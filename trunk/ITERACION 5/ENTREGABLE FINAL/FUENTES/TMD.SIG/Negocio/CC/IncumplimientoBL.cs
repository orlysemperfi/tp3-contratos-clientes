using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.CC;
using Datos.CC;

namespace Negocio.CC
{
    public class IncumplimientoBL : Negocio.CC.IIncumplimientoBL
    {
        private IIncumplimientoDAO incumplimientoDAO = new IncumplimientoDAO();

        public void insertar(IncumplimientoE incumplimiento)
        {
            incumplimientoDAO.Insertar(incumplimiento);
        }
    }
}
