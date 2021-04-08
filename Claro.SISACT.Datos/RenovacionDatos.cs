using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Configuration; 

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for RenovacionDatos.
	/// </summary>
	public class RenovacionDatos
	{
		public RenovacionDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public ArrayList ListarTipoOperacion()
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)}; 
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_RENOVACION + ".SP_CON_TIPO_OPERACION";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					oItem.Tipo = Funciones.CheckStr(dr["DOCC_CODIGO"]);
					oItem.Codigo2 = Funciones.CheckStr(dr["TOPEN_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["TOPEV_DESCRIPCION"]);
					filas.Add(oItem);
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

		public ArrayList ListarTipoOferta(string strTipoDocumento)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
                
			arrParam[0].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_RENOVACION + ".SP_CON_TIPO_OFERTA";
                
			obRequest.Parameters.AddRange(arrParam);
                
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["TOFC_CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["TOFV_DESCRIPCION"]);

					if (strTipoDocumento != System.Configuration.ConfigurationSettings.AppSettings["TipoDocumentoRUC"].ToString()) 
					{
						filas.Add(oItem);
					}
					else
					{
						if (oItem.Codigo != System.Configuration.ConfigurationSettings.AppSettings["constCodTipoProductoB2E"].ToString())
							filas.Add(oItem);
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
			return filas;
		}
	}
}
