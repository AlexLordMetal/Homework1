using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте диапазон чисел.");
            Console.Write("MIN: ");
            int min = Int32.Parse(Console.ReadLine());
            Console.Write("MAX: ");
            int max = Int32.Parse(Console.ReadLine());
            int[] numArray = new int[max - min];

            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = min + i;
            }

            Random random = new Random();
            int j = 0;          // Additional value for random array element
            int tempNum = 0;    // Additional value for changing array elements

            for (int i = 0; i < numArray.Length; i++)     // Randomize array
            {
                j = random.Next(numArray.Length);
                if (i != j)
                {
                    tempNum = numArray[i];
                    numArray[i] = numArray[j];
                    numArray[j] = tempNum;
                }
            }

            Console.WriteLine("Массив с рандомом:");
            foreach (int i in numArray)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            for (int i = 0; i < numArray.Length - 1; i++)     // Sort array
            {
                for (j = i + 1; j < numArray.Length; j++)
                {
                    if (numArray[j] < numArray[i])
                    {
                        tempNum = numArray[i];
                        numArray[i] = numArray[j];
                        numArray[j] = tempNum;
                    }
                }
            }

            Console.WriteLine("Отсортированный массив:");
            foreach (int i in numArray)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}