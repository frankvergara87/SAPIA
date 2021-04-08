using System;
using System.Collections;
using Claro.SisAct.Common;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PlanDetalleVenta.
	/// </summary>
	public class PlanDetalleVenta
	{
		public PlanDetalleVenta()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private Int64 _PLVTN_CODIGO;
		private Int64 _SOLIN_CODIGO;
		private Int64 _SOPLN_CODIGO;
		private Int64 _SOPLN_SECUENCIA;
		private Int64 _SOPLN_ORDEN;

		private string _PAQTV_CODIGO;
		private string _PAQTV_DESCRIPCION;
		private string _PLANC_CODIGO;
		private string _PLANV_DESCRIPCION;
		private string _TPROC_CODIGO;
		private string _TPROV_DESCRIPCION;

		private int _SOPLN_CANTIDAD;

		private double _CARGO_FIJO;
		private double _SOPLC_MONTO_TOTAL;
		
		private double _TOPE_MONTO;

		private string _TELEFONO;
		private string _MATERIAL;
		private string _MATERIAL_DESC;
		private string _PACUC_CODIGO;
		private string _PACUV_DESCRIPCION;
		private string _CAMPANA;
		private string _CAMPANA_DESC;
		private string _LISTA_PRECIO;
		private string _LISTA_PRECIO_DESC;
		private double _PRECIO_LISTA;
		private double _PRECIO_VENTA;

		private string _CUOTA_DESCRIPCION;
		private string _CUOTA_CODIGO = "00";
		private double _CUOTA_INICIAL = 100;
		private string _SOPLV_PAQU_AGRU;		
		private string _SUBSIDIO;
		private int _PLNN_TIPO_PLAN;
		private double _CARGO_FIJO_LIN;
		private double _SOLIN_COSTO_INST_DTH;

		private string _CASO_ESPECIAL;
		private string _OFERTA;
		private string _TIPO_PRODUCTO;
		private string _FLAG_PORTABILIDAD;
		private string _RIESGO;
		private string _TIPO_OFICINA;
		private string _OFICINA;
		private string _TOPE_CODIGO;
		private string _TOPE_DESCRIPCION;
		private string _TOPEN_CODIGO;	//TIPO OPERACION
		private string _GRUPO_PLAN;
		private string _PRDC_CODIGO;		//TABLA SISACT_AP_PRODUCTO
		private string _PRDV_DESCRIPCION;
		private ArrayList _SERVICIO;
		private PlanSolicitudDTH _PLAN_SOL_DTH;
		private PlanSolicitudHFC _PLAN_SOL_HFC;
		private Int64 _ID_SOLUCION;
		private string _SOLUCION;
		private Int64 _IDDET;
		private Int64 _IDPRODUCTO;
		private Int64 _IDLINEA;
		private string _MODALIDAD_VENTA;
		//gaa20161024
		private string _FAMILIA_PLAN;
		private string _FAMILIA_PLAN_DES;
		//fin gaa20161024
		public Int64 PLVTN_CODIGO
		{
			get { return this._PLVTN_CODIGO; }
			set { this._PLVTN_CODIGO = value; }
		}

		public Int64 SOLIN_CODIGO
		{
			get { return this._SOLIN_CODIGO; }
			set { this._SOLIN_CODIGO = value; }
		}

		public Int64 SOPLN_CODIGO
		{
			get { return this._SOPLN_CODIGO; }
			set { this._SOPLN_CODIGO = value; }
		}

		public Int64 SOPLN_SECUENCIA
		{
			get { return this._SOPLN_SECUENCIA; }
			set { this._SOPLN_SECUENCIA = value; }
		}

		public Int64 SOPLN_ORDEN
		{
			get { return this._SOPLN_ORDEN; }
			set { this._SOPLN_ORDEN = value; }
		}

		public string PAQTV_CODIGO
		{
			get { return this._PAQTV_CODIGO; }
			set { this._PAQTV_CODIGO = value; }
		}

		public string PAQTV_DESCRIPCION
		{
			get { return this._PAQTV_DESCRIPCION; }
			set { this._PAQTV_DESCRIPCION = value; }
		}

		public string PLANC_CODIGO
		{
			get { return this._PLANC_CODIGO; }
			set { this._PLANC_CODIGO = value; }
		}

		public string PLANV_DESCRIPCION
		{
			get { return this._PLANV_DESCRIPCION; }
			set { this._PLANV_DESCRIPCION = value; }
		}

		public string TPROC_CODIGO
		{
			get { return this._TPROC_CODIGO; }
			set { this._TPROC_CODIGO = value; }
		}

		public int SOPLN_CANTIDAD
		{
			get { return this._SOPLN_CANTIDAD; }
			set { this._SOPLN_CANTIDAD = value; }
		}

		public double CARGO_FIJO
		{
			get { return this._CARGO_FIJO; }
			set { this._CARGO_FIJO = value; }
		}

		public double SOPLC_MONTO_TOTAL
		{
			get { return this._SOPLC_MONTO_TOTAL; }
			set { this._SOPLC_MONTO_TOTAL = value; }
		}

		public double TOPE_MONTO
		{
			get { return this._TOPE_MONTO; }
			set { this._TOPE_MONTO = value; }
		}

		public string TELEFONO
		{
			get { return this._TELEFONO; }
			set { this._TELEFONO = value; }
		}

		public string MATERIAL
		{
			get { return this._MATERIAL; }
			set { this._MATERIAL = value; }
		}

		public string MATERIAL_DESC
		{
			get { return this._MATERIAL_DESC; }
			set { this._MATERIAL_DESC = value; }
		}

		public string PACUC_CODIGO
		{
			get { return this._PACUC_CODIGO; }
			set { this._PACUC_CODIGO = value; }
		}

		public string PACUV_DESCRIPCION
		{
			get { return this._PACUV_DESCRIPCION; }
			set { this._PACUV_DESCRIPCION = value; }
		}

		public string CAMPANA
		{
			get { return this._CAMPANA; }
			set { this._CAMPANA = value; }
		}

		public string CAMPANA_DESC
		{
			get { return this._CAMPANA_DESC; }
			set { this._CAMPANA_DESC = value; }
		}

		public string LISTA_PRECIO
		{
			get { return this._LISTA_PRECIO; }
			set { this._LISTA_PRECIO = value; }
		}

		public string LISTA_PRECIO_DESC
		{
			get { return this._LISTA_PRECIO_DESC; }
			set { this._LISTA_PRECIO_DESC = value; }
		}

		public double PRECIO_LISTA
		{
			get { return this._PRECIO_LISTA; }
			set { this._PRECIO_LISTA = value; }
		}

		public double PRECIO_VENTA
		{
			get { return this._PRECIO_VENTA; }
			set { this._PRECIO_VENTA = value; }
		}

		public string CUOTA_DESCRIPCION
		{
			get { return this._CUOTA_DESCRIPCION; }
			set { this._CUOTA_DESCRIPCION = value; }
		}

		public string CUOTA_CODIGO
		{
			get { return this._CUOTA_CODIGO; }
			set { this._CUOTA_CODIGO = value; }
		}

		public double CUOTA_INICIAL
		{
			get { return this._CUOTA_INICIAL; }
			set { this._CUOTA_INICIAL = value; }
		}

		public string SOPLV_PAQU_AGRU
		{
			get { return this._SOPLV_PAQU_AGRU; }
			set { this._SOPLV_PAQU_AGRU = value; }
		}

		public int PLNN_TIPO_PLAN
		{
			get { return this._PLNN_TIPO_PLAN; }
			set { this._PLNN_TIPO_PLAN = value; }
		}

		public string SUBSIDIO
		{
			get { return this._SUBSIDIO; }
			set { this._SUBSIDIO = value; }
		}		

		public double CARGO_FIJO_LIN
		{
			get { return this._CARGO_FIJO_LIN; }
			set { this._CARGO_FIJO_LIN = value; }
		}

		public double SOLIN_COSTO_INST_DTH
		{
			get { return this._SOLIN_COSTO_INST_DTH; }
			set { this._SOLIN_COSTO_INST_DTH = value; }
		}

//gaa20121122
		public string CASO_ESPECIAL
		{
			get { return this._CASO_ESPECIAL; }
			set { this._CASO_ESPECIAL = value; }
		}

		public string OFERTA
		{
			get { return this._OFERTA; }
			set { this._OFERTA = value; }
		}

		public string TIPO_PRODUCTO
		{
			get { return this._TIPO_PRODUCTO; }
			set { this._TIPO_PRODUCTO = value; }
		}

		public string FLAG_PORTABILIDAD
		{
			get { return this._FLAG_PORTABILIDAD; }
			set { this._FLAG_PORTABILIDAD = value; }
		}
		public string RIESGO
		{
			get { return this._RIESGO; }
			set { this._RIESGO = value; }
		}
		public string TIPO_OFICINA
		{
			get { return this._TIPO_OFICINA; }
			set { this._TIPO_OFICINA = value; }
		}
		public string OFICINA
		{
			get { return this._OFICINA; }
			set { this._OFICINA = value; }
		}
		public string TOPE_CODIGO
		{
			get { return this._TOPE_CODIGO; }
			set { this._TOPE_CODIGO = value; }
		}
//fin gaa20121122

		public string TOPEN_CODIGO
		{
			get { return this._TOPEN_CODIGO; }
			set { this._TOPEN_CODIGO = value; }
		}

		public string TPROV_DESCRIPCION
		{
			get { return this._TPROV_DESCRIPCION; }
			set { this._TPROV_DESCRIPCION = value; }
		}
		public string TOPE_DESCRIPCION
		{
			get { return this._TOPE_DESCRIPCION; }
			set { this._TOPE_DESCRIPCION = value; }
		}
		public string GRUPO_PLAN
		{
			get { return this._GRUPO_PLAN; }
			set { this._GRUPO_PLAN = value; }
		}
		public string PRDC_CODIGO
		{
			get { return this._PRDC_CODIGO; }
			set { this._PRDC_CODIGO = value; }
		}
		public string PRDV_DESCRIPCION
		{
			get { return this._PRDV_DESCRIPCION; }
			set { this._PRDV_DESCRIPCION = value; }
		}
		public ArrayList SERVICIO 
		{
			get{ return _SERVICIO; } 
			set{ _SERVICIO = value; } 
		}

		public PlanSolicitudDTH PLAN_SOL_DTH
		{
			get{ return _PLAN_SOL_DTH; } 
			set{ _PLAN_SOL_DTH = value; } 
		}

		public PlanSolicitudHFC PLAN_SOL_HFC 
		{
			get{ return _PLAN_SOL_HFC; } 
			set{ _PLAN_SOL_HFC = value; } 
		}

		public Int64 ID_SOLUCION
		{
			get{ return _ID_SOLUCION; } 
			set{ _ID_SOLUCION = value; } 
		}
		public string SOLUCION
		{
			get{ return _SOLUCION; } 
			set{ _SOLUCION = value; } 
		}
		public Int64 IDDET
		{
			get{ return _IDDET; } 
			set{ _IDDET = value; } 
		}
		public Int64 IDPRODUCTO
		{
			get{ return _IDPRODUCTO; } 
			set{ _IDPRODUCTO = value; } 
		}
		public Int64 IDLINEA
		{
			get{ return _IDLINEA; } 
			set{ _IDLINEA = value; } 
		}
		public string MODALIDAD_VENTA
		{
			get{ return _MODALIDAD_VENTA; } 
			set{ _MODALIDAD_VENTA = value; } 
		}

		//consolidado 20012015

		public Int64 TMCODE;


		//consolidado 20012015
		//gaa20161024
		public string FAMILIA_PLAN
		{
			get{ return _FAMILIA_PLAN; }
			set{ _FAMILIA_PLAN = value; } 
		}
		public string FAMILIA_PLAN_DES
		{
			get{ return _FAMILIA_PLAN_DES; }
			set{ _FAMILIA_PLAN_DES = value; } 
		}
		//fin gaa20161024
	}
}
