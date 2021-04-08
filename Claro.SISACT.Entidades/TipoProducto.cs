using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de TipoProducto.
	/// </summary>
	public class TipoProducto
	{
		/*PrimaryKey*/
		private string					_TPROC_CODIGO;
		/*PrimaryKey*/

		private string					_TPROV_DESCRIPCION;
		private string					_TPROC_ESTADO;

		public TipoProducto() { }

		public string TPROC_CODIGO
		{
			get{ return _TPROC_CODIGO; }
			set{ _TPROC_CODIGO = value; }
		}
		public string TPROV_DESCRIPCION
		{
			get{ return _TPROV_DESCRIPCION; }
			set{ _TPROV_DESCRIPCION = value; }
		}
		public string TPROC_ESTADO
		{
			get{ return _TPROC_ESTADO; }
			set{ _TPROC_ESTADO = value; }
		}
	}
}
