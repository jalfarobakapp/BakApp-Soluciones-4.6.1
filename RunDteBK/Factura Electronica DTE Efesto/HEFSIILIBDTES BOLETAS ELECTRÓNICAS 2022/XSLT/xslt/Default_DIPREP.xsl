<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:sii="http://www.sii.cl/SiiDte" exclude-result-prefixes="sii">
  <xsl:output indent="yes" method="html" encoding="iso-8859-1" omit-xml-declaration="yes"/>
  <xsl:decimal-format  name="moneda" decimal-separator="," grouping-separator="."/>

  <!--PARAMETROS -->
  <xsl:param name="esCedible"/>
  
  
  <!-- PARAMEROS INTERNOS -->
  <xsl:param name="SIIDireccionRegional">S.I.I.- SANTIAGO CENTRO</xsl:param>
  <xsl:param name="PrefijoFecha">SANTIAGO</xsl:param>
  
  
  <!-- BEGIN -->
  <xsl:template match="/">
    <xsl:call-template name="crearRepresentacion"/>    
  </xsl:template>
  
  <!-- INDICADOR DE TRASLADO SOLO GUIAS DE DESPACHO -->
  <xsl:template name="indicadorTraslado">
    <xsl:variable name="IT" select="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado"/>
    <xsl:choose>
      <xsl:when test="$IT='1'">Operaci�n constituye venta</xsl:when>
      <xsl:when test="$IT='2'">Ventas por efectuar</xsl:when>
      <xsl:when test="$IT='3'">Consignaciones</xsl:when>
      <xsl:when test="$IT='4'">Entregas gratuitas</xsl:when>
      <xsl:when test="$IT='5'">Traslados internos</xsl:when>
      <xsl:when test="$IT='6'">Otros traslados no venta</xsl:when>
      <xsl:when test="$IT='7'">Gu�a de devoluci�n</xsl:when>
      <xsl:when test="$IT='8'">Traslados para exportaci�n(no venta)</xsl:when>
      <xsl:when test="$IT='9'">Venta para exportaci�n</xsl:when>
      <xsl:otherwise>Contado</xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
  <!-- FUNCIONES forma de pago-->
  <xsl:template name="formaDePago">
    <xsl:variable name="FP" select="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:FmaPago"/>
    <xsl:choose>
      <xsl:when test="$FP='1'">Contado</xsl:when>
      <xsl:when test="$FP='2'">Credito</xsl:when>
      <xsl:when test="$FP='3'">Sin Costo(entrega gratuita)</xsl:when>
      <xsl:otherwise>Contado</xsl:otherwise>
    </xsl:choose>
  </xsl:template>
   
  <!-- FUNCIONES crear uri PDF417 -->
  <xsl:template name="uriPdf417">
    <xsl:variable name="E" select="sii:DTE/sii:Documento/sii:Encabezado/sii:Emisor/sii:RUTEmisor"/>
    <xsl:variable name="F" select="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:Folio"/>
    <xsl:variable name="T" select="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE"/>
    <xsl:value-of select="concat('R',$E,'T',$T,'F',$F,'.png')"/>
  </xsl:template>
    
  <!-- FUNCIONES FormatoRut -->
  <xsl:template name="FormatoRut">
    <xsl:param name="Rut"/>
    <xsl:variable name="body" select="format-number(substring-before($Rut,'-'),'###.###.###','moneda')"/>
    <xsl:variable name="digito" select="translate(substring-after($Rut,'-'),'k','K')"/>
    <xsl:value-of select="concat($body,'-',$digito)"/>
  </xsl:template>
  
  <!-- FUNCIONES NombreDocumento -->
  <xsl:template name="NombreDocumento">
    <xsl:param name="tip"/>
    <xsl:variable name="resultado">
      <xsl:choose>
        <xsl:when test="$tip='33'">FACTURA ELECTR�NICA</xsl:when>
        <xsl:when test="$tip='34'">FACTURA NO AFECTA O EXENTA ELECTR�NICA</xsl:when>
        <xsl:when test="$tip='46'">FACTURA DE COMPRA ELECTR�NICA</xsl:when>
        <xsl:when test="$tip='56'">NOTA DE D�BITO ELECTR�NICA</xsl:when>
        <xsl:when test="$tip='61'">NOTA DE CR�DITO ELECTR�NICA</xsl:when>
        <xsl:when test="$tip='52'">GU�A DE DESPACHO ELECTR�NICA</xsl:when>
    		<xsl:when test="$tip='39'">BOLETA ELECTR�NICA</xsl:when>
        <xsl:when test="$tip='41'">BOLETA EXENTA ELECTR�NICA</xsl:when>
    		<xsl:otherwise>&#160;</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:value-of select="$resultado"/>
  </xsl:template>
  
  <!-- FORMATEO DE FECHA DE GENERACION -->
  <xsl:template name="FechaFormateado">
    <!-- RESULTADO DE LA FUNCION -->
	<div style="text-align:right;padding:3px 3px 3px 3px;font-family:verdana;font-size:13px">
	
		<xsl:value-of select="$PrefijoFecha"/>,&#160;
		<xsl:value-of select="substring(sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:FchEmis,9,2)"/>
		
		<xsl:variable name="indiceMes" select="substring(sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:FchEmis,6,2)"/>
		<xsl:choose>
			<xsl:when test="$indiceMes='01'"> Enero </xsl:when>
			<xsl:when test="$indiceMes='02'"> Febrero </xsl:when>
			<xsl:when test="$indiceMes='03'"> Marzo </xsl:when>
			<xsl:when test="$indiceMes='04'"> Abril </xsl:when>
			<xsl:when test="$indiceMes='05'"> Mayo </xsl:when>
			<xsl:when test="$indiceMes='06'"> Junio </xsl:when>
			<xsl:when test="$indiceMes='07'"> Julio </xsl:when>
			<xsl:when test="$indiceMes='08'"> Agosto </xsl:when>
			<xsl:when test="$indiceMes='09'"> Septiembre </xsl:when>
			<xsl:when test="$indiceMes='10'"> Octubre </xsl:when>
			<xsl:when test="$indiceMes='11'"> Noviembre </xsl:when>
			<xsl:when test="$indiceMes='12'"> Diciembre </xsl:when>
        </xsl:choose>
		de&#160;
		<xsl:value-of select="substring(sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:FchEmis,1,4)"/>
		
	</div>
  </xsl:template>
  
  
  <!-- CREA LA REPRESENTACION DEL DOCUMENTO -->
  <xsl:template name="crearRepresentacion">
    
    <!-- CREE EL MARCO DE TRABAJO -->
    <html>
      <header>
        <title>Representacion documento DTE</title>
        
        <style>
          .marco
          {
          width:25cm;
          height:20cm;
          border:0px solid #cdcdcd;
		  margin-top:10px;

          }

          td
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;
          }


          .DetalleDocumento
          {
          width : 100%;
          height: 10cm;
          border: 2px solid black;
          }

          .DetalleDocumento th
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;
          }

          .DetalleDocumento td
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;
          }

          .ReferenciasDocumento{
          width:99%;
          border-top:2px solid black;
          border-right:2px solid black;
          border-left:2px solid black;
          border-bottom:1px solid BLACK;
          }

          .ReferenciasDocumento th
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;
          height:23px;
          }

          .ReferenciasDocumento td
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;
          height:23px;

          }


          .TotalesDocumento
          {
          width:100%;
          border:2px solid black;
          }

          .TotalesDocumento td
          {
          padding:2px 4px 2px 4px;
          font-family:verdana;
          font-size:11px;
          height:23px;
          }

          .FooterDocumento
          {
          width:100%;
          border:0px solid black;
          margin:5px 0 0 0;
          }

          .FooterDocumento td
          {
          padding:4px 4px 4px 4px;
          }

          .PalabrasDocumento
          {
          width:100%;
          border:2px solid #cdcdcd;
          margin:5px 0 0 0;
          }

          .PalabrasDocumento td
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;
          padding:3px 3px 3px 3px;

          }

          .DetalleRowBottom
          {
          border-bottom:1px solid White;
          }

          .DetalleRowRight
          {
          border-right:1px solid White;
          }

          .DetalleRowBottomHeader
          {
          border-bottom:1px solid black;
          }

          .DetalleRowRightHeader
          {
          border-right:1px solid Black;
          }


          .HeaderDocumento
          {
          width:100%
          }

          .HeaderDocumento td
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;
          }



          .ReceptorDocumento
          {
			width:100%;
			border:1px solid black;
          }

          .ReceptorDocumento td
          {
			vertical-align:top;
			font-family:verdana;
			font-size:11px;
			height:23px;
          }

          .TransporteDocumento
          {
			width:100%;
			border:2px solid black;
          }

          .TransporteDocumento td
          {
          vertical-align:top;
          font-family:verdana;
          font-size:11px;

          }

          .CuadroRojo
          {
          font-family:verdana;
          font-size:16px;
          font-weight:bold;
          text-align:center;
          color:red;
          padding:3px;
          width:8cm;
          height:2.5cm;
          text-align:center;
          border:3px solid red;
		  margin-left:5px;
          }


          .HeaderEncabezado
          {
          font-family:verdana;
          font-size:12px;
          font-weight:bold;
          padding-top:8px;
          padding-left:3px;
          padding-bottom:3px;

          }

          .CeldaCantidad
          {
          font-size:15px;
          text-align:right;
          padding:2px 2px 2px 2px;
          }

          .CeldaTexto
          {
          text-align:left;
          padding:0 2px 0 2px;
          }

          .TotaleraDocumento
          {
          margin:10px 0 0 0;
          width:100%;

          }

          .TimbreElectronico
          {
          padding:0 0 0 0;
          text-align:right;
          }

          .TimbreElectronico img
          {
          /*
          width:9cm;
          height:3cm;*/
          }

          .TextoRecibo
          {

          font-family:verdana;
          font-size:8px;
          font-weight:bold;


          }

          .TextoNotaRecibo
          {

          font-family:verdana;
          font-size:7px;
          font-weight:bold;


          }

          /* ESTILO TEXTO RAZON SOCIAL EMPRESA EMISORA */
          .TextoGrande {
          font-family :arial;
          font-size   : 12.5pt;
          font-weight :bold;
          }

          /* ESTILO TEXTO GIRO EMPRESA */
          .TextoGiro {
          font-family :Verdana;
          font-size   :7.5pt;

          }
		  
		  /* ============================================================= */
		  /* NUEVOS ESTILOS                                                */
		  /* ============================================================= */
		  
		  /* ESTILO DE TABLA */
		  .Tabla
		  {
			width:100%;
			border:2px solid black;
		  
		  }
		  
  		  /* ESTILO DE TD TABLA */
		  .Tabla td
		  {
			font-family: verdana;
			font-size:10pt;
			text-align:left;
			padding:3px 5px 3px 5px;
		    background:#FFFFFF;
			
		  }

		  
		  /* TITULO DE TABLAS */
		  .TablaTitulo
		  {
			background:#D8D8D8;
			font-family: verdana;
			font-size:10pt;
			text-align:left;
			padding:3px 5px 3px 5px;
			border-bottom:2px solid black;
		  }
		  
		  /* TITULO DE TABLAS */
		  .TablaDetalle
		  {
			background:#D8D8D8;
			font-family: verdana;
			font-size:10pt;
			text-align:left;
			padding:3px 5px 3px 5px;
			
		  }
		  
		  

        </style>
        
      </header>
      <body style="padding-top:20px">
        <table class="marco" align="center">
          <tr>
            <td>
			  
              <xsl:call-template name="HeaderDocumento"/>
			  <br/>
              <xsl:call-template name="ReceptorDocumento"/>
			  <br/>
              
              <xsl:call-template name="DetalleDocumento"/>
              <xsl:call-template name="TotaleraDocumento"/>
			  
			  <br/>
			  <br/>
              <xsl:call-template name="FooterDocumento"/>
			  <xsl:call-template name="MensajeCedible"/>
            </td>
          </tr>
        </table>
      </body>
    </html>
    
  </xsl:template>

  <!-- CUADRO ROJO -->
  <xsl:template name="CuadroRojo">
    <div class="CuadroRojo">

      <!-- De formato al rut-->
      <xsl:variable name="RUT">
        <xsl:call-template name="FormatoRut">
          <xsl:with-param name="Rut" select="sii:DTE/sii:Documento/sii:Encabezado/sii:Emisor/sii:RUTEmisor"/>
        </xsl:call-template>
      </xsl:variable>
      
      <!-- Calcule el nombre del documento -->
      <xsl:variable name="NombreDte">
        <xsl:call-template name="NombreDocumento">
          <xsl:with-param name="tip" select="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE"/>
        </xsl:call-template>
      </xsl:variable>

      <!-- Cual es el folio del documento -->
      <xsl:variable name="Folio">
        <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:Folio"/>
      </xsl:variable>
      
      <!-- SALIDA -->
      <div>
        R.U.T.:<xsl:value-of select="$RUT"/>
        <div style="padding-top:3px;">
          <xsl:value-of select="$NombreDte"/>
        </div>
        <div style="padding-top:3px;">N�<xsl:value-of select="$Folio"/></div>
      </div>



    </div>
    <div style="text-align:center;color:red;font-weight:bold;padding:5px 0 0 0 "><xsl:value-of select="$SIIDireccionRegional"/></div>
  </xsl:template>
  
  <!-- HEADER DEL DOCUMENTO -->
  <xsl:template name="HeaderDocumento">
   
    <table class="HeaderDocumento" border="0px">
      <colgroup>
        <col style="width:auto"/>
        <col style="width:200px"/>
      </colgroup>
      <tr>
        <td>

          <table border="0px" style="width:100%" cellpadding="0" cellspacing="0">
            <colgroup>
              <col style="width:1%"/>
              <col style="width:auto"/>
            </colgroup>
            <tr>
              <td>
                <!-- LOGO DEL EMISOR DEL DOCUMENTO -->
                <!--<img src="IMAGES/Default2.jpg" alt="logo cliente" style="width:110px;height:120px;padding-right:5px"/>-->
                <img src="IMAGES/LogoDiprec.png" alt="logo cliente" style="width:110px;height:120px;padding-right:5px"/>
              </td>
              <td>
                <!-- DATOS DEL CONTRIBUYENTE -->
                <div class="TextoGrande">
                  DIRECCION GENERAL DEL CREDITO PRENDARIO

                  <br/>
                  <div class="TextoGiro">
                    CREDITO PRENDARIO<br/>
                    OTRAS ACTIVIDADES DE SERVICIOS DE APOYO A LAS EMPRESAS<br/>
                    ACTIVIDADES DE LA ADMINISTRACION PUBLICA EN GENERAL
                  </div>
				  <br/>
                 
				  <div style="font-weight:normal;font-size:12px">
            Casa matriz:<br/>
            Direcci�n:  SAN ANTONIO NRO 425 PISO 5<br/>
            Comuna:  SANTIAGO<br/>
            Ciudad:  SANTIAGO<br/>
            

            <!--<b>Direcci�n:</b>&#160;
				          --><!--<xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Emisor/sii:DirOrigen"/><br/>--><!--
                  PRESIDENTE RIESCO 5111, Depto. 174<BR/>
                  <b>Comuna:</b>&#160;
				          <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Emisor/sii:CmnaOrigen"/>
                  <BR/>
			            <b>Ciudad:</b>&#160;
                  <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Emisor/sii:CiudadOrigen"/>-->

          </div>
				  
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div class="TextoGiro">&#160;</div>
              </td>
            </tr>
          </table>
          
        </td>
        <td>
          <xsl:call-template name="CuadroRojo"/>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          Sucursales:<br/>

          <table width="100%" style="background:#f5f5f5;border-radius: 10px;">
            <tr>
              <td style="font-size:7px;">
                000.-MATRIZ S.I.I. - SANTIAGO CENTRO<br/>
                132.-MATUCANA<br/>
                133.-SAN DIEGO<br/>
                135.-PTE. ALTO<br/>
                250.-ARICA<br/>
                011.-IQUIQUE<br/>
                002.-ANTOFAGASTA<br/>
                003.-COPIAPO<br/>
                004.-LA SERENA<br/>
                051.-LOS ANDES
              </td>
              <td style="font-size:7px;">
                :SAN PABLO 1130<br/>
                :MATUCANA 33<br/>
                :SAN DIEGO 1426<br/>
                :MANUEL RODRIGUEZ 053<br/>
                :RAFAEL SOTOMAYOR 871<br/>
                :GOROSTIAGA 651<br/>
                :JOSE SANTOS OSSA 1981<br/>
                :ATACAMA 443<br/>
                :FCO. DE AGUIRRE 480<br/>
                :MANUEL RODRIGUEZ 468
              </td>
              <td style="font-size:7px;">
                054.-VALPARAISO<br/>
                053.-VI�A DEL MAR<br/>
                055.-QUILPUE<br/>
                052.-QUILLOTA<br/>
                006.-RANCAGUA<br/>
                007.-TALCA<br/>
                008.-CONCEPCION<br/>
                009.-TEMUCO<br/>
                010.-VALDIVIA<br/>
                101.-PUERTO MONTT<br/>
                012.-PUNTA ARENAS


              </td>
              <td style="font-size:7px;">
                :12 DE FEBRERO 144<br/>
                :VALPARAISO 971<br/>
                :FREIRE 1284<br/>
                :O'HIGGINS 77<br/>
                :NICOLAS RUBIO 319<br/>
                :2 SUR 1196<br/>
                :FREIRE 171<br/>
                :GENERAL MACKENNA 280<br/>
                :RAMON PICARTE 608<br/>
                :URMENETA 954<br/>
                :LAUTARO NAVARRO 1024
              </td>
            </tr>
            </table>

          
          
          
          
        </td>
      </tr>
    </table>
    
    
  </xsl:template>

  <!-- DATOS DEL RECEPTOR -->
  <xsl:template name="ReceptorDocumento">
    
      <!-- AGREGAR FECHA FORMATEADA -->
	  <xsl:call-template name="FechaFormateado"/>

    
    
      <table border="0px" cellpadding="0" cellspacing="0" class="Tabla">
      <colgroup>
        <col style="width:100px;" />
        <col style="width:3px;"/>
        <col style="width:auto"/>
        <col style="width:120px"/>
        <col style="width:3px;"/>
        <col style="width:140px"/>
      </colgroup>  
		<tr>
			<th colspan="6" class="TablaTitulo">Receptor</th>
		</tr>
		<tr>
          <td style="font-weight:bold;color:#848484">Se�or(es)</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Receptor/sii:RznSocRecep"/>
          </td>
          <td style="font-weight:bold;color:#848484">RUT</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Receptor/sii:RUTRecep"/>
          </td>
        </tr>
		
		    <tr>
          <td style="font-weight:bold;color:#848484">Direcci�n</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Receptor/sii:DirRecep"/>
          </td>
          <td style="font-weight:bold;color:#848484">Comuna</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Receptor/sii:CmnaRecep"/>
          </td>
        </tr>
		    <tr>
          <td style="font-weight:bold;color:#848484">Nro Unidad</td>
          <td style="font-weight:bold;">:</td>
          <td >
            <b style="background:yellow">132 Matucana</b>
          </td>
          <td style="font-weight:bold;color:#848484">Ciudad</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Receptor/sii:CiudadRecep"/>
          </td>
        </tr>

        <!-- DATOS DE DIPREP -->
        <tr>
          <td style="font-weight:bold;color:#848484">Tipo</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <b style="background:yellow">Remate Juducial</b>
          </td>
          <td style="font-weight:bold;color:#848484">&#160;</td>
          <td style="font-weight:bold;">&#160;</td>
          <td>
            &#160;
          </td>
        </tr>
        
        <!-- GUIAS DE DESPACHO -->
        <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE = '52'">
        <tr>
          <td style="font-weight:bold;color:#848484">Ind.Traslado</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <xsl:choose>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '1'">Operaci�n constituye venta</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '2'">Ventas por efectuar</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '3'">Consignaciones</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '4'">Entrega gratuita</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '5'">Traslados internos</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '6'">Otros traslados no venta</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '7'">Gu�a de devoluci�n</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '8'">Traslado para exportaci�n. (no venta)</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:IndTraslado = '9'">Venta para exportaci�n</xsl:when>
            </xsl:choose>
          </td>
          <td style="font-weight:bold;color:#848484">Tipo.Desp.</td>
          <td style="font-weight:bold;">:</td>
          <td>
            <xsl:choose>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDespacho = '1'">Despacho por cuenta del receptor</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDespacho = '2'">Despacho por cuenta del emisor</xsl:when>
              <xsl:when test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDespacho = '3'">Despacho por cuenta del emisor a otras instalaciones</xsl:when>
            </xsl:choose>
          </td>
        </tr>
        </xsl:if>
        
        
    </table>
  </xsl:template>

  

  <!-- DATOS DEL DETALLE DEL DOCUMENTO -->
  <xsl:template name="DetalleDocumento">
    	
    <!-- TABLA DE DETALLE DEL DOCUMENTO -->	
    <table border="0px" cellpadding="0" cellspacing="0" class="Tabla" height="400px">
        <colgroup>
			
				<col style="width:30px;"/>
				<col style="width:80px;"/>
				<col style="width:auto"/>
				<col style="width:80px"/>
				<col style="width:80px;"/>
				<col style="width:80px;"/>
				<col style="width:80px;"/>
				<col style="width:80px;"/>
			
		</colgroup>
		<tr style="height:22px;">
			<th colspan="8" class="TablaTitulo">Detalle</th>
		</tr>
		<tr style="height:22px;">
			<th  class="TablaTitulo">Nro</th>
			<th  class="TablaTitulo">C�digo</th>
			<th  class="TablaTitulo">Detalle</th>
			<th  class="TablaTitulo">Cantidad</th>
			<th  class="TablaTitulo">Unidad</th>
			<th  class="TablaTitulo">Precio</th>
			<th  class="TablaTitulo">Descto</th>
			<th  class="TablaTitulo">Valor</th>
        </tr>

		<!-- ESPACIO INTERMEDIO -->
		<tr style="height:5px;">
			<td colspan="8"></td>
		</tr>
		
		<!-- MUESTRE AQUI EL DETALLE DEL DOCUMENTO -->
		<xsl:for-each select="sii:DTE/sii:Documento/sii:Detalle">
			<tr style="height:22px;">
				<td ><xsl:value-of select="position()"/></td>
				<td class="TablaDetalle">
				<xsl:choose>
				  <xsl:when test="sii:CdgItem/sii:VlrCodigo">
					<xsl:value-of select="sii:CdgItem/sii:VlrCodigo"/>    
				  </xsl:when>
				  <xsl:otherwise>&#160;</xsl:otherwise>
				</xsl:choose>
				</td>
				<td class="TablaDetalle">
				<xsl:choose>
				  <xsl:when test="sii:NmbItem">
					<xsl:value-of select="sii:NmbItem"/>
				  </xsl:when>
				  <xsl:otherwise>&#160;</xsl:otherwise>
				</xsl:choose>
				
				</td>
				<td class="TablaDetalle" style="text-align:right">
				<xsl:choose>
				  <xsl:when test="sii:QtyItem">
					<xsl:value-of select="format-number(sii:QtyItem,'###.###.##0,##','moneda')"/>	
				  </xsl:when>
				  <xsl:otherwise>0</xsl:otherwise>
				</xsl:choose>
				</td>
				<td class="TablaDetalle">
				 <xsl:choose>
				  <xsl:when test="sii:UnmdItem">
					  <xsl:value-of select="sii:UnmdItem"/>
				  </xsl:when>
				  <xsl:otherwise>
					&#160;
				  </xsl:otherwise>
				</xsl:choose>
				</td>
				<td class="TablaDetalle" style="text-align:right">
				<xsl:choose>
				  <xsl:when test="sii:PrcItem">
					<xsl:value-of select="format-number(sii:PrcItem,'###.###.##0,##','moneda')"/>
				  </xsl:when>
				  <xsl:otherwise>
					<xsl:value-of select="format-number('0','###.###.##0,##','moneda')"/>
				  </xsl:otherwise>
				</xsl:choose>
				</td>
				<td class="TablaDetalle" style="text-align:right">
				<xsl:choose>
				  <xsl:when test="sii:DescuentoMonto">
					<xsl:value-of select="format-number(sii:DescuentoMonto,'###.###.##0,##','moneda')"/>
				  </xsl:when>
				  <xsl:otherwise>
					<xsl:value-of select="format-number('0','###.###.##0,##','moneda')"/>
				  </xsl:otherwise>
				</xsl:choose>				
				</td>
				<td class="TablaDetalle" style="text-align:right">
					<xsl:value-of select="format-number(sii:MontoItem,'###.###.##0,##','moneda')"/>
				</td>
			</tr>
			
			<!-- COMO LLAMAR A FUNCION PARA SEPARAR DESCRIPCION ADICIONAL -->
			<xsl:if test="sii:DscItem">
				<td>&#160;</td>
			    <td>&#160;</td>
				<td>
					<xsl:call-template name="tokenize">
						<xsl:with-param name="text" select="sii:DscItem"/>
					</xsl:call-template>
				</td>
				<td>&#160;</td>
				<td>&#160;</td>
				<td>&#160;</td>
				<td>&#160;</td>
			</xsl:if>
			
			
			
		</xsl:for-each> 
		
		
		
    <!-- AGREGAR MENSAJE DE DESCUENTO -->
      <tr style="height:22px;">
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <!--<td>REBAJA 40% DE BOLETA</td>-->
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
      </tr>

      <!-- COMPLETE LA TABLA -->
      <tr>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
        <td>&#160;</td>
      </tr>
      
		
		
	</table>
	   
  </xsl:template>

  <!-- DATOS DE LA TOTALERA -->
  <xsl:template name="TotaleraDocumento">
    <table class="TotaleraDocumento" border="0px" cellpadding="0" cellspacing="0">
      <colgroup>
        <col style="width:65%;"/>
        <col style="width:35%"/>
      </colgroup>
      <tr>
        <td>
          <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE='61'">
            <xsl:call-template name="ReferenciasDocumento"/>
          </xsl:if>
          <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE='56'">
            <xsl:call-template name="ReferenciasDocumento"/>
          </xsl:if>
          <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE='39'">
            <xsl:call-template name="DatosVenta"/>
          </xsl:if>
            
        </td>
        <td>
          <xsl:call-template name="TotalesDocumento"/>
        </td>
      </tr>
    </table>
    
  </xsl:template>
  
  <!-- DATOS DE REFERENCIA DEL DOCUMENTO -->
  <xsl:template name="ReferenciasDocumento">
  
    <table class="Tabla" border="0px" cellpadding="0" cellspacing="0" style="width:99%">
      <colgroup>
        <col style="width:30%;"/>
        <col style="width:15%"/>
        <col style="width:15%"/>
        <col style="width:auto"/>
      </colgroup>
	  
	  <tr>
        <th class="TablaTitulo" colspan="4">Referencias a otros documentos.</th>
      </tr>
	  
      <tr>
        <th class="TablaTitulo">Doc.Ref</th>
        <th class="TablaTitulo">Folio</th>
        <th class="TablaTitulo">Fecha</th>
        <th class="TablaTitulo">Raz�n Ref</th>
      </tr>
      <xsl:for-each select="sii:DTE/sii:Documento/sii:Referencia">
      <tr>
        <td class="TablaDetalle" style="text-align:center">
          <b style="background:yellow">
          <xsl:call-template name="NombreDocumento">
            <xsl:with-param name="tip" select="sii:TpoDocRef"/>
          </xsl:call-template>
          </b>
        </td>
        <td class="TablaDetalle" style="padding-right:5px;">
          <b style="background:yellow">
          <xsl:value-of select="sii:FolioRef"/>
          </b>
        </td>
        <td class="TablaDetalle" style="text-align:center">
          <b style="background:yellow">
          <xsl:value-of select="sii:FchRef"/>
          </b>
        </td>
        <td class="TablaDetalle" style="padding-left:3px;padding-right:3px;">
          <b style="background:yellow">
          <xsl:value-of select="sii:RazonRef"/>
          </b>
        </td>
      </tr>
      </xsl:for-each>
      <xsl:if test="count(sii:DTE/sii:Documento/sii:Referencia)=0">
      <tr>
        <td class=" DetalleRowRight">&#160;</td>
        <td class=" DetalleRowRight">&#160;</td>
        <td class=" DetalleRowRight">&#160;</td>
        <td>&#160;</td>
      </tr>
      </xsl:if>
    </table>
  
    

  </xsl:template>

  <!-- DATOS DE REFERENCIA DEL DOCUMENTO -->
  <xsl:template name="DatosVenta">

    <table class="Tabla" border="0px" cellpadding="0" cellspacing="0" style="width:99%">
      <colgroup>
        <col style="width:30%;"/>
        <col style="width:auto"/>
      </colgroup>

      <tr>
        <th class="TablaTitulo" colspan="2">Datos de la venta</th>
      </tr>

      <!-- PRIMER DATO -->
      <tr>
        <td class="TablaDetalle" style="text-align:left">
          Tipo de Venta
        </td>
        <td class="TablaDetalle" style="padding-right:5px;">
          REMATE PLAZO VENCIDO
        </td>
      </tr>

      <!-- ULTIMO DATO -->
      <tr>
        <td class="TablaDetalle" style="text-align:left">
          Unidad
        </td>
        <td class="TablaDetalle" style="padding-right:5px;">
          SANTIAGO 1
        </td>
      </tr>


    </table>



  </xsl:template>

  <!-- DATOS DE REFERENCIA DEL DOCUMENTO -->
  <xsl:template name="TotalesDocumento">
  
	  <!-- SI EL DOCUMENTO ACTUAL ESS UNA FACTURA DE COMPRA -->
    <table class="TotalesDocumento" border="0px" cellpadding="0" cellspacing="0">
      <colgroup>
        <col style="width:50%;"/>
        <col style="width:2%"/>
        <col style="width:auto"/>
      </colgroup>

      <!-- CALCULOS -->
      <xsl:variable name="BRUTO" select="number(sii:DTE/sii:Documento/sii:Encabezado/sii:Totales/sii:MntTotal)"/>
      <xsl:variable name="EXENTO">
        <xsl:if test="not(sii:DTE/sii:Documento/sii:Encabezado/sii:Totales/sii:MntExe)">
          0
        </xsl:if>
        <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:Totales/sii:MntExe">
          <xsl:value-of select="sii:DTE/sii:Documento/sii:Encabezado/sii:Totales/sii:MntExe"/>
        </xsl:if>
      </xsl:variable>
      <xsl:variable name="BRUTO2" select="number($BRUTO)-number($EXENTO)"/>
      
      
      <!-- CALCULO DE MONTO NETO -->
      <xsl:variable name="NETO">
        <xsl:value-of select="($BRUTO2*100) div 119"/>
      </xsl:variable>
           

      <!-- CALCULO DE MONTO NETO -->
      <xsl:variable name="IVA">
        <xsl:value-of select="($NETO*19) div 100"/>
      </xsl:variable>

      <!-- MONTO NETO -->
      <!--
      <tr>
        <td style="font-weight:bold;font-size:14px">Neto $</td>
        <td>:</td>
        <td class="CeldaCantidad" style="font-size:14px">
          <xsl:value-of select="format-number(round($NETO),'###.###.##0,##','moneda')"/>
        </td>
      </tr>
      -->
      
      <!-- MONTO EXENTO -->
      <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE='61'">
      <!--<tr>
        <td style="font-weight:bold;font-size:14px">Exento $</td>
        <td>:</td>
        <td class="CeldaCantidad" style="font-size:14px">
          0
        </td>
      </tr>-->
      </xsl:if>

      <!--
      <tr>
        <td style="font-weight:bold;font-size:14px">I.V.A. (19%)</td>
        <td>:</td>
        <td class="CeldaCantidad" style="font-size:14px">
          <xsl:value-of select="format-number(round($IVA),'###.###.##0,##','moneda')"/>
        </td>
      </tr>
      -->
      
      <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:Totales/sii:MntExe>0">
      <tr>
        <td style="font-weight:bold;font-size:14px">Monto Exento $</td>
        <td>:</td>
        <td class="CeldaCantidad" style="font-size:14px">
          <xsl:value-of select="format-number($EXENTO,'###.###.##0,##','moneda')"/>
        </td>
      </tr>
      </xsl:if>
      
      <tr>
        <td style="font-weight:bold;font-size:14px">Total $</td>
        <td>:</td>
        <td class="CeldaCantidad" style="font-size:14px">
          <xsl:value-of select="format-number($BRUTO,'###.###.##0,##','moneda')"/>
        </td>
      </tr>
      
    </table>
	

			

			
			

	    
  </xsl:template>

  <!-- REPRESENTA EL TOTAL EN PALABRAS -->
  <xsl:template name="PalabrasDocumento">
    <table class="PalabrasDocumento" border="0px" cellpadding="0" cellspacing="0">
      <tr>
        <td>Total:</td>
      </tr>
    </table>
  </xsl:template>

  <!-- TIMBRE DEL DOCUMENTO ACTUAL -->
  <xsl:template name="TimbreElectronico">

    <xsl:variable name="uriPdf417Image">
      <xsl:call-template name="uriPdf417"/>
    </xsl:variable>

    <div class="TimbreElectronico">
      <img src="{$uriPdf417Image}" alt="{$uriPdf417Image}"/>
      <div style="text-align:center;padding-top:3px;">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Timbre Electr�nico SII</div>
      <div style="text-align:center;padding-top:0px;">&#160;&#160;&#160;&#160;&#160;&#160;Res. 80 de 2014 Verifique documento: http://www.DIPREP.cl//Boletas/ </div>
    </div>
  </xsl:template>


  <!-- ACUSERECIBO -->
  <xsl:template name="AcuseRecibo">
    
  <!-- Solo Aplique cuando el documento sea cedible-->
    <xsl:if test="$esCedible='True'">
      <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE!=61">
        <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE!=56">
          
        <div>
          <table width="50%" height="70" border="0" align="right" cellpadding="0" cellspacing="0" style="border:1px solid black">
            <tr>
              <td width="20%" height="12" valign="middle" class="TextoRecibo">Nombre</td>
              <td width="80%" valign="middle" align="left" class="TextoRecibo">_________________________________________________</td>
            </tr>
            <tr>
              <td height="12" valign="middle" class="TextoRecibo">R.U.T.</td>
              <td valign="middle" align="right" class="TextoRecibo">_________________________________________________</td>
            </tr>
            <tr>
              <td height="12" valign="middle" class="TextoRecibo">Fecha</td>
              <td valign="middle" align="right" class="TextoRecibo">_________________________________________________</td>
            </tr>
            <tr>
              <td height="12" valign="middle" class="TextoRecibo">Recinto</td>
              <td valign="middle" align="right" class="TextoRecibo">_________________________________________________</td>
            </tr>
            <tr>
              <td height="12" valign="middle" class="TextoRecibo">Firma</td>
              <td valign="middle" align="right" class="TextoRecibo">_________________________________________________</td>
            </tr>
            <tr>
              <td height="15" width="100%" colspan="2" align="justify" valign="bottom">
                <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
                  <tr>
                    <td class="TextoNotaRecibo" style="padding:0 0 0 0">
                      El acuse de recibo que se declara en este acto, de acuerdo a lo dispuesto en la letra b) del Art. 4�, y la letra c) del Art. 5� de la Ley 19.983, acredita que la entrega de mercader�as o servicio (s) prestado (s) ha (n) sido recibido (s).
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>    
          </div>
          
        </xsl:if>
      </xsl:if>
    </xsl:if>
  </xsl:template>

  <!-- MENSAJE CEDIBLE ( SOLO SI CORRESPONDE )-->
  <xsl:template name="MensajeCedible">
    <div style="text-align:right;padding:px 3px 0 0;">
      <xsl:if test="$esCedible='True'">
		      <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE!=61">
			      <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE!=56">
				      <!--CEDIBLE-->
			      </xsl:if>
		      </xsl:if>
          <xsl:if test="sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE=52">
            CON SU FACTURA
          </xsl:if>
      </xsl:if>  
    </div>
  </xsl:template>
  
  <!-- REPRESENTA EL FOOTER DEL DOCUMENTO -->
  <xsl:template name="FooterDocumento">
    <table class="FooterDocumento" border="0px" cellpadding="0" cellspacing="0">
      <colgroup>
        <col style="width:50%"/>
        <col style="width:50%"/>
      </colgroup>
      <tr>
        <td style="padding-right:120px">
          <xsl:call-template name="TimbreElectronico"/>
        </td>
        <td>
          &#160;<!--<xsl:call-template name="AcuseRecibo"/>-->
        </td>
      </tr>
    </table>
  </xsl:template>
 
 
 <!-- SEPARA DESCRIPCION ADICIONAL 1152 1175-->
 
 <!-- DEFINA EL RETORNO DE CARRO -->
 <xsl:variable name="_crlf"><xsl:text>|</xsl:text></xsl:variable>
 
 
 <xsl:template match="string/text()" name="tokenize">
    <xsl:param name="text" select="."/>
    <xsl:param name="sep" select="$_crlf"/>
    <xsl:choose>
        <xsl:when test="not(contains($text, $sep))">
            <div> 
                <xsl:value-of select="translate( normalize-space($text),'@', '&#160;' )"/>
            </div>
			
        </xsl:when>
        <xsl:otherwise>
			<div>
                <xsl:value-of select="normalize-space(substring-before($text, $sep))"/>
				<!-- <xsl:value-of select="normalize-space(substring-before($text, $sep))"/> -->
            </div>
			
            <xsl:call-template name="tokenize">
                <xsl:with-param name="text" select="substring-after(  translate($text,'@', '&#160;'  ), $sep )"/>
            </xsl:call-template>
			
        </xsl:otherwise>
    </xsl:choose>
</xsl:template>

</xsl:stylesheet>