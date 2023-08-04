using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;  // �κ��丮 Ȱ��ȭ ����. true�� �Ǹ� ī�޶� �����Ӱ� �ٸ� �Է��� ���� ���̴�.

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base �̹���
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot���� �θ��� Grid Setting 

    private slot[] slots;  // ���Ե� �迭

    public item_base currentItem; // ȹ���� ������
    public int itemLevel; // �۷�
    public Image itemImage;  // �������� �̹���
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
            if (slots[i].item != null)  // null �̶�� slots[i].item.itemName �� �� ��Ÿ�� ���� ����
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