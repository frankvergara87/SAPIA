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
	/// Descripción breve de ReglaCrediticiaNegocio.
	/// </summary>
	/// 
	public class ReglaCrediticiaNegocio
	{
		public ReglaCrediticiaNegocio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		#region [Declaracion de Constantes - Config]

		string consTipoProductoDTH = ConfigurationSettings.AppSettings["consTipoProductoDTH"].ToString();
		string consTipoProductoHFC = ConfigurationSettings.AppSettings["consTipoProducto3Play"].ToString();
		string consTipoDocRUC = ConfigurationSettings.AppSettings["TipoDocumentoRUC"].ToString();
		string consTipoDocDNI = ConfigurationSettings.AppSettings["constCodTipoDocumentoDNI"].ToString();
		string consTipoOperacionAltaReno = ConfigurationSettings.AppSettings["constTipoOperacionAltaRenovacion"].ToString();
		string consFormaPagoCuota = ConfigurationSettings.AppSettings["constFormaPagoCuota"].ToString();
		string consFormaPagoContado = ConfigurationSettings.AppSettings["constFormaPagoContado"].ToString();
		string nameArchivo = "log_Consulta_BRMS";		

		#endregion [Declaracion de Constantes - Config]

		string tipoDocumento = string.Empty;
		string nroDocumento = string.Empty;
		ItemMensaje objMensaje;

		public void CalcularLCDisponible(ClienteCuenta objCliente, string strCodRiesgo, string strEsSaludSunat, string strClienteNuevo, double dblLC,
										 ref ArrayList objLCxProducto, ref ArrayList objLCDisponiblexProducto)
		{
			// Calcular LC Buro x Producto
			objLCxProducto = (new EvaluacionNegocio()).ObtenerLCxBilletera(strCodRiesgo, objCliente.tipoDoc, objCliente.nroDoc, strEsSaludSunat, strClienteNuevo, dblLC);
			// Calcular Monto Facturado x Producto
			ArrayList oMontoFacturadoxProducto = objCliente.oMontoFacturadoxBilletera;
			// Calcular Monto NO Facturado x Producto
			ArrayList oMontoNoFacturadoxProducto = objCliente.oMontoNoFacturadoxBilletera;
			// Calcular LC Disponible x Producto
			objLCDisponiblexProducto = new ArrayList();

			double dblLCxBilletera;
			foreach (Billetera objBilletera in objLCxProducto)
			{
				dblLCxBilletera = 0.0;
				if (oMontoFacturadoxProducto != null)
				{
					foreach (Billetera objMonto in oMontoFacturadoxProducto)
					{
						if (objBilletera.idBilletera == objMonto.idBilletera)
						{
							dblLCxBilletera = objMonto.monto;
							break;
						}
					}
				}
				if (oMontoNoFacturadoxProducto != null)
				{
					foreach (Billetera objMonto in oMontoNoFacturadoxProducto)
					{
						if (objBilletera.idBilletera == objMonto.idBilletera)
						{
							dblLCxBilletera += objMonto.monto;
							break;
						}
					}
				}
				if (objBilletera.monto >= dblLCxBilletera)
					objBilletera.monto = objBilletera.monto - dblLCxBilletera;
				else
					objBilletera.monto = 0.0;

				objBilletera.monto = Funciones.CheckDbl(objBilletera.monto, 2);
				objLCDisponiblexProducto.Add(objBilletera);
			}
		}

		public VistaEvaluacion Evaluar(ClienteCuenta objCliente, ArrayList objDireccion, string strDatosGeneral, string strPlanesDetalle, string strServiciosDetalle, string strEquiposDetalle, string strBRMSProtMovil)  //PROY-24724-IDEA-28174 se agregó nuevo parametro (strBRMSProtMovil)
		{
			VistaEvaluacion objVistaEvaluacion = null;

			string strTipoDoc = objCliente.tipoDoc;
			string nroDocumento = objCliente.nroDoc;

			EvaluacionNegocio objEvaluacion = new EvaluacionNegocio();
			ArrayList objListaBilleteraEvaluado = new ArrayList();
			ArrayList objListaOfrecimiento = new ArrayList();

			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Metodo : " + "Evaluar", false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strDatosGeneral : " + strDatosGeneral, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strPlanesDetalle : " + strPlanesDetalle, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strServiciosDetalle : " + strServiciosDetalle, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strEquiposDetalle : " + strEquiposDetalle, false);

			// Consultar Reglas Creditos
			ConsultarReglasCreditos(objCliente, objDireccion, strDatosGeneral, strPlanesDetalle, strServiciosDetalle, strEquiposDetalle, "N", ref objListaOfrecimiento, ref objListaBilleteraEvaluado,strBRMSProtMovil); //PROY-24724-IDEA-28174 - se agregó nuevo parametro(strBRMSProtMovil)

			objVistaEvaluacion = ResultadoOfrecimiento(objListaOfrecimiento);

			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Resultado Ofrecimiento", false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Riesgo Claro : " + objVistaEvaluacion.riesgoClaro, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Comportamiento Pago : " + objVistaEvaluacion.comportamientoPago, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "LC Disponible : " + objVistaEvaluacion.LCDisponible, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Tipo Garantia : " + objVistaEvaluacion.tipoGarantia, false);
			// Calcular LC Disponible Evaluado
			if (strTipoDoc != consTipoDocRUC) strTipoDoc = consTipoDocDNI;

			objVistaEvaluacion.rangoLCDisponible = objEvaluacion.ConsultarTextoRangoLC(strTipoDoc, nroDocumento, objVistaEvaluacion.LCDisponible);

			return objVistaEvaluacion;
		}

		/*******************************************PROY-29123************************************************************/
		public Ofrecimiento EvaluarCliente(ClienteCuenta objCliente, ArrayList objDireccion, string strDatos)
		{
			Ofrecimiento objOfrecimiento = new Ofrecimiento();

			string nroDocumentoCli = objCliente.nroDoc;

			ArrayList objListaOfrecimiento = new ArrayList();

			HelperLog.EscribirLog("", nameArchivo, nroDocumentoCli + " - " + "Metodo : " + "EvaluarCliente", false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumentoCli + " - " + "strDatos : " + strDatos, false);

			// Consultar Reglas Creditos
			ConsultarReglasCliente(objCliente, objDireccion,"S", strDatos, ref objListaOfrecimiento);

			HelperLog.EscribirLog("", nameArchivo, nroDocumentoCli + " - " + "Resultado Evaluacion Cliente", false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumentoCli + " - " + "Cantidad de Resultados : " + objListaOfrecimiento.Count, false);
			
			if(objListaOfrecimiento.Count > 0){
				foreach (Ofrecimiento obj in objListaOfrecimiento)
				{
					objOfrecimiento.MaximoCuotas = obj.MaximoCuotas;
					objOfrecimiento.PrecioEquipoMaximo = obj.PrecioEquipoMaximo;
					objOfrecimiento.MensajeBRMS = obj.MensajeBRMS;
				}

			}
			

			return objOfrecimiento;
		}

		public ArrayList EvaluarCuota(ClienteCuenta objCliente, ArrayList objDireccion, string strDatosGeneral, string strPlanesDetalle, string strServiciosDetalle, string strEquiposDetalle, string strBRMSProtMovil, ref Ofrecimiento objOfrecimientoRef) //PROY-24724-IDEA-28174 - se agrego Nuevo Parametro (strBRMSProtMovil)
		{
			ArrayList objListaCuota = new ArrayList();
			ArrayList objListaBilleteraEvaluado = new ArrayList();
			ArrayList objListaOfrecimiento = new ArrayList();

			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Metodo : " + "EvaluarCuota", false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strDatosGeneral : " + strDatosGeneral, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strPlanesDetalle : " + strPlanesDetalle, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strServiciosDetalle : " + strServiciosDetalle, false);
			HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "strEquiposDetalle : " + strEquiposDetalle, false);

			// Consultar Reglas Creditos
			ConsultarReglasCreditos(objCliente, objDireccion, strDatosGeneral, strPlanesDetalle, strServiciosDetalle, strEquiposDetalle, "S", ref objListaOfrecimiento, ref objListaBilleteraEvaluado,strBRMSProtMovil); //PROY-24724-IDEA-28174 - se agrego Nuevo Parametro (strBRMSProtMovil)

			ArrayList objLista = new GeneralNegocios().ListarTipoCuota();
			foreach (Ofrecimiento obj in objListaOfrecimiento)
			{
				if (obj.ListaCuotas != null && obj.ListaCuotas.Count > 0)
				{
					foreach (Cuota objCuota in obj.ListaCuotas)
					{
						foreach (Cuota objItem in objLista)
						{
							if (objCuota.nroCuota == objItem.nroCuota)
							{
								objCuota.idFila = obj.IdFila.ToString();
								objCuota.idCuota = objItem.idCuota;
								objCuota.cuota = objItem.cuota;

								objListaCuota.Add(objCuota);
							}
						}
					}
				}
				//PROY-29123 VENTA EN CUOTAS INICIO
				else if (obj.MensajeBRMS != "" && obj.MensajeBRMS != null) {
					
					{
						objOfrecimientoRef.PrecioEquipoMaximo = obj.PrecioEquipoMaximo;
						objOfrecimientoRef.MaximoCuotas = obj.MaximoCuotas;
						objOfrecimientoRef.MensajeBRMS = obj.MensajeBRMS;
					}
				}
				//PROY-29123 VENTA EN CUOTAS FIN
			}

			return objListaCuota;
		}

		public void ConsultarReglasCreditos(ClienteCuenta objCliente, ArrayList objDireccion, string strDatosGeneral, string strPlanesDetalle, string strServiciosDetalle,
			string strEquiposDetalle, string strFlgCuota, ref ArrayList objListaOfrecimiento, ref ArrayList objListaBilleteraEvaluado,string strBRMSProtMovil) //PROY-24724-IDEA-28174 - se agrego Nuevo Parametro (strBRMSProtMovil)
		{
		
				string strTipoDoc = objCliente.tipoDoc;
				string nroDocumento = objCliente.nroDoc;
				this.tipoDocumento = strTipoDoc;
				this.nroDocumento = nroDocumento;
				bool flag1raConsulta = true;

				HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Metodo : " + "Inicio Evaluar - Input BRMS: " +  strDatosGeneral, false);
				string[] arrDatosGeneral = strDatosGeneral.Split('|');
				string strTipoOperacion = arrDatosGeneral[0];
				string strOferta = arrDatosGeneral[1];
				string strModalidadVenta = arrDatosGeneral[2];
				//Ini dbe - MRAF
				string strPlazoAcuerdoActual = String.Empty;
				string strMesesCumplirApadece = String.Empty;
				
				if(arrDatosGeneral.Length>3)
				{
					strPlazoAcuerdoActual = arrDatosGeneral[3];
					strMesesCumplirApadece = arrDatosGeneral[4];
				}
				//Fin dbe
				
				HelperLog.EscribirLog("", nameArchivo, nroDocumento + " - " + "Metodo : " + "Inicio Evaluar - Input BRMS: " +  strDatosGeneral, false);

				// Detalle Planes Evaluados
				ArrayList objListaOferta = ObtenerDetalleEvaluacion(strPlanesDetalle, strServiciosDetalle, strEquiposDetalle);

				// Productos de Planes Evaluados
				ArrayList objProductoPlanesEval = ObtenerProductosPlanesEval(objListaOferta);

				ArrayList objBilleteraPlanesActivo = null;
				EvaluacionNegocio objEvaluacion = new EvaluacionNegocio();
				ArrayList objListaOfertaEvaluado = new ArrayList();
				Ofrecimiento objOfrecimiento = null;
				objListaOfrecimiento = new ArrayList();
				objListaBilleteraEvaluado = new ArrayList();

				// Nro Planes Activos
				if (objCliente.oPlanesActivosxBilletera != null)
				{
					objBilleteraPlanesActivo = new ArrayList(objCliente.oPlanesActivosxBilletera);
				}

				// Consulta Datos Evaluación BRMS
				ReglasEvaluacionWS.ClaroEvalClientesReglasRequest oEvaluacionCliente = datosGeneralEvaluacion(objCliente);
				ReglasEvaluacionWS.oferta oOferta;
				ReglasEvaluacionWS.solicitud1 oSolicitud1;

				oSolicitud1 = oEvaluacionCliente.solicitud.solicitud1;
				oSolicitud1.tipoDeOperacion = strTipoOperacion;

				// Verificar si es la primera consulta
				flag1raConsulta = (oSolicitud1.tipoDeOperacion != consTipoOperacionAltaReno);

				// Flujo Reglas Evaluación / Reglas Cuotas
				oSolicitud1.transaccion = ConfigurationSettings.AppSettings["constTrxEvaluacion"].ToString();
				if (strFlgCuota == "S")
					oSolicitud1.transaccion = ConfigurationSettings.AppSettings["constTrxVentaCuotas"].ToString();

				// Modalidad de Venta
				if (strModalidadVenta != consFormaPagoCuota)
					strModalidadVenta = consFormaPagoContado;

				foreach (OfertaBRMS objOferta in objListaOferta)
				{
					// Plan
					string idPlan = objOferta.idPlan;

					oEvaluacionCliente.DecisionID = objOferta.idFila.ToString();
					oOferta = new ReglasEvaluacionWS.oferta();
					oOferta.campana = new ReglasEvaluacionWS.campana();

					oOferta.campana.tipo = objOferta.campana;
					oOferta.casoEpecial = "REGULAR";
					oOferta.controlDeConsumo = objOferta.topeConsumo;
					oOferta.kitDeInstalacion = String.Empty;
                    //gaa20170215
                    oOferta.cantidadLineasSEC = objOferta.cantidadLineasSEC;
                    oOferta.montoCFSEC = objOferta.montoCFSEC;
                    //fin gaa20170215
					// LISTA EQUIPOS
					ArrayList objListaEquipo = objOferta.oEquipo;
					if (objListaEquipo != null)
					{
						int idx = 0;
						if (objOferta.idProducto == consTipoProductoDTH)
						{
							EquipoBRMS oEquipoBRMS = (EquipoBRMS)objListaEquipo[0];
							// Consulta Detalle Decos asociados al Equipo
							ArrayList objListaDeco = objEvaluacion.ConsultarDetalleDecoxKIT(oEquipoBRMS.idEquipo);
							ReglasEvaluacionWS.equipo[] oListaEquipo = new ReglasEvaluacionWS.equipo[objListaDeco.Count];

							foreach (EquipoBRMS oPlanEquipo in objListaDeco)
							{
								oListaEquipo[idx] = new ReglasEvaluacionWS.equipo();
								oListaEquipo[idx].costo = oPlanEquipo.costo;
								oListaEquipo[idx].cuotas = oEquipoBRMS.cantidadDeCuotas;
								oListaEquipo[idx].formaDePago = strModalidadVenta;
								oListaEquipo[idx].gama = oEquipoBRMS.gama;
								oListaEquipo[idx].modelo = oPlanEquipo.modelo;
								oListaEquipo[idx].montoDeCuota = oEquipoBRMS.montoDeCuota;
								oListaEquipo[idx].porcentajecuotaInicial = oEquipoBRMS.porcentajeCuotaInicial;
								oListaEquipo[idx].precioDeVenta = oEquipoBRMS.precioDeVenta;
								oListaEquipo[idx].tipoDeDeco = oPlanEquipo.tipoDeDeco;
								oListaEquipo[idx].tipoOperacionKit = oEquipoBRMS.tipoDeOperacionKit;
								idx++;
							}
							oSolicitud1.equipo = oListaEquipo;
							oOferta.kitDeInstalacion = oEquipoBRMS.modelo;
						}
						else
						{
							ReglasEvaluacionWS.equipo[] oListaEquipo = new ReglasEvaluacionWS.equipo[objListaEquipo.Count];
							foreach (EquipoBRMS oPlanEquipo in objListaEquipo)
							{
								oListaEquipo[idx] = new ReglasEvaluacionWS.equipo();
								oListaEquipo[idx].costo = oPlanEquipo.costo;
								oListaEquipo[idx].cuotas = oPlanEquipo.cantidadDeCuotas;
								oListaEquipo[idx].formaDePago = strModalidadVenta;
								oListaEquipo[idx].gama = oPlanEquipo.gama;
								oListaEquipo[idx].modelo = oPlanEquipo.modelo;
								oListaEquipo[idx].montoDeCuota = oPlanEquipo.montoDeCuota;
								oListaEquipo[idx].porcentajecuotaInicial = oPlanEquipo.porcentajeCuotaInicial;
								oListaEquipo[idx].precioDeVenta = oPlanEquipo.precioDeVenta;
								oListaEquipo[idx].tipoDeDeco = oPlanEquipo.tipoDeDeco;
								oListaEquipo[idx].tipoOperacionKit = oPlanEquipo.tipoDeOperacionKit;
								idx++;
							}
							oSolicitud1.equipo = oListaEquipo;
						}
					}

					// DIRECCION CLIENTE
					if (objDireccion != null)
					{
						foreach (DireccionCliente oDirCliente in objDireccion)
						{
							if (oDirCliente.IdFila == objOferta.idFila)
							{
								string departamento = null, provincia = null, distrito = null;
								(new GeneralNegocios()).ConsultarDatosDireccion(oDirCliente.IdDepartamento, oDirCliente.IdProvincia, oDirCliente.IdDistrito,
									ref departamento, ref provincia, ref distrito);

								oSolicitud1.cliente.direccion = new ReglasEvaluacionWS.direccion();
								oSolicitud1.cliente.direccion.codigoDePlano = oDirCliente.IdPlano;
								oSolicitud1.cliente.direccion.departamento = departamento;
								oSolicitud1.cliente.direccion.provincia = provincia;
								oSolicitud1.cliente.direccion.distrito = distrito;
								oSolicitud1.cliente.direccion.region = String.Empty;

								break;
							}
						}
					}

					// Plan Actual
					oOferta.planActual = new ReglasEvaluacionWS.planActual();
					oOferta.planActual.cargoFijo = objCliente.planActualCF;
					oOferta.planActual.descripcion = objCliente.planActual.ToUpper();
//gaa20161115
                                        //oOferta.planActual.tiempoPermanencia = objCliente.tiempoPermanencia;  //- MRAF4
					oOferta.planActual.tiempoPermanencia = objCliente.tiempoPermanenciaContratoMeses;  //- MRAF4
//fin gaa20161115
					//Inicio dbe - MRAF

					oOferta.planActual.mesesParaCubrirApadece=Funciones.CheckInt(strMesesCumplirApadece);
					oOferta.planActual.plazoDeAcuerdo=Funciones.CheckInt(strPlazoAcuerdoActual);
					//Fin dbe

					// Plan Solicitado
					oOferta.planSolicitado = new ReglasEvaluacionWS.planSolicitado();

                    HelperLog.EscribirLog("", nameArchivo, objCliente.nroDoc + " - " + "Iniciando Cargo Fijo del Plan Solicitando", false);
                    HelperLog.EscribirLog("", nameArchivo, objCliente.nroDoc + " - " + "Cargo Fijo del Plan Solicitando :" + objOferta.cargoFijo.ToString(), false);
                    HelperLog.EscribirLog("", nameArchivo, objCliente.nroDoc + " - " + "Cargo Fijo del Plan Actual :" + objCliente.planActualCF.ToString(), false);
						oOferta.planSolicitado.cargoFijo = (objOferta.cargoFijo - objCliente.planActualCF > 0) ? (objOferta.cargoFijo - objCliente.planActualCF) : 0;
                    HelperLog.EscribirLog("", nameArchivo, objCliente.nroDoc + " - " + "Calculo de Cargo Fijo del Plan Solicitando :" + oOferta.planSolicitado.cargoFijo.ToString(), false);
					
					oOferta.planSolicitado.descripcion = objOferta.plan;
					oOferta.planSolicitado.paquete = objOferta.paquete;

					// LISTA SERVICIOS
					ArrayList objListaServicio = objOferta.oServicio;
					if (objListaServicio != null && objListaServicio.Count > 0)
					{
						int idx = 0;
						ReglasEvaluacionWS.servicio[] oListaServicio = new ReglasEvaluacionWS.servicio[objListaServicio.Count];

						foreach (ItemGenerico oPlanServicio in objListaServicio)
						{
							oListaServicio[idx] = new ReglasEvaluacionWS.servicio();
							oListaServicio[idx].nombre = oPlanServicio.Descripcion;
							idx++;
						}
						oOferta.planSolicitado.servicio = oListaServicio;
					}

					// DTH + BAM [CF PROMOCIONAL]
					if (objOferta.idProducto == consTipoProductoDTH)
					{
						objOferta.cargoFijo += objEvaluacion.ObtenerCFPromocional(objOferta.idCampana);
					}

					oOferta.plazoDeAcuerdo = objOferta.plazo;
					oOferta.productoComercial = objOferta.producto;
					oOferta.proteccionMovil = strBRMSProtMovil == "SI" ? Claro.SisAct.Negocios.ReglasEvaluacionWS.tipoSiNo.SI : Claro.SisAct.Negocios.ReglasEvaluacionWS.tipoSiNo.NO; //PROY-24724-IDEA-28174
					oOferta.segmentoDeOferta = strOferta;
					oOferta.tipoDeOperacionEmpresa = String.Empty;

					// Productos Plan [Tipos de Productos que componen al Plan]
					
					ArrayList objBilleteraPlan = new ArrayList();
					foreach (PlanBilletera obj in objProductoPlanesEval)
					{
						if (obj.Plan == idPlan)
						{
							objBilleteraPlan = obj.oBilletera;
						}
					}

					// Descripción Producto [Texto de Tipos de Productos que componen al Plan]
					foreach (Billetera obj in objBilleteraPlan)
					{
						if (oOferta.tipoDeProducto == null) oOferta.tipoDeProducto = obj.billetera;
						else oOferta.tipoDeProducto += " + " + obj.billetera;
					}

					// Nro Planes = Sumatoria Planes [Productos que componen al Plan]
					int intPlanesActivo = CalcularNroPlanesActivoxProducto(objBilleteraPlanesActivo, objBilleteraPlan);
					int intPlanesEvaluado = 1; //CalcularNroPlanesxProducto(objListaOfertaEvaluado, objBilleteraPlan);
					int nroPlanesAutonomia = intPlanesActivo - 1;

					if (strTipoDoc == consTipoDocRUC) nroPlanesAutonomia = intPlanesEvaluado;

					// LC Disponible Plan = Sumatoria [LC - CF] [Productos que componen al Plan]
					double dblLCDisponible = CalcularMontoxProducto(objCliente.oLCDisponiblexBilletera, objBilleteraPlan);
					double dblCFEvaluado = objOferta.cargoFijo; //CalcularCFEvaluado(objListaOfertaEvaluado, objBilleteraPlan);

					// Monto Facturado [Productos que componen al Plan]
					double dblMontoFacturado = CalcularMontoxProducto(objCliente.oMontoFacturadoxBilletera, objBilleteraPlan);
					double dblMontoNoFacturado = CalcularMontoxProducto(objCliente.oMontoNoFacturadoxBilletera, objBilleteraPlan);

					oSolicitud1.cliente.cantidadDePlanesPorProducto = intPlanesActivo;

					if (!flag1raConsulta)
					{
						oSolicitud1.cliente.limiteDeCreditoDisponible = dblLCDisponible + objCliente.planActualCF;
						oSolicitud1.cliente.limiteDeCreditoDisponible = Funciones.CheckDbl(oSolicitud1.cliente.limiteDeCreditoDisponible, 2);
					}
					else
					{
						oSolicitud1.cliente.limiteDeCreditoDisponible = 0.0;
						oSolicitud1.cliente.riesgo = "";
					}

					oSolicitud1.cliente.facturacionPromedioProducto = Funciones.CheckDbl(dblMontoFacturado + dblMontoNoFacturado, 2);

					oSolicitud1.oferta = oOferta;
					oSolicitud1.fechaEjecucion = DateTime.Now; //PROY-24724-IDEA-28174 
					oSolicitud1.horaEjecucion = DateTime.Now.Hour;//PROY-24724-IDEA-28174 
					oEvaluacionCliente.solicitud.solicitud1 = oSolicitud1;

					// Consulta BRMS
					objOfrecimiento = (new BWReglasCreditica()).ConsultaReglaCrediticia(nroDocumento, oEvaluacionCliente, ref objMensaje);

					objOfrecimiento.IdFila = objOferta.idFila;
					objOfrecimiento.IdProducto = objOferta.idProducto;
					objOfrecimiento.CargoFijo = objOferta.cargoFijo;
					objOfrecimiento.nroLineaActivoxProducto = intPlanesActivo;
					objOfrecimiento.nroLineaEvaluadoxProducto = intPlanesEvaluado;
					objOfrecimiento.montoFacturadoxProducto = dblMontoFacturado;
					objOfrecimiento.Plan = objOferta.plan;
					objOfrecimiento.TipoOperacion = oSolicitud1.tipoDeOperacion;
					objOfrecimiento.LcDisponible = oSolicitud1.cliente.limiteDeCreditoDisponible;

					// AUTONOMIA
					objOfrecimiento.TieneAutonomia = ResultadoAutonomia(objOfrecimiento, strTipoDoc, nroPlanesAutonomia, objOferta.cargoFijo, dblMontoFacturado);

					if (objOfrecimiento.TieneAutonomia == "S")
						objOfrecimiento.ResultadoAutonomia = ConfigurationSettings.AppSettings["constAutonomiaAprobado"].ToString();
					else
						objOfrecimiento.ResultadoAutonomia = ConfigurationSettings.AppSettings["constAutonomiaIrCreditos"].ToString();

					// LOG
					grabarLog(oEvaluacionCliente, ref objOfrecimiento);

					objListaOfrecimiento.Add(objOfrecimiento);

					objOferta.oBilletera = new ArrayList(objBilleteraPlan);
					objListaOfertaEvaluado.Add(objOferta);
					objListaBilleteraEvaluado.AddRange(objBilleteraPlan);
				}
		}


		/*********************************************PROY-29123 INICIO****************************************************/
		public void ConsultarReglasCliente(ClienteCuenta objCliente, ArrayList objDireccion, string strFlgCuota, string strDatos,ref ArrayList objListaOfrecimiento) 
		{
		
			string nroDocumentoCli = objCliente.nroDoc;
			Ofrecimiento objOfrecimiento = null;

			string[] arrDatosGeneral = strDatos.Split('|');

			string strTipoOperacion = arrDatosGeneral[0];
			string strOferta = arrDatosGeneral[1];

			if (strOferta == "SELECCIONE...") strOferta = "";

			// Consulta Datos Evaluación BRMS
			ReglasEvaluacionWS.ClaroEvalClientesReglasRequest oEvaluacionCliente = datosGeneralEvaluacion(objCliente);
			ReglasEvaluacionWS.oferta oOferta;
			ReglasEvaluacionWS.solicitud1 oSolicitud1;

			oSolicitud1 = oEvaluacionCliente.solicitud.solicitud1;
			oSolicitud1.tipoDeOperacion = strTipoOperacion;

			oOferta = new ReglasEvaluacionWS.oferta();
			oOferta.segmentoDeOferta = strOferta;

			oSolicitud1.oferta = oOferta;

			oEvaluacionCliente.solicitud.solicitud1 = oSolicitud1;

			// Flujo Reglas Evaluación / Reglas Cuotas
			oSolicitud1.transaccion = ConfigurationSettings.AppSettings["constTrxEvaluacion"].ToString();
			if (strFlgCuota == "S")
				oSolicitud1.transaccion = ConfigurationSettings.AppSettings["constTrxVentaCuotas"].ToString();

			// Consulta BRMS
			objOfrecimiento = (new BWReglasCreditica()).ConsultaReglaCrediticia(nroDocumentoCli, oEvaluacionCliente, ref objMensaje);

			objListaOfrecimiento.Add(objOfrecimiento);

		}
		/*********************************************PROY-29123 FIN****************************************************/
		public ArrayList ObtenerDetalleEvaluacion(string strPlanesDetalle, string strServiciosDetalle, string strEquiposDetalle)
		{
			ArrayList objDetalleEval = new ArrayList();
			ArrayList objPlanDetalle = new ArrayList();
			objPlanDetalle = ObtenerDetallePlanesEval(strPlanesDetalle);
			objDetalleEval = ObtenerDetallePlanEquipoEval(objPlanDetalle, strServiciosDetalle, strEquiposDetalle);
			return objDetalleEval;
		}

		private ArrayList ObtenerDetallePlanesEval(String strPlanesDetalle)
		{
			ArrayList listaPlanDetalle = new ArrayList();
			string[] arrPlanDetalle = strPlanesDetalle.Split('|');

			OfertaBRMS objOferta;
			ArrayList objListaPlazo = new GeneralNegocios().ListarPlazoAcuerdo("");
			ArrayList objListaProducto = new GeneralNegocios().ListarProducto();
			foreach (string strDetalle in arrPlanDetalle)
			{
				if (strDetalle != "")
				{
					objOferta = new OfertaBRMS();
					string[] objPlan = strDetalle.ToUpper().Split(';');
					objOferta.idFila = Funciones.CheckInt(objPlan[0]);
					objOferta.idProducto = objPlan[1];
					// Producto
					foreach (ItemGenerico producto in objListaProducto)
					{
						if (producto.Codigo == objOferta.idProducto)
						{
							objOferta.producto = producto.Descripcion;
							break;
						}
					}
					// Plazo Acuerdo
					objOferta.idPlazo = objPlan[2];
					foreach (ItemGenerico plazo in objListaPlazo)
					{
						if (plazo.Codigo == objOferta.idPlazo)
						{
							objOferta.plazo = plazo.Descripcion;
							break;
						}
					}
					objOferta.idPaquete = objPlan[3].Split('_')[0];
					objOferta.paquete = objPlan[4];
					objOferta.idPlan = objPlan[5].Split('_')[0];
					objOferta.plan = objPlan[6];

					objOferta.topeConsumo = ConfigurationSettings.AppSettings["ConstTextSinTopeConsumo"].ToString();
					if (objPlan[7] == ConfigurationSettings.AppSettings["constCodTopeCeroServicio"].ToString())
						objOferta.topeConsumo = "TOPE DE CONSUMO CERO";

					if (objPlan[7] == ConfigurationSettings.AppSettings["constCodTopeSinCFServicio"].ToString())
						objOferta.topeConsumo = "TOPE DE CONSUMO SIN CF";

					//CAMBIO!!!
					if (objPlan[7] == ConfigurationSettings.AppSettings["constCodTopeAutomaticoServicio"].ToString())
						objOferta.topeConsumo = "TOPE DE CONSUMO AUTOMATICO";

					if (objOferta.idProducto == consTipoProductoHFC)
						objOferta.topeConsumo = objPlan[7];

					objOferta.idCampana = objPlan[8];
					objOferta.campana = objPlan[9];
					objOferta.cargoFijo = Funciones.CheckDbl(objPlan[10], 2);
					//gaa20170215
					objOferta.cantidadLineasSEC = Funciones.CheckInt(objPlan[12]);
					objOferta.montoCFSEC = Funciones.CheckDbl(objPlan[11], 2);
					//fin gaa20170215
					listaPlanDetalle.Add(objOferta);
				}
			}

			return listaPlanDetalle;
		}

		private ArrayList ObtenerDetallePlanEquipoEval(ArrayList objPlanDetalle, string strServiciosDetalle, string strEquiposDetalle)
		{
			ArrayList listaPlanDetalle = new ArrayList();

			string idFila = String.Empty;
			string[] arrPlanEquipo = strEquiposDetalle.Split('|');
			string[] arrPlanServicio = strServiciosDetalle.Split('|');

			EquipoBRMS objEquipo;
			ItemGenerico objServicio;
			ArrayList objListaEquipo;
			ArrayList objListaServicio;

			foreach (OfertaBRMS objOferta in objPlanDetalle)
			{
				objListaEquipo = new ArrayList();
				foreach (string strEquipo in arrPlanEquipo)
				{
					idFila = strEquipo.Split(';')[0];
					if (objOferta.idFila.ToString() == idFila)
					{
						objEquipo = new EquipoBRMS();
						objEquipo.idFila = strEquipo.Split(';')[0];
						objEquipo.idProducto = strEquipo.Split(';')[1];
						objEquipo.idEquipo = strEquipo.Split(';')[2];
						objEquipo.costo = Funciones.CheckDbl(strEquipo.Split(';')[4], 2);
						objEquipo.modelo = strEquipo.Split(';')[3];
						objEquipo.montoDeCuota = Funciones.CheckDbl(strEquipo.Split(';')[8], 2);
						objEquipo.precioDeVenta = Funciones.CheckDbl(strEquipo.Split(';')[5], 2);
						objEquipo.cantidadDeCuotas = Funciones.CheckInt(strEquipo.Split(';')[6]);
						objEquipo.porcentajeCuotaInicial = Funciones.CheckDbl(strEquipo.Split(';')[7], 2);

						if (objEquipo.idProducto == ConfigurationSettings.AppSettings["consTipoProductoDTH"].ToString())
						{
							objEquipo.tipoDeOperacionKit = ConfigurationSettings.AppSettings["constTipoKitDECO"];
						}
						objListaEquipo.Add(objEquipo);
					}
				}
				objOferta.oEquipo = objListaEquipo;


				objListaServicio = new ArrayList();
				foreach (string strServicio in arrPlanServicio)
				{
					idFila = strServicio.Split(';')[0];
					if (objOferta.idFila.ToString() == idFila)
					{
						string[] arrServicio = strServicio.Split(';');
						for (int i = 1; i < arrServicio.Length; i++)
						{
							objServicio = new ItemGenerico();
							objServicio.Descripcion = arrServicio[i];
							objListaServicio.Add(objServicio);
						}
					}
				}
				objOferta.oServicio = objListaServicio;

				listaPlanDetalle.Add(objOferta);
			}
			return listaPlanDetalle;
		}

		private ArrayList ObtenerProductosPlanesEval(ArrayList objPlanDetalle)
		{
			string strPlanesEvaluados = string.Empty;
			ArrayList objProductoPlanesEval = new ArrayList();
			foreach (OfertaBRMS item in objPlanDetalle)
			{
				string strPlan = item.idPlan;
				if (item.idProducto == ConfigurationSettings.AppSettings["consTipoProducto3Play"].ToString())
				{
					strPlan = item.idPlan;
					strPlanesEvaluados = string.Format("{0}|{1};{2}", strPlanesEvaluados, strPlan, "1");
				}
				else
				{
					strPlanesEvaluados = string.Format("{0}|{1};{2}", strPlanesEvaluados, strPlan, "0");
				}
			}
			objProductoPlanesEval = (new EvaluacionNegocio()).ObtenerBilleteraxPlan(strPlanesEvaluados);
			return objProductoPlanesEval;
		}

		private ReglasEvaluacionWS.ClaroEvalClientesReglasRequest datosGeneralEvaluacion(ClienteCuenta objCliente)
		{
			string strCodOficina = objCliente.oficina;
			string strCodTipoDoc = objCliente.tipoDoc;
			string strNroDocumento = objCliente.nroDoc;
			string strNroOperacion = Funciones.CheckStr(objCliente.nroOperacionBuro);

			ReglasEvaluacionWS.ClaroEvalClientesReglasRequest oEvaluacionCliente = new ReglasEvaluacionWS.ClaroEvalClientesReglasRequest();
			DataSet dsDatosEvaluacionCliente = (new EvaluacionNegocio()).ObtenerDatosEvaluacion(strCodOficina, strCodTipoDoc, strNroDocumento, strNroOperacion);

			if (dsDatosEvaluacionCliente != null)
			{
				DataTable dtOficina = dsDatosEvaluacionCliente.Tables[0];
				DataTable dtCliente = dsDatosEvaluacionCliente.Tables[1];
				DataTable dtRepresentante = dsDatosEvaluacionCliente.Tables[2];

				ReglasEvaluacionWS.solicitud oSolicitud = new ReglasEvaluacionWS.solicitud();
				ReglasEvaluacionWS.puntodeVenta oOficina = new ReglasEvaluacionWS.puntodeVenta();
				ReglasEvaluacionWS.direccion oDireccionOficina = new ReglasEvaluacionWS.direccion();

				// Información Punto de Venta
				oOficina.codigo = Funciones.CheckStr(dtOficina.Rows[0]["CODIGO"]);
				oOficina.descripcion = Funciones.CheckStr(dtOficina.Rows[0]["PDV"]);
				oOficina.calidadDeVendedor = String.Empty;
				oOficina.canal = Funciones.CheckStr(dtOficina.Rows[0]["CANAL"]);

				// Información Direccion Punto de Venta
				oDireccionOficina.codigoDePlano = String.Empty;
				oDireccionOficina.departamento = Funciones.CheckStr(dtOficina.Rows[0]["DEPARTAMENTO"]);
				oDireccionOficina.distrito = Funciones.CheckStr(dtOficina.Rows[0]["DISTRITO"]);
				oDireccionOficina.provincia = Funciones.CheckStr(dtOficina.Rows[0]["PROVINCIA"]);
				oDireccionOficina.region = Funciones.CheckStr(dtOficina.Rows[0]["REGION"]);
				oOficina.direccion = oDireccionOficina;
				ReglasEvaluacionWS.cliente oCliente = new ReglasEvaluacionWS.cliente();
				ReglasEvaluacionWS.documento oDocumentoCliente = new ReglasEvaluacionWS.documento();

				// Información Cliente
				oDocumentoCliente.numero=Funciones.CheckStr(strNroDocumento); //INC000000772085
				oDocumentoCliente.descripcion = ObtenerTipoDocumento(strCodTipoDoc, strNroDocumento);
				oDocumentoCliente.descripcionSpecified = true;
				oCliente.documento = oDocumentoCliente;
				oCliente.cantidadDeLineasActivas = objCliente.nroPlanesActivos;
				oCliente.comportamientoDePago = objCliente.comportamientoPago;

				oCliente.facturacionPromedioClaro = objCliente.montoFacturadoTotal + objCliente.montoNoFacturadoTotal;

				if (dtCliente.Rows.Count > 0)
				{
					oDocumentoCliente.numero = Funciones.CheckStr(dtCliente.Rows[0]["NRO_DOCUMENTO"]);
					oCliente.creditScore = Funciones.CheckDbl(dtCliente.Rows[0]["PUNTAJE"]);
					oCliente.riesgo = Funciones.CheckStr(dtCliente.Rows[0]["RIESGO"]);
					oCliente.sexo = Funciones.CheckStr(dtCliente.Rows[0]["SEXO"]);
					oCliente.edad = Funciones.CheckInt(dtCliente.Rows[0]["EDAD"]);
				}

				oCliente.tiempoDePermanencia = objCliente.tiempoPermanencia;
				oCliente.tipo = objCliente.tipoCliente;

				// Información Lista de Representantes Legales
				if (strCodTipoDoc == consTipoDocRUC)
				{
					ReglasEvaluacionWS.representanteLegal oRRLL;
					ReglasEvaluacionWS.representanteLegal[] oListaRRLL = new ReglasEvaluacionWS.representanteLegal[dtRepresentante.Rows.Count];
					ReglasEvaluacionWS.documento oDocumentoRRLL;
					int idx = 0;
					foreach (DataRow dr in dtRepresentante.Rows)
					{
						oRRLL = new ReglasEvaluacionWS.representanteLegal();
						oDocumentoRRLL = new ReglasEvaluacionWS.documento();
						oDocumentoRRLL.numero = Funciones.CheckStr(dr["NUMERO_DOCUMENTO"]);
						oDocumentoRRLL.descripcion = ObtenerTipoDocumento(dr["TIPO_DOCUMENTO"].ToString(), dr["NUMERO_DOCUMENTO"].ToString());
						oDocumentoRRLL.descripcionSpecified = true;
						oRRLL.documento = oDocumentoRRLL;
						oRRLL.riesgo = Funciones.CheckStr(dr["RIESGO"]);

						oListaRRLL[idx] = new ReglasEvaluacionWS.representanteLegal();
						oListaRRLL[idx] = oRRLL;
						idx++;
					}
					oCliente.representanteLegal = oListaRRLL;
				}

				// Información Solicitud
				oSolicitud.solicitud1 = new ReglasEvaluacionWS.solicitud1();
				oSolicitud.solicitud1.flagDeLicitacion = ReglasEvaluacionWS.tipoSiNo.NO;
				oSolicitud.solicitud1.flagDeLicitacionSpecified = true;
				oSolicitud.solicitud1.tipoDeBolsa = String.Empty;
				oSolicitud.solicitud1.tipoDeDespacho = ConfigurationSettings.AppSettings["constTextoPDV"].ToString();
				oSolicitud.solicitud1.cliente = oCliente;
				oSolicitud.solicitud1.puntodeVenta = oOficina;
				//gaa20170215
				if (objCliente.buroConsultado == null)
					objCliente.buroConsultado = string.Empty;

				if (objCliente.buroConsultado.Length > 0)
				{
					if (Funciones.IsNumeric(objCliente.buroConsultado))
					{
					BLConsulta objConsulta = new BLConsulta();
					oSolicitud.solicitud1.buroConsultado = objConsulta.ObtenerBuroDescripcion(objCliente.buroConsultado);
				}
				}
				else
					oSolicitud.solicitud1.buroConsultado = objCliente.buroConsultado;

				//fin gaa20170215

				oSolicitud.solicitud1.totalPlanes = 1; /*PROY-31636-RENTESEG*/

				oEvaluacionCliente.solicitud = oSolicitud;
			}
			return oEvaluacionCliente;
		}

		private string ResultadoAutonomia(Ofrecimiento oOfrecimiento, string strTipoDoc, int nroPlanes, double dblCF, double dblMontoFacturado)
		{
			string strAutonomia = "N";
			double dblMontoCFPermitido = 0.0;

			if (oOfrecimiento.TieneAutonomia != "SIN_REGLAS")
			{
				if (Funciones.CheckStr(oOfrecimiento.Restriccion) != "NO")
					strAutonomia = "NO_CONDICION";
				else
				{
					 if (oOfrecimiento.TipoOperacion == ConfigurationSettings.AppSettings["constTextoOperacionRenovacion"].ToString())
					 {
						 if (oOfrecimiento.AutonomiaRenovacion == ConfigurationSettings.AppSettings["constAutonomiaAprobado"].ToString())
							 strAutonomia = "S";
					 }
					 else
					 {
						 if (strTipoDoc == consTipoDocRUC)
						 {
							 if (oOfrecimiento.CantidadDeLineasAdicionalesRUC >= nroPlanes)
							 {
								 if (oOfrecimiento.TipoDeAutonomiaCargoFijo == "REFERENCIAL")
									 dblMontoCFPermitido = Funciones.CheckDbl(oOfrecimiento.MontoCFParaRUC * (dblMontoFacturado / 100), 2);
								 else
									 dblMontoCFPermitido = oOfrecimiento.MontoCFParaRUC;

								 if (dblMontoCFPermitido >= dblCF)
									 strAutonomia = "S";
							 }
						 }
						 else if (oOfrecimiento.CantidadDeLineasMaximas >= nroPlanes)
							 strAutonomia = "S";
					 }
				}
			}
			else
				strAutonomia = oOfrecimiento.TieneAutonomia;

			return strAutonomia;
		}

		private VistaEvaluacion ResultadoOfrecimiento(ArrayList objOfrecimiento)
		{
			double dblImporte = 0.0;
			double dblImporteTotal = 0.0;
			double dblNroGarantia = 0.0;
			string constTipoGarantiaNinguno = ConfigurationSettings.AppSettings["constCodTipoGarantiaNinguno"].ToString();
			string constGarantiaNinguno = string.Empty;

			Garantia objGarantia;
			ArrayList objListaGarantia = new ArrayList();
			VistaEvaluacion objVistaEvaluacion = new VistaEvaluacion();

			ArrayList objListaProducto = (new GeneralNegocios()).ListarProducto();
			ArrayList objListaTipoGarantia = (new GeneralNegocios()).ListarTipoGarantia("", "1");

			foreach (ItemGenerico objItem in objListaTipoGarantia)
			{
				if (objItem.Codigo == constTipoGarantiaNinguno)
				{
					constGarantiaNinguno = objItem.Descripcion.ToUpper();
					break;
				}
			}

			foreach (Ofrecimiento obj in objOfrecimiento)
			{
				objGarantia = new Garantia();
				objGarantia.IdFila = obj.IdFila;
				objGarantia.idGarantia = constTipoGarantiaNinguno;
				objGarantia.garantia = constGarantiaNinguno;
				objGarantia.idProducto = obj.IdProducto;
				objGarantia.CF = Funciones.CheckDbl(obj.CargoFijo, 2);
				objGarantia.nroGarantia = 1;
				objGarantia.plan = obj.Plan;

				foreach (ItemGenerico objItem in objListaProducto)
				{
					if (objItem.Codigo == obj.IdProducto)
					{
						objGarantia.producto = objItem.Descripcion;
						break;
					}
				}

				if (obj.TieneAutonomia != "SIN_REGLAS")
				{
					foreach (ItemGenerico objItem in objListaTipoGarantia)
					{
						if (objItem.Descripcion.ToUpper() == obj.TipoDeGarantia.ToUpper())
						{
							objGarantia.garantia = objItem.Descripcion.ToUpper();
							objGarantia.idGarantia = objItem.Codigo;
							break;
						}
					}

					if (obj.Tipodecobro == "REFERENCIAL")
						dblImporte = obj.MontoDeGarantia * obj.CargoFijo;
					else
						dblImporte = obj.MontoDeGarantia;

					if (obj.CargoFijo > 0)
					{
						// CALCULO IMPORTE DTH
						if (obj.IdProducto == consTipoProductoDTH)
						{
							if (dblImporte % 5 > 0)
								dblImporte = 5 * (Funciones.CheckInt(dblImporte / 5) + 1);
						}
						dblNroGarantia = Math.Round(dblImporte / obj.CargoFijo, 2);
					}

					objGarantia.nroGarantia = dblNroGarantia;
					objGarantia.importe = Funciones.CheckDbl(dblImporte, 2);
				}

				dblImporteTotal += objGarantia.importe;
				objListaGarantia.Add(objGarantia);
			}

			objVistaEvaluacion.oGarantia = new ArrayList(objListaGarantia);

			string strCostoInstalacion = ConfigurationSettings.AppSettings["constMsjSinCostoInstalacion"].ToString();
			objVistaEvaluacion.oOfrecimiento = new ArrayList();

			foreach (Ofrecimiento obj in objOfrecimiento)
			{
				if (obj.TieneAutonomia != "SIN_REGLAS")
				{
					objVistaEvaluacion.riesgoClaro = obj.RiesgoEnClaro;
					objVistaEvaluacion.comportamientoPago = obj.ComportamientoConsolidado.ToString();
					objVistaEvaluacion.exoneraRA = "NO";
					objVistaEvaluacion.tipoGarantia = obj.TipoDeGarantia;
					objVistaEvaluacion.importeGarantia = dblImporteTotal;

					if (obj.ProcesoDeExoneracionDeRentas == "SI")
						objVistaEvaluacion.exoneraRA = obj.ProcesoDeExoneracionDeRentas;
				}
				objVistaEvaluacion.cargoFijo += obj.CargoFijo; 
				strCostoInstalacion = obj.CostoDeInstalacion.ToString();
				objVistaEvaluacion.LCDisponible = obj.LcDisponible;

				if (objVistaEvaluacion.planAutonomia == null) objVistaEvaluacion.planAutonomia = string.Format("{0};{1};{2}", obj.IdFila, obj.TieneAutonomia, strCostoInstalacion);
				else objVistaEvaluacion.planAutonomia = string.Format("{0}|{1};{2};{3}", objVistaEvaluacion.planAutonomia, obj.IdFila, obj.TieneAutonomia, strCostoInstalacion);

				objVistaEvaluacion.oOfrecimiento.Add(obj);
			}

			return objVistaEvaluacion;
		}

		private int CalcularNroPlanesxProducto(ArrayList objLista, ArrayList objBilleteraActual)
		{
			int nroPlanes = objBilleteraActual.Count;
			foreach (Billetera obj in objBilleteraActual)
			{
				foreach (OfertaBRMS obj1 in objLista)
				{
					foreach (Billetera obj2 in obj1.oBilletera)
					{
						if (obj.idBilletera == obj2.idBilletera) nroPlanes++;
					}
				}
			}
			return nroPlanes;
		}

		private int CalcularNroPlanesActivoxProducto(ArrayList objLista, ArrayList objBilleteraActual)
		{
			int nroPlanes = 0;
			if (objLista != null)
			{
				foreach (Billetera obj in objBilleteraActual)
				{
					foreach (PlanBilletera obj1 in objLista)
					{
						foreach (Billetera obj2 in obj1.oBilletera)
						{
							if (obj.idBilletera == obj2.idBilletera)
								nroPlanes += obj1.nroPlanes;
						}
					}
				}
			}
			return nroPlanes;
		}

		private double CalcularMontoxProducto(ArrayList objLista, ArrayList objBilleteraActual)
		{
			double dblMonto = 0.0;
			if (objLista != null)
			{
				foreach (Billetera obj in objLista)
				{
					foreach (Billetera obj1 in objBilleteraActual)
					{
						if (obj.idBilletera == obj1.idBilletera)
						{
							dblMonto += obj.monto;
							break;
						}
					}
				}
			}
			return dblMonto;
		}

		private double CalcularCFEvaluado(ArrayList objListaEvaluado, ArrayList objBilleteraActual)
		{
			double dblCF = 0.0;
			foreach (Billetera obj in objBilleteraActual)
			{
				foreach (OfertaBRMS obj1 in objListaEvaluado)
				{
					foreach (Billetera obj2 in obj1.oBilletera)
					{
						if (obj.idBilletera == obj2.idBilletera)
						{
							dblCF += obj1.cargoFijo;
							break;
						}
					}
				}
			}
			return dblCF;
		}

		private ReglasEvaluacionWS.tipoDeDocumento ObtenerTipoDocumento(string strTipoDoc, string strNroDoc)
		{
			if (strTipoDoc == ConfigurationSettings.AppSettings["constCodTipoDocumentoDNI"].ToString())
				return ReglasEvaluacionWS.tipoDeDocumento.DNI;

			if (strTipoDoc == ConfigurationSettings.AppSettings["constCodTipoDocumentoCEX"].ToString())
				return ReglasEvaluacionWS.tipoDeDocumento.CE;

			if (strTipoDoc == ConfigurationSettings.AppSettings["constCodTipoDocumentoRUC"].ToString())
			{
				if (strNroDoc.Substring(0, 1) == "1") return ReglasEvaluacionWS.tipoDeDocumento.RUC10;
				else return ReglasEvaluacionWS.tipoDeDocumento.RUC20;
			}
			//PROY 31636 RENTESEG
			if (strTipoDoc == AppSettings.Key_codigoDocCIRE.ToString())
				return ReglasEvaluacionWS.tipoDeDocumento.CIRE;

			if (strTipoDoc == AppSettings.Key_codigoDocCIE.ToString())
				return ReglasEvaluacionWS.tipoDeDocumento.CIE;

			if (strTipoDoc == AppSettings.Key_codigoDocCPP.ToString())
				return ReglasEvaluacionWS.tipoDeDocumento.CPP;

			if (strTipoDoc == AppSettings.Key_codigoDocCTM.ToString())
				return ReglasEvaluacionWS.tipoDeDocumento.CTM;
			if(strTipoDoc == AppSettings.Key_codigoDocPasaporte07)
				return ReglasEvaluacionWS.tipoDeDocumento.PASAPORTE;
			//PROY 31636 RENTESEG
			return ReglasEvaluacionWS.tipoDeDocumento.DNI;
		}

		//PROY-24740
		private void grabarLog(ReglasEvaluacionWS.ClaroEvalClientesReglasRequest oEvaluacion, ref Ofrecimiento oOfrecimiento)
		{
			StringBuilder strSolicitud = new StringBuilder();
			StringBuilder strCliente =new StringBuilder();
			StringBuilder strDirCliente = new StringBuilder();
			StringBuilder strDocCliente = new StringBuilder();
			StringBuilder strOferta = new StringBuilder();
			StringBuilder strCampana = new StringBuilder();
			StringBuilder strPlanActual = new StringBuilder();
			StringBuilder strPlan = new StringBuilder();
			StringBuilder strOficina = new StringBuilder();
			StringBuilder strDirOficina = new StringBuilder();
			StringBuilder strRepLegal = new StringBuilder();
			StringBuilder strServicio = new StringBuilder();
			StringBuilder strEquipo = new StringBuilder();
			StringBuilder strOfrecimiento = new StringBuilder();

			ReglasEvaluacionWS.solicitud1 oSolicitud;
			ReglasEvaluacionWS.cliente oCliente;
			ReglasEvaluacionWS.oferta oOferta;

			oSolicitud = oEvaluacion.solicitud.solicitud1;
			oCliente = oEvaluacion.solicitud.solicitud1.cliente;
			oOferta = oEvaluacion.solicitud.solicitud1.oferta;

			// Información Solicitud --------------------------------------------
			strSolicitud.AppendFormat("{0}|",oSolicitud.cargoFijoDeBolsa);
			strSolicitud.AppendFormat("{0}|",oSolicitud.flagDeLicitacion.ToString());
			strSolicitud.AppendFormat("{0}|",oSolicitud.tipoDeBolsa);
			strSolicitud.AppendFormat("{0}|",oSolicitud.tipoDeDespacho);
			strSolicitud.AppendFormat("{0}|",oSolicitud.tipoDeOperacion);
			//strSolicitud.Append(oSolicitud.transaccion.ToString());
                        strSolicitud.AppendFormat("{0}|",oSolicitud.transaccion.ToString()); //'PROY-24724-IDEA-28174  
                        strSolicitud.AppendFormat("{0}|",oSolicitud.fechaEjecucion);//'PROY-24724-IDEA-28174  
                        strSolicitud.AppendFormat("{0}|",oSolicitud.horaEjecucion);//'PROY-24724-IDEA-28174  
//gaa20170215
			if (oSolicitud.buroConsultado == null)
				oSolicitud.buroConsultado = string.Empty;
			strSolicitud.Append(Funciones.CheckStr(oSolicitud.buroConsultado));
//gaa20170215
			// Información Cliente ----------------------------------------------
			strCliente.AppendFormat("{0}|",oCliente.cantidadDeLineasActivas);
			strCliente.AppendFormat("{0}|",oCliente.cantidadDePlanesPorProducto);
			strCliente.AppendFormat("{0}|",oCliente.comportamientoDePago);
			strCliente.AppendFormat("{0}|",oCliente.creditScore);
			strCliente.AppendFormat("{0}|",oCliente.edad);
			strCliente.AppendFormat("{0}|",oCliente.facturacionPromedioClaro);
			strCliente.AppendFormat("{0}|",oCliente.facturacionPromedioProducto);
			strCliente.AppendFormat("{0}|",oCliente.limiteDeCreditoDisponible );
			strCliente.AppendFormat("{0}|",oCliente.riesgo);
			strCliente.AppendFormat("{0}|",oCliente.sexo);
			strCliente.AppendFormat("{0}|",oCliente.tiempoDePermanencia);
			strCliente.Append(oCliente.tipo);

			// Información Dirección Cliente ---------------------------------------
			if (oCliente.direccion != null)
			{
				strDirCliente.AppendFormat("{0}|",oCliente.direccion.codigoDePlano);
				strDirCliente.AppendFormat("{0}|",oCliente.direccion.departamento);
				strDirCliente.AppendFormat("{0}|",oCliente.direccion.distrito);
				strDirCliente.AppendFormat("{0}|",oCliente.direccion.provincia);
				strDirCliente.Append(oCliente.direccion.region);
			}

			// Información Documento Cliente ---------------------------------------
			strDocCliente.AppendFormat("{0}|",oCliente.documento.descripcion.ToString());
			strDocCliente.Append(oCliente.documento.numero);

			// Información Representante Cliente -----------------------------------
			if (oSolicitud.cliente.representanteLegal != null)
			{
				foreach (ReglasEvaluacionWS.representanteLegal rrll in oSolicitud.cliente.representanteLegal)
				{
					strRepLegal.AppendFormat("{0}|",rrll.documento.descripcion.ToString());
					strRepLegal.AppendFormat("{0}|",rrll.documento.numero.ToString());
					strRepLegal.AppendFormat("{0}_",rrll.riesgo);
				}
			}

			// Información Servicios Cliente --------------------------------------
			if (oOferta.planSolicitado.servicio != null)
			{
				foreach (ReglasEvaluacionWS.servicio oServicio in oOferta.planSolicitado.servicio)
				{
					strServicio.AppendFormat("{0}_",oServicio.nombre);
				}
			}

			// Información Equipos Cliente ----------------------------------------
			if (oSolicitud.equipo != null)
			{
				foreach (ReglasEvaluacionWS.equipo oEquipo in oSolicitud.equipo)
				{
					strEquipo.AppendFormat("{0}|",oEquipo.costo);
					strEquipo.AppendFormat("{0}|",oEquipo.cuotas);
					strEquipo.AppendFormat("{0}|",oEquipo.formaDePago);
					strEquipo.AppendFormat("{0}|",oEquipo.gama);
					strEquipo.AppendFormat("{0}|",oEquipo.modelo);
					strEquipo.AppendFormat("{0}|",oEquipo.montoDeCuota);
					strEquipo.AppendFormat("{0}|",oEquipo.porcentajecuotaInicial);
					strEquipo.AppendFormat("{0}|",oEquipo.precioDeVenta);
					strEquipo.AppendFormat("{0}|",oEquipo.tipoDeDeco);
					strEquipo.AppendFormat("{0}_",oEquipo.tipoOperacionKit);
				}
			}

			// Información Oferta --------------------------------------------------
			strOferta.AppendFormat("{0}|",oOferta.cantidadDeDecos);
			strOferta.AppendFormat("{0}|",oOferta.casoEpecial);
			strOferta.AppendFormat("{0}|",oOferta.controlDeConsumo);
			strOferta.AppendFormat("{0}|",oOferta.kitDeInstalacion);
			strOferta.AppendFormat("{0}|",oOferta.plazoDeAcuerdo);
			strOferta.AppendFormat("{0}|",oOferta.productoComercial);
			strOferta.AppendFormat("{0}|",oOferta.segmentoDeOferta);
			strOferta.AppendFormat("{0}|",oOferta.tipoDeOperacionEmpresa);
			strOferta.AppendFormat("{0}|",oOferta.tipoDeProducto);
			strOferta.AppendFormat("{0}|",oOferta.modalidadCedente);
			strOferta.AppendFormat("{0}|",oOferta.operadorCedente);
			strOferta.AppendFormat("{0}|",oOferta.combo); //'PROY-24724-IDEA-28174 
                        strOferta.AppendFormat("{0}|",oOferta.proteccionMovil); //'PROY-24724-IDEA-28174 
//gaa20170215
			strOferta.AppendFormat("|{0}|", Funciones.CheckStr(oOferta.cantidadLineasSEC));//se esta considerando con mesoperadorcedente, para estar alineado con consumer
			strOferta.Append(Funciones.CheckStr(oOferta.montoCFSEC));
//gaa20170215
			// Información Plan Actual -----------------------------------------------
			strPlanActual.AppendFormat("{0}|",oOferta.planActual.cargoFijo);
			strPlanActual.AppendFormat("{0}|",oOferta.planActual.descripcion);
			//strPlanActual.Append("|||");//considerando tiempo de permanencia
			// No se cuenta con Información
			//			strPlanActual += oOferta.planActual.mesesParaCubrirApadece + "|";
			//			strPlanActual += oOferta.planActual.plazoDeAcuerdo + "|";
//gaa20161122
			strPlanActual.AppendFormat("{0}|",oOferta.planActual.mesesParaCubrirApadece);
			strPlanActual.AppendFormat("{0}|",oOferta.planActual.plazoDeAcuerdo);
			strPlanActual.AppendFormat("{0}|",oOferta.planActual.tiempoPermanencia);   	//MAF
//fin gaa20161122
			// Información Plan Solicitado -------------------------------------------
			strPlan.AppendFormat("{0}|",oOferta.planSolicitado.cargoFijo);
			strPlan.AppendFormat("{0}|",oOferta.planSolicitado.descripcion);
			strPlan.AppendFormat("{0}|",oOferta.planSolicitado.paquete);

			// Información Campaña ---------------------------------------------------
			strCampana.AppendFormat("{0}|",oOferta.campana.grupo);
			strCampana.Append(oOferta.campana.tipo);

			// Información Punto de Venta --------------------------------------------
			strOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.calidadDeVendedor);
			strOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.canal);
			strOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.codigo);
			strOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.descripcion);

			// Información Dirección Punto de Venta ----------------------------------
			strDirOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.direccion.codigoDePlano);
			strDirOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.direccion.departamento);
			strDirOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.direccion.distrito);
			strDirOficina.AppendFormat("{0}|",oSolicitud.puntodeVenta.direccion.provincia);
			strDirOficina.Append(oSolicitud.puntodeVenta.direccion.region);

			// Información Ofrecimiento ----------------------------------------------
			if (oOfrecimiento.TieneAutonomia != "SIN_REGLAS")
			{
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.CantidadDeAplicacionesRenta);				
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.CantidadDeLineasAdicionalesRUC);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.CantidadDeLineasMaximas);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.AutonomiaRenovacion);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.CapacidadDePago);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.ComportamientoConsolidado);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.ComportamientoDePagoC1);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.ControlDeConsumo);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.CostoDeInstalacion);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.CostoTotalEquipos);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.FactorDeEndeudamientoCliente);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.FactorDeRenovacionCliente);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.FrecuenciaDeAplicacionMensual);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.LimiteDeCreditoCobranza);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.MesInicioRentas);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.MontoCFParaRUC);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.MontoDeGarantia);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.MontoTopeAutomatico);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.PrecioDeVentaTotalEquipos);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.PrioridadPublicar);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.ProcesoDeExoneracionDeRentas);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.ProcesoIDValidator);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.ProcesoValidacionInternaClaro);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.Publicar);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.Restriccion);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.RiesgoEnClaro);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.RiesgoOferta);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.RiesgoTotalEquipo);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.RiesgoTotalRepLegales);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.TipoDeAutonomiaCargoFijo);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.Tipodecobro);
				strOfrecimiento.AppendFormat("{0}|",oOfrecimiento.TipoDeGarantia);
			}
			strOfrecimiento.Append(oOfrecimiento.FlagExito);

			oOfrecimiento.In_solicitud = strSolicitud.ToString();
			oOfrecimiento.In_cliente = strCliente.ToString();
			oOfrecimiento.In_direccion_cliente = strDirCliente.ToString();
			oOfrecimiento.In_doc_cliente = strDocCliente.ToString();
			oOfrecimiento.In_rrll_cliente = strRepLegal.ToString();
			oOfrecimiento.In_equipo = strEquipo.ToString();
			oOfrecimiento.In_oferta = strOferta.ToString();
			oOfrecimiento.In_campana = strCampana.ToString();
			oOfrecimiento.In_plan_actual = strPlanActual.ToString();
			oOfrecimiento.In_plan_solicitado = strPlan.ToString();
			oOfrecimiento.In_servicio = strServicio.ToString();
			oOfrecimiento.In_pdv = strOficina.ToString();
			oOfrecimiento.In_direccion_pdv = strDirOficina.ToString();

			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strSolicitud : " , strSolicitud.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strCliente : " , strCliente.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strDirCliente : " , strDirCliente.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strDocCliente : " , strDocCliente.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strRepLegal : " , strRepLegal.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strEquipo : " , strEquipo.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strOferta : " , strOferta.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strCampana : " , strCampana.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strPlanActual : " , strPlanActual.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strPlan : " , strPlan.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strServicio : " , strServicio.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strOficina : " , strOficina.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strDirOficina : " , strDirOficina.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "strOfrecimiento : " , strOfrecimiento.ToString()), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}{3}", nroDocumento , " - " , "mensaje error : " ,  oOfrecimiento.Mensaje), false);
			HelperLog.EscribirLog("", nameArchivo,string.Format("{0}{1}{2}", nroDocumento , " - " , "---------------------------------------------------"), false);
		}
	}
}
