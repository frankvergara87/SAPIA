using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for PlanDetalleConsNegocio.
	/// </summary>
	public class PlanDetalleConsNegocio
	{
		public PlanDetalleConsNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public ArrayList ObtenerPlanesSolicitudConsumer_DTH(string nrosec)
		{
			return new PlanDetalleConsDatos().ObtenerPlanesSolicitudConsumer_DTH(nrosec);
		}

		public bool InsertarKitSolicitud_DTH(SecKit_AP objItemKit)
		{
			return new PlanDetalleConsDatos().InsertarKitSolicitud_DTH(objItemKit);
		}

		public bool InsertarPlanSolicitud_DTH(PlanDetalleConsumer objDetalle, ref string rMsg)
		{
			return new PlanDetalleConsDatos().InsertarPlanSolicitud_DTH(objDetalle, ref rMsg);
		}

		public bool InsertarServiciosSolicitud(ArrayList listaServicios)
		{
			return new PlanDetalleConsDatos().InsertarServiciosSolicitud(listaServicios);
		}
	}
}
