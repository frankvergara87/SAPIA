using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for AcuerdoItemDoc.
	/// </summary>
	public class DocumentoSEC
	{
		//---instancias de variables
		private System.Int64 _ID_DOCUMENTO_SEC;
		private System.Int64 _COD_SEC;
		private System.Int32 _ID_DOCUMENTO;
		private System.String _NOMBRE_GLOSA;
		private System.String _TIPO_CREACION;
		private System.DateTime _FECHA_CREACION;
		private System.String _USUARIO_CREACION;
		private System.String _NOMBRE_ARCHIVO;
		private System.Int64 _CODIGO_RECIBO; //18-06-2010

		
		//--propiedades
		public  System.Int64 ID_DOCUMENTO_SEC
		{ 
		   get { return _ID_DOCUMENTO_SEC; }
		   set  {_ID_DOCUMENTO_SEC = value; }
		}
		public  System.Int64 COD_SEC
		{ 
			get { return _COD_SEC; }
			set {_COD_SEC = value; }
		}

		public  System.Int32 ID_DOCUMENTO
		{
			get { return _ID_DOCUMENTO; }
			set {_ID_DOCUMENTO = value; }
		}

		public  System.String NOMBRE_GLOSA
		{
		   get { return _NOMBRE_GLOSA;}
		   set { _NOMBRE_GLOSA = value;}
		}
		
		public  System.String TIPO_CREACION
			{
		   get { return _TIPO_CREACION;}
		   set {_TIPO_CREACION = value;}
			}
			
		public  System.DateTime FECHA_CREACION
		{ 
		   get { return _FECHA_CREACION;}
		   set {_FECHA_CREACION = value;}
		}

		public  System.String USUARIO_CREACION
		{ 
		   get { return _USUARIO_CREACION;}
		   set {_USUARIO_CREACION = value;}
		}
		

		public  System.String NOMBRE_ARCHIVO
		{
			get { return _NOMBRE_ARCHIVO; }
			set { _NOMBRE_ARCHIVO = value; }
		}

		public  System.Int64 CODIGO_RECIBO
		{
			get { return _CODIGO_RECIBO; }
			set { _CODIGO_RECIBO = value; }
		}

		
		
			//---Constructores
		
		public DocumentoSEC()
		{

		}

		public DocumentoSEC(System.Int64 pID_DOCUMENTO_SEC, System.Int64 pCOD_SEC, System.Int32 pID_DOCUMENTO,
							 System.String pNOMBRE_GLOSA, 
							 System.String pTIPO_CREACION, System.DateTime pFECHA_CREACION, 
							 System.String pUSUARIO_CREACION, System.String pNOMBRE_ARCHIVO
							)
		{
			_ID_DOCUMENTO_SEC = pID_DOCUMENTO_SEC; 
			_COD_SEC = pCOD_SEC; 
			_ID_DOCUMENTO = pID_DOCUMENTO; 
			_NOMBRE_GLOSA = pNOMBRE_GLOSA; 
			_TIPO_CREACION = pTIPO_CREACION; 
			_FECHA_CREACION = pFECHA_CREACION; 
			_USUARIO_CREACION = pUSUARIO_CREACION; 
			_NOMBRE_ARCHIVO = pNOMBRE_ARCHIVO;
		}

		public DocumentoSEC(System.Int64 pID_DOCUMENTO_SEC, System.Int64 pCOD_SEC, System.Int32 pID_DOCUMENTO,
			System.String pNOMBRE_GLOSA, System.String pTIPO_CREACION, System.DateTime pFECHA_CREACION, 
			System.String pUSUARIO_CREACION, System.String pNOMBRE_ARCHIVO, System.Int64 pCodigoRecibo
			)
		{
			_ID_DOCUMENTO_SEC = pID_DOCUMENTO_SEC; 
			_COD_SEC = pCOD_SEC; 
			_ID_DOCUMENTO = pID_DOCUMENTO; 
			_NOMBRE_GLOSA = pNOMBRE_GLOSA; 
			_TIPO_CREACION = pTIPO_CREACION; 
			_FECHA_CREACION = pFECHA_CREACION; 
			_USUARIO_CREACION = pUSUARIO_CREACION; 
			_NOMBRE_ARCHIVO = pNOMBRE_ARCHIVO;
			_CODIGO_RECIBO = pCodigoRecibo;
		}
	}
}
