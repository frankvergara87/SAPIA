using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for TipoRiesgoDatos.
	/// </summary>
	public class ValidarClienteClaro
	{
		public ValidarClienteClaro()
		{

		}

		public ArrayList Listar_LineasActivas(int intTipDoc, string strDocumento)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int32,ParameterDirection.Input),
												new DAABRequest.Parameter("P_DOCUMENTO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("CUR_TELEFONO", DbType.Object, ParameterDirection.Output),
												new DAABRequest.Parameter("P_COD_RESULT", DbType.Int32, ParameterDirection.Output),
												new DAABRequest.Parameter("P_DES_RESULT", DbType.String, ParameterDirection.Output) 
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = intTipDoc;
			arrParam[1].Value = strDocumento;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.BSCS_LINEAS_ACTIVAS;
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["telefono"]);
					item.Descripcion = Funciones.CheckStr(dr["telefono"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public string Capturar_ValorParametros(string strValor)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												new DAABRequest.Parameter("P_PCONI_CODIGO", DbType.String, ParameterDirection.Input)
			};
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = System.DBNull.Value;
			arrParam[1].Value = strValor;
		
			string pstrNombre = string.Empty;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_OBTENERPARAMETRO;
			objRequest.Parameters.AddRange(arrParam);
		
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[0];
				pstrNombre = Funciones.CheckStr(parSalida1.Value);
				objRequest.Factory.Dispose();
			}
			return pstrNombre;
		}

		public bool Guardar_CodigoSMS(string strNroTelefonico, string strClaveSMS, DateTime dttFecha)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.String, 1, ParameterDirection.Output),
												new DAABRequest.Parameter("P_TELEFONO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_CLAVESMS", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_FEC_REGISTRO", DbType.DateTime, ParameterDirection.Input)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = strNroTelefonico;
			arrParam[2].Value = strClaveSMS;
			arrParam[3].Value = dttFecha;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_ENVIARSMS;
			objRequest.Parameters.AddRange(arrParam);
			objRequest.Transactional = true;

			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				objRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch(Exception e)
			{
				throw  e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[0];
				salida = Funciones.CheckBoo(Funciones.CheckInt(parSalida1.Value));
				objRequest.Factory.Dispose();
			}
			return salida;
		}

		public string Obtener_CodigoSMS(string strNroTelefono)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												new DAABRequest.Parameter("P_TELEFONO", DbType.String, ParameterDirection.Input)
											   };
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = System.DBNull.Value;
			arrParam[1].Value = strNroTelefono;
		
			string pstrNombre = string.Empty;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_OBTENERSMS;
			objRequest.Parameters.AddRange(arrParam);
		
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[0];
				pstrNombre = Funciones.CheckStr(parSalida1.Value);
				objRequest.Factory.Dispose();
			}
			return pstrNombre;
		}

		public int Validar_BlackWhiteList (string strTipDoc, string strDocumento, string strTipoOper,string strFecha, string strTipoLista)
		{
			int intValidar = 0;
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_VALIDAR", DbType.Int32,ParameterDirection.Output),
												new DAABRequest.Parameter("P_TIPODOCU", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_NRODOCU", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_FECHA", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_OPCION", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("P_TFLUJO", DbType.String, ParameterDirection.Input) 
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = System.DBNull.Value;
			arrParam[1].Value = strTipDoc;
			arrParam[2].Value = strDocumento;
			arrParam[3].Value = strFecha;
			arrParam[4].Value = strTipoLista;
			arrParam[5].Value = strTipoOper;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_VALIDARWHITEBLACKLIST;
			obRequest.Parameters.AddRange(arrParam);
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				intValidar = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
			}
			return intValidar;
		}

		public string Validar_BRMS(Double strSolicitud)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												new DAABRequest.Parameter("P_SOLICITUD", DbType.Double, ParameterDirection.Input)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = System.DBNull.Value;
			arrParam[1].Value = strSolicitud;

			string pstrNombre = string.Empty;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_VALIDARBRMS;
			objRequest.Parameters.AddRange(arrParam);
		
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[0];
				pstrNombre = Funciones.CheckStr(parSalida1.Value);
				objRequest.Factory.Dispose();
			}
			return pstrNombre;
		}
		
		public bool Guardar_Logs( ref AuditoriaLogs _pAuditoriaLog)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_AUDI_ITEM", DbType.Int32, ParameterDirection.Output),
												new DAABRequest.Parameter("K_AUDI_SEC", DbType.String, 20, ParameterDirection.Output),
												new DAABRequest.Parameter("K_AUDIV_SECUENCIA", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDIV_NROSEC", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDIV_TIPODOCU", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDIV_NRODOCU", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_LINEAACTIVA", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_BRMS", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_BLACKWHITE", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_POPUP", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDIV_NROEQUIPO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_NROENVIOSMS", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_NROINTENTO", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_NROINDICADOR", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_DISPONIBLESMS", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDIV_COMENTARIO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDII_PDV", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDIV_IPSERVICIO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_AUDIV_USUARIO_CREAC", DbType.String, ParameterDirection.Input)
											   };
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = DBNull.Value;
			arrParam[2].Value = _pAuditoriaLog.AUDIV_SECUENCIA;
			arrParam[3].Value = _pAuditoriaLog.AUDIV_NROSEC;
			arrParam[4].Value = _pAuditoriaLog.AUDIV_TIPODOCU;
			arrParam[5].Value = _pAuditoriaLog.AUDIV_NRODOCU;
			arrParam[6].Value = _pAuditoriaLog.AUDII_LINEAACTIVA;
			arrParam[7].Value = _pAuditoriaLog.AUDII_BRMS;
			arrParam[8].Value = _pAuditoriaLog.AUDII_BLACKWHITE;
			arrParam[9].Value = _pAuditoriaLog.AUDII_POPUP;
			arrParam[10].Value = _pAuditoriaLog.AUDIV_NROEQUIPO;
			arrParam[11].Value = _pAuditoriaLog.AUDII_NROENVIOSMS;
			arrParam[12].Value = _pAuditoriaLog.AUDII_NROINTENTO;
			arrParam[13].Value = _pAuditoriaLog.AUDII_NROINDICADOR;
			arrParam[14].Value = _pAuditoriaLog.AUDII_DISPONIBLESMS;
			arrParam[15].Value = _pAuditoriaLog.AUDIV_COMENTARIO;
			arrParam[16].Value = _pAuditoriaLog.AUDII_PDV;
			arrParam[17].Value = _pAuditoriaLog.AUDIV_IPSERVICIO;
			arrParam[18].Value = _pAuditoriaLog.AUDIV_USUARIO_CREAC;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_GUARDARLOGS ;
			objRequest.Parameters.AddRange(arrParam);
			objRequest.Transactional = true;

			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				objRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch(Exception e)
			{
				throw  e;
			}
			finally
			{
				IDataParameter parSalida1;
				IDataParameter parSalida2;
				parSalida1 = (IDataParameter)objRequest.Parameters[0];
				_pAuditoriaLog.AUDII_ITEM = Funciones.CheckInt(parSalida1.Value);
				parSalida2 = (IDataParameter)objRequest.Parameters[1];
				_pAuditoriaLog.AUDIV_SECUENCIA = Funciones.CheckStr(parSalida2.Value);
				objRequest.Factory.Dispose();
			}
			return salida;
		}

		public bool Actualizar_Logs( ref AuditoriaLogs _pAuditoriaLog)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_AUDII_ITEM", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDIV_NROEQUIPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDII_NROENVIOSMS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDII_NROINTENTO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDII_NROINDICADOR", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDII_DISPONIBLESMS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDIV_COMENTARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDII_PDV", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDIV_IPSERVICIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_AUDIV_USUARIO_MODI", DbType.String, ParameterDirection.Input)
												  };
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = _pAuditoriaLog.AUDII_ITEM;
			arrParam[1].Value = _pAuditoriaLog.AUDIV_NROEQUIPO;
			arrParam[2].Value = _pAuditoriaLog.AUDII_NROENVIOSMS;
			arrParam[3].Value = _pAuditoriaLog.AUDII_NROINTENTO;
			arrParam[4].Value = _pAuditoriaLog.AUDII_NROINDICADOR;
			arrParam[5].Value = _pAuditoriaLog.AUDII_DISPONIBLESMS;
			arrParam[6].Value = _pAuditoriaLog.AUDIV_COMENTARIO;
			arrParam[7].Value = _pAuditoriaLog.AUDII_PDV;
			arrParam[8].Value = _pAuditoriaLog.AUDIV_IPSERVICIO;
			arrParam[9].Value = _pAuditoriaLog.AUDIV_USUARIO_MODI;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_ACTUALIZARLOGS;
			objRequest.Parameters.AddRange(arrParam);
			objRequest.Transactional = true;

			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				objRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch(Exception e)
			{
				throw  e;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return salida;
		}

		public AuditoriaLogs Listar_logs(int intIdAudit)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												new DAABRequest.Parameter("K_AUDII_ITEM", DbType.Int32, ParameterDirection.Input),
											 };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = intIdAudit;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_CONSULTARLOGS;
			obRequest.Parameters.AddRange(arrParam);
			
			//ArrayList filas = new ArrayList();
			IDataReader dr = null;
			AuditoriaLogs p_Auditoria = new AuditoriaLogs();
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while(dr.Read())
					{
						//ItemGenerico item = new ItemGenerico();
						p_Auditoria.AUDII_ITEM = Funciones.CheckInt(dr["AUDII_ITEM"]);
						p_Auditoria.AUDII_BLACKWHITE = Funciones.CheckInt(dr["AUDII_BLACKWHITE"]);
						p_Auditoria.AUDII_BRMS = Funciones.CheckInt(dr["AUDII_BRMS"]);
						p_Auditoria.AUDII_DISPONIBLESMS = Funciones.CheckInt(dr["AUDII_DISPONIBLESMS"]);
						p_Auditoria.AUDII_LINEAACTIVA = Funciones.CheckInt(dr["AUDII_LINEAACTIVA"]);
						p_Auditoria.AUDII_NROENVIOSMS = Funciones.CheckInt(dr["AUDII_NROENVIOSMS"]);
						p_Auditoria.AUDII_NROINDICADOR = Funciones.CheckInt(dr["AUDII_NROINDICADOR"]);
						p_Auditoria.AUDII_NROINTENTO = Funciones.CheckInt(dr["AUDII_NROINTENTO"]);
						p_Auditoria.AUDII_PDV = Funciones.CheckInt(dr["AUDII_PDV"]);
						p_Auditoria.AUDII_POPUP = Funciones.CheckInt(dr["AUDII_POPUP"]);
						p_Auditoria.AUDIV_COMENTARIO = Funciones.CheckStr(dr["AUDIV_COMENTARIO"]);
						p_Auditoria.AUDIV_NRODOCU = Funciones.CheckStr(dr["AUDIV_NRODOCU"]);
						p_Auditoria.AUDIV_NROSEC = Funciones.CheckStr(dr["AUDIV_NROSEC"]);
						p_Auditoria.AUDIV_SECUENCIA= Funciones.CheckStr(dr["AUDIV_SECUENCIA"]);
						p_Auditoria.AUDIV_TIPODOCU = Funciones.CheckStr(dr["AUDIV_TIPODOCU"]);
						//filas.Add(item);
					}
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return p_Auditoria;
		}
	}
}