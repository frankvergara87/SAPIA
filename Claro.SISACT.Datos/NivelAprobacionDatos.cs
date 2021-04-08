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
	/// Descripción breve de NivelAprobacion.
	/// </summary>
	public class NivelAprobacionDatos
	{
		public NivelAprobacionDatos()
		{
			
		}
		public DataTable ListarNivelesDeAprobacionXTipo(string v_tipo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("V_NAC_TIPO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("cv_1", DbType.Object,ParameterDirection.Output)
											   }; 
			for(int j=0;j<arrParam.Length;j++)
				arrParam[j].Value = System.DBNull.Value;

			arrParam[0].Value = v_tipo;
						
			//BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACTSS_NIV_APROB_X_TIPO"; //SISACT_PKG_REPO_EQUIPO
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


		public bool ActualizarNivelesDeAprobacion(int v_codigo, string v_estado, int v_cantidad, string v_usuario)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("V_NAN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_NAC_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_NAC_CANTIDAD", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_NAV_USUAC_MODI", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_VALOR_RETORNO", DbType.Int64, ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = v_codigo;
			++i; arrParam[i].Value = v_estado;
			++i; arrParam[i].Value = v_cantidad;
			++i; arrParam[i].Value = v_usuario;

			bool salida = false;
			//BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACTSU_NIV_APROB";
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
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				obRequest.Factory.Dispose();

				if(parSalida1.Value.ToString() == "0"  )
					salida = false;
				else
					salida = true;
			}			
			return salida ;
		}


		public bool ObtenerPerfilPorMonto(string v_tipo, double v_cantidad, ref string v_perfil_codigo, ref string v_perfil_descripcion)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("V_NAC_TIPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_NAC_CANTIDAD", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_NAN_PERFIL_VINCULADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("V_NAV_PERFIL_DESC", DbType.String, ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = v_tipo;
			++i; arrParam[i].Value = v_cantidad;

			bool salida = false;
			//BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACTSS_PERFIL_X_MONTO_TIPO";
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
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				IDataParameter parSalida2;
				
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-2];
				parSalida2 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				
				v_perfil_codigo = Funciones.CheckStr(parSalida1.Value);
				v_perfil_descripcion = Funciones.CheckStr(parSalida2.Value);
				
				obRequest.Factory.Dispose();

			}			
			return salida ;
		}
		public ArrayList ConsultarPerfilesMonto(string v_tipo, double v_cantidad )
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("V_NAC_TIPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_NAC_CANTIDAD", DbType.Double, ParameterDirection.Input),
													new DAABRequest.Parameter("K_PERFILES", DbType.Object, ParameterDirection.Output)
												   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = v_tipo;
			++i; arrParam[i].Value = v_cantidad;

			//BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACTSS_PERFILES_X_MONTO";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList Filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{                    
					while (dr.Read())
					{
						ItemGenerico item = new ItemGenerico();
						item.Descripcion2 = Funciones.CheckStr(dr["NAN_PERFIL_VINCULADO"]);
						item.Descripcion = Funciones.CheckStr(dr["NAV_PERFIL_DESC"]); 
						item.Monto = Funciones.CheckDbl(dr["NAC_CANTIDAD"]);
						Filas.Add(item);
					}
				}
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return Filas ;
		}
		//SD820360 
		public ArrayList ConsultarPerfilesMontoMeses(string v_tipo, double v_cantidad )
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("V_NAC_TIPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_NAC_CANTIDAD", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PERFILES", DbType.Object, ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = v_tipo;
			++i; arrParam[i].Value = v_cantidad;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.SISACT_PKG_MANT_LIMITE_AUT + ".SISACTSS_PERFILES_X_MONTO";//SD820360 
			obRequest.Parameters.AddRange(arrParam);

			ArrayList Filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{                    
					while (dr.Read())
					{
						ItemGenerico item = new ItemGenerico();
						item.Descripcion2 = Funciones.CheckStr(dr["NAN_PERFIL_VINCULADO"]);
						item.Descripcion = Funciones.CheckStr(dr["NAV_PERFIL_DESC"]); 
						item.Monto = Funciones.CheckDbl(dr["NAC_CANTIDAD"]);
						Filas.Add(item);
					}
				}
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return Filas ;
		}

		public ArrayList ListarNivelesDeAprobacionMeses(string v_tipo)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("V_NAC_TIPO", DbType.String, ParameterDirection.Input),                                                 
												   new DAABRequest.Parameter("cv_1", DbType.Object, ParameterDirection.Output)
											   };

			arrParam[0].Value = v_tipo;

			IDataReader dr = null;
			ArrayList lista = new ArrayList();
											
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT); 
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Parameters.Clear();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_MANT_LIMITE_AUT + ".SISACTSS_NIV_APROB_X_TIPO";
			obRequest.Parameters.AddRange(arrParam);
			try
			{ 
						
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				NivelAprobacion item;

				while (dr.Read())
				{
					item = new NivelAprobacion();

					item.CODIGO = Funciones.CheckStr(dr["NAN_PERFIL_VINCULADO"]);
					item.ESTADO = Funciones.CheckStr(dr["NAC_ESTADO"]);
					item.CANAL = Funciones.CheckStr(dr["NAV_PERFIL_DESC"]);
					item.DIASMINIMO = Funciones.CheckStr(dr["NAC_CANTIDAD"]);
					lista.Add(item);
				}
			}
			catch (Exception )
			{
						
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return lista;
		}

		public int InsertarActualizaDatosNivelesAprobacionXtipo(string strPerfilVin, string strTipo, string strEstado, string strPerfilDesc, string strCantidad, string strUsuario, ref string codError, ref string msgError)
		{

			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_NAN_PERFIL_VINCULADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NAC_TIPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NAC_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NAV_PERFIL_DESC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NAC_CANTIDAD", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NAV_USUAC_MODI", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_RESPUESTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MENSAJE_RESPUESTA", DbType.String,ParameterDirection.Output),
			};

			arrParam[0].Value = strPerfilVin;
			arrParam[1].Value = strTipo;
			arrParam[2].Value = strEstado;
			arrParam[3].Value = strPerfilDesc;
			arrParam[4].Value = strCantidad;
			arrParam[5].Value = strUsuario;


			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT); 
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.Parameters.Clear();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_MANT_LIMITE_AUT + ".sisactsi_niv_autorizacion";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;


			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				codError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[6]).Value);
				msgError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[7]).Value);
			}
			catch (Exception ex)
			{
				
				codError = "-9";
				msgError = "Error oracle. Consultar administrador.";
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return 0;
		}

			
		public void ObtenerCantidadMaxMinAutorizacion(ref double nCantidadMaxima, ref double nCantidadMinima)
		{
			double nCanMax = 0.0;
			double nCanMin = 0.0;

			DAABRequest.Parameter[] arrParam = {												   												   
												   new DAABRequest.Parameter("p_cantidad_max", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_cantidad_min", DbType.Int32, ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_MANT_LIMITE_AUT + ".SP_CANTMAX_MIN_AUTORIZA";
			obRequest.Parameters.AddRange(arrParam);
			
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				IDataParameter parSalida1;
				IDataParameter parSalida2;

				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				parSalida2 = (IDataParameter)obRequest.Parameters[1];				

				nCanMax = Funciones.CheckDbl(parSalida1.Value);
				nCanMin = Funciones.CheckDbl(parSalida2.Value);

				obRequest.Factory.Dispose();

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

			nCantidadMaxima = nCanMax;
			nCantidadMinima = nCanMin;

		}
		
	}
}
