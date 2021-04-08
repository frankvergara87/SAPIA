Imports Anthem
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text.RegularExpressions

Public Class sisact_mant_equipos_x_servicio
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As Anthem.DataGrid
    Protected WithEvents dgrGrillaDetalle As Anthem.DataGrid
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidEquipos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidServCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMoverItem As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlGrupo As Anthem.DropDownList
    Protected WithEvents ddlServicio As Anthem.DropDownList
    Protected WithEvents ddlEstado As Anthem.DropDownList
    Protected WithEvents dgrMACabecera As Anthem.DataGrid
    Protected WithEvents dgrMADetalle As Anthem.DataGrid
    Protected WithEvents dgrMDCabecera As Anthem.DataGrid
    Protected WithEvents dgrMDDetalle As Anthem.DataGrid
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblMensaje As Anthem.Label
    Protected WithEvents ddlEstadoBuscar As Anthem.DropDownList
    Protected WithEvents ddlProducto As Anthem.DropDownList
    Protected WithEvents ddlProductoBuscar As Anthem.DropDownList
    Protected WithEvents hidProducto As System.Web.UI.HtmlControls.HtmlInputHidden

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
    Dim oFile As String = oLog.Log_CrearNombreArchivo("LOG_MANT_EQUIPOS_X_SERVICIO")

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Anthem.Manager.Register(Me)
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
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
            Inicio()
            RegisterStartupScript("script", "<script>f_Inicio()</script>")
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
    End Sub
    'ldrz
    Private Sub ddlGrupo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlGrupo.SelectedIndexChanged
        LlenarServicio(ddlProducto.SelectedValue, ddlGrupo.SelectedValue)
        LlenarEquiposxServicio(ddlServicio.SelectedValue)
        LlenarEquiposDisponibles(ddlProducto.SelectedValue, ddlGrupo.SelectedValue, ddlServicio.SelectedValue)
        ddlServicio.UpdateAfterCallBack = True
    End Sub
'ldrz
    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        LlenarEquiposxServicio(ddlServicio.SelectedValue)
        LlenarEquiposDisponibles(ddlProducto.SelectedValue, ddlGrupo.SelectedValue, ddlServicio.SelectedValue)
    End Sub
    'ldrz
    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        Dim objLServicio3Play As LServicio3Play
        Dim strDescripcion As String
        Dim strEstado As String
        Dim strProducto As String

        Try
            dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
            strProducto = ddlProductoBuscar.SelectedValue
            strDescripcion = txtBusDescripcion.Text.Trim
            strEstado = ddlEstadoBuscar.SelectedValue
            objLServicio3Play = New LServicio3Play

            dgrGrillaCabecera.DataSource = ""
            dgrGrillaCabecera.DataBind()

            dgrGrillaDetalle.DataSource = objLServicio3Play.fdtbListarEquiposxServicio3Play(strProducto, strDescripcion, strEstado)
            dgrGrillaDetalle.DataBind()
            dgrGrillaDetalle.UpdateAfterCallBack = True
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error dgrGrillaDetalle - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error dgrGrillaDetalle - Fin :::::::::::::")
        End Try
    End Sub

    <Anthem.Method()> _
    Sub BuscarAnthem()
        dgrGrillaDetalle.CurrentPageIndex = 0
        Buscar()
    End Sub
    
'ldrz
    <Anthem.Method()> _
Sub ModificarAnthem(ByVal pstrCodigo As String, ByVal pstrCodProd As String)
        Dim strCodigo As String
        Dim strCodProd As String
        Dim iPos As Integer

        iPos = InStr(pstrCodigo, ",")
        strCodigo = Left(pstrCodigo, iPos - 1)
        strCodProd = Mid(pstrCodigo, iPos + 1, Len(pstrCodigo) - iPos)


        Modificar(strCodigo, strCodProd)
    End Sub

