using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for TipoRiesgoNegocio.
	/// </summary>
	public class BOValidarClienteClaro
	{
	//ListaPrecios.BonoRenovacionReposicionWS _oTransaccion = new BonoPrepagoWS.BonoRenovacionReposicionWS();

		public BOValidarClienteClaro()
		{
			
		}
		
		public int ValidarCliente(string strTipDoc, string strDocumento, int intNroSEC, string strTipoOpera,string strFecha,string strUsuario, ref int p_intLogs)
		{
			int _intValidar = 0;
			int _intValidarBRMS = 0;
			int _intValidarWhite = 0;
			int _intValidarBlack = 0;
			AuditoriaLogs p_Auditoria = new AuditoriaLogs();

			ArrayList arrLineasActivas = new ArrayList();
			arrLineasActivas = ListarLineasActivas(0, strDocumento);

			p_Auditoria.AUDIV_COMENTARIO = "ValidacionClienteClaro";
			p_Auditoria.AUDIV_IPSERVICIO = System.Net.Dns.GetHostName();
			p_Auditoria.AUDIV_NROSEC = Convert.ToString(intNroSEC);
			p_Auditoria.AUDIV_TIPODOCU = strTipDoc;
			p_Auditoria.AUDIV_NRODOCU = strDocumento;
			p_Auditoria.AUDIV_USUARIO_CREAC = strUsuario;

			if (arrLineasActivas.Count<=0)
			{
				arrLineasActivas = ListarLineasActivas( Funciones.CheckInt( strTipDoc), strDocumento);
			}
			if (arrLineasActivas.Count<=0 )
			{
				p_Auditoria.AUDII_LINEAACTIVA = _intValidar;
				p_Auditoria.AUDII_POPUP = 0;
				GuardarAuditoriaLog(ref p_Auditoria);
				p_intLogs = p_Auditoria.AUDII_ITEM;
				return _intValidar;
			}

			foreach (Claro.SisAct.Entidades.ItemGenerico ArrListActivas  in arrLineasActivas)
			{
				if (ArrListActivas.Codigo == "")
				{
					p_Auditoria.AUDII_LINEAACTIVA = _intValidar;
					p_Auditoria.AUDII_POPUP = 0;
					GuardarAuditoriaLog(ref p_Auditoria);
					p_intLogs = p_Auditoria.AUDII_ITEM;
					return _intValidar;
				}
			}

			p_Auditoria.AUDII_LINEAACTIVA = 1;

			string strValidarBRMS;
			strValidarBRMS = ValidarBRMS(intNroSEC);
			if (strValidarBRMS == "" )
				strValidarBRMS ="1";

			
			if (Funciones.IsNumeric(strValidarBRMS)){
				_intValidarBRMS = Funciones.CheckInt(strValidarBRMS);
			}else{
				_intValidarBRMS =1;
			}
			
			p_Auditoria.AUDII_BRMS = _intValidarBRMS;
			p_Auditoria.AUDII_BLACKWHITE =0;
			
			//Ingresar Codigo Validar WHITE LIST
			_intValidarWhite = ValidarWhiteBlackList(strTipDoc, strDocumento, "", strFecha, "01");
			if (_intValidarWhite == 1) 
			{
				p_Auditoria.AUDII_BLACKWHITE = 1;
				p_Auditoria.AUDII_POPUP = 0;
				GuardarAuditoriaLog(ref p_Auditoria);
				p_intLogs = p_Auditoria.AUDII_ITEM;
				
				_intValidar = 0;

				return _intValidar;
			}

			//Ingresar Codigo Validar BLACK LIST.
			_intValidarBlack = ValidarWhiteBlackList(strTipDoc, strDocumento, strTipoOpera, strFecha, "02");
			if (_intValidarBlack == 1)
			{
				_intValidar = 2;
				p_Auditoria.AUDII_BLACKWHITE = 2;
				p_Auditoria.AUDII_POPUP = 1;
				GuardarAuditoriaLog(ref p_Auditoria);
				p_intLogs = p_Auditoria.AUDII_ITEM;
				return _intValidar;
			}

			_intValidar = _intValidarBRMS;

			//Guardar LOGS
			if (_intValidar > 0){
				p_Auditoria.AUDII_POPUP = 1;
			}
			//p_intLogs =2;
			GuardarAuditoriaLog(ref p_Auditoria);
			p_intLogs = p_Auditoria.AUDII_ITEM;

			return _intValidar;
		}

		public ArrayList ListarLineasActivas(int intTipDoc, string strDocumento)
		{
			ArrayList _ArrLista = null;
		
				ValidarClienteClaro _obj = new ValidarClienteClaro();
				_ArrLista  = _obj.Listar_LineasActivas(intTipDoc, strDocumento);
		
				return _ArrLista;
			}
		public int ValidarWhiteBlackList(string strTipDoc, string strDocumento, string strTipoOper, string strFecha, string strTipoLista)
		{
			ValidarClienteClaro _obj = new ValidarClienteClaro();
            return  _obj.Validar_BlackWhiteList(strTipDoc, strDocumento,strTipoOper, strFecha, strTipoLista);
		}
		
		public string Capturar_ValorParametros(string strValor)
		{
			ValidarClienteClaro _obj = new ValidarClienteClaro();
			return _obj.Capturar_ValorParametros(strValor);

		}
		public bool GuardarCodigoSMS(string strNroTelefonico, string strClaveSMS, DateTime dttFecha)
		{
			ValidarClienteClaro _obj = new ValidarClienteClaro();
			return _obj.Guardar_CodigoSMS (strNroTelefonico, strClaveSMS, dttFecha);
		}
		public string ObtenerCodigoSMS(string strNroTelefono)
		{
			ValidarClienteClaro _obj = new ValidarClienteClaro();
			return _obj.Obtener_CodigoSMS(strNroTelefono);
		}

		public string ValidarBRMS(Double intSolicitud)
		{
			ValidarClienteClaro _obj = new ValidarClienteClaro();
			return _obj.Validar_BRMS(intSolicitud);
		}

		public bool EnviarSMS(string strIdTransaccion, string strIpAplicacion, string strUsuarioApp, string strMensajeSMS, string strTiempo, string strIdentificadorMAS, string msisdn, string strAppConfigurador, out string strResultado, out string strMensaje)
		{

				WSEnvioSMS.bsEnvioSmsService objEnvioSMS = new WSEnvioSMS.bsEnvioSmsService();
				WSEnvioSMS.EnvioSMSRequestType objEnvioSMSRequest = new WSEnvioSMS.EnvioSMSRequestType();
				WSEnvioSMS.EnvioSMSResponseType objEnvioSMSResponse = new WSEnvioSMS.EnvioSMSResponseType();
				objEnvioSMS.Url = strAppConfigurador;
				objEnvioSMS.Credentials = System.Net.CredentialCache.DefaultCredentials;
				objEnvioSMS.Timeout = Convert.ToInt32(strTiempo); //45000 360000

				objEnvioSMSRequest.idTransaccion = strIdTransaccion;
				objEnvioSMSRequest.ipAplicacion = strIpAplicacion;
				objEnvioSMSRequest.usuarioApp = strUsuarioApp;
				objEnvioSMSRequest.mensaje = strMensajeSMS;
				objEnvioSMSRequest.identificadorMAS = strIdentificadorMAS;
				objEnvioSMSRequest.msisdn = msisdn;

				objEnvioSMSResponse = objEnvioSMS.enviarSms(objEnvioSMSRequest);

				strResultado = objEnvioSMSResponse.codigoError;
				strMensaje = objEnvioSMSResponse.mensajeError;
//				HelperLog.CrearArchivolog("ValidarCliente","Enviar SMS: " + strResultado ,"","",strMensaje);
		

			return (strResultado.Equals("0") ? true : false);
		}

		public bool EnviarMail(string strAppUrl, string straplicacion, string p_strRemitente, string p_strDestinatario,  string p_strAsunto, string p_strMensaje , string strResultado, string strError  )
		{
		
				string nombreServer = System.Net.Dns.GetHostName();
				string ipServer = System.Net.Dns.GetHostByName(nombreServer).AddressList[0].ToString();
				
				WSMail.EnvioMail objEnvioMail = new Claro.SisAct.Negocios.WSMail.EnvioMail();
				objEnvioMail.Url = strAppUrl;
			
				objEnvioMail.Credentials = System.Net.CredentialCache.DefaultCredentials;

				WSMail.AuditType obj = objEnvioMail.envioMail("100", ipServer, straplicacion, p_strRemitente, p_strDestinatario, p_strAsunto, p_strMensaje, 1);


				strResultado = obj.errorCode;
				strError = obj.errorMsg;
				HelperLog.CrearArchivolog("ValidarCliente","Enviar Mail: " + strResultado,"","",strError);
			
			return (strResultado.Equals("0") ? true : false);
		}

		public bool GuardarAuditoriaLog( ref AuditoriaLogs _pAuditoriaLog)
		{
			ValidarClienteClaro _obj = new ValidarClienteClaro();
			return _obj.Guardar_Logs (ref _pAuditoriaLog);
		}

		public bool ActualizarAuditoriaLog( ref AuditoriaLogs _pAuditoriaLog)
		{
			ValidarClienteClaro _obj = new ValidarClienteClaro();
			return _obj.Actualizar_Logs (ref _pAuditoriaLog);
		}

		public AuditoriaLogs ConsultarLogs(int intIDAudit)
		{
			AuditoriaLogs _p_Auditoria = new AuditoriaLogs();
			
				ValidarClienteClaro _obj = new ValidarClienteClaro();
				_p_Auditoria  = _obj.Listar_logs(intIDAudit);
			
			return _p_Auditoria;
		}
	}
}
