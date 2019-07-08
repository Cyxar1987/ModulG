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
        static Monolit mon;
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
            using (StreamWriter writer = new StreamWriter("Result3.txt"))
            {
                writer.Write(stringBuilder);
            }
        }

        //  Метод для заполнения полей монолита
        static Monolit CreateMonolit()
        {
            mon = new Monolit();
            double res;

            Console.WriteLine("Введите номер скважины");
            mon.MineName = Console.ReadLine();
            Console.WriteLine();
        Label_E:
            Console.WriteLine("Введите коэффициент пористости");
            if (Double.TryParse(Console.ReadLine(), out res))
            {
                mon.E = res;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Некорректный ввовд! Повторите еще раз");
                goto Label_E;
            }

        Label_LabNat:
            Console.WriteLine("Введите лабораторный модуль в естественном состоянии");
            if (Double.TryParse(Console.ReadLine(), out res))
            {
                mon.LabModulNature = res;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Некорректный ввовд! Повторите еще раз");
                goto Label_LabNat;
            }

        Label_LabWat:
            Console.WriteLine("Введите лабораторный модуль в водонасыщеном состоянии");
            if (Double.TryParse(Console.ReadLine(), out res))
            {
                mon.LabModuleWarter = res;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Некорректный ввовд! Повторите еще раз");
                goto Label_LabWat;
            }            
            Console.WriteLine();
                return mon;
        }
        //  Метод для редактирования указанного монолита
        static void EditMonolit(int index)
        {
            if (list != null)
            {
                if (index > 0 && index <= list.Count)
                {
                    index--;
                    list[index] = CreateMonolit();
                }
                else
                {
                    Console.WriteLine("Монолит с таким номером отсутствует");
                }
            }
            else
            {
                Console.WriteLine("Список монолитов пуст");
            }
        }



        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            list = new List<Monolit>();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите команду");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":      // ветка создания монолита
                        Console.WriteLine();
                        list.Add(CreateMonolit());                        
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

                    case "5":   // ветка для редактирования монолита
                        int a = Int32.Parse(Console.ReadLine());
                        EditMonolit(a);
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
