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
	/// Descripción breve de DEquipos3Play.
	/// </summary>
	public class DEquipos3Play
	{
		public DEquipos3Play()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

        # region "Consulta"
        public DataTable fdtbListarBusquedaEquipos(string pstrDescripcion, string pstrEstado)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
													new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input)
                                               }; 
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = pstrDescripcion;
			arrParam[2].Value = pstrEstado;
			
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_MATERIAL_3PLAY";
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
        
        public DataTable fdtbListarTipoEquipos()
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = DBNull.Value;
			
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_TIPO_EQUIPO_3PLAY";
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

        public DataTable fdtbListarEstadoEquipos(string strTipoItem)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.String, 10, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = strTipoItem;
            arrParam[1].Value = DBNull.Value;
			
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_ITEM";
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

        public DataTable fdtbListarGrupos()
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = DBNull.Value;
			
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_GRUPO_SERV_3PLAY";
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

        public DataTable fdtbTraerEquipos(string pstrMateCodigo)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_MATVCODIGO", DbType.String, 10, ParameterDirection.Input)												   
                                               }; 
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = pstrMateCodigo;
			
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_MATERIAL_3PLAY_ID";
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

        
        #endregion

        # region "Transacciones"
        public bool fbooEquiInsertar(string pstrCodigo, string pstrDescripcion, string pstrTipo, string pstrEstado, string pstrIdSap, string pstrDesSap, 
									 string pstrTipEqu, string strAccion , string pstrUsuario, ref string sEstado, ref string rMsg)
        {			
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_MATV_CODIGO", DbType.String, 10,ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_MATV_DESCRIPCION", DbType.String, 60, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_TMATC_CODIGO", DbType.String, 2, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_MATC_ESTADO", DbType.String, 1, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_MATV_ID_SAP", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATV_DES_SAP", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPEQU", DbType.String, 10, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_ACCION", DbType.String, 1, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
                                               };
			int i;
            i=0; arrParam[i].Value = DBNull.Value;
            ++i; arrParam[i].Value=  pstrCodigo;
            ++i; arrParam[i].Value = pstrDescripcion;
            ++i; arrParam[i].Value = pstrTipo;
            ++i; arrParam[i].Value = pstrEstado;
			++i; arrParam[i].Value = pstrIdSap;
			++i; arrParam[i].Value = pstrDesSap;
			++i; arrParam[i].Value = pstrTipEqu;
            ++i; arrParam[i].Value = strAccion;
            ++i; arrParam[i].Value = pstrUsuario;


            bool salida = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_INS_MATERIAL_3PLAY";
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
                sEstado = Funciones.CheckStr(parSalida1.Value);
                obRequest.Factory.Dispose();
            }			
            return salida ;
        }
        //SP_INS_MATERIAL_GRUPO_3PLAY
        public bool fbooGrupoInsertar(string pstrCodigo, string pstrGrupo, ref string sEstado, ref string rMsg)
        {			
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_MATV_CODIGO", DbType.String,10,ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_GRUPOS", DbType.String, 50, ParameterDirection.Input)
                                               };

            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value=  pstrCodigo;
            arrParam[2].Value = pstrGrupo;


            bool salida = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_INS_MATERIAL_GRUPO_3PLAY";
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
                sEstado = Funciones.CheckStr(parSalida1.Value);
                obRequest.Factory.Dispose();
            }			
            return salida ;
        }

        //MANTSD_ELIMIN_MATE_3_PLAY

        public bool fbooEqui3PlayEliminar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
        {			
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.String, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_MATV_CODIGO", DbType.String, 10, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
                                               };
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = pstrCodigo;
            arrParam[2].Value = pstrUsuario;
			
            bool salida = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_DEL_MATERIAL_3_PLAY";
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
