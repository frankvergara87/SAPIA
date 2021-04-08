using System;
using System.Configuration;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for DataCreditoDatos.
	/// </summary>
	public class DataCreditoDatos
	{
		public DataCreditoDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool ConsultaDataCreditoRepositorioLocal(DataCreditoIN oDataCreditoIN, ref DataCreditoOUT ObjDataCreditoLocalOUT, ref string mensajeError, string tipoSEC, ref int iParametro)
		{	
			bool result = false;
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_istrTipoDocumento",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_istrNumeroDocumento",DbType.String,11,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_istrApellidoPaterno",DbType.String,30,ParameterDirection.Input),												
												   new DAABRequest.Parameter("P_TipoSEC",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DiasAntiguedad",DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = oDataCreditoIN.istrTipoDocumento;
			arrParam[1].Value = oDataCreditoIN.istrNumeroDocumento;
			arrParam[2].Value = oDataCreditoIN.istrAPELLIDOPATERNO;			
			arrParam[3].Value = tipoSEC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_HISTORICO_DC + ".SISACT_LISTAR_DATOS_DC";
			obRequest.Parameters.AddRange(arrParam);
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				IDataParameter pSalidaParam;				
				pSalidaParam = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-2];
				iParametro = Funciones.CheckInt(pSalidaParam.Value);

				while(dr.Read())
				{
					ObjDataCreditoLocalOUT =  new DataCreditoOUT();
					ObjDataCreditoLocalOUT.NUMEROOPERACION = Funciones.CheckStr(dr["NUMERO_OPERACION"]);
					ObjDataCreditoLocalOUT.ACCION = Funciones.CheckStr(dr["ACCION"]);
					ObjDataCreditoLocalOUT.LIMITE_DE_CREDITO = Funciones.CheckDbl(dr["LIMITE_DE_CREDITO"]);
					ObjDataCreditoLocalOUT.LC_DISPONIBLE = Funciones.CheckDbl(dr["LC_DISPONIBLE"]);
					ObjDataCreditoLocalOUT.NV_LC_MAXIMO = Funciones.CheckDbl(dr["NV_LC_MAXIMO"]);
					ObjDataCreditoLocalOUT.NV_TOTAL_CARGOS_FIJOS = Funciones.CheckDbl(dr["NV_TOTAL_CARGOS_FIJOS"]);
					ObjDataCreditoLocalOUT.SCORE = Funciones.CheckInt(dr["SCORE"]);
					ObjDataCreditoLocalOUT.CREDIT_SCORE = Funciones.CheckStr(dr["CREDIT_SCORE"]);
					ObjDataCreditoLocalOUT.TIPO_DE_PRODUCTO = Funciones.CheckStr(dr["TIPO_DE_PRODUCTO"]);
					ObjDataCreditoLocalOUT.INGRESO_O_LC = Funciones.CheckDbl(dr["INGRESO_O_LC"]);
					ObjDataCreditoLocalOUT.TIPO_DE_CLIENTE = Funciones.CheckStr(dr["TIPO_DE_CLIENTE"]);
					ObjDataCreditoLocalOUT.TIPO_DE_TARJETA = Funciones.CheckStr(dr["TIPO_DE_TARJETA"]);
					ObjDataCreditoLocalOUT.NUMERO_DOCUMENTO = Funciones.CheckStr(dr["NUMERO_DOCUMENTO"]);
					ObjDataCreditoLocalOUT.APELLIDO_PATERNO = Funciones.CheckStr(dr["APELLIDO_PATERNO"]);
					ObjDataCreditoLocalOUT.APELLIDO_MATERNO = Funciones.CheckStr(dr["APELLIDO_MATERNO"]);
					ObjDataCreditoLocalOUT.NOMBRES = Funciones.CheckStr(dr["NOMBRES"]);
					ObjDataCreditoLocalOUT.respuesta = Funciones.CheckStr(dr["RESPUESTA"]);
					//E76009 Inicio Datacredito Fase 1
					ObjDataCreditoLocalOUT.IstrEstadoCivil = Funciones.CheckStr(dr["ISRTESTADOCIVIL"]);
					ObjDataCreditoLocalOUT.TOP_10000 = Funciones.CheckStr(dr["TOP_1000"]);
					ObjDataCreditoLocalOUT.RAZONES = Funciones.CheckStr(dr["RAZONES"]);
					ObjDataCreditoLocalOUT.ANALISIS = Funciones.CheckStr(dr["ANALISIS"]);
					ObjDataCreditoLocalOUT.SCORE_RANKIN_OPERATIVO = Funciones.CheckStr(dr["SCORE_RANKIN_OPERATIVO"]);
					ObjDataCreditoLocalOUT.NUMERO_ENTIDADES_RANKIN_OPERATIVO = Funciones.CheckStr(dr["NUM_ENT_RANKIN_OPERATIVO"]);
					ObjDataCreditoLocalOUT.PUNTAJE = Funciones.CheckStr(dr["PUNTAJE"]);
					ObjDataCreditoLocalOUT.limiteCreditoDataCredito = Funciones.CheckDbl(dr["LIMITECREDITODATACREDITO"]);
					ObjDataCreditoLocalOUT.limiteCreditoBaseExterna = Funciones.CheckDbl(dr["LIMITECREDITOBASEEXTERNA"]);
					ObjDataCreditoLocalOUT.limiteCreditoClaro = Funciones.CheckDbl(dr["LIMITECREDITOCLARO"]);
					ObjDataCreditoLocalOUT.fechanacimiento = Funciones.CheckStr(dr["FECHANACIMIENTO"]);
					//E76009 Fin Datacredito Fase 1
					ObjDataCreditoLocalOUT.CodigoBuro = Funciones.CheckStr(dr["BURO_CREDITICIO"]);
					result = true;
				}
				
			}
			catch(Exception e)
			{		
				mensajeError = "Error en la información consultada de DataCredito. Comunicarse con Créditos y Activaciones.";
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return result;
		}

		public bool GuardarDatosDataCredito(DataCreditoIN oDataCreditoIN, DataCreditoOUT oDataCreditoOUT)
		{
			Boolean resultado = false;			
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("P_istrSecuencia", DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrTipoDocumento",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrNumeroDocumento",DbType.String,11,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrApellidoPaterno",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrApellidoMaterno",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrNombres",DbType.String,40,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrTipoProducto",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrTipoCliente",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrNumOperaPVU",DbType.String,20,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrRegion",DbType.String,20,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrArea",DbType.String,20,ParameterDirection.Input),
					new DAABRequest.Parameter("P_istrPuntoVenta",DbType.String,20,ParameterDirection.Input),
					new DAABRequest.Parameter("P_NUMOPERA_EFT",DbType.String,20,ParameterDirection.Input),
					new DAABRequest.Parameter("P_NUMERO_OPERACION",DbType.String,15,ParameterDirection.Input),
					new DAABRequest.Parameter("P_ACCION",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_LIMITE_DE_CREDITO",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_LC_DISPONIBLE",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_NV_LC_MAXIMO",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_NV_TOTAL_CARGOS_FIJOS",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_SCORE",DbType.Int32,ParameterDirection.Input),
					new DAABRequest.Parameter("P_CREDIT_SCORE",DbType.String,6,ParameterDirection.Input),
					new DAABRequest.Parameter("P_TIPO_DE_PRODUCTO",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_INGRESO_O_LC",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_TIPO_DE_CLIENTE",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_TIPO_DE_TARJETA",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_NUMERO_DOCUMENTO",DbType.String,11,ParameterDirection.Input),
					new DAABRequest.Parameter("P_APELLIDO_PATERNO",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_APELLIDO_MATERNO",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_NOMBRES",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_RESPUESTA",DbType.String,10,ParameterDirection.Input),
					new DAABRequest.Parameter("P_ISRTESTADOCIVIL",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_TOP_1000",DbType.String,1,ParameterDirection.Input),
					new DAABRequest.Parameter("P_RAZONES",DbType.String,50,ParameterDirection.Input),
					new DAABRequest.Parameter("P_ANALISIS",DbType.String,10,ParameterDirection.Input),
					new DAABRequest.Parameter("P_SCORE_RANKIN_OPERATIVO",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_NUM_ENT_RANKIN_OPERATIVO",DbType.String,10,ParameterDirection.Input),
					new DAABRequest.Parameter("P_PUNTAJE",DbType.String,30,ParameterDirection.Input),
					new DAABRequest.Parameter("P_LIMITECREDITODATACREDITO",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_LIMITECREDITOBASEEXTERNA",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_LIMITECREDITOCLARO",DbType.Decimal,ParameterDirection.Input),
					new DAABRequest.Parameter("P_FECHANACIMIENTO",DbType.Date,ParameterDirection.Input),
					new DAABRequest.Parameter("P_BURO_CREDITICIO",DbType.Int16,ParameterDirection.Input),
					new DAABRequest.Parameter("P_RETORNO", DbType.Int32,ParameterDirection.Output)
				};			
		
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oDataCreditoIN.istrSecuencia;
			arrParam[1].Value = oDataCreditoIN.istrTipoDocumento;
			arrParam[2].Value = oDataCreditoIN.istrNumeroDocumento;
			arrParam[3].Value = oDataCreditoIN.istrAPELLIDOPATERNO;
			arrParam[4].Value = oDataCreditoIN.istrAPELLIDOMATERNO;
			arrParam[5].Value = oDataCreditoIN.istrNOMBRES;
			arrParam[6].Value = oDataCreditoIN.istrTIPOPRODUCTO;
			arrParam[7].Value = oDataCreditoIN.istrTIPOCLIENTE;
			arrParam[8].Value = oDataCreditoIN.istrNumOperaPVU;
			arrParam[9].Value = oDataCreditoIN.istrRegion;
			arrParam[10].Value = oDataCreditoIN.istrArea;
			arrParam[11].Value = oDataCreditoIN.istrPuntoVenta;
			arrParam[12].Value = oDataCreditoIN.ostrNumOperaEFT;
			arrParam[13].Value = oDataCreditoOUT.NUMEROOPERACION;
			arrParam[14].Value = oDataCreditoOUT.ACCION;
			arrParam[15].Value = oDataCreditoOUT.LIMITE_DE_CREDITO;
			arrParam[16].Value = oDataCreditoOUT.LC_DISPONIBLE;
			arrParam[17].Value = oDataCreditoOUT.NV_LC_MAXIMO;
			arrParam[18].Value = oDataCreditoOUT.NV_TOTAL_CARGOS_FIJOS;
			arrParam[19].Value = oDataCreditoOUT.SCORE;
			arrParam[20].Value = oDataCreditoOUT.CREDIT_SCORE;
			arrParam[21].Value = oDataCreditoOUT.TIPO_DE_PRODUCTO;
			arrParam[22].Value = oDataCreditoOUT.INGRESO_O_LC;
			arrParam[23].Value = oDataCreditoOUT.TIPO_DE_CLIENTE;
			arrParam[24].Value = oDataCreditoOUT.TIPO_DE_TARJETA;
			arrParam[25].Value = oDataCreditoOUT.NUMERO_DOCUMENTO;
			arrParam[26].Value = oDataCreditoOUT.APELLIDO_PATERNO;
			arrParam[27].Value = oDataCreditoOUT.APELLIDO_MATERNO;
			arrParam[28].Value = oDataCreditoOUT.NOMBRES;
			arrParam[29].Value = oDataCreditoOUT.respuesta;
			arrParam[30].Value = oDataCreditoIN.strEstadoCivil;
			arrParam[31].Value = oDataCreditoOUT.TOP_10000;
			arrParam[32].Value = oDataCreditoOUT.RAZONES;
			arrParam[33].Value = oDataCreditoOUT.ANALISIS;
			arrParam[34].Value = oDataCreditoOUT.SCORE_RANKIN_OPERATIVO;
			arrParam[35].Value = oDataCreditoOUT.NUMERO_ENTIDADES_RANKIN_OPERATIVO;
			arrParam[36].Value = oDataCreditoOUT.PUNTAJE;
			arrParam[37].Value = oDataCreditoOUT.limiteCreditoDataCredito;
			arrParam[38].Value = oDataCreditoOUT.limiteCreditoBaseExterna;
			arrParam[39].Value = oDataCreditoOUT.limiteCreditoClaro;
			arrParam[40].Value = oDataCreditoOUT.fechanacimiento;
			arrParam[41].Value = oDataCreditoOUT.CodigoBuro;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_HISTORICO_DC + ".SISACT_INSERTAR_DATOS_DC";
			obRequest.Parameters.AddRange(arrParam);
			int intDatoRetorno = 0;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				intDatoRetorno = Funciones.CheckInt(pSalida.Value);
				
				if (intDatoRetorno > 0)
					resultado = true;
				else
					resultado = false;
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return resultado;
		}


	}
}
