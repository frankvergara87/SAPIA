using System;
using System.Data;
using System.Collections;
using System.Configuration;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using Claro.SisAct.Common;
using Claro.SisAct.Configuracion;

namespace Claro.SisAct.SapGeneral
{
	/// <summary>
	/// Descripción breve de clsGeneral.
	/// </summary>
	public class clsGeneral
	{
		public clsGeneral()
		{
		}

		private SapGeneral ConectaSAP()
		{	

			string strAplicacion = ConfigurationSettings.AppSettings["KeySAP"].ToString();
			Claro.SisAct.Configuracion.ConfigConexionSAP oConfigConexionSAP = Claro.SisAct.Configuracion.ConfigConexionSAP.GetInstance(strAplicacion);
				
			string strLanguage=ConfigurationSettings.AppSettings["IdiomaSAP"].ToString();
			string strApplicationServer = ConfigurationSettings.AppSettings["ServidorSAP"].ToString();
			string strSistema = ConfigurationSettings.AppSettings["SistemaSAP"].ToString();

			// Load Balancing SAP
			string strLoadBal = ConfigurationSettings.AppSettings["gConstLoadBalancing"].ToString();
			string strMessServ = ConfigurationSettings.AppSettings["gConstMessageServer"].ToString();
			string strR3Name = ConfigurationSettings.AppSettings["gConstR3Name"].ToString();
			string strGroup = ConfigurationSettings.AppSettings["gConstGroup"].ToString();
 
			SapGeneral  proxy;
 
			if (strLoadBal == "0")
			{
				proxy = new SapGeneral("CLIENT=" + oConfigConexionSAP.Parametros.BaseDatos + " USER=" + oConfigConexionSAP.Parametros.Usuario + " PASSWD=" + oConfigConexionSAP.Parametros.Password + " LANG=" + strLanguage +" ASHOST=" + strApplicationServer + " SYSNR=" + strSistema);
			} 
			else 
			{
				proxy = new SapGeneral("CLIENT=" + oConfigConexionSAP.Parametros.BaseDatos + " USER=" + oConfigConexionSAP.Parametros.Usuario+ " PASSWD=" + oConfigConexionSAP.Parametros.Password+ " LANG=" + strLanguage +" MSHOST=" + strMessServ + " R3NAME=" + strR3Name + " GROUP=" + strGroup);
			}                   
			return proxy;
		}
		private decimal FormatoDec(string Valor)
		{
			decimal res = 0;
			if (Valor.Trim() != "")
			{
				res = Convert.ToDecimal(Valor);
			}
			return res;
		}
		private string FormatoDecSTR(string Valor)
		{
			string res = "0";
			if (Valor.Trim() != "")
			{
				res = Valor;
			}
			return res;
		}
		private string FormatoFecha(string Fecha)
		{
			if (Fecha.Length > 0 )
				return Fecha.Substring(6,4) + "/" + Fecha.Substring(3,2) + "/" + Fecha.Substring(0,2);
			else
				return "0000/00/00";
		}
		public ArrayList ConsultarListaPrecios(string p_tipo_venta, string p_plan_tarif, string p_codigo_material, string p_codigo_campania,
			string p_org_venta, string p_fecha, string p_tipo_operacion)
		{
			DataSet dsReturn = new DataSet();
			ArrayList lista = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZWA_UTILIZACIONTable objListaPrecios = new ZWA_UTILIZACIONTable();
				BAPIRET2Table objRetorno = new BAPIRET2Table();
				proxy.Zsisa_Rfc_Con_Lista_Precio(p_codigo_campania, p_codigo_material, p_fecha, p_tipo_venta, p_org_venta,
					p_plan_tarif, p_tipo_operacion, ref objRetorno, ref objListaPrecios);
				dsReturn.Tables.Add(objListaPrecios.ToADODataTable());
				dsReturn.Tables.Add(objRetorno.ToADODataTable());

				proxy.Connection.Close();

				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo = Funciones.CheckStr(dr["ABRVW"]);
						item.Descripcion = Funciones.CheckStr(dr["BEZEI"]);
						lista.Add(item);
					}	
				}
				if (dsReturn.Tables[1].Rows.Count>0)
				{
					foreach(DataRow dr in dsReturn.Tables[1].Rows)
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E")
						{
							//throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
							throw new Exception("SAP. La combinacion Tipo Venta, Plan, Material CHIP/Equipo, Campaña; no esta configurada en el Sistema.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return lista;
		}
		public DataSet ConsultarPrecio(string p_oficina, string p_documento_origen, string p_consecutivo, string p_material,
			string p_utilizacion,decimal p_cantidad, string p_fecha, string p_serie, string p_nro_telefono, string p_tipo_doc_venta,
			string p_cadena_series, string p_canal, string p_org_vnt, string p_disp_IMEI, out decimal p_descuento, out decimal p_prec_incIGV,
			out decimal p_precio, out decimal p_subTotal)
		{
			DataSet dsReturn = new DataSet();
			decimal valorIGV;
			string[] strTrama;
			int intMax;
			try
			{				
				SapGeneral proxy = ConectaSAP();
				ZST_PV_LIN_DOC_IMEITable objLinDocIMEI = new ZST_PV_LIN_DOC_IMEITable();
				ZST_PV_LIN_DOC_IMEI objLineaLinDocIMEI = new ZST_PV_LIN_DOC_IMEI();

				BAPIRET2Table objLog = new BAPIRET2Table();

				intMax = 4;
				strTrama = p_cadena_series.Split(';',(char)intMax);
				p_nro_telefono = "";
				
				if (p_cadena_series.Length > 0)
				{
					objLineaLinDocIMEI.Documento = strTrama[0];
					objLineaLinDocIMEI.Consecutivo = strTrama[1];
					objLineaLinDocIMEI.Serie_Inicial = strTrama[2];
					objLineaLinDocIMEI.Serie_Final = strTrama[3];

					objLinDocIMEI.Add(objLineaLinDocIMEI);
				}

				proxy.Zpvu_Rfc_Val_Ser_Tlf_Pre(p_canal, p_cantidad, p_consecutivo, p_documento_origen, p_fecha, p_material,
					p_nro_telefono, p_oficina, p_org_vnt, p_serie, p_tipo_doc_venta, p_utilizacion, p_disp_IMEI, out p_descuento,
					out p_prec_incIGV, out p_precio, out p_subTotal, out valorIGV, ref objLinDocIMEI, ref objLog);
					                           
				dsReturn.Tables.Add(objLog.ToADODataTable());
				proxy.Connection.Close();

				if (dsReturn.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E")
						{
							throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
						}
					}
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				p_descuento = 0;
				p_prec_incIGV = 0;
				p_precio = 0;
				p_subTotal = 0;

				throw ex;
			}
			return dsReturn;
		}
		public DataSet ConsultarParametrosOfVenta(string p_oficina_venta)
		{
			DataSet dsReturn = new DataSet();
			try
			{
				ZST_PV_PARAM_OF_VTATable objParam = new ZST_PV_PARAM_OF_VTATable();
				BAPIRET2Table objRetorno = new BAPIRET2Table();

				SapGeneral proxy = ConectaSAP();

				proxy.Zpvu_Rfc_Adm_Param_Of_Vta(p_oficina_venta, "", "", ref objParam, ref objRetorno);
				
				dsReturn.Tables.Add(objParam.ToADODataTable());
				dsReturn.Tables.Add(objRetorno.ToADODataTable());
				proxy.Connection.Close();

				if (dsReturn.Tables[1].Rows.Count>0) 
				{	
					foreach(DataRow dr in dsReturn.Tables[1].Rows) 
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E") 
						{
							throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
						}
					}
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}

			return dsReturn;
		}
		public DataSet ConsultarTipoDocumentoOfVenta(string p_oficinaVenta)
		{
			DataSet dsReturn = new DataSet();
			try
			{
				ZST_PV_CLASE_PEDIDOTable objClasePedido = new ZST_PV_CLASE_PEDIDOTable();

				SapGeneral proxy = ConectaSAP();

				proxy.Zpvu_Rfc_Mae_Clase_Pedido(p_oficinaVenta, ref objClasePedido);
				
				dsReturn.Tables.Add(objClasePedido.ToADODataTable());
				proxy.Connection.Close();

			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}

			return dsReturn;
		}
		public bool RealizarPedido(string CadenaCabecera,string CadenaDetalle, string CadenaSeries,
			string CadenaServAdic, string CadenaAcuerdo, 
			out string strEntrega,
			out string strFactura,
			out string strNroContrato,
			out string strNroDocCliente,
			out string strNroPedido,
			out string strRefHistorico,
			out string strTipDocCliente,
			out decimal dblValorDescuento)
		{
			DataSet dsReturn = new DataSet();
			bool valor = true;
			int intMax1;
			int intMax2;
			int intMax3;
			int intMax4;
			//int intMax5;

			string[] strTrama1;
			string[] strTrama2;

			try
			{
				ZST_PV_DOCUMENTOTable objDocumento = new ZST_PV_DOCUMENTOTable();
				ZST_PV_LINEA_DOC_VENTATable objLineaDocumento = new ZST_PV_LINEA_DOC_VENTATable();
				ZST_PV_LIN_DOC_IMEITable objLinDocIMEI = new ZST_PV_LIN_DOC_IMEITable();
				ZST_PV_SERVI_CONTRATable objServicios = new ZST_PV_SERVI_CONTRATable();
				ZST_PV_CONTRATOTable objContrato = new ZST_PV_CONTRATOTable();
				BAPIRET2Table objLog = new BAPIRET2Table();

				ZST_PV_DOCUMENTO objFilaDocumento = new ZST_PV_DOCUMENTO();
				ZST_PV_LINEA_DOC_VENTA objFilaLineaDocumento = new ZST_PV_LINEA_DOC_VENTA();
				ZST_PV_LIN_DOC_IMEI objFilaLinDocIMEI = new ZST_PV_LIN_DOC_IMEI();
				ZST_PV_SERVI_CONTRA objFilaServicios = new ZST_PV_SERVI_CONTRA();
				ZST_PV_CONTRATO objFilaContrato = new ZST_PV_CONTRATO();

				intMax1 = 41;
				intMax2 = 29;
				intMax3 = 4;
				intMax4 = 4;
				//intMax5 = 66; //62

				strTrama1 = CadenaCabecera.Split(';',(char)intMax1);

				if (CadenaCabecera.Length > 0)
				{
					objFilaDocumento.Documento = strTrama1[0];
					objFilaDocumento.Tipo_Documento = strTrama1[1];
					objFilaDocumento.Oficina_Venta = strTrama1[2];
					objFilaDocumento.Fecha_Documento =  FormatoFecha(strTrama1[3]);
					objFilaDocumento.Tipo_Doc_Cliente = strTrama1[4];
					objFilaDocumento.Cliente = strTrama1[5];
					objFilaDocumento.Augru = strTrama1[6];
					objFilaDocumento.Moneda = strTrama1[7];
					objFilaDocumento.Tipo_Operacion = strTrama1[8];
					objFilaDocumento.Total_Mercaderia = FormatoDec(strTrama1[9]);
					objFilaDocumento.Total_Impuesto = FormatoDec(strTrama1[10]);
					objFilaDocumento.Total_Documento = FormatoDec(strTrama1[11]);
					objFilaDocumento.Fecha_Registro = FormatoFecha(strTrama1[12]);
					objFilaDocumento.Impreso = strTrama1[13];
					objFilaDocumento.Observacion1 = strTrama1[14];
					objFilaDocumento.Observacion2 = strTrama1[15];
					objFilaDocumento.Tipo_Venta = strTrama1[16];
					objFilaDocumento.Numero_Contrato = strTrama1[17];
					objFilaDocumento.Nro_Referencia = strTrama1[18];
					objFilaDocumento.Usuario_Registro = strTrama1[19];
					objFilaDocumento.Anulado = strTrama1[20];
					objFilaDocumento.Documento_Origen = strTrama1[21];
					objFilaDocumento.Fecha_Vta_Origen = FormatoFecha(strTrama1[22]);
					objFilaDocumento.Nro_Refer_Origen = strTrama1[23];
					objFilaDocumento.Nro_Cuotas = strTrama1[24];
					objFilaDocumento.Nro_Clarify = strTrama1[25];
					objFilaDocumento.Estado = strTrama1[26];
					objFilaDocumento.Vendedor = strTrama1[27];
					objFilaDocumento.Mala_Venta = strTrama1[28];
					objFilaDocumento.Clase_Venta = strTrama1[29];
					objFilaDocumento.Des_Clase_Venta = strTrama1[30];
					objFilaDocumento.Mot_Mala_Venta = strTrama1[31];
					objFilaDocumento.Telefono = strTrama1[32];
					objFilaDocumento.Referencia = strTrama1[33];
					objFilaDocumento.Historico = strTrama1[34];
					objFilaDocumento.Numero_Hdc = strTrama1[35];
					objFilaDocumento.Nro_Pcs_Asociado = strTrama1[36];
					objFilaDocumento.Nro_Ped_Tg = strTrama1[37];
					objFilaDocumento.Nro_Acuer_Alqu = strTrama1[38];
					objFilaDocumento.Trans_Gratuita = strTrama1[39];
					objFilaDocumento.Fidelizacion = strTrama1[40];
					//objFilaDocumento.Vendedor_Dni = strTrama1[41];
					//objFilaDocumento.Nro_Solicitud = strTrama1[42];
					//objFilaDocumento.Serie_Recibida = strTrama1[43];
					//objFilaDocumento.Operador = strTrama1[44];
					objFilaDocumento.Tipo_Prod_Operad = strTrama1[45];
					//objFilaDocumento.Clase_Ped_Devol = strTrama1[46];
					//objFilaDocumento.Nro_Factura = strTrama1[47];
					objFilaDocumento.Orgvnt = strTrama1[48];
					objFilaDocumento.Canal = strTrama1[49];
					
					objDocumento.Add(objFilaDocumento);
				}

				if (CadenaDetalle.Length > 0 )
				{
					strTrama1 = CadenaDetalle.Split('|');
					for (int i=0;i<strTrama1.Length;i++)
					{
						strTrama2 = strTrama1[i].Split(';',(char)intMax2);

						objFilaLineaDocumento = null;
						objFilaLineaDocumento = new ZST_PV_LINEA_DOC_VENTA();

						objFilaLineaDocumento.Documento = strTrama2[0];
						objFilaLineaDocumento.Consecutivo = strTrama2[1];
						objFilaLineaDocumento.Articulo = strTrama2[2];
						objFilaLineaDocumento.Des_Articulo = strTrama2[3];
						objFilaLineaDocumento.Utilizacion = strTrama2[4];
						objFilaLineaDocumento.Des_Utilizacion = strTrama2[5];
						objFilaLineaDocumento.Campana = strTrama2[6];
						objFilaLineaDocumento.Des_Campana = strTrama2[7];
						objFilaLineaDocumento.Serie = strTrama2[8];
						objFilaLineaDocumento.Cantidad = FormatoDec(strTrama2[9]);
						objFilaLineaDocumento.Precio = FormatoDec(strTrama2[10]);
						objFilaLineaDocumento.Precio_Total = FormatoDec(strTrama2[11]);
						objFilaLineaDocumento.Descuento = Convert.ToDecimal(strTrama2[12]);
						//objFilaLineaDocumento.Porc_Descuento = Convert.ToDecimal(strTrama2[13]);
						//objFilaLineaDocumento.Descuento_Adic = Convert.ToDecimal(strTrama2[14]);
						objFilaLineaDocumento.Subtotal = FormatoDec(strTrama2[15]);
						objFilaLineaDocumento.Impuesto1 = FormatoDec(strTrama2[16]);
						objFilaLineaDocumento.Impuesto2 = FormatoDec(strTrama2[17]);
						objFilaLineaDocumento.Plan_Tarifario = strTrama2[18];
						objFilaLineaDocumento.Des_Plan_Tarifar = strTrama2[19];
						objFilaLineaDocumento.Centro_Costo = strTrama2[20];
						objFilaLineaDocumento.Motivo_Devolucio = strTrama2[21];
						objFilaLineaDocumento.Asociado = strTrama2[22];
						objFilaLineaDocumento.Consecutivo_Padr = FormatoDecSTR(strTrama2[23]);
						objFilaLineaDocumento.Articulo_Asociac = strTrama2[24];
						objFilaLineaDocumento.Numero_Telefono = strTrama2[25];
						objFilaLineaDocumento.Nro_Clarify =FormatoDecSTR(strTrama2[26]);
						objFilaLineaDocumento.Dev_Componente = strTrama2[27];
						//objFilaLineaDocumento.Serie_Ant = strTrama2[28];

						objLineaDocumento.Add(objFilaLineaDocumento);
					}
				}


				if (CadenaSeries.Length > 0)
				{
					strTrama1 = CadenaSeries.Split('|');
					for (int i=0;i<strTrama1.Length;i++)
					{
						strTrama2 = strTrama1[i].Split(';',(char)intMax3);

						objFilaLinDocIMEI = null;
						objFilaLinDocIMEI = new ZST_PV_LIN_DOC_IMEI();

						objFilaLinDocIMEI.Documento = strTrama2[0];
						objFilaLinDocIMEI.Consecutivo = strTrama2[1];
						objFilaLinDocIMEI.Serie_Inicial = strTrama2[2];
						objFilaLinDocIMEI.Serie_Final = strTrama2[3];

						objLinDocIMEI.Add(objFilaLinDocIMEI);
					}
				}

				if (CadenaServAdic.Length > 0)
				{
					strTrama1 = CadenaServAdic.Split('|');
					for (int i=0;i<strTrama1.Length;i++)
					{
						strTrama2 = strTrama1[i].Split(';',(char)intMax4);

						objFilaServicios = null;
						objFilaServicios = new ZST_PV_SERVI_CONTRA();

						objFilaServicios.Documento  = strTrama2[0];
						objFilaServicios.Consecutivo = strTrama2[1];
						objFilaServicios.Servicio_Solicit = strTrama2[2];
						if (strTrama2[2].Length > 4)
						{
							objFilaServicios.Servicio_Solicit = Funciones.Right(strTrama2[2], 4);
						}
						objFilaServicios.Valor_Selecciona = strTrama2[3];

						objServicios.Add(objFilaServicios);
					}
				}

				// La parte de generacion de acuerdo se deja de lado momentaneamente
				if (CadenaAcuerdo.Length > 0)
				{
					string[] arrAcuerdo = CadenaAcuerdo.Split(';');

					objFilaContrato.Numero_Contrato = arrAcuerdo [0];
					objFilaContrato.Oficina_Ventas = arrAcuerdo [1];
					objFilaContrato.Numero_Pcs = arrAcuerdo [2];
					objFilaContrato.Fecha_Contrato = FormatoFecha(arrAcuerdo [3]);
					objFilaContrato.Plazo_Acuerdo = arrAcuerdo [4];
					objFilaContrato.Fact_Nombre = arrAcuerdo [5];
					objFilaContrato.Fact_Apel_Pat = arrAcuerdo [6];
					objFilaContrato.Fact_Ape_Mat = arrAcuerdo [7];
					objFilaContrato.Fact_R_Social = arrAcuerdo [8];
					objFilaContrato.Codigo_Aprobacio = arrAcuerdo [9];
					objFilaContrato.Resultado = arrAcuerdo [10];
					objFilaContrato.Impreso = arrAcuerdo [11];
					objFilaContrato.Fecha_Registro = FormatoFecha(arrAcuerdo [12]);
					objFilaContrato.Fecha_Actualiz = FormatoFecha(arrAcuerdo [13]);
					objFilaContrato.Doc_Sustento = arrAcuerdo [14];
					objFilaContrato.Tarjeta_Credito = arrAcuerdo [15];
					objFilaContrato.Num_Tarj_Credito = arrAcuerdo [16];
					objFilaContrato.Moneda_Tcred = arrAcuerdo [17];
					objFilaContrato.Linea_Credito = FormatoDec(arrAcuerdo [18]);
					objFilaContrato.Fecha_Venc_Tcred = arrAcuerdo [19];
					objFilaContrato.Vendedor = arrAcuerdo [20];
					objFilaContrato.Telefono_Vendedo = arrAcuerdo [21];
					objFilaContrato.Documento = arrAcuerdo [22];
					objFilaContrato.Via_Pago = arrAcuerdo [23];
					objFilaContrato.Debito_Automati = arrAcuerdo [24];
					objFilaContrato.Analista_Credito = arrAcuerdo [25];
					objFilaContrato.Migracion = arrAcuerdo [26];
					objFilaContrato.Estado = arrAcuerdo [27];
					objFilaContrato.Cod_Observacion = arrAcuerdo [28];
					objFilaContrato.Observaciones = arrAcuerdo [29];
					objFilaContrato.Tipo_Rechazo = arrAcuerdo [30];
					objFilaContrato.Via_Dsf = arrAcuerdo [31];
					objFilaContrato.Tipo_Doc_Cliente = arrAcuerdo [32];
					objFilaContrato.Cliente = arrAcuerdo [33];
					objFilaContrato.Telef_Renov = arrAcuerdo [34];
					objFilaContrato.Plan_Renov = arrAcuerdo [35];
					objFilaContrato.Renovacion = arrAcuerdo [36];
					objFilaContrato.Codigo_Banco = arrAcuerdo [37];
					objFilaContrato.Nro_Clarify = arrAcuerdo [38];
					objFilaContrato.Numero_Hdc = arrAcuerdo [39];
					objFilaContrato.Reposicion =  arrAcuerdo [40];
					objFilaContrato.Campana = arrAcuerdo [41];
					objFilaContrato.Aprobador = arrAcuerdo [42];
					objFilaContrato.Lim_Credito = FormatoDec(arrAcuerdo [43]);
					objFilaContrato.Eval_Cred_Manual = arrAcuerdo [44];
					objFilaContrato.Score_Crediticio = arrAcuerdo [45];
					objFilaContrato.Control_Fraude = arrAcuerdo [46];
					objFilaContrato.Nro_Carpeta_Obs = arrAcuerdo [47];
					objFilaContrato.Nro_Contrato_Ant = arrAcuerdo [48];
					objFilaContrato.Operador = arrAcuerdo [49];
					objFilaContrato.Plan_Anterior = arrAcuerdo [50];
					objFilaContrato.Nro_Ope_Infocorp = arrAcuerdo [51];
					objFilaContrato.Cs_Large = arrAcuerdo [52];
					objFilaContrato.Cs_Subcuenta = arrAcuerdo [53];
					objFilaContrato.Lim_Cred_Max = FormatoDec(arrAcuerdo [54]);
					objFilaContrato.Sum_Planes_Actua = FormatoDec(arrAcuerdo [55]);
					objFilaContrato.Sum_Planes_Vendi = FormatoDec(arrAcuerdo [56]);
					objFilaContrato.Respons_Pago = arrAcuerdo [57];
					objFilaContrato.Existe_Bscs = arrAcuerdo [58];
					objFilaContrato.Tipo_Activ_Clte =  arrAcuerdo [59];
					objFilaContrato.Activacion_Linea = arrAcuerdo [60];
					objFilaContrato.Acuerdo_Manual = arrAcuerdo [61];
					objFilaContrato.Tipo_Cli_Act = arrAcuerdo [62];
					objFilaContrato.Tipo_Vta_Ori = arrAcuerdo [63];
					objFilaContrato.Motivo_Mig = arrAcuerdo [64];
					objFilaContrato.Con_Sin_Eq = arrAcuerdo [65];
					objFilaContrato.Motivo_Repos = arrAcuerdo [66];


					objContrato.Add (objFilaContrato);
					objFilaContrato = null;
				}

				SapGeneral proxy = ConectaSAP();

				strEntrega = "";
				strFactura = "";
				strNroContrato = "";
				strNroDocCliente = "";
				strNroPedido = "";
				strRefHistorico = "";
				strTipDocCliente = "";
				dblValorDescuento = 0;

				int cantIntentoSap = Funciones.CheckInt(ConfigurationSettings.AppSettings["consultaIntentosSAP"]);			
				int cont=0;
				try
				{
					proxy.Zpvu_Rfc_Trs_Pedido("","","","","",out strEntrega,out strFactura,out strNroContrato,
						out strNroDocCliente,out strNroPedido,out strRefHistorico,
						out strTipDocCliente,out dblValorDescuento,ref objContrato,
						ref objDocumento,ref objLinDocIMEI,ref objLineaDocumento,
						ref objLog,ref objServicios);
					
				}
				catch
				{
					for(cont=0; cont< cantIntentoSap;cont++ ) 
					{
						try
						{
							proxy.Zpvu_Rfc_Trs_Pedido("","","","","",out strEntrega,out strFactura,out strNroContrato,
								out strNroDocCliente,out strNroPedido,out strRefHistorico,
								out strTipDocCliente,out dblValorDescuento,ref objContrato,
								ref objDocumento,ref objLinDocIMEI,ref objLineaDocumento,
								ref objLog,ref objServicios);
							break;
						}
						catch(Exception ex1)
						{
							if(cont == cantIntentoSap - 1)
							{
								throw ex1;
							} 
						}
					}
				}

				dsReturn.Tables.Add(objDocumento.ToADODataTable());
				dsReturn.Tables.Add(objLog.ToADODataTable());

				proxy.Connection.Close();

				string sMensajes = "";
				if (dsReturn.Tables[1].Rows.Count>0) 
				{	
					foreach(DataRow dr in dsReturn.Tables[1].Rows) 
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						sMensajes += " - " + Funciones.CheckStr(dr["MESSAGE"]);
						if (tipo == "E") 
						{
							throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
						}
					}
				}
				if(strFactura==""){
					throw new Exception(sMensajes);
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				strEntrega = "";
				strFactura = "";
				strNroContrato = "";
				strNroDocCliente = "";
				strNroPedido = "";
				strRefHistorico = "";
				strTipDocCliente = "";
				dblValorDescuento  = 0;

				valor = false;
				throw ex;
			}

			return valor;
		}
		public DataSet Set_ActualizaCreaCliente(string OficinaVta, string[] arrCliente)
		{
			DataSet dsReturn = new DataSet();
			
			//try
			//{
			SapGeneral proxy = ConectaSAP();
			BAPIRET2Table objLog = new BAPIRET2Table();
			ZST_PV_CLIENTETable objCliente = new ZST_PV_CLIENTETable();
			ZST_PV_CLIENTE objLinCliente = new ZST_PV_CLIENTE();
              
			if (arrCliente[1] != "" && arrCliente[2] != "")
			{
				//objLinCliente = objCliente[0];
				objLinCliente.Cliente=arrCliente[0];
				objLinCliente.Tipo_Doc_Cliente=arrCliente[1];
				objLinCliente.Tipo_Cliente=arrCliente[2];
				objLinCliente.Nombre=arrCliente[3];
				objLinCliente.Apellido_Paterno=arrCliente[4];
				objLinCliente.Apellido_Materno=arrCliente[5];
				objLinCliente.Razon_Social=arrCliente[6];
				objLinCliente.Fecha_Nacimiento=arrCliente[7];
				objLinCliente.Telefono=arrCliente[8];
				objLinCliente.Fax=arrCliente[9];
				objLinCliente.E_Mail=arrCliente[10];
				objLinCliente.Nombre_Conyuge=arrCliente[11];
				objLinCliente.Carga_Familiar=arrCliente[12];
				objLinCliente.Sexo=arrCliente[13];
				objLinCliente.Calle_Legal=arrCliente[14];
				objLinCliente.Ubigeo_Legal=arrCliente[15];
				objLinCliente.Calle_Fact=arrCliente[16];
				objLinCliente.Ubigeo_Fact=arrCliente[17];
				objLinCliente.Replegal_Tip_Doc=arrCliente[18];
				objLinCliente.Replegal_Nro_Doc=arrCliente[19];
				objLinCliente.Replegal_Nombre=arrCliente[20];
				objLinCliente.Replegal_Ape_Pat=arrCliente[21];
				objLinCliente.Replegal_Ape_Mat=arrCliente[22];
				objLinCliente.Replegal_Telefon=arrCliente[23];
				objLinCliente.Contacto_Tip_Doc=arrCliente[24];
				objLinCliente.Contacto_Nro_Doc=arrCliente[25];
				objLinCliente.Contacto_Nombre=arrCliente[26];
				objLinCliente.Contacto_Ape_Pat=arrCliente[27];
				objLinCliente.Contacto_Ape_Mat=arrCliente[28];
				objLinCliente.Contacto_Telefon=arrCliente[29];
				objLinCliente.Cargo=arrCliente[30];
				objLinCliente.Dependiente=arrCliente[31];
				objLinCliente.Empresa_Labora=arrCliente[32];
				objLinCliente.Empresa_Cargo=arrCliente[33];
				objLinCliente.Empresa_Telefono=arrCliente[34];
				objLinCliente.Actividad=arrCliente[35];
				objLinCliente.Ing_Bruto=FormatoDec(arrCliente[36]); //decimal
				objLinCliente.Otros_Ingresos=FormatoDec(arrCliente[37]); //decimal
				objLinCliente.Tarjeta_Credito=arrCliente[38];
				objLinCliente.Num_Tarj_Credito=arrCliente[39];
				objLinCliente.Moneda_Tcred=arrCliente[40];
				objLinCliente.Linea_Credito=FormatoDec(arrCliente[41]); //decimal
				objLinCliente.Fecha_Venc_Tcred=arrCliente[42];
				objLinCliente.Clasificacion=arrCliente[43];
				objLinCliente.Clase_Cliente=arrCliente[44];
				objLinCliente.Ramo=arrCliente[45];
				objLinCliente.Observaciones=arrCliente[46];
				objLinCliente.Estado_Civil=arrCliente[47];
				objLinCliente.Tit_Cliente=arrCliente[48];
				objLinCliente.Replegal_Tit=arrCliente[49];
				objLinCliente.Replegal_Fnac=arrCliente[50];
				objLinCliente.Replegal_Sexo=arrCliente[51];
				objLinCliente.Replegal_Est_Civ=arrCliente[52];
				objLinCliente.Ktokd=arrCliente[53];
				objLinCliente.Refer_Direccion=arrCliente[54];
				objLinCliente.Telf_Pref=arrCliente[55];
				objLinCliente.Fax_Pref=arrCliente[56];
				objLinCliente.Telef_Legal=arrCliente[57];
				objLinCliente.Operador=arrCliente[58];
				objLinCliente.Denom_Operador=arrCliente[59];
				objLinCliente.Tipo_Prod_Operad=arrCliente[60];
				objLinCliente.Denom_Tpo_Prod_Op=arrCliente[61];
				objLinCliente.Telef_Legal_Pref=arrCliente[62];
				objLinCliente.Refer_Legal=arrCliente[63];
				objLinCliente.Kunnr=arrCliente[64];
			}
			objCliente.Add(objLinCliente);

			proxy.Zpvu_Rfc_Trs_Cliente(OficinaVta,ref objLog, ref objCliente);
			dsReturn.Tables.Add(objCliente.ToADODataTable());
			dsReturn.Tables.Add(objLog.ToADODataTable());
			proxy.Connection.Close();
			//}
			/*catch (Exception ex)
			{
				dsReturn = null;
			}*/
			return dsReturn;

		}
		public DataSet Get_ConsultaCliente(string Oficina,string TipDocCliente ,string Cliente ) 
		{
			string Multimarca="";
			DataSet dsReturn;
			try
			{
				ZST_PV_CLIENTETable objCliente = new ZST_PV_CLIENTETable();	
				BAPIRET2Table objReturn = new BAPIRET2Table();
				SapGeneral proxy = ConectaSAP();	

				proxy.Zpvu_Rfc_Con_Cliente(Cliente,Oficina, TipDocCliente, out Multimarca, ref objCliente, ref objReturn);

				dsReturn = new DataSet();					
				dsReturn.Tables.Add(objCliente.ToADODataTable());			
				dsReturn.Tables.Add(objReturn.ToADODataTable());
				proxy.Connection.Close();
			}
			catch
			{
				dsReturn=null;
			}
			
			return dsReturn;
		}
		public DataSet SetGetLogActivacionChip(string nroDocumento, string puntoVenta, 
			string strLog, ref string nroSolicitud)
		{
			SapGeneral proxy = ConectaSAP();
			DataSet dsReturn = new DataSet();
			string[] strTrama;
			try
			{
				ZST_ACT_CHIPTable objActChip = new ZST_ACT_CHIPTable();
				BAPIRET2Table objReturn = new BAPIRET2Table();
				ZST_ACT_CHIP objFilaActChip = new ZST_ACT_CHIP();
				
				int intMax = 18;

				strTrama = strLog.Split(';',(char)intMax);

				if (strLog.Length > 0)
				{
					objFilaActChip.Nro_Solicitud = strTrama[0];
					objFilaActChip.Nro_Telefono = strTrama[1];
					objFilaActChip.Serie_Actual = strTrama[2];
					objFilaActChip.Imsi_Actual = strTrama[3];
					objFilaActChip.Oficina_Venta = strTrama[4];
					objFilaActChip.Documento = strTrama[5];
					objFilaActChip.Motivo_Pedido = strTrama[6];
					objFilaActChip.Serie_Nueva = strTrama[7];
					objFilaActChip.Imsi_Nuevo = strTrama[8];
					objFilaActChip.Vendedor = strTrama[9];
					objFilaActChip.Estado_Ini_Telef = strTrama[10];
					objFilaActChip.Fecha_Creacion = strTrama[11];
					objFilaActChip.Hora_Creacion = strTrama[12];
					objFilaActChip.Estado_Solicitud = strTrama[13];
					objFilaActChip.Enviado_Variacio = strTrama[14];
					objFilaActChip.Estado_Fin_Telef = strTrama[15];
					objFilaActChip.Fecha_Actualiz = strTrama[16];
					objFilaActChip.Hora_Actualiz = strTrama[17];
					objActChip.Add(objFilaActChip);
				}
				
				proxy.Zpvu_Rfc_Trs_Activacion_Chip(nroDocumento, puntoVenta, out nroSolicitud, ref objActChip, ref objReturn);
				
				dsReturn.Tables.Add(objActChip.ToADODataTable());
				dsReturn.Tables.Add(objReturn.ToADODataTable());
				proxy.Connection.Close();

			}
			catch (Exception)
			{
				dsReturn = null;
			}
			finally
			{
				proxy.Connection.Close();
			}

			return dsReturn;
		}
		public DataSet Get_ConsultaPedido(string Referencia, string Oficina, string Nro_Sap, string Tipo_Documento)
		{
			DataSet dsReturn = new DataSet();
			SapGeneral proxy = ConectaSAP();
			try
			{
				ZST_PV_DOCUMENTOTable objDocumento = new ZST_PV_DOCUMENTOTable();
				ZST_PV_LINEA_DOC_VENTATable objLineaDoc = new ZST_PV_LINEA_DOC_VENTATable();
				ZST_PV_LIN_DOC_IMEITable objLineaDocIMEI = new ZST_PV_LIN_DOC_IMEITable();
				ZST_PV_SERVI_CONTRATable objServicioCont = new ZST_PV_SERVI_CONTRATable();
				BAPIRET2Table objReturn = new BAPIRET2Table();

				int cantIntentoSap = Funciones.CheckInt(ConfigurationSettings.AppSettings["consultaIntentosSAP"]);			
				int cont=0;
				try
				{
					proxy.Zpvu_Rfc_Con_Pedido(Nro_Sap,Oficina,Referencia,Tipo_Documento,ref objDocumento, ref objLineaDocIMEI, ref objLineaDoc, ref objReturn, ref objServicioCont);
					
				}
				catch
				{
					for(cont=0; cont< cantIntentoSap;cont++ ) 
					{
						try
						{
							proxy.Zpvu_Rfc_Con_Pedido(Nro_Sap,Oficina,Referencia,Tipo_Documento,ref objDocumento, ref objLineaDocIMEI, ref objLineaDoc, ref objReturn, ref objServicioCont);
							break;
						}
						catch(Exception ex1)
						{
							if(cont == cantIntentoSap - 1)
							{
								throw ex1;
							} 
						}
					}
				}

				dsReturn.Tables.Add(objDocumento.ToADODataTable());
				dsReturn.Tables.Add(objLineaDoc.ToADODataTable());
				dsReturn.Tables.Add(objLineaDocIMEI.ToADODataTable());
				dsReturn.Tables.Add(objServicioCont.ToADODataTable());
				dsReturn.Tables.Add(objReturn.ToADODataTable());
				proxy.Connection.Close();

			}
			catch (Exception)
			{
				dsReturn = null;
			}

			return dsReturn;
		}
		public ItemGenerico ConsultarMaterial(string p_codigo_iccid_imei) 
		{
			string out_codigo, out_descripcion;

			ItemGenerico item = new ItemGenerico();
			try
			{
				SapGeneral proxy = ConectaSAP();

				proxy.Zsisa_Rfc_Con_Material(p_codigo_iccid_imei, out out_codigo, out out_descripcion);

				item.Codigo = out_codigo;
				item.Descripcion = out_descripcion;

				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return item;
		}
		public string ConsultarIccid(string Clase_Venta, string Nro_Telefono, string Tipo_Venta)
		{
			string Matnr;
			string Imei = "";
			string Fecha_Venta;

			try
			{
				SapGeneral proxy = ConectaSAP();

				BAPIRET2Table objRetorno = new BAPIRET2Table();
				proxy.Zpvu_Rfc_Con_Telefono_Sans(Clase_Venta,  Nro_Telefono, Tipo_Venta, out Fecha_Venta, out Imei, out Matnr, ref objRetorno);
				proxy.Connection.Close();
			}
			catch (Exception)
			{
				Imei = "0000000000000000";
			}
			return Imei;
		}
		public ArrayList Get_ConsultaCampana(string FechaVenta, string TipoVenta)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrCampana = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_CAMPANATable objCampana = new ZST_PV_CAMPANATable();
				proxy.Zpvu_Rfc_Mae_Campana(FechaVenta,TipoVenta,ref objCampana);
				dsReturn.Tables.Add(objCampana.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo  = Funciones.CheckStr(dr["CAMPANA"]);
						item.Descripcion =Funciones.CheckStr(dr["DESCRIPCION"]);
						arrCampana.Add(item);
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception)
			{
				dsReturn = null;
			}
			return arrCampana;
		}

		public string Get_Consulta_Prefijo(string Fecha_Documento, string Oficina_Venta, string Tipo_Documento)
		{
			string prefijo;
			try
			{
				SapGeneral proxy = ConectaSAP();
				proxy.Zpvu_Rfc_Con_Prefijo(FormatoFecha(Fecha_Documento),Oficina_Venta,Tipo_Documento,out prefijo);
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return prefijo;
		}

		public bool Set_EstadoAcuerdoPCS(string NroContrato, string Estado, string Usuario,string AnalistaCredito, string CodigoAprobacion,string TipoRechazo, string Observaciones, string NumeroHDC)
		{
			DataSet dsReturn = new DataSet();
			bool blnReturn = true;
			try
			{
				BAPIRET2Table objReturn = new BAPIRET2Table();

				SapGeneral proxy = ConectaSAP();
				proxy.Zpvu_Rfc_Trs_Act_Estado_Pcs(AnalistaCredito, CodigoAprobacion,Estado,"",NroContrato,NumeroHDC,Observaciones,TipoRechazo,Usuario,ref objReturn);
                        
				dsReturn.Tables.Add(objReturn.ToADODataTable());

				if (dsReturn.Tables[1].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[1].Rows)
					{						
						if (Funciones.CheckStr(dr["TYPE"]) == "E"){
							blnReturn = false;
							break;
						}									
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}

			return blnReturn;
		}

		public bool Get_RegistroAcuerdoPCS(string[] arrAcuerdo, string CadenaServAdic,out string Nro_Contrato, ref string mensaje)
		{
			DataSet dsReturn = new DataSet();
			bool valor = true;

			SapGeneral proxy = ConectaSAP();

			ZST_PV_DOCUMENTOTable objDocumento = new ZST_PV_DOCUMENTOTable();
			ZST_PV_LINEA_DOC_VENTATable objLineaDocumento = new ZST_PV_LINEA_DOC_VENTATable();			
			ZST_PV_SERVI_CONTRATable objServicios = new ZST_PV_SERVI_CONTRATable();
			ZST_PV_CONTRATOTable objContrato = new ZST_PV_CONTRATOTable();
			BAPIRET2Table objLog = new BAPIRET2Table();

			ZST_PV_SERVI_CONTRA objFilaServicios = new ZST_PV_SERVI_CONTRA();
			ZST_PV_CONTRATO objFilaContrato = new ZST_PV_CONTRATO();

			string[] strTrama1;
			string[] strTrama2;
			int intMax4=4;
			
			// La parte de generacion de acuerdo se deja de lado momentaneamente
			if (arrAcuerdo != null) 
			{
				if (arrAcuerdo.Length>0)
				{
					objFilaContrato.Numero_Contrato = arrAcuerdo [0];
					objFilaContrato.Oficina_Ventas = arrAcuerdo [1];
					objFilaContrato.Numero_Pcs = arrAcuerdo [2];
					objFilaContrato.Fecha_Contrato = FormatoFecha(arrAcuerdo [3]);
					objFilaContrato.Plazo_Acuerdo = arrAcuerdo [4];
					objFilaContrato.Fact_Nombre = arrAcuerdo [5];
					objFilaContrato.Fact_Apel_Pat = arrAcuerdo [6];
					objFilaContrato.Fact_Ape_Mat = arrAcuerdo [7];
					objFilaContrato.Fact_R_Social = arrAcuerdo [8];
					objFilaContrato.Codigo_Aprobacio = arrAcuerdo [9];
					objFilaContrato.Resultado = arrAcuerdo [10];
					objFilaContrato.Impreso = arrAcuerdo [11];
					objFilaContrato.Fecha_Registro = FormatoFecha(arrAcuerdo [12]);
					objFilaContrato.Fecha_Actualiz = FormatoFecha(arrAcuerdo [13]);
					objFilaContrato.Doc_Sustento = arrAcuerdo [14];
					objFilaContrato.Tarjeta_Credito = arrAcuerdo [15];
					objFilaContrato.Num_Tarj_Credito = arrAcuerdo [16];
					objFilaContrato.Moneda_Tcred = arrAcuerdo [17];
					objFilaContrato.Linea_Credito = FormatoDec(arrAcuerdo [18]);
					objFilaContrato.Fecha_Venc_Tcred = arrAcuerdo [19];
					objFilaContrato.Vendedor = arrAcuerdo [20];
					objFilaContrato.Telefono_Vendedo = arrAcuerdo [21];
					objFilaContrato.Documento = arrAcuerdo [22];
					objFilaContrato.Via_Pago = arrAcuerdo [23];
					objFilaContrato.Debito_Automati = arrAcuerdo [24];
					objFilaContrato.Analista_Credito = arrAcuerdo [25];
					objFilaContrato.Migracion = arrAcuerdo [26];
					objFilaContrato.Estado = arrAcuerdo [27];
					objFilaContrato.Cod_Observacion = arrAcuerdo [28];
					objFilaContrato.Observaciones = arrAcuerdo [29];
					objFilaContrato.Tipo_Rechazo = arrAcuerdo [30];
					objFilaContrato.Via_Dsf = arrAcuerdo [31];
					objFilaContrato.Tipo_Doc_Cliente = arrAcuerdo [32];
					objFilaContrato.Cliente = arrAcuerdo [33];
					objFilaContrato.Telef_Renov = arrAcuerdo [34];
					objFilaContrato.Plan_Renov = arrAcuerdo [35];
					objFilaContrato.Renovacion = arrAcuerdo [36];
					objFilaContrato.Codigo_Banco = arrAcuerdo [37];
					objFilaContrato.Nro_Clarify = arrAcuerdo [38];
					objFilaContrato.Numero_Hdc = arrAcuerdo [39];
					objFilaContrato.Reposicion =  arrAcuerdo [40];
					objFilaContrato.Campana = arrAcuerdo [41];
					objFilaContrato.Aprobador = arrAcuerdo [42];
					objFilaContrato.Lim_Credito = FormatoDec(arrAcuerdo [43]);
					objFilaContrato.Eval_Cred_Manual = arrAcuerdo [44];
					objFilaContrato.Score_Crediticio = arrAcuerdo [45];
					objFilaContrato.Control_Fraude = arrAcuerdo [46];
					objFilaContrato.Nro_Carpeta_Obs = arrAcuerdo [47];
					objFilaContrato.Nro_Contrato_Ant = arrAcuerdo [48];
					objFilaContrato.Operador = arrAcuerdo [49];
					objFilaContrato.Plan_Anterior = arrAcuerdo [50];
					objFilaContrato.Nro_Ope_Infocorp = arrAcuerdo [51];
					objFilaContrato.Cs_Large = arrAcuerdo [52];
					objFilaContrato.Cs_Subcuenta = arrAcuerdo [53];
					objFilaContrato.Lim_Cred_Max = FormatoDec(arrAcuerdo [54]);
					objFilaContrato.Sum_Planes_Actua = FormatoDec(arrAcuerdo [55]);
					objFilaContrato.Sum_Planes_Vendi = FormatoDec(arrAcuerdo [56]);
					objFilaContrato.Respons_Pago = arrAcuerdo [57];
					objFilaContrato.Existe_Bscs = arrAcuerdo [58];
					objFilaContrato.Tipo_Activ_Clte =  arrAcuerdo [59];
					objFilaContrato.Activacion_Linea = arrAcuerdo [60];
					objFilaContrato.Acuerdo_Manual = arrAcuerdo [61];
					objFilaContrato.Tipo_Cli_Act = arrAcuerdo [62];
					objFilaContrato.Tipo_Vta_Ori = arrAcuerdo [63];
					objFilaContrato.Motivo_Mig = arrAcuerdo [64];
					objFilaContrato.Con_Sin_Eq = arrAcuerdo [65];
					//objFilaContrato.Motivo_Repos = arrAcuerdo [66];

					objContrato.Add (objFilaContrato);
					objFilaContrato = null;

				}
			}

			
			if (CadenaServAdic.Length > 0)
			{
				strTrama1 = CadenaServAdic.Split('|');
				for (int i=0;i<strTrama1.Length;i++)
				{
					strTrama2 = strTrama1[i].Split(';',(char)intMax4);
					objFilaServicios = null;
					objFilaServicios = new ZST_PV_SERVI_CONTRA();

					objFilaServicios.Documento  = strTrama2[0];
					objFilaServicios.Consecutivo = strTrama2[1];
					objFilaServicios.Servicio_Solicit = strTrama2[2];
					objFilaServicios.Valor_Selecciona = strTrama2[3];

					objServicios.Add(objFilaServicios);
				}
			}
						
			proxy.Zpvu_Rfc_Trs_Contrato_Pcs(out Nro_Contrato,ref objContrato,ref objDocumento ,ref objLineaDocumento,ref objLog,ref objServicios);
			
			dsReturn.Tables.Add(objDocumento.ToADODataTable());
			dsReturn.Tables.Add(objLog.ToADODataTable());

			if (dsReturn.Tables[1].Rows.Count>0)
			{	
				foreach(DataRow dr in dsReturn.Tables[1].Rows)
				{
					string tipo = Funciones.CheckStr(dr["TYPE"]);
					if (tipo == "E")
					{
						mensaje =  Funciones.CheckStr(dr["MESSAGE"]);
						valor = false;
					}		
				}
			}
			proxy.Connection.Close();

			/*}
			catch (Exception ex)
			{
				dsReturn = null;
				strEntrega = "";
			strFactura = "";
			strNroContrato = "";
			strNroDocCliente = "";
			strNroPedido = "";
			strRefHistorico = "";
			strTipDocCliente = "";
			dblValorDescuento  = 0;
			}*/

			return valor;
		}
		public ArrayList ConsultarListaVendedores(string p_oficina_venta)
		{
			DataSet dsReturn = new DataSet();
			ArrayList lista = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_VENDEDORTable objListaVendedores = new ZST_PV_VENDEDORTable();

				proxy.Zpvu_Rfc_Mae_Vendedor(p_oficina_venta, ref objListaVendedores);
				dsReturn.Tables.Add(objListaVendedores.ToADODataTable());

				proxy.Connection.Close();

				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo = Funciones.CheckStr(dr["USUARIO"]);
						item.Descripcion = Funciones.CheckStr(dr["NOMBRE"]);
						lista.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return lista;
		}

		public ArrayList get_ConsultaMaterial(string FechaVenta, string Material, string TipoVenta, string Oficina, string ClaseVenta)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrArticulo = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_ARTICULOTable objArticulos = new ZST_PV_ARTICULOTable();
				proxy.Zpvu_Rfc_Mae_Articulo(ClaseVenta,FechaVenta,Material,Oficina,TipoVenta,ref objArticulos);
				dsReturn.Tables.Add(objArticulos.ToADODataTable());
				if(dsReturn.Tables[0].Rows.Count > 0)
				{
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico();					
						item.Codigo = Funciones.CheckStr(dr["MATNR"]);
						item.Descripcion = Funciones.CheckStr(dr["MAKTX"]);						
						arrArticulo.Add(item);
					}
				}
				proxy.Connection.Close();
			}
			catch(Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return arrArticulo;
		}

		public DataSet get_ConsultaHistoria(string Flag, string Nro_Telefono, string Oficina_Venta)
		{
			DataSet dsReturn = new DataSet();
			try
			{
				ZST_PV_HIST_CLIENTETable objParam = new ZST_PV_HIST_CLIENTETable(); //ZST_PV_PARAM_OF_VTATable();
				BAPIRET2Table objRetorno = new BAPIRET2Table();

				SapGeneral proxy = ConectaSAP();

				proxy.Zpvu_Rfc_Con_Hist_X_Nro_Telef(Flag, Nro_Telefono, Oficina_Venta, ref objParam, ref objRetorno);
				
				dsReturn.Tables.Add(objParam.ToADODataTable());
				dsReturn.Tables.Add(objRetorno.ToADODataTable());
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}

			return dsReturn;
		}

		public ArrayList Get_ConsultaMotivosReposicion( string Motivo)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrMotivo = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_MOTIVO_PEDIDOTable objMotivo = new ZST_PV_MOTIVO_PEDIDOTable();
				proxy.Zpvu_Rfc_Mae_Motivo_Reposicion(Motivo,ref objMotivo);
				dsReturn.Tables.Add(objMotivo.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo  = Funciones.CheckStr(dr["AUGRU"]);
						item.Descripcion = Funciones.CheckStr(dr["BEZEI"]);
						arrMotivo.Add(item);
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return arrMotivo;
		}
		
		public ArrayList Get_ObtenerMaterialesPDV( string p_tipo_operacion, string p_fecha,string p_codigo_material, string p_oficina_venta, string p_tipo_venta)
		{

			DataSet dsReturn = new DataSet();
			ArrayList arrArticulo = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_ARTICULOTable objArticulo = new ZST_PV_ARTICULOTable();
				proxy.Zpvu_Rfc_Mae_Articulo(p_tipo_operacion,p_fecha,p_codigo_material,p_oficina_venta,p_tipo_venta,ref objArticulo);
				dsReturn.Tables.Add(objArticulo.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo  = Funciones.CheckStr(dr["MATNR"]);
						item.Descripcion = Funciones.CheckStr(dr["MAKTX"]);
						//item.Tipo = Funciones.CheckStr(dr["SERN"]);
						item.Descripcion2 = Funciones.CheckStr(dr["MATKL"]);
						arrArticulo.Add(item);
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{

				dsReturn = null;
				throw ex;
			}
			return arrArticulo;
		}

		public ArrayList Get_ConsultaPlanTarifario(string tipoClienteAct,string Utilizacion, string TipoVenta, string CodPlan)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrPlanTarifario = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_PLAN_TARIFARIOTable objPlanTar = new ZST_PV_PLAN_TARIFARIOTable();
				proxy.Zpvu_Rfc_Mae_Plan_Tarifario(tipoClienteAct,TipoVenta,Utilizacion, ref objPlanTar);
				dsReturn.Tables.Add(objPlanTar.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					if (CodPlan != "")
					{
						foreach(DataRow dr in dsReturn.Tables[0].Rows)
						{
							if (Funciones.CheckDecimal(CodPlan)>= Funciones.CheckDecimal(dr["CARGO_FIJO"]))
							{
								Plan item = new Plan(); 
								item.PLANC_CODIGO = Funciones.CheckStr(dr["PLAN_TARIFARIO"]);
								item.PLANV_DESCRIPCION =Funciones.CheckStr(dr["DESCRIPCION"]);
								item.PLANC_ESTADO = Funciones.CheckStr(dr["FLAG_VIGENCIA"]);
								item.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["CARGO_FIJO"]);
								item.TCLIC_CODIGO = Funciones.CheckStr(dr["TIPO_CLI_ACT"]);
								arrPlanTarifario.Add(item);
							}
						}
					}
					else
					{
						foreach(DataRow dr in dsReturn.Tables[0].Rows)
						{
							Plan item = new Plan(); 
							item.PLANC_CODIGO  = Funciones.CheckStr(dr["PLAN_TARIFARIO"]);
							item.PLANV_DESCRIPCION =Funciones.CheckStr(dr["DESCRIPCION"]);
							item.PLANC_ESTADO = Funciones.CheckStr(dr["FLAG_VIGENCIA"]);
							item.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["CARGO_FIJO"]);
							item.TCLIC_CODIGO = Funciones.CheckStr(dr["TIPO_CLI_ACT"]);
							arrPlanTarifario.Add(item);
						}
					}
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return arrPlanTarifario;
		}
		public string ConsultarPrefijo(string p_fecha_documento, string p_oficina_venta, string p_tipo_documento)
		{
			string out_prefijo;
			try
			{
				SapGeneral proxy = ConectaSAP();
				proxy.Zpvu_Rfc_Con_Prefijo(p_fecha_documento, p_oficina_venta, p_tipo_documento, out out_prefijo);
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return out_prefijo;
		}
	
		public DataSet ConsultarAcuerdo(string p_nro_contrato, string p_nro_contrato_pcs)
		{
			DataSet dsReturn = new DataSet();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_CONSULTA_CONTRATOTable objAcuerdo = new ZST_PV_CONSULTA_CONTRATOTable();
				ZST_PV_DET_ACUERDOTable objDetalleAcuerdo = new ZST_PV_DET_ACUERDOTable();
				ZST_PV_SERVICIOS_ACUERDOTable objServicios = new ZST_PV_SERVICIOS_ACUERDOTable();
				ZST_PV_CLIENTETable objCliente = new ZST_PV_CLIENTETable();
				BAPIRET2Table objRetorno = new BAPIRET2Table();

				int cantIntentoSap = Funciones.CheckInt(ConfigurationSettings.AppSettings["consultaIntentosSAP"]);			
				int cont=0;
				try
				{
					proxy.Zpvu_Rfc_Con_Acuerdo(p_nro_contrato, p_nro_contrato_pcs, ref objAcuerdo, ref objCliente, ref objDetalleAcuerdo, ref objRetorno, ref objServicios);
					
				}
				catch
				{
					for(cont=0; cont< cantIntentoSap;cont++ ) 
					{
						try
						{
							proxy.Zpvu_Rfc_Con_Acuerdo(p_nro_contrato, p_nro_contrato_pcs, ref objAcuerdo, ref objCliente, ref objDetalleAcuerdo, ref objRetorno, ref objServicios);
							break;
						}
						catch(Exception ex1)
						{
							if(cont == cantIntentoSap - 1)
							{
								throw ex1;
							} 
						}
					}
				}	

				dsReturn.Tables.Add(objAcuerdo.ToADODataTable());
				dsReturn.Tables.Add(objDetalleAcuerdo.ToADODataTable());
				dsReturn.Tables.Add(objServicios.ToADODataTable());
				dsReturn.Tables.Add(objCliente.ToADODataTable());
				dsReturn.Tables.Add(objRetorno.ToADODataTable());

				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return dsReturn;
		}

		public ItemGenerico ConsultarEstadoCivil(string p_est_civil_codigo)
		{
			DataSet dsReturn = new DataSet();
			ItemGenerico item = new ItemGenerico();
			try
			{
				SapGeneral proxy = ConectaSAP();

				ZST_PV_EST_CIVILTable objEstadoCivil = new ZST_PV_EST_CIVILTable();
				proxy.Zpvu_Rfc_Mae_Est_Civil(ref objEstadoCivil);

				dsReturn.Tables.Add(objEstadoCivil.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						string codigo = Funciones.CheckStr(dr["FAMST"]);
						if (codigo == p_est_civil_codigo) 
						{
							item.Codigo = Funciones.CheckStr(dr["FAMST"]);
							item.Descripcion = Funciones.CheckStr(dr["FTEXT"]);
							break;
						}
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return item;
		}

		public void ConsultarUbigeo(string p_ubigeo, out string dep_cod, out string dep_desc, out string prov_cod, out string prov_desc,
			out string dist_cod, out string dist_desc, out string codigo_postal)
		{
			try
			{
				SapGeneral proxy = ConectaSAP();

				proxy.Zpvu_Rfc_Con_Ubigeo(p_ubigeo, out dep_cod, out dist_cod, out prov_cod, out codigo_postal, out dep_desc, out dist_desc,
					out prov_desc);

				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dep_cod = "";
				dist_cod = "";
				prov_cod = "";
				codigo_postal = "";
				dep_desc = "";
				dist_desc = "";
				prov_desc = "";

				throw ex;
			}
			return;
		}

		public ItemGenerico ConsultarPlazoAcuerdo(string p_plazo_codigo)
		{
			DataSet dsReturn = new DataSet();
			ItemGenerico item = new ItemGenerico();
			try
			{
				SapGeneral proxy = ConectaSAP();

				ZST_PV_PLAZO_ACUERDOTable objPlazoAcuerdo = new ZST_PV_PLAZO_ACUERDOTable();
				proxy.Zpvu_Rfc_Mae_Plazo_Acuerdo(ref objPlazoAcuerdo);

				dsReturn.Tables.Add(objPlazoAcuerdo.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						string codigo = Funciones.CheckStr(dr["PLAZO_ACUERDO"]);
						if (codigo == p_plazo_codigo) 
						{
							item.Codigo = Funciones.CheckStr(dr["PLAZO_ACUERDO"]);
							item.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
							item.Codigo2 = Funciones.CheckStr(dr["ACTIVO"]);
							item.Descripcion2 = Funciones.CheckStr(dr["PRIORIDAD"]);
							break;
						}
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return item;
		}

		// Agregado -EMC-
		public ArrayList get_seriesxMaterial(string oficina,string material,string resultados,string telefono)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrSeries = new ArrayList();

			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PVU_IMEISTable objArticulos = new ZST_PVU_IMEISTable();
				BAPIRET2Table objbapiret = new BAPIRET2Table();
				proxy.Zpvu_Rfc_Con_Imeis(material,resultados,telefono,oficina,ref objArticulos,ref objbapiret);
				dsReturn.Tables.Add(objArticulos.ToADODataTable());
				dsReturn.Tables.Add(objbapiret.ToADODataTable());
				if(dsReturn.Tables[0].Rows.Count > 0)
				{
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico();							
						item.Codigo = Funciones.CheckStr(dr["SERNR"]);
						item.Descripcion = Funciones.CheckStr(dr["NRO_TELEF"]);
						item.Codigo2 = Funciones.CheckStr(dr["MATNR"]);
						arrSeries.Add(item);
					}
				}
				proxy.Connection.Close();
			}
			catch(Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return arrSeries;
		}


		//ZPVU_RFC_TRS_ANULA_PEDIDO_SAP
		public DataSet Set_AnularDocumentoJob(string CadenaDocumento, string Usuario) 
		{
			DataSet dsReturn;
			try
			{
				
				ZST_PV_LOGTable objReturn = new ZST_PV_LOGTable();
				ZST_PV_REPLICATable objReplica = new ZST_PV_REPLICATable();
				SapGeneral proxy = ConectaSAP();
				

				ZST_PV_REPLICA objReplicaFila = new ZST_PV_REPLICA();
				string[]  strTrama;
				
				strTrama = CadenaDocumento.Split(';',(char)43);
				
				if (CadenaDocumento.Length>0)
				{
					if (strTrama.Length>0) objReplicaFila.Borra = strTrama[0];
					if (strTrama.Length>1) objReplicaFila.Auart = strTrama[1];
					if (strTrama.Length>2) objReplicaFila.Vkorg = strTrama[2];
					if (strTrama.Length>3) objReplicaFila.Vtweg = strTrama[3];
					if (strTrama.Length>4) objReplicaFila.Spart = strTrama[4];
					if (strTrama.Length>5) objReplicaFila.Vkbur = strTrama[5];
					if (strTrama.Length>6) objReplicaFila.Vkgrp = strTrama[6];			
					if (strTrama.Length>7) objReplicaFila.Xblnr = strTrama[7];
					if (strTrama.Length>8) objReplicaFila.Kunnr = strTrama[8];
					if (strTrama.Length>9) objReplicaFila.Augru = strTrama[9];
					if (strTrama.Length>10) objReplicaFila.Mot_Repo = strTrama[10];				
					if (strTrama.Length>11) objReplicaFila.Mvgr4 = strTrama[11];
					if (strTrama.Length>12) objReplicaFila.Nro_Clarif = strTrama[12];
					if (strTrama.Length>13) objReplicaFila.Nro_Cuotas = strTrama[13];
					if (strTrama.Length>14) objReplicaFila.Tipo_Venta_Pvu = strTrama[14];
					if (strTrama.Length>15) objReplicaFila.Audat = strTrama[15];
					if (strTrama.Length>16) objReplicaFila.Prsdt = strTrama[16];
					if (strTrama.Length>17) objReplicaFila.Ihrez_E = strTrama[17];
					if (strTrama.Length>18) objReplicaFila.Interloc = strTrama[18];
					if (strTrama.Length>19) objReplicaFila.Dwerk = strTrama[19];
					if (strTrama.Length>20) objReplicaFila.Zterm = strTrama[20];
					if (strTrama.Length>21) objReplicaFila.Mabnr = strTrama[21];
					if (strTrama.Length>22) objReplicaFila.Kwmeng = strTrama[22];
					if (strTrama.Length>23) objReplicaFila.Pltyp = strTrama[23];
					if (strTrama.Length>24) objReplicaFila.Mvgr3 = strTrama[24];
					if (strTrama.Length>25) objReplicaFila.Vkaus = strTrama[25];
					if (strTrama.Length>26) objReplicaFila.Lgort = strTrama[26];
					if (strTrama.Length>27) objReplicaFila.Sernr = strTrama[27];
					if (strTrama.Length>28) objReplicaFila.Nro_Telef = strTrama[28];
					if (strTrama.Length>29) objReplicaFila.Campana = strTrama[29];
					if (strTrama.Length>30) objReplicaFila.Plan_Tarifario = strTrama[30];
					if (strTrama.Length>31) objReplicaFila.Nro_Clarify = strTrama[31];
					if (strTrama.Length>32) objReplicaFila.Vstel = strTrama[32];
					if (strTrama.Length>33) objReplicaFila.Kondm = strTrama[33];
					if (strTrama.Length>34) objReplicaFila.Clase_Venta = strTrama[34];

					if (strTrama.Length>35) objReplicaFila.Ref_Origen = strTrama[35];
					if (strTrama.Length>36) objReplicaFila.Nro_Pcs_Asociado = strTrama[36];
					if (strTrama.Length>37) objReplicaFila.Nro_Ped_Tg = strTrama[37];
					if (strTrama.Length>38) objReplicaFila.Nro_Acuer_Alqu = strTrama[38];
					if (strTrama.Length>39) objReplicaFila.Fidelizacion = strTrama[39];

					if (strTrama.Length>40) objReplicaFila.Nro_Solicitud = strTrama[40];
					if (strTrama.Length>41) objReplicaFila.Serie_Recibida = strTrama[41];
					if (strTrama.Length>42) objReplicaFila.Operador = strTrama[42];
					if (strTrama.Length>43) objReplicaFila.Tipo_Prod_Operad = strTrama[43];
					objReplica.Add(objReplicaFila);
				}

				proxy.Zpvu_Rfc_Trs_Anula_Pedido_Sap(Usuario,ref objReturn,ref objReplica);
				dsReturn = new DataSet();
				dsReturn.Tables.Add(objReplica.ToADODataTable());				
				dsReturn.Tables.Add(objReturn.ToADODataTable());
				proxy.Connection.Close();
			}
			catch
			{
				dsReturn=null;
			}
			return dsReturn;
			
		}


		//ZPVU_RFC_TRS_ACT_ESTADO_PEDIDO

		public  Boolean Set_ActualizaEstadoPedido(string NroPedido, string OficinaVenta, string Almacenero, string Despachador )
		{
			Boolean retorno = true;

		
			DataSet dsReturn = new DataSet();
			try
			{
				BAPIRET2Table objReturn = new BAPIRET2Table();

				SapGeneral proxy = ConectaSAP();

				proxy.Zpvu_Rfc_Trs_Act_Estado_Pedido(Almacenero,Despachador, NroPedido, OficinaVenta, ref objReturn);
				
				dsReturn.Tables.Add(objReturn.ToADODataTable());
				proxy.Connection.Close();

				if (dsReturn.Tables[0].Rows.Count>0) 
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows) 
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E") 
						{
							retorno = false;
							throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
						}
					}
				}

			}
			catch (Exception ex)
			{
				
				dsReturn = null;
				throw ex;
			}
			
			return retorno;
		}


		//ZPVU_RFC_CON_CAJA_CERRADA

		public DataSet Get_ConsultaCierreCaja(string p_oficinaVenta, string p_fecha, out string v_cierre_realizado )
		{
			
			string usuario = "";

			DataSet dsReturn = new DataSet();
			try
			{
				BAPIRET2Table objReturn = new BAPIRET2Table();

				SapGeneral proxy = ConectaSAP();
				
				

				proxy.Zpvu_Rfc_Con_Caja_Cerrada(FormatoFecha(p_fecha), p_oficinaVenta , usuario, out v_cierre_realizado,  ref objReturn);
				
				dsReturn.Tables.Add(objReturn.ToADODataTable());
				proxy.Connection.Close();

				if (dsReturn.Tables[0].Rows.Count>0) 
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows) 
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E") 
						{
							throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
						}
					}
				}

			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}

			return dsReturn;
		}

