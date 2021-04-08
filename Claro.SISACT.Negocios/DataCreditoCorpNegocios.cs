using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;
using Claro.SisAct.Datos;
using Claro.SisAct.Configuracion;

namespace Claro.SisAct.Negocios
{
	// <summary>
	// Summary description for DataCreditoCorpNegocios.
	// </summary>
	public class DataCreditoCorpNegocios
	{
		string _Key;
		string _User;
		string _Pasw;
		string _ModeloDc;
		string[] _ServsDc = new string[4];

		public EmpresaExperto ConsultaBuroCrediticio(DataCreditoCorpIN p_datacredito, string user, out string mensaje, 
			string nombreHost, string nombreServer, string ipServer, string ipcliente)
		{
			EmpresaExperto rptaBuro = null;
			mensaje = string.Empty;

			string strUrl = string.Empty;
			string strDocumento = ConfigurationSettings.AppSettings["constCodTipoDocumentoRUC"];
			string idBuro = new SolicitudNegocios().AsignarBuroCrediticio(strDocumento, ref strUrl, ref _Key);

			// Consulta Buro DataCredito
			if (idBuro == ConfigurationSettings.AppSettings["constCodBuroDataCreditoRUC"])
			{
				DataCreditoCorp.ServicioClaroCorporativo _DataCreditoCorp = new DataCreditoCorp.ServicioClaroCorporativo();

				// DataCredito Contingencia
				if(ObtenerParamDC_Contingencia().Equals("1"))
				{
					_DataCreditoCorp.Url = ConfigurationSettings.AppSettings["RutaWS_DcCorp_Cont"].ToString();
				}
				else
				{
					_DataCreditoCorp.Url = strUrl;
				}	

				//PROY-24740
				Claro.SisAct.Configuracion.ConfigConexionDC  oConfigConexionDC = Claro.SisAct.Configuracion.ConfigConexionDC .GetInstance(_Key);
				_User = oConfigConexionDC.Parametros.Usuario;
				_Pasw=oConfigConexionDC.Parametros.Password;

				_ModeloDc = ConfigurationSettings.AppSettings["DcCorpModelo"];
				_ServsDc[0] = ConfigurationSettings.AppSettings["DcCorpServicio12"];
				_ServsDc[1] = ConfigurationSettings.AppSettings["DcCorpServicio50"];
				_ServsDc[2] = ConfigurationSettings.AppSettings["DcCorpServicio53"];
				_ServsDc[3] = "";

				rptaBuro = ConsultaDataCredito(_DataCreditoCorp, p_datacredito, user, out mensaje, nombreHost, nombreServer, ipServer, ipcliente);
			}

			return rptaBuro;
		}

