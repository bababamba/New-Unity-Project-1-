using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EventRoom : Room
{
    public Random random = new Random();

    public EventRoom(int x, int y) : base(x, y)
    {
        this.type = RoomType.EVENT;
        Init();
    }

    public enum EventType
    {
        NONE = 0,

    }
    public EventType eventNum = EventType.NONE;

    public void Init()
    {
        // 이벤트 결정
            // 이벤트 풀이 존재해야 한다.
            // 이벤트 풀에서 랜덤으로 이벤트를 뽑아낸다.
            // 뽑아낸 이벤트는 이벤트 풀에서 임시 제거되어, 스테이지 클리어 시 초기화된다.

        // UI 연동
            // Monobehaviour를 상속한 인게임 오브젝트에서 UI를 띄운다.
            // '이벤트 결정' 파트에서 정해진 이벤트 내용(JSON이나 딕셔너리 활용하여 이름-내용 적어둬야 함) 출력
    }

    public void Execute(int num)
    {
        // 이벤트 처리
            // UI 연동을 통해 UI에는 현재 이벤트 방 스크립트에 접근 가능하다.
            // UI에서 버튼을 눌러 Execute(선택지 번호)를 전달한다.
            // 이벤트의 해당 번호에 대한 선택지 결과를 제공한다.
    }
}
