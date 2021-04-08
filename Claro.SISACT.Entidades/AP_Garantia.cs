using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AP_Garantia.
	/// </summary>
	public class AP_Garantia
	{
		public AP_Garantia()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private Int64 _GARAN_NUMERO_GARANTIA;
		private string _GARAC_TIPO_DOC_CLIENTE;
		private string _GARAV_NRO_DOC_CLIENTE;
		private DateTime _GARAD_FECHA_VENCIMIENTO;
		private Int64 _VENTN_DOCUMENTO;
		private Int64 _CONTN_NUMERO_CONTRATO;
		private float _GARAN_MONTO_GARANTIA;
		private string _GARAV_OFICINA;
		private string _GARAV_USUARIO_CREA;
		private DateTime _GARAD_FECHA_CREA;
		private Int64 _GARAN_NRO_CARGOS;
		private string _GARAC_TIPO_GARANTIA;
		private string _GARAC_ESTADO;
		private string _CLASE_DOC_SAP;
		
		
		public Int64 GARAN_NUMERO_GARANTIA {get{ return _GARAN_NUMERO_GARANTIA;} set{_GARAN_NUMERO_GARANTIA = value;}}
		public string GARAC_TIPO_DOC_CLIENTE {get{ return _GARAC_TIPO_DOC_CLIENTE;} set{_GARAC_TIPO_DOC_CLIENTE = value;}}
		public string GARAV_NRO_DOC_CLIENTE {get{ return _GARAV_NRO_DOC_CLIENTE;} set{_GARAV_NRO_DOC_CLIENTE = value;}}
		public DateTime GARAD_FECHA_VENCIMIENTO {get{ return _GARAD_FECHA_VENCIMIENTO;} set{_GARAD_FECHA_VENCIMIENTO = value;}}
		public Int64 VENTN_DOCUMENTO {get{ return _VENTN_DOCUMENTO;} set{_VENTN_DOCUMENTO = value;}}
		public Int64 CONTN_NUMERO_CONTRATO {get{ return _CONTN_NUMERO_CONTRATO;} set{_CONTN_NUMERO_CONTRATO = value;}}
		public float GARAN_MONTO_GARANTIA {get{ return _GARAN_MONTO_GARANTIA;} set{_GARAN_MONTO_GARANTIA = value;}}
		public string GARAV_OFICINA {get{ return _GARAV_OFICINA;} set{_GARAV_OFICINA = value;}}
		public string GARAV_USUARIO_CREA {get{ return _GARAV_USUARIO_CREA;} set{_GARAV_USUARIO_CREA = value;}}
		public DateTime GARAD_FECHA_CREA {get{ return _GARAD_FECHA_CREA;} set{_GARAD_FECHA_CREA = value;}}
		public Int64 GARAN_NRO_CARGOS {get{ return _GARAN_NRO_CARGOS;} set{_GARAN_NRO_CARGOS = value;}}
		public string GARAC_TIPO_GARANTIA {get{ return _GARAC_TIPO_GARANTIA;} set{_GARAC_TIPO_GARANTIA = value;}}
		public string GARAC_ESTADO {get{ return _GARAC_ESTADO;} set{_GARAC_ESTADO = value;}}
		public string CLASE_DOC_SAP {get{ return _CLASE_DOC_SAP;} set{_CLASE_DOC_SAP = value;}}
		
	}
}
