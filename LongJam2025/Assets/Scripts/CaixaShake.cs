using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaShake : MonoBehaviour
{
    public ShopManagerScript shop;

    Animator animator;

    private void Start()
    {
           animator = this.GetComponent<Animator>();
    }

    public void OnMouseDown()
    {
        animator.SetTrigger("Click");
        shop.addPoints();
    }
}
