using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberBaseBall
{
     class COM
    {

        int[] comChoice = new int[4];

        public COM()
        {
            //생성할 때, 4가지 숫자를 중복 없이 뽑아서 comChoice 배열에 삽입.
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int temp = rand.Next(1, 10);
                if (comChoice.Contains(temp)) // 중복검사, 중복시 다시 뽑음
                {
                    i--;
                }
                else
                {
                    comChoice[i] = temp;
                }
            }
        }
        public int[] GetComChoice()
        {
            return comChoice;
        }
    }
}
