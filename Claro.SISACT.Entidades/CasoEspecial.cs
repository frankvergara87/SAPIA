using System;
using System.Data;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de CasoEspecial.
	/// </summary>
	public class CasoEspecial
	{
		//Cabecera
		private string _Codigo; 
		private string _Descripcion; 
		private string _IdEstado; 
		private int _WhiteList;
		private string _IdOferta;
		private int _MaxPlanes;
		private int _MaxPlanesVoz;
		private int _MaxPlanesDatos;
		private string _Usuario;

		private string _TCESC_CODIGO; 
		private string _TCESC_DESCRIPCION; 

		//Detalles
		private DataTable _DtCasoEspecialDocumento;
		private DataTable _DtCasoEspecialCuota;
		private DataTable _DtCasoEspecialCampania;
		private DataTable _DtCasoEspecialPDV;
		private DataTable _DtCasoEspecialPlan;
		private DataTable _DtCasoEspecialRiesgo;
		private DataTable _DtCasoEspecialTopeConsumo;

		
		//Renovacion
		private string _FLAG_WHITELIST; 
		private string _TOFC_CODIGO; 
		private int _TCEN_MAX_PLANES; 
		private int _TCEN_MAX_PLAN_VOZ; 
		private int _TCEN_MAX_PLAN_DATOS;
		private string _TCESC_DESCRIPCION2; 


		public CasoEspecial()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public string TCESC_CODIGO
		{
			get { return this._TCESC_CODIGO; }
			set { this._TCESC_CODIGO = value; }
		}

		public string TCESC_DESCRIPCION
		{
			get { return this._TCESC_DESCRIPCION; }
			set { this._TCESC_DESCRIPCION = value; }
		}

		public string Codigo
		{
			set { _Codigo = value;}
			get { return _Codigo;}
		}

		public string Descripcion
		{
			set { _Descripcion = value;}
			get { return _Descripcion;}
		}

		public string IdEstado
		{
			set { _IdEstado = value;}
			get { return _IdEstado;}
		}

		public int WhiteList
		{
			set { _WhiteList = value;}
			get { return _WhiteList;}
		}

		public string IdOferta
		{
			set { _IdOferta = value;}
			get { return _IdOferta;}
		}

		public int MaxPlanes
		{
			set { _MaxPlanes = value;}
			get { return _MaxPlanes;}
		}

		public int MaxPlanesVoz
		{
			set { _MaxPlanesVoz = value;}
			get { return _MaxPlanesVoz;}
		}

		public int MaxPlanesDatos
		{
			set { _MaxPlanesDatos = value;}
			get { return _MaxPlanesDatos;}
		}

		public string Usuario
		{
			set { _Usuario = value;}
			get { return _Usuario;}
		}

		public DataTable DtCasoEspecialDocumento
		{
			set { _DtCasoEspecialDocumento = value;}
			get { return _DtCasoEspecialDocumento;}
		}

		public DataTable DtCasoEspecialCuota
		{
			set { _DtCasoEspecialCuota = value;}
			get { return _DtCasoEspecialCuota;}
		}

		public DataTable DtCasoEspecialCampania
		{
			set { _DtCasoEspecialCampania = value;}
			get { return _DtCasoEspecialCampania;}
		}

		public DataTable DtCasoEspecialPDV
		{
			set { _DtCasoEspecialPDV = value;}
			get { return _DtCasoEspecialPDV;}
		}

		public DataTable DtCasoEspecialPlan
		{
			set { _DtCasoEspecialPlan = value;}
			get { return _DtCasoEspecialPlan;}
		}

		public DataTable DtCasoEspecialRiesgo
		{
			set { _DtCasoEspecialRiesgo = value;}
			get { return _DtCasoEspecialRiesgo;}
		}

		public DataTable DtCasoEspecialTopeConsumo
		{
			set { _DtCasoEspecialTopeConsumo = value;}
			get { return _DtCasoEspecialTopeConsumo;}
		}

		public string TCESC_DESCRIPCION2
		{
			get { return this._TCESC_DESCRIPCION2; }
			set { this._TCESC_DESCRIPCION2 = value; }
		}
		
		public int TCEN_MAX_PLANES
		{
			get { return this._TCEN_MAX_PLANES; }
			set { this._TCEN_MAX_PLANES = value; }
		}
		
		public int TCEN_MAX_PLAN_VOZ
		{
			get { return this._TCEN_MAX_PLAN_VOZ; }
			set { this._TCEN_MAX_PLAN_VOZ = value; }
		}

		public int TCEN_MAX_PLAN_DATOS
		{
			get { return this._TCEN_MAX_PLAN_DATOS; }
			set { this._TCEN_MAX_PLAN_DATOS = value; }
		}

		public string FLAG_WHITELIST
		{
			get { return this._FLAG_WHITELIST; }
			set { this._FLAG_WHITELIST = value; }
		}
		
		public string TOFC_CODIGO
		{
			get { return this._TOFC_CODIGO; }
			set { this._TOFC_CODIGO = value; }
		}

	}
}
