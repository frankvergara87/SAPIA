<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_cargar_archivo_consumer.aspx.vb" Inherits="sisact_cargar_archivo_consumer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_consulta_evaluacion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="JavaScript" src="../../../librerias/lib_funcvalidacion.js"></script>
		<script language="javascript">	
		
		function f_ValidarEnter()
		{	
			if (document.all)
			{
				if (event.keyCode == 13)
				{	
					f_Buscar();	
					event.keyCode = 0;
				}
			}
		}
		
		top.window.moveTo(0,0);
		if (document.all) {
			top.window.resizeTo(screen.availWidth,screen.availHeight);
		}else if (document.layers||document.getElementById) {
			if (top.window.outerHeight<screen.availHeight||top.window.outerWidth<screen.availWidth){
				top.window.outerHeight = screen.availHeight;
				top.window.outerWidth = screen.availWidth;
			}
		}
			
		function cerrarVentana(){ 
							
			top.parent.window.close();	
		} 
		
		
		function f_Buscar()
		{	
			var strNroSEC = document.form1.txtCodSolicitud.value;			
			if(strNroSEC=='')
			{
				alert("Debe Ingresar el Nro de Evaluación")
				document.form1.txtCodSolicitud.focus();
				return false;
			}
			iframeValida.location.href =  "sisact_verifica_evaluacion_consumer.aspx?strCodSolicitud=" + strNroSEC;
		}
		
		function f_Enviar(strNroSEC,nroDocumento,razonSocial){
			ifrAdjuntar.location.href =  "sisact_cargar_archivo_solicitud_consumer.aspx?strCodSolicitud=" + strNroSEC + "&strNumeroDocumento=" + nroDocumento;			
		}


		function f_Limpiar(){
			location.href = "sisact_cargar_archivo_consumer.aspx?NumSolicitud=";
		}
		
		function f_ValidaIngreso(CaracteresPermitidos)   {
			var key = String.fromCharCode(window.event.keyCode)
			var valid = new String(CaracteresPermitidos)
			var ok = "no";
			for (var i=0; i<valid.length; i++) 
			{
				if (key == valid.substring(i,i+1))
					ok = "yes"        
			}
			if (ok == "no")
				window.event.keyCode=0
		}

		</script>
	</HEAD>
	<body>
		<form id="form1" method="post" runat="server" target="_top" onSubmit="return false;">
			<table cellSpacing="3" cellPadding="0" width="100%" border="0">
				<tr>
					<!--td class="header" align="center" colSpan="4" height="20">&nbsp;Activaciones</td-->
				</tr>
				<tr>
					<td>
						<table class="contenido" cellSpacing="2" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Arial12b">N° Evaluación:
									<asp:textbox id="txtCodSolicitud" runat="server" cssclass="clsInputEnable" onkeypress="f_ValidaIngreso('0123456789');"
										onkeydown="javascript:f_ValidarEnter();" ReadOnly="True"></asp:textbox>
									<INPUT class="Boton" id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="javascript:f_Buscar();" onmouseout="this.className='Boton';" type="button" style="DISPLAY:NONE" 
										value="Buscar" name="btnBuscar">&nbsp; <INPUT class="Boton" id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="javascript:f_Limpiar();" onmouseout="this.className='Boton';" type="button" value="Limpiar" name="btnLimpiar" style="DISPLAY:NONE" >
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<IFRAME id="ifrAdjuntar" src="" style="WIDTH: 100%; HEIGHT: 500px" name="ifrAdjuntar" frameBorder="no">
						</IFRAME>
					</td>
				</tr>
			</table>
			<iframe id="iframeValida" name="iframeValida" width="100" height="100" frameborder="0" framespacing="0">
			</iframe>
		</form>
	</body>
</HTML>
 
 
 
 
