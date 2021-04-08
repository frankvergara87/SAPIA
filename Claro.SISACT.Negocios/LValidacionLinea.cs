using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Motivos de lineas desactivas.
	/// </summary>
	public class LValidacionLinea
	{
		public LValidacionLinea(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda()
		{
			DValidacionLinea obj = new DValidacionLinea();
			return obj.fdtbListarBusqueda();
		}

		# endregion

		# region "Transacciones"

		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrMotivo, string pstrRecomendacion, string pstrEstado, string pstrMesesDesac, string pstrMesesActiva, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DValidacionLinea obj = new DValidacionLinea();
			return obj.fbooModificar(pstrCodigo, pstrDescripcion, pstrMotivo, pstrRecomendacion, pstrEstado, pstrMesesDesac, pstrMesesActiva, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooDesactivar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
		{
			DValidacionLinea obj = new DValidacionLinea();
			return obj.fbooDesactivar(pstrCodigo, pstrUsuario, ref sEstado, ref rMsg);
		}

		# endregion
	}
}
