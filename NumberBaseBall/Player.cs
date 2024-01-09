using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberBaseBall
{
    class Player
    {
        int[] playerChoice = new int[4];
        int life = 1;
        public Player()
        { 

        }

        public int[] GetPlayerChoice()
        {
            return playerChoice;
        }

        public void SetPlayerChoice()
        {
            int intChoice = 0;
            do
            {   
                Console.Write("숫자를 입력하세요:");
                string strChoice = Console.ReadLine();
                if ( strChoice.Length == 4 && int.TryParse(strChoice, out intChoice))
                {
                    int cnt = 0;
                   foreach(char c in strChoice)
                    {
                        playerChoice[cnt] = int.Parse(c.ToString());
                        cnt++;
                    }
                }
                else
                {
                    Console.WriteLine("\n올바른 숫자를 입력해주세요.");
                }
            } while (intChoice == 0);
        }

        public void ReduceLife()
        {
            life++;
        }

        public int GetLife() 
        { 
            return life;
        }

        public void EndGame()
        {
            life =11;
        }
    }
}
