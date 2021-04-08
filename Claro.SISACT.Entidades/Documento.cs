using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Documento.
	/// </summary>
	public class Documento
	{
		private string _NOMBRE_CLIENTE;
		private double _IMPORTE;
		private double _SALDO;
		private string _TIPO_DOCUMENTO_DES;
		private string _FACTURA_SUNAT;
		//private string _FACTURA_SUNAT;
		private string _FECHA;
		private string _DOCUMENTO_SAP;
		private string _UTILIZACION_DES;
		private string _UTILIZACION;
		private string _CUOTAS;
		private string _MONEDA;
		private double _NETO;
		private double _IMPUESTO;
		private double _PAGOS;
		private string _NRO_DEP_GARANTIA;
		private string _NRO_REF_DEP_GAR;
		private string _CLASE_FACTURA; //FKART
		private string _NRO_CONTRATO;
		private string _NRO_SEC;

        private int _codigo;
		private string _nombre;
        private TipoDocumentoE _tipodoc;

		private Registro _registro;

        public int CODIGO
		{
			set{_codigo = value;}
			get{ return _codigo;}
		}

		public string NOMBRE
		{
			set{_nombre = value;}
			get{ return _nombre;}
		}

                public TipoDocumentoE TIPO_DOCUMENTO
		{
			set{_tipodoc = value;}
			get{ 
				if(_tipodoc==null)
				{
					_tipodoc = new TipoDocumentoE();
				}
				return _tipodoc;
			}
		}

                public Documento (int pCodigo, string pNombre, /*string pNombre_Alternativo, */TipoDocumentoE pTiposDocumento)
		{
			_codigo = pCodigo;
			_nombre = pNombre;
			_tipodoc = pTiposDocumento;
		}

		public Documento()
		{}
		public string NOMBRE_CLIENTE
		{
			set{  _NOMBRE_CLIENTE= value;}
			get{ return _NOMBRE_CLIENTE;}
		}
		public double IMPORTE
		{
			set{  _IMPORTE= value;}
			get{ return _IMPORTE;}
		}
		public double SALDO
		{
			set{  _SALDO= value;}
			get{ return _SALDO;}
		}
		public string TIPO_DOCUMENTO_DES
		{
			set{  _TIPO_DOCUMENTO_DES= value;}
			get{ return _TIPO_DOCUMENTO_DES;}
		}
		public string FACTURA_SUNAT
		{
			set{  _FACTURA_SUNAT= value;}
			get{ return _FACTURA_SUNAT;}
		}
		public string FECHA
		{
			set{  _FECHA= value;}
			get{ return _FECHA;}
		}
		public string DOCUMENTO_SAP
		{
			set{  _DOCUMENTO_SAP= value;}
			get{ return _DOCUMENTO_SAP;}
		}
		public string UTILIZACION_DES
		{
			set{  _UTILIZACION_DES= value;}
			get{ return _UTILIZACION_DES;}
		}
		public string UTILIZACION
		{
			set{  _UTILIZACION= value;}
			get{ return _UTILIZACION;}
		}
		public string CUOTAS
		{
			set{  _CUOTAS= value;}
			get{ return _CUOTAS;}
		}
		public string MONEDA
		{
			set{  _MONEDA= value;}
			get{ return _MONEDA;}
		}
		public double NETO
		{
			set{  _NETO= value;}
			get{ return _NETO;}
		}
		public double IMPUESTO
		{
			set{  _IMPUESTO= value;}
			get{ return _IMPUESTO;}
		}
		public double PAGOS
		{
			set{  _PAGOS= value;}
			get{ return _PAGOS;}
		}
		public string NRO_DEP_GARANTIA
		{
			set{  _NRO_DEP_GARANTIA= value;}
			get{ return _NRO_DEP_GARANTIA;}
		}
		public string NRO_REF_DEP_GAR
		{
			set{  _NRO_REF_DEP_GAR= value;}
			get{ return _NRO_REF_DEP_GAR;}
		}
		public string CLASE_FACTURA
		{
			set{  _CLASE_FACTURA= value;}
			get{ return _CLASE_FACTURA;}
		}
		public string NRO_CONTRATO
		{
			set{  _NRO_CONTRATO= value;}
			get{ return _NRO_CONTRATO;}
		}
		public string NRO_SEC
		{
			set{  _NRO_SEC= value;}
			get{ return _NRO_SEC;}
		}

		public Registro REGISTRO
		{
			set{_registro = value;}
			get
			{ 
				if(_registro==null)
				{
					_registro = new Registro();
				}
				return _registro;
			}
		}
		//--inicio-dga-01082015
		private string _FLAG_REPOSICION = "";
		public string FLAG_REPOSICION
		{
			set{_FLAG_REPOSICION = value;}
			get{ return _FLAG_REPOSICION;}
		}

		private string _NRO_CELULAR = "";
		public string NRO_CELULAR
		{
			set{_NRO_CELULAR = value;}
			get{ return _NRO_CELULAR;}
		}
		//-fin-dga-01082015
	}
}
