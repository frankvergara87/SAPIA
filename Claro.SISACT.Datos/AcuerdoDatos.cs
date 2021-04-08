using System;
using System.Configuration;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.DAAB; 
using Claro.SisAct.Common;


namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for AcuerdoDatos.
	/// </summary>
	public class AcuerdoDatos
	{
		public AcuerdoDatos()
		{
		}


		public ArrayList ListarPorCodigoEvaluacionCodSEC(int codevaluacion,long codsec)
		{			
			//me lista acciones segun el codigo de evaluacion
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("codsec", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("codevaluacion", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codsec;
			arrParam[1].Value = codevaluacion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".ListarAcuerdosEvalPorSec";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList salida = new ArrayList();
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{

					Acuerdo item = new Acuerdo();
					item.COD_ACUERDO= Funciones.CheckInt(dr["cod_acuerdo"]); 
					
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


#region "Operaciones Solicitud"
		
		public virtual long ExisteSolicitud (long pNroSolicitudSEC)
		{
			//--inicializa dato a  devolver
			long intExiste = 0; //- 0= NO existe
			//--define parametros
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NroSolicitud", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_Existe", DbType.Int32, ParameterDirection.Output)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!pNroSolicitudSEC.Equals(-1)) arrParam[0].Value = pNroSolicitudSEC;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".SECT_SOLICITUD_Existe";
			objRequest.Parameters.AddRange(arrParam);
	
			try
			{
				intExiste =	Funciones.CheckInt(objRequest.Factory.ExecuteScalar(ref objRequest));
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[1];
				intExiste = Funciones.CheckInt64(parSalida1.Value);
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			return intExiste;
		}


		public virtual long ActualizarEstadoSEC (ref DAABRequest pObjRequest, long pCOD_SEC, string pCodEstadoNuevo, string pLoginUsuario)
		{
			long iResultado = 0; //--
			bool SeCreaRequest = false;	//si se crea en esta funcion el objeto Request

			if (pObjRequest == null) 
			{
				BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				pObjRequest = obj.CreaRequest();
				pObjRequest.Transactional = true;
				SeCreaRequest = true;
			}
			
			try
			{				
				//---establecer parametros
				DAABRequest.Parameter[] arrParam = {
													   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_COD_ESTADO", DbType.String,ParameterDirection.Input), 
													   new DAABRequest.Parameter("P_LOGIN", DbType.String,16,ParameterDirection.Input), 
													   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64,ParameterDirection.Output) 
												   };
				for (int i=0; i<arrParam.Length;i++)
					arrParam[i].Value = DBNull.Value;

				if(pCOD_SEC>0) arrParam[0].Value = pCOD_SEC ;
				if(!pCodEstadoNuevo.Equals("")) arrParam[1].Value = pCodEstadoNuevo;
				if(!pLoginUsuario.Equals("")) arrParam[2].Value = pLoginUsuario;
						
				pObjRequest.Parameters.Clear(); 
				pObjRequest.Parameters.AddRange(arrParam);

				//----
				pObjRequest.CommandType = CommandType.StoredProcedure;
				pObjRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".SECT_SOLICITUD_Act_Estado";
				pObjRequest.Factory.ExecuteNonQuery(ref pObjRequest);
				
				//--recupera parametro de resultado				
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)pObjRequest.Parameters[3];
				iResultado = Funciones.CheckInt64(parSalida1.Value);
				
				if (SeCreaRequest)
					pObjRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				if (SeCreaRequest)
					pObjRequest.Factory.RollBackTransaction();
				
				throw ex;
			}
			finally
			{		
				pObjRequest.Parameters.Clear();
				if (SeCreaRequest)
					pObjRequest.Factory.Dispose();
			}	
			
			return iResultado;
		}


#endregion

#region "Operaciones de Cliente"

		public string ObtenerRUC_Asociado (long pCOD_SEC)
		{
			//--inicializa dato a  devolver
			string sRUC;
			//--define parametros
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RUC", DbType.String, ParameterDirection.Output)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(pCOD_SEC>0) arrParam[0].Value = pCOD_SEC;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".CLIENTE_Obt_RUC_Asociado";
			objRequest.Parameters.AddRange(arrParam);
	
			try
			{
				Funciones.CheckInt(objRequest.Factory.ExecuteScalar(ref objRequest));
				//---
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[1];
				sRUC = Funciones.CheckStr(parSalida1.Value);
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			//---
			return sRUC;
		}

		
#endregion


#region "Operaciones principales"
		

		
		public virtual bool ExisteAcuerdo (long pNroSolicitudSEC, int pIdDocumento)
		{
			//--inicializa dato a  devolver
			long intExiste = 0; //- 0= NO existe
			//--define parametros
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EXISTE", DbType.Int64, ParameterDirection.Output)
											   };
			//int i;
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!pNroSolicitudSEC.Equals(-1)) arrParam[0].Value = pNroSolicitudSEC;
			if(!pNroSolicitudSEC.Equals(-1)) arrParam[1].Value = pIdDocumento;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".ACUERDO_Existe_X_Tipo";
			objRequest.Parameters.AddRange(arrParam);
	
			try
			{
				Funciones.CheckInt(objRequest.Factory.ExecuteScalar(ref objRequest));
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[2];
				intExiste = Funciones.CheckInt64(parSalida1.Value);
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			return (intExiste != 0);

		}


		public virtual long ObtSolicitudDeDocumentoActivo(string pRUC, int pIdDocumento)
		{
			//--inicializa dato a  devolver
			long iCOD_SEC= 0; //- 0= NO existe
			//--define parametros
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RUC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64, ParameterDirection.Output)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!pRUC.Equals("")) arrParam[0].Value = pRUC;
			if(pIdDocumento>0) arrParam[1].Value = pIdDocumento;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".ACUERDO_Obt_Solic_Doc_Activo";
			objRequest.Parameters.AddRange(arrParam);
	
			try
			{
				objRequest.Factory.ExecuteScalar(ref objRequest);
				//---
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[2];
				iCOD_SEC = Funciones.CheckInt64(parSalida1.Value);
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			return iCOD_SEC; //(iTiene > 0);
		}
		
		

		
		public long Eliminar(long pCodigoAcuerdo)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_COD_ACUERDO", DbType.Int64,ParameterDirection.InputOutput)
											   }; 

			arrParam[0].Value = DBNull.Value;
			if(!pCodigoAcuerdo.Equals("")) arrParam[0].Value = pCodigoAcuerdo;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".ACUERDO_Eliminar";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;

			int retorno;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{
				obRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				retorno = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
			return retorno;	
		}


		public long Eliminar(long pNroSolicitud, int pIdDocumento)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOCS_ELIMINADOS", DbType.Int32,ParameterDirection.Output)
											   }; 

			int intCont=0;
			for ( intCont=0; intCont<arrParam.Length;intCont++)
				arrParam[intCont].Value = DBNull.Value;
			
			if(pNroSolicitud>0) arrParam[0].Value = pNroSolicitud;
			if(pIdDocumento>0) arrParam[1].Value = pIdDocumento;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".ACUERDO_Eliminar_X_SEC_DOC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;

			long retorno;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				//---
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				retorno = Funciones.CheckInt(parSalida1.Value);
			}
			catch(Exception e)
			{
				obRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
			return retorno;	
		}




		/// <summary>
		/// Pobla la entidad correspondiente la registro Acuerdo dela Base de Datos
		/// </summary>
		/// <param name="idrd"></param>
		/// <returns>Entidad Acuerdo</returns>
		
		public long ObtenerCodigo_X_SEC_DOC(long pNroSolicitudSEC, int pIdDocumento)
		{
			//--inicializa dato a  devolver
			long iCodigo = -1;
			//--define parametros
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_ACUERDO", DbType.Int32,ParameterDirection.Output)
											   };
			int i;

			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!pNroSolicitudSEC.Equals(-1)) arrParam[0].Value = pNroSolicitudSEC;
			if(!pIdDocumento.Equals(-1)) arrParam[1].Value = pIdDocumento;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".ACUERDO_ObtenerCod_X_SEC_DOC";
			objRequest.Parameters.AddRange(arrParam);
	
			try
			{
				Funciones.CheckStr(objRequest.Factory.ExecuteScalar(ref objRequest));
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[2];
				iCodigo = Funciones.CheckInt(parSalida1.Value);
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			//---
			return iCodigo;
		}


		
#endregion

		
		/// <summary>
		/// Obtiene la Lista de los items de documentos de de una Solicitud, desde la BD
		/// </summary>
		/// <param name="pNroSolicitudSEC">Nro de Solicitud</param>
		/// <returns></returns>
		public ArrayList ListarItemsDoc (long pNroSolicitudSEC)
		{
			//--parametro de salida
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_ITEMS_DOC", DbType.Object,ParameterDirection.Output)
											   }; 
			
			if(!pNroSolicitudSEC.Equals(-1)) arrParam[0].Value = pNroSolicitudSEC;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT); 
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO +".DOCUMENTO_SEC_Listar_X_SEC" ;
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					DocumentoSEC_Desc item = new DocumentoSEC_Desc();
					item.ID_DOCUMENTO_SEC =Funciones.CheckInt64(dr["ID_DOCUMENTO_SEC"]);
					item.COD_SEC =Funciones.CheckInt64(dr["COD_SEC"]);
					item.ID_DOCUMENTO =Funciones.CheckInt(dr["ID_DOCUMENTO"]);
					item.DESC_TIPO_DOCUMENTO  = Funciones.CheckStr(dr["DESC_TIPO_DOCUMENTO"]);
					item.DESC_DOCUMENTO  = Funciones.CheckStr(dr["DESC_DOCUMENTO"]);
					item.NOMBRE_GLOSA  = Funciones.CheckStr(dr["NOMBRE_GLOSA"]);
					item.COD_ESTADO   = Funciones.CheckStr(dr["COD_ESTADO"]);
					item.DESC_ESTADO  = Funciones.CheckStr(dr["DESC_ESTADO"]);
					item.TIPO_CREACION = Funciones.CheckStr(dr["TIPO_CREACION"]);
					item.DESC_TIPO_CREACION  = Funciones.CheckStr(dr["DESC_TIPO_CREACION"]);
					item.FECHA_CREACION  = Funciones.CheckDate(dr["FECHA_CREACION"]);
					item.NOMBRE_ARCHIVO  = Funciones.CheckStr(dr["NOMBRE_ARCHIVO"]); //agregado 25-05-2010
					//--agrega item
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}




				
		#region AcuerdoB29


		#endregion
		
		/*T12646*/
		public ArrayList ListarItemsDocSec (long pNroSolicitudSEC, string datFecha)
		{
			//--parametro de salida
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int32,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_ID_DOC_SEC", DbType.DateTime ,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEMS_DOC", DbType.Object,ParameterDirection.Output)
			};

			if(!pNroSolicitudSEC.Equals(-1)) arrParam[0].Value = pNroSolicitudSEC;
			if(!pNroSolicitudSEC.Equals(-1)) arrParam[1].Value = datFecha;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO +".DOCUMENTO_SEC_Listar_X_SEC_DOC" ;
			obRequest.Parameters.AddRange(arrParam);
						
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					DocumentoSEC_Desc item = new DocumentoSEC_Desc();
					item.ID_DOCUMENTO_SEC =Funciones.CheckInt64(dr["ID_DOCUMENTO_SEC"]);
					item.COD_SEC =Funciones.CheckInt(dr["COD_SEC"]);
					item.ID_DOCUMENTO =Funciones.CheckInt(dr["ID_DOCUMENTO"]);
					item.DESC_TIPO_DOCUMENTO  = Funciones.CheckStr(dr["DESC_TIPO_DOCUMENTO"]);
					item.DESC_DOCUMENTO  = Funciones.CheckStr(dr["DESC_DOCUMENTO"]);
					item.NOMBRE_GLOSA  = Funciones.CheckStr(dr["NOMBRE_GLOSA"]);
					item.COD_ESTADO   = Funciones.CheckStr(dr["COD_ESTADO"]);
					item.DESC_ESTADO  = Funciones.CheckStr(dr["DESC_ESTADO"]);
					item.TIPO_CREACION = Funciones.CheckStr(dr["TIPO_CREACION"]);
					item.DESC_TIPO_CREACION  = Funciones.CheckStr(dr["DESC_TIPO_CREACION"]);
					item.FECHA_CREACION  = Funciones.CheckDate(dr["FECHA_CREACION"]);
					item.NOMBRE_ARCHIVO  = Funciones.CheckStr(dr["NOMBRE_ARCHIVO"]); //agregado 25-05-2010

					//--agrega item
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
		}
			return filas;
			}


				
		public long Cerrar_X_SEC(ref DAABRequest pObjRequest, long pCOD_SEC)	
			{
			bool SeCreaRequest = false;	//si se crea en esta funcion el objeto Request
			long retorno;			

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64,ParameterDirection.Output),
			};

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(pCOD_SEC>0) arrParam[0].Value = pCOD_SEC;
			
			if (pObjRequest == null) 
			{
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				pObjRequest = obj.CreaRequest();
				pObjRequest.Transactional = true;
				SeCreaRequest = true;
		}
			pObjRequest.CommandType = CommandType.StoredProcedure;

			pObjRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".ACUERDO_Cerrar_X_SEC";

			pObjRequest.Parameters.Clear(); 
			pObjRequest.Parameters.AddRange(arrParam);
						

			try
			{
				pObjRequest.Factory.ExecuteNonQuery(ref pObjRequest);				
			//--
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)pObjRequest.Parameters[1];
				retorno = Funciones.CheckInt64(parSalida1.Value);
				//--
				if (SeCreaRequest)
					pObjRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{		
				if (SeCreaRequest)
					pObjRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				if (SeCreaRequest)
					pObjRequest.Factory.Dispose();				
			}
			return retorno;	
		}

		public long Cerrar(Acuerdo pObjAcuerdoEnt)	
			{
			DAABRequest pObjRequest = null; 
			return Cerrar(ref pObjRequest, pObjAcuerdoEnt);
		}


		protected long Cerrar(ref DAABRequest pObjRequest, Acuerdo pObjAcuerdoEnt)	
		{
			bool SeCreaRequest = false;	//si se crea en esta funcion el objeto Request
			long retorno;			

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64,ParameterDirection.Output),
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(pObjAcuerdoEnt.COD_SEC>0) arrParam[0].Value = pObjAcuerdoEnt.COD_SEC;
			if(pObjAcuerdoEnt.ID_DOCUMENTO>0) arrParam[1].Value = pObjAcuerdoEnt.ID_DOCUMENTO;
						

			if (pObjRequest == null) 
		{
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				pObjRequest = obj.CreaRequest();
				pObjRequest.Transactional = true;
				SeCreaRequest = true;
			}
			pObjRequest.CommandType = CommandType.StoredProcedure;

			pObjRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".ACUERDO_Cerrar";

			pObjRequest.Parameters.Clear(); 
			pObjRequest.Parameters.AddRange(arrParam);
						

			try
			{
				pObjRequest.Factory.ExecuteNonQuery(ref pObjRequest);				
				//--
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)pObjRequest.Parameters[2];
				retorno = Funciones.CheckInt64(parSalida1.Value);
				//--
				if (SeCreaRequest)
					pObjRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{		
				if (SeCreaRequest)
					pObjRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				if (SeCreaRequest)
					pObjRequest.Factory.Dispose();				
			}
			return retorno;	
			}
		}


}
