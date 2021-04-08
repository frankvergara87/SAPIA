using System;
using System.Configuration;
using Claro.SisAct.Configuracion;
using Claro.SisAct.DAAB;
using System.Collections;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for SISACT_Conexion.
	/// </summary>
	public abstract class SISACT_Conexion
	{
		protected string mAplicacion; 		
		//private static System.Collections.Hashtable _arrConfigurraciones;
		private static ArrayList _arrConfigurraciones;
		public SISACT_Conexion(string aplicacion)
		{
			mAplicacion = aplicacion; 
		}

		public static IClaroBDConfiguracion GeneraConfiguracion(string aplicacion, Type typeParam) 
		{ 		
			return GeneraConfiguracion(aplicacion, System.Configuration.ConfigurationSettings.AppSettings[aplicacion], typeParam);			
		}
		
		public static IClaroBDConfiguracion GeneraConfiguracion(string aplicacion, string archivoConfig, Type typeParam) 
		{ 
			if (_arrConfigurraciones == null)
			{
				_arrConfigurraciones = new ArrayList();
			}
		
			ClaroBDConfiguracion objType = null;

			foreach (ClaroBDConfiguracion o in _arrConfigurraciones)
			{
				if (o.Name == aplicacion)
				{
					objType = o;
					break;
				}
			}

			if (objType == null) 
			{
				if ((aplicacion == null || aplicacion == ""))
				{
					throw new ApplicationException("No ha especificado el Key del Código de la Aplicacion");
				}
		
				if ((archivoConfig == null || archivoConfig == ""))
				{
					throw new ApplicationException("No se encuentra el Key del Archivo de Configuracion");
				}

				IConfiguracion objType1 =(IConfiguracion) Activator.CreateInstance(typeParam, new object[] {archivoConfig});
				objType1.Parametros.Name =aplicacion;
				objType = objType1.Parametros;
				_arrConfigurraciones.Add(objType);
			}
			return (ClaroBDConfiguracion)objType;
		}
		
		protected string Aplicacion
		{
			get
			{
				return this.mAplicacion;
			}
		}
		
		public abstract DAABRequest CreaRequest();
	}
}
