using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_base : Creture
{
    CircleCollider2D col;
    protected GameObject player;
    Transform playerCenter;
    float playerRadius;
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.tag = "Enemy";
    }
    void Start()
    {
        this.init(100,1,2);
        col = GetComponent<CircleCollider2D>();
        player = GameObject.Find("player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCenter = player.transform;
        playerRadius = 1.2F;
       // moveToPlayer();
        bool isColliding = CheckCollisionWithCircle();
        if (isColliding)
        {
            
        }
    } 
    protected void moveToPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        // 적을 플레이어 방향으로 이동시킴
        transform.Translate(direction * speed * Time.deltaTime);

    }
    private bool CheckCollisionWithCircle()
    {
        // 원의 중심과 CircleCollider2D의 중심 사이의 거리 계산
        float distance = Vector2.Distance(playerCenter.position, col.bounds.center);

        // 원의 중심과 CircleCollider2D의 중심 거리가 반지름보다 작으면 충돌로 간주
        if (distance <= playerRadius)
        {
            return true;
        }

        return false;
    }
    



}
