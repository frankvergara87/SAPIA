using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for RestriccionCanalBusinessLogic.
	/// </summary>
	public class RestriccionCanalBusinessLogic
	{
		public RestriccionCanalBusinessLogic()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataTable fdtbListarTipoOficina()
		{
			//DRestriccionPDV obj = new DRestriccionPDV();
			return new RestriccionCanalDataAccess().fdtbListarTipoOficina();// obj.fdtbListarTipoOficina();
		}

		public ArrayList ListarCanal(string strCanales,string strCodigo,string strDescripcion)
		{
			return new RestriccionCanalDataAccess().ListarCanal(strCanales, strCodigo, strDescripcion);
		}

		//fdtbListarPDVTotal
		public DataTable fdtbListarPDVTotal(string strCanales,string strCodigo,string strDescripcion)
		{
			//DRestriccionPDV obj = new DRestriccionPDV();
			return new RestriccionCanalDataAccess().fdtbListarPDVTotal(strCanales, strCodigo, strDescripcion);// obj.fdtbListarTipoOficina();
		}
		//fdtbListarPDV
		public DataTable fdtbListarPDV(string strCodigo,string Pdv)
		{
			//DRestriccionPDV obj = new DRestriccionPDV();
			return new RestriccionCanalDataAccess().fdtbListarPDV(strCodigo, Pdv);// obj.fdtbListarTipoOficina();
		}
	}
}
