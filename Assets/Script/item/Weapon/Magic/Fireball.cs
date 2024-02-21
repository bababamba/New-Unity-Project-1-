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
        itemName = "파이어볼";

        itemCaption = "신뢰와 안정, 그리고~~~~~~~~~~";
    }

    protected override void Update()
    {
        itemText = "적에게 닿거나 일정 시간이 지나면 폭발하는 화염구를 발사해 넓은 범위에 피해를 준다.";
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
