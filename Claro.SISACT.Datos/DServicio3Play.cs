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
	/// Descripción breve de DServicio3Play.
	/// </summary>
	public class DServicio3Play
	{
		public DServicio3Play()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

        # region "Consultas"
        public DataTable fdtbListarBusquedaServicio3Play(string pstrDescripcion, string pstrEstado)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),												   
													new DAABRequest.Parameter("P_ESTADO", DbType.String, 50, ParameterDirection.Input)
                                               }; 
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = pstrDescripcion;
			arrParam[2].Value = pstrEstado;
			
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_SERVICIO_3PLAY";
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

        public DataTable fdtbListarEstadoServ3Play(string strTipoItem)
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
		//ldrz
public DataTable fdtbListarProductos()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANT_POSTVENTA + ".SISASS_TIPO_PRODUCTO";
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
//ldrz		
public DataTable fdtbListarGruposxProducto(string pstrCodProd)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_CURSOR", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, 4, ParameterDirection.Input)
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value =  pstrCodProd;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_GRUPOXPRODUCTO";
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
			
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
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
        public DataTable fdtbTraerServicio3Play(string pstrServCodigo)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_SERVCODIGO", DbType.String, 4, ParameterDirection.Input)												   
                                               }; 
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = pstrServCodigo;
			
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_SERVICIO_3PLAY_ID";
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

        # region "Transaciones"
        
        public bool fbooServInsertar(string pstrCodigo, string pstrDescripcion, string pstrIdConfigITW, string pstrDescripcionExt, string pstrDescripcionBSCS, string pstrEstado, string pstrGrupo, int pintOrden,  string pstrUsuario, ref string sEstado, ref string rMsg)
        {			
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_SERVV_CODIGO", DbType.String,4,ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_SERVV_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
//gaa20130923
												   new DAABRequest.Parameter("P_SERVV_CODIGO_EXT", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVV_DES_EXT", DbType.String, 150, ParameterDirection.Input),
//fin gaa20130923
//gaa20131003
												   new DAABRequest.Parameter("P_SERVV_DES_BSCS", DbType.String, 50, ParameterDirection.Input),
//fin gaa20131003
                                                   new DAABRequest.Parameter("P_SERVC_ESTADO", DbType.String, 1, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_GSRVC_CODIGO", DbType.String, 3, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_SERVN_ORDEN", DbType.Int64, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
                                               };

            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value=  pstrCodigo;
            arrParam[2].Value = pstrDescripcion;
//gaa20130923
			arrParam[3].Value = pstrIdConfigITW;
			arrParam[4].Value = pstrDescripcionExt;
//fin gaa20130923
//gaa20131003
			arrParam[5].Value = pstrDescripcionBSCS;
//fin gaa20131003
            arrParam[6].Value = pstrEstado;
            arrParam[7].Value = pstrGrupo;
            arrParam[8].Value = pintOrden;
            arrParam[9].Value = pstrUsuario;


            bool salida = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_INS_SERVICIO_3PLAY";
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


        public bool fbooServ3PlayModificar(string pstrCodigo, string pstrDescripcion, string pstrIdConfigITW, string pstrDescripcionExt, string pstrDescripcionBSCS, string pstrEstado, string pstrGrupo, int pintOrden,  string pstrUsuario, ref string sEstado, ref string rMsg)
        {			
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_SERVV_CODIGO", DbType.String,4,ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_SERVV_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
//gaa20130923
												   new DAABRequest.Parameter("P_SERVV_CODIGO_EXT", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVV_DES_EXT", DbType.String, 150, ParameterDirection.Input),
//fin gaa20130923
//gaa20131003
												   new DAABRequest.Parameter("P_SERVV_DES_BSCS", DbType.String, 50, ParameterDirection.Input),
//fin gaa20131003
                                                   new DAABRequest.Parameter("P_SERVC_ESTADO", DbType.String, 1, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_GSRVC_CODIGO", DbType.String, 3, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_SERVN_ORDEN", DbType.Int64, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
                                               };

            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value=  pstrCodigo;
            arrParam[2].Value = pstrDescripcion;
//gaa20130923
			arrParam[3].Value = pstrIdConfigITW;
			arrParam[4].Value = pstrDescripcionExt;
//fin gaa20130923
//gaa20131003
			arrParam[5].Value = pstrDescripcionBSCS;
//fin gaa20131003
            arrParam[6].Value = pstrEstado;
            arrParam[7].Value = pstrGrupo;
            arrParam[8].Value = pintOrden;
            arrParam[9].Value = pstrUsuario;

            bool salida = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_UPD_SERVICIO_3PLAY";
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


        public bool fbooServ3PlayEliminar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
        {			
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_RESULTADO", DbType.String, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("P_SERVV_CODIGO", DbType.String, 4, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
                                               };
            arrParam[0].Value = DBNull.Value;
            arrParam[1].Value = pstrCodigo;
            arrParam[2].Value = pstrUsuario;
			
            bool salida = false;
            BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_DEL_SERVICIO_3PLAY";
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

        //ESALASB-Modificado luego ldrz
        public DataTable fdtbListarEquiposxServicio3Play(string pstrProducto,string pstrDescripcion,string pstrEstado)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_PRDC", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_ESTADO", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = pstrProducto;
	    arrParam[1].Value = pstrDescripcion;
            arrParam[2].Value = pstrEstado;
            arrParam[3].Value = DBNull.Value;
			
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_EQUIP_SERVICIO_3PLAY";
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

//ldrz
        public DataTable fdtbListarServiciosxGrupo3Play(string pstrProducto,string pstrGrupo)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_GRUPO", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = pstrProducto;
			arrParam[1].Value = pstrGrupo;
            arrParam[2].Value = DBNull.Value;
			
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_SERVICIO_GRUPO_3PLAY";
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
        public DataTable fdtbObtenerEquiposxCodigo3Play(string pstrCodigo)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CODIGO", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = pstrCodigo;
            arrParam[1].Value = DBNull.Value;
			
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_EQUIP_SERVICIO_3PLAY_C";
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
        public DataTable fdtbObtenerEquiposxServicio3Play(string pstrServicio)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_IDSERVICIO", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = pstrServicio;
            arrParam[1].Value = DBNull.Value;
			
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_EQUIP_SERVICIO_3PLAY_S";
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
        //ldrz
public DataTable fdtbListarEquiposxGrupo3Play(string pstrProducto,string pstrGrupo,string pstrServicio)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_PRDC", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_GRUPO", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_SERVICIO", DbType.String, 50, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
                                               }; 
            arrParam[0].Value = pstrProducto;
			arrParam[1].Value = pstrGrupo;
            arrParam[2].Value = pstrServicio;
            arrParam[3].Value = DBNull.Value;
			
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_EQUIP_GRUPO_3PLAY";
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
        public bool fbooInsertarEquiposxServicio3Play(string pstrGrupo, string pstrIdServicio, string pstrServicio, string pstrEstado, string pstrEquipos,ref string pstrMensaje)
        {
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CODGRUPO", DbType.String,ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_IDSERVICIO", DbType.String, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_SERVICIO", DbType.String, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_ESTADO", DbType.String, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_EQUIPOS", DbType.String,8000, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, 10, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("K_MENSAJE", DbType.String, ParameterDirection.Output)
                                               };

            arrParam[0].Value=  pstrGrupo;
            arrParam[1].Value=  pstrIdServicio;
            arrParam[2].Value = pstrServicio;
            arrParam[3].Value = pstrEstado;
            arrParam[4].Value = pstrEquipos;
            arrParam[5].Value = DBNull.Value;
            arrParam[6].Value = DBNull.Value;

            bool salida = false;
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_INS_EQUIP_SERVICIO_3PLAY";
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
                pstrMensaje = "Ocurrió un problema al registrar. Por favor intente nuevamente.";
                throw ex;
            }
            finally
            {
                IDataParameter prmSalida;
                prmSalida = (IDataParameter)obRequest.Parameters[6];
                if(Funciones.CheckStr(prmSalida.Value)!="")
                {
                    pstrMensaje = Funciones.CheckStr(prmSalida.Value);
                }    
                obRequest.Factory.Dispose();
            }			
            return salida ;
        }

        public bool fbooEliminarEquipoxServicio3Play(string pstrCodigo,ref string pstrMensaje)
        {
            DAABRequest.Parameter[] arrParam = {
                                                   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
                                                   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, 10, ParameterDirection.Output),
                                                   new DAABRequest.Parameter("K_MENSAJE", DbType.String, ParameterDirection.Output)
                                               };

            arrParam[0].Value=  pstrCodigo;
            arrParam[1].Value = DBNull.Value;
            arrParam[2].Value = DBNull.Value;

            bool salida = false;
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest obRequest = obj.CreaRequest();
            obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_DEL_EQUIP_SERVICIO_3PLAY";
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
                pstrMensaje = "Ocurrió un problema al eliminar. Por favor intente nuevamente.";
                throw ex;
            }
            finally
            {
                IDataParameter prmSalida;
                prmSalida = (IDataParameter)obRequest.Parameters[2];
                if(Funciones.CheckStr(prmSalida.Value)!="")
                {
                    pstrMensaje = Funciones.CheckStr(prmSalida.Value);
                }
                obRequest.Factory.Dispose();
            }			
            return salida ;
        }
	}

   

}
