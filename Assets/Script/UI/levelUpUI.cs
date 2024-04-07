using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class levelUpUI : MonoBehaviour
{

    [SerializeField]
    private GameObject go_LevelUpBase;
    public item_base currentItem1; // »πµÊ«— æ∆¿Ã≈€
    [SerializeField]
    private Image itemImage1;
    public item_base currentItem2; // »πµÊ«— æ∆¿Ã≈€
    [SerializeField]
    private Image itemImage2;
    public item_base currentItem3;
    [SerializeField]// »πµÊ«— æ∆¿Ã≈€
    private Image itemImage3;

    int selected = 0;
    [SerializeField]
    private TextMeshProUGUI select1_Text;
    [SerializeField]
    private TextMeshProUGUI select2_Text;
    [SerializeField]
    private TextMeshProUGUI select3_Text;
    [SerializeField]
    private TextMeshProUGUI item_Text;

    [SerializeField]
    private inventory inventory;

    [SerializeField]
    private UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OpenLevelUP()
    {
        go_LevelUpBase.SetActive(true);
    }

    public void CloseLevelUP()
    {
        SetColor(0);
        go_LevelUpBase.SetActive(false);
    }

 
    public void onclickItem1()
    {
        if (selected != 1)
        {
            select1_Text.text = "¥ŸΩ√ ¥≠∑Øº≠ »πµÊ!!";
            select2_Text.text = currentItem2.getItemName();
            select3_Text.text = currentItem3.getItemName();
            selected = 1;
            item_Text.text = currentItem1.getItemName() + "\n\n" + currentItem1.getItemText() + "\n\n" + currentItem1.getItemCaption();
        }
        else
        {
            for (int i = 0; i < PlayerData.data.weapons.Length; i++)
            {
                if (PlayerData.data.weapons[i].GetType() == currentItem1.GetType())
                {
                    if (PlayerData.data.weapons[i].active)
                        PlayerData.data.weapons[i].levelUp();
                    else
                        PlayerData.data.weapons[i].active = true;
                    Debug.Log(PlayerData.data.weapons[i].GetType());
                }
            }
            inventory.AcquireItem(currentItem1);
            uIManager.LevelUp();
            CloseLevelUP();
        }
    }
    public void onclickItem2()
    {
        if (selected != 2)
        {
            select2_Text.text = "¥ŸΩ√ ¥≠∑Øº≠ »πµÊ!!";
            select1_Text.text = currentItem1.getItemName();
            select3_Text.text = currentItem3.getItemName();
            selected = 2;
            item_Text.text = currentItem2.getItemName() + "\n\n" + currentItem2.getItemText() + "\n\n" + currentItem2.getItemCaption();
        }
        else
        {
            for (int i = 0; i < PlayerData.data.weapons.Length; i++)
            {
                if (PlayerData.data.weapons[i].GetType() == currentItem2.GetType())
                {
                    if (PlayerData.data.weapons[i].active)
                    {
                        PlayerData.data.weapons[i].levelUp();
                        Debug.Log("lvlup");
                    }
                    else
                    {
                        PlayerData.data.weapons[i].active = true;
                        Debug.Log("new" + PlayerData.data.weapons[i].active);
                    }
                    Debug.Log(PlayerData.data.weapons[i].GetType());
                    Debug.Log(currentItem2.GetType());
                }
            }
            inventory.AcquireItem(currentItem2);
            uIManager.LevelUp();
            CloseLevelUP();
        }
    }
    public void onclickItem3()
    {
        if (selected != 3)
        {
            select3_Text.text = "¥ŸΩ√ ¥≠∑Øº≠ »πµÊ!!";
            select1_Text.text = currentItem1.getItemName();
            select2_Text.text = currentItem2.getItemName();
            selected = 3;
            item_Text.text = currentItem3.getItemName() + "\n\n" + currentItem3.getItemText() + "\n\n" + currentItem3.getItemCaption();
        }
        else
        {
            for(int i = 0; i < PlayerData.data.weapons.Length; i++)
            {
                if (PlayerData.data.weapons[i].GetType() == currentItem3.GetType())
                {
                    if (PlayerData.data.weapons[i].active)
                        PlayerData.data.weapons[i].levelUp();
                    else
                        PlayerData.data.weapons[i].active = true;
                    Debug.Log(PlayerData.data.weapons[i].GetType());
                }
            }
            
            inventory.AcquireItem(currentItem3);
            uIManager.LevelUp();
            CloseLevelUP();
        }
    }
    public void setItems(item_base item1, item_base item2, item_base item3)
    {
        currentItem1 = item1;
        itemImage1.sprite = item1.itemImage;
        currentItem2 = item2;
        itemImage2.sprite = item2.itemImage;
        currentItem3 = item3;
        itemImage3.sprite = item3.itemImage;
        select1_Text.text = currentItem1.getItemName();
        select2_Text.text = currentItem2.getItemName();
        select3_Text.text = currentItem3.getItemName();
        SetColor(1);
    }
    private void SetColor(float _alpha)
    {
        Color color = itemImage1.color;
        color.a = _alpha;
        itemImage1.color = color;
        Color color2 = itemImage2.color;
        color2.a = _alpha;
        itemImage2.color = color2;
        Color color3 = itemImage3.color;
        color3.a = _alpha;
        itemImage3.color = color3;
    }
}
