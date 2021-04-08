Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO
Public Class sisact_ifr_consulta_lista_precios_ICCID
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidParametros As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosRetorno As System.Web.UI.HtmlControls.HtmlInputHidden
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
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("sisact_ifr_consulta_lista_precios_chip repuesto dac")
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
        hidParametros.Value = Request.QueryString("params")
        ConsultarListaPrecios()
    End Sub

    Private Sub ConsultarListaPrecios()
        Dim idLog As String = ""
        Dim param() As String = hidParametros.Value.Split(","c)
        Dim listaPrecios As New ArrayList
        Dim oConsultarSap As New SapGeneralNegocios
        Dim strListaPrecio As String = "00" & "," & ConfigurationSettings.AppSettings("Seleccionar")
        Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("constTipoOperacionREPO")
        Dim strTipoPlazo As String = ConfigurationSettings.AppSettings("constPlazoRepo")
        Dim strCampanaSap As String = ConfigurationSettings.AppSettings("strCampanaRepo")

        Dim listaSec As New ArrayList
        Dim oConsultaSolicitud As New SolicitudNegocios
        Dim oSolicitud As New SolicitudPersona
        Dim oConsultaMSS As New ConsultaMsSapNegocio
        Dim tipoOperacion As String


        Try
            ' strCampanaSap = ObtenerCampanaSap(param(4))

            listaPrecios = oConsultaMSS.ConsultarListaPrecio("", param(0), param(11), "", param(3), strCampanaSap, strTipoOperacion, strTipoPlazo, String.Empty)

            objLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio ConsultarListaPrecios")
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp p_tipo_venta: " & param(0))
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp p_plan_tarif: " & "")
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp p_codigo_material ICCID: " & param(3))
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp p_codigo_campania: " & strCampanaSap)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp p_fecha: " & Now.ToString("yyyy/MM/dd"))
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp p_tipo_operacion: " & strTipoOperacion)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp p_plazo_acuerdo: " & strTipoPlazo)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp strCanalSap: " & param(11))
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp strTipoDocVentaSap: " & param(9))
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "inp strOficina: " & param(10))

            For Each item As ItemGenerico In listaPrecios
                strListaPrecio = strListaPrecio & ";" & CheckStr(item.Codigo) & "," & CheckStr(item.Descripcion)
            Next

            hidDatosRetorno.Value = strListaPrecio
            hidResponse.Value = "RetornarDatos"

            objLog.Log_WriteLog(strArchivo, idLog & " - " & "out DatosRetorno: " & hidDatosRetorno.Value)
            objLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin ConsultarListaPrecios")
        Catch ex As Exception
            hidMsg.Value = "Error ." & ex.Message
            hidResponse.Value = "Error"
        End Try
    End Sub

    'Private Function ObtenerCampanaSap(ByVal strCampana As String) As String
    '    Dim strCampanaSap As String
    '    strCampanaSap = New ConsumerNegocio().ObtenerCampanaSap(strCampana)
    '    Return strCampanaSap
    'End Function
End Class

