using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    AttackBase bulletScript;

    public int blizzardNum;
    public int blizzardRange;

    protected override void Start()
    {
        basic_attack = 10;
        dpl = 5;
        baseDmg = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 6;
        blizzardNum = 6;
        blizzardRange = 6;
        itemName = "���ڵ�";

        itemCaption = "";
    }

    protected override void Update()
    {
        itemText = "���� ���� �� ���� ���鿡�� ������ ����߷� ���ظ� �ְ� �������� �Ѵ�.";
        base.Update();
    }

    protected override void itemTrigger()
    {
        for (int i = 0; i < blizzardNum; i++)
        {
            Transform target = gameManager.randomEnemyInRange(playerNumber, blizzardRange);
            if (target != player.transform)
            {
                GameObject blizzardEffect = Instantiate(bullet, target.transform.position, Quaternion.identity);
                bulletScript = blizzardEffect.GetComponent<BlizzardAttack>();
                bulletScript.addDmg = (int)(level * dpl);
                bulletScript.init(calcDmg(), 5, 1);
            }
        }
    }
    public override void levelUp()
    {
        base.levelUp();
    }

}
