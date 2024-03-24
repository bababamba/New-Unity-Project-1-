using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopProductButton : MonoBehaviour
{
    public ShopUI shop;

    public void Purchase(int num)
    {
        if (shop.Purchase(num))
            this.GetComponent<Button>().interactable = false;
    }
}
