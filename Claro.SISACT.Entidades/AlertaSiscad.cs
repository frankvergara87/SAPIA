using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de AlertaSiscad.
	/// </summary>
	public class AlertaSiscad
	{
		private string _COD_REGION; 
		private string _CODCADENA; 
		private string _NOMBREJEFE; 
		private string _MAILJEFE; 
		private string _NOMBSECTORISTA; 
		private string _MAILSECTORISTA; 
		private string _ID; 
		private string _CODPDV; 
		private string _FECREG; 
		
		public AlertaSiscad()
		{			
		}
		public string ID
		{
			set { _ID= value;}
			get { return _ID;}
		}
		public string COD_REGION
		{
			set { _COD_REGION= value;}
			get { return _COD_REGION;}
		}
		public string CODCADENA
		{
			set { _CODCADENA= value;}
			get { return _CODCADENA;}
		}
		public string NOMBREJEFE
		{
			set { _NOMBREJEFE= value;}
			get { return _NOMBREJEFE;}
		}
		public string MAILJEFE
		{
			set { _MAILJEFE= value;}
			get { return _MAILJEFE;}
		}
		public string NOMBSECTORISTA
		{
			set { _NOMBSECTORISTA= value;}
			get { return _NOMBSECTORISTA;}
		}
		public string MAILSECTORISTA
		{
			set { _MAILSECTORISTA= value;}
			get { return _MAILSECTORISTA;}
		}
		public string CODPDV
		{
			set { _CODPDV= value;}
			get { return _CODPDV;}
		}
		public string FECREG
		{
			set { _FECREG= value;}
			get { return _FECREG;}
		}
		
	}
}
