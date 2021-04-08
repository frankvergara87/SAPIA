<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_HFC_Masivo.aspx.vb" Inherits="sisact_mant_HFC_Masivo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>sisact_mant_HFC_Masivo</title>
        <meta name="vs_snapToGrid" content="True">
        <meta name="vs_showGrid" content="True">
        <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <LINK rel="stylesheet" type="text/css" href="../../estilos/general.css">
        <LINK title="win2k-cold-1" rel="stylesheet" type="text/css" href="../../estilos/calendar-blue.css"
            media="all">
        <script language="JavaScript" src="../../script/Lib_FuncValidacion.js"></script>
        <script language="javascript" src="../../script/funciones_sec.js"></script>
        <script language="javascript" src="../../librerias/funciones_generales.js"></script>
        <script type="text/javascript" src="../../Script/calendar/calendar.js"></script>
        <script type="text/javascript" src="../../Script/calendar/calendar_es.js"></script>
        <script type="text/javascript" src="../../Script/calendar/calendario_call.js"></script>
        <script type="text/javascript" src="../../Script/calendar/calendar_setup.js"></script>
        <script language="javascript" type="text/javascript">
        
            function f_Buscar()
			{	
				if (getValue('txtBusquedaFechaInicio').length == 0 && getValue('txtBusquedaFechaFin').length == 0)
				{
					alert('Debe ingresar la Fecha Inicial y Fecha Final.');
					return false;
				}
				var dias;
			     dias=0;
			     dias= DiferenciaFechas()
			   //alert('dffd' +(dias));
			if (dias>92){
					alert('El rango de Fechas no debe de ser mayor a 3 meses.');
					return false;
				}			
			}
			
			function fecha( cadena )
            {   
			    //Separador para la introduccion de las fechas   
			    var separador = "/"  
    				
			    //Separa por dia, mes y año   
			    if ( cadena.indexOf( separador ) != -1 ) {   
					    var posi1 = 0   
					    var posi2 = cadena.indexOf( separador, posi1 + 1 )   
					    var posi3 = cadena.indexOf( separador, posi2 + 1 )   
					    this.dia = cadena.substring( posi1, posi2 )   
					    this.mes = cadena.substring( posi2 + 1, posi3 )   
					    this.anio = cadena.substring( posi3 + 1, cadena.length )   
			    } else {   
					    this.dia = 0   
					    this.mes = 0   
					    this.anio = 0      
			    }   
            }
            
            function DiferenciaFechas () 
            {   
			    //Obtiene los datos del formulario   
			    CadenaFecha1 = document.getElementById("txtBusquedaFechaFin").value;
			    CadenaFecha2 = document.getElementById("txtBusquedaFechaInicio").value;
    				    
			    //Obtiene dia, mes y año   
			    var fecha1 = new fecha( CadenaFecha1 )      
			    var fecha2 = new fecha( CadenaFecha2 )   
    				    

			    //var miFecha1 = new Date( fecha1.anio, fecha1.mes, fecha1.dia )   
			    var miFecha1 = new Date( fecha1.anio, fecha1.mes-1, fecha1.dia )   
    			
			    //var miFecha2 = new Date( fecha2.anio, fecha2.mes, fecha2.dia )   
			    var miFecha2 = new Date( fecha2.anio, fecha2.mes-1, fecha2.dia )   
    			
			    //Resta fechas y redondea   
			    var diferencia = miFecha1.getTime() - miFecha2.getTime()   
			    var dias = Math.floor(diferencia / (1000 * 60 * 60 * 24))   
			    var segundos = Math.floor(diferencia / 1000)   

			    return dias   
            }
			
			function f_Inicio()
			{
				f_MostrarTab('BUSQUEDA');
			}
			
			function f_MostrarTab(valor)
			{
			    if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					var currentTime = new Date();
					var dd = currentTime.getDate();
                    var mm = currentTime.getMonth()+1; //January is 0!
                    var yyyy = currentTime.getFullYear();
                    
                    if(dd<10){dd='0'+dd} 
                    if(mm<10){mm='0'+mm} 
                    currentTime = dd+'/'+mm+'/'+yyyy;

                    //fecha actual
					document.getElementById("txtBusquedaFechaFin").value=currentTime;
                    
                    //fecha inicio
                    var d = new Date(yyyy, mm, dd);
                    d.setMonth(d.getMonth()-4);
                    
					var dd2 = d.getDate();
                    var mm2 = d.getMonth()+1; //January is 0!
                    var yyyy2 = d.getFullYear();
                    
                    if(dd2<10){dd2='0'+dd2} 
                    if(mm2<10){mm2='0'+mm2} 
                    document.getElementById("txtBusquedaFechaInicio").value=dd2+'/'+mm2+'/'+yyyy2;
				}
			}
			
			function f_Limpiar()
			{
				setValue('txtBusquedaFechaInicio', '');
				setValue('txtBusquedaFechaFin', '');
				document.getElementById('<%=ddlEstado.ClientId %>').selectedIndex = -1;
			}

        </script>
    </HEAD>
    <body MS_POSITIONING="GridLayout">
        <form id="FrmHFCMasivo" method="post" runat="server">
            <table class="tblContenido" border="0" cellSpacing="0" cellPadding="0">
                <tr id="trBusqueda">
                    <td>
                        <table class="contenido" border="0" cellSpacing="0" cellPadding="0" width="1100">
                            <tr>
                                <td style="WIDTH: 1100px; HEIGHT: 23px" class="header" colSpan="6" align="left">Consulta 
                                    Reporte HFC Masivo
                                </td>
                            </tr>
                            <tr>
                                <td class="Arial10B" width="1100">&nbsp;
                                    <asp:label id="lblFecIni" Runat="server" Text="Fecha Atención Inicio:"></asp:label>&nbsp;&nbsp;&nbsp;
                                    <asp:textbox id="txtBusquedaFechaInicio" runat="server" ReadOnly="True" CssClass="clsInputDisable"
                                        Width="80px"></asp:textbox>&nbsp; <IMG style="BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; BORDER-TOP: 0px; CURSOR: pointer; BORDER-RIGHT: 0px"
                                        id="btnBusquedaFechaInicio" border="0" src="../../images/calendario.gif">
                                    <SCRIPT type="text/javascript">
                                                    Calendar.setup(
                                                        {
                                                            inputField     :    "txtBusquedaFechaInicio",      
                                                            ifFormat       :    "%d/%m/%Y",                                                               
                                                            button         :    "btnBusquedaFechaInicio",   
                                                            singleClick    :    true,          
                                                            step           :    1               
                                                        }
                                                    );
                                    </SCRIPT>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:label id="Label1" Runat="server" Text="Fecha Atención Final:"></asp:label>&nbsp;&nbsp;&nbsp;
                                    <asp:textbox id="txtBusquedaFechaFin" runat="server" ReadOnly="True" CssClass="clsInputDisable"
                                        Width="80px"></asp:textbox>&nbsp;<IMG style="BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; BORDER-TOP: 0px; CURSOR: pointer; BORDER-RIGHT: 0px"
                                        id="btnBusquedaFechaFin" border="0" src="../../images/calendario.gif">
                                    <SCRIPT type="text/javascript">
                                                    Calendar.setup(
                                                        {
                                                            inputField     :    "txtBusquedaFechaFin",      
                                                            ifFormat       :    "%d/%m/%Y",                                                               
                                                            button         :    "btnBusquedaFechaFin",   
                                                            singleClick    :    true,          
                                                            step           :    1               
                                                        }
                                                    );
                                    </SCRIPT>
                                </td>
                            </tr>
                            <tr>
                                <td style="HEIGHT: 17px" class="Arial10B" width="960">&nbsp;&nbsp;<asp:label id="Label2" Runat="server" Text="Estado:"></asp:label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:dropdownlist id="ddlEstado" runat="server" CssClass="clsSelectEnable" Width="125px" AutoPostBack="True"></asp:dropdownlist></td>
                                <td style="HEIGHT: 17px" width="100"><asp:button style="CURSOR: hand" id="btnBuscar" onmouseover="this.className='BotonResaltado';"
                                        onmouseout="this.className='Boton';" Runat="server" Text="Buscar" CssClass="Boton" Width="90" Height="19"></asp:button></td>
                                <td style="HEIGHT: 17px" width="100"><asp:button style="CURSOR: hand" id="btnExportar" onmouseover="this.className='BotonResaltado';"
                                        onmouseout="this.className='Boton';" Runat="server" Text="Exportar" CssClass="Boton" Width="90" Height="19"></asp:button></td>
                                <td style="HEIGHT: 17px" width="100"><asp:button style="CURSOR: hand" id="btnLimpiar" onmouseover="this.className='BotonResaltado';"
                                        onmouseout="this.className='Boton';" Runat="server" Text="Limpiar" CssClass="Boton" Width="90" Height="19"></asp:button></td>
                            </tr>
                            <tr id="trGrilla">
                                <td width="1100" colSpan="8"><br>
                                    <div style="WIDTH: 1090px; HEIGHT: 374px" id="divGrid" class="clsGridRow">
                                        <table border="0" cellSpacing="0" cellPadding="0">
                                            <tr>
                                                <td colSpan="8"> <!-- colspan="4"--> <!--Width="960px" height="300px"--><asp:datagrid id="dgDetalleHFC" Runat="server" AllowPaging="True" ShowHeader="True" AutoGenerateColumns="False">
                                                        <ItemStyle cssclass="Arial10B" backcolor="#E9EBEE" Height="25px"></ItemStyle>
                                                        <alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="SOLIN_CODIGO" HeaderText="SEC" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos" Height="35px"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CONTN_NUMERO_SOT" HeaderText="SOT" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CODIGO_CLIENTE_SGA" HeaderText="CLIENTE SGA" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="90px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="NOMBRE_CLIENTE" HeaderText="NOMBRE CLIENTE" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="200px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TIPO_DOC" HeaderText="TIPO DOCUMENTO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="120px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="NUM_DOC" HeaderText="NUM. DOCUMENTO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="120px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CAMPANA" HeaderText="CAMPA&#209;A" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ESTADO_SOT" HeaderText="ESTADO SOT" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="100px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="SOLUCION" HeaderText="SOLUCION" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PAQUETE" HeaderText="PAQUETE" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="250px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ID_PLANO" HeaderText="COD. PLANO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="80px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="DIREC_INST" HeaderText="DIRECCION INSTALACION" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="200px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TIPO_VIA" HeaderText="TIPO VIA" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="70px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="REFERENCIA_INST" HeaderText="REFERENCIA INSTALACION" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="240px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="NRO_PUERTA" HeaderText="NRO PUERTA" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="90px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ID_URBANIZACION" HeaderText="CODIGO URBANIZACION" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TXT_URBANIZACION" HeaderText="URBANIZACION" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="120px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="MANZANA" HeaderText="MANZANA" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="LOTE" HeaderText="LOTE" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="DEPAV_DESCRIPCION" HeaderText="DEPARTAMENTO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PROVV_DESCRIPCION" HeaderText="PROVINCIA" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="DISTV_DESCRIPCION" HeaderText="DISTRITO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="OVENC_CODIGO" HeaderText="OFICINA VENTA" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="INSTALADOR" HeaderText="INSTALADOR" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CONTD_FECHA_CONTRATO" HeaderText="FECHA CONTRATO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CONTV_USUARIO_CREACION" HeaderText="USUARIO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TELEFONO_REF_1" HeaderText="TELEFONO REFERENCIA1" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TELEFONO_REF_2" HeaderText="TELEFONO REFERENCIA2" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TELEF_DIR_INST" HeaderText="TELEFONO INSTALACION" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="VENDEDOR" HeaderText="VENDEDOR" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="DNI_VENDEDOR" HeaderText="DNI VENDEDOR" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CANAL" HeaderText="CANAL VENTA" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CONTC_ESTADO" HeaderText="ESTADO CONTRATO" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="40px"></itemstyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="FECHA_INST" HeaderText="FECHA INSTALACION" itemstyle-cssclass="Arial10B">
                                                                <headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
                                                                <itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
                                                            </asp:BoundColumn>
                                                        </Columns>
                                                        <PagerStyle Font-Size="12px" Mode="NumericPages"></PagerStyle>
                                                    </asp:datagrid></td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
 
 
 
 
