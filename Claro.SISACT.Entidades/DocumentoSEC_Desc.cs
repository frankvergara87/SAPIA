using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for DocumentoSEC_Des
	/// </summary>
	public class DocumentoSEC_Desc : DocumentoSEC
	{
		private string  _DESC_TIPO_DOCUMENTO;
		private string  _DESC_DOCUMENTO;
		private string  _COD_ESTADO;
		private string  _DESC_ESTADO;
		private string  _DESC_TIPO_CREACION;
		
		//--propiedades


		public  string DESC_TIPO_DOCUMENTO
		{ 
			get { return _DESC_TIPO_DOCUMENTO; }
			set { _DESC_TIPO_DOCUMENTO = value; }
		}

		public  string DESC_DOCUMENTO
		{ 
			get { return _DESC_DOCUMENTO; }
			set { _DESC_DOCUMENTO = value; }
		}		
		
		public string  COD_ESTADO
		{ 
			get { return _COD_ESTADO; }
			set { _COD_ESTADO = value; }
		}
		
		public string  DESC_ESTADO
		{ 
			get { return _DESC_ESTADO; }
		set { _DESC_ESTADO = value; }
		}

		public  string DESC_TIPO_CREACION
		{ 
			get { return _DESC_TIPO_CREACION; }
			set { _DESC_TIPO_CREACION = value; }
		}		
		

		public DocumentoSEC_Desc()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
