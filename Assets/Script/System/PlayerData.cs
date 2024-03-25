using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData data;

    public int maxHP;
    public int curHP;
    public float speed;

    public int gold = 0;
    public weapon_base[] weapons = new weapon_base[11];
    public Player player;

    public bool initialized = false;

    public Room[,] rooms;
    public int[] lastRoom = new int[2];
    public int curFloor;
    public bool savedLevelData = false;
    public int enemyPool;


    void Awake()
    {
        // �̱���
        if (data != null)
            Destroy(this.gameObject);
        else
            data = this;

        // �� ����� ����X
        DontDestroyOnLoad(this);

        // ���� ���� �ʱ� ������ �Է�
        if (!initialized)
        {
            CreatePlayerData(100,100, 10, 999);
        }



        

    }

    public void UpdateMapData()
    {
        if(!savedLevelData)
        {
            rooms = new Room[Level.level.width, Level.level.height + 1];
            rooms = Level.level.rooms;
            lastRoom = Level.level.lastRoom;
            curFloor = Level.level.curFloor;
            savedLevelData = true;
        }
        else
        {
            Level.level.rooms = rooms;
            Level.level.lastRoom = lastRoom;
            Level.level.curFloor = curFloor;
        }
    }

    public void CreatePlayerData(int maxhpValue, int hpValue, float speedValue, int goldValue)
    {
        maxHP = maxhpValue;
        curHP = hpValue;
        speed = speedValue;
        gold = goldValue;

        // ó���� ��� ���� ���⿡ active = true; �ۼ�
        foreach (weapon_base weapon in weapons)
        {
            weapon.active = false;
        }
        weapons[4].active = true;
        weapons[4].level = 4;

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
