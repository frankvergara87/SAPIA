using System;
using System.Data;
using System.Collections;
using System.Configuration; 
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for PlanTarifarioDataAccess.
	/// </summary>
	public class PlanTarifarioDataAccess
	{
		public PlanTarifarioDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataTable ListarEstado()
		{//SISACT_PKG_GENERAL.SP_CON_ITEM()
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.Int32,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = ConfigurationSettings.AppSettings["ConstItemEstado"].ToString();//1;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_ITEM";//BaseDatos.PKG_SISACT_CONSULTAS + ".SP_CON_TIPO_CLIENTE";//revisar el esquema "SISACT_PKG_GENERAL" para cambiarlo
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public DataTable ListarEssaludSunat()
		{//SISACT_PKG_GENERAL.SP_CON_ITEM()
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.Int32,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value =ConfigurationSettings.AppSettings["ConstItemEsSaludSunat"].ToString();// 14;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_ITEM";//BaseDatos.PKG_SISACT_CONSULTAS + ".SP_CON_TIPO_CLIENTE";//revisar el esquema "SISACT_PKG_GENERAL" para cambiarlo
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}
		
		public DataTable ListarTipoPlan()
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.Int32,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = ConfigurationSettings.AppSettings["ConstItemTipoPlan"].ToString();//8;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_ITEM";//BaseDatos.PKG_SISACT_CONSULTAS + ".SP_CON_TIPO_CLIENTE";//revisar el esquema "SISACT_PKG_GENERAL" para cambiarlo
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		
		public DataTable ListarOferta()
		{//SISACT_PKG_GENERAL.SP_CON_TIPO_OFERTA
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command =BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_TIPO_OFERTA";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}


		public DataTable ListarTopeConsumo()
		{//SISACT_PKG_GENERAL.SP_CON_TOPE_CONSUMO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_TOPE_CONSUMO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		
		public DataTable ListarEstadoTope()
		{//SISACT_PKG_GENERAL.SP_CON_ITEM()
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.Int32,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value =ConfigurationSettings.AppSettings["ConstItemEstadoTope"].ToString();// 2;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_ITEM";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		
		public DataTable ListarTipoDespacho()
		{//SISACT_PKG_GENERAL.SP_CON_TIPO_DESPACHO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_TIPO_DESPACHO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}


		public DataTable ListarTipoFlujo()
		{//SISACT_PKG_GENERAL.SP_CON_ITEM()
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.Int32,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value =ConfigurationSettings.AppSettings["ConstItemTipoFlujo"].ToString();// 13;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_ITEM";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public DataTable ListarTipoProducto()
		{//SP_SISACT_LISTAR_RES_CUOTA
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_TIPO_PRO";//falta
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}


		public DataTable ListarTipoDocumento()
		{//SISACT_PKG_GENERAL.SP_CON_TIPO_DOCUMENTO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   //new DAABRequest.Parameter("P_FLAG", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			//int j = 0;
			//arrParam[j].Value = string.Empty;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_TIPO_DOCUMENTO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public DataTable ListarGrupo()
		{//SISACT_PKG_GENERAL.SP_CON_TIPO_CUOTAS
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_LISTAR_GRUPO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}
		public DataTable ListarPlazoAcuerdo(string p_oferta,string p_caso_especial)
		{//SISACT_PKG_GENERAL.SP_CON_PLAZO_ACUERDO()
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_OFERTA", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = p_oferta;
			j++;arrParam[j].Value = p_caso_especial;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_PLAZO_ACUERDO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}


		public DataTable ListarCuotas()
		{//SISACT_PKG_GENERAL.SP_CON_TIPO_CUOTAS
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_TIPO_CUOTA";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}


		public bool InsertarPlanTarifario(PlanTarifario oPlanTarifario, DataTable LlenarDataConsumoEstado,ArrayList ListaDetalle,ArrayList ListaPdv, string strUsuario,DataTable ListaDocumento)
		{	
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANV_DESCRIPCION", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_SAP", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_BSCS", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANV_DES_BASE", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_ESTADO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_TIPO_DESPACHO", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_TIPO_FLUJO", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_EXCLUSIVO_CE", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_TIPO_PLAN", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_GPLNC_CODIGO", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANN_CAR_FIJ", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANN_LIM_CRED_CON", DbType.Decimal, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_RENOVACION", DbType.String, ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( oPlanTarifario.CodigoPlan != null  && oPlanTarifario.CodigoPlan != "") arrParam[i].Value = oPlanTarifario.CodigoPlan;
			++i; if( oPlanTarifario.IdOferta != null  && oPlanTarifario.IdOferta != "") arrParam[i].Value = oPlanTarifario.IdOferta;
			++i; if( oPlanTarifario.DescripcionPlan != null  && oPlanTarifario.DescripcionPlan != "") arrParam[i].Value = oPlanTarifario.DescripcionPlan;
			++i; if( oPlanTarifario.CodigoPlanSap != null  && oPlanTarifario.CodigoPlanSap != "") arrParam[i].Value = oPlanTarifario.CodigoPlanSap;
			++i; if( oPlanTarifario.CodigoPlanBscs != null  && oPlanTarifario.CodigoPlanBscs != "") arrParam[i].Value = oPlanTarifario.CodigoPlanBscs;
			++i; if( oPlanTarifario.DescripcionPlanBase != null  && oPlanTarifario.DescripcionPlanBase != "") arrParam[i].Value = oPlanTarifario.DescripcionPlanBase;
			++i; if( oPlanTarifario.IdEstado != null  && oPlanTarifario.IdEstado != "") arrParam[i].Value = oPlanTarifario.IdEstado;
			++i; if( oPlanTarifario.IdTipoDespacho != null  && oPlanTarifario.IdTipoDespacho != "") arrParam[i].Value = oPlanTarifario.IdTipoDespacho;
			++i; if( oPlanTarifario.IdTipoFlujo != null  && oPlanTarifario.IdTipoFlujo != "") arrParam[i].Value = oPlanTarifario.IdTipoFlujo;
			++i; if( oPlanTarifario.IdExclusivoCasoEspecial != null  && oPlanTarifario.IdExclusivoCasoEspecial != "") arrParam[i].Value = oPlanTarifario.IdExclusivoCasoEspecial;
			++i; if( oPlanTarifario.IdTipoPlan != null  && oPlanTarifario.IdTipoPlan != "")arrParam[i].Value = oPlanTarifario.IdTipoPlan;
			++i; if( oPlanTarifario.IdGrupoPlan != null  && oPlanTarifario.IdGrupoPlan != "") arrParam[i].Value = oPlanTarifario.IdGrupoPlan;			
			++i; if( oPlanTarifario.CargoFijo > 0) arrParam[i].Value = oPlanTarifario.CargoFijo;
			++i; if( oPlanTarifario.LimiteCredito > 0) arrParam[i].Value = oPlanTarifario.LimiteCredito;
			++i; if( strUsuario != null  && strUsuario != "")arrParam[i].Value = strUsuario;
			++i; if( oPlanTarifario.IdTipoProducto != null  && oPlanTarifario.IdTipoProducto != "")arrParam[i].Value = oPlanTarifario.IdTipoProducto;
			++i; if( oPlanTarifario.FlagRenovacion != null  && oPlanTarifario.FlagRenovacion != "")arrParam[i].Value = oPlanTarifario.FlagRenovacion;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_PLAN_TARIFARIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					foreach(DataRow oDataRow in LlenarDataConsumoEstado.Rows)
					{
						bool result=InsertarConsumoEstado(oPlanTarifario.CodigoPlan,Funciones.CheckStr(oDataRow[0]),Funciones.CheckStr(oDataRow[1]));				
					}

					foreach(PuntoVenta oPuntoVenta in ListaPdv)
					{
						bool result=InsertarRestriccionPdv(oPlanTarifario.CodigoPlan,Funciones.CheckStr(oPuntoVenta.TOFIC_CODIGO),Funciones.CheckStr(oPuntoVenta.OVENC_CODIGO));				
					}

					foreach(DetallePlanTarifario oDetallePlanTarifario in ListaDetalle)
					{
						bool result=InsertarPlanDetalle(oPlanTarifario.CodigoPlan,oDetallePlanTarifario.IdDocumento,oDetallePlanTarifario.IdPlazo,oDetallePlanTarifario.IdCuota,oDetallePlanTarifario.ValorCuota);				
					}
					foreach(DataRow oDataRow in ListaDocumento.Rows)
					{
						bool result=InsertarPlanDocumento(oPlanTarifario.CodigoPlan,Funciones.CheckStr(oDataRow[0]));				
					}
					
					salida = true;
					}
				else
					salida = false;
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

		
		public bool InsertarTipoDocumento(string CodPlan,  string valor)
		{//SP_SISACT_INS_TIPO_DOCUMENTO			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO_PLAN_SISACT", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_DOCUMENTO", DbType.String,2,  ParameterDirection.Input)
											   };							
					int i=0;
					for ( i=0; i<arrParam.Length;i++)
						arrParam[i].Value = DBNull.Value;

					i=1; if( CodPlan != null  && CodPlan != "") arrParam[i].Value = CodPlan;
					++i; if( valor != null  && valor != "") arrParam[i].Value = valor;
			
					bool salida = false;
					BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
					DAABRequest obRequest = obj.CreaRequest();
					obRequest.CommandType = CommandType.StoredProcedure;
					obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_TIPO_DOCUMENTO";
					obRequest.Parameters.AddRange(arrParam);
					obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
		public bool InsertarPlazoAcuerdo(string CodPlan,  string valor)
		{//SP_SISACT_INS_PLAZO
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( CodPlan != null  && CodPlan != "") arrParam[i].Value = CodPlan;
			++i; if( valor != null  && valor != "") arrParam[i].Value = valor;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_PLAZO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
		public bool InsertarCuotas(string CodPlan, string codigo,decimal inicial)
		{//SP_SISACT_INS_CUOTAS
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO_PLAN_SISACT", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOTA_CODIGO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOTA_INICIAL", DbType.Decimal,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( CodPlan != null  && CodPlan != "") arrParam[i].Value = CodPlan;
			++i; if( codigo != null  && codigo != "") arrParam[i].Value = codigo;
			++i; if( inicial  > 0) arrParam[i].Value = inicial;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_CUOTAS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
		public bool InsertarConsumoEstado(string CodPlan,string valor, string estado)
		{//SP_SISACT_INS_TOPE
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO_PLAN_SISACT", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPE_CODIGO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPE_ESTADO", DbType.String,2,  ParameterDirection.Input)
			};							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( CodPlan != null  && CodPlan != "") arrParam[i].Value = CodPlan;
			++i; if( valor != null  && valor != "") arrParam[i].Value = valor;
			++i; if( estado != null  && estado != "") arrParam[i].Value = estado;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_TOPE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
		public bool InsertarRestriccionPdv(string CodPlan, string TOFIC_CODIGO,string OVENC_CODIGO)
		{//SP_SISACT_INS_RESTRICCION_PDV
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO_PLAN_SISACT", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOFIC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( CodPlan != null  && CodPlan != "") arrParam[i].Value = CodPlan;
			++i; if( TOFIC_CODIGO != null  && TOFIC_CODIGO != "") arrParam[i].Value = TOFIC_CODIGO;
			++i; if( OVENC_CODIGO != null  && OVENC_CODIGO != "") arrParam[i].Value = OVENC_CODIGO;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_RESTRICCION_PDV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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


		public bool InsertarPlanDetalle(string codigo, string tdoc,string plazo, string cuota, decimal valor)
		{//SP_SISACT_INS_RESTRICCION_PDV
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLNC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUON_INICIAL", DbType.Decimal,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( codigo != null  && codigo != "") arrParam[i].Value = codigo;
			++i; if( tdoc != null  && tdoc != "") arrParam[i].Value = tdoc;
			++i; if( plazo != null  && plazo != "") arrParam[i].Value = plazo;
			++i; if( cuota != null  && cuota != "") arrParam[i].Value = cuota;
			++i; if( valor > 0) arrParam[i].Value = valor;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_DETALLE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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


		public bool ModificarPlanTarifario(PlanTarifario oPlanTarifario, DataTable LlenarDataConsumoEstado,ArrayList ListaDetalle,ArrayList ListaPdv, string strUsuario,DataTable ListaDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANV_DESCRIPCION", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_SAP", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_BSCS", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANV_DES_BASE", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_ESTADO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_TIPO_DESPACHO", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_TIPO_FLUJO", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_EXCLUSIVO_CE", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_TIPO_PLAN", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_GPLNC_CODIGO", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANN_CAR_FIJ", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANN_LIM_CRED_CON", DbType.Decimal, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, ParameterDirection.Input),
									               new DAABRequest.Parameter("P_FLAG_RENOVACION", DbType.String, ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( oPlanTarifario.CodigoPlan != null  && oPlanTarifario.CodigoPlan != "") arrParam[i].Value = oPlanTarifario.CodigoPlan;
			++i; if( oPlanTarifario.IdOferta != null  && oPlanTarifario.IdOferta != "") arrParam[i].Value = oPlanTarifario.IdOferta;
			++i; if( oPlanTarifario.DescripcionPlan != null  && oPlanTarifario.DescripcionPlan != "") arrParam[i].Value = oPlanTarifario.DescripcionPlan;
			++i; if( oPlanTarifario.CodigoPlanSap != null  && oPlanTarifario.CodigoPlanSap != "") arrParam[i].Value = oPlanTarifario.CodigoPlanSap;
			++i; if( oPlanTarifario.CodigoPlanBscs != null  && oPlanTarifario.CodigoPlanBscs != "") arrParam[i].Value = oPlanTarifario.CodigoPlanBscs;
			++i; if( oPlanTarifario.DescripcionPlanBase != null  && oPlanTarifario.DescripcionPlanBase != "") arrParam[i].Value = oPlanTarifario.DescripcionPlanBase;
			++i; if( oPlanTarifario.IdEstado != null  && oPlanTarifario.IdEstado != "") arrParam[i].Value = oPlanTarifario.IdEstado;
			++i; if( oPlanTarifario.IdTipoDespacho != null  && oPlanTarifario.IdTipoDespacho != "") arrParam[i].Value = oPlanTarifario.IdTipoDespacho;
			++i; if( oPlanTarifario.IdTipoFlujo != null  && oPlanTarifario.IdTipoFlujo != "") arrParam[i].Value = oPlanTarifario.IdTipoFlujo;
			++i; if( oPlanTarifario.IdExclusivoCasoEspecial != null  && oPlanTarifario.IdExclusivoCasoEspecial != "") arrParam[i].Value = oPlanTarifario.IdExclusivoCasoEspecial;
			++i; if( oPlanTarifario.IdTipoPlan != null  && oPlanTarifario.IdTipoPlan != "")arrParam[i].Value = oPlanTarifario.IdTipoPlan;
			++i; if( oPlanTarifario.IdGrupoPlan != null  && oPlanTarifario.IdGrupoPlan != "") arrParam[i].Value = oPlanTarifario.IdGrupoPlan;			
			++i; if( oPlanTarifario.CargoFijo > 0) arrParam[i].Value = oPlanTarifario.CargoFijo;
			++i; if( oPlanTarifario.LimiteCredito > 0) arrParam[i].Value = oPlanTarifario.LimiteCredito;
			++i; if( strUsuario != null  && strUsuario != "")arrParam[i].Value = strUsuario;
			++i; if( oPlanTarifario.IdTipoProducto != null  && oPlanTarifario.IdTipoProducto != "")arrParam[i].Value = oPlanTarifario.IdTipoProducto;
			++i; if( oPlanTarifario.FlagRenovacion != null  && oPlanTarifario.FlagRenovacion != "")arrParam[i].Value = oPlanTarifario.FlagRenovacion;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_UPD_PLAN_TARIFARIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					EliminarDetalles(oPlanTarifario.CodigoPlan);
					EliminarPlanDocumento(oPlanTarifario.CodigoPlan);

					//AQUI LA LLAMADA A LOS METODOS PARA GRABAR LOS DETALLES
					foreach(DataRow oDataRow in LlenarDataConsumoEstado.Rows)
					{
						bool result=InsertarConsumoEstado(oPlanTarifario.CodigoPlan,Funciones.CheckStr(oDataRow[0]),Funciones.CheckStr(oDataRow[1]));				
					}

					foreach(PuntoVenta oPuntoVenta in ListaPdv)
					{
						bool result=InsertarRestriccionPdv(oPlanTarifario.CodigoPlan,Funciones.CheckStr(oPuntoVenta.TOFIC_CODIGO),Funciones.CheckStr(oPuntoVenta.OVENC_CODIGO));				
					}

					foreach(DetallePlanTarifario oDetallePlanTarifario in ListaDetalle)
					{
						bool result=InsertarPlanDetalle(oPlanTarifario.CodigoPlan,oDetallePlanTarifario.IdDocumento,oDetallePlanTarifario.IdPlazo,oDetallePlanTarifario.IdCuota,oDetallePlanTarifario.ValorCuota);				
					}

					foreach(DataRow oDataRow in ListaDocumento.Rows)
					{
						bool result=InsertarPlanDocumento(oPlanTarifario.CodigoPlan,Funciones.CheckStr(oDataRow[0]));				
					}

					salida = true;

				}
				else
					salida = false;
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

		
		public bool EliminarDetalles(string codigo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO_PLAN_SISACT", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( codigo != null  && codigo != "") arrParam[i].Value = codigo;

			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_PLAN_TARIF";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
		public bool EliminarPlanTarifario(string cod)
		{//SP_SISACT_DEL_PLAN_TARIFARIO
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO_PLAN_SISACT", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;

			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_PLAN_TARIFARIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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


		public PlanTarifario getPlan(string codigo)
		{
			PlanTarifario oPlanTarifario=null;

			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SEL_PLAN_TARIFARIO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
				if(oDataTable.Rows.Count>0)
				{
					foreach(DataRow dr  in oDataTable.Rows)
					{
						oPlanTarifario=new PlanTarifario();
						oPlanTarifario.CodigoPlan=Funciones.CheckStr(dr["PLANC_CODIGO"]);
						oPlanTarifario.IdOferta=Funciones.CheckStr(dr["TPROC_CODIGO"]);
						oPlanTarifario.DescripcionPlan=Funciones.CheckStr(dr["PLANV_DESCRIPCION"]);
						oPlanTarifario.CodigoPlanSap=Funciones.CheckStr(dr["CODIGO_SAP"]);
						oPlanTarifario.CodigoPlanBscs=Funciones.CheckStr(dr["CODIGO_BSCS"]);
						oPlanTarifario.DescripcionPlanBase=Funciones.CheckStr(dr["PLANV_DES_BASE"]);
						oPlanTarifario.IdEstado=Funciones.CheckStr(dr["PLANC_ESTADO"]);
						oPlanTarifario.IdTipoDespacho=Funciones.CheckStr(dr["PLNV_TIPO_DESPACHO"]);
						oPlanTarifario.IdTipoFlujo=Funciones.CheckStr(dr["PLNV_TIPO_FLUJO"]);
						oPlanTarifario.IdExclusivoCasoEspecial=Funciones.CheckStr(dr["PLNC_EXCLUSIVO_CE"]);
						oPlanTarifario.IdTipoPlan=Funciones.CheckStr(dr["PLNV_TIPO_PLAN"]);
						oPlanTarifario.IdGrupoPlan=Funciones.CheckStr(dr["GPLNC_CODIGO"]);
						oPlanTarifario.CargoFijo=Funciones.CheckDecimal(dr["PLANN_CAR_FIJ"]);
						oPlanTarifario.LimiteCredito=Funciones.CheckDecimal(dr["PLANN_LIM_CRED_CON"]);
						oPlanTarifario.IdTipoProducto=Funciones.CheckStr(dr["PRDC_CODIGO"]);
						oPlanTarifario.FlagRenovacion=Funciones.CheckStr(dr["FLAG_RENOVACION"]);
					}
				}
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oPlanTarifario;
		}


		public DataTable getDocumentos(string codigo)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_SEL_TIPO_DOCUMENTO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		
		public DataTable getPlazoAcuerdo(string codigo)
		{//SP_SISACT_SEL_PLAZO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_SEL_PLAZO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		
		public DataTable getConsumoEstado(string codigo)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_SEL_TOPE";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}
		
		
		public DataTable getConsumoCuotas(string codigo)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_SEL_CUOTAS";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}
		
		
		public DataTable getRestriccionPdv(string codigo)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_SEL_RESTRICCION_PDV";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}
		
		
		public ArrayList ListarPdvRestriccion(string codPlan)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codPlan;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_RES_PDV";
			oDAABRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			PuntoVenta oPuntoVenta;
			IDataReader dr = null;
			try
			{
				dr = oDAABRequest.Factory.ExecuteReader(ref oDAABRequest).ReturnDataReader;				
				while(dr.Read())
				{
					//Plan item = new Plan();
					oPuntoVenta=new PuntoVenta();
					oPuntoVenta.OVENC_CODIGO= Funciones.CheckStr(dr["OVENC_CODIGO"]);
					oPuntoVenta.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					oPuntoVenta.CANAC_CODIGO = Funciones.CheckStr(dr["CANAC_CODIGO"]);
					filas.Add(oPuntoVenta);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListarDetalle(string codPlan)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),//default DB Claro
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = codPlan;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_DETALLE";
			oDAABRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			DetallePlanTarifario oDetallePlanTarifario;
			//PuntoVenta oPuntoVenta;
			IDataReader dr = null;
			try
			{
				dr = oDAABRequest.Factory.ExecuteReader(ref oDAABRequest).ReturnDataReader;				
				while(dr.Read())
				{
					//Plan item = new Plan();
					oDetallePlanTarifario=new DetallePlanTarifario();
					oDetallePlanTarifario.IdDocumento=Funciones.CheckStr(dr["DOCC_CODIGO"]);
					oDetallePlanTarifario.DescripcionDocumento=Funciones.CheckStr(dr["DESCRIPCION"]);
					oDetallePlanTarifario.IdPlazo=Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					oDetallePlanTarifario.DescripcionPlazo=Funciones.CheckStr(dr["PACUV_DESCRIPCION"]);
					oDetallePlanTarifario.IdCuota=Funciones.CheckStr(dr["CUOC_CODIGO"]);
					oDetallePlanTarifario.DescripcionCuota=Funciones.CheckStr(dr["DES_CUOTA"]);
					oDetallePlanTarifario.ValorCuota=Funciones.CheckDecimal(dr["CUON_INICIAL"]);

					filas.Add(oDetallePlanTarifario);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return filas;
		}

		
//		public ArrayList ConsultarPlanTarifario(string codPlan, string descripcion)
//		{
//			DAABRequest.Parameter[] arrParam = {
//												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
//												   new DAABRequest.Parameter("P_COD_PLAN", DbType.String, 5, ParameterDirection.Input),
//												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 40, ParameterDirection.Input)
//											   }; 		
//
//			int i=0;
//			for ( i=0; i<arrParam.Length;i++)
//				arrParam[i].Value = DBNull.Value;
//
//			i=1; if( codPlan!= null && codPlan != "") arrParam[i].Value = codPlan;
//			++i; if( descripcion != null  && descripcion != "") arrParam[i].Value = descripcion;
//		
//			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
//			DAABRequest obRequest = obj.CreaRequest(); 
//			obRequest.CommandType = CommandType.StoredProcedure; 			
//			obRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SISACT_CON_PLAN_TARIFARIO";
//			obRequest.Parameters.AddRange(arrParam);
//			
//			ArrayList filas = new ArrayList();
//			IDataReader dr = null;
//			try
//			{
//				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
//				while(dr.Read())
//				{
//					Plan item = new Plan();
//					item.PLANC_CODIGO = Funciones.CheckStr(dr["PLANC_CODIGO"]);//CODIGO
//					item.PLANV_DESCRIPCION= Funciones.CheckStr(dr["PLANV_DESCRIPCION"]);//DESCRIPCION
//					item.PLANV_DES_BASE = Funciones.CheckStr(dr["TOFV_DESCRIPCION"]);//OFERTA
//					item.PLANC_TIPOMP = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);//TIPO PRODUCTO
//					item.PLANN_CAR_FIJ = Funciones.CheckDecimal(dr["PLANN_CAR_FIJ"]);//CARGO FIJO
//					item.PLANN_LIM_CRED_CON = Funciones.CheckDecimal(dr["PLANN_LIM_CRED_CON"]);//LIMITE CREDITO
//					item.PLANC_ESTADO = Funciones.CheckStr(dr["PLANC_ESTADO"]);//ESTADO
//
////					item.PLANV_DESCRIPCION = Funciones.CheckStr(dr["PLANV_DESCRIPCION"]);
////					item.PLANN_CAR_FIJ = Funciones.CheckDecimal(dr["PLANN_CAR_FIJ"]);
////					item.ESTADO_DESCRIPCION = Funciones.CheckStr(dr["ESTADO_DES"]);
////					item.PLANC_ESTADO = Funciones.CheckStr(dr["PLANC_ESTADO"]);
////					item.CODIGO_SAP = Funciones.CheckStr(dr["CODIGO_SAP"]);
////					item.CODIGO_BSCS = Funciones.CheckStr(dr["CODIGO_BSCS"]);
////					item.PLANV_DES_BASE = Funciones.CheckStr(dr["PLANV_DES_BASE"]);
////					item.PLANN_LIM_CRED_CON = Funciones.CheckDecimal(dr["PLANN_LIM_CRED_CON"]);
//					filas.Add(item);
//				}
//			}
//			catch(Exception e)
//			{				
//				throw e;
//			}
//			finally
//			{
//				if (dr != null && dr.IsClosed==false ) dr.Close();
//				obRequest.Parameters.Clear();
//				obRequest.Factory.Dispose();
//			}
//			return filas;
//		}

		public DataTable ConsultarPlanTarifario(string codPlan, string descripcion)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COD_PLAN", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 40, ParameterDirection.Input)
											   }; 		

			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( codPlan!= null && codPlan != "") arrParam[i].Value = codPlan;
			++i; if( descripcion != null  && descripcion != "") arrParam[i].Value = descripcion;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SISACT_CON_PLAN_TARIFARIO";
			objRequest.Parameters.AddRange(arrParam);
			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ConsultarPlanTarifarioExportar(string codPlan, string descripcion)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COD_PLAN", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 40, ParameterDirection.Input)
											   }; 		

			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( codPlan!= null && codPlan != "") arrParam[i].Value = codPlan;
			++i; if( descripcion != null  && descripcion != "") arrParam[i].Value = descripcion;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SISACT_CON_PLAN_TARIFARIO_EX";
			objRequest.Parameters.AddRange(arrParam);
			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}
		
//		public DataTable fdtbListarTopConsumo()
//		{			
//			DataTable dtResultado = new DataTable();
//			DAABRequest.Parameter[] arrParam = {
//												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
//											   }; 
//			arrParam[0].Value = DBNull.Value;
//			
//			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
//			DAABRequest objRequest = obj.CreaRequest();
//			objRequest.CommandType = CommandType.StoredProcedure;
//			objRequest.Command = BaseDatos.PKG_SISACT_CONSULTA_GENERAL + ".MANTSS_LISTAR_TOPCSM";
//			objRequest.Parameters.AddRange(arrParam);
//
//			try
//			{
//				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
//			}
//			catch( Exception ex )
//			{
//				throw ex;
//			}
//			finally
//			{			
//				objRequest.Factory.Dispose();
//			}
//			return dtResultado;
//		}

		
		public DataTable ListarRiesgo( string tipo)
		{//SP_SISACT_LISTA_RIESGO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			int j=0;
			arrParam[j].Value = tipo;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_TIPO_RIESGO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		
		public DataTable ListarPLan()
		{//SP_LISTAR_PLAN
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_LISTAR_PLAN";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

	
		public DataTable ListarRestriccionRiesgo( string TipDoc, string Riesgo, string Plazo, string Plan)
		{//SP_SISACT_LISTAR_RES_RIESGO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 0;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;
			j++;arrParam[j].Value = Plazo;
			j++;arrParam[j].Value = Plan;

			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_RES_RIESGO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public DataTable ListarRestriccionRiesgoExportar( string TipDoc, string Riesgo, string Plazo, string Plan)
		{//SP_SISACT_LISTAR_RES_RIESGO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 0;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;
			j++;arrParam[j].Value = Plazo;
			j++;arrParam[j].Value = Plan;

			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_RES_RIESGO_EX";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}
		
		public bool InsertarRestriccionRiesgo(string oTipoDocumento,string oRiesgo,DataTable oPlazo,DataTable oPLan,DataTable oListaCampanas,string sUsuario)
		{//verificar la validación que se tiene que tener como  minimo un registro por cada coleccion
			bool Resultado=false;
			string sRiesgo =string.Empty;
			string sTipoDocumento =string.Empty;
			string sPlazo =string.Empty;
			string sPLan =string.Empty;
			string sCampanaCodigo =string.Empty;
			string sCampanaDescripcion =string.Empty;
		
					foreach(DataRow rowPlazo in oPlazo.Rows)
					{
						sPlazo=rowPlazo[0].ToString();
						foreach(DataRow rowPLan in oPLan.Rows)
						{
							sPLan=rowPLan[0].ToString();
							foreach(DataRow rowCampana  in oListaCampanas.Rows)
							{
								Resultado=RegistroInsertRiesgo(oTipoDocumento,oRiesgo,sPlazo,sPLan,rowCampana[0].ToString(),rowCampana[1].ToString(),sUsuario);
								if (Resultado==false){return false;}
							}
						}
					}
			return Resultado;
		}

		
		public bool RegistroInsertRiesgo(string sTipoDocumento,
										string sRiesgo,
										string sPlazo,
										string sPLan,
										string sCampanaCodigo,
										string sCampanaDescripcion,
										string sUsuario)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_CODIGO", DbType.String,  ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_CMPV_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CMPV_DESCRIPCION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( sTipoDocumento != null  && sTipoDocumento != "") arrParam[i].Value = sTipoDocumento;
			++i; if( sRiesgo != null  && sRiesgo != "") arrParam[i].Value = sRiesgo;
			++i; if( sPlazo != null  && sPlazo != "") arrParam[i].Value = sPlazo;
			++i; if( sPLan != null  && sPLan != "") arrParam[i].Value = sPLan;
			++i; if( sCampanaCodigo != null  && sCampanaCodigo != "") arrParam[i].Value = sCampanaCodigo;
			++i; if( sCampanaDescripcion != null  && sCampanaDescripcion != "") arrParam[i].Value = sCampanaDescripcion;
			++i; if( sUsuario != null  && sUsuario != "") arrParam[i].Value = sUsuario;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_REST_RIESGO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
		public DataTable getRestriccionRiesgo( string TipDoc, string Riesgo, string Plazo, string Plan,string Campana)
		{//SP_SISACT_LISTAR_RES_RIESGO
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 0;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;
			j++;arrParam[j].Value = Plazo;
			j++;arrParam[j].Value = Plan;
			j++;arrParam[j].Value = Campana;

			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_RIESGO_EDIT";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}
	
		
		public bool EliminarRestriccionRiesgo( string TipDoc, string Riesgo, string Plazo, string Plan,string Campana)
		{//ELIMINAR EliminarRestriccionRiesgo
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, ParameterDirection.Input)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 1;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;
			j++;arrParam[j].Value = Plazo;
			j++;arrParam[j].Value = Plan;
			j++;arrParam[j].Value = Campana;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_REST_RIESGO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
		public bool ActualizarRestriccionRiesgo(DataTable oRiesgo,DataTable oTipoDocumento,DataTable oPlazo,DataTable oPLan,DataTable oListaCampanas,string sUsuario)
		{//verificar la validación que se tiene que tener como  minimo un registro por cada coleccion
			bool Resultado=false;
			string sRiesgo =string.Empty;
			string sTipoDocumento =string.Empty;
			string sPlazo =string.Empty;
			string sPLan =string.Empty;
			string sCampanaCodigo =string.Empty;
			string sCampanaDescripcion =string.Empty;

			foreach(DataRow rowRiesgo in oRiesgo.Rows)
			{
				sRiesgo=rowRiesgo[0].ToString();
				foreach(DataRow rowTipoDocumento in oTipoDocumento.Rows)
				{
					sTipoDocumento=rowTipoDocumento[0].ToString();
					foreach(DataRow rowPlazo in oPlazo.Rows)
					{
						sPlazo=rowPlazo[0].ToString();
						foreach(DataRow rowPLan in oPLan.Rows)
						{
							sPLan=rowPLan[0].ToString();
							foreach(DataRow rowCampana  in oListaCampanas.Rows)
							{
//								if (EliminarUpdateRestriccionRiesgo(  TipDoc,  Riesgo,  Plazo,  Plan, Campana) ==true)
//								{
//								}
								Resultado=RegistroInsertRiesgo(sRiesgo,sTipoDocumento,sPlazo,sPLan,rowCampana[0].ToString(),rowCampana[1].ToString(),sUsuario);
								if (Resultado==false){return false;}
							}
						}
					}
				}
			}
			return Resultado;
		}

		
		public bool EliminarUpdateRestriccionRiesgo( string TipDoc, string Riesgo, string Plazo, string Plan,string Campana)
		{//SP_SISACT_DEL_PLAN_TARIFARIO
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, ParameterDirection.Input)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 1;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;
			j++;arrParam[j].Value = Plazo;
			j++;arrParam[j].Value = Plan;
			j++;arrParam[j].Value = Campana;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_UPD_RIESGO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{			
					salida = true;
				}
				else
					salida = false;
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

		
//		public bool InsertarRestriccionCuota(DataTable ListaRiesgo,DataTable ListaTipoDocumento,DataTable ListaCuotas, string strUsuario)
//		{
//			bool Resultado=false;
//			string sRiesgo =string.Empty;
//			string sTipoDocumento =string.Empty;
//			string sCuota =string.Empty;
//
//				foreach(DataRow rowRiesgo in ListaRiesgo.Rows)
//				{
//					sRiesgo=rowRiesgo[0].ToString();
//					foreach(DataRow rowTipoDocumento in ListaTipoDocumento.Rows)
//					{
//						sTipoDocumento=rowTipoDocumento[0].ToString();
//						foreach(DataRow rowCuota in ListaCuotas.Rows)
//						{
//								Resultado=InsertarRestriccionCuotaDetalle(sRiesgo,sTipoDocumento,rowCuota[0].ToString(),Convert.ToDecimal( rowCuota[1].ToString()),strUsuario);
//								if (Resultado==false){return false;}
//						}
//					}
//				}
//
//			return Resultado;
//		}

		public bool InsertarRestriccionCuota(string Riesgo,string TipDoc,string Cuota,decimal CuotaIni, string strUsuario)
		{//SP_SISACT_INS_REST_CUOTA			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUON_INICIA", DbType.Decimal,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( Riesgo != null  && Riesgo != "") arrParam[i].Value = Riesgo;
			++i; if( TipDoc != null  && TipDoc != "") arrParam[i].Value = TipDoc;
			++i; if( Cuota != null  && Cuota != "") arrParam[i].Value = Cuota;
			++i; if( CuotaIni >= 0) arrParam[i].Value = CuotaIni;
			++i; if( strUsuario != null  && strUsuario != "")arrParam[i].Value = strUsuario;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_RES_CUOTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		
		public DataTable ListarRestriccionCuota(string sTipoDocumento,string sRiesgo, string sCuota)
		{//SP_SISACT_LISTAR_RES_CUOTA
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;if( sTipoDocumento != null  && sTipoDocumento != "") arrParam[j].Value = sTipoDocumento;
			j++;if( sRiesgo != null  && sRiesgo != "") arrParam[j].Value = sRiesgo;
			j++;if( sCuota != null  && sCuota != "") arrParam[j].Value = sCuota;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_RES_CUOTA";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public DataTable ListarRestriccionCuotaExportar(string sTipoDocumento,string sRiesgo, string sCuota)
		{//SP_SISACT_LISTAR_RES_CUOTA
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;if( sTipoDocumento != null  && sTipoDocumento != "") arrParam[j].Value = sTipoDocumento;
			j++;if( sRiesgo != null  && sRiesgo != "") arrParam[j].Value = sRiesgo;
			j++;if( sCuota != null  && sCuota != "") arrParam[j].Value = sCuota;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_RES_CUOTA_EX";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public int InsertarGrupo(string Descripcion,string strUsuario)
		{//SP_SISACT_INS_REST_CUOTA			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,  ParameterDirection.Input)
											};
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( Descripcion != null  && Descripcion != "") arrParam[i].Value = Descripcion;
			++i; if( strUsuario != null  && strUsuario != "")arrParam[i].Value = strUsuario;

			int salida = -1;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_GRUPO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckInt(pSalida.Value) >=0)
				{
					salida = Funciones.CheckInt(pSalida.Value);
				}
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

		
		public bool validarRestriccionCuota(string riesgo,string doc,string cuota)
		{//SP_SISACT_INS_REST_CUOTA			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input)
			};
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( riesgo != null  && riesgo != "") arrParam[i].Value = riesgo;
			++i; if( doc != null  && doc != "")arrParam[i].Value = doc;
			++i; if( cuota != null  && cuota != "")arrParam[i].Value = cuota;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_VALIDAR_RES_CUOTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		
		public bool EliminarRestriccionCuota(string riesgo,string doc,string cuota)
		{//SP_SISACT_DEL_RES_CUOTA //ELIMINAR			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( riesgo != null  && riesgo != "") arrParam[i].Value = riesgo;
			++i; if( doc != null  && doc != "")arrParam[i].Value = doc;
			++i; if( cuota != null  && cuota != "")arrParam[i].Value = cuota;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_RES_CUOTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

	
		public bool ModificarRestriccionCuota(DetallePlanTarifario oDetallePlanTarifario,string estado)
		{//SP_SISACT_UPD_RES_CUOTA			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VALOR", DbType.Decimal,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( oDetallePlanTarifario.IdPlazo != null  && oDetallePlanTarifario.IdPlazo != "") arrParam[i].Value = oDetallePlanTarifario.IdPlazo;
			++i; if( oDetallePlanTarifario.IdDocumento != null  && oDetallePlanTarifario.IdDocumento != "")arrParam[i].Value = oDetallePlanTarifario.IdDocumento;
			++i; if( oDetallePlanTarifario.IdCuota != null  && oDetallePlanTarifario.IdCuota != "")arrParam[i].Value = oDetallePlanTarifario.IdCuota;
			++i; if( oDetallePlanTarifario.ValorCuota>0)arrParam[i].Value = oDetallePlanTarifario.ValorCuota;
			++i; if( estado != null  && estado != "")arrParam[i].Value = estado;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_UPD_RES_CUOTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		
		public DetallePlanTarifario getRestriccionCuota(string riesgo,string doc,string cuota)
		{//			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( riesgo != null  && riesgo != "") arrParam[i].Value = riesgo;
			++i; if( doc != null  && doc != "")arrParam[i].Value = doc;
			++i; if( cuota != null  && cuota != "")arrParam[i].Value = cuota;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_GET_RES_CUOTA";
			oDAABRequest.Parameters.AddRange(arrParam);
			
			//ArrayList filas = new ArrayList();
			DetallePlanTarifario oDetallePlanTarifario=null;
			IDataReader dr = null;
			try
			{
				dr = oDAABRequest.Factory.ExecuteReader(ref oDAABRequest).ReturnDataReader;				
				if(dr.Read())
				{
					//Plan item = new Plan();
					oDetallePlanTarifario=new DetallePlanTarifario();
					oDetallePlanTarifario.IdPlazo= Funciones.CheckStr(dr[0]);
					oDetallePlanTarifario.IdDocumento = Funciones.CheckStr(dr[1]);
					oDetallePlanTarifario.IdCuota = Funciones.CheckStr(dr[2]);
					oDetallePlanTarifario.ValorCuota = Funciones.CheckDecimal(dr[3]);
					oDetallePlanTarifario.IdEstado = Funciones.CheckStr(dr[4]);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return oDetallePlanTarifario;
		}

		public DataTable getDetallesRestriccionRiesgo( string TipDoc, string Riesgo,int tipo)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input)										   												   
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 1;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;


			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			switch (tipo)
			{
				case 1:
					oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LLENAR_PLAZOS";
					break;
				case 2:
					oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LLENAR_CAMPANAS";
					break;
				case 3:
					oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LLENAR_PLANES";
					break;
			}
			
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public bool DelDetallesRestriccionRiesgo( string TipDoc, string Riesgo)
		{
			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input)										   												   
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 1;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;


			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_DET_RIESGO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
			}
			finally
			{			
				obRequest.Factory.Dispose();
			}
			return salida;
		}
		public bool validarDetallesRestriccionRiesgo( string TipDoc, string Riesgo)
		{
			DataTable oDataTable = new DataTable();

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input)										   												   
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			int j = 1;
			arrParam[j].Value = TipDoc;
			j++;arrParam[j].Value = Riesgo;


			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_VALIDAR_RIESGO";
		
			oDAABRequest.Parameters.AddRange(arrParam);
			bool resultado=true;
			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
				if(oDataTable.Rows.Count>0)
				{resultado=false;}
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return resultado;
		}//

		public DataTable ListarFactorPorRiesgo(string sTipoDocumento,string sRiesgo, int tipo)
		{//SP_SISACT_LISTAR_RES_CUOTA
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;if( sTipoDocumento != null  && sTipoDocumento != "") arrParam[j].Value = sTipoDocumento;
			j++;if( sRiesgo != null  && sRiesgo != "") arrParam[j].Value = sRiesgo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			if (tipo==1)
				oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_FACTOR_RIE";
				else
				oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO +  ".SP_SISACT_LISTAR_FACTOR_RIE_EX";

			
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public bool InsertarFactorRiesgo(string Riesgo,string TipDoc,string Essalud,decimal Factor, string strUsuario)
		{//SP_SISACT_INS_REST_CUOTA			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEMN_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUON_INICIA", DbType.Decimal,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( Riesgo != null  && Riesgo != "") arrParam[i].Value = Riesgo;
			++i; if( TipDoc != null  && TipDoc != "") arrParam[i].Value = TipDoc;
			++i; if( Essalud != null  && Essalud != "") arrParam[i].Value = Essalud;
			++i; if( Factor >= 0) arrParam[i].Value = Factor;
			++i; if( strUsuario != null  && strUsuario != "")arrParam[i].Value = strUsuario;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_FACT_RIE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		public bool ModificarFactorRiesgo(string Riesgo,string TipDoc,string Essalud,decimal Factor, string strEstado)
		{//SP_SISACT_INS_REST_CUOTA			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEMN_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUON_INICIA", DbType.Decimal,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//decimal cuotaDec=
			i=1; if( Riesgo != null  && Riesgo != "") arrParam[i].Value = Riesgo;
			++i; if( TipDoc != null  && TipDoc != "") arrParam[i].Value = TipDoc;
			++i; if( Essalud != null  && Essalud != "") arrParam[i].Value = Essalud;
			++i; if( Factor >= 0) arrParam[i].Value = Factor;
			++i; if( strEstado != null  && strEstado != "")arrParam[i].Value = strEstado;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_UPD_FACT_RIE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		public bool EliminarFactorRiesgo(string Riesgo,string TipDoc,string Essalud)
		{//SP_SISACT_INS_REST_CUOTA			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEMN_CODIGO", DbType.String, ParameterDirection.Input),
												};
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Riesgo != null  && Riesgo != "") arrParam[i].Value = Riesgo;
			++i; if( TipDoc != null  && TipDoc != "") arrParam[i].Value = TipDoc;
			++i; if( Essalud != null  ) arrParam[i].Value = Essalud;
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_FACT_RIE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		public DataTable getFactorRiesgo(string Riesgo,string TipDoc,string Essalud)
		{

			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEMN_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j=0; if( Riesgo != null  && Riesgo != "") arrParam[j].Value = Riesgo;
			j++; if( TipDoc != null  && TipDoc != "") arrParam[j].Value = TipDoc;
			j++; if( Essalud != null  ) arrParam[j].Value = Essalud;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_GET_FACT_RIE";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];				
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public bool EliminarPlanDocumento(string sCod)
		{//SP_SISACT_DEL_PLAN_DOC			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String,  ParameterDirection.Input),
			};
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( sCod != null  && sCod != "") arrParam[i].Value = sCod;
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_DEL_PLAN_DOC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		public bool InsertarPlanDocumento(string sCod,string sDoc)
		{//SP_SISACT_INS_PLAN_DOC			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
			};
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( sCod != null  && sCod != "") arrParam[i].Value = sCod;
			i++; if( sDoc != null  && sDoc != "") arrParam[i].Value = sDoc;
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_INS_PLAN_DOC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
				{
					salida = true;
				}
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

		public DataTable getPlanDocumento(string sCod)
		{

			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j=0; if( sCod != null  && sCod != "") arrParam[j].Value = sCod;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".SP_SISACT_GET_PLAN_DOC";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];				
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

	}

}
