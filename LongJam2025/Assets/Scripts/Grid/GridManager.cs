using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public GridLayout gridLayout;
    public Tilemap mainMap;
    public Tilemap tempMap;

    public TileBase[] tileTypes;

    public GameObject movel;

    public static Dictionary<States, TileBase> tileBases = new Dictionary<States, TileBase>();
    private MovelManager temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;


    public enum States
    {
        Empty,
        Green,
        White,
        Red
    }

    // Start is called before the first frame update
    void Start()
    {
        tileBases.Add(States.Empty, null);
        tileBases.Add(States.Green, tileTypes[0]);
        tileBases.Add(States.White, tileTypes[1]);
        tileBases.Add(States.Red, tileTypes[2]);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) { InitializeMovel(movel); }
        if (temp == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            if (!temp.Placed)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = gridLayout.LocalToCell(mousePos);

                if (prevPos != cellPos)
                {
                    temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos + new Vector3(0, 0, 0));
                    prevPos = cellPos;
                    FollowBuilding();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (temp.CanBePlaced())
            {
                temp.Place();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearArea();
            Destroy(temp.gameObject);
        }
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        if (area.size.z == 0) print("ESQUECEU DE MUDAR O TAMANHO DO Z PARA DIFERENTE DE 0");
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tiles = new TileBase[size];

        int i = 0;
        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            tiles[i] = tilemap.GetTile(pos);
            i++;
        }
        return tiles;
    }

    private static void FillTiles(TileBase[] tiles, States type)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = tileBases[type];
        }
    }

    private static void SetTilesBlock(BoundsInt area, States type, Tilemap tilemap)
    {
        if (area.size.z == 0) print("ESQUECEU DE MUDAR O TAMANHO DO Z PARA DIFERENTE DE 0");
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tiles = new TileBase[size];
        FillTiles(tiles, type);
        tilemap.SetTilesBlock(area, tiles);
    }

    public void InitializeMovel(GameObject movel)
    {
        temp = Instantiate(movel, Vector3.zero, Quaternion.identity).GetComponent<MovelManager>();
        FollowBuilding();
    }

    private void ClearArea()
    {
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, States.Empty);
        tempMap.SetTilesBlock(prevArea, toClear);
    }

    private void FollowBuilding()
    {
        ClearArea();
        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt area = temp.area;

        TileBase[] baseArray = GetTilesBlock(area, mainMap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for (int i = 0; i < baseArray.Length; i++)
        {
            if (baseArray[i] == tileBases[States.White])
            {
                tileArray[i] = tileBases[States.Green];
            }
            else
            {
                FillTiles(tileArray, States.Red);
                break;
            }
        }

        tempMap.SetTilesBlock(area, tileArray);
        prevArea = area;
    }

    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, mainMap);
        foreach (var b in baseArray)
        {
            if (b != tileBases[States.White])
            {
                return false;
            }
        }
        return true;
    }

    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, States.Empty, tempMap);
        SetTilesBlock(area, States.Green, mainMap);
    }
}
