//PROY-32129 :: INI
using System;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Text;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// PROY-33192
	/// </summary>
	public class BLCasoEspecial
	{
		public BLCasoEspecial()
		{
			
		}

		public ArrayList ListarUniversidades(ref string sCodMensaje, ref string sMensaje)
		{
			return new DACasoEspecial().ListarUniversidades(ref sCodMensaje, ref sMensaje);
		}

		public bool RegistrarAlumno(string sTipoDoc, string sNroDoc, Int64 iCodInst, string sCodPersona, string sUsuario ,ref string sCodMensaje, ref string sMensaje)
		{
			DACasoEspecial obj = new DACasoEspecial();
			return obj.RegistrarAlumno(sTipoDoc, sNroDoc, iCodInst, sCodPersona, sUsuario ,ref sCodMensaje, ref sMensaje);
		}

		public bool ValidarAlumno(string sTipoDoc, string sNroDoc, ref string sCodMensaje, ref string sMensaje)
		{
			DACasoEspecial obj = new DACasoEspecial();
			return obj.ValidarAlumno(sTipoDoc, sNroDoc, ref sCodMensaje, ref sMensaje);
		}

		public bool EliminarAlumno(string sTipoDoc, string sNroDoc, string usuario, ref string sCodMensaje, ref string sMensaje)
		{
			DACasoEspecial obj = new DACasoEspecial();
			return obj.EliminarAlumno(sTipoDoc, sNroDoc, usuario, ref sCodMensaje, ref sMensaje);
		}
	}
}
//PROY-32129 :: FIN