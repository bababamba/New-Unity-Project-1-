using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theaxe : passive_base
{
    // Start is called before the first frame update
    private void Awake()
    {
        itemNum = 6;

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ad = 100;
        armor = 1;

        itemName = "��ī�ο� ����";

        itemCaption = "���ݷ��� ���ϰ� �÷��ش�.���ݷ�:100";
    }
    public override void levelUp()
    {
        base.levelUp();
        ad += 30;
    }
}
