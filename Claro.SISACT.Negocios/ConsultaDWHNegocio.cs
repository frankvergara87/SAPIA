using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for ConsultaDWHNegocio.
	/// </summary>
	public class ConsultaDWHNegocio
	{
		public ConsultaDWHNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public ArrayList LineasAbonado(string p_tipo_documento, string p_nro_documento)
		{
			return new ConsultaDWH().LineasAbonado(p_tipo_documento, p_nro_documento);
		}
	}
}
