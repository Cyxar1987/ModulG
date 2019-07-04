using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulGeo
{
    enum GruntName
    {
        Supec,
        Suglinok,
        Glina
    }

    class Monolit
    {
        string mineName;                // Номер скважины
        public GruntName gruntName;            // Наименование грунта
        double e;                       // коэффициент пористости
        double labModulNature;          // лабораторный модуль (естественный)
        double labModuleWarter;         // лабораторный модуль (водонасыщенный)
        double kM;                      // коэффициент кМ
        double labModulNature_kM;       // модуль (естественный) с учетом кМ
        double labModulWarter_kM;       // модуль (водонасыщенный) с учетом кМ

        public Monolit()
        {
            MineName = "1";
            gruntName = GruntName.Suglinok;
        }
        public Monolit(string mName, double e, double LabModulNat, double LabModulWart)
        {
            MineName = mName;
            gruntName = GruntName.Glina;
            E = e;
            LabModulNature = LabModulNat;
            LabModuleWarter = LabModulWart;            
        }

        public string MineName { get => mineName; set => mineName = value; }
        public double E { get => e; set => e = value; }
        public double LabModulNature { get => labModulNature; set => labModulNature = value; }
        public double LabModuleWarter { get => labModuleWarter; set => labModuleWarter = value; }
        public double KM { get => kM; set => kM = value; }
        public double LabModulNature_kM { get => labModulNature_kM; set => labModulNature_kM = value; }
        public double LabModulWarter_kM { get => labModulWarter_kM; set => labModulWarter_kM = value; }

        public override string ToString()
        {
            return String.Format("{0} {1:0.000} {2:00.00} {3:00.00} {4:0.000} {5:00.00} {6:00.00}",
                                  MineName, E, LabModulNature, LabModuleWarter, KM, LabModulNature_kM, LabModulWarter_kM);        
        }
    }
}
