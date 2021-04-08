Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text.RegularExpressions
Public Class sisact_ifr_resultado_evaluacion
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaParam As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensaje As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOficina As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClaseCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOferta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRiesgo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEdad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidScore As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCasoEspecial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroRRLL As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hiCadenaDrools As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanesActivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanAutonomia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLCDisponible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGarantiaxProducto As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMetodo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLCDisponiblexProd As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidImporte As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPoderes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGrupoCadena As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResultado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFacRenovacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidComporPago As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTextoLCDisponible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRiesgoClaro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidComportaConsolidado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidComportaClaroC1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFactorRenovacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMontoRegistrado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMSJMontoRegistrado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRespuestaMontoR As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPermanencia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlazoAcuerdoBRMS As System.Web.UI.HtmlControls.HtmlInputHidden


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
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_ifr_resultado_evaluacion")
    Dim strArchivo2 As String = oLog.Log_CrearNombreArchivo("sisactresuleval")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        'FORMATO {0|1}: Codigo|Descipción
        hidTipoDoc.Value = Request.QueryString("strTipoDoc")
        hidCanal.Value = Request.QueryString("strCanal")
        hidOferta.Value = Request.QueryString("strOferta")
        hidRiesgo.Value = Request.QueryString("strRiesgo")
        hidOficina.Value = Request.QueryString("strOficina")
        hidCasoEspecial.Value = Request.QueryString("strCasoEspecial")
        '--------------------------------------------------------------
        hidNroDocumento.Value = Request.QueryString("strNroDocumento")
        hidClaseCliente.Value = Request.QueryString("strClaseCliente")
        hidEdad.Value = Request.QueryString("strEdad")
        hidScore.Value = Request.QueryString("strScore")
        hidNroRRLL.Value = Request.QueryString("strNroRRLL")
        hidPlanesActivos.Value = Request.QueryString("strPlanesActivos")
        hidNroPlanes.Value = Request.QueryString("strNroPlanes")
        hidGrupoCadena.Value = Request.QueryString("strGrupoCadena")
        hidTipoOperacion.Value = Request.QueryString("strTipoOperacion")
        hidComporPago.Value = Request.QueryString("strComporPago")
        hidFacRenovacion.Value = Request.QueryString("strFactorRenov")

        Dim strMetodo As String = Request.QueryString("strMetodo")
        Dim strCodRiesgo As String = Request.QueryString("strRiesgo")
        Dim strCodTipoDoc As String = Request.QueryString("strTipoDoc")
        Dim strEssaludSunat As String = Request.QueryString("strEssaludSunat")
        Dim strClienteNuevo As String = Request.QueryString("strClienteNuevo")
        Dim dblLC As String = Request.QueryString("dblLC")

        hidTipoDoc.Value = Request.QueryString("tipoDoc")
        hidNroDocumento.Value = Request.QueryString("nroDoc")
        hidOferta.Value = Request.QueryString("oferta")
        hidOficina.Value = Request.QueryString("pdv")
        hidRiesgo.Value = Request.QueryString("riesgo")
        hidCasoEspecial.Value = Request.QueryString("ce")
        hidNroRRLL.Value = Request.QueryString("nroRRLL")
        hidNroPlanes.Value = Request.QueryString("strNroPlanes")
        hidTipoOperacion.Value = Request.QueryString("tipoOperacion")
        hidMetodo.Value = Request.QueryString("strMetodo")

        'INICIO WHZR 29092014

        hidMontoRegistrado.Value = Request.QueryString("strMontoRegistrado")
        'FIN WHZR 29092014

        'INICIO WHZR 04112014
        hidPermanencia.Value = Request.QueryString("strPermanencia")
        hidPlazoAcuerdoBRMS.Value = Request.QueryString("strPlazoAcuerdo")
        'FIN WHZR 04112014

        Try
            hiCadenaDrools.Value = Request.QueryString("strCadenaDrools")
            hiCadenaDrools.Value = CheckStr(hiCadenaDrools.Value).Replace("*", "+")
            hidMetodo.Value = strMetodo
            Select Case strMetodo
                Case "CalcularLCDisponible"
                    CalcularLCDisponible(strCodRiesgo, strCodTipoDoc, strEssaludSunat, strClienteNuevo, dblLC)
                Case "Evaluar"
                    ObtenerParametros()
                    Evaluar()
            End Select
        Catch ex As Exception
            hidMensaje.Value = ConfigurationSettings.AppSettings("constMsjErrorEvaluacion")
            hidNroDocumento.Value = Session("strNroDocumento")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR METODO " & strMetodo & ": " & ex.Message)
        End Try

    End Sub

