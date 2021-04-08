/******************************************\
  Clase generada para BL de Plan Tarifario
\******************************************/

using System;
using System.Data; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for PlanTarifarioBusinessLogic.
	/// </summary>
	public class PlanTarifarioBusinessLogic
	{
		public PlanTarifarioBusinessLogic()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool InsertarPlanTarifario(PlanTarifario oPlanTarifario, DataTable LlenarDataConsumoEstado,ArrayList ListaDetalle,ArrayList ListaPdv, string strUsuario,DataTable ListaDocumento)
		{
			return new PlanTarifarioDataAccess().InsertarPlanTarifario(oPlanTarifario,LlenarDataConsumoEstado,ListaDetalle,ListaPdv,strUsuario, ListaDocumento);
		}

		public bool ModificarPlanTarifario(PlanTarifario oPlanTarifario, DataTable LlenarDataConsumoEstado,ArrayList ListaDetalle,ArrayList ListaPdv, string strUsuario,DataTable ListaDocumento)
		{
			return new PlanTarifarioDataAccess().ModificarPlanTarifario( oPlanTarifario,  LlenarDataConsumoEstado, ListaDetalle, ListaPdv,  strUsuario, ListaDocumento);
		}

		public bool EliminarPlanTarifario(DataTable ListaPlanes)
		{//string cod
			bool result=false;
			foreach(DataRow oDataRow in ListaPlanes.Rows)
			{
				result= new PlanTarifarioDataAccess().EliminarPlanTarifario( oDataRow[0].ToString());
			}
			return result;
		}

		public PlanTarifario getPlan(string codigo)
		{
			return new PlanTarifarioDataAccess().getPlan(codigo);
		}
		public DataTable ListarTipoPlan()
		{
			return new PlanTarifarioDataAccess().ListarTipoPlan();
		}

		public DataTable ListarEstado()
		{
			return new PlanTarifarioDataAccess().ListarEstado();			
		}

		public DataTable ListarOferta()
		{
			return new PlanTarifarioDataAccess().ListarOferta();
		}

		public DataTable ListarTopeConsumo()
		{
			return new PlanTarifarioDataAccess().ListarTopeConsumo();
		}
		public DataTable ListarEstadoTope()
		{
			return new PlanTarifarioDataAccess().ListarEstadoTope();
		}

		public DataTable ListarTipoDespacho()
		{
			return new PlanTarifarioDataAccess().ListarTipoDespacho();
		}

		public DataTable ListarTipoFlujo()
		{
			return new PlanTarifarioDataAccess().ListarTipoFlujo();			
		}

		public DataTable ListarTipoProducto()
		{
			return new PlanTarifarioDataAccess().ListarTipoProducto();
		}
		public DataTable ListarTipoDocumento()
		{
			return new PlanTarifarioDataAccess().ListarTipoDocumento();
		}

		public DataTable ListarPlazoAcuerdo(string p_oferta,string p_caso_especial)
		{
			return new PlanTarifarioDataAccess().ListarPlazoAcuerdo(p_oferta,p_caso_especial);
		}
		public DataTable ListarCuotas()
		{
			return new PlanTarifarioDataAccess().ListarCuotas();
		}

		public DataTable ConsultarPlanTarifario(string codPlan, string descripcion)
		{
			return new PlanTarifarioDataAccess().ConsultarPlanTarifario(codPlan,descripcion);
		}

//		public DataTable fdtbListarTopConsumo()
//		{
//			return new PlanTarifarioDataAccess().fdtbListarTopConsumo();
//		}

		public DataTable ListarGrupo()
		{
			return new PlanTarifarioDataAccess().ListarGrupo();
		}

		public DataTable getDocumentos(string codigo)
		{
			return new PlanTarifarioDataAccess().getDocumentos(codigo);
		}
		public DataTable getPlazoAcuerdo(string codigo)
		{
			return new PlanTarifarioDataAccess().getPlazoAcuerdo(codigo);
		}
		public DataTable getConsumoEstado(string codigo)
		{
			return new PlanTarifarioDataAccess().getConsumoEstado(codigo);
		}
		public DataTable getConsumoCuotas(string codigo)
		{
			return new PlanTarifarioDataAccess().getConsumoCuotas(codigo);
		}
		public DataTable getRestriccionPdv(string codigo)
		{
			return new PlanTarifarioDataAccess().getRestriccionPdv(codigo);
		}
		public ArrayList ListarPdvRestriccion(string codPlan)
		{
			return new PlanTarifarioDataAccess().ListarPdvRestriccion(codPlan);
		}

		public ArrayList ListarItems(string vNombreApp, string vNombreSP,string vParametroSalida,string vValueMember,string vDisplayMember )
		{
			return new GeneralDatos().ListarItems(vNombreApp,vNombreSP,vParametroSalida,vValueMember,vDisplayMember);
		}
		public DataTable ListarRiesgo( string tipo)
		{
			return new PlanTarifarioDataAccess().ListarRiesgo(tipo);
		}

		public DataTable ListarPLan()
		{
			return new PlanTarifarioDataAccess().ListarPLan();
		}

		public DataTable ListarRestriccionRiesgo( string TipDoc, string Riesgo, string Plazo, string Plan )
		{
			return new PlanTarifarioDataAccess().ListarRestriccionRiesgo(TipDoc,Riesgo,Plazo,Plan);
		}

		public DataTable ListarRestriccionRiesgoExportar( string TipDoc, string Riesgo, string Plazo, string Plan)
		{
			return new PlanTarifarioDataAccess().ListarRestriccionRiesgoExportar(TipDoc,Riesgo,Plazo,Plan);
		}

		public bool InsertarRestriccionRiesgo(string oTipoDocumento,string oRiesgo,DataTable oPlazo,DataTable oPLan,DataTable oListaCampanas,string sUsuario)
		{
			return new PlanTarifarioDataAccess().InsertarRestriccionRiesgo( oTipoDocumento, oRiesgo, oPlazo, oPLan, oListaCampanas, sUsuario);
		}

		public DataTable getRestriccionRiesgo( string TipDoc, string Riesgo, string Plazo, string Plan,string Campana)
		{
			return new PlanTarifarioDataAccess().getRestriccionRiesgo( TipDoc,  Riesgo,  Plazo,  Plan, Campana);
		}

		public bool EliminarRestriccionRiesgo( DataTable oListaRestriccionRiesgo)
		{
			bool result=false;
			foreach(DataRow dr in oListaRestriccionRiesgo.Rows)//TipDoc,  Riesgo,  Plazo,  Plan, Campana
			{
				result=new PlanTarifarioDataAccess().EliminarRestriccionRiesgo( dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),dr[4].ToString());
			}

			return result;
		}

		public bool EliminarUpdateRestriccionRiesgo( string TipDoc, string Riesgo, string Plazo, string Plan,string Campana)
		{
			return new PlanTarifarioDataAccess().EliminarUpdateRestriccionRiesgo( TipDoc,  Riesgo,  Plazo,  Plan, Campana);
		}
