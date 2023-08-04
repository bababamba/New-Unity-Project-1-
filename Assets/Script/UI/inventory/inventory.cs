using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;  // 인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력을 막을 것이다.

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 

    private slot[] slots;  // 슬롯들 배열

    public item_base currentItem; // 획득한 아이템
    public int itemLevel; // 템렙
    public Image itemImage;  // 아이템의 이미지
    [SerializeField]
    private TextMeshProUGUI text_Count;
    [SerializeField]
    private TextMeshProUGUI item_Text;
    [SerializeField]
    private GameObject go_CountImage;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<slot>();
        gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        ClearCurrentSlot();
        go_InventoryBase.SetActive(false);
    }
    public void AddCurrentItem(item_base _item, int _level = 1)
    {
        currentItem = _item;
        itemLevel = _level;
        itemImage.sprite = currentItem.itemImage;
        item_Text.text = currentItem.getItemName() +"\n\n"+ currentItem.getItemText() + "\n\n" + currentItem.getItemCaption();
        if (itemLevel > 1)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemLevel.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }
    public void ClearCurrentSlot()
    {
        currentItem = null;
        itemLevel = 0;
        itemImage.sprite = null;
        SetColor(0);
        item_Text.text = null;
        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    public void AcquireItem(item_base _item, int _count = 1)
    {
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
            {
                if (slots[i].item.getItemNumber() == _item.getItemNumber())
                {
                    slots[i].AddItem(_item, _count);
                    return;
                }
            }
        }
        

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

}