Imports System.Text
Imports System.Text.RegularExpressions
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Collections
Imports Claro.SisAct.Common.Funciones

Public Class usc_direccion
    Inherits System.Web.UI.UserControl

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label29 As System.Web.UI.WebControls.Label
    Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents Label47 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents Label50 As System.Web.UI.WebControls.Label
    Protected WithEvents Label45 As System.Web.UI.WebControls.Label
    Protected WithEvents Label48 As System.Web.UI.WebControls.Label
    Protected WithEvents Label49 As System.Web.UI.WebControls.Label
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPrefijo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDireccion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroPuerta As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkSinNumero As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlEdificacion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtManzana As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLote As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoInterior As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroInterior As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblContadorDireccion As System.Web.UI.WebControls.Label
    Protected WithEvents ddlUrbanizacion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtUrbanizacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlZona As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNombreZona As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblContadorReferencia As System.Web.UI.WebControls.Label
    Protected WithEvents ddlDepartamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProvincia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDistrito As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodigoPostal As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidDptoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProvincias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDistritos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaCodigoPostal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDptoDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProvinciaDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDistritoDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lbltitulodireccion As System.Web.UI.WebControls.Label
    Protected WithEvents hidDistritoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProvinciaId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSinNumero As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents panelSinNumero As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRUCEmpleador As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtNombreEmpresa As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents filaEmpleador As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents divSinNumero As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents hidShowRUC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTelfRef As System.Web.UI.WebControls.Label
    Protected WithEvents txtTelefonoReferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrefijoTelefonoReferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtUbigeo As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidListUbigeo As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

