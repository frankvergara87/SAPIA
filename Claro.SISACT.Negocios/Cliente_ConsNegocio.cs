using System;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de ClienteNegocio.
	/// </summary>
	public class ClienteCons_Negocio
	{
		public ClienteCons_Negocio()
		{
		}

		public ArrayList BuscarClienteCompletoDes(string flagBuscar, string condicion, int tipodoc)
		{
			Cliente_ConsDatos obj = new Cliente_ConsDatos();			
			ArrayList lisClientes;
			
				lisClientes= obj.BuscarClienteCompletoDes(flagBuscar, condicion,tipodoc);
			
			return lisClientes;
		}
		//Renovacion

		public ArrayList BuscarClienteDeudaBloqueo(string flagBuscar, string condicion, int tipodoc)
		{
			Cliente_ConsDatos obj = new Cliente_ConsDatos();			
			ArrayList lisClientes;
		
				lisClientes= obj.BuscarClienteDeudaBloqueo(flagBuscar, condicion,tipodoc);
			

			return lisClientes;
		}

		
	}
}
