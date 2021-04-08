using System;
using System.Collections.Specialized;
using System.Text;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.DAAB;
using System.Data;
using System.Configuration;

namespace Claro.SisAct.Datos
{	
	public class DATrsMsSap
	{
		public DATrsMsSap()
		{			
		}

		public static Int64 RegistrarPedido(string CadenaCabecera, ref string codResp, ref string msgResp)
		{
			int i;
			Int64 nroPedidoMsSap = 0;
			string[] arrDBAcuerdo = CadenaCabecera.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ORGVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CANALVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_SECTOR", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOVENTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHADOCUMENTO", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_MOTIVOPEDIDO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CLASEFACTURA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESCCLASEFACTURA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESTINOMERCADERIA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CLASEPEDIDO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CODTIPOOPERACION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESCTIPOOPERACION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHAENTREGA", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_SISTEMAVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_CODVENDEDOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESTADO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ISRENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_PEDIDOALTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_UBIGEO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESQUEMACALCULO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPODOCCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NRODOCCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NOMBRECLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_PATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_MATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_NACIMIENTOCLIENTE",DbType.Date , ParameterDirection.Input),//D
												   new DAABRequest.Parameter("K_PEDIV_RAZONSOCIAL", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_CORREOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_TELEFONOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESTADOCIVILCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DIRECCIONCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_NUMEROCALLE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DISTRITOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CODDPTOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_PAISCLIENTE", DbType.String,  ParameterDirection.Input),                                                   
												   new DAABRequest.Parameter("K_PEDIC_RLTIPODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLNRODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLPATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLMATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLNOMBRE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOOFICINA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ISSISCAD", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_USUARIOCREA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHACREA", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_USUARIOMODI", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHAMODI", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIC_FLAGLP", DbType.String, ParameterDirection.Input), 
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,  ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String, ParameterDirection.Output)
											   };

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			for (i = 0; i < arrDBAcuerdo.Length; i++)
			{
				if (arrDBAcuerdo[i]!= null  &&  arrDBAcuerdo[i].Trim() != "")
				{
					if (arrParam[i].DbType== DbType.DateTime )
					{
						arrParam[i].Value = Funciones.CheckDate(arrDBAcuerdo[i]).ToLongDateString();
					}
					if (arrParam[i].DbType== DbType.Date )
					{
						arrParam[i].Value = Funciones.CheckDate(arrDBAcuerdo[i]).ToShortDateString();
					}	
					else if (arrParam[i].DbType== DbType.Decimal)
					{
						arrParam[i].Value = Funciones.CheckDecimal(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Double)
					{
						arrParam[i].Value = Funciones.CheckDbl(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Int64)
					{
						arrParam[i].Value = Funciones.CheckInt64(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Int32)
					{
						arrParam[i].Value = Funciones.CheckInt(arrDBAcuerdo[i]);
			}
					else
			{
						arrParam[i].Value = arrDBAcuerdo[i];
					}
				}
			}

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSI_PEDIDO";
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSI_PEDIDO";//dga
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter pSalida0;
				IDataParameter pSalida1;
				IDataParameter pSalida2;
				pSalida0 = (IDataParameter)obRequest.Parameters[51];
				pSalida1 = (IDataParameter)obRequest.Parameters[52];
				pSalida2 = (IDataParameter)obRequest.Parameters[53];
				nroPedidoMsSap = Funciones.CheckInt64(pSalida0.Value);
				codResp = Funciones.CheckStr(pSalida1.Value);
				msgResp = Funciones.CheckStr(pSalida2.Value);
			}
			catch (Exception ex)
			{
				codResp = "-99";
				msgResp = ex.Message.ToString();
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return nroPedidoMsSap;
		}


		public static int RegistrarPedidoDetalle(Int64 idPedido, string cadenaDetalle)
		{
			int i = 0, codResp;
			string[] arrDBAcuerdo = cadenaDetalle.Split(Convert.ToChar(";"));
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_SERIC_CODSERIE", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEC_CODMATERIAL", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_DESCMATERIAL", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_CANTIDAD", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_PRECIOVENTA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_NROTELEFONO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_NROCLARIFY", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_NRORENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_TOTALRENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_NROCUOTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_CODIGOLP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_DESCRIPCIONLP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_USUARIOCREA", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPED_FECHACREA", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_USUARIOMODI", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPED_FECHAMODI", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEC_CENTROCOSTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,300,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String,3000,ParameterDirection.Output)
				                                   
											   };


			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSI_DETALLEPEDIDO";
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSI_DETALLEPEDIDO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			for (i = 0; i < arrDBAcuerdo.Length; i++)
			{
				if (arrDBAcuerdo[i].Trim() != "")
					arrParam[i].Value = arrDBAcuerdo[i].Trim();
			}
			arrParam[0].Value = idPedido;

			if (arrDBAcuerdo[16].Trim() != "")
				arrParam[16].Value = Funciones.CheckDate(arrDBAcuerdo[16].Trim());

			if (arrDBAcuerdo[18].Trim() != "")
				arrParam[18].Value = Funciones.CheckDate(arrDBAcuerdo[18].Trim());


			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida0;
				IDataParameter pSalida1;
				pSalida0 = (IDataParameter)obRequest.Parameters[20];
				pSalida1 = (IDataParameter)obRequest.Parameters[21];
				codResp = Funciones.CheckInt(pSalida0.Value);
			}
			catch (Exception e)
			{
				obRequest.Factory.RollBackTransaction();
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return codResp;
		}


		public bool AnularPedido(Int64 p_nroPedido, string vMotivoPedido, string vEstado, string vTipOficina)
		{
			//string pestado = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["codPedidoEstadoAnular"]);
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_MOTIVOPEDIDO", DbType.String , ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOOFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String,ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			if (p_nroPedido > 0)
			{
				arrParam[0].Value = p_nroPedido;
				arrParam[1].Value = vMotivoPedido;
				arrParam[2].Value = vEstado;
				arrParam[3].Value = vTipOficina;
			}
			int codResp=99;
			bool salida = false;
			
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSU_ANULARPEDIDO";
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSU_ANULARPEDIDO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);

				IDataParameter pSalida0;
				IDataParameter pSalida1;
				pSalida0 = (IDataParameter)obRequest.Parameters[4];
				pSalida1 = (IDataParameter)obRequest.Parameters[5];
				codResp = Funciones.CheckInt(pSalida0.Value);
				
				salida = codResp==0?true:false;

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return salida;
		}

	
		public bool ActualizarPedido(Int64 pNroPedido, string vEquipos, string vPresuscrito, string vNroCarta, string vOperador, string vPublicar, string vCorreo, ref string strMensaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("NROPEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("EQUIPOS", DbType.String, 1000, ParameterDirection.Input),
												   new DAABRequest.Parameter("PRESUSCRITO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("NROCARTA", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("OPERADOR", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("PUBLICAR", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("CORREO", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("RESPUESTA", DbType.Int32, ParameterDirection.Output)
											   };

			int i;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pNroPedido;
			arrParam[1].Value = vEquipos;
			arrParam[2].Value = vPresuscrito;
			arrParam[3].Value = vNroCarta;
			arrParam[4].Value = vOperador;
			arrParam[5].Value = vPublicar;
			arrParam[6].Value = vCorreo;

			bool retorno = false;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSU_PEDIDO";
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSU_PEDIDO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[7];
				retorno = (Funciones.CheckInt(parRetorno.Value) == 1);
			}
			catch (Exception ex)
			{
				strMensaje = ex.Message.ToString();
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return retorno;
		}
		

	

		
		public bool CambiarEstadoSerie(string p_CodSerie,string p_estado, ref string strMensaje)
		{
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("K_SERIC_CODSERIE", DbType.String, ParameterDirection.Input),												   
				new DAABRequest.Parameter("K_SERIC_ESTADO", DbType.String , ParameterDirection.Input),
			};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			if (p_CodSerie != "")
			{
				arrParam[0].Value = p_CodSerie;
				arrParam[1].Value = p_estado;				
			}

			bool salida = false;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSU_ACTUALIZARESTADOSERIE";
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSU_ACTUALIZARESTADOSERIE";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);

				salida = true;
			}
			catch (Exception ex)
			{
				strMensaje = ex.Message.ToString();
				throw ex;

			}
			finally
			{

				obRequest.Factory.Dispose();
			}
			return salida;
		}


		public bool ActualizarEstadoPedido ( BEParametrosMSSAP oParamMSSAP)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_PEDIC_ESTADO", DbType.String , ParameterDirection.Input)
			};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oParamMSSAP.IdPedidoMSSAP;
			arrParam[1].Value = oParamMSSAP.EstadoPedidoMSSAP;
			
			string nroError=string.Empty, desError=string.Empty;
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP+ ".SSAPSU_ACTUALIZARPAGO";
			//obRequest.Command = BaseDatos.PkgMSSap+ ".SSAPSU_ACTUALIZARPAGO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
