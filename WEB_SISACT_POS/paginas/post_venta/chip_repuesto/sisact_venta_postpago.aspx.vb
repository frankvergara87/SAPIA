Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones

Public Class sisact_venta_postpago
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlTipoDocId As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNumeroDocId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroLinea As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHlr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVendedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSerieChip As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodMaterial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescArticulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCampania As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPrecio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensajeValidaCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTelefono As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioSubTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOK As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniaDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaPrecioDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampanias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPLSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOrgVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanalVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlDesArticulo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidNroDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCadenaServiciosRechazados As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCadenaPlanesAceptados As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMaterialesPostpago As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensajeReposicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtNombreCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidPerfil_149 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlDepartamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProvincia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDistrito As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidCadenaProvincias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCadenaDistritos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDesMaterial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProvinciaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDistritoSelected As System.Web.UI.HtmlControls.HtmlInputHidden

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
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_reposicion_postpago")

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty) Or CheckStr(Session("CodVendedorSAP")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        ' Eventos de los Controles
        ddlTipoDocId.Attributes.Add("onChange", "cambiarTipoDoc(this.value);")
        ddlCampania.Attributes.Add("onChange", "cargarListaPrecios();")
        ddlPrecio.Attributes.Add("onChange", "cargarPrecio();")

        If Not IsPostBack Then
            Inicio()
        Else
            If hidAccion.Value = "Consultar" Then
                Consultar()
            ElseIf hidAccion.Value = "GenerarPedido" Then
                GenerarPedido()
            End If
            hidAccion.Value = ""
        End If
    End Sub


    Private Sub Inicio()
        Try
            hidTipoVenta.Value = ConfigurationSettings.AppSettings("constCodTipoVentaPostpago").ToString()
            hidTipoOperacion.Value = ConfigurationSettings.AppSettings("constCodOperReposicion").ToString()
            hidTipoCliente.Value = ConfigurationSettings.AppSettings("constCodTipoClienteConsumer").ToString()
            hidPlanDefault.Value = ConfigurationSettings.AppSettings("constCodPlanChipRepuestoPospago").ToString()
            hidCampaniaDefault.Value = ConfigurationSettings.AppSettings("constCodCampaniaChipPospago").ToString()
            hidListaPrecioDefault.Value = ConfigurationSettings.AppSettings("constCodListPrecioChip").ToString()

            ObtenerDatosVendedor()
            CargarTipoDocumento()
            CargarCampanias()
            ConsultarDatosVenta()
            ObtenerPlanesServiciosParam()
            ObtenerUbigeo()

            txtHlr.Text = ""
            txtNombreCliente.Text = ""
            txtTotal.Text = "0.00"
            txtVendedor.Text = CheckStr(Session("CodVendedorSAP"))
            txtFecha.Text = String.Format("{0:dd/MM/yyyy}", Now)
        Catch ex As Exception
            hidMsg.Value = String.Format("Error. {0}", ex.Message)
        End Try
    End Sub

    Private Sub ObtenerPlanesServiciosParam()
        Dim listaParametros As New ArrayList
        Dim codParam As String = ConfigurationSettings.AppSettings("consCodParamValidarPlanServicio")
        Dim oMaterialParametro As New ParametroConsumer
        listaParametros = New ConsumerNegocio().ListarParametroGeneral(codParam)

        For Each oMaterialParametro In listaParametros
            Select Case oMaterialParametro.PCONV_VALOR
                Case "PLAN_ACEPTADO"
                    hidCadenaPlanesAceptados.Value = oMaterialParametro.PCONV_DESCRIPCION

                Case "SERVICIO_RECHAZADO"
                    hidCadenaServiciosRechazados.Value = oMaterialParametro.PCONV_DESCRIPCION
            End Select
        Next
    End Sub

    Private Sub ObtenerDatosVendedor()
        ' Buscar Datos del Usuario Logeado
        Dim oUsuario As Usuario
        oUsuario = New MaestroNegocio().ObtenerUsuarioLogin(Me.CurrentUser)
        Dim codUsuario As Integer = CheckInt(oUsuario.UsuarioId)

        ' Buscar Punto de Venta
        Dim listaPuntoVenta As ArrayList = New VentaNegocios().ListaPDVUsuario(codUsuario, "")

        If IsNothing(listaPuntoVenta) OrElse listaPuntoVenta.Count = 0 Then
            Throw New Exception("Error: Usuario no pertenece a algun Punto de Venta.")
        Else
            ' Guardar los datos generales de Venta
            Dim itemPuntoVenta As PuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)

            ' Validando los puntos de ventas existentes
            Dim existeCanal As Boolean = False
            Dim codCAC As String = ConfigurationSettings.AppSettings("constCodTipoCAC")
            Dim codDAC As String = ConfigurationSettings.AppSettings("constCodTipoDAC")
            Dim codCorner As String = ConfigurationSettings.AppSettings("CacCorner")

            Dim codCaneles() As String = {codCAC, codDAC, codCorner}
            For Each _canal As String In codCaneles
                If (_canal.Equals(itemPuntoVenta.TOFIC_CODIGO)) Then
                    existeCanal = True
                    Exit For
                End If
            Next
            If Not existeCanal Then
                Throw New Exception("Error: El Punto de Venta no existe.")
            End If

            'Validar Punto de venta para reposicion
            Dim objUsuarioNeg As LoginUsuarioNegocios = New LoginUsuarioNegocios
            Dim puntoVentaLogin As PuntoVenta = objUsuarioNeg.ValidarOficinaVenta(itemPuntoVenta.OVENC_CODIGO)

            If IsNothing(puntoVentaLogin) Then
                Throw New Exception("El Punto de Venta " & itemPuntoVenta.OVENV_DESCRIPCION & " no está configurado para la reposición.")
            Else
                Dim valorReposicion As String = puntoVentaLogin.OVENC_PDV_REPOS
                If Not valorReposicion.Equals("1") Then
                    hidMensajeReposicion.Value = "El Punto de Venta " & puntoVentaLogin.OVENV_DESCRIPCION & " no está configurado para la reposición."
                    Throw New Exception(hidMensajeReposicion.Value)
                End If
            End If

            ' Guardar canal de vendedor
            hidOfVenta.Value = CheckStr(itemPuntoVenta.OVENC_CODIGO)
            hidCanalVenta.Value = CheckStr(itemPuntoVenta.TOFIC_CODIGO)

            'Validar datos usuario
            hidPerfil_149.Value = "N"
            If itemPuntoVenta.OVENC_CODIGO.Equals(ConfigurationSettings.AppSettings("CONS_COD_PTOVTA_149")) Then
                hidPerfil_149.Value = "S"
            End If

            'Se Obtiene los materiales configurados para la venta postpago
            CargarMaterialesPostpago(codCAC)

            oUsuario = Nothing
            itemPuntoVenta = Nothing
            listaPuntoVenta = Nothing

        End If
    End Sub

    Private Sub CargarMaterialesCAC()
        Dim listaMateriales As New ArrayList
        Dim codParam As String = ConfigurationSettings.AppSettings("consCodParamMaterialesCAC")
        Dim oMaterialParametro As New ParametroConsumer
        listaMateriales = New ConsumerNegocio().ListarParametroGeneral(codParam)
        oMaterialParametro.PCONV_VALOR = "00"
        oMaterialParametro.PCONV_DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
        listaMateriales.Insert(0, oMaterialParametro)

        LlenaCombo(listaMateriales, ddlDesArticulo, "PCONV_VALOR", "PCONV_DESCRIPCION")
        listaMateriales = Nothing
        oMaterialParametro = Nothing
    End Sub

    Private Sub CargarMaterialesPostpago(ByVal codCAC As String)
        Dim listaMateriales As New ArrayList
        Dim codParam As String = ConfigurationSettings.AppSettings("consCodParamMaterialesCAC")
        listaMateriales = New ConsumerNegocio().ListarParametroGeneral(codParam)

        If hidCanalVenta.Value.Equals(codCAC) Then
            Dim oMaterialParametro As New ParametroConsumer
            oMaterialParametro.PCONV_VALOR = "00"
            oMaterialParametro.PCONV_DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
            listaMateriales.Insert(0, oMaterialParametro)

            LlenaCombo(listaMateriales, ddlDesArticulo, "PCONV_VALOR", "PCONV_DESCRIPCION")
            oMaterialParametro = Nothing
            ddlDesArticulo.Attributes.Add("onChange", "f_CambiaIccid()")
        Else
            Dim strMateriales As String = String.Empty
            For Each item As ParametroConsumer In listaMateriales
                strMateriales = strMateriales & "|" & CheckStr(item.PCONV_VALOR)

                oLog.Log_WriteLog(strArchivo, " - " & "******** Carga de materiales de postpago:")
                oLog.Log_WriteLog(strArchivo, " - " & CheckStr(item.PCONV_VALOR))
            Next
            hidMaterialesPostpago.Value = strMateriales
        End If

        listaMateriales = Nothing
    End Sub

    Private Sub ConsultarTipoDocVenta()
        Dim codCAC As String = ConfigurationSettings.AppSettings("constCodTipoCAC")
        If hidCanalVenta.Value.Equals(codCAC) Then
            Dim dsClasePedido As New DataSet
            Dim oficina As String = hidOfVenta.Value
            Dim tipoDocCliente As String = ddlTipoDocId.SelectedValue

            dsClasePedido = (New SapGeneralNegocios).ConsultarTipoDocumentoOfVenta(hidOfVenta.Value)
            Dim listaTipoDocVenta() As String = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPos" & tipoDocCliente).Split(CChar(","))

            For Each item As String In listaTipoDocVenta
                If hidTipoDocVenta.Value <> "" Then
                    Exit For
                End If
                For Each fila As System.Data.DataRow In dsClasePedido.Tables(0).Rows
                    If CheckStr(fila.Item("AUART")) = item Then
                        hidTipoDocVenta.Value = item
                        Exit For
                    End If
                Next
            Next

            dsClasePedido = Nothing
            listaTipoDocVenta = Nothing
        Else
            hidTipoDocVenta.Value = ConfigurationSettings.AppSettings("constTipoDocVentaChip").ToString()
        End If

    End Sub

    Private Sub CargarTipoDocumento()
        Dim listaTipoDoc As New ArrayList
        Dim oTipoDocumento As New ItemGenerico

        listaTipoDoc = New VentaNegocios().ListaTipoDocumento("")
        'Remuevo los item de CIP y PASAPORTE 
        listaTipoDoc.RemoveRange(3, 1)
        listaTipoDoc.RemoveRange(1, 1)

        oTipoDocumento.Codigo = "00"
        oTipoDocumento.Descripcion = ConfigurationSettings.AppSettings("Seleccionar")
        listaTipoDoc.Insert(0, oTipoDocumento)

        LlenaCombo(listaTipoDoc, ddlTipoDocId, "Codigo", "Descripcion")
        listaTipoDoc = Nothing
        oTipoDocumento = Nothing
    End Sub

    Private Sub ConsultarDatosVenta()

        Dim oConsultarSap As New SapGeneralNegocios
        Dim dsOficina As New DataSet
        dsOficina = oConsultarSap.ConsultarParametrosOfVenta(CheckStr(hidOfVenta.Value))

        hidCanal.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
        hidOrgVenta.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))

        dsOficina = Nothing
        oConsultarSap = Nothing
    End Sub

    Private Sub CargarCampanias()
        Dim listaCampanias As New ArrayList
        Dim fecha As String = String.Format("{0:yyyy/MM/dd}", Now)
        Dim TipoVenta As String = hidTipoVenta.Value
        Dim strCampanias As String = "00" & "," & ConfigurationSettings.AppSettings("Seleccionar")

        listaCampanias = (New SapGeneralNegocios).Get_ConsultaCampana(fecha, TipoVenta)
        For Each item As ItemGenerico In listaCampanias
            strCampanias = strCampanias & ";" & CheckStr(item.Codigo) & "," & CheckStr(item.Descripcion)
        Next

        hidCampanias.Value = strCampanias
        listaCampanias = Nothing
    End Sub

    Private Sub Consultar()
        Dim flagOK As Boolean
        Dim mensaje As String
        Dim flag_valida As String
        Dim datosCliente(4) As String

        Dim nroLinea As String = CheckStr(txtNroLinea.Text)
        Dim nroClieDoc As String = CheckStr(txtNumeroDocId.Text)
        Dim tipoClieDoc As String = CheckStr(ddlTipoDocId.SelectedValue)
        Dim desClieDoc As String = CheckStr(ddlTipoDocId.SelectedItem.Text)
        hidMensajeValidaCliente.Value = "OK"

        Try
            If LeerDatosLinea(nroLinea, datosCliente) Then

                Dim objRestChipRepuestoNegocio As New RestChipRepuestoNegocio
                Dim cod_Respuesta, strMensaje As String
                Dim usuario_id As String = CurrentUser
                Dim ipcliente As String = CurrentTerminal
                Dim idTransaccion As String = String.Format("{0:yyyyMMdd}", Now)

                cod_Respuesta = objRestChipRepuestoNegocio.validarBloqueoPostpago(idTransaccion, ipcliente, ConfigurationSettings.AppSettings("constAplicacion").ToString(), nroLinea, strMensaje)
                'validacion de los mensajes de error

                Select Case cod_Respuesta
                    Case "0"
                        ' permite seguir con el proceso de reposicion de chip postapgo
                        flag_valida = "OK"
                    Case "1"
                        Auditoria(ConfigurationSettings.AppSettings("CodTransRechazoReposicion").ToString(), "Error al realizar la validacion del Nro de Linea:" & nroLinea)
                        RegisterStartupScript("script", "<script>alert('Línea bloqueada por uso prohibido. No procede desbloqueo, ni reposición de SIMCARD bajo ningún motivo');</script>")
                        Exit Sub
                    Case Else
                        Auditoria(ConfigurationSettings.AppSettings("CodTransRechazoReposicion").ToString(), "Línea bloqueada por uso prohibido. No procede desbloqueo, ni reposición de SIMCARD bajo ningún motivo. Nro de Linea:" & nroLinea)
                        RegisterStartupScript("script", "<script>alert('Ocurrio un error al realizar la validacion del numero.');</script>")
                        Exit Sub
                End Select

                Dim cod_id As String = datosCliente(4)

                'Validar Planes y Servicios
                Dim validaPlanServicio As Boolean = ValidarPlanServiciosBSCS(nroClieDoc, tipoClieDoc, nroLinea, cod_id, strMensaje)
                If Not validaPlanServicio Then
                    RegisterStartupScript("script", "<script>alert('" & strMensaje & "');</script>")
                    Exit Sub
                End If

                'Consultar Tipo Documento de Venta
                ConsultarTipoDocVenta()

                txtHlr.Text = CheckStr(ConsultaHlr(nroLinea))
                hidTelefono.Value = nroLinea
                hidNroDoc.Value = nroClieDoc
                hidTipoDocCliente.Value = tipoClieDoc

                Dim nombreCliente As String = String.Empty
                If tipoClieDoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                    nombreCliente = datosCliente(2) 'Razon Social
                Else
                    nombreCliente = datosCliente(0) & " " & datosCliente(1) 'Nombre  y Apellido
                End If
                txtNombreCliente.Text = nombreCliente
                hidDatosCliente.Value = Join(datosCliente, ";")

                Dim strScript As String = "validaFlujo('" + CheckStr(flag_valida).ToUpper() + "');"
                RegisterStartupScript("script", "<script>" & strScript & "</script>")
            End If
        Catch ex As Exception
            RegisterStartupScript("script", "<script>alert('Ocurrió un error al validar el cliente');</script>")
        End Try

    End Sub

    Private Function ValidarPlanServiciosBSCS(ByVal nroClieDoc As String, ByVal tipoClieDoc As String, ByVal nroLinea As String, ByVal cod_id As String, ByRef mensajeError As String) As Boolean
        Dim vExito As Boolean = False
        Try
            'Se invocan los servicios BSCS y se obitiene el codigo del plan

            Dim boolValidacion As Boolean

            'Se valida el plan
            'boolValidacion = ValidarPlan(nroLinea, mensajeError)
            'If Not boolValidacion Then Return False

            'Se valida el servicio
            boolValidacion = ValidarServicios(cod_id, mensajeError)
            If Not boolValidacion Then Return False

            'Pasó las validaciones de Plan y Servicios
            vExito = True

        Catch ex As Exception
            mensajeError = "Error al validar Plan y Servicios BSCS."
            oLog.Log_WriteLog(strArchivo, nroClieDoc & " - " & "Error validar Plan y Servicio BCSC. " & ex.Message)
            vExito = False
        End Try

        Return vExito

    End Function

    Private Function ValidarPlan(ByVal NroLinea As String, ByRef mensajeError As String) As Boolean
        Dim _validaPlan As Boolean = False
        Dim flgPlanAceptado As String = ConfigurationSettings.AppSettings("consCodParamValidarPlanAceptadoFlag")
        If flgPlanAceptado.Equals("1") Then
            Dim oChipRespuestoPostpago As New ChipRepuestoPostpagoNegocio
            Dim intResutado As Int32

            Dim strMensaje As String = String.Empty
            intResutado = oChipRespuestoPostpago.ValidarPlanesLTG4G(NroLinea, strMensaje)
            If intResutado = 0 Then
                        _validaPlan = True
                        Return _validaPlan
            Else
                mensajeError = strMensaje
            End If


        End If
        oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "******** Valida el plan:")
        oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " " & mensajeError)

        Return _validaPlan
    End Function

    Private Function ValidarServicios(ByVal cod_id As String, ByRef mensajeError As String) As Boolean
        Dim _validaPlan As Boolean = True
        Dim flgServicioRechazados As String = ConfigurationSettings.AppSettings("consCodParamValidarServicioRechazadosFlag")


        If flgServicioRechazados.Equals("1") Then
            Dim codPlan As String = String.Empty
            Dim desPlan As String = String.Empty '--dga
            Dim dsListaServicios As DataSet = (New ChipRepuestoPostpagoNegocio).ListaServicios(cod_id, codPlan, desPlan)
            Dim listServicios As ArrayList = New ArrayList
            'Se reccorre el cursor del detalle
            If Not IsNothing(dsListaServicios) AndAlso dsListaServicios.Tables(0).Rows.Count > 0 Then
                'Se obtiene el codigo de plan
                Dim dtServicios As DataTable = dsListaServicios.Tables(0)
                For Each _item As DataRow In dtServicios.Rows
                    listServicios.Add(CheckStr(_item("SNCODE")))
                Next
            End If


            If Not (hidCadenaServiciosRechazados.Value.Equals("")) Then
                If listServicios.Count > 0 Then
                    Dim ServiciosRechazados As String() = hidCadenaServiciosRechazados.Value.Split("|")
                    For Each _servicio As String In listServicios
                        'Se valida cada servicio
                        For Each _item As String In ServiciosRechazados
                            If _servicio.Equals(Trim(_item)) Then
                                _validaPlan = False
                                mensajeError = "El servicio no se encuentra apto"
                                oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "****** Valida el Servicio:")
                                oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " " & mensajeError)
                                Return _validaPlan
                            End If
                        Next
                    Next
                Else
                    _validaPlan = False
                    mensajeError = "No cuenta con servicios activados"
                    oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "****** Valida el servicio:")
                    oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " " & mensajeError)
                    Return _validaPlan
                End If
            End If
        End If
        Return _validaPlan
    End Function

    Private Function ConsultaHlr(ByVal nroLinea As String) As String
        Dim oConsulta As New VentaNegocios
        Dim Msisdn As String = "51" & nroLinea
        Dim strHLR As String = Right("00" & CheckStr(oConsulta.ObtenerNroHLR(Msisdn)), 2)

        Return strHLR
    End Function

    Private Function LeerDatosLinea(ByVal nroLinea As String, ByRef datosCliente() As String) As Boolean

        Dim oPostpagoNegocios As New DatosPostpagoNegocios
        Dim oVentaExpress As New VentaExpressNegocios

        Dim mensajeError As String = String.Empty
        Dim datosLinea As ClienteBSCS = Nothing
        Dim resp As Boolean = True
        'INICIO WHZR 25112014
        Dim strConsumer As String = ConfigurationSettings.AppSettings("strPostTipClienteConsumer")
        'FIN WHZR 25112014


        datosLinea = oPostpagoNegocios.LeerDatosCliente(nroLinea, "", mensajeError)

        If IsNothing(datosLinea) Then
            hidMsg.Value = "La línea no existe o no es Postpago."
            resp = False
        Else


            'VALIDAR TITULARIDAD DE LA LINEA
            Dim tipodoc As String = ddlTipoDocId.SelectedValue
            Dim nrodoc As String = Trim(txtNumeroDocId.Text)
            Dim boolRUC As Boolean = False

            'INICIO WHZR 25112014
            If (UCase(datosLinea.Tipo_cliente) <> UCase(strConsumer)) Then
                hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCliNoComsumer")
                resp = False
            End If
            'FIN WHZR 25112014

            If tipodoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                boolRUC = True
                If nrodoc <> datosLinea.Ruc_dni Then
                    hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaRUCCli")
                    resp = False
                End If

            ElseIf tipodoc = ConfigurationSettings.AppSettings("TipoDocumentoCE") Then

                If nrodoc <> datosLinea.Num_doc Then
                    hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaCECli")
                    resp = False
                End If

            Else

                If nrodoc <> datosLinea.Num_doc Then
                    hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaDNICli")
                    resp = False
                End If

            End If

            'Se obtiene datos del cliente
            datosCliente(0) = IIf(boolRUC, "", datosLinea.Nombre)
            datosCliente(1) = IIf(boolRUC, "", datosLinea.Apellidos)
            datosCliente(2) = datosLinea.Rep_legal
            datosCliente(3) = IIf(boolRUC, datosLinea.RazonSocial, "")
            datosCliente(4) = datosLinea.Co_id

        End If


        Return resp

    End Function

    Private Sub GenerarPedido()
        Dim oConsultarSap As New SapGeneralNegocios
        Dim cadenaDetalle As String = ""
        Dim cadenaCabecera As String = ""

        Try
            Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
            Dim valorDescuento As Decimal

            'Generar los Parametros
            cadenaCabecera = GenerarCadenaCabecera()
            cadenaDetalle = GenerarCadenaDetalle()

            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "Generar Pedido")
            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - Cadena Cabecera:" & CheckStr(cadenaCabecera))
            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - Cadena Detalle:" & CheckStr(cadenaDetalle))

            ' Realizar Pedido
            Dim pedidoGenerado As Boolean = oConsultarSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", entrega, factura, _
                                            nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)

            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "Resultado: " & CheckStr(pedidoGenerado))

            If Not pedidoGenerado Then
                Throw New Exception("No se pudo Generar el Pedido en Sap.")
            End If

            ' Grabar Detalle Chip Repuesto 
            GenerarDetalleChipSap(factura)

            'Grabar la Venta en SISACT
            Dim strMensajeError As String = String.Empty
            Dim guardarPedido As Boolean = GuardarVentaReposicion(nroContrato, factura, nroPedido, strMensajeError)
            If Not guardarPedido Then
                'Se anula el pedido en SAP
                AnularPedido(factura)
                Throw New Exception(strMensajeError)
            End If

            'Se valida el Tipo de Canal
            If hidCanalVenta.Value = ConfigurationSettings.AppSettings("CacCorner") Then

                Dim blnRegVentaSiscad As Boolean = RegistrarPreventaSICAD(nroPedido)

                If Not blnRegVentaSiscad Then
                    Dim oVentaExpress As New VentaExpressNegocios
                    oVentaExpress.ANULACION_VENTA(nroPedido, CheckStr(Session("Almacen")))
                    'No se registran los datos correctamente en SISCAD
                    Throw New Exception("Error generando la venta en SISCAD.")
                End If
            End If

            ' Auditoria Realizar Pedido
            Dim descRealizarPedido As String = "Se realizó Transacción exitosa de Generar Pedido Postpago. (OficinaVenta: " & hidOfVenta.Value & " | Nro Pedido: " & nroPedido & ")."
            AuditoriaRealizarPedido(descRealizarPedido)

            ' Mensaje de Exito al realizar la Venta
            Dim mensaje As String = "Pedido generado satisfactoriamente." & Chr(13) & "Ingresar a Activación\Pool de Contratos\Documentos por pagar para culminar proceso."
            Dim strScript As String = "window.reload();"

            hidMsg.Value = mensaje
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        Catch ex As Exception
            txtHlr.Text = ""
            txtNombreCliente.Text = ""
            hidMsg.Value = "Error. Generar Pedido. " & ex.Message
            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & hidMsg.Value)
        End Try
        oConsultarSap = Nothing
    End Sub

    Private Function GenerarCadenaCabecera() As String

        Dim oConsultarSap As New SapGeneralNegocios

        Dim oficina As String = CheckStr(hidOfVenta.Value)
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
        Dim nroDocCliente As String = hidNroDoc.Value  'ConfigurationSettings.AppSettings("constCodDocClienteChip")
        Dim tipoDocCliente As String = hidTipoDocCliente.Value   'ConfigurationSettings.AppSettings("constTipoDocClienteChip")
        Dim tipoVenta As String = hidTipoVenta.Value
        Dim tipoCliente As String = hidTipoCliente.Value
        Dim tipoOperacion As String = hidTipoOperacion.Value
        Dim motivoReposicion As String = ConfigurationSettings.AppSettings("constCodMotivoReposicion")
        Dim tipoDocVenta As String = hidTipoDocVenta.Value  'ConfigurationSettings.AppSettings("constTipoDocVentaChip")
        Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")
        Dim totalSinIGV As String = hidPrecioSubTotal.Value
        Dim totalConIGV As String = hidPrecioTotal.Value
        Dim canal As String = hidCanal.Value
        Dim orgVenta As String = hidOrgVenta.Value
        Dim totalIGV As String = CStr(CheckDecimal(hidPrecioTotal.Value) - CheckDecimal(hidPrecioSubTotal.Value))

        ' Cadena Documento
        Dim arrayCabecera(49) As String
        arrayCabecera(0) = ""                                    'Documento
        arrayCabecera(1) = tipoDocVenta                          'Tipo_Documento
        arrayCabecera(2) = oficina                               'Oficina_Venta
        arrayCabecera(3) = String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
        arrayCabecera(4) = tipoDocCliente                        'Tipo_Doc_Cliente
        arrayCabecera(5) = nroDocCliente                         'Cliente
        arrayCabecera(6) = motivoReposicion                      'Motivo de Reposicion
        arrayCabecera(7) = moneda                                'Moneda
        arrayCabecera(9) = totalSinIGV                           'Total_Mercaderia
        arrayCabecera(10) = totalIGV                             'Total_Impuesto
        arrayCabecera(11) = totalConIGV                          'Total_Documento
        arrayCabecera(16) = tipoVenta                            'Tipo_Venta
        arrayCabecera(25) = codVendedor                          'Código Comercial
        arrayCabecera(27) = codVendedor                          'Vendedor
        arrayCabecera(29) = tipoOperacion                        'Chip Repuesto
        arrayCabecera(44) = "01"                                 'Operador
        arrayCabecera(45) = "02"                                 'Tipo de Operador
        arrayCabecera(48) = orgVenta                             'Orgvnt
        arrayCabecera(49) = canal                                'Canal

        oConsultarSap = Nothing
        Return Join(arrayCabecera, ";")
    End Function

    Private Function GenerarCadenaDetalle() As String
        Dim cadenaDetalle As String = ""
        Dim oConsultaExpress As New VentaNegocios

        ' Detalle Linea Venta
        Dim arrayDetalle(28) As String
        Dim consecutivo As String = "000001"
        Dim cantidad As Integer = 1
        Dim codPlan As String = ConfigurationSettings.AppSettings("constCodPlanChipRepuestoPospago")
        Dim desPlan As String = ConfigurationSettings.AppSettings("constDesPlanChipRepuestoPospago")
        Dim arrayListaPrecio() As String = hidPLSelected.Value.Split(","c)
        Dim arrayCampania() As String = hidCampaniaSelected.Value.Split(","c)

        Dim totalSinIGV As String = hidPrecioSubTotal.Value
        Dim totalConIGV As String = hidPrecioTotal.Value
        Dim totalIGV As String = CheckStr(CheckDecimal(hidPrecioTotal.Value) - CheckDecimal(hidPrecioSubTotal.Value))

        ' Iccid
        arrayDetalle(0) = ""                            'Documento
        arrayDetalle(1) = consecutivo                   'Consecutivo (codigo 6 digitos)
        arrayDetalle(2) = txtCodMaterial.Text           'Articulo
        'arrayDetalle(3) = txtDescArticulo.Text          'Des_Articulo
        arrayDetalle(3) = hidDesMaterial.Value
        arrayDetalle(4) = arrayListaPrecio(0)           'Utilizacion
        arrayDetalle(5) = arrayListaPrecio(1)           'Des_Utilizacion
        arrayDetalle(6) = arrayCampania(0)              'Campana
        arrayDetalle(7) = arrayCampania(1)              'Des_Campana
        arrayDetalle(8) = CheckStr(hidIccid.Value)      'Iccid
        arrayDetalle(9) = CheckStr(cantidad)            'Cantidad
        arrayDetalle(10) = totalSinIGV                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
        arrayDetalle(11) = totalConIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
        arrayDetalle(12) = totalIGV                     'Descuento
        arrayDetalle(13) = ""                           'Porc_Descuento
        arrayDetalle(14) = ""                           'Descuento_Adic
        arrayDetalle(15) = totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
        arrayDetalle(16) = totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
        arrayDetalle(17) = ""                           'Impuesto2
        arrayDetalle(18) = codPlan                      'Plan_Tarifario
        arrayDetalle(19) = desPlan                      'Des_Plan_Tarifar
        arrayDetalle(20) = ""                           'Centro_Costo
        arrayDetalle(21) = ""                           'Motivo_Devolucio
        arrayDetalle(22) = ""                           'Asociado
        arrayDetalle(23) = ""                           'Consecutivo_Padr
        arrayDetalle(24) = ""                           'Articulo_Asociac
        arrayDetalle(25) = hidTelefono.Value            'Numero_Telefono
        arrayDetalle(26) = ""                           'Nro_Clarify
        arrayDetalle(27) = ""                           'Dev_Componente
        arrayDetalle(28) = ""                           'Serie_Ant

        cadenaDetalle = Join(arrayDetalle, ";")
        oConsultaExpress = Nothing

        Return cadenaDetalle
    End Function

    Private Sub GenerarDetalleChipSap(ByVal nroPedido As String)

        Dim arrayDetalle(18) As String
        Dim oConsultaSap As New SapGeneralNegocios
        Dim nroLinea As String = CheckStr(hidTelefono.Value)
        Dim motivo As String = ConfigurationSettings.AppSettings("constCodMotivoReposicion")
        Dim puntoVenta As String = CheckStr(hidOfVenta.Value)
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))

        Try
            arrayDetalle(0) = ""
            arrayDetalle(1) = nroLinea
            arrayDetalle(2) = oConsultaSap.ConsultarIccid("", nroLinea, "")
            arrayDetalle(3) = ""
            arrayDetalle(4) = puntoVenta
            arrayDetalle(5) = nroPedido
            arrayDetalle(6) = motivo
            arrayDetalle(7) = hidIccid.Value
            arrayDetalle(9) = codVendedor
            arrayDetalle(10) = ""
            arrayDetalle(11) = String.Format("{0:dd/MM/yyyy}", Now)
            arrayDetalle(12) = Format(Now, "H:mm:ss")
            arrayDetalle(13) = ConfigurationSettings.AppSettings("strEstadoSolNuevo")
            arrayDetalle(14) = "X"
            arrayDetalle(15) = ""
            arrayDetalle(16) = String.Format("{0:dd/MM/yyyy}", Now)
            arrayDetalle(17) = Format(Now, "H:mm:ss")
            ' Grabar Datos Pedido
            oConsultaSap.SetGetLogActivacionChip("", "", Join(arrayDetalle, ";"), "")
        Catch ex As Exception
        End Try
    End Sub


    Private Function GuardarVentaReposicion(ByVal nroContrato As String, ByVal nroFactura As String, ByVal nroPedido As String, ByRef strMensaje As String) As Boolean

        Dim vExito As Boolean
        Dim oVentaReposicion As New VentaReposicionPost

        Try
            oVentaReposicion.repo_doc_sap = nroFactura
            oVentaReposicion.repo_nro_cont = nroContrato
            oVentaReposicion.repo_nro_ped = nroPedido
            oVentaReposicion.repo_tip_ofi = hidCanalVenta.Value
            oVentaReposicion.repo_oficina = hidOfVenta.Value
            oVentaReposicion.repo_cod_ven = CheckStr(Session("CodVendedorSAP"))
            oVentaReposicion.repo_tip_doc_clien = hidTipoDocCliente.Value
            oVentaReposicion.repo_nro_doc = hidNroDoc.Value
            oVentaReposicion.repo_nro_telef = hidTelefono.Value

            'Se obitiene los datos del cliente
            Dim datosCliente() As String = hidDatosCliente.Value.Split(";")
            oVentaReposicion.repo_nom_clien = datosCliente(0)
            oVentaReposicion.repo_ape_clien = datosCliente(1)
            oVentaReposicion.repo_rep_legal = datosCliente(2)
            oVentaReposicion.repo_raz_social = datosCliente(3)

            oVentaReposicion.repo_tip_venta = hidTipoVenta.Value
            oVentaReposicion.repo_tip_oper = hidTipoOperacion.Value
            oVentaReposicion.repo_serie = hidIccid.Value
            oVentaReposicion.repo_cod_mat = txtCodMaterial.Text

            'Se obtiene datos de la campaña y el precio
            Dim arrayListaPrecio() As String = hidPLSelected.Value.Split(","c)
            Dim arrayCampania() As String = hidCampaniaSelected.Value.Split(","c)

            oVentaReposicion.repo_cod_camp = arrayCampania(0)
            oVentaReposicion.repo_list_prec = arrayListaPrecio(0)

            oVentaReposicion.repo_plan_tarif = ConfigurationSettings.AppSettings("constCodPlanChipRepuestoPospago")
            oVentaReposicion.repo_costo = txtTotal.Text
            oVentaReposicion.repo_usuario = CurrentUser
            oVentaReposicion.repo_depac_codigo = ddlDepartamento.SelectedValue
            oVentaReposicion.repo_provc_codigo = hidProvinciaSelected.Value
            oVentaReposicion.repo_distc_codigo = hidDistritoSelected.Value
            oVentaReposicion.repo_est_repos = "01"


            vExito = (New ChipRepuestoPostpagoNegocio).GrabarVentaReposicion(oVentaReposicion, strMensaje)

        Catch ex As Exception
            vExito = False
            strMensaje = "Error grabar venta reposición. " & ex.Message
        End Try

        Return vExito

    End Function

