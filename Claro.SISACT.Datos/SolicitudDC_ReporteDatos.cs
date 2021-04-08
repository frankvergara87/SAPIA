using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for SolicitudDC_ReporteDatos.
	/// </summary>
	public class SolicitudDC_ReporteDatos
	{
		public SolicitudDC_ReporteDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Renovacion
		public void Insertar_DC_Reporte(Vista_SolicitudDC_Reporte vista)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_DCREV_NUM_OPERACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREN_SOLIN_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREV_OVEN_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREN_USUARIO_REG", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREC_TIPO_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREV_NUM_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREV_APELLIDO_PAT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREV_APELLIDO_MAT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREV_NOMBRE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREN_CANT_INTENTOS", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DCREC_VALIDAR_CLIENTE", DbType.String,ParameterDirection.Input)
											   }; 
			int intCont=0;
			for ( intCont=0; intCont<arrParam.Length;intCont++)
				arrParam[intCont].Value = DBNull.Value;
			
			if(!vista.DCREV_NUM_OPERACION.Equals("")) arrParam[0].Value = vista.DCREV_NUM_OPERACION;
			if(!vista.DCREN_SOLIN_CODIGO.Equals("")) arrParam[1].Value = vista.DCREN_SOLIN_CODIGO;
			if(!vista.DCREV_OVEN_CODIGO.Equals("")) arrParam[2].Value = vista.DCREV_OVEN_CODIGO;
			if(!vista.DCREN_USUARIO_REG.Equals("")) arrParam[3].Value = vista.DCREN_USUARIO_REG;
			if(!vista.DCREC_TIPO_DOCUMENTO.Equals("")) arrParam[4].Value = vista.DCREC_TIPO_DOCUMENTO;
			if(!vista.DCREV_NUM_DOCUMENTO.Equals("")) arrParam[5].Value = vista.DCREV_NUM_DOCUMENTO;
			if(!vista.DCREV_APELLIDO_PAT.Equals("")) arrParam[6].Value = vista.DCREV_APELLIDO_PAT;
			if(!vista.DCREV_APELLIDO_MAT.Equals("")) arrParam[7].Value = vista.DCREV_APELLIDO_MAT;
			if(!vista.DCREV_NOMBRE.Equals("")) arrParam[8].Value = vista.DCREV_NOMBRE;
			if(!vista.DCREN_CANT_INTENTOS.Equals(-1)) arrParam[9].Value = vista.DCREN_CANT_INTENTOS;
			if(!vista.DCREC_VALIDAR_CLIENTE.Equals("")) arrParam[10].Value = vista.DCREC_VALIDAR_CLIENTE;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_INSERTAR_REPORTE_DC";
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

		public void Insertar_Correccion_Nombres(Vista_Correccion_Nombres oItem)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOCUMENTO", DbType.String, 11, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_ANTERIOR", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_AP_PAT_ANTERIOR", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_AP_MAT_ANTERIOR", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_NUEVO", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_AP_PAT_NUEVO", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_AP_MAT_NUEVO", DbType.String, 40, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TERMINAL", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USU_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIED_FEC_NAC", DbType.Date, ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = oItem.SIVNC_TIPO_DOCUMENTO;
			arrParam[1].Value = oItem.SIVNV_NUM_DOCUMENTO;
			arrParam[2].Value = oItem.SIVNV_NOMBRE_ANTERIOR;
			arrParam[3].Value = oItem.SIVNV_APE_PATERNO_ANT;
			arrParam[4].Value = oItem.SIVNV_APE_MATERNO_ANT;
			arrParam[5].Value = oItem.SIVNV_NOMBRE_NUEVO;
			arrParam[6].Value = oItem.SIVNV_APE_PATERNO_NUEVO;
			arrParam[7].Value = oItem.SIVNV_APE_MATERNO_NUEVO;
			arrParam[8].Value = oItem.SIVNV_SOLIN_CODIGO;
			arrParam[9].Value = oItem.SIVNV_TERMINAL;
			arrParam[10].Value = oItem.SIVNV_USUARIO_CREACION;
			arrParam[11].Value = oItem.FECHA_NACIMIENTO;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SP_ACTUALIZAR_NOMBRES_DC";
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

		public bool Insertar_DC_Parametros(DataCredito_Input_Output bean)
		{
			bool respuesta = false;
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NUM_OPERACION", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_INPUT_VALORES", DbType.String,4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OUTPUT_VALORES", DbType.String,4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_DOCUMENTO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_PUNTO_VENTA", DbType.String,5,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FORMA_PAGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_ACTIVACION", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CLIENTE", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_VENTA", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO_ACUERDO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN1", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN2", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN3", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTROL_CONSUMO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESSALUD", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUNAT", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LIMITE_CREDITO", DbType.Double,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCORE_TEXTO", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCORE_NUMERO", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA_DC", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APE_PATERNO", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APE_MATERNO", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRES", DbType.String,40,ParameterDirection.Input),
												   //E76009 Inicio
												   new DAABRequest.Parameter("P_UBIGEO", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CLIENTE_DC", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO_CIVIL_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ORIGEN_LC_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALISIS_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCORE_RANKING_OPER_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PUNTAJE_DC", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_DATA_CREDITO_DC", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_BASE_EXTERNA_DC", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_CLARO_DC", DbType.Decimal,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RAZONES_DC", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_NACE_CLIENTE_DC", DbType.Date,ParameterDirection.Input),					
												   //E76009 Fin
												   new DAABRequest.Parameter("P_BURO_CREDITICIO", DbType.Int64,ParameterDirection.Input)//ADD PROY-20054-IDEA-23849
											   }; 
			int intCont=0;
			for ( intCont=0; intCont<arrParam.Length;intCont++)
				arrParam[intCont].Value = DBNull.Value;
			
			if(!Funciones.CheckStr(bean.IODCV_NUM_OPERACION).Equals("")) arrParam[1].Value = bean.IODCV_NUM_OPERACION;
			if(!Funciones.CheckStr(bean.IODCV_INPUT_VALORES).Equals("")) arrParam[2].Value = bean.IODCV_INPUT_VALORES;
			if(!Funciones.CheckStr(bean.IODCV_OUTPUT_VALORES).Equals("")) arrParam[3].Value = bean.IODCV_OUTPUT_VALORES;
			if(!Funciones.CheckStr(bean.IODCV_TIPO_DOCUMENTO).Equals("")) arrParam[4].Value = bean.IODCV_TIPO_DOCUMENTO;
			if(!Funciones.CheckStr(bean.IODCV_NUM_DOCUMENTO).Equals("")) arrParam[5].Value = bean.IODCV_NUM_DOCUMENTO;
			if(!Funciones.CheckStr(bean.IODCV_USUARIO_REGISTRO).Equals("")) arrParam[6].Value = bean.IODCV_USUARIO_REGISTRO;
			if(!Funciones.CheckStr(bean.IODCV_COD_PUNTO_VENTA).Equals("")) arrParam[7].Value = bean.IODCV_COD_PUNTO_VENTA;
			if(!Funciones.CheckStr(bean.IODCC_FORMA_PAGO).Equals("")) arrParam[8].Value = bean.IODCC_FORMA_PAGO;
			if(!Funciones.CheckStr(bean.IODCC_TIPO_ACTIVACION).Equals("")) arrParam[9].Value = bean.IODCC_TIPO_ACTIVACION;
			if(!Funciones.CheckStr(bean.IODCC_TIPO_CLIENTE).Equals("")) arrParam[10].Value = bean.IODCC_TIPO_CLIENTE;
			if(!Funciones.CheckStr(bean.IODCC_TIPO_VENTA).Equals("")) arrParam[11].Value = bean.IODCC_TIPO_VENTA;
			if(!Funciones.CheckStr(bean.IODCC_PLAZO_ACUERDO).Equals("")) arrParam[12].Value = bean.IODCC_PLAZO_ACUERDO;
			if(!Funciones.CheckStr(bean.IODCC_PLAN1).Equals("")) arrParam[13].Value = bean.IODCC_PLAN1;
			if(!Funciones.CheckStr(bean.IODCC_PLAN2).Equals("")) arrParam[14].Value = bean.IODCC_PLAN2;
			if(!Funciones.CheckStr(bean.IODCC_PLAN3).Equals("")) arrParam[15].Value = bean.IODCC_PLAN3;
			if(!Funciones.CheckStr(bean.IODCC_CONTROL_CONSUMO).Equals("")) arrParam[16].Value = bean.IODCC_CONTROL_CONSUMO;
			if(!Funciones.CheckStr(bean.IODCC_FLAG_ESSALUD).Equals("")) arrParam[17].Value = bean.IODCC_FLAG_ESSALUD;
			if(!Funciones.CheckStr(bean.IODCC_FLAG_SUNAT).Equals("")) arrParam[18].Value = bean.IODCC_FLAG_SUNAT;
			if(!Funciones.CheckStr(bean.IODCC_RIESGO).Equals("")) arrParam[19].Value = bean.IODCC_RIESGO;
			if(!Funciones.CheckStr(bean.IODCC_LIMITE_CREDITO).Equals("")) arrParam[20].Value = bean.IODCC_LIMITE_CREDITO;
			if(!Funciones.CheckStr(bean.IODCC_SCORE_TEXTO).Equals("")) arrParam[21].Value = bean.IODCC_SCORE_TEXTO;
			if(!Funciones.CheckStr(bean.IODCC_SCORE_NUMERO).Equals("")) arrParam[22].Value = bean.IODCC_SCORE_NUMERO;
			if(!Funciones.CheckStr(bean.IODCC_RESPUESTA_DC).Equals("")) arrParam[23].Value = bean.IODCC_RESPUESTA_DC;
			if(!Funciones.CheckStr(bean.IODCV_APE_PATERNO).Equals("")) arrParam[24].Value = bean.IODCV_APE_PATERNO;
			if(!Funciones.CheckStr(bean.IODCV_APE_MATERNO).Equals("")) arrParam[25].Value = bean.IODCV_APE_MATERNO;
			if(!Funciones.CheckStr(bean.IODCV_NOMBRES).Equals("")) arrParam[26].Value = bean.IODCV_NOMBRES;
			//E76009 INICIO
			if(!Funciones.CheckStr(bean.IODCV_UBIGEO).Equals("")) arrParam[27].Value = bean.IODCV_UBIGEO;
			if(!Funciones.CheckStr(bean.IODCC_TIPO_CLIENTE_DC).Equals("")) arrParam[28].Value = bean.IODCC_TIPO_CLIENTE_DC;
			if(!Funciones.CheckStr(bean.IODCC_ESTADO_CIVIL_DC).Equals("")) arrParam[29].Value = bean.IODCC_ESTADO_CIVIL_DC;
			if(!Funciones.CheckStr(bean.IODCC_ORIGEN_LC_DC).Equals("")) arrParam[30].Value = bean.IODCC_ORIGEN_LC_DC;
			if(!Funciones.CheckStr(bean.IODCC_ANALISIS_DC).Equals("")) arrParam[31].Value = bean.IODCC_ANALISIS_DC;
			if(!Funciones.CheckStr(bean.IODCC_SCORE_RANKING_OPER_DC).Equals("")) arrParam[32].Value = bean.IODCC_SCORE_RANKING_OPER_DC;
			if(!Funciones.CheckStr(bean.IODCN_PUNTAJE_DC).Equals("")) arrParam[33].Value = bean.IODCN_PUNTAJE_DC;
			if(!Funciones.CheckStr(bean.IODCN_LC_DATA_CREDITO_DC).Equals("")) arrParam[34].Value = bean.IODCN_LC_DATA_CREDITO_DC;
			if(!Funciones.CheckStr(bean.IODCN_LC_BASE_EXTERNA_DC).Equals("")) arrParam[35].Value = bean.IODCN_LC_BASE_EXTERNA_DC;
			if(!Funciones.CheckStr(bean.IODCN_LC_CLARO_DC).Equals("")) arrParam[36].Value = bean.IODCN_LC_CLARO_DC;
			if(!Funciones.CheckStr(bean.IODCC_RAZONES_DC).Equals("")) arrParam[37].Value = bean.IODCC_RAZONES_DC;
			if(!Funciones.CheckStr(bean.IODCD_FECHA_NACE_CLIENTE_DC).Equals("")) arrParam[38].Value = bean.IODCD_FECHA_NACE_CLIENTE_DC;
			//E76009 FIN
			if(!Funciones.CheckInt(bean.IODCN_BURO_CREDITICIO).Equals("")) arrParam[39].Value = bean.IODCN_BURO_CREDITICIO; //ADD PROY-20054-IDEA-23849

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_INSERTAR_VALORES_IODC1"; //ADD PROY-20054-IDEA-23849
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteScalar(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				
				respuesta = (Funciones.CheckInt64(parSalida1.Value) != 0);
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
			return respuesta;
		}

		public bool Actualizar_Input_Output(DataCredito_Input_Output bean)
		{
				  bool respuesta = false;
				  DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
														 new DAABRequest.Parameter("P_NUM_OPERACION", DbType.String,ParameterDirection.Input),
														 new DAABRequest.Parameter("P_NUM_CF", DbType.Double,ParameterDirection.Input),
														 new DAABRequest.Parameter("P_TIPO_GARANTIA", DbType.String,ParameterDirection.Input),
														 new DAABRequest.Parameter("P_IMPORTE", DbType.Double,ParameterDirection.Input),
														 new DAABRequest.Parameter("P_NUM_SEC", DbType.Int64,ParameterDirection.Input),
														 new DAABRequest.Parameter("P_TIPO_SEC", DbType.String,ParameterDirection.Input)
													 }; 
				  int intCont=0;
				  for ( intCont=0; intCont<arrParam.Length;intCont++)
					  arrParam[intCont].Value = DBNull.Value;
			
				  if(!bean.IODCV_NUM_OPERACION.Equals(String.Empty)) arrParam[1].Value = bean.IODCV_NUM_OPERACION;
				  if(bean.IODCI_NUM_CF != -1) arrParam[2].Value = bean.IODCI_NUM_CF;
				  if(bean.IODCC_TIPO_GARANTIA != "" && bean.IODCC_TIPO_GARANTIA != null) arrParam[3].Value = bean.IODCC_TIPO_GARANTIA;
				  //if(!bean.IODCC_TIPO_GARANTIA.Equals(String.Empty)) arrParam[3].Value = bean.IODCC_TIPO_GARANTIA;
				  if(bean.IODCN_TOTAL_IMPORTE != -1) arrParam[4].Value = bean.IODCN_TOTAL_IMPORTE;
				  if(bean.IODCN_SOLIN_CODIGO != -1) arrParam[5].Value = bean.IODCN_SOLIN_CODIGO;
				  if(bean.IODCV_TIPO_SEC != "" && bean.IODCV_TIPO_SEC != null) arrParam[6].Value = bean.IODCV_TIPO_SEC;
				  //if(!bean.IODCV_TIPO_SEC.Equals(String.Empty)) arrParam[6].Value = bean.IODCV_TIPO_SEC;
			
				  BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				  DAABRequest obRequest = obj.CreaRequest();
				  obRequest.CommandType = CommandType.StoredProcedure;
				  obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_UPD_INPUT_OUT_DC";
				  obRequest.Parameters.AddRange(arrParam);
				  obRequest.Transactional=true;
			
				  try
				  {
					  obRequest.Factory.ExecuteScalar(ref obRequest);
					  obRequest.Factory.CommitTransaction();
					  IDataParameter parSalida1;
					  parSalida1 = (IDataParameter)obRequest.Parameters[0];

					  respuesta = (Funciones.CheckInt64(parSalida1.Value) != 0);
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
				  return respuesta;
		}



	}
}
