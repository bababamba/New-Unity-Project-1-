using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_Base : specialEnemyBase
{
    public GameObject MyBoss;
    public override void death()
    {
        MyBoss.GetComponent<boss2>().takeDamage(100f);
        base.death();
    }
}
