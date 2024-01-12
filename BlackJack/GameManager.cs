using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class GameManager
    {
        Dealer dealer;
        User user;
        Deck deck;
        

        public GameManager()
        {
            dealer = new Dealer();
            user = new User();
            deck = new Deck();
        }


        //화면 그려주는 메소드
        public void Render() { 


        }

        //게임이 진행되는 메소드
        public void Game(){
            while (true)
            {

                Render();
            }
        }
    }
}
