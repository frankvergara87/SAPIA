using System;
using System.Configuration;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexionMANT.
	/// </summary>
	public class ConfigConexionMANT : ConfiguracionBase
	{		
		public ConfigConexionMANT(string aplicacion)
			: base(aplicacion) { }

		
		public override void LeerValores(Base.Configuration configuracion)
		{
			Parametros.BaseDatos = configuracion.LeerBaseDatos();
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
			Parametros.Servidor = "";
			Parametros.Provider = "";
		
		}
	}
}