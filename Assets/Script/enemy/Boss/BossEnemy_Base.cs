using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy_Base : enemy_base
{
    [SerializeField]
    protected bool canMove = true;
    protected float timer = 0;
    [SerializeField]
    protected float timerMax = 1f;
    protected int numberOfGimick = 2;
    protected bool isGimickEnd = true;
    protected int mustGimick = 0;

    protected int lastGimick = 1;
    private System.Random randomNumber = new System.Random();
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timer = 3f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        initE(0);
        if (canMove)
            moveToPlayer();
        
        //if(timer>=0)
            timer -= Time.deltaTime;

        if (isGimickEnd && timer < 0)

        {
            if (mustGimick == 0)
                ChooseGimick();
            else
            {
                ActivateGimick(mustGimick);
                mustGimick = 0;
            }
            timer = timerMax;
        }
        //Debug.Log(lastGimick + " " + mustGimick + " " + isGimickEnd + " " );

    }
    protected virtual void ChooseGimick()
    {
        int temp = 0;
        //temp = randomNumber.Next(1, numberOfGimick + 1);
        while (true)
        {
            temp = randomNumber.Next(1, numberOfGimick + 1);
            
            if (temp != lastGimick)
            {
                lastGimick = temp;
                break;
            }
        }
        
        ActivateGimick(lastGimick);
        

    }
    protected virtual void ActivateGimick(int Gimick)
    {isGimickEnd = false;
        
        switch (Gimick)
        {
            case 1: gimick1(); break;
            case 2: gimick2(); break;
            case 3: gimick3(); break;
            case 4: gimick4(); break;
        }
        
    } 
    protected virtual void gimick1()
    {
        isGimickEnd = true;
    }
    protected virtual void gimick2()
    {
        isGimickEnd = true;

    }
    protected virtual void gimick3()
    {
        isGimickEnd = true;

    }
    protected virtual void gimick4()
    {
        isGimickEnd = true;

    }

    protected virtual void initBossEnemy(bool canM, float timerM)
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
