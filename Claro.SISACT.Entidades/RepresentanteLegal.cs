using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Provincia.
	/// </summary>
	public class RepresentanteLegal
	{
		
		private Int64 _APODN_CODIGO;
		private Int64 _SOLIN_CODIGO;
		private Int64 _P_SCPN_NRO_PEDIDO; //PROY-25335 - Contratación Electrónica - Release 0
		private string _CLIEC_NUM_DOC;
		private string _APODV_NOM_REP_LEG;
		private string _APODV_APA_REP_LEG;
		private string _APODV_AMA_REP_LEG;
		private string _APODC_TIP_DOC_REP;
		private string _APODV_NUM_DOC_REP;
		private string _APODV_CAR_REP;
		private string _APODC_ESTADO;
		private string _TDOCV_DESCRIPCION_REP;
		private string _TPODC_CODIGO;
		private string _SPODC_CODIGO;
		private string _E_MAIL; /*MAC agregado 12/11/2009*/ 

		private string _P_SRLV_ID_TX_P;  //PROY-25335 - Contratación Electrónica - Release 0
		private string _P_SCPV_OBSERVACION;  //PROY-25335 - Contratación Electrónica - Release 0
		private string _P_SCPV_APLICACION;   //PROY-25335 - Contratación Electrónica - Release 0
		private string _P_SCPV_USUARIO_CREA; //PROY-25335 - Contratación Electrónica - Release 0
		private string _P_SRLC_CODNACIONALIDAD;//31636-RENTESEG
		private string _P_SRLV_DESCNACIONALIDAD;//31636-RENTESEG

		public RepresentanteLegal(){}
		public Int64 APODN_CODIGO
		{
			set{ _APODN_CODIGO = value;}
			get{ return _APODN_CODIGO;}
		}
		public Int64 SOLIN_CODIGO
		{
			set{ _SOLIN_CODIGO= value;}
			get{ return _SOLIN_CODIGO;}
		}
		public string CLIEC_NUM_DOC
		{
			set{ _CLIEC_NUM_DOC= value;}
			get{ return _CLIEC_NUM_DOC;}
		}
		public string APODV_NOM_REP_LEG
		{
			set{ _APODV_NOM_REP_LEG= value;}
			get{ return _APODV_NOM_REP_LEG;}
		}
		public string APODV_APA_REP_LEG
		{
			set{ _APODV_APA_REP_LEG= value;}
			get{ return _APODV_APA_REP_LEG;}
		}
		public string APODV_AMA_REP_LEG
		{
			set{ _APODV_AMA_REP_LEG= value;}
			get{ return _APODV_AMA_REP_LEG;}
		}
		public string APODC_TIP_DOC_REP
		{
			set{ _APODC_TIP_DOC_REP= value;}
			get{ return _APODC_TIP_DOC_REP;}
		}
		public string APODV_NUM_DOC_REP
		{
			set{ _APODV_NUM_DOC_REP= value;}
			get{ return _APODV_NUM_DOC_REP;}
		}
		public string APODV_CAR_REP
		{
			set{ _APODV_CAR_REP= value;}
			get{ return _APODV_CAR_REP;}
		}
		public string APODC_ESTADO
		{
			set{ _APODC_ESTADO= value;}
			get{ return _APODC_ESTADO;}
		}
		public string TDOCV_DESCRIPCION_REP{
			set{_TDOCV_DESCRIPCION_REP = value;}
			get{return _TDOCV_DESCRIPCION_REP;}
		}

		public string TPODC_CODIGO
		{
			set{_TPODC_CODIGO = value;}
			get{return _TPODC_CODIGO;}
		}
		public string SPODC_CODIGO
		{
			set{_SPODC_CODIGO = value;}
			get{return _SPODC_CODIGO;}
		}
		
		public string E_MAIL /*agregado por MAC 12-12-2009*/
		{
			set{_E_MAIL = value;}
			get{return _E_MAIL;}
		}
                //Inicio PROY-25335 - Contratación Electrónica - Release 0
		public Int64 P_SCPN_NRO_PEDIDO
		{
			set{_P_SCPN_NRO_PEDIDO = value;}
			get{return _P_SCPN_NRO_PEDIDO;}
		}
		public string P_SRLV_ID_TX_P
		{
			set{_P_SRLV_ID_TX_P = value;}
			get{return _SPODC_CODIGO;}
		}
		public string P_SCPV_OBSERVACION
		{
			set{_P_SCPV_OBSERVACION = value;}
			get{return _P_SCPV_OBSERVACION;}
		}
		public string P_SCPV_APLICACION
		{
			set{_P_SCPV_APLICACION = value;}
			get{return _P_SCPV_APLICACION;}
		}
		public string P_SCPV_USUARIO_CREA
		{
			set{_P_SCPV_USUARIO_CREA= value;}
			get{return _SPODC_CODIGO;}
		}
               //Fin PROY-25335 - Contratación Electrónica - Release 0
		//INI PROY 31636
		public string P_SRLC_CODNACIONALIDAD
		{
			set{_P_SRLC_CODNACIONALIDAD= value;}
			get{return _P_SRLC_CODNACIONALIDAD;}
		}
		public string P_SRLV_DESCNACIONALIDAD
		{
			set{_P_SRLV_DESCNACIONALIDAD=value;}
			get{return _P_SRLV_DESCNACIONALIDAD;}
		}
		//FIN PROY 31636
	}
}
