using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Renta.
	/// </summary>
	public class Renta
	{
		private string _autonomia;
		private string _codGarantia;
		private string _desGarantia;
		private double _nroRenta = 0;
		private double _importe = 0.0;
		private string _codProducto;
		private string _desProducto;
		private double _CF = 0.0;

		public Renta()
		{}

		public Renta(string codGarantia)
		{
			this.codGarantia = codGarantia;
		}

		public string autonomia
		{
			get{ return _autonomia; }
			set{ _autonomia = value; }
		}
		public string codGarantia
		{
			get{ return _codGarantia; }
			set{ _codGarantia = value; }
		}
		public string desGarantia
		{
			get{ return _desGarantia; }
			set{ _desGarantia = value; }
		}
		public double nroRenta
		{
			get{ return _nroRenta; }
			set{ _nroRenta = value; }
		}
		public double importe
		{
			get{ return _importe; }
			set{ _importe = value; }
		}
		public string codProducto
		{
			get{ return _codProducto; }
			set{ _codProducto = value; }
		}
		public string desProducto
		{
			get{ return _desProducto; }
			set{ _desProducto = value; }
		}
		public double CF
		{
			get{ return _CF; }
			set{ _CF = value; }
		}
	}
}