#Region "Evaluación"

    Private Sub CalcularLCDisponible(ByVal strCodRiesgo As String, _
                                            ByVal strCodTipoDoc As String, _
                                            ByVal strEssaludSunat As String, _
                                            ByVal strClienteNuevo As String, _
                                            ByVal dblLC As String)

        Dim oReglas As New ReglasEvaluacionNegocio
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim arrCuentaMonto As ArrayList
        Dim strCuentaMontoFact As String = String.Empty
        Dim strCuentaMontoNoFact As String = String.Empty
        Try
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "========== INICIO LC DISPONIBLE ====================")

            Dim oClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & nroDocumento), ClienteCuenta)
            If Session("oClienteCuenta" & nroDocumento) Is Nothing Then
                oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "PERDIDA SESION CLIENTE")
            End If
            If oClienteCta.nroDoc = nroDocumento Then
                arrCuentaMonto = oClienteCta.montoCuenta
                For Each item As PlanBilletera In arrCuentaMonto
                    If item.MontoFacturado > 0 Then
                        strCuentaMontoFact = String.Format("{0}|{1};{2}", strCuentaMontoFact, item.CodigoBilletera, item.MontoFacturado)
                    End If
                    If item.MontoNoFacturado > 0 Then
                        strCuentaMontoNoFact = String.Format("{0}|{1};{2}", strCuentaMontoNoFact, item.CodigoBilletera, item.MontoNoFacturado)
                    End If
                Next
            End If

            Dim strInput As String = String.Format("{0}|{1}|{2}|{3}|{4}", strCodRiesgo, strCodTipoDoc, strEssaludSunat, strClienteNuevo, dblLC)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Input  --> LC x Producto  : " & strInput)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Input  --> Monto Facturado    : " & strCuentaMontoFact)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Input  --> Monto No Facturado : " & strCuentaMontoNoFact)

            'Calcular LC x Producto
            Dim arrLCxProducto As ArrayList = oReglas.ObtenerLCxProducto(strCodRiesgo, strCodTipoDoc, strEssaludSunat, strClienteNuevo, dblLC)
            'Calcular Prom Factura x Producto
            Dim arrFactxProducto As ArrayList = oReglas.ObtenerFactxProducto(strCuentaMontoFact)
            'Calcular Prom NO Factura x Producto
            Dim arrNoFactxProducto As ArrayList = oReglas.ObtenerFactxProducto(strCuentaMontoNoFact)
            'Calcular LC Disponible x Producto
            Dim arrLCDispxProducto As ArrayList = CalcularLCDispxProducto(arrLCxProducto, arrFactxProducto, arrNoFactxProducto)

            'Sesión Cliente
            oClienteCta.LCxProducto = arrLCxProducto
            oClienteCta.FacturaxProducto = arrFactxProducto
            oClienteCta.NoFacturaxProducto = arrNoFactxProducto
            oClienteCta.LCDispxProducto = arrLCDispxProducto
            Session("oClienteCuenta" & nroDocumento) = oClienteCta

            Dim strLCxProd As String
            For Each item As ItemGenerico In arrLCxProducto
                strLCxProd = String.Format("{0}|{1};{2}", strLCxProd, item.Codigo, item.Valor)
            Next
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> LC x Producto		 : " & strLCxProd)

            Dim strFactxProd As String
            For Each item As ItemGenerico In arrFactxProducto
                strFactxProd = String.Format("{0}|{1};{2}", strFactxProd, item.Codigo, item.Valor)
            Next
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> Fact x Producto    : " & strFactxProd)

            Dim strNoFactxProd As String
            For Each item As ItemGenerico In arrNoFactxProducto
                strNoFactxProd = String.Format("{0}|{1};{2}", strNoFactxProd, item.Codigo, item.Valor)
            Next
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> No Fact x Producto : " & strNoFactxProd)

            Dim strLCDispxProd As String
            For Each item As ItemGenerico In arrLCDispxProducto
                strLCDispxProd = String.Format("{0}|{1};{2}", strLCDispxProd, item.Codigo, item.Valor)
            Next
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> LC Disp x Producto : " & strLCDispxProd)

            hidLCDisponiblexProd.Value = strLCDispxProd

        Finally
            oReglas = Nothing
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "========== FIN LC DISPONIBLE =======================")
        End Try

    End Sub

    Public Sub Evaluar2()

        Dim strMensaje As String
        Dim dblTotalCF As Double
        Dim strTipoGarantia As String
        Dim strCodTipoGarantia As String
        Dim dblMontoImporte As Double = 0
        Dim dblNroGarantia As Double = 0
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim nroPlanes As Integer
        Dim strRiesgo As String = hidRiesgo.Value.Split("|")(0)
        Dim blnOKConsulta As Boolean = False
        Dim arrReglaOUT As New ArrayList
        Dim dblLCDisponible As Double
        Dim strGarantiaxProducto As String
        Dim strGrupoCadena As String = CheckStr(hidGrupoCadena.Value)

        Try
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "========== INICIO EVALUACION =======================")

            'MATRIZ REGLAS CREDITOS
            Dim oReglaOUT As New MatrizReglasOUT
            Dim arrDataRegla As ArrayList = ObtenerDatosReglas(dblLCDisponible)

            For Each oReglaIN As MatrizReglasIN In arrDataRegla

                'DTH + BAM [CF PROMOCIONAL]
                If oReglaIN.Producto = ConfigurationSettings.AppSettings("consTipoProductoDTH") Then
                    Dim CFPromocional As Double = CheckDbl((New ConsumerNegocio).getCFPromocional(oReglaIN.CodCampania))
                    oReglaIN.CargoFijo = oReglaIN.CargoFijo + CFPromocional
                End If

                Dim blnGrupoPlan As Boolean = (oReglaIN.GrupoPlanTarifario <> "")
                If Not strGrupoCadena = "" Then
                    oReglaIN.Pdv = strGrupoCadena
                    blnOKConsulta = ConsultarReglas(oReglaIN, oReglaOUT, strMensaje)
                    If Not blnOKConsulta Then
                        If blnGrupoPlan Then
                            oReglaIN.Plan = oReglaIN.GrupoPlanTarifario
                            blnOKConsulta = ConsultarReglas(oReglaIN, oReglaOUT, strMensaje)
                        End If
                    End If
                Else
                    blnOKConsulta = ConsultarReglas(oReglaIN, oReglaOUT, strMensaje)
                    If Not blnOKConsulta Then
                        If blnGrupoPlan Then
                            oReglaIN.Plan = oReglaIN.GrupoPlanTarifario
                            blnOKConsulta = ConsultarReglas(oReglaIN, oReglaOUT, strMensaje)
                        End If
                    End If
                End If

                'DATOS RETORNO
                oReglaOUT.Orden = oReglaIN.Orden
                oReglaOUT.Producto = oReglaIN.Producto
                oReglaOUT.CargoFijo = oReglaIN.CargoFijo
                oReglaOUT.CargoFijoEval = oReglaIN.CargoFijoEval 'CF Evaluación

                'AUTONOMIA
                If blnOKConsulta Then
                    If Not CheckStr(oReglaOUT.Restriccion) = "NO" Then
                        oReglaOUT.Autonomia = "NO_CONDICION"
                    ElseIf oReglaOUT.respuestaRenovacion = ConfigurationSettings.AppSettings("constTextoRequiereEvaluacion").ToUpper Then
                        oReglaOUT.Autonomia = "N"
                    Else
                        oReglaOUT.Autonomia = "S"
                    End If
                Else
                    oReglaOUT.Autonomia = "SIN_REGLAS" 'SIN_REGLAS O EXCEPCIÓN CONSULTA DROOLS
                End If

                arrReglaOUT.Add(oReglaOUT)
            Next

            Dim blnProdEvaluado As Boolean
            Dim arrListaProducto As ArrayList = (New ConsumerNegocio).ListarProducto()
            Dim listaTipoGarantia As ArrayList = (New ConsumerNegocio).ListarTipoGarantia("", "1")

            Dim dblImporte As Double
            For Each item As ItemGenerico In arrListaProducto
                dblTotalCF = 0.0
                dblNroGarantia = 1
                dblImporte = 0.0
                strTipoGarantia = ""
                blnProdEvaluado = False
                strCodTipoGarantia = ConfigurationSettings.AppSettings("constCodTipoGarantiaRA")

                For Each itemDetalle As MatrizReglasOUT In arrReglaOUT
                    If item.Codigo = itemDetalle.Producto Then
                        'MONTO GARANTIA
                        If itemDetalle.AbsolutoReferencial = "R" Then
                            dblImporte = dblImporte + CheckDbl(itemDetalle.MontoGarantia) * CheckDbl(itemDetalle.CargoFijo)
                        ElseIf oReglaOUT.AbsolutoReferencial = "A" Then
                            dblImporte = dblImporte + CheckDbl(itemDetalle.MontoGarantia)
                        End If

                        'CF TOTAL / TIPO GARANTIA
                        dblTotalCF = dblTotalCF + CheckDbl(itemDetalle.CargoFijoEval)
                        strTipoGarantia = CheckStr(itemDetalle.TipoGarantia)

                        blnProdEvaluado = True
                    End If
                Next

                If blnProdEvaluado Then
                    'NRO GARANTIAS
                    If dblTotalCF = 0 Then
                        dblNroGarantia = 1
                    Else
                        'CALCULO IMPORTE DTH
                        If item.Codigo = ConfigurationSettings.AppSettings("consTipoProductoDTH") Then
                            If (dblImporte Mod 5) > 0 Then
                                dblImporte = 5 * (Int(dblImporte / 5) + 1)
                            End If
                        End If
                        dblNroGarantia = Math.Round((dblImporte / dblTotalCF), 2)
                    End If

                    For Each oCargo As TipoCargo In listaTipoGarantia
                        If CheckStr(oCargo.TCARV_DESCRIPCION).ToUpper = CheckStr(strTipoGarantia).ToUpper Then
                            strCodTipoGarantia = oCargo.TCARC_CODIGO
                            Exit For
                        End If
                    Next

                    'CADENA RENTAS X PRODUCTO
                    Dim strCadena As String = String.Format("{0};{1};{2};{3};{4};{5};{6}", _
                    strCodTipoGarantia, strTipoGarantia, dblNroGarantia, CheckDbl(dblImporte, 2), item.Codigo, item.Descripcion, dblTotalCF)
                    strGarantiaxProducto = strGarantiaxProducto & "|" & strCadena

                    dblMontoImporte = dblMontoImporte + CheckDbl(dblImporte, 2)
                End If
            Next

            'CADENA AUTONOMIA X PLAN
            Dim strPlanAutonomia As String
            For Each itemDetalle As MatrizReglasOUT In arrReglaOUT
                strPlanAutonomia = strPlanAutonomia & "|" & itemDetalle.Orden & ";" & itemDetalle.Autonomia
                hidResultado.Value = CheckStr(itemDetalle.respuestaRenovacion)
            Next

            'VALIDAR PODERES - 0-NO,1-SI
            If CheckStr(hidTipoDoc.Value) = ConfigurationSettings.AppSettings("TipoDocumentoRUC") And CheckInt(hidNroRRLL.Value) = 1 Then
                hidPoderes.Value = (New ConsumerNegocio).ConsultaObtencionPoderes(strRiesgo, nroPlanes)
            End If

            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> LC Disponible    : " & dblLCDisponible)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> Autonomia x Plan : " & strPlanAutonomia)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> Garantia x Prod  : " & strGarantiaxProducto)

            hidImporte.Value = dblMontoImporte
            hidLCDisponible.Value = dblLCDisponible
            hidPlanAutonomia.Value = strPlanAutonomia
            hidGarantiaxProducto.Value = strGarantiaxProducto
            hidTextoLCDisponible.Value = (New ConsumerNegocio).ConsultarTextoRangoLC(hidTipoDoc.Value, dblLCDisponible)

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR  --> Evaluar : " & CheckStr(ex.Message))
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR  --> Evaluar : " & CheckStr(ex.StackTrace))
            Throw ex
        Finally
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "========== FIN EVALUACION ==========================")
        End Try

    End Sub

    Public Function ConsultarReglas(ByVal oReglasIN As MatrizReglasIN, ByRef oReglasOUT As MatrizReglasOUT, ByRef strMensaje As String)
        strMensaje = ""
        oReglasOUT = New MatrizReglasOUT
        Dim blnConsulta As Boolean
        Dim nroDocumento As String = hidNroDocumento.Value

        'Consulta Reglas WS
        oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Input WS Drools  --> " & GrabarInLog(oReglasIN))
        Try
            blnConsulta = (New ReglasCrediticiaRenovNegocio).ConsultaMatrizReglas(oReglasIN, oReglasOUT, strMensaje)
        Catch ex As Exception
            blnConsulta = False
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Método ConsultarReglas() Exception Message Error: " & ex.Message)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Método ConsultarReglas() Exception Message StackTrace: " & ex.StackTrace)
        End Try

        oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output WS Drools --> " & GrabarOutLog(strMensaje, oReglasOUT))

        Return blnConsulta
    End Function

