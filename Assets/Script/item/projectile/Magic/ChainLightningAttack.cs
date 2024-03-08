using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightningAttack : AttackBase
{
    public GameObject bullet;
    ChainLightningAttack bulletScript;

    public Transform curTarget;
    public int chainLeft;

    protected override void Start()
    {
        maxLifetime = 0.125f;
        type = Type.ELEC;
        base.Start();

        this.curTarget.GetComponent<enemy_base>().takeDamage(dmg);
    }

    protected override void Update()
    {
        base.Update();
        /*if(curTarget == null)
        {
            this.die();
        }*/
    }

    // Update is called once per frame
    protected override void die()
    {
        chainLeft--;
        if (chainLeft >= 0)
        {
            Transform target = gameManager.StrongestEnemy(playerNumber, 50);
            if (target != player.transform)
            {
                GameObject CLEffect = Instantiate(bullet, target.transform.position, Quaternion.identity);
                bulletScript = CLEffect.GetComponent<ChainLightningAttack>();
                bulletScript.player = player;
                bulletScript.curTarget = target;
                bulletScript.chainLeft = chainLeft;
                bulletScript.dmg = this.dmg * 0.75f;
            }
        }
        base.die();
    }

    public new void OnTriggerEnter2D(Collider2D col)
    {
    }

}
