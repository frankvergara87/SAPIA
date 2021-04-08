using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de VentaExpressDatos.
	/// </summary>
	public class VentaExpressDatos
	{
		public VentaExpressDatos() {}

		public MigracionWL ValidacionWhitelist(string nroDocumento, string nroLinea)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.String,16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LINEA", DbType.String,9, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   }; 

			arrParam[0].Value = nroDocumento;
			arrParam[1].Value = nroLinea;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_VALIDAR_WHITELIST";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = false;

			IDataReader dr = null;
			MigracionWL objMig=null;
			try
			{
				ArrayList filas = new ArrayList();
			
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				
				while(dr.Read())
				{
					objMig = new MigracionWL();
					objMig.TIPO_DOCUMENTO = Funciones.CheckStr(dr["MIGPV_TIPO_DOCUM"]);
					objMig.NRO_DOCUMENTO  = Funciones.CheckStr(dr["migpv_nro_docum"]);

					objMig.NOMBRES   = Funciones.CheckStr(dr["migpv_nombre_cli"]);
					objMig.APELLIDO_PATERNO   = Funciones.CheckStr(dr["migpv_apepat_cli"]);
					objMig.APELLIDO_MATERNO    = Funciones.CheckStr(dr["migpv_apemat_cli"]);
					objMig.PLAZO_ACUERDO   = Funciones.CheckStr(dr["migpv_plazo_acuerdo"]);

					objMig.NRO_LINEA = Funciones.CheckStr(dr["migpv_nro_linea"]);
					objMig.RIESGO  = Funciones.CheckStr(dr["migpc_riesgo"]);
					objMig.SCORE  = Funciones.CheckStr(dr["migpc_score"]);
					objMig.SCORE_CRED  = Funciones.CheckStr(dr["migpc_score_cred"]);

					objMig.CARGO_FIJO_MAX   = Funciones.CheckDbl(dr["migpn_carg_fij_max"]);
					objMig.CARGO_FIJO_MIN   = Funciones.CheckDbl(dr["migpn_carg_fij_min"]);

					objMig.MONTO_FLAT  = Funciones.CheckDbl(dr["migpn_monto_flat"]);
					objMig.LIMITE_CREDITO   = Funciones.CheckDbl(dr["migpn_lim_cred"]);
					objMig.FLAG_CONTROL_CONSUMO   = Funciones.CheckInt(dr["migpc_flag_contr_cons"]);
					objMig.FLAG_MIGRACION  = Funciones.CheckInt(dr["migpc_flag_mig"]);

					objMig.NRO_CARGOS_FIJOS_MAX   = Funciones.CheckInt(dr["migpn_nro_carg_fijos_max"]);
					objMig.NRO_CARGOS_FIJOS_MIN   = Funciones.CheckInt(dr["migpn_nro_carg_fijos_min"]);
					
					objMig.TIPO_CARGO_MAX  = Funciones.CheckStr(dr["migpc_tip_garant_max"]);
					objMig.TIPO_CARGO_MIN  = Funciones.CheckStr(dr["migpc_tip_garant_min"]);

					objMig.TIPO_CARGO_MAX_DESC  = Funciones.CheckStr(dr["tcarv_descripcion"]);
					objMig.TIPO_CARGO_MIN_DESC  = Funciones.CheckStr(dr["tcarv_descripcion2"]);
				}
			}
			catch( Exception ex )
			{				
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return objMig;
		}
	
		//e75785
		public ArrayList ListaPlanesMaxCF(string strTipoCliente, double cargo_fijo)
		{
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("P_TIPO_CLI_ACT",DbType.String ,ParameterDirection.Input),
					new DAABRequest.Parameter("P_CF",DbType.Double,ParameterDirection.Input),
					new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)

				};			
			
			arrParam[0].Value = strTipoCliente;
			arrParam[1].Value = cargo_fijo;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_LISTAR_PLANES_CF_MAX";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Plan itm = new Plan();
					itm.PLANN_CODIGO = Funciones.CheckInt(dr["PLAN_TARIFARIO"]);
					itm.PLANN_CAR_FIJ = Funciones.CheckDbl(dr["CARGO_FIJO"]);
					itm.PLANV_DESCRIPCION = Funciones.CheckStr(dr["DESCRIPCION"]);				
					filas.Add(itm);
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
		}//end
		//e75785
		public ArrayList Get_ConsultaPlanServicio(string plan, string servicio)
		{
			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("P_CODPLAN", DbType.String,3,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODSERVICIO", DbType.String,4,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)											   
											   }; 

			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = plan;
			arrParam[1].Value = servicio;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACT_LISTAR_SRVS_PLAN";
			obRequest.Parameters.AddRange(arrParam);
			ArrayList arrServicios = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				while(dr.Read())
				{
					Servicio item = new Servicio(); 
					item.Servicio_Solicit  = Funciones.CheckStr(dr["Servicio_Solicit"]);
					item.Descripcion =Funciones.CheckStr(dr["DESCRIPCION"]);
					item.Cargo_Fijo =Funciones.CheckInt (dr["Cargo_Fijo"]);
					item.Grupo =Funciones.CheckStr(dr["Grupo"]);
					item.Orden =Funciones.CheckInt(dr["Orden"]);
					item.Plan_Tarifario =Funciones.CheckStr(dr["Plan_Tarifario"]);
					item.Seleccionable =Funciones.CheckStr(dr["Seleccionable"]);
					arrServicios.Add(item);					
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return arrServicios;
		}


		public bool Set_Actualiza_Contrato_Solicitud(Int64 nroSEC,string strNumContrato)
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("p_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_SOLIV_NUM_CON", DbType.String, ParameterDirection.Input)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;				

			arrParam[0].Value = nroSEC;
			arrParam[1].Value = strNumContrato;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.SECP_PKG_SOLICITUDES  + ".SECSS_ACT_CONTRATO_SOLICITUD";
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
				salida = false;
				throw ex;
			}
			finally
			{	
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public void insertarLogMigracion(string[] arrLog)
		{
			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_logmv_nro_linea", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmv_tip_docum", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmv_num_docum", DbType.String ,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmc_existe_wl", DbType.String ,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmc_valido_bscs", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmc_es_prepago", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmv_nro_sec", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmv_nro_contrato", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmc_tip_deposito", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmc_activ_input_param", DbType.String,150,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmc_activ_result", DbType.String ,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmc_activ_des_result", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmv_cod_vendedor", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_logmv_punto_venta", DbType.String,10,ParameterDirection.Input)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = arrLog[0];
			arrParam[1].Value = arrLog[1];
			arrParam[2].Value = arrLog[2];
			arrParam[3].Value = arrLog[3];
			arrParam[4].Value = arrLog[4];
			arrParam[5].Value = arrLog[5];
			arrParam[6].Value = arrLog[6];
			arrParam[7].Value = arrLog[7];
			arrParam[8].Value = arrLog[8];
			arrParam[9].Value = arrLog[9];
			arrParam[10].Value = arrLog[10];
			arrParam[11].Value = arrLog[11];
			arrParam[12].Value = arrLog[12];
			arrParam[13].Value = arrLog[13];
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".INSERTAR_LOG_MIGRACION";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception ex)
			{				
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public void actualiza_MigracionWL(string P_NRO_DOCUM, string P_NRO_LINEA,string P_ESTADO,out string P_RPTA)
		{

			P_RPTA="";
			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("P_NRO_DOCUM", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_LINEA", DbType.String,16,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RPTA", DbType.String,1,ParameterDirection.Output)
												  }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = P_NRO_DOCUM;
			arrParam[1].Value = P_NRO_LINEA;
			arrParam[2].Value = P_ESTADO;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_UPDATE_MIGRA_PRE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[3];
				P_RPTA = Funciones.CheckStr(pSalida1.Value);
			}
			catch (Exception)
			{				
				//obRequest.Factory.RollBackTransaction();
				//throw ex;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public bool ActualizarPagoSolicitud(Int64 p_nroSEC, string p_flag_pago)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_FLG_PAG_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RETORNO", DbType.Int32, ParameterDirection.Output)
											   };

			for ( int i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			if ( p_nroSEC > 0 ) arrParam[0].Value = p_nroSEC;
			if ( p_flag_pago != "" ) arrParam[1].Value = p_flag_pago;

			bool salida = false;
			int resultado = 0;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_UPDATE_PAGO_SOLICITUD";
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
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[2];
				resultado = Funciones.CheckInt(parSalida.Value);
				salida = (resultado != 0);
				obRequest.Factory.Dispose();
			}
			return salida;
		}

		public PuntoVenta ObtenerDatosOficinaventa(string puntoventa)
		{


			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_OFICINA_VENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			
			arrParam[0].Value = puntoventa; 
			

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
		
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_MANTENIMIENTO + ".SISCAD_CON_DATOS_PDV";
			obRequest.Parameters.AddRange(arrParam);

			PuntoVenta OBJPTOVENTA = new PuntoVenta();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
				
					OBJPTOVENTA.OVENV_DESCRIPCION = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					OBJPTOVENTA.CANAV_DESCRIPCION = Funciones.CheckStr(dr["CADV_DESCRIPCION"]);
					OBJPTOVENTA.OVENC_CODIGO = Funciones.CheckStr(dr["OVENC_CODIGO"]);
					OBJPTOVENTA.OVENV_CENTRO = Funciones.CheckStr(dr["OVENV_CENTRO"]);
					OBJPTOVENTA.OVENV_NRO_CLIE_PADRE = Funciones.CheckStr(dr["OVENV_NRO_CLIE_PADRE"]);
					OBJPTOVENTA.OVENV_NRO_CLIE_HIJO = Funciones.CheckStr(dr["OVENV_NRO_CLIE_HIJO"]);
					OBJPTOVENTA.OVENV_ALMACEN = Funciones.CheckStr(dr["OVENV_ALMACEN"]);
							
				}
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return OBJPTOVENTA;

		}

		public string ObtenerEstMat(string serie,string codmaterial, string puntoventa)
		{
						
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_MATV_ESTADO", DbType.String,1,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MATV_SERIE", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATV_COD_MATERIAL", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PEDV_PUNTO_VENTA", DbType.String,ParameterDirection.Input)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = serie; 
			arrParam[2].Value = codmaterial; 
			arrParam[3].Value = puntoventa; 
			

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
		
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_VENTA + ".SISACT_CONS_ESTADO_MATERIAL";
			obRequest.Parameters.AddRange(arrParam);

			string estado_material = "";
			IDataReader dr = null;
			try
			{
                                           
				obRequest.Factory.ExecuteReader(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				estado_material = Funciones.CheckStr(parSalida.Value);
					
			}
			catch(Exception )
			{
				throw;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return estado_material;
		}

		public ArrayList ListarPlanes(string p_codigo_plan, string p_tipo_venta, string p_tipo_cliente, string p_flag_vigencia, string p_mandt)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN_TARIFARIO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_VENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CLIENTE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_VIGENCIA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MANDT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (p_codigo_plan != "") { arrParam[i].Value = p_codigo_plan; }
			i++; if (p_tipo_venta != "") { arrParam[i].Value = p_tipo_venta; }
			i++; if (p_tipo_cliente != "") { arrParam[i].Value = p_tipo_cliente; }
			i++; if (p_flag_vigencia != "") { arrParam[i].Value = p_flag_vigencia; }
			i++; if (p_mandt != "") { arrParam[i].Value = p_mandt; }

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_LISTAR_PLANES";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item=new ItemGenerico();
					item.Codigo=Funciones.CheckStr(dr["PLAN_TARIFARIO"]);
					item.Descripcion=Funciones.CheckStr(dr["DESCRIPCION"]);
					item.Codigo2=Funciones.CheckStr(dr["TIPO_VENTA"]);
					item.estado=Funciones.CheckStr(dr["FLAG_VIGENCIA"]);
					item.Monto=Funciones.CheckDbl(dr["CARGO_FIJO"]);
					item.Tipo=Funciones.CheckStr(dr["TIPO_CLI_ACT"]);
					item.orden=Funciones.CheckInt(dr["MANDT"]);

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

		public ArrayList ConsultarListaCampanias(string p_tipo_venta, string p_fecha, string p_mandt)
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

			
			i=0; if (p_tipo_venta != "") { arrParam[i].Value = p_tipo_venta; }
			
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

               public bool ActualizaRenovacionPrepago(ItemGenerico p_linea)
		{
			DAABRequest.Parameter[] arrParam = {
							      new DAABRequest.Parameter("P_REPREV_NRO_TELEFONO", DbType.String, ParameterDirection.Input),
							      new DAABRequest.Parameter("P_REPRED_FECHA_INICIO", DbType.Date, ParameterDirection.Input),
                                                              new DAABRequest.Parameter("P_REPRED_FECHA_FIN", DbType.Date, ParameterDirection.Input),
							      new DAABRequest.Parameter("P_REPREC_FLAG_RENOVADO", DbType.String, ParameterDirection.Input),
							      new DAABRequest.Parameter("P_REPREV_NRO_RENOVADO", DbType.String, ParameterDirection.Input),
	                                                      new DAABRequest.Parameter("P_RETORNO", DbType.Int32, ParameterDirection.Output)
		                                           };

			int i;
			for ( i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			i=0; if ( p_linea.Numero != "" ) arrParam[i].Value = p_linea.Numero;
			i++; if ( p_linea.Fecha != "" ) arrParam[i].Value = Funciones.CheckDate(p_linea.Fecha);
			i++; if ( p_linea.Fecha2 != "" ) arrParam[i].Value = Funciones.CheckDate(p_linea.Fecha2);
			i++; if ( p_linea.estado != "" ) arrParam[i].Value = p_linea.estado;
			i++; if ( p_linea.Descripcion2 != "" ) arrParam[i].Value = p_linea.Descripcion2;

			bool salida = false;
			int resultado = 0;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_UPDATE_RENOVACION_PRE";
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
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[4];
				resultado = Funciones.CheckInt(parSalida.Value);
				salida = (resultado > 0);
				obRequest.Factory.Dispose();
			}
			return salida;
		}		
		public string ObtenerCargoFijoPlan(string p_codigo_plan)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLAN_TARIFARIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = p_codigo_plan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_OBTENER_CF_PLAN";
			obRequest.Parameters.AddRange(arrParam);
			
			string cargo_fijo = "";
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					cargo_fijo = Funciones.CheckStr(dr["CARGO_FIJO"]);
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
			return cargo_fijo;
		}
				
		public bool CrearVenta(VentaSiscad oVenta, ref string NroTicket)
		{
			   

            
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RETORNO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TICK_PREVENTA", DbType.String, 25, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_VENTV_TIPO_DOC_CLIENTE", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_NRO_DOC_CLIENTE", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_PUNTO_VENTA", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_NRO_PEDIDO_SAP", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_NRO_ENTREGA_SAP", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_NRO_CONTRATO_SAP", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_NRO_DOCUMENTO_SAP", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_TIPO_VENTA", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_ESTADO", DbType.String,2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_TICKET_VENTA", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_TIPO_OPERACION", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_USUARIO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_ORIGEN", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTD_FECHA_CIERRE", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_NRO_DOC_VENDEDOR", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_NOM_APE_VENDEDOR", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NROPEDIDO_MSSAP", DbType.String, ParameterDirection.Input)
											   }; 
			int i;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;				

			i=0; arrParam[i].Value = oVenta.IdVenta;
			++i; arrParam[i].Value = oVenta.TicketPreventa;
			++i; arrParam[i].Value = oVenta.TipoDocCliente;
			++i; arrParam[i].Value = oVenta.NroDocCliente;
			++i; arrParam[i].Value = oVenta.PuntoVenta;
			++i; arrParam[i].Value = oVenta.NroPedidoSap;
			++i; arrParam[i].Value = oVenta.NroEntregaSap;
			++i; arrParam[i].Value = oVenta.NroContratoSap;
			++i; arrParam[i].Value = oVenta.NroDocumentoSap;
			++i; arrParam[i].Value = oVenta.TipoVenta;
			++i; arrParam[i].Value = oVenta.EstadoVenta;
			++i; arrParam[i].Value = oVenta.TicketVenta;
			++i; arrParam[i].Value = oVenta.TipoOperacion;
			++i; arrParam[i].Value = oVenta.Usuario;
			++i; arrParam[i].Value = oVenta.CodAplicacion;
			++i; arrParam[i].Value = oVenta.FechaCierre;
			++i; arrParam[i].Value = oVenta.NroDocVendedor;
			++i; arrParam[i].Value = oVenta.NombreVendedor;
			++i; arrParam[i].Value = oVenta.nropedido_mssap;
			bool salida = false;
			string retorno = "";
			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
		
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_VENTA + ".SISACT_REGISTRO_VENTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter parRetorno, parTicket;
				parRetorno = (IDataParameter)obRequest.Parameters[0];
				parTicket = (IDataParameter)obRequest.Parameters[1];

				retorno = Funciones.CheckStr(parRetorno.Value);
				NroTicket = Funciones.CheckStr(parTicket.Value);	

				if (retorno == "1") 
				{
					salida = true;
				}
			}
			catch( Exception ex )
			{
				NroTicket = "";	
				salida = false;
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
		public string CrearOrdenVenta(OrdenVentaSiscad oOrdenVenta)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RETORNO", DbType.String,2, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_EXISTE_PRECIO", DbType.String,2, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_EXISTE_SKU", DbType.String,2,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PRECIO", DbType.Currency, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TICK_PREVENTA", DbType.String, 25, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATV_COD_MATERIAL", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATV_SERIE", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ORDV_PRECIO", DbType.Currency, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CATV_COD_LISTA_PRECIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CATV_PUNTO_VENTA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ORDV_IDENTIFICADOR", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATV_ESTADO", DbType.String,5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ORDV_NRO_LINEA", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENTV_ORIGEN", DbType.String,20, ParameterDirection.Input)
											   }; 

			int i;
			for ( i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;	
			
			i=4; arrParam[i].Value = oOrdenVenta.TicketPreventa;
			++i; arrParam[i].Value = oOrdenVenta.CodigoMaterial;
			++i; arrParam[i].Value = oOrdenVenta.Serie;
			++i; arrParam[i].Value = oOrdenVenta.Precio;
			++i; arrParam[i].Value = oOrdenVenta.ListaPrecio;
			++i; arrParam[i].Value = oOrdenVenta.PuntoVenta;
			++i; arrParam[i].Value = oOrdenVenta.Identificador ;
			++i; arrParam[i].Value = oOrdenVenta.EstadoMaterial ;
			++i; arrParam[i].Value = oOrdenVenta.NroTelefono;  
			++i; arrParam[i].Value = oOrdenVenta.OrigenVenta;  
			
			string retorno = "";

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
		
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_VENTA + ".SISACT_REGISTRO_ORDENVENTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
		
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida,parSalida2,parSalida3,parSalida4;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				parSalida2 = (IDataParameter)obRequest.Parameters[1];
				parSalida3 = (IDataParameter)obRequest.Parameters[2];
				parSalida4 = (IDataParameter)obRequest.Parameters[3];
				
				retorno = Funciones.CheckStr(parSalida.Value) + ";" + Funciones.CheckStr(parSalida2.Value) + ";" + Funciones.CheckStr(parSalida3.Value) + ";" + Funciones.CheckStr(parSalida4.Value);

				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();				
				throw ex;
			}
			finally
			{					
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno ;
		}
		public AlertaSiscad CorreoAlertasSiscad(string codPdv)
		{
				
			AlertaSiscad item = new AlertaSiscad();		
			int i;
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_COD_OFICINA_VENTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUR_SALIDA", DbType.Object, ParameterDirection.Output)};

			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (codPdv != "") {arrParam[i].Value = codPdv;}

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_CONSULTAS + ".SISCAD_LIST_ALERTXPDV";
			obRequest.Parameters.AddRange(arrParam);
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{					
					item.MAILJEFE  = Funciones.CheckStr(dr["ALERT_MAILJEFE"]);
					item.MAILSECTORISTA  = Funciones.CheckStr(dr["ALERT_MAILSECTORISTA"]);					
				}
			}
			catch
			{
				item = null;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return item;		
		}
		
		public string ConsultaParamConfigSiscad(string cod)
		{
			
			string strValorConfig = "";		
			int i;
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_VALOR_SALIDA", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("v_confi_codigo", DbType.Int32 , ParameterDirection.Input )};

			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if (cod != "") {arrParam[i].Value = cod;}

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.pkg_siscad_mantenimiento + ".SISCAD_LIST_PARAM_CONF";
			obRequest.Parameters.AddRange(arrParam);
						
			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);
				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				strValorConfig = Funciones.CheckStr(pSalida.Value);
			}
			catch
			{
				
			}
			finally
			{			
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return strValorConfig;
		}		

	
		public string GrabarVentaRenovacion(string oficina, string doc_tipo, string doc_nro, string vendedor, string doc_sap,
			string cont_sap, string correo, string plan_act, string telefono, 
			string plan_nuevo, string tope_cons, string servidor, double limite, string ciclo_fact)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC_CLIE_TIPO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC_CLIE_NUMERO", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CORREO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTRATO_SAP", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_ACTUAL", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_NUEVO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPE_CONSUMO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CICLO_FACT", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LIMITE_CREDITO", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVIDOR", DbType.String, 20, ParameterDirection.Input)
											   }; 

			int i;
			for ( i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;	
			
			i=1; arrParam[i].Value = oficina;
			++i; arrParam[i].Value = doc_tipo;
			++i; arrParam[i].Value = doc_nro;
			++i; arrParam[i].Value = correo;
			++i; arrParam[i].Value = vendedor;
			++i; arrParam[i].Value = doc_sap;
			++i; arrParam[i].Value = cont_sap;
			++i; arrParam[i].Value = telefono;
			++i; arrParam[i].Value = plan_act;
			++i; arrParam[i].Value = plan_nuevo;
			++i; arrParam[i].Value = tope_cons;
			++i; arrParam[i].Value = ciclo_fact;
			++i; arrParam[i].Value = limite;
			++i; arrParam[i].Value = servidor;
			
			string retorno = "";

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACT_INS_VENTA_RENOVACION";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
		
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				retorno = Funciones.CheckStr(parSalida.Value);

				obRequest.Factory.CommitTransaction();
			}
			catch (Exception)
			{
				obRequest.Factory.RollBackTransaction();				
				throw;
			}
			finally
			{					
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return retorno;
		}	

		public bool validaAPADECE(int co_id)
		{

			bool retorno=true;
			ArrayList comandosTran = new ArrayList();
			string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIGA"];
			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("v_co_id", DbType.String,15,ParameterDirection.Input),
												   new DAABRequest.Parameter("v_estado", DbType.String,1,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = co_id;
			
			BDSIGA obj = new BDSIGA(BaseDatos.BD_SIGA);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = esquema + ".SP_SISACT_ESTADO_APADECE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[1];
				if (Funciones.CheckInt(pSalida1.Value) == 1){
					retorno = false;
				}
			}
			catch(Exception ex)
			{				
				//obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return retorno;
		}
		

		public string GrabarVentaRenovacionCAC(string oficina, string doc_tipo, string doc_nro, string vendedor, string doc_sap,
			string cont_sap, string correo, string plan_act, string telefono, 
			string plan_nuevo, string tope_cons, string servidor, double limite, string ciclo_fact, string canal, string pedido_sap, string tipo_renovacion, int flag_exoneracion, int flag_descuento, string titular, string representante, double descuento, string usuarioValidador,
			string RetenidoFidelizado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC_CLIE_TIPO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC_CLIE_NUMERO", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CORREO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTRATO_SAP", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_ACTUAL", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_NUEVO", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPE_CONSUMO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CICLO_FACT", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LIMITE_CREDITO", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVIDOR", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PEDIDO_SAP", DbType.String, ParameterDirection.Input),									   
												   new DAABRequest.Parameter("P_TIPO_RENOVACION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_EXONERACION", DbType.String,1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_DESCUENTO", DbType.String,1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TITULAR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_REPRESENTANTE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCUENTO", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USER_VALIDADOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_FIDELIZADO_RETENIDO", DbType.String, ParameterDirection.Input)
											   }; 

			int i;
			for ( i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;	
			
			i=1; arrParam[i].Value = oficina;
			++i; arrParam[i].Value = doc_tipo;
			++i; arrParam[i].Value = doc_nro;
			++i; arrParam[i].Value = correo;
			++i; arrParam[i].Value = vendedor;
			++i; arrParam[i].Value = doc_sap;
			++i; arrParam[i].Value = cont_sap;
			++i; arrParam[i].Value = telefono;
			++i; arrParam[i].Value = plan_act;
			++i; arrParam[i].Value = plan_nuevo;
			++i; arrParam[i].Value = tope_cons;
			++i; arrParam[i].Value = ciclo_fact;
			++i; arrParam[i].Value = limite;
			++i; arrParam[i].Value = servidor;

			++i; arrParam[i].Value = canal;
			++i; arrParam[i].Value = pedido_sap;
			++i; arrParam[i].Value = tipo_renovacion;
			++i; arrParam[i].Value = flag_exoneracion;
			++i; arrParam[i].Value = flag_descuento;
			++i; arrParam[i].Value = titular;
			++i; arrParam[i].Value = representante;
			++i; arrParam[i].Value = descuento;
			++i; arrParam[i].Value = usuarioValidador;
			// Inicio E77568
			++i; arrParam[i].Value = RetenidoFidelizado;
			// Fin E77568
			string retorno = "";

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACT_INS_VENTA_RENOV_CAC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
		
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				retorno = Funciones.CheckStr(parSalida.Value);

				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
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
        
		public bool EliminarVentaRenovacionPostpago(string doc_sap)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DOCUMENTO_SAP", DbType.String,  ParameterDirection.Input)
											   };
			int i;
			for ( i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;	
			
			i=1; arrParam[i].Value = doc_sap;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SISACT_DEL_VENTA_RENOV_CAC";
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
				throw ex;
			}
			finally
			{
				string par1 = "";

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				par1 = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();

				if(par1 == "0")
				{	
					salida = true;
				}
				else
				{
					salida = false;
				}
				
			}			
			return salida ;
		}




		public AcuerdoApadece ConsultarAPADECE(string nroTelefono)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NROTELEFONO", DbType.String,16, ParameterDirection.Input),
												   new DAABRequest.Parameter("CURSOR_SALIDA", DbType.Object, ParameterDirection.Output)
											   }; 

			arrParam[0].Value = nroTelefono;
			
			BDSIGA obj = new BDSIGA(BaseDatos.BD_SIGA);		

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_SIGA_ACUERDO + ".SP_CONSULTAR_ESTADO_APADECE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = false;

			IDataReader dr = null;
			AcuerdoApadece objApadece=null;
			try
			{
				ArrayList filas = new ArrayList();
			
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				
				while(dr.Read())
				{
					objApadece = new AcuerdoApadece();
					objApadece.ACUERDO_ID = Funciones.CheckStr(dr["Acuerdo_Id"]);
					objApadece.NRO_TELEFONO  = Funciones.CheckStr(dr["Nro_Telefono"]);
					objApadece.CO_ID   = Funciones.CheckStr(dr["Co_id"]);
					objApadece.CUSTOMER_ID   = Funciones.CheckStr(dr["Customer_id"]);
					objApadece.FECHA_INICIO    = Funciones.CheckDate(dr["Fecha_Ini_Acuerdo"]);
					objApadece.FECHA_FIN   = Funciones.CheckDate(dr["Fecha_Fin_Acuerdo"]);
					objApadece.COD_PLAZO_ACUERDO = Funciones.CheckStr(dr["cod_plazo_acuerdo"]);
					objApadece.PLAZO_ACUERDO  = Funciones.CheckStr(dr["des_plazo_acuerdo"]);
					objApadece.VIGENCIA_MESES  = Funciones.CheckInt(dr["vigencia_meses"]);
					objApadece.COD_ESTADO_ACUERDO  = Funciones.CheckStr(dr["estado_acuerdo"]);
					objApadece.ESTADO_ACUERDO   = Funciones.CheckStr(dr["desc_acuerdo"]);
					objApadece.MONTO_REINTEGRO   = Funciones.CheckDbl(dr["monto_apadece_total"]);
					objApadece.NRO_MESES_PENDIENTE   = Funciones.CheckInt(dr["Nro_Meses_Pendiente"]);
					
				}
			}
			catch( Exception ex )
			{				
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return objApadece;
		}

