using System;

namespace Claro.SisAct.Entidades
{
	
	public class RestriccionRiesgo
	{
		public RestriccionRiesgo()
		{
			_TPROC_CODIGO="01";
		}


		private string _TVENC_CODIGO;
		public string TVENC_CODIGO
		{
			set{_TVENC_CODIGO = value;}
			get{ return _TVENC_CODIGO;}
		}


		private string _TPROC_CODIGO;
		public string TPROC_CODIGO
		{
			set{_TPROC_CODIGO = value;}
			get{ return _TPROC_CODIGO;}
		}


		private string _RIEN_CODIGO;
		public string RIEN_CODIGO
		{
			set{_RIEN_CODIGO = value;}
			get{ return _RIEN_CODIGO;}
		}


		private string _RTVRI_CODIGO;
		public string RTVRI_CODIGO
		{
			set{_RTVRI_CODIGO = value;}
			get{ return _RTVRI_CODIGO;}
		}

		

	}
}
