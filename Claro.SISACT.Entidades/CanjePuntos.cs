using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for CanjePuntos.
	/// </summary>
	/// <remarks>
	/// Autor: E77568.
	/// PS - Automatización de canje y nota de crédito.
	/// </remarks>
	public class CanjePuntos
	{

		// Tipo documento SISACT
		private string _TIPO_DOC;
		// Número de documento
		private string _NUM_DOC;
		// Documento SAP de la Nota de Crédito
		private string _NRO_DOC_SAP_NC;
		// Cantidad de puntos usados
		private double _PUNTOS_USADOS;
		// Factor de Conversión de Puntos a Soles
		private double _FACTOR_CONVERSION;
		// Equivalente de descuento en soles
		private double _SOLES_DESCUENTO;
		// Código de punto de venta
		private string _COD_PDV;
		// Fecha de Registro
		private DateTime _FECHA_REG;
		// Usuario registro (Reserva)
		private string _USUARIO_REG;
		// Fecha de Canje
		private DateTime _FECHA_CANJE;
		// usuario de realiza el canje en el pago
		private string _USUARIO_CANJE;
		// 1: Se realizó el canje de puntos
		private string _FLAG_CANJE;
		// Descripción de la campaña Claro Club
		private string _CAMPANA;
		// Nro de línea que aplica al descuento de puntos
		private string _NRO_LINEA;
		// Número de documento de la boleta
		private string _DOCUMENTO_SAP;
		// Código de la campaña
		private double _IDCAMPANA;
		// Código del tipo de documento de ClaroClub.
		private double _ID_CCLUB;
		// Descripciòn del tipo de descuento recibido.
		private string _DESCRIPCION;
		// Descripciòn de la bolsa.
		private string _DESCRIP_BOLSA;
		// Código de la bolsa.
		private string _COD_BOLSA;
		// Puntos asignados.
		private string _PUNTOS_ASIGNADOS;

		// Inicio SD_812077 
		// Nombre completo del asesor
		private string _NOM_ASESOR;
		/// <summary>
		/// Nombre completo del asesor.
		/// </summary>
		public string NOM_ASESOR
		{
			set { _NOM_ASESOR = value;}
			get { return _NOM_ASESOR;}
		}
		// Fin SD_812077 

		// Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos
		private string _SEGMENTO;
		private DateTime _CAMPANA_VIGENCIA_INI;
		private DateTime _CAMPANA_VIGENCIA_FIN;
		private string _DOC_SAP_DSCTO_EQUIPO;
		private decimal _DSCTO_EQUIPO;
		public string SEGMENTO
		{
			set { _SEGMENTO = value;}
			get { return _SEGMENTO;}
		}
		public DateTime CAMPANA_VIGENCIA_INI
		{
			set { _CAMPANA_VIGENCIA_INI = value;}
			get { return _CAMPANA_VIGENCIA_INI;}
		}
		public DateTime CAMPANA_VIGENCIA_FIN
		{
			set { _CAMPANA_VIGENCIA_FIN = value;}
			get { return _CAMPANA_VIGENCIA_FIN;}
		}
		public string DOC_SAP_DSCTO_EQUIPO
		{
			set { _DOC_SAP_DSCTO_EQUIPO = value;}
			get { return _DOC_SAP_DSCTO_EQUIPO;}
		}
		public decimal DSCTO_EQUIPO
		{
			set { _DSCTO_EQUIPO = value;}
			get { return _DSCTO_EQUIPO;}
		}
		// Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos

		/// <summary>
		/// Puntos asignados.
		/// </summary>
		public string PUNTOS_ASIGNADOS
		{
			set { _PUNTOS_ASIGNADOS = value;}
			get { return _PUNTOS_ASIGNADOS;}
		}
		/// <summary>
		/// Código de la bolsa.
		/// </summary>
		public string COD_BOLSA
		{
			set { _COD_BOLSA = value;}
			get { return _COD_BOLSA;}
		}
		/// <summary>
		/// Descripciòn de la bolsa.
		/// </summary>
		public string DESCRIP_BOLSA
		{
			set { _DESCRIP_BOLSA = value;}
			get { return _DESCRIP_BOLSA;}
		}
		/// <summary>
		/// Descripciòn del tipo de descuento recibido.
		/// </summary>
		public string DESCRIPCION
		{
			set { _DESCRIPCION = value;}
			get { return _DESCRIPCION;}
		}
		/// <summary>
		/// Código del tipo de documento de ClaroClub.
		/// </summary>
		public double ID_CCLUB
		{
			set { _ID_CCLUB = value;}
			get { return _ID_CCLUB;}
		}
		/// <summary>
		/// Código de la campaña
		/// </summary>
		public double IDCAMPANA
		{
			set { _IDCAMPANA = value;}
			get { return _IDCAMPANA;}
		}
		/// <summary>
		/// Número de documento de la boleta
		/// </summary>
		public string DOCUMENTO_SAP
		{
			set { _DOCUMENTO_SAP = value;}
			get { return _DOCUMENTO_SAP;}
		}
		/// <summary>
		/// Nro de línea que aplica al descuento de puntos
		/// </summary>
		public string NRO_LINEA
		{
			set { _NRO_LINEA = value;}
			get { return _NRO_LINEA;}
		}
		/// <summary>
		/// Tipo documento SISACT
		/// </summary>
		public string TIPO_DOC
		{
			set { _TIPO_DOC = value;}
			get { return _TIPO_DOC;}
		}
		/// <summary>
		/// Número de documento
		/// </summary>
		public string NUM_DOC
		{
			set { _NUM_DOC = value;}
			get { return _NUM_DOC;}
		}
		/// <summary>
		/// Documento SAP de la Nota de Crédito
		/// </summary>
		public string NRO_DOC_SAP_NC
		{
			set { _NRO_DOC_SAP_NC = value;}
			get { return _NRO_DOC_SAP_NC;}
		}
		/// <summary>
		/// Cantidad de puntos usados
		/// </summary>
		public double PUNTOS_USADOS
		{
			set { _PUNTOS_USADOS = value;}
			get { return _PUNTOS_USADOS;}
		}
		/// <summary>
		/// Factor de Conversión de Puntos a Soles
		/// </summary>
		public double FACTOR_CONVERSION
		{
			set { _FACTOR_CONVERSION = value;}
			get { return _FACTOR_CONVERSION;}
		}
		/// <summary>
		/// Equivalente de descuento en soles
		/// </summary>
		public double SOLES_DESCUENTO
		{
			set { _SOLES_DESCUENTO = value;}
			get { return _SOLES_DESCUENTO;}
		}
		/// <summary>
		/// Código de punto de venta
		/// </summary>
		public string COD_PDV
		{
			set { _COD_PDV= value;}
			get { return _COD_PDV;}
		}
		/// <summary>
		/// Usuario registro (Reserva)
		/// </summary>
		public DateTime FECHA_REG
		{
			set { _FECHA_REG= value;}
			get { return _FECHA_REG;}
		}
		/// <summary>
		/// Usuario registro (Reserva)
		/// </summary>
		public string USUARIO_REG
		{
			set { _USUARIO_REG = value;}
			get { return _USUARIO_REG;}
		}
		/// <summary>
		/// Fecha de Canje
		/// </summary>
		public DateTime FECHA_CANJE
		{
			set { _FECHA_CANJE = value;}
			get { return _FECHA_CANJE;}
		}
		/// <summary>
		/// usuario de realiza el canje en el pago
		/// </summary>
		public string USUARIO_CANJE
		{
			set { _USUARIO_CANJE = value;}
			get { return _USUARIO_CANJE;}
		}
		/// <summary>
		/// 1: Se realizó el canje de puntos
		/// </summary>
		public string FLAG_CANJE
		{
			set { _FLAG_CANJE = value;}
			get { return _FLAG_CANJE;}
		}
		/// <summary>
		/// Descripción de la campaña Claro Club.
		/// </summary>
		public string CAMPANA
		{
			set { _CAMPANA = value;}
			get { return _CAMPANA;}
		}

		public CanjePuntos()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
