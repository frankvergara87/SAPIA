using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;
using Claro.SisAct.Negocios.ConsultarImeiBloqueadoWS;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for ConsultarImeiBloqueadoWS.
	/// </summary>
	public class BWConsultarImeiBloqueado
	{
		
		public int ConsultarImeiBloqueado(string CodRed, string nro_imei, ref int cod_respuesta, ref string msj_respuesta, ref string cod_desbloqueo)
		{
			int intValidarBloqueo;

	   		//INICIO|PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados
			
			try
			{
				ConsultarImeiBloqueadoWS.ConsultarImeiBloqueadoService oConsultarImeiBloqueadoWS = new ConsultarImeiBloqueadoWS.ConsultarImeiBloqueadoService();
				oConsultarImeiBloqueadoWS.Url = Funciones.CheckStr(ConfigurationSettings.AppSettings["ConstConsultaImeiBloqueado_Url"]);
				oConsultarImeiBloqueadoWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
				oConsultarImeiBloqueadoWS.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["ConstConsultaImeiBloqueado_TimeOut"]);
	
				// Datos de Auditoria
				ConsultarImeiBloqueadoWS.auditRequestType AuditRequest = new ConsultarImeiBloqueadoWS.auditRequestType();
				AuditRequest.idTransaccion = DateTime.Now.ToString("yyyyMMddHHss");
				AuditRequest.ipAplicacion = ConfigurationSettings.AppSettings["CodigoAplicacion"];
				AuditRequest.nombreAplicacion = ConfigurationSettings.AppSettings["constAplicacion"];
				AuditRequest.usuarioAplicacion = CodRed;

				// Request - WS
				ConsultarImeiBloqueadoWS.consultarImeiBloqueadoRequest ConsultarImeiBloqueadoRequest = new ConsultarImeiBloqueadoWS.consultarImeiBloqueadoRequest();
				ConsultarImeiBloqueadoRequest.auditRequest = AuditRequest;
				ConsultarImeiBloqueadoRequest.numeroImei = nro_imei;
				
				// Response - WS
				ConsultarImeiBloqueadoWS.consultarImeiBloqueadoResponse ConsultarImeiBloqueadoResponse = new ConsultarImeiBloqueadoWS.consultarImeiBloqueadoResponse();
				ConsultarImeiBloqueadoResponse = oConsultarImeiBloqueadoWS.consultarImeiBloqueado(ConsultarImeiBloqueadoRequest);
				intValidarBloqueo = 0;
				
				//Validación de Consulta
				if (ConsultarImeiBloqueadoResponse.auditResponse.codigoRespuesta.Equals(0))
				{					
					cod_desbloqueo = Funciones.CheckStr(ConsultarImeiBloqueadoResponse.codigoDesbloqueo);
					cod_respuesta = Funciones.CheckInt(ConsultarImeiBloqueadoResponse.auditResponse.codigoRespuesta);
					msj_respuesta = Funciones.CheckStr(ConsultarImeiBloqueadoResponse.auditResponse.mensajeRespuesta);
				}
				else
				{	
					cod_respuesta = Funciones.CheckInt(ConsultarImeiBloqueadoResponse.auditResponse.codigoRespuesta);
					msj_respuesta = Funciones.CheckStr(ConsultarImeiBloqueadoResponse.auditResponse.mensajeRespuesta);

					int intCodRespuesta= Funciones.CheckInt(ConsultarImeiBloqueadoResponse.auditResponse.codigoRespuesta);
					if (intCodRespuesta != 1)
					{
						intValidarBloqueo = 1;
					}
				}

			}
			catch(Exception ex)
			{
				intValidarBloqueo = 1;
				cod_respuesta = -99;
				cod_desbloqueo=String.Empty;
				msj_respuesta = "ConsultarImeiBloqueadoWS - ERROR -> " + ex.Message;
				//throw ex;
			}
			return intValidarBloqueo;
			//FIN|PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados
		}
		
	}
}
