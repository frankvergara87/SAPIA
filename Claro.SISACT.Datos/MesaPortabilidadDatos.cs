using System;
using System.Data;
using System.Collections;
using System.Reflection;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for MesaPortabilidadDatos.
	/// </summary>
	public class MesaPortabilidadDatos
	{
		public MesaPortabilidadDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool EnvioMPxSec(int intSec, string strUsuario)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPOV_USUARIO_CREA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA", DbType.Int32, ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = intSec;
			arrParam[1].Value = strUsuario;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_ENVIO_MP_X_SEC";
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
				//rMsg = "Error al AutoAsignarSEC. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				//sEstado = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public ArrayList ObtenerDetalleSEC(int nroSec)
		{			
			DAABRequest.Parameter[] arrParam = {	
												   new DAABRequest.Parameter("P_NRO_SEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DATOS_SEC", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_LINEAS", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_ADJUNTOS", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = nroSec;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_POOL_SP_PORT_IN_DET";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList lisRetorno = new ArrayList();
			DataSet ds=new DataSet(); 
	
			try
			{
				ds= obRequest.Factory.ExecuteDataset(ref obRequest);
				foreach(DataTable ItemTabla in ds.Tables)
				{
					ArrayList arraTabla= new ArrayList();
					foreach(DataRow dr in ItemTabla.Rows )
					{
						SolicitudPortabilidad objDatoCliente=new SolicitudPortabilidad();
						foreach(DataColumn dc in ItemTabla.Columns)
						{ 
							//APLICAMOS Reflection para el llenado de los campos disponibles en la clase
							MemberInfo[] objMiembro=objDatoCliente.GetType().GetMember(dc.ColumnName); // Nos aseguramos que el campo exista como Miembro de la clase
							if (objMiembro.Length>0) 
							{
								PropertyInfo objpropiedad =objDatoCliente.GetType().GetProperty(dc.ColumnName);
								if (dr[dc.ColumnName]!=DBNull.Value) //Revisamos que el contenido del campo tenga un valor 
								{
									Object objDatoNuevo;
									switch (objpropiedad.PropertyType.ToString())
									{
										case "System.Int64": objDatoNuevo=Convert.ToInt64(dr[dc.ColumnName]);
											break;
										case "System.Int32": objDatoNuevo=Convert.ToInt32(dr[dc.ColumnName]);
											break;
										case "System.String": objDatoNuevo=Convert.ToString(dr[dc.ColumnName]);
											break;
										case "System.Double": objDatoNuevo=Convert.ToDouble(dr[dc.ColumnName]);
											break;
										default: objDatoNuevo=Convert.ToInt16(dr[dc.ColumnName]);
											break;
									}
									objpropiedad.SetValue(objDatoCliente,objDatoNuevo,null);
								}
							}
							else
							{
								//Punto que identifica los miembros inexistentes: Aqui se debe implementar en caso sea necesario un error controlado para el mantenimiento.
								
							}
						}
						arraTabla.Add(objDatoCliente);
					}
					lisRetorno.Add(arraTabla);	
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				ds.Dispose();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return lisRetorno;
		}

	}
}
