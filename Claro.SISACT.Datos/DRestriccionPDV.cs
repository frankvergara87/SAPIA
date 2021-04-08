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
	/// Summary description for MantenimeintoMaestro.
	/// </summary>
	public class DRestriccionPDV
	{
		public DRestriccionPDV()
		{
			//
			// TODO: Add constructor logic here 
			//
		}

		# region "Consultas"
			
		public DataTable fdtbListarTipoOficina()
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".MANTSS_LISTAR_TIPO_OFIC";
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

		public DataTable fdtbListarPDVTotal(string pstrCanales, string pstrCodigo, string pstrDescripcion)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CANALES", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 40, ParameterDirection.Input)													
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCanales;
			arrParam[2].Value = pstrCodigo;
			arrParam[3].Value = pstrDescripcion;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".MANTSS_LISTAR_PDV_TOTAL";
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

		public DataTable fdtbListarPDV(string pstrPlanCodigo, string pstrPDVs)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PDVs", DbType.String, 32767, ParameterDirection.Input)
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = DBNull.Value;
			arrParam[2].Value = DBNull.Value;

			arrParam[1].Value = pstrPlanCodigo;
			if (pstrPDVs.Length > 0)
				arrParam[2].Value = pstrPDVs;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".MANTSS_LISTAR_PDV";
			objRequest.Parameters.AddRange(arrParam);
			ArrayList lst = new ArrayList();
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

		# endregion

		# region "Transacciones"

		public void pInsertar(string pstrPlanCodigo, string pstrPDVs, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PDVs", DbType.String, 32767, ParameterDirection.Input)
											   };
			arrParam[0].Value = pstrPlanCodigo;
			arrParam[1].Value = DBNull.Value;
			if (pstrPDVs.Length > 0)
				arrParam[1].Value = pstrPDVs;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".MANTSI_INSERT_RESTPLA";
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
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
		}

		# endregion

	}
}
