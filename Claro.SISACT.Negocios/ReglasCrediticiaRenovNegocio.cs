using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de ReglasEvaluacionRenovNegocio.
	/// </summary>
	public class ReglasCrediticiaRenovNegocio
    {
		ReglasCrediticiaRenovWS.ReglasEvaluacionCrediticiaWS _oTransaccion = new ReglasCrediticiaRenovWS.ReglasEvaluacionCrediticiaWS();
		
		public ReglasCrediticiaRenovNegocio()
		{
			_oTransaccion.Url = ConfigurationSettings.AppSettings["RutaWS_ReglasCrediticiaRenov"].ToString();
			_oTransaccion.Credentials= System.Net.CredentialCache.DefaultCredentials;
			_oTransaccion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOut_ReglasCrediticiaRenov"].ToString());

		}

	
		public bool ConsultaMatrizReglas(MatrizReglasIN oReglasIN, ref MatrizReglasOUT oReglasOUT, ref string mensaje)
		{	
			ReglasCrediticiaRenovWS.ReglaType[] outAuditType;
			string codRetorno;

			bool blnOK = false;
			string idTransaccion = oReglasIN.NroDocumento;
			try
			{
				codRetorno = _oTransaccion.consultarReglas(ref idTransaccion,
					ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString(),
					ConfigurationSettings.AppSettings["constAplicacion"].ToString(),
					ConfigurationSettings.AppSettings["USRProceso"].ToString(),
					oReglasIN.TipoDespacho, 
					oReglasIN.TipoProducto,
					oReglasIN.Canal,
					oReglasIN.Pdv,
					oReglasIN.TipoCliente,
					oReglasIN.TipoDocumento,
					oReglasIN.Departamento,
					oReglasIN.Provincia,
					oReglasIN.Distrito,
					oReglasIN.CasoEspecial,
					oReglasIN.FactorEndeudamiento,
					oReglasIN.TipoOperacion,
					oReglasIN.Oferta,
					oReglasIN.Plan,
					Funciones.CheckDbl(oReglasIN.CargoFijo),
					oReglasIN.PlazoAcuerdo,
					oReglasIN.Campania,
					oReglasIN.Control,
					oReglasIN.FactorSubsidio,
					oReglasIN.PorcentajeCuotaInicial,
					oReglasIN.Cuotas,
					oReglasIN.Kit,
					oReglasIN.Riesgo,
					oReglasIN.Score,
					Funciones.CheckInt(oReglasIN.Edad),
					oReglasIN.CantidadRRLL,
					oReglasIN.Publicar,
					oReglasIN.FactorRenovacion,
					oReglasIN.ComportamientoPago,
					out mensaje,
					out outAuditType);			

				if (codRetorno == "0")
				{
					blnOK = true;
					oReglasOUT.TipoGarantia = Funciones.CheckStr(outAuditType[0].tipoGarantia);
					oReglasOUT.Restriccion = Funciones.CheckStr(outAuditType[0].restriccion);
					oReglasOUT.AbsolutoReferencial = Funciones.CheckStr(outAuditType[0].absolutoReferencial);
					oReglasOUT.MontoGarantia = Funciones.CheckStr(outAuditType[0].montoGarantia);
					oReglasOUT.CostoInstalacion = Funciones.CheckStr(outAuditType[0].costoInstalacion);
					oReglasOUT.CantidadProductoMax = Funciones.CheckStr(outAuditType[0].cantidadProductoMax);
					oReglasOUT.respuestaRenovacion=Funciones.CheckStr(outAuditType[0].respuestaRenovacion);
				}
				else
				{
					mensaje = codRetorno + "|" + mensaje;
				}
			}
			catch(Exception ex)
			{
				blnOK = false;
				mensaje = ex.Message;
				throw ex;
			}
			finally 
			{
				_oTransaccion.Dispose(); 
			}

			return blnOK;
		}
	}
}
