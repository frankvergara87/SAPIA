using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for BEGestionAcuerdoWS.
	/// </summary>
	public class BEGestionAcuerdoWS
	{
		public BEGestionAcuerdoWS()
		{
		}

		private string _acuerdoCaducado;
		private string _acuerdoOrigen ;
		private string _acuerdoId ;
		private string _coId  ;
		private string _customerId  ;
		private string _acuerdoEstado  ;
		private double _acuerdoMontoApacedeTotal  ;
		private string _acuerdoVigenciaMeses  ;
		private string _acuerdoFechaInicio ;  
		private string _acuerdoFechaFin  ;
		private Int64 _mesesAntiguedad  ;
		private Int64 _mesesPendientes  ;
		private Int64 _diasPendientes  ;
		private string _codPlazoAcuerdo  ;
		private string _descPlazoAcuerdo  ;
		private Int64 _diasVigentes  ;
		private string _CadenaXml  ;
		
		private string _montoApadece  ;
		private string _cargoFijoDiario  ;
		private string _precioLista  ;
		private string _precioVenta  ;
		private string _diasBloqueadoSusp  ;
		private string _fechaFinVigReal  ;
		private string _descripcionEstadoAcuerdo;
		private string _finVigenciaReal;

		public string acuerdoCaducado
		{
			get { return _acuerdoCaducado; }
			set { _acuerdoCaducado = value; }
		}

		public string acuerdoOrigen
		{
			get { return _acuerdoOrigen; }
			set { _acuerdoOrigen = value; }
		}

		public string acuerdoId
		{
			get { return _acuerdoId; }
			set { _acuerdoId = value; }
		}
		public string coId
		{
			get { return _coId; }
			set { _coId = value; }
		}
		public string customerId
		{
			get { return _customerId; }
			set { _customerId = value; }
		}
            
		public string acuerdoEstado
		{
			get { return _acuerdoEstado; }
			set { _acuerdoEstado = value; }
		}
		public double acuerdoMontoApacedeTotal
		{
			get { return _acuerdoMontoApacedeTotal; }
			set { _acuerdoMontoApacedeTotal = value; }
		}
		public string acuerdoVigenciaMeses
		{
			get { return _acuerdoVigenciaMeses; }
			set { _acuerdoVigenciaMeses = value; }
		}
		public string acuerdoFechaInicio
		{
			get { return _acuerdoFechaInicio; }
			set { _acuerdoFechaInicio = value; }
		}
		public string acuerdoFechaFin
		{
			get { return _acuerdoFechaFin; }
			set { _acuerdoFechaFin = value; }
		}
		public Int64 mesesAntiguedad
		{
			get { return _mesesAntiguedad; }
			set { _mesesAntiguedad = value; }
		}
            
		public Int64 mesesPendientes
		{
			get { return _mesesPendientes; }
			set { _mesesPendientes = value; }
		}
		public Int64 diasPendientes
		{
			get { return _diasPendientes; }
			set { _diasPendientes = value; }
		}
		public string codPlazoAcuerdo
		{
			get { return _codPlazoAcuerdo; }
			set { _codPlazoAcuerdo = value; }
		}
		public string descPlazoAcuerdo
		{
			get { return _descPlazoAcuerdo; }
			set { _descPlazoAcuerdo = value; }
		}
		public Int64 diasVigentes
		{
			get { return _diasVigentes; }
			set { _diasVigentes = value; }
		}
		public string CadenaXml
		{
			get { return _CadenaXml; }
			set { _CadenaXml = value; }
		}
		
		//Lista Opcional
		public string montoApadece
		{
			get { return _montoApadece; }
			set { _montoApadece = value; }
		}
		public string cargoFijoDiario
		{
			get { return _cargoFijoDiario; }
			set { _cargoFijoDiario = value; }
		}
		public string precioLista
		{
			get { return _precioLista; }
			set { _precioLista = value; }
		}
		public string precioVenta
		{
			get { return _precioVenta; }
			set { _precioVenta = value; }
		}
		public string diasBloqueadoSusp
		{
			get { return _diasBloqueadoSusp; }
			set { _diasBloqueadoSusp = value; }
		}
		public string fechaFinVigReal
		{
			get { return _fechaFinVigReal; }
			set { _fechaFinVigReal = value; }
		}		
		public string descripcionEstadoAcuerdo
		{
			get { return _descripcionEstadoAcuerdo; }
			set { _descripcionEstadoAcuerdo = value; }
		}		
		public string finVigenciaReal		{
			get { return _finVigenciaReal; }
			set { _finVigenciaReal = value; }
		}
		

	}
}
