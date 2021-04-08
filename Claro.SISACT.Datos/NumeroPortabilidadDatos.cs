using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for PlanDetalleConsDatos.
	/// </summary>
	public class NumeroPortabilidadDatos
	{
		public NumeroPortabilidadDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ConsultarNumeroPortabilidad(string strNumeroPortabilidad)
		{			
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_NUMERO", DbType.String,11,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEC", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!strNumeroPortabilidad.Equals("")) arrParam[0].Value = strNumeroPortabilidad;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_VERIFICAR_NUMERO";
			obRequest.Parameters.AddRange(arrParam);
						
			string sec = "";
			IDataReader dr = null;
			
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{							
					sec = Funciones.CheckStr(dr["SEC"]);
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
			return sec;
		}


		public bool InsertarNumeroPortabilidad(NumeroPortabilidad objDetalle)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_NUM_DOC" ,DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_CODIGO" ,DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_NUMERO" ,DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_MODALIDAD" ,DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_ESTADO" ,DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PORT_USU_CREA" ,DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOPLN_CODIGO" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPE_CONSUMO" ,DbType.Int64,ParameterDirection.Input)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = objDetalle.SOLIN_CODIGO;
			arrParam[2].Value = objDetalle.PORT_NUM_DOC;
			arrParam[3].Value = objDetalle.PLANC_CODIGO;
			arrParam[4].Value = objDetalle.PORT_NUMERO;
			arrParam[5].Value = objDetalle.PORT_MODALIDAD;
			arrParam[6].Value = objDetalle.FLAG_ESTADO;
			arrParam[7].Value = objDetalle.TPROC_CODIGO;
			arrParam[8].Value = objDetalle.PORT_USU_CREA;
			if (objDetalle.SOPLN_CODIGO!=0) arrParam[9].Value = objDetalle.SOPLN_CODIGO;
			arrParam[10].Value = objDetalle.SOPLN_TOPE_CONSUMO;

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_INSERT_NUMERO";
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

		public bool ValidarListaNumerosPortabilidad(ArrayList listaTelefonos, ref ArrayList lineasAptas, ref ArrayList lineasNoAptas, ref string strMensajeError)
		{
			bool response = true;
			int loop = (listaTelefonos.Count / 100) + 1;

			for (int j = 0; j < loop; j++) 
			{
				string strListaTelefonos = "";
				int inicio = j * 100;
				int fin = (j + 1) * 100;
				for (int k = inicio; k < fin; k++) 
				{
					if (k == listaTelefonos.Count) { break; }
					NumeroPortabilidad numTmp = (NumeroPortabilidad)listaTelefonos[k];
					strListaTelefonos += "," + numTmp.PORT_NUMERO;
				}
				if (strListaTelefonos.Length > 0)
				{
					strListaTelefonos = strListaTelefonos.Substring(1);
					response = response & ConsultarListaNumerosPortabilidad(strListaTelefonos, ref lineasAptas, ref lineasNoAptas);
				}
				
			}
			if (!response) 
			{
				string strListaTelefonosNoAptos = "";
				for (int k=0; k<lineasNoAptas.Count; k++) 
				{
					NumeroPortabilidad numTmp = (NumeroPortabilidad)lineasNoAptas[k];
					if (strListaTelefonosNoAptos.IndexOf(numTmp.PORT_NUMERO) == -1 ) 
					{
						strListaTelefonosNoAptos += "," + numTmp.PORT_NUMERO;
					}
				}
				strListaTelefonosNoAptos = strListaTelefonosNoAptos.Substring(1);
				strMensajeError = "Error. Número(s) a Portar: " + strListaTelefonosNoAptos + " ya se encuentra(n) en Proceso de Portabilidad.";
			}
			return response;
		}

		private bool ConsultarListaNumerosPortabilidad(string strListaTelefonos, ref ArrayList lineasAptas, ref ArrayList lineasNoAptas)
		{
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_NUMEROS", DbType.String, 1500, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   };
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			if(strListaTelefonos != "") arrParam[0].Value = strListaTelefonos;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_VERIFICAR_NUMERO_MASIVO";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				strListaTelefonos = "," + strListaTelefonos;
				while(dr.Read())
				{
					string sec = Funciones.CheckStr(dr["SEC"]);
					string numeroTelefono = Funciones.CheckStr(dr["PORT_NUMERO"]);

					NumeroPortabilidad item =  new NumeroPortabilidad();
					item.PORT_NUMERO = numeroTelefono;
					item.MENSAJE_ERROR = "El número ingresado ya se encuentra en Proceso de Portabilidad. SEC: " + sec;
					lineasNoAptas.Add(item);

					strListaTelefonos = strListaTelefonos.Replace("," + numeroTelefono, "");

				}
				string[] arrayTmp = strListaTelefonos.Split(Convert.ToChar(","));
				for (int x = 1; x < arrayTmp.Length; x++)
				{
					if (arrayTmp[x] != "")
					{
						string numeroTelefono = arrayTmp[x];

						//T12618 - Validación de código nacional de números - INICIO
						if (numeroTelefono.Length==9)
						{
							NumeroPortabilidad item =  new NumeroPortabilidad();
							item.PORT_NUMERO = numeroTelefono;
							item.MENSAJE_ERROR = Funciones.ObtenerResultadoTelefono("0");
							lineasAptas.Add(item);
						}
						else
						{
							NumeroPortabilidad item =  new NumeroPortabilidad();
							item.PORT_NUMERO = numeroTelefono;
							item.MENSAJE_ERROR = "Error en formato del número.";
							lineasNoAptas.Add(item);
						}
						//T12618 - Validación de código nacional de números - FIN
					}
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
			return (lineasNoAptas.Count == 0);
		}



	}
}
