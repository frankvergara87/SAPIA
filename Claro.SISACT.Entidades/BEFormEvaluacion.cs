using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de BEFormEvaluacion.
	/// </summary>
	public class BEFormEvaluacion
	{
		private string _metodo;
		private int _idFila;
		private Int64 _nroSEC;

		private string _idOficina;
		private string _idFlujo;
		private string _idOferta;
		private string _idTipoOperacion;
		private string _idCasoEspecial;
		private string _idCombo;
		private string _idTipoVenta;
		private string _flgPorta;

		private string _tipoDocumento;
		private string _nroDocumento;

		private string _idProducto;
		private string _idCampana;
		private string _idCampanaSap;
		private string _idPlazo;
		private string _idPaquete;
		private int nroSecuencia;
		private string _idPlan;
		private string _listaPlan;
		private string _idPlanSap;
		private string _idMaterial;
		private string _idListaPrecio;
		private int _nroCuotas;

		private string _fechaSap;
		private string _canalSap;
		private string _centroSap;
		private string _orgVentaSap;
		private string _tipoDocumentoSap;
		private string _idTipoOperacionSap;

		private string _evaluarFijo;
		private string _modalidadVenta;
		private string _idTipoOficina;
		private string _idCuota;
//gaa20161027
		private string _IdFamiliaPlan;
//fin gaa20161027
		public string Metodo
		{
			get { return this._metodo; }
			set { this._metodo = value; }
		}

		public int IdFila
		{
			get { return this._idFila; }
			set { this._idFila = value; }
		}

		public Int64 NroSEC
		{
			get { return this._nroSEC; }
			set { this._nroSEC = value; }
		}

		public string IdOficina
		{
			get { return this._idOficina; }
			set { this._idOficina = value; }
		}

		public string IdFlujo
		{
			get { return this._idFlujo; }
			set { this._idFlujo = value; }
		}

		public string IdOferta
		{
			get { return this._idOferta; }
			set { this._idOferta = value; }
		}

		public string IdTipoOperacion
		{
			get { return this._idTipoOperacion; }
			set { this._idTipoOperacion = value; }
		}

		public string IdCasoEspecial
		{
			get { return this._idCasoEspecial; }
			set { this._idCasoEspecial = value; }
		}

		public string IdCombo
		{
			get { return this._idCombo; }
			set { this._idCombo = value; }
		}

		public string IdTipoVenta
		{
			get { return this._idTipoVenta; }
			set { this._idTipoVenta = value; }
		}

		public string FlgPorta
		{
			get { return this._flgPorta; }
			set { this._flgPorta = value; }
		}

		public string TipoDocumento
		{
			get { return this._tipoDocumento; }
			set { this._tipoDocumento = value; }
		}

		public string NroDocumento
		{
			get { return this._nroDocumento; }
			set { this._nroDocumento = value; }
		}

		public string IdProducto
		{
			get { return this._idProducto; }
			set { this._idProducto = value; }
		}

		public string IdCampana
		{
			get { return this._idCampana; }
			set { this._idCampana = value; }
		}

		public string IdCampanaSap
		{
			get { return this._idCampanaSap; }
			set { this._idCampanaSap = value; }
		}

		public string IdPlazo
		{
			get { return this._idPlazo; }
			set { this._idPlazo = value; }
		}

		public string IdPaquete
		{
			get { return this._idPaquete; }
			set { this._idPaquete = value; }
		}

		public int NroSecuencia
		{
			get { return this.nroSecuencia; }
			set { this.nroSecuencia = value; }
		}

		public string IdPlan
		{
			get { return this._idPlan; }
			set { this._idPlan = value; }
		}

		public string ListaPlan
		{
			get { return this._listaPlan; }
			set { this._listaPlan = value; }
		}

		public string IdPlanSap
		{
			get { return this._idPlanSap; }
			set { this._idPlanSap = value; }
		}

		public string IdMaterial
		{
			get { return this._idMaterial; }
			set { this._idMaterial = value; }
		}

		public string IdListaPrecio
		{
			get { return this._idListaPrecio; }
			set { this._idListaPrecio = value; }
		}

		public int NroCuotas
		{
			get { return this._nroCuotas; }
			set { this._nroCuotas = value; }
		}

		public string FechaSap
		{
			get { return this._fechaSap; }
			set { this._fechaSap = value; }
		}

		public string CanalSap
		{
			get { return this._canalSap; }
			set { this._canalSap = value; }
		}

		public string CentroSap
		{
			get { return this._centroSap; }
			set { this._centroSap = value; }
		}

		public string OrgVentaSap
		{
			get { return this._orgVentaSap; }
			set { this._orgVentaSap = value; }
		}

		public string TipoDocumentoSap
		{
			get { return this._tipoDocumentoSap; }
			set { this._tipoDocumentoSap = value; }
		}

		public string IdTipoOperacionSap
		{
			get { return this._idTipoOperacionSap; }
			set { this._idTipoOperacionSap = value; }
		}

		public string EvaluarFijo
		{
			get { return this._evaluarFijo; }
			set { this._evaluarFijo = value; }
		}

		public string ModalidadVenta
		{
			get { return this._modalidadVenta; }
			set { this._modalidadVenta = value; }
		}

		public string IdTipoOficina
		{
			get { return this._idTipoOficina; }
			set { this._idTipoOficina = value; }
		}

		public string IdCuota
		{
			get { return this._idCuota; }
			set { this._idCuota = value; }
		}
//gaa20161027
		public string IdFamiliaPlan
		{
			get { return this._IdFamiliaPlan; }
			set { this._IdFamiliaPlan = value; }
		}
//fin gaa20161027
	}
}
