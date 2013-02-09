using System;
namespace Datos.CC
{
    public interface IIndicadorDAO
    {
        void Agregar(Entidades.CC.IndicadorE indicador, int idContrato);
        System.Collections.Generic.List<Entidades.CC.IndicadorE> ObteneIndicadores();
    }
}
