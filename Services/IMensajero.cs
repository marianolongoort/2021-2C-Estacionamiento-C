using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Services
{
    public interface IMensajero
    {
        void EnviarMensaje(string msg);
    }
}
