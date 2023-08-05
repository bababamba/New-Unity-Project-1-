using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;


public class Player : Creture, IPunObservable
{
    public Rigidbody2D RB;
    public Animator AN;
    public SpriteRenderer SR;
    public PhotonView PV;
    public Text NickNameText;

    public GameObject HealthBar;
    private Transform barTransform;
    public VirtualJoystick VJ;
    
    
    public Vector2 playerDirection;
    Vector3 curPos;

    public int armor;
    public int ad;
    public int ap;
    public int move;
    public int armorP;
    public int magicP;
    public float critical;
    private void Awake()
    {
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.color = PV.IsMine ? Color.white : Color.blue;

        
        this.init(100, 10, 1);
        VJ.speed = this.speed;
        
        gameObject.tag = "Player";
        if (PV.IsMine)
        {
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        }



    }
    // Start is called before the first frame update
    private void Start()
    {
        barTransform = HealthBar.transform;
    }

    // Update is called once per frame
    private void Update()
    {//위치 동기화
        UpdateHealthBar();
        if (!PV.IsMine)
            if ((transform.position - curPos).magnitude >= 100) transform.position = curPos;
            else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
        
        
    }
    public override void death()
    {
        //base.death();
        VJ.speed = 0;
        Debug.Log("GAME OVER");
    }
    public Transform playerTransform()
    {
        return this.transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ItemObject"))
        {
            gameManager.expUp(10f);
            Destroy(collision.gameObject);
        }
    }


    public void playerStatusChange(int cHp, int cArmor, int cAd, int cAp, float cMove, int cArmorP, int cMagicP, float cCritical, bool equip )
    {
        if (equip)
        {
            this.addMaxHP(cHp);
            this.armor += cArmor;
            this.ad += cAd;
            this.ap += cAp;
            this.speed += cMove;
            this.armorP += cArmorP;
            this.magicP += cMagicP;
            this.critical += cCritical;
        }
        else
        {
            this.addMaxHP(-cHp);
            this.armor -= cArmor;
            this.ad -= cAd;
            this.ap -= cAp;
            this.speed -= cMove;
            this.armorP -= cArmorP;
            this.magicP -= cMagicP;
            this.critical -= cCritical;
            
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(HealthBar.transform.localScale);
        }
        else
        {
            curPos = (Vector3)stream.ReceiveNext();
            HealthBar.transform.localScale = (Vector3)stream.ReceiveNext();
        }
    }
    private void UpdateHealthBar()
    {
        float scale = (float)this.getCurHP() / (float)this.getMaxHP();
        barTransform.localScale = new Vector3(scale, 0.1f, 1f);
        barTransform.localPosition = new Vector3(-0.5f + scale * 0.5f, 0.7f, 0f);
    }
}
