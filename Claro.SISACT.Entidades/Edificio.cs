using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Edificio.
	/// </summary>
	public class Edificio
	{
		private string _EDIFV_CODIGO;
		private string _DEPAC_CODIGO;
		private string _PROVC_CODIGO;
		private string _DISTC_CODIGO;
		private string _EDIFV_DIRECCION;
		private string _EDIFV_NODO;
		private string _EDIFV_DESCRIPCION;
		private DateTime _EDIFD_FECHA_ACTIV;
		private string _EDIFC_ESTADO;

		public Edificio(){}

		public string EDIFV_CODIGO
		{
			set{  _EDIFV_CODIGO= value;}
			get{ return _EDIFV_CODIGO;}
		}
		public string DEPAC_CODIGO
		{
			set{  _DEPAC_CODIGO= value;}
			get{ return _DEPAC_CODIGO;}
		}
		public string PROVC_CODIGO
		{
			set{  _PROVC_CODIGO= value;}
			get{ return _PROVC_CODIGO;}
		}
		public string DISTC_CODIGO
		{
			set{  _DISTC_CODIGO= value;}
			get{ return _DISTC_CODIGO;}
		}
		public string EDIFV_DIRECCION
		{
			set{  _EDIFV_DIRECCION= value;}
			get{ return _EDIFV_DIRECCION;}
		}
		public string EDIFV_NODO
		{
			set{  _EDIFV_NODO= value;}
			get{ return _EDIFV_NODO;}
		}
		public string EDIFV_DESCRIPCION
		{
			set{  _EDIFV_DESCRIPCION= value;}
			get{ return _EDIFV_DESCRIPCION;}
		}
		public DateTime EDIFD_FECHA_ACTIV
		{
			set{  _EDIFD_FECHA_ACTIV= value;}
			get{ return _EDIFD_FECHA_ACTIV;}
		}
		public string EDIFC_ESTADO
		{
			set{  _EDIFC_ESTADO= value;}
			get{ return _EDIFC_ESTADO;}
		}
	}
}
