using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Auditoria LOGS.
	/// </summary>
	[Serializable]
	public class AuditoriaLogs
	{
		private int _AUDII_ITEM;
		private string _AUDIV_SECUENCIA;		
		private string _AUDIV_NROSEC;		
		private string _AUDIV_TIPODOCU;		
		private string _AUDIV_NRODOCU;
		private int _AUDII_LINEAACTIVA;
		private int _AUDII_BRMS;
		private int _AUDII_BLACKWHITE;
		private int _AUDII_POPUP;
		private string _AUDIV_NROEQUIPO;
		private int _AUDII_NROENVIOSMS;
		private int _AUDII_NROINTENTO;
		private int _AUDII_NROINDICADOR;
		private int _AUDII_DISPONIBLESMS;
		private string _AUDIV_COMENTARIO;
		private int _AUDII_PDV;
		private string _AUDIV_IPSERVICIO;
		private string _AUDIV_USUARIO_CREAC;
		private string _AUDIV_USUARIO_MODI;
		private int _AUDII_INTENTO_ANT;

		public AuditoriaLogs()
		{
			//
			// TODO: Add constructor logic here
			//
		}		

		public int AUDII_ITEM
		{
			set{_AUDII_ITEM= value;}
			get{ return _AUDII_ITEM;}
		}
		public string AUDIV_SECUENCIA
		{
			set{_AUDIV_SECUENCIA = value;}
			get{ return _AUDIV_SECUENCIA;}
		}
		public string AUDIV_NROSEC
		{
			set{_AUDIV_NROSEC= value;}
			get{ return _AUDIV_NROSEC;}
		}
		public string AUDIV_TIPODOCU
		{
			set{_AUDIV_TIPODOCU= value;}
			get{ return _AUDIV_TIPODOCU;}
		}
		public string AUDIV_NRODOCU
		{
			set{_AUDIV_NRODOCU= value;}
			get{ return _AUDIV_NRODOCU;}
		}

		public int AUDII_LINEAACTIVA
		{
			set{_AUDII_LINEAACTIVA= value;}
			get{ return _AUDII_LINEAACTIVA;}
		}
		public int AUDII_BRMS
		{
			set{_AUDII_BRMS= value;}
			get{ return _AUDII_BRMS;}
		}
		
		public int AUDII_BLACKWHITE
		{
			set{_AUDII_BLACKWHITE= value;}
			get{ return _AUDII_BLACKWHITE;}
		}
		public int AUDII_POPUP
		{
			set{_AUDII_POPUP= value;}
			get{ return _AUDII_POPUP;}
		}
		public string AUDIV_NROEQUIPO
		{
			set{_AUDIV_NROEQUIPO= value;}
			get{ return _AUDIV_NROEQUIPO;}
		}

		public int AUDII_NROENVIOSMS
		{
			set{_AUDII_NROENVIOSMS= value;}
			get{ return _AUDII_NROENVIOSMS;}
		}
		
		public int AUDII_NROINTENTO
		{
			set{_AUDII_NROINTENTO= value;}
			get{ return _AUDII_NROINTENTO;}
		}
		
		public int AUDII_NROINDICADOR
		{
			set{_AUDII_NROINDICADOR= value;}
			get{ return _AUDII_NROINDICADOR;}
		}
		public int AUDII_DISPONIBLESMS
		{
			set{_AUDII_DISPONIBLESMS= value;}
			get{ return _AUDII_DISPONIBLESMS;}
		}
		

		public string AUDIV_COMENTARIO
		{
			set{_AUDIV_COMENTARIO= value;}
			get{ return _AUDIV_COMENTARIO;}
		}
		public int AUDII_PDV
		{
			set{_AUDII_PDV= value;}
			get{ return _AUDII_PDV;}
		}
		
		public string AUDIV_IPSERVICIO
		{
			set{_AUDIV_IPSERVICIO= value;}
			get{ return _AUDIV_IPSERVICIO;}
		}
		public string AUDIV_USUARIO_CREAC
		{
			set{_AUDIV_USUARIO_CREAC= value;}
			get{ return _AUDIV_USUARIO_CREAC;}
		}
		public string AUDIV_USUARIO_MODI
		{
			set{_AUDIV_USUARIO_MODI= value;}
			get{ return _AUDIV_USUARIO_MODI;}
		}
		public int AUDII_INTENTO_ANT
		{
			set{_AUDII_INTENTO_ANT= value;}
			get{ return _AUDII_INTENTO_ANT;}
		}
	}
}
