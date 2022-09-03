using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using HEFESTO.CONSULTA.TRACKID;
using HEFESTO.CONSULTA.TRACKID.AUTENTICACION;

namespace HEFESTO.CLASS.CORE.AUTENTICACION
{
    public class CONSULTASSII
    {
        /// <summary>
        /// Recuperar el estado de un trackid
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultarTrackId(string RutEmpresa, string Trackid, string Token, SIIAmbiente ambiente)
        {

            ////
            //// Inicie la respuesta de este metodo
            Respuesta resp = new Respuesta();
            
            ////
            //// Parse de datos
            string rut = RutEmpresa.Split('-')[0];
            string dig = RutEmpresa.Split('-')[1];

            ////
            //// Recupere el resultaldo en string
            string respuestaSII = string.Empty;

            ////
            //// Consulte
            try
            {

                ////
                //// Ejecute la consulta en certificacion
                if (ambiente == SIIAmbiente.Certificacion)
                {
                    HEFESTO.CONSULTA.TRACKID.CERTIFICACION.QueryEstUpService query = new HEFESTO.CONSULTA.TRACKID.CERTIFICACION.QueryEstUpService();
                    respuestaSII = query.getEstUp(rut, dig, Trackid, Token);

                }

                ////
                //// Ejecute la consulta en certificacion
                if (ambiente == SIIAmbiente.Produccion)
                {
                    HEFESTO.CONSULTA.TRACKID.PRODUCCION.QueryEstUpService query = new HEFESTO.CONSULTA.TRACKID.PRODUCCION.QueryEstUpService();
                    respuestaSII = query.getEstUp(rut, dig, Trackid, Token);
                }    


            }
            catch (Exception ex)
            {

                resp.EsCorrecto = false;
                resp.Mensaje = "No fue posible consultar el trackid del documento";
                resp.Detalle = ex.Message;
                resp.Resultado = null;
                return resp;

            }


            ////
            //// Si hay una respuesta desde el SII interpretala
            if (string.IsNullOrEmpty(respuestaSII))
            {

                resp.EsCorrecto = false;
                resp.Mensaje = "El SII no suministro respuesta a la consulta Trackid";
                resp.Resultado = null;
                return resp;
            
            }

            ////
            //// Lea la respuesta para su interpretacion.
            XmlDocument xmlRespuesta = new XmlDocument();
            xmlRespuesta.PreserveWhitespace = true;
            xmlRespuesta.LoadXml(respuestaSII);


            ////
            //// Asigne el namespace manager
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlRespuesta.NameTable);
            ns.AddNamespace("SII", xmlRespuesta.DocumentElement.NamespaceURI);

            ////
            //// Recupere el estado del documento.
            XmlNode ESTADO = xmlRespuesta.SelectSingleNode("SII:RESPUESTA/SII:RESP_HDR/ESTADO",ns);
            if (ESTADO == null)
            {

                resp.EsCorrecto = false;
                resp.Mensaje = "No fue posible leer la respuesta del estado del documento DTE.";
                resp.Resultado = null;
                return resp;
            
            }


