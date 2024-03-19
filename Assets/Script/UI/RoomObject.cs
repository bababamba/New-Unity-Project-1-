using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomObject : MonoBehaviour
{
    public Room.RoomType roomType;
    public Sprite[] Images;

    public void SetImage(int num)
    {
        this.GetComponent<Image>().sprite = Images[num];
    }


    public void OnClick()
    {
        switch (roomType)
        {
            case Room.RoomType.COMBAT:
                
                break;
            case Room.RoomType.ELITE:

                break;
            case Room.RoomType.BOSS:

                break;
            case Room.RoomType.EVENT:
                MapUIManager.manager.OpenUI(0);
                break;
            case Room.RoomType.MERCHANT:
                MapUIManager.manager.OpenUI(1);
                break;
            case Room.RoomType.FIREPLACE:
                MapUIManager.manager.OpenUI(0);
                break;
            case Room.RoomType.CHEST:
                MapUIManager.manager.OpenUI(0);
                break;
            default:
                break;
        }

    }
}
