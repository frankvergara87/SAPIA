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
	/// Summary description for RestriccionPdvDataAccess.
	/// </summary>
	public class RestriccionPdvDataAccess
	{
		public RestriccionPdvDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataTable fdtbListarTipoOficina()
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".MANTSS_LISTAR_TIPO_OFIC";
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

		public ArrayList ListarPDV(string pstrCanales, string pstrCodigo, string pstrDescripcion)
		{
			DataTable dtResultado = new DataTable();
			ArrayList ListaPdv=new ArrayList();
			PuntoVenta oPuntoVenta;//=new PuntoVenta();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CANALES", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 40, ParameterDirection.Input)													
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCanales;
			arrParam[2].Value = pstrCodigo;
			arrParam[3].Value = pstrDescripcion;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_PLAN_TARIFARIO + ".MANTSS_LISTAR_PDV_TOTAL";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
				foreach(DataRow dr  in dtResultado.Rows)
				{
					oPuntoVenta=new PuntoVenta();
					oPuntoVenta.OVENC_CODIGO=Funciones.CheckStr(dr["OVENC_CODIGO"]);
					oPuntoVenta.OVENV_DESCRIPCION=Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					oPuntoVenta.CANAC_CODIGO=Funciones.CheckStr(dr["CANAC_CODIGO"]);
					ListaPdv.Add(oPuntoVenta);
				}

			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return ListaPdv;
		}
	}
}
