using System;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexion_SAP.
	/// </summary>
	public class ConfigConexionSAP: ConfiguracionBase
	{
		public ConfigConexionSAP(string aplicacion)
			: base(aplicacion) { }
		
		public override void LeerValores(Base.Configuration configuracion)
		{
			Parametros.BaseDatos = configuracion.LeerBaseDatos();
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
		}

		public static ConfigConexionSAP GetInstance(string aplicacion)
		{
			return new ConfigConexionSAP(aplicacion);
		}
	}
}
