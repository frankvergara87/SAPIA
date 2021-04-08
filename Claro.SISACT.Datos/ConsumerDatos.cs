using System;
using System.Configuration;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Text;
namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for ConsumerDatos.
	/// </summary>
	public class ConsumerDatos
	{
		public ConsumerDatos()
		{			
		}

		public SolicitudPersona DetalleEvaluacionNatural(string nroSEC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSS_DET_SOL_NAT";
			obRequest.Parameters.AddRange(arrParam);

			SolicitudPersona item = new SolicitudPersona();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					item.SOLIC_EXI_BSC_FIN = Funciones.CheckStr(dr["SOLIC_EXI_BSC_FIN"]);
					item.CANAC_CODIGO = Funciones.CheckStr(dr["CANAC_CODIGO"]);
					item.OVENC_CODIGO = Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.SOLIC_EXI_BSC_FIN = Funciones.CheckStr(dr["SOLIC_EXI_BSC_FIN"]);
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					item.TDOCC_CODIGO = Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);
					item.CLIEC_NUM_DOC = Funciones.NroDocumentoIdentidad(Funciones.CheckStr(dr["TDOCC_CODIGO"]),Funciones.CheckStr(dr["CLIEC_NUM_DOC"]));
					item.CLIEV_NOMBRE = Funciones.CheckStr(dr["CLIEV_NOMBRE"]);
					item.CLIEV_APE_PAT = Funciones.CheckStr(dr["CLIEV_APE_PAT"]);
					item.CLIEV_APE_MAT = Funciones.CheckStr(dr["CLIEV_APE_MAT"]);
					item.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					item.CCLIV_DESCRIPCION = Funciones.CheckStr(dr["CCLIV_DESCRIPCION"]);
					item.SOLIV_DES_TIP_ACT = Funciones.CheckStr(dr["SOLIV_DES_TIP_ACT"]);
					item.TVENV_DESCRIPCION = Funciones.CheckStr(dr["TVENV_DESCRIPCION"]);
					item.PLANV_DESCRIPCION1 = Funciones.CheckStr(dr["PLANV_DESCRIPCION1"]);
					item.PLANV_DESCRIPCION2 = Funciones.CheckStr(dr["PLANV_DESCRIPCION2"]);
					item.PLANV_DESCRIPCION3 = Funciones.CheckStr(dr["PLANV_DESCRIPCION3"]);
					item.PACUV_DESCRIPCION = Funciones.CheckStr(dr["PACUV_DESCRIPCION"]);
					item.FPAGV_DESCRIPCION = Funciones.CheckStr(dr["FPAGV_DESCRIPCION"]);
					item.SOLIN_CAN_LIN = Funciones.CheckStr(dr["SOLIN_CAN_LIN"]);
					item.SOLIC_EVA_SUN = Funciones.CheckStr(dr["SOLIC_EVA_SUN"]);
					item.SOLIC_EVA_ESS = Funciones.CheckStr(dr["SOLIC_EVA_ESS"]);
					item.CCLIC_CODIGO = Funciones.CheckStr(dr["CCLIC_CODIGO"]);
					item.RDIRC_CODIGO = Funciones.CheckStr(dr["RDIRC_CODIGO"]);
					item.RDIRV_DESCRIPCION = Funciones.CheckStr(dr["RDIRV_DESCRIPCION"]);
					item.MRDIV_CAD_CODIGO = Funciones.CheckStr(dr["MRDIV_CAD_CODIGO"]);
					item.TACTC_CODIGO = Funciones.CheckStr(dr["TACTC_CODIGO"]);
					item.CLIEV_PRE_DIR = Funciones.CheckStr(dr["CLIEV_PRE_DIR"]);
					item.CLIEV_DIRECCION = Funciones.CheckStr(dr["CLIEV_DIRECCION"]);
					item.CLIEV_REF_DIR = Funciones.CheckStr(dr["CLIEV_REF_DIR"]);
					item.CLIEC_COD_DEP_DIR = Funciones.CheckStr(dr["CLIEC_COD_DEP_DIR"]);
					item.CLIEC_COD_PRO_DIR = Funciones.CheckStr(dr["CLIEC_COD_PRO_DIR"]);
					item.CLIEC_COD_DIS_DIR = Funciones.CheckStr(dr["CLIEC_COD_DIS_DIR"]);
					item.CLIEC_COD_POS_DIR = Funciones.CheckStr(dr["CLIEC_COD_POS_DIR"]);
					item.CLIEV_PRE_DIR_TRA = Funciones.CheckStr(dr["CLIEV_PRE_DIR_TRA"]);
					item.CLIEV_DIR_TRA = Funciones.CheckStr(dr["CLIEV_DIR_TRA"]);
					item.CLIEV_REF_DIR_TRA = Funciones.CheckStr(dr["CLIEV_REF_DIR_TRA"]);
					item.CLIEC_COD_DEP_TRA = Funciones.CheckStr(dr["CLIEC_COD_DEP_TRA"]);
					item.CLIEC_COD_PRO_TRA = Funciones.CheckStr(dr["CLIEC_COD_PRO_TRA"]);
					item.CLIEC_COD_DIS_TRA = Funciones.CheckStr(dr["CLIEC_COD_DIS_TRA"]);
					item.CLIEC_COD_POS_TRA = Funciones.CheckStr(dr["CLIEC_COD_POS_TRA"]);
					item.CLIEV_TEL_FIJ_TRA = Funciones.CheckStr(dr["CLIEV_TEL_FIJ_TRA"]);
					//Inicio TS-CJF - Agregacion de Datos Domicilio y Trabajo
					item.DEPAV_DESCRIPCION_LEGAL =  Funciones.CheckStr(dr["DEPAV_DESCRIPCION_LEGAL"]);
					item.DEPAV_DESCRIPCION_TRABAJO =  Funciones.CheckStr(dr["DEPAV_DESCRIPCION_TRABAJO"]);
					item.PROVV_DESCRIPCION_LEGAL =  Funciones.CheckStr(dr["PROVV_DESCRIPCION_LEGAL"]);
					item.PROVV_DESCRIPCION_TRABAJO =  Funciones.CheckStr(dr["PROVV_DESCRIPCION_TRABAJO"]);
					item.DISTV_DESCRIPCION_LEGAL =  Funciones.CheckStr(dr["DISTV_DESCRIPCION_LEGAL"]);
					item.DISTV_DESCRIPCION_TRABAJO  =  Funciones.CheckStr(dr["DISTV_DESCRIPCION_TRABAJO"]);
					item.SOLIV_RUC_EMP_SUS = Funciones.CheckStr(dr["SOLIV_RUC_EMP_SUS"]);
					item.SOLIV_EMP_SUS = Funciones.CheckStr(dr["SOLIV_EMP_SUS"]);
					item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]);
					item.SOLIN_CODIGO = Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
					item.SOLIC_SCO_TXT_CON = Funciones.CheckStr(dr["SOLIC_SCO_TXT_CON"]);
					item.SOLIN_LIM_CRE_CON  = Funciones.CheckDbl(dr["SOLIN_LIM_CRE_CON"]);
					item.SOLIN_SCO_NUM_CON  = Funciones.CheckDbl(dr["SOLIN_SCO_NUM_CON"]);
					//Fin TS-CJF - Agregacion de Datos Domicilio y Trabajo
					item.CLIEV_TEL_REF_1 = Funciones.CheckStr(dr["CLIEV_TEL_REF_1"]);
					item.CLIEV_TEL_REF_2 = Funciones.CheckStr(dr["CLIEV_TEL_REF_2"]);
					item.TVENC_CODIGO = Funciones.CheckStr(dr["TVENC_CODIGO"]);
					item.PLANC_CODIGO1 = Funciones.CheckStr(dr["PLANC_CODIGO1"]);
					item.PLANC_CODIGO2 = Funciones.CheckStr(dr["PLANC_CODIGO2"]);
					item.PLANC_CODIGO3 = Funciones.CheckStr(dr["PLANC_CODIGO3"]);
					item.PACUC_CODIGO = Funciones.CheckStr(dr["PACUC_CODIGO"]);
					item.FPAGC_CODIGO = Funciones.CheckStr(dr["FPAGC_CODIGO"]); 
					item.PLANN_CAR_FIJ1=Funciones.CheckDbl(dr["PLANN_CAR_FIJ1"]);
					item.PLANN_CAR_FIJ2=Funciones.CheckDbl(dr["PLANN_CAR_FIJ2"]);
					item.PLANN_CAR_FIJ3=Funciones.CheckDbl(dr["PLANN_CAR_FIJ3"]);
					item.SOLIC_TIP_CAR_MAN =Funciones.CheckStr(dr["SOLIC_TIP_CAR_MAN"]);
					item.SOLIC_TIP_CAR_FIJ =Funciones.CheckStr(dr["SOLIC_TIP_CAR_FIJ"]);
					item.SOLIN_IMP_DG = Funciones.CheckStr(dr["SOLIN_IMP_DG"]);
					item.SOLIN_IMP_DG_MAN = Funciones.CheckDbl(dr["SOLIN_IMP_DG_MAN"]);
					item.SOLIV_COM_PUN_VEN = Funciones.CheckStr(dr["SOLIV_COM_PUN_VEN"]);
					item.MRECV_DESCRIPCION = Funciones.CheckStr(dr["MRECV_DESCRIPCION"]);
					item.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);

					item.CLIEV_TEL_LEG = Funciones.CheckStr(dr["CLIEV_TEL_LEG"]);

					// T12618 - Portabilidad - INICIO
					item.OPERADOR_CEDENTE = Funciones.CheckStr(dr["OPERADOR_CEDENTE"]);
					item.ESTADO_PORTABILIDAD = Funciones.CheckStr(dr["ESTADO_PORTABILIDAD"]);
					item.SOLIV_RES_EXP_CON = Funciones.CheckStr(dr["SOLIV_RES_EXP_CON"]);
					switch(item.SOLIV_RES_EXP_CON)
					{
						case "A" :item.SOLIV_RES_EXP_CON = "APROBAR"; break;
						case "B" :item.SOLIV_RES_EXP_CON = "APROBAR__VERIFICAR"; break;
						case "C" :item.SOLIV_RES_EXP_CON = "OBSERVAR"; break;
						case "D" :item.SOLIV_RES_EXP_CON = "ALTO_RIESGO"; break;
						case "S" :item.SOLIV_RES_EXP_CON = "SIN_HISTORIAL"; break;
					}
					// T12618 - Portabilidad - FIN
					item.RFINC_CODIGO = Funciones.CheckStr(dr["RFINC_CODIGO"]);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return item;
		}

		public ArrayList ListaPlazosAcuerdo(string cod_plazoacuerdo,string cod_tipoproducto,string estado)
		{
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("K_PLA_ACUERDO",DbType.String,2,ParameterDirection.Input),
					new DAABRequest.Parameter("K_TIP_PRODUCTO",DbType.String,2,ParameterDirection.Input),					
					new DAABRequest.Parameter("K_ESTADO",DbType.String,1,ParameterDirection.Input),					
					new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)

				};			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
						

			if(!cod_plazoacuerdo.Equals("")) arrParam[0].Value = cod_plazoacuerdo;			
			if(!cod_tipoproducto.Equals("")) arrParam[1].Value = cod_tipoproducto;			
			if(!estado.Equals("")) arrParam[2].Value = estado;

			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SECP_MAESTROS + ".SECSS_CON_PLAZO_ACUERDO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					PlazoAcuerdo objPlazoAcuerdo= new PlazoAcuerdo();
										
					objPlazoAcuerdo.PACUC_CODIGO = Funciones.CheckStr(dr["PACUC_CODIGO"]);
					objPlazoAcuerdo.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					objPlazoAcuerdo.PACUV_DESCRIPCION = Funciones.CheckStr(dr["PACUV_DESCRIPCION"]);
					objPlazoAcuerdo.PACUC_ESTADO = Funciones.CheckStr(dr["PACUC_ESTADO"]);

					filas.Add(objPlazoAcuerdo);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}//end ListaPlazosAcuerdo

		public ArrayList ListaCanales(Int64 cod_usuario,string cod_producto)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_USUAN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_TPROC_CODIGO", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if(cod_usuario > 0) arrParam[0].Value = cod_usuario;	
			if(!cod_producto.Equals("")) arrParam[1].Value = cod_producto;
					

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_TIPO_OFI_X_USUARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Canal objCanal = new Canal();
					objCanal.CANAC_CODIGO=Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					objCanal.CANAV_DESCRIPCION=Funciones.CheckStr(dr["TOFIV_DESCRIPCION"]);					
					filas.Add(objCanal);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}//end ListaCanales		
		
		public int CargaMasiva(string pstrTipo, string pstrdatos)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DATOS", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA", DbType.Int32, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrdatos;

			int retorno = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			switch (pstrTipo)
			{
				case "W": 
					obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".SP_INSERT_CARGA_WHTFLX";
					break;
				case "B": 
					obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".SP_INSERT_CARGA_BLKLST";
					break;
				case "E": 
					obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".SP_INSERT_CARGA_EMPTOP";
					break;
				case "C":
					obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".SP_INSERT_CARGA_WHTCES";
					break;
			}
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[1];				
				retorno = Funciones.CheckInt(parRetorno.Value);
			}
			catch( Exception ex )
			{				
				retorno = 0;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno;
		}

		public ArrayList ListarTipoDocumento()
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)}; 
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_DOCUMENTO";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					TipoDocumento oItem = new TipoDocumento();
					oItem.TDOCC_CODIGO = Funciones.CheckStr(dr["DOCC_CODIGO"]);
					oItem.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["DOCV_DESCRIPCION"]);
					oItem.COD_BSCS = Funciones.CheckStr(dr["DOCC_COD_BSCS"]);
					oItem.COD_SGA = Funciones.CheckStr(dr["DOCC_COD_SGA"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public DataSet ListarBolsaMasiva(int pstrTipoDocumento, string pstrNroDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_tipo_doc", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_doc", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cliente", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_bolsa", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_cod_err", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_des_err", DbType.String, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrTipoDocumento;
			arrParam[1].Value = pstrNroDocumento;
 
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_BSCS_BOLSA + ".sp_consulta_bolsa";

			obRequest.Parameters.AddRange(arrParam);
                  
			DataSet ds = null;
			try
			{
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return ds;
		}

		public void ProcesarBolsa(string pstrCustcode, string pstrAccion, int pintBolsa, string pstrUsuario, string pstrPDV, ref string pstrCodError, ref string pstrDesError)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_custcode", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_accion", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_fu_pack_id", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_usuario", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_punto_venta", DbType.String, 100, ParameterDirection.Input),
												   //new DAABRequest.Parameter("p_vendedor", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cod_err", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_des_err", DbType.String, 200, ParameterDirection.Output)
											   };
			int i;
			i=0; arrParam[i].Value = pstrCustcode;
			i++; arrParam[i].Value = pstrAccion;
			i++; arrParam[i].Value = pintBolsa;
			i++; arrParam[i].Value = pstrUsuario;
			i++; arrParam[i].Value = pstrPDV;
			//i++; arrParam[i].Value = pstrUsuario;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Transactional = true;
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_BSCS_BOLSA + ".SP_PROCESO_BOLSA";
			obRequest.Parameters.AddRange(arrParam);	
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);				
				pstrCodError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);
				pstrDesError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[6]).Value);
			}
			catch(Exception e)
			{		
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}
		public DataTable ListarGrupoBolsa()
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("p_grupo_bolsa", DbType.Object, ParameterDirection.Output)}; 
	 
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_BSCS_BOLSA + ".SP_CONSULTA_GRUPO_BOLSA";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}
		public DataTable ListarTipoBolsa(string pstrTipoBolsa)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_shbolsa", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipo_bolsa", DbType.Object, ParameterDirection.Output),
			}; 
	                  
			arrParam[0].Value = pstrTipoBolsa;
	 
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_BSCS_BOLSA + ".SP_CONSULTA_TIPO_BOLSA";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}
		public ArrayList ListarSolucion3Play(string pstrTipoServicio, out int pintCodError, out string pstrMsjError)
		{
			ArrayList filas = new ArrayList();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("an_tipsrv", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("cur_solucion_o", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("an_coderror_o", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("ac_mensaje_o", DbType.String, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrTipoServicio;
 
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".p_consulta_solucion";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			IDataReader dr = null;
			try
			{

				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo  = Funciones.CheckStr(dr["IDSOLUCION"]);
					item.Descripcion = Funciones.CheckStr(dr["SOLUCION"]);

					filas.Add(item);
				}				

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				pintCodError = Convert.ToInt32(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)obRequest.Parameters[3];
				pstrMsjError = Convert.ToString(parSalida2.Value);
			}
			catch(Exception e)			
			{                       
				
				pintCodError = 1;
				pstrMsjError = e.Message;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPaquete3Play(Int64 plngIdSolucion, out int pintCodError, out string pstrMsjError)
		{
			ArrayList filas = new ArrayList();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("an_idsolucion", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("cur_paquete_o", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("an_coderror_o", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("ac_mensaje_o", DbType.String, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = plngIdSolucion;
 
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".p_consulta_paquete";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			//DataTable dt;
			IDataReader dr = null;
			try
			{
				//dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo  = Funciones.CheckStr(dr["IDPAQ"]);
					item.Descripcion = Funciones.CheckStr(dr["OBSERVACION"]);

					filas.Add(item);
				}	

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				pintCodError = Convert.ToInt32(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)obRequest.Parameters[3];
				pstrMsjError = Convert.ToString(parSalida2.Value);
			}
			catch(Exception e)
			{                       
				
				pintCodError = 1;
				pstrMsjError = e.Message;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPlanesXPaquete3Play(string pstrPaquete)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("an_idpaq", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("cur_srv_o", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("an_coderror_o", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("ac_mensaje_o", DbType.String, ParameterDirection.Output)
											   }; 
			ArrayList filas;
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrPaquete;
 
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".p_consulta_srv";
                  
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ServicioHFC oSrv = new ServicioHFC();
					oSrv.IDDET = Funciones.CheckInt64(dr["IDDET"]);
					oSrv.IdProducto = Funciones.CheckInt64(dr["IDPRODUCTO"]);
					oSrv.IdLinea = Funciones.CheckInt64(dr["IDLINEA"]);
					oSrv.Producto = Funciones.CheckStr(dr["PRODUCTO"]);
					oSrv.Grupo = Funciones.CheckInt(dr["PAQUETE"]);
					oSrv.IdServicio = Funciones.CheckStr(dr["CODSRV"]);
					oSrv.Servicio = Funciones.CheckStr(dr["SERVICIO"]);
					oSrv.IdEquipo = Funciones.CheckStr(dr["CODEQUIPO"]);
					oSrv.Equipo = Funciones.CheckStr(dr["EQUIPO"]);
					oSrv.CF_Precio = Funciones.CheckDbl(dr["PRECIO"]);
					oSrv.FlagPrincipal = Funciones.CheckStr(dr["FLGPRINCIPAL"]);
					oSrv.FlagOpcional = Funciones.CheckStr(dr["FLG_OPCIONAL"]);
					oSrv.FlagDefecto = Funciones.CheckStr(dr["DEFECTO"]);
					oSrv.CantVenta = Funciones.CheckInt(dr["CANTIDAD"]);

					filas.Add(oSrv);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		//Renovacion
		public ArrayList ListarPlanTarifario(string pstrOferta, string pstrProducto, string pstrDespacho, string pstrFlujo, string pstrDocumento, 
			string pstrOficina, string pstrCasoEspecial, string pstrPlazo, string pstrRiesgo, string pstrFlagRenovacion)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_OFERTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PROD", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESPACHO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLUJO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAGRENOVACION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrOferta;
			arrParam[1].Value = pstrProducto;
			arrParam[2].Value = pstrDespacho;
			arrParam[3].Value = pstrFlujo;
			arrParam[4].Value = pstrDocumento;
			arrParam[5].Value = pstrOficina;
			arrParam[6].Value = pstrCasoEspecial;
			arrParam[7].Value = pstrPlazo;
			arrParam[8].Value = pstrRiesgo;
			arrParam[9].Value = pstrFlagRenovacion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PLAN_TARIFARIO1";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					Plan oPlan = new Plan();
					oPlan.PLANC_CODIGO = Funciones.CheckStr(dr["PLANC_CODIGO"]);
					oPlan.PLANV_DESCRIPCION = Funciones.CheckStr(dr["PLANV_DESCRIPCION"]);
					oPlan.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["PLANN_CAR_FIJ"]);
					oPlan.PLANC_EQUI_SAP = Funciones.CheckStr(dr["PLANC_EQUI_SAP"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNV_TIPO_PLAN"]);
					oPlan.GPLNV_DESCRIPCION = Funciones.CheckStr(dr["GPLNV_DESCRIPCION"]);
					oPlan.CODIGO_BSCS = Funciones.CheckStr(dr["CODIGO_BSCS"]);
					oPlan.TIPO_PRODUCTOS = Funciones.CheckStr(dr["TIPO_PRODUCTOS"]);
					filas.Add(oPlan);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public DataTable ObtenerEquipoGama()
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output)
											   }; 
			
			arrParam[0].Value = DBNull.Value;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_LISTAR_EQUIPOGAMA";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				return obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public ArrayList ListarParametroGeneral(string pstrCodigo)
		{
			ArrayList filas = new ArrayList();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCodigo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PARAM_GENERAL";

			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ParametroConsumer oItem = new ParametroConsumer(); 
					oItem.PCONI_CODIGO = Funciones.CheckStr(dr["PCONI_CODIGO"]);
					oItem.PCONV_DESCRIPCION = Funciones.CheckStr(dr["PCONV_DESCRIPCION"]);
					oItem.PCONV_VALOR = Funciones.CheckStr(dr["PCONV_VALOR"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public string ValidarSECRecurrente(string strTipoDocumento, string strNroDocumento, string strOferta, string strCasoEspecial, 
			string strCadenaDetalle, ref string flgReingresoSec)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SEC_RECURRENTE", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_FLG_REINGRESO", DbType.String, 2, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFERTA", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CADENA", DbType.String, 5000, ParameterDirection.Input)};
			int i;
			string SEC = "";
			i=2; arrParam[i].Value = strTipoDocumento;
			i++; arrParam[i].Value = strNroDocumento;
			i++; arrParam[i].Value = strOferta;
			i++; arrParam[i].Value = strCasoEspecial;
			i++; arrParam[i].Value = strCadenaDetalle;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Transactional = true;
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_VALIDA_SEC_RECURRENTE";
			obRequest.Parameters.AddRange(arrParam);	
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);				
				SEC = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[0]).Value);
				flgReingresoSec = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[1]).Value);
			}
			catch(Exception)
			{		
				SEC = "0";
				flgReingresoSec = "";
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return SEC;
		}
		//VENTA UNIFICADA
		public string ConsultarProductoPaquete(string pPaquete)
		{
			string strProductos;
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_PLAN", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_PRODUCTOS", DbType.String, 100, ParameterDirection.Output)}; 
			arrParam[0].Value = pPaquete;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			
			obRequest.Command = "SP_OBTENER_PRODUCTOS_PLAN";
			string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
			if ( esquema != null && esquema != "") 
				obRequest.Command = esquema  + "." + obRequest.Command;

			obRequest.Parameters.AddRange(arrParam);
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter p;
				p = (IDataParameter)obRequest.Parameters[1];
				strProductos= Funciones.CheckStr(p.Value);
			}
			catch(Exception)
			{				
				strProductos = "";
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return strProductos;
		}

		public DataTable ListadoPaquete3Play(Int64 plngIdSolucion, out int pintCodError, out string pstrMsjError)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("an_idsolucion", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("cur_paquete_o", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("an_coderror_o", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("ac_mensaje_o", DbType.String, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = plngIdSolucion;
 
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".p_consulta_paquete";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			DataTable dt;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				pintCodError = Convert.ToInt32(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)obRequest.Parameters[3];
				pstrMsjError = Convert.ToString(parSalida2.Value);
			}
			catch(Exception e)
			{                       
				dt = null;
				pintCodError = 1;
				pstrMsjError = e.Message;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}

		public ArrayList ListarPlazoDTH(string pstrCodPlan)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; if (pstrCodPlan != String.Empty) { arrParam[i].Value = pstrCodPlan; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_PLAZO_DTH";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					PlazoAcuerdo oPlazo = new PlazoAcuerdo();
					oPlazo.PACUC_CODIGO = Funciones.CheckStr(dr["PLZAC_CODIGO"]);                          
					oPlazo.PACUV_DESCRIPCION = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);
					filas.Add(oPlazo);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPlanDTH(string pstrOferta, string pstrCampana)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OFERTA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, 4, ParameterDirection.Input)
											   }; 
            
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrOferta;
			arrParam[2].Value = pstrCampana;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".MANTSS_LISTAR_PLAN_DTH";
            
			obRequest.Parameters.AddRange(arrParam);
            
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					Plan oPlan = new Plan();
					oPlan.PLANC_CODIGO = Funciones.CheckStr(dr["PLANC_CODIGO"]);
					oPlan.PLANV_DESCRIPCION = Funciones.CheckStr(dr["PLANV_DESCRIPCION"]);
					oPlan.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["PLANN_CAR_FIJ"]);
					oPlan.PLANC_EQUI_SAP = Funciones.CheckStr(dr["PLANC_EQUI_SAP"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNV_TIPO_PLAN"]);
					oPlan.GPLNV_DESCRIPCION = Funciones.CheckStr(dr["GPLNV_DESCRIPCION"]);
					oPlan.CODIGO_BSCS = Funciones.CheckStr(dr["CODIGO_BSCS"]);
					filas.Add(oPlan);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarCampanaDTH1(string pstrOficina)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 4, ParameterDirection.Input)
											   }; 
            
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".MANTSS_LISTAR_CAMPANA_DTH1";
            
			obRequest.Parameters.AddRange(arrParam);
            
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					AP_Campana oCampana = new AP_Campana();
					oCampana.CAMPV_CODIGO = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					oCampana.CAMPV_DESCRIPCION = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
					filas.Add(oCampana);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public DataTable ListadoSolucion3Play(string pstrTipoServicio, out int pintCodError, out string pstrMsjError)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("an_tipsrv", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("cur_solucion_o", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("an_coderror_o", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("ac_mensaje_o", DbType.String, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrTipoServicio;
 
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".p_consulta_solucion";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			DataTable dt;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				pintCodError = Convert.ToInt32(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)obRequest.Parameters[3];
				pstrMsjError = Convert.ToString(parSalida2.Value);
			}
			catch(Exception e)
			{                       
				dt = null;
				pintCodError = 1;
				pstrMsjError = e.Message;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}

		public ArrayList ListarPromocionesXPaquete3Play(string pstrPaquete)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("an_idpaq", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("cur_prom_srv", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("an_coderror_o", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("ac_mensaje_o", DbType.String, ParameterDirection.Output)
											   }; 
			ArrayList filas;
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrPaquete;
 
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".p_consulta_prom_paq";
                  
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					SecPlan_AP oPlan = new SecPlan_AP();
					oPlan.PLNV_CODIGO = Funciones.CheckStr(dr["IDDET"]);
					oPlan.CAMP_CODIGO = Funciones.CheckStr(dr["IDPRODUCTO"]);
					oPlan.CAMP_DESCRIPCION = Funciones.CheckStr(dr["IDLINEA"]);
					oPlan.PLNC_ESTADO = Funciones.CheckStr(dr["IDPROM"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["FLGEDI"]);
					oPlan.PAQPN_SECUENCIA = Funciones.CheckInt(dr["PAQUETE"]);
					oPlan.PLNV_DESCRIPCION = Funciones.CheckStr(dr["DSCPROM"]);
					filas.Add(oPlan);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPaqueteUni(string pstrDocumento, string pstrOferta, string pstrPlazo)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFERTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrDocumento;
			arrParam[1].Value = pstrOferta;
			arrParam[2].Value = pstrPlazo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PAQUETE";

			obRequest.Parameters.AddRange(arrParam);

			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					Paquete_AP oPaq = new Paquete_AP(); 
					oPaq.PAQTV_CODIGO = Funciones.CheckStr(dr["PAQTV_CODIGO"]);
					oPaq.PAQTV_DESCRIPCION = Funciones.CheckStr(dr["PAQTV_DESCRIPCION"]);
					oPaq.TPAQTV_CODIGO = Funciones.CheckStr(dr["TPAQTV_CODIGO"]);
					filas.Add(oPaq);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarCuota(string pstrDocumento, string pstrRiesgo, string pstrPlan, string pstrPlazo,
			int pintNroPlanes, string pstrCasoEspecial)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {

												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_PLANES", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrDocumento;
			arrParam[1].Value = pstrRiesgo;
			arrParam[2].Value = pstrPlan;
			arrParam[3].Value = pstrPlazo;
			arrParam[4].Value = pintNroPlanes;
			arrParam[5].Value = pstrCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_CUOTAS";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["CUOC_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["CUOV_DESCRIPCION"]);
					oItem.Codigo2 = oItem.Codigo + "_" + Funciones.CheckStr(dr["CUON_INICIAL"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		//PROY-24740
		public ArrayList ListarCasoEspecial(string pstrOferta, string pstrDocumento, string pstrOficina)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_OFERTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
            
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrOferta;
			arrParam[1].Value = pstrDocumento;
			arrParam[2].Value = pstrOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = string.Format("{0}{1}" ,BaseDatos.PKG_SISACT_GENERAL , ".SP_CON_CASO_ESPECIAL");
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					CasoEspecial oCasoEspecial = new CasoEspecial();
					oCasoEspecial.TCESC_CODIGO = Funciones.CheckStr(dr["TCESC_CODIGO"]);
					oCasoEspecial.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);
					oCasoEspecial.TCEN_MAX_PLANES = Funciones.CheckInt(dr["TCEN_MAX_PLANES"]);
					oCasoEspecial.TCEN_MAX_PLAN_VOZ = Funciones.CheckInt(dr["TCEN_MAX_PLAN_VOZ"]);
					oCasoEspecial.TCEN_MAX_PLAN_DATOS = Funciones.CheckInt(dr["TCEN_MAX_PLAN_DATOS"]);
					oCasoEspecial.FLAG_WHITELIST = Funciones.CheckStr(dr["TCESI_FLAG_WHITELIST"]);

					StringBuilder sblDescripcion = new StringBuilder();
					sblDescripcion.AppendFormat("{0}_",oCasoEspecial.TCESC_CODIGO );
					sblDescripcion.AppendFormat("{0}_",oCasoEspecial.FLAG_WHITELIST);
					sblDescripcion.AppendFormat("{0}_",oCasoEspecial.TCEN_MAX_PLANES);
					sblDescripcion.AppendFormat("{0}_",oCasoEspecial.TCEN_MAX_PLAN_VOZ );
					sblDescripcion.Append(oCasoEspecial.TCEN_MAX_PLAN_DATOS);

					oCasoEspecial.TCESC_DESCRIPCION2 = sblDescripcion.ToString();
					filas.Add(oCasoEspecial);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		//PROY-24740
		public void ObtenerPlanesSolicitud(string nroSEC, ref ArrayList listaPlanes, ref ArrayList listaServicios)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_PLAN", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_SERVICIO", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (	int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			string[] sTab = {"planes","servicios"};
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_CON_PLAN_DETALLE";
			obRequest.Parameters.AddRange(arrParam);
			
			IDataReader dr=null;

			int idGen = Funciones.CheckInt(DateTime.Now.ToString("hhmmss")); //Autogenerado
			try
			{
				dr= obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
					{
						PlanDetalleVenta oPlan = new PlanDetalleVenta();
						oPlan.SOLIN_CODIGO = Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
						oPlan.SOPLN_CODIGO = Funciones.CheckInt64(dr["SOPLN_CODIGO"]);
						oPlan.SOPLN_SECUENCIA = Funciones.CheckInt64(dr["SOPLN_SECUENCIA"]);
						oPlan.SOPLN_ORDEN = Funciones.CheckInt64(dr["SOPLN_ORDEN"]);
						oPlan.PAQTV_CODIGO = Funciones.CheckStr(dr["PAQTV_CODIGO"]);
						oPlan.PAQTV_DESCRIPCION = Funciones.CheckStr(dr["PAQTV_DESCRIPCION"]);
						oPlan.PLANC_CODIGO = Funciones.CheckStr(dr["PLANC_CODIGO"]);
						oPlan.PLANV_DESCRIPCION = Funciones.CheckStr(dr["PLANV_DESCRIPCION"]);
						oPlan.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
						oPlan.SOPLN_CANTIDAD = Funciones.CheckInt(dr["SOPLN_CANTIDAD"]);
						oPlan.CARGO_FIJO = Funciones.CheckDbl(dr["SOPLN_MONTO_UNIT"]);
						oPlan.SOPLC_MONTO_TOTAL = Funciones.CheckDbl(dr["SOPLC_MONTO_TOTAL"]);
						oPlan.TOPE_MONTO = Funciones.CheckDbl(dr["SOPLN_TOPE_MONTO"]);
						oPlan.TELEFONO = Funciones.CheckStr(dr["TELEFONO"]);
						oPlan.MATERIAL = Funciones.CheckStr(dr["MATERIAL"]);
						oPlan.MATERIAL_DESC = Funciones.CheckStr(dr["MATERIAL_DESC"]);
						oPlan.PACUC_CODIGO = Funciones.CheckStr(dr["PACUC_CODIGO"]);
						oPlan.PACUV_DESCRIPCION = Funciones.CheckStr(dr["PACUV_DESCRIPCION"]);
						oPlan.CAMPANA = Funciones.CheckStr(dr["CAMPANA"]);
						oPlan.CAMPANA_DESC = Funciones.CheckStr(dr["CAMPANA_DESC"]);
						oPlan.LISTA_PRECIO = Funciones.CheckStr(dr["LISTA_PRECIO"]);
						oPlan.LISTA_PRECIO_DESC = Funciones.CheckStr(dr["LISTA_PRECIO_DESC"]);
						oPlan.PRECIO_LISTA = Funciones.CheckDbl(dr["PRECIO_LISTA"]);
						oPlan.PRECIO_VENTA = Funciones.CheckDbl(dr["PRECIO_VENTA"]);
						oPlan.CUOTA_DESCRIPCION = Funciones.CheckStr(dr["CUOTA_DESCRIPCION"]);
						oPlan.CUOTA_CODIGO = Funciones.CheckStr(dr["CUOTA_CODIGO"]);
						oPlan.CUOTA_INICIAL = Funciones.CheckDbl(dr["CUOTA_INICIAL"]);
						oPlan.SOPLV_PAQU_AGRU  = Funciones.CheckStr(dr["SOPLV_PAQU_AGRU"]);
						oPlan.SUBSIDIO  = Funciones.CheckStr(dr["SUBSIDIO_EQUIPO"]);
						oPlan.CARGO_FIJO_LIN  = Funciones.CheckDbl(dr["CARGO_FIJO_LIN"]);
						oPlan.SOLIN_COSTO_INST_DTH  = Funciones.CheckDbl(dr["SOLIN_COSTO_INST_DTH"]);
						oPlan.CASO_ESPECIAL  = Funciones.CheckStr(dr["CASO_ESPECIAL"]);
						oPlan.OFERTA  = Funciones.CheckStr(dr["OFERTA"]);
						oPlan.TIPO_PRODUCTO  = Funciones.CheckStr(dr["TIPO_PRODUCTO"]);
						oPlan.FLAG_PORTABILIDAD = Funciones.CheckStr(dr["FLAG_PORTABILIDAD"]);
						oPlan.RIESGO = Funciones.CheckStr(dr["RIESGO"]);
						oPlan.TIPO_OFICINA = Funciones.CheckStr(dr["TIPO_OFICINA"]);
						oPlan.OFICINA = Funciones.CheckStr(dr["OFICINA"]);
						oPlan.TOPEN_CODIGO = Funciones.CheckStr(dr["TOPEN_CODIGO"]);
						oPlan.PRDV_DESCRIPCION = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
						oPlan.PRDC_CODIGO = Funciones.CheckStr(dr["PRDC_CODIGO"]);
						oPlan.ID_SOLUCION = Funciones.CheckInt64(dr["ID_SOLUCION"]);
						oPlan.SOLUCION = Funciones.CheckStr(dr["SOLUCION"]);
						oPlan.IDDET = Funciones.CheckInt64(dr["IDDET"]);
						oPlan.IDPRODUCTO = Funciones.CheckInt64(dr["IDPRODUCTO"]);
						oPlan.IDLINEA = Funciones.CheckInt64(dr["IDLINEA"]);
						oPlan.FAMILIA_PLAN = Funciones.CheckStr(dr["FAMILIA_PLAN"]);
						oPlan.FAMILIA_PLAN_DES = Funciones.CheckStr(dr["FAMILIA_PLAN_DES"]);
						listaPlanes.Add(oPlan);
					}
				
				dr.NextResult();

				while(dr.Read())
					{
						SecServicio_AP oServicio = new SecServicio_AP();

						oServicio.SOPLN_CODIGO = Funciones.CheckInt(dr["SOPLN_CODIGO"]);
						oServicio.SERVV_CODIGO = Funciones.CheckStr(dr["SERVV_CODIGO"]);
						oServicio.SERVV_DESCRIPCION = Funciones.CheckStr(dr["DESCRIPCION"]);
						oServicio.CARGO_FIJO_BASE = Funciones.CheckDbl(dr["SERVN_PRECIO_SERV"]);

						oServicio.IDDET = Funciones.CheckInt64(dr["IDDET"]);
						oServicio.IDPRODUCTO = Funciones.CheckInt64(dr["IDPRODUCTO"]);
						oServicio.IDLINEA = Funciones.CheckInt64(dr["IDLINEA"]);
						oServicio.PLSVN_CODIGO = Funciones.CheckInt(dr["PLSVN_CODIGO"]);

						listaServicios.Add(oServicio);
					}
				}
			finally
			{				
				if (dr!=null&& dr.IsClosed==false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public ArrayList ConsultarListaServicios(string p_plan_tarifario, string p_tipo_cliente, string p_mandt)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN_TARIFARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CLIENTE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MANDT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (p_plan_tarifario != "") { arrParam[i].Value = p_plan_tarifario; }
			++i; if (p_tipo_cliente != "") { arrParam[i].Value = p_tipo_cliente; }
			++i; if (p_mandt != "") { arrParam[i].Value = p_mandt; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_LISTAR_SERVICIOS_2";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					SecServicio_AP oServ = new SecServicio_AP();
					oServ.SERVV_CODIGO = Funciones.CheckStr(dr["SERVICIO_SOLICIT"]);
					oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr["DESCRIPCION"]);
					oServ.CARGO_FIJO_BASE = Funciones.CheckFloat(dr["CARGO_FIJO"]);
					oServ.DESCUENTO_EN_PLAN = 0;
					oServ.GSRVC_CODIGO = Funciones.CheckStr(dr["GRUPO"]);
					oServ.SERVN_ORDEN = Funciones.CheckInt(dr["ORDEN"]);
					oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["SELECCIONABLE"]);
					oServ.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr["SELECCIONABLE"]);
					oServ.PLAN.PLNV_CODIGO = p_plan_tarifario; //Funciones.CheckStr(dr["Plan_Tarifario"]);

					filas.Add(oServ);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarServiciosXPaqPlan(string codPaquete, string codPlan, int idSecuencia)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PAQTV_COD", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQPN_SECUENCIA", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; if (codPaquete != String.Empty) { arrParam[i].Value = codPaquete; }
			i++; if (codPlan != String.Empty) { arrParam[i].Value = codPlan; }
			i++; if (idSecuencia != 0) { arrParam[i].Value = idSecuencia; }
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			string[] sTab = {"Planes","Servicios"}; 
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_CON_SERV_BY_PAQ_PLAN";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					SecServicio_AP oServ = new SecServicio_AP();
					oServ.PLAN = new SecPlan_AP();
					oServ.PLAN.PLNV_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);
					oServ.PLAN.PAQPN_SECUENCIA = Funciones.CheckInt(dr["PAQPN_SECUENCIA"]);
					oServ.SERVV_CODIGO = Funciones.CheckStr(dr["SERVV_CODIGO"]);
					oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr["SERVV_DESCRIPCION"]);
					oServ.SERVC_ESTADO = Funciones.CheckStr(dr["SERVC_ESTADO"]);
					oServ.GSRVC_CODIGO = Funciones.CheckStr(dr["GSRVC_CODIGO"]);
					oServ.SERVN_ORDEN = Funciones.CheckInt(dr["SERVN_ORDEN"]);
					oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["SELECCIONABLE_BASE"]);
					oServ.CARGO_FIJO_BASE = Funciones.CheckInt(dr["CARGO_FIJO_BASE"]);
					oServ.SELECCIONABLE_EN_PAQUETE = Funciones.CheckStr(dr["SELECCIONABLE_EN_PAQUETE"]);
					oServ.CARGO_FIJO_EN_PAQUETE = Funciones.CheckInt(dr["CARGO_FIJO_EN_PAQUETE"]);
					oServ.SERVD_FECHA_CREA = Funciones.CheckDate(dr["SERVD_FECHA_CREA"]);
					oServ.SERVV_USUARIO_CREA = Funciones.CheckStr(dr["SERVV_USUARIO_CREA"]);
					filas.Add(oServ);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}	


		public ArrayList ListarPlanIndiRestServ(string pstrPlan, string pstrCasoEspecial)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrPlan;
			arrParam[1].Value = pstrCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_REGLAS_PLAN_SERVICIO";

			obRequest.Parameters.AddRange(arrParam);

			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					SecServicio_AP oServ = new SecServicio_AP(); 
					oServ.SERVV_CODIGO = Funciones.CheckStr(dr["SERVICIO"]);
					oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["ESTADO"]);
					filas.Add(oServ);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPlazoAcuerdo(string pstrCasoEspecial)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 
                  
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PLAZO_ACUERDO";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					PlazoAcuerdo oPlazo = new PlazoAcuerdo();
					oPlazo.PACUC_CODIGO = Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					oPlazo.PACUV_DESCRIPCION = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);
					filas.Add(oPlazo);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPlazoAcuerdo(string pstrTipoProducto, string pstrCasoEspecial)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 
                  
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrTipoProducto;
			arrParam[1].Value = pstrCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".sp_con_plazo_acuerdo_prd";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					PlazoAcuerdo oPlazo = new PlazoAcuerdo();
					oPlazo.PACUC_CODIGO = Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					oPlazo.PACUV_DESCRIPCION = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);
					filas.Add(oPlazo);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarTipoProductoxOferta(string pstrOferta, string pstrFlujo, string pstrCasoEspecial, string pstrTipoDoc, string pstrOficina)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_OFERTA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLUJO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrOferta;
			arrParam[1].Value = pstrFlujo;
			arrParam[2].Value = pstrCasoEspecial;
			arrParam[3].Value = pstrTipoDoc;
			arrParam[4].Value = pstrOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.SISACT_PKG_GENERAL + ".SP_CON_TIPO_PRODUCTO_X_ITEM";

			obRequest.Parameters.AddRange(arrParam);

			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public string ConsultarGrupoCadena(string pOficina)
		{
			string strGrupoCadena;
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_OFICINA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_GRUPO", DbType.String, 100, ParameterDirection.Output)}; 
			arrParam[0].Value = pOficina;
			
			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			
			obRequest.Command = "SP_CON_GRUPO_CADENA";
			string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISCAD"];
			if ( esquema != null && esquema != "") 
				obRequest.Command = esquema  + "." + obRequest.Command;

			obRequest.Parameters.AddRange(arrParam);
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter p;
				p = (IDataParameter)obRequest.Parameters[1];
				strGrupoCadena= Funciones.CheckStr(p.Value);
			}
			catch(Exception)
			{				
				strGrupoCadena = "";
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return strGrupoCadena;
		}

		public string ConsultarGrupoCadenaSISACT(string pOficina)
		{
			string strGrupoCadena;
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_OFICINA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_GRUPO", DbType.String, 100, ParameterDirection.Output)}; 
			arrParam[0].Value = pOficina;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			
			obRequest.Command = "SP_CON_GRUPO_CADENA";
			string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
			if ( esquema != null && esquema != "") 
				obRequest.Command = esquema  + "." + obRequest.Command;

			obRequest.Parameters.AddRange(arrParam);
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter p;
				p = (IDataParameter)obRequest.Parameters[1];
				strGrupoCadena= Funciones.CheckStr(p.Value);
			}
			catch(Exception)
			{				
				strGrupoCadena = "";
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return strGrupoCadena;
		}

		public ArrayList ListadoTopeAutomatico(string pstrPlanCodigo)
		{                 
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COD_PLAN", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = pstrPlanCodigo;
			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.TIM098_LISTA_PLAN_TC;
			
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					TopeConsumo item = new TopeConsumo();
					item.CODPLAN  = Funciones.CheckStr(dr["COD_PLAN"]);                          
					item.NOMBRE = Funciones.CheckStr(dr["DESCRIPCION"]);
					item.ESTADO = Funciones.CheckStr(dr["ESTADO"]);
					item.MONTO = Funciones.CheckDbl(dr["MONTO_TOPE"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ConsultarListaKitsDTH(string p_tipo_operacion, string p_cod_campania, string p_plazo_acuerdo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_OPERACION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (p_tipo_operacion != "") { arrParam[i].Value = p_tipo_operacion; }
			++i; if (p_cod_campania != "") { arrParam[i].Value = p_cod_campania; }
			++i; if (p_plazo_acuerdo != "") { arrParam[i].Value = p_plazo_acuerdo; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_LISTAR_KITS_DTH";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					SecKit_AP oKit = new SecKit_AP();
					oKit.KITV_CODIGO= Funciones.CheckInt(dr["KITV_CODIGO"]);
					oKit.KITV_DESCRIPCION= Funciones.CheckStr(dr["DESCRIPCION"]);
					oKit.CARGO_FIJO_BASE=Funciones.CheckDbl(dr["CARGO_FIJO"]);
					oKit.TKITC_CODIGO= Funciones.CheckStr(dr["TIPO_KIT"]);
					oKit.KITN_PRECIO_BASE = Funciones.CheckDbl(dr["KITN_PRECIO_BASE"]);
					oKit.SELECCIONABLE_EN_PLAN = "0";
					oKit.CARGO_FIJO_EN_SEC = Funciones.CheckDbl(dr["CF_ALQUILER_KIT"]);
					oKit.KITN_COSTO_INST = Funciones.CheckDbl(dr["KITN_COSTO_INST"]);
					filas.Add(oKit);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarTipoProducto(string pstrOferta, string pstrFlujo)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_OFERTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLUJO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrOferta;
			arrParam[1].Value = pstrFlujo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_PRODUCTO";

			obRequest.Parameters.AddRange(arrParam);

			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		//PROY-24740
		public ArrayList ListarPlanesXPaquete(string codPaquete)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PAQTV_COD", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_PLANES", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_SERVICIOS", DbType.Object,ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; if (codPaquete != String.Empty) { arrParam[i].Value = codPaquete; }
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			string[] sTab = {"Planes","Servicios"}; 
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_CON_DET_BY_PAQUETE";
                  
			obRequest.Parameters.AddRange(arrParam);
			filas = new ArrayList();
			IDataReader dr = null;
                  
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				int idGen = Funciones.CheckInt(DateTime.Now.ToString("hhmmss")); //Autogenerado

				while(dr.Read())
				{
					SecPlan_AP oPlan = new SecPlan_AP();
					oPlan.PAQPN_SECUENCIA = Funciones.CheckInt(dr["PAQPN_SECUENCIA"]);
					oPlan.PLNV_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);
					oPlan.PLNV_DESCRIPCION = Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					oPlan.PLNC_ESTADO = Funciones.CheckStr(dr["PLNC_ESTADO"]);
					oPlan.TVENC_CODIGO = Funciones.CheckStr(dr["TVENC_CODIGO"]);
					oPlan.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNN_TIPO_PLAN"]);
					oPlan.CARGO_FIJO_BASE = Funciones.CheckInt(dr["PLNN_CARGO_FIJO"]);
					oPlan.CARGO_FIJO_EN_PAQUETE = Funciones.CheckInt(dr["PAQPN_CARGO_FIJO"]);
					oPlan.PLND_FECHA_CREA = Funciones.CheckDate(dr["PAQPD_FECHA_CREA"]);
					oPlan.PLNV_USUARIO_CREA = Funciones.CheckStr(dr["PAQPV_USUARIO_CREA"]);
					oPlan.PAQUETE.PAQTV_CODIGO = Funciones.CheckStr(dr["PAQTV_CODIGO"]);
					oPlan.PAQUETE.PAQTV_DESCRIPCION = Funciones.CheckStr(dr["PAQTV_DESCRIPCION"]);
					oPlan.PAQUETE.PAQTC_ESTADO = Funciones.CheckStr(dr["PAQTC_ESTADO"]);
					oPlan.PAQUETE.TPAQTV_CODIGO = Funciones.CheckStr(dr["TPAQTV_CODIGO"]);
					oPlan.PAQUETE.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					oPlan.GPLNV_DESCRIPCION = Funciones.CheckStr(dr["GPLNV_DESCRIPCION"]);
					oPlan.PLANC_EQUI_SAP = Funciones.CheckStr(dr["PLANC_EQUI_SAP"]);
					oPlan.SOPLN_CODIGO = idGen;
					filas.Add(oPlan);
				}
				dr.NextResult();

				ArrayList listSecServicio_Ap = new ArrayList();

				while(dr.Read())
						{
							SecServicio_AP oServ = new SecServicio_AP();
					oServ.PAQPN_SECUENCIA =Funciones.CheckInt(dr["PAQPN_SECUENCIA"]);
					oServ.PLNV_CODIGO=Funciones.CheckInt(dr["PLNV_CODIGO"]);
					oServ.SERVV_CODIGO = Funciones.CheckStr(dr["SERVV_CODIGO"]);
					oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr["SERVV_DESCRIPCION"]);
					oServ.SERVC_ESTADO = Funciones.CheckStr(dr["SERVC_ESTADO"]);
					oServ.GSRVC_CODIGO = Funciones.CheckStr(dr["GSRVC_CODIGO"]);
					oServ.SERVN_ORDEN = Funciones.CheckInt(dr["SERVN_ORDEN"]);
					oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["SELECCIONABLE_BASE"]);
					oServ.CARGO_FIJO_BASE = Funciones.CheckInt(dr["CARGO_FIJO_BASE"]);
					oServ.SELECCIONABLE_EN_PAQUETE = Funciones.CheckStr(dr["SELECCIONABLE_EN_PAQUETE"]);
					oServ.CARGO_FIJO_EN_PAQUETE = Funciones.CheckInt(dr["CARGO_FIJO_EN_PAQUETE"]);
					oServ.SERVD_FECHA_CREA = Funciones.CheckDate(dr["SERVD_FECHA_CREA"]);
					oServ.SERVV_USUARIO_CREA = Funciones.CheckStr(dr["SERVV_USUARIO_CREA"]);
					listSecServicio_Ap.Add(oServ);
				}

				//Merge
				foreach (SecPlan_AP item in filas)
				{
					foreach(SecServicio_AP serv  in listSecServicio_Ap)
					{
						if (item.PAQPN_SECUENCIA==serv.PAQPN_SECUENCIA && Funciones.CheckInt(item.PLNV_CODIGO)==serv.PLNV_CODIGO)
						{
							serv.PLAN=item;
							item.SERVICIOS.Add(serv);
						}
					}
				}
			}
			finally
			{
				if( dr!=null && dr.IsClosed==false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}	

		public ArrayList ListarServicioDTH(string pstrCodPlan)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN_TARIFARIO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCodPlan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_LISTAR_SERVICIOS_DTH";
                
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					SecServicio_AP oServ = new SecServicio_AP();
					oServ.SERVV_CODIGO = Funciones.CheckStr(dr["SERVICIO_SOLICIT"]);
					oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr["DESCRIPCION"]);
					oServ.CARGO_FIJO_BASE = Funciones.CheckDbl(dr["CARGO_FIJO"]);					
					oServ.GSRVC_CODIGO = Funciones.CheckStr(dr["GRUPO"]);
					oServ.SERVN_ORDEN = Funciones.CheckInt(dr["ORDEN"]);
					oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["SELECCIONABLE"]);
					oServ.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr["SELECCIONABLE"]);
					oServ.PLAN.PLNV_CODIGO = pstrCodPlan;
					oServ.TSERVC_CODIGO= Funciones.CheckStr(dr["TIPO_SERVICIO"]);
					filas.Add(oServ);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarNoMostrarCampania(string pstrDocumento, string pstrRiesgo, string pstrPlan, 
			string pstrPlazo, string pstrOficina)
		{
			ArrayList filas = new ArrayList();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrDocumento;
			arrParam[1].Value = pstrRiesgo;
			arrParam[2].Value = pstrPlan;
			arrParam[3].Value = pstrPlazo;
			arrParam[4].Value = pstrOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_NO_MOSTRAR_CAMPANA";

			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico(); 
					oItem.Codigo = Funciones.CheckStr(dr["CMPV_CODIGO"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarCampaniaCE(string pstrCasoEspecial)
		{
			ArrayList filas = new ArrayList();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_CAMPANA_CE";

			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico(); 
					oItem.Codigo = Funciones.CheckStr(dr["CMPV_CODIGO"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarCampanaDTH(string pstrCodPlazo, string pstrCodPlan)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAZO_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCodPlazo;
			arrParam[1].Value = pstrCodPlan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_CAMPANA_DTH";
                
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					AP_Campana oCampana = new AP_Campana();
					oCampana.CAMPV_CODIGO = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					oCampana.CAMPV_DESCRIPCION = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
					filas.Add(oCampana);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarParametroConsumer(int intCodigoParametro)
		{
			ArrayList lisRetorno=new ArrayList();
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("v_INT_CODIGO",DbType.Int64,ParameterDirection.Input),
					new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
				};			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = intCodigoParametro;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".LISTAR_PARAM_CONSUMER";
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ParametroConsumer itm = new ParametroConsumer();
					itm.PCONI_CODIGO = dr["PCONI_CODIGO"].ToString();					
					itm.PCONV_DESCRIPCION = dr["PCONV_DESCRIPCION"].ToString();					
					itm.PCONV_VALOR = dr["PCONV_VALOR"].ToString();					
					itm.PCONI_FLAG_ACTIVO =Convert.ToInt16(dr["PCONI_FLAG_ACTIVO"]);					
					itm.PCONV_MENSAJE =dr["PCONV_MENSAJE"].ToString();					
					lisRetorno.Add(itm);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			


			return lisRetorno;
		}

		//		public DataSet ListarDetalleLineaSGA(string pstrTipoDocu, string pstrNroDocumento, int pintCantMes)
		//		{
		//			DAABRequest.Parameter[] arrParam = {
		//												   new DAABRequest.Parameter("AC_NTDIDE", DbType.String, 15, ParameterDirection.Input),
		//												   new DAABRequest.Parameter("AC_TIP_DOC", DbType.String, 3, ParameterDirection.Input),
		//												   new DAABRequest.Parameter("AC_CANT_MES", DbType.Int32, ParameterDirection.Input),
		//												   new DAABRequest.Parameter("CLIENTE_CUR", DbType.Object, ParameterDirection.Output),
		//												   new DAABRequest.Parameter("SERVICIOS_CUR", DbType.Object, ParameterDirection.Output),
		//												   new DAABRequest.Parameter("SERVICIOS_SUSP_CUR", DbType.Object, ParameterDirection.Output),
		//												   new DAABRequest.Parameter("FAC_CUR", DbType.Object, ParameterDirection.Output),
		//												   new DAABRequest.Parameter("AC_ERROR_CODE", DbType.Int32, ParameterDirection.Output),
		//												   new DAABRequest.Parameter("AC_MENSAJE", DbType.String, ParameterDirection.Output)
		//											   }; 
		//                  
		//			int i=0;
		//			for (i=0; i<arrParam.Length;i++)
		//				arrParam[i].Value = DBNull.Value;
		// 
		//			arrParam[0].Value = pstrNroDocumento;
		//			arrParam[1].Value = pstrTipoDocu;
		//			arrParam[2].Value = pintCantMes;
		// 
		//			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
		//			DAABRequest obRequest = obj.CreaRequest();
		//			obRequest.CommandType = CommandType.StoredProcedure;             
		//			obRequest.Command = BaseDatos.PKG_PQ_CONSULTA_SIAC_SRV + ".P_CONSULTA";
		//                  
		//			obRequest.Parameters.AddRange(arrParam);
		//                  
		//			DataSet ds;
		//			try
		//			{
		//				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
		//			}
		//			catch(Exception e)
		//			{                       
		//				ds = null;
		//			}
		//			finally
		//			{
		//				obRequest.Parameters.Clear();
		//				obRequest.Factory.Dispose();
		//			}
		//			return ds;
		//		}


		//gaa20121107
		public DataSet ListarDetalleLineaSGA(string pstrTipoDocu, string pstrNroDocumento, int pintCantMes)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_documento", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipo_documento", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cant_prom", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cabecera_inf", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_detalles_inf", DbType.Object, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrNroDocumento;
			arrParam[1].Value = pstrTipoDocu;
			arrParam[2].Value = pintCantMes;
 
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_PQ_CONSULTA_SIAC_SRV + ".GET_INFORMACION_CLIENTE";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			DataSet ds;
			try
			{
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
			}
			catch(Exception)
			{                       
				ds = null;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return ds;
		}
		//fin gaa20121107

		public DataSet ListarDetalleLinea(int pstrTipoDocu, string pstrNroDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUR_CLIENTE", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CUR_DETALLE", DbType.Object, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrTipoDocu;
			arrParam[1].Value = pstrNroDocumento;
 
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_CLIENTE + ".SP_DETALLE_X_LINEA"; //"PKG_PARAMETRICO.SP_DETALLE_X_LINEA"; 

			obRequest.Parameters.AddRange(arrParam);
                  
			DataSet ds = null;
			try
			{
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return ds;
		}

		public int EvaluacionPendiente(string strCodTipoDocumento , string strNumeroDocumento, int dblVigencia)
		{
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("P_TDOCC_CODIGO",DbType.String,2,ParameterDirection.Input),
					new DAABRequest.Parameter("P_CLIEC_NUM_DOC",DbType.String,16,ParameterDirection.Input),
					new DAABRequest.Parameter("P_VIGENCIA",DbType.Int64,ParameterDirection.Input),					
					new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
				};			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;						

			if(!strCodTipoDocumento.Equals("")) arrParam[0].Value = strCodTipoDocumento;
			if(!strNumeroDocumento.Equals("")) arrParam[1].Value = strNumeroDocumento;
			arrParam[2].Value = dblVigencia;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSS_CANTIDAD_SOL_PENDIENTE2";
			obRequest.Parameters.AddRange(arrParam);
			
			int cantidad;
			cantidad=0;
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					cantidad = Funciones.CheckInt(dr["CANTIDAD"]);				
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return cantidad;
		}

		public void ConsultaTopBlackWhiteList(string pTipoDoc, string pNroDoc, int pDiasDeuda, double pDeuda, int pLineasActivas, 
			int pLineasBloqueo, ref bool pBlack, ref bool pWhite, ref bool pTop)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_EXISTE_BL", DbType.String, 2, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_EXISTE_WH", DbType.String, 2, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_EXISTE_TP", DbType.String, 2, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DIAS_DEUDA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DEUDA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEA_ACT", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEA_BLOQ", DbType.Int64, ParameterDirection.Input)
											   }; 
			int i;
			for (i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			i=3; arrParam[i].Value = pTipoDoc;
			i++; arrParam[i].Value = pNroDoc;
			i++; arrParam[i].Value = pDiasDeuda;
			i++; arrParam[i].Value = pDeuda;
			i++; arrParam[i].Value = pLineasActivas;
			i++; arrParam[i].Value = pLineasBloqueo;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CON_BLACK_WHITELIST";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);

				pBlack = (Funciones.CheckStr(((IDataParameter)obRequest.Parameters[0]).Value) == "1");
				pWhite = (Funciones.CheckStr(((IDataParameter)obRequest.Parameters[1]).Value) == "1");
				pTop = (Funciones.CheckStr(((IDataParameter)obRequest.Parameters[2]).Value) == "1");
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public ArrayList ListarTipoRiesgo(string pstrTipo)
		{
			ArrayList filas = new ArrayList();
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_TIPO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)}; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if (pstrTipo != "") arrParam[0].Value = pstrTipo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_RIESGO";

			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					Riesgo oItem = new Riesgo(); 
					oItem.RIEV_ENTRADA = Funciones.CheckStr(dr["RIEN_CODIGO"]);
					oItem.RIEV_DESCRIPCION = Funciones.CheckStr(dr["RIEV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}		

		public ArrayList ListarTipoOperacion()
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)}; 
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_OPERACION";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					oItem.Tipo = Funciones.CheckStr(dr["DOCC_CODIGO"]);
					oItem.Codigo2 = Funciones.CheckStr(dr["TOPEN_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["TOPEV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarTipoOferta(string strTipoDocumento)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                
			arrParam[0].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_OFERTA";
                
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["TOFC_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["TOFV_DESCRIPCION"]);

					if (strTipoDocumento != System.Configuration.ConfigurationSettings.AppSettings["TipoDocumentoRUC"].ToString()) 
					{
						filas.Add(oItem);
					}
					else
					{
						if (oItem.Codigo != System.Configuration.ConfigurationSettings.AppSettings["constCodTipoProductoB2E"].ToString())
							filas.Add(oItem);
					}
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarProducto()
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)}; 
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PRODUCTO";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public void ObtenerAlqInstalKIT(string idKit, string idCampana, string idPlazo, ref double pAlquiler, ref double pInstalacion)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ALQUILER", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_INSTALACION", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MATERIAL", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, 10, ParameterDirection.Input)};
			int i;
			i=2; arrParam[i].Value = idKit;
			i++; arrParam[i].Value = idCampana;
			i++; arrParam[i].Value = idPlazo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Transactional = true;
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_ALQ_INSTAL_KIT";
			obRequest.Parameters.AddRange(arrParam);	
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);				
				pAlquiler = Funciones.CheckDbl(((IDataParameter)obRequest.Parameters[0]).Value);
				pInstalacion = Funciones.CheckDbl(((IDataParameter)obRequest.Parameters[1]).Value);
			}
			catch(Exception e)
			{		
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public double ObtenerPorcentajeLCD(int pIdTipoCliente, int pIdSegmento, int pIdTipoRiesgo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_REGV_TIPO_CLIENTE", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REGDN_PORCENTAJE_LCD", DbType.Double,ParameterDirection.Output),
			};
			int i;
			double dPorcentaje = 0.0;			
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if(pIdTipoCliente>0) arrParam[i].Value = pIdTipoCliente;
			i++; if(pIdSegmento>0) arrParam[i].Value = pIdSegmento;
			i++; if(pIdTipoRiesgo>0) arrParam[i].Value = pIdTipoRiesgo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest pObjRequest = obj.CreaRequest();
			pObjRequest.Transactional = true;
			pObjRequest.CommandType = CommandType.StoredProcedure;
			pObjRequest.Command = BaseDatos.PKG_SISACT_REGLAS + ".SISACTS_CON_PORCENTAJE_LCD";
			pObjRequest.Parameters.AddRange(arrParam);
						
			try
			{
				pObjRequest.Factory.ExecuteNonQuery(ref pObjRequest);				
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)pObjRequest.Parameters[3];
				dPorcentaje = Funciones.CheckDbl(parSalida1.Value);
			}
			catch(Exception)
			{		
				dPorcentaje = 0.0;
			}
			finally
			{
				pObjRequest.Factory.Dispose();
			}

			return dPorcentaje;				
		}

		public bool InsertarPlanSolicitud(PlanDetalleVenta oPlan, ref string rMsg)
		{
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 

			if (oPlan.PRDC_CODIGO == ConfigurationSettings.AppSettings["CodTipoProductoDTH"])
			{
				DAABRequest.Parameter[] arrParam = {
													   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
													   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLC_MONTO_TOTAL" ,DbType.Double,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_MONTO_UNIT" ,DbType.Double,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_PLANC_CODIGO" ,DbType.String,4,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_TPROC_CODIGO" ,DbType.String,2,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_CANTIDAD" ,DbType.Int64,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_ORDEN", DbType.Int16, ParameterDirection.Input)
												   }; 

				for (int i=0; i<arrParam.Length;i++)
					arrParam[i].Value = DBNull.Value;

				arrParam[1].Value = oPlan.SOLIN_CODIGO;
				arrParam[2].Value = oPlan.CARGO_FIJO;
				arrParam[3].Value = oPlan.CARGO_FIJO;
				arrParam[4].Value = oPlan.PLANC_CODIGO;
				arrParam[5].Value = oPlan.TPROC_CODIGO;
				arrParam[6].Value = oPlan.SOPLN_CANTIDAD;
				arrParam[7].Value = oPlan.SOPLN_ORDEN;

				obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SISACT_INSERTAR_SOL_PLANES_DTH";
				obRequest.Parameters.AddRange(arrParam);
			}
			else
			{
				DAABRequest.Parameter[] arrParam = {
													   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
													   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, 4, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, 2, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String, 5, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_SECUENCIA", DbType.Int64, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_CANTIDAD", DbType.Int64, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_MONTO_UNIT", DbType.Double, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLC_MONTO_TOTAL", DbType.Double, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_TOPE_CONSUMO", DbType.Int64, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_TOPE_MONTO", DbType.Double, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_TOPE_CF", DbType.Double, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLV_PAQU_AGRU", DbType.String, ParameterDirection.Input),
													   new DAABRequest.Parameter("P_SOPLN_ORDEN", DbType.Int16, ParameterDirection.Input)
													   //gaa20161024
													   ,new DAABRequest.Parameter("P_SOPLC_FAMILIA", DbType.String, 4, ParameterDirection.Input)
													   //fin gaa20161024
												   }; 

				for (int i=0; i<arrParam.Length;i++)
					arrParam[i].Value = DBNull.Value;

				arrParam[1].Value = oPlan.SOLIN_CODIGO;
				arrParam[2].Value = oPlan.PLANC_CODIGO;
				arrParam[3].Value = oPlan.TPROC_CODIGO;
				arrParam[4].Value = oPlan.PAQTV_CODIGO;
				arrParam[5].Value = oPlan.SOPLN_SECUENCIA;
				arrParam[6].Value = oPlan.SOPLN_CANTIDAD;
				arrParam[7].Value = oPlan.CARGO_FIJO;
				arrParam[8].Value = oPlan.CARGO_FIJO;
				//Inicio Incidencia 20160114
				arrParam[9].Value = Funciones.CheckInt64(oPlan.TOPE_CODIGO);
				//Fin Inicio Incidencia 20160114
				arrParam[10].Value = Funciones.CheckDbl(oPlan.TOPE_MONTO);
				if (oPlan.SOPLN_SECUENCIA > 0) 
					arrParam[12].Value = oPlan.SOPLV_PAQU_AGRU;
				
				arrParam[13].Value = oPlan.SOPLN_ORDEN;
				//gaa20161024
				arrParam[14].Value = oPlan.FAMILIA_PLAN;
				//fin gaa20161024
				obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_INS_SOL_PLAN";
				obRequest.Parameters.AddRange(arrParam);
			}		
			try
			{
				obRequest.Transactional = true;
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida1.Value);
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
// 'PROY-24724-IDEA-28174 - INICIO 
		public bool InsertarPlanVenta(PlanDetalleVenta oPlan)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERIAL", DbType.String, 18, ParameterDirection.Input),//PROY-24724-IDEA-28174 - INICIO 
												   new DAABRequest.Parameter("P_MATERIAL_DESC", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO_DESC", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA_DESC", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LISTA_PRECIO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LISTA_PRECIO_DESC", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_LISTA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_VENTA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOTA_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOTA_INICIAL", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUBSIDIO", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CARGO_FIJO_LIN", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MODALIDAD_VENTA", DbType.String, 4, ParameterDirection.Input),
			}; 
			bool salida = false;

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = oPlan.SOLIN_CODIGO;
			arrParam[2].Value = oPlan.SOPLN_CODIGO;
			arrParam[3].Value = oPlan.TELEFONO;
			arrParam[4].Value = oPlan.MATERIAL;
			arrParam[5].Value = oPlan.MATERIAL_DESC;
			arrParam[6].Value = oPlan.PACUC_CODIGO;
			arrParam[7].Value = oPlan.PACUV_DESCRIPCION;
			arrParam[8].Value = oPlan.CAMPANA;
			arrParam[9].Value = oPlan.CAMPANA_DESC;
			arrParam[10].Value = oPlan.LISTA_PRECIO;
			arrParam[11].Value = oPlan.LISTA_PRECIO_DESC;
			arrParam[12].Value = oPlan.PRECIO_LISTA;
			arrParam[13].Value = oPlan.PRECIO_VENTA;
			arrParam[14].Value = oPlan.CUOTA_CODIGO;
			arrParam[15].Value = oPlan.CUOTA_INICIAL;
			arrParam[16].Value = oPlan.SUBSIDIO;
			arrParam[17].Value = oPlan.CARGO_FIJO_LIN;
			arrParam[18].Value = oPlan.MODALIDAD_VENTA;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_INS_SOL_PLAN_VENTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				/*IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida1.Value);*/
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
// 'PROY-24724-IDEA-28174 - Fin 
		public bool InsertarPlanServicio(ArrayList listaServicio, Int64 nroSEC, Int64 idPln)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_SERV", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 15, ParameterDirection.Input)
											   }; 
			bool salida = false;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_INS_SOL_PLAN_SERV";
			try
			{
				foreach (SecServicio_AP oServicio in listaServicio)
				{
					for (int i=0; i<arrParam.Length;i++)
						arrParam[i].Value = DBNull.Value;

					arrParam[1].Value = nroSEC; //oServicio.SOLIN_CODIGO;
					arrParam[2].Value = idPln;  //oServicio.SOPLN_CODIGO;
					arrParam[3].Value = oServicio.SERVV_CODIGO;
					arrParam[4].Value = oServicio.CARGO_FIJO_BASE;
					arrParam[5].Value = oServicio.SERVV_USUARIO_CREA;

					obRequest.Parameters.Clear();
					obRequest.Parameters.AddRange(arrParam);
					obRequest.Transactional = true;
					obRequest.Factory.ExecuteNonQuery(ref obRequest);
					obRequest.Factory.CommitTransaction();
				}
				salida = true;
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				if (salida)
				{
					/*IDataParameter pSalida1;
					pSalida1 = (IDataParameter)obRequest.Parameters[0];*/
					obRequest.Parameters.Clear();
					obRequest.Factory.Dispose();
				}
			}			
			return salida ;
		}


		//----------------Roaming Internacional-----------------------------

		public bool InsertarPlanServicio_2(ArrayList listaServicio, Int64 nroSEC, Int64 idPln, string codOficina, string p_Planc_Codigo, string p_Prima)//PROY-24724-IDEA-28174 Nuevo Parametro (p_Prima)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_SERV", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVC_ESTADO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVC_PLAZO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVD_FECHA_ACTIVACION", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVD_FECHA_DESACTIVACION", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVC_ORIGEN", DbType.String, 15, ParameterDirection.Input)
											   }; 
			bool salida = false;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_ROAMING_SERV + ".SISACT_INS_SOL_PLAN_SERV_DESP"; 
			try
			{
				foreach (SecServicio_AP oServicio in listaServicio)
				{
					for (int i=0; i<arrParam.Length;i++)
						arrParam[i].Value = DBNull.Value;

					arrParam[1].Value = nroSEC; //oServicio.SOLIN_CODIGO;
					arrParam[2].Value = idPln;  //oServicio.SOPLN_CODIGO;
					arrParam[3].Value = oServicio.SERVV_CODIGO;
					//PROY-24724-IDEA-28174- INICIO
					if (oServicio.SERVV_CODIGO.Equals(ClsKeyAPP.strCodServProteccionMovil))	//PROY-24724-IDEA-28174 - Parametros
					{arrParam[4].Value = p_Prima; }
					else {arrParam[4].Value = oServicio.CARGO_FIJO_BASE; }
					//PROY-24724-IDEA-28174- FIN
					
					arrParam[5].Value = oServicio.SERVV_USUARIO_CREA;
					if (oServicio.SERVC_ESTADO  != null) 
					{
						arrParam[6].Value = oServicio.SERVC_ESTADO;
					}
					if (oServicio.SERVC_PLAZO  != null) 
					{
						arrParam[7].Value = oServicio.SERVC_PLAZO;
					}
					if (oServicio.SERVD_FECHA_ACTIVACION  != System.DateTime.MinValue) 
					{
						arrParam[8].Value = oServicio.SERVD_FECHA_ACTIVACION;
					}
					if (oServicio.SERVD_FECHA_DESACTIVACION  != System.DateTime.MinValue) 
					{
						arrParam[9].Value = oServicio.SERVD_FECHA_DESACTIVACION;
					}
					arrParam[10].Value = ConfigurationSettings.AppSettings["ConstSistemaConsumer"]; 

					obRequest.Parameters.Clear();
					obRequest.Parameters.AddRange(arrParam);
					obRequest.Transactional = true;
					obRequest.Factory.ExecuteNonQuery(ref obRequest);
					obRequest.Factory.CommitTransaction();


					/*********** Registro Servicio Roaming *****************/
					if (oServicio.SERVV_CODIGO.Equals(ConfigurationSettings.AppSettings["codServRoamingI"]))
					{
						bool vExitoRoaming = InsertarPlanServiceRoamig(oServicio,nroSEC,idPln,codOficina, p_Planc_Codigo);
					}

				}
				salida = true;
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				if (salida)
				{
					/*IDataParameter pSalida1;
					pSalida1 = (IDataParameter)obRequest.Parameters[0];*/
					obRequest.Parameters.Clear();
					obRequest.Factory.Dispose();
				}
			}			
			return salida ;
		}

		private bool InsertarPlanServiceRoamig(SecServicio_AP oServicio, Int64 p_Solin_Codigo,Int64 p_Sopln_Codigo, string p_Oven_Codigo, string p_Planc_Codigo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_SAP", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_TELF_VENTA", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVN_PRECIO_SERV", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVC_PLAZO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVD_FECHA_ACTIVACION", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVD_FECHA_DESACTIVACION", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVC_ORIGEN", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUV_DESCRIPCION", DbType.String, 30, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_CODIGO", DbType.Int64, ParameterDirection.Input)
											   }; 

			BDSISACT objR = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequestR = objR.CreaRequest();
			obRequestR.CommandType = CommandType.StoredProcedure; 			
			obRequestR.Command = BaseDatos.PKG_ROAMING_SERV + ".SISACT_INS_PLAN_SERV_ROAMING"; 

			bool salida = false;

			try
			{
				for (int i=0; i<arrParam.Length;i++)
					arrParam[i].Value = DBNull.Value;


				arrParam[1].Value = p_Solin_Codigo; 
				arrParam[2].Value = oServicio.SERVV_CODIGO; 
				arrParam[3].Value = p_Planc_Codigo;
				//arrParam[4].Value = null;
				//arrParam[5].Value = null;
				arrParam[6].Value = oServicio.CARGO_FIJO_BASE;
				arrParam[7].Value = oServicio.SERVC_PLAZO;
				arrParam[8].Value = oServicio.SERVD_FECHA_ACTIVACION;
				arrParam[9].Value = oServicio.SERVD_FECHA_DESACTIVACION;					
				arrParam[10].Value = ConfigurationSettings.AppSettings["ConstSistemaConsumer"]; 
				arrParam[11].Value = oServicio.SERVV_USUARIO_CREA;
				arrParam[12].Value = p_Oven_Codigo;				
				//arrParam[13].Value = null;
				arrParam[14].Value = p_Sopln_Codigo;

				obRequestR.Parameters.Clear();
				obRequestR.Parameters.AddRange(arrParam);
				obRequestR.Transactional = true;
				obRequestR.Factory.ExecuteNonQuery(ref obRequestR);
				obRequestR.Factory.CommitTransaction();
			
			}
			catch(Exception ex)
			{
				obRequestR.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				if (salida)
				{
					/*IDataParameter pSalida1;
					pSalida1 = (IDataParameter)obRequest.Parameters[0];*/
					obRequestR.Parameters.Clear();
					obRequestR.Factory.Dispose();
				}
			}

			return salida;
		}


		//---------------Roaming Internacional --------------------------------




		public bool InsertarPlanHFC(PlanSolicitudHFC oPlan, string nroSEC, ref string idSolHFC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDSOLUCION", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLUCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDPAQ", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQUETE", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
											   }; 
			int i;
			bool salida = false;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = nroSEC;
			i++; arrParam[i].Value = oPlan.IdSolucion;
			i++; arrParam[i].Value = oPlan.Solucion;
			i++; arrParam[i].Value = oPlan.IdPaquete;
			i++; arrParam[i].Value = oPlan.Paquete;
			i++; arrParam[i].Value = oPlan.IdPlazo;
			i++; arrParam[i].Value = oPlan.Plazo;
			i++; arrParam[i].Value = oPlan.Usuario;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_INS_SOL_PLAN_HFC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				idSolHFC = Funciones.CheckStr(pSalida1.Value);
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return salida;
		}
		
		public bool InsertarPlanServicioHFC(ArrayList arrPlanDetalleHFC, Int64 idSolHFC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SLPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDDET", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDPRODUCTO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDLINEA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQUETE", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDSERVICIO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVICIO", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDEQUIPO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EQUIPO", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_PRECIO", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_LINEA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLG_PRINCIPAL", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANT_EVAL", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ORDEN", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_AGRUPA", DbType.String, 50, ParameterDirection.Input)
											   }; 
			bool salida = false;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_INS_SOL_PLAN_SERV_HFC";
			try
			{
				foreach (PlanDetalleHFC oServicio in arrPlanDetalleHFC)
				{
					int i=0;
					for (i=0; i<arrParam.Length;i++)
						arrParam[i].Value = DBNull.Value;

					i=1; arrParam[i].Value = idSolHFC;
					i++; arrParam[i].Value = oServicio.IDDET;
					i++; arrParam[i].Value = oServicio.IdProducto;
					i++; arrParam[i].Value = oServicio.IdLinea;
					i++; arrParam[i].Value = oServicio.Producto;
					i++; arrParam[i].Value = oServicio.Grupo;
					i++; arrParam[i].Value = oServicio.IdServicio;
					i++; arrParam[i].Value = oServicio.Servicio;
					i++; arrParam[i].Value = oServicio.IdEquipo;
					i++; arrParam[i].Value = oServicio.Equipo;
					i++; arrParam[i].Value = oServicio.Precio;
					i++; arrParam[i].Value = oServicio.CF_Linea;
					i++; arrParam[i].Value = oServicio.FlagPrincipal;
					i++; arrParam[i].Value = oServicio.Cantidad;
					i++; arrParam[i].Value = oServicio.Orden;
					i++; arrParam[i].Value = oServicio.Agrupa;

					obRequest.Parameters.Clear();
					obRequest.Parameters.AddRange(arrParam);
					obRequest.Transactional = true;
					obRequest.Factory.ExecuteNonQuery(ref obRequest);
					obRequest.Factory.CommitTransaction();
				}
				salida = true;
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				if (salida)
				{
					obRequest.Parameters.Clear();
					obRequest.Factory.Dispose();
				}
			}			
			return salida;
		}

		public bool InsertarPlanPromocionHFC(ArrayList arrPromocionHFC, Int64 idSolHFC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SLPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDDET", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDPRODUCTO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDLINEA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDPROM", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROMOCION", DbType.String, 50, ParameterDirection.Input)
											   }; 
			bool salida = false;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_INS_SOL_PROMOCION_HFC";
			try
			{
				foreach (PlanPromocionHFC oPromocion in arrPromocionHFC)
				{
					int i=0;
					for (i=0; i<arrParam.Length;i++)
						arrParam[i].Value = DBNull.Value;

					i=1; arrParam[i].Value = idSolHFC;
					i++; arrParam[i].Value = oPromocion.IDDET;
					i++; arrParam[i].Value = oPromocion.IdProducto;
					i++; arrParam[i].Value = oPromocion.IdLinea;
					i++; arrParam[i].Value = oPromocion.IdPromocion;
					i++; arrParam[i].Value = oPromocion.Promocion;

					obRequest.Parameters.Clear();
					obRequest.Parameters.AddRange(arrParam);
					obRequest.Transactional = true;
					obRequest.Factory.ExecuteNonQuery(ref obRequest);
					obRequest.Factory.CommitTransaction();
				}
				salida = true;
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				if (salida)
				{
					obRequest.Parameters.Clear();
					obRequest.Factory.Dispose();
				}
			}			
			return salida;
		}

		public double fltTraerPrecioKit(string pstrCodCampana, string pstrCodPlaza, int pintcodKit)
		{
			Double dblPrecio = 0;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CAMP_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZA_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_KIT_CODIGO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO", DbType.Double, ParameterDirection.Output)
											   }; 
                  
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; arrParam[i].Value = pstrCodCampana;
			i++; arrParam[i].Value = pstrCodPlaza;
			i++; arrParam[i].Value = pintcodKit;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure ;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_TRAER_PRECIO_LISTA";
                  
			obRequest.Parameters.AddRange(arrParam);

			try
			{                  
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				dblPrecio = Convert.ToDouble(parSalida1.Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dblPrecio;
		}

		public int EvaluacionPendiente_DTH(string strCodTipoDocumento , string strNumeroDocumento, int dblVigencia)
		{
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("P_TDOCC_CODIGO",DbType.String,2,ParameterDirection.Input),
					new DAABRequest.Parameter("P_CLIEC_NUM_DOC",DbType.String,16,ParameterDirection.Input),
					new DAABRequest.Parameter("P_VIGENCIA",DbType.Int64,ParameterDirection.Input),					
					new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
				};			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;						

			if(!strCodTipoDocumento.Equals("")) arrParam[0].Value = strCodTipoDocumento;
			if(!strNumeroDocumento.Equals("")) arrParam[1].Value = strNumeroDocumento;
			arrParam[2].Value = dblVigencia;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSS_CANTI_SOL_PENDIENTE_DTH";
			obRequest.Parameters.AddRange(arrParam);
			
			int cantidad;
			cantidad=0;
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					cantidad = Funciones.CheckInt(dr["CANTIDAD"]);				
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return cantidad;
		}

		public ArrayList ListarTipoGarantia(string tipo_garantia, string estado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TCARC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCARC_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (tipo_garantia != string.Empty) { arrParam[i].Value = tipo_garantia; }
			i++; if (estado != string.Empty) { arrParam[i].Value = estado; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_CON_TIPO_GARANTIA";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					TipoCargo oTipoCargo = new TipoCargo();
					oTipoCargo.TCARC_CODIGO = Funciones.CheckStr(dr["TCARC_CODIGO"]);
					oTipoCargo.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
					oTipoCargo.TCARC_ESTADO = Funciones.CheckStr(dr["TCARC_ESTADO"]);

					filas.Add(oTipoCargo);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public DataTable ObtenerInformacionCrediticia(string nroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NROSEC", DbType.Int64, ParameterDirection.Input)
											   }; 
			
			for (int i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = nroSEC;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CON_DATOS_CREDITOS";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				return obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public string ObtenerComentarioPDV(string nroSEC)
		{
			string strResultado = string.Empty;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COMENTARIO", DbType.String, 200, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NROSEC", DbType.Int64, ParameterDirection.Input)
											   }; 
			
			for (int i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = nroSEC;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_TRAER_COMENTARIOPDV";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				strResultado = Funciones.CheckStr(pSalida.Value);
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return strResultado;
		}

		public DataTable ListarGarantiaSec(string nroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SP_CON_GARANTIA_SEC";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				return obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public string ConsultaObtencionPoderes(string strTipoRiesgo, int numCantMaxLineas)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_STRTIPORIESGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTCANTMAXLINEAS", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAGPRESENTA", DbType.String,ParameterDirection.Output),
			}; 

			int i = 0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=-1;
			i++; arrParam[i].Value = strTipoRiesgo;
			i++; arrParam[i].Value = numCantMaxLineas;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_CON_REGLA_PODERES";
			obRequest.Parameters.AddRange(arrParam);
			
			string rflagPresenta="";

			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter p1;
				p1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				rflagPresenta= Funciones.CheckStr(p1.Value);
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return rflagPresenta;
		}

		public double getCFPromocional(string pCodCampana)
		{
			Double dblCF = 0;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_CF_PROM", DbType.Double, ParameterDirection.Output)
											   }; 
                  
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; arrParam[i].Value = pCodCampana;				

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure ;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_CF_PROMOCIONAL";
                  
			obRequest.Parameters.AddRange(arrParam);

			try
			{                  
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				if (parSalida1.Value != System.DBNull.Value)
					dblCF = Funciones.CheckDbl(parSalida1.Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dblCF;
		}

		public ArrayList ConsultarDepartamentoPDV(string pOficina)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 10, ParameterDirection.Input)}; 

			arrParam[1].Value = pOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			
			obRequest.Command = "SP_CON_DEPARTAMENTO_PDV";
			string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
			if ( esquema != null && esquema != "") 
				obRequest.Command = esquema  + "." + obRequest.Command;

			obRequest.Parameters.AddRange(arrParam);
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					PuntoVenta oItem = new PuntoVenta();
					oItem.OVENC_CODIGO = Funciones.CheckStr(dr["OVENC_CODIGO"]);
					oItem.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					oItem.DEPAC_CODIGO = Funciones.CheckStr(dr["DEPAC_CODIGO"]);
					oItem.DEPAV_DESCRIPCION = Funciones.CheckStr(dr["DEPAV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarCampanaDTH2(string pstrCodPlazo, string pstrCodPlan)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAZO_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCodPlazo;
			arrParam[1].Value = pstrCodPlan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_CAMPANA_DTH";
                
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					AP_Campana oCampana = new AP_Campana();
					oCampana.CAMPV_CODIGO = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					oCampana.CAMPV_DESCRIPCION = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
					filas.Add(oCampana);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ConsultarListaServiciosDTH(string p_plan_tarifario)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN_TARIFARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (p_plan_tarifario != "") { arrParam[i].Value = p_plan_tarifario; }
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_LISTAR_SERVICIOS_DTH";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					SecServicio_AP oServ = new SecServicio_AP();
					oServ.SERVV_CODIGO = Funciones.CheckStr(dr["SERVICIO_SOLICIT"]);
					oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr["DESCRIPCION"]);
					oServ.CARGO_FIJO_BASE = Funciones.CheckDbl(dr["CARGO_FIJO"]);					
					oServ.GSRVC_CODIGO = Funciones.CheckStr(dr["GRUPO"]);
					oServ.SERVN_ORDEN = Funciones.CheckInt(dr["ORDEN"]);
					oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["SELECCIONABLE"]);
					oServ.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr["SELECCIONABLE"]);
					oServ.PLAN.PLNV_CODIGO = p_plan_tarifario; //Funciones.CheckStr(dr["Plan_Tarifario"]);
					oServ.TSERVC_CODIGO= Funciones.CheckStr(dr["TIPO_SERVICIO"]);
					filas.Add(oServ);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList DetalleOferta3Play(Int64 nroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object ,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input)}; 
			
			arrParam[1].Value = nroSEC;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 			
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CONS_DETALLE_HFC";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					PlanDetalleHFC item = new PlanDetalleHFC();
					item.IdSolucion = Funciones.CheckInt64(dr["IDSOLUCION"]);
					item.Solucion = Funciones.CheckStr(dr["SOLUCION"]);
					item.IdPaquete = Funciones.CheckInt64(dr["IDPAQ"]);
					item.Paquete = Funciones.CheckStr(dr["PAQUETE"]);
					item.Grupo = Funciones.CheckInt(dr["GRUPO"]);
					item.Tipo = Funciones.CheckStr(dr["TIPO"]);
					item.IdProducto = Funciones.CheckInt64(dr["IDPRODUCTO"]);
					item.Producto = Funciones.CheckStr(dr["PRODUCTO"]);
					item.IdServicio = Funciones.CheckStr(dr["IDSERVICIO"]);
					item.Servicio = Funciones.CheckStr(dr["SERVICIO"]);
					item.IdPromocion = Funciones.CheckInt64(dr["IDPROM"]);
					item.Promocion = Funciones.CheckStr(dr["PROMOCION"]);
					item.FlagPrincipal = Funciones.CheckStr(dr["FLG_PRINCIPAL"]);
					item.Precio = Funciones.CheckDbl(dr["CF_PRECIO"]);

					filas.Add(item);
				}
				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public double fltTraerCFAlquilerKit(int pintcodKit, int pintCampania, string pintPlazo)
		{
			Double dblCosto = 0;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_KIT_CODIGO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_CODIGO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_ALQUILER_KIT", DbType.Double, ParameterDirection.Output)
											   }; 
                  
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; arrParam[i].Value = pintcodKit;
			i++; arrParam[i].Value = pintCampania;
			i++; arrParam[i].Value = pintPlazo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure ;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_CFALQUILERKIT";
                  
			obRequest.Parameters.AddRange(arrParam);

			try
			{                  
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				if (parSalida1.Value != System.DBNull.Value)
					dblCosto = Convert.ToDouble(parSalida1.Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dblCosto;
		}
	
		public double fltTraerCostoInstalacionKit(int pintcodKit, int pintCampania, string pintPlazo)
		{
			Double dblCosto = 0;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_KIT_CODIGO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_CODIGO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COSTO", DbType.Double, ParameterDirection.Output)
											   }; 
                  
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; arrParam[i].Value = pintcodKit;
			i++; arrParam[i].Value = pintCampania;
			i++; arrParam[i].Value = pintPlazo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure ;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_TRAER_COSTO_INST_KIT";
                  
			obRequest.Parameters.AddRange(arrParam);

			try
			{                  
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				if (parSalida1.Value != System.DBNull.Value)
					dblCosto = Convert.ToDouble(parSalida1.Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dblCosto;
		}

		public ArrayList ListarCampanaDTH(string pstrCodPlan)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_PROD", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; if (pstrCodPlan != String.Empty) { arrParam[i].Value = pstrCodPlan; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_CAMPANA_DTH";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					AP_Campana oCampana = new AP_Campana();
					oCampana.CAMPV_CODIGO = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					oCampana.CAMPV_DESCRIPCION = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
					filas.Add(oCampana);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPlan(string codPlan, string codTipoProd, string codTipoVenta, string codPlazo, string tipoPlan, string codEstado)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_TIPOVD", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_ESTADO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; if (codPlan != String.Empty) { arrParam[i].Value = codPlan; }
			i++; if (codTipoProd != String.Empty) { arrParam[i].Value = codTipoProd; }
			i++; if (codTipoVenta != String.Empty) { arrParam[i].Value = codTipoVenta; }
			i++; if (codPlazo != String.Empty) { arrParam[i].Value = codPlazo; }
			i++; if (tipoPlan != String.Empty) { arrParam[i].Value = tipoPlan; }
			i++; if (codEstado != String.Empty) { arrParam[i].Value = codEstado; }
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_CON_PLAN";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					SecPlan_AP oPlan = new SecPlan_AP();
					oPlan.PLNV_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);                          
					oPlan.PLNV_DESCRIPCION = Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					oPlan.PLNC_ESTADO = Funciones.CheckStr(dr["PLNC_ESTADO"]);
					oPlan.TVENC_CODIGO = Funciones.CheckStr(dr["TVENC_CODIGO"]);
					oPlan.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNN_TIPO_PLAN"]);
					oPlan.CARGO_FIJO_BASE = Funciones.CheckInt(dr["PLNN_CARGO_FIJO"]);
					oPlan.PLND_FECHA_CREA = Funciones.CheckDate(dr["PLND_FECHA_CREA"]);
					oPlan.PLNV_USUARIO_CREA = Funciones.CheckStr(dr["PLNV_USUARIO_CREA"]);
					oPlan.PLANC_CORREOCLIENTEOBLIGA = Funciones.CheckStr(dr["PLANC_CORREOCLIENTEOBLIGA"]);
					oPlan.TCTRL_CONSUMO= Funciones.CheckStr(dr["TCTRL_CONSUMO"]);
					filas.Add(oPlan);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPlanDTH(string codPlan, string codTipoProd, string codTipoVenta, string codPlazo, string tipoPlan, string codCampana)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_TIPO_PRO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; if (codPlan != String.Empty) { arrParam[i].Value = codPlan; }
			i++; if (codTipoProd != String.Empty) { arrParam[i].Value = codTipoProd; }
			i++; if (codTipoVenta != String.Empty) { arrParam[i].Value = codTipoVenta; }
			i++; if (codPlazo != String.Empty) { arrParam[i].Value = codPlazo; }
			i++; if (tipoPlan != String.Empty) { arrParam[i].Value = tipoPlan; }
			i++; if (codCampana != String.Empty) { arrParam[i].Value = codCampana; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SISACT_CON_PLAN_DTH";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					SecPlan_AP oPlan = new SecPlan_AP();
					oPlan.PLNV_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);                          
					oPlan.PLNV_DESCRIPCION = Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					oPlan.PLNC_ESTADO = Funciones.CheckStr(dr["PLNC_ESTADO"]);
					oPlan.TVENC_CODIGO = Funciones.CheckStr(dr["TVENC_CODIGO"]);
					oPlan.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNN_TIPO_PLAN"]);
					oPlan.CARGO_FIJO_BASE = Funciones.CheckDbl(dr["PLNN_CARGO_FIJO"]);
					oPlan.PLND_FECHA_CREA = Funciones.CheckDate(dr["PLND_FECHA_CREA"]);
					oPlan.PLNV_USUARIO_CREA = Funciones.CheckStr(dr["PLNV_USUARIO_CREA"]);
					//gaa20120131
					oPlan.PACUC_DESCRIPCION = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);
					//fin gaa20120131
					//gaa20120202
					oPlan.CAMP_CODIGO = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					oPlan.PLZO_CODIGO = Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					//fin gaa20120202
					filas.Add(oPlan);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPlanDTH1(string codTipoProd, string codTipoVenta, string codCampania)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMP_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i=0; if (codTipoProd != String.Empty) { arrParam[i].Value = codTipoProd; }
			i++; if (codTipoVenta != String.Empty) { arrParam[i].Value = codTipoVenta; }
			i++; if (codCampania != String.Empty) { arrParam[i].Value = codCampania; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_PLAN_DTH";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					SecPlan_AP oPlan = new SecPlan_AP();
					oPlan.PLNV_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);                          
					oPlan.PLNV_DESCRIPCION = Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					oPlan.PLNC_ESTADO = Funciones.CheckStr(dr["PLNC_ESTADO"]);
					oPlan.TVENC_CODIGO = Funciones.CheckStr(dr["TVENC_CODIGO"]);
					oPlan.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNN_TIPO_PLAN"]);
					oPlan.CARGO_FIJO_BASE = Funciones.CheckInt(dr["PLNN_CARGO_FIJO"]);
					oPlan.PLND_FECHA_CREA = Funciones.CheckDate(dr["PLND_FECHA_CREA"]);
					oPlan.PLNV_USUARIO_CREA = Funciones.CheckStr(dr["PLNV_USUARIO_CREA"]);
					//oPlan.PACUC_DESCRIPCION = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);
					//oPlan.CAMP_CODIGO = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					//oPlan.PLZO_CODIGO = Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					filas.Add(oPlan);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ObtenerSECPendiente(string strTipoDoc, string strNroDoc)
		{
			ArrayList filas = new ArrayList();
			DAABRequest.Parameter[] arrParam =
												{
													new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String, 2, ParameterDirection.Input),
													new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String, 16, ParameterDirection.Input),
													new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
												};			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;						

			arrParam[0].Value = strTipoDoc;
			arrParam[1].Value = strNroDoc;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_SOL_PENDIENTE2";
			obRequest.Parameters.AddRange(arrParam);
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					SolicitudPersona item = new SolicitudPersona();

					item.SOLIN_CODIGO = Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
					item.TDOCC_CODIGO = Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.CLIEC_NUM_DOC = Funciones.CheckStr(dr["CLIEC_NUM_DOC"]);
					item.CLIEV_NOMBRE = Funciones.CheckStr(dr["CLIEV_NOMBRE"]);
					item.CLIEV_APE_PAT = Funciones.CheckStr(dr["CLIEV_APE_PAT"]);
					item.CLIEV_APE_MAT = Funciones.CheckStr(dr["CLIEV_APE_MAT"]);
					item.CLIEV_RAZ_SOC = Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]);

					if (item.CLIEV_NOMBRE != "" && item.CLIEV_APE_PAT != "")
					{
						item.CLIEV_RAZ_SOC = item.CLIEV_NOMBRE + "  " + item.CLIEV_APE_PAT + "  " + item.CLIEV_APE_MAT;
					}	

					item.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]);
					item.ESTADODES = Funciones.CheckStr(dr["ESTADO_VENTA"]);
					item.SOLIN_IMP_DG = Funciones.CheckStr(dr["SOLIN_IMP_DG"]);
					item.SOLID_FEC_REG = Funciones.CheckDate(dr["SOLID_FEC_REG"]);
							
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}


		public int EvaluacionPendienteRenovacion(string strCodTipoDocumento , string strNumeroDocumento, int dblVigencia)
		{
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("P_TDOCC_CODIGO",DbType.String,2,ParameterDirection.Input),
					new DAABRequest.Parameter("P_CLIEC_NUM_DOC",DbType.String,16,ParameterDirection.Input),		
					new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
				};			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;						

			if(!strCodTipoDocumento.Equals("")) arrParam[0].Value = strCodTipoDocumento;
			if(!strNumeroDocumento.Equals("")) arrParam[1].Value = strNumeroDocumento;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_RENOVACION + ".SECSS_CANTIDAD_SOL_PENDIENTE2";
			obRequest.Parameters.AddRange(arrParam);
			
			int cantidad;
			cantidad=0;
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					cantidad = Funciones.CheckInt(dr["CANTIDAD"]);				
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return cantidad;
		}

		public ArrayList ListarBilletera()
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)}; 
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PRODUCTO_CLASE";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["PRCLN_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["PRCLV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
		//gaa20130826
		public DataTable ListarRangoLCDisponible(string pstrTipoDocumento, string pstrEstado)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_TIPODOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)}; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrTipoDocumento;
			arrParam[1].Value = pstrEstado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".mantss_listar_rango_lcdispo";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}

		public void ActivarRangoLCDisponible(string pstrItemsSel, string pstrCodUsuario, string pstrEstado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGOS", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUAMODI", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrItemsSel;
			arrParam[1].Value = pstrCodUsuario;
			arrParam[2].Value = pstrEstado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".mantsm_activ_rango_lcdispo";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{				
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
		}

		public void EliminarRangoLCDisponible(string pstrItemsSel)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGOS", DbType.String, 4000, ParameterDirection.Input)
											   }; 
			arrParam[0].Value = pstrItemsSel;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSD_ELIMI_RANGO_LCDISPO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{				
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
		}

		public void InsertarRangoLCDisponible(string pstrTipoDocumento, string pstrRangoInicial, string pstrRangoFinal, string pstrMensajeSISACT, 
			string pstrMensajeSMS, string pstrUsuario, out int pintResultado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPODOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANGOINI", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANGOFIN", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MSJSISACT", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MSJSMS", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrTipoDocumento;
			arrParam[1].Value = pstrRangoInicial;
			arrParam[2].Value = pstrRangoFinal;
			arrParam[3].Value = pstrMensajeSISACT;
			arrParam[4].Value = pstrMensajeSMS;
			arrParam[5].Value = pstrUsuario;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".mantsi_inser_rango_lcdispo";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[6];
				pintResultado = 0;
				if (parSalida1.Value != System.DBNull.Value)
					pintResultado = Convert.ToInt32(parSalida1.Value);
			}
			catch( Exception ex )
			{				
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}	
		}

		public void ModificarRangoLCDisponible(string pstrCodigo, string pstrTipoDocumento, string pstrRangoInicial, string pstrRangoFinal, 
			string pstrMensajeSISACT, string pstrMensajeSMS, string pstrEstado, string pstrUsuario, out int pintResultado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPODOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANGOINI", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANGOFIN", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MSJSISACT", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MSJSMS", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrTipoDocumento;
			arrParam[2].Value = pstrRangoInicial;
			arrParam[3].Value = pstrRangoFinal;
			arrParam[4].Value = pstrMensajeSISACT;
			arrParam[5].Value = pstrMensajeSMS;
			arrParam[6].Value = pstrEstado;
			arrParam[7].Value = pstrUsuario;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".mantsm_modif_rango_lcdispo";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[8];
				pintResultado = 0;
				if (parSalida1.Value != System.DBNull.Value)
					pintResultado = Convert.ToInt32(parSalida1.Value);
			}
			catch( Exception ex )
			{				
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}
		//fin gaa20130826

		//---------------------
		public string ConsultarTextoRangoLC(string strTipoDocumento, double dblLC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COMENTARIO_LC", DbType.String, 50, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC", DbType.Double, ParameterDirection.Input)};
			int i;
			string strTextoLC = "";
			i=1; arrParam[i].Value = strTipoDocumento;
			i++; arrParam[i].Value = dblLC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Transactional = true;
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CON_TEXTO_RANGO_LC";
			obRequest.Parameters.AddRange(arrParam);	
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);				
				strTextoLC = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[0]).Value);;
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return strTextoLC;
		}

		//----------------------
		public DataSet ListarDetalleLineaCantPlanes(int pstrTipoDocu, string pstrNroDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUR_PLANES_PAQ", DbType.Object, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrTipoDocu;
			arrParam[1].Value = pstrNroDocumento;
 
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_CLIENTE + ".SP_DETALLE_X_LINEA_CANT_PLANES";

			obRequest.Parameters.AddRange(arrParam);

			DataSet ds = null;
			try
			{
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return ds;
		}	
	
		//--- Bolsa Compartida ---------
		public ArrayList ListarPlanBase()
		{
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PLAN_BASE";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["PLAN_BASE"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarPlanCombo()
		{
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PLAN_COMBO";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["PLAN_COMBO"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarPlanBaseCombo(string strPlanBase)
		{
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLAN_BASE", DbType.String, 5, ParameterDirection.Input)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if (strPlanBase != string.Empty) arrParam[1].Value = strPlanBase;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PLAN_BASE_COMBO";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			Plan oPlan;
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while (dr.Read())
				{
					//gaa20140507
				
					oPlan = new Plan();
					oPlan.PLANC_CODIGO = Funciones.CheckStr(dr["PLANC_CODIGO"]);
					oPlan.PLANV_DESCRIPCION = Funciones.CheckStr(dr["PLANV_DESCRIPCION"]);
					oPlan.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["PLANN_CAR_FIJ"]);
					oPlan.PLANC_EQUI_SAP = Funciones.CheckStr(dr["PLANC_EQUI_SAP"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNV_TIPO_PLAN"]);
					oPlan.GPLNV_DESCRIPCION = Funciones.CheckStr(dr["GPLNV_DESCRIPCION"]);
					oPlan.CODIGO_BSCS = Funciones.CheckStr(dr["CODIGO_BSCS"]);
					oPlan.TIPO_PRODUCTOS = Funciones.CheckStr(dr["TIPO_PRODUCTOS"]);
					oPlan.ServicioCodigo = Funciones.CheckStr(dr["SERVICIO"]);
					oPlan.ServicioDescripcion = Funciones.CheckStr(dr["SERVICIO_DES"]);
					//fin gaa20140507
					objLista.Add(oPlan);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return objLista;
		}

		public DataSet ListarDetalleLineaSISACT(string strTipoDoc, string strNroDoc, string strTelefono)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR_CAB", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CURSOR_DET", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LISTA_TELEFONO", DbType.String, 32767, ParameterDirection.Input),
			}; 

			if (strTipoDoc == ConfigurationSettings.AppSettings["TipoDocumentoRUC"].ToString())
				strNroDoc = Funciones.Right(strNroDoc + "     ", 16);
			else
				strNroDoc = Funciones.Right("0000000000000000" + strNroDoc, 16);

			arrParam[2].Value = strTipoDoc;
			arrParam[3].Value = strNroDoc;
			if (strTelefono != string.Empty) arrParam[4].Value = strTelefono;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_DETALLE_LINEA";
			obRequest.Parameters.AddRange(arrParam);
                  
			DataSet ds = null;
			try
			{
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return ds;
		}

		//gaa20130730
		public DataTable ListarServicioHFC(string pstrCodigo, string pstrDescripcion)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_SNCODE", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)}; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			if (pstrCodigo.Length > 0)
				arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrDescripcion;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = "PP021_VENTA_HFC.SP_SERVICIO_HCF";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}

		public DataTable ListarPlanHFC(string pstrCodigo, string pstrDescripcion)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_TMCODE", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)}; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			if (pstrCodigo.Length > 0)
				arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrDescripcion;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = "PP021_VENTA_HFC.SP_PLANES_HCF";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}
		//gaa20130826
		public DataTable ListarEquipoHFC(string pstrCodigo, string pstrDescripcion, out Int64 pintCodError, out string pstrMsjError)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("p_codtipequ", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_descripcion", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cur_equ", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_coderror", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_mensaje", DbType.String, ParameterDirection.Output)
			
											   }; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrDescripcion;

			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".lista_tip_equipo";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				pintCodError = 0;
				if (parSalida1.Value != System.DBNull.Value)
					pintCodError = Convert.ToInt64(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)obRequest.Parameters[4];
				pstrMsjError = string.Empty;
				if (parSalida2.Value != System.DBNull.Value)
					pstrMsjError = Convert.ToString(parSalida2.Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}

		public DataTable ListarCampanaHFC(string pstrDescripcion)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CAMPANHA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOM_CAMP", DbType.Object, ParameterDirection.Output)}; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrDescripcion;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = "PP021_VENTA_HFC.SP_CAMPANHAS";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}
		//fin gaa20130730
		//gaa20130923
		public DataTable ListarServicioCodExt(string pstrId, string pstrCodExt, out Int64 pintCodError, out string pstrMsjError)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("p_idconfigitw", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_codigo_ext", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cur_cod_ext", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_coderror", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_mensaje", DbType.String, ParameterDirection.Output)}; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			if (pstrId.Length > 0)
				arrParam[0].Value = pstrId;
			arrParam[1].Value = pstrCodExt;

			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PQ_INT_SISACT_CONSULTA + ".lista_codigo_externo";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				pintCodError = 0;
				if (parSalida1.Value != System.DBNull.Value)
					pintCodError = Convert.ToInt64(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)obRequest.Parameters[4];
				pstrMsjError = string.Empty;
				if (parSalida2.Value != System.DBNull.Value)
					pstrMsjError = Convert.ToString(parSalida2.Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}
		//fin gaa20130923
		//gaa20130916
		public DataTable ListarVendedorPP(string pstrTipo, string pstrDescripcion)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, ParameterDirection.Input)}; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = pstrTipo;
			arrParam[2].Value = pstrDescripcion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".mantss_listar_vendedor_pp";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}

		public DataTable ListarSupervisorPP(string pstrPosicion)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_POSICION", DbType.String, ParameterDirection.Input)}; 
	 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = pstrPosicion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".mantss_listar_supervisor_pp";

			obRequest.Parameters.AddRange(arrParam);
	                  
			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}

		public void InsertarVendedorPP(string pstrDNI, string pstrEmail, string pstrNombre, string pstrTelefono, string pstrPosicion, 
			string pstrSupervisor, string pstrUsuario, out string pstrRetorno)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DNI", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EMAIL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_POSICION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUPERVISOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RETORNO", DbType.String, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrDNI;
			arrParam[1].Value = pstrNombre;
			arrParam[2].Value = pstrEmail;
			arrParam[3].Value = pstrTelefono;
			arrParam[4].Value = pstrPosicion;
			arrParam[5].Value = pstrSupervisor;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_INSERT_VENDEDOR_PP";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[6];
				pstrRetorno = String.Empty;
				if (parSalida1.Value != System.DBNull.Value)
					pstrRetorno = Convert.ToString(parSalida1.Value);
			}
			catch( Exception ex )
			{				
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public void ModificarVendedorPP(string pstrCodigo, string pstrDNI, string pstrEmail, string pstrNombre, string pstrTelefono, string pstrPosicion, 
			string pstrSupervisor, string pstrEstado, string pstrUsuario, out string pstrRetorno)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DNI", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EMAIL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_POSICION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUPERVISOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RETORNO", DbType.String, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrDNI;
			arrParam[2].Value = pstrNombre;
			arrParam[3].Value = pstrEmail;
			arrParam[4].Value = pstrTelefono;
			arrParam[5].Value = pstrPosicion;
			arrParam[6].Value = pstrSupervisor;
			arrParam[7].Value = pstrEstado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_MODIFI_VENDEDOR_PP";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[8];
				pstrRetorno = String.Empty;
				if (parSalida1.Value != System.DBNull.Value)
					pstrRetorno = Convert.ToString(parSalida1.Value);
			}
			catch( Exception ex )
			{				
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public void DesactivarVendedorPP(string pstrCodigo, string pstrUsuario)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int64, ParameterDirection.Input)
											   }; 

			arrParam[0].Value = pstrCodigo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_DESACT_VENDEDOR_PP";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{				
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		//fin gaa20130916
		//--------------------------------------WHZR------------------------------------------


		public DataTable ObtenerNroLineaWhitelist(string  strTelefono, string strNroDoc)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NRO_LINEA", DbType.String , ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String , ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = strTelefono;
			arrParam[1].Value = strNroDoc;
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_WHIT_LINEA";

			obRequest.Parameters.AddRange(arrParam);

			DataTable dt = null;
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dt;
		}	

		public ArrayList ListarTipoItem(string strTipoItem)
		{
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.String, 50, ParameterDirection.Input)
											   };
			arrParam[1].Value = strTipoItem;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_ITEM";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem = null;
			IDataReader dr = null;

			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["ITEMN_CODIGO"]);
					objItem.Descripcion = Funciones.CheckStr(dr["ITEMN_DESCRIPCION"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}

			return objLista;
		}

		public DataSet ListarDetalleLineaBSCS(int tipoDocumento, string nroDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUR_CLIENTE", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CUR_DETALLE", DbType.Object, ParameterDirection.Output)
											   };
			int i = 0; arrParam[i].Value = tipoDocumento;
			i++; arrParam[i].Value = nroDocumento;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_BSCS_CONSULTA_CONS + ".SP_DETALLE_X_LINEA";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				return objRequest.Factory.ExecuteDataset(ref objRequest);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
		}

		public int ObtenerComportamientoPago(int tipoDocumento, string nroDocumento, ref ItemMensaje objMensaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_tip_doc", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_num_doc", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_indicador", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_cod_err", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msg_err", DbType.String, 100, ParameterDirection.Output)
											   };
			arrParam[0].Value = tipoDocumento;
			arrParam[1].Value = nroDocumento;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.Tim127CompPago;
			objRequest.Parameters.AddRange(arrParam);

			objMensaje = new ItemMensaje();
			int CP = 0, codError;
			bool blnOK;
			try
			{
				objRequest.Factory.ExecuteScalar(ref objRequest);
				IDataParameter p1, p2, p3;
				p1 = (IDataParameter)objRequest.Parameters[2];
				p2 = (IDataParameter)objRequest.Parameters[3];
				p3 = (IDataParameter)objRequest.Parameters[4];
				CP = Funciones.CheckInt(p1.Value);
				codError = Funciones.CheckInt(p2.Value);
				blnOK = (codError == 0);

				objMensaje = new ItemMensaje(Funciones.CheckStr(p2.Value), Funciones.CheckStr(p3.Value), blnOK);
			}
			catch (Exception ex)
			{
				objMensaje = new ItemMensaje(ex.Source, ex.Message, false);
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return CP;
		}

		public DataTable ListarCantPlanxBilleteraBSCS(int tipoDocumento, string nroDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUR_PLANES_PAQ", DbType.Object, ParameterDirection.Output)
											   };
			int i = 0; arrParam[i].Value = tipoDocumento;
			i++; arrParam[i].Value = nroDocumento;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_BSCS_CONSULTA_CONS + ".SP_DETALLE_X_LINEA_CANT_PLANES";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				return objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
		}

		public ArrayList ListarListaPrecioxCuota(string strCuota)
		{
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CUOTA", DbType.String, 4, ParameterDirection.Input)
											   };
			arrParam[1].Value = strCuota;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_LPRECIO_CUOTA";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem = null;
			IDataReader dr = null;

			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["LPRECIO"]);
					objItem.Codigo2 = Funciones.CheckStr(dr["CUOC_CODIGO"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}

			return objLista;
		}

		//PROY-24740
		public ArrayList ListarPlanTarifario(string strTipoDocumento, string strTipoOferta, string strTipoProducto, string strPlazo, string strCampana, string strFlujo, string strTipoOperacion, string strFamilia)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_OFERTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLUJO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_OPERACION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FAMILIA", DbType.String, 4, ParameterDirection.Input)
											   };

			int i = 0; 
			arrParam[i].Value = DBNull.Value;
			i++; arrParam[i].Value = strTipoDocumento;
			i++; arrParam[i].Value = strTipoOferta;
			i++; arrParam[i].Value = strTipoProducto;
			i++; arrParam[i].Value = strCampana;
			i++; arrParam[i].Value = strPlazo;
			i++; arrParam[i].Value = strFlujo;
			i++; arrParam[i].Value = strTipoOperacion;
