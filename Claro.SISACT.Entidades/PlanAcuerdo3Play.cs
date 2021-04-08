using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for PlanAcuerdo3Play.
	/// </summary>
	public class PlanAcuerdo3Play
	{
		public PlanAcuerdo3Play()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string _PLNV_CODIGO;
		private string _PLZAC_CODIGO;
		private string _PACUC_ESTADO;
		private DateTime _PACUD_FECHA_CREA;
		private string _PACUV_USUARIO_CREA;
		private int _PACUN_CORRELATIVO;
		private string _PRDC_CODIGO;

		public string PLNV_CODIGO
		{
			set{_PLNV_CODIGO = value;}
			get{ return _PLNV_CODIGO;}		
		}

		public string PLZAC_CODIGO
		{
			set{_PLZAC_CODIGO = value;}
			get{ return _PLZAC_CODIGO;}		
		}

		public string PACUC_ESTADO
		{
			set{_PACUC_ESTADO = value;}
			get{ return _PACUC_ESTADO;}		
		}

		public DateTime PACUD_FECHA_CREA
		{
			set{_PACUD_FECHA_CREA = value;}
			get{ return _PACUD_FECHA_CREA;}		
		}

		public string PACUV_USUARIO_CREA
		{
			set{_PACUV_USUARIO_CREA = value;}
			get{ return _PACUV_USUARIO_CREA;}		
		}

		public int PACUN_CORRELATIVO
		{
			set{_PACUN_CORRELATIVO = value;}
			get{ return _PACUN_CORRELATIVO;}		
		}

		public string PRDC_CODIGO
		{
			set{_PRDC_CODIGO = value;}
			get{ return _PRDC_CODIGO;}		
		}

	}
}
