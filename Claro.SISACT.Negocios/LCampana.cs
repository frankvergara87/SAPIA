using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LCampana
	{
		public LCampana(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DCampana obj = new DCampana();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbTraer(string pstrCodigo)
		{
			DCampana obj = new DCampana();
			return obj.fdtbTraer(pstrCodigo);	
		}

		public DataTable fdtbListarCampanaPV(string pstrCodigo)
		{
			DCampana obj = new DCampana();
			return obj.fdtbListarCampanaPV(pstrCodigo);
		}

		public DataTable fdtbListarPVSinCampana(string pstrCodigo)
		{
			DCampana obj = new DCampana();
			return obj.fdtbListarPVSinCampana(pstrCodigo);
		}

		public DataTable fdtbListarCampanaPlan(string pstrCodigo)
		{
			DCampana obj = new DCampana();
			return obj.fdtbListarCampanaPlan(pstrCodigo);
		}

		public DataTable fdtbListarPlanSinCampana(string pstrCodigo)
		{
			DCampana obj = new DCampana();
			return obj.fdtbListarPlanSinCampana(pstrCodigo);
		}

		public DataTable fdtbListarCampanaKit(string pstrCodigo)
		{
			DCampana obj = new DCampana();
			return obj.fdtbListarCampanaKit(pstrCodigo);
		}

		public DataTable fdtbListarKitSinCampana(string pstrCodigo)
		{
			DCampana obj = new DCampana();
			return obj.fdtbListarKitSinCampana(pstrCodigo);
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(string pstrCodigo, string pstrDescripcion, string pstrPromocion,string pstrTipoProd, string pstrEstado, string pstrUsuario, 
			DateTime pdtmFechaInicio, DateTime pdtmFechaFin, string CFPromocional,string fechaIniProm,string fechaFinProm, ref string sEstado, ref string rMsg,
			string pstrPDVs, string pstrPlanes)
		{
			bool booResultado;

			DCampana obj = new DCampana();
			booResultado = obj.fbooInsertar(pstrCodigo, pstrDescripcion,pstrPromocion,pstrTipoProd, pstrEstado, pstrUsuario, pdtmFechaInicio, 
				pdtmFechaFin,CFPromocional,fechaIniProm,fechaFinProm, ref sEstado, ref rMsg);

			pActualizar(sEstado, pstrUsuario, pstrPDVs, pstrPlanes);

			return booResultado;
		}

		public bool fbooEliminar(string pstrCodigo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DCampana obj = new DCampana();
			return obj.fbooEliminar(pstrCodigo, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrPromocion,string pstrTipoProd, string pstrEstado, string pstrUsuario, 
			DateTime pdtmFechaInicio, DateTime pdtmFechaFin,string CFPromocional,string fechaIniProm,string fechaFinProm, ref string sEstado, ref string rMsg,
			string pstrPDVs, string pstrPlanes)
		{
			bool booResultado;

			DCampana obj = new DCampana();
			booResultado = obj.fbooModificar(pstrCodigo, pstrDescripcion, pstrPromocion,pstrTipoProd, pstrEstado, pstrUsuario, pdtmFechaInicio, 
				pdtmFechaFin, CFPromocional,fechaIniProm,fechaFinProm,ref sEstado, ref rMsg);

			pActualizar(sEstado, pstrUsuario, pstrPDVs, pstrPlanes);

			return booResultado;
		}

		private void pActualizar(string pstrCodigo, string pstrUsuario, string pstrPDVs, string pstrPlanes)
		{
			string curSalida = string.Empty ;
			string Msg = string.Empty;

			DCampana obj = new DCampana();
			obj.fbooCampanaPVPLInsertar(pstrCodigo, 
				pstrUsuario, pstrPDVs, pstrPlanes, ref curSalida, ref Msg);
		}

		# endregion
	}
}