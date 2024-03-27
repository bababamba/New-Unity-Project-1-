using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadPanel : MonoBehaviour
{
    public void Disable()
    {
        this.transform.Find("Background").GetComponent<Image>().raycastTarget = false;
        GetComponentInChildren<Button>().interactable = false;
    }

    public void Enable()
    {
        this.transform.Find("Background").GetComponent<Image>().raycastTarget = true;
        GetComponentInChildren<Button>().interactable = true;
    }

    void Update()
    {
        this.transform.Find("HPText").GetComponent<Text>().text = PlayerData.data.curHP + " / " + PlayerData.data.maxHP;
        this.transform.Find("GoldText").GetComponent<Text>().text = PlayerData.data.gold + "";
    }

    public void OnClick()
    {
        MapUIManager.manager.OpenUI(2);
    }

}
