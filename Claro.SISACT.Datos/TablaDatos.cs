using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{

	public class TablaDatos
	{
		public TablaDatos()
		{}

		public ArrayList Listar_Portal()
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   };
			int i;

			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command= BaseDatos.PCK_MANT_TABLAS  + ".MANTSS_LISTAR_PORTAL_TEMP";			
			objRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;

			ArrayList filas = new ArrayList();
			
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = dr["PTRUI_CODIGO"].ToString();
					item.Descripcion = dr["PTRUV_DESCRIPCION"].ToString();
					item.Descripcion2 = dr["PTRUV_RUTA"].ToString();
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
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return filas;
		}
	}
}