		public EmpresaExperto ConsultaDataCredito(DataCreditoCorp.ServicioClaroCorporativo _DataCreditoCorp, DataCreditoCorpIN p_datacredito, 
			string user, out string mensaje, string nombreHost, string nombreServer, string ipServer, string ipcliente)
		{
			EmpresaExperto rptaEmpresaDC = null;
			rptaEmpresaDC = new EmpresaExperto();
			rptaEmpresaDC.strFlagInterno = string.Empty;
			mensaje = string.Empty;
			
			string nameArchivo = "LogWSDrools";	
			
			// Evaluar si hay datos en la BD y si hay devolver esos resultados a capa presentacion
			HistorialDCDatos objHistorialDCDatos = new HistorialDCDatos();
			HistorialDataCreditoCorp objConsultaHistorialDataCreditoCorp = new HistorialDataCreditoCorp();
			objConsultaHistorialDataCreditoCorp = objHistorialDCDatos.obtenerHistorialDCCorp(p_datacredito);

			HistorialDataCreditoCorp objHistorialDataCreditoCorp = new HistorialDataCreditoCorp();
			ArrayList ListaRepresentanteLegal = new ArrayList();

			rptaEmpresaDC.origen_experto = "DC";

			if (objConsultaHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion.Equals(""))
			{
				try
				{
					// Declarando las variables que serán usadas para la obtención de datos
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

					string rptaReturn = _DataCreditoCorp.metodosReturn(p_datacredito.istrTipoDocumento, p_datacredito.istrNumeroDocumento, p_datacredito.istrApellidoPaterno, p_datacredito.istrApellidoMaterno, p_datacredito.istrNombres, p_datacredito.istrTipoPersona, _User, _Pasw, _ModeloDc);

					string strRpta12 = System.Text.RegularExpressions.Regex.Split(rptaReturn,"RespuestaSVC12>")[1];
					strRpta12 = strRpta12.Substring(0,strRpta12.Length-2);
					strRpta12 = "<RespuestaSVC12>" + strRpta12 + "</RespuestaSVC12>";
					string strRpta50 = System.Text.RegularExpressions.Regex.Split(rptaReturn,"RespuestaSVC50>")[1];
					strRpta50 = strRpta50.Substring(0,strRpta50.Length-2);
					strRpta50 = "<RespuestaSVC50>" + strRpta50 + "</RespuestaSVC50>";
					string strRpta53 = System.Text.RegularExpressions.Regex.Split(rptaReturn,"RespuestaSVC53>")[1];
					strRpta53 = strRpta53.Substring(0,strRpta53.Length-2);
					strRpta53 = "<RespuestaSVC53>" + strRpta53 + "</RespuestaSVC53>";

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

					// Llenando los datos del cliente
					rptaEmpresaDC.strFlagInterno = "0";

					rptaEmpresaDC.strCodRetorno = strCodigoRetorno;
					rptaEmpresaDC.strNroOperacion = strNroOperacion;
					rptaEmpresaDC.strRazonSocial = strRazonSocial;
					rptaEmpresaDC.strRiesgo = strRiesgo;
					rptaEmpresaDC.strNombres = p_datacredito.istrNombres;
					rptaEmpresaDC.strApellidoPaterno = p_datacredito.istrApellidoPaterno;
					rptaEmpresaDC.strApellidoMaterno = p_datacredito.istrApellidoMaterno;

					rptaEmpresaDC.ListaRepresentanteLegal = ListaRepresentanteLegal;
					rptaEmpresaDC.strMensaje = "";

					objHistorialDataCreditoCorp.RepresentantesLegales = ListaHistDCRepresentanteLegal;

					// T12618 - INPUT/OUTPUT - Inicio

					DataCredito_Input_Output bean = new DataCredito_Input_Output();
					bean.IODCV_NUM_OPERACION = objHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion;
					
					string paramEntradas = objHistorialDataCreditoCorp.ws12_In_TipoDocumento + "|" +
						objHistorialDataCreditoCorp.ws12_In_NumeroDocumento + "|" +
						p_datacredito.istrApellidoPaterno + "|" +
						p_datacredito.istrApellidoMaterno + "|" +
						p_datacredito.istrNombres + "|" +
						objHistorialDataCreditoCorp.ws12_In_TipoPersona + "|" +
						objHistorialDataCreditoCorp.ws12_In_TipoServicio;
										   
					string paramSalidas = objHistorialDataCreditoCorp.ws12_Out_Header_Transaccion + "|" +
						objHistorialDataCreditoCorp.ws12_Out_Header_TipoServicio + "|" +
						objHistorialDataCreditoCorp.ws12_Out_Header_CodigoRetorno + "|" +
						objHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion + "|" +
						objHistorialDataCreditoCorp.ws12_Out_Error_CodigoMensajes + "|" +
						objHistorialDataCreditoCorp.ws12_Out_Error_Mensaje;

					HelperLog.EscribirLog("", nameArchivo, "paramEntradas: " + paramEntradas, false);
					HelperLog.EscribirLog("", nameArchivo, "paramSalidas: " + paramSalidas, false);

					bean.IODCV_INPUT_VALORES = paramEntradas;
					bean.IODCV_OUTPUT_VALORES = paramSalidas;
					bean.IODCV_TIPO_DOCUMENTO = objHistorialDataCreditoCorp.ws12_In_TipoDocumento;
					bean.IODCV_NUM_DOCUMENTO = objHistorialDataCreditoCorp.ws12_In_NumeroDocumento;
					bean.IODCV_USUARIO_REGISTRO = user;
					bean.IODCV_COD_PUNTO_VENTA = p_datacredito.istrPuntoVenta; //PROY-20054-IDEA-23849
					bean.IODCC_RIESGO = objHistorialDataCreditoCorp.ws50_Out_CampoValor_Accion;
					bean.IODCC_RESPUESTA_DC = _ServsDc[0].ToString();
					RepresentanteLegal oRepresentanteLegalInOut = new RepresentanteLegal();
					if (ListaRepresentanteLegal != null && ListaRepresentanteLegal.Count != 0)
						oRepresentanteLegalInOut = (RepresentanteLegal)ListaRepresentanteLegal[0];

					if (p_datacredito.istrTipoPersona.Equals("J"))
					{
						bean.IODCV_APE_PATERNO = "";
						bean.IODCV_APE_MATERNO = "";

						string strRazonSocialDC = objHistorialDataCreditoCorp.ws50_Out_GrupoIntegrantes_IntegranteNombres.Trim().ToUpper();
						if (strRazonSocialDC.Length > 40)
						{
							strRazonSocialDC = strRazonSocialDC.Substring(0,40);
						}

						bean.IODCV_NOMBRES = strRazonSocialDC;
					}
					else
					{
						if (oRepresentanteLegalInOut != null)
						{
							bean.IODCV_APE_PATERNO = oRepresentanteLegalInOut.APODV_APA_REP_LEG;
							bean.IODCV_APE_MATERNO = oRepresentanteLegalInOut.APODV_AMA_REP_LEG;
							bean.IODCV_NOMBRES = oRepresentanteLegalInOut.APODV_NOM_REP_LEG;
						}
						else
						{
							bean.IODCV_APE_PATERNO = "";
							bean.IODCV_APE_MATERNO = "";
							bean.IODCV_NOMBRES = "";
						}
					}
					
					bean.IODCV_TIPO_SEC = p_datacredito.istrTipoSEC;

					bean.IODCC_TIPO_CLIENTE = "";
					bean.IODCC_FORMA_PAGO = "";
					bean.IODCC_TIPO_ACTIVACION = "";
					bean.IODCC_TIPO_CLIENTE = "";
					bean.IODCC_TIPO_VENTA = "";
					bean.IODCC_PLAZO_ACUERDO = "";
					bean.IODCC_PLAN1 = "";
					bean.IODCC_PLAN2 = "";
					bean.IODCC_PLAN3 = "";
					bean.IODCC_CONTROL_CONSUMO = "";
					bean.IODCC_FLAG_ESSALUD = "";
					bean.IODCC_FLAG_SUNAT = "";
					bean.IODCC_LIMITE_CREDITO = "";
					bean.IODCC_SCORE_TEXTO = "";
					bean.IODCC_SCORE_NUMERO = "";

					//INICIO: PROY-20054-IDEA-23849
					Int32 CODIGOBURO = Funciones.CheckInt(ConfigurationSettings.AppSettings["constCodBuroDataCreditoRUC"].ToString());
					objHistorialDataCreditoCorp.buro_consultado = CODIGOBURO;
					bean.IODCN_BURO_CREDITICIO = CODIGOBURO;
					rptaEmpresaDC.buro_consultado = CODIGOBURO;
					//FIN

					HelperLog.EscribirLog("", nameArchivo, "Insertar_DC_Parametros ", false);

					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_NUM_OPERACION, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_INPUT_VALORES, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_OUTPUT_VALORES, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_TIPO_DOCUMENTO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_NUM_DOCUMENTO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_USUARIO_REGISTRO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_COD_PUNTO_VENTA, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_FORMA_PAGO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_TIPO_ACTIVACION, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_TIPO_CLIENTE, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_TIPO_VENTA, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_PLAZO_ACUERDO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_PLAN1, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_PLAN2, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_PLAN3, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_CONTROL_CONSUMO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_FLAG_ESSALUD, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_FLAG_SUNAT, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_RIESGO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_LIMITE_CREDITO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_SCORE_TEXTO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_SCORE_NUMERO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_RESPUESTA_DC, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_APE_PATERNO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_APE_MATERNO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_NOMBRES, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCV_UBIGEO, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_TIPO_CLIENTE_DC, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_ESTADO_CIVIL_DC, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_ORIGEN_LC_DC, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_ANALISIS_DC, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_SCORE_RANKING_OPER_DC, false);
					HelperLog.EscribirLog("", nameArchivo, Funciones.CheckStr(bean.IODCN_PUNTAJE_DC), false);
					HelperLog.EscribirLog("", nameArchivo, Funciones.CheckStr(bean.IODCN_LC_DATA_CREDITO_DC), false);
					HelperLog.EscribirLog("", nameArchivo, Funciones.CheckStr(bean.IODCN_LC_BASE_EXTERNA_DC), false);
					HelperLog.EscribirLog("", nameArchivo, Funciones.CheckStr(bean.IODCN_LC_CLARO_DC), false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCC_RAZONES_DC, false);
					HelperLog.EscribirLog("", nameArchivo, bean.IODCD_FECHA_NACE_CLIENTE_DC, false);

					SolicitudDC_ReporteNegocio negocioReporte = new SolicitudDC_ReporteNegocio();
					HelperLog.EscribirLog("", nameArchivo, "metodo", false);
					negocioReporte.Insertar_DC_Parametros(bean);
					negocioReporte = null;

					// T12618 - INPUT/OUTPUT - Fin

					HelperLog.EscribirLog("", nameArchivo, "grabarConsultaDCCorp ", false);

					// Grabar el historial en BD el resultado de DC
					string mensajeRetorno = "";
					if (!objHistorialDCDatos.grabarConsultaDCCorp(objHistorialDataCreditoCorp, ref mensajeRetorno))
					{
						mensaje = "Error en grabar en BD Historial DC";
						return rptaEmpresaDC;
					}

					HelperLog.EscribirLog("", nameArchivo, "mensaje: " + mensaje, false);

					// T12618 - Auditoria Registro Histórico DC - INICIO
					string codTransaccion = ConfigurationSettings.AppSettings["DcAuditRegistroHistorialDCCorporativo"].ToString();
					string detalle = "Registro Tabla Corporativo Exitosa. (" + " " + objHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion + " " + objHistorialDataCreditoCorp.ws12_In_TipoDocumento + " " + objHistorialDataCreditoCorp.ws12_In_NumeroDocumento + " " + objHistorialDataCreditoCorp.ws50_Out_CampoValor_Accion + " " + objHistorialDataCreditoCorp.ws12_Out_Header_CodigoRetorno + " " + objHistorialDataCreditoCorp.ws50_Out_GrupoIntegrantes_IntegranteNombres + " " + p_datacredito.istrTipoSEC + ")";
					registrarAuditoriaHistoricoCorporativo(nombreHost, nombreServer, ipServer, user, ipcliente, detalle, codTransaccion);
					// T12618 - Auditoria Registro Histórico DC - FIN

				}
				catch(Exception e)
				{
					mensaje = e.Message;
					rptaEmpresaDC.strMensaje = e.Message;

					HelperLog.EscribirLog("", nameArchivo, "Exception: " + mensaje, false);
				}
			}
			else
			{
				// Se evalúan los campos de estado_ruc y deuda_financiera tal y como se realiza cuando se hace la consulta a DC
				rptaEmpresaDC.origen_experto = "BD";
				if (objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_Accion.Equals("5"))
					rptaEmpresaDC.estado_ruc = "B";
				else
					rptaEmpresaDC.estado_ruc = "A";

				double monto1 = 0;
				double monto2 = 0;
				double monto3 = 0;
				if (Funciones.isNumeric(objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngTarjeta)) monto1 = Funciones.CheckDbl(objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngTarjeta);
				if (Funciones.isNumeric(objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDHipotecaria)) monto2 = Funciones.CheckDbl(objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDHipotecaria);
				if (Funciones.isNumeric(objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDnHipoTarjeta)) monto3 = Funciones.CheckDbl(objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDnHipoTarjeta);
				// Por regla se toma el Monto Mayor
				double montoMayor = monto1;
				if (monto2>montoMayor) montoMayor = monto2;
				if (monto3>montoMayor) montoMayor = monto3;
				rptaEmpresaDC.deuda_financiera = montoMayor;

				// Campos traídos de la BD
				rptaEmpresaDC.strCodRetorno = objConsultaHistorialDataCreditoCorp.ws53_Out_Header_CodigoRetorno;
				rptaEmpresaDC.strNroOperacion = objConsultaHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion;
				rptaEmpresaDC.strRazonSocial = objConsultaHistorialDataCreditoCorp.ws50_Out_GrupoIntegrantes_IntegranteNombres;
				rptaEmpresaDC.strRiesgo = objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_Accion;
				rptaEmpresaDC.strNombres = p_datacredito.istrNombres;
				rptaEmpresaDC.strApellidoPaterno = p_datacredito.istrApellidoPaterno;
				rptaEmpresaDC.strApellidoMaterno = p_datacredito.istrApellidoMaterno;
				
				// Traes de la segunda tabla
				rptaEmpresaDC.ListaRepresentanteLegal = objConsultaHistorialDataCreditoCorp.RepresentantesLegales;

				// Siempre el mismo valor, 0 y vacío cuando es correcto
				rptaEmpresaDC.strFlagInterno = "0";
				rptaEmpresaDC.strMensaje = "";

				rptaEmpresaDC.buro_consultado = objConsultaHistorialDataCreditoCorp.buro_consultado; //ADD PROY-20054-IDEA-23849

				// T12618 - Auditoria Consulta Histórico DC - INICIO
				//string codTransaccion = ConfigurationSettings.AppSettings["DcAuditConsultaHistorialDCCorporativo"].ToString();
				//string detalle = "Consulta Tabla Corporativo Exitosa. (" + objConsultaHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion + " " + objConsultaHistorialDataCreditoCorp.ws12_In_TipoDocumento + " " + objConsultaHistorialDataCreditoCorp.ws12_In_NumeroDocumento + " " + p_datacredito.istrTipoSEC + ")";
				//registrarAuditoriaHistoricoCorporativo(nombreHost, nombreServer, ipServer, user, ipcliente, detalle, codTransaccion);
				// T12618 - Auditoria Consulta Histórico DC - FIN
			}
			return rptaEmpresaDC;
		}

		public string ObtenerParamDC_Contingencia()
		{
			int iCodParametro = Funciones.CheckInt(ConfigurationSettings.AppSettings["consCodParametro_DC_Contingencia"]);
			MantMaestroNegocio obj = new MantMaestroNegocio();
			return obj.ObtenerValorContingenciaDC(iCodParametro);
		}

		private void registrarAuditoriaHistoricoCorporativo(string nombreHost, string nombreServer, string ipServer, string usuario_id, string ipcliente, string detalle, string strCodTrans)
		{
			try
			{
				string strCodAplica = ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString();
				string strCodServ = ConfigurationSettings.AppSettings["CONS_COD_SACT_SERV"].ToString();
				int flagAuditoria = Convert.ToInt32(ConfigurationSettings.AppSettings["CONS_COD_FLAG_AUDIT"]);

				if (flagAuditoria == 1)
				{
					bool rpta = false;
					string strRef = "0";
					rpta = new AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", ref strRef, ref detalle);
					if (!rpta)
						throw new Exception("Error. No se registro en Auditoria el registro en el Historial Corporativo de DC.");
				}
			}
			catch (Exception)
			{}
		}
	}
}
