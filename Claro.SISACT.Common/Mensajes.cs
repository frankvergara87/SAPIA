using System;


namespace Claro.SisAct.Common
{

	
	

	/// <summary>
	/// Summary description for Mensajes.
	/// </summary>
	public sealed  class Mensajes
	{
	
		public const string ERROR_CARGARPAGINA = "No es posible carga la página. Consulte con el Adminsitrador";
		public const string ERROR_EJECUTAR_OPERACION = "No se ha registrado la operación. ";
		public const string ERROR_AL_VISUALIZAR_DOCUMENTO = "No existe o no es posible visualizar el documento seleccionado.";
		public const string ERROR_PAGINA_EDICION_DESCONOCIDA = "No se ha encontrado la página para la Edición del Documento";
		public const string ERROR_OBTENER_ITEMS_ACUERDOS="No se pudo recuperar los items de \n documentos de acuerdos para la solicitud.";
		public const string ERROR_NO_TIENE_PERMISO_ESCRITURA="No tiene permisos de escritura en el repositorio.";
		public const string ERROR_CREAR_ARCHIVO_DATOS ="No ha sido posible crear el archivo  con los datos del acuerdo";
		public const string ERROR_DETALLE_EQUIPOS_NO_RECUPERADOS = "No se pudo recuperar el detalle de los equipos del Acuerdo.";
		public const string ERROR_DETALLE_SERVICIOS_NO_RECUPERADOS = "No se pudo recuperar el detalle de los Servicios del Acuerdo.";
		public const string ERROR_NO_ES_POSIBLE_CREAR_ACUERDOS ="No es posible crear Acuerdos.";
		//public const string ERROR_ENVIAR_CREDITOS_aCTIVACIONES = "No ha sido posible enviar los Documentos a Créditos y Activaciones.";
		public const string ERROR_ENVIAR_CREDITOS_aCTIVACIONES = "No ha sido posible enviar los Documentos a Créditos.";

		public const string INFO_ACUERDO_YA_REGISTRADO = "El tipo de documento ya ha sido registrado para la solicitud.";
		public const string INFO_NO_DOCUMENTO_INGRESO_DATOS="No es un documento de ingreso de datos.";
		public const string INFO_SOLICITUD_NO_EXISTE = "La Solicitud {0} no existe o No pertenece a un Cliente Corporativo";
		public const string INFO_NINGUNO_ELIMINADOS =  "No ha sido posible eliminar los registros seleccionados";
		public const string INFO_NINGUNO_SELECCIONADO =  "No ha seleccionado algún registro para eliminar.";
		public const string INFO_CANTIDAD_ELIMINADOS = "Se ha(n) eliminado {0:d} registro(s).";
		public const string INFO_CANTIDAD_ELIMINADOS_ERROR = "Se ha(n) eliminado {0:d} registro(s), no se pudieron eliminar {1:d} registro(s) por tener evaluación.";
		public const string INFO_CANTIDAD_ELIMINADOS_NINGUNO = "No se pudieron eliminar {0:d} registro(s) por tener evaluación.";

		public const string INFO_SE_CERRO_ACUERDO = "El docmento ya fue cerrado anteriormente.";
		public const string INFO_ACUERDO_CERRADO_NO_EDIT = "Un documento Cerrado no es editable.";
		public const string INFO_DOCUMENTO_FUE_CERRADO = "El documento se cambió a estado Cerrado.";
		public const string INFO_NO_INGRESO_DOMICILIO_FISCAL = "No ha ingresado datos de Domicilio Fiscal";
		public const string INFO_EDITE_GRABE_DOCUMENTO = "Vuelva a editar y guarde el documento.";
		public const string INFO_SOLO_1_B01_ACTIVO_X_CLIENTE = "No es posible crear otro Acuerdo B01 activo para el mismo cliente.";
		public const string INFO_SE_REQUIERE_ACUERDO_B01 = "Para crear el Acuerdo B-03 debe existir el Acuerdo B-01 en una solicitud anterior.";
		public const string INFO_B01_B03_NO_PUEDEN_COEXISTIR ="No se puede tener acuerdo B-01 y un acuerdo B-03, para la misma solicitud.";


		//CAMBIO MARVIN
		public const string CHECKLIST_ERROR_GUARDAR_CAMBIOS = "Ocurrió un error al guardar los cambios.";
		public const string CHECKLIST_ERROR_ABRIR_PDF = "Ocurrió un error al Abrir el archivo.";
		public const string CHECKLIST_ERROR_CARGAR_EVALUACION = "Ocurrió un error al Cargar la evaluación.";
		public const string CHECKLIST_ERROR_AUDITORIA = "No se pudo registrar en Auditoria.";
		public const string CHECKLIST_ERROR = "Ocurrió un error al procesar la solicitud.";
		public const string CHECKLIST_ERROR_ARCHIVO_NO_EXISTE = "No se encontró el archivo.";

		//FIN CAMBIO

		//-- E75810 - Despacho
		public const string ERROR_SOLPER_CODIGO_REQUERIDO = "Código de la Persona asociada a una Solicitud es un dato requerido y debe ser mayor a cero.";
		public const string ERROR_SOLPER_NROSOLICITUD_REQUERIDO = "Número de Solicitud es un dato requerido y debe ser mayor a cero.";
		public const string ERROR_SOLPER_TIPOPERSONA_REQUERIDO = "Tipo de Persona asociada a la Solicitud es un dato requerido.";
		public const string ERROR_SOLPER_NOMBRE_REQUERIDO = "Nombre de Persona asociada a la Solicitud es un dato requerido.";
		public const string ERROR_SOLPER_APELLIDOPAT_REQUERIDO = "Apellido Paterno de Persona asociada a la Solicitud es un dato requerido.";
		public const string ERROR_SOLPER_ESTADO_REQUERIDO = "Estado de Persona asociada a la Solicitud es un dato requerido.";
		public const string ERROR_SOLPER_USUARIOCREA_REQUERIDO = "Usuario de Creación de Persona asociada a la Solicitud es un dato requerido.";
		public const string ERROR_SOLPER_FECHAREG_REQUERIDO = "Fecha de Registro de Persona asociada a la Solicitud es un dato requerido.";

		public const string ERROR_SOLDIR_CODIGO_REQUERIDO = "Código de la Dirección asociada a una Solicitud es un dato requerido y debe ser mayor a cero.";
		public const string ERROR_SOLDIR_NROSOLICITUD_REQUERIDO = "Número de Solicitud es un dato requerido y debe ser mayor a cero.";
		public const string ERROR_SOLDIR_TIPODIR_REQUERIDO = "Tipo de Persona de la Dirección asociada a la Solicitud es un dato requerido.";
		//FIN

		public Mensajes()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
	}
}
