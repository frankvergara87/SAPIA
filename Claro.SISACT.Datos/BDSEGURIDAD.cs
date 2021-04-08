using System;
using System.Configuration; 
using Claro.SisAct.DAAB; 
using Claro.SisAct.Configuracion; 

namespace Claro.SisAct.Datos
{
	public class BDSEGURIDAD : SISACT_BDConexion
	{
		public BDSEGURIDAD(string aplicacion)
			: base(aplicacion) { }


		protected override IClaroBDConfiguracion Configuracion
		{
			get
			{
				return SISACT_Conexion.GeneraConfiguracion(this.Aplicacion,typeof(ConfigConexionSEGURIDAD));			    
			}
		}
	}


}
