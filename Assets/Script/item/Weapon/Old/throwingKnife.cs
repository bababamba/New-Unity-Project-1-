using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingKnife : weapon_base
{
    public GameObject bullet;
    public float shootForce = 10f;
    projectile_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        basic_attack = 5;
        add = 0.4f;
        base.Start();
        itemNum = 8;
        Maxcooldown = 0.8f;
        itemName = "투척용 단검";

        itemCaption = "이정도의 무기도 없다면 이곳에서 살아남을 수 없다.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "보고있는 방향으로 " + basic_attack + " + " + add * playerScript.ad + "만큼의 피해를 입히는 투사체를 발사한다.";
        base.Update();
    }
    protected override void itemTrigger()
    {
        Transform temp = gameManager.closestEnemy(playerNumber, 100f);
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<projectile_base>();
            bulletScript.init(calcDmg(), 5, 1);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = playerScript.playerDirection.normalized; // 시작점에서 발사 지점까지의 벡터 방향을 구함
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            whiteBoxRigidbody.rotation = angle-45;
        }
    }
    public override void levelUp()
    {
        base.levelUp();
        Maxcooldown -= 0.05f;
        add += 0.1f;
    }


}