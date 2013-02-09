using System;
namespace Negocio.Generico
{
    public interface IOrganizacionBL
    {
        void insertar(Entidades.GEN.OrganizacionE o);
        System.Collections.Generic.List<Entidades.GEN.OrganizacionE> listAll();
    }
}
