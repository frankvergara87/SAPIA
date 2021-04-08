using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Descuento.
	/// </summary>
	public class Descuento
	{
		public Descuento()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private string _idCombo ;
		public string idCombo
		{
			get { return this._idCombo; }
			set { this._idCombo = value; }
		}
		private string _idProducto ;
		public string idProducto
		{
			get { return this._idProducto; }
			set { this._idProducto = value; }
		}
		private string _tipoDescuento;
		public string tipoDescuento
		{
			get { return this._tipoDescuento; }
			set { this._tipoDescuento = value; }
		}
		private double _montoDescuento ;
		public double montoDescuento
		{
			get { return this._montoDescuento; }
			set { this._montoDescuento = value; }
		}
		private int _mesesAplicacion ;
		public int mesesAplicacion
		{
			get { return this._mesesAplicacion; }
			set { this._mesesAplicacion = value; }
		}

		public enum TIPO_DESCUENTO
		{
			DSCTO_MONTO = 1,
			DSCTO_PORCENTAJE = 2
		}
	}
}
