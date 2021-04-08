using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de LoginUsuarioDatos.
	/// </summary>
	public class LoginUsuarioDatos
	{
		public LoginUsuarioDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ArrayList ListarOpcionesPagina(Int64 strCodUsuario, Int64 strCodAplicacion)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("k_user", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("k_aplic_cod", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("k_cur_menu", DbType.Object, ParameterDirection.Output)
											   };
			int i;

			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			i=0; arrParam[i].Value = strCodUsuario;
			i++; arrParam[i].Value = strCodAplicacion;

			BDSEGURIDAD obj = new BDSEGURIDAD(BaseDatos.BD_DBAUDIT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command= BaseDatos.PKG_SEGU_SEGURIDAD  + ".SEGU_PAGINA_OPCIONES_X_USUARIO";			
			objRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;

			ArrayList filas = new ArrayList();

			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;				
				string opciones = "";
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = dr["OPCIC_COD"].ToString();
					item.Descripcion = dr["CLAVE"].ToString();
					item.Descripcion2 = dr["OPCIC_DES"].ToString();
					filas.Add(item);
					opciones += "," + item.Descripcion;

				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return filas;
		}

		public Usuario ConsultaDatosUsuario(string p_cta_red)
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_CTA_RED", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = p_cta_red;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CONSULTA_PDV_USUARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			Usuario oUsuario = new Usuario();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					oUsuario.UsuarioId = Funciones.CheckInt64(dr["USUAN_CODIGO"]);
					oUsuario.TipoOficinaId = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					oUsuario.OficinaId = Funciones.CheckStr(dr["OVENC_CODIGO"]);
				}	
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return oUsuario;
		}

		public PuntoVenta ValidarOficinaVenta(string strOficinaVenta)
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_OFICINA_VENTA", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Object, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = strOficinaVenta;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_VALIDAR_OFICINA";
			obRequest.Parameters.AddRange(arrParam);
			
			PuntoVenta oPuntoVenta = new PuntoVenta();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					oPuntoVenta.OVENC_PDV_RENOV = Funciones.CheckStr(dr["OVENC_PDV_RENOV"]);
					oPuntoVenta.OVENC_PDV_REPOS = Funciones.CheckStr(dr["OVENC_PDV_REPOS"]);						
					oPuntoVenta.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
				}	
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return oPuntoVenta;
		}
	}
}
