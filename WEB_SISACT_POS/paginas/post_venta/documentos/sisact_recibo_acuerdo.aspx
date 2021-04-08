<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_recibo_acuerdo.aspx.vb" Inherits="sisact_recibo_acuerdo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Carga de Recibos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src='../../../script/Lib_FuncValidacion.js"'></script>
		<script language="JavaScript" src="../../../librerias/date-picker.js"></script>
		<script language="javascript">
		
			function trim(cadena){
				for(i=0; i<cadena.length; ){
					if(cadena.charAt(i)==" ")
						cadena=cadena.substring(i+1, cadena.length);
					else
						break;
				}
				for(i=cadena.length-1; i>=0; i=cadena.length-1){
					if(cadena.charAt(i)==" ")
						cadena=cadena.substring(0,i);
					else
						break;
				}
				return cadena;
			}
			function ValidaDecimalB(control,campo,vacio)
			{
				var flag=true;
				var i,j,a,cadena;
				eval("cadena = " + control + ".value");
				cadena=trim(cadena);
				if ((cadena == null) || (cadena.length == 0)&&(!vacio)){
					eval("" + control + ".select()");
					alert('Debe ingresar ' + campo );
					return false;
				}
				
				for(i=0;i<cadena.length;i++)
				{ 	a=(cadena.substr(i,1));
					if (a==' ') {
						flag=false;
					}

					j=a.charCodeAt(0);
					if ( !( ((j>=48) && (j<=57)) || (j==45) || (j==46))   )
						flag=false;
				}
				if (! flag)
				{
					alert(campo + " contiene caracteres no válidos");
					eval(control + ".select()")
				}
				return flag;
			}
			
			function ValidaFechaMenor(control1,control2,campo1,campo2){ 
				var cadena1;
				var cadena2;				
				eval("cadena1 = " + control1 + ".value");
				eval("cadena2 = " + control2 + ".value");
				if ((cadena1!='')&&(cadena2!='')){
					comp1 	= cadena1.substr(6,4) + '' + cadena1.substr(3,2) + '' + cadena1.substr(0,2);
					comp2 	= cadena2.substr(6,4) + '' + cadena2.substr(3,2) + '' + cadena2.substr(0,2);
					if 	((comp1) < (comp2)){
						alert('' + campo1 +' debe ser MENOR o IGUAL que la ' + campo2 + '');
						return false;
						}
				}
				return true;
			}
			
			function agregarRecibo(valor){				
				if (getValue('hidProceso') == 'A_E') {
					mostrarTabVisible('Modificar');
				}
				else{
					limpiar();
					mostrarTabVisible('Agregar');
					setValue('hidProceso','AGR_E');
				}				
				setFocus('ddlBanco');
			}
			function seleccionarBanco(){
				setValue('hidBancoId',getValue('ddlPlazo'));
				setValue('hidBancoDes',getText('ddlPlazo'));
			}
			
			function validarDatos(opcion){
				var banco =  getValue('ddlBanco');
				if(banco=='' || banco=='-1' ){
					alert('El Banco es un dato requerido.');
					setFocus('ddlBanco');
					return false;
				}	
							
				var nroOperacion = getValue('txtNroOperacion');				
				//if (banco != 1){
					if(nroOperacion==''){
						alert('El Nro de Operacion es un dato requerido.');
						setFocusSelect('txtNroOperacion');
						return false;
					}
				//}
				var montoOperacion = getValue('txtMontoOperacion');
				
				if(montoOperacion=='' || parseFloat(montoOperacion)==0 ){
					alert('El Monto de Deposito es un dato requerido.');
					setFocusSelect('txtMontoOperacion');
					return false;
				}
				if(!ValidaDecimalB("document.form1.txtMontoOperacion","Monto",true)){
					return false;
				}
				
				
				var fechaOperacion= getValue('txtFechaDeposito');
				if(fechaOperacion == '' ){
					alert('La fecha de Deposito es un dato requerido.');
					setFocusSelect('txtFechaDeposito');
					return false;
				}				
				
				if (validarFecha('txtFechaDeposito')==false){
					setFocusSelect('txtFechaDeposito');
					return false;
				}
				
				/* la fecha debe ser MENOR A LA DE HOY */
				if(!ValidaFechaMenor("document.getElementById('hidFechaActual')","document.getElementById('txtFechaDeposito')",'La Fecha de DEPOSITO','Fecha Actual')){
					setFocusSelect('txtFechaDeposito');
					return false;
				}		
				return true
			}						
			function limpiar(){
				setValue('ddlBanco',"-1");
				setValue('txtFechaDeposito',"");
				setValue('txtNroOperacion',"");
				setValue('txtMontoOperacion',"");				
			}
			
			function editar(control){
				var fila = control.id;
				fila = fila.replace('dgRecibo','');
				fila = fila.replace('lblEditar','');				
				var id = getValue('dgRecibo' + fila + 'hidReciboIdFila');
				setValue('hidProceso','E_E');
				setValue('hidReciboId',id );
				mostrarTabVisible('Modificar')
				document.form1.submit();
			}
			function eliminar(control){
				var fila = control.id;
				fila = fila.replace('dgRecibo','');
				fila = fila.replace('lblEliminar','');
				
				if (confirm('¿Esta seguro de eliminar este elemento?')==false) return;
				var id  = getValue('dgRecibo' + fila + 'hidReciboIdFila');
				setValue('hidProceso','Elim_E');
				
				setValue('hidReciboId',id );
				document.form1.submit();
			}
			function aceptar(valor){				
				if( validarDatos(valor) == false) return false;				
				
				
				document.form1.submit();
				
			}
			function mostrarTabVisible(valor){
				if (valor == 'Listado'){	
					setVisible('tblListado',true);
					setVisible('tblDetalle',false);
				}
				if (valor == 'Modificar'){	
					setVisible('tblListado',false);
					setVisible('tblDetalle',true);
					setVisible('btnAceptar',true);
				}
				if (valor == 'Agregar'){	
					setVisible('tblListado',false);
					setVisible('tblDetalle',true);
					setVisible('btnAceptar',true);
				}
			}					
			function obtenerNroFilasGrid(){
				var tbl = document.getElementById('dgRecibo');
				var filas;
				if (tbl != null && tbl.rows!=null)
					filas = tbl.rows.length-1;				
				return filas;
			}
			
			function retornarParent(){
				var listaRecibo = getValue('hidListaRecibo');
				var nroFilas = obtenerNroFilasGrid(); //getValue('hidNroEquipos');
				self.parent.retornoRecibo(listaRecibo,nroFilas);
			}
			function cancelar(){
				mostrarTabVisible('Listado');
				self.parent.mostrarBotones(true);
				retornarParent();
			}
			
			function alerta()
			{
				alert(getValue('hidListaRecibo'));
			}
			

			function inicio(){
				//alert(getValue('hidProceso'));
						
				if (getValue('HidMsg') != ''){
					if (getValue('hidProceso') == ''){
						mostrarTabVisible('Modificar');
						setValue('hidProceso','A_E' );
					}
					else if (getValue('hidProceso') == 'AGR_E'){
						mostrarTabVisible('Agregar');
						setValue('hidProceso','AGR_E');
					}
					alert(getValue('HidMsg'));
					setValue('HidMsg','');
				}else{
					retornarParent();
					if (getValue('hidProceso') == 'A_E'){
						self.parent.iframeAgregarRecibo();
					}
					else{	
						mostrarTabVisible('Listado');
						self.parent.mostrarBotones(true);
					}					
				}		
			}
		</script>
	</HEAD>
	<body onload="inicio();">
		<form id="form1" method="post" runat="server">
			<table style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 1px" cellSpacing="0" cellPadding="0"
				width="102%" border="0">
				<tr>
					<td>
						<TABLE id="tblListado" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><asp:datagrid id="dgRecibo" runat="server" AutoGenerateColumns="False">
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:Label ID="lblEditar" onclick="javascript:editar(this);" Runat="server">
														<IMG alt="Editar Fila" style="cursor:hand" src="../../../images/editar.gif" border="0"></asp:Label>
													<INPUT id="hidReciboIdFila" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidId" runat="server" value ='<%# DataBinder.Eval(Container.DataItem, "RECIBO_ID")%>' >
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblEliminar" onclick="javascript:eliminar(this);" Runat="server">
														<IMG alt="Eliminar Fila" style="cursor:hand" src="../../../images/rechazar.gif" border="0"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Banco">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="Arial10b"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblBancoDes runat="server" CssClass="Arial10b" Text='<%# DataBinder.Eval(Container.DataItem, "BANCO_DES")%>'>
													</asp:Label><INPUT id=hidBancoIdFila style="WIDTH: 8px; HEIGHT: 22px" type=hidden size=1 value='<%# DataBinder.Eval(Container.DataItem, "BANCO_ID")%>' name=hidBancoId runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Nro Operacion">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblNroOperacion" runat="server" CssClass="Arial10b" Text='<%# DataBinder.Eval(Container.DataItem, "NRO_OPERACION")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Fecha Deposito">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblFechaDeposito" runat="server" CssClass="Arial10b" Text='<%# ObtenerFecha(DataBinder.Eval(Container.DataItem, "FECHA_DEPOSITO"),"{0:dd/MM/yyyy}")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Monto Deposito">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblMontoDeposito" runat="server" CssClass="Arial10b" Text='<%# DataBinder.Eval(Container.DataItem, "MONTO_DEPOSITO","{0:#,###,###.00}")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="RECIBO_ID" HeaderText="RECIBO_ID">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" CssClass="Arial10b"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn Visible="False">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblSOLIN_CODIGO" runat="server" CssClass="Arial10b" Text='<%# DataBinder.Eval(Container.DataItem, "SOLIN_CODIGO")%>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
						<TABLE id="tblDetalle" style="DISPLAY: none">
							<tr>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
										<TR>
											<TD><asp:label id="lblEquipoDesEdit" runat="server" CssClass="Arial10b" Width="66px">Banco
												</asp:label></TD>
											<TD><asp:dropdownlist id="ddlBanco" runat="server" CssClass="clsSelectEnable0"></asp:dropdownlist></TD>
											<TD><asp:label id="lblCantidadEdit" runat="server" CssClass="Arial10b">Nro Operación</asp:label></TD>
											<TD><asp:textbox id="txtNroOperacion" runat="server" CssClass="clsInputEnable" Width="160px" MaxLength="60"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label2" runat="server" CssClass="Arial10b">Monto Deposito</asp:label></TD>
											<TD><asp:textbox onkeypress="return soloMontos(event, this);" id="txtMontoOperacion" runat="server"
													CssClass="clsInputEnable" Width="111px" MaxLength="15"></asp:textbox></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label32" runat="server" CssClass="Arial10b" Width="86px">Fecha Depósito</asp:label></TD>
											<TD>
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" border="0">
													<TR>
														<TD><asp:textbox id="txtFechaDeposito" runat="server" CssClass="clsInputEnable" Width="80" MaxLength="10"></asp:textbox></TD>
														<td vAlign="top"><A onmouseover="window.status='Date Picker';return true;" style="CURSOR: hand" onmouseout="window.status='';return true;"
																href="javascript:show_calendar('form1.txtFechaDeposito');"><IMG id="ibtnFechaDeposito" src="../../../images/Calendario.gif" border="0">
															</A>
														</td>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD align="center"><INPUT id="hidLisRecbElim" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidLisRecbElim"
										runat="server"><INPUT id="hidSEC" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidBancoId"
										runat="server"><INPUT id="hidBancoId" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidBancoId"
										runat="server"> <INPUT id="hidBancoDes" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidBancoDes"
										runat="server"> <INPUT id="hidListaRecibo" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidListaRecibo"
										runat="server"> <INPUT id="hidFechaActual" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidFechaActual"
										runat="server"> <INPUT id="hidProceso" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidProceso"
										runat="server"><INPUT id="hidReciboId" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidReciboId"
										runat="server"> <INPUT id="hidOcultar" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidOcultar"
										runat="server"><INPUT id="hidMsg" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" name="hidMsg"
										runat="server"><INPUT id="hidFilaRecibo" style="WIDTH: 7px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hidFilaRecibo" runat="server"> <INPUT class="Boton" id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="aceptar('AGR_E');" onmouseout="this.className='Boton';" type="button" value="Aceptar" name="btnAceptar">&nbsp;
									<INPUT class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="cancelar()" onmouseout="this.className='Boton';" type="button" value="Cancelar"
										name="btnCancelar">
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
