using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : enemy_base
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.init(50, 3f, 2);
        attackDamage = 1f;
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        initE(0);
        moveToPlayer();
    }
}