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
	/// Descripción breve de MigracionNegocios.
	/// </summary>
	public class MigracionNegocios
	{
		MigracionWS.EbsEjecucionMigracionService _migracion = new MigracionWS.EbsEjecucionMigracionService();

		public MigracionNegocios()
		{
			_migracion.Url = ConfigurationSettings.AppSettings["RutaWS_Migracion"].ToString();
			_migracion.Credentials= System.Net.CredentialCache.DefaultCredentials;
			_migracion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeoutWSMigracion"].ToString());
		}

		public void ejecutarMigracion(string telefono,string fecha_programacion,string flag_notificar,string idtransaccion)
		{
			MigracionWS.ejecutarMigracionRequest objMigracionReq = new MigracionWS.ejecutarMigracionRequest();

			objMigracionReq.telefono=telefono;
			objMigracionReq.fechaProgramacion=fecha_programacion;
			objMigracionReq.flagNotificar=flag_notificar;
			objMigracionReq.idTransaccion=idtransaccion;
			
			_migracion.ejecutarMigracion(objMigracionReq);
		}

		public bool RegistrarMigracion(Claro.SisAct.Entidades.DetalleTransaccion detalle,ref string rFlagInsercion ,ref string rMsgText)
		{
			MigracionDatos oMigracionDatos=new MigracionDatos();
			return oMigracionDatos.RegistrarMigracion(detalle,ref rFlagInsercion ,ref rMsgText);
		}
	}
}
