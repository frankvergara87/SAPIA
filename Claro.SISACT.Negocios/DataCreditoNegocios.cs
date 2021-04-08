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
	public class DataCreditoNegocios
	{
		string _Key;
		string _User;
		string _Pasw;

		public DataCreditoNegocios()
		{
			
			 //TODO: Add constructor logic here
			
		}

		private string nameLogs = "LogWSDC";

		public bool ConsultaDataCreditoRepositorioLocal(DataCreditoIN p_datacredito, ref DataCreditoOUT ObjDataCreditoLocalOUT, ref string mensajeError, string tipoSEC, ref int iParametro)
		{				
			return new DataCreditoDatos().ConsultaDataCreditoRepositorioLocal(p_datacredito, ref ObjDataCreditoLocalOUT, ref mensajeError, tipoSEC, ref iParametro);
		}

		public DataCreditoOUT ConsultaDataCredito(DataCredito.ClaroServiceService _DataCredito, DataCreditoIN p_datacredito, out string mensaje)
		{
			DataCreditoOUT rptaDC = null;
			mensaje = string.Empty;
			try 
			{
				string param = "";
				param = param + p_datacredito.istrSecuencia + "|";
				param = param + p_datacredito.istrTipoDocumento + "|";
				param = param + p_datacredito.istrNumeroDocumento + "|";
				param = param + p_datacredito.istrAPELLIDOPATERNO.ToUpper() + "|";
				param = param + p_datacredito.istrAPELLIDOMATERNO.ToUpper() + "|";
				param = param + p_datacredito.istrNOMBRES.ToUpper() + "|";
				param = param + p_datacredito.istrDatoEntrada + "|";
				param = param + p_datacredito.istrDatoComplemento + "|";
				param = param + p_datacredito.istrTIPOPRODUCTO + "|";
				param = param + p_datacredito.istrTIPOCLIENTE + "|";
				param = param + p_datacredito.istrEDAD + "|";
				param = param + p_datacredito.istrIngresoOLineaCredito + "|";
				param = param + p_datacredito.istrTIPOTARJETA + "|";
				param = param + p_datacredito.istrRUC + "|";
				param = param + p_datacredito.istrANTIGUEDADLABORAL + "|";
				param = param + p_datacredito.istrNumOperaPVU + "|";
				param = param + p_datacredito.istrRegion + "|";
				param = param + p_datacredito.istrArea + "|";
				param = param + _User + "|";
				param = param + p_datacredito.istrPuntoVenta + "|";
				param = param + _Pasw + "|";
				param = param + p_datacredito.istrIDTerminal + "|";
				param = param + p_datacredito.istrUsuarioACC + "|";
				param = param + p_datacredito.ostrNumOperaEFT + "|";
				param = param + p_datacredito.istrNUMCUENTAS + "|";
				param = param + p_datacredito.strEstadoCivil + "|";
				param = param + "ConsultaDataCredito" + "|";

				HelperLog.EscribirLog("", nameLogs, "param: " + param, false);
				_DataCredito.Timeout = 5000;
				string strDataCreditoOUT = _DataCredito.ejecutarConsultaClaro(p_datacredito.istrSecuencia, p_datacredito.istrTipoDocumento,
					p_datacredito.istrNumeroDocumento, p_datacredito.istrAPELLIDOPATERNO.ToUpper(), p_datacredito.istrAPELLIDOMATERNO.ToUpper(),
					p_datacredito.istrNOMBRES.ToUpper(), p_datacredito.istrDatoEntrada, p_datacredito.istrDatoComplemento, p_datacredito.istrTIPOPRODUCTO,
					p_datacredito.istrTIPOCLIENTE, p_datacredito.istrEDAD, p_datacredito.istrIngresoOLineaCredito, p_datacredito.istrTIPOTARJETA,
					p_datacredito.istrRUC, p_datacredito.istrANTIGUEDADLABORAL, p_datacredito.istrNumOperaPVU, p_datacredito.istrRegion,
					p_datacredito.istrArea, _User, p_datacredito.istrPuntoVenta, _Pasw, p_datacredito.istrIDTerminal, p_datacredito.istrUsuarioACC,
					p_datacredito.ostrNumOperaEFT, p_datacredito.istrNUMCUENTAS, p_datacredito.strEstadoCivil);

				XmlNode XmlNodo;
				XmlDocument XmlDoc = new XmlDocument();
				XmlDoc.LoadXml(strDataCreditoOUT);

				XmlNodo = XmlDoc.DocumentElement;

				rptaDC = new DataCreditoOUT();
				rptaDC.CodigoBuro = ConfigurationSettings.AppSettings["constCodBuroDataCreditoDNI"];

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
					else if (atributo.Name.Equals("SCORE")) { rptaDC.SCORE = Funciones.CheckInt(atributo.Value); }
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
				HelperLog.EscribirLog("", nameLogs, "ERROR DC: " + ex.Message, false);
				mensaje = "Error en la información enviada por DataCredito. Comunicarse con Créditos y Activaciones.";
				//throw ex;
			}
			return rptaDC;
		}

		public DataCreditoOUT ConsultaBuroCrediticio(DataCreditoIN p_datacredito, out string mensaje)
		{
			DataCreditoOUT rptaDC = null;
			mensaje = string.Empty;

			string strUrl = string.Empty;
			string strDocumento = ConfigurationSettings.AppSettings["constCodTipoDocumentoDNICE"];
			string idBuro = new SolicitudNegocios().AsignarBuroCrediticio(strDocumento, ref strUrl, ref _Key);
			int i = 0;
			bool flgNext = false;

			while (i < 1) 
			{
				i = i + 1;

				//HelperLog.EscribirLog("", "LogWSDC.txt", "strUrl: " + strUrl, false);
				// Consulta Buro DataCredito
				if (idBuro == ConfigurationSettings.AppSettings["constCodBuroDataCreditoDNI"])
				{
					DataCredito.ClaroServiceService _DataCredito = new DataCredito.ClaroServiceService();
					_DataCredito.Url = strUrl;

					//PROY-24740
					Claro.SisAct.Configuracion.ConfigConexionDC  oConfigConexionDC = Claro.SisAct.Configuracion.ConfigConexionDC .GetInstance(_Key);
					_User = oConfigConexionDC.Parametros.Usuario;
					_Pasw=oConfigConexionDC.Parametros.Password;
					
					rptaDC = ConsultaDataCredito(_DataCredito, p_datacredito, out mensaje);
				}
				// Consulta Buro Equifax
				if (idBuro == ConfigurationSettings.AppSettings["constCodBuroEquifaxDNI"])
				{
					DataCredito.ClaroServiceService _DataCredito = new DataCredito.ClaroServiceService();
					_DataCredito.Url = strUrl;

					//PROY-24740
					Claro.SisAct.Configuracion.ConfigConexionDC  oConfigConexionDC = Claro.SisAct.Configuracion.ConfigConexionDC .GetInstance(_Key);
					_User = oConfigConexionDC.Parametros.Usuario;
					_Pasw=oConfigConexionDC.Parametros.Password;

					rptaDC = ConsultaEquifax(_DataCredito, p_datacredito, out mensaje);
				}

				if (rptaDC == null && !flgNext)
				{
					i = 0;
					flgNext = true;
					HelperLog.EscribirLog("", nameLogs, "Consulta Siguiente Buro", false);
					idBuro = new SolicitudNegocios().AsignarNextBuroCrediticio(strDocumento, idBuro, ref strUrl, ref _Key);
				}
			}
			return rptaDC;
		}

		public DataCreditoOUT ConsultaEquifax(DataCredito.ClaroServiceService _DataCredito, DataCreditoIN p_datacredito, out string mensaje)
		{
			DataCreditoOUT rptaDC = null;
			mensaje = string.Empty;
			try 
			{
				string param = "";
				param = param + p_datacredito.istrSecuencia + "|";
				param = param + p_datacredito.istrTipoDocumento + "|";
				param = param + p_datacredito.istrNumeroDocumento + "|";
				param = param + p_datacredito.istrAPELLIDOPATERNO.ToUpper() + "|";
				param = param + p_datacredito.istrAPELLIDOMATERNO.ToUpper() + "|";
				param = param + p_datacredito.istrNOMBRES.ToUpper() + "|";
				param = param + p_datacredito.istrDatoEntrada + "|";
				param = param + p_datacredito.istrDatoComplemento + "|";
				param = param + p_datacredito.istrTIPOPRODUCTO + "|";
				param = param + p_datacredito.istrTIPOCLIENTE + "|";
				param = param + p_datacredito.istrEDAD + "|";
				param = param + p_datacredito.istrIngresoOLineaCredito + "|";
				param = param + p_datacredito.istrTIPOTARJETA + "|";
				param = param + p_datacredito.istrRUC + "|";
				param = param + p_datacredito.istrANTIGUEDADLABORAL + "|";
				param = param + p_datacredito.istrNumOperaPVU + "|";
				param = param + p_datacredito.istrRegion + "|";
				param = param + p_datacredito.istrArea + "|";
				param = param + _User + "|";
				param = param + p_datacredito.istrPuntoVenta + "|";
				param = param + _Pasw + "|";
				param = param + p_datacredito.istrIDTerminal + "|";
				param = param + p_datacredito.istrUsuarioACC + "|";
				param = param + p_datacredito.ostrNumOperaEFT + "|";
				param = param + p_datacredito.istrNUMCUENTAS + "|";
				param = param + p_datacredito.strEstadoCivil + "|";
				param = param + "ConsultaEquifax" + "|";

				HelperLog.EscribirLog("", nameLogs, "param: " + param, false);

				string strDataCreditoOUT = _DataCredito.ejecutarConsultaClaro(p_datacredito.istrSecuencia, p_datacredito.istrTipoDocumento,
					p_datacredito.istrNumeroDocumento, p_datacredito.istrAPELLIDOPATERNO.ToUpper(), p_datacredito.istrAPELLIDOMATERNO.ToUpper(),
					p_datacredito.istrNOMBRES.ToUpper(), p_datacredito.istrDatoEntrada, p_datacredito.istrDatoComplemento, p_datacredito.istrTIPOPRODUCTO,
					p_datacredito.istrTIPOCLIENTE, p_datacredito.istrEDAD, p_datacredito.istrIngresoOLineaCredito, p_datacredito.istrTIPOTARJETA,
					p_datacredito.istrRUC, p_datacredito.istrANTIGUEDADLABORAL, p_datacredito.istrNumOperaPVU, p_datacredito.istrRegion,
					p_datacredito.istrArea, _User, p_datacredito.istrPuntoVenta, _Pasw, p_datacredito.istrIDTerminal, p_datacredito.istrUsuarioACC,
					p_datacredito.ostrNumOperaEFT, p_datacredito.istrNUMCUENTAS, p_datacredito.strEstadoCivil);

				XmlNode XmlNodo;
				XmlDocument XmlDoc = new XmlDocument();
				XmlDoc.LoadXml(strDataCreditoOUT);

				XmlNodo = XmlDoc.DocumentElement;

				rptaDC = new DataCreditoOUT();
				rptaDC.CodigoBuro = ConfigurationSettings.AppSettings["constCodBuroEquifaxDNI"];

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
					else if (atributo.Name.Equals("SCORE")) { rptaDC.SCORE = Funciones.CheckInt(atributo.Value); }
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
				HelperLog.EscribirLog("", nameLogs, "ERROR EQUIFAX: " + ex.Message, false);
				mensaje = "Error en la información enviada por DataCredito. Comunicarse con Créditos y Activaciones.";
				//throw ex;
			}
			return rptaDC;
		}
		public bool GuardarDatosDataCredito(DataCreditoIN oDataCreditoIN, DataCreditoOUT oDataCreditoOUT)
		{			
			return new DataCreditoDatos().GuardarDatosDataCredito(oDataCreditoIN, oDataCreditoOUT);
		}
	
	}
}
