using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostNova : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    AttackBase bulletScript;

    protected override void Start()
    {
        basic_attack = 10;
        base.Start();
        itemNum = 0;
        Maxcooldown = 6;
        itemName = "���ν�Ʈ ���";

        itemCaption = "���� �Ӽ� �̸��� '���'�� ���̸� ������ �ȴٴ°� ����ΰ���?";
    }

    protected override void Update()
    {
        itemText = "������ �ֺ� ������ �ñ��� �ĵ��� �����Ͽ� ���� ���ظ� ������ �������� �Ѵ�.";
        base.Update();
    }

    protected override void itemTrigger()
    {
        GameObject axeEffect = Instantiate(bullet, player.transform.position, Quaternion.LookRotation(Vector3.forward, playerScript.playerDirection));
        bulletScript = axeEffect.GetComponent<FrostNovaAttack>();
        bulletScript.player = player;
        bulletScript.position = player.transform.position;
        bulletScript.init(calcDmg(), 5, 1);
    }
    public override void levelUp()
    {
        base.levelUp();
    }

}
