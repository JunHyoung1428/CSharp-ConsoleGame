/*<과제>
 * 컴퓨터와 가위바위보를 진행하자
 * 
 * Rule.
 *      1. 플레이어는 가위, 바위, 보 중에서 하나를 선택하여 입력하도록 하자
 *      2. 랜덤으로 컴퓨터가 가위, 바위, 보 중에 하나를 선택하게 하자
 *      3. 승패를 계산해서 플레이어가 이긴 횟수, 컴퓨터가 이긴 횟수를 보여주도록 하자
 *      4. (5판 3선)둘 중 한쪽이 3번 이겼을 때 누가 이겼는지 출력하고 게임을 종료하도록 하자
 * 
 */

/*<추가 조건>
 *  1.Main 함수의 길이는 20줄 제한
 *  2. 가위, 바위, 보 string X -> enum 으로 관리
 *  3. 플레이어 입력 Console.ReadLine() 사용 X ReadKey()로 진행
 *          ㄴ ConsoleKetInfo 를 사용
 */


namespace RockScissorsPaper
{
    internal class Program
    {
        enum Hand
        {
            바위,
            가위,
            보,
            None
        }
        static Hand GetPlayerChoice()
        {
            ConsoleKeyInfo key;
            Hand playerChoice = Hand.None;
            while (playerChoice == Hand.None)
            {

                Console.Write("\n 가위[1] 바위[2] 보[3] 중 하나를 입력해 주세요 : ");
                key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        playerChoice = Hand.가위;
                        break;
                    case '2':
                        playerChoice = Hand.바위;
                        break;
                    case '3':
                        playerChoice = Hand.보;
                        break;
                    default:
                        Console.WriteLine("\n올바른 값을 입력해 주세요.");
                        break;

                }
            }
            Console.WriteLine();
            Console.WriteLine($"당신은 {playerChoice} 를 냈습니다.");
            return playerChoice;
        }
        static Hand GetCPUChoice()
        {
            Hand cpuChoice = Hand.None;
            Random rand = new Random();
            int randInt = rand.Next(3);
            switch (randInt)
            {
                case 0:
                    cpuChoice = Hand.가위;
                    break;
                case 1:
                    cpuChoice = Hand.바위;
                    break;
                case 2:
                    cpuChoice = Hand.보;
                    break;
            }
            return cpuChoice;
        }

        static void PlayGame()
        {
            Hand playerChoice, cpuChoice;
            int playerWinCnt = 0, cpuWinCnt = 0, drawCnt = 0;

            while (playerWinCnt < 3 && cpuWinCnt < 3)
            {
                playerChoice = GetPlayerChoice();
                cpuChoice = GetCPUChoice();
                Console.WriteLine($"CPU는 {cpuChoice} 를 냈습니다.");
                if (playerChoice == cpuChoice)
                {
                    drawCnt++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("무승부 입니다.");
                    Console.ResetColor();
                }
                else if (playerChoice == Hand.가위 && cpuChoice == Hand.보 ||
                    playerChoice == Hand.바위 && cpuChoice == Hand.가위 ||
                     playerChoice == Hand.보 && cpuChoice == Hand.바위)
                {
                    playerWinCnt++;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"당신이 이겼습니다. \t당신이 이긴 횟수:{playerWinCnt}");
                    Console.ResetColor();
                }
                else
                {
                    cpuWinCnt++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"CPU가 이겼습니다. \tCPU가 이긴 횟수{cpuWinCnt}");
                    Console.ResetColor();
                }
            }
            if (playerWinCnt == 3)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n\n<<< GAME OVER >>>");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n<<< GAME OVER >>>");
                Console.ResetColor();
            }
            Console.WriteLine($"\n당신이 이긴횟수:{playerWinCnt}회\tCPU가 이긴횟수:{cpuWinCnt}회\t무승부{drawCnt}회");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("<<<가위 바위 보 게임>>>\n");

            PlayGame();

            Console.WriteLine("종료할려면 아무 키나 입력해주세요.");
            Console.ReadKey();
        }
    }
}