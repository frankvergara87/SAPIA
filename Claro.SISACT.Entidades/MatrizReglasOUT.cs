using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de MatrizReglasOUT.
	/// </summary>
	public class MatrizReglasOUT
	{
		private string _restriccion;
		private string _tipoGarantia;
		private string _absolutoReferencial;
		private string _montoGarantia;
		private string _costoInstalacion;
		private string _cantidadProductoMax;
		private string _producto;
		private double _cargoFijo;
		private double _cargoFijoEval;
		private string _autonomia;
		private string _orden;
		private string _respuestaRenovacion;

		public MatrizReglasOUT()
		{	}

		public string Restriccion
		{
			get { return this._restriccion; }
			set { this._restriccion = value; }
		}

		public string TipoGarantia
		{
			get { return this._tipoGarantia; }
			set { this._tipoGarantia = value; }
		}

		public string AbsolutoReferencial
		{
			get { return this._absolutoReferencial; }
			set { this._absolutoReferencial = value; }
		}

		public string MontoGarantia
		{
			get { return this._montoGarantia; }
			set { this._montoGarantia = value; }
		}

		public string CostoInstalacion
		{
			get { return this._costoInstalacion; }
			set { this._costoInstalacion = value; }
		}

		public string CantidadProductoMax
		{
			get { return this._cantidadProductoMax; }
			set { this._cantidadProductoMax = value; }
		}

		public string Producto
		{
			get { return this._producto; }
			set { this._producto = value; }
		}

		public double CargoFijo
		{
			get { return this._cargoFijo; }
			set { this._cargoFijo = value; }
		}

		public double CargoFijoEval
		{
			get { return this._cargoFijoEval; }
			set { this._cargoFijoEval = value; }
		}

		public string Autonomia
		{
			get { return this._autonomia; }
			set { this._autonomia = value; }
		}

		public string Orden
		{
			get { return this._orden; }
			set { this._orden = value; }
		}	

		public string respuestaRenovacion
		{
			get { return this._respuestaRenovacion; }
			set { this._respuestaRenovacion = value; }
		}	
	}
}
