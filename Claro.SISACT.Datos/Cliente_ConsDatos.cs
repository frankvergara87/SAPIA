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
	/// Descripción breve de Cliente_ConsDatos.
	/// </summary>
	public class Cliente_ConsDatos
	{
		public Cliente_ConsDatos()
		{
		}
		
		public ArrayList BuscarClienteCompletoDes(string strFlagBuscar ,string strCondicion, int inttipodoc)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_FLAG_BUSCAR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONDICION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("CUR_Cliente", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("CUR_Cliente2", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("CUR_Cliente3", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("CUR_Cliente4", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strFlagBuscar;
			arrParam[1].Value = strCondicion;
			arrParam[2].Value = inttipodoc;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			
			obRequest.Command = BaseDatos.PKG_BSCS_CONSULTA_CONS + ".BUSCAR_CLIENTE_COMPLETO";
			
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lisRetorno= new ArrayList();
			DataSet ds=new DataSet(); 
			try
			{
				ds= obRequest.Factory.ExecuteDataset(ref obRequest);
				foreach(DataTable ItemTabla in ds.Tables)
				{
					ArrayList arraTabla= new ArrayList();
					foreach(DataRow dr in ItemTabla.Rows )
					{
						Cliente_Cons objDatoCliente_Cons=new Cliente_Cons();
						foreach(DataColumn dc in ItemTabla.Columns)
						{ 
							//APLICAMOS Reflection para el llenado de los campos disponibles en la clase
							MemberInfo[] objMiembro=objDatoCliente_Cons.GetType().GetMember(dc.ColumnName); // Nos aseguramos que el campo exista como Miembro de la clase
							if (objMiembro.Length>0) 
							{
								PropertyInfo objpropiedad =objDatoCliente_Cons.GetType().GetProperty(dc.ColumnName);
								if (dr[dc.ColumnName]!=DBNull.Value) //Revisamos que el contenido del campo tenga un valor 
								{
									Object objDatoNuevo;
									switch (objpropiedad.PropertyType.ToString())
									{
										case "System.Int64": objDatoNuevo=Convert.ToInt64(dr[dc.ColumnName]);
											break;
										case "System.String": objDatoNuevo=Convert.ToString(dr[dc.ColumnName]);
											break;
										case "System.Double": objDatoNuevo=Convert.ToDouble(dr[dc.ColumnName]);
											break;
										default: objDatoNuevo=Convert.ToInt16(dr[dc.ColumnName]);
											break;
									}
									objpropiedad.SetValue(objDatoCliente_Cons,objDatoNuevo,null);
								}
							}
							else
							{
								//Punto que identifica los miembros inexistentes: Aqui se debe implementar en caso sea necesario un error controlado para el mantenimiento.
								
							}
						}
						arraTabla.Add(objDatoCliente_Cons);
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



		public ArrayList BuscarClienteDeudaBloqueo(string strFlagBuscar ,string strCondicion, int inttipodoc)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_FLAG_BUSCAR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONDICION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int16,ParameterDirection.Input),
												   new DAABRequest.Parameter("CUR_TELEFONO", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strFlagBuscar;
			arrParam[1].Value = strCondicion;
			arrParam[2].Value = inttipodoc;

			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			
			obRequest.Command = BaseDatos.PKG_BSCS_CONSULTA_CONS + ".SP_BUSCAR_CLIENTE_SEC";
			
			obRequest.Parameters.AddRange(arrParam);
			ArrayList lisRetorno= new ArrayList();
			DataSet ds=new DataSet();
			try
			{
				ds= obRequest.Factory.ExecuteDataset(ref obRequest);
				foreach(DataTable ItemTabla in ds.Tables)
				{
					ArrayList arraTabla= new ArrayList();
					foreach(DataRow dr in ItemTabla.Rows )
					{
						Cliente_Cons objDatoCliente_Cons=new Cliente_Cons();
						foreach(DataColumn dc in ItemTabla.Columns)
						{
							//APLICAMOS Reflection para el llenado de los campos disponibles en la clase
							MemberInfo[] objMiembro=objDatoCliente_Cons.GetType().GetMember(dc.ColumnName); // Nos aseguramos que el campo exista como Miembro de la clase
							if (objMiembro.Length>0) 
							{
								PropertyInfo objpropiedad =objDatoCliente_Cons.GetType().GetProperty(dc.ColumnName);
								if (dr[dc.ColumnName]!=DBNull.Value) //Revisamos que el contenido del campo tenga un valor 
								{
									Object objDatoNuevo;
									switch (objpropiedad.PropertyType.ToString())
									{
										case "System.Int64": objDatoNuevo=Convert.ToInt64(dr[dc.ColumnName]);
											break;
										case "System.String": objDatoNuevo=Convert.ToString(dr[dc.ColumnName]);
											break;
										case "System.Double": objDatoNuevo=Convert.ToDouble(dr[dc.ColumnName]);
											break;
										default: objDatoNuevo=Convert.ToInt16(dr[dc.ColumnName]);
											break;
									}
									objpropiedad.SetValue(objDatoCliente_Cons,objDatoNuevo,null);
								}
							}
							else
							{
								//Punto que identifica los miembros inexistentes: Aqui se debe implementar en caso sea necesario un error controlado para el mantenimiento.
								
							}
						}
						arraTabla.Add(objDatoCliente_Cons);
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
