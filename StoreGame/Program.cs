﻿/*
 ■	상점 게임 만들기
1.	상점에서는 다음 작업들이 가능하다.
    A.	아이템 구매
    B.	아이템 판매
    C.	아이템 확인
2.	아이템은 기본적으로 이름, 설명, 가격을 가지고 있으며,
    무기는 공격력, 방어구는 방어력, 장신구는 체력을 상승시키는 수치를 가진다.
3.	아이템 구매 메뉴 선택시 상점이 소유하고 있는 아이템들 목록이 제공되고,
    구매하고자 하는 아이템을 선택시 구매를 진행한다. 단, 돈이 부족하다면 구매는 진행되지 않는다.
    구매가 완료되면 소유한 아이템에 구매한 아이템이 추가되며, 아이템에 의해 플레이어 능력이 상승한다.
4.	아이템 판매 메뉴 선택시 플레이어가 소유하고 있는 아이템들 목록이 제공되고,
    판매하고자 하는 아이템을 선택시 판매를 진행한다. 단, 소유한 아이템이 없다면 진행되지 않는다.
    판매가 완료되면 소유한 아이템에 판매한 아이템이 제거되며, 아이템에 의해 플레이어 능력이 하락한다.
5.	아이템 확인 메뉴 선택시 플레이어가 소유하고 있는 아이템들 목록이 제공되고,
    아이템들에 의해 상승한 플레이어 최종 능력치를 보여준다.
플레이어는 최대 6개의 아이템을 소유할 수 있으며 빈칸은 보여주지 않는다.
 */


namespace StoreGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Store store = new Store();

            while (true)
            {
                store.StoreMenu(player);
            }
        }
    }
}
