<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_listado_representante_legal.aspx.vb" Inherits="sisact_listado_representante_legal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_listado_representante_legal</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../librerias/lib_funcvalidacion.js"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript">
		//PROY 31636
			/*$(document).ready(function(){
				seleccionarNacionalidad();
			});*/
			window.onload = seleccionarNacionalidad;
			function seleccionarNacionalidad()
			{	
				var tbl = document.getElementById('dgRepresentanteLegal');
				var filas = tbl.rows.length;
				var i;
				for(i=2;i <= filas;i++)
				{
					var control = 'dgRepresentanteLegal__ctl' + i + '_ddlNacionalidad';
					var docControl = 'dgRepresentanteLegal__ctl' + i + '_hidTipoDocumento';
					var dll = document.getElementById(control);
					var strTipoDoc = getValue(docControl);//document.getElementById(docControl).outerText;//"DNI"
					
					if (strTipoDoc != "")
					{
						if (strTipoDoc == '01')
						{
							dll.disabled = true;
							dll.value = '154';
						}
						else
						{
							dll.disabled = false;
							dll.value = '-1';
							//dll.removeChild(dll.options[i]);
							if(strTipoDoc != '01' && strTipoDoc != '06'){
								for(var i = 0; i < dll.length; i++){
									if(dll.options[i].value == '154'){
										dll.remove(i);
										break;
									}
								}
							}
						}
					}
				}
			}
			//PROY 31636
			
			function obtenerRepresentanteSeleccionado()
			{	
				var tbl = document.getElementById('dgRepresentanteLegal');
				var filas = tbl.rows.length;
				var i;
				var lista_salida = '';
				for(i=2;i < filas+2;i++)
				{
					var control = 'dgRepresentanteLegal__ctl' + i + '_chkRepresentanteLegal';
					var chk = document.getElementById(control);
					if (chk != null)
					{
						if (chk.checked == true)
						{
							var controlNumero = 'dgRepresentanteLegal__ctl' + i + '_lblNumero';
							var controlTipoDocumento = 'dgRepresentanteLegal__ctl' + i + '_hidTipoDocumento';
							var controlNombre = 'dgRepresentanteLegal__ctl' + i + '_lblNombre';
							var controlApePaterno = 'dgRepresentanteLegal__ctl' + i + '_lblApellidoPaterno';
							var controlApeMaterno = 'dgRepresentanteLegal__ctl' + i + '_lblApellidoMaterno';
							var controlCargo = 'dgRepresentanteLegal__ctl' + i + '_lblCargo';
							var controlCodNacionalidad = 'dgRepresentanteLegal__ctl' + i + '_ddlNacionalidad'; //PROY 31636
							
							var numero = getValueHTML(controlNumero);						
							var tipoDocumento = getValue(controlTipoDocumento);						
							var nombre = getValueHTML(controlNombre).replace("'","");
							var apePaterno = getValueHTML(controlApePaterno).replace("'","");
							var apeMaterno = getValueHTML(controlApeMaterno).replace("'","");						
							var cargo = getValueHTML(controlCargo);
							var codNacionalidad = getValue(controlCodNacionalidad);//PROY 31636
							var descNacionalidad = getText(controlCodNacionalidad);//PROY 31636 
							if(tipoDocumento != '01' && codNacionalidad =='154'){
								alert("Debe seleccionar una nacionalidad diferente para "+ nombre + " "+apePaterno+" "+apeMaterno);
								return;
							}
							if(codNacionalidad != '-1'){
								var datosRepresentante =  tipoDocumento + ";" + numero + ";" + nombre + ";" + apePaterno + ";" + apeMaterno + ";" + cargo +";"+ codNacionalidad +";"+ descNacionalidad;					
							if (numero != '')
							{							
								lista_salida += datosRepresentante + "|"  ;
							}						
							}else{
								alert("Debe seleccionar una nacionalidad para "+ nombre + " "+apePaterno+" "+apeMaterno);
								return;
							}
						}
					}
				}
				if (lista_salida!='')
				{
					lista_salida = lista_salida.substring(0,lista_salida.length - 1);
				}
				return lista_salida;
			}

			function seleccionarTodo(chk)
			{
				var xState = chk.checked;
				var theBox = chk;
				var nombre = "_chkRepresentanteLegal";
				var idBox;
				var i=0;			
				elm = theBox.form.elements;
				for (i=0; i<elm.length; i++)
				{
					if (elm[i].type == "checkbox" && elm[i].id != theBox.id)
					{
						idBox = elm[i].id;
						var index = idBox.indexOf(nombre);
						if (index > -1)
						{
							if (elm[i].checked != xState)
								elm[i].click();				
						}
					}
				}
			}
		</script>
	</HEAD>
	<body>
		<form id="frmPrincipal" name="frmPrincipal" method="post" runat="server">
			<table style="Z-INDEX: 101; POSITION: absolute; TOP: 1px; LEFT: 0px" cellSpacing="0" cellPadding="0"
				width="102%" border="0">
				<TR>
					<TD align="left"><asp:datagrid id="dgRepresentanteLegal" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="5px"></ItemStyle>
									<HeaderTemplate>
										<asp:CheckBox id="chkMarcar" onclick="javascript:seleccionarTodo(this);" ToolTip="Seleccionar Todo/Deseleccionar Todo"
											AutoPostBack="false" Runat="server" Text="" TextAlign="Right"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<input id="chkRepresentanteLegal" runat="server" type="checkbox" name="chkRepresentanteLegal">
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Nombre">
									<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblNombre" CssClass="TablaFilas" text='<%# DataBinder.Eval(Container.DataItem, "APODV_NOM_REP_LEG")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Apellido Paterno">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblApellidoPaterno" CssClass="TablaFilas" text='<%# DataBinder.Eval(Container.DataItem, "APODV_APA_REP_LEG")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Apellido Materno">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblApellidoMaterno" CssClass="TablaFilas" text='<%# DataBinder.Eval(Container.DataItem, "APODV_AMA_REP_LEG")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tipo Documento">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblTipoDocumento" runat="server" CssClass="TablaFilas" text='<%# DataBinder.Eval(Container.DataItem, "TDOCV_DESCRIPCION_REP")%>'>
										</asp:Label>
										<input id="hidTipoDocumento" value='<%# DataBinder.Eval(Container.DataItem, "APODC_TIP_DOC_REP")%>' runat="server" type="hidden" NAME="hidTipoDocumento"/>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="N&#176; Documento">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" CssClass="TablaFilas"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblNumero" runat="server" CssClass="TablaFilas" text='<%# DataBinder.Eval(Container.DataItem, "APODV_NUM_DOC_REP")%>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Nacionalidad">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList id="ddlNacionalidad" CssClass="clsSelectEnable" runat="server" Width="120px" DataSource='<%# obtenerNacionalidad()%>' DataTextField='Descripcion' DataValueField='Codigo'>
										</asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Cargo">
									<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblCargo" runat="server" CssClass="TablaFilas" text='<%# DataBinder.Eval(Container.DataItem, "APODV_CAR_REP")%>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Situaci&#243;n">
									<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblSituacion" runat="server" CssClass="TablaFilas"></asp:Label>
										<input id="hidMensajeSituacion" runat="server" type="hidden" NAME="hidMensajeSituacion" />
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</table>
			<input id="hidSituacionOK" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidSituacionOK"
				runat="server"> <input id="hidSituacionNOOK" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidSituacionNOOK"
				runat="server"> <input id="hidError" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidError"
				runat="server"> <input id="hidMensajeResultado" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidMensajeResultado" runat="server"> <input id="hidCodTipoRiesgo" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidCodTipoRiesgo"
				runat="server"> <input id="hidRazonSocial" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidRazonSocial"
				runat="server"> <input id="hidNumeroOperacion" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidNumeroOperacion"
				runat="server"> <input id="hidFlagEjecucion" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidFlagEjecucion"
				runat="server"> <input id="hidNombre" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidNombre" runat="server">
			<input id="hidApellidoPaterno" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidApellidoPaterno"
				runat="server"> <input id="hidApellidoMaterno" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidApellidoMaterno"
				runat="server"> <input id="hidCodSolicitud" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidCodSolicitud"
				runat="server"> <input id="hidTipoPersona" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidTipoPersona"
				runat="server"> <input id="hidFlagInterno" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidFlagInterno"
				runat="server"> <input id="hidNroFilas" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidNroFilas"
				runat="server"> <input id="hidDeudaFinanciera" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidDeudaFinanciera"
				runat="server"> <input id="hidEstadoRUC" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidEstadoRUC"
				runat="server"> <input id="hidForm" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidForm" runat="server">
			<input id="hidCodError" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidCodError"
				runat="server"> <input id="hidContFact" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidContFact"
				runat="server">
				<!-- INICIO: PROY-20054-IDEA-23849 -->
				<input id="hidBuroConsultado" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidBuroConsultado"
				runat="server">
				<!-- FIN: PROY-20054-IDEA-23849 -->
		</form>
		<script language="javascript">
			if (document.frmPrincipal.hidFlagEjecucion.value == "1")
			{

				if (document.frmPrincipal.hidMensajeResultado.value != "" && document.frmPrincipal.hidFlagInterno.value != "3")
				{		
					parent.alert(document.frmPrincipal.hidMensajeResultado.value);
					parent.quitarImagenEsperando();
					parent.habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
				}
				else
				{

                    //PROY-20054|CAMBIOS EN EL MÉTODO
					parent.f_RetornoDataCreditoCorp
					(
						document.frmPrincipal.hidNumeroOperacion.value,
						document.frmPrincipal.hidRazonSocial.value,
						document.frmPrincipal.hidNombre.value,
						document.frmPrincipal.hidApellidoPaterno.value,
						document.frmPrincipal.hidApellidoMaterno.value,
						document.frmPrincipal.hidCodTipoRiesgo.value,
						document.frmPrincipal.hidTipoPersona.value,
						document.frmPrincipal.hidDeudaFinanciera.value,
						document.frmPrincipal.hidNroFilas.value,
						document.frmPrincipal.hidBuroConsultado.value
					);
				}
			}						
		</script>
	</body>
</HTML>
 
 
 
 
