using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Cuota.
	/// </summary>
	public class Cuota
	{
		public Cuota()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public string _idFila ;
		public string idFila
		{
			get { return this._idFila; }
			set { this._idFila = value; }
		}
		public string _idCuota ;
		public string idCuota
		{
			get { return this._idCuota; }
			set { this._idCuota = value; }
		}
		public string _cuota ;
		public string cuota
		{
			get { return this._cuota; }
			set { this._cuota = value; }
		}
		public int _nroCuota ;
		public int nroCuota
		{
			get { return this._nroCuota; }
			set { this._nroCuota = value; }
		}
		public double _porcenCuotaInicial ;
		public double porcenCuotaInicial
		{
			get { return this._porcenCuotaInicial; }
			set { this._porcenCuotaInicial = value; }
		}

		public double _monto ;
		public double monto
		{
			get { return this._monto; }
			set { this._monto = value; }
		}

		public string _usuario ;
		public string usuario
		{
			get { return this._usuario; }
			set { this._usuario = value; }
		}

		public DateTime _fechEmision ;
		public DateTime fechEmision
		{
			get { return this._fechEmision; }
			set { this._fechEmision = value; }
		}

		public string _nroSap ;
		public string nroSap
		{
			get { return this._nroSap; }
			set { this._nroSap = value; }
		}

		public string _telefono ;
		public string telefono
		{
			get { return this._telefono; }
			set { this._telefono = value; }
		}

		public string _nroContrato;
		public string nroContrato
		{
			get { return this._nroContrato; }
			set { this._nroContrato = value; }
		}
		// Nuevo * LCA 
		private string _CUOV_MATE;
		private string _CUOV_IMEI;
		private string _CUOV_NOM_CLIENTE;
		private string _CUOV_NRO_DOC_CLIENTE;
		private string _CUOV_NRO_CLIENTE;

		private string _CVEV_NRO_CONTRA;
		private string _CVEC_NUMERO_CUOTA;
		private DateTime _CVED_FECHA_VENCIMIENTO;
		private string _CVEV_IMPORTE_CUOTA;
		private string _CVEV_DOCUMENTO_SAP;
		private string _CVEV_LINEA;
		private string _CVEV_NRO_ASOCIADO;
		private string _CVEV_OBSE;
		private string _IMPORTE;
		private string _MONTOIGV;
		private string _OFICINA;
		// FIN
		private string _CUOV_NRO_CONTRATO;
		private int _CUON_NRO_CUOTA;
		private DateTime _CUOD_FECHA_EMISION;
		private Double _CUON_MONTO;
		private string _CUOV_NRO_DOC_SAP;
		private string _CUOV_NRO_CELULAR;
		private string _CUOV_USUARIO_REG;
		private string _FLAG_ENVIO;
		private string _CUENTA_BSCS;
		private string _CUSTOMER_ID;
		private string _CONTRATO_SISACT;
		private string _CICLO_FACTURACION;

		private string _cu;
		private string _descripcion;

		public string CICLO_FACTURACION	
		{
			get{ return _CICLO_FACTURACION; }
			set{ _CICLO_FACTURACION = value; }
		}
			
		// Nuevo * LCA
		public string CUOV_NRO_CLIENTE
		{
			get{ return _CUOV_NRO_CLIENTE; }
			set{ _CUOV_NRO_CLIENTE = value; }
		}
		public string CUOV_MATE
		{
			get{ return _CUOV_MATE; }
			set{ _CUOV_MATE = value; }
		}
		public string CUOV_IMEI
		{
			get{ return _CUOV_IMEI; }
			set{ _CUOV_IMEI = value; }
		}
		public string CUOV_NOM_CLIENTE
		{
			get{ return _CUOV_NOM_CLIENTE; }
			set{ _CUOV_NOM_CLIENTE = value; }
		}
		public string CUOV_NRO_DOC_CLIENTE
		{
			get{ return _CUOV_NRO_DOC_CLIENTE; }
			set{ _CUOV_NRO_DOC_CLIENTE = value; }
		}

		public string CVEV_NRO_CONTRA
		{
			get{ return _CVEV_NRO_CONTRA; }
			set{ _CVEV_NRO_CONTRA = value; }
		}

		public string CVEC_NUMERO_CUOTA
		{
			get{ return _CVEC_NUMERO_CUOTA; }
			set{ _CVEC_NUMERO_CUOTA = value; }
	}

		public DateTime CVED_FECHA_VENCIMIENTO
		{
			get{ return _CVED_FECHA_VENCIMIENTO; }
			set{ _CVED_FECHA_VENCIMIENTO = value; }
		}

		public string CVEV_IMPORTE_CUOTA
		{
			get{ return _CVEV_IMPORTE_CUOTA; }
			set{ _CVEV_IMPORTE_CUOTA = value; }
		}

		public string CVEV_DOCUMENTO_SAP
		{
			get{ return _CVEV_DOCUMENTO_SAP; }
			set{ _CVEV_DOCUMENTO_SAP = value; }
		}

		public string CVEV_LINEA
		{
			get{ return _CVEV_LINEA; }
			set{ _CVEV_LINEA = value; }
		}

		public string CVEV_NRO_ASOCIADO
		{
			get{ return _CVEV_NRO_ASOCIADO; }
			set{ _CVEV_NRO_ASOCIADO = value; }
		}
		
		public string CVEV_OBSE
		{
			get{ return _CVEV_OBSE; }
			set{ _CVEV_OBSE = value; }
		}

		public string IMPORTE
		{
			get{ return _IMPORTE; }
			set{ _IMPORTE = value; }
		}

		public string MONTOIGV
		{
			get{ return _MONTOIGV; }
			set{ _MONTOIGV = value; }
		}
		// Fin
		public string OFICINA
		{
			get{ return _OFICINA; }
			set{ _OFICINA = value; }
}

		public string CU
		{
			get{ return _cu; }
			set{ _cu = value; }
		}

		public string DESCRIPCION
		{
			get{ return _descripcion; }
			set{ _descripcion = value; }
		}
		
		//T13087: Reimpresión Cronograma Pagos
		public string CUOV_NRO_CONTRATO
		{
			get{ return _CUOV_NRO_CONTRATO; }
			set{ _CUOV_NRO_CONTRATO = value; }
		}
		public int CUON_NRO_CUOTA
		{
			get{ return _CUON_NRO_CUOTA; }
			set{ _CUON_NRO_CUOTA = value; }
		}
		public DateTime CUOD_FECHA_EMISION
		{
			get{ return _CUOD_FECHA_EMISION; }
			set{ _CUOD_FECHA_EMISION = value; }
		}
		public Double CUON_MONTO
		{
			get{ return _CUON_MONTO; }
			set{ _CUON_MONTO = value; }
		}
		public string CUOV_NRO_DOC_SAP
		{
			get{ return _CUOV_NRO_DOC_SAP; }
			set{ _CUOV_NRO_DOC_SAP = value; }
		}
		public string CUOV_NRO_CELULAR
		{
			get{ return _CUOV_NRO_CELULAR; }
			set{ _CUOV_NRO_CELULAR = value; }
		}
		public string CUOV_USUARIO_REG
		{
			get{ return _CUOV_USUARIO_REG; }
			set{ _CUOV_USUARIO_REG = value; }
		}
		public string FLAG_ENVIO
		{
			get{ return _FLAG_ENVIO; }
			set{ _FLAG_ENVIO = value; }
		}
		public string CUENTA_BSCS
		{
			get{ return _CUENTA_BSCS; }
			set{ _CUENTA_BSCS = value; }
		}
		public string CUSTOMER_ID
		{
			get{ return _CUSTOMER_ID; }
			set{ _CUSTOMER_ID = value; }
		}
		public string CONTRATO_SISACT
		{
			get{ return _CONTRATO_SISACT; }
			set{ _CONTRATO_SISACT = value; }
		}
		
		//PROY-29123 VENTA EN CUOTAS INICIO
		private int _maximoCuotas;
		private double _precioEquipoMaximo;
		private string _mensajeBRMS;

		public int MaximoCuotas
		{
			get { return this._maximoCuotas; }
			set { this._maximoCuotas = value; }
		}

		public double PrecioEquipoMaximo
		{
			get { return this._precioEquipoMaximo; }
			set { this._precioEquipoMaximo = value; }
		}

		public string MensajeBRMS
		{
			get { return this._mensajeBRMS; }
			set { this._mensajeBRMS = value; }
		}
		//PROY-29123 VENTA EN CUOTAS FIN

        //PROY-31948 INI
        public string _CantCuotasPendLinea;
		public string _Estado;
		public string _Mensaje;
		public string CantCuotasPendLinea 
		{
			set { _CantCuotasPendLinea=value;}
			get {return _CantCuotasPendLinea;}
		}
		public string Estado
		{
			set{_Estado = value;}
			get{ return _Estado;}
		}
		public string Mensaje
		{
			set{_Mensaje = value;}
			get{ return _Mensaje;}
		}
		//PROY-31948 FIN
	}
}
