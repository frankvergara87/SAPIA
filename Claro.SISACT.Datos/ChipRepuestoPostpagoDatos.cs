using System;
using System.Data;
using Claro.SisAct.DAAB;
using Claro.SisAct.Common;
using System.Collections;
using Claro.SisAct.Entidades;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de ChipRepuestoPostpagoDatos.
	/// </summary>
	public class ChipRepuestoPostpagoDatos
	{
		public ChipRepuestoPostpagoDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public DataSet ListaServicios(int codID, ref string codPlan, ref string desPlan)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_co_id", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tmcode", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_tmdes", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_cursor", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("v_errnum", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("v_errmsj", DbType.String,ParameterDirection.Output)
												   
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codID;
			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SP_LISTA_SERVICIOS; 
			obRequest.Parameters.AddRange(arrParam);
			
			
			DataSet ds = null;

			try
			{
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);

				IDataParameter pSalida1;
				IDataParameter pSalida2;
				pSalida1 = (IDataParameter)obRequest.Parameters[1];
				codPlan = Funciones.CheckStr(pSalida1.Value);
				
				pSalida2 = (IDataParameter)obRequest.Parameters[2];
				desPlan = Funciones.CheckStr(pSalida2.Value);
				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return ds;
		}

		public ArrayList ListaDepartamentos()
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Object,ParameterDirection.Output)
											   }; 
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_LIST_DEP_REPOSICION";
			obRequest.Parameters.AddRange(arrParam);			
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Departamento item = new Departamento();
					item.DEPAC_CODIGO= Funciones.CheckStr(dr["DEPAC_CODIGO"]);
					item.DEPAV_DESCRIPCION= Funciones.CheckStr(dr["DEPAV_DESCRIPCION"]);
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

		public ArrayList ListaProvincias(string codDep)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DEPAC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codDep;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_LIST_PROV_REPOSICION";
			obRequest.Parameters.AddRange(arrParam);			
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Provincia item = new Provincia();
					item.PROVC_CODIGO= Funciones.CheckStr(dr["PROVC_CODIGO"]);
					item.PROVV_DESCRIPCION= Funciones.CheckStr(dr["PROVV_DESCRIPCION"]);
					item.DEPAC_CODIGO= Funciones.CheckStr(dr["DEPAC_CODIGO"]);
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


		public ArrayList ListaDistritos(string codDep, string codProv)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DEPAC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROVC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codDep;
			arrParam[1].Value = codProv;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_LIST_DIST_REPOSICION";
			obRequest.Parameters.AddRange(arrParam);			
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Distrito item = new Distrito();
					item.DISTC_CODIGO= Funciones.CheckStr(dr["DISTC_CODIGO"]);
					item.DISTV_DESCRIPCION= Funciones.CheckStr(dr["DISTV_DESCRIPCION"]);
					item.DEPAC_CODIGO= Funciones.CheckStr(dr["DEPAC_CODIGO"]);
					item.PROVC_CODIGO= Funciones.CheckStr(dr["PROVC_CODIGO"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}


		public bool GrabarVentaReposicion(VentaReposicionPost oVentaReposicionPost, ref string rMsg)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_REPO_DOC_SAP", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_NRO_CONT", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_NRO_PED", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_TIP_OFI", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_OFICINA", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_COD_VEN", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_TIP_DOC_CLIEN", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_NRO_DOC", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_NRO_TELEF", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_NOM_CLIEN", DbType.String,80,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_APE_CLIEN", DbType.String,80,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_REP_LEGAL", DbType.String,80,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_RAZ_SOCIAL", DbType.String,80,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_TIP_VENTA", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_TIP_OPER", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_SERIE", DbType.String,18,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_COD_MAT", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_COD_CAMP", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_LIST_PREC", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_PLAN_TARIF", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_COSTO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_USUARIO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_DEPAC_CODIGO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_PROVC_CODIGO", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_DISTC_CODIGO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPO_EST_REPOS", DbType.String,2,ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; arrParam[i].Value = oVentaReposicionPost.repo_doc_sap;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_nro_cont;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_nro_ped;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_tip_ofi;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_oficina;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_cod_ven;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_tip_doc_clien;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_nro_doc;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_nro_telef;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_nom_clien;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_ape_clien;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_rep_legal;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_raz_social;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_tip_venta;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_tip_oper;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_serie;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_cod_mat;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_cod_camp;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_list_prec;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_plan_tarif;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_costo;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_usuario;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_depac_codigo;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_provc_codigo;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_distc_codigo;
			i++; arrParam[i].Value = oVentaReposicionPost.repo_est_repos;

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_INSERT_VENTA_REPO_POST";
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
				rMsg = "Error al Insertar la venta reposición. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		//****************************************** INICIO WHZR ********************************************//

		public int ValidarPlanesLTG4G(string pstrNumLinea, ref string strMSG)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_MSISDN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_PROD", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSGERR", DbType.String, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrNumLinea;

			int retorno = 0;
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.TIM150_VAL_SALE_4G; 
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[1];				
				retorno = Funciones.CheckInt(parRetorno.Value);

				parRetorno = (IDataParameter)obRequest.Parameters[2];
				strMSG = Funciones.CheckStr(parRetorno.Value);
			}
			catch( Exception ex )
			{				
				retorno = 0;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();

			}			
			return retorno;
		}


		//****************************************** FIN WHZR    ********************************************//
	}
}
