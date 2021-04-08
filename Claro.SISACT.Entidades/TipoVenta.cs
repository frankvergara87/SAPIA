using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de TipoVenta.
	/// </summary>
	public class TipoVenta
	{
		/*PrimaryKey*/
		private string					_TVENC_CODIGO;
		private string					_TPROC_CODIGO;
		/*PrimaryKey*/

		/*Referencia a otra Entidad*/
		private TipoProducto			_TIPO_PRODUCTO;
		private string					_TVENV_DESCRIPCION;

		private string					_TVENC_ESTADO;

		public TipoVenta() { }

		public string TVENC_CODIGO
		{
			get{ return _TVENC_CODIGO; }
			set{ _TVENC_CODIGO = value; }
		}
		public string TPROC_CODIGO
		{
			get{ return _TPROC_CODIGO; }
			set{ _TPROC_CODIGO = value; }
		}
		public TipoProducto TIPO_PRODUCTO
		{
			get{ return _TIPO_PRODUCTO; }
			set{ _TIPO_PRODUCTO = value; }
		}
		public string TVENV_DESCRIPCION
		{
			get{ return _TVENV_DESCRIPCION; }
			set{ _TVENV_DESCRIPCION = value; }
		}
		public string TVENC_ESTADO
		{
			get{ return _TVENC_ESTADO; }
			set{ _TVENC_ESTADO = value; }
		}
	}
}
