using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LRestriccionPDV
	{
		public LRestriccionPDV(){}

		# region "Consultas"

		public DataTable fdtbListarTipoOficina()
		{
			DRestriccionPDV obj = new DRestriccionPDV();
			return obj.fdtbListarTipoOficina();
		}

		public DataTable fdtbListarPDVTotal(string pstrCanales, string pstrCodigo, string pstrDescripcion)
		{
			DRestriccionPDV obj = new DRestriccionPDV();
			return obj.fdtbListarPDVTotal(pstrCanales, pstrCodigo, pstrDescripcion);
		}

		public DataTable fdtbListarPDV(string pstrPlanCodigo, string pstrPDVs)
		{
			DRestriccionPDV obj = new DRestriccionPDV();
			return obj.fdtbListarPDV(pstrPlanCodigo, pstrPDVs);
		}

		# endregion

		# region "Transacciones"

		public void pInsertar(string pstrPlanCodigo, string strPDVs, ref string rMsg)
		{
			DRestriccionPDV obj = new DRestriccionPDV();
			obj.pInsertar(pstrPlanCodigo, strPDVs, ref rMsg);
		}

		# endregion
	}
}
