using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.CC
{
    public class ContratoE
    {
        private int CODIGO_CONTRATO;
        private string NUMERO_CONTRATO;
	    private string NUMERO_BUENA_PRO;
	    private string NUMERO_CARTA_FIANZA;
	    private DateTime FECHA_INICIO;
	    private DateTime FECHA_FIN;
	    private decimal MONTO;
	    private string DESCRIPCION;
	    private DateTime FECHA_TERMINO;
	    private string MOTIVO_TERMINO;
	    private int CODIGO_CLIENTE;
	    private int CODIGO_SERVICIO;
	    private string CODIGO_MONEDA;
	    private int CODIGO_EMPLEADO_APROB_LEGA;
	    private int CODIGO_EMPLEADO_APROB_COMERCIA;
	    private int CODIGO_EMPLEADO_TERM_COMERCIAL;
	    private int CODIGO_EMPLEADO_TERM_LEGAL;
	    private int CODIGO_EMPLEADO_ANUL_COMERCIAL;
	    private int CODIGO_EMPLEADO_ANUL_LEGAL;
	    private string ESTADO ;
	    private DateTime FECHA_REGISTRO;

        public void setCODIGO_CONTRATO(int _CODIGO_CONTRATO)
        {
            this.CODIGO_CONTRATO = _CODIGO_CONTRATO;
        }
        public int getCODIGO_CONTRATO()
        {
            return CODIGO_CONTRATO;
        }
    }
}
