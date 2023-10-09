using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public item_base item; // ȹ���� ������
    public int itemLevel; // �۷�
    public Image itemImage;  // �������� �̹���

    [SerializeField]
    private TextMeshProUGUI text_Count;
    [SerializeField]
    private GameObject go_CountImage;
    [SerializeField]
    private inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<inventory>();
    }
    // ������ �̹����� ���� ����
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // �κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(item_base _item, int _level = 1)
    {
        item = _item;
        itemLevel += _level;
        
        itemImage.sprite = item.itemImage;
        item.active = true;
        if (itemLevel > 1)
        {
            item.levelUp();
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

    // �ش� ������ ������ ���� ������Ʈ
    public void SetSlotLevel(int _Level)
    {
        itemLevel += _Level;
        text_Count.text = itemLevel.ToString();

        if (itemLevel <= 0)
            ClearSlot();
        else if(itemLevel < 2)
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
    }

    // �ش� ���� �ϳ� ����
    private void ClearSlot()
    {
        item.active = false;
        item = null;
        itemLevel = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
    private void ClearSlot2()
    {
        
        item = null;
        itemLevel = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                inventory.ClearCurrentSlot();
                inventory.AddCurrentItem(item,itemLevel);
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (item != null)
        {
            Audio_Manager.Instance.SFX_ClickBucket();
            dragSlot.instance.dragslot = this;
            dragSlot.instance.DragSetImage(itemImage);
            dragSlot.instance.transform.position = eventData.position;
        }
    }

    // ���콺 �巡�� ���� �� ��� �߻��ϴ� �̺�Ʈ
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
            dragSlot.instance.transform.position = eventData.position;
    }

    // ���콺 �巡�װ� ������ �� �߻��ϴ� �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {
        dragSlot.instance.SetColor(0);
        dragSlot.instance.dragslot = null;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (dragSlot.instance.dragslot != null)
            ChangeSlot();
    }

    private void ChangeSlot()
    {
        item_base _tempItem = item;
        int _tempItemCount = itemLevel;
        ClearSlot2();
        AddItem(dragSlot.instance.dragslot.item, dragSlot.instance.dragslot.itemLevel);


        if (_tempItem != null)
        {
            dragSlot.instance.dragslot.ClearSlot2();
            dragSlot.instance.dragslot.AddItem(_tempItem, _tempItemCount);
        
        }
        else
            dragSlot.instance.dragslot.ClearSlot2();
       
    }
}