//FMES
		public DataTable ConsultaEstadoSOT()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)												   
											   }; 

			int i = 0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;		
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;			

			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SISACT_LISTAR_SOT";

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
		
		//----------------------------------------------------

		public DataTable reporteVentasxPtoVenta(int intSec,string strNumeroDocumento,string strTipoDocumento, string strFechaInicio, string strFechaFin, string strPuntoVenta, string strEstadoSot)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_SEC", DbType.Decimal,10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUMERO_DOC", DbType.String,16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO_DOC", DbType.String,20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_INICIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_FIN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PUNTO_VENTA", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO_SOT", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 

			int i = 0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;		
			
			arrParam[0].Value = intSec;
			arrParam[1].Value = strNumeroDocumento;
			arrParam[2].Value = strTipoDocumento;
			arrParam[3].Value = strFechaInicio;
			arrParam[4].Value = strFechaFin;
			arrParam[5].Value = strPuntoVenta;
			arrParam[6].Value = strEstadoSot;

			BDREPTDM obj = new BDREPTDM(BaseDatos.BD_REPTDM);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;			
			
			objRequest.Command = BaseDatos.PKG_SISACT_DTH_REPTDM + ".USP_VENTAXPUNTO";

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
		
		//FMES
		public void ObtenerMontoMaxDescuentoAS(ref double MontoMaxDesAS, ref double MesesMaxDesAS)
		{
			double descuento = 0.0;
			double meses = 0;
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_MONTO", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MESES", DbType.Int32, ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_MONTOMAX_DESC_X_ASESOR";
			obRequest.Parameters.AddRange(arrParam);
			
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				IDataParameter parSalida1;
				IDataParameter parSalida2;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				parSalida2 = (IDataParameter)obRequest.Parameters[1];
				descuento = Funciones.CheckDbl(parSalida1.Value);
				meses = Funciones.CheckInt(parSalida2.Value);
				obRequest.Factory.Dispose();

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

			MontoMaxDesAS = descuento;
			MesesMaxDesAS = meses;
			
		}
			
		public void ObtenerMontoMaxMinDescuentoAS(ref double MontoMaxDesASMax, ref double MesesMaxDesASMax, ref double MontoMaxDesAS, ref double MesesMaxDesAS)
		{
			double descuentoMax = 0.0;
			double descuentoMin = 0.0;
			double mesesMax = 0;
			double mesesMin = 0;
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("p_montomax", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_montomin", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_mesesmax", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_mesesmin", DbType.Int32, ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".sp_montomax_min_autoriza";
			obRequest.Parameters.AddRange(arrParam);
			
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				IDataParameter parSalida1;
				IDataParameter parSalida2;
				IDataParameter parSalida3;
				IDataParameter parSalida4;

				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				parSalida2 = (IDataParameter)obRequest.Parameters[1];
				parSalida3 = (IDataParameter)obRequest.Parameters[2];
				parSalida4 = (IDataParameter)obRequest.Parameters[3];

				descuentoMax = Funciones.CheckDbl(parSalida1.Value);
				descuentoMin = Funciones.CheckDbl(parSalida2.Value);
				mesesMax = Funciones.CheckInt(parSalida3.Value);
				mesesMin = Funciones.CheckInt(parSalida4.Value);
				obRequest.Factory.Dispose();

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

			MontoMaxDesAS = descuentoMin;
			MesesMaxDesAS = mesesMin;
			MontoMaxDesASMax = descuentoMax;
			MesesMaxDesASMax = mesesMax;
		}
			
		public ArrayList ConsultaLPreciosporPlazo(string plazo_acuerdo)
		{
			DAABRequest.Parameter[] arrParam = {
												
												   new DAABRequest.Parameter("P_PLAZO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   };

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if (plazo_acuerdo != "") { arrParam[i].Value = plazo_acuerdo; }
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".SP_LIST_LPRECIO_X_PLAZO";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["LPRECIO"]);
					

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
		//INICIO WHZR

		public PuntoVenta ListaOficinaVentaxID(string id)
		{
			//List<OficinaVenta> Lista = new List<OficinaVenta>();
			IDataReader dr = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_id", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cur_salida", DbType.Object, ParameterDirection.Output)
											   };
			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
			arrParam[0].Value = id;
            
			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_MANTENIMIENTO + ".SISCAD_CONS_PDVXID";
			obRequest.Parameters.AddRange(arrParam);

			PuntoVenta eOficinaVenta=new PuntoVenta();
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					//Lista.Insert(0, new OficinaVenta());
					while (dr.Read())
					{
						eOficinaVenta.OVENC_CODIGO = Funciones.CheckStr(dr["ovenc_codigo"]);
						eOficinaVenta.OVENV_DESCRIPCION = Funciones.CheckStr(dr["ovenv_descripcion"]);
						eOficinaVenta.OVENV_CENTRO = Funciones.CheckStr(dr["OVENV_CENTRO"]);
						eOficinaVenta.OVENV_ALMACEN = Funciones.CheckStr(dr["OVENV_ALMACEN"]);
						eOficinaVenta.OVENC_ESTADO = Funciones.CheckStr(dr["ovenc_estado"]);
	
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return eOficinaVenta;
		}


		//	SISCAD_PKG_VENTA.SISCAD_REGISTRO_HIST_VENTA 
		public bool RegistroHistoricoVenta(int idVenta, string estado, string usuario)
		{

			DAABRequest.Parameter[] arrParam = {	
												   new DAABRequest.Parameter("P_VENTN_ID_VENTA" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HVENV_ESTADO" ,DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_HVENV_USUARIO_REG" ,DbType.String,10,ParameterDirection.Input)
											   };



			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = idVenta;
			arrParam[1].Value = estado;
			arrParam[2].Value = usuario;

			bool salida = false;

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_VENTA + ".SISCAD_REGISTRO_HIST_VENTA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return salida;

		}

		public bool ANULACION_VENTA(string NRO_DOCUMENTO,string PTO_VENTA)
		{
			DAABRequest.Parameter[] arrParam =  {
													new DAABRequest.Parameter("P_VENTV_NRO_DOCUMENTO_SAP", DbType.String, ParameterDirection.Input),
													new DAABRequest.Parameter("P_VENTV_PUNTO_VENTA", DbType.String,20, ParameterDirection.Input),
													new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output)
												}; 

			for ( int i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;  
                  
			arrParam[0].Value = NRO_DOCUMENTO;
			arrParam[1].Value = PTO_VENTA;

			bool salida = false;

			BDSISCAD obj = new BDSISCAD(BaseDatos.BD_SISCAD);
            
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISCAD_VENTA + ".SISACT_ANULACION_VENTA";
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
				throw ex ;
			}
			finally
			{                            
				obRequest.Factory.Dispose();
			}                 
			return salida ;
		}     
			
		//----------------------------------INICIO WHZR 02102014------------------------------------
		public AcuerdoApadece Consultar_APADECE_NUEVO(int intMSISDN, int intCOD_ID, int intACUERDO_ID, DateTime dtFECHA_TRANSACCION, int intTIPO_ACUERDO,
			int intMOTIVO_APADECE, int intCF_NUEVO, int intFLG_EQUIPO, int intACUERDO_VIGENTE,
			ref int intMONTO_APADECE, ref string strTIPO_PRODUCTO, ref int intCODERROR, ref string strDESERROR)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("PI_MSISDN", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_COD_ID", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_ACUERDO_ID", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_FECHA_TRANSACCION", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_TIPO_ACUERDO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_MOTIVO_APADECE", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_CF_NUEVO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_FLG_EQUIPO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PI_ACUERDO_VIGENTE", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PO_MONTO_APADECE", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("PO_TIPO_PRODUCTO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("PO_CODERROR", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("PO_DESERROR", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("CUR_SEC", DbType.Object, ParameterDirection.Output),
			}; 
			
			string nameArchivo = "prueba";	
			
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = intMSISDN;

			if (Funciones.CheckInt(intCOD_ID) != 0)
			{
				arrParam[1].Value = intCOD_ID;
			}
			if(Funciones.CheckInt(intACUERDO_ID) != 0 )
			{
				arrParam[2].Value = intACUERDO_ID;
			} 
			
			if(Funciones.CheckDate(dtFECHA_TRANSACCION)!= Funciones.CheckDate("01/01/0001"))
			{
			arrParam[3].Value = dtFECHA_TRANSACCION;
			}

			if(Funciones.CheckInt(intTIPO_ACUERDO)!= 0)
			{
				arrParam[4].Value = intTIPO_ACUERDO;
			}
			if(Funciones.CheckInt(intMOTIVO_APADECE)!= 0){
				arrParam[5].Value = intMOTIVO_APADECE;
			}
			
			if(Funciones.CheckInt(intCF_NUEVO)!= 0)
			{
			arrParam[6].Value = intCF_NUEVO;
			}
			if(Funciones.CheckInt(intFLG_EQUIPO) != 0)
			{
				arrParam[7].Value = intFLG_EQUIPO;
			}
			if(Funciones.CheckInt(intACUERDO_VIGENTE) != 0)
			{
				arrParam[8].Value = intACUERDO_VIGENTE;
			}

			BDNSIGA obj = new BDNSIGA(BaseDatos.BD_NSIGA);		
			i = 0;
			for (i = 0; i < arrParam.Length; i++)
			HelperLog.EscribirLog("", nameArchivo, "prueba"  + arrParam[i].Value, false);

			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SIGA_CONSULTAS + ".SP_OBTENER_APADECE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = false;

			IDataReader dr = null;
			AcuerdoApadece objApadece=null;
			try
			{
				ArrayList filas = new ArrayList();
			
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				
				while(dr.Read())
				{
					objApadece = new AcuerdoApadece();
					objApadece.NCA_IDACUERDO = Funciones.CheckStr(dr[0]);
					objApadece.NCA_FECHA_ACUERDO = Funciones.CheckStr(dr[1]);
					objApadece.NCA_TIPO_TRANSACCION = Funciones.CheckStr(dr[2]);
					objApadece.NCA_COD_PLAZO_ACUERDO = Funciones.CheckStr(dr[3]);
					objApadece.NCA_TIPO_ACUERDO = Funciones.CheckStr(dr[4]);
					objApadece.NCA_VIGENCIA_MESES = Funciones.CheckStr(dr[5]);
					objApadece.NCA_COD_EQUIPO = Funciones.CheckStr(dr[6]);
					objApadece.NCA_SERIE_EQUIPO = Funciones.CheckStr(dr[7]);
					objApadece.NCA_ICCID = Funciones.CheckStr(dr[8]);
					objApadece.NCA_PRECIO_LISTA = Funciones.CheckStr(dr[9]);
					objApadece.NCA_PRECIO_VENTA = Funciones.CheckStr(dr[10]);
					objApadece.NCA_FACT_MIN_ESPERADA = Funciones.CheckStr(dr[11]);
					objApadece.NCA_CF_TOTAL_ACUMULAD = Funciones.CheckStr(dr[12]);
					objApadece.NCA_MONTO_APADECE = Funciones.CheckStr(dr[13]);
					objApadece.NCA_CO_ID = Funciones.CheckStr(dr[14]);
					objApadece.NCA_CUSTOMER_ID = Funciones.CheckStr(dr[15]);
					objApadece.NCA_CUSTOMER_CODE = Funciones.CheckStr(dr[16]);
					objApadece.NCA_MSISDN = Funciones.CheckStr(dr[17]);
					objApadece.NCA_SUBSIDIO = Funciones.CheckStr(dr[18]);
					objApadece.NCA_CF_VIGENTE = Funciones.CheckStr(dr[19]);
					objApadece.NCA_MONTO_APADECE_ANTERIOR = Funciones.CheckStr(dr[20]);
					objApadece.NCA_NOMBRE_EQUIPO = Funciones.CheckStr(dr[21]);
					objApadece.NCA_SERIE_EQUIPO2 = Funciones.CheckStr(dr[22]);
					objApadece.NCA_COD_PLAN = Funciones.CheckStr(dr[23]);
					objApadece.NCA_COD_PLAN_ANTERIOR = Funciones.CheckStr(dr[24]);
					objApadece.NCA_COD_TIPO_PLAN = Funciones.CheckStr(dr[25]);
					objApadece.NCA_DESCRIPCION_PLAN = Funciones.CheckStr(dr[26]);
				}
				IDataParameter parSalida,parSalida2,parSalida3,parSalida4;
				parSalida = (IDataParameter)obRequest.Parameters[9];
				parSalida2 = (IDataParameter)obRequest.Parameters[10];
				parSalida3 = (IDataParameter)obRequest.Parameters[11];
				parSalida4 = (IDataParameter)obRequest.Parameters[12];

				intMONTO_APADECE = Funciones.CheckInt(parSalida.Value);
				strTIPO_PRODUCTO = Funciones.CheckStr(parSalida2.Value);
				intCODERROR = Funciones.CheckInt(parSalida3.Value);
				strDESERROR = Funciones.CheckStr(parSalida4.Value);

 
			}
			catch( Exception ex )
			{				
				throw ex;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return objApadece;
		}




		//---------------------------------FIN WHZR 02102014----------------------------------------
		//inicio whzr 06112014	
		public int ValidaClaveVendedor(string PI_VEN_TIPO_DOCU,
			string PI_VEN_NUME_DOCU,
			string PI_VEN_PDV,
			string PI_VEN_USUA,
			string PI_VEN_CLAV_ACTU,
			int PI_CODI_APLI,
			ref string PO_VENDEDOR)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("PI_VEN_TIPO_DOCU", DbType.String, ParameterDirection.Input),												  
												   new DAABRequest.Parameter("PI_VEN_NUME_DOCU", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("PI_VEN_PDV", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("PI_VEN_USUA", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("PI_VEN_CLAV_ACTU", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("PI_CODI_APLI", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("PO_VALO_VALI", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("PO_VENDEDOR", DbType.String, ParameterDirection.Output) };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = PI_VEN_TIPO_DOCU;
			arrParam[1].Value = PI_VEN_NUME_DOCU;
			arrParam[2].Value = PI_VEN_PDV;
			arrParam[3].Value = PI_VEN_USUA;
			arrParam[4].Value = PI_VEN_CLAV_ACTU;
			arrParam[5].Value = PI_CODI_APLI;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_VENDEDOR_SEGURIDAD + ".SISACSS_VENDEDOR_CLAVE_VALID";
			obRequest.Parameters.AddRange(arrParam);

			int PO_VALO_VALI;			

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter psalida;
				IDataParameter psalida1;
				psalida = (IDataParameter)obRequest.Parameters[6];
				psalida1 = (IDataParameter)obRequest.Parameters[7];
				PO_VALO_VALI = Funciones.CheckInt(psalida.Value);
				PO_VENDEDOR = Funciones.CheckStr(psalida1.Value);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{

				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}

			return PO_VALO_VALI;
		}


		public int ObtenerCantidadVentas(string strDocumento, string strtelefono, int intDias){
		
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_cantidad", DbType.Int32, ParameterDirection.Output),												  
												   new DAABRequest.Parameter("p_doc_clie", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("p_telefono", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("p_dias", DbType.Int32, ParameterDirection.Input) };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = strDocumento;
			arrParam[2].Value = strtelefono;
			arrParam[3].Value = intDias;

		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".sp_obtener_num_vendidos";
			obRequest.Parameters.AddRange(arrParam);

			int intCantidadVentas;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter psalida;
				psalida = (IDataParameter)obRequest.Parameters[0];
				intCantidadVentas = Funciones.CheckInt(psalida.Value);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{

				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}

			return intCantidadVentas;

		}

		//fin whzr 06112014

		//Inicio PPV 12012017
			
		public int ObtenerLineasVendidasPVU(string strDocumento, string strtelefono, int intDias)
		{
		
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_cantidad", DbType.Int32, ParameterDirection.Output),												  
												   new DAABRequest.Parameter("p_doc_clie", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("p_telefono", DbType.String, ParameterDirection.Input),	
												   new DAABRequest.Parameter("p_dias", DbType.Int32, ParameterDirection.Input) };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = strDocumento;
			arrParam[2].Value = strtelefono;
			arrParam[3].Value = intDias;

		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SP_OBTENER_LINEAS_VENDIDAS_PVU";
			obRequest.Parameters.AddRange(arrParam);

			int intCantidadVentas;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter psalida;
				psalida = (IDataParameter)obRequest.Parameters[0];
				intCantidadVentas = Funciones.CheckInt(psalida.Value);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{

				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}

			return intCantidadVentas;

		}
		//Fin PPV 12012017

		//consolidado 06012015

		public string getFlagIdValidator(string nroDoc,string  nroSec)
		{
			DAABRequest.Parameter[] arrParam ={	new DAABRequest.Parameter("P_NRODOC", DbType.String, ParameterDirection.Input),												   
												  new DAABRequest.Parameter("P_NROSEC", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("P_RESPUESTA", DbType.Int32, ParameterDirection.Output)
											  };

			int i=0;
			for (i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			
			i=0; if (nroDoc != "") { arrParam[i].Value = nroDoc; }
			i++; if (nroSec != "") { arrParam[i].Value = nroSec; }		
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO + ".sisact_idv_validacion";
			
			obRequest.Parameters.AddRange(arrParam);
						
			string codRespuesta = "";
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);		
			
				IDataParameter parSalida;				
				parSalida = (IDataParameter)obRequest.Parameters[2];								
				codRespuesta =Funciones.CheckStr(parSalida.Value);				
			}
			catch( Exception ex )
			{					
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return codRespuesta;
		}

		//consolidado 06012015

		//Inicio RIHU 30122014 - Desbloqueo Equipo.
		public int intValidarEquipoBloqueado(string strIMEI, string strCodMaterial , out string strDescripcionResp)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_IMEI", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_MATERIAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_RESPUESTA", DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DES_RESPUESTA", DbType.String, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++){
				arrParam[i].Value = DBNull.Value;
			}

			arrParam[0].Value = strIMEI;
			arrParam[1].Value = strCodMaterial;

			int intResult = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_ValidarEquipoBloqueado;
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
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				IDataParameter parSalida2;
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				parSalida2 = (IDataParameter)obRequest.Parameters[3];
				intResult = Funciones.CheckInt(parSalida1.Value);
				strDescripcionResp = Funciones.CheckStr(parSalida2.Value);
				obRequest.Factory.Dispose();
			}			
			return intResult;
		}

		public Boolean booDesbloqueoEquipo(string k_imei, ref string k_simlock, ref string k_cod_error, ref string k_msg_error)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_IMEI", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_SIMLOCK", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_COD_ERROR", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_MSG_ERROR", DbType.String, ParameterDirection.Output)
											   };

			for (int j = 0; j < arrParam.Length; j++)
				arrParam[j].Value = System.DBNull.Value;

			arrParam[0].Value = k_imei;

			BDSIMLOCK obj = new BDSIMLOCK(BaseDatos.BD_SIMLOCK);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_ObtenerEquipoBloqueado;
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			Boolean booRes = false;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				k_msg_error = "Error al Insertar. \nMensaje : " + ex.Message;
				return false;
			}
			finally
			{
				IDataParameter par_simlock;
				IDataParameter par_cod_error;
				IDataParameter par_msg_error;

				par_simlock = (IDataParameter)obRequest.Parameters[1];
				par_cod_error = (IDataParameter)obRequest.Parameters[2];
				par_msg_error = (IDataParameter)obRequest.Parameters[3];
			
				k_simlock = Funciones.CheckStr(par_simlock.Value);
				k_cod_error = Funciones.CheckStr(par_cod_error.Value);
				k_msg_error = Funciones.CheckStr(par_msg_error.Value);
				//k_cod_error ="0";
				obRequest.Factory.Dispose();
			}
			return booRes;
		}

			

		//consolidado 16012015

		public bool ActualizarContratoSolicitud(Int64 p_nroSEC, string p_nroContrato)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIV_NUM_CON", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RETORNO", DbType.Int32, ParameterDirection.Output)
											   };

			for ( int i=0; i<arrParam.Length;i++ )
				arrParam[i].Value = DBNull.Value;

			if ( p_nroSEC > 0 ) arrParam[0].Value = p_nroSEC;
			if ( p_nroContrato != "" ) arrParam[1].Value = p_nroContrato;

			bool salida = false;
			int resultado = 0;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_UPDATE_CONTRATO_SOLICITUD";
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
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[2];
				resultado = Funciones.CheckInt(parSalida.Value);
				salida = (resultado != 0);
				obRequest.Factory.Dispose();
			}
			return salida;
		}	

		//consolidado 16012015


		//consolidado 20012015

		public Int64 GrabarVenta(string cadenaCabecera)
		{

			string[] arrDBAcuerdo = cadenaCabecera.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_resultado", DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msgerr", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_documento", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_tipo_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_canal", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_oficina_venta", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipo_doc_cliente", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_nro_doc_cliente", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_moneda", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_topen_codigo", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_total_venta", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_subtotal_impuesto", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_subtotal_venta", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_observacion", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tven_codigo", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_numero_referencia", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_usuario_crea", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_numero_cuotas", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_vendedor", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_org_venta", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_numero_sec", DbType.Int64,ParameterDirection.Input)
											   };

			Int64 nroVenta = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".sp_reg_venta";
			obRequest.Parameters.AddRange(arrParam);

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			try
			{
				for (int i = 0; i < arrDBAcuerdo.Length; i++)
				{
					if (arrDBAcuerdo[i].Trim() != "")
						arrParam[i].Value = arrDBAcuerdo[i].Trim();
				}

				obRequest.Factory.ExecuteReader(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[2];
				nroVenta = Funciones.CheckInt64(parSalida.Value);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return nroVenta;
		}


		public static Int64 GrabarVentaDetalle(Int64 idVenta, string cadenaDetalle)
		{
			string[] arrDatos = cadenaDetalle.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_resultado", DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msgerr", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_correlativo", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_documento", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_material", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_material_desc", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_plan", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_plan_desc", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_telefono", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_campana", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_campana_desc", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cantidad", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_precio", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_descuento", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_subtotal", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_igv", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_total", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_lista_precio", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_lista_precio_desc", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_imei19", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cuotas", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_des_cuotas", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_prdc_codigo", DbType.String,5,ParameterDirection.Input)
											   };

			Int64 nroVenta = 0;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".sp_reg_venta_detalle";
			obRequest.Parameters.AddRange(arrParam);

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			try
			{
				for (int i = 0; i < arrDatos.Length; i++)
				{
					if (arrDatos[i].Trim() != "")
						arrParam[i].Value = arrDatos[i].Trim();
				}

				arrParam[3].Value = idVenta;

				obRequest.Factory.ExecuteReader(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				nroVenta = Funciones.CheckInt64(parSalida.Value);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return nroVenta;
		}



		public  Int64 GenerarAcuerdo(string datosAcuerdo, ref string sMensaje)
		{

			string[] arrDBAcuerdo = datosAcuerdo.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NROACUERDO", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSJ_RESPUESTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_VENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_OPERACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA_VENTAS", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUMERO_PCS", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZO_ACUERDO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FACT_NOMBRE", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FACT_APE_PAT", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FACT_APE_MAT", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FACT_R_SOCIAL", DbType.String,300,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO_APROBACION", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VENDEDOR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_nombre_vendedor", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCUMENTO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ANALISTA_CREDITO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MIGRACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_COD_OBSERVACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OBSERVACIONES", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC_CLIENTE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIENTE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RENOVACION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_APROBADOR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LIM_CREDITO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SCORE_CREDITICIO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONTROL_FRAUDE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CS_LARGE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CS_SUBCUENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUM_PLANES_VENDI", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESPONS_PAGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_EXISTE_BSCS", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ACTIVACION_LINEA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ACUERDO_MANUAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CLI_ACT", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MOTIVO_MIG", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MOTIVO_REPOS", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_CANAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_nombre_usuario", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_ciclo_fact", DbType.String,ParameterDirection.Input)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			Int64 nroContrato = 0;

			for (int i = 0; i < arrDBAcuerdo.Length; i++)
			{
				if (arrDBAcuerdo[i].Trim() != "")
					arrParam[i].Value = arrDBAcuerdo[i].Trim();
			}

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".SP_REG_ACUERDO";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{


				obRequest.Factory.ExecuteReader(ref obRequest);
				IDataParameter parSalida, parSalida1;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				nroContrato = Funciones.CheckInt64(parSalida.Value);
				sMensaje = Funciones.CheckStr(parSalida1.Value);

				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();

			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return nroContrato;
		}
		public  String GenerarAcuerdoDet(Int64 nroAcuerdo, string datosAcuerdoDet, ref string strMensaje)
		{
			string[] arrDBAcuerdo = datosAcuerdoDet.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_RESPUESTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSJ_RESPUESTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NROACUERDO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSECUTIVO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ARTICULO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DES_ARTICULO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_UTILIZACION", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DES_UTILIZACION", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DES_CAMPANA", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERIE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANTIDAD", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_LISTA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_TOTAL", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCUENTO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SUBTOTAL", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IMPUESTO", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_TARIFARIO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DES_PLAN_TARIFAR", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUMERO_TELEFONO", DbType.String,ParameterDirection.Input),											   
												   new DAABRequest.Parameter("P_PRINCIPAL", DbType.String,ParameterDirection.Input),		
												   new DAABRequest.Parameter("P_COD_EQUIPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DES_EQUIPO", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERIE_EQUIPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUC_CODIGO", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PACUV_DESCRIPCION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RECIBO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SOLIN_CODIGO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cuotas", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_des_cuotas", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tmcode", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cargo_fijo", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_slpln_codigo", DbType.Int64,ParameterDirection.Input)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			string strCodResp = "";
			try
			{
				for (int i = 0; i < arrDBAcuerdo.Length; i++)
				{
					if (arrDBAcuerdo[i].Trim() != "")
						arrParam[i].Value = arrDBAcuerdo[i].Trim();
				}
				arrParam[2].Value = nroAcuerdo;

				BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				DAABRequest obRequest = obj.CreaRequest();
				obRequest.CommandType = CommandType.StoredProcedure;
				obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".SP_REG_ACUERDO_DET";
				obRequest.Parameters.AddRange(arrParam);

				IDataReader dr = null;

				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter parSalida;
				IDataParameter parSalida1;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				strCodResp = Funciones.CheckStr(parSalida.Value);
				strMensaje = Funciones.CheckStr(parSalida1.Value);

				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();

			}  
			catch (Exception e)
			{
				throw e;
			}

			return strCodResp;
		}

		public  String GenerarAcuerdoEquipo(Int64 nroAcuerdo, string datosAcuerdoEquipo, ref string strMensaje)
		{
			string[] arrDBAcuerdo = datosAcuerdoEquipo.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_cod_respuesta", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msj_respuesta", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_id_contrato", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_id_detalle", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cod_equipo", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_des_equipo", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_serie_equipo", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_campana", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_campana_desc", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_utilizacion", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_des_utilizacion", DbType.String,100,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_precio_lista", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_precio_venta", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_descuento", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_impuesto", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cuota", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_des_cuota", DbType.String,100,ParameterDirection.Input)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			string strCodResp = "";
			try
			{
				for (int i = 0; i < arrDBAcuerdo.Length; i++)
				{
					if (arrDBAcuerdo[i].Trim() != "")
						arrParam[i].Value = arrDBAcuerdo[i].Trim();
				}
				arrParam[2].Value = nroAcuerdo;

				BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
				DAABRequest obRequest = obj.CreaRequest();
				obRequest.CommandType = CommandType.StoredProcedure;
				obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".sp_reg_acuerdo_equipo";
				obRequest.Parameters.AddRange(arrParam);

				IDataReader dr = null;

				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter parSalida;
				IDataParameter parSalida1;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				strCodResp = Funciones.CheckStr(parSalida.Value);
				strMensaje = Funciones.CheckStr(parSalida1.Value);

				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();

			}  
			catch (Exception e)
			{
				throw e;
			}

			return strCodResp;
		}

		public  String GenerarAcuerdoServ(Int64 nroAcuerdo, string datosAcuerdoServ, ref string strMensaje)
		{
			string[] arrDBAcuerdo = datosAcuerdoServ.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COD_RESPUESTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSJ_RESPUESTA", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NROACUERDO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ID_DETALLE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVICIO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVICIO_DES", DbType.String,100,ParameterDirection.Input),										   
												   new DAABRequest.Parameter("p_cargo_fijo", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_spcode", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_sncode", DbType.String,ParameterDirection.Input)
											   };
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".SP_REG_ACUERDO_SER";
			obRequest.Parameters.AddRange(arrParam);

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			string strCodResp = "";
			try
			{
				for (int i = 0; i < arrDBAcuerdo.Length; i++)
				{
					if (arrDBAcuerdo[i].Trim() != "")
						arrParam[i].Value = arrDBAcuerdo[i].Trim();
				}
				arrParam[2].Value = nroAcuerdo;

				IDataReader dr = null;
				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter parSalida;
				IDataParameter parSalida1;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				strCodResp = Funciones.CheckStr(parSalida.Value);
				strMensaje = Funciones.CheckStr(parSalida1.Value);

				if (dr != null && dr.IsClosed == false) dr.Close();
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return strCodResp;
		}


		public string ObtenerFactorLimCred(string p_codigo_param)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PARAN_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = p_codigo_param;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_OBTENER_FACTOR_LIM_CRED";
			obRequest.Parameters.AddRange(arrParam);
			
			//ItemGenerico item = new ItemGenerico();
			string factor_lim_cred = "";
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					
					factor_lim_cred = Funciones.CheckStr(dr["PARAV_VALOR"]);
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
			return factor_lim_cred;
		}


		//consolidado 20012015

		public DataTable ConsultaDetalleAcuerdo(string tipo, string valor)
		{
			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_tipo", DbType.String,16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_valor", DbType.String,100, ParameterDirection.Input),
												   new DAABRequest.Parameter("cursor_salida", DbType.Object, ParameterDirection.Output)
											   }; 

			arrParam[0].Value = tipo;
			arrParam[1].Value = valor;
			
			BDSIGA obj = new BDSIGA(BaseDatos.BD_SIGA);		
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_SIGA_ACUERDO + ".SSSIGA_CONSULTA_ACUERDO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];	
			}
			catch( Exception ex )
			{				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return dtResultado;
		}
		//JNUFLO

		public DataTable ConsultaVigenciaLibre(int param_grupo)
		{
			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_paran_grupo", DbType.Int32, ParameterDirection.Input),
												   
												   new DAABRequest.Parameter("p_cursor", DbType.Object, ParameterDirection.Output)
											   }; 

			arrParam[0].Value = param_grupo; 
			
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
		    obRequest.Command = BaseDatos.PKG_SISACT_MAESTROS + ".sisact_mant_list_parametro";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];	
			}
			catch( Exception ex )
			{				
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return dtResultado;
		}

		public bool actualizarDepositoGarantia(string nroSEC,string nroDeposito, string customerId, string tipoDeposito)
		{

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SEC" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCDEPOSITOSAP" ,DbType.String,50,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUSTOMERID" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPOGARANTIA" ,DbType.String,10,ParameterDirection.Input)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroSEC;
			arrParam[1].Value = nroDeposito;
			arrParam[2].Value = customerId;
			arrParam[3].Value = tipoDeposito;

			bool salida = false;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_SOLICITUD_CONS + ".SP_UPDATE_DEPOSITO_GAR";
			obRequest.Parameters.AddRange(arrParam);
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				salida = true;
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{					
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public void GrabarGarantia(string cadenaDeposito, ref string nroGarantiaSisact)
		{

			string[] arrDBAcuerdo = cadenaDeposito.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_cod_respuesta", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msj_respuesta", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_numero_garantia", DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_nro_contrato", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_recibo", DbType.Int64,ParameterDirection.Input),                                                
												   new DAABRequest.Parameter("p_tipo_doc_cliente", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_nro_doc_cliente", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_monto_garantia", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_oficina", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_usuario_crea", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_nro_cargos", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipo_garantia", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_clase_doc_sap", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_nro_dep_sap", DbType.String,ParameterDirection.Input)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			for (int i = 0; i < arrParam.Length; i++)
			{
				if (arrDBAcuerdo[i].Trim() != "")
					arrParam[i].Value = arrDBAcuerdo[i].Trim();
			}

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".sp_reg_garantia";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{


				obRequest.Factory.ExecuteReader(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[2];
				nroGarantiaSisact = Funciones.CheckStr(parSalida.Value);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public string RollBackVenta(Int64 idVenta, ref string strMensaje)
		{
			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("p_id_venta", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cod_resp", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msg_resp", DbType.String,ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = idVenta;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".sp_rollback_venta";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;

			string codResp = "";
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter parSalida, parSalida2;
				parSalida = (IDataParameter)obRequest.Parameters[1];
				parSalida2 = (IDataParameter)obRequest.Parameters[2];
				codResp = Funciones.CheckStr(parSalida.Value);
				strMensaje = Funciones.CheckStr(parSalida2.Value);
			}
			catch (Exception e)
			{
				obRequest.Factory.RollBackTransaction();
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return codResp;
		}

		public string GrabarInfoVentaSap(Int64 p_id_venta, Int64 p_id_contrato, string p_recibo,
			string p_nro_documento, string p_tipo_documento, double p_monto_documento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_cod_respuesta", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_msj_respuesta", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("p_id_venta", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_id_contrato", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_recibo", DbType.Int64,ParameterDirection.Input),                                                                                             
												   new DAABRequest.Parameter("p_nro_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipo_documento", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_monto_documento", DbType.Double,ParameterDirection.Input)
											   };
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			i = 2; arrParam[i].Value = p_id_venta;
			i++; arrParam[i].Value = p_id_contrato;
			i++; arrParam[i].Value = Funciones.CheckInt64(p_recibo);
			i++; arrParam[i].Value = p_nro_documento;
			i++; arrParam[i].Value = p_tipo_documento;
			i++; arrParam[i].Value = p_monto_documento;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".sp_reg_info_venta_sap";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			string codResp = "";
			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[0];
				codResp = Funciones.CheckStr(parSalida.Value);

				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();

			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return codResp;
		}

		public Boolean insertaCuotas(Cuota itemCuota)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NRO_CUOTAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_CONTRATO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_PEDIDO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_LINEA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_EMISION", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTO", DbType.Double, ParameterDirection.Input),				
												   new DAABRequest.Parameter("P_USUARIO_REG", DbType.String, ParameterDirection.Input)
												   
											   }; 

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = itemCuota.nroCuota; 
			arrParam[2].Value = itemCuota.nroContrato; 
			arrParam[3].Value = itemCuota.nroSap;
			arrParam[4].Value = itemCuota.telefono; 
			arrParam[5].Value = itemCuota.fechEmision; 
			arrParam[6].Value = itemCuota.monto;
			arrParam[7].Value = itemCuota.usuario;
		

			bool salida = false;
			string rMsg="";
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_PORTABILIDAD + ".SP_INSERT_CUOTA";
			obRequest.Parameters.AddRange(arrParam);

			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida.Value);

				//INC000001019296-INICIO
				if(rMsg == "0")
				{
					salida = true;
				}

			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Cuota. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return salida;
		}

		public bool GrabarCuotas(Cuota itemCuota)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NRO_CLIENTE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_CUOTAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_CONTRATO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_PEDIDO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC_CLIEN", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOM_CLIENTE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_LINEA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHA_EMISION", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTO", DbType.Double, ParameterDirection.Input),				
												   new DAABRequest.Parameter("P_USUARIO_REG", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_CVE_C", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IMEI", DbType.String, ParameterDirection.Input), //*LCA
												   new DAABRequest.Parameter("P_CODMAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUSTOMER_ID", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUENTA_CLIE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_ENVIO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CON_SISACT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CICLO", DbType.String, ParameterDirection.Input)
											   };

			int i;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = itemCuota.CUOV_NRO_CLIENTE;
			arrParam[2].Value = itemCuota.CUON_NRO_CUOTA;
			arrParam[3].Value = itemCuota.CUOV_NRO_CONTRATO;
			arrParam[4].Value = itemCuota.CUOV_NRO_DOC_SAP;
			arrParam[5].Value = itemCuota.CUOV_NRO_DOC_CLIENTE;
			arrParam[6].Value = itemCuota.CUOV_NOM_CLIENTE;
			arrParam[7].Value = itemCuota.CUOV_NRO_CELULAR;
			arrParam[8].Value = itemCuota.CUOD_FECHA_EMISION;
			arrParam[9].Value = itemCuota.CUON_MONTO;
			arrParam[10].Value = itemCuota.CUOV_USUARIO_REG;
			arrParam[11].Value = "M";
			arrParam[12].Value = itemCuota.CUOV_IMEI;
			arrParam[13].Value = itemCuota.CUOV_MATE;
			arrParam[14].Value = itemCuota.OFICINA;
			arrParam[15].Value = itemCuota.CUSTOMER_ID;
			arrParam[16].Value = itemCuota.CUENTA_BSCS;
			arrParam[17].Value = itemCuota.FLAG_ENVIO;
			arrParam[18].Value = itemCuota.CONTRATO_SISACT;
			arrParam[19].Value = itemCuota.CICLO_FACTURACION;

			bool salida = false;
			string rMsg = "";
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_DRA_CVE + ".SISACSI_INSERT_CUOTA";
			obRequest.Parameters.AddRange(arrParam);

			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				rMsg = Funciones.CheckStr(pSalida.Value);

				//INC000001019296-INICIO
				if(rMsg == "0")
				{
					salida = true;
				}
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar Cuota. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return salida;
		}

		public string ConsultaFechaEmision(string strCiclo, ref string strFechaEmision, ref string codResp, ref string strMensaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("V_CICLO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FEC_EMISION", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MGS_ERR", DbType.String,ParameterDirection.Output)
                                                   
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strCiclo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CONTRATO + ".SISASS_FECEMI";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[1];
				strFechaEmision = Funciones.CheckStr(pSalida1.Value);

				codResp = "0";
				strMensaje = "OK";
			}
			catch (Exception e)
			{
				codResp = "-99";
				strMensaje = e.Message;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return strFechaEmision;
		}

		public bool ActualizarPlanVenta(Int64 idSolPlan, string telefono, string equipo, double precioEquipo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SOPLN_CODIGO", DbType.Int64, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_FINAL", DbType.Double, ParameterDirection.Input)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = idSolPlan;
			arrParam[2].Value = telefono;
			arrParam[3].Value = equipo;
			arrParam[4].Value = precioEquipo;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_UPD_SOL_PLAN_VENTA";
			obRequest.Parameters.AddRange(arrParam);

			bool blnOK = false;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);

				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[1];

				HelperLog.CrearArchivolog("VentaExpressDatos"," Respuesta de SISACT_PKG_GENERAL_3PLAY_6.SP_UPD_SOL_PLAN_VENTA: " +
					Funciones.CheckStr(parSalida.Value.ToString()),Funciones.CheckStr(arrParam[1].Value.ToString()),
					Funciones.CheckStr(parSalida.Value.ToString()),"");
	

