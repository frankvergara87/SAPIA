using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for InteraccionDatos.
	/// </summary>
	public class InteraccionDatos
	{
		
		public InteraccionDatos()
		{
		
		}
		public ItemGenerico InsertarInteraccion(Interaccion item)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONTACTOBJID_1", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SITEOBJID_1", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ACCOUNT", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PHONE", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLASE", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUBCLASE", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_METODO_CONTACTO", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_INTER", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_AGENTE", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USR_PROCESO", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HECHO_EN_UNO", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOTAS", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CASO", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.String, 255, ParameterDirection.Input),
												   new DAABRequest.Parameter("ID_INTERACCION", DbType.String, 255, ParameterDirection.Output),				
												   new DAABRequest.Parameter("FLAG_CREACION", DbType.String, 255, ParameterDirection.Output),
												   new DAABRequest.Parameter("MSG_TEXT", DbType.String, 255, ParameterDirection.Output)			
											   }; 
			for(int j=0;j<arrParam.Length;j++)
				arrParam[j].Value = System.DBNull.Value;

			int i=0;
			if( item.OBJID_CONTACTO != null )
				arrParam[i].Value =Funciones.CheckInt64(item.OBJID_CONTACTO);// P_CONTACTOBJID_1			
			
			i++;
			if( item.OBJID_SITE != null )
				arrParam[i].Value =Funciones.CheckInt64(item.OBJID_SITE);// P_SITEOBJID_1
			
			i++;
			if( item.CUENTA != null )
				arrParam[i].Value =item.CUENTA;// P_ACCOUNT
			
			i++;			
			if( item.TELEFONO != null )
				arrParam[i].Value =item.TELEFONO;// P_PHONE
			i++;
			if( item.TIPO != null )
				arrParam[i].Value =item.TIPO;// P_TIPO
			
			i++;
			if( item.CLASE != null )
				arrParam[i].Value =item.CLASE;// P_CLASE
			
			i++;
			if( item.SUBCLASE != null )
				arrParam[i].Value =item.SUBCLASE;// P_SUBCLASE
			
			i++;
			if( item.METODO != null )
				arrParam[i].Value =item.METODO;// P_METODO_CONTACTO
			
			i++;
			if( item.TIPO_INTER != null )
				arrParam[i].Value =item.TIPO_INTER;// P_TIPO_INTER
			
			i++;
			if( item.AGENTE != null )
				arrParam[i].Value =item.AGENTE;// P_AGENTE
			
			i++;			
			if( item.USUARIO_PROCESO != null )
				arrParam[i].Value =item.USUARIO_PROCESO;// P_USR_PROCESO			
			
			i++;			
			if( item.HECHO_EN_UNO != null )				
				arrParam[i].Value = item.HECHO_EN_UNO;// P_HECHO_EN_UNO	
			
			i++;			
			if( item.NOTAS != null )
				arrParam[i].Value = item.NOTAS;// P_NOTAS
			
			i++;
			if( item.FLAG_CASO != null )
				arrParam[i].Value = item.FLAG_CASO;// P_FLAG_CASO
			
			i++;
			if( item.RESULTADO != null )
				arrParam[i].Value = item.RESULTADO;// P_RESULTADO
		
			ItemGenerico itemDatos = new ItemGenerico();
			Clarify objClarify = new Clarify(BaseDatos.BD_CLARIFY);
			DAABRequest obRequest = objClarify.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.NOMBRE_PACKAGE_INTERCCION_CLFY +  ".SP_CREATE_INTERACT";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				itemDatos.estado = Funciones.CheckStr(ex.Source);
				itemDatos.Descripcion = Funciones.CheckStr(ex.Message);
			}
			finally
			{
				IDataParameter parSalida1 ,parSalida2,parSalida3;
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-3];
				parSalida2 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-2];
				parSalida3 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				// ItemGenerico
				itemDatos.Codigo = Funciones.CheckStr(parSalida1.Value);
				itemDatos.estado = Funciones.CheckStr(parSalida2.Value);
				itemDatos.Descripcion = Funciones.CheckStr(parSalida3.Value) ;

				obRequest.Factory.Dispose();
			}
			return itemDatos;
		}
		
	}
}
