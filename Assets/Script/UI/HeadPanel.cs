using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadPanel : MonoBehaviour
{
    public void Disable()
    {
        GetComponentInChildren<Image>().raycastTarget = false;
        GetComponentInChildren<Button>().interactable = false;
    }

    public void Enable()
    {
        GetComponentInChildren<Image>().raycastTarget = true;
        GetComponentInChildren<Button>().interactable = true;
    }

    public void OnClick()
    {
        MapUIManager.manager.OpenUI(2);
    }

}
