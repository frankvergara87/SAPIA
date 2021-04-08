using System;

namespace Claro.SisAct.Entidades
{

	public class PlanDetalleConsumer
	{
		public PlanDetalleConsumer()
		{
			
		}


		private int _SOPLN_CODIGO;
		public int SOPLN_CODIGO
		{
			set{_SOPLN_CODIGO = value;}
			get{ return _SOPLN_CODIGO;}
		}


		private int _SOLIN_CODIGO;
		public int SOLIN_CODIGO
		{
			set{_SOLIN_CODIGO = value;}
			get{ return _SOLIN_CODIGO;}
		}


		private Double _SOPLC_MONTO_TOTAL;
		public Double SOPLC_MONTO_TOTAL
		{
			set{_SOPLC_MONTO_TOTAL = value;}
			get{ return _SOPLC_MONTO_TOTAL;}
		}


		private Double _SOPLN_MONTO_UNIT;
		public Double SOPLN_MONTO_UNIT
		{
			set{_SOPLN_MONTO_UNIT = value;}
			get{ return _SOPLN_MONTO_UNIT;}
		}


		private string _PLANC_CODIGO;
		public string PLANC_CODIGO
		{
			set{_PLANC_CODIGO = value;}
			get{ return _PLANC_CODIGO;}
		}

		private string _PLANV_DESCRIPCION;
		public string PLANV_DESCRIPCION
		{
			set{_PLANV_DESCRIPCION = value;}
			get{ return _PLANV_DESCRIPCION;}
		}


		private string _TPROC_CODIGO;
		public string TPROC_CODIGO
		{
			set{_TPROC_CODIGO = value;}
			get{ return _TPROC_CODIGO;}
		}


		private int _SOPLN_CANTIDAD;
		public int SOPLN_CANTIDAD
		{
			set{_SOPLN_CANTIDAD = value;}
			get{ return _SOPLN_CANTIDAD;}
		}
		
	}

}
