using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Archivo.
	/// </summary>
	public class Archivo
	{
		private string  _ARCHIVO_CODIGO;
		private string  _SOLIN_CODIGO;
		private string  _ARCHIVO_NOM;
		private string  _ARCHIVO_RUTA;
		private string  _ARCHIVO_FEC_REG;
		private string _ARCHIVO_USU_REG;
		private string  _ARCHIVO_ESTADO;
		
		public Archivo()
		{
		}
		public string  ARCHIVO_CODIGO
		{
			set{_ARCHIVO_CODIGO= value;}
			get{ return _ARCHIVO_CODIGO;}
		}	
		public string SOLIN_CODIGO
		{
			set{_SOLIN_CODIGO= value;}
			get{ return _SOLIN_CODIGO;}
		}
		public string ARCHIVO_NOM
		{
			set{_ARCHIVO_NOM= value;}
			get{ return _ARCHIVO_NOM;}
		}
		public string ARCHIVO_RUTA
		{
			set{_ARCHIVO_RUTA= value;}
			get{ return _ARCHIVO_RUTA;}
		}
		public string ARCHIVO_FEC_REG
		{
			set{_ARCHIVO_FEC_REG= value;}
			get{ return _ARCHIVO_FEC_REG;}
		}
		public string ARCHIVO_USU_REG
		{
			set{_ARCHIVO_USU_REG= value;}
			get{ return _ARCHIVO_USU_REG;}
		}
		public string ARCHIVO_ESTADO
		{
			set{_ARCHIVO_ESTADO= value;}
			get{ return _ARCHIVO_ESTADO;}
		}
	}
}
