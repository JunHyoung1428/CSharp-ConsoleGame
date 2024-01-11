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
        int number; // 1~13?

        // id 에 따라 카드의 심볼과 숫자를 세팅하는 생성자
        public Card(int id)
        {
            this.id = id;
            number = id % 13;
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
            string printedNumber;
            int value = id % 13;
            switch (value)
            {
                case 0:
                     printedNumber ="K ";
                    break;
                case 11:
                     printedNumber = "J ";
                    break;
                case 12:
                    printedNumber = "Q ";
                    break;
                case 1:
                    printedNumber = "A ";
                    break;
                default:
                    printedNumber = value.ToString();
                    break;
            }
           

            if(symbole == "♥" || symbole== "◆")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }//Fix:빨간색일때 맨 오른쪽 끝이 안나옴;;
            Console.WriteLine("┌─────────┐");
            Console.WriteLine($"│ {printedNumber}      │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│    {symbole}   │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│      {printedNumber} │");
            Console.WriteLine("└─────────┘");

            Console.ResetColor();
        }
    }
}
