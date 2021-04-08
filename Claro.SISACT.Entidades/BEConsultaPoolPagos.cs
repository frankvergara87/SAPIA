using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for BEConsultaPoolPagos.
	/// </summary>
	public class BEConsultaPoolPagos
	{
		public BEConsultaPoolPagos()
		{
		}
		private string _PEDII_NROINTERNO_PEDIDO;
		private string _STATUS;
		private string _SOCIEDAD;
		private string _PEDIC_NRO_FACTURA;
		private string _PEDIC_TIPO_VENTA;
		private string _CLASEFACTURA;
		private string _CLASECOMPROBANTE;
		private string _INDICADOR_PAGO ;
		private string _FACTURAANULADA ;
		private DateTime _PAGOD_FECHA_CONTAB ;
		private string _TELEFONO ;
		private string _PEDIV_NOMBRECLIENTE ;
		private string _CLIEC_CLIENTE ;
		private string _PEDIC_MONEDA ;
		private int _PEDIN_NRO_CUOTAS ;
		private decimal _INPAN_TOTALMERCADERIA;
		private decimal _INPAN_TOTALIMPUESTO;
		private decimal _INPAN_TOTALDOCUMENTO;
		private decimal _PEDIN_PAGO;
		private decimal _PEDIN_SALDO;
		private string _PEDIV_DESCCLASEFACTURA;
		private string _COMPC_CODIGOSUNAT;
		private string _PEDIV_HORA;
		private string _PEDIV_SALIDA_PEDIDO ;
		private int    _PEDIN_PEDIDOALTA ;
        private string _NroSEC;  
		private string _FLAG;
		private DateTime _FECHA_PAGO;
	    private string _NRO_CONTRATO;
        private string _UTILIZACION_DES;
		private decimal _NETO;
		private string _NRO_DEP_GARANTIA;
		private string  _NRO_REF_DEP_GAR;
		private string _FLAG_REPOSICION;
        private string _ORIGEN;
		private string _CODTIPOOPERACION;




		public string CODTIPOOPERACION
		{
			set{_CODTIPOOPERACION = value;}
			get{ return _CODTIPOOPERACION;}
		}
		public string NRO_CONTRATO
		{
			set{_NRO_CONTRATO = value;}
			get{ return _NRO_CONTRATO;}
		}
		public string ORIGEN
		{
			set{_ORIGEN = value;}
			get{ return _ORIGEN;}
		}
		public string UTILIZACION_DES
		{
			set{_UTILIZACION_DES = value;}
			get{ return _UTILIZACION_DES;}
		}
		public decimal NETO
		{
			set{_NETO = value;}
			get{ return _NETO;}
		}
		public string NRO_DEP_GARANTIA
		{
			set{_NRO_DEP_GARANTIA = value;}
			get{ return _NRO_DEP_GARANTIA;}
		}

		public string NRO_REF_DEP_GAR
		{
			set{_NRO_REF_DEP_GAR = value;}
			get{ return _NRO_REF_DEP_GAR;}
		}
		public string FLAG_REPOSICION
		{
			set{_FLAG_REPOSICION = value;}
			get{ return _FLAG_REPOSICION;}
		}
		public string NRO_SEC
		{
			set{_NroSEC = value;}
			get{ return _NroSEC;}
		}
		public string FLAG
		{
			set{_FLAG = value;}
			get{ return _FLAG;}
		}
		public string DOCUMENTO_SAP
		{
			set{_PEDII_NROINTERNO_PEDIDO = value;}
			get{ return _PEDII_NROINTERNO_PEDIDO;}
		}
		public string STATUS 
		{
			set{_STATUS = value;}
			get{ return _STATUS;}
		}
		public string SOCIEDAD 
		{
			set{_SOCIEDAD = value;}
			get{ return _SOCIEDAD;}
		}
		public string PEDIC_NRO_FACTURA
		{
			set{_PEDIC_NRO_FACTURA= value;}
			get{ return _PEDIC_NRO_FACTURA;}
		}
		public string PEDIC_TIPO_VENTA
		{
			set{_PEDIC_TIPO_VENTA = value;}
			get{ return _PEDIC_TIPO_VENTA;}
		}
		public string CLASE_FACTURA
		{
			set{_CLASEFACTURA = value;}
			get{ return _CLASEFACTURA;}
		}
		public string CLASECOMPROBANTE 
		{
			set{_CLASECOMPROBANTE = value;}
			get{ return _CLASECOMPROBANTE;}
		}
		public string INDICADOR_PAGO
		{
			set{_INDICADOR_PAGO = value;}
			get{ return _INDICADOR_PAGO;}
		}
		public string FACTURAANULADA
		{
			set{_FACTURAANULADA = value;}
			get{ return _FACTURAANULADA;}
		}
		public DateTime FECHA
		{
			set{_PAGOD_FECHA_CONTAB = value;}
			get{ return _PAGOD_FECHA_CONTAB;}
		}
		public string NRO_CELULAR
		{
			set{_TELEFONO = value;}
			get{ return _TELEFONO;}
		}
		public string NOMBRE_CLIENTE
		{
			set{_PEDIV_NOMBRECLIENTE = value;}
			get{ return _PEDIV_NOMBRECLIENTE;}
		}
		public string CLIEC_CLIENTE
		{
			set{_CLIEC_CLIENTE = value;}
			get{ return _CLIEC_CLIENTE;}
		}
		public string MONEDA
		{
			set{_PEDIC_MONEDA = value;}
			get{ return _PEDIC_MONEDA;}
		}
		public int CUOTAS
		{
			set{_PEDIN_NRO_CUOTAS = value;}
			get{ return _PEDIN_NRO_CUOTAS;}
		}
		public decimal INPAN_TOTALMERCADERIA 
		{
			set{_INPAN_TOTALMERCADERIA = value;}
			get{ return _INPAN_TOTALMERCADERIA;}
		}
		public decimal INPAN_TOTALIMPUESTO
		{
			set{_INPAN_TOTALIMPUESTO = value;}
			get{ return _INPAN_TOTALIMPUESTO;}
		}
		public decimal IMPORTE
		{
			set{_INPAN_TOTALDOCUMENTO = value;}
			get{ return _INPAN_TOTALDOCUMENTO;}
		}
		public decimal PEDIN_PAGO
		{
			set{_PEDIN_PAGO = value;}
			get{ return _PEDIN_PAGO;}
		}
		public decimal SALDO 
		{
			set{_PEDIN_SALDO = value;}
			get{ return _PEDIN_SALDO;}
		}
		public string TIPO_DOCUMENTO_DES
		{
			set{_PEDIV_DESCCLASEFACTURA = value;}
			get{ return _PEDIV_DESCCLASEFACTURA;}
		}
		public string FACTURA_SUNAT
		{
			set{_COMPC_CODIGOSUNAT = value;}
			get{ return _COMPC_CODIGOSUNAT;}
		}
		public string PEDIV_HORA
		{
			set{_PEDIV_HORA = value;}
			get{ return _PEDIV_HORA;}
		}
		public string PEDIV_SALIDA_PEDIDO 
		{
			set{_PEDIV_SALIDA_PEDIDO = value;}
			get{ return _PEDIV_SALIDA_PEDIDO;}
		}
		public int PEDIN_PEDIDOALTA
		{
			set{_PEDIN_PEDIDOALTA = value;}
			get{ return _PEDIN_PEDIDOALTA;}
		}
		public DateTime FECHA_PAGO
		{
			set{_FECHA_PAGO = value;}
			get{ return _FECHA_PAGO;}
		}
		

	}
}
