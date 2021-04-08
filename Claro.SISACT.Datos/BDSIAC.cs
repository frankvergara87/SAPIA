using System;
using System.Configuration; 
using Claro.SisAct.DAAB; 
using Claro.SisAct.Configuracion; 

namespace Claro.SisAct.Datos
{
	public class BDSIAC : SISACT_BDConexion
	{
		public BDSIAC(string aplicacion)
			: base(aplicacion) { }


		protected override IClaroBDConfiguracion Configuracion
		{
			get
			{
				return SISACT_Conexion.GeneraConfiguracion(this.Aplicacion,typeof(ConfigConexionSIAC));			    
			}
		}
	}


}
