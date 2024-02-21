using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonFlower : weapon_base
{
    public GameObject bullet;
    public float shootForce = 5f;
    areaD_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        basic_attack = 30;
        add = 0.3f;
        apd = 0.3f;
        itemNum = 4;
        Maxcooldown = 1.5f;
        
        itemName = "�޹ٶ��";
        itemText = "��������� ���� ���·� ����" + basic_attack + " + " + apd * playerScript.ap +  "+"+ add*playerScript.ad + "��ŭ�� ���ظ� �ش�.";
        itemCaption = "���� �������� ����� �� ���̴�. ���� ������ ����־� ������� ���¿� ���� �� ��ī�ο�����.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        itemText = "��������� ���� ���·� ����" + basic_attack + " + " + apd * playerScript.ap + "+" + add * playerScript.ad + "��ŭ�� ���ظ� �ش�.";
    }
    protected override void itemTrigger()
    {
        Transform temp = gameManager.randomEnemy(playerNumber);
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position+ new Vector3(playerScript.playerDirection.x, playerScript.playerDirection.y)*1.5f, Quaternion.LookRotation(Vector3.forward, playerScript. playerDirection));
            bulletScript = whiteBox.GetComponent<areaD_base>();
            bulletScript.init(calcDmg(), 1, 0, 0.2f);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            whiteBox.transform.parent = player.transform;
        }
        //Quaternion.Euler(0f, 0f, Mathf.Atan2(playerScript.playerDirection.x, playerScript.playerDirection.y) * Mathf.Rad2Deg)
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.1f;
        apd += 0.1f;
    }
}
