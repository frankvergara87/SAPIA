using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Garantia.
	/// </summary>
	public class Garantia
	{
		public Garantia()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private int _IdFila ;
		public int IdFila
		{
			set{_IdFila= value;}
			get{ return _IdFila;}
		}
		private string _idGarantia ;
		public string idGarantia
		{
			set{_idGarantia= value;}
			get{ return _idGarantia;}
		}
		private string _garantia ;
		public string garantia
		{
			set{_garantia= value;}
			get{ return _garantia;}
		}
		private double _nroGarantia ;
		public double nroGarantia
		{
			set{_nroGarantia= value;}
			get{ return _nroGarantia;}
		}
		private double _importe ;
		public double importe
		{
			set{_importe= value;}
			get{ return _importe;}
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
		private double _CF ;
		public double CF
		{
			set{_CF= value;}
			get{ return _CF;}
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
	}
}
