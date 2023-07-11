using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartOfFire : weapon_base
{
    public GameObject bullet;
    fireOfHeart fire;
    protected override void Start()
    {
        base.Start();
        fire = bullet.GetComponent<fireOfHeart>();
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
    }
}
