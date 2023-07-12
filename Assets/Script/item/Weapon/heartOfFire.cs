using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartOfFire : weapon_base
{
    public GameObject bullet;
    fireOfHeart fire;
    protected override void Start()
    {

        itemNum = 1;
        base.Start();
        
        Maxcooldown = 1;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


    }
    protected override void itemTrigger()
    {
        GameObject heartFire = Instantiate(bullet, player.transform.position, Quaternion.identity);
        fire = bullet.GetComponent<fireOfHeart>();
        fire.init(2, 0.2f, 1, 0);
    }
}
