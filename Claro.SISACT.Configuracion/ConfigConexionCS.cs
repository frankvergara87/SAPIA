using System;
using System.Configuration;

namespace Claro.SisAct.Configuracion
{
	/// <summary>
	/// Summary description for ConfigConexion_CS.
	/// </summary>
	public class ConfigConexionCS : ConfiguracionBase
	{		
		public ConfigConexionCS(string aplicacion)
			: base(aplicacion) { }

		
		public override void LeerValores(Base.Configuration configuracion)
		{
			Parametros.Usuario = configuracion.LeerUsuario();
			Parametros.Password = configuracion.LeerContrasena();
				
		}

		public static ConfigConexionCS GetInstance(string aplicacion)
		{
			return new ConfigConexionCS(aplicacion);
		}

		}
	}

