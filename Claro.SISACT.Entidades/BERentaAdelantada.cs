using System;

namespace Claro.SisAct.Entidades
{
	public class BERentaAdelantada
	{

		public BERentaAdelantada()
		{			
		}
       
		private int _DranCodigo;
		private string _drac_tipo_ra;
		private string _drav_nro_asociado;
		private decimal _dran_importe_pago;
		private string _drav_origen;
		private string _drav_tipo_aplicacion;
		private string _drav_customer_id;
		private string _drav_documento_fi;
		private decimal _dran_total_amount;
		private decimal _dran_open_amount;
		private string _drav_referencia_sap;
		private string _drav_nro_recibo;
		private string _drav_cuenta_sap;
		private string _drav_enviar_referencia;
		private string _drav_moneda;
		private string _drav_clase_documento;
		private string _drav_llave_pago;
		private string _drav_documento_cliente;
		private string _drav_linea;
		private string _drav_recibo_aplicar;
		private DateTime _drad_fecha_emision;
		private DateTime _drad_fecha_vencimiento;
		private string _dran_usuario_crea;
		private DateTime _drad_fecha_crea;
		private string _dran_usuario_mod;
		private DateTime _drad_fecha_mod;
		private int _dran_solin_codigo;
		private int _dran_estado_pago;
		private string _codigo_pago;
		private string _cliente;
		private string _contacto;
		private string _direccion;
		private string _distrito;
		private string _provincia;
		private string _departamento;
		private string _telefono_cliente;
		private string _punto_venta;
		private string _Tipo_Documento_Cliente;

		private string _DRAV_NROGENERADO_SAP;
		private string _DRAV_CUENTA_BSCS;
		private int _DRAN_IDCONTRATO_SI;
		private string _DRAV_RAZONSOCIAL_NOMBRE;
		private string _DRAV_COD_PDV;
		private string _DRAV_CANAL_PDV;
		private string _Drav_Cod_Cli_Sap_Pdv;
		private decimal _Dran_Igv_Dra;
		public string _Sis_Sku_Dra;
		public string _Ticket_Venta_Dra;
		public string _Pediv_PedidoAlta;

		public string Pediv_PedidoAlta
		{
			get { return _Pediv_PedidoAlta; }
			set { _Pediv_PedidoAlta = value; }
		}

		public string Ticket_Venta_Dra
		{
			get { return _Ticket_Venta_Dra; }
			set { _Ticket_Venta_Dra = value; }
		}

		public string Sis_Sku_Dra
		{
			get { return _Sis_Sku_Dra; }
			set { _Sis_Sku_Dra = value; }
		}

		public decimal Dran_Igv_Dra
		{
			get { return _Dran_Igv_Dra; }
			set { _Dran_Igv_Dra = value; }
		}

		public string Tipo_Documento_Cliente
		{
			get { return _Tipo_Documento_Cliente; }
			set { _Tipo_Documento_Cliente = value; }
		}

		public int DranCodigo
		{
			get { return _DranCodigo; }
			set { _DranCodigo = value; }
		}
        
		public string Drac_tipo_ra
		{
			get { return _drac_tipo_ra; }
			set { _drac_tipo_ra = value; }
		}        

		public string Drav_nro_asociado
		{
			get { return _drav_nro_asociado; }
			set { _drav_nro_asociado = value; }
		}
        
		public decimal Dran_importe_pago
		{
			get { return _dran_importe_pago; }
			set { _dran_importe_pago = value; }
		}
        
		public string Drav_origen
		{
			get { return _drav_origen; }
			set { _drav_origen = value; }
		}
        
		public string Drav_tipo_aplicacion
		{
			get { return _drav_tipo_aplicacion; }
			set { _drav_tipo_aplicacion = value; }
		}
        
		public string Drav_customer_id
		{
			get { return _drav_customer_id; }
			set { _drav_customer_id = value; }
		}
        
		public string Drav_documento_fi
		{
			get { return _drav_documento_fi; }
			set { _drav_documento_fi = value; }
		}
        
		public decimal Dran_total_amount
		{
			get { return _dran_total_amount; }
			set { _dran_total_amount = value; }
		}
        
		public decimal Dran_open_amount
		{
			get { return _dran_open_amount; }
			set { _dran_open_amount = value; }
		}
        
		public string Drav_referencia_sap
		{
			get { return _drav_referencia_sap; }
			set { _drav_referencia_sap = value; }
		}
        
		public string Drav_nro_recibo
		{
			get { return _drav_nro_recibo; }
			set { _drav_nro_recibo = value; }
		}
        
