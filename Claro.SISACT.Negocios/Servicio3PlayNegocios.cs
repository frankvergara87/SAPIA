using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de Servicio3PlayNegocios.
	/// </summary>
	public class Servicio3PlayNegocios
	{
		public Servicio3PlayNegocios()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ArrayList ListarServicio3Play()
		{
			Servicio3PlayDatos oServicio3PlayDatos = new Servicio3PlayDatos();
			return  oServicio3PlayDatos.ListarServicio3Play();
		}

		public DataTable ListarServicio3PlayTabla(string P_PLNV_CODIGO)
		{
			Servicio3PlayDatos oServicio3PlayDatos = new Servicio3PlayDatos();
			return  oServicio3PlayDatos.ListarServicio3PlayTabla(P_PLNV_CODIGO);
		}

	}
}