'ldrz
    <Anthem.Method()> _
    Function EliminarAnthem(ByVal pstrCodigo As String) As String
        Return Eliminar(pstrCodigo)
    End Function
    <Anthem.Method()> _
    Function AceptarAnthem(ByVal pstrEquipos As String) As String
        Return Aceptar(pstrEquipos)
    End Function
    <Anthem.Method()> _
    Sub LimpiarRegistroAnthem()
        ddlProducto.SelectedIndex = -1
        ddlGrupo.SelectedIndex = -1
        ddlServicio.SelectedIndex = -1
        dgrMACabecera.DataSource = ""
        dgrMACabecera.DataBind()
        dgrMADetalle.DataSource = ""
        dgrMADetalle.DataBind()
        dgrMDCabecera.DataSource = ""
        dgrMDCabecera.DataBind()
        dgrMDDetalle.DataSource = ""
        dgrMDDetalle.DataBind()
    End Sub
    <Anthem.Method()> _
    Sub LimpiarDatosAnthem()
        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()
    End Sub

'ldrz
    Private Sub Inicio()
        lblMensaje.Visible = False

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()

        dgrMACabecera.DataSource = ""
        dgrMACabecera.DataBind()
        dgrMADetalle.DataSource = ""
        dgrMADetalle.DataBind()

        dgrMDCabecera.DataSource = ""
        dgrMDCabecera.DataBind()
        dgrMDDetalle.DataSource = ""
        dgrMDDetalle.DataBind()

        LlenarProducto()
        LlenarGrupo(String.Empty)
        LlenarServicio(String.Empty, String.Empty)
        LlenarEstado()
        LlenarProductoBuscar()

        ddlBusqueda.SelectedValue = "1"
    End Sub
    
'ldrz
    Private Sub Buscar()
        Dim objLServicio3Play As LServicio3Play
        Dim strDescripcion As String
        Dim strEstado As String
        Dim dt As New DataTable
        Dim strProducto As String
        Try
            strProducto = ddlProductoBuscar.SelectedValue
            strDescripcion = txtBusDescripcion.Text.Trim.ToUpper
            strEstado = ddlEstadoBuscar.SelectedValue
            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objLServicio3Play = New LServicio3Play

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()
                dt = objLServicio3Play.fdtbListarEquiposxServicio3Play(strProducto, strDescripcion, strEstado)
                dgrGrillaDetalle.DataSource = dt
                dgrGrillaDetalle.DataBind()
                dgrGrillaDetalle.UpdateAfterCallBack = True
                If (dt.Rows.Count > 0) Then
                    dgrGrillaDetalle.PagerStyle.Visible = True
                    lblMensaje.Visible = False
                Else
                    dgrGrillaDetalle.PagerStyle.Visible = False
                    lblMensaje.Visible = True
                End If
            End If

            Auditoria(ConfigurationSettings.AppSettings("AUDIT_CON_EQUIPO_X_SERV_3PLAY"), "Consulta Equipo por Servicio 3Play")

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Buscar - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Buscar - Fin :::::::::::::")
        End Try
    End Sub
    
'ldrz
Private Sub Modificar(ByVal pstrCodigo As String, ByVal pstrCodProd As String)
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Try
            objLServicio3Play = New LServicio3Play
            dt = objLServicio3Play.fdtbObtenerEquiposxCodigo3Play(pstrCodigo)
            If (dt.Rows.Count > 0) Then
                ddlProducto.SelectedValue = pstrCodProd ''CheckStr(ddlProductoBuscar.SelectedValue)
                LlenarGrupo(pstrCodProd)                                  ''maquino
                ddlGrupo.SelectedValue = CheckStr(dt.Rows(0).Item("COD_GRUPO"))
                LlenarServicio(pstrCodProd, ddlGrupo.SelectedValue) '' maquino
                ddlServicio.SelectedValue = CheckStr(dt.Rows(0).Item("IDSERVICIO"))
                ddlEstado.SelectedValue = CheckStr(dt.Rows(0).Item("ESTADO"))
                ddlProducto.UpdateAfterCallBack = True
                ddlGrupo.UpdateAfterCallBack = True
                ddlServicio.UpdateAfterCallBack = True
                ddlEstado.UpdateAfterCallBack = True
                LlenarEquiposxCodigo(pstrCodigo)
                LlenarEquiposDisponibles(pstrCodProd, ddlGrupo.SelectedValue, ddlServicio.SelectedValue)
            End If
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Modificar - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Modificar - Fin :::::::::::::")
        End Try
    End Sub
    Function Eliminar(ByVal pstrCodigo As String) As String
        Dim objLServicio3Play As LServicio3Play
        Dim blnResultado As Boolean
        Dim strMensaje As String
        Try
            objLServicio3Play = New LServicio3Play
            blnResultado = objLServicio3Play.fbooEliminarEquipoxServicio3Play(pstrCodigo, strMensaje)

            Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_EQUIPO_X_SERV_3PLAY"), "Desactivar Equipo por Servicio 3Play (Código: " & pstrCodigo & " )")

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Eliminar - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Eliminar - Fin :::::::::::::")
        End Try
        Return strMensaje
    End Function
    
