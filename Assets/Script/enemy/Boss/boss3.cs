using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class boss3 : BossEnemy_Base
{
    Vector3 playerDirection;
    [SerializeField] Sprite Sq;
    public GameObject parryEffect;

    public GameObject Garen;

    public float parrytime = 1f;
    public bool parry = false;
    public GameObject Slicer;
    public float parryTimer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.init(1000, 4, 2);
        numberOfGimick = 3;
        mustGimick = 0;
        initBossEnemy(true, 2);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (parry)
        {
            parryTimer += Time.deltaTime;

            // 1초가 지났을 때
            if (parryTimer >= parrytime)
            {
                parry = false;
                base.gimick3();
                timer = 1f;
            }
        }

        }
    protected override void gimick1()
    {
        stopSeconds(3f);
        StartCoroutine(GetSetGo());
        
    }
    protected override void gimick2()
    {

        GameObject Blade = Instantiate(Garen, this.transform.position, Quaternion.identity);
        Blade.transform.SetParent(this.transform);
        this.speed = speed*2;
        StartCoroutine(Boost());
        
    }
    protected override void gimick3()
    {
        GameObject ParryFx = Instantiate(parryEffect, this.transform.position, Quaternion.identity);
        Destroy(ParryFx, 2);
        parryTimer = 0f;
        stopSeconds(3f);
        StartCoroutine(Parrying());
        
        
    }
    protected override void gimick8()
    {
        StartCoroutine(Critical());
    }
    public override void takeDamage(float dmg)
    {
        if (parry)
        {
            Debug.Log("텅!");
            parry = false;
            mustGimick = 8;
            base.gimick3();
        }
        else
            base.takeDamage(dmg);

    }
    private void DrawChargeRange(float delay)
    {
        playerDirection = (player.transform.position - transform.position).normalized;

        // 돌진 전 범위를 표시하는 빨간색 사각형 생성
        GameObject chargeRangeIndicator = new GameObject("ChargeRangeIndicator");
        chargeRangeIndicator.transform.position = transform.position;
        chargeRangeIndicator.transform.up = playerDirection; // 사각형을 플레이어 방향으로 회전

        // 한쪽 끝이 Pawn의 중심에 오도록 스케일 설정
        float halfChargeDistance = speed * 0.5f;
        chargeRangeIndicator.transform.localScale = new Vector3(2f, speed*2, 1f);
        chargeRangeIndicator.transform.position = transform.position + playerDirection * halfChargeDistance;

        SpriteRenderer spr = chargeRangeIndicator.AddComponent<SpriteRenderer>();

        Color color = Color.red;
        color.a = 0.5f;
        spr.color = color;
        spr.sprite = Sq;
        Destroy(chargeRangeIndicator, delay);
    }

    public void ChargeTowardsPlayer()
    {
        // 플레이어 방향 계산
        //playerDirection = (player.transform.position - transform.position).normalized;

        // 플레이어 방향으로 일정 거리 돌진
        transform.DOMove(transform.position + playerDirection * this.speed*2, 0.5f);
    }
    IEnumerator GetSetGo()
    {
        DrawChargeRange(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChargeTowardsPlayer();
        yield return new WaitForSeconds(0.5f);
        DrawChargeRange(0.5f);
        yield return new WaitForSeconds(0.5f);
        ChargeTowardsPlayer();
        yield return new WaitForSeconds(0.5f);
        DrawChargeRange(0.3f);
        yield return new WaitForSeconds(0.3f);
        ChargeTowardsPlayer();
        yield return new WaitForSeconds(0.5f);
        base.gimick1();
        timer = 1f;
    }
    IEnumerator Parrying()
    {
        yield return new WaitForSeconds(1f);
        parry = true;
    }
    IEnumerator Boost()
    {
        yield return new WaitForSeconds(4f);
        speed = 4f;
        base.gimick2();
        timer = 1f;
    }
    IEnumerator Critical()
    {
        yield return new WaitForSeconds(1f);
        CriticalAttack();
        yield return new WaitForSeconds(0.5f);
        CriticalAttack();
        yield return new WaitForSeconds(0.5f);
        CriticalAttack();
        yield return new WaitForSeconds(0.3f);
        CriticalAttack();
        yield return new WaitForSeconds(0.2f);
        CriticalAttack();
        yield return new WaitForSeconds(0.2f);
        CriticalAttack();
        yield return new WaitForSeconds(0.5f);
        CriticalAttack();
        yield return new WaitForSeconds(0.1f);
        CriticalAttack();
        yield return new WaitForSeconds(0.1f);
        base.gimick8();
        timer = 1f;
    }
    public void CriticalAttack()
    {
        float randomRotation = Random.Range(0, 2);
        Vector3 spawnPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        //Instantiate(Slicer, spawnPosition, Quaternion.Euler(0, 0, randomRotation));
        if (randomRotation == 0)
        {
            Instantiate(Slicer, spawnPosition, Quaternion.Euler(0, 0, 90));
        }
        else
            Instantiate(Slicer, spawnPosition, Quaternion.Euler(0, 0, 0));
        
    }
}
