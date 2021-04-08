Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common 'PROY-24724-IDEA-28174
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario  'PROY-24724-IDEA-28174

Public Class sisact_ifr_consulta_reglas
    Inherits SisAct_WebBase 'PROY-24724-IDEA-28174

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidIdFila As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResultado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOficina As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMetodo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensaje As System.Web.UI.HtmlControls.HtmlInputHidden
    'PROY-24724-IDEA-28174 - INICIO
    Protected WithEvents hidflagProTMovil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEvalPM As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrima As System.Web.UI.HtmlControls.HtmlInputHidden     
    Protected WithEvents hidDeducible As System.Web.UI.HtmlControls.HtmlInputHidden 
    Protected WithEvents hidCertificadoPM As System.Web.UI.HtmlControls.HtmlInputHidden
    'PROY-24724-IDEA-28174 - FIN
    Protected WithEvents hidCoID As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim objLog As New SISACT_Log
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("sisact_ifr_consulta_regla")
    Dim strBRMS_PM As String = "NO" 'PROY-24724-IDEA-28174 -parametro
    Dim strTipoClientePM As String = String.Empty 'PROY-24724-IDEA-28174 


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Dim strIdFila As String = Request.QueryString("idFila")
        Dim nroDocumento As String = Request.QueryString("nroDocumento")
        Dim tipoDocumento As String = Request.QueryString("tipoDocumento")
        Dim strDatosGeneral As String = Request.QueryString("strCadenaDatos")
        Dim strPlanesDetalle As String = Request.QueryString("strCadenaPlan")
        Dim strEquiposDetalle As String = Request.QueryString("strCadenaEquipo")
        Dim strOficina As String = Request.QueryString("strOficina")
        Dim strRiesgo As String = Request.QueryString("strRiesgo")
        Dim strEssaludSunat As String = Request.QueryString("strEssaludSunat")
        Dim dblLC As Double = CheckDbl(Request.QueryString("dblLC"))
        Dim nroOperacion As String = Request.QueryString("nroOperacion")
        'gaa20170215
        Dim strBuroConsultado As String = Request.QueryString("strBuroConsultado")
        'fin gaa20170215
        Dim strMetodo As String = Request.QueryString("strMetodo")
        'Proy 29123 Venta en Cuotas
        Dim strDatos As String = Request.QueryString("strDatos")

        'PROY-24724-IDEA-28174 - INICIO
        Dim strFlagProTMovil As String = Request.QueryString("strFlagProTMovil")
        hidflagProTMovil.Value = strFlagProTMovil
        Dim cadenaEquiposDetalle As String = Request.QueryString("strCadenaEquipo")
        strTipoClientePM = Request.QueryString("strTipoCliente")
        'PROY-24724-IDEA-28174 - FIN

        hidTipoDocumento.Value = tipoDocumento
        hidNroDocumento.Value = nroDocumento
        hidOficina.Value = strOficina
        hidMetodo.Value = strMetodo

        hidCoID.Value = Request.QueryString("strCoID") 'SD1052592

        objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Ingreso a Page_Load(): sisact_ifr_consulta_reglas")
        objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strMetodo: " & Funciones.CheckStr(strMetodo))
       
        If (strMetodo = "Evaluar") Then

            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "VALOR DE EvaluarIngreso: " & Funciones.CheckStr(Session("EvaluarIngreso")))
            If Not CheckStr(Session("EvaluarIngreso")).Equals("2") Then
                'gaa20170215
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Ingreso a if EvaluarIngreso: " & Funciones.CheckStr(Session("EvaluarIngreso")))

                Evaluar(strDatosGeneral, strPlanesDetalle, "", strEquiposDetalle, strBuroConsultado)
                'fin gaa20170215
            End If

            If CheckStr(Session("EvaluarIngreso")).Equals("1") Then
                Session("EvaluarIngreso") = 2
            End If

            If Session("EvaluarIngreso") Is Nothing Then
                Session("EvaluarIngreso") = 1
            End If
        ElseIf (strMetodo = "EvaluarCuota") Then
            'gaa20170215
            'EvaluarCuota(strDatosGeneral, strPlanesDetalle, "", strEquiposDetalle)
            EvaluarCuota(strDatosGeneral, strPlanesDetalle, "", strEquiposDetalle, strBuroConsultado)
            'fin gaa20170215
        ElseIf (strMetodo = "CalcularLCDisponible") Then
            CalcularLCDisponible(nroOperacion, strRiesgo, strEssaludSunat, dblLC)
            'PROY-29123
        ElseIf (strMetodo = "EvaluarCliente") Then
            EvaluarCliente(nroDocumento, strBuroConsultado, tipoDocumento, strDatos)
        End If

    End Sub

    Private Sub CalcularLCDisponible(ByVal nroOperacion As String, ByVal strRiesgo As String, ByVal strEssaludSunat As String, ByVal dblLC As Double)
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim tipoDocumento As String = hidTipoDocumento.Value
        Try
            Dim objConsulta As New ReglaCrediticiaNegocio
            Dim objLCxProducto As New ArrayList
            Dim objLCDisponiblexProducto As New ArrayList

            Dim objCliente As ClienteCuenta = CType(Session("objCliente" & nroDocumento), ClienteCuenta)

            objConsulta.CalcularLCDisponible(objCliente, strRiesgo, strEssaludSunat, "N", dblLC, objLCxProducto, objLCDisponiblexProducto)

            objCliente.oLCBuroxBilletera = objLCxProducto
            objCliente.oLCDisponiblexBilletera = objLCDisponiblexProducto
            objCliente.nroOperacionBuro = nroOperacion

            Session("objCliente" & nroDocumento) = objCliente
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR.CalcularLCDisponible: " & ex.Message)
            hidMensaje.Value = ex.Message
        End Try
    End Sub

    Private Sub EvaluarCuota(ByVal strDatosGeneral As String, ByVal strPlanesDetalle As String, ByVal strServiciosDetalle As String, ByVal strEquiposDetalle As String, ByVal strBuroConsultado As String)
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim tipoDocumento As String = hidTipoDocumento.Value
        Dim flagProTMovil As String = hidflagProTMovil.Value  'PROY-24724-IDEA-28174  

        Try
            Dim objConsulta As New ReglaCrediticiaNegocio
            Dim arrCuota As New ArrayList
            Dim strCadena As String = String.Empty

            Dim objClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & nroDocumento), ClienteCuenta)
            Dim objCliente As ClienteCuenta = CType(Session("objCliente" & nroDocumento), ClienteCuenta)

            If (objCliente Is Nothing) Then
                objCliente = (New DatosClienteNegocio).ConsultarDatosCliente(tipoDocumento, nroDocumento, hidCoID.Value) 'SD1052592
            End If

            Dim objOfrecimiento As New Ofrecimiento
            'gaa20170215
            objCliente.buroConsultado = strBuroConsultado
            'fin gaa20170215
            Session("objCliente" & nroDocumento) = objCliente

            objCliente.planActual = CheckStr(objClienteCta.planActual)
            objCliente.planActualCF = objClienteCta.planActualCF
            objCliente.oficina = hidOficina.Value
            'MAF INI - MRAF
            Dim objGestionAcuerdo As BEGestionAcuerdoWS = CType(Session("GestionAcuerdoWS"), BEGestionAcuerdoWS)
            Dim intMeses As Int32 = 0
            Dim datFechaActiva As DateTime
            datFechaActiva = DateTime.Parse(objGestionAcuerdo.acuerdoFechaInicio)
            intMeses = (DateTime.Now.Subtract(datFechaActiva).Days \ 30)
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & " LA FECHA DE ACTIVACION ES: " & datFechaActiva)
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & " EL NUMERO DE MESES ES:  " & intMeses)
            'gaa20161115
            'objCliente.tiempoPermanencia = intMeses
            objCliente.tiempoPermanenciaContratoMeses = intMeses
            'fin gaa20161115
            'MAF FIN
            'PROY-24724-IDEA-28174 - INICIO
            Dim strMontoPrima As String = String.Empty
            Dim strDeducible As String = String.Empty
            Dim strFlagEvalPM As String = String.Empty
            Dim strCertificado As String = String.Empty
            Dim strDatosAdicionales As String = String.Empty

            If (flagProTMovil = "PM") Then
                objLog.Log_WriteLog(strArchivo, "flagProTMovil = PM")
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & ">>>>>>>>> INICIO ValidarProteccionMovil() <<<<<<<<<<<<")
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Inp. Nro. Docuemtno : " & nroDocumento)
                ValidarProteccionMovil(strEquiposDetalle, nroDocumento, strMontoPrima, strDeducible, strFlagEvalPM, strCertificado, strDatosAdicionales)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out.     Monto Prima : " & strMontoPrima)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out.       Deducible : " & strDeducible)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out.  N. Certificado : " & strCertificado)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out. Flag. Eval. PM. : " & strFlagEvalPM)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out. strDatosAdicionales. : " & strDatosAdicionales)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & ">>>>>>>>> Final ValidarProteccionMovil() <<<<<<<<<<<<")

                If (strFlagEvalPM = "1") Then
                    Dim strEquiposDetalleRpta As String = String.Empty
                    DesgloseNuevoValorBRMS(strPlanesDetalle, strMontoPrima, strEquiposDetalleRpta)
                    strPlanesDetalle = strEquiposDetalleRpta
                    strBRMS_PM = "SI" 'PROY-24724-IDEA-28174- parametro
                End If
            End If
            'PROY-24724-IDEA-28174 - FIN

            arrCuota = objConsulta.EvaluarCuota(objCliente, Nothing, strDatosGeneral, strPlanesDetalle, strServiciosDetalle, strEquiposDetalle, strBRMS_PM, objOfrecimiento) 'PROY-24724-IDEA-28174 - se agregó nuevo parametro (strBRMS_PM)

            'PROY-29123 VENTA EN CUOTAS INICIO
            Dim maxCuotas As String = ""
            Dim maxMonto As String = ""
            Dim msjBRMS As String = ""

            For Each obj As Cuota In arrCuota
                strCadena &= "|" & obj.idCuota & "_" & obj.porcenCuotaInicial
                strCadena &= ";" & obj.cuota

                maxCuotas = "^" & obj.MaximoCuotas
                maxMonto = "^" & obj.PrecioEquipoMaximo
                msjBRMS = "^" & obj.MensajeBRMS
            Next

            If (objOfrecimiento.MensajeBRMS <> "") Then
                maxCuotas = "^" & objOfrecimiento.MaximoCuotas
                maxMonto = "^" & objOfrecimiento.PrecioEquipoMaximo
                msjBRMS = "^" & objOfrecimiento.MensajeBRMS
            End If
            'PROY-29123 VENTA EN CUOTAS FIN

            'PROY-24724-IDEA-28174 - INICIO      
            If (flagProTMovil = "PM") Then
            strCadena &= "*" & strMontoPrima & "*"
            strCadena &= strDeducible & "*"
            strCadena &= strFlagEvalPM & "*"
            strCadena &= strCertificado & "*"
            strCadena &= strDatosAdicionales
            End If
            'PROY-24724-IDEA-28174 - FIN
            hidResultado.Value = strCadena & maxCuotas & maxMonto & msjBRMS  'PROY-29123
        Catch ex As Exception
            hidResultado.Value = ""
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR.EvaluarCuota: " & ex.Message)
            hidMensaje.Value = ex.Message
        End Try

    End Sub

    'PROY-29123 VENTA EN CUOTAS INICIO
    Private Sub EvaluarCliente(ByVal strNroDocumento As String, ByVal strBuroConsultado As String, ByVal strTipoDocumento As String, ByVal strDatos As String)

        Try
            Dim objConsulta As New ReglaCrediticiaNegocio
            Dim arrCuota As New ArrayList
            Dim strCadena As String = String.Empty
            Dim objOfrecimiento As Ofrecimiento

            Dim objClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & strNroDocumento), ClienteCuenta)
            Dim objCliente As ClienteCuenta = CType(Session("objCliente" & strNroDocumento), ClienteCuenta)

            If (objCliente Is Nothing) Then
                objCliente = (New DatosClienteNegocio).ConsultarDatosCliente(strTipoDocumento, strNroDocumento, hidCoID.Value) 'SD1052592
            End If

            objCliente.planActual = CheckStr(objClienteCta.planActual)
            objCliente.planActualCF = objClienteCta.planActualCF
            objCliente.oficina = hidOficina.Value
            objCliente.nroOperacionBuro = strBuroConsultado

            'Dim strMontoPrima As String = String.Empty
            'Dim strDeducible As String = String.Empty
            'Dim strFlagEvalPM As String = String.Empty
            'Dim strCertificado As String = String.Empty
            'Dim strDatosAdicionales As String = String.Empty


            objOfrecimiento = objConsulta.EvaluarCliente(objCliente, Nothing, strDatos)

            strCadena &= objOfrecimiento.MaximoCuotas
            strCadena &= ";"
            strCadena &= objOfrecimiento.PrecioEquipoMaximo
            strCadena &= ";"
            strCadena &= objOfrecimiento.MensajeBRMS

            hidResultado.Value = strCadena
        Catch ex As Exception
            hidResultado.Value = ""
            objLog.Log_WriteLog(strArchivo, strNroDocumento & " - " & "ERROR.EvaluarCliente: " & ex.Message)
            hidMensaje.Value = ex.Message
        End Try

    End Sub
    'PROY-29123 VENTA EN CUOTAS FIN
    Private Sub Evaluar(ByVal strDatosGeneral As String, ByVal strPlanesDetalle As String, ByVal strServiciosDetalle As String, ByVal strEquiposDetalle As String, ByVal strBuroConsultado As String)
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim tipoDocumento As String = hidTipoDocumento.Value
Dim flagProTMovil As String = hidflagProTMovil.Value  'PROY-24724-IDEA-28174  
        objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Nro Documento: " & nroDocumento)
        objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Tipo Documento: " & tipoDocumento)
        Dim strCoID As String = hidCoID.Value
        Try
            Dim objConsulta As New ReglaCrediticiaNegocio
            Dim strCadena As String = String.Empty
            Dim objVista As New VistaEvaluacion
            Dim strResultado As String = String.Empty
            Dim objOfrecimiento As New Ofrecimiento
            Dim objGarantia As New Garantia

            Dim objClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & nroDocumento), ClienteCuenta)
            Dim objCliente As ClienteCuenta = CType(Session("objCliente" & nroDocumento), ClienteCuenta)

            If (objCliente Is Nothing) Then
                objCliente = (New DatosClienteNegocio).ConsultarDatosCliente(tipoDocumento, nroDocumento, hidCoID.Value) 'SD1052592
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "objCliente Lleno")
            Else
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "objCliente Null")
            End If
            'Inicio DBE   - MRAF
            'gaa20161115
            Dim objPermanecia() As String = Convert.ToString(Session("GestionAcuerdoReno")).Split(CChar("|"))
            'fin gaa20161115
            'gaa20170215
            objCliente.buroConsultado = strBuroConsultado
            'fin gaa20170215
            Session("objCliente" & nroDocumento) = objCliente

            objCliente.planActual = objClienteCta.planActual
            objCliente.planActualCF = (New ConsumerNegocio).ConsultarCargoFijo(strCoID) 'SD1052592
            objCliente.oficina = hidOficina.Value
