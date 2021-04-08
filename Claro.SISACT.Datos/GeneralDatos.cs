using System;
using System.Data;
using System.Collections;
using System.Configuration; 
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	public class GeneralDatos
	{		
		public GeneralDatos(){}

		public ArrayList ListarTipoDocumentoCliente()
		{		
			return ListarItems(BaseDatos.BD_CLARIFY,BaseDatos.NOMBRE_PACKAGE_CUSTOMER_CLFY + ".SP_CUSTOMER_DOC_TYPE","RESULT","TIPO_DOC","TIPO_DOC");
		}
		
		public ArrayList ListarNacionalidad()
		{				
			return ListarItems(BaseDatos.BD_CLARIFY,BaseDatos.NOMBRE_PACKAGE_CUSTOMER_CLFY + ".SP_BIRTHPLACE","RESULT","NACIONALIDAD","NACIONALIDAD");
		}
		public ArrayList ListarItems(string vNombreApp, string vNombreSP,string vParametroSalida,string vValueMember,string vDisplayMember )
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter(vParametroSalida, DbType.Object, ParameterDirection.Output)}; 
			Clarify objClarify = new Clarify(vNombreApp);
			DAABRequest obRequest = objClarify.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = vNombreSP; 
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lista = new ArrayList();
			IDataReader dr=null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr[vValueMember]);
					item.Descripcion = Funciones.CheckStr(dr[vDisplayMember]);
					lista.Add(item);					
				}			
			}
			catch(Exception e){throw e;}
			finally
			{
				if(dr != null)
					dr.Close();
				obRequest.Factory.Dispose();
			}
			return lista;
		}

		public ArrayList ListarTipoDocumento()
		{
			DAABRequest.Parameter[] arrParam = { 
				new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
			};

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_DOCUMENTO";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			TipoDocumento objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new TipoDocumento();
					objItem.ID_SISACT = Funciones.CheckStr(dr["DOCC_CODIGO"]) == AppSettings.Key_codigoDocPasaporte08 ? AppSettings.Key_codigoDocPasaporte07 : Funciones.CheckStr(dr["DOCC_CODIGO"]); /*PROY-31636 - RENTESEG*/
					objItem.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["DOCV_DESCRIPCION"]);
					objItem.ID_BSCS = Funciones.CheckInt(dr["DOCC_COD_BSCS"]);
					objItem.COD_SGA = Funciones.CheckStr(dr["DOCC_COD_SGA"]);
					objItem.ID_DC_CORP = Funciones.CheckStr(dr["DOCC_COD_DC"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarParametroGeneral(string strCodigo)
		{
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("P_CODIGO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)                                                                        
			};
			arrParam[0].Value = strCodigo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PARAM_GENERAL";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["PCONI_CODIGO"]);
					objItem.Descripcion = Funciones.CheckStr(dr["PCONV_DESCRIPCION"]);
					//objItem.Valor = Funciones.CheckStr(dr["PCONV_VALOR"]); PENDIENTE LUIS
					objItem.Valor2 = Funciones.CheckStr(dr["PCONV_VALOR"]); //JAZ
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public string ListaPrefijosApellidoCompuesto()
		{
			DAABRequest.Parameter[] arrParam = { 
				new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
			};

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_LIST_PREFIJO_APELLIDO";
			objRequest.Parameters.AddRange(arrParam);

			string cadTokens = "";
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					if (cadTokens.Length == 0) cadTokens = cadTokens + Funciones.CheckStr(dr["PREFIJOAP"]);
					else cadTokens = cadTokens + "," + Funciones.CheckStr(dr["PREFIJOAP"]);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Factory.Dispose();
			}
			return cadTokens;
		}

		public ArrayList ListarTipoCuota()
		{
			DAABRequest.Parameter[] arrParam = { 
				new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
			};

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_CUOTA";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			Cuota objItem = null;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new Cuota();
					objItem.idCuota = Funciones.CheckStr(dr["CUOC_CODIGO"]);
					objItem.cuota = Funciones.CheckStr(dr["CUOV_DESCRIPCION"]);
					objItem.nroCuota = Funciones.CheckInt(dr["CUON_VIGENCIA"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public void ConsultarDatosDireccion(string idDepartamento, string idProvincia, string idDistrito,
			ref string strDepartamento, ref string strProvincia, ref string strDistrito)
		{
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("P_CUR_DIR", DbType.Object,ParameterDirection.Output),
				new DAABRequest.Parameter("P_DEPARTAMENTO", DbType.String, 4, ParameterDirection.Input),
				new DAABRequest.Parameter("P_PROVINCIA", DbType.String, 4, ParameterDirection.Input),
				new DAABRequest.Parameter("P_DISTRITO", DbType.String, 4, ParameterDirection.Input)
			};

			arrParam[1].Value = idDepartamento;
			arrParam[2].Value = idProvincia;
			arrParam[3].Value = idDistrito;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_CONSULTA_BRMS + ".SP_CON_DATOS_DISTRITO";
			objRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					strDepartamento = Funciones.CheckStr(dr["DEPAV_DESCRIPCION"]);
					strProvincia = Funciones.CheckStr(dr["PROVV_DESCRIPCION"]);
					strDistrito = Funciones.CheckStr(dr["DISTV_DESCRIPCION"]);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
		}

		public ArrayList ListarPlazoAcuerdo(string strCasoEspecial)
		{
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
			};
			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			if (!(Funciones.CheckStr(strCasoEspecial)=="")) { arrParam[0].Value = strCasoEspecial; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PLAZO_ACUERDO";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem = null;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["PLZAC_CODIGO"]);
					objItem.Descripcion = Funciones.CheckStr(dr["PLZAV_DESCRIPCION"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarProducto()
		{
			DAABRequest.Parameter[] arrParam = { 
				new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output) 
			};

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_PRODUCTO";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["PRDC_CODIGO"]);
					objItem.Descripcion = Funciones.CheckStr(dr["PRDV_DESCRIPCION"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ListarTipoGarantia(string strTipoGarantia, string strEstado)
		{
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("P_TCARC_CODIGO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_TCARC_ESTADO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
			};
			int i;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			i = 0; if (!(Funciones.CheckStr(strTipoGarantia)=="")) { arrParam[i].Value = strTipoGarantia; }
			i++; if (!(Funciones.CheckStr(strEstado)=="")) { arrParam[i].Value = strEstado; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_CON_TIPO_GARANTIA";
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["TCARC_CODIGO"]);
					objItem.Descripcion = Funciones.CheckStr(dr["TCARV_DESCRIPCION"]);
					objItem.estado = Funciones.CheckStr(dr["TCARC_ESTADO"]);
					objLista.Add(objItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

	}
}
