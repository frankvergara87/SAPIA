<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_subirdocumento.aspx.vb" Inherits="sisact_subirdocumento" aspcompat="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>.::ANEXAR DOCUMENTOS::.</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<base target="_self">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		
				function InhabilitarTecla()
				{
					//KeyAscii = event.keyCode
					event.returnValue = false;
				}
				
				function retornarDatos(idRow, nombreDoc){
					
					window.returnValue = idRow + ',' + nombreDoc;
					window.close();
					//parent.document.actualizaHidDocumento(idRow,nombreDoc);
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
					var tblRecibo = document.getElementById('tblRecibo');
					tblRecibo.style.display = 'block';
					var idSEC =getValue('hidNumSec');
					//ifrRecibo.location.href = "../evaluacion_corp/sisact_recibo.aspx?IdSEC="+idSEC;	
					ifrRecibo.location.href = "sisact_recibo_acuerdo.aspx?IdSEC="+idSEC;	
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
					var total = 0;
					if (listaRecibos != null)
					{
						var i;
						var valor;
						
						
						listaRecibos = listaRecibos.replace(/<@Recibo@>/gi,"|");
						//alert(listaRecibos);
						
						var arrRecibos = listaRecibos.split('|');
						
						//---						
						if (arrRecibos.length > 0)
						{
							for (i=0;i<arrRecibos.length;i++)
							{
								valor = arrRecibos[i];
								
								if ((i%7 == 0) && (!isNaN(valor)))
								{
									if  (valor<0)
									{ //alert(valor);
									   total++;
									}   
								}
							}
						}
						
					}
					
					//---
					if (total <= 0)
					{
						alert('Tiene que ingresar por lo menos un nuevo recibo');
						return false
					}
					/*
					else if (total > 1)
					{
						alert('Ha ingresado '+ total ' recibos. Solo debe ingresar un solo recibo');
						return false					
					}
					*/
				
					
					//
					if (confirm('Se grabar\u00e1n los datos ingresados. ¿Desea continuar?')==false){
						return false;
					}
					setValue('hidProceso','grabar');
					setValue('hidAnexar','');
					
					document.frmAnexarDocumento.submit();
					
				}
				
				function retornoRecibo(listaRecibo,nroFilas){		
					setValue('hidListaRecibo',listaRecibo);
					setValue('hidNroFilas',nroFilas);			
				}
				
				function inicio()
				{
					var msg  = document.frmAnexarDocumento.hidMsg.value;
					
					if(msg!='')
					{
						alert(msg);
						mostrarFrameRecibo();
						//---si
						if (getValue('hidCerrar')=='1')
							CerrarVentanaDialog();
					}
				}
						
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="inicio();">
		<form id="frmAnexarDocumento" method="post" encType="multipart/form-data" runat="server">
			<DIV style="Z-INDEX: 102; LEFT: 4px; WIDTH: 608px; POSITION: absolute; TOP: 4px; HEIGHT: 140px"
				ms_positioning="GridLayout">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="header" style="HEIGHT: 20px">&nbsp;
							<asp:label id="lblOperacion" runat="server" BorderColor="Transparent" BackColor="Transparent"
								Height="2px" Width="440px">ANEXAR DOCUMENTO</asp:label></td>
					</tr>
					<tr>
						<td style="HEIGHT: 6px"></td>
					</tr>
					<!-- T12646 -->
					<tr id="trDatosSubsanar" style="DISPLAY: none" runat="server">
						<td>
							<table width="100%" class="contenido">
								<tr>
									<td colspan="4">
										<u>Datos de la SEC</u>
									</td>
								</tr>
								<tr>
									<td width="65">Nro. SEC:
									</td>
									<td width="120"><%= Request("NS") %></td>
									<td width="100">Nombre Glosa:
									</td>
									<td width="200"><%= Request("NG") %></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="HEIGHT: 63px">
							<table class="contenido" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td style="WIDTH: 6px"></td>
									<td style="WIDTH: 22%; HEIGHT: 22px">&nbsp;Nombre de Archivo:
									</td>
									<td style="WIDTH: 449px"><INPUT class="Boton" onkeypress="javascript:InhabilitarTecla();" id="filNombreArchivo"
											title="Seleccionar Archivo" style="WIDTH: 450px; HEIGHT: 22px; TEXT-ALIGN: left" type="file" size="54" name="filNombreArchivo"
											runat="server"></td>
									<td></td>
								</tr>
								<tr>
									<td style="WIDTH: 6px"></td>
									<td style="WIDTH: 150px" width="22%">&nbsp;</td>
									<td style="WIDTH: 449px">&nbsp;</td>
									<td>&nbsp;</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table id="tblBotonesOtros" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td width="5%">&nbsp;</td>
									<td width="5%">&nbsp;</td>
									<td align="right" width="40%"><anthem:button id="btnAnexar" runat="server" Width="95px" TextDuringCallBack="Anexando..." EnabledDuringCallBack="False"
											CssClass="Boton" Text="Anexar" CausesValidation="False"></anthem:button></td>
									<td align="left" width="100"><anthem:button id="btnCerrar" runat="server" Width="95px" CssClass="Boton" Text="Cerrar" CausesValidation="False"></anthem:button></td>
									<TD width="5%">&nbsp;</TD>
									<td width="5%">&nbsp; 
										<!-- T12646 -->
										<input type="hidden" name="hidIdDocumentoSEC" id="hidIdDocumentoSEC" runat="server">
										<input type="hidden" name="hidIdRow" id="hidIdRow" runat="server"> <input type="hidden" name="hidNumSec" id="hidNumSec" runat="server">
									</td>
								</tr>
								<TR>
									<TD colSpan="6"></TD>
								</TR>
								<TR>
									<TD colSpan="6">
										<TABLE id="tblRecibo" style="DISPLAY:none" cellSpacing="1" cellPadding="0" width="100%"
											border="0">
											<TR>
												<TD class="header" width="100%" vAlign="middle">
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
												<TD class="contenido" colSpan="2"><IFRAME id="ifrRecibo" style="HEIGHT: 100px" name="ifrRecibo" frameBorder="no" scrolling="yes"
														width="100%"></IFRAME>
												</TD>
											</TR>
											<tr id="trBotones">
												<td align="center" colSpan="4"><INPUT class="Boton" id="btnGrabar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
														onclick="javascript:grabar();" onmouseout="this.className='Boton';" type="button" value="Grabar" name="btnGrabar">
													<input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="DISPLAY: none; WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
														onclick="javascript:cancelar();" onmouseout="this.className='Boton';" type="button"
														value="Cancelar" name="btnCancelar"><input id="hidProceso" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidProceso"
														runat="server"> <input id="hidListaArchivos" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidListaArchivos"
														runat="server"><input id="hidMsg" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidMsg"
														runat="server"> <input id="hidAnexar" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidAnexar"
														runat="server"> <input id="hidVisible" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidVisible"
														runat="server"><input id="hidListaRecibo" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidListaRecibo"
														runat="server"><input id="hidNroFilas" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidNroFilas"
														runat="server"> <INPUT id="Hidden1" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidEstadoSEC"
														runat="server"> <INPUT id="hidEstadoSEC_OBSERVADO" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
														name="hidEstadoSEC_OBSERVADO" runat="server"> <INPUT id="hidEstadoSEC_APROBADO" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
														name="hidEstadoSEC_APROBADO" runat="server"> <INPUT id="hidEstadoSEC_NUEVO" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
														name="hidEstadoSEC_NUEVO" runat="server"> <INPUT id="hidNroDG" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidNroDG"
														runat="server"><INPUT id="hidFlagEnvio" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagEnvio"
														runat="server"> <INPUT id="hidLoadFrame" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagEnvio"
														runat="server"> <INPUT id="hiListaArchivosLoad" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1"
														name="hiListaArchivosLoad" runat="server"><INPUT id="hidArchivosElim" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidArchivosElim"
														runat="server"> <INPUT id="hidRecibosElim" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidRecibosElim"
														runat="server"> <INPUT id="hidtamanioMax" style="WIDTH: 8px; HEIGHT: 2px" type="hidden" size="1" name="hidtamanioMax"
														runat="server"><INPUT id="hidtamanioMin" style="WIDTH: 8px; HEIGHT: 2px" type="hidden" size="1" name="hidtamanioMin"
														runat="server"> <INPUT id="hidCerrar" style="WIDTH: 8px; HEIGHT: 2px" type="hidden" size="1" name="hidCerrar"
														runat="server">
												</td>
											</tr>
										</TABLE>
									</TD>
								</TR>
							</table>
						</td>
					</tr>
				</table>
			</DIV>
		</form>
	</body>
</HTML>
 
 
 
 
