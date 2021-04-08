using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LWhiLstCasoEspecial
	{
		public LWhiLstCasoEspecial(){}

		# region "Consultas"

		public ArrayList ListarCasoEspecial()
		{
			DWhiLstCasoEspecial obj = new DWhiLstCasoEspecial();
			return obj.ListarCasoEspecial();
		}

		public DataTable fdtbListarBusqueda(string pstrCasoEspecial, string pstrTipoDocumento, string pstrNroDocumento, string pstrVigenciaInicio, string pstrVigenciaFin, string pstrFechaInicio, string pstrFechaFin)
		{
			DWhiLstCasoEspecial obj = new DWhiLstCasoEspecial();
			//return obj.fdtbListarBusqueda(pstrCasoEspecial, pstrTipoDocumento, pstrNroDocumento, pstrVigenciaInicio, pstrVigenciaFin, pstrFechaInicio, pstrFechaFin);
			return obj.fdtbListarBusqueda(pstrCasoEspecial,pstrTipoDocumento,pstrNroDocumento,pstrVigenciaInicio,pstrVigenciaFin,pstrFechaInicio,pstrFechaFin);
		}

		public Whitelist fwhlTraer(Int64 pintSecuencia)
		{
			DWhiLstCasoEspecial obj = new DWhiLstCasoEspecial();
			return obj.fwhlTraer(pintSecuencia);
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DWhiLstCasoEspecial obj = new DWhiLstCasoEspecial();
			return obj.fbooInsertar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooModificar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DWhiLstCasoEspecial obj = new DWhiLstCasoEspecial();
			return obj.fbooModificar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooEliminarSeleccionados(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			DWhiLstCasoEspecial obj = new DWhiLstCasoEspecial();
			return obj.fbooEliminarSeleccionados(strSeleccionados, ref pstrEstado, ref pstrMsg);
		}

		# endregion
	}
}