#Region "Propiedades"

    Public WriteOnly Property pTituloDireccion() As String
        Set(ByVal Value As String)
            Me.lbltitulodireccion.Text = Value
        End Set
    End Property
    Public ReadOnly Property pIdprefijo() As String
        Get
            Return Me.ddlPrefijo.SelectedValue
        End Get
    End Property

    Public ReadOnly Property pTxtprefijo() As String
        Get
            Return Me.ddlPrefijo.SelectedItem.ToString()
        End Get
    End Property

    Public ReadOnly Property pTxtdireccion() As String
        Get
            Return Me.txtDireccion.Text
        End Get
    End Property
    Public ReadOnly Property pTxtnropuerta() As String
        Get
            Return Me.txtNroPuerta.Text
        End Get
    End Property
    Public ReadOnly Property pddlEdificacion() As String
        Get
            Return Me.ddlEdificacion.SelectedValue
        End Get
    End Property
    Public ReadOnly Property ptxtManzana() As String
        Get
            Return Me.txtManzana.Text
        End Get
    End Property
    Public ReadOnly Property ptxtLote() As String
        Get
            Return Me.txtLote.Text
        End Get
    End Property
    Public ReadOnly Property pddlTipoInterior() As String
        Get
            Return Me.ddlTipoInterior.SelectedValue
        End Get
    End Property

    Public ReadOnly Property ptxtNroInterior() As String
        Get
            Return Me.txtNroInterior.Text
        End Get
    End Property
    Public ReadOnly Property plblContadorDireccion() As String
        Get
            Return Me.lblContadorDireccion.Text
        End Get
    End Property
    Public ReadOnly Property pddlUrbanizacion() As String
        Get
            Return Me.ddlUrbanizacion.SelectedValue
        End Get
    End Property
    Public ReadOnly Property ptxtUrbanizacion() As String
        Get
            Return Me.txtUrbanizacion.Text
        End Get
    End Property
    Public ReadOnly Property pddlZona() As String
        Get
            Return Me.ddlZona.SelectedValue
        End Get
    End Property
    Public ReadOnly Property ptxtNombreZona() As String
        Get
            Return Me.txtNombreZona.Text
        End Get
    End Property
    Public ReadOnly Property ptxtReferencia() As String
        Get
            Return Me.txtReferencia.Text
        End Get
    End Property
    Public ReadOnly Property plblContadorReferencia() As String
        Get
            Return Me.lblContadorReferencia.Text
        End Get
    End Property

    Public ReadOnly Property pddlDepartamento() As String
        Get
            Return Me.ddlDepartamento.SelectedValue
        End Get
    End Property
    Public ReadOnly Property pddlProvincia() As String
        Get
            Return Me.ddlProvincia.SelectedValue
        End Get
    End Property
    Public ReadOnly Property pddlDistrito() As String
        Get
            Return Me.ddlDistrito.SelectedValue
        End Get
    End Property
    Public ReadOnly Property ptxtCodigoPostal() As String
        Get
            Return Me.txtCodigoPostal.Text
        End Get

    End Property
    Public Property ptxtTituloTelefonoReferencia() As String
        Get
            Return Me.lblTelfRef.Text
        End Get
        Set(ByVal Value As String)
            Me.lblTelfRef.Text = Value
        End Set
    End Property
    Public ReadOnly Property ptxtTelefonoReferencia() As String
        Get
            Return Me.txtTelefonoReferencia.Text
        End Get
    End Property
    Public ReadOnly Property ptxtPrefijoTelefonoRef() As String
        Get
            Return Me.txtPrefijoTelefonoReferencia.Text
        End Get
    End Property

    Public WriteOnly Property pShowRUC() As String
        Set(ByVal Value As String)
            Me.hidShowRUC.Value = Value
        End Set
    End Property
    Public ReadOnly Property ptxtNumeroRUC() As String
        Get
            Return Me.txtRUCEmpleador.Value
        End Get

    End Property
    Public ReadOnly Property ptxtNombreEmpleador() As String
        Get
            Return Me.txtNombreEmpresa.Value
        End Get
    End Property

    'ddlEdificacion   'txtManzana   'txtLote   'ddlTipoInterior   'txtNroInterior    'lblContadorDireccion
    'ddlUrbanizacion  'txtUrbanizacion  'ddlZona   'txtNombreZona   'txtReferencia   'lblContadorReferencia
    'ddlDepartamento   'ddlProvincia   'ddlDistrito   'txtCodigoPostal   'txtTelefonoReferencia
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not IsPostBack Then
            hidSinNumero.Value = ConfigurationSettings.AppSettings("constSinNumero")
            If hidSinNumero.Value = "" Then hidSinNumero.Value = "S/N"

            Dim lista As ArrayList
            Dim hasListas As New Hashtable

            Dim tablas() As Integer = {1, 3, 4, 5, 8, 9, 10, 12, 13, 14, 15}
            Dim oConsulta As New MaestroNegocio
            hasListas = oConsulta.ListarItemsGenericos(tablas)

            lista = CType(hasListas(4), ArrayList)
            LlenaCombo(lista, ddlPrefijo, "CODIGO2", "DESCRIPCION2", False, True, "[Seleccionar]")

            'tipo edificacion
            lista = New ArrayList
            lista = CType(hasListas(13), ArrayList)
            LlenaCombo(lista, ddlEdificacion, "Codigo", "Descripcion2", False, True, "--SEL--")

            'tipo interior
            lista = New ArrayList
            lista = CType(hasListas(12), ArrayList)
            LlenaCombo(lista, ddlTipoInterior, "Codigo", "Descripcion2", False, True, "")


            'Lista Urbanizacion
            lista = New ArrayList
            lista = CType(hasListas(14), ArrayList)
            LlenaCombo(lista, ddlUrbanizacion, "Codigo", "Descripcion2", False, True, "")

            'Tipo Zona
            lista = New ArrayList
            lista = CType(hasListas(15), ArrayList)
            LlenaCombo(lista, ddlZona, "Codigo", "Descripcion2", False, True, "--SEL--")

            ''''''''''''''''''''''''''''''''''
            Dim provincias, distritos As ArrayList
            Dim sb As New StringBuilder
            Dim sbCodigoPostal As New StringBuilder
            Dim sbAlmacenDistrito As New StringBuilder
            Dim sbUbigeo As New StringBuilder
            'cadena para provincia
            Dim total As Integer = 0
            Dim i As Integer = 0
            Dim linea As String
            Dim provinciasDefault As String = ""

            provincias = oConsulta.ListaProvincia("000", "00", "A")
            distritos = oConsulta.ListaDistrito("0000", "000", "00", "A")
            oConsulta = Nothing
            total = provincias.Count - 1

            hidDptoDefault.Value = ConfigurationSettings.AppSettings("DptoDefault") ' "01"
            hidProvinciaDefault.Value = ConfigurationSettings.AppSettings("ProvinciaDefault") ' "127"

            hidDptoId.Value = hidDptoDefault.Value
            ddlProvincia.Items.Add(New ListItem("--Seleccionar--", ""))
            ddlDistrito.Items.Add(New ListItem("--Seleccionar--", ""))

            Dim dpto_id As String = ""
            Dim provincia_id As String = ""
            Dim provincia_des As String = ""

            Dim distrito_id As String = ""
            Dim distrito_des As String = ""

            For i = 0 To total
                Dim item As Provincia = CType(provincias(i), Provincia)
                dpto_id = item.DEPAC_CODIGO
                provincia_id = item.PROVC_CODIGO
                provincia_des = item.PROVV_DESCRIPCION
                If i = total Then
                    linea = String.Format("{0};{1};{2}", provincia_id, provincia_des, dpto_id)
                Else
                    linea = String.Format("{0};{1};{2}|", provincia_id, provincia_des, dpto_id)
                End If
                If hidDptoId.Value = dpto_id Then
                    ddlProvincia.Items.Add(New ListItem(provincia_des, provincia_id))
                    If hidProvinciaDefault.Value = provincia_id Then
                        ddlProvincia.Items(ddlProvincia.Items.Count - 1).Selected = True
                    End If
                End If
                sb.Append(linea)
            Next
            hidProvincias.Value = sb.ToString()

            '*******************
            'cadena para distrito
            total = distritos.Count - 1
            Dim Ubigeo As String = String.Empty
            sb = New StringBuilder
            For i = 0 To total
                Dim item As Distrito = CType(distritos(i), Distrito)
                Dim codigoPostal As String = item.DISTC_CODIGO_POSTAL
                distrito_id = item.DISTC_CODIGO
                distrito_des = item.DISTV_DESCRIPCION
                provincia_id = item.PROVC_CODIGO
                dpto_id = item.DEPAC_CODIGO
                Dim almacenId As String = item.ALMACEN
                If i = total Then
                    linea = String.Format("{0};{1};{2};{3}", distrito_id, distrito_des, provincia_id, codigoPostal)
                Else
                    linea = String.Format("{0};{1};{2};{3}|", distrito_id, distrito_des, provincia_id, codigoPostal)
                End If
                If hidProvinciaDefault.Value = provincia_id Then
                    ddlDistrito.Items.Add(New ListItem(distrito_des, distrito_id))
                    ddlDistrito.Items(ddlDistrito.Items.Count - 1).Attributes.Add("id", codigoPostal)
                    sbUbigeo.AppendFormat("{0}{1}{2};{3}|", dpto_id, provincia_id, distrito_id, distrito_id)
                    If codigoPostal <> "" Then sbCodigoPostal.AppendFormat("{0};{1}|", distrito_id, codigoPostal)
                End If
                sbAlmacenDistrito.AppendFormat("{0};{1}|", distrito_id, almacenId)
                sb.Append(linea)
            Next
            hidDistritos.Value = sb.ToString()
            hidListaCodigoPostal.Value = sbCodigoPostal.ToString()
            hidListUbigeo.Value = sbUbigeo.ToString()
            'hidListaAlmacenDistrito.Value = sbAlmacenDistrito.ToString()

            '********************************************
            'Departamento
            lista = CType(hasListas(5), ArrayList)
            lista.Insert(0, New Departamento("-1", "--Seleccionar--", ""))
            With ddlDepartamento
                .DataSource = lista
                .DataValueField = "DEPAC_CODIGO"
                .DataTextField = "DEPAV_DESCRIPCION"
                .DataBind()
            End With

            Try
                ddlDepartamento.SelectedValue = hidDptoId.Value
            Catch ex As Exception
            End Try

            If hidShowRUC.Value = "true" Then
                filaEmpleador.Visible = True
            Else
                filaEmpleador.Visible = False
            End If

            hidProvinciaId.Value = ddlProvincia.SelectedValue

        End If

    End Sub

    Public Function pDireccionTotal() As String
        Dim direccion As String = ""

        direccion &= pTxtdireccion().ToUpper & " " & pTxtnropuerta() & " "

        If ddlEdificacion.SelectedIndex > 0 Then
            direccion &= ddlEdificacion.SelectedItem().ToString().Substring(5, ddlEdificacion.SelectedItem().ToString().Length - 5).ToUpper & " "
            direccion &= ptxtManzana().ToUpper & " LOTE " & ptxtLote() & " "
        End If

        If ddlTipoInterior.SelectedIndex > 0 Then
            direccion &= ddlTipoInterior.SelectedItem.ToString().Substring(6, ddlTipoInterior.SelectedItem().ToString().Length - 6).ToUpper & " "
            direccion &= txtNroInterior.Text & " "
        End If

        If ddlUrbanizacion.SelectedIndex > 0 Then
            direccion &= ddlUrbanizacion.SelectedItem().ToString().Substring(4, ddlUrbanizacion.SelectedItem().ToString().Length - 4).ToUpper & " "
            direccion &= txtUrbanizacion.Text.ToUpper & " "
        End If

        If ddlZona.SelectedIndex > 0 Then
            direccion &= ddlZona.SelectedItem.ToString().Substring(6, ddlZona.SelectedItem().ToString().Length - 6).ToUpper & " "
            direccion &= txtNombreZona.Text & " "
        End If

        Return direccion

    End Function

    Public Function pDireccionSAP() As String
        Dim direccion As String = ""
        direccion &= pTxtdireccion() & " " & pTxtnropuerta() & " "
        Return direccion
    End Function

    Public Function hiddenProvinciaID() As String
        Return hidProvinciaId.Value
    End Function

    Public Function hiddenDistritoID() As String
        Return hidDistritoId.Value
    End Function

End Class
