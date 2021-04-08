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
		public long COD_ACUERDO 
		public long COD_SEC 
		public int ID_DOCUMENTO 
		public string COD_ESTADO 
		public string TT_CODIGO_TIPO_ACUERDO 
		public string TT_CODIGO_TIPO_VENTA 
		public string TT_CODIGO_OPCION_ACUERDO 
		public string MOTIVO_OPCION_OTRO 
		public string TT_CODIGO_TIPO_CLIENTE 
		public string CODIGO_CLIENTE 
		public string NRO_ACUERDO_PCS 
		public string TT_CODIGO_DESCUENTO_ESPECIAL 
		public string OVENC_CODIGO 
		public string NOMBRE_PDV

		public string CODIGO_TIPO_PDV 

		public string NOMBRE_TIPO_PDV 

		public string EMAIL_PDV 
	
		public string EMAIL_AUTORIZADO 
		public DateTime FECHA_ACTIVACION 
		public string USUARIO_CREACION 
		public DateTime FECHA_CREACION 
		public string OBSERVACIONES 

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