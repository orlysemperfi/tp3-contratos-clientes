using System;
namespace Datos.CC
{
    public interface IRolDAO
    {
        void Agregar(Entidades.CC.RolE rol, int idContrato);
        System.Collections.Generic.List<Entidades.CC.RolE> ObteneRoles();
    }
}
