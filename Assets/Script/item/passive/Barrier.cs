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
        itemName = "�޴�� ��ȣ�� ������ġ";
        itemText = "hp:10 armor:2";
        itemCaption = "������ ������ �̿��Ͽ� ����ڿ��� ��ȣ���� �������ش�. �ѹ� ���ظ� ���� ����, �������� �ʿ��ϴ�.";
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