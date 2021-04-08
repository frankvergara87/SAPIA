using System;
using System.Configuration;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexionClarify.
	/// </summary>
	public class ConfigConexionClarify : ConfiguracionBase
	{		
		public ConfigConexionClarify (string aplicacion)
			: base(aplicacion) { }

		
		public override void LeerValores(Base.Configuration configuracion)
		{
			Parametros.BaseDatos = configuracion.LeerBaseDatos();
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
			Parametros.Servidor = "";
			Parametros.Provider = "";
			Parametros.MaxPoolSize = System.Configuration.ConfigurationSettings.AppSettings["CLFYMaxPoolSize"];
			Parametros.MinPoolSize = System.Configuration.ConfigurationSettings.AppSettings["CLFYMinPoolSize"];
			Parametros.ConnectionLifetime = System.Configuration.ConfigurationSettings.AppSettings["CLFYConnectionLifetime"];
			Parametros.Pooling = System.Configuration.ConfigurationSettings.AppSettings["CLFYPooling"];
		
		}
	}
}