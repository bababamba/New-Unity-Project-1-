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
        basic_attack = 10;
        shootForce = 1.5f;
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
        Vector3 dir = (target.transform.position - player.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x + 1) * Mathf.Rad2Deg;
        GameObject axeEffect = Instantiate(bullet, player.transform.position, Quaternion.Euler(0, 0, angle - 180));
        Debug.Log(angle);
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
