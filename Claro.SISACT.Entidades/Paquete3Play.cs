using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Paquete3Play.
	/// </summary>
	public class Paquete3Play
	{
		public Paquete3Play()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string _PAQTV_CODIGO;
		private string _PAQTV_DESCRIPCION;
		private string _PAQTC_ESTADO;
		private DateTime _PAQTD_FECHA_CREA;
		private string _PAQTV_USUARIO_CREA;
		private int _TPAQTV_CODIGO;
		private string _TPROC_CODIGO;
		private string _PLANC_CODIGO;
		private string _TPDOC_CODIGO;
		private string _PRDC_CODIGO;

		public string PAQTV_CODIGO
		{
			set{_PAQTV_CODIGO = value;}
			get{ return _PAQTV_CODIGO;}		
		}

		public string PAQTV_DESCRIPCION
		{
			set{_PAQTV_DESCRIPCION = value;}
			get{ return _PAQTV_DESCRIPCION;}		
		}

		public string PAQTC_ESTADO
		{
			set{_PAQTC_ESTADO = value;}
			get{ return _PAQTC_ESTADO;}		
		}

		public DateTime PAQTD_FECHA_CREA
		{
			set{_PAQTD_FECHA_CREA = value;}
			get{ return _PAQTD_FECHA_CREA;}		
		}

		public string PAQTV_USUARIO_CREA
		{
			set{_PAQTV_USUARIO_CREA = value;}
			get{ return _PAQTV_USUARIO_CREA;}		
		}

		public int TPAQTV_CODIGO
		{
			set{_TPAQTV_CODIGO = value;}
			get{ return _TPAQTV_CODIGO;}		
		}

		public string TPROC_CODIGO
		{
			set{_TPROC_CODIGO = value;}
			get{ return _TPROC_CODIGO;}		
		}

		public string PLANC_CODIGO
		{
			set{_PLANC_CODIGO = value;}
			get{ return _PLANC_CODIGO;}		
		}

		public string TPDOC_CODIGO
		{
			set{_TPDOC_CODIGO = value;}
			get{ return _TPDOC_CODIGO;}		
		}

		public string PRDC_CODIGO
		{
			set{_PRDC_CODIGO = value;}
			get{ return _PRDC_CODIGO;}		
		}

	}
}
