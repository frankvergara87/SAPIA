using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for DocumentoSECDatos.
	/// </summary>
	public class DocumentoSECDatos
	{
		public DocumentoSECDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}


#region "Operaciones CRUD"
		

		/// <summary>
		/// Recupera el Nombre de archivo digitalizado de un Documento SEC
		/// </summary>
		/// <param name="pIDDOcumentoSEC"></param>
		/// <returns></returns>
		public string ObtenerNombreArchivo(long pIDDOcumentoSEC ) 
		{

			//--inicializa dato a  devolver
			string strNombreArchivo = "";
			//--define parametros
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ID_DOCUMENTO_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_ARCHIVO", DbType.String,ParameterDirection.Output)
											   }; 
			int i;
			
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!pIDDOcumentoSEC.Equals(-1)) arrParam[0].Value = pIDDOcumentoSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_DeterminaArchivo";
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
				parSalida1 = (IDataParameter)objRequest.Parameters[1];
				strNombreArchivo = Funciones.CheckStr(parSalida1.Value);
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			return strNombreArchivo;
		}


		public string ObtenerNombreArchivoIngreso(long pNroSolicitud, int pIdDocumento ) 
		{
			//--inicializa dato a  devolver
			string strNombreArchivo = "";
			//--define parametros
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_ARCHIVO", DbType.String,ParameterDirection.Output)
											   };
			int i;

			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!pNroSolicitud.Equals(-1)) arrParam[0].Value = pNroSolicitud;
			if(!pIdDocumento.Equals(-1)) arrParam[1].Value = pIdDocumento;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_DeterminaArchIng";
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
				strNombreArchivo = Funciones.CheckStr(parSalida1.Value);
				objRequest.Factory.Dispose();
				objRequest.Parameters.Clear();
			}
			return strNombreArchivo;

		}
		

		//-----para eliminar		

		public long Crear(DocumentoSEC pObjDocumentoSEC) 
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_COD_DOCUMENTO_SEC", DbType.Int32,ParameterDirection.InputOutput),
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_GLOSA", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CREACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_CREACION", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREACION", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_ARCHIVO", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_RECIBO", DbType.Int64,ParameterDirection.Input)	
											   }; 

	
			int intCont=0;
			for ( intCont=0; intCont<arrParam.Length;intCont++)
				arrParam[intCont].Value = DBNull.Value;
			
			if(!pObjDocumentoSEC.COD_SEC.Equals(-1)) arrParam[1].Value = pObjDocumentoSEC.COD_SEC;
			if(!pObjDocumentoSEC.ID_DOCUMENTO.Equals(-1)) arrParam[2].Value = pObjDocumentoSEC.ID_DOCUMENTO;
			if(!pObjDocumentoSEC.NOMBRE_GLOSA.Equals("")) arrParam[3].Value = pObjDocumentoSEC.NOMBRE_GLOSA;
			if(!pObjDocumentoSEC.TIPO_CREACION.Equals("")) arrParam[4].Value = pObjDocumentoSEC.TIPO_CREACION;

			arrParam[5].Value = System.DateTime.Now;  //--provisional 
			if(!pObjDocumentoSEC.USUARIO_CREACION.Equals("")) arrParam[6].Value = pObjDocumentoSEC.USUARIO_CREACION;
			if(!pObjDocumentoSEC.NOMBRE_ARCHIVO.Equals("")) arrParam[7].Value = pObjDocumentoSEC.NOMBRE_ARCHIVO;
			if(pObjDocumentoSEC.CODIGO_RECIBO>0) arrParam[8].Value = pObjDocumentoSEC.CODIGO_RECIBO;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_Insertar";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;

			long retorno;
			
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


		//-----para eliminar
		public long Actualizar(DocumentoSEC pObjDocumentoSEC)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_COD_DOCUMENTO_SEC", DbType.Int64,ParameterDirection.InputOutput),
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_GLOSA", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CREACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREACION", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_RECIBO", DbType.Int64,ParameterDirection.Input)	
												}; 

			int intCont=0;
			for ( intCont=0; intCont<arrParam.Length;intCont++)
				arrParam[intCont].Value = DBNull.Value;
			
			if(!pObjDocumentoSEC.ID_DOCUMENTO_SEC.Equals(-1)) arrParam[0].Value = pObjDocumentoSEC.ID_DOCUMENTO_SEC;
			if(!pObjDocumentoSEC.COD_SEC.Equals(-1)) arrParam[1].Value = pObjDocumentoSEC.COD_SEC;
			if(!pObjDocumentoSEC.ID_DOCUMENTO.Equals(-1)) arrParam[2].Value = pObjDocumentoSEC.ID_DOCUMENTO;
			if(!pObjDocumentoSEC.NOMBRE_GLOSA.Equals("")) arrParam[3].Value = pObjDocumentoSEC.NOMBRE_GLOSA;
			if(!pObjDocumentoSEC.TIPO_CREACION.Equals("")) arrParam[4].Value = pObjDocumentoSEC.TIPO_CREACION;
			if(!pObjDocumentoSEC.USUARIO_CREACION.Equals("")) arrParam[5].Value = pObjDocumentoSEC.USUARIO_CREACION;
			if(!pObjDocumentoSEC.USUARIO_CREACION.Equals("")) arrParam[5].Value = pObjDocumentoSEC.USUARIO_CREACION;
			if(pObjDocumentoSEC.CODIGO_RECIBO>0) arrParam[6].Value = pObjDocumentoSEC.CODIGO_RECIBO;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_Actualizar";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;

			long retorno;
			
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




		protected DAABRequest.Parameter[] ObtenerParametros (DocumentoSEC pObjItem)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_COD_DOCUMENTO_SEC", DbType.Int64,ParameterDirection.InputOutput),
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_GLOSA", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CREACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_CREACION", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREACION", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE_ARCHIVO", DbType.String,256,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_RECIBO", DbType.Int64,ParameterDirection.Input)		
											   };
			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			//--
			if (pObjItem != null) 
			{
				i=0; if(pObjItem.ID_DOCUMENTO_SEC>0) arrParam[i].Value = pObjItem.ID_DOCUMENTO_SEC;
				i++; if(pObjItem.COD_SEC>0) arrParam[i].Value = pObjItem.COD_SEC;
				i++; if(pObjItem.ID_DOCUMENTO>0) arrParam[i].Value = pObjItem.ID_DOCUMENTO;
				i++; if(!pObjItem.NOMBRE_GLOSA.Equals("")) arrParam[i].Value = pObjItem.NOMBRE_GLOSA;
				i++; if(!pObjItem.TIPO_CREACION.Equals("")) arrParam[i].Value = pObjItem.TIPO_CREACION;
				i++; if(pObjItem.FECHA_CREACION != System.DateTime.MinValue) arrParam[i].Value = pObjItem.FECHA_CREACION;
				i++; if(!pObjItem.USUARIO_CREACION.Equals("")) arrParam[i].Value = pObjItem.USUARIO_CREACION;
				i++; if(!pObjItem.NOMBRE_ARCHIVO.Equals("")) arrParam[i].Value = pObjItem.NOMBRE_ARCHIVO;
				i++; if(pObjItem.CODIGO_RECIBO>0) arrParam[i].Value = pObjItem.CODIGO_RECIBO;

			}
			//---
			return  arrParam;
		}
		

		public long Crear(ref DAABRequest pObjRequest, DocumentoSEC pObjItem)
		{
			return CrearActualizar(ref pObjRequest, pObjItem, (byte)TOperacionCRUD.crear);
		}

		
		public long Actualizar(ref DAABRequest pObjRequest, DocumentoSEC pObjItem)
		{
			return CrearActualizar(ref pObjRequest, pObjItem, (byte)TOperacionCRUD.actualizar);
		}

		
		public long CrearActualizar(ref DAABRequest pObjRequest, DocumentoSEC pObjItem, byte pTipoOperacion)
		{			

			long lIdDocumentoSEC= 0; //--no agregado
			bool SeCreaRequest = false;	//falg para si se crea en esta funcion el objeto Request

			//--
			if (pObjRequest == null) 
			{
				BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				pObjRequest = obj.CreaRequest();
				pObjRequest.Transactional = true;
				SeCreaRequest = true;
			}

			pObjRequest.CommandType = CommandType.StoredProcedure;
			
			if  (pTipoOperacion == (byte)TOperacionCRUD.crear) 
				pObjRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_Insertar";
			else if (pTipoOperacion == (byte)TOperacionCRUD.actualizar) 
				pObjRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_Actualizar";
			
			//---establecer parametros
			pObjRequest.Parameters.Clear(); 
			pObjRequest.Parameters.AddRange(ObtenerParametros(pObjItem));
		
			try
			{
				pObjRequest.Factory.ExecuteNonQuery(ref pObjRequest);
				
				if (SeCreaRequest)
					pObjRequest.Factory.CommitTransaction();

				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)pObjRequest.Parameters[0];
				lIdDocumentoSEC = Funciones.CheckInt64(parSalida1.Value);
			}
			catch( Exception ex )
			{
				if (SeCreaRequest)
					pObjRequest.Factory.RollBackTransaction();

				throw ex;
			}
			finally
			{		
				if (SeCreaRequest)
					pObjRequest.Factory.Dispose();
			}	
			//--
			return lIdDocumentoSEC;
		}

		public int Eliminar(ref DAABRequest pObjRequest, long pCodSEC, long pCodigoRecibo)
		{			

			int pEliminados = 0;
			bool SeCreaRequest = false;	//flag para si se crea en esta funcion el objeto Request

			//--
			if (pObjRequest == null) 
			{
				BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				pObjRequest = obj.CreaRequest();
				pObjRequest.Transactional = true;
				SeCreaRequest = true;
			}

			pObjRequest.CommandType = CommandType.StoredProcedure;
			
			pObjRequest.Command=BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_Eliminar_SEC_Rec";
			
			//---establecer parametros
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_RECIBO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ELIMINADO", DbType.Int32,ParameterDirection.Output)		
											   };
			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			i=0; if(pCodSEC>0) arrParam[i].Value =pCodSEC;
			i++; if(pCodigoRecibo>0) arrParam[i].Value = pCodigoRecibo;
			
			pObjRequest.Parameters.Clear(); 
			pObjRequest.Parameters.AddRange(arrParam);
		
			//---
			try
			{
				pObjRequest.Factory.ExecuteNonQuery(ref pObjRequest);
				
				if (SeCreaRequest)
					pObjRequest.Factory.CommitTransaction();

				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)pObjRequest.Parameters[2];
				pEliminados = Funciones.CheckInt(parSalida1.Value);
			}
			catch( Exception ex )
			{
				if (SeCreaRequest)
					pObjRequest.Factory.RollBackTransaction();

				throw ex;
			}
			finally
			{		
				if (SeCreaRequest)
					pObjRequest.Factory.Dispose();
			}	
			//--
			return pEliminados;
		}

		public long Eliminar(long pIdDocumentoSEC)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_ID_DOCUMENTO_SEC", DbType.Int64,ParameterDirection.InputOutput)
											   }; 

			arrParam[0].Value = DBNull.Value;
			if(!pIdDocumentoSEC.Equals(-1)) arrParam[0].Value = pIdDocumentoSEC;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_Eliminar";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;

			long retorno;
			
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

