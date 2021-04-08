using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de TipoBloqueo.
	/// </summary>
	public class TipoBloqueo
	{
		private string _ID_CODIGO;
		private string _DESCRIPCION;
		private string _VENTA;

		public TipoBloqueo(){}
		
		public string ID_CODIGO
		{
			set{_ID_CODIGO= value;}
			get{return _ID_CODIGO;}
		}

		public string DESCRIPCION
		{
			set{_DESCRIPCION= value;}
			get{return _DESCRIPCION;}
		}

		public string VENTA
		{
			set{_VENTA= value;}
			get{return _VENTA;}
		}
	}
}
