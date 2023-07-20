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
            // ���� �÷��̾� �������� �̵���Ŵ
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    /*
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
            Debug.Log("�ڽ��� �÷��̾�� �浹�߽��ϴ�!");
        }
    }
    private void UpdateHealthBar()
    {
        float scale = (float)this.getCurHP() / (float)this.getMaxHP();
        barTransform.localScale = new Vector3(scale, 0.1f, 1f);
        barTransform.localPosition = new Vector3(-0.5f + scale * 0.5f, 0.7f, 0f);
    }


}
