using System;
using System.Configuration;

namespace Claro.SisAct.Configuracion
{
	public abstract class ConfiguracionBase : IConfiguracion
	{
		private ClaroBDConfiguracion _objParametros;

		public ConfiguracionBase(string aplicacion)
		{
			try
			{
				DatoProduccion(aplicacion);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		private void DatoProduccion(string aplicacion)
		{
			if (_objParametros == null)
			{
				_objParametros = new ClaroBDConfiguracion();
			}

			Base.Configuration cfgConexion = new Base.Configuration(aplicacion);

			LeerValores(cfgConexion);
		}


		public abstract void LeerValores(Base.Configuration configuracion);

		public ClaroBDConfiguracion Parametros
		{
			get
			{
				return _objParametros;
			}
		}
	}
}