//				if (Funciones.CheckStr(parSalida.Value) == "0")
//				{
					blnOK = true;
//				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return blnOK;
		}


		//-Inicio-dga-31072015
		public string ObtenerSecMSSAP(string nroContrato)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_SOLIV_NUM_PED", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroContrato;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_OBTENERSEC_PEDIDO";
			obRequest.Parameters.AddRange(arrParam);
			
			string numero_sec = "";
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					numero_sec = Funciones.CheckStr(dr["SOLIN_CODIGO"]);
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
			return numero_sec;
		}
		//-Fin-dga-31072015

		//Inicio RNP 16/09/2015
		public string InsertaVtaFidelizacion(string nroDocumento, Int64 idVenta, string nroContrato, Int64 idPedidoMsSap, double montoDescuentoDivididoFidelizacion, string idOficina, string codUsuario)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_NRODOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDVENTA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDCONTRATO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDPEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTO", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PDV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, ParameterDirection.Input)										   
											   }; 

			int i;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroDocumento; 
			arrParam[1].Value = idVenta; 
			arrParam[2].Value = Convert.ToInt32(nroContrato);
			arrParam[3].Value = idPedidoMsSap; 
			arrParam[4].Value = montoDescuentoDivididoFidelizacion; 
			arrParam[5].Value = idOficina;
			arrParam[6].Value = codUsuario;
		

			string rMsg="";
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_INS_VTA_FIDELIZACION";
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
				rMsg = "Error al Insertar Fidelización \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return rMsg;
		}

		public string ActualizaEstadoFidelizacion(Int64 idVenta, string nroContrato, Int64 idPedidoMsSap, int iEstado)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_IDVENTA", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDCONTRATO", DbType.Int32, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_IDPEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, ParameterDirection.Input),
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = idVenta;
			arrParam[1].Value = Convert.ToInt32(nroContrato);
			arrParam[2].Value = idPedidoMsSap;
			arrParam[3].Value = iEstado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_UPD_EST_FIDELIZACION";
			obRequest.Parameters.AddRange(arrParam);

			string rMsg="";
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Actualizar Estado Fidelización \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return rMsg;
		}
		//Fin RNP 16/09/2015

		//INICIO CAMPAÑA NO VIGENTE 28102015
		public void ObtenerPlanNoVigente(string strIdPlanNoVig, ref string strplanIdNoVig_Out, ref string strplanDesNoVig, ref string strIdPlanVig, ref string strplanDesVig, ref string strCampanasPlan)
		{
			string strplanDesNoVig1 = "";
			string strIdPlanVig1 = "";
			string strplanDesVig1 = "";
			string strplanIdNoVig_Out1 = "";
			string strCampanasPlan1= "";//Modificacion Plan No Vigente
			
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_ID_PLAN_NO_VIGENTE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_ID_NOVIGENTE_OUT", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLAN_DES_NOVIGENTE", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_ID_PLAN_VIGENTE", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLAN_DES_VIGENTE", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CAMPANAS_PLAN", DbType.String, ParameterDirection.Output),
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;	
		
			arrParam[0].Value = strIdPlanNoVig;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_OBT_PLAN_NO_VIGENTE";
			obRequest.Parameters.AddRange(arrParam);
			
			
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				IDataParameter parSalida1;
				IDataParameter parSalida2;
				IDataParameter parSalida3;
				IDataParameter parSalida4;
				IDataParameter parSalida5;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				parSalida2 = (IDataParameter)obRequest.Parameters[2];
				parSalida3 = (IDataParameter)obRequest.Parameters[3];
				parSalida4 = (IDataParameter)obRequest.Parameters[4];
				parSalida5 = (IDataParameter)obRequest.Parameters[5];
				strplanIdNoVig_Out1 = Funciones.CheckStr(parSalida1.Value);
				strplanDesNoVig1 = Funciones.CheckStr(parSalida2.Value);
				strIdPlanVig1 = Funciones.CheckStr(parSalida3.Value);
				strplanDesVig1 = Funciones.CheckStr(parSalida4.Value);
				strCampanasPlan1 = Funciones.CheckStr(parSalida5.Value); //Modificacion

				obRequest.Factory.Dispose();

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

			strplanDesNoVig = strplanDesNoVig1;
			strIdPlanVig = strIdPlanVig1;
			strplanDesVig = strplanDesVig1;
			strplanIdNoVig_Out = strplanIdNoVig_Out1;
			strCampanasPlan = strCampanasPlan1;//Modificacion Plan No Vigente
			
		}

		//FIN CAMPAÑA NO VIGENTE 28102015

