using System;
using System.Collections;
using Claro.SisAct.Common;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PlanSolHFC.
	/// </summary>
	public class PlanSolicitudHFC
	{
		public PlanSolicitudHFC()
		{
		}
		private Int64 _IdSolucion;
		private string _Solucion;
		private Int64 _IdPaquete;
		private string _Paquete;
		private string _IdPlazo;
		private string _Plazo;
		private string _Usuario;
		private ArrayList _Servicio;
		private ArrayList _Promocion;

		public Int64 IdSolucion
		{
			get { return this._IdSolucion; }
			set { this._IdSolucion = value; }
		}

		public string Solucion
		{
			get { return this._Solucion; }
			set { this._Solucion = value; }
		}

		public Int64 IdPaquete
		{
			get { return this._IdPaquete; }
			set { this._IdPaquete = value; }
		}

		public string Paquete
		{
			get { return this._Paquete; }
			set { this._Paquete = value; }
		}

		public string IdPlazo
		{
			get { return this._IdPlazo; }
			set { this._IdPlazo = value; }
		}

		public string Plazo
		{
			get { return this._Plazo; }
			set { this._Plazo = value; }
		}

		public string Usuario
		{
			get { return this._Usuario; }
			set { this._Usuario = value; }
		}

		public ArrayList Servicio
		{
			get { return this._Servicio; }
			set { this._Servicio = value; }
		}

		public ArrayList Promocion
		{
			get { return this._Promocion; }
			set { this._Promocion = value; }
		}
	}
}