#Region "Funciones Generales"

    Private Sub ObtenerParametros()
        Dim listaParametros As String
        Dim arrayListaParametro As ArrayList = New ConsumerNegocio().ListarParametroGeneral(1)
        For Each oItem As ParametroConsumer In arrayListaParametro
            listaParametros = listaParametros & oItem.PCONI_CODIGO & ";" & CheckStr(oItem.PCONV_VALOR) & "|"
        Next
        hidListaParam.Value = listaParametros
    End Sub

    Public Function CalificarEnduedamiento(ByVal dblLCTotal As Double, ByVal dblCF As Double) As String
        Dim dblFactor As Double
        Dim strCalificacion As String
        Dim dblFactorEnduedaMenor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorEndeudaMenor")))
        Dim dblFactorEnduedaMayor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorEndeudaMayor")))

        dblFactor = CheckDbl((dblCF / (dblLCTotal + 0.1)), 2)

        If dblFactor < dblFactorEnduedaMenor Then
            strCalificacion = "BUENO"
        ElseIf dblFactorEnduedaMenor <= dblFactor And dblFactor <= dblFactorEnduedaMayor Then
            strCalificacion = "REGULAR"
        Else
            strCalificacion = "MALO"
        End If
        Return strCalificacion
    End Function

    Public Function CalificarSubsidio(ByVal dblPrecioLista As Double, ByVal dblPrecioVenta As Double) As String
        Dim dblFactor As Double
        Dim strCalificacion As String
        Dim dblFactorSubsidioMenor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorSubsidioMenor")))
        Dim dblFactorSubsidioMayor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorSubsidioMayor")))

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio dblPrecioVenta resultado_evaluacion " & dblPrecioVenta)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio dblPrecioLista resultado_evaluacion " & dblPrecioLista)

        If dblPrecioVenta = 0 Then
            dblFactor = 0
        Else
            dblFactor = (dblPrecioLista - dblPrecioVenta) / dblPrecioVenta
            If dblFactor < 0 Then
                dblFactor = 0
            End If
        End If
        dblFactor = CheckDbl(dblFactor, 2)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio dblFactor " & dblFactor)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio dblFactorSubsidioMenor resultado_evaluacion " & dblFactorSubsidioMenor)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio dblFactorSubsidioMayor  resultado_evaluacion " & dblFactorSubsidioMayor)

        If dblFactor < dblFactorSubsidioMenor Then
            strCalificacion = "BAJO"
        ElseIf dblFactor >= dblFactorSubsidioMenor And dblFactor < dblFactorSubsidioMayor Then
            strCalificacion = "MEDIO"
        ElseIf dblFactor >= dblFactorSubsidioMayor Then
            strCalificacion = "ALTO"
        End If
        Return strCalificacion
    End Function

    Public Function ObtenerParametroGeneral(ByVal CodParametro As String) As String
        Dim valor As String
        Dim listaParametro As String = hidListaParam.Value
        Dim arrListaParametro As String() = listaParametro.Split("|")
        For Each item As String In arrListaParametro
            Dim parametro As String() = item.Split(";")
            If parametro(0) = CodParametro Then
                valor = parametro(1)
            End If
        Next
        Return valor
    End Function

    Public Function ObtenerPlanProducto(ByVal arrPlanesxProducto As ArrayList, ByVal strPlanPaquete As String) As ArrayList
        Dim orden As Int64 = 0
        Dim arrPlan As New ArrayList
        For Each item As ItemGenerico In arrPlanesxProducto
            If item.Codigo = strPlanPaquete Then
                arrPlan.Add(item)
            End If
        Next
        Return arrPlan
    End Function

    Public Function ObtenerProductos(ByVal arrPlanxProducto As ArrayList) As String
        Dim strProducto As String
        For Each item As ItemGenerico In arrPlanxProducto
            If strProducto = "" Then
                strProducto = item.Descripcion
            Else
                strProducto = strProducto & " + " & item.Descripcion
            End If
        Next
        Return strProducto
    End Function

    Public Function CalcularNroPlanxProducto(ByVal arrProductos As ArrayList, ByVal arrPlanxProducto As ArrayList) As Integer
        Dim nroPlanes As Integer = 0
        For Each plan As ItemGenerico In arrPlanxProducto
            For Each item As ItemGenerico In arrProductos
                If item.Codigo = plan.Codigo2 Then
                    nroPlanes = nroPlanes + CheckInt(item.Valor)
                End If
            Next
        Next

        Return nroPlanes
    End Function

    Public Function CalcularLCDisponible(ByVal arrLCDispxProducto As ArrayList, ByVal arrPlanxProducto As ArrayList) As Double
        Dim dblLC As Double = 0

        If IsNothing(arrLCDispxProducto) Then
            arrLCDispxProducto = New ArrayList
        End If
        If IsNothing(arrPlanxProducto) Then
            arrPlanxProducto = New ArrayList
        End If

        If arrLCDispxProducto.Count > 0 And arrPlanxProducto.Count > 0 Then
            For Each item As ItemGenerico In arrLCDispxProducto
                For Each item1 As ItemGenerico In arrPlanxProducto
                    If item.Codigo = item1.Codigo2 Then
                        dblLC = dblLC + item.Valor
                        Exit For
                    End If
                Next
            Next
        End If
        Return dblLC
    End Function

    Public Function CalcularLCDispxProducto(ByVal arrLCxProd As ArrayList, ByVal arrFactxProd As ArrayList, ByVal arrNoFactxProd As ArrayList) As ArrayList
        Dim array As New ArrayList
        If arrFactxProd Is Nothing Then
            Return arrLCxProd
        End If
        For Each itemLC As ItemGenerico In arrLCxProd
            Dim item As New ItemGenerico
            For Each itemFact As ItemGenerico In arrFactxProd
                If itemLC.Codigo = itemFact.Codigo Then
                    For Each itemNOFact As ItemGenerico In arrNoFactxProd
                        If itemFact.Codigo = itemNOFact.Codigo Then

                            item.Codigo = itemLC.Codigo
                            item.Descripcion = itemLC.Descripcion
                            item.Valor = 0
                            If itemLC.Valor > (itemFact.Valor + itemNOFact.Valor) Then
                                item.Valor = CheckDbl(itemLC.Valor) - CheckDbl(itemFact.Valor) - CheckDbl(itemNOFact.Valor)
                            End If
                            array.Add(item)
                            Exit For
                        End If
                    Next
                End If
            Next
        Next
        Return array
    End Function

    Public Function ObtenerProductosxPlanes(ByVal arrCuentaMonto As ArrayList, ByVal arrPlanesxProducto As ArrayList) As ArrayList
        Dim array As New ArrayList
        Dim oBilletera As New PlanBilletera
        For Each itemCta As PlanBilletera In arrCuentaMonto
            oBilletera.NroPlanesMovil += itemCta.NroPlanesMovil
            oBilletera.NroPlanesInternet += itemCta.NroPlanesInternet
            oBilletera.NroPlanesClaroTV += itemCta.NroPlanesClaroTV
            oBilletera.NroPlanesTelefonia += itemCta.NroPlanesTelefonia
            oBilletera.NroPlanesBAM += itemCta.NroPlanesBAM
        Next

        Dim arrListaBilletera As ArrayList = (New ConsumerNegocio).ListarBilletera()
        For Each item As ItemGenerico In arrListaBilletera
            Dim itemOut As New ItemGenerico
            itemOut.Codigo = item.Codigo
            itemOut.Descripcion = item.Descripcion

            Select Case item.Codigo
                Case ConfigurationSettings.AppSettings("constTipoBilleteraMovil")
                    itemOut.Valor += oBilletera.NroPlanesMovil
                Case ConfigurationSettings.AppSettings("constTipoBilleteraInter")
                    itemOut.Valor += oBilletera.NroPlanesInternet
                Case ConfigurationSettings.AppSettings("constTipoBilleteraTV")
                    itemOut.Valor += oBilletera.NroPlanesClaroTV
                Case ConfigurationSettings.AppSettings("constTipoBilleteraTelef")
                    itemOut.Valor += oBilletera.NroPlanesTelefonia
                Case ConfigurationSettings.AppSettings("constTipoBilleteraBAM")
                    itemOut.Valor += oBilletera.NroPlanesBAM
            End Select

            For Each item1 As ItemGenerico In arrPlanesxProducto
                If item.Codigo = item1.Codigo Then
                    itemOut.Valor += item1.Valor
                End If
            Next

            array.Add(itemOut)
        Next

        Return array
    End Function

    Public Function GrabarInLog(ByVal oReglaIN As MatrizReglasIN) As String
        Dim param As String = ""
        param = param & oReglaIN.Campania & "|"
        param = param & oReglaIN.Canal & "|"
        param = param & oReglaIN.CantidadRRLL & "|"
        param = param & oReglaIN.CargoFijo & "|"
        param = param & oReglaIN.CasoEspecial & "|"
        param = param & oReglaIN.Control & "|"
        param = param & oReglaIN.Cuotas & "|"
        param = param & oReglaIN.Departamento & "|"
        param = param & oReglaIN.Distrito & "|"
        param = param & oReglaIN.Edad & "|"
        param = param & oReglaIN.FactorEndeudamiento & "|"
        param = param & oReglaIN.FactorSubsidio & "|"
        param = param & oReglaIN.Plan & "|"
        param = param & oReglaIN.Kit & "|"
        param = param & oReglaIN.Oferta & "|"
        param = param & oReglaIN.Pdv & "|"
        param = param & oReglaIN.PlazoAcuerdo & "|"
        param = param & oReglaIN.PorcentajeCuotaInicial & "|"
        param = param & oReglaIN.Provincia & "|"
        param = param & oReglaIN.Publicar & "|"
        param = param & oReglaIN.Riesgo & "|"
        param = param & oReglaIN.Score & "|"
        param = param & oReglaIN.TipoCliente & "|"
        param = param & oReglaIN.TipoDespacho & "|"
        param = param & oReglaIN.TipoDocumento & "|"
        param = param & oReglaIN.TipoOperacion & "|"
        param = param & oReglaIN.TipoProducto & "|"
        param = param & oReglaIN.Producto & "|"
        param = param & oReglaIN.NroPlanes & "|"
        param = param & oReglaIN.CargoFijoEval
        Return param
    End Function

    Public Function GrabarOutLog(ByVal strMensaje As String, ByVal oReglaOUT As MatrizReglasOUT) As String
        Dim param As String = ""
        param = param & strMensaje & "|"
        If Not IsNothing(oReglaOUT) Then
            param = param & oReglaOUT.Restriccion & "|"
            param = param & oReglaOUT.TipoGarantia & "|"
            param = param & oReglaOUT.AbsolutoReferencial & "|"
            param = param & oReglaOUT.MontoGarantia & "|"
            param = param & oReglaOUT.CostoInstalacion & "|"
            param = param & oReglaOUT.CantidadProductoMax & "|"
            param = param & oReglaOUT.respuestaRenovacion
        End If
        Return param
    End Function

    Private Function ObtenerPlanDetalle() As ArrayList

        Dim nroDocumento As String = hidNroDocumento.Value
        Dim listaPlanDetalle As New ArrayList
        Dim arrPlazo As ArrayList = (New ConsumerNegocio).ListarPlazoAcuerdo("")
        Dim arrProducto As ArrayList = (New ConsumerNegocio).ListarProducto()
        Try
            Dim arrPlanDetalle() As String = hiCadenaDrools.Value.Split("|")
            For Each strPlanDetalle As String In arrPlanDetalle
                If strPlanDetalle.Length > 0 Then

                    Dim strPlan As String() = UCase(strPlanDetalle).Split(";")
                    Dim oPlanDetalle As New PlanDetalleVenta

                    'Orden
                    oPlanDetalle.SOPLN_ORDEN = CheckInt64(strPlan(0))

                    'Producto
                    oPlanDetalle.PRDC_CODIGO = CheckStr(strPlan(1))
                    Dim blnPaquete3Play As Boolean = (oPlanDetalle.PRDC_CODIGO = ConfigurationSettings.AppSettings("consTipoProducto3Play"))
                    For Each producto As ItemGenerico In arrProducto
                        If producto.Codigo = oPlanDetalle.TPROC_CODIGO Then
                            oPlanDetalle.PRDV_DESCRIPCION = CheckStr(producto.Descripcion)
                            Exit For
                        End If
                    Next

                    'Plazo Acuerdo
                    oPlanDetalle.PACUC_CODIGO = CheckStr(strPlan(2))
                    For Each plazo As PlazoAcuerdo In arrPlazo
                        If plazo.PACUC_CODIGO = oPlanDetalle.PACUC_CODIGO Then
                            oPlanDetalle.PACUV_DESCRIPCION = CheckStr(plazo.PACUV_DESCRIPCION)
                            Exit For
                        End If
                    Next

                    oPlanDetalle.PAQTV_CODIGO = CheckStr(strPlan(3))
                    If Not oPlanDetalle.PAQTV_CODIGO = "" Then
                        oPlanDetalle.PAQTV_CODIGO = oPlanDetalle.PAQTV_CODIGO.Split("_")(0)
                        oPlanDetalle.PLANV_DESCRIPCION = CheckStr(strPlan(4)).Replace("*", "+")
                        oPlanDetalle.PAQTV_DESCRIPCION = oPlanDetalle.PLANV_DESCRIPCION
                    Else
                        oPlanDetalle.PLANC_CODIGO = CheckStr(strPlan(6))
                        oPlanDetalle.PLANV_DESCRIPCION = CheckStr(strPlan(7))
                    End If

                    oPlanDetalle.PLANC_CODIGO = CheckStr(strPlan(6))
                    oPlanDetalle.GRUPO_PLAN = CheckStr(strPlan(8))

                    Dim strCodTope As String = CheckStr(strPlan(9))
                    oPlanDetalle.TOPE_DESCRIPCION = ConfigurationSettings.AppSettings("ConstTextSinTopeConsumo")
                    Select Case strCodTope
                        Case ConfigurationSettings.AppSettings("constCodTopeCeroServicio")
                            oPlanDetalle.TOPE_DESCRIPCION = "TOPE DE CONSUMO CERO"
                        Case ConfigurationSettings.AppSettings("constCodTopeSinCFServicio")
                            oPlanDetalle.TOPE_DESCRIPCION = "TOPE DE CONSUMO SIN CF"
                        Case ConfigurationSettings.AppSettings("constCodTopeAutomaticoServicio")
                            oPlanDetalle.TOPE_DESCRIPCION = "TOPE DE CONSUMO AUTOMATICO"
                    End Select

                    If Not oPlanDetalle.PAQTV_CODIGO = "" Then
                        oPlanDetalle.TOPE_DESCRIPCION = ConfigurationSettings.AppSettings("constTextoTODOS")
                    End If

                    oPlanDetalle.CAMPANA = CheckStr(strPlan(10))
                    oPlanDetalle.CAMPANA_DESC = CheckStr(strPlan(11))
                    oPlanDetalle.MATERIAL_DESC = CheckStr(strPlan(12))
                    oPlanDetalle.CARGO_FIJO_LIN = CheckDbl(strPlan(13))
                    oPlanDetalle.CARGO_FIJO = CheckDbl(strPlan(13))
                    oPlanDetalle.PRECIO_LISTA = CheckDbl(CheckStr(strPlan(14)))
                    oPlanDetalle.PRECIO_VENTA = CheckDbl(CheckStr(strPlan(15)))

                    'Cuotas/Porcentaje
                    If Not CheckStr(strPlan(16)) = "" Then
                        oPlanDetalle.CUOTA_CODIGO = CheckDbl(CheckStr(strPlan(16)))
                        oPlanDetalle.CUOTA_INICIAL = CheckDbl(CheckStr(strPlan(17)))
                    End If

                    'Nro Planes x Paquete
                    'oPlanDetalle.SOPLN_CANTIDAD = CheckInt(strPlan(18))

                    listaPlanDetalle.Add(oPlanDetalle)
                End If
            Next

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR  --> ObtenerPlanDetalle : " & ex.Message)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR  --> ObtenerPlanDetalle Input: " & hiCadenaDrools.Value)
            Throw ex
        End Try

        Return listaPlanDetalle
    End Function

    Public Function ObtenerDatosReglas(ByRef dblLCDisponible As Double) As ArrayList

        Dim oData As New ArrayList
        Dim oReglas As New ReglasEvaluacionNegocio
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim strEdad As String = hidEdad.Value
        Dim strScore As String = hidScore.Value
        Dim strNroRRLL As String = hidNroRRLL.Value
        Dim strClaseCliente As String = hidClaseCliente.Value
        Dim strFactorRenovacion As String = hidFacRenovacion.Value
        Dim strComporPago As String = hidComporPago.Value

        Try
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & " INICIO PARA HACER LOS SPLIT")

            Dim strCodTipoDoc As String = hidTipoDoc.Value.Split("|")(0)
            Dim strCodCasoEspecial As String = hidCasoEspecial.Value.Split("|")(0)
            Dim strCasoEspecial As String = hidCasoEspecial.Value.Split("|")(1)
            Dim strDesCanal As String = hidCanal.Value.Split("|")(1)
            Dim strDesOferta As String = hidOferta.Value.Split("|")(1)
            Dim strDesRiesgo As String = hidRiesgo.Value.Split("|")(1)
            Dim strDesTipoDoc As String = hidTipoDoc.Value.Split("|")(1)
            Dim strDesOficina As String = hidOficina.Value.Split("|")(1)

            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "TIPO DOCUMENTO     : " & hidTipoDoc.Value)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "CASO ESPECIAL     : " & hidCasoEspecial.Value)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "CANAL     : " & hidCanal.Value)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "OFERTA     : " & hidOferta.Value)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "RIESGO     : " & hidRiesgo.Value)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "OFICINA     : " & hidOficina.Value)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & " FIN PARA HACER LOS SPLIT")

            'Planes Evaluados
            Dim strPlanesEval As String = ""
            Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
            For Each item As PlanDetalleVenta In arrPlanDetalle
                Dim strPlan As String = item.PLANC_CODIGO
                If item.PRDC_CODIGO = ConfigurationSettings.AppSettings("consTipoProducto3Play") Then
                    strPlan = item.PAQTV_CODIGO
                    strPlanesEval = String.Format("{0}|{1};{2}", strPlanesEval, strPlan, "1")
                Else
                    If item.PAQTV_CODIGO = "" Then
                        strPlanesEval = String.Format("{0}|{1};{2}", strPlanesEval, strPlan, "0")
                    Else
                        strPlan = item.PAQTV_CODIGO
                        'Oferta Corporativo - El conteo se realiza x nro de planes que contiene el paquete
                        For i As Integer = 1 To item.SOPLN_CANTIDAD
                            strPlanesEval = String.Format("{0}|{1};{2}", strPlanesEval, strPlan, "0")
                        Next
                    End If
                End If
            Next

            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> strPlanesEval    : " & strPlanesEval)

            'LC x Producto
            Dim oClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & nroDocumento), ClienteCuenta)
            Dim arrLCDispxProducto As New ArrayList
            Dim arrCuentaMonto As New ArrayList
            If oClienteCta.nroDoc = nroDocumento Then
                arrLCDispxProducto = oClienteCta.LCDispxProducto
                arrCuentaMonto = oClienteCta.montoCuenta
            End If

            'Obtener Estructura Plan x Producto
            Dim arrPlanesxProducto As ArrayList = oReglas.ObtenerPlanxProducto(strPlanesEval)

            'Calcular Nro Productos Evaluación
            Dim arrNroProductoEval As ArrayList = oReglas.ObtenerProductosxPlanes(strPlanesEval)

            'Calcular Total Productos
            Dim arrNroProductoTotal As ArrayList = ObtenerProductosxPlanes(arrCuentaMonto, arrNroProductoEval)

            Dim strPlanesxProd As String
            For Each item As ItemGenerico In arrNroProductoTotal
                strPlanesxProd = String.Format("{0}|{1};{2}", strPlanesxProd, item.Codigo, item.Valor)
            Next
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "Output --> Planes x Prod    : " & strPlanesxProd)

            'Departamento Oficina
            Dim strDepaOficina As String = ConsultarDepaOficina()

            Dim dblLCProducto As Double = 0.0
            Dim arrPlanxProducto As New ArrayList
            Dim oInput As MatrizReglasIN

            For Each item As PlanDetalleVenta In arrPlanDetalle

                oInput = New MatrizReglasIN
                oInput.Orden = item.SOPLN_ORDEN
                oInput.TipoDespacho = ConfigurationSettings.AppSettings("constTextoPDV")
                oInput.Pdv = strDesOficina
                oInput.Departamento = strDepaOficina
                oInput.TipoCliente = strClaseCliente
                oInput.TipoDocumento = strDesTipoDoc
                oInput.Oferta = strDesOferta
                oInput.Publicar = ConfigurationSettings.AppSettings("constCondicionPublicar")
                oInput.PlazoAcuerdo = item.PACUV_DESCRIPCION
                oInput.Plan = item.PLANV_DESCRIPCION

                If Trim(item.GRUPO_PLAN).Equals(String.Empty) Then
                    oInput.GrupoPlanTarifario = ConfigurationSettings.AppSettings("ParamGrupoPTarifarioDrools")
                Else
                    oInput.GrupoPlanTarifario = item.GRUPO_PLAN
                End If

                oInput.Campania = item.CAMPANA_DESC

                If item.PRDC_CODIGO = ConfigurationSettings.AppSettings("consTipoProducto3Play") Then
                    oInput.Campania = ConfigurationSettings.AppSettings("constTextoTODOS")
                End If

                oInput.CodCampania = item.CAMPANA
                oInput.Control = item.TOPE_DESCRIPCION
                oInput.NroDocumento = Right("00000000000" & nroDocumento, 11)
                oInput.Producto = item.PRDC_CODIGO

                Dim TipoOperacion As String = hidTipoOperacion.Value
                TipoOperacion = Replace(TipoOperacion, "Ó", "O")
                TipoOperacion = Replace(TipoOperacion, "ó", "o")
                oInput.TipoOperacion = TipoOperacion

                If item.PRDC_CODIGO = ConfigurationSettings.AppSettings("consTipoProductoDTH") Then
                    oInput.Kit = item.MATERIAL_DESC
                End If

                'Riesgo
                oInput.Riesgo = strDesRiesgo
                If Trim(strDesRiesgo).Equals(String.Empty) Then
                    oInput.Riesgo = ConfigurationSettings.AppSettings("ParamRiesgoDrools")
                End If

                If strCodTipoDoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                    oInput.CantidadRRLL = strNroRRLL
                Else
                    If Trim(strScore).Equals(String.Empty) Then
                        oInput.Score = ConfigurationSettings.AppSettings("ParamScoreDrools")
                    Else
                        oInput.Score = strScore
                    End If
                    oInput.Edad = strEdad
                End If

                'Canal
                oInput.Canal = strDesCanal
                If strDesCanal = "CORNER" Then
                    oInput.Canal = "CADENA"
                End If

                'Caso Especial
                If Not CheckStr(strCodCasoEspecial) = "" Then
                    oInput.CasoEspecial = strCasoEspecial
                End If

                'Cuotas/Porcentaje
                oInput.Cuotas = CheckStr(CheckInt(item.CUOTA_CODIGO))
                oInput.PorcentajeCuotaInicial = item.CUOTA_INICIAL

                'Plan / Paquete
                oInput.CodPlan = item.PLANC_CODIGO
                If Not item.PAQTV_CODIGO = "" Then
                    oInput.CodPlan = item.PAQTV_CODIGO
                End If
                oInput.CargoFijo = item.CARGO_FIJO_LIN
                oInput.CargoFijoEval = item.CARGO_FIJO_LIN

                'Plan x Producto [Tipos de Productos que componen al Plan]
                arrPlanxProducto = Nothing
                arrPlanxProducto = ObtenerPlanProducto(arrPlanesxProducto, oInput.CodPlan)

                'Producto [Descripción de Tipos de Productos que componen al Plan]
                oInput.TipoProducto = ObtenerProductos(arrPlanxProducto)

                'Factor Subsidio
                If item.PRDC_CODIGO = ConfigurationSettings.AppSettings("consTipoProductoDTH") Then
                    oInput.FactorSubsidio = "BAJO"
                ElseIf item.PRDC_CODIGO = ConfigurationSettings.AppSettings("consTipoProducto3Play") Then
                    oInput.FactorSubsidio = "ALTO"
                Else
                    oInput.FactorSubsidio = CalificarSubsidio(item.PRECIO_LISTA, item.PRECIO_VENTA)
                End If

                'Nro Planes [Se cuentan los planes cuyos Tipos de Productos esten incluidos en los Tipos de Productos que componen al Plan]
                If oInput.CasoEspecial = "REGULAR" Then
                    oInput.NroPlanes = CalcularNroPlanxProducto(arrNroProductoTotal, arrPlanxProducto)
                Else
                    oInput.NroPlanes = hidNroPlanes.Value
                End If

                'Factor Endeudamiento
                '[Sumatoria LC de Tipos de Productos que componen al Plan]
                dblLCProducto = CalcularLCDisponible(arrLCDispxProducto, arrPlanxProducto)
                oInput.FactorEndeudamiento = CalificarEnduedamiento(dblLCProducto, oInput.CargoFijo)

                'Factor renovacion / comportamiento pago
                oInput.FactorRenovacion = strFactorRenovacion
                oInput.ComportamientoPago = strComporPago
                oData.Add(oInput)
            Next

            'Calcular LC Disponible Evaluado
            Dim arrPlanEvalxProd As ArrayList = oReglas.ObtenerPlanxProducto(strPlanesEval)
            Dim dblLCEvaluado As Double = CalcularLCDisponible(arrLCDispxProducto, arrPlanEvalxProd)
            dblLCDisponible = dblLCEvaluado

            Return oData

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "ERROR  --> ObtenerDatosReglas : " & ex.Message)
            Throw ex
        Finally
            oData = Nothing
            oReglas = Nothing
        End Try

    End Function

    Public Function ConsultarDepaOficina()
        Dim strDepartamento As String
        Try
            Dim strOficina As String = CheckStr(hidOficina.Value).Split("|")(0)
            Dim arrOficina As ArrayList = (New ConsumerNegocio).ConsultarDepartamentoPDV(strOficina)
            If arrOficina.Count > 0 Then
                strDepartamento = CheckStr(CType(arrOficina(0), PuntoVenta).DEPAV_DESCRIPCION)
                If strDepartamento = "" Then
                    strDepartamento = ConfigurationSettings.AppSettings("constTextoTODOS")
                End If
            Else
                strDepartamento = ConfigurationSettings.AppSettings("constTextoTODOS")
            End If
        Catch ex As Exception
            strDepartamento = ConfigurationSettings.AppSettings("constTextoTODOS")
        End Try
        Return strDepartamento
    End Function

