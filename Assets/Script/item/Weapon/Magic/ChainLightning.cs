using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : weapon_base
{
    public GameObject bullet;
    ChainLightningAttack bulletScript;
    public int maxChain;

    protected override void Start()
    {
        basic_attack = 10;
        add = 0.1f;
        base.Start();
        itemNum = 0;
        Maxcooldown = 6;
        maxChain = 3;
        itemName = "ü�� ����Ʈ��";

        itemCaption = "";
    }

    protected override void Update()
    {
        itemText = "���� �� ü���� ���� ���� ������ �����ϴ� ������ ���� ���ظ� �ְ�, ���� ��󿡰� ���� ���ط� ���̵ȴ�.";
        base.Update();
    }

    protected override void itemTrigger()
    {
        Transform target = gameManager.StrongestEnemy(playerNumber, 50);
        if (target != player.transform)
        {
            GameObject CLEffect = Instantiate(bullet, target.transform.position, Quaternion.identity);
            bulletScript = CLEffect.GetComponent<ChainLightningAttack>();
            bulletScript.player = player;
            bulletScript.curTarget = target;
            bulletScript.chainLeft = maxChain;
            bulletScript.init(calcDmg(), 5, 1);
        }
        else Debug.Log("No Target!");
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }

}
