Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO
Imports System

Public Class sisact_venta_prepago
Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

'El Diseñador de Web Forms requiere esta llamada.
<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidMensajeValidaCliente As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidTipoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidTipoCliente As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidTelefono As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidPrecioSubTotal As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidPrecioTotal As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidOfVenta As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidIccid As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidOK As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidCampaniaDefault As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidListaPrecioDefault As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidTipoDocVenta As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidCampanias As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidPlanDefault As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents ddlTipoDocId As System.Web.UI.WebControls.DropDownList
Protected WithEvents txtNumeroDocId As System.Web.UI.WebControls.TextBox
Protected WithEvents txtNroLinea As System.Web.UI.WebControls.TextBox
Protected WithEvents txtHlr As System.Web.UI.WebControls.TextBox
Protected WithEvents txtVendedor As System.Web.UI.WebControls.TextBox
Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
Protected WithEvents txtSerieChip As System.Web.UI.WebControls.TextBox
Protected WithEvents txtCodMaterial As System.Web.UI.WebControls.TextBox
Protected WithEvents txtDescArticulo As System.Web.UI.WebControls.TextBox
Protected WithEvents ddlCampania As System.Web.UI.WebControls.DropDownList
Protected WithEvents ddlPrecio As System.Web.UI.WebControls.DropDownList
Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
Protected WithEvents hidPLSelected As System.Web.UI.HtmlControls.HtmlInputHidden
Protected WithEvents hidCampaniaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOrgVenta As System.Web.UI.HtmlControls.HtmlInputHidden

