using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for PuntoVenta.
	/// </summary>
	public class PuntoVenta
	{
		private string _OVENC_CODIGO;
		private string _TPROC_CODIGO;		
		private string _CANAC_CODIGO;
		private string _OVENV_DESCRIPCION;
		private string _TOFIC_CODIGO;
		private string _OVENC_ESTADO;
		private string _TOFIV_DESCRIPCION;
		private string _TPROV_DESCRIPCION;
		private string _OVENC_REGION;
		private string _CANAV_DESCRIPCION;
		private string _ESTADO_RESTRICCION;
		private string _TCESC_CODIGO;

		private string _OVENV_CENTRO;
		private string _OVENV_NRO_CLIE_PADRE;
		private string _OVENV_NRO_CLIE_HIJO;
		private string _OVENV_ALMACEN;

		private string _DEPAC_CODIGO;
		private string _DEPAV_DESCRIPCION;
		private string _OVENC_PDV_RENOV;
		private string _OVENC_PDV_REPOS;

		private string _PROV_EXTERNO;
		//inicio 04/11/2014
		private string _OVENC_ASISTENCIA;
		//fin 04/11/2014 

                //Inicio PROY-25335 - Contratación Electrónica - Release 0
		private string _OVENV_OUTOFFBIO;
		private string _OVENC_FLAG_BIO_POST;
		private string _OVENC_FLAGHUELLERO_POST;
                //Fin PROY-25335 - Contratación Electrónica - Release 0

		public PuntoVenta()	{}

		public PuntoVenta(string vCodigo,string vDescripcion)
		{			
			_OVENC_CODIGO = vCodigo;
			_OVENV_DESCRIPCION = vDescripcion;			
		}

		public PuntoVenta(string vCodigo,string vDescripcion,string vTipo,string vCanal)
		{			
			_OVENC_CODIGO = vCodigo;
			_OVENV_DESCRIPCION = vDescripcion;	
			_TOFIC_CODIGO = vTipo;
			_CANAC_CODIGO = vCanal;
		}

		public string OVENC_PDV_RENOV
		{
			get{return _OVENC_PDV_RENOV; }
			set{_OVENC_PDV_RENOV= value;}
		}
		public string OVENC_PDV_REPOS
		{
			get{return _OVENC_PDV_REPOS; }
			set{_OVENC_PDV_REPOS= value;}
		}
		public string OVENC_CODIGO
		{
			get{return _OVENC_CODIGO; }
			set{_OVENC_CODIGO= value;}
		}
		public string TPROC_CODIGO 
		{
			get{return _TPROC_CODIGO; }
			set{_TPROC_CODIGO = value;}
		}
		public string CANAC_CODIGO
		{
			get{return _CANAC_CODIGO; }
			set{_CANAC_CODIGO = value;}
		}
		public string OVENV_DESCRIPCION
		{
			get{return _OVENV_DESCRIPCION; }
			set{_OVENV_DESCRIPCION= value;}
		}		
		public string TOFIC_CODIGO
		{
			get{return _TOFIC_CODIGO; }
			set{_TOFIC_CODIGO= value;}
		}
		public string OVENC_ESTADO
		{
			get{return _OVENC_ESTADO; }
			set{_OVENC_ESTADO= value;}
		}
		public string TOFIV_DESCRIPCION
		{
			get{return _TOFIV_DESCRIPCION; }
			set{_TOFIV_DESCRIPCION= value;}
		}
		public string TPROV_DESCRIPCION
		{
			get{return _TPROV_DESCRIPCION; }
			set{_TPROV_DESCRIPCION= value;}
		}
		public string CANAV_DESCRIPCION
		{
			get{return _CANAV_DESCRIPCION; }
			set{_CANAV_DESCRIPCION= value;}
		}
		public string TCESC_CODIGO { 
			set { _TCESC_CODIGO= value; } 
			get{ return _TCESC_CODIGO; }
		}
		public string ESTADO_RESTRICCION
		{
			set{_ESTADO_RESTRICCION = value;}
			get{return _ESTADO_RESTRICCION;}
		}
		public string OVENC_REGION
		{
			get{return _OVENC_REGION; }
			set{_OVENC_REGION= value;}
		}

		public string OVENV_CENTRO
		{
			get{return _OVENV_CENTRO; }
			set{_OVENV_CENTRO= value;}
		}
		public string OVENV_NRO_CLIE_PADRE
		{
			get{return _OVENV_NRO_CLIE_PADRE; }
			set{_OVENV_NRO_CLIE_PADRE= value;}
		}
		public string OVENV_NRO_CLIE_HIJO
		{
			get{return _OVENV_NRO_CLIE_HIJO; }
			set{_OVENV_NRO_CLIE_HIJO= value;}
		}
		public string OVENV_ALMACEN
		{
			get{return _OVENV_ALMACEN; }
			set{_OVENV_ALMACEN= value;}
		}		
		public string DEPAC_CODIGO
		{
			get{return _DEPAC_CODIGO; }
			set{_DEPAC_CODIGO= value;}
		}

		public string DEPAV_DESCRIPCION
		{
			get{return _DEPAV_DESCRIPCION; }
			set{_DEPAV_DESCRIPCION= value;}
		}
		public string PROV_EXTERNO
		{
			get{return _PROV_EXTERNO; }
			set{_PROV_EXTERNO= value;}
		}
		//inicio 04/11/2014
		public string OVENC_ASISTENCIA
		{
			get{return _OVENC_ASISTENCIA; }
			set{_OVENC_ASISTENCIA= value;}
		}
		//fin 04/11/2014 
 
                //Inicio PROY-25335 - Contratación Electrónica - Release 0
		public string OVENV_OUTOFFBIO
		{
			get{return _OVENV_OUTOFFBIO; }
			set{_OVENV_OUTOFFBIO= value;}
		}
		public string OVENC_FLAG_BIO_POST
		{
			get{return _OVENC_FLAG_BIO_POST; }
			set{_OVENC_FLAG_BIO_POST= value;}
		}
		public string OVENC_FLAGHUELLERO_POST
		{
			get{return _OVENC_FLAGHUELLERO_POST; }
			set{_OVENC_FLAGHUELLERO_POST= value;}
		}
		//Fin PROY-25335 - Contratación Electrónica - Release 0

	}
}
