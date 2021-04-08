Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Common.Funciones
Public Class sisact_valida_vendedor
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClave As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPaginaOrigen As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents btnValidar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents txtNumeroDocId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtClaveAcceso As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMensajeError As System.Web.UI.WebControls.Label

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
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("Log_ValidacionUsuarioVenta")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If (Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Not IsPostBack Then
            hidPaginaOrigen.Value = CheckStr(Request.QueryString("PO"))
        Else

            Select Case hidRequest.Value
                Case "Buscar"
                    Call ValidacionVenta()
            End Select

        End If
    End Sub

    Private Sub ValidacionVenta()
        Dim idLog As String
        Dim oConsultaExpressPorta As New VentaExpressNegocios

        lblMensajeError.Text = ""
        idLog = CurrentUser

        Dim PO_VALO_VALI As Integer
        Dim PI_VEN_TIPO_DOCU As String = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI")
        Dim PI_VEN_NUME_DOCU As String = txtNumeroDocId.Text
        Dim PI_VEN_USUA As String = CurrentUser
        Dim PI_VEN_CLAV_ACTU As String = (hidClave.Value).ToUpper()
        Dim PI_CODI_APLI As Integer = CheckInt(ConfigurationSettings.AppSettings("CodigoAplicacion"))
        Dim PO_VENDEDOR As String

        Try

            Dim PI_VEN_PDV As String = ObtenerOficina().OVENC_CODIGO

            objLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio ValidacionVenta()")
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp PI_VEN_TIPO_DOCU: " & PI_VEN_TIPO_DOCU)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp PI_VEN_NUME_DOCU: " & PI_VEN_NUME_DOCU)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp PI_VEN_PDV: " & PI_VEN_PDV)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp PI_VEN_USUA: " & PI_VEN_USUA)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp PI_VEN_CLAV_ACTU: " & PI_VEN_CLAV_ACTU)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp PI_CODI_APLI: " & PI_CODI_APLI)

            PO_VALO_VALI = oConsultaExpressPorta.ValidaClaveVendedor(PI_VEN_TIPO_DOCU, _
                                                                     PI_VEN_NUME_DOCU, _
                                                                     PI_VEN_PDV, _
                                                                     PI_VEN_USUA, _
                                                                     PI_VEN_CLAV_ACTU, _
                                                                     PI_CODI_APLI, PO_VENDEDOR)

            objLog.Log_WriteLog(strArchivo, idLog & " - " & "out PO_VALO_VALI: " & PO_VALO_VALI)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "out PO_VENDEDOR: " & PO_VENDEDOR)


            If PO_VALO_VALI <> CheckInt(ConfigurationSettings.AppSettings("codExitoValidaVendedor")) Then
                Select Case CheckStr(PO_VALO_VALI)
                    Case ConfigurationSettings.AppSettings("codErrorValidaVendedor_2")
                        lblMensajeError.Text = ConfigurationSettings.AppSettings("msgErrorValidaVendedor_2")
                    Case ConfigurationSettings.AppSettings("codErrorValidaVendedor_3")
                        lblMensajeError.Text = ConfigurationSettings.AppSettings("msgErrorValidaVendedor_3")
                    Case ConfigurationSettings.AppSettings("codErrorValidaVendedor_4")
                        lblMensajeError.Text = ConfigurationSettings.AppSettings("msgErrorValidaVendedor_4")
                    Case ConfigurationSettings.AppSettings("codErrorValidaVendedor_5")
                        lblMensajeError.Text = ConfigurationSettings.AppSettings("msgErrorValidaVendedor_5")
                    Case ConfigurationSettings.AppSettings("codErrorValidaVendedor_6")
                        lblMensajeError.Text = ConfigurationSettings.AppSettings("msgErrorValidaVendedor_6")
                    Case Else
                        lblMensajeError.Text = ConfigurationSettings.AppSettings("msgErrorValidaVendedor")
                End Select
            End If
        Catch ex As Exception
            lblMensajeError.Text = ex.Message.ToString()
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "Error: " & ex.Message.ToString() & " " & ex.StackTrace.ToString())
        Finally
            oConsultaExpressPorta = Nothing
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin ValidacionVenta()")
        End Try

        If PO_VALO_VALI = CheckInt(ConfigurationSettings.AppSettings("codExitoValidaVendedor")) Then
            Dim oVendedor As New Vendedor
            oVendedor.TipoDocumento = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI")
            oVendedor.NumeroDocumento = PI_VEN_NUME_DOCU
            oVendedor.Nombre = PO_VENDEDOR
            Session("DatosVendedor") = oVendedor

            Dim paginaDestino As String = ""
            Select Case hidPaginaOrigen.Value
                Case "VE"
                    paginaDestino = "sisact_renovacion_postpago.aspx?flagVendedorValido=S" + "&VenDesc=" + PO_VENDEDOR + "&VendDoc=" + PI_VEN_NUME_DOCU
            End Select
            If paginaDestino <> "" Then
                'Response.Redirect(paginaDestino)
                Page.RegisterStartupScript("a", "<script>f_accept_validate('" & paginaDestino & "');</script>")

            End If
        End If
    End Sub

    Private Function ObtenerOficina() As PuntoVenta
        Dim oPuntoVenta As New PuntoVenta
        If (Not Session("DatosOficina") Is Nothing) Then
            oPuntoVenta = CType(Session("DatosOficina"), PuntoVenta)
        Else
            Dim oMaestro As New MaestroNegocio
            Dim oUsuario As Usuario

            oUsuario = oMaestro.ObtenerUsuarioLogin(Me.CurrentUser)
            oMaestro = Nothing

            ' Buscar Punto de Venta
            Dim listaPuntoVenta As ArrayList = New MaestroNegocio().ListaPDVUsuario(oUsuario.UsuarioId, "")

            If listaPuntoVenta.Count = 0 Then
                Throw New Exception("Error: Usuario no pertenece a algún Punto de Venta.")
            End If

            ' Guardar los datos escogidos a Session
            oPuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)
        End If
        Session("DatosOficina") = oPuntoVenta
        Return oPuntoVenta
    End Function

End Class
