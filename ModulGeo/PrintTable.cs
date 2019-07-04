using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulGeo
{
    //char horizontalBorder = '\u2500';
    //char verticalBorder = '\u2502';
    //char upAndLeftBorder = '\u2518';
    //char upAndRightBroder = '\u2514';
    //char downAndLeftBorder = '\u2510';
    //char downAndRightBroder = '\u250C';
    //char lineAndDown = '\u252C';
    //char lineandUp = '\u2534';

    class PrintTable
    {
        private const char horizontalBorder = '\u2500';
        private const char verticalBorder = '\u2502';
        private const char upAndLeftBorder = '\u2518';
        private const char upAndRightBroder = '\u2514';
        private const char downAndLeftBorder = '\u2510';
        private const char downAndRightBroder = '\u250C';
        private const char lineAndDown = '\u252C';
        private const char lineandUp = '\u2534';
        private const char upDownAndRight = '\u251C';
        private const char upDownAndLeft = '\u2524';
        private const char cross = '\u253C';

        // Массив символов для печати верхней границы
        private static char[] upBorderChar = { downAndRightBroder, horizontalBorder, lineAndDown, downAndLeftBorder };
        // Массив символов для печати средней границы
        private static char[] middleBorderChar = { upDownAndRight, horizontalBorder, cross, upDownAndLeft };
        // Массив символов для печати нижней границы
        private static char[] downBorderChar = { upAndRightBroder, horizontalBorder, lineandUp, upAndLeftBorder };

        // Ширина столбцов для печати таблицы (ТОЛЬКО ЧЕТНОЕ ЦЕЛОЕ ЧИСЛО!!!)
        static int[] columWidth = { 8, 10, 12, 12, 8, 14, 14 };

        static string[] headersStartData = { "№", "коэф пор", "Модуль ест", "Модуль вод", "Km", "Модуль Km ест", "Модуль Km вод" };

        // Печать начальных данных (номер скв. | коэфф. пор. | Лаб мод ест | Лаб мод вод)
        public static StringBuilder PrintData(List<Monolit> monolits)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (monolits != null)
            {
                stringBuilder.Append(PrintBorder(upBorderChar));
                stringBuilder.Append(PrintHeaders());
                stringBuilder.Append(PrintBorder(middleBorderChar));

                foreach (Monolit m in monolits)
                {
                    int count = 0;
                    stringBuilder.Append(PrintField(m.MineName.ToString(), count++));
                    stringBuilder.Append(PrintField(m.E.ToString(), count++));
                    stringBuilder.Append(PrintField(m.LabModulNature.ToString(), count++));
                    stringBuilder.Append(PrintField(m.LabModuleWarter.ToString(), count++));
                    stringBuilder.Append(PrintField(m.KM.ToString(), count++));
                    stringBuilder.Append(PrintField(m.LabModulNature_kM.ToString(), count++));
                    stringBuilder.Append(PrintField(m.LabModulWarter_kM.ToString(), count++));
                    stringBuilder.AppendLine();
                }
                stringBuilder.Append(PrintBorder(downBorderChar));
            }
            else
            {
                stringBuilder.Append("Вы не внесли монолиты!");                     
            }                
            
            return stringBuilder;
        }

        public static StringBuilder PrintHeaders()
        {
            StringBuilder sb = new StringBuilder();
            // Печатаем заголовки в таблице
            int numberOfSpaces;
            sb.Append(verticalBorder);
            for (int i = 0; i < columWidth.Length; i++)
            {
                if (headersStartData[i].Length % 2 == 0) // Если количество сиволов в строке четное
                {
                    numberOfSpaces = columWidth[i] - headersStartData[i].Length;
                    sb.Append(new String(' ', numberOfSpaces / 2));
                    sb.Append(headersStartData[i]);
                    sb.Append(new String(' ', numberOfSpaces / 2) + verticalBorder);
                }
                else
                {
                    numberOfSpaces = columWidth[i] - headersStartData[i].Length;
                    sb.Append(new String(' ', numberOfSpaces / 2));
                    sb.Append(headersStartData[i]);
                    sb.Append(new String(' ', (numberOfSpaces / 2) + 1) + verticalBorder);
                }
            }
            sb.AppendLine();
            return sb;
        }

        private static string PrintField(string monolitField, int numbeColumm)
        {
            int countSpace;
            StringBuilder builder = new StringBuilder();
            builder.Append(verticalBorder);
            countSpace = columWidth[numbeColumm] - monolitField.Length;
            if (countSpace % 2 == 0)
            {
                builder.Append(new String(' ', countSpace / 2) + monolitField + new String(' ', countSpace / 2));
            }
            else
            {
                builder.Append(new String(' ', countSpace / 2) + monolitField + new String(' ', (countSpace / 2) + 1));
            }
            if (numbeColumm == columWidth.Length - 1)
            {
                builder.Append(verticalBorder);
            }
            return builder.ToString();
        }

        // Печать рамки таблицы по заданным сиволам
        private static StringBuilder PrintBorder(char[] simbol)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(simbol[0]);
            for (int i = 0; i < columWidth.Length; i++)
            {
                sb.Append(new String(simbol[1], columWidth[i]));
                if (i != columWidth.Length - 1)
                {
                    sb.Append(simbol[2]);
                }
            }
            sb.Append(simbol[3]);
            sb.AppendLine();
            return sb;
        }
    }
}
