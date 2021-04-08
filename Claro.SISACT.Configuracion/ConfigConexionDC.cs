using System;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexion_DC.
	/// </summary>
	public class ConfigConexionDC : ConfiguracionBase
	{
		public ConfigConexionDC(string aplicacion)
			: base(aplicacion) { }
		
		public override void LeerValores(Base.Configuration configuracion)
		{			
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
		}

		public static ConfigConexionDC GetInstance(string aplicacion)
		{
			return new ConfigConexionDC (aplicacion);
		}
	}
}
