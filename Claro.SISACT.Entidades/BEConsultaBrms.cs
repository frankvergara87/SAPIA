using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de BEConsultaBrms.
	/// </summary>
	public class BEConsultaBrms
	{
		public BEConsultaBrms()
		{

		}
		public string _TipoCliente ;
		public string _Canal;
		public string _EstadoAcuerdo;
		public string _SegmentoCliente;
		public int _PeriodoContrato;
		public int _DiasPermanencia;
		public int _DiasPendientes;
		public string _ComportamientoPago;
		public int _Bloqueo;
		public string _CampaniaActual;
		public string _PlanActual;
		public string _PagoCuotas;
		public string _ModalidadVenta;
		public int _AntiguedadLinea;

		public string TipoCliente
		{
			set{_TipoCliente = value;}
			get{ return _TipoCliente;}
		}
		public string Canal
		{
			set{_Canal = value;}
			get{ return _Canal;}
		}

		public string EstadoAcuerdo
		{
			set{_EstadoAcuerdo = value;}
			get{ return _EstadoAcuerdo;}
		}
		public string SegmentoCliente
		{
			set{_SegmentoCliente = value;}
			get{ return _SegmentoCliente;}
		}
		public int PeriodoContrato
		{
			set{_PeriodoContrato = value;}
			get{ return _PeriodoContrato;}
		}
		public int DiasPermanencia
		{
			set{_DiasPermanencia = value;}
			get{ return _DiasPermanencia;}
		}
		public string ComportamientoPago
		{
			set{_ComportamientoPago = value;}
			get{ return _ComportamientoPago;}
		}
		public int Bloqueo
		{
			set{_Bloqueo = value;}
			get{ return _Bloqueo;}
		}
		public string CampaniaActual
		{
			set{_CampaniaActual = value;}
			get{ return _CampaniaActual;}
		}
		public string PlanActual
		{
			set{_PlanActual = value;}
			get{ return _PlanActual;}
		}
		public int DiasPendientes
		{
			set{_DiasPendientes = value;}
			get{ return _DiasPendientes;}
		}
		public string PagoCuotas
		{
			set{_PagoCuotas = value;}
			get{ return _PagoCuotas;}
		}
		public string ModalidadVenta
		{
			set{_ModalidadVenta = value;}
			get{ return _ModalidadVenta;}
		}
		public int AntiguedadLinea
		{
			set{_AntiguedadLinea = value;}
			get{ return _AntiguedadLinea;}
		}
	}
}
