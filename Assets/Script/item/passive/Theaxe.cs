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
        ad = 30;
        armor = 1;

        itemName = "��ī�ο� ����";
        itemText = "���ݷ�:30";
        itemCaption = "���ݷ��� ���ϰ� �÷��ش�. �ֵθ��⿡�� �ʹ� ������ ���� �������� �� ����.";
    }
    public override void levelUp()
    {
        base.levelUp();
        itemName = "��ī�ο� ����+" + (level-1).ToString();
              
        ad += 10;
        itemText = "���ݷ�:" + ad.ToString();
    }
}
