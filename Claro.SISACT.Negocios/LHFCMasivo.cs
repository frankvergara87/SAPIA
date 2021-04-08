using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	public class LHFCMasivo
	{
		public LHFCMasivo()
		{			
		}

        public DataTable fdtbListarBusqueda(long intNroSot, string pstrFechaInicio, string pstrFechaFin)
        {
            SolicitudDatos obj1 = new SolicitudDatos();
            DHFCMasivo obj = new DHFCMasivo();
            DataTable dt = new DataTable(); 
            DataTable dt1 = new DataTable();
            String DesSot="";
            dt = obj.fdtbListarBusqueda(pstrFechaInicio,pstrFechaFin);
            
            for(int i= 0; i< dt.Rows.Count; i++){
                dt1= obj1.ConsultaEstadoSOT(Funciones.CheckInt64(dt.Rows[i]["CONTN_NUMERO_SOT"]));

                DesSot=  Funciones.CheckStr(dt1.Rows[0]["DESESTSOL"]);
                dt.Rows[i]["ESTADO_SOT"] =DesSot;

                if (Funciones.CheckInt64(dt1.Rows[0]["ESTSOL"])!=intNroSot && intNroSot!=0)
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }
            }

           return dt;
        }
	}
}
