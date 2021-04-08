using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripci�n breve de CobranzaNegocios.
	/// </summary>
	public class CobranzaNegocios
	{
		public CobranzaNegocios()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		/* -----------------------------------------------------------------------------------
		 * Objetivo : Permite insertar un ajuste por reclamo
		 * Creaci�n : E77281  / 15-10-2012
		 * -----------------------------------------------------------------------------------*/
		public Int32 InsertarAjustesXReclamos(Int64 vCUSTOMERID, string vCodOCC, string vFecha, string vPeriodo, double vMonto, string vComentario)
		{
				CobranzaDatos oDatos = new CobranzaDatos();
				return oDatos.InsertarAjustesXReclamos(vCUSTOMERID,vCodOCC,vFecha,vPeriodo,vMonto,vComentario);
			
		}
	}
}
