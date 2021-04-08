using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripci�n breve de LBlacklistDAC.
	/// </summary>
	public class LBlacklistDAC
	{
		public LBlacklistDAC()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public DataTable fdtbListarBusqueda(string pstrDescripcion, string pstrCodDpto)
		{
			DBlacklistDAC obj = new DBlacklistDAC();
			return obj.fdtbListarBusqueda(pstrDescripcion, pstrCodDpto);
		}

		public DataTable fdtbListarDAC(string pstrDescripcion, string pstrCodDpto)
		{
			DBlacklistDAC obj = new DBlacklistDAC();
			return obj.fdtbListarDAC(pstrDescripcion, pstrCodDpto);
		}

		public bool fbooInsertar(string pstrCodigos, string pstrUsuario, ref string rMsg)
		{
			DBlacklistDAC obj = new DBlacklistDAC();
			return obj.fbooInsertar(pstrCodigos, pstrUsuario, ref rMsg);
		}

		public bool fbooEliminar(string pstrCodigo, ref string rMsg)
		{
			DBlacklistDAC obj = new DBlacklistDAC();
			return obj.fbooEliminar(pstrCodigo, ref rMsg);
		}

		public void fbooEliminarRango(string pstrItemsSel)
		{
			DBlacklistDAC obj = new DBlacklistDAC();
			obj.fbooEliminarRango(pstrItemsSel);
		}
	}
}
