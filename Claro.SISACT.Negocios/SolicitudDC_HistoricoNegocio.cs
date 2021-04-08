using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for SolicitudDC_HistoricoNegocio.
	/// </summary>
	public class SolicitudDC_HistoricoNegocio
	{
		public SolicitudDC_HistoricoNegocio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Renovacion
		public void Actualizar_DC_Historico(string numOperacion, string validarCliente)
		{
			new SolicitudDC_HistoricoDatos().Actualizar_DC_Historico(numOperacion,validarCliente);
		}

		public void Insertar_DC_Historico(VistaSolicitudDC_Historico vista)
		{
			new SolicitudDC_HistoricoDatos().Insertar_DC_Historico(vista);
		}
	}
}
