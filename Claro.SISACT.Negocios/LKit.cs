using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Mantenimiento de Configuracion de Planes.
	/// </summary>
	public class LKit
	{
		public LKit(){}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{
			DKit obj = new DKit();
			return obj.fdtbListarBusqueda(pstrDescripcion);
		}

		public DataTable fdtbTraer(string pstrCodigo)
		{
			DKit obj = new DKit();
			return obj.fdtbTraer(pstrCodigo);	
		}

		public DataTable fdtbListarTipo()
		{
			DKit obj = new DKit();
			return obj.fdtbListarTipo();
		}

		public DataTable fdtbListarKitEquipo(string pstrCodigo)
		{
			DKit obj = new DKit();
			return obj.fdtbListarKitEquipo(pstrCodigo);
		}

		public DataTable fdtbListarEquipoSinKit(string pstrCodigo)
		{
			DKit obj = new DKit();
			return obj.fdtbListarEquipoSinKit(pstrCodigo);
		}

		public DataTable ListarTipoOperacion(){
			DKit obj = new DKit();
			return obj.ListarTipoOperacion();
		}
		# endregion

		# region "Transacciones"
//gaa20120517
		//public bool fbooInsertar(string pstrDescripcion, string pstrTipo, float pfltMonto, string pstrEstado, string pstrUsuario, DataTable pdtbKitMaterial, ref string sEstado, ref string rMsg)
		public bool fbooInsertar(string pstrDescripcion, string pstrTipo,string pstrTipoOpe, float pfltMonto, float pfltCosto, string pstrEstado, string pstrUsuario, DataTable pdtbKitMaterial, ref string sEstado, ref string rMsg)
//gaa20120517
		{
			bool booResultado;

			DKit obj = new DKit();
//gaa20120517
			//booResultado = obj.fbooInsertar(pstrDescripcion, pstrTipo, pfltMonto, pstrEstado, pstrUsuario, ref sEstado, ref rMsg);
			booResultado = obj.fbooInsertar(pstrDescripcion, pstrTipo,pstrTipoOpe, pfltMonto, pfltCosto, pstrEstado, pstrUsuario, ref sEstado, ref rMsg);
//fin gaa20120517
			pActualizarKitMaterial(sEstado, pstrUsuario, pdtbKitMaterial);

			return booResultado;
		}

		public bool fbooEliminar(string pstrCodigo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DKit obj = new DKit();
			return obj.fbooEliminar(pstrCodigo, pstrUsuario, ref sEstado, ref rMsg);
		}
//gaa20120517
		//public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrTipo, float pfltMonto, string pstrEstado, string pstrUsuario, DataTable pdtbKitMaterial, ref string sEstado, ref string rMsg)
		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrTipo, string pstrTipoOpe,float pfltMonto, float pfltCosto, string pstrEstado, string pstrUsuario, DataTable pdtbKitMaterial, ref string sEstado, ref string rMsg)
//fin gaa20120517
		{
			bool booResultado;

			DKit obj = new DKit();
//gaa20120517
			//booResultado = obj.fbooModificar(pstrCodigo, pstrDescripcion, pstrTipo, pfltMonto, pstrEstado, pstrUsuario, ref sEstado, ref rMsg);
			booResultado = obj.fbooModificar(pstrCodigo, pstrDescripcion, pstrTipo,pstrTipoOpe, pfltMonto, pfltCosto, pstrEstado, pstrUsuario, ref sEstado, ref rMsg);
//fin gaa20120517
			pActualizarKitMaterial(sEstado, pstrUsuario, pdtbKitMaterial);

			return booResultado;
		}

		private void pActualizarKitMaterial(string pstrCodigo, string pstrUsuario, DataTable pdtbKitMaterial)
		{
			string curSalida = string.Empty ;
			string Msg = string.Empty;
			//bool resultado = false;
			DKit obj;

			//Elimina en tabla de kit-material
			obj = new DKit();
			obj.fbooKitMaterialEliminar(pstrCodigo, ref curSalida, ref Msg);

			//Inserta en tabla de kit-material
			foreach (DataRow drw in pdtbKitMaterial.Rows)
			{
				obj = new DKit();
				obj.fbooKitMaterialInsertar(pstrCodigo, 
					Convert.ToString(drw["keqv_codigo"]), 
					Convert.ToString(drw["matv_iddet"]),
					Convert.ToInt32(drw["keqn_cantidad"]),
					pstrUsuario, ref curSalida, ref Msg);
			}
		}

		# endregion
	}
}
