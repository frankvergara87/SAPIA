using System;
using System.Data;
using Claro.SisAct.Datos;
using System.Collections;
using Claro.SisAct.Entidades;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de ChipRepuestoPostpagoNegocio.
	/// </summary>
	public class ChipRepuestoPostpagoNegocio
	{
		public ChipRepuestoPostpagoNegocio()
		{
		}

		public DataSet ListaServicios(int codID, ref string codPlan,ref string desPlan){
			ChipRepuestoPostpagoDatos obj = new ChipRepuestoPostpagoDatos();
			return obj.ListaServicios(codID, ref codPlan,ref desPlan);
		}

		public ArrayList ListaDepartamentos()
		{	
			ChipRepuestoPostpagoDatos obj = new ChipRepuestoPostpagoDatos();
			return obj.ListaDepartamentos();
		}

		public ArrayList ListaProvincias(string codDep)
		{	
			ChipRepuestoPostpagoDatos obj = new ChipRepuestoPostpagoDatos();
			return obj.ListaProvincias(codDep);
		}

		public ArrayList ListaDistritos(string codDep, string codProv)
		{	
			ChipRepuestoPostpagoDatos obj = new ChipRepuestoPostpagoDatos();
			return obj.ListaDistritos(codDep, codProv);
		}

		public bool GrabarVentaReposicion(VentaReposicionPost oVentaReposicionPost, ref string rMsg)
		{
			ChipRepuestoPostpagoDatos obj = new ChipRepuestoPostpagoDatos();
			return obj.GrabarVentaReposicion(oVentaReposicionPost, ref rMsg);
		}

		//*************************************** INICIO WHZR *********************************************
		public int ValidarPlanesLTG4G(string pstrNumLinea, ref string strMSG)
		{
			ChipRepuestoPostpagoDatos obj = new ChipRepuestoPostpagoDatos();
			return obj.ValidarPlanesLTG4G(pstrNumLinea, ref strMSG);
		}
		//*************************************** FIN WHZR *********************************************
	}
}
