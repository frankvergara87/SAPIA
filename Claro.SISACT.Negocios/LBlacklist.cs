using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LBlacklist
	{
		public LBlacklist(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrTipoDocumento, string pstrNroDocumento, string pstrNroDocumentoRRLL, string pstrFechaInicio, string pstrFechaFin, int pintTipoEmpresa)
		{
			DBlacklist obj = new DBlacklist();
			return obj.fdtbListarBusqueda(pstrTipoDocumento, pstrNroDocumento, pstrNroDocumentoRRLL, pstrFechaInicio, pstrFechaFin, pintTipoEmpresa);
		}

		public Whitelist fwhlTraer(string pstrTipoDocumento, string pstrNroDocumento)
		{
			DBlacklist obj = new DBlacklist();
			return obj.fwhlTraer(pstrTipoDocumento, pstrNroDocumento);
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DBlacklist obj = new DBlacklist();
			return obj.fbooInsertar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooModificar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DBlacklist obj = new DBlacklist();
			return obj.fbooModificar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooEliminarSeleccionados(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			DBlacklist obj = new DBlacklist();
			return obj.fbooEliminarSeleccionados(strSeleccionados, ref pstrEstado, ref pstrMsg);
		}

		# endregion
	}
}
