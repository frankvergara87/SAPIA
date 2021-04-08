Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text

Public Class sisact_pop_plan_combo
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rblLista As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDesPlanSeleccionado As System.Web.UI.WebControls.TextBox
    Protected WithEvents repLista As System.Web.UI.WebControls.Repeater
    Protected WithEvents litLista As System.Web.UI.WebControls.Literal

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim strCodSrvSinBolsaCompartida As String = ConfigurationSettings.AppSettings("consCodSrvSinBolsaCompartida")
    Dim strSrvSinBolsaCompartida As String = ConfigurationSettings.AppSettings("consSrvSinBolsaCompartida")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If


        Inicio()

    End Sub

    'PROY-24740
    Private Sub Inicio()
        Try
            Dim codPlanBase As String = Request.QueryString("idPlanBase")
            Dim desPlanBase As String = Request.QueryString("planBase")

            Dim arrServicio As New ArrayList
            Dim arrPlanCombo As ArrayList = (New ConsumerNegocio).ListarPlanBaseCombo(codPlanBase)
            Dim strValores As New StringBuilder


            For Each plan1 As Plan In arrPlanCombo
                Dim strPlanCodigo As New StringBuilder(plan1.PLANC_CODIGO)
                strPlanCodigo.AppendFormat("_{0}_{1}_{2}__{3}_{4}_{5};{6}", plan1.PLANN_CAR_FIJ.ToString, plan1.PLANC_EQUI_SAP.ToString, plan1.PLNN_TIPO_PLAN, plan1.GPLNV_DESCRIPCION, plan1.CODIGO_BSCS, plan1.TIPO_PRODUCTOS, plan1.PLANV_DESCRIPCION)
                strValores.AppendFormat("<br /><input type='radio' name='radLista' value='{0}' onclick='seleccionarBolsa(this.value)'>{1}</input>", String.Format("{0}|{1}|{2}|{3}", strPlanCodigo.ToString(), plan1.PLANV_DESCRIPCION, plan1.ServicioCodigo, plan1.ServicioDescripcion), plan1.ServicioDescripcion)
            Next

            Dim oItem As New Plan
            oItem.PLANC_CODIGO = codPlanBase
            oItem.PLANV_DESCRIPCION = desPlanBase
            oItem.ServicioCodigo = strCodSrvSinBolsaCompartida
            oItem.ServicioDescripcion = strSrvSinBolsaCompartida

            arrPlanCombo.Insert(0, oItem)

            strValores.Insert(0, String.Format("<input type='radio' name='radLista' value='{0}' onclick='seleccionarBolsa(this.value)'>{1}</input>", String.Format("{0}|{1}|{2}", oItem.PLANC_CODIGO, oItem.PLANV_DESCRIPCION, oItem.ServicioCodigo), oItem.ServicioDescripcion))
            litLista.Text = strValores.ToString()

            txtDesPlanSeleccionado.Text = desPlanBase

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
