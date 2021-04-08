using System;
using System.Xml.Serialization;
using System.Collections;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;
using Claro.SisAct.Entidades;
using System.Configuration;
using Claro.SisAct.Negocios.ConsultaUDBWS;


namespace Claro.SisAct.Negocios
{
	public class ComandoHLRNegocios
	{

		public ComandoHLRNegocios()
		{
		}
		//Inicio Nuevo HLR - UDB - MVC
		public ArrayList HLR_Consulta(string strValor,ref string strMSGERROR, ref string strCodError,ref string strInfComando )
		{
			//Creacion de Arraylist
			ArrayList salida= new ArrayList();
			
			try
			{
				int i =0;
				int j =0;
				ConsultaHLR.HlrSiacWSService objServicioHLR = new ConsultaHLR.HlrSiacWSService();
				objServicioHLR.Url= ConfigurationSettings.AppSettings["strWebServiceConsultaHLR"];
				objServicioHLR.Credentials= System.Net.CredentialCache.DefaultCredentials;			

				ConsultaHLR.HLRRequestSIAC objRequestSIAC = new ConsultaHLR.HLRRequestSIAC();
				objRequestSIAC.msisdn   = strValor;
				ConsultaHLR.HLRResponseSIAC objhlrResponse = new ConsultaHLR.HLRResponseSIAC();
				objhlrResponse = objServicioHLR.hlrConsultasSIAC(objRequestSIAC);
				
				ConsultaHLR.HLRResponseSIACHLRResponseZMIO objZMIO = new ConsultaHLR.HLRResponseSIACHLRResponseZMIO();
				ConsultaHLR.HLRResponseSIACHLRResponseZMNO objZMNO = new ConsultaHLR.HLRResponseSIACHLRResponseZMNO();
				ConsultaHLR.HLRResponseSIACHLRResponseZMGO objZMGO = new ConsultaHLR.HLRResponseSIACHLRResponseZMGO();
				ConsultaHLR.HLRResponseSIACHLRResponseZMSO objZMSO = new ConsultaHLR.HLRResponseSIACHLRResponseZMSO();

				objZMIO = objhlrResponse.HLRResponseZMIO;
				objZMNO = objhlrResponse.HLRResponseZMNO;
				objZMGO = objhlrResponse.HLRResponseZMGO;
				objZMSO = objhlrResponse.HLRResponseZMSO;
				strMSGERROR = objhlrResponse.mensaje.ToString();
				strCodError = objhlrResponse.retorno.ToString();

				if (objZMIO.lineas.Length>0)
				{
					//recorre la lista de resultado que devuelve el WS				
					for(i=0;i<objZMIO.lineas.Length;i++)
					{									
						ItemGenerico LineaItem= new ItemGenerico();														
						LineaItem.Codigo =i.ToString();					
						LineaItem.Descripcion =objZMIO.lineas[i].linea;							
						salida.Add(LineaItem);
					}
				}
				if (objZMNO.lineas.Length>0)
				{
					//recorre la lista de resultado que devuelve el WS				
					for(i=0;i<objZMNO.lineas.Length;i++)
					{									
						ItemGenerico LineaItem= new ItemGenerico();														
						LineaItem.Codigo =i.ToString();					
						LineaItem.Descripcion =objZMNO.lineas[i].linea;							
						salida.Add(LineaItem);
					}
				}
				if (objZMGO.lineas.Length>0)
				{
					//recorre la lista de resultado que devuelve el WS				
					for(i=0;i<objZMGO.lineas.Length;i++)
					{									
						ItemGenerico LineaItem= new ItemGenerico();														
						LineaItem.Codigo =i.ToString();					
						LineaItem.Descripcion =objZMGO.lineas[i].linea;							
						salida.Add(LineaItem);
					}
				}
				if (objZMSO.lineas.Length>0)
				{
					//recorre la lista de resultado que devuelve el WS				
					for(i=0;i<objZMSO.lineas.Length;i++)
					{									
						ItemGenerico LineaItem= new ItemGenerico();														
						LineaItem.Codigo =i.ToString();					
						LineaItem.Descripcion =objZMSO.lineas[i].linea;							
						salida.Add(LineaItem);
					}
				}
			}
			catch(Exception ex)
			{
				
				if (strMSGERROR!="")
				{
					strMSGERROR = strMSGERROR + ". Error ComandoHLRNegocios:ComandoHLR(): " + ex.Message;
				}
				else 
				{
					strMSGERROR = "Error ComandoHLRNegocios:ComandoHLR(): " + ex.Message;
				}
				throw ex;
			}		
			
			return salida;
		}		
		
