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
        //flag 변수

        public virtual void ISDraw()
        {

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
            }
            else if(sum > 21)
            {
                //Burst
            }
            else
            {
                //Keep Game
            }
        }
    }
}
