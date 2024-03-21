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
    private SpriteRenderer spriteRenderer;

    private Vector3 ownPosition;
    private Vector3 ownScale;

    //�˹� ����
    public bool knockback = false;
    public float knockbackTime = 0.5f;
    public float knockbackTimer = 0;
    public float frictionRate = 0.95f;

    //���ο� ����
    public float moveSpeedValue = 0;
    public bool frozen = false;
    public float freezeTime = 3f;
    public float freezeTimer = 0;


    [SerializeField]
    public float attackDamage;

    
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        barTransform = healthBar.transform;
        ownPosition = healthBar.transform.localPosition;
        ownScale = healthBar.transform.localScale;
        
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
        if(dropped != null)
           Instantiate(dropped, this.transform.position, Quaternion.identity);
    }
    protected void moveToPlayer()
    {
        //�����̻� ó��
        moveSpeedValue = 0;
        if (frozen)
        {
            moveSpeedValue -= 0.25f;
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            freezeTimer += Time.deltaTime;
            if(freezeTimer >= freezeTime)
            {
                frozen = false;
                freezeTimer = 0;
            }
        }
        else
            this.GetComponent<SpriteRenderer>().color = Color.white;
            

        if (player && !knockback)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            // ���� �÷��̾� �������� �̵���Ŵ
            transform.Translate(direction * (speed * (1 + moveSpeedValue)) * Time.deltaTime);
            if (direction.x < 0)
                flipE(false);
            else
                flipE(true);
        }
        else if (knockback)
        {
            knockbackTimer += Time.deltaTime;
            this.transform.GetComponent<Rigidbody2D>().velocity *= frictionRate;
            if (knockbackTimer >= knockbackTime)
            {
                knockback = false;
                knockbackTimer = 0;
                this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    public void Knockback(Vector2 dir, float pow)
    {
        this.transform.GetComponent<Rigidbody2D>().velocity = dir * pow;
        knockback = true;
    }
   
public void flipE(bool a = true)

    {
        spriteRenderer.flipX = a;
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
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("ItemObject") || collision.gameObject.CompareTag("Structure"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.GetComponent<Player>());
            if(attackDamage>0)
                collision.gameObject.GetComponent<Player>().takeDamage(attackDamage);
            
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
        /*
        float scale = (float)this.getCurHP() / (float)this.getMaxHP();
        barTransform.localScale = new Vector3(scale*ownScale.x, ownScale.y, 1f);
        barTransform.localPosition = new Vector3(-0.5f + scale * 0.5f* ownScale.x, barTransform.localPosition.y, 0f);
        */

        float healthPercentage = (float)(this.getCurHP() / this.getMaxHP());
        Vector3 newScale = ownScale;
        newScale.x *= healthPercentage;
        healthBar.transform.localScale = newScale;

        float xPos = ownPosition.x - (ownScale.x - newScale.x) / 2;
        Vector3 newPos = ownPosition;
        newPos.x = xPos;
        healthBar.transform.localPosition = newPos;
    }
    public void initE(int P)
    {
        SetManager();
        
        player = gameManager.FindPlayerByNumber(P);
        playerScript = player.GetComponent<Player>();
    }


}
