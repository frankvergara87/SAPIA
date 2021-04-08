Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_iccid_Postpago
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidCodIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosRetorno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidHlr As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOficina As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUsoHLR As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim oLog As New SISACT_Log
    Dim oFile As String = oLog.Log_CrearNombreArchivo(ConfigurationSettings.AppSettings("constNameLogRepPostpago"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")

        If Session("codUsuarioSisact") Is Nothing Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            If Not IsPostBack Then
                Inicio()
            End If
        End If
    End Sub

    Private Sub Inicio()
        hidCodIccid.Value = Request.QueryString("codIccid")
        hidNroLinea.Value = Request.QueryString("nroLinea")
        hidHlr.Value = Request.QueryString("nroHLR")
        hidOficina.Value = Request.QueryString("Oficina")
        hidUsoHLR.Value = Request.QueryString("usaHLR")
        BuscarIccid()
    End Sub

    Private Sub BuscarIccid()
        Dim codIccid As String = Right("000000000000000000" & hidCodIccid.Value, 18)
        Dim nroLinea As String = hidNroLinea.Value
        Dim nroHLR As String = hidHlr.Value
        Dim Oficina As String = hidOficina.Value
        Dim usoHLR As String = hidUsoHLR.Value
        Dim strTipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("strPostpagoTipoOperacion")

        If codIccid <> "" Then
            Dim item As New ItemGenerico
            Dim oConsultaSap As New SapGeneralNegocios
            Dim oConsulta As New VentaExpressNegocios

            Try
                'Consulta Disponibilidad de Material en Sap
                item = oConsultaSap.ConsultarMaterial(codIccid)

                'Hlr de la Serie del Material
                Dim strHLR As String = codIccid.Substring(6, 2)

                'Si el Chip no se encuentra disponible en SAP  
                If CheckStr(item.Codigo) = "" Then
                    If usoHLR = "RP" Then
                        Throw New Exception("La serie del Equipo no es válida.")
                    Else
                        Throw New Exception("La serie del SIM no es válida.")
                    End If
                End If

                If usoHLR = "RP" Then
                    strTipoOperacion = ConfigurationSettings.AppSettings("constCodOperRenovacion")
                Else
                    'Si el tipo de HLR del nuevo chip NO coincide con el tipo de HLR anterior
                    If CheckStr(nroHLR) <> CheckStr(strHLR) Then
                        Throw New Exception("El HRL no coincide.")
                    End If
                End If

                'Validar si el Material se Encuentra Disponible en SISCAD
                Dim oficinaSiscad As PuntoVenta = oConsulta.ObtenerDatosOficinaventa(Oficina)

                If CheckStr(oficinaSiscad.OVENV_DESCRIPCION) <> "" Then
                    Dim estadoLibre As String = ConfigurationSettings.AppSettings("EstadoMaterial")
                    Dim estadoMaterial As String = oConsulta.ObtenerEstMat(codIccid, item.Codigo, Oficina)

                    If Not (estadoLibre = estadoMaterial) Then
                        Throw New Exception("La serie no se ha ingresado en el almacén del PDV en SISCAD y/o no se encuentra disponible para la venta.")
                    End If
                End If

                Dim fecha As String = CStr(DateTime.Now.Today)
                Dim listaMaterial As ArrayList = oConsultaSap.Get_ObtenerMaterialesPDV(strTipoOperacion, fecha, "", Oficina, strTipoVenta)
                Dim blnFound As Boolean = False

                'Si el Chip no pertenece al punto de venta  
                If listaMaterial.Count = 0 Then
                    If usoHLR = "RP" Then
                        Throw New Exception("El Equipo no pertenece al punto de venta.")
                    Else
                        Throw New Exception("El SIM no pertenece al punto de venta.")
                    End If

                End If

                For Each articulo As ItemGenerico In listaMaterial
                    If articulo.Codigo = item.Codigo Then
                        blnFound = True
                        Exit For
                    End If
                Next

                'Si el ICCID no pertenece al Tipo de Venta
                If Not blnFound Then
                    If usoHLR = "RP" Then
                        Throw New Exception("No pertenece al Tipo de venta Postpago, ni al tipo de operación Renovación.")
                    Else
                        Throw New Exception("No pertenece al Tipo de venta Postpago, ni al tipo de operación Chip Repuesto.")
                    End If
                End If

                hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion
                hidResponse.Value = "RetornarDatos"

            Catch ex As Exception

                Dim input As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", nroLinea, codIccid, Oficina, nroHLR, strTipoVenta, strTipoOperacion)

                oLog.Log_WriteLog(oFile, nroLinea & "- " & "Inicio Consultar Iccid")
                oLog.Log_WriteLog(oFile, nroLinea & "- " & "  Input --> " & input)
                oLog.Log_WriteLog(oFile, nroLinea & "- " & "  Error --> " & ex.Message)
                oLog.Log_WriteLog(oFile, nroLinea & "- " & "Fin Consultar Iccid")

                hidMsg.Value = "Error. " & ex.Message
                hidDatosRetorno.Value = ""
                hidResponse.Value = "RetornarDatos"

            Finally
                item = Nothing
                oConsultaSap = Nothing
                oConsulta = Nothing
            End Try
        End If
    End Sub

End Class