#Region " Auditoria"

    Private Sub AuditoriaRealizarPedido(ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("CodTransAuditVentaPedido")

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
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

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "Metodos RegistroSISCAD"

    Private Function RegistrarPreventaSICAD(ByVal nroPedido As String) As Boolean
        Dim oOficina As New PuntoVenta
        Dim oVentaExpress As New VentaExpressNegocios
        Dim blnRetorno As Boolean
        Dim NroTicket As String

        'Parametros de Salida
        Dim listaPedido As New ArrayList
        Dim listaMaterial As New ArrayList
        Dim listaOrden As New ArrayList
        Dim oVenta As New VentaSiscad

        Dim retorno As String
        Dim exito As Boolean = False

        Dim listaSeriesSinSKU As New ArrayList
        Dim listaSeriesSinPrecio As New ArrayList
        Dim arrRetorno() As String


            If ObtenerDatosOficina(nroPedido, hidOfVenta.Value, oOficina) Then

                If ObtenerDatosVenta(nroPedido, hidOfVenta.Value, oOficina, _
                                            listaPedido, _
                                            listaMaterial, _
                                            listaOrden, _
                                            oVenta) Then

                    oVenta.EstadoVenta = ConfigurationSettings.AppSettings("constEstadoVentaPreventa")
                    oVenta.Usuario = Me.CurrentUser
                    'REGISTRAR CABECERA VENTA SISCAD
                    blnRetorno = oVentaExpress.CrearVenta(oVenta, NroTicket)

                    If blnRetorno Then
                        oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Inicio CrearOrdenVenta")
                        For Each orden As OrdenVentaSiscad In listaOrden

                            'Agregar Nro. Ticket en la Entidad OrdenSiscad
                            orden.TicketPreventa = NroTicket
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Inicio CrearOrdenVenta")
                            'Grabar información de Orden de Venta
                            orden.EstadoMaterial = ConfigurationSettings.AppSettings("constEstadoMaterialPreventa")
                            orden.OrigenVenta = ConfigurationSettings.AppSettings("constAplicacion")

                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP CodigoMaterial:" & orden.CodigoMaterial)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP Serie:" & orden.Serie)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP ListaPrecio:" & orden.ListaPrecio)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP Precio:" & orden.Precio)

                            retorno = oVentaExpress.CrearOrdenVenta(orden)

                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "    OUT retorno: " & retorno)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Fin CrearOrdenVenta")

                            arrRetorno = retorno.Split(";")
                            If CheckInt(arrRetorno(0)) > 0 Then
                                If arrRetorno(1) = "0" Then
                                    listaSeriesSinPrecio.Add(orden)
                                End If

                                If arrRetorno(2) = "0" Then
                                    orden.Precio = arrRetorno(3)
                                    listaSeriesSinSKU.Add(orden)
                                End If
                            End If
                        Next

                        Dim arrID_VENTA() As String
                        arrID_VENTA = NroTicket.Split("-")
                        Dim id_venta As String = arrID_VENTA(1).ToString()
                        Dim EstadoVenta As String = String.Empty
                        EstadoVenta = ConfigurationSettings.AppSettings("constEstadoVentaPreventa")
                        'crear historico''
                        Dim objVenta As New VentaExpressNegocios
                        Dim respuestaHist As Boolean = False
                        oLog.Log_WriteLog(strArchivo, "---RegistroHistoricoVenta---")
                        oLog.Log_WriteLog(strArchivo, "id Venta: " & id_venta)
                        oLog.Log_WriteLog(strArchivo, "Estado: " & EstadoVenta)
                        oLog.Log_WriteLog(strArchivo, "Usuario: " & Me.CurrentUser)
                        respuestaHist = objVenta.RegistroHistoricoVenta(id_venta, EstadoVenta, Me.CurrentUser) 'Session("strUsuario").ToString())
                        oLog.Log_WriteLog(strArchivo, "Resultado: " & respuestaHist.ToString)
                        If Not respuestaHist Then
                            'Dim [error] As String = "Error al registrar el histórico de ventas"
                            'Dim strComando As String = " alert('Error al registrar el histórico de ventas.'); "
                            'RegisterStartupScript("script", "<script>" & strComando & "</script>")
                            'oLog.CrearArchivolog(Session("strUsuario").ToString(), Page.Title, "btngrabar_Click()", "Se realiza el cierre de venta", [error], "Id Venta: " & item.ORDN_ID_VENTA.ToString(),  "")
                            'Master.EstablecerMensajeError([error])
                            Return False
                        End If

                        If (listaSeriesSinPrecio.Count > 0 OrElse listaSeriesSinSKU.Count > 0) Then
                            EnviarCorreoSiscad(oOficina, listaSeriesSinPrecio, listaSeriesSinSKU)
                        End If

                        oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Fin CrearOrdenVenta")
                        exito = True
                    Else
                        exito = False
                    End If
                End If
            End If

        Return exito
    End Function

    Private Function ObtenerDatosOficina(ByVal NroDocSap As String, ByVal PuntoVenta As String, ByRef Oficina As PuntoVenta) As Boolean
        Dim oSiscad As New VentaExpressNegocios
        Dim arrayOficina As New ArrayList
        Dim blnFound As Boolean = False
        Dim strKey As String = PuntoVenta & "|" & NroDocSap

        Try
            'Verificar Oficina es un Corner y Obtener Datos
            Oficina = oSiscad.ObtenerDatosOficinaventa(PuntoVenta)

            If Oficina.OVENC_CODIGO <> "" Then
                blnFound = True
            End If

        Catch ex As Exception
            blnFound = False

        Finally
            arrayOficina = Nothing
            oSiscad = Nothing
        End Try

        Return blnFound
    End Function


    Private Function ObtenerDatosVenta(ByVal NroDocSap As String, _
                                     ByVal PuntoVenta As String, _
                                     ByVal oOficina As PuntoVenta, _
                                     ByRef arrayPedido As ArrayList, _
                                     ByRef arrayMaterial As ArrayList, _
                                     ByRef arrayOrden As ArrayList, _
                                     ByRef oVenta As VentaSiscad) As Boolean

        Dim oConsultaSap As New SapGeneralNegocios
        Dim dsPedido As New DataSet
        Dim dtCabecera As New DataTable
        Dim dtDetalle As New DataTable
        Dim blnFound As Boolean = False
        Dim idx As Integer = 0
        Dim strKey As String = PuntoVenta & "|" & NroDocSap

        Try
            'Consulta Datos Pedido Sap
            dsPedido = oConsultaSap.Get_ConsultaPedido("", PuntoVenta, NroDocSap, "")

            If IsNothing(dsPedido) OrElse dsPedido.Tables.Count = 0 Then
                Throw New Exception("No se encontro Registros Consulta Pedido Sap.")
            Else
                '0.Estructuras Tablas Detalle Pedido Sap
                dtCabecera = CType(dsPedido.Tables(0), DataTable)
                dtDetalle = CType(dsPedido.Tables(1), DataTable)

                If dtCabecera.Rows.Count = 0 Or dtDetalle.Rows.Count = 0 Then
                    Throw New Exception("No se encontro Registros Detalle Pedido Sap.")
                End If
            End If

            '1.Obtener Datos Venta BD Siscad
            oVenta.NroDocCliente = CheckStr(dtCabecera.Rows(0)("CLIENTE"))
            oVenta.TipoDocCliente = CheckStr(dtCabecera.Rows(0)("TIPO_DOC_CLIENTE")).PadLeft(2, "0")
            oVenta.NroContratoSap = CheckStr(dtCabecera.Rows(0)("NUMERO_CONTRATO"))
            oVenta.PuntoVenta = PuntoVenta
            oVenta.NroDocumentoSap = NroDocSap
            oVenta.TipoVenta = CheckStr(dtCabecera.Rows(0)("TIPO_VENTA"))

            If CheckStr(dtCabecera.Rows(0)("TIPO_VENTA")) = "07" Then
                oVenta.TipoVenta = "3"
            End If

            'Valor de Tipo Operacion
            oVenta.TipoOperacion = CheckStr(dtCabecera.Rows(0)("CLASE_VENTA"))
            oVenta.CodAplicacion = ConfigurationSettings.AppSettings("constAplicacion")

            '2.Obtener Detalle Pedido Sap
            For i As Integer = 0 To dtDetalle.Rows.Count - 1

                Dim oPedido As New PedidoSiscad
                Dim oMaterial As New MaterialSiscad

                oPedido.Werks = oOficina.OVENV_CENTRO
                oPedido.Lgort = oOficina.OVENV_ALMACEN
                oPedido.Auart = ConfigurationSettings.AppSettings("clasedocumento")
                oPedido.Vkorg = ConfigurationSettings.AppSettings("Organizacionventas")
                oPedido.Kunnr = oOficina.OVENV_NRO_CLIE_PADRE
                oPedido.Kunag = oOficina.OVENV_NRO_CLIE_HIJO
                oPedido.Vtweg = ConfigurationSettings.AppSettings("Canaldistribucion")
                oPedido.Spart = ConfigurationSettings.AppSettings("Sector")
                oPedido.Vkbur = oOficina.OVENC_CODIGO
                oPedido.Menge = 1

                oPedido.Matnr = CheckStr(dtDetalle.Rows(i)("ARTICULO"))
                oPedido.Vkaus = CheckStr(dtDetalle.Rows(i)("UTILIZACION"))

                If arrayPedido.Count > 0 Then

                    For ii As Integer = 0 To arrayPedido.Count - 1
                        Dim pedido As PedidoSiscad = CType(arrayPedido(ii), PedidoSiscad)

                        If oPedido.Matnr = pedido.Matnr And oPedido.Vkaus = pedido.Vkaus Then
                            oPedido.Menge = pedido.Menge + 1
                            arrayPedido.RemoveAt(ii)
                            Exit For
                        End If
                    Next

                End If

                arrayPedido.Add(oPedido)

                '3.Obtener Lista Materiales Sap
                oMaterial.Matnr = CheckStr(dtDetalle.Rows(i)("ARTICULO"))
                oMaterial.Sernr = CheckStr(dtDetalle.Rows(i)("SERIE")).PadLeft(18, "0")
                oMaterial.Vkaus = CheckStr(dtDetalle.Rows(i)("UTILIZACION"))

                arrayMaterial.Add(oMaterial)

                '4.Obtener Detalle Orden BD Siscad
                Dim oOrden As New OrdenVentaSiscad

                oOrden.CodigoMaterial = CheckStr(dtDetalle.Rows(i)("ARTICULO"))
                oOrden.PuntoVenta = PuntoVenta
                oOrden.ListaPrecio = CheckStr(dtDetalle.Rows(i)("UTILIZACION"))
                oOrden.Precio = CheckDecimal(dtDetalle.Rows(i)("SUBTOTAL")) + CheckDecimal(dtDetalle.Rows(i)("IMPUESTO1"))
                oOrden.NroTelefono = FormatoTelefono(CheckStr(dtDetalle.Rows(i)("NUMERO_TELEFONO")))

                If oOrden.CodigoMaterial.StartsWith("PS") Then
                    idx = idx + 1
                    oOrden.Serie = CheckStr(dtDetalle.Rows(i)("SERIE"))
                    oOrden.Identificador = idx
                Else
                    If arrayOrden.Count > 0 Then
                        For Each chip As OrdenVentaSiscad In arrayOrden
                            If chip.CodigoMaterial.StartsWith("PS") And chip.NroTelefono = oOrden.NroTelefono Then
                                oOrden.Identificador = chip.Identificador
                                Exit For
                            End If
                        Next
                    End If
                    oOrden.Serie = CheckStr(dtDetalle.Rows(i)("SERIE")).Substring(3)
                End If

                arrayOrden.Add(oOrden)
            Next

            blnFound = True

        Catch ex As Exception
            blnFound = False
        Finally
            oConsultaSap = Nothing
            dsPedido = Nothing
            dtCabecera = Nothing
            dtDetalle = Nothing
        End Try

        Return blnFound
    End Function


    Private Sub EnviarCorreoSiscad(ByVal oOficina As PuntoVenta, ByVal listaSeriesSinPrecio As ArrayList, ByVal listaSeriesSinSKU As ArrayList)

        Try
            Dim strMensaje As String
            Dim strListaDistribucion As String
            Dim strCorreoAlerta As String
            Dim strMaterial As String
            Dim strListaPrecios As String

            'Determina Mensaje Series sin precio
            For Each orden As OrdenVentaSiscad In listaSeriesSinPrecio
                strMaterial = orden.CodigoMaterial & " - " & orden.DescMaterial
                strListaPrecios = orden.ListaPrecio & " - " & orden.DesListaPrecio
                strMensaje += String.Format("No se ha encontrado el precio para el material {0} con lista de precios {1} en el punto de venta {2}.", strMaterial, strListaPrecios, oOficina.OVENV_DESCRIPCION) + "|"
            Next

            'Determina Mensaje Precio sin SKU
            For Each orden As OrdenVentaSiscad In listaSeriesSinSKU
                strMensaje += String.Format("No se tiene configurado un SKU para el precio S/. {0} en la cadena {1}.", orden.Precio, oOficina.CANAV_DESCRIPCION) + "|"
            Next

            If strMensaje <> "" Then
                Dim strHTMLCuerpo As String
                Dim arrMensaje() As String
                Dim i As Integer

                arrMensaje = strMensaje.Split("|")
                strHTMLCuerpo = "<HTML>"
                strHTMLCuerpo = strHTMLCuerpo & "<HEAD></HEAD><BODY><table>"
                For i = 0 To UBound(arrMensaje)
                    strHTMLCuerpo = strHTMLCuerpo & "<tr><td>" & arrMensaje(i) & "</tr></td>"
                Next
                strHTMLCuerpo = strHTMLCuerpo & "</table></BODY></HTML>"

                strCorreoAlerta = ObtenerCorreoAlertasSiscad(oOficina.OVENC_CODIGO)
                strListaDistribucion = ObtenerListaDistribucion(ConfigurationSettings.AppSettings("CodParam_CorreoAdmCadenas"))

                sisact_Mail.EnviarEmail(ConfigurationSettings.AppSettings("strEmailRemitente"), strListaDistribucion & ";" & strCorreoAlerta, "", "", ConfigurationSettings.AppSettings("AsuntoCorreoSISCADAlertas"), strHTMLCuerpo, "")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Function ObtenerCorreoAlertasSiscad(ByVal codPdv As String) As String

        Dim strCorreos As String
        Try
            Dim oVentaNegocios As New VentaExpressNegocios
            Dim oAlerta As AlertaSiscad
            oAlerta = oVentaNegocios.CorreoAlertasSiscad(codPdv)
            strCorreos = oAlerta.MAILJEFE & ";" & oAlerta.MAILSECTORISTA
        Catch ex As Exception
            strCorreos = ""
        End Try
        Return strCorreos
    End Function

    Private Function ObtenerListaDistribucion(ByVal key As String) As String

        Dim strCorreos As String
        Try
            Dim oVentaNegocios As New VentaExpressNegocios
            strCorreos = oVentaNegocios.ConsultaParamConfigSiscad(key)
        Catch ex As Exception
            strCorreos = ""
        End Try
        Return strCorreos
    End Function

