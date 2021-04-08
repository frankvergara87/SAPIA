using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PlanSolicitudDTH.
	/// </summary>
	public class PlanSolicitudDTH
	{
		public PlanSolicitudDTH()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private AP_Venta _VENTA_DTH;
		private AP_VentaDetalle _VENTA_DET_DTH;
		private AP_Garantia _GARANTIA_DTH;

		public AP_Venta VENTA_DTH
		{
			get { return this._VENTA_DTH; }
			set { this._VENTA_DTH = value; }
		}

		public AP_VentaDetalle VENTA_DET_DTH
		{
			get { return this._VENTA_DET_DTH; }
			set { this._VENTA_DET_DTH = value; }
		}

		public AP_Garantia GARANTIA_DTH
		{
			get { return this._GARANTIA_DTH; }
			set { this._GARANTIA_DTH = value; }
		}
	}
}
