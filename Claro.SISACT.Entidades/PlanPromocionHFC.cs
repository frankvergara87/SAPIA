using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PlanPromHFC.
	/// </summary>
	public class PlanPromocionHFC
	{
		public PlanPromocionHFC()
		{
		}
		private Int64 _IDDET;
		private Int64 _IdProducto;
		private Int64 _IdLinea;
		private Int64 _IdPromocion;
		private string _Promocion;

		public Int64 IDDET
		{
			get { return this._IDDET; }
			set { this._IDDET = value; }
		}

		public Int64 IdProducto
		{
			get { return this._IdProducto; }
			set { this._IdProducto = value; }
		}

		public Int64 IdLinea
		{
			get { return this._IdLinea; }
			set { this._IdLinea = value; }
		}

		public Int64 IdPromocion
		{
			get { return this._IdPromocion; }
			set { this._IdPromocion = value; }
		}

		public string Promocion
		{
			get { return this._Promocion; }
			set { this._Promocion = value; }
		}
	}
}
