using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de CasoEspecialNegocios.
	/// </summary>
	public class CasoEspecialNegocios
	{
		public CasoEspecialNegocios()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		private string _Mensaje;
		public string Mensaje
		{
			set { _Mensaje = value;}
			get { return _Mensaje;}
		}

		CasoEspecialDatos obj = new CasoEspecialDatos();

		//Transacciones

		public bool InsertarCasoEspecial(CasoEspecial ent)
		{
			bool salida = obj.InsertarCasoEspecial(ent);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool ActualizarCasoEspecial(CasoEspecial ent)
		{	
			bool salida = obj.ActualizarCasoEspecial(ent);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool EliminarCasoEspecial(string cod)
		{
			bool salida = obj.EliminarCasoEspecial(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool ValidaCasoEspecial(int Accion, string Codigo, string Descripcion)
		{
			return obj.ValidaCasoEspecial(Accion,Codigo,Descripcion);
		}

		//Agregar Detalles
		public bool InsertarCasoEspecialDocumento(string Codigo, string IdDocumento)
		{
			bool salida = obj.InsertarCasoEspecialDocumento(Codigo,IdDocumento);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool InsertarCasoEspecialCuotas(string Codigo, string IdPLazo,string IdCuota, decimal Porcentaje)
		{
			bool salida = obj.InsertarCasoEspecialCuotas(Codigo,IdPLazo,IdCuota,Porcentaje);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool InsertarCasoEspecialCampanias(string Codigo, string IdCampania, string Campania, string Exclusiva)
		{
			bool salida = obj.InsertarCasoEspecialCampanias(Codigo,IdCampania,Campania,Exclusiva);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool InsertarCasoEspecialPDV(string Codigo, string IdPuntoVenta, string IdCanal)
		{
			bool salida = obj.InsertarCasoEspecialPDV(Codigo,IdPuntoVenta,IdCanal);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool InsertarCasoEspecialPlanes(string Codigo, string IdPlan, int NumeroPlanes, string IdPlazo, string IdCuota, decimal Porcentaje)
		{
			bool salida = obj.InsertarCasoEspecialPlanes(Codigo,IdPlan,NumeroPlanes,IdPlazo,IdCuota,Porcentaje);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool InsertarCasoEspecialRiesgos(string Codigo, string IdDocumento, string IdRiesgo, 
			string IdPlan, int NumeroPlanes, string IdPlazo, string IdCuota, decimal Porcentaje)
		{
			bool salida = obj.InsertarCasoEspecialRiesgos(Codigo,IdDocumento,IdRiesgo,IdPlan,NumeroPlanes,IdPlazo,IdCuota,Porcentaje);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool InsertarCasoEspecialTopeConsumo(string Codigo, string IdPlan, int IdTopeConsumo, string IdEstadoTope)
		{
			bool salida = obj.InsertarCasoEspecialTopeConsumo(Codigo,IdPlan,IdTopeConsumo,IdEstadoTope);
			Mensaje = obj.Mensaje;
			return salida;
		}

		//Eliminar Detalles
		public bool EliminarDetalleDocumentos(string cod)
		{
			bool salida = obj.EliminarDetalleDocumentos(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool EliminarDetalleCuotas(string cod)
		{
			bool salida = obj.EliminarDetalleCuotas(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool EliminarDetalleCampania(string cod)
		{
			bool salida = obj.EliminarDetalleCampania(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool EliminarDetallePDV(string cod)
		{
			bool salida = obj.EliminarDetallePDV(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool EliminarDetallePlanes(string cod)
		{
			bool salida = obj.EliminarDetallePlanes(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool EliminarDetalleRiesgos(string cod)
		{
			bool salida = obj.EliminarDetalleRiesgos(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		public bool EliminarDetalleTopeConsumo(string cod)
		{
			bool salida = obj.EliminarDetalleTopeConsumo(cod);
			Mensaje = obj.Mensaje;
			return salida;
		}

		//Consultas

		public DataTable ListadoCasoEspecialCabecera(string cod, int Item)
		{
			return obj.ListadoCasoEspecialCabecera(cod,Item);
		}

		public DataTable ListadoCasoEspecialDocumento(string cod)
		{
			return obj.ListadoCasoEspecialDocumento(cod);
		}

		public DataTable ListadoCasoEspecialCuotas(string cod)
		{
			return obj.ListadoCasoEspecialCuotas(cod);
		}

		public DataTable ListadoCasoEspecialCampanias(string cod)
		{
			return obj.ListadoCasoEspecialCampanias(cod);
		}

		public DataTable ListadoCasoEspecialPDV(string cod)
		{
			return obj.ListadoCasoEspecialPDV(cod);
		}

		public DataTable ListadoCasoEspecialPlanes(string cod)
		{
			return obj.ListadoCasoEspecialPlanes(cod);
		}

		public DataTable ListadoCasoEspecialRiesgos(string cod)
		{
			return obj.ListadoCasoEspecialRiesgos(cod);
		}

		public DataTable ListadoCasoEspecialTopeConsumo(string cod, int Item)
		{
			return obj.ListadoCasoEspecialTopeConsumo(cod,Item);
		}

		//Listados

		public DataTable ListadoCasoEspecial(string strDescripcion, string IdEstado, int Item)
		{
			return obj.ListadoCasoEspecial(strDescripcion, IdEstado, Item);
		}

		public DataTable ListadoComboPlan(string IdOferta, string IdEstado)
		{
			return obj.ListadoComboPlan(IdOferta, IdEstado);
		}

		public DataTable ListadoComboEstado(int Item)
		{
			return obj.ListadoComboEstado(Item);
		}

		public DataTable ListadoComboTipoDocumento()
		{
			return obj.ListadoComboTipoDocumento();
		}

		public DataTable ListadoComboRiesgo(string strTipo)
		{
			return obj.ListadoComboRiesgo(strTipo);
		}

//		public DataTable ListadoComboTopeConsumo(string Item)
//		{
//			return obj.ListadoComboTopeConsumo(Item);
//		}

		public DataTable ListadoComboPlazoAcuerdo(string IdCasoEspecial)
		{
			return obj.ListadoComboPlazoAcuerdo(IdCasoEspecial);
		}

		public DataTable ListadoTipoCuota()
		{
			return obj.ListadoTipoCuota();
		}

		public DataTable ListarTopeConsumo(string Item)
		{
			return obj.ListarTopeConsumo(Item);
		}
		
		public DataTable ListarEstadoTope(string TipoItem)
		{
			return obj.ListarEstadoTope(TipoItem);
		}

		public DataTable ListarOferta()
		{
			return obj.ListarOferta();
		}


		//Puntos de Venta
		public DataTable ListarTipoOficina(int IdEstado)
		{
			return obj.ListarTipoOficina(IdEstado);
		}

		public ArrayList ListarPDV(string pstrCanales, string psrtIdEstado, string pstrCodigo, string pstrDescripcion)
		{
			return obj.ListarPDV(pstrCanales,psrtIdEstado,pstrCodigo,pstrDescripcion);
		}

		//Canal

//		public ArrayList ListarCanal(string strCanales,string strCodigo,string strDescripcion)
//		{
//			return obj.ListarCanal(strCanales,strCodigo,strDescripcion);
//		}
//
//		public DataTable ListarPDVTotal(string strCanales,string strCodigo,string strDescripcion)
//		{
//			return obj.ListarPDVTotal(strCanales,strCodigo,strDescripcion);
//		}
//
//		public DataTable ListarPDV(string strCodigo,string Pdv)
//		{
//			return obj.ListarPDV(strCanales,Pdv);
//		}

	}
}
