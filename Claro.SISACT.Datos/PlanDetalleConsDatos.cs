using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for PlanDetalleConsDatos.
	/// </summary>
	public class PlanDetalleConsDatos
	{
		public PlanDetalleConsDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public ArrayList ObtenerPlanesSolicitudConsumer_DTH(string nroSEC)
		{			
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_PLAN", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_SERVICIO", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_KIT", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (	int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			string[] sTab = {"planes","servicios", "kits"};
			obRequest.TableNames = sTab; 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_DTH  + ".SECSS_CON_PLANES_SERVICIOS_DTH";
			obRequest.Parameters.AddRange(arrParam);
			
			filas = new ArrayList();
			DataSet ds = null;

			int idGen = Funciones.CheckInt(DateTime.Now.ToString("hhmmss")); //Autogenerado
			try
			{
				ds= obRequest.Factory.ExecuteDataset(ref obRequest);
				DataTable dt1 = ds.Tables["Planes"];
				DataTable dt2 = ds.Tables["Servicios"];
				DataTable dt3 = ds.Tables["Kits"];
				for(int k=0;k<dt1.Rows.Count;k++)
				{
					DataRow dr = dt1.Rows[k];
					SecPlan_AP oPlan = new SecPlan_AP();
					oPlan.PLNV_CODIGO = Funciones.CheckStr(dr["PLNV_CODIGO"]);                          
					oPlan.PLNV_DESCRIPCION = Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					oPlan.TPROC_CODIGO = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					oPlan.CARGO_FIJO_BASE = Funciones.CheckDbl(dr["PLNN_CARGO_FIJO"]);
					oPlan.TVENC_CODIGO= Funciones.CheckStr(dr["TVENC_CODIGO"]);
					oPlan.SOPLN_CODIGO = Funciones.CheckInt(dr["SOPLN_CODIGO"]);
					oPlan.PACUC_CODIGO = Funciones.CheckStr(dr["PACUC_CODIGO"]);
					oPlan.PACUC_DESCRIPCION = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);					
					oPlan.CAMP_CODIGO = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
					oPlan.PLZO_CODIGO = Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					oPlan.CF_ALQUILER_KIT = Funciones.CheckDbl(dr["SOLIN_CF_ALQUILER_KIT"]);
					oPlan.CARGO_FIJO_EN_SEC = Funciones.CheckDbl(dr["SOLIN_SUM_CAR_CON"]);
					oPlan.CAMP_DESCRIPCION = Funciones.CheckStr(dr["campv_descripcion"]);
					
					for(int j=0;j<dt2.Rows.Count;j++)
					{
						DataRow dr2 = dt2.Rows[j];
						if (Funciones.CheckInt(dr["SOPLN_CODIGO"]) == Funciones.CheckInt(dr2["SOPLN_CODIGO"])) 
						{
							SecServicio_AP oServ = new SecServicio_AP();
							oServ.PLAN = new SecPlan_AP();
							oServ.SERVV_CODIGO = Funciones.CheckStr(dr2["SERVV_CODIGO"]);
							oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr2["SERVV_DESCRIPCION"]);
							oServ.SERVC_ESTADO = Funciones.CheckStr(dr2["SERVC_ESTADO"]);
							oServ.GSRVC_CODIGO = Funciones.CheckStr(dr2["GSRVC_CODIGO"]);
							oServ.SERVN_ORDEN = Funciones.CheckInt(dr2["SERVN_ORDEN"]);
							oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr2["SELECCIONABLE_BASE"]);
							oServ.CARGO_FIJO_BASE = Funciones.CheckDbl(dr2["CARGO_FIJO_BASE"]);
							oServ.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr2["SELECCIONABLE_BASE"]);
							oServ.TSERVC_CODIGO = Funciones.CheckStr(dr2["TIPO_SERVICIO"]);
							
							oPlan.SERVICIOS.Add(oServ);
						}
					}

					for(int z=0;z<dt3.Rows.Count;z++)
					{
						DataRow dr3 = dt3.Rows[z];
						SecKit_AP oKit = new SecKit_AP();
						oKit.PLAN = new SecPlan_AP();
							
						//						oKit.KITV_CODIGO = Funciones.CheckInt(dr3["KITV_CODIGO"]);
						//							oKit.KITV_DESCRIPCION = Funciones.CheckStr(dr3["KITV_DESCRIPCION"]);
						//							oKit.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr3["SELECCIONABLE_BASE"]);
						//							oKit.CARGO_FIJO_BASE = Funciones.CheckInt(dr3["CARGO_FIJO_BASE"]);
						//							oPlan.KITS.Add(oKit);
						oKit.KITV_CODIGO = Funciones.CheckInt(dr3["MATERIAL"]);
						oKit.KITV_DESCRIPCION = Funciones.CheckStr(dr3["MATERIAL_DESC"]);
						oKit.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr3["SELECCIONABLE_BASE"]);
						oKit.CARGO_FIJO_BASE = Funciones.CheckDbl(dr3["TOTAL"]);
						oPlan.KITS.Add(oKit);
						
					}

					filas.Add(oPlan);
				}
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
			return filas;
		}
	
		public bool InsertarKitSolicitud_DTH(SecKit_AP objItemKit)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_KITV_CODIGO" ,DbType.Int64,ParameterDirection.Input)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = objItemKit.SOLIN_CODIGO;
			arrParam[2].Value = objItemKit.KITV_CODIGO;
			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SISACT_INSERTAR_SOL_KITS_DTH";
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

		public bool InsertarPlanSolicitud_DTH(PlanDetalleConsumer objDetalle, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLC_MONTO_TOTAL" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_MONTO_UNIT" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_CODIGO" ,DbType.String,4,ParameterDirection.Input),
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
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SISACT_INSERTAR_SOL_PLANES_DTH";
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

		public bool InsertarServiciosSolicitud(ArrayList listaServicios)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVV_CODIGO" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVN_PRECIO_SERV" ,DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLSVV_USUARIO_CREA" ,DbType.String, ParameterDirection.Input)
											   };

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_INSERTAR_SERV_SEC";
			try
			{
				foreach (SecServicio_AP oServ in listaServicios)
				{
					string seleccionable = string.Empty;
					double cargoFijo = 0;
					if (oServ.PLAN.PAQUETE.PAQTV_CODIGO != string.Empty && oServ.PLAN.PAQUETE.PAQTV_CODIGO != "00")
					{
						seleccionable = oServ.SELECCIONABLE_EN_PAQUETE;
						cargoFijo = oServ.CARGO_FIJO_EN_PAQUETE;
					}
					else
					{
						seleccionable = oServ.SELECCIONABLE_EN_PLAN;
						cargoFijo = (oServ.CARGO_FIJO_BASE - oServ.DESCUENTO_EN_PLAN);
					}
					if ((Funciones.CheckInt(seleccionable) & 
						(Funciones.CheckInt(SERVICIOS_SELECCIONABLE.OBLIGATORIO) | 
						Funciones.CheckInt(SERVICIOS_SELECCIONABLE.SELECCIONADO))) != 0)
					{

						for (int i=0; i<arrParam.Length;i++)
							arrParam[i].Value = DBNull.Value;

						arrParam[1].Value = oServ.SOLIN_CODIGO;
						arrParam[2].Value = oServ.SOPLN_CODIGO;
						arrParam[3].Value = oServ.SERVV_CODIGO;
						arrParam[4].Value = cargoFijo;
						arrParam[5].Value = oServ.SERVV_USUARIO_CREA;

						obRequest.Parameters.Clear();
						obRequest.Parameters.AddRange(arrParam);
						obRequest.Transactional = true;
						obRequest.Factory.ExecuteNonQuery(ref obRequest);
						obRequest.Factory.CommitTransaction();
					}
					salida = true;
				}
			}
			catch( Exception ex )
			{
				salida = false;
				obRequest.Factory.RollBackTransaction();
				
				throw ex;
			}
			finally
			{
				if (salida)
				{
					/*IDataParameter pSalida1;
					pSalida1 = (IDataParameter)obRequest.Parameters[0];*/
					obRequest.Factory.Dispose();
				}
			}			
			return salida ;
		}
		

	}
}
