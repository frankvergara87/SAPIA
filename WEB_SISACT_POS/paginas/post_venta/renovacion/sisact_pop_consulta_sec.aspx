<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_consulta_sec.aspx.vb" Inherits="sisact_pop_consulta_sec"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Consulta - SEC</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
		
			//DNI   CIP   CFA   CE    RUC   PASP
			var arrayTipoDocPVU = ['01', '02', '03', '04', '06', '07'];
			var arrayTamaDocPVU = [ 8  ,  15 ,  15 ,  9 ,  11 ,  15 ];
		
			function asignarFila(nroSEC, strNombres, strApePaterno, strApeMaterno)
			{
				document.getElementById('hidNroSEC').value = nroSEC;
				document.getElementById('txtApePat').value = strApePaterno;
				document.getElementById('txtApeMat').value = strApeMaterno;
				document.getElementById('txtNombre').value = strNombres;
			}
			
			function aceptar()
			{
				var nroSEC = document.getElementById('hidNroSEC').value;			
				if (nroSEC =='' )
				{
					alert('Debe selecionar una evaluación');
					return false;
				}

				window.opener.document.getElementById('hidNroSEC').value = nroSEC;
				window.opener.document.getElementById('txtApePat').value = document.getElementById('txtApePat').value;
				window.opener.document.getElementById('txtApeMat').value = document.getElementById('txtApeMat').value;
				window.opener.document.getElementById('txtNombre').value = document.getElementById('txtNombre').value;									
				window.opener.retornarConsultaSEC(nroSEC);
				window.close();			
			}
			
			function cerrarVentana()
			{
				window.opener.nuevaEvaluacion();
				window.close();
			}
			
			function inicio()
			{
				for (var num=0; num <= document.frmPrincipal.length-1; num++) 
				{
					if (document.frmPrincipal.elements[num].name == "rbtSEC") 
					{
						if (document.frmPrincipal.elements[num].disabled) 
						{
							alert("El cliente tiene una SEC que ha sido utilizada en una venta, no se puede generar una nueva SEC");
							document.getElementById('btnAceptar').disabled = true;
							break;
						}  
					}
				}
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
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<input type="hidden" id="hidNroSEC" name="hidNroSEC" style="WIDTH:1px;HEIGHT:1px">
			<input type="hidden" id="txtApePat" name="txtApePat" style="WIDTH:1px;HEIGHT:1px">
			<input type="hidden" id="txtApeMat" name="txtApeMat" style="WIDTH:1px;HEIGHT:1px">
			<input type="hidden" id="txtNombre" name="txtNombre" style="WIDTH:1px;HEIGHT:1px">
			<table width="100%" cellpadding="0" cellspacing="2" border="0" align="center">
				<tr>
					<td>
						<table width="100%" align="center" cellspacing="0" cellpadding="0">
							<tr>
								<td>
									<div id="lista" style="WIDTH: 1100px; OVERFLOW: auto">
										<asp:datagrid id="dgLista" runat="server" AutoGenerateColumns="False" Height="64px" EnableViewState="False">
											<AlternatingItemStyle HorizontalAlign="Center" Height="15px" CssClass="Arial10"></AlternatingItemStyle>
											<ItemStyle HorizontalAlign="Center" Height="15px" CssClass="Arial10"></ItemStyle>
											<HeaderStyle CssClass="TablaTitulos"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="Sel">
													<ItemTemplate>
														<input type="radio" id="rbtSEC" name="rbtSEC" onclick="javascript:asignarFila('<%# DataBinder.Eval(Container.DataItem, "SOLIN_CODIGO")%>','<%# DataBinder.Eval(Container.DataItem, "CLIEV_NOMBRE")%>','<%# DataBinder.Eval(Container.DataItem, "CLIEV_APE_PAT")%>','<%# DataBinder.Eval(Container.DataItem, "CLIEV_APE_MAT")%>');">
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="SOLIN_CODIGO" HeaderText="Nro SEC">
													<HeaderStyle HorizontalAlign="Center" Height="25px" Width="100px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ESTAV_DESCRIPCION" HeaderText="Estado">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Nro Documento">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Center" CssClass="Arial10B" Width="100px"></ItemStyle>
														<ItemTemplate>
															<script language='javascript'> document.write(showNroDoc('<%# DataBinder.Eval(Container.DataItem, "CLIEC_NUM_DOC") %>', '<%# DataBinder.Eval(Container.DataItem, "TDOCC_CODIGO") %>') + "&nbsp;"); </script>
														</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="CLIEV_RAZ_SOC" HeaderText="Nombre / Raz&#243;n Social">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="400px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="OVENV_DESCRIPCION" HeaderText="Oficina Venta">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="300px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="SOLID_FEC_REG" HeaderText="Fecha Registro">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TCARV_DESCRIPCION" HeaderText="Tipo Garantia">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="SOLIN_IMP_DG" HeaderText="Importe">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ESTADODES" HeaderText="Estado de Venta">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class="fila_consulta">
					<td height="25" colspan="14" align="left">
						<asp:label ID="lblFilas" CssClass="Arial10BRed" Runat="server"></asp:label>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%" align="center" cellspacing="0" cellpadding="4" class="contenido" ID="Table1">
							<tr>
								<td align="center">
									<input name="btnAceptar" id="btnAceptar" type="button" class="BotonOptm" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='BotonOptm';" style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand"
										onClick="javascript:aceptar();" onkeypress="javascript:aceptar();" value="Aceptar"
										tabindex="123">&nbsp;&nbsp; <input name="btnAceptar" id="btnCancelar" type="button" class="BotonOptm" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='BotonOptm';" style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand" onClick="javascript:cerrarVentana();"
										value="Cancelar" tabindex="123">&nbsp;&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