#End Region

#Region "Funciones BRMS"

    Public Function datosGeneralEvaluacion(ByVal oClienteCta As ClienteCuenta) As ReglasEvaluacionWS.ClaroEvalClientesReglasRequest

        Dim strTipoDoc As String = hidTipoDoc.Value
        Dim strCodOficina As String = hidOficina.Value
        Dim strCodTipoDoc As String = hidTipoDoc.Value
        Dim strNroDocumento As String = hidNroDocumento.Value
        Dim strNroOperacion As String = String.Empty 'hidNroOperacion.Value
        Dim oEvaluacionCliente As New ReglasEvaluacionWS.ClaroEvalClientesReglasRequest
        Dim dsDatosEvaluacionCliente As DataSet = (New ReglasEvaluacionNegocio).ConsultaDatosEvaluacionCliente(strCodOficina, strCodTipoDoc, strNroDocumento, strNroOperacion)

        If Not IsNothing(dsDatosEvaluacionCliente) Then

            Dim dtOficina As DataTable = dsDatosEvaluacionCliente.Tables(0)
            'Dim dtCliente As DataTable = dsDatosEvaluacionCliente.Tables(1)
            'Dim dtRepresentante As DataTable = dsDatosEvaluacionCliente.Tables(2)

            Dim oSolicitud As New ReglasEvaluacionWS.solicitud
            Dim oOficina As New ReglasEvaluacionWS.puntodeVenta
            Dim oDireccionOficina As New ReglasEvaluacionWS.direccion

            'Información Punto de Venta
            oOficina.codigo = CheckStr(dtOficina.Rows(0)("CODIGO"))
            oOficina.descripcion = CheckStr(dtOficina.Rows(0)("PDV"))
            oOficina.calidadDeVendedor = String.Empty
            oOficina.canal = CheckStr(dtOficina.Rows(0)("CANAL"))

            'Información Direccion Punto de Venta
            oDireccionOficina.codigoDePlano = String.Empty
            oDireccionOficina.departamento = CheckStr(dtOficina.Rows(0)("DEPARTAMENTO"))
            oDireccionOficina.distrito = CheckStr(dtOficina.Rows(0)("DISTRITO"))
            oDireccionOficina.provincia = CheckStr(dtOficina.Rows(0)("PROVINCIA"))
            oDireccionOficina.region = CheckStr(dtOficina.Rows(0)("REGION"))

            oOficina.direccion = oDireccionOficina

            Dim oCliente As New ReglasEvaluacionWS.cliente
            Dim oDocumentoCliente As New ReglasEvaluacionWS.documento

            'Información Cliente
            oDocumentoCliente.numero = strNroDocumento
            oDocumentoCliente.descripcion = ObtenerTipoDocumento(strCodTipoDoc, strNroDocumento)
            oDocumentoCliente.descripcionSpecified = True
            oCliente.documento = oDocumentoCliente

            oCliente.cantidadDeLineasActivas = oClienteCta.nroPlanesActivos
            oCliente.comportamientoDePago = oClienteCta.comportamientoPago
            'oCliente.edad = CheckStr(dtCliente.Rows(0)("EDAD"))
            oCliente.facturacionPromedioClaro = oClienteCta.montoFacturadoTotal
            'oCliente.creditScore = CheckStr(dtCliente.Rows(0)("PUNTAJE"))
            'oCliente.riesgo = CheckStr(dtCliente.Rows(0)("RIESGO"))
            'oCliente.sexo = CheckStr(dtCliente.Rows(0)("SEXO"))
            oCliente.tiempoDePermanencia = oClienteCta.tiempoPermanencia
            oCliente.tipo = oClienteCta.tipoCliente

            'Información Lista de Representantes Legales
            'If strTipoDoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then

            '    Dim oRRLL As ReglasEvaluacionWS.representanteLegal
            '    Dim oListaRRLL(dtRepresentante.Rows.Count - 1) As ReglasEvaluacionWS.representanteLegal
            '    Dim oDocumentoRRLL As ReglasEvaluacionWS.documento

            '    Dim idx As Integer = 0
            '    For Each dr As DataRow In dtRepresentante.Rows
            '        oRRLL = New ReglasEvaluacionWS.representanteLegal
            '        oDocumentoRRLL = New ReglasEvaluacionWS.documento
            '        oDocumentoRRLL.numero = CheckStr(dr("NUMERO_DOCUMENTO"))
            '        oDocumentoRRLL.descripcion = ObtenerTipoDocumento(dr("TIPO_DOCUMENTO"), dr("NUMERO_DOCUMENTO"))

            '        oRRLL.documento = oDocumentoRRLL
            '        oRRLL.riesgo = CheckStr(dr("RIESGO"))

            '        oListaRRLL(idx) = New ReglasEvaluacionWS.representanteLegal
            '        oListaRRLL(idx) = oRRLL
            '        idx += 1
            '    Next
            '    oCliente.representanteLegal = oListaRRLL
            'End If

            'Información Solicitud
            oSolicitud.solicitud1 = New ReglasEvaluacionWS.solicitud1
            oSolicitud.solicitud1.flagDeLicitacion = ReglasEvaluacionWS.tipoSiNo.NO
            oSolicitud.solicitud1.flagDeLicitacionSpecified = True
            oSolicitud.solicitud1.tipoDeBolsa = String.Empty
            oSolicitud.solicitud1.tipoDeDespacho = ConfigurationSettings.AppSettings("constTextoPDV")

            oSolicitud.solicitud1.cliente = oCliente
            oSolicitud.solicitud1.puntodeVenta = oOficina

            oEvaluacionCliente.solicitud = oSolicitud
        End If

        Return oEvaluacionCliente

    End Function

    Public Sub Evaluar()
        Dim strTipoDoc As String = hidTipoDoc.Value
        Dim oListaOfrecimiento As New ArrayList
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim strRiesgoClaro As String = String.Empty

            Dim strOferta As String = hidOferta.Value

            'Lista Planes Evaluados
            Dim arrPlanDetalle As String() = CheckStr(hiCadenaDrools.Value).Split(";")

            'Datos Cliente = Facturador / Evaluación
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "INICIO Datos Cliente = Facturador / Evaluación")
            Dim oClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & nroDocumento), ClienteCuenta)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "INICIO Datos Cliente = Facturador / Evaluación1")
            Dim oEvaluacionCliente As ReglasEvaluacionWS.ClaroEvalClientesReglasRequest
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "INICIO Datos Cliente = Facturador / Evaluación2")
            Dim oOfrecimiento As New Ofrecimiento
            Dim oConsumerNegocio As New ConsumerNegocio

            Dim dblLCDisponiblePlan As Double = 0.0
            Dim arrProductosxPlan As New ArrayList

            Dim oOferta As New ReglasEvaluacionWS.oferta
            Dim oSolicitud As ReglasEvaluacionWS.solicitud1
            Dim oEquipo As ReglasEvaluacionWS.equipo

            oEvaluacionCliente = datosGeneralEvaluacion(oClienteCta)
            oSolicitud = oEvaluacionCliente.solicitud.solicitud1
            oSolicitud.tipoDeOperacion = "RENOVACION" 'hidTipoOperacion.Value

            oEvaluacionCliente.DecisionID = arrPlanDetalle(0)
            oOferta = New ReglasEvaluacionWS.oferta

            oOferta.campana = New ReglasEvaluacionWS.campana
            oOferta.campana.tipo = arrPlanDetalle(9)
            oOferta.casoEpecial = "REGULAR"

            Dim strCodTope As String = CheckStr(arrPlanDetalle(7))
            oOferta.controlDeConsumo = ConfigurationSettings.AppSettings("ConstTextSinTopeConsumo")
            Select Case strCodTope
                Case ConfigurationSettings.AppSettings("constCodTopeCeroServicio")
                    oOferta.controlDeConsumo = "TOPE DE CONSUMO CERO"
                Case ConfigurationSettings.AppSettings("constCodTopeSinCFServicio")
                    oOferta.controlDeConsumo = "TOPE DE CONSUMO SIN CF"
                Case ConfigurationSettings.AppSettings("constCodTopeAutomaticoServicio")
                    oOferta.controlDeConsumo = "TOPE DE CONSUMO AUTOMATICO"
            End Select

            oOferta.kitDeInstalacion = String.Empty

            'LISTA EQUIPOS
            Dim oListaEquipo(0) As ReglasEvaluacionWS.equipo
            oListaEquipo(0) = New ReglasEvaluacionWS.equipo
            oListaEquipo(0).costo = CheckDbl(arrPlanDetalle(13))
            oListaEquipo(0).cuotas = CheckInt(arrPlanDetalle(15))
            oListaEquipo(0).formaDePago = ConfigurationSettings.AppSettings("constFormaPagoContado")
            oListaEquipo(0).gama = ConfigurationSettings.AppSettings("constGamaEquipoBajo")
            oListaEquipo(0).modelo = arrPlanDetalle(12)
            oListaEquipo(0).montoDeCuota = CheckDbl(arrPlanDetalle(17))
            oListaEquipo(0).porcentajecuotaInicial = CheckDbl(arrPlanDetalle(16))
            oListaEquipo(0).precioDeVenta = CheckDbl(arrPlanDetalle(14))
            oListaEquipo(0).tipoDeDeco = String.Empty
            oListaEquipo(0).tipoOperacionKit = String.Empty
            oSolicitud.equipo = oListaEquipo

            'Plan Actual
            oOferta.planActual = New ReglasEvaluacionWS.planActual
            oOferta.planActual.cargoFijo = oClienteCta.planActualCF
            oOferta.planActual.descripcion = oClienteCta.planActual.ToUpper

            'Plan Solicitado
            oOferta.planSolicitado = New ReglasEvaluacionWS.planSolicitado
            oOferta.planSolicitado.cargoFijo = CheckDbl(arrPlanDetalle(10))
            oOferta.planSolicitado.descripcion = UCase(arrPlanDetalle(6))
            oOferta.planSolicitado.paquete = String.Empty
            oOferta.plazoDeAcuerdo = arrPlanDetalle(2)

            'Producto
            Dim arrProducto As ArrayList = (New ConsumerNegocio).ListarProducto()
            For Each producto As ItemGenerico In arrProducto
                If producto.Codigo = arrPlanDetalle(1) Then
                    oOferta.productoComercial = CheckStr(producto.Descripcion)
                    Exit For
                End If
            Next

            oOferta.segmentoDeOferta = strOferta
            oOferta.tipoDeOperacionEmpresa = String.Empty

            'Producto x Plan [Tipos de Productos que componen al Plan]
            arrProductosxPlan = Nothing
            arrProductosxPlan = (New ReglasEvaluacionNegocio).ObtenerPlanxProducto(arrPlanDetalle(5) & ";0")

            'Producto [Texto de Tipos de Productos que componen al Plan]
            oOferta.tipoDeProducto = ObtenerTextoProductosxPlan(arrProductosxPlan)

            'Nro Planes = Sumatoria Planes [Productos que componen al Plan]
            Dim intPlanesActivoxProducto As Integer
            Dim arrNroPlanesActivosxProducto As New ArrayList
            intPlanesActivoxProducto = CalcularNroPlanesActivoxProducto(oClienteCta.oNroPlanesActivosxProducto, arrProductosxPlan)
            oSolicitud.cliente.cantidadDePlanesPorProducto = intPlanesActivoxProducto

            'LC Disponible Plan = Sumatoria [LC - CF] [Productos que componen al Plan]
            dblLCDisponiblePlan = 0 'CalcularLCDisponiblePlan(arrPlanDetalle, arrProductosPlanesEval, arrLCDisponiblexProducto, oPlan) 'PENDIENTE

            oSolicitud.cliente.limiteDeCreditoDisponible = dblLCDisponiblePlan
            oSolicitud.oferta = oOferta
            oEvaluacionCliente.solicitud.solicitud1 = oSolicitud

            'Monto Facturado x Producto
            Dim dblMontoFacturadoxProducto As Double = 0.0
            dblMontoFacturadoxProducto = CalcularMontoFacturadoxProducto(oClienteCta.FacturaxProducto, arrProductosxPlan)
            oSolicitud.cliente.facturacionPromedioProducto = dblMontoFacturadoxProducto

            'Consulta BRMS
            oOfrecimiento = (New BRMSNegocio).ConsultaReglaCrediticia(oEvaluacionCliente)
            oOfrecimiento.IdFila = arrPlanDetalle(0)
            oOfrecimiento.IdProducto = arrPlanDetalle(1)
            oOfrecimiento.CargoFijo = CheckDbl(arrPlanDetalle(10))


            'INICIO WHZR 29092014
            Dim StrCargoFijo As String = Convert.ToString(oOfrecimiento.CargoFijo)
            Dim Respuesta As Boolean = True
            If hidCanal.Value = Convert.ToString(ConfigurationSettings.AppSettings("constCodTipoDAC")) Or hidCanal.Value = Convert.ToString(ConfigurationSettings.AppSettings("constCodTipoCRN")) Then
                If Convert.ToDouble(hidMontoRegistrado.Value) >= Convert.ToDouble(StrCargoFijo) Then
                    hidMSJMontoRegistrado.Value = ConfigurationSettings.AppSettings("consMensajeNroLineaWhitelist")
                    Respuesta = False
                    hidRespuestaMontoR.Value = Respuesta
                    Exit Sub
                Else
                    hidRespuestaMontoR.Value = Respuesta
                End If
            End If

            'FIN WHZR 29092014
            'AUTONOMIA
            oOfrecimiento.TieneAutonomia = ResultadoAutonomia(oOfrecimiento, intPlanesActivoxProducto)
            'MONTO DE GARANTIA
            oOfrecimiento.MontoGarantiaFinal = ResultadoMontoGarantia(oOfrecimiento)
            'LOG
            grabarLog(oEvaluacionCliente, oOfrecimiento)

            oListaOfrecimiento.Add(oOfrecimiento)

            ResultadoOfrecimiento(oListaOfrecimiento)

            'Session Ofrecimiento
            Session("oClienteOfrecimiento" & nroDocumento) = oListaOfrecimiento

            'Calcular LC Disponible Evaluado
            Dim dblLCEvaluado As Double = 0 'CalcularLCDisponibleEval(arrLCDisponiblexProducto, arrProductosPlanesEval) 'PENDIENTE
            hidLCDisponible.Value = dblLCEvaluado


    End Sub

    Public Function ResultadoAutonomia(ByVal oOfrecimiento As Ofrecimiento, ByVal nroPlanesxProducto As Integer) As String
        Dim strAutonomia As String = "N"
        If oOfrecimiento.FlagExito = "S" Then
            If Not CheckStr(oOfrecimiento.Restriccion) = "NO" Then
                strAutonomia = "NO_CONDICION"
            Else
                If oOfrecimiento.AutonomiaRenovacion = ConfigurationSettings.AppSettings("constAutonomiaAprobado") Then
                    strAutonomia = "S"
                End If
            End If
        Else
            strAutonomia = "SIN_REGLAS" 'SIN_REGLAS O EXCEPCIÓN CONSULTA DROOLS
        End If

        Return strAutonomia
    End Function

    Public Function ResultadoMontoGarantia(ByVal oOfrecimiento As Ofrecimiento) As String
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim dblImporte As Double = 0.0
        oLog.Log_WriteLog(strArchivo2, nroDocumento & " - " & "ResultadoMontoGaratia")
        oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.FlagExito --> " & oOfrecimiento.FlagExito.ToString())
        oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.Tipodecobro --> " & oOfrecimiento.Tipodecobro.ToString())
        oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.MontoDeGarantia --> " & oOfrecimiento.MontoDeGarantia.ToString())
        oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.CargoFijo --> " & oOfrecimiento.CargoFijo.ToString())
        If oOfrecimiento.FlagExito = "S" Then
            If oOfrecimiento.Tipodecobro = "REFERENCIAL" Then
                dblImporte = CheckDbl((oOfrecimiento.MontoDeGarantia * oOfrecimiento.CargoFijo), 2)
            Else
                dblImporte = CheckDbl(oOfrecimiento.MontoDeGarantia, 2)
            End If
        End If
        oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "dblImporte --> " & dblImporte.ToString())

        Return dblImporte
    End Function

    Public Sub ResultadoOfrecimiento(ByVal arrOfrecimiento As ArrayList)

        Dim nroDocumento As String = hidNroDocumento.Value
        Dim dblTotalCF As Double
        Dim dblImporte As Double
        Dim strTipoGarantia As String
        Dim strCodTipoGarantia As String
        Dim dblMontoImporte As Double = 0
        Dim dblNroGarantia As Double = 0
        Dim blnProdEvaluado As Boolean
        Dim strGarantiaxProducto As String
        Dim strRiesgoClaro As String = String.Empty
        Dim strComportaConsolidado As String = String.Empty
        Dim strComportaPagoC1 As String = String.Empty
        Dim strTipoDoc As String = hidTipoDoc.Value

        Dim arrListaProducto As ArrayList = (New ConsumerNegocio).ListarProducto()
        Dim listaTipoGarantia As ArrayList = (New ConsumerNegocio).ListarTipoGarantia("", "1")

        For Each oProducto As ItemGenerico In arrListaProducto
            dblTotalCF = 0.0
            dblNroGarantia = 1
            dblImporte = 0.0
            strTipoGarantia = ""
            blnProdEvaluado = False
            strCodTipoGarantia = ConfigurationSettings.AppSettings("constCodTipoGarantiaRA")

            For Each oOfrecimiento As Ofrecimiento In arrOfrecimiento
                oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.FlagExito--> " & oOfrecimiento.FlagExito.ToString())
                oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oProducto.Codigo--> " & oProducto.Codigo.ToString())
                oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.IdProducto--> " & oOfrecimiento.IdProducto.ToString())
                oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.MontoGarantiaFinal--> " & oOfrecimiento.MontoGarantiaFinal.ToString())
                oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "oOfrecimiento.CargoFijo--> " & oOfrecimiento.CargoFijo.ToString())

                If oOfrecimiento.FlagExito = "S" And oProducto.Codigo = oOfrecimiento.IdProducto Then
                    'CF TOTAL / TIPO GARANTIA
                    dblImporte = dblImporte + oOfrecimiento.MontoGarantiaFinal
                    dblTotalCF = dblTotalCF + oOfrecimiento.CargoFijo
                    strTipoGarantia = oOfrecimiento.TipoDeGarantia

                    blnProdEvaluado = True
                End If
            Next
            oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "dblImporte--> " & dblImporte.ToString())
            oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "dblTotalCF--> " & dblTotalCF.ToString())
            oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "strTipoGarantia--> " & strTipoGarantia)

            If blnProdEvaluado Then
                'NRO GARANTIAS
                If dblTotalCF = 0 Then
                    dblNroGarantia = 1
                Else
                    'CALCULO IMPORTE DTH
                    If oProducto.Codigo = ConfigurationSettings.AppSettings("consTipoProductoDTH") Then
                        If (dblImporte Mod 5) > 0 Then
                            dblImporte = 5 * (Int(dblImporte / 5) + 1)
                        End If
                    End If
                    dblNroGarantia = Math.Round((dblImporte / dblTotalCF), 2)
                End If

                For Each oCargo As TipoCargo In listaTipoGarantia
                    If CheckStr(oCargo.TCARV_DESCRIPCION).ToUpper = CheckStr(strTipoGarantia).ToUpper Then
                        strCodTipoGarantia = oCargo.TCARC_CODIGO
                        Exit For
                    End If
                Next

                'CADENA RENTAS X PRODUCTO
                Dim strCadena As String = String.Format("{0};{1};{2};{3};{4};{5};{6}", _
                strCodTipoGarantia, strTipoGarantia, dblNroGarantia, CheckDbl(dblImporte, 2), oProducto.Codigo, oProducto.Descripcion, dblTotalCF)
                strGarantiaxProducto = strGarantiaxProducto & "|" & strCadena

                dblMontoImporte = dblMontoImporte + CheckDbl(dblImporte, 2)

                oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "strGarantiaxProducto--> " & strGarantiaxProducto)
                oLog.Log_WriteLog(strArchivo2, hidNroDocumento.Value & " - " & "dblMontoImporte--> " & dblMontoImporte.ToString())

            End If
        Next

        'CADENA AUTONOMIA X PLAN
        Dim strPlanAutonomia As String
        Dim strExoneracionRA As String = "NO"
        Dim strFactorRenovacion As String
        Dim strResultado As String
        Dim strCostoInstalacion As String = ConfigurationSettings.AppSettings("constMsjSinCostoInstalacion")
        For Each oOfrecimiento As Ofrecimiento In arrOfrecimiento
            If oOfrecimiento.FlagExito = "S" Then
                strCostoInstalacion = oOfrecimiento.CostoDeInstalacion
            End If
            strFactorRenovacion = oOfrecimiento.FactorDeRenovacionCliente
            strRiesgoClaro = oOfrecimiento.RiesgoEnClaro
            strComportaConsolidado = oOfrecimiento.ComportamientoConsolidado
            strComportaPagoC1 = oOfrecimiento.ComportamientoDePagoC1
            strResultado = oOfrecimiento.AutonomiaRenovacion

            strPlanAutonomia = strPlanAutonomia & "|" & oOfrecimiento.IdFila & ";" & oOfrecimiento.TieneAutonomia & ";" & strCostoInstalacion

            If strExoneracionRA = "SI" Then
                strExoneracionRA = oOfrecimiento.ProcesoDeExoneracionDeRentas
            End If
        Next

        'VALIDAR PODERES - 0-NO,1-SI
        If strTipoDoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") And CheckInt(hidNroRRLL.Value) = 1 Then
            hidPoderes.Value = (New ConsumerNegocio).ConsultaObtencionPoderes(hidRiesgo.Value, arrOfrecimiento.Count)
        End If

        'hidExoneracionRA.Value = strExoneracionRA 'PENDIENTE
        hidImporte.Value = dblMontoImporte
        hidPlanAutonomia.Value = strPlanAutonomia
        hidGarantiaxProducto.Value = strGarantiaxProducto
        hidRiesgoClaro.Value = strRiesgoClaro
        hidComportaConsolidado.Value = strComportaConsolidado
        hidComportaClaroC1.Value = strComportaPagoC1
        hidFactorRenovacion.Value = strFactorRenovacion
        hidResultado.Value = strResultado

        If Not strTipoDoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
            strTipoDoc = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI")
        End If
        hidTextoLCDisponible.Value = (New ConsumerNegocio).ConsultarTextoRangoLC(strTipoDoc, CheckDbl(hidLCDisponible.Value))

    End Sub

    Private Sub grabarLog(ByVal oEvaluacion As ReglasEvaluacionWS.ClaroEvalClientesReglasRequest, ByRef oOfrecimiento As Ofrecimiento)
        Dim strSolicitud As String = String.Empty
        Dim strCliente As String = String.Empty
        Dim strDirCliente As String = String.Empty
        Dim strDocCliente As String = String.Empty
        Dim strOferta As String = String.Empty
        Dim strCampana As String = String.Empty
        Dim strPlan As String = String.Empty
        Dim strPlanActual As String = String.Empty
        Dim strOficina As String = String.Empty
        Dim strDirOficina As String = String.Empty
        Dim strRepLegal As String = String.Empty
        Dim strEquipo As String = String.Empty
        Dim strOfrecimiento As String = String.Empty
        Dim nroDocumento As String = hidNroDocumento.Value

            Dim oSolicitud As ReglasEvaluacionWS.solicitud1
            Dim oCliente As ReglasEvaluacionWS.cliente
            Dim oOferta As ReglasEvaluacionWS.oferta
            Dim oRepLegal As ReglasEvaluacionWS.representanteLegal

            oSolicitud = oEvaluacion.solicitud.solicitud1
            oCliente = oEvaluacion.solicitud.solicitud1.cliente
            oOferta = oEvaluacion.solicitud.solicitud1.oferta

            'Información Solicitud --------------------------------------------
            strSolicitud &= oSolicitud.cargoFijoDeBolsa & "|"
            strSolicitud &= oSolicitud.flagDeLicitacion.ToString & "|"
            strSolicitud &= oSolicitud.tipoDeBolsa & "|"
            strSolicitud &= oSolicitud.tipoDeDespacho & "|"
            strSolicitud &= oSolicitud.tipoDeOperacion

            'Información Cliente ----------------------------------------------
            strCliente &= oCliente.cantidadDeLineasActivas & "|"
            strCliente &= oCliente.cantidadDePlanesPorProducto & "|"
            strCliente &= oCliente.comportamientoDePago & "|"
            strCliente &= oCliente.creditScore & "|"
            strCliente &= oCliente.edad & "|"
            strCliente &= oCliente.facturacionPromedioClaro & "|"
            strCliente &= oCliente.facturacionPromedioProducto & "|"
            strCliente &= oCliente.limiteDeCreditoDisponible & "|"
            strCliente &= oCliente.riesgo & "|"
            strCliente &= oCliente.sexo & "|"
            strCliente &= oCliente.tiempoDePermanencia & "|"
            strCliente &= oCliente.tipo

            'Información Dirección Cliente ---------------------------------------
            If Not IsNothing(oCliente.direccion) Then
                strDirCliente &= oCliente.direccion.codigoDePlano & "|"
                strDirCliente &= oCliente.direccion.departamento & "|"
                strDirCliente &= oCliente.direccion.distrito & "|"
                strDirCliente &= oCliente.direccion.provincia & "|"
                strDirCliente &= oCliente.direccion.region
            End If

            'Información Documento Cliente ---------------------------------------
            strDocCliente &= oCliente.documento.descripcion.ToString & "|"
            strDocCliente &= oCliente.documento.numero

            'Información Representante Cliente -----------------------------------
            If Not IsNothing(oSolicitud.cliente.representanteLegal) Then
                For Each rrll As ReglasEvaluacionWS.representanteLegal In oSolicitud.cliente.representanteLegal
                    strRepLegal &= rrll.documento.descripcion.ToString & "|"
                    strRepLegal &= rrll.documento.numero.ToString & "|"
                    strRepLegal &= rrll.riesgo & "_"
                Next
            End If

            'Información Equipos Cliente ----------------------------------------
            If Not IsNothing(oSolicitud.equipo) Then
                For Each oEquipo As ReglasEvaluacionWS.equipo In oSolicitud.equipo
                    strEquipo &= oEquipo.costo & "|"
                    strEquipo &= oEquipo.cuotas & "|"
                    strEquipo &= oEquipo.formaDePago & "|"
                    strEquipo &= oEquipo.gama & "|"
                    strEquipo &= oEquipo.modelo & "|"
                    strEquipo &= oEquipo.montoDeCuota & "|"
                    strEquipo &= oEquipo.porcentajecuotaInicial & "|"
                    strEquipo &= oEquipo.precioDeVenta & "|"
                    strEquipo &= oEquipo.tipoDeDeco & "|"
                    strEquipo &= oEquipo.tipoOperacionKit & "_"
                Next
            End If

            'Información Oferta --------------------------------------------------
            strOferta &= oOferta.cantidadDeDecos & "|"
            strOferta &= oOferta.casoEpecial & "|"
            strOferta &= oOferta.controlDeConsumo & "|"
            strOferta &= oOferta.kitDeInstalacion & "|"
            strOferta &= oOferta.plazoDeAcuerdo & "|"
            strOferta &= oOferta.productoComercial & "|"
            strOferta &= oOferta.segmentoDeOferta & "|"
            strOferta &= oOferta.tipoDeOperacionEmpresa & "|"
            strOferta &= oOferta.tipoDeProducto

            'Información Plan Actual -----------------------------------------------
            strPlanActual &= oOferta.planActual.cargoFijo & "|"
            strPlanActual &= oOferta.planActual.descripcion & "|"
            strPlanActual &= oOferta.planActual.mesesParaCubrirApadece & "|"
            strPlanActual &= oOferta.planActual.plazoDeAcuerdo & "|"
            'gaa20161122
            strPlanActual &= oOferta.planActual.tiempoPermanencia & "|"
            'fin gaa20161122
            'Información Plan Solicitado -------------------------------------------
            strPlan &= oOferta.planSolicitado.cargoFijo & "|"
            strPlan &= oOferta.planSolicitado.descripcion & "|"
            strPlan &= oOferta.planSolicitado.paquete & "|"

            'Información Campaña ---------------------------------------------------
            strCampana &= oOferta.campana.grupo & "|"
            strCampana &= oOferta.campana.tipo

            'Información Punto de Venta --------------------------------------------
            strOficina &= oSolicitud.puntodeVenta.calidadDeVendedor & "|"
            strOficina &= oSolicitud.puntodeVenta.canal & "|"
            strOficina &= oSolicitud.puntodeVenta.codigo & "|"
            strOficina &= oSolicitud.puntodeVenta.descripcion & "|"

            'Información Dirección Punto de Venta ----------------------------------
            strDirOficina &= oSolicitud.puntodeVenta.direccion.codigoDePlano & "|"
            strDirOficina &= oSolicitud.puntodeVenta.direccion.departamento & "|"
            strDirOficina &= oSolicitud.puntodeVenta.direccion.distrito & "|"
            strDirOficina &= oSolicitud.puntodeVenta.direccion.provincia & "|"
            strDirOficina &= oSolicitud.puntodeVenta.direccion.region

            'Información Ofrecimiento ----------------------------------------------
            If oOfrecimiento.FlagExito = "S" Then
                strOfrecimiento &= oOfrecimiento.CantidadDeAplicacionesRenta & "|"
                strOfrecimiento &= oOfrecimiento.CantidadDeLineasAdicionalesRUC & "|"
                strOfrecimiento &= oOfrecimiento.CantidadDeLineasMaximas & "|"
                strOfrecimiento &= oOfrecimiento.AutonomiaRenovacion & "|"
                strOfrecimiento &= oOfrecimiento.CapacidadDePago & "|"
                strOfrecimiento &= oOfrecimiento.ComportamientoConsolidado & "|"
                strOfrecimiento &= oOfrecimiento.ComportamientoDePagoC1 & "|"
                strOfrecimiento &= oOfrecimiento.ControlDeConsumo & "|"
                strOfrecimiento &= oOfrecimiento.CostoDeInstalacion & "|"
                strOfrecimiento &= oOfrecimiento.CostoTotalEquipos & "|"
                strOfrecimiento &= oOfrecimiento.FactorDeEndeudamientoCliente & "|"
                strOfrecimiento &= oOfrecimiento.FactorDeRenovacionCliente & "|"
                strOfrecimiento &= oOfrecimiento.FrecuenciaDeAplicacionMensual & "|"
                strOfrecimiento &= oOfrecimiento.LimiteDeCreditoCobranza & "|"
                strOfrecimiento &= oOfrecimiento.MesInicioRentas & "|"
                strOfrecimiento &= oOfrecimiento.MontoCFParaRUC & "|"
                strOfrecimiento &= oOfrecimiento.MontoDeGarantia & "|"
                strOfrecimiento &= oOfrecimiento.MontoTopeAutomatico & "|"
                strOfrecimiento &= oOfrecimiento.PrecioDeVentaTotalEquipos & "|"
                strOfrecimiento &= oOfrecimiento.PrioridadPublicar & "|"
                strOfrecimiento &= oOfrecimiento.ProcesoDeExoneracionDeRentas & "|"
                strOfrecimiento &= oOfrecimiento.ProcesoIDValidator & "|"
                strOfrecimiento &= oOfrecimiento.ProcesoValidacionInternaClaro & "|"
                strOfrecimiento &= oOfrecimiento.Publicar & "|"
                strOfrecimiento &= oOfrecimiento.Restriccion & "|"
                strOfrecimiento &= oOfrecimiento.RiesgoEnClaro & "|"
                strOfrecimiento &= oOfrecimiento.RiesgoOferta & "|"
                strOfrecimiento &= oOfrecimiento.RiesgoTotalEquipo & "|"
                strOfrecimiento &= oOfrecimiento.RiesgoTotalRepLegales & "|"
                strOfrecimiento &= oOfrecimiento.TipoDeAutonomiaCargoFijo & "|"
                strOfrecimiento &= oOfrecimiento.Tipodecobro & "|"
                strOfrecimiento &= oOfrecimiento.TipoDeGarantia & "|"
            End If
            strOfrecimiento &= oOfrecimiento.FlagExito

            oOfrecimiento.In_solicitud = strSolicitud
            oOfrecimiento.In_cliente = strCliente
            oOfrecimiento.In_direccion_cliente = strDirCliente
            oOfrecimiento.In_doc_cliente = strDocCliente
            oOfrecimiento.In_rrll_cliente = strRepLegal
            oOfrecimiento.In_equipo = strEquipo
            oOfrecimiento.In_oferta = strOferta
            oOfrecimiento.In_campana = strCampana
            oOfrecimiento.In_plan_actual = strPlanActual
            oOfrecimiento.In_plan_solicitado = strPlan
            'oOfrecimiento.In_servicio
            oOfrecimiento.In_pdv = strOficina
            oOfrecimiento.In_direccion_pdv = strDirOficina

            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strSolicitud : " & strSolicitud)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strCliente : " & strCliente)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strDirCliente : " & strDirCliente)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strDocCliente : " & strDocCliente)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strRepLegal : " & strRepLegal)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strEquipo : " & strEquipo)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strOferta : " & strOferta)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strCampana : " & strCampana)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strPlanActual : " & strPlanActual)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strPlan : " & strPlan)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strOficina : " & strOficina)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strDirOficina : " & strDirOficina)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "strOfrecimiento : " & strOfrecimiento)
            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "mensaje error : " & oOfrecimiento.Mensaje)


    End Sub

