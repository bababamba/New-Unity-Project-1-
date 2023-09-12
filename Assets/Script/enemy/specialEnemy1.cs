using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEnemy1 : specialEnemyBase
{
    protected override void Start()
    {
        base.Start();
        initSpecialEnemy(true, 1.5f);
    }

    protected override void gimick()
    {
        base.gimick();
        player.transform
    }
    // Start is called before the first frame update

}
