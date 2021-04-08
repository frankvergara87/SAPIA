<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Index.aspx.vb" Inherits="Index"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>SISACT - Sistema de Activaciones</TITLE>
		<script language='javascript' src='script/funciones_sec.js'></script>
		<script language="javascript">
	//validarUrl();

	function cambiarAltura(){
		var altura = '';
		var h = 600;
		altura = h +"px";	
		document.getElementById("iframeBody").style.height = altura;
	}
		</script>
	</HEAD>
	<frameset framespacing="0" rows="*" border="0" frameborder="0">
		<frame name="main" scrolling="no" src="Acceso.aspx">
	</frameset>
</HTML>
 
 
 
 
