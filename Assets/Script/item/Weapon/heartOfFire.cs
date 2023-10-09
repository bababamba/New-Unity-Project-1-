using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class heartOfFire : weapon_base
{
    public GameObject bullet;
    fireOfHeart fire;
    
    protected override void Start()
    {
        base.Start();
        basic_attack = 2;
        apd = 0.01f;
        itemNum = 1;
        itemName = "���� ����";
        itemText = "������" + basic_attack + " + " + apd*playerScript.ap + "��ŭ�� ���ظ� ƽ���� ������.";
        itemCaption = "���� ������ ���� ������ ���¿��. 3��ī���� 1�и��� ���� ������ ȭ���̴�.";
        
        
        Maxcooldown = 1;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        itemText = "������" + basic_attack + " + " + apd * playerScript.ap + "��ŭ�� ���ظ� ƽ���� ������.";

    }
    protected override void itemTrigger(int itemLevel)
    {
        GameObject fire = Instantiate(bullet, player.transform.position, Quaternion.identity);
        fire.transform.SetParent(player.transform);
        fire.GetComponent<fireOfHeart>().init(calcDmg(), 0.2f, 1, 0);
        

    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack = 2 + (0.5f * (level-1));
        apd = 0.01f +(0.005f * (level-1));
    }
}