using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for PlanTarifario.
	/// </summary>
	public class PlanTarifario
	{
		public PlanTarifario()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private string _PLANV_DESCRIPCION;
		public string PLANV_DESCRIPCION
		{
			set{_PLANV_DESCRIPCION= value;}
			get{ return _PLANV_DESCRIPCION;}
		}
		//public string CodigoPlan{get;set;}
		private string _CodigoPlan;
		public string CodigoPlan
		{
			set{_CodigoPlan= value;}
			get{ return _CodigoPlan;}
		}
		//public int IdOferta{get;set;}
		private string _IdOferta;
		public string IdOferta
		{
			set{_IdOferta= value;}
			get{ return _IdOferta;}
		}
		//public string Oferta{get;set;}
		private string _Oferta;
		public string Oferta
		{
			set{_Oferta= value;}
			get{ return _Oferta;}
		}

		//public string DescripcionPlan{get;set;}
		private string _DescripcionPlan;
		public string DescripcionPlan
		{
			set{_DescripcionPlan= value;}
			get{ return _DescripcionPlan;}
		}
		//public string CodigoPlanSap{get;set;}
		private string _CodigoPlanSap;
		public string CodigoPlanSap
		{
			set{_CodigoPlanSap= value;}
			get{ return _CodigoPlanSap;}
		}
		//public string CodigoPlanBscs{get;set;}
		private string _CodigoPlanBscs;
		public string CodigoPlanBscs
		{
			set{_CodigoPlanBscs= value;}
			get{ return _CodigoPlanBscs;}
		}
		//public string DescripcionPlanBase{get;set;}
		private string _DescripcionPlanBase;
		public string DescripcionPlanBase
		{
			set{_DescripcionPlanBase= value;}
			get{ return _DescripcionPlanBase;}
		}
		//public int IdEstado{get;set;}
		private string _IdEstado;
		public string IdEstado
		{
			set{_IdEstado= value;}
			get{ return _IdEstado;}
		}
		//public string DescripcionEstado{get;set;}
		private string _DescripcionEstado;
		public string DescripcionEstado
		{
			set{_DescripcionEstado= value;}
			get{ return _DescripcionEstado;}
		}
		//public int IdTipoDespacho{get;set;}
		private string _IdTipoDespacho;
		public string IdTipoDespacho
		{
			set{_IdTipoDespacho= value;}
			get{ return _IdTipoDespacho;}
		}
		//public string DescripcionTipoDespacho{get;set;}
		private string _DescripcionTipoDespacho;
		public string DescripcionTipoDespacho
		{
			set{_DescripcionTipoDespacho= value;}
			get{ return _DescripcionTipoDespacho;}
		}
		//public int IdTipoFlujo{get;set;}
		private string _IdTipoFlujo;
		public string IdTipoFlujo
		{
			set{_IdTipoFlujo= value;}
			get{ return _IdTipoFlujo;}
		}
		//public string DescripcionTipoFlujo{get;set;}
		private string _DescripcionTipoFlujo;
		public string DescripcionTipoFlujo
		{
			set{_DescripcionTipoFlujo= value;}
			get{ return _DescripcionTipoFlujo;}
		}
		//public int IdExclusivoCasoEspecial{get;set;}
		private string _IdExclusivoCasoEspecial;
		public string IdExclusivoCasoEspecial
		{
			set{_IdExclusivoCasoEspecial= value;}
			get{ return _IdExclusivoCasoEspecial;}
		}
		//public string DescripcionEsclusivoCasoEspecial{get;set;}
		private string _DescripcionEsclusivoCasoEspecial;
		public string DescripcionEsclusivoCasoEspecial
		{
			set{_DescripcionEsclusivoCasoEspecial= value;}
			get{ return _DescripcionEsclusivoCasoEspecial;}
		}
		//public int IdDocumento{get;set;}
		private string _IdDocumento;
		public string IdDocumento
		{
			set{_IdDocumento= value;}
			get{ return _IdDocumento;}
		}
		//public string DescripcionDocumento{get;set;}
		private string _DescripcionDocumento;
		public string DescripcionDocumento
		{
			set{_DescripcionDocumento= value;}
			get{ return _DescripcionDocumento;}
		}
		//public int IdSinTope{get;set;}
		private string _IdSinTope;
		public string IdSinTope
		{
			set{_IdSinTope= value;}
			get{ return _IdSinTope;}
		}
		//public string DescripcionSinTope{get;set;}
		private string _DescripcionSinTope;
		public string DescripcionSinTope
		{
			set{_DescripcionSinTope= value;}
			get{ return _DescripcionSinTope;}
		}
		//public int IdTopeSinCf{get;set;}
		private string _IdTopeSinCf;
		public string IdTopeSinCf
		{
			set{_IdTopeSinCf= value;}
			get{ return _IdTopeSinCf;}
		}
		//public string DescripcionTopeSinCf{get;set;}
		private string _DescripcionTopeSinCf;
		public string DescripcionTopeSinCf
		{
			set{_DescripcionTopeSinCf= value;}
			get{ return _DescripcionTopeSinCf;}
		}
		//public int IdTopeConCf{get;set;}
		private string _IdTopeConCf;
		public string IdTopeConCf
		{
			set{_IdTopeConCf= value;}
			get{ return _IdTopeConCf;}
		}
		//public string DescripcionTopeConCf{get;set;}
		private string _DescripcionTopeConCf;
		public string DescripcionTopeConCf
		{
			set{_DescripcionTopeConCf= value;}
			get{ return _DescripcionTopeConCf;}
		}
		//public int IdTopeAutomatico{get;set;}
		private string _IdTopeAutomatico;
		public string IdTopeAutomatico
		{
			set{_IdTopeAutomatico= value;}
			get{ return _IdTopeAutomatico;}
		}
		//public string DescripcionTopeAutomatico{get;set;}
		private string _DescripcionTopeAutomatico;
		public string DescripcionTopeAutomatico
		{
			set{_DescripcionTopeAutomatico= value;}
			get{ return _DescripcionTopeAutomatico;}
		}
		//public int IdTipoPlan{get;set;}
		private string _IdTipoPlan;
		public string IdTipoPlan
		{
			set{_IdTipoPlan= value;}
			get{ return _IdTipoPlan;}
		}
		//public string DescripcionTipoPlan{get;set;}
		private string _DescripcionTipoPlan;
		public string DescripcionTipoPlan
		{
			set{_DescripcionTipoPlan= value;}
			get{ return _DescripcionTipoPlan;}
		}
		//public int IdGrupoPlan{get;set;}
		private string _IdGrupoPlan;
		public string IdGrupoPlan
		{
			set{_IdGrupoPlan= value;}
			get{ return _IdGrupoPlan;}
		}
		//public string DescripcionGrupoPlan{get;set;}
		private string _DescripcionGrupoPlan;
		public string DescripcionGrupoPlan
		{
			set{_DescripcionGrupoPlan= value;}
			get{ return _DescripcionGrupoPlan;}
		}
		//public decimal CargoFijo{get;set;}
		private decimal _CargoFijo;
		public decimal CargoFijo
		{
			set{_CargoFijo= value;}
			get{ return _CargoFijo;}
		}
		//public decimal LimiteCredito{get;set;}
		private decimal _LimiteCredito;
		public decimal LimiteCredito
		{
			set{_LimiteCredito= value;}
			get{ return _LimiteCredito;}
		}
		//public int IdPlazoAcuero{get;set;}
		private string _IdPlazoAcuero;
		public string IdPlazoAcuero
		{
			set{_IdPlazoAcuero= value;}
			get{ return _IdPlazoAcuero;}
		}
		//public string DescripcionPlazoAcuerdo{get;set;}
		private string _DescripcionPlazoAcuerdo;
		public string DescripcionPlazoAcuerdo
		{
			set{_DescripcionPlazoAcuerdo= value;}
			get{ return _DescripcionPlazoAcuerdo;}
		}
		//public decimal PorcentajeCuotaInicial{get;set;}
		private decimal _PorcentajeCuotaInicial;
		public decimal PorcentajeCuotaInicial
		{
			set{_PorcentajeCuotaInicial= value;}
			get{ return _PorcentajeCuotaInicial;}
		}
		//public bool chkSinCuotas{get;set;}
		private bool _chkSinCuotas;
		public bool chkSinCuotas
		{
			set{_chkSinCuotas= value;}
			get{ return _chkSinCuotas;}
		}
		//public decimal valorSinCuotas{get;set;}
		private decimal _valorSinCuotas;
		public decimal valorSinCuotas
		{
			set{_valorSinCuotas= value;}
			get{ return _valorSinCuotas;}
		}
		//public bool chk6Cuotas{get;set;}
		private bool _chk6Cuotas;
		public bool chk6Cuotas
		{
			set{_chk6Cuotas= value;}
			get{ return _chk6Cuotas;}
		}
		//public decimal valor6Cuotas{get;set;}
		private decimal _valor6Cuotas;
		public decimal valor6Cuotas
		{
			set{_valor6Cuotas= value;}
			get{ return _valor6Cuotas;}
		}
		//public bool chk12Cuotas{get;set;}
		private bool _chk12Cuotas;
		public bool chk12Cuotas
		{
			set{_chk12Cuotas= value;}
			get{ return _chk12Cuotas;}
		}
		//public decimal valor12Cuotas{get;set;}
		private decimal _valor12Cuotas;
		public decimal valor12Cuotas
		{
			set{_valor12Cuotas= value;}
			get{ return _valor12Cuotas;}
		}
		//public bool chk18Cuotas{get;set;}
		private bool _chk18Cuotas;
		public bool chk18Cuotas
		{
			set{_chk18Cuotas= value;}
			get{ return _chk18Cuotas;}
		}
		//public decimal valor18Cuotas{get;set;}
		private decimal _valor18Cuotas;
		public decimal valor18Cuotas
		{
			set{_valor18Cuotas= value;}
			get{ return _valor18Cuotas;}
		}

		//public ArrayList ListaRestriccionPdv{get;set;}
		private ArrayList _ListaRestriccionPdv;
		public ArrayList ListaRestriccionPdv
		{
			set{_ListaRestriccionPdv= value;}
			get{ return _ListaRestriccionPdv;}
		}
		//public ArrayList ListaRestriccionCanal{get;set;}
		private ArrayList _ListaRestriccionCanal;
		public ArrayList ListaRestriccionCanal
		{
			set{_ListaRestriccionCanal = value;}
			get{ return _ListaRestriccionCanal;}
		}

		private string _IdTipoProducto;
		public string IdTipoProducto
		{
			set{_IdTipoProducto= value;}
			get{ return _IdTipoProducto;}
		}
		//public string DescripcionEstado{get;set;}
		private string _DescripcionTipoProducto;
		public string DescripcionTipoProducto
		{
			set{_DescripcionTipoProducto= value;}
			get{ return _DescripcionTipoProducto;}
		}

		//RenovacionPostPagoDAC
		private string _FlagRenovacion;
		public string FlagRenovacion
		{
			set{_FlagRenovacion= value;}
			get{ return _FlagRenovacion;}
		}
	}
}
