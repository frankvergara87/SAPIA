using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Plan3PlayNegocios.
	/// </summary>
	public class Plan3PlayNegocios
	{
		public Plan3PlayNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool InsertarPlan3Play(Plan3Play oPlan3Play, ref string sCodigoPlan, ref string rMsg)
		{			
			Plan3PlayDatos oPlan3PlayDatos = new Plan3PlayDatos();
			return  oPlan3PlayDatos.InsertarPlan3Play(oPlan3Play, ref sCodigoPlan, ref rMsg);
		}

		public bool ActualizarPlan3Play(Plan3Play oPlan3Play)
		{			
			Plan3PlayDatos oPlan3PlayDatos = new Plan3PlayDatos();
			return  oPlan3PlayDatos.ActualizarPlan3Play(oPlan3Play);
		}

		public bool EliminarPlan3Play(Plan3Play oPlan3Play)
		{			
			Plan3PlayDatos oPlan3PlayDatos = new Plan3PlayDatos();
			return  oPlan3PlayDatos.EliminarPlan3Play(oPlan3Play);
		}

		public ArrayList ListarPlan3Play(string P_PLNV_CODIGO, string P_PLNV_DESCRIPCION, string P_PLNC_ESTADO)
		{
			Plan3PlayDatos oPlan3PlayDatos = new Plan3PlayDatos();
			return  oPlan3PlayDatos.ListarPlan3Play(P_PLNV_CODIGO,P_PLNV_DESCRIPCION,P_PLNC_ESTADO);
		}

		public DataTable ListarPlan3PlayTabla(string P_PLNV_CODIGO, string P_PLNV_DESCRIPCION, string P_PLNC_ESTADO)
		{
			Plan3PlayDatos oPlan3PlayDatos = new Plan3PlayDatos();
			return  oPlan3PlayDatos.ListarPlan3PlayTabla(P_PLNV_CODIGO,P_PLNV_DESCRIPCION,P_PLNC_ESTADO);
		}
//ldrz
		public DataTable ListarPlanPaquete3Play(string P_PRDC,string P_PLNV_CODIGO)
		{
			Plan3PlayDatos oPlan3PlayDatos = new Plan3PlayDatos();
			return  oPlan3PlayDatos.ListarPlanPaquete3Play(P_PRDC,P_PLNV_CODIGO);
		}

		public bool MantenimientoPlan3Play(string strAccion, Plan3Play oPlan)
		{
			return new Plan3PlayDatos().MantenimientoPlan3Play(strAccion, oPlan);
		}
	}
}
