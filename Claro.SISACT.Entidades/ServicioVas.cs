using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de VasEntidad.
	/// </summary>
	public class ServicioVas
	{

		public ServicioVas()
		{
		}

		private string	_VSERC_CLIE_TIP_DOC;
		private string	_VSERV_CLIE_DOC;
		private string	_VSERV_CLIE_TELF;
		private Int64	_VSERN_COD_PAQ;
		private string	_VSERV_DIR_EMAIL;
		private Int64   _VSERN_COD_PROV;
		private Int64   _VSERN_COD_VAS;
		private string	_VSERV_USU_CREA;
		private Double	_VSERN_COS_SERV;
		private string	_VSERV_FRECUENCIA;
		private string	_VSERC_FLAG_ACT;
		private string	_VSERC_FLAG_TIPF;

		public string VSERC_CLIE_TIP_DOC
		{
			set{_VSERC_CLIE_TIP_DOC = value;}
			get{return _VSERC_CLIE_TIP_DOC;}
		}

		public string VSERV_CLIE_DOC
		{
			set{_VSERV_CLIE_DOC = value;}
			get{return _VSERV_CLIE_DOC;}
		}

		public string VSERV_CLIE_TELF
		{
			set{_VSERV_CLIE_TELF = value;}
			get{return _VSERV_CLIE_TELF;}
		}

		public Int64 VSERN_COD_PAQ
		{
			set{_VSERN_COD_PAQ = value;}
			get{return _VSERN_COD_PAQ;}
		}

		public string VSERV_DIR_EMAIL
		{
			set{_VSERV_DIR_EMAIL = value;}
			get{return _VSERV_DIR_EMAIL;}
		}

		public Int64 VSERN_COD_PROV
		{
			set{_VSERN_COD_PROV = value;}
			get{return _VSERN_COD_PROV;}
		}

		public Int64 VSERN_COD_VAS
		{
			set{_VSERN_COD_VAS = value;}
			get{return _VSERN_COD_VAS;}
		}

		public string VSERV_USU_CREA
		{
			set{_VSERV_USU_CREA = value;}
			get{return _VSERV_USU_CREA;}
		}

		public Double VSERN_COS_SERV
		{
			set{_VSERN_COS_SERV = value;}
			get{return _VSERN_COS_SERV;}
		}

		public string VSERV_FRECUENCIA
		{
			set{_VSERV_FRECUENCIA = value;}
			get{return _VSERV_FRECUENCIA;}
		}

		public string VSERC_FLAG_ACT
		{
			set{_VSERC_FLAG_ACT = value;}
			get{return _VSERC_FLAG_ACT;}
		}

		public string VSERC_FLAG_TIPF
		{
			set{_VSERC_FLAG_TIPF = value;}
			get{return _VSERC_FLAG_TIPF;}
		}
	}
}
