using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Загадайте число от 0 до 100");
            int startNum = 0;
            int endNum = 100;
            int midNum = 0;
            int count = 1;
            string isIt = "";
            Console.Write("Загадали? ");
            while (isIt != "=" && count < 8)
            {
                midNum = startNum + (endNum - startNum) / 2;
                Console.WriteLine($"Попытка {count}: Ваше число {midNum} ? < = >");
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
                count++;
            }

            if (isIt != "=" && count == 8)
            {
                Console.WriteLine("Вы мухлюете, я пас!");
            }

            Console.ReadKey();
        }
    }
}
