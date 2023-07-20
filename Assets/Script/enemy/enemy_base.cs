using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_base : Creture
{
    CircleCollider2D col;
    protected GameObject player;
    protected Player playerScript;
    public GameObject dropped;

    public GameObject healthBar;
    private Transform barTransform;

    //Transform playerCenter;
    //float playerRadius;
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.tag = "Enemy";
    }
    protected virtual void Start()
    {
        
        col = GetComponent<CircleCollider2D>();
        player = GameObject.Find("player");
        playerScript = player.GetComponent<Player>();
        barTransform = healthBar.transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
       
      // moveToPlayer();
        UpdateHealthBar();


    }
    public override void death()
    {
        base.death();
        gameManager.killCountUp();
        GameObject itemDropped = Instantiate(dropped, this.transform.position, Quaternion.identity);
    }
    protected void moveToPlayer()
    {
        if (player)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            // 적을 플레이어 방향으로 이동시킴
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    /*
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
    }*/
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item")||collision.gameObject.CompareTag("ItemObject"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.takeDamage(1);
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("박스가 플레이어와 충돌했습니다!");
        }
    }
    private void UpdateHealthBar()
    {
        float scale = (float)this.getCurHP() / (float)this.getMaxHP();
        barTransform.localScale = new Vector3(scale, 0.1f, 1f);
        barTransform.localPosition = new Vector3(-0.5f + scale * 0.5f, 0.7f, 0f);
    }


}
