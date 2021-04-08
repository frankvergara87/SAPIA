using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Cliente.
	/// </summary>
	public class Cliente_Cons:IComparable
	{
		private int _CANTIDAD_CORTE_PARCIAL;
		private int _CANTIDAD_CORTE_TOTAL;
		private int _CANTIDAD_CORTE_BAJAS ;
		private int _CANTIDAD_LINEAS_ACTIVAS ;
		private int _CANTIDAD_LINEAS_SUSPENDIDAS ;
		private int _BLOQUEOS_PEDIDO_CLIENTE ;
		private int _BLOQUEOS_COBRANZA ;
		private int _BLOQUEOS_FINANCIAMIENTO ;
		private int _BLOQUEOS_FRAUDE ;
		private int _BLOQUEOS_LIMITE_CREDITO ;
		private int _BLOQUEOS_ROBO ;
		private int _LINEAS_MAYOR_N_DIAS;
		private int _LINEAS_MENOR_N_DIAS;
		private Int64 _LINEAS;
		//wsotomayor
		private Int64 _CUSTOMER_ID;
		private int _ID_TIP_DOC;

		private double _DEUDA;
		private double _ANTIGUEDAD_CLIENTE;
		private double _ANTIGUEDAD;
		//wsotomayor
		private double _FACT_PROM;
		private double _MONTO_VENC;
		private double _MONTO_PEND;
		private double _FACT_SEC;
		private double _MONTO_CAST;
		private double _PROM_FACT;

		private string _NUMERO_DOCUMENTO;
		private string _ID_CLIENTE;
		private string _RAZON_SOCIAL;
		private string _NOMBRES;
		private string _APELLIDO_PATERNO;
		private string _APELLIDO_MATERNO;
		private string _CODIGO_BLOQUEO;


		//wsotomayor
		private string _DIRECCION_FACTURA;
		private string _CONTACTO_FACTURA;
		private string _TELEFONO_DOMICILIO;
		private string _DIRECCION;
		private string _DISTRITO;
		private string _APELLIDOS;
		private string _TIP_DOC;
		private string _CUSTCODE;
		private string _RUC_DNI;
		//BETSY APAC		
		private string _FECHA_VENC;
		private string _DIAS_VENC;
		
		#region "TS-2009"
		private string _CO_ID;
		private string _FECHA_ACTIVACION;
		private string _ESTADO;
		private string _FEC_ESTADO;
		private string _PLAN_COD;
		private string _PLAN_DES;	
		private string _SHORT_DESCRIPTION;
		private string _BLOQUEO;
		private string _FECHA_BLOQUEO;
		private string _MOTIVO_BLOQUEO;
		private string _MOTIVO_ESTADO;
		#endregion
	
		// JAZ
		private string _NRO_CUENTA;
		private string _NRO_CONTRATO;
		private string _NRO_LINEA;
		private string _FECHA_ESTADO;
		private string _NRO_SEC;
		//


		public string NRO_CUENTA { set{_NRO_CUENTA = value;} get{ return _NRO_CUENTA;}}
		public string NRO_CONTRATO { set{_NRO_CONTRATO = value;} get{ return _NRO_CONTRATO;}}
		public string NRO_LINEA { set{_NRO_LINEA = value;} get{ return _NRO_LINEA;}}
		public string FECHA_ESTADO { set{_FECHA_ESTADO = value;} get{ return _FECHA_ESTADO;}}
		public string NRO_SEC { set{_NRO_SEC = value;} get{ return _NRO_SEC;}}

		#region "E75688"
		private string _afil_recibo_x_correo;
		private string _email;
		#endregion

		//Renovacion
		private string _ESTADO_LINEA;
		private string _TIPO_ESTADO;
		private string _DEUDA_VENCIDA_CUENTA;

		public Cliente_Cons()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
			
		}

		#region "Propiedades Publicas"


		public string ID_CLIENTE		{ set{_ID_CLIENTE = value;}		get{ return _ID_CLIENTE;}	}
		public string NUMERO_DOCUMENTO	{ set{_NUMERO_DOCUMENTO = value;}get{ return _NUMERO_DOCUMENTO;}}
		public string RAZON_SOCIAL		{ set{_RAZON_SOCIAL = value;}	 get{ return _RAZON_SOCIAL;}}
		public string NOMBRES			{ set{_NOMBRES = value;}		 get{ return _NOMBRES;}		}
		public string APELLIDO_PATERNO	{ set{_APELLIDO_PATERNO = value;}get{ return _APELLIDO_PATERNO;}}		
		public string APELLIDO_MATERNO	{ set{_APELLIDO_MATERNO= value;} get{ return _APELLIDO_MATERNO;}}
		public string DIRECCION_FACTURA	{ set{_DIRECCION_FACTURA= value;}get{ return _DIRECCION_FACTURA;}}	
		public string CONTACTO_FACTURA	{ set{_CONTACTO_FACTURA= value;} get{ return _CONTACTO_FACTURA;} }	
		public string TELEFONO_DOMICILIO{ set{_TELEFONO_DOMICILIO= value;}get{ return _TELEFONO_DOMICILIO;}}	
		public string FECHA_VENC		{ set{_FECHA_VENC= value;}		get{ return _FECHA_VENC;}	}	
		public string DIAS_VENC			{ set{_DIAS_VENC= value;}		get{ return _DIAS_VENC;}	}			
		public string CODIGO_BLOQUEO	{ set{_CODIGO_BLOQUEO= value;}	get{ return _CODIGO_BLOQUEO;}}
		public string CUSTCODE			{ set { _CUSTCODE= value;} get{ return _CUSTCODE;}}
		public string RUC_DNI			{ set { _RUC_DNI= value;} get{ return _RUC_DNI;}}		
		public string DIRECCION			{ set { _DIRECCION= value;} get{ return _DIRECCION;}}
		public string DISTRITO			{ set { _DISTRITO= value;} get{ return _DISTRITO;}}		
		public string APELLIDOS			{ set { _APELLIDOS= value;} get{ return _APELLIDOS;}}
		public string TIP_DOC			{ set { _TIP_DOC= value;} get{ return _TIP_DOC;}}
		
		#region "TS-JLR"

		public string CO_ID				{ set { _CO_ID= value;} get{ return _CO_ID;}}
		public string TELEFONO			{ set { _TELEFONO_DOMICILIO= value;} get{ return _TELEFONO_DOMICILIO;}}
		public string FECHA_ACTIVACION	{ set { _FECHA_ACTIVACION=  value;} get{ return _FECHA_ACTIVACION;}}
		
		public string FEC_ESTADO		{ set { _FEC_ESTADO= value.Substring(0,10);} get{ return _FEC_ESTADO;}}
		public string PLAN_COD			{ set { _PLAN_COD= value;} get{ return _PLAN_COD;}}
		public string PLAN_DES			{ set { _PLAN_DES= value;} get{ return _PLAN_DES;}}
		public string SHORT_DESCRIPTION	{ set { _SHORT_DESCRIPTION= value;} get{ return _SHORT_DESCRIPTION;}}
		public string BLOQUEO			{ set { _BLOQUEO= value;} get{ return _BLOQUEO;}}
		public string FECHA				{ set { _FECHA_BLOQUEO= value.Substring(0,10);} get{ return _FECHA_BLOQUEO;}}
		public string ESTADO			{ set { _ESTADO= value;} 
											get{
												string varReturn="";
												switch(_ESTADO)
												{
													case "a":varReturn="ACTIVO";
														break;
													case "d":varReturn="DESACTIVADO";
														break;
													case "s":varReturn="SUSPENDIDO";
														break;
												}
												return varReturn;}
										}
		public string MOTIVO_BLOQUEO	{ set { _MOTIVO_BLOQUEO= value;} get{ return _MOTIVO_BLOQUEO;}}
		public string MOTIVO_ESTADO	{ set { _MOTIVO_ESTADO= value;} get{ return _MOTIVO_ESTADO;}}


		#endregion



		public double DEUDA			{ set{_DEUDA = value;}			get{ return _DEUDA;}		}
		public double ANTIGUEDAD	{ set{_ANTIGUEDAD = value;}		get{ return _ANTIGUEDAD;}	}
		public double FACT_PROM		{ set { _FACT_PROM= value;} get{ return _FACT_PROM;}}
		public double MONTO_VENC	{ set {_MONTO_VENC = value;} get{ return _MONTO_VENC;}}
		public double MONTO_PEND	{ set { _MONTO_PEND= value;} get{ return _MONTO_PEND;}}
		public double FACT_SEC		{ set { _FACT_SEC= value;} get{ return _FACT_SEC;}}
		public double PROM_FACT		{ set { _PROM_FACT= value;} get{ return _PROM_FACT;}}	
		public double MONTO_CAST	{ set { _MONTO_CAST= value;} get{ return _MONTO_CAST;}}
		public double ANTIGUEDAD_CLIENTE{ set{_ANTIGUEDAD_CLIENTE= value;}get{ return _ANTIGUEDAD_CLIENTE;}}
		public Int64 LINEAS				{ set{_LINEAS = value;}			get{ return _LINEAS;}		}
		public Int64 CUSTOMER_ID		{ set {_CUSTOMER_ID = value;}	 get{ return _CUSTOMER_ID;}	}

		public int CANTIDAD_CORTE_PARCIAL	{set { _CANTIDAD_CORTE_PARCIAL= value;} get{ return _CANTIDAD_CORTE_PARCIAL;}}
		public int CANTIDAD_CORTE_TOTAL		{set { _CANTIDAD_CORTE_TOTAL= value;} get{ return _CANTIDAD_CORTE_TOTAL;}}
		public int CANTIDAD_CORTE_BAJAS		{set { _CANTIDAD_CORTE_BAJAS = value;} get{ return _CANTIDAD_CORTE_BAJAS ;}}
		public int CANTIDAD_LINEAS_ACTIVAS	{set { _CANTIDAD_LINEAS_ACTIVAS = value;} get{ return _CANTIDAD_LINEAS_ACTIVAS ;}}
		public int BLOQUEOS_PEDIDO_CLIENTE	{set { _BLOQUEOS_PEDIDO_CLIENTE = value;} get{ return _BLOQUEOS_PEDIDO_CLIENTE ;}}
		public int BLOQUEOS_COBRANZA		{set { _BLOQUEOS_COBRANZA = value;} get{ return _BLOQUEOS_COBRANZA ;}}
		public int BLOQUEOS_FINANCIAMIENTO	{set { _BLOQUEOS_FINANCIAMIENTO = value;} get{ return _BLOQUEOS_FINANCIAMIENTO ;}}
		public int BLOQUEOS_FRAUDE			{set { _BLOQUEOS_FRAUDE = value;} get{ return _BLOQUEOS_FRAUDE ;}}
		public int BLOQUEOS_LIMITE_CREDITO	{set { _BLOQUEOS_LIMITE_CREDITO= value;} get{ return _BLOQUEOS_LIMITE_CREDITO;}}
		public int BLOQUEOS_ROBO			{set { _BLOQUEOS_ROBO = value;} get{ return _BLOQUEOS_ROBO ;}}	
		public int LINEAS_MAYOR_N_DIAS		{set { _LINEAS_MAYOR_N_DIAS = value;} get{ return _LINEAS_MAYOR_N_DIAS ;}}	
		public int ID_TIP_DOC				{set { _ID_TIP_DOC= value;} get{ return _ID_TIP_DOC;}}
		public int LINEAS_MENOR_N_DIAS		{set { _LINEAS_MENOR_N_DIAS= value;} get{ return _LINEAS_MENOR_N_DIAS;}}	
		public int CANTIDAD_LINEAS_SUSPENDIDAS{set { _CANTIDAD_LINEAS_SUSPENDIDAS= value;} get{ return _CANTIDAD_LINEAS_SUSPENDIDAS;}}

		#region "E75688"
		public string AFIL_RECIBO_X_CORREO  {set { _afil_recibo_x_correo= value;} get{ return _afil_recibo_x_correo;}}
		public string EMAIL				{set { _email= value;} get{ return _email;}}	
		#endregion

		#endregion				

		//Renovacion
		public string ESTADO_LINEA { set{_ESTADO_LINEA = value;} get{ return _ESTADO_LINEA;}}
		public string TIPO_ESTADO { set{_TIPO_ESTADO = value;} get{ return _TIPO_ESTADO;}}
		public string DEUDA_VENCIDA_CUENTA { set{_DEUDA_VENCIDA_CUENTA = value;} get{ return _DEUDA_VENCIDA_CUENTA;}}

		#region IComparable Members

		public int CompareTo(Object objObjeto)
		{
			int ValorRetorno=0;
			Cliente objClienteComparado=(Cliente)objObjeto;
			if(objClienteComparado.CUSTOMER_ID==_CUSTOMER_ID)
			{
				ValorRetorno=1;
			}

			return ValorRetorno;
		}

		
		#endregion
	}
}
