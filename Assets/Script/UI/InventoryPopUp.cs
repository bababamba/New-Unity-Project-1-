using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InventoryPopUp : MonoBehaviour
{
    public UIManager manager;

    public IconPanel iconPanel;

    private Canvas[] inventory;
    private TMP_Text[] weaponText;


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "maingame")
            manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        this.gameObject.SetActive(false);
    }

    public void Init()
    {
        IconPanel.iconPanel = this.iconPanel;

        inventory = this.transform.Find("Inventory").GetComponentsInChildren<Canvas>();
        weaponText = this.transform.Find("DescPanel").GetComponentsInChildren<TMP_Text>();

        //this.transform.Find("Inventory").SetAsFirstSibling();

        

        int count = 0;
        foreach(Canvas c in inventory)
        {
            IconPanel[] buttons = c.transform.GetComponentsInChildren<IconPanel>();

            for(int i = 0; i < buttons.Length; i++)
            {
                while (count < PlayerData.data.weapons.Length && !PlayerData.data.weapons[count].active)
                    count++;

                if (count >= PlayerData.data.weapons.Length)
                {
                    buttons[i].gameObject.SetActive(false);
                    continue;
                }
                buttons[i].SetWeapon(PlayerData.data.weapons[count]);
                count++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetWeaponDesc();
    }

    public void SetWeaponDesc()
    {
        if(iconPanel.GetWeapon() == null)
        {
            foreach (TMP_Text text in weaponText)
                text.text = "";
        }
        else
        {
            foreach(TMP_Text text in weaponText)
            {
                switch (text.transform.name)
                {
                    case "WeaponName":
                        text.text = iconPanel.GetWeapon().getItemName() + "";
                        break;
                    case "Level":
                        text.text = "Level " + iconPanel.GetWeapon().level;
                        break;
                    case "Description":
                        text.text = iconPanel.GetWeapon().getItemText() + "";
                        break;
                    default:
                        text.text = "";
                        break;
                }
            }
            iconPanel.SetText(iconPanel.GetWeapon().level);
        }
    }

    public void Close()
    {
        if (SceneManager.GetActiveScene().name == "IngameMapScreen")
            MapUIManager.manager.CloseUI(5);
        else if (SceneManager.GetActiveScene().name == "maingame")
        {
            manager.ResumeGame();
            gameObject.SetActive(false);
        }
    }

}
