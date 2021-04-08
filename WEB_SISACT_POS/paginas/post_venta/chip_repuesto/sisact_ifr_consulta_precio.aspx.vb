Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_precio
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidConsultaPrecio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRespuestaPrecio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOficina As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    'Dim oLog As New SISACT_Log
    'Dim oFile As String = oLog.Log_CrearNombreArchivo(ConfigurationSettings.AppSettings("constNameLogRepPostpago"))

    Dim objLog As New SISACT_Log
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("sisact_ifr_consulta_lista_precios_rp")

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
        hidConsultaPrecio.Value = Request.QueryString("params")
        hidTipoOficina.Value = Request.QueryString("tipoOficina")
        ConsultarPrecio()
    End Sub

    Private Sub ConsultarPrecio()
        Dim nroLinea As String
        Dim dblIccidPrecio As Decimal
        Dim dblIccidDescuento As Decimal
        Dim dblIccidPreIGV As Decimal
        Dim dblIccidTotal As Decimal
        Dim strConsulta As String = hidConsultaPrecio.Value
        Dim canal As String
        Dim orgVenta As String

        If strConsulta <> "" Then

            Dim param() As String = strConsulta.Split(CChar(","))
            Dim oConsultarSap As New SapGeneralNegocios
            Dim oPrecios As New PreciosMateriales
            Dim oConsultaMSS As New ConsultaMsSapNegocio
            Dim dsPrecio As New DataSet
            Dim cantidad As Decimal = 1
            Dim oficina As String = param(0)
            Dim serieIccid As String = param(3)
            'inicio whzr 15112014
            Dim strChipIccid As String = param(7)
            Dim dsPrecioChip As New DataSet
            'fin whzr 15112014
            nroLinea = param(4)
            Dim fecha As String = String.Format("{0:yyyy/MM/dd}", Now)
            Dim disponibImei As String = String.Empty
            Dim input As String = ""
            Dim precioIccid As String = ""
            Dim precioEquipo As String = ""
            Dim sRenov As String = Request.QueryString("renov")

            Dim tipoOficina As String = ConfigurationSettings.AppSettings("constCodTipoOficinaCAC")
            Dim idMaterial As String = param(1)
            Dim idListaPrecio As String = param(2)
            Dim imei As String = param(3)

            Try


                    Dim arrPrecioBase As ArrayList
                    Dim arrPrecioVenta As ArrayList
                    Dim precioBase As Decimal
                Dim precioCompra As Decimal 'INC000000715147
                    Dim precioVenta As Decimal
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "idMaterial ===" & CheckStr(idMaterial))
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "idListaPrecio ===" & CheckStr(idListaPrecio))

                    arrPrecioBase = oConsultaMSS.ConsultaPrecioBaseMaterial(idMaterial)
                    arrPrecioVenta = oConsultaMSS.ConsultarPrecioMaterial(idListaPrecio, idMaterial)

                    For Each item As ItemGenerico In arrPrecioBase
                        precioBase = CheckDecimal(item.Monto)
                    precioCompra = CheckDecimal(item.Valor) 'INC000000715147
                    Next

                    For Each item As ItemGenerico In arrPrecioVenta
                        precioVenta = CheckDecimal(item.Monto)
                    Next



                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "idMaterial ===" & idMaterial)
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "imei  ===" & imei)
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "precioBase  ===" & CheckStr(precioBase))
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "precioVenta  ===" & CheckStr(precioVenta))
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "precioCompra  ===" & CheckStr(precioCompra)) 'INC000000715147

                    oPrecios = oConsultaMSS.Get_PrecioVenta(idMaterial, imei, precioBase, precioVenta)

                If precioVenta <> 0 Then
                    oConsultaMSS.reservaSerieMaterial(imei)
                End If

                'precioEquipo = CheckStr(oPrecios.decDescuentos) & "," & CheckStr(oPrecios.decTotal) & "," & CheckStr(oPrecios.decPrecioVenta) & "," & CheckStr(oPrecios.decPrecioVenta)

                precioEquipo = CheckStr(oPrecios.decDescuentos) & "," & CheckStr(precioVenta) & "," & CheckStr(precioCompra) & "," & CheckStr(oPrecios.decPrecioVenta) 'INC000000715147
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "precioEquipo  ===" & precioEquipo) 'INC000000715147
                hidRespuestaPrecio.Value = precioEquipo

                hidResponse.Value = "RetornarDatos"

            Catch ex As Exception
                If sRenov = "RP" Then
                    hidMsg.Value = "El equipo no se encuentra disponible para la renovación."
                Else
                    hidMsg.Value = "Error. El SIM no se encuentra disponible para la reposición."
                End If

                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "Error al consultar el precio.")
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & hidMsg.Value & " " & ex.Message)

                hidRespuestaPrecio.Value = ""
                hidResponse.Value = "Error"

            Finally
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "Inicio Consultar Precio")
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "  Input --> " & input)
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "  Out   --> " & precioEquipo)
                objLog.Log_WriteLog(strArchivo, nroLinea & "- " & "Fin Consultar Precio")

                dsPrecio = Nothing
                oConsultarSap = Nothing
            End Try
        End If
    End Sub

End Class
