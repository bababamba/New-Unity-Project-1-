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
        OptionPanel[1].text = "´Ý±â";
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
                    ChangeScreen(optionNum);
                    break;
                case 1:
                    ChangeScreen(optionNum);
                    break;
                case 2:
                    ChangeScreen(optionNum);
                    break;
                case 3:
                    ChangeScreen(optionNum);
                    break;
                case 4:
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
