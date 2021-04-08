using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LTipoClientePlan
	{
		public LTipoClientePlan(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbTraer(string pstrCodigo)
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbTraer(pstrCodigo);	
		}

		public DataTable fdtbListarTipoCliente()
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbListarTipoCliente();	
		}

		public DataTable fdtbListarPlanxTipoCliente(string pstrTipoClienteCodigo)
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbListarPlanxTipoCliente(pstrTipoClienteCodigo);	
		}

		public DataTable fdtbListarTipoVenta()
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbListarTipoVenta();	
		}

		public DataTable fdtbListarControlConsumo()
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbListarControlConsumo();	
		}
		public DataTable fdtbListarTopConsumo()
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbListarTopConsumo();	
		}

		public DataTable fdtbListarConsumoEstado(string pstrPlanCodigo)
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fdtbListarConsumoEstado(pstrPlanCodigo);	
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(string pstrPlan, string pstrTipoCliente, string pstrTipoVenta, string pstrTipoDocumento, 
								 string pstrEstado, DataTable pdtbConsumoEstado, string pstrUsuario, string strPDVs, ref string sEstado, ref string rMsg)
		{
			bool booResultado;

			DTipoClientePlan obj = new DTipoClientePlan();

			booResultado = obj.fbooInsertar(pstrPlan, pstrTipoCliente, pstrTipoVenta, pstrTipoDocumento, pstrEstado, ref sEstado, ref rMsg);

			DRestriccionPDV objPDV = new DRestriccionPDV();
			objPDV.pInsertar(pstrPlan, strPDVs, ref rMsg);

			obj = new DTipoClientePlan();
			obj.fbooEliminarConsumo(pstrPlan, ref sEstado, ref rMsg);

			foreach (DataRow dr in pdtbConsumoEstado.Rows)
			{
				obj = new DTipoClientePlan();
				obj.fbooInsertarConsumo(pstrPlan, dr["codigo"].ToString(), dr["valor"].ToString(), pstrUsuario, ref sEstado, ref rMsg);
			}

			return booResultado;
		}

		public bool fbooEliminar(string pstrCodigo, ref string sEstado, ref string rMsg)
		{
			DTipoClientePlan obj = new DTipoClientePlan();
			return obj.fbooEliminar(pstrCodigo, ref sEstado, ref rMsg);
		}

		public bool fbooModificar(string pstrCodigo, string pstrPlan, string pstrTipoCliente, string pstrTipoVenta, string pstrTipoDocumento, 
								  string pstrEstado, DataTable pdtbConsumoEstado, string pstrUsuario, string strPDVs, ref string sEstado, ref string rMsg)
		{
			bool booResultado;

			DTipoClientePlan obj = new DTipoClientePlan();
			booResultado = obj.fbooModificar(pstrCodigo, pstrPlan, pstrTipoCliente, pstrTipoVenta, pstrTipoDocumento, pstrEstado, ref sEstado, ref rMsg);

			DRestriccionPDV objPDV = new DRestriccionPDV();
			objPDV.pInsertar(pstrPlan, strPDVs, ref rMsg);

			obj = new DTipoClientePlan();
			obj.fbooEliminarConsumo(pstrPlan, ref sEstado, ref rMsg);

			foreach (DataRow dr in pdtbConsumoEstado.Rows)
			{
				obj = new DTipoClientePlan();
				obj.fbooInsertarConsumo(pstrPlan, dr["codigo"].ToString(), dr["valor"].ToString(), pstrUsuario, ref sEstado, ref rMsg);
			}

			return booResultado;
		}

		# endregion
	}
}
