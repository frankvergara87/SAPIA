<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_vendedores_dac.aspx.vb" Inherits="sisact_mant_vendedores_dac" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact Mantenimiento de Usuarios</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../estilos/general.css">
		<script language="JavaScript" src="../../librerias/lib_funcvalidacion.js"></script>
		<script language="JavaScript" src="../../librerias/DATE-PICKER.JS"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio()
			{
				mostrarTabVisible('Inicio');
				cambiarEstado();
				
				var valor = getValue('hidMostrar');
				var perfil= getValue('hidTipo');
				var estado= getValue('hidEstadoId');
				
				document.getElementById("tblUsuario").style.width="980px";
				var CantUsuario = getValue('hidCantidadUsuario');
				if (CantUsuario!= '' || CantUsuario != 0)retornaCantidadDG('divUsuario',CantUsuario,'480');							
				if (getValue('HidMsg') != ''){
					alert(getValue('HidMsg'));
					setValue('HidMsg','');
				}	

				mostrarTabVisible(valor);
							
				if(perfil=='VendedorDac'){
					setValueHTML('tdOficinaUsuario','Distribuidor');
					setVisible('ddlEstado',true);
					setVisible('tdLabelEstado',true);
					setVisible('tdLabel2Estado',true);
					setVisible('ddlOficina',false);
					setVisible('trCodBSCS',false);
					//alert("segui"+perfil);
				}
				//else if(perfil != 'FortelMantVendedor'){
				//	setVisible('tdAgregar',false);
				//}
				
				if (perfil=='UniversidadClaro')
				{
					setVisible('trVerificacionReniec',true);
				}
				else
				{
					setVisible('trVerificacionReniec',false);
				}
								
				if (perfil != 'FortelMantVendedor')
				{
					setEnabled('btnCargar',false,'');			
				}

				//Fortel
				if (perfil=='FortelMantVendedor' || perfil == 'ProveedorExterno')
					setVisible('btnBuscarPDV',true);
				else
					setVisible('btnBuscarPDV',false);
				
				
				if (getValue('HidMsg') != ''){
							alert(getValue('HidMsg'));
							setValue('HidMsg','');
						}
						
				if (perfil=='UniversidadClaro' || perfil=='SoporteOperacional' || ( estado!='' && estado!='00' && estado!='01') )
				{
					document.frmPrincipal.txtNombreUsuario.readOnly=true;
					document.frmPrincipal.txtNumeroDocumento.readOnly=true;
					document.frmPrincipal.txtDireccion.readOnly=true;
					document.frmPrincipal.txtFechaNacimiento.readOnly=true;
					//document.frmPrincipal.txtNumeroCelular.readOnly=true;
					setVisible('a_txtFechaNacimiento',false);
					//document.getElementById('ddlPuntoVenta').disabled=true;
				}
				
				var numEstados = getValue('hidCountEstados');
				
				if (numEstados == '0')
				{
					setVisible('ddlEstado',false);
					setVisible('tdLabelEstado',false);
					setVisible('tdLabel2Estado',false);
					if (perfil != 'VendedorDac')
					{
						setVisible('btnAceptar',false);
					}
				}
				else
				{
					setVisible('ddlEstado',true);
					setVisible('tdLabelEstado',true);
					setVisible('tdLabel2Estado',true);
					setVisible('btnAceptar',true);
				}
				
				if (getValue('hidMostrarUsuarioBD') == 'SI')
				{
					setValue('txtCodUsuario',getValue('hidVendedorIdBD'));
					setValue('txtNumeroDocumento',getValue('hidDniBD'));
					setValue('txtNombreUsuario',getValue('hidNombreBD'));
					setValue('txtDireccion',getValue('hidDireccionBD'));
					setValue('txtFechaNacimiento',getValue('hidFechaNacimientoBD'));
					setValue('txtNumeroCelular',getValue('hidNumeroCelularBD'));
					
					document.frmPrincipal.txtNombreUsuario.readOnly=true;
					document.frmPrincipal.txtNumeroDocumento.readOnly=true;
					document.frmPrincipal.txtDireccion.readOnly=true;
					document.frmPrincipal.txtFechaNacimiento.readOnly=true;
					//document.frmPrincipal.txtNumeroCelular.readOnly=true;
					setVisible('a_txtFechaNacimiento',false);
					setVisible('trVerificacionReniec',false);
					setVisible('trVerificacionReniec',false);
					setVisible('btnAceptar',false);		
					
					//Como se hara con el distribuidor, punto de venta y estado
					
					//setValue('hidDistribuidorId',distribuidorId);
					//setValue('hidPuntoVentaId',Punto_Venta);
					setVisible('ddlEstado',false);
					setVisible('tdLabelEstado',false);
					setVisible('tdLabel2Estado',false);	
					//setValue('ddlPuntoVenta','00');
					//document.getElementById('ddlPuntoVenta').disabled=true;
				}
				
				if(getValue('hidProceso') == 'BuscarPDV'){
					setVisible('updateClaveShadow', true);
					setVisible('PDVContent', true);
					setFocus('txtBusPDV');
				}else{
					setVisible('updateClaveShadow', false);
					setVisible('PDVContent', false);				
				}
				
				
			}
			
			function mostrarTabVisible(valor){
			
				if (valor == 'Inicio'){
					setVisible('tblUsuario',false);	
				}
				
				if (valor == 'Listado'){
				
					setVisible('tblUsuario',true);	
					setVisible('trBusqueda',true);	
					setVisible('trUsuario',true);	
					setVisible('trDetalleUsuario',false);	
					setVisible('trCargaMasiva',false);	
					document.getElementById('tdListado').className='tab_activo';
					
					document.getElementById('tdAgregar').className='tab_inactivo';
					
					document.getElementById('tdModificar').className='tab_inactivo';
				    document.getElementById('tdCargaMasiva').className='tab_inactivo';
					setVisible('tdModificar',false);
					setVisible('tdAgregar',true);
					setValue('hidMostrar',valor);
					setFocus('txtBusUsuario');	
					setValue('txtCodUsuario','');
					setValue('txtNombreUsuario','');
					setValue('txtDireccion','');
					setValue('txtNumeroDocumento','');
					setValue('txtFechaNacimiento','');
					setValue('txtNumeroCelular','');
					//setValue('ddlPuntoVenta','00');
					setValue('txtCodVendedor','');
					setValue('hidCodVendedor','');
					setValue('txtMotivo','');
					setValue('hidMostrarUsuarioBD','');
					setValue('hidVendedorIdBD','');
					setValue('hidDniBD','');
					setValue('hidNombreBD','');
					setValue('hidDireccionBD','');
					setValue('hidFechaNacimientoBD','');
					setValue('hidNumeroCelularBD','');
					setValue('txtProv_Exte','');
					
					document.frmPrincipal.txtNombreUsuario.readOnly=false;
					document.frmPrincipal.txtNumeroDocumento.readOnly=false;
					document.frmPrincipal.txtDireccion.readOnly=false;
					document.frmPrincipal.txtFechaNacimiento.readOnly=false;
					//document.frmPrincipal.txtNumeroCelular.readOnly=false;
					setVisible('a_txtFechaNacimiento',true);
					setVisible('btnAceptar',true);
					//document.getElementById('ddlPuntoVenta').disabled=false;
					setValue('hidLimpiarMasi','');
					
				}
				if (valor == 'Modificar'){
					setVisible('tblUsuario',true);	
					setVisible('trBusqueda',false);	
					setVisible('trUsuario',false);	
					setVisible('trCargaMasiva',false);
					setVisible('trDetalleUsuario',true);	
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').className='tab_inactivo';
					document.getElementById('tdModificar').className='tab_activo';
			        document.getElementById('tdCargaMasiva').className='tab_inactivo';
					setVisible('tdModificar',true);
					setVisible('tdAgregar',false);
					setValue('hidMostrar',valor);
					setFocus('txtNombreUsuario');	
					document.getElementById('txtCodUsuario').className='clsInputDisable';
					document.frmPrincipal.txtCodUsuario.readOnly=true;
					
					setVisible('ddlEstado',true);
					setVisible('tdLabelEstado',true);
					setVisible('tdLabel2Estado',true);
					setValue('hidLimpiarMasi','');

				}				
				if (valor == 'Agregar'){
					setVisible('tblUsuario',true);	
					setVisible('trBusqueda',false);	
					setVisible('trUsuario',false);	
					setVisible('trCargaMasiva',false);	
					setVisible('trDetalleUsuario',true);	
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').className='tab_activo';
					document.getElementById('tdModificar').className='tab_inactivo';
					document.getElementById('tdCargaMasiva').className='tab_inactivo';
					setVisible('tdModificar',false);
					setVisible('tdAgregar',true);
					setValue('hidMostrar',valor);
					setFocus('txtCodUsuario');	
					document.getElementById('txtCodUsuario').className='clsInputDisable';
					document.frmPrincipal.txtCodUsuario.readOnly=true;
					setVisible('ddlEstado',false);
					setVisible('tdLabelEstado',false);
					setVisible('tdLabel2Estado',false);
					
					setValue('txtEstado','NUEVO');
					
					document.frmPrincipal.txtNombreUsuario.readOnly=false;
					document.frmPrincipal.txtNumeroDocumento.readOnly=false;
					document.frmPrincipal.txtDireccion.readOnly=false;
					document.frmPrincipal.txtFechaNacimiento.readOnly=false;
					//document.frmPrincipal.txtNumeroCelular.readOnly=false;
					document.frmPrincipal.ddlTipoDocumento.disabled=false;
					setVisible('a_txtFechaNacimiento',true);
					setVisible('btnAceptar',true);
					//document.getElementById('ddlPuntoVenta').disabled=false;
					setValue('hidLimpiarMasi','');
				}
				
				if (valor == 'CargaMasiva'){
					
					setVisible('tblUsuario',true);	
					setVisible('trBusqueda',false);	
					setVisible('trUsuario',false);	
					setVisible('trDetalleUsuario',false);
					setVisible('trCargaMasiva',true);	
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdCargaMasiva').className='tab_activo';
					document.getElementById('tdAgregar').className='tab_inactivo';
					document.getElementById('tdModificar').className='tab_inactivo';
					//setVisible('listNoCargaron',false);
					//setVisible('listBlack',false);
					//setVisible('noCargados',false);
					//setVisible('enBlackList',false);
					setVisible('tdModificar',false);
					setVisible('tdAgregar',true);
					setValue('hidMostrar',valor);
					setValue('hidProceso',valor);
					
					
					if(getValue('hidLimpiarMasi') != 'NO_LIMPIAR')
					{
						setValueInnerText('lblRegistrados','');
						setValueInnerText('lblNoRegistrados','');
					    setValue('txtListaNoCargaron','');
						setValue('txtListaBlack','');
					}
										
					if(getValue('hidMensaje') != '')
					{
						alert(getValue('hidMensaje'));		
					}
					setValue('hidMensaje','');
					
					//------------limpia----------------
					setVisible('tdModificar',false);
					setVisible('tdAgregar',true);
					setValue('hidMostrar',valor);
					//setFocus('txtBusUsuario');	
					setValue('txtCodUsuario','');
					setValue('txtNombreUsuario','');
					setValue('txtDireccion','');
					setValue('txtNumeroDocumento','');
					setValue('txtFechaNacimiento','');
					setValue('txtNumeroCelular','');
					//setValue('ddlPuntoVenta','00');
					setValue('txtCodVendedor','');
					setValue('hidCodVendedor','');
					setValue('txtMotivo','');
					setValue('hidMostrarUsuarioBD','');
					setValue('hidVendedorIdBD','');
					setValue('hidDniBD','');
					setValue('hidNombreBD','');
					setValue('hidDireccionBD','');
					setValue('hidFechaNacimientoBD','');
					setValue('hidNumeroCelularBD','');
					setValue('txtProv_Exte','');
					//------------limpia----------------
				}
				
				
				if (getValue('hidPerfiles') == 'SACT_UCL' || getValue('hidPerfiles') == 'SACT_SOP')
				{
					setVisible('tdAgregar',false);
				}
			}
			
            
			function retornaCantidadDG(dg,cantidad,maximo){
			/*
				if (cantidad=='') 
					cantidad = 3; var h = 30 * parseInt(cantidad,10); 
				if(h>parseInt(maximo,10)) 
					document.getElementById(dg).style.height = maximo + "px"; 
				else 
					document.getElementById(dg).style.height = h +"px"; 			*/
			}

			function f_Modificar(UsuarioId,Nombre,Numero_Documento,distribuidorId,Fecha_Registro,Estado,Direccion,Tipo_Documento,Fecha_Nacimiento,Punto_Venta,Fecha_Modificacion,Usuario_Registro,Usuario_Modificacion,EstadoId,VerificacionReniec,NumeroCelular,Prov_exter)
			{
				var vPerfilId = getValue('hidPerfiles');
				
				if (vPerfilId == 'SACT_DIST')
				{
					if (EstadoId == '01' || EstadoId == '02')
					{
						f_cargarDatosModificacion(UsuarioId,Nombre,Numero_Documento,distribuidorId,Fecha_Registro,Estado,Direccion,Tipo_Documento,Fecha_Nacimiento,Punto_Venta,Fecha_Modificacion,Usuario_Registro,Usuario_Modificacion,EstadoId,VerificacionReniec, NumeroCelular,Prov_exter)
					}
					else
					{
						alert("No se puede modificar vendedor");
					}
				}
				else if (vPerfilId == 'SACT_UCL')
				{
					if (EstadoId == '01' || EstadoId == '02' || EstadoId == '03' || EstadoId == '05')
					{
						f_cargarDatosModificacion(UsuarioId,Nombre,Numero_Documento,distribuidorId,Fecha_Registro,Estado,Direccion,Tipo_Documento,Fecha_Nacimiento,Punto_Venta,Fecha_Modificacion,Usuario_Registro,Usuario_Modificacion,EstadoId,VerificacionReniec, NumeroCelular,Prov_exter)
					}
					else
					{
						alert("No se puede modificar vendedor");
					}
				}
				else if (vPerfilId == 'SACT_SOP')
				{
					f_cargarDatosModificacion(UsuarioId,Nombre,Numero_Documento,distribuidorId,Fecha_Registro,Estado,Direccion,Tipo_Documento,Fecha_Nacimiento,Punto_Venta,Fecha_Modificacion,Usuario_Registro,Usuario_Modificacion,EstadoId,VerificacionReniec, NumeroCelular,Prov_exter)
				}
				else if (vPerfilId == 'SACT_FORT')
				{
						f_cargarDatosModificacion(UsuarioId,Nombre,Numero_Documento,distribuidorId,Fecha_Registro,Estado,Direccion,Tipo_Documento,Fecha_Nacimiento,Punto_Venta,Fecha_Modificacion,Usuario_Registro,Usuario_Modificacion,EstadoId,VerificacionReniec, NumeroCelular,Prov_exter)
				}
				else if (vPerfilId == 'PROV_EXT')
				{
						f_cargarDatosModificacion(UsuarioId,Nombre,Numero_Documento,distribuidorId,Fecha_Registro,Estado,Direccion,Tipo_Documento,Fecha_Nacimiento,Punto_Venta,Fecha_Modificacion,Usuario_Registro,Usuario_Modificacion,EstadoId,VerificacionReniec, NumeroCelular,Prov_exter)
				}
				else
				{
					alert("No se puede modificar vendedor");
				}
			}
			
			function f_cargarDatosModificacion(UsuarioId,Nombre,Numero_Documento,distribuidorId,Fecha_Registro,Estado,Direccion,Tipo_Documento,Fecha_Nacimiento,Punto_Venta,Fecha_Modificacion,Usuario_Registro,Usuario_Modificacion,EstadoId,VerificacionReniec, NumeroCelular,Prov_exter)
			{
				setValue('txtCodUsuario',UsuarioId);
				setValue('txtNombreUsuario',Nombre);
				setValue('txtNumeroDocumento',Numero_Documento);
				setValue('hidDistribuidorId',distribuidorId);
				setValue('hidEstadoId',EstadoId);			
				setValue('txtDireccion',Direccion);
				setValue('ddlTipoDocumento',Tipo_Documento);
				setValue('hidTipoDocumento',Tipo_Documento);
				setValue('txtFechaNacimiento',Fecha_Nacimiento.substring(0,10));
				setValue('txtNumeroCelular', NumeroCelular);
				setValue('hidPuntoVentaId',Punto_Venta);
				setValue('hidTipoDocumentoId',Tipo_Documento);
				setValue('hidMostrar','Modificar');
				setValue('hidProceso','Modificar');
				setValue('hidVerRen',VerificacionReniec);
				setValue('txtProv_Exte',Prov_exter);

				document.frmPrincipal.submit();
			}

			function f_Eliminar(UsuarioId,Nombre,Estado){
				if (estado == 'ACTIVO' || estado == '1'){					
					if (confirm("¿Está Seguro Desactivar al usuario: " + nombre + "?")){
						setValue('txtCodUsuario',usuarioId);
						setValue('hidProceso','Eliminar');
						document.frmPrincipal.submit();		
					}
				}else{
					alert("El Usuario " + nombre + " se encuentra Inactivo.");					
				}
			}
			
			function Aceptar(){		

					var fecNac = getValue('txtFechaNacimiento');
					
					if (getValue('txtFechaNacimiento') == ''){
							alert("Debe seleccionar el campo Fecha de Nacimiento");
							setFocus('txtFechaNacimiento');	
							return false;
					}
					
					if (validarFecha('txtFechaNacimiento') == false)
					{
						setFocus('txtFechaNacimiento');
						return false;
					}
					
					if(!esFechaValida(fecNac)){
						return false;
					}
				
					var fecha= FechaActual();				
					var fechaActual=fecha.substr(6,4)+ fecha.substr(3,2) + fecha.substr(0,2);
					var fechaNacimiento = fecNac.substr(6,4)+ fecNac.substr(3,2) + fecNac.substr(0,2);			
					

					if(fechaNacimiento>fechaActual){
						alert("La fecha de nacimiento no puede ser mayor a hoy.");
						return false;
					}
					
					

					if (getValue('ddlTipoDocumento') == '00' || getValue('ddlTipoDocumento') == ''){
							alert("No ha seleccionado Tipo de Documento.");
							setFocus('ddlTipoDocumento');	
							return false;
					}
					if(getValue('ddlTipoDocumento') == '01'){
						 if (!ValidaDNI('document.frmPrincipal.txtNumeroDocumento','el campo Numero de Documento',false)) return false;												
					}
					if (!ValidaNombre('document.frmPrincipal.txtNombreUsuario','el campo Nombres y Apellidos ',false)) return false;												
					if (!ValidaDireccion('document.frmPrincipal.txtDireccion','el campo Direccion ',false)) return false;												
			    	
			    	//Validar NumeroCelular
			    	
					
					
				/*if (getValue('ddlPuntoVenta') == '00' || getValue('ddlPuntoVenta') == ''){
						alert("No ha seleccionado Punto de Venta.");
						setFocus('ddlPuntoVenta');	
						return false;
				}
				
				var now = new Date();
				var fechaActual = now.getDate() + "/" + now.getMonth() + "/" + now.getYear();
				if (getValue('txtFechaNacimiento') > fechaActual){
						alert("La fecha de nacimiento no puede ser mayor a hoy.");
						setValue('txtFechaNacimiento',"");
						return false;
				}*/
				
				if (document.getElementById('trMotivo').style.display == 'block' && document.getElementById('txtMotivo').value == ''){
						alert("Debe ingresar un motivo");
						return false;
					}
					
				if (!document.getElementById('chbVerificacionReniec').checked && document.getElementById('trVerificacionReniec').style.display != 'none'){
						alert("Debe realizar la validación en RENIEC");
						return false;
					}
				
				if (confirm("¿Está seguro de grabar los datos?")){
					//var RetornarFlexibilizacion = getValue('hidNuevoUsuario');
					setValue('hidProceso','Grabar');
					var codVendedor = getValue('txtCodVendedor');
					setValue('hidCodVendedor',codVendedor);
					var OficinaId = getValue('ddlOficina');
					setValue('hidOficinaId',OficinaId);
					document.frmPrincipal.submit();						
				}
			}
			function Cancelar(){
				var valor = getValue('hidMostrar');
				if (valor == 'AgregarAutorizador'){
					window.close();
				}else{
					setValue('hidProceso','');
					mostrarTabVisible('Listado');
				}
			}					
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						f_Buscar(false);	
						event.keyCode = 0;
					}
				}	
			}	
			
			function f_Validar_DNI(){
				//alert("s");
				if(getValue('ddlBusqueda')=='2'){
					if (!ValidaDNI('document.frmPrincipal.txtBusUsuario','el campo de busqueda',false)) return false;	
				}
			}		
			
			function f_Buscar(limpiar){
				if (limpiar == true){ 
					setValue('txtBusUsuario','');
					
				}
				if (getValue('ddlBusqueda')=='0' && getValue('txtBusUsuario')==''){
					alert('Debe ingresar un Nombre o Apellido');
					return;
				}					
				if (getValue('ddlBusqueda')=='2' && getValue('txtBusUsuario')==''){
					alert('Debe ingresar DNI');
					return;
				}
				setValue('hidProceso','Buscar');
				document.frmPrincipal.submit();	
			}
			
			function e_alfaNumerico(){
				var j = event.keyCode;
				var flag = true;
				if (!(((j>=48)&&(j<=57))||((j>96)&&(j<=123))||((j>64)&&(j<=91))||(j==38)||(j==45)||(j==209)||(j==225)||(j==233)||(j==237)||(j==241)||(j==243)||(j==250))) flag=false;
				if (flag == true) {
					e_mayuscula();
				}else{
					event.keyCode = 0;
				}
			}
					
			function e_numero(){
				if ( !( (event.keyCode>=48) && (event.keyCode<=57)) && !(event.keyCode==13) )
				event.keyCode=0;
			}
			
			function e_numeroBSCS(){
				if ( !( (event.keyCode>=48) && (event.keyCode<=57)) && !(event.keyCode==13) && !(event.keyCode==46) )
				event.keyCode=0;
			}
			
			function e_mayuscula() {
				if ((event.keyCode>96&&event.keyCode<123)||(event.keyCode==241)||(event.keyCode==250)||(event.keyCode==243)||(event.keyCode==237)||(event.keyCode==233)||(event.keyCode==225))
					event.keyCode=event.keyCode-32;
					
			}
			
			function cambiarEstado(){
				if(getValue('ddlBusqueda')=='0' || getValue('ddlBusqueda')=='5'){
					
					document.getElementById('txtBusUsuario').className='clsInputEnable';
					document.frmPrincipal.txtBusUsuario.readOnly=false;
					
				}else if(getValue('ddlBusqueda')=='1'){
					setValue('txtBusUsuario','');
					document.getElementById('txtBusUsuario').className='clsInputDisable';
					document.frmPrincipal.txtBusUsuario.readOnly=true;
				}else if(getValue('ddlBusqueda')=='2'){
					document.getElementById('txtBusUsuario').className='clsInputEnable';
					document.frmPrincipal.txtBusUsuario.readOnly=false;
				}
			}
			
			function validarMotivo()
			{
				if (getValue('ddlEstado') == '03' || getValue('ddlEstado') == '04' || getValue('ddlEstado') == '06')
				{
					document.getElementById('trMotivo').style.display = 'block';
					document.getElementById('txtMotivo').value = '';
				}
				else
				{
					document.getElementById('trMotivo').style.display = 'none';
					document.getElementById('txtMotivo').value = '';
				}
			}
			
			function f_EventoSoloNumeros()
			{
				var CaracteresPermitidos = '0123456789';
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++) 
				{
						if (key == valid.substring(i,i+1))
							ok = "yes"        
				}
				if(window.event.keyCode != 16){
					if (ok == "no")
							window.event.keyCode=0
				}
			}
			
			function BuscarPDV(){
				
				
				f_limpiar();

		    }
		    
		    
		    //-----------------------------------------
		    
		    function f_BuscarContPDV(limpiar){
				
				if (limpiar == true){ 
					setValue('txtBusPDV','');
					
				}
				
				if (getValue('ddlBusquedaPDV')=='0' && getValue('txtBusPDV')==''){
					alert('Debe ingresar un nombre del pdv');
					return;
				}	
								
				setValue('hidProceso','BuscarPDV');
				document.frmPrincipal.submit();	
				
			}
			
			//-----------------------------------------
			
			function seleccionarFila(opt){
				document.frmPrincipal.hidCodigoPDV.value = '';
				document.frmPrincipal.hidNombrePDV.value = '';
				
				if (opt.checked){
				
					document.frmPrincipal.hidCodigoPDV.value = opt.CodigoPDV;
					document.frmPrincipal.hidNombrePDV.value = opt.NombrePDV;
					
					if(getValue('hidCodigoPDV') != '' && getValue('hidNombrePDV') != ''){
				
						setValue('hdDesPDV', opt.NombrePDV);
						setValue('hdCodPDV', opt.CodigoPDV);
						setValue('hdPExt', opt.PrExterno);
						setValue('hidProceso','PDV');
						
						document.frmPrincipal.submit();
					 
					}
				}
			}
		    
		    //-----------------------------------------
			
			function f_limpiar(){
			
				setValue('txtBusPDV','');
				setValue('hidProceso','Limpiar');
				document.frmPrincipal.submit();
						
			}
			
			function f_cancelar(){
				
				setValue('txtBusPDV','');
				setVisible('updateClaveShadow', false);
				setVisible('PDVContent', false);
				setValue('hidProceso','Cancelar');
				document.frmPrincipal.submit();
			}
			
			
		</script>
	</HEAD>
	<body onload="inicio()">
		<div style="Z-INDEX: 5; POSITION: absolute; FILTER: alpha(opacity=45); BACKGROUND-COLOR: darkgray; WIDTH: 100.86%; DISPLAY: none; HEIGHT: 96.6%; opacity: 0.45"
			id="updateClaveShadow"></div>
		<form id="frmPrincipal" method="post" runat="server">
			<!-- ================================================================================================================= -->
			<div style="Z-INDEX: 9; POSITION: absolute; MARGIN-TOP: -189px; WIDTH: 500px; DISPLAY: none; HEIGHT: 400px; MARGIN-LEFT: -321px; OVERFLOW: auto; TOP: 50%; LEFT: 50%"
				id="PDVContent">
				<table style="WIDTH: 100%; HEIGHT: 400px; TOP: 1px; LEFT: 1px" id="tblPDV" class="contenido"
					border="0" cellSpacing="0" cellPadding="0">
					<tr id="trTituloPDV">
						<td style="WIDTH: 100%; HEIGHT: 23px" class="header" align="center"><asp:label id="lblTipoMantPDV" runat="server" text="Buscar Punto de Venta"></asp:label></td>
					</tr>
					<tr>
						<td height="5"></td>
					</tr>
					<tr>
						<td style="HEIGHT: 26px" class="Arial10B">&nbsp;<asp:dropdownlist id="ddlBusquedaPDV" runat="server" cssclass="clsSelectEnable"></asp:dropdownlist>
							&nbsp;<asp:textbox onkeydown="javascript:f_ValidarEnter();" id="txtBusPDV" runat="server" cssclass="clsInputEnable"></asp:textbox>&nbsp;
							<input id="btnBuscarG" class="Boton" onclick="f_BuscarContPDV(false)" value="Buscar" type="button"
								name="btnBuscar"> <input id="btnLimpiar" class="Boton" onclick="f_limpiar()" value="Limpiar" type="button"
								name="btnLimpiar"> <input id="btnCancelarPDV" class="Boton" onclick="f_cancelar();" value="Cancelar" type="button"
								name="btnCancelarPDV">
						</td>
					</tr>
					<tr>
						<td style="HEIGHT: 26px" class="Arial10B"><asp:datagrid id="dgCabPdv" runat="server" showheader="True" autogeneratecolumns="False" width="100%">
								<columns>
									<asp:boundcolumn headertext=" ">
										<headerstyle wrap="False" horizontalalign="Center" cssclass="TablaTitulos" Width="25px"></headerstyle>
									</asp:boundcolumn>
									<asp:templatecolumn headertext="CÓDIGO">
										<headerstyle horizontalalign="Center" cssclass="TablaTitulos" Width="150px"></headerstyle>
									</asp:templatecolumn>
									<asp:templatecolumn headertext="PUNTO DE VENTA">
										<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
									</asp:templatecolumn>
								</columns>
							</asp:datagrid></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:datagrid id="dgPdv" runat="server" showheader="False" autogeneratecolumns="False" width="100%">
								<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
								<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
								<columns>
									<asp:TemplateColumn HeaderText="Sel">
										<HeaderStyle Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
										<ItemStyle Width="25px"></ItemStyle>
										<ItemTemplate>
											<input type="radio" name=id="optSelUsuario"	
												CodigoPDV='<%#DataBinder.Eval(Container.DataItem, "OVENC_CODIGO")%>'	
												NombrePDV='<%#DataBinder.Eval(Container.DataItem, "OVENV_DESCRIPCION")%>'	
												PrExterno='<%#IIf(DataBinder.Eval(Container.DataItem, "PROV_EXTERNO")="","CLARO",DataBinder.Eval(Container.DataItem, "PROV_EXTERNO"))%>'															
												onclick = 'seleccionarFila(this);'																	
											/>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:boundcolumn datafield="OVENC_CODIGO" itemstyle-cssclass="Arial10B">
										<headerstyle horizontalalign="center"></headerstyle>
										<itemstyle wrap="false" horizontalalign="center" Width="150px"></itemstyle>
									</asp:boundcolumn>
									<asp:boundcolumn datafield="OVENV_DESCRIPCION" itemstyle-cssclass="Arial10B">
										<headerstyle horizontalalign="center"></headerstyle>
										<itemstyle wrap="false" horizontalalign="left"></itemstyle>
									</asp:boundcolumn>
									<asp:boundcolumn datafield="PROV_EXTERNO" itemstyle-cssclass="Arial10B" Visible="False">
										<headerstyle horizontalalign="center"></headerstyle>
										<itemstyle wrap="false" horizontalalign="left"></itemstyle>
									</asp:boundcolumn>
								</columns>
							</asp:datagrid></td>
					</tr>
					<tr>
						<td><input id="hidTipoUsuarioId" type="hidden" name="hidTipoUsuarioId" runat="server">
							<input id="hidCodigoPDV" type="hidden" name="hidCodigoPDV" runat="server"> <input id="hidNombrePDV" type="hidden" name="hidNombrePDV" runat="server">
							<input id="hidLogin" type="hidden" name="hidLogin" runat="server"> <input id="hidEstadoUsuario" type="hidden" name="hidEstadoUsuario" runat="server">
						</td>
					</tr>
				</table>
			</div>
			<!-- ================================================================================================================= -->
			<table style="POSITION: absolute; WIDTH: 690px; TOP: 1px; LEFT: 1px" id="tblUsuario" class="contenido"
				border="0" cellSpacing="0" cellPadding="0">
				<tr id="trTitulo">
					<td style="WIDTH: 100%; HEIGHT: 23px" class="header" align="center"><asp:label id="lblTipoMant" runat="server" text=""></asp:label></td>
				</tr>
				<tr>
					<td style="WIDTH: 980px">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td>
									<table border="0" cellSpacing="0" cellPadding="0">
										<tr>
											<td><IMG src="../../spacer.gif" width="2" height="2"></td>
											<td id="tdListado" class="tab_activo" borderColor="#000099" width="122" align="center"><A href="javascript:mostrarTabVisible('Listado');">Listado</A></td>
											<td><IMG src="../../spacer.gif" width="2" height="2"></td>
											<td id="tdAgregar" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:mostrarTabVisible('Agregar');">Agregar</A></td>
											<td id="tdModificar" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:mostrarTabVisible('Modificar');">Modificar</A></td>
											<td class="tab_inactivo" id="tdCargaMasiva" borderColor="#000099" align="center" width="122"><A href="javascript:mostrarTabVisible('CargaMasiva');">Carga 
													Masiva</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trBusqueda">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td style="WIDTH: 100%; HEIGHT: 20px" class="header" height="20" colSpan="2">&nbsp;Busqueda 
												de Usuarios</td>
										</tr>
										<tr>
											<td style="HEIGHT: 26px" class="Arial10B">&nbsp;<asp:dropdownlist id="ddlBusqueda" onclick="cambiarEstado();" runat="server" cssclass="clsSelectEnable"></asp:dropdownlist>
												&nbsp;<asp:textbox onkeydown="javascript:f_ValidarEnter();" id="txtBusUsuario" runat="server" cssclass="clsInputEnable"
													width="400px"></asp:textbox>&nbsp;<input id="btnBuscar" class="Boton" onclick="f_Buscar(false)" value="Buscar" type="button"
													name="btnBuscar">&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trUsuario">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0">
										<tr>
											<td><asp:datagrid id="dgCabUsuario" runat="server" showheader="True" autogeneratecolumns="False" width="1060px">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CÓDIGO" headerstyle-width="50px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="NOMBRES Y APELLIDOS" headerstyle-width="310px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="310px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="DNI" headerstyle-width="50px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PUNTO DE VENTA" headerstyle-width="200px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="200px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FECHA ACTUALIZACION" headerstyle-width="100px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO" headerstyle-width="150px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="150px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="NRO CELULAR" headerstyle-width="100px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px"></headerstyle>
														</asp:templatecolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div style="WIDTH: 1072px;HEIGHT: 400px" id="divUsuario" class="clsGridRow">
										<table border="0" cellSpacing="0" cellPadding="0" width="1060">
											<tr>
												<td><asp:datagrid id="dgUsuario" runat="server" autogeneratecolumns="False" width="1056px" ShowHeader="false">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "VendedorId")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "Nombre")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "NumeroDocumento")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "DistribuidorId")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "FechaRegistro")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "Estado")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "Direccion")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "TipoDocumento")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "FechaNacimiento")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "PuntoVentaId")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "FechaModificacion")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "UsuarioRegistroId")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "UsuarioModificacionId")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "EstadoId")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "VerificacionReniec")%>",
																									"<%# DataBinder.Eval(Container.DataItem, "NumeroCelular")%>",
																									"<%# IIf(DataBinder.Eval(Container.DataItem, "Prov_exter")="","CLARO", DataBinder.Eval(Container.DataItem, "Prov_exter"))%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Usuario'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="VendedorId" headertext="CÓDIGO">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Nombre" headertext="NOMBRES Y APELLIDOS">
																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="310px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NumeroDocumento" headertext="DNI">
																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DistribuidorDescripcion" headertext="PUNTO DE VENTA">
																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="200px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FechaRegistro" headertext="FECHA ACTUALIZACION">
																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EstadoDescripcion" headertext="ESTADO">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NumeroCelular" headertext="Nro Celular">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Prov_exter" headertext="Prov. Externo" Visible="false">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
													</asp:datagrid></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<tr id="trDetalleUsuario">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TBODY>
											<tr>
												<td style="WIDTH: 1079px" class="header" height="25" colSpan="6">Detalle Usuario</td>
											</tr>
											<tr>
												<td style="HEIGHT: 16px" class="Arial10B" noWrap>Código</td>
												<td style="HEIGHT: 16px" class="Arial10B" noWrap>:&nbsp;</td>
												<td style="WIDTH: 305px; HEIGHT: 16px" class="Arial10B" noWrap><asp:textbox id="txtCodUsuario" runat="server" cssclass="clsInputDisable" readonly maxlength="4"></asp:textbox></td>
												<td style="WIDTH: 62px; HEIGHT: 16px" id="tdLabelEstado" class="Arial10B" noWrap>Estado</td>
												<td style="WIDTH: 1px; HEIGHT: 16px" id="tdLabel2Estado" class="Arial10B">:&nbsp;</td>
												<td style="WIDTH: 586px; HEIGHT: 16px" class="Arial10B"><asp:dropdownlist id="ddlEstado" runat="server" cssclass="clsSelectEnable" Visible="false" onchange="validarMotivo()"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td style="HEIGHT: 20px" class="Arial10B" noWrap>Tipo Documento</td>
												<td style="HEIGHT: 20px" class="Arial10B" noWrap>:&nbsp;</td>
												<td style="WIDTH: 305px; HEIGHT: 22px" class="Arial10B" noWrap><asp:dropdownlist id="ddlTipoDocumento" runat="server" cssclass="clsSelectEnable" Width="128px"></asp:dropdownlist></td>
												<td style="WIDTH: 62px; HEIGHT: 22px" class="Arial10B">Nro de Documento</td>
												<td style="WIDTH: 1px; HEIGHT: 22px" class="Arial10B">:&nbsp;</td>
												<td style="WIDTH: 586px; HEIGHT: 22px" class="Arial10B"><asp:textbox id="txtNumeroDocumento" onkeypress="return f_EventoSoloNumeros();" runat="server"
														cssclass="clsInputEnable" maxlength="8" Width="104px"></asp:textbox></td>
											</tr>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 20px" class="Arial10B" noWrap>Nombres y Apellidos</TD>
												<TD style="WIDTH: 2px; HEIGHT: 20px" class="Arial10B" noWrap>:&nbsp;</TD>
												<TD style="WIDTH: 941px; HEIGHT: 20px" class="Arial10B" colSpan="4"><asp:textbox id="txtNombreUsuario" onkeypress="e_mayuscula()" runat="server" cssclass="clsInputEnable"
														width="480px" maxlength="300" Height="20px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 20px" class="Arial10B" noWrap>Dirección</TD>
												<TD style="WIDTH: 2px; HEIGHT: 20px" class="Arial10B" noWrap>:&nbsp;</TD>
												<TD style="WIDTH: 941px; HEIGHT: 20px" class="Arial10B" colSpan="4"><asp:textbox id="txtDireccion" onkeypress="e_mayuscula()" runat="server" cssclass="clsInputEnable"
														width="480px" maxlength="300" Height="20px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 21px" class="Arial10B" noWrap>Fecha de Nacimiento</TD>
												<TD style="WIDTH: 2px; HEIGHT: 21px" class="Arial10B" noWrap>:&nbsp;</TD>
												<TD style="WIDTH: 305px; HEIGHT: 21px" class="Arial10B" noWrap><asp:textbox id="txtFechaNacimiento" runat="server" cssclass="clsInputEnable" maxlength="10"
														ReadOnly></asp:textbox>&nbsp; <A id="a_txtFechaNacimiento" onmouseover="window.status='Hacer clic para ver calendario';return true;"
														onmouseout="window.status='';return true;" href="javascript:show_calendar('frmPrincipal.txtFechaNacimiento','../../');">
														<IMG border="0" src="../../images/btn_Calendario.gif"></A>
												</TD>
												<td style="WIDTH: 62px; HEIGHT: 21px" class="Arial10B">Celular</td>
												<td style="WIDTH: 1px; HEIGHT: 21px" class="Arial10B">:&nbsp;</td>
												<td style="WIDTH: 586px; HEIGHT: 21px" class="Arial10B"><asp:textbox id="txtNumeroCelular" onkeypress="e_numero()" runat="server" cssclass="clsInputEnable"
														maxlength="15" Width="104px"></asp:textbox>&nbsp;
													<DIV style="WIDTH: 264px; DISPLAY: inline; HEIGHT: 14px; COLOR: red" ms_positioning="FlowLayout">El 
														número celular del vendedor debe ser Claro
													</DIV>
												</td>
											</TR>
											<TR id="trDistribuidor">
												<TD style="WIDTH: 131px; HEIGHT: 22px" id="tdDistribuidor" class="Arial10B" noWrap>Nombre 
													PDV
												</TD>
												<TD style="WIDTH: 2px; HEIGHT: 22px" class="Arial10B" noWrap>:&nbsp;</TD>
												<TD style="WIDTH: 305px; HEIGHT: 22px" class="Arial10B">
													<div style="TEXT-ALIGN: left; WIDTH: 58.14%; FLOAT: left; HEIGHT: 14px"><asp:label id="lblDistribuidor" runat="server" cssclass="clsInputEnable"></asp:label></div>
													<div style="TEXT-ALIGN: center; WIDTH: 41.73%; FLOAT: left; HEIGHT: 20px"><input style="WIDTH: 30px; HEIGHT: 20px; CURSOR: hand" id="btnBuscarPDV" class="Boton"
															onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="javascript:BuscarPDV();" value="..." type="button" name="btnBuscarPDV">
													</div>
												</TD>
												<TD style="WIDTH: 62px; HEIGHT: 22px" class="Arial10B">Tipo PDV
												</TD>
												<TD style="WIDTH: 1px; HEIGHT: 22px" class="Arial10B">:&nbsp;</TD>
												<TD style="WIDTH: 586px; HEIGHT: 22px" class="Arial10B"><asp:label id="lblTipoPdv" runat="server" cssclass="clsInputEnable" Width="81px"></asp:label>&nbsp;&nbsp;&nbsp;
													<asp:label id="lblProvExter" runat="server" cssclass="clsInputEnable" Width="72px">Prov.Externo</asp:label>&nbsp;<asp:textbox style="Z-INDEX: 0" id="txtProv_Exte" runat="server" cssclass="clsInputEnable" Width="80px"
														ReadOnly="True" ForeColor="Navy" Font-Bold="True" BorderStyle="None"></asp:textbox></TD>
												<td style="HEIGHT: 22px" class="Arial10B"></td>
								</td>
							<TR id="trVerificacionReniec">
								<TD style="WIDTH: 131px; HEIGHT: 15px" id="tdVerificacionReniec" class="Arial10B" noWrap>Verificación 
									RENIEC</TD>
								<TD style="WIDTH: 2px; HEIGHT: 15px" class="Arial10B" noWrap>:</TD>
								<TD style="WIDTH: 391px; HEIGHT: 15px" class="Arial10B" colSpan="6" noWrap><asp:checkbox id="chbVerificacionReniec" runat="server" Enabled="false"></asp:checkbox></TD>
							</TR>
							<TR style="DISPLAY: none" id="trMotivo">
								<TD style="WIDTH: 131px; HEIGHT: 52px" id="tdMotivo" class="Arial10B" noWrap>Motivo</TD>
								<TD style="WIDTH: 2px; HEIGHT: 52px" class="Arial10B" noWrap>:&nbsp;</TD>
								<TD style="WIDTH: 391px; HEIGHT: 52px" class="Arial10B" colSpan="6" noWrap><asp:textbox id="txtMotivo" onkeypress="e_mayuscula()" runat="server" cssclass="inputTextArea"
										Height="50px" Width="300px" TextMode="MultiLine" MaxLength="500"></asp:textbox></TD>
							</TR>
							<TR height="25">
								<TD style="WIDTH: 1079px" colSpan="6" align="center"><INPUT style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand" id="btnAceptar" class="Boton" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='Boton';" onclick="Aceptar()" value="Aceptar" type="button" name="btnAceptar">&nbsp;
									<INPUT style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand" id="btnCancelar" class="Boton"
										onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										onclick="Cancelar()" value="Cancelar" type="button" name="btnCancelar">
								</TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr id="trCargaMasiva">
					<td>
						<table>
							<tr>
								<td class="header" style="WIDTH: 1079px" colSpan="6" height="25">Carga Masiva</td>
							</tr>
							<tr>
								<td><INPUT class="boton" id="FileToUpload" style="WIDTH: 250px; HEIGHT: 19px" type="file" size="62"
										name="FileToUpload" runat="server" title="Examinar">
									<asp:button id="btnCargar" runat="server" Width="100" Text="Cargar" CssClass="Boton"></asp:button></td>
							</tr>
							<tr>
								<td>
									<div>
										<span class="Arial10B">Archivos Registrados Correctamente : </span>
										<asp:label id="lblRegistrados" runat="server"></asp:label>
									</div>
									<div>
										<span class="Arial10B">Archivos No Registrados Correctamente : </span>
										<asp:label id="lblNoRegistrados" runat="server"></asp:label>
									</div>
									<div>
										<span class="Arial10B" id="noCargados" style="DISPLAY: block">Lista de DNI que no 
											cargaron :</span>
										<asp:textbox id="txtListaNoCargaron" style="TEXT-TRANSFORM: uppercase" runat="server" Width="15%"
											CssClass="inputTextArea" Rows="15" TextMode="MultiLine"></asp:textbox>
									</div>
									<div>
										<span class="Arial10B" id="enBlackList" style="DISPLAY: block">Lista de DNI en 
											BlackList :</span>
										<asp:textbox id="txtListaBlack" style="TEXT-TRANSFORM: uppercase" runat="server" Width="15%"
											CssClass="inputTextArea" Rows="15" TextMode="MultiLine"></asp:textbox>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE> <INPUT id="hidLimpiarMasi" type="hidden" name="hidLimpiarMasi" runat="server">
			<INPUT id="hidMensaje" type="hidden" name="hidMensaje" runat="server"> <INPUT id="hidProceso" type="hidden" name="hidProceso" runat="server">
			<INPUT id="hidMostrar" type="hidden" name="hidMostrar" runat="server"> <INPUT id="hidCantidadUsuario" type="hidden" name="hidCantidadUsuario" runat="server">
			<INPUT id="hidMsg" type="hidden" name="hidMsg" runat="server"> <INPUT id="hidListaTipoUsuario" type="hidden" name="hidListaTipoUsuario" runat="server">
			<INPUT id="hidFlagVendedor" type="hidden" name="hidFlagVendedor" runat="server">
			<INPUT id="hidFlagTipoUsuario" type="hidden" name="hidFlagTipoUsuario" runat="server">
			<INPUT id="hidUsuario" type="hidden" name="hidUsuario" runat="server"> <INPUT id="hidCodVendedor" type="hidden" name="hidCodVendedor" runat="server">
			<INPUT id="hidOficinaId" type="hidden" name="hidOficinaId" runat="server"> <INPUT id="hidNuevoUsuario" type="hidden" name="hidNuevoUsuario" runat="server">
			<INPUT id="hidTipo" type="hidden" name="hidTipo" runat="server"> <INPUT id="hidDistribuidorId" type="hidden" name="hidDistribuidorId" runat="server">
			<INPUT id="hidPuntoVentaId" type="hidden" name="hidPuntoVentaId" runat="server">
			<INPUT id="hidTipoDocumentoId" type="hidden" name="hidTipoDocumentoId" runat="server">
			<INPUT id="hidEstadoId" type="hidden" name="hidEstadoId" runat="server"> <INPUT id="hidPerfiles" type="hidden" name="hidPerfiles" runat="server">
			<INPUT id="hidVerRen" type="hidden" name="hidVerRen" runat="server"> <INPUT id="hidCountEstados" type="hidden" name="hidCountEstados" runat="server">
			<INPUT id="hidMostrarUsuarioBD" type="hidden" name="hidMostrarUsuarioBD" runat="server">
			<INPUT id="hidVendedorIdBD" type="hidden" name="hidVendedorIdBD" runat="server">
			<INPUT id="hidDniBD" type="hidden" name="hidDniBD" runat="server"> <INPUT id="hidNombreBD" type="hidden" name="hidNombreBD" runat="server">
			<INPUT id="hidDireccionBD" type="hidden" name="hidDireccionBD" runat="server"> <INPUT id="hidFechaNacimientoBD" type="hidden" name="hidFechaNacimientoBD" runat="server">
			<!-- JAZ --><INPUT id="cu" size="1" type="hidden" name="cu" runat="server"> <INPUT id="hidPuntoVenta" size="1" type="hidden" name="hidPuntoVenta" runat="server">
			<INPUT id="hidTipoDocumento" size="1" type="hidden" name="hidTipoDocumento" runat="server">
			<INPUT id="hidNumeroCelularBD" type="hidden" name="hidNumeroCelularBD" runat="server">
			<INPUT id="hdCodPDV" type="hidden" name="hdCodPDV" runat="server"> <INPUT id="hdDesPDV" type="hidden" name="hdDesPDV" runat="server">
			<INPUT id="hdPExt" type="hidden" name="hdPExt" runat="server">
		</form>
	</body>
</HTML>
