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
        itemName = "체인 라이트닝";

        itemCaption = "";
    }

    protected override void Update()
    {
        itemText = "범위 내 체력이 가장 높은 적에게 연쇄하는 번개를 날려 피해를 주고, 다음 대상에게 약한 피해로 전이된다.";
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
