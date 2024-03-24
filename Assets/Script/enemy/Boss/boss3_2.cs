using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3_2 : BossEnemy_Base
{

    [SerializeField] GameObject bullet;
    enemyProjectileBase bulletScript;
    public float shootForce = 6f;
    Vector3 centerPosition;

    [SerializeField] GameObject teleSpawn;
    [SerializeField] float teleportRadius = 20f;

    [SerializeField] GameObject thunder;

    public boss3 friend;

    float teleCooldown = 10f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.init(700, -1, 2);
        numberOfGimick = 2;
        mustGimick = 0;
        initBossEnemy(true, 2);
        centerPosition = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (teleCooldown > 0)
            teleCooldown -= Time.deltaTime;
        else
        {
            Transform temp = gameManager.getPlayerTransform(this.transform);
            if (temp != this.transform && 5 < Vector2.Distance(temp.position, this.transform.position))
                mustGimick = 8;
        }
        base.Update();
               

    }
    protected override void gimick1()
    {
        StartCoroutine(IsGun());

    }
    protected override void gimick2()
    {
        Vector3 startPoint = player.transform.position;
        Vector3 endPoint = transform.position;

        Vector3 randomPointOnLine = RandomPointOnLine(startPoint, endPoint);

        Instantiate(thunder, randomPointOnLine, Quaternion.identity);

        base.gimick2();
        timer = 1f;
    }
    protected override void gimick3()
    {
        

    }
    protected override void gimick8()
    {
        Vector2 randomOffset = Random.insideUnitCircle * teleportRadius;

        Instantiate(teleSpawn, this.transform.position, Quaternion.identity);
        Vector3 GoPosition = new Vector3(centerPosition.x + randomOffset.x, centerPosition.y + randomOffset.y, centerPosition.z);
        this.transform.position = GoPosition;
        teleCooldown = 10f;
        base.gimick8();
        timer = 1f;
    }
    
    IEnumerator IsGun()
    {
        Shooting(5, 30);
        yield return new WaitForSeconds(0.5f);
        Shooting(5, 30);
        yield return new WaitForSeconds(0.5f);
        Shooting(5, 30);
        yield return new WaitForSeconds(0.5f);
        Shooting(5, 30);
        yield return new WaitForSeconds(0.5f);
        Shooting(5, 30);
        yield return new WaitForSeconds(0.5f);
        base.gimick1();
        timer = 1f;
    }
    void Shooting(int numberOfBullets, float fanAngle)
    {
        Vector2 playerDirection = player. transform.position - transform.position;
        float playerAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;

        // ��ä���� ������ �÷��̾�� �� ������ ������ �°� ����
        float startAngle = playerAngle - (fanAngle / 2f);
        float angleStep = fanAngle / (numberOfBullets - 1);
        Vector2 fireDirection = (player.transform.position - transform.position).normalized;
        for (int i = 0; i < numberOfBullets; i++)
        {
            // ������ �������� ��ȯ
            float angleInRadians = Mathf.Deg2Rad * (startAngle + i * angleStep);

            // ������ ���� ���� ���� ���
            Vector2 bulletDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
            GameObject Bullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = Bullet.GetComponent<Rigidbody2D>();
            bulletScript = Bullet.GetComponent<enemyProjectileBase>();
            bulletScript.init(10, 5, 1);
            // �Ѿ˿� �ӵ� ����
            bulletRb.velocity = (bulletDirection ) * shootForce;
        }
    }
    Vector3 RandomPointOnLine(Vector3 startPoint, Vector3 endPoint)
    {
        // ���� ���̸� ���մϴ�.
        float lineLength = Vector3.Distance(startPoint, endPoint);

        // ������ ������ �����մϴ�.
        float randomRatio = Random.Range(0f, 1f);

        // ������ ������ ���� �� ���� ��ġ�� ����մϴ�.
        Vector3 randomPoint = startPoint + (randomRatio * (endPoint - startPoint));

        return randomPoint;
    }
    public override void death()
    {
        if (friend)
        {
            friend.Ragemode();
        }
        base.death();
    }
    public void Ragemode()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1f);
        this.addCurHP(350);
        this.speed = 1;
        timerMax = 1;
    }
}