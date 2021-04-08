Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_venta_prepago
    'Inherits System.Web.UI.Page
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtPlan As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIccid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroLinea As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImei As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaterialImei As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArticuloImei As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSerieIccid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroLineaCAC As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlArticuloIMEI As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMaterialImeiCAC As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCampania As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPrecio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMontoTotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents trVentaDAC As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trVentaCAC As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hidCampaniaDesc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioDesc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumeroPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProcesarPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanActual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniasDisponibles As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidConsultaPrecio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRespuestaPrecioPlan As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioSubTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfVentaDesc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidScoreCred As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlazoAcuerdo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVendedor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocPrefijo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrefijo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagPrefijoManual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroContrato As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroPedido As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDeposito As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidParamsListaPrecios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVentaExpress As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected cargoFijoTotal As Decimal = 0
    Protected WithEvents hidCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtMontoTotal1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidCampaniaDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaPrecioDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampanias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPLSelected As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim objLog As New SISACT_Log
	Dim strArchivorRenovPrep As String = objLog.Log_CrearNombreArchivo(ConfigurationSettings.AppSettings("constNameLogRenovacion"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")
        If (Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If
        If Not IsPostBack Then
            Inicio()
            txtImei.Attributes.Add("disabled", "disabled")
        Else
            Select Case hidRequest.Value
                Case "GenerarAcuerdo"
                    ' Generar el Acuerdo
                    GenerarAcuerdo()
            End Select
        End If
    End Sub

    Private Sub Inicio()
        hidResponse.Value = "DetallePlanes"
        Dim listaPlanes As New ArrayList

        Try
            Dim oSolicitud As SolicitudPersona = CType(Session("SolicitudSelected"), SolicitudPersona)
            hidTipoDoc.Value = oSolicitud.TDOCC_CODIGO

            Dim oCanal As Canal = CType(Session("CanalSelected"), Canal)

            Dim oVendedor As Vendedor = CType(Session("VendedorSelected"), Vendedor)
            hidVendedor.Value = oVendedor.Id_Distribuidor_Vendedor

            Dim oPuntoVenta As PuntoVenta = CType(Session("PuntoVentaSelected"), PuntoVenta)
            hidOfVenta.Value = oPuntoVenta.OVENC_CODIGO 'oSolicitud.OVENC_CODIGO
            hidOfVentaDesc.Value = oPuntoVenta.OVENV_DESCRIPCION 'oSolicitud.OVENV_DESCRIPCION
            hidCanal.Value = oCanal.CANAC_CODIGO

            hidPlanDefault.Value = ConfigurationSettings.AppSettings("constCodPlanChipRepuesto")
            hidCampaniaDefault.Value = ConfigurationSettings.AppSettings("constCodCampaniaPreP")
            hidListaPrecioDefault.Value = ConfigurationSettings.AppSettings("constCodListPrecioChip")

            If oCanal.CANAC_CODIGO = ConfigurationSettings.AppSettings("ExpressVentaCAC") Then
                hidVentaExpress.Value = ConfigurationSettings.AppSettings("ExpressVentaCAC")
            Else
                hidVentaExpress.Value = ConfigurationSettings.AppSettings("ExpressVentaDAC")
            End If

            If (hidVentaExpress.Value = ConfigurationSettings.AppSettings("ExpressVentaDAC")) Then
                trVentaDAC.Visible = True
                trVentaCAC.Visible = False
            Else
                trVentaDAC.Visible = False
                trVentaCAC.Visible = True
                ddlArticuloIMEI.Attributes.Add("onChange", "f_CambiaImei()")

                ' Cargar los Articulos del Almacen
                CargarArticulos()
            End If

            Dim oConsultaSolicitud As New SolicitudNegocios

            Dim oConsultaExpress As New VentaExpressNegocios
            Dim oConsultaSap As New SapGeneralNegocios

            ' Lista de PLANES
            Dim fecha As String = Now.ToString("yyyyMMdd")
            Dim tipoCliente As String = ConfigurationSettings.AppSettings("constCodTipoProductoConSAP") '"02" 'Sisact: 01 = Consumer - SAP: 02 = Consumer
            hidTipoCliente.Value = tipoCliente

            Dim tipoVenta As String = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago")
            hidTipoVenta.Value = tipoVenta
            Dim tipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")
            hidTipoOperacion.Value = tipoOperacion

            Dim mandt As String = ConfigurationSettings.AppSettings("ExpressMandt")

            ' Plan Prepago
            Dim planPrepago As String = ConfigurationSettings.AppSettings("ExpressPlanPrepago")
            listaPlanes = New VentaExpressNegocios().ListarPlanes(planPrepago, tipoVenta, tipoCliente, "", mandt)

            hidNumeroPlanes.Value = listaPlanes.Count.ToString()
            For i As Integer = 0 To listaPlanes.Count - 1
                Dim idxPlan As Integer = i + 1
                Dim oPlan As ItemGenerico = CType(listaPlanes(i), ItemGenerico)

                ' Obtener datos de la Linea
                Dim oLinea As ItemGenerico = CType(Session("LineaSelected"), ItemGenerico)
                hidPlanes.Value = hidPlanes.Value & "|" & oPlan.Codigo & "," & oPlan.Descripcion & "," & oPlan.Monto & "," & oLinea.Numero & "," & oLinea.Descripcion

                ' Lista de Campanias Disponibles (par cada plan)
                Dim listaCampanias As New ArrayList
                listaCampanias = oConsultaExpress.ConsultarListaCampanias(tipoVenta, fecha, mandt)
                If listaCampanias.Count = 0 Then
                    If hidMsg.Value <> "" Then
                        hidMsg.Value = hidMsg.Value & Chr(13) & "Error. No existen campañas disponibles para el Plan " & idxPlan & _
                        " (" & oPlan.Descripcion & ")."
                    Else
                        hidMsg.Value = "Error. No existen campañas disponibles para el Plan " & idxPlan & _
                        " (" & oPlan.Descripcion & ")."
                    End If
                End If
            Next
            CargarCampanias()
        Catch ex As Exception
            hidMsg.Value = "Error. " & ex.Message
        End Try
        listaPlanes = Nothing
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

        hidCampaniasDisponibles.Value = hidCampaniasDisponibles.Value & "|" & strCampanias
        hidCampanias.Value = strCampanias
        listaCampanias = Nothing
    End Sub

    Sub CargarArticulos()
        CargarArticuloIMEI()
    End Sub

    Sub CargarArticuloIMEI()
        Dim arrListaIMEI As New ArrayList
        Dim arreglo As New ArrayList
        Dim oSapNegocios As New SapGeneralNegocios
        Dim fechaActual As String = CStr(Now.Today)
        Dim tipoVenta As String = hidTipoVenta.Value
        Dim claseVenta As String = hidTipoOperacion.Value
        Dim iccid As New ItemGenerico
        Dim posicion As Integer = 0

        arreglo = oSapNegocios.get_ConsultaMaterial(fechaActual, "", tipoVenta, hidOfVenta.Value, claseVenta)

        For i As Integer = 0 To arreglo.Count - 1
            iccid = CType(arreglo.Item(i), ItemGenerico)
            If Not iccid.Codigo.StartsWith("PS") Then
                arrListaIMEI.Insert(posicion, arreglo.Item(i))
                posicion += 1
            End If
        Next

        Dim item As New ItemGenerico
        item.Codigo = "0000000000"
        item.Descripcion = ConfigurationSettings.AppSettings("Seleccionar")
        arrListaIMEI.Insert(0, item)

        With ddlArticuloIMEI
            .DataSource = arrListaIMEI
            .DataValueField = "codigo"
            .DataTextField = "descripcion"
            .DataBind()
        End With

        oSapNegocios = Nothing
        arreglo = Nothing
        arrListaIMEI = Nothing
    End Sub

#Region " Realizar Pedido"
    Private Sub GenerarAcuerdo()

		objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Inicio GenerarAcuerdo()")

        If Session("ClienteSAP") Is Nothing Then
            If Not RegistrarClienteSAP() Then
                Exit Sub
            End If
        End If
        Dim oConsultarSap As New SapGeneralNegocios
        Dim oConsultarExpress As New VentaExpressNegocios
        Dim oConsultarSolicitud As New SolicitudNegocios

        Dim cadenaCabecera As String = ""
        Dim cadenaDetalle As String = ""
        Dim cadenaAcuerdo As String = ""
        Dim cadenaDeposito As String = ""

        Dim estadosSec As String = ConfigurationSettings.AppSettings("constEstadoAPR")

        hidNroContrato.Value = ""
        hidNroPedido.Value = ""

		Dim listaSolicitudes As ArrayList = New ArrayList
		Dim nroLinea As String
        Try
            Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
            Dim valorDescuento As Decimal

            'Generar los Parametros en el Orden: Cabecera, Detalle
            cadenaCabecera = GenerarCadenaCabecera()
			cadenaDetalle = GenerarCadenaDetalle()

			nroLinea = CheckStr(cadenaDetalle.Split(";"c)(25))

			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "Inicio RealizarPedido")
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "    INP cadenaCabecera: " & cadenaCabecera)
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "    INP cadenaDetalle: " & cadenaDetalle)

            ' Realizar Pedido
            Dim pedidoGenerado As Boolean = oConsultarSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", _
                entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)


			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "    OUT entrega: " & entrega)
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "    OUT factura: " & factura)
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "    OUT nroContrato: " & nroContrato)
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "    OUT nroPedido: " & nroPedido)
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "Fin RealizarPedido")

            If Not pedidoGenerado Then
                Throw New Exception("No se pudo Generar el Acuerdo.")
            End If
            hidNroContrato.Value = nroContrato
            hidNroPedido.Value = nroPedido

            Dim blnRegVentaSiscad As Boolean
            blnRegVentaSiscad = RegistrarPreventaSICAD(nroPedido)

            ' Auditoria Realizar Pedido
            Dim Imei As String = CheckStr(cadenaDetalle.Split(";"c)(8))

            Dim montoTotal As String = CheckStr(cadenaDetalle.Split(";"c)(11))
            Dim campania As String = CheckStr(cadenaDetalle.Split(";"c)(6))
            Dim planTarif As String = CheckStr(cadenaDetalle.Split(";"c)(18))

            Dim descRealizarPedido As String = "Se realizó Transacción exitosa de Generar Pedido Prepago. (OficinaVenta: " & hidOfVenta.Value & " - " & hidOfVentaDesc.Value & _
                " | Nro Pedido: " & nroPedido & _
                " | Nro Linea: " & nroLinea & _
                " | Plan: " & planTarif & _
                " | Serie Equipo: " & Imei & _
                " | Campaña: " & campania & _
                " | Total: " & montoTotal & ")."

            Dim strScript As String = "window.parent.setValue('hidMsg','El Pedido ha sido generado satisfactoriamente.'); window.parent.reload();"

            If Not blnRegVentaSiscad Then
                RollBackVentaSAP(nroPedido)
                descRealizarPedido = "Error en Generar Pedido Prepago." & " | Nro Linea: " & nroLinea
                strScript = "window.parent.setValue('hidMsg','Error generando la venta en SISCAD.'); window.parent.reload();"
            End If

            AuditoriaRealizarPedido(descRealizarPedido)
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        Catch ex As Exception
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "    ERROR:" & ex.Message.ToString())
            If hidMsg.Value <> "" Then
                hidMsg.Value = hidMsg.Value & Chr(13) & "Error. " & ex.Message
            Else
                hidMsg.Value = "Error. " & ex.Message
            End If
        Finally
			objLog.Log_WriteLog(strArchivorRenovPrep, " -" & nroLinea & "- " & "Fin GenerarAcuerdo()")
        End Try
        oConsultarSap = Nothing
        oConsultarExpress = Nothing
        oConsultarSolicitud = Nothing
    End Sub

    Private Function RegistrarPreventaSICAD(ByVal nroPedido As String) As Boolean

        Dim oOficina As New PuntoVenta
        Dim oVentaExpress As New VentaExpressNegocios
        Dim blnRetorno As Boolean
        Dim NroTicket As String

        'Parametros de Salida
        Dim listaPedido As New ArrayList
        Dim listaMaterial As New ArrayList
        Dim listaOrden As New ArrayList
        Dim oVenta As New VentaSiscad

        Dim retorno As String
		Dim exito As Boolean = True

		Dim listaSeriesSinSKU As New ArrayList
		Dim listaSeriesSinPrecio As New ArrayList
		Dim arrRetorno() As String

        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Inicio RegistrarPreventaSICAD")
        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "    nroPedido: " & nroPedido)
        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "    hidOfVenta: " & hidOfVenta.Value)
        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "    hidCanal: " & hidCanal.Value)

        Try
            'VALIDA CANAL CORNER
            If hidCanal.Value = ConfigurationSettings.AppSettings("CacCorner") Then
                'VERIFICA OFICINA ACTIVA SISCAD
                If ObtenerDatosOficina(nroPedido, hidOfVenta.Value, oOficina) Then
                    'OBTENER DATOS DE VENTA DE SAP
                    If ObtenerDatosVenta(nroPedido, hidOfVenta.Value, oOficina, _
                                        listaPedido, _
                                        listaMaterial, _
                                        listaOrden, _
                                        oVenta) Then
                        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Inicio CrearVenta")

                        oVenta.EstadoVenta = ConfigurationSettings.AppSettings("constEstadoVentaPreventa")
                        oVenta.Usuario = Me.CurrentUser
                        'REGISTRAR CABECERA VENTA SISCAD
                        blnRetorno = oVentaExpress.CrearVenta(oVenta, NroTicket)

                        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "    OUT blnRetorno: " & blnRetorno)
                        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "    OUT NroTicket: " & NroTicket)
                        objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Fin CrearVenta")

						If blnRetorno Then
							objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Inicio CrearOrdenVenta")
							For Each orden As OrdenVentaSiscad In listaOrden

								'Agregar Nro. Ticket en la Entidad OrdenSiscad
								orden.TicketPreventa = NroTicket
								objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Inicio CrearOrdenVenta")
								'Grabar información de Orden de Venta
								orden.EstadoMaterial = ConfigurationSettings.AppSettings("constEstadoMaterialPreventa")
								orden.OrigenVenta = ConfigurationSettings.AppSettings("constAplicacion")

								objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "	INP CodigoMaterial:" & orden.CodigoMaterial)
								objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "	INP Serie:" & orden.Serie)
								objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "	INP ListaPrecio:" & orden.ListaPrecio)
								objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "	INP Precio:" & orden.Precio)

								retorno = oVentaExpress.CrearOrdenVenta(orden)

								objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "    OUT retorno: " & retorno)
								objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Fin CrearOrdenVenta")

								arrRetorno = retorno.Split(";")
								If CheckInt(arrRetorno(0)) > 0 Then
									If arrRetorno(1) = "0" Then
										listaSeriesSinPrecio.Add(orden)
									End If

									If arrRetorno(2) = "0" Then
										orden.Precio = arrRetorno(3)
										listaSeriesSinSKU.Add(orden)
									End If
								End If
							Next
							EnviarCorreoSiscad(oOficina, listaSeriesSinPrecio, listaSeriesSinSKU)
							objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Fin CrearOrdenVenta")
							exito = True
						Else
							exito = False
						End If
					End If
                End If
            End If
        Catch ex As Exception
            exito = False
            objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "    ERROR: " & ex.Message.ToString())
        Finally
            objLog.Log_WriteLog(strArchivorRenovPrep, " -" & txtNroLinea.Text & "- " & "Fin RegistrarPreventaSICAD")
        End Try

        Return exito

    End Function

    Private Function ObtenerDatosOficina(ByVal NroDocSap As String, ByVal PuntoVenta As String, ByRef Oficina As PuntoVenta) As Boolean
        Dim oSiscad As New VentaExpressNegocios
        Dim arrayOficina As New ArrayList
        Dim blnFound As Boolean = False
        Dim strKey As String = PuntoVenta & "|" & NroDocSap

        Try
            'Verificar Oficina es un Corner y Obtener Datos
            Oficina = oSiscad.ObtenerDatosOficinaventa(PuntoVenta)

            If Oficina.OVENC_CODIGO <> "" Then
                blnFound = True
            End If

        Catch ex As Exception
            blnFound = False

        Finally
            arrayOficina = Nothing
            oSiscad = Nothing
        End Try

        Return blnFound
    End Function

