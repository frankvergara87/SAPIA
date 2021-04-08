using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LConfiguracionPlan
	{
		public LConfiguracionPlan(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbListarProducto(string pstrPlanCodigo)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fdtbListarProducto(pstrPlanCodigo);
		}

		public DataTable fdtbListarPlazo(string pstrPlanCodigo)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fdtbListarPlazo(pstrPlanCodigo);
		}

		public DataTable fdtbListarServicio(string pstrPlanCodigo)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fdtbListarServicio(pstrPlanCodigo);
		}

		public DataTable fdtbTraer(string pstrPlanCodigo)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fdtbTraer(pstrPlanCodigo);
		}
//gaa20131010
		public DataTable fdtbListarKitAsociado(string pstrPlanCodigo)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fdtbListarKitAsociado(pstrPlanCodigo);
		}

		public DataTable fdtbListarKitDisponible(string pstrPlanCodigo)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fdtbListarKitDisponible(pstrPlanCodigo);
		}
//fin gaa20131010
		# endregion

		# region "Transacciones"

		public bool fbooPlanInsertar(string pstrDescripcion, string pstrEstado, string pstrTipoProducto, string pstrCargoFijo, string pstrUsuario, ref string sEstado, ref string rMsg, DataTable dtbPlazo, DataTable dtbServicio, string pstrKits)
		{
			bool booResultado;

			DConfiguracionPlan obj = new DConfiguracionPlan();
			booResultado = obj.fbooPlanInsertar(pstrDescripcion, pstrEstado, pstrTipoProducto, pstrCargoFijo, pstrUsuario, ref sEstado, ref rMsg);
			
			pPlanActualizar(sEstado, pstrUsuario, dtbPlazo, dtbServicio);
			
			booResultado = fbooPlanKitInsertar(sEstado, pstrUsuario, pstrKits, ref sEstado, ref rMsg);
			
			return booResultado;
		}

		public bool fbooPlanEliminar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fbooPlanEliminar(pstrCodigo, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooPlanModificar(string pstrCodigo, string pstrDescripcion, string pstrEstado, string pstrTipoProducto, string pstrCargoFijo, string pstrUsuario, ref string sEstado, ref string rMsg, DataTable dtbPlazo, DataTable dtbServicio, string pstrKits)
		{
			bool booResultado;

			DConfiguracionPlan obj = new DConfiguracionPlan();
			obj.fbooPlanModificar(pstrCodigo, pstrDescripcion, pstrEstado, pstrTipoProducto, pstrCargoFijo, pstrUsuario, ref sEstado, ref rMsg);

			pPlanActualizar(sEstado, pstrUsuario, dtbPlazo, dtbServicio);
			
			booResultado = fbooPlanKitInsertar(pstrCodigo, pstrUsuario, pstrKits, ref sEstado, ref rMsg);
			
			return booResultado;
		}

		private void pPlanActualizar(string pstrPlanCodigo, string pstrUsuario, DataTable dtbPlazo, DataTable dtbServicio)
		{
			int curSalida = 0;
			string Msg = string.Empty;
			//bool resultado = false;
			DConfiguracionPlan obj;

			//Elimina en tabla de planes-plazo
			obj = new DConfiguracionPlan();
			obj.fbooPlanPlazoEliminar(pstrPlanCodigo, ref curSalida, ref Msg);
			//Elimina en tabla de planes-servicios
			obj = new DConfiguracionPlan();
			obj.fbooPlanServicioEliminar(pstrPlanCodigo, ref curSalida, ref Msg);
			//Inserta en tabla de planes-plazo
			foreach (DataRow drw in dtbPlazo.Rows)
			{
				obj = new DConfiguracionPlan();
				obj.fbooPlanPlazoInsertar(pstrPlanCodigo, Convert.ToString(drw["PLAZACODIGO"]), pstrUsuario, ref curSalida, ref Msg);
			}
			//Inserta en tabla de planes-servicios
			foreach (DataRow drw in dtbServicio.Rows)
			{
				obj = new DConfiguracionPlan();
				obj.fbooPlanServicioInsertar(pstrPlanCodigo, Convert.ToString(drw["SERVICIOCODIGO"]), pstrUsuario,
					Convert.ToString(drw["CARGO"]), Convert.ToString(drw["SELECCIONABLE"]), ref curSalida, ref Msg);
			}
		}
//gaa20131011
		public bool fbooPlanKitInsertar(string pstrPlan, string pstrUsuario, 
			string pstrKits, ref string sEstado, ref string rMsg)
		{
			DConfiguracionPlan obj = new DConfiguracionPlan();
			return obj.fbooPlanKitInsertar(pstrPlan, pstrUsuario, pstrKits, ref sEstado, ref rMsg);
		}
//fin gaa20131011
		# endregion
	}
}
