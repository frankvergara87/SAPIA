using System;

namespace Claro.SisAct.Entidades
{

	public class NumeroPortabilidad
	{
		public NumeroPortabilidad()
		{ }

		private int _SOLIN_CODIGO;
		public int SOLIN_CODIGO
		{
			set{_SOLIN_CODIGO = value;}
			get{ return _SOLIN_CODIGO;}
		}

		private string _PORT_NUM_DOC;
		public string PORT_NUM_DOC
		{
			set{_PORT_NUM_DOC = value;}
			get{ return _PORT_NUM_DOC;}
		}

		private string _PLANC_CODIGO;
		public string PLANC_CODIGO
		{
			set{_PLANC_CODIGO = value;}
			get{ return _PLANC_CODIGO;}
		}

		private string _PORT_NUMERO;
		public string PORT_NUMERO
		{
			set{_PORT_NUMERO = value;}
			get{ return _PORT_NUMERO;}
		}

		private string _FLAG_ESTADO;
		public string FLAG_ESTADO
		{
			set{_FLAG_ESTADO = value;}
			get{ return _FLAG_ESTADO;}
		}

		private string _TPROC_CODIGO;
		public string TPROC_CODIGO
		{
			set{_TPROC_CODIGO = value;}
			get{ return _TPROC_CODIGO;}
		}

		private string _PORT_USU_CREA;
		public string PORT_USU_CREA
		{
			set{_PORT_USU_CREA = value;}
			get{ return _PORT_USU_CREA;}
		}
		private string _MENSAJE_ERROR;
		public string MENSAJE_ERROR
		{
			set{ _MENSAJE_ERROR= value;}
			get{ return _MENSAJE_ERROR;}
		}
		private string _ESTADO;
		public string ESTADO
		{
			set{ _ESTADO = value;}
			get{ return _ESTADO;}
		}
		private string _PREFIJO;
		public string PREFIJO
		{
			set{ _PREFIJO = value;}
			get{ return _PREFIJO;}
		}
		private string _DESC_ESTADO;
		public string DESC_ESTADO
		{
			set{ _DESC_ESTADO = value;}
			get{ return _DESC_ESTADO;}
		}
		private string _PORT_MODALIDAD;
		public string PORT_MODALIDAD
		{
			set{ _PORT_MODALIDAD = value;}
			get{ return _PORT_MODALIDAD;}
		}
		private int _SOPLN_CODIGO;
		public int SOPLN_CODIGO
		{
			set{_SOPLN_CODIGO = value;}
			get{ return _SOPLN_CODIGO;}
		}

		private int _SOPLN_TOPE_CONSUMO = 0;
		public int SOPLN_TOPE_CONSUMO
		{
			set{_SOPLN_TOPE_CONSUMO = value;}
			get{ return _SOPLN_TOPE_CONSUMO;}
		}
	}
}
