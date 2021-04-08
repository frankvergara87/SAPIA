using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Riesgo.
	/// </summary>
	public class Riesgo
	{
		private int _RIEN_CODIGO;
		private string _RIEV_DESCRIPCION;
		private string _RIEV_ESTADO;
		private int _RIEN_PRIORIDAD;
		private string _RIEV_LOGIN_REG;
		private DateTime _RIED_FECHA_REGISTRO;
		private string _RIEV_TERMINAL;
		private string _RIEV_VALOR_EQUIVAL;
		private string _RIEV_ENTRADA;

		public int RIEN_CODIGO {get{ return _RIEN_CODIGO;} set{_RIEN_CODIGO = value;}}
		public string RIEV_DESCRIPCION {get{ return _RIEV_DESCRIPCION;} set{_RIEV_DESCRIPCION = value;}}
		public string RIEV_ESTADO {get{ return _RIEV_ESTADO;} set{_RIEV_ESTADO = value;}}
		public int RIEN_PRIORIDAD {get{ return _RIEN_PRIORIDAD;} set{_RIEN_PRIORIDAD = value;}}
		public string RIEV_LOGIN_REG {get{ return _RIEV_LOGIN_REG;} set{_RIEV_LOGIN_REG = value;}}
		public DateTime RIED_FECHA_REGISTRO {get{ return _RIED_FECHA_REGISTRO;} set{_RIED_FECHA_REGISTRO = value;}}
		public string RIEV_TERMINAL {get{ return _RIEV_TERMINAL;} set{_RIEV_TERMINAL = value;}}
		public string RIEV_VALOR_EQUIVAL {get{ return _RIEV_VALOR_EQUIVAL;} set{_RIEV_VALOR_EQUIVAL = value;}}
		public string RIEV_ENTRADA {get{ return _RIEV_ENTRADA;} set{_RIEV_ENTRADA = value;}}

		public Riesgo()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
	}
}
