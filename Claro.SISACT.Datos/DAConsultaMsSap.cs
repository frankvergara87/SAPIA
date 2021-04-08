using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;
using System.Configuration;
using System.Text;


namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for DAConsultaMsSap.
	/// </summary>
	public class DAConsultaMsSap
	{
		public DAConsultaMsSap()
		{	
		}

		public ArrayList ConsultaMaterialXOficina(string pCodOficina,string pDesOficina,string pCodCentro,string pcodAlmacen,string pTipoOficina)
		{
			DAABRequest.Parameter[] arrParam = 
					{
						new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String, ParameterDirection.Input),
						new DAABRequest.Parameter("K_OFICV_DESCRIPCION", DbType.String, ParameterDirection.Input),
						new DAABRequest.Parameter("K_OFICC_CODCENTRO", DbType.String, ParameterDirection.Input),
						new DAABRequest.Parameter("K_OFICC_CODALMACEN", DbType.String, ParameterDirection.Input),
						new DAABRequest.Parameter("K_OFICC_TIPOOFICINA", DbType.String, ParameterDirection.Input),
						new DAABRequest.Parameter("K_RESULT_SET", DbType.Object, ParameterDirection.Output)
					};

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}			

			BEParametroOficina oPar =  ParametrosOficina(pCodOficina);
			arrParam[0].Value = oPar.codigoOficinaMSSAP; //pCodOficina;
			arrParam[1].Value = "";//pDesOficina;			
			arrParam[2].Value = oPar.codigoCentro; 
			arrParam[3].Value = oPar.codigoAlmacen;
			arrParam[4].Value = oPar.TipoOficina;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP+ Constantes.MSSapMateOficina;//dga
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapMateOficina;
			
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
					item.Descripcion = Funciones.CheckStr(dr["MATEV_DESCMATERIAL"]);					
					item.codCentro = Funciones.CheckStr(dr["OFICC_CODCENTRO"]);
					item.codAlmacen = Funciones.CheckStr(dr["OFICC_CODALMACEN"]);
					item.codOficina = Funciones.CheckStr(dr["OFICV_CODOFICINA"]);
					item.desOficina = Funciones.CheckStr(dr["OFICV_DESCRIPCION"]);
					item.tipoMaterial = Funciones.CheckStr(dr["MATEC_TIPOMATERIAL"]);
					filas.Add(item);
				}
				
			}
			catch (Exception ex)
			{
				throw (ex);
				//return ex.Message;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return filas;
		}


		public ArrayList ConsultarStock(string pcodOficina, string pdesOficina, string pTipoOficina)
		{
			DAABRequest.Parameter[] arrParam = 
					{
						new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String, ParameterDirection.Input),
						new DAABRequest.Parameter("K_OFICV_DESCRIPCION", DbType.String, ParameterDirection.Input),
						new DAABRequest.Parameter("K_OFICC_TIPOOFICINA", DbType.String, ParameterDirection.Input),						
						new DAABRequest.Parameter("K_RESULT_SET", DbType.Object, ParameterDirection.Output)
					};

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}
			BEParametroOficina oPar = ParametrosOficina(pcodOficina);            
			arrParam[0].Value = oPar.codigoOficinaMSSAP; //pcodOficina;  
			arrParam[1].Value = "";//pdesOficina;
			arrParam[2].Value = oPar.TipoOficina;			

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + Constantes.MSSapStockDisponible;//dga
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapStockDisponible;
			

			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					//BEConsultaStock item = new BEConsultaStock();
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
					item.Descripcion = Funciones.CheckStr(dr["MATEV_DESCMATERIAL"]);					
					item.stockVenta = Funciones.CheckInt(dr["STOCN_LIBRE"]);
					item.tipoMaterial = Funciones.CheckStr(dr["MATEC_TIPOMATERIAL"]);

					filas.Add(item);
				}
				
			}
			catch (Exception ex)
			{
				throw (ex);
				//return ex.Message;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return filas;
		}


		public ArrayList ConsultarSerieMaterial(string pCodOficina,string pDesOficina,string pCodCentro,string pcodAlmacen,
						string pcodMaterial, string pdescMaterial,string pTipoOficina)
		{
			//Invocara al SP SSAPSS_SERIEXMATERIAL			
			DAABRequest.Parameter[] arrParam = {
											    new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_OFICV_DESCRIPCION", DbType.String, ParameterDirection.Input),
												//new DAABRequest.Parameter("K_SERIC_CODSERIE", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_OFICC_CODCENTRO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_OFICC_CODALMACEN", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_MATEC_CODMATERIAL", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_MATEV_DESCMATERIAL", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_OFICC_TIPOOFICINA", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_RESULT_SET", DbType.Object, ParameterDirection.Output)											   
											   };

			for (int i = 0; i < arrParam.Length; i++){
				arrParam[i].Value = DBNull.Value;
			}			
			BEParametroOficina oPar = ParametrosOficina(pCodOficina);
			arrParam[0].Value = oPar.codigoOficinaMSSAP; //pCodOficina;
			arrParam[1].Value = "";//pDesOficina;
			arrParam[2].Value = oPar.codigoCentro;//pCodCentro; 
			arrParam[3].Value = oPar.codigoAlmacen;//pcodAlmacen; 
			arrParam[4].Value = pcodMaterial; HelperLog.CrearArchivolog("LOG_ConsultarSerieMaterial",arrParam[4].Value.ToString(),"","","");
			arrParam[5].Value = pdescMaterial; HelperLog.CrearArchivolog("LOG_ConsultarSerieMaterial","","","","");
			arrParam[6].Value = oPar.TipoOficina; HelperLog.CrearArchivolog("LOG_ConsultarSerieMaterial",arrParam[6].Value.ToString(),"","","");

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP+ Constantes.MSSapSeriesMaterial;//dga
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapSeriesMaterial;

			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				if (dr != null)
				{
					while (dr.Read())
					{	
						//BEConsultaSerieMaterial item = new BEConsultaSerieMaterial();
						ItemGenerico item = new ItemGenerico();
						//item.Codigo = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
						item.Codigo = Funciones.CheckStr(dr["SERIC_CODSERIE"]);
						item.Descripcion = Funciones.CheckStr(dr["MATEV_DESCMATERIAL"]);
						item.Codigo2 = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
						item.serie = Funciones.CheckStr(dr["SERIC_CODSERIE"]);
						item.tipoMaterial = Funciones.CheckStr(dr["MATEC_TIPOMATERIAL"]);

						filas.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}


			return filas;
		}

		
		public ItemGenerico ConsultarSerie(string pcodSerie)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_SERIC_CODSERIE", DbType.String, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_RESULT_SET", DbType.Object, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}
			arrParam[0].Value = pcodSerie;
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + Constantes.MSSapValidaSeries;//dga
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapValidaSeries;

			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);
			
			ItemGenerico item = new ItemGenerico();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				if (dr != null)
				{	
					while (dr.Read())
					{	
						//item = new BEArticulo();
						item = new ItemGenerico();						
						item.Codigo = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
						item.Descripcion = Funciones.CheckStr(dr["MATEV_DESCMATERIAL"]);
						item.serie = Funciones.CheckStr(dr["SERIC_CODSERIE"]);
						item.estado = Funciones.CheckStr(dr["SERIC_ESTADO"]);
						item.PuntoVenta = Funciones.CheckStr(dr["OFICV_CODOFICINA"]);						
						item.Tipo = Funciones.CheckStr(dr["MATEC_TIPOMATERIAL"]);
						item.CodInterlocutor = Funciones.CheckStr(dr["INTEV_CODPADRE"]);
						
					}
				}
			}
			catch (Exception ex)
			{
				//CAMBIO!!!
				item=null;
				HelperLog.CrearArchivolog("Error en el Catch:",ex.Message,"","","");

			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return item;
		}


		//05102015 SSAPSS_OFICINA

		public ItemGenerico ConsultarSerieXPDV(string strCodOficina, string strDesOficina)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_OFICV_DESCRIPCION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULT_SET", DbType.Object, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}

			arrParam[0].Value = strCodOficina; //pCodOficina;
			arrParam[1].Value = strDesOficina;//pDesOficina;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_OFICINA";//dga
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapValidaSeries;

			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);
			ItemGenerico item = new ItemGenerico();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				if (dr != null)
				{	
					while (dr.Read())
					{	
						//item = new BEArticulo();
						item = new ItemGenerico();						
						item.Codigo = Funciones.CheckStr(dr["OFICV_CODOFICINA"]);
						item.Descripcion = Funciones.CheckStr(dr["OFICV_DESCRIPCION"]);
						item.CodInterlocutorPadre = Funciones.CheckStr(dr["INTEV_CODPADRE"]);
						
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return item;
		}

		//05102015


		public BEParametroOficina ParametrosOficina(string sCodigoOficina)
		{
			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String, ParameterDirection.Input),					
					new DAABRequest.Parameter("K_SALIDA", DbType.Object, ParameterDirection.Output) };

			int i = 0;

			for (i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;     
			
			arrParam[0].Value = sCodigoOficina;			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;			
			obRequest.Command = BaseDatos.SISACT_PKG_NUEVA_LISTAPRECIOS + ".SISACS_DATOS_OFICINA"; 
			obRequest.Parameters.AddRange(arrParam);
			
			BEParametroOficina item = new BEParametroOficina();
			
			IDataReader dr = null;  
			try
			{                   
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while (dr.Read())
					{
						item = new BEParametroOficina();
						item.codigoOficinaVenta = Funciones.CheckStr(dr["OVENC_CODIGO"]);
						item.canal = Funciones.CheckStr(dr["CANAC_CODIGO"]);
						item.CodigoTipoProducto = Funciones.CheckStr(dr["TPROC_CODIGO"]);
						item.DescripcionOficina = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
						item.TipoOficina = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
						item.CodigoUsuario = Funciones.CheckStr(dr["OVENV_CODUSUARIO"]);
						item.CodigoRegion = Funciones.CheckStr(dr["DEPAC_CODIGO"]);
						item.CodigoInterlocutor = Funciones.CheckStr(dr["OVENV_CODIGO_SINERGIA"]);						
					}
					
					BEParametroOficina itemMSSAP = ParametrosOficinaMSSAP(item.CodigoInterlocutor);

					if (itemMSSAP != null )
					{
						item.codigoOficinaMSSAP=itemMSSAP.codigoOficinaVenta;
						item.codigoCentro = itemMSSAP.codigoCentro;
						item.codigoAlmacen = itemMSSAP.codigoAlmacen;
						item.CodigoRegion = itemMSSAP.CodigoRegion ;
						item.orgVenta = itemMSSAP.orgVenta ;
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return item;
		}
		private BEParametroOficina ParametrosOficinaMSSAP(string sCodigoOficina)
		{
			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String, ParameterDirection.Input),					
					new DAABRequest.Parameter("K_OFICV_DESCRIPCION", DbType.String, ParameterDirection.Input),					
					new DAABRequest.Parameter("K_RESULT_SET", DbType.Object, ParameterDirection.Output) };
			
			int i = 0;

			for (i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;     
			
			arrParam[0].Value = sCodigoOficina;			

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;			
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_OFICINA"; 
			obRequest.Parameters.AddRange(arrParam);

			BEParametroOficina item = new BEParametroOficina();
			
			IDataReader dr = null;  
			try
			{                   
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while (dr.Read())
					{
						item = new BEParametroOficina();
						item.codigoOficinaVenta = Funciones.CheckStr(dr["OFICV_CODOFICINA"]);
						item.DescripcionOficina = Funciones.CheckStr(dr["OFICV_DESCRIPCION"]);
						item.codigoCentro = Funciones.CheckStr(dr["OFICC_CODCENTRO"]);
						item.codigoAlmacen = Funciones.CheckStr(dr["OFICC_CODALMACEN"]);
						item.CodigoRegion = Funciones.CheckStr(dr["OFICC_REGION"]);
						item.orgVenta = Funciones.CheckStr(dr["OFICC_ORGVENTA"]);                        
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return item;
		}

		public ItemGenerico ConsultaPrecioBase(string codMaterial, string desMaterial)
		{
			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("K_MATEC_CODMATERIAL", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("K_MATEV_DESCMATERIAL", DbType.String, ParameterDirection.Input),					
					new DAABRequest.Parameter("K_RESULT_SET", DbType.Object, ParameterDirection.Output)
				};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codMaterial;
			arrParam[1].Value = desMaterial;			

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP+ Constantes.MSSapPreciosBase;//dga
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapPreciosBase;
			

			obRequest.Parameters.AddRange(arrParam);
			
			//ArrayList filas = new ArrayList();
			IDataReader dr = null;
			ItemGenerico item = new ItemGenerico();
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{					
					item = new ItemGenerico();	
					item.Codigo = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
					item.Descripcion = Funciones.CheckStr(dr["MATEV_DESCMATERIAL"]);
					item.PrecioBase = Funciones.CheckDbl(dr["MATEN_PRECIOBASE"]);
					item.PrecioCompra = Funciones.CheckDbl(dr["MATEN_PRECIOCOMPRA"]);					
					//filas.Add(item);
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return item;			
		}
		

		public ItemGenerico ConsultaPrecioVenta(string codMaterial,string codSerie,double preBase,double preVenta)
		{

			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("K_PREVC_CODMATERIAL", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("K_PREVC_CODSERIE", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("K_PREVN_PRECIOBASE", DbType.Decimal, ParameterDirection.Input),
					new DAABRequest.Parameter("K_PREVN_PRECIOVENTA", DbType.Decimal, ParameterDirection.Input),
					new DAABRequest.Parameter("K_PREVC_CODMATERIAL_OUT", DbType.String, ParameterDirection.Output),
					new DAABRequest.Parameter("K_PREVV_DESCRIPCION_OUT", DbType.String, ParameterDirection.Output),
					new DAABRequest.Parameter("K_PREVC_CODSERIE_OUT", DbType.String, ParameterDirection.Output),
					new DAABRequest.Parameter("K_PREVN_PRECIOBASE_OUT", DbType.Decimal, ParameterDirection.Output),
					new DAABRequest.Parameter("K_PREVN_PRECIOVENTA_OUT", DbType.Decimal, ParameterDirection.Output),
					new DAABRequest.Parameter("K_PREVN_DESCUENTO_OUT", DbType.Decimal, ParameterDirection.Output),
					new DAABRequest.Parameter("K_PREVN_IGV_OUT", DbType.Decimal, ParameterDirection.Output),
					new DAABRequest.Parameter("K_PREVN_TOTAL_OUT", DbType.Decimal, ParameterDirection.Output)
				};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

//			arrParam[0].Value = codMaterial;			
//			arrParam[1].Value = codSerie;
//			arrParam[2].Value = preBase;
//			arrParam[3].Value = preVenta;

			arrParam[0].Value = codMaterial;
			arrParam[1].Value = codSerie;
			arrParam[2].Value = preBase;
			arrParam[3].Value = preVenta;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + Constantes.MSSapPrecioVenta;//dga
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapPrecioVenta;

			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);
			
			//ArrayList filas = new ArrayList();
			IDataReader dr = null;
			ItemGenerico item = new ItemGenerico();
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;		
				if (dr != null)
				{
//					while(dr.Read())
//					{							
						item = new ItemGenerico();
						item.Codigo = codMaterial;
						item.Descripcion = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);
						item.PrecioBase = preBase;
						item.PrecioCompra = preVenta;
						item.CodMaterial_Out  = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[4]).Value);
						item.Descripcion_Out = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);
						item.CodSerie_Out = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[6]).Value);
						item.PrecioBase_Out = Convert.ToDecimal(((IDataParameter)obRequest.Parameters[7]).Value);
						item.PrecioVenta_Out = Convert.ToDecimal(((IDataParameter)obRequest.Parameters[8]).Value);
						item.Descuento_Out = Convert.ToDecimal(((IDataParameter)obRequest.Parameters[9]).Value);
						item.Igv_Out = Convert.ToDecimal(((IDataParameter)obRequest.Parameters[10]).Value);
						item.Total_Out = Convert.ToDecimal(((IDataParameter)obRequest.Parameters[11]).Value);
						//filas.Add(item);
