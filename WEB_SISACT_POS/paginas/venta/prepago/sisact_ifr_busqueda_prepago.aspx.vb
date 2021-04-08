Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_busqueda_prepago
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTipoVenta As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumeroTelefono As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPaso2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents BtnFocus As System.Web.UI.WebControls.Button

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")
        If (Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Not IsPostBack Then
            Inicio()
        End If
    End Sub

    Private Sub Inicio()
        Try
            btnPaso2.Attributes.Add("OnClick", "return consultar();")
            btnLimpiar.Attributes.Add("OnClick", "return limpiar();")
            BtnFocus.Attributes.Add("OnClick", "return false;")

            lblTipoVenta.Text = CheckStr(Session("TipoVentaExpress"))
            If Session("LineaSelected") Is Nothing Then
                HabilitarControles(True)
            Else
                HabilitarControles(False)
                txtNumeroTelefono.Text = CType(Session("LineaSelected"), ItemGenerico).Numero
            End If
            btnLimpiar.Attributes.Remove("disabled")

            ' Buscar Datos del Usuario logeado (Codigo Vendedor, Punto Venta)
            ObtenerDatosVendedor()
        Catch ex As Exception
            HabilitarControles(True)
            hidMsg.Value = String.Format("Error. {0}", ex.Message)
        End Try
    End Sub

    Private Sub ObtenerDatosVendedor()
        ' No esta en session
        If Session("VendedorSelected") Is Nothing Then
            ' Buscar Datos del Usuario logeado (Codigo Vendedor)
            Dim oUsuario As Usuario
            oUsuario = New MaestroNegocio().ObtenerUsuarioLogin(Me.CurrentUser)
            Dim codUsuario As Integer = CheckInt(oUsuario.UsuarioId)

            ' Buscar Punto de Venta
            'Dim listaPuntoVenta As ArrayList = New MantMaestroNegocio().ListaOficinaVentaXUsuario(codUsuario, "0000", "1")
            Dim listaPuntoVenta As ArrayList = New MaestroNegocio().ListaPDVUsuario(codUsuario, "")

            If listaPuntoVenta.Count = 0 Then
                Throw New Exception("Error: Usuario no pertenece a algun Punto de Venta.")
            End If

            ' Guardar los datos escogidos a Session
            Dim itemPuntoVenta As PuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)
            Dim oCanal As New Canal
            oCanal.CANAC_CODIGO = itemPuntoVenta.CANAC_CODIGO
            oCanal.CANAV_DESCRIPCION = itemPuntoVenta.CANAV_DESCRIPCION
            Session("CanalSelected") = oCanal

            Dim oPuntoVenta As New PuntoVenta
            oPuntoVenta.OVENC_CODIGO = itemPuntoVenta.OVENC_CODIGO
            oPuntoVenta.OVENV_DESCRIPCION = itemPuntoVenta.OVENV_DESCRIPCION
            oPuntoVenta.CANAC_CODIGO = itemPuntoVenta.CANAC_CODIGO
            oPuntoVenta.TOFIC_CODIGO = itemPuntoVenta.TOFIC_CODIGO
            Session("PuntoVentaSelected") = oPuntoVenta

            Dim oVendedor As New Vendedor
            oVendedor.Id_Distribuidor_Vendedor = CheckStr(Session("CodVendedorSAP")) 'oUsuario.CodigoVendedor
            oVendedor.Nombre = oUsuario.NombreCompleto
            Session("VendedorSelected") = oVendedor
        End If
    End Sub

    Private Sub btnPaso2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaso2.Click
        Try
            Dim datosLinea As New ItemGenerico
            datosLinea.Numero = txtNumeroTelefono.Text
            Session("LineaSelected") = datosLinea

            If BusquedaPrepago() Then
                Dim pasosVenta() As String = CType(Session("PasosVenta"), String())
                pasosVenta(0) = CheckStr(CheckInt(pasosVenta(0)) + 1)
                Session("PasosVenta") = pasosVenta

                HabilitarControles(False)
                Refrescar()
            Else
                HabilitarControles(True)
            End If
            btnLimpiar.Attributes.Remove("disabled")
        Catch ex As Exception
            HabilitarControles(True)
            hidMsg.Value = String.Format("Error preparando Siguiente Paso. {0}", ex.Message)
        End Try
    End Sub

    Private Sub HabilitarControles(ByVal flag As Boolean)
        If flag Then
            btnPaso2.Attributes.Remove("disabled")
            txtNumeroTelefono.Attributes.Remove("disabled")
            btnLimpiar.Attributes.Remove("disabled")
        Else
            btnPaso2.Attributes.Add("disabled", "disabled")
            txtNumeroTelefono.Attributes.Add("disabled", "disabled")
            btnLimpiar.Attributes.Add("disabled", "disabled")
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Try
            Dim pasosVenta() As String = CType(Session("PasosVenta"), String())
            pasosVenta(0) = "2"
            Session("PasosVenta") = pasosVenta
            Session("LineaSelected") = Nothing

            Refrescar()
        Catch
        End Try
    End Sub

    Private Function BusquedaPrepago() As Boolean
        Dim buscarLinea As Boolean = False
        Dim nroLinea As String = CType(Session("LineaSelected"), ItemGenerico).Numero
        buscarLinea = BuscarDatosLinea(nroLinea)

        Return buscarLinea
    End Function

    Private Function BuscarDatosLinea(ByVal nroLinea As String) As Boolean

        If Not LeerDatosLinea(nroLinea) Then
            Return False
        End If

        If Not VerificarCantidadRenovacion(nroLinea) Then
            Return False
        End If

        If Not LeerDatosCliente(nroLinea) Then
            Return False
        End If

        ' Auditoria
        Dim puntoVentaCod As String = CType(Session("PuntoVentaSelected"), PuntoVenta).OVENC_CODIGO
        Dim puntoVentaDesc As String = CType(Session("PuntoVentaSelected"), PuntoVenta).OVENV_DESCRIPCION
        Dim tipoDoc As String = CType(Session("SolicitudSelected"), SolicitudPersona).TDOCV_DESCRIPCION
        Dim numeroDoc As String = CType(Session("SolicitudSelected"), SolicitudPersona).CLIEC_NUM_DOC

        Dim descAudit As String = "Se realizó una Busqueda de Número de Linea - Venta Express Renovación Prepago. Filtros (OficinaVenta: " & puntoVentaCod & " - " & puntoVentaDesc & " | Nro de Línea " & nroLinea & "). Resultado (TipoDoc: " & tipoDoc & " | Nro Doc " & numeroDoc & ")."
        AuditoriaBusquedaLinea(descAudit)
        Return True
    End Function

    Private Function VerificarCantidadRenovacion(ByVal nroLinea As String) As Boolean
        'Consultar RFC ZPVU_RFC_CON_HIST_X_NRO_TELEF y comparar con valor de parametro
        Dim oSapNegocios As New SapGeneralNegocios
        Dim oClienteNegocios As New ClienteNegocio
        Dim oficina As String = ConfigurationSettings.AppSettings("constPtoVentaDefault")
        Dim dsDatosSAP As DataSet = oSapNegocios.get_ConsultaHistoria("", nroLinea, oficina)
        Dim Clase As String = ConfigurationSettings.AppSettings("constClaseRenovPrepago")
        Dim iCont As Integer = 0
        Dim iRenovaciones As Integer = 0
        Dim iResult As Integer = 0
        Dim sFecha, sClase As String
        Dim fecha As String
        Dim i As Integer

        If dsDatosSAP.Tables(0).Rows.Count() > 0 Then

            For i = 0 To dsDatosSAP.Tables(0).Rows.Count() - 1 '.Columns.Count - 1
                sFecha = CheckStr(dsDatosSAP.Tables(0).Rows(i)(4))
                sClase = CheckStr(dsDatosSAP.Tables(0).Rows(i)(8))
                sFecha = Right(sFecha, 2) + "/" + sFecha.Substring(4, 2) + "/" + Left(sFecha, 4)
                iResult = oClienteNegocios.registrarPeriodoRenovaciones(nroLinea, sFecha, sClase)
            Next

            If iResult = 1 Then
                iRenovaciones = oClienteNegocios.consultarPeriodoRenovaciones(nroLinea)
                If iRenovaciones = 1 Then
                    VerificarCantidadRenovacion = False
                    hidMsg.Value = "El Cliente alcanzo la cantidad máxima para renovar equipos"
                    Return False
                Else
                    VerificarCantidadRenovacion = True
                End If
            End If
        Else
            ' Si no tiene renovaciones en SAP entonces entra al procediemiento de consulta, de todas maneras...
            iRenovaciones = oClienteNegocios.consultarPeriodoRenovaciones(nroLinea)
            If iRenovaciones = 1 Then
                VerificarCantidadRenovacion = False
                hidMsg.Value = "El Cliente alcanzo la cantidad máxima para renovar equipos"
                Return False
            Else
                VerificarCantidadRenovacion = True
            End If
        End If

        Return True
    End Function

    Private Function LeerDatosLinea(ByVal nroLinea As String) As Boolean
        Dim oPrepagoNegocios As New DatosPrepagoNegocios

        Dim providerIdPrepago As String = ConfigurationSettings.AppSettings("ProviderIdPrepago").ToString()
        Dim providerIdControl As String = ConfigurationSettings.AppSettings("ProviderIdControl").ToString()
        Dim mensajeError As String = ""
        Dim datosLinea As ItemGenerico = Nothing

        datosLinea = oPrepagoNegocios.LeerDatosPrepago(nroLinea, providerIdPrepago, providerIdControl, mensajeError)
        If datosLinea Is Nothing Then
            hidMsg.Value = "Error. " & mensajeError
            Return False
        End If
        If Not datosLinea.estado.ToUpper().Equals("P") Then
            hidMsg.Value = "Error. El Número ingresado NO es PREPAGO"
            Return False
        End If
        If datosLinea.Codigo.ToUpper().Equals("TRUE") Then
            hidMsg.Value = "Error. Número ingresado esta BLOQUEADO."
            Return False
        End If
        If Not datosLinea.Codigo2.ToUpper().Equals("1") Then
            hidMsg.Value = "Error. La Linea NO se encuentra activada."
            Return False
        End If

        Dim lineaSelected As ItemGenerico = CType(Session("LineaSelected"), ItemGenerico)
        lineaSelected.Numero = datosLinea.Numero
        lineaSelected.Descripcion = datosLinea.Descripcion
        lineaSelected.Codigo = datosLinea.Codigo
        lineaSelected.Codigo2 = datosLinea.Codigo2
        lineaSelected.estado = datosLinea.estado

        Session("LineaSelected") = lineaSelected
        Return True
    End Function

    Private Function LeerDatosCliente(ByVal nroLinea As String) As Boolean
        Dim oClienteNegocios As New ClienteNegocio
        Dim flagConsulta As String = ""
        Dim mensajeError As String = ""

        Dim oCliente As Cliente = oClienteNegocios.ObtenerCliente(nroLinea, "", "", "1", flagConsulta, mensajeError)
        If oCliente.OBJID_CONTACTO Is Nothing Then
            hidMsg.Value = "Error. Nro de Línea del Cliente no se encuentra en la BD de Clarify."
            Return False
        End If

        ' Guardar los datos del cliente
        Dim oSolicitudPersona As New SolicitudPersona
        oSolicitudPersona.TVENC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago")
        oSolicitudPersona.CCLIC_CODIGO = CheckStr(oCliente.ID_CLIENTE) 'Este dato no existe
        oSolicitudPersona.CLIEV_NOMBRE = oCliente.NOMBRES
        oSolicitudPersona.CLIEV_RAZ_SOC = oCliente.RAZON_SOCIAL
        oSolicitudPersona.CLIEV_APE_PAT = oCliente.APELLIDOS '_PATERNO 'Este dato esta junto (Ap_Paterno + ApMaterno)
        oSolicitudPersona.CLIEV_APE_MAT = oCliente.APELLIDO_MATERNO 'Este dato esta junto (Ap_Paterno + ApMaterno)
        oSolicitudPersona.TDOCV_DESCRIPCION = oCliente.TIPO_DOC
        oSolicitudPersona.CLIEC_NUM_DOC = oCliente.NRO_DOC

        ' Por defecto Tipo Documento DNI
        oSolicitudPersona.TDOCC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") 'CheckStr(oCliente.ID_TIP_DOC)
        Dim docDNI, docCE, docRUC, docPASS As String
        docDNI = ConfigurationSettings.AppSettings("ExpressTipoDocDNI")
        docCE = ConfigurationSettings.AppSettings("ExpressTipoDocCE")
        docRUC = ConfigurationSettings.AppSettings("ExpressTipoDocRUC")
        docPASS = ConfigurationSettings.AppSettings("ExpressTipoDocPASS")

        ' Buscar el Tipo de Documento
        If docDNI.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docDNI.Split(";"c)(0)
        ElseIf docCE.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docCE.Split(";"c)(0)
        ElseIf docRUC.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docRUC.Split(";"c)(0)
        ElseIf docPASS.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docPASS.Split(";"c)(0)
        End If

        oSolicitudPersona.CLIEV_PRE_TEL_LEG = ""
        oSolicitudPersona.CLIEV_TEL_LEG = oCliente.TELEFONO_DOMICILIO
        oSolicitudPersona.CLIEV_PRE_DIR = ""
        oSolicitudPersona.CLIEV_DIRECCION = oCliente.DIRECCION
        oSolicitudPersona.DEPAV_DESCRIPCION = oCliente.DEPARTAMENTO
        oSolicitudPersona.PROVV_DESCRIPCION = oCliente.PROVINCIA
        oSolicitudPersona.DISTV_DESCRIPCION = oCliente.DISTRITO
        oSolicitudPersona.OVENC_CODIGO = CType(Session("PuntoVentaSelected"), PuntoVenta).OVENC_CODIGO

        Dim oConsultaSap As New SapGeneralNegocios
        Dim dsDatosSAP As DataSet = oConsultaSap.Get_ConsultaCliente(oSolicitudPersona.OVENC_CODIGO, oSolicitudPersona.TDOCC_CODIGO, oCliente.NRO_DOC)
        Dim dtCliente As System.Data.DataTable = dsDatosSAP.Tables(0)
        Session("ClienteSAP") = Nothing
        If dtCliente.Rows.Count > 0 Then
            Session("ClienteSAP") = dtCliente
            oSolicitudPersona.CLIEV_NOMBRE = CheckStr(dtCliente.Rows(0)("NOMBRE"))
            oSolicitudPersona.CLIEV_RAZ_SOC = CheckStr(dtCliente.Rows(0)("RAZON_SOCIAL"))
            oSolicitudPersona.CLIEV_APE_PAT = CheckStr(dtCliente.Rows(0)("APELLIDO_PATERNO"))
            oSolicitudPersona.CLIEV_APE_MAT = CheckStr(dtCliente.Rows(0)("APELLIDO_MATERNO"))
            'oSolicitudPersona.TDOCC_CODIGO = "0" & CheckStr(dtCliente.Rows(0)("TIPO_DOC_CLIENTE"))

            oSolicitudPersona.CLIEV_PRE_TEL_LEG = CheckStr(dtCliente.Rows(0)("TELEF_LEGAL_PREF"))
            oSolicitudPersona.CLIEV_TEL_LEG = CheckStr(dtCliente.Rows(0)("TELEF_LEGAL"))
            oSolicitudPersona.CLIEV_PRE_DIR = ""
            oSolicitudPersona.CLIEV_DIRECCION = CheckStr(dtCliente.Rows(0)("CALLE_LEGAL"))

        End If

        Session("SolicitudSelected") = oSolicitudPersona
        Return True

    End Function

    Private Sub Refrescar()
        Try
            Dim pasosVenta() As String = CType(Session("PasosVenta"), String())

            Dim strScript As String = String.Format("window.parent.refrescar({0},{1});", pasosVenta(0), pasosVenta(1))
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        Catch ex As Exception
            hidMsg.Value = String.Format("Error. No se pudo continuar con Siguiente Paso. {0}", ex.Message)
        End Try
    End Sub

#Region " Auditoria"
    Private Sub AuditoriaBusquedaLinea(ByVal descTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("ExpressPreRenAuditBusqueda")

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", descTrans)
            If Not auditoriaGrabado Then
                Throw New Exception("Error. No se registro en Auditoria la Busqueda de Número de Linea.")
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class
