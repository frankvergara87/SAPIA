using System;
using System.Configuration;
using System.IO;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using Claro.SisAct.Common; 
using System.Web;


namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for AcuerdoNegocios.
	/// </summary>
	public class AcuerdoNegocios
	{

		public AcuerdoNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public ArrayList ListarPorCodigoEvaluacionCodSEC(int codevaluacion,long codsec)
		{
			return new AcuerdoDatos().ListarPorCodigoEvaluacionCodSEC(codevaluacion,codsec);
		}

		public ArrayList ListarItemsDocSec (long pNroSolicitudSEC, string datFecha)
		{
			AcuerdoDatos objAcuerdoDatos = new AcuerdoDatos();
			return objAcuerdoDatos.ListarItemsDocSec(pNroSolicitudSEC,datFecha);
		}

		public bool Cerrar(Acuerdo pObjAcuerdoEnt)	
		{
			long iResultado; 
			AcuerdoDatos objAcuerdoD = new AcuerdoDatos();
			iResultado = objAcuerdoD.Cerrar(pObjAcuerdoEnt);	
			//--procesar resultado
			if (iResultado>0) 
			{
				/*no hacer nada, esta correcto*/
			}
			else if (iResultado==0) 
				throw new Exception("Acuerdo no existe.");
			else if (iResultado == -1)
				throw new Exception("Error grave al intentar Cerrar el Acuerdo");
			else if (iResultado == -2)
				throw new Exception("El Acuerdo ya se encuentra Cerrado.");
			else 
			{
			}

			//---retrona resultado
			return (iResultado>0);
		} /****CerrarAcuerdo****/


		#region "Métodos Generales"


		public bool ExisteSolicitud (long pNroSolicitudSEC)
		{
			long iExiste;
			AcuerdoDatos objAcuerdoData = new AcuerdoDatos();
			iExiste =objAcuerdoData.ExisteSolicitud(pNroSolicitudSEC);
			//---
			return (iExiste > 0);
		}


		public string ObtenerRUC_Asociado (long pCOD_SEC)
		{
			return new AcuerdoDatos().ObtenerRUC_Asociado(pCOD_SEC);
		}

		
		public int ValidarCreacionAcuerdo(long pCOD_SEC, int pIDDocumento)
		{
			int vCodigo=0;
			AcuerdoDatos objAcuerdoData = new AcuerdoDatos();
			//--
			int vIdDocAcuerdoB01 = Funciones.CheckInt(ConfigurationSettings.AppSettings["B01"]);  
			int vIdDocAcuerdoB03 = Funciones.CheckInt(ConfigurationSettings.AppSettings["B03"]);  
			//---
			if (objAcuerdoData.ExisteAcuerdo(pCOD_SEC, pIDDocumento))
				vCodigo = -1000; //Sólo puede crear un Acuerdo de este tipo para la SEC.
			else  //Se podría crear
			{
				if (vIdDocAcuerdoB01 == pIDDocumento)  
				{
					if (objAcuerdoData.ExisteAcuerdo(pCOD_SEC,vIdDocAcuerdoB03)) 
						vCodigo = -1004; //-- No se pude tener acuerdo B-01 y acuerdo B-03.
					else
						vCodigo = 4;
				}
				else if (vIdDocAcuerdoB03 == pIDDocumento)  
				{
					if (objAcuerdoData.ExisteAcuerdo(pCOD_SEC,vIdDocAcuerdoB01)) 
						vCodigo = -1004; //-- No se puede tener acuerdo B-01 y acuerdo B-03.
					else
						vCodigo = 5;
				}
				else
				{
					vCodigo = 1;
				}
			}
			
			objAcuerdoData = null;
			//---
			return vCodigo;
		}

		public virtual long ObtSolicitudDeDocumentoActivo(string pRUC, int pIdDocumento)
		{
			return new AcuerdoDatos().ObtSolicitudDeDocumentoActivo(pRUC,pIdDocumento);
		}

		
			/// <summary>
		/// Elimina un Acuerdo, sin el archivo generado
		/// </summary>
		/// <param name="pCodigoAcuerdo"></param>
		/// <returns></returns>
		public long Eliminar(long pCodigoAcuerdo)
		{
			long intResultado=-1;
	
				AcuerdoDatos objAcuerdoIngresoDatos = new AcuerdoDatos();
				intResultado = objAcuerdoIngresoDatos.Eliminar(pCodigoAcuerdo);

			return intResultado;
		}

		/// <summary>
		/// Eliminar el registro de Acuerdo y de sus items (documentos_sec)
		/// </summary>
		/// <param name="pNroSolicitud"></param>
		/// <param name="pIdDocumento"></param>
		/// <returns></returns>
		public long Eliminar(long pNroSolicitud, int pIdDocumento)
		{
			long intResultado=-1;
	
				//--recuperar nombre antes de eliminar
				string sArchivoOrigen;
				DocumentoSECNegocio objDocSECNegocio = new DocumentoSECNegocio();
				sArchivoOrigen =objDocSECNegocio.ObtenerNombreArchivoIngreso(pNroSolicitud,pIdDocumento);
				objDocSECNegocio = null;

				//---elimina de BD
				AcuerdoDatos objAcuerdoDatos = new AcuerdoDatos();
				intResultado = objAcuerdoDatos.Eliminar(pNroSolicitud, pIdDocumento);
				objAcuerdoDatos = null;
					
				if (intResultado>0) 
				{						
					//--elimina archivo			
					DocumentoSECNegocio objDocSEC = new DocumentoSECNegocio();
					objDocSEC.DeleteDocumento(sArchivoOrigen); 
					objDocSEC = null;
				}				
				//--solo prueba
				//throw new Exception (" detino: "+strArchivoDestino+" -- origen: "+ strArchivoOrigen);
				return intResultado;
					
		}

		/// <summary>
		/// Elimina varios items, acuerdos y documentos SEC, a través de la Capa de Datos
		/// </summary>
		/// <param name="pDocumentos">Documentos SEC a eliminar</param>		
		public void EliminarVarios(ArrayList pDocumentos,out long numEliminados, out long numNoEliminados, string pRutaRepositorio)
		{
			long iEliminados = 0;
			long noEliminados = 0;

			long UltCOD_SEC_Eliminado = -1;
			long UltID_DOCUMENTO_Eliminado = -1;
			//--
			foreach (DocumentoSEC ItemDoc in pDocumentos)
			{
				//string tipoCreacion = "";				
				DocumentoSECNegocio objDocSECNeg = new DocumentoSECNegocio();
				try
				{
					if (ItemDoc.TIPO_CREACION == ConfigurationSettings.AppSettings["TCREACION_INGRESO"].ToString())
					{
						iEliminados = iEliminados + Eliminar(ItemDoc.COD_SEC, ItemDoc.ID_DOCUMENTO) - 1;	/*Para no computar el del registro de Acuerdo, solo los Docuemntos SEC*/
						//--
						UltCOD_SEC_Eliminado = ItemDoc.COD_SEC;
						UltID_DOCUMENTO_Eliminado = ItemDoc.ID_DOCUMENTO;
					}
					else 
					{
						if	((UltCOD_SEC_Eliminado != ItemDoc.COD_SEC) && (UltID_DOCUMENTO_Eliminado != ItemDoc.ID_DOCUMENTO))
						{
							if (ItemDoc.TIPO_CREACION == ConfigurationSettings.AppSettings["TCREACION_DIGITALIZADO"].ToString()) 
							{
								objDocSECNeg.Eliminar(ItemDoc.ID_DOCUMENTO_SEC);  
								iEliminados = iEliminados + 1;
							}
						}
						else
						{
							//--ya fue eliminado a traves del item de Tipo de Creacion 'I', el cual ubica el acuerdo
						}
					}
				}
				catch //(Exception ex)
				{
					noEliminados +=1;
					//throw;
				}
				finally
				{
					objDocSECNeg = null;
				}
			} /*foreach*/
			
			numEliminados = iEliminados;
			numNoEliminados = noEliminados;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="pNroSolicitudSEC"></param>
		/// <param name="pIdDocumento"></param>
		/// <returns></returns>
		public virtual bool ExisteAcuerdo (int pNroSolicitudSEC, int pIdDocumento)
		{
			AcuerdoDatos objAcuerdoIngreso = new AcuerdoDatos();
			return objAcuerdoIngreso.ExisteAcuerdo(pNroSolicitudSEC,pIdDocumento);
		}


		/// <summary>
		/// Obtiene los datos de un acuerdo en base al numero de solicitud
		/// </summary>
		/// <param name="pNroSolicitudSEC"></param>
		/// <returns></returns>
		
		public long ObtenerCodigo_X_SEC_DOC(long pNroSolicitudSEC, int pIdDocumento)
		{
			AcuerdoDatos objAcuerdoDatos = new AcuerdoDatos();
			return objAcuerdoDatos.ObtenerCodigo_X_SEC_DOC(pNroSolicitudSEC, pIdDocumento);
			
		}


		/// <summary>
		/// Obtiene la Lista de los items de documentos de de una Solicitud, desde la capa de datos
		/// </summary>
		/// <param name="pNroSolicitudSEC">Nro de Solicitud</param>
		/// <returns></returns>
		public ArrayList ListarItemsDoc (long pNroSolicitudSEC)
		{
			return new AcuerdoDatos().ListarItemsDoc(pNroSolicitudSEC);
		}


		
#endregion

	}
}