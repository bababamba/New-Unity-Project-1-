using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class ShopRoom : Room
{
    public Random random = new Random();

    public ShopRoom(int x, int y) : base(x, y)
    {
        this.type = RoomType.MERCHANT;
        Init();
    }

    public void Init()
    {
        //UI 연동
            // Monobehaviour를 상속한 인게임 오브젝트에서 UI를 띄운다.

        //이벤트 처리
            // 상품 리스트에서 정해진 갯수만큼 랜덤으로 상품을 결정한다.
            // 상품(무기 레벨업) 리스트에서 이미 최대 레벨인 무기는 사전에 제외한다.

        //UI 표시
            // '이벤트 처리'에서 결정한 상품들을 UI 내 각 상품 칸에 배치한다.
    }

}
