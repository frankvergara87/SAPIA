using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Cliente.
	/// </summary>
	public class Cliente
	{
		private string _ID_CLIENTE;
		private double _DEUDA;
		private Int64 _LINEAS;
		private double _ANTIGUEDAD;
		private string _NUMERO_DOCUMENTO;
		private double _ANTIGUEDAD_CLIENTE;
		private string _RAZON_SOCIAL;
		private string _APELLIDO_PATERNO;
		private string _APELLIDO_MATERNO;
		private string _CODIGO_BLOQUEO;


		//wsotomayor
		private string _DIRECCION_FACTURA;
		private string _CONTACTO_FACTURA;
		private string _TELEFONO_DOMICILIO;
		//wsotomayor

		private Int64 _CUSTOMER_ID;
		private string _CUSTCODE;
		private string _RUC_DNI;
		private double _FACT_PROM;
		private double _MONTO_VENC;
		private double _MONTO_PEND;
		private double _FACT_SEC;
		private string _DIRECCION;
		private int _ID_TIP_DOC;
		private string _TIP_DOC;
		private double _MONTO_CAST;
		//BETSY APAC
		private string _FECHA_VENC;
		private string _DIAS_VENC;
		//FIN BETSY APAC		
		private string _PROVINCIA;

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
		private double _PROM_FACT;

		//INICIO - E75688
		private string _CHK_CORREO;
		private string _CORREO;	
		//FIN - E75688



		private string _NOMBRES;
		private string _APELLIDOS;
		private string _NRO_DOC;
		private string _TIPO_DOC;
		private string _NOMBRE_COMPLETO;
		private string _DOMICILIO;
		private string _ESTADO_CONTACTO;
		private string _TELEF_REFERENCIA;
		private string _CIUDAD;
		private string _FECHA_NAC;
		private string _LUGAR_NACIMIENTO_DES;
		private string _MOTIVO_REGISTRO;
		private string _USUARIO;
		private string _OBJID_CONTACTO;
		private int _FLAG_REGISTRADO;
		private string _MODALIDAD;
		private string _TELEFONO;
		private string _SEXO;
		private string _ESTADO_CIVIL;
		private string _OCUPACION;
		private string _CARGO;
		private string _FAX;
		private string _EMAIL;
		private string _DISTRITO;
		private string _ZIPCODE;
		private string _URBANIZACION;
		private string _DEPARTAMENTO;
		private string _REFERENCIA;
		private string _FLAG_EMAIL;
		private string _OBJID_SITE;
		private string _CUENTA;
		private string _SEGMENTO;
		private string _ROL_CONTACTO;
		private string _ESTADO_CONTRATO;
		private string _ESTADO_SITE;
		private string _S_NOMBRES;
		private string _S_APELLIDOS;
		private DateTime _FECHA_ACT;
		private string _PUNTO_VENTA;
		private string _CANT_REG;
		private string _FUNCION;

		public Cliente()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public string ID_CLIENTE
		{
			set{_ID_CLIENTE = value;}
			get{ return _ID_CLIENTE;}
		}
		public double DEUDA
		{
			set{_DEUDA = value;}
			get{ return _DEUDA;}
		}
		public Int64 LINEAS
		{
			set{_LINEAS = value;}
			get{ return _LINEAS;}
		}
		public double ANTIGUEDAD
		{
			set{_ANTIGUEDAD = value;}
			get{ return _ANTIGUEDAD;}
		}
		public string NUMERO_DOCUMENTO
		{
			set{_NUMERO_DOCUMENTO = value;}
			get{ return _NUMERO_DOCUMENTO;}
		}
		public double ANTIGUEDAD_CLIENTE
		{
			set{_ANTIGUEDAD_CLIENTE= value;}
			get{ return _ANTIGUEDAD_CLIENTE;}
		}
		public string RAZON_SOCIAL
		{
			set{_RAZON_SOCIAL = value;}
			get{ return _RAZON_SOCIAL;}
		}
		public string APELLIDO_PATERNO
		{
			set{_APELLIDO_PATERNO = value;}
			get{ return _APELLIDO_PATERNO;}
		}		
		public string APELLIDO_MATERNO
		{
			set{_APELLIDO_MATERNO= value;}
			get{ return _APELLIDO_MATERNO;}
		}
		
		public string DIRECCION_FACTURA
		{
			set{_DIRECCION_FACTURA= value;}
			get{ return _DIRECCION_FACTURA;}
		}	
		public string CONTACTO_FACTURA
		{
			set{_CONTACTO_FACTURA= value;}
			get{ return _CONTACTO_FACTURA;}
		}	
		public string TELEFONO_DOMICILIO
		{
			set{_TELEFONO_DOMICILIO= value;}
			get{ return _TELEFONO_DOMICILIO;}
		}	

		public Int64 CUSTOMER_ID {
			set {_CUSTOMER_ID = value;} 
			get{ return _CUSTOMER_ID;}
		}
		//BETSY APAC
		public string FECHA_VENC
		{
			set{_FECHA_VENC= value;}
			get{ return _FECHA_VENC;}
		}	
		public string DIAS_VENC
		{
			set{_DIAS_VENC= value;}
			get{ return _DIAS_VENC;}
		}			
		public string CODIGO_BLOQUEO
		{
			set{_CODIGO_BLOQUEO= value;}
			get{ return _CODIGO_BLOQUEO;}
		}
		//FIN BETSY APAC
		public string CUSTCODE{set { _CUSTCODE= value;} get{ return _CUSTCODE;}}
		public string RUC_DNI{set { _RUC_DNI= value;} get{ return _RUC_DNI;}}		
		public double FACT_PROM{set { _FACT_PROM= value;} get{ return _FACT_PROM;}}
		public double MONTO_VENC{set {_MONTO_VENC = value;} get{ return _MONTO_VENC;}}
		public double MONTO_PEND{set { _MONTO_PEND= value;} get{ return _MONTO_PEND;}}
		public double FACT_SEC{set { _FACT_SEC= value;} get{ return _FACT_SEC;}}
		public string DIRECCION{set { _DIRECCION= value;} get{ return _DIRECCION;}}
		public int ID_TIP_DOC{set { _ID_TIP_DOC= value;} get{ return _ID_TIP_DOC;}}
		public string TIP_DOC{set { _TIP_DOC= value;} get{ return _TIP_DOC;}}
		public double MONTO_CAST{set { _MONTO_CAST= value;} get{ return _MONTO_CAST;}}

		public int CANTIDAD_CORTE_PARCIAL{set { _CANTIDAD_CORTE_PARCIAL= value;} get{ return _CANTIDAD_CORTE_PARCIAL;}}
		public int CANTIDAD_CORTE_TOTAL{set { _CANTIDAD_CORTE_TOTAL= value;} get{ return _CANTIDAD_CORTE_TOTAL;}}
		public int CANTIDAD_CORTE_BAJAS {set { _CANTIDAD_CORTE_BAJAS = value;} get{ return _CANTIDAD_CORTE_BAJAS ;}}
		public int CANTIDAD_LINEAS_ACTIVAS {set { _CANTIDAD_LINEAS_ACTIVAS = value;} get{ return _CANTIDAD_LINEAS_ACTIVAS ;}}
		public int CANTIDAD_LINEAS_SUSPENDIDAS {set { _CANTIDAD_LINEAS_SUSPENDIDAS= value;} get{ return _CANTIDAD_LINEAS_SUSPENDIDAS;}}
		public int BLOQUEOS_PEDIDO_CLIENTE {set { _BLOQUEOS_PEDIDO_CLIENTE = value;} get{ return _BLOQUEOS_PEDIDO_CLIENTE ;}}
		public int BLOQUEOS_COBRANZA {set { _BLOQUEOS_COBRANZA = value;} get{ return _BLOQUEOS_COBRANZA ;}}
		
		public int BLOQUEOS_FINANCIAMIENTO {set { _BLOQUEOS_FINANCIAMIENTO = value;} get{ return _BLOQUEOS_FINANCIAMIENTO ;}}
		public int BLOQUEOS_FRAUDE {set { _BLOQUEOS_FRAUDE = value;} get{ return _BLOQUEOS_FRAUDE ;}}
		public int BLOQUEOS_LIMITE_CREDITO{set { _BLOQUEOS_LIMITE_CREDITO= value;} get{ return _BLOQUEOS_LIMITE_CREDITO;}}
		public int BLOQUEOS_ROBO {set { _BLOQUEOS_ROBO = value;} get{ return _BLOQUEOS_ROBO ;}}	
		public int LINEAS_MAYOR_N_DIAS {set { _LINEAS_MAYOR_N_DIAS = value;} get{ return _LINEAS_MAYOR_N_DIAS ;}}	
		public double PROM_FACT{set { _PROM_FACT= value;} get{ return _PROM_FACT;}}	
		public int LINEAS_MENOR_N_DIAS{set { _LINEAS_MENOR_N_DIAS= value;} get{ return _LINEAS_MENOR_N_DIAS;}}	
				
		//INICIO -  E75688
		public string CHK_CORREO               {set { _CHK_CORREO= value;} get{ return _CHK_CORREO;}}
		public string CORREO				{set { _CORREO= value;} get{ return _CORREO;}}	
		//FIN  - E75688
		


		public string NOMBRES{set { _NOMBRES= value;} get{ return _NOMBRES;}}	
		public string APELLIDOS{set { _APELLIDOS= value;} get{ return _APELLIDOS;}}	
		public string NRO_DOC{set { _NRO_DOC= value;} get{ return _NRO_DOC;}}	
		public string TIPO_DOC{set { _TIPO_DOC= value;} get{ return _TIPO_DOC;}}	
		public string NOMBRE_COMPLETO{set { _NOMBRE_COMPLETO= value;} get{ return _NOMBRE_COMPLETO;}}	
		public string ESTADO_CONTACTO{set { _ESTADO_CONTACTO= value;} get{ return _ESTADO_CONTACTO;}}	
		public string TELEF_REFERENCIA{set { _TELEF_REFERENCIA= value;} get{ return _TELEF_REFERENCIA;}}	
		public string CIUDAD{set { _CIUDAD= value;} get{ return _CIUDAD;}}	
		public string FECHA_NAC{set { _FECHA_NAC= value;} get{ return _FECHA_NAC;}}	
		public string LUGAR_NACIMIENTO_DES{set { _LUGAR_NACIMIENTO_DES= value;} get{ return _LUGAR_NACIMIENTO_DES;}}	
		public string DOMICILIO{set { _DOMICILIO= value;} get{ return _DOMICILIO;}}
		public string MOTIVO_REGISTRO{set { _MOTIVO_REGISTRO= value;} get{ return _MOTIVO_REGISTRO;}}
		public string USUARIO{set { _USUARIO= value;} get{ return _USUARIO;}}
		public string OBJID_CONTACTO{set { _OBJID_CONTACTO= value;} get{ return _OBJID_CONTACTO;}}	
		public int FLAG_REGISTRADO{set { _FLAG_REGISTRADO= value;} get{ return _FLAG_REGISTRADO;}}	
		public string MODALIDAD{set { _MODALIDAD= value;} get{ return _MODALIDAD;}}	
		public string TELEFONO{set { _TELEFONO= value;} get{ return _TELEFONO;}}	
		public string SEXO{set { _SEXO= value;} get{ return _SEXO;}}	
		public string ESTADO_CIVIL{set { _ESTADO_CIVIL= value;} get{ return _ESTADO_CIVIL;}}	
		public string OCUPACION{set { _OCUPACION= value;} get{ return _OCUPACION;}}	
		public string CARGO{set { _CARGO= value;} get{ return _CARGO;}}	
		public string FAX{set { _FAX= value;} get{ return _FAX;}}	
		public string EMAIL{set { _EMAIL= value;} get{ return _EMAIL;}}	
		public string DISTRITO{set { _DISTRITO= value;} get{ return _DISTRITO;}}	
		public string ZIPCODE{set { _ZIPCODE= value;} get{ return _ZIPCODE;}}	
		public string URBANIZACION{set { _URBANIZACION= value;} get{ return _URBANIZACION;}}	
		public string DEPARTAMENTO{set { _DEPARTAMENTO= value;} get{ return _DEPARTAMENTO;}}	
		public string REFERENCIA{set { _REFERENCIA= value;} get{ return _REFERENCIA;}}	
		public string FLAG_EMAIL{set { _FLAG_EMAIL= value;} get{ return _FLAG_EMAIL;}}	
		public string OBJID_SITE{set { _OBJID_SITE= value;} get{ return _OBJID_SITE;}}	
		public string CUENTA{set { _CUENTA= value;} get{ return _CUENTA;}}	
		public string SEGMENTO{set { _SEGMENTO= value;} get{ return _SEGMENTO;}}	
		public string ROL_CONTACTO{set { _ROL_CONTACTO= value;} get{ return _ROL_CONTACTO;}}	
		public string ESTADO_CONTRATO{set { _ESTADO_CONTRATO= value;} get{ return _ESTADO_CONTRATO;}}	
		public string ESTADO_SITE{set { _ESTADO_SITE= value;} get{ return _ESTADO_SITE;}}	
		public string S_NOMBRES{set { _S_NOMBRES= value;} get{ return _S_NOMBRES;}}	
		public string S_APELLIDOS{set { _S_APELLIDOS= value;} get{ return _S_APELLIDOS;}}	
		public DateTime FECHA_ACT{set { _FECHA_ACT= value;} get{ return _FECHA_ACT;}}	
		public string PUNTO_VENTA{set { _PUNTO_VENTA= value;} get{ return _PUNTO_VENTA;}}	
		public string CANT_REG{set { _CANT_REG= value;} get{ return _CANT_REG;}}	
		public string FUNCION{set { _FUNCION= value;} get{ return _FUNCION;}}	
		public string PROVINCIA{set{ _PROVINCIA = value; }get{ return _PROVINCIA; }}

		
	}
}
