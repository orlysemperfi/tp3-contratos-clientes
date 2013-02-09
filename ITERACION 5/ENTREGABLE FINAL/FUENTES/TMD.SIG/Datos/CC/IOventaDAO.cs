using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.CC;

namespace Datos.CC
{
    public interface IOventaDAO
    {
        List<OventaE> Oventa_Lista(string razon_social, string ruc);
    }
}
