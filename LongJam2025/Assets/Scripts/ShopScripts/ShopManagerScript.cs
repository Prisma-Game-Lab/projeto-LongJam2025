using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject endButton;
    public int[,] shopItems = new int[5, 16];
    public float _points;
    public float Points
{
    get => _points;
    set
    {
        _points = value;
        if (PointsTxt != null)
        {
            PointsTxt.text = _points.ToString();
        }
    }
}

    public bool isVisible = false;

    public float total_points = 0;

    public int[] tiers = new int[3];

    public TMP_Text PointsTxt;

    private float holdTime = 0f;

    public float time = 0;
    private float holdThreshold = 1f;
    private bool isHolding = false;

    public int tier1_price;

    public int tier2_price;

    public int base_pc;

    public int pc_per_item;
    public int tier3_price;
    private int number_of_items = 15;
    private GameObject buttonRef;

    public GameObject[] itemList;
   // public GridManager gridManager;

    void Start()
    {
        GameManager.tier = 0;
        Points = Points;
       
        shopItems[1,1] = tier1_price;
        shopItems[3,1] = 1;
        for (int i = 1; i <= number_of_items; i++)
        {
            shopItems[0, i] = i;     // Item ID
            shopItems[2, i] = 0;
            shopItems[4,i] = 0;
            if (i <= 9 && i>1){
            shopItems[1,i] = tier2_price;
            shopItems[3,i] = 2;
            }
            if (i > 9){
            shopItems[1,i] = tier3_price;
            shopItems[3,i] = 3;

            }
        }
        
        for (int i=0;i<3;i++){
            tiers[i] = 0;
        }
    }

    public void addPoints(){
        int total = 0;
        for (int i=1;i<=number_of_items;i++){
            if (shopItems[2,i] > 0){
                total += base_pc * (int)Mathf.Pow(pc_per_item,shopItems[3,i]);
            }
        }
        total_points += total;
        Points += total;
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 1.0f) {
            addPoints();
            time = 0.0f;
            
        }
        PointsTxt.text = _points.ToString();

        if(total_points >= 50){
            tiers[0] = 1;
            GameManager.tier = 1;
            if (total_points>= 1500){
                tiers[1] = 1;
               GameManager.tier = 2;
                if (total_points >= 45000){
                    tiers[2] = 1;
                   GameManager.tier = 3;
                    if (total_points >= 100000)
                    {
                        endButton.SetActive(true);
                    }
        }  
        }
        }

        
        if (isHolding)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdThreshold)
            {
                if(isVisible == true)
                MoveItem(); 
                isHolding = false;
            }
        }
    }

    public void OnButtonDown(GameObject button)
    {
        buttonRef = button;
        isHolding = true;
        holdTime = 0f;

        
        ScrollRect scrollRect = button.GetComponentInParent<ScrollRect>();
        if (scrollRect != null)
        {
            
        }
    }

    public void OnButtonUp()
    {
        if (holdTime < holdThreshold)
        {
            if (isVisible == true)
            Buy(); 
        }
        isHolding = false;
    }

    public GameObject IdToObject(int itemId)
    {
        return itemList[0];
    }

    private void Buy()
    {
        if (buttonRef == null) return;

        int itemId = buttonRef.GetComponent<ButtonInfo>().ItemId;

        if (shopItems[2,itemId] > 0 && shopItems[4,itemId] == 0){
             AudioManager.Instance.PlaySFX("buy");
             shopItems[4,itemId] = 1;
        }
        
        if (Points >= shopItems[1, itemId] && shopItems[2,itemId] == 0)
        {
            shopItems[4,itemId] = 1;
            AudioManager.Instance.PlaySFX("buy");
           Points -= shopItems[1, itemId];
            if (shopItems[2,itemId] == 0){
            shopItems[2, itemId] += 1;
            }
            
           // GridManager.instance.InitializeMovel(IdToObject(itemId));
            
        }
        else
        {
            
        }
    }

    private void MoveItem()
    {
        if (buttonRef == null) return;

        int itemId = buttonRef.GetComponent<ButtonInfo>().ItemId;
         shopItems[4,itemId] = 0;

        if (shopItems[2, itemId] > 0)
        {
           
            //shopItems[2, itemId] -= 1;
            
            
           
        }
        else
        {
           
        }
    }
}
