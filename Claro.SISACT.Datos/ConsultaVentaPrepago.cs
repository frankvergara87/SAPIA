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
	/// Descripción breve de ConsultaVentaPrepago.
	/// </summary>
	public class ConsultaVentaPrepago
	{
		public ConsultaVentaPrepago()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}


		public ArrayList Lis_Lista_Linea_Material(string strCodigoIccid, out string strCodigoResp)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ICCID", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULT", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_LISTADO", DbType.Object,ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strCodigoIccid;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_VENTA_PREPAGO + ".SISACTS_CON_CHIP";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();


			IDataReader dr = null;
			try
			{
				int contador = 0;
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while (dr.Read())
				{
					contador = contador + 1;
					DetalleLineaMaterial item = new DetalleLineaMaterial();

					item.LINEA = Funciones.CheckStr(dr[0]);
					item.COD_MATERIAL_CHIP = Funciones.CheckStr(dr[1]);
					item.DES_MATERIAL_CHIP = Funciones.CheckStr(dr[2]);

					filas.Add(item);

				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{


				IDataParameter parCodigoResp;
				parCodigoResp = (IDataParameter)obRequest.Parameters[1];
				strCodigoResp = Funciones.CheckStr(parCodigoResp.Value);   


				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;



		}


	}
}
