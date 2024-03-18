using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapUIManager : MonoBehaviour
{
    public GameObject[] PoPUpScreen;
    public GameObject[] Screen;
    public static MapUIManager manager;

    private bool isAnyUIOpen = false;


    void Start()
    {
        if (manager == null)
            manager = this;
        else if (manager != this)
            Destroy(this);
    }

    void Update()
    {
        if(isAnyUIOpen)
        {
            Screen[0].GetComponent<HeadPanel>().Disable();
            Screen[1].GetComponent<Level>().Disable();
        }
        else
        {
            Screen[0].GetComponent<HeadPanel>().Enable();
            Screen[1].GetComponent<Level>().Enable();
        }
    }


    public void OpenUI(int num)
    {
        if(isAnyUIOpen)
            return;

        PoPUpScreen[num].SetActive(true);
        PoPUpScreen[num].GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        isAnyUIOpen = true;
    }
    public void CloseUI(int num)
    {
        PoPUpScreen[num].SetActive(false);

        isAnyUIOpen = false;
    }
}
