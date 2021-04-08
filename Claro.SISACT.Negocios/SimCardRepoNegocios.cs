using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de SimCardRepoNegocios.
	/// </summary>
	public class SimCardRepoNegocios
	{
		SimCardsWS.ebsSimcards simCard = new Claro.SisAct.Negocios.SimCardsWS.ebsSimcards();
		string idAplicacion = Funciones.CheckStr(ConfigurationSettings.AppSettings["CodigoAplicacion"]);
		string nombreAplicacion = Funciones.CheckStr(ConfigurationSettings.AppSettings["constAplicacion"]);		
		string nameArchivo = "LOG_POSTVENTA_SANS" + "_" + string.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".txt";
	
		public SimCardRepoNegocios()
		{
			simCard.Url = Funciones.CheckStr(ConfigurationSettings.AppSettings["consRutaWS_Sans"]);
			simCard.Credentials = System.Net.CredentialCache.DefaultCredentials;
			simCard.Timeout = Funciones.CheckInt(ConfigurationSettings.AppSettings["consRutaWS_Sans_Timeout"]);
		}

		public bool ValidaDatosNroTelef(string nroTelef, string codMaterial, string iccid, string usuario, ref string ws_material, ref string ws_serie, ref string mensajeResultado)
		{
			bool blnOk = false;
			string codigoResultado = "";
			string idTransaccion = DateTime.Now.ToString("hhmmssfff");
			string ipAplicacion =  Funciones.CheckStr(ConfigurationSettings.AppSettings["CodigoAplicacion"]);
			string nombreAplicacion = Funciones.CheckStr(ConfigurationSettings.AppSettings["constAplicacion"]);
			string usuarioAplicacion = usuario;
			string ws_nroTelefono = string.Empty;
			//string ws_material = string.Empty;
			//string ws_serie = string.Empty;
			string ws_materialAntiguo = string.Empty; 
			try
			{
				SimCardsWS.itReturnType[] itReturn;
				SimCardsWS.nroSimcardsDataType[] nroSimcardsDataType;

				codigoResultado = simCard.obtenerDatosNroTelef(ref idTransaccion, ipAplicacion, nombreAplicacion, usuarioAplicacion,
					nroTelef, Funciones.CheckStr(codMaterial), Funciones.CheckStr(iccid), out mensajeResultado, out nroSimcardsDataType, out itReturn);

				int cantReg = nroSimcardsDataType.Length;
                
				HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);				
				HelperLog.EscribirLog("", nameArchivo, "Datos obtenidos del WS", false);
				HelperLog.EscribirLog("", nameArchivo, "- Cantidad de Registro: " + cantReg.ToString(), false);

				if (codigoResultado == "0"){
					blnOk = true;
				}

				if (cantReg > 0)
				{				
					ws_nroTelefono = nroSimcardsDataType[0].nroTelef;
					ws_material = nroSimcardsDataType[0].matNr;
					ws_serie = nroSimcardsDataType[0].serNr;
					ws_materialAntiguo = nroSimcardsDataType[0].matNrAntig;  

					HelperLog.EscribirLog("", nameArchivo, "- Nro telefono: " + ws_nroTelefono, false);
					HelperLog.EscribirLog("", nameArchivo, "- Material: " + ws_material, false);
					HelperLog.EscribirLog("", nameArchivo, "- Serie: " + ws_serie, false);
					HelperLog.EscribirLog("", nameArchivo, "- Material Antiguo: " + ws_materialAntiguo, false);	

				}
				else 
				{
					ws_serie = iccid;
					HelperLog.EscribirLog("", nameArchivo, "***** El WS no devuelve datos. Por lo cual no se consultará SAP.", false);
				}		

				if (itReturn != null)
				{
					foreach (SimCardsWS.itReturnType oRespuesta in itReturn)
					{
						
						if (oRespuesta.tipo == "E")
						{
							mensajeResultado = oRespuesta.mensaje;
						}
					}
				}
			}
			catch (Exception e)
			{
				codigoResultado = "-99";
				mensajeResultado = e.Message.ToString();
			}
			return blnOk;
		}
	}
}
