using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Kit_Equipo_AP.
	/// </summary>
	public class Kit_Equipo_AP
	{
		private int _KEQN_CORRELATIVO;
		private int _KITV_CODIGO;
		private string _KEQV_CODIGO;
		private DateTime _KEQD_FECHA_CREA;
		private string _KEQV_USUARIO_CREA;
		private int _KEQN_CANTIDAD;
		private string _MATV_DESCRIPCION;

		public int KEQN_CORRELATIVO {get{ return _KEQN_CORRELATIVO;} set{_KEQN_CORRELATIVO = value;}}
		public int KITV_CODIGO {get{ return _KITV_CODIGO;} set{_KITV_CODIGO = value;}}
		public string KEQV_CODIGO {get{ return _KEQV_CODIGO;} set{_KEQV_CODIGO = value;}}
		public DateTime KEQD_FECHA_CREA {get{ return _KEQD_FECHA_CREA;} set{_KEQD_FECHA_CREA = value;}}
		public string KEQV_USUARIO_CREA {get{ return _KEQV_USUARIO_CREA;} set{_KEQV_USUARIO_CREA = value;}}
		public int KEQN_CANTIDAD {get{ return _KEQN_CANTIDAD;} set{_KEQN_CANTIDAD = value;}}
		public string MATV_DESCRIPCION {get{ return _MATV_DESCRIPCION;} set{_MATV_DESCRIPCION = value;}}

		public Kit_Equipo_AP()
		{
			KEQN_CORRELATIVO = 0;
			KITV_CODIGO = 0;
			KEQV_CODIGO = String.Empty;
			KEQD_FECHA_CREA = new DateTime();
			KEQV_USUARIO_CREA = String.Empty;
			KEQN_CANTIDAD = 0;
			MATV_DESCRIPCION= String.Empty;
		}
	}
}
