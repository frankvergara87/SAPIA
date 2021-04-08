//PROY-32129 :: INI
using System;
using System.Configuration;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Text;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// //PROY-33192
	/// </summary>
	public class DACasoEspecial
	{
		public DACasoEspecial()
		{
			
		}

		public ArrayList ListarUniversidades(ref string sCodMensaje, ref string sMensaje)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("pout_respuesta_codigo", DbType.Int64,ParameterDirection.Output),
                                                   new DAABRequest.Parameter("pout_respuesta_mensaje", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("pout_respuesta_cursor", DbType.Object,ParameterDirection.Output)
											   }; 
                
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".sisacss_listado_instituciones";

			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["INSTN_ID"]);
					oItem.Descripcion = Funciones.CheckStr(dr["INSTV_DESCRIPCION"]);
					filas.Add(oItem);
				}
			}
			catch(Exception e)
			{    
                sCodMensaje = "-1";
				sMensaje = "ERROR AL EJECUTAR SP: " + BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".SISACT_MAESTRO_INSTITUCION" + e.Message.ToString();
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}


		public bool RegistrarAlumno(string sTipoDoc, string sNroDoc, Int64 iCodInst, string sCodPersona, string sUsuario ,ref string sCodMensaje, ref string sMensaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("pin_tipo_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pin_nro_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pin_cod_institucion", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("pin_cod_persona", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pin_usuario", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pout_respuesta_codigo", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("pout_respuesta_mensaje", DbType.String,ParameterDirection.Output)
											   }; 
			bool salida = false;

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = sTipoDoc;
			arrParam[1].Value = sNroDoc;
			arrParam[2].Value = iCodInst;
			arrParam[3].Value = sCodPersona;
			arrParam[4].Value = sUsuario;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".sisacsiu_log_whitelist";

			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter pSalida1, pSalida2;
				pSalida1 = (IDataParameter)obRequest.Parameters[5];
				pSalida2 = (IDataParameter)obRequest.Parameters[6];
				sCodMensaje = Funciones.CheckStr(pSalida1.Value);
				sMensaje = Funciones.CheckStr(pSalida2.Value);

				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				sCodMensaje = "-1";
				sMensaje = "ERROR AL EJECUTAR SP: " + BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".sisacsiu_log_whitelist - " + ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			

			return salida ;
		}


		public bool ValidarAlumno(string sTipoDoc, string sNroDoc, ref string sCodMensaje, ref string sMensaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("pin_tipo_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pin_nro_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pout_respuesta_codigo", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("pout_respuesta_mensaje", DbType.String,ParameterDirection.Output)
											   }; 
			bool salida = false;

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = sTipoDoc;
			arrParam[1].Value = sNroDoc;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".sisacss_whitelist_x_doc";

			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter pSalida1, pSalida2;
				pSalida1 = (IDataParameter)obRequest.Parameters[2];
				pSalida2 = (IDataParameter)obRequest.Parameters[3];
				sCodMensaje = Funciones.CheckStr(pSalida1.Value);
				sMensaje = Funciones.CheckStr(pSalida2.Value);

				if (sCodMensaje == "1")//cliente SI se encuentra en el whitelist.';
				{
					salida = true;	
				}

			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				sCodMensaje = "-1";
				sMensaje = "ERROR AL EJECUTAR SP: " + BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".sisacss_whitelist_x_doc - " + ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			

			return salida;
		}

		public bool EliminarAlumno(string sTipoDoc, string sNroDoc, string usuario, ref string sCodMensaje, ref string sMensaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("pin_tipo_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pin_nro_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pin_usuario", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("pout_respuesta_codigo", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("pout_respuesta_mensaje", DbType.String,ParameterDirection.Output)
											   }; 
			bool salida = false;

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = sTipoDoc;
			arrParam[1].Value = sNroDoc;
			arrParam[2].Value = usuario;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".sisacsd_log_whitelist";

			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter pSalida1, pSalida2;
				pSalida1 = (IDataParameter)obRequest.Parameters[3];
				pSalida2 = (IDataParameter)obRequest.Parameters[4];
				sCodMensaje = Funciones.CheckStr(pSalida1.Value);
				sMensaje = Funciones.CheckStr(pSalida2.Value);

				if (sCodMensaje == "1")//registro ha sido desactivado.
				{
					salida = true;	
				}

			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				sCodMensaje = "-1";
				sMensaje = "ERROR AL EJECUTAR SP: " + BaseDatos.PKG_SISACT_CAMPANA_ESPECIAL + ".sisacss_whitelist_x_doc - " + ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			

			return salida;
		}

	}
}
//PROY-32129 :: FIN