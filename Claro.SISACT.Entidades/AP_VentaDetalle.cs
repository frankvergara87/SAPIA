using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AP_VentaDetalle.
	/// </summary>
	public class AP_VentaDetalle
	{
		public AP_VentaDetalle()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private Int64 _ID_DOCUMENTO;
		private string _TELEFONO;
		private string _MATERIAL;
		private string _MATERIAL_DESC;
		private Int64 _CANTIDAD;
		private float _PRECIO;
		private float _DESCUENTO;
		private float _SUBTOTAL;
		private float _IGV;
		private float _TOTAL;
		private string _PLAN;
		private string _PLAN_DESC;
		private string _CAMPANA;
		private string _CAMPANA_DESC;
		private string _LISTA_PRECIO;
		private string _LISTA_PRECIO_DESC;
		private Int64 _ORDEN;
		private string _IMEI19;
		private string _PLAZO;		

		public Int64 ID_DOCUMENTO {get{ return _ID_DOCUMENTO;} set{_ID_DOCUMENTO = value;}}
		public string TELEFONO {get{ return _TELEFONO;} set{_TELEFONO = value;}}
		public string MATERIAL {get{ return _MATERIAL;} set{_MATERIAL = value;}}
		public string MATERIAL_DESC {get{ return _MATERIAL_DESC;} set{_MATERIAL_DESC = value;}}
		public Int64 CANTIDAD {get{ return _CANTIDAD;} set{_CANTIDAD = value;}}
		public float PRECIO {get{ return _PRECIO;} set{_PRECIO = value;}}
		public float DESCUENTO {get{ return _DESCUENTO;} set{_DESCUENTO = value;}}
		public float SUBTOTAL {get{ return _SUBTOTAL;} set{_SUBTOTAL = value;}}
		public float IGV {get{ return _IGV;} set{_IGV = value;}}
		public float TOTAL {get{ return _TOTAL;} set{_TOTAL = value;}}
		public string PLAN {get{ return _PLAN;} set{_PLAN = value;}}
		public string PLAN_DESC {get{ return _PLAN_DESC;} set{_PLAN_DESC = value;}}
		public string CAMPANA {get{ return _CAMPANA;} set{_CAMPANA = value;}}
		public string CAMPANA_DESC {get{ return _CAMPANA_DESC;} set{_CAMPANA_DESC = value;}}
		public string LISTA_PRECIO {get{ return _LISTA_PRECIO;} set{_LISTA_PRECIO = value;}}
		public string LISTA_PRECIO_DESC {get{ return _LISTA_PRECIO_DESC;} set{_LISTA_PRECIO_DESC = value;}}
		public Int64 ORDEN {get{ return _ORDEN;} set{_ORDEN = value;}}
		public string IMEI19 {get{ return _IMEI19;} set{_IMEI19 = value;}}
		public string PLAZO {get{ return _PLAZO;} set{_PLAZO = value;}}

	}
}
