using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Distribuidor.
	/// </summary>
	public class Distribuidor
	{
		private string _DISTC_CODIGO;
		private string _DISTV_DESCRIPCION;
        private string _DISTV_ESTADO;
		private ArrayList _LISTA_OFICINAS;
		private ArrayList _LISTA;
		public Distribuidor()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public string DISTC_CODIGO 
		{
			get{ return _DISTC_CODIGO;}
			set{ 	 _DISTC_CODIGO = value; }
		}
		public string DISTV_DESCRIPCION 
		{
			get{ return _DISTV_DESCRIPCION;}
			set{ 	 _DISTV_DESCRIPCION = value; }
		}
		public string DISTV_ESTADO 
		{
			get{ return _DISTV_ESTADO;}
			set{ 	 _DISTV_ESTADO = value; }
		}
		public ArrayList LISTA_OFICINAS 
		{
			get{ return _LISTA_OFICINAS;}
			set{ 	 _LISTA_OFICINAS = value; }
		}
		public ArrayList LISTA 
		{
			get{ return _LISTA;}
			set{ 	 _LISTA = value; }
		}
		
	}
}
