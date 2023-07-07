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
        // ���� �÷��̾� �������� �̵���Ŵ
        transform.Translate(direction * speed * Time.deltaTime);

    }
    private bool CheckCollisionWithCircle()
    {
        // ���� �߽ɰ� CircleCollider2D�� �߽� ������ �Ÿ� ���
        float distance = Vector2.Distance(playerCenter.position, col.bounds.center);

        // ���� �߽ɰ� CircleCollider2D�� �߽� �Ÿ��� ���������� ������ �浹�� ����
        if (distance <= playerRadius)
        {
            return true;
        }

        return false;
    }
    



}