#Region "Funciones Calculo"

    Public Function ObtenerTipoDocumento(ByVal strTipoDoc As String, ByVal strNroDoc As String) As ReglasEvaluacionWS.tipoDeDocumento
        Select Case strTipoDoc
            Case ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI")
                Return ReglasEvaluacionWS.tipoDeDocumento.DNI
            Case ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX")
                Return ReglasEvaluacionWS.tipoDeDocumento.CE
            Case ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC")
                If strNroDoc.Substring(0, 1) = "1" Then
                    Return ReglasEvaluacionWS.tipoDeDocumento.RUC10
                Else
                    Return ReglasEvaluacionWS.tipoDeDocumento.RUC20
                End If
            Case AppSettings.Key_codigoDocCIRE '//INI PROY 31636 RENTESEG
                Return ReglasEvaluacionWS.tipoDeDocumento.CIRE
            Case AppSettings.Key_codigoDocCIE
                Return ReglasEvaluacionWS.tipoDeDocumento.CIE
            Case AppSettings.Key_codigoDocCPP
                Return ReglasEvaluacionWS.tipoDeDocumento.CPP
            Case AppSettings.Key_codigoDocCTM
                Return ReglasEvaluacionWS.tipoDeDocumento.CTM
            Case AppSettings.Key_codigoDocPasaporte07
                Return ReglasEvaluacionWS.tipoDeDocumento.PASAPORTE '//FIN PROY 31636 RENTESEG
            Case Else
                Return ReglasEvaluacionWS.tipoDeDocumento.DNI
        End Select
    End Function

    Public Function ObtenerTextoProductosxPlan(ByVal arrProductosxPlan As ArrayList) As String
        Dim strTextoProducto As String
        For Each item As ItemGenerico In arrProductosxPlan
            If strTextoProducto = "" Then
                strTextoProducto = item.Descripcion
            Else
                strTextoProducto = strTextoProducto & " + " & item.Descripcion
            End If
        Next
        Return strTextoProducto
    End Function

    Public Function CalcularMontoFacturadoxProducto(ByVal oMontoFacturadoxProducto As ArrayList, ByVal arrProductosxPlan As ArrayList) As Double
        Dim dblMontoFacturado As Double = 0.0

        For Each oMontoFacturado As ItemGenerico In oMontoFacturadoxProducto
            For Each oProducto As ItemGenerico In arrProductosxPlan
                If oMontoFacturado.Codigo = oProducto.Codigo2 Then
                    dblMontoFacturado = dblMontoFacturado + oMontoFacturado.Valor
                End If
            Next
        Next

        Return dblMontoFacturado
    End Function

    Public Function CalcularNroPlanesActivoxProducto(ByVal arrNroPlanesxProducto As ArrayList, ByVal arrProductosxPlan As ArrayList) As Integer
        Dim nroPlanes As Integer = 0
        For Each producto As ItemGenerico In arrProductosxPlan
            For Each plan As PlanBilletera In arrNroPlanesxProducto
                Select Case producto.Codigo2
                    Case ConfigurationSettings.AppSettings("constTipoBilleteraMovil")
                        nroPlanes = nroPlanes + CheckInt(plan.NroPlanesMovil)
                    Case ConfigurationSettings.AppSettings("constTipoBilleteraInter")
                        nroPlanes = nroPlanes + CheckInt(plan.NroPlanesInternet)
                    Case ConfigurationSettings.AppSettings("constTipoBilleteraTV")
                        nroPlanes = nroPlanes + CheckInt(plan.NroPlanesClaroTV)
                    Case ConfigurationSettings.AppSettings("constTipoBilleteraTelef")
                        nroPlanes = nroPlanes + CheckInt(plan.NroPlanesTelefonia)
                    Case ConfigurationSettings.AppSettings("constTipoBilleteraBAM")
                        nroPlanes = nroPlanes + CheckInt(plan.NroPlanesBAM)
                End Select
            Next
        Next
        Return nroPlanes
    End Function

#End Region

#End Region

#End Region

End Class
