using System;
using System.Configuration;
using Claro.SisAct.Configuracion;
using Claro.SisAct.DAAB;

namespace Claro.SisAct.Datos
{

	public abstract class SISACT_BDConexion: SISACT_Conexion
	{
		public SISACT_BDConexion(string aplicacion)
			: base(aplicacion) { }

		protected abstract IClaroBDConfiguracion Configuracion { get; }

		public override DAABRequest CreaRequest()
		{
			DAABRequest.TipoOrigenDatos obOrigen;
			if (Configuracion.Provider.IndexOf("ORA") > 0 || Configuracion.Provider == "")
			{
				obOrigen = DAABRequest.TipoOrigenDatos.ORACLE;
			}
			else
			{
				obOrigen = DAABRequest.TipoOrigenDatos.SQL;
			}
			return new DAABRequest(obOrigen, Configuracion.CadenaConexion);
		} 
	}
}
