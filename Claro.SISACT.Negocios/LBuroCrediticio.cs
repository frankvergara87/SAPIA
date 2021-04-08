using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de LWhitelistAsesor.
	/// </summary>
	public class LBuroCrediticio
	{
		public LBuroCrediticio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		# region "Consultas"

		public DataTable ListarBusqueda(string strTipo, string strDescripcion, string strDocumento, string strEstado)
		{
			DBuroCrediticio obj = new DBuroCrediticio();
			return obj.ListarBusqueda(strTipo, strDescripcion, strDocumento, strEstado);
		}

		public DataTable ListarConfigBuro(string strDocumento)
		{
			DBuroCrediticio obj = new DBuroCrediticio();
			return obj.ListarConfigBuro(strDocumento);	
		}

		public DataTable ConsultarDatos(string strCodigo)
		{
			DBuroCrediticio obj = new DBuroCrediticio();
			return obj.ConsultarDatos(strCodigo);	
		}

		# endregion

		# region "Transacciones"

		public void ModificarEstado(string strBuros, string strEstado)
		{
			DBuroCrediticio obj = new DBuroCrediticio();
			obj.ModificarEstado(strBuros, strEstado);
		}

		public void ModificarDatos(string strCodigo, string strNombre, string strDescripcion, string strDocumento, 
								string strEstado, string strUsuario)
		{
			DBuroCrediticio obj = new DBuroCrediticio();
			obj.ModificarDatos(strCodigo, strNombre, strDescripcion, strDocumento, strEstado, strUsuario);
		}

		public void ModificarConfigBuro(string strConfBuro, string strDocumento, string strUsuario)
		{
			DBuroCrediticio obj = new DBuroCrediticio();
			obj.ModificarConfigBuro(strConfBuro, strDocumento, strUsuario);
		}

		# endregion
	}
}
