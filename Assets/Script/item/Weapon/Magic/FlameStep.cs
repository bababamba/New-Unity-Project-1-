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
        Init();
        base.Start();
    }

    public override void Init()
    {
        basic_attack = 10;
        dpl = 5;
        itemNum = 0;
        Maxcooldown = 0.25f;
        itemName = "�÷��� ����";
        itemText = "�ֱ������� �߰����� ȭ���� ���� ���� ������ ª�� �������� ���ظ� �ش�.";
        itemCaption = "�Ź��� �� ź�ٰ� �ϳ׿�.";
    }

    protected override void Update()
    { 
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
