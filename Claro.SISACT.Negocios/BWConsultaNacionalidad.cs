using System;
using System.Text;
using Claro.SisAct.Entidades;
using System.Collections; 
using Claro.SisAct.Negocios.ConsultaNacionalidadWS;
using Microsoft.Web.Services2;
using Microsoft.Web.Services2.Security;
using Microsoft.Web.Services2.Security.Tokens;
using System.Configuration;
using System.Web;

namespace Claro.SisAct.Negocios
{
	public class BWConsultaNacionalidad 
	{
		ConsultaNacionalidadWS.DAT_ConsultaNacionalidad_v1 objTransaction = null;
		UsernameToken usernameToken = null;

		public BWConsultaNacionalidad()
		{
			objTransaction = new DAT_ConsultaNacionalidad_v1();
			objTransaction.Url =ConfigurationSettings.AppSettings["RutaWS_ConsultaNacionalidad"].ToString();
			objTransaction.Credentials = System.Net.CredentialCache.DefaultCredentials;
			objTransaction.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOut_ConsultaNacionalidad"].ToString());

		}

		public ArrayList ConsultarNacionalidad(string strUsuario,string strPassword,string CurrentUser, string CurrentTerminal, string wsIp,ref string msgRespuesta, ref string codRespuesta,ref string strNacionalidad)
		{
			ConsultaNacionalidadWS.consultarNacionalidadRequest consultarNacionalidadRequestWS = new ConsultaNacionalidadWS.consultarNacionalidadRequest();
			ArrayList lstArraNacionalidad = new ArrayList();
			BEItemGenerico objItem = null;
			StringBuilder lista = new StringBuilder();
			string lista2 = string.Empty;

			try
			{
				//wsse:Security
				usernameToken = new UsernameToken(strUsuario, strPassword, PasswordOption.SendPlainText);
				objTransaction.RequestSoapContext.Security.Tokens.Add(usernameToken);

				//Auditoria OSB
				objTransaction.headerRequest = new HeaderRequest();
				objTransaction.headerRequest.channel = string.Empty;
				objTransaction.headerRequest.idApplication = CurrentTerminal;
				objTransaction.headerRequest.userApplication = "USRSISACT";
				objTransaction.headerRequest.userSession = CurrentUser;
				objTransaction.headerRequest.idESBTransaction = string.Empty;
				objTransaction.headerRequest.idBusinessTransaction = string.Empty;
				objTransaction.headerRequest.startDate = Convert.ToDateTime(string.Format("{0:u}", DateTime.UtcNow));
				objTransaction.headerRequest.additionalNode = string.Empty;

				//DataPower
				objTransaction.HeaderRequest = new HeaderRequestType();
				objTransaction.HeaderRequest.country = ConfigurationSettings.AppSettings["DAT_ConsultaNacionalidad_country"].ToString();
				objTransaction.HeaderRequest.language = ConfigurationSettings.AppSettings["DAT_ConsultaNacionalidad_language"].ToString();
				objTransaction.HeaderRequest.consumer = ConfigurationSettings.AppSettings["DAT_ConsultaNacionalidad_consumer"].ToString();
				objTransaction.HeaderRequest.system = ConfigurationSettings.AppSettings["DAT_ConsultaNacionalidad_system"].ToString();
				objTransaction.HeaderRequest.modulo = ConfigurationSettings.AppSettings["DAT_ConsultaNacionalidad_modulo"].ToString();
				objTransaction.HeaderRequest.pid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
				objTransaction.HeaderRequest.userId = CurrentUser;
				objTransaction.HeaderRequest.dispositivo = CurrentTerminal;
				objTransaction.HeaderRequest.wsIp = wsIp;
				objTransaction.HeaderRequest.operation = ConfigurationSettings.AppSettings["DAT_ConsultaNacionalidad_operation"].ToString();
				objTransaction.HeaderRequest.timestamp = Convert.ToDateTime(string.Format("{0:u}", DateTime.UtcNow));
				objTransaction.HeaderRequest.msgType = ConfigurationSettings.AppSettings["DAT_ConsultaNacionalidad_msgType"].ToString();

				RequestOpcionalTypeRequestOpcional[] listaResquestOpcional = new RequestOpcionalTypeRequestOpcional[1];
				listaResquestOpcional[0]= new RequestOpcionalTypeRequestOpcional();
				listaResquestOpcional[0].campo = string.Empty;
				listaResquestOpcional[0].valor= string.Empty;

				consultarNacionalidadRequestWS.listaResquestOpcional = listaResquestOpcional;

				ConsultaNacionalidadWS.consultarNacionalidadResponse response = objTransaction.consultarNacionalidad(consultarNacionalidadRequestWS);

				codRespuesta = response.responseStatus.codigoRespuesta;
				msgRespuesta = response.responseStatus.descripcionRespuesta;

				foreach(ConsultaNacionalidadWS.Result obj in response.responseData.result)
				{
					objItem = new BEItemGenerico();
					objItem.Codigo = obj.codigo.ToString();
					objItem.Descripcion = obj.nacionalidad;
					lstArraNacionalidad.Add(objItem);
					
					lista.Append(obj.codigo.ToString());
					lista.Append(";");
					lista.Append(obj.nacionalidad.ToString());
					lista.Append("|");
					
				}

				strNacionalidad = lista.ToString();
				strNacionalidad = strNacionalidad.Substring(0, strNacionalidad.Length - 1);

				lstArraNacionalidad.Insert(0,new BEItemGenerico("-1","-- Seleccionar --"));


			}
			catch(Exception ex)
			{
				msgRespuesta = ex.Message;
				return null;
			}
			finally
			{
				objTransaction.Dispose();
			}

			return lstArraNacionalidad;		
		}
	}
}
