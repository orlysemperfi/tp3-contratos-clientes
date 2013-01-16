using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.CC;

namespace Datos.CC
{
    public interface IContratoDAO
    {
        List<ContratoE> GetContratos();
    }
}
