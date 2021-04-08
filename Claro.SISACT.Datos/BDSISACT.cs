using System;
using System.Configuration; 
using Claro.SisAct.DAAB; 
using Claro.SisAct.Configuracion; 

namespace Claro.SisAct.Datos
{
	public class BDSISACT : SISACT_BDConexion
	{
		public BDSISACT(string aplicacion)
			: base(aplicacion) { }


		protected override IClaroBDConfiguracion Configuracion
		{
			get
			{
				return SISACT_Conexion.GeneraConfiguracion(this.Aplicacion,typeof(ConfigConexionSISACT));			    
			}
		}
	}


}
