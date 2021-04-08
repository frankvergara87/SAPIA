using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LCampana3Play
	{
		public LCampana3Play(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DCampana3Play obj = new DCampana3Play();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbTraer(string pstrCodigo)
		{
			DCampana3Play obj = new DCampana3Play();
			return obj.fdtbTraer(pstrCodigo);	
		}

		public DataTable fdtbListarCampanaPV(string pstrCodigo)
		{
			DCampana3Play obj = new DCampana3Play();
			return obj.fdtbListarCampanaPV(pstrCodigo);
		}

		public DataTable fdtbListarPVSinCampana(string pstrCodigo)
		{
			DCampana3Play obj = new DCampana3Play();
			return obj.fdtbListarPVSinCampana(pstrCodigo);
		}

		public DataTable fdtbListarCampanaPlan(string pstrCodigo)
		{
			DCampana3Play obj = new DCampana3Play();
			return obj.fdtbListarCampanaPlan(pstrCodigo);
		}

		public DataTable fdtbListarPlanSinCampana(string pstrCodigo)
		{
			DCampana3Play obj = new DCampana3Play();
			return obj.fdtbListarPlanSinCampana(pstrCodigo);
		}
		# endregion

		# region "Transacciones"

		public bool fbooInsertar(string pstrDescripcion, string pstrPromocion, string pstrEstado, string pstrUsuario, 
			DateTime pdtmFechaInicio, DateTime pdtmFechaFin, ref string pstrCodigo, ref string rMsg,
			string pstrPDVs, string pstrPlanes)
		{
			bool booResultado;

			DCampana3Play obj = new DCampana3Play();
			booResultado = obj.fbooInsertar(pstrDescripcion, pstrPromocion, pstrEstado, pstrUsuario, pdtmFechaInicio, 
				pdtmFechaFin, ref pstrCodigo, ref rMsg);

			pActualizar(pstrCodigo, pstrUsuario, pstrPDVs, pstrPlanes);

			return booResultado;
		}

		public bool fbooEliminar(string pstrCodigo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DCampana3Play obj = new DCampana3Play();
			return obj.fbooEliminar(pstrCodigo, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrPromocion,string pstrTipoProd, string pstrEstado, string pstrUsuario, 
			DateTime pdtmFechaInicio, DateTime pdtmFechaFin, ref string sEstado, ref string rMsg,
			string pstrPDVs, string pstrPlanes)
		{
			bool booResultado;

			DCampana3Play obj = new DCampana3Play();
			booResultado = obj.fbooModificar(pstrCodigo, pstrDescripcion, pstrPromocion,pstrTipoProd, pstrEstado, pstrUsuario, pdtmFechaInicio, 
				pdtmFechaFin, ref sEstado, ref rMsg);

			pActualizar(pstrCodigo, pstrUsuario, pstrPDVs, pstrPlanes);

			return booResultado;
		}

		private void pActualizar(string pstrCodigo, string pstrUsuario, string pstrPDVs, string pstrPlanes)
		{
			string curSalida = string.Empty ;
			string Msg = string.Empty;

			DCampana3Play obj = new DCampana3Play();
			obj.fbooCampanaPVPLInsertar(pstrCodigo, pstrUsuario, pstrPDVs, pstrPlanes, ref curSalida, ref Msg);
		}

		# endregion
	}
}