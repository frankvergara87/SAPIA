using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de DataCreditoOUT.
	/// </summary>
	public class DataCreditoOUT
	{
		private string _NumeroOperacion = "";
		private string _CodigoModelo = "";
		private string _RegsCalificacion = "";
		private string _ACCION = "";
		private string _DIRECCIONES = "";
		private double _LIMITE_DE_CREDITO = 0;
		private string _CLASE_DE_CLIENTE = "";
		private double _LC_DISPONIBLE = 0;
		private double _NV_LC_MAXIMO = 0;
		private double _NV_TOTAL_CARGOS_FIJOS = 0;
		private string _EXPLICACION = "";
		private int _SCORE = 0;
		private string _CREDIT_SCORE = "";
		private string _TIPO_DE_PRODUCTO = "";
		private double _LINEA_DE_CREDITO_EN_EL_SISTEMA = 0;
		private int _EDAD = 0;
		private double _INGRESO_O_LC = 0;
		private string _TIPO_DE_CLIENTE = "";
		private string _TIPO_DE_TARJETA = "";
		private string _TOP_10000 = "";
		private int _ANTIGUEDAD_LABORAL = 0;
		private string _NUMERO_DOCUMENTO = "";
		private string _APELLIDO_PATERNO = "";
		private string _APELLIDO_MATERNO = "";
		private string _NOMBRES = "";
		private string _respuesta = "";
		private string _fechaConsulta = "";
		//E76009 Inicio
		private string _IstrEstadoCivil="";
		private string _RAZONES="";
		private string _ANALISIS="";
		private string _SCORE_RANKIN_OPERATIVO="";
		private string _NUMERO_ENTIDADES_RANKIN_OPERATIVO="";
		private string _PUNTAJE="";
		private double _limiteCreditoDataCredito=0;
		private double _limiteCreditoBaseExterna=0;
		private double _limiteCreditoClaro=0;
		private string _fechanacimiento="";
		//E76009 Fin
		//gaa20170215
		public string _BUROCONSULTADO=string.Empty;
		//gaa20170215

		private string _CodigoBuro;

		public DataCreditoOUT()
		{}

		public enum TIPO_CLIENTE
		{
			SUNAT = 1,
			ESSALUD = 2
		}

		public enum TIPO_RESPUESTA
		{
			TIPO09 = 9,
			TIPO10 = 10,
			TIPO13 = 13
		}

		public enum VALIDACION_CLIENTE
		{
			NINGUNO = 0,
			NOMBRES = 1,
			ESSALUDSUNAT = 2,
			EDAD = 4
		}

		public string NUMEROOPERACION
		{
			set{ _NumeroOperacion = value; }
			get{ return _NumeroOperacion; }
		}
		public string CODIGOMODELO
		{
			set{ _CodigoModelo = value; }
			get{ return _CodigoModelo; }
		}
		public string RegsCalificacion
		{
			set{ _RegsCalificacion = value; }
			get{ return _RegsCalificacion; }
		}
		public string ACCION
		{
			set{ _ACCION = value; }
			get{ return _ACCION; }
		}
		public string DIRECCIONES
		{
			set{ _DIRECCIONES = value; }
			get{ return _DIRECCIONES; }
		}
		public double LIMITE_DE_CREDITO
		{
			set{ _LIMITE_DE_CREDITO = value; }
			get{ return _LIMITE_DE_CREDITO; }
		}
		public string CLASE_DE_CLIENTE
		{
			set{ _CLASE_DE_CLIENTE = value; }
			get{ return _CLASE_DE_CLIENTE; }
		}
		public double LC_DISPONIBLE
		{
			set{ _LC_DISPONIBLE = value; }
			get{ return _LC_DISPONIBLE; }
		}
		public double NV_LC_MAXIMO
		{
			set{ _NV_LC_MAXIMO = value; }
			get{ return _NV_LC_MAXIMO; }
		}
		public double NV_TOTAL_CARGOS_FIJOS
		{
			set{ _NV_TOTAL_CARGOS_FIJOS = value; }
			get{ return _NV_TOTAL_CARGOS_FIJOS; }
		}
		public string EXPLICACION
		{
			set{ _EXPLICACION = value; }
			get{ return _EXPLICACION; }
		}
		public int SCORE
		{
			set{ _SCORE = value; }
			get{ return _SCORE; }
		}
		public string CREDIT_SCORE
		{
			set{ _CREDIT_SCORE = value; }
			get{ return _CREDIT_SCORE; }
		}
		public string TIPO_DE_PRODUCTO
		{
			set{ _TIPO_DE_PRODUCTO = value; }
			get{ return _TIPO_DE_PRODUCTO; }
		}
		public double LINEA_DE_CREDITO_EN_EL_SISTEMA
		{
			set{ _LINEA_DE_CREDITO_EN_EL_SISTEMA = value; }
			get{ return _LINEA_DE_CREDITO_EN_EL_SISTEMA; }
		}
		public int EDAD
		{
			set{ _EDAD = value; }
			get{ return _EDAD; }
		}
		public double INGRESO_O_LC
		{
			set{ _INGRESO_O_LC = value; }
			get{ return _INGRESO_O_LC; }
		}
		public string TIPO_DE_CLIENTE
		{
			set{ _TIPO_DE_CLIENTE = value; }
			get{ return _TIPO_DE_CLIENTE; }
		}
		public string TIPO_DE_TARJETA
		{
			set{ _TIPO_DE_TARJETA = value; }
			get{ return _TIPO_DE_TARJETA; }
		}
		public string TOP_10000
		{
			set{ _TOP_10000 = value; }
			get{ return _TOP_10000; }
		}
		public int ANTIGUEDAD_LABORAL
		{
			set{ _ANTIGUEDAD_LABORAL = value; }
			get{ return _ANTIGUEDAD_LABORAL; }
		}
		public string NUMERO_DOCUMENTO
		{
			set{ _NUMERO_DOCUMENTO = value; }
			get{ return _NUMERO_DOCUMENTO; }
		}
		public string APELLIDO_PATERNO
		{
			set{ _APELLIDO_PATERNO = value; }
			get{ return _APELLIDO_PATERNO; }
		}
		public string APELLIDO_MATERNO
		{
			set{ _APELLIDO_MATERNO = value; }
			get{ return _APELLIDO_MATERNO; }
		}
		public string NOMBRES
		{
			set{ _NOMBRES = value; }
			get{ return _NOMBRES; }
		}
		public string respuesta
		{
			set{ _respuesta = value; }
			get{ return _respuesta; }
		}
		public string fechaConsulta
		{
			set{ _fechaConsulta = value; }
			get{ return _fechaConsulta; }
		}
		//E76009 Inicio
		public string IstrEstadoCivil
		{
			set{ _IstrEstadoCivil = value; }
			get{ return _IstrEstadoCivil; }
		}	
		public string RAZONES
		{
			set{ _RAZONES = value; }
			get{ return _RAZONES; }
		}
		public string ANALISIS
		{
			set{ _ANALISIS = value; }
			get{ return _ANALISIS; }
		}
		public string SCORE_RANKIN_OPERATIVO
		{
			set{ _SCORE_RANKIN_OPERATIVO = value; }
			get{ return _SCORE_RANKIN_OPERATIVO; }
		}
		public string NUMERO_ENTIDADES_RANKIN_OPERATIVO
		{
			set{ _NUMERO_ENTIDADES_RANKIN_OPERATIVO = value; }
			get{ return _NUMERO_ENTIDADES_RANKIN_OPERATIVO; }
		}
		public string PUNTAJE
		{
			set{ _PUNTAJE = value; }
			get{ return _PUNTAJE; }
		}
		public double limiteCreditoDataCredito
		{
			set{ _limiteCreditoDataCredito = value; }
			get{ return _limiteCreditoDataCredito; }
		}
		public double limiteCreditoBaseExterna
		{
			set{ _limiteCreditoBaseExterna = value; }
			get{ return _limiteCreditoBaseExterna; }
		}
		public double limiteCreditoClaro
		{
			set{ _limiteCreditoClaro = value; }
			get{ return _limiteCreditoClaro; }
		}
		public string fechanacimiento
		{
			set{ _fechanacimiento = value; }
			get{ return _fechanacimiento; }
		}
		public string CodigoBuro
		{
			set{ _CodigoBuro = value; }
			get{ return _CodigoBuro; }
		}
		//gaa20170215
		public string BUROCONSULTADO
		{
			set{ _BUROCONSULTADO = value; }
			get{ return _BUROCONSULTADO; }
		}
		//gaa20170215
	}
}
