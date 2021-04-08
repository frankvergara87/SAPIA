Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text.RegularExpressions

Public Class sisact_mant_servicio_equipos
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlSolucion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPaquete As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProducto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlServicio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents dgrODCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrODDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrOACabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrOADetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidPDVs As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEquipos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidServCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMoverItem As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton

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
    Dim oFile As String = oLog.Log_CrearNombreArchivo("logMantenimiento3play")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
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
            LlenarSolucion()
            RegisterStartupScript("script", "<script>f_Inicio()</script>")
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("OnClick", "return grabar();")

    End Sub
    Private Sub LlenarSolucion()
        Dim idLog As String = CurrentUser
        Dim strResultado As String = String.Empty
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strTipoServicio As String = ConfigurationSettings.AppSettings("constTipoServicio3Play")
        Dim intCodError As Integer
        Dim strMsgError As String

        Try
            objConsumerNegocio = New ConsumerNegocio
            Dim oListaSolucion As New ArrayList
            oListaSolucion = objConsumerNegocio.ListarSolucion3Play(strTipoServicio, intCodError, strMsgError)
            oListaSolucion = AgregarItemGenerico(oListaSolucion)

            If Not oListaSolucion Is Nothing Then
                ddlSolucion.DataSource = oListaSolucion
                ddlSolucion.DataValueField = "Codigo"
                ddlSolucion.DataTextField = "Descripcion"
                ddlSolucion.DataBind()                
                For Each item As ItemGenerico In oListaSolucion
                    strResultado &= "|" & item.Codigo & ";" & item.Descripcion
                Next
            Else
                RegisterStartupScript("script", "<script>alert('No existe lista de Soluciones para el servicio " & strTipoServicio & ".');</script>")
            End If
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR LlenarSolucion: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR LlenarSolucion: " & ex.StackTrace.ToString())
            'Throw ex
        Finally
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub ddlSolucion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSolucion.SelectedIndexChanged
        Dim idLog As String = CurrentUser
        Dim strResultado As String = String.Empty
        Dim objConsumerNegocio As ConsumerNegocio
        Dim intCodError As Integer
        Dim strMsgError As String
        Try
            objConsumerNegocio = New ConsumerNegocio
            ddlPaquete.Items.Clear()
            ddlProducto.Items.Clear()
            ddlServicio.Items.Clear()
            dgrODDetalle.DataSource = Nothing
            dgrODDetalle.DataBind()
            Dim oListaPaquetes As New ArrayList
            If ddlSolucion.SelectedValue <> "-1" Then
                oListaPaquetes = objConsumerNegocio.ListarPaquete3Play(ddlSolucion.SelectedValue, intCodError, strMsgError)
                oListaPaquetes = AgregarItemGenerico(oListaPaquetes)

                ddlPaquete.DataSource = oListaPaquetes
                ddlPaquete.DataValueField = "Codigo"
                ddlPaquete.DataTextField = "Descripcion"
                ddlPaquete.DataBind()
            End If
            For Each item As ItemGenerico In oListaPaquetes
                strResultado &= "|" & item.Codigo & ";" & item.Descripcion
            Next
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR ddlSolucion_SelectedIndexChanged: " & ex.Message.ToString())
            'Throw ex
        Finally
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub ddlPaquete_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPaquete.SelectedIndexChanged
        Dim idLog As String = CurrentUser
        Dim strResultado As String = String.Empty
        Dim objConsumerNegocio As ConsumerNegocio
        Dim intCodError As Integer
        Dim strMsgError As String
        Try
            objConsumerNegocio = New ConsumerNegocio
            Dim dtb As New ArrayList
            Dim arrProd As New ArrayList
            Dim auxProd As Int64 = 0
            ddlProducto.Items.Clear()
            ddlServicio.Items.Clear()
            dgrODDetalle.DataSource = Nothing
            dgrODDetalle.DataBind()

            If ddlPaquete.SelectedValue <> "-1" Then
                dtb = objConsumerNegocio.ListarPlanesXPaquete3Play(ddlPaquete.SelectedValue)
                Session("ArrServ") = dtb

                For Each objPlan As ServicioHFC In dtb
                    If objPlan.FlagPrincipal = 1 Then
                        If auxProd <> objPlan.IdProducto Then
                            arrProd.Add(objPlan)
                        End If
                        auxProd = objPlan.IdProducto
                    End If
                Next

                Dim oServicioHFC As New ServicioHFC
                oServicioHFC.IdProducto = "-1"
                oServicioHFC.Producto = "Seleccione..."
                arrProd.Insert(0, oServicioHFC)

                ddlProducto.DataSource = arrProd
                ddlProducto.DataValueField = "idproducto"
                ddlProducto.DataTextField = "producto"
                ddlProducto.DataBind()
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR ddlPaquete_SelectedIndexChanged: " & ex.Message.ToString())
            'Throw ex
        Finally
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub ddlProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProducto.SelectedIndexChanged
        Dim dtb As New ArrayList
        Dim arrServ As New ArrayList
        dtb = Session("ArrServ")
        ddlServicio.Items.Clear()
        dgrODDetalle.DataSource = Nothing
        dgrODDetalle.DataBind()

        If ddlProducto.SelectedValue <> "-1" Then
            For Each objPlan As ServicioHFC In dtb
                If objPlan.IdProducto = ddlProducto.SelectedValue Then
                    arrServ.Add(objPlan)
                End If
            Next

            Dim oServicioHFC As New ServicioHFC
            oServicioHFC.IdServicio = "-1"
            oServicioHFC.Servicio = "Seleccione..."
            arrServ.Insert(0, oServicioHFC)

            ddlServicio.DataSource = arrServ
            ddlServicio.DataValueField = "IdServicio"
            ddlServicio.DataTextField = "Servicio"
            ddlServicio.DataBind()
        End If

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub ddlServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlServicio.SelectedIndexChanged
        Dim dtb As New ArrayList
        Dim arrEquipo As New ArrayList
        Dim grupo As Int16
        dtb = Session("ArrServ")
        dgrODDetalle.DataSource = Nothing
        dgrODDetalle.DataBind()
        If ddlServicio.SelectedValue <> "-1" Then
            For Each objPaq As ServicioHFC In dtb
                If objPaq.IdServicio = ddlServicio.SelectedValue Then
                    grupo = objPaq.Grupo
                    Exit For
                End If
            Next

            For Each objEquipo As ServicioHFC In dtb
                If objEquipo.Producto = "COMODATO" Then
                    If objEquipo.Grupo = grupo Then
                        arrEquipo.Add(objEquipo)
                    End If
                End If
            Next

            dgrODCabecera.DataSource = ""
            dgrODCabecera.DataBind()
            dgrODDetalle.DataSource = arrEquipo
            dgrODDetalle.DataBind()

            dgrOACabecera.DataSource = ""
            dgrOACabecera.DataBind()
            dgrOADetalle.DataSource = ""
            dgrOADetalle.DataBind()
        End If
        RegisterStartupScript("script", "<script>document.getElementById('tblPV').style.display = '';f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        ActivarCombos(True)
        limpiar()
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim idLog As String = CurrentUser
        Dim objMant As New MaestroNegocio
        Dim strCabecera As String = ""
        Dim strEquipo As String = ""
        Try
            strCabecera = ddlPaquete.SelectedValue & ";" & ddlPaquete.SelectedItem.Text & ";" & _
                                  ddlServicio.SelectedValue & ";" & ddlServicio.SelectedItem.Text & ";" & _
                                  ddlEstado.SelectedValue & ";" & ddlSolucion.SelectedValue
            strEquipo = hidEquipos.Value

            If hidServCodigo.Value.Length = 0 Then

                oLog.Log_WriteLog(oFile, idLog & "- " & "Inicio insertarServEquipos")
                oLog.Log_WriteLog(oFile, idLog & "- " & "inp strCabecera: " & strCabecera)
                oLog.Log_WriteLog(oFile, idLog & "- " & "inp strEquipo: " & strEquipo)

                objMant.insertarServEquipos(strCabecera, strEquipo)

                oLog.Log_WriteLog(oFile, idLog & "- " & "Fin insertarServEquipos")
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantServXEquipo_Insertar"), "Inserta Servicio x Equipo")
            Else
                oLog.Log_WriteLog(oFile, idLog & "- " & "Inicio actualizarServEquipos")
                oLog.Log_WriteLog(oFile, idLog & "- " & "inp hidServCodigo: " & hidServCodigo.Value)
                oLog.Log_WriteLog(oFile, idLog & "- " & "inp strEquipo: " & strEquipo)
                oLog.Log_WriteLog(oFile, idLog & "- " & "inp ddlEstado: " & ddlEstado.SelectedValue)

                objMant.actualizarServEquipos(hidServCodigo.Value, strEquipo, ddlEstado.SelectedValue)

                oLog.Log_WriteLog(oFile, idLog & "- " & "Fin actualizarServEquipos")
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantServXEquipo_Modificar"), "Modifica Servicio x Equipo")
            End If

            limpiar()
            buscar()
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('Se regitraron los datos correctamente.')</script>")
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR btnAceptar_Click: " & ex.Message.ToString())
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Error: Configuración ya existe.')</script>")
            Else
                RegisterStartupScript("script1", "<script>alert('Ocurrió un error en el proceso.');</script>")
            End If
        End Try

    End Sub

    Sub limpiar()
        ddlSolucion.SelectedIndex = 0

        ddlPaquete.Items.Clear()
        ddlProducto.Items.Clear()
        ddlServicio.Items.Clear()

        hidMoverItem.Value = ""
        hidServCodigo.Value = ""
        hidEquipos.Value = ""
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim idLog As String = CurrentUser
        Try
            dgrGrillaDetalle.CurrentPageIndex = 0
            buscar()
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR btnBuscar_Click: " & ex.Message.ToString())
            'Throw ex
        End Try
    End Sub

    Sub buscar()
        Dim idLog As String = CurrentUser
        Dim objMant As MaestroNegocio
        Dim strDescripcion As String

        Try
            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objMant = New MaestroNegocio

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objMant.listarServXEquipo(strDescripcion, 0, 0)
                dgrGrillaDetalle.DataBind()
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantServXEquipo_Consulta"), "Consulta Servicio x Equipo")
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR btnBuscar_Click: " & ex.Message.ToString())
            Throw ex
        End Try
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim idLog As String = CurrentUser
        Dim objMant As MaestroNegocio
        Dim dt As DataTable
        Dim arrServ As New ArrayList
        Dim arrEqD As New ArrayList
        Dim serv As String
        Dim grupo As Int16
        Dim dtEqA As New DataTable
        Dim dtEqD As New DataTable

        dtEqA.Columns.Add("IDDET")
        dtEqA.Columns.Add("IdLinea")
        dtEqA.Columns.Add("IdEquipo")
        dtEqA.Columns.Add("Equipo")
        dtEqA.Columns.Add("cant_equipo")

        dtEqD.Columns.Add("IDDET")
        dtEqD.Columns.Add("IdLinea")
        dtEqD.Columns.Add("IdEquipo")
        dtEqD.Columns.Add("Equipo")
        dtEqD.Columns.Add("cant_equipo")

        Try
            objMant = New MaestroNegocio
            dt = New DataTable

            dt = objMant.listarEquipos(hidServCodigo.Value)
            ddlSolucion.SelectedValue = Convert.ToString(dt.Rows(0)("IDSOLUCION"))
            ddlSolucion_SelectedIndexChanged(Nothing, Nothing)
            ddlPaquete.SelectedValue = Convert.ToString(dt.Rows(0)("IDPAQUETE"))
            ddlPaquete_SelectedIndexChanged(Nothing, Nothing)
            arrServ = Session("ArrServ")
            serv = Convert.ToString(dt.Rows(0)("IDSERVICIO"))
            For Each objPlan As ServicioHFC In arrServ
                If objPlan.FlagPrincipal = 1 Then
                    If serv = objPlan.IdServicio Then
                        ddlProducto.SelectedValue = objPlan.IdProducto
                        Exit For
                    End If

                End If
            Next
            ddlProducto_SelectedIndexChanged(Nothing, Nothing)
            ddlServicio.SelectedValue = Convert.ToString(dt.Rows(0)("IDSERVICIO"))
            ddlEstado.SelectedValue = Convert.ToString(dt.Rows(0)("ESTADO"))

            For Each objPaq As ServicioHFC In arrServ
                If objPaq.IdServicio = ddlServicio.SelectedValue Then
                    grupo = objPaq.Grupo
                    Exit For
                End If
            Next

            For Each objEquipo As ServicioHFC In arrServ
                If objEquipo.Producto = "COMODATO" Then
                    If objEquipo.Grupo = grupo Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If objEquipo.IdEquipo = Convert.ToString(dt.Rows(i)("IDEQUIPO")) Then
                                Dim dr As DataRow = dtEqA.NewRow
                                dr("IDDET") = objEquipo.IDDET
                                dr("IdLinea") = objEquipo.IdLinea
                                dr("IdEquipo") = objEquipo.IdEquipo
                                dr("Equipo") = objEquipo.Equipo
                                dr("cant_equipo") = Convert.ToString(dt.Rows(i)("cant_equipo"))

                                dtEqA.Rows.Add(dr)
                                dtEqA.AcceptChanges()
                            End If
                        Next
                    End If
                End If
            Next

            For Each objEquipo As ServicioHFC In arrServ
                If objEquipo.Producto = "COMODATO" Then
                    If objEquipo.Grupo = grupo Then
                        Dim dr As DataRow = dtEqD.NewRow
                        dr("IDDET") = objEquipo.IDDET
                        dr("IdLinea") = objEquipo.IdLinea
                        dr("IdEquipo") = objEquipo.IdEquipo
                        dr("Equipo") = objEquipo.Equipo

                        dtEqD.Rows.Add(dr)
                        dtEqD.AcceptChanges()
                    End If
                End If
            Next


            For j As Integer = 0 To dtEqA.Rows.Count - 1
                For i As Integer = 0 To dtEqD.Rows.Count - 1
                    If Convert.ToString(dtEqD.Rows(i)("IDEQUIPO")) = Convert.ToString(dtEqA.Rows(j)("IDEQUIPO")) Then
                        dtEqD.Rows(i).Delete()
                        dtEqD.AcceptChanges()
                        Exit For
                    End If
                Next
            Next


            dgrODCabecera.DataSource = ""
            dgrODCabecera.DataBind()
            dgrODDetalle.DataSource = dtEqD
            dgrODDetalle.DataBind()

            dgrOACabecera.DataSource = ""
            dgrOACabecera.DataBind()
            dgrOADetalle.DataSource = dtEqA
            dgrOADetalle.DataBind()
            ActivarCombos(False)
            hidMoverItem.Value = "NO"
            RegisterStartupScript("script2", "<script>document.getElementById('tblPV').style.display = '';f_MostrarTab('EDICION')</script>")
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR btnModificar_ServerClick: " & ex.Message.ToString())
            'Throw ex
        End Try
    End Sub

    Sub ActivarCombos(ByVal valor As Boolean)
        ddlSolucion.Enabled = valor
        ddlPaquete.Enabled = valor
        ddlProducto.Enabled = valor
        ddlServicio.Enabled = valor
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim idLog As String = CurrentUser
        Dim objMant As MaestroNegocio

        Try
            objMant = New MaestroNegocio
            objMant.eliminarServEquipos(hidServCodigo.Value)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantServXEquipo_Eliminar"), "Eliminar Servicio x Equipo")
            btnBuscar_Click(Nothing, Nothing)
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & "- " & "ERROR btnEliminar_ServerClick: " & ex.Message.ToString())
            'Throw ex
        End Try
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        buscar()
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

    Private Function AgregarItemGenerico(ByVal oLista As ArrayList) As ArrayList
        Dim itmSeleccione As New ItemGenerico
        itmSeleccione.Codigo = "-1"
        itmSeleccione.Descripcion = "Seleccione..."
        oLista.Insert(0, itmSeleccione)
        Return oLista
    End Function
End Class
