using System;
using System.IO;
using Claro.SisAct.Datos;
using Claro.SisAct.Entidades; 
using System.Collections;
using System.Configuration; 

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for DocumentoSEC.
	/// </summary>
	public class DocumentoSECNegocio
	{
		public DocumentoSECNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Recupera el Nombre de archivo digitalizado de un Documento SEC desde la Capa de Datos
		/// </summary>
		/// <param name="pIDDOcumentoSEC"></param>
		/// <returns></returns>
		public string ObtenerNombreArchivo(long pIDDOcumentoSEC ) 
		{
			DocumentoSECDatos objDocumentoSEC = new DocumentoSECDatos();
			return objDocumentoSEC.ObtenerNombreArchivo(pIDDOcumentoSEC);

		}


		/// <summary>
		/// Obtien el nombre de archivo digitalziado respecto del documento de ingreso (el cual debe ser unico)
		/// desdel a Capa de Datos
		/// </summary>
		/// <param name="pNroSolicitud">Nro de SOlcituud</param>
		/// <param name="pIdDocumento"></param>
		/// <returns></returns>
		public string ObtenerNombreArchivoIngreso(long pNroSolicitud, int pIdDocumento ) 
		{
			DocumentoSECDatos objDocumentoSEC = new DocumentoSECDatos();
			return objDocumentoSEC.ObtenerNombreArchivoIngreso(pNroSolicitud,pIdDocumento);

		}


		public long Crear(DocumentoSEC  pObjDocumentoSECEnt)
		{
			long intResultado=-1;
		
				DocumentoSECDatos objDocumentoSECData = new DocumentoSECDatos();
				//--determina si ya existe o no
				bool existe=false ; 
				if (!existe) 
				{
					intResultado = objDocumentoSECData.Crear(pObjDocumentoSECEnt);
					
					//throw new Exception("Registrado");
				}
				else
					intResultado = -1000;  //---Acuerdo ya ha sido registrado 

			return intResultado;
			
		}


		/// <summary>
		/// Actualiza un documento SEC
		/// </summary>
		/// <param name="pObjDocumentoSEC"></param>
		/// <returns></returns>
		public long Actualizar(DocumentoSEC pObjDocumentoSEC)
		{
			long intResultado=-1;
		
				DocumentoSECDatos objDocumentoSECDatos = new DocumentoSECDatos();
				intResultado = objDocumentoSECDatos.Actualizar(pObjDocumentoSEC);
		
			return intResultado;
		}


		/// <summary>
		/// Elimina un registro de Documento SEC en base a su Identificador único
		/// </summary>
		/// <param name="pIdDocumentoSEC">Identificador único de Documento SEC</param>
		/// <returns></returns>
		public long Eliminar(long pIdDocumentoSEC)
		{
			long iResultado=-1;//error
		
				string sArchivoOrigen;
				DocumentoSECNegocio objDocSECNegocio = new DocumentoSECNegocio();
				sArchivoOrigen =objDocSECNegocio.ObtenerNombreArchivo(pIdDocumentoSEC);
				objDocSECNegocio = null;

				//--elimina registro de la BD
				DocumentoSECDatos objDocumentoSECDatos = new DocumentoSECDatos();
				iResultado = objDocumentoSECDatos.Eliminar(pIdDocumentoSEC);
				objDocumentoSECDatos = null;

				//--Recupera y estructura nombre de archivo a eliminar, luego elimina 
				if (iResultado>0)
				{
					DeleteDocumento(sArchivoOrigen);
				}
			return iResultado;
		}

		public long Eliminar(long pIdDocumentoSEC, bool pTambienFile)
		{
			long iResultado=-1;//error
		
				string sArchivoOrigen;
				DocumentoSECNegocio objDocSECNegocio = new DocumentoSECNegocio();
				sArchivoOrigen =objDocSECNegocio.ObtenerNombreArchivo(pIdDocumentoSEC);
				objDocSECNegocio = null;

				//--elimina registro de la BD
				DocumentoSECDatos objDocumentoSECDatos = new DocumentoSECDatos();
				iResultado = objDocumentoSECDatos.Eliminar(pIdDocumentoSEC);
				objDocumentoSECDatos = null;

				//--Recupera y estructura nombre de archivo a eliminar, luego elimina 
				if (iResultado>0 && pTambienFile)
				{
					DeleteDocumento(sArchivoOrigen);
				}
		
			return iResultado;
		}
		

#region "Solicitud"

		public bool EnviarACreditosActivaciones(int pCOD_SEC, string pCodEstadoNuevo, string pLoginUsuario)
		{
			DocumentoSECDatos objDocSECDatos = new DocumentoSECDatos();
			return objDocSECDatos.EnviarACreditosActivaciones(pCOD_SEC,pCodEstadoNuevo, pLoginUsuario);			
		}

#endregion


	    //T12646
		public int SubsanaDocumento(DocumentoSEC  pObjDocumentoSECEnt)
		{
			int intResultado=-1;
		
				DocumentoSECDatos objDocumentoSECData = new DocumentoSECDatos();
				//--determina si ya existe o no
				bool existe=false ; 
				if (!existe) 
				{
					intResultado = objDocumentoSECData.SubsanaDocumento(pObjDocumentoSECEnt);
					
				}
				else
					intResultado = -1000;  //---Acuerdo ya ha sido registrado 


			return intResultado;
	
		}

		/*** metodos de AP******/
		public ArrayList listaAnalistasCyA()
		{		
			DocumentoSECDatos obj = new DocumentoSECDatos();			
			return obj.listaAnalistasCyA();
		}

		public ArrayList listaAnalistasCyAPorArea(string codarea)
		{		
			DocumentoSECDatos obj = new DocumentoSECDatos();			
			return obj.listaAnalistasCyAPorArea(codarea);
		}

		/// <summary>
		/// Listar Analistas de Creditos y Activaciones por Area, desde la Capa de Datos
		/// </summary>
		/// <param name="pCodArea">Código de Área</param>
		/// <returns>Lista de Analistas</returns>
		public ArrayList listaAnalistasCyA_p_Rederivar(string pLoginUsuarioDerivador)
		{		
			return null;
		}

		public bool paraCorreccionPDV(int codsec)
		{		
			DocumentoSECDatos obj = new DocumentoSECDatos();			
			return obj.paraCorreccionPDV(codsec);
		}


		/// <summary>
		/// Elimina un archivo de una ruta compartida para acuerdos y checklist
		/// </summary>
		/// <param name="pNombreArchivo">Nombre del archivo a eliminar (sin ruta)</param>
		/// <returns></returns>
		public bool DeleteDocumento(string pNombreArchivo)
		{
			ControlFileTransfer objControlFileNeg;
			bool seRealizo = false;
			//--obtiene la ruta compartida para estructura el nombre completo
			string sRutaNombreCompleto =  ConfigurationSettings.AppSettings["ACU_CORP_RutaDestino"].ToString() + pNombreArchivo;
			//--elimina archivo
			try
			{
				objControlFileNeg = new ControlFileTransfer();
				seRealizo = objControlFileNeg.DeleteFile(sRutaNombreCompleto); 
			}
		
			finally
			{
				objControlFileNeg = null;
			}
			//--retorna resultado de operacion
			return seRealizo;			
		}
	}
}
