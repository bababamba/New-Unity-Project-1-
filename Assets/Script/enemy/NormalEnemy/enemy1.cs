using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : enemy_base
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.init(50, 1, 2);
        attackDamage = 1;
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        moveToPlayer();
    }
}
