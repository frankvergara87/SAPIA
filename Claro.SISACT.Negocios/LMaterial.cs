using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LMaterial
	{
		public LMaterial(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DMaterial obj = new DMaterial();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbTraer(string pstrCodigo)
		{
			DMaterial obj = new DMaterial();
			return obj.fdtbTraer(pstrCodigo);	
		}

		public DataTable fdtbListarTipoMaterial()
		{
			DMaterial obj = new DMaterial();
			return obj.fdtbListarTipoMaterial();
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(string pstrCodigo, string pstrDescripcion, string pstrEstado, string pstrIddet, string pstrTipo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DMaterial obj = new DMaterial();
			return obj.fbooInsertar(pstrCodigo, pstrDescripcion, pstrEstado, pstrIddet, pstrTipo, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooEliminar(string pstrCodigo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DMaterial obj = new DMaterial();
			return obj.fbooEliminar(pstrCodigo, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrEstado, string pstrIddet, string pstrTipo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DMaterial obj = new DMaterial();
			return obj.fbooModificar(pstrCodigo, pstrDescripcion, pstrEstado, pstrIddet, pstrTipo, pstrUsuario, ref sEstado, ref rMsg);
		}

		# endregion
	}
}
