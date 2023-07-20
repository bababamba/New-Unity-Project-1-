using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartOfFire : weapon_base
{
    public GameObject bullet;
    fireOfHeart fire;
    
    protected override void Start()
    {
        basic_attack = 2;
        apd = 0.01f;
        itemNum = 1;
        base.Start();
        
        Maxcooldown = 1;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


    }
    protected override void itemTrigger(int itemLevel)
    {
        GameObject heartFire = Instantiate(bullet, player.transform.position, Quaternion.identity);
        fire = bullet.GetComponent<fireOfHeart>();
        fire.init(calcDmg(), 0.2f, 1, 0);
    }
    public override void levelUp()
    {
        base.levelUp();
        basic_attack += 0.5f;
        apd += 0.005f;
    }
}
