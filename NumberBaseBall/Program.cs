/*
 ■	숫자야구 게임 만들기
1.	컴퓨터는 1~9 중에 랜덤한 4자리 숫자를 뽑는다. 단, 중복은 허용하지 않는다.
2.	유저는 10번의 기회가 있다.
3.	플레이어가 수를 입력하면 컴퓨터는 아래조건에 맞추어 결과를 알려준다.
A.	Ball : 자리수는 다르지만 포함된 경우
B.	Strike : 자리수와 값이 동일한 경우
C.	Out : 숫자가 하나도 맞지 않을 경우
D.	HomeRun : 모든 숫자가 자리수와 값이 동일한 경우
E.	예시 : 정답이 3629 일 때, 1234 -> 2Ball / 2649 ->2Strike 1Ball / 4518 -> Out
4.	10번의 기회 소진 전까지 정답을 맞추면 승리하며, 모든 기회를 소진하면 패배한다.
*/

namespace NumberBaseBall
{
    internal class Program
    {
       
        static void InitGame()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("********** 숫자 야구 **********");
            Console.WriteLine("*******************************\n");

        }
        static void Main(string[] args)
        {
            InitGame();
            COM com = new COM();
            Player player = new Player();
            
          
            PlayGame(com, player);
            
        }

        static void PlayGame(COM com, Player player)
        {
            int life = player.GetLife();
            while (life <= 10)
            {
                Console.WriteLine($"\n\n========== {life} 번째 기회 ==========\n");
                player.SetPlayerChoice();
                Judge(com,player);
                life = player.GetLife();
            }
            Console.WriteLine("\nGAME OVER!");
        }

        static void Judge(COM com, Player player)
        {
            int ballCnt = 0, strikeCnt = 0;

            int[] comChoice = com.GetComChoice();
            int[] playerChoice = player.GetPlayerChoice();

            for(int i = 0; i < comChoice.Length; i++)
            {
                if (comChoice[i] == playerChoice[i])
                {
                    strikeCnt++;
                }
                else if (playerChoice.Contains(comChoice[i]))
                {
                    ballCnt++;
                }
            }

            if(strikeCnt == 4)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Hom Run! \n승리했습니다!");
                Console.ResetColor();
                player.EndGame();
            }
            else if(strikeCnt==0 && ballCnt ==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Out!!");
                Console.ResetColor();
                player.ReduceLife();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Strike : {strikeCnt}\tBall : {ballCnt}");
                Console.ResetColor();
                player.ReduceLife();
            }
        }
    }
}
