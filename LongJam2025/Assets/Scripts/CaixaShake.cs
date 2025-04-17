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
    public void earnPoints()
    {
        AudioManager.Instance.PlaySFX("box");
        shop._points += 5 + GameManager.tier * 10;
        shop.total_points += 5 + GameManager.tier * 10;
    }

    public void OnMouseDown()
    {
        animator.SetTrigger("Click");
        earnPoints();
    }
}
