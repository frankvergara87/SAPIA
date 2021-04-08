using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.DAAB;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for DAConsulta.
	/// </summary>
	public class DAConsulta
	{
		public DAConsulta()
		{			
		}

		public ArrayList ConsultaVendedor(string codOficina, out int result)
		{
			result = 0;
			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PDV_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEND_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULT", DbType.Int32, ParameterDirection.Output),												
												   new DAABRequest.Parameter("P_LISTADO", DbType.Object, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = codOficina;
			arrParam[1].Value = "1";
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + ".SISACT_VENDEDORES_SAP_CONS";
			obRequest.Parameters.AddRange(arrParam);			
			
			HelperLog.CrearArchivolog("LOG_ListarVendedor","obRequest.Command : " + BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + Constantes.MSSapConsultaVendedor,"","","");
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;		

			try
			{
//				IDataParameter pSalida;
//				pSalida = (IDataParameter)obRequest.Parameters[2];
//				result = Funciones.CheckInt(pSalida.Value);
				//DataTable dtbLista;

				//dtbLista = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0].Rows[0];		

				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Vendedor item = new Vendedor();
					item.VendedorId = Funciones.CheckInt64(dr["VEND_CODIGO"]);
					item.Nombre = Funciones.CheckStr(dr["VEND_NOMBRE"]);
					filas.Add(item);
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return filas;
		}


		public DataSet ConsultaClaseDocumentoOficina(string tipOficina, out int result)
		{
			DataSet ds = new DataSet();

			result = 0;
			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("P_TOFIC_CODIGO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_DOCU_ESTADO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_RESULT", DbType.Int32, ParameterDirection.Output),                                                
					new DAABRequest.Parameter("P_LISTADO", DbType.Object, ParameterDirection.Output)
				};

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}

			arrParam[0].Value = tipOficina;HelperLog.CrearArchivolog("LOG_ListaClaPedOfi",arrParam[0].Value.ToString(),"","","");
			arrParam[1].Value = 1;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + Constantes.MSSapConsultaClasePedidoOficina;
			
			HelperLog.CrearArchivolog("LOG_ListaClaPedOfi","obRequest.Command : " + BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + Constantes.MSSapConsultaClasePedidoOficina,"","","");

			obRequest.Parameters.AddRange(arrParam);
			
//			ArrayList filas = new ArrayList();
//			IDataReader dr = null;

			try
			{
				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[2];
				result = Funciones.CheckInt(pSalida.Value);
//
//				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
//				while(dr.Read())
//				{
//					BETipoDocOficina item = new BETipoDocOficina();
//					item.CodDoc = Funciones.CheckStr(dr["DOCU_CODIGO"]);
//					item.DesDoc = Funciones.CheckStr(dr["DOCU_DESCRIP"]);
//					item.ClasDoc = Funciones.CheckStr(dr["DOCU_CLASE"]);
//					filas.Add(item);
//				}

				//dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
//				if (dr != null && dr.IsClosed == false)
//					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return ds;
		}


		public ArrayList ConsultaListaPrecios( string codProducto, string codTipoVenta, string codCanal, string departamento, string codMaterial, string codCampania, int codTipOperacion ,string codPlazo, string plan )
		{
			DAABRequest.Parameter[] arrParam = 
				{   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_DEPARTAMENTO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_MATEC_CODIGO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_CAMPC_CODIGO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_TOPEC_CODIGO", DbType.Int64, ParameterDirection.Input),                                                  
					new DAABRequest.Parameter("P_PLAZC_CODIGO", DbType.String, ParameterDirection.Input),
                    new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, ParameterDirection.Input),                            
					new DAABRequest.Parameter("K_SALIDA", DbType.Object, ParameterDirection.Output) };
			int i = 0;

			for (i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;     

			arrParam[0].Value = codProducto;
			arrParam[1].Value = codTipoVenta;
			arrParam[2].Value = codCanal;
			arrParam[3].Value = departamento;
			arrParam[4].Value = codMaterial;
			arrParam[5].Value = codCampania;
			arrParam[6].Value = codTipOperacion;
			arrParam[7].Value = codPlazo;
			arrParam[8].Value = plan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;			
			obRequest.Command = BaseDatos.SISACT_PKG_NUEVA_LISTAPRECIOS + Constantes.MSSapConsListaPrecios; 
			obRequest.Parameters.AddRange(arrParam);

			
			ArrayList filas = new ArrayList();
			//ArrayList filas = new BEArticulo();
			
			IDataReader dr = null;  
			try
			{                   
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while (dr.Read())
					{
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["LIPRN_CODIGOLISTAPRECIO"]);
						item.Descripcion = Funciones.CheckStr(dr["LIPRV_DESCRIPCION"]);						
						item.PrecioVenta_Out = Funciones.CheckDecimal(dr["MATED_PRECIOVENTA"]);
						item.seguro_descto = Funciones.CheckStr(dr["LIPRC_DSTO_SEGURO"]);
						//Inicio Servicios Adicionales Roaming
						item.Codigo2 = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
						//Fin Servicios Adicionales Roaming
						filas.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
	
	
		public ArrayList ConsultaServiciosXPlan(string sTipProducto,string sPlanCodigo)
		{
			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String, ParameterDirection.Input),					                                                 
					new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output) };
			int i = 0;
			for (i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;     
			
			arrParam[0].Value = sTipProducto;			
			arrParam[1].Value = sPlanCodigo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + Constantes.MSSapConsPlanServicio; 
			obRequest.Parameters.AddRange(arrParam);

			
			ArrayList filas = new ArrayList();
			//ArrayList filas = new BEServPlan();
			
			IDataReader dr = null;  
			try
			{                   
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while (dr.Read())
					{
						Servicio_AP item = new Servicio_AP();
						item.SERVV_CODIGO = Funciones.CheckStr(dr["SERVV_CODIGO"]);
						item.SERVV_DESCRIPCION = Funciones.CheckStr(dr["SERVV_DESCRIPCION"]);
						item.CARGO_FIJO_BASE = Funciones.CheckDbl(dr["PSRVN_CARGO_FIJO"]);
						item.GSRVC_CODIGO = Funciones.CheckStr(dr["GSRVC_CODIGO"]);
						item.SELECCIONABLE_BASE = Funciones.CheckStr(dr["PSRVV_SELECCIONABLE"]);
						item.SERVN_ORDEN = Funciones.CheckInt(dr["SERVN_ORDEN"]);
						
						filas.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
	
		
	
	
//		public void ConsultaCierreCajaPVU(string pFecha,string pUsuario, string poficina, out string CierreReal)
//		{
//			DAABRequest.Parameter[] arrParam = 
//				{
//					new DAABRequest.Parameter("P_FECHA", DbType.String, ParameterDirection.Input),
//					new DAABRequest.Parameter("P_USUARIO", DbType.String, ParameterDirection.Input),	
//				    new DAABRequest.Parameter("P_OFICINA", DbType.String, ParameterDirection.Input),                                             
//					new DAABRequest.Parameter("C_DATOS", DbType.Object, ParameterDirection.Output) };
//			int i = 0;
//			for (i=0; i < arrParam.Length; i++)
//				arrParam[i].Value = DBNull.Value;     
//			
//			arrParam[0].Value = pFecha;			
//			arrParam[1].Value = pUsuario;
//			arrParam[2].Value = poficina;
//
//			BDSICAR obj = new BDSICAR(BaseDatos.BD_SICAR);
//			DAABRequest obRequest = obj.CreaRequest();
//			obRequest.CommandType = CommandType.StoredProcedure;			
//			obRequest.Command = BaseDatos.PCK_SICAR_OFF_SAP + ".MIG_ObtenerCajaAsignada"; 
//			obRequest.Parameters.AddRange(arrParam);
//			CierreReal = "";
//			ItemGenerico item = new ItemGenerico();
//			IDataReader dr = null;  
//			try
//			{                   
//				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
//				if (dr != null)
//				{
//					while (dr.Read())
//					{
//						item.Codigo = Funciones.CheckStr(dr["CAJA_CERRADA"]);
//					}
//					CierreReal =item.Codigo;
//				}
//			}
//			catch (Exception ex)
//			{
//				throw (ex);
//			}
//			finally
//			{
//				if (dr != null && dr.IsClosed == false)
//					dr.Close();
//				obRequest.Parameters.Clear();
//				obRequest.Factory.Dispose();
//			}
//		}

		public ArrayList ConsultaEquiposAlternativos()
		{
			DAABRequest.Parameter[] arrParam = 
				{                          
					new DAABRequest.Parameter("P_RESULT_SET", DbType.Object, ParameterDirection.Output) };

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;			
			obRequest.Command = BaseDatos.PKG_MATERIAL_LISTA + ".SSAPSS_MATERIAL_LISTA_T"; 
			obRequest.Parameters.AddRange(arrParam);

			
			ArrayList filas = new ArrayList();
			
			IDataReader dr = null;  
			try
			{                   
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while (dr.Read())
					{
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
						item.Descripcion = Funciones.CheckStr(dr["MATEV_DESCMATERIAL"]);
						filas.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
 
		//PROY-24724-IDEA-28174 - INICIO
		public void ConsultarPrecioListaPrepago(string strCodMaterial,Int64 strCodListaPrecioPrepago, ref double dblP_PRECIOPREPAGO, ref string strMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_MATERIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LISTAPRECIO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIOPREPAGO", DbType.Double, ParameterDirection.Output)
											   };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strCodMaterial;
			arrParam[1].Value = strCodListaPrecioPrepago;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_PKG_NUEVA_LISTAPRE_6 + ".SISACTSI_PRECIO_PREPAGO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[2];
				dblP_PRECIOPREPAGO = Funciones.CheckDbl(pSalida.Value);
				strMsg = "Consulta Satisfactoria";

			}
			catch (Exception e)
			{
				strMsg = "Consulta Fallida: " + e.Message.ToString();

			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}
      //PROY-24724-IDEA-28174 - FIN
		//gaa20170327
		public string ObtenerBuroDescripcion(string strBuroCodigo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_BURO_COD", DbType.Int32, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_BURO_DES", DbType.String, ParameterDirection.Output)
											   };
			arrParam[0].Value = strBuroCodigo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2_ + ".SISACT_BUROCREDITICIO_DES";
			objRequest.Parameters.AddRange(arrParam);

			string strBuroDescripcion = string.Empty;
			try
			{
				objRequest.Factory.ExecuteScalar(ref objRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[1];
				strBuroDescripcion = Funciones.CheckStr(parSalida1.Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return strBuroDescripcion;
		}
		//fin gaa20170327
	}
}
