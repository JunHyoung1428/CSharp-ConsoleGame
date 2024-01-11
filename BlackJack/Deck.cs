using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
     class Deck
    {
        List<Card> deck;

        //덱을 초기화 하는 메서드
        public void InitDeck()
        {
            //카드 객체 52개 만들어서 넣기
        }

        //카드를 뽑아서 덱에서 제거하고 카드를 반환하는 메서드
        public Card Draw()
        {
            Random rand = new Random();

           //랜덤으로 뽑아서 리스트에서 해당 인덱스 카드 Remove()
            return deck[1];
        }


    }
}
