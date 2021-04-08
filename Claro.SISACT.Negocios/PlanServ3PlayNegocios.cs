using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for PlanServ3PlayNegocios.
	/// </summary>
	public class PlanServ3PlayNegocios
	{
		public PlanServ3PlayNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public bool InsertarPlanServ3Play(PlanServ3Play oPlanServ3Play)
		{			
			PlanServ3PlayDatos oPlanServ3PlayDatos = new PlanServ3PlayDatos();
			return  oPlanServ3PlayDatos.InsertarPlanServ3Play(oPlanServ3Play);
		}

		public DataTable ListarPlanServ3Play(string P_PLNV_CODIGO)
		{
			PlanServ3PlayDatos oPlanServ3PlayDatos = new PlanServ3PlayDatos();
			return  oPlanServ3PlayDatos.ListarPlanServ3Play(P_PLNV_CODIGO);
		}

		public bool EliminarPlanServ3Play(string P_PLNV_CODIGO)
		{
			PlanServ3PlayDatos oPlanServ3PlayDatos = new PlanServ3PlayDatos();
			return  oPlanServ3PlayDatos.EliminarPlanServ3Play(P_PLNV_CODIGO);
		}
//gaa20130724
		public DataTable ListarEquipoxNoPlan(string pstrProductoCodigo, string pstrPlanCodigo)
		{
			PlanServ3PlayDatos oPlanServ3PlayDatos = new PlanServ3PlayDatos();
			return oPlanServ3PlayDatos.ListarEquipoxNoPlan(pstrProductoCodigo, pstrPlanCodigo);
		}

		public DataTable ListarEquipoxPlan(string pstrProductoCodigo, string pstrPlanCodigo)
		{
			PlanServ3PlayDatos oPlanServ3PlayDatos = new PlanServ3PlayDatos();
			return oPlanServ3PlayDatos.ListarEquipoxPlan(pstrProductoCodigo, pstrPlanCodigo);
		}

		public bool InsertarPlanEqui3Play(PlanServ3Play oPlanServ3Play)
		{
			PlanServ3PlayDatos oPlanServ3PlayDatos = new PlanServ3PlayDatos();
			return oPlanServ3PlayDatos.InsertarPlanEqui3Play(oPlanServ3Play);
		}
//fin gaa20130724
//gaa20131104
		public DataTable ListarPlanServicioBSCS(string pstrPlanCodigo)
		{
			PlanServ3PlayDatos oPlanServ3PlayDatos = new PlanServ3PlayDatos();
			return oPlanServ3PlayDatos.ListarPlanServicioBSCS(pstrPlanCodigo);
		}
//fin gaa20131104
	}
}
