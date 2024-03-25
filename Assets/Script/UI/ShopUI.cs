using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ShopUI : MonoBehaviour
{
    public enum Product
    {
        BATTLEAXE = 0,
        DAGGER = 1,
        HAMMER = 2,
        SHIELD = 3,
        SWORD = 4,
        BLIZZARD = 5,
        CHAINLIGHTNING = 6,
        FIREBALL = 7,
        FLAMESTEP = 8,
        FROSTNOVA = 9,
        THUNDERBOLT = 10
    }
    public List<Product> products = new List<Product>();
    public Random random = new Random();

    public Canvas[] shelf;
    public Sprite[] images = new Sprite[11];


    void Start()
    {
        for (int i = 0; i < 11; i++)
            products.Add((Product)i);
        shelf = this.transform.Find("ItemScreen").GetComponentsInChildren<Canvas>();

        this.gameObject.SetActive(false);
    }

    void Update()
    {
        //��� â�� ���� ��� ��� ���� �ʿ�
        this.transform.Find("GoldBar").GetComponentInChildren<Text>().text = "Gold : " + PlayerData.data.gold;
    }

    public void OpenShop()
    {
        for (int i = 0; i < 5; i++)
            products.RemoveAt(random.Next(0, products.Count));

        for(int i = 0; i < shelf.Length; i++)
        {
            Image[] thumbnails = shelf[i].GetComponentsInChildren<Image>();
            Button[] buttons = shelf[i].GetComponentsInChildren<Button>();
            for(int j = 0; j < 3; j++)
            {
                thumbnails[j].sprite = images[(int)products[j + (i * 3)]];
                // �÷��̾� �����ؼ� ���� ��� ���� å��
                buttons[j].GetComponentInChildren<Text>().text = (PlayerData.data.weapons[(int)products[j + (i * 3)]].level * 100) + "G";
                buttons[j].GetComponentInChildren<Text>().fontSize = 30;
            }
        }
         //Debug.Log(products.Count);   
    }

    public bool Purchase(int num)
    {
        // �÷��̾� �����ؼ� ��ǰ ���ݰ� ��, ���� ������ �׳� ���� = return
        // ���� ������ ����� �̹��� �� ��Ӱ�, ��ư �������� ����
        // �÷��̾� ���� ������ +1 ����� ��
        if(PlayerData.data.gold >= 100 * PlayerData.data.weapons[(int)products[num]].level)
        {
            PlayerData.data.gold -= 100 * PlayerData.data.weapons[(int)products[num]].level;
            if (PlayerData.data.weapons[(int)products[num]].active == false)
                PlayerData.data.weapons[(int)products[num]].active = true;
            else
                PlayerData.data.weapons[(int)products[num]].levelUp();
            return true;
        }
        else
        {
            Debug.Log("Not Enough Gold.");
            return false;
        }
    }

    
    public void Close()
    {
        products = new List<Product>();
        for (int i = 0; i < 11; i++)
            products.Add((Product)i);

        MapUIManager.manager.CloseUI(1);
    }

}
