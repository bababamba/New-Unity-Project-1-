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
        // �̺�Ʈ ��ȣ�� 1�� �з�, ���� �������� �з�
    }
}
