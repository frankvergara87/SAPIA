using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for PlanAcuerdo3PlayNegocios.
	/// </summary>
	public class PlanAcuerdo3PlayNegocios
	{
		public PlanAcuerdo3PlayNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public bool InsertarPlanAcuerdo3Play(PlanAcuerdo3Play oPlanAcuerdo3Play)
		{			
			PlanAcuerdo3PlayDatos oPlanAcuerdo3PlayDatos = new PlanAcuerdo3PlayDatos();
			return  oPlanAcuerdo3PlayDatos.InsertarPlanAcuerdo3Play(oPlanAcuerdo3Play);
		}

		public bool EliminarPlanAcuerdo3Play(PlanAcuerdo3Play oPlanAcuerdo3Play)
		{			
			PlanAcuerdo3PlayDatos oPlanAcuerdo3PlayDatos = new PlanAcuerdo3PlayDatos();
			return  oPlanAcuerdo3PlayDatos.EliminarPlanAcuerdo3Play(oPlanAcuerdo3Play);
		}

		public DataTable ListarPlanAcuerdo3Play(string P_PLNV_CODIGO)
		{
			PlanAcuerdo3PlayDatos oPlanAcuerdo3PlayDatos = new PlanAcuerdo3PlayDatos();
			return  oPlanAcuerdo3PlayDatos.ListarPlanAcuerdo3Play(P_PLNV_CODIGO);
		}

	}
}
