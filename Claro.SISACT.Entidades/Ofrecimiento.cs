using System;
using System.Collections;
namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Ofrecimiento.
	/// </summary>
	public class Ofrecimiento
	{
		private int _idFila;
		private string _idProducto;
		private double _montoGarantiaFinal;
		private double _cargoFijo;
		private string _tieneAutonomia;
		private string _flagExito;

		//----------------------------------------------
		private string _in_solicitud;
		private string _in_cliente;
		private string _in_direccion_cliente;
		private string _in_doc_cliente;
		private string _in_rrll_cliente;
		private string _in_equipo;
		private string _in_oferta;
		private string _in_campana;
		private string _in_plan_actual;
		private string _in_plan_solicitado;
		private string _in_servicio;
		private string _in_pdv;
		private string _in_direccion_pdv;

		//----------------------------------------------
		private int _cantidadDeLineasAdicionalesRUC;
		private int _cantidadDeLineasMaximas;
		private int _cantidadDeLineasRenovaciones;
		private string _autonomiaRenovacion;
		private double _montoCFParaRUC;
		private string _tipoDeAutonomiaCargoFijo;
		private string _controlDeConsumo;
		private double _costoDeInstalacion;
		private int _cantidadDeAplicacionesRenta;
		private int _frecuenciaDeAplicacionMensual;
		private int _mesInicioRentas;
		private double _montoDeGarantia;
		private string _tipodecobro;
		private string _tipoDeGarantia;
		private double _limiteDeCreditoCobranza;
		private double _montoTopeAutomatico;
		private string _prioridadPublicar;
		private string _procesoDeExoneracionDeRentas;
		private string _procesoIDValidator;
		private string _procesoValidacionInternaClaro;
		private string _publicar;
		private string _restriccion;
		private string _capacidadDePago;
		private int _comportamientoConsolidado;
		private int _comportamientoDePagoC1;
		private double _costoTotalEquipos;
		private double _factorDeEndeudamientoCliente;
		private double _factorDeRenovacionCliente;
		private double _precioDeVentaTotalEquipos;
		private string _riesgoEnClaro;
		private string _riesgoOferta;
		private int _riesgoTotalEquipo;
		private string _riesgoTotalRepLegales;
		private string _tipoOperacion;
		private string _resultadoAutonomia;
		private double _lcDisponible;

		private string _mensaje;

		//PROY-29123 VENTA EN CUOTAS INICIO
		private int _maximoCuotas;
		private double _precioEquipoMaximo;
		private string _mensajeBRMS;
		//PROY-29123 VENTA EN CUOTAS FIN

		public Ofrecimiento()
		{
		}

		private int _nroLineaActivoxProducto ;
		public int nroLineaActivoxProducto
		{
			get { return this._nroLineaActivoxProducto; }
			set { this._nroLineaActivoxProducto = value; }
		}
		private int _nroLineaEvaluadoxProducto ;
		public int nroLineaEvaluadoxProducto
		{
			get { return this._nroLineaEvaluadoxProducto; }
			set { this._nroLineaEvaluadoxProducto = value; }
		}
		private double _montoFacturadoxProducto ;
		public double montoFacturadoxProducto
		{
			get { return this._montoFacturadoxProducto; }
			set { this._montoFacturadoxProducto = value; }
		}
		private ArrayList _ListaCuotas ;
		public ArrayList ListaCuotas
		{
			get { return this._ListaCuotas; }
			set { this._ListaCuotas = value; }
		}
		private string _Plan ;
		public string Plan
		{
			get { return this._Plan; }
			set { this._Plan = value; }
		}
		private string _Combo ;
		public string Combo
		{
			get { return this._Combo; }
			set { this._Combo = value; }
		}
		private double _DescuentoCF ;
		public double DescuentoCF
		{
			get { return this._DescuentoCF; }
			set { this._DescuentoCF = value; }
		}



		public int IdFila
		{
			get { return this._idFila; }
			set { this._idFila = value; }
		}

		public string IdProducto
		{
			get { return this._idProducto; }
			set { this._idProducto = value; }
		}

		public double MontoGarantiaFinal
		{
			get { return this._montoGarantiaFinal; }
			set { this._montoGarantiaFinal = value; }
		}

		public double CargoFijo
		{
			get { return this._cargoFijo; }
			set { this._cargoFijo = value; }
		}

		public string TieneAutonomia
		{
			get { return this._tieneAutonomia; }
			set { this._tieneAutonomia = value; }
		}
		
		public string FlagExito
		{
			get { return this._flagExito; }
			set { this._flagExito = value; }
		}
		
		public string In_solicitud
		{
			get { return this._in_solicitud; }
			set { this._in_solicitud = value; }
		}

		public string In_cliente
		{
			get { return this._in_cliente; }
			set { this._in_cliente = value; }
		}

		public string In_direccion_cliente
		{
			get { return this._in_direccion_cliente; }
			set { this._in_direccion_cliente = value; }
		}

		public string In_doc_cliente
		{
			get { return this._in_doc_cliente; }
			set { this._in_doc_cliente = value; }
		}

		public string In_rrll_cliente
		{
			get { return this._in_rrll_cliente; }
			set { this._in_rrll_cliente = value; }
		}

		public string In_equipo
		{
			get { return this._in_equipo; }
			set { this._in_equipo = value; }
		}

		public string In_oferta
		{
			get { return this._in_oferta; }
			set { this._in_oferta = value; }
		}

		public string In_campana
		{
			get { return this._in_campana; }
			set { this._in_campana = value; }
		}

		public string In_plan_actual
		{
			get { return this._in_plan_actual; }
			set { this._in_plan_actual = value; }
		}

		public string In_plan_solicitado
		{
			get { return this._in_plan_solicitado; }
			set { this._in_plan_solicitado = value; }
		}

		public string In_servicio
		{
			get { return this._in_servicio; }
			set { this._in_servicio = value; }
		}

		public string In_pdv
		{
			get { return this._in_pdv; }
			set { this._in_pdv = value; }
		}

		public string In_direccion_pdv
		{
			get { return this._in_direccion_pdv; }
			set { this._in_direccion_pdv = value; }
		}

		public int CantidadDeLineasAdicionalesRUC
		{
			get { return this._cantidadDeLineasAdicionalesRUC; }
			set { this._cantidadDeLineasAdicionalesRUC = value; }
		}

		public int CantidadDeLineasMaximas
		{
			get { return this._cantidadDeLineasMaximas; }
			set { this._cantidadDeLineasMaximas = value; }
		}

		public int CantidadDeLineasRenovaciones
		{
			get { return this._cantidadDeLineasRenovaciones; }
			set { this._cantidadDeLineasRenovaciones = value; }
		}

		public string AutonomiaRenovacion
		{
			get { return this._autonomiaRenovacion; }
			set { this._autonomiaRenovacion = value; }
		}

		public double MontoCFParaRUC
		{
			get { return this._montoCFParaRUC; }
			set { this._montoCFParaRUC = value; }
		}

		public string TipoDeAutonomiaCargoFijo
		{
			get { return this._tipoDeAutonomiaCargoFijo; }
			set { this._tipoDeAutonomiaCargoFijo = value; }
		}

		public string ControlDeConsumo
		{
			get { return this._controlDeConsumo; }
			set { this._controlDeConsumo = value; }
		}

		public double CostoDeInstalacion
		{
			get { return this._costoDeInstalacion; }
			set { this._costoDeInstalacion = value; }
		}

		public int CantidadDeAplicacionesRenta
		{
			get { return this._cantidadDeAplicacionesRenta; }
			set { this._cantidadDeAplicacionesRenta = value; }
		}

		public int FrecuenciaDeAplicacionMensual
		{
			get { return this._frecuenciaDeAplicacionMensual; }
			set { this._frecuenciaDeAplicacionMensual = value; }
		}

		public int MesInicioRentas
		{
			get { return this._mesInicioRentas; }
			set { this._mesInicioRentas = value; }
		}

		public double MontoDeGarantia
		{
			get { return this._montoDeGarantia; }
			set { this._montoDeGarantia = value; }
		}

		public string Tipodecobro
		{
			get { return this._tipodecobro; }
			set { this._tipodecobro = value; }
		}

		public string TipoDeGarantia
		{
			get { return this._tipoDeGarantia; }
			set { this._tipoDeGarantia = value; }
		}

		public double LimiteDeCreditoCobranza
		{
			get { return this._limiteDeCreditoCobranza; }
			set { this._limiteDeCreditoCobranza = value; }
		}

		public double MontoTopeAutomatico
		{
			get { return this._montoTopeAutomatico; }
			set { this._montoTopeAutomatico = value; }
		}

		public string PrioridadPublicar
		{
			get { return this._prioridadPublicar; }
			set { this._prioridadPublicar = value; }
		}

		public string ProcesoDeExoneracionDeRentas
		{
			get { return this._procesoDeExoneracionDeRentas; }
			set { this._procesoDeExoneracionDeRentas = value; }
		}

		public string ProcesoIDValidator
		{
			get { return this._procesoIDValidator; }
			set { this._procesoIDValidator = value; }
		}

		public string ProcesoValidacionInternaClaro
		{
			get { return this._procesoValidacionInternaClaro; }
			set { this._procesoValidacionInternaClaro = value; }
		}

		public string Publicar
		{
			get { return this._publicar; }
			set { this._publicar = value; }
		}

		public string Restriccion
		{
			get { return this._restriccion; }
			set { this._restriccion = value; }
		}

		public string CapacidadDePago
		{
			get { return this._capacidadDePago; }
			set { this._capacidadDePago = value; }
		}

		public int ComportamientoConsolidado
		{
			get { return this._comportamientoConsolidado; }
			set { this._comportamientoConsolidado = value; }
		}

		public int ComportamientoDePagoC1
		{
			get { return this._comportamientoDePagoC1; }
			set { this._comportamientoDePagoC1 = value; }
		}

		public double CostoTotalEquipos
		{
			get { return this._costoTotalEquipos; }
			set { this._costoTotalEquipos = value; }
		}

		public double FactorDeEndeudamientoCliente
		{
			get { return this._factorDeEndeudamientoCliente; }
			set { this._factorDeEndeudamientoCliente = value; }
		}

		public double FactorDeRenovacionCliente
		{
			get { return this._factorDeRenovacionCliente; }
			set { this._factorDeRenovacionCliente = value; }
		}

		public double PrecioDeVentaTotalEquipos
		{
			get { return this._precioDeVentaTotalEquipos; }
			set { this._precioDeVentaTotalEquipos = value; }
		}

		public string RiesgoEnClaro
		{
			get { return this._riesgoEnClaro; }
			set { this._riesgoEnClaro = value; }
		}

		public string RiesgoOferta
		{
			get { return this._riesgoOferta; }
			set { this._riesgoOferta = value; }
		}

		public int RiesgoTotalEquipo
		{
			get { return this._riesgoTotalEquipo; }
			set { this._riesgoTotalEquipo = value; }
		}

		public string RiesgoTotalRepLegales
		{
			get { return this._riesgoTotalRepLegales; }
			set { this._riesgoTotalRepLegales = value; }
		}

		public string Mensaje
		{
			get { return this._mensaje; }
			set { this._mensaje = value; }
		}

		public string TipoOperacion
		{
			get { return this._tipoOperacion; }
			set { this._tipoOperacion = value; }
		}

		public string ResultadoAutonomia
		{
			get { return this._resultadoAutonomia; }
			set { this._resultadoAutonomia = value; }
		}
		
		public double LcDisponible
		{
			get { return this._lcDisponible; }
			set { this._lcDisponible = value; }
		}

		//PROY-29123 VENTA EN CUOTAS INICIO
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
	}
}
