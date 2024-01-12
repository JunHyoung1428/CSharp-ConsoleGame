using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        List<Card> hand;
        //flag 변수 추가할것

        public void Draw(Card card)
        {
            hand.Add(card);
        }

        public void Judge()
        {
            int sum = 0;
            foreach (Card card in hand)
            {
                sum += card.Power;
            }

            if (sum == 21)
            {
                // WIN
                // flag 변경
            }
            else if(sum > 21)
            {
                //Burst
                // flag 변경
            }
            else
            {
                //Keep Game
            }
        }
    }
}
