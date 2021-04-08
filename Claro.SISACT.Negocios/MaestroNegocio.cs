using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;


namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for MaestroNegocio.
	/// </summary>
	public class MaestroNegocio
	{
		public MaestroNegocio(){}

		public Usuario ObtenerUsuarioLogin(string login)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ObtenerUsuarioLogin(login);
		}
		public ArrayList ListaOficinaVentaXUsuario(int usuarioId,string oficinaId, string estado)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaOficinaVentaXUsuario(usuarioId,oficinaId,estado);
		}

		public Hashtable ListarItemsGenericos(int[] tablas)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListarItemsGenericos(tablas);
		}
		public ArrayList ListaTipoDocumento(string flag_ruc)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaTipoDocumento(flag_ruc);
		}
		public ArrayList ListaProvincia(string cod_provincia,string cod_dpto,string estado)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaProvincia(cod_provincia,cod_dpto,estado);
		}
		public ArrayList ListaDistrito(string cod_distrio,string cod_provincia,string cod_dpto,string estado)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaDistrito(cod_distrio,cod_provincia,cod_dpto,estado);
		}

		public ArrayList ListaPDVPorCanal(string cod_producto,string cod_canal)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaPDVPorCanal(cod_producto,cod_canal);
		}

		public ArrayList ListaModalidadCampanna(string producto)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaModalidadCampanna(producto);
		}
		public ArrayList ConsultarListaCampanias(string p_tipo_venta, string p_fecha, string p_mandt, string strFiltro)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ConsultarListaCampanias( p_tipo_venta,  p_fecha,  p_mandt, strFiltro);
		}
		public ArrayList ListaPDVUsuario(Int64 cod_usuario,string cod_producto)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaPDVUsuario(cod_usuario,cod_producto);
		}
		public int insertarBlackListCanalPdv( BLCanalPDV oBlackList)
		{		
			MaestroDatos obj = new MaestroDatos();
			return obj.insertarBlackListCanalPdv(oBlackList);	
		}

		public bool eliminarBlackListCanalPdv( int vID, ref string rMsg)
		{		
			MaestroDatos obj = new MaestroDatos();
			return obj.eliminarBlackListCanalPdv(vID, ref rMsg);	
		}

		public ArrayList ListaBlackListCanalPdv()
		{
			MaestroDatos obj = new MaestroDatos();			
			return obj.ListaBlackListCanalPdv();
		}

		public String ConsultarDac(string ctaRed) 
		{
			MaestroDatos obj = new MaestroDatos();			
			return obj.ConsultarDac(ctaRed);
		}

		public ArrayList ListaTipoOficinaVentaUsuario(Int64 cod_usuario,string cod_producto){
			MaestroDatos obj = new MaestroDatos();			
			return obj.ListaTipoOficinaVentaUsuario(cod_usuario,cod_producto);
		}
		public bool ValidarBlackList(Vendedor item , ref string rMsg){
			MaestroDatos obj = new MaestroDatos();			
			return obj.ValidarBlackList(item,ref rMsg);
		}
		public bool GrabarVendedor(Vendedor item, ref int sEstado, ref string rMsg, ref Vendedor itemVendedorExistente){
			MaestroDatos obj = new MaestroDatos();			
			return obj.GrabarVendedor(item, ref sEstado, ref rMsg, ref itemVendedorExistente);
		}
		public ArrayList ListaEstadosHabilitados(string cod_perfil, string cod_estado){
			MaestroDatos obj = new MaestroDatos();			
			return obj.ListaEstadosHabilitados(cod_perfil, cod_estado);
		}
		public string ObtenerDistribuidorUsuario(string distribuidorId){
			MaestroDatos obj = new MaestroDatos();			
			return obj.ObtenerDistribuidorUsuario(distribuidorId);
		}

		public ArrayList ListaVendedor(Vendedor itemU, string flgBuscar, string dacId, string perfil, string FlagFortelCadena, string codgrupo){
			MaestroDatos obj = new MaestroDatos();			
			return obj.ListaVendedor(itemU, flgBuscar, dacId, perfil, FlagFortelCadena, codgrupo);
		}

		public ArrayList ListaVendedorExt(Vendedor itemU, string flgBuscar, string dacId, string perfil, string FlagFortelCadena, string Pexterno, string codgrupo)
		{
			MaestroDatos obj = new MaestroDatos();			
			return obj.ListaVendedorExt(itemU, flgBuscar, dacId, perfil, FlagFortelCadena, Pexterno, codgrupo);
		}

		public int GuardarLprecioPacuerdo(string p_datos, string p_usuario)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.GuardarLprecioPacuerdo(p_datos,p_usuario);
		}
		public ArrayList ListaPlazoAcuerdo()
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaPlazoAcuerdo();
		}
		public int ListarCantidadRegLpPa()
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListarCantidadRegLpPa();
		}
		public ArrayList ListaLprecioPacuerdo(string numInsert)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListalprecioPacuerdo(numInsert);
		}

		public ArrayList ListaAsociacionCampana(string vID, string cod_producto, string fecha_inicio, string fecha_fin, string nombre)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaAsociacionCampana(vID, cod_producto, fecha_inicio, fecha_fin, nombre);
		}

		public bool GrabarAsociacionCampana(AsociacionCampana objAsocCampana)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.GrabarAsociacionCampana(objAsocCampana);
		}
		
		public bool EliminarAsociacionCampana(int vID)
		{		
			MaestroDatos obj = new MaestroDatos();
			return obj.EliminarAsociacionCampana(vID);
		}

		/*public AsociacionCampana ObtenerAsociacionCampana(int vID)
		{		
			MaestroDatos obj = new MaestroDatos();
			return obj.ObtenerAsociacionCampana(vID);
		}*/

		public bool ActualizarAsociacionCampana(AsociacionCampana objAsocCampana)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ActualizarAsociacionCampana(objAsocCampana);
		}
		public ArrayList ListaCampana(string cod_producto)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaCampana(cod_producto);
		}

		public ArrayList ListaTiposProducto()
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaTablaGeneralSISACT("PR");
		}

		public ArrayList ListadoTopeConsumo(){
			MaestroDatos obj = new MaestroDatos();
			return obj.ListadoTopeConsumo();
		}
		public ArrayList ListadoPlazoAcuerdo()
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListadoPlazoAcuerdo();
		}

