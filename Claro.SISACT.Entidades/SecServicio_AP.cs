using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de SecServicio_AP.
	/// </summary>
	public class SecServicio_AP : Servicio_AP
	{
		private int _PLSVN_CODIGO;
		private int _SOLIN_CODIGO;
		private int _SOPLN_CODIGO;
		private double _SERVN_PRECIO_SERV;
		private Int64 _IDDET;
		private Int64 _IDPRODUCTO;
		private Int64 _IDLINEA;
//---------------Roaming -----------------------
//		private string _SERVC_ESTADO;
		private string _SERVC_PLAZO;
		private DateTime _SERVD_FECHA_ACTIVACION;
		private DateTime _SERVD_FECHA_DESACTIVACION;

//		public string SERVC_ESTADO {get{ return _SERVC_ESTADO;} set{_SERVC_ESTADO = value;}}
		public string SERVC_PLAZO {get{ return _SERVC_PLAZO;} set{_SERVC_PLAZO = value;}}
		public DateTime SERVD_FECHA_ACTIVACION {get{ return _SERVD_FECHA_ACTIVACION;} set{_SERVD_FECHA_ACTIVACION = value;}}
		public DateTime SERVD_FECHA_DESACTIVACION {get{ return _SERVD_FECHA_DESACTIVACION;} set{_SERVD_FECHA_DESACTIVACION = value;}}

//---------------------------------------------------------

		public int PLSVN_CODIGO {get{ return _PLSVN_CODIGO;} set{_PLSVN_CODIGO = value;}}
		public int SOLIN_CODIGO {get{ return _SOLIN_CODIGO;} set{_SOLIN_CODIGO = value;}}
		public int SOPLN_CODIGO {get{ return _SOPLN_CODIGO;} set{_SOPLN_CODIGO = value;}}
		public double CARGO_FIJO_EN_SEC {get{ return _SERVN_PRECIO_SERV;} set{_SERVN_PRECIO_SERV = value;}}

		public Int64 IDDET
		{
			get{ return _IDDET; } 
			set{ _IDDET = value; } 
		}
		public Int64 IDPRODUCTO
		{
			get{ return _IDPRODUCTO; } 
			set{ _IDPRODUCTO = value; } 
		}
		public Int64 IDLINEA
		{
			get{ return _IDLINEA; } 
			set{ _IDLINEA = value; } 
		}

		private Int64 _SOPLN_ORDEN;
		public Int64 SOPLN_ORDEN
		{
			set{_SOPLN_ORDEN = value;}
			get{ return _SOPLN_ORDEN;}		
		}

		public SecServicio_AP()
		{
			new Servicio_AP();
			PLSVN_CODIGO = 0;
			SOLIN_CODIGO = 0;
			SOPLN_CODIGO = 0;
			CARGO_FIJO_EN_SEC = 0;
		}
	}
}
