using System;
using System.Collections;
using System.Data;
using Claro.SisAct.Common;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de ClienteCuenta.
	/// </summary>
	public class ClienteCuenta
	{
		public ClienteCuenta()
		{}
		private string _nroDoc;
		private string _tipoDoc;
		private string _tipoDocDes;
		private string _nombres;
		private int _nroLineas;
		private int _nroLineasBSCS;
		private int _nroLineasMenor = 0;
		private int _nroLineasMayor = 0;
		private double _CF;
		private double _CF_Menor;
		private double _CF_Mayor;
		private double _deudaCastigada;
		private double _deudaVencida = 0;
		private int _nroBloqueo;
		private int _nroSuspension;
		private Int64 _nroMesesClaro;
		private bool _esClienteClaro;
		private bool _isBlackList;
		private bool _isWhiteList;
		private bool _isTop;
		private ArrayList _montoCuenta;
		private string _planActivos;
		private string _nroDocAsociado;

		private DataTable _lineaSGA;
		private DataTable _lineaBSCS;
		private ArrayList _lineaOAC;
		private DataTable _lineaSISACT;

		private ArrayList _LCxProducto;
		private ArrayList _FacturaxProducto;
		private ArrayList _LCDispxProducto;
		private ArrayList _GarantiaxProducto;
		private ArrayList _NoFacturaxProducto;

		private int _nroBloqueoMovil;
		private int _nroSuspensionMovil;
		private int _nroRangoDiasBSCS;


		private string _listaLineasFraude;

		private int _nroPlanesActivos;
		private int _comportamientoPago;
		private double _montoFacturadoTotal;
		private int _tiempoPermanencia;
		private string _tipoCliente;
		private string _planActual;
		private double _planActualCF;
		private string _planActualPlazo;
		private ArrayList _oNroPlanesActivosxProducto;

		private int _nroLineaMenor7Dia;
		private int _nroLineaMenor30Dia;
		private int _nroLineaMenor90Dia;
		private int _nroLineaMenor180Dia;
		private int _nroLineaMayor90Dia;
		private int _nroLineaMayor180Dia;

		private int _nroDiasDeuda;
		private double _deudaTotal;

		private double _factorRenovacion;
//gaa20161115
		private int _tiempoPermanenciaContratoMeses;
//fin gaa20161115
//gaa20170215
		private string _buroConsultado;
//fin gaa20170215
		public int nroDiasDeuda
		{
			get { return this._nroDiasDeuda; }
			set { this._nroDiasDeuda = value; }
		}
		public double deudaTotal
		{
			get { return this._deudaTotal; }
			set { this._deudaTotal = value; }
		}

		private string _apellidos;
		public string apellidos
		{
			get { return this._apellidos; }
			set { this._apellidos = value; }
		}
		private string _apellidoPaterno;
		public string apellidoPaterno
		{
			get { return this._apellidoPaterno; }
			set { this._apellidoPaterno = value; }
		}
		private string _apellidoMaterno;
		public string apellidoMaterno
		{
			get { return this._apellidoMaterno; }
			set { this._apellidoMaterno = value; }
		}
		private string _razonSocial;
		public string razonSocial
		{
			get { return this._razonSocial; }
			set { this._razonSocial = value; }
		}
		private string _soloEvaluarFijo;
		public string soloEvaluarFijo
		{
			get { return this._soloEvaluarFijo; }
			set { this._soloEvaluarFijo = value; }
		}
		private string _mensajeDeudaBloqueo;
		public string mensajeDeudaBloqueo
		{
			get { return this._mensajeDeudaBloqueo; }
			set { this._mensajeDeudaBloqueo = value; }
		}


		private ArrayList _oPlanesActivosxBilletera ;
	public ArrayList oPlanesActivosxBilletera
{
	get { return this._oPlanesActivosxBilletera; }
	set { this._oPlanesActivosxBilletera= value; }
}

//	        public ArrayList _oPlanesActivosxBilletera ;
//	public ArrayList oPlanesActivosxBilletera
//{
//	get { return this._oPlanesActivosxBilletera; }
//	set { this._oPlanesActivosxBilletera= value; }
//}

        private ArrayList _oPlanesActivosCorporativo ;
	public ArrayList oPlanesActivosCorporativo
{
	get { return this._oPlanesActivosCorporativo; }
	set { this._oPlanesActivosCorporativo= value; }
}

        private ArrayList _oLCBuroxBilletera ;
	public ArrayList oLCBuroxBilletera
{
	get { return this._oLCBuroxBilletera; }
	set { this._oLCBuroxBilletera= value; }
}

        private ArrayList _oMontoFacturadoxBilletera ;
	public ArrayList oMontoFacturadoxBilletera
{
	get { return this._oMontoFacturadoxBilletera; }
	set { this._oMontoFacturadoxBilletera= value; }
}

        private ArrayList _oMontoNoFacturadoxBilletera;
	public ArrayList oMontoNoFacturadoxBilletera
{
	get { return this._oMontoNoFacturadoxBilletera; }
	set { this._oMontoNoFacturadoxBilletera= value; }
}

        private ArrayList _oLCDisponiblexBilletera;
	public ArrayList oLCDisponiblexBilletera
{
	get { return this._oLCDisponiblexBilletera; }
	set { this._oLCDisponiblexBilletera= value; }
}

        private ArrayList _oGarantiaxProducto ;
	public ArrayList oGarantiaxProducto
{
	get { return this._oGarantiaxProducto; }
	set { this._oGarantiaxProducto= value; }
}

        private ArrayList _oOAC ;
	public ArrayList oOAC
{
	get { return this._oOAC; }
	set { this._oOAC= value; }
}

//        public BEVistaEvaluacion oVistaEvaluacion { get; set; }
//	public ArrayList xxxx
//{
//	get { return this._xxxx }
//	set { this._xxxx= value; }
//}


//	public BEVistaEvaluacion oVistaEvaluacion { get; set; }

		
		private string _idCliente;
		public string idCliente
		{
			get { return this._idCliente; }
			set { this._idCliente = value; }
		}

		private string _oficina;
		public string oficina
		{
			get { return this._oficina; }
			set { this._oficina = value; }
		}
		private string _nroOperacionBuro;
		public string nroOperacionBuro
		{
			get { return this._nroOperacionBuro; }
			set { this._nroOperacionBuro = value; }
		}
		private double _CF_Total;
		public double CF_Total
		{
			get { return this._CF_Total; }
			set { this._CF_Total = value; }
		}

		private bool _soloBloqueoRoboPerdida ;
		public bool soloBloqueoRoboPerdida
		{
			get { return this._soloBloqueoRoboPerdida; }
			set { this._soloBloqueoRoboPerdida = value; }
		}
		private DataTable _lineaPrepago;
		public DataTable lineaPrepago
		{
			get { return this._lineaPrepago; }
			set { this._lineaPrepago = value; }
		}
		private int _nroLineasSGA;
		public int nroLineasSGA
		{
			get { return this._nroLineasSGA; }
			set { this._nroLineasSGA = value; }
		}
		private int _nroLineasSISACT;
		public int nroLineasSISACT 
		{
			get { return this._nroLineasSISACT; }
			set { this._nroLineasSISACT = value; }
		}
		private double _montoNoFacturadoTotal;
		public double montoNoFacturadoTotal
		{
			get { return this._montoNoFacturadoTotal; }
			set { this._montoNoFacturadoTotal = value; }
		}

		public string nroDoc
		{
			get { return this._nroDoc; }
			set { this._nroDoc = value; }
		}

		public string tipoDoc
		{
			get { return this._tipoDoc; }
			set { this._tipoDoc = value; }
		}

		public string tipoDocDes
		{
			get { return this._tipoDocDes; }
			set { this._tipoDocDes = value; }
		}

		public string nombres
		{
			get { return this._nombres; }
			set { this._nombres = value; }
		}

		public bool esClienteClaro
		{
			get { return this._esClienteClaro; }
			set { this._esClienteClaro = value; }
		}

		public bool isBlackList
		{
			get { return this._isBlackList; }
			set { this._isBlackList = value; }
		}

		public bool isWhiteList
		{
			get { return this._isWhiteList; }
			set { this._isWhiteList = value; }
		}

		public bool isTop
		{
			get { return this._isTop; }
			set { this._isTop = value; }
		}

		public int nroLineas
		{
			get { return this._nroLineas; }
			set { this._nroLineas = value; }
		}

		public int nroLineasBSCS
		{
			get { return this._nroLineasBSCS; }
			set { this._nroLineasBSCS = value; }
		}

		public int nroLineasMenor
		{
			get { return this._nroLineasMenor; }
			set { this._nroLineasMenor = value; }
		}

		public int nroLineasMayor
		{
			get { return this._nroLineasMayor; }
			set { this._nroLineasMayor = value; }
		}

		public double CF
		{
			get { return this._CF; }
			set { this._CF = value; }
		}

		public double CF_Menor
		{
			get { return this._CF_Menor; }
			set { this._CF_Menor = value; }
		}

		public double CF_Mayor
		{
			get { return this._CF_Mayor; }
			set { this._CF_Mayor = value; }
		}

		public double deudaCastigada
		{
			get { return this._deudaCastigada; }
			set { this._deudaCastigada = value; }
		}

		public double deudaVencida
		{
			get { return this._deudaVencida; }
			set { this._deudaVencida = value; }
		}

		public int nroBloqueo
		{
			get { return this._nroBloqueo; }
			set { this._nroBloqueo = value; }
		}

		public int nroSuspension
		{
			get { return this._nroSuspension; }
			set { this._nroSuspension = value; }
		}

		public ArrayList montoCuenta
		{
			get { return this._montoCuenta; }
			set { this._montoCuenta = value; }
		}
		
		public string planActivos
		{
			get { return this._planActivos; }
			set { this._planActivos = value; }
		}

		public string nroDocAsociado
		{
			get { return this._nroDocAsociado; }
			set { this._nroDocAsociado = value; }
		}
		
		public Int64 nroMesesClaro
		{
			get { return this._nroMesesClaro; }
			set { this._nroMesesClaro = value; }
		}
		
		public DataTable LineaSISACT
		{
			get { return this._lineaSISACT; }
			set { this._lineaSISACT = value; }
		}

		public DataTable LineaSGA
		{
			get { return this._lineaSGA; }
			set { this._lineaSGA = value; }
		}

		public DataTable LineaBSCS
		{
			get { return this._lineaBSCS; }
			set { this._lineaBSCS = value; }
		}

		public ArrayList LineaOAC
		{
			get { return this._lineaOAC; }
			set { this._lineaOAC = value; }
		}

		public ArrayList LCxProducto
		{
			get { return this._LCxProducto; }
			set { this._LCxProducto = value; }
		}

		public ArrayList FacturaxProducto
		{
			get { return this._FacturaxProducto; }
			set { this._FacturaxProducto = value; }
		}

		public ArrayList LCDispxProducto
		{
			get { return this._LCDispxProducto; }
			set { this._LCDispxProducto = value; }
		}

		public ArrayList GarantiaxProducto
		{
			get { return this._GarantiaxProducto; }
			set { this._GarantiaxProducto = value; }
		}

		public ArrayList NoFacturaxProducto
		{
			get { return this._NoFacturaxProducto; }
			set { this._NoFacturaxProducto = value; }
		}

		public int nroBloqueoMovil
		{
			get { return this._nroBloqueoMovil; }
			set { this._nroBloqueoMovil = value; }
		}

		public int nroSuspensionMovil
		{
			get { return this._nroSuspensionMovil; }
			set { this._nroSuspensionMovil = value; }
		}

		public int nroRangoDiasBSCS
		{
			get { return this._nroRangoDiasBSCS; }
			set { this._nroRangoDiasBSCS = value; }
		}

		public string listaLineasFraude
		{
			get { return this._listaLineasFraude; }
			set { this._listaLineasFraude = value; }
		}

		public int nroPlanesActivos
		{
			get { return this._nroPlanesActivos; }
			set { this._nroPlanesActivos = value; }
		}
		public int comportamientoPago
		{
			get { return this._comportamientoPago; }
			set { this._comportamientoPago = value; }
		}
		public double montoFacturadoTotal
		{
			get { return this._montoFacturadoTotal; }
			set { this._montoFacturadoTotal = value; }
		}
		public int tiempoPermanencia
		{
			get { return this._tiempoPermanencia; }
			set { this._tiempoPermanencia = value; }
		}
		public string tipoCliente
		{
			get { return this._tipoCliente; }
			set { this._tipoCliente = value; }
		}
		public string planActual
		{
			get { return this._planActual; }
			set { this._planActual = value; }
		}
		public double planActualCF
		{
			get { return this._planActualCF; }
			set { this._planActualCF = value; }
		}
		public string planActualPlazo
		{
			get { return this._planActualPlazo; }
			set { this._planActualPlazo = value; }
		}
		public ArrayList oNroPlanesActivosxProducto
		{
			get { return this._oNroPlanesActivosxProducto; }
			set { this._oNroPlanesActivosxProducto = value; }
		}
		public int nroLineaMenor7Dia
		{
			get { return this._nroLineaMenor7Dia; }
			set { this._nroLineaMenor7Dia = value; }
		}
		public int nroLineaMenor30Dia
		{
			get { return this._nroLineaMenor30Dia; }
			set { this._nroLineaMenor30Dia = value; }
		}
		public int nroLineaMenor90Dia
		{
			get { return this._nroLineaMenor90Dia; }
			set { this._nroLineaMenor90Dia = value; }
		}
		public int nroLineaMenor180Dia
		{
			get { return this._nroLineaMenor180Dia; }
			set { this._nroLineaMenor180Dia = value; }
		}
		public int nroLineaMayor90Dia
		{
			get { return this._nroLineaMayor90Dia; }
			set { this._nroLineaMayor90Dia = value; }
		}
		public int nroLineaMayor180Dia
		{
			get { return this._nroLineaMayor180Dia; }
			set { this._nroLineaMayor180Dia = value; }
		}

		public double factorRenovacion
		{
			get { return this._factorRenovacion; }
			set { this._factorRenovacion = value; }
		}
//gaa20161115
		public int tiempoPermanenciaContratoMeses
		{
			get { return this._tiempoPermanenciaContratoMeses; }
			set { this._tiempoPermanenciaContratoMeses = value; }
		}
//fin gaa20161115
//gaa20170215
		public string buroConsultado
		{
			get { return this._buroConsultado; }
			set { this._buroConsultado = value; }
		}
//fin gaa20170215
	}
}