            ////
            //// Identifique la respuesta del documento.
            entRespuestaDTE RespuestaDte = new entRespuestaDTE();
            switch (ESTADO.InnerText)
            {
                case "LOK":
                    //// <?xml version="1.0" encoding="UTF-8"?>
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////      <SII:RESP_HDR>
                    ////          <TRACKID>0023757328</TRACKID>
                    ////          <ESTADO>LOK</ESTADO>
                    ////          <GLOSA>Envio de Libro Aceptado - Cuadrado</GLOSA>
                    ////          <NUM_ATENCION>502614   ( 2014/07/16 21:22:35)</NUM_ATENCION>
                    ////      </SII:RESP_HDR>
                    ////  </SII:RESPUESTA>

                    RespuestaDte.Estado = "LOK";
                    RespuestaDte.Glosa = "Envio de Libro Aceptado - Cuadrado";
                    break;


                case "LSO":
                    //// <?xml version="1.0" encoding="UTF-8"?>
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////     <SII:RESP_HDR>
                    ////         <TRACKID>0023758910</TRACKID>
                    ////         <ESTADO>LSO</ESTADO>
                    ////         <GLOSA>Schema de Envio de Libro Correcto</GLOSA>
                    ////         <NUM_ATENCION>524691   ( 2014/07/17 00:20:02)</NUM_ATENCION>
                    ////     </SII:RESP_HDR>
                    //// </SII:RESPUESTA>

                    RespuestaDte.Estado = "LSO";
                    RespuestaDte.Glosa = "Schema de Envio de Libro Correcto, vuelva a consultar.";
                    break;

                case "LNC":
                    
                    //// <?xml version="1.0" encoding="UTF-8"?>
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////     <SII:RESP_HDR>
                    ////         <TRACKID>0023758982</TRACKID>
                    ////         <ESTADO>LNC</ESTADO>
                    ////         <GLOSA>Tipo de Envio de Libro No Corresponde</GLOSA>
                    ////         <NUM_ATENCION>525986   ( 2014/07/17 00:29:07)</NUM_ATENCION>
                    ////     </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "LNC";
                    RespuestaDte.Glosa = "Tipo de Envio de Libro No Corresponde, libro enviado anteriormente.";
                    break;


                case "LRH":
                    //// <?xml version="1.0" encoding="UTF-8"?>
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////     <SII:RESP_HDR>
                    ////         <TRACKID>0023753952</TRACKID>
                    ////         <ESTADO>LRH</ESTADO>
                    ////         <GLOSA>Envio de Libro Rechazado - Descuadrado</GLOSA>
                    ////         <NUM_ATENCION>457958   ( 2014/07/16 15:48:59)</NUM_ATENCION>
                    ////     </SII:RESP_HDR>
                    //// </SII:RESPUESTA>

                    RespuestaDte.Estado = "LRH";
                    RespuestaDte.Glosa = "Envio de Libro Rechazado - Descuadrado";
                    break;



                case "LRC":
                    //// <?xml version="1.0" encoding="UTF-8"?>
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////     <SII:RESP_HDR>
                    ////         <TRACKID>0023753100</TRACKID>
                    ////         <ESTADO>LRC</ESTADO>
                    ////         <GLOSA>Caratula de Envio de Libro Invalida</GLOSA>
                    ////         <NUM_ATENCION>445839   ( 2014/07/16 14:34:37)</NUM_ATENCION>
                    ////     </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "LRC";
                    RespuestaDte.Glosa = "Caratula de Envio de Libro Invalida";
                    break;

                case "LRF":
                    //// <?xml version="1.0" encoding="UTF-8"?>
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////     <SII:RESP_HDR>
                    ////         <TRACKID>0023665026</TRACKID>
                    ////         <ESTADO>LRF</ESTADO>
                    ////         <GLOSA>Envio de Libro Rechazado por Firma</GLOSA>
                    ////         <NUM_ATENCION>233670   ( 2014/07/09 09:17:42)</NUM_ATENCION>
                    ////     </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "LRF";
                    RespuestaDte.Glosa = "Envio de Libro Rechazado por Firma";


                    break;

                case "RSC":
                    ////
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>RSC</ESTADO>
                    ////        <GLOSA>Rechazado por Error en Schema</ GLOSA >
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "RSC";
                    RespuestaDte.Glosa = "Rechazado por Error en Schema";
                    break;

                case "SDK":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>SDK</ESTADO>
                    ////        <GLOSA >Schema Validado</ GLOSA >
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "SDK";
                    RespuestaDte.Glosa = "Schema Validado";
                    break;

                case "CRT":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>CRT</ESTADO>
                    ////        <GLOSA >Caratula OK</ GLOSA >
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "CRT";
                    RespuestaDte.Glosa = "Caratula OK";
                    break;

                case "RFR":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>RFR</ESTADO>
                    ////        <GLOSA>Rechazado por Error en Firma</GLOSA>
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA
                    RespuestaDte.Estado = "RFR";
                    RespuestaDte.Glosa = "Rechazado por Error en Firma";
                    break;

                case "05":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>05</ESTADO>
                    ////        <GLOSA>Error: RETORNO DATOS</GLOSA>
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "05";
                    RespuestaDte.Glosa = "Error: RETORNO DATOS";
                    break;

                case "PRD":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>PRD</ESTADO>
                    ////        <GLOSA>Error Retorno Datos</GLOSA>
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "PRD";
                    RespuestaDte.Glosa = "Error Retorno Datos";
                    break;

                case "RCT":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>RCT</ESTADO>
                    ////        <GLOSA>Rechazado por Error en Carátula</GLOSA>
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "RCT";
                    RespuestaDte.Glosa = "Rechazado por Error en Carátula";
                    break;

                case "EPR":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <TRACKID>251</TRACKID>
                    ////        <ESTADO>EPR</ESTADO>
                    ////        <GLOSA>Envio Procesado</GLOSA>
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    ////   <SII:RESP_BODY>
                    ////        <TIPO_DOCTO>33</TIPO_DOCTO>
                    ////        <INFORMADOS>1</INFORMADOS>
                    ////        <ACEPTADOS>1</ACEPTADOS>
                    ////        <RECHAZADOS>0</RECHAZADOS>
                    ////        <REPAROS>0</REPAROS>
                    ////    </SII:RESP_BODY>
                    //// </SII:RESPUESTA>


                    ////
                    //// Recupere el estado del documento
                    string EstadoDTE = string.Empty;
                    XmlElement node = (XmlElement)xmlRespuesta.SelectSingleNode("SII:RESPUESTA/SII:RESP_BODY/ACEPTADOS", ns);
                    if (node != null)
                    {
                        if (node.InnerText == "1")
                            EstadoDTE = "ACEPTADO";
                    }
                    node = (XmlElement)xmlRespuesta.SelectSingleNode("SII:RESPUESTA/SII:RESP_BODY/RECHAZADOS", ns);
                    if (node != null)
                    {
                        if (node.InnerText == "1")
                            EstadoDTE = "RECHAZADO";
                    }
                    node = (XmlElement)xmlRespuesta.SelectSingleNode("SII:RESPUESTA/SII:RESP_BODY/REPAROS", ns);
                    if (node != null)
                    {
                        if (node.InnerText == "1")
                            EstadoDTE = "ACEPTADO CON REPAROS";
                    }

                    RespuestaDte.Estado = "EPR";
                    RespuestaDte.Glosa = "Envio Procesado";
                    RespuestaDte.EstadoDTE = EstadoDTE;
                    break;

                case "-11":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-11</ESTADO>
                    ////        <ERR_CODE/>
                    ////        <SQL_CODE/>
                    ////        <SRV_CODE/>1</ERR_CODE>
                    ////        <NUM_ATENCION>532 ( 2004/06/14 16:44:20)</NUM_ATENCION>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-11";
                    RespuestaDte.Glosa = "ERROR: De proceso";
                    break;

                case "-3":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema"> - <SII:RESP_HDR>
                    ////        <ESTADO>-3</ESTADO>
                    ////        <GLOSA>ERROR : RUT USUARIO NO EXISTE </GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-3";
                    RespuestaDte.Glosa = "ERROR : RUT USUARIO NO EXISTE";
                    break;

                case "-4":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-4</ESTADO>
                    ////        <GLOSA>ERROR : OBTENCIÓN DE DATOS  </GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-4";
                    RespuestaDte.Glosa = "ERROR : OBTENCIÓN DE DATOS";
                    break;

                case "-5":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-5</ESTADO>
                    ////        <GLOSA>ERROR : RETORNO DE DATOS</GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-5";
                    RespuestaDte.Glosa = "ERROR : RETORNO DE DATOS";
                    break;

                case "-6":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-6</ESTADO>
                    ////        <GLOSA>ERROR :USUARIO NO AUTORIZADO</GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-6";
                    RespuestaDte.Glosa = "ERROR :USUARIO NO AUTORIZADO";
                    break;

                case "-7":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-7</ESTADO>
                    ////        <GLOSA>ERROR: RETORNO DATOS </GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-7";
                    RespuestaDte.Glosa = "ERROR: RETORNO DATOS ";
                    break;

                case "-8":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-8</ESTADO>
                    ////        <GLOSA>ERROR: RETORNO DE DATOS </GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-8";
                    RespuestaDte.Glosa = "ERROR: RETORNO DE DATOS ";
                    break;

                case "-9":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-9</ESTADO>
                    ////        <GLOSA>ERROR: RETORNO DE DATOS </GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-9";
                    RespuestaDte.Glosa = "ERROR: RETORNO DE DATOS ";
                    break;

                case "-10":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-10</ESTADO>
                    ////        <GLOSA>ERROR: VALIDA RUT </GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-10";
                    RespuestaDte.Glosa = "ERROR: VALIDA RUT";
                    break;

                case "-12":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-12</ESTADO>
                    ////        <GLOSA>ERROR: RETORNO DATOS </GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA> 
                    RespuestaDte.Estado = "-12";
                    RespuestaDte.Glosa = "ERROR: RETORNO DATOS ";
                    break;

                case "-13":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-13</ESTADO>
                    ////        <GLOSA>ERROR: RUT USUARIO</GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-13";
                    RespuestaDte.Glosa = "ERROR: USUARIO NULO";
                    break;

                case "-14":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>-14</ESTADO>
                    ////        <GLOSA>ERROR: XML RETORNO</GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "-14";
                    RespuestaDte.Glosa = "ERROR: XML RETORNO";
                    break;

                case "002":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>002</ESTADO>
                    ////        <GLOSA>TOKEN+INACTIVO</GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "002";
                    RespuestaDte.Glosa = "TOKEN+INACTIVO";
                    break;

                case "003":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>003</ESTADO>
                    ////        <GLOSA>NO+EXISTE</GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA>
                    RespuestaDte.Estado = "003";
                    RespuestaDte.Glosa = "TOKEN NO EXISTE";
                    break;

                case "001":
                    //// Ejemplo de respuesta
                    //// <SII:RESPUESTA xmlns:SII="http://www.sii.cl/XMLSchema">
                    ////    <SII:RESP_HDR>
                    ////        <ESTADO>001</ESTADO>
                    ////        <GLOSA>COOKIE INACTIVO</GLOSA>
                    ////    </SII:RESP_HDR>
                    //// </SII:RESPUESTA> 
                    RespuestaDte.Estado = "001";
                    RespuestaDte.Glosa = "COOKIE INACTIVO";
                    break;



                default:
                    RespuestaDte.Estado = "XXX";
                    RespuestaDte.Glosa = "No se reconoce la respuesta del SII.";
                    break;
            }


            RespuestaDte.Glosa = respuestaSII;



            ////
            //// Construya la respuesta de salida
            resp.EsCorrecto = true;
            resp.Resultado = RespuestaDte;

            ////
            //// Si no hay Respuesta regrese error.
            return resp;

        
        }

        


    }
}
