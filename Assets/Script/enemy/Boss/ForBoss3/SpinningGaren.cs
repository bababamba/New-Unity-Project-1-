using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningGaren : enemyExplosionBase
{
    public float rotationSpeed = 100f;
    public GameObject Sword;
    protected override void Start()
    {
        dmg = 5;
        maxLifeTime = 4;
        maxDmgDuration = 0.2f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        Sword.transform.RotateAround(transform.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
        base.Update();
    }
}
