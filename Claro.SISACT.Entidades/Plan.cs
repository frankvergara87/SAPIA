using System;
using System.Collections;
namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Plan.
	/// </summary>
	public class Plan: IComparable
	{
		private int _PLANN_CODIGO;
		private string _TPROC_CODIGO;
		private string _TVENC_CODIGO;
		private string _PLANV_DESCRIPCION;
		private int _ID_BSCS;
		private string _PLANC_ESTADO;
		private string _PLANV_UNIDAD_TOPE;

		private string _TPROV_DESCRIPCION;
		private string _TVENV_DESCRIPCION;
		private double _CARGO_PLAN;
		//Inicio Mayllon
		private Double _PLANN_CAR_FIJ;
		private Decimal _PLANN_LIM_CRED_CON;
		private string  _PLANC_SCO_TXT_CON;
		private int     _PLANN_SCO_NUM_CON;
		private string  _PLANC_TIPO;
		private string  _PLANC_TIPO_REGLA;
		//Fin Mayllon
		private string _PLANC_CODIGO;
		private string _CODIGO_BSCS;

		private string _TCLIC_CODIGO;
		private string _TCLIV_DESCRIPCION;
		private int    _ID_SAP;
		private string _CODIGO_SAP;
		private string _CODIGO_MATRIZ_REGLA;
		private string _CODIGO_AUTONOMIA;
		private string _CODIGO_EXCLUYENTE;
		private int _CANTIDAD_MINIMA_MATRIZ;
		private int _CANTIDAD_MAXIMA_MATRIZ;
		private int _PLANN_MAX_NUM;
		private decimal _TCARC_CODIGO;
		private decimal _TCARN_NUM_CAR_FIJ;
		private decimal _MONTN_MONTO_FLAT;
		private int _FAM_PLANN_CODIGO;
		private string _PLANC_CORREOCLIENTEOBLIGA;

		//adicionado JAR - codigo de plazoacuerdo
		private string _PACUC_CODIGO;
		private string _PLANC_TIPOVD;
		//Fin JAR
		private ArrayList _servicios;

		//Renovacion
		private string _PLANC_EQUI_SAP;
		private int _PLNN_TIPO_PLAN;
		private string _GPLNV_DESCRIPCION;
		private string _TIPO_PRODUCTOS;
		//Fin de Renovacion
 // -- Bolsa Compartida
		private string _ServicioCodigo;
		private string _ServicioDescripcion;
		//-- Bolsa compartida

		public Plan(){}


		public int _CANTIDAD;
		public int CANTIDAD
		{
			set{_CANTIDAD= value;}
			get{ return _CANTIDAD;}
		}

	public Plan(int vPLANN_CODIGO,string vPLANV_DESCRIPCION)
		{
			_PLANN_CODIGO=vPLANN_CODIGO;
			_PLANV_DESCRIPCION=vPLANV_DESCRIPCION;
		}

		public int PLANN_CODIGO{
			set{_PLANN_CODIGO = value;}
			get{ return _PLANN_CODIGO;}
		}
		
		public string PLANC_CODIGO
		{
			set{_PLANC_CODIGO= value;}
			get{ return _PLANC_CODIGO;}
		}
		public string TPROC_CODIGO
		{
			set{_TPROC_CODIGO= value;}
			get{ return _TPROC_CODIGO;}
		}
		public string TVENC_CODIGO
		{
			set{_TVENC_CODIGO= value;}
			get{ return _TVENC_CODIGO;}
		}
		public string PLANV_DESCRIPCION
		{
			set{_PLANV_DESCRIPCION= value;}
			get{ return _PLANV_DESCRIPCION;}
		}
		public string PLANV_UNIDAD_TOPE
		{
			set{_PLANV_UNIDAD_TOPE= value;}
			get{ return _PLANV_UNIDAD_TOPE;}
		}
		public int ID_BSCS
		{
			set{_ID_BSCS= value;}
			get{ return _ID_BSCS;}
		}
		public string PLANC_ESTADO
		{
			set{_PLANC_ESTADO= value;}
			get{ return _PLANC_ESTADO;}
		}
		public string TPROV_DESCRIPCION
		{
			set{_TPROV_DESCRIPCION= value;}
			get{ return _TPROV_DESCRIPCION;}
		}             
			
		public string TVENV_DESCRIPCION
		{
			set{_TVENV_DESCRIPCION= value;}
			get{ return _TVENV_DESCRIPCION;}
		}   		
		//Inicio Mayllon
		public Double PLANN_CAR_FIJ
		{
			set{ _PLANN_CAR_FIJ= value;}
			get{ return _PLANN_CAR_FIJ;}
		}
		public Decimal PLANN_LIM_CRED_CON
		{
			set{ _PLANN_LIM_CRED_CON= value;}
			get{ return _PLANN_LIM_CRED_CON;}
		}
		
		public string PLANC_SCO_TXT_CON
		{
			set{ _PLANC_SCO_TXT_CON= value;}
			get{ return _PLANC_SCO_TXT_CON;}
		}
		
		public int PLANN_SCO_NUM_CON
		{
			set{ _PLANN_SCO_NUM_CON= value;}
			get{ return _PLANN_SCO_NUM_CON;}
		}
		
		public string PLANC_TIPO
		{
			set{ _PLANC_TIPO= value;}
			get{ return _PLANC_TIPO;}
		}

		public string PLANC_TIPO_REGLA
		{
			set{ _PLANC_TIPO_REGLA = value;}
			get{ return _PLANC_TIPO_REGLA;}
		}
		//Fin Mayllon
		public double  CARGO_PLAN
		{
			set{_CARGO_PLAN= value;}
			get{ return _CARGO_PLAN;}
		}   
   
		public string CODIGO_BSCS
		{
			set{ _CODIGO_BSCS = value;}
			get{ return _CODIGO_BSCS;}
		}
//Para Gama de Planes - INICIO
		public int CompareTo(object obj)
		{
			Plan Compare = (Plan)obj;
			int result = this._PLANN_CAR_FIJ.CompareTo(Compare._PLANN_CAR_FIJ);
			if (result == 0)
				result = this._PLANV_DESCRIPCION.CompareTo(Compare._PLANV_DESCRIPCION);
			return result;
		}
//Para Gama de Planes - FIN

                public string TCLIC_CODIGO
		{
			set{_TCLIC_CODIGO=value;}
			get{return _TCLIC_CODIGO;}
		}

		public string TCLIV_DESCRIPCION
		{
			set{_TCLIV_DESCRIPCION=value;}
			get{return _TCLIV_DESCRIPCION;}
		}

		public int ID_SAP
		{
			set{_ID_SAP=value;}
			get{return _ID_SAP;}
		}
		public string CODIGO_SAP
		{
			set{_CODIGO_SAP=value;}
			get{return _CODIGO_SAP;}
		}

		public string CODIGO_MATRIZ_REGLA
		{
			set{_CODIGO_MATRIZ_REGLA=value;}
			get{return _CODIGO_MATRIZ_REGLA;}
		}
		public string CODIGO_AUTONOMIA
		{
			set{_CODIGO_AUTONOMIA=value;}
			get{return _CODIGO_AUTONOMIA;}
		}
		public string CODIGO_EXCLUYENTE
		{
			set{_CODIGO_EXCLUYENTE=value;}
			get{return _CODIGO_EXCLUYENTE;}
		}
		public int CANTIDAD_MINIMA_MATRIZ
		{
			set{_CANTIDAD_MINIMA_MATRIZ=value;}
			get{return _CANTIDAD_MINIMA_MATRIZ;}
		}
		public int CANTIDAD_MAXIMA_MATRIZ
		{
			set{_CANTIDAD_MAXIMA_MATRIZ=value;}
			get{return _CANTIDAD_MAXIMA_MATRIZ;}
		}
		public int PLANN_MAX_NUM
		{
			set{_PLANN_MAX_NUM=value;}
			get{return _PLANN_MAX_NUM;}
		}

		public decimal TCARC_CODIGO
		{
			set{_TCARC_CODIGO=value;}
			get{return _TCARC_CODIGO;}
		}
		public decimal TCARN_NUM_CAR_FIJ
		{
			set{_TCARN_NUM_CAR_FIJ=value;}
			get{return _TCARN_NUM_CAR_FIJ;}
		}
		public decimal MONTN_MONTO_FLAT
		{
			set{_MONTN_MONTO_FLAT=value;}
			get{return _MONTN_MONTO_FLAT;}
		}
		public int FAM_PLANN_CODIGO
		{
			set{_FAM_PLANN_CODIGO=value;}
			get{return _FAM_PLANN_CODIGO;}
		}

		public ArrayList SERVICIOS
		{
			set{
				_servicios=value;
			}
			get{
				if(_servicios == null)
				{
					_servicios = new ArrayList();
				}
				return _servicios;
			}
		}
		public string PACUC_CODIGO
		{
			set{_PACUC_CODIGO= value;}
			get{ return _PACUC_CODIGO;}
		}
		public string PLANC_CORREOCLIENTEOBLIGA
		{
			set{_PLANC_CORREOCLIENTEOBLIGA=value;}
			get{return _PLANC_CORREOCLIENTEOBLIGA;}
		}

		public string PLANC_TIPOVD
		{
			set{_PLANC_TIPOVD= value;}
			get{ return _PLANC_TIPOVD;}
		}

		private string _PLANC_TIPOMP;
		public string PLANC_TIPOMP
		{
			set{_PLANC_TIPOMP= value;}
			get{ return _PLANC_TIPOMP;}
		}

		private string _TIPOMP_DESCRIPCION;
		public string TIPOMP_DESCRIPCION
		{
			set{_TIPOMP_DESCRIPCION= value;}
			get{ return _TIPOMP_DESCRIPCION;}
		}

		private string _PLANV_DES_BASE;
		public string PLANV_DES_BASE
		{
			set{_PLANV_DES_BASE= value;}
			get{ return _PLANV_DES_BASE;}
		}

		private string _ESTADO_DESCRIPCION;
		public string ESTADO_DESCRIPCION
		{
			set{_ESTADO_DESCRIPCION= value;}
			get{ return _ESTADO_DESCRIPCION;}
		}

		public string PLANC_EQUI_SAP
		{
			set{_PLANC_EQUI_SAP=value;}
			get{return _PLANC_EQUI_SAP;}
		}

		public int PLNN_TIPO_PLAN
		{
			set{_PLNN_TIPO_PLAN=value;}
			get{return _PLNN_TIPO_PLAN;}
		}

		public string GPLNV_DESCRIPCION
		{
			set{_GPLNV_DESCRIPCION = value;}
			get{return _GPLNV_DESCRIPCION;}
		}

		public string TIPO_PRODUCTOS
		{
			set{_TIPO_PRODUCTOS = value;}
			get{return _TIPO_PRODUCTOS;}
		}
		//-- Bolsa compartida
		public string ServicioCodigo
		{
			set{_ServicioCodigo = value;}
			get{return _ServicioCodigo;}
		}

		public string ServicioDescripcion
		{
			set{_ServicioDescripcion = value;}
			get{return _ServicioDescripcion;}
		}
		//-- Bolsa Compartida
		
	}
}
