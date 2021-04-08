using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de DataCreditoIN.
	/// </summary>
	public class DataCreditoIN
	{
		private string _istrSecuencia = "";
		private string _istrTipoDocumento = "";
		private string _istrNumeroDocumento = "";
		private string _istrAPELLIDOPATERNO = "";
		private string _istrAPELLIDOMATERNO = "";
		private string _istrNOMBRES = "";
		private int _istrDatoEntrada = 0;
		private string _istrDatoComplemento = "";
		private string _istrTIPOPRODUCTO = "";
		private string _istrTIPOCLIENTE = "";
		private string _istrEDAD = "";
		private string _istrIngresoOLineaCredito = "";
		private string _istrTIPOTARJETA = "";
		private string _istrRUC = "";
		private string _istrANTIGUEDADLABORAL = "";
		private string _istrNumOperaPVU = "";
		private string _istrRegion = "";
		private string _istrArea = "";
		private string _istrCanal = "";
		private string _istrPuntoVenta = "";
		private string _istrIDCanal = "";
		private string _istrIDTerminal = "";
		private string _istrUsuarioACC = "";
		private string _ostrNumOperaEFT = "";
		private string _istrNUMCUENTAS = "";
		//E76009 Inicio
		private string _strEstadoCivil = "";
		//E76009 Fin

		public DataCreditoIN()
		{}

		public enum EXPERTO
		{
			DATACREDITO = 1,
			EQUIFAX = 2
		}

		public string istrSecuencia
		{
			set{ _istrSecuencia = value; }
			get{ return _istrSecuencia; }
		}
		public string istrTipoDocumento
		{
			set{ _istrTipoDocumento = value; }
			get{ return _istrTipoDocumento; }
		}
		public string istrNumeroDocumento
		{
			set{ _istrNumeroDocumento = value; }
			get{ return _istrNumeroDocumento; }
		}
		public string istrAPELLIDOPATERNO
		{
			set{ _istrAPELLIDOPATERNO = value; }
			get{ return _istrAPELLIDOPATERNO; }
		}
		public string istrAPELLIDOMATERNO
		{
			set{ _istrAPELLIDOMATERNO = value; }
			get{ return _istrAPELLIDOMATERNO; }
		}
		public string istrNOMBRES
		{
			set{ _istrNOMBRES = value; }
			get{ return _istrNOMBRES; }
		}
		public int istrDatoEntrada
		{
			set{ _istrDatoEntrada = value; }
			get{ return _istrDatoEntrada; }
		}
		public string istrDatoComplemento
		{
			set{ _istrDatoComplemento = value; }
			get{ return _istrDatoComplemento; }
		}
		public string istrTIPOPRODUCTO
		{
			set{ _istrTIPOPRODUCTO = value; }
			get{ return _istrTIPOPRODUCTO; }
		}
		public string istrTIPOCLIENTE
		{
			set{ _istrTIPOCLIENTE = value; }
			get{ return _istrTIPOCLIENTE; }
		}
		public string istrEDAD
		{
			set{ _istrEDAD = value; }
			get{ return _istrEDAD; }
		}
		public string istrIngresoOLineaCredito
		{
			set{ _istrIngresoOLineaCredito = value; }
			get{ return _istrIngresoOLineaCredito; }
		}
		public string istrTIPOTARJETA
		{
			set{ _istrTIPOTARJETA = value; }
			get{ return _istrTIPOTARJETA; }
		}
		public string istrRUC
		{
			set{ _istrRUC = value; }
			get{ return _istrRUC; }
		}
		public string istrANTIGUEDADLABORAL
		{
			set{ _istrANTIGUEDADLABORAL = value; }
			get{ return _istrANTIGUEDADLABORAL; }
		}
		public string istrNumOperaPVU
		{
			set{ _istrNumOperaPVU = value; }
			get{ return _istrNumOperaPVU; }
		}
		public string istrRegion
		{
			set{ _istrRegion = value; }
			get{ return _istrRegion; }
		}
		public string istrArea
		{
			set{ _istrArea = value; }
			get{ return _istrArea; }
		}
		public string istrCanal
		{
			set{ _istrCanal = value; }
			get{ return _istrCanal; }
		}
		public string istrPuntoVenta
		{
			set{ _istrPuntoVenta = value; }
			get{ return _istrPuntoVenta; }
		}
		public string istrIDCanal
		{
			set{ _istrIDCanal = value; }
			get{ return _istrIDCanal; }
		}
		public string istrIDTerminal
		{
			set{ _istrIDTerminal = value; }
			get{ return _istrIDTerminal; }
		}
		public string istrUsuarioACC
		{
			set{ _istrUsuarioACC = value; }
			get{ return _istrUsuarioACC; }
		}
		public string ostrNumOperaEFT
		{
			set{ _ostrNumOperaEFT = value; }
			get{ return _ostrNumOperaEFT; }
		}
		public string istrNUMCUENTAS
		{
			set{ _istrNUMCUENTAS = value; }
			get{ return _istrNUMCUENTAS; }
		}
		//E760009 Inicio 
		public string strEstadoCivil
		{
			set{ _strEstadoCivil = value; }
			get{ return _strEstadoCivil; }
		}
		//E76009 Fin
	}
}
