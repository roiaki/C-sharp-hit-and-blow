using System;
using System.Reflection.Metadata.Ecma335;

namespace HitAndBlow
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 乱数作成して
            int[] rand = CreatRandNum();
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine(rand[i]);
            }
            while (true)
            {
                // 入力して
                int[] input = InputNumber();
                // 判定する
                if (Judgement(input, rand))
                {
                    break;
                }
            }           
        }

        /*
         * 乱数作成メソッド 
         * @return int[] randNum 生成した乱数
         * 
         */
        public static int[] CreatRandNum() 
        {
            int[] randArray = new int[4];
            while (true)
            {               
                Random rand = new System.Random();
                int randNum = rand.Next(1000, 10000);
                for (int i = 0; i <= 3; i++)
                {
                    randArray[i] = randNum % 10;
                    randNum = randNum / 10;
                    Console.WriteLine(i + ": " + randArray[i]);
                }

                if (randArray[3] != 0)
                {
                    if (DuplicationCheck(randArray))
                    {
                        break;
                    }
                }
            }
            return randArray;
        }
   
        /*
         * 入力メソッド　
         * @return int[] numArray
         */ 
        public static int[] InputNumber()
        {
            String str = System.Console.ReadLine();
            int num = System.Int32.Parse(str);
            int[] numArray = new int[4];
            for (int i = 0; i <= 3; i++)
            {
                numArray[i] = num % 10;
                num = num / 10;
                Console.WriteLine(numArray[i]);
            }
            return numArray;

        }

        /*
         * 重複チェックメソッド
         * @param int[] randNum 生成した乱数
         * @return Boolean dupulicatedFlag 重複していたらfalse 
         */ 
        public static Boolean DuplicationCheck(int[] randNum)
        {
            Boolean dupulicatedFlag = true;
            for (int i = 0; i < randNum.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (randNum[i] == randNum[j])
                    {
                        dupulicatedFlag = false;
                    }
                }
            }
            Console.WriteLine(" i" + dupulicatedFlag);
            return dupulicatedFlag;
        }

        /*
         * 判定メソッド
         * @param int[] rand 乱数
         * @param int[] input 入力された整数
         * @return boolean correctFlag 正解したらtrue
         */ 
        public static Boolean Judgement(int[] rand, int[] input)
        {
            int BlowCnt = 0;
            int HitCnt = 0;
            Boolean correctFlag;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (rand[i] == input[j])
                    {
                        BlowCnt++;
                    }
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == rand[i])
                {
                    HitCnt++;
                }
            }
            Console.WriteLine(HitCnt + "Hit" + (BlowCnt - HitCnt) + "Blow");
            if (HitCnt == 4)
            {
                Console.WriteLine("正解です");
                correctFlag = true;
            } 
            else
            {
                correctFlag = false;
            }
            return correctFlag;
        }
    }
}
