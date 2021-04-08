using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for ErrorInfo.
	/// </summary>
	public class ErrorInfo
	{
		private string _pagina_origen ;
		private string _error_titulo ;
		private string _error_detalle ;
		private string _error_tecnico;
		private string _error_trace;
		private string _error_source;
		public ErrorInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string pagina_origen{
			set{ _pagina_origen = value;}
			get{ return _pagina_origen ;}
		}
		public string error_titulo
		{
			set{ _error_titulo = value;}
			get{ return _error_titulo ;}
		}
		public string error_detalle 
		{
			set{ _error_detalle = value;}
			get{ return _error_detalle ;}
		}
		public string error_tecnico
		{
			set{ _error_tecnico = value;}
			get{ return _error_tecnico ;}
		}
		public string error_trace
		{
			set{ _error_trace= value;}
			get{ return _error_trace;}
		}
		public string error_source{
			set{ _error_source = value;}
			get{ return _error_source;}
		}

	}
}
