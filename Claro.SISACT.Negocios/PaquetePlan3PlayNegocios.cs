using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for PaquetePlan3PlayNegocios.
	/// </summary>
	public class PaquetePlan3PlayNegocios
	{
		public PaquetePlan3PlayNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool InsertarPaqueteDetalle3Play(PaquetePlan3Play oPaquetePlan3Play)
		{
			PaquetePlan3PlayDatos oPaquetePlan3PlayDatos = new PaquetePlan3PlayDatos();
			return  oPaquetePlan3PlayDatos.InsertarPaqueteDetalle3Play(oPaquetePlan3Play);
		}

		public bool InsertarPaquetePlan3Play(PaquetePlan3Play oPaquetePlan3Play)
		{
			PaquetePlan3PlayDatos oPaquetePlan3PlayDatos = new PaquetePlan3PlayDatos();
			return  oPaquetePlan3PlayDatos.InsertarPaquetePlan3Play(oPaquetePlan3Play);
		}
//ldrz
		public bool EliminarPaquetePlan3Play(string P_PRDC_CODIGO,string P_PAQTV_CODIGO)
		{
			PaquetePlan3PlayDatos oPaquetePlan3PlayDatos = new PaquetePlan3PlayDatos();
			return  oPaquetePlan3PlayDatos.EliminarPaquetePlan3Play(P_PRDC_CODIGO,P_PAQTV_CODIGO);
		}
//ldrz
		public DataTable ListarPaquetePlan3Play(string P_PRDC, string P_PAQTV_CODIGO)
		{
			PaquetePlan3PlayDatos oPaquetePlan3PlayDatos = new PaquetePlan3PlayDatos();
			return  oPaquetePlan3PlayDatos.ListarPaquetePlan3Play(P_PRDC,P_PAQTV_CODIGO);
		}

	}
}
