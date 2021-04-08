using System;

namespace Claro.SisAct.Entidades
{
	public class Vista_SolicitudDC_Reporte
	{
		public Vista_SolicitudDC_Reporte()
		{}

		private string _DCREV_NUM_OPERACION;
		private string _DCREN_SOLIN_CODIGO;
		private string _DCREV_OVEN_CODIGO;
		private string _DCREV_OVEN_DESC;
		private string _DCREN_USUARIO_REG;
		private string _DCREC_TIPO_DOCUMENTO;
		private string _DCREV_TIPO_DOCUMENTO_DESC;
		private string _DCREV_NUM_DOCUMENTO;
		private string _DCREV_APELLIDO_PAT;
		private string _DCREV_APELLIDO_MAT;
		private string _DCREV_NOMBRE;
		private int _DCREN_CANT_INTENTOS;
		private string _DCREC_VALIDAR_CLIENTE;
		private string _DCREC_FACTOR_RENOVACION;

		public string DCREV_NUM_OPERACION 
		{
			get{ return _DCREV_NUM_OPERACION;}
			set{ 	 _DCREV_NUM_OPERACION = value; }
		}

		public string DCREN_SOLIN_CODIGO 
		{
			get{ return _DCREN_SOLIN_CODIGO;}
			set{ 	 _DCREN_SOLIN_CODIGO = value; }
		}

		public string DCREV_OVEN_CODIGO 
		{
			get{ return _DCREV_OVEN_CODIGO;}
			set{ 	 _DCREV_OVEN_CODIGO = value; }
		}

		public string DCREV_OVEN_DESC 
		{
			get{ return _DCREV_OVEN_DESC;}
			set{ 	 _DCREV_OVEN_DESC = value; }
		}

		public string DCREN_USUARIO_REG 
		{
			get{ return _DCREN_USUARIO_REG;}
			set{ 	 _DCREN_USUARIO_REG = value; }
		}

		public string DCREC_TIPO_DOCUMENTO 
		{
			get{ return _DCREC_TIPO_DOCUMENTO;}
			set{ 	 _DCREC_TIPO_DOCUMENTO = value; }
		}

		public string DCREV_TIPO_DOCUMENTO_DESC 
		{
			get{ return _DCREV_TIPO_DOCUMENTO_DESC;}
			set{ 	 _DCREV_TIPO_DOCUMENTO_DESC = value; }
		}

		public string DCREV_NUM_DOCUMENTO 
		{
			get{ return _DCREV_NUM_DOCUMENTO;}
			set{ 	 _DCREV_NUM_DOCUMENTO = value; }
		}

		public string DCREV_APELLIDO_PAT 
		{
			get{ return _DCREV_APELLIDO_PAT;}
			set{ 	 _DCREV_APELLIDO_PAT = value; }
		}

		public string DCREV_APELLIDO_MAT 
		{
			get{ return _DCREV_APELLIDO_MAT;}
			set{ 	 _DCREV_APELLIDO_MAT = value; }
		}

		public string DCREV_NOMBRE 
		{
			get{ return _DCREV_NOMBRE;}
			set{ 	 _DCREV_NOMBRE = value; }
		}

		public int DCREN_CANT_INTENTOS 
		{
			get{ return _DCREN_CANT_INTENTOS;}
			set{ 	 _DCREN_CANT_INTENTOS = value; }
		}

		public string DCREC_VALIDAR_CLIENTE 
		{
			get{ return _DCREC_VALIDAR_CLIENTE;}
			set{ 	 _DCREC_VALIDAR_CLIENTE = value; }
		}

		public string DCREC_FACTOR_RENOVACION 
		{
			get{ return _DCREC_FACTOR_RENOVACION;}
			set{ 	 _DCREC_FACTOR_RENOVACION = value; }
		}
	}
}
