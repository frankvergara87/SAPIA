Option Strict Off

Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades

Public Class sisact_mant_agregar_grupo
    Inherits SisAct_WebBase

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnAgregarPdv As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents txtAccionGrabarPDV As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombreGrupo As System.Web.UI.WebControls.TextBox

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub

    Private Sub btnAgregarPdv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPdv.Click
        Try
            Dim strUsuario As String = CurrentUser 'Convert.ToString(Session("codUsuarioSisact"))
            If Me.txtNombreGrupo.Text = "" Then
                RegisterStartupScript("script", "<script>alert('Ingrese la descripci�n del grupo');</script>")
                Exit Sub
            Else
                Dim res As Integer = New PlanTarifarioBusinessLogic().InsertarGrupo(Me.txtNombreGrupo.Text, strUsuario)
                If res >= 0 Then
                    RegisterStartupScript("script", "<script>llamarPadre();</script>")
                    Session("IdGrupo") = res.ToString
                Else
                    RegisterStartupScript("script", "<script>alert('Error: El registro ya existe.')</script>")
                End If
            End If


        Catch ex As Exception

        End Try


    End Sub
End Class
