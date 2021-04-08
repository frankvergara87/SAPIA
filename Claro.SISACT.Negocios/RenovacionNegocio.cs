using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for RenovacionNegocio.
	/// </summary>
	public class RenovacionNegocio
	{
		public RenovacionNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public ArrayList ListarTipoOperacion()
		{
			return new RenovacionDatos().ListarTipoOperacion();
		}

		public ArrayList ListarTipoOferta(string strTipoDocumento)
		{
			return new RenovacionDatos().ListarTipoOferta(strTipoDocumento);
		}
	}
}