		public ItemGenerico UDB_Consulta(string strValor,ref string strMSGERROR, ref string strCodError)
		{
			string strkeyIMSI=string.Empty;
			string strkeyRC=string.Empty;
			string strIMSI=string.Empty;
			string strRC=string.Empty;
			string strUrl=string.Empty;
			string strAccion = string.Empty;
			string strApp = string.Empty;
			string strIpApp = string.Empty;
			string strUserSystem = string.Empty;
			string strTransaccion = string.Empty;
			string strParamEnvio = string.Empty;
			string strParamListaEnvio = string.Empty;
			
			bool blnIMSI=false;
			bool blnRC=false;
			bool blnAccion=false;
			DateTime fecha = DateTime.Now;


			ItemGenerico objItemGenerico= new ItemGenerico();

			strkeyIMSI = ConfigurationSettings.AppSettings["strWSKeyIMSI"];
			strkeyRC = ConfigurationSettings.AppSettings["strWSKeyRC"];
			strUrl=ConfigurationSettings.AppSettings["strWSConsultaUDB"];
			strAccion=ConfigurationSettings.AppSettings["strWSidAccionUDB"];
            strApp = ConfigurationSettings.AppSettings["constAplicacion"];
			strUserSystem= ConfigurationSettings.AppSettings["CONS_SERVV_USUARIO_SISTEMA"];
			strIpApp= ConfigurationSettings.AppSettings["strWebIpCod"];
			strParamEnvio=ConfigurationSettings.AppSettings["strWSParamEnvio"];
			strParamListaEnvio=ConfigurationSettings.AppSettings["strWSParamListaEnvio"];
			strTransaccion = strValor + fecha.ToString("ddMMyyyyHmm");
				
			try
			{
				//Configuración de Servicio                    
				UDBWSService objServicioUDB = new UDBWSService();
				objServicioUDB.Url = strUrl;
				objServicioUDB.Credentials= System.Net.CredentialCache.DefaultCredentials;             
                        
				//Request
				consultarRequest objconsultarRequest= new consultarRequest();

                parametrosAuditRequest objAuditRequest = new parametrosAuditRequest();
				objAuditRequest.idTransaccion=strTransaccion;
				objAuditRequest.ipAplicacion=strIpApp;
				objAuditRequest.nombreAplicacion = strApp;
				objAuditRequest.usuarioAplicacion=strUserSystem;

				objconsultarRequest.auditRequest = objAuditRequest;

				accionType objEntidad = new accionType();
				objEntidad.idAccion=strAccion;

				accionType objAccionRequest = new accionType();
				objAccionRequest = objEntidad;
                        
				objconsultarRequest.accionRequest = objAccionRequest;//Añadiendo idAccion -> accionRequest

				//listaParametrosParametro
				listaParametrosParametro objListaParametrosParametro = new listaParametrosParametro();
				objListaParametrosParametro.campo = strParamEnvio;
				objListaParametrosParametro.valor = strValor;

				listaParametrosParametro[] objArrListaParametrosParametro = new listaParametrosParametro[1];
				objArrListaParametrosParametro[0] = objListaParametrosParametro;

				listaParametros objListaParametros = new listaParametros();
				objListaParametros.nombreLista = strParamListaEnvio;
				objListaParametros.parametro = objArrListaParametrosParametro;

				listaParametros[] objArrListaParametros = new listaParametros[1];
				objArrListaParametros[0] = objListaParametros;

				objAccionRequest.listaParametros = objArrListaParametros;

				objconsultarRequest.accionRequest = objAccionRequest;
                      
				//Response
				ConsultaUDBWS.consultarResponse objResponseUDB = new ConsultaUDBWS.consultarResponse();
				objResponseUDB= objServicioUDB.consultar(objconsultarRequest);

				if(objResponseUDB.accionResponse.listaParametros != null ){
				for(int i=0;i<objResponseUDB.accionResponse.listaParametros.Length;i++)
				{
					if(objResponseUDB.accionResponse.listaParametros[i].nombreLista.Equals(strAccion))
					{
						blnAccion=true;
						for(int j=0; j<objResponseUDB.accionResponse.listaParametros[i].parametro.Length;j++)
						{
							if(objResponseUDB.accionResponse.listaParametros[i].parametro[j].campo.Equals(strkeyIMSI))
							{
								strIMSI = objResponseUDB.accionResponse.listaParametros[i].parametro[j].valor.ToString();
								blnIMSI=true;
							}
							else if (objResponseUDB.accionResponse.listaParametros[i].parametro[j].campo.Equals(strkeyRC))
							{
								strRC = objResponseUDB.accionResponse.listaParametros[i].parametro[j].valor.ToString();
								blnRC=true;
							}
							if(blnIMSI&&blnRC){break;}
						}
					}
					if(blnAccion){break;}
				}
				}
                  
				strMSGERROR = objResponseUDB.auditResponse.msjRespuesta.ToString();
				strCodError = objResponseUDB.auditResponse.codRespuesta.ToString();
                   
				
				objItemGenerico.Codigo = strIMSI;
				objItemGenerico.Codigo2 = strRC;
			}
			catch(Exception ex)
			{
				if (strMSGERROR!="")
				{
					strMSGERROR = strMSGERROR + ". Error ComandoHLRNegocios:ComandoUDB(): " + ex.Message;
				}
				else 
				{
					strMSGERROR = "Error ComandoHLRNegocios:ComandoUDB(): " + ex.Message;
				}
				throw ex;
			}           
                  
			return objItemGenerico;
		}
		//Inicio Nuevo HLR - UDB - MVC

	}
}
