using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for ConsultaDWH.
	/// </summary>
	public class ConsultaDWH
	{
		public ConsultaDWH()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public ArrayList LineasAbonado(string p_tipo_documento, string p_nro_documento)
		{			
			//me lista Documentoes segun el codigo de evaluacion
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("v_tipo_doc", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_nro_doc", DbType.String,200,ParameterDirection.Input),				
												   new DAABRequest.Parameter("p_cursor", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("v_resultado", DbType.String, 100, ParameterDirection.Output),
												   new DAABRequest.Parameter("v_msg_error", DbType.String, 100, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = p_tipo_documento;
			arrParam[1].Value = p_nro_documento;

			BDDWH obj = new BDDWH(BaseDatos.BD_DWH);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_DWH_ABONADOS_CLARO + ".sp_lista_abonado_recupero";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList salida = new ArrayList();
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					LineaAbonado objLineaAbonado = new LineaAbonado();

					objLineaAbonado.Nro_telefono = Funciones.CheckStr(dr["NRO_TELEFONO"]);
					objLineaAbonado.Tipo_documento = Funciones.CheckStr(dr["TIPO_DOCUMENTO"]);
					objLineaAbonado.Nro_documento = Funciones.CheckStr(dr["NRO_DOCUMENTO"]);                    
					objLineaAbonado.Nombres = Funciones.CheckStr(dr["NOMBRES"]);
					objLineaAbonado.Apellidos = Funciones.CheckStr(dr["APELLIDOS"]);
					objLineaAbonado.Fecha_activacion = Funciones.CheckStr(dr["FECHA_ACTIVACION"]);
					objLineaAbonado.Plan_tarifario = Funciones.CheckStr(dr["PLAN_TARIFARIO"]);
					objLineaAbonado.Segmento = Funciones.CheckStr(dr["SEGMENTO"]);
					objLineaAbonado.Estado = Funciones.CheckStr(dr["ESTADO"]);
					objLineaAbonado.Create_date = Funciones.CheckStr(dr["CREATE_DATE"]);

					salida.Add(objLineaAbonado);
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
			return salida;
		}
	}
}
