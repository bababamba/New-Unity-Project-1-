using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public item_base item; // 획득한 아이템
    public int itemLevel; // 템렙
    public Image itemImage;  // 아이템의 이미지

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
    // 아이템 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
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

    // 해당 슬롯의 아이템 갯수 업데이트
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

    // 해당 슬롯 하나 삭제
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

    // 마우스 드래그 중일 때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
            dragSlot.instance.transform.position = eventData.position;
    }

    // 마우스 드래그가 끝났을 때 발생하는 이벤트
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
