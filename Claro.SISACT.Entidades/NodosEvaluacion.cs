using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Nodos_Evaluacion.
	/// </summary>
	public class NodosEvaluacion
	{
		
		private string _SRNOC_TIPO_RAZON_NODO;
		private string _SRNOC_COD_RAZON_NODO;
		private string _SRNOV_DESCRIPCION;
		private string _TIPO_RAZON;
		

		
		public NodosEvaluacion()
		{}

		public string SRNOC_TIPO_RAZON_NODO 
		{
			get{ return _SRNOC_TIPO_RAZON_NODO;}
			set{ _SRNOC_TIPO_RAZON_NODO = value; }
		}
		public string SRNOC_COD_RAZON_NODO 
		{
			get{ return _SRNOC_COD_RAZON_NODO;}
			set{ _SRNOC_COD_RAZON_NODO = value; }
		}
		public string SRNOV_DESCRIPCION 
		{
			get{ return _SRNOV_DESCRIPCION;}
			set{ _SRNOV_DESCRIPCION = value; }
		}
		public string TIPO_RAZON 
		{
			get{ return _TIPO_RAZON;}
			set{ _TIPO_RAZON = value; }
		}
	}
}
