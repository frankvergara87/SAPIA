Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.IO
Public Class sisact_mant_HFC_Masivo
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblFecIni As System.Web.UI.WebControls.Label
    Protected WithEvents txtBusquedaFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBusquedaFechaFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgDetalleHFC As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region
    Private rutaOrigen As String = ConfigurationSettings.AppSettings("consRutaOrigenLpPa")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.Write("<script language='javascript' src='../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        If Not Page.IsPostBack Then
 
                CargarTipoOperacion()
                RegisterStartupScript("script", "<script>f_Inicio()</script>")

        End If
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

            dgDetalleHFC.CurrentPageIndex = 0
            Buscar()
    End Sub

    Sub Buscar()
        Dim objHFCMasivo As LHFCMasivo
        Dim intNroSot As Long = ddlEstado.SelectedValue
        Dim strFechaBusquedaInicio As String = txtBusquedaFechaInicio.Text
        Dim strFechaBusquedaFin As String = txtBusquedaFechaFin.Text

        Dim dtbLista As New DataTable

        Try
            objHFCMasivo = New LHFCMasivo
            dtbLista = objHFCMasivo.fdtbListarBusqueda(intNroSot, strFechaBusquedaInicio, strFechaBusquedaFin)
            dgDetalleHFC.DataSource = dtbLista
            dgDetalleHFC.DataBind()

            Session("ITEMS_TOTAL") = dtbLista
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")


        Catch ex As Exception
           Throw ex
        End Try
        objHFCMasivo = Nothing
        Auditoria(ConfigurationSettings.AppSettings("HFC_MASIVO_CONSULTAR"), "Consulta  Reporte HFC Masivo.")
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

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Not Session("ITEMS_TOTAL") Is Nothing Then
            Dim dtbLista As DataTable = DirectCast(Session("ITEMS_TOTAL"), DataTable)
            Dim newFile As String = "Reporte_HFC_Masivo_" & DateTime.Now.ToString("ddMMyyyy")
            Dim Linea As String
            Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & newFile & ".csv"), False, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            Dim totalReg As Integer = dtbLista.Rows.Count
            Try

                If totalReg > 0 Then
                    Linea = "SEC" & "," & _
                        "SOT" & "," & _
                        "CLIENTE SGA" & "," & _
                        "CLIENTE" & "," & _
                        "TIPO DOCUMENTO" & "," & _
                        "DOCUMENTO" & "," & _
                        "CAMPAÑA" & "," & _
                        "ESTADO SOT" & "," & _
                        "SOLUCIÓN" & "," & _
                        "PAQUETE" & "," & _
                        "COD. PLANO" & "," & _
                        "DIRECCIÓN INSTALACIÓN" & "," & _
                        "TIPO VIA" & "," & _
                        "REFERENCIA INSTALACIÓN" & "," & _
                        "NRO PUERTA" & "," & _
                        "COD. URBANIZACIÓN" & "," & _
                        "URBANIZACIÓN" & "," & _
                        "MANZANA" & "," & _
                        "LOTE" & "," & _
                        "DEPARTAMENTO" & "," & _
                        "PROVINCIA" & "," & _
                        "DISTRITO" & "," & _
                        "OFICINA VENTA" & "," & _
                        "INSTALADOR" & "," & _
                        "FECHA CONTRATO" & "," & _
                        "USUARIO" & "," & _
                        "TELEFONO REFERENCIA1" & "," & _
                        "TELEFONO REFERENCIA2" & "," & _
                        "TELEFONO INSTALACION" & "," & _
                        "VENDEDOR" & "," & _
                        "DNI VENDEDOR" & "," & _
                        "CANAL VENTA" & "," & _
                        "ESTADO CONTRATO" & "," & _
                        "FECHA INSTALACIÓN"
                    sw.WriteLine(Linea)
                    For i As Integer = 0 To totalReg - 1
                        Linea = dtbLista.Rows(i)("SOLIN_CODIGO") & "," & _
                            dtbLista.Rows(i)("CONTN_NUMERO_SOT") & "," & _
                           Chr(160) & dtbLista.Rows(i)("CODIGO_CLIENTE_SGA") & "," & _
                            dtbLista.Rows(i)("NOMBRE_CLIENTE") & "," & _
                            dtbLista.Rows(i)("TIPO_DOC") & "," & _
                            Chr(160) & dtbLista.Rows(i)("NUM_DOC") & "," & _
                            dtbLista.Rows(i)("CAMPANA") & "," & _
                            dtbLista.Rows(i)("ESTADO_SOT") & "," & _
                            dtbLista.Rows(i)("SOLUCION") & "," & _
                            dtbLista.Rows(i)("PAQUETE") & "," & _
                            dtbLista.Rows(i)("ID_PLANO") & "," & _
                            dtbLista.Rows(i)("DIREC_INST") & "," & _
                            dtbLista.Rows(i)("TIPO_VIA") & "," & _
                            dtbLista.Rows(i)("REFERENCIA_INST") & "," & _
                            dtbLista.Rows(i)("NRO_PUERTA") & "," & _
                            dtbLista.Rows(i)("ID_URBANIZACION") & "," & _
                            dtbLista.Rows(i)("TXT_URBANIZACION") & "," & _
                            dtbLista.Rows(i)("MANZANA") & "," & _
                            dtbLista.Rows(i)("LOTE") & "," & _
                            dtbLista.Rows(i)("DEPAV_DESCRIPCION") & "," & _
                            dtbLista.Rows(i)("PROVV_DESCRIPCION") & "," & _
                            dtbLista.Rows(i)("DISTV_DESCRIPCION") & "," & _
                            Chr(160) & dtbLista.Rows(i)("OVENC_CODIGO") & "," & _
                            dtbLista.Rows(i)("INSTALADOR") & "," & _
                            dtbLista.Rows(i)("CONTD_FECHA_CONTRATO") & "," & _
                            dtbLista.Rows(i)("CONTV_USUARIO_CREACION") & "," & _
                            Chr(160) & dtbLista.Rows(i)("TELEFONO_REF_1") & "," & _
                            Chr(160) & dtbLista.Rows(i)("TELEFONO_REF_2") & "," & _
                             Chr(160) & dtbLista.Rows(i)("TELEF_DIR_INST") & "," & _
                            dtbLista.Rows(i)("VENDEDOR") & "," & _
                            dtbLista.Rows(i)("DNI_VENDEDOR") & "," & _
                            dtbLista.Rows(i)("CANAL") & "," & _
                            dtbLista.Rows(i)("CONTC_ESTADO") & "," & _
                        dtbLista.Rows(i)("FECHA_INST")
                        sw.WriteLine(Linea)
                    Next
                    sw.Flush()
                    sw.Close()
                    Dim fs As System.IO.FileStream = Nothing
                    fs = System.IO.File.Open(Server.MapPath(rutaOrigen & "/" & newFile & _
                            ".csv"), System.IO.FileMode.Open)
                    Dim btFile(fs.Length) As Byte
                    fs.Read(btFile, 0, fs.Length)
                    fs.Close()
                    With Response
                        .Clear()
                        .AddHeader("Content-disposition", "attachment;filename=" & newFile & ".csv")
                        '.ContentType = "application/octet-stream" 'csv
                        .ContentType = "text/csv; charset=iso-8859-1"
                        .BinaryWrite(btFile)
                        .End()
                    End With
                Else
                    RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('No existen registros cargados')</script>")
                End If
            Catch ex As Threading.ThreadAbortException
            Catch ex As Exception
                sw.Flush()
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('Error al exportar carga')</script>")
            Finally
                sw.Close()
                Auditoria(ConfigurationSettings.AppSettings("HFC_MASIVO_EXPORTAR"), "Exportar Archivo Lista de Reporte HFC Masivo.")
            End Try
        Else
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('No existen registros cargados')</script>")
        End If
    End Sub

    Private Sub dgDetalleHFC_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDetalleHFC.PageIndexChanged
        dgDetalleHFC.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dgDetalleHFC.DataSource = Nothing
        dgDetalleHFC.DataBind()
        Session("ITEMS_TOTAL") = Nothing
        'RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub CargarTipoOperacion()

        Dim oVenta As New VentaExpressNegocios

        Dim dtConsultaEstadoSOT As DataTable = oVenta.ConsultaEstadoSOT()


        Dim strDelete As String = ConfigurationSettings.AppSettings("TipoOperacionesBorrar")
        Dim itemsRemove As String = ""

        For i As Integer = 0 To dtConsultaEstadoSOT.Rows.Count - 1

            Dim drDelete As DataRow = dtConsultaEstadoSOT.Rows(i)
            If strDelete.IndexOf(";" & Trim(drDelete("estsol")) & ";") > -1 Then
                itemsRemove &= i & ";"
            End If

        Next

        If Not itemsRemove.Equals(String.Empty) Then
            itemsRemove = itemsRemove.Substring(0, itemsRemove.Length - 1)
            Dim arrayItems As String() = itemsRemove.Split(";"c)
            Dim intPos As Integer = 0
            For Each item As Integer In arrayItems
                dtConsultaEstadoSOT.Rows.RemoveAt(CInt(item) - intPos)
                intPos += 1
            Next

        End If

        Dim drNew As DataRow = dtConsultaEstadoSOT.NewRow
        drNew("estsol") = "00"
        drNew("descripcion") = ConfigurationSettings.AppSettings("Todos")
        dtConsultaEstadoSOT.Rows.InsertAt(drNew, 0)

        ddlEstado.DataValueField = "estsol"
        ddlEstado.DataTextField = "descripcion"
        ddlEstado.DataSource = dtConsultaEstadoSOT
        ddlEstado.DataBind()

        oVenta = Nothing

    End Sub
End Class
