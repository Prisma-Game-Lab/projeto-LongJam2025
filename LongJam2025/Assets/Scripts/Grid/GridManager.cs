using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public GridLayout gridLayout;
    public Tilemap mainMap;
    public Tilemap tempMap;

    public static Dictionary<States, TileBase> tileBases = new Dictionary<States, TileBase>();
    private MovelManager temp;
    private Vector3 prevPos;
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
        string tilepath = @"Images\Tilemap\grid_";
        tileBases.Add(States.Empty, null);
        tileBases.Add(States.Green, Resources.Load<TileBase>(path: tilepath + "green"));
        tileBases.Add(States.White, Resources.Load<TileBase>(path: tilepath + "white"));
        tileBases.Add(States.Red, Resources.Load<TileBase>(path: tilepath + "red"));
    }
    
    private void Awake()
    {
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        
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
}
