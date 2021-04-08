using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for LineaBloqueo.
	/// </summary>
	public class LineaBloqueo
	{
		private string _LINEA;
		private string _CUSTOMER_ID;
		private string _CO_ID;
		private string _TICKLER;
		private string _DESCRIPCION;
		private string _FECHA_TICKLER;
		private string _DESCRIPCION_LARGA;

		public LineaBloqueo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string LINEA
		{
			set{_LINEA= value;}
			get{return _LINEA;}
		}

		public string CUSTOMER_ID
		{
			set{_CUSTOMER_ID= value;}
			get{return _CUSTOMER_ID;}
		}

		public string CO_ID
		{
			set{_CO_ID= value;}
			get{return _CO_ID;}
		}

		public string TICKLER
		{
			set{_TICKLER= value;}
			get{return _TICKLER;}
		}

		public string DESCRIPCION
		{
			set{_DESCRIPCION= value;}
			get{return _DESCRIPCION;}
		}

		public string FECHA_TICKLER
		{
			set {_FECHA_TICKLER = value;}
			get {return _FECHA_TICKLER;}
		}

		public string DESCRIPCION_LARGA
		{
			set{_DESCRIPCION_LARGA= value;}
			get{return _DESCRIPCION_LARGA;}
		}
		
	}
}
