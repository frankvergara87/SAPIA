using System;
using System.Web.Services;
using System.Diagnostics;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.ComponentModel;
using Claro.SisAct.Negocios.EnvioCorreoWS;
using Claro.SisAct.Entidades;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for BWEnvioCorreo.
	/// </summary>

	//PROY-24724-IDEA-28174 - CLASE NUEVA
	public class BWEnvioCorreo
	{
		#region [Declaracion de Constantes - Config]
		envioCorreoWSService oenvioCorreoWSService = new envioCorreoWSService();
		#endregion [Declaracion de Constantes - Config]

		envioCorreoWSService _objTransaccion = new envioCorreoWSService();

		public BWEnvioCorreo()
		{
			_objTransaccion.Url = ConfigurationSettings.AppSettings["consEnvioCorreoWS_URL"].ToString();
			_objTransaccion.Credentials = System.Net.CredentialCache.DefaultCredentials;
			_objTransaccion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["consEnvioCorreoWS_TimeOut"].ToString());
		}

		public BEItemMensaje EnviarCorreo(string strRemitente, string strDestinatario, string strAsunto, string strMensaje, string strHtmlFlag, BEItemGenerico objAudit)
		{
			BEItemMensaje objMensaje = new BEItemMensaje(false);
			
			EnvioCorreoWS.AuditTypeResponse objResponse = new AuditTypeResponse();
			EnvioCorreoWS.AuditTypeRequest objRequest = new AuditTypeRequest();
			EnvioCorreoWS.ParametroOpcionalComplexType[] parametrosOpcionalesResponse = new EnvioCorreoWS.ParametroOpcionalComplexType[0];
			EnvioCorreoWS.ParametroOpcionalComplexType[] parametrosOpcionalesRequest = new EnvioCorreoWS.ParametroOpcionalComplexType[0];


			objRequest.idTransaccion = objAudit.Codigo;                
			objRequest.usrAplicacion = objAudit.Codigo2;
			objRequest.codigoAplicacion = objAudit.Codigo3;
			objRequest.ipAplicacion = objAudit.Descripcion2;

			objResponse = _objTransaccion.enviarCorreo(objRequest,
				strRemitente,
				strDestinatario,
				strAsunto,
				strMensaje,
				strHtmlFlag,
				parametrosOpcionalesRequest,
				out parametrosOpcionalesResponse);

			objMensaje.codigo = objResponse.codigoRespuesta.ToString();
			objMensaje.descripcion = objResponse.mensajeRespuesta.ToString();

			if (objMensaje.codigo == "0")
			{objMensaje.exito = true;}

			return objMensaje;
		}
	}

}