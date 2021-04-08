using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de TipoDocumento (Digitalizacion de Documentos).
	/// </summary>
	public class TipoDocumentoE
	{
		public TipoDocumentoE()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public TipoDocumentoE(int pCodigo,string pNombre,int pOrden, int pTotalDocsAdjunta)
		{
			this._codigo =pCodigo;
			this._nombre=pNombre;
			this._orden= pOrden;
			this._Total_Docs_Adjunta = pTotalDocsAdjunta;
		}

		private int _codigo;
		private int _orden;
		private string _nombre;
		private int _Total_Docs_Adjunta;
		private Registro _registro;

		public int CODIGO
		{
			set{_codigo = value;}
			get{ return _codigo;}
		}
		public string NOMBRE
		{
			set{_nombre = value;}
			get{ return _nombre;}
		}

		public int ORDEN
		{
			set{_orden = value;}
			get{ return _orden;}
		}

		public int Total_Docs_Adjunta
		{
			set{_Total_Docs_Adjunta = value;}
			get{ return _Total_Docs_Adjunta;}
		}

		public Registro REGISTRO
		{
			set{_registro = value;}
			get
			{ 
				if(_registro==null)
				{
					_registro = new Registro();
				}
				return _registro;
			}
		}
	}
}
