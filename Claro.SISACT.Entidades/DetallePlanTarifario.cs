using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de DetallePlanTarifario.
	/// </summary>
	public class DetallePlanTarifario
	{
		public DetallePlanTarifario()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private string _IdDocumento;
		public string IdDocumento
		{
			set{_IdDocumento= value;}
			get{ return _IdDocumento;}
		}

		//public string DescripcionPlan{get;set;}
		private string _DescripcionDocumento;
		public string DescripcionDocumento
		{
			set{_DescripcionDocumento= value;}
			get{ return _DescripcionDocumento;}
		}

		private string _IdPlazo;
		public string IdPlazo
		{
			set{_IdPlazo= value;}
			get{ return _IdPlazo;}
		}

		//public string DescripcionPlan{get;set;}
		private string _DescripcionPlazo;
		public string DescripcionPlazo
		{
			set{_DescripcionPlazo= value;}
			get{ return _DescripcionPlazo;}
		}

		private string _IdCuota;
		public string IdCuota
		{
			set{_IdCuota= value;}
			get{ return _IdCuota;}
		}

		//public string DescripcionPlan{get;set;}
		private string _DescripcionCuota;
		public string DescripcionCuota
		{
			set{_DescripcionCuota= value;}
			get{ return _DescripcionCuota;}
		}

		private decimal _ValorCuota;
		public decimal ValorCuota
		{
			set{_ValorCuota= value;}
			get{ return _ValorCuota;}
		}

		private string _IdEstado;
		public string IdEstado
		{
			set{_IdEstado= value;}
			get{ return _IdEstado;}
		}
		private string _DescripcionEstado;
		public string DescripcionEstado
		{
			set{_DescripcionEstado= value;}
			get{ return _DescripcionEstado;}
		}
	}
}