//gaa20161027
			i++; arrParam[i].Value = strFamilia;
//fin gaa20161027
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_CON_PLAN_TARIFARIO_RENO";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			Plan objItem = null;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					objItem = new Plan();
					objItem.PLANC_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);
					objItem.PLANV_DESCRIPCION = Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					objItem.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["PLNN_CARGO_FIJO"]);
					objItem.PLANC_EQUI_SAP = Funciones.CheckStr(dr["PLNV_CODIGO_SAP"]);
					objItem.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNV_TIPO_PLAN"]);
					objItem.GPLNV_DESCRIPCION = Funciones.CheckStr(dr["GPLNV_DESCRIPCION"]);
					objItem.CODIGO_BSCS = Funciones.CheckStr(dr["PLNV_CODIGO_BSCS"]);
					objItem.TIPO_PRODUCTOS = Funciones.CheckStr(dr["TIPO_PRODUCTOS"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false)  dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarItemxPDV(int intTipoItem, string strOficina)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 10, ParameterDirection.Input)   
											   };
			int i = 0; 
			arrParam[i].Value = DBNull.Value;
			i++; arrParam[i].Value = intTipoItem;
			i++; arrParam[i].Value = strOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_FILTRO_ITEM_X_PDV";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["ITEM"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}
		
		//PROY-24740
		public ArrayList ListarCampana(string pstrOficina, string pstrOferta, string strTipoProducto, string strModalidad, string pstrFlujo, string pstrTipoOperacion)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_OFERTA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MODALIDAD_VENTA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLUJO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_OPERACION", DbType.String, 50, ParameterDirection.Input)
											   };
			int i = 0; arrParam[i].Value = DBNull.Value;
			i++; arrParam[i].Value = pstrOferta;
			i++; arrParam[i].Value = pstrOficina;
			i++; arrParam[i].Value = strTipoProducto;
			i++; arrParam[i].Value = strModalidad;
			i++; arrParam[i].Value = pstrFlujo;
			i++; arrParam[i].Value = pstrTipoOperacion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_CON_CAMPANA_RENO";
			objRequest.Parameters.AddRange(arrParam);

			ItemGenerico objItem = null;
			ArrayList objLista = new ArrayList();
			IDataReader dr= null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					objItem.Codigo2 = Funciones.CheckStr(dr["CAMPV_CODIGO_SAP"]);
					objItem.Descripcion = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
					objItem.Tipo = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		//PROY-24740
		public ArrayList ListarPlazo(string pstrTipoProducto, string pstrCasoEspecial, string pstrModalidadVenta)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output), 
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MODALIDAD_VENTA", DbType.String, 2, ParameterDirection.Input),                                          
			};
			int i = 0; arrParam[i].Value = DBNull.Value;
			i++; arrParam[i].Value = pstrTipoProducto;
			i++; arrParam[i].Value = pstrCasoEspecial;
			i++; arrParam[i].Value = pstrModalidadVenta;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_CON_PLAZO_ACUERDO";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					objItem.Descripcion = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);
					objItem.Codigo2 = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		//PROY-24740
		public ArrayList ListarServiciosXPlan(string pstrTipoProducto, string pstrPlan)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object ,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String, 4, ParameterDirection.Input)
											   };
			int i = 0; arrParam[i].Value = DBNull.Value;
			i++; arrParam[i].Value = pstrTipoProducto;
			i++; arrParam[i].Value = pstrPlan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_CON_PLAN_X_SERVICIO";
			objRequest.Parameters.AddRange(arrParam);

			Servicio_AP objItem = null;
			ArrayList objLista = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;					
				while(dr.Read())
				{
					objItem = new Servicio_AP();
					objItem.SERVV_CODIGO = Funciones.CheckStr(dr["servv_codigo"]);
					objItem.SERVV_DESCRIPCION = Funciones.CheckStr(dr["servv_descripcion"]);
					objItem.CARGO_FIJO_BASE = Funciones.CheckDbl(dr["psrvn_cargo_fijo"]);
					objItem.DESCUENTO_EN_PLAN = 0;
					objItem.GSRVC_CODIGO = Funciones.CheckStr(dr["gsrvc_codigo"]);
					objItem.SERVN_ORDEN = Funciones.CheckInt(dr["servn_orden"]);
					objItem.SELECCIONABLE_BASE = Funciones.CheckStr(dr["psrvv_seleccionable"]);
					objItem.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr["psrvv_seleccionable"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarPlanTopeConfig(string pstrPlan, string pstrCasoEspecial)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   };
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrPlan;
			arrParam[1].Value = pstrCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_CON_REGLAS_PLAN_SERVICIO";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			Servicio_AP objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new Servicio_AP();
					objItem.SERVV_CODIGO = Funciones.CheckStr(dr["SERVICIO"]);
					objItem.SELECCIONABLE_BASE = Funciones.CheckStr(dr["ESTADO"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}
		//fin gaa20150504

		public string ObtenerCampanaSap(string strCampana)
		{
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.Text;
			objRequest.Command = string.Format("select campv_codigo_sap from sisact_ap_campana s where s.campv_codigo = '{0}'", strCampana);

			string strCampanaSap;
			try
			{
				strCampanaSap = Funciones.CheckStr(objRequest.Factory.ExecuteScalar(ref objRequest));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return strCampanaSap;
		}

		//PROY-24740
		public ArrayList ListarCampanaNuevas(string pstrCombo, string strTipoProducto)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COMBO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO", DbType.String, ParameterDirection.Input)	
											   };
			int i = 0; arrParam[i].Value = DBNull.Value;
			i++; arrParam[i].Value = pstrCombo;
			i++; arrParam[i].Value = strTipoProducto;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".sp_con_campana_x_combo";
			objRequest.Parameters.AddRange(arrParam);

			ItemGenerico objItem = null;
			ArrayList objLista = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					objItem.Codigo2 = Funciones.CheckStr(dr["CAMPV_CODIGO_SAP"]);
					objItem.Descripcion = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
					objItem.Tipo = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarPlanCombo(string pstrCombo)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COMBO", DbType.String, ParameterDirection.Input)                                                                    
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;


			arrParam[1].Value = pstrCombo;


			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".sp_con_plan_x_combo";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					Plan oPlan = new Plan();
					oPlan.PLANC_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);
					oPlan.PLANV_DESCRIPCION = Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					oPlan.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["PLNN_CARGO_FIJO"]);
					oPlan.PLANC_EQUI_SAP = Funciones.CheckStr(dr["PLNV_CODIGO_SAP"]);
					oPlan.PLNN_TIPO_PLAN = Funciones.CheckInt(dr["PLNV_TIPO_PLAN"]);
					oPlan.GPLNV_DESCRIPCION = Funciones.CheckStr(dr["GPLNV_DESCRIPCION"]);
					oPlan.CODIGO_BSCS = Funciones.CheckStr(dr["PLNV_CODIGO_BSCS"]);
					oPlan.TIPO_PRODUCTOS = Funciones.CheckStr(dr["TIPO_PRODUCTOS"]);
					filas.Add(oPlan);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		//FIN 23112015
		//gaa20151929
		public bool ValidacionAccesoOpcionEP(string strCanal, string strProducto, string strTipoOperacion, string strTipoDocumento, string strTipoValidacion)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CANAL", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPOOPERACION", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPODOCUMENTO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPOVALIDACION", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO_RESPUESTA", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MENSAJE_RESPUESTA", DbType.String, 1000, ParameterDirection.Output)
											   };
			bool booResultado = true;
			arrParam[0].Value = strCanal;
			arrParam[1].Value = strProducto;
			arrParam[2].Value = strTipoOperacion;
			arrParam[3].Value = strTipoDocumento;
			arrParam[4].Value = strTipoValidacion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".SSAPSS_VALIDAEQPROM";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[5];
				booResultado = ((Funciones.CheckInt(parSalida1.Value) > 0) ? true : false);
			}
			catch
			{
				booResultado = false;
			}
			finally
			{
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			return booResultado;
		}
		//fin gaa20151929
		//gaa20160301 - MRAF
		public void ListarBloqueo(string strNroLinea, int intDiasBloqueo, string strTipoBloqueo, 
			out int intBloqueo, out int intDiasAntiguedad, out string strCampanaActual, 
			out int intComportamientoPago, out Int64 intCodRpta, out string strDesRpta)
		{
			DAABRequest.Parameter[] arrParam = {
												new DAABRequest.Parameter("P_LINEA", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_DIAS_BLOQSUSP", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("P_TIPO_BLOQUEO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_BLOQUEO", DbType.Int64, ParameterDirection.Output),
												new DAABRequest.Parameter("P_DIAS_ANTIGUEDAD", DbType.Int64, ParameterDirection.Output),
												new DAABRequest.Parameter("P_CAMPANA", DbType.String, ParameterDirection.Output),
												new DAABRequest.Parameter("P_COMP_PAGO", DbType.Int64, ParameterDirection.Output),
												new DAABRequest.Parameter("P_CODIGO_RESPUESTA", DbType.Int64, ParameterDirection.Output),
												new DAABRequest.Parameter("P_MENSAJE_RESPUESTA", DbType.String, ParameterDirection.Output)
											   }; 
                  
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = strNroLinea;
			arrParam[1].Value = intDiasBloqueo;
			arrParam[2].Value = strTipoBloqueo;
 
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.SISACT_PKG_VENTA_EXPRESS_6 + ".SISACSS_VAL_DIAS_SIN_BLOQSUSP";

			obRequest.Parameters.AddRange(arrParam);
                  
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				intBloqueo = Funciones.CheckInt(((IDataParameter)obRequest.Parameters[3]).Value);
				intDiasAntiguedad = Funciones.CheckInt(((IDataParameter)obRequest.Parameters[4]).Value);
				strCampanaActual = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value); 
				intComportamientoPago = Funciones.CheckInt(((IDataParameter)obRequest.Parameters[6]).Value);
				intCodRpta = Funciones.CheckInt64(((IDataParameter)obRequest.Parameters[7]).Value);
				strDesRpta = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[8]).Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}
		//fin gaa20160301
		//gaa20160318
		public void ListarSegmentoModalidadCuota(string pStrNroLinea, out string pStrCuota, 
			out string pstrModalidad, out string pstrSegmento, out Int64 pIntCodErr, out string pStrDesErr)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_LINEA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOTAS", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MODALIDAD", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SEGMENTO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("OUT_ERRNUM", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("OUT_ERRMSJ", DbType.String, ParameterDirection.Output)
											   }; 

			arrParam[0].Value = pStrNroLinea;
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACSS_DATOS_LINEA";

			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				pStrCuota = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[1]).Value);
				pstrModalidad = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[2]).Value);
				pstrSegmento = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[3]).Value); 
				pIntCodErr = Funciones.CheckInt64(((IDataParameter)obRequest.Parameters[4]).Value);
				pStrDesErr = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}
		//fin gaa20160318
		//gaa20160321
		//EMMH I
		public void ListarDesCanalxVendedor(string pStrCodVendedor, out string pStrDesCanal, out Int64 pIntCodRes, out string pStrDesRes)
		{
					DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("k_codvend", DbType.String, ParameterDirection.Input),
														new DAABRequest.Parameter("k_codvendsiapdv", DbType.String, ParameterDirection.Input),
														new DAABRequest.Parameter("K_RESULTADO", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("k_cod_resultado", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("k_msj_resultado", DbType.String, ParameterDirection.Output)
											   }; 

					for (int i=0; i<arrParam.Length;i++)
						arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pStrCodVendedor;
					arrParam[1].Value = null;
					pStrDesCanal = string.Empty;
 
			BDSIA obj = new BDSIA(BaseDatos.BD_SIAPDV);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_CONSULTA_PDV + ".SIAPDVSS_UBIGEO_POR_CODVEND";

			obRequest.Parameters.AddRange(arrParam);

					ArrayList filas = new ArrayList();
					IDataReader dr = null;
					try
					{
						dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				

						while(dr.Read())
						{
							ItemGenerico objCanal = new ItemGenerico();
							objCanal.Descripcion =Funciones.CheckStr(dr["canaldesc"]);
							filas.Add(objCanal);
							pStrDesCanal=Funciones.CheckStr(objCanal.Descripcion);
						}
						IDataParameter parSalida1;
						parSalida1 = (IDataParameter)obRequest.Parameters[3];
						pIntCodRes = Convert.ToInt32(parSalida1.Value);

						IDataParameter parSalida2;
						parSalida2 = (IDataParameter)obRequest.Parameters[4];
						pStrDesRes = Convert.ToString(parSalida2.Value);

					}
		                  
					catch(Exception e)
					{                       
						throw e;
					}
					finally
					{
						obRequest.Parameters.Clear();
						obRequest.Factory.Dispose();
					}
				}
		//EMMH F
		//fin gaa20160321
		//EMMH I
			public void ListarDesCanalxTofic(string pStrTofic, out string pStrDesCanal, out Int64 pIntCodRes, out string pStrDesRes)
			{
				DAABRequest.Parameter[] arrParam = {
													   new DAABRequest.Parameter("p_confi_codigo", DbType.Int64,ParameterDirection.Input),
													   new DAABRequest.Parameter("p_canac_codigo", DbType.String, ParameterDirection.Output),
													   new DAABRequest.Parameter("k_salida", DbType.String, ParameterDirection.Output),
													   new DAABRequest.Parameter("out_errnum", DbType.Int64, ParameterDirection.Output),
													   new DAABRequest.Parameter("out_errmsj", DbType.String, ParameterDirection.Output)
												   }; 

				arrParam[0].Value = pStrTofic;
 
				BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				DAABRequest obRequest = obj.CreaRequest();
				obRequest.CommandType = CommandType.StoredProcedure;  
				obRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".sisactss_configcodigo";

				obRequest.Parameters.AddRange(arrParam);
                  
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				pStrDesCanal = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[8]).Value);
				pIntCodRes = Funciones.CheckInt64(((IDataParameter)obRequest.Parameters[9]).Value);
				pStrDesRes = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[10]).Value);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}
