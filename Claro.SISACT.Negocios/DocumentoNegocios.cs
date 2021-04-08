using System;
using Claro.SisAct.Datos;
using System.Collections;
using Claro.SisAct.Entidades;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for DocumentoNegocios.
	/// </summary>
	public class DocumentoNegocios
	{
		public DocumentoNegocios()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Obtiene todos los Documentos de la Capa de Datos
		/// </summary>
		/// <returns></returns>
		public ArrayList Listar(int pCodigoTipoDocumento)
		{				
			DocumentoDatos objDocumento = new DocumentoDatos();
		
				return objDocumento.Listar(pCodigoTipoDocumento);
		}


		public ArrayList listar(int cod,string descripcion,string estado,int tipodoc)
		{
			DocumentoDatos obj = new DocumentoDatos();			
			return obj.listar(cod,descripcion,estado,tipodoc);
		}

		public void insertar(Documento objDocumento,out int resultado)
		{
			DocumentoDatos obj = new DocumentoDatos();			
			obj.insertar(objDocumento,out resultado);
		}

		public void actualizar(Documento objDocumento,out int resultado)
		{
			DocumentoDatos obj = new DocumentoDatos();			
			obj.actualizar(objDocumento,out resultado);
		}

		public void eliminar(int cod,string estado,string usuario,out int resultado)
		{
			DocumentoDatos obj = new DocumentoDatos();			
			obj.eliminar(cod,estado,usuario,out resultado);
		}		
	}
}
