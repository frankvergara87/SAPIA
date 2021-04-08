using System;
using System.Configuration;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexionSISACT.
	/// </summary>
	public class ConfigConexionSISACT : ConfiguracionBase
	{		
		public ConfigConexionSISACT(string aplicacion)
			: base(aplicacion) { }

		
		public override void LeerValores(Base.Configuration configuracion)
		{
			Parametros.BaseDatos = configuracion.LeerBaseDatos();
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
			Parametros.Servidor = "";
			Parametros.Provider = "";
			Parametros.MaxPoolSize = System.Configuration.ConfigurationSettings.AppSettings["PVUMaxPoolSize"];
			Parametros.MinPoolSize = System.Configuration.ConfigurationSettings.AppSettings["PVUMinPoolSize"];
			Parametros.ConnectionLifetime = System.Configuration.ConfigurationSettings.AppSettings["PVUConnectionLifetime"];
			Parametros.Pooling = System.Configuration.ConfigurationSettings.AppSettings["PVUPooling"];
		}
	}
}