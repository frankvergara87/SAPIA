using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for ConsultaSIACNegocios.
	/// </summary>
	public class ConsultaSIACNegocios
	{
		public ConsultaSIACNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public string ValidaBloqueoLinea(string p_numero_telefono)
		{
			return new ConsultaSIAC().ValidaBloqueoLinea(p_numero_telefono);
		}

	}
}
