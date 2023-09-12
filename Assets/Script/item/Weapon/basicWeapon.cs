using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicWeapon : weapon_base
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
        itemName = "호신용 무기";
        
        itemCaption = "이정도의 무기도 없다면 이곳에서 살아남을 수 없다.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        itemText = "가장 가까운 적에게" + basic_attack + " + " + add * playerScript.ad + "만큼의 피해를 입히는 투사체를 발사한다.";
        base.Update();
    }
    protected override void itemTrigger(int itemLevel)
    {
        Transform temp = gameManager.closestEnemy(playerNumber,100f);
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<projectile_base>();
            bulletScript.init(calcDmg(), 5, 4);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - player.transform.position).normalized; // 시작점에서 발사 지점까지의 벡터 방향을 구함
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 5;
        add += 0.05f;
    }
    
    
}
