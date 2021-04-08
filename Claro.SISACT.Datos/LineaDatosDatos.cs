using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.DAAB;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	public class LineaDatosDatos
	{	
		public LineaDatosDatos()
		{
		
		}

		public ArrayList obtieneDatosDolMMS(string msisdn, ref string strMensaje)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_MSISDN", DbType.String,20,msisdn,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String,20,null,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOCUMENTO", DbType.String ,30,null,ParameterDirection.Input ),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)};
					
			BDDOL  obj = new BDDOL(BaseDatos.BD_SIAC);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_PROCESO_DOL + ".SP_CONSULTA_REG_IMAGEN";
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lista = new ArrayList();
			IDataReader dr=null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					DolMMS item = new DolMMS();
					item.CodRegistro = Funciones.CheckStr(dr["CODIGO_REGISTRO"]);
					item.Msisdn = Funciones.CheckStr(dr["MSISDN"]);
					item.TipoDocumento = Funciones.CheckStr(dr["TIPO_DOCUMENTO"]);
					item.NumDocumento= Funciones.CheckStr(dr["NUMERO_DOCUMENTO"]);
					item.CodUsuario = Funciones.CheckStr(dr["CODIGO_USUARIO"]);
					item.CodOficina = Funciones.CheckStr(dr["CODIGO_OFICINA"]);
					item.FecRegistro = Funciones.CheckDate(dr["FECHA_REGISTRO"]);
					item.UrlArchivo = Funciones.CheckStr(dr["RUTA_ARCHIVO"]);
					item.CodSistema = Funciones.CheckStr(dr["SISTEMA"]);
					item.Estado = Funciones.CheckStr(dr["ESTADO"]);
					item.FlgDummy = Funciones.CheckStr(dr["FLAG_DUMMY"]);
					item.FecNac = Funciones.CheckStr(dr["FECHA_NACIMIENTO"]);
					lista.Add(item);
				}
			}
			catch(Exception ex)
			{
				strMensaje = ex.Message.ToString();
			}
			finally
			{
				if(dr != null)
					dr.Close();
				obRequest.Factory.Dispose();
			}

			return lista;
		}
	
		public void registrarDOL(string MSISDN, string TipoDocumento, string NumDocumento, 
			string Usuario, string Oficina, string Ruta, string Sistema,
			string Estado, string FlagDummy, string FechaNac, ref string strMensaje)
		{
			
			DAABRequest.Parameter[] arrParam = { 
												   new DAAB.DAABRequest.Parameter("P_MSISDN", DbType.String, 15, MSISDN, ParameterDirection.Input), 
												   new DAAB.DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, 2, TipoDocumento, ParameterDirection.Input), 
												   new DAAB.DAABRequest.Parameter("P_NUMERO_DOCUMENTO", DbType.String, 12, NumDocumento, ParameterDirection.Input), 
												   new DAAB.DAABRequest.Parameter("P_USUARIO", DbType.String, 15, Usuario, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("P_OFICINA", DbType.String, 4, Oficina, ParameterDirection.Input), 
												   new DAAB.DAABRequest.Parameter("P_RUTA", DbType.String, 200, Ruta, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("P_SISTEMA", DbType.String, 2, Sistema, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("P_ESTADO", DbType.String, 1, Estado, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("P_FLAG_DUMMY", DbType.String, 1, FlagDummy, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("P_FECHA_NACIMIENTO", DbType.String, 8, FechaNac, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("P_CODIGO_REGISTRO", DbType.Int64, ParameterDirection.Output),
												   new DAAB.DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)};
					
			BDDOL  obj = new BDDOL(BaseDatos.BD_SIAC);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_PROCESO_DOL + ".SP_INSERT_IMAGEN";
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lista = new ArrayList();
			IDataReader dr=null;

			int resultado;

			try
			{				
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida1, parSalida2;
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-2];
				parSalida2 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				

				resultado = Funciones.CheckInt(parSalida1.Value );

				if(resultado==1)
					strMensaje = Funciones.CheckStr(parSalida2.Value);
			}
			catch(Exception ex)
			{
				//resultado = 0;
				strMensaje = ex.Message.ToString();
			}
			finally
			{
				if(dr != null)
					dr.Close();
				obRequest.Factory.Dispose();
			}

			//return resultado;
		}

		public void cambiaEstadoDolMMS(int codRegistro, string msisdn, string estado)
		{
			bool salida = true;		
			string cod = codRegistro.ToString() ;
			DAABRequest.Parameter[] arrParam = {   new DAAB.DAABRequest.Parameter("P_CODIGO_REGISTRO", DbType.Int64, 9, cod.Equals("0") ? null : cod, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("P_MSISDN", DbType.String, 15, msisdn, ParameterDirection.Input), 
												   new DAAB.DAABRequest.Parameter("P_ESTADO", DbType.String, 1, estado, ParameterDirection.Input),												   
												   new DAAB.DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)};
					
			BDDOL  obj = new BDDOL(BaseDatos.BD_SIAC);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_PROCESO_DOL + ".SP_UPDATE_ESTADO";
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lista = new ArrayList();
			IDataReader dr=null;

			int resultado;

			try
			{				
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				
				resultado = Funciones.CheckInt(parSalida1.Value );
				
				if(resultado!=0)
				{
					salida = false;
				}
			}
			catch(Exception)
			{
				salida = false;
			}
			finally
			{
				if(dr != null)
					dr.Close();
				obRequest.Factory.Dispose();
			}
		}
		
		public int registrarPeriodoRenovaciones(string linea, string fecha, string clase)
		{
			DAABRequest.Parameter[] arrParam = { 
												new DAAB.DAABRequest.Parameter("P_LINEA", DbType.String, 20, linea, ParameterDirection.Input),
												new DAAB.DAABRequest.Parameter("P_FECHA", DbType.String, 10, fecha, ParameterDirection.Input), 
												new DAAB.DAABRequest.Parameter("P_CLASE", DbType.String, 10, clase, ParameterDirection.Input), 
												new DAAB.DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)};

			BDSISACT  obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANT_PLN + ".SISACT_LISTA_RENOVACIONES_INS";
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lista = new ArrayList();
			int resultado;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				resultado = Funciones.CheckInt(parSalida1.Value );

			}
			catch (Exception)
			{
				resultado = 0;
				//strMensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}

			return resultado;
		}
		
		public int consultarPeriodoRenovaciones(string linea)
		{
			DAABRequest.Parameter[] arrParam = { 
												   new DAAB.DAABRequest.Parameter("P_LINEA", DbType.String, 20, linea, ParameterDirection.Input),
												   new DAAB.DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)};

			BDSISACT  obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANT_PLN + ".SISACT_LISTA_RENOVACIONES_SEL";
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lista = new ArrayList();
			int resultado;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				resultado = Funciones.CheckInt(parSalida1.Value );
			}
			catch (Exception)
			{
				resultado = 0;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}

			return resultado;
		}


	}
}
