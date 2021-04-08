<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ListadoArchivosAdjuntos.aspx.vb" Inherits="sisact_ListadoArchivosAdjuntos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_ListadoArchivosAdjuntos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="JavaScript" src="../../../librerias/lib_funcvalidacion.js"></script>
		<script language="JavaScript">
			function eliminarArchivo(codigo){
				if (confirm('¿Esta seguro de eliminar este elemento?')==false)
					return;
				//alert(codigo);
				setValue('hidProceso','E');
				setValue('hidId',codigo);
				document.Form1.submit();
			
			}
			function cargarGrid(valor){
				if (getValue('hidflag')==""){
					setValue('hidflag','1');
					setValue('hidProceso','I')
					document.Form1.submit();
				}
				
			}
			function inicio(){				
				if (getValue('hidflag')==""){
					setValue('hidLista',self.parent.retornarLista());
					setValue('hidLisArchiElim',self.parent.retornarListaEli());//OGV!
					
					/*var val1 =getValue('hidLisArchiElim');
					alert(getValue('hidLisArchiElim') + '' + 'if');*/									
					cargarGrid(getValue("hidflag"));
					//alert('primera vez');					
				}else{
					//alert("esta pppp:"+getValue('hidLista'));
					self.parent.cargarLista(getValue('hidLista'));
					self.parent.cargarListaEli(getValue('hidLisArchiElim'));//OGV!					
					//alert(getValue('hidLisArchiElim')+ ' '+ 'else');
				}
				
			}
			
		</script>
	</HEAD>
	<body onload="javascript:inicio();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 1px" cellSpacing="0" cellPadding="0"
				width="102%" border="0">
				<tr>
					<td vAlign="top"><asp:datagrid id="dgLista" runat="server" AutoGenerateColumns="FALSE" ShowHeader="false">
							<Columns>
								<asp:TemplateColumn HeaderText="">
									<HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" width="25px"></ItemStyle>
									<ItemTemplate>
										<A href='javascript:eliminarArchivo("<%# abrirArchivo(DataBinder.Eval(Container.DataItem, "Codigo"))%>");'>
											<IMG alt="Eliminar Fila" src="../../../images/close.gif" border="0"></A> <INPUT id="hidIdArchivo" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidIdArchivo"
												runat="server" value='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>'>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="">
									<HeaderStyle HorizontalAlign="Center" Wrap="true" CssClass="TablaTitulos"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" width="100%"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblNomArchivo" runat="server" CssClass="Arial10b" Text='<%# DataBinder.Eval(Container.DataItem, "Descripcion")%>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="estado" HeaderText="estado" Visible="False">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td><INPUT id="hidLista" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidLista"
							runat="server"> <INPUT id="hidProceso" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidProceso"
							runat="server"> <INPUT id="hidId" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidId"
							runat="server"> <INPUT id="hidflag" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidflag"
							runat="server"><INPUT id="hidLisArchiElim" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidLisArchiElim"
							runat="server">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
