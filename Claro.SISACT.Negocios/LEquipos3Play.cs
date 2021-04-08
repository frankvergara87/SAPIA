using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de LEquipos.
	/// </summary>
	public class LEquipos3Play
	{
		public LEquipos3Play()
		{}

        # region "Consultas"
        public DataTable fdtbListarBusquedaEquipos(string pstrDescripcion, string pstrEstado)
        {
            DEquipos3Play obj = new DEquipos3Play();
            return obj.fdtbListarBusquedaEquipos(pstrDescripcion, pstrEstado);
        }

        public DataTable fdtbListarTipoEquipos()
        {
            DEquipos3Play obj = new DEquipos3Play();
            return obj.fdtbListarTipoEquipos();	
        }

        public DataTable fdtbListarEstadoEquipos(string strTipoItem)
        {
            DEquipos3Play obj = new DEquipos3Play();
            return obj.fdtbListarEstadoEquipos(strTipoItem);	
        }

        public DataTable fdtbListarGrupos()
        {
            DEquipos3Play obj = new DEquipos3Play();
            return obj.fdtbListarGrupos();	
        }    

        public DataTable fdtbTraerEquipos(string pstrMateCodigo)
        {
            DEquipos3Play obj = new DEquipos3Play();
            return obj.fdtbTraerEquipos(pstrMateCodigo);
        }

        # endregion

        # region "Transacciones"

		public bool fbooEquiInsertar(string pstrCodigo, string pstrDescripcion, string pstrTipo, string pstrEstado, string pstrGrupo, string pstrIdSap, string pstrDesSap, 
									 string pstrTipEqu, string strAccion, string pstrUsuario, ref string sEstado, ref string rMsg)
        {
            DEquipos3Play obj = new DEquipos3Play();
            bool bol  = obj.fbooEquiInsertar(pstrCodigo, pstrDescripcion, pstrTipo, pstrEstado, pstrIdSap, pstrDesSap, pstrTipEqu, strAccion, pstrUsuario, ref sEstado, ref rMsg);

            if(bol){
               obj.fbooGrupoInsertar(pstrCodigo, pstrGrupo, ref sEstado, ref rMsg);     
            }
            return bol;
        }

        public bool fbooEqui3PlayEliminar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
        {
            DEquipos3Play obj = new DEquipos3Play();
            return obj.fbooEqui3PlayEliminar(pstrCodigo,pstrUsuario,ref sEstado, ref rMsg);
        }
        # endregion
	}
}
