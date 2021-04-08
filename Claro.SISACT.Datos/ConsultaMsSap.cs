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
	/// Descripción breve de ConsultaMsSap.
	/// </summary>
	public class ConsultaMsSap
	{
		public ConsultaMsSap()
		{
			
		}

		public ArrayList ConsultaVendedores(String oficinaVenta)
		{
           
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("K_VENDC_CODVENDEDOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_OFICC_CODIGOOFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("CU_VENDEDOR", DbType.Object , ParameterDirection.Output),
												   new DAABRequest.Parameter("K_NRO_ERROR", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DES_ERROR", DbType.String, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = oficinaVenta;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_VENDEDOR";            
			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;

			ArrayList filas = new ArrayList();

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while (dr.Read())
					{
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["CODVENDEDOR"]);
						item.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
						filas.Add(item);
					}
				}
			}
			catch
			{
				throw;
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

		public ArrayList ConsultarListaPrecio(string strCodProducto, string strTipoVenta, string strTipoOficina, string strCodDepartamento,
											  string strCodMaterial, string strCodCampania, string intTipoOperacion, string strCodPlazo, string strCodPlan)
		{
			DAABRequest.Parameter[] arrParam = { 
				new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_CANAC_CODIGO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_DEPARTAMENTO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_MATEC_CODIGO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_CAMPC_CODIGO", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_TOPEC_CODIGO", DbType.String, ParameterDirection.Input),                                                  
				new DAABRequest.Parameter("P_PLAZC_CODIGO", DbType.String, ParameterDirection.Input),                                                  
				new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, ParameterDirection.Input),    
				new DAABRequest.Parameter("K_SALIDA", DbType.Object, ParameterDirection.Output) 
			};
			int i = 0;

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			i = 0;

			arrParam[i].Value = strCodProducto;
			i++; arrParam[i].Value = strTipoVenta;
			i++; arrParam[i].Value = strTipoOficina;
			i++; arrParam[i].Value = strCodDepartamento;
			i++; arrParam[i].Value = strCodMaterial;
			i++; arrParam[i].Value = strCodCampania;
			i++; arrParam[i].Value = intTipoOperacion;
			i++; arrParam[i].Value = strCodPlazo;
			i++; arrParam[i].Value = strCodPlan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_NUEVA_LISTAPRECIOS + ".SISACSS_CONSULTAR_LISTAPRECIOS";
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
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["LIPRN_CODIGOLISTAPRECIO"]);
						item.Descripcion = Funciones.CheckStr(dr["LIPRV_DESCRIPCION"]);
						item.Monto = Funciones.CheckDbl(dr["MATED_PRECIOVENTA"]);
						item.Valor = Funciones.CheckDbl(dr["MATED_PRECIOVENTA"]);
						filas.Add(item);
					}
				}
			}
			catch
			{
				throw;
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

			BEParametroOficina oPar = ConsultaParametrosOficina(pcodOficina,"");            
			arrParam[0].Value = oPar.cPuntoVentaSinergia; //pcodOficina;
			arrParam[1].Value = string.Empty;//pdesOficina;
			arrParam[2].Value = oPar.TipoOficina;			
		
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_STOCK";

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

		public ArrayList ConsultarSerieMaterial(string strCodigoOficinaMSSAP,string strCodigoAlmacen, string strCodigoCentro,Int32 intCantidad, string strCodigoMaterial,string strTipoVenta)
		{


			DAABRequest.Parameter[] arrParam = {    new DAABRequest.Parameter("K_OFICC_CODIGOOFICINA", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_OFICC_CODIGOALMACEN", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_OFICC_CENTRO", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_CANTIDAD", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("K_MATEC_CODMATERIAL", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_STOCC_TIPOVENTA", DbType.String, ParameterDirection.Input),
												new DAABRequest.Parameter("K_NRO_ERROR", DbType.Int32, ParameterDirection.Output),
												new DAABRequest.Parameter("K_DES_ERROR", DbType.String, ParameterDirection.Output),                                                    
												new DAABRequest.Parameter("K_CU_SERIE", DbType.Object, ParameterDirection.Output)
											};

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}

			arrParam[0].Value = strCodigoOficinaMSSAP;
			arrParam[1].Value = strCodigoAlmacen;
			arrParam[2].Value = strCodigoCentro;
			arrParam[3].Value = intCantidad;
			arrParam[4].Value = strCodigoMaterial;
			arrParam[5].Value = strTipoVenta;            

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_SERIEXMATERIAL";

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
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["SERIC_CODIGOSERIE"]);
						item.Descripcion = Funciones.CheckStr(dr["SERIC_CODIGOSERIE"]);                                              
						filas.Add(item);
					}
				}
			}

			catch
			{
				throw;
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

		public PreciosMateriales Get_PrecioVenta(string strCodigoMaterial,string strSerieMaterial,decimal dblPrecioBaseMaterial,decimal dblPrecioVentaMaterial)
		{
			PreciosMateriales itemPreciosVenta = new PreciosMateriales();
			DAABRequest.Parameter[] arrParam = {
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
												   new DAABRequest.Parameter("K_PREVN_TOTAL_OUT", DbType.Double, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
			{ arrParam[i].Value = DBNull.Value; }

			arrParam[0].Value = strCodigoMaterial;
			arrParam[1].Value = strSerieMaterial;
			arrParam[2].Value = dblPrecioBaseMaterial;
			arrParam[3].Value = dblPrecioVentaMaterial;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_PREVENTA";
			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				if (dr != null)
				{
					itemPreciosVenta.CodigoMaterial = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[4]).Value);
					itemPreciosVenta.descripcionMaterial = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);
					itemPreciosVenta.SerieMaterial = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[6]).Value);
					itemPreciosVenta.decPrecioBase = Funciones.CheckDecimal(((IDataParameter)obRequest.Parameters[7]).Value);
					itemPreciosVenta.decPrecioVenta = Funciones.CheckDecimal(((IDataParameter)obRequest.Parameters[8]).Value);
					itemPreciosVenta.decDescuentos = Funciones.CheckDecimal(((IDataParameter)obRequest.Parameters[9]).Value);
					itemPreciosVenta.decValorIgv = Funciones.CheckDecimal(((IDataParameter)obRequest.Parameters[10]).Value);
					itemPreciosVenta.decTotal = Funciones.CheckDecimal(((IDataParameter)obRequest.Parameters[11]).Value);
					itemPreciosVenta.PrecioBaseMaterial =  Funciones.CheckDecimal(dblPrecioBaseMaterial);                    
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return itemPreciosVenta;
		}

		public ArrayList ConsultaPrecioBaseMaterial(string strCodigoMaterial)
		{

			DAABRequest.Parameter[] arrParam = {    new DAABRequest.Parameter("K_MATEC_CODMATERIAL", DbType.String, ParameterDirection.Input),                                                    
												   new DAABRequest.Parameter("K_MATEV_DESCMATERIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULT_SET", DbType.Object,ParameterDirection.Output)
												   //dga
//												   new DAABRequest.Parameter("K_NRO_ERROR", DbType.Int32, ParameterDirection.Output),
//												   new DAABRequest.Parameter("K_DES_ERROR", DbType.String, ParameterDirection.Output),
//												   new DAABRequest.Parameter("K_CU_PRECIOBASE", DbType.Object, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}
            
			arrParam[0].Value = strCodigoMaterial;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_PRECIOBASE";

			obRequest.Parameters.AddRange(arrParam);

			ArrayList oBePrecioMaterial = new ArrayList();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				if (dr != null)
				{
					while (dr.Read())
					{
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["MATEC_CODMATERIAL"]);
						item.Descripcion = Funciones.CheckStr(dr["MATEV_DESCMATERIAL"]);
						//item.Descripcion = Funciones.CheckStr(dr["MATEV_DENOMINACION"]);dga
 						item.Monto = Funciones.CheckDbl(dr["MATEN_PRECIOBASE"]);
						item.Valor = Funciones.CheckDbl(dr["MATEN_PRECIOCOMPRA"]);
						//item.Valor = Funciones.CheckDbl(dr["MATEN_PRECIOPROMEDIO"]);dga
						oBePrecioMaterial.Add(item);
					}
				}
			}

			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return oBePrecioMaterial;
		}

		public ArrayList ConsultarPrecioMaterial(string codLista, string codMaterial)
		{
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("P_LIPRN_CODIGO", DbType.String, ParameterDirection.Input),
												 new DAABRequest.Parameter("P_MATEC_CODIGO", DbType.String, ParameterDirection.Input),
												 new DAABRequest.Parameter("K_SALIDA", DbType.Object, ParameterDirection.Output) };
			int i = 0;

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			i = 0;

			arrParam[i].Value = codLista;
			i++; arrParam[i].Value = codMaterial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_NUEVA_LISTAPRECIOS + ".SISACSS_CON_LISTAXMATERIAL";
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
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["LIPRN_CODIGOLISTAPRECIO"]);
						item.Descripcion = Funciones.CheckStr(dr["LIPRV_DESCRIPCION"]);
						item.Monto = Funciones.CheckDbl(dr["MATED_PRECIOVENTA"]);
						filas.Add(item);
					}
				}
			}
			catch
			{
				throw;
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

		public DataSet ParametrosOficinaVenta(string oficina)
		{
			DataSet dsParametros = new DataSet();
			//ssapss_grupomaterial

			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("K_OFICC_CODIGOOFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NRO_ERROR", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DES_ERROR", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CU_PARAMETRO", DbType.Object, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oficina;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".ssapss_parametrooficina";
			obRequest.Parameters.AddRange(arrParam);
		
		
			try
			{
				dsParametros = obRequest.Factory.ExecuteDataset(ref obRequest);
				
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return dsParametros;
		}

		public BECliente ConsultaCliente(string nroDocCliente, string tipodoccliente)
		{
			//Invocara al SP SSAPSS_CLIENTE     
		   
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("k_cliec_tipodoccliente", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("k_cliev_nrodoccliente", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("k_nrolog", DbType.Int32, ParameterDirection.Output),  
												   new DAABRequest.Parameter("k_deslog", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("k_cu_codcliente", DbType.Object, ParameterDirection.Output)
											   };


			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = tipodoccliente;
			arrParam[1].Value = nroDocCliente;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + ".SSAPSS_CLIENTE";
			obRequest.Parameters.AddRange(arrParam);

			BECliente oConsultaCliente = null;

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
		           

					while (dr.Read())
					{
						oConsultaCliente = new BECliente();
					{
						oConsultaCliente.Cliente = Funciones.CheckStr(dr["CLIEV_NRO_DOCUMENTO"]);
						oConsultaCliente.TipoDocCliente = Funciones.CheckStr(dr["CLIEC_TIPO_DOCUMENTO"]);
						oConsultaCliente.Nombre = Funciones.CheckStr(dr["CLIEV_NOMBRE"]);
						oConsultaCliente.ApellidoPaterno = Funciones.CheckStr(dr["CLIEV_APELLIDO_PATERNO"]);
						oConsultaCliente.ApellidoMaterno = Funciones.CheckStr(dr["CLIEV_APELLIDO_MATERNO"]);
						oConsultaCliente.RazonSocial = Funciones.CheckStr(dr["CLIEV_RAZON_SOCIAL"]);
						oConsultaCliente.FechaNacimiento = Funciones.CheckDate(dr["CLIED_FECHA_NACIMIENTO"]);
						oConsultaCliente.Telefono = Funciones.CheckStr(dr["CLIEV_TELEFONO"]);
						oConsultaCliente.EMail = Funciones.CheckStr(dr["CLIEV_E_MAIL"]);
						oConsultaCliente.Sexo = Funciones.CheckStr(dr["CLIEC_SEXO"]);
						oConsultaCliente.EstadoCivil = Funciones.CheckStr(dr["CLIEC_ESTADO_CIVIL"]);
						oConsultaCliente.titulo = Funciones.CheckStr(dr["CLIEC_TITULO"]);
						oConsultaCliente.CargaFamiliar = Funciones.CheckStr(dr["CLIEC_CARGA_FAMILIAR"]);
						oConsultaCliente.NombreConyuge = Funciones.CheckStr(dr["CLIEV_CONYUGE_NOMBRE"]);
						oConsultaCliente.ApePatConyuge = Funciones.CheckStr(dr["CLIEV_CONYUGE_APE_PAT"]);
						oConsultaCliente.ApeMatConyuge = Funciones.CheckStr(dr["CLIEV_CONYUGE_APE_MAT"]);
						oConsultaCliente.DireccionLegalPref = Funciones.CheckStr(dr["CLIEV_DIRECCION_LEGAL_PREF"]);
						oConsultaCliente.DireccionLegal = Funciones.CheckStr(dr["CLIEV_DIRECCION_LEGAL"]);
						oConsultaCliente.DireccionLegalRef = Funciones.CheckStr(dr["CLIEV_DIRECCION_LEGAL_REFER"]);
						oConsultaCliente.UbigeoLegal = Funciones.CheckStr(dr["CLIEV_UBIGEO_LEGAL"]);
						oConsultaCliente.TelefLegalPref = Funciones.CheckStr(dr["CLIEV_TELEF_LEGAL_PREF"]);
						oConsultaCliente.TelefLegal = Funciones.CheckStr(dr["CLIEV_TELEF_LEGAL"]);
						oConsultaCliente.DireccionFactPref = Funciones.CheckStr(dr["CLIEV_DIRECCION_FACT_PREF"]);
						oConsultaCliente.DireccionFact = Funciones.CheckStr(dr["CLIEV_DIRECCION_FACT"]);
						oConsultaCliente.DireccionFactRef = Funciones.CheckStr(dr["CLIEV_DIRECCION_FACT_REFER"]);
						oConsultaCliente.UbigeoFact = Funciones.CheckStr(dr["CLIEV_UBIGEO_FACT"]);
						oConsultaCliente.TelefFactPref = Funciones.CheckStr(dr["CLIEV_TELEF_FACT_PREF"]);
						oConsultaCliente.TeleFact = Funciones.CheckStr(dr["CLIEV_TELEF_FACT"]);
						oConsultaCliente.ReplegalTipDoc = Funciones.CheckStr(dr["CLIEC_REPLEGAL_TIPO_DOC"]);
						oConsultaCliente.ReplegalNroDoc = Funciones.CheckStr(dr["CLIEV_REPLEGAL_NRO_DOC"]);
						oConsultaCliente.ReplegalApePat = Funciones.CheckStr(dr["CLIEV_REPLEGAL_APE_PAT"]);
						oConsultaCliente.ReplegalApeMat = Funciones.CheckStr(dr["CLIEV_REPLEGAL_APE_MAT"]);
						oConsultaCliente.ReplegalNombre = Funciones.CheckStr(dr["CLIEV_REPLEGAL_NOMBRE"]);
						oConsultaCliente.ReplegalFnac = Funciones.CheckDate(dr["CLIED_REPLEGAL_FECHA_NAC"]);
						oConsultaCliente.ReplegalTelefon = Funciones.CheckStr(dr["CLIEV_REPLEGAL_TELEFONO"]);
						oConsultaCliente.ReplegalSexo = Funciones.CheckStr(dr["CLIEC_REPLEGAL_SEXO"]);
						oConsultaCliente.ReplegalEstCiv = Funciones.CheckStr(dr["CLIEC_REPLEGAL_EST_CIV"]);
						oConsultaCliente.ReplegalTitulo = Funciones.CheckStr(dr["CLIEC_REPLEGAL_TITULO"]);
						oConsultaCliente.ContactoTipDoc = Funciones.CheckStr(dr["CLIEC_CONTACTO_TIPO_DOC"]);
						oConsultaCliente.ContactoNroDoc = Funciones.CheckStr(dr["CLIEV_CONTACTO_NRO_DOC"]);
						oConsultaCliente.ContactoNombre = Funciones.CheckStr(dr["CLIEV_CONTACTO_NOMBRE"]);
						oConsultaCliente.ContactoApePat = Funciones.CheckStr(dr["CLIEV_CONTACTO_APE_PAT"]);
						oConsultaCliente.ContactoApeMat = Funciones.CheckStr(dr["CLIEV_CONTACTO_APE_MAT"]);
						oConsultaCliente.ContactoTelefon = Funciones.CheckStr(dr["CLIEV_CONTACTO_TELEFONO"]);
						oConsultaCliente.ClienCondCliente = Funciones.CheckInt(dr["CLIEN_COND_CLIENTE"]);
						oConsultaCliente.EmpresaCargo = Funciones.CheckStr(dr["CLIEV_EMPRESA_CARGO"]);
						oConsultaCliente.EmpresaTelefono = Funciones.CheckStr(dr["CLIEV_EMPRESA_TELEFONO"]);
						oConsultaCliente.IngBruto = Funciones.CheckDecimal(dr["CLIEN_INGRESO_BRUTO"]);
						oConsultaCliente.OtrosIngresos = Funciones.CheckDecimal(dr["CLIEN_OTROS_INGRESOS"]);
						oConsultaCliente.Tipocredito = Funciones.CheckStr(dr["CLIEV_TCREDITO_TIPO"]);
						oConsultaCliente.NumTarjCredito = Funciones.CheckStr(dr["CLIEV_TCREDITO_NUM"]);
						oConsultaCliente.MonedaTcred = Funciones.CheckStr(dr["CLIEC_TCREDITO_MONEDA"]);
						oConsultaCliente.LineaCredito = Funciones.CheckDecimal(dr["CLIEN_TCREDITO_LINEA_CRED"]);
						oConsultaCliente.FechaVencTcred = Funciones.CheckStr(dr["CLIEC_TCREDITO_FECHA_VENC"]);
						oConsultaCliente.Observaciones = Funciones.CheckStr(dr["CLIEV_OBSERVACIONES"]);
						oConsultaCliente.codigosap = Funciones.CheckStr(dr["CLIEV_CODIGO_SAP"]);
						oConsultaCliente.vendsap = Funciones.CheckStr(dr["CLIEV_VENDEDOR_SAP"]);
						oConsultaCliente.usuario = Funciones.CheckStr(dr["CLIEV_USUARIO_CREA"]);
						oConsultaCliente.fechacrea = Funciones.CheckStr(dr["CLIED_FECHA_CREA"]);
						oConsultaCliente.TipoCliente = Funciones.CheckStr(dr["cliev_tipo_cliente"]);
					}
					}
				}
			}
			catch
			{

				throw;
			}
			finally
			{
				if (dr != null && dr.IsClosed == false)
					dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return oConsultaCliente;
		}
		//ini sinergia 6.0

		public Int64 RegistrarPedido(string CadenaCabecera, ref string codResp, ref string msgResp)
		{
			int i;
			Int64 nroPedidoMsSap = 0;
			string[] arrDBAcuerdo = CadenaCabecera.Split(Convert.ToChar(";"));

DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ORGVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CANALVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_SECTOR", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOVENTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHADOCUMENTO", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_MOTIVOPEDIDO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CLASEFACTURA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESCCLASEFACTURA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESTINOMERCADERIA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CLASEPEDIDO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CODTIPOOPERACION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESCTIPOOPERACION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHAENTREGA", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_SISTEMAVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_CODVENDEDOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESTADO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ISRENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_PEDIDOALTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_UBIGEO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESQUEMACALCULO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPODOCCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NRODOCCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NOMBRECLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_PATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_MATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_NACIMIENTOCLIENTE",DbType.Date , ParameterDirection.Input),//D
												   new DAABRequest.Parameter("K_PEDIV_RAZONSOCIAL", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_CORREOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_TELEFONOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESTADOCIVILCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DIRECCIONCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_NUMEROCALLE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DISTRITOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CODDPTOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_PAISCLIENTE", DbType.String,  ParameterDirection.Input),                                                   
												   new DAABRequest.Parameter("K_PEDIC_RLTIPODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLNRODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLPATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLMATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLNOMBRE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOOFICINA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ISSISCAD", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_USUARIOCREA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHACREA", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_USUARIOMODI", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHAMODI", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIC_FLAGLP", DbType.String, ParameterDirection.Input), 
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,  ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String, ParameterDirection.Output)
											   };

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			for (i = 0; i < arrDBAcuerdo.Length; i++)
			{
				if (arrDBAcuerdo[i]!= null  &&  arrDBAcuerdo[i].Trim() != "")
				{
					if (arrParam[i].DbType== DbType.DateTime )
					{
						arrParam[i].Value = Funciones.CheckDate(arrDBAcuerdo[i]).ToLongDateString();
					}
					if (arrParam[i].DbType== DbType.Date )
					{
						arrParam[i].Value = Funciones.CheckDate(arrDBAcuerdo[i]).ToShortDateString();
					}	
					else if (arrParam[i].DbType== DbType.Decimal)
					{
						arrParam[i].Value = Funciones.CheckDecimal(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Double)
					{
						arrParam[i].Value = Funciones.CheckDbl(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Int64)
					{
						arrParam[i].Value = Funciones.CheckInt64(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Int32)
					{
						arrParam[i].Value = Funciones.CheckInt(arrDBAcuerdo[i]);
					}
					else
					{
						arrParam[i].Value = arrDBAcuerdo[i];
					}
				}
			}

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSI_PEDIDO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter pSalida0;
				IDataParameter pSalida1;
				IDataParameter pSalida2;
				pSalida0 = (IDataParameter)obRequest.Parameters[51];
				pSalida1 = (IDataParameter)obRequest.Parameters[52];
				pSalida2 = (IDataParameter)obRequest.Parameters[53];
				nroPedidoMsSap = Funciones.CheckInt64(pSalida0.Value);
				codResp = Funciones.CheckStr(pSalida1.Value);
				msgResp = Funciones.CheckStr(pSalida2.Value);
			}
			catch (Exception ex)
			{
				codResp = "-99";
				msgResp = ex.Message.ToString();
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return nroPedidoMsSap;
		}


		public int RegistrarPedidoDetalle(Int64 idPedido, string cadenaDetalle)
		{
			int i = 0, codResp;
			string[] arrDBAcuerdo = cadenaDetalle.Split(Convert.ToChar(";"));
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String,10,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_SERIC_CODSERIE", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEC_CODMATERIAL", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_DESCMATERIAL", DbType.String,200,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_CANTIDAD", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_PRECIOVENTA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_NROTELEFONO", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_NROCLARIFY", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_NRORENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_TOTALRENTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_NROCUOTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_CODIGOLP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_DESCRIPCIONLP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_USUARIOCREA", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPED_FECHACREA", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_USUARIOMODI", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPED_FECHAMODI", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEC_CENTROCOSTO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,300,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String,3000,ParameterDirection.Output)
				                                   
											   };


			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSI_DETALLEPEDIDO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			for (i = 0; i < arrDBAcuerdo.Length; i++)
			{
				if (arrDBAcuerdo[i].Trim() != "")
					arrParam[i].Value = arrDBAcuerdo[i].Trim();
			}
			arrParam[0].Value = idPedido;

			if (arrDBAcuerdo[16].Trim() != "")
				arrParam[16].Value = Funciones.CheckDate(arrDBAcuerdo[16].Trim());

			if (arrDBAcuerdo[18].Trim() != "")
				arrParam[18].Value = Funciones.CheckDate(arrDBAcuerdo[18].Trim());


			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida0;
				IDataParameter pSalida1;
				pSalida0 = (IDataParameter)obRequest.Parameters[20];
				pSalida1 = (IDataParameter)obRequest.Parameters[21];
				codResp = Funciones.CheckInt(pSalida0.Value);
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

		public bool GrabarInfoRentaSAP(Int64 nroPedidoMSSAP, Int32 nroCuotasSEC, double dblMontoRenta, string strNroRentaSAP)
		{
			int nroError =0;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDII_NROINTERNO_PEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_CUOTAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_MONTO_RENTA", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NRO_DOC_SAP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NRO_ERROR", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DES_ERROR", DbType.String, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = nroPedidoMSSAP;
			arrParam[1].Value = nroCuotasSEC;
			arrParam[2].Value = dblMontoRenta;
			arrParam[3].Value = strNroRentaSAP;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_PEDIDO + ".SSAPSU_RENTAADELANTADA";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				nroError = Funciones.CheckInt(((IDataParameter)obRequest.Parameters[4]).Value);
				string desError = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);
				if (nroError != 0)
				{
					throw new Exception(desError);
				}				
			}
			catch 
			{
				throw;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return nroError > 0;
		}

		public DataSet ConsultaAcuerdo(string nrocontrato, string nrosubcontrato)
		{
			DataSet dtResultado = new DataSet();
			DataTable dt = new DataTable();
			DAABRequest.Parameter[] arrParam = 
				{
					new DAABRequest.Parameter("p_nro_contrato", DbType.Int32, ParameterDirection.Input),
					new DAABRequest.Parameter("p_nro_sub_contrato", DbType.Int32, ParameterDirection.Input),
					new DAABRequest.Parameter("p_cod_resp", DbType.String, ParameterDirection.Output),
					new DAABRequest.Parameter("p_msg_resp", DbType.String, ParameterDirection.Output),
					new DAABRequest.Parameter("c_contrato", DbType.Object, ParameterDirection.Output),
					new DAABRequest.Parameter("c_contrato_det", DbType.Object, ParameterDirection.Output),
					new DAABRequest.Parameter("c_contrato_serv", DbType.Object, ParameterDirection.Output),
					new DAABRequest.Parameter("c_direccion", DbType.Object, ParameterDirection.Output),
					new DAABRequest.Parameter("c_garantia", DbType.Object, ParameterDirection.Output)
				};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = Convert.ToInt32(nrocontrato);
			arrParam[1].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_ACUERDO + ".sp_con_acuerdos";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{		
				dtResultado = obRequest.Factory.ExecuteDataset(ref obRequest);
			}
			catch(Exception ex)
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

		//-inicio-dga-03082015
		public DataSet ConsultaPedido(string nropedido, string codoficina)
		{
			//Invocara al SP SSAPSS_PEDIDO     
			
			DataSet dsResultado = new DataSet();
			DataTable dt = new DataTable();
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int32, ParameterDirection.Input),
											   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULT_HEADER", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_RESULT_DETAIL", DbType.Object, ParameterDirection.Output) 
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			DAConsultaMsSap Ofi = new DAConsultaMsSap();
			arrParam[0].Value = Convert.ToInt32(nropedido);

			codoficina = Funciones.CheckStr(codoficina);

			if (codoficina != "")	
			{	

				BEParametroOficina oPar = Ofi.ParametrosOficina(codoficina);
		
			if (oPar.TipoOficina==System.Configuration.ConfigurationSettings.AppSettings["constCodTipoCAC"])
			{
			arrParam[1].Value = oPar.cPuntoVentaSinergia;
			}
			else		
			{
				arrParam[2].Value = oPar.CodigoInterlocutor;
			}
		
			}

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
                        obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_PEDIDO";
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSS_PEDIDO";
			obRequest.Parameters.AddRange(arrParam);
		
			try
			{
				dsResultado = obRequest.Factory.ExecuteDataset(ref obRequest);
				
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return dsResultado;
		}

		public double ConsultaDetallePrecio(string nropedido, string strNroSerie, ref string strNroError, ref string strDesError) //SD_644347 - CUOTAS - INICIO
		{
			//Invocara al SP SSAPSS_PEDIDO     
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DESCC_CODSERIE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_MONTO", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String, ParameterDirection.Output) 
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = Convert.ToInt32(nropedido);
			arrParam[1].Value = strNroSerie;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_MONTOXEQUIPO";
			obRequest.Parameters.AddRange(arrParam);
			double dblMonto = 0;

			try
			{
				obRequest.Factory.ExecuteReader(ref obRequest);

				IDataParameter parSalMonto, parSalNLog, parSalDLog;
				parSalMonto = (IDataParameter)obRequest.Parameters[2];
				parSalNLog = (IDataParameter)obRequest.Parameters[3];
				parSalDLog = (IDataParameter)obRequest.Parameters[4];
				dblMonto = Funciones.CheckDbl(parSalMonto.Value);
				strNroError = Funciones.CheckStr(parSalNLog.Value);
				strDesError = Funciones.CheckStr(parSalDLog.Value);
			}
			catch(Exception ex)
			{
				strNroError = "-1";
				strDesError = ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			 return dblMonto;
		} //SD_644347 - CUOTAS - FIN

		public string ConsultaPrecioApadece(string strCodMaterial)
		{
			string strPrecioApadece = string.Empty;
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("K_MATEC_CODMATERIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("O_MATEC_CODMATERIAL", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("O_MATEV_DESCMATERIAL", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("O_MATEN_PRECIOAPADECE", DbType.Decimal, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strCodMaterial;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
            obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_PRECIOAPADECE";
			obRequest.Parameters.AddRange(arrParam);
		
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter pRespuesta;
				pRespuesta = (IDataParameter)obRequest.Parameters[3];
				strPrecioApadece = Funciones.CheckStr(Funciones.CheckDecimal(pRespuesta.Value));	
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return strPrecioApadece;
		}

		public ArrayList PlanXServicios(string tipoproduc, string codplan)
		{
			ArrayList PlanXServicios = new ArrayList();
			Servicio_AP oServ = new Servicio_AP();

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_PRODUCTO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN_CODIGO", DbType.String, ParameterDirection.Input)};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = tipoproduc;
			arrParam[1].Value = codplan;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_VENTA_EXPRESS + ".SP_CON_PLAN_X_SERVICIO";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while(dr.Read())
					{
						oServ = new Servicio_AP();
						oServ.SERVV_CODIGO= Funciones.CheckStr(dr["SERVV_CODIGO"]);
						oServ.SERVV_DESCRIPCION = Funciones.CheckStr(dr["SERVV_DESCRIPCION"]);
						//oServ.CARGO_FIJO = Funciones.CheckDbl(dr["PSRVN_CARGO_FIJO"]);
						oServ.GSRVC_CODIGO = Funciones.CheckStr(dr["GSRVC_CODIGO"]);
						oServ.SERVN_ORDEN = Funciones.CheckInt(dr["SERVN_ORDEN"]);
						oServ.SELECCIONABLE_BASE = Funciones.CheckStr(dr["PSRVV_SELECCIONABLE"]);
						PlanXServicios.Add(oServ);

					}
				}
			}
			catch(Exception ex)
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

			return PlanXServicios;
		}



		public ArrayList ListarCampanias(string codigo, string descripcion, string tipoventa, string estado)
		{
			    
			DataTable dt = new DataTable();
			DAABRequest.Parameter[] arrParam = { 
												   new DAABRequest.Parameter("P_CAMPV_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_DESCRIPCION", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_TIPO_VENTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPC_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output) 
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = DBNull.Value;
			arrParam[2].Value = System.Configuration.ConfigurationSettings.AppSettings["ConstCodTipoVentaPostPago"];
			arrParam[3].Value = System.Configuration.ConfigurationSettings.AppSettings["ConsCompaniaEstado"];

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PkgMantConv + ".SP_CON_CAMPANHAS_TIPO_VENTA";
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
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["CAMPV_CODIGO"]);
						item.Descripcion = Funciones.CheckStr(dr["CAMPV_DESCRIPCION"]);
						item.Codigo2 = Funciones.CheckStr(dr["CAMPV_CODIGO_SAP"]);
						filas.Add(item);
					}
				}
				
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return filas;
		}
		
		public String CambiarEstadoSerie(string codSerie, string codMaterial, string codOficina, string pestado)
		{
           
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_CODIGOSERIE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CODMATERIAL", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CODIGOOFICINA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_ESTADO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NRO_ERROR", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DES_ERROR", DbType.String, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}

			try
			{
				int i = 0;
				i = 0;
				if (codSerie != "") 
				{
					arrParam[i].Value = codSerie; 
					i++; if (codMaterial != "") { arrParam[i].Value = codMaterial; }
					i++; if (codOficina != "") { arrParam[i].Value = codOficina; }
					i++; if (pestado != "") { arrParam[i].Value = pestado; }

				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSU_RESERVA_SERIE";
            obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSU_RESERVA_SERIE";
			
			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				//Commit
				obRequest.Factory.CommitTransaction();
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				return ex.Message;
			}
			finally
			{
				
			}
			//Se retorna 1 si todo se ejecuto 
			return "1";

		}

		public bool AnularPedido(Int64 p_nroPedido, string tipoficina)
		{
			//string pestado = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["codPedidoEstadoAnular"]);
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOOFICINA", DbType.String , ParameterDirection.Input)
												   
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			if (p_nroPedido > 0)
			{
				arrParam[0].Value = p_nroPedido;
				arrParam[1].Value = tipoficina;
			}

			bool salida = false;
			
			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP+ ".SSAPSD_LIBERARPEDIDO";
			//obRequest.Command = BaseDatos.PkgMSSap + ".SSAPSD_LIBERARPEDIDO";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				salida = true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return salida;
		}

		public ArrayList ListarCuotas()
		{
			ArrayList listaCuota = new ArrayList();
			Cuota oCuotas = new Cuota();

			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("p_cursor", DbType.Object, ParameterDirection.Output) };

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL + ".SP_CON_TIPO_CUOTA";

			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr!= null)
				{
					while(dr.Read())
					{
						oCuotas.CU = Funciones.CheckStr(dr["CUOC_CODIGO"]);
						oCuotas.DESCRIPCION = Funciones.CheckStr(dr["CUOV_DESCRIPCION"]);

						listaCuota.Add(oCuotas);
					}
				}
                                                               
			}
			catch(Exception ex)
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
			return listaCuota;
		}

		public ArrayList ListarPlanesTarifarios(string tipoproducto,string tipoventa)
		{
			ArrayList listaPlanTarifario = new ArrayList();
			Plan oPlanTarifario = new Plan();

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TVENC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_SALIDA", DbType.Object, ParameterDirection.Output)};

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = tipoproducto;
			arrParam[1].Value = tipoventa;
		
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_NUEVA_LISTAPRECIOS + ".SISACT_CON_PLANES";
			obRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while(dr.Read())
					{
						oPlanTarifario = new Plan();
						//oPlanTarifario.PLNV_CODIGO= Funciones.CheckStr(dr["planc_codigo"]);
						oPlanTarifario.PLANV_DESCRIPCION= Funciones.CheckStr(dr["planv_descripcion"]);
						oPlanTarifario.CODIGO_SAP = Funciones.CheckStr(dr["codigo_sap"]);
						oPlanTarifario.PLANC_ESTADO = "1";
						listaPlanTarifario.Add(oPlanTarifario);

					}
				}
			}
			catch(Exception ex)
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

			return listaPlanTarifario;
		}

		public ArrayList ConsultaVendedoresPVU(string oficinaVenta, string estado)
		{
           
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("p_pdv_codigo", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_vend_estado", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_result", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("p_listado", DbType.Object , ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oficinaVenta;
			arrParam[1].Value = estado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CONS_MAESTRA_SAP + ".sisact_vendedores_sap_cons";            
			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;

			ArrayList filas = new ArrayList();

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				if (dr != null)
				{
					while (dr.Read())
					{
						ItemGenerico item = new ItemGenerico();
						item.Codigo = Funciones.CheckStr(dr["vend_codigo"]);
						item.Descripcion = Funciones.CheckStr(dr["vend_nombre"]);
						filas.Add(item);
					}
				}
			}
			catch
			{
				throw;
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
		//-fin-dga-03082015

//ini sinergia 6.0 03082015
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
			arrParam[1].Value = "";	
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

		public BEParametroOficina ConsultaParametrosOficina(string pCodOficina,string pdesoficina)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_ovenc_codigo", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("k_salida", DbType.Object, ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}

			arrParam[0].Value = pCodOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_NUEVA_LISTAPRECIOS + ".SISACS_DATOS_OFICINA";

			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			BEParametroOficina fila = new BEParametroOficina();
			IDataReader dr = null;
			
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;								
				if (dr != null)
				{
					while (dr.Read())
					{												
						fila = new BEParametroOficina();
						fila.orgVenta = null;
						fila.canal = Funciones.CheckStr(dr["CANAC_CODIGO"]);
						fila.codigoCentro = null;
						fila.codigoAlmacen = null;
						fila.sector = string.Empty;
						fila.DescripcionOficina = Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
						fila.TipoOficina = Funciones.CheckStr(dr["TOFIC_CODIGO"]);
						fila.cPuntoVentaSinergia = Funciones.CheckStr(dr["OVENV_CODIGO_SINERGIA"]);
						//Inicio Servicios Adicionales Roaming
						fila.CodigoRegion = Funciones.CheckStr(dr["DEPAC_CODIGO"]);
						//Fin Servicios Adicionales Roaming
						break;
					}
				}	
			
				BEParametroOficina oPuntoVentaMSSAP = ConsultaParametrosOficinaMSSAP(fila.cPuntoVentaSinergia);
				if ( oPuntoVentaMSSAP !=null	)
				{
					fila.orgVenta = oPuntoVentaMSSAP.orgVenta;
					fila.codigoCentro = oPuntoVentaMSSAP.codigoCentro;
					fila.codigoAlmacen = oPuntoVentaMSSAP.codigoAlmacen;
					//Agregado para el cpd
					fila.CodigoCpdMasivo =oPuntoVentaMSSAP.CodigoCpdMasivo;
					fila.CodigoCpdCorporativo =oPuntoVentaMSSAP.CodigoCpdCorporativo;
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
			return fila;
		}

		public BEParametroOficina ConsultaParametrosOficinaMSSAP(string pCodOficina)
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

			arrParam[0].Value = pCodOficina;
			arrParam[1].Value = "";

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_OFICINA";

			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			BEParametroOficina fila = new BEParametroOficina();
			IDataReader dr = null;

			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;								
				if (dr != null)
				{
					while (dr.Read())
					{												
						fila = new BEParametroOficina();
						fila.codigoOficinaMSSAP= Funciones.CheckStr(dr["OFICV_CODOFICINA"]);
						fila.orgVenta =Funciones.CheckStr(dr["OFICC_ORGVENTA"]);
						fila.codigoCentro = Funciones.CheckStr(dr["OFICC_CODCENTRO"]);
						fila.codigoAlmacen = Funciones.CheckStr(dr["OFICC_CODALMACEN"]);
						fila.sector = string.Empty;
						fila.CodigoRegion= Funciones.CheckStr(dr["OFICC_REGION"]);
						//Agregago para el cpd
						fila.CodigoCpdMasivo = Funciones.CheckStr(dr["OFICC_CPDMASIVO"]);
						fila.CodigoCpdCorporativo= Funciones.CheckStr(dr["OFICC_CPDCORPORATIVO"]);
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
			return fila;
		}

		public string actualizaPedido(string nroPedido)
		{
           
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.String, ParameterDirection.Input)
											   };


			arrParam[0].Value = DBNull.Value;

			arrParam[0].Value = nroPedido;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSU_ACTUALIZARPEDIDO";

			
			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				//Commit
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				return ex.Message;
			}
			finally
			{
				obRequest.Factory.CommitTransaction();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
				
			}
			//Se retorna 1 si todo se ejecuto 
			return "1";

		}

		public   Int64 RegistrarDevolucion(string CadenaCabecera, ref string codResp, ref string msgResp)
		{
			int i;
			Int64 nroPedidoMsSap = 0;
			string[] arrDBAcuerdo = CadenaCabecera.Split(Convert.ToChar(";"));

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ORGVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CANALVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_SECTOR", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOVENTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHADOCUMENTO", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_MOTIVOPEDIDO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CLASEFACTURA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESCCLASEFACTURA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESTINOMERCADERIA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CLASEPEDIDO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CODTIPOOPERACION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DESCTIPOOPERACION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHAENTREGA", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_SISTEMAVENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_CODVENDEDOR", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESTADO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ISRENTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_PEDIDOALTA", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_UBIGEO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESQUEMACALCULO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NROREFNCND", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPODOCCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NRODOCCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_NOMBRECLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_PATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_MATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_NACIMIENTOCLIENTE",DbType.Date , ParameterDirection.Input),//D
												   new DAABRequest.Parameter("K_PEDIV_RAZONSOCIAL", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_CORREOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_TELEFONOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESTADOCIVILCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DIRECCIONCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_NUMEROCALLE", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_DISTRITOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_CODDPTOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_PAISCLIENTE", DbType.String,  ParameterDirection.Input),                                                   
												   new DAABRequest.Parameter("K_PEDIC_RLTIPODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLNRODOCUMENTO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLPATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLMATERNOCLIENTE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_RLNOMBRE", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_TIPOOFICINA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ISSISCAD", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_FLAGLP", DbType.String, ParameterDirection.Input), 
												   new DAABRequest.Parameter("K_PEDIV_USUARIOCREA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHACREA", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIV_USUARIOMODI", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDID_FECHAMODI", DbType.DateTime, ParameterDirection.Input), //D
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,  ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String, ParameterDirection.Output)
											   };

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			for (i = 0; i < arrDBAcuerdo.Length; i++)
			{
				if (arrDBAcuerdo[i]!= null  &&  arrDBAcuerdo[i].Trim() != "")
				{
					if (arrParam[i].DbType== DbType.DateTime )
					{
						arrParam[i].Value = Funciones.CheckDate(arrDBAcuerdo[i]).ToLongDateString();
					}
					if (arrParam[i].DbType== DbType.Date )
					{
						arrParam[i].Value = Funciones.CheckDate(arrDBAcuerdo[i]).ToShortDateString();
					}     
					else if (arrParam[i].DbType== DbType.Decimal)
					{
						arrParam[i].Value = Funciones.CheckDecimal(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Double)
					{
						arrParam[i].Value = Funciones.CheckDbl(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Int64)
					{
						arrParam[i].Value = Funciones.CheckInt64(arrDBAcuerdo[i]);
					}
					else if (arrParam[i].DbType== DbType.Int32)
					{
						arrParam[i].Value = Funciones.CheckInt(arrDBAcuerdo[i]);
					}
					else
					{
						arrParam[i].Value = arrDBAcuerdo[i];
					}
				}
			}

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSI_DEVOLUCION";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter pSalida0;
				IDataParameter pSalida1;
				IDataParameter pSalida2;
				pSalida0 = (IDataParameter)obRequest.Parameters[52];
				pSalida1 = (IDataParameter)obRequest.Parameters[53];
				pSalida2 = (IDataParameter)obRequest.Parameters[54];
				nroPedidoMsSap = Funciones.CheckInt64(pSalida0.Value);
				codResp = Funciones.CheckStr(pSalida1.Value);
				msgResp = Funciones.CheckStr(pSalida2.Value);
			}
			catch (Exception ex)
			{
				codResp = "-99";
				msgResp = ex.Message.ToString();
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return nroPedidoMsSap;
		}

		public   int RegistrarDevolucionDetalle(Int64 idPedido, string cadenaDetalle, ref string nroError, ref string desError)
		{
			int i = 0, codResp;
			string[] arrDBAcuerdo = cadenaDetalle.Split(Convert.ToChar(";"));
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_PEDIN_NROPEDIDO", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIN_CONSECUTIVO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_OFICV_CODOFICINA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_INTEV_CODINTERLOCUTOR", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_SERIC_CODSERIE", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEC_CODMATERIAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_DESCMATERIAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_CANTIDAD", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_PRECIOVENTA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_NROTELEFONO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_NROCLARIFY", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_NRORENTA", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_TOTALRENTA", DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEN_NROCUOTA", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIC_ESQUEMACALCLULO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_PEDIV_VERSIONSAP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_CODIGOLP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_DESCRIPCIONLP", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_USUARIOCREA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPED_FECHACREA", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPEV_USUARIOMODI", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_DEPED_FECHAMODI", DbType.DateTime,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String,ParameterDirection.Output)
											   };


			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSI_DETALLEDEVOLUCION";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			for (i = 0; i < arrDBAcuerdo.Length; i++)
			{
				if (arrDBAcuerdo[i].Trim() != "")
					arrParam[i].Value = arrDBAcuerdo[i].Trim();
			}
			arrParam[0].Value = idPedido;

			if (arrDBAcuerdo[18].Trim() != "")
				arrParam[19].Value = Funciones.CheckDate(arrDBAcuerdo[19].Trim());

			if (arrDBAcuerdo[20].Trim() != "")
				arrParam[21].Value = Funciones.CheckDate(arrDBAcuerdo[21].Trim());


			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida0;
				IDataParameter pSalida1;
				pSalida0 = (IDataParameter)obRequest.Parameters[22];
				pSalida1 = (IDataParameter)obRequest.Parameters[23];
				codResp = Funciones.CheckInt(pSalida0.Value);
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

		
		public string reservaSerieMaterial(string codSerie)
		{
           
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_SERIC_CODSERIE", DbType.String, ParameterDirection.Input)
											   };


			arrParam[0].Value = DBNull.Value;

			arrParam[0].Value = codSerie;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();

			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSU_RESERVATEMPORAL";

                  
			obRequest.Transactional = true;
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				//Commit
			}
			catch (Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				return ex.Message;
			}
			finally
			{
				obRequest.Factory.CommitTransaction();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
                        
			}
			//Se retorna 1 si todo se ejecuto 
			return "1";

		}

		
		public  ItemGenerico ConsultaMaterial46(string strCodMaterial)
		{

			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("K_CONVV_CODMATERIAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_NROLOG", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESLOG", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_MATERIAL60", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("K_DESC_MATERIAL60", DbType.String,ParameterDirection.Output),                                                                             
												   new DAABRequest.Parameter("K_TIPO_MATERIAL60", DbType.String, ParameterDirection.Output)
											   };

			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;
			arrParam[0].Value = strCodMaterial;

			BDMSSAP obj = new BDMSSAP(BaseDatos.BD_MSSAP);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_CONSULTA_MSSAP + ".SSAPSS_MATERIAL_46";
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
						item = new ItemGenerico();	
						item.Codigo = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[3]).Value);
						item.Descripcion = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[4]).Value);
						//item.MATV_TIPO_MAT = Funciones.CheckStr(((IDataParameter)obRequest.Parameters[5]).Value);
					}				
				}

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
			return item;
		}

		
		//fin sinergia 6.0 03082015

		//INI PROY 31636 RENTESEG
		public bool MSSAP_ClienteNacionalidad_Actualizar(string strClienteNacionalidad)
		{
			string [] objClienteNacionalidad = strClienteNacionalidad.Split(';');
			bool blnResultado = false;
			DAABRequest.Parameter[] arrParam ={
												  new DAABRequest.Parameter("V_CLIEC_TIPO_DOCUMENTO",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CLIEV_NRO_DOCUMENTO",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CLIEC_CODNACION",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CLIEV_DESNACION",DbType.String,ParameterDirection.Input),
												  new DAABRequest.Parameter("RESULTADO",DbType.Int32,ParameterDirection.Output)
											  };
			for (int i = 0; i < arrParam.Length; i++)
			{
				arrParam[i].Value = DBNull.Value;
			}
			int j = 0;
			arrParam[j].Value = objClienteNacionalidad[0];
			j++; arrParam[j].Value = objClienteNacionalidad[1];
			j++; arrParam[j].Value = objClienteNacionalidad[2];
			j++; arrParam[j].Value = objClienteNacionalidad[3];
            
			BDSISACT objDBSisact = new BDSISACT(BaseDatos.BD_MSSAP);
			DAABRequest objRequest = objDBSisact.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_VENTA + ".SSAPSU_CLIE_NACIONALIDAD";//APUNTAR AL SP CREADO
			objRequest.Parameters.AddRange(arrParam);
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				blnResultado = (Funciones.CheckInt(((IDataParameter)objRequest.Parameters[4]).Value) == 0) ? true : false;
			}
			catch (Exception ex)
			{
				blnResultado = false;
				throw ex;
			}
			finally
			{
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return blnResultado;
		}
		//INI PROY 31636 RENTESEG

}
}