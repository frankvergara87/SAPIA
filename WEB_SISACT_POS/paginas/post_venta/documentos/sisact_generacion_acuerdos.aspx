<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_generacion_acuerdos.aspx.vb" Inherits="sisact_generacion_acuerdos" aspcompat="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>.::ADJUNTAR DOCUMENTOS::.</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK href="../../../estilos/progress.css" type="text/css" rel="stylesheet">
		<script src="../../../script/ProgressAnthem.js" type="text/javascript"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		
			function onKeyUpNroSEC()
			{				
				var nro =  getValue('txtNroSolicitud');
				var btn =  document.getElementById('btnConsultar'); 
				if (btn != null)
					btn.disabled = (nro == null || nro == '');
				else
					btn.disabled  = false;
			}
		
			function HabilitarControlAyudaTipoDoc()
			{
				var IdTipoDoc;
				var total = 0;				
				var habilitar =  false;
				IdTipoDoc = getValue('ddlTipoDocumento');
				if (IdTipoDoc != '' || IdTipoDoc != 'undefined')					
					total = obtenerTotalDocsAdjunta(IdTipoDoc);
				
				//--
				setEnabled('btnAyudaTipoDoc',(total>0),'');
				
			}
		
			function obtenerTotalDocsAdjunta(IdTipoDoc)
			{
				if (IdTipoDoc <= 0) return 0;
				var cad = getValue('hidTotalDocsAdjunta');
				if (cad == '') return '';				
				var TiposDoc = cad.split("|");
				var i, aDatos;
				for (i=0;i < TiposDoc.length;i++)
				{
					aDatos = TiposDoc[i].split(";");
					if ( aDatos[0] == IdTipoDoc){
						cad = aDatos[1];
						return parseInt(cad, 10);
					}
				}
				return 0;
			}	
			
			function MostrarVentanaPopup (pUrl, w, h)
			{			
					var rpta;
					var opciones = 'dialogHeight: ' + h +'px; dialogWidth: '+ w + 'px; edge: Raised; center: Yes; help: No; resizable: No; status: No; scrollbars=no';
					rpta = window.showModalDialog(pUrl, '' ,opciones);						
				
			}
			
			function ActualizarGrilla ()
			{
				//return Anthem_InvokePageMethod('',[],function(result){;})
				var valor= getValue('hidEnviado');					
				if (valor=='1') 
				{
					Anthem_InvokePageMethod('ObtenerDocumentosSEC',[]);
					setValue('hidEnviado','');
				}
			}
	
			function ValidarCampos ()
			{
				if(getValueHTML('lblNroSolicitud')==''){
					alert('Nro de Solicitud es un dato requerido.');
					setFocus('txtNroSolicitud');
					return false;
				}
				if(getValue('ddlTipoDocumento')=='0'){
					alert('Tipo de Documento es un dato requerido.');
					setFocus('ddlTipoDocumento');
					return false;
				}
				if(getValue('ddlDocumento')=='0'){
					alert('Documento es un dato requerido');
					setFocus('ddlDocumento');
					return false;
				}
				if (getValue('txtNombreGlosa')=='') {
					alert('El Nombre de Glosa es un dato requerido');
					setFocus('txtNombreGlosa');
					return false;
				}
				
				setValue('hidEnviado','1');
				
				return true;	
					
			}
			
			function InicializarEditar()
			{
				setValue('hidEnviado','1');	
			}
			
			function CambiarNombreGlosa()
			{
				setValue('txtNombreGlosa',getText('ddlDocumento'));	
			}
			
			
			function MostrarAyudaTipoDoc() 
			{
				var id = getValue('ddlTipoDocumento');
				if (id != '') {
					return MostrarVentanaNoModal('sisact_matrizdocumentos.aspx?TD='+id,830,500);
				}	
			}
			
			function ConfirmarEliminarVarios()
			{
				if (!window.confirm('¿Realmente desea eliminar los registros seleccionados?') )
					return false;
				else
					return true;
			}			
			
			function ConfirmarCerrarAcuerdo	()
			{
				if (!window.confirm('¿Realmente desea cambiar el Estado del Acuerdo a Cerrado?') )
					return false;
				else
					return true;
			}
			
			function ConfirmarEnviarCreditosActivaciones()
			{
				if (!window.confirm('¿Realmente desea enviar todos los documentos a Créditos?') )
					return false;
				else
					return true;
			}	
	
			function maximizar()
			{
				top.window.moveTo(0,0);
				if (document.all) {
					try{
						top.window.resizeTo(screen.availWidth,screen.availHeight);
					}catch(ex){}
				}else if (document.layers||document.getElementById) {
					if (top.window.outerHeight<screen.availHeight||top.window.outerWidth<screen.availWidth){
						try{
							top.window.outerHeight = screen.availHeight;
							top.window.outerWidth = screen.availWidth;						
						}catch(ex){}
					}
				}
			}
	
			function retonaSubsanacion(){
				if(document.getElementById('hidEstadoSEC').value != '15' && document.getElementById('hidEstadoSEC').value != '20'  && document.getElementById('hidEstadoSEC').value != ''){
					window.opener.cambiaFecha(document.getElementById('hidFechaConsulta').value);
					window.close();
				}
			}
			
			/*MARVIN ANDIA*/
			function iframeAgregarRecibo(){
				mostrarBotones(false);
				document.getElementById("ifrRecibo").style.height = "100px";
				ifrRecibo.agregarRecibo(1);
			}
			
			function mostrarBotones(flag){
				setVisible('trBotones',flag);
			}
			
			function mostrarFrameRecibo()
			{	
				var idSEC =getValueHTML('lblNroSolicitud');
	
				
				if(idSEC!='')
				{
					var tblRecibo = document.getElementById('tblRecibo');
					tblRecibo.style.display = 'block';
					
					var estado = getValue('hidEstadoSEC');
					ifrRecibo.location.href = "sisact_recibo_acuerdo.aspx?IdSEC="+idSEC + "&estado="+ estado;	
				}
				
			}
			
			function estadoSec(estado)
			{
				setValue('hidEstadoSEC',estado);
			}
			
			function grabar(){
				//var hid = ifrArchivos.document.getElementById('hidLista')
				//var hidArrayArchiElim = ifrArchivos.document.getElementById('hidLisArchiElim').value;//OGV
				var hidArrayRecibElim = ifrRecibo.document.getElementById('hidLisRecbElim').value;//OGV
				
				//setValue('hidArchivosElim',hidArrayArchiElim);//OGV
				setValue('hidRecibosElim',hidArrayRecibElim);//OGV
			
				/*var lista
				if (hid==null){
					alert("Debe agregar por lo menos un archivo");
					return false;                                          
				}
				else{
					lista = hid.value
					if (lista == ""){
						alert("Debe agregar por lo menos un archivo");
						return false;       
					}
				}*/
				
				//setValue('hidListaArchivos',lista);				
				
				var listaRecibos = getValue('hidListaRecibo');
				/*var estado = getValue('hidEstadoSEC');
				var nroDG = getValue('hidNroDG');
				if (estado == getValue('hidEstadoSEC_OBSERVADO')){ // cuando esta OBSERVADO ES OBLIGATORIO el registro de recibos
					if (listaRecibos == '' && parseFloat(nroDG)>0){
						alert('Debe Ingresar los datos del RECIBO.');
						setFocus('btnAgregarRecibo');
						return false;
					}
				}				
				if ( ( getValue('hidFlagEnvio')== '1' ) && (estado == getValue('hidEstadoSEC_APROBADO') || estado == getValue('hidEstadoSEC_NUEVO'))){ // cuando esta APROBADO ES OBLIGATORIO el registro de recibos
					if (listaRecibos == '' && parseFloat(nroDG)>0){
						alert('Debe Ingresar los datos del RECIBO.');
						setFocus('btnAgregarRecibo');
						return false;
					}
				}*/
				
				if (confirm('Se grabaran los datos ingresados. ¿Desea continuar?')==false){
					return false;
				}
				setValue('hidProceso','grabar');
				setValue('hidAnexar','');
				
				document.frmGeneracionAcuerdo.submit();
			}
			
			function retornoRecibo(listaRecibo,nroFilas){		
				setValue('hidListaRecibo',listaRecibo);
				setValue('hidNroFilas',nroFilas);			
			}
			
			function inicio()
			{
				
				var msg  = document.frmGeneracionAcuerdo.hidMsg.value;
				
				if(msg!='')
				{
					alert(msg);
					mostrarFrameRecibo();
				}
			}
			
			function cancelar()
			{
				
			}
			
			function ocultarBotonesRecibo(valor)
			{
				var btnAgregarRecibo = document.getElementById('btnAgregarRecibo');
				var btnGrabar = document.getElementById('btnGrabar');
				
				if(btnGrabar!=null && btnAgregarRecibo!=null)
				{
					if(valor)
					{
						btnAgregarRecibo.style.display='none';
						btnGrabar.style.display='none';
					}else
					{
						btnAgregarRecibo.style.display='block';
						btnGrabar.style.display='block';
					}
				}
			}
			
			function verArchivo(file) {
				var estilo = "width=700,height=600,top=50,left=50,titlebar=yes,toolbar=0,location=0,directories=0,status=0,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=0";
				window.open("verDocumento.aspx?nombrearchivo=" +  file, "ACUERDO", estilo);
				//window.location.href = "verDocumento.aspx?nombrearchivo=" +  file+"&tipo=acuerdo";
			}

			function showNroDoc(numDoc, tipoDoc) {
				var indexOf = getIndexOf(arrayTipoDocPVU, tipoDoc);
				var longitud = arrayTamaDocPVU[indexOf];

				// Validar solo para los Casos DNI y RUC
				if (arrayTamaDocPVU[indexOf] == '15') {
					return numDoc;
				}
				else {
					return numDoc.substring(numDoc.length - longitud);
				}
			}

		</script>
	</HEAD>
	<body onfocus="ActualizarGrilla();" onload="maximizar();inicio();" MS_POSITIONING="GridLayout">
		<form id="frmGeneracionAcuerdo" method="post" runat="server">
			<div class="modalBackground" id="divProgress" style="DISPLAY: none; WIDTH: 982px">
				<div class="updateProgress" id="divImagen">
					<div style="TEXT-ALIGN: center">
						<IMG style="VERTICAL-ALIGN: middle" alt="..." src="../../../images/progress.gif">
					</div>
				</div>
			</div>
			<DIV style="Z-INDEX: 102; OVERFLOW: auto; WIDTH: 980px; padding:8px;" ms_positioning="GridLayout">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
						<tr>
							<td class="header" style="HEIGHT: 20px">
								&nbsp;Adjuntar Documentos</td>
						</tr>
						<tr>
							<td style="HEIGHT: 6px"></td>
						</tr>
						<tr>
							<td style="HEIGHT: 3px">
								<table class="contenido" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 166px"></TD>
										<TD style="WIDTH: 127px"></TD>
										<TD></TD>
										<TD style="WIDTH: 130px"></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<tr>
										<td style="WIDTH: 166px; HEIGHT: 20px">&nbsp;Número de Solicitud:
										</td>
										<TD style="WIDTH: 127px; HEIGHT: 20px"><asp:textbox id="txtNroSolicitud" runat="server" MaxLength="9" CssClass="clsInputEnable" Width="118px"></asp:textbox></TD>
										<td style="HEIGHT: 20px"><anthem:button id="btnConsultar" runat="server" CssClass="Boton" Width="80px" Enabled="False" EnableViewState="False"
												TextDuringCallBack="Consultando..." EnabledDuringCallBack="False" CausesValidation="False" Text="Consultar"></anthem:button></td>
										<td style="WIDTH: 104px; HEIGHT: 20px"></td>
										<td style="HEIGHT: 20px">&nbsp;</td>
										<td style="HEIGHT: 20px">&nbsp;</td>
										<td style="HEIGHT: 20px">&nbsp;</td>
									</tr>
									<TR>
										<TD style="WIDTH: 166px"></TD>
										<TD style="WIDTH: 127px"></TD>
										<TD></TD>
										<TD style="WIDTH: 130px"></TD>
										<TD></TD>
										<TD></TD>
										<TD></TD>
									</TR>
								</table>
							</td>
						</tr>
						<tr>
							<td style="HEIGHT: 2px"></td>
						</tr>
						<tr>
							<td>
								<table class="contenido" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 8px; HEIGHT: 7px"></TD>
										<TD style="WIDTH: 157px; HEIGHT: 7px"></TD>
										<TD style="WIDTH: 131px; HEIGHT: 7px"></TD>
										<TD style="WIDTH: 168px; HEIGHT: 7px"></TD>
										<TD style="HEIGHT: 7px"></TD>
										<TD style="HEIGHT: 7px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
										<td style="WIDTH: 157px; HEIGHT: 18px"><asp:label id="Label2" runat="server">Número de Solicitud : </asp:label></td>
										<td style="WIDTH: 131px; HEIGHT: 18px"><asp:label id="Label1" runat="server">Tipo de Documento : </asp:label></td>
										<td style="WIDTH: 168px; HEIGHT: 18px"><asp:label id="Label3" runat="server">Número de Documento : </asp:label></td>
										<td style="HEIGHT: 18px"><asp:label id="Label4" runat="server">Razón Social / Nombres y Apellidos : </asp:label></td>
										<TD style="HEIGHT: 18px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
										<TD style="WIDTH: 157px; HEIGHT: 20px"><anthem:label id="lblNroSolicitud" runat="server" CssClass="clsSoloLectura"></anthem:label></TD>
										<TD style="WIDTH: 131px; HEIGHT: 20px"><anthem:label id="lblTipoDoc" runat="server" CssClass="clsSoloLectura"></anthem:label></TD>
										<TD style="WIDTH: 168px; HEIGHT: 20px"><anthem:label id="lblNroDoc" runat="server" CssClass="clsSoloLectura"></anthem:label></TD>
										<TD style="HEIGHT: 20px"><anthem:label id="lblRazon" runat="server" CssClass="clsSoloLectura"></anthem:label></TD>
										<TD style="HEIGHT: 20px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 8px"></TD>
										<TD style="WIDTH: 157px; HEIGHT: 6px"></TD>
										<TD style="WIDTH: 131px"></TD>
										<TD style="WIDTH: 168px"></TD>
										<TD></TD>
										<TD></TD>
									</TR>
								</table>
							</td>
						</tr>
						<tr>
							<td style="HEIGHT: 2px"></td>
						</tr>
						<tr>
							<td>
								<div id="divCrearAnexar" runat="server">
					<table class="contenido" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TBODY>
							<tr>
								<td style="WIDTH: 7px; HEIGHT: 19px"></td>
								<td style="WIDTH: 263px; HEIGHT: 19px" vAlign="bottom" colSpan="2">Tipo de 
									Documento:
								</td>
								<td style="WIDTH: 331px; HEIGHT: 19px" vAlign="bottom">Documento:</td>
								<td style="WIDTH: 205px; HEIGHT: 19px" vAlign="bottom">Nombre de Glosa:</td>
								<td style="HEIGHT: 19px">&nbsp;</td>
								<td style="HEIGHT: 19px">&nbsp;</td>
								<td style="HEIGHT: 19px">&nbsp;</td>
							</tr>
							<tr>
								<td style="WIDTH: 7px; HEIGHT: 23px">&nbsp;</td>
								<td style="WIDTH: 174px; HEIGHT: 23px" vAlign="middle"><anthem:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="clsSelectEnable0" Width="232px" onchange="HabilitarControlAyudaTipoDoc(); setValue('txtNombreGlosa','');"
										AutoUpdateAfterCallBack="True" AutoCallBack="True"></anthem:dropdownlist></td>
								<td style="WIDTH: 29px; HEIGHT: 23px" vAlign="middle" align="left"><anthem:button id="btnAyudaTipoDoc" runat="server" CssClass="Boton" Width="20px" Enabled="False"
										CausesValidation="False" Text="?"></anthem:button>&nbsp;</td>
								<td style="WIDTH: 331px; HEIGHT: 23px"><anthem:dropdownlist id="ddlDocumento" runat="server" CssClass="clsSelectEnable0" Width="99%" onchange="CambiarNombreGlosa();"
										AutoUpdateAfterCallBack="True" AutoCallBack="True"></anthem:dropdownlist></td>
								<TD style="WIDTH: 205px; HEIGHT: 23px"><asp:textbox id="txtNombreGlosa" runat="server" CssClass="clsInputEnable" Width="100%" maxLength="100"
										Height="17" onpaste="InhabilitarCopyPaste();"></asp:textbox></TD>
								<TD style="HEIGHT: 23px" align="right"><anthem:button id="btnCrear" runat="server" CssClass="Boton" Width="80px" Enabled="False" EnableViewState="True"
										EnabledDuringCallBack="False" CausesValidation="False" Text="Crear" PreCallBackFunction="ValidarCampos" Visible="False"></anthem:button></TD>
								<TD style="WIDTH: 86px; HEIGHT: 23px" align="right"><anthem:button id="btnAnexar" runat="server" CssClass="Boton" Width="80px" Enabled="False" EnableViewState="True"
										EnabledDuringCallBack="False" CausesValidation="False" Text="Anexar" PreCallBackFunction="ValidarCampos"></anthem:button></TD>
								<TD style="HEIGHT: 23px"></TD>
							</tr>
							<TR>
								<TD style="WIDTH: 7px; HEIGHT: 6px"></TD>
								<TD></TD>
								<TD style="WIDTH: 29px"></TD>
								<TD style="WIDTH: 331px"></TD>
								<TD style="WIDTH: 205px"></TD>
								<TD></TD>
								<TD></TD>
								<TD style="WIDTH: 6px"></TD>
							</TR>
						</TBODY>
					</table>
								</div>
							</td>
						</tr>
						<tr>
							<td style="HEIGHT: 6px"></td>
						</tr>
						<tr>
							<td>
								<div id="divGrilla" style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; OVERFLOW: auto; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid">
								<anthem:datagrid id="dgItemsDoc" runat="server" Width="100%" Height="19px" AutoGenerateColumns="False">
										<ItemStyle Height="25px" CssClass="Arial10b"></ItemStyle>
										<HeaderStyle CssClass="TablaTitulos"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Selecc.">
												<HeaderStyle HorizontalAlign="Center" Height="20px" Width="48px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderTemplate>
													Selecc.
												
