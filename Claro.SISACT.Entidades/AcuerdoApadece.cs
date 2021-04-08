using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AcuerdoApadece.
	/// </summary>
	public class AcuerdoApadece
	{
		private string _ACUERDO_ID;
		private string _NRO_TELEFONO;
		private string _CO_ID;
		private string _CUSTOMER_ID;
		private DateTime _FECHA_INICIO;
		private DateTime _FECHA_FIN;
		private string _COD_PLAZO_ACUERDO;
		private string _PLAZO_ACUERDO;
		private int _VIGENCIA_MESES;
		private string _COD_ESTADO_ACUERDO;
		private string _ESTADO_ACUERDO;
		private double _MONTO_REINTEGRO;
		private int _NRO_MESES_PENDIENTE;
		private int _NRO_DIAS_PENALIDAD;



		//nuevo apadece jmori

		private string _NCA_IDACUERDO;
		private string _NCA_FECHA_ACUERDO;
		private string _NCA_TIPO_TRANSACCION; 
		private string _NCA_COD_PLAZO_ACUERDO; 
		private string _NCA_TIPO_ACUERDO; 
		private string _NCA_VIGENCIA_MESES; 
		private string _NCA_COD_EQUIPO;
		private string _NCA_SERIE_EQUIPO; 
		private string _NCA_ICCID; 
		private string _NCA_PRECIO_LISTA; 
		private string _NCA_PRECIO_VENTA; 
		private string _NCA_FACT_MIN_ESPERADA; 
		private string _NCA_CF_TOTAL_ACUMULAD; 
		private string _NCA_MONTO_APADECE; 
		private string _NCA_CO_ID; 
		private string _NCA_CUSTOMER_ID;
		private string _NCA_CUSTOMER_CODE; 
		private string _NCA_MSISDN;
		private string _NCA_SUBSIDIO;
		private string _NCA_CF_VIGENTE;
		private string _NCA_MONTO_APADECE_ANTERIOR; 
		private string _NCA_NOMBRE_EQUIPO; 
		private string _NCA_SERIE_EQUIPO2;
		private string _NCA_COD_PLAN;
		private string _NCA_COD_PLAN_ANTERIOR; 
		private string _NCA_COD_TIPO_PLAN ;
		private string _NCA_DESCRIPCION_PLAN; 

		public string NCA_IDACUERDO
		{
			set { _NCA_IDACUERDO= value;}
			get { return _NCA_IDACUERDO;}
		}

		public string NCA_FECHA_ACUERDO
		{
			set { _NCA_FECHA_ACUERDO= value;}
			get { return _NCA_FECHA_ACUERDO;}
		}

		public string NCA_TIPO_TRANSACCION
		{
			set { _NCA_TIPO_TRANSACCION = value;}
			get { return _NCA_TIPO_TRANSACCION;}
		}

		public string NCA_COD_PLAZO_ACUERDO
		{
			set { _NCA_COD_PLAZO_ACUERDO= value;}
			get { return _NCA_COD_PLAZO_ACUERDO;}
		}

		public string NCA_TIPO_ACUERDO
		{
			set { _NCA_TIPO_ACUERDO= value;}
			get { return _NCA_TIPO_ACUERDO;}
		}

		public string NCA_VIGENCIA_MESES
		{
			set { _NCA_VIGENCIA_MESES= value;}
			get { return _NCA_VIGENCIA_MESES;}
		}

		public string NCA_COD_EQUIPO
		{
			set { _NCA_COD_EQUIPO= value;}
			get { return _NCA_COD_EQUIPO;}
		}

		public string NCA_SERIE_EQUIPO
		{
			set { _NCA_SERIE_EQUIPO = value;}
			get { return _NCA_SERIE_EQUIPO;}
		}

		public string NCA_ICCID
		{
			set { _NCA_ICCID= value;}
			get { return _NCA_ICCID;}
		}

		public string NCA_PRECIO_LISTA
		{
			set { _NCA_PRECIO_LISTA= value;}
			get { return _NCA_PRECIO_LISTA;}
		}

		public string NCA_PRECIO_VENTA
		{
			set { _NCA_PRECIO_VENTA= value;}
			get { return _NCA_PRECIO_VENTA;}
		}
		public string NCA_FACT_MIN_ESPERADA
		{
			set { _NCA_FACT_MIN_ESPERADA= value;}
			get { return _NCA_FACT_MIN_ESPERADA;}
		}
		public string NCA_CF_TOTAL_ACUMULAD
		{
			set { _NCA_CF_TOTAL_ACUMULAD= value;}
			get { return _NCA_CF_TOTAL_ACUMULAD;}
		}
		public string NCA_MONTO_APADECE
		{
			set { _NCA_MONTO_APADECE= value;}
			get { return _NCA_MONTO_APADECE;}
		}

		public string NCA_CO_ID
		{
			set { _NCA_CO_ID= value;}
			get { return _NCA_CO_ID;}
		}

		public string NCA_CUSTOMER_ID
		{
			set { _NCA_CUSTOMER_ID= value;}
			get { return _NCA_CUSTOMER_ID;}
		}

		
		public string NCA_CUSTOMER_CODE
		{
			set { _NCA_CUSTOMER_CODE= value;}
			get { return _NCA_CUSTOMER_CODE;}
		}
		
		public string NCA_MSISDN
		{
			set { _NCA_MSISDN= value;}
			get { return _NCA_MSISDN;}
		}
		
		public string NCA_SUBSIDIO
		{
			set { _NCA_SUBSIDIO= value;}
			get { return _NCA_SUBSIDIO;}
		}
		public string NCA_CF_VIGENTE
		{
			set { _NCA_CF_VIGENTE= value;}
			get { return _NCA_CF_VIGENTE;}
		}
		public string NCA_MONTO_APADECE_ANTERIOR
		{
			set { _NCA_MONTO_APADECE_ANTERIOR= value;}
			get { return _NCA_MONTO_APADECE_ANTERIOR;}
		}
		public string NCA_NOMBRE_EQUIPO
		{
			set { _NCA_NOMBRE_EQUIPO= value;}
			get { return _NCA_NOMBRE_EQUIPO;}
		}
		public string NCA_SERIE_EQUIPO2
		{
			set { _NCA_SERIE_EQUIPO2= value;}
			get { return _NCA_SERIE_EQUIPO2;}
		}
		public string NCA_COD_PLAN
		{
			set { _NCA_COD_PLAN= value;}
			get { return _NCA_COD_PLAN;}
		}

		public string NCA_COD_PLAN_ANTERIOR
		{
			set { _NCA_COD_PLAN_ANTERIOR= value;}
			get { return _NCA_COD_PLAN_ANTERIOR;}
		}
		public string NCA_COD_TIPO_PLAN
		{
			set { _NCA_COD_TIPO_PLAN= value;}
			get { return _NCA_COD_TIPO_PLAN;}
		}
		public string NCA_DESCRIPCION_PLAN
		{
			set { _NCA_DESCRIPCION_PLAN= value;}
			get { return _NCA_DESCRIPCION_PLAN;}
		}

		//end jmori


		public AcuerdoApadece()
		{
			
		}

		public string ACUERDO_ID
		{
			set { _ACUERDO_ID= value;}
			get { return _ACUERDO_ID;}
		}

		public string NRO_TELEFONO
		{
			set { _NRO_TELEFONO= value;}
			get { return _NRO_TELEFONO;}
		}

		public string CO_ID
		{
			set { _CO_ID= value;}
			get { return _CO_ID;}
		}

		public string CUSTOMER_ID
		{
			set { _CUSTOMER_ID= value;}
			get { return _CUSTOMER_ID;}
		}

		public DateTime FECHA_INICIO
		{
			set { _FECHA_INICIO= value;}
			get { return _FECHA_INICIO;}
		}

		public DateTime FECHA_FIN
		{
			set { _FECHA_FIN= value;}
			get { return _FECHA_FIN;}
		}

		public string COD_PLAZO_ACUERDO
		{
			set { _COD_PLAZO_ACUERDO= value;}
			get { return _COD_PLAZO_ACUERDO;}
		}

		public string PLAZO_ACUERDO
		{
			set { _PLAZO_ACUERDO= value;}
			get { return _PLAZO_ACUERDO;}
		}

		public int VIGENCIA_MESES
		{
			set { _VIGENCIA_MESES= value;}
			get { return _VIGENCIA_MESES;}
		}

		public string COD_ESTADO_ACUERDO
		{
			set { _COD_ESTADO_ACUERDO= value;}
			get { return _COD_ESTADO_ACUERDO;}
		}

		public string ESTADO_ACUERDO
		{
			set { _ESTADO_ACUERDO= value;}
			get { return _ESTADO_ACUERDO;}
		}

		public double MONTO_REINTEGRO
		{
			set { _MONTO_REINTEGRO= value;}
			get { return _MONTO_REINTEGRO;}
		}

		public int NRO_MESES_PENDIENTE
		{
			set { _NRO_MESES_PENDIENTE= value;}
			get { return _NRO_MESES_PENDIENTE;}
		}

		public int NRO_DIAS_PENALIDAD
		{
			set { _NRO_DIAS_PENALIDAD= value;}
			get { return _NRO_DIAS_PENALIDAD;}
		}

		
	}
}