'ldrz
    Function Aceptar(ByVal pstrEquipos As String) As String
        Dim objLServicio3Play As LServicio3Play
        Dim blnResultado As Boolean
        Dim strMensaje As String
        Try
            objLServicio3Play = New LServicio3Play
            blnResultado = objLServicio3Play.fbooInsertarEquiposxServicio3Play(ddlGrupo.SelectedValue, ddlServicio.SelectedValue, ddlServicio.SelectedItem.Text, ddlEstado.SelectedValue, pstrEquipos, strMensaje)
            If (blnResultado) Then
                LlenarEquiposxServicio(ddlServicio.SelectedValue)
                LlenarEquiposDisponibles(ddlProducto.SelectedValue, ddlGrupo.SelectedValue, ddlServicio.SelectedValue)
            End If

            Auditoria(ConfigurationSettings.AppSettings("AUDIT_INS_EQUIPO_X_SERV_3PLAY"), "Insertar Equipo por Servicio 3Play")

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Eliminar - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error Eliminar - Fin :::::::::::::")
        End Try
        Return strMensaje
    End Function
     
'ldrz
Private Sub LlenarGrupo(ByVal pstrProducto As String)
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Try
            objLServicio3Play = New LServicio3Play
            ddlGrupo.DataValueField = "GSRVC_CODIGO"
            ddlGrupo.DataTextField = "GSRVV_DESCRIPCION"
            dt = objLServicio3Play.fdtbListarGruposxProducto(pstrProducto)
            ddlGrupo.DataSource = dt
            ddlGrupo.DataBind()
            ddlGrupo.Items.Insert(0, New ListItem("SELECCIONAR", ""))
            ddlGrupo.SelectedIndex = 0
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub
    Private Sub LlenarEstado()
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Try
            ddlEstado.Items.Insert(0, New ListItem("SELECCIONAR", ""))
            ddlEstado.Items.Insert(1, New ListItem("ACTIVO", "1"))
            ddlEstado.Items.Insert(2, New ListItem("INACTIVO", "0"))
            ddlEstado.SelectedIndex = 1
            ddlEstadoBuscar.Items.Insert(0, New ListItem("ACTIVO", "1"))
            ddlEstadoBuscar.Items.Insert(1, New ListItem("INACTIVO", "0"))
            ddlEstadoBuscar.SelectedIndex = 0
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarEstado - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarEstado - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub
    
