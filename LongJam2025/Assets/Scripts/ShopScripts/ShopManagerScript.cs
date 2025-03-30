using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[13, 13];
    public float points;

    public bool isVisible = false;

    public float points_spent = 0;

    public int[] tiers = new int[3];

    public TMP_Text PointsTxt;

    private float holdTime = 0f;
    private float holdThreshold = 1f;
    private bool isHolding = false;
    private GameObject buttonRef; 

    void Start()
    {
        PointsTxt.text = points.ToString();
       

        // Initialize shop items
        for (int i = 1; i <= 12; i++)
        {
            shopItems[1, i] = i;       // Item ID
            shopItems[2, i] = i * 10;  // Prices
            shopItems[3, i] = 0;       // Quantity
        }
        for (int i=0;i<3;i++){
            tiers[i] = 0;
        }
    }

    void Update()
    {
        if(points_spent >= 250){
            tiers[0] = 1;
            if(points_spent >= 500){
                tiers[1] = 1;
                if(points_spent >= 750){
                    tiers[2] = 1;
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

    private void Buy()
    {
        if (buttonRef == null) return;

        int itemId = buttonRef.GetComponent<ButtonInfo>().ItemId;

        if (points >= shopItems[2, itemId])
        {
            points -= shopItems[2, itemId];
            points_spent += shopItems[2, itemId];
            shopItems[3, itemId] += 1;
            PointsTxt.text = points.ToString();
            Debug.Log("Item " + itemId + " comprado com sucesso!");
        }
        else
        {
            Debug.Log("Você não tem pontos suficientes para comprar o item " + itemId + "!");
        }
    }

    private void MoveItem()
    {
        if (buttonRef == null) return;

        int itemId = buttonRef.GetComponent<ButtonInfo>().ItemId;

        if (shopItems[3, itemId] > 0)
        {
            shopItems[3, itemId] -= 1;
            PointsTxt.text = points.ToString();
            Debug.Log("Item " + itemId + " movido  com sucesso!");
        }
        else
        {
            Debug.Log("Você não tem esse item para mover!");
        }
    }
}
