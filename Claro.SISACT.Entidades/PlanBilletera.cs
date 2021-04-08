using System;
using System.Collections;
using System.Data;
using Claro.SisAct.Common;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de PlanDetalle.
	/// </summary>
	public class PlanBilletera
	{
		public PlanBilletera()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private string _plan;
		private string _cuenta;
		private int _codigoBilletera;
		private int _nroPlanesMovil;
		private int _nroPlanesInternet;
		private int _nroPlanesTelefonia;
		private int _nroPlanesClaroTV;
		private int _nroPlanesBAM;
		private double _montoFacturado;
		private double _montoNoFacturado;
		private int _orden;


		//GEJ 
		public int _idBilletera ;
		public int idBilletera
		{
			get { return this._idBilletera; }
			set { this._idBilletera = value; }
		}
		public int _nroPlanes;
		public int nroPlanes
		{
			get { return this._nroPlanes; }
			set { this._nroPlanes = value; }
		}
		public double _CF ;
		public double CF
		{
			get { return this._CF; }
			set { this._CF = value; }
		}
      
		public TIPO_PLAN _tipoPlan;
		public TIPO_PLAN tipoPlan
		{
			get { return this._tipoPlan; }
			set { this._tipoPlan = value; }
		}
		public TIPO_FACTURADOR _tipoFacturador;
		public TIPO_FACTURADOR tipoFacturador
		{
			get { return this._tipoFacturador; }
			set { this._tipoFacturador = value; }
		}
		public ArrayList _oBilletera ;
		public ArrayList oBilletera
		{
			get { return this._oBilletera; }
			set { this._oBilletera = value; }
		}

		public bool ContainsAny(ArrayList objLista)
		{
			if (this.oBilletera != null)
			{

				foreach (Billetera obj in objLista)
				{
					foreach (Billetera obj1 in this.oBilletera)
					{
						if (obj.idBilletera == obj1.idBilletera)
							return true;
					}
				}
			}
			return false;
		}
		public enum TIPO_PLAN
		{
			MOVIL = 1,
			DATOS = 2
		}
		public enum TIPO_FACTURADOR
		{
			BSCS = 0,
			SGA = 1
		}
		public enum TIPO_SISTEMA
		{
			BSCS = 0,
			SGA = 1,
			SISACT = 2
		}
		//FIN GEJ

		public string Plan
		{
			get { return this._plan; }
			set { this._plan = value; }
		}

		public string Cuenta
		{
			get { return this._cuenta; }
			set { this._cuenta = value; }
		}

		public int CodigoBilletera
		{
			get { return this._codigoBilletera; }
			set { this._codigoBilletera = value; }
		}

		public int NroPlanesMovil
		{
			get { return this._nroPlanesMovil; }
			set { this._nroPlanesMovil = value; }
		}

		public int NroPlanesInternet
		{
			get { return this._nroPlanesInternet; }
			set { this._nroPlanesInternet = value; }
		}

		public int NroPlanesTelefonia
		{
			get { return this._nroPlanesTelefonia; }
			set { this._nroPlanesTelefonia = value; }
		}

		public int NroPlanesClaroTV
		{
			get { return this._nroPlanesClaroTV; }
			set { this._nroPlanesClaroTV = value; }
		}

		public int NroPlanesBAM
		{
			get { return this._nroPlanesBAM; }
			set { this._nroPlanesBAM = value; }
		}

		public double MontoFacturado
		{
			get { return this._montoFacturado; }
			set { this._montoFacturado = value; }
		}

		public double MontoNoFacturado
		{
			get { return this._montoNoFacturado; }
			set { this._montoNoFacturado = value; }
		}

		public int Orden
		{
			get { return this._orden; }
			set { this._orden = value; }
		}
	}
}
