using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for ArchivoPortabilidadDatos.
	/// </summary>
	public class ArchivoPortabilidadDatos
	{
		public ArchivoPortabilidadDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public bool InsertarArchivoPortabilidad(ArchivoPortabilidad objDetalle)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ARCH_NOMBRE" ,DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ARCH_RUTA" ,DbType.String,4000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_ESTADO" ,DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ARCH_TIPO" ,DbType.String,15,ParameterDirection.Input)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = objDetalle.SOLIN_CODIGO;
			arrParam[2].Value = objDetalle.ARCH_NOMBRE;
			arrParam[3].Value = objDetalle.ARCH_RUTA;
			arrParam[4].Value = objDetalle.FLAG_ESTADO;
			arrParam[5].Value = objDetalle.ARCH_TIPO;

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_INSERT_ARCHIVO";
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

				throw ex;
			}
			finally
			{					
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


	}
}
