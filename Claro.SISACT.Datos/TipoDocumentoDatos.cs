using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for TipoDocumentoDatos.
	/// </summary>
	public class TipoDocumentoDatos
	{
		public TipoDocumentoDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Obtiene todos los Tipos de Documentos
		/// </summary>
		/// <returns></returns>
		public ArrayList Listar()
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.Object,ParameterDirection.Output)}; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT); 
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO +".TIPO_DOCUMENTO_LISTAR" ;
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					
					TipoDocumentoE item = new TipoDocumentoE(
												Funciones.CheckInt(dr["ID_TIPO_DOCUMENTO"]),
												Funciones.CheckStr(dr["NOMBRE"]),
												Funciones.CheckInt(dr["ORDEN"]),
												Funciones.CheckInt(dr["TOTAL_DOCS_ADJUNTA"])
												);
					//--
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


		public ArrayList listar(int cod,string descripcion,string estado)
		{			
			//me lista TipoDoces segun el codigo de evaluacion
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("v_codtdoc", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_desctdoc", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_estado", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = cod;
			arrParam[1].Value = descripcion;
			arrParam[2].Value = estado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_ListarTipoDoc";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList salida = new ArrayList();
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{

					TipoDocumentoE item = new TipoDocumentoE();

					item.CODIGO= Funciones.CheckInt(dr["id_tipo_documento"]); 
					item.NOMBRE= Funciones.CheckStr(dr["nombre"]);
					item.REGISTRO.ORDEN =Funciones.CheckInt16(dr["orden"]);
					item.REGISTRO.FECHA_MODIFICACION =Funciones.CheckDate(dr["fecha_modificacion"]);
					item.REGISTRO.USUARIO_MODIFICACION =Funciones.CheckStr(dr["usuario"]);
					item.REGISTRO.ACTIVO =Funciones.CheckStr(dr["activo"]);

					salida.Add(item);
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
			return salida;
		}


		public void insertar(TipoDocumentoE objTipoDoc,out int resultado)
		{

			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_nombre", DbType.String,200 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_orden", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_usuario_creacion", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = objTipoDoc.NOMBRE;
			arrParam[1].Value= objTipoDoc.REGISTRO.ORDEN;
			arrParam[2].Value= objTipoDoc.REGISTRO.USUARIO_CREACION;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_insertarTipoDoc";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch (Exception)
			{	
				resultado=1;
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{	
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				resultado = int.Parse(parSalida1.Value.ToString());
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}


		public void actualizar(TipoDocumentoE objTipoDoc,out int resultado)
		{

			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_id_tipo_documento", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_nombre", DbType.String,200 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_orden", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_usuario_modificacion", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value= objTipoDoc.CODIGO;
			arrParam[1].Value = objTipoDoc.NOMBRE;
			arrParam[2].Value= objTipoDoc.REGISTRO.ORDEN;
			arrParam[3].Value= objTipoDoc.REGISTRO.USUARIO_MODIFICACION;


			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_actualizarTipoDoc";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch (Exception)
			{	
				resultado=1;
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{		
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[4];
				resultado = int.Parse(parSalida1.Value.ToString());

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}


		public void eliminar(int cod,string estado,string usuario,out int resultado)
		{

			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_id_tipo_documento", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_estado", DbType.String,1,ParameterDirection.Input),
				                                   new DAABRequest.Parameter("v_usuario_modificacion", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
												   
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value= cod;
			arrParam[1].Value= estado;
			arrParam[2].Value= usuario;


			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_cambiarEstadoTipoDoc";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch (Exception)
			{		
				resultado=1;
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{				
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				resultado = int.Parse(parSalida1.Value.ToString());

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

	}
}
