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
        itemName = "프로스트 노바";

        itemCaption = "대충 속성 이름에 '노바'만 붙이면 마법이 된다는게 사실인가요?";
    }

    protected override void Update()
    {
        itemText = "원형의 주변 범위에 냉기의 파동을 방출하여 약한 피해를 입히고 느려지게 한다.";
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
