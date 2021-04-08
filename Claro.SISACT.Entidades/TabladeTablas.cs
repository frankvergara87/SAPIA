using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for TabladeTablas.
	/// </summary>
	public class TabladeTablas
	{
		private string _TABLN_CODIGO;
		private string _TABLN_TIPO;
		private string _TABLN_DESCRIPCION;
		private string _TABLN_ESTADO;
		private string _TABLN_ORDEN;
		private string _TABLN_DESCRIPCION_TT; 
		private string _TABLN_FLAG_SISTEMA; 
		

		public TabladeTablas(){}

		public TabladeTablas(string _CODIGO,string _DESCRIPCION){
			_TABLN_CODIGO = _CODIGO;
			_TABLN_DESCRIPCION = _DESCRIPCION;
		}

	
		public string TABLN_CODIGO
		{
			get{ return _TABLN_CODIGO;}
			set{ _TABLN_CODIGO= value;}
		}

		public string TABLN_TIPO
		{
			get{ return _TABLN_TIPO;}
			set{ _TABLN_TIPO= value;}
		}

		public string TABLN_DESCRIPCION
		{
			get{ return _TABLN_DESCRIPCION;}
			set{ _TABLN_DESCRIPCION= value;}
		}
		public string TABLN_ESTADO
		{
			get{ return _TABLN_ESTADO;}
			set{ _TABLN_ESTADO= value;}
		}
		public string TABLN_ORDEN
		{
			get{ return _TABLN_ORDEN;}
			set{ _TABLN_ORDEN= value;}
		}

		public string TABLN_DESCRIPCION_TT
		{
			get{ return _TABLN_DESCRIPCION_TT;}
			set{ _TABLN_DESCRIPCION_TT= value;}
		}

		public string TABLN_FLAG_SISTEMA
		{
			get{ return _TABLN_FLAG_SISTEMA;}
			set{ _TABLN_FLAG_SISTEMA= value;}
		}

	}
}
