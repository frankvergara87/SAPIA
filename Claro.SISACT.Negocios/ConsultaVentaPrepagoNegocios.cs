using System;
using System.Collections; 
using Claro.SisAct.Datos; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Configuration;
namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripci�n breve de ConsultaVentaPrepagoNegocios.
	/// </summary>
	public class ConsultaVentaPrepagoNegocios
	{
		public ConsultaVentaPrepagoNegocios()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public ArrayList Lis_Lista_Linea_Material(string strCodigoIccid, out string strCodigoResp)
		{
			ConsultaVentaPrepago obj = new ConsultaVentaPrepago();
			return obj.Lis_Lista_Linea_Material( strCodigoIccid, out strCodigoResp);
		}

	}
}
