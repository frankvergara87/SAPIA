using System;

namespace Claro.SisAct.Entidades
{
	public class DataCredito_Input_Output
	{
		private int _IODCN_CODIGO;
		private string _IODCV_NUM_OPERACION;
		private string _IODCV_INPUT_VALORES;
		private string _IODCV_OUTPUT_VALORES;
		private DateTime _IODCD_FECHA_REGISTRO;
		private string _IODCV_TIPO_DOCUMENTO;
		private string _IODCV_NUM_DOCUMENTO;
		private string _IODCV_USUARIO_REGISTRO;
		private string _IODCV_COD_PUNTO_VENTA;
		private string _IODCC_FORMA_PAGO;
		private string _IODCC_TIPO_ACTIVACION;
		private string _IODCC_TIPO_CLIENTE;
		private string _IODCC_TIPO_VENTA;
		private string _IODCC_PLAZO_ACUERDO;
		private string _IODCC_PLAN1;
		private string _IODCC_PLAN2;
		private string _IODCC_PLAN3;
		private double _IODCI_NUM_CF;
		private string _IODCC_CONTROL_CONSUMO;
		private string _IODCC_FLAG_ESSALUD;
		private string _IODCC_FLAG_SUNAT;
		private string _IODCC_RIESGO;
		private string _IODCC_LIMITE_CREDITO;
		private string _IODCC_SCORE_TEXTO;
		private string _IODCC_SCORE_NUMERO;
		private string _IODCC_RESPUESTA_DC;
		private string _IODCC_TIPO_GARANTIA;
		private double _IODCN_TOTAL_IMPORTE;
		private string _IODCV_APE_PATERNO;
		private string _IODCV_APE_MATERNO;
		private string _IODCV_NOMBRES;
		private int _IODCN_SOLIN_CODIGO;
		private string _IODCV_TIPO_SEC;

		//E76009 Inicio
		private string _IODCV_UBIGEO;
		private string _IODCC_TIPO_CLIENTE_DC;
		private string _IODCC_ESTADO_CIVIL_DC;
		private string _IODCC_ORIGEN_LC_DC;
		private string _IODCC_ANALISIS_DC;
		private string _IODCC_SCORE_RANKING_OPER_DC;
		private int    _IODCN_PUNTAJE_DC;
		private double _IODCN_LC_DATA_CREDITO_DC;
		private double _IODCN_LC_BASE_EXTERNA_DC;
		private double _IODCN_LC_CLARO_DC;
		private string _IODCC_RAZONES_DC;
		private string _IODCD_FECHA_NACE_CLIENTE_DC;
		//E76009 Fin

		private int _IODCN_BURO_CREDITICIO; //ADD PROY-20054-IDEA-23849

		public DataCredito_Input_Output()
		{}

		public int IODCN_CODIGO
		{
			set{_IODCN_CODIGO = value;}
			get{return _IODCN_CODIGO;}
		}

		public string IODCV_NUM_OPERACION
		{
			set{_IODCV_NUM_OPERACION = value;}
			get{return _IODCV_NUM_OPERACION;}
		}

		public string IODCV_INPUT_VALORES
		{
			set{_IODCV_INPUT_VALORES = value;}
			get{return _IODCV_INPUT_VALORES;}
		}

		public string IODCV_OUTPUT_VALORES
		{
			set{_IODCV_OUTPUT_VALORES = value;}
			get{return _IODCV_OUTPUT_VALORES;}
		}

		public DateTime IODCD_FECHA_REGISTRO
		{
			set{_IODCD_FECHA_REGISTRO = value;}
			get{return _IODCD_FECHA_REGISTRO;}
		}

		public string IODCV_TIPO_DOCUMENTO
		{
			set{_IODCV_TIPO_DOCUMENTO = value;}
			get{return _IODCV_TIPO_DOCUMENTO;}
		}

		public string IODCV_NUM_DOCUMENTO
		{
			set{_IODCV_NUM_DOCUMENTO = value;}
			get{return _IODCV_NUM_DOCUMENTO;}
		}

		public string IODCV_USUARIO_REGISTRO
		{
			set{_IODCV_USUARIO_REGISTRO = value;}
			get{return _IODCV_USUARIO_REGISTRO;}
		}

		public string IODCV_COD_PUNTO_VENTA
		{
			set{_IODCV_COD_PUNTO_VENTA = value;}
			get{return _IODCV_COD_PUNTO_VENTA;}
		}

		public string IODCC_FORMA_PAGO
		{
			set{_IODCC_FORMA_PAGO = value;}
			get{return _IODCC_FORMA_PAGO;}
		}

		public string IODCC_TIPO_ACTIVACION
		{
			set{_IODCC_TIPO_ACTIVACION = value;}
			get{return _IODCC_TIPO_ACTIVACION;}
		}

		public string IODCC_TIPO_CLIENTE
		{
			set{_IODCC_TIPO_CLIENTE = value;}
			get{return _IODCC_TIPO_CLIENTE;}
		}

		public string IODCC_TIPO_VENTA
		{
			set{_IODCC_TIPO_VENTA = value;}
			get{return _IODCC_TIPO_VENTA;}
		}

		public string IODCC_PLAZO_ACUERDO
		{
			set{_IODCC_PLAZO_ACUERDO = value;}
			get{return _IODCC_PLAZO_ACUERDO;}
		}

		public string IODCC_PLAN1
		{
			set{_IODCC_PLAN1 = value;}
			get{return _IODCC_PLAN1;}
		}

		public string IODCC_PLAN2
		{
			set{_IODCC_PLAN2 = value;}
			get{return _IODCC_PLAN2;}
		}

