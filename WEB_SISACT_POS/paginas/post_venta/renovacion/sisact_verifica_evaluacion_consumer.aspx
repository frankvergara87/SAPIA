<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_verifica_evaluacion_consumer.aspx.vb" Inherits="sisact_verifica_evaluacion_consumer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_verifica_evaluacion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<input type="hidden" name="hidCodSolicitud" id="hidCodSolicitud" runat="server">
			<input type="hidden" name="hidCodEstado" id="hidCodEstado" runat="server"> <input type="hidden" name="hidFlagTerminado" id="hidFlagTerminado" runat="server">
			<input type="hidden" name="hidCodTipoEvaluacion" id="hidCodTipoEvaluacion" runat="server" >
			<input type="hidden" name="hidNumeroDocumento" id="hidNumeroDocumento" runat="server">
			<input type="hidden" name="hidRazonSocial" id="hidRazonSocial" runat="server"> <input type="hidden" name="hidFlagPermiteIngresar" id="hidFlagPermiteIngresar" runat="server">
			<script language="javascript">
				var blFlag = true;
				if(document.frmPrincipal.hidCodSolicitud.value =="")
				{
					parent.alert("El Nro de Evaluación Ingresado No Existe");
					blFlag = false;
				}
				else
				{			
					//if(document.frmPrincipal.hidCodTipoEvaluacion.value != "<%=constCodEvaluacionConsumer%>")
					//{
					//	parent.alert("El Nro de Evaluación no pertenece a un Cliente Consumer");		
					//	blFlag = false;
					//}else{	
						var nroSEC= document.frmPrincipal.hidCodSolicitud.value; 
						if (document.frmPrincipal.hidFlagPermiteIngresar.value == 'N'){
							parent.alert("La Solicitud Nº " + nroSEC +" fue rechazada por no adjuntar Sustento de ingreso");	
							blFlag = false;
						}else {
							if (document.frmPrincipal.hidFlagTerminado.value == 'S'){
								parent.alert("Ya se realizó anteriormente la carga de archivos para la Evaluación"); 
								blFlag = false;
							}		
						}
					//}
				}
				if (blFlag)
				{
					parent.f_Enviar(document.frmPrincipal.hidCodSolicitud.value,document.frmPrincipal.hidNumeroDocumento.value,document.frmPrincipal.hidRazonSocial.value);
				}
			</script>
		</form>
	</body>
</HTML>
 
 
 
 
