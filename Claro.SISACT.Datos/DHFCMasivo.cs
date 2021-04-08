using System;
using System.Data;
using System.Collections;
using System.Configuration; 
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	public class DHFCMasivo
	{
		public DHFCMasivo()
		{			
		}
        
        public DataTable fdtbListarBusqueda(string pstrFechaInicio,string pstrFechaFin)
        {			
            DataTable dtResultado = new DataTable();
            DAABRequest.Parameter[] arrParam = {            
                                                   new DAABRequest.Parameter("P_FECHAINICIO", DbType.String, 11, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_FECHAFIN", DbType.String, 11, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
                                               }; 
            
            arrParam[0].Value = pstrFechaInicio;
            arrParam[1].Value = pstrFechaFin;
            arrParam[2].Value = DBNull.Value;
			
            BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
            DAABRequest objRequest = obj.CreaRequest();
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".USP_LISTAR_HFC_MASIVO";
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
	}
}
