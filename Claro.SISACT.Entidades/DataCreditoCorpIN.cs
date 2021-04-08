using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de DataCreditoCorpIN.
	/// </summary>
	public class DataCreditoCorpIN
	{
		private string _istrTipoDocumento = "";
		private string _istrNumeroDocumento = "";
		private string _istrApellidoPaterno = "";
		private string _istrApellidoMaterno = "";
		private string _istrNombres = "";
		private string _istrTipoPersona = "";
		private string _istrCodSolicitud = "";

		// Variables de apoyo
		private string _istrPuntoVenta = "";
		private string _istrTipoSEC = "";
		// Variables de apoyo

		public DataCreditoCorpIN()
		{}

		public string istrTipoDocumento
		{
			set{ _istrTipoDocumento = value; }
			get{ return _istrTipoDocumento; }
		}
		public string istrNumeroDocumento
		{
			set{ _istrNumeroDocumento = value; }
			get{ return _istrNumeroDocumento; }
		}
		public string istrApellidoPaterno
		{
			set{ _istrApellidoPaterno = value; }
			get{ return _istrApellidoPaterno; }
		}
		public string istrApellidoMaterno
		{
			set{ _istrApellidoMaterno = value; }
			get{ return _istrApellidoMaterno; }
		}
		public string istrNombres
		{
			set{ _istrNombres = value; }
			get{ return _istrNombres; }
		}
		public string istrTipoPersona
		{
			set{ _istrTipoPersona = value; }
			get{ return _istrTipoPersona; }
		}
		public string istrCodSolicitud
		{
			set{ _istrCodSolicitud = value; }
			get{ return _istrCodSolicitud; }
		}
		public string istrPuntoVenta
		{
			set{ _istrPuntoVenta = value; }
			get{ return _istrPuntoVenta; }
		}
		public string istrTipoSEC
		{
			set{ _istrTipoSEC = value; }
			get{ return _istrTipoSEC; }
		}
	}
}
