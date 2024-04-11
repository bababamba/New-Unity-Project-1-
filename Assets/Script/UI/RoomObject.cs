using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomObject : MonoBehaviour
{
    public Room.RoomType roomType;
    public Sprite[] Images;

    public int[] position = new int[2];

    public void SetImage(int num)
    {
        this.GetComponent<Image>().sprite = Images[num];
    }


    public void OnClick()
    {
        PlayerData.data.lastRoom[0] = position[0];
        PlayerData.data.lastRoom[1] = position[1];
        PlayerData.data.curFloor++;
        PlayerData.data.UpdateMapData();

        switch (roomType)
        {
            case Room.RoomType.COMBAT:
                MapUIManager.manager.ToCombatScene(Room.RoomType.COMBAT);
                break;
            case Room.RoomType.ELITE:
                MapUIManager.manager.ToCombatScene(Room.RoomType.ELITE);
                break;
            case Room.RoomType.BOSS:
                MapUIManager.manager.ToCombatScene(Room.RoomType.BOSS);
                break;
            case Room.RoomType.EVENT:
                MapUIManager.manager.OpenUI(0);
                break;
            case Room.RoomType.MERCHANT:
                MapUIManager.manager.OpenUI(1);
                break;
            case Room.RoomType.FIREPLACE:
                MapUIManager.manager.OpenUI(777);
                break;
            case Room.RoomType.CHEST:
                MapUIManager.manager.OpenUI(111);
                break;
            default:
                break;
        }

    }
}
