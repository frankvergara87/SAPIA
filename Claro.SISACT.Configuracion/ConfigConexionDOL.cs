using System;
using System.Configuration;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexionDOL.
	/// </summary>
	public class ConfigConexionDOL : ConfiguracionBase
	{		
		public ConfigConexionDOL(string aplicacion)
			: base(aplicacion) { }

		
		public override void LeerValores(Base.Configuration configuracion)
		{
			Parametros.BaseDatos = configuracion.LeerBaseDatos();
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
			Parametros.Servidor = "";
			Parametros.Provider = "";
			Parametros.MaxPoolSize = System.Configuration.ConfigurationSettings.AppSettings["MaxPoolSize"];
			Parametros.MinPoolSize = System.Configuration.ConfigurationSettings.AppSettings["MinPoolSize"];
			Parametros.ConnectionLifetime = System.Configuration.ConfigurationSettings.AppSettings["ConnectionLifetime"];
			Parametros.Pooling = System.Configuration.ConfigurationSettings.AppSettings["Pooling"];
		
		}
	}
}
			
	

		