//					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return item;			
		}
		

		public DataSet ConsultaCliente(string tipoDocCliente, string nroDocCliente)
		{
			DataSet dtbLista;
			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("K_CLIEC_TIPODOCCLIENTE", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("K_CLIEV_NRODOCCLIENTE", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("CU_CLIENTE", DbType.Object, ParameterDirection.Output) };


			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = tipoDocCliente;
			arrParam[1].Value = nroDocCliente;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + Constantes.MSSapDatosCliente;//dga			
			//obRequest.Command = BaseDatos.PkgMSSap + Constantes.MSSapDatosCliente;
			obRequest.Parameters.AddRange(arrParam);

			//BEClienteSAP oConsultaCliente = null;

			try
			{
				dtbLista = obRequest.Factory.ExecuteDataset(ref obRequest); //.Tables[0];
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dtbLista;
		}


		public ArrayList ConsultarPoolPagos(string strCadenaParametros)
		{
		
			//BEParametroOficina oConsultaParametrosOficina = ConsultaParametrosOficina(Funciones.CheckStr(strCadenaParametros.Split(';')[2]),null);


			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("K_PEDIC_ESTADO", DbType.String, ParameterDirection.Input),
					new DAABRequest.Parameter("K_PEDID_FECHADOCUMENTO", DbType.Date, ParameterDirection.Input),
					new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String, ParameterDirection.Input),					
					new DAABRequest.Parameter("CU_ESTADOPEDIDO", DbType.Object, ParameterDirection.Output)					
				};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
		
			arrParam[0].Value = Funciones.CheckStr(strCadenaParametros.Split(';')[0]);
			arrParam[1].Value = Funciones.CheckDate(strCadenaParametros.Split(';')[1]).ToString("dd/MM/yyyy");
			arrParam[2].Value = "0004070046";

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_DIP_POOLPAGOS";//dga
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSS_DIP_POOLPAGOS";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;		

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					Documento item = new Documento();
					item.DOCUMENTO_SAP = Funciones.CheckStr(dr["PEDIN_NROPEDIDO"]);
					item.FECHA = Funciones.CheckStr(dr["PEDID_FECHADOCUMENTO"]);
					item.NOMBRE_CLIENTE = Funciones.CheckStr(dr["PEDIV_NOMBRECLIENTE"]);
					item.IMPORTE = Funciones.CheckDbl(dr["INPAN_TOTALDOCUMENTO"]);
					item.SALDO = Funciones.CheckDbl(dr["PEDIN_SALDO"]);
					item.TIPO_DOCUMENTO_DES = Funciones.CheckStr(dr["PEDIV_DESCCLASEFACTURA"]);
					item.FACTURA_SUNAT = Funciones.CheckStr(dr["PAGOC_CODSUNAT"]).Replace("*","");
					try { if (Funciones.CheckInt(item.FACTURA_SUNAT) == 0) {item.FACTURA_SUNAT = ""; } }
					catch{}
					item.UTILIZACION =String.Empty;
					item.UTILIZACION_DES = String.Empty;
					item.CUOTAS = String.Empty;
					item.MONEDA = Funciones.CheckStr(dr["PEDIC_MONEDA"]);
					item.NETO = Funciones.CheckDbl(dr["INPAN_TOTALMERCADERIA"]);
					item.IMPUESTO = Funciones.CheckDbl(dr["INPAN_TOTALIMPUESTO"]);
					item.PAGOS = Funciones.CheckDbl(dr["PEDIN_PAGO"]);
					item.NRO_DEP_GARANTIA = String.Empty;
					item.NRO_REF_DEP_GAR = String.Empty;
					item.FLAG_REPOSICION="N";


					//------------------------------------Agregar Campo Nro Celular - Oliver Rivera ------------------------------------//

					item.NRO_CELULAR = String.Empty;						

					//------------------------------------Agregar Campo Nro Celular - Oliver Rivera ------------------------------------//


					item.NRO_CONTRATO = item.DOCUMENTO_SAP;// Funciones.CheckStr(dr["NRO_CONTRATO"]);
					if (Funciones.IsContratoVacio(item.NRO_CONTRATO)) 
					{
						item.NRO_CONTRATO = string.Empty;
						item.NRO_SEC = item.DOCUMENTO_SAP;//oConsultaExpressPorta.ObtenerSecByPedido(item.DOCUMENTO_SAP);
					}
					else 
					{
						item.NRO_SEC = new VentaExpressDatos().ObtenerSecMSSAP(item.NRO_CONTRATO);//oConsulta.ObtenerSec(item.NRO_CONTRATO);
						if (item.NRO_SEC == "") 
						{
							//item.NRO_SEC = oConsultaExpressPorta.ObtenerSecByContrato(item.NRO_CONTRATO);
						}
						//item.NRO_SEC=item.DOCUMENTO_SAP;
					}

					try
					{
//						listaPlanes = oConsulta.ListarPlanesSolicitudPersona(item.NRO_SEC);
//						foreach(PlanDetalleConsumer plan in listaPlanes) 
//						{
//							string CodPlan = Funciones.CheckStr(plan.PLANC_CODIGO);
//							string planes2PlayCorp = ConfigurationSettings.AppSettings["CodPlanes2PlayCorporativo"];
//							if (planes2PlayCorp.IndexOf(";" + CodPlan + ";") > -1)
//							{
//								item.FLAG = "1";
//							}
//						}
					}
					catch{}

					String sNroPedido = item.DOCUMENTO_SAP;
					String sNroContrato = item.NRO_CONTRATO;
					String sTipoDocumento = Funciones.CheckStr(dr["PEDIC_CLASEFACTURA"]);
					//Para saber si es DL o DE
					if(sTipoDocumento == "DG")
					{
//						DataSet dsTipoDocumento = ConsultarTipoGarantia("",sNroContrato);
//						if(dsTipoDocumento.Tables[0].Rows.Count>0)
//						{
//							sTipoDocumento = dsTipoDocumento.Tables[0].Rows[0].ItemArray[18].ToString();
//						}
					}
					item.CLASE_FACTURA = sTipoDocumento;
					filas.Add(item);
				}

			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

		//Flujo DRA 14/10/2015
		public bool ObtenerInterlocutorPadre(string codInterlocutor, ref string codInterlocutorPadre)
		{
			DAABRequest.Parameter[] arrParam ={	new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("K_INTEV_CODPADRE", DbType.String, ParameterDirection.Output)
											  };

			bool retorno = false;
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = codInterlocutor;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_CONSULTAPADRE_INTER";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);

				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[1];
				codInterlocutorPadre = Funciones.CheckStr(parSalida.Value);

				retorno = true;
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

			return retorno;
		}

	}
}
