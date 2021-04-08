using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Interaccion.
	/// </summary>
	public class Interaccion
	{
		private string _OBJID_CONTACTO;
		private string _OBJID_SITE;
		private string _CUENTA;
		private string _ID_INTERACCION;
		private string _FECHA_CREACION;
		private string _START_DATE;
		private string _TELEFONO;
		private string _TIPO;
		private string _CLASE;
		private string _SUBCLASE;
		private string _TIPIFICACION;
		private string _TIPO_CODIGO;
		private string _CLASE_CODIGO;
		private string _SUBCLASE_CODIGO;
		private string _INSERTADO_POR;
		private string _TIPO_INTER;
		private string _METODO;
		private string _RESULTADO;
		private string _HECHO_EN_UNO;
		private string _AGENTE;
		private string _NOMBRE_AGENTE;
		private string _APELLIDO_AGENTE;
		private string _ID_CASO;
		private string _NOTAS;
		private string _FLAG_CASO;
		private string _USUARIO_PROCESO;
		public string _ES_TFI;
		public string _ESLINEA_INACTIVA;

		public Interaccion(){}

		public string OBJID_CONTACTO
		{
			set{_OBJID_CONTACTO = value;}
			get{return _OBJID_CONTACTO;}
		}
		public string OBJID_SITE
		{
			set{_OBJID_SITE = value;}
			get{return _OBJID_SITE ;}
		}
		public string CUENTA
		{
			set{_CUENTA = value;}
			get{return _CUENTA ;}
		}
		public string ID_INTERACCION
		{
			set{_ID_INTERACCION = value;}
			get{return _ID_INTERACCION ;}
		}
		public string FECHA_CREACION
		{
			set{_FECHA_CREACION = value;}
			get{return _FECHA_CREACION ;}
		}
		public string NOTAS
		{
			set{_NOTAS = value;}
			get{return _NOTAS ;}
		}
		public string START_DATE
		{
			set{_START_DATE = value;}
			get{return _START_DATE ;}
		}
		public string TELEFONO
		{
			set{_TELEFONO = value;}
			get{return _TELEFONO ;}
		}
		public string TIPO
		{
			set{_TIPO = value;}
			get{return _TIPO ;}
		}
		public string CLASE
		{
			set{_CLASE = value;}
			get{return _CLASE ;}
		}
		public string SUBCLASE
		{
			set{_SUBCLASE = value;}
			get{return _SUBCLASE ;}
		}
		public string TIPIFICACION
		{
			set{_TIPIFICACION = value;}
			get{return _TIPIFICACION ;}
		}
		public string TIPO_CODIGO
		{
			set{_TIPO_CODIGO = value;}
			get{return _TIPO_CODIGO ;}
		}
		public string CLASE_CODIGO
		{
			set{_CLASE_CODIGO = value;}
			get{return _CLASE_CODIGO ;}
		}
		public string SUBCLASE_CODIGO
		{
			set{_SUBCLASE_CODIGO = value;}
			get{return _SUBCLASE_CODIGO ;}
		}
		public string INSERTADO_POR
		{
			set{_INSERTADO_POR = value;}
			get{return _INSERTADO_POR ;}
		}
		public string TIPO_INTER
		{
			set{_TIPO_INTER = value;}
			get{return _TIPO_INTER ;}
		}
		public string METODO
		{
			set{_METODO = value;}
			get{return _METODO ;}
		}
		public string RESULTADO
		{
			set{_RESULTADO = value;}
			get{return _RESULTADO ;}
		}
		public string HECHO_EN_UNO
		{
			set{_HECHO_EN_UNO = value;}
			get{return _HECHO_EN_UNO ;}
		}
		public string AGENTE
		{
			set{_AGENTE = value;}
			get{return _AGENTE ;}
		}
		public string NOMBRE_AGENTE
		{
			set{_NOMBRE_AGENTE = value;}
			get{return _NOMBRE_AGENTE ;}
		}
		public string APELLIDO_AGENTE
		{
			set{_APELLIDO_AGENTE = value;}
			get{return _APELLIDO_AGENTE ;}
		}
		public string ID_CASO
		{
			set{_ID_CASO = value;}
			get{return _ID_CASO ;}
		}
		public string FLAG_CASO
		{
			set{_FLAG_CASO = value;}
			get{return _FLAG_CASO;}
		}
		public string USUARIO_PROCESO
		{			
			set{_USUARIO_PROCESO = value;}
			get{return _USUARIO_PROCESO;}
		}
		public string ES_TFI
		{
			set{_ES_TFI = value;}
			get{ return _ES_TFI;}
		}
		public string ESLINEA_INACTIVA
		{
			set{_ESLINEA_INACTIVA = value;}
			get{ return _ESLINEA_INACTIVA;}
		}
	}
}