#endregion


		/// <summary>
		/// Obtiene la Lista los Analistas de Creditos y Activaciones por Area, desde la BD
		/// </summary>
		/// <param name="pCodArea">Código de Área</param>
		/// <returns>Lista de Analistas</returns>
		public ArrayList listaAnalistasCyA_p_Rederivar(string pLoginUsuarioDerivador)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_LOGIN_DERIVADOR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OUT", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if (pLoginUsuarioDerivador.Length>0)
				arrParam[0].Value = pLoginUsuarioDerivador;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".ANALISTAS_CYA_Lista_X_Derivad";
			obRequest.Parameters.AddRange(arrParam);
						
			ArrayList salida = new ArrayList();
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				ItemGenerico item = null;
				while(dr.Read())
				{
					item = new ItemGenerico();
					item.Codigo  = Funciones.CheckStr(dr["CYA_USERNT"]); 
					item.Descripcion = Funciones.CheckStr(dr["CYA_NOMCOM"]); 
					
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


		public ArrayList listaAnalistasCyA()
		{			
			DAABRequest.Parameter[] arrParam = {
												new DAABRequest.Parameter("P_OUT", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".ListaAnalistasCyA";
			obRequest.Parameters.AddRange(arrParam);
						
			ArrayList salida = new ArrayList();
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				ItemGenerico item = null;
				while(dr.Read())
				{
					item = new ItemGenerico();
					item.Codigo  = Funciones.CheckStr(dr["CYA_USERNT"]); 
					item.Descripcion = Funciones.CheckStr(dr["CYA_NOMCOM"].ToString()); 
					
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

		
		public ArrayList listaAnalistasCyAPorArea(string codarea)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_AREA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OUT", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;


			arrParam[0].Value = codarea;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".ListaAnalistasCyAPorArea";
			obRequest.Parameters.AddRange(arrParam);
						
			ArrayList salida = new ArrayList();
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				ItemGenerico item = null;
				while(dr.Read())
				{
					item = new ItemGenerico();
					item.Codigo  = Funciones.CheckStr(dr["CYA_USERNT"]); 
					item.Descripcion = Funciones.CheckStr(dr["CYA_NOMCOM"].ToString()); 
					
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

		
		public bool EnviarACreditosActivaciones(long pCOD_SEC, string pCodEstadoNuevo, string pLoginUsuario)
		{
			
			bool SeEnvio = false; //--
			long iResultado=0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.Transactional = true;			

			try
			{	
				//---cierra acuerdos de la sec
				AcuerdoDatos objAcuerdos = new AcuerdoDatos();
				objAcuerdos.Cerrar_X_SEC(ref objRequest,pCOD_SEC); 	

				iResultado = objAcuerdos.ActualizarEstadoSEC(ref objRequest,pCOD_SEC, pCodEstadoNuevo, pLoginUsuario);
				

				objAcuerdos = null;

				SeEnvio = (iResultado>0);

				//--
				objRequest.Factory.CommitTransaction();

			}
			catch (Exception ex)
			{
				objRequest.Factory.RollBackTransaction();

				throw ex;
			}
			finally
			{	
				objRequest.Factory.Dispose();
			}	
			//--
			return SeEnvio;
 
		}
		//T12646				
				
			public int SubsanaDocumento(DocumentoSEC pObjDocumentoSEC) 
			{
				DAABRequest.Parameter[] arrParam = {   
													   new DAABRequest.Parameter("P_COD_DOCUMENTO_SEC", DbType.Int64,ParameterDirection.InputOutput),
													   new DAABRequest.Parameter("P_COD_SEC", DbType.Int64,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_ID_DOCUMENTO", DbType.Int32,ParameterDirection.Input),
													   new DAABRequest.Parameter("P_NOMBRE_ARCHIVO", DbType.String,ParameterDirection.Input)
				}; 

	
				int intCont=0;
				for ( intCont=0; intCont<arrParam.Length;intCont++)
					arrParam[intCont].Value = DBNull.Value;
		
				if(!pObjDocumentoSEC.ID_DOCUMENTO_SEC.Equals(-1)) arrParam[0].Value = pObjDocumentoSEC.ID_DOCUMENTO_SEC; 
				if(!pObjDocumentoSEC.COD_SEC.Equals(-1)) arrParam[1].Value = pObjDocumentoSEC.COD_SEC;
				if(!pObjDocumentoSEC.ID_DOCUMENTO.Equals(-1)) arrParam[2].Value = pObjDocumentoSEC.ID_DOCUMENTO;
				if(!pObjDocumentoSEC.NOMBRE_ARCHIVO.Equals("")) arrParam[3].Value = pObjDocumentoSEC.NOMBRE_ARCHIVO;
			
				BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				DAABRequest obRequest = obj.CreaRequest();
				obRequest.CommandType = CommandType.StoredProcedure;
				obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".DOCUMENTO_SEC_Subsanar";
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

		
		public bool paraCorreccionPDV(int codsec)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_COD_SEC", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OUT", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codsec;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EVALUACION_SEC + ".ListarSubFlagObservado";
			obRequest.Parameters.AddRange(arrParam);			
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				

				if(dr.Read())
				{
					if(Funciones.CheckStr(dr["correccion_pdv"])=="1")
					{
						return true;
					}
				}
				return false;
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
		}


	}
}
