using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    //카드 클래스, 고유한 id를 가지며(1~52) 그에 따라 맞는 숫자와 문양을 가짐
     class Card
    {
        int id; // 1~52

        string symbole; //♠ ♣ ♥ ◆
        string strNumber; // A ,2 ,3 ,4 5 ~ 10 , J , Q , K
        int power;

        public int Power { get { return power; } }

        // id 에 따라 카드의 심볼과 숫자를 세팅하는 생성자
        public Card(int id)
        {
            this.id = id;

            switch (id % 13)
            {
                case 1:
                    strNumber = "A ";
                    power = 10;
                    break;
               
                case 11:
                    strNumber = "J ";
                    power = 10;
                    break;
                case 12:
                    strNumber = "Q ";
                    power = 10;
                    break;
                case 0:
                    strNumber = "K ";
                    power = 10;
                    break;
                default:
                    strNumber = (id % 13).ToString();
                    power = id % 13;
                    break;
            }
            
            switch ((id-1) / 13)
            {
                case 0:
                    symbole = "♠";
                    break;
                case 1:
                    symbole = "♣";
                    break;
                case 2:
                    symbole = "♥";
                    break;
                case 3:
                    symbole = "◆";
                    break;
            }
        }

        //카드의 정보를 콘솔 화면에 보여주는 메소드
        public void Print()
        {

            if(symbole == "♥" || symbole== "◆")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }//Fix:빨간색일때 맨 오른쪽 끝이 안나옴;;
            Console.WriteLine("┌─────────┐");
            Console.WriteLine($"│ {strNumber}      │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│    {symbole}   │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│      {strNumber} │");
            Console.WriteLine("└─────────┘");

            Console.ResetColor();
        }
    }
}
