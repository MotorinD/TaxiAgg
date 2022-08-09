using System;
using System.Diagnostics;
using System.Threading;
using TaxiAgg.Models;

namespace TaxiAgg
{
    internal class Program
    {
        private static Random Rnd = new Random();
        private static int MaxSleepTime = 10000;
        public static int GetRandomSleepTime() => Rnd.Next(MaxSleepTime);

        static TaxiService TaxiService = new TaxiService();

        static void Main(string[] args)
        {


            while (true)
            {
                var result = SearchTaxi();

                if (result is null)
                {
                    Console.WriteLine("Didn't find a taxi");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Want to book taxi? Y/N");
                Console.ReadKey();

                //Если пользователь захочет выбрать найденное такси, вызываем метод бронирования и переходим в  режим ожидания
                //прибытия машины, иначе ничего не делаем. В процессе ожидания можно добавить вызов метода отмены бронирования аналогичный как для бронирования.
                if (true)
                {
                    TaxiService.BookTaxi(result.Id, result.ServiceId);
                    Console.WriteLine("Waiting for taxi arrived...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Request denied search again?");
                    continue;
                }
            }
        }

        private static ResponseTaxiModel SearchTaxi()
        {

            var spin = new ConsoleSpiner();
            var sw = new Stopwatch();

            sw.Restart();

            var searchTaxiTask = TaxiService.RequestTaxiAsync(new Models.RequestTaxiParams());

            Console.Write("Looking for taxi....\n");

            while (!searchTaxiTask.IsCompleted)
            {
                Thread.Sleep(100);
                spin.Turn();
            }

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"Search time: {sw.ElapsedMilliseconds} ms");

            var searchResult = searchTaxiTask.Result;

            return searchResult;
        }

        public class ConsoleSpiner
        {
            int _counter;
            public ConsoleSpiner()
            {
                this._counter = 0;
            }
            public void Turn()
            {
                this._counter++;
                switch (this._counter % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }
}
