<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_matrizdocumentos.aspx.vb" Inherits="sisact_matrizdocumentos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MATRIZ DE DOCUMENTOS POR TIPO DE EMPRESA</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../estilos/estilo_acuerdos_corp.css" type="text/css" rel="stylesheet">
		<LINK href="../../../estilos/est_General.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmMatrizDocumentos" method="post" runat="server">
			<DIV style="Z-INDEX: 102; LEFT: 8px; WIDTH: 800px; TOP: 8px; HEIGHT: 24px">
				<table id="tblTitulo" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="header" align="center" style="HEIGHT: 24px">MATRIZ DE DOCUMENTOS POR 
							TIPO DE EMPRESA
						</td>
					</tr>
					<tr>
						<td height="6"></td>
					</tr>
				</table>
			</DIV>
			<DIV>
				<div>
					<table class="clsTxtArial8" id="Table1" borderColor="#000000" cellSpacing="0" cellPadding="0"
						border="1" style="WIDTH: 800px; HEIGHT: 250px">
						<tr>
							<td class="clsTxtIzquierda"><IMG height="239" alt="" src="../../../imagenes/acuerdos/subtitulomatriz0.gif" width="503">
							</td>
							<td width="22"><IMG height="239" alt="" src="../../../imagenes/acuerdos/subtitulomatriz1.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz2.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz3.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz4.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz5.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz6.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz7.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz8.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz9.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz10.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz11.gif" width="21"></td>
							<td width="22"><IMG height="239" alt="." src="../../../imagenes/acuerdos/subtitulomatriz12.gif" width="21"></td>
						</tr>
					</table>
				</div>
				<div id="divSustentoIdentidad" runat="server">
					<table class="clsTxtArial8" id="Table2" borderColor="#000000" cellSpacing="0" cellPadding="0"
						width="800" border="1">
						<tr>
							<td class="clsTxtTituloCeldas" colSpan="13">Sustento de Identidad
							</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Documento de identidad vigente del RL</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Carnet Extranjeria/Pasaporte del RL
							</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Poderes inscritos en Registros P�blicos (RR.PP).<br>
								(S�lo adjuntar la la hoja con al designaci�n y facultades del RL. La vigencia 
								del documento no tendr� antiguedad mayor a 3 meses)
							</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Resoluci�n de nombramiento y la Resoluci�n o Norma 
								Legal con las facultades del RL.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Minuta de constituci�n del consorcio, donde se validar� 
								al RL y sus facultades contractuales.<br>
								(S�lo consorcios).
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Norma legal o el documento con las facultades del RRLL 
								y s�lo la hoja con la designaci�n del RL inscrito en Registros&nbsp;P�blicos. 
								(Asociaciones, Federaciones, Colegios, etc).
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
						</tr>
					</table>
				</div>
				<div id="divSustentoDireccion" runat="server">
					<table class="clsTxtArial8" id="Table6" borderColor="#000000" cellSpacing="0" cellPadding="0"
						width="800" border="1">
						<tr class="clsTxtCentrado">
							<td class="clsTxtTituloCeldas" colSpan="13">Sustento de Direcci�n
							</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Si las direcciones indicadas en los acuerdos se 
								encuentran registradas en SUNAT y la empesa figura como Habido no requiere 
								sustento de direcci�n.
							</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Recibo de servicios (luz, agua, telefon�a) de los 2 
								�ltimos meses a nombre de la Empresa/Persona Natural
							</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td>Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Si la direcci�n de la Empresa/ Persona Natural se 
								encuentra validada en p�ginas blancas no se requerir� el Recibo de servicios a 
								nombre de la Empresa/Persona Natural.
							</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td>Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Si no cuenta con recibo de servicios se acepta como 
								documento v�lido los Contratos de arrendamiento debiodamente firmados por el RL 
								y el arrendador.
							</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td>Op</td>
						</tr>
					</table>
				</div>
				<div id="divSustentoCapacidadPago" runat="server">
					<table class="clsTxtArial8" id="Table3" borderColor="#000000" cellSpacing="0" cellPadding="0"
						width="800" border="1">
						<tr class="clsTxtCentrado">
							<td class="clsTxtTituloCeldas" colSpan="13">Sustento de capacidad de pago 
								(ingresos)</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">2 �ltimos formularios PDT 621 con sus recpectivos 
								vouchers de pago de IGV y/o renta. Se sugiere s�lo adjuntar p�ginas 1 y 3.<br>
								Para que se consideren v�lidos los PDT's:<br>
								- Uno de los meses deben tener ventas superiores a las compras.<br>
								- El pago de impuestos debe ser acorde al volumen de ventas presentado.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Para solicitudes de ventas mayores a S/.1,000 soles 
								(como Cargo Fijo Total) solicitar�n al cliente la impresi�n de p�gina Web SUNAT 
								con pagos validados.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda" height="37">Constancias de pago SUNAT con sus 
								respectivos vouchers de pago.<br>
								(Para empresas del R�gimen �nico Simplificado)
							</td>
							<td width="22" height="37">&nbsp;</td>
							<td width="22" height="37">&nbsp;</td>
							<td width="22" height="37">&nbsp;</td>
							<td width="22" height="37">X</td>
							<td width="22" height="37">&nbsp;</td>
							<td width="22" height="37">&nbsp;</td>
							<td width="22" height="37">X</td>
							<td width="22" height="37">X</td>
							<td width="22" height="37">&nbsp;</td>
							<td width="22" height="37">X</td>
							<td width="22" height="37">&nbsp;</td>
							<td width="22" height="37">Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Recibos por Honorarios de los dos �ltimos meses.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
						</tr>
					</table>
				</div>
				<div id="divSustentoComplementario" runat="server">
					<table class="clsTxtArial8" id="Table7" borderColor="#000000" cellSpacing="0" cellPadding="0"
						width="800" border="1">
						<tr class="clsTxtCentrado">
							<td class="clsTxtTituloCeldas" colSpan="13">Sustentos Complementarios (Si los PDT 
								no cumplen con los requisitos definidos, las ventas son insuficientes o la 
								empresa no
								<br>
								presenta el sustento).
							</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">2 �ltimos estados de cuenta corriente y/o movimientos 
								bancarios de la empresa.
							</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>Op</td>
							<td>Op</td>
							<td>&nbsp;</td>
							<td>Op</td>
							<td>Op</td>
							<td>&nbsp;</td>
							<td>Op</td>
							<td>Op</td>
							<td>Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Hoja de los poderes inscritos en registros p�blicos con 
								la relaci�n de los accionistas.
							</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>X</td>
							<td>Op</td>
							<td>&nbsp;</td>
							<td>Op</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>Op</td>
							<td>Op</td>
							<td>Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Estado de cuenta corriente/movimientos bancarios de los 
								principales accionistas.</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>X</td>
							<td>Op</td>
							<td>&nbsp;</td>
							<td>Op</td>
							<td>Op</td>
							<td>&nbsp;</td>
							<td>Op</td>
							<td>Op</td>
							<td>Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Contratos, cartas fianza, carta de presentaci�n si 
								empresa pertenece a grupo econ�mico importante-TOP, etc.</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">Op</td>
							<td width="22">&nbsp;</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">&nbsp;</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
						</tr>
					</table>
				</div>
				<div id="divSustentoTrabajadores" runat="server">
					<table class="clsTxtArial8" id="Table5" borderColor="#000000" cellSpacing="0" cellPadding="0"
						width="800" border="1">
						<tr class="clsTxtCentrado">
							<td class="clsTxtTituloCeldas" colSpan="13">Sustento de Trabajadores y uso de 
								l�neas.
							</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Se considera la cantidad de trabajadores que figuran en 
								SUNAT como registrados en planilla.
							</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Formulario 601 que contiene la cantidad de trabajadores 
								por locaci�n.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Carta de la empresa confirmado uso de las l�neas, 
								relaci�n de trabajadores que laboran en su proceso con los datos de DNI y 
								tel�fono de referencia. De acuerdo a la cantidad de l�neas solicitada por la 
								empresa realizaremos verificaci�n telef�nica o de campo para confirmar el 
								tama�o de la empresa.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">op</td>
						</tr>
					</table>
				</div>
				<div id="divSustentoCliente" runat="server">
					<table class="clsTxtArial8" cellSpacing="0" cellPadding="0" width="800" border="1" borderColor="#000000">
						<tr class="clsTxtCentrado">
							<td class="clsTxtTituloCeldas" colSpan="13">Sustento cliente de la competencia
							</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">2 �ltimos recibos cancelados sin deudas vencidas de 
								recibos anteriores, cargos por reconexi�n ni mora.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">Op</td>
						</tr>
					</table>
				</div>
				<div id="divOtrosDocumentos" runat="server">
					<table class="clsTxtArial8" id="Table8" borderColor="#000000" cellSpacing="0" cellPadding="0"
						width="800" border="1">
						<tr class="clsTxtCentrado">
							<td class="clsTxtTituloCeldas" colSpan="13">Otros documentos a anexar
							</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Ficha de la SUNARP (Para considerar el Capital Social 
								inscrito en Registros P �blicos)
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Documento de Adjudicaci�n de Buena Pro (Licitaci�n, 
								Concurso P�blico) indicando el monto adjudicado a Am�rica M�vil. Para 
								solicitudes mayores a S/. 10,650.S�lo para estos casos los acuerdos no 
								requieren firmas.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Orden de Compra/Servicio a nombre y con direcci�n de 
								Am�rica M�vil Per� SAC.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Carta de presentaci�n de la empresa en la que indica 
								cual es el giro del negocio.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Carta de compromiso de no fraude firmada por el RRLL.
							</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22"></td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Carta solicitando l�neas a Claro.
							</td>
							<td width="22">Op</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">&nbsp;</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">&nbsp;</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
							<td width="22">Op</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Formatos y Anexos (Acuerdo B01, B03, B04, B22, B29, 
								etc.)
							</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Para m�s de 10 planes es obligatorio adjutnar un Excel 
								con el detalle de los topes correspondientes.
							</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">&nbsp;</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Mail de aprobaci�n descuentos especiales 
								(digitalizado), incluyendo la plantilla o detalle de los par�metros aprobados.
							</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
							<td width="22">X</td>
						</tr>
					</table>
				</div>
			</DIV>
			<div><INPUT id="hidIdTipoDoc" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidIdTipoDoc"
					runat="server"></div>
		</form>
	</body>
</HTML>
 
 
 
 
