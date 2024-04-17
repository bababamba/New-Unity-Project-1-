using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Unit_Rook : Chess_Unit
{
    [SerializeField] Sprite Sq;
    Vector3 playerDirection;
    protected override void Start()
    {
        base.Start();
        this.init(100, 20, 2);
        attackDamage = 1f;
    }
    protected override void gimick()
    {

    }


    public override void OnActive()
    {
        StartCoroutine(GetSetGo());

    }
    IEnumerator GetSetGo()
    {
        DrawChargeRange();
        yield return new WaitForSeconds(0.5f);
        ChargeTowardsPlayer();
    }
    private void DrawChargeRange()
    {
        playerDirection = (player.transform.position - transform.position).normalized;

        // 돌진 전 범위를 표시하는 빨간색 사각형 생성
        GameObject chargeRangeIndicator = new GameObject("ChargeRangeIndicator");
        chargeRangeIndicator.transform.position = transform.position;
        chargeRangeIndicator.transform.up = playerDirection; // 사각형을 플레이어 방향으로 회전

        // 한쪽 끝이 Pawn의 중심에 오도록 스케일 설정
        float halfChargeDistance = speed * 0.5f;
        chargeRangeIndicator.transform.localScale = new Vector3(1f, speed, 1f);
        chargeRangeIndicator.transform.position = transform.position + playerDirection * halfChargeDistance;

        SpriteRenderer spr = chargeRangeIndicator.AddComponent<SpriteRenderer>();

        Color color = Color.red;
        color.a = 0.5f;
        spr.color = color;
        spr.sprite = Sq;
        Destroy(chargeRangeIndicator, 0.5f);
    }

    public void ChargeTowardsPlayer()
    {
        // 플레이어 방향 계산
        //playerDirection = (player.transform.position - transform.position).normalized;

        // 플레이어 방향으로 일정 거리 돌진
        transform.DOMove(transform.position + playerDirection * this.speed, 0.75f);
    }
}
