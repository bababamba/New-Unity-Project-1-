using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEnemyBase : enemy_base
{
    [SerializeField]
    protected bool canMove = true;
    protected float timer = 0;
    [SerializeField]
    protected float timerMax = 1.5f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timer = timerMax * 2;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        initE(0);
        if(canMove)
            moveToPlayer();

        timer -= Time.deltaTime;
        if (timer < 0)

        {
            gimick();
            timer = timerMax;
        }


    }
    protected virtual void gimick()
    {

    }
    protected virtual void initSpecialEnemy(bool canM, float timerM)
    {
        this.canMove = canM;
        this.timerMax = timerM;
    }
    protected void stopSeconds(float time)
    {
        StartCoroutine(Stop(time));
    }
    private IEnumerator Stop(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;


    }
}