		public string Drav_cuenta_sap
		{
			get { return _drav_cuenta_sap; }
			set { _drav_cuenta_sap = value; }
		}
        
		public string Drav_enviar_referencia
		{
			get { return _drav_enviar_referencia; }
			set { _drav_enviar_referencia = value; }
		}
        
		public string Drav_moneda
		{
			get { return _drav_moneda; }
			set { _drav_moneda = value; }
		}
        
		public string Drav_clase_documento
		{
			get { return _drav_clase_documento; }
			set { _drav_clase_documento = value; }
		}
        
		public string Drav_llave_pago
		{
			get { return _drav_llave_pago; }
			set { _drav_llave_pago = value; }
		}
        
		public string Drav_documento_cliente
		{
			get { return _drav_documento_cliente; }
			set { _drav_documento_cliente = value; }
		}
        
		public string Drav_linea
		{
			get { return _drav_linea; }
			set { _drav_linea = value; }
		}
        
		public string Drav_recibo_aplicar
		{
			get { return _drav_recibo_aplicar; }
			set { _drav_recibo_aplicar = value; }
		}
        
		public DateTime Drad_fecha_emision
		{
			get { return _drad_fecha_emision; }
			set { _drad_fecha_emision = value; }
		}
        
		public DateTime Drad_fecha_vencimiento
		{
			get { return _drad_fecha_vencimiento; }
			set { _drad_fecha_vencimiento = value; }
		}
        
		public string Dran_usuario_crea
		{
			get { return _dran_usuario_crea; }
			set { _dran_usuario_crea = value; }
		}
        
		public DateTime Drad_fecha_crea
		{
			get { return _drad_fecha_crea; }
			set { _drad_fecha_crea = value; }
		}
        
		public string Dran_usuario_mod
		{
			get { return _dran_usuario_mod; }
			set { _dran_usuario_mod = value; }
		}        

		public DateTime Drad_fecha_mod
		{
			get { return _drad_fecha_mod; }
			set { _drad_fecha_mod = value; }
		}        

		public int Dran_solin_codigo
		{
			get { return _dran_solin_codigo; }
			set { _dran_solin_codigo = value; }
		}        

		public int Dran_estado_pago
		{
			get { return _dran_estado_pago; }
			set { _dran_estado_pago = value; }
		}
        
		public string Codigo_pago
		{
			get { return _codigo_pago; }
			set { _codigo_pago = value; }
		}

		public string Cliente
		{
			get { return _cliente; }
			set { _cliente = value; }
		}
        
		public string Contacto
		{
			get { return _contacto; }
			set { _contacto = value; }
		}
        
		public string Direccion
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
        
		public string Distrito
		{
			get { return _distrito; }
			set { _distrito = value; }
		}
        
		public string Provincia
		{
			get { return _provincia; }
			set { _provincia = value; }
		}
        
		public string Departamento
		{
			get { return _departamento; }
			set { _departamento = value; }
		}
        
		public string Telefono_cliente
		{
			get { return _telefono_cliente; }
			set { _telefono_cliente = value; }
		}
        
		public string Punto_venta
		{
			get { return _punto_venta; }
			set { _punto_venta = value; }
		}

		public string DRAV_NROGENERADO_SAP
		{
			get { return _DRAV_NROGENERADO_SAP; }
			set { _DRAV_NROGENERADO_SAP = value; }
		}        

		public string DRAV_CUENTA_BSCS
		{
			get { return _DRAV_CUENTA_BSCS; }
			set { _DRAV_CUENTA_BSCS = value; }
		}        

		public int DRAN_IDCONTRATO_SI
		{
			get { return _DRAN_IDCONTRATO_SI; }
			set { _DRAN_IDCONTRATO_SI = value; }
		}            

		public string DRAV_RAZONSOCIAL_NOMBRE
		{
			get { return _DRAV_RAZONSOCIAL_NOMBRE; }
			set { _DRAV_RAZONSOCIAL_NOMBRE = value; }
		}        

		public string DRAV_COD_PDV
		{
			get { return _DRAV_COD_PDV; }
			set { _DRAV_COD_PDV = value; }
		}        

		public string DRAV_CANAL_PDV
		{
			get { return _DRAV_CANAL_PDV; }
			set { _DRAV_CANAL_PDV = value; }
		}        

		public string Drav_Cod_Cli_Sap_Pdv
		{
			get { return _Drav_Cod_Cli_Sap_Pdv; }
			set { _Drav_Cod_Cli_Sap_Pdv = value; }
		}

	}
}
