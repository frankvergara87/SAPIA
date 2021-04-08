using System;
using System.Configuration; 
using Claro.SisAct.DAAB; 
using Claro.SisAct.Configuracion; 

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de BDSIA.
	/// </summary>
	public class BDSIA : SISACT_BDConexion
	{
		public BDSIA(string aplicacion)
			: base(aplicacion) { }

		protected override IClaroBDConfiguracion Configuracion
		{
			get
			{
				return SISACT_Conexion.GeneraConfiguracion(this.Aplicacion,typeof(ConfigConexionSIA));			    
			}
		}
	}
}
