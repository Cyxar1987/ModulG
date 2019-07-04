using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulGeo
{
    class Calculate
    {
        static double[] eForMk = { 0.55, 0.65, 0.75, 0.85, 0.95, 1.05 };

        static double[] mkForSupec = { 4, 3.5, 3, 2, 2, 2 };
        static double[] mkForSuglinok = { 5, 4.5, 4, 3, 2.5, 2 };
        static double[] mkForGlina = { 6, 6, 6, 5.5, 5, 4.5 };

        public static void CalcResult(List<Monolit> monolits)
        {
            if (monolits != null)
            {
                foreach (var m in monolits)
                {
                    CalcMk(m);
                    CalcModul(m);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В списке отсутствуют монолиты!");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        static private void CalcMk (Monolit m)
        {
            double deltaE;
            double deltaKM;
            double[] useArray;  // Массив который будет использоваться в зависимости от типа грунта
            double result;

            switch (m.gruntName)
            {
                case GruntName.Supec:
                    useArray = mkForSupec;
                    break;
                case GruntName.Suglinok:
                    useArray = mkForSuglinok;
                    break;
                case GruntName.Glina:
                    useArray = mkForGlina;
                    break;
                default:
                    useArray = mkForSupec;
                    break;
            }

            for (int i = 0; i < eForMk.Length; i++)
            {
                deltaE = Math.Round(m.E - eForMk[i], 3);
                if (deltaE > 0 && deltaE < 0.1)
                {
                    deltaKM = useArray[i] - useArray[i + 1];
                    result = useArray[i] - ((deltaKM * deltaE) / 0.1);
                    m.KM = Math.Round(result, 3);                    
                    break;
                }
                else if (deltaE == 0)
                {
                    m.KM = useArray[i];                    
                    break;
                }
                else if (i == 0 && deltaE < 0)
                {
                    m.KM = useArray[i];
                }
                else if (i == eForMk.Length - 1 && deltaE > 0.1)
                {
                    m.KM = useArray[i];
                }
            }
        }
        static private void CalcModul(Monolit m)
        {
            m.LabModulNature_kM = Math.Round(m.KM * m.LabModulNature, 1);
            m.LabModulWarter_kM = Math.Round(m.KM * m.LabModuleWarter, 1);
        }
    }
}
