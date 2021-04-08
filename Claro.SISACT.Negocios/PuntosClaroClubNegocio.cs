using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;

using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for PuntosClaroClubNegocio.
	/// </summary>
	/// <remarks>
	/// Autor: E77568.
	/// PS - Automatización de canje y nota de crédito.
	/// </remarks>
	public class PuntosClaroClubNegocio
	{
		private string _NOMBRE_SERVER;
		private string _IP_SERVER;
		private string _APLICACION;

		public string NOMBRE_SERVER
		{
			set { _NOMBRE_SERVER = value; }
			get { return _NOMBRE_SERVER; }
		}
		public string IP_SERVER
		{
			set { _IP_SERVER = value; }
			get { return _IP_SERVER; }
		}
		/// <summary>
		/// Nombre de la aplicaciòn que llama al webservice.
		/// </summary>
		/// <remarks>
		/// Autor: E77568.
		/// PS - Automatización de canje y nota de crédito.
		/// RF-04.
		/// </remarks>
		public string APLICACION
		{
			set { _APLICACION = value; }
			get { return _APLICACION; }
		}

		/// <summary>
		/// Inicializa el objeto con el nombre del servidor, la direcciòn ip del servidor y el
		/// nombre de la aplicaciòn..
		/// </summary>
		/// <remarks>
		/// Autor: E77568.
		/// PS - Automatización de canje y nota de crédito.
		/// RF-04.
		/// </remarks>
		public PuntosClaroClubNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
			_NOMBRE_SERVER = System.Net.Dns.GetHostName();
			IP_SERVER = System.Net.Dns.GetHostByName(_NOMBRE_SERVER).AddressList[0].ToString();
			APLICACION = ConfigurationSettings.AppSettings["constAplicacion"].ToString();
		}


		/// <summary>
		/// Consulta los saldos para la visualización de los puntos y soles del cliente.
		/// </summary>
		/// <param name="K_TIPO_DOC">Tipo de documento.</param>
		/// <param name="K_NUM_DOC">Nùmero de documento.</param>
		/// <remarks>
		/// Autor: E77568.
		/// PS - Automatización de canje y nota de crédito.
		/// RF-04.
		/// </remarks>
		/// <returns>
		/// Devuelve un cursor con los siguientse datos:
		/// •	Saldo actual de Claro Puntos.
		/// •	Saldo de puntos en Postpago.
		/// •	Saldo de puntos en Prepago.
		/// •	Saldo de puntos en HFC.
		/// •	Saldo de puntos en DTH.
		/// •	Claro Puntos a utilizar
		/// •	Soles de descuento.
		/// •	Factor de Conversión (Esto con la finalidad que el Asesor pueda convertir de puntos a soles y viceversa).
		/// •	Código del Valor = 1, 2, 3, 4 ó 5 (Entero positivo)Para los clientes Postpago, Prepago, DTH y HFC.
		/// </returns>
		public ConsultarPuntosWS.consultarPuntosResponse consultarPuntos(string K_TIPO_DOC,
																		 string K_NUM_DOC,
																		 string usuarioAplicacion,
																		 string K_COD_CLIENTE)
		{
			ConsultarPuntosWS.ebsConsultaPuntosClaroClubService objPuntosClaroClub = new ConsultarPuntosWS.ebsConsultaPuntosClaroClubService();
			ConsultarPuntosWS.consultarPuntosRequest objConsultarPuntosRequest = new ConsultarPuntosWS.consultarPuntosRequest();
			ConsultarPuntosWS.consultarPuntosResponse objConsultarPuntosResponse = new ConsultarPuntosWS.consultarPuntosResponse();  
			int ConstTimeOutConsultarPuntos;
			objPuntosClaroClub.Url = ConfigurationSettings.AppSettings["ConstUrlConsultarPuntos"];
			objPuntosClaroClub.Credentials = System.Net.CredentialCache.DefaultCredentials;
			ConstTimeOutConsultarPuntos = Funciones.CheckInt(ConfigurationSettings.AppSettings["ConstTimeOutConsultarPuntos"]);
			// Si existe un timeout, asignarlo, sino usar el valor por defecto
			if (ConstTimeOutConsultarPuntos > 0) 
			{
				objPuntosClaroClub.Timeout = ConstTimeOutConsultarPuntos;
			}
			
			objConsultarPuntosRequest.idTransaccion = DateTime.Now.ToString("yyyyMMddHHmmss");
			objConsultarPuntosRequest.ipAplicacion = IP_SERVER;//"127.0.0.1";
			objConsultarPuntosRequest.aplicacion = APLICACION;
			objConsultarPuntosRequest.usuarioAplicacion = usuarioAplicacion;//"E77113";

			objConsultarPuntosRequest.tipoDoc = K_TIPO_DOC;
			objConsultarPuntosRequest.numDoc = K_NUM_DOC;//"06186910";

			objConsultarPuntosRequest.codigoCliente = K_COD_CLIENTE;
   		
				objConsultarPuntosResponse = objPuntosClaroClub.consultarPuntosClaroClub(objConsultarPuntosRequest);

				return objConsultarPuntosResponse;
		}


		/// <summary>
		/// Permite reservar (bloquear) los puntos al momento que el cliente solicita activar ó renovar un equipo.
		/// El WS invoca el SP de la BD de ClaroClub.
		/// </summary>
		/// <param name="K_TIPO_DOC">Tipo de documento.</param>
		/// <param name="K_NUM_DOC">Nùmero de documento.</param>
		/// <param name="tipoClie"></param>
		/// <param name="usuario">Còdigo de usuario.</param>
		/// <param name="txId">Còdigo que generò la transacciòn.</param>
		/// <param name="errorCode">Código de error</param>
		/// <param name="errorMsg">Descripción del error.</param>
		/// <remarks>
		/// Autor: E77568.
		/// PS - Automatización de canje y nota de crédito.
		/// RF-04.
		/// </remarks>
		public void bloquearPuntos(string K_TIPO_DOC,
			string K_NUM_DOC,
			string tipoClie,
			string usuario,
			ref string txId,
			ref string errorCode,
			ref string errorMsg)
		{
			GestionarPuntosClaroClubWS.ebsGestionarPuntosService objGestionarPuntosService = new GestionarPuntosClaroClubWS.ebsGestionarPuntosService();
			int ConstTimeOutGestionarPuntos;
			objGestionarPuntosService.Url = ConfigurationSettings.AppSettings["ConstUrlGestionarPuntos"];
			objGestionarPuntosService.Credentials = System.Net.CredentialCache.DefaultCredentials;
			ConstTimeOutGestionarPuntos = Funciones.CheckInt(ConfigurationSettings.AppSettings["ConstTimeOutGestionarPuntos"]);
			// Si existe un timeout, asignarlo, sino usar el valor por defecto
			if (ConstTimeOutGestionarPuntos > 0) 
			{
				objGestionarPuntosService.Timeout = ConstTimeOutGestionarPuntos;
			}

			GestionarPuntosClaroClubWS.bloquearPuntosRequest objBloquearPuntosRequest = new GestionarPuntosClaroClubWS.bloquearPuntosRequest();
			GestionarPuntosClaroClubWS.bloquearPuntosResponse objBloquearPuntosResponse = new GestionarPuntosClaroClubWS.bloquearPuntosResponse();   			
			objBloquearPuntosRequest.ipAplicacion = IP_SERVER;
			objBloquearPuntosRequest.aplicacion = APLICACION;
			objBloquearPuntosRequest.tipoDoc = K_TIPO_DOC;
			objBloquearPuntosRequest.numDoc = K_NUM_DOC;  
			objBloquearPuntosRequest.tipoClie = tipoClie;
			objBloquearPuntosRequest.usuario = usuario;  
						
			try
			{
				objBloquearPuntosResponse = objGestionarPuntosService.bloquearPuntos(objBloquearPuntosRequest);

				txId = objBloquearPuntosResponse.audit.txId;
				errorCode = objBloquearPuntosResponse.audit.errorCode;
				errorMsg = objBloquearPuntosResponse.audit.errorMsg;
			}
			finally
			{
				objGestionarPuntosService = null;
				objBloquearPuntosRequest = null;
				objBloquearPuntosResponse = null;
			}
		}

		/// <summary>
		/// Permite liberar los puntos al momento que el cliente solicita activar ó renovar un equipo.
		/// El WS invoca el SP de la BD de ClaroClub.
		/// </summary>
		/// <param name="K_TIPO_DOC">Tipo de documento.</param>
		/// <param name="K_NUM_DOC">Nùmero de documento.</param>
		/// <param name="tipoClie"></param>
		/// <param name="txId">Còdigo que generò la transacciòn.</param>
		/// <param name="errorCode">Código de error.</param>
		/// <param name="errorMsg">Descripción del error.</param>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public void liberarPuntos(string K_TIPO_DOC,
			string K_NUM_DOC,
			string tipoClie,
			ref string txId,
			ref string errorCode,
			ref string errorMsg)
		{

			GestionarPuntosClaroClubWS.ebsGestionarPuntosService objGestionarPuntosService = new GestionarPuntosClaroClubWS.ebsGestionarPuntosService();
			int ConstTimeOutGestionarPuntos;
			objGestionarPuntosService.Url = ConfigurationSettings.AppSettings["ConstUrlGestionarPuntos"];
			objGestionarPuntosService.Credentials = System.Net.CredentialCache.DefaultCredentials;
			ConstTimeOutGestionarPuntos = Funciones.CheckInt(ConfigurationSettings.AppSettings["ConstTimeOutGestionarPuntos"]);
			// Si existe un timeout, asignarlo, sino usar el valor por defecto
			if (ConstTimeOutGestionarPuntos > 0) 
			{
				objGestionarPuntosService.Timeout = ConstTimeOutGestionarPuntos;
			}

			GestionarPuntosClaroClubWS.liberarPuntosRequest objLiberarPuntosRequest = new GestionarPuntosClaroClubWS.liberarPuntosRequest();
			GestionarPuntosClaroClubWS.liberarPuntosResponse objLiberarPuntosResponse = new GestionarPuntosClaroClubWS.liberarPuntosResponse();   			
			objLiberarPuntosRequest.ipAplicacion = IP_SERVER;
			objLiberarPuntosRequest.aplicacion = APLICACION;
			objLiberarPuntosRequest.tipoDoc = K_TIPO_DOC;
			objLiberarPuntosRequest.numDoc = K_NUM_DOC;
			objLiberarPuntosRequest.tipoClie = tipoClie;
						
			try
			{
				objLiberarPuntosResponse = objGestionarPuntosService.liberarPuntos(objLiberarPuntosRequest);

				txId = objLiberarPuntosResponse.audit.txId;
				errorCode = objLiberarPuntosResponse.audit.errorCode;
				errorMsg = objLiberarPuntosResponse.audit.errorMsg;
			}
			finally
			{
				objGestionarPuntosService = null;
				objLiberarPuntosRequest = null;
				objLiberarPuntosResponse = null;
			}
		}

		/// <summary>
		/// Registra la operaciòn de canje de puntos Claro Club en el SISACT.
		/// El WS invoca el SP de la BD de ClaroClub.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public void InsertarCanjePuntos(CanjePuntos objCanjePuntos)
		{
			PuntosClaroClubDatos obj = new PuntosClaroClubDatos();

			obj.InsertarCanjePuntos(objCanjePuntos);
		}
		/// <summary>
		/// Registra la operaciòn de canje de puntos Claro Club en el SISACT.
		/// El WS invoca el SP de la BD de ClaroClub.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public void InsertarCanjePuntos2(CanjePuntos objCanjePuntos)
		{
			PuntosClaroClubDatos obj = new PuntosClaroClubDatos();

			obj.InsertarCanjePuntos2(objCanjePuntos);
		}
		/// <summary>
		/// Actualiza la operaciòn de canje de puntos Claro Club, cuando se efectuo el pago de la nota de crèdito.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public void ActualizarCanjePuntos(CanjePuntos objCanjePuntos)
		{
			PuntosClaroClubDatos obj = new PuntosClaroClubDatos();

			obj.ActualizarCanjePuntos(objCanjePuntos);
		}
		/// <summary>
		/// Devuelve los datos de un registro de puntos Claro Club, identificado por el nùmero de documento SAP.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public DataTable ListarCanjePuntos(string P_NRO_DOC_SAP_NC)
		{
			PuntosClaroClubDatos obj = new PuntosClaroClubDatos();

			return obj.ListarCanjePuntos(P_NRO_DOC_SAP_NC);
		}

		/// <summary>
		/// Elimina la operaciòn de canje de puntos Claro Club
		/// </summary>
		/// <remarks>
		/// Autor: Javier Sandoval
		/// PS - Renovacion PostPago Equipos Fase1 v6
		/// RF-04
		/// </remarks>
		public void EliminarCanjePuntos(CanjePuntos objCanjePuntos)
		{
			PuntosClaroClubDatos obj = new PuntosClaroClubDatos();

			obj.EliminarCanjePuntos(objCanjePuntos);
		}

		/// <summary>
		/// Verificar si existe una reserva de puntos, consultando al PUNTOSCC.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public void ValidaBloqueoBolsa(string k_tipo_doc,
									   string k_num_doc,
									   string k_tipo_clie,
									   ref string k_tipo_doc2,
									   ref string k_estado,
									   ref double k_coderror,
									   ref string k_descerror)
		{
			PuntosClaroClubDatos obj = new PuntosClaroClubDatos();

			obj.ValidaBloqueoBolsa(k_tipo_doc,
							       k_num_doc,
								   k_tipo_clie,
								   ref k_tipo_doc2,
								   ref k_estado,
								   ref k_coderror,
								   ref k_descerror);
		}


		//PROY-26366 - FASE II - INICIO

		public static ArrayList ListarDatosNCxDocSAP(string P_DOCUMENTO_SAP)
		{
			return new PuntosClaroClubDatos().ListarDatosNCxDocSAP(P_DOCUMENTO_SAP);
		}

		public static bool InsertarDetaClaroPuntos(Int64 ID_CANJE_PUNTOS, string SERIE_ARTICULO, Int64 PUNTOS_USADOS, decimal SOLES_DESCUENTO, ref string CODIGO_RESPUESTA, ref string MENSAJE_RESPUESTA)
		{
			return new PuntosClaroClubDatos().InsertarDetaClaroPuntos(ID_CANJE_PUNTOS, SERIE_ARTICULO, PUNTOS_USADOS, SOLES_DESCUENTO, ref CODIGO_RESPUESTA, ref MENSAJE_RESPUESTA);
		}

		//PROY-26366 - FASE II - FIN


	}
}
