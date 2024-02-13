using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAxe : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    projectile_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 6;
        itemName = "���� ����";

        itemCaption = "�� �޸� ���ڸ� ������ ��ŵ� ���� ����ŷ!";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "�ֺ� ���� ������ ������ �ֵѷ�" + basic_attack + " + " + add * playerScript.ad + "��ŭ�� ���ظ� �ش�.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        GameObject axeEffect = Instantiate(bullet, player.transform.position, Quaternion.identity);
        bulletScript = axeEffect.GetComponent<BattleAxeAttack>();
        bulletScript.init(calcDmg(), 5, 1);
        axeEffect.transform.SetParent(player.transform, false);
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }


}
