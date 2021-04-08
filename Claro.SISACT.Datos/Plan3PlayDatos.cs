using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for Plan3PlayDatos.
	/// </summary>
	public class Plan3PlayDatos
	{
		public Plan3PlayDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
		public bool InsertarPlan3Play(Plan3Play oPlan3Play, ref string sCodigoPlan, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLNV_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_CODIGO_BSCS", DbType.String, 4, ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = oPlan3Play.PLNV_DESCRIPCION;
			i++; arrParam[i].Value = oPlan3Play.PLNC_ESTADO;
			i++; arrParam[i].Value = oPlan3Play.TPROC_CODIGO;
			i++; arrParam[i].Value = oPlan3Play.PLNV_USUARIO_CREA;
			i++; arrParam[i].Value = oPlan3Play.PLNV_CODIGO_BSCS;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_INS_PLAN_3PLAY";
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
				rMsg = "Error al Insertar Plan 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sCodigoPlan = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public bool ActualizarPlan3Play(Plan3Play oPlan3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_CODIGO_BSCS", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oPlan3Play.PLNV_CODIGO;
			arrParam[1].Value = oPlan3Play.PLNV_DESCRIPCION;
			arrParam[2].Value = oPlan3Play.PLNC_ESTADO;
			arrParam[3].Value = oPlan3Play.TPROC_CODIGO;
			arrParam[4].Value = oPlan3Play.PLNV_USUARIO_CREA;
			arrParam[5].Value = oPlan3Play.PLNV_CODIGO_BSCS;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_UPD_PLAN_3PLAY";
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
				string rMsg = "Error al Modificar en Plan 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public bool EliminarPlan3Play(Plan3Play oPlan3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oPlan3Play.PLNV_CODIGO;
			arrParam[1].Value = oPlan3Play.PLNV_USUARIO_CREA;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_DEL_PLAN_3PLAY";
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
				string rMsg = "Error al Eliminar en Plan 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public ArrayList ListarPlan3Play(string P_PLNV_CODIGO,string P_PLNV_DESCRIPCION, string P_PLNC_ESTADO)
		{
			Plan3Play oPlan3Play = null;
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_DESCRIPCION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = P_PLNV_CODIGO;
			arrParam[1].Value = P_PLNV_DESCRIPCION;
			arrParam[2].Value = P_PLNC_ESTADO;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_PLAN_3PLAY";
			oDAABRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = oDAABRequest.Factory.ExecuteReader(ref oDAABRequest).ReturnDataReader;		
				while(dr.Read())
				{
					oPlan3Play = new Plan3Play();
					oPlan3Play.PLNV_CODIGO=Funciones.CheckStr(dr["PLNV_CODIGO"]);
					oPlan3Play.PLNV_DESCRIPCION=Funciones.CheckStr(dr["PLNV_DESCRIPCION"]);
					oPlan3Play.PLNC_ESTADO=Funciones.CheckStr(dr["PLNC_ESTADO"]);
					oPlan3Play.ESTADO_PLAN=Funciones.CheckStr(dr["ESTADO_PLAN"]);
					oPlan3Play.TVENC_CODIGO=Funciones.CheckStr(dr["TVENC_CODIGO"]);
					oPlan3Play.TVENV_DESCRIPCION=Funciones.CheckStr(dr["TVENV_DESCRIPCION"]);
					oPlan3Play.TPROC_CODIGO=Funciones.CheckStr(dr["TPROC_CODIGO"]);
					oPlan3Play.TPROV_DESCRIPCION=Funciones.CheckStr(dr["TPROV_DESCRIPCION"]);
					oPlan3Play.PLNN_CARGO_FIJO=Funciones.CheckDecimal(dr["PLNN_CARGO_FIJO"]);						
					oPlan3Play.PLNC_TIPO_PRODUCTO=Funciones.CheckStr(dr["PLNC_TIPO_PRODUCTO"]);
					oPlan3Play.PRDV_DESCRIPCION=Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
					filas.Add(oPlan3Play);
				}
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				if (dr != null && dr.IsClosed==false ) dr.Close();
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return filas;
		}


		public DataTable ListarPlan3PlayTabla(string P_PLNV_CODIGO, string P_PLNV_DESCRIPCION, string P_PLNC_ESTADO)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_DESCRIPCION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = P_PLNV_CODIGO;
			arrParam[1].Value = P_PLNV_DESCRIPCION;
			arrParam[2].Value = P_PLNC_ESTADO;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_PLAN_3PLAY";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return dtResultado;
		}

                //ldrz
		public DataTable ListarPlanPaquete3Play(string P_PRDC,string P_PLNV_CODIGO)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = P_PRDC;
			arrParam[1].Value = P_PLNV_CODIGO;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_PLAN_PAQUETE_3PLAY";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public bool MantenimientoPlan3Play(string strAccion, Plan3Play oPlan)
		{			
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
				new DAABRequest.Parameter("P_ACCION", DbType.String, 2, ParameterDirection.Input),
				new DAABRequest.Parameter("P_PARAM_GENERALES", DbType.String, 4000, ParameterDirection.Input),
				new DAABRequest.Parameter("P_PLAZOS", DbType.String, 4000, ParameterDirection.Input),
				new DAABRequest.Parameter("P_SERVICIOS", DbType.String, 4000, ParameterDirection.Input),
				new DAABRequest.Parameter("P_ALQUILER", DbType.String, 4000, ParameterDirection.Input),
				new DAABRequest.Parameter("P_PLNV_USUARIO_CREA", DbType.String, 4000, ParameterDirection.Input)
			};
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = strAccion;
			i++; arrParam[i].Value = oPlan.PARAM_GENERALES;
			i++; arrParam[i].Value = oPlan.PLAZOS;
			i++; arrParam[i].Value = oPlan.SERVICIOS;
			i++; arrParam[i].Value = oPlan.ALQUILER;
			i++; arrParam[i].Value = oPlan.PLNV_USUARIO_CREA;

			bool blnOK = false;
			int resultado;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_MAN_PLAN";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parSalida1 = (IDataParameter)obRequest.Parameters[0];
				resultado = Funciones.CheckInt(parSalida1.Value);

				if (resultado == 1) blnOK = true;
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
			return blnOK;
		}

	}
}