public void insertarRepo4G(int co_id, string linea)
		{
			ArrayList comandosTran = new ArrayList();

			DAABRequest.Parameter[] arrParam = {
				
												   new DAABRequest.Parameter("P_CO_ID", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RESULTADO", DbType.String,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = co_id;
			arrParam[1].Value = linea;

			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);					

			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_REPO_ACT + ".SP_INSERT_REPO_ACT";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional=true;
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				//				obRequest.Factory.CommitTransaction();
			}
			catch(Exception ex)
			{				
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{				
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}
	//INICIO PROMOCION CAMPAÑA 23112015

		public ArrayList ListarGrupoProducto(string strFlujoRenov)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_FLUJO", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strFlujoRenov;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_GENERAL_3PLAY + ".SP_CON_COMBO_X_FLUJO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["COMBV_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["COMBV_DESCRIPCION"]);
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

		public string ActualizaComboRenov(string strNroSEC, string strPlanAsoc)
		{

			DAABRequest.Parameter[] arrParam = {   
												   new DAABRequest.Parameter("V_NROSEC", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("V_FLAG", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("V_PLANASOC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("V_IDVENTA", DbType.Int64,ParameterDirection.Input)
											   };
			
			for (int i=0; i<arrParam.Length;i++)
			arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strNroSEC;
			arrParam[1].Value  = "0";
			arrParam[2].Value  = strPlanAsoc;
			


			string retorno = "";

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_UPDATE_VR_COMBO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				retorno = "0";
				obRequest.Factory.CommitTransaction();
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return retorno;
		}

		//FIN PROMOCION CAMPAÑA 23112015

		//Inicio Nuevo HLR - UDB - MVC
		public ArrayList ListarEquivalenciaHLRyUDB(int nHLR_1,int nHLR_2)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_NRO_HLR_CAC", DbType.Int16,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_NRO_HLR_DAC", DbType.Int16,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nHLR_1;
			arrParam[1].Value = nHLR_2;
			
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_OBT_HLREQUIV";
			obRequest.Parameters.AddRange(arrParam);
			
			//Inicio Reader
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
			
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["COD_HLR"]);					
					item.Codigo2 = Funciones.CheckStr(dr["COD_UDB"]);					
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
			//Fin Reader
			return filas;
		}
		//Fin Nuevo HLR - UDB - MVC

	}
}