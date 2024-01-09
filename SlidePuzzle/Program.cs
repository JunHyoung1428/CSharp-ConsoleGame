/******************************************
  슬라이드 퍼즐 만들기
*   5x5 판을 생성하고 랜덤한 숫자를 배치한다.
* 시작위치는 상관없으며 ArrowKey입력시 해당 방향으로 이동한다.
*   단, 밖으로 벗어날 수 없다.
*   아래 예시는 0이 움직이는 것으로 가정한다.
 *******************************************/

using System;

namespace SlidePuzzle
{
    internal class Program
    {

        static int[,] puzzle = new int[5, 5];
        static int cursorX = 0, cursorY = 0;


        //puzzle 배열과 화면을 초기화하는 메서드
        static void InitalizedPuzzle()
        {
            RandomizePuzzle();
            DrawPuzzle();
        }

        //키보드 입력을 ReadKey()로 받는 메서드
        static ConsoleKeyInfo GetKey()
        {
            Console.WriteLine("← : 왼쪽  → : 오른쪽  ↑ : 위쪽  ↓ : 아래쪽");
            ConsoleKeyInfo key = Console.ReadKey();
            return key;
        }
        //화면에 puzzle 배열을 화면에 그리는 메서드
        static void DrawPuzzle()
        {
            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // Console.Write($"({i},{j})\t");  //for Debug
                    if (puzzle[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{puzzle[i, j]}\t");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{puzzle[i, j]}\t");
                    }
                }
                Console.WriteLine("\n\n\n");
            }
        }
        // puzzle 배열을 랜덤하게 섞고 삽입하는 메서드
        static void RandomizePuzzle()
        {
            Random rand = new Random();
            int[] numbers = new int[25];
            for (int i = 0; i < 25; i++)
            {
                numbers[i] = i;
            }

            // 0~24의 숫자를 랜덤하게 섞기 (피셔-예이츠 셔플)
            for (int i = 24; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            // 섞은 숫자를 puzzle배열에 삽입
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    puzzle[row, col] = numbers[row * 5 + col];
                    if (numbers[row * 5 + col] == 0)
                    {
                        cursorX = row;
                        cursorY = col;
                    }
                }
            }
        }

        // Cursor(0) 위치를 조정하는 메서드
        // 키보드 입력 방향에 맞춰서 해당 값과 0의 위치를 교환해야함
        static void MoveCursor(ConsoleKeyInfo key)
        {
            //0의 위치는???  puzzle[cursorX,cursorY]
            int newX = cursorX;
            int newY = cursorY;


            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (cursorX > 0)
                    {
                        newX = cursorX - 1;
                    }
                    //Console.WriteLine("위");
                    break;
                case ConsoleKey.DownArrow:
                    if (cursorX < 4)
                    {
                        newX = cursorX + 1;
                    }
                    //Console.WriteLine("아래");
                    break;
                case ConsoleKey.LeftArrow:
                    if (cursorY > 0)
                    {
                        newY = cursorY - 1;
                    }
                    //Console.WriteLine("왼쪽");
                    break;
                case ConsoleKey.RightArrow:
                    if (cursorY < 4)
                    {
                        newY = cursorY + 1;
                    }
                    //Console.WriteLine("오른쪽");
                    break;
            }

            // 빈칸하고 기존 값 바꾸기
            puzzle[cursorX, cursorY] = puzzle[newX, newY];
            puzzle[newX, newY] = 0;
            // 기존 좌표를 새 좌표로 바꾸기
            cursorX = newX;
            cursorY = newY;
        }
        static bool IsGameFinish()
        {
            int cnt = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (puzzle[i, j] != cnt++)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            InitalizedPuzzle();

            while (!IsGameFinish())
            {
                DrawPuzzle();
                //Console.WriteLine($"{cursorX},{cursorY}");//for Debug
                MoveCursor(GetKey());
            }

            Console.WriteLine("Finsh!");
        }
    }
}