using System;
using System.Collections;
namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de VistaEvaluacion.
	/// </summary>
	public class VistaEvaluacion
	{
		public VistaEvaluacion()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private string _exoneraRA ;
		public string exoneraRA
		{
			set{_exoneraRA= value;}
			get{ return _exoneraRA;}
		}
		private string _riesgoClaro ;
		public string riesgoClaro
		{
			set{_riesgoClaro= value;}
			get{ return _riesgoClaro;}
		}
		private string _comportamientoPago ;
		public string comportamientoPago
		{
			set{_comportamientoPago= value;}
			get{ return _comportamientoPago;}
		}
		private double _LCDisponible ;
		public double LCDisponible
		{
			set{_LCDisponible= value;}
			get{ return _LCDisponible;}
		}
		private string _rangoLCDisponible ;
		public string rangoLCDisponible
		{
			set{_rangoLCDisponible= value;}
			get{ return _rangoLCDisponible;}
		}
		private string _poderes ;
		public string poderes
		{
			set{_poderes= value;}
			get{ return _poderes;}
		}
		private double _importeGarantia ;
		public double importeGarantia
		{
			set{_importeGarantia= value;}
			get{ return _importeGarantia;}
		}
		private double _cargoFijo ;
		public double cargoFijo
		{
			set{_cargoFijo= value;}
			get{ return _cargoFijo;}
		}
		private string _tipoGarantia ;
		public string tipoGarantia
		{
			set{_tipoGarantia= value;}
			get{ return _tipoGarantia;}
		}
		private string _planAutonomia ;
		public string planAutonomia
		{
			set{_planAutonomia= value;}
			get{ return _planAutonomia;}
		}
		private ArrayList _oOfrecimiento ;
		public ArrayList oOfrecimiento
		{
			set{_oOfrecimiento= value;}
			get{ return _oOfrecimiento;}
		}
		private ArrayList _oGarantia ;
		public ArrayList oGarantia
		{
			set{_oGarantia= value;}
			get{ return _oGarantia;}
		}
		private ArrayList _oMensaje ;
		public ArrayList oMensaje
		{
			set{_oMensaje= value;}
			get{ return _oMensaje;}
		}

	}
}
