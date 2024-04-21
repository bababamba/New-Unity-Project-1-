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

    public void SetColor(Color c)
    {
        ColorBlock b =  this.GetComponent<Button>().colors;
        Image i = this.GetComponent<Image>();
        b.normalColor = c;
        b.selectedColor = c;
        b.disabledColor = c;
        b.pressedColor = c;
        i.color = c;
        Debug.Log("asd");
    }


    public void OnClick()
    {
        SetColor(new Color(186 / 255f, 109 / 255f, 25 / 255f));
        PlayerData.data.rooms[position[0], position[1]].path = true;
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
