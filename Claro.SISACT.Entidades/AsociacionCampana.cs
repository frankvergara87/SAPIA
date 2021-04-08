using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AsociacionCampana.
	/// </summary>
	public class AsociacionCampana
	{
		private string _COD_ASOCIACION;
		private string _CAMPANA_PADRE;
		private string _CAMPANA_HIJA;
		private string _TIPO_PRODUCTO_PADRE;
		private string _TIPO_PRODUCTO_HIJA;
		private string _DESCRIPCION;
		private DateTime _FECHA_INICIO;
		private DateTime _FECHA_FIN;
		private string _ESTADO;

		public string COD_ASOCIACION
		{
			set{_COD_ASOCIACION = value;}
			get{ return _COD_ASOCIACION;}
		}

		public string CAMPANA_PADRE
		{
			set{_CAMPANA_PADRE = value;}
			get{ return _CAMPANA_PADRE;}
		}

		public string CAMPANA_HIJA
		{
			set{_CAMPANA_HIJA = value;}
			get{ return _CAMPANA_HIJA;}
		}
		
		public string TIPO_PRODUCTO_PADRE
		{
			set{_TIPO_PRODUCTO_PADRE = value;}
			get{ return _TIPO_PRODUCTO_PADRE;}
		}

		public string TIPO_PRODUCTO_HIJA
		{
			set{_TIPO_PRODUCTO_HIJA = value;}
			get{ return _TIPO_PRODUCTO_HIJA;}
		}

		public string DESCRIPCION
		{
			set{_DESCRIPCION = value;}
			get{ return _DESCRIPCION;}
		}

		public DateTime FECHA_INICIO
		{
			set{_FECHA_INICIO = value;}
			get{ return _FECHA_INICIO;}
		}

		public DateTime FECHA_FIN
		{
			set{_FECHA_FIN = value;}
			get{ return _FECHA_FIN;}
		}

		public string ESTADO
		{
			set{_ESTADO = value;}
			get{ return _ESTADO;}
		}

		public AsociacionCampana()
		{
			FECHA_INICIO = DateTime.MinValue;
			FECHA_FIN = DateTime.MinValue;

		}
	}

}
