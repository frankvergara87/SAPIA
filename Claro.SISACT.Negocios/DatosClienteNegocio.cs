using System;
using System.Collections;
using System.Web;
using System.Data;
using System.Configuration;
using System.Text;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de DatosClienteNegocio.
	/// </summary>
	public class DatosClienteNegocio
	{
		public DatosClienteNegocio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		#region [Declaracion de Constantes - Config]

		string constCodTipoDocRUC = ConfigurationSettings.AppSettings["TipoDocumentoRUC"].ToString();
		string constCodTipoDocDNI = ConfigurationSettings.AppSettings["constCodTipoDocumentoDNI"].ToString();
		string constCodUmbralDeuda = ConfigurationSettings.AppSettings["constUmbralDeuda"].ToString();
		string constCodTiempoPermanenciaRUC = ConfigurationSettings.AppSettings["TiempoPermanenciaRUC"].ToString();
		string constCodTiempoPermanenciaDNI = ConfigurationSettings.AppSettings["TiempoPermanenciaDNI"].ToString();
		string constCodDiasLineasBSCS = ConfigurationSettings.AppSettings["constDiasLineasBSCS"].ToString();
		string constCodBloqueoRobo = ConfigurationSettings.AppSettings["constCodBloqueoRobo"].ToString();
		string constCodBloqueoPerdida = ConfigurationSettings.AppSettings["constCodBloqueoPerdida"].ToString();
		string nameArchivo = "log_Consulta_BRMS" + "_" + string.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".txt";	

		#endregion [Declaracion de Constantes - Config]

		String nroDocumento = null;
		String tipoDocumento = null;
		TipoDocumento objDocumento = null;
		ItemMensaje objMensaje = null;

		public ClienteCuenta ConsultarDatosCliente(string tipoDocumento, string nroDocumento, string strCoID)
		{
			ClienteCuenta objCliente = new ClienteCuenta();
			ConsumerNegocio objConsumer = new ConsumerNegocio();
			DataTable dtResumen = null;
			DataTable dtDetalle = null;
			ArrayList objListaMontoFactura = null;
			ArrayList objListaPlanesActivos = null;
			string listaTelefono = string.Empty;

				ArrayList objListaDocumento = (new GeneralNegocios()).ListarTipoDocumento();
				foreach (TipoDocumento obj in objListaDocumento)
				{
					if (obj.ID_SISACT == tipoDocumento)
					{
						this.nroDocumento = nroDocumento;
						this.tipoDocumento = tipoDocumento;
						objDocumento = new TipoDocumento();
						objDocumento = obj;
						objDocumento.ID_OAC = Funciones.CheckInt(tipoDocumento).ToString();
						break;
					}
				}

				objCliente.idCliente = DateTime.Now.ToString("ddMMyyyyhhmmss");
				objCliente.tipoDoc = tipoDocumento;
				objCliente.tipoDocDes = objDocumento.TDOCV_DESCRIPCION.ToString();
				objCliente.nroDoc = nroDocumento;
				if (tipoDocumento == constCodTipoDocRUC) objCliente.nroDocAsociado = nroDocumento.Substring(2, 8);

				int intMesesPermanencia = 0;
				int intMesesPermanenciaBSCS = 0;
				int intMesesPermanenciaSGA = 0;

				// Lista Parametros Generales
				ArrayList objListaItem = (new GeneralNegocios()).ListarParametroGeneral("1");//JAZ

				int intMeses = Funciones.CheckInt(obtenerParametro(objListaItem, "27"));
				double dblPorcentajeDeuda = Funciones.CheckDbl(obtenerParametro(objListaItem, "26"));

				double dblUmbralDeuda = Funciones.CheckDbl(obtenerParametro(objListaItem, constCodUmbralDeuda));
				int intUmbralPermanencia;
				if (tipoDocumento == constCodTipoDocRUC)
					intUmbralPermanencia = Funciones.CheckInt(obtenerParametro2(objListaItem, constCodTiempoPermanenciaRUC));//JAZ
				else
					intUmbralPermanencia = Funciones.CheckInt(obtenerParametro2(objListaItem, constCodTiempoPermanenciaDNI));//JAZ

				objCliente.nroRangoDiasBSCS = 90; // Funciones.CheckInt(obtenerParametro(objListaItem, constCodDiasLineasBSCS));
				// Lista Parametros Generales

				// Detalle Lineas BSCS
				DataSet dsListaBSCS = objConsumer.ListarDetalleLineaBSCS(objDocumento.ID_BSCS, nroDocumento);
				// Detalle Lineas SGA
				DataSet dsListaSGA = objConsumer.ListarDetalleLineaSGA(objDocumento.COD_SGA, nroDocumento, intMeses);
				// Comportamiento Pago
				objCliente.comportamientoPago = objConsumer.ObtenerComportamientoPago(objDocumento.ID_BSCS, nroDocumento, ref objMensaje);
               
				if (dsListaBSCS != null && dsListaBSCS.Tables[0].Rows.Count > 0)
				{
					dtResumen = new DataTable();
					dtResumen = dsListaBSCS.Tables[0];
					dtDetalle = new DataTable();
					dtDetalle = dsListaBSCS.Tables[1];

					if (Funciones.CheckStr(objCliente.nombres)=="" && Funciones.CheckStr(objCliente.razonSocial)=="")
					{
						objCliente.nombres = Funciones.CheckStr(dtResumen.Rows[0]["NOMBRES"]);
						objCliente.apellidos = Funciones.CheckStr(dtResumen.Rows[0]["APELLIDOS"]);
						objCliente.razonSocial = Funciones.CheckStr(dtResumen.Rows[0]["RAZON_SOCIAL"]);
					}

					objCliente.nroPlanesActivos = Funciones.CheckInt(dtResumen.Rows[0]["PLANES"]);
					objCliente.CF_Total = ConsultarCargoFijo(strCoID); //SD1052592
					objCliente.nroBloqueo = Funciones.CheckInt(dtResumen.Rows[0]["BLOQ"]);
					objCliente.nroSuspension = Funciones.CheckInt(dtResumen.Rows[0]["SUSP"]);

					objCliente.nroLineasBSCS = Funciones.CheckInt(dtResumen.Rows[0]["PLANES"]);
					objCliente.nroLineaMenor7Dia = Funciones.CheckInt(dtResumen.Rows[0]["NRO_7"]);
					objCliente.nroLineaMenor30Dia = Funciones.CheckInt(dtResumen.Rows[0]["NRO_30"]);
					objCliente.nroLineaMenor90Dia = Funciones.CheckInt(dtResumen.Rows[0]["NRO_90"]);
					objCliente.nroLineaMenor180Dia = Funciones.CheckInt(dtResumen.Rows[0]["NRO_180"]);
					objCliente.nroLineaMayor90Dia = Funciones.CheckInt(dtResumen.Rows[0]["NRO_90_MAS"]);
					objCliente.nroLineaMayor180Dia = Funciones.CheckInt(dtResumen.Rows[0]["NRO_180_MAS"]);

					objCliente.LineaBSCS = dtDetalle;
					ProcesarDetalleBSCS(dtDetalle, ref objListaMontoFactura, ref objListaPlanesActivos, ref intMesesPermanenciaBSCS);
				}

				if (dsListaSGA != null && dsListaSGA.Tables[0].Rows.Count > 0)
				{
					dtResumen = new DataTable();
					dtResumen = dsListaSGA.Tables[0];
					dtDetalle = new DataTable();
					dtDetalle = dsListaSGA.Tables[1];

					if (Funciones.CheckStr(objCliente.nombres) == ""  && Funciones.CheckStr(objCliente.razonSocial) == "" )
					{
						objCliente.nombres = Funciones.CheckStr(dtResumen.Rows[0]["NOMCLI"]);
						objCliente.apellidoPaterno = Funciones.CheckStr(dtResumen.Rows[0]["APEPAT"]);
						objCliente.apellidoMaterno = Funciones.CheckStr(dtResumen.Rows[0]["APEMAT"]);
						objCliente.apellidos = Funciones.CheckStr(objCliente.apellidoPaterno + " " + objCliente.apellidoMaterno);
						objCliente.razonSocial = Funciones.CheckStr(dtResumen.Rows[0]["RAZON_SOCIAL"]);
					}

					objCliente.nroPlanesActivos += Funciones.CheckInt(dtResumen.Rows[0]["NUM_PLAN"]);
					objCliente.CF_Total += Funciones.CheckDbl(dtResumen.Rows[0]["CF_SERVICIOS"]);
					objCliente.nroBloqueo += Funciones.CheckInt(dtResumen.Rows[0]["NUM_BLOQ"]);
					objCliente.nroSuspension += Funciones.CheckInt(dtResumen.Rows[0]["NUM_SUSP"]);
					objCliente.nroLineasSGA = Funciones.CheckInt(dtResumen.Rows[0]["NUM_PLAN"]);

					objCliente.LineaSGA = dtDetalle;
					ProcesarDetalleSGA(dtDetalle, ref objListaMontoFactura, ref objListaPlanesActivos, ref intMesesPermanenciaSGA);
				}

				// Detalle Lineas SISACT
				DataSet dsListaSISACT = objConsumer.ListarDetalleLineaSISACT(objDocumento.ID_SISACT, nroDocumento, listaTelefono);

				if (dsListaSISACT != null && dsListaSISACT.Tables[0].Rows.Count > 0)
				{
					dtResumen = new DataTable();
					dtResumen = dsListaSISACT.Tables[0];
					dtDetalle = new DataTable();
					dtDetalle = dsListaSISACT.Tables[1];

					if (Funciones.CheckStr(objCliente.nombres)==""  && Funciones.CheckStr(objCliente.razonSocial)=="" )
					{
						objCliente.nombres = Funciones.CheckStr(dtResumen.Rows[0]["NOMBRE"]);
						objCliente.apellidoPaterno = Funciones.CheckStr(dtResumen.Rows[0]["APELLIDO_PAT"]);
						objCliente.apellidoMaterno = Funciones.CheckStr(dtResumen.Rows[0]["APELLIDO_MAT"]);
						objCliente.apellidos = Funciones.CheckStr(objCliente.apellidoPaterno + " " + objCliente.apellidoMaterno);
						objCliente.razonSocial = Funciones.CheckStr(dtResumen.Rows[0]["RAZON_SOCIAL"]);
					}

					objCliente.LineaSISACT = dtDetalle;
					ProcesarDetalleSISACT(dtDetalle, ref objListaMontoFactura, ref objListaPlanesActivos);

					foreach (DataRow dr in dtDetalle.Rows)
					{
						objCliente.nroPlanesActivos += 1;
						objCliente.CF_Total += Funciones.CheckDbl(dr["CARGO_FIJO"]);
						objCliente.CF_Menor += Funciones.CheckDbl(dr["CARGO_FIJO"]);
						objCliente.nroLineasBSCS += 1;
						objCliente.nroLineaMenor7Dia += 1;
						objCliente.nroLineaMenor30Dia += 1;
						objCliente.nroLineaMenor90Dia += 1;
						objCliente.nroLineaMenor180Dia += 1;
						objCliente.nroLineasSISACT += 1;
					}
				}

				// Calcular Monto Facturado, NO Facturado x Producto y Total Facturado
				if (objListaMontoFactura != null)
					ObtenerMontoFactxBilletera(objListaMontoFactura, ref objCliente);

				// Validar BlackList de Créditos / WhiteList de Flexibilización
				bool isBlackList = true, isWhiteList = true, isTop = true;
				objConsumer.ConsultaTopBlackWhiteList(tipoDocumento, nroDocumento, objCliente.nroDiasDeuda, objCliente.deudaTotal, objCliente.nroPlanesActivos, objCliente.nroBloqueo,
					ref isBlackList, ref isWhiteList, ref isTop);

				// Cliente Nuevo/Cliente Claro
				intMesesPermanencia = (intMesesPermanenciaBSCS > intMesesPermanenciaSGA) ? intMesesPermanenciaBSCS : intMesesPermanenciaSGA;
				objCliente.tiempoPermanencia = intMesesPermanencia;
				objCliente.esClienteClaro = (intMesesPermanencia >= intUmbralPermanencia);

				string strCategoriaCliente = objCliente.esClienteClaro ? "CLIENTE CLARO" : "CLIENTE NUEVO";
				strCategoriaCliente += isTop ? " TOP" : "";

				objCliente.isBlackList = isBlackList;
				objCliente.isWhiteList = isWhiteList;
				objCliente.isTop = isTop;
				objCliente.tipoCliente = strCategoriaCliente;
				objCliente.oPlanesActivosxBilletera = objListaPlanesActivos;
		
			return objCliente;
		}

		private void ProcesarDetalleBSCS(DataTable dtDetalleBSCS, ref ArrayList objListaMontoFactura, ref ArrayList objListaPlanActivos, ref int intMesesPermanencia)
		{
			System.DateTime datFechaActiva;
			int intMeses = 0;
			intMesesPermanencia = 0;

			if (objListaMontoFactura == null) objListaMontoFactura = new ArrayList();
			ArrayList objListaCuenta = new ArrayList();
			PlanBilletera objBilletera;
			String strCuenta;

			foreach (DataRow dr in dtDetalleBSCS.Rows)
			{
				strCuenta = dr["CUENTA"].ToString();
				if (!objListaCuenta.Contains(strCuenta))
				{
					if (dr["ESTADO"].ToString().ToUpper() == "ACTIVO")
					{
					objBilletera = new PlanBilletera();
					objBilletera.Cuenta = strCuenta;
					objBilletera.MontoFacturado = Funciones.CheckDbl(dr["PROM_FACT"], 2);
					objBilletera.MontoNoFacturado = Funciones.CheckDbl(dr["MONTO_NO_FACT"], 2);

					int intCodBilletera = 0;
					if (Funciones.CheckInt(dr["NRO_MOVIL"]) > 0) intCodBilletera += (int)Billetera.TIPO_BILLETERA.MOVIL;
					if (Funciones.CheckInt(dr["NRO_INTERNET_FIJO"]) > 0) intCodBilletera += (int)Billetera.TIPO_BILLETERA.INTERNET;
					if (Funciones.CheckInt(dr["NRO_CLARO_TV"]) > 0) intCodBilletera += (int)Billetera.TIPO_BILLETERA.CLAROTV;
					if (Funciones.CheckInt(dr["NRO_TELEF_FIJA"]) > 0) intCodBilletera += (int)Billetera.TIPO_BILLETERA.TELEFONIA;
					if (Funciones.CheckInt(dr["NRO_BAM"]) > 0) intCodBilletera += (int)Billetera.TIPO_BILLETERA.BAM;

					objBilletera.idBilletera = intCodBilletera;

					objListaMontoFactura.Add(objBilletera);
					objListaCuenta.Add(strCuenta);
				}
				}

				if (tipoDocumento != constCodTipoDocRUC)
				{
					//Consulta Apadece Vigente SIGA PENDIENTE

					if (dr["ESTADO"].ToString().ToUpper() == "ACTIVO" && dr["FECHA_ACTIVACION"].ToString() != String.Empty)
					{
						datFechaActiva = DateTime.Parse(dr["FECHA_ACTIVACION"].ToString());
						intMeses = (DateTime.Now.Subtract(datFechaActiva).Days / 30);
						if (intMesesPermanencia < intMeses) intMesesPermanencia = intMeses;
					}
				}
				else
				{
					if (dr["FECHA_ACTIVACION"].ToString() != String.Empty)
					{
						datFechaActiva = DateTime.Parse(dr["FECHA_ACTIVACION"].ToString());
						intMeses = (DateTime.Now.Subtract(datFechaActiva).Days / 30);
						if (intMesesPermanencia < intMeses) intMesesPermanencia = intMeses;
					}
				}
			}

			// Detalle Cantidad de Planes x Billetera
			DataTable dtListaCantPlanBSCS = (new ConsumerNegocio()).ListarCantPlanxBilleteraBSCS(objDocumento.ID_BSCS, nroDocumento);
			objListaPlanActivos = ProcesarCantPlanBSCS(dtListaCantPlanBSCS);
		}

		private void ProcesarDetalleSGA(DataTable dtDetalleSGA, ref ArrayList objListaMontoFactura, ref ArrayList objListaPlanActivos, ref int intMesesPermanencia)
		{
			System.DateTime datFechaActiva;
			int intMeses = 0;
			intMesesPermanencia = 0;
			PlanBilletera objPlan;
			int intSistemaSGA = (int)PlanBilletera.TIPO_SISTEMA.SGA;
			ArrayList objListaPlan = (new EvaluacionNegocio()).ObtenerPlanesxBilletera(intSistemaSGA);

			if (objListaMontoFactura == null) objListaMontoFactura = new ArrayList();
			if (objListaPlanActivos == null) objListaPlanActivos = new ArrayList();

			foreach (DataRow dr in dtDetalleSGA.Rows)
			{
				if (dr["ESTADO"].ToString().ToUpper() == "ACTIVO")
				{
					objPlan = new PlanBilletera();
					objPlan.Plan = dr["IDPAQ"].ToString();
					objPlan.MontoFacturado = Funciones.CheckDbl(dr["PROM_FAC"], 2);
					objPlan.MontoNoFacturado = Funciones.CheckDbl(dr["MONTO_NO_FAC"], 2);

					objPlan.tipoFacturador = PlanBilletera.TIPO_FACTURADOR.SGA;
					objPlan.nroPlanes = 1;

					ArrayList objListaBilletera = null;
					foreach (PlanBilletera obj in objListaPlan)
					{
						if (obj.Plan == objPlan.Plan)
						{
							objListaBilletera = obj.oBilletera;
							break;
						}
					}

					if (objListaBilletera != null)
					{
						objPlan.oBilletera = new ArrayList();
						foreach (Billetera obj in objListaBilletera)
						{
							objPlan.idBilletera += obj.idBilletera;
							objPlan.oBilletera.Add(new Billetera(obj.idBilletera, 1));
						}
					}
					else
					{
						objPlan.idBilletera = (int)Billetera.TIPO_BILLETERA.TRIPLEPLAY;

						objPlan.oBilletera = new ArrayList();
						objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.INTERNET), 1));
						objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.CLAROTV), 1));
						objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.TELEFONIA), 1));
					}

					objListaPlanActivos.Add(objPlan);
					objListaMontoFactura.Add(objPlan);

					if (dr["FECHA_ACTIVACION"].ToString() != String.Empty)
					{
						datFechaActiva = DateTime.Parse(dr["FECHA_ACTIVACION"].ToString());
						intMeses = (DateTime.Now.Subtract(datFechaActiva).Days / 30);
						if (intMesesPermanencia < intMeses) intMesesPermanencia = intMeses;
					}
				}
			}
		}

		private void ProcesarDetalleSISACT(DataTable dtDetalleSISACT, ref ArrayList objListaMontoFactura, ref ArrayList objListaPlanActivos)
		{
			PlanBilletera objPlan;
			int intSistemaSISACT = (int)PlanBilletera.TIPO_SISTEMA.SISACT;
			ArrayList objListaPlan = (new EvaluacionNegocio()).ObtenerPlanesxBilletera(intSistemaSISACT);

			if (objListaMontoFactura == null) objListaMontoFactura = new ArrayList();
			if (objListaPlanActivos == null) objListaPlanActivos = new ArrayList();

			foreach (DataRow dr in dtDetalleSISACT.Rows)
			{
				objPlan = new PlanBilletera();
				objPlan.Plan = dr["PLAN_BSCS"].ToString();
				objPlan.MontoFacturado = 0;
				objPlan.MontoNoFacturado = Funciones.CheckDbl(dr["CARGO_FIJO"], 2);

				objPlan.tipoPlan = PlanBilletera.TIPO_PLAN.MOVIL;
				objPlan.tipoFacturador = PlanBilletera.TIPO_FACTURADOR.BSCS;
				objPlan.nroPlanes = 1;

				ArrayList objListaBilletera = null;
				foreach (PlanBilletera obj in objListaPlan)
				{
					if (obj.Plan == objPlan.Plan)
					{
						objListaBilletera = obj.oBilletera;
						break;
					}
				}

				if (objListaBilletera != null)
				{
					objPlan.oBilletera = new ArrayList();
					foreach (Billetera obj in objListaBilletera)
					{
						objPlan.idBilletera += obj.idBilletera;
						objPlan.oBilletera.Add(new Billetera(obj.idBilletera, 1));

						if (obj.idBilletera == (int)Billetera.TIPO_BILLETERA.BAM)
						{
							objPlan.tipoPlan = PlanBilletera.TIPO_PLAN.DATOS;
						}
					}
				}
				else
				{
					objPlan.idBilletera = (int)Billetera.TIPO_BILLETERA.MOVIL;

					objPlan.oBilletera = new ArrayList();
					objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.MOVIL), 1));
				}

				objListaPlanActivos.Add(objPlan);
				objListaMontoFactura.Add(objPlan);
			}
		}

		private ArrayList ProcesarCantPlanBSCS(DataTable dtDetalle)
		{
			PlanBilletera objPlan;
			ArrayList objLista = new ArrayList();
			foreach (DataRow dr in dtDetalle.Rows)
			{
				objPlan = new PlanBilletera();
				objPlan.Plan = dr["TMCODE"].ToString();
				objPlan.tipoFacturador =  PlanBilletera.TIPO_FACTURADOR.BSCS;
				int nroPlanes = 0;

				objPlan.oBilletera = new ArrayList();
				if (Funciones.CheckInt(dr["NRO_MOVIL"]) > 0)
				{
					nroPlanes = Funciones.CheckInt(dr["NRO_MOVIL"]);
					objPlan.idBilletera += (int)(Billetera.TIPO_BILLETERA.MOVIL);
					objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.MOVIL), nroPlanes));
				}
				if (Funciones.CheckInt(dr["NRO_INTERNET_FIJO"]) > 0)
				{
					nroPlanes = Funciones.CheckInt(dr["NRO_INTERNET_FIJO"]);
					objPlan.idBilletera += (int)(Billetera.TIPO_BILLETERA.INTERNET);
					objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.INTERNET), nroPlanes));
				}
				if (Funciones.CheckInt(dr["NRO_CLARO_TV"]) > 0)
				{
					nroPlanes = Funciones.CheckInt(dr["NRO_CLARO_TV"]);
					objPlan.idBilletera += (int)(Billetera.TIPO_BILLETERA.CLAROTV);
					objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.CLAROTV), nroPlanes));
				}
				if (Funciones.CheckInt(dr["NRO_TELEF_FIJA"]) > 0)
				{
					nroPlanes = Funciones.CheckInt(dr["NRO_TELEF_FIJA"]);
					objPlan.idBilletera += (int)(Billetera.TIPO_BILLETERA.TELEFONIA);
					objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.TELEFONIA), nroPlanes));
				}
				if (Funciones.CheckInt(dr["NRO_BAM"]) > 0)
				{
					nroPlanes = Funciones.CheckInt(dr["NRO_BAM"]);
					objPlan.idBilletera += (int)(Billetera.TIPO_BILLETERA.BAM);
					objPlan.oBilletera.Add(new Billetera((int)(Billetera.TIPO_BILLETERA.BAM), nroPlanes));
				}

				objPlan.nroPlanes = nroPlanes;
				objPlan.tipoPlan = PlanBilletera.TIPO_PLAN.MOVIL;
				if (Funciones.CheckInt(dr["NRO_BAM"]) > 0) objPlan.tipoPlan = PlanBilletera.TIPO_PLAN.DATOS;

				objLista.Add(objPlan);
			}
			return objLista;
		}

		private void ObtenerMontoFactxBilletera(ArrayList objListaMonto, ref ClienteCuenta objCliente)
		{
			string strMontoFacturado = string.Empty;
			string strMontoNoFacturado = string.Empty;
			EvaluacionNegocio objEvaluacion = new EvaluacionNegocio();
			string strNroDocumento = objCliente.nroDoc;

			foreach (PlanBilletera obj in objListaMonto)
			{
				if (obj.MontoFacturado > 0)
					strMontoFacturado = String.Format("{0}|{1};{2}", strMontoFacturado, obj.idBilletera, obj.MontoFacturado);
				if (obj.MontoNoFacturado > 0)
					strMontoNoFacturado = String.Format("{0}|{1};{2}", strMontoNoFacturado, obj.idBilletera, obj.MontoNoFacturado);

				objCliente.montoFacturadoTotal += obj.MontoFacturado;
				objCliente.montoNoFacturadoTotal += obj.MontoNoFacturado;
			}

			objCliente.oMontoFacturadoxBilletera = objEvaluacion.ObtenerMontoFactxBilletera(strNroDocumento, strMontoFacturado);
			objCliente.oMontoNoFacturadoxBilletera = objEvaluacion.ObtenerMontoFactxBilletera(strNroDocumento, strMontoNoFacturado);
		}

		private string obtenerParametro(ArrayList objListaItem, string idParametro)
		{
			string valor = string.Empty;
			if (objListaItem != null)
			{
				foreach (ItemGenerico objItem in objListaItem)
				{
					if (objItem.Codigo == idParametro)
					{
						valor = Funciones.CheckStr(objItem.Valor);
						break;
					}
				}
			}
			return valor;
		}

		private string obtenerParametro2(ArrayList objListaItem, string idParametro)
		{
			string valor = string.Empty;
			if (objListaItem != null)
			{
				foreach (ItemGenerico objItem in objListaItem)
				{
					if (objItem.Codigo == idParametro)
					{
						valor = Funciones.CheckStr(objItem.Valor2);
						break;
					}
				}
			}
			return valor;
		}
		//Inicio - SD1052592
		public double ConsultarCargoFijo(string coID)
		{
			return new ConsumerDatos().ConsultarCargoFijo(coID);
		}
		//Fin - SD1052592

	}
}
