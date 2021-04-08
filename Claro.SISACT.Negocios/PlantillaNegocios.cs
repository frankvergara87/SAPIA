using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripci�n breve de PlantillaNegocios.
	/// </summary>
	public class PlantillaNegocios
	{
		public PlantillaNegocios()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public bool InsertarPlantillaInteraccion(PlantillaInteraccion plantillaInteraccion,
			string vInteraccionId, 			
			ref string rFlagInsercion ,
			ref string rMsgText)
		{															
			bool resultadoPlantilla = false;
			string strTransaccion = plantillaInteraccion.NOMBRE_TRANSACCION;						
			
			PlantillaDatos oGrabar = new PlantillaDatos();		
			resultadoPlantilla = oGrabar.InsertarPlantillaInteraccion(plantillaInteraccion,vInteraccionId,ref rFlagInsercion,ref rMsgText);						
									
			return true;
		}
	}
}
