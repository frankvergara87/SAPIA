using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AP_VentaEquipo.
	/// </summary>
	public class AP_VentaEquipo
	{
		public AP_VentaEquipo()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private Int64 _ID_DETALLE;
		private string _MATERIAL;
		private string _MATERIAL_DES;
		private Int64 _CANTIDAD;
		private Int64 _ID_VENTA;
		private string _ID_TIPO_MATERIAL;
		
		public Int64 ID_DETALLE {get{ return _ID_DETALLE;} set{_ID_DETALLE = value;}}
		public string MATERIAL {get{ return _MATERIAL;} set{_MATERIAL = value;}}
		public string MATERIAL_DES {get{ return _MATERIAL_DES;} set{_MATERIAL_DES = value;}}
		public Int64 CANTIDAD {get{ return _CANTIDAD;} set{_CANTIDAD = value;}}
		public Int64 ID_VENTA {get{ return _ID_VENTA;} set{_ID_VENTA = value;}}
		public string ID_TIPO_MATERIAL {get{ return _ID_TIPO_MATERIAL;} set{_ID_TIPO_MATERIAL = value;}}
	}
}
