using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wall_Unit : specialEnemyBase
{
    public Transform Point;
    Vector3 Direction;
    protected override void Start()
    {
        base.Start();
        this.init(1000, 4, 2);
        initSpecialEnemy(false, 4f);
        attackDamage = 1f;
    }
    protected override void gimick()
    {
        this.setCurHP(this.getMaxHP());
    }


    public virtual void OnActive()
    {
        Direction = (Point.position - transform.position).normalized;
        transform.DOMove(transform.position + Direction * this.speed, 1f);

    }
    

}
