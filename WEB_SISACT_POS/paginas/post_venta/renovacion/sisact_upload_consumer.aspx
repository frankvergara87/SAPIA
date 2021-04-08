<%@ Page Language="vb" AspCompat="true" AutoEventWireup="false" Codebehind="sisact_upload_consumer.aspx.vb" Inherits="sisact_upload_consumer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SISACT - Carga de Archivos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Styles/sigec_GEN_BasePaginas.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Styles/siseg_GEN_BaseTablas.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="JavaScript" src="../../../librerias/lib_funcvalidacion.js"></script>
		<script language="javascript">
			
			function checkNombre(nombre) {
				var n = "";
				var aFile = nombre.split('\\');
				n = aFile[aFile.length-1];
				//CARACTERES VALIDOS
				var validos = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789._- ';
				var resultado = true;				
				for (var i = 0; i < n.length; i++){
					var c = n.substr(i,1);
					var existe = validos.indexOf(c);					
					if (existe<0){
						resultado = false;
						break;
					}
				}
				if (resultado == false) {
					alert("El nombre del archivo contiene CARACTERES NO PERMITIDOS." );
					return false;
				}
				return true;
			}       
					
				
			function EnviarDatos(){				
                var nombreArchivo = document.frmPrincipal.txtFile.value;
				if (nombreArchivo != ""){
					if (checkNombre(nombreArchivo) ==false){
						return false;
					} 
					else
					{
						setValue('hidAccion','grabar');
						document.frmPrincipal.action="sisact_upload_consumer.aspx?cu=" + getValue('hidUsuarioExt') + "&Action=1";
						document.frmPrincipal.submit();
					}
				}
				else{
					alert("Debe Ingresar una Ruta de Archivo valida");
					return false;
				}
			}
			
			function Cancelar(){
				//var nombre = getValue(' ');
				//window.opener.ifrArchivos.location.href = "sisact_ListadoArchivosAdjuntos.aspx?listaArchivos="+nombre;
				window.close();
				setValue('hidAccion','');
			}

		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="frmPrincipal" name="frmPrincipal" method="post" encType="multipart/form-data"
			runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" align="left" border="0">
				<tr>
					<td vAlign="top" align="left">
						<table>
							<tr>
								<td><input class="Boton" id="txtFile" style="WIDTH: 350px; HEIGHT: 22px" type="file" size="58"
										name="txtFile" runat="server">
								</td>
							<tr>
							<TR>
								<TD align="left"><label class="Arial10b" style="COLOR: #ff0000">CARACTERES INVALIDOS:&lt;&gt;()=?¿¡+{}[]*&amp;%Ññ'|°" (acentos)</label>
								</TD>
							</TR>
							<tr>
								<td align="center"><input class="Boton" onclick="javascript:EnviarDatos()" type="button" value="Aceptar" name="cmdAceptar">
									<input class="Boton" onclick="javascript:Cancelar()" type="button" value="Cancelar" name="cmdCancelar">
								</td>
							</tr>
							<tr>
								<td><INPUT id="hidNombreArchivo" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidNombreArchivo"
										runat="server"><INPUT id="hidFlag" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidFlag"
										runat="server"><INPUT id="hidAccion" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidAccion"
										runat="server"> <INPUT id="hidLista" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidLista"
										runat="server"> <INPUT id="hidMsg" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidMsg"
										runat="server"> <INPUT id="hidFl" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidFl"
										runat="server"> <INPUT id="hidtamanioMax" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidtamanioMax"
										runat="server"> <INPUT id="hidtamanioMin" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidtamanioMin"
										runat="server"> <INPUT id="hidUsuarioExt" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidUsuarioExt"
										runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
