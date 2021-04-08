using System;

using System.Collections;

using System.Data;



namespace Claro.SisAct.Entidades
{
	public class DetalleTransaccion
	{
		private int _CO_ID;
		private string _SERVD_FECHAPROG;
		private string _SERVD_FECHA_REG;
		private string _SERVD_FECHA_EJEC;
		private string _SERVC_ESTADO;
		private string _SERVC_ESBATCH;
		private string _SERVV_MEN_ERROR;
		private string _SERVV_COD_ERROR;
		private string _SERVV_USUARIO_SISTEMA;
		private string _SERVV_ID_EAI_SW;
		private int _SERVI_COD;
		private string _SERVV_MSISDN;
		private string _SERVV_ID_BATCH;
		private string _SERVV_USUARIO_APLICACION;
		private string _SERVV_EMAIL_USUARIO_APP;
		private object _SERVV_XMLENTRADA;
		private string _TIPO_TRANSACCION;
		private string _TIPO_ESTADO;
		private string _ID_TRANSACCION;
		private string _SERVC_NROCUENTA;
		private string _SERVC_PUNTOVENTA;
		private string _SERVC_CODIGO_INTERACCION;
		private string _SERVC_CODIGO_PROGRAMACION;
		private string _SERVV_FECHA_DESDE;
		private string _SERVV_FECHA_HASTA;
		private string _SERVC_ASESOR;	
	

		public string TIPO_TRANSACCION
		{
			get { return _TIPO_TRANSACCION;}
			set { _TIPO_TRANSACCION = value;}
		}

		public string TIPO_ESTADO
		{
			get { return _TIPO_ESTADO;}
			set { _TIPO_ESTADO = value;}
		}

		public int CO_ID
		{
			get { return _CO_ID;}
			set { _CO_ID = value;}
		}

		public string SERVD_FECHAPROG
		{
			get { return _SERVD_FECHAPROG;}
			set { _SERVD_FECHAPROG = value;}
		}

		public string SERVD_FECHA_REG
		{
			get { return _SERVD_FECHA_REG;}
			set { _SERVD_FECHA_REG = value;}
		}

		public string SERVD_FECHA_EJEC
		{
			get { return _SERVD_FECHA_EJEC;}
			set { _SERVD_FECHA_EJEC = value;}
		}

		public string SERVC_ESTADO
		{
			get { return _SERVC_ESTADO;}
			set { _SERVC_ESTADO = value;}
		}

		public string SERVC_ESBATCH
		{
			get { return _SERVC_ESBATCH;}
			set { _SERVC_ESBATCH = value;}
		}

		public string SERVV_MEN_ERROR
		{
			get { return _SERVV_MEN_ERROR;}
			set { _SERVV_MEN_ERROR = value;}
		}

		public string SERVV_COD_ERROR
		{
			get { return _SERVV_COD_ERROR;}
			set { _SERVV_COD_ERROR = value;}
		}

		public string SERVV_USUARIO_SISTEMA
		{
			get { return _SERVV_USUARIO_SISTEMA;}
			set { _SERVV_USUARIO_SISTEMA = value;}
		}

		public string SERVV_ID_EAI_SW
		{
			get { return _SERVV_ID_EAI_SW;}
			set { _SERVV_ID_EAI_SW = value;}
		}

		public int SERVI_COD
		{
			get { return _SERVI_COD;}
			set { _SERVI_COD = value;}
		}

		public string SERVV_MSISDN
		{
			get { return _SERVV_MSISDN;}
			set { _SERVV_MSISDN = value;}
		}

		public string SERVV_ID_BATCH
		{
			get { return _SERVV_ID_BATCH;}
			set { _SERVV_ID_BATCH = value;}
		}

		public string SERVV_USUARIO_APLICACION
		{
			get { return _SERVV_USUARIO_APLICACION;}
			set { _SERVV_USUARIO_APLICACION = value;}
		}

		public string SERVV_EMAIL_USUARIO_APP
		{
			get { return _SERVV_EMAIL_USUARIO_APP;}
			set { _SERVV_EMAIL_USUARIO_APP = value;}
		}

		public object SERVV_XMLENTRADA
		{
			get { return _SERVV_XMLENTRADA;}
			set { _SERVV_XMLENTRADA = value;}
		
		}
		
		public string ID_TRANSACCION
		{
			get { return _ID_TRANSACCION;}
			set { _ID_TRANSACCION = value;}
		}
		public string SERVC_NROCUENTA
		 {
			 get { return _SERVC_NROCUENTA;}
			 set { _SERVC_NROCUENTA = value;}
		
		 }

		public string SERVC_PUNTOVENTA
		{
			get { return _SERVC_PUNTOVENTA;}
			set { _SERVC_PUNTOVENTA = value;}
		}

		public string SERVC_CODIGO_INTERACCION
		{
			get { return _SERVC_CODIGO_INTERACCION;}
			set { _SERVC_CODIGO_INTERACCION = value;}
		}
		
		public string SERVC_CODIGO_PROGRAMACION
		{
			get { return _SERVC_CODIGO_PROGRAMACION;}
			set { _SERVC_CODIGO_PROGRAMACION = value;}
		}
		
		public string SERVV_FECHA_DESDE
		{
			get { return _SERVV_FECHA_DESDE;}
			set { _SERVV_FECHA_DESDE = value;}
		}
		
		public string SERVV_FECHA_HASTA
		{
			get { return _SERVV_FECHA_HASTA;}
			set { _SERVV_FECHA_HASTA = value;}
		}
	
		public string SERVC_ASESOR
		{
			get { return _SERVC_ASESOR;}
			set { _SERVC_ASESOR = value;}
		}
	

	}
}