#End Region


#Region "Metodos Ubigeo"

    Private Sub ObtenerUbigeo()
        ListarDepartamentos()
        ObtenerProvincias()
        ObtenerDistritos()
    End Sub

    Private Sub ListarDepartamentos()

        Dim listaDepartamentos As New ArrayList
        Dim oDepartamento As New Departamento

        listaDepartamentos = New ChipRepuestoPostpagoNegocio().ListaDepartamentos()

        oDepartamento.DEPAC_CODIGO = ""
        oDepartamento.DEPAV_DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
        listaDepartamentos.Insert(0, oDepartamento)

        LlenaCombo(listaDepartamentos, ddlDepartamento, "DEPAC_CODIGO", "DEPAV_DESCRIPCION")
        listaDepartamentos = Nothing
        oDepartamento = Nothing

        ddlDepartamento.Attributes.Add("onChange", "cargarProvincias(this.value)")

    End Sub

    Private Sub ObtenerProvincias()

        Dim listaProvincias As New ArrayList
        listaProvincias = New ChipRepuestoPostpagoNegocio().ListaProvincias("00")
        Dim cadenaProvincias As String = String.Empty

        Dim primerElemento As Boolean = True
        For Each _item As Provincia In listaProvincias
            If primerElemento Then
                cadenaProvincias = _item.PROVC_CODIGO & ";" & _item.PROVV_DESCRIPCION & ";" & _item.DEPAC_CODIGO
                primerElemento = False
            Else
                cadenaProvincias &= "|" & _item.PROVC_CODIGO & ";" & _item.PROVV_DESCRIPCION & ";" & _item.DEPAC_CODIGO
            End If
        Next

        hidCadenaProvincias.Value = cadenaProvincias
        ddlProvincia.Attributes.Add("onChange", "cargarDistritos(this.value)")

    End Sub

    Private Sub ObtenerDistritos()

        Dim listaDistritos As New ArrayList
        listaDistritos = New ChipRepuestoPostpagoNegocio().ListaDistritos("00", "000")
        Dim cadenaDistritos As String = String.Empty

        Dim primerElemento As Boolean = True
        For Each _item As Distrito In listaDistritos
            If primerElemento Then
                cadenaDistritos = _item.DISTC_CODIGO & ";" & _item.DISTV_DESCRIPCION & ";" & _item.DEPAC_CODIGO & ";" & _item.PROVC_CODIGO
                primerElemento = False
            Else
                cadenaDistritos &= "|" & _item.DISTC_CODIGO & ";" & _item.DISTV_DESCRIPCION & ";" & _item.DEPAC_CODIGO & ";" & _item.PROVC_CODIGO
            End If
        Next

        hidCadenaDistritos.Value = cadenaDistritos
        ddlDistrito.Attributes.Add("onChange", "selectedDistrito(this.value)")

    End Sub

