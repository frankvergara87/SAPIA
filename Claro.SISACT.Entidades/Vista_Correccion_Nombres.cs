using System;

namespace Claro.SisAct.Entidades
{
	public class Vista_Correccion_Nombres
	{
		private string _SIVNN_CODIGO;
		private string _SIVNC_TIPO_DOCUMENTO;
		private string _SIVNV_NUM_DOCUMENTO;
		private string _SIVNV_NOMBRE_ANTERIOR;
		private string _SIVNV_APE_PATERNO_ANT;
		private string _SIVNV_APE_MATERNO_ANT;
		private string _SIVNV_NOMBRE_NUEVO;
		private string _SIVNV_APE_PATERNO_NUEVO;
		private string _SIVNV_APE_MATERNO_NUEVO;
		private string _SIVNV_SOLIN_CODIGO;
		private string _SIVNV_TERMINAL;
		private string _SIVNV_USUARIO_CREACION;
		
		// Editar EsSalud/Sunat
		private string _SIVNC_EVA_SUN_ANT;
		private string _SIVNC_EVA_ESS_ANT;
		private string _SIVNC_EVA_SUN_NUEVO;
		private string _SIVNC_EVA_ESS_NUEVO;
		// Editar EsSalud/Sunat

		private DateTime _FECHA_NACIMIENTO;

		public Vista_Correccion_Nombres()
		{}

		public string SIVNN_CODIGO
		{
			set{_SIVNN_CODIGO= value;}
			get{return _SIVNN_CODIGO;}
		}

		public string SIVNC_TIPO_DOCUMENTO
		{
			set{_SIVNC_TIPO_DOCUMENTO= value;}
			get{return _SIVNC_TIPO_DOCUMENTO;}
		}

		public string SIVNV_NUM_DOCUMENTO
		{
			set{_SIVNV_NUM_DOCUMENTO= value;}
			get{return _SIVNV_NUM_DOCUMENTO;}
		}

		public string SIVNV_NOMBRE_ANTERIOR
		{
			set{_SIVNV_NOMBRE_ANTERIOR= value;}
			get{return _SIVNV_NOMBRE_ANTERIOR;}
		}

		public string SIVNV_APE_PATERNO_ANT
		{
			set{_SIVNV_APE_PATERNO_ANT= value;}
			get{return _SIVNV_APE_PATERNO_ANT;}
		}

		public string SIVNV_APE_MATERNO_ANT
		{
			set{_SIVNV_APE_MATERNO_ANT= value;}
			get{return _SIVNV_APE_MATERNO_ANT;}
		}

		public string SIVNV_NOMBRE_NUEVO
		{
			set{_SIVNV_NOMBRE_NUEVO= value;}
			get{return _SIVNV_NOMBRE_NUEVO;}
		}

		public string SIVNV_APE_PATERNO_NUEVO
		{
			set{_SIVNV_APE_PATERNO_NUEVO= value;}
			get{return _SIVNV_APE_PATERNO_NUEVO;}
		}

		public string SIVNV_APE_MATERNO_NUEVO
		{
			set{_SIVNV_APE_MATERNO_NUEVO= value;}
			get{return _SIVNV_APE_MATERNO_NUEVO;}
		}

		public string SIVNV_SOLIN_CODIGO
		{
			set{_SIVNV_SOLIN_CODIGO= value;}
			get{return _SIVNV_SOLIN_CODIGO;}
		}

		public string SIVNV_TERMINAL
		{
			set{_SIVNV_TERMINAL= value;}
			get{return _SIVNV_TERMINAL;}
		}

		public string SIVNV_USUARIO_CREACION
		{
			set{_SIVNV_USUARIO_CREACION= value;}
			get{return _SIVNV_USUARIO_CREACION;}
		}

		// Editar EsSalud/Sunat
		public string SIVNC_EVA_SUN_ANT
		{
			set{_SIVNC_EVA_SUN_ANT= value;}
			get{return _SIVNC_EVA_SUN_ANT;}
		}

		public string SIVNC_EVA_ESS_ANT
		{
			set{_SIVNC_EVA_ESS_ANT= value;}
			get{return _SIVNC_EVA_ESS_ANT;}
		}

		public string SIVNC_EVA_SUN_NUEVO
		{
			set{_SIVNC_EVA_SUN_NUEVO= value;}
			get{return _SIVNC_EVA_SUN_NUEVO;}
		}

		public string SIVNC_EVA_ESS_NUEVO
		{
			set{_SIVNC_EVA_ESS_NUEVO= value;}
			get{return _SIVNC_EVA_ESS_NUEVO;}
		}

		public DateTime FECHA_NACIMIENTO
		{ 
			set {  _FECHA_NACIMIENTO= value;} 
			get { return _FECHA_NACIMIENTO;} 
		}	
	}
}
