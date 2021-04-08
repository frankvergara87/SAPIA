using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Whitelist.
	/// </summary>
	public class Whitelist
	{
		public Whitelist()
		{

		}

		private string _TipoDocumento;
		private string _NroDocumento;
		private string _Nombre;
		private int _CantidadDias;
		private Single _MontoDeuda;
		private int _TasaBloqueo;
		private string _ObservacionCredito;
		private string _VigenciaIndefinida;
		private int _VigenciaDias;
		private string _UsuarioAprobador;
		private string _NombreUsuarioAprobador;
		private string _Estado;
		private string _FechaRegistro;

		public string TipoDocumento
		{
			get{ return _TipoDocumento;}
			set{ _TipoDocumento = value; }
		}
		public string NroDocumento
		{
			get{ return _NroDocumento;}
			set{ _NroDocumento = value; }
		}
		public string Nombre
		{
			get{ return _Nombre;}
			set{ _Nombre = value; }
		}
		public int CantidadDias
		{
			get{ return _CantidadDias;}
			set{ _CantidadDias = value; }
		}
		public Single MontoDeuda
		{
			get{ return _MontoDeuda;}
			set{ _MontoDeuda = value; }
		}
		public int TasaBloqueo
		{
			get{ return _TasaBloqueo;}
			set{ _TasaBloqueo = value; }
		}
		public string ObservacionCredito
		{
			get{ return _ObservacionCredito;}
			set{ _ObservacionCredito = value; }
		}
		public string VigenciaIndefinida
		{
			get{ return _VigenciaIndefinida;}
			set{ _VigenciaIndefinida = value; }
		}
		public int VigenciaDias
		{
			get{ return _VigenciaDias;}
			set{ _VigenciaDias = value; }
		}
		public string UsuarioAprobador
		{
			get{ return _UsuarioAprobador;}
			set{ _UsuarioAprobador = value; }
		}
		public string NombreUsuarioAprobador
		{
			get{ return _NombreUsuarioAprobador;}
			set{ _NombreUsuarioAprobador = value; }
		}
		public string Estado
		{
			get{ return _Estado;}
			set{ _Estado = value; }
		}
		public string FechaRegistro
		{
			get{ return _FechaRegistro;}
			set{ _FechaRegistro = value; }
		}
	}
}
