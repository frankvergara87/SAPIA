using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.SapGeneral;
using Claro.SisAct.Common;
using System.Data;


namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de SapGeneralNegocios.
	/// </summary>
	public class SapGeneralNegocios
	{
		public SapGeneralNegocios()
		{
		}

		public ArrayList ConsultarListaPrecios(string p_tipo_venta, string p_plan_tarif, string p_codigo_material, string p_codigo_campania,
			string p_org_venta, string p_fecha, string p_tipo_operacion)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarListaPrecios(p_tipo_venta, p_plan_tarif, p_codigo_material, p_codigo_campania,
				p_org_venta, p_fecha, p_tipo_operacion);
		}
		public DataSet ConsultarPrecio(string p_oficina, string p_documento_origen, string p_consecutivo, string p_material,
			string p_utilizacion,decimal p_cantidad, string p_fecha, string p_serie, string p_nro_telefono, string p_tipo_doc_venta,
			string p_cadena_series, string p_canal, string p_org_vnt,string p_disp_IMEI, out decimal p_descuento,out decimal p_prec_incIGV,
			out decimal p_precio, out decimal p_subTotal) 
		{
			clsGeneral obj = new clsGeneral();

			return obj.ConsultarPrecio(p_oficina, p_documento_origen, p_consecutivo, p_material, p_utilizacion, p_cantidad, p_fecha, p_serie,
				p_nro_telefono, p_tipo_doc_venta, p_cadena_series, p_canal, p_org_vnt, p_disp_IMEI, out p_descuento, out p_prec_incIGV,
				out p_precio, out p_subTotal);
		}
		public DataSet ConsultarParametrosOfVenta(string p_oficina_venta)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarParametrosOfVenta(p_oficina_venta);
		}
		public DataSet ConsultarTipoDocumentoOfVenta(string p_oficina_venta)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarTipoDocumentoOfVenta(p_oficina_venta);
		}
		public bool RealizarPedido(string CadenaCabecera,string CadenaDetalle, string CadenaSeries,
									string CadenaServAdic, string CadenaAcuerdo, out string strEntrega, out string strFactura,
									out string strNroContrato, out string strNroDocCliente, out string strNroPedido,
									out string strRefHistorico, out string strTipDocCliente, out decimal dblValorDescuento)
		{
			clsGeneral obj = new clsGeneral();
			return obj.RealizarPedido(CadenaCabecera, CadenaDetalle, CadenaSeries, CadenaServAdic, CadenaAcuerdo,
										out strEntrega, out strFactura, out strNroContrato, out strNroDocCliente, out strNroPedido,
										out strRefHistorico, out strTipDocCliente, out dblValorDescuento);
		}
		public DataSet Set_ActualizaCreaCliente(string OficinaVta, string[] arrCliente)
		{
			clsGeneral obj = new clsGeneral();
			return obj.Set_ActualizaCreaCliente( OficinaVta,  arrCliente);
		}
		public DataSet Get_ConsultaCliente(string Oficina,string TipDocCliente ,string Cliente) 
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaCliente( Oficina,  TipDocCliente,Cliente);
		}
		public DataSet SetGetLogActivacionChip(string nroDocumento,string puntoVenta,string strLog,ref string nroSolicitud) 
		{
			clsGeneral obj = new clsGeneral();
			return obj.SetGetLogActivacionChip(nroDocumento, puntoVenta, strLog, ref nroSolicitud);
		}
		public DataSet Get_ConsultaPedido(string Referencia,string Oficina,string Nro_Sap,string Tipo_Documento)
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaPedido(Referencia, Oficina, Nro_Sap, Tipo_Documento);
		}
		public string ConsultarIccid(string Clase_Venta, string Nro_Telefono, string Tipo_Venta)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarIccid(Clase_Venta, Nro_Telefono, Tipo_Venta);
		}
		public ItemGenerico ConsultarMaterial(string p_codigo_iccid_imei) 
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarMaterial(p_codigo_iccid_imei);
		}
		public ArrayList Get_ConsultaCampana(string FechaVenta, string TipoVenta) 
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaCampana(FechaVenta, TipoVenta);
		}

		public string Get_Consulta_Prefijo(string Fecha_Documento, string Oficina_Venta, string Tipo_Documento)
		{
			clsGeneral obj = new  clsGeneral();
			return obj.Get_Consulta_Prefijo(Fecha_Documento,Oficina_Venta,Tipo_Documento);
		}

		public bool Get_RegistroAcuerdoPCS(string[] arrAcuerdo, string CadenaServAdic,out string Nro_Contrato, ref string mensaje)
		{
			clsGeneral obj = new  clsGeneral();
			return obj.Get_RegistroAcuerdoPCS(arrAcuerdo,CadenaServAdic,out Nro_Contrato, ref mensaje);

		}
		public bool Set_EstadoAcuerdoPCS(string NroContrato, string Estado, string Usuario,string AnalistaCredito, string CodigoAprobacion,string TipoRechazo, string Observaciones, string NumeroHDC){
			clsGeneral obj = new  clsGeneral();
			return obj.Set_EstadoAcuerdoPCS( NroContrato,  Estado,  Usuario, AnalistaCredito,  CodigoAprobacion, TipoRechazo,  Observaciones,  NumeroHDC);

		}
		public ArrayList ConsultarListaVendedores(string p_oficina_venta)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarListaVendedores(p_oficina_venta);
		}

		// JAZ : Renov Prepago
		public ArrayList get_ConsultaMaterial(string FechaVenta, string Material, string TipoVenta, string Oficina, string ClaseVenta)
		{
			clsGeneral obj = new clsGeneral();
			return obj.get_ConsultaMaterial(FechaVenta, Material, TipoVenta, Oficina, ClaseVenta);
		}

		public DataSet get_ConsultaHistoria(string Flag, string Nro_Telefono, string Oficina_Venta)
		{
			clsGeneral obj = new clsGeneral();
			return obj.get_ConsultaHistoria( Flag, Nro_Telefono, Oficina_Venta);		
		}

		public ArrayList Get_ConsultaMotivosReposicion(string Motivo) 
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaMotivosReposicion(Motivo);
		}
		public ArrayList Get_ObtenerMaterialesPDV(string p_tipo_operacion, string p_fecha,string p_codigo_material, string p_oficina_venta, string p_tipo_venta) 
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ObtenerMaterialesPDV( p_tipo_operacion,  p_fecha, p_codigo_material,  p_oficina_venta,  p_tipo_venta);
		}
		public ArrayList Get_ConsultaPlanTarifario(string tipoClienteAct,string Utilizacion, string TipoVenta, string CodPlan)
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaPlanTarifario(tipoClienteAct, Utilizacion, TipoVenta, CodPlan);
		}
		public string ConsultarPrefijo(string p_fecha_documento, string p_oficina_venta, string p_tipo_documento)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarPrefijo(p_fecha_documento, p_oficina_venta, p_tipo_documento);
		}
		public DataSet ConsultarAcuerdo(string p_nro_contrato, string p_nro_contrato_pcs)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarAcuerdo(p_nro_contrato, p_nro_contrato_pcs);
		}
		public ItemGenerico ConsultarEstadoCivil(string p_est_civil_codigo)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarEstadoCivil(p_est_civil_codigo);
		}

		public void ConsultarUbigeo(string p_ubigeo, out string dep_cod, out string dep_desc, out string prov_cod, out string prov_desc,
			out string dist_cod, out string dist_desc, out string codigo_postal)
		{
			clsGeneral obj = new clsGeneral();
			obj.ConsultarUbigeo(p_ubigeo, out dep_cod, out dep_desc, out prov_cod, out prov_desc, out dist_cod, out dist_desc,
				out codigo_postal);
		}
		public ItemGenerico ConsultarPlazoAcuerdo(string p_plazo_codigo)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarPlazoAcuerdo(p_plazo_codigo);
		}

		// Agregado -EMC-
		public ArrayList get_seriesxMaterial(string oficina,string material,string resultados,string telefono)
		{
			clsGeneral obj = new clsGeneral();
			return obj.get_seriesxMaterial(oficina, material, resultados, telefono);
		}

		public DataSet Set_AnularDocumentoJob(string CadenaDocumento, string Usuario) 
		{
			clsGeneral obj = new clsGeneral();
			return obj.Set_AnularDocumentoJob(CadenaDocumento, Usuario);
		}

		public  Boolean Set_ActualizaEstadoPedido(string NroPedido, string OficinaVenta, string Almacenero, string Despachador )
		{
			clsGeneral obj = new clsGeneral();
			return obj.Set_ActualizaEstadoPedido(NroPedido, OficinaVenta, Almacenero, Despachador );
		}

		public DataSet Get_ConsultaCierreCaja(string p_oficinaVenta, string p_fecha, out string v_cierre_realizado )
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaCierreCaja(p_oficinaVenta, p_fecha, out v_cierre_realizado);
		}

		public ArrayList get_ConsultaMaterialRe(string pstrCampana, string pstrPDV, string pstrOrgVenta, string pstrCentro, string pstrPlan, ref int pintRC)
		{
			clsGeneral obj = new clsGeneral();
			return obj.get_ConsultaMaterialRe(pstrCampana, pstrPDV, pstrOrgVenta, pstrCentro, pstrPlan, ref pintRC);
		}

		public ArrayList Get_ConsultaCampana_X_Plan(string pstrPlan, ref int pintRC)
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaCampana_X_Plan(pstrPlan, ref pintRC);
		}

		public DataTable Get_CostoPromedio(string PGRUPO, string PMATNR, string PWERKS)
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_CostoPromedio(PGRUPO, PMATNR, PWERKS);
		}

		public ArrayList ConsultarLPrecio(string p_canal, string p_tipo_doc_venta, string p_tipo_venta, string p_plan_tarif, string p_codigo_material, string p_codigo_campania,
										  string p_org_venta, string p_fecha, string p_tipo_operacion, string p_plazo_acuerdo, string p_oficina)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarLPrecio(p_canal, p_tipo_doc_venta, p_tipo_venta, p_plan_tarif, p_codigo_material, p_codigo_campania,
										p_org_venta, p_fecha, p_tipo_operacion, p_plazo_acuerdo, p_oficina);
		}

		public ArrayList ConsultarListaPreciosRP(string p_tipo_venta, string p_plan_tarif, string p_codigo_material, string p_codigo_campania,
			string p_org_venta, string p_fecha, string p_tipo_operacion)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarListaPreciosRP(p_tipo_venta, p_plan_tarif, p_codigo_material, p_codigo_campania,
				p_org_venta, p_fecha, p_tipo_operacion);
		}

		public ArrayList Get_ConsultaPlanServicio(string plan, string servicio)
		{
			clsGeneral obj = new clsGeneral();
			return obj.Get_ConsultaPlanServicio(plan, servicio);
		}

		//Chip Repuesto Postpago
		public ArrayList ConsultarListaPreciosMaestro(string p_codigo_articulo, string p_codigo_campana, string p_fecha_Venta, 
			string p_tipo_operacion, string p_tipo_Venta)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarListaPreciosMaestro(p_codigo_articulo,p_codigo_campana,p_fecha_Venta,p_tipo_operacion,p_tipo_Venta);
		}
		//Chip Repuesto Postpago

                
                //sans
		public string ConsultarIccid_Zs(string Clase_Venta, string Nro_Telefono, string Tipo_Venta, string Fecha_Cambio, string Material, string Material_Antig, string Serie)
		{
			clsGeneral obj = new clsGeneral();
			return obj.ConsultarIccid_Zs(Clase_Venta, Nro_Telefono, Tipo_Venta, Fecha_Cambio, Material, Material_Antig, Serie);
		}
		//fin sans

		//consolidado 21012015

		public bool CrearDepositoGarantia(string CadenaDeposito, out string NroDeposito)
		{
			clsGeneral obj = new clsGeneral();
			return obj.CrearDepositoGarantia(CadenaDeposito, out NroDeposito);
		}


		//consolidado 21012015
	}
}
