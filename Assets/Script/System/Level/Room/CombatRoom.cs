using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CombatRoom : Room
{
    public Random random = new Random();

    public CombatRoom(int x, int y) : base(x, y) 
    {
        Init();
    }

    public void Init()
    {
        // ���� ���� Ȯ��
            // �Ϲ� ������ ��, ���� �� Ÿ�� ����Ʈ���� ���� �����Ͽ� �ʿ� �����Ѵ�.
            // ����Ʈ ������ ��, �߰��� �� ���̵� ���� ���� ����Ʈ���� ���� �����Ͽ� �ʿ� �����Ѵ�.
            // ���� ������ ��, ���� ���� Ÿ�� ����Ʈ���� ���� �����Ͽ� �ʿ� �����Ѵ�.
    }

}
