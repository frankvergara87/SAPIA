using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Configuration; 


namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for MaestroDatos.
	/// </summary>
	public class MaestroDatos
	{
		public MaestroDatos(){}

		public Usuario ObtenerUsuarioLogin(string login)
		{			
			
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_USUAC_CTARED", DbType.String,15,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			
			if(login != "") arrParam[0].Value = login;			
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SECSS_DET_USUARIO_LOGIN";
			obRequest.Parameters.AddRange(arrParam);
			
			Usuario item = new Usuario();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					item.UsuarioId= Funciones.CheckInt64(dr["USUAN_CODIGO"]); 	
					item.Nombre =  Funciones.CheckStr(dr["USUAV_NOMBRE"]);
					item.Email     = Funciones.CheckStr(dr["USUAV_EMAIL"]);
					item.Telefono  = Funciones.CheckStr(dr["USUAV_TELEFONO"]);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{				
				if (dr != null && dr.IsClosed==false ) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return item;
		}	
		public ArrayList ListaOficinaVentaXUsuario(int usuarioId,string oficinaId, string estado)
		{			
			
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_USUAN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USPDC_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = usuarioId;
			++i; arrParam[i].Value = oficinaId;
			++i; arrParam[i].Value = estado;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_MANT_CON_PDV_X_USUARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())		
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.Descripcion= Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					item.estado = Funciones.CheckStr(dr["USPDC_ESTADO"]);
					filas.Add(item);
				}				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public Hashtable ListarItemsGenericos(int[] tablas)
		{
			/*
				Lista de tablas 
				-------------------
				1: TIPO DE DOCUMENTO
				2: Tipo Cliente
				3: APN
				4: Prefijo
				5: Departamento
				6; Score
				7: Actividad comercial
				8: Promoción
				9: Plazo Equipo
				10: Tipo Operacion
				11: Almacen
				12: Tipo Interior
				13:	Tipo Edificacion
				14:	Lista Urbanizacion
				15: Tipo Zona
			*/
			Hashtable salida = new Hashtable();			
			foreach(int i in tablas)
			{
				switch(i)
				{
					case 1: // TIPO DE DOCUMENTO
						salida.Add(i, ListaTipoDocumento("R") );
						break;
					case 2: // Tipo Cliente
						salida.Add(i,ListaTipoCliente(0) );
						break;
					case 3: // APN
						salida.Add(i, ListaAPN());
						break;
					case 4: // Prefijo
						salida.Add(i, ListaPrefijo("00","A"));
						break;
					case 5: // Departamento
						salida.Add(i, ListaDepartamento("00","A"));
						break;
					case 6: // Score
						salida.Add(i, ListaScore());
						break;						
					case 7:
						salida.Add(i,ListaActividadComercial());
						break;
					case 8 :
						salida.Add(i,ListaModalidadCampanna("02"));
						break;
					case 9 :
						salida.Add(i,ListaPlazoEquipo());
						break;
					case 10 :
						salida.Add(i,ListaTipoOperacion());
						break;
					case 11:
						salida.Add(i,ListaAlmacen());
						break;
					case 12:
						salida.Add(i,ListaTipoInterior());
						break;						
					case 13: // 13:	Tipo Edificacion
						salida.Add(i,ListaTipoEdificacion());
						break;
					case 14:	// Lista Urbanizacion
						salida.Add(i,ListaUrbanizacion());
						break;
					case 15:	//Tipo Zona
						salida.Add(i,ListaTipoZona());
						break;
				}
			}
			return salida;
		}

		public ArrayList ListaPrefijo(string prefijo , string estado)
		{			
			
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("K_PRE_DIRECCION", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if(!prefijo.Equals("")) arrParam[0].Value = prefijo;			
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
		
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_PREFIJO_DIR";
			
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo= Funciones.CheckStr(dr["PDIRC_CODIGO"]);
					item.Codigo2= Funciones.CheckStr(dr["PDIRV_ABREVIATURA"]);
					item.Descripcion = Funciones.CheckStr(dr["PDIRV_DESCRIPCION2"]);					
					item.Descripcion2= Funciones.CheckStr(dr["PDIRV_ABREVIATURA"]) + " - " + Funciones.CheckStr(dr["PDIRV_DESCRIPCION2"]);					
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
			
		}

		public ArrayList ListaDepartamento(string cod_dpto,string estado)
		{			
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_COD_DEPARTAMENTO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_ESTADO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if(!cod_dpto.Equals("")) arrParam[0].Value = cod_dpto;
			if(!estado.Equals("")) arrParam[1].Value = estado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SECP_MAESTROS + ".SECSS_CON_DEPARTAMENTO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Departamento item = new Departamento();
					item.DEPAC_CODIGO= Funciones.CheckStr(dr["DEPAC_CODIGO"]);
					item.DEPAV_DESCRIPCION= Funciones.CheckStr(dr["DEPAV_DESCRIPCION"]);
					item.DEPAV_COD_CIU= Funciones.CheckStr(dr["DEPAV_COD_CIU"]);
					item.DEPAC_ESTADO= Funciones.CheckStr(dr["DEPAC_ESTADO"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}
		public ArrayList ListaActividadComercial()
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 		
			
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_ACTIVIDAD_COMERCIAL";
			obRequest.Parameters.AddRange(arrParam);
		
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["ACOMV_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["ACOMV_DESCRIPCION"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaParametros(Int64 codigo)
		{			
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_PARAN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if (codigo>0 ) arrParam[0].Value = codigo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_PARAMETRO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Parametro item = new Parametro();
					item.Codigo = Funciones.CheckInt64(dr["PARAN_CODIGO"]);
					item.Valor= Funciones.CheckStr(dr["PARAV_VALOR"]);
					item.Valor1= Funciones.CheckStr(dr["PARAV_VALOR1"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		
		//OGV
		public ArrayList ListaParametrosGrupo(Int64 codigoGP)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_PARAN_GRUPO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if (codigoGP>0 ) arrParam[0].Value = codigoGP;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_PARAMETRO_GP";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Parametro item = new Parametro();
					item.Codigo = Funciones.CheckInt64(dr["PARAN_CODIGO"]);
					item.Descripcion= Funciones.CheckStr(dr["PARAV_DESCRIPCION"]);
					item.Valor= Funciones.CheckStr(dr["PARAV_VALOR"]);
					item.Valor1= Funciones.CheckStr(dr["PARAV_VALOR1"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}
//PROY-24724-IDEA-28174 - INICIO  PARAMETROS
		public ArrayList ListaParametrosGrupo_Keys(Int64 codigoGP)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_PARAN_GRUPO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
		
			if (codigoGP>0 ) arrParam[0].Value = codigoGP;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_PARAMETRO_GP";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					string[] item = new string[] {"",""};
                                        item[0]= Funciones.CheckStr(dr["PARAV_VALOR"]);
					item[1]= Funciones.CheckStr(dr["PARAV_VALOR1"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}//PROY-24724-IDEA-28174 - FIN  PARAMETROS
		public ArrayList ListaTipoDocumento(string flag_ruc)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_FLAG_CON", DbType.String,1,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(flag_ruc != "") arrParam[0].Value = flag_ruc;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_TIPO_DOC";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.Codigo2 = Funciones.CheckStr(dr["ID_BSCS"]);
					item.Descripcion = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaModalidadCampanna(string producto)
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			if (producto != null && producto != "" ) arrParam[0].Value = producto;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_CAMPANA";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo= Funciones.CheckStr(dr["CAMPN_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);					
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaPDVPorCanal(string cod_producto,string cod_canal)
		{			

			DAABRequest.Parameter[] arrParam = {    
												   new DAABRequest.Parameter("K_TPROC_CODIGO", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CANAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			
			arrParam[0].Value = cod_producto;
			arrParam[1].Value = cod_canal;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_PDV_X_CANAL";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					PuntoVenta item = new PuntoVenta();					
					item.OVENC_CODIGO= Funciones.CheckStr(dr["OVENC_CODIGO"]);								
					item.OVENV_DESCRIPCION= Funciones.CheckStr(dr["OVENV_DESCRIPCION"]) + " - " + Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.TOFIC_CODIGO= Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					item.CANAC_CODIGO= Funciones.CheckStr(dr["CANAC_CODIGO"]);
					item.CANAV_DESCRIPCION= Funciones.CheckStr(dr["CANAV_DESCRIPCION"]);
					item.OVENC_REGION= Funciones.CheckStr(dr["OVENC_REGION"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}

		public ArrayList ListaProvincia(string cod_provincia,string cod_dpto,string estado)
		{			
		
			
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("K_COD_PROVINCIA", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_COD_DEPARTAMENTO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_ESTADO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!cod_provincia.Equals("")) arrParam[0].Value = cod_provincia;
			if(!cod_dpto.Equals("")) arrParam[1].Value = cod_dpto;
			if(!estado.Equals("")) arrParam[2].Value = estado;

						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD + ".SECSS_CON_PROVINCIA";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Provincia item = new Provincia();
					item.PROVC_CODIGO= Funciones.CheckStr(dr["PROVC_CODIGO"]);
					item.DEPAC_CODIGO= Funciones.CheckStr(dr["DEPAC_CODIGO"]);
					item.PROVV_DESCRIPCION= Funciones.CheckStr(dr["PROVV_DESCRIPCION"]);
					item.PROVC_ESTADO= Funciones.CheckStr(dr["PROVC_ESTADO"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}		

		public ArrayList ListaDistrito(string cod_distrio,string cod_provincia,string cod_dpto,string estado)
		{					
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("K_COD_DISTRITO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_COD_PROVINCIA", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_COD_DEPARTAMENTO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_ESTADO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!cod_distrio.Equals("")) arrParam[0].Value = cod_distrio;
			if(!cod_provincia.Equals("")) arrParam[1].Value = cod_provincia;
			if(!cod_dpto.Equals("")) arrParam[2].Value = cod_dpto;
			if(!estado.Equals("")) arrParam[3].Value = estado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD + ".SECSS_CON_DISTRITO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Distrito item = new Distrito();
					item.DISTC_CODIGO= Funciones.CheckStr(dr["DISTC_CODIGO"]);
					item.DEPAC_CODIGO= Funciones.CheckStr(dr["DEPAC_CODIGO"]);
					item.PROVC_CODIGO= Funciones.CheckStr(dr["PROVC_CODIGO"]);
					item.DISTC_CODIGO_POSTAL= Funciones.CheckStr(dr["DISTC_CODIGO_POSTAL"]);
					item.DISTV_DESCRIPCION= Funciones.CheckStr(dr["DISTV_DESCRIPCION"]);
					item.DISTC_ESTADO= Funciones.CheckStr(dr["DISTC_ESTADO"]);
					item.ALMACEN= Funciones.CheckStr(dr["DISTC_ALMACEN"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}		
		
		public ArrayList ListaTipoCliente(int P_TCLIN_CODIGO)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TCLIN_CODIGO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(P_TCLIN_CODIGO >0) arrParam[0].Value = P_TCLIN_CODIGO;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_TIPO_CLIENTE";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo= Funciones.CheckStr(dr["TCLIN_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["TCLIV_DESCRIPCION"]);					
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaScore()
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_SCORE";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["SCREC_CODIGO"]);
					item.Descripcion = item.Codigo ;
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaAPN()
		{
			return ListaTablaGeneral("A");
		}

		public ArrayList ListaTipoInterior()
		{
			return ListaTablaGeneralSISACT("D");
		}
		
		public ArrayList ListaTipoEdificacion()
		{
			return ListaTablaGeneralSISACT("M");
		}
		public ArrayList ListaUrbanizacion()
		{
			return ListaTablaGeneralSISACT("U");
		}
		public ArrayList ListaTipoZona()
		{
			return ListaTablaGeneralSISACT("Z");
		}

		public ArrayList ListaTablaGeneral(string tipo)
		{			
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_DETC_TIPO", DbType.String,2,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = tipo;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_DET_TABLAS";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo= Funciones.CheckStr(dr["DETN_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["DETV_DESCRIPCION"]);					
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaTablaGeneralSISACT(string tipo)
		{			
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_TABLN_TIPO", DbType.String,2,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_TABLN_ESTADO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = tipo;
			arrParam[1].Value = "1";
			arrParam[2].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_TABLA_TABLAS";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo= Funciones.CheckStr(dr["TABLN_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["TABLN_DESCRIPCION"]);										
					item.Descripcion2 = Funciones.CheckStr(dr["TABLN_CODIGO"]) + " - " + Funciones.CheckStr(dr["TABLN_DESCRIPCION"]);					
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaPlazoEquipo()
		{
			return ListaTablaGeneral("E");
		}
		public ArrayList ListaTipoOperacion()
		{
			return ListaTablaGeneralSISACT("O");
		}
		public ArrayList ListaAlmacen()
		{
			return ListaTablaGeneralSISACT("A");
		}

		public ArrayList ConsultarListaCampanias(string p_tipo_venta, string p_fecha, string p_mandt, string strFiltro)
		{
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("P_TIPO_VENTA", DbType.String, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_FECHA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MANDT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			//i=0; if (p_plan_tarifario != "") { arrParam[i].Value = p_plan_tarifario; }
			//++i; if (p_tipo_cliente != "") { arrParam[i].Value = p_tipo_cliente; }
			i=0; if (p_tipo_venta != "") { arrParam[i].Value = p_tipo_venta; }
			//++i; if (p_tipo_operacion != "") { arrParam[i].Value = p_tipo_operacion; }
			++i; if (p_fecha != "") { arrParam[i].Value = p_fecha; }
			++i; if (p_mandt != "") { arrParam[i].Value = p_mandt; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_LISTAR_CAMPANIAS";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["CAMPANA"]);
					item.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
					item.Codigo2 = Funciones.CheckStr(dr["TIPO_VENTA"]);

					if(strFiltro.Length>0)
					{
						if(strFiltro.IndexOf(item.Codigo)!=-1)
						{
					filas.Add(item);
				}
			}
					else{
						filas.Add(item);
					}				
					
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaPDVUsuario(Int64 cod_usuario,string cod_producto)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_USUAN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_TPROC_CODIGO", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if(cod_usuario > 0) arrParam[0].Value = cod_usuario;
			arrParam[1].Value = cod_producto;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_PDV_X_USUARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					PuntoVenta item = new PuntoVenta();					
					item.OVENC_CODIGO= Funciones.CheckStr(dr["OVENC_CODIGO"]);								
					item.OVENV_DESCRIPCION= Funciones.CheckStr(dr["OVENV_DESCRIPCION"]) + " - " + Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.TOFIC_CODIGO= Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					item.CANAC_CODIGO= Funciones.CheckStr(dr["CANAC_CODIGO"]);
					item.CANAV_DESCRIPCION= Funciones.CheckStr(dr["CANAV_DESCRIPCION"]);
					item.OVENC_REGION= Funciones.CheckStr(dr["OVENC_REGION"]);
					item.OVENC_ASISTENCIA = Funciones.CheckStr(dr["OVENC_ASISTENCIA"]);
					item.OVENV_OUTOFFBIO = Funciones.CheckStr(dr["OVENC_ASISTENCIA"]);  //PROY-25335 - Contratación Electrónica - Release 0
					item.OVENC_FLAG_BIO_POST = Funciones.CheckStr(dr["OVENC_FLAG_BIO_POST"]);  //PROY-25335 - Contratación Electrónica - Release 0
					item.OVENC_FLAGHUELLERO_POST = Funciones.CheckStr(dr["OVENC_FLAGHUELLERO_POST"]);  //PROY-25335 - Contratación Electrónica - Release 0
					
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}

		//Registro DNI VENDEDOR 
		public int insertarBlackListCanalPdv( BLCanalPDV oBlackList) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COD_CANAL", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_PDV", DbType.String,40,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_REG", DbType.String,40,ParameterDirection.Input)
											   }; 
			
			
			string codCanal = oBlackList.COD_CANAL;
			string codPDV = oBlackList.COD_PDV;
			string usuario_reg = oBlackList.USUARIO_REG;

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0;		
			++i; if(codCanal != null && codCanal != "") arrParam[i].Value = codCanal;
			++i; if(codPDV != null && codPDV != "") arrParam[i].Value = codPDV;
			++i; if(usuario_reg != null && usuario_reg != "") arrParam[i].Value = usuario_reg;
						
			int retorno = 0;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest  = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 						
							
			obRequest.Parameters.Clear();
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_INS_BLACKLIST_CANALPDV";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
			}
			catch(Exception e)
			{						
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				retorno = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
			return retorno;	
		}

		public bool eliminarBlackListCanalPdv( int vID , ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_ID", DbType.Int32,ParameterDirection.Input)											   }; 
			
			
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0;		
			++i; arrParam[i].Value = vID;
						
			bool salida = false;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest  = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Transactional = true;
							
			obRequest.Parameters.Clear();
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_DEL_BLACKLIST_CANALPDV";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				rMsg = "Error al Eliminar BlackList de Canal y Pdv " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public ArrayList ListaBlackListCanalPdv()
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_CON_BLACKLIST_CANALPDV";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
					
				while(dr.Read())
				{
					BLCanalPDV oBlackList = new BLCanalPDV();
					oBlackList.ORDEN = Funciones.CheckStr(dr["ORDEN"]);
					oBlackList.ID = Funciones.CheckInt(dr["ID"]);
					oBlackList.COD_CANAL= Funciones.CheckStr(dr["COD_CANAL"]);						
					oBlackList.DES_CANAL=Funciones.CheckStr(dr["TOFIV_DESCRIPCION"]);
					oBlackList.COD_PDV=Funciones.CheckStr(dr["COD_PUNTO_VENTA"]);
					oBlackList.DES_PDV=Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					filas.Add(oBlackList);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public String ConsultarDac(string ctaRed) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_VEN_CTA_RED", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_DAC_ACT", DbType.String, ParameterDirection.Output)
											   };
      
			arrParam[0].Value = ctaRed;  
			arrParam[1].Value = DBNull.Value;

			string salida = "";
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_MANT_CON_DAC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			int bb;

			try
			{
				bb=Convert.ToInt16(obRequest.Factory.ExecuteScalar(ref obRequest));
				obRequest.Factory.CommitTransaction();
 
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				salida = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}                 
			return salida ;

		}

		public ArrayList ListaTipoOficinaVentaUsuario(Int64 cod_usuario,string cod_producto)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_USUAN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_TPROC_CODIGO", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if(cod_usuario > 0) arrParam[0].Value = cod_usuario;			
			arrParam[1].Value = cod_producto;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_TIPO_OFI_X_USUARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["TOFIV_DESCRIPCION"]);										
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}	
		// T12618 - Implementación módulo vendedores 05/2009 INICIO
		public bool ValidarBlackList(Vendedor item , ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_VEN_NUM_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;
			arrParam[i].Value = item.NumeroDocumento;      
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_VAL_BLACKLIST_VENDEDOR";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			int bb;
			try
			{
				bb=Convert.ToInt16(obRequest.Factory.ExecuteScalar(ref obRequest));
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				if(Funciones.CheckInt(parSalida1.Value) > 0)
					salida = true;
				obRequest.Factory.Dispose();
			}                 
			return salida ;
		}
		// T12618 - Implementación módulo vendedores 05/2009 FIN
		// T12618 - Implementación módulo vendedores 05/2009 INICIO
		public bool GrabarVendedor(Vendedor item, ref int sEstado, ref string rMsg, ref Vendedor itemVendedorExistente)
		{	
			bool resultado = false;
			int usuarioId = Funciones.CheckInt(item.VendedorId);
			
			ArrayList oConsulta;
			
			if (item.VendedorId == 0)
			{
				oConsulta =	ListaVendedor(item,"4",item.distribuidorId,"","","");
			}
			else
			{
				oConsulta =	ListaVendedor(item,"3",item.distribuidorId,"","","");
			}
			
			if (oConsulta.Count == 0)
			{
				resultado = InsertarVendedor(item,ref sEstado,ref rMsg) ;
				usuarioId = sEstado;
				if (resultado == true && sEstado > 0)
				{
					rMsg = "Vendedor registrado satisfactoriamente.";
				}
				else
				{
					if ( sEstado > 0 )					
					{
						rMsg = "Error al Crear el Vendedor.";
					}
				}
			}
			else
			{	
				Vendedor itemVendedor = new Vendedor();
				itemVendedor = (Vendedor)oConsulta[0];

				//Vendedor enviado como nuevo pero ya existe el DNI
				if (item.VendedorId == 0)
				{
					if (itemVendedor.EstadoId == "04")
					{
						//Artificio para evaluacion de devolucion de datos y ponerlos inactivos
						long vendedorIdEnviado = item.VendedorId;
						item.VendedorId = itemVendedor.VendedorId;
						
						//Validar si tiene mas de 90 dias de haber sido inactivado
						
						DateTime fechaInactividad = ObtenerFechaInactividad(item.VendedorId);
						TimeSpan diferencia = DateTime.Now - fechaInactividad;
						int dias = diferencia.Days;

						if (dias < 90)
						{
							rMsg = "El vendedor tiene menos de 90 días de haber pertenecido a un DAC.";
							itemVendedorExistente = itemVendedor;
						}
						else
						{
							item.EstadoId = "05";
							item.Nombre = itemVendedor.Nombre;
							item.FechaNacimiento = itemVendedor.FechaNacimiento;
							resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);

							if ( sEstado > 0 )
							{
								rMsg = "El vendedor ha sido reasignado a este DAC.";
							}
							
						}

						//Artificio para evaluacion de devolucion de datos y ponerlos inactivos
						item.VendedorId = vendedorIdEnviado;
					}
					else if (itemVendedor.EstadoId == "07")
					{
						rMsg = "El vendedor se encuentra de BAJA.";
						itemVendedorExistente = itemVendedor;
					}
					else
					{
						rMsg = "El vendedor ya se encuentra registrado.";
						itemVendedorExistente = itemVendedor;
					}
				}
					//Vendedor enviado como actualizacion
				else
				{
					//Si es actualizacion normal verificar que el dni nuevo no este en bd
					oConsulta =	ListaVendedor(item,"4",item.distribuidorId,"","","");
					if (oConsulta.Count == 0)
					{
						resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);					
					}
					else
					{
						itemVendedor = (Vendedor)oConsulta[0];
						if (item.VendedorId == itemVendedor.VendedorId)
						{
							if (item.EstadoId == "04")
							{
								//Validar que cuando sea quiera inactivar el vendedor ya debe haber estado habilitado alguna vez
								if(verificarInactivarVendedor(item.VendedorId))
								{
									resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);
								}
								else
								{
									rMsg = "El vendedor no ha pertenecido a ningún DAC. No se puede inactivar.";
									itemVendedorExistente = itemVendedor;
								}
							}
							else
							{
								resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);
							}
						}
						else
						{
							rMsg = "El DNI ya se encuentra registrado.";
							itemVendedorExistente = itemVendedor;
						}
					}
				}

				if (resultado != true)
				{
					if (rMsg.Equals(""))
						rMsg = "Error al Actualizar al Vendedor.";
				}
				else
				{
					if (rMsg.Equals(""))
						rMsg = "Los Datos se Grabaron Satisfactoriamente.";
				}

			}	
			
			sEstado = usuarioId;						
			return resultado;
		}
		public ArrayList ListaEstadosHabilitados(string cod_perfil, string cod_estado)
		{			
			
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("K_PERFIL", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_COD_ESTADO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			int j = 0;
			arrParam[j].Value = cod_perfil;
			j++; arrParam[j].Value = cod_estado;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_LISTA_EST_HAB";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					Estado item = new Estado();
					item.ESTAC_CODIGO = Funciones.CheckStr(dr["ESTAC_CODIGO"]);
					item.ESTAV_DESCRIPCION = Funciones.CheckStr(dr["ESTAV_DESCRIPCION"]);
					item.Estado_ID = Funciones.CheckInt64(dr["ESTAC_ESTADO"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
			
		}
		public ArrayList ListaVendedor(Vendedor itemU, string flgBuscar, string dacId, string perfil, string FlagFortelCadena, string codgrupo)
		{			
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_VEN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_VEN_NOMBRES", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_DAC_ACT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_NUM_DOC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PERFIL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_PTO_ACT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_FORTEL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_GRUPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = itemU.VendedorId;
			if(itemU.Nombre!="" && itemU.Nombre!=null)  
			{
				++i; arrParam[i].Value = itemU.Nombre;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			++i; arrParam[i].Value = flgBuscar;
			++i; arrParam[i].Value = itemU.Estado;
			if(dacId!="" && dacId!=null) 
			{
				++i; arrParam[i].Value = dacId;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			if(itemU.NumeroDocumento!="" && itemU.NumeroDocumento!=null) 
			{
				++i; arrParam[i].Value = itemU.NumeroDocumento;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			++i; arrParam[i].Value = perfil;
			++i; arrParam[i].Value = itemU.PuntoVentaId;
			++i; arrParam[i].Value = FlagFortelCadena;
			++i; arrParam[i].Value = codgrupo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_MANT_CON_VENDEDORES";
			//obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_CON_VENDEDORES_PDV";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())		
				{
					Vendedor item = new Vendedor();
					item.VendedorId = Funciones.CheckInt(dr["VEN_CODIGO"]);
					item.Nombre = Funciones.CheckStr(dr["VEN_NOMBRES"]);
					item.distribuidorId = Funciones.CheckStr(dr["VEN_DAC_ACT"]);
					item.TipoDocumento= Funciones.CheckStr(dr["VEN_TIPO_DOC"]);
					item.NumeroDocumento= Funciones.CheckStr(dr["VEN_NUM_DOC"]);
					item.Direccion = Funciones.CheckStr(dr["VEN_DIRECCION"]);
					item.FechaNacimiento = Funciones.CheckStr(dr["VEN_FEC_NAC"]);
					item.PuntoVentaId= Funciones.CheckStr(dr["VEN_PTO_ACT"]);
					item.FechaRegistro= Funciones.CheckStr(dr["VEN_FEC_REG"]);
					item.FechaModificacion= Funciones.CheckStr(dr["VEN_FEC_MOD"]);
					item.EstadoId = Funciones.CheckStr(dr["VEN_ESTADO"]);
					item.VerificacionReniec = Funciones.CheckStr(dr["VEN_VER_REN"]);
					item.DistribuidorDescripcion = Funciones.CheckStr(dr["DISTRIBUIDOR"]);
					item.NumeroCelular = Funciones.CheckStr(dr["VEN_NUME_CELU"]);
					item.Prov_exter = Funciones.CheckStr(dr["PARAV_DESCRIPCION"]);
					
					if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "01")
					{
						item.EstadoDescripcion = ConfigurationSettings.AppSettings["CONS_ESTADO_NUEVO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "02")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_HABILITADO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "03")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_DESHABILITADO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "04")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACTIVO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "05")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACT_ASIGNADO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "06")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACT_BAJA"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "07")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_BAJA"];
					}
					else
					{
						item.EstadoDescripcion  = "";
					}
					filas.Add(item);
				}				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		
		public ArrayList ListaVendedorExt(Vendedor itemU, string flgBuscar, string dacId, string perfil, string FlagFortelCadena, string Pexterno, string codgrupo)
		{			
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_VEN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_VEN_NOMBRES", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_DAC_ACT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_NUM_DOC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PERFIL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_PTO_ACT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_FORTEL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROV_EXT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_GRUPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = itemU.VendedorId;
			if(itemU.Nombre!="" && itemU.Nombre!=null)  
			{
				++i; arrParam[i].Value = itemU.Nombre;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			++i; arrParam[i].Value = flgBuscar;
			++i; arrParam[i].Value = itemU.Estado;
			if(dacId!="" && dacId!=null) 
			{
				++i; arrParam[i].Value = dacId;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			if(itemU.NumeroDocumento!="" && itemU.NumeroDocumento!=null) 
			{
				++i; arrParam[i].Value = itemU.NumeroDocumento;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			++i; arrParam[i].Value = perfil;
			++i; arrParam[i].Value = itemU.PuntoVentaId;
			++i; arrParam[i].Value = FlagFortelCadena;

			++i; arrParam[i].Value = Pexterno;
			++i; arrParam[i].Value = codgrupo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_MANT_CON_VENDEDOR_EXT";
			//obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_CON_VENDEDORES_PDV";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())		
				{
					Vendedor item = new Vendedor();
					item.VendedorId = Funciones.CheckInt(dr["VEN_CODIGO"]);
					item.Nombre = Funciones.CheckStr(dr["VEN_NOMBRES"]);
					item.distribuidorId = Funciones.CheckStr(dr["VEN_DAC_ACT"]);
					item.TipoDocumento= Funciones.CheckStr(dr["VEN_TIPO_DOC"]);
					item.NumeroDocumento= Funciones.CheckStr(dr["VEN_NUM_DOC"]);
					item.Direccion = Funciones.CheckStr(dr["VEN_DIRECCION"]);
					item.FechaNacimiento = Funciones.CheckStr(dr["VEN_FEC_NAC"]);
					item.PuntoVentaId= Funciones.CheckStr(dr["VEN_PTO_ACT"]);
					item.FechaRegistro= Funciones.CheckStr(dr["VEN_FEC_REG"]);
					item.FechaModificacion= Funciones.CheckStr(dr["VEN_FEC_MOD"]);
					item.EstadoId = Funciones.CheckStr(dr["VEN_ESTADO"]);
					item.VerificacionReniec = Funciones.CheckStr(dr["VEN_VER_REN"]);
					item.DistribuidorDescripcion = Funciones.CheckStr(dr["DISTRIBUIDOR"]);
					item.NumeroCelular = Funciones.CheckStr(dr["VEN_NUME_CELU"]);
					item.Prov_exter = Funciones.CheckStr(dr["PARAV_DESCRIPCION"]);
					
					if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "01")
					{
						item.EstadoDescripcion = ConfigurationSettings.AppSettings["CONS_ESTADO_NUEVO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "02")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_HABILITADO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "03")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_DESHABILITADO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "04")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACTIVO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "05")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACT_ASIGNADO"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "06")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACT_BAJA"];
					}
					else if (Funciones.CheckStr(dr["VEN_ESTADO"]) == "07")
					{
						item.EstadoDescripcion  = ConfigurationSettings.AppSettings["CONS_ESTADO_BAJA"];
					}
					else
					{
						item.EstadoDescripcion  = "";
					}
					filas.Add(item);
				}				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
		
		
		public bool InsertarVendedor(Vendedor item , ref int sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {															
				new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output),
				new DAABRequest.Parameter("PO_CODIGO", DbType.Int64, ParameterDirection.Output),
				new DAABRequest.Parameter("PO_DESCRIPCION", DbType.String, ParameterDirection.Output),
				new DAABRequest.Parameter("P_VEN_NOMBRES", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_TIPO_DOC", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_NUM_DOC", DbType.String, ParameterDirection.Input),												   				   
				new DAABRequest.Parameter("P_VEN_DIRECCION", DbType.String, ParameterDirection.Input),												   				   
				new DAABRequest.Parameter("P_VEN_FEC_NAC", DbType.DateTime, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_ESTADO", DbType.String, ParameterDirection.Input),												   				   
				new DAABRequest.Parameter("P_VEN_DAC_ACT", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_USU_REG", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_PTO_ACT", DbType.String, ParameterDirection.Input),												   
				new DAABRequest.Parameter("P_VEN_NUM_CEL", DbType.String, ParameterDirection.Input)
			}; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			i=3; arrParam[i].Value = item.Nombre;
			++i; arrParam[i].Value = item.TipoDocumento;
			++i; arrParam[i].Value = item.NumeroDocumento;
			++i; arrParam[i].Value = item.Direccion;
			++i; arrParam[i].Value = item.FechaNacimiento;
			++i; arrParam[i].Value = item.Estado;
			++i; arrParam[i].Value = item.distribuidorId;
			++i; arrParam[i].Value = item.UsuarioRegistroId;
			++i; arrParam[i].Value = item.PuntoVentaId;			
			++i; arrParam[i].Value = item.NumeroCelular;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSI_MANT_INS_VENDEDORES";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sEstado = Funciones.CheckInt(parSalida1.Value);

				int codigo;

				IDataParameter parSalida2;				
				parSalida2 = (IDataParameter)obRequest.Parameters[1];
				codigo = Funciones.CheckInt(parSalida2.Value);

				String descripcion;
				IDataParameter parSalida3;				
				parSalida3 = (IDataParameter)obRequest.Parameters[2];
				descripcion = Funciones.CheckStr(parSalida3.Value);

				//if(codigo == 1)
				//{
					//rMsg = "Linea Pertenece a otro Vendedor:"+descripcion;
				//	rMsg = "El número de línea del promotor existe para otro promotor o es un número de RED de un PDV, verifique la información ingresada";
				//}

				if(codigo == 3)
				{
					rMsg = ConfigurationSettings.AppSettings.Get("MsgErrorProveedorExternoOficina").ToString().Replace("{0}", descripcion);
				}
				else if(codigo == 4)
				{
					rMsg = ConfigurationSettings.AppSettings.Get("MsgErrorProveedorExternoVendedor").ToString().Replace("{0}", descripcion);
				}

				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
		// T12618 - Implementación módulo vendedores 05/2009 INICIO
		public DateTime ObtenerFechaInactividad(long codigoVendedor)
		{			
			DateTime fecha = new DateTime();

			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_VEN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)}; 
			arrParam[0].Value = codigoVendedor;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_FECHA_INACTIVIDAD";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					fecha = Funciones.CheckDate(dr["FECHA"]);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return fecha;
		}
		// T12618 - Implementación módulo vendedores 05/2009 FIN

		public bool ActualizarVendedor(Vendedor item, ref int sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
				new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output),
				new DAABRequest.Parameter("PO_CODIGO", DbType.Int64, ParameterDirection.Output),
				new DAABRequest.Parameter("PO_DESCRIPCION", DbType.String, ParameterDirection.Output),

				new DAABRequest.Parameter("P_VEN_CODIGO", DbType.Int64, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_NOMBRES", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_TIPO_DOC", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_NUM_DOC", DbType.String, ParameterDirection.Input),												   				   
				new DAABRequest.Parameter("P_VEN_DIRECCION", DbType.String, ParameterDirection.Input),												   				   
				new DAABRequest.Parameter("P_VEN_FEC_NAC", DbType.DateTime, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_ESTADO", DbType.String, ParameterDirection.Input),												   				   
				new DAABRequest.Parameter("P_VEN_DAC_ACT", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_USU_MOD", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VER_RENIEC", DbType.Int64, ParameterDirection.Input),
				new DAABRequest.Parameter("P_MOTIVO", DbType.String, 500, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_PTO_ACT", DbType.String, 20, ParameterDirection.Input),
				new DAABRequest.Parameter("P_VEN_NUM_CEL", DbType.String, ParameterDirection.Input)
			}; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=3; arrParam[i].Value = item.VendedorId;
			++i; arrParam[i].Value = item.Nombre;
			++i; arrParam[i].Value = item.TipoDocumento;
			++i; arrParam[i].Value = item.NumeroDocumento;
			++i; arrParam[i].Value = item.Direccion;
			++i; arrParam[i].Value = item.FechaNacimiento;
			++i; arrParam[i].Value = item.EstadoId;
			++i; arrParam[i].Value = item.distribuidorId;
			++i; arrParam[i].Value = item.UsuarioModificacionId;
			++i; arrParam[i].Value = item.VerificacionReniec;
			++i; arrParam[i].Value = item.Motivo;
			++i; arrParam[i].Value = item.PuntoVentaId;
			++i; arrParam[i].Value = item.NumeroCelular;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSU_MANT_ACT_VENDEDORES";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Actualizar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sEstado = Funciones.CheckInt(parSalida1.Value);
				
				int codigo;
				IDataParameter parSalida2;				
				parSalida2 = (IDataParameter)obRequest.Parameters[1];
				codigo = Funciones.CheckInt(parSalida2.Value);

				String descripcion;
				IDataParameter parSalida3;				
				parSalida3 = (IDataParameter)obRequest.Parameters[2];
				descripcion = Funciones.CheckStr(parSalida3.Value);

				//if(codigo == 1)
				//{
					//rMsg = "Linea Pertenece a otro Vendedor:"+descripcion;

				//	rMsg = "El número de línea del promotor existe para otro promotor o es un número de RED de un PDV, verifique la información ingresada";
				//}

				if(codigo == 3)
				{
					rMsg = ConfigurationSettings.AppSettings.Get("MsgErrorProveedorExternoOficina").ToString().Replace("{0}", descripcion);
				}
				else if(codigo == 4)
				{
					rMsg = ConfigurationSettings.AppSettings.Get("MsgErrorProveedorExternoVendedor").ToString().Replace("{0}", descripcion);
				}

				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
		public bool verificarInactivarVendedor(long vendedorId)
		{			
			bool haSidoActivado = false;

			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_ID_VEN", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)}; 
			arrParam[0].Value = vendedorId;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_VERIF_INACTIVAR_VEN";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					if (Funciones.CheckInt(dr["HABILITADO"]) > 0)
					{
						haSidoActivado = true;
					}
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return haSidoActivado;
		}
		public string ObtenerDistribuidorUsuario(string distribuidorId)
		{			
			string distribuidor = "";

			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_COD_DISTRIBUIDOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)}; 
			arrParam[0].Value = distribuidorId;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_OBTENER_DISTRIBUIDOR";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					distribuidor = Funciones.CheckStr(dr["DISTRIBUIDOR"]);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return distribuidor;
		}

		/*Ublanco*/
		public int GuardarLprecioPacuerdo(string p_datos, string p_usuario){
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DATOS", DbType.String,100000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA", DbType.Int32, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = p_datos;
			arrParam[1].Value = p_usuario;

			int retorno = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SP_INSERT_CARGA_LP_PA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[2];				
				retorno = Funciones.CheckInt(parRetorno.Value);
			}
			catch( Exception ex )
			{				
				retorno = 0;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno;
		
		}

		public ArrayList ListaPlazoAcuerdo()
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 		
			
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SP_LIST_PLAZOACUERDO";
			obRequest.Parameters.AddRange(arrParam);
		
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["PACUC_CODIGO"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public int ListarCantidadRegLpPa()
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("TOTALREG", DbType.Int32, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			int retorno = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SP_LIST_CANT_LPRECIO_PACU";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[0];				
				retorno = Funciones.CheckInt(parRetorno.Value);
			}
			catch( Exception ex )
			{				
				retorno = 0;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno;
		
		}

		public ArrayList ListalprecioPacuerdo(string numInsert)
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_NUMINSER", DbType.String,100000,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DATOS", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			if (numInsert != null && numInsert != "" ) arrParam[0].Value = numInsert;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SP_LIST_LPRECIO_PACUERDO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Descripcion= Funciones.CheckStr(dr["DATOS"]);
					item.orden = Funciones.CheckInt(dr["SECUENCIAL"]);					
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaAsociacionCampana(string id, string cod_producto, string fecha_inicio, string fecha_fin, string nombre)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output),												   
												   new DAABRequest.Parameter("P_ID", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_INICIO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_FIN", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRODUCTO", DbType.String,ParameterDirection.Input)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if (id != null && id.Length != 0) arrParam[1].Value = Funciones.CheckInt(id);
			if (nombre != null && nombre.Length != 0) arrParam[2].Value = nombre;
			if (fecha_inicio != null && fecha_inicio.Length != 0) arrParam[3].Value = fecha_inicio;
			if (fecha_fin != null && fecha_fin.Length != 0) arrParam[4].Value = fecha_fin;
			if (cod_producto != null && cod_producto.Length != 0) arrParam[5].Value = cod_producto;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO+ ".SISACT_CON_ASOCIACION_CAMPANA";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					AsociacionCampana objAC = new AsociacionCampana();
					objAC.COD_ASOCIACION = Funciones.CheckStr(dr["ID"]);
					objAC.CAMPANA_PADRE = Funciones.CheckStr(dr["CAMPANA_PADRE"]);
					objAC.CAMPANA_HIJA = Funciones.CheckStr(dr["CAMPANA_HIJA"]);
					objAC.TIPO_PRODUCTO_HIJA = Funciones.CheckStr(dr["TIPO_PRODUCTO_HIJA"]);
					objAC.TIPO_PRODUCTO_PADRE = Funciones.CheckStr(dr["TIPO_PROD_PADRE"]);
					objAC.DESCRIPCION = Funciones.CheckStr(dr["DESCRIPCION"]);
					objAC.FECHA_INICIO = Funciones.CheckDate(dr["FECHA_INICIO"]);
					objAC.FECHA_FIN = Funciones.CheckDate(dr["FECHA_FIN"]);
					objAC.ESTADO = Funciones.CheckStr(dr["ESTADO"]);

					filas.Add(objAC);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}	

		public bool GrabarAsociacionCampana(AsociacionCampana objAsocCampana)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CAMPANA_PADRE", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA_HIJA", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO_PADRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO_HIJA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 500, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_INICIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_FIN", DbType.String, ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=1; arrParam[i].Value = objAsocCampana.CAMPANA_PADRE;
			++i; arrParam[i].Value = objAsocCampana.CAMPANA_HIJA;
			++i; arrParam[i].Value = objAsocCampana.TIPO_PRODUCTO_PADRE;
			++i; arrParam[i].Value = objAsocCampana.TIPO_PRODUCTO_HIJA;
			++i; arrParam[i].Value = objAsocCampana.DESCRIPCION;
			++i; arrParam[i].Value = String.Format("{0:dd/MM/yyyy}",objAsocCampana.FECHA_INICIO);
			++i; arrParam[i].Value = String.Format("{0:dd/MM/yyyy}",objAsocCampana.FECHA_FIN);

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".SISACT_INS_ASOCIACION_CAMPANA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				//rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				//sEstado = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarAsociacionCampana(int vID)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_ID", DbType.Int64, ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=1; arrParam[i].Value = vID;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".SISACT_DEL_ASOCIACION_CAMPANA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				//rMsg = "Error al Eliminar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				//sEstado = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool ActualizarAsociacionCampana(AsociacionCampana objAsocCampana)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_ID", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_FIN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, ParameterDirection.Input)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=1; arrParam[i].Value = objAsocCampana.COD_ASOCIACION;
			++i; arrParam[i].Value = String.Format("{0:dd/MM/yyyy}",objAsocCampana.FECHA_FIN);
			++i; arrParam[i].Value = objAsocCampana.ESTADO;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".SISACT_UPD_ASOCIACION_CAMPANA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				//rMsg = "Error al Actualizar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public ArrayList ListaCampana(string cod_producto)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output),												   
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String,ParameterDirection.Input)

			}; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[1].Value = cod_producto;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO+ ".SISACT_CON_CAMPANA";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					AsociacionCampana objAC = new AsociacionCampana();
					objAC.COD_ASOCIACION = Funciones.CheckStr(dr["COD"]);
					objAC.CAMPANA_PADRE = Funciones.CheckStr(dr["DESC"]);

					filas.Add(objAC);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}	

		public ArrayList ListadoTopeConsumo()
		{                 
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)};
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_TOPE_CONSUMO";
			
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					TopeConsumo item = new TopeConsumo();
					item.CODIGO = Funciones.CheckStr(dr["TPCON_CODIGO"]);                          
					item.NOMBRE = Funciones.CheckStr(dr["TPCOV_NOMBRE"]);
					item.CARGO_FIJO = Funciones.CheckDbl(dr["TPCON_CARGO_FIJO"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListadoPlazoAcuerdo()
		{                 
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)};
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_CONS_2 + ".SISACT_LISTAR_PLAZOACUERDO";
			
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["PACUC_CODIGO"]);                          
					item.Descripcion = Funciones.CheckStr(dr["PACUV_DESCRIPCION"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}	
	
		public DataTable listarTipProdMensaje(string pstrDescripcion, string pstrCodigo, string pstrCodTipoCli)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCLI", DbType.String, 50, ParameterDirection.Input)								   

											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrCodTipoCli;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_LISTAR_TIPOPROD_MSJ";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable listarTipoProducto()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_LISTAR_TIPO_PRODUCTO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public bool insertarTipoProdMsj(string pstrCodigo, string pstrCodCorreo, string pstrCodApp, string pstrCodTipoCli)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCORREO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODAPP", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCLI", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrCodCorreo;
			arrParam[2].Value = pstrCodApp;
			arrParam[3].Value = pstrCodTipoCli;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_INSERT_PRODUCTO_MSJ";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool modificarTipoProdMsj(string pstrCodigo, string pstrCodCorreo, string pstrCodApp, string pstrCodTipoCli)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCORREO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODAPP", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCLI", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrCodCorreo;
			arrParam[2].Value = pstrCodApp;
			arrParam[3].Value = pstrCodTipoCli;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_UPDATE_PRODUCTO_MSJ";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool eliminarTipoProdMsj(string pstrCodigo, string pstrCodTipoCli)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODCLI", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrCodTipoCli;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_DELETE_PRODUCTO_MSJ";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public DataTable listarTipoCliente()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_LISTAR_TIPO_CLIENTE";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable listarServXEquipo(string pstrDescripcion,Int64 pstrPaquete, Int64 pstrServicio)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQUETE", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVICIO", DbType.Int64, ParameterDirection.Input)								   

											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;

			i++;arrParam[1].Value = pstrDescripcion;
			i++;if (pstrPaquete != 0) { arrParam[i].Value = pstrPaquete; }
			i++;if (pstrServicio != 0) { arrParam[i].Value = pstrServicio; }
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_LISTAR_SERV_EQUIPO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public bool insertarServEquipos(string pstrCabecera, string pstrEquipos)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CABECERA", DbType.String, 8000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EQUIPO", DbType.String, 8000, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCabecera;
			arrParam[1].Value = pstrEquipos;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_INSERT_SERV_EQUIPO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public DataTable listarEquipos(string pstrCodGrupo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODGRUPO", DbType.String, 50, ParameterDirection.Input)							   

											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;

			i++;arrParam[1].Value = pstrCodGrupo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_LISTAR_EQUIP0S";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public bool actualizarServEquipos(string pstrCodigo, string pstrEquipos, string pstrEstado)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int64 , ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EQUIPO", DbType.String, 8000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 5, ParameterDirection.Input)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCodigo;
			if(pstrEquipos != ""){arrParam[1].Value = pstrEquipos;}
			arrParam[2].Value = pstrEstado;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_UPDATE_SERV_EQUIPO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool eliminarServEquipos(string pstrCodigo)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int64 , ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_DELETE_SERV_EQUIPO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

                public ArrayList ObtenerTipoDocumentosPVU(string p_tipo_doc, string p_estado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TDOCC_CODIGO",DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TDOCC_ESTADO",DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (p_tipo_doc != "") { arrParam[i].Value = p_tipo_doc; }
			++i; if (p_estado != "") { arrParam[i].Value = p_estado; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_LISTA_TIPO_DOCS_PVU";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					TipoDocumento item = new TipoDocumento();
					item.TDOCC_CODIGO = Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.TDOCV_DESCRIPCION = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);
					item.TDOCC_ESTADO = Funciones.CheckStr(dr["TDOCC_ESTADO"]);
					item.ID_BSCS = Funciones.CheckInt(dr["ID_BSCS"]);
					item.ID_INFOCORP = Funciones.CheckInt(dr["ID_INFOCORP"]);
					item.ID_ABDCP = Funciones.CheckStr(dr["ID_ABDCP"]);
					item.ID_DC_CORP = Funciones.CheckStr(dr["ID_DC_CORP"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public int validoPdvCliente_BlackList( string vCodCanal, string vCodPdv) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_COD_CANAL", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_PDV", DbType.String,10,ParameterDirection.Input)
											   }; 
			
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0;		
			arrParam[1].Value = vCodCanal;
			arrParam[2].Value = vCodPdv;
						
			int retorno = 0;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest  = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Transactional = true;
							
			obRequest.Parameters.Clear();
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACT_GET_BL_PDVUSUARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{
				obRequest.Factory.RollBackTransaction();		
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				retorno = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
			return retorno;	
		}

		public string ListaPrefijosApellidoCompuesto()
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)}; 

			arrParam[0].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SISACT_LIST_PREFIJO_APELLIDO";
			obRequest.Parameters.AddRange(arrParam);
			
			string cadTokens = "";
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					if(cadTokens.Length == 0)
						cadTokens = cadTokens + Funciones.CheckStr(dr["PREFIJOAP"]);
					else
						cadTokens = cadTokens + "," + Funciones.CheckStr(dr["PREFIJOAP"]);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return cadTokens;			
		}

		//DRC ListaVendedorClave
		public ArrayList ListaVendedorClave(Vendedor itemU, string flgBuscar)
		{			
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_FLAG_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_PDV", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_NOMB", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_NUME_DOCU", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("O_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 

			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = flgBuscar;
			++i; arrParam[i].Value = itemU.PuntoVentaId;
			if(itemU.Nombre!="" && itemU.Nombre!=null)  
			{
				++i; arrParam[i].Value = itemU.Nombre;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			if(itemU.NumeroDocumento!="" && itemU.NumeroDocumento!=null) 
			{
				++i; arrParam[i].Value = itemU.NumeroDocumento;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENDEDOR_SEGURIDAD + ".SISACSS_VENDEDOR_CLAVE";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())		
				{
					Vendedor item = new Vendedor();
					item.NumeroDocumento= Funciones.CheckStr(dr["VEN_NUME_DOCU"]);
					item.Nombre = Funciones.CheckStr(dr["VEN_NOMB"]);			
					item.NumeroCelular = Funciones.CheckStr(dr["VEN_NUME_CELU"]);
					item.FechaModificacion= Funciones.CheckStr(dr["VEN_FECH_MODI"]);					
					item.EstadoId = Funciones.CheckStr(dr["VEN_ESTA"]);					
					filas.Add(item);
				}				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
		

		public ArrayList ListaVendedorClavePro(Vendedor itemU, string flgBuscar, string prove)
		{			
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_FLAG_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_PDV", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_NOMB", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_NUME_DOCU", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OVENC_PRO_EXT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("O_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 

			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = flgBuscar;
			++i; arrParam[i].Value = itemU.PuntoVentaId;
			if(itemU.Nombre!="" && itemU.Nombre!=null)  
			{
				++i; arrParam[i].Value = itemU.Nombre;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			if(itemU.NumeroDocumento!="" && itemU.NumeroDocumento!=null) 
			{
				++i; arrParam[i].Value = itemU.NumeroDocumento;
			}
			else
			{
				++i; arrParam[i].Value = "";
			}
			++i; arrParam[i].Value = prove;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENDEDOR_SEGURIDAD + ".SISACSS_VENDEDOR_CLAVEPRO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())		
				{
					Vendedor item = new Vendedor();
					item.NumeroDocumento= Funciones.CheckStr(dr["VEN_NUME_DOCU"]);
					item.Nombre = Funciones.CheckStr(dr["VEN_NOMB"]);			
					item.NumeroCelular = Funciones.CheckStr(dr["VEN_NUME_CELU"]);
					item.FechaModificacion= Funciones.CheckStr(dr["VEN_FECH_MODI"]);					
					item.EstadoId = Funciones.CheckStr(dr["VEN_ESTA"]);					
					filas.Add(item);
				}				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public bool ActualizarVendedorClave(Vendedor item, ref int sEstado, ref string rMsg)
		{	

			DAABRequest.Parameter[] arrParam = {				
												   new DAABRequest.Parameter("P_VEN_NUME_DOCU", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_PDV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_CLAV_ACTU", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_USUA_MODI", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("O_RESULTADO", DbType.Int64, ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0; arrParam[i].Value = item.NumeroDocumento;
			++i; arrParam[i].Value = item.PuntoVentaId;
			++i; arrParam[i].Value = item.Clave;
			++i; arrParam[i].Value = item.UsuarioModificacionId;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENDEDOR_SEGURIDAD + ".SISACSU_VENDEDOR_CLAVE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Actualizar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[4];
				sEstado = Funciones.CheckInt(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public ArrayList ListaBuscarOficinaVenta(string busquedaPDV, string flagBuscar, string tipoPDV, string codgrupo)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PDV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_GRUPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = busquedaPDV;
			++i; arrParam[i].Value = flagBuscar;
			++i; arrParam[i].Value = tipoPDV;
			++i; arrParam[i].Value = codgrupo;		
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_BUSCAR_OFICINA_VENTA";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					PuntoVenta item = new PuntoVenta();
					item.OVENC_CODIGO = Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					item.TOFIC_CODIGO = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					item.TOFIV_DESCRIPCION = Funciones.CheckStr(dr["TOFIV_DESCRIPCION"]);
					item.PROV_EXTERNO = Funciones.CheckStr(dr["PARAV_DESCRIPCION"]);

					if (Funciones.CheckStr(dr["OVENC_ESTADO"]) == "1")
						item.OVENC_ESTADO  = ConfigurationSettings.AppSettings["CONS_ESTADO_ACTIVO"];
					else
						item.OVENC_ESTADO  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACTIVO"];

					filas.Add(item);
				}				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		public ArrayList ListaOficinaVentaPro(string busquedaPDV, string flagBuscar, string tipoPDV, string codigo, string codgrupo)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_BUSQUEDA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PDV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_GRUPO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = busquedaPDV;
			++i; arrParam[i].Value = flagBuscar;
			++i; arrParam[i].Value = tipoPDV;
			++i; arrParam[i].Value = codigo;	
			++i; arrParam[i].Value = codgrupo;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACSS_LISTAR_OFICINA_VENTA";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					PuntoVenta item = new PuntoVenta();
					item.OVENC_CODIGO = Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					item.TOFIC_CODIGO = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					item.TOFIV_DESCRIPCION = Funciones.CheckStr(dr["TOFIV_DESCRIPCION"]);
					item.PROV_EXTERNO = Funciones.CheckStr(dr["PARAV_DESCRIPCION"]);

					if (Funciones.CheckStr(dr["OVENC_ESTADO"]) == "1")
						item.OVENC_ESTADO  = ConfigurationSettings.AppSettings["CONS_ESTADO_ACTIVO"];
					else
						item.OVENC_ESTADO  = ConfigurationSettings.AppSettings["CONS_ESTADO_INACTIVO"];

					filas.Add(item);
				}				
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
		public bool insertarIDValidatorList(string P_TIPO_DOC, string P_NRO_DOC, string P_NOMBRE, string P_VIGE_INDEF, Int32 P_VIGE_DIAS, string P_TIPO_LISTA, string P_USUARIO)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 250, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGE_INDEF", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGE_DIAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_LISTA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 250, ParameterDirection.Input),
			};

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;
			
			arrParam[i].Value = P_TIPO_DOC;
			i++;arrParam[i].Value = P_NRO_DOC;
			i++;arrParam[i].Value = P_NOMBRE;
			i++;arrParam[i].Value = P_VIGE_INDEF;
			i++;arrParam[i].Value = P_VIGE_DIAS;
			i++;arrParam[i].Value = P_TIPO_LISTA;
			i++;arrParam[i].Value = P_USUARIO;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_INSERT_LISTAS_IDV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
		
		public bool actualizarIDValidatorList(string P_CODIGO, string P_VIGE_INDEF, Int32 P_VIGE_DIAS, string P_NOMBRE, string P_USUARIO)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGE_INDEF", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGE_DIAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 200, ParameterDirection.Input)
											   };

			
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;

			arrParam[i].Value = P_CODIGO;
			i++;arrParam[i].Value = P_VIGE_INDEF;
			i++;arrParam[i].Value = P_VIGE_DIAS;
			i++;arrParam[i].Value = P_NOMBRE;
			i++;arrParam[i].Value = P_USUARIO;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_UPDATE_LISTAS_IDV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		
		public DataTable listarIDValidatorList(string pstrDNI, string pstrFchaIni, 
			string pstrFchaFin, string pstrTipoList, string pstrTipoDoc, Int32 pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NRODNI", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHAINI", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHAFIN", DbType.String, 15, ParameterDirection.Input),								   
												   new DAABRequest.Parameter("P_TIPOLIST", DbType.String, 5, ParameterDirection.Input),								   
												   new DAABRequest.Parameter("p_TIPODOC", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input)								   
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;

			i++;arrParam[i].Value = pstrDNI;
			i++;arrParam[i].Value = pstrFchaIni;
			i++;arrParam[i].Value = pstrFchaFin;
			i++; arrParam[i].Value = pstrTipoList;
			i++; if(!pstrTipoDoc.Equals("00")) arrParam[i].Value = pstrTipoDoc;
			i++; if(pstrCodigo != 0) arrParam[i].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSS_CONS_LISTAS_IDV";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}
		
		public bool eliminarSeleccionadosIDValidator(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SECUENCIAS", DbType.String, 32767, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = DBNull.Value;

			if (strSeleccionados.Length > 0)
				arrParam[1].Value = strSeleccionados;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".MANTSM_ELISEL_LISTAS_IDV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				pstrMsg = "Error al Eliminar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				pstrEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public int CargaMasivaIDValidatorList(string pstrdatos, ref string pstrErrores)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DATOS", DbType.String, 32767, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSJERROR", DbType.String,4000, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrdatos;

			int retorno = 0;
			string retorno2 = "";
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".SP_INSERT_CARGA_IDV";
			
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[1];				
				retorno = Funciones.CheckInt(parRetorno.Value);

				IDataParameter parRetorno2;
				parRetorno2 = (IDataParameter)obRequest.Parameters[2];				
				retorno2 = Funciones.CheckStr(parRetorno2.Value);
				pstrErrores = retorno2;
			}
			catch( Exception ex )
			{				
				retorno = 0;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno;
		}


		public DataTable listarEdificio(string pstrDepartamento, string pstrProvincia, 
										string pstrDistrito, string pstrDireccion, string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DEPARTAMENTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROVINCIA", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DISTRITO", DbType.String, 4, ParameterDirection.Input),								   
												   new DAABRequest.Parameter("P_DIRECCION", DbType.String, 250, ParameterDirection.Input),								   
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 250, ParameterDirection.Input)								   
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;

			i++;arrParam[1].Value = pstrDepartamento;
			i++;arrParam[i].Value = pstrProvincia;
			i++;arrParam[i].Value = pstrDistrito;
			i++; arrParam[i].Value = pstrDireccion;
			i++; arrParam[i].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".MANTSS_LISTAR_EDIFICIO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public bool insertarEdificio(Edificio oEdificio)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DEPAC_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROVC_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DISTC_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFV_DIRECCION", DbType.String, 250, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFV_NODO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFV_DESCRIPCION", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFD_FECHA_ACTIV", DbType.DateTime, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFC_ESTADO", DbType.String, 10, ParameterDirection.Input)
											   };

			
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;

			arrParam[i].Value = oEdificio.DEPAC_CODIGO;
			i++;arrParam[i].Value = oEdificio.PROVC_CODIGO;
			i++;arrParam[i].Value = oEdificio.DISTC_CODIGO;
			i++;arrParam[i].Value = oEdificio.EDIFV_DIRECCION;
			i++;arrParam[i].Value = oEdificio.EDIFV_NODO;
			i++;arrParam[i].Value = oEdificio.EDIFV_DESCRIPCION;
			i++;arrParam[i].Value = oEdificio.EDIFD_FECHA_ACTIV;
			i++;arrParam[i].Value = oEdificio.EDIFC_ESTADO;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".MANTSS_INSERT_EDIFICIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool actualizarEdificio(Edificio oEdificio)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_EDIFV_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DEPAC_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROVC_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DISTC_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFV_DIRECCION", DbType.String, 250, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFV_NODO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFV_DESCRIPCION", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFD_FECHA_ACTIV", DbType.DateTime, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EDIFC_ESTADO", DbType.String, 10, ParameterDirection.Input)
											   };

			
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;

			arrParam[i].Value = oEdificio.EDIFV_CODIGO;
			i++;arrParam[i].Value = oEdificio.DEPAC_CODIGO;
			i++;arrParam[i].Value = oEdificio.PROVC_CODIGO;
			i++;arrParam[i].Value = oEdificio.DISTC_CODIGO;
			i++;arrParam[i].Value = oEdificio.EDIFV_DIRECCION;
			i++;arrParam[i].Value = oEdificio.EDIFV_NODO;
			i++;arrParam[i].Value = oEdificio.EDIFV_DESCRIPCION;
			i++;arrParam[i].Value = oEdificio.EDIFD_FECHA_ACTIV;
			i++;arrParam[i].Value = oEdificio.EDIFC_ESTADO;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".MANTSS_UPDATE_EDIFICIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool eliminarSeleccionadosEdificio(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SECUENCIAS", DbType.String, 32767, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = DBNull.Value;

			if (strSeleccionados.Length > 0)
				arrParam[1].Value = strSeleccionados;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".MANTSM_ELISEL_EDIFICIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				pstrMsg = "Error al Eliminar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				pstrEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public int CargaMasivaEdificio(string pstrdatos)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DATOS", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA", DbType.Int32, ParameterDirection.Output)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = pstrdatos;

			int retorno = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SP_INSERT_CARGA_EDIF";
			
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[1];				
				retorno = Funciones.CheckInt(parRetorno.Value);
			}
			catch( Exception ex )
			{				
				retorno = 0;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno;
		}

		#region "PROY 16359 - IDEA 19861"

		public bool ValidaNegocio(ref Vendedor item, ref string rMsg,ref string sAccion)
		{	
			bool resultado = false;
			ArrayList oConsulta;
			

			if (item.VendedorId == 0)
			{
				oConsulta =	ListaVendedor(item,"4",item.distribuidorId,"","","");
			}
			else
			{
				oConsulta =	ListaVendedor(item,"3",item.distribuidorId,"","","");
			}
			
			if (oConsulta.Count == 0)
			{
				//resultado = InsertarVendedor(item,ref sEstado,ref rMsg) ;
				//--------------------------VALIDACION CADENA Y LINEA----------------------//
				if (!ValidaOficinaCadena(item.NumeroCelular))
				{
					if (!ValidaLinea(item.NumeroCelular,item.VendedorId,"INSERTAR"))
					{
						sAccion = "INSERTAR";
						resultado = true;
					}
					else
					{
						rMsg = "El número de linea existente";
						resultado = false;
					}

				}
				else
				{
					rMsg = "El número de linea pertenece a otra oficina";
					resultado = false;
				}
				//--------------------------VALIDACION CADENA Y LINEA----------------------//
			}
			else
			{	
				Vendedor itemVendedor = new Vendedor();
				itemVendedor = (Vendedor)oConsulta[0];
				item.VendedorId = itemVendedor.VendedorId;

				//Vendedor enviado como nuevo pero ya existe el DNI
				if (item.VendedorId == 0)
				{
					if (itemVendedor.EstadoId == "04")
					{
						//Artificio para evaluacion de devolucion de datos y ponerlos inactivos
						//long vendedorIdEnviado = item.VendedorId;
						item.VendedorId = itemVendedor.VendedorId;
						
						//Validar si tiene mas de 90 dias de haber sido inactivado
						
						DateTime fechaInactividad = ObtenerFechaInactividad(item.VendedorId);
						TimeSpan diferencia = DateTime.Now - fechaInactividad;
						int dias = diferencia.Days;

						if (dias < 90)
						{	
							rMsg = "El vendedor tiene menos de 90 días de haber pertenecido a un DAC.";
							resultado = false;
						}
						else
						{
							item.EstadoId = "05";
							item.Nombre = itemVendedor.Nombre;
							item.FechaNacimiento = itemVendedor.FechaNacimiento;
							//resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);
							//--------------------------VALIDACION CADENA Y LINEA----------------------//
							if (!ValidaOficinaCadena(item.NumeroCelular))
							{
								if (!ValidaLinea(item.NumeroCelular,item.VendedorId,"ACTUALIZAR"))
								{
									sAccion = "ACTUALIZAR";
									resultado = true;
								}
								else
								{
									rMsg = "El número de linea existente";
									resultado = false;
								}

							}
							else
							{
								rMsg = "El número de linea pertenece a otra oficina";
								resultado = false;
							}
							//--------------------------VALIDACION CADENA Y LINEA----------------------//

						}

						//Artificio para evaluacion de devolucion de datos y ponerlos inactivos
						//item.VendedorId = vendedorIdEnviado;
					}
					else if (itemVendedor.EstadoId == "07")
					{
						rMsg = "El vendedor se encuentra de BAJA.";
						resultado = false;
					}
					else
					{
						rMsg = "El vendedor ya se encuentra registrado.";
						resultado = false;
					}
				}
					//Vendedor enviado como actualizacion
				else
				{
					//Si es actualizacion normal verificar que el dni nuevo no este en bd
					oConsulta =	ListaVendedor(item,"4",item.distribuidorId,"","","");
					if (oConsulta.Count == 0)
					{
						//resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);
						//--------------------------VALIDACION CADENA Y LINEA----------------------//
						if (!ValidaOficinaCadena(item.NumeroCelular))
						{
							if (!ValidaLinea(item.NumeroCelular,item.VendedorId,"ACTUALIZAR"))
							{
								sAccion = "ACTUALIZAR";
								resultado = true;
							}
							else
							{
								rMsg = "El número de linea existente";
								resultado = false;
							}

						}
						else
						{
							rMsg = "El número de linea pertenece a otra oficina";
							resultado = false;
						}
						//--------------------------VALIDACION CADENA Y LINEA----------------------//
					}
					else
					{
						itemVendedor = (Vendedor)oConsulta[0];
						if (item.VendedorId == itemVendedor.VendedorId)
						{
							if (item.EstadoId == "04")
							{
								//Validar que cuando sea quiera inactivar el vendedor ya debe haber estado habilitado alguna vez
								if(verificarInactivarVendedor(item.VendedorId))
								{
									//resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);
									//--------------------------VALIDACION CADENA Y LINEA----------------------//
									if (!ValidaOficinaCadena(item.NumeroCelular))
									{
										if (!ValidaLinea(item.NumeroCelular,item.VendedorId,"ACTUALIZAR"))
										{
											sAccion = "ACTUALIZAR";
											resultado = true;
										}
										else
										{
											rMsg = "El número de linea existente";
											resultado = false;
										}

									}
									else
									{
										rMsg = "El número de linea pertenece a otra oficina";
										resultado = false;
									}
									//--------------------------VALIDACION CADENA Y LINEA----------------------//
								}
								else
								{
									rMsg = "El vendedor no ha pertenecido a ningún DAC. No se puede inactivar.";
									resultado = false;
								}
							}
							else
							{
								//resultado = ActualizarVendedor(item, ref sEstado,ref rMsg);
								//--------------------------VALIDACION CADENA Y LINEA----------------------//
								if (!ValidaOficinaCadena(item.NumeroCelular))
								{
									if (!ValidaLinea(item.NumeroCelular,item.VendedorId,"ACTUALIZAR"))
									{
										sAccion = "ACTUALIZAR";
										resultado = true;
									}
									else
									{
										rMsg = "El número de linea existente";
										resultado = false;
									}
								}
								else
								{
									rMsg = "El número de linea pertenece a otra oficina";
									resultado = false;
								}
								//--------------------------VALIDACION CADENA Y LINEA----------------------//
							}
						}
						else
						{	
							rMsg = "El DNI ya se encuentra registrado.";
							resultado = false;
						}
					}
				}

			}
								
			return resultado;
		}
	
		public bool ValidaLinea(string sNumTelefono,long sCodVendedor,string sAccion) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_VEN_NUM_CEL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ACCION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0;arrParam[i].Value = sNumTelefono;
			i++;arrParam[i].Value = sCodVendedor;
			i++;arrParam[i].Value = sAccion;
	
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACTSS_VALIDA_LINEA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			int bb;
			try
			{
				bb=Convert.ToInt16(obRequest.Factory.ExecuteScalar(ref obRequest));
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				if(Funciones.CheckInt(parSalida1.Value) > 0)
					salida = true;
				obRequest.Factory.Dispose();
			}                 
			return salida ;
		}

		public bool ValidaOficinaCadena(string sNumTelefono) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_VEN_NUM_CEL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;arrParam[i].Value = sNumTelefono;

	
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACTSS_VALIDA_OFICINA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			int bb;
			try
			{
				bb=Convert.ToInt16(obRequest.Factory.ExecuteScalar(ref obRequest));
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				if(Funciones.CheckInt(parSalida1.Value) > 0)
					salida = true;
				obRequest.Factory.Dispose();
			}                 
			return salida ;
		}

		public int CargaMasiVendedor(string p_datos, string p_usuario,string p_cod_distribuidor)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DATOS", DbType.String,100000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VEN_DAC_ACT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPUESTA", DbType.Int32, ParameterDirection.Output)
											   };
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = p_datos;
			arrParam[1].Value = p_usuario;
			arrParam[2].Value = p_cod_distribuidor;

			int retorno = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SP_CARGA_MASI_VENDEDOR";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno;
				parRetorno = (IDataParameter)obRequest.Parameters[3];				
				retorno = Funciones.CheckInt(parRetorno.Value);
			}
			catch( Exception ex )
			{				
				retorno = 0;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno;
		
		}

		public bool ValidarTipoPDV(string tipoOficina,string codigoOficina , ref string rMsg) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TOFIC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int64, ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			i=0;arrParam[i].Value = tipoOficina;      
			i++;arrParam[i].Value = codigoOficina;
				
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SISACTSS_VALIDA_TIPO_OFICINA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			int bb;
			try
			{
				bb=Convert.ToInt16(obRequest.Factory.ExecuteScalar(ref obRequest));
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				if(Funciones.CheckInt(parSalida1.Value) > 0)
					salida = true;
				obRequest.Factory.Dispose();
			}                 
			return salida ;
		}

		
		#endregion 

	public ArrayList ListaMotivoRenovacionChip(string cod_operacion, string estado)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_moti_opera", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_moti_estado", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_result", DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_listado", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			
				arrParam[0].Value = cod_operacion;
		        arrParam[1].Value = estado;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + ".SISACT_MOTIVO_VENTA_CONS";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["moti_codigo"]);
					item.Descripcion = Funciones.CheckStr(dr["moti_descrip"]);
					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
	}
			return filas;
		}


//Inicio PROY-25335 - Contratación Electrónica - Release 0
		public bool RegistrarBiometriaGendoc(BEBiometria item)
		{	

			DAABRequest.Parameter[] arrParam = {				
												   new DAABRequest.Parameter("PI_NUM_PEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_NUM_SEC", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_TIP_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_NUM_DOCUMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_NUM_LINEA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_DSC_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_COD_RESPUESTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_FEC_OPERACION", DbType.DateTime, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_DSC_APLIC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_TIP_OPERACION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_COD_PDV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_COD_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_DSC_MODALIDAD", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_DEPARTAMENTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_LATITUD", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_LONGITUD", DbType.Decimal, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_TIP_DOCVEND", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_NUM_DOCVEND", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_COD_VEND", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_SER_LECTOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_NUM_ICCID", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_ID_PADRE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_COD_VENDSEC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_DSC_OBSERV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_USUARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("PO_COD_RESPUESTA", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("PO_MSJ_RESPUESTA", DbType.String, ParameterDirection.Output)
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0; arrParam[i].Value = item.GDOC_NROPEDIDO;
			++i; arrParam[i].Value = item.GDOC_NROSEC;
			++i; arrParam[i].Value = item.GDOC_TIPODOCUMENTO;
			++i; arrParam[i].Value = item.GDOC_NRODOCUMENTO;
			++i; arrParam[i].Value = item.GDOC_LINEA;
			++i; arrParam[i].Value = item.GDOC_PRODUCTO;
			++i; arrParam[i].Value = item.GDOC_RESPUESTA;
			++i; arrParam[i].Value = DateTime.Now;
			++i; arrParam[i].Value = item.GDOC_APLICACION;
			++i; arrParam[i].Value = item.GDOC_TIP_OPERACION;
			++i; arrParam[i].Value = item.GDOC_PDV;
			++i; arrParam[i].Value = item.GDOC_ESTADO;
			++i; arrParam[i].Value = item.GDOC_MODALIDAD;
			++i; arrParam[i].Value = item.GDOC_DEPARTAMENTO;
			++i; arrParam[i].Value = item.GDOC_LATITUD;
			++i; arrParam[i].Value = item.GDOC_LONGITUD;
			++i; arrParam[i].Value = item.GDOC_TIPDOCVEND;
			++i; arrParam[i].Value = item.GDOC_NRODOCVEND;
			++i; arrParam[i].Value = item.GDOC_CODVENDEDOR;
			++i; arrParam[i].Value = item.GDOC_SERIELECTOR;
			++i; arrParam[i].Value = item.GDOC_ICCID;
			++i; arrParam[i].Value = item.GDOC_IDPADRE;
			++i; arrParam[i].Value = item.GDOC_CODVENDSEC;
			++i; arrParam[i].Value = item.GDOC_OBSERVACION;
			++i; arrParam[i].Value = item.GDOC_USUARIO_CREA;


			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = "PKG_GENDOC_25335_0.BIOMSI_REG_GENDOC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			
			}
			catch
			{
				salida = false;
				obRequest.Factory.RollBackTransaction();
		
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[26];
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public bool RegistrarRepresentanteLegalSEC(RepresentanteLegal item)
		{		

			DAABRequest.Parameter[] arrParam = {				
												   new DAABRequest.Parameter("P_SRLN_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPN_NRO_PEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLN_APODN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLV_ID_TX_P", DbType.String,30, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLV_TIPO_DOCUMENTO_RL", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLV_NRO_DOCUMENTO_RL", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLV_NOMBRES_RL", DbType.String,200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLV_APELLIDOS_PAT_RL", DbType.String,200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLV_APELLIDOS_MAT_RL", DbType.String,200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_OBSERVACION", DbType.String,150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_APLICACION", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_USUARIO_CREA", DbType.String,15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SRLC_CODNACIONALIDAD", DbType.String, ParameterDirection.Input),//PROY-31636
												   new DAABRequest.Parameter("P_SRLV_DESCNACIONALIDAD", DbType.String, ParameterDirection.Input),//PROY-31636
												   new DAABRequest.Parameter("P_CODIGO_RESPUESTA", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MENSAJE_RESPUESTA", DbType.String, ParameterDirection.Output)
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0; arrParam[i].Value = item.SOLIN_CODIGO;
			++i; arrParam[i].Value = item.P_SCPN_NRO_PEDIDO;
			++i; arrParam[i].Value = item.APODN_CODIGO;
			++i; arrParam[i].Value = item.P_SRLV_ID_TX_P;
			++i; arrParam[i].Value = item.APODC_TIP_DOC_REP;
			++i; arrParam[i].Value = item.APODV_NUM_DOC_REP;
			++i; arrParam[i].Value = item.APODV_NOM_REP_LEG;
			++i; arrParam[i].Value = item.APODV_APA_REP_LEG;
			++i; arrParam[i].Value = item.APODV_AMA_REP_LEG;
			++i; arrParam[i].Value = item.P_SCPV_OBSERVACION;
			++i; arrParam[i].Value = item.P_SCPV_APLICACION;
			++i; arrParam[i].Value = item.P_SCPV_USUARIO_CREA;
			++i; arrParam[i].Value = item.P_SRLC_CODNACIONALIDAD;//PROY-31636
			++i; arrParam[i].Value = item.P_SRLV_DESCNACIONALIDAD;//PROY-31636

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = "PKG_SISACT_REPRESENTANTE_LEGAL.SISACTSI_REPRESENTANTE_LEGAL";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
		
			}
			catch
			{
				salida = false;
				obRequest.Factory.RollBackTransaction();

			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[12];
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

	
		
		public bool RegistrarCartaPoderSEC(BECartaPoder item)
		{		

			DAABRequest.Parameter[] arrParam = {				
												   new DAABRequest.Parameter("P_SCPN_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPN_NRO_PEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_ID_TX_P", DbType.String,30, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_TIPO_TRANSACCION", DbType.String, 30,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_TIPO_OPERACION", DbType.String,15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_DESC_OPERACION", DbType.String,100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_TIPO_DOCUMENTO_AP", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_NRO_DOCUMENTO_AP", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_NOMBRES_AP", DbType.String,200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_APELLIDOS_PAT_AP", DbType.String,200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_APELLIDOS_MAT_AP", DbType.String,200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_OBSERVACION", DbType.String,150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_APLICACION", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCPV_USUARIO_CREA", DbType.String,15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_RESPUESTA", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MENSAJE_RESPUESTA", DbType.String, ParameterDirection.Output)
											   }; 


			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0; arrParam[i].Value = item.SCPN_SOLIN_CODIGO;
			++i; arrParam[i].Value = item.SCPN_NRO_PEDIDO;
			++i; arrParam[i].Value = item.SCPV_ID_TX_P;
			++i; arrParam[i].Value = item.SCPV_TIPO_TRANSACCION;
			++i; arrParam[i].Value = item.SCPV_TIPO_OPERACION;
			++i; arrParam[i].Value = item.SCPV_DESC_OPERACION;
			++i; arrParam[i].Value = item.SCPV_TIPO_DOCUMENTO_AP;
			++i; arrParam[i].Value = item.SCPV_NRO_DOCUMENTO_AP;
			++i; arrParam[i].Value = item.SCPV_NOMBRES_AP;
			++i; arrParam[i].Value = item.SCPV_APELLIDOS_PAT_AP;
			++i; arrParam[i].Value = item.SCPV_APELLIDOS_MAT_AP;
			++i; arrParam[i].Value = item.SCPV_OBSERVACION;
			++i; arrParam[i].Value = item.SCPV_APLICACION;
			++i; arrParam[i].Value = item.SCPV_USUARIO_CREA;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = "PKG_SISACT_CARTA_PODER.SISACTSI_CARTA_PODER";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
		
			}
			catch( Exception ex )
			{
				salida = false;
				obRequest.Factory.RollBackTransaction();

			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[14];
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public string Generar_ID_BIO(int tipo)
		{	
			DAABRequest.Parameter[] arrParam = {	

												   new DAABRequest.Parameter("p_tipo_id", DbType.Int32, ParameterDirection.Input),
                                                   new DAABRequest.Parameter("p_id_trx_bio", DbType.String, ParameterDirection.ReturnValue)

											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0; arrParam[i].Value = tipo;

			string retorno = string.Empty ;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = "SISACT_PKG_BIOMETRIA.SISACTFUN_GEN_ID_TX_BIO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			
			}
			catch( Exception ex )
			{
		
				obRequest.Factory.RollBackTransaction();

			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				retorno = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}			
			return retorno ;
		}

// Fin PROY-25335 - Contratación Electrónica - Release 0
		//PROY-31948 INI 
		public ArrayList ListaParametrosMaxCuotas_Keys(Int64 codigoGP)
		{			
			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_PARAN_GRUPO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if (codigoGP>0 ) arrParam[0].Value = codigoGP;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_PARAMETRO_GP";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Parametro item = new Parametro();
					item.Codigo = Funciones.CheckInt64(dr["PARAN_CODIGO"]);
					item.Descripcion= Funciones.CheckStr(dr["PARAV_DESCRIPCION"]);
					item.Valor= Funciones.CheckStr(dr["PARAV_VALOR"]);
					item.Valor1= Funciones.CheckStr(dr["PARAV_VALOR1"]);
                   	filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;			
		}
		//PROY-31948 FIN
	}

}
