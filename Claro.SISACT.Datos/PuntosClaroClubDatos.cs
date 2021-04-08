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
	/// Summary description for PuntosClaroClubDatos.
	/// </summary>
	/// <remarks>
	/// Autor: E77568.
	/// PS - Automatización de canje y nota de crédito.
	/// </remarks>
	public class PuntosClaroClubDatos
	{
		public PuntosClaroClubDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void InsertarCanjePuntos(CanjePuntos objCanjePuntos)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_DOC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC_SAP_NC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PUNTOS_USADOS", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FACTOR_CONVERSION", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLES_DESCUENTO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_PDV", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_REG", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CANJE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_LINEA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDCAMPANA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_CCLUB", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String,ParameterDirection.Input)
											   };

			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = objCanjePuntos.TIPO_DOC;
			arrParam[1].Value = objCanjePuntos.NUM_DOC;
			arrParam[2].Value =	objCanjePuntos.NRO_DOC_SAP_NC;
			arrParam[3].Value =	objCanjePuntos.PUNTOS_USADOS;
			arrParam[4].Value =	objCanjePuntos.FACTOR_CONVERSION;
			arrParam[5].Value =	objCanjePuntos.SOLES_DESCUENTO;
			arrParam[6].Value =	objCanjePuntos.COD_PDV;
			arrParam[7].Value =	objCanjePuntos.USUARIO_REG;
			arrParam[8].Value = objCanjePuntos.FLAG_CANJE;
			arrParam[9].Value = objCanjePuntos.CAMPANA;
			arrParam[10].Value = objCanjePuntos.NRO_LINEA;
			arrParam[11].Value = objCanjePuntos.DOCUMENTO_SAP;
			if (objCanjePuntos.IDCAMPANA > -1) 
			{
				arrParam[12].Value = objCanjePuntos.IDCAMPANA;
			}
			arrParam[13].Value = objCanjePuntos.ID_CCLUB;
			arrParam[14].Value = objCanjePuntos.DESCRIPCION;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_PROCESOS + ".MANTSI_INSERT_CANJE_PUNTOS";
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
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
		}


		public void InsertarCanjePuntos2(CanjePuntos objCanjePuntos)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_DOC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC_SAP_NC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PUNTOS_USADOS", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FACTOR_CONVERSION", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLES_DESCUENTO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_PDV", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_REG", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CANJE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_LINEA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDCAMPANA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_CCLUB", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SEGMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA_VIGENCIA_INI", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA_VIGENCIA_FIN", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC_SAP_DSCTO_EQUIPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DSCTO_EQUIPO", DbType.Decimal,ParameterDirection.Input)
											   };

			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = objCanjePuntos.TIPO_DOC;
			arrParam[1].Value = objCanjePuntos.NUM_DOC;
			arrParam[2].Value =	objCanjePuntos.NRO_DOC_SAP_NC;
			arrParam[3].Value =	objCanjePuntos.PUNTOS_USADOS;
			arrParam[4].Value =	objCanjePuntos.FACTOR_CONVERSION;
			arrParam[5].Value =	objCanjePuntos.SOLES_DESCUENTO;
			arrParam[6].Value =	objCanjePuntos.COD_PDV;
			arrParam[7].Value =	objCanjePuntos.USUARIO_REG;
			arrParam[8].Value = objCanjePuntos.FLAG_CANJE;
			arrParam[9].Value = objCanjePuntos.CAMPANA;
			arrParam[10].Value = objCanjePuntos.NRO_LINEA;
			arrParam[11].Value = objCanjePuntos.DOCUMENTO_SAP;
			if (objCanjePuntos.IDCAMPANA > -1) 
			{
				arrParam[12].Value = objCanjePuntos.IDCAMPANA;
			}
			arrParam[13].Value = objCanjePuntos.ID_CCLUB;
			arrParam[14].Value = objCanjePuntos.DESCRIPCION;

			// Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos					
			arrParam[15].Value = objCanjePuntos.SEGMENTO;
			if (objCanjePuntos.CAMPANA_VIGENCIA_INI != new DateTime(1,1,1)) { arrParam[16].Value = objCanjePuntos.CAMPANA_VIGENCIA_INI; }
			if (objCanjePuntos.CAMPANA_VIGENCIA_FIN != new DateTime(1,1,1)) { arrParam[17].Value = objCanjePuntos.CAMPANA_VIGENCIA_FIN; }
			if (objCanjePuntos.DOC_SAP_DSCTO_EQUIPO != "")  
			{
				arrParam[18].Value = objCanjePuntos.DOC_SAP_DSCTO_EQUIPO;
				arrParam[19].Value = objCanjePuntos.DSCTO_EQUIPO;
			}
			// Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_PROCESOS + ".MANTSI_INSERT_CANJE_PUNTOS2";
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
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
		}


		/// <summary>
		/// Actualiza la operaciòn de canje de puntos Claro Club, cuando se efectuo el pago de la nota de crèdito.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public void ActualizarCanjePuntos(CanjePuntos objCanjePuntos)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NRO_DOC_SAP_NC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CANJE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_CANJE", DbType.String,ParameterDirection.Input)
											   };

			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = objCanjePuntos.NRO_DOC_SAP_NC;
			arrParam[1].Value = objCanjePuntos.USUARIO_CANJE;
			arrParam[2].Value =	objCanjePuntos.FLAG_CANJE;

						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_PROCESOS + ".MANTSU_UPDATE_CANJE_PUNTOS";
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
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
		}
		/// <summary>
		/// Devuelve los datos de un registro de puntos Claro Club, identificado por el nùmero de documento SAP.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public DataTable ListarCanjePuntos(string P_NRO_DOC_SAP_NC)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NRO_DOC_SAP_NC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CUR_CLAROPUNTOS_DET", DbType.Object,ParameterDirection.Output) //PROY 26366 
											   }; 
			for(int j=0; j<arrParam.Length; j++)
				arrParam[j].Value = System.DBNull.Value;

			arrParam[0].Value = P_NRO_DOC_SAP_NC;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_PROCESOS + ".MANTSS_SELECT_CANJE_PUNTOS"; 
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
		/// <summary>
		/// Elimina la operaciòn de canje de puntos Claro Club
		/// </summary>
		/// <remarks>
		/// Autor: Javier Sandoval
		/// PS - Renovacion PostPago Equipos Fase1 v6
		/// RF-04
		/// </remarks>
		public void EliminarCanjePuntos(CanjePuntos objCanjePuntos)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String,ParameterDirection.Input)
											   };

			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = objCanjePuntos.DOCUMENTO_SAP;

						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_PROCESOS + ".MANTSU_DELETE_CANJE_PUNTOS";
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
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
		}

		/// <summary>
		/// Verificar si existe una reserva de puntos, consultando al PUNTOSCC.
		/// </summary>
		/// <remarks>
		/// Autor: E77568
		/// PS - Automatización de canje y nota de crédito
		/// RF-04
		/// </remarks>
		public void ValidaBloqueoBolsa(string k_tipo_doc,
									   string k_num_doc,
									   string k_tipo_clie,
									   ref string k_tipo_doc2,
									   ref string k_estado,
									   ref double k_coderror,
									   ref string k_descerror)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_TIPO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NUM_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_TIPO_CLIE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_TIPO_DOC2", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_ESTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CODERROR", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESCERROR", DbType.String, ParameterDirection.Output)
											   }; 
			for(int j = 0; j < arrParam.Length; j++)
				arrParam[j].Value = System.DBNull.Value;

			arrParam[0].Value = k_tipo_doc;
			arrParam[1].Value = k_num_doc;
			arrParam[2].Value = k_tipo_clie;
			
			BD_PUNTOSCC obj = new BD_PUNTOSCC(BaseDatos.BD_PUNTOSCC);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CC_TRANSACCION + ".ADMPS_VALBLOQUEOBOLSA";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				

				IDataParameter parTIPO_DOC2;
				IDataParameter parESTADO;	
				IDataParameter parCODERROR;	
				IDataParameter parDESCERROR;	

				parTIPO_DOC2 = (IDataParameter)obRequest.Parameters[3];
				parESTADO = (IDataParameter)obRequest.Parameters[4];
				parCODERROR = (IDataParameter)obRequest.Parameters[5];
				parDESCERROR = (IDataParameter)obRequest.Parameters[6];

				k_tipo_doc2 = Funciones.CheckStr(parTIPO_DOC2.Value);
				k_estado = Funciones.CheckStr(parESTADO.Value);
				k_coderror = Funciones.CheckDbl(parCODERROR.Value);
				k_descerror = Funciones.CheckStr(parDESCERROR.Value);
				obRequest.Factory.Dispose();

			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				if (dr != null && dr.IsClosed == false) 
				{
					dr.Close();
				}
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		//PROY-26366 - FASE II - INICIO
		public ArrayList ListarDatosNCxDocSAP(string P_DOCUMENTO_SAP)
		{

			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
				};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = P_DOCUMENTO_SAP;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_PROCESOS + Constantes.SisactListarDatosNCxDocSAP;
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				Parametro item;

				while (dr.Read())
				{
					item = new Parametro();

					item.Codigo = Funciones.CheckInt64(dr["ID_CANJE_PUNTOS"]);
					filas.Add(item);
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return filas;
		}
 
		public bool InsertarDetaClaroPuntos(Int64 ID_CANJE_PUNTOS, string SERIE_ARTICULO, Int64 PUNTOS_USADOS, decimal SOLES_DESCUENTO, ref string CODIGO_RESPUESTA, ref string MENSAJE_RESPUESTA)
		{
			bool resultado = false;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ID_CANJE_PUNTO", DbType.Int64,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERIE_ARTICULO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PUNTOS_USADOS", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLES_DESCUENTO", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_RESPUESTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MENSAJE_RESPUESTA", DbType.String,100,ParameterDirection.Output)
											   };


			int i;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = ID_CANJE_PUNTOS;
			arrParam[1].Value = SERIE_ARTICULO;
			arrParam[2].Value = PUNTOS_USADOS;
			arrParam[3].Value = SOLES_DESCUENTO;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_PROCESOS + Constantes.SisactInsertarDetaClaroPuntos;
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				CODIGO_RESPUESTA = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[4]).Value);
				MENSAJE_RESPUESTA = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);

				if (CODIGO_RESPUESTA == "0")
				{
					resultado = true; 
				}

			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return resultado;
		}
		//PROY-26366 - FASE II - FIN		
	}
}
