using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Unit_Bishop : Chess_Unit
{
    [SerializeField] GameObject bullet;
    enemyProjectileBase bulletScript;
    public float shootForce = 6f;
    Vector3 playerDirection;
    protected override void Start()
    {
        base.Start();
        this.init(100, 10, 2);
        attackDamage = 1f;
    }
    protected override void gimick()
    {

    }


    public override void OnActive()
    {
        Shooting(3, 30);

    }
    void Shooting(int numberOfBullets, float fanAngle)
    {
        Vector2 playerDirection = player.transform.position - transform.position;
        float playerAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;

        // 부채꼴의 각도를 플레이어와 적 사이의 각도에 맞게 보정
        float startAngle = playerAngle - (fanAngle / 2f);
        float angleStep = fanAngle / (numberOfBullets - 1);
        Vector2 fireDirection = (player.transform.position - transform.position).normalized;
        for (int i = 0; i < numberOfBullets; i++)
        {
            // 각도를 라디안으로 변환
            float angleInRadians = Mathf.Deg2Rad * (startAngle + i * angleStep);

            // 각도에 따른 방향 벡터 계산
            Vector2 bulletDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
            GameObject Bullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = Bullet.GetComponent<Rigidbody2D>();
            bulletScript = Bullet.GetComponent<enemyProjectileBase>();
            bulletScript.init(10, 5, 1);
            // 총알에 속도 적용
            bulletRb.velocity = (bulletDirection) * shootForce;
        }
    }

}
