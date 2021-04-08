using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;

namespace Claro.SisAct.Negocios
{
	public class TablaNegocio
	{
		public TablaNegocio()
		{}

		public ArrayList Listar_Portal()
		{
			return new TablaDatos().Listar_Portal();
		}
	}
}
