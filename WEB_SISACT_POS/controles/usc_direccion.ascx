<meta name="vs_showGrid" content="True">
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="usc_direccion.ascx.vb" Inherits="usc_direccion" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK rel="stylesheet" type="text/css" href="../estilos/general.css">
<script language="javascript">	
	var K_CANTIDAD_DIRECCION = 40;	
	function eventoSoloNumerosEnteros(){
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
</script>
<TABLE id="tblDireccion" border="0" cellSpacing="0" cellPadding="0" width="800">
	<TR>
		<TD><asp:label id="lbltitulodireccion" CssClass="Arial10b" runat="server">Titulo Dirección</asp:label></TD>
	</TR>
	<TR>
		<TD>
			<TABLE style="TABLE-LAYOUT: fixed" border="0" cellSpacing="0" cellPadding="1" width="800">
				<colgroup>
					<col width="135">
					<col width="130">
					<col width="60">
					<col width="10">
					<col width="45">
					<col width="120">
					<col width="60">
					<col width="60">
					<col width="135">
					<col width="60">
					<col width="60">
				</colgroup>
				<TR>
					<TD><asp:label id="Label29" CssClass="Arial10b" runat="server">&nbsp;Av/Calle/Jr</asp:label></TD>
					<TD style="WIDTH: 142px" noWrap align="left"><asp:label id="Label26" CssClass="Arial10b" runat="server">Nombre de la Via (Av/Calle/Jr)</asp:label></TD>
					<TD align="left"><asp:label id="Label19" CssClass="Arial10b" runat="server">Número</asp:label></TD>
					<TD></TD>
					<TD><LABEL style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: red; FONT-FAMILY: Arial"></LABEL></TD>
					<TD style="WIDTH: 79px" align="center"><asp:label id="Label47" CssClass="Arial10b" runat="server">Mz/Bloq/Edif</asp:label></TD>
					<TD noWrap align="center"><asp:label id="Label20" CssClass="Arial10b" runat="server">Nro Mz/Bq</asp:label></TD>
					<TD align="center"><asp:label id="Label21" CssClass="Arial10b" runat="server">Lote</asp:label></TD>
					<TD align="center"><asp:label id="Label23" CssClass="Arial10b" runat="server">Tipo Dpto/int</asp:label></TD>
					<TD align="left"><asp:label id="Label25" CssClass="Arial10b" runat="server">Número</asp:label></TD>
					<TD align="center"><asp:label id="Label50" CssClass="Arial10b" runat="server" Visible="True">Contador</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:dropdownlist id="ddlPrefijo" CssClass="clsSelectEnable0" runat="server" Width="120px" onChange="onchange_prefijo(this);"></asp:dropdownlist></TD>
					<TD><asp:textbox onblur="onkeyup_direccion(this,'ddlPrefijo','D')" onkeydown="onkeyup_direccion(this,'ddlPrefijo','D')"
							id="txtDireccion" onkeyup="onkeyup_direccion(this,'ddlPrefijo','D')" CssClass="clsInputDisable"
							runat="server" Width="110px" MaxLength="25" ReadOnly="True"></asp:textbox></TD>
					<TD><asp:textbox onblur="onkeyup_NroPuerta(this)" id="txtNroPuerta" onkeypress="eventoSoloNumerosEnteros();"
							onkeyup="onkeyup_NroPuerta(this);" CssClass="clsInputDisable" runat="server" Width="52px"
							MaxLength="5" ReadOnly="True"></asp:textbox></TD>
					<TD></TD>
					<TD>
						<div disabled id="divSinNumero" runat="server"><asp:checkbox id="chkSinNumero" onclick="sinNumero(this)" CssClass="Arial10b" runat="server" TextAlign="Left"
								Text="S/N"></asp:checkbox></div>
					</TD>
					<TD><asp:dropdownlist id="ddlEdificacion" CssClass="clsSelectEnable0" runat="server" onchange="onchange_edificacion(this)"
							Width="110px" disabled></asp:dropdownlist></TD>
					<TD><asp:textbox onblur="onkeyup_mz_lote(this,'D')" onkeydown="onkeyup_mz_lote(this,'D')" id="txtManzana"
							onkeyup="onkeyup_mz_lote(this,'D')" CssClass="clsInputDisable" runat="server" Width="52px"
							MaxLength="5" ReadOnly="True"></asp:textbox></TD>
					<TD><asp:textbox onblur="onkeyup_mz_lote(this,'D')" id="txtLote" onkeyup="onkeyup_mz_lote(this,'D')"
							CssClass="clsInputDisable" runat="server" Width="52px" MaxLength="5" ReadOnly="True"></asp:textbox></TD>
					<TD><asp:dropdownlist id="ddlTipoInterior" CssClass="clsSelectEnable0" runat="server" onchange="onchange_interior(this);"
							Width="120px"></asp:dropdownlist></TD>
					<TD><asp:textbox onblur="onkeyup_mz_lote(this,'D')" id="txtNroInterior" onkeypress="eventoSoloNumerosEnteros();"
							onkeyup="onkeyup_mz_lote(this,'D')" CssClass="clsInputDisable" runat="server" Width="52px"
							MaxLength="5" ReadOnly="True"></asp:textbox></TD>
					<TD align="center"><asp:label id="lblContadorDireccion" CssClass="Arial10b" runat="server" Visible="True" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:label id="Label45" CssClass="Arial10b" runat="server">&nbsp;Tipo y Nombre Urbanización</asp:label></TD>
					<TD noWrap></TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:label id="Label48" CssClass="Arial10b" runat="server">Zona/Etapa</asp:label></TD>
					<TD colSpan="2"><asp:label id="Label49" CssClass="Arial10b" runat="server">Nombre Zona/Etapa</asp:label></TD>
					<TD align="center"><asp:label id="Label24" CssClass="Arial10b" runat="server">&nbsp;Referencia</asp:label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 153px"><asp:dropdownlist id="ddlUrbanizacion" CssClass="clsSelectEnable0" runat="server" onchange="onchange_urbanizacion(this);"
							Width="120px"></asp:dropdownlist></TD>
					<TD style="WIDTH: 142px"><asp:textbox onblur="onkeyup_mz_lote(this,'R')" id="txtUrbanizacion" onkeyup="onkeyup_mz_lote(this,'R')"
							CssClass="clsInputDisable" runat="server" Width="110px" MaxLength="40" ReadOnly="True"></asp:textbox></TD>
					<TD noWrap></TD>
					<TD style="WIDTH: 32px"></TD>
					<TD></TD>
					<TD style="WIDTH: 79px" align="center"><asp:dropdownlist id="ddlZona" CssClass="clsSelectEnable0" runat="server" onchange="onchange_zona(this)"
							Width="110px"></asp:dropdownlist></TD>
					<TD colSpan="2"><asp:textbox onblur="onkeyup_mz_lote(this,'R')" id="txtNombreZona" onkeyup="onkeyup_mz_lote(this,'R')"
							CssClass="clsInputDisable" runat="server" Width="110px" MaxLength="40" ReadOnly="True"></asp:textbox></TD>
					<TD><asp:textbox onblur="onkeyup_mz_lote(this,'R')" id="txtReferencia" onkeyup="onkeyup_mz_lote(this,'R')"
							CssClass="clsInputEnable" runat="server" Width="128px" MaxLength="38"></asp:textbox></TD>
					<TD></TD>
					<TD><asp:label id="lblContadorReferencia" CssClass="Arial10b" runat="server" Visible="True" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 153px"></TD>
					<TD style="WIDTH: 142px"></TD>
					<TD noWrap></TD>
					<TD style="WIDTH: 32px"></TD>
					<TD></TD>
					<TD style="WIDTH: 79px" align="center"></TD>
					<TD colSpan="5"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 153px" class="Arial10b">Departamento</TD>
					<TD style="WIDTH: 142px"><STRONG><FONT color="#000080" size="2" face="Arial10b"><asp:label id="Label1" CssClass="Arial10b" runat="server">Provincia</asp:label></FONT></STRONG></TD>
					<TD noWrap><STRONG><FONT color="#000080" size="2" face="Arial"></FONT></STRONG></TD>
					<TD style="WIDTH: 32px"></TD>
					<TD></TD>
					<TD style="WIDTH: 79px" align="center"><STRONG><FONT color="#000080" size="2" face="Arial10b"><asp:label id="Label2" CssClass="Arial10b" runat="server">Distrito</asp:label></FONT></STRONG></TD>
					<TD colSpan="2"><STRONG><FONT color="#000080" size="2" face="Arial10b"><asp:label id="Label3" CssClass="Arial10b" runat="server">Cod. Postal</asp:label></FONT></STRONG></TD>
					<TD>
						<asp:label id="Label4" runat="server" CssClass="Arial10b">Ubigeo</asp:label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 153px"><asp:dropdownlist id="ddlDepartamento" CssClass="clsSelectEnable0" runat="server" onchange="mostrarProvincia(this);"
							Width="120px"></asp:dropdownlist></TD>
					<TD style="WIDTH: 142px"><asp:dropdownlist id="ddlProvincia" CssClass="clsSelectEnable0" runat="server" onchange="mostrarDistrito(this);"
							Width="120px"></asp:dropdownlist></TD>
					<TD noWrap></TD>
					<TD style="WIDTH: 32px"></TD>
					<TD></TD>
					<TD style="WIDTH: 79px" align="center"><asp:dropdownlist id="ddlDistrito" CssClass="clsSelectEnable0" runat="server" onchange="mostrarCodigoPostal(this); mostrarUbigeo(this);"
							Width="110px"></asp:dropdownlist></TD>
					<TD colSpan="2"><asp:textbox id="txtCodigoPostal" CssClass="clsInputDisable" runat="server" Width="110px" ReadOnly="True"></asp:textbox></TD>
					<TD>
						<asp:textbox id="txtUbigeo" runat="server" CssClass="clsInputDisable" Width="110px" ReadOnly="True"></asp:textbox>
					</TD>
					<TD colSpan="2"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 153px">
						<asp:label id="lblTelfRef" runat="server" CssClass="Arial10b">Telf. Referencia</asp:label></TD>
					<TD style="WIDTH: 142px"></TD>
					<TD noWrap></TD>
					<TD style="WIDTH: 32px"></TD>
					<TD></TD>
					<TD style="WIDTH: 79px" align="center"></TD>
					<TD colSpan="2"></TD>
					<TD></TD>
					<TD colSpan="2"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 153px">
						<TABLE id="Table1" border="0">
							<TR>
								<TD>
									<asp:textbox id="txtPrefijoTelefonoReferencia" onkeypress="eventoSoloNumerosEnteros();" runat="server"
										CssClass="clsInputEnable" Width="25px" MaxLength="3"></asp:textbox>&nbsp;-
								</TD>
								<TD>
									<asp:textbox id="txtTelefonoReferencia" onkeypress="eventoSoloNumerosEnteros();" runat="server"
										CssClass="clsInputEnable" Width="80px" MaxLength="7"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="WIDTH: 142px">
						<asp:label id="Label10" runat="server" CssClass="Arial10b" Visible="False">Ej.01-6131000</asp:label></TD>
					<TD noWrap></TD>
					<TD style="WIDTH: 32px"></TD>
					<TD></TD>
					<TD style="WIDTH: 79px" align="center"></TD>
					<TD colSpan="2"></TD>
					<TD></TD>
					<TD colSpan="2"></TD>
					<TD></TD>
				</TR>
				<TR id="filaEmpleador" runat="server">
					<TD style="WIDTH: 153px" class="Arial10b">Ruc&nbsp;del Empleador</TD>
					<TD style="WIDTH: 142px"><INPUT id="txtRUCEmpleador" class="clsInputEnable" onkeypress="eventoSoloNumerosEnteros();"
							maxLength="11" name="txtRUCEmpleador" runat="server" tabindex_1="40"></TD>
					<TD noWrap></TD>
					<TD style="WIDTH: 32px"></TD>
					<TD></TD>
					<TD style="WIDTH: 79px" align="center"></TD>
					<TD class="Arial10b" colSpan="2">Nombre Empresa</TD>
					<TD colSpan="3"><INPUT style="WIDTH: 240px; HEIGHT: 17px" id="txtNombreEmpresa" class="clsInputEnable"
							maxLength="40" size="34" name="txtNombreEmpresa" runat="server" tabindex_1="46"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<tr>
		<td align="center"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidProvincias" size="1" type="hidden" name="hidProvincias"
				runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidDistritos" size="1" type="hidden" name="hidDistritos"
				runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidListaCodigoPostal" size="1" type="hidden"
				name="hidListaCodigoPostal" runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidDptoDefault" size="1" type="hidden" name="hidDptoDefault"
				runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidProvinciaDefault" size="1" type="hidden"
				name="hidProvinciaDefault" runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidDistritoDefault" size="1" type="hidden"
				name="hidDistritoDefault" runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidDptoId" size="1" type="hidden" name="hidDptoId"
				runat="server"> <INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidDistritoId" size="1" type="hidden" name="hidDistritoId"
				runat="server"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidProvinciaId" size="1" type="hidden" name="hidProvinciaId"
				runat="server"> <INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidSinNumero" size="1" type="hidden" name="hidSinNumero"
				runat="server"> <INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidShowRUC" size="1" type="hidden" name="hidShowRUC"
				runat="server"> <input style="WIDTH: 8px; HEIGHT: 22px" id="hidListUbigeo" name="hidListUbigeo" size="1"
				type="hidden" runat="server">
		</td>
	</tr>
</TABLE>
