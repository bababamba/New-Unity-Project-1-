using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    AttackBase bulletScript;

    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 6;
        itemName = "���̾";

        itemCaption = "�ŷڿ� ����, �׸���~~~~~~~~~~";
    }

    protected override void Update()
    {
        itemText = "������ ��ų� ���� �ð��� ������ �����ϴ� ȭ������ �߻��� ���� ������ ���ظ� �ش�.";
        base.Update();
    }

    protected override void itemTrigger()
    {
        Transform target = gameManager.closestEnemy(playerNumber, 100f);
        GameObject axeEffect = Instantiate(bullet, player.transform.position, Quaternion.identity);
        bulletScript = axeEffect.GetComponent<FireballAttack>();
        bulletScript.init(calcDmg(), 5, 1);
        axeEffect.GetComponent<Rigidbody2D>().AddForce((target.transform.position - player.transform.position) * shootForce, ForceMode2D.Impulse);

    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }

}
