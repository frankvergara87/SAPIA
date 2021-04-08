using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LEmpresaTop
	{
		public LEmpresaTop(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrTipoDocumento, string pstrNroDocumento, string pstrNombre, string pstrFechaInicio, string pstrFechaFin, int pintRankingInicio, int pintRankingFin)
		{
			DEmpresaTop obj = new DEmpresaTop();
			return obj.fdtbListarBusqueda(pstrTipoDocumento, pstrNroDocumento, pstrNombre, pstrFechaInicio, pstrFechaFin, pintRankingInicio, pintRankingFin);
		}

		public Whitelist fwhlTraer(string pstrTipoDocumento, string pstrNroDocumento)
		{
			DEmpresaTop obj = new DEmpresaTop();
			return obj.fwhlTraer(pstrTipoDocumento, pstrNroDocumento);
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DEmpresaTop obj = new DEmpresaTop();
			return obj.fbooInsertar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooModificar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DEmpresaTop obj = new DEmpresaTop();
			return obj.fbooModificar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooEliminarSeleccionados(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			DEmpresaTop obj = new DEmpresaTop();
			return obj.fbooEliminarSeleccionados(strSeleccionados, ref pstrEstado, ref pstrMsg);
		}

		# endregion
	}
}
