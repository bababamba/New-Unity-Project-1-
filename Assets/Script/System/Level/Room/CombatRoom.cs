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
        // 전투 종류 확인
            // 일반 전투일 시, 등장 적 타입 리스트에서 랜덤 선택하여 맵에 전달한다.
            // 엘리트 전투일 시, 추가로 들어갈 난이도 조정 사항 리스트에서 랜덤 선택하여 맵에 전달한다.
            // 보스 전투일 시, 등장 보스 타입 리스트에서 랜덤 선택하여 맵에 전달한다.
    }

}
