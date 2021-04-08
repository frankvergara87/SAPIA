using System;
using System.Text;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Evalenzs - Clase Nueva
	/// </summary>
	public class NivelAprobacion
	{
		private string _CODIGO;
		private string _ESTADO;
		private string _CANAL;
		private string _DIASMINIMO;
		private string _CLIENTE;

		public NivelAprobacion()
		{
			this._CODIGO = string.Empty;
			this._ESTADO = string.Empty;
			this._CANAL = string.Empty;
			this._DIASMINIMO = string.Empty;
			this._CLIENTE = string.Empty;
		}

		public string CODIGO
		{
			get { return _CODIGO; }
			set { _CODIGO = value; }
		}

		public string ESTADO
		{
			get { return _ESTADO; }
			set { _ESTADO = value; }
		}

		public string CANAL
		{
			get { return _CANAL; }
			set { _CANAL = value; }
		}
		public string DIASMINIMO
		{
			get { return _DIASMINIMO; }
			set { _DIASMINIMO = value; }
		}

		public string CLIENTE
		{
			get { return _CLIENTE; }
			set { _CLIENTE = value; }
		}
	}
}
