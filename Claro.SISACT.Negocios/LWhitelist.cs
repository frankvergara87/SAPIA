using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Configuration; 
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LWhitelist
	{
		public LWhitelist(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrTipoDocumento, string pstrNroDocumento, string pstrFechaInicio, string pstrFechaFin, string pstrUsuarioAprobador)
		{
			DWhitelist obj = new DWhitelist();
			return obj.fdtbListarBusqueda(pstrTipoDocumento, pstrNroDocumento, pstrFechaInicio, pstrFechaFin, pstrUsuarioAprobador);
		}

		public Whitelist fwhlTraer(string pstrTipoDocumento, string pstrNroDocumento)
		{
			DWhitelist obj = new DWhitelist();
			return obj.fwhlTraer(pstrTipoDocumento, pstrNroDocumento);
		}

		public string fstrClienteTraerNombre(string pstrTipoDocumento, string pstrNroDocumento)
		{
			int pintTipoDocumento = 0;

			if (pstrTipoDocumento == ConfigurationSettings.AppSettings["constCodTipoDocumentoDNI"])
				pintTipoDocumento = 2;
			else
			{
				if (pstrTipoDocumento == ConfigurationSettings.AppSettings["constCodTipoDocumentoRUC"])
					pintTipoDocumento = 99;
				else
				{
					if (AppSettings.Key_codDocMigra_Pasaporte_CE.IndexOf(pstrTipoDocumento) > -1)
						pintTipoDocumento = 4;
				}
			}

			DWhitelist obj = new DWhitelist();
			return obj.fstrClienteTraerNombre(pintTipoDocumento, pstrNroDocumento);
		}

		public string fstrUsuarioTraerNombre(string pstrUsuario)
		{
			DWhitelist obj = new DWhitelist();
			return obj.fstrUsuarioTraerNombre(pstrUsuario);
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DWhitelist obj = new DWhitelist();
			return obj.fbooInsertar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooEliminar(string pstrTipoDocumento, string pstrNroDocumento, ref string pstrEstado, ref string pstrMsg)
		{
			DWhitelist obj = new DWhitelist();
			return obj.fbooEliminar(pstrTipoDocumento, pstrNroDocumento, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooModificar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{
			DWhitelist obj = new DWhitelist();
			return obj.fbooModificar(whls, ref pstrEstado, ref pstrMsg);
		}

		public bool fbooEliminarSeleccionados(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			DWhitelist obj = new DWhitelist();
			return obj.fbooEliminarSeleccionados(strSeleccionados, ref pstrEstado, ref pstrMsg);
		}

		# endregion
	}
}
