using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Helpers
{
    public static class Restrictions
    {
        public const int FloorL1 = 2;
        public const int FloorL2 = 3;
        public const int FloorL3 = 5;
        public const int FloorL4 = 10;
        public const int CeilL1 = 10;
        public const int CeilL2 = 25;
        public const int CeilL3 = 50;
        public const int CeilL4 = 100;
        public const int FloorDNI = 1000000;
        public const int CeilDNI = 99999999;
        public const long FloorCUIL = 20000000000;
        public const long CeilCUIL = 30999999999;
        public const int FloorVehiculoAnio = 1900;
        public const int CeilVehiculoAnio = 2099;
        public const string RolesLevel2 = "Empleado,Administrador";
    }
}
