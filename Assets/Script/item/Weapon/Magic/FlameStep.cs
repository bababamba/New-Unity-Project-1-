using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameStep : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    AttackBase bulletScript;

    protected override void Start()
    {
        basic_attack = 10;
        dpl = 5;
        base.Start();
        itemNum = 0;
        Maxcooldown = 0.25f;
        itemName = "플레임 스텝";

        itemCaption = "신발은 안 탄다고 하네요.";
    }

    protected override void Update()
    {
        itemText = "주기적으로 발걸음에 화염을 남겨 닿은 적에게 짧은 간격으로 피해를 준다.";
        base.Update();
    }

    protected override void itemTrigger()
    {
        GameObject flameStepEffect = Instantiate(bullet, player.transform.position, Quaternion.LookRotation(Vector3.forward, playerScript.playerDirection));
        bulletScript = flameStepEffect.GetComponent<FlameStepAttack>();
        bulletScript.addDmg = (int)(level * dpl);
        //bulletScript.init(calcDmg(), 5, 1);
    }
    public override void levelUp()
    {
        base.levelUp();
    }

}
