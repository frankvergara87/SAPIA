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
	/// Descripción breve de ClienteDatos.
	/// </summary>
	public class ClienteDatos
	{
		public ClienteDatos()
		{
		}
		public Cliente ObtenerCliente(string vPHONE,string vACCOUNT,string vCONTACTOBJID_1,string vFLAG_REG,ref  string vFLAG_CONSULTA,ref string vMSG_TEXT)
		{

			if (vCONTACTOBJID_1 == "")
				vCONTACTOBJID_1 = null;			
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_PHONE", DbType.String,20,vPHONE,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ACCOUNT", DbType.String,80,vACCOUNT,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTACTOBJID_1", DbType.Int64,vCONTACTOBJID_1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_REG", DbType.String,20,vFLAG_REG,ParameterDirection.Input),												
												   new DAABRequest.Parameter("P_FLAG_CONSULTA", DbType.String,255,vFLAG_CONSULTA,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSG_TEXT", DbType.String,255,vMSG_TEXT,ParameterDirection.Output),
												   new DAABRequest.Parameter("CUSTOMER", DbType.Object, ParameterDirection.Output)
											   }; 
			

			Clarify objClarify = new Clarify(BaseDatos.BD_CLARIFY);
			DAABRequest obRequest = objClarify.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_CUSTOMER_CLFY + ".SP_CUSTOMER_CLFY"; 
			string[] sTab = {"Resultado"}; 
			obRequest.TableNames = sTab; 
			obRequest.Parameters.AddRange(arrParam);
			Cliente item = new Cliente();
			DataTable dt = new DataTable();
			try
			{
				dt = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
				if( dt.Rows.Count>0)
				{								
					item = MapearTablaToCliente(dt.Rows[0]);					
				}
			}
			catch(Exception e){throw e;}
			finally
			{				
				obRequest.Factory.Dispose();
			}
			return item;
		}	
		private Cliente MapearTablaToCliente(DataRow dr)
		{
			Cliente item = new Cliente();
			item.OBJID_CONTACTO = Funciones.CheckStr(dr["OBJID_CONTACTO"]);
			item.OBJID_SITE = Funciones.CheckStr(dr["OBJID_SITE"]);
			item.TELEFONO = Funciones.CheckStr(dr["TELEFONO"]);
			item.CUENTA = Funciones.CheckStr(dr["CUENTA"]);
			item.MODALIDAD = Funciones.CheckStr(dr["MODALIDAD"]);
			item.SEGMENTO = Funciones.CheckStr(dr["SEGMENTO"]);
			item.ROL_CONTACTO = Funciones.CheckStr(dr["ROL_CONTACTO"]);
			item.ESTADO_CONTACTO = Funciones.CheckStr(dr["ESTADO_CONTACTO"]);
			item.ESTADO_CONTRATO = Funciones.CheckStr(dr["ESTADO_CONTRATO"]);
			item.ESTADO_SITE = Funciones.CheckStr(dr["ESTADO_SITE"]);
			item.S_NOMBRES = Funciones.CheckStr(dr["S_NOMBRES"]);
			item.S_APELLIDOS = Funciones.CheckStr(dr["S_APELLIDOS"]);
			item.NOMBRES = Funciones.CheckStr(dr["NOMBRES"]);
			item.APELLIDOS = Funciones.CheckStr(dr["APELLIDOS"]);
			item.DOMICILIO = Funciones.CheckStr(dr["DOMICILIO"]);
			item.URBANIZACION = Funciones.CheckStr(dr["URBANIZACION"]);
			item.REFERENCIA = Funciones.CheckStr(dr["REFERENCIA"]);
			item.CIUDAD = Funciones.CheckStr(dr["CIUDAD"]);
			item.DISTRITO = Funciones.CheckStr(dr["DISTRITO"]);
			item.DEPARTAMENTO = Funciones.CheckStr(dr["DEPARTAMENTO"]);
			item.ZIPCODE = Funciones.CheckStr(dr["ZIPCODE"]);
			item.EMAIL = Funciones.CheckStr(dr["EMAIL"]);
			item.TELEF_REFERENCIA = Funciones.CheckStr(dr["TELEF_REFERENCIA"]);
			item.FAX = Funciones.CheckStr(dr["FAX"]);
			DateTime fecha = new DateTime(1,1,1);
			if (dr["FECHA_NAC"] != DBNull.Value)
				if (Funciones.CheckDate( dr["FECHA_NAC"]) != fecha )
					item.FECHA_NAC = Funciones.CheckDate(dr["FECHA_NAC"]).ToShortDateString();
			item.SEXO = Funciones.CheckStr(dr["SEXO"]);
			item.ESTADO_CIVIL = Funciones.CheckStr(dr["ESTADO_CIVIL"]);
			item.TIPO_DOC = Funciones.CheckStr(dr["TIPO_DOC"]);
			item.NRO_DOC = Funciones.CheckStr(dr["NRO_DOC"]);
			item.FECHA_ACT = Funciones.CheckDate(dr["FECHA_ACT"]);
			item.PUNTO_VENTA = Funciones.CheckStr(dr["PUNTO_VENTA"]);
			item.FLAG_REGISTRADO = Funciones.CheckInt(dr["FLAG_REGISTRADO"]);
			item.OCUPACION = Funciones.CheckStr(dr["OCUPACION"]);
			item.CANT_REG = Funciones.CheckStr(dr["CANT_REG"]);
			item.FLAG_EMAIL = Funciones.CheckStr(dr["FLAG_EMAIL"]);			
			item.MOTIVO_REGISTRO= Funciones.CheckStr(dr["MOTIVO_REGISTRO"]);
			item.FUNCION = Funciones.CheckStr(dr["FUNCION"]);
			item.CARGO = Funciones.CheckStr(dr["CARGO"]);
			item.LUGAR_NACIMIENTO_DES = Funciones.CheckStr(dr["LUGAR_NAC"]);
			return item;
		}
	
		//INI PROY 31636 RENTESEG
		public bool ClienteNacionalidad_Actualizar(string strClienteNacionalidad)
		{
			string [] objClienteNacionalidad = strClienteNacionalidad.Split(';');
			bool blnResultado = false;
			DAABRequest.Parameter[] arrParam ={
												  new DAABRequest.Parameter("V_CLIEC_TIPO_DOCUMENTO",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CLIEV_NRO_DOCUMENTO",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CLIEC_CODNACION",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CLIEV_DESNACION",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CLIEV_USUARIO_CREA",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("RESULTADO",DbType.Int32,ParameterDirection.Output)
											  };
			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}
			int j = 0;
			arrParam[j].Value = objClienteNacionalidad[0];
			j++; arrParam[j].Value = objClienteNacionalidad[1];
			j++; arrParam[j].Value = objClienteNacionalidad[2];
			j++; arrParam[j].Value = objClienteNacionalidad[3];
			j++; arrParam[j].Value = objClienteNacionalidad[4];

			BDSISACT objDBSisact = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = objDBSisact.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + ".SISACTSU_CLIE_NACIONALIDAD";//APUNTAR AL SP CREADO
			objRequest.Parameters.AddRange(arrParam);
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				blnResultado = (Funciones.CheckInt(((IDataParameter)objRequest.Parameters[5]).Value) == 0) ? true : false; ;
			}
			catch (Exception ex)
			{
				blnResultado = false;
				throw ex;
			}
			finally
			{
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return blnResultado;
		}
		//FIN PROY 31636 RENTESEG
	}
}
