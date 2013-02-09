using System;
namespace Datos.CC
{
    public interface IEntregableDAO
    {
        void Agregar(Entidades.CC.EntregableE entregable, int idContrato);
        System.Collections.Generic.List<Entidades.CC.EntregableE> ObteneEntregables();
    }
}