//		public ArrayList get_ConsultaMaterialRe(string pstrCampana, string pstrPDV, string pstrOrgVenta, string pstrCentro, string pstrPlan, ref int pintRC)
//		{
//			DataSet dsReturn = new DataSet();
//			ArrayList arrArticulo = new ArrayList();
//			try
//			{
//				SapGeneral proxy = ConectaSAP();
//				ZMATNR_LISTTable objArticulos = new ZMATNR_LISTTable();
//				proxy.Zpvu_Material_X_Campana(pstrCampana, 1, pstrPDV, pstrPlan, pstrOrgVenta, pstrCentro, out pintRC, ref objArticulos);
//				dsReturn.Tables.Add(objArticulos.ToADODataTable());
//				if(dsReturn.Tables[0].Rows.Count > 0)
//				{
//					foreach(DataRow dr in dsReturn.Tables[0].Rows)
//					{
//						ItemGenerico item = new ItemGenerico();					
//						item.Codigo = Funciones.CheckStr(dr["MATNR"]);
//						item.Descripcion = Funciones.CheckStr(dr["MAKTX"]);						
//						item.Descripcion = item.Descripcion.Replace("PACK BASICO ", "");
//
//						if (item.Codigo.Substring(0,2) != "PS")
//							arrArticulo.Add(item);
//					}
//				}
//				proxy.Connection.Close();
//			}
//			catch(Exception ex)
//			{
//				dsReturn = null;
//				throw ex;
//			}
//			return arrArticulo;
//		}

		//Renovacion
		public ArrayList get_ConsultaMaterialRe(string pstrCampana, string pstrPDV, string pstrOrgVenta, string pstrCentro, string pstrPlan, ref int pintRC)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrArticulo = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZMATNR_LISTTable objArticulos = new ZMATNR_LISTTable();
				proxy.Zpvu_Material_X_Campana(pstrCampana, 1, pstrPDV, pstrPlan, pstrOrgVenta, pstrCentro, out pintRC, ref objArticulos);
				dsReturn.Tables.Add(objArticulos.ToADODataTable());
				if(dsReturn.Tables[0].Rows.Count > 0)
				{
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico();					
						item.Codigo = Funciones.CheckStr(dr["MATNR"]);
						item.Descripcion = Funciones.CheckStr(dr["MAKTX"]);						
						item.Descripcion = item.Descripcion.Replace("PACK BASICO ", "");

						if (item.Codigo.Substring(0,2) != "PS")
							arrArticulo.Add(item);
					}
				}
				proxy.Connection.Close();
			}
			catch(Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return arrArticulo;
		}

		public ArrayList Get_ConsultaCampana_X_Plan(string pstrPlan, ref int pintRC)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrCampana = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PV_CAMPANATable objCampana = new ZST_PV_CAMPANATable();
				proxy.Zpvu_Campana_X_Plan(pstrPlan, out pintRC, ref objCampana);
				dsReturn.Tables.Add(objCampana.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo  = Funciones.CheckStr(dr["CAMPANA"]);
						item.Descripcion =Funciones.CheckStr(dr["DESCRIPCION"]);
						arrCampana.Add(item);
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return arrCampana;
		}

		public DataTable Get_CostoPromedio(string PGRUPO, string PMATNR, string PWERKS)
		{
			DataTable dtResultado = new DataTable();
						try
						{
							ZMM_VALOR_PROMEDIOTable objTabla = new ZMM_VALOR_PROMEDIOTable();	
							SapGeneral proxy = ConectaSAP();	
			
							proxy.Zmm_Valor_Promedio(PGRUPO, PMATNR, PWERKS, ref objTabla);
			
							dtResultado = objTabla.ToADODataTable();
							proxy.Connection.Close();
						}
						catch
						{
							dtResultado = null;
						}
			
			return dtResultado;
		}

		public ArrayList ConsultarLPrecio(string p_canal, string p_tipo_doc_venta, string p_tipo_venta, string p_plan_tarif, string p_codigo_material, string p_codigo_campania,
										  string p_org_venta, string p_fecha, string p_tipo_operacion, string p_plazo_acuerdo, string p_oficina)
		{
			DataSet dsReturn = new DataSet();
			ArrayList lista = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZWA_UTILIZACION_1Table objListaPrecios = new ZWA_UTILIZACION_1Table();
				BAPIRET2Table objRetorno = new BAPIRET2Table();

				proxy.Zsisa_Rfc_Con_Lista_Precio_1(p_canal, p_tipo_doc_venta, p_codigo_campania, p_codigo_material, p_fecha, p_tipo_venta, p_oficina, p_org_venta,
					p_plan_tarif, p_tipo_operacion, ref objRetorno, ref objListaPrecios);
				dsReturn.Tables.Add(objListaPrecios.ToADODataTable());
				dsReturn.Tables.Add(objRetorno.ToADODataTable());

				proxy.Connection.Close();

				VentaExpressDatos obj = new VentaExpressDatos();
				ArrayList listaprecio = new ArrayList();

				//Consulta tabla lista_precios/plazo_acuerdo
				listaprecio = obj.ConsultaLPreciosporPlazo(p_plazo_acuerdo);

				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo = Funciones.CheckStr(dr["ABRVW"]);
						item.Descripcion = Funciones.CheckStr(dr["BEZEI"]);
						item.Valor = Funciones.CheckDbl(dr["PRECIOIGV"]);
						
						foreach(ItemGenerico lista_precio in listaprecio) 
						{
							if (item.Codigo == lista_precio.Codigo) 
							{
								lista.Add(item);
								break;
							}
						}
					}	
				}

				if (dsReturn.Tables[1].Rows.Count>0)
				{
					foreach(DataRow dr in dsReturn.Tables[1].Rows)
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E")
						{
							throw new Exception("SAP. La combinacion Tipo Venta, Plan, Material CHIP/Equipo, Campaña; no esta configurada en el Sistema.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return lista;
		}

		public ArrayList ConsultarListaPreciosRP(string p_tipo_venta, string p_plan_tarif, string p_codigo_material, string p_codigo_campania,
			string p_org_venta, string p_fecha, string p_tipo_operacion)
		{
			DataSet dsReturn = new DataSet();
			ArrayList lista = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				ZWA_UTILIZACIONTable objListaPrecios = new ZWA_UTILIZACIONTable();
				BAPIRET2Table objRetorno = new BAPIRET2Table();
				proxy.Zsisa_Rfc_Con_Lista_Precio(p_codigo_campania, p_codigo_material, p_fecha, p_tipo_venta, p_org_venta,
					p_plan_tarif, p_tipo_operacion, ref objRetorno, ref objListaPrecios);
				dsReturn.Tables.Add(objListaPrecios.ToADODataTable());
				dsReturn.Tables.Add(objRetorno.ToADODataTable());

				proxy.Connection.Close();

				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo = Funciones.CheckStr(dr["ABRVW"]);
						item.Descripcion = Funciones.CheckStr(dr["BEZEI"]);
						lista.Add(item);
					}	
				}
				if (dsReturn.Tables[1].Rows.Count>0)
				{
					foreach(DataRow dr in dsReturn.Tables[1].Rows)
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E")
						{
							//throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
							throw new Exception("SAP. La combinacion Tipo Venta, Plan, Material CHIP/Equipo, Campaña; no esta configurada en el Sistema.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return lista;
		}

		public ArrayList Get_ConsultaPlanServicio(string plan, string servicio)
		{
			DataSet dsReturn = new DataSet();
			ArrayList arrServicios = new ArrayList();
			try	
			{
				SapGeneral proxy = ConectaSAP();
				ZST_PLAN_SERVTable objServicios = new ZST_PLAN_SERVTable();
				proxy.Zpvu_Rfc_Mae_Plan_X_Servicios(plan,servicio,ref objServicios);
				dsReturn.Tables.Add(objServicios.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						SecServicio_AP oServ = new SecServicio_AP(); 
						oServ.SERVV_CODIGO = Funciones.CheckStr(dr["Servicio_Solicit"]);
						oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr["DESCRIPCION"]);
						oServ.CARGO_FIJO_BASE = Funciones.CheckFloat(dr["Cargo_Fijo"]);
						oServ.DESCUENTO_EN_PLAN = 0;
						oServ.GSRVC_CODIGO = Funciones.CheckStr(dr["Grupo"]);
						oServ.SERVN_ORDEN = Funciones.CheckInt(dr["Orden"]);
						oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["Seleccionable"]);
						if (oServ.SELECCIONABLE_BASE == "1")
							oServ.SELECCIONABLE_BASE = "2";
						oServ.SELECCIONABLE_EN_PLAN = Funciones.CheckStr(dr["Seleccionable"]);
						oServ.PLAN.PLNV_CODIGO = plan;
						oServ.TSERVC_CODIGO = oServ.SERVN_ORDEN + "_" + oServ.GSRVC_CODIGO + "_" + oServ.SELECCIONABLE_BASE + "_" + oServ.SERVV_CODIGO + "_" + oServ.CARGO_FIJO_BASE;
						arrServicios.Add(oServ);
					}	
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return arrServicios;
		}

		//Chip Repuesto Postpago
		public ArrayList ConsultarListaPreciosMaestro(string p_codigo_articulo, string p_codigo_campana, string p_fecha_Venta, string p_tipo_operacion,
			string p_tipo_Venta)
		{
			DataSet dsReturn = new DataSet();
			ArrayList lista = new ArrayList();
			try
			{
				SapGeneral proxy = ConectaSAP();
				//ZWA_UTILIZACIONTable objListaPrecios = new ZWA_UTILIZACIONTable();
				ZST_PV_UTILIZACIONTable objListaPrecios = new ZST_PV_UTILIZACIONTable();
				proxy.Zpvu_Rfc_Mae_Utilizacion(p_codigo_articulo, p_codigo_campana, p_fecha_Venta, p_tipo_operacion, p_tipo_Venta, ref objListaPrecios);
				dsReturn.Tables.Add(objListaPrecios.ToADODataTable());
				proxy.Connection.Close();

				if (dsReturn.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						ItemGenerico item = new ItemGenerico(); 
						item.Codigo = Funciones.CheckStr(dr["ABRVW"]);
						item.Descripcion = Funciones.CheckStr(dr["BEZEI"]);
						lista.Add(item);			
					}
				}
			}
			catch (Exception ex)
			{
				dsReturn = null;
				throw ex;
			}
			return lista;
		}

		//Sans
		public string ConsultarIccid_Zs(string Clase_Venta, string Nro_Telefono, string Tipo_Venta, string Fecha_Cambio, string Material, string Material_Antig, string Serie)
		{
			string Matnr;
			string Imei = "";
			string Fecha_Venta;

			try
			{
				SapGeneral proxy = ConectaSAP();

				BAPIRET2Table objRetorno = new BAPIRET2Table();
				proxy.Zpvu_Rfc_Con_Telefono_Sans_Zs(Clase_Venta, Fecha_Cambio, Material, Material_Antig, Nro_Telefono, Serie, Tipo_Venta, out Fecha_Venta, out Imei, out Matnr, ref objRetorno);
				proxy.Connection.Close();
			}
			catch (Exception)
			{
				Imei = "0000000000000000";
			}
			return Imei;
		}
		//Sans

		//consolidado 21012015

		public bool CrearDepositoGarantia(string CadenaDeposito, out string NroDeposito)
		{
			DataSet dsReturn = new DataSet();
			bool valor = true;
			string[] strTrama;
			int intMax;
			try
			{				
				ZST_DEP_GARANTIATable objDepGarant = new ZST_DEP_GARANTIATable();
				ZST_DEP_GARANTIA objLineaDepGarant = new ZST_DEP_GARANTIA();
				BAPIRET2Table objLog = new BAPIRET2Table();

				intMax = 23;
				strTrama = CadenaDeposito.Split(';',(char)intMax);
				
				if (CadenaDeposito.Length > 0)
				{
					objLineaDepGarant.Nro_Dep_Garantia  = strTrama[0];
					objLineaDepGarant.Tipo_Doc_Cliente = strTrama[1];
					objLineaDepGarant.Cliente  = strTrama[2];
					objLineaDepGarant.Fecha_Deposito  = FormatoFecha(strTrama[3]);
					objLineaDepGarant.Fecha_Vencimient  = FormatoFecha(strTrama[4]);
					objLineaDepGarant.Numero_Contrato = strTrama[5];
					objLineaDepGarant.Documento = strTrama[6];
					objLineaDepGarant.Belnr = strTrama[7];
					objLineaDepGarant.Xblnr = strTrama[8];
					objLineaDepGarant.Monto_Deposito = FormatoDec(strTrama[9]);
					objLineaDepGarant.Oficina_Venta = strTrama[10];
					objLineaDepGarant.Anulado = strTrama[11];
					objLineaDepGarant.Usu_Creacion = strTrama[12];
					objLineaDepGarant.Fec_Creacion  = strTrama[13];
					objLineaDepGarant.Hor_Creacion = strTrama[14];
					objLineaDepGarant.Usu_Modifica  = strTrama[15];
					objLineaDepGarant.Fec_Modifica  = strTrama[16];
					objLineaDepGarant.Hor_Modifica  = strTrama[17];
					objLineaDepGarant.Cldoc = strTrama[18];
					objLineaDepGarant.Nro_Cargos = strTrama[19];
					objLineaDepGarant.Nro_Operacion = strTrama[20];
					objLineaDepGarant.Via_Pago = strTrama[21];
					objLineaDepGarant.Nro_Carpeta_Obs = strTrama[22];

					objDepGarant.Add(objLineaDepGarant);
				}

				SapGeneral proxy = ConectaSAP();

				proxy.Zpvu_Rfc_Trs_Crea_Dep_Garan(out NroDeposito, ref objDepGarant, ref objLog);	                           
				dsReturn.Tables.Add(objLog.ToADODataTable());
				if (dsReturn.Tables[0].Rows.Count>0)
				{	
					foreach(DataRow dr in dsReturn.Tables[0].Rows)
					{
						string tipo = Funciones.CheckStr(dr["TYPE"]);
						if (tipo == "E") 
						{
							throw new Exception(Funciones.CheckStr(dr["MESSAGE"]));
						}
					}
				}
				proxy.Connection.Close();
			}
			catch (Exception ex)
			{
				dsReturn =  null;
				NroDeposito = "";
				valor = false;
				throw ex;

			}
			return valor;
		}



		//consolidado 21012015

	}
}
