using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LServicio
	{
		public LServicio(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DServicio obj = new DServicio();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbListarGrupoServicio()
		{
			DServicio obj = new DServicio();
			return obj.fdtbListarGrupoServicio();
		}

		public DataTable fdtbTraer(string pstrServCodigo)
		{
			DServicio obj = new DServicio();
			return obj.fdtbTraer(pstrServCodigo);	
		}

		public DataTable fdtbListarTipo()
		{
			DServicio obj = new DServicio();
			return obj.fdtbListarTipo();	
		}

		# endregion

		# region "Transacciones"

		public bool fbooServInsertar(string pstrDescripcion, string pstrEstado, string pstrGrupo, int pintOrden, string pstrIddet, string pstrTipo, string pstrUsuario,string pstrCodBSCS, ref string sEstado, ref string rMsg)
		{
			DServicio obj = new DServicio();
			return obj.fbooServInsertar(pstrDescripcion, pstrEstado, pstrGrupo, pintOrden, pstrIddet, pstrTipo, pstrUsuario,pstrCodBSCS, ref sEstado, ref rMsg);
		}

		public bool fbooServEliminar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
		{
			DServicio obj = new DServicio();
			return obj.fbooServEliminar(pstrCodigo, pstrUsuario, ref sEstado, ref rMsg);
		}

		public bool fbooServModificar(string pstrCodigo, string pstrDescripcion, string pstrEstado, string pstrGrupo, int pintOrden, string pstrIddet, string pstrTipo, string pstrUsuario, string pstrCodBSCS, ref string sEstado, ref string rMsg)
		{
			DServicio obj = new DServicio();
			return obj.fbooServModificar(pstrCodigo, pstrDescripcion, pstrEstado, pstrGrupo, pintOrden, pstrIddet, pstrTipo, pstrUsuario,pstrCodBSCS, ref sEstado, ref rMsg);
		}

		# endregion
	}
}
