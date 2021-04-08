using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Plan3Play.
	/// </summary>
	public class Plan3Play
	{
		public Plan3Play()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string _PLNV_CODIGO;
		private string _PLNV_DESCRIPCION;
		private string _PLNC_ESTADO;
		private string _TVENC_CODIGO;
		private string _TPROC_CODIGO;
		private DateTime _PLND_FECHA_CREA;
		private string _PLNV_USUARIO_CREA;
		private decimal _PLNN_CARGO_FIJO;
		private string _PLNC_TIPO_PRODUCTO;
		private string _PLNV_CODIGO_BSCS;
		private int _K_RESULTADO;
		// Otros
		private string _ESTADO_PLAN;
		private string _TVENV_DESCRIPCION;
		private string _TPROV_DESCRIPCION;
		private string _PRDV_DESCRIPCION;

		private string _PARAM_GENERALES;
		private string _PLAZOS;
		private string _SERVICIOS;
		private string _ALQUILER;

		public string PLNV_CODIGO
		{
			set{_PLNV_CODIGO = value;}
			get{ return _PLNV_CODIGO;}		
		}

		public string PLNV_DESCRIPCION
		{
			set { _PLNV_DESCRIPCION = value; }
			get { return _PLNV_DESCRIPCION; }
		}

		public string PLNC_ESTADO
		{
			set { _PLNC_ESTADO = value; }
			get { return _PLNC_ESTADO; }
		}

		public string TVENC_CODIGO
		{
			set { _TVENC_CODIGO = value; }
			get { return _TVENC_CODIGO; }
		}

		public string TPROC_CODIGO
		{
			set { _TPROC_CODIGO = value; }
			get { return _TPROC_CODIGO; }
		}

		public DateTime PLND_FECHA_CREA
		{
			set { _PLND_FECHA_CREA = value; }
			get { return _PLND_FECHA_CREA; }
		}

		public string PLNV_USUARIO_CREA
		{
			set { _PLNV_USUARIO_CREA = value; }
			get { return _PLNV_USUARIO_CREA; }
		}

		public decimal PLNN_CARGO_FIJO
		{
			set { _PLNN_CARGO_FIJO = value; }
			get { return _PLNN_CARGO_FIJO; }
		}

		public string PLNC_TIPO_PRODUCTO
		{
			set { _PLNC_TIPO_PRODUCTO = value; }
			get { return _PLNC_TIPO_PRODUCTO; }
		}

		public string PLNV_CODIGO_BSCS
		{
			set { _PLNV_CODIGO_BSCS = value; }
			get { return _PLNV_CODIGO_BSCS; }
		}

		public int K_RESULTADO
		{
			set { _K_RESULTADO = value; }
			get { return _K_RESULTADO; }
		}


		// Otros
		public string ESTADO_PLAN
		{
			set { _ESTADO_PLAN = value; }
			get { return _ESTADO_PLAN; }
		}

		public string TVENV_DESCRIPCION
		{
			set{_TVENV_DESCRIPCION = value;}
			get{ return _TVENV_DESCRIPCION;}		
		}

		public string TPROV_DESCRIPCION
		{
			set{_TPROV_DESCRIPCION = value;}
			get{ return _TPROV_DESCRIPCION;}		
		}

		public string PRDV_DESCRIPCION
		{
			set{_PRDV_DESCRIPCION = value;}
			get{ return _PRDV_DESCRIPCION;}		
		}

		public string PARAM_GENERALES
		{
			set{_PARAM_GENERALES = value;}
			get{ return _PARAM_GENERALES;}		
		}
		public string PLAZOS
		{
			set{_PLAZOS = value;}
			get{ return _PLAZOS;}		
		}
		public string SERVICIOS
		{
			set{_SERVICIOS = value;}
			get{ return _SERVICIOS;}		
		}
		public string ALQUILER
		{
			set{_ALQUILER = value;}
			get{ return _ALQUILER;}		
		}
	}
}

