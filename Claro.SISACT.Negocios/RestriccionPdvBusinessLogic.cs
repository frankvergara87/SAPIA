using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for RestriccionPdvBusinessLogic.
	/// </summary>
	public class RestriccionPdvBusinessLogic
	{
		public RestriccionPdvBusinessLogic()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public DataTable fdtbListarTipoOficina()
		{
			return new RestriccionPdvDataAccess().fdtbListarTipoOficina();// obj.fdtbListarTipoOficina();
		}

		public ArrayList ListarPDV(string strCanales,string strCodigo,string strDescripcion)
		{
			return new RestriccionPdvDataAccess().ListarPDV(strCanales,strCodigo,strDescripcion);
		}

	}
}
