using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = false;
            do
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 101);
                Console.WriteLine("Число загадано, попробуйте отгадать.");
                Console.Write("Введите предполагаемое число: ");
                int myNumber = Convert.ToInt32(Console.ReadLine());
                if (myNumber == randomNumber)
                {
                    Console.WriteLine($"Верно! Число {myNumber} и есть загаданное.");
                }
                else if (myNumber > randomNumber)
                {
                    Console.WriteLine($"Нет, не оно. Ваше число больше загаданного. Было загадано {randomNumber}.");
                }
                else
                {
                    Console.WriteLine($"Нет, не оно. Ваше число меньше загаданного. Было загадано {randomNumber}.");
                }
                Console.WriteLine("Хотите сыграть еще раз? (y, n)");
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "y" || yesOrNo == "Y")
                {
                    isContinue = true;
                    Console.Clear();
                }
                else
                {
                    isContinue = false;
                }
            } while (isContinue == true);
        }
    }
}