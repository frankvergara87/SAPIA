using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de CasoEspecialDatos.
	/// </summary>
	public class CasoEspecialDatos
	{
		public CasoEspecialDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		#region Transacciones

		private string _Mensaje;
		public string Mensaje
		{
			set { _Mensaje = value;}
			get { return _Mensaje;}
		}

		//Inserta Cabecera Caso Especial

		public bool InsertarCasoEspecial(CasoEspecial ent)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_CODIGO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WHITELIST", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDOFERTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MAX_PLANES", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MAX_PLAN_VOZ", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MAX_PLAN_DATOS", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			int j=2; if( ent.Descripcion != null  && ent.Descripcion != "") arrParam[j].Value = ent.Descripcion;
			j++; if( ent.IdEstado != null  && ent.IdEstado != "") arrParam[j].Value = ent.IdEstado;
			j++; arrParam[j].Value = ent.WhiteList;
			j++; if( ent.IdOferta != null  && ent.IdOferta != "") arrParam[j].Value = ent.IdOferta;
			j++; arrParam[j].Value = ent.MaxPlanes;
			j++; arrParam[j].Value = ent.MaxPlanesVoz;
			j++; arrParam[j ].Value = ent.MaxPlanesDatos;
			j++; if( ent.Usuario != null  && ent.Usuario != "") arrParam[j].Value = ent.Usuario;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CASO_ESPECIAL";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				IDataParameter pCodigo;
				pCodigo = (IDataParameter)obRequest.Parameters[1];
				ent.Codigo = Convert.ToString(pCodigo.Value);
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				Mensaje = ex.Message.ToString();
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool ActualizarCasoEspecial(CasoEspecial ent)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WHITELIST", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDOFERTA", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MAX_PLANES", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MAX_PLAN_VOZ", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MAX_PLAN_DATOS", DbType.Int32,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
		
			int j=1; if( ent.Codigo != null  && ent.Codigo != "") arrParam[j].Value = ent.Codigo;
			j++; if( ent.Descripcion != null  && ent.Descripcion != "") arrParam[j].Value = ent.Descripcion;
			j++; if( ent.IdEstado != null  && ent.IdEstado != "") arrParam[j].Value = ent.IdEstado;
			j++; arrParam[j].Value = ent.WhiteList;
			j++; if( ent.IdOferta != null  && ent.IdOferta != "") arrParam[j].Value = ent.IdOferta;
			j++; arrParam[j].Value = ent.MaxPlanes;
			j++; arrParam[j].Value = ent.MaxPlanesVoz;
			j++; arrParam[j ].Value = ent.MaxPlanesDatos;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ACTUALIZAR_CASO_ESPECIAL";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				Mensaje = ex.Message.ToString();
				obRequest.Factory.RollBackTransaction();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarCasoEspecial(string cod)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CASO_ESPECIAL";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		//PROY-24740
		public bool ValidaCasoEspecial(int Accion, string Codigo, string Descripcion)
		{
			bool salida = false;			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ACCION", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = Accion;
			arrParam[1].Value = Codigo;
			arrParam[2].Value = Descripcion;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_VALIDA_CASO_ESPECIAL";
			objRequest.Parameters.AddRange(arrParam);

			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while( dr.Read())
				{
					salida = true;
					break;
				}				
			}			
			finally
			{
				if ( dr!=null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return salida;
		}

		//Agregar Detalles
		public bool InsertarCasoEspecialDocumento(string Codigo, string IdDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Codigo != null  && Codigo != "") arrParam[i].Value = Codigo;
			i++; if( IdDocumento != null  && IdDocumento != "") arrParam[i].Value = IdDocumento;
			
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CE_DOCUMENTO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;

			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarCasoEspecialCuotas(string Codigo, string IdPLazo,string IdCuota, decimal Porcentaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUON_INICIAL", DbType.Decimal,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Codigo != null  && Codigo != "") arrParam[i].Value = Codigo;
			i++; if( IdPLazo != null  && IdPLazo != "") arrParam[i].Value = IdPLazo;
			i++; if( IdCuota != null  && IdCuota != "") arrParam[i].Value = IdCuota;
			i++; arrParam[i].Value = Porcentaje;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CE_CUOTAS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarCasoEspecialCampanias(string Codigo, string IdCampania, string Campania, string Exclusiva)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CMPV_CODIGO", DbType.String,4,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CAMPV_DESCRIPCION", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCEC_EXCLUSIVA", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Codigo != null  && Codigo != "") arrParam[i].Value = Codigo;
			i++; if( IdCampania != null  && IdCampania != "") arrParam[i].Value = IdCampania;
			i++; if( Campania != null  && Campania != "") arrParam[i].Value = Campania;
			i++; if( Exclusiva != null  && Exclusiva != "") arrParam[i].Value = Exclusiva;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CE_CAMPANIA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarCasoEspecialPDV(string Codigo, string IdPuntoVenta, string IdCanal)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOFIC_CODIGO", DbType.String,2,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OVENC_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Codigo != null  && Codigo != "") arrParam[i].Value = Codigo;
			i++; if( IdCanal != null  && IdCanal != "") arrParam[i].Value = IdCanal;
			i++; if( IdPuntoVenta != null  && IdPuntoVenta != "") arrParam[i].Value = IdPuntoVenta;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CE_PDV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarCasoEspecialPlanes(string Codigo, string IdPlan, int NumeroPlanes, string IdPlazo, string IdCuota, decimal Porcentaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCEN_NRO_PLANES", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUON_INICIAL", DbType.Decimal,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Codigo != null  && Codigo != "") arrParam[i].Value = Codigo;
			i++; if( IdPlan != null  && IdPlan != "") arrParam[i].Value = IdPlan;
			i++; arrParam[i].Value = NumeroPlanes;
			i++; if( IdPlazo != null  && IdPlazo != "") arrParam[i].Value = IdPlazo;
			i++; if( IdCuota != null  && IdCuota != "") arrParam[i].Value = IdCuota;
			i++; arrParam[i].Value = Porcentaje;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CE_PLANES";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarCasoEspecialRiesgos(string Codigo, string IdDocumento, string IdRiesgo, 
			string IdPlan, int NumeroPlanes, string IdPlazo, string IdCuota, decimal Porcentaje)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOCC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIEN_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TCEN_NRO_PLANES", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLZAC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUOC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CUON_INICIAL", DbType.Decimal,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Codigo != null  && Codigo != "") arrParam[i].Value = Codigo;
			i++; if( IdDocumento != null  && IdDocumento != "") arrParam[i].Value = IdDocumento;
			i++; if( IdRiesgo != null  && IdRiesgo != "") arrParam[i].Value = IdRiesgo;
			i++; if( IdPlan != null  && IdPlan != "") arrParam[i].Value = IdPlan;
			i++; arrParam[i].Value = NumeroPlanes;
			i++; if( IdPlazo != null  && IdPlazo != "") arrParam[i].Value = IdPlazo;
			i++; if( IdCuota != null  && IdCuota != "") arrParam[i].Value = IdCuota;
			i++; arrParam[i].Value = Porcentaje;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CE_RIESGOS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarCasoEspecialTopeConsumo(string Codigo, string IdPlan, int IdTopeConsumo, string IdEstadoTope)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNC_CODIGO", DbType.String,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPE_CODIGO", DbType.Int32,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TOPE_ESTADO", DbType.String,  ParameterDirection.Input)
											   };
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( Codigo != null  && Codigo != "") arrParam[i].Value = Codigo;
			i++; if( IdPlan != null  && IdPlan != "") arrParam[i].Value = IdPlan;
			i++; arrParam[i].Value = IdTopeConsumo;
			i++; if( IdEstadoTope != null  && IdEstadoTope != "") arrParam[i].Value = IdEstadoTope;

			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_INSERTAR_CE_TOPECONSUMO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		//Eliminar Detalles
		public bool EliminarDetalleDocumentos(string cod)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CE_DOCUMENTO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarDetalleCuotas(string cod)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CE_CUOTAS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarDetalleCampania(string cod)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CE_CAMPANIA";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarDetallePDV(string cod)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CE_PDV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarDetallePlanes(string cod)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CE_PLANES";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarDetalleRiesgos(string cod)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CE_RIESGOS";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool EliminarDetalleTopeConsumo(string cod)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,  ParameterDirection.Input)
											   };							
			int i=0;
			for ( i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=1; if( cod != null  && cod != "") arrParam[i].Value = cod;
		
			bool salida = false;
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command =BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_ELIMINAR_CE_TOPECONSUMO";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{					
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();

				IDataParameter pSalida;
				pSalida = (IDataParameter)obRequest.Parameters[0];
				if (Funciones.CheckStr(pSalida.Value) == "1")
					salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				Mensaje = ex.Message.ToString();
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		#endregion

		#region Consultas

		public DataTable ListadoCasoEspecialCabecera(string cod, int Item)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEM", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
			i++; arrParam[i].Value = Item;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_CABECERA";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoCasoEspecialDocumento(string cod)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_DOCUMENTO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoCasoEspecialCuotas(string cod)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_CUOTAS";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoCasoEspecialCampanias(string cod)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_CAMPANIA";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoCasoEspecialPDV(string cod)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_PDV";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoCasoEspecialPlanes(string cod)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_PLANES";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoCasoEspecialRiesgos(string cod)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_RIESGOS";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoCasoEspecialTopeConsumo(string cod, int Item)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEM", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( cod != null  && cod != "") arrParam[i].Value = cod;
			i++; arrParam[i].Value = Item;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_TOPECONSUMO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		#endregion

		#region Listados

		public DataTable ListadoCasoEspecial(string strDescripcion, string IdEstado, int Item)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ITEM", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0;
			if( strDescripcion != null  && strDescripcion != "")
				if (strDescripcion.Length > 0) arrParam[i].Value = strDescripcion;
			i++; if( IdEstado != null  && IdEstado != "") arrParam[i].Value = IdEstado;
			i++; arrParam[i].Value = Item;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CASO_ESPECIAL";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoComboPlan(string IdOferta, string IdEstado)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_OFERTA", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO_PLAN", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0;
			if (IdOferta.Length > 0) arrParam[i].Value = IdOferta;
			i++;arrParam[i].Value = IdEstado;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_CON_PLAN";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoComboEstado(int Item)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ITEM", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0;arrParam[i].Value = Item;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_LISTAR_CE_ESTADO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoComboTipoDocumento()
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL + ".SP_CON_TIPO_DOCUMENTO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoComboRiesgo(string strTipo)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; if( strTipo != null  && strTipo != "") arrParam[i].Value = strTipo;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL + ".SP_CON_TIPO_RIESGO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		//		public DataTable ListadoComboTopeConsumo(string Item)
		//		{
		//			DataTable dtResultado = new DataTable();
		//			DAABRequest.Parameter[] arrParam = {
		//												   new DAABRequest.Parameter("P_ITEM", DbType.Object,ParameterDirection.Output),
		//												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
		//											   }; 
		//			int i;
		//			i=0; if( Item != null  && Item != "") arrParam[i].Value = Item;
		//			i++; arrParam[i].Value = DBNull.Value;
		//				
		//			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
		//			DAABRequest objRequest = obj.CreaRequest();
		//			objRequest.CommandType = CommandType.StoredProcedure;
		//			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".SP_CON_TOPE_CONSUMO";
		//			objRequest.Parameters.AddRange(arrParam);
		//
		//			try
		//			{
		//				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
		//			}
		//			catch(Exception ex )
		//			{
		//				throw ex;
		//			}
		//			finally
		//			{			
		//				objRequest.Factory.Dispose();
		//			}
		//			return dtResultado;
		//		}

		public DataTable ListadoComboPlazoAcuerdo(string IdCasoEspecial)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; 
			if( IdCasoEspecial != null  && IdCasoEspecial != "")
				if (IdCasoEspecial.Length > 0) arrParam[i].Value = IdCasoEspecial;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL + ".SP_CON_PLAZO_ACUERDO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListadoTipoCuota()
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
				
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_GENERAL + ".SP_CON_TIPO_CUOTA";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch(Exception ex )
			{
				throw ex;
			}
			finally
			{			
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListarTopeConsumo(string Item)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ITEM", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0; if(Item != null  && Item != "") arrParam[i].Value = Item;
		
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL +  ".SP_CON_TOPE_CONSUMO";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		
		public DataTable ListarEstadoTope(string TipoItem)
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_ITEM", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0; if(TipoItem != null  && TipoItem != "") arrParam[i].Value = TipoItem;

			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_ITEM";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}

		public DataTable ListarOferta()
		{
			DataTable oDataTable = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command =BaseDatos.SISACT_PKG_GENERAL +  ".SP_CON_TIPO_OFERTA";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				oDataTable = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Factory.Dispose();
			}
			return oDataTable;
		}


		//Puntos de Venta
		public DataTable ListarTipoOficina(int IdEstado)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_ESTADO", DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			int j=0; arrParam[j].Value = IdEstado;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".MANTSS_LISTAR_TIPO_OFIC";
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

		//PROY-24740
		public ArrayList ListarPDV(string pstrCanales, string psrtIdEstado, string pstrCodigo, string pstrDescripcion)
		{			
			ArrayList ListaPdv=new ArrayList();
			PuntoVenta oPuntoVenta;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CANALES", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 40, ParameterDirection.Input)													
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			int j=0; arrParam[j].Value = DBNull.Value;
			j++; if( pstrCanales != null  && pstrCanales != "") arrParam[j].Value = pstrCanales;
			j++; if( psrtIdEstado != null  && psrtIdEstado != "") arrParam[j].Value = psrtIdEstado;
			j++; if( pstrCodigo != null  && pstrCodigo != "") arrParam[j].Value = pstrCodigo;
			j++; if( pstrDescripcion != null  && pstrDescripcion != "") arrParam[j].Value = pstrDescripcion;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_CASOESPECIAL + ".MANTSS_LISTAR_PDV_TOTAL";
			objRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					oPuntoVenta=new PuntoVenta();
					oPuntoVenta.OVENC_CODIGO=Funciones.CheckStr(dr["OVENC_CODIGO"]);
					oPuntoVenta.OVENV_DESCRIPCION=Funciones.CheckStr(dr["OVENV_DESCRIPCION"]);
					oPuntoVenta.CANAC_CODIGO=Funciones.CheckStr(dr["CANAC_CODIGO"]);
					ListaPdv.Add(oPuntoVenta);
				}

			}
			finally
			{			
				if(dr!=null&& dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return ListaPdv;
		}

		#endregion
	}
}
