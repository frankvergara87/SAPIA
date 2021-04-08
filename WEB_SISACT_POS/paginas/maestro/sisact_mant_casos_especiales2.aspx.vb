Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports System.Text

Public Class sisact_mant_casos_especiales2
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkDNI As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkCE As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDNICE As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkRUC As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDocumentos As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnGrabar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCantMaximaporCasoEspecial As System.Web.UI.WebControls.TextBox
    Protected WithEvents trBusquedaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trGrillaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgPDV As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkCanal As System.Web.UI.WebControls.CheckBox
    'Protected WithEvents dgCanal As System.Web.UI.WebControls.DataGrid
    Protected WithEvents trGrillaCanal As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgPlanes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodigoEsp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCasoDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidCondicionPdv As System.Web.UI.HtmlControls.HtmlInputHidden
    'Protected WithEvents btnEliminarCanal As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCondicionCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hi As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnEditar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ddlDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnEliminarServer As System.Web.UI.WebControls.Button
    Protected WithEvents hiTab As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCondicionTAB As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnModificarServeer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEditarServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEditarPdvServer As System.Web.UI.WebControls.Button
    'Protected WithEvents btnEditarCanalServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEditarReglaServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEditarPlanServer As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents btnAgregarRestriccion As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregarPlan As System.Web.UI.WebControls.Button
    Protected WithEvents chkSolicitaCuotaInicial As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dgRestricciones As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkListaDocumento As System.Web.UI.WebControls.CheckBoxList
    'Protected WithEvents chkListaCampania As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents trPestanas As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hidIndice As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgCampanias As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents btnEliminarTodosCanalServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarTodosCampaniaServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarTodosPdvServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarCampaniaServer As System.Web.UI.WebControls.Button
    'Protected WithEvents btnEliminarCanalServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarPdvServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarPlanServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarTodosPlanServer As System.Web.UI.WebControls.Button
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCantMaximaPlanesVoz As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantMaximaPlanesDatos As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgCuotas As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgTopeConsumo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnEliminarTopeConsumoServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarRestriccionServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarTodosRestriccionServer As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPlazos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCuotas As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPorcentaje As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlOferta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnEliminarTodosCuotasServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarTodosTopeConsumoServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarCuotaServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregarServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnListadoServer As System.Web.UI.WebControls.Button
    Protected WithEvents Listad As System.Web.UI.WebControls.Label
    Protected WithEvents CheckWhiteList As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkWhiteList As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnGrabarServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnRecuperarValores As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportarCSV As System.Web.UI.WebControls.Button
    Protected WithEvents ddlEstadoConsulta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents imgMensaje As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnListado As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregarCuota As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private DtCuotas As DataTable
    Private DtCampanias As DataTable
    Private DtCanal As DataTable
    Private DtPDV As DataTable
    Private DtPlanes As DataTable
    Private DtRestricciones As DataTable
    Private DtTopeConsumo As DataTable

    Dim CE_ESTADO_ACTIVO As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_ESTADO_ACTIVO"))
    Dim CE_ESTADO_INACTIVO As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_ESTADO_INACTIVO"))
    Dim CE_P_CASO_ESPECIAL As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_P_CASO_ESPECIAL"))
    Dim CE_ITEM_01 As Integer = Funciones.CheckInt(ConfigurationSettings.AppSettings("CE_ITEM_01"))
    Dim CE_ITEM_02 As Integer = Funciones.CheckInt(ConfigurationSettings.AppSettings("CE_ITEM_02"))
    Dim CE_ESTADO_PLAN As Integer = Funciones.CheckInt(ConfigurationSettings.AppSettings("CE_ESTADO_PLAN"))

    Dim CE_CODAUDT_CONSULTAR As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_CODAUDT_CONSULTAR"))
    Dim CE_CODAUDT_INSERTAR As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_CODAUDT_INSERTAR"))
    Dim CE_CODAUDT_ACTUALIZAR As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_CODAUDT_ACTUALIZAR"))
    Dim CE_CODAUDT_DESACTIVAR As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_CODAUDT_DESACTIVAR"))


    Dim oLog As New SISACT_Log
    Dim nameFile As String = ConfigurationSettings.AppSettings("CE_CONS_NAMELOG")
    Dim oFile As String = oLog.Log_CrearNombreArchivo(nameFile)
    Dim strIdentifyLog As String = ""

    Private ent As New CasoEspecial
    Private obj As New CasoEspecialNegocios