//		public bool RegistroUpdateRiesgo(string sRiesgo,string sTipoDocumento,string sPlazo,string sPLan,string sCampanaCodigo,string sCampanaDescripcion,string sUsuario)
//		{
//			return new PlanTarifarioDataAccess().ActualizarRiesgo("","","","","","","");
//		}
		public DataTable ListarRestriccionCuota(string TipoDocumento,string Riesgo, string Cuota)
		{
			return new PlanTarifarioDataAccess().ListarRestriccionCuota(TipoDocumento,Riesgo,Cuota);
		}

		public DataTable ListarRestriccionCuotaExportar(string sTipoDocumento,string sRiesgo, string sCuota)
		{
			return new PlanTarifarioDataAccess().ListarRestriccionCuotaExportar(sTipoDocumento,sRiesgo,sCuota);
		}

		public bool InsertarRestriccionCuota(ArrayList ListaResCuota, string strUsuario)
		{//string Riesgo,string TipDoc,string Cuota,decimal CuotaIni, string strUsuario
			bool result=false;
			foreach(DetallePlanTarifario oDetallePlanTarifario in ListaResCuota)
			{
				result=new PlanTarifarioDataAccess().InsertarRestriccionCuota(oDetallePlanTarifario.IdPlazo,oDetallePlanTarifario.IdDocumento,oDetallePlanTarifario.IdCuota,oDetallePlanTarifario.ValorCuota,strUsuario);
			}
			return result;
			//return new PlanTarifarioDataAccess().InsertarRestriccionCuota(ListaRiesgo,ListaTipoDocumento,ListaCuotas,strUsuario);
		}

		public int InsertarGrupo(string Descripcion,string strUsuario)
		{
			return new PlanTarifarioDataAccess().InsertarGrupo(Descripcion,strUsuario);
		}
		
		public ArrayList ListarDetalle(string codPlan)
		{
			return new PlanTarifarioDataAccess().ListarDetalle(codPlan);
		}
		public bool validarRestriccionCuota(string riesgo,string doc,string cuota)
		{
			return new PlanTarifarioDataAccess().validarRestriccionCuota(riesgo,doc,cuota);
		}

		public bool EliminarRestriccionCuota(DataTable oListaRestriccionCuota)
		{
			bool result=false;
			foreach(DataRow dr in oListaRestriccionCuota.Rows)//RESTRICCION POR CUOTA /ELIMINAR
			{
				result= new PlanTarifarioDataAccess().EliminarRestriccionCuota(dr[0].ToString(),dr[1].ToString(),dr[2].ToString());
			}
			return result;
		}

		public bool ModificarRestriccionCuota(DetallePlanTarifario oDetallePlanTarifario,string estado)
		{
			return new PlanTarifarioDataAccess().ModificarRestriccionCuota(oDetallePlanTarifario,estado);
		}

		public DetallePlanTarifario getRestriccionCuota(string riesgo,string doc,string cuota)
		{//	
			return new PlanTarifarioDataAccess().getRestriccionCuota(riesgo,doc,cuota);
		}
		public DataTable getDetallesRestriccionRiesgo( string TipDoc, string Riesgo,int tipo)
		{
			return new PlanTarifarioDataAccess().getDetallesRestriccionRiesgo(TipDoc,Riesgo,tipo);
		}

		public bool validarDetallesRestriccionRiesgo( string TipDoc, string Riesgo)
		{
			return new PlanTarifarioDataAccess().validarDetallesRestriccionRiesgo(TipDoc,Riesgo);
		}
		public bool DelDetallesRestriccionRiesgo( string TipDoc, string Riesgo)
		{
			return new PlanTarifarioDataAccess().DelDetallesRestriccionRiesgo(TipDoc,Riesgo);
		}

		public DataTable ListarEssaludSunat()
		{
			return new PlanTarifarioDataAccess().ListarEssaludSunat();
		}

		public DataTable ListarFactorPorRiesgo(string sTipoDocumento,string sRiesgo, int tipo)
		{
			return new PlanTarifarioDataAccess().ListarFactorPorRiesgo(sTipoDocumento,sRiesgo,tipo);
		}

		public bool InsertarFactorRiesgo(string Riesgo,string TipDoc,string Essalud,decimal Factor, string strUsuario)
		{
			return new PlanTarifarioDataAccess().InsertarFactorRiesgo(Riesgo,TipDoc,Essalud,Factor,strUsuario);
		}
		public bool ModificarFactorRiesgo(string Riesgo,string TipDoc,string Essalud,decimal Factor, string strEstado)
		{
			return new PlanTarifarioDataAccess().ModificarFactorRiesgo(Riesgo,TipDoc,Essalud,Factor,strEstado);
		}

		public bool EliminarFactorRiesgo(DataTable ListaFactorRiesgo)
		{//string Riesgo,string TipDoc,string Essalud
			bool result=false;
			foreach(DataRow dr in ListaFactorRiesgo.Rows)
			{
				result= new PlanTarifarioDataAccess().EliminarFactorRiesgo(dr[0].ToString(),dr[1].ToString(),dr[2].ToString());
			}
			return result;
		}

		public DataTable getFactorRiesgo(string Riesgo,string TipDoc,string Essalud)
		{
			return new PlanTarifarioDataAccess().getFactorRiesgo(Riesgo,TipDoc,Essalud);
		}
		public DataTable ConsultarPlanTarifarioExportar(string codPlan, string descripcion)
		{
			return new PlanTarifarioDataAccess().ConsultarPlanTarifarioExportar(codPlan,descripcion);
		}

		public DataTable getPlanDocumento(string sCod)
		{
			return new PlanTarifarioDataAccess().getPlanDocumento(sCod);
		}
		
	}
}
