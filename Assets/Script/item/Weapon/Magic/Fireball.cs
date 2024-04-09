using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : weapon_base
{
    public GameObject bullet;
    public float shootForce;
    AttackBase bulletScript;

    protected override void Start()
    {
        Init();
        base.Start();
    }

    public override void Init()
    {
        basic_attack = 10;
        dpl = 5;
        shootForce = 1.5f;
        itemNum = 0;
        Maxcooldown = 6;
        itemName = "���̾";
        itemText = "������ ��ų� ���� �ð��� ������ �����ϴ� ȭ������ �߻��� ���� ������ ���ظ� �ش�.";
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
        Vector3 dir = (target.transform.position - player.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x + 1) * Mathf.Rad2Deg;
        GameObject axeEffect = Instantiate(bullet, player.transform.position, Quaternion.Euler(0, 0, angle - 180));
        Debug.Log(angle);
        bulletScript = axeEffect.GetComponent<FireballAttack>();
        bulletScript.addDmg = (int)(level * dpl);
        bulletScript.init(calcDmg(), 5, 1);
        axeEffect.GetComponent<Rigidbody2D>().AddForce((target.transform.position - player.transform.position) * shootForce, ForceMode2D.Impulse);

    }
    public override void levelUp()
    {
        base.levelUp();
    }

}
