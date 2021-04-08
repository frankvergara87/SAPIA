using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AP_Venta.
	/// </summary>
	public class AP_Venta
	{
		public AP_Venta()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private Int64 _ID_DOCUMENTO;
		private string _TIPO_DOCUMENTO;
		private string _CANAL;
		private string _OFICINA_VENTA;
		private DateTime _FECHA_CREA;
		private string _TIPO_DOC_CLIENTE;
		private string _NRO_DOC_CLIENTE;
		private string _MONEDA;
		private Int64 _TOPEN_CODIGO;
		private float _TOTAL_VENTA;
		private float _SUBTOTAL_IMPUESTO;
		private float _SUBTOTAL_VENTA;
		private DateTime _FECHA_VENTA;
		private string _OBSERVACION;
		private string _TVENC_CODIGO;
		private string _NUMERO_REFERENCIA;
		private string _USUARIO_CREA;
		private Int64 _NUMERO_CUOTAS;
		private string _ESTADO;
		private string _VENDEDOR;
		private string _ORG_VENTA;
		private Int64 _NUMERO_SEC;

		public Int64 ID_DOCUMENTO {get{ return _ID_DOCUMENTO;} set{_ID_DOCUMENTO = value;}}
		public string TIPO_DOCUMENTO {get{ return _TIPO_DOCUMENTO;} set{_TIPO_DOCUMENTO = value;}}
		public string CANAL {get{ return _CANAL;} set{_CANAL = value;}}
		public string OFICINA_VENTA {get{ return _OFICINA_VENTA;} set{_OFICINA_VENTA = value;}}
		public DateTime FECHA_CREA {get{ return _FECHA_CREA;} set{_FECHA_CREA = value;}}
		public string TIPO_DOC_CLIENTE {get{ return _TIPO_DOC_CLIENTE;} set{_TIPO_DOC_CLIENTE = value;}}
		public string NRO_DOC_CLIENTE {get{ return _NRO_DOC_CLIENTE;} set{_NRO_DOC_CLIENTE = value;}}
		public string MONEDA {get{ return _MONEDA;} set{_MONEDA = value;}}
		public Int64 TOPEN_CODIGO {get{ return _TOPEN_CODIGO;} set{_TOPEN_CODIGO = value;}}
		public float TOTAL_VENTA {get{ return _TOTAL_VENTA;} set{_TOTAL_VENTA = value;}}
		public float SUBTOTAL_IMPUESTO {get{ return _SUBTOTAL_IMPUESTO;} set{_SUBTOTAL_IMPUESTO = value;}}
		public float SUBTOTAL_VENTA {get{ return _SUBTOTAL_VENTA;} set{_SUBTOTAL_VENTA = value;}}
		public DateTime FECHA_VENTA {get{ return _FECHA_VENTA;} set{_FECHA_VENTA = value;}}
		public string OBSERVACION {get{ return _OBSERVACION;} set{_OBSERVACION = value;}}
		public string TVENC_CODIGO {get{ return _TVENC_CODIGO;} set{_TVENC_CODIGO = value;}}
		public string NUMERO_REFERENCIA {get{ return _NUMERO_REFERENCIA;} set{_NUMERO_REFERENCIA = value;}}
		public string USUARIO_CREA {get{ return _USUARIO_CREA;} set{_USUARIO_CREA = value;}}
		public Int64 NUMERO_CUOTAS {get{ return _NUMERO_CUOTAS;} set{_NUMERO_CUOTAS = value;}}
		public string ESTADO {get{ return _ESTADO;} set{_ESTADO = value;}}
		public string VENDEDOR {get{ return _VENDEDOR;} set{_VENDEDOR = value;}}
		public string ORG_VENTA {get{ return _ORG_VENTA;} set{_ORG_VENTA = value;}}
		public Int64 NUMERO_SEC {get{ return _NUMERO_SEC;} set{_NUMERO_SEC = value;}}
		
	}
}
