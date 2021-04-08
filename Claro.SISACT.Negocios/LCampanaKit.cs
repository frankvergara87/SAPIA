using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LCampanaKit
	{
		public LCampanaKit(){}

		# region "Consultas"

		public DataTable fdtbListarCampana()
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fdtbListarCampana();
		}

		public DataTable fdtbListarKit()
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fdtbListarKit();
		}

		public DataTable fdtbListarPlazo()
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fdtbListarPlazo();
		}

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbTraer(string pstrCodigo)
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fdtbTraer(pstrCodigo);	
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(string pstrCampanaCodigo, string pstrKitCodigo, string pstrPlazoCodigo, string pstrPrecio, string pstrInstal,string cf_alquiler_kit, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fbooInsertar(pstrCampanaCodigo, pstrKitCodigo, pstrPlazoCodigo, pstrPrecio, pstrInstal,cf_alquiler_kit, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooEliminar(string pstrCodigo, ref string sEstado, ref string rMsg)
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fbooEliminar(pstrCodigo, ref sEstado, ref rMsg);
		}

		public bool fbooModificar(string pstrCodigo, string pstrPrecio, string pstrInstal,string cf_alquiler_kit, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DCampanaKit obj = new DCampanaKit();
			return obj.fbooModificar(pstrCodigo, pstrPrecio, pstrInstal,cf_alquiler_kit, pstrUsuario, ref sEstado, ref rMsg);
		}

		# endregion
	}
}
