using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData data = null;

    public int maxHP;
    public int curHP;
    public float speed;

    public int gold = 0;
    public weapon_base[] weapons = new weapon_base[11];
    public Player player;

    public bool initialized = true;

    public Room[,] rooms;
    public int[] lastRoom = new int[2];
    public List<int[]> lastRooms;
    public int curFloor;
    public bool savedLevelData = false;
    public int enemyPool;
    public int killCount = 0;


    void Awake()
    {
        // 싱글톤
        if (data == null)
        {
            data = this;

            // 씬 변경시 제거X
            DontDestroyOnLoad(this.gameObject);

            //Debug.Log("new data");
            initialized = false;
        }
        else
        {
            Destroy(this.gameObject);
            //Debug.Log("delete duplicate");
        }
        // 최초 한정 초기 데이터 입력
        if (initialized == false)
        {
            CreatePlayerData(100,100, 10, 999, true);
            //Debug.Log(".......");
        }
        foreach(weapon_base weapon in weapons)
        {
            weapon.Init();
            //Debug.Log(weapon.GetType() + " : level " + weapon.level);
            //Debug.Log(weapon.active);
        }

        

    }

    public void UpdateMapData()
    {
        if(!savedLevelData)
        {
            rooms = new Room[Level.level.width, Level.level.height + 1];
            rooms = Level.level.rooms;
            lastRoom = Level.level.lastRoom;
            lastRooms = new List<int[]>();
            curFloor = Level.level.curFloor;
            savedLevelData = true;
        }
        else
        {
            Level.level.rooms = rooms;
            Level.level.lastRoom = lastRoom;
            Level.level.lastRooms = lastRooms;
            Level.level.curFloor = curFloor;
        }
    }

    public void CreatePlayerData(int maxhpValue, int hpValue, float speedValue, int goldValue, bool newData = false)
    {
        maxHP = maxhpValue;
        curHP = hpValue;
        speed = speedValue;
        gold = goldValue;

        // 처음에 들고 있을 무기에 active = true; 작성
        foreach (weapon_base weapon in weapons)
        {
            if (newData)
            {
                weapon.level = 1;
                weapon.active = false;
            }
        }
        if (newData)
        {
            weapons[7].active = true;
            weapons[7].level = 4000;
        }
        if (newData)
        {
            savedLevelData = false;
            killCount = 0;

            curFloor = 0;
        }

        initialized = true;
    }

    public void GivePlayerData(Player p)
    {
        p.init(maxHP, speed, 1);
        p.setCurHP(curHP);

        Transform inventory = p.transform.Find("ItemPool");
        foreach (weapon_base weapon in weapons)
        {
            Instantiate(weapon, inventory);
        }
        this.player = p;
    }

}
