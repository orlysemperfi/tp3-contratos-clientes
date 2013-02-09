using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.CC;

namespace Negocio.CC
{
    public interface IOventaBL
    {
        List<OventaE> Oventa_Lista(string razon_social, string ruc);
    }
}
