using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEnemy2 : specialEnemyBase
{
    public GameObject bullet;
    public float shootForce = 10f;
    enemyProjectileBase bulletScript;
    protected override void Start()
    {
        base.Start();
        this.init(50, 1, 2);

        initSpecialEnemy(true, 2f);
    }

    protected override void gimick()
    {
        base.gimick();
        

    }
    // Start is called before the first frame update

}
