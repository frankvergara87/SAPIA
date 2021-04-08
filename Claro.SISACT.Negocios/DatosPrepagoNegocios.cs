using System;
using Claro.SisAct.Entidades;
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
	/// Descripción breve de DatosPrepagoNegocios.
	/// </summary>
	public class DatosPrepagoNegocios
	{
		DatosPrepagoWS.EbsDatosPrepagoService _DatosPrepago = new DatosPrepagoWS.EbsDatosPrepagoService();

		public DatosPrepagoNegocios()
		{
			_DatosPrepago.Url = ConfigurationSettings.AppSettings["RutaWS_DatosPrepago"].ToString();
			_DatosPrepago.Credentials= System.Net.CredentialCache.DefaultCredentials;
			_DatosPrepago.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeoutWS"].ToString());
		}

		public ItemGenerico LeerDatosPrepago(string nroTelefono, string providerIdPrepago, string providerIdControl, ref string MensajeError)
		{	
			//string strCodRetorno = "";
			ItemGenerico itemDatos = null;
			try
			{
				string[] listPrepago = providerIdPrepago.Split('|');
				string[] listControl = providerIdControl.Split('|');

				DatosPrepagoWS.INDatosPrepagoRequest objPrepagoReq = new DatosPrepagoWS.INDatosPrepagoRequest();
				DatosPrepagoWS.INDatosPrepagoResponse objPrepagoResp = new DatosPrepagoWS.INDatosPrepagoResponse();
				objPrepagoReq.telefono = nroTelefono;
				objPrepagoResp = _DatosPrepago.leerDatosPrepago(objPrepagoReq);

				if (objPrepagoResp.resultado.Trim()=="0")
				{
					//strCodRetorno="E";
					MensajeError="Provider ID no identificado";

					for (int idx=0; idx<listPrepago.Length; idx++)
					{
						if (objPrepagoResp.datosPrePago.providerID.Trim() == listPrepago[idx])
						{
							MensajeError="Prepago";
							itemDatos = new ItemGenerico();
							itemDatos.Numero = nroTelefono;
							itemDatos.Descripcion = objPrepagoResp.datosPrePago.imsi;
							itemDatos.Codigo = objPrepagoResp.datosPrePago.isLocked;
							itemDatos.Codigo2 = objPrepagoResp.datosPrePago.subscriberLifeCycleStatus;
							itemDatos.estado = "P";
							break;
						}
					}
					for (int idy=0; idy<listControl.Length; idy++)
					{
						if (objPrepagoResp.datosPrePago.providerID.Trim() == listControl[idy])
						{
							MensajeError="Control";
							itemDatos = new ItemGenerico();
							itemDatos.Numero = nroTelefono;
							itemDatos.Descripcion = objPrepagoResp.datosPrePago.imsi;
							itemDatos.Codigo = objPrepagoResp.datosPrePago.isLocked;
							itemDatos.Codigo2 = objPrepagoResp.datosPrePago.subscriberLifeCycleStatus;
							itemDatos.estado = "C";
							break;
						}
					}
				}
				else
				{
					//strCodRetorno="E";
					MensajeError = "El número ingresado No es PREPAGO.";
				}

			}
			catch(Exception ex)
			{
				//strCodRetorno="E";
				MensajeError = "El servicio esta temporalmente fuera de servicio. " + ex.Message;
				//exp.StackTrace();
				//ex.ToString();
			}

			return itemDatos;
		}
	}
}
