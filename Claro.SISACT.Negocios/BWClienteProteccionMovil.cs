using System;
using System.Text;
using System.Configuration;
using System.Collections; 
using Claro.SisAct.Datos; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Negocios.ClienteProteccionMovilWS;


namespace Claro.SisAct.Negocios
{
	
	//PROY-24724-IDEA-28174 - CLASE NUEVA

	public class BWClienteProteccionMovil
	{
		#region [Declaracion de Constantes - Config]
		ClienteProteccionMovilWSService oClienteProteccionMovil = new ClienteProteccionMovilWSService();
		#endregion [Declaracion de Constantes - Config]

		public BWClienteProteccionMovil()
		{
			oClienteProteccionMovil.Url =  ConfigurationSettings.AppSettings["consClienteProteccionMovilWS_URL"].ToString();
			//oClienteProteccionMovil.Credentials = System.Net.CredentialCache.DefaultCredentials;
			oClienteProteccionMovil.Timeout = Funciones.CheckInt(ConfigurationSettings.AppSettings["consClienteProteccionMovilWS_TimeOut"].ToString());

		}

		public BEItemMensaje ConsultarPrima(string strCodMaterial,string strTipoCliente,string strTipoDocumento,string strNroDocumento, 
			BEItemGenerico objAudit,ref string strCodRpta,ref string strMgsRpta,ref string strPrima, ref string strDeducible,ref  string strCertificado, ref string strNombProd, ref string strDescProd, ref string strIncTIpoDanio,ref string strIncTipoRobo)
		{			
			BEItemMensaje objMensaje = new BEItemMensaje(false);
			objMensaje.exito = false;

			ClienteProteccionMovilWS.consultarPrimaRequest objRequest = new ClienteProteccionMovilWS.consultarPrimaRequest();
			ClienteProteccionMovilWS.consultarPrimaResponse	 objResponse = new ClienteProteccionMovilWS.consultarPrimaResponse();
			ClienteProteccionMovilWS.AuditRequestType objAuditRequest = new ClienteProteccionMovilWS.AuditRequestType();
			ClienteProteccionMovilWS.IdentificationType objIdentificator = new ClienteProteccionMovilWS.IdentificationType();

			objAuditRequest.idTransaccion = objAudit.Codigo; 
			objAuditRequest.aplicacion = objAudit.Descripcion;
			objAuditRequest.ipAplicacion = objAudit.Descripcion2; 
			objAuditRequest.usrAplicacion = objAudit.Codigo2;
					
			objIdentificator.idType = strTipoDocumento;
			objIdentificator.idValue = strNroDocumento;
			objIdentificator.issuedCountryCode = "";

			objRequest.auditRequest = objAuditRequest;
			objRequest.identificationType=objIdentificator;
			objRequest.accountType = strTipoCliente;
			objRequest.clientAssetSKU=strCodMaterial;
			objRequest.clientProductSKU = ClsKeyAPP.strDesServProteccionMovil; 
			objRequest.region ="";

			objResponse = oClienteProteccionMovil.consultarPrima(objRequest);
			strCodRpta = objResponse.auditResponse.codigoRespuesta;
			strMgsRpta = objResponse.auditResponse.mensajeRespuesta;

			objMensaje.codigo = Funciones.CheckStr(strCodRpta) ;
			objMensaje.descripcion = Funciones.CheckStr(strMgsRpta) ;
			if (strCodRpta == "0")
			{
				objMensaje.exito = true;
				strPrima = Convert.ToString(objResponse.products[0].premium);
		
				string deducibleDanioFalla = (Funciones.CheckStr(objResponse.products[0].deductible)).Trim(); 
				string deducibleRobo = (Funciones.CheckStr(objResponse.products[1].deductible)).Trim();		

				string[] arrdeducibleDanioFalla=null;

				deducibleDanioFalla = deducibleDanioFalla.Replace("n","ñ");	
				
				arrdeducibleDanioFalla=deducibleDanioFalla.Split(" ".ToCharArray()); 
				deducibleDanioFalla=arrdeducibleDanioFalla[0]+ " " + arrdeducibleDanioFalla[arrdeducibleDanioFalla.Length - 1];

				strDeducible =  deducibleRobo + " - " + deducibleDanioFalla;
				strCertificado = objResponse.quoteID;
				strNombProd=objResponse.products[0].productName;
				strDescProd=objResponse.products[0].productDescription;
				strIncTIpoDanio=objResponse.products[0].incidentType;
				strIncTipoRobo=objResponse.products[1].incidentType;
			}
			else
			{
				objMensaje.exito = false;
				objMensaje.codigo = strCodRpta; 
				objMensaje.mensajeSistema = Funciones.CheckStr(strMgsRpta);
			}
			return objMensaje;	
		}


	}
}



