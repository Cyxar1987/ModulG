using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulGeo
{
    class Program
    {
        static List<Monolit> list;       
        // Заполняем List<> тестовыми монолитами
        static void TestAddMonolits()
        {
            list = new List<Monolit>
            {
                  new Monolit("1241", 1.25, 8.7, 10.22),
                  new Monolit("1241", 0.45, 7.00, 11.33),
                  new Monolit("1241", 0.95, 6.55, 9.44),
                  new Monolit("1241", 0.734, 8.64, 12.65),
                  new Monolit("1241", 0.687, 9.32, 14.15),
                  new Monolit("1241", 0.643, 11.02, 16.32),
            };
        }        
        //  Метод для записи данных в файл
        static void WritrToFile(StringBuilder stringBuilder)
        {
            using (StreamWriter writer = new StreamWriter("Result2.txt"))
            {
                writer.Write(stringBuilder);
            }
        }

        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите команду");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":      // ветка создания монолита      
                        TestAddMonolits();
                        Console.WriteLine();
                        break;

                    case "2":       // ветка для распечатки занесенных монолитов                        
                        Console.WriteLine();                                            
                        Console.WriteLine(PrintTable.PrintData(list));
                        Console.WriteLine();
                        break;

                    case "3":       // ветка для расчета занесенных монолитов                        
                        Calculate.CalcResult(list);
                        Console.WriteLine(PrintTable.PrintData(list));
                        break;

                    case "4":   // ветка для сохранения данных в файл
                        WritrToFile(PrintTable.PrintData(list));
                        break;

                    case "q":   // ветка для завершения работы приложения
                        flag = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong command");
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
