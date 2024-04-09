using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    AttackBase bulletScript;
    // Start is called before the first frame update
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
        Maxcooldown = 5;
        itemName = "��ġ";
        itemText = "���濡 ��ġ�� ������ " + basic_attack + " + " + "��ŭ�� ���ظ� �ְ� ũ�� ���ĳ���.";
        itemCaption = "";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void itemTrigger()
    {
        Vector2 position = new Vector2(playerScript.playerDirection.x, playerScript.playerDirection.y) * 2f;
        GameObject hammerEffect = Instantiate(bullet, player.transform.position + new Vector3(playerScript.playerDirection.x, 
            playerScript.playerDirection.y) * 2f, Quaternion.LookRotation(Vector3.forward, playerScript.playerDirection));
        bulletScript = hammerEffect.GetComponent<HammerAttack>();
        bulletScript.addDmg = (int)(level * dpl);
        bulletScript.player = player;
        bulletScript.position = position;
        bulletScript.init(calcDmg(), 5, 1);

    }
    public override void levelUp()
    {
        base.levelUp();
    }


}
