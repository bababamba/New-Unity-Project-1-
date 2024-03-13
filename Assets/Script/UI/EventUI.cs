using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    public Text EventNamePanel;
    public Text EventDescriptionPanel;
    public Button[] Buttons;

    public string EventName;
    public string EventDescription;
    public string[] option;
    public string[] AfterEventDescription;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Init()
    {
        
    }

    public void Execute(int eventNum, int optionNum)
    {
        // 이벤트 번호로 1차 분류, 이후 선택지별 분류
    }
}