'gaa20161115
            objLog.Log_WriteLog(strArchivo, nroDocumento & " ----Inicio Input BRMS--- " & "objPermanecia: " & Convert.ToString(Session("GestionAcuerdoReno")))
            If objPermanecia(0) <> "" Then
                '    objCliente.tiempoPermanencia = Convert.ToInt32(objPermanecia(0))
                strDatosGeneral = strDatosGeneral & "|" & objPermanecia(1) & "|" & objPermanecia(2)
                'Else
                '    objCliente.tiempoPermanencia = 0
            End If

            'Session("GestionAcuerdoReno") = ""
            'fin gaa20161115
            'Fin DBE

            'gaa20161115
            objLog.Log_WriteLog(strArchivo, nroDocumento & " ----Inicio Input BRMS--- " & "TiempoPermanencia: " & objCliente.tiempoPermanencia & ", strDatosGeneral: " & strDatosGeneral)
            'fin gaa20161115
            'MRAF INI
            Dim objGestionAcuerdo As BEGestionAcuerdoWS = CType(Session("GestionAcuerdoWS"), BEGestionAcuerdoWS)
            Dim intMeses As Int32 = 0
            Dim datFechaActiva As DateTime
            datFechaActiva = DateTime.Parse(objGestionAcuerdo.acuerdoFechaInicio)
            intMeses = (DateTime.Now.Subtract(datFechaActiva).Days \ 30)
            'gaa20161115
            'objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & " LA FECHA DE ACTIVACION ES: " & datFechaActiva)
            'objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & " EL NUMERO DE MESES ES:  " & intMeses)
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & " LA FECHA DE ACTIVACION ES: " & datFechaActiva)
            objLog.Log_WriteLog(strArchivo, nroDocumento & " ----Inicio Input BRMS--- " & "TiempoPermanenciaContrato: " & intMeses)
            'fin gaa20161115
            'gaa20161115
            'objCliente.tiempoPermanencia = intMeses
            objCliente.tiempoPermanenciaContratoMeses = intMeses
            'fin gaa20161115
            'MRAF FIN
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Plan Actual: " & objCliente.planActual)
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Plan Actual CF: " & objCliente.planActualCF)
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Oficina: " & objCliente.oficina)

            'PROY-24724-IDEA-28174 - INICIO
            Dim strMontoPrima As String = String.Empty
            Dim strDeducible As String = String.Empty
            Dim strFlagEvalPM As String = String.Empty
            Dim strCertificado As String = String.Empty
            Dim strDatosAdicionales As String = String.Empty

            If (flagProTMovil = "PM") Then


                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & ">>>>>>>>> INICIO ValidarProteccionMovil() <<<<<<<<<<<<")
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> flagProTMovil : " & flagProTMovil)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Inp. Nro. Docuemtno : " & nroDocumento)

                ValidarProteccionMovil(strEquiposDetalle, nroDocumento, strMontoPrima, strDeducible, strFlagEvalPM, strCertificado, strDatosAdicionales)

                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out.     Monto Prima : " & strMontoPrima)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out.       Deducible : " & strDeducible)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out.  N. Certificado : " & strCertificado)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out. Flag. Eval. PM. : " & strFlagEvalPM)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "    >> Out. strDatosAdicionales. : " & strDatosAdicionales)
                objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & ">>>>>>>>> Fin ValidarProteccionMovil() <<<<<<<<<<<<")

                If (strFlagEvalPM = "1") Then
                    Dim strEquiposDetalleRpta As String = String.Empty
                    DesgloseNuevoValorBRMS(strPlanesDetalle, strMontoPrima, strEquiposDetalleRpta)

                    strPlanesDetalle = strEquiposDetalleRpta
                    strBRMS_PM = "SI" 'PROY-24724-IDEA-28174 - parametro
                End If

            End If
            'PROY-24724-IDEA-28174 - FIN

            objVista = objConsulta.Evaluar(objCliente, Nothing, strDatosGeneral, strPlanesDetalle, strServiciosDetalle, strEquiposDetalle, strBRMS_PM) 'PROY-24724-IDEA-28174 -  se agregó nuevo parametro (strBRMS_PM)

            objOfrecimiento = CType(objVista.oOfrecimiento(0), Ofrecimiento)
            objGarantia = CType(objVista.oGarantia(0), Garantia)

            strResultado &= objVista.planAutonomia & "_"
            strResultado &= String.Format("{0};{1};{2};{3};{4};{5};{6}", objGarantia.idGarantia, objGarantia.garantia, objGarantia.nroGarantia, objGarantia.importe.ToString(), objGarantia.idProducto, objGarantia.producto, objGarantia.CF) & "_"
            strResultado &= objVista.importeGarantia.ToString() & "_"
            strResultado &= objOfrecimiento.ResultadoAutonomia & "_"
            strResultado &= objVista.rangoLCDisponible & "_"
            strResultado &= objOfrecimiento.RiesgoEnClaro & "_"
            strResultado &= objOfrecimiento.ComportamientoConsolidado.ToString() & "_"
            strResultado &= objOfrecimiento.FactorDeRenovacionCliente.ToString() & "_"
            strResultado &= objVista.LCDisponible & "_"
