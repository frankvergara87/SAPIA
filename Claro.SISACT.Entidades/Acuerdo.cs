using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Acuerdo.
	/// </summary>
	public class Acuerdo
	{
		//--
		protected long _COD_ACUERDO;
		protected long _COD_SEC;
		protected int _ID_DOCUMENTO;
		protected string _COD_ESTADO;
		protected string _TT_CODIGO_TIPO_ACUERDO;
		protected string _TT_CODIGO_TIPO_VENTA;
		protected string _TT_CODIGO_OPCION_ACUERDO;
		protected string _MOTIVO_OPCION_OTRO;
		protected string _TT_CODIGO_TIPO_CLIENTE;
		protected string _CODIGO_CLIENTE;
		protected string _NRO_ACUERDO_PCS;
		protected string _TT_CODIGO_DESCUENTO_ESPECIAL;
		//---
		protected string _OVENC_CODIGO; //Codigo de PDV
		protected string _NOMBRE_PDV;   //campo agregado en entidad
		protected string _CODIGO_TIPO_PDV;
		protected string _NOMBRE_TIPO_PDV; //campo agregado en entidad
		protected string _EMAIL_PDV;
		//--
		protected string _EMAIL_AUTORIZADO;
		protected DateTime _FECHA_ACTIVACION;
		protected string _USUARIO_CREACION;
		protected DateTime _FECHA_CREACION;
		protected string _OBSERVACIONES;
		private Usuario _CONSULTOR;
		private ArrayList _DETALLE_SERVICIOS;
		private ArrayList _DETALLE_EQUIPOS;
		private ArrayList _DETALLE_BOLSAS_MINUTO;
		private string _NOMBRE_GLOSA;
		private string _TIPO_CREACION;
		 
		private ArrayList _REPRESENTANTES_LEGALES;


		private Cliente _CLIENTE;
		

		//--propiedades-------------------------------------------------------
		public long COD_ACUERDO 		{			get {  return _COD_ACUERDO;  }			set {  _COD_ACUERDO = value; }		} 
		public long COD_SEC 		{			get {  return _COD_SEC;  }			set {  _COD_SEC = value; }		} 
		public int ID_DOCUMENTO 		{			get {  return _ID_DOCUMENTO;  }			set {  _ID_DOCUMENTO = value; }		} 
		public string COD_ESTADO 		{			get {  return _COD_ESTADO;  }			set {  _COD_ESTADO = value; }		} 
		public string TT_CODIGO_TIPO_ACUERDO 		{			get {  return _TT_CODIGO_TIPO_ACUERDO;  }			set {  _TT_CODIGO_TIPO_ACUERDO = value; }		} 
		public string TT_CODIGO_TIPO_VENTA 		{			get {  return _TT_CODIGO_TIPO_VENTA;  }			set {  _TT_CODIGO_TIPO_VENTA = value; }		} 
		public string TT_CODIGO_OPCION_ACUERDO 		{			get {  return _TT_CODIGO_OPCION_ACUERDO;  }			set {  _TT_CODIGO_OPCION_ACUERDO = value; }		} 
		public string MOTIVO_OPCION_OTRO 		{			get {  return _MOTIVO_OPCION_OTRO;  }			set {  _MOTIVO_OPCION_OTRO = value; }		} 
		public string TT_CODIGO_TIPO_CLIENTE 		{			get {  return _TT_CODIGO_TIPO_CLIENTE;  }			set {  _TT_CODIGO_TIPO_CLIENTE = value; }		} 
		public string CODIGO_CLIENTE 		{			get {  return _CODIGO_CLIENTE;  }			set {  _CODIGO_CLIENTE = value; }		} 
		public string NRO_ACUERDO_PCS 		{			get {  return _NRO_ACUERDO_PCS;  }			set {  _NRO_ACUERDO_PCS = value; }		} 
		public string TT_CODIGO_DESCUENTO_ESPECIAL 		{			get {  return _TT_CODIGO_DESCUENTO_ESPECIAL;  }			set {  _TT_CODIGO_DESCUENTO_ESPECIAL = value; }		} 
		public string OVENC_CODIGO 		{			get {  return _OVENC_CODIGO;  }			set {  _OVENC_CODIGO = value; }		}
		public string NOMBRE_PDV		{			get {  return _NOMBRE_PDV;  }			set {  _NOMBRE_PDV = value; }		}

		public string CODIGO_TIPO_PDV 		{			get {  return _CODIGO_TIPO_PDV;  }			set {  _CODIGO_TIPO_PDV = value; }		}

		public string NOMBRE_TIPO_PDV 		{			get {  return _NOMBRE_TIPO_PDV;  }			set {  _NOMBRE_TIPO_PDV = value; }		}

		public string EMAIL_PDV 		{			get {  return _EMAIL_PDV;  }			set {  _EMAIL_PDV = value; }		}
	
		public string EMAIL_AUTORIZADO 		{			get {  return _EMAIL_AUTORIZADO;  }			set {  _EMAIL_AUTORIZADO = value; }		} 
		public DateTime FECHA_ACTIVACION 		{			get {  return _FECHA_ACTIVACION;  }			set {  _FECHA_ACTIVACION = value; }		} 
		public string USUARIO_CREACION 		{			get {  return _USUARIO_CREACION;  }			set {  _USUARIO_CREACION = value; }		} 
		public DateTime FECHA_CREACION 		{			get {  return _FECHA_CREACION;  }			set {  _FECHA_CREACION = value; }		} 
		public string OBSERVACIONES 		{			get {  return _OBSERVACIONES;  }			set {  _OBSERVACIONES = value; }		} 

		public Usuario CONSULTOR
		{ 
			get 
			{ 
				if(_CONSULTOR==null)
				{
					_CONSULTOR = new Usuario();
				}
				return _CONSULTOR; 
			}
			set	{_CONSULTOR = value;  }
		}
		

		public ArrayList DETALLE_SERVICIOS
		{ 
			get 
			{ 
				if (_DETALLE_SERVICIOS == null)
					_DETALLE_SERVICIOS = new ArrayList(); 
				return _DETALLE_SERVICIOS; 
			}
			set	{	_DETALLE_SERVICIOS = value;  }
		}

		public ArrayList DETALLE_EQUIPOS
		{ 
			get 
			{ 
				if (_DETALLE_EQUIPOS == null)
					_DETALLE_EQUIPOS = new ArrayList(); 
				return _DETALLE_EQUIPOS; 
			}
			set	{	_DETALLE_EQUIPOS = value;  }
		}

		public ArrayList DETALLE_BOLSAS_MINUTO
		{ 
			get 
			{ 
				if (_DETALLE_BOLSAS_MINUTO == null)
					_DETALLE_BOLSAS_MINUTO = new ArrayList(); 
				return _DETALLE_BOLSAS_MINUTO; 
			}
			set	{	_DETALLE_BOLSAS_MINUTO = value;  }
		}


		//------------------
		public string NOMBRE_GLOSA
		{ 
			get { return _NOMBRE_GLOSA;}
			set{_NOMBRE_GLOSA = value;}
		}

		public string TIPO_CREACION
		{ 
			get { return _TIPO_CREACION;}
			set{_TIPO_CREACION = value;}
		}
		
		public ArrayList REPRESENTANTES_LEGALES
		{ 
			get { return _REPRESENTANTES_LEGALES;}
			set { _REPRESENTANTES_LEGALES = value;}
		}

		public Cliente CLIENTE
		{ 
			get { return _CLIENTE;}
			set { _CLIENTE = value;}
		}

		
		public Acuerdo()
		{

		}


	}
}
