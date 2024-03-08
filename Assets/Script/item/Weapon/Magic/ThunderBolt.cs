using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBolt : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    ThunderBoltAttack leftScript;
    ThunderBoltAttack rightScript;

    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 6;
        itemName = "�����Ʈ";

        itemCaption = "";
    }

    protected override void Update()
    {
        itemText = "�¿�� ������ �߻��� ���� �� ���� ���� �������� ���� ���ظ� �ش�.";
        base.Update();
    }

    protected override void itemTrigger()
    {
        GameObject leftEffect = Instantiate(bullet, player.transform.position - new Vector3(5.5f, 0, 0), Quaternion.identity);
        GameObject rightEffect = Instantiate(bullet, player.transform.position + new Vector3(5.5f, 0, 0), Quaternion.identity);
        leftScript = leftEffect.GetComponent<ThunderBoltAttack>();
        rightScript = rightEffect.GetComponent<ThunderBoltAttack>();
        leftScript.player = player;
        rightScript.player = player;
        leftScript.left = true;
        rightScript.left = false;
        leftScript.init(calcDmg(), 5, 1);
        rightScript.init(calcDmg(), 5, 1);
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }

}
