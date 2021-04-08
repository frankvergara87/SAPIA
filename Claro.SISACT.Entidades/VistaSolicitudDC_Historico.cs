using System;

namespace Claro.SisAct.Entidades
{
	public class VistaSolicitudDC_Historico
	{
		public VistaSolicitudDC_Historico()
		{}

		private string _HISTV_NUM_OPERACION;
		private string _HISTC_TIPO_DOCUMENTO;
		private string _HISTV_TIPO_DOCUMENTO_DESC;
		private string _HISTV_NUM_DOCUMENTO;
		private string _HISTV_APELLIDO_PAT;
		private string _HISTV_APELLIDO_MAT;
		private string _HISTV_NOMBRE;
		private string _HISTC_TIPO_RESPUESTA;
		private string _HISTC_TIPO_RIESGO;
		private int _HISTN_CANT_INTENTOS;
		private string _HISTV_OVEN_CODIGO;
		private string _HISTV_OVEN_DESC;
		private string _HISTV_TERMINAL_ID;
		private string _HISTN_USUARIO_REG;
		private string _HISTD_FECHA_REG;

		public string HISTV_NUM_OPERACION 
		{
			get{ return _HISTV_NUM_OPERACION;}
			set{ 	 _HISTV_NUM_OPERACION = value; }
		}

		public string HISTC_TIPO_DOCUMENTO 
		{
			get{ return _HISTC_TIPO_DOCUMENTO;}
			set{ 	 _HISTC_TIPO_DOCUMENTO = value; }
		}

		public string HISTV_TIPO_DOCUMENTO_DESC 
		{
			get{ return _HISTV_TIPO_DOCUMENTO_DESC;}
			set{ 	 _HISTV_TIPO_DOCUMENTO_DESC = value; }
		}

		public string HISTV_NUM_DOCUMENTO 
		{
			get{ return _HISTV_NUM_DOCUMENTO;}
			set{ 	 _HISTV_NUM_DOCUMENTO = value; }
		}

		public string HISTV_APELLIDO_PAT 
		{
			get{ return _HISTV_APELLIDO_PAT;}
			set{ 	 _HISTV_APELLIDO_PAT = value; }
		}

		public string HISTV_APELLIDO_MAT 
		{
			get{ return _HISTV_APELLIDO_MAT;}
			set{ 	 _HISTV_APELLIDO_MAT = value; }
		}

		public string HISTV_NOMBRE 
		{
			get{ return _HISTV_NOMBRE;}
			set{ 	 _HISTV_NOMBRE = value; }
		}

		public string HISTC_TIPO_RESPUESTA 
		{
			get{ return _HISTC_TIPO_RESPUESTA;}
			set{ 	 _HISTC_TIPO_RESPUESTA = value; }
		}

		public string HISTC_TIPO_RIESGO 
		{
			get{ return _HISTC_TIPO_RIESGO;}
			set{ 	 _HISTC_TIPO_RIESGO = value; }
		}

		public int HISTN_CANT_INTENTOS 
		{
			get{ return _HISTN_CANT_INTENTOS;}
			set{ 	 _HISTN_CANT_INTENTOS = value; }
		}

		public string HISTV_OVEN_CODIGO 
		{
			get{ return _HISTV_OVEN_CODIGO;}
			set{ 	 _HISTV_OVEN_CODIGO = value; }
		}

		public string HISTV_OVEN_DESC 
		{
			get{ return _HISTV_OVEN_DESC;}
			set{ 	 _HISTV_OVEN_DESC = value; }
		}

		public string HISTV_TERMINAL_ID 
		{
			get{ return _HISTV_TERMINAL_ID;}
			set{ 	 _HISTV_TERMINAL_ID = value; }
		}

		public string HISTN_USUARIO_REG 
		{
			get{ return _HISTN_USUARIO_REG;}
			set{ 	 _HISTN_USUARIO_REG = value; }
		}
		public string HISTD_FECHA_REG 
		{
			get{ return _HISTD_FECHA_REG;}
			set{ 	 _HISTD_FECHA_REG = value; }
		}
	}
}
