using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de InteraccionNegocios.
	/// </summary>
	public class InteraccionNegocios
	{
		public InteraccionNegocios()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public ItemGenerico InsertarInteraccion(Interaccion item) 
		{
			InteraccionDatos obj = new InteraccionDatos();
			return obj.InsertarInteraccion(item);
		}

	}
}
