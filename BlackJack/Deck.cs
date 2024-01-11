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

        }

        //카드를 뽑아서 덱에서 제거하고 카드를 반환하는 메서드
        public Card Draw()
        {
            Random rand = new Random();

           
            return deck[1];
        }


    }
}
