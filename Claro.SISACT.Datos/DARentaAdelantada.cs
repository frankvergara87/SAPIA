using System;
using Claro.SisAct.Entidades;
using System.Data;
using System.Collections;
using Claro.SisAct.Common;
using Claro.SisAct.DAAB;

namespace Claro.SisAct.Datos
{
	public class DARentaAdelantada
	{
		public DARentaAdelantada()
		{
		}


		public BERentaAdelantada GrabarRentaAdelantadaPVUDB(BERentaAdelantada ra)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("PDRAC_TIPO_RA", DbType.String,0,ra.Drac_tipo_ra,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAD_FECHA_EMISION", DbType.Date,0,ra.Drad_fecha_emision,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAD_FECHA_VENCIMIENTO", DbType.Date,0,ra.Drad_fecha_vencimiento,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_CUSTOMER_ID", DbType.String,0,ra.Drav_customer_id,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_DOCUMENTO_FI", DbType.String,0,ra.Drav_documento_fi,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAN_TOTAL_AMOUNT", DbType.Decimal,0,ra.Dran_total_amount,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAN_OPEN_AMOUNT", DbType.Decimal,0,ra.Dran_open_amount,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_DOCUMENTO_CLIENTE", DbType.String,0,ra.Drav_documento_cliente,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_REFERENCIA_SAP", DbType.String,0,ra.Drav_referencia_sap,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_TIPO_APLICACION", DbType.String,0,ra.Drav_tipo_aplicacion,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_MONEDA", DbType.String,0,ra.Drav_moneda,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_CLASE_DOCUMENTO", DbType.String,0,ra.Drav_clase_documento,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_LINEA", DbType.String,0,ra.Drav_linea,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAN_IMPORTE_PAGO", DbType.Decimal,0,ra.Dran_importe_pago ,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAN_SOLIN_CODIGO", DbType.Int64,0,ra.Dran_solin_codigo,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAN_IDCONTRATO_SISACT", DbType.Int64,0,ra.DRAN_IDCONTRATO_SI,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_NROGENERADO_PEDIDO", DbType.String,0,ra.DRAV_NROGENERADO_SAP,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAN_USUARIO_CREA", DbType.String,0,ra.Dran_usuario_crea,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAN_RAZON_SOCI_NOMB", DbType.String,0,ra.DRAV_RAZONSOCIAL_NOMBRE,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_COD_PDV", DbType.String,0,ra.DRAV_COD_PDV,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_CANAL_PDV", DbType.String,0,ra.DRAV_CANAL_PDV,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_COD_CLI_SAP_PDV", DbType.String,0,ra.Drav_Cod_Cli_Sap_Pdv,ParameterDirection.Input),
												   new DAABRequest.Parameter("PDRAV_NRO_REC_APLICAR", DbType.String,0,ra.Drav_recibo_aplicar,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_SKU_DRA", DbType.String,0,ra.Sis_Sku_Dra,ParameterDirection.Input),

												   new DAABRequest.Parameter("PRESULTADO", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("PCODIGO_DRAN", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("PDRAV_NRO_ASOCIADO", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("PORIG_CTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("PNUM_DRAN_IGV_DRA", DbType.Decimal,ParameterDirection.Output),
												   new DAABRequest.Parameter("PCODIGO_PAGO", DbType.String,ParameterDirection.Output)  
											   };

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_DRA_CVE + ".SISACSI_INSERTAR_DRA";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);
				ra.DranCodigo = Funciones.CheckInt(((IDataParameter)obRequest.Parameters[25]).Value);
				ra.Drav_nro_asociado = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[26]).Value);
				ra.Drav_origen = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[27]).Value);
				ra.Dran_Igv_Dra = Funciones.CheckDecimal(((IDataParameter)obRequest.Parameters[28]).Value);
				ra.Codigo_pago = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[29]).Value);
				return ra;
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}


		public string GrabarRentaAdelantadaSISCAD(BERentaAdelantada ra)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("PSIS_CODIGO", DbType.Int64,0,ra.DranCodigo ,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_NRO_DRA", DbType.String,0,ra.Drav_nro_asociado ,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_TIPO_RA", DbType.String,0,ra.Drac_tipo_ra,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_MONEDA", DbType.String,0,ra.Drav_moneda,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_IMPORTE_DRA", DbType.Decimal,0,ra.Dran_importe_pago,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_IGV_DRA", DbType.Decimal,0,ra.Dran_Igv_Dra,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_FECHA_EMISION", DbType.Date,0,ra.Drad_fecha_emision,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_FECHA_VENCIMIENTO", DbType.Date,0,ra.Drad_fecha_vencimiento,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_COD_PDV", DbType.String,0,ra.DRAV_COD_PDV,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_CANAL_PDV", DbType.String,0,ra.DRAV_CANAL_PDV,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_DOCID_CLIENTE", DbType.String,0,ra.Drav_documento_cliente, ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_NOM_CLIENTE", DbType.String,0,ra.DRAV_RAZONSOCIAL_NOMBRE,ParameterDirection.Input),                    
												   new DAABRequest.Parameter("PSIS_ORIGEN_CUENTA", DbType.String,0,ra.Drav_origen,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_COD_CUENTA", DbType.String,0,ra.Drav_customer_id,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_SKU_DRA", DbType.String,0,ra.Sis_Sku_Dra,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_COD_APLICACION", DbType.String,0,ra.Drav_tipo_aplicacion,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_USUARIO_CREA", DbType.String,0,ra.Dran_usuario_crea ,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_SOLIN_CODIGO", DbType.Int64,0,ra.Dran_solin_codigo,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_NROGENERADO_PEDIDO", DbType.String,0,ra.DRAV_NROGENERADO_SAP,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_IDCONTRATO_SI", DbType.Int64,0,ra.DRAN_IDCONTRATO_SI,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_DRAV_PROD_IDENTIFICACION", DbType.String,0,ra.Drav_linea,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_CODIGO_PAGO", DbType.String,0,ra.Codigo_pago,ParameterDirection.Input),
												   new DAABRequest.Parameter("PSIS_PEDIN_PEDIDOALTA", DbType.String,0,ra.Pediv_PedidoAlta,ParameterDirection.Input),
												   new DAABRequest.Parameter("PRESULTADO", DbType.String,ParameterDirection.Output)                 
											   };

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISCAD_PKG_RENTAADELANTADA + ".SISCAD_INS_DRA";
			obRequest.Parameters.AddRange(arrParam);

			string respuesta = "";
			IDataReader dr = null;
			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);
				respuesta = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[23]).Value);                
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return respuesta;
		}


		public void obtenerSKURentaAdelantada(string p_cod_pdv, double p_precio, ref string p_sku)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO_PDV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("O_SKU", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESCLOG", DbType.String, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = p_cod_pdv;
			arrParam[1].Value = p_precio;

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISCAD_PKG_RENTAADELANTADA + ".SISCAD_CONS_SKU_DRA";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter pSalida, pSalida1, pSalida2;
				pSalida = (IDataParameter)obRequest.Parameters[2];
				pSalida1 = (IDataParameter)obRequest.Parameters[3];
				pSalida2 = (IDataParameter)obRequest.Parameters[4];
				
				if (Funciones.CheckStr(pSalida1.Value) == "1")
                    p_sku = "0";
                else
                    p_sku = Funciones.CheckStr(pSalida.Value);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				//if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		
		public bool actualizaVendedor(string p_nroSap, string dniVendedor, string nomVendedor, string codPago, string codSinergia, ref string msg_resp)
		{                                            
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DRAV_NROGENERADO_SAP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_DNI_VENDEDOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_NOM_VENDEDOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_SIS_VENTV_TICKET_VENTA_DRA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_SIS_COD_PDV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MSG_RESP", DbType.String, ParameterDirection.Output)
											   };
                                              
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[0].Value = p_nroSap;
			arrParam[1].Value = dniVendedor;
			arrParam[2].Value = nomVendedor;
			arrParam[3].Value = codPago;
			arrParam[4].Value = codSinergia;

			bool salida = false;
 
			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISCAD_PKG_RENTAADELANTADA + ".SISCAD_UPDTVENDEDOR_DRA";
			obRequest.Parameters.AddRange(arrParam);
                                    
			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[5];
				msg_resp = Funciones.CheckStr(pSalida.Value);
				salida = true;
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				//if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return salida;
		}


public void actualizarUbigeo(Int64 pSolinCodigo, string numDocumento, ref string msg_resp)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLINCODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MSG_RESP", DbType.String, ParameterDirection.Output)
											   };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pSolinCodigo;
			arrParam[1].Value = numDocumento;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_DRA_CVE + ".SISACSS_UPDTUBIGEO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[2];
				msg_resp = Funciones.CheckStr(pSalida.Value);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}


	}
}
