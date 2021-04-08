using System;
using System.Data;
using System.Collections;
using System.Configuration; 
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Text;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for HistorialDCDatos.
	/// </summary>
	public class HistorialDCDatos
	{
		public HistorialDCDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//PROY-24740
		public HistorialDataCreditoCorp obtenerHistorialDCCorp(DataCreditoCorpIN p_datacredito)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_RUC",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_SEC",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_HISTORIAL_DC", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_HISTORIAL_REPLEG", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = p_datacredito.istrTipoDocumento.Substring(p_datacredito.istrTipoDocumento.Length - 1, 1);
			arrParam[1].Value = p_datacredito.istrNumeroDocumento;
			arrParam[2].Value = p_datacredito.istrTipoSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			string[] sTab = {"historico","representantes"}; 
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_HISTORICO_DC + ".SPS_OBTENER_HISTORICO_DC_CORP";
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr=null;			
			HistorialDataCreditoCorp objConsultaHistorialDataCreditoCorp = new HistorialDataCreditoCorp();
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				
				while( dr.Read())
				{					
					objConsultaHistorialDataCreditoCorp.ws53_Out_Header_CodigoRetorno = Funciones.CheckStr(dr["COD_RETORNO"]);
					objConsultaHistorialDataCreditoCorp.ws12_Out_Header_NumeroOperacion = Funciones.CheckStr(dr["NUM_OPERACION"]);
					objConsultaHistorialDataCreditoCorp.ws50_Out_GrupoIntegrantes_IntegranteNombres = Funciones.CheckStr(dr["RAZON_SOCIAL"]);
					objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_Accion = Funciones.CheckStr(dr["RIESGO"]);
					objConsultaHistorialDataCreditoCorp.ws12_In_Nombres = Funciones.CheckStr(dr["NOMBRES"]);
					objConsultaHistorialDataCreditoCorp.ws12_In_ApellidoPaterno = Funciones.CheckStr(dr["APE_PAT"]);
					objConsultaHistorialDataCreditoCorp.ws12_In_ApellidoMaterno = Funciones.CheckStr(dr["APE_MAT"]);
					objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngTarjeta = Funciones.CheckStr(dr["MSG_ING_TAR"]);
					objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDHipotecaria = Funciones.CheckStr(dr["MSG_ING_DHIP"]);
					objConsultaHistorialDataCreditoCorp.ws50_Out_CampoValor_MsgIngDnHipoTarjeta = Funciones.CheckStr(dr["MSG_ING_DNHIPO_TAR"]);
					objConsultaHistorialDataCreditoCorp.buro_consultado = Funciones.CheckInt(dr["BURO_CREDITICIO"]); //PROY-20054-IDEA-23849
				}

				// Para los representantes legal
				dr.NextResult();
				ArrayList ListaRepresentanteLegal = new ArrayList();

				string strNombreCompletoRRLL = "";
				string strApePaterno = "";
				string strApeMaterno = "";
				string strNombre = "";
				string[] arrNombre;
					
				while(dr.Read())
				{
					RepresentanteLegal oRepresentanteLegal = new RepresentanteLegal();						
					oRepresentanteLegal.APODC_TIP_DOC_REP = Funciones.CheckStr(dr["TIPO_DOCUMENTO"]);
					oRepresentanteLegal.APODV_NUM_DOC_REP = Funciones.CheckStr(dr["NUMERO_DOCUMENTO"]);

					strNombreCompletoRRLL = Funciones.CheckStr(dr["NOMBRES"]);
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
							StringBuilder sblNombre = new StringBuilder();
							for (int z=2;z<arrNombre.Length;z++)
							{
								sblNombre.AppendFormat("{0} ", arrNombre[z]);
							}
							strNombre = sblNombre.ToString().Trim();
						}
					}

					oRepresentanteLegal.APODV_APA_REP_LEG = strApePaterno;
					oRepresentanteLegal.APODV_AMA_REP_LEG = strApeMaterno;
					oRepresentanteLegal.APODV_NOM_REP_LEG = strNombre;
					oRepresentanteLegal.APODV_CAR_REP = Funciones.CheckStr(dr["CARGO"]);
					ListaRepresentanteLegal.Add(oRepresentanteLegal);
				}				
				objConsultaHistorialDataCreditoCorp.RepresentantesLegales = ListaRepresentanteLegal;
			}
			finally
			{				
				if (dr!=null && dr.IsClosed==false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return objConsultaHistorialDataCreditoCorp;
		}

		public bool grabarConsultaDCCorp(HistorialDataCreditoCorp item, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_WS12_IN_TIPDOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_IN_NUMDOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_IN_APEPAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_IN_APEMAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_IN_NOM", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_IN_TIPPER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_IN_TIPSER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_OUT_HEADER_TRA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_OUT_HEADER_TIPSER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_OUT_HEADER_CODRET", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_OUT_HEADER_NUMOPE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_OUT_ERROR_CODMEN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS12_OUT_ERROR_MEN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_IN_TIPSER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_IN_NUMOPE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_HEADER_TRA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_HEADER_TIPSER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_HEADER_CODRET", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_HEADER_NUMOPE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_GI_INTTIPDOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_GI_INTNUMDOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_GI_INTNOM", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CN_ACCION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CECAMPO_ACCION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CV_ACCION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CN_MSGINGTAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CEC_MSGINGTAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CV_MSGINGTAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CN_MSGINGDHIP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CEC_MSGINGDHIP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CV_MSGINGDHIP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CN_MSGINGDNHIPOTAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CEC_MSGINGDNHIPOTAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CV_MSGINGDNHIPOTAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CN_EXP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CEC_EXP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CV_EXP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CN_EXPAUX", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CEC_EXPAUX", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS50_OUT_CV_EXPAUX", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_IN_TIPSER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_IN_NUMOPE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_HEADER_TRA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_HEADER_TIPSER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_HEADER_CODRET", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_HEADER_NUMOPE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BURO_CREDITICIO", DbType.Int64, ParameterDirection.Input) // ADD PROY-20054-IDEA-23849
			};
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = item.ws12_In_TipoDocumento;
			++i; arrParam[i].Value = item.ws12_In_NumeroDocumento;
			++i; if(!Funciones.CheckStr(item.ws12_In_ApellidoPaterno).Equals("")) arrParam[i].Value = item.ws12_In_ApellidoPaterno;
			++i; if(!Funciones.CheckStr(item.ws12_In_ApellidoMaterno).Equals("")) arrParam[i].Value = item.ws12_In_ApellidoMaterno;
			++i; if(!Funciones.CheckStr(item.ws12_In_Nombres).Equals("")) arrParam[i].Value = item.ws12_In_Nombres;
			++i; arrParam[i].Value = item.ws12_In_TipoPersona;
			++i; arrParam[i].Value = item.ws12_In_TipoServicio;
			++i; arrParam[i].Value = item.ws12_Out_Header_Transaccion;
			++i; arrParam[i].Value = item.ws12_Out_Header_TipoServicio;
			++i; arrParam[i].Value = item.ws12_Out_Header_CodigoRetorno;
			++i; arrParam[i].Value = item.ws12_Out_Header_NumeroOperacion;
			++i; arrParam[i].Value = item.ws12_Out_Error_CodigoMensajes;
			++i; arrParam[i].Value = item.ws12_Out_Error_Mensaje;
			++i; arrParam[i].Value = item.ws50_In_TipoServicio;
			++i; arrParam[i].Value = item.ws50_In_NumeroOperacion;
			++i; arrParam[i].Value = item.ws50_Out_Header_Transaccion;
			++i; arrParam[i].Value = item.ws50_Out_Header_TipoServicio;
			++i; arrParam[i].Value = item.ws50_Out_Header_CodigoRetorno;
			++i; arrParam[i].Value = item.ws50_Out_Header_NumeroOperacion;
			++i; arrParam[i].Value = item.ws50_Out_GrupoIntegrantes_IntegranteTipoDocumento;
			++i; arrParam[i].Value = item.ws50_Out_GrupoIntegrantes_IntegranteNumeroDocumento;
			++i; arrParam[i].Value = item.ws50_Out_GrupoIntegrantes_IntegranteNombres;
			++i; arrParam[i].Value = item.ws50_Out_CampoNombre_Accion;
			++i; arrParam[i].Value = item.ws50_Out_CampoExisteCampo_Accion;
			++i; arrParam[i].Value = item.ws50_Out_CampoValor_Accion;
			++i; arrParam[i].Value = item.ws50_Out_CampoNombre_MsgIngTarjeta;
			++i; arrParam[i].Value = item.ws50_Out_CampoExisteCampo_MsgIngTarjeta;
			++i; arrParam[i].Value = item.ws50_Out_CampoValor_MsgIngTarjeta;
			++i; arrParam[i].Value = item.ws50_Out_CampoNombre_MsgIngDHipotecaria;
			++i; arrParam[i].Value = item.ws50_Out_CampoExisteCampo_MsgIngDHipotecaria;
			++i; arrParam[i].Value = item.ws50_Out_CampoValor_MsgIngDHipotecaria;
			++i; arrParam[i].Value = item.ws50_Out_CampoNombre_MsgIngDnHipoTarjeta;
			++i; arrParam[i].Value = item.ws50_Out_CampoExisteCampo_MsgIngDnHipoTarjeta;
			++i; arrParam[i].Value = item.ws50_Out_CampoValor_MsgIngDnHipoTarjeta;
			++i; arrParam[i].Value = item.ws50_Out_CampoNombre_Explicacion;
			++i; arrParam[i].Value = item.ws50_Out_CampoExisteCampo_Explicacion;
			++i; arrParam[i].Value = item.ws50_Out_CampoValor_Explicacion;
			++i; arrParam[i].Value = item.ws50_Out_CampoNombre_ExplicacionAuxiliar;
			++i; arrParam[i].Value = item.ws50_Out_CampoExisteCampo_ExplicacionAuxiliar;
			++i; arrParam[i].Value = item.ws50_Out_CampoValor_ExplicacionAuxiliar;
			++i; arrParam[i].Value = item.ws53_In_TipoServicio;
			++i; arrParam[i].Value = item.ws53_In_NumeroOperacion;
			++i; arrParam[i].Value = item.ws53_Out_Header_Transaccion;
			++i; arrParam[i].Value = item.ws53_Out_Header_TipoServicio;
			++i; arrParam[i].Value = item.ws53_Out_Header_CodigoRetorno;
			++i; arrParam[i].Value = item.ws53_Out_Header_NumeroOperacion;
			++i; arrParam[i].Value = item.buro_consultado; // ADD PROY-20054-IDEA-23849
												
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_HISTORICO_DC + ".SPI_GRABAR_HISTORICO_DC_CORP";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				
				for (int j = 0; j < item.RepresentantesLegales.Count; j++)
				{
					if (!grabarConsultaDCCorpRepresentantesLegales((HistorialDataCreditoRepLegCorp)item.RepresentantesLegales[j], ref rMsg))
					{	
						obRequest.Factory.RollBackTransaction();
						return salida;
					}
				}
				
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Historial de Consulta a Data Crédito Corp. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}

			return salida ;
		}	
	
		public bool grabarConsultaDCCorpRepresentantesLegales(HistorialDataCreditoRepLegCorp item, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_WS12_IN_NUMOPE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_RL_TIPPER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_RL_TIPDOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_RL_NUMDOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_RL_NOM", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WS53_OUT_RL_CAR", DbType.String, ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = item.ws53_In_NumeroOperacionRepLeg;
			++i; arrParam[i].Value = item.ws53_Out_RepresentanteLegalTipoPersona;
			++i; arrParam[i].Value = item.ws53_Out_RepresentanteLegalTipoDocumento;
			++i; arrParam[i].Value = item.ws53_Out_RepresentanteLegalNumeroDocumento;
			++i; arrParam[i].Value = item.ws53_Out_RepresentanteLegalNombre;
			++i; arrParam[i].Value = item.ws53_Out_RepresentanteLegalCargo;
												
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_HISTORICO_DC + ".SPI_GRABAR_HIST_DC_RL_CORP";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Historial de Representantes Legales de Data Crédito Corp. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}

			return salida ;
		}



	}
}
