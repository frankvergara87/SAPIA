<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Inicio.aspx.vb" Inherits="Inicio"%>
<%@ Register TagPrefix="uc1" TagName="ctr_Menu" Src="controles/ctr_Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SISACT</title>
		<link href="estilos/general.css" rel="styleSheet" type="text/css">
			<script language="javascript">

	var message="";

	function clickIE()
	{
		if (document.all)
		{
			(message);
			return false;
		}
	}

	if (document.layers)
	{
		document.captureEvents(Event.MOUSEDOWN);
	}
	else
	{
		document.oncontextmenu=clickIE;
	}

    document.oncontextmenu=new Function("return false")
	
	function cambiarAltura(){
		var altura = '';
		var h = 540;
		altura = h +"px";	
		document.getElementById("iframeBody").style.height = altura;
	}
			</script>
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="frmPrincipal" method="post" runat="server">
			<table height="100%" width="100%" border="0" style="LEFT: 0px; POSITION: absolute; TOP: 0px">
				<tr>
					<td height="58">
						<iframe name="iframeTop" src="Include/Top.aspx" id="iframeTop" frameborder="0" marginheight="0"
							width="1016" height="100%" noResize scrolling="no"></iframe>
					</td>
				</tr>
				<tr>
					<td height="12">
						<uc1:ctr_Menu id="Ctr_Menu1" runat="server"></uc1:ctr_Menu>
					</td>
				</tr>
				<tr>
					<td height="*" valign="top">
						<iframe name="iframeBody" src="blank.htm" id="iframeBody" frameborder="0" marginheight="0"
							width="1005" height="610" marginwidth="0" scrolling="yes" valign="top"></iframe>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
