
using System;

namespace indice
{
    class Programa
    {
        static void Main(string[] args)
        {

            TwoSum(new int[] { 1, 2, 3 }, 4);
            TwoSum(new int[] { 3, 2, 4 }, 6);

        }
        public static int[] TwoSum(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {

                int num = numbers[i];

                for (int j = 0; j < numbers.Length; j++)
                {
                    int num2 = numbers[j];
                    if(num +  num2 == target && i!=j)
                        return new int[]{ i, j};
                }
            }
            return new int[0];
        }
    }
}