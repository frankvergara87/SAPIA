using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for MantMaestroNegocio.
	/// </summary>
	public class MantMaestroNegocio
	{
		public MantMaestroNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ObtenerValorContingenciaDC(int codParametro)
		{
			MantMaestroDatos obj = new MantMaestroDatos();
			return obj.ObtenerValorContingenciaDC(codParametro);
		}

		public ArrayList ListaTablaGeneralSISACT(string codigo,string estado)////SE REPLICO METODO DE MAESTRO DATOS SE CAMBIO LA CLACE ITEM
		{
			MantMaestroDatos obj = new MantMaestroDatos();
			return obj.ListaTablaGeneralSISACT(codigo,estado);
		}
	}
}
