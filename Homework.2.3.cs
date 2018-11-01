using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте диапазон, в котором будете загадывать число.");
            Console.Write("MIN: ");
            int startNum = Int32.Parse(Console.ReadLine());
            Console.Write("MAX: ");
            int endNum = Int32.Parse(Console.ReadLine());
            int midNum = 0;
            int count1 = 0;
            double testNum = endNum - startNum + 1;
            do
            {
                testNum = testNum / 2;
                count1++;
            } while (testNum >= 1);
            Console.WriteLine($"Загадайте ваше число. Я отгадаю его за {count1} попыток.");
            int count2 = 1;
            string isIt = "";
            while ((isIt != "=") && (count2 < count1 + 1))
            {
                midNum = startNum + (endNum - startNum) / 2;
                Console.WriteLine($"Попытка {count2}: Ваше число {midNum} ? < = >");
                isIt = Console.ReadLine();

                if (isIt == "=")
                {
                    Console.WriteLine("Я угадал, я умная машина!");
                }
                else if (isIt == "<")
                {
                    endNum = midNum;
                }
                else if (isIt == ">")
                {
                    startNum = midNum + 1;
                }
                else
                {
                    Console.WriteLine("Вы мухлюете, я пас!");
                    isIt = "=";
                }
                count2++;
            }
            if ((isIt != "=") && (count2 == count1 + 1))
            {
                Console.WriteLine("Вы мухлюете, я пас!");
            }
            Console.ReadKey();
        }
    }
}