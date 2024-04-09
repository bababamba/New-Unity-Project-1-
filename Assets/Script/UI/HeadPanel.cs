using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadPanel : MonoBehaviour
{
    public UIManager manager;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "maingame")
            manager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void Disable()
    {
        this.transform.Find("Background").GetComponent<Image>().raycastTarget = false;
        foreach(Button b in GetComponentsInChildren<Button>())
            b.interactable = false;
    }

    public void Enable()
    {
        this.transform.Find("Background").GetComponent<Image>().raycastTarget = true;
        foreach (Button b in GetComponentsInChildren<Button>())
            b.interactable = true;
    }

    void Update()
    {
        this.transform.Find("Status_Life").Find("HPText").GetComponent<Text>().text = PlayerData.data.curHP + " / " + PlayerData.data.maxHP;
        this.transform.Find("Status_Coin").Find("GoldText").GetComponent<Text>().text = PlayerData.data.gold + "";
    }

    public void OnClick()
    {
        MapUIManager.manager.OpenUI(2);
    }

    public void PauseMenu()
    {
        if(!manager.isPaused)
        {
            manager.PauseGame();
            manager.pauseMenu.SetActive(true);
        }
        else
        {
            manager.pauseMenu.SetActive(false);
            manager.ResumeGame();
        }
    }

    public void Inventory()
    {
        if(!manager.isPaused)
        {
            manager.PauseGame();
            manager.inventoryObject.GetComponent<InventoryPopUp>().Init();
            manager.inventoryObject.SetActive(true);
        }
        else
        {
            manager.inventoryObject.SetActive(false);
            manager.ResumeGame();
        }
    }

}
