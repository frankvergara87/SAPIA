using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for VistaSolicitudEvaluacion.
	/// </summary>
	public class VistaSolicitudEvaluacion
	{
		private	float  _SOLIN_CODIGO;
		private	string _ESTAC_CODIGO;	
		private	double _SOLIN_NUM_CAR_FIJ_ADI; 
		private double _SOLIN_NUM_RA; 
		private	double _SOLIN_IMP_DG_MAN; 
		private	string _SOLIV_COM_PUN_VEN;
		private	string _SOLIV_COM_EVAL; 
		private	string _SOLIC_TIP_CAR_MAN;
		private string _SOLIC_COD_APROB;

		// E75606 - Editar Nombre, Apellidos Cliente (tipo 6, riesgo S DataCredito)
		private string _CLIEV_NOMBRE;
		private string _CLIEV_APE_PAT;
		private string _CLIEV_APE_MAT;
		// E75606 - Editar Nombre, Apellidos Cliente (tipo 6, riesgo S DataCredito)

		// Editar EsSalud/Sunat
		private string _SOLIC_EVA_SUN;
		private string _SOLIC_EVA_ESS;
		// Editar EsSalud/Sunat

		private DateTime _FECHA_NACIMIENTO;
		private string _FLAG_REINGRESO_SEC = "0";
		private double _SOLIN_COSTO_INST;	
		private double _SOLIN_IMP_DG_GRUPO_SEC;

		public VistaSolicitudEvaluacion()
		{			
		}
				
		public string SOLIC_COD_APROB 
		{
			get{ return _SOLIC_COD_APROB;}
			set{ 	 _SOLIC_COD_APROB = value; }
		}

		public float SOLIN_CODIGO 
		{
			get{ return _SOLIN_CODIGO;}
			set{ 	 _SOLIN_CODIGO = value; }
		}

		public string ESTAC_CODIGO 
		{
			get{ return _ESTAC_CODIGO;}
			set{ 	 _ESTAC_CODIGO = value; }
		}

		public double SOLIN_NUM_CAR_FIJ_ADI 
		{
			get{ return _SOLIN_NUM_CAR_FIJ_ADI;}
			set{ 	 _SOLIN_NUM_CAR_FIJ_ADI = value; }
		}

		public double SOLIN_NUM_RA
		{
			get{ return _SOLIN_NUM_RA;}
			set{ 	 _SOLIN_NUM_RA = value; }
		}

		public double SOLIN_IMP_DG_MAN 
		{
			get{ return _SOLIN_IMP_DG_MAN;}
			set{ 	 _SOLIN_IMP_DG_MAN = value; }
		}

		public string SOLIV_COM_PUN_VEN 
		{
			get{ return _SOLIV_COM_PUN_VEN;}
			set{ 	 _SOLIV_COM_PUN_VEN = value; }
		}

		public string SOLIV_COM_EVAL 
		{
			get{ return _SOLIV_COM_EVAL;}
			set{ 	 _SOLIV_COM_EVAL = value; }
		}

		public string SOLIC_TIP_CAR_MAN 
		{
			get{ return _SOLIC_TIP_CAR_MAN;}
			set{ 	 _SOLIC_TIP_CAR_MAN = value; }
		}

		// E75606 - Editar Nombre, Apellidos Cliente (tipo 6, riesgo S DataCredito)
		public string CLIEV_NOMBRE
		{
			get{ return _CLIEV_NOMBRE; }
			set{ _CLIEV_NOMBRE = value; }
		}
		public string CLIEV_APE_PAT
		{
			get{ return _CLIEV_APE_PAT; }
			set{ _CLIEV_APE_PAT = value; }
		}
		public string CLIEV_APE_MAT
		{
			get{ return _CLIEV_APE_MAT; }
			set{ _CLIEV_APE_MAT = value; }
		}
		// E75606 - Editar Nombre, Apellidos Cliente (tipo 6, riesgo S DataCredito)

		public string SOLIC_EVA_SUN
		{
			get{ return _SOLIC_EVA_SUN; }
			set{ _SOLIC_EVA_SUN = value; }
		}
		public string SOLIC_EVA_ESS
		{
			get{ return _SOLIC_EVA_ESS; }
			set{ _SOLIC_EVA_ESS = value; }
		}

		public DateTime FECHA_NACIMIENTO
		{ 
			set {  _FECHA_NACIMIENTO= value;} 
			get { return _FECHA_NACIMIENTO;} 
		}	
	
		public string FLAG_REINGRESO_SEC
		{ 
			set {  _FLAG_REINGRESO_SEC= value;} 
			get { return _FLAG_REINGRESO_SEC;} 
		}
		public double SOLIN_COSTO_INST
		{
			set {  _SOLIN_COSTO_INST= value;} 
			get { return _SOLIN_COSTO_INST;} 
		}
		public double SOLIN_IMP_DG_GRUPO_SEC
		{
			set {  _SOLIN_IMP_DG_GRUPO_SEC = value;} 
			get { return _SOLIN_IMP_DG_GRUPO_SEC;} 
		}
	}
}
