<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_casos_especiales2.aspx.vb" Inherits="sisact_mant_casos_especiales2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>.::Mantenimiento de Casos Especiales::.</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta charset="utf-8" http-equiv="Content-Type" content="text/html">
		<style type="text/css">.textgrilla { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #e06704; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A:hover { FONT-SIZE: 12px; COLOR: #e06704; TEXT-DECORATION: none }
	A:active { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:visited { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:link { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
		</style>
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../librerias/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" src="ConsumerValidacion.js"></script>
		<script language="javascript" src="../../script/CasosEspeciales.js"></script>
		<script language="javascript" type="text/javascript">

			function f_Mensaje(Mensaje)
			{
				alert(Mensaje);
				return false;
			}

			//Generales
			function f_mostrarPestaña(ind){
				//debugger;
				document.getElementById("trCampanias").style.display='none';
				document.getElementById("trPDV").style.display='none';
				document.getElementById("trPlanes").style.display='none';
				document.getElementById("trTopeConsumo").style.display='none';
				document.getElementById("trRestricciones").style.display='none';
				document.getElementById("hidIndice").value=ind;
				//document.getElementById("lblMensaje").innerHTML = "";

				if(ind == 1) //Campanias
				{
					document.getElementById("trCampanias").style.display='block';
					document.getElementById("tdCampanias").style.backgroundColor = "#325493";
					document.getElementById("tdPDV").style.backgroundColor = "#f59130";
					document.getElementById("tdPDV").style.color="ffffff";
					document.getElementById("tdPlanes").style.backgroundColor = "#f59130";
					document.getElementById("tdPlanes").style.color="ffffff";
					document.getElementById("tdTopeConsumo").style.backgroundColor = "#f59130";
					document.getElementById("tdTopeConsumo").style.color="ffffff";
					document.getElementById("tdRestricciones").style.backgroundColor = "#f59130";
					document.getElementById("tdRestricciones").style.color="ffffff";
				}
				else if(ind == 2) //Puntos de Venta
				{
					document.getElementById("trPDV").style.display='block';
					document.getElementById("tdCampanias").style.backgroundColor = "#f59130";
					document.getElementById("tdCampanias").style.color="#ffffff";
					document.getElementById("tdPDV").style.backgroundColor = "#325493";
					document.getElementById("tdPDV").style.color="ffffff";
					document.getElementById("tdPlanes").style.backgroundColor = "#f59130";
					document.getElementById("tdPlanes").style.color="ffffff";
					document.getElementById("tdTopeConsumo").style.backgroundColor = "#f59130";
					document.getElementById("tdTopeConsumo").style.color="ffffff";
					document.getElementById("tdRestricciones").style.backgroundColor = "#f59130";
					document.getElementById("tdRestricciones").style.color="ffffff";
				}
				else if(ind == 3) //Planes
				{
					document.getElementById("trPlanes").style.display='block';
					document.getElementById("tdCampanias").style.backgroundColor = "#f59130";
					document.getElementById("tdCampanias").style.color="#ffffff";
					document.getElementById("tdPDV").style.backgroundColor = "#f59130";
					document.getElementById("tdPDV").style.color="ffffff";
					document.getElementById("tdPlanes").style.backgroundColor = "#325493";
					document.getElementById("tdPlanes").style.color="ffffff";
					document.getElementById("tdTopeConsumo").style.backgroundColor = "#f59130";
					document.getElementById("tdTopeConsumo").style.color="ffffff";
					document.getElementById("tdRestricciones").style.backgroundColor = "#f59130";
					document.getElementById("tdRestricciones").style.color="ffffff";
				}
				else if(ind == 4) //Tope de Consumo
				{
					document.getElementById("trTopeConsumo").style.display='block';
					document.getElementById("tdCampanias").style.backgroundColor = "#f59130";
					document.getElementById("tdCampanias").style.color="#ffffff";
					document.getElementById("tdPDV").style.backgroundColor = "#f59130";
					document.getElementById("tdPDV").style.color="ffffff";
					document.getElementById("tdPlanes").style.backgroundColor = "#f59130";
					document.getElementById("tdPlanes").style.color="ffffff";
					document.getElementById("tdTopeConsumo").style.backgroundColor = "#325493";
					document.getElementById("tdTopeConsumo").style.color="ffffff";
					document.getElementById("tdRestricciones").style.backgroundColor = "#f59130";
					document.getElementById("tdRestricciones").style.color="ffffff";
				}
				else if(ind == 5) //Restricciones
				{
					document.getElementById("trRestricciones").style.display='block';
					document.getElementById("tdCampanias").style.backgroundColor = "#f59130";
					document.getElementById("tdCampanias").style.color="#ffffff";
					document.getElementById("tdPDV").style.backgroundColor = "#f59130";
					document.getElementById("tdPDV").style.color="ffffff";
					document.getElementById("tdPlanes").style.backgroundColor = "#f59130";
					document.getElementById("tdPlanes").style.color="ffffff";
					document.getElementById("tdTopeConsumo").style.backgroundColor = "#f59130";
					document.getElementById("tdTopeConsumo").style.color="ffffff";
					document.getElementById("tdRestricciones").style.backgroundColor = "#325493";
					document.getElementById("tdRestricciones").style.color="ffffff";
				}
				return false;
			}

			function f_MostrarTab(valor)
			{
				if (valor == 'BUSQUEDA')
				{
					document.getElementById('hidCondicionPdv').value = 'BUSQUEDA'; 
					setVisible('trBUSQUEDA', true);	
					setVisible('trMANTENIMIENTO', false);
					document.getElementById('btnListado').className='boton_activo';
					document.getElementById('btnAgregar').className='boton_inactivo';
				}
				if (valor == 'MANTENIMIENTO')
				{
					document.getElementById('hidCondicionPdv').value = 'MANTENIMIENTO'; 
					setVisible('trBUSQUEDA', false);	
					setVisible('trMANTENIMIENTO', true);	
					document.getElementById('btnListado').className='boton_inactivo';
					document.getElementById('btnAgregar').className='boton_activo';
					f_mostrarPestaña(1);
				}
				return false;
			}

			function chkEditar_Click(chk,txt)
			{
				var obj_chk = document.getElementById(chk);
				var obj_txt = document.getElementById(txt);
			
				if(obj_chk.checked)
				{
					obj_txt.readOnly = false;
					obj_txt.focus();
				}
				else
				{
					obj_txt.readOnly = true;
					obj_txt.value = ""
				}
			}

			//Utiles
			function formatDecimal2(obj) { 
				var num = obj.value; 
				if(num=="") return;
				num = num.toString().replace(/\$|\,/g,''); 
				if(isNaN(num)) num = "0"; 
				sign = (num == (num = Math.abs(num))); 
				num = Math.floor(num*100+0.50000000001); 
				cents = num%100; 
				num = Math.floor(num/100).toString(); 
			 
				if (cents<0) cents=cents*-1; 
				if(cents<10) cents = "0" + cents; 
			 
				for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++) 
				{
					num = num.substring(0,num.length-(4*i+3))+','+ num.substring(num.length-(4*i+3)); 
				}
			 
				obj.value = (((sign)?'':'-') + num + '.' + cents); 
			}

			function f_OnFocus(obj)
			{
				obj.style.background= "#e3efff";
			}

			function f_OnBlur(obj)
			{
				obj.style.background= "#ffffff";
			}
			
			function validaCaracteres() 
			{
				var CaracteresPermitidos = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789_-() ";
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++)
				{
					if (key == valid.substring(i,i+1))
						ok = "yes";
				}
				if (ok == "no")
					window.event.keyCode=0;

				if ((key > 0x60) && (key < 0x7B))
					window.event.keyCode = key-0x20;
			}
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{
						document.getElementById('<%=btnBuscar.ClientId%>').click;
						event.keyCode = 0;
					}
				}
			}
			
			function f_EventoSoloNumerosEnteros()
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
			
			function f_EventoNumerosDecimales()
			{
				var CaracteresPermitidos = '0123456789.';
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

			function fgetLeftPosition(w) {
				var leftPosition=(screen.width)?(screen.width-w)/2:100; 
				return leftPosition;
			}
			
			function fgetTopPosition(h) {
				var topPosition=(screen.height)?(screen.height-h)/2:100; 
				return topPosition;
			}

			//Acciones

			function f_Listado()
			{
				var accion = document.getElementById('hidCondicionPdv').value;
				if (accion == 'MANTENIMIENTO')
				{
					if(confirm('¿Está Seguro de Continuar?')) 
					{
						document.getElementById('hidCondicionPdv').value = 'LISTADO'; 
						document.getElementById("<%=btnListadoServer.ClientID%>").click();
					}
				}
				else
				{
						document.getElementById('hidCondicionPdv').value = 'LISTADO'; 
						document.getElementById("<%=btnListadoServer.ClientID%>").click();
				}
				return false;				

			}

			function f_Agregar()
			{
				document.getElementById('hidCondicionPdv').value = 'AGREGAR'; 
				document.getElementById("<%=btnAgregarServer.ClientID%>").click(); 
				f_mostrarPestaña(1);
				return false;
			}
			
			function f_Modificar(Codigo)
			{
				document.getElementById('hidCondicionPdv').value = 'MODIFICAR'; 
				setValue('hidCodigo',Codigo);
				document.getElementById('txtCodigoEsp').value = Codigo;
				f_MostrarTab('MANTENIMIENTO');
				document.getElementById("<%=btnEditarServer.ClientID%>").click(); 
				return false;
			}
			
			function f_Eliminar(Codigo, IdEstado) { 
			    if(IdEstado == 'I')
			    {
			    	return false; 
			    }
			    else
			    {
					if(confirm('¿Está Seguro de Desactivar este Registro?')) 
					{
						document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
						document.getElementById('hidCondicionPdv').value = 'ELIMINAR'; 
						document.getElementById("<%=btnEliminarServer.ClientID%>").click(); 
					}
				}
				return false; 
			}
			
			function f_EliminarCampania(Codigo) { 
				if(confirm('¿Está Seguro de Eliminar este Registro(Campaña) del Detalle?')) 
				{ 
					document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
					document.getElementById('hidCondicionPdv').value = 'ELIMINARCAMPANIA'; 
					document.getElementById("<%=btnEliminarCampaniaServer.ClientID%>").click(); 
				} 
				return false; 
			}
		
			function f_EliminarPDV(Codigo) { 
				if(confirm('¿Está Seguro de Eliminar este Registro(Pdv) del Detalle?')) 
				{ 
					document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
					document.getElementById('hidCondicionPdv').value = 'ELIMINARPDV'; 
					document.getElementById("<%=btnEliminarPdvServer.ClientID%>").click(); 
				} 
				return false; 
			}
			
			function f_EliminarPlan(Codigo) { 
				if(confirm('¿Está Seguro de Eliminar este Registro(Plan) del Detalle?')) 
				{ 
					document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
					document.getElementById('hidCondicionPdv').value = 'ELIMINARPLAN'; 
					document.getElementById("<%=btnEliminarPlanServer.ClientID%>").click(); 
				} 
				return false; 
			}
			
			function f_EliminarRestriccion(Codigo) { 
				if(confirm('¿Está Seguro de Eliminar este Registro(Restriccion) del Detalle?')) 
				{ 
					document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
					document.getElementById('hidCondicionPdv').value = 'ELIMINARRESTRICCION'; 
					document.getElementById("<%=btnEliminarRestriccionServer.ClientID%>").click(); 
				} 
				return false; 
			}
			
			function f_EliminarTopeConsumo(Codigo) { 
				if(confirm('¿Está Seguro de Eliminar este Registro(TopeConsumo) del Detalle?')) 
				{ 
					document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
					document.getElementById('hidCondicionPdv').value = 'ELIMINARTOPECONSUMO'; 
					document.getElementById("<%=btnEliminarTopeConsumoServer.ClientID%>").click(); 
				} 
				return false; 
			}
			
			function f_EliminarCuota(Codigo) { 
				if(confirm('¿Esta Seguro de Eliminar este Registro(Cuota) del Detalle?')) 
				{ 
					document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
					document.getElementById('hidCondicionPdv').value = 'ELIMINARCUOTA'; 
					document.getElementById("<%=btnEliminarCuotaServer.ClientID%>").click(); 
				} 
				return false; 
			}
			
			function f_EliminarTodosCampania() { 
				var tabla = document.getElementById('dgCampanias');
				var rows = tabla.getElementsByTagName('tr');
				if (rows.length == 2)
					return false;
				else
				{
					if(confirm('¿Está Seguro de Eliminar todos los Registros(Campaña) del Detalle?')) 
					{ 
						document.getElementById('hidCondicionPdv').value = 'ELIMINARTODOSCAMPANIA'; 
						document.getElementById("<%=btnEliminarTodosCampaniaServer.ClientID%>").click(); 
					} 
					return false; 
				}
			}
			
			function f_EliminarTodosPDV() { 
				var tabla = document.getElementById('dgPDV');
				var rows = tabla.getElementsByTagName('tr');
				if (rows.length == 2)
					return false;
				else
				{
					if(confirm('¿Esta Seguro de Eliminar todos los Registros(PDV) del Detalle?')) 
					{ 
						document.getElementById('hidCondicionPdv').value = 'ELIMINARTODOSPDV'; 
						document.getElementById("<%=btnEliminarTodosPdvServer.ClientID%>").click(); 
					} 
					return false; 
				}
			}
			
			function f_EliminarTodosPlan() { 
				var tabla = document.getElementById('dgPlanes');
				var rows = tabla.getElementsByTagName('tr');
				if (rows.length == 2) //grilla vacía
					return false;
				else
				{
					if(confirm('¿Esta Seguro de Eliminar todos los Registros(Plan) del Detalle?')) 
					{ 
						document.getElementById('hidCondicionPdv').value = 'ELIMINARTODOSPLAN'; 
						document.getElementById("<%=btnEliminarTodosPlanServer.ClientID%>").click(); 
					} 
					return false;
				}
			}
			
			function f_EliminarTodosRestriccion() { 
				var tabla = document.getElementById('dgRestricciones');
				var rows = tabla.getElementsByTagName('tr');
				if (rows.length == 2)
					return false;
				else
				{
					if(confirm('¿Esta Seguro de Eliminar todos los Registros(Restriccion) del Detalle?')) 
					{ 
						document.getElementById('hidCondicionPdv').value = 'ELIMINARTODOSRESTRICCION'; 
						document.getElementById("<%=btnEliminarTodosRestriccionServer.ClientID%>").click(); 
					} 
					return false; 
				}
			}
			
			function f_EliminarTodosTopeConsumo() { 
				var tabla = document.getElementById('dgTopeConsumo');
				var rows = tabla.getElementsByTagName('tr');
				if (rows.length == 2)
					return false;
				else
				{
					if(confirm('¿Esta Seguro de Eliminar todos los Registros(TopeConsumo) del Detalle?')) 
					{ 
						document.getElementById('hidCondicionPdv').value = 'ELIMINARTODOSTOPECONSUMO'; 
						document.getElementById("<%=btnEliminarTodosTopeConsumoServer.ClientID%>").click(); 
					} 
					return false; 
				}
			}
			
			function f_EliminarTodosCuotas() { 
				var tabla = document.getElementById('dgCuotas');
				var rows = tabla.getElementsByTagName('tr');
				if (rows.length == 2)
					return false;
				else
				{
					if(confirm('¿Esta Seguro de Eliminar todos los Registros(Cuotas) del Detalle?')) 
					{ 
						document.getElementById('hidCondicionPdv').value = 'ELIMINARTODOSCUOTAS'; 
						document.getElementById("<%=btnEliminarTodosCuotasServer.ClientID%>").click(); 
					} 
					return false; 
				}
			}

			//Modales
			function cargarPopUpCampanias()
			{
					window.open("sisact_pop_cargarCampanias.aspx",null,"width=550px,height=350px,top=150px,left=400px,resizable=no,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no, status=yes");
					return false;	
			}

			function refrescarCampanias()
			{
				document.getElementById("hidCondicionPdv").value="CAMPANIAS";
				frmPrincipal.submit();
			}

			function cargarPopUpPdv()
			{
				window.open("sisact_pop_cargarPdv2.aspx",null,"width=800,height=540,top=70px,left=300px");
				return false;	
			}
		
			function refrescarPdv() 
			{ 
				document.getElementById('hidCondicionPdv').value='MANTENIMIENTO'; 
				frmPrincipal.submit(); 
			}

			function cargarPopUpPlanes()
			{
				if (document.getElementById("ddlOferta").value == '--Seleccione--')
				{
					alert('Seleccione la Oferta');
					document.getElementById("ddlOferta").focus();
					return false;	
				}
				else
				{
					window.open("sisact_pop_cargarPlanes.aspx",null,"width=550px,height=350px,top=150px,left=400px,resizable=no,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no, status=yes");
					return false;		
				}
			}
			
			function editarPopUpPlanes(Codigo)
			{
				if (document.getElementById("ddlOferta").value == '--Seleccione--')
				{
					alert('Seleccione la Oferta');
					document.getElementById("ddlOferta").focus();
					return false;	
				}
				else
				{
					window.open("sisact_pop_cargarPlanes.aspx?Codigo=" + Codigo,null,"width=550px,height=350px,top=150px,left=400px,resizable=no,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no, status=yes");
					return false;		
				}
			}

			function refrescarPlanes()
			{
				document.getElementById("hidCondicionPdv").value="PLANES";
				frmPrincipal.submit();
			}

			function cargarPopUpRestricciones()
			{
				if (document.getElementById("ddlOferta").value == '--Seleccione--')
				{
					alert('Seleccione la Oferta');
					document.getElementById("ddlOferta").focus();
					return false;	
				}
				else
				{
					var tabla = document.getElementById('dgPlanes');
					var rows = tabla.getElementsByTagName('tr');
					if (rows.length == 2)
					{
						alert('Agregue Registros al Detalle de PLANES de la Página Principal');
						f_mostrarPestaña(3);
						return false;	
					}
					else
					{
						window.open("sisact_pop_cargarRestricciones.aspx",null,"width=550px,height=350px,top=150px,left=400px,resizable=no,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no, status=yes");
						return false;					
					}
				}
			}
			
			function editarPopUpRestricciones(Codigo)
			{
				if (document.getElementById("ddlOferta").value == '--Seleccione--')
				{
					alert('Seleccione la Oferta');
					document.getElementById("ddlOferta").focus();
					return false;	
				}
				else
				{
					window.open("sisact_pop_cargarRestricciones.aspx?Codigo=" + Codigo,null,"width=550px,height=350px,top=150px,left=400px,resizable=no,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no, status=yes");
					return false;		
				}
			}

			function refrescarRestricciones()
			{
				document.getElementById("hidCondicionPdv").value="RESTRICCIONES";
				frmPrincipal.submit();
			}

			function cargarPopUpTopeConsumo()
			{
				if (document.getElementById("ddlOferta").value == '--Seleccione--')
				{
					alert('Seleccione la Oferta');
					document.getElementById("ddlOferta").focus();
					return false;	
				}
				else
				{
					var tabla = document.getElementById('dgPlanes');
					var rows = tabla.getElementsByTagName('tr');
					if (rows.length == 2)
					{
						alert('Agregue Registros al Detalle de PLANES de la Página Principal');
						f_mostrarPestaña(3);
						return false;	
					}
					else
					{
						window.open("sisact_pop_cargarTopeConsumo.aspx",null,"width=550px,height=350px,top=150px,left=400px,resizable=no,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no, status=yes");
						return false;					
					}
				}
			}

			function f_Grabar()
			{
				if(confirm('¿Esta Seguro de Grabar los Cambios?')) 
				{ 
					f_Operacion();
					document.getElementById("<%=btnGrabarServer.ClientID%>").click(); 
				} 
				return false; 
			}
			
			function f_Operacion()
			{
				/*document.getElementById("trPestanas").style.visibility='hidden';
				document.getElementById("trCampanias").style.display='none';
				document.getElementById("trPDV").style.display='none';
				document.getElementById("trPlanes").style.display='none';
				document.getElementById("trTopeConsumo").style.display='none';
				document.getElementById("trRestricciones").style.display='none';
				document.getElementById("trCuotas").style.display='none';
				document.getElementById("lblMensaje").innerHTML = "Por Favor Espere, En estos momentos la Información se esta Procesando...";*/
				document.getElementById("<%=btnAgregarCuota.ClientID%>").disabled = true;
				document.getElementById("<%=btnListado.ClientID%>").disabled = true;
				document.getElementById("<%=btnAgregar.ClientID%>").disabled = true;
				document.getElementById("<%=btnGrabar.ClientID%>").disabled = true;
				document.getElementById("<%=btnCancelar.ClientID%>").disabled = true;
				document.getElementById("<%=ddlOferta.ClientID%>").disabled = true;
				return false; 
			}
			
			function f_Resultado()
			{
				/*f_MostrarTab('MANTENIMIENTO');
				document.getElementById("trPestanas").style.visibility='visible';
				f_mostrarPestaña(1);
				document.getElementById("trCuotas").style.display='block';
				document.getElementById("lblMensaje").innerHTML = "";*/
				document.getElementById("<%=btnAgregarCuota.ClientID%>").disabled = false;
				document.getElementById("<%=btnListado.ClientID%>").disabled = false;
				document.getElementById("<%=btnAgregar.ClientID%>").disabled = false;
				document.getElementById("<%=btnGrabar.ClientID%>").disabled = false;
				document.getElementById("<%=btnCancelar.ClientID%>").disabled = false;
				document.getElementById("<%=ddlOferta.ClientID%>").disabled = false;
				return false; 
			}
		
		</script>
	</HEAD>
	<body style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; MARGIN: 0px; PADDING-TOP: 5px">
		<form id="frmPrincipal" method="post" runat="server">
			<table style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
				borderColor="#95b7f3" cellSpacing="1" cellPadding="1" width="900" align="center">
				<TBODY>
					<tr height="20">
						<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">Casos Especiales
						</td>
					</tr>
					<!--Tabla Botonera-->
					<!-- Fin de Botonera -->
					<!--Tabla Busqueda-->
					<TR>
					<TR>
						<TD style="PADDING-BOTTOM: 5px; PADDING-TOP: 5px" align="center"><asp:button id="btnListado" runat="server" Text="Listado" width="120px" ForeColor="White" Font-Bold="True"
								Font-Size="7pt" Font-Names="Verdana" BorderStyle="Double" CssClass="boton_activo"></asp:button>&nbsp;
							<asp:button id="btnAgregar" runat="server" Text="Agregar" width="120px" ForeColor="White" Font-Bold="True"
								Font-Size="7pt" Font-Names="Verdana" BorderStyle="Double" CssClass="boton_inactivo"></asp:button></TD>
					</TR>
					<tr id="trBUSQUEDA">
						<td style="PADDING-BOTTOM: 5px" align="center">
							<table id="tblBusqueda" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
								cellSpacing="1" cellPadding="1" width="850">
								<tr height="20">
									<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center" colSpan="2">Búsqueda
									</td>
								</tr>
								<tr align="center">
									<td class="Arial11BV" align="right" width="180">Caso Especial</td>
									<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px" align="left">
										<!--Opciones de Busqueda--><asp:dropdownlist id="ddlBusqueda" CssClass="clsSelectEnable" Runat="server" Width="100px" AutoPostBack="True"></asp:dropdownlist>
										<!--Caja de Texto Busqueda--><asp:textbox onkeypress="validaCaracteres();" id="txtBusDescripcion" onkeydown="f_ValidarEnter();"
											runat="server" CssClass="clsInputEnable" Width="200px" autocomplete="off" MaxLength="40"></asp:textbox>
										<!--onpaste="return false;"-->
										<!-- Boton Buscar --><asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
											Text="Buscar" CssClass="Boton" Runat="server" Width="90" Height="19"></asp:button>
										<!-- Boton Limpiar --><asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
											Text="Limpiar" CssClass="Boton" Runat="server" Width="90" Height="19"></asp:button></td>
								</tr>
								<tr align="center">
									<td class="Arial11BV" align="right" width="180">Estado</td>
									<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px" align="left"><asp:dropdownlist id="ddlEstadoConsulta" CssClass="clsSelectEnable" Runat="server" Width="100px" AutoPostBack="True"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td align="center" colSpan="2">
										<table cellSpacing="0" cellPadding="0">
											<tr align="center">
												<td style="PADDING-BOTTOM: 5px" align="center"><asp:datagrid id="dgrGrillaDetalle" runat="server" DataKeyField="CODIGO" autogeneratecolumns="False"
														AllowPaging="True" CellPadding="1" CellSpacing="1" BorderColor="#95B7F3" alternatingitemstyle backcolor="#DDDEE2" AllowSorting="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="30px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton id="btnEditar" runat="server" ImageUrl="../../images/btn_edit.jpg" CommandName="Edit"
																		ToolTip="Editar"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="CODIGO" HeaderText="Cód.">
																<HeaderStyle Width="10px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CASOESPECIAL" HeaderText="Caso Especial">
																<HeaderStyle Width="300px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="OFERTA" HeaderText="Oferta">
																<HeaderStyle Width="80px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DOCUMENTOS" HeaderText="Documentos">
																<HeaderStyle Width="100px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO" HeaderText="Estado">
																<HeaderStyle Width="70px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="C.Max.Planes" HeaderText="C.Max.Planes">
																<HeaderStyle Width="90px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="C.Max.P.Voz" HeaderText="C.Max.P.Voz">
																<HeaderStyle Width="100px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="C.Max.P.Datos" HeaderText="C.Max.P.Datos">
																<HeaderStyle Width="100px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="WhiteList"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="WhiteList">
																<HeaderStyle Width="80px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox ID="CheckWhiteList" Runat="Server" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem,"WhiteList")%>'>
																	</asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="30px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton id="btnEliminar" runat="server" ImageUrl="../../images/ico_Eliminar.gif" CommandName="Delete"
																		ToolTip="Desactivar"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle Font-Size="11px" CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
											<tr>
												<td align="left"><asp:button id="btnExportarCSV" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
														Text="Exportar CSV" CssClass="Boton" Runat="server" Width="90" Height="19"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<!-- Fin de Busqueda -->
					<!--Tabla MANTENIMIENTO-->
					<tr id="trMANTENIMIENTO">
						<td style="PADDING-BOTTOM: 5px" align="center">
							<table id="tblEdicion" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
								cellSpacing="1" cellPadding="1" width="750" border="0">
								<TBODY>
									<tr height="20">
										<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">Mantenimiento
										</td>
									</tr>
									<tr>
										<td style="PADDING-TOP: 5px" align="center">
											<table class="Arial11BV" cellSpacing="1" cellPadding="1" width="700">
												<TBODY>
													<tr>
														<td align="right" width="250">Código :</td>
														<td width="120"><asp:textbox id="txtCodigoEsp" runat="server" width="50px" CssClass="clsInputEnable" MaxLength="10"
																Enabled="False" ReadOnly="True"></asp:textbox></td>
														<td align="right" width="80">Estado :</td>
														<td align="left" width="120"><asp:dropdownlist id="ddlEstado" style="CURSOR: pointer" runat="server" CssClass="clsSelectEnable"
																Width="80px"></asp:dropdownlist></td>
														<td width="90" colSpan="3"><asp:checkbox id="chkWhiteList" runat="server" Text="WhiteList" width="15px"></asp:checkbox></td>
													</tr>
													<tr>
														<td align="right" width="250">Caso Especial :
														</td>
														<td style="HEIGHT: 19px" width="370" colSpan="4"><asp:textbox onkeypress="validaCaracteres();" onpaste="return false;" id="txtCasoDescripcion"
																onblur="f_OnBlur(this);" onfocus="f_OnFocus(this);" runat="server" CssClass="clsInputEnable" Width="450px" autocomplete="off" MaxLength="50"></asp:textbox></td>
													</tr>
													<tr>
														<td align="right" width="250">Documento :
														</td>
														<td colSpan="4"><asp:checkboxlist id="chkListaDocumento" runat="server" CssClass="Arial11BV" Width="100%" RepeatDirection="Horizontal"
																BorderWidth="1"></asp:checkboxlist></td>
													</tr>
													<tr>
														<td align="right" width="250">Cant. Máx. de Planes por Caso Especial :</td>
														<td style="WIDTH: 114px" width="114"><asp:textbox onkeypress="f_EventoSoloNumerosEnteros();" onpaste="return false;" id="txtCantMaximaporCasoEspecial"
																onblur="f_OnBlur(this);" style="TEXT-ALIGN: right" onfocus="f_OnFocus(this);" runat="server" CssClass="clsInputEnable" Width="40px"
																MaxLength="3"></asp:textbox></td>
														<td align="right" width="220" colSpan="2">Cant. Máx. de Planes Voz :
														</td>
														<td width="90" colSpan="3"><asp:textbox onkeypress="f_EventoSoloNumerosEnteros();" onpaste="return false;" id="txtCantMaximaPlanesVoz"
																onblur="f_OnBlur(this);" style="TEXT-ALIGN: right" onfocus="f_OnFocus(this);" runat="server" CssClass="clsInputEnable"
																Width="40px" autocomplete="off" MaxLength="3"></asp:textbox></td>
													</tr>
													<tr>
														<td align="right" width="250">Oferta :</td>
														<td width="120"><asp:dropdownlist id="ddlOferta" CssClass="Arial11BV" Runat="Server" Width="110px" AutoPostBack="True"></asp:dropdownlist></td>
														<td align="right" width="220" colSpan="2">Cant. Máx. de Planes Datos :
														</td>
														<td width="90" colSpan="3"><asp:textbox onkeypress="f_EventoSoloNumerosEnteros();" onpaste="return false;" id="txtCantMaximaPlanesDatos"
																onblur="f_OnBlur(this);" style="TEXT-ALIGN: right" onfocus="f_OnFocus(this);" runat="server" CssClass="clsInputEnable"
																Width="40px" autocomplete="off" MaxLength="3"></asp:textbox></td>
													</tr>
													<TR>
														<TD align="right" width="250">Plazos :</TD>
														<TD width="80" colSpan="4"><asp:dropdownlist id="ddlPlazos" style="CURSOR: pointer" runat="server" CssClass="Arial11BV" Width="260px"></asp:dropdownlist></TD>
													</TR>
													<tr>
														<td align="right" width="250">Cuotas :
														</td>
														<td width="120"><asp:dropdownlist id="ddlCuotas" style="CURSOR: pointer" runat="server" CssClass="Arial11BV" Width="110px"></asp:dropdownlist></td>
														<td align="right" width="80">Porcentaje :</td>
														<td align="center" width="120"><asp:textbox onkeypress="f_EventoNumerosDecimales();" onpaste="return false;" id="txtPorcentaje"
																onblur="f_OnBlur(this);" style="TEXT-ALIGN: right" onfocus="f_OnFocus(this);" runat="server" CssClass="clsInputEnable"
																Width="40px" autocomplete="off" MaxLength="3"></asp:textbox>&nbsp;
															<asp:button id="btnAgregarCuota" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
																Text="Agregar" CssClass="Boton" Runat="Server" Width="60px"></asp:button></td>
														<td style="WIDTH: 97px" align="left" width="95"></td>
										</td>
									</tr>
									<tr id="trCuotas">
										<td align="right" width="250">Detalle de Cuotas :
										</td>
										<td colSpan="7"><asp:datagrid id="dgCuotas" width="100%" CssClass="Arial11BV" Runat="Server" DataKeyField="IdPlazo"
												AllowPaging="True" CellPadding="1" CellSpacing="1" BorderColor="#95B7F3" PageSize="5" AutoGenerateColumns="False">
												<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
												<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn>
														<HeaderStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
														<HeaderTemplate>
															<asp:ImageButton id="btnEliminarTodosCuotas" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																ImageAlign="Middle" ToolTip="Eliminar Todos"></asp:ImageButton>
														</HeaderTemplate>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="btnEliminarCuota" runat="server" ImageUrl="../../images/ico_Eliminar.gif" ToolTip="Eliminar"></asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="IdPlazo" HeaderText="IdPlazo"></asp:BoundColumn>
													<asp:BoundColumn DataField="Plazo" HeaderText="Plazo">
														<HeaderStyle Width="230px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="IdCuota" HeaderText="IdCuota"></asp:BoundColumn>
													<asp:BoundColumn DataField="Cuota" HeaderText="Cuota">
														<HeaderStyle Width="70px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Porcentaje" HeaderText="Pct%" DataFormatString="{0:N2}">
														<HeaderStyle Width="55px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></td>
									</tr>
									<tr>
										<td align="right" colSpan="7"></td>
									</tr>
									<tr>
										<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
											align="center" colSpan="7">
											<!-- Boton Buscar --><asp:button id="btnGrabar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
												Text="Grabar" CssClass="Boton" Runat="server" Width="110px" Height="19"></asp:button>
											<!-- Boton Limpiar --><asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
												Text="Cerrar" CssClass="Boton" Runat="server" Width="110px" Height="19"></asp:button></td>
									</tr>
									<tr>
										<td align="center" colSpan="7"><asp:label id="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></td>
									</tr>
									<tr id="trPestanas">
										<td colSpan="7"><br>
											<table borderColor="#f48d29" cellSpacing="1" cellPadding="1" width="100%" align="center"
												border="1">
												<tr width="100%">
													<td class="Arial11BV" id="tdCampanias" style="CURSOR: hand; COLOR: white; BACKGROUND-COLOR: #325493; 15px: "
														onclick="f_mostrarPestaña(1);" align="center" width="5%">
														<P><FONT size="2"><STRONG>CAMPAÑAS</STRONG></FONT><FONT size="2"><STRONG></STRONG></FONT></P>
													</td>
													<td class="Arial11BV" id="tdPDV" style="CURSOR: hand" onclick="f_mostrarPestaña(2);"
														align="center" width="22%" bgColor="#f59130"><FONT color="#ffffff" size="2"><STRONG>PUNTOS 
																DE VENTA</STRONG> </FONT>
													</td>
													<td class="Arial11BV" id="tdPlanes" style="CURSOR: hand" onclick="f_mostrarPestaña(3);"
														align="center" width="10%" bgColor="#f59130"><FONT color="#ffffff" size="2"><STRONG>PLANES
															</STRONG></FONT>
													</td>
													<td class="Arial11BV" id="tdTopeConsumo" style="CURSOR: hand" onclick="f_mostrarPestaña(4);"
														align="center" width="28%" bgColor="#f59130">
														<P><FONT color="#ffffff" size="2"><STRONG>TOPES&nbsp;DE CONSUMO</STRONG></FONT><FONT color="#ffffff" size="2"><STRONG>&nbsp;POR 
																	PLAN</STRONG></FONT></P>
													</td>
													<td class="Arial11BV" id="tdRestricciones" style="CURSOR: hand" onclick="f_mostrarPestaña(5);"
														align="center" width="30%" bgColor="#f59130"><FONT color="#ffffff" size="2"><STRONG>RESTRICCIONES&nbsp;POR 
																RIESGO</STRONG></FONT></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr id="trCampanias">
										<td style="WIDTH: 100%" align="center" colSpan="7">
											<table class="Arial11BV" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
												cellSpacing="1" cellPadding="1">
												<tr height="20">
													<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">CAMPAÑAS
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
														align="right"><input class="Boton" id="btnAgregarCampania" onmouseover="this.className='BotonResaltado';"
															onclick="cargarPopUpCampanias();" onmouseout="this.className='Boton';" type="button" value="Agregar"
															name="btnAgregarCampania">
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px" align="center"><asp:datagrid id="dgCampanias" runat="server" DataKeyField="IdCampania" AllowPaging="True" CellPadding="1"
															CellSpacing="1" BorderColor="#95B7F3" PageSize="5" AutoGenerateColumns="False">
															<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
															<HeaderStyle CssClass="TablaTitulos" Height="20px" HorizontalAlign="Center"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="">
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderTemplate>
																		<asp:ImageButton id="btnEliminarTodosCampania" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar Todos"></asp:ImageButton>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<asp:ImageButton id="btnEliminarCampania" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn Datafield="IdCampania" Visible="False" HeaderText="IdCampania"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Campania" HeaderText="Campaña">
																	<HeaderStyle Width="300px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="Exclusiva"></asp:BoundColumn>
																<asp:TemplateColumn HeaderText="Exclusiva" ItemStyle-HorizontalAlign="Center">
																	<HeaderStyle Width="40px"></HeaderStyle>
																	<ItemTemplate>
																		<asp:CheckBox ID="ChkExclusiva" Runat="Server" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem,"Exclusiva")%>'>
																		</asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr id="trPDV">
										<td style="WIDTH: 100%" align="center" colSpan="7">
											<table class="Arial11BV" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
												cellSpacing="1" cellPadding="1">
												<tr height="20">
													<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">PUNTOS DE VENTA 
														AUTORIZADOS
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
														align="right"><input class="Boton" id="btnAgregarPDV" onmouseover="this.className='BotonResaltado';"
															onclick="cargarPopUpPdv();" onmouseout="this.className='Boton';" type="button" value="Agregar" name="btnAgregarPDV">
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px" align="center"><asp:datagrid id="dgPDV" runat="server" DataKeyField="IdPuntoVenta" AllowPaging="True" CellPadding="1"
															CellSpacing="1" BorderColor="#95B7F3" PageSize="5" AutoGenerateColumns="False">
															<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
															<HeaderStyle CssClass="TablaTitulos" Height="20px" HorizontalAlign="Center"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<HeaderTemplate>
																		<asp:ImageButton id="btnEliminarTodosPDV" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar Todos"></asp:ImageButton>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<asp:ImageButton id="btnEliminarPDV" runat="server" ImageUrl="../../images/ico_Eliminar.gif" ToolTip="Eliminar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="IdPuntoVenta" HeaderText="Código">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="50px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PuntoVenta" HeaderText="Descripción">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="290px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Canal" HeaderText="Canal">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="150px"></HeaderStyle>
																</asp:BoundColumn>
															</Columns>
															<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr id="trPlanes">
										<td style="WIDTH: 100%" align="center" colSpan="7">
											<table class="Arial11BV" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
												cellSpacing="1" cellPadding="1">
												<tr height="20">
													<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">PLANES
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 26px"
														align="right"><input class="Boton" id="btnAgregarPlan" onmouseover="this.className='BotonResaltado';"
															onclick="cargarPopUpPlanes();" onmouseout="this.className='Boton';" type="button" value="Agregar"
															name="btnAgregarPlan">
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px" align="center"><asp:datagrid id="dgPlanes" runat="server" DataKeyField="IdPlan" AllowPaging="True" CellPadding="1"
															CellSpacing="1" BorderColor="#95B7F3" PageSize="5" AutoGenerateColumns="False">
															<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
															<HeaderStyle CssClass="TablaTitulos" Height="20px" HorizontalAlign="Center"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<HeaderTemplate>
																		<asp:ImageButton id="btnEliminarTodosPlan" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar Todos"></asp:ImageButton>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<asp:ImageButton id="btnEliminarPlan" runat="server" ImageUrl="../../images/ico_Eliminar.gif" ImageAlign="Middle"
																			ToolTip="Eliminar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn Datafield="IdPlan" Visible="False" HeaderText="IdPlan"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Plan" HeaderText="Plan">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="170px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="NroPlanes" HeaderText="Nro Planes">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdPlazo" Visible="False" HeaderText="IdPlazo"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Plazo" HeaderText="Plazo">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="150px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdCuota" Visible="False" HeaderText="IdCuota"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Cuota" HeaderText="Cuota" ItemStyle-Width="100px">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="70px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="Porcentaje" HeaderText="Pct %" DataFormatString="{0:N2}">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:TemplateColumn HeaderText="">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<ItemTemplate>
																		<asp:ImageButton id="btnEditarPlan" runat="server" ImageUrl="../../images/btn_edit.jpg" ImageAlign="Middle"
																			ToolTip="Editar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr id="trRestricciones">
										<td style="WIDTH: 100%" align="center" colSpan="7">
											<table class="Arial11BV" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
												cellSpacing="1" cellPadding="1">
												<tr height="20">
													<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">RESTRICCIONES&nbsp;POR 
														RIESGO
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
														align="right"><input class="Boton" id="btnAgregarRestriccion" onmouseover="this.className='BotonResaltado';"
															onclick="cargarPopUpRestricciones();" onmouseout="this.className='Boton';" type="button" value="Agregar"
															name="btnAgregarRestriccion">
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px" align="center"><asp:datagrid id="dgRestricciones" runat="server" DataKeyField="IdDocumento" AllowPaging="True"
															CellPadding="1" CellSpacing="1" BorderColor="#95B7F3" PageSize="5" AutoGenerateColumns="False">
															<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
															<HeaderStyle CssClass="TablaTitulos" Height="20px" HorizontalAlign="Center"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<HeaderTemplate>
																		<asp:ImageButton id="btnEliminarTodosRestriccion" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar Todos"></asp:ImageButton>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<asp:ImageButton id="btnEliminarRestriccion" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn Datafield="IdDocumento" Visible="False" HeaderText="IdDocumento"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Documento" HeaderText="Documento">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdRiesgo" Visible="False" HeaderText="IdRiesgo"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Riesgo" HeaderText="Riesgo">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdPlan" Visible="False" HeaderText="IdPlan"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Plan" HeaderText="Plan">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="110px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="NroPlanes" HeaderText="Nro Planes">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="70px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdPlazo" Visible="False" HeaderText="IdPlazo"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Plazo" HeaderText="Plazo">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdCuota" Visible="False" HeaderText="IdCuota"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Cuota" HeaderText="Cuota">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="70px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="Porcentaje" HeaderText="Pct %" DataFormatString="{0:N2}">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:TemplateColumn HeaderText="">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<ItemTemplate>
																		<asp:ImageButton id="btnEditarRestriccion" runat="server" ImageUrl="../../images/btn_edit.jpg" ImageAlign="Middle"
																			ToolTip="Editar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr id="trTopeConsumo">
										<td style="WIDTH: 100%" align="center" colSpan="7">
											<table class="Arial11BV" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
												cellSpacing="1" cellPadding="1">
												<tr height="20">
													<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">TOPE&nbsp;DE 
														CONSUMO POR PLAN</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
														align="right"><input class="Boton" id="btnAgregarTopeConsumo" onmouseover="this.className='BotonResaltado';"
															onclick="cargarPopUpTopeConsumo();" onmouseout="this.className='Boton';" type="button" value="Agregar/Editar"
															name="btnAgregarTopeConsumo">
													</td>
												</tr>
												<tr>
													<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px" align="center"><asp:datagrid id="dgTopeConsumo" runat="server" DataKeyField="IdPlan" AllowPaging="True" CellPadding="1"
															CellSpacing="1" BorderColor="#95B7F3" PageSize="5" AutoGenerateColumns="False">
															<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
															<HeaderStyle CssClass="TablaTitulos" Height="20px" HorizontalAlign="Center"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<HeaderTemplate>
																		<asp:ImageButton id="btnEliminarTodosTopeConsumo" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar Todos"></asp:ImageButton>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<asp:ImageButton id="btnEliminarTopeConsumo" runat="server" ImageUrl="../../images/ico_Eliminar.gif"
																			ImageAlign="Middle" ToolTip="Eliminar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn Datafield="IdPlan" Visible="False" HeaderText="IdPlan"></asp:BoundColumn>
																<asp:BoundColumn Datafield="Plan" HeaderText="Plan">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="250px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdTopeConsumo" Visible="False" HeaderText="IdTopeConsumo"></asp:BoundColumn>
																<asp:BoundColumn Datafield="TopeConsumo" HeaderText="Tope Consumo">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Datafield="IdEstadoTope" Visible="False" HeaderText="IdEstadoTope"></asp:BoundColumn>
																<asp:BoundColumn Datafield="EstadoTope" HeaderText="Estado Tope">
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	<HeaderStyle Width="150px"></HeaderStyle>
																</asp:BoundColumn>
															</Columns>
															<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></td>
												</tr>
											</table>
										</td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
			</TD></TR></TBODY></TABLE></TD></TR> 
			<!-- Fin de Edicion --> </TABLE> 
			<!-- Fin de Tabla Principal -->
			<!-- <input style="DISPLAY: none" id="btnEliminar" type="button" runat="server">-->
			<!-- <input style="DISPLAY: none" id="btnEditar" type="button" runat="server">--><INPUT id="hidCodigo" type="hidden" name="hidCodigo" runat="server">
			<input id="hidCondicionTAB" type="hidden" name="hidCondicionTAB" runat="server">
			<input id="hidCondicionPdv" type="hidden" name="hidCondicionPdv" runat="server">
			<input id="hidIndice" type="hidden" size="1" name="hidIndice" runat="server">
			<asp:button id="btnEditarServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEditarPdvServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarCampaniaServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarPdvServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarPlanServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarRestriccionServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTopeConsumoServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTodosCampaniaServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTodosPdvServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTodosPlanServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTodosRestriccionServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTodosTopeConsumoServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTodosCuotasServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarCuotaServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnAgregarServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnListadoServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnGrabarServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnRecuperarValores" style="DISPLAY: none" Runat="server"></asp:button></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
 
 
 
 
