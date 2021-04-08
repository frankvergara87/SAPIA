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
	/// Descripción breve de DatosPostpagoNegocios.
	/// </summary>
	public class DatosPostpagoNegocios
	{
		ConsultaPostpagoWS.SIACPostpagoConsultasWSService _DatosPostpago = new ConsultaPostpagoWS.SIACPostpagoConsultasWSService();

		public DatosPostpagoNegocios()
		{
			_DatosPostpago.Url = ConfigurationSettings.AppSettings["RutaWS_DatosPostpago"].ToString();
			_DatosPostpago.Credentials= System.Net.CredentialCache.DefaultCredentials;
			_DatosPostpago.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeoutWS"].ToString());
		}

		public ClienteBSCS LeerDatosCliente(string nroTelefono, string custcode, ref string MensajeError)
		{	
			ClienteBSCS item = null;
			try
			{
				ConsultaPostpagoWS.datosClienteResponse objPostpagoResponse = new ConsultaPostpagoWS.datosClienteResponse();
				ConsultaPostpagoWS.cliente objCliente = new ConsultaPostpagoWS.cliente();

				// Consulta Método Datos Cliente
				objPostpagoResponse = _DatosPostpago.datosCliente(custcode, nroTelefono);
				objCliente = objPostpagoResponse.cliente[0];

				if (Funciones.CheckStr(objCliente.customerId)!="")
				{
					item = new ClienteBSCS();

					item.CustomerId = objCliente.customerId;
					item.Cuenta = objCliente.cuenta;
					item.Nombre = objCliente.nombre;
					item.Apellidos = objCliente.apellidos;
					item.RazonSocial = objCliente.razonSocial;
					item.Tip_doc = objCliente.tip_doc;
					item.Num_doc = objCliente.num_doc;
					item.Titulo = objCliente.titulo;
					item.Telef_principal = objCliente.telef_principal;
					item.Estado_civil = objCliente.estado_civil;
					item.Fecha_nac = objCliente.fecha_nac;
					item.Lug_nac = objCliente.lug_nac;
					item.Ruc_dni = objCliente.ruc_dni;
					item.Nomb_comercial = objCliente.nomb_comercial;
					item.Contacto_cliente = objCliente.contacto_cliente;
					item.Rep_legal = objCliente.rep_legal;
					item.Telef_contacto = objCliente.telef_contacto;
					item.Fax = objCliente.fax;
					item.Email = objCliente.email;
					item.Cargo = objCliente.cargo;
					item.Consultor = objCliente.consultor;
					item.Asesor = objCliente.asesor;
					item.Direccion_fac = objCliente.direccion_fac;
					item.Urbanizacion_fac = objCliente.urbanizacion_fac;
					item.Distrito_fac = objCliente.distrito_fac;
					item.Provincia_fac = objCliente.provincia_fac;
					item.Cod_postal_fac = objCliente.cod_postal_fac;
					item.Departamento_fac = objCliente.departamento_fac;
					item.Pais_fac = objCliente.pais_fac;
					item.Direccion_leg = objCliente.direccion_leg;
					item.Urbanizacion_leg = objCliente.urbanizacion_leg;
					item.Distrito_leg = objCliente.distrito_leg;
					item.Provincia_leg = objCliente.provincia_leg;
					item.Cod_postal_leg = objCliente.cod_postal_leg;
					item.Departamento_leg = objCliente.departamento_leg;
					item.Pais_leg = objCliente.pais_leg;
					item.Co_id = objCliente.co_id;
					item.Nicho_id = objCliente.nicho_id;
					item.Num_cuentas = objCliente.num_cuentas;
					item.Num_lineas = objCliente.num_lineas;
					item.Ciclo_fac = objCliente.ciclo_fac;
					item.Status_cuenta = objCliente.status_cuenta;
					item.Modalidad = objCliente.modalidad;
					item.Tipo_cliente = objCliente.tipo_cliente;
					item.Fecha_act = objCliente.fecha_act;
					item.Limite_credito = objCliente.limite_credito;
					item.Segmento = objCliente.segmento;
					item.Respon_pago = objCliente.respon_pago;
					item.Credit_score = objCliente.credit_score;
					item.Forma_pago = objCliente.forma_pago;
					item.Codigo_tipo_cliente = objCliente.codigo_tipo_cliente;
					item.Sexo = objCliente.sexo;
					item.Nacionalidad = objCliente.nacionalidad;
					item.Estado_civil_id = objCliente.estado_civil_id;
				}
				else
				{
					MensajeError = "El número de teléfono no es Postpago.";
				}
			}
			catch(Exception ex)
			{
				MensajeError = "El servicio esta temporalmente fuera de servicio. " + ex.Message;
			}

			return item;
		}
		public string obtenerIMSI(int co_id,ref string MensajeError)
		{
			string nroIMSI="";
			try
			{
				ConsultaPostpagoWS.contrato objPostpagoResponse = new ConsultaPostpagoWS.contrato();
				//ConsultaPostpagoWS.contrato objContrato = new ConsultaPostpagoWS.contrato();

				objPostpagoResponse = _DatosPostpago.datosContrato(co_id)[0];
				nroIMSI = objPostpagoResponse.imsi + ";" + objPostpagoResponse.plan;
				//nroIMSI = objPostpagoResponse.imsi;
			}
			catch(Exception ex)
			{
				MensajeError = "El servicio esta temporalmente fuera de servicio. " + ex.Message;
			}
			return nroIMSI;
		}

	}
}
