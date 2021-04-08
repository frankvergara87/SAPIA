using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Text;
using System.Data;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	//	<summary>
	//	Summary description for DataCreditoNegocios.
	//	</summary>
	public class CreditosWSNegocios
	{
		string _Url;
		string _idAplicacion = null;
		string _usuAplicacion = null;
		string _idTransaccion = null;
		static string nombreServer = System.Net.Dns.GetHostName();
		string ipServer = System.Net.Dns.GetHostByName(nombreServer).AddressList[0].ToString();
		string[] _ServsDc = new string[4]; //ADD PROY-20054-IDEA-23849


		public CreditosWSNegocios()
		{
			_Url = ConfigurationSettings.AppSettings["RutaWS_Orquestador"].ToString();
			_idAplicacion = ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString();
			_usuAplicacion = ConfigurationSettings.AppSettings["constNombreAplicacion"].ToString();
			_idTransaccion = DateTime.Now.ToString("hhmmssfff");
		}

		private string nameLogs = "LogWSBM";
		private string nameLogsc = "LogWSBC"; //ADD PROY-20054-IDEA-23849

		public DataCreditoOUT EvaluarCredito(DataCreditoIN objIN, Usuario objUsuario, out string mensaje)
		{
			DataCreditoOUT rptaDC = null;
			mensaje = string.Empty;
			try 
			{
				string param = "";
				param = param + objIN.istrSecuencia + "|";
				param = param + objIN.istrTipoDocumento + "|";
				param = param + objIN.istrNumeroDocumento + "|";
				param = param + objIN.istrAPELLIDOPATERNO.ToUpper() + "|";
				param = param + objIN.istrAPELLIDOMATERNO.ToUpper() + "|";
				param = param + objIN.istrNOMBRES.ToUpper() + "|";
				param = param + objIN.istrDatoEntrada + "|";
				param = param + objIN.istrDatoComplemento + "|";
				param = param + objIN.istrTIPOPRODUCTO + "|";
				param = param + objIN.istrTIPOCLIENTE + "|";
				param = param + objIN.istrEDAD + "|";
				param = param + objIN.istrIngresoOLineaCredito + "|";
				param = param + objIN.istrTIPOTARJETA + "|";
				param = param + objIN.istrRUC + "|";
				param = param + objIN.istrANTIGUEDADLABORAL + "|";
				param = param + objIN.istrNumOperaPVU + "|";
				param = param + objIN.istrRegion + "|";
				param = param + objIN.istrArea + "|";
				param = param + objIN.istrPuntoVenta + "|";
				param = param + objIN.istrIDTerminal + "|";
				param = param + objIN.istrUsuarioACC + "|";
				param = param + objIN.ostrNumOperaEFT + "|";
				param = param + objIN.istrNUMCUENTAS + "|";
				param = param + objIN.strEstadoCivil + "|";
				param = param + "EbsCreditosWS:EvaluarCredito" + "|";

				HelperLog.EscribirLog("", nameLogs, "param: " + param, false);

				EbsCreditosWS.EbsCreditosWSService _objTransaccion = new EbsCreditosWS.EbsCreditosWSService();
				EbsCreditosWS.ConsultarDatosDCRequest _request = new EbsCreditosWS.ConsultarDatosDCRequest();
				EbsCreditosWS.ConsultarDatosDCResponse _response = new EbsCreditosWS.ConsultarDatosDCResponse();
				EbsCreditosWS.AuditRequestType _auditRequest = new EbsCreditosWS.AuditRequestType();
				EbsCreditosWS.BEUsuario _beUsuario = new EbsCreditosWS.BEUsuario();

				_objTransaccion.Url = _Url;
				_objTransaccion.Credentials = System.Net.CredentialCache.DefaultCredentials;
				_objTransaccion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOutEbsCreditosWS"]);

				_auditRequest.idTransaccion = _idTransaccion;
				_auditRequest.ipAplicacion = ipServer;
				_auditRequest.nombreAplicacion = nombreServer;
				_auditRequest.usuarioAplicacion = ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString();

				_request.flagConsulta = ConfigurationSettings.AppSettings["flagConsultaRepositorio"].ToString();
				_request.nroDocumento = objIN.istrNumeroDocumento;
				_request.strApePaterno = objIN.istrAPELLIDOPATERNO;
				_request.strApeMaterno = objIN.istrAPELLIDOMATERNO;
				_request.strNombres = objIN.istrNOMBRES;
				_request.strRazonSocial = objIN.istrNOMBRES;
				_request.tipoDocumento = objIN.istrTipoDocumento;
				_request.oficina = objIN.istrPuntoVenta;

				_beUsuario.apellido_Mat = objUsuario.Apellidos;
				_beUsuario.apellido_Pat = objUsuario.Apellidos;
				_beUsuario.area = objUsuario.AreaUsuario;
				_beUsuario.cadenaOpcionesPagina = string.Empty;
				_beUsuario.cadenaPerfil = objUsuario.Perfil;
				_beUsuario.canalVenta = objUsuario.TipoOficinaId;
				_beUsuario.canalVentaDescripcion = objUsuario.TipoOficinaId;
				_beUsuario.estadoAcceso = objUsuario.Estado;
				_beUsuario.host = objUsuario.CtaRed;
				_beUsuario.idArea = objUsuario.AreaUsuario;
				_beUsuario.idCuentaRed = objUsuario.Login;
				_beUsuario.idUsuario = objUsuario.UsuarioId;
				_beUsuario.idUsuarioSisact = objUsuario.UsuarioId;
				_beUsuario.idUsuarioSisactSpecified = (Funciones.CheckStr(objUsuario.UsuarioId).Length > 0) ? true : false;
				_beUsuario.idUsuarioSpecified = (Funciones.CheckStr(objUsuario.UsuarioId).Length > 0) ? true : false;
				_beUsuario.idVendedorSap = objUsuario.CodigoVendedor;
				_beUsuario.login = objUsuario.Login;
				_beUsuario.nombre = objUsuario.Nombre;
				_beUsuario.nombreCompleto = objUsuario.NombreCompleto;
				_beUsuario.oficinaVenta = objUsuario.OficinaId;
				_beUsuario.oficinaVentaDescripcion = objUsuario.OficinaDes;
				_beUsuario.perfil149 = false;
				_beUsuario.perfil149Specified = false;
				_beUsuario.terminal = string.Empty;
				_beUsuario.tipoOficina = objUsuario.TipoOficinaId;

				_request.objUsuario = _beUsuario;

				_request.auditRequestType = _auditRequest;

				_response = _objTransaccion.evaluarCredito(_request);

				string strDataCreditoOUT = _response.cadena;
				//string strDataCreditoOUT = "&lt;?xml version='1.0' encoding='UTF-8' standalone='yes'?>&lt;EvaluacionClaro fechaNacimiento='' limiteCreditoClaro='0.0' limiteCreditoBaseExterna='0.0' limiteCreditoDataCredito='0.0' PUNTAJE='' NUMERO_ENTIDADES_RANKIN_OPERATIVO='' SCORE_RANKIN_OPERATIVO='' ANALISIS='' RAZONES='' NUMERO_DOCUMENTO='000007398' ANTIGUEDAD_LABORAL='0' TOP_10000='' TIPO_DE_TARJETA='5' TIPO_DE_CLIENTE='0' INGRESO_O_LC='0.0' EDAD='0' LINEA_DE_CREDITO_EN_EL_SISTEMA='0.0' TIPO_DE_PRODUCTO='0' CREDIT_SCORE='R' SCORE='25' EXPLICACION='' NV_TOTAL_CARGOS_FIJOS='0.0' NV_LC_MAXIMO='0.0' LC_DISPONIBLE='0.0' CLASE_DE_CLIENTE='' LIMITE_DE_CREDITO='0.0' DIRECCIONES='' ACCION='S' RegsCalificacion='' CODIGOMODELO='' NUMEROOPERACION='170417000020279' respuesta='09' fechaConsulta='1492471155710'/>";

				XmlNode XmlNodo;
				XmlDocument XmlDoc = new XmlDocument();
				string xmlStringResult = strDataCreditoOUT.Replace("&lt;", "<");
				XmlDoc.LoadXml(xmlStringResult);

				XmlNodo = XmlDoc.DocumentElement;

				rptaDC = new DataCreditoOUT();
				string strBuroConsultado = _response.buroConsultado;
				rptaDC.CodigoBuro = strBuroConsultado;
				rptaDC.BUROCONSULTADO = strBuroConsultado;

				foreach (XmlAttribute atributo in XmlNodo.Attributes) 
				{
					if (atributo.Name.Equals("NOMBRES")) { rptaDC.NOMBRES = atributo.Value.ToUpper(); }
					else if (atributo.Name.Equals("APELLIDO_PATERNO")) { rptaDC.APELLIDO_PATERNO = atributo.Value.ToUpper(); }
					else if (atributo.Name.Equals("APELLIDO_MATERNO")) { rptaDC.APELLIDO_MATERNO = atributo.Value.ToUpper(); }
					else if (atributo.Name.Equals("NUMERO_DOCUMENTO")) { rptaDC.NUMERO_DOCUMENTO = atributo.Value; }
					else if (atributo.Name.Equals("ANTIGUEDAD_LABORAL")) { rptaDC.ANTIGUEDAD_LABORAL = Funciones.CheckInt(atributo.Value); }
					else if (atributo.Name.Equals("TOP_10000")) { rptaDC.TOP_10000 = atributo.Value; }
					else if (atributo.Name.Equals("TIPO_DE_TARJETA")) { rptaDC.TIPO_DE_TARJETA = atributo.Value; }
					else if (atributo.Name.Equals("TIPO_DE_CLIENTE")) { rptaDC.TIPO_DE_CLIENTE = atributo.Value; }
					else if (atributo.Name.Equals("INGRESO_O_LC")) { rptaDC.INGRESO_O_LC = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("EDAD")) { rptaDC.EDAD = Funciones.CheckInt(atributo.Value); }
					else if (atributo.Name.Equals("LINEA_DE_CREDITO_EN_EL_SISTEMA")) { rptaDC.LINEA_DE_CREDITO_EN_EL_SISTEMA = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("TIPO_DE_PRODUCTO")) { rptaDC.TIPO_DE_PRODUCTO = atributo.Value; }
					else if (atributo.Name.Equals("CREDIT_SCORE")) { rptaDC.CREDIT_SCORE = atributo.Value; }
					//else if (atributo.Name.Equals("SCORE")) { rptaDC.SCORE = Funciones.CheckInt(atributo.Value); }
			        else if (atributo.Name.Equals("SCORE")) { rptaDC.SCORE = (Funciones.CheckInt(Math.Round(Funciones.CheckDbl(atributo.Value), 0))); }
					else if (atributo.Name.Equals("EXPLICACION")) { rptaDC.EXPLICACION = atributo.Value; }
					else if (atributo.Name.Equals("NV_TOTAL_CARGOS_FIJOS")) { rptaDC.NV_TOTAL_CARGOS_FIJOS = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("NV_LC_MAXIMO")) { rptaDC.NV_LC_MAXIMO = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("LC_DISPONIBLE")) { rptaDC.LC_DISPONIBLE = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("CLASE_DE_CLIENTE")) { rptaDC.CLASE_DE_CLIENTE = atributo.Value; }
					else if (atributo.Name.Equals("LIMITE_DE_CREDITO")) { rptaDC.LIMITE_DE_CREDITO = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("DIRECCIONES")) { rptaDC.DIRECCIONES = atributo.Value; }
					else if (atributo.Name.Equals("ACCION")) { rptaDC.ACCION = atributo.Value; }
					else if (atributo.Name.Equals("RegsCalificacion")) { rptaDC.RegsCalificacion = atributo.Value; }
					else if (atributo.Name.Equals("CODIGOMODELO")) { rptaDC.CODIGOMODELO = atributo.Value; }
					else if (atributo.Name.Equals("NUMEROOPERACION")) { rptaDC.NUMEROOPERACION = atributo.Value; }
					else if (atributo.Name.Equals("respuesta")) { rptaDC.respuesta = atributo.Value; }
					else if (atributo.Name.Equals("fechaConsulta")) { rptaDC.fechaConsulta = atributo.Value; }
					else if (atributo.Name.Equals("RAZONES")) { rptaDC.RAZONES = atributo.Value; }
					else if (atributo.Name.Equals("ANALISIS")) { rptaDC.ANALISIS = atributo.Value; }
					else if (atributo.Name.Equals("SCORE_RANKIN_OPERATIVO")) { rptaDC.SCORE_RANKIN_OPERATIVO = atributo.Value; }
					else if (atributo.Name.Equals("NUMERO_ENTIDADES_RANKIN_OPERATIVO")) { rptaDC.NUMERO_ENTIDADES_RANKIN_OPERATIVO = atributo.Value; }
					else if (atributo.Name.Equals("PUNTAJE")) { rptaDC.PUNTAJE = atributo.Value; }
					else if (atributo.Name.Equals("limiteCreditoDataCredito")) { rptaDC.limiteCreditoDataCredito = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("limiteCreditoBaseExterna")) { rptaDC.limiteCreditoBaseExterna = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("limiteCreditoClaro")) { rptaDC.limiteCreditoClaro = Funciones.CheckDbl(atributo.Value); }
					else if (atributo.Name.Equals("fechaNacimiento")) { rptaDC.fechanacimiento = atributo.Value; }
					else { mensaje = "DataCredito Error: Parametro desconocido (" + atributo.Name + ") enviado por DataCredito."; }
					//"Error en la información enviada por DataCredito. Comunicarse con Créditos y Activaciones"
				}
			}
			catch (Exception ex)
			{
				rptaDC = null;
				HelperLog.EscribirLog("", nameLogs, "ERROR WSBM: " + ex.Message, false);
				mensaje = "Error en la información enviada por EbsCreditosWS. Comunicarse con Créditos y Activaciones.";
				//throw ex;
			}
			return rptaDC;
		}

		//INICIO: PROY-20054-IDEA-23849
		public EmpresaExperto ConsultaDataCreditoCorp(DataCreditoCorpIN p_datacredito,
																		string user, 
																		out string mensaje, 
																		string nombreHost, 
																		string nombreServer, string ipServer, string ipcliente,Usuario objUsuario)
		{
			EbsCreditosWS.EbsCreditosWSService _objTransaccion = new EbsCreditosWS.EbsCreditosWSService();
			EbsCreditosWS.ConsultarDatosDCRequest _request = new EbsCreditosWS.ConsultarDatosDCRequest();
			EbsCreditosWS.ConsultarDatosDCResponse _response = new EbsCreditosWS.ConsultarDatosDCResponse();
			EbsCreditosWS.AuditRequestType _auditRequest = new EbsCreditosWS.AuditRequestType();
			EbsCreditosWS.BEUsuario _beUsuario = new EbsCreditosWS.BEUsuario();

			EmpresaExperto rptaEmpresaDC = new EmpresaExperto();
			rptaEmpresaDC.strFlagInterno = string.Empty;
			mensaje = string.Empty;
			
			string nameArchivo = "LogWSDrools";	
			
			HistorialDataCreditoCorp objHistorialDataCreditoCorp = new HistorialDataCreditoCorp();
			ArrayList ListaRepresentanteLegal = new ArrayList();

			rptaEmpresaDC.origen_experto = "DC";

			_ServsDc[0] = ConfigurationSettings.AppSettings["DcCorpServicio12"];
			_ServsDc[1] = ConfigurationSettings.AppSettings["DcCorpServicio50"];
			_ServsDc[2] = ConfigurationSettings.AppSettings["DcCorpServicio53"];
			_ServsDc[3] = "";

			try
			{
				DataSet oDataSet;
				DataTable oHeader;
				DataTable oError;

				string strCodigoRetorno = string.Empty;
				string strNroOperacion = string.Empty;

				string strNroOperacionws50 = string.Empty;
				string strNroOperacionws53 = string.Empty;

				string strCodError = string.Empty;
				string strMsgError = string.Empty;

				string strRazonSocial = string.Empty;
				string strRiesgo = string.Empty;

				if (p_datacredito.istrTipoDocumento.Length == 2) 
				{
					TipoDocumento item = new MaestroNegocio().ObtenerTipoDocumentosPVU(p_datacredito.istrTipoDocumento, "")[0] as TipoDocumento;
					p_datacredito.istrTipoDocumento = item.ID_DC_CORP;
				}

				//Inicio: Parametros de Entrada
				_objTransaccion.Url = _Url;
				_objTransaccion.Credentials = System.Net.CredentialCache.DefaultCredentials;
				_objTransaccion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOutEbsCreditosWS"]);

				_auditRequest.idTransaccion = _idTransaccion;
				_auditRequest.ipAplicacion = ipServer;
				_auditRequest.nombreAplicacion = nombreServer;
				_auditRequest.usuarioAplicacion = ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString();

				HelperLog.EscribirLog("", nameLogsc, "_objTransaccion.Url: " + _objTransaccion.Url, false);
				HelperLog.EscribirLog("", nameLogsc, "_objTransaccion.Timeout : " + _objTransaccion.Timeout , false);
				HelperLog.EscribirLog("", nameLogsc, "_auditRequest.idTransaccion : " + _auditRequest.idTransaccion , false);
				HelperLog.EscribirLog("", nameLogsc, "_auditRequest.ipAplicacion : " + _auditRequest.ipAplicacion , false);
				HelperLog.EscribirLog("", nameLogsc, "_auditRequest.nombreAplicacion: " + _auditRequest.nombreAplicacion, false);
				HelperLog.EscribirLog("", nameLogsc, "_auditRequest.usuarioAplicacion: " + _auditRequest.usuarioAplicacion, false);

				_request.flagConsulta = ConfigurationSettings.AppSettings["flagConsultaRepositorio"].ToString();
				_request.nroDocumento = p_datacredito.istrNumeroDocumento;
				_request.strApePaterno = p_datacredito.istrApellidoPaterno;
				_request.strApeMaterno = p_datacredito.istrApellidoMaterno;
				_request.strNombres = p_datacredito.istrNombres;
				_request.strRazonSocial = p_datacredito.istrNombres;
				_request.tipoDocumento = p_datacredito.istrTipoDocumento;
				_request.oficina = p_datacredito.istrPuntoVenta;

				HelperLog.EscribirLog("", nameLogsc, "_request.flagConsulta: " + _request.flagConsulta, false);
				HelperLog.EscribirLog("", nameLogsc, "_request.nroDocumento: " + _request.nroDocumento, false);
				HelperLog.EscribirLog("", nameLogsc, "_request.strApePaterno: " + _request.strApePaterno, false);
				HelperLog.EscribirLog("", nameLogsc, "_request.strApeMaterno: " + _request.strApeMaterno, false);
				HelperLog.EscribirLog("", nameLogsc, "_request.strNombres: " + _request.strNombres, false);
				HelperLog.EscribirLog("", nameLogsc, "_request.strRazonSocial: " + _request.strRazonSocial, false);
				HelperLog.EscribirLog("", nameLogsc, "_request.tipoDocumento: " + _request.tipoDocumento, false);
				HelperLog.EscribirLog("", nameLogsc, "_request.oficina : " + _request.oficina , false);

				_beUsuario.apellido_Mat = objUsuario.Apellidos;
				_beUsuario.apellido_Pat = objUsuario.Apellidos;
				_beUsuario.area = objUsuario.AreaUsuario;
				_beUsuario.cadenaOpcionesPagina = string.Empty;
				_beUsuario.cadenaPerfil = objUsuario.Perfil;
				_beUsuario.canalVenta = objUsuario.TipoOficinaId;
				_beUsuario.canalVentaDescripcion = objUsuario.TipoOficinaId;
				_beUsuario.estadoAcceso = objUsuario.Estado;
				_beUsuario.host = objUsuario.CtaRed;
				_beUsuario.idArea = objUsuario.AreaUsuario;
				_beUsuario.idCuentaRed = objUsuario.Login;
				_beUsuario.idUsuario = objUsuario.UsuarioId;
				_beUsuario.idUsuarioSisact = objUsuario.UsuarioId;
				_beUsuario.idUsuarioSisactSpecified = (Funciones.CheckStr(objUsuario.UsuarioId).Length > 0) ? true : false;
				_beUsuario.idUsuarioSpecified = (Funciones.CheckStr(objUsuario.UsuarioId).Length > 0) ? true : false;
				_beUsuario.idVendedorSap = objUsuario.CodigoVendedor;
				_beUsuario.login = objUsuario.Login;
				_beUsuario.nombre = objUsuario.Nombre;
				_beUsuario.nombreCompleto = objUsuario.NombreCompleto;
				_beUsuario.oficinaVenta = objUsuario.OficinaId;
				_beUsuario.oficinaVentaDescripcion = objUsuario.OficinaDes;
				_beUsuario.perfil149 = false;
				_beUsuario.perfil149Specified = false;
				_beUsuario.terminal = string.Empty;
				_beUsuario.tipoOficina = objUsuario.TipoOficinaId;

				_request.objUsuario = _beUsuario;
				_request.auditRequestType = _auditRequest;

				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.apellido_Mat : " + _beUsuario.apellido_Mat , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.apellido_Pat : " + _beUsuario.apellido_Pat , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.area : " + _beUsuario.area , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.cadenaOpcionesPagina : " + _beUsuario.cadenaOpcionesPagina , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.cadenaPerfil : " + _beUsuario.cadenaPerfil , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.canalVenta : " + _beUsuario.canalVenta , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.canalVentaDescripcion : " + _beUsuario.canalVentaDescripcion , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.estadoAcceso : " + _beUsuario.estadoAcceso , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.host : " + _beUsuario.host , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.idArea : " + _beUsuario.idArea , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.idCuentaRed : " + _beUsuario.idCuentaRed , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.idUsuario : " + _beUsuario.idUsuario , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.idUsuarioSisact : " + _beUsuario.idUsuarioSisact , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.idUsuarioSisactSpecified : " + _beUsuario.idUsuarioSisactSpecified , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.idUsuarioSpecified : " + _beUsuario.idUsuarioSpecified , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.idVendedorSap : " + _beUsuario.idVendedorSap , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.login : " + _beUsuario.login , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.nombre : " + _beUsuario.nombre , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.nombreCompleto : " + _beUsuario.nombreCompleto , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.oficinaVenta : " + _beUsuario.oficinaVenta , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.oficinaVentaDescripcion : " + _beUsuario.oficinaVentaDescripcion , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.perfil149 : " + _beUsuario.perfil149 , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.perfil149Specified : " + _beUsuario.perfil149Specified , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.terminal : " + _beUsuario.terminal , false);
				HelperLog.EscribirLog("", nameLogsc, "_beUsuario.tipoOficina : " + _beUsuario.tipoOficina , false);

				_response = _objTransaccion.evaluarCredito(_request);
				HelperLog.EscribirLog("", nameLogsc, "_response.codigoError: " + _response.codigoError, false);
				HelperLog.EscribirLog("", nameLogsc, "_response.descripcionError: " + _response.descripcionError, false);
				HelperLog.EscribirLog("", nameLogsc, "_response.tipo: " + _response.tipo, false);
				HelperLog.EscribirLog("", nameLogsc, "_response.auditResponseType.codigoRespuesta: " + _response.auditResponseType.codigoRespuesta, false);
				HelperLog.EscribirLog("", nameLogsc, "_response.auditResponseType.mensajeRespuesta: " + _response.auditResponseType.mensajeRespuesta, false);
				string rptaReturn = _response.cadena;
				HelperLog.EscribirLog("", nameLogsc, "rptaReturn: " + rptaReturn, false);

				string strRpta12 = System.Text.RegularExpressions.Regex.Split(rptaReturn,"RespuestaSVC12>")[1];
				strRpta12 = strRpta12.Substring(0,strRpta12.Length-2);
				strRpta12 = "<RespuestaSVC12>" + strRpta12 + "</RespuestaSVC12>";
				string strRpta50 = System.Text.RegularExpressions.Regex.Split(rptaReturn,"RespuestaSVC50>")[1];
				strRpta50 = strRpta50.Substring(0,strRpta50.Length-2);
				strRpta50 = "<RespuestaSVC50>" + strRpta50 + "</RespuestaSVC50>";
				string strRpta53 = System.Text.RegularExpressions.Regex.Split(rptaReturn,"RespuestaSVC53>")[1];
				strRpta53 = strRpta53.Substring(0,strRpta53.Length-2);
				strRpta53 = "<RespuestaSVC53>" + strRpta53 + "</RespuestaSVC53>";

				#region INICIO SERVICIO 12
				// INICIO SERVICIO 12
				objHistorialDataCreditoCorp.ws12_In_TipoDocumento = p_datacredito.istrTipoDocumento;
				objHistorialDataCreditoCorp.ws12_In_NumeroDocumento = p_datacredito.istrNumeroDocumento;
				objHistorialDataCreditoCorp.ws12_In_TipoPersona = p_datacredito.istrTipoPersona;
				objHistorialDataCreditoCorp.ws12_In_TipoServicio = _ServsDc[0].ToString();

				System.Xml.XmlDocument oXMLDocument12 = new System.Xml.XmlDocument();				
				oXMLDocument12.LoadXml(strRpta12);

				oDataSet = new DataSet();
				oDataSet.ReadXml(new System.Xml.XmlNodeReader(oXMLDocument12));				

				oHeader = new DataTable();
				oError = new DataTable();						

				if (oDataSet.Tables.Count>0)
				{
					for(int i=0;i<oDataSet.Tables.Count;i++)
					{
						switch(oDataSet.Tables[i].TableName.ToUpper())
						{
							case "HEADER":
								oHeader = oDataSet.Tables[i];
								break;
							case "ERROR":
								oError = oDataSet.Tables[i];
								break;
						}						 
					}
				}

				if (oError.Rows.Count > 0)
				{
					strCodError = oError.Rows[0]["CodigoMensajes"].ToString();
					strMsgError = oError.Rows[0]["Mensaje"].ToString();

					objHistorialDataCreditoCorp.ws12_Out_Error_CodigoMensajes = strCodError;
					objHistorialDataCreditoCorp.ws12_Out_Error_Mensaje = strMsgError;

				}
				if (oHeader.Rows.Count > 0)
				{
					strNroOperacion = oHeader.Rows[0]["NumeroOperacion"].ToString();
					strCodigoRetorno = oHeader.Rows[0]["CodigoRetorno"].ToString();	
			
					objHistorialDataCreditoCorp.ws12_Out_Header_Transaccion = oHeader.Rows[0]["Transaccion"].ToString();
					objHistorialDataCreditoCorp.ws12_Out_Header_TipoServicio = _ServsDc[0].ToString();;

					objHistorialDataCreditoCorp.ws12_Out_Header_CodigoRetorno = strCodigoRetorno;
					objHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion = strNroOperacion;

					if (strCodigoRetorno != ConfigurationSettings.AppSettings["DcCorpCodigoRetornoOk"])
					{	
						rptaEmpresaDC.strCodError = strCodError;
						rptaEmpresaDC.strMensajeError = strMsgError;
						rptaEmpresaDC.strCodRetorno = strCodigoRetorno;
						rptaEmpresaDC.strFlagInterno = "1";

						mensaje = "Error Consulta DataCredito Servicio 12";
						return rptaEmpresaDC;
					}
				}

				oHeader = null;
				oError = null;
				oDataSet = null;
				// FIN SERVICIO 12
				#endregion

				#region INICIO SERVICIO 50
				// INICIO SERVICIO 50
				objHistorialDataCreditoCorp.ws50_In_TipoServicio = _ServsDc[1];
				objHistorialDataCreditoCorp.ws50_In_NumeroOperacion = strNroOperacion;

				System.Xml.XmlDocument oXMLDocument50 = new System.Xml.XmlDocument();
				oXMLDocument50.LoadXml(strRpta50);

				oDataSet = new DataSet();
				oDataSet.ReadXml(new System.Xml.XmlNodeReader(oXMLDocument50));

				DataTable oDatosCliente = new DataTable();
				DataTable oEvaluacionCliente = new DataTable();

				if (oDataSet.Tables.Count>0)
				{
					for(int i=0;i<oDataSet.Tables.Count;i++)
					{
						switch(oDataSet.Tables[i].TableName.ToUpper())
						{
							case "HEADER":
								oHeader = oDataSet.Tables[i];
								break;
							case "INTEGRANTE":
								oDatosCliente = oDataSet.Tables[i];
								break;
							case "CAMPO":
								oEvaluacionCliente = oDataSet.Tables[i];
								break;
						}
					}
				}
				if (oHeader.Rows.Count > 0)
				{	
					strCodigoRetorno = oHeader.Rows[0]["CodigoRetorno"].ToString();
					strNroOperacionws50 = oHeader.Rows[0]["NumeroOperacion"].ToString();

					objHistorialDataCreditoCorp.ws50_Out_Header_Transaccion = oHeader.Rows[0]["Transaccion"].ToString();
					objHistorialDataCreditoCorp.ws50_Out_Header_TipoServicio = oHeader.Rows[0]["TipoServicio"].ToString();
				
					objHistorialDataCreditoCorp.ws50_Out_Header_CodigoRetorno = strCodigoRetorno;
					objHistorialDataCreditoCorp.ws50_Out_Header_NumeroOperacion = strNroOperacionws50;

					if (strCodigoRetorno != ConfigurationSettings.AppSettings["DcCorpCodigoRetornoOk"])
					{	
						rptaEmpresaDC.strCodRetorno = strCodigoRetorno;
						rptaEmpresaDC.strFlagInterno = "2";

						mensaje = "Error Consulta DataCredito Servicio 50";
						return rptaEmpresaDC;
					}
				}

				if (oDatosCliente.Rows.Count > 0)
				{
					if (p_datacredito.istrTipoPersona.Equals("J"))
					{
						strRazonSocial = oDatosCliente.Rows[0]["Nombres"].ToString().Trim().ToUpper();						
						if (strRazonSocial.Length > 40)
						{
							strRazonSocial = strRazonSocial.Substring(0,40);
						}							
					}
					else
					{
						// T12618 - Considerar nombres y apellidos retornados por DC - INICIO
						
						strRazonSocial  = "";

						string strNombreCompletoDC = "";
						string strNombresDC = "";
						string strApePatDC = "";
						string strApeMatDC = "";
						string[] arrNombresDC;

						strNombreCompletoDC = oDatosCliente.Rows[0]["Nombres"].ToString().Trim().ToUpper();
						//JAR - llenar razon social cuando es PN
						strRazonSocial = strNombreCompletoDC;						
						if (strRazonSocial.Length > 40)
						{
							strRazonSocial = strRazonSocial.Substring(0,40);
						}	
						//Fin cambios JAR
						arrNombresDC = strNombreCompletoDC.Split(' ');
						strApePatDC = "";
						strApeMatDC = "";
						strNombresDC = "";
						if (arrNombresDC.Length == 3)
						{
							strApePatDC = arrNombresDC[0].Trim();
							strApeMatDC = arrNombresDC[1].Trim();
							strNombresDC = arrNombresDC[2].Trim();
						}
						else
						{
							if (arrNombresDC.Length > 3)
							{
								strApePatDC = arrNombresDC[0].Trim();
								strApeMatDC = arrNombresDC[1].Trim();
								strNombresDC = "";
								for (int z=2;z<arrNombresDC.Length;z++)
								{
									strNombresDC = strNombresDC.Trim() + " " + arrNombresDC[z];
								}
								strNombresDC = strNombresDC.Trim();
							}
							else
							{
								// T12618 - Para personas con dos nombres - INICIO
								strApePatDC = arrNombresDC[0].Trim();
								strNombresDC = arrNombresDC[1].Trim();
								// T12618 - Para personas con dos nombres - FIN
							}
						}

						objHistorialDataCreditoCorp.ws12_In_ApellidoPaterno = strApePatDC;
						objHistorialDataCreditoCorp.ws12_In_ApellidoMaterno = strApeMatDC;
						objHistorialDataCreditoCorp.ws12_In_Nombres = strNombresDC;

						// T12618 - Considerar nombres y apellidos retornados por DC - FIN
					}

					objHistorialDataCreditoCorp.ws50_Out_GrupoIntegrantes_IntegranteTipoDocumento = oDatosCliente.Rows[0]["TipoDocumento"].ToString();
					objHistorialDataCreditoCorp.ws50_Out_GrupoIntegrantes_IntegranteNumeroDocumento = oDatosCliente.Rows[0]["NumeroDocumento"].ToString();
					objHistorialDataCreditoCorp.ws50_Out_GrupoIntegrantes_IntegranteNombres = oDatosCliente.Rows[0]["Nombres"].ToString().Trim().ToUpper();

				}
				string strAltoRiesgo,strMedioRiesgo,strBajoRiesgo,strSinHistorial,strRUCEnBaja;
				strAltoRiesgo = ConfigurationSettings.AppSettings["DcCorpRiesgoAlto"].ToUpper();
				strMedioRiesgo = ConfigurationSettings.AppSettings["DcCorpRiesgoMedio"].ToUpper();
				strBajoRiesgo = ConfigurationSettings.AppSettings["DcCorpRiesgoBajo"].ToUpper();
				strSinHistorial = ConfigurationSettings.AppSettings["DcCorpSinHistorial"].ToUpper();
				strRUCEnBaja = ConfigurationSettings.AppSettings["DcCorpRUCEnBaja"].ToUpper();

				string strConstAccion,strConstConcepto1,strConstConcepto2,strConstConcepto3;
				strConstAccion = ConfigurationSettings.AppSettings["DcCorpServ50Accion"].ToUpper();
				strConstConcepto1 = ConfigurationSettings.AppSettings["DcCorpServ50Campo1"].ToUpper();
				strConstConcepto2 = ConfigurationSettings.AppSettings["DcCorpServ50Campo2"].ToUpper();
				strConstConcepto3 = ConfigurationSettings.AppSettings["DcCorpServ50Campo3"].ToUpper();

				string strConstExplicacion,strConstExplicacionAux;
				strConstExplicacion = ConfigurationSettings.AppSettings["DcCorpServ50CampoExplicacion"].ToUpper();
				strConstExplicacionAux = ConfigurationSettings.AppSettings["DcCorpServ50CampoExplicacionAuxiliar"].ToUpper();;
			
				string montoConcepto1 = "";
				string montoConcepto2 = "";
				string montoConcepto3 = "";

				if (oEvaluacionCliente.Rows.Count > 0)
				{
					for(int i=0;i<oEvaluacionCliente.Rows.Count;i++)
					{						
						string nombreCampo = Funciones.CheckStr(oEvaluacionCliente.Rows[i]["Nombre"]).ToUpper();
						string existeCampo = Funciones.CheckStr(oEvaluacionCliente.Rows[i]["ExisteCampo"]).ToUpper();
						string valor = Funciones.CheckStr(oEvaluacionCliente.Rows[i]["Valor"]).ToUpper();
				
						if (nombreCampo.Equals(strConstAccion))
						{
							strRiesgo = valor.ToUpper();
							if (strRiesgo.Equals(strBajoRiesgo))
								strRiesgo = "1" ;//"Bajo";								
							else if (strRiesgo.Equals(strMedioRiesgo))
								strRiesgo = "2" ;//"Medio";								
							else if (strRiesgo.Equals(strAltoRiesgo))
								strRiesgo = "3" ;//"Alto";
							else if (strRiesgo.Equals(strSinHistorial))
								strRiesgo = "4"; //Sin historial
							else if (strRiesgo.Equals(strRUCEnBaja))
							{
								strRiesgo = "5"; //RUC en Baja
								rptaEmpresaDC.estado_ruc = "B";
								rptaEmpresaDC.strCodRetorno = strCodigoRetorno;
								rptaEmpresaDC.strNroOperacion = strNroOperacion;
								rptaEmpresaDC.strRazonSocial = strRazonSocial;
								rptaEmpresaDC.strRiesgo = strRiesgo;
								rptaEmpresaDC.strNombres = p_datacredito.istrNombres;
								rptaEmpresaDC.strApellidoPaterno = p_datacredito.istrApellidoPaterno;
								rptaEmpresaDC.strApellidoMaterno = p_datacredito.istrApellidoMaterno;

								rptaEmpresaDC.strFlagInterno = "0";

								mensaje = "RUC SUSPENDIDO EN BAJA EN SUNAT";
								return rptaEmpresaDC;
							}

							objHistorialDataCreditoCorp.ws50_Out_CampoNombre_Accion = strConstAccion;
							objHistorialDataCreditoCorp.ws50_Out_CampoExisteCampo_Accion = "0";
							objHistorialDataCreditoCorp.ws50_Out_CampoValor_Accion = strRiesgo;

						}
						else if(nombreCampo.Equals(strConstConcepto1))
						{
							montoConcepto1 = valor.Replace("S/.","").Trim();

							objHistorialDataCreditoCorp.ws50_Out_CampoNombre_MsgIngTarjeta = strConstConcepto1;
							objHistorialDataCreditoCorp.ws50_Out_CampoExisteCampo_MsgIngTarjeta = "0";
							objHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngTarjeta = montoConcepto1;
						}
						else if(nombreCampo.Equals(strConstConcepto2))
						{
							montoConcepto2 = valor.Replace("S/.","").Trim();

							objHistorialDataCreditoCorp.ws50_Out_CampoNombre_MsgIngDHipotecaria = strConstConcepto2;
							objHistorialDataCreditoCorp.ws50_Out_CampoExisteCampo_MsgIngDHipotecaria = "0";
							objHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDHipotecaria = montoConcepto2;
						}
						else if(nombreCampo.Equals(strConstConcepto3))
						{
							montoConcepto3 = valor.Replace("S/.","").Trim();

							objHistorialDataCreditoCorp.ws50_Out_CampoNombre_MsgIngDnHipoTarjeta = strConstConcepto3;
							objHistorialDataCreditoCorp.ws50_Out_CampoExisteCampo_MsgIngDnHipoTarjeta = "0";
							objHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDnHipoTarjeta = montoConcepto3;
						}
						else if(nombreCampo.Equals(strConstExplicacion))
						{
							objHistorialDataCreditoCorp.ws50_Out_CampoNombre_Explicacion = strConstExplicacion;
							objHistorialDataCreditoCorp.ws50_Out_CampoExisteCampo_Explicacion = "0";
							objHistorialDataCreditoCorp.ws50_Out_CampoValor_Explicacion = valor;
						}
						else if(nombreCampo.Equals(strConstExplicacionAux))
						{
							objHistorialDataCreditoCorp.ws50_Out_CampoNombre_ExplicacionAuxiliar = strConstExplicacionAux;
							objHistorialDataCreditoCorp.ws50_Out_CampoExisteCampo_ExplicacionAuxiliar = "0";
							objHistorialDataCreditoCorp.ws50_Out_CampoValor_ExplicacionAuxiliar = valor;
						}
					}
				}
				double monto1 = 0;
				double monto2 = 0;
				double monto3 = 0;

				if (Funciones.isNumeric(montoConcepto1)) monto1 = Funciones.CheckDbl(montoConcepto1);
				if (Funciones.isNumeric(montoConcepto2)) monto2 = Funciones.CheckDbl(montoConcepto2);
				if (Funciones.isNumeric(montoConcepto3)) monto3 = Funciones.CheckDbl(montoConcepto3);
			
				// Por regla se toma el Monto Mayor
				double montoMayor = monto1;
				if (monto2>montoMayor) montoMayor = monto2;
				if (monto3>montoMayor) montoMayor = monto3;

				rptaEmpresaDC.estado_ruc = "A";
				rptaEmpresaDC.deuda_financiera = montoMayor;

				oHeader = null;
				oDataSet = null;

				oEvaluacionCliente = null;
				oDatosCliente = null;
				// FIN SERVICIO 50
				#endregion

				#region INICIO SERVICIO 53
				// INICIO SERVICIO 53
				ArrayList ListaHistDCRepresentanteLegal = new ArrayList();
				
				if (p_datacredito.istrTipoPersona.Equals("J"))
				{
					objHistorialDataCreditoCorp.ws53_In_TipoServicio = _ServsDc[2].ToString();
					objHistorialDataCreditoCorp.ws53_In_NumeroOperacion = strNroOperacion;
				
					System.Xml.XmlDocument oXMLDocument53 = new System.Xml.XmlDocument();
					oXMLDocument53.LoadXml(strRpta53);

					oDataSet = new DataSet();
					oDataSet.ReadXml(new System.Xml.XmlNodeReader(oXMLDocument53));				

					DataTable oDatosRRLL = new DataTable();

					if (oDataSet.Tables.Count>0)
					{
						for(int i=0;i<oDataSet.Tables.Count;i++)
						{
							switch(oDataSet.Tables[i].TableName.ToUpper())
							{
								case "HEADER":
									oHeader = oDataSet.Tables[i];
									break;
								case "REPRESENTANTELEGAL":
									oDatosRRLL = oDataSet.Tables[i];
									break;
							}
						}
					}
					if (oHeader.Rows.Count > 0)
					{	
						strCodigoRetorno = oHeader.Rows[0]["CodigoRetorno"].ToString();
						strNroOperacionws53 = oHeader.Rows[0]["NumeroOperacion"].ToString();

						objHistorialDataCreditoCorp.ws53_Out_Header_Transaccion = oHeader.Rows[0]["Transaccion"].ToString();
						objHistorialDataCreditoCorp.ws53_Out_Header_TipoServicio = _ServsDc[2].ToString();
					
						objHistorialDataCreditoCorp.ws53_Out_Header_CodigoRetorno = strCodigoRetorno;
						objHistorialDataCreditoCorp.ws53_Out_Header_NumeroOperacion = strNroOperacionws53;

						if (strCodigoRetorno != ConfigurationSettings.AppSettings["DcCorpCodigoRetornoOk"])
						{	
							rptaEmpresaDC.strCodRetorno = strCodigoRetorno;
							rptaEmpresaDC.strNroOperacion = strNroOperacion;
							rptaEmpresaDC.strRazonSocial = strRazonSocial;
							rptaEmpresaDC.strRiesgo = strRiesgo;
							rptaEmpresaDC.strNombres = p_datacredito.istrNombres;
							rptaEmpresaDC.strApellidoPaterno = p_datacredito.istrApellidoPaterno;
							rptaEmpresaDC.strApellidoMaterno = p_datacredito.istrApellidoMaterno;
							rptaEmpresaDC.strFlagInterno = "3";

							rptaEmpresaDC.ListaRepresentanteLegal = ListaRepresentanteLegal;
						
							mensaje = "Error Consulta DataCredito Servicio 53";
							return rptaEmpresaDC;
						}
					}

					string strTipoDocumentoRRLL,strNumeroDocumentoRRLL,strCargo,strNombreCompletoRRLL,strNombre,strApePaterno,strApeMaterno;
					string[] arrNombre;
				
					if (oDatosRRLL.Rows.Count > 0)
					{
						for(int i=0;i<oDatosRRLL.Rows.Count;i++)
						{
							strTipoDocumentoRRLL = oDatosRRLL.Rows[i]["TipoDocumento"].ToString();
							strNumeroDocumentoRRLL = oDatosRRLL.Rows[i]["NumeroDocumento"].ToString();
							strCargo = oDatosRRLL.Rows[i]["Cargo"].ToString();
							strNombreCompletoRRLL = oDatosRRLL.Rows[i]["NombresRazonSocial"].ToString();
							arrNombre = strNombreCompletoRRLL.Split(' ');
							strApePaterno = "";
							strApeMaterno = "";
							strNombre = "";
							if (arrNombre.Length == 3)
							{
								strApePaterno = arrNombre[0];
								strApeMaterno = arrNombre[1];
								strNombre = arrNombre[2];
							}
							else
							{
								if (arrNombre.Length > 3)
								{
									strApePaterno = arrNombre[0];
									strApeMaterno = arrNombre[1];
									strNombre = "";
									for (int z=2;z<arrNombre.Length;z++)
									{
										strNombre = strNombre.Trim() + " " + arrNombre[z];
									}
									strNombre = strNombre.Trim();
								}
							}
							RepresentanteLegal oRepresentanteLegal = new RepresentanteLegal();						
							oRepresentanteLegal.APODC_TIP_DOC_REP = strTipoDocumentoRRLL.Trim().ToUpper(); 
							oRepresentanteLegal.APODV_NUM_DOC_REP = strNumeroDocumentoRRLL.Trim().ToUpper();
							oRepresentanteLegal.APODV_APA_REP_LEG = strApePaterno.Trim().ToUpper();
							oRepresentanteLegal.APODV_AMA_REP_LEG = strApeMaterno.Trim().ToUpper();
							oRepresentanteLegal.APODV_NOM_REP_LEG = strNombre.Trim().ToUpper();
							oRepresentanteLegal.APODV_CAR_REP = strCargo.Trim().ToUpper();						

							ListaRepresentanteLegal.Add(oRepresentanteLegal);

							HistorialDataCreditoRepLegCorp objHistorialDataCreditoRepLegCorp = new HistorialDataCreditoRepLegCorp();
							objHistorialDataCreditoRepLegCorp.ws53_In_NumeroOperacionRepLeg = strNroOperacion;
							objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalTipoPersona = oDatosRRLL.Rows[i]["TipoPersona"].ToString();
							objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalTipoDocumento = strTipoDocumentoRRLL;
							objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalNumeroDocumento = strNumeroDocumentoRRLL;
							objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalNombre = strNombreCompletoRRLL;
							objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalCargo = strCargo;

							ListaHistDCRepresentanteLegal.Add(objHistorialDataCreditoRepLegCorp);
						}					
					}	
				}
				else
				{
					string nroDocumentoDNI = p_datacredito.istrNumeroDocumento.Substring(2,8);
					RepresentanteLegal oRepresentanteLegal = new RepresentanteLegal();
					oRepresentanteLegal.APODC_TIP_DOC_REP = ConfigurationSettings.AppSettings["DcCorpTipoDocDNI"].ToString();
					oRepresentanteLegal.APODV_NUM_DOC_REP = nroDocumentoDNI;
					// T12618 - Considerar nombres y apellidos retornados por DC - INICIO
					
					oRepresentanteLegal.APODV_APA_REP_LEG = objHistorialDataCreditoCorp.ws12_In_ApellidoPaterno;
					oRepresentanteLegal.APODV_AMA_REP_LEG = objHistorialDataCreditoCorp.ws12_In_ApellidoMaterno;
					oRepresentanteLegal.APODV_NOM_REP_LEG = objHistorialDataCreditoCorp.ws12_In_Nombres;
					// T12618 - Considerar nombres y apellidos retornados por DC - FIN
					oRepresentanteLegal.APODV_CAR_REP = ConfigurationSettings.AppSettings["DcCorpCargoRUC10"];

					ListaRepresentanteLegal.Add(oRepresentanteLegal);

					HistorialDataCreditoRepLegCorp objHistorialDataCreditoRepLegCorp = new HistorialDataCreditoRepLegCorp();
					objHistorialDataCreditoRepLegCorp.ws53_In_NumeroOperacionRepLeg = strNroOperacion;
					objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalTipoPersona = p_datacredito.istrTipoPersona;
					objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalTipoDocumento = ConfigurationSettings.AppSettings["DcCorpTipoDocDNI"].ToString();
					objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalNumeroDocumento = nroDocumentoDNI;
					objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalNombre = objHistorialDataCreditoCorp.ws12_In_ApellidoPaterno + " " + objHistorialDataCreditoCorp.ws12_In_ApellidoMaterno + " " + objHistorialDataCreditoCorp.ws12_In_Nombres;
					objHistorialDataCreditoRepLegCorp.ws53_Out_RepresentanteLegalCargo = ConfigurationSettings.AppSettings["DcCorpCargoRUC10"];

					ListaHistDCRepresentanteLegal.Add(objHistorialDataCreditoRepLegCorp);
				}

				oHeader = null;
				oDataSet = null;
				// FIN SERVICIO 53
				#endregion

				// Llenando los datos del cliente
				rptaEmpresaDC.strFlagInterno = "0";
				rptaEmpresaDC.strCodRetorno = strCodigoRetorno;
				rptaEmpresaDC.strNroOperacion = strNroOperacion;
				rptaEmpresaDC.strRazonSocial = strRazonSocial;
				rptaEmpresaDC.strRiesgo = strRiesgo;
				rptaEmpresaDC.strNombres = p_datacredito.istrNombres;
				rptaEmpresaDC.strApellidoPaterno = p_datacredito.istrApellidoPaterno;
				rptaEmpresaDC.strApellidoMaterno = p_datacredito.istrApellidoMaterno;
				String buroConsultado = _response.buroConsultado;
				rptaEmpresaDC.buro_consultado = Convert.ToInt32(_response.buroConsultado);
				rptaEmpresaDC.ListaRepresentanteLegal = ListaRepresentanteLegal;
				rptaEmpresaDC.strMensaje = "";

				HelperLog.EscribirLog("", nameArchivo, "mensaje: " + mensaje, false);

				//Salida del Servicio
				HelperLog.EscribirLog("", nameLogsc, "------------- Inicio: Salida del Servicio buro -------------", false);
				string param1 = "";
				param1 = param1 + rptaEmpresaDC.strFlagInterno + "|";
				param1 = param1 + rptaEmpresaDC.strCodRetorno + "|";
				param1 = param1 + rptaEmpresaDC.strNroOperacion + "|";
				param1 = param1 + rptaEmpresaDC.strRazonSocial + "|";
				param1 = param1 + rptaEmpresaDC.strRiesgo + "|";
				param1 = param1 + rptaEmpresaDC.strNombres + "|";
				param1 = param1 + rptaEmpresaDC.strApellidoPaterno + "|";
				param1 = param1 + rptaEmpresaDC.strApellidoMaterno + "|";
				param1 = param1 + rptaEmpresaDC.buro_consultado + "|";
				param1 = param1 + buroConsultado + "|";
				param1 = param1 + "EbsCreditosWS:EvaluarCredito" + "|";
				HelperLog.EscribirLog("", nameLogsc, "param1: " + param1, false);
				HelperLog.EscribirLog("", nameLogsc, "------------- Fin: Salida del Servicio buro -------------", false);
			}
			catch(Exception ex)
			{
				rptaEmpresaDC = null;
				HelperLog.EscribirLog("", nameLogsc, "ERROR WSBM: " + ex.Message, false);
				mensaje = "Error en la información enviada por EbsCreditosWS. Comunicarse con Créditos y Activaciones.";
			}
			return rptaEmpresaDC;
		}

		//FIN
	}
}