Private Function ObtenerDatosVenta(ByVal NroDocSap As String, _
                                        ByVal PuntoVenta As String, _
                                        ByVal oOficina As PuntoVenta, _
                                        ByRef arrayPedido As ArrayList, _
                                        ByRef arrayMaterial As ArrayList, _
                                        ByRef arrayOrden As ArrayList, _
                                        ByRef oVenta As VentaSiscad) As Boolean

        Dim oConsultaSap As New SapGeneralNegocios
        Dim dsPedido As New DataSet
        Dim dtCabecera As New DataTable
        Dim dtDetalle As New DataTable
        Dim blnFound As Boolean = False
        Dim idx As Integer = 0
        Dim strKey As String = PuntoVenta & "|" & NroDocSap

        Try
            'Consulta Datos Pedido Sap
            dsPedido = oConsultaSap.Get_ConsultaPedido("", PuntoVenta, NroDocSap, "")

            If IsNothing(dsPedido) OrElse dsPedido.Tables.Count = 0 Then
                Throw New Exception("No se encontro Registros Consulta Pedido Sap.")
            Else
                '0.Estructuras Tablas Detalle Pedido Sap
                dtCabecera = CType(dsPedido.Tables(0), DataTable)
                dtDetalle = CType(dsPedido.Tables(1), DataTable)

                If dtCabecera.Rows.Count = 0 Or dtDetalle.Rows.Count = 0 Then
                    Throw New Exception("No se encontro Registros Detalle Pedido Sap.")
                End If
            End If

            '1.Obtener Datos Venta BD Siscad
            oVenta.NroDocCliente = CheckStr(dtCabecera.Rows(0)("CLIENTE"))
            oVenta.TipoDocCliente = CheckStr(dtCabecera.Rows(0)("TIPO_DOC_CLIENTE")).PadLeft(2, "0")
            oVenta.NroContratoSap = CheckStr(dtCabecera.Rows(0)("NUMERO_CONTRATO"))
            oVenta.PuntoVenta = PuntoVenta
            oVenta.NroDocumentoSap = NroDocSap
            oVenta.TipoVenta = CheckStr(dtCabecera.Rows(0)("TIPO_VENTA"))

            If CheckStr(dtCabecera.Rows(0)("TIPO_VENTA")) = "07" Then
                oVenta.TipoVenta = "3"
            End If

            'Valor de Tipo Operacion
            oVenta.TipoOperacion = CheckStr(dtCabecera.Rows(0)("CLASE_VENTA"))
            oVenta.CodAplicacion = ConfigurationSettings.AppSettings("constAplicacion")

            '2.Obtener Detalle Pedido Sap
            For i As Integer = 0 To dtDetalle.Rows.Count - 1

                Dim oPedido As New PedidoSiscad
                Dim oMaterial As New MaterialSiscad

                oPedido.Werks = oOficina.OVENV_CENTRO
                oPedido.Lgort = oOficina.OVENV_ALMACEN
                oPedido.Auart = ConfigurationSettings.AppSettings("clasedocumento")
                oPedido.Vkorg = ConfigurationSettings.AppSettings("Organizacionventas")
                oPedido.Kunnr = oOficina.OVENV_NRO_CLIE_PADRE
                oPedido.Kunag = oOficina.OVENV_NRO_CLIE_HIJO
                oPedido.Vtweg = ConfigurationSettings.AppSettings("Canaldistribucion")
                oPedido.Spart = ConfigurationSettings.AppSettings("Sector")
                oPedido.Vkbur = oOficina.OVENC_CODIGO
                oPedido.Menge = 1

                oPedido.Matnr = CheckStr(dtDetalle.Rows(i)("ARTICULO"))
                oPedido.Vkaus = CheckStr(dtDetalle.Rows(i)("UTILIZACION"))

                If arrayPedido.Count > 0 Then

                    For ii As Integer = 0 To arrayPedido.Count - 1
                        Dim pedido As PedidoSiscad = CType(arrayPedido(ii), PedidoSiscad)

                        If oPedido.Matnr = pedido.Matnr And oPedido.Vkaus = pedido.Vkaus Then
                            oPedido.Menge = pedido.Menge + 1
                            arrayPedido.RemoveAt(ii)
                            Exit For
                        End If
                    Next

                End If

                arrayPedido.Add(oPedido)

                '3.Obtener Lista Materiales Sap
                oMaterial.Matnr = CheckStr(dtDetalle.Rows(i)("ARTICULO"))
                oMaterial.Sernr = CheckStr(dtDetalle.Rows(i)("SERIE")).PadLeft(18, "0")
                oMaterial.Vkaus = CheckStr(dtDetalle.Rows(i)("UTILIZACION"))

                arrayMaterial.Add(oMaterial)

                '4.Obtener Detalle Orden BD Siscad
                Dim oOrden As New OrdenVentaSiscad

                oOrden.CodigoMaterial = CheckStr(dtDetalle.Rows(i)("ARTICULO"))
                oOrden.PuntoVenta = PuntoVenta
                oOrden.ListaPrecio = CheckStr(dtDetalle.Rows(i)("UTILIZACION"))
                oOrden.Precio = CheckDecimal(dtDetalle.Rows(i)("SUBTOTAL")) + CheckDecimal(dtDetalle.Rows(i)("IMPUESTO1"))
                oOrden.NroTelefono = FormatoTelefono(CheckStr(dtDetalle.Rows(i)("NUMERO_TELEFONO")))

                If oOrden.CodigoMaterial.StartsWith("PS") Then
                    idx = idx + 1
                    oOrden.Serie = CheckStr(dtDetalle.Rows(i)("SERIE"))
                    oOrden.Identificador = idx
                Else
                    If arrayOrden.Count > 0 Then
                        For Each chip As OrdenVentaSiscad In arrayOrden
                            If chip.CodigoMaterial.StartsWith("PS") And chip.NroTelefono = oOrden.NroTelefono Then
                                oOrden.Identificador = chip.Identificador
                                Exit For
                            End If
                        Next
                    End If
                    oOrden.Serie = CheckStr(dtDetalle.Rows(i)("SERIE")).Substring(3)
                End If

                arrayOrden.Add(oOrden)
            Next

            blnFound = True

        Catch ex As Exception
            blnFound = False
        Finally
            oConsultaSap = Nothing
            dsPedido = Nothing
            dtCabecera = Nothing
            dtDetalle = Nothing
        End Try

        Return blnFound
    End Function

    Private Sub RollBackVentaSAP(ByVal nroPedido As String)

        Dim oficina As String
        Dim arrCabecera(49) As String

        Dim oConsultarSap As New SapGeneralNegocios
        Dim bProceso, bProcesoBoleta As Boolean

        oficina = hidOfVenta.Value

        Dim dsOficina As New DataSet
        dsOficina = oConsultarSap.ConsultarParametrosOfVenta(oficina)
        Dim canal As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG")))
        Dim orgVenta As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG")))

        arrCabecera(0) = nroPedido
        arrCabecera(1) = "ELIM"
        arrCabecera(2) = oficina
        arrCabecera(48) = orgVenta
        arrCabecera(49) = canal
        Dim strCabecera As String = Join(arrCabecera, ";")

        oConsultarSap.RealizarPedido(strCabecera, "", "", "", "", "", "", "", "", "", "", "", 0)
    End Sub

    Private Function GenerarCadenaCabecera() As String
        Dim oSolicitud As SolicitudPersona = CType(Session("SolicitudSelected"), SolicitudPersona)

        Dim oConsultarSap As New SapGeneralNegocios

        Dim oficina As String = hidOfVenta.Value
        Dim tipoDocCliente As String = oSolicitud.TDOCC_CODIGO 'hidTipoDoc.Value
        Dim nroDocCliente As String = oSolicitud.CLIEC_NUM_DOC 'txtNumDoc.Text
        Dim codVendedor As String = hidVendedor.Value
        Dim tipoVenta As String = hidTipoVenta.Value
        Dim tipoCliente As String = hidTipoCliente.Value
        Dim tipoOperacion As String = hidTipoOperacion.Value
        Dim tipoDocVenta As String = ""

        Dim dsClasePedido As New DataSet
        dsClasePedido = oConsultarSap.ConsultarTipoDocumentoOfVenta(oficina)
        Dim arrayTipoDocVenta() As String = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPreRen" & tipoDocCliente).Split(CChar(","))
        For Each tipoDocVentaTmp As String In arrayTipoDocVenta
            If tipoDocVenta <> "" Then
                Exit For
            End If
            For Each rowTmp As System.Data.DataRow In dsClasePedido.Tables(0).Rows
                If CheckStr(rowTmp.Item("AUART")) = tipoDocVentaTmp Then
                    tipoDocVenta = tipoDocVentaTmp
                    Exit For
                End If
            Next
        Next

        Dim dsOficina As New DataSet
        dsOficina = oConsultarSap.ConsultarParametrosOfVenta(oficina)
        Dim canal As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG")))
        Dim orgVenta As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG")))

        Dim moneda As String = ConfigurationSettings.AppSettings("ExpressMoneda") '"L"
        Dim totalSinIGV As String = hidPrecioSubTotal.Value
        Dim totalConIGV As String = hidPrecioTotal.Value
        Dim totalIGV As String = CStr(CheckDecimal(hidPrecioTotal.Value) - CheckDecimal(hidPrecioSubTotal.Value))

        ' CABECERA
        Dim arrayCabecera(49) As String

        'arrayCabecera(0) = ""                        'Documento
        arrayCabecera(1) = tipoDocVenta               'Tipo_Documento
        arrayCabecera(2) = oficina                    'Oficina_Venta
        arrayCabecera(3) = Now.ToString("dd/MM/yyyy") 'Fecha_Documento
        arrayCabecera(4) = tipoDocCliente             'Tipo_Doc_Cliente
        arrayCabecera(5) = nroDocCliente              'Cliente
        'arrayCabecera(6) = ""                        'Augru
        arrayCabecera(7) = moneda                     'Moneda
        'arrayCabecera(8) = ""                        'Tipo_Operacion (Codigo Comercial)
        arrayCabecera(9) = totalSinIGV                'Total_Mercaderia
        arrayCabecera(10) = totalIGV                  'Total_Impuesto
        arrayCabecera(11) = totalConIGV               'Total_Documento
        'arrayCabecera(12) = ""                       'Fecha_Registro
        'arrayCabecera(13) = ""                       'Impreso
        'arrayCabecera(14) = ""                       'Observacion1
        'arrayCabecera(15) = ""                       'Observacion2
        arrayCabecera(16) = tipoVenta                 'Tipo_Venta
        'arrayCabecera(17) = ""                       'Numero_Contrato
        'arrayCabecera(18) = ""                       'Nro_Referencia
        'arrayCabecera(19) = ""                       'Usuario_Registro
        'arrayCabecera(20) = ""                       'Anulado
        'arrayCabecera(21) = ""                       'Documento_Origen
        'arrayCabecera(22) = ""                       'Fecha_Vta_Origen
        'arrayCabecera(23) = ""                       'Nro_Refer_Origen
        'arrayCabecera(24) = ""                       'Nro_Cuotas
        'arrayCabecera(25) = ""                       'Nro_Clarify
        'arrayCabecera(26) = ""                       'Estado
        arrayCabecera(27) = codVendedor               'Vendedor
        'arrayCabecera(28) = ""                       'Mala_Venta
        arrayCabecera(29) = tipoOperacion             'Clase_Venta (Siempre Alta Nueva)
        'arrayCabecera(30) = ""                       'Des_Clase_Venta
        'arrayCabecera(31) = ""                       'Mot_Mala_Venta
        'arrayCabecera(32) = ""                       'Telefono
        'arrayCabecera(33) = ""                       'Referencia
        'arrayCabecera(34) = ""                       'Historico
        'arrayCabecera(35) = ""                       'Numero_Hdc
        'arrayCabecera(36) = ""                       'Nro_Pcs_Asociado
        'arrayCabecera(37) = ""                       'Nro_Ped_Tg
        'arrayCabecera(38) = ""                       'Nro_Acuer_Alqu
        'arrayCabecera(39) = ""                       'Trans_Gratuita
        'arrayCabecera(40) = ""                       'Fidelizacion
        'arrayCabecera(41) = ""                       'Vendedor_Dni
        'arrayCabecera(42) = ""                       'Nro_Solicitud
        'arrayCabecera(43) = ""                       'Serie_Recibida
        'arrayCabecera(44) = ""                       'Operador
        'arrayCabecera(45) = ""                       'Tipo_Prod_Operad
        'arrayCabecera(46) = ""                       'Clase_Ped_Devol
        'arrayCabecera(47) = ""                       'Nro_Factura
        arrayCabecera(48) = orgVenta                  'Orgvnt
        arrayCabecera(49) = canal                     'Canal

        oConsultarSap = Nothing
        dsClasePedido = Nothing
        dsOficina = Nothing
        Return Join(arrayCabecera, ";")
    End Function

    Private Function GenerarCadenaDetalle() As String
        Dim cadenaDetalle As String = ""
        Dim nroPlanes As Integer = hidProcesarPlanes.Value.Split(CChar("|")).Length - 1 'GENERAR ACUERDO (NO TODOS LOS PLANES)

        Dim oConsultaExpress As New VentaExpressNegocios

        ' DETALLE PLAN
        Dim arrayDetalle(28) As String

        Dim arrayPlanes() As String = hidProcesarPlanes.Value.Split(CChar("|"))
        For i As Integer = 1 To arrayPlanes.Length - 1
            Dim plan As String = arrayPlanes(i)

            Dim arrayItems() As String = plan.Split(";"c)
            Dim consecutivo As String = arrayItems(0).Split(","c)(1)
            Dim cantidad As Integer = 1

            Dim codigoPlan As String = hidPlanes.Value.Split("|"c)(CheckInt(consecutivo)).Split(","c)(0)
            Dim descPlan As String = arrayItems(1).Split(","c)(1)

            'Obtener el Cargo Fijo del Plan y sumarlo
            Dim cargoFijoPlan As Decimal = CheckDecimal(oConsultaExpress.ObtenerCargoFijoPlan(codigoPlan))
            cargoFijoTotal = cargoFijoTotal + cargoFijoPlan

            Dim tipoVentaExpress As String = CheckStr(Session("TipoVentaExpress"))
            If tipoVentaExpress <> ConfigurationSettings.AppSettings("ExpressModoPrepagoRenovacion") Then
                ' Iccid
                arrayDetalle(0) = ""                             'Documento
                arrayDetalle(1) = Right("000000" + CheckStr(consecutivo), 6)                 'Consecutivo (codigo 6 digitos)
                arrayDetalle(2) = arrayItems(3).Split(","c)(1)   'Articulo
                arrayDetalle(3) = arrayItems(4).Split(","c)(1)   'Des_Articulo
                arrayDetalle(4) = arrayItems(11).Split(","c)(1)  'Utilizacion
                arrayDetalle(5) = arrayItems(12).Split(","c)(1)  'Des_Utilizacion
                arrayDetalle(6) = arrayItems(9).Split(","c)(1)   'Campana
                arrayDetalle(7) = arrayItems(10).Split(","c)(1)  'Des_Campana
                arrayDetalle(8) = Right("000000000000000000" + arrayItems(2).Split(","c)(1), 18) 'arrayItems(2).Split(","c)(1)   'Serie
                arrayDetalle(9) = CheckStr(cantidad)             'Cantidad
                arrayDetalle(10) = arrayItems(13).Split(","c)(3) 'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
                arrayDetalle(11) = arrayItems(13).Split(","c)(4) 'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
                arrayDetalle(12) = arrayItems(13).Split(","c)(1) 'Descuento
                arrayDetalle(13) = ""                            'Porc_Descuento
                arrayDetalle(14) = ""                            'Descuento_Adic
                arrayDetalle(15) = arrayItems(13).Split(","c)(4) 'Subtotal (igual q precio total * Cantidad)
                arrayDetalle(16) = CheckStr(CheckDecimal(arrayItems(13).Split(","c)(2)) - CheckDecimal(arrayItems(13).Split(","c)(4))) 'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
                arrayDetalle(17) = ""                            'Impuesto2
                arrayDetalle(18) = codigoPlan                    'Plan_Tarifario
                arrayDetalle(19) = descPlan                      'Des_Plan_Tarifar
                arrayDetalle(20) = ""                            'Centro_Costo
                arrayDetalle(21) = ""                            'Motivo_Devolucio
                arrayDetalle(22) = ""                            'Asociado
                arrayDetalle(23) = ""                            'Consecutivo_Padr
                arrayDetalle(24) = ""                            'Articulo_Asociac
                arrayDetalle(25) = arrayItems(5).Split(","c)(1)  'Numero_Telefono
                arrayDetalle(26) = ""                            'Nro_Clarify
                arrayDetalle(27) = ""                            'Dev_Componente
                arrayDetalle(28) = ""                            'Serie_Ant

                If cadenaDetalle.Length > 0 Then
                    cadenaDetalle = cadenaDetalle & "|" & Join(arrayDetalle, ";")
                Else
                    cadenaDetalle = Join(arrayDetalle, ";")
                End If

                consecutivo = CStr(CheckInt(consecutivo) + nroPlanes)
            End If

            ' Imei
            arrayDetalle(0) = ""                             'Documento
            arrayDetalle(1) = Right("000000" + CheckStr(consecutivo), 6)                    'Consecutivo
            arrayDetalle(2) = arrayItems(7).Split(","c)(1)   'Articulo
            arrayDetalle(3) = arrayItems(8).Split(","c)(1)   'Des_Articulo
            arrayDetalle(4) = arrayItems(11).Split(","c)(1)  'Utilizacion
            arrayDetalle(5) = arrayItems(12).Split(","c)(1)  'Des_Utilizacion
            arrayDetalle(6) = arrayItems(9).Split(","c)(1)   'Campana
            arrayDetalle(7) = arrayItems(10).Split(","c)(1)  'Des_Campana
            arrayDetalle(8) = Right("000000000000000000" + arrayItems(6).Split(","c)(1), 18)  'arrayItems(6).Split(","c)(1)   'Serie
            arrayDetalle(9) = CheckStr(cantidad)             'Cantidad
            arrayDetalle(10) = arrayItems(13).Split(","c)(7) 'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
            arrayDetalle(11) = arrayItems(13).Split(","c)(8) 'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
            arrayDetalle(12) = arrayItems(13).Split(","c)(5) 'Descuento
            arrayDetalle(13) = ""                            'Porc_Descuento
            arrayDetalle(14) = ""                            'Descuento_Adic
            arrayDetalle(15) = arrayItems(13).Split(","c)(8) 'Subtotal (igual q precio total * Cantidad)
            arrayDetalle(16) = CheckStr(CheckDecimal(arrayItems(13).Split(","c)(6)) - CheckDecimal(arrayItems(13).Split(","c)(8))) 'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
            arrayDetalle(17) = ""                            'Impuesto2
            arrayDetalle(18) = codigoPlan                    'Plan_Tarifario
            arrayDetalle(19) = descPlan                      'Des_Plan_Tarifar
            arrayDetalle(20) = ""                            'Centro_Costo
            arrayDetalle(21) = ""                            'Motivo_Devolucio
            arrayDetalle(22) = ""                            'Asociado
            arrayDetalle(23) = ""                            'Consecutivo_Padr
            arrayDetalle(24) = ""                            'Articulo_Asociac
            arrayDetalle(25) = arrayItems(5).Split(","c)(1)  'Numero_Telefono
            arrayDetalle(26) = ""                            'Nro_Clarify
            arrayDetalle(27) = ""                            'Dev_Componente
            arrayDetalle(28) = ""                            'Serie_Ant

            If cadenaDetalle.Length > 0 Then
                cadenaDetalle = cadenaDetalle & "|" & Join(arrayDetalle, ";")
            Else
                cadenaDetalle = Join(arrayDetalle, ";")
            End If
        Next
        oConsultaExpress = Nothing

        ' Ordenar el array de Detalle segun el parametro "consecutivo"
        Dim sortCadena() As String = cadenaDetalle.Split("|"c)
        Dim unsortCadena() As String = cadenaDetalle.Split("|"c)
        For Each cadenaTmp As String In unsortCadena
            Dim idx As Integer = CheckInt(cadenaTmp.Split(";"c)(1)) - 1
            sortCadena(idx) = cadenaTmp
        Next

        Return Join(sortCadena, "|"c)
    End Function

    Private Function RegistrarClienteSAP() As Boolean
        Dim DclienteSAP(64) As String

        Dim tipoClienteSAP As String = ConfigurationSettings.AppSettings("constCodTipoProductoConSAP")
        Dim oSolicitudPersona As SolicitudPersona = CType(Session("SolicitudSelected"), SolicitudPersona)

        DclienteSAP(0) = oSolicitudPersona.CLIEC_NUM_DOC ' Numero Documento Identidad
        DclienteSAP(1) = oSolicitudPersona.TDOCC_CODIGO ' Codigo Tipo Documento Identidad
        DclienteSAP(2) = tipoClienteSAP

        DclienteSAP(3) = Left(oSolicitudPersona.CLIEV_NOMBRE, 40)
        DclienteSAP(4) = Left(oSolicitudPersona.CLIEV_APE_PAT, 40)
        DclienteSAP(5) = Left(oSolicitudPersona.CLIEV_APE_MAT, 40) + "-"
        DclienteSAP(6) = "" ' Razon Social Cliente

        DclienteSAP(7) = "01/01/1900" ' Fecha nacimiento Cliente
        DclienteSAP(8) = ""
        DclienteSAP(9) = ""
        DclienteSAP(10) = ""
        DclienteSAP(11) = " "
        DclienteSAP(12) = "00"
        DclienteSAP(13) = ""

        DclienteSAP(14) = Left(Trim(oSolicitudPersona.CLIEV_PRE_DIR) & " " & Trim(oSolicitudPersona.CLIEV_DIRECCION), 40) ' Direccion Legal Cliente
        DclienteSAP(15) = "" ' UBIGEO Direccion Legal del Cliente

        DclienteSAP(18) = "" 'strCodTipoDocumentoRepLegal
        DclienteSAP(19) = "" 'strNumeroDocumentoRepLegal
        DclienteSAP(20) = "" 'strNombreRepLegal
        DclienteSAP(21) = "" 'strApellidoPaternoRepLegal
        DclienteSAP(22) = "" 'strApellidoManternoRepLegal
        DclienteSAP(23) = ""
        DclienteSAP(24) = "" 'strCodTipoDocumentoContacto
        DclienteSAP(25) = "" 'strNumeroDocumentoContacto	
        DclienteSAP(26) = "" 'strNombreContacto 
        DclienteSAP(27) = "" 'strApellidoPaternoContacto  
        DclienteSAP(28) = "" 'strApellidoManternoContacto 
        DclienteSAP(29) = "" 'strCargoContacto   

        DclienteSAP(31) = ""
        DclienteSAP(32) = ""
        DclienteSAP(33) = ""
        DclienteSAP(34) = ""
        DclienteSAP(35) = ""
        DclienteSAP(36) = "0.00"
        DclienteSAP(37) = "0.00"
        DclienteSAP(38) = ""
        DclienteSAP(39) = ""
        DclienteSAP(40) = "" 'CODIGO TIPO DE MONEDA
        DclienteSAP(41) = "0.00"
        DclienteSAP(42) = ""
        DclienteSAP(43) = ""
        DclienteSAP(44) = ""
        DclienteSAP(45) = ""
        DclienteSAP(46) = ""
        DclienteSAP(47) = ""
        DclienteSAP(48) = ""
        DclienteSAP(49) = ""
        DclienteSAP(50) = ""
        DclienteSAP(51) = ""
        DclienteSAP(52) = ""
        DclienteSAP(53) = ""
        DclienteSAP(54) = "" 'Referencia Direccion Legal Cliente
        DclienteSAP(55) = ""
        DclienteSAP(56) = "01"
        DclienteSAP(57) = ""
        DclienteSAP(58) = "00"
        DclienteSAP(59) = "00"
        DclienteSAP(60) = "0"
        DclienteSAP(61) = ""
        DclienteSAP(62) = ""

        Dim ptoVenta As String = CStr(oSolicitudPersona.OVENC_CODIGO)

        Dim res As Boolean
        Dim dt As New DataSet
        Dim oSapNegocios As New SapGeneralNegocios
        dt = oSapNegocios.Set_ActualizaCreaCliente(ptoVenta, DclienteSAP)
        Dim strMensaje As String = ""

        For i As Integer = 0 To dt.Tables(1).Rows.Count - 1
            If CheckStr(dt.Tables(1).Rows(i).Item("TYPE")) = "E" Then
                strMensaje = CheckStr(dt.Tables(1).Rows(i).Item("MESSAGE"))
            End If
        Next

        If Not strMensaje.Equals(String.Empty) Then
            hidMsg.Value = String.Format("Error. Cliente no puede ser registrado en SAP. {0}.", strMensaje)
            Return False
        End If
        Return True
    End Function
