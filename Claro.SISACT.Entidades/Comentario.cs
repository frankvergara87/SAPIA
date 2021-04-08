using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Comentario.
	/// </summary>
	public class Comentario
	{
		private int _COMEC_CODIGO;
	    private Int64 _SOLIN_CODIGO;
	    private string _COMEV_COMENTARIO;
		private string _COMEC_USU_REG;
		private DateTime _COMED_FEC_REG;
		private string _COMEC_ESTADO;
		private string _COMEC_FLA_COM;
		private string _COMEC_FLA_COM_DES;
		
		public Comentario()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public int COMEC_CODIGO
		{
			set{_COMEC_CODIGO = value;}
			get{ return _COMEC_CODIGO;}
		}
		public Int64 SOLIN_CODIGO
		{
			set{_SOLIN_CODIGO = value;}
			get{ return _SOLIN_CODIGO;}
		}
		public string COMEV_COMENTARIO
		{
			set{_COMEV_COMENTARIO = value;}
			get{ return _COMEV_COMENTARIO;}
		}
		public string COMEC_USU_REG
		{
			set{_COMEC_USU_REG = value;}
			get{ return _COMEC_USU_REG;}
		}
		public DateTime COMED_FEC_REG
		{
			set{_COMED_FEC_REG = value;}
			get{ return _COMED_FEC_REG;}
		}
		public string COMEC_ESTADO
		{
			set{_COMEC_ESTADO = value;}
			get{ return _COMEC_ESTADO;}
		}
		public string COMEC_FLA_COM
		{
			set{_COMEC_FLA_COM = value;}
			get{ return _COMEC_FLA_COM;}
		}
		public string COMEC_FLA_COM_DES
		{
			set{_COMEC_FLA_COM_DES = value;}
			get{ return _COMEC_FLA_COM_DES;}
		}
	}
}
