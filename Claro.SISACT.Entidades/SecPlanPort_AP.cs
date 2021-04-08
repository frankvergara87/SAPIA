using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de SecPlanPort_AP.
	/// </summary>
	public class SecPlanPort_AP
	{
		private string _PORT_NUMERO;
		private ParametroPortabilidad _PORT_MODALIDAD;

		public string PORT_NUMERO {get{ return _PORT_NUMERO;} set{_PORT_NUMERO = value;}}
		public ParametroPortabilidad PORT_MODALIDAD {get{ return _PORT_MODALIDAD;} set{_PORT_MODALIDAD = value;}}

		public SecPlanPort_AP()
		{
			PORT_NUMERO = string.Empty;
			PORT_MODALIDAD = new ParametroPortabilidad();
		}
	}
}
