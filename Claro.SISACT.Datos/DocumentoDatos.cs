using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for DocumentoDatos.
	/// </summary>
	public class DocumentoDatos
	{
		public DocumentoDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Obtiene todos los Documentos segun parametros
		/// </summary>
		/// <param name="pTipoDoc"></param>
		/// <returns></returns>
		public ArrayList Listar(int pCodigoTipoDocumento)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_ID_TIPO_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												new DAABRequest.Parameter("P_DOCUMENTO", DbType.Object,ParameterDirection.Output)}; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
		
			arrParam[0].Value = pCodigoTipoDocumento;
			//--
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT); 
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO +".DOCUMENTO_LISTAR" ;
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{	
					Documento item = new Documento();
					item.CODIGO  = Funciones.CheckInt(dr["ID_DOCUMENTO"]);
					item.NOMBRE  = Funciones.CheckStr(dr["NOMBRE"]);
					
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

		public ArrayList listar(int cod,string descripcion,string estado,int tipodoc)
		{			
			//me lista Documentoes segun el codigo de evaluacion
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("v_coddoc", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_descdoc", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_estado", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_tipodoc", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = cod;
			arrParam[1].Value = descripcion;
			arrParam[2].Value = estado;
			arrParam[3].Value = tipodoc;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_ListarDocumento";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList salida = new ArrayList();
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{

					Documento item = new Documento();

					item.CODIGO= Funciones.CheckInt(dr["id_documento"]); 
					item.NOMBRE= Funciones.CheckStr(dr["nombre"]);
					item.REGISTRO.ORDEN =Funciones.CheckInt16(dr["nro_orden"]);
					item.TIPO_DOCUMENTO.CODIGO = Funciones.CheckInt(dr["id_tipo_documento"]); 
					item.TIPO_DOCUMENTO.NOMBRE = Funciones.CheckStr(dr["tipo_doc_desc"]); 
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


		public void insertar(Documento objDocumento,out int resultado)
		{

			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_nombre", DbType.String,255 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_orden", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_tipodoc", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_usuario_creacion", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)

											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = objDocumento.NOMBRE;
			arrParam[1].Value= objDocumento.REGISTRO.ORDEN;
			arrParam[2].Value= objDocumento.TIPO_DOCUMENTO.CODIGO;
			arrParam[3].Value= objDocumento.REGISTRO.USUARIO_CREACION;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_insertarDocumento";
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


		public void actualizar(Documento objDocumento,out int resultado)
		{

			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_id_documento", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_nombre", DbType.String,255 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_tipodoc", DbType.Int32 ,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_orden", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_usuario_modificacion", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value= objDocumento.CODIGO;
			arrParam[1].Value = objDocumento.NOMBRE;
			arrParam[2].Value= objDocumento.TIPO_DOCUMENTO.CODIGO;
			arrParam[3].Value= objDocumento.REGISTRO.ORDEN;
			arrParam[4].Value= objDocumento.REGISTRO.USUARIO_MODIFICACION;


			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_actualizarDocumento";
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
				parSalida1 = (IDataParameter)obRequest.Parameters[5];
				resultado = int.Parse(parSalida1.Value.ToString());

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}


		public void eliminar(int cod,string estado,string usuario,out int resultado)
		{

			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_id_documento", DbType.Int32,ParameterDirection.Input),
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
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".Mant_cambiarEstadoDocumento";
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