#Region "Metodos"

    Private _Mensaje As String
    Private Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal Value As String)
            _Mensaje = Value
        End Set
    End Property

    Public Enum Acciones
        Consultar = 0
        Insertar = 1
        Actualizar = 2
    End Enum

    Private Sub LlenarListadoGeneral(ByVal Descripcion As String, ByVal IdEstado As String)
        Session("ListadoCasoEspecial") = obj.ListadoCasoEspecial(Descripcion, IdEstado, CE_ITEM_01)
        Call Comunes.LLenarDataGrid(Me.dgrGrillaDetalle, CType(Session("ListadoCasoEspecial"), DataTable))
        Session("FiltroCasoEspecial") = CType(Session("ListadoCasoEspecial"), DataTable)
    End Sub

    Private Sub LlenarCriterios()
        Me.ddlBusqueda.Items.Clear()
        Me.ddlBusqueda.Items.Insert(0, "DESCRIPCION")
        Me.ddlBusqueda.Items.Insert(1, "TODOS")
    End Sub

    Private Sub LlenarListaDocumentos()
        Dim Dt As DataTable = obj.ListadoComboTipoDocumento
        For Each Dr As DataRow In Dt.Rows
            Dim Item As New ListItem
            Item.Value = Dr("DOCC_CODIGO")
            Item.Text = Dr("DOCV_DESCRIPCION")
            Me.chkListaDocumento.Items.Add(Item)
        Next
        Me.chkListaDocumento.DataBind()
    End Sub

    Private Sub LlenarCombos()
        Call Comunes.LlenarComboOrdenado(Me.ddlEstadoConsulta, obj.ListadoComboEstado(CE_ITEM_01), "IDESTADO", "ESTADO", False)
        Call Comunes.LlenarComboOrdenado(Me.ddlEstado, obj.ListadoComboEstado(CE_ITEM_01), "IDESTADO", "ESTADO", False)
        Call Comunes.LlenarComboOrdenado(Me.ddlOferta, obj.ListarOferta(), "TOFC_CODIGO", "TOFV_DESCRIPCION")
        Call Comunes.LlenarComboOrdenado(Me.ddlPlazos, obj.ListadoComboPlazoAcuerdo(CE_P_CASO_ESPECIAL), "PLZAC_CODIGO", "PLZAV_DESCRIPCION")
        Call Comunes.LlenarComboOrdenado(Me.ddlCuotas, obj.ListadoTipoCuota(), "CUOC_CODIGO", "CUOV_DESCRIPCION")
    End Sub

    Private Sub LlenarSesiones(ByVal Limpiar As Boolean)
        If Session("Cuotas") Is Nothing Then
            DtCuotas = New DataTable
            DtCuotas.Columns.Add("IdPlazo", GetType(String))
            DtCuotas.Columns.Add("Plazo", GetType(String))
            DtCuotas.Columns.Add("IdCuota", GetType(String))
            DtCuotas.Columns.Add("Cuota", GetType(String))
            DtCuotas.Columns.Add("Porcentaje", GetType(Double))
            Session("Cuotas") = DtCuotas
        Else
            DtCuotas = CType(Session("Cuotas"), DataTable)
        End If

        If Limpiar = True Then
            DtCuotas.Clear()
            Session("Cuotas") = DtCuotas
            Me.dgCuotas.CurrentPageIndex = 0
        End If

        Me.dgCuotas.DataSource = DtCuotas
        Me.dgCuotas.DataBind()

        If Session("Campanias") Is Nothing Then
            DtCampanias = New DataTable
            DtCampanias.Columns.Add("IdCampania", GetType(String))
            DtCampanias.Columns.Add("Campania", GetType(String))
            DtCampanias.Columns.Add("Exclusiva", GetType(String))
            Session("Campanias") = DtCampanias
        Else
            DtCampanias = CType(Session("Campanias"), DataTable)
        End If
        If Limpiar = True Then
            DtCampanias.Clear()
            Session("Campanias") = DtCampanias
            Me.dgCampanias.CurrentPageIndex = 0
        End If
        Me.dgCampanias.DataSource = DtCampanias
        Me.dgCampanias.DataBind()

        If Session("PDV") Is Nothing Then
            DtPDV = New DataTable
            DtPDV.Columns.Add("IdPuntoVenta", GetType(String))
            DtPDV.Columns.Add("PuntoVenta", GetType(String))
            DtPDV.Columns.Add("Canal", GetType(String))
            Session("PDV") = DtPDV
        Else
            DtPDV = CType(Session("PDV"), DataTable)
        End If
        If Limpiar = True Then
            DtPDV.Clear()
            Session("PDV") = DtPDV
            Me.dgPDV.CurrentPageIndex = 0
        End If
        Me.dgPDV.DataSource = DtPDV
        Me.dgPDV.DataBind()

        If Session("Planes") Is Nothing Then
            DtPlanes = New DataTable
            DtPlanes.Columns.Add("IdPlan", GetType(String))
            DtPlanes.Columns.Add("Plan", GetType(String))
            DtPlanes.Columns.Add("NroPlanes", GetType(Integer))
            DtPlanes.Columns.Add("IdPlazo", GetType(String))
            DtPlanes.Columns.Add("Plazo", GetType(String))
            DtPlanes.Columns.Add("IdCuota", GetType(String))
            DtPlanes.Columns.Add("Cuota", GetType(String))
            DtPlanes.Columns.Add("Porcentaje", GetType(Double))
            Session("Planes") = DtPlanes
        Else
            DtPlanes = CType(Session("Planes"), DataTable)
        End If
        If Limpiar = True Then
            DtPlanes.Clear()
            Session("Planes") = DtPlanes
            Me.dgPlanes.CurrentPageIndex = 0
        End If
        Me.dgPlanes.DataSource = DtPlanes
        Me.dgPlanes.DataBind()

        If Session("Restricciones") Is Nothing Then
            DtRestricciones = New DataTable
            DtRestricciones.Columns.Add("IdDocumento", GetType(String))
            DtRestricciones.Columns.Add("Documento", GetType(String))
            DtRestricciones.Columns.Add("IdRiesgo", GetType(String))
            DtRestricciones.Columns.Add("Riesgo", GetType(String))
            DtRestricciones.Columns.Add("IdPlan", GetType(String))
            DtRestricciones.Columns.Add("Plan", GetType(String))
            DtRestricciones.Columns.Add("NroPlanes", GetType(Integer))
            DtRestricciones.Columns.Add("IdPlazo", GetType(String))
            DtRestricciones.Columns.Add("Plazo", GetType(String))
            DtRestricciones.Columns.Add("IdCuota", GetType(String))
            DtRestricciones.Columns.Add("Cuota", GetType(String))
            DtRestricciones.Columns.Add("Porcentaje", GetType(Double))
            Session("Restricciones") = DtRestricciones
        Else
            DtRestricciones = CType(Session("Restricciones"), DataTable)
        End If
        If Limpiar = True Then
            DtRestricciones.Clear()
            Session("Restricciones") = DtRestricciones
            Me.dgRestricciones.CurrentPageIndex = 0
        End If
        Me.dgRestricciones.DataSource = DtRestricciones
        Me.dgRestricciones.DataBind()

        If Session("TopeConsumo") Is Nothing Then
            DtTopeConsumo = New DataTable
            DtTopeConsumo.Columns.Add("IdPlan", GetType(String))
            DtTopeConsumo.Columns.Add("Plan", GetType(String))
            DtTopeConsumo.Columns.Add("IdTopeConsumo", GetType(Integer))
            DtTopeConsumo.Columns.Add("TopeConsumo", GetType(String))
            DtTopeConsumo.Columns.Add("IdEstadoTope", GetType(String))
            DtTopeConsumo.Columns.Add("EstadoTope", GetType(String))
            Session("TopeConsumo") = DtTopeConsumo
        Else
            DtTopeConsumo = CType(Session("TopeConsumo"), DataTable)
        End If
        If Limpiar = True Then
            DtTopeConsumo.Clear()
            Session("TopeConsumo") = DtTopeConsumo
            Me.dgTopeConsumo.CurrentPageIndex = 0
        End If
        Me.dgTopeConsumo.DataSource = DtTopeConsumo
        Me.dgTopeConsumo.DataBind()
    End Sub

    Private Function Validar() As Boolean
        Validar = False
        If Me.txtCasoDescripcion.Text.Trim = String.Empty Then
            Me.hidCondicionPdv.Value = "VALIDACION"
            RegisterStartupScript("script", "<script>alert('Ingrese la Descripcion'); document.getElementById('" & Me.txtCasoDescripcion.ClientID & "').focus();</script>")
            Exit Function
        End If
        Dim ContadorDocumentos As Integer = 0
        For Each Item As ListItem In Me.chkListaDocumento.Items
            If Item.Selected = True Then
                ContadorDocumentos = ContadorDocumentos + 1
            End If
        Next
        If ContadorDocumentos = 0 Then
            Me.hidCondicionPdv.Value = "VALIDACION"
            RegisterStartupScript("script", "<script>alert('Marque por lo menos un Documento'); document.getElementById('" & chkListaDocumento.ClientID & "').focus();</script>")
            Exit Function
        End If
        Dim CantidadPlan As Integer = Funciones.CheckInt(Me.txtCantMaximaporCasoEspecial.Text.ToString)
        'If CantidadPlan = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>alert('Ingrese la Cantidad Máxima para Caso Especial'); document.getElementById('" & Me.txtCantMaximaporCasoEspecial.ClientID & "').focus();</script>")
        '    Exit Function
        'End If
        Dim CantidadPlanesVoz As Integer = Funciones.CheckInt(Me.txtCantMaximaPlanesVoz.Text.ToString)
        'If CantidadPlanesVoz = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>alert('Ingrese la Cantidad Máxima para Planes de Voz'); document.getElementById('" & Me.txtCantMaximaPlanesVoz.ClientID & "').focus();</script>")
        '    Exit Function
        'End If
        Dim CantidadPlanesDatos As Integer = Funciones.CheckInt(Me.txtCantMaximaPlanesDatos.Text.ToString)
        'If CantidadPlanesDatos = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>alert('Ingrese la Cantidad Máxima para Planes de Datos'); document.getElementById('" & Me.txtCantMaximaPlanesDatos.ClientID & "').focus();</script>")
        '    Exit Function
        'End If
        If CantidadPlanesDatos > CantidadPlan Then
            Me.hidCondicionPdv.Value = "VALIDACION"
            RegisterStartupScript("script", "<script>alert('La Cantidad de Planes de Datos no puede ser superior a la Cantidad Máxima por Plan'); document.getElementById('" & Me.txtCantMaximaPlanesDatos.ClientID & "').focus();</script>")
            Exit Function
        End If
        If CantidadPlanesVoz > CantidadPlan Then
            Me.hidCondicionPdv.Value = "VALIDACION"
            RegisterStartupScript("script", "<script>alert('La Cantidad de Planes de Voz no puede ser superior a la Cantidad Máxima por Plan'); document.getElementById('" & Me.txtCantMaximaPlanesDatos.ClientID & "').focus();</script>")
            Exit Function
        End If
        If Me.ddlOferta.SelectedIndex = 0 Then
            Me.hidCondicionPdv.Value = "VALIDACION"
            RegisterStartupScript("script", "<script>alert('Seleccione la Oferta'); document.getElementById('" & Me.ddlOferta.ClientID & "').focus();</script>")
            Exit Function
        End If
        'If Me.dgCuotas.Items.Count = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>f_mostrarPestaña('1');alert('Agrege un Item al Detalle de CUOTAS');</script>")
        '    Exit Function
        'End If
        'If Me.dgCampanias.Items.Count = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>f_mostrarPestaña('1');alert('Agrege un Item al Detalle de PUNTO DE VENTA');</script>")
        '    Exit Function
        'End If
        'If Me.dgCuotas.Items.Count = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>alert('Agrege un Item al Detalle A CUOTAS');</script>")
        '    Exit Function
        'End If
        'If Me.dgPDV.Items.Count = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>f_mostrarPestaña('2');alert('Agrege un Item al Detalle de PUNTO DE VENTA');</script>")
        '    Exit Function
        'End If
        'If Me.dgPlanes.Items.Count = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>f_mostrarPestaña('3');alert('Agrege un Item al Detalle de PLANES');</script>")
        '    Exit Function
        'End If
        'If Me.dgRestricciones.Items.Count = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>f_mostrarPestaña('4');alert('Agrege un Item al Detalle de RESTRICCIONES');</script>")
        '    Exit Function
        'End If
        'If Me.dgTopeConsumo.Items.Count = 0 Then
        '    Me.hidCondicionPdv.Value = "VALIDACION"
        '    RegisterStartupScript("script", "<script>f_mostrarPestaña('5');alert('Agrege un Item al Detalle de TOPES DE CONSUMO');</script>")
        '    Exit Function
        'End If
        Validar = True
    End Function

    Private Sub Validaciones()
        If Validar() = False Then Exit Sub
        'Validación de Negocio Duplicidad
        Dim Codigo As String = Me.txtCodigoEsp.Text.Trim()
        Dim Descripcion As String = Me.txtCasoDescripcion.Text.Trim.ToUpper()
        Dim Accion As Integer = CType(Session("Accion"), Integer)
        Dim Resultado As Boolean = False
        If Accion = Acciones.Insertar Then 'Insertar
            Resultado = obj.ValidaCasoEspecial(Accion, Codigo, Descripcion)
        ElseIf Accion = Acciones.Actualizar Then 'Actualizar
            Resultado = obj.ValidaCasoEspecial(Accion, Codigo, Descripcion)
        End If
        If Resultado = True Then
            RegisterStartupScript("script", "<script>alert('La Descripción de este Caso Especial ya existe, Verifique');</script>")
            Exit Sub
        End If
        RegisterStartupScript("script", "<script>f_Grabar();</script>")
    End Sub

    Private Sub Grabar()

        Try

            Dim Codigo As String = Me.txtCodigoEsp.Text.Trim()
            Dim Descripcion As String = Me.txtCasoDescripcion.Text.Trim.ToUpper()
            Dim IdEstado As String = Me.ddlEstado.SelectedValue.ToString()
            Dim WhiteList As Integer
            If Me.chkWhiteList.Checked = True Then WhiteList = 1
            If Me.chkWhiteList.Checked = False Then WhiteList = 0
            Dim DtDocumento As New DataTable
            DtDocumento.Columns.Add("IdDocumento", GetType(String))
            For Each Item As ListItem In Me.chkListaDocumento.Items
                If Item.Selected = True Then
                    Dim Row As DataRow = DtDocumento.NewRow
                    Row("IdDocumento") = Item.Value.ToString()
                    DtDocumento.Rows.Add(Row)
                End If
            Next
            Dim DtCuotas As DataTable = CType(Session("Cuotas"), DataTable)
            Dim CantidadPlanMaxima As Integer = Funciones.CheckInt(Me.txtCantMaximaporCasoEspecial.Text)
            Dim CantidadPlanVoz As Integer = Funciones.CheckInt(Me.txtCantMaximaPlanesVoz.Text)
            Dim CantidadPlanDatos As Integer = Funciones.CheckInt(Me.txtCantMaximaPlanesDatos.Text)
            Dim IdOferta As String = Me.ddlOferta.SelectedItem.Value.ToString()
            Dim DtCampanias As DataTable = CType(Session("Campanias"), DataTable)
            Dim DtPdv As DataTable = CType(Session("PDV"), DataTable)
            Dim DtPlanes As DataTable = CType(Session("Planes"), DataTable)
            Dim DtRestricciones As DataTable = CType(Session("Restricciones"), DataTable)
            Dim DtTopeConsumo As DataTable = CType(Session("TopeConsumo"), DataTable)

            'Llamar Procedimiento de Grabar

            Dim ent As New CasoEspecial

            ent.Codigo = Codigo
            ent.Descripcion = Descripcion
            ent.IdEstado = IdEstado
            ent.WhiteList = WhiteList

            ent.MaxPlanes = CantidadPlanMaxima
            ent.MaxPlanesDatos = CantidadPlanDatos
            ent.MaxPlanesVoz = CantidadPlanVoz
            ent.IdOferta = IdOferta

            ent.DtCasoEspecialDocumento = DtDocumento
            ent.DtCasoEspecialCuota = DtCuotas
            ent.DtCasoEspecialCampania = DtCampanias
            ent.DtCasoEspecialPDV = DtPdv
            ent.DtCasoEspecialPlan = DtPlanes
            ent.DtCasoEspecialRiesgo = DtRestricciones
            ent.DtCasoEspecialTopeConsumo = DtTopeConsumo
            ent.Usuario = CurrentUser() 'CType(Session("codUsuarioSisact"), String)

            Dim Operacion As String = ""
            Dim Valores As String = ""
            Dim Comentario As String = ""

            Valores = Valores + " Codigo: " + ent.Codigo
            Valores = Valores + " Descripcion: " + ent.Descripcion
            Valores = Valores + " IdEstado: " + ent.IdEstado
            Valores = Valores + " WhiteList: " + ent.WhiteList.ToString
            Valores = Valores + " MaxPlanes: " + ent.MaxPlanes.ToString
            Valores = Valores + " MaxPlanesDatos: " + ent.MaxPlanesDatos.ToString
            Valores = Valores + " MaxPlanesVoz: " + ent.MaxPlanesVoz.ToString
            Valores = Valores + " IdOferta: " + ent.IdOferta
            Valores = Valores + " Usuario: " + ent.Usuario
            Valores = Valores.Trim

            If Session("Accion") = Acciones.Actualizar Then ' Actualizar
                Operacion = "Actualizar Caso Especial"
                Comentario = "Iniciando Actualizar el Caso Especial"
                Call Log(Operacion, "-->", Comentario)
                Call Log("Enviando Variables", Valores, "")
                If Transaccion(ent, Acciones.Actualizar) = True Then
                    Comentario = "Se Terminó de Actualizar con Éxito el Caso Especial"
                    Call Auditoria(CE_CODAUDT_ACTUALIZAR, "El Caso Especial " + Valores + " se Actualizó Correctamente")
                    Call Log(Operacion, "-->", Comentario + Environment.NewLine)
                    Call RecuperarValores(ent.Codigo, Acciones.Actualizar)
                Else
                    Comentario = "Se Presentaron Errores al Actualizar el Caso Especial"
                    Call Auditoria(CE_CODAUDT_ACTUALIZAR, Comentario + " " + Valores)
                    Call Log(Operacion, Valores, Comentario + Environment.NewLine)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                End If
            End If
            If Session("Accion") = Acciones.Insertar Then 'Insertar
                Operacion = "Insertar Caso Especial"
                Comentario = "Iniciando Insertar el Caso Especial"
                Call Log(Operacion, "-->", Comentario)
                Call Log("Enviando Variables", Valores, "")
                If Transaccion(ent, Acciones.Insertar) = True Then
                    Comentario = "Se Terminó de Insertar con Éxito el Caso Especial"
                    Call Auditoria(CE_CODAUDT_INSERTAR, "El Caso Especial " + Valores + " se Insertó Correctamente")
                    Call Log(Operacion, "-->", Comentario + Environment.NewLine)
                    Call RecuperarValores(ent.Codigo, Acciones.Insertar)
                Else
                    Comentario = "Se Presentaron Errores al Insertar el Caso Especial"
                    Call Auditoria(CE_CODAUDT_INSERTAR, Comentario + " " + Valores)
                    Call Log(Operacion, Valores, Comentario + Environment.NewLine)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                End If
            End If

        Catch ex As Exception
            If Session("Accion") = Acciones.Actualizar Then 'Actualizar
                RegisterStartupScript("script", "<script>f_Resultado();alert('Error al Actualizar El Caso Especial');</script>")
            End If
            If Session("Accion") = Acciones.Insertar Then 'Insertar
                RegisterStartupScript("script", "<script>f_Resultado();alert('Error al Insertar El Caso Especial');</script>")
            End If
            Dim Mensaje As String = ex.Message.ToString
            Mensaje = Comunes.QuitarSaltosLinea(Mensaje, " ")
            Mensaje = Mensaje.Replace(Environment.NewLine, " ")
            Me.lblMensaje.Text = Mensaje
        End Try
    End Sub

    Private Function Transaccion(ByVal ent As CasoEspecial, ByVal Accion As Integer) As Boolean
        Dim Titulo As String = ""
        Dim Operacion As String = ""
        Dim Valores As String = ""
        Dim Comentario As String = ""

        Dim Resultado As Boolean = True
        Try

            If Resultado = True Then

                If Accion = Acciones.Insertar Then
                    Resultado = obj.InsertarCasoEspecial(ent)
                End If

                If Accion = Acciones.Actualizar Then
                    Resultado = obj.ActualizarCasoEspecial(ent)
                End If

            End If

            If Resultado = True Then
                Resultado = obj.EliminarDetalleDocumentos(ent.Codigo)
                Valores = "Codigo: " + ent.Codigo
                Titulo = "Eliminar Físicamente el Detalle de Documento en Caso Especial"
                If Resultado = False Then
                    Operacion = "Falla al " + Titulo
                    Comentario = "Descripción: " + obj.Mensaje
                    Call Log(Operacion, Valores, Comentario)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                Else
                    Operacion = "Éxito al " + Titulo
                    Call Log(Operacion, Valores, "")
                End If
            End If
            If Resultado = True Then
                If Not ent.DtCasoEspecialDocumento Is Nothing Then
                    If ent.DtCasoEspecialDocumento.Rows.Count > 0 Then
                        For Each Row As DataRow In ent.DtCasoEspecialDocumento.Rows
                            Dim IdDocumento As String = Funciones.CheckStr(Row("IdDocumento"))
                            Resultado = obj.InsertarCasoEspecialDocumento(ent.Codigo, IdDocumento)
                            Valores = "Codigo: " + ent.Codigo + " IdDocumento: " + IdDocumento
                            Titulo = "Insertar Detalle de Documento en Caso Especial"
                            If Resultado = False Then
                                Operacion = "Falla al " + Titulo
                                Comentario = "Descripción: " + obj.Mensaje
                                Call Log(Operacion, Valores, Comentario)
                                Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                            Else
                                Operacion = "Éxito al " + Titulo
                                Call Log(Operacion, Valores, "")
                            End If
                        Next
                    End If
                End If
            End If
            If Resultado = True Then
                Resultado = obj.EliminarDetalleCuotas(ent.Codigo)
                Valores = "Codigo: " + ent.Codigo
                Titulo = "Eliminar Físicamente el Detalle de Cuotas en Caso Especial"
                If Resultado = False Then
                    Operacion = "Falla al " + Titulo
                    Comentario = "Descripción: " + obj.Mensaje
                    Call Log(Operacion, Valores, Comentario)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                Else
                    Operacion = "Éxito al " + Titulo
                    Call Log(Operacion, Valores, "")
                End If
            End If
            If Resultado = True Then
                If Not ent.DtCasoEspecialCuota Is Nothing Then
                    If ent.DtCasoEspecialCuota.Rows.Count > 0 Then
                        For Each Row As DataRow In ent.DtCasoEspecialCuota.Rows
                            Dim IdPlazo As String = Funciones.CheckStr(Row("IdPlazo"))
                            Dim IdCuota As String = Funciones.CheckStr(Row("IdCuota"))
                            Dim Porcentaje As Decimal = Funciones.CheckDecimal(Row("Porcentaje"))
                            Valores = "Codigo: " + ent.Codigo + " IdPlazo: " + IdPlazo + " IdCuota: " + IdCuota + " Porcentaje: " + Porcentaje.ToString
                            Titulo = "Insertar Detalle de Cuotas en Caso Especial"
                            Resultado = obj.InsertarCasoEspecialCuotas(ent.Codigo, IdPlazo, IdCuota, Porcentaje)
                            If Resultado = False Then
                                Operacion = "Falla al " + Titulo
                                Comentario = "Descripción: " + obj.Mensaje
                                Call Log(Operacion, Valores, Comentario)
                                Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                            Else
                                Operacion = "Éxito al " + Titulo
                                Call Log(Operacion, Valores, "")
                            End If
                        Next
                    End If
                End If
            End If
            If Resultado = True Then
                Resultado = obj.EliminarDetalleCampania(ent.Codigo)
                Valores = "Codigo: " + ent.Codigo
                Titulo = "Eliminar Físicamente el Detalle de Campañas en Caso Especial"
                If Resultado = False Then
                    Operacion = "Falla al " + Titulo
                    Comentario = "Descripción: " + obj.Mensaje
                    Call Log(Operacion, Valores, Comentario)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                Else
                    Operacion = "Éxito al " + Titulo
                    Call Log(Operacion, Valores, "")
                End If
            End If
            If Resultado = True Then
                If Not ent.DtCasoEspecialCampania Is Nothing Then
                    If ent.DtCasoEspecialCampania.Rows.Count > 0 Then
                        For Each Row As DataRow In ent.DtCasoEspecialCampania.Rows
                            Dim IdCampania As String = Funciones.CheckStr(Row("IdCampania"))
                            Dim Campania As String = Funciones.CheckStr(Row("Campania"))
                            Dim Exclusiva As String = Funciones.CheckStr(Row("Exclusiva"))
                            Resultado = obj.InsertarCasoEspecialCampanias(ent.Codigo, IdCampania, Campania, Exclusiva)
                            Valores = "Codigo: " + ent.Codigo + " IdCampania: " + IdCampania + " Campania: " + Campania + " Exclusiva: " + Exclusiva
                            Titulo = "Insertar Detalle de Campañas en Caso Especial"
                            If Resultado = False Then
                                Operacion = "Falla al " + Titulo
                                Comentario = "Descripción: " + obj.Mensaje
                                Call Log(Operacion, Valores, Comentario)
                                Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                            Else
                                Operacion = "Éxito al " + Titulo
                                Call Log(Operacion, Valores, "")
                            End If
                        Next
                    End If
                End If
            End If
            If Resultado = True Then
                Resultado = obj.EliminarDetallePDV(ent.Codigo)
                Valores = "Codigo: " + ent.Codigo
                Titulo = "Eliminar Físicamente el Detalle de Puntos de Venta en Caso Especial"
                If Resultado = False Then
                    Operacion = "Falla al " + Titulo
                    Comentario = "Descripción: " + obj.Mensaje
                    Call Log(Operacion, Valores, Comentario)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                Else
                    Operacion = "Éxito al " + Titulo
                    Call Log(Operacion, Valores, "")
                End If
            End If
            If Resultado = True Then
                If Not ent.DtCasoEspecialPDV Is Nothing Then
                    If ent.DtCasoEspecialPDV.Rows.Count > 0 Then
                        For Each Row As DataRow In ent.DtCasoEspecialPDV.Rows
                            Dim IdPuntoVenta As String = Funciones.CheckStr(Row("IdPuntoVenta"))
                            Dim Canal As String = Funciones.CheckStr(Row("Canal"))
                            Resultado = obj.InsertarCasoEspecialPDV(ent.Codigo, IdPuntoVenta, Canal)
                            Valores = "Codigo: " + ent.Codigo + " IdPuntoVenta: " + IdPuntoVenta + " | Canal: " + Canal
                            Titulo = "Insertar Detalle de Puntos de Venta en Caso Especial"
                            If Resultado = False Then
                                Operacion = "Falla al " + Titulo
                                Comentario = "Descripción: " + obj.Mensaje
                                Call Log(Operacion, Valores, Comentario)
                                Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                            Else
                                Operacion = "Éxito al " + Titulo
                                Call Log(Operacion, Valores, "")
                            End If
                        Next
                    End If
                End If
            End If
            If Resultado = True Then
                Resultado = obj.EliminarDetallePlanes(ent.Codigo)
                Valores = "Codigo: " + ent.Codigo
                Titulo = "Eliminar Físicamente el Detalle de Planes en Caso Especial"
                If Resultado = False Then
                    Operacion = "Falla al " + Titulo
                    Comentario = "Descripción: " + obj.Mensaje
                    Call Log(Operacion, Valores, Comentario)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                Else
                    Operacion = "Éxito al " + Titulo
                    Call Log(Operacion, Valores, "")
                End If
            End If
            If Resultado = True Then
                If Not ent.DtCasoEspecialPlan Is Nothing Then
                    If ent.DtCasoEspecialPlan.Rows.Count > 0 Then
                        For Each Row As DataRow In ent.DtCasoEspecialPlan.Rows
                            Dim IdPlan As String = Funciones.CheckStr(Row("IdPlan"))
                            Dim NroPlanes As Integer = Funciones.CheckInt(Row("NroPlanes"))
                            Dim IdPlazo As String = Funciones.CheckStr(Row("IdPlazo"))
                            Dim IdCuota As String = Funciones.CheckStr(Row("IdCuota"))
                            Dim Porcentaje As Decimal = Funciones.CheckDecimal(Row("Porcentaje"))
                            Resultado = obj.InsertarCasoEspecialPlanes(ent.Codigo, IdPlan, NroPlanes, IdPlazo, IdCuota, Porcentaje)
                            Valores = "Codigo: " + ent.Codigo + " IdPlan: " + IdPlan + " NroPlanes: " + NroPlanes.ToString + " IdPlazo: " + IdPlazo + " IdCuota: " + IdCuota + " Porcentaje: " + Porcentaje.ToString
                            Titulo = "Insertar Detalle de Planes en Caso Especial"
                            If Resultado = False Then
                                Operacion = "Falla al " + Titulo
                                Comentario = "Descripción: " + obj.Mensaje
                                Call Log(Operacion, Valores, Comentario)
                                Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                            Else
                                Operacion = "Éxito al " + Titulo
                                Call Log(Operacion, Valores, "")
                            End If
                        Next
                    End If
                End If
            End If
            If Resultado = True Then
                Resultado = obj.EliminarDetalleRiesgos(ent.Codigo)
                Valores = "Codigo: " + ent.Codigo
                Titulo = "Eliminar Físicamente el Detalle de Riesgos en Caso Especial"
                If Resultado = False Then
                    Operacion = "Falla al " + Titulo
                    Comentario = "Descripción: " + obj.Mensaje
                    Call Log(Operacion, Valores, Comentario)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                Else
                    Operacion = "Éxito al " + Titulo
                    Call Log(Operacion, Valores, "")
                End If
            End If
            If Resultado = True Then
                If Not ent.DtCasoEspecialRiesgo Is Nothing Then
                    If ent.DtCasoEspecialRiesgo.Rows.Count > 0 Then
                        For Each Row As DataRow In ent.DtCasoEspecialRiesgo.Rows
                            Dim IdDocumento As String = Funciones.CheckStr(Row("IdDocumento"))
                            Dim IdRiesgo As String = Funciones.CheckStr(Row("IdRiesgo"))
                            Dim IdPlan As String = Funciones.CheckStr(Row("IdPlan"))
                            Dim NroPlanes As Integer = Funciones.CheckInt(Row("NroPlanes"))
                            Dim IdPlazo As String = Funciones.CheckStr(Row("IdPlazo"))
                            Dim IdCuota As String = Funciones.CheckStr(Row("IdCuota"))
                            Dim Porcentaje As Decimal = Funciones.CheckDecimal(Row("Porcentaje"))
                            Resultado = obj.InsertarCasoEspecialRiesgos(ent.Codigo, IdDocumento, IdRiesgo, IdPlan, NroPlanes, IdPlazo, IdCuota, Porcentaje)
                            Valores = "Codigo: " + ent.Codigo + " IdDocumento: " + IdDocumento + " IdRiesgo: " + IdRiesgo + " IdPlan: " + IdPlan + " NroPlanes: " + NroPlanes.ToString + " IdPlazo: " + IdPlazo + " IdCuota: " + IdCuota + " Porcentaje: " + Porcentaje.ToString
                            Titulo = "Insertar Detalle de Riesgos en Caso Especial"
                            If Resultado = False Then
                                Operacion = "Falla al " + Titulo
                                Comentario = "Descripción: " + obj.Mensaje
                                Call Log(Operacion, Valores, Comentario)
                                Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                            Else
                                Operacion = "Éxito al " + Titulo
                                Call Log(Operacion, Valores, "")
                            End If
                        Next
                    End If
                End If
            End If
            If Resultado = True Then
                Resultado = obj.EliminarDetalleTopeConsumo(ent.Codigo)
                Valores = "Codigo: " + ent.Codigo
                Titulo = "Eliminar Físicamente el Detalle de Topes de Consumo en Caso Especial"
                If Resultado = False Then
                    Operacion = "Falla al " + Titulo
                    Comentario = "Descripción: " + obj.Mensaje
                    Call Log(Operacion, Valores, Comentario)
                    Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                Else
                    Operacion = "Éxito al " + Titulo
                    Call Log(Operacion, Valores, "")
                End If
            End If
            If Resultado = True Then
                If Not ent.DtCasoEspecialTopeConsumo Is Nothing Then
                    If ent.DtCasoEspecialTopeConsumo.Rows.Count > 0 Then
                        For Each Row As DataRow In ent.DtCasoEspecialTopeConsumo.Rows
                            Dim IdPlan As String = Funciones.CheckStr(Row("IdPlan"))
                            Dim IdTopeConsumo As Integer = Funciones.CheckInt(Row("IdTopeConsumo"))
                            Dim IdEstadoTope As String = Funciones.CheckStr(Row("IdEstadoTope"))
                            Resultado = obj.InsertarCasoEspecialTopeConsumo(ent.Codigo, IdPlan, IdTopeConsumo, IdEstadoTope)
                            Valores = "Codigo: " + ent.Codigo + " IdPlan: " + IdPlan + " IdTopeConsumo: " + IdTopeConsumo.ToString + " IdEstadoTope: " + IdEstadoTope
                            Titulo = "Insertar Detalle de Topes de Consumo en Caso Especial"
                            If Resultado = False Then
                                Operacion = "Falla al " + Titulo
                                Comentario = "Descripción: " + obj.Mensaje
                                Call Log(Operacion, Valores, Comentario)
                                Throw New Exception(Operacion + " --> | " + Valores + " " + Comentario)
                            Else
                                Operacion = "Éxito al " + Titulo
                                Call Log(Operacion, Valores, "")
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            Mensaje = ex.Message.ToString
        End Try
        Return Resultado
    End Function

    Private Sub Cancelar()
        RegisterStartupScript("script", "<script>f_Listado();</script>")
    End Sub

    Private Sub Eliminar()
        Dim Codigo As String = Me.hidCodigo.Value.ToString
        Call Log("Desactivar Caso Especial", "-->", "Iniciando Desactivar el Caso Especial")
        Call Log("Enviando Variables", "Codigo: " + Codigo, "")
        If obj.EliminarCasoEspecial(Codigo) = True Then
            Call Auditoria(CE_CODAUDT_DESACTIVAR, "El Caso Especial Codigo: " + Codigo + " se Desactivó de Manera Lógica Correctamente")
            Call Log("Desactivar Caso Especial", "-->", "Se Terminó de Desactivar con Éxito el Caso Especial")
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_Listado();alert('El Caso Especial se Desactivó Correctamente');</script>")
        Else
            Call Auditoria(CE_CODAUDT_DESACTIVAR, "Se Presentaron Errores al Desactivar el Caso Especial Codigo: " + Codigo)
            Call Log("Actualizar Caso Especial", "-->", "Se Presentaron Errores al Desactivar el Caso Especial")
            RegisterStartupScript("script", "<script>alert('Error al Desactivar El Caso Especial');</script>")
        End If
        Me.hidCodigo.Value = Nothing
    End Sub

    Private Function ValidarDetalle() As Boolean
        ValidarDetalle = False
        If Me.ddlPlazos.SelectedIndex = 0 Then
            RegisterStartupScript("script", "<script>alert('Seleccione el Plazo'); document.getElementById('" & Me.ddlPlazos.ClientID & "').focus();</script>")
            Exit Function
        End If
        If Me.ddlCuotas.SelectedIndex = 0 Then
            RegisterStartupScript("script", "<script>alert('Seleccione la Cuota'); document.getElementById('" & Me.ddlCuotas.ClientID & "').focus();</script>")
            Exit Function
        End If
        Dim IdCuota As String = Me.ddlCuotas.SelectedItem.Value.ToString()
        If Me.txtPorcentaje.Text.Trim = String.Empty Then
            RegisterStartupScript("script", "<script>alert('Ingrese el Porcentaje'); document.getElementById('" & Me.txtPorcentaje.ClientID & "').focus();</script>")
            Exit Function
        End If
        Dim Cadena As String = Me.txtPorcentaje.Text.ToString()
        Dim Contador As Integer = 0
        For Each I As Char In Cadena
            If I = "." Then Contador = Contador + 1
        Next
        If Contador > 1 Then
            RegisterStartupScript("script", "<script>alert('Ingrese un Numero Válido para el Porcentaje'); document.getElementById('" & Me.txtPorcentaje.ClientID & "').focus();</script>")
            Exit Function
        End If
        Dim Porcentaje As Double = Funciones.CheckDbl(Cadena)
        'If Porcentaje >= 0 And Porcentaje <= 100 Then
        'Else
        '    RegisterStartupScript("script", "<script>alert('El Porcentaje de pago inicial debe ser Mayor a cero y No debe excederse del 100.00%'); document.getElementById('" & Me.txtPorcentaje.ClientID & "').focus();</script>")
        '    Exit Function
        'End If

        'If Porcentaje = 0 Then
        '    RegisterStartupScript("script", "<script>alert('El Porcentaje debe ser Mayor a Cero'); document.getElementById('" & Me.txtPorcentaje.ClientID & "').focus();</script>")
        '    Exit Function
        'End If

        Dim IdPlazo As String = Me.ddlPlazos.SelectedItem.Value.ToString()

        If Not Session("Cuotas") Is Nothing Then
            Dim Dt As DataTable = CType(Session("Cuotas"), DataTable)

            Dim Filtro As String = ""
            Filtro = Filtro + "IdPlazo= '" + IdPlazo + "' and "
            Filtro = Filtro + "IdCuota= '" + IdCuota + "'"

            Dim ArrDr() As DataRow = Dt.Select(Filtro)
            If ArrDr.Length > 0 Then
                For I As Integer = 0 To Dt.Rows.Count - 1
                    Dim IdPlazoSession As String = Convert.ToString(Dt.Rows(I).Item("IdPlazo"))
                    Dim IdCuotaSession As String = Convert.ToString(Dt.Rows(I).Item("IdCuota"))
                    Dim PorcentajeSession As Double = Convert.ToDouble(Dt.Rows(I).Item("Porcentaje"))
                    If IdPlazo = IdPlazoSession And IdCuota = IdCuotaSession Then
                        Dim NuevoPorcentaje As Double = PorcentajeSession + Porcentaje
                        If NuevoPorcentaje >= 0 And NuevoPorcentaje <= 100 Then
                        Else
                            RegisterStartupScript("script", "<script>alert('El Porcentaje de pago inicial debe ser mayor o igual a cero y No debe excederse del 100.00%'); </script>")
                            Exit Function
                        End If
                    End If
                Next
            End If

        End If

        ValidarDetalle = True
    End Function

    Private Sub AgregarDetalle()
        If ValidarDetalle() = False Then Exit Sub
        Dim Dt As DataTable = Session("Cuotas")
        Dim IdPlazo As String = Me.ddlPlazos.SelectedItem.Value.ToString()
        Dim Plazo As String = Me.ddlPlazos.SelectedItem.Text.ToString()
        Dim IdCuota As String = Me.ddlCuotas.SelectedItem.Value.ToString()
        Dim Cuota As String = Me.ddlCuotas.SelectedItem.Text.ToString()
        Dim Cadena As String = Me.txtPorcentaje.Text.ToString()
        Dim Porcentaje As Double = Funciones.CheckDbl(Cadena)
        Dim Filtro As String = ""
        Filtro = Filtro + "IdPlazo= '" + IdPlazo + "' and "
        Filtro = Filtro + "IdCuota= '" + IdCuota + "'"

        Dim ArrDr() As DataRow = Dt.Select(Filtro)
        If ArrDr.Length > 0 Then
            For I As Integer = 0 To Dt.Rows.Count - 1
                Dim IdPlazoSession As String = Convert.ToString(Dt.Rows(I).Item("IdPlazo"))
                Dim IdCuotaSession As String = Convert.ToString(Dt.Rows(I).Item("IdCuota"))
                Dim PorcentajeSession As Double = Convert.ToDouble(Dt.Rows(I).Item("Porcentaje"))
                If IdPlazo = IdPlazoSession And IdCuota = IdCuotaSession Then
                    Dt.Rows(I).Item("Porcentaje") = PorcentajeSession + Porcentaje
                End If
            Next
        Else
            Dim Fila As DataRow = Dt.NewRow
            Fila("IdPlazo") = IdPlazo
            Fila("Plazo") = Plazo
            Fila("IdCuota") = IdCuota
            Fila("Cuota") = Cuota
            Fila("Porcentaje") = Porcentaje
            Dt.Rows.Add(Fila)
        End If

        Session("Cuotas") = Dt
        Me.dgCuotas.DataSource = CType(Session("Cuotas"), DataTable)
        Me.dgCuotas.DataBind()
        'Me.ddlPlazos.SelectedIndex = 0
        'Me.ddlCuotas.SelectedIndex = 0
        'Me.txtPorcentaje.Text = String.Empty
    End Sub

    Private Sub LimpiarValoresConsulta()
        Me.txtBusDescripcion.Text = ""
        Me.txtBusDescripcion.Enabled = True
        Me.txtBusDescripcion.BackColor = System.Drawing.Color.White
        Me.ddlBusqueda.SelectedIndex = 0
        Me.txtBusDescripcion.Text = String.Empty
        Dim IdEstado As String = CE_ESTADO_ACTIVO
        Me.ddlEstadoConsulta.SelectedValue = CE_ESTADO_ACTIVO
        Dim Descripcion As String = Me.txtBusDescripcion.Text.Trim
        Session("ListadoCasoEspecial") = obj.ListadoCasoEspecial(Descripcion, IdEstado, CE_ITEM_01)
        Session("FiltroCasoEspecial") = CType(Session("ListadoCasoEspecial"), DataTable)
        Me.dgrGrillaDetalle.CurrentPageIndex = 0
        Call Comunes.LLenarDataGrid(Me.dgrGrillaDetalle, CType(Session("FiltroCasoEspecial"), DataTable))
        RegisterStartupScript("script", "<script>document.getElementById('" & txtBusDescripcion.ClientID & "').focus();</script>")
    End Sub

    Private Sub LimpiarSesiones()
        Session("Cuotas") = Nothing
        Session("Campanias") = Nothing
        Session("PDV") = Nothing
        Session("Planes") = Nothing
        Session("Restricciones") = Nothing
        Session("TopesConsumo") = Nothing
        Session("Accion") = Acciones.Consultar
    End Sub

    Private Sub Listado()
        Call LimpiarSesiones()
        Me.btnAgregar.Text = "Agregar"
        Call Limpiar()
        Call LlenarSesiones(True)
        Call LlenarListadoGeneral("", CE_ESTADO_ACTIVO)
        RegisterStartupScript("script", "<script>document.getElementById('" & Me.txtBusDescripcion.ClientID & "').focus();</script>")
    End Sub

    Private Sub Agregar()
        If Me.btnAgregar.Text = "Modificar" Then
            Me.hidCondicionPdv.Value = "MODIFICAR"
            Me.btnAgregar.Text = "Modificar"
            Me.btnGrabar.Text = "Grabar Cambios"
            If Session("Accion") <> Acciones.Actualizar Then
                Dim Codigo As String = Me.hidCodigo.Value.ToString
                If Codigo <> "" Then
                    Me.txtCodigoEsp.Text = Codigo
                    Call LlenarCampos(Codigo)
                End If
            End If
            Session("Accion") = Acciones.Actualizar
            Me.ddlEstado.Enabled = True
        ElseIf Me.btnAgregar.Text = "Agregar" Then
            Me.hidCondicionPdv.Value = "AGREGAR"
            Me.btnAgregar.Text = "Agregar"
            Me.btnGrabar.Text = "Grabar"
            If Session("Accion") <> Acciones.Insertar Then
                Call Limpiar()
                Call LlenarSesiones(True)
                Session("oArrayListSessionPdv") = Nothing
            End If
            Session("Accion") = Acciones.Insertar
            Me.ddlEstado.SelectedValue = CE_ESTADO_ACTIVO
            Me.ddlEstado.Enabled = False
        End If
        RegisterStartupScript("script", "<script>document.getElementById('" & Me.txtCasoDescripcion.ClientID & "').focus();</script>")
    End Sub

    Private Sub Editar()
        Session("Accion") = Acciones.Actualizar
        Me.btnGrabar.Text = "Grabar Cambios"
        Me.hidCondicionPdv.Value = "MODIFICAR"
        Me.btnAgregar.Text = "Modificar"
        Dim Codigo As String = Me.hidCodigo.Value.ToString
        Me.txtCodigoEsp.Text = Codigo
        Call LlenarCampos(Codigo)
        Me.ddlEstado.Enabled = True
        RegisterStartupScript("script", "<script>document.getElementById('" & Me.txtCasoDescripcion.ClientID & "').focus();</script>")
    End Sub

    Private Sub Limpiar()
        Me.txtCodigoEsp.Text = String.Empty
        Me.txtCasoDescripcion.Text = String.Empty
        Me.ddlEstado.SelectedValue = CE_ESTADO_ACTIVO
        Me.chkWhiteList.Checked = False
        For Each Item As ListItem In Me.chkListaDocumento.Items
            Item.Selected = False
        Next
        Me.ddlOferta.SelectedIndex = 0
        Me.txtCantMaximaporCasoEspecial.Text = String.Empty
        Me.txtCantMaximaPlanesDatos.Text = String.Empty
        Me.txtCantMaximaPlanesVoz.Text = String.Empty
        Me.ddlPlazos.SelectedIndex = 0
        Me.ddlCuotas.SelectedIndex = 0
        Me.txtPorcentaje.Text = String.Empty
        Session("IdOferta") = Nothing
        Me.lblMensaje.Text = String.Empty
        Me.ddlEstadoConsulta.SelectedValue = CE_ESTADO_ACTIVO
        Me.txtBusDescripcion.Text = String.Empty
    End Sub

    Private Sub LlenarCampos(ByVal Codigo As String)
        Dim Dt As DataTable = obj.ListadoCasoEspecialCabecera(Codigo, CE_ITEM_01)
        If Not Dt Is Nothing Then
            If Dt.Rows.Count > 0 Then
                'Me.txtCodigoEsp.Text = Convert.ToString(Dt.Rows(0).Item("Codigo"))
                Me.txtCasoDescripcion.Text = Funciones.CheckStr(Dt.Rows(0).Item("CasoEspecial"))
                Dim IdEstado As String = Funciones.CheckStr(Dt.Rows(0).Item("IdEstado"))
                Me.ddlEstado.SelectedValue = IdEstado
                Me.chkWhiteList.Checked = Convert.ToBoolean(Dt.Rows(0).Item("WhiteList"))
                Me.ddlOferta.SelectedValue = Funciones.CheckStr(Dt.Rows(0).Item("IdOferta"))
                Dim CantMaximaporCasoEspecial As Integer = Funciones.CheckInt(Dt.Rows(0).Item("MaxPlanes"))
                If CantMaximaporCasoEspecial = 0 Then
                    Me.txtCantMaximaporCasoEspecial.Text = String.Empty
                Else
                    Me.txtCantMaximaporCasoEspecial.Text = CantMaximaporCasoEspecial.ToString
                End If
                Dim CantMaximaPlanesDatos As Integer = Funciones.CheckInt(Dt.Rows(0).Item("PlanesDatos"))
                If CantMaximaPlanesDatos = 0 Then
                    Me.txtCantMaximaPlanesDatos.Text = String.Empty
                Else
                    Me.txtCantMaximaPlanesDatos.Text = CantMaximaPlanesDatos.ToString
                End If
                Dim CantMaximaPlanesVoz As Integer = Funciones.CheckInt(Dt.Rows(0).Item("PlanesVoz"))
                If CantMaximaPlanesVoz = 0 Then
                    Me.txtCantMaximaPlanesVoz.Text = String.Empty
                Else
                    Me.txtCantMaximaPlanesVoz.Text = CantMaximaPlanesVoz.ToString
                End If
                Session("IdOferta") = Funciones.CheckStr(Dt.Rows(0).Item("IdOferta"))
            End If
        End If
        Call LlenarDetalles(Codigo)
        Me.hidCodigo.Value = Nothing
    End Sub

    Private Sub LlenarDetalles(ByVal Codigo As String)
        For Each Item As ListItem In Me.chkListaDocumento.Items
            Item.Selected = False
        Next
        Dim Dt As DataTable = obj.ListadoCasoEspecialDocumento(Codigo)
        If Dt.Rows.Count > 0 Then
            For Each Dr As DataRow In Dt.Rows
                For Each Item As ListItem In Me.chkListaDocumento.Items
                    If Convert.ToString(Dr("IdDocumento")) = Item.Value.ToString() Then
                        Item.Selected = True
                    End If
                Next
            Next
            Me.chkListaDocumento.DataBind()
        End If

        Me.dgCuotas.CurrentPageIndex = 0
        Session("Cuotas") = obj.ListadoCasoEspecialCuotas(Codigo)
        Me.dgCuotas.DataSource = CType(Session("Cuotas"), DataTable)
        Me.dgCuotas.DataBind()

        Me.dgCampanias.CurrentPageIndex = 0
        Dim DtSinOrdenar As DataTable = obj.ListadoCasoEspecialCampanias(Codigo)
        Dim DtCampañas As DataTable = DtSinOrdenar.Clone
        Dim Ordenacion As String = "Campania Asc"
        Dim Rows() As DataRow = DtSinOrdenar.Select("", Ordenacion)
        For Each Dr As DataRow In Rows
            Dim Row As DataRow = DtCampañas.NewRow
            Row("IdCampania") = Funciones.CheckStr(Dr("IdCampania"))
            Row("Campania") = Funciones.CheckStr(Dr("Campania"))
            Row("Exclusiva") = Funciones.CheckStr(Dr("Exclusiva"))
            DtCampañas.Rows.Add(Row)
        Next
        Session("Campanias") = DtCampañas
        Me.dgCampanias.DataSource = DtCampañas
        Me.dgCampanias.DataBind()

        Me.dgPDV.CurrentPageIndex = 0
        Session("PDV") = obj.ListadoCasoEspecialPDV(Codigo)
        Me.dgPDV.DataSource = CType(Session("PDV"), DataTable)
        Me.dgPDV.DataBind()

        Dim Arreglo As New ArrayList
        Dim DtPDV As DataTable = CType(Session("PDV"), DataTable)
        For Each Fila As DataRow In DtPDV.Rows
            Dim Item As New Claro.SisAct.Entidades.PuntoVenta
            Item.OVENC_CODIGO = Funciones.CheckStr(Fila("IdPuntoVenta"))
            Item.OVENV_DESCRIPCION = Funciones.CheckStr(Fila("PuntoVenta"))
            Item.CANAC_CODIGO = Funciones.CheckStr(Fila("Canal"))
            Arreglo.Add(Item)
        Next
        Session("oArrayListSessionPdv") = Arreglo

        Me.dgPlanes.CurrentPageIndex = 0
        Session("Planes") = obj.ListadoCasoEspecialPlanes(Codigo)
        Me.dgPlanes.DataSource = CType(Session("Planes"), DataTable)
        Me.dgPlanes.DataBind()

        Me.dgRestricciones.CurrentPageIndex = 0
        Session("Restricciones") = obj.ListadoCasoEspecialRiesgos(Codigo)
        Me.dgRestricciones.DataSource = CType(Session("Restricciones"), DataTable)
        Me.dgRestricciones.DataBind()

        Me.dgTopeConsumo.CurrentPageIndex = 0
        Session("TopeConsumo") = obj.ListadoCasoEspecialTopeConsumo(Codigo, CE_ITEM_02)
        Me.dgTopeConsumo.DataSource = CType(Session("TopeConsumo"), DataTable)
        Me.dgTopeConsumo.DataBind()
    End Sub

    Private Sub RecuperarValores(ByVal Codigo As String, ByVal Accion As Integer)
        Session("Accion") = Acciones.Actualizar
        Me.btnGrabar.Text = "Guardar Cambios"
        Me.hidCondicionPdv.Value = "MODIFICAR"
        Me.btnAgregar.Text = "Modificar"
        Me.txtCodigoEsp.Text = Codigo
        Call LlenarCampos(Codigo)
        Me.ddlEstado.Enabled = True
        If Accion = Acciones.Insertar Then
            RegisterStartupScript("script", "<script>;f_Resultado();alert('El Caso Especial se Registró Correctamente');document.getElementById('" & Me.txtCasoDescripcion.ClientID & "').focus();</script>")
        End If
        If Accion = Acciones.Actualizar Then
            RegisterStartupScript("script", "<script>f_Resultado();alert('El Caso Especial se Actualizó Correctamente');document.getElementById('" & Me.txtCasoDescripcion.ClientID & "').focus();</script>")
        End If
        'RegisterStartupScript("script", "<script>document.getElementById('" & Me.txtCasoDescripcion.ClientID & "').focus();</script>")
    End Sub

    Private Sub ExportarCsv(ByVal ruta As String)

        Dim Descripcion As String = Me.txtBusDescripcion.Text.Trim
        Dim IdEstado As String = Me.ddlEstadoConsulta.SelectedValue.ToString()

        Dim myTable As DataTable = obj.ListadoCasoEspecial(Descripcion, IdEstado, CE_ITEM_01)
        Dim dr As DataRow = myTable.NewRow
        dr(0) = "Codigo"
        dr(1) = "CasoEspecial"
        dr(2) = "Oferta"
        dr(3) = "Documentos"
        dr(4) = "Estado"
        dr(5) = "C.Max.Planes"
        dr(6) = "C.Max.Voz"
        dr(7) = "C.Max.Datos"
        dr(8) = "WhiteList"

        myTable.Rows.InsertAt(dr, 0)
        Dim myRow As DataRow
        Dim numCols As Integer = 0
        Dim myString As String
        Dim myWriter As New System.IO.StreamWriter(ruta)

        For Each myRow In myTable.Rows 'recorre las filas
            myString = ""
            For numCols = 0 To myTable.Columns.Count - 2 'recorre las columnas
                If Object.ReferenceEquals(myRow.Item(numCols).GetType(), myString.GetType()) Then
                    myString = myString & """" & myRow.Item(numCols).ToString() & ""","
                ElseIf Object.ReferenceEquals(myRow.Item(numCols).GetType(), numCols.GetType()) Then
                    myString = myString & myRow.Item(numCols).ToString() & ","
                End If
            Next

            If Object.ReferenceEquals(myRow.Item(numCols).GetType(), myString.GetType()) Then
                myString = myString & """" & myRow.Item(numCols).ToString() & """"
            ElseIf Object.ReferenceEquals(myRow.Item(numCols).GetType(), numCols.GetType()) Then
                myString = myString & myRow.Item(numCols).ToString()
            End If
            myWriter.WriteLine(myString)
        Next

        myWriter.Close()
    End Sub

    Public Sub Auditoria(ByVal strTransaccion As String, ByVal strDesTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal
            'Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            'Dim strNomAplica As String = ConfigurationSettings.AppSettings("NombreAplicacion")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim flag As Boolean = New AuditoriaNegocio().registrarAuditoria(strTransaccion, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strDesTrans)
            If flag = False Then
                Dim Mensaje As String = "No se pudo Registrar la Auditoría de " + strTransaccion
                RegisterStartupScript("script", "<script>alert('" + Mensaje + "');</script>")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Log(ByVal Operacion As String, ByVal Valores As String, ByVal Comentario As String)
        Dim Mensaje As String = Operacion + " | " + Valores + " | " + Comentario
        oLog.Log_WriteLog(oFile, Mensaje)
    End Sub

#End Region

#Region "Formulario"

    Public Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Call LlenarCriterios()
            Call LlenarListaDocumentos()
            Call LlenarListadoGeneral("", CE_ESTADO_ACTIVO)
            Call LlenarCombos()
            Me.ddlEstado.Enabled = True
            Call RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');</script>")
        Else
            Dim Accion As String = Me.hidCondicionPdv.Value.ToString().Trim().ToUpper()
            Select Case Accion
                Case "BUSQUEDA"
                    RegisterStartupScript("jsbusqueda", "<script>f_MostrarTab('BUSQUEDA');f_mostrarPestaña(100);</script>")
                Case "AGREGAR"
                    RegisterStartupScript("jsmantenimiento", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(1);</script>")
                Case "MODIFICAR"
                    RegisterStartupScript("jsmantenimiento", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(1);</script>")
                Case "MANTENIMIENTO"
                    RegisterStartupScript("jsmantenimiento", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "VALIDACION"
                    RegisterStartupScript("jsvalidacion", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "CAMPANIAS"
                    RegisterStartupScript("jscampanias", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "PDV"
                    RegisterStartupScript("jscampanias", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "PLANES"
                    RegisterStartupScript("jsplanes", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "RESTRICCIONES"
                    RegisterStartupScript("jsrestricciones", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "TOPECONSUMO"
                    RegisterStartupScript("jstopeconsumo", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINAR"
                    RegisterStartupScript("jseliminar", "<script>f_MostrarTab('BUSQUEDA');</script>")
                Case "ELIMINARCAMPANIA"
                    RegisterStartupScript("jseliminarcampania", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARPDV"
                    RegisterStartupScript("jseliminarpdv", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARPLAN"
                    RegisterStartupScript("jseliminarplan", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARRESTRICCION"
                    RegisterStartupScript("jseliminarrestriccion", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARTOPECONSUMO"
                    RegisterStartupScript("jseliminartopeconsumo", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARCUOTA"
                    RegisterStartupScript("jseliminartodostopeconsumo", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARTODOSCAMPANIA"
                    RegisterStartupScript("jseliminarcampania", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARTODOSPDV"
                    RegisterStartupScript("jseliminarpdv", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARTODOSPLAN"
                    RegisterStartupScript("jseliminarplan", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARTODOSRESTRICCION"
                    RegisterStartupScript("jseliminarrestriccion", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARTODOSTOPECONSUMO"
                    RegisterStartupScript("jseliminartodostopeconsumo", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case "ELIMINARTODOSCUOTAS"
                    RegisterStartupScript("jseliminartodostopeconsumo", "<script>f_MostrarTab('MANTENIMIENTO');f_mostrarPestaña(" & Me.hidIndice.Value & ");</script>")
                Case Else
                    RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');</script>")
            End Select
        End If
        Me.hidCondicionPdv.Value = Nothing
        Me.hidIndice.Value = Nothing
        Call LlenarSesiones(False)
    End Sub

    Public Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then Exit Sub 'Cabecera
            Dim Codigo As String = e.Item.Cells(1).Text
            Dim IdEstado As String = Strings.Left(e.Item.Cells(5).Text, 1)
            Dim btnEditar As ImageButton = DirectCast(e.Item.FindControl("btnEditar"), ImageButton)
            If Not btnEditar Is Nothing Then
                btnEditar.Attributes.Add("onclick", "return f_Modificar('" & Codigo & "')")
            End If
            Dim btnEliminar As ImageButton = DirectCast(e.Item.FindControl("btnEliminar"), ImageButton)
            If Not btnEliminar Is Nothing Then
                btnEliminar.Attributes.Add("onclick", "return f_Eliminar('" & Codigo & "','" & IdEstado & "')")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgCampanias_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCampanias.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then 'Cabecera
                Dim btnEliminarTodosCampania As ImageButton = DirectCast(e.Item.FindControl("btnEliminarTodosCampania"), ImageButton)
                If Not btnEliminarTodosCampania Is Nothing Then
                    btnEliminarTodosCampania.Attributes.Add("onclick", "return f_EliminarTodosCampania()")
                End If
            Else
                Dim Codigo As String = e.Item.Cells(1).Text
                Dim btnEliminarCampania As ImageButton = DirectCast(e.Item.FindControl("btnEliminarCampania"), ImageButton)
                If Not btnEliminarCampania Is Nothing Then
                    btnEliminarCampania.Attributes.Add("onclick", "return f_EliminarCampania('" & Codigo & "')")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgPDV_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPDV.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then 'Cabecera
                Dim btnEliminarTodosPDV As ImageButton = DirectCast(e.Item.FindControl("btnEliminarTodosPDV"), ImageButton)
                If Not btnEliminarTodosPDV Is Nothing Then
                    btnEliminarTodosPDV.Attributes.Add("onclick", "return f_EliminarTodosPDV()")
                End If
            Else
                Dim Codigo As String = e.Item.Cells(1).Text
                Dim btnEliminarPDV As ImageButton = DirectCast(e.Item.FindControl("btnEliminarPDV"), ImageButton)
                If Not btnEliminarPDV Is Nothing Then
                    btnEliminarPDV.Attributes.Add("onclick", "return f_EliminarPDV('" & Codigo & "')")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgPlanes_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPlanes.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then 'Cabecera
                Dim btnEliminarTodosPlan As ImageButton = DirectCast(e.Item.FindControl("btnEliminarTodosPlan"), ImageButton)
                If Not btnEliminarTodosPlan Is Nothing Then
                    btnEliminarTodosPlan.Attributes.Add("onclick", "return f_EliminarTodosPlan()")
                End If
            Else
                Dim IdPlan As String = e.Item.Cells(1).Text.ToString()
                Dim IdPlazo As String = e.Item.Cells(4).Text.ToString()
                Dim IdCuota As String = e.Item.Cells(6).Text.ToString()
                Dim NroPlanes As String = e.Item.Cells(3).Text.ToString()
                Dim Codigo As String = IdPlan + "|" + IdPlazo + "|" + IdCuota + "|" + NroPlanes
                Dim btnEditarPlan As ImageButton = DirectCast(e.Item.FindControl("btnEditarPlan"), ImageButton)
                If Not btnEditarPlan Is Nothing Then
                    btnEditarPlan.Attributes.Add("onclick", "return editarPopUpPlanes('" & Codigo & "')")
                End If
                Dim btnEliminarPlan As ImageButton = DirectCast(e.Item.FindControl("btnEliminarPlan"), ImageButton)
                If Not btnEliminarPlan Is Nothing Then
                    btnEliminarPlan.Attributes.Add("onclick", "return f_EliminarPlan('" & Codigo & "')")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgRestricciones_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgRestricciones.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then 'Cabecera
                Dim btnEliminarTodosRestriccion As ImageButton = DirectCast(e.Item.FindControl("btnEliminarTodosRestriccion"), ImageButton)
                If Not btnEliminarTodosRestriccion Is Nothing Then
                    btnEliminarTodosRestriccion.Attributes.Add("onclick", "return f_EliminarTodosRestriccion()")
                End If
            Else
                Dim IdDocumento As String = e.Item.Cells(1).Text.ToString()
                Dim IdRiesgo As String = e.Item.Cells(3).Text.ToString()
                Dim IdPlan As String = e.Item.Cells(5).Text.ToString()
                Dim IdPlazo As String = e.Item.Cells(8).Text.ToString()
                Dim IdCuota As String = e.Item.Cells(10).Text.ToString()
                Dim NroPlanes As String = e.Item.Cells(7).Text.ToString()
                Dim Codigo As String = IdDocumento + "|" + IdRiesgo + "|" + IdPlan + "|" + IdPlazo + "|" + IdCuota + "|" + NroPlanes
                Dim btnEditarRestriccion As ImageButton = DirectCast(e.Item.FindControl("btnEditarRestriccion"), ImageButton)
                If Not btnEditarRestriccion Is Nothing Then
                    btnEditarRestriccion.Attributes.Add("onclick", "return editarPopUpRestricciones('" & Codigo & "')")
                End If
                Dim btnEliminarRestriccion As ImageButton = DirectCast(e.Item.FindControl("btnEliminarRestriccion"), ImageButton)
                If Not btnEliminarRestriccion Is Nothing Then
                    btnEliminarRestriccion.Attributes.Add("onclick", "return f_EliminarRestriccion('" & Codigo & "')")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgTopeConsumo_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgTopeConsumo.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then 'Cabecera
                Dim btnEliminarTodosTopeConsumo As ImageButton = DirectCast(e.Item.FindControl("btnEliminarTodosTopeConsumo"), ImageButton)
                If Not btnEliminarTodosTopeConsumo Is Nothing Then
                    btnEliminarTodosTopeConsumo.Attributes.Add("onclick", "return f_EliminarTodosTopeConsumo()")
                End If
            Else
                Dim IdPlan As String = e.Item.Cells(1).Text.ToString()
                Dim IdTopeConsumo As String = e.Item.Cells(3).Text.ToString()
                Dim Codigo As String = IdPlan + "|" + IdTopeConsumo
                Dim btnEliminarTopeConsumo As ImageButton = DirectCast(e.Item.FindControl("btnEliminarTopeConsumo"), ImageButton)
                If Not btnEliminarTopeConsumo Is Nothing Then
                    btnEliminarTopeConsumo.Attributes.Add("onclick", "return f_EliminarTopeConsumo('" & Codigo & "')")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgCuotas_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCuotas.ItemDataBound
        Try
            If e.Item.ItemIndex = -1 Then 'Cabecera
                Dim btnEliminarTodosCuotas As ImageButton = DirectCast(e.Item.FindControl("btnEliminarTodosCuotas"), ImageButton)
                If Not btnEliminarTodosCuotas Is Nothing Then
                    btnEliminarTodosCuotas.Attributes.Add("onclick", "return f_EliminarTodosCuotas()")
                End If
            Else
                Dim IdPlazo As String = e.Item.Cells(1).Text.ToString()
                Dim IdCuota As String = e.Item.Cells(3).Text.ToString()
                Dim Codigo As String = IdPlazo + "|" + IdCuota
                Dim btnEliminarCuota As ImageButton = DirectCast(e.Item.FindControl("btnEliminarCuota"), ImageButton)
                If Not btnEliminarCuota Is Nothing Then
                    btnEliminarCuota.Attributes.Add("onclick", "return f_EliminarCuota('" & Codigo & "')")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Eliminar

    Private Sub btnEliminarServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarServer.Click
        Call Eliminar()
    End Sub

    Private Sub btnEliminarCuotaServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarCuotaServer.Click
        If Not Session("Cuotas") Is Nothing Then
            Me.dgCuotas.CurrentPageIndex = 0
            Dim Coleccion() As String = Split(Me.hidCodigo.Value.ToString(), "|")

            Dim IdPlazo As String = Coleccion(0).ToString()
            Dim IdCuota As String = Coleccion(1).ToString()

            Dim Dt As DataTable = CType(Session("Cuotas"), DataTable)

            If Not Dt Is Nothing Then
                If Dt.Rows.Count > 0 Then
                    For Each Dr As DataRow In Dt.Rows
                        If IdPlazo = Dr("IdPlazo").ToString() And _
                        IdCuota = Dr("IdCuota").ToString() Then
                            Dt.Rows.Remove(Dr)
                            Exit For
                        End If
                    Next
                    Session("Cuotas") = Dt
                    Call LLenarDataGrid(Me.dgCuotas, Dt)
                    Me.hidCodigo.Value = String.Empty
                    Dt.Dispose()
                    Dt = Nothing
                End If
            End If
            RegisterStartupScript("script", "<script>alert('Registro(Cuota) Eliminado');</script>")
        End If
    End Sub

    Private Sub btnEliminarCampaniaServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarCampaniaServer.Click
        If Not Session("Campanias") Is Nothing Then
            Me.dgCampanias.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("Campanias"), DataTable), "IdCampania", Me.dgCampanias, Me.hidCodigo)
            RegisterStartupScript("script", "<script>alert('Registro(Campaña) Eliminado');</script>")
        End If
    End Sub

    Private Sub btnEliminarPdvServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarPdvServer.Click
        If Not Session("PDV") Is Nothing Then
            Me.dgPDV.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("PDV"), DataTable), "IdPuntoVenta", Me.dgPDV, Me.hidCodigo)
            Dim Arreglo As New ArrayList
            Dim Dt As DataTable = CType(Session("PDV"), DataTable)
            For Each Fila As DataRow In Dt.Rows
                Dim Item As New Claro.SisAct.Entidades.PuntoVenta
                Item.OVENC_CODIGO = Convert.ToString(Fila("IdPuntoVenta"))
                Item.OVENV_DESCRIPCION = Convert.ToString(Fila("PuntoVenta"))
                Item.CANAC_CODIGO = Convert.ToString(Fila("Canal"))
                Arreglo.Add(Item)
            Next
            Session("oArrayListSessionPdv") = Arreglo
            RegisterStartupScript("script", "<script>alert('Registro(PDV) Eliminado');</script>")
        End If
    End Sub

    Private Sub btnEliminarPlanServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarPlanServer.Click
        If Not Session("Planes") Is Nothing Then
            Me.dgPlanes.CurrentPageIndex = 0
            Dim Coleccion() As String = Split(Me.hidCodigo.Value.ToString(), "|")

            Dim IdPlan As String = Coleccion(0).ToString()
            Dim IdPlazo As String = Coleccion(1).ToString()
            Dim IdCuota As String = Coleccion(2).ToString()
            Dim NroPlanes As String = Coleccion(3).ToString()

            Dim Dt As DataTable = CType(Session("Planes"), DataTable)

            Dim IdPlanParametro As String = ""

            If Not Dt Is Nothing Then
                If Dt.Rows.Count > 0 Then
                    For Each Dr As DataRow In Dt.Rows
                        If IdPlan = Dr("IdPlan").ToString() And _
                        IdPlazo = Dr("IdPlazo").ToString() And _
                        IdCuota = Dr("IdCuota").ToString() And _
                        NroPlanes = Dr("NroPlanes").ToString() Then
                            Dt.Rows.Remove(Dr)
                            IdPlanParametro = IdPlan
                            Exit For
                        End If
                    Next

                    Session("Planes") = Dt
                    Call LLenarDataGrid(Me.dgPlanes, Dt)

                    Dim Filtro As String = ""
                    Dim ControlBorrarTope As Boolean = False

                    Filtro = Filtro + "IdPlan= '" + IdPlan + "' "
                    Dim ArrDr() As DataRow = Dt.Select(Filtro)
                    If ArrDr.Length = 0 Then
                        ControlBorrarTope = True
                    End If

                    If ControlBorrarTope = True Then

                        Dim NuevoFiltro As String = ""
                        NuevoFiltro = NuevoFiltro + "IdPlan= '" + IdPlan + "' "

                        Dim DtTopeConsumo As DataTable = CType(Session("TopeConsumo"), DataTable)
                        Dim ArrDrTopeConsumo() As DataRow = DtTopeConsumo.Select(Filtro)
                        If ArrDrTopeConsumo.Length > 0 Then
                            For Each Dr As DataRow In ArrDrTopeConsumo
                                DtTopeConsumo.Rows.Remove(Dr)
                            Next
                        End If
                        Session("TopeConsumo") = DtTopeConsumo
                        Call LLenarDataGrid(Me.dgTopeConsumo, DtTopeConsumo)

                        Dim DtRestricciones As DataTable = CType(Session("Restricciones"), DataTable)
                        Dim ArrDrRestricciones() As DataRow = DtRestricciones.Select(Filtro)
                        If ArrDrRestricciones.Length > 0 Then
                            For Each Dr As DataRow In ArrDrRestricciones
                                DtRestricciones.Rows.Remove(Dr)
                            Next
                        End If
                        Session("Restricciones") = DtRestricciones
                        Call LLenarDataGrid(Me.dgRestricciones, DtRestricciones)

                    End If

                    Me.hidCodigo.Value = String.Empty
                    Dt.Dispose()
                    Dt = Nothing

                End If
            End If

            RegisterStartupScript("script", "<script>alert('Registro(Plan) Eliminado');</script>")
        End If
    End Sub

    Private Sub btnEliminarRestriccionServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarRestriccionServer.Click
        If Not Session("Restricciones") Is Nothing Then
            Me.dgRestricciones.CurrentPageIndex = 0

            Dim Coleccion() As String = Split(Me.hidCodigo.Value.ToString(), "|")

            Dim IdDocumento As String = Coleccion(0).ToString()
            Dim IdRiesgo As String = Coleccion(1).ToString()
            Dim IdPlan As String = Coleccion(2).ToString()
            Dim IdPlazo As String = Coleccion(3).ToString()
            Dim IdCuota As String = Coleccion(4).ToString()
            Dim NroPlanes As String = Coleccion(5).ToString()

            Dim Dt As DataTable = CType(Session("Restricciones"), DataTable)

            If Not Dt Is Nothing Then
                If Dt.Rows.Count > 0 Then
                    For Each Dr As DataRow In Dt.Rows
                        If IdDocumento = Dr("IdDocumento").ToString() And _
                        IdRiesgo = Dr("IdRiesgo").ToString() And _
                        IdPlan = Dr("IdPlan").ToString() And _
                        IdPlazo = Dr("IdPlazo").ToString() And _
                        IdCuota = Dr("IdCuota").ToString() And _
                        NroPlanes = Dr("NroPlanes").ToString() Then
                            Dt.Rows.Remove(Dr)
                            Exit For
                        End If
                    Next
                    Session("Restricciones") = Dt
                    Call LLenarDataGrid(Me.dgRestricciones, Dt)
                    Me.hidCodigo.Value = String.Empty
                    Dt.Dispose()
                    Dt = Nothing
                End If
            End If

            RegisterStartupScript("script", "<script>alert('Registro(Restricciones) Eliminado');</script>")
        End If

    End Sub

    Private Sub btnEliminarTopeConsumoServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarTopeConsumoServer.Click
        If Not Session("TopeConsumo") Is Nothing Then
            Me.dgTopeConsumo.CurrentPageIndex = 0

            Dim Coleccion() As String = Split(Me.hidCodigo.Value.ToString(), "|")

            Dim IdPlan As String = Coleccion(0).ToString()
            Dim IdTopeConsumo As String = Coleccion(1).ToString()

            Dim Dt As DataTable = CType(Session("TopeConsumo"), DataTable)

            If Not Dt Is Nothing Then
                If Dt.Rows.Count > 0 Then
                    Dim Filtro As String = ""
                    Filtro = Filtro + "IdPlan= '" + IdPlan + "'"
                    Dim ArrDr() As DataRow = Dt.Select(Filtro)
                    If ArrDr.Length > 0 Then
                        For Each Dr As DataRow In ArrDr
                            Dt.Rows.Remove(Dr)
                        Next
                    End If
                    Session("TopeConsumo") = Dt
                    Call LLenarDataGrid(Me.dgTopeConsumo, Dt)
                    Me.hidCodigo.Value = String.Empty
                    Dt.Dispose()
                    Dt = Nothing
                End If
            End If

            RegisterStartupScript("script", "<script>alert('Registro(s)(Tope Consumo) Eliminado(s)');</script>")
        End If
    End Sub

    'Eliminar Todos

    Private Sub btnEliminarTodosCuotasServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarTodosCuotasServer.Click
        If Not Session("Cuotas") Is Nothing Then
            Me.dgCuotas.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("Cuotas"), DataTable), "", Me.dgCuotas, Me.hidCodigo)
            RegisterStartupScript("script", "<script>alert('Registros(Cuotas) Eliminados');</script>")
        End If
    End Sub

    Private Sub btnEliminarTodosCampaniaServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTodosCampaniaServer.Click
        If Not Session("Campanias") Is Nothing Then
            Me.dgCampanias.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("Campanias"), DataTable), "", Me.dgCampanias, Me.hidCodigo)
            RegisterStartupScript("script", "<script>alert('Registros(Campañas) Eliminados');</script>")
        End If
    End Sub

    Private Sub btnEliminarTodosPdvServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTodosPdvServer.Click
        If Not Session("PDV") Is Nothing Then
            Me.dgPDV.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("PDV"), DataTable), "", Me.dgPDV, Me.hidCodigo)
            Dim Arreglo As New ArrayList
            Dim Dt As DataTable = CType(Session("PDV"), DataTable)
            For Each Fila As DataRow In Dt.Rows
                Dim Item As New Claro.SisAct.Entidades.PuntoVenta
                Item.OVENC_CODIGO = Funciones.CheckStr(Fila("IdPuntoVenta"))
                Item.OVENV_DESCRIPCION = Funciones.CheckStr(Fila("PuntoVenta"))
                Item.CANAC_CODIGO = Funciones.CheckStr(Fila("Canal"))
                Arreglo.Add(Item)
            Next
            Session("oArrayListSessionPdv") = Arreglo
            RegisterStartupScript("script", "<script>alert('Registros(PDV) Eliminados');</script>")
        End If
    End Sub

    Private Sub btnEliminarTodosPlanServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTodosPlanServer.Click
        If Not Session("Planes") Is Nothing Then
            Me.dgPlanes.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("Planes"), DataTable), "", Me.dgPlanes, Me.hidCodigo)
            If Not Session("TopeConsumo") Is Nothing Then
                Call Comunes.Eliminar(CType(Session("TopeConsumo"), DataTable), "", Me.dgTopeConsumo, Me.hidCodigo)
            End If
            If Not Session("Restricciones") Is Nothing Then
                Call Comunes.Eliminar(CType(Session("Restricciones"), DataTable), "", Me.dgRestricciones, Me.hidCodigo)
            End If
            RegisterStartupScript("script", "<script>alert('Registros(Planes) Eliminados');</script>")
        End If
    End Sub

    Private Sub btnEliminarTodosRestriccionServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTodosRestriccionServer.Click
        If Not Session("Restricciones") Is Nothing Then
            Me.dgRestricciones.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("Restricciones"), DataTable), "", Me.dgRestricciones, Me.hidCodigo)
            RegisterStartupScript("script", "<script>alert('Registros(Restricciones) Eliminados');</script>")
        End If
    End Sub

    Private Sub btnEliminarTodosTopeConsumoServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTodosTopeConsumoServer.Click
        If Not Session("TopeConsumo") Is Nothing Then
            Me.dgTopeConsumo.CurrentPageIndex = 0
            Call Comunes.Eliminar(CType(Session("TopeConsumo"), DataTable), "", Me.dgTopeConsumo, Me.hidCodigo)
            RegisterStartupScript("script", "<script>alert('Registros(Tope Consumo) Eliminados');</script>")
        End If
    End Sub

    Private Sub ddlBusqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBusqueda.SelectedIndexChanged
        If Me.ddlBusqueda.SelectedIndex = 0 Then
            Me.txtBusDescripcion.BackColor = System.Drawing.Color.White
            Me.txtBusDescripcion.Enabled = True
        Else
            Me.txtBusDescripcion.Text = ""
            Me.txtBusDescripcion.Enabled = False
            Me.txtBusDescripcion.BackColor = System.Drawing.Color.WhiteSmoke
        End If
    End Sub

    Private Sub ddlOferta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlOferta.SelectedIndexChanged
        Dim IdOferta As String = ""
        If Me.ddlOferta.SelectedIndex <> 0 Then
            IdOferta = ddlOferta.SelectedValue.ToString
        End If
        Session("IdOferta") = IdOferta
    End Sub

    Private Sub dgCuotas_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCuotas.PageIndexChanged
        Me.dgCuotas.CurrentPageIndex = e.NewPageIndex
        Call Comunes.LLenarDataGrid(Me.dgCuotas, CType(Session("Cuotas"), DataTable))
    End Sub

    Private Sub dgCampanias_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCampanias.PageIndexChanged
        Me.dgCampanias.CurrentPageIndex = e.NewPageIndex
        Call Comunes.LLenarDataGrid(Me.dgCampanias, CType(Session("Campanias"), DataTable))
    End Sub

    Private Sub dgPDV_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPDV.PageIndexChanged
        Me.dgPDV.CurrentPageIndex = e.NewPageIndex
        Call Comunes.LLenarDataGrid(Me.dgPDV, CType(Session("PDV"), DataTable))
    End Sub

    Private Sub dgPlanes_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPlanes.PageIndexChanged
        Me.dgPlanes.CurrentPageIndex = e.NewPageIndex
        Call Comunes.LLenarDataGrid(Me.dgPlanes, CType(Session("Planes"), DataTable))
    End Sub

    Private Sub dgRestricciones_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgRestricciones.PageIndexChanged
        Me.dgRestricciones.CurrentPageIndex = e.NewPageIndex
        Call Comunes.LLenarDataGrid(Me.dgRestricciones, CType(Session("Restricciones"), DataTable))
    End Sub

    Private Sub dgTopeConsumo_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgTopeConsumo.PageIndexChanged
        Me.dgTopeConsumo.CurrentPageIndex = e.NewPageIndex
        Call Comunes.LLenarDataGrid(Me.dgTopeConsumo, CType(Session("TopeConsumo"), DataTable))
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        Session("Accion") = Acciones.Consultar
        Me.dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Dim Descripcion As String = Me.txtBusDescripcion.Text.Trim
        Dim IdEstado As String = Me.ddlEstadoConsulta.SelectedValue.ToString()
        Session("ListadoCasoEspecial") = obj.ListadoCasoEspecial(Descripcion, IdEstado, CE_ITEM_01)
        Session("FiltroCasoEspecial") = CType(Session("ListadoCasoEspecial"), DataTable)
        Call Comunes.LLenarDataGrid(Me.dgrGrillaDetalle, CType(Session("FiltroCasoEspecial"), DataTable))
    End Sub

    Private Sub ddlEstadoConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEstadoConsulta.SelectedIndexChanged
        Try
            Dim Descripcion As String = Me.txtBusDescripcion.Text.Trim
            Dim IdEstado As String = Me.ddlEstadoConsulta.SelectedValue.ToString()
            Session("ListadoCasoEspecial") = obj.ListadoCasoEspecial(Descripcion, IdEstado, CE_ITEM_01)
            Session("FiltroCasoEspecial") = CType(Session("ListadoCasoEspecial"), DataTable)
            Me.dgrGrillaDetalle.CurrentPageIndex = 0
            Call Comunes.LLenarDataGrid(Me.dgrGrillaDetalle, Session("FiltroCasoEspecial"))
            Call Auditoria("Buscar Caso Especial", "El Caso Especial se Consultó Correctamente")
        Catch ex As Exception

            Call Auditoria("Buscar Caso Especial", "Se Presentaron Errores al Consultar El Caso Especial")
        End Try
    End Sub

    'Botones

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim IdEstado As String = ""
            Me.dgrGrillaDetalle.CurrentPageIndex = 0
            If Me.ddlBusqueda.SelectedIndex = 0 Then
                If Me.txtBusDescripcion.Text.Trim = String.Empty And Me.txtBusDescripcion.Enabled = True And Me.dgrGrillaDetalle.Items.Count = 0 Then
                    IdEstado = Me.ddlEstadoConsulta.SelectedValue.ToString()
                    Session("ListadoCasoEspecial") = obj.ListadoCasoEspecial("", IdEstado, CE_ITEM_01)
                    Session("FiltroCasoEspecial") = CType(Session("ListadoCasoEspecial"), DataTable)
                    Me.dgrGrillaDetalle.CurrentPageIndex = 0
                    Call Comunes.LLenarDataGrid(Me.dgrGrillaDetalle, Session("FiltroCasoEspecial"))
                    Me.ddlBusqueda.SelectedIndex = 1
                    Me.ddlBusqueda_SelectedIndexChanged(Nothing, Nothing)
                    Exit Sub
                End If
                If Me.txtBusDescripcion.Text.Trim = String.Empty And Me.txtBusDescripcion.Enabled = True Then
                    RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('Ingrese la Descripción'); document.getElementById('" & Me.txtBusDescripcion.ClientID & "').focus();</script>")
                    Exit Sub
                End If
                Dim Descripcion As String = Me.txtBusDescripcion.Text.Trim
                IdEstado = Me.ddlEstadoConsulta.SelectedValue.ToString()
                Session("ListadoCasoEspecial") = obj.ListadoCasoEspecial(Descripcion, IdEstado, CE_ITEM_01)
                Session("FiltroCasoEspecial") = CType(Session("ListadoCasoEspecial"), DataTable)
                Me.dgrGrillaDetalle.CurrentPageIndex = 0
                Call Comunes.LLenarDataGrid(Me.dgrGrillaDetalle, CType(Session("FiltroCasoEspecial"), DataTable))
            Else
                Me.txtBusDescripcion.Text = String.Empty
                IdEstado = Me.ddlEstadoConsulta.SelectedValue.ToString()
                Dim Descripcion As String = Me.txtBusDescripcion.Text.Trim
                Session("ListadoCasoEspecial") = obj.ListadoCasoEspecial(Descripcion, IdEstado, CE_ITEM_01)
                Session("FiltroCasoEspecial") = CType(Session("ListadoCasoEspecial"), DataTable)
                Me.dgrGrillaDetalle.CurrentPageIndex = 0
                Call Comunes.LLenarDataGrid(Me.dgrGrillaDetalle, CType(Session("FiltroCasoEspecial"), DataTable))
            End If
            Call Auditoria("Buscar Caso Especial", "El Caso Especial se Consultó Correctamente")
        Catch ex As Exception
            Call Auditoria("Buscar Caso Especial", "Se Presentaron Errores al Consultar El Caso Especial")
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Call LimpiarValoresConsulta()
    End Sub

    Private Sub btnListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListado.Click
        Call RegisterStartupScript("script", "<script>f_Listado();</script>")
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Call RegisterStartupScript("script", "<script>f_Agregar();</script>")
    End Sub

    Private Sub btnListadoServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnListadoServer.Click
        Call Listado()
    End Sub

    Private Sub btnAgregarServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarServer.Click
        Call Agregar()
    End Sub

    Private Sub btnEditarServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditarServer.Click
        Call Editar()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Mensaje = String.Empty
        Me.lblMensaje.Text = String.Empty
        Call Validaciones()
    End Sub

    Private Sub btnGrabarServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabarServer.Click
        Call Grabar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Call Cancelar()
    End Sub

    Private Sub btnAgregarCuota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCuota.Click
        Call AgregarDetalle()
    End Sub

    Private Sub btnExportarCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarCSV.Click
        If Me.dgrGrillaDetalle.Items.Count = 0 Then
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
            Exit Sub
        End If
        Dim applicationPath As String = System.Web.HttpContext.Current.Request.ApplicationPath
        applicationPath = System.Web.HttpContext.Current.Server.MapPath(applicationPath & "\CasosEspeciales.csv")
        Call Auditoria(ConfigurationSettings.AppSettings("CE_CODAUDT_EXPORTAR"), "Exportar Archivo Caso Especial.")
        Call ExportarCsv(applicationPath)
        Response.Redirect("DownloadFiles.aspx?FileName=CasosEspeciales.csv")
    End Sub

#End Region

  
End Class
