using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for PaquetePlan3Play.
	/// </summary>
	public class PaquetePlan3Play
	{
		public PaquetePlan3Play()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private int _PAQPN_CORRELATIVO;
		private int _PAQPN_SECUENCIA;
		private string _PAQTV_CODIGO;
		private string _PLNV_CODIGO;
		private decimal _PAQPN_CARGO_FIJO;
		private DateTime _PAQPD_FECHA_CREA;
		private string _PAQPV_USUARIO_CREA;
		private string _PRDC_CODIGO;
		private string _PAQUETE_PLAN;

		public int PAQPN_CORRELATIVO
		{
			set{_PAQPN_CORRELATIVO = value;}
			get{ return _PAQPN_CORRELATIVO;}		
		}

		public int PAQPN_SECUENCIA
		{
			set{_PAQPN_SECUENCIA = value;}
			get{ return _PAQPN_SECUENCIA;}		
		}

		public string PAQTV_CODIGO
		{
			set{_PAQTV_CODIGO = value;}
			get{ return _PAQTV_CODIGO;}		
		}

		public string PLNV_CODIGO
		{
			set{_PLNV_CODIGO = value;}
			get{ return _PLNV_CODIGO;}		
		}

		public decimal PAQPN_CARGO_FIJO
		{
			set{_PAQPN_CARGO_FIJO = value;}
			get{ return _PAQPN_CARGO_FIJO;}		
		}

		public DateTime PAQPD_FECHA_CREA
		{
			set{_PAQPD_FECHA_CREA = value;}
			get{ return _PAQPD_FECHA_CREA;}		
		}
		public string PAQPV_USUARIO_CREA
		{
			set{_PAQPV_USUARIO_CREA = value;}
			get{ return _PAQPV_USUARIO_CREA;}		
		}

		public string PRDC_CODIGO
		{
			set{_PRDC_CODIGO = value;}
			get{ return _PRDC_CODIGO;}		
		}

		public string PAQUETE_PLAN
		{
			set{_PAQUETE_PLAN = value;}
			get{ return _PAQUETE_PLAN;}		
		}

	}
}
