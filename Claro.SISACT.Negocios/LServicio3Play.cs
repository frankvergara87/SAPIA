using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de LServicio3Play.
	/// </summary>
	public class LServicio3Play
	{
		public LServicio3Play()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
        # region "Consultas"
        public DataTable fdtbListarBusquedaServicio3Play(string pstrDescripcion, string pstrEstado)
        {
            DServicio3Play obj = new DServicio3Play();
            return obj.fdtbListarBusquedaServicio3Play(pstrDescripcion, pstrEstado);
        }
        
        public DataTable fdtbListarEstadoServ3Play(string strTipoItem)
        {
            DServicio3Play obj = new DServicio3Play();
            return obj.fdtbListarEstadoServ3Play(strTipoItem);

        }
	//ldrz
	public DataTable fdtbListarProductos()
		{
			DServicio3Play obj =new DServicio3Play();
			return obj.fdtbListarProductos();
		}
         //ldrz
		public DataTable fdtbListarGruposxProducto(string pstrCodProd)
		{
			DServicio3Play obj =new DServicio3Play();
			return obj.fdtbListarGruposxProducto(pstrCodProd);
		}
        public DataTable fdtbListarGrupos()
        {
            DServicio3Play obj =new DServicio3Play();
            return obj.fdtbListarGrupos();
        }

        public DataTable fdtbTraerServicio3Play(string pstrServCodigo)
        {	
            DServicio3Play obj =new DServicio3Play();
            return obj.fdtbTraerServicio3Play(pstrServCodigo);
        }
        # endregion
        
        # region "Transacciones"
        public bool fbooServInsertar(string pstrCodigo, string pstrDescripcion, string pstrIdConfigITW, string pstrDescripcionExt, string pstrDescripcionSisact, string pstrEstado, string pstrGrupo, int pintOrden,  string pstrUsuario, ref string sEstado, ref string rMsg)
        {
            DServicio3Play obj =new DServicio3Play();
            return obj.fbooServInsertar(pstrCodigo,pstrDescripcion,pstrIdConfigITW,pstrDescripcionExt,pstrDescripcionSisact,pstrEstado,pstrGrupo,pintOrden,pstrUsuario,ref sEstado, ref rMsg);        }

        public bool fbooServ3PlayModificar(string pstrCodigo, string pstrDescripcion, string pstrIdConfigITW, string pstrDescripcionExt, string pstrDescripcionSisact, string pstrEstado, string pstrGrupo, int pintOrden,  string pstrUsuario, ref string sEstado, ref string rMsg)
        {
            DServicio3Play obj =new DServicio3Play();
            return obj.fbooServ3PlayModificar(pstrCodigo,pstrDescripcion,pstrIdConfigITW,pstrDescripcionExt,pstrDescripcionSisact,pstrEstado,pstrGrupo,pintOrden,pstrUsuario,ref sEstado, ref rMsg);
        }
        public bool fbooServ3PlayEliminar(string pstrCodigo, string pstrUsuario, ref int sEstado, ref string rMsg)
        {
            DServicio3Play obj =new DServicio3Play();
            return obj.fbooServ3PlayEliminar(pstrCodigo,pstrUsuario,ref sEstado , ref rMsg);
        }
        # endregion

        //ESALASB, ldrz
        public DataTable fdtbListarEquiposxServicio3Play(string pstrProducto,string pstrDescripcion,string pstrEstado)
        {			
            DServicio3Play obj = new DServicio3Play();
            return obj.fdtbListarEquiposxServicio3Play(pstrProducto,pstrDescripcion,pstrEstado);
        }
        //ldrz
        public DataTable fdtbListarServiciosxGrupo3Play(string pstrProducto,string pstrGrupo)
        {			
            DServicio3Play obj = new DServicio3Play();
            return obj.fdtbListarServiciosxGrupo3Play(pstrProducto,pstrGrupo);
        }
        public DataTable fdtbObtenerEquiposxCodigo3Play(string pstrCodigo)
        {			
            DServicio3Play obj = new DServicio3Play();
            return obj.fdtbObtenerEquiposxCodigo3Play(pstrCodigo);
        }
        public DataTable fdtbObtenerEquiposxServicio3Play(string pstrServicio)
        {			
            DServicio3Play obj = new DServicio3Play();
            return obj.fdtbObtenerEquiposxServicio3Play(pstrServicio);
        }
        //ldrz
        public DataTable fdtbListarEquiposxGrupo3Play(string pstrProducto,string pstrGrupo,string pstrServicio)
        {			
            DServicio3Play obj = new DServicio3Play();
            return obj.fdtbListarEquiposxGrupo3Play(pstrProducto,pstrGrupo, pstrServicio);
        }
        public bool fbooInsertarEquiposxServicio3Play(string pstrGrupo, string pstrIdServicio, string pstrServicio, string pstrEstado, string pstrEquipos,ref string pstrMensaje)
        {
            DServicio3Play obj =new DServicio3Play();
            return obj.fbooInsertarEquiposxServicio3Play(pstrGrupo,pstrIdServicio,pstrServicio,pstrEstado,pstrEquipos, ref pstrMensaje);
        }

        public bool fbooEliminarEquipoxServicio3Play(string pstrCodigo,ref string pstrMensaje)
        {
            DServicio3Play obj =new DServicio3Play();
            return obj.fbooEliminarEquipoxServicio3Play(pstrCodigo, ref pstrMensaje);
        }
	}
}
