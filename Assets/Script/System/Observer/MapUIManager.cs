using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class MapUIManager : MonoBehaviour
{
    public TextAsset EventData;

    public GameObject[] PoPUpScreen;
    public GameObject[] Screen;
    public static MapUIManager manager;
    public Random random = new Random();

    public static Level level;

    public bool isAnyUIOpen = false;
    private bool gameOver = false;

    void Awake()
    {
        if (manager == null)
            manager = this;
        else if (manager != this)
            Destroy(this);

        if(level == null)
            level = this.GetComponentInChildren<Level>();
            
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

        if(PlayerData.data.curHP <= 0 && !gameOver)
        {
            gameOver = true;
            for (int i = 0; i < 4; i++)
                CloseUI(i);
            OpenUI(4);
        }

        if (Input.GetKey(KeyCode.I))
            OpenUI(5);
    }

    public void OpenUI(int num)
    {
        if(isAnyUIOpen && num != 3 && num != 4)
            return;

        if (num == 111 || num == 777)
            PoPUpScreen[0].SetActive(true);
        else if(num==3)
            PoPUpScreen[num].transform.position = Vector2.zero;
        else
            PoPUpScreen[num].SetActive(true);

        if (num == 0)
            PoPUpScreen[num].GetComponent<EventUI>().Init(random.Next(0, 5));
        //PoPUpScreen[num].GetComponent<EventUI>().Init(3);
        else if (num == 1)
            PoPUpScreen[num].GetComponent<ShopUI>().OpenShop();
        else if (num == 4)
        {
            foreach (Canvas c in Level.level.floor)
                c.sortingOrder = 0;
        }
        else if (num == 5)
            PoPUpScreen[num].GetComponent<InventoryPopUp>().Init();
        else if (num == 111)
            PoPUpScreen[0].GetComponent<EventUI>().Init(5);
        else if (num == 777)
            PoPUpScreen[0].GetComponent<EventUI>().Init(6);

        if (num == 111 || num == 777)
            PoPUpScreen[0].GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        else
            PoPUpScreen[num].GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        isAnyUIOpen = true;
    }

    public void CloseUI(int num)
    {


        if (num != 3)
        {
            isAnyUIOpen = false;
            PoPUpScreen[num].SetActive(false);
        }
        else
            PoPUpScreen[num].transform.position = new Vector2(-2000, -2000);
    }

    public Dictionary<int, Dictionary<string, string>> ReadCSV(TextAsset file)
    {
        string[] key = null;
        string[] value = null;
        Dictionary<string, string> dataset = new Dictionary<string, string>();
        Dictionary<int, Dictionary<string, string>> eventdata = new Dictionary<int, Dictionary<string, string>>();
        int num = 0;

        string[] data = file.text.Split('\n');
        foreach (string s in data)
        {
            if (string.IsNullOrEmpty(s)) break;
            if (s.Substring(0, 1).Equals("!")) break;

            dataset = new Dictionary<string, string>();

            if (s.Substring(0, 1).Equals("#")) // 첫 줄에 각 항목에 대한 간단한 설명이 들어가고, 이를 읽어 딕셔너리 키로 사용
            {
                key = s.Split(',');
                key[0] = key[0].Replace("#", "");
                key[6] = key[6].Replace("\r\n", "");
                continue;
            }

            value = s.Split(',');
            value[6] = value[6].Replace("\r\n", "");
            for (int i = 0; i < key.Length; i++)
                dataset.Add(key[i], value[i]);

            eventdata.Add(num, dataset);
            //dataset.Clear();
            num += 1;
        }

        return eventdata;
    }

    public void ToCombatScene(Room.RoomType type)
    {
        Audio_Manager.Instance.SFX_Click();
        int num = 0;
        if (type == Room.RoomType.COMBAT)
            num = random.Next(0, 4);
        else if (type == Room.RoomType.ELITE)
        {

        }
        else if (type == Room.RoomType.BOSS)
            num = 100;
        PlayerData.data.enemyPool = num;
        SceneManager.LoadScene("maingame");
    }
}
