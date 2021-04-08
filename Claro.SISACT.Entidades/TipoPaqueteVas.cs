using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Referencia a la tabla de paquetes (VAS)
	/// </summary>
	public class TipoPaqueteVas
	{
		private int _PROVN_CODIGO;
		private string _DESV_PROVEEDOR;
		private int _VASN_CODIGO;  //uso
		private string _DESV_SERV_VAS;
		private int _PAQN_CODIGO;
		private string _DESV_PAQUETE;//uso
		private string _FRECV_TIEMPO;
		private Double _COSTN_SERVICIO;
		private string _ESTC_PAQUETE;
		private DateTime  _FECD_REGISTRO;
		private string _USUV_CREACION;
		private string _DESV_DET_PAQUETE;//uso
		
		public TipoPaqueteVas()
		{
			
		}
		public TipoPaqueteVas(int VASN_CODIGO ,string DESV_PAQUETE , string DESV_DET_PAQUETE)
		{
			_VASN_CODIGO=VASN_CODIGO;
			_DESV_PAQUETE=DESV_PAQUETE;
			_DESV_DET_PAQUETE=DESV_DET_PAQUETE;			
		}

		public int PROVN_CODIGO
		{
			set{_PROVN_CODIGO= value;}
			get{return _PROVN_CODIGO;}
		}
		
		public string DESV_PROVEEDOR
		{
			set{_DESV_PROVEEDOR= value;}
			get{return _DESV_PROVEEDOR;}
		}
		public int VASN_CODIGO
		{
			set{_VASN_CODIGO= value;}
			get{return _VASN_CODIGO;}
		}
		public string DESV_SERV_VAS
		{
			set{_DESV_SERV_VAS= value;}
			get{return _DESV_SERV_VAS;}
		}
		
		public int PAQN_CODIGO
		{
			set{_PAQN_CODIGO= value;}
			get{return _PAQN_CODIGO;}
		}
		
		public string DESV_PAQUETE
		{
			set{_DESV_PAQUETE= value;}
			get{return _DESV_PAQUETE;}
		}

		
		public string FRECV_TIEMPO
		{
			set{_FRECV_TIEMPO= value;}
			get{return _FRECV_TIEMPO;}
		}
		
		public Double COSTN_SERVICIO
		{
			set{_COSTN_SERVICIO= value;}
			get{return _COSTN_SERVICIO;}
		}

		public string ESTC_PAQUETE
		{
			set{_ESTC_PAQUETE= value;}
			get{return _ESTC_PAQUETE;}
		}
		
		public DateTime FECD_REGISTRO
		{
			set{_FECD_REGISTRO= value;}
			get{return _FECD_REGISTRO;}
		}
		
		public string USUV_CREACION
		{
			set{_USUV_CREACION= value;}
			get{return _USUV_CREACION;}
		}
		
		public string DESV_DET_PAQUETE
		{
			set{_DESV_DET_PAQUETE= value;}
			get{return _DESV_DET_PAQUETE;}
		}



	}
}