</HeaderTemplate>
												<ItemTemplate>
													<INPUT id="chbxSeleccionar" style="TEXT-ALIGN: center" type="checkbox" name="chbxSeleccionar"
														runat="server">
												</ItemTemplate>
												<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Cerrar">
												<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderTemplate>
Cerrar 
</HeaderTemplate>
												<ItemTemplate>
													<anthem:ImageButton id="ibtnCerrar" runat="server" CausesValidation="False" PreCallBackFunction="ConfirmarCerrarAcuerdo"
														ImageUrl="../../../images/rechazar.gif" CommandName="cerrar" ToolTip="Haga click si desea Cerrar el Acuerdo"></anthem:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Editar">
												<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<anthem:ImageButton id="ibtnEditar" runat="server" EnabledDuringCallBack="False" CausesValidation="False"
														PreCallBackFunction="InicializarEditar" ToolTip="Haga click si desea editar el Acuerdo" CommandName="editar"
														ImageUrl="../../../images/btn_edit.jpg"></anthem:ImageButton>
													<INPUT id=hidID_DOCUMENTO_SEC type=hidden value='<%# DataBinder.Eval(Container.DataItem, "ID_DOCUMENTO_SEC")%>' name=hidID_DOCUMENTO_SEC runat="server">
													<INPUT id=hidCOD_SEC type=hidden value='<%# DataBinder.Eval(Container.DataItem, "COD_SEC")%>' name=hidCOD_SEC runat="server">
													<INPUT id=hidID_DOCUMENTO type=hidden value='<%# DataBinder.Eval(Container.DataItem, "ID_DOCUMENTO")%>' name=hidID_DOCUMENTO runat="server">
													<INPUT id=hidTIPO_CREACION type=hidden value='<%# DataBinder.Eval(Container.DataItem, "TIPO_CREACION")%>' name=hidTIPO_CREACION runat="server">
													<INPUT id=hidCOD_ESTADO type=hidden value='<%# DataBinder.Eval(Container.DataItem, "COD_ESTADO")%>' name=hidCOD_ESTADO runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="DESC_TIPO_DOCUMENTO" HeaderText="Tipo de Documento">
												<HeaderStyle Width="120px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESC_DOCUMENTO" HeaderText="Documento"></asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRE_GLOSA" HeaderText="Nombre de Glosa"></asp:BoundColumn>
											<asp:BoundColumn DataField="DESC_ESTADO" HeaderText="Estado">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESC_TIPO_CREACION" HeaderText="Tipo de Creaci&#243;n">
												<HeaderStyle Width="106px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FECHA_CREACION" HeaderText="Fecha Creaci&#243;n" DataFormatString="{0:dd/MM/yyyy}">
												<HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Ver">
												<HeaderStyle HorizontalAlign="Center" Width="36px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderTemplate>
