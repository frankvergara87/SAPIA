using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de LoginUsuarioNegocios.
	/// </summary>
	public class LoginUsuarioNegocios
	{
		public LoginUsuarioNegocios()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public ArrayList ListarOpcionesPagina(Int64 strCodUsuario, Int64 strCodAplicacion)
		{
			LoginUsuarioDatos obj = new LoginUsuarioDatos();
			return obj.ListarOpcionesPagina(strCodUsuario, strCodAplicacion);
		}
		public Usuario ConsultaDatosUsuario(string p_cta_red)
		{
			return (new LoginUsuarioDatos()).ConsultaDatosUsuario(p_cta_red);
		}
		public PuntoVenta ValidarOficinaVenta(string strOficinaVenta)
		{
			return (new LoginUsuarioDatos()).ValidarOficinaVenta(strOficinaVenta);
		}
	}
}
