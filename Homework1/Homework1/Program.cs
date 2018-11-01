using System;
using System.Threading;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вам надо сходить в магазин.");
            Console.WriteLine("Сколько товаров должно быть в списке? (От 1 до 10)");
            int numberOfProducts = ShoppingAmount(Console.ReadLine());
            Console.WriteLine("Ожидайте, идет генерация списка покупок:");
            string[] ShoppingList = GenerateShoppingList(numberOfProducts);
            Console.WriteLine("Хотите добавить что-то еще к списку? (Enter - пропустить)");
            ShoppingList = AddProduct(ShoppingList, Console.ReadLine());
            string[] WearingList = Dress();
            int isDressed = WearingList.Length;
            Console.WriteLine("Какую сумму денег вы с собой возьмете");
            int ShoppingMoney = TakeMoney(Console.ReadLine());
            Console.WriteLine("Вы вышли на улицу. По какой дороге пойдете, длинной или короткой? (1 или 2)");
            RoadToShop(isDressed, Console.ReadLine());
            Console.WriteLine("Вы пришли в магазин. Покупаем продукты по списку");
            int LeftMoney = Shopping(ShoppingList, ShoppingMoney);

            /*********************************/
            /*Все проверки пройдены           /
            /*********************************/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Поздравляем! Вы удачно сходили в магазин. Вы оделись в " + String.Join(", ", WearingList) +
                ". По дороге не встретили гопников. В магазине купили " + String.Join(", ", ShoppingList) +
                ". У вас еще осталось " + LeftMoney + " рублей");
            Console.ReadLine();
        }


        /*********************************/
        /* Генерируем случайное число     /
        /*********************************/
        static int GenerateRandomNumber(Random random)
        {
            return random.Next(10);
        }

        /*********************************/
        /* Неудачный исход квеста         /
        /*********************************/
        static void BadEnd(string myText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(myText);
            Console.ReadLine();
            Environment.Exit(0);
        }

        /*********************************/
        /*Количество продуктов            /
        /*********************************/
        static int ShoppingAmount(string NumberOfProducts)
        {
            bool isItNumber = Int32.TryParse(NumberOfProducts, out int numberOfProducts);
            if (isItNumber == false || numberOfProducts < 1 || numberOfProducts > 10)
                BadEnd("Не хватает интеллекта для выбора числа от 1 до 10. Улучшите интеллект и попробуйте еще раз...");
            return numberOfProducts;
        }


        /*********************************/
        /*Генерируем список покупок       /
        /*********************************/
        static string[] GenerateShoppingList(int numberOfProducts)
        {
            string[] fullShoppingList = { "пельмени", "пиво", "водка", "виски", "абсент", "джин", "коньяк", "вино", "ром", "печеньки" };
            string[] myShoppingList = new string[numberOfProducts];
            int i;
            int j;
            bool notEqual = true;
            Random random = new Random();

            for (i = 0; i < numberOfProducts; i++)
            {
                myShoppingList[i] = fullShoppingList[GenerateRandomNumber(random)];
                notEqual = true;
                for (j = 0; j != i; j++)
                    if (myShoppingList[i] == myShoppingList[j])
                        notEqual = false;
                if (notEqual == true)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(myShoppingList[i]);
                }
                else
                    i = --i;
            }
            return myShoppingList;
        }

        /*********************************/
        /*Добавляем товар в список        /
        /*********************************/
        static string[] AddProduct(string[] myShoppingList, string myProduct)
        {
            if (myProduct != "")
            {
                Array.Resize(ref myShoppingList, myShoppingList.Length + 1);
                myShoppingList[myShoppingList.Length - 1] = myProduct;
                Console.WriteLine("Товар " + myShoppingList[myShoppingList.Length - 1] + " добавлен к списку покупок");
            }
            return myShoppingList;
        }

        /*********************************/
        /*Одеваемся                       /
        /*********************************/
        static string[] Dress()
        {
            string DressString = "";
            string[] myWearingList = new string[10];
            int i = 0;
            Console.WriteLine("Что вы оденете? (Разделитель - Enter, пропустить - Enter)");

            do
            {
                DressString = Console.ReadLine();

                if (DressString == "" && i == 0)
                    Console.WriteLine("Голый пойдете? Ваше право!");
                else if (i == 10)
                {
                    Console.WriteLine("Хватит одевать все подряд!");
                    DressString = "";
                }
                else if (DressString != "")
                {
                    myWearingList[i] = DressString;
                    i = ++i;
                }
            }
            while (DressString != "");

            Array.Resize(ref myWearingList, i);
            return myWearingList;
        }

        /*********************************/
        /*Берем деньги                    /
        /*********************************/
        static int TakeMoney(string Money)
        {
            int myShoppingMoney = 0;
            bool isItMoney = Int32.TryParse(Money, out myShoppingMoney);

            if (isItMoney == false || myShoppingMoney == 0)
                BadEnd("Нет денег - нет магазина...");

            return myShoppingMoney;
        }

        /*********************************/
        /*Идем в магазин                  /
        /*********************************/
        static void RoadToShop(int isWeared, string RoadNumber)
        {

            if (isWeared == 0)                  //Проверка на наличие одежды
                BadEnd("Поскольку вы пошли в магазин без одежды, по дороге вас арестовали...");

            bool badEvent = false;

            if (RoadNumber == "1")              //Разный риск нарваться на гопников в зависимости от выбранной дороги
                RoadRisk(1);
            else if (RoadNumber == "2")
                RoadRisk(2);
            else
                BadEnd("Вы не смогли сделать правильный выбор, и магазин закрылся... Навсегда");
        }

        /*********************************/
        /*Шанс встретить гопников         /
        /*********************************/
        static void RoadRisk(int RoadNumber)
        {
            Random random = new Random();
            int randomResult = GenerateRandomNumber(random);

            if (RoadNumber == 1 && randomResult < 2)
                BadEnd("Вы встретили гопников, и оказались в больнице без денег и одежды...");
            else if (RoadNumber == 2 && randomResult < 7)
                BadEnd("Вы встретили гопников, и оказались в больнице без денег и одежды...");
        }

        /*********************************/
        /*В магазине                      /
        /*********************************/

        static int Shopping(string[] myShoppingList, int LeftMoney)
        {
            int PriceMoney = 0;

            for (int i = 0; i < myShoppingList.Length; i++)
            {
                Console.WriteLine("Сколько стоит " + myShoppingList[i] + "?");
                bool isItMoney = Int32.TryParse(Console.ReadLine(), out PriceMoney);
                if (isItMoney == false || PriceMoney == 0)
                    BadEnd("Не хватает интеллекта для совершения покупок. Улучшите интеллект и попробуйте еще раз...");
                else
                {
                    LeftMoney = LeftMoney - PriceMoney;
                    if (LeftMoney < 0)
                        BadEnd("Вам не хватило денег, зарабатывайте больше...");
                }
            }
            return LeftMoney;
        }
    }
}
