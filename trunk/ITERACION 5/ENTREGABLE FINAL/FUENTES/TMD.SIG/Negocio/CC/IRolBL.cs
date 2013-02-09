using System;
namespace Negocio.CC
{
    public interface IRolBL
    {
        void insertar(Entidades.CC.RolE rol, int idContrato);
        System.Collections.Generic.List<Entidades.CC.RolE> ObteneRoles();
    }
}
