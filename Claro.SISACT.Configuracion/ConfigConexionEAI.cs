using System;
using System.Configuration;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexionEAI.
	/// </summary>
	public class ConfigConexionEAI : ConfiguracionBase
	{		
		public ConfigConexionEAI(string aplicacion)
			: base(aplicacion) { }

		
		public override void LeerValores(Base.Configuration configuracion)
		{
			Parametros.BaseDatos = configuracion.LeerBaseDatos();
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
			Parametros.Servidor = "";
			Parametros.Provider = "";
			Parametros.MaxPoolSize = System.Configuration.ConfigurationSettings.AppSettings["EAIMaxPoolSize"];
			Parametros.MinPoolSize = System.Configuration.ConfigurationSettings.AppSettings["EAIMinPoolSize"];
			Parametros.ConnectionLifetime = System.Configuration.ConfigurationSettings.AppSettings["EAIConnectionLifetime"];
			Parametros.Pooling = System.Configuration.ConfigurationSettings.AppSettings["EAIPooling"];
		
		}
	}
}
			
	