using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for MesaPortabilidadNegocio.
	/// </summary>
	public class MesaPortabilidadNegocio
	{
		public MesaPortabilidadNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool EnvioMPxSec(int intSec, string strUsuario)
		{
			MesaPortabilidadDatos obj = new MesaPortabilidadDatos();			
			return obj.EnvioMPxSec(intSec, strUsuario);
		}

		public ArrayList ObtenerDetalleSEC(int nroSec)
		{
			MesaPortabilidadDatos obj = new MesaPortabilidadDatos();			
			return obj.ObtenerDetalleSEC(nroSec);
		}

	}
}
