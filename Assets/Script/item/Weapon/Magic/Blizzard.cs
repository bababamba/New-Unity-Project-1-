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
        itemName = "블리자드";

        itemCaption = "";
    }

    protected override void Update()
    {
        itemText = "일정 범위 내 여러 적들에게 얼음을 떨어뜨려 피해를 주고 느려지게 한다.";
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
