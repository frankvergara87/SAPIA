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
	/// Summary description for DValidacionLinea.
	/// </summary>
	public class DValidacionLinea
	{
		public DValidacionLinea()
		{
			//
			// TODO: Add constructor logic here 
			//
		}

		# region "Consultas"
			
		public DataTable fdtbListarBusqueda()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_LISTAR_MNTO_LINEADESAC";
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

		# endregion

		# region "Transacciones"

		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrMotivo, string pstrRecomendacion, string pstrEstado, string pstrMesesDesac, string pstrMesesActiva, string pstrUsuario, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MOTIVO", DbType.String, 500, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECOMENDACION", DbType.String, 500, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MESESDESAC", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MESESACTIV", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 20, ParameterDirection.Input)
			};

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrMotivo;
			arrParam[4].Value = pstrRecomendacion;
			arrParam[5].Value = pstrEstado;
			arrParam[6].Value = pstrMesesDesac;
			if (pstrMesesActiva.Length > 0)
				arrParam[7].Value = pstrMesesActiva;
			arrParam[8].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_MODIFI_LINEADESAC";
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
				rMsg = "Error al Modificar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool fbooDesactivar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
													new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
													new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input),
													new DAABRequest.Parameter("P_USUARIO", DbType.String, 20, ParameterDirection.Input)
												};
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrUsuario;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_DESACT_LINEADESAC";
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
				rMsg = "Error al Eliminar. \nMensaje : " + ex.Message;
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
		
		# endregion

	}
}