#End Region

#Region "RollBack SAP"

    Private Function AnularPedido(ByRef sDocSAP As String) As Boolean

        If sDocSAP = "" Then
            AnularPedido = False
            Exit Function
        End If

        Dim idLog As String = sDocSAP
        Dim boolOK As Boolean
        Dim canalSAP As String = hidCanal.Value
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio Anular_Boleta")
        Try
            Dim obSAP As New SapGeneralNegocios
            Dim canalCAC As String = ConfigurationSettings.AppSettings("CacCorner")
            If Not hidCanalVenta.Value.Equals(canalCAC) Then
                Dim arrCabecera(49) As String
                arrCabecera(0) = sDocSAP
                arrCabecera(1) = "ELIM"
                arrCabecera(2) = CheckStr(hidOfVenta.Value)
                arrCabecera(48) = hidOrgVenta.Value
                arrCabecera(49) = canalSAP
                Dim strCabecera As String = Join(arrCabecera, ";")
                Dim result As Boolean
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio RealizarPedido(ELIM)")
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inp strCabecera: " & strCabecera)
                boolOK = obSAP.RealizarPedido(strCabecera, "", "", "", "", "", "", "", "", "", "", "", 0)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Out boolOK: " & boolOK)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin RealizarPedido")
            Else
                Dim aCadena(35) As String
                aCadena(0) = " "
                aCadena(1) = CheckStr(hidTipoDocVenta.Value)
                aCadena(5) = CheckStr(hidOfVenta.Value) 'Oficina de Ventas
                aCadena(7) = sDocSAP ' Numero Documento Sap

                Dim strCadenaDoc As String = String.Join(";", aCadena)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio Set_AnularDocumentoJob")
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inp strCadenaDoc: " & strCadenaDoc)
                Dim dsResult2 As DataSet = obSAP.Set_AnularDocumentoJob(CheckStr(strCadenaDoc), "")
                boolOK = True
                If dsResult2.Tables(1).Rows.Count > 0 Then
                    Dim drMsg As DataRow
                    For Each drMsg In dsResult2.Tables(1).Rows
                        If CheckStr(drMsg("TYPE")) = "E" Then
                            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out Msg:" & CheckStr((drMsg("Msg"))))
                            Throw New Exception(CheckStr(drMsg("TYPE")))
                            boolOK = False
                        End If
                    Next
                End If
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "boolOK:" & boolOK)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin Set_AnularDocumentoJob")
            End If
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR Anular_Boleta: " & ex.Message.ToString() & " " & ex.StackTrace.ToString())
            boolOK = False
        Finally
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin Anular_Boleta")
        End Try

        Return boolOK
    End Function


#End Region

End Class
