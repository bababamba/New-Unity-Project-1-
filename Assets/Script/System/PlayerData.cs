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

    public int gold;
    public weapon_base[] weapons = new weapon_base[11];
    public Player player;

    public bool initialized = false;





    void Awake()
    {
        // �̱���
        if (data != null)
            Destroy(this);
        else
            data = this;

        // �� ����� ����X
        DontDestroyOnLoad(this);

        // ���� ���� �ʱ� ������ �Է�
        if (!initialized)
        {
            CreatePlayerData(100, 10, 100);
        }



    }

    public void CreatePlayerData(int hpValue, int speedValue, int goldValue)
    {
        maxHP = hpValue;
        curHP = hpValue;
        speed = speedValue;
        gold = goldValue;

        // ó���� ��� ���� ���⿡ active = true; �ۼ�
        foreach (weapon_base weapon in weapons)
        {
            weapon.active = false;
        }
        weapons[4].active = true;

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
    }



}
