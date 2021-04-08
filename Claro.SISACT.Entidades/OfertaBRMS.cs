using System;
using System.Collections;
namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de OfertaBRMS.
	/// </summary>
	public class OfertaBRMS
	{
		public OfertaBRMS()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private int _idFila ;
		public int idFila
		{
			set{_idFila= value;}
			get{ return _idFila;}
		}
		private string _idProducto ;
		public string idProducto
		{
			set{_idProducto= value;}
			get{ return _idProducto;}
		}
		private string _producto ;
		public string producto
		{
			set{_producto= value;}
			get{ return _producto;}
		}
		private string _idPlazo ;
		public string idPlazo
		{
			set{_idPlazo= value;}
			get{ return _idPlazo;}
		}
		private string _plazo ;
		public string plazo
		{
			set{_plazo= value;}
			get{ return _plazo;}
		}
		private string _idPaquete ;
		public string idPaquete
		{
			set{_idPaquete= value;}
			get{ return _idPaquete;}
		}
		private string _paquete ;
		public string paquete
		{
			set{_paquete= value;}
			get{ return _paquete;}
		}
		private string _idPlan ;
		public string idPlan
		{
			set{_idPlan= value;}
			get{ return _idPlan;}
		}
		private string _plan ;
		public string plan
		{
			set{_plan= value;}
			get{ return _plan;}
		}
		private string _idCampana ;
		public string idCampana
		{
			set{_idCampana= value;}
			get{ return _idCampana;}
		}
		private string _campana ;
		public string campana
		{
			set{_campana= value;}
			get{ return _campana;}
		}
		private double _cargoFijo ;
		public double cargoFijo
		{
			set{_cargoFijo= value;}
			get{ return _cargoFijo;}
		}
		private string _topeConsumo ;
		public string topeConsumo
		{
			set{_topeConsumo= value;}
			get{ return _topeConsumo;}
		}
		private ArrayList _oEquipo;
		public ArrayList oEquipo
		{
			set{_oEquipo= value;}
			get{ return _oEquipo;}
		}
		private ArrayList _oServicio ;
		public ArrayList oServicio
		{
			set{_oServicio= value;}
			get{ return _oServicio;}
		}
		private ArrayList _oBilletera ;
		public ArrayList oBilletera
		{
			set{_oBilletera= value;}
			get{ return _oBilletera;}
		}
		//gaa20170215
		private int _cantidadLineasSEC;
		public int cantidadLineasSEC 
		{
			set{_cantidadLineasSEC= value;}
			get{ return _cantidadLineasSEC;}
		}
		private double _montoCFSEC;
		public double montoCFSEC
		{
			set{_montoCFSEC= value;}
			get{ return _montoCFSEC;}
		}
		//fin gaa20170215
	}
}