Ver 
</HeaderTemplate>
												<ItemTemplate>
													<IMG id="imgVisualizar" name="imgVisualizar" title="Haga click si desea visualizar el Acuerdo"
														alt="Ver" style="CURSOR: hand" src="../../../images/botones/btn_VerArchivo.gif" border="0"
														runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</anthem:datagrid></div>
							</td>
						</tr>
						<tr>
							<td>
								<anthem:button id="btnEliminar" runat="server" CssClass="Boton" Width="95px" EnableViewState="False"
									TextDuringCallBack="Eliminando..." CausesValidation="False" Text="Eliminar" PreCallBackFunction="ConfirmarEliminarVarios"
									EnabledDuringCallBack="False"></anthem:button>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<TABLE id="tblRecibo" style="DISPLAY: none" cellSpacing="1" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD class="header" vAlign="middle" width="100%">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="120"><asp:label id="Label7" runat="server" CssClass="Arial10b" Width="120px">Registro de Recibos</asp:label></TD>
														<TD align="left"><INPUT class="BotonOptm" id="btnAgregarRecibo" style="WIDTH: 128px; CURSOR: hand; HEIGHT: 19px"
																onclick="iframeAgregarRecibo()" type="button" value="Agregar Recibos" name="btnAgregarRecibo">
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="contenido" colSpan="2"><IFRAME id="ifrRecibo" style="HEIGHT: 90px" name="ifrRecibo" frameBorder="no" width="100%"
													scrolling="yes"></IFRAME>
											</TD>
										</TR>
										<tr id="trBotones">
											<td align="left" colSpan="4"><INPUT class="Boton" id="btnGrabar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
													onclick="javascript:grabar();" onmouseout="this.className='Boton';" type="button" value="Grabar Recibos" name="btnGrabar">
												<input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="DISPLAY: none; WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
													onclick="javascript:cancelar();" onmouseout="this.className='Boton';" type="button"
													value="Cancelar" name="btnCancelar">
											</td>
										</tr>
									</TABLE>
								</div>
							</td>
						</tr>
						<tr>
							<td><div>
									<table id="tblBotonesOtros" style="WIDTH: 100%; HEIGHT: 50px" cellSpacing="0" cellPadding="0"
										border="0">
										<DIV></DIV>
										<tbody>
											<tr>
												<td style="WIDTH: 10%; HEIGHT: 24px" colSpan="2"></td>
												<td style="HEIGHT: 24px"></td>
												<td style="WIDTH: 200px; HEIGHT: 24px"></td>
												<TD style="WIDTH: 200px; HEIGHT: 24px" align="right"><input class="Boton" id="btnRetornar" style="DISPLAY: none" onclick="retonaSubsanacion();"
														type="button" value="Retornar a Subsanación" name="btnRetornar" runat="Server">
												</TD>
												<td style="WIDTH: 210px; HEIGHT: 24px" align="right">&nbsp;
													<anthem:button id="btnEnviar" runat="server" CssClass="Boton" Width="201px" EnableViewState="False"
														EnabledDuringCallBack="False" CausesValidation="False" Text="Enviar a Créditos"
														PreCallBackFunction="ConfirmarEnviarCreditosActivaciones" Visible="True"></anthem:button></td>
												<td align="right" style="WIDTH: 6px; HEIGHT: 24px"></td>
											</tr>
										</tbody>
									</table>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<input id="hidProceso" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidProceso"
									runat="server"> <input id="hidListaArchivos" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidListaArchivos"
									runat="server"><input id="hidMsg" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidMsg"
									runat="server"> <input id="hidAnexar" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidAnexar"
									runat="server"> <input id="hidVisible" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidVisible"
									runat="server"><input id="hidListaRecibo" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidListaRecibo"
									runat="server"><input id="hidNroFilas" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidNroFilas"
									runat="server"> <INPUT id="hidEstadoSEC_OBSERVADO" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
									name="hidEstadoSEC_OBSERVADO" runat="server"> <INPUT id="hidEstadoSEC_APROBADO" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
									name="hidEstadoSEC_APROBADO" runat="server"> <INPUT id="hidEstadoSEC_NUEVO" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
									name="hidEstadoSEC_NUEVO" runat="server"> <INPUT id="hidNroDG" type="hidden" size="1" name="hidNroDG" runat="server"><INPUT id="hidFlagEnvio" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagEnvio"
									runat="server"> <INPUT id="hidLoadFrame" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagEnvio"
									runat="server"> <INPUT id="hiListaArchivosLoad" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
									name="hiListaArchivosLoad" runat="server"><INPUT id="hidArchivosElim" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidArchivosElim"
									runat="server"> <INPUT id="hidRecibosElim" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidRecibosElim"
									runat="server"> <INPUT id="hidEnviado" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidEnviado"
									runat="server"> <INPUT id="hidTotalDocsAdjunta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
									name="hidTotalDocAdjunta" runat="server"> <INPUT id="hidFechaConsulta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidFechaConsulta"
									runat="server"> <INPUT id="hidEstadoSEC" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidEstadoSEC"
									runat="server">
							</td>
						</tr>
					</TBODY>
				</table>
			</DIV>
			<INPUT id="hidTipoDespacho" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="hidden" size="1" name="hidTipoDespacho" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