public ArrayList ListaTablaGeneralSISACT(string cod)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaTablaGeneralSISACT(cod);
		}

		public DataTable listarTipProdMensaje(string pstrDescripcion, string pstrCodigo,string pstrCodTipoCli)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.listarTipProdMensaje(pstrDescripcion, pstrCodigo,pstrCodTipoCli);
		}

		public DataTable listarTipoProducto()
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.listarTipoProducto();
		}

		public bool insertarTipoProdMsj(string pstrCodigo, string pstrCodCorreo, string pstrCodApp, string pstrCodTipoCli)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.insertarTipoProdMsj(pstrCodigo,pstrCodCorreo,pstrCodApp,pstrCodTipoCli);
		}

		public bool modificarTipoProdMsj(string pstrCodigo, string pstrCodCorreo, string pstrCodApp,string pstrCodTipoCli)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.modificarTipoProdMsj(pstrCodigo,pstrCodCorreo,pstrCodApp,pstrCodTipoCli);
		}

		public bool eliminarTipoProdMsj(string pstrCodigo,string pstrCodTipoCli)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.eliminarTipoProdMsj(pstrCodigo,pstrCodTipoCli);
		}

		public DataTable listarTipoCliente()
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.listarTipoCliente();
		}

		public DataTable listarServXEquipo(string pstrDescripcion,Int64 pstrPaquete, Int64 pstrServicio){
			MaestroDatos obj = new MaestroDatos();
			return obj.listarServXEquipo(pstrDescripcion,pstrPaquete,pstrServicio);
		}

		public bool insertarServEquipos(string pstrCabecera, string pstrEquipos){
			MaestroDatos obj = new MaestroDatos();
			return obj.insertarServEquipos(pstrCabecera,pstrEquipos);
		}

		public DataTable listarEquipos(string pstrCodGrupo){
			MaestroDatos obj = new MaestroDatos();
			return obj.listarEquipos(pstrCodGrupo);
		}
		
		public bool actualizarServEquipos(string pstrCodigo, string pstrEquipos, string pstrEstado){
			MaestroDatos obj = new MaestroDatos();
			return obj.actualizarServEquipos(pstrCodigo,pstrEquipos,pstrEstado);
		}

		public bool eliminarServEquipos(string pstrCodigo)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.eliminarServEquipos(pstrCodigo);
		}

                public ArrayList ObtenerTipoDocumentosPVU(string p_tipo_doc, string p_estado)
		{
			return new MaestroDatos().ObtenerTipoDocumentosPVU(p_tipo_doc, p_estado);
		}

		public ArrayList ListaParametros(Int64 codigo)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaParametros(codigo);
		}

		public ArrayList ListaParametrosGrupo(Int64 codigoGP)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaParametrosGrupo(codigoGP);
		}	
	      //PROY-24724-IDEA-28174 - INICIO  PARAMETROS
		public ArrayList ListaParametrosGrupo_Keys(Int64 codigoGP)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaParametrosGrupo_Keys(codigoGP);
		}
              //PROY-24724-IDEA-28174 - FIN  PARAMETROS
		public int validoPdvCliente_BlackList(string vCodCanal, string vCodPdv)
		{
			return new MaestroDatos().validoPdvCliente_BlackList(vCodCanal, vCodPdv);
		}

		public string ListaPrefijosApellidoCompuesto()
		{
			return new MaestroDatos().ListaPrefijosApellidoCompuesto();
		}

		//DRC ListaVendedorClave
		public ArrayList ListaVendedorClave(Vendedor item, string flgBuscar)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaVendedorClave(item,flgBuscar);
		}

		public ArrayList ListaVendedorClavePro(Vendedor item, string flgBuscar, string prove)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaVendedorClavePro(item,flgBuscar,prove);
		}

		public bool ActualizarVendedorClave(Vendedor item, ref int sEstado, ref string rMsg)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ActualizarVendedorClave(item, ref sEstado, ref rMsg);
		}

		public ArrayList ListaBuscarOficinaVenta(string busquedaPDV,string flagBuscar,string tipoPDV, string codgrupo)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaBuscarOficinaVenta(busquedaPDV,flagBuscar,tipoPDV,codgrupo);
		}

		public ArrayList ListaOficinaVentaPro(string busquedaPDV,string flagBuscar,string tipoPDV, string codigo, string codgrupo)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaOficinaVentaPro(busquedaPDV,flagBuscar,tipoPDV,codigo,codgrupo);
		}

		public bool insertarIDValidatorList(string P_TIPO_DOC, string P_NRO_DOC, string P_NOMBRE, string P_VIGE_INDEF, Int32 P_VIGE_DIAS, string P_TIPO_LISTA, string P_USUARIO){
			MaestroDatos obj = new MaestroDatos();
			return obj.insertarIDValidatorList(P_TIPO_DOC, P_NRO_DOC, P_NOMBRE, P_VIGE_INDEF, P_VIGE_DIAS, P_TIPO_LISTA, P_USUARIO);
		}
		public bool actualizarIDValidatorList(string P_CODIGO, string P_VIGE_INDEF, Int32 P_VIGE_DIAS, string P_NOMBRE, string P_USUARIO){
			MaestroDatos obj = new MaestroDatos();
			return obj.actualizarIDValidatorList(P_CODIGO, P_VIGE_INDEF, P_VIGE_DIAS, P_NOMBRE, P_USUARIO);			
		}
		public DataTable listarIDValidatorList(string pstrDNI, string pstrFchaIni, 
			string pstrFchaFin, string pstrTipoList, string pstrTipoDoc, Int32 pstrCodigo)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.listarIDValidatorList(pstrDNI,pstrFchaIni,pstrFchaFin,pstrTipoList,pstrTipoDoc,pstrCodigo);
		}
		public bool eliminarSeleccionadosIDValidator(string strSeleccionados, ref string pstrEstado, ref string pstrMsg){
			MaestroDatos obj = new MaestroDatos();
			return obj.eliminarSeleccionadosIDValidator(strSeleccionados, ref pstrEstado, ref pstrMsg);
		}
		public int CargaMasivaIDValidatorList(string pstrdatos, ref string pstrErrores){
			MaestroDatos obj = new MaestroDatos();
			return obj.CargaMasivaIDValidatorList(pstrdatos, ref pstrErrores);
		}

		public DataTable listarEdificio(string pstrDepartamento, string pstrProvincia, 
			string pstrDistrito, string pstrDireccion, string pstrCodigo)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.listarEdificio(pstrDepartamento,pstrProvincia,pstrDistrito,pstrDireccion,pstrCodigo);
		}

		public bool insertarEdificio(Edificio oEdificio){
			MaestroDatos obj = new MaestroDatos();
			return obj.insertarEdificio(oEdificio);
		}

		public bool actualizarEdificio(Edificio oEdificio)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.actualizarEdificio(oEdificio);
		}

		public bool eliminarSeleccionadosEdificio(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.eliminarSeleccionadosEdificio(strSeleccionados,ref pstrEstado, ref pstrMsg);
		}

		public int CargaMasivaEdificio(string pstrdatos)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.CargaMasivaEdificio(pstrdatos);
		}

		#region "PROY 16359 - IDEA 19861"
		public bool ValidarTipoPDV(string tipoOficina,string codigoOficina , ref string rMsg)
		{
			MaestroDatos obj = new MaestroDatos();				
			return obj.ValidarTipoPDV(tipoOficina,codigoOficina,ref rMsg);
		}

		public bool ValidaNegocio(ref Vendedor item, ref string rMsg, ref string sAccion)
		{
			MaestroDatos obj = new MaestroDatos();			
			return obj.ValidaNegocio(ref item, ref rMsg,ref sAccion);
		}

		public int CargaMasiVendedor(string p_datos, string p_usuario, string p_cod_distribuidor)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.CargaMasiVendedor(p_datos,p_usuario,p_cod_distribuidor);
		}

		#endregion

		//consolidado 03012015

		public ArrayList ListaMotivoRenovacionChip(string cod_operacion, string estado)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaMotivoRenovacionChip(cod_operacion,estado);
		}

		//consolidado 03012015


                //Inicio PROY-25335 - Contratación Electrónica - Release 0
		//* OSCAR ATENCIO *//
		public bool RegistrarBiometriaGendoc(BEBiometria items)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.RegistrarBiometriaGendoc(items);
		
		}

		public bool RegistrarRepresentanteLegalSEC(RepresentanteLegal items)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.RegistrarRepresentanteLegalSEC(items);
		
		}

		public bool RegistrarCartaPoderSEC(BECartaPoder items)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.RegistrarCartaPoderSEC(items);
		
		}

		public string Generar_ID_BIO(int item)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.Generar_ID_BIO(item);
		}
		//* OSCAR ATENCIO *//
		//FinPROY-25335 - Contratación Electrónica - Release 0
	
		//PROY-31948 INI
		public ArrayList ListaParametrosMaxCuotas_Keys(Int64 codigoGP)
		{
			MaestroDatos obj = new MaestroDatos();
			return obj.ListaParametrosMaxCuotas_Keys(codigoGP);
		}
		//PROY-31948 FIN
	}
}
