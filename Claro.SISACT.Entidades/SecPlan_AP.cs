using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PaqPlan_AP.
	/// </summary>
	public class SecPlan_AP : Plan_AP
	{
		private int _SOPLN_CODIGO;
		private int _SOLIN_CODIGO;
		private double _CARGO_FIJO_EN_SEC;
		private double _CF_ALQUILER_KIT;

		public int SOPLN_CODIGO {get{ return _SOPLN_CODIGO;} set{_SOPLN_CODIGO = value;}}
		public int SOLIN_CODIGO {get{ return _SOLIN_CODIGO;} set{_SOLIN_CODIGO = value;}}
		public double CARGO_FIJO_EN_SEC {get{ return _CARGO_FIJO_EN_SEC;} set{_CARGO_FIJO_EN_SEC = value;}}

		private SecPlanPort_AP _PLANPORT;
		public SecPlanPort_AP PLANPORT {get{ return _PLANPORT;} set{_PLANPORT = value;}}
		public double CF_ALQUILER_KIT {get{ return _CF_ALQUILER_KIT;} set{_CF_ALQUILER_KIT = value;}}
		//gaa20120202
		private string _CAMP_CODIGO;
		private string _PLZO_CODIGO;

		public string CAMP_CODIGO {get{ return _CAMP_CODIGO;} set{_CAMP_CODIGO = value;}}
		public string PLZO_CODIGO {get{ return _PLZO_CODIGO;} set{_PLZO_CODIGO = value;}}
		//fin gaa20120202

		private string _CAMP_DESCRIPCION;
		public string CAMP_DESCRIPCION {get{ return _CAMP_DESCRIPCION;} set{_CAMP_DESCRIPCION = value;}}

		private string _PLANC_EQUI_SAP;
		public string PLANC_EQUI_SAP {get{ return _PLANC_EQUI_SAP;} set{_PLANC_EQUI_SAP = value;}}

		private string _GPLNV_DESCRIPCION;
		public string GPLNV_DESCRIPCION
		{
			set{_GPLNV_DESCRIPCION = value;}
			get{return _GPLNV_DESCRIPCION;}
		}

		public double CARGO_FIJO_TOTAL_EN_SEC
		{
			get
			{
				double CFtotal = 0;
				CFtotal += CARGO_FIJO_EN_SEC;
				foreach (SecServicio_AP oServ in SERVICIOS)
				{
					CFtotal += oServ.CARGO_FIJO_EN_SEC;
				}
				return CFtotal;
			}
		}

		public SecPlan_AP()
		{
			new Plan_AP();
			SOPLN_CODIGO = 0;
			SOLIN_CODIGO = 0;

			CARGO_FIJO_EN_SEC = 0;

			PLANPORT = new SecPlanPort_AP();
		}
	}
}
