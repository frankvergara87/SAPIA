using System;
using System.Text;
using System.Configuration;
using System.Collections; 
using Claro.SisAct.Datos; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Negocios.GestionaProteccionMovilWS;



namespace Claro.SisAct.Negocios
{
	public class BWGestionaProteccionMovil
	{
		//PROY-24724-IDEA-28174 - CLASE NUEVA
		#region [Declaracion de Constantes - Config]
		GestionaProteccionMovilWSService oGestionaProteccionMovil = new GestionaProteccionMovilWSService();
		#endregion [Declaracion de Constantes - Config]


		public BWGestionaProteccionMovil()
		{
			oGestionaProteccionMovil.Url = ConfigurationSettings.AppSettings["consGestionaProteccionMovilWS_URL"].ToString();
			oGestionaProteccionMovil.Credentials = System.Net.CredentialCache.DefaultCredentials;
			oGestionaProteccionMovil.Timeout = Funciones.CheckInt(ConfigurationSettings.AppSettings["consGestionaProteccionMovilWS_TimeOut"].ToString());
		}

		string strCodRpta = "";
		string strMgsRpta = "";


		
		public BEItemMensaje GuardarProteccionMovil(string strNroSecPM ,string strTipoOperacion , string strCodPlan , string  strFechaEvaluacion, string strTipoCliente , string strTipoDoc ,
			string  strNroDoc, string strDescProducto , string  strCodMaterial, string  strNroCertificado,string  strMontoPrima, string  strIncTipoDano,
			string  strIncTipoRobo,string  strDeducibleDano,string  strDeducibleRobo, string strResultadoRpta,string strNomProdRpta,string strDescProductoRpta,string strFlagEstado,
			string strFechaModifica, string strUsuarioModifica, BEItemGenerico objAudit)
		{		
			BEItemMensaje objMensaje = new BEItemMensaje(false);
			objMensaje.exito = false;
			
				GestionaProteccionMovilWS.guardarPrimaRequest objRequest = new GestionaProteccionMovilWS.guardarPrimaRequest();
				GestionaProteccionMovilWS.guardarPrimaResponse objResponse = new GestionaProteccionMovilWS.guardarPrimaResponse();
				GestionaProteccionMovilWS.auditRequestType objAuditRequest = new GestionaProteccionMovilWS.auditRequestType();
 
				objAuditRequest.idTransaccion = objAudit.Codigo;
				objAuditRequest.nombreAplicacion = objAudit.Descripcion;
				objAuditRequest.ipAplicacion = objAudit.Descripcion2;
				objAuditRequest.usuarioAplicacion = objAudit.Codigo2;

				objRequest.auditRequest = objAuditRequest;
				objRequest.nroSec = strNroSecPM;
				objRequest.tipoOperacion = strTipoOperacion;
				objRequest.soplnCodigo = strCodPlan;
				objRequest.fechaEvaluacion = strFechaEvaluacion;
				objRequest.tipoClienteReq = strTipoCliente;
				objRequest.tipoDocReq = strTipoDoc;
				objRequest.nroDocReq = strNroDoc;
				objRequest.descProtReq = strDescProducto;
				objRequest.codMaterialReq = strCodMaterial;
				objRequest.nroCertifRpta = strNroCertificado;
				objRequest.montoPrimaRpta = strMontoPrima;
				objRequest.incidenciaTipoDanio = strIncTipoDano;
				objRequest.incidenciaTipoRobo = strIncTipoRobo;
				objRequest.deducibleDanio = strDeducibleDano;
				objRequest.deducibleRobo = strDeducibleRobo;
				objRequest.resultadoRpta = strResultadoRpta;
				objRequest.nombreProdRpta = strNomProdRpta;
				objRequest.descProdRpta = strDescProductoRpta;
				objRequest.flagEstado = strFlagEstado;
				objRequest.fechaModif = strFechaModifica;
				objRequest.usrMod = strUsuarioModifica;
			
				objResponse = oGestionaProteccionMovil.guardarPrima(objRequest);

				strCodRpta = objResponse.auditResponse.codigoRespuesta;
				strMgsRpta = objResponse.auditResponse.mensajeRespuesta;

				objMensaje.codigo = Funciones.CheckStr(strCodRpta) ;
				objMensaje.descripcion = Funciones.CheckStr(strMgsRpta) ;

				if (objMensaje.codigo == "0") 
					{objMensaje.exito = true;}
				else
				{	objMensaje.exito = false;
					objMensaje.codigo = strCodRpta; 
					objMensaje.mensajeSistema = Funciones.CheckStr(strMgsRpta);
				}
			return objMensaje;  			
		}


	}
}
