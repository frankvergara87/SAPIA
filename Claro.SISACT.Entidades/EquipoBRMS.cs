using System;
using System.Configuration;
namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de EquipoBRMS.
	/// </summary>
	public class EquipoBRMS
	{
		public EquipoBRMS()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
			this.tipoDeOperacionKit = "";
			this.formaDePago = "";
			this.tipoDeDeco = "";
			this.gama = ConfigurationSettings.AppSettings["constGamaEquipoBajo"].ToString();
			this.formaDePago = ConfigurationSettings.AppSettings["constFormaPagoContado"].ToString();
		}

		private string _idFila ;
		public string idFila
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
		private string _idEquipo ;
		public string idEquipo
		{
			set{_idEquipo= value;}
			get{ return _idEquipo;}
		}
		private double _costo ;
		public double costo
		{
			set{_costo= value;}
			get{ return _costo;}
		}
		private double _factorDePagoInicial ;
		public double factorDePagoInicial
		{
			set{_factorDePagoInicial= value;}
			get{ return _factorDePagoInicial;}
		}
		private double _factorDeSubsidio ;
		public double factorDeSubsidio
		{
			set{_factorDeSubsidio= value;}
			get{ return _factorDeSubsidio;}
		}
		private string _kit ;
		public string kit
		{
			set{_kit= value;}
			get{ return _kit;}
		}
		private string _gama ;
		public string gama
		{
			set{_gama= value;}
			get{ return _gama;}
		}
		private string _modelo ;
		public string modelo
		{
			set{_modelo= value;}
			get{ return _modelo;}
		}
		private double _montoDeCuota ;
		public double montoDeCuota
		{
			set{_montoDeCuota= value;}
			get{ return _montoDeCuota;}
		}
		private double _precioDeVenta ;
		public double precioDeVenta
		{
			set{_precioDeVenta= value;}
			get{ return _precioDeVenta;}
		}
		private string _grupo ;
		public string grupo
		{
			set{_grupo= value;}
			get{ return _grupo;}
		}
		private string _tipoDeOperacionKit ;
		public string tipoDeOperacionKit
		{
			set{_tipoDeOperacionKit= value;}
			get{ return _tipoDeOperacionKit;}
		}
		private string _formaDePago ;
		public string formaDePago
		{
			set{_formaDePago= value;}
			get{ return _formaDePago;}
		}
		private int _cantidadDeCuotas ;
		public int cantidadDeCuotas
		{
			set{_cantidadDeCuotas= value;}
			get{ return _cantidadDeCuotas;}
		}
		private double _porcentajeCuotaInicial ;
		public double porcentajeCuotaInicial
		{
			set{_porcentajeCuotaInicial= value;}
			get{ return _porcentajeCuotaInicial;}
		}
		private string _tipoDeDeco ;
		public string tipoDeDeco
		{
			set{_tipoDeDeco= value;}
			get{ return _tipoDeDeco;}
		}
		private string _riesgo ;
		public string riesgo
		{
			set{_riesgo= value;}
			get{ return _riesgo;}
		}
	}
}
