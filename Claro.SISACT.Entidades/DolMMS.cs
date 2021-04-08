using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for DolMMS.
	/// </summary>
	public class DolMMS
	{

		private string _codRegistro;
		private string _msisdn;
		private string _tipoDocumento;
		private string _numDocumento;
		private string _codUsuario;
		private string _codOficina;
		private DateTime _fecRegistro;
		private string _urlArchivo;
		private string _codSistema;
		private string _estado;
		private string _flgDummy;
		private string _fecNac;

		public DolMMS(){}

		public string CodRegistro
		{
			set{_codRegistro= value;}
			get{ return _codRegistro;}
		}
		public string Msisdn
		{
			set{_msisdn= value;}
			get{ return _msisdn;}
		}
		public string TipoDocumento
		{
			set{_tipoDocumento= value;}
			get{ return _tipoDocumento;}
		}
		public string NumDocumento
		{
			set{_numDocumento= value;}
			get{ return _numDocumento;}
		}
		public string CodUsuario
		{
			set{_codUsuario= value;}
			get{ return _codUsuario;}
		}
		public string CodOficina
		{
			set{_codOficina= value;}
			get{ return _codOficina;}
		}
		public DateTime FecRegistro
		{
			set{_fecRegistro= value;}
			get{ return _fecRegistro;}
		}
		public string UrlArchivo
		{
			set{_urlArchivo= value;}
			get{ return _urlArchivo;}
		}
		public string CodSistema
		{
			set{_codSistema= value;}
			get{ return _codSistema;}
		}
		public string Estado
		{
			set{_estado= value;}
			get{ return _estado;}
		}
		public string FlgDummy
		{
			set{_flgDummy= value;}
			get{ return _flgDummy;}
		}
		public string FecNac
		{
			set{_fecNac= value;}
			get{ return _fecNac;}
		}


	}
}
