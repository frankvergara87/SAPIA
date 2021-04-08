Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_lista_precios
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
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("sisact_ifr_consulta_lista_precios_chip repuesto")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
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

    'PROY-24740
    Private Sub ConsultarListaPrecios()
        Dim idLog As String = ""
        Dim param() As String = hidParametros.Value.Split(","c)
        Dim listaPrecios As New ArrayList
        Dim oConsultarSap As New SapGeneralNegocios
        Dim strListaPrecio As String = String.Format("{0},{1}", "00", ConfigurationSettings.AppSettings("Seleccionar"))

        Dim listaSec As New ArrayList
        Dim oConsultaSolicitud As New SolicitudNegocios
        Dim oSolicitud As New SolicitudPersona
        Dim oConsultaMSS As New ConsultaMsSapNegocio
        Dim tipoOperacion As String
        Dim oVentaExpress As New VentaExpressNegocios


        Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("constTipoOperacionREPO")
        Dim strTipoPlazo As String = ConfigurationSettings.AppSettings("constPlazoRepo")
        Dim strCampanaSap As String = ConfigurationSettings.AppSettings("strCampanaRepo")
        Try

            Dim strHLR As String = param(6)
            If strHLR <> "" Then
                If strHLR.Length = 2 Then
                    strHLR = Right(String.Format("{0}{1}", "00", strHLR.Substring(1)), 2)
                Else
                    strHLR = Right(String.Format("{0}{1}", "00", strHLR), 2)
                End If
                Dim strHLRiccid As String = String.Format("{0}{1}", "0", param(2).Substring(7, 1))

                Dim nHLRiccid As Integer = CheckInt(param(2).Substring(7, 1))

                objLog.Log_WriteLog(strArchivo, "- ConsultarListaPrecios nHLRiccid:")

                Dim oListaHLR As ArrayList = oVentaExpress.ListarEquivalenciaHLRyUDB(0, nHLRiccid)
                Dim nUDB As Integer = CheckInt(ConfigurationSettings.AppSettings("Nuevo_Hlr"))

                If oListaHLR.Count > 0 Then

                    If Not CheckInt(CType(oListaHLR(0), ItemGenerico).Codigo2) = CheckInt(nUDB) Then

                        objLog.Log_WriteLog(strArchivo, String.Format("{0}{1}", "Codigo 2 : ", CType(oListaHLR(0), ItemGenerico).Codigo))
                        objLog.Log_WriteLog(strArchivo, String.Format("{0}{1}", "nUDB : ", nUDB))

                        If Not CheckInt(CType(oListaHLR(0), ItemGenerico).Codigo) = CheckInt(strHLR) Then
                            objLog.Log_WriteLog(strArchivo, String.Format("{0}{1}", "Codigo: ", CType(oListaHLR(0), ItemGenerico).Codigo))
                            objLog.Log_WriteLog(strArchivo, String.Format("{0}{1}", "strHLR : ", strHLR))

                            Throw New Exception(String.Format("{0}{1}{2}{3}{4}{5}{6}{7}", "El HLR del telefono: ", CStr(strHLR), Chr(13), " No pertenece al chip ", param(2), " con HLR ", strHLRiccid, " (HLR: Posicion 8 del ICCID)"))
                        Exit Sub

                        End If
                    End If

                    End If
            Else
                Throw New Exception("No existe HLR para el telefono.")
            End If

            listaPrecios = oConsultaMSS.ConsultarListaPrecio("", param(0), param(11), "", param(3), strCampanaSap, strTipoOperacion, strTipoPlazo, String.Empty)

            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}", idLog, "Inicio ConsultarListaPrecios"))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp p_tipo_venta: ", param(0)))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp p_plan_tarif: ", ""))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp p_codigo_material ICCID: ", param(3)))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp p_codigo_campania: ", strCampanaSap))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp p_fecha: ", Now.ToString("yyyy/MM/dd")))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp p_tipo_operacion: ", strTipoOperacion))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp p_plazo_acuerdo: ", strTipoPlazo))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp strCanalSap: ", param(11)))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp strTipoDocVentaSap: ", param(9)))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "inp strOficina: ", param(10)))

            For Each item As ItemGenerico In listaPrecios
                strListaPrecio = String.Format("{0};{1},{2}", strListaPrecio, CheckStr(item.Codigo), CheckStr(item.Descripcion))
            Next

            hidDatosRetorno.Value = strListaPrecio
            hidResponse.Value = "RetornarDatos"

            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}{2}", idLog, "out DatosRetorno: ", hidDatosRetorno.Value))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}", idLog, "Fin ConsultarListaPrecios"))

        Catch ex As Exception
            hidMsg.Value = String.Format("{0} {1}", "Error .", ex.Message)
            hidResponse.Value = "Error"
        End Try
    End Sub

    'Private Function ObtenerCampanaSap(ByVal strCampana As String) As String
    '    Dim strCampanaSap As String
    '    strCampanaSap = New ConsumerNegocio().ObtenerCampanaSap(strCampana)
    '    Return strCampanaSap
    'End Function
End Class
