using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Consultas de producción
/// </summary>
namespace Hefesto.Acuse.Recibo.Factura.Dal.Produccion
{

    /// <summary>
    /// Metodos relacionados con las consultas al SII
    /// </summary>
    internal class HefConsultas
    {

        /// <summary>
        /// Variables globales a la clase
        /// </summary>
        static string urlSII = "https://ws1.sii.cl/WSREGISTRORECLAMODTE/registroreclamodteservice";

        /// <summary>
        /// Consulta al registro de reclamos
        /// </summary>
        internal static Respuesta Hef_consultarVersion(string token)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "<soapenv:Header/>\r\n";
                sQuery += "<soapenv:Body>\r\n";
                sQuery += "    <ws:getVersion/>\r\n";
                sQuery += "</soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("cookie", Token);
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"utf-8\"";
                req.ContentLength = sQuery.Length;
                req.Host = "ws1.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida al documento XML
                XDocument xdoc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_consultarVersion";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = xdoc.ToString();

            }
            catch (Exception ex)
            {
                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_consultarVersion";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta al registro de reclamos
        /// </summary>
        internal static Respuesta Hef_consultarDocDteCedible(string rutEmisor, string tipoDoc, string folio, string token)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:consultarDocDteCedible>\r\n";
                sQuery += "         <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "         <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "         <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "         <folio>" + folio + "</folio>\r\n";
                sQuery += "      </ws:consultarDocDteCedible>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("cookie", Token);
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"utf-8\"";
                req.ContentLength = sQuery.Length;
                req.Host = "ws1.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida al documento XML
                XDocument xdoc = XDocument.Parse(sResultado);


                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_consultarDocDteCedible";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = xdoc.ToString();

            }
            catch (Exception ex)
            {
                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_consultarDocDteCedible";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta al SII por la fecha de recepción de un documento DTE
        /// </summary>
        /// <returns></returns>
        internal static Respuesta Hef_ConsultaFechaRecepcionDte(string rutEmisor, string tipoDoc, string folio, string token)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {


                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:consultarFechaRecepcionSii>\r\n";
                sQuery += "         <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "         <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "         <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "         <folio>" + folio + "</folio>\r\n";
                sQuery += "      </ws:consultarFechaRecepcionSii>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("cookie", Token);
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"utf-8\"";
                req.ContentLength = sQuery.Length;
                req.Host = "ws1.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida
                XDocument doc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_consultarFechaRecepcionSii";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = doc.ToString();

            }
            catch (Exception ex)
            {

                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_consultarFechaRecepcionSii";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rutEmisor"></param>
        /// <param name="tipoDoc"></param>
        /// <param name="folio"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        internal static Respuesta Hef_ConsultarHistorialDte(string rutEmisor, string tipoDoc, string folio, string token)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:listarEventosHistDoc>\r\n";
                sQuery += "          <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "          <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "          <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "          <folio>" + folio + "</folio>\r\n";
                sQuery += "      </ws:listarEventosHistDoc>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("cookie", Token);
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"utf-8\"";
                req.ContentLength = sQuery.Length;
                req.Host = "ws1.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida
                XDocument doc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_listarEventosHistDoc";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = doc.ToString();

            }
            catch (Exception ex)
            {

                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_listarEventosHistDoc";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Agregar evento al documento DTE
        /// Aceptar
        /// Rechazar
        /// Recibo mercaderias
        /// Recibo mercaderias parciales
        /// </summary>
        internal static Respuesta Hef_AgregarEventoDte(string rutEmisor, string tipoDoc, string folio, string token, enumAcciones Acciones)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {


                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Recupere el literal del emun de acciones
                string accion = Acciones.ToString().Split('_')[0];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:ingresarAceptacionReclamoDoc>\r\n";
                sQuery += "         <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "         <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "         <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "         <folio>" + folio + "</folio>\r\n";
                sQuery += "         <accionDoc>" + accion + "</accionDoc>\r\n";
                sQuery += "      </ws:ingresarAceptacionReclamoDoc>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("cookie", Token);
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"utf-8\"";
                req.ContentLength = sQuery.Length;
                req.Host = "ws1.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida
                XDocument doc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_AgregarEventoDte";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = doc.ToString();

            }
            catch (Exception ex)
            {

                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_AgregarEventoDte";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }


    }


}

/// <summary>
/// Consultas de certificacion
/// </summary>
namespace Hefesto.Acuse.Recibo.Factura.Dal.Certificacion
{

    /// <summary>
    /// Metodos relacionados con las consultas al SII
    /// </summary>
    internal class HefConsultas
    {


        /// <summary>
        /// Variables globales a la clase
        /// </summary>
        static string urlSII = "https://ws2.sii.cl/WSREGISTRORECLAMODTECERT/registroreclamodteservice";

        /// <summary>
        /// Consulta al registro de reclamos
        /// </summary>
        internal static Respuesta Hef_consultarVersion(string token)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();
                        
            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "<soapenv:Header/>\r\n";
                sQuery += "<soapenv:Body>\r\n";
                sQuery += "    <ws:getVersion/>\r\n";
                sQuery += "</soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"UTF-8\"";
                req.Headers.Add("SOAPAction", "");
                req.Headers.Add("cookie", Token);
                req.ContentLength = sQuery.Length;
                req.Host = "ws2.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.5.5 (java/12.0.1)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida al documento XML
                XDocument xdoc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_consultarVersion";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = xdoc.ToString();

            }
            catch (Exception ex)
            {
                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_consultarVersion";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta al registro de reclamos
        /// </summary>
        internal static Respuesta Hef_consultarDocDteCedible(string rutEmisor, string tipoDoc, string folio, string token)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:consultarDocDteCedible>\r\n";
                sQuery += "         <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "         <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "         <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "         <folio>" + folio + "</folio>\r\n";
                sQuery += "      </ws:consultarDocDteCedible>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"UTF-8\"";
                req.Headers.Add("SOAPAction", "");
                req.Headers.Add("cookie", Token);
                req.ContentLength = sQuery.Length;
                req.Host = "ws2.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.5.5 (java/12.0.1)";
                req.AutomaticDecompression = DecompressionMethods.GZip;




                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida al documento XML
                XDocument xdoc = XDocument.Parse(sResultado);


                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_consultarDocDteCedible";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = xdoc.ToString();

            }
            catch (Exception ex)
            {
                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_consultarDocDteCedible";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta al SII por la fecha de recepción de un documento DTE
        /// </summary>
        /// <returns></returns>
        internal static Respuesta Hef_ConsultaFechaRecepcionDte(string rutEmisor, string tipoDoc, string folio, string token)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:consultarFechaRecepcionSii>\r\n";
                sQuery += "         <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "         <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "         <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "         <folio>" + folio + "</folio>\r\n";
                sQuery += "      </ws:consultarFechaRecepcionSii>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"UTF-8\"";
                req.Headers.Add("SOAPAction", "");
                req.Headers.Add("cookie", Token);
                req.ContentLength = sQuery.Length;
                req.Host = "ws2.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.5.5 (java/12.0.1)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida
                XDocument doc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_consultarFechaRecepcionSii";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = doc.ToString();

            }
            catch (Exception ex)
            {

                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_consultarFechaRecepcionSii";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rutEmisor"></param>
        /// <param name="tipoDoc"></param>
        /// <param name="folio"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        internal static Respuesta Hef_ConsultarHistorialDte(string rutEmisor, string tipoDoc, string folio, string token)
        {
            

            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:listarEventosHistDoc>\r\n";
                sQuery += "          <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "          <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "          <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "          <folio>" + folio + "</folio>\r\n";
                sQuery += "      </ws:listarEventosHistDoc>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"UTF-8\"";
                req.Headers.Add("SOAPAction", "");
                req.Headers.Add("cookie", Token);
                req.ContentLength = sQuery.Length;
                req.Host = "ws2.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.5.5 (java/12.0.1)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida
                XDocument doc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_listarEventosHistDoc";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = doc.ToString();

            }
            catch (Exception ex)
            {

                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_listarEventosHistDoc";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Agregar evento al documento DTE
        /// Aceptar
        /// Rechazar
        /// Recibo mercaderias
        /// Recibo mercaderias parciales
        /// </summary>
        internal static Respuesta Hef_AgregarEventoDte(string rutEmisor, string tipoDoc, string folio, string token, enumAcciones Acciones)
        {
            ////
            //// Inicie la respuesta del proceso
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {


                ////
                //// Recupere el token y de formato de salida
                string Token = string.Format("TOKEN={0}", token);

                ////
                //// Parsee el rutEmisor
                string Rut = rutEmisor.Split('-')[0];
                string Dvf = rutEmisor.Split('-')[1];

                ////
                //// Recupere el literal del emun de acciones
                string accion = Acciones.ToString().Split('_')[0];

                ////
                //// Cree el sobre de la consulta SOAP
                string sQuery = string.Empty;
                sQuery += "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.registroreclamodte.diii.sdi.sii.cl\">\r\n";
                sQuery += "   <soapenv:Header/>\r\n";
                sQuery += "   <soapenv:Body>\r\n";
                sQuery += "      <ws:ingresarAceptacionReclamoDoc>\r\n";
                sQuery += "         <rutEmisor>" + Rut + "</rutEmisor>\r\n";
                sQuery += "         <dvEmisor>" + Dvf + "</dvEmisor>\r\n";
                sQuery += "         <tipoDoc>" + tipoDoc + "</tipoDoc>\r\n";
                sQuery += "         <folio>" + folio + "</folio>\r\n";
                sQuery += "         <accionDoc>" + accion + "</accionDoc>\r\n";
                sQuery += "      </ws:ingresarAceptacionReclamoDoc>\r\n";
                sQuery += "   </soapenv:Body>\r\n";
                sQuery += "</soapenv:Envelope>\r\n";

                ////
                //// Comprobar que la consulta este bien construída
                XmlDocument xSobre = new XmlDocument();
                xSobre.PreserveWhitespace = true;
                xSobre.LoadXml(sQuery);

                ////
                //// Cree la conección al webservice.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSII);
                req.Method = "POST";
                req.Headers.Add("Accept-Encoding", "gzip,deflate");
                req.ContentType = "text/xml; charset=\"UTF-8\"";
                req.Headers.Add("SOAPAction", "");
                req.Headers.Add("cookie", Token);
                req.ContentLength = sQuery.Length;
                req.Host = "ws2.sii.cl";
                req.UserAgent = "Apache-HttpClient/4.5.5 (java/12.0.1)";
                req.AutomaticDecompression = DecompressionMethods.GZip;

                ////
                //// Suministre la información al webservice
                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(sQuery);
                    }
                }

                ////
                //// Recupere el objeto response ( respuesta del webservice ) 
                WebResponse response = req.GetResponse();

                ////
                //// Recupere los datos que se encuentran el la respuesta del webservice
                Stream responseStream = response.GetResponseStream();

                ////
                //// Escriba los datos recuperados en un string
                string sResultado = string.Empty;
                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    sResultado = reader.ReadToEnd();
                }

                ////
                //// De formato de salida
                XDocument doc = XDocument.Parse(sResultado);

                ////
                //// Regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Mensaje = "Hef_AgregarEventoDte";
                resp.Detalle = "Proceso exitoso";
                resp.Resultado = doc.ToString();

            }
            catch (Exception ex)
            {

                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Mensaje = "Hef_AgregarEventoDte";
                resp.Detalle = "No fue posible realizar la acción.\r\n" + ex.Message;
                resp.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }


    }


}



