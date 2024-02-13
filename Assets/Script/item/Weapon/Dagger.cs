using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : weapon_base
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
        Maxcooldown = 1;
        itemName = "�ܰ�";

        itemCaption = "";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "���� �������� �ܰ��� �� " + basic_attack + " + " + add * playerScript.ad + "��ŭ�� ���ظ� �ش�.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        GameObject daggerEffect = Instantiate(bullet, player.transform.position, Quaternion.identity);
        bulletScript = daggerEffect.GetComponent<DaggerAttack>();
        bulletScript.init(calcDmg(), 5, 1);
        daggerEffect.transform.SetParent(player.transform, false);
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }


}
