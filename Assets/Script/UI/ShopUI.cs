using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Close()
    {
        MapUIManager.manager.CloseUI(1);
    }



    public bool payable()
    {

        return false;
    }
}
