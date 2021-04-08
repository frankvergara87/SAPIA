using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for SolicitudDC_ReporteNegocio.
	/// </summary>
	public class SolicitudDC_ReporteNegocio
	{
		public SolicitudDC_ReporteNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Renovacion
		public void Insertar_DC_Reporte(Vista_SolicitudDC_Reporte vista)
		{
			new SolicitudDC_ReporteDatos().Insertar_DC_Reporte(vista);
		}

		public void Insertar_Correccion_Nombres(Vista_Correccion_Nombres vista)
		{
			new SolicitudDC_ReporteDatos().Insertar_Correccion_Nombres(vista);
		}

		public bool Insertar_DC_Parametros(DataCredito_Input_Output bean)
		{
			return new SolicitudDC_ReporteDatos().Insertar_DC_Parametros(bean);		
		}

		public bool Actualizar_Input_Output(DataCredito_Input_Output bean)
		{
			return new SolicitudDC_ReporteDatos().Actualizar_Input_Output(bean);
		}

	}
}
