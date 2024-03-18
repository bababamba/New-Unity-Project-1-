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
        for (int i = 0; i <= 11; i++)
            products.Add((Product)i);
        shelf = GetComponentsInChildren<Canvas>();


        this.gameObject.SetActive(false);
    }

    void Update()
    {
        //골드 창에 현재 골드 계속 갱신 필요
    }

    public void OpenShop()
    {
        for (int i = 0; i <= 5; i++)
            products.RemoveAt(random.Next(0, products.Count));

        for(int i = 0; i < shelf.Length - 1; i++)
        {
            Image[] thumbnails = shelf[i + 1].GetComponentsInChildren<Image>();
            Button[] buttons = shelf[i + 1].GetComponentsInChildren<Button>();
            int count = 0;
            for(int j = 0; j < 3; j++)
            {
                thumbnails[count].sprite = images[(int)products[j + (i * 3)]];
                // 플레이어 연동해서 레벨 비례 가격 책정
                //buttons[count].GetComponentInChildren<Text>().text = 
                count++;
            }
        }
            
    }

    public void Purchase()
    {
        // 플레이어 연동해서 상품 가격과 비교, 돈이 없으면 그냥 무시 = return
        // 돈이 있으면 썸네일 이미지 색 어둡게, 버튼 못누르게 변경
        // 플레이어 무기 레벨도 +1 해줘야 함
    }


    public void Close()
    {
        for (int i = 0; i <= 11; i++)
            products.Add((Product)i);

        MapUIManager.manager.CloseUI(1);
    }

}
