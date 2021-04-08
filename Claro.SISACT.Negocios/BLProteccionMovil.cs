using System;
using System.Text;
using System.Configuration;
using System.Data;
using Claro.SisAct.Datos;
using System.Collections; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;



namespace Claro.SisAct.Negocios
{
	//PROY-24724-IDEA-28174 - CLASE NUEVA
	public class BLProteccionMovil
	{
		public void BorrarServicioProteccionMovil(string strNroSec, string strCodServProteccionMovil, string strCodSolPlan,ref string strCodRespuesta, ref string strMsjRespuesta)
		{
			DAProteccionMovil oDAProteccionMovil = new DAProteccionMovil();
			oDAProteccionMovil.BorrarServicioProteccionMovil(strNroSec, strCodServProteccionMovil,strCodSolPlan, ref strCodRespuesta, ref strMsjRespuesta);
		}  
   
	
		public BEItemMensaje EnviarCorreoContingencia(string strMetodo, string strCodError, string strMensajeError, BEItemGenerico objAudit,string strFlagCorreo)
		{
			BWEnvioCorreo objEnvioCorreo = new BWEnvioCorreo();
			BEItemMensaje objMensaje = new BEItemMensaje(false);

			string strRemitente = string.Empty;
			string strDestinatario = string.Empty;
			string strMensaje = string.Empty;
			string strHtmlFlag =  ClsKeyAPP.strEnvioCorreoHtmlFlag; 
			string strRespuesta = string.Empty;
			string strUrl=string.Empty ;
			string strTransacción=string.Empty ;
			//////PROY-24724-IDEA-28174 - PARAMETROS INI
			string[] arrDatosMensaje = new string[6];
			string[] arrAsunto = new string[1];
			string strAsunto =ClsKeyAPP.strAsuntoProtMovil;

			strRemitente = ClsKeyAPP.strRemitenteProtMovil;
			strDestinatario = ClsKeyAPP.strDestinatarioProtMovil;
			strMensaje = ClsKeyAPP.strMensajeProtMovil;

			if(strFlagCorreo=="GP")
			{
				arrAsunto[0] = "GESTIONAPROTECCIONMOVIL";		
				strUrl=ConfigurationSettings.AppSettings["consGestionaProteccionMovilWS_URL"];				
			}
			else if(strFlagCorreo=="CP")
			{
				arrAsunto[0] = "CLIENTEPROTECCIONMOVIL";
				strUrl=ConfigurationSettings.AppSettings["consClienteProteccionMovilWS_URL"];				
			}


			strAsunto = String.Format(strAsunto, arrAsunto);
			
			arrDatosMensaje[0] = strMetodo; //METODO
			arrDatosMensaje[1] = " URL: " + strUrl;
			arrDatosMensaje[2] = strCodError;	//CODIGO DE ERROR
			arrDatosMensaje[3] = Funciones.CheckStr(strMensajeError); //MESAJE DE ERROR
			arrDatosMensaje[4] = objAudit.Codigo;	//TRANSACCION
			arrDatosMensaje[5] = arrAsunto[0];		//Nombre Serv
			strMensaje = String.Format(strMensaje, arrDatosMensaje);
			strMensaje = strMensaje.Replace("=", "<br>");
			//PROY-24724-IDEA-28174 - PARAMETROS FIN
 
			try 
			{
				objMensaje = objEnvioCorreo.EnviarCorreo(strRemitente, strDestinatario, strAsunto, strMensaje, strHtmlFlag, objAudit);
			}

			catch (Exception ex)
			{
				objMensaje.exito = false;
				objMensaje.descripcion = ex.Message;
			}

			return objMensaje;
		}

		public void EliminarProteccionMovil(string strNroSec, string strNroCertificado,ref string strCodRespuesta, ref string strMsjRespuesta)
		{
			DAProteccionMovil oDAProteccionMovil = new DAProteccionMovil();
			oDAProteccionMovil.EliminarProteccionMovil(strNroSec, strNroCertificado, ref strCodRespuesta, ref strMsjRespuesta);
		} 
 


	}
}