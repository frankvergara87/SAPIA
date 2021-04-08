using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for Paquete3PlayNegocios.
	/// </summary>
	public class Paquete3PlayNegocios
	{
		public Paquete3PlayNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool InsertarPaquete3Play(Paquete3Play oPaquete3Play, ref string sEstado, ref string rMsg)
		{			
			Paquete3PlayDatos oPaquete3PlayDatos = new Paquete3PlayDatos();
			return  oPaquete3PlayDatos.InsertarPaquete3Play(oPaquete3Play, ref sEstado, ref rMsg);
		}

		public bool ActualizarPaquete3Play(Paquete3Play oPaquete3Play)
		{			
			Paquete3PlayDatos oPaquete3PlayDatos = new Paquete3PlayDatos();
			return  oPaquete3PlayDatos.ActualizarPaquete3Play(oPaquete3Play);
		}
//ldrz
		public bool EliminarPaquete3Play(string P_PRDC_CODIGO,string P_PAQTV_CODIGO, string P_USUARIO_CREA)
		{			
			Paquete3PlayDatos oPaquete3PlayDatos = new Paquete3PlayDatos();
			return  oPaquete3PlayDatos.EliminarPaquete3Play(P_PRDC_CODIGO,P_PAQTV_CODIGO, P_USUARIO_CREA);
		}
//ldrz
		public DataTable ListarPaquete3Play(string P_PRDC,string P_PAQTV_CODIGO, string P_PAQTV_DESCRIPCION, string P_ESTADO)
		{
			Paquete3PlayDatos oPaquete3PlayDatos = new Paquete3PlayDatos();
			return  oPaquete3PlayDatos.ListarPaquete3Play(P_PRDC,P_PAQTV_CODIGO, P_PAQTV_DESCRIPCION,P_ESTADO);
		}


//		maquino , ldrz
		public DataTable fdtbListarProductos() 
		{
			DServicio3Play obj =new DServicio3Play();
			return obj.fdtbListarProductos();
		}

	}
}
