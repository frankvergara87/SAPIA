using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Telefono.
	/// </summary>
	public class Telefono
	{
		private string _NRO_TELEFONO;
		private string _PREFIJO;
		private string _NRO_SIMCARD;
		private string _CENTRO;
		private string _ALMACEN_ID;
		private string _ALMACEN_DES;
		private string _DEPARTAMENTO;		
		private string _ESTADO;
		private string _TIRA_TELEFONO;

		private string _MATEC_CODIGO;
		private string _MATERIAL_DES;
		
		private string _USUARIO_ESTADO;
		private string _MENSAJE_ERROR;
		
		private DateTime _FECHA_ESTADO;
		private Int64 _SEC_ID;

		public Telefono()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public string NRO_TELEFONO
		{
			set{_NRO_TELEFONO = value;}
			get{ return _NRO_TELEFONO;}
		}
		public string PREFIJO
		{
			set{_PREFIJO= value;}
			get{ return _PREFIJO;}
		}
		public string NRO_SIMCARD
		{
			set{_NRO_SIMCARD= value;}
			get{ return _NRO_SIMCARD;}
		}
		public string CENTRO
		{
			set{ _CENTRO= value;}
			get{ return _CENTRO;}
		}
		public string ALMACEN_ID
		{
			set{ _ALMACEN_ID= value;}
			get{ return _ALMACEN_ID;}
		}
		public string ALMACEN_DES
		{
			set{ _ALMACEN_DES= value;}
			get{ return _ALMACEN_DES;}
		}		
		public string MATEC_CODIGO
		{
			set{ _MATEC_CODIGO= value;}
			get{ return _MATEC_CODIGO;}
		}
		public string MATERIAL_DES
		{
			set{ _MATERIAL_DES= value;}
			get{ return _MATERIAL_DES;}
		}

		public string DEPARTAMENTO
		{
			set{ _DEPARTAMENTO= value;}
			get{ return _DEPARTAMENTO;}
		}
		public string ESTADO
		{
			set{ _ESTADO = value;}
			get{ return _ESTADO;}
		}
		public string TIRA_TELEFONO
		{
			set{ _TIRA_TELEFONO= value;}
			get{ return _TIRA_TELEFONO;}
		}

		public string USUARIO_ESTADO
		{
			set{ _USUARIO_ESTADO= value;}
			get{ return _USUARIO_ESTADO;}
		}
		public string MENSAJE_ERROR
		{
			set{ _MENSAJE_ERROR= value;}
			get{ return _MENSAJE_ERROR;}
		}
		public DateTime FECHA_ESTADO
		{
			set{ _FECHA_ESTADO= value;}
			get{ return _FECHA_ESTADO;}
		}	
		
		public Int64 SEC_ID
		{
			set{ _SEC_ID= value;}
			get{ return _SEC_ID;}
		}
		
	}
}
