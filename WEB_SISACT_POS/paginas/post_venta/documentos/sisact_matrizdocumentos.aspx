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
							<td class="clsTxtIzquierda">Poderes inscritos en Registros Públicos (RR.PP).<br>
								(Sólo adjuntar la la hoja con al designación y facultades del RL. La vigencia 
								del documento no tendrá antiguedad mayor a 3 meses)
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
							<td class="clsTxtIzquierda">Resolución de nombramiento y la Resolución o Norma 
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
							<td class="clsTxtIzquierda">Minuta de constitución del consorcio, donde se validará 
								al RL y sus facultades contractuales.<br>
								(Sólo consorcios).
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
								y sólo la hoja con la designación del RL inscrito en Registros&nbsp;Públicos. 
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
							<td class="clsTxtTituloCeldas" colSpan="13">Sustento de Dirección
							</td>
						</tr>
						<tr class="clsTxtCentrado">
							<td class="clsTxtIzquierda">Si las direcciones indicadas en los acuerdos se 
								encuentran registradas en SUNAT y la empesa figura como Habido no requiere 
								sustento de dirección.
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
							<td class="clsTxtIzquierda">Recibo de servicios (luz, agua, telefonía) de los 2 
								últimos meses a nombre de la Empresa/Persona Natural
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
							<td class="clsTxtIzquierda">Si la dirección de la Empresa/ Persona Natural se 
								encuentra validada en páginas blancas no se requerirá el Recibo de servicios a 
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
								documento válido los Contratos de arrendamiento debiodamente firmados por el RL 
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
							<td class="clsTxtIzquierda">2 últimos formularios PDT 621 con sus recpectivos 
								vouchers de pago de IGV y/o renta. Se sugiere sólo adjuntar páginas 1 y 3.<br>
								Para que se consideren válidos los PDT's:<br>
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
								(como Cargo Fijo Total) solicitarán al cliente la impresión de página Web SUNAT 
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
								(Para empresas del Régimen Único Simplificado)
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
							<td class="clsTxtIzquierda">Recibos por Honorarios de los dos últimos meses.
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
							<td class="clsTxtIzquierda">2 últimos estados de cuenta corriente y/o movimientos 
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
							<td class="clsTxtIzquierda">Hoja de los poderes inscritos en registros públicos con 
								la relación de los accionistas.
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
							<td class="clsTxtIzquierda">Contratos, cartas fianza, carta de presentación si 
								empresa pertenece a grupo económico importante-TOP, etc.</td>
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
								líneas.
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
								por locación.
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
							<td class="clsTxtIzquierda">Carta de la empresa confirmado uso de las líneas, 
								relación de trabajadores que laboran en su proceso con los datos de DNI y 
								teléfono de referencia. De acuerdo a la cantidad de líneas solicitada por la 
								empresa realizaremos verificación telefónica o de campo para confirmar el 
								tamaño de la empresa.
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
							<td class="clsTxtIzquierda">2 últimos recibos cancelados sin deudas vencidas de 
								recibos anteriores, cargos por reconexión ni mora.
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
								inscrito en Registros P úblicos)
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
							<td class="clsTxtIzquierda">Documento de Adjudicación de Buena Pro (Licitación, 
								Concurso Público) indicando el monto adjudicado a América Móvil. Para 
								solicitudes mayores a S/. 10,650.Sólo para estos casos los acuerdos no 
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
							<td class="clsTxtIzquierda">Orden de Compra/Servicio a nombre y con dirección de 
								América Móvil Perú SAC.
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
							<td class="clsTxtIzquierda">Carta de presentación de la empresa en la que indica 
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
							<td class="clsTxtIzquierda">Carta solicitando líneas a Claro.
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
							<td class="clsTxtIzquierda">Para más de 10 planes es obligatorio adjutnar un Excel 
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
							<td class="clsTxtIzquierda">Mail de aprobación descuentos especiales 
								(digitalizado), incluyendo la plantilla o detalle de los parámetros aprobados.
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
 
 
 
 
