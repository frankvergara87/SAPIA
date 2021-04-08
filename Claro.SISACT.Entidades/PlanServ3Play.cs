using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for PlanServ3Play.
	/// </summary>
	public class PlanServ3Play
	{
		public PlanServ3Play()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string _PLNV_CODIGO;
		private string _SERVV_CODIGO;
		private string _PSRVD_FECHA_CREA;
		private string _PSRVV_USUARIO_CREA;
		private string _PSRVN_CARGO_FIJO;
		private string _PSRVN_CORRELATIVO;
		private string _PSRVV_SELECCIONABLE;
		private string _PRDC_CODIGO;
		private string _PSRVC_FLG_DEFECTO;

		public string PLNV_CODIGO
		{
			set{_PLNV_CODIGO = value;}
			get{ return _PLNV_CODIGO;}		
		}

		public string SERVV_CODIGO
		{
			set{_SERVV_CODIGO = value;}
			get{ return _SERVV_CODIGO;}		
		}

		public string PSRVD_FECHA_CREA
		{
			set{_PSRVD_FECHA_CREA = value;}
			get{ return _PSRVD_FECHA_CREA;}		
		}

		public string PSRVV_USUARIO_CREA
		{
			set{_PSRVV_USUARIO_CREA = value;}
			get{ return _PSRVV_USUARIO_CREA;}		
		}

		public string PSRVN_CARGO_FIJO
		{
			set{_PSRVN_CARGO_FIJO = value;}
			get{ return _PSRVN_CARGO_FIJO;}		
		}


		public string PSRVN_CORRELATIVO
		{
			set{_PSRVN_CORRELATIVO = value;}
			get{ return _PSRVN_CORRELATIVO;}		
		}

		public string PSRVV_SELECCIONABLE
		{
			set{_PSRVV_SELECCIONABLE = value;}
			get{ return _PSRVV_SELECCIONABLE;}		
		}

		public string PRDC_CODIGO
		{
			set{_PRDC_CODIGO = value;}
			get{ return _PRDC_CODIGO;}		
		}

		public string PSRVC_FLG_DEFECTO
		{
			set{_PSRVC_FLG_DEFECTO = value;}
			get{ return _PSRVC_FLG_DEFECTO;}		
		}

	}
}
