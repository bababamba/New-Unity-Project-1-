using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade : weapon_base
{
    public GameObject bullet;
    public float shootForce = 5f;
    projectile_base bulletScript;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        basic_attack = 40;
        itemNum = 3;
        Maxcooldown = 2;
        
        itemName = "작은 폭탄";
        itemText = "주위의 랜덤한 적에게" + basic_attack + "만큼의 피해를 입히는 폭탄을 던진다.";
        itemCaption = "전해져오는 이야기에 따르면 먼 옛날 조금 큰 폭탄 때문에 세상이 멸망했다고 한다. 어린애도 믿지 않을 이야기다. 너무 매끈해서 던지기가 힘들다.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        itemText = "주위의 랜덤한 적에게" + basic_attack + "만큼의 피해를 입히는 폭탄을 던진다.";
    }
    protected override void itemTrigger(int itemLevel)
    {
        Transform temp = gameManager.randomEnemy(playerNumber);
        if (temp != player.transform)
        {
            GameObject whiteBox = Instantiate(bullet, player.transform.position, Quaternion.identity);
            bulletScript = whiteBox.GetComponent<projectile_base>();
            bulletScript.init(calcDmg(), 2+itemLevel,1);
            Rigidbody2D whiteBoxRigidbody = whiteBox.GetComponent<Rigidbody2D>();
            Vector2 shootDirection = (temp.position - player.transform.position).normalized; // 시작점에서 발사 지점까지의 벡터 방향을 구함
            whiteBoxRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 15;
        
    }
}
