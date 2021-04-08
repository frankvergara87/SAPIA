using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

using System.Configuration;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for ConsultaSolicitud.
	/// </summary>
	public class SolicitudDatos
	{
		public SolicitudDatos(){}

		public bool ModificacionEvaluacionNaturalConsumer(VistaSolicitud objVistaSolicitud)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO" ,DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLA_TER" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_TEL_LEG" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_LEG" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIRECCION" ,DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_DIR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_DIR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_DIR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_DIR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR_FAC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIR_FAC" ,DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR_FAC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_FAC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_FAC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_FAC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_FAC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR_TRA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIR_TRA" ,DbType.String,2000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR_TRA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_TRA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_TRA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_TRA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_TRA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_REF_1" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_REF_2" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_FIJ_TRA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_CRE_FIN" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCO_TXT_FIN" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SCO_NUM_FIN" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_MAX_FIN" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_POSTCONTROL" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RDIRC_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RFINC_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MRECC_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_DG" ,DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TEVAC_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_EST" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TAFIC_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_TAR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_TIP_MON" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_TAR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NOM_TIT_TAR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DOC_TIT_TAR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FEC_VEN_TAR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_MNTOMAX" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_OPE_FIN" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RUCEMPLEADOR" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBREEMPRESA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TACTC_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_APROB" ,DbType.String,ParameterDirection.Input),
                                                                                                   //INICIO - E75688
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC" ,DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_CLIEV_EST_CIV" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TITUC_CODIGO" ,DbType.String,ParameterDirection.Input)
												   //FIN  -E75688
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = 0;
			arrParam[1].Value = objVistaSolicitud.solin_codigo;
			arrParam[2].Value = objVistaSolicitud.solic_fla_ter;
			arrParam[3].Value =	objVistaSolicitud.cliev_pre_tel_leg;
			arrParam[4].Value =	objVistaSolicitud.cliev_tel_leg;
			arrParam[5].Value =	objVistaSolicitud.cliev_pre_dir;
			arrParam[6].Value =	objVistaSolicitud.cliev_direccion;
			arrParam[7].Value =	objVistaSolicitud.cliev_ref_dir;
			arrParam[8].Value =	objVistaSolicitud.cliec_cod_dep_dir;
			arrParam[9].Value =	objVistaSolicitud.cliec_cod_pro_dir;
			arrParam[10].Value = objVistaSolicitud.cliec_cod_dis_dir;
			arrParam[11].Value = objVistaSolicitud.cliec_cod_pos_dir;
			arrParam[12].Value = objVistaSolicitud.cliev_pre_dir_fac;
			arrParam[13].Value = objVistaSolicitud.cliev_dir_fac;
			arrParam[14].Value = objVistaSolicitud.cliev_ref_dir_fac;
			arrParam[15].Value = objVistaSolicitud.cliec_cod_dep_fac;
			arrParam[16].Value = objVistaSolicitud.cliec_cod_pro_fac;
			arrParam[17].Value =objVistaSolicitud.cliec_cod_dis_fac;
			arrParam[18].Value =objVistaSolicitud.cliec_cod_pos_fac;
			arrParam[19].Value =objVistaSolicitud.cliev_pre_dir_tra;
			arrParam[20].Value =objVistaSolicitud.cliev_dir_tra;
			arrParam[21].Value =objVistaSolicitud.cliev_ref_dir_tra;
			arrParam[22].Value =objVistaSolicitud.cliec_cod_dep_tra;
			arrParam[23].Value =objVistaSolicitud.cliec_cod_pro_tra;
			arrParam[24].Value =objVistaSolicitud.cliec_cod_dis_tra;
			arrParam[25].Value =objVistaSolicitud.cliec_cod_pos_tra;
			arrParam[26].Value =objVistaSolicitud.cliev_tel_ref_1;
			arrParam[27].Value =objVistaSolicitud.cliev_tel_ref_2;
			arrParam[28].Value =objVistaSolicitud.cliev_tel_fij_tra;
			arrParam[29].Value =objVistaSolicitud.solin_lim_cre_fin;
			arrParam[30].Value =objVistaSolicitud.solic_sco_txt_fin;
			arrParam[31].Value =objVistaSolicitud.solin_sco_num_fin;
			arrParam[32].Value =objVistaSolicitud.solin_lim_max_fin;
			arrParam[33].Value =objVistaSolicitud.solic_postcontrol;
			arrParam[34].Value =objVistaSolicitud.rdirc_codigo;
			arrParam[35].Value =objVistaSolicitud.rfinc_codigo;
			arrParam[36].Value =objVistaSolicitud.mrecc_codigo;
			arrParam[37].Value =objVistaSolicitud.solin_imp_dg_man;
			arrParam[38].Value =objVistaSolicitud.solic_tip_car_man;
			arrParam[39].Value =objVistaSolicitud.soliv_com_dg;
			arrParam[40].Value =objVistaSolicitud.tevac_codigo;
			arrParam[41].Value =objVistaSolicitud.estac_codigo;
			arrParam[42].Value = objVistaSolicitud.soliv_des_est;
			arrParam[43].Value =objVistaSolicitud.solic_usu_cre;
			arrParam[44].Value =objVistaSolicitud.tafic_codigo;
			arrParam[45].Value =objVistaSolicitud.solic_cod_tar;
			arrParam[46].Value =objVistaSolicitud.solic_cod_tip_mon;
			arrParam[47].Value =objVistaSolicitud.soliv_num_tar;
			arrParam[48].Value =objVistaSolicitud.soliv_nom_tit_tar;
			arrParam[49].Value =objVistaSolicitud.soliv_doc_tit_tar;
			arrParam[50].Value =objVistaSolicitud.soliv_fec_ven_tar;
			arrParam[51].Value =objVistaSolicitud.solin_mntomax;
			arrParam[52].Value =objVistaSolicitud.soliv_num_ope_fin;
			arrParam[53].Value =objVistaSolicitud.topen_codigo;
			arrParam[54].Value =objVistaSolicitud.rucempleador;
			arrParam[55].Value =objVistaSolicitud.nombreempresa;
			arrParam[56].Value =objVistaSolicitud.TACTC_CODIGO;
			arrParam[57].Value =objVistaSolicitud.SOLIC_COD_APROB;
			//INICIO - E75688
			arrParam[58].Value =objVistaSolicitud.CLIED_FEC_NAC;
			arrParam[59].Value =objVistaSolicitud.CLIEV_EST_CIV;
			arrParam[60].Value =objVistaSolicitud.TITULO_PERSONA_COD;
			//FIN - E75688
				
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSU_ACT_SOL_NAT_CONS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

                public bool GrabarFlagTerminadoSol_Cons(string P_SOLIN_CODIGO, string P_SOLIC_USU_CRE,double P_SOLIN_ING_SUS, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLAG_ENVIO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_ING_SUS", DbType.Double,ParameterDirection.Input)};
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = P_SOLIN_CODIGO;			
			i++; arrParam[i].Value = P_SOLIC_USU_CRE;
			i++; arrParam[i].Value = "1";
			i++; arrParam[i].Value = P_SOLIN_ING_SUS;
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACU_ACT_SOL_TERMINAR_CONS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Actualizar el Flag Terminar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
					
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];				
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public bool ValidarEvaluacion(VistaSolicitudEvaluacion objEntidad)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO" ,DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ_ADI" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_RA" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_PUN_VEN" ,DbType.String,500,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_EVAL" ,DbType.String,500,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_APROB" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NOMBRE" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_PAT" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_MAT" ,DbType.String,ParameterDirection.Input),
												   // Edición EsSalud/Sunat
												   new DAABRequest.Parameter("P_ESS_NUEVO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUN_NUEVO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC", DbType.Date,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_REINGRESO_SEC", DbType.String, 2, ParameterDirection.Input)
												   //gaa20120518
												   ,new DAABRequest.Parameter("P_SOLIN_COST_INST", DbType.Double, ParameterDirection.Input)
												   //fin gaa20120518
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = objEntidad.SOLIN_CODIGO ;
			++i; arrParam[i].Value = objEntidad.ESTAC_CODIGO;
			++i; arrParam[i].Value = Convert.ToDouble(objEntidad.SOLIN_NUM_CAR_FIJ_ADI);
			++i; arrParam[i].Value = Convert.ToDouble(objEntidad.SOLIN_NUM_RA);
			++i; arrParam[i].Value = Convert.ToDouble(objEntidad.SOLIN_IMP_DG_MAN);
			++i; arrParam[i].Value = objEntidad.SOLIV_COM_PUN_VEN ;
			++i; arrParam[i].Value = objEntidad.SOLIV_COM_EVAL;
			++i; arrParam[i].Value = objEntidad.SOLIC_TIP_CAR_MAN;
			++i; arrParam[i].Value = objEntidad.SOLIC_COD_APROB;
			++i; if (objEntidad.CLIEV_NOMBRE != "") { arrParam[i].Value = objEntidad.CLIEV_NOMBRE; }
			++i; if (objEntidad.CLIEV_APE_PAT != "") { arrParam[i].Value = objEntidad.CLIEV_APE_PAT; }
			++i; if (objEntidad.CLIEV_APE_MAT != "") { arrParam[i].Value = objEntidad.CLIEV_APE_MAT; }
			
			// Edición EsSalud/Sunat
			++i; if (objEntidad.SOLIC_EVA_ESS != "") { arrParam[i].Value = objEntidad.SOLIC_EVA_ESS; }
			++i; if (objEntidad.SOLIC_EVA_SUN != "") { arrParam[i].Value = objEntidad.SOLIC_EVA_SUN; }

			++i; if (objEntidad.FECHA_NACIMIENTO != new DateTime(1,1,1)) { arrParam[i].Value = objEntidad.FECHA_NACIMIENTO; }
			++i; if (objEntidad.FLAG_REINGRESO_SEC != "") { arrParam[i].Value = objEntidad.FLAG_REINGRESO_SEC; }
			//gaa20120518
			++i; arrParam[i].Value = Convert.ToDouble(objEntidad.SOLIN_COSTO_INST);
			//fin gaa20120518												
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACU_APROB_ANUL_SECT_DC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			bool salida = false;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();			
				throw ex;
			}
			finally
			{				
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public ArrayList ObtenerConsultaSolicitudCons(string nroSEC, string tipoDocumento,string nroDocumento)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(tipoDocumento != "") arrParam[0].Value = tipoDocumento;
			if(nroDocumento != "") arrParam[1].Value = nroDocumento;
			if(nroSEC!= "") arrParam[2].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSS_CON_SOL_CONS";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ConsultaSolicitud item = new ConsultaSolicitud();					
					item.SOLIN_CODIGO = Funciones.CheckStr(dr["SOLIN_CODIGO"]);
					item.TPROV_DESCRIPCION = Funciones.CheckStr(dr["TPROV_DESCRIPCION"]);
					item.SEGMV_DESCRIPCION = Funciones.CheckStr(dr["SEGMV_DESCRIPCION"]);
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]);
					item.TVENV_DESCRIPCION = Funciones.CheckStr(dr["TVENV_DESCRIPCION"]);
					item.SOLID_FEC_REG = Funciones.CheckDate(dr["SOLID_FEC_REG"]);
					item.SOLID_FEC_APR = Funciones.CheckDate(dr["SOLID_FEC_APR"]);
					if ( Funciones.CheckDate(dr["SOLID_FEC_APR"]) != DateTime.MinValue )
						item.SOLID_FEC_APR_STR = Funciones.CheckStr(Funciones.CheckDate(dr["SOLID_FEC_APR"]));
					else
						item.SOLID_FEC_APR_STR = "";
					item.CLIEV_NOMBRE = Funciones.CheckStr(dr["CLIEV_NOMBRE"]);
					item.CLIEV_APE_PAT = Funciones.CheckStr(dr["CLIEV_APE_PAT"]);
					item.CLIEV_APE_MAT = Funciones.CheckStr(dr["CLIEV_APE_MAT"]);
					item.CLIEV_RAZ_SOC = Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]);
					item.TDOCC_CODIGO = Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.CLIEC_NUM_DOC = Funciones.NroDocumentoIdentidad(Funciones.CheckStr(dr["TDOCC_CODIGO"]),Funciones.CheckStr(dr["CLIEC_NUM_DOC"]));
					item.ESTAC_CODIGO = Funciones.CheckStr(dr["ESTAC_CODIGO"]);
					item.MRECC_CODIGO = Funciones.CheckStr(dr["MRECC_CODIGO"]);
					item.MRECV_DESCRIPCION = Funciones.CheckStr(dr["MRECV_DESCRIPCION"]);
					item.SOLIC_FLA_TER = Funciones.CheckStr(dr["SOLIC_FLA_TER"]);
					item.TEVAC_CODIGO = Funciones.CheckStr(dr["TEVAC_CODIGO"]);
					item.TACTC_CODIGO = Funciones.CheckStr(dr["TACTC_CODIGO"]);
					item.TACTV_DESCRIPCION = Funciones.CheckStr(dr["TACTV_DESCRIPCION"]);					
					item.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
					item.SOLIN_IMP_DG = Funciones.CheckStr(dr["SOLIN_IMP_DG"]);
					item.RDIRC_CODIGO = Funciones.CheckStr(dr["RDIRC_CODIGO"]);
					item.RDIRV_DESCRIPCION = Funciones.CheckStr(dr["RDIRV_DESCRIPCION"]);
					item.MRDIV_CAD_CODIGO = Funciones.CheckStr(dr["MRDIV_CAD_CODIGO"]);
					item.TIPO_GARANTIA_DES= Funciones.CheckStr(dr["TCARV_DESCRIPCION_MAN"]);
					item.CANTIDAD_CARGOS_FIJOS= Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ"]);
					item.SOLIC_TIPO_EVALUACION= Funciones.CheckStr(dr["SOLIC_TIPO_EVALUACION"]);
					item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);
					item.SOLIV_MOTIVO_RECHAZO = Funciones.CheckStr(dr["SOLIV_MOTIVO_RECHAZO"]);
					//item.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);
					
					//INICIO - E75688	  
						//*******************Se comento por DESIN 33870-1	   	**************************//	
						//if (item.CLIEV_NOMBRE != "" && item.CLIEV_APE_PAT != "")
							//item.CLIEV_RAZ_SOC = item.CLIEV_NOMBRE + " " + item.CLIEV_APE_PAT + " " + item.CLIEV_APE_MAT ;
					//FIN - E75688					

					//T12618 - Portabilidad - INICIO
					item.FLAG_PORTABILIDAD = Funciones.CheckStr(dr["FLAG_PORTABILIDAD"]);
					//T12618 - Portabilidad - FIN

                                        item.ESTAC_CODIGO = Funciones.CheckStr(dr["ESTAC_CODIGO"]);
					item.SOLIC_COD_APROB = Funciones.CheckStr(dr["SOLIC_COD_APROB"]);

                                        //INICIO - E75688
					item.CLIEV_FLAG_CORREO = Funciones.CheckStr(dr["CLIEV_FLAG_CORREO"]);
					item.CLIEV_CORREO = Funciones.CheckStr(dr["CLIEV_CORREO"]);
					item.CLIEV_TEL_SMS = Funciones.CheckStr(dr["CLIEV_TEL_SMS"]);
					item.CLIED_FEC_NAC = Funciones.CheckDate(dr["CLIED_FEC_NAC"]);
					item.CLIEV_EST_CIV = Funciones.CheckStr(dr["CLIEV_EST_CIV"]);
					item.TITULO_PERSONA_COD = Funciones.CheckStr(dr["TITULO_COD"]);
					//FIN - E75688
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

	
	        public ArrayList ObtenerSolicitudes(string nroSEC_grupo)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_GRUPO_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC_grupo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 	
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SP_SOLICITUDES_VENTA";
			obRequest.Parameters.AddRange(arrParam);
						
			IDataReader dr = null;
			ArrayList fila = new ArrayList();
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{			
					SolicitudPersona item = new SolicitudPersona();
					item.SOLIN_CODIGO		= Funciones.CheckInt64(dr["SOLIN_CODIGO"]);	
					item.PRDV_DESCRIPCION	= Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);	
					item.SOLIN_GRUPO_SEC	= Funciones.CheckInt64(dr["SOLIN_GRUPO_SEC"]);	
					item.SOLIN_USU_VEN		= Funciones.CheckStr(dr["SOLIN_USU_VEN"]);	
					item.PRDC_CODIGO		= Funciones.CheckStr(dr["PRDC_CODIGO"]);	
					item.PACUC_CODIGO		= Funciones.CheckStr(dr["PACUC_CODIGO"]);

					item.SOLIN_IMP_DG		= Funciones.CheckStr(dr["SOLIN_IMP_DG"]);						
					item.SOLIC_TIP_CAR_FIJ	= Funciones.CheckStr(dr["SOLIC_TIP_CAR_FIJ"]);	
					item.TIPO_GARANTIA_DES	= Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);	
					item.SOLIN_IMP_DG_MAN	= Funciones.CheckDbl(dr["SOLIN_IMP_DG_MAN"]);	
					item.SOLIC_TIP_CAR_MAN	= Funciones.CheckStr(dr["SOLIC_TIP_CAR_MAN"]);
					item.TCARV_DESCRIPCION	= Funciones.CheckStr(dr["TCARV_DESCRIPCION_MAN"]);					

					item.SOLIN_SUM_CAR_CON	= Funciones.CheckDbl(dr["SOLIN_SUM_CAR_CON"]);		
					
					item.TDOCC_CODIGO		= Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.CLIEC_NUM_DOC		= Funciones.NroDocumentoIdentidad(Funciones.CheckStr(dr["TDOCC_CODIGO"]),Funciones.CheckStr(dr["CLIEC_NUM_DOC"]));					
					item.CLIEV_NOMBRE		= Funciones.CheckStr(dr["CLIEV_NOMBRE"]);
					item.CLIEV_RAZ_SOC		= Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]);
					item.CLIEV_APE_PAT		= Funciones.CheckStr(dr["CLIEV_APE_PAT"]);
					item.CLIEV_APE_MAT		= Funciones.CheckStr(dr["CLIEV_APE_MAT"]);
					item.FECHA_NACIMIENTO	= Funciones.CheckDate(dr["CLIED_FEC_NAC"]);					
					item.ESTADO_CIVIL_DES   = Funciones.CheckStr(dr["CLIEV_EST_CIV"]);
					item.SOLIV_CORREO		= Funciones.CheckStr(dr["CLIEV_CORREO"]);
					item.OVENC_CODIGO		= Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.OVENV_DESCRIPCION	= Funciones.CheckStr(dr["SOLIV_DES_OFI_VEN"]);
					item.SOLIC_SCO_TXT_CON	= Funciones.CheckStr(dr["SOLIC_SCO_TXT_CON"]);
					item.SOLIN_SCO_NUM_CON	= Funciones.CheckDbl(dr["SOLIN_SCO_NUM_CON"]);
					item.TPROC_CODIGO		= Funciones.CheckStr(dr["TPROC_CODIGO"]);
					item.TVENC_CODIGO		= Funciones.CheckStr(dr["TVENC_CODIGO"]);
					item.TOPEN_CODIGO		= Funciones.CheckStr(dr["TOPEN_CODIGO"]);
					item.TCESC_CODIGO = Funciones.CheckStr(dr["TCESC_CODIGO"]);
					item.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);

					//Renovacion
					item.NUMERO_LINEA = Funciones.CheckStr(dr["NUMERO_LINEA"]);

					fila.Add(item);
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
			return fila;
		}

		public bool RegistrarEvaluacionNaturalReingreso(string strDatosSolicitud, ref string rMsg)
		{
			string[] arrDBSolicitud = strDatosSolicitud.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO" ,DbType.Double,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OVENC_CODIGO" ,DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_USU_VEN" ,DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_FIN" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALC_CODIGO" ,DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC" ,DbType.AnsiStringFixedLength,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RAZ_SOC" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_PROM_VEN" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGMN_CODIGO" ,DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCLIC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TACTC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO" ,DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_1" ,DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_2" ,DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_3" ,DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FPAGC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN" ,DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RFINC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MRECC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN" ,DbType.String,14,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TEVAC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLA_TER" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_EST" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_OFI_VEN" ,DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_FIN" ,DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_TIP_ACT" ,DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_PUN_VEN" ,DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_EVALUADOR" ,DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE" ,DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NOM" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_PAT" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_MAT" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_DIR" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DIRECCION" ,DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_REFERENCIA" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DEP_1" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_PRO_1" ,DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DIS_1" ,DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COD_POS_1" ,DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_TEL" ,DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TELEFONO" ,DbType.String,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_DIR_TRA" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DIR_TRA" ,DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_REF_TRA" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DEP_3" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_PRO_3" ,DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DIS_3" ,DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_POS_3" ,DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_REF_1" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_REF_1" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_REF_2" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_REF_2" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_CON_TRA" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_FIJ_TRA" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EVA_ESS" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EVA_SUN" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_RES_DIR" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_DIR" ,DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CAR_CLI" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_FIJ" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_RES_EXP_CON" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_OPE_CON" ,DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_CRE_CON" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_CON" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCESC_CODIGO" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCO_TXT_CON" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SCO_NUM_CON" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO_PADRE" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_INFOCORP" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HINFV_MENSAJE" ,DbType.String,1000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RUCEMPLEADOR" ,DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBREEMPRESA" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCAMPANNA" ,DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_CON" ,DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR_ID" ,DbType.String,8,ParameterDirection.Input),
												   /*TeamSoft - E72373 (Inicio)*/
												   new DAABRequest.Parameter("P_FLAG_CONSUMO" ,DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   /*TeamSoft - E72373 (Fin)*/

												   //INICIO - E75688
												   new DAABRequest.Parameter("P_SOLIV_FLAG_CORR", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CORREO", DbType.String, 200, ParameterDirection.Input),
												   //FIN - E75688
												   	/*CosapiSoft - E76009 (Inicio)*/
													new DAABRequest.Parameter("P_CLIEV_EST_CIV" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIV_UBIGEO_INEI" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIC_ORIGEN_LC_DC" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIC_ANALISIS_DC" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIC_SCORE_RANKING_OPER_DC" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIN_PUNTAJE_DC" ,DbType.Double,ParameterDirection.Input),                                                                
													new DAABRequest.Parameter("P_SOLIN_LC_DATA_CREDITO_DC" ,DbType.Double,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIN_LC_BASE_EXTERNA_DC" ,DbType.Double,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIN_LC_CLARO_DC" ,DbType.Double,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIC_REGLAS_DURAS_DC" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIC_ALERT_COMPORT_DC" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIC_ALERTAS_DC" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_SOLIC_CORRESP_SALDO_DC" ,DbType.String,40,ParameterDirection.Input),
													new DAABRequest.Parameter("P_CLIED_FEC_NAC" ,DbType.Date,ParameterDirection.Input)
													/*CosapiSoft - E76009 (Fin)*/
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			for (i=1; i<arrParam.Length;i++)
				arrParam[i].Value = arrDBSolicitud[i-1].Trim();

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Parameters.Clear();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSI_INS_SOL_NAT_REINGRESO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar la Solicitud. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool AnularSEC(string nroSEC,string strResultadoFinal, string strEstado)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RFINC_CODIGO" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_ESTAC_CODIGO" ,DbType.String,2,ParameterDirection.Input)
											    }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = Funciones.CheckDbl(nroSEC);
			arrParam[1].Value = strResultadoFinal;
			arrParam[2].Value = strEstado;

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Parameters.Clear();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SECP_PKG_SOLICITUDES + ".SECSS_ACT_ESTADO_SOLICITUD";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				salida = false;
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];				
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarPlanSolicitud(PlanDetalleConsumer objDetalle)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLC_MONTO_TOTAL" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_MONTO_UNIT" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_CODIGO" ,DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_CANTIDAD" ,DbType.Int64,ParameterDirection.Input)
											   }; 
 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[1].Value = objDetalle.SOLIN_CODIGO;
			arrParam[2].Value = objDetalle.SOPLC_MONTO_TOTAL;
			arrParam[3].Value = objDetalle.SOPLN_MONTO_UNIT;
			arrParam[4].Value = objDetalle.PLANC_CODIGO;
			arrParam[5].Value = objDetalle.TPROC_CODIGO;
			arrParam[6].Value = objDetalle.SOPLN_CANTIDAD;
 
			bool salida = false;
                                   
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);    
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;                   
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_INSERTAR_SOL_PLANES";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
		catch( Exception ex )
		{
			obRequest.Factory.RollBackTransaction();              
			throw ex;
			}
			finally
			{                            
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				obRequest.Factory.Dispose();
			}                 
			return salida ;
	}

		//Renovacion

		public DataTable ConsultaEstadoSOT(long intNroSOT)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("an_codsolot", DbType.Int64 , ParameterDirection.Input),												   
												   new DAABRequest.Parameter("ao_cursor", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("an_codigo_error", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("ac_mensaje_error", DbType.String,ParameterDirection.Output)	
												   
											   }; 

			int i = 0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = intNroSOT;			
			
			BDSGA obj = new BDSGA(BaseDatos.BD_SGA);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;			
			objRequest.Command = BaseDatos.PKG_INTEGRACION_DTH + ".p_consulta_solot";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}
	
		public string ValidarVendedorDNI(string pstrNroDocumento)
		{
			string salida = string.Empty; 
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrNroDocumento;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_VALI_VEND_DOCU"; 
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];

				salida = Funciones.CheckStr(parSalida1.Value);
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
			return salida;
		}

		public ArrayList ConsultarSolDireccion(Int64 nroSEC)
		{
			ArrayList filas;
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input)}; 
			arrParam[1].Value = nroSEC;
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_CON_SOL_DIRECCION";
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					DireccionCliente oDireccion = new DireccionCliente();
					oDireccion.IdTipoDireccion = Funciones.CheckStr(dr["TIPO_DIR"]);
					oDireccion.IdPrefijo = Funciones.CheckStr(dr["ID_PREFIJO"]);
					oDireccion.Prefijo = Funciones.CheckStr(dr["PREFIJO"]);
					oDireccion.Direccion = Funciones.CheckStr(dr["DIRECCION"]);
					oDireccion.NroPuerta = Funciones.CheckStr(dr["NRO_PUERTA"]);
					oDireccion.IdEdificacion = Funciones.CheckStr(dr["ID_EDIFICACION"]);
					oDireccion.Edificacion = Funciones.CheckStr(dr["EDIFICACION"]);
					oDireccion.Manzana = Funciones.CheckStr(dr["MANZANA"]);
					oDireccion.Lote = Funciones.CheckStr(dr["LOTE"]);
					oDireccion.IdTipoInterior = Funciones.CheckStr(dr["ID_INTERIOR"]);
					oDireccion.TipoInterior = Funciones.CheckStr(dr["TIPO_INTERIOR"]);
					oDireccion.NroInterior = Funciones.CheckStr(dr["NRO_INTERIOR"]);
					oDireccion.IdUrbanizacion = Funciones.CheckStr(dr["ID_URBANIZACION"]);
					oDireccion.Urbanizacion = Funciones.CheckStr(dr["URBANIZACION"]);
					oDireccion.TxtUrbanizacion = Funciones.CheckStr(dr["TXT_URBANIZACION"]);
					oDireccion.IdDomicilio = Funciones.CheckStr(dr["ID_DOMICILIO"]);
					oDireccion.Domicilio = Funciones.CheckStr(dr["DOMICILIO"]);
					oDireccion.IdZona = Funciones.CheckStr(dr["ID_ZONA"]);
					oDireccion.Zona = Funciones.CheckStr(dr["ZONA"]);
					oDireccion.NombreZona = Funciones.CheckStr(dr["NOMBRE_ZONA"]);
					oDireccion.Referencia = Funciones.CheckStr(dr["REFERENCIA"]);
					oDireccion.Referencia_Sec = Funciones.CheckStr(dr["REFERENCIA_SEC"]);
					oDireccion.IdDepartamento = Funciones.CheckStr(dr["ID_DEPARTAMENTO"]);
					oDireccion.IdProvincia = Funciones.CheckStr(dr["ID_PROVINCIA"]);
					oDireccion.IdDistrito = Funciones.CheckStr(dr["ID_DISTRITO"]);
					oDireccion.IdPostal = Funciones.CheckStr(dr["ID_POSTAL"]);
					oDireccion.IdUbigeo = Funciones.CheckStr(dr["ID_UBIGEO"]);
					oDireccion.IdTelefono = Funciones.CheckStr(dr["ID_TELEFONO"]);
					oDireccion.Telefono = Funciones.CheckStr(dr["TELEFONO"]);
					oDireccion.IdCentroPoblado = Funciones.CheckStr(dr["ID_POBLADO"]);
					oDireccion.IdPlano = Funciones.CheckStr(dr["ID_PLANO"]);
					oDireccion.DirCompleta = Funciones.CheckStr(dr["DIR_COMPLETA"]);
					oDireccion.IdTipoProducto = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					oDireccion.VentaProactiva = Funciones.CheckStr(dr["VENTA_PROACTIVA"]);
					oDireccion.DniVendedor = Funciones.CheckStr(dr["DNI_VENDEDOR"]);

					filas.Add(oDireccion);
				}
			}
			catch(Exception ex)
			{                       
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarPromociones(string pstrSoplnCodigo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 
			ArrayList filas;
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrSoplnCodigo;
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".MANTSS_LISTAR_PROMOCION";
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo2 = Funciones.CheckStr(dr["sopln_codigo"]);
					oItem.Codigo = Funciones.CheckStr(dr["promn_codigo"]);
					oItem.Descripcion = Funciones.CheckStr(dr["promocion"]);
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

		public ArrayList ObtenerPlanesCliente(int tipoDoc, string numeroDoc)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_DOC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANES", DbType.Object,ParameterDirection.Output)
												   
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = tipoDoc;
			arrParam[1].Value = numeroDoc;
			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.TIM142_PKG_EMPRESAS + ".CONSULTAR_CLIENTE"; 
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					Plan_AP item = new Plan_AP();
					item.PLNV_CODIGO=Funciones.CheckStr(dr["TMCODE"]);
					item.CARGO_FIJO_BASE = Funciones.CheckFloat(dr["CF"]);
					item.PLNN_TIPO_PLAN= Funciones.CheckInt(dr["TIPO"]);
					item.TPROC_CODIGO=Funciones.CheckStr(dr["PRGCODE"]);
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

		public ArrayList ObtenerFormulaRecurrente(string dni,int meses, int condicion)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("CUR_CLIENTE", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DNI", DbType.String,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MESES", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONDICION", DbType.Int16 ,ParameterDirection.Input)

											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = dni;
			arrParam[2].Value = meses;
			arrParam[3].Value = condicion;

			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_BSCS_CONSULTA_CONS + ".CLIENTE_CARGOS_FIJOS"; //"PKG_PARAMETRICO_prueba.CLIENTE_CARGOS_FIJOS"; 
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					FormulaRecurrente  item = new FormulaRecurrente();
					item.TMCODE  = Funciones.CheckStr(dr["TMCODE"]);
					item.DES = Funciones.CheckStr(dr["DES"]);
					item.CF = Funciones.CheckInt(dr["CF"]);
					item.ACTIVOS = Funciones.CheckInt(dr["ACTIVOS"]);					
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

		public string ConsultarCalificacionPago(int strTipoDoc, string strNroDoc, ref string mensaje)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("p_tip_doc", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_num_doc", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_indicador", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_cod_err", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msg_err", DbType.String, 100, ParameterDirection.Output)}; 
			arrParam[0].Value = strTipoDoc;
			arrParam[1].Value = strNroDoc;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;

			obRequest.Command = "TIM127_COMP_PAGO";
			string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
			if ( esquema != null && esquema != "") 
				obRequest.Command = esquema  + "." + obRequest.Command;

			obRequest.Parameters.AddRange(arrParam);
			
			string idIndicador = "";
			string idError;
			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter p1, p2, p3;
				p1 = (IDataParameter)obRequest.Parameters[2];
				p2 = (IDataParameter)obRequest.Parameters[3];
				p3 = (IDataParameter)obRequest.Parameters[4];
				idIndicador = Funciones.CheckStr(p1.Value);
				idError = Funciones.CheckStr(p2.Value);
				mensaje = Funciones.CheckStr(p3.Value);
			}
			catch(Exception e)
			{	
				mensaje = e.Message;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return idIndicador;
		}

		public bool InsertarSolDireccion(DireccionCliente oDireccion, Int64 nroSEC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DIR", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_PREFIJO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PREFIJO", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DIRECCION", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_PUERTA", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_EDIFICACION", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFICACION", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MANZANA", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LOTE", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_INTERIOR", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_INTERIOR", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_INTERIOR", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_URBANIZACION", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_URBANIZACION", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TXT_URBANIZACION", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOMICILIO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOMICILIO", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_ZONA", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ZONA", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_ZONA", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REFERENCIA", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REFERENCIA_SEC", DbType.String, 250, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DEPARTAMENTO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_PROVINCIA", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DISTRITO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_POSTAL", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_UBIGEO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_TELEFONO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, 9, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_POBLADO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_PLANO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DIR_COMPLETA", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DIRECCION_SAP", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REFERENCIA_SAP", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO_REF_1", DbType.String, 9, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO_REF_2", DbType.String, 9, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTA_PROACTIVA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DNI_VENDEDOR", DbType.String, 10, ParameterDirection.Input)
											   }; 
			bool salida = false;
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = nroSEC;
			i++; arrParam[i].Value = oDireccion.IdTipoDireccion;
			i++; arrParam[i].Value = oDireccion.IdPrefijo;
			i++; arrParam[i].Value = oDireccion.Prefijo;
			i++; arrParam[i].Value = oDireccion.Direccion;
			i++; arrParam[i].Value = oDireccion.NroPuerta;
			i++; arrParam[i].Value = oDireccion.IdEdificacion;
			i++; arrParam[i].Value = oDireccion.Edificacion;
			i++; arrParam[i].Value = oDireccion.Manzana;
			i++; arrParam[i].Value = oDireccion.Lote;
			i++; arrParam[i].Value = oDireccion.IdTipoInterior;
			i++; arrParam[i].Value = oDireccion.TipoInterior;
			i++; arrParam[i].Value = oDireccion.NroInterior;
			i++; arrParam[i].Value = oDireccion.IdUrbanizacion;
			i++; arrParam[i].Value = oDireccion.Urbanizacion;
			i++; arrParam[i].Value = oDireccion.TxtUrbanizacion;
			i++; arrParam[i].Value = oDireccion.IdDomicilio;
			i++; arrParam[i].Value = oDireccion.Domicilio;
			i++; arrParam[i].Value = oDireccion.IdZona;
			i++; arrParam[i].Value = oDireccion.Zona;
			i++; arrParam[i].Value = oDireccion.NombreZona;
			i++; arrParam[i].Value = oDireccion.Referencia;
			i++; arrParam[i].Value = oDireccion.Referencia_Sec;
			i++; arrParam[i].Value = oDireccion.IdDepartamento;
			i++; arrParam[i].Value = oDireccion.IdProvincia;
			i++; arrParam[i].Value = oDireccion.IdDistrito;
			i++; arrParam[i].Value = oDireccion.IdPostal;
			i++; arrParam[i].Value = oDireccion.IdUbigeo;
			i++; arrParam[i].Value = oDireccion.IdTelefono;
			i++; arrParam[i].Value = oDireccion.Telefono;
			i++; arrParam[i].Value = oDireccion.IdCentroPoblado;
			i++; arrParam[i].Value = oDireccion.IdPlano;
			i++; arrParam[i].Value = oDireccion.DirCompleta;
			i++; arrParam[i].Value = oDireccion.DirCompletaSAP;
			i++; arrParam[i].Value = oDireccion.DirReferenciaSAP;
			i++; arrParam[i].Value = oDireccion.TelefonoReferencia1;
			i++; arrParam[i].Value = oDireccion.TelefonoReferencia2;
			i++; arrParam[i].Value = oDireccion.VentaProactiva;
			i++; arrParam[i].Value = oDireccion.DniVendedor;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SISACT_INS_SOL_DIRECCION";
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
				salida = false;
				throw ex;
			}
			finally
			{					
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return salida;
		}

		public bool RegistrarEvaluacionPortabilidad(string strDatosSolicitud, ref string rMsg, ref Int64 nroSEC)
		{
			string[] arrDBSolicitud = strDatosSolicitud.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Double,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_USU_VEN", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_FIN", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALC_CODIGO", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.AnsiStringFixedLength,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RAZ_SOC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_PROM_VEN", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGMN_CODIGO", DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCLIC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TACTC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_1", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_2", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_3", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FPAGC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN", DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RFINC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MRECC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN", DbType.String,14,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TEVAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLA_TER", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_EST", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_OFI_VEN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_FIN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_TIP_ACT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_PUN_VEN", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_EVALUADOR", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NOM", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_PAT", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_MAT", DbType.String,40,ParameterDirection.Input),
												   /*new DAABRequest.Parameter("P_SOLIV_PRE_DIR", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DIRECCION", DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_REFERENCIA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DEP_1", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_PRO_1", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DIS_1", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COD_POS_1", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_TEL", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TELEFONO", DbType.String,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_DIR_TRA", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DIR_TRA", DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_REF_TRA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DEP_3", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_PRO_3", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DIS_3", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_POS_3", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_REF_1", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_REF_1", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_REF_2", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_REF_2", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_CON_TRA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_FIJ_TRA", DbType.String,10,ParameterDirection.Input),
												   */new DAABRequest.Parameter("P_SOLIC_EVA_ESS", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EVA_SUN", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_RES_DIR", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_DIR", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CAR_CLI", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_FIJ", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_RES_EXP_CON", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_OPE_CON", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_CRE_CON", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_CON", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCESC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCO_TXT_CON", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SCO_NUM_CON", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_INFOCORP", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HINFV_MENSAJE", DbType.String,1000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RUCEMPLEADOR", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBREEMPRESA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCAMPANNA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_CON", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR_ID", DbType.String,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CONSUMO", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_PORTABILIDAD", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_OPER_CED", DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_ESTADO", DbType.String,5,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_TELEF_CONT", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_FLAG_REC_OPE_CED", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_CARGO_FIJO_OPE_CED", DbType.String, 10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_NRO_FOLIO", DbType.String, 10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLAG_CORREO",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CORREO",DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_SMS", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_EST_CIV", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_UBIGEO_INEI", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ORIGEN_LC_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ANALISIS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCORE_RANKING_OPER_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_PUNTAJE_DC", DbType.Double,ParameterDirection.Input),										
												   new DAABRequest.Parameter("P_SOLIN_LC_DATA_CREDITO_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LC_BASE_EXTERNA_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LC_CLARO_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_REGLAS_DURAS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ALERT_COMPORT_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ALERTAS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_CORRESP_SALDO_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC", DbType.Date,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_DISPONIBLE", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_MENORES", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_MAYORES", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_GRUPO_SEC", DbType.Int64 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_CALIFICACION_PAGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BURO_CREDITICIO", DbType.Int16, ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			for (i=1; i<arrParam.Length;i++)
				arrParam[i].Value = arrDBSolicitud[i-1].Trim();

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_INSERT_SOLICITUD_PORTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar la Solicitud de Portabilidad. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida1.Value);
				nroSEC = Funciones.CheckInt64(pSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool RegistrarEvaluacionDTH_HFC(string strDatosSolicitud, ref string rMsg, ref Int64 nroSEC)
		{
			string[] arrDBSolicitud = strDatosSolicitud.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Double,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_USU_VEN", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_FIN", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALC_CODIGO", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.AnsiStringFixedLength,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RAZ_SOC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_PROM_VEN", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGMN_CODIGO", DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCLIC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TACTC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_1", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_2", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_3", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FPAGC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN", DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RFINC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MRECC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN", DbType.String,14,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TEVAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLA_TER", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_EST", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_OFI_VEN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_FIN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_TIP_ACT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_PUN_VEN", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_EVALUADOR", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NOM", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_PAT", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_MAT", DbType.String,40,ParameterDirection.Input),
												   /*
												   new DAABRequest.Parameter("P_SOLIV_PRE_DIR", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DIRECCION", DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_REFERENCIA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DEP_1", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_PRO_1", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DIS_1", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COD_POS_1", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_TEL", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TELEFONO", DbType.String,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_DIR_TRA", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DIR_TRA", DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_REF_TRA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DEP_3", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_PRO_3", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DIS_3", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_POS_3", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_REF_1", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_REF_1", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_REF_2", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_REF_2", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PER_CON_TRA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TEL_FIJ_TRA", DbType.String,10,ParameterDirection.Input),
												   */
												   new DAABRequest.Parameter("P_SOLIC_EVA_ESS", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EVA_SUN", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_RES_DIR", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_DIR", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CAR_CLI", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_FIJ", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_RES_EXP_CON", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_OPE_CON", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_CRE_CON", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_CON", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCESC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCO_TXT_CON", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SCO_NUM_CON", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO_PADRE", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_INFOCORP", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HINFV_MENSAJE", DbType.String,1000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RUCEMPLEADOR", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBREEMPRESA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCAMPANNA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_CON", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR_ID", DbType.String,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CONSUMO", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLAG_CORR", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CORREO", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_EST_CIV", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_UBIGEO_INEI", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ORIGEN_LC_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ANALISIS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCORE_RANKING_OPER_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_PUNTAJE_DC", DbType.Double,ParameterDirection.Input),										
												   new DAABRequest.Parameter("P_SOLIN_LC_DATA_CREDITO_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LC_BASE_EXTERNA_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LC_CLARO_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_REGLAS_DURAS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ALERT_COMPORT_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ALERTAS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_CORRESP_SALDO_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC", DbType.Date,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC_PDV", DbType.Date,ParameterDirection.Input),								
												   new DAABRequest.Parameter("P_LC_DISPONIBLE", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_MENORES", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_MAYORES", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DEUDA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BLOQUEO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_SEC_ASOCIADA", DbType.Int64 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA_DC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_GRUPO_SEC", DbType.Int64 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_CALIFICACION_PAGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BURO_CREDITICIO", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_GRUPO_SEC", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CF_GRUPO_SEC", DbType.Double, ParameterDirection.Input),
												   //----------------------------------------------------------------------------------------------------------------------------------------
												   /*new DAABRequest.Parameter("P_SOLIV_PRE_DIR", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DIRECCION", DbType.String,2000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_REFERENCIA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DEP_1", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_PRO_1", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_DIS_1", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COD_POS_1", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_PRE_TEL", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_TELEFONO", DbType.String,8,ParameterDirection.Input),*/
												   //----------------------------------------------------------------------------------------------------------------------------------------
												   /*new DAABRequest.Parameter("P_CLIEV_COD_PRE_DIR_FAC", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR_FAC", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIR_FAC", DbType.AnsiStringFixedLength,4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NRO_PUERTA_FAC", DbType.AnsiStringFixedLength,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_COD_URBANIZACION_FAC", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_URBANIZACION_FAC", DbType.AnsiStringFixedLength,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_MANZANA_FAC", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_LOTE_FAC", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR_FAC", DbType.AnsiStringFixedLength,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_FAC", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_FAC", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_FAC", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_FAC_SGA", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_FAC_SGA", DbType.AnsiStringFixedLength,13,ParameterDirection.Input),*/
												   //----------------------------------------------------------------------------------------------------------------------------------------
												   /*new DAABRequest.Parameter("P_CLIEV_COD_PRE_DIR_INST", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR_INST", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIR_INST", DbType.AnsiStringFixedLength,4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NRO_PUERTA_INST", DbType.AnsiStringFixedLength,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_COD_URBANIZACION_INST", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_URBANIZACION_INST", DbType.AnsiStringFixedLength,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_MANZANA_INST", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_LOTE_INST", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR_INST", DbType.AnsiStringFixedLength,340,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_INST", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_INST", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_INST", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_INST", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_INST", DbType.AnsiStringFixedLength,13,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TIP_DOM_INST", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_CEN_POB", DbType.AnsiStringFixedLength,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_COD_MAPA", DbType.String,ParameterDirection.Input),*/
												   //----------------------------------------------------------------------------------------------------------------------------------------
												   new DAABRequest.Parameter("P_FLAG_VTA_PROACTIVA", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_CODIGO", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_VEN_DNI", DbType.AnsiStringFixedLength,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_KIT_COS_INST", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_BLOQUEO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NRO_CARTA_PRESELEC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_OPERADOR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PAGINA_CLARO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CF_ALQUILER_KIT", DbType.Double,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			for (i=1; i<arrParam.Length;i++)
			{
				if(arrDBSolicitud[i-1].Trim() != "")
					arrParam[i].Value = arrDBSolicitud[i-1].Trim();
			}
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSI_INS_SOL_PERSONA_SGA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar la Solicitud. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida1.Value);
				nroSEC = Funciones.CheckInt64(pSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public bool RegistrarEvaluacion(string strDatosSolicitud, ref string rMsg, ref Int64 nroSEC)
		{
			string nameArchivo = "LOG_RegistrarEvaluacion_DATOS";	
			string initFormatLog = nroSEC + " " + string.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | ";
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Inicio RegistrarEvaluacion", false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);

			string[] arrDBSolicitud = strDatosSolicitud.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_USU_VEN", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_FIN", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALC_CODIGO", DbType.AnsiStringFixedLength,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.AnsiStringFixedLength,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RAZ_SOC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_PROM_VEN", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGMN_CODIGO", DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCLIC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TACTC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_1", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_2", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_PLA_MAX_3", DbType.AnsiStringFixedLength,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FPAGC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN", DbType.Int32,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RFINC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MRECC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN", DbType.String,14,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TEVAC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLA_TER", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_EST", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_OFI_VEN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_FIN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_TIP_ACT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_PUN_VEN", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_EVALUADOR", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE", DbType.AnsiStringFixedLength,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NOM", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_PAT", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_MAT", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EVA_ESS", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EVA_SUN", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_COD_RES_DIR", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_DIR", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CAR_CLI", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_FIJ", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_RES_EXP_CON", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_OPE_CON", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_CRE_CON", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_CON", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCESC_CODIGO", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCO_TXT_CON", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SCO_NUM_CON", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO_PADRE", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_INFOCORP", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HINFV_MENSAJE", DbType.String,1000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RUCEMPLEADOR", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBREEMPRESA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCAMPANNA", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_CON", DbType.AnsiStringFixedLength,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR_ID", DbType.String,8,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CONSUMO", DbType.AnsiStringFixedLength,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLAG_CORR", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CORREO", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_EST_CIV", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_UBIGEO_INEI", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ORIGEN_LC_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ANALISIS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_SCORE_RANKING_OPER_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_PUNTAJE_DC", DbType.Double,ParameterDirection.Input),										
												   new DAABRequest.Parameter("P_SOLIN_LC_DATA_CREDITO_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LC_BASE_EXTERNA_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LC_CLARO_DC", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_REGLAS_DURAS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ALERT_COMPORT_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_ALERTAS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_CORRESP_SALDO_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC", DbType.Date,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC_PDV", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_DISPONIBLE", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_MENORES", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_MAYORES", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DEUDA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BLOQUEO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_SEC_ASOCIADA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA_DC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_GRUPO_SEC", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_CALIFICACION_PAGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BURO_CREDITICIO", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_GRUPO_SEC", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CF_GRUPO_SEC", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FACTOR_RENOVACION", DbType.String,10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RIESGO_CLARO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_COMPORTA_PAGO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_CODNACION", DbType.String, 20, ParameterDirection.Input), /*PROY-31636*/
												   new DAABRequest.Parameter("P_CLIEV_DESCNACION", DbType.String, 80, ParameterDirection.Input) /*PROY-31636*/

											   }; 
			int i=0;
		
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			for (i=1; i<arrParam.Length;i++)
			{
				arrParam[i].Value = arrDBSolicitud[i-1].Trim();

				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- valores= " + arrParam[i].Value , false);	
			}
	
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSI_INS_SOL_PERSONA_RP";


			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + obRequest.Command, false);
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				HelperLog.EscribirLog("", nameArchivo, "Antes de la ejecucion del store " + DateTime.Now.ToString(), false);
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				HelperLog.EscribirLog("", nameArchivo, "Despues de la ejecucion del store " + DateTime.Now.ToString(), false);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				string MensajeError = "Error. " + ex.Message;
				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + MensajeError, false);
			}
			finally
			{					
	
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida1.Value);
				nroSEC = Funciones.CheckInt64(pSalida1.Value);

				HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- nroSEC= " + nroSEC , false);	
				obRequest.Factory.Dispose();
			}			

			return salida ;
		}
		
		
		public bool GrabarVentaRenovacion(VentaRenovaPost oVentaRenovaPost, Int64 Accion)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String,5,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,11,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_USU_VEN", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NROLINEA", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_ACTUAL", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_NUEVO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CICLO_FACTURACION", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LIMITE_CREDITO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVIDOR", DbType.String,30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TITULAR", DbType.String,150,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CARGOFIJO_NUEVO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CARGOFIJO_ACTUAL", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_RENOVACION", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPRESENTANTE", DbType.String,150,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CORREO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USER_VALIDADOR", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_DESCUENTO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTRATO_SAP", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PEDIDO_SAP", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCUENTO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RENOF_FLAGGENER", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC_VENDEDOR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOM_VENDEDOR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INTER_CAMBIO_PLAN", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ACCION", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_RENOV_Y_CHIP", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MOT_TIP_RENOVCHIP", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_FIDELIZADO_RETENIDO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGENVIA_PLAN", DbType.String,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = oVentaRenovaPost.oficina;
			i++; arrParam[i].Value = oVentaRenovaPost.tipo_documento;
			i++; arrParam[i].Value = oVentaRenovaPost.doc_clien_numero;
			i++; arrParam[i].Value = oVentaRenovaPost.vendedor;
			i++; arrParam[i].Value = oVentaRenovaPost.telefono;
			i++; arrParam[i].Value = oVentaRenovaPost.plan_actual;
			i++; arrParam[i].Value = oVentaRenovaPost.plan_nuevo;
			i++; arrParam[i].Value = oVentaRenovaPost.ciclo_fact;
			i++; arrParam[i].Value = oVentaRenovaPost.limite_credito;
			i++; arrParam[i].Value = oVentaRenovaPost.servidor;
			i++; arrParam[i].Value = oVentaRenovaPost.canal;
			i++; arrParam[i].Value = oVentaRenovaPost.numero_sec;
			i++; arrParam[i].Value = oVentaRenovaPost.titular;
			i++; arrParam[i].Value = oVentaRenovaPost.renof_cnuevo;
			i++; arrParam[i].Value = oVentaRenovaPost.renof_cactual;
			i++; arrParam[i].Value = oVentaRenovaPost.tipo_renovacion;
			i++; arrParam[i].Value = oVentaRenovaPost.representante;
			i++; arrParam[i].Value = oVentaRenovaPost.correo;
			i++; arrParam[i].Value = oVentaRenovaPost.usuario_validador;
			i++; arrParam[i].Value = oVentaRenovaPost.flag_descuento;
			i++; arrParam[i].Value = oVentaRenovaPost.numero_factura;
			i++; arrParam[i].Value = oVentaRenovaPost.numero_contrato;
			i++; arrParam[i].Value = oVentaRenovaPost.numero_pedido;
			i++; arrParam[i].Value = oVentaRenovaPost.descuento;
			i++; arrParam[i].Value = oVentaRenovaPost.renof_Flaggener;
			i++; arrParam[i].Value = oVentaRenovaPost.num_vendedor;
			i++; arrParam[i].Value = oVentaRenovaPost.nom_vendedor;
			i++; arrParam[i].Value = oVentaRenovaPost.iter_cambio_plan;
			i++; arrParam[i].Value = Accion;
			i++; arrParam[i].Value = oVentaRenovaPost.flag_renovacion_y_chip;
			i++; arrParam[i].Value = oVentaRenovaPost.mot_tip_renovchip;
			i++; arrParam[i].Value = oVentaRenovaPost.flag_fidelizado_retenido;
			i++; arrParam[i].Value = oVentaRenovaPost.VigenciaPlan;
			//P_FLAG_FIDELIZADO_RETENIDO

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSI_MANT_VENTA_RENOVA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool AnularSECSAnteriores(VistaSolicitud oSolicitud)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.AnsiStringFixedLength,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = oSolicitud.TDOCC_CODIGO;
			i++; arrParam[i].Value = oSolicitud.CLIEC_NUM_DOC;
			i++; arrParam[i].Value = oSolicitud.LINEA;
			i++; arrParam[i].Value = Convert.ToInt64(oSolicitud.solin_codigo);

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SP_ANU_SOL_PENDIENTE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool AnularVentaRenovacion(string NumeroDoc, string SolinCodigo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,11,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = NumeroDoc;
			arrParam[1].Value = SolinCodigo;

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSI_ANU_VENTA_RENOVA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public bool GrabarSolicitudEmpresaPort(SolicitudEmpresa item,ref Int64 codigo,ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OVENC_CODIGO",DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANEXO2", DbType.String,7,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_FIN", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALC_CODIGO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RAZ_SOC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NOMBRE", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_PAT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_MAT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_PROM_VEN", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGMN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCLIC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TACTC_CODIGO", DbType.String,2,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RFINC_CODIGO", DbType.String,2,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN", DbType.String,1,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TEVAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLA_TER", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_EST", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_OFI_VEN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_FIN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_TIP_ACT", DbType.String,20,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIV_COM_EVALUADOR", DbType.String,500,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLASC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUAN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLEXN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_TRIEC_CODIGO", DbType.String,1,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_OPERC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN_EXCOMP", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CONSULTOR", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_DEUDA_CLIENTE", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LINEA_CLIENTE", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_ANTIGUEDAD", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO_PADRE", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLAG_REINGRESO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_OPE_CON", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ_LINEA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_ANTIGUEDAD_CLIENTE", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLAG_EMPRESA_TRAFICO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLA_VER_RES", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLAG_EMPRESA_TOLERAN", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_FIN", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAR_FIJO_ACTUAL", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUBSIDIO_TOTAL", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEAS_RECURRENTE_ACTUAL", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEAS_MAYOR_N_DIAS", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEAS_MENOR_N_DIAS", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PARAM_DIAS_RECURRENTE", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_DG", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLAG_ENVIO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_BOLSA_REF", DbType.Double,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_PORTABILIDAD", DbType.String,1,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_PORT_OPER_CED", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TLINC_CODIGO_CEDENTE", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_SOLIN_NRO_FORMATO", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_CARGO_FIJO_OPE_CED", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_ESTADO", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_TELEF_CONT", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLAG_CORR", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CORREO", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_LINEA_CREDITO_CALC", DbType.Double,ParameterDirection.Input),
												   //JAR
												   new DAABRequest.Parameter("P_DPCHN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIRECCION", DbType.String, 4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_DIR", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_DIR", DbType.String, 3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_DIR", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_DIR", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_TEL_LEG", DbType.String,3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_LEG", DbType.String, 13, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR_FAC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIR_FAC", DbType.String, 4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR_FAC", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_FAC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_FAC", DbType.String, 3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_FAC", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_FAC", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RGLPC_PODERES", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_FIJ", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPREC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FPAGC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_CRE_FIN", DbType.Decimal,ParameterDirection.Input),
												   //FIN JAR
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_CON", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCESC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_CALIFICACION_PAGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BURO_CREDITICIO", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_MONTO_VENCIDO", DbType.Double, ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = item.OVENC_CODIGO;			
			++i; arrParam[i].Value = item.CANAC_CODIGO;
			++i; arrParam[i].Value = item.ANEXO2;
			++i; arrParam[i].Value = item.SOLIC_EXI_BSC_FIN;
			++i; arrParam[i].Value = item.ANALC_CODIGO;
			++i; arrParam[i].Value = item.TDOCC_CODIGO;
			++i; arrParam[i].Value = item.CLIEC_NUM_DOC;
			++i; arrParam[i].Value = item.CLIEV_RAZ_SOC;
			++i; arrParam[i].Value = item.CLIEV_NOMBRE;
			++i; arrParam[i].Value = item.CLIEV_APE_PAT;
			++i; arrParam[i].Value = item.CLIEV_APE_MAT;
			++i; arrParam[i].Value = item.CLIEN_PROM_VEN;			
			++i; arrParam[i].Value = item.TPROC_CODIGO;
			++i; arrParam[i].Value = item.SEGMN_CODIGO;
			++i; arrParam[i].Value = item.TCLIC_CODIGO;
			++i; arrParam[i].Value = item.TVENC_CODIGO;
			++i; arrParam[i].Value = item.TACTC_CODIGO;						
			++i; arrParam[i].Value = item.SOLIN_CAN_LIN;
			++i; arrParam[i].Value = item.RFINC_CODIGO;			
			++i; arrParam[i].Value = item.SOLIC_TIP_CAR_MAN;
			++i; arrParam[i].Value = item.SOLIN_NUM_CAR_FIJ;
			++i; arrParam[i].Value = item.ESTAC_CODIGO;
			++i; arrParam[i].Value = item.TEVAC_CODIGO;
			++i; arrParam[i].Value = item.SOLIC_FLA_TER;
			++i; arrParam[i].Value = item.SOLIV_DES_EST;
			++i; arrParam[i].Value = item.SOLIV_DES_OFI_VEN;
			++i; arrParam[i].Value = item.SOLIV_DES_RES_FIN;
			++i; arrParam[i].Value = item.SOLIV_DES_TIP_ACT;			
			++i; arrParam[i].Value = item.SOLIV_COM_EVALUADOR;
			++i; arrParam[i].Value = item.SOLIC_USU_CRE;
			++i; arrParam[i].Value = item.CLASC_CODIGO;
			++i; if (item.USUAN_CODIGO>0 ) arrParam[i].Value = item.USUAN_CODIGO;			
			++i; arrParam[i].Value = item.FLEXN_CODIGO;			
			++i; arrParam[i].Value = item.TRIEC_CODIGO;
			++i; arrParam[i].Value = item.OPERC_CODIGO;
			++i; if (item.SOLIN_CAN_LIN_EXCOMP>0 ) arrParam[i].Value = item.SOLIN_CAN_LIN_EXCOMP;
			++i; if (item.CONSULTOR_ID>0 ) arrParam[i].Value = item.CONSULTOR_ID;
			++i; if (item.SOLIN_DEUDA_CLIENTE>0 ) arrParam[i].Value = item.SOLIN_DEUDA_CLIENTE;
			++i; if (item.SOLIN_LINEA_CLIENTE>0 ) arrParam[i].Value = item.SOLIN_LINEA_CLIENTE;
			++i; if (item.SOLIN_ANTIGUEDAD>0 ) arrParam[i].Value = item.SOLIN_ANTIGUEDAD;
			++i; if (item.SOLIN_CODIGO_PADRE>0 ) arrParam[i].Value = item.SOLIN_CODIGO_PADRE;
			++i; if (item.SOLIC_FLAG_REINGRESO !="" ) arrParam[i].Value = item.SOLIC_FLAG_REINGRESO;
			++i; if (item.SOLIV_NUM_OPE_CON !="" ) arrParam[i].Value = item.SOLIV_NUM_OPE_CON;			  
			++i; if (item.SOLIN_NUM_CAR_FIJ_LINEA>0 ) arrParam[i].Value = item.SOLIN_NUM_CAR_FIJ_LINEA;
			++i; if (item.SOLIN_ANTIGUEDAD_CLIENTE>0 ) arrParam[i].Value = item.SOLIN_ANTIGUEDAD_CLIENTE;
			++i; if (item.SOLIC_FLAG_EMPRESA_TRAFICO !="" ) arrParam[i].Value = item.SOLIC_FLAG_EMPRESA_TRAFICO;
			++i; if (item.FLAG_RESPONSABLE_PUNTO_VENTA !="" ) arrParam[i].Value = item.FLAG_RESPONSABLE_PUNTO_VENTA;
			++i; if (item.SOLIC_FLAG_EMPRESA_TOLERAN !="" ) arrParam[i].Value = item.SOLIC_FLAG_EMPRESA_TOLERAN;
			++i; arrParam[i].Value = item.SOLIN_SUM_CAR_FIN;
			++i; arrParam[i].Value = item.SOLIN_CAR_FIJO_ACTUAL;
			++i; arrParam[i].Value = item.SOLIN_SUBSIDIO_TOTAL;
				
			++i; arrParam[i].Value = item.NRO_LINEAS_RECURRENTE_ACTUAL;
			++i; arrParam[i].Value = item.NRO_LINEAS_MAYOR_N_DIAS;
			++i; arrParam[i].Value = item.NRO_LINEAS_MENOR_N_DIAS;
			++i; arrParam[i].Value = item.DIAS_LINEAS_RECURRENTE;
			++i; arrParam[i].Value = item.SOLIV_COM_DG;
			++i; arrParam[i].Value = item.SOLIV_FLAG_ENVIO;
			++i; if (item.SOLIN_BOLSA_REF>0 ) arrParam[i].Value = item.SOLIN_BOLSA_REF;
			++i; if (item.CAMPN_CODIGO>0 ) arrParam[i].Value = item.CAMPN_CODIGO;
			++i; arrParam[i].Value = item.FLAG_PORTABILIDAD;
			++i; arrParam[i].Value = item.PORT_OPER_CED;
			++i; arrParam[i].Value = item.TLINC_CODIGO_CEDENTE;
			++i; arrParam[i].Value = item.PORT_SOLIN_NRO_FORMATO;
			++i; arrParam[i].Value = item.PORT_CARGO_FIJO_OPE_CED;
			++i; arrParam[i].Value = item.PORT_ESTADO;
			++i; arrParam[i].Value = item.PORT_TELEF_CONT;
			++i; arrParam[i].Value = item.FLAG_CORREO;
			++i; arrParam[i].Value = item.SOLIV_CORREO;
			++i; arrParam[i].Value = item.SOLIN_LINEA_CREDITO_CALC; //E75810 
			//JAR
			++i; arrParam[i].Value = item.DPCHN_CODIGO;
			++i; arrParam[i].Value = item.CLIEV_PRE_DIR;
			++i; arrParam[i].Value = item.CLIEV_DIRECCION;
			++i; arrParam[i].Value = item.CLIEV_REF_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_DEP_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_PRO_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_DIS_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_POS_DIR;
			++i; arrParam[i].Value = item.CLIEV_PRE_TEL_LEG;
			++i; arrParam[i].Value = item.CLIEV_TEL_LEG;
			++i; arrParam[i].Value = item.CLIEV_PRE_DIR_FAC;
			++i; arrParam[i].Value = item.CLIEV_DIR_FAC;
			++i; arrParam[i].Value = item.CLIEV_REF_DIR_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_DEP_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_PRO_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_DIS_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_POS_FAC;
			++i; arrParam[i].Value = item.RGLPC_PODERES;
			++i; arrParam[i].Value = item.PACUC_CODIGO;
			++i; arrParam[i].Value = item.TOPEN_CODIGO;
			++i; arrParam[i].Value = item.SOLIC_TIP_CAR_FIJ;
			++i; arrParam[i].Value = item.SOLIN_IMP_DG;
			++i; arrParam[i].Value = item.SOLIN_IMP_DG_MAN;
			++i; arrParam[i].Value = item.TPREC_CODIGO;
			++i; arrParam[i].Value = item.FPAGC_CODIGO;
			++i; if (item.SOLIN_LIM_CRE_FIN>0 ) arrParam[i].Value = item.SOLIN_LIM_CRE_FIN;
			//FIN JAR
									
			++i; if (item.SOLIN_SUM_CAR_CON>0 ) arrParam[i].Value = item.SOLIN_SUM_CAR_CON;
					
			++i; arrParam[i].Value = item.TCESC_CODIGO;
			++i; arrParam[i].Value = item.PRDC_CODIGO;   
			++i; arrParam[i].Value = item.CLIEV_CALIFICACION_PAGO;
			++i; arrParam[i].Value = item.BURO_CODIGO;
			++i; arrParam[i].Value = item.CLIEN_MONTO_VENCIDO;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD_CORP + ".SECSI_INS_SOL_CORP_PORT_PDV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Solicitud. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
					
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				codigo = Funciones.CheckInt64(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		/*public bool RegistrarEvaluacionDatosCreditos(DatosCreditos item)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.String, 2, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_CLIENTE", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO_LC", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO_FACT", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MSJ_AUTONOMIA", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MOTIVO", DbType.String, 500, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANGO_LC", DbType.String, 10,ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			i=1;	arrParam[i].Value = item.SOLIN_CODIGO;
			i=i+1;	arrParam[i].Value = item.FACT_PROMEDIO;
			i=i+1;	if (item.PRODUCTO_LC != "") arrParam[i].Value = item.PRODUCTO_LC;
			i=i+1;	if (item.PRODUCTO_FACT != "") arrParam[i].Value = item.PRODUCTO_FACT;
			i=i+1;	if (item.MSJ_AUTONOMIA != "") arrParam[i].Value = item.MSJ_AUTONOMIA;	
			i=i+1;	if (item.MOTIVO != "") arrParam[i].Value = item.MOTIVO;
			i=i+1;	if (item.USUARIO_CREA != "")arrParam[i].Value = item.USUARIO_CREA;
			i=i+1;	if (item.RANGO_LC_DISPONIBLE != "")arrParam[i].Value = item.RANGO_LC_DISPONIBLE;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_INS_DATO_CREDITOS_RP";
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
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida1.Value) == "0")
					salida = true;	
				obRequest.Factory.Dispose();
			}			
			return salida;
		}*/

		public bool RegistrarEvaluacionDatosCreditos(DatosCreditos item)
		{
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("P_RESULTADO", DbType.String, 2, ParameterDirection.Output),
				new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
				new DAABRequest.Parameter("P_LC_CLIENTE", DbType.Double, ParameterDirection.Input),
				new DAABRequest.Parameter("P_MONTO_X_PRODUCTO", DbType.String, 200, ParameterDirection.Input),
				new DAABRequest.Parameter("P_MSJ_AUTONOMIA", DbType.String, 200, ParameterDirection.Input),
				new DAABRequest.Parameter("P_MOTIVO", DbType.String, 500, ParameterDirection.Input),
				new DAABRequest.Parameter("P_RANGO_LC", DbType.String, 50, ParameterDirection.Input),
				new DAABRequest.Parameter("P_NRO_LINEA", DbType.Int32, ParameterDirection.Input),
				new DAABRequest.Parameter("P_NRO_LINEA_7", DbType.Int32, ParameterDirection.Input),
				new DAABRequest.Parameter("P_NRO_LINEA_30", DbType.Int32, ParameterDirection.Input),
				new DAABRequest.Parameter("P_NRO_LINEA_90", DbType.Int32, ParameterDirection.Input),
				new DAABRequest.Parameter("P_NRO_LINEA_180", DbType.Int32, ParameterDirection.Input),
				new DAABRequest.Parameter("P_NRO_LINEA_MAY180", DbType.Int32, ParameterDirection.Input),
				new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10,ParameterDirection.Input)
			};
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			i = 1; arrParam[i].Value = item.SOLIN_CODIGO;
			i++; arrParam[i].Value = item.LC_DISPONIBLE;
			i++; if (Funciones.CheckStr(item.PRODUCTO_MONTO) != "") arrParam[i].Value = item.PRODUCTO_MONTO;
			i++; if (Funciones.CheckStr(item.MSJ_AUTONOMIA) != "") arrParam[i].Value = item.MSJ_AUTONOMIA;
			i++; if (Funciones.CheckStr(item.MOTIVO) != "") arrParam[i].Value = item.MOTIVO;
			i++; if (Funciones.CheckStr(item.RANGO_LC_DISPONIBLE) != "") arrParam[i].Value = item.RANGO_LC_DISPONIBLE;
			i++; arrParam[i].Value = item.nroLineas;
			i++; arrParam[i].Value = item.nroLineaMenor7Dia;
			i++; arrParam[i].Value = item.nroLineaMenor30Dia;
			i++; arrParam[i].Value = item.nroLineaMenor90Dia;
			i++; arrParam[i].Value = item.nroLineaMenor180Dia;
			i++; arrParam[i].Value = item.nroLineaMayor180Dia;
			i++; if (item.USUARIO_CREA != "") arrParam[i].Value = item.USUARIO_CREA;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_INS_DATOS_CREDITOS";
			objRequest.Parameters.AddRange(arrParam);
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)objRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida1.Value) == "0")
					salida = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return salida;
		}

		public bool GrabarRazonesEvaluacion(Int64 strNroSEC, string strNodo,ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_SRDCN_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRDCN_COD_RAZON_NODO" ,DbType.String,ParameterDirection.Input)																					   
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strNroSEC;
			arrParam[1].Value = strNodo;
			
			
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_INS_RAZONES_EVALUACION";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Razones de Evaluacion. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{		
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool GrabarLogHistorico(Int64 strNroSEC, string strEstado, string strUsuario, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE" ,DbType.String,ParameterDirection.Input)												   
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strNroSEC;
			arrParam[1].Value = strEstado;
			arrParam[2].Value = strUsuario;
			
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACTI_INS_LOG";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Historico Estado. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{		
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool GrabarSolicitudEmpresa(SolicitudEmpresa item,ref Int64 codigo,ref string rMsg) 
		{
			String nameArchivo = "LOGGUARDACORPRP";
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OVENC_CODIGO",DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANEXO2", DbType.String,7,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_EXI_BSC_FIN", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALC_CODIGO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RAZ_SOC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_NOMBRE", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_PAT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_APE_MAT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_PROM_VEN", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGMN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCLIC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TACTC_CODIGO", DbType.String,2,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RFINC_CODIGO", DbType.String,2,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_MAN", DbType.String,1,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TEVAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLA_TER", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_EST", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_OFI_VEN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_RES_FIN", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_DES_TIP_ACT", DbType.String,20,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIV_COM_EVALUADOR", DbType.String,500,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_USU_CRE", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLASC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUAN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLEXN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_TRIEC_CODIGO", DbType.String,1,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_OPERC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAN_LIN_EXCOMP", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CONSULTOR", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_DEUDA_CLIENTE", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LINEA_CLIENTE", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_ANTIGUEDAD", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO_PADRE", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLAG_REINGRESO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_OPE_CON", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_NUM_CAR_FIJ_LINEA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_ANTIGUEDAD_CLIENTE", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLAG_EMPRESA_TRAFICO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLA_VER_RES", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_FLAG_EMPRESA_TOLERAN", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_FIN", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CAR_FIJO_ACTUAL", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUBSIDIO_TOTAL", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEAS_RECURRENTE_ACTUAL", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEAS_MAYOR_N_DIAS", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEAS_MENOR_N_DIAS", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PARAM_DIAS_RECURRENTE", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_COM_DG", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLAG_ENVIO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_BOLSA_REF", DbType.Double,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_EMAIL_AUTORIZADO", DbType.String, 100, ParameterDirection.Input),
												   //INICIO - E75688
												   new DAABRequest.Parameter("P_SOLIV_FLAG_CORR", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_CORREO", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_LINEA_CREDITO_CALC", DbType.Decimal, ParameterDirection.Input),
												   //FIN
												   //JAR
												   new DAABRequest.Parameter("P_DPCHN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIRECCION", DbType.String, 4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_DIR", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_DIR", DbType.String, 3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_DIR", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_DIR", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_TEL_LEG", DbType.String,3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_TEL_LEG", DbType.String, 13, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_PRE_DIR_FAC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_DIR_FAC", DbType.String, 4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_REF_DIR_FAC", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DEP_FAC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_PRO_FAC", DbType.String, 3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_DIS_FAC", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_COD_POS_FAC", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RGLPC_PODERES", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIC_TIP_CAR_FIJ", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_MAN", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPREC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FPAGC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_USU_VEN", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_LIM_CRE_FIN", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_SUM_CAR_CON", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCESC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_CALIFICACION_PAGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BURO_CREDITICIO", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_GRUPO_SEC", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_IMP_DG_GRUPO_SEC", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CF_GRUPO_SEC", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEN_MONTO_VENCIDO", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FACTOR_RENOVACION", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_RIESGO_CLARO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEV_COMPORTA_PAGO", DbType.String, 20, ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = item.OVENC_CODIGO;			
			++i; arrParam[i].Value = item.CANAC_CODIGO;
			++i; arrParam[i].Value = item.ANEXO2;
			++i; arrParam[i].Value = item.SOLIC_EXI_BSC_FIN;
			++i; arrParam[i].Value = item.ANALC_CODIGO;
			++i; arrParam[i].Value = item.TDOCC_CODIGO;
			++i; arrParam[i].Value = item.CLIEC_NUM_DOC;
			++i; arrParam[i].Value = item.CLIEV_RAZ_SOC;
			++i; arrParam[i].Value = item.CLIEV_NOMBRE;
			++i; arrParam[i].Value = item.CLIEV_APE_PAT;
			++i; arrParam[i].Value = item.CLIEV_APE_MAT;
			++i; arrParam[i].Value = item.CLIEN_PROM_VEN;			
			++i; arrParam[i].Value = item.TPROC_CODIGO;
			++i; arrParam[i].Value = item.SEGMN_CODIGO;
			++i; arrParam[i].Value = item.TCLIC_CODIGO;
			++i; arrParam[i].Value = item.TVENC_CODIGO;
			++i; arrParam[i].Value = item.TACTC_CODIGO;						
			++i; arrParam[i].Value = item.SOLIN_CAN_LIN;
			++i; arrParam[i].Value = item.RFINC_CODIGO;			
			++i; arrParam[i].Value = item.SOLIC_TIP_CAR_MAN;
			++i; arrParam[i].Value = item.SOLIN_NUM_CAR_FIJ;
			++i; arrParam[i].Value = item.ESTAC_CODIGO;
			++i; arrParam[i].Value = item.TEVAC_CODIGO;
			++i; arrParam[i].Value = item.SOLIC_FLA_TER;
			++i; arrParam[i].Value = item.SOLIV_DES_EST;
			++i; arrParam[i].Value = item.SOLIV_DES_OFI_VEN;
			++i; arrParam[i].Value = item.SOLIV_DES_RES_FIN;
			++i; arrParam[i].Value = item.SOLIV_DES_TIP_ACT;			
			++i; arrParam[i].Value = item.SOLIV_COM_EVALUADOR;
			++i; arrParam[i].Value = item.SOLIC_USU_CRE;
			++i; arrParam[i].Value = item.CLASC_CODIGO;
			++i; if (item.USUAN_CODIGO>0 ) arrParam[i].Value = item.USUAN_CODIGO;			
			++i; arrParam[i].Value = item.FLEXN_CODIGO;			
			++i; arrParam[i].Value = item.TRIEC_CODIGO;
			++i; arrParam[i].Value = item.OPERC_CODIGO;
			++i; if (item.SOLIN_CAN_LIN_EXCOMP>0 ) arrParam[i].Value = item.SOLIN_CAN_LIN_EXCOMP;
			++i; if (item.CONSULTOR_ID>0 ) arrParam[i].Value = item.CONSULTOR_ID;
			++i; if (item.SOLIN_DEUDA_CLIENTE>0 ) arrParam[i].Value = item.SOLIN_DEUDA_CLIENTE;
			++i; if (item.SOLIN_LINEA_CLIENTE>0 ) arrParam[i].Value = item.SOLIN_LINEA_CLIENTE;
			++i; if (item.SOLIN_ANTIGUEDAD>0 ) arrParam[i].Value = item.SOLIN_ANTIGUEDAD;
			++i; if (item.SOLIN_CODIGO_PADRE>0 ) arrParam[i].Value = item.SOLIN_CODIGO_PADRE;
			++i; if (item.SOLIC_FLAG_REINGRESO !="" ) arrParam[i].Value = item.SOLIC_FLAG_REINGRESO;
			++i; if (item.SOLIV_NUM_OPE_CON !="" ) arrParam[i].Value = item.SOLIV_NUM_OPE_CON;			  
			++i; if (item.SOLIN_NUM_CAR_FIJ_LINEA>0 ) arrParam[i].Value = item.SOLIN_NUM_CAR_FIJ_LINEA;
			++i; if (item.SOLIN_ANTIGUEDAD_CLIENTE>0 ) arrParam[i].Value = item.SOLIN_ANTIGUEDAD_CLIENTE;
			++i; if (item.SOLIC_FLAG_EMPRESA_TRAFICO !="" ) arrParam[i].Value = item.SOLIC_FLAG_EMPRESA_TRAFICO;
			++i; if (item.FLAG_RESPONSABLE_PUNTO_VENTA !="" ) arrParam[i].Value = item.FLAG_RESPONSABLE_PUNTO_VENTA;
			++i; if (item.SOLIC_FLAG_EMPRESA_TOLERAN !="" ) arrParam[i].Value = item.SOLIC_FLAG_EMPRESA_TOLERAN;
			++i; arrParam[i].Value = item.SOLIN_SUM_CAR_FIN;
			++i; arrParam[i].Value = item.SOLIN_CAR_FIJO_ACTUAL;
			++i; arrParam[i].Value = item.SOLIN_SUBSIDIO_TOTAL;
				
			++i; arrParam[i].Value = item.NRO_LINEAS_RECURRENTE_ACTUAL;
			++i; arrParam[i].Value = item.NRO_LINEAS_MAYOR_N_DIAS;
			++i; arrParam[i].Value = item.NRO_LINEAS_MENOR_N_DIAS;
			++i; arrParam[i].Value = item.DIAS_LINEAS_RECURRENTE;
			++i; arrParam[i].Value = item.SOLIV_COM_DG;
			++i; arrParam[i].Value = item.SOLIV_FLAG_ENVIO;
			++i; if (item.SOLIN_BOLSA_REF>0 ) arrParam[i].Value = item.SOLIN_BOLSA_REF;
			++i; if (item.CAMPN_CODIGO>0 ) arrParam[i].Value = item.CAMPN_CODIGO;
			++i; if (item.EMAIL_AUTORIZADO != "") arrParam[i].Value = item.EMAIL_AUTORIZADO;

			//INICIO - E75688
			++i; arrParam[i].Value = item.FLAG_CORREO;
			++i; arrParam[i].Value = item.SOLIV_CORREO;
			//FIN - E75688
			++i; arrParam[i].Value = item.SOLIN_LINEA_CREDITO_CALC;  //E75810

			//JAR
			++i; arrParam[i].Value = item.DPCHN_CODIGO;
			++i; arrParam[i].Value = item.CLIEV_PRE_DIR;
			++i; arrParam[i].Value = item.CLIEV_DIRECCION;
			++i; arrParam[i].Value = item.CLIEV_REF_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_DEP_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_PRO_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_DIS_DIR;
			++i; arrParam[i].Value = item.CLIEC_COD_POS_DIR;
			++i; arrParam[i].Value = item.CLIEV_PRE_TEL_LEG;
			++i; arrParam[i].Value = item.CLIEV_TEL_LEG;
			++i; arrParam[i].Value = item.CLIEV_PRE_DIR_FAC;
			++i; arrParam[i].Value = item.CLIEV_DIR_FAC;
			++i; arrParam[i].Value = item.CLIEV_REF_DIR_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_DEP_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_PRO_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_DIS_FAC;
			++i; arrParam[i].Value = item.CLIEC_COD_POS_FAC;
			++i; arrParam[i].Value = item.RGLPC_PODERES;
			++i; arrParam[i].Value = item.PACUC_CODIGO;
			++i; arrParam[i].Value = item.TOPEN_CODIGO;
			++i; arrParam[i].Value = item.SOLIC_TIP_CAR_FIJ;
			++i; arrParam[i].Value = item.SOLIN_IMP_DG;
			++i; arrParam[i].Value = item.SOLIN_IMP_DG_MAN;
			++i; arrParam[i].Value = item.TPREC_CODIGO;
			++i; arrParam[i].Value = item.FPAGC_CODIGO;
			++i; arrParam[i].Value = item.SOLIN_USU_VEN;
			++i; if (item.SOLIN_LIM_CRE_FIN>0 ) arrParam[i].Value = item.SOLIN_LIM_CRE_FIN;
			++i; if (item.SOLIN_SUM_CAR_CON>0 ) arrParam[i].Value = item.SOLIN_SUM_CAR_CON;
			++i; arrParam[i].Value = item.TCESC_CODIGO;
			++i; arrParam[i].Value = item.PRDC_CODIGO;
			++i; arrParam[i].Value = item.CLIEV_CALIFICACION_PAGO;
			++i; arrParam[i].Value = item.BURO_CODIGO;
			++i; arrParam[i].Value = item.SOLIN_GRUPO_SEC;
			++i; arrParam[i].Value = item.SOLIN_IMP_DG_GRUPO_SEC;
			++i; arrParam[i].Value = item.SOLIN_CF_GRUPO_SEC;
			++i; arrParam[i].Value = item.CLIEN_MONTO_VENCIDO;
			++i; arrParam[i].Value = item.SOLIV_FACTOR_RENOVACION;

			++i; arrParam[i].Value = item.CLIEV_RIESGO_CLARO;
			++i; arrParam[i].Value = item.CLIEV_COMPORTA_PAGO;

			//FIN JAR
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SECSI_INS_SOL_CORP_RP";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				HelperLog.EscribirLog("", nameArchivo, "correcto: GrabarSolicitudEmpresa ", false);
				salida = true;
			}
			catch( Exception ex )
			{
				HelperLog.EscribirLog("", nameArchivo, "Error: GrabarSolicitudEmpresa " + ex.Message, false);
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Solicitud. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
					
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				HelperLog.EscribirLog("", nameArchivo, "nrosec: " + parSalida1.Value, false);
				codigo = Funciones.CheckInt64(parSalida1.Value);
				HelperLog.EscribirLog("", nameArchivo, "nrosec: " + codigo, false);

				obRequest.Factory.Dispose();
			}			
			return salida ;
		}		
		public bool GrabarSolicitudRepLegal(RepresentanteLegal item,ref Int64 codigo,ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APODC_TIP_DOC_REP", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APODV_NUM_DOC_REP", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APODV_NOM_REP_LEG", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APODV_APA_REP_LEG", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APODV_AMA_REP_LEG", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APODV_CAR_REP", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APODC_CODNACION", DbType.String,40,ParameterDirection.Input),//PROY 31636 RENTESEG
												   new DAABRequest.Parameter("P_APODV_DESCNACION", DbType.String,40,ParameterDirection.Input),//PROY 31636 RENTESEG
			};
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = item.SOLIN_CODIGO;			
			++i; arrParam[i].Value = item.CLIEC_NUM_DOC;
			++i; arrParam[i].Value = item.APODC_TIP_DOC_REP;
			++i; arrParam[i].Value = item.APODV_NUM_DOC_REP;
			++i; arrParam[i].Value = item.APODV_NOM_REP_LEG;
			++i; arrParam[i].Value = item.APODV_APA_REP_LEG;
			++i; arrParam[i].Value = item.APODV_AMA_REP_LEG;
			++i; arrParam[i].Value = item.APODV_CAR_REP;			
			++i; arrParam[i].Value = item.P_SRLC_CODNACIONALIDAD; /*PROY-31636*/
			++i; arrParam[i].Value = item.P_SRLV_DESCNACIONALIDAD; /*PROY-31636*/

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SECSI_INS_REP_LEGAL";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Representante Legal. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
					
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				codigo = Funciones.CheckInt64(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}		

		public bool Registrar_Monto_Vencido(Int64 nroSEC, Double Monto_Vencido, string Bloqueo)
		{						
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTO_VENCIDO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BLOQUEO", DbType.String,ParameterDirection.Input)
											   }; 			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;
			arrParam[1].Value = Monto_Vencido;
			arrParam[2].Value = Bloqueo;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SECSI_INS_CLIE_MV_BLOQUEO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;	
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{		
				obRequest.Factory.Dispose();
			}			
			return salida ;

		}

		public bool RegistrarVenta_DTH(AP_Venta item, Int64 nroSEC, ref string strIdVenta)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Double,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSGERR" ,DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DOCUMENTO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO" ,DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAL" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA_VENTA" ,DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC_CLIENTE" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC_CLIENTE" ,DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONEDA" ,DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPEN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOTAL_VENTA" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUBTOTAL_IMPUESTO" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUBTOTAL_VENTA" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OBSERVACION" ,DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVEN_CODIGO" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUMERO_REFERENCIA" ,DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUMERO_CUOTAS" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR" ,DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ORG_VENTA" ,DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUMERO_SEC" ,DbType.Int64,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;


			i=3; arrParam[i].Value = item.TIPO_DOCUMENTO;			
			++i; arrParam[i].Value = item.CANAL;
			++i; arrParam[i].Value = item.OFICINA_VENTA;
			++i; arrParam[i].Value = item.TIPO_DOC_CLIENTE;
			++i; arrParam[i].Value = item.NRO_DOC_CLIENTE;
			++i; arrParam[i].Value = item.MONEDA;
			++i; arrParam[i].Value = item.TOPEN_CODIGO;
			++i; arrParam[i].Value = item.TOTAL_VENTA;
			++i; arrParam[i].Value = item.SUBTOTAL_IMPUESTO;
			++i; arrParam[i].Value = item.SUBTOTAL_VENTA;
			++i; arrParam[i].Value = item.OBSERVACION;
			++i; arrParam[i].Value = item.TVENC_CODIGO;			
			++i; arrParam[i].Value = item.NUMERO_REFERENCIA;
			++i; arrParam[i].Value = item.USUARIO_CREA;
			++i; arrParam[i].Value = item.NUMERO_CUOTAS;
			++i; arrParam[i].Value = item.VENDEDOR;
			++i; arrParam[i].Value = item.ORG_VENTA;						
			++i; arrParam[i].Value = nroSEC;
						
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_REGISTRA_VENTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				strIdVenta = "Error al Insertar la Venta. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[2];
				strIdVenta = Funciones.CheckStr(pSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool RegistrarVentaDetalle_DTH(AP_VentaDetalle item, Int64 strIdVenta, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Double,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSGERR", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CORRELATIVO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERIAL", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERIAL_DESC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_DESC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA_DESC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCUENTO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String,4,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=2; arrParam[i].Value = item.ORDEN;	
			++i; arrParam[i].Value = strIdVenta;			
			++i; arrParam[i].Value = item.MATERIAL;
			++i; arrParam[i].Value = item.MATERIAL_DESC;
			++i; arrParam[i].Value = item.PLAN;
			++i; arrParam[i].Value = item.PLAN_DESC;
			++i; arrParam[i].Value = item.CAMPANA;
			++i; arrParam[i].Value = item.CAMPANA_DESC;
			++i; arrParam[i].Value = item.DESCUENTO;
			++i; arrParam[i].Value = item.PLAZO;
						
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_REGISTRA_VENTA_DETALLE_DTH";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar el detalle de la Venta. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[2];
				rMsg = Funciones.CheckStr(pSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool RegistrarGarantia_DTH(AP_Garantia item, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Double,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSGERR" ,DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NUMERO_GARANTIA" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOC_CLIENTE" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC_CLIENTE" ,DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTN_DOCUMENTO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTO_GARANTIA" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA" ,DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_CARGOS" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_GARANTIA" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLASE_DOC_SAP" ,DbType.String,5,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;


			i=3; arrParam[i].Value = item.GARAC_TIPO_DOC_CLIENTE;
			++i; arrParam[i].Value = item.GARAV_NRO_DOC_CLIENTE;
			++i; arrParam[i].Value = item.VENTN_DOCUMENTO;
			++i; arrParam[i].Value = item.GARAN_MONTO_GARANTIA;
			++i; arrParam[i].Value = item.GARAV_OFICINA;
			++i; arrParam[i].Value = item.GARAV_USUARIO_CREA;
			++i; arrParam[i].Value = item.GARAN_NRO_CARGOS;
			++i; arrParam[i].Value = item.GARAC_TIPO_GARANTIA;
			++i; arrParam[i].Value = item.CLASE_DOC_SAP;
						
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_REGISTRA_GARANTIA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar los equipos de la venta. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[2];
				rMsg = Funciones.CheckStr(pSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool GrabarComentario(Comentario item, ref int sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COMEV_COMENTARIO", DbType.String,500, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COMEC_USU_REG", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COMEC_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COMEC_FLA_COM", DbType.String, ParameterDirection.Input),
			}; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if(item.SOLIN_CODIGO > 0 ) arrParam[i].Value = item.SOLIN_CODIGO;
			++i; if(item.COMEV_COMENTARIO != "" && item.COMEV_COMENTARIO != null) arrParam[i].Value = item.COMEV_COMENTARIO;
			++i; if(item.COMEC_USU_REG != "" && item.COMEC_USU_REG != null) arrParam[i].Value = item.COMEC_USU_REG;
			++i; if(item.COMEC_ESTADO != "" && item.COMEC_ESTADO != null) arrParam[i].Value = item.COMEC_ESTADO;
			++i; if(item.COMEC_FLA_COM != "" && item.COMEC_FLA_COM != null) arrParam[i].Value = item.COMEC_FLA_COM;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACTI_INS_COMENTARIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
					
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sEstado = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}	

		public bool GrabarArchivo(string P_SOLIN_CODIGO, string P_ARCHV_NOM_ARC, string P_ARCHV_RUT_ARC, string P_ARCHC_USU_REG, ref Int64 codigo, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ARCHV_NOM_ARC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ARCHV_RUT_ARC", DbType.String,250,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ARCHC_USU_REG", DbType.String,20,ParameterDirection.Input),
			};
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = P_SOLIN_CODIGO;
			++i; arrParam[i].Value = P_ARCHV_NOM_ARC;
			++i; arrParam[i].Value = P_ARCHV_RUT_ARC;
			++i; arrParam[i].Value = P_ARCHC_USU_REG;
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SECSI_INS_ARCHIVO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Representante Legal. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
					
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				codigo = Funciones.CheckInt64(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public string AsignarBuroCrediticio(string strDocumento, ref string strUrl, ref string strKey)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_BURO", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_URL", DbType.String, 150, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_KEY", DbType.String, 10, ParameterDirection.Output)}; 
			arrParam[0].Value = strDocumento;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_ID_BURO_CONSULTA";
			obRequest.Parameters.AddRange(arrParam);
			
			string idBuro;
			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter p1, p2, p3;
				p1 = (IDataParameter)obRequest.Parameters[1];
				p2 = (IDataParameter)obRequest.Parameters[2];
				p3 = (IDataParameter)obRequest.Parameters[3];
				idBuro = Funciones.CheckStr(p1.Value);
				strUrl = Funciones.CheckStr(p2.Value);
				strKey = Funciones.CheckStr(p3.Value);
			}
			catch (Exception)
			{	
				if (strDocumento != ConfigurationSettings.AppSettings["constCodTipoDocumentoRUC"])
				{
					idBuro = ConfigurationSettings.AppSettings["constCodBuroDataCreditoDNI"];
					strUrl = ConfigurationSettings.AppSettings["RutaWS_DC_1"];
					strKey = ConfigurationSettings.AppSettings["keyDataCredito_1"];
				}
				else
				{
					idBuro = ConfigurationSettings.AppSettings["constCodBuroDataCreditoRUC"];
					strUrl = ConfigurationSettings.AppSettings["RutaWS_DcCorp"];
					strKey = ConfigurationSettings.AppSettings["keyDataCreditoCorp"];
				}
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return idBuro;
		}

		//PROY-24740
		public SolicitudEmpresa ObtenerSolicitudEmpresa(string nroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_REP_LEGAL", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_DIRECCION", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			string[] sTab = {"solicitud","representante","direccion"}; 
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = string.Format("{0}{1}" ,BaseDatos.PKG_SISACT_EVALUACION , ".SECSS_DET_SOL_CORP");
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr=null;
			SolicitudEmpresa item = new SolicitudEmpresa();
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					item.SOLIN_CODIGO = Funciones.CheckInt64(dr["SOLIN_CODIGO"]); 
					item.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]); 
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]); 
					item.OVENC_CODIGO = Funciones.CheckStr(dr["OVENC_CODIGO"]); 
					item.CANAC_CODIGO = Funciones.CheckStr(dr["CANAC_CODIGO"]); 
					item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]); 
					item.SOLID_FEC_REG = Funciones.CheckDate(dr["SOLID_FEC_REG"]); 
					item.CLIEV_NOMBRE = Funciones.CheckStr(dr["CLIEV_NOMBRE"]); 
					item.CLIEV_APE_PAT = Funciones.CheckStr(dr["CLIEV_APE_PAT"]); 
					item.CLIEV_APE_MAT = Funciones.CheckStr(dr["CLIEV_APE_MAT"]); 
					item.CLIEV_RAZ_SOC = Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]); 
					item.TDOCC_CODIGO = Funciones.CheckStr(dr["TDOCC_CODIGO"]); 
					item.ESTAC_CODIGO = Funciones.CheckStr(dr["ESTAC_CODIGO"]); 
					item.SOLIC_FLA_TER = Funciones.CheckStr(dr["SOLIC_FLA_TER"]); 
					item.TEVAC_CODIGO = Funciones.CheckStr(dr["TEVAC_CODIGO"]); 
					item.SOLIC_EXI_BSC_FIN = Funciones.CheckStr(dr["SOLIC_EXI_BSC_FIN"]);
					item.CLIEC_NUM_DOC = Funciones.NroDocumentoIdentidad(Funciones.CheckStr(dr["TDOCC_CODIGO"]),Funciones.CheckStr(dr["CLIEC_NUM_DOC"]));
					item.CLIEN_CAP_SOC = Funciones.CheckStr(dr["CLIEN_CAP_SOC"]);
					item.FPAGC_CODIGO = Funciones.CheckStr(dr["FPAGC_CODIGO"]);
					item.SOLIN_CAN_LIN = Funciones.CheckInt(dr["SOLIN_CAN_LIN"]);
					item.RFINC_CODIGO = Funciones.CheckStr(dr["RFINC_CODIGO"]);
					item.RFINV_DESCRIPCION = Funciones.CheckStr(dr["RFINV_DESCRIPCION"]); 
					item.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]); 
					item.SOLIN_IMP_DG_MAN = Funciones.CheckDbl(dr["SOLIN_IMP_DG_MAN"]); 
					item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]); 
					item.CCLIC_CODIGO = Funciones.CheckStr(dr["CCLIC_CODIGO"]); 					
					item.FLEXN_CODIGO = Funciones.CheckInt(dr["FLEXN_CODIGO"]); 
					item.FLEXV_DESCRIPCION = Funciones.CheckStr(dr["FLEXV_DESCRIPCION"]); 
					item.AUTORIZADOR = Funciones.CheckStr(dr["AUTORIZADOR"]); 
					item.USUAN_CODIGO = Funciones.CheckInt64(dr["USUAN_CODIGO"]); 
					item.CLASC_CODIGO = Funciones.CheckStr(dr["CLASC_CODIGO"]); 
					item.CLASV_DESCRIPCION = Funciones.CheckStr(dr["CLASV_DESCRIPCION"]); 
					item.OPERV_DESCRIPCION = Funciones.CheckStr(dr["OPERV_DESCRIPCION"]); 
					item.SOLIN_CAN_LIN_EXCOMP = Funciones.CheckInt(dr["SOLIN_CAN_LIN_EXCOMP"]); 
					item.TRIEC_CODIGO = Funciones.CheckStr(dr["TRIEC_CODIGO"]); 
					
					item.SOLIN_NUM_CAR_FIJ = Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ"]); 					
					item.CANTIDAD_CARGOS_FIJOS= Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ"]);
					
					item.VENDEDOR_ID = Funciones.CheckInt64(dr["SOLIN_VENDEDOR"]); 
					item.DISTRIBUIDOR_ID = Funciones.CheckStr(dr["DISTC_CODIGO"]); 
					
					
					item.CONSULTOR_ID= Funciones.CheckInt64(dr["CONSULTOR_CODIGO"]);
					item.CONSULTOR_DES= Funciones.CheckStr(dr["CONSULTOR_NOMBRE"]); 

					item.TOFIC_CODIGO= Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					item.TOFIV_DESCRIPCION= Funciones.CheckStr(dr["TOFIV_DESCRIPCION"]);
					item.SOLIV_COM_PUN_VEN= Funciones.CheckStr(dr["SOLIV_COM_PUN_VEN"]);
					item.SOLIN_DEUDA_CLIENTE= Funciones.CheckDbl(dr["SOLIN_DEUDA_CLIENTE"]);
					item.SOLIN_LINEA_CLIENTE= Funciones.CheckInt(dr["SOLIN_LINEA_CLIENTE"]);
					item.SOLIN_ANTIGUEDAD= Funciones.CheckDbl(dr["SOLIN_ANTIGUEDAD"]);                	
					item.SOLIC_TIP_CAR_MAN = Funciones.CheckStr(dr["SOLIC_TIP_CAR_MAN"]);                	
					item.OPERC_CODIGO= Funciones.CheckStr(dr["OPERC_CODIGO"]);                											
					item.CLIEN_PROM_VEN= Funciones.CheckDbl(dr["CLIEN_CAP_SOC"]); 
					item.SOLID_FEC_DEPOSITO = Funciones.CheckDate(dr["SOLID_FEC_DEPOSITO"]); 
					item.SOLIV_COD_VOUCHER = Funciones.CheckStr(dr["SOLIV_COD_VOUCHER"]); 
					item.ACTIVADOR_ID = Funciones.CheckStr(dr["SOLIC_COD_APROB"]); 					
					item.MOTIVO_RECHAZO = Funciones.CheckStr(dr["SOLIV_MOTIVO_RECHAZO"]);
					item.SOLIN_CODIGO_PADRE = Funciones.CheckInt64(dr["SOLIN_CODIGO_PADRE"]); 
					item.ALMAC_CODIGO = Funciones.CheckStr(dr["ALMAC_CODIGO"]);
					item.ALMAV_DESCRIPCION = Funciones.CheckStr(dr["ALMAV_DESCRIPCION"]);
					item.SOLIV_COM_DESPACHO = Funciones.CheckStr(dr["SOLIV_COM_DESPACHO"]);
					item.SOLID_FEC_ACTIV = Funciones.CheckDate(dr["SOLID_FEC_ACTIV"]);
					item.SOLIV_NUM_OPE_CON  = Funciones.CheckStr(dr["SOLIV_NUM_OPE_CON"]);
					item.SOLIN_NUM_CAR_FIJ_LINEA = Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ_LINEA"]); 					
					item.SOLIN_ANTIGUEDAD_CLIENTE = Funciones.CheckDbl(dr["SOLIN_ANTIGUEDAD_CLIENTE"]); 					
					item.SOLIC_FLAG_EMPRESA_TRAFICO = Funciones.CheckStr(dr["SOLIC_FLAG_EMPRESA_TRAFICO"]);
					
					item.TIPO_OPERACION_DES = Funciones.CheckStr(dr["TOPEV_DESCRIPCION"]);					
					item.NRO_CONTRATO = Funciones.CheckStr(dr["SOLIV_NUM_ACU"]);
					item.FLAG_RESPONSABLE_PUNTO_VENTA = Funciones.CheckStr(dr["SOLIV_FLA_VER_RES"]);

					item.SOLIN_SUM_CAR_FIN = Funciones.CheckDbl(dr["SOLIN_SUM_CAR_FIN"]);
					item.SOLID_FEC_OBS	= Funciones.CheckDate(dr["SOLID_FEC_OBS"]);
					item.SOLIN_CAR_FIJO_ACTUAL = Funciones.CheckDbl(dr["SOLIN_CAR_FIJO_ACTUAL"]);	
					item.SOLIN_NUM_CAR_FIJ_ADI = Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ_ADI"]);	
					item.SOLIN_SUBSIDIO_TOTAL = Funciones.CheckDbl(dr["SOLIN_SUBSIDIO_TOTAL"]);	
					item.SOLIN_NUM_RA = Funciones.CheckDbl(dr["SOLIN_NUM_RA"]);	
					item.SOLIN_IMP_RA = Funciones.CheckDbl(dr["SOLIN_IMP_RA"]);	
					item.SOLIN_NUM_CAR_FIJ_SIS = Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ_SIS"]);
					item.SOLIV_COM_EVALUADOR = Funciones.CheckStr(dr["SOLIV_COM_EVAL"]); 

					item.NRO_LINEAS_RECURRENTE_ACTUAL = Funciones.CheckInt(dr["LINEAS_RECURRENTE_ACTUAL"]);
					item.NRO_LINEAS_MAYOR_N_DIAS = Funciones.CheckInt(dr["LINEAS_MAYOR_N_DIAS"]);
					item.NRO_LINEAS_MENOR_N_DIAS = Funciones.CheckInt(dr["LINEAS_MENOR_N_DIAS"]);
					item.DIAS_LINEAS_RECURRENTE = Funciones.CheckInt(dr["PARAM_DIAS_RECURRENTE"]);
					item.TIPO_RIESGO_DES = Funciones.CheckStr(dr["TIPO_RIESGO_DES"]);
					item.SOLIV_COM_DG= Funciones.CheckStr(dr["SOLIV_COM_DG"]);
					item.SOLIV_FLAG_ENVIO = Funciones.CheckStr(dr["SOLIV_FLAG_ENVIO"]);

					item.DISTRIBUIDOR_DES = Funciones.CheckStr(dr["DISTRIBUIDOR_DES"]); 
					item.SOLIN_BOLSA_REF = Funciones.CheckDbl(dr["SOLIN_BOLSA_REF"]);

					item.CAMPN_CODIGO = Funciones.CheckInt64(dr["CAMPN_CODIGO"]);
					item.ANEXO2 = Funciones.CheckStr(dr["ANEXO_2"]);
					//T12639 - Datos para la portabilidad 
					item.FLAG_PORTABILIDAD = Funciones.CheckStr(dr["FLAG_PORTABILIDAD"]);
					item.PORT_OPER_CED = Funciones.CheckInt(dr["PORT_OPER_CED"]);
					item.PORT_CARGO_FIJO_OPE_CED = Funciones.CheckStr(dr["PORT_CARGO_FIJO_OPE_CED"]);
					item.TLINC_CODIGO_CEDENTE = Funciones.CheckStr(dr["TLINC_CODIGO_CEDENTE"]);
					item.PORT_SOLIN_NRO_FORMATO = Funciones.CheckStr(dr["PORT_SOLIN_NRO_FORMATO"]);
					item.SOLIN_CAN_LIN_REG = Funciones.CheckInt(dr["SOLIN_CAN_LIN_REG"]);

					//INICIO - E75688
					item.FLAG_CORREO = Funciones.CheckStr(dr["CLIEV_FLAG_CORREO"]);
					item.SOLIV_CORREO = Funciones.CheckStr(dr["CLIEV_CORREO"]);
					item.SOLIV_TELCONF_SMS = Funciones.CheckStr(dr["CLIEV_TEL_SMS"]);
					//FIN
				}

				dr.NextResult();
				// para los representantes legal
				
				ArrayList representantes = new ArrayList();

				while(dr.Read())
				{
					Int64 representante_id = Funciones.CheckInt64(dr["APODN_CODIGO"]);
					if (representante_id>0)
					{
						RepresentanteLegal oRepre = new RepresentanteLegal();
						oRepre.APODN_CODIGO = representante_id;
						oRepre.APODV_NOM_REP_LEG = Funciones.CheckStr(dr["APODV_NOM_REP_LEG"]); 
						oRepre.APODV_APA_REP_LEG = Funciones.CheckStr(dr["APODV_APA_REP_LEG"]); 
						oRepre.APODV_AMA_REP_LEG = Funciones.CheckStr(dr["APODV_AMA_REP_LEG"]); 
						oRepre.APODC_TIP_DOC_REP = Funciones.CheckStr(dr["APODC_TIP_DOC_REP"]); 
						oRepre.APODV_NUM_DOC_REP = Funciones.CheckStr(dr["APODV_NUM_DOC_REP"]); 
						oRepre.TPODC_CODIGO = Funciones.CheckStr(dr["TPODC_CODIGO"]); 
						oRepre.APODV_CAR_REP = Funciones.CheckStr(dr["APODV_CAR_REP"]); 
						oRepre.TDOCV_DESCRIPCION_REP = Funciones.CheckStr(dr["TDOCV_DESCRIPCION_REP"]); 
						representantes.Add(oRepre);
					}
				}
				
				item.REPRESENTANTE_LEGAL = representantes;

				dr.NextResult();

				while(dr.Read())
				{										
					item.CLIEV_PRE_DIR = Funciones.CheckStr(dr["CLIEV_PRE_DIR"]);
					item.CLIEV_REF_DIR = Funciones.CheckStr(dr["CLIEV_REF_DIR"]);
					item.CLIEC_COD_DEP_DIR = Funciones.CheckStr(dr["CLIEC_COD_DEP_DIR"]);
					item.CLIEC_COD_PRO_DIR = Funciones.CheckStr(dr["CLIEC_COD_PRO_DIR"]);
					item.CLIEC_COD_DIS_DIR = Funciones.CheckStr(dr["CLIEC_COD_DIS_DIR"]);

					item.CLIEC_COD_POS_DIR = Funciones.CheckStr(dr["CLIEC_COD_POS_DIR"]);
					item.CLIEV_TEL_LEG = Funciones.CheckStr(dr["CLIEV_TEL_LEG"]);
					item.CLIEV_PRE_DIR_FAC = Funciones.CheckStr(dr["CLIEV_PRE_DIR_FAC"]);
					item.CLIEV_REF_DIR_FAC = Funciones.CheckStr(dr["CLIEV_REF_DIR_FAC"]);
					item.CLIEC_COD_DEP_FAC = Funciones.CheckStr(dr["CLIEC_COD_DEP_FAC"]);
					item.CLIEC_COD_PRO_FAC = Funciones.CheckStr(dr["CLIEC_COD_PRO_FAC"]);
					item.CLIEC_COD_DIS_FAC = Funciones.CheckStr(dr["CLIEC_COD_DIS_FAC"]);
					item.CLIEC_COD_POS_FAC = Funciones.CheckStr(dr["CLIEC_COD_POS_FAC"]);
					
				}
			}
			finally
			{	
				if(dr!=null && dr.IsClosed==false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return item;
		}

		//Utiliza el Código de Evaluador para el Filtro
		public ArrayList ObtenerListaPoolEvaluadorPendienteConsumer2(string login,string estado)
		{			
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_APROBADOR", DbType.String,10,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = login;
			arrParam[1].Value = estado;
			
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			string[] sTab = {"detalle","reingreso"}; 
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACTS_CON_POOL_EVAL_PEND_CON";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList lista = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					SolicitudEmpresa item = new SolicitudEmpresa();
					item.SOLIN_CODIGO = Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
					if (item.SOLIN_CODIGO >0)
					{
						item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]);
						item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);					
						item.NUM_DOCU = Funciones.CheckStr(dr["CLIEC_NUM_DOC"]);
						if (Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]) == "" )
						{
							item.RAZON_SOCIAL = Funciones.CheckStr(dr["CLIEV_NOMBRE"]) + " " + Funciones.CheckStr(dr["CLIEV_APE_PAT"]) + " " + Funciones.CheckStr(dr["CLIEV_APE_MAT"]);
						}
						else
						{
							item.RAZON_SOCIAL = Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]);
						}
						item.FECHA_APROBACION = Funciones.CheckDate(dr["SOLID_FEC_APR"]);
						item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
						item.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
						item.SOLIN_IMP_DG_MAN = Funciones.CheckDbl(dr["SOLIN_IMP_DG_MAN"]);
						item.SOLIN_NUM_CAR_FIJ= Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ"]);
						item.TDOCC_CODIGO= Funciones.CheckStr(dr["TDOCC_CODIGO"]);
						item.ESTAC_CODIGO = Funciones.CheckStr(dr["ESTAC_CODIGO"]);
						item.SOLIC_FLA_TER = Funciones.CheckStr(dr["SOLIC_FLA_TER"]);
						item.MOTIVO_RECHAZO = Funciones.CheckStr(dr["SOLIV_MOTIVO_RECHAZO"]);										
						item.CANTIDAD_LINEAS = Funciones.CheckInt(dr["SOLIN_CAN_LIN"]);
						item.SOLIC_FLAG_REINGRESO = Funciones.CheckStr(dr["SOLIC_FLAG_REINGRESO"]);
						item.ACTIVADOR_ID= Funciones.CheckStr(dr["SOLIC_COD_APROB"]);
						item.SOLIV_EMPRESA_TOP_DES = Funciones.CheckStr(dr["EMPRESA_TOP"]);

						lista.Add(item);					
					}
				}				
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{	
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return lista;						
		}

		public bool GrabarRechazoSolicitudConsumer(Int64 secId,string usuario_login,string motivo_id,string obs, string codestado, ref string rProceso, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {					
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MOTIVO_ID", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OBS", DbType.String,300,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROCESO", DbType.String,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = secId;
			arrParam[1].Value = usuario_login;
			if (motivo_id != null && motivo_id != "") arrParam[2].Value = motivo_id;
			arrParam[3].Value = obs;			
			arrParam[4].Value = codestado;
			
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Transactional = true;
		
			obRequest.Parameters.Clear();
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACU_RECHAZO_SOLICITUD_CONS";
			obRequest.Parameters.AddRange(arrParam);			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Grabar Rechazo de la solicitud. Mensaje : " + ex.Message;
				throw ex;
			}
			finally
			{	
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				rProceso = Funciones.CheckStr(pSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public RazonesEvaluacion ListaRazonesEvaluacion(string nroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_LIST_RAZONES_EVALUACION";
			obRequest.Parameters.AddRange(arrParam);
			
			RazonesEvaluacion item = new RazonesEvaluacion();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					
					item.solic_reglas_duras_dc = Funciones.CheckStr(dr["solic_reglas_duras_dc"]);
					item.SRDUV_DESCRIPCION = Funciones.CheckStr(dr["SRDUV_DESCRIPCION"]); 
					item.solic_alerta_comportamiento_dc = Funciones.CheckStr(dr["solic_alerta_comportamiento_dc"]); 
					item.SACOV_DESCRIPCION = Funciones.CheckStr(dr["SACOV_DESCRIPCION"]); 
					item.solic_alertas_dc = Funciones.CheckInt(dr["solic_alertas_dc"]); 
					item.solic_correspondencia_saldo_dc = Funciones.CheckStr(dr["solic_correspondencia_saldo_dc"]); 
					item.SCSAV_DESCRIPCION_DE_RANGO = Funciones.CheckStr(dr["SCSAV_DESCRIPCION_DE_RANGO"]); 		
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

		public ArrayList ListaNodosAdversas(string nroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_LIST_NODOS_EVALUACION";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			//Nodos_Evaluacion item = new Nodos_Evaluacion();
			IDataReader dr = null;
			try
			{
				
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					NodosEvaluacion item = new NodosEvaluacion();
					item.SRNOC_TIPO_RAZON_NODO = Funciones.CheckStr(dr["SRNOC_TIPO_RAZON_NODO"]);
					item.SRNOC_COD_RAZON_NODO = Funciones.CheckStr(dr["SRNOC_COD_RAZON_NODO"]); 
					item.SRNOV_DESCRIPCION = Funciones.CheckStr(dr["SRNOV_DESCRIPCION"]); 
					item.TIPO_RAZON = Funciones.CheckStr(dr["TIPO_RAZON"]); 
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

		public ArrayList ObtenerArchivos(string nroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (	int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SECSS_CON_ARCHIVO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Archivo item = new Archivo();					
					item.ARCHIVO_CODIGO = Funciones.CheckStr(dr["ARCHN_CODIGO"]);
					item.ARCHIVO_NOM = Funciones.CheckStr(dr["ARCHV_NOM_ARC"]);
					item.ARCHIVO_RUTA = Funciones.CheckStr(dr["ARCHV_RUT_ARC"]);
					item.SOLIN_CODIGO = Funciones.CheckStr(dr["SOLIN_CODIGO"]);
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

		public SolicitudPersona ObtenerSolicitudPersonaCons(string nroSEC)
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
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SECSS_DET_SOL_PERS_CONS";
			obRequest.Parameters.AddRange(arrParam);
			
			SolicitudPersona item = new SolicitudPersona();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					item.SOLIN_CODIGO = Funciones.CheckInt64(dr["SOLIN_CODIGO"]); 
					item.CANAC_CODIGO = Funciones.CheckStr(dr["CANAC_CODIGO"]); 
					item.CANAV_DESCRIPCION = Funciones.CheckStr(dr["CANAV_DESCRIPCION"]);
					item.TOFIV_DESCRIPCION = Funciones.CheckStr(dr["TOFIV_DESCRIPCION"]);
					item.SOLIC_EXI_BSC_FIN = Funciones.CheckStr(dr["SOLIC_EXI_BSC_FIN"]);
					item.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]); 
					item.OVENC_CODIGO = Funciones.CheckStr(dr["OVENC_CODIGO"]); 
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]); 
					item.TCESC_CODIGO = Funciones.CheckStr(dr["TCESC_CODIGO"]);
					item.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);
					item.TDOCC_CODIGO = Funciones.CheckStr(dr["TDOCC_CODIGO"]); 
					item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]); 
					item.CLIEC_NUM_DOC = Funciones.NroDocumentoIdentidad(Funciones.CheckStr(dr["TDOCC_CODIGO"]),Funciones.CheckStr(dr["CLIEC_NUM_DOC"]));
					item.CLIEV_NOMBRE = Funciones.CheckStr(dr["CLIEV_NOMBRE"]); 
					item.CLIEV_APE_PAT = Funciones.CheckStr(dr["CLIEV_APE_PAT"]); 
					item.CLIEV_APE_MAT = Funciones.CheckStr(dr["CLIEV_APE_MAT"]); 
					item.TACTC_CODIGO = Funciones.CheckStr(dr["TACTC_CODIGO"]);
					item.TACTV_DESCRIPCION = Funciones.CheckStr(dr["TACTV_DESCRIPCION"]);
					item.TVENC_CODIGO = Funciones.CheckStr(dr["TVENC_CODIGO"]);
					item.TVENV_DESCRIPCION = Funciones.CheckStr(dr["TVENV_DESCRIPCION"]);
					item.FPAGC_CODIGO = Funciones.CheckStr(dr["FPAGC_CODIGO"]); 
					item.FPAGV_DESCRIPCION = Funciones.CheckStr(dr["FPAGV_DESCRIPCION"]);
					item.PACUC_CODIGO = Funciones.CheckStr(dr["PACUC_CODIGO"]);
					item.PACUV_DESCRIPCION = Funciones.CheckStr(dr["PACUV_DESCRIPCION"]);
					item.SOLIC_PLA_TAR_1 = Funciones.CheckStr(dr["PLA_TAR_1"]);
					item.SOLIC_PLA_TAR_2 = Funciones.CheckStr(dr["PLA_TAR_2"]);
					item.SOLIC_PLA_TAR_2 = Funciones.CheckStr(dr["PLA_TAR_3"]);
					item.SOLIC_TIP_CAR_FIJ = Funciones.CheckStr(dr["SOLIC_TIP_CAR_FIJ"]);
					item.SOLIN_NUM_CAR_FIJ = Funciones.CheckStr(dr["SOLIN_NUM_CAR_FIJ"]);
					item.SOLIN_NRO_PLANES_PER = Funciones.CheckStr(dr["SOLIN_NRO_PLANES_PER"]);
					item.SOLIC_COD_PLAN_MAX = Funciones.CheckStr(dr["SOLIC_COD_PLAN_MAX"]);
					item.RDIRV_DESCRIPCION = Funciones.CheckStr(dr["RDIRV_DESCRIPCION"]);
					item.TIPO_GARANTIA_DES= Funciones.CheckStr(dr["TCARV_DESCRIPCION_MAN"]);
					item.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
					item.SOLIV_MEN_PRE = Funciones.CheckStr(dr["SOLIV_MEN_PRE"]);
					item.CCLIC_CODIGO = Funciones.CheckStr(dr["CCLIC_CODIGO"]);
					item.SOLIC_EVA_SUN = Funciones.CheckStr(dr["SOLIC_EVA_SUN"]);
					item.SOLIC_EVA_ESS = Funciones.CheckStr(dr["SOLIC_EVA_ESS"]);
					item.CLIEV_PRE_DIR = Funciones.CheckStr(dr["CLIEV_PRE_DIR"]);
					item.CLIEV_DIRECCION = Funciones.CheckStr(dr["CLIEV_DIRECCION"]);
					item.CLIEV_REF_DIR = Funciones.CheckStr(dr["CLIEV_REF_DIR"]);
					item.CLIEC_COD_DEP_DIR = Funciones.CheckStr(dr["CLIEC_COD_DEP_DIR"]);
					item.DEPAV_DESCRIPCION = Funciones.CheckStr(dr["DEPAV_DESCRIPCION"]);
					item.CLIEC_COD_PRO_DIR = Funciones.CheckStr(dr["CLIEC_COD_PRO_DIR"]);
					item.PROVV_DESCRIPCION = Funciones.CheckStr(dr["PROVV_DESCRIPCION"]);
					item.CLIEC_COD_DIS_DIR = Funciones.CheckStr(dr["CLIEC_COD_DIS_DIR"]);
					item.DISTV_DESCRIPCION = Funciones.CheckStr(dr["DISTV_DESCRIPCION"]);
					item.CLIEC_COD_POS_DIR = Funciones.CheckStr(dr["CLIEC_COD_POS_DIR"]);
					item.CLIEV_TEL_LEG = Funciones.CheckStr(dr["CLIEV_TEL_LEG"]);
					item.CLIEV_PRE_DIR_TRA = Funciones.CheckStr(dr["CLIEV_PRE_DIR_TRA"]);
					item.CLIEV_DIR_TRA = Funciones.CheckStr(dr["CLIEV_DIR_TRA"]);
					item.CLIEV_REF_DIR_TRA = Funciones.CheckStr(dr["CLIEV_REF_DIR_TRA"]);
					item.CLIEC_COD_DEP_TRA = Funciones.CheckStr(dr["CLIEC_COD_DEP_TRA"]);
					item.DEPAV_DESCRIPCION_TRA = Funciones.CheckStr(dr["DEPAV_DESCRIPCION_TRA"]);
					item.CLIEC_COD_PRO_TRA = Funciones.CheckStr(dr["CLIEC_COD_PRO_TRA"]);
					item.PROVV_DESCRIPCION_TRA = Funciones.CheckStr(dr["PROVV_DESCRIPCION_TRA"]);
					item.CLIEC_COD_DIS_TRA = Funciones.CheckStr(dr["CLIEC_COD_DIS_TRA"]);
					item.DISTV_DESCRIPCION_TRA = Funciones.CheckStr(dr["DISTV_DESCRIPCION_TRA"]);
					item.CLIEC_COD_POS_TRA = Funciones.CheckStr(dr["CLIEC_COD_POS_TRA"]);
					item.CLIEV_TEL_FIJ_TRA = Funciones.CheckStr(dr["CLIEV_TEL_FIJ_TRA"]);
					item.CLIEV_TEL_REF_1 = Funciones.CheckStr(dr["CLIEV_TEL_REF_1"]);
					item.CLIEV_TEL_REF_2 = Funciones.CheckStr(dr["CLIEV_TEL_REF_2"]);
					item.CLIEV_PRE_DIR_FAC = Funciones.CheckStr(dr["CLIEV_PRE_DIR_FAC"]);
					item.CLIEV_DIR_FAC = Funciones.CheckStr(dr["CLIEV_DIR_FAC"]);
					item.CLIEV_REF_DIR_FAC = Funciones.CheckStr(dr["CLIEV_REF_DIR_FAC"]);
					item.CLIEC_COD_DEP_FAC = Funciones.CheckStr(dr["CLIEC_COD_DEP_FAC"]);
					item.DEPAV_DESCRIPCION_FAC = Funciones.CheckStr(dr["DEPAV_DESCRIPCION_FAC"]);
					item.CLIEC_COD_PRO_FAC = Funciones.CheckStr(dr["CLIEC_COD_PRO_FAC"]);
					item.PROVV_DESCRIPCION_FAC = Funciones.CheckStr(dr["PROVV_DESCRIPCION_FAC"]);
					item.CLIEC_COD_DIS_FAC = Funciones.CheckStr(dr["CLIEC_COD_DIS_FAC"]);
					item.DISTV_DESCRIPCION_FAC = Funciones.CheckStr(dr["DISTV_DESCRIPCION_FAC"]);
					item.CLIEC_COD_POS_FAC = Funciones.CheckStr(dr["CLIEC_COD_POS_FAC"]);
					item.SOLID_FEC_REG = Funciones.CheckDate(dr["SOLID_FEC_REG"]);
					item.SOLIN_CAN_LIN = Funciones.CheckStr(dr["SOLIN_CAN_LIN"]);
					item.USUAV_NOMBRE = Funciones.CheckStr(dr["USUAV_NOMBRE"]);
					item.TAFIV_DESCRIPCION = Funciones.CheckStr(dr["TAFIV_DESCRIPCION"]);
					item.SOLIV_NUM_TAR = Funciones.CheckStr(dr["SOLIV_NUM_TAR"]);
					item.SOLIV_NOM_TIT_TAR = Funciones.CheckStr(dr["SOLIV_NOM_TIT_TAR"]);
					item.SOLIV_DOC_TIT_TAR = Funciones.CheckStr(dr["SOLIV_DOC_TIT_TAR"]);
					item.SOLIV_FEC_VEN_TAR = Funciones.CheckStr(dr["SOLIV_FEC_VEN_TAR"]);
					item.ENTIV_DESCRIPCION = Funciones.CheckStr(dr["ENTIV_DESCRIPCION"]);
					item.TARJV_DESCRIPCION = Funciones.CheckStr(dr["TARJV_DESCRIPCION"]);
					item.TMONV_DESCRIPCION = Funciones.CheckStr(dr["TMONV_DESCRIPCION"]);
					item.SOLIN_MNTOMAX = Funciones.CheckStr(dr["SOLIN_MNTOMAX"]);
					/*E72373 - TeamSoft (Inicio)*/
					item.SOLIV_COM_PUN_VEN = Funciones.CheckStr(dr["SOLIV_COM_PUN_VEN"]);
					item.SOLIV_COM_EVAL = Funciones.CheckStr(dr["SOLIV_COM_EVAL"]);
					item.SOLIV_NUM_OPE_CON = Funciones.CheckStr(dr["SOLIV_NUM_OPE_CON"]);
					item.SOLIV_NUM_OPE_FIN = Funciones.CheckStr(dr["SOLIV_NUM_OPE_FIN"]);
					item.SOLIN_IMP_DG = Funciones.CheckStr(dr["SOLIN_IMP_DG"]);
					item.SOLIN_ING_SUS  = Funciones.CheckDbl(dr["SOLIN_ING_SUS"]);
					item.RIEV_DESCRIPCION = Funciones.CheckStr(dr["RIEV_DESCRIPCION"]);
					item.SOLIV_RES_EXP_CON = Funciones.CheckStr(dr["SOLIV_RES_EXP_CON"]);
					item.TCARC_CODIGO = Funciones.CheckStr(dr["TCARC_CODIGO"]);
					item.SOLIN_NUM_RA = Funciones.CheckDbl(dr["SOLIN_NUM_RA"]);
					item.SOLIN_NUM_CAR_FIJ_ADI = Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ_ADI"]);
					item.SOLIN_IMP_DG_MAN = Funciones.CheckDbl(dr["SOLIN_IMP_DG_MAN"]);
					item.SOLIC_TIP_CAR_MAN = Funciones.CheckStr(dr["SOLIC_TIP_CAR_MAN"]);
					item.ESTAC_CODIGO=Funciones.CheckStr(dr["ESTAC_CODIGO"]);
					/*E72373 - TeamSoft (Fin)*/

					/*E75638 - CosapiSoft (Inicio)*/
					item.PDIRV_DESCRIPCION_LEGAL=Funciones.CheckStr(dr["PDIRV_DESCRIPCION_LEGAL"]);
					item.PDIRV_DESCRIPCION_FACTURACION=Funciones.CheckStr(dr["PDIRV_DESCRIPCION_FACTURACION"]);
					item.PDIRV_DESCRIPCION_TRABAJO=Funciones.CheckStr(dr["PDIRV_DESCRIPCION_TRABAJO"]);
					item.CLIEV_PRE_TEL_LEG=Funciones.CheckStr(dr["CLIEV_PRE_TEL_LEG"]);
					item.CONSULTOR_CODIGO=Funciones.CheckStr(dr["CONSULTOR_CODIGO"]);
					item.CONSULTOR_NOMBRE=Funciones.CheckStr(dr["CONSULTOR_NOMBRE"]);
					item.SOLIN_USU_VEN=Funciones.CheckStr(dr["SOLIN_USU_VEN"]);
					item.USUAV_NOMBRE=Funciones.CheckStr(dr["USUAV_NOMBRE"]);
					/*E75638 - CosapiSoft (Fin)*/
					
					/*E72373 - TeamSoft (Inicio)*/
					item.SOLIC_FLAG_CONSUMO = Funciones.CheckStr(dr["SOLIC_FLAG_CONSUMO"]);
					/*E72373 - TeamSoft (Fin)*/

					/*E75606 (Venta Express Inicio)*/
					item.SOLIN_LIM_CRE_CON=Funciones.CheckDbl(dr["SOLIN_LIM_CRE_CON"]);
					item.SOLIC_SCO_TXT_CON=Funciones.CheckStr(dr["SOLIC_SCO_TXT_CON"]);
					item.SOLIN_SCO_NUM_CON=Funciones.CheckDbl(dr["SOLIN_SCO_NUM_CON"]);

					item.TCLIC_CODIGO=Funciones.CheckStr(dr["TCLIC_CODIGO"]);
					item.TOPEN_CODIGO=Funciones.CheckStr(dr["TOPEN_CODIGO"]);
					item.DCREV_NUM_OPERACION=Funciones.CheckStr(dr["DCREV_NUM_OPERACION"]);
					item.DCREV_TIPO_RESPUESTA=Funciones.CheckStr(dr["DCREV_TIPO_RESPUESTA"]);
					item.DCREV_TIPO_RESP_DESC=Funciones.CheckStr(dr["DCREV_TIPO_RESP_DESC"]);
					item.DCREC_VALIDAR_CLIENTE=Funciones.CheckStr(dr["DCREC_VALIDAR_CLIENTE"]);
					/*E75606 (Venta Express Fin)*/

					//T12618 - Portabilidad - INICIO
					item.FLAG_PORTABILIDAD = Funciones.CheckStr(dr["FLAG_PORTABILIDAD"]);
					//T12618 - Portabilidad - FIN

					// E75606 - Cliente RUC - INICIO
					item.CLIEV_RAZ_SOC = Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]);
					// E75606 - Cliente RUC - FIN
					
					//INICIO - E75688
					item.FLAG_CORREO = Funciones.CheckStr(dr["CLIEV_FLAG_CORREO"]);
					item.SOLIV_CORREO = Funciones.CheckStr(dr["CLIEV_CORREO"]);
					item.SOLIV_TEL_SMS   = Funciones.CheckStr(dr["CLIEV_TEL_SMS"]);
					item.FECHA_NACIMIENTO = Funciones.CheckDate(dr["CLIED_FEC_NAC"]);
					item.ESTADO_CIVIL_DES   = Funciones.CheckStr(dr["CLIEV_EST_CIV"]);
					item.TITULO_PERSONA_DES =  Funciones.CheckStr(dr["TITULO_DESC"]);
					//FIN
					//E76009 - INCIO DATACREDITO FASE 1
					item.FECHA_NACIMIENTO = Funciones.CheckDate(dr["CLIED_FEC_NAC"]);
					item.ESTADO_CIVIL_DES = Funciones.CheckStr(dr["CLIEV_EST_CIV"]);
					item.PROVV_DESCRIPCION_DC = Funciones.CheckStr(dr["PROVV_DESCRIPCION_DC"]);
					item.DEPAV_DESCRIPCION_DC = Funciones.CheckStr(dr["DEPAV_DESCRIPCION_DC"]);
					item.SOLIN_PUNTAJE_DC = Funciones.CheckInt(dr["SOLIN_PUNTAJE_DC"]);
					item.SOLIC_ANALISIS_DC = Funciones.CheckStr(dr["solic_analisis_dc"]);
					item.SOLIC_SCORE_RANKING_OPER_DC = Funciones.CheckStr(dr["solic_score_ranking_oper_dc"]);
					item.SOLIC_ORIGEN_LC_DC = Funciones.CheckStr(dr["solic_origen_lc_dc"]);
					item.SOLIN_LC_BASE_EXTERNA_DC = Funciones.CheckDbl(dr["solin_lc_base_externa_dc"]);
					item.SOLIN_LC_CLARO_DC = Funciones.CheckDbl(dr["solin_lc_claro_dc"]);
					item.SOLIN_LC_DATA_CREDITO_DC = Funciones.CheckDbl(dr["solin_lc_data_credito_dc"]);
					//E76009 - FIN DATACREDITO FASE 1					
					item.SOLIC_EVA_ESS_INI = Funciones.CheckStr(dr["SOLIC_EVA_ESS_INI"]);
					item.SOLIC_EVA_SUN_INI = Funciones.CheckStr(dr["SOLIC_EVA_SUN_INI"]);
					//MBM
					item.CLIEN_MONTO_VENCIDO = Funciones.CheckDbl(dr["CLIEN_MONTO_VENCIDO"]);
					item.CLIEC_BLOQUEO = Funciones.CheckStr(dr["CLIEC_BLOQUEO"]);
					//MBM Fin
					item.SOLIN_SUM_CAR_CON = Funciones.CheckDbl(dr["SOLIN_SUM_CAR_CON"]);
					item.FECHA_NACIMIENTO_PDV = Funciones.CheckDate(dr["CLIED_FEC_NAC_PDV"]);
					item.FLAG_REINGRESO_SEC = Funciones.CheckStr(dr["FLAG_REINGRESO_SEC"]);
					item.SOLIN_LC_DISPONIBLE = Funciones.CheckDbl(dr["CLIEN_LC_DISPONIBLE"]);
					item.SOLIN_CF_MENORES = Funciones.CheckDbl(dr["CLIEN_CF_MENORES"]);
					item.SOLIN_CF_MAYORES = Funciones.CheckDbl(dr["CLIEN_CF_MAYORES"]);
					item.TPROD_COMERCIALIZAR = Funciones.CheckStr(dr["TPROD_COMERCIALIZAR"]);
					item.ID_VENTA_DTH = Funciones.CheckStr(dr["ID_VENTA_DTH"]);
					//gaa20120518
					item.SOLIN_COST_INST = Funciones.CheckDbl(dr["SOLIN_COSTO_INST_DTH"]);
					//fin gaa20120518
					item.TPROV_DESCRIPCION = Funciones.CheckStr(dr["TOFV_DESCRIPCION"]);
					item.PRDV_DESCRIPCION = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
					item.CREDV_OBS_FLEXIBILIZACION = Funciones.CheckStr(dr["CREDV_OBS_FLEXIBILIZACION"]);
					item.CLIEV_CALIFICACION_PAGO = Funciones.CheckStr(dr["CLIEV_CALIFICACION_PAGO"]);
					item.BURO_DESCRIPCION = Funciones.CheckStr(dr["BURO_DESCRIPCION"]);
					item.TOPEV_DESCRIPCION = Funciones.CheckStr(dr["TOPEV_DESCRIPCION"]);
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

		public DataSet ObtenerDatosContratoDTH(string nroSEC,string NroContrato)
		{			
			//ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONTRATO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR_CONTRATO", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CURSOR_PLAN", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CURSOR_SERV", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CURSOR_KIT", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (	int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if (NroContrato.Length > 0)
			{
				arrParam[0].Value = Funciones.CheckInt64(NroContrato);
			} 
			if (nroSEC.Length > 0)
			{
				arrParam[1].Value = Funciones.CheckInt64(nroSEC);
			} 

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			string[] sTab = {"contrato","planes","servicios", "kits"};
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CONSULTA_DATOS_CONTRATO";
			obRequest.Parameters.AddRange(arrParam);
			
			//filas = new ArrayList();
			DataSet ds = null;

			int idGen = Funciones.CheckInt(DateTime.Now.ToString("hhmmss")); //Autogenerado
			try
			{
				ds= obRequest.Factory.ExecuteDataset(ref obRequest);
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

		public ArrayList ObtenerKitEquipo_DTH(string KitCodigo)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_KITV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
												   
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = KitCodigo;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SECSS_DET_KIT_EQUIPO_DTH"; 
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					Kit_Equipo_AP item = new Kit_Equipo_AP();
					item.KEQV_CODIGO= Funciones.CheckStr(dr["KEQV_CODIGO"]);
					item.MATV_DESCRIPCION=Funciones.CheckStr(dr["MATV_DESCRIPCION"]);
					item.KEQN_CANTIDAD = Funciones.CheckInt(dr["KEQN_CANTIDAD"]);
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

		public ArrayList ObtenerListaHistoricoConsumer(int nroSec,string tipo_documento, string nroDocumento,DateTime fecha_inicio,DateTime fecha_fin, string estac_codigo)
		{			
			DAABRequest.Parameter[] arrParam = {	
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_INICIO", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_FIN", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output),
			}; 
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if (nroSec >0) arrParam[0].Value = nroSec;
			if (tipo_documento!= null && tipo_documento != "") arrParam[1].Value = tipo_documento;
			if (nroDocumento!= null && nroDocumento != "") arrParam[2].Value = nroDocumento.PadLeft(16,'0');
			if(fecha_inicio != new DateTime(1,1,1)) arrParam[3].Value = fecha_inicio;
			if(fecha_fin != new DateTime(1,1,1)) arrParam[4].Value = fecha_fin;
			if (estac_codigo != "00") arrParam[5].Value = estac_codigo;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();  
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACS_CON_HISTORICO_SOL_CONS";
			obRequest.Parameters.AddRange(arrParam);
			

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					SolicitudEmpresa item = new SolicitudEmpresa();
					item.SOLIN_CODIGO = Funciones.CheckInt(dr["SOLIN_CODIGO"]);
					item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]);
					item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);					
					item.NUM_DOCU = Funciones.NroDocumentoIdentidad(Funciones.CheckStr(dr["TDOCC_CODIGO"]),Funciones.CheckStr(dr["CLIEC_NUM_DOC"]));  
					item.CLIEV_NOMBRE = Funciones.CheckStr(dr["CLIEV_NOMBRE"]);
					item.CLIEV_APE_PAT = Funciones.CheckStr(dr["CLIEV_APE_PAT"]);
					item.CLIEV_APE_MAT = Funciones.CheckStr(dr["CLIEV_APE_MAT"]);
					item.FECHA_REG_APROBACION = Funciones.CheckStr(dr["SOLID_FEC_APR"]);
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					item.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
					item.SOLIN_IMP_DG_MAN = Funciones.CheckDbl(dr["SOLIN_IMP_DG_MAN"]);
					item.SOLIN_NUM_CAR_FIJ= Funciones.CheckDbl(dr["SOLIN_NUM_CAR_FIJ"]);
					item.TDOCC_CODIGO= Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.ESTAC_CODIGO = Funciones.CheckStr(dr["ESTAC_CODIGO"]);
					item.SOLIC_FLA_TER = Funciones.CheckStr(dr["SOLIC_FLA_TER"]);
					item.MOTIVO_RECHAZO = Funciones.CheckStr(dr["SOLIV_MOTIVO_RECHAZO"]);										
					item.CANTIDAD_LINEAS = Funciones.CheckInt(dr["SOLIN_CAN_LIN"]);
					item.SOLIC_FLAG_REINGRESO = Funciones.CheckStr(dr["SOLIC_FLAG_REINGRESO"]);
					item.ACTIVADOR_ID= Funciones.CheckStr(dr["SOLIC_COD_APROB"]);
					item.SOLID_FEC_REG = Funciones.CheckDate(dr["SOLID_FEC_REG"]);
					item.SOLIN_SUM_CAR_CON = Funciones.CheckDbl(dr["SOLIN_SUM_CAR_CON"]);
					item.SOLIV_NUM_CON = Funciones.CheckStr(dr["SOLIV_NUM_CON"]);
					item.RIESGO = Funciones.CheckStr(dr["SOLIV_RES_EXP_CON"]);
					item.PRDV_DESCRIPCION = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
					//gaa20121114
					item.PRDC_CODIGO = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					item.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);
					//fin gaa20121114
					if (item.CLIEV_NOMBRE != "" && item.CLIEV_APE_PAT != "")
						item.RAZON_SOCIAL = item.CLIEV_NOMBRE + " " + item.CLIEV_APE_PAT + " " + item.CLIEV_APE_MAT ;

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

		public ArrayList ObtenerLogEstados(Int64 NroSEC)
		{			
			DAABRequest.Parameter[] arrParam = {	
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = NroSEC;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 						
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACS_CON_ESTADOS";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Estado item = new Estado();
					item.NroSEC = Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
					item.ESTAC_CODIGO = Funciones.CheckStr(dr["ESTAC_CODIGO"]);					
					item.HISEV_USUA_REG = Funciones.CheckStr(dr["HISEV_USUA_REG"]);
					item.HISED_FEC_REG = Funciones.CheckDate(dr["HISED_FEC_REG"]);
					item.HISEV_COMENTARIO = Funciones.CheckStr(dr["HISEV_COMENTARIO"]);

					item.HISEV_FLAG_ARCHIVO = Funciones.CheckStr(dr["HISEV_FLAG_ARCHIVO"]);
					item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]);
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

		public void Aprobar_Creditos(VistaSolicitudEvaluacion oItem)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_CAR_FIJ_ADI", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_RA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IMP_DG_MAN", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COM_PUN_VEN", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COM_EVAL", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIP_CAR_MAN", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_APROB", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COST_INST", DbType.Double, ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
			
			i=0; arrParam[i].Value = oItem.SOLIN_CODIGO;
			i++; arrParam[i].Value = oItem.SOLIN_NUM_CAR_FIJ_ADI;
			i++; arrParam[i].Value = oItem.SOLIN_NUM_RA;
			i++; arrParam[i].Value = oItem.SOLIN_IMP_DG_MAN;
			i++; arrParam[i].Value = oItem.SOLIV_COM_PUN_VEN;
			i++; arrParam[i].Value = oItem.SOLIV_COM_EVAL;
			i++; arrParam[i].Value = oItem.SOLIC_TIP_CAR_MAN;
			i++; arrParam[i].Value = oItem.SOLIC_COD_APROB;
			i++; arrParam[i].Value = oItem.SOLIN_COSTO_INST;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SP_APROBAR_CREDITOS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{
				obRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
		}

		public void Rechazar_Creditos(VistaSolicitudEvaluacion oItem)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COM_PUN_VEN", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COM_EVAL", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_APROB", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_REINGRESO_SEC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COST_INST", DbType.Double, ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
			
			i=0; arrParam[i].Value = oItem.SOLIN_CODIGO;
			i++; arrParam[i].Value = oItem.SOLIV_COM_PUN_VEN;
			i++; arrParam[i].Value = oItem.SOLIV_COM_EVAL;
			i++; arrParam[i].Value = oItem.SOLIC_COD_APROB;
			i++; arrParam[i].Value = oItem.FLAG_REINGRESO_SEC;
			i++; arrParam[i].Value = oItem.SOLIN_COSTO_INST;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SP_RECHAZAR_CREDITOS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{
				obRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
		}

		public ArrayList ListarEquiposHFC(string pstrSoplnCodigo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 
			ArrayList filas;
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = pstrSoplnCodigo;
 
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".MANTSS_LISTAR_EQUIPO_HFC";
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo2 = Funciones.CheckStr(dr["SOPLN_CODIGO"]);
					oItem.Codigo = Funciones.CheckStr(dr["CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
					oItem.Valor = Funciones.CheckDbl(dr["PRECIO"]);
					oItem.Numero = Funciones.CheckStr(dr["PAQUETE"]);
					oItem.orden = Funciones.CheckInt(dr["CANTIDAD"]);
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

		public ArrayList ObtenerListaPoolEvaluadorLibreConsumer(string estado,DateTime fecha_inicio,DateTime fecha_fin)
		{			
			DAABRequest.Parameter[] arrParam = {				
												   new DAABRequest.Parameter("P_ESTAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_INICIO", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_FIN", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			
			arrParam[0].Value = estado;
			arrParam[1].Value = fecha_inicio;
			arrParam[2].Value = fecha_fin;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			/*string[] sTab = {"detalle","reingreso"}; 
			obRequest.TableNames = sTab; */
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACTS_CON_POOL_EVAL_LIB_CON";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{

					VistaSolicitud item = new VistaSolicitud ();
					item.solin_codigo = Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
					item.soliv_des_est = Funciones.CheckStr(dr["SOLIV_DES_EST"]);
					item.SOLID_FEC_APR = Funciones.CheckDate(dr["SOLID_FEC_APR"]);
					item.solid_fec_reg = Funciones.CheckDate(dr["SOLID_FEC_REG"]);
					item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);
					item.CLIEC_NUM_DOC = Funciones.NroDocumentoIdentidad(Funciones.CheckStr(dr["TDOCC_CODIGO"]),Funciones.CheckStr(dr["CLIEC_NUM_DOC"]));  				
					item.CLIEV_NOMBRE = Funciones.CheckStr(dr["CLIEV_NOMBRE"]);
					item.CLIEV_APE_PAT = Funciones.CheckStr(dr["CLIEV_APE_PAT"]);
					item.CLIEV_APE_MAT = Funciones.CheckStr(dr["CLIEV_APE_MAT"]);
					item.SOLIV_DES_OFI_VEN = Funciones.CheckStr(dr["SOLIV_DES_OFI_VEN"]);
					item.SOLIN_CAN_LIN = Funciones.CheckInt(dr["SOLIN_CAN_LIN"]);
					item.TCARV_DESCRIPCION = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
					item.SOLIN_IMP_DG = Funciones.CheckStr(dr["SOLIN_IMP_DG"]);
					item.SOLIV_MOTIVO_RECHAZO= Funciones.CheckStr(dr["SOLIV_MOTIVO_RECHAZO"]);
					//Inicio Cosapisoft E75686
					//					if (Funciones.CheckStr(dr["FLAG_PORTABILIDAD"]) == "P")
					//						item.FLAG_PORTABILIDAD = "PORTABILIDAD";
					//					else
					//						item.FLAG_PORTABILIDAD = "NORMAL";
					//Fin Cosapisoft E75686
					
					item.FLAG_PORTABILIDAD = Funciones.CheckStr(dr["FLAG_PORTABILIDAD"]);

					// E75606 - Cliente RUC
					item.TCLIC_CODIGO = Funciones.CheckStr(dr["TCLIC_CODIGO"]);
					item.CLIEV_RAZ_SOC = Funciones.CheckStr(dr["CLIEV_RAZ_SOC"]);
					item.TPROV_DESCRIPCION = Funciones.CheckStr(dr["TOFV_DESCRIPCION"]);
					item.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);
					item.SOLIV_RES_EXP_CON = Funciones.CheckStr(dr["SOLIV_RES_EXP_CON"]);
					//gaa20121114
					item.TPROC_CODIGO = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					//fin gaa20121114
					// E75606 - Cliente RUC
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

		public bool AsignarActivadorDespachador2(Int64 secId,string usuario,string documento, string bandeja, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),				
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_SOLIC_COD_APROB", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIEC_NUM_DOC", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BANDEJA", DbType.String,1,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = secId;
			++i; if(usuario != "" && usuario!="-1") arrParam[i].Value = usuario;                                
			++i; arrParam[i].Value = documento;
			++i; arrParam[i].Value = bandeja;
			
			bool salida = false;			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACU_ASIGNA_ACTIV_DESPACH2";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al asignar activador Mensaje : " + ex.Message;
				throw ex;
			}
			finally
			{	
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		/// <summary>
		/// Metodo		:	ObtenerEvaluacionSolicitud
		/// Proposito	:	
		/// Entradas	:	Nro Sec
		/// Retono		:	Retorna una una solicitud 
		/// </summary>
		public SolicitudEmpresa ObtenerEvaluacionSolicitud(string nroSEC,string flag_bandeja)
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
			string[] sTab = {"solicitud","representante"}; 
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACS_DET_VALIDACION";
			obRequest.Parameters.AddRange(arrParam);
			SolicitudEmpresa item = new SolicitudEmpresa();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					if (flag_bandeja=="A")
					{
						item.ACTIVADOR_ID= Funciones.CheckStr(dr["SOLIC_COD_APROB"]);						
						item.USUAV_NOMBRE= Funciones.CheckStr(dr["NOMBRE_APROB"]);
					}
					else if (flag_bandeja=="E")
					{
						item.ACTIVADOR_ID= Funciones.CheckStr(dr["SOLIC_COD_EVAL"]);
						item.USUAV_NOMBRE= Funciones.CheckStr(dr["NOMBRE_EVALUADOR"]);
					}
					else
					{
						item.ACTIVADOR_ID= Funciones.CheckStr(dr["SOLIV_COD_DESPACHADOR"]);					
						item.USUAV_NOMBRE= Funciones.CheckStr(dr["NOMBRE_DESPACHADOR"]);
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
			return item;
		}

		public string AsignarSECAutomatica(string strUsuario)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Output)}; 
			arrParam[0].Value = strUsuario;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SP_ASIGNAR_SEC_POOL";
			obRequest.Parameters.AddRange(arrParam);
			
			string nroSEC;
			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter p1;
				p1 = (IDataParameter)obRequest.Parameters[1];
				nroSEC = Funciones.CheckStr(p1.Value);
			}
			catch (Exception)
			{				
				nroSEC = "";
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return nroSEC;
		}

		public bool LiberarSECAutomatica(Int64 nroSEC)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input)}; 
			arrParam[0].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SP_LIBERAR_SEC_POOL";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			bool salida;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch (Exception)
			{
				obRequest.Factory.RollBackTransaction();
				salida = false;
			}
			finally
			{					
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return salida;
		}

		public string AsignarNextBuroCrediticio(string strDocumento, string strBuro, ref string strUrl, ref string strKey)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_BURO", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_BURO_NEXT", DbType.Int16, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_URL", DbType.String, 150, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_KEY", DbType.String, 10, ParameterDirection.Output)}; 
			arrParam[0].Value = strDocumento;
			arrParam[1].Value = strBuro;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_ID_BURO_NEXT";
			obRequest.Parameters.AddRange(arrParam);
			
			string idBuroNext;
			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter p1, p2, p3;
				p1 = (IDataParameter)obRequest.Parameters[2];
				p2 = (IDataParameter)obRequest.Parameters[3];
				p3 = (IDataParameter)obRequest.Parameters[4];
				idBuroNext = Funciones.CheckStr(p1.Value);
				strUrl = Funciones.CheckStr(p2.Value);
				strKey = Funciones.CheckStr(p3.Value);
			}
		catch (Exception)
			{	
				if (strDocumento != ConfigurationSettings.AppSettings["constCodTipoDocumentoRUC"])
				{
					idBuroNext = ConfigurationSettings.AppSettings["constCodBuroDataCreditoDNI"];
					strUrl = ConfigurationSettings.AppSettings["RutaWS_DC_1"];
					strKey = ConfigurationSettings.AppSettings["keyDataCredito_1"];
				}
				else
				{
					idBuroNext = ConfigurationSettings.AppSettings["constCodBuroDataCreditoRUC"];
					strUrl = ConfigurationSettings.AppSettings["RutaWS_DcCorp"];
					strKey = ConfigurationSettings.AppSettings["keyDataCreditoCorp"];
				}
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return idBuroNext;
		}

		public bool Asociar_Set_Sot(Int64 nroSec_Asoc,Int64  NroSot_Asoc, Int64 nroSec)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SEC_ASOCIADA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOT_ASOCIADA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_RESP", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSG", DbType.String, ParameterDirection.Output)
											   };

			for ( int i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			if(nroSec_Asoc > 0) arrParam[0].Value = nroSec_Asoc;
			if(NroSot_Asoc > 0) arrParam[1].Value = NroSot_Asoc;
			arrParam[2].Value = nroSec;			

			bool salida = false;		

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_ASOCIAR_SEC_SOT";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();	
			
				IDataParameter parSalida;
				IDataParameter parSalida1;
				parSalida = (IDataParameter)obRequest.Parameters[3];
				parSalida1 = (IDataParameter)obRequest.Parameters[4];			
				
				if(Funciones.CheckStr(parSalida.Value) == "0")
				{
					salida = true;
				}
				else
				{
					salida = false;
				}  				
			}
			catch (Exception)
			{
				obRequest.Factory.RollBackTransaction();
				//throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return salida;
		}

		public SolicitudPersona consulta_sec(string nroSEC)
		{
			SolicitudPersona oSolicitud = new SolicitudPersona();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value =   Funciones.CheckInt64(nroSEC);

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_CONSULTA_SEC";
			obRequest.Parameters.AddRange(arrParam);
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					oSolicitud.SOLIN_CODIGO  		= Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
					oSolicitud.SOLIV_NUM_CON		= Funciones.CheckStr(dr["SOLIV_NUM_CON"]);
					oSolicitud.CLIEC_NUM_DOC		=	Funciones.CheckStr(dr["CLIEC_NUM_DOC"]);
					oSolicitud.TDOCC_CODIGO         =    Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					oSolicitud.ESTAC_CODIGO         =    Funciones.CheckStr(dr["ESTAC_CODIGO"]);
					oSolicitud.SOLIV_DES_EST         =    Funciones.CheckStr(dr["SOLIV_DES_EST"]);
					oSolicitud.TPROD_COMERCIALIZAR  =    Funciones.CheckStr(dr["TPROD_COMERCIALIZAR"]);
					oSolicitud.CAMPV_CODIGO         =    Funciones.CheckStr(dr["CAMPV_CODIGO"]);					
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
			return oSolicitud;
		}

		public ArrayList ConsultaCampanaDependiente(string codCampana)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codCampana;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_CON_CAMPANA_DEPEND";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["CAMPANA_PADRE"]);
					item.Codigo2 =  Funciones.CheckStr(dr["TIPO_PROD_PADRE"]);
					item.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
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

		public DataTable ConsultarCompatibilidadTelefono(string pTelRef1)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TEL_REF1", DbType.String, ParameterDirection.Input)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = pTelRef1;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_DOC_TEL_REF1"; 
			obRequest.Parameters.AddRange(arrParam);
			
			DataTable dt = new DataTable();

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

		public ArrayList ConsultarTelefonoDisponible_DTH()
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
												   
											   }; 
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_TELEFONO_DISPONIBLE"; 
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					Telefono item = new Telefono();
					item.NRO_TELEFONO= Funciones.CheckStr(dr["STV_TELEFONO"]);
					item.NRO_SIMCARD=Funciones.CheckStr(dr["STV_SERIE"]);
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

		public bool RegistrarVentaEquipo_DTH(AP_VentaEquipo item, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Double,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSGERR" ,DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_ID_DETALLE" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERIAL" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERIAL_DES" ,DbType.String,50,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANTIDAD" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO" ,DbType.Int64,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;


			i=2; arrParam[i].Value = item.ID_DETALLE;			
			++i; arrParam[i].Value = item.MATERIAL;
			++i; arrParam[i].Value = item.MATERIAL_DES;
			++i; arrParam[i].Value = item.CANTIDAD;
			++i; arrParam[i].Value = item.ID_VENTA;
						
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_REGISTRA_VENTA_EQUIPO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar los equipos de la venta. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public DataTable ListarSolicitudesCoincidentesDTH(string pstrCodTipoDocumento, string pstrNroDocumento, 
			string strCodTipoVenta, string pstrCodTipoCliente, string pstrCodPlazoAcuerdo, string pstrCodCasoEspecial)
		{
			DAABRequest.Parameter[] arrParam = {	
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODTIPDOC", DbType.String, 2, ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_NRODOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODTIPVTA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODTIPCLI", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODPLZACU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODTIPCES", DbType.String, 2, ParameterDirection.Input)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = pstrCodTipoDocumento;
			arrParam[2].Value = pstrNroDocumento;
			arrParam[3].Value = strCodTipoVenta;
			arrParam[4].Value = pstrCodTipoCliente;
			arrParam[5].Value = pstrCodPlazoAcuerdo;
			arrParam[6].Value = pstrCodCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SISACT_LISTAR_SEC_IGUAL_DTH"; 
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				return obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch (Exception)
			{				
				return null;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public ArrayList obtenerComentario(int codigoSec,string tipoComentario)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COMEC_FLA_COM", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(codigoSec > 0) arrParam[0].Value = codigoSec;
			if(tipoComentario != "" && tipoComentario != null) arrParam[1].Value = tipoComentario;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACTS_CON_COMENTARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					Comentario item = new Comentario();
					item.COMEC_CODIGO = Funciones.CheckInt(dr["COMEC_CODIGO"]);
					item.COMEC_ESTADO = Funciones.CheckStr(dr["COMEC_ESTADO"]);
					item.COMEC_FLA_COM = Funciones.CheckStr(dr["COMEC_FLA_COM"]);
					item.COMEC_USU_REG = Funciones.CheckStr(dr["COMEC_USU_REG"]);
					item.COMED_FEC_REG = Funciones.CheckDate(dr["COMED_FEC_REG"]);
					item.COMEV_COMENTARIO = Funciones.CheckStr(dr["COMEV_COMENTARIO"]);
					item.SOLIN_CODIGO = Funciones.CheckInt(dr["SOLIN_CODIGO"]);
					item.COMEC_FLA_COM_DES = Funciones.CheckStr(dr["TABLN_DESCRIPCION"]);
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

		public bool Valida_Sot_Cliente(Int64 nroSot,string tipoDocCliente, string nroDocCliente, string campanaPadre,ref string codRespuesta, ref string msg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NRO_SOT", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC_CLIENTE", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_NRO_DOC_CLIENTE", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA_PADRE", DbType.String,10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_RESP", DbType.String,10, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSG", DbType.String,1000, ParameterDirection.Output)
											   };

			for ( int i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSot;
			arrParam[1].Value = tipoDocCliente;
			arrParam[2].Value = nroDocCliente;
			arrParam[3].Value = campanaPadre;

			bool salida = false;		

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_VALIDA_SOT_CLIENTE";
			obRequest.Parameters.AddRange(arrParam);		

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);							
			}
			catch( Exception ex )
			{				
				throw ex;
			}
			finally
			{
				IDataParameter parSalida;
				IDataParameter parSalida1;
				parSalida = (IDataParameter)obRequest.Parameters[4];
				parSalida1 = (IDataParameter)obRequest.Parameters[5];
				codRespuesta = Funciones.CheckStr(parSalida.Value);
				msg = Funciones.CheckStr(parSalida1.Value);
				if(codRespuesta == "0")
				{
					salida = true;
				}
				else
				{
					salida = false;
				}  
				obRequest.Factory.Dispose();
			}
			return salida;
		}	

		public bool TienePlanIgualDTH(int intpCodSolicitud, int pstrCodPlan, int pintCantidad)
		{
			DAABRequest.Parameter[] arrParam = {	
												   new DAABRequest.Parameter("P_SALIDA", DbType.Int32, ParameterDirection.Output),	
												   new DAABRequest.Parameter("P_CODSOLIC", DbType.Int32, ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_CODPLAN", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANTIDAD", DbType.Int32, ParameterDirection.Input),
												   
			}; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = intpCodSolicitud;
			arrParam[2].Value = pstrCodPlan;
			arrParam[3].Value = pintCantidad;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SISACT_CONTAR_PLAN_IGUAL_DTH";
			obRequest.Parameters.AddRange(arrParam);
						
			
			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];

				return Convert.ToBoolean(parSalida1.Value);
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

		public bool EliminarRecibo(string P_SOLIN_CODIGO,string P_RECIN_CODIGO,ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIN_CODIGO", DbType.String,ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = P_SOLIN_CODIGO;
			arrParam[1].Value = P_RECIN_CODIGO;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SECSI_DEL_RECIBO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Eliminar Recibo. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
												
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool GrabarRecibo(ReciboDeposito item,ref Int64 codigo, ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BANCN_CODIGO", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIV_NRO_OPERACION", DbType.String,60,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIN_MONTO", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECID_FECHA_RECIBO", DbType.DateTime ,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIV_LOGIN", DbType.String ,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIV_TERMINAL", DbType.String ,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIN_CODIGO", DbType.Int64,ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = item.SOLIN_CODIGO;
			++i; arrParam[i].Value = item.BANCO_ID;
			++i; arrParam[i].Value = item.NRO_OPERACION;
			++i; arrParam[i].Value = item.MONTO_DEPOSITO ;
			++i; arrParam[i].Value = item.FECHA_DEPOSITO ;
			++i; arrParam[i].Value = item.LOGIN ;
			++i; arrParam[i].Value = item.TERMINAL ;
			++i; arrParam[i].Value = item.RECIBO_ID;
			

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACT_INS_RECIBO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Representante Legal. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
					
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				codigo = Funciones.CheckInt64(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public ArrayList ListaRecibo(Int64 nrosec, int banco_id, string nro_recibo)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_BANCN_CODIGO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIV_NRO_OPERACION", DbType.String,60,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
		
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if (nrosec>0) arrParam[0].Value = nrosec;
			if (banco_id>0) arrParam[1].Value = banco_id;
			if (nro_recibo != null && nro_recibo != "") arrParam[2].Value = nro_recibo;


			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION + ".SISACT_CON_RECIBO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ReciboDeposito item = new ReciboDeposito();
					item.SOLIN_CODIGO = Funciones.CheckInt64(dr["SOLIN_CODIGO"]);
					item.RECIBO_ID = Funciones.CheckInt(dr["RECIN_CODIGO"]);
					item.BANCO_ID = Funciones.CheckInt(dr["BANCN_CODIGO"]);
					item.BANCO_DES = Funciones.CheckStr(dr["TABLN_DESCRIPCION"]);
					item.MONTO_DEPOSITO = Funciones.CheckDbl(dr["RECIN_MONTO"]);
					item.NRO_OPERACION = Funciones.CheckStr(dr["RECIV_NRO_OPERACION"]);
					item.FECHA_DEPOSITO = Funciones.CheckDate(dr["RECID_FECHA_RECIBO"]);
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


		//consolidado 05012015

		public string ActualizarVentaRenovacionDatosComp(string strNroSEC, string strNroDoc, string nroFactura, string nroContrato, string nroPedido, string strTipoRenovacion, string flagExoneracion, string flagDescuento, string strCanal, string titular, string descuento, string usuarioValidador, string RetenidoFidelizado, string strflag_renovChip, string strMotivoRenovChip)
		{


			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC_CLIE_NUMERO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTRATO_SAP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PEDIDO_SAP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_RENOVACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_EXONERACION",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_DESCUENTO",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAL",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TITULAR",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCUENTO",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USER_VALIDADOR",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_FIDEL_RETEN",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_RENOVCHIP",DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MOT_RENOVCHIP",DbType.String,ParameterDirection.Input)
											   };
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;



			i = 0; i++; arrParam[i].Value = strNroSEC;
			i++; arrParam[i].Value = strNroDoc;
			i++; arrParam[i].Value = nroFactura;
			i++; arrParam[i].Value = nroContrato;
			i++; arrParam[i].Value = nroPedido;
			i++; arrParam[i].Value = strTipoRenovacion;
			i++; arrParam[i].Value = flagExoneracion;
			i++; arrParam[i].Value = flagDescuento;
			i++; arrParam[i].Value = strCanal;
			i++; arrParam[i].Value = titular;
			i++; arrParam[i].Value = descuento;
			i++; arrParam[i].Value = usuarioValidador;
			i++; arrParam[i].Value = RetenidoFidelizado;
			i++; arrParam[i].Value = strflag_renovChip;
			i++; arrParam[i].Value = strMotivoRenovChip;

			string retorno = "";

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SP_UPD_VENTA_RENOVACION_COMP";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				retorno = Funciones.CheckStr(parSalida.Value);

				obRequest.Factory.CommitTransaction();
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return retorno;
		}

		//consolidado 05012015
		//gaa20160308  - MRAF
		public void TraerTipoOperacionBRMS(string pintNroSec, out string pstrTipoOperacion, out string pstrCobroPenalidad)
		{
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("P_NROSEC", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPOOPERACION", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COBROPENALIDAD", DbType.String, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pintNroSec;

			string strTipoOperacion = string.Empty;
			string strCobroPenalidad = string.Empty;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".MANTSS_TRAER_TIPO_OPE_BRMS";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);

				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[1];
				strTipoOperacion = Funciones.CheckStr(parSalida.Value);
				parSalida = (IDataParameter)obRequest.Parameters[2];
				strCobroPenalidad = Funciones.CheckStr(parSalida.Value);
				obRequest.Factory.Dispose();
			}
			catch
			{
				throw;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			pstrTipoOperacion = strTipoOperacion;
			pstrCobroPenalidad = strCobroPenalidad;
		}

		public void InsertarTipoOperacionBRMS(Int64 pintCodSolicitud, Int64 pintTipoOperacion, string pstrCobroPenalidad, double pdobPenalidad, double pdobIGV) 
		{
			DAABRequest.Parameter[] arrParam = {
												new DAABRequest.Parameter("P_NROSEC", DbType.Int64, ParameterDirection.Input),	
												new DAABRequest.Parameter("P_TIPOOPERACION", DbType.Int64, ParameterDirection.Input),
												new DAABRequest.Parameter("P_COBROPENALIDAD", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_PENALIDAD", DbType.Single, ParameterDirection.Input),
												new DAABRequest.Parameter("P_IGV", DbType.Single, ParameterDirection.Input)
									};
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pintCodSolicitud;
			arrParam[1].Value = pintTipoOperacion;
			arrParam[2].Value = pstrCobroPenalidad;
			arrParam[3].Value = pdobPenalidad;
			arrParam[4].Value = pdobIGV;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".MANTSS_INSERT_TIPO_OPE_BRMS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
												
				obRequest.Factory.Dispose();
			}			
		}
		//fin gaa20160308  - MRAF FIN 
	}
}