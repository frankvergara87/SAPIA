using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
//using Claro.SisAct.WSDatos;
using System.Data;
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for NumeroPortabilidadNegocio.
	/// </summary>
	public class NumeroPortabilidadNegocio
	{
		public NumeroPortabilidadNegocio()
		{ }
		
		//Renovacion
		public bool validarNumeroPortabilidad(string strNumeroPortabilidad, ref string strMensajeError)
		{
			if (!ConsultarNumeroPortabilidad(strNumeroPortabilidad, ref strMensajeError))
			{
				string numeroPortabilidad;
				numeroPortabilidad = strNumeroPortabilidad.Substring(strNumeroPortabilidad.Length - 9, 9);
				if(validaEstadoPortabilidad(numeroPortabilidad, ref strMensajeError))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				strMensajeError = "El número ingresado se encuentra en proceso de portabilidad. SEC: " + strMensajeError;
				return true;
			}
		}

		public bool ConsultarNumeroPortabilidad(string strNumeroPortabilidad, ref string strSec)
		{
			NumeroPortabilidadDatos objNumeroPortabilidadDatos = new NumeroPortabilidadDatos();
			strSec = objNumeroPortabilidadDatos.ConsultarNumeroPortabilidad(strNumeroPortabilidad).ToString();
			if(strSec.Equals(""))
				return false; 
			else
				return true;
		}

		public bool validaEstadoPortabilidad(string strNumeroPortabilidad, ref string strMensajeError)
		{
			return true;
//			ValidacionNumeroPortabilidad objValidacionNumeroPortabilidad = new ValidacionNumeroPortabilidad();
//			return objValidacionNumeroPortabilidad.validarProcesoPortabilidad(strNumeroPortabilidad, ref strMensajeError);
		}

		public bool InsertarNumeroPortabilidad(NumeroPortabilidad objDetalle)
		{
			return new NumeroPortabilidadDatos().InsertarNumeroPortabilidad(objDetalle);
		}

		public bool ValidarListaNumerosPortabilidad(ArrayList listaTelefonos, ref ArrayList lineasAptas, ref ArrayList lineasNoAptas, bool flagValidarRepetidas, ref string strMensajeError)
		{
			int i = 0;

			string listaSinRepetidas = "";
			ArrayList listaTelfTmp = new ArrayList();
			listaTelfTmp.AddRange(listaTelefonos);
			
			for (i=0; i<listaTelfTmp.Count; i++)
			{
				NumeroPortabilidad item = (NumeroPortabilidad) listaTelfTmp[i];
				string numeroTelefono = item.PORT_NUMERO;
				if (listaSinRepetidas.IndexOf(numeroTelefono) != -1)
				{
					if (flagValidarRepetidas)
					{
						strMensajeError = "Error: Numero a Portar " + numeroTelefono + " ya se encuentra en la lista actual.";
						return false;
					}
					listaTelfTmp.RemoveAt(i);
					i--;
				}
				else
				{
					listaSinRepetidas = listaSinRepetidas + numeroTelefono + ";";
				}
			}

			NumeroPortabilidadDatos objNumeroPortabilidadDatos = new NumeroPortabilidadDatos();
			return objNumeroPortabilidadDatos.ValidarListaNumerosPortabilidad(listaTelfTmp, ref lineasAptas, ref lineasNoAptas, ref strMensajeError);
		}


	}
}
