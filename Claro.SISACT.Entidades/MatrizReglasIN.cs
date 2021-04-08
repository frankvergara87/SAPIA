using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de MatrizReglasIN.
	/// </summary>
	public class MatrizReglasIN
	{
		private string _tipoDespacho = "";
		private string _tipoProducto = "";
		private string _canal = "";
		private string _pdv = "";
		private string _tipoCliente = "";
		private string _tipoDocumento = "";
		private string _departamento = "TODOS";
		private string _provincia = "TODOS";
		private string _distrito = "TODOS";
		private string _casoEspecial = "REGULAR";
		private string _factorEndeudamiento = "";
		private string _oferta = "";
		private string _grupoPlanTarifario = "";
		private string _cargoFijo = "";
		private string _cargoFijoEval = "";
		private string _plazoAcuerdo = "";
		private string _campania = "TODOS";
		private string _control = "";
		private string _factorSubsidio = "";
		private string _porcentajeCuotaInicial = "100";
		private string _cuotas = "0";
		private string _kit = "TODOS";
		private string _riesgo = "";
		private string _score = "";
		private string _edad = "999";
		private string _cantidadRRLL = "0";
		private string _publicar = "";
		private int _nroPlanes = 0;
		private string _nroDocumento = "";
		private string _producto = "";
		private string _plan = "";
		private string _codPlan = "";
		private string _codCampania = "";
		private string _orden = "";
		private string _tipoOperacion = "";
		private string _factorRenovacion="";
		private string _comportamientoPago="";

		public MatrizReglasIN()
		{}

		public string TipoDespacho
		{
			get { return this._tipoDespacho; }
			set { this._tipoDespacho = value; }
		}

		public string TipoProducto
		{
			get { return this._tipoProducto; }
			set { this._tipoProducto = value; }
		}

		public string Canal
		{
			get { return this._canal; }
			set { this._canal = value; }
		}

		public string Pdv
		{
			get { return this._pdv; }
			set { this._pdv = value; }
		}

		public string TipoCliente
		{
			get { return this._tipoCliente; }
			set { this._tipoCliente = value; }
		}

		public string TipoDocumento
		{
			get { return this._tipoDocumento; }
			set { this._tipoDocumento = value; }
		}

		public string Departamento
		{
			get { return this._departamento; }
			set { this._departamento = value; }
		}

		public string Provincia
		{
			get { return this._provincia; }
			set { this._provincia = value; }
		}

		public string Distrito
		{
			get { return this._distrito; }
			set { this._distrito = value; }
		}

		public string CasoEspecial
		{
			get { return this._casoEspecial; }
			set { this._casoEspecial = value; }
		}

		public string FactorEndeudamiento
		{
			get { return this._factorEndeudamiento; }
			set { this._factorEndeudamiento = value; }
		}

		public string Oferta
		{
			get { return this._oferta; }
			set { this._oferta = value; }
		}

		public string GrupoPlanTarifario
		{
			get { return this._grupoPlanTarifario; }
			set { this._grupoPlanTarifario = value; }
		}

		public string CargoFijo
		{
			get { return this._cargoFijo; }
			set { this._cargoFijo = value; }
		}

		public string CargoFijoEval
		{
			get { return this._cargoFijoEval; }
			set { this._cargoFijoEval = value; }
		}

		public string PlazoAcuerdo
		{
			get { return this._plazoAcuerdo; }
			set { this._plazoAcuerdo = value; }
		}

		public string Campania
		{
			get { return this._campania; }
			set { this._campania = value; }
		}

		public string Control
		{
			get { return this._control; }
			set { this._control = value; }
		}

		public string FactorSubsidio
		{
			get { return this._factorSubsidio; }
			set { this._factorSubsidio = value; }
		}

		public string PorcentajeCuotaInicial
		{
			get { return this._porcentajeCuotaInicial; }
			set { this._porcentajeCuotaInicial = value; }
		}

		public string Cuotas
		{
			get { return this._cuotas; }
			set { this._cuotas = value; }
		}

		public string Kit
		{
			get { return this._kit; }
			set { this._kit = value; }
		}

		public string Riesgo
		{
			get { return this._riesgo; }
			set { this._riesgo = value; }
		}

		public string Score
		{
			get { return this._score; }
			set { this._score = value; }
		}

		public string Edad
		{
			get { return this._edad; }
			set { this._edad = value; }
		}

		public string CantidadRRLL
		{
			get { return this._cantidadRRLL; }
			set { this._cantidadRRLL = value; }
		}

		public string Publicar
		{
			get { return this._publicar; }
			set { this._publicar = value; }
		}

		public int NroPlanes
		{
			get { return this._nroPlanes; }
			set { this._nroPlanes = value; }
		}

		public string NroDocumento
		{
			get { return this._nroDocumento; }
			set { this._nroDocumento = value; }
		}	

		public string Producto
		{
			get { return this._producto; }
			set { this._producto = value; }
		}		

		public string Plan
		{
			get { return this._plan; }
			set { this._plan = value; }
		}		

		public string CodPlan
		{
			get { return this._codPlan; }
			set { this._codPlan = value; }
		}		

		public string CodCampania
		{
			get { return this._codCampania; }
			set { this._codCampania = value; }
		}
		
		public string Orden
		{
			get { return this._orden; }
			set { this._orden = value; }
		}	

		public string TipoOperacion
		{
			get { return this._tipoOperacion; }
			set { this._tipoOperacion = value; }
		}

		public string FactorRenovacion
		{
			get { return this._factorRenovacion; }
			set { this._factorRenovacion = value; }
		}

		public string ComportamientoPago
		{
			get { return this._comportamientoPago; }
			set { this._comportamientoPago = value; }
		}
	}
}
