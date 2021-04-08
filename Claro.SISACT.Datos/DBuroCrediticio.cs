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
	/// Descripción breve de DWhitelistAsesor.
	/// </summary>
	public class DBuroCrediticio
	{
		public DBuroCrediticio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		# region "Consultas"

		public DataTable ListarBusqueda(string strTipo, string strDescripcion, string strDocumento, string strEstado)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input)
											   };
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = strTipo;
			arrParam[2].Value = strDescripcion;
			arrParam[3].Value = strDocumento;
			arrParam[4].Value = strEstado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_CON_BURO_CREDITICIO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListarConfigBuro(string strDocumento)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, 2, ParameterDirection.Input),
												new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output)};
			arrParam[0].Value = strDocumento;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_CON_CONF_BURO_CREDITICIO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ConsultarDatos(string strCodigo)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 15, ParameterDirection.Input)
											   };
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = strCodigo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_CON_DATOS_BURO_CREDITICIO";
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

		public void ModificarEstado(string strBuros, string strEstado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_BUROS", DbType.String, 32767, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 2, ParameterDirection.Input)
											   };
			arrParam[0].Value = strBuros;
			arrParam[1].Value = strEstado;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_UPD_ESTADO_BURO_CREDITICIO";
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
				obRequest.Factory.Dispose();
			}
		}

		public void ModificarDatos(string strCodigo, string strNombre, string strDescripcion, string strDocumento, 
									string strEstado, string strUsuario)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = strCodigo;
			arrParam[1].Value = strNombre;
			arrParam[2].Value = strDescripcion;
			arrParam[3].Value = strDocumento;
			arrParam[4].Value = strEstado;
			arrParam[5].Value = strUsuario;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_UPD_BURO_CREDITICIO";
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
				obRequest.Factory.Dispose();
			}
		}

		public void ModificarConfigBuro(string strConfBuro, string strDocumento, string strUsuario)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONF_BURO", DbType.String, 32767, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };
			arrParam[0].Value = strConfBuro;
			arrParam[1].Value = strDocumento;
			arrParam[2].Value = strUsuario;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_BURO_CREDITICIO + ".SP_UPD_CONF_BURO_CREDITICIO";
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
				obRequest.Factory.Dispose();
			}
		}
		# endregion
	}
}
