using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for BLRenoAnticipada.
	/// </summary>
	public class BLRenoAnticipada
	{
		public BLRenoAnticipada()
		{
			
		}

		public bool RegRenoAnticipada(BERenoAnti oRenoAnticipada, ref string oCodRpta, ref string oMensaje)
		{
			DARenoAnticipada obj = new DARenoAnticipada ();
			return obj.RegRenoAnticipada(oRenoAnticipada, ref oCodRpta, ref oMensaje);			
		}


	}
}
