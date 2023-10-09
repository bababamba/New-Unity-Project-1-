using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : enemy_base
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.init(100, 0.7f, 2);
        attackDamage = 3;
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        moveToPlayer();
    }
}