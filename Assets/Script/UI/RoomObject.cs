using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomObject : MonoBehaviour
{
    public Sprite[] Images;

    public void SetImage(int num)
    {
        this.GetComponent<Image>().sprite = Images[num];
    }
}
