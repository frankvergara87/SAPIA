using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de Servicio3PlayDatos.
	/// </summary>
	public class Servicio3PlayDatos
	{
		public Servicio3PlayDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ArrayList ListarServicio3Play()
		{
			Servicio3Play oServicio3Play = null;
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_CON_SERV_3PLAY";
			oDAABRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = oDAABRequest.Factory.ExecuteReader(ref oDAABRequest).ReturnDataReader;		
				while(dr.Read())
				{
					oServicio3Play = new Servicio3Play();
					oServicio3Play.SERVV_CODIGO=Funciones.CheckStr(dr["SERVV_CODIGO"]);
					oServicio3Play.SERVV_DESCRIPCION=Funciones.CheckStr(dr["SERVV_DESCRIPCION"]);
					oServicio3Play.GSRVC_PADRE=Funciones.CheckStr(dr["GSRVC_PADRE"]);
					oServicio3Play.GSRVV_DESCRIPCION=Funciones.CheckStr(dr["GSRVV_DESCRIPCION"]);
					filas.Add(oServicio3Play);
				}
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				if (dr != null && dr.IsClosed==false ) dr.Close();
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return filas;
		}


	
		public DataTable ListarServicio3PlayTabla(string P_PLNV_CODIGO)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = P_PLNV_CODIGO;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_SERVICIO_3PLAY";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return dtResultado;
		}


	}
}
