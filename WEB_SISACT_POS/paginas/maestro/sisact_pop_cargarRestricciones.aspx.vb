Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios

Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones

Public Class sisact_pop_cargarRestricciones
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlRiesgo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPlan As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroPlanes As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnMarcarServer As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents btnCerrar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPlazos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnEliminarServer As System.Web.UI.WebControls.Button
    Protected WithEvents hidCondicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnEliminarTodosServer As System.Web.UI.WebControls.Button
    Protected WithEvents dgrCuotas As System.Web.UI.WebControls.DataGrid

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim CE_K0_TIPO_RIESGO As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_K0_TIPO_RIESGO"))
    Dim CE_K1_TIPO_RIESGO As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_K1_TIPO_RIESGO"))
    Dim CE_K2_TIPO_RIESGO As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_K2_TIPO_RIESGO"))
    Dim CE_P_CASO_ESPECIAL As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_P_CASO_ESPECIAL"))
    Dim CE_TD_DNI As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_TD_DNI"))
    Dim CE_TD_CE As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_TD_CE"))
    Dim CE_ESTADO_PLAN As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_ESTADO_PLAN"))

    Private ent As New CasoEspecial
    Private obj As New CasoEspecialNegocios

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
            Call CargarCombos()
            If Not Request.QueryString("Codigo") Is Nothing Then
                Dim Coleccion() As String = Split(Request.QueryString("Codigo").ToString(), "|")
                Me.ddlDocumento.SelectedValue = Coleccion(0).ToString()
                ddlDocumento_SelectedIndexChanged(Nothing, Nothing)
                Me.ddlRiesgo.SelectedValue = Coleccion(1).ToString()
                Me.ddlPlan.SelectedValue = Coleccion(2).ToString()
                Me.txtNroPlanes.Text = Coleccion(5).ToString()
                Me.ddlPlazos.SelectedValue = Coleccion(3).ToString()
            End If
            Call CargarCuotas()
            Call SesionTemporal()
            Me.btnCerrar.Attributes.Add("onclick", "return f_CerrarVentana();")
            RegisterStartupScript("script", "<script>document.getElementById('" & Me.ddlDocumento.ClientID & "').focus();</script>")
        Else
            Me.hidCondicion.Value = Nothing
        End If
    End Sub

    Private Sub SesionTemporal()
        If Not Request.QueryString("Codigo") Is Nothing Then

            Dim Dt As DataTable = CType(Session("Restricciones"), DataTable)

            Dim DtTemporal As New DataTable
            With DtTemporal
                .Columns.Add("IdDocumento", GetType(String))
                .Columns.Add("Documento", GetType(String))
                .Columns.Add("IdRiesgo", GetType(String))
                .Columns.Add("Riesgo", GetType(String))
                .Columns.Add("IdPlan", GetType(String))
                .Columns.Add("Plan", GetType(String))
                .Columns.Add("NroPlanes", GetType(Integer))
                .Columns.Add("IdPlazo", GetType(String))
                .Columns.Add("Plazo", GetType(String))
                .Columns.Add("IdCuota", GetType(String))
                .Columns.Add("Cuota", GetType(String))
                .Columns.Add("Porcentaje", GetType(Double))
            End With

            For Each Dr As DataRow In Dt.Rows
                Dim Fila As DataRow = DtTemporal.NewRow
                Fila("IdDocumento") = Dr("IdDocumento")
                Fila("Documento") = Dr("Documento")
                Fila("IdRiesgo") = Dr("IdRiesgo")
                Fila("Riesgo") = Dr("Riesgo")
                Fila("IdPlan") = Dr("IdPlan")
                Fila("Plan") = Dr("Plan")
                Fila("NroPlanes") = Dr("NroPlanes")
                Fila("IdPlazo") = Dr("IdPlazo")
                Fila("Plazo") = Dr("Plazo")
                Fila("IdCuota") = Dr("IdCuota")
                Fila("Cuota") = Dr("Cuota")
                Fila("Porcentaje") = Dr("Porcentaje")
                DtTemporal.Rows.Add(Fila)
            Next

            Session("RestriccionesTemporal") = DtTemporal

            Dim Coleccion() As String = Split(Request.QueryString("Codigo").ToString(), "|")

            Me.ddlDocumento.SelectedValue = Coleccion(0).ToString()
            Me.ddlRiesgo.SelectedValue = Coleccion(1).ToString()
            Me.ddlPlan.SelectedValue = Coleccion(2).ToString()
            Me.txtNroPlanes.Text = Coleccion(5).ToString()
            Me.ddlPlazos.SelectedValue = Coleccion(3).ToString()

            Dim IdDocumento As String = Coleccion(0).ToString()
            Dim IdRiesgo As String = Coleccion(1).ToString()
            Dim IdPlan As String = Coleccion(2).ToString()
            Dim IdPlazo As String = Coleccion(3).ToString()

            Dim Filtro As String = ""
            Filtro = Filtro + "IdDocumento = '" & IdDocumento & "' and "
            Filtro = Filtro + "IdRiesgo = '" & IdRiesgo & "' and "
            Filtro = Filtro + "IdPlan = '" & IdPlan & "' and "
            Filtro = Filtro + "IdPlazo = '" & IdPlazo & "' "

            Dim ArrDr() As DataRow = DtTemporal.Select(Filtro)
            If ArrDr.Length > 0 Then
                For Each Dr As DataRow In ArrDr
                    DtTemporal.Rows.Remove(Dr)
                Next
            End If

            Session("RestriccionesTemporal") = DtTemporal
        Else
            Session("RestriccionesTemporal") = CType(Session("Restricciones"), DataTable)
        End If
    End Sub

    Private Sub CargarCombos()
        Call Comunes.LlenarComboOrdenado(Me.ddlDocumento, obj.ListadoComboTipoDocumento, "DOCC_CODIGO", "DOCV_DESCRIPCION")
        Call Comunes.LlenarComboOrdenado(Me.ddlRiesgo, obj.ListadoComboRiesgo(CE_K0_TIPO_RIESGO), "RIEN_CODIGO", "RIEV_DESCRIPCION")
        Call Comunes.LlenarComboOrdenado(Me.ddlPlazos, obj.ListadoComboPlazoAcuerdo(CE_P_CASO_ESPECIAL), "PLZAC_CODIGO", "PLZAV_DESCRIPCION")
        Dim IdOferta As String = CType(Session("IdOferta"), String)

        Dim DtPlan As DataTable = CType(Session("Planes"), DataTable)
        Dim Dt As New DataTable
        Dt.Columns.Add("IdPlan", GetType(String))
        Dt.Columns.Add("Plan", GetType(String))
        For Each Dr As DataRow In DtPlan.Rows
            Dim Filtro As String = ""
            Filtro = Filtro + "IdPlan= '" + Convert.ToString(Dr("IdPlan")) + "' "
            Dim ArrDr() As DataRow = Dt.Select(Filtro)
            If ArrDr.Length = 0 Then
                Dim Fila As DataRow = Dt.NewRow
                Fila("IdPlan") = Convert.ToString(Dr("IdPlan"))
                Fila("Plan") = Convert.ToString(Dr("Plan"))
                Dt.Rows.Add(Fila)
            End If
        Next
        Call Comunes.LlenarComboOrdenado(Me.ddlPlan, Dt, "IdPlan", "Plan")
    End Sub

    Private Sub CargarCuotas()
        Dim Dt As DataTable = obj.ListadoTipoCuota()
        If Me.hidCondicion.Value = "Eliminar" Or Me.ddlPlazos.SelectedIndex = 0 Then
            Dt.Rows.Clear()
            Me.dgrCuotas.DataSource = Dt
            Me.dgrCuotas.DataBind()
        Else
            Me.dgrCuotas.DataSource = Dt
            Me.dgrCuotas.DataBind()
            Call ValoresMarcados()
        End If
        Me.hidCondicion.Value = Nothing
    End Sub

    Private Sub ValoresMarcados()
        If Not Session("Restricciones") Is Nothing Then
            Dim Dt As DataTable = CType(Session("Restricciones"), DataTable)

            If Dt Is Nothing Then
                Dt = New DataTable
                Dt.Columns.Add("IdDocumento", GetType(String))
                Dt.Columns.Add("Documento", GetType(String))
                Dt.Columns.Add("IdRiesgo", GetType(String))
                Dt.Columns.Add("Riesgo", GetType(String))
                Dt.Columns.Add("IdPlan", GetType(String))
                Dt.Columns.Add("Plan", GetType(String))
                Dt.Columns.Add("NroPlanes", GetType(Integer))
                Dt.Columns.Add("IdPlazo", GetType(String))
                Dt.Columns.Add("Plazo", GetType(String))
                Dt.Columns.Add("IdCuota", GetType(String))
                Dt.Columns.Add("Cuota", GetType(String))
                Dt.Columns.Add("Porcentaje", GetType(Double))
            End If

            For Each Item As DataGridItem In dgrCuotas.Items
                CType(Item.FindControl("txtPorcentaje"), TextBox).ReadOnly = True
                CType(Item.FindControl("txtPorcentaje"), TextBox).Text = ""
            Next

            Dim IdDocumento As String = Me.ddlDocumento.SelectedValue.ToString()
            Dim IdRiesgo As String = Me.ddlRiesgo.SelectedValue.ToString()
            Dim IdPlan As String = Me.ddlPlan.SelectedValue.ToString()
            Dim NroPlanes As Integer = Funciones.CheckInt(Me.txtNroPlanes.Text)
            Dim IdPlazo As String = Me.ddlPlazos.SelectedValue.ToString()

            Dim Filtro As String = ""
            Filtro = Filtro + "IdDocumento = '" & IdDocumento & "' and "
            Filtro = Filtro + "IdRiesgo = '" & IdRiesgo & "' and "
            Filtro = Filtro + "IdPlan = '" & IdPlan & "' and "
            Filtro = Filtro + "IdPlazo = '" & IdPlazo & "' "

            Dim ArrDr() As DataRow = Dt.Select(Filtro)

            For Each Dr As DataRow In ArrDr
                For Each Item As DataGridItem In dgrCuotas.Items
                    Dim IdCuotaDetalle As String = Funciones.CheckStr(Dr("IdCuota"))
                    Dim PorcentajeSession As Double = Funciones.CheckDbl(Dr("Porcentaje"))
                    Dim txtPorcentaje As TextBox = CType(Item.FindControl("txtPorcentaje"), TextBox)
                    If IdCuotaDetalle = Item.Cells(1).Text Then
                        CType(item.FindControl("chkMarcar"), CheckBox).Checked = True
                        txtPorcentaje.Text = PorcentajeSession.ToString("n2")
                        If IdCuotaDetalle = "00" Then
                            txtPorcentaje.ReadOnly = True
                        Else
                            txtPorcentaje.ReadOnly = False
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Function Validar() As Boolean
        Validar = False
        If Me.ddlDocumento.SelectedItem.Text = "--Seleccione--" Then
            RegisterStartupScript("script", "<script>alert('Seleccione el Documento'); document.getElementById('" & Me.ddlDocumento.ClientID & "').focus();</script>")
            Exit Function
        End If
        If Me.ddlRiesgo.SelectedItem.Text = "--Seleccione--" Then
            RegisterStartupScript("script", "<script>alert('Seleccione el Riesgo'); document.getElementById('" & Me.ddlRiesgo.ClientID & "').focus();</script>")
            Exit Function
        End If
        If Me.ddlPlan.SelectedItem.Text = "--Seleccione--" Then
            RegisterStartupScript("script", "<script>alert('Seleccione el Plan'); document.getElementById('" & Me.ddlPlan.ClientID & "').focus();</script>")
            Exit Function
        End If
        Dim NroPlanes As String = Me.txtNroPlanes.Text.Trim
        If NroPlanes = String.Empty Then
            RegisterStartupScript("script", "<script>alert('Ingrese el Nro de Planes'); document.getElementById('" & Me.txtNroPlanes.ClientID & "').focus();</script>")
            Exit Function
        End If
        'If Funciones.CheckInt(NroPlanes) = 0 Then
        '    RegisterStartupScript("script", "<script>alert('El Nro de Planes debe ser Mayor a 0'); document.getElementById('" & Me.txtNroPlanes.ClientID & "').focus();</script>")
        '    Exit Function
        'End If
        If Me.ddlPlazos.SelectedItem.Text = "--Seleccione--" Then
            RegisterStartupScript("script", "<script>alert('Seleccione el Plazo'); document.getElementById('" & Me.ddlPlazos.ClientID & "').focus();</script>")
            Exit Function
        End If
        If Me.dgrCuotas.Items.Count = 0 Then
            RegisterStartupScript("script", "<script>alert('Agregue Registros a Cuotas'); document.getElementById('" & Me.dgrCuotas.ClientID & "').focus();</script>")
            Exit Function
        End If
        Dim myCheckBox As CheckBox
        Dim myTextBox As TextBox
        Dim ContadorVacios As Integer = 0
        For Each Item As DataGridItem In dgrCuotas.Items
            myCheckBox = CType(Item.FindControl("chkMarcar"), CheckBox)
            If myCheckBox.Checked = True Then
                ContadorVacios = ContadorVacios + 1
            End If
        Next
        If ContadorVacios = 0 Then
            RegisterStartupScript("script", "<script>alert('Marque Registros para las Cuotas'); document.getElementById('" & Me.dgrCuotas.ClientID & "').focus();</script>")
            Exit Function
        End If
        For Each Item As DataGridItem In dgrCuotas.Items
            Dim IdCuota As String = Item.Cells(1).Text
            myCheckBox = CType(Item.FindControl("chkMarcar"), CheckBox)
            myTextBox = CType(Item.FindControl("txtPorcentaje"), TextBox)
            If myCheckBox.Checked Then
                If myTextBox.Text.Trim = String.Empty Then
                    myTextBox.ReadOnly = False
                    RegisterStartupScript("script", "<script>alert('Ingrese el Porcentaje'); document.getElementById('" & myTextBox.ClientID & "').focus();</script>")
                    Exit Function
                End If
                Dim Cadena As String = myTextBox.Text.ToString()
                Dim Contador As Integer = 0
                For Each I As Char In Cadena
                    If I = "." Then Contador = Contador + 1
                Next
                If Contador > 1 Then
                    myTextBox.ReadOnly = False
                    RegisterStartupScript("script", "<script>alert('Ingrese un Numero Válido para el Porcentaje'); document.getElementById('" & myTextBox.ClientID & "').focus();</script>")
                    Exit Function
                End If
                Dim Porcentaje As Double = Funciones.CheckDbl(Cadena)
                'If Porcentaje = 0 Then
                '    myTextBox.ReadOnly = False
                '    RegisterStartupScript("script", "<script>alert('El Porcentaje debe ser Mayor a Cero'); document.getElementById('" & myTextBox.ClientID & "').focus();</script>")
                '    Exit Function
                'End If
                If Porcentaje >= 0 And Porcentaje <= 100 Then
                Else
                    myTextBox.ReadOnly = False
                    RegisterStartupScript("script", "<script>alert('El Porcentaje de pago inicial debe ser mayor o igual a cero y No debe excederse del 100.00%'); document.getElementById('" & myTextBox.ClientID & "').focus();</script>")
                    Exit Function
                End If
                myTextBox.ReadOnly = True
            End If
        Next
        Validar = True
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Validar() = False Then Exit Sub
        If Not Session("RestriccionesTemporal") Is Nothing Then
            Dim Dt As DataTable = CType(Session("RestriccionesTemporal"), DataTable)
            If Dt Is Nothing Then
                Dt = New DataTable
                Dt.Columns.Add("IdDocumento", GetType(String))
                Dt.Columns.Add("Documento", GetType(String))
                Dt.Columns.Add("IdRiesgo", GetType(String))
                Dt.Columns.Add("Riesgo", GetType(String))
                Dt.Columns.Add("IdPlan", GetType(String))
                Dt.Columns.Add("Plan", GetType(String))
                Dt.Columns.Add("NroPlanes", GetType(Integer))
                Dt.Columns.Add("IdPlazo", GetType(String))
                Dt.Columns.Add("Plazo", GetType(String))
                Dt.Columns.Add("IdCuota", GetType(String))
                Dt.Columns.Add("Cuota", GetType(String))
                Dt.Columns.Add("Porcentaje", GetType(Double))
            End If

            Dim IdDocumento As String = Me.ddlDocumento.SelectedValue.ToString()
            Dim Documento As String = Me.ddlDocumento.SelectedItem.Text
            Dim IdRiesgo As String = Me.ddlRiesgo.SelectedValue.ToString()
            Dim Riesgo As String = Me.ddlRiesgo.SelectedItem.Text
            Dim IdPlan As String = Me.ddlPlan.SelectedValue.ToString()
            Dim Plan As String = Me.ddlPlan.SelectedItem.Text
            Dim NroPlanes As Integer = Funciones.CheckInt(Me.txtNroPlanes.Text)
            Dim IdPlazo As String = Me.ddlPlazos.SelectedValue.ToString()
            Dim Plazo As String = Me.ddlPlazos.SelectedItem.Text

            For Each Item As DataGridItem In Me.dgrCuotas.Items
                Dim Filtro As String = ""
                Filtro = Filtro + "IdDocumento = '" & IdDocumento & "' and "
                Filtro = Filtro + "IdRiesgo = '" & IdRiesgo & "' and "
                Filtro = Filtro + "IdPlan = '" & IdPlan & "' and "
                Filtro = Filtro + "IdPlazo = '" & IdPlazo & "' "
                Dim ArrDr() As DataRow = Dt.Select(Filtro)
                If ArrDr.Length > 0 Then
                    For Each Dr As DataRow In ArrDr
                        Dt.Rows.Remove(Dr)
                    Next
                End If
            Next
            For Each Item As DataGridItem In Me.dgrCuotas.Items
                Dim myCheckBox As CheckBox = CType(Item.FindControl("chkMarcar"), CheckBox)
                Dim myTextBox As TextBox = CType(Item.FindControl("txtPorcentaje"), TextBox)
                Dim IdCuota As String = Item.Cells(1).Text
                Dim Cuota As String = Item.Cells(2).Text
                Dim Porcentaje As Double = Funciones.CheckDbl(myTextBox.Text)
                If myCheckBox.Checked = True And myTextBox.Text <> "" Then
                    Dim Fila As DataRow = Dt.NewRow
                    Fila("IdDocumento") = IdDocumento
                    Fila("Documento") = Documento
                    Fila("IdRiesgo") = IdRiesgo
                    Fila("Riesgo") = Riesgo
                    Fila("IdPlan") = IdPlan
                    Fila("Plan") = Plan
                    Fila("NroPlanes") = NroPlanes
                    Fila("IdPlazo") = IdPlazo
                    Fila("Plazo") = Plazo
                    Fila("IdCuota") = IdCuota
                    Fila("Cuota") = Cuota
                    Fila("Porcentaje") = Porcentaje
                    Dt.Rows.Add(Fila)
                End If
            Next
            Session("Restricciones") = Dt
            Session("RestriccionesTemporal") = Nothing
            RegisterStartupScript("script", "<script>llamarPadre();</script>")
        End If
    End Sub

    Private Sub ddlPlazos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPlazos.SelectedIndexChanged
        Call CargarCuotas()
    End Sub

    Private Sub ddlDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDocumento.SelectedIndexChanged
        Dim IdTipoDocumento As String = ""
        Dim TipoDocumento As String = CE_K1_TIPO_RIESGO
        If Not Me.ddlDocumento.SelectedIndex = 0 Then
            IdTipoDocumento = Me.ddlDocumento.SelectedValue.ToString()
            Dim Grupo As String() = {CE_TD_DNI, CE_TD_CE}
            For I As Integer = 0 To Grupo.Length - 1
                If Grupo(I).ToString() = IdTipoDocumento Then
                    TipoDocumento = CE_K2_TIPO_RIESGO
                    Exit For
                End If
            Next
        End If
        Call Comunes.LlenarComboOrdenado(Me.ddlRiesgo, obj.ListadoComboRiesgo(TipoDocumento), "RIEN_CODIGO", "RIEV_DESCRIPCION")
    End Sub

    Private Sub dgrCuotas_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrCuotas.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then Exit Sub
            Dim IdCuota As String = e.Item.Cells(1).Text
            Dim txtPorcentaje_Server As TextBox = DirectCast(e.Item.FindControl("txtPorcentaje"), TextBox)
            Dim chkMarcar_Server As CheckBox = DirectCast(e.Item.FindControl("chkMarcar"), CheckBox)
            If Not chkMarcar_Server Is Nothing Then
                chkMarcar_Server.Attributes.Add("onclick", "chkEditar_Click('" & chkMarcar_Server.ClientID & "','" & txtPorcentaje_Server.ClientID & "', '" & IdCuota & "')")
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