#End Region

	Private Sub EnviarCorreoSiscad(ByVal oOficina As PuntoVenta, ByVal listaSeriesSinPrecio As ArrayList, ByVal listaSeriesSinSKU As ArrayList)

		Try
			Dim strMensaje As String
			Dim strListaDistribucion As String
			Dim strCorreoAlerta As String
			Dim strMaterial As String
			Dim strListaPrecios As String

			'Determina Mensaje Series sin precio
			For Each orden As OrdenVentaSiscad In listaSeriesSinPrecio
				strMaterial = orden.CodigoMaterial & " - " & orden.DescMaterial
				strListaPrecios = orden.ListaPrecio & " - " & orden.DesListaPrecio
				strMensaje += String.Format("No se ha encontrado el precio para el material {0} con lista de precios {1} en el punto de venta {2}.", strMaterial, strListaPrecios, oOficina.OVENV_DESCRIPCION) + "|"
			Next

			'Determina Mensaje Precio sin SKU
			For Each orden As OrdenVentaSiscad In listaSeriesSinSKU
				strMensaje += String.Format("No se tiene configurado un SKU para el precio S/. {0} en la cadena {1}.", orden.Precio, oOficina.CANAV_DESCRIPCION) + "|"
			Next

			If strMensaje <> "" Then
				Dim strHTMLCuerpo As String
				Dim arrMensaje() As String
				Dim i As Integer

				arrMensaje = strMensaje.Split("|")
				strHTMLCuerpo = "<HTML>"
				strHTMLCuerpo = strHTMLCuerpo & "<HEAD></HEAD><BODY><table>"
				For i = 0 To UBound(arrMensaje)
					strHTMLCuerpo = strHTMLCuerpo & "<tr><td>" & arrMensaje(i) & "</tr></td>"
				Next
				strHTMLCuerpo = strHTMLCuerpo & "</table></BODY></HTML>"

				strCorreoAlerta = ObtenerCorreoAlertasSiscad(oOficina.OVENC_CODIGO)
				strListaDistribucion = ObtenerListaDistribucion(ConfigurationSettings.AppSettings("CodParam_CorreoAdmCadenas"))

				sisact_Mail.EnviarEmail(ConfigurationSettings.AppSettings("strEmailRemitente"), strListaDistribucion & ";" & strCorreoAlerta, "", "", ConfigurationSettings.AppSettings("AsuntoCorreoSISCADAlertas"), strHTMLCuerpo, "")
			End If

		Catch ex As Exception
		End Try
	End Sub
	Private Function ObtenerCorreoAlertasSiscad(ByVal codPdv As String) As String

		Dim strCorreos As String
		Try
			Dim oVentaNegocios As New VentaExpressNegocios
			Dim oAlerta As AlertaSiscad
			oAlerta = oVentaNegocios.CorreoAlertasSiscad(codPdv)
			strCorreos = oAlerta.MAILJEFE & ";" & oAlerta.MAILSECTORISTA
		Catch ex As Exception
			strCorreos = ""
		End Try
		Return strCorreos
	End Function
	Private Function ObtenerListaDistribucion(ByVal key As String) As String

		Dim strCorreos As String
		Try
			Dim oVentaNegocios As New VentaExpressNegocios
			strCorreos = oVentaNegocios.ConsultaParamConfigSiscad(key)
		Catch ex As Exception
			strCorreos = ""
		End Try
		Return strCorreos
	End Function


#Region " Auditoria"
	Private Sub AuditoriaRealizarPedido(ByVal desTrans As String)
		Try
			Dim nombreHost As String = System.Net.Dns.GetHostName
			Dim nombreServer As String = System.Net.Dns.GetHostName
			Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
			Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
			Dim usuario_id As String = CurrentUser
			Dim ipcliente As String = CurrentTerminal

			Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
			Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
			Dim strCodTrans As String = ConfigurationSettings.AppSettings("ExpressAuditTransVentaPedidoCod")

			Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
			If Not auditoriaGrabado Then
				Throw New Exception("Error. No se registro en Auditoria la Grabacion Pedido de Venta Prepago.")
			End If
		Catch ex As Exception
		End Try
	End Sub
#End Region

End Class