//EMMH F  - MRAF FIN
		//PROY-24740
//Inicio Plan No Vig
		//Lista de Campanas asociadas al plan no vigente
		public ArrayList ListarCampanaNoVig(string pstrOficina, string pstrOferta, string strTipoProducto, string strModalidad, string pstrFlujo, string pstrTipoOperacion,string pstrPlanCodigoPlan,string pstrCampanasPlanNoVig)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_OFERTA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MODALIDAD_VENTA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLUJO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_OPERACION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANAS_NOVIG", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, 50, ParameterDirection.Input)
											   };

			int i = 0; arrParam[i].Value = DBNull.Value;
			i++; arrParam[i].Value = pstrOferta;
			i++; arrParam[i].Value = pstrOficina;
			i++; arrParam[i].Value = strTipoProducto;
			i++; arrParam[i].Value = strModalidad;
			i++; arrParam[i].Value = pstrFlujo;
			i++; arrParam[i].Value = pstrTipoOperacion;
			i++; arrParam[i].Value = pstrCampanasPlanNoVig;
			i++; arrParam[i].Value = pstrPlanCodigoPlan;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_CON_CAMPANA_RENO_NOVIG";
			objRequest.Parameters.AddRange(arrParam);

			ItemGenerico objItem = null;
			ArrayList objLista = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					objItem.Codigo2 = Funciones.CheckStr(dr["CAMPV_CODIGO_SAP"]);
					objItem.Descripcion = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
					objItem.Tipo = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}
		//Fin Plan No Vig	

		//Inicio Renovacion Por Bloqueo JAZ
		public void  ListarLineasConBloqueo(string pstrCoId, string pstrNumeroDoc, string pstrTipoBusqueda, ref ArrayList pobjListaDetalleBloqueo,ref string pstrCodRespuesta)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CO_ID",DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOCUMENTO", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_ASOCIADO", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUR_SALIDA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSGERR", DbType.String, 500, ParameterDirection.Output)												   
											   };

			int i = 0;
			arrParam[i].Value = pstrCoId;
			i++; arrParam[i].Value = pstrNumeroDoc;
			i++; arrParam[i].Value = pstrTipoBusqueda;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;			
			objRequest.Command = BaseDatos.TIM_SISACT_PKG_VENTA_EXPRESS_6 + ".SP_SISACTSS_VALIDA_RENOV";
			objRequest.Parameters.AddRange(arrParam);

			LineaBloqueo objItem = null;
			ArrayList objListaDetalleBloqueo = new ArrayList();			

			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;

				while (dr.Read())
				{
					objItem = new LineaBloqueo();
					objItem.LINEA = Funciones.CheckStr(dr["DN_NUM"]);
					objItem.CUSTOMER_ID = Funciones.CheckStr(dr["CUSTOMER_ID"]);
					objItem.CO_ID = Funciones.CheckStr(dr["CO_ID"]);
					objItem.TICKLER = Funciones.CheckStr(dr["TICKLER_CODE"]);
					objItem.DESCRIPCION = Funciones.CheckStr(dr["SHORT_DESCRIPTION"]);
					objItem.DESCRIPCION_LARGA = Funciones.CheckStr(dr["LONG_DESCRIPTION"]);
					
					objListaDetalleBloqueo.Add(objItem);
				}

				pobjListaDetalleBloqueo = objListaDetalleBloqueo;	
				
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[4];
				pstrCodRespuesta = Funciones.CheckStr(parSalida1.Value);

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();				
			}			
		}

		//Fin Renovacion Por Bloqueo JAZ
		//gaa20161020
		public ArrayList ListarFamiliaPlan(string strModalidad, string strCampana)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output)/*,
												   new DAABRequest.Parameter("P_MODALIDAD", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FAMILIAPLAN", DbType.String, 4, ParameterDirection.Input)*/
											   };
			arrParam[0].Value = DBNull.Value;/*
			arrParam[1].Value = strModalidad;
			arrParam[2].Value = strCampana;
			arrParam[3].Value = DBNull.Value;*/

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACSS_FAMILIAPLAN";
			objRequest.Parameters.AddRange(arrParam);

			filas = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["FAMILIA_PLAN"]);
					objItem.Descripcion = Funciones.CheckStr(dr["FAMILIA_DES"]);
					filas.Add(objItem);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return filas;
		}
		//fin gaa20161020
		//Inicio SD1052592
		public double ConsultarCargoFijo(string coID)
		{
			double cargoFijo;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("PI_CO_ID", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PO_CARGO_FIJO", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("PO_CODE_RESP", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("PO_MSG_RESP", DbType.String, ParameterDirection.Output)
											   };

			arrParam[0].Value = coID;
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = "TIM.SISACTS_DETALLE_CF_X_CONTRATO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[1];
				cargoFijo = Funciones.CheckDbl(parSalida1.Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return cargoFijo;
		}
		//Fin - SD1052592
		//INICIO PROY-31008
		public Boolean RetornarTopeCero(double intcoid, double strsncode)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("p_co_id", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_sncode", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("result", DbType.String, ParameterDirection.ReturnValue)}; 
			arrParam[0].Value = intcoid;
			arrParam[1].Value = strsncode;
			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = "TFUN015_ESTADO_SERVICIO";
			obRequest.Parameters.AddRange(arrParam);
			
			Boolean TopeCero;
			string valor;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter p1;
				p1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				valor = Funciones.CheckStr(p1.Value);
				if ((valor).ToUpper() == "A")
					TopeCero = true;
				else
					TopeCero=false;

			}
			catch (Exception)
			{				
				TopeCero = false;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return TopeCero;
		}
	
	    //FIN PROY-31008
	}
}
