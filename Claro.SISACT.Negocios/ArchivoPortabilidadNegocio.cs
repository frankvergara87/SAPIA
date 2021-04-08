using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for ArchivoPortabilidadNegocio.
	/// </summary>
	public class ArchivoPortabilidadNegocio
	{
		public ArchivoPortabilidadNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Renovacion
		public bool InsertarArchivoPortabilidad(ArchivoPortabilidad objDetalle)
		{
			return new ArchivoPortabilidadDatos().InsertarArchivoPortabilidad(objDetalle);
		}
	}
}
