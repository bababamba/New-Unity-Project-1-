using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : passive_base
{
    public GameObject barrier;
    private GameObject BarrierObject;
    private void Awake()
    {
        itemNum = 7;

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hp = 10;
        armor = 2;
        Maxcooldown = 3f;
        itemName = "휴대용 보호막 생성장치";
        itemText = "hp:10 armor:2";
        itemCaption = "주위의 마력을 이용하여 사용자에게 보호막을 생성해준다. 한번 피해를 막고 나면, 재충전이 필요하다.";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!playerScript.isBarrier)
        {   
            if(BarrierObject)
                Destroy(BarrierObject);
            CooldownOff = false;
        }

    }
    protected override void itemTrigger(int itemLevel)
    {
        CooldownOff = true;
        BarrierObject = Instantiate(barrier, player.transform.position, Quaternion.identity);
        BarrierObject.transform.parent = player.transform;
        playerScript.isBarrier = true;

    }
}