using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for SolicitudDC_HistoricoDatos.
	/// </summary>
	public class SolicitudDC_HistoricoDatos
	{
		public SolicitudDC_HistoricoDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Renovacion
		public void Actualizar_DC_Historico(string numOperacion, string validarCliente)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_NUM_OPERACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VALIDAR_CLIENTE", DbType.String,ParameterDirection.Input)
											   }; 
			int intCont=0;
			for ( intCont=0; intCont<arrParam.Length;intCont++)
				arrParam[intCont].Value = DBNull.Value;
			
			if(!numOperacion.Equals("")) arrParam[0].Value = numOperacion;
			if(!validarCliente.Equals("")) arrParam[1].Value = validarCliente;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_UPD_VALIDAR_NOMBRES";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{
				obRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
		}

		public void Insertar_DC_Historico(VistaSolicitudDC_Historico vista)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_HISTV_NUM_OPERACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTC_TIPO_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTV_NUM_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTV_APELLIDO_PAT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTV_APELLIDO_MAT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTV_NOMBRE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTC_TIPO_RESPUESTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTC_TIPO_RIESGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTN_CANT_INTENTOS", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTV_OVEN_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTV_TERMINAL_ID", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HISTN_USUARIO_REG", DbType.String,ParameterDirection.Input)
											   }; 
			int intCont=0;
			for ( intCont=0; intCont<arrParam.Length;intCont++)
				arrParam[intCont].Value = DBNull.Value;
			
			if(!vista.HISTV_NUM_OPERACION.Equals("")) arrParam[0].Value = vista.HISTV_NUM_OPERACION;
			if(!vista.HISTC_TIPO_DOCUMENTO.Equals("")) arrParam[1].Value = vista.HISTC_TIPO_DOCUMENTO;
			if(!vista.HISTV_NUM_DOCUMENTO.Equals("")) arrParam[2].Value = vista.HISTV_NUM_DOCUMENTO;
			if(!vista.HISTV_APELLIDO_PAT.Equals("")) arrParam[3].Value = vista.HISTV_APELLIDO_PAT;
			if(!vista.HISTV_APELLIDO_MAT.Equals("")) arrParam[4].Value = vista.HISTV_APELLIDO_MAT;
			if(!vista.HISTV_NOMBRE.Equals("")) arrParam[5].Value = vista.HISTV_NOMBRE;
			if(!vista.HISTC_TIPO_RESPUESTA.Equals("")) arrParam[6].Value = vista.HISTC_TIPO_RESPUESTA;
			if(!vista.HISTC_TIPO_RIESGO.Equals("")) arrParam[7].Value = vista.HISTC_TIPO_RIESGO;
			if(!vista.HISTN_CANT_INTENTOS.Equals(-1)) arrParam[8].Value = vista.HISTN_CANT_INTENTOS;
			if(!vista.HISTV_OVEN_CODIGO.Equals("")) arrParam[9].Value = vista.HISTV_OVEN_CODIGO;
			if(!vista.HISTV_TERMINAL_ID.Equals("")) arrParam[10].Value = vista.HISTV_TERMINAL_ID;
			if(!vista.HISTN_USUARIO_REG.Equals("")) arrParam[11].Value = vista.HISTN_USUARIO_REG;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_INSERTAR_HISTORICO_DC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{
				obRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
		}


	}
}
