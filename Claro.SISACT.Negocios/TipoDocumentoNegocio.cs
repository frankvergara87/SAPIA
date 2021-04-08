using System;
using Claro.SisAct.Datos;
using Claro.SisAct.Entidades;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for TipoDocumentoNegocio.
	/// </summary>
	public class TipoDocumentoNegocio
	{
		public TipoDocumentoNegocio()
		{
		}

		public ArrayList Listar()
		{	
			
			TipoDocumentoDatos objTipoDocumento = new TipoDocumentoDatos();
			return objTipoDocumento.Listar();

		}

		public ArrayList listar(int cod,string descripcion,string estado)
		{
			TipoDocumentoDatos obj = new TipoDocumentoDatos();			
			return obj.listar(cod,descripcion,estado);
		}

		public void insertar(TipoDocumentoE objDocumento,out int resultado)
		{
			TipoDocumentoDatos obj = new TipoDocumentoDatos();	
			obj.insertar(objDocumento,out resultado);
		}

		public void actualizar(TipoDocumentoE objDocumento,out int resultado)
		{
			TipoDocumentoDatos obj = new TipoDocumentoDatos();			
			obj.actualizar(objDocumento,out resultado);
		}

		public void eliminar(int cod,string estado,string usuario,out int resultado)
		{
			TipoDocumentoDatos obj = new TipoDocumentoDatos();			
			obj.eliminar(cod,estado,usuario,out resultado);
		}
	}
}
