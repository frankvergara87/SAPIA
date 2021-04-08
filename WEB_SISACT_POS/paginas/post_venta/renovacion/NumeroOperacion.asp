<% @ language="vbscript" %>
<% Option Explicit %>

<!-- #include file="../../include/INF_Funciones.asp" -->
<!-- #include file="../../include/Constantes_site.asp" -->

	<script language="javascript" src="../../../script/funciones_sec.js"></script>
	<script language="javascript" type="text/javascript">
		validarUrl();
	</script>
<%
Session("CodUsuarioSisact") = Request("CodUsuarioSisact")
If isnull(Session("CodUsuarioSisact")) or Session("CodUsuarioSisact") = "" Then
	Response.Redirect(strRutaSite)
End if

'NUMERO OPERACION ORIGEN
Dim NumOpe
DIm objNumOpe,NUMEROOPERACIONORIGEN

'Set objNumOpe = Server.CreateObject("COM_PVU_INF_Dbo.clsInstitucion")
'Numope = objNumOpe.FP_NumeroOperacion("INFOCORP")
'NumOpe=Format(now(), "yyyyMMddhhmmss")
NumOpe=cstr(year(now()) & month(now()) & day(now()) & hour(now()) & minute(now()) & second(now()))
If NumOpe <> "" Then
	NUMEROOPERACIONORIGEN = NumOpe
%>
	<script language="javascript">
		self.parent.f_ByPass_DataCredito_Equifax("<%=NUMEROOPERACIONORIGEN%>");
	</script>
<%
Else
	NUMEROOPERACIONORIGEN = 0
%>
	<script language="javascript">
		self.parent.document.frmPrincipal.txtClientenuevo.value = "";
	</script>
<%
Response.End
End If
%> 
 
