﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades.CC;

namespace Datos.CC {

  public interface IServicioDAO {

    List<ServicioE> GetServicios();
    //ContratoE Find(int codigoContrato);
    //void Update(ContratoE o);
    
  }

}