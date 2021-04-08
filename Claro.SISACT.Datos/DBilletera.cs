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
	/// Descripción breve de DBilletera.
	/// </summary>
	public class DBilletera
	{
		public DBilletera()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

        # region "Consultas"

        public DataTable ListarBilleterasActivas()
        {
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_DATOS", DbType.Object, ParameterDirection.Output)
                                                };
            arrParam[0].Value = DBNull.Value;
            
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_PORCEN_FACT + ".SP_GET_BILLETERAS_ACTIVAS";
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


        public DataTable ListarBilleterasLista(string P_BILLETERAS, string P_ESTADO)
        {
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_DATOS", DbType.Object, ParameterDirection.Output)
                                                   ,new DAABRequest.Parameter("P_BILLETERAS", DbType.String, 20, ParameterDirection.Input)
                                                   ,new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input)
                                               };
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = P_BILLETERAS;
            arrParam[2].Value = P_ESTADO;
            
            
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_PORCEN_FACT + ".SP_GET_BILLETERAS_LIST";
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


        public DataTable ObtenerBilleteras(int P_CODIGO)
        {
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_DATOS", DbType.Object, ParameterDirection.Output)
                                                   ,new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input)
                                               };
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = P_CODIGO;
            
            
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_PORCEN_FACT + ".SP_GET_BILLETERAS";
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
            
        #endregion


        #region Transaciones

        public bool ModificarPorcentaje(decimal P_PORCENTAJE, int P_CODIGO, int P_CODIGO_BASE)
        {
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_PORCENTAJE", DbType.Decimal, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CODIGO_BASE", DbType.Int32, ParameterDirection.Input)
                                               };

            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = P_PORCENTAJE;
            arrParam[2].Value = P_CODIGO;
            arrParam[3].Value = P_CODIGO_BASE;

            bool vexito = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_PORCEN_FACT + ".SP_EDIT_BILLETERA_PORCEN";
            obRequest.Parameters.AddRange(arrParam);
            obRequest.Transactional = true;

            try
            {
                obRequest.Factory.ExecuteNonQuery(ref obRequest);
                obRequest.Factory.CommitTransaction();
                vexito = true;
            }
            catch( Exception ex )
            {
                obRequest.Factory.RollBackTransaction();
                throw ex;
            }
            finally
            {
                IDataParameter parSalida1;
                parSalida1 = (IDataParameter)obRequest.Parameters[0];
                obRequest.Factory.Dispose();
            }
            return vexito;
        }


        public int AgregarPorcentaje(int P_CODIGO, string P_DESCRIPCION, int P_CODIGO_BASE, decimal P_PORCENTAJE, string P_USUARIO)
        {
            
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 20, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CODIGO_BASE", DbType.Int32, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_PORCENTAJE", DbType.Decimal, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_USUARIO", DbType.String, 20, ParameterDirection.Input) 
                                                  };

            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = P_CODIGO;
            arrParam[2].Value = P_DESCRIPCION;
            arrParam[3].Value = P_CODIGO_BASE;
            arrParam[4].Value = P_PORCENTAJE;
            arrParam[5].Value = P_USUARIO;
            
            int vexito = 0;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_PORCEN_FACT + ".SP_INSERT_BILLETERA_PORCEN";
            obRequest.Parameters.AddRange(arrParam);
            obRequest.Transactional = true;

            try
            {
                obRequest.Factory.ExecuteNonQuery(ref obRequest);
                obRequest.Factory.CommitTransaction();   
                vexito = 1;
            }
            catch( Exception ex )
            {
                vexito = 0;
                obRequest.Factory.RollBackTransaction();
                throw ex;
            }
            finally
            {
                IDataParameter parSalida1;
                parSalida1 = (IDataParameter)obRequest.Parameters[0];
                vexito = Int32.Parse(parSalida1.Value.ToString());
                obRequest.Factory.Dispose();
            }
            return vexito;
        }


        public bool ModificarEstadoBilleteras(string P_BILLETERAS, string P_ESTADO){
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_BILLETERAS", DbType.String, 200, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input)
                                               };

            arrParam[0].Value = P_BILLETERAS;
            arrParam[1].Value = P_ESTADO;

            bool vexito = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_PORCEN_FACT + ".SP_EDIT_ESTADO_BILLETERAS";
            obRequest.Parameters.AddRange(arrParam);
            obRequest.Transactional = true;

            try
            {
                obRequest.Factory.ExecuteNonQuery(ref obRequest);
                obRequest.Factory.CommitTransaction();
                vexito = true;
            }
            catch( Exception ex )
            {
                vexito = false;
                obRequest.Factory.RollBackTransaction();
                throw ex;
            }
            finally
            {
                obRequest.Factory.Dispose();
            }
            return vexito;        
        }

        #endregion
	}
}