'ldrz
Private Sub LlenarServicio(ByVal pstrProducto As String, ByVal pstrGrupo As String)
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Try
            objLServicio3Play = New LServicio3Play
            ddlServicio.DataValueField = "SERVV_CODIGO"
            ddlServicio.DataTextField = "SERVV_DESCRIPCION"
            dt = objLServicio3Play.fdtbListarServiciosxGrupo3Play(pstrProducto, pstrGrupo)
            ddlServicio.DataSource = dt
            ddlServicio.DataBind()
            ddlServicio.Items.Insert(0, New ListItem("SELECCIONAR", ""))
            ddlServicio.SelectedIndex = 0
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarServicio - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarServicio - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub
    Private Sub LlenarEquiposxCodigo(ByVal pstrCodigo As String)
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Try
            objLServicio3Play = New LServicio3Play
            dgrMACabecera.DataSource = ""
            dgrMACabecera.DataBind()
            dt = objLServicio3Play.fdtbObtenerEquiposxCodigo3Play(pstrCodigo)
            dgrMADetalle.DataSource = dt
            dgrMADetalle.DataBind()
            dgrMADetalle.UpdateAfterCallBack = True
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub
    Private Sub LlenarEquiposxServicio(ByVal pstrServicio As String)
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Try
            objLServicio3Play = New LServicio3Play
            dgrMACabecera.DataSource = ""
            dgrMACabecera.DataBind()
            dt = objLServicio3Play.fdtbObtenerEquiposxServicio3Play(pstrServicio)
            dgrMADetalle.DataSource = dt
            dgrMADetalle.DataBind()
            dgrMADetalle.UpdateAfterCallBack = True
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub
    
'ldrz
Private Sub LlenarEquiposDisponibles(ByVal pstrProducto As String, ByVal pstrGrupo As String, ByVal pstrServicio As String)
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Try
            objLServicio3Play = New LServicio3Play
            dgrMDCabecera.DataSource = ""
            dgrMDCabecera.DataBind()
            dt = objLServicio3Play.fdtbListarEquiposxGrupo3Play(pstrProducto, pstrGrupo, pstrServicio)
            dgrMDDetalle.DataSource = dt
            dgrMDDetalle.DataBind()
            dgrMDDetalle.UpdateAfterCallBack = True
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarGrupo - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
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

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV") ' Cambiar por Equipos 
            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub

'ldrz
    Private Sub ddlProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProducto.SelectedIndexChanged
        LlenarGrupo(ddlProducto.SelectedValue)
        LlenarServicio(ddlProducto.SelectedValue, ddlGrupo.SelectedValue)
        LlenarEquiposxServicio(ddlServicio.SelectedValue)
        LlenarEquiposDisponibles(ddlProducto.SelectedValue, ddlGrupo.SelectedValue, ddlServicio.SelectedValue)
        ddlServicio.UpdateAfterCallBack = True
    End Sub

'ldrz
   Private Sub LlenarProducto()
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Dim strCodProd As String

        Try
            objLServicio3Play = New LServicio3Play
            ddlProducto.DataValueField = "PRDC_CODIGO"
            ddlProducto.DataTextField = "PRDV_DESCRIPCION"
            dt = objLServicio3Play.fdtbListarProductos()

            strCodProd = ConfigurationSettings.AppSettings("constProd3Play")
            Dim dv As New DataView(dt)
            dv.RowFilter = "PRDC_CODIGO IN " & strCodProd

            ddlProducto.DataSource = dv ''dt
            ddlProducto.DataBind()
            ddlProducto.Items.Insert(0, New ListItem("SELECCIONAR", ""))
            ddlProducto.SelectedIndex = 0

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub

'ldrz
    Private Sub LlenarProductoBuscar()
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Dim strCodProd As String

        Try
            objLServicio3Play = New LServicio3Play
            ddlProductoBuscar.DataValueField = "PRDC_CODIGO"
            ddlProductoBuscar.DataTextField = "PRDV_DESCRIPCION"
            dt = objLServicio3Play.fdtbListarProductos()

            strCodProd = ConfigurationSettings.AppSettings("constProd3Play")
            Dim dv As New DataView(dt)
            dv.RowFilter = "PRDC_CODIGO IN " & strCodProd

            ddlProductoBuscar.DataSource = dv ''dt
            ddlProductoBuscar.DataBind()
            ddlProductoBuscar.Items.Insert(0, New ListItem("SELECCIONAR", ""))
            ddlProductoBuscar.SelectedIndex = 0

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Inicio  :::::::::::::")
            oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub



End Class