'PROY-24724-IDEA-28174 - INICIO         
            strResultado &= "=" & strMontoPrima & "_"
            strResultado &= strDeducible & "_"
            strResultado &= strFlagEvalPM & "_"
            strResultado &= strCertificado & "_"
            strResultado &= strDatosAdicionales
            'PROY-24724-IDEA-28174 - FIN
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Resultado Evaluar: " & strResultado)
            'Session Ofrecimiento
            Session("oClienteOfrecimiento" & nroDocumento) = objVista.oOfrecimiento

            hidResultado.Value = strResultado
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR.Evaluar: " & ex.Message)
            hidMensaje.Value = ex.Message
        End Try

    End Sub
    'PROY-24724-IDEA-28174 - INICIO 
    Private Sub ValidarProteccionMovil(ByVal strEquiposDetalle As String, ByVal strNumDocumento As String, ByRef strMontoPrima As String, ByRef strDeducible As String, ByRef strFlagEvalPM As String, ByRef strCertificado As String, ByRef strDatosAdicionales As String)


        Dim objClienteConsultaPrima As New BWClienteProteccionMovil
        Dim BLProteccionMovil As New BLProteccionMovil
        Dim Blconsulta As New Blconsulta
        Dim oBEItemMensaje As New BEItemMensaje
        Dim objBWCliente As New BWClienteProteccionMovil

        'Hidden Limpios
        hidDeducible.Value = String.Empty
        hidPrima.Value = String.Empty
        hidflagProTMovil.Value = String.Empty

        ''Consulta Lista Prepago
        Dim strCodListaPrecioPrepago As Integer = CheckInt(ClsKeyAPP.strCodListaPrecioPrepagoMes) ''PROY-24724-IDEA-28174 - Parametro
        Dim strCodMaterial As String = String.Empty
        Dim arrPlanEquipo As String() = strEquiposDetalle.Split(CChar("|"))
        strCodMaterial = Funciones.CheckStr((arrPlanEquipo(0).Split(CChar(";")))(2)).Trim()
        Dim dblPrecioPrepago As Double
        Dim strMsjConsultaLPrecio As String = String.Empty
        Dim dblPrecioPrepagoMinimo As Double = Funciones.CheckDbl(ClsKeyAPP.strCodPrecioPrepagoMinimo) 'PROY-24724-IDEA-28174 - Parametro

        'Consulta Asurión
        Dim objAudit As New BEItemGenerico
        Dim strTipoDocumento As String = CheckStr(hidTipoDocumento.Value)
        Dim strNroDocumento As String = CheckStr(hidNroDocumento.Value)
        Dim strTipoCliente As String = strTipoClientePM
        Dim strCodRpta As String = String.Empty
        Dim strMsjRpta As String = String.Empty
        Dim strNombPro As String = String.Empty
        Dim strDescPro As String = String.Empty
        Dim strIncTipoDanio As String = String.Empty
        Dim strIncTipoRobo As String = String.Empty

        'Validaciones Rptas Asurión
        Dim strRptAsurion As String
        Dim strDeducibleDesglose() As String

        ''Correo contingencia
        Dim bolErrorConsulta As Boolean = False
        Dim strMetodo As String = "consultarPrima()"
        Dim oBEItemMsjCorreo As New BEItemMensaje
        Dim strFlagCorreo As String = "CP"


        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & ">>>>>> INICIO ConsultarPrecioListaPrepago() <<<<<<<<<<")
        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Inp            Cod. Material: " & strCodMaterial)
        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Inp Cod. List.Precio Prepago: " & strCodListaPrecioPrepago)

        Blconsulta.ConsultarPrecioListaPrepago(strCodMaterial, strCodListaPrecioPrepago, dblPrecioPrepago, strMsjConsultaLPrecio)

        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Out   Precio Prepago: " & dblPrecioPrepago)
        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Out          Mensaje: " & strMsjConsultaLPrecio)
        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & ">>>>>> FIN ConsultarPrecioListaPrepago() <<<<<<<<<<")

        If (dblPrecioPrepago >= dblPrecioPrepagoMinimo) Then
            Try
                objAudit.Codigo = strNumDocumento + String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)
                objAudit.Codigo2 = Funciones.CheckStr(CurrentUser)
                objAudit.Codigo3 = Funciones.CheckStr(ConfigurationSettings.AppSettings("CodigoAplicacion"))
                objAudit.Descripcion = Funciones.CheckStr(ConfigurationSettings.AppSettings("constAplicacion"))
                objAudit.Descripcion2 = Funciones.CheckStr(CurrentTerminal)
                'PROY-24724-IDEA-28174 - Parametros -INI 
                If (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteMasivo)) Then
                    strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteMasivo)
                ElseIf (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteB2E)) Then
                    strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteB2E)
                ElseIf (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteBusiness)) Then 
                    strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteBusiness)
                End If
                'PROY-24724-IDEA-28174 - Parametros -FIN

                'strCodMaterial = strCodMaterial.TrimStart(Convert.ToChar("0"))

                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & ">>>>>>>>>>>>>> INICIO ConsultarPrima() <<<<<<<<<<<<<<<")
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Inp  Cod Material: " & strCodMaterial)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Inp  Tipo Cliente: " & strTipoCliente)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Inp     Tipo Doc.: " & strTipoDocumento)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Inp      Nro Doc.: " & strNroDocumento)


                oBEItemMensaje = objBWCliente.ConsultarPrima(strCodMaterial, strTipoCliente, strTipoDocumento, strNroDocumento, objAudit, strCodRpta, strMsjRpta, strMontoPrima, strDeducible, strCertificado, _
                                                      strNombPro, strDescPro, strIncTipoDanio, strIncTipoRobo)

                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Out     Cod Rpta : " & strCodRpta)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Out     Msj Rpta : " & strMsjRpta)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Out  Monto Prima : " & strMontoPrima)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Out    Deducible : " & strDeducible)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Out  Certificado : " & strCertificado)
                objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & ">>>>>>>>>>>>>> F I N ConsultarPrima() <<<<<<<<<<<<<<<")

                If strCodRpta = "0" Then
                    strRptAsurion = "SC"    ' Si califica
                    strFlagEvalPM = "1"
                    hidDeducible.Value = strDeducible
                    hidPrima.Value = strMontoPrima
                    hidEvalPM.Value = strFlagEvalPM
                    hidCertificadoPM.Value = strCertificado
                    strDatosAdicionales = strNombPro + "|" + strDescPro + "|" + strIncTipoDanio + "|" + strIncTipoRobo
                ElseIf strCodRpta = "2" Then
                    strRptAsurion = "NC" 'No califica cobertura
                    strFlagEvalPM = "2" 'EL equipo no califica para la cobertura      
                Else
                    strRptAsurion = "ES"
                    strFlagEvalPM = "3" 'no respondio asurion
                    bolErrorConsulta = True
                    strCodRpta = "-2"
                    strRptAsurion = "Sin Servicio de ClienteProteccionMovil"
                End If
                '"SC=Si califica" 
                'Si califica(SC) - No califica(NC) - Error de Servicio(ES) - ND=No Disponibilidad

            Catch ex As Exception
                strMsjRpta = ex.Message.ToString()
                strCodRpta = "99"
                strRptAsurion = "ND"
                bolErrorConsulta = True
                strFlagEvalPM = "3" 'no respondio asurion
            Finally
                If bolErrorConsulta Then
                    Try
                        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >>  INICIO EnviarCorreoContingencia()<< ")
                        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> URL WS" & Funciones.CheckStr(ConfigurationSettings.AppSettings("consClienteProteccionMovilWS_Error")))
                        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Metodo de la aplicación:" & strMetodo)
                        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Codigo Rpta:" & strCodRpta)
                        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Mensaje Rpta:" & strMsjRpta)
                oBEItemMsjCorreo = BLProteccionMovil.EnviarCorreoContingencia(strMetodo, strCodRpta, strMsjRpta, objAudit, strFlagCorreo)
                        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >>  FIN EnviarCorreoContingencia()<< ")
                    Catch ex As Exception
                        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Error Mensaje EX:" & ex.Message.ToString)
                    End Try
                End If
            End Try
        Else
            strFlagEvalPM = "4"  'Monto de Equipo inferior a S/150.00
        End If

        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "strRptAsurion: " & strRptAsurion)
        objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "strFlagEvalPM: " & strFlagEvalPM)

        If oBEItemMsjCorreo.exito = False Then
            objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> INI Error en envío de correo <>")
            objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Cod: " & oBEItemMsjCorreo.codigo)
            objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Msj: " & oBEItemMsjCorreo.descripcion)
            objLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> FIN Error en envío de correo <>")
        End If

    End Sub

    Private Sub DesgloseNuevoValorBRMS(ByVal strEquiposDetalle As String, ByVal strMontoPrima As String, ByRef strEquiposDetalleRpta As String)

        objLog.Log_WriteLog(strArchivo, "INICIO DesloseServicioContratados()")
        objLog.Log_WriteLog(strArchivo, "Inp Detalle Equipo.: " & strEquiposDetalle)
        objLog.Log_WriteLog(strArchivo, "Inp     Monto Prima: " & strMontoPrima)

        Dim arrEquipoDetalle As String() = strEquiposDetalle.Split(CChar(";"))
        Dim arrEquipoDet As String() = arrEquipoDetalle(10).Split(CChar("|"))
        Dim strCostoFijo As String = arrEquipoDet(0)
        Dim DblDetalleConPrima As Double = Funciones.CheckDbl(strCostoFijo) + Funciones.CheckDbl(strMontoPrima)
        Dim StrMontoConPrima As String = Funciones.CheckStr(DblDetalleConPrima)
        'gaa20170529
        Dim dblMontoConPrimaAcu As Double = Funciones.CheckDbl(arrEquipoDetalle(11)) + Funciones.CheckDbl(strMontoPrima)
        Dim StrMontoConPrimaAcu As String = Funciones.CheckStr(dblMontoConPrimaAcu)
        'fin gaa20170529
        'volver  a unir a la cadena
		'gaa20170529
        strEquiposDetalleRpta = arrEquipoDetalle(0) + ";" + arrEquipoDetalle(1) + ";" + arrEquipoDetalle(2) + ";" + arrEquipoDetalle(3) + ";" + arrEquipoDetalle(4) + ";" + arrEquipoDetalle(5) + ";" + arrEquipoDetalle(6) + ";" + arrEquipoDetalle(7) + ";" + arrEquipoDetalle(8) + ";" + arrEquipoDetalle(9) + ";" + StrMontoConPrima + ";" + StrMontoConPrimaAcu + ";" + arrEquipoDetalle(12) + "|"
        'fin gaa20170529
        'strEquiposDetalleRpta = arrEquipoDetalle(0) + ";" + arrEquipoDetalle(1) + ";" + arrEquipoDetalle(2) + ";" + arrEquipoDetalle(3) + ";" + arrEquipoDetalle(4) + ";" + arrEquipoDetalle(5) + ";" + arrEquipoDetalle(6) + ";" + arrEquipoDetalle(7) + ";" + arrEquipoDetalle(8) + ";" + arrEquipoDetalle(9) + ";" + StrMontoConPrima + "|"
        objLog.Log_WriteLog(strArchivo, "Out    Monto Total: " & StrMontoConPrima)
        objLog.Log_WriteLog(strArchivo, "Out Detalle Equipo: " & strEquiposDetalleRpta)
        objLog.Log_WriteLog(strArchivo, "FIN DesgloseNuevoValorBRMS()")
    End Sub    'PROY-24724-IDEA-28174 - FIN 
End Class
