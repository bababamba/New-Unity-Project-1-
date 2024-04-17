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

        // ���� �� ������ ǥ���ϴ� ������ �簢�� ����
        GameObject chargeRangeIndicator = new GameObject("ChargeRangeIndicator");
        chargeRangeIndicator.transform.position = transform.position;
        chargeRangeIndicator.transform.up = playerDirection; // �簢���� �÷��̾� �������� ȸ��

        // ���� ���� Pawn�� �߽ɿ� ������ ������ ����
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
        // �÷��̾� ���� ���
        //playerDirection = (player.transform.position - transform.position).normalized;

        // �÷��̾� �������� ���� �Ÿ� ����
        transform.DOMove(transform.position + playerDirection * this.speed, 0.75f);
    }
}
