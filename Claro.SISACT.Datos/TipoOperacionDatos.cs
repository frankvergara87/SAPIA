using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for TipoRiesgoDatos.
	/// </summary>
	public class TipoOperacionDatos
	{
		public TipoOperacionDatos()
		{
			
		}

		public ArrayList ListarTipoOperacion(int tipoOperacion, string tipoProducto)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("k_tip_operacion", DbType.Int32,ParameterDirection.Input),
												new DAABRequest.Parameter("k_tip_producto", DbType.String,ParameterDirection.Input),
												new DAABRequest.Parameter("k_estado", DbType.String,ParameterDirection.Input),
												new DAABRequest.Parameter("k_cur_salida", DbType.Object,ParameterDirection.Output)}; 
			
			arrParam[0].Value = tipoOperacion;
			arrParam[1].Value = tipoProducto;
			arrParam[2].Value = "A";
			arrParam[3].Value = DBNull.Value;;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SECP_MAESTROS + ".SECSS_CON_TIPO_OPERACION";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["TOPEN_CODIGO"]);
					item.Codigo2 = Funciones.CheckStr(dr["TPROC_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["TOPEV_DESCRIPCION"]);
					item.Descripcion2 = Funciones.CheckStr(dr["TOPEC_ESTADO"]);
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

	}
}
