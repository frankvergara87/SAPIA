using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for TipoRiesgoNegocio.
	/// </summary>
	public class TipoOperacionNegocio
	{
		public TipoOperacionNegocio()
		{
			
		}

		public ArrayList ListarTipoOperacion(int tipoOperacion, string tipoProducto)
		{
			return new TipoOperacionDatos().ListarTipoOperacion(tipoOperacion,tipoProducto);
		}
	}
}
