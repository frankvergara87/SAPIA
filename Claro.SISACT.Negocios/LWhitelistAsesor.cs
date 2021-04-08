using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de LWhitelistAsesor.
	/// </summary>
	public class LWhitelistAsesor
	{
		public LWhitelistAsesor()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrTipo, string pstrDescripcion, string pstrOficina)
		{
			DWhitelistAsesor obj = new DWhitelistAsesor();
			return obj.fdtbListarBusqueda(pstrTipo, pstrDescripcion, pstrOficina);
		}

		public DataTable fdtbTraer(string pstrDNI)
		{
			DWhitelistAsesor obj = new DWhitelistAsesor();
			return obj.fdtbTraer(pstrDNI);	
		}

		# endregion

		# region "Transacciones"

		public void pInsertar(string pstrDNI, string pstrNombre, string pstrPaterno, string pstrMaterno, string pstrTelefono, string pstrUsuario, 
								string pstrTipoOficina, string pstrOficina, ref string rMsg)
		{
			DWhitelistAsesor obj = new DWhitelistAsesor();
			obj.pInsertar(pstrDNI, pstrNombre, pstrPaterno, pstrMaterno, pstrTelefono, pstrUsuario, pstrTipoOficina, pstrOficina, ref rMsg);
		}

		public void pEliminar(string pstrDNI, string pstrUsuario, ref string rMsg)
		{
			DWhitelistAsesor obj = new DWhitelistAsesor();
			obj.pEliminar(pstrDNI, pstrUsuario, ref rMsg);
		}

		public void pModificar(string pstrDNI, string pstrNombre, string pstrPaterno, string pstrMaterno, string pstrTelefono, string pstrEstado, string pstrUsuario, ref string rMsg)
		{
			DWhitelistAsesor obj = new DWhitelistAsesor();
			obj.pModificar(pstrDNI, pstrNombre, pstrPaterno, pstrMaterno, pstrTelefono, pstrEstado, pstrUsuario, ref rMsg);
		}

		# endregion
	}
}