		public string IODCC_PLAN3
		{
			set{_IODCC_PLAN3 = value;}
			get{return _IODCC_PLAN3;}
		}

		public double IODCI_NUM_CF
		{
			set{_IODCI_NUM_CF = value;}
			get{return _IODCI_NUM_CF;}
		}

		public string IODCC_CONTROL_CONSUMO
		{
			set{_IODCC_CONTROL_CONSUMO = value;}
			get{return _IODCC_CONTROL_CONSUMO;}
		}

		public string IODCC_FLAG_ESSALUD
		{
			set{_IODCC_FLAG_ESSALUD = value;}
			get{return _IODCC_FLAG_ESSALUD;}
		}

		public string IODCC_FLAG_SUNAT
		{
			set{_IODCC_FLAG_SUNAT = value;}
			get{return _IODCC_FLAG_SUNAT;}
		}

		public string IODCC_RIESGO
		{
			set{_IODCC_RIESGO = value;}
			get{return _IODCC_RIESGO;}
		}

		public string IODCC_LIMITE_CREDITO
		{
			set{_IODCC_LIMITE_CREDITO = value;}
			get{return _IODCC_LIMITE_CREDITO;}
		}

		public string IODCC_SCORE_TEXTO
		{
			set{_IODCC_SCORE_TEXTO = value;}
			get{return _IODCC_SCORE_TEXTO;}
		}

		public string IODCC_SCORE_NUMERO
		{
			set{_IODCC_SCORE_NUMERO = value;}
			get{return _IODCC_SCORE_NUMERO;}
		}

		public string IODCC_RESPUESTA_DC
		{
			set{_IODCC_RESPUESTA_DC = value;}
			get{return _IODCC_RESPUESTA_DC;}
		}

		public string IODCC_TIPO_GARANTIA
		{
			set{_IODCC_TIPO_GARANTIA = value;}
			get{return _IODCC_TIPO_GARANTIA;}
		}

		public double IODCN_TOTAL_IMPORTE
		{
			set{_IODCN_TOTAL_IMPORTE = value;}
			get{return _IODCN_TOTAL_IMPORTE;}
		}

		public string IODCV_APE_PATERNO
		{
			set{_IODCV_APE_PATERNO = value;}
			get{return _IODCV_APE_PATERNO;}
		}

		public string IODCV_APE_MATERNO
		{
			set{_IODCV_APE_MATERNO = value;}
			get{return _IODCV_APE_MATERNO;}
		}

		public string IODCV_NOMBRES
		{
			set{_IODCV_NOMBRES = value;}
			get{return _IODCV_NOMBRES;}
		}

		public int IODCN_SOLIN_CODIGO
		{
			set{_IODCN_SOLIN_CODIGO = value;}
			get{return _IODCN_SOLIN_CODIGO;}
		}
		public string IODCV_TIPO_SEC
		{
			set{_IODCV_TIPO_SEC = value;}
			get{return _IODCV_TIPO_SEC;}
		}
		//E76009 Inicio
		public string IODCV_UBIGEO
		{
			set{_IODCV_UBIGEO = value;}
			get{return _IODCV_UBIGEO;}
		}
		public string IODCC_TIPO_CLIENTE_DC
		{
			set{_IODCC_TIPO_CLIENTE_DC = value;}
			get{return _IODCC_TIPO_CLIENTE_DC;}
		}
		public string IODCC_ESTADO_CIVIL_DC
		{
			set{_IODCC_ESTADO_CIVIL_DC = value;}
			get{return _IODCC_ESTADO_CIVIL_DC;}
		}
		public string IODCC_ORIGEN_LC_DC
		{
			set{_IODCC_ORIGEN_LC_DC = value;}
			get{return _IODCC_ORIGEN_LC_DC;}
		}
		public string IODCC_ANALISIS_DC
		{
			set{_IODCC_ANALISIS_DC = value;}
			get{return _IODCC_ANALISIS_DC;}
		}
		public string IODCC_SCORE_RANKING_OPER_DC
		{
			set{_IODCC_SCORE_RANKING_OPER_DC = value;}
			get{return _IODCC_SCORE_RANKING_OPER_DC;}
		}
		public int IODCN_PUNTAJE_DC
		{
			set{_IODCN_PUNTAJE_DC = value;}
			get{return _IODCN_PUNTAJE_DC;}
		}
		public double IODCN_LC_DATA_CREDITO_DC
		{
			set{_IODCN_LC_DATA_CREDITO_DC = value;}
			get{return _IODCN_LC_DATA_CREDITO_DC;}
		}
		public double IODCN_LC_BASE_EXTERNA_DC
		{
			set{_IODCN_LC_BASE_EXTERNA_DC = value;}
			get{return _IODCN_LC_BASE_EXTERNA_DC;}
		}
		public double IODCN_LC_CLARO_DC
		{
			set{_IODCN_LC_CLARO_DC = value;}
			get{return _IODCN_LC_CLARO_DC;}
		}
		public string IODCC_RAZONES_DC
		{
			set{_IODCC_RAZONES_DC = value;}
			get{return _IODCC_RAZONES_DC;}
		}
		public string   IODCD_FECHA_NACE_CLIENTE_DC
		{
			set{_IODCD_FECHA_NACE_CLIENTE_DC = value;}
			get{return _IODCD_FECHA_NACE_CLIENTE_DC;}
		}
		//E76009 Fin
		
		//INICIO: PROY-20054-IDEA-23849
		public int IODCN_BURO_CREDITICIO
		{
			set{_IODCN_BURO_CREDITICIO = value;}
			get{return _IODCN_BURO_CREDITICIO;}
		}
		//FIN

	}
}
