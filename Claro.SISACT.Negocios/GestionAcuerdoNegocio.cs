using System;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Configuration;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for GestionAcuerdoNegocios.
	/// </summary>
	public class GestionAcuerdoNegocios
	{
		int numVecesConsultaWS=0;

		public GestionAcuerdoNegocios()
		{
			
		}
		public HttpWebRequest CreateWebRequest()
		{
			HelperLog.EscribirLog("", "LogGestionAcuerdoWS.txt","---Inicio CreateWebRequest ---", false);
			string urlHP = ConfigurationSettings.AppSettings["RutaWS_GestionAcuerdo"];                       
			string Headers = ConfigurationSettings.AppSettings["WS_Headers"];
			string ContentType = ConfigurationSettings.AppSettings["WS_ContentType"];
			string Accept = ConfigurationSettings.AppSettings["WS_Accept"];
			string Method = ConfigurationSettings.AppSettings["WS_Method"];
                        
			HelperLog.EscribirLog("", "LogGestionAcuerdoWS.txt",DateTime.Now.ToString("ddMMyyyyHHmmss")+"--->"+"CreateWebRequest --> URLWS:"+urlHP, false);
                        
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@urlHP);

			webRequest.Headers.Add(@Headers);
			webRequest.ContentType = ContentType;
			webRequest.Accept = Accept;
			webRequest.Method = Method;
			return webRequest;
		}
		public BEGestionAcuerdoWS ObtenerGestionAcuerdoWS(string usuarioaplicacion,string msisdn,string coid,ref string codWS, ref string MensajeWS)
		{			
			HelperLog.EscribirLog("", "LogGestionAcuerdoWS.txt",DateTime.Now.ToString("ddMMyyyyHHmmss")+"--->"+"Metodo: ObtenerGestionAcuerdoWS: -->INPUT -->  Usuario:"+usuarioaplicacion+", msisdn:"+ msisdn+", coid:"+coid, false);
                  

			ArrayList lista = new ArrayList();
			BEGestionAcuerdoWS item= new BEGestionAcuerdoWS();   
			try
			{
				string idTransaccion=DateTime.Now.ToString("yyyyMMddHHmmss");
				string ipAplicacion=ConfigurationSettings.AppSettings["CodigoAplicacion"];
				string nombreAplicacion=ConfigurationSettings.AppSettings["constAplicacion"];;
				string usuarioAplicacion=usuarioaplicacion;
				string fechaTransaccion = DateTime.Now.ToString("dd/MM/yyyy");
				string cargoFijoNuevo = ConfigurationSettings.AppSettings["WSGesAcuerdo_RenoAntiCargoFijo"];                  
				string motivoApadece = ConfigurationSettings.AppSettings["WSGesAcuerdo_RenoAntiMotivo"];
				string flagEquipo = ConfigurationSettings.AppSettings["WSGesAcuerdo_RenoAntiFlagEquipo"];
                        
				HttpWebRequest request = CreateWebRequest();
				request.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["WSGesAcuerdo_Timeout"].ToString());
				XmlDocument soapEnvelopeXml = new XmlDocument();                       
                        
				soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:typ=""http://claro.com.pe/eai/ws/postventa/gestionacuerdo/types"" xmlns:bas=""http://claro.com.pe/eai/ws/baseschema"">"+
					"<soapenv:Header/>"+
					"<soapenv:Body>"+
					"<typ:obtenerReintegroEquipoRequest>"+
					"<typ:auditRequest>"+
					"<bas:idTransaccion>"+idTransaccion+"</bas:idTransaccion>"+
					"<bas:ipAplicacion>"+ipAplicacion+"</bas:ipAplicacion>"+
					"<bas:nombreAplicacion>"+nombreAplicacion+"</bas:nombreAplicacion>"+
					"<bas:usuarioAplicacion>"+usuarioaplicacion+"</bas:usuarioAplicacion>"+
					"</typ:auditRequest>"+
					"<typ:msisdn>"+msisdn+"</typ:msisdn>"+
					"<typ:coId>"+coid+"</typ:coId>"+
					"<typ:fechaTransaccion>"+fechaTransaccion+"</typ:fechaTransaccion>"+
					"<typ:cargoFijoNuevo>"+cargoFijoNuevo+"</typ:cargoFijoNuevo>"+
					"<typ:motivoApadece>"+motivoApadece+"</typ:motivoApadece>"+
					"<typ:flagEquipo>"+flagEquipo+"</typ:flagEquipo>"+
					"<typ:listaRequestOpcional>"+            					
					"</typ:listaRequestOpcional>"+
					"</typ:obtenerReintegroEquipoRequest>"+
					"</soapenv:Body>"+
					"</soapenv:Envelope>");

				using (Stream stream = request.GetRequestStream())
				{
					soapEnvelopeXml.Save(stream);
				}

				using (WebResponse response = request.GetResponse())
				{
					using (StreamReader rd = new StreamReader(response.GetResponseStream()))
					{
						string soapResult = rd.ReadToEnd();
						Console.WriteLine(soapResult);

						XmlDocument xmlCod = new XmlDocument();
						xmlCod.LoadXml(soapResult);
						XmlNamespaceManager manager = new XmlNamespaceManager(xmlCod.NameTable);
						manager.AddNamespace(ConfigurationSettings.AppSettings["GestionAcuerdoWS_ns0"], ConfigurationSettings.AppSettings["GestionAcuerdoWS_servicio"]);
						XmlNodeList lstGestionAcuerdoWS = xmlCod.SelectNodes(ConfigurationSettings.AppSettings["GestionAcuerdoWS_response"],manager);
						string cadenaXML=xmlCod.InnerXml;                                                                      
						HelperLog.EscribirLog("", "LogGestionAcuerdoWS.txt"," ObtenerGestionAcuerdoWS--> NumRegcodigoDocumentos:"+lstGestionAcuerdoWS.Count, false);

						if (lstGestionAcuerdoWS.Count > 0)
						{
							foreach (XmlNode xn in lstGestionAcuerdoWS)
							{
								//Auditoria
								codWS=xn["auditResponse"]["ns0:codigoRespuesta"].InnerText;
								MensajeWS=xn["auditResponse"]["ns0:mensajeRespuesta"].InnerText;
								
								//obtenerReintegroEquipoResponse
								if(codWS=="0")
								{     
									item.acuerdoOrigen = xn["acuerdoOrigen"].InnerText;
									item.acuerdoId = xn["acuerdoId"].InnerText;
									item.coId = xn["coId"].InnerText;
									item.customerId = xn["customerId"].InnerText;
									item.acuerdoEstado = xn["acuerdoEstado"].InnerText;
									item.acuerdoMontoApacedeTotal =Funciones.CheckDbl(xn["acuerdoMontoApacedeTotal"].InnerText);
									item.acuerdoVigenciaMeses = xn["acuerdoVigenciaMeses"].InnerText;
									item.acuerdoFechaInicio = xn["acuerdoFechaInicio"].InnerText;
									item.acuerdoFechaFin = xn["acuerdoFechaFin"].InnerText;
									item.mesesAntiguedad = Funciones.CheckInt64(xn["mesesAntiguedad"].InnerText);
									item.mesesPendientes = Funciones.CheckInt64(xn["mesesPendientes"].InnerText);
									item.diasPendientes = Funciones.CheckInt64(xn["diasPendientes"].InnerText);
									item.codPlazoAcuerdo = xn["codPlazoAcuerdo"].InnerText;
									item.descPlazoAcuerdo = xn["descPlazoAcuerdo"].InnerText;
									item.acuerdoCaducado = xn["acuerdoCaducado"].InnerText;
									item.diasVigentes=Funciones.CheckInt64(xn["diasVigencia"].InnerText);
									item.montoApadece=xn["montoApadece"].InnerText;
									item.cargoFijoDiario=xn["cargoFijoDiario"].InnerText;
									item.precioVenta=xn["precioLista"].InnerText;
									item.precioVenta=xn["precioVenta"].InnerText;
									item.diasBloqueadoSusp=xn["diasBloqueo"].InnerText;
									item.finVigenciaReal=xn["finVigenciaReal"].InnerText;
									item.CadenaXml=cadenaXML;
                                                     
									HelperLog.EscribirLog("", "LogGestionAcuerdoWS.txt",DateTime.Now.ToString("ddMMyyyyHHmmss")+"--->"+"OUTPUT_WS: AcuerdoOrigen:"+item.acuerdoOrigen+", AcuerdoId:"+ item.acuerdoId+", CoId :"+item.coId+", customerId:"+item.customerId+",AcuerdoEstado:"+item.acuerdoEstado+
										",AcuerdoMontoApacedeTotal:"+item.acuerdoMontoApacedeTotal+", AcuerdoVigenciaMeses:"+item.acuerdoVigenciaMeses+",AcuerdoFechaInicio:"+item.acuerdoFechaInicio+", AcuerdoFechaFin:"+item.acuerdoFechaFin+
										", MesesAntiguedad:"+item.mesesAntiguedad+", MesesPendientes:"+item.mesesPendientes+", DiasPendientes:"+item.diasPendientes+", CodPlazoAcuerdo:"+item.codPlazoAcuerdo+", DescPlazoAcuerdo:"+item.descPlazoAcuerdo+
										", AcuerdoCaducado:"+item.acuerdoCaducado+", numVecesConsultaWS: "+ numVecesConsultaWS +",  msisdn: " + msisdn.ToString(), false);
									numVecesConsultaWS++;
								}
								else
								{
									item=null;
									numVecesConsultaWS++;
									HelperLog.EscribirLog("", "LogGestionAcuerdoWS.txt",DateTime.Now.ToString("ddMMyyyyHHmmss")+"--->"+" OUTPUT_WS --> CodWS:"+codWS+", MsgWS:"+MensajeWS+", NumeroVecesConsultadasWS:" + numVecesConsultaWS, false);
								}
							}
						}
					}
				}
			}
			catch(Exception ex)
			{	
				codWS = "-2";
				MensajeWS = ex.Message;
				HelperLog.EscribirLog("", "LogGestionAcuerdoWS.txt",DateTime.Now.ToString("ddMMyyyyHHmmss")+"--->"+" OUTPUT_WS: MsgWS:"+MensajeWS+",MsgERROR_Catch:"+ex.Message+",MsgERROR_Catch_StackTrace:"+ex.StackTrace, false);
			}
			return item; 
		}
	}
}