//				nroError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[2]).Value);
//				desError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[3]).Value);		
				nroError="0";
			}
			catch (Exception ex)
			{
				nroError="-1";
				desError = ex.Message.ToString();
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();				
			}
			return nroError=="0";			
		}

//		public void ActualizarDescuentoPedido (int pNropedido,string pCodEsquema, string pClaseCondicion, decimal pDesctMonto ,out string pNrolog,out string pDeslog )
//		{
//			DAABRequest.Parameter[] arrParam = {
//												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),												   
//												   new DAABRequest.Parameter("K_ESQUC_CODIGOESQUEMA", DbType.String, ParameterDirection.Input),
//												   new DAABRequest.Parameter("K_CLCOC_CODCLASECONDICION", DbType.String, ParameterDirection.Input),
//												   new DAABRequest.Parameter("K_DESCN_MONTO", DbType.Decimal, ParameterDirection.Input),
//												   new DAABRequest.Parameter("K_NROLOG", DbType.String , ParameterDirection.Output),
//												   new DAABRequest.Parameter("K_DESLOG", DbType.String , ParameterDirection.Output)
//												   
//											   };
//
//			for (int i = 0; i < arrParam.Length; i++)
//				arrParam[i].Value = DBNull.Value;
//
//			arrParam[0].Value = pNropedido;
//			arrParam[1].Value = pCodEsquema;
//			arrParam[2].Value = pClaseCondicion;
//			arrParam[3].Value = pDesctMonto;
//			
//			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
//			DAABRequest obRequest = obj.CreaRequest();
//			obRequest.CommandType = CommandType.StoredProcedure;
//			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSU_DESCUENTO";
//			obRequest.Parameters.AddRange(arrParam);
//			obRequest.Transactional = true;
//
//			try
//			{
//				obRequest.Factory.ExecuteNonQuery(ref obRequest);
//				obRequest.Factory.CommitTransaction();
//				IDataParameter pSalida1;
//				IDataParameter pSalida2;
//				pSalida1 = (IDataParameter)obRequest.Parameters[4];
//				pSalida2 = (IDataParameter)obRequest.Parameters[5];
//
//				pNrolog = Funciones.CheckStr(pSalida1.Value);
//				pDeslog = Funciones.CheckStr(pSalida2.Value);
//			}
//			catch (Exception ex)
//			{
//				obRequest.Factory.RollBackTransaction();
//				pNrolog="-1";
//				pDeslog = ex.Message.ToString();
//				throw ex;
//			}
//			finally
//			{
//				obRequest.Factory.Dispose();				
//			}
//		}

		public void ActualizarDescuentoPedido(int pNropedido, int pConsecutivo, string pCodEsquema, string pClaseCondicion, decimal pDesctMonto, out string pNrolog, out string pDeslog)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_DEPEN_CONSECUTIVO", DbType.Int64, ParameterDirection.Input),                                                                             
												   new DAABRequest.Parameter("K_ESQUC_CODIGOESQUEMA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CLCOC_CODCLASECONDICION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DESCN_MONTO", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String , ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String , ParameterDirection.Output)
												   
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pNropedido;
			arrParam[1].Value = pConsecutivo;
			arrParam[2].Value = pCodEsquema;
			arrParam[3].Value = pClaseCondicion;
			arrParam[4].Value = pDesctMonto;
			
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSU_DESCUENTO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter pSalida1;
				IDataParameter pSalida2;
				pSalida1 = (IDataParameter)obRequest.Parameters[5];
				pSalida2 = (IDataParameter)obRequest.Parameters[6];

				pNrolog = Funciones.CheckStr(pSalida1.Value);
				pDeslog = Funciones.CheckStr(pSalida2.Value);
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				pNrolog="-1";
				pDeslog = ex.Message.ToString();
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();				
			}
		}


		public void RecalculaEsquema (int pNropedido,int pCodConsecutivo, string pEsquemaCalcu ,out string pNrolog,out string pDeslog )
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_DEPEN_CONSECUTIVO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESQUEMACALCULO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String , ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String , ParameterDirection.Output)
												   
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pNropedido;
			arrParam[1].Value = pCodConsecutivo;
			arrParam[2].Value = pEsquemaCalcu;
			
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSU_RECALCULARESQUEMA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter pSalida1;
				IDataParameter pSalida2;
				pSalida1 = (IDataParameter)obRequest.Parameters[3];
				pSalida2 = (IDataParameter)obRequest.Parameters[4];

				pNrolog = Funciones.CheckStr(pSalida1.Value);
				pDeslog = Funciones.CheckStr(pSalida2.Value);
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				pNrolog="-1";
				pDeslog = ex.Message.ToString();
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();				
			}
		}
		public void RecalculaDescuento(int pNropedido,string pEsquemaCalcu ,out string pNrolog,out string pDeslog )
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_PEDIC_ESQUEMACALCULO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String , ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String , ParameterDirection.Output)
												   
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pNropedido;
			arrParam[1].Value = pEsquemaCalcu;
			
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSU_RECALCULARDESCUENTO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter pSalida1;
				IDataParameter pSalida2;
				pSalida1 = (IDataParameter)obRequest.Parameters[2];
				pSalida2 = (IDataParameter)obRequest.Parameters[3];

				pNrolog = Funciones.CheckStr(pSalida1.Value);
				pDeslog = Funciones.CheckStr(pSalida2.Value);
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				pNrolog="-1";
				pDeslog = ex.Message.ToString();
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();				
			}
		}


		public string ActualizaCliente(BECliente oBEClienteSAP)
		{
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("V_CLIEV_NRO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_APELLIDO_PATERNO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_APELLIDO_MATERNO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_RAZON_SOCIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIED_FECHA_NACIMIENTO", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TELEFONO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_E_MAIL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_SEXO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_ESTADO_CIVIL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_TITULO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_CARGA_FAMILIAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONYUGE_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONYUGE_APE_PAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONYUGE_APE_MAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_DIRECCION_LEGAL_PREF", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_DIRECCION_LEGAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_DIRECCION_LEGAL_REFER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_UBIGEO_LEGAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TELEF_LEGAL_PREF", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TELEF_LEGAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_DIRECCION_FACT_PREF", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_DIRECCION_FACT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_DIRECCION_FACT_REFER", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_UBIGEO_FACT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TELEF_FACT_PREF", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TELEF_FACT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_REPLEGAL_TIPO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_REPLEGAL_NRO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_REPLEGAL_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_REPLEGAL_APE_PAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_REPLEGAL_APE_MAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIED_REPLEGAL_FECHA_NAC", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_REPLEGAL_TELEFONO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_REPLEGAL_SEXO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_REPLEGAL_EST_CIV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_REPLEGAL_TITULO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_CONTACTO_TIPO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONTACTO_NRO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONTACTO_NOMBRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONTACTO_APE_PAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONTACTO_APE_MAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CONTACTO_TELEFONO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEN_COND_CLIENTE", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_EMPRESA_LABORA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_EMPRESA_CARGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_EMPRESA_TELEFONO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEN_INGRESO_BRUTO", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEN_OTROS_INGRESOS", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TCREDITO_TIPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TCREDITO_NUM", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_TCREDITO_MONEDA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEN_TCREDITO_LINEA_CRED", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEC_TCREDITO_FECHA_VENC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_OBSERVACIONES", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_CODIGO_SAP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_VENDEDOR_SAP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_USUARIO_CREA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("V_CLIEV_TIPO_CLIENTE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output) 
											   };

			for (int i1 = 0; i1 < arrParam.Length; i1++)
			{ arrParam[i1].Value = DBNull.Value; }

			DateTime fecNacimientoDEF = DateTime.Now;

			try
			{
				int i = 0;
				i = 0; arrParam[i].Value = oBEClienteSAP.Cliente; //V_CLIEV_NRO_DOCUMENTO
				i++; arrParam[i].Value = oBEClienteSAP.TipoDocCliente;//V_CLIEC_TIPO_DOCUMENTO
				i++; arrParam[i].Value = oBEClienteSAP.Nombre; //V_CLIEV_NOMBRE
				i++; arrParam[i].Value = oBEClienteSAP.ApellidoPaterno; //V_CLIEV_APELLIDO_PATERNO
				i++; arrParam[i].Value = oBEClienteSAP.ApellidoMaterno;//V_CLIEV_APELLIDO_MATERNO
				i++; arrParam[i].Value = oBEClienteSAP.RazonSocial;//V_CLIEV_RAZON_SOCIAL
				i++; arrParam[i].Value = Funciones.CheckDate(oBEClienteSAP.FechaNacimiento); //V_CLIED_FECHA_NACIMIENTO
				i++; arrParam[i].Value = oBEClienteSAP.Telefono;//V_CLIEV_TELEFONO
				i++; arrParam[i].Value = oBEClienteSAP.EMail; //V_CLIEV_E_MAIL
				i++; arrParam[i].Value = oBEClienteSAP.Sexo;//V_CLIEC_SEXO
				i++; arrParam[i].Value = oBEClienteSAP.EstadoCivil; //V_CLIEC_ESTADO_CIVIL
				i++; arrParam[i].Value = oBEClienteSAP.TitCliente;//V_CLIEC_TITULO
				i++; arrParam[i].Value = oBEClienteSAP.CargaFamiliar;//V_CLIEC_CARGA_FAMILIAR
				i++; arrParam[i].Value = oBEClienteSAP.NombreConyuge;//V_CLIEV_CONYUGE_NOMBRE
				i++; arrParam[i].Value = oBEClienteSAP.ApePatConyuge; //V_CLIEV_CONYUGE_APE_PAT
				i++; arrParam[i].Value = oBEClienteSAP.ApeMatConyuge; //V_CLIEV_CONYUGE_APE_MAT
				i++; arrParam[i].Value = oBEClienteSAP.DireccionLegalPref;//V_CLIEV_DIRECCION_LEGAL_PREF
				i++; arrParam[i].Value = oBEClienteSAP.DireccionLegal;//V_CLIEV_DIRECCION_LEGAL
				i++; arrParam[i].Value = oBEClienteSAP.ReferDireccion;//V_CLIEV_DIRECCION_LEGAL_REFER
				i++; arrParam[i].Value = oBEClienteSAP.UbigeoLegal; //V_CLIEV_UBIGEO_LEGAL
				i++; arrParam[i].Value = oBEClienteSAP.TelfPref; //V_CLIEV_TELEF_LEGAL_PREF
				i++; arrParam[i].Value = oBEClienteSAP.TelefLegal; //V_CLIEV_TELEF_LEGAL
				i++; arrParam[i].Value = oBEClienteSAP.DireccionFactPref; //V_CLIEV_DIRECCION_FACT_PREF
				i++; arrParam[i].Value = oBEClienteSAP.DireccionFact; //V_CLIEV_DIRECCION_FACT
				i++; arrParam[i].Value = null; //V_CLIEV_DIRECCION_FACT_REFER
				i++; arrParam[i].Value = oBEClienteSAP.UbigeoFact; //V_CLIEV_UBIGEO_FACT
				i++; arrParam[i].Value = oBEClienteSAP.TelefLegalPref; //V_CLIEV_TELEF_FACT_PREF
				i++; arrParam[i].Value = null; //V_CLIEV_TELEF_FACT
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalTipDoc; //V_CLIEC_REPLEGAL_TIPO_DOC
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalNroDoc; //V_CLIEV_REPLEGAL_NRO_DOC
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalNombre; //V_CLIEV_REPLEGAL_NOMBRE
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalApePat; //V_CLIEV_REPLEGAL_APE_PAT
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalApeMat; //V_CLIEV_REPLEGAL_APE_MAT               
				i++; arrParam[i].Value = null; //V_CLIED_REPLEGAL_FECHA_NAC
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalTelefon; //V_CLIEV_REPLEGAL_TELEFONO
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalSexo; //V_CLIEC_REPLEGAL_SEXO
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalEstCiv; //V_CLIEC_REPLEGAL_EST_CIV
				i++; arrParam[i].Value = oBEClienteSAP.ReplegalTit; //V_CLIEC_REPLEGAL_TITULO
				i++; arrParam[i].Value = oBEClienteSAP.ContactoTipDoc; //V_CLIEC_CONTACTO_TIPO_DOC
				i++; arrParam[i].Value = oBEClienteSAP.ContactoNroDoc; //V_CLIEV_CONTACTO_NRO_DOC
				i++; arrParam[i].Value = oBEClienteSAP.ContactoNombre; //V_CLIEV_CONTACTO_NOMBRE
				i++; arrParam[i].Value = oBEClienteSAP.ContactoApePat; //V_CLIEV_CONTACTO_APE_PAT
				i++; arrParam[i].Value = oBEClienteSAP.ContactoApeMat; //V_CLIEV_CONTACTO_APE_MAT
				i++; arrParam[i].Value = oBEClienteSAP.ContactoTelefon; //V_CLIEV_CONTACTO_TELEFONO
				i++; arrParam[i].Value = oBEClienteSAP.ClienCondCliente; //V_CLIEN_COND_CLIENTE
				i++; arrParam[i].Value = oBEClienteSAP.EmpresaLabora; //V_CLIEV_EMPRESA_LABORA
				i++; arrParam[i].Value = oBEClienteSAP.EmpresaCargo; //V_CLIEV_EMPRESA_CARGO
				i++; arrParam[i].Value = oBEClienteSAP.EmpresaTelefono; //V_CLIEV_EMPRESA_TELEFONO
				i++; arrParam[i].Value = oBEClienteSAP.IngBruto; //V_CLIEN_INGRESO_BRUTO
				i++; arrParam[i].Value = oBEClienteSAP.OtrosIngresos; //V_CLIEN_OTROS_INGRESOS
				i++; arrParam[i].Value = oBEClienteSAP.TarjetaCredito; //V_CLIEV_TCREDITO_TIPO
				i++; arrParam[i].Value = oBEClienteSAP.NumTarjCredito; //V_CLIEV_TCREDITO_NUM
				i++; arrParam[i].Value = oBEClienteSAP.MonedaTcred; //V_CLIEC_TCREDITO_MONEDA
				i++; arrParam[i].Value = oBEClienteSAP.LineaCredito; //V_CLIEN_TCREDITO_LINEA_CRED
				i++; arrParam[i].Value = oBEClienteSAP.FechaVencTcred; //V_CLIEC_TCREDITO_FECHA_VENC
				i++; arrParam[i].Value = oBEClienteSAP.Observaciones; //V_CLIEV_OBSERVACIONES
				i++; arrParam[i].Value = oBEClienteSAP.CliCodigSap; //V_CLIEV_CODIGO_SAP
				i++; arrParam[i].Value = oBEClienteSAP.VendedorSap; //V_CLIEV_VENDEDOR_SAP
				i++; arrParam[i].Value = oBEClienteSAP.UsuarioCrea; //V_CLIEV_USUARIO_CREA
				i++; arrParam[i].Value = oBEClienteSAP.TipoCliente; //V_CLIEV_VENDEDOR_SAP
			}
			catch (Exception)
			{				
				return "0";
			}

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + ".SSAPSU_CLIENTE";
			obRequest.Parameters.AddRange(arrParam);
			int p_respuesta;

			try
			{
                
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				
				p_respuesta = Convert.ToInt32(((IDataParameter)obRequest.Parameters[60]).Value);

				if (p_respuesta != 1)
				{					
					return "0";
				}

			}
	catch (Exception)
			{				
				p_respuesta = 0;
				return "0";
			}
			finally
			{
				obRequest.Parameters.Clear();
			}		

			return "1";
		}


		//Flujo DRA 14/10/2015
		public bool ActualizarPedidoDRA(int nroGeneradoSap, string nroAsociadoDRA, ref string oNroError, ref string oDescError)
		{
			oNroError = "-1";
			oDescError = string.Empty;

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DRAASOCIADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String, ParameterDirection.Output) 
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroGeneradoSap;
			arrParam[1].Value = nroAsociadoDRA;

			bool salida = false;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSU_UPDATEDRAPEDIDO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				oNroError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[2]).Value);
				oDescError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[3]).Value);

				salida = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return salida;
		}

		public bool EliminarPedidoMSSASP(Int64 p_nroPedido, string tipoficina)
		{
			//string pestado = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["codPedidoEstadoAnular"]);
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOOFICINA", DbType.String , ParameterDirection.Input)
												   
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			if (p_nroPedido > 0)
			{
				arrParam[0].Value = p_nroPedido;
				arrParam[1].Value = tipoficina;
			}

			bool salida = false;
			
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSD_LIBERARPEDIDO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return salida;
		}

	}
}
