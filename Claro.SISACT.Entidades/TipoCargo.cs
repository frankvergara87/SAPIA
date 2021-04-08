using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de TipoCargo.
	/// </summary>
	[Serializable]
	public class TipoCargo
	{
		private string _TCARC_CODIGO;
		private string _TCARV_DESCRIPCION;
		private string _TCARC_ESTADO;

		public string TCARC_CODIGO {get{ return _TCARC_CODIGO;} set{_TCARC_CODIGO = value;}}
		public string TCARV_DESCRIPCION {get{ return _TCARV_DESCRIPCION;} set{_TCARV_DESCRIPCION = value;}}
		public string TCARC_ESTADO {get{ return _TCARC_ESTADO;} set{_TCARC_ESTADO = value;}}

		public TipoCargo()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
	}
}