'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
'No se debe eliminar o mover.
Private designerPlaceholderDeclaration As System.Object

Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty) Or CheckStr(Session("CodVendedorSAP")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        ' Eventos de los Controles
        ddlTipoDocId.Attributes.Add("onChange", "cambiarTipoDoc(this.value);")
        ddlCampania.Attributes.Add("onChange", "cargarListaPrecios();")
        ddlPrecio.Attributes.Add("onChange", "cargarPrecio();")

        If Not IsPostBack Then
            Inicio()
        Else
            If hidAccion.Value = "Consultar" Then
                Consultar()
            ElseIf hidAccion.Value = "GenerarPedido" Then
                GenerarPedido()
            End If
            hidAccion.Value = ""
        End If
    End Sub

    Private Sub Inicio()
        Try
            hidTipoVenta.Value = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago").ToString()
            hidTipoOperacion.Value = ConfigurationSettings.AppSettings("constCodOperReposicion").ToString()
            hidTipoCliente.Value = ConfigurationSettings.AppSettings("constCodTipoClienteConsumer").ToString()
            hidTipoDocVenta.Value = ConfigurationSettings.AppSettings("constTipoDocVentaChip").ToString()
            hidPlanDefault.Value = ConfigurationSettings.AppSettings("constCodPlanChipRepuesto").ToString()
            hidCampaniaDefault.Value = ConfigurationSettings.AppSettings("constCodCampaniaChip").ToString()
            hidListaPrecioDefault.Value = ConfigurationSettings.AppSettings("constCodListPrecioChip").ToString()

            ObtenerDatosVendedor()
            CargarTipoDocumento()
            CargarCampanias()
            ConsultarDatosVenta()

            txtHlr.Text = ""
            txtTotal.Text = "0.00"
            txtVendedor.Text = CheckStr(Session("CodVendedorSAP"))
            txtFecha.Text = String.Format("{0:dd/MM/yyyy}", Now)
        Catch ex As Exception
            hidMsg.Value = String.Format("Error. {0}", ex.Message)
        End Try
    End Sub

    Private Sub ObtenerDatosVendedor()
        ' Buscar Datos del Usuario Logeado
        Dim oUsuario As Usuario
        oUsuario = New MaestroNegocio().ObtenerUsuarioLogin(Me.CurrentUser)
        Dim codUsuario As Integer = CheckInt(oUsuario.UsuarioId)

        ' Buscar Punto de Venta
        Dim listaPuntoVenta As ArrayList = New VentaNegocios().ListaPDVUsuario(codUsuario, "")
        If IsNothing(listaPuntoVenta) OrElse listaPuntoVenta.Count = 0 Then
            Throw New Exception("Error: Usuario no pertenece a algun Punto de Venta.")
        End If

        ' Guardar los datos generales de Venta
        Dim itemPuntoVenta As PuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)
        hidOfVenta.Value = CheckStr(itemPuntoVenta.OVENC_CODIGO)

        oUsuario = Nothing
        itemPuntoVenta = Nothing
        listaPuntoVenta = Nothing
    End Sub

    Private Sub CargarTipoDocumento()
        Dim listaTipoDoc As New ArrayList
        Dim oTipoDocumento As New ItemGenerico

        listaTipoDoc = New VentaNegocios().ListaTipoDocumento("")
        oTipoDocumento.Codigo = "00"
        oTipoDocumento.Descripcion = ConfigurationSettings.AppSettings("Seleccionar")
        listaTipoDoc.Insert(0, oTipoDocumento)

        LlenaCombo(listaTipoDoc, ddlTipoDocId, "Codigo", "Descripcion")
        listaTipoDoc = Nothing
        oTipoDocumento = Nothing
    End Sub

    Private Sub ConsultarDatosVenta()

        Dim oConsultarSap As New SapGeneralNegocios
        Dim dsOficina As New DataSet
        dsOficina = oConsultarSap.ConsultarParametrosOfVenta(CheckStr(hidOfVenta.Value))

        hidCanal.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
        hidOrgVenta.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))

        dsOficina = Nothing
        oConsultarSap = Nothing
    End Sub

    Private Sub CargarCampanias()
        Dim listaCampanias As New ArrayList
        Dim fecha As String = String.Format("{0:yyyy/MM/dd}", Now)
        Dim TipoVenta As String = hidTipoVenta.Value
        Dim strCampanias As String = "00" & "," & ConfigurationSettings.AppSettings("Seleccionar")

        listaCampanias = (New SapGeneralNegocios).Get_ConsultaCampana(fecha, TipoVenta)
        For Each item As ItemGenerico In listaCampanias
            strCampanias = strCampanias & ";" & CheckStr(item.Codigo) & "," & CheckStr(item.Descripcion)
        Next

        hidCampanias.Value = strCampanias
        listaCampanias = Nothing
    End Sub

    Private Sub Consultar()
        Dim flagOK As Boolean
        Dim mensaje As String
        Dim flag_valida As String

        Dim nroLinea As String = CheckStr(txtNroLinea.Text)
        Dim nroClieDoc As String = CheckStr(txtNumeroDocId.Text)
        Dim tipoClieDoc As String = CheckStr(ddlTipoDocId.SelectedValue)
        Dim desClieDoc As String = CheckStr(ddlTipoDocId.SelectedItem.Text)
        hidMensajeValidaCliente.Value = "OK"

        Try
        If LeerDatosLinea(nroLinea) Then

                Dim objRestChipRepuestoNegocio As New RestChipRepuestoNegocio
                Dim cod_Respuesta, strMensaje As String
                Dim usuario_id As String = CurrentUser
                Dim ipcliente As String = CurrentTerminal
                Dim idTransaccion As String = String.Format("{0:yyyyMMdd}", Now)

                cod_Respuesta = objRestChipRepuestoNegocio.validarBloqueo(idTransaccion, ipcliente, ConfigurationSettings.AppSettings("constAplicacion").ToString(), nroLinea, usuario_id, strMensaje)
                'validacion de los mensajes de error

                Select Case cod_Respuesta
                    Case "0"
                        ' permite seguir con el proceso de reposicion de chip prepago
                    Case "1"
                        Auditoria(ConfigurationSettings.AppSettings("CodTransRechazoReposicion").ToString(), "Error al realizar la validacion del Nro de Linea:" & nroLinea)
                        RegisterStartupScript("script", "<script>alert('Línea bloqueada por uso prohibido. No procede desbloqueo, ni reposición de SIMCARD bajo ningún motivo');</script>")
                        Exit Sub
                    Case Else
                        Auditoria(ConfigurationSettings.AppSettings("CodTransRechazoReposicion").ToString(), "Línea bloqueada por uso prohibido. No procede desbloqueo, ni reposición de SIMCARD bajo ningún motivo. Nro de Linea:" & nroLinea)
                        RegisterStartupScript("script", "<script>alert('Ocurrio un error al realizar la validacion del numero.');</script>")
                        Exit Sub

                End Select

                'If cod_Respuesta <> "0" Then
                '    Auditoria(ConfigurationSettings.AppSettings("CodTransRechazoReposicion").ToString(), "Línea bloqueada por uso prohibido. No procede desbloqueo, ni reposición de SIMCARD bajo ningún motivo. Nro de Linea:" & nroLinea)
                '    RegisterStartupScript("script", "<script>alert('Línea bloqueada por uso prohibido. No procede desbloqueo, ni reposición de SIMCARD bajo ningún motivo');</script>")
                '    Exit Sub
                'End If

            flagOK = (New VentaNegocios).ConsultaValidacionCliente(desClieDoc, nroClieDoc, nroLinea, flag_valida, mensaje)
            If CheckStr(flag_valida).ToUpper.Equals("OK") Then
                txtHlr.Text = CheckStr(ConsultaHlr(nroLinea))
                hidTelefono.Value = nroLinea
            Else
                hidMsg.Value = mensaje
            End If

            Dim strScript As String = "validaFlujo('" + CheckStr(flag_valida).ToUpper() + "');"
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        End If
        Catch ex As Exception
            RegisterStartupScript("script", "<script>alert('Ocurrió un error al validar el cliente');</script>")
        End Try
        
    End Sub

    Private Function ConsultaHlr(ByVal nroLinea As String) As String
        Dim oConsulta As New VentaNegocios
        Dim Msisdn As String = "51" & nroLinea
        Dim strHLR As String

        'If (ConfigurationSettings.AppSettings("FLAG_Hlr") = "01") Then '---------------llave agregada para prueba
            strHLR = Right("00" & CheckStr(oConsulta.ObtenerNroHLR(Msisdn)), 2)
            'Else
            '    strHLR = Right("00" & ConfigurationSettings.AppSettings("Nuevo_Hlr"), 2)
            'End If

        Return strHLR

    End Function

    Private Function LeerDatosLinea(ByVal nroLinea As String) As Boolean
        Dim oPrepagoNegocios As New DatosPrepagoNegocios

        Dim providerIdPrepago As String = ConfigurationSettings.AppSettings("ProviderIdPrepago").ToString()
        Dim providerIdControl As String = ConfigurationSettings.AppSettings("ProviderIdControl").ToString()
        Dim mensajeError As String = ""
        Dim datosLinea As ItemGenerico = Nothing

        datosLinea = oPrepagoNegocios.LeerDatosPrepago(nroLinea, providerIdPrepago, providerIdControl, mensajeError)
        If IsNothing(datosLinea) OrElse (Not datosLinea.estado.ToUpper().Equals("P")) Then
            hidMsg.Value = "Número ingresado no es prepago o ha sido dado de baja."
            Return False
        End If

        Return True
    End Function

    Private Sub GenerarPedido()
        Dim oConsultarSap As New SapGeneralNegocios
        Dim cadenaDetalle As String = ""
        Dim cadenaCabecera As String = ""

        Try
            Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
            Dim valorDescuento As Decimal

            'Generar los Parametros
            cadenaCabecera = GenerarCadenaCabecera()
            cadenaDetalle = GenerarCadenaDetalle()
            ' Realizar Pedido
            Dim pedidoGenerado As Boolean = oConsultarSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", entrega, factura, _
                                            nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)
            If Not pedidoGenerado Then
                Throw New Exception("No se pudo Generar el Pedido en Sap.")
            End If

            ' Grabar Detalle Chip Repuesto 
            GenerarDetalleChipSap(factura)

            ' Auditoria Realizar Pedido
            Dim descRealizarPedido As String = "Se realizó Transacción exitosa de Generar Pedido Prepago. (OficinaVenta: " & hidOfVenta.Value & " | Nro Pedido: " & nroPedido & ")."
            AuditoriaRealizarPedido(descRealizarPedido)

            ' Mensaje de Exito al realizar la Venta
            Dim mensaje As String = "Pedido generado satisfactoriamente." & Chr(13) & "Ingresar a Activación/Documentos por pagar para culminar proceso."
            Dim strScript As String = "window.reload();"

            hidMsg.Value = mensaje
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        Catch ex As Exception
            txtHlr.Text = ""
            hidMsg.Value = "Error. Generar Pedido. " & ex.Message
        End Try
        oConsultarSap = Nothing
    End Sub

    Private Function GenerarCadenaCabecera() As String

        Dim oConsultarSap As New SapGeneralNegocios

        Dim oficina As String = CheckStr(hidOfVenta.Value)
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
        Dim nroDocCliente As String = ConfigurationSettings.AppSettings("constCodDocClienteChip")
        Dim tipoDocCliente As String = ConfigurationSettings.AppSettings("constTipoDocClienteChip")
        Dim tipoVenta As String = hidTipoVenta.Value
        Dim tipoCliente As String = hidTipoCliente.Value
        Dim tipoOperacion As String = hidTipoOperacion.Value
        Dim motivoReposicion As String = ConfigurationSettings.AppSettings("constCodMotivoReposicion")
        Dim tipoDocVenta As String = ConfigurationSettings.AppSettings("constTipoDocVentaChip")
        Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")
        Dim totalSinIGV As String = hidPrecioSubTotal.Value
        Dim totalConIGV As String = hidPrecioTotal.Value
        Dim canal As String = hidCanal.Value
        Dim orgVenta As String = hidOrgVenta.Value
        Dim totalIGV As String = CStr(CheckDecimal(hidPrecioTotal.Value) - CheckDecimal(hidPrecioSubTotal.Value))

        ' Cadena Documento
        Dim arrayCabecera(49) As String
        arrayCabecera(0) = ""                                    'Documento
        arrayCabecera(1) = tipoDocVenta                          'Tipo_Documento
        arrayCabecera(2) = oficina                               'Oficina_Venta
        arrayCabecera(3) = String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
        arrayCabecera(4) = tipoDocCliente                        'Tipo_Doc_Cliente
        arrayCabecera(5) = nroDocCliente                         'Cliente
        arrayCabecera(6) = motivoReposicion                      'Motivo de Reposicion
        arrayCabecera(7) = moneda                                'Moneda
        arrayCabecera(9) = totalSinIGV                           'Total_Mercaderia
        arrayCabecera(10) = totalIGV                             'Total_Impuesto
        arrayCabecera(11) = totalConIGV                          'Total_Documento
        arrayCabecera(16) = tipoVenta                            'Tipo_Venta
        arrayCabecera(25) = codVendedor                          'Código Comercial
        arrayCabecera(27) = codVendedor                          'Vendedor
        arrayCabecera(29) = tipoOperacion                        'Chip Repuesto
        arrayCabecera(44) = "01"                                 'Operador
        arrayCabecera(45) = "02"                                 'Tipo de Operador
        arrayCabecera(48) = orgVenta                             'Orgvnt
        arrayCabecera(49) = canal                                'Canal

        oConsultarSap = Nothing
        Return Join(arrayCabecera, ";")
    End Function

    Private Function GenerarCadenaDetalle() As String
        Dim cadenaDetalle As String = ""
        Dim oConsultaExpress As New VentaNegocios

        ' Detalle Linea Venta
        Dim arrayDetalle(28) As String
        Dim consecutivo As String = "000001"
        Dim cantidad As Integer = 1
        Dim codPlan As String = ConfigurationSettings.AppSettings("constCodPlanChipRepuesto")
        Dim desPlan As String = ConfigurationSettings.AppSettings("constDesPlanChipRepuesto")
        Dim arrayListaPrecio() As String = hidPLSelected.Value.Split(","c)
        Dim arrayCampania() As String = hidCampaniaSelected.Value.Split(","c)

        Dim totalSinIGV As String = hidPrecioSubTotal.Value
        Dim totalConIGV As String = hidPrecioTotal.Value
        Dim totalIGV As String = CheckStr(CheckDecimal(hidPrecioTotal.Value) - CheckDecimal(hidPrecioSubTotal.Value))

        ' Iccid
        arrayDetalle(0) = ""                            'Documento
        arrayDetalle(1) = consecutivo                   'Consecutivo (codigo 6 digitos)
        arrayDetalle(2) = txtCodMaterial.Text           'Articulo
        arrayDetalle(3) = txtDescArticulo.Text          'Des_Articulo
        arrayDetalle(4) = arrayListaPrecio(0)           'Utilizacion
        arrayDetalle(5) = arrayListaPrecio(1)           'Des_Utilizacion
        arrayDetalle(6) = arrayCampania(0)              'Campana
        arrayDetalle(7) = arrayCampania(1)              'Des_Campana
        arrayDetalle(8) = CheckStr(hidIccid.Value)      'Iccid
        arrayDetalle(9) = CheckStr(cantidad)            'Cantidad
        arrayDetalle(10) = totalSinIGV                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
        arrayDetalle(11) = totalConIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
        arrayDetalle(12) = totalIGV                     'Descuento
        arrayDetalle(13) = ""                           'Porc_Descuento
        arrayDetalle(14) = ""                           'Descuento_Adic
        arrayDetalle(15) = totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
        arrayDetalle(16) = totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
        arrayDetalle(17) = ""                           'Impuesto2
        arrayDetalle(18) = codPlan                      'Plan_Tarifario
        arrayDetalle(19) = desPlan                      'Des_Plan_Tarifar
        arrayDetalle(20) = ""                           'Centro_Costo
        arrayDetalle(21) = ""                           'Motivo_Devolucio
        arrayDetalle(22) = ""                           'Asociado
        arrayDetalle(23) = ""                           'Consecutivo_Padr
        arrayDetalle(24) = ""                           'Articulo_Asociac
        arrayDetalle(25) = hidTelefono.Value            'Numero_Telefono
        arrayDetalle(26) = ""                           'Nro_Clarify
        arrayDetalle(27) = ""                           'Dev_Componente
        arrayDetalle(28) = ""                           'Serie_Ant

        cadenaDetalle = Join(arrayDetalle, ";")
        oConsultaExpress = Nothing

        Return cadenaDetalle
    End Function

    Private Sub GenerarDetalleChipSap(ByVal nroPedido As String)

        Dim arrayDetalle(18) As String
        Dim oConsultaSap As New SapGeneralNegocios
        Dim nroLinea As String = CheckStr(hidTelefono.Value)
        Dim motivo As String = ConfigurationSettings.AppSettings("constCodMotivoReposicion")
        Dim puntoVenta As String = CheckStr(hidOfVenta.Value)
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))

        Dim oConsultaSans As New SansNegocio

        Try
            Dim usuario_id As String = CurrentUser
            arrayDetalle(0) = ""
            arrayDetalle(1) = nroLinea
            'arrayDetalle(2) = oConsultaSap.ConsultarIccid("", nroLinea, "")
            arrayDetalle(2) = oConsultaSans.ConsultarIccid("", nroLinea, "", txtCodMaterial.Text, txtSerieChip.Text, usuario_id)
            arrayDetalle(3) = ""
            arrayDetalle(4) = puntoVenta
            arrayDetalle(5) = nroPedido
            arrayDetalle(6) = motivo
            arrayDetalle(7) = hidIccid.Value
            arrayDetalle(9) = codVendedor
            arrayDetalle(10) = ""
            arrayDetalle(11) = String.Format("{0:dd/MM/yyyy}", Now)
            arrayDetalle(12) = Format(Now, "H:mm:ss")
            arrayDetalle(13) = ConfigurationSettings.AppSettings("strEstadoSolNuevo")
            arrayDetalle(14) = "X"
            arrayDetalle(15) = ""
            arrayDetalle(16) = String.Format("{0:dd/MM/yyyy}", Now)
            arrayDetalle(17) = Format(Now, "H:mm:ss")
            ' Grabar Datos Pedido
            oConsultaSap.SetGetLogActivacionChip("", "", Join(arrayDetalle, ";"), "")
        Catch ex As Exception
        End Try
    End Sub

#Region " Auditoria"
    Private Sub AuditoriaRealizarPedido(ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("CodTransAuditVentaPedido")

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Auditoria(ByVal strCodTrans As String, ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class
