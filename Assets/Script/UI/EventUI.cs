using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    public Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>();
    public Text EventNamePanel;
    public Text DescriptionPanel;
    public Text[] OptionPanel;

    public Button[] Buttons;

    public int EventNum;
    public string EventName;
    public string Description;
    public string[] Option = new string[2];
    public string[] OptionResult = new string[2];

    public bool optionSelected = false;

    void Start()
    {
        data = new Dictionary<int, Dictionary<string, string>>(MapUIManager.manager.ReadCSV(MapUIManager.manager.EventData));
        OptionPanel[0] = Buttons[0].GetComponentInChildren<Text>();
        OptionPanel[1] = Buttons[1].GetComponentInChildren<Text>();
        this.gameObject.SetActive(false);
    }

    public void Init(int eventNum)
    {

        Dictionary<string, string> eventdata = new Dictionary<string, string>();
        eventdata = data[eventNum];


        EventNum = int.Parse(eventdata["EventNum"]);
        EventName = eventdata["EventName"];
        Description = eventdata["Description"];
        Option[0] = eventdata["Option1"];
        Option[1] = eventdata["Option2"];
        OptionResult[0] = eventdata["Option1Result"];
        OptionResult[1] = eventdata["Option2Result\r"];

        EventNamePanel.text = EventName;
        DescriptionPanel.text = Description;
        OptionPanel[0].text = Option[0];
        OptionPanel[1].text = Option[1];    
    }

    public void ChangeScreen(int num)
    {
        DescriptionPanel.text = OptionResult[num];
        Buttons[0].gameObject.SetActive(false);
        OptionPanel[1].text = "닫기";
    }

    public void Close()
    {
        MapUIManager.manager.CloseUI(0);
    }

    public void Execute(int optionNum)
    {
        if (!optionSelected)
        {
            switch (EventNum)
            {
                case 0:
                    // 보유한 랜덤 무기 업글
                    ChangeScreen(optionNum);
                    break;
                case 1:
                    // 보유무기 1종, 미보유 무기 1종 선택 후, 보유무기는 1렙 미보유로 변경 / 미보유무기는 보유 n렙(보유무기렙)으로 변경
                    ChangeScreen(optionNum);
                    break;
                case 2:
                    // 가장 낮은 무기렙 * 100 지급. 해당 무기는 1렙 미보유로 변경
                    ChangeScreen(optionNum);
                    break;
                case 3:
                    // 골드 일정범위 내에서 지급. 최대체력 20%데미지
                    ChangeScreen(optionNum);
                    break;
                case 4:
                    // 다음층 대신 보스층 활성화
                    ChangeScreen(optionNum);
                    break;
                default:
                    break;
            }
            optionSelected = true;
        }
        else
        {
            Buttons[0].gameObject.SetActive(true);
            optionSelected = false;
            MapUIManager.manager.CloseUI(0);
        }
    }

}
