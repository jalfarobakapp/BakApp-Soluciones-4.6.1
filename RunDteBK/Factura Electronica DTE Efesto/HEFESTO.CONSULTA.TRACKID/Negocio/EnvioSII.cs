using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using HEFESTO.CLASS.CORE.AUTENTICACION;

namespace HEFESTO.CONSULTA.TRACKID.Negocio
{
    public class EnvioSII
    {

            /// <summary>
            /// Constantes a utilizar
            /// </summary>
            const string URL_CERTIFICACION = "https://maullin.sii.cl/cgi_dte/UPL/DTEUpload";
            const string URL_PRODUCCION = "https://palena.sii.cl/cgi_dte/UPL/DTEUpload";

            /// <summary>
            /// Regresa el estado de un determinado envio al SII, utiliza el
            /// archivo de respuesta generado por el SII para identificar el
            /// estado actual del envio.
            /// </summary>
            /// <param name="uri">uri del archivo fisico</param>
            public static Respuesta RecuperarEstadoByRespuesta(XmlDocument xmlRespuesta)
            {

                ////
                //// Inicie la Respuesta
                Respuesta respuesta = new Respuesta();

                ////
                //// Constantes del documento
                const string HESTATUS = "RECEPCIONDTE/STATUS";

                ////
                //// Recupere el estado del documento
                try
                {

                    XmlElement nodeEstatus = (XmlElement)xmlRespuesta.SelectSingleNode(HESTATUS);
                    if (nodeEstatus != null)
                    {

                        ////
                        //// Inicie la entidad de resultado de estados
                        entRecepcionDTE rd = new entRecepcionDTE();

                        ////
                        //// Inicie la interpretacion del resultado
                        switch (nodeEstatus.InnerText)
                        {
                            case "0":
                                rd.EstadoID = 0;
                                rd.EstadoLiteral = "Upload OK";
                                break;

                            case "1":
                                rd.EstadoID = 1;
                                rd.EstadoLiteral = "El Sender no tiene permiso para enviar.";
                                break;

                            case "2":
                                rd.EstadoID = 2;
                                rd.EstadoLiteral = "Error en tamaño del archivo (muy grande o muy chico).";
                                break;

                            case "3":
                                rd.EstadoID = 3;
                                rd.EstadoLiteral = "Archivo cortado (tamaño <> al parámetro size).";
                                break;

                            case "5":
                                rd.EstadoID = 5;
                                rd.EstadoLiteral = "No está autenticado.";
                                break;

                            case "6":
                                rd.EstadoID = 6;
                                rd.EstadoLiteral = "Empresa no autorizada a enviar archivos.";
                                break;

                            case "7":
                                rd.EstadoID = 7;
                                rd.EstadoLiteral = "Esquema Invalido.";
                                break;

                            case "8":
                                rd.EstadoID = 8;
                                rd.EstadoLiteral = "Firma del Documento.";
                                break;

                            case "9":
                                rd.EstadoID = 9;
                                rd.EstadoLiteral = "Sistema Bloqueado";
                                break;

                            default:
                                rd.EstadoID = -1;
                                rd.EstadoLiteral = "Otros - Error Interno";
                                break;

                        }

                        ////
                        //// Regrese el valor de retorno
                        respuesta.EsCorrecto = true;
                        respuesta.Resultado = rd;


                    }
                    else
                    {
                        throw new Exception("No fue posible rescatar el nodo status del archivo xml.");
                    }

                }
                catch (Exception ex)
                {
                    respuesta.EsCorrecto = false;
                    respuesta.Mensaje = "No fue posible leer el archivo de respuesta.";
                    respuesta.Detalle = ex.Message;
                    respuesta.Resultado = null;
                }


                ////
                //// Regrese el valor de retorno del proceso
                return respuesta;


            }

            /// <summary>
            /// Regresa el estado de un determinado envio al SII, utiliza el
            /// archivo de respuesta generado por el SII para identificar el
            /// estado actual del envio.
            /// </summary>
            /// <param name="Cadena">string regresado por el SII</param>
            public static Respuesta RecuperarEstadoByRespuesta(string Cadena)
            {

                ////
                //// Inicie la Respuesta
                Respuesta respuesta = new Respuesta();

                ////
                //// Constantes del documento
                const string HESTATUS = "RECEPCIONDTE/STATUS";


                ////
                //// Recupere el estado del documento
                try
                {
                    ////
                    //// Cree el documento xml basandose en la cadena
                    XmlDocument xmlRespuesta = new XmlDocument();
                    xmlRespuesta.PreserveWhitespace = true;
                    xmlRespuesta.LoadXml(Cadena);

                    ////
                    //// Rescate el nodo status
                    XmlElement nodeEstatus = (XmlElement)xmlRespuesta.SelectSingleNode(HESTATUS);
                    if (nodeEstatus != null)
                    {

                        ////
                        //// Inicie la entidad de resultado de estados
                        entRecepcionDTE rd = new entRecepcionDTE();

                        ////
                        //// Inicie la interpretacion del resultado
                        switch (nodeEstatus.InnerText)
                        {
                            case "0":
                                rd.EstadoID = 0;
                                rd.EstadoLiteral = "Upload OK";
                                break;

                            case "1":
                                rd.EstadoID = 1;
                                rd.EstadoLiteral = "El Sender no tiene permiso para enviar.";
                                break;

                            case "2":
                                rd.EstadoID = 2;
                                rd.EstadoLiteral = "Error en tamaño del archivo (muy grande o muy chico).";
                                break;

                            case "3":
                                rd.EstadoID = 3;
                                rd.EstadoLiteral = "Archivo cortado (tamaño <> al parámetro size).";
                                break;

                            case "5":
                                rd.EstadoID = 5;
                                rd.EstadoLiteral = "No está autenticado.";
                                break;

                            case "6":
                                rd.EstadoID = 6;
                                rd.EstadoLiteral = "Empresa no autorizada a enviar archivos.";
                                break;

                            case "7":
                                rd.EstadoID = 7;
                                rd.EstadoLiteral = "Esquema Invalido.";
                                break;

                            case "8":
                                rd.EstadoID = 8;
                                rd.EstadoLiteral = "Firma del Documento.";
                                break;

                            case "9":
                                rd.EstadoID = 9;
                                rd.EstadoLiteral = "Sistema Bloqueado";
                                break;

                            default:
                                rd.EstadoID = -1;
                                rd.EstadoLiteral = "Otros - Error Interno";
                                break;

                        }

                        ////
                        //// Regrese el valor de retorno
                        respuesta.EsCorrecto = true;
                        respuesta.Resultado = rd;

                    }
                    else
                    {
                        throw new Exception("No fue posible rescatar el nodo status del archivo xml.");
                    }

                }
                catch (Exception ex)
                {
                    respuesta.EsCorrecto = false;
                    respuesta.Mensaje = "No fue posible leer el archivo de respuesta.";
                    respuesta.Detalle = ex.Message;
                    respuesta.Resultado = null;
                }


                ////
                //// Regrese el valor de retorno del proceso
                return respuesta;


            }

            /// <summary>
            /// Recuperar el estado de un trackid
            /// </summary>
            /// <returns></returns>
            public static Respuesta ConsultarTrackId(string RutEmpresa, X509Certificate2 certificado, string Trackid, SIIAmbiente ambiente)
            {

                ////
                //// Inicie la respuesta de este metodo
                Respuesta r = new Respuesta();

                ////
                //// Recupere el token
                string Token = string.Empty;
                Respuesta respuesta = LOGIN.Conectar(certificado, ambiente);

                ////
                //// Recupere el token
                if (respuesta.EsCorrecto)
                {
                    Token = (string)respuesta.Resultado;
                }
                else
                {
                    return respuesta;
                }

                ////
                //// Valide que exista token
                if (string.IsNullOrEmpty(Token))
                    return respuesta;


                ////
                //// Inicie la consulta del trackid
                Respuesta resp = CONSULTASSII.ConsultarTrackId(RutEmpresa, Trackid, Token, ambiente);


                ////
                //// Regrese la respuesta
                return resp;
            }

            /// <summary>
            /// Envia un determinado archivo al SII
            /// </summary>
            public static Respuesta EnviarArchivoSII(string archivo, string token, string pRutEmisor, string pDigEmisor, string pRutEmpresa, string pDigEmpresa, SIIAmbiente ambiente = SIIAmbiente.Certificacion)
            {

                ////
                //// Inicialice el objeto respuesta
                Respuesta respuesta = new Respuesta();


                ////
                //// Parametros
                string pNombreArchivo = archivo;
                string pNombreArchivoShort = Path.GetFileName(archivo);

                #region  CREAR HEADER DEL ENVIO

                ////
                //// Construya los encabezados del documento 
                string secuencia = string.Empty;
                secuencia += "--7d23e2a11301c4\r\n";
                secuencia += "Content-Disposition: form-data; name=\"rutSender\"\r\n";
                secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
                secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
                secuencia += "\r\n";
                secuencia += pRutEmisor + "\r\n";
                secuencia += "--7d23e2a11301c4\r\n";
                secuencia += "Content-Disposition: form-data; name=\"dvSender\"\r\n";
                secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
                secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
                secuencia += "\r\n";
                secuencia += pDigEmisor + "\r\n";
                secuencia += "--7d23e2a11301c4\r\n";
                secuencia += "Content-Disposition: form-data; name=\"rutCompany\"\r\n";
                secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
                secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
                secuencia += "\r\n";
                secuencia += pRutEmpresa + "\r\n";
                secuencia += "--7d23e2a11301c4\r\n";
                secuencia += "Content-Disposition: form-data; name=\"dvCompany\"\r\n";
                secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
                secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
                secuencia += "\r\n";
                secuencia += pDigEmpresa + "\r\n";
                secuencia += "--7d23e2a11301c4\r\n";
                secuencia += "Content-Disposition: form-data; name=\"archivo\"; filename=\"" + pNombreArchivoShort + "\" \r\n";
                secuencia += "Content-Type: application/octet-stream\r\n";
                secuencia += "Content-Transfer-Encoding: binary\r\n";
                secuencia += "\r\n";


                ////
                //// Agregue el documento xml utilizando streamreader pues utilizar xdocument
                //// realiza interpretacion de los caracteres .
                string strDocumento = string.Empty;
                using (StreamReader sr = new StreamReader(pNombreArchivo, Encoding.GetEncoding("ISO-8859-1")))
                {
                    strDocumento = sr.ReadToEnd();
                }

                ////
                //// Escriba el final de la secuencia
                secuencia += strDocumento;
                secuencia += "\r\n";
                secuencia += "--7d23e2a11301c4--\r\n";

                #endregion

                ////
                //// Aqui se configura el request que hace la solicitud al SII
                #region CONFIGURACION DE REQUEST

                ////
                //// Defina que ambiente utilizar.
                string pUrl = (SIIAmbiente.Certificacion == ambiente) ? URL_CERTIFICACION : URL_PRODUCCION;

                ////
                //// Cree los parametros del header.
                string pMethod = "POST";
                string pAccept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-powerpoint, application/ms-excel, application/msword, */*";
                string pReferer = "www.hefestoDte.cl";
                string pToken = "TOKEN={0}";

                ////
                //// Cree un nuevo request para iniciar el proceso
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pUrl);
                request.Method = pMethod;
                request.Accept = pAccept;
                request.Referer = pReferer;

                ////
                //// Agregar el content-type
                request.ContentType = "multipart/form-data: boundary=7d23e2a11301c4";
                request.ContentLength = secuencia.Length;

                ////
                //// Defina manualmente los headers del request
                request.Headers.Add("Accept-Language", "es-cl");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Cookie", string.Format(pToken, token));

                ////
                //// Defina el user agent
                request.UserAgent = "Mozilla/4.0 (compatible; PROG 1.0; Windows NT 5.0; YComp 5.0.2.4)";
                request.KeepAlive = true;

                #endregion

                ////
                //// Escritura del request
                #region ESCRIBE LA DATA NECESARIA

                ////
                //// Recupere el streamwriter para escribir la secuencia
                try
                {

                    using (StreamWriter sw = new StreamWriter(request.GetRequestStream(), Encoding.GetEncoding("ISO-8859-1")))
                    {
                        sw.Write(secuencia);
                    }

                }
                catch (Exception ex)
                {
                    respuesta.EsCorrecto = false;
                    respuesta.Mensaje = "No fue posible escribir en el request la cadena RFC1867\r\nEsto se debe a un error en el formato del documento.\r\n";
                    respuesta.Detalle = ex.Message;
                    respuesta.Resultado = null;
                    return respuesta;

                }

                #endregion

                ////
                //// Enviar libro y solicitar la respuesta del SII
                #region ENVIA Y SOLICITA RESPUESTA

                try
                {
                    ////
                    //// Defina donde depositar el resultado
                    string respuestaSii = string.Empty;

                    ////
                    //// Recupere la respuesta del sii
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        ////
                        //// Lea la respuesta del SII utilizando el streamReader
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            respuestaSii = sr.ReadToEnd().Trim();
                        }

                    }

                    ////
                    //// Hay respuesta?
                    if (string.IsNullOrEmpty(respuestaSii))
                        throw new ArgumentNullException("Respuesta del SII es null");


                    ////
                    //// Interprete la respuesta del SII
                    //// respuesta = FuncionesComunes.leerRespuestaEnvioLibro(respuestaSii);
                    respuesta = AUTENTICACION.FUNCIONES.leerRespuestaEnvioLibro(respuestaSii);


                }
                catch (Exception ex)
                {
                    ////
                    //// Indique al codigo cliente que no fue posible enviar el documento.
                    respuesta.EsCorrecto = false;
                    respuesta.Mensaje = "No fue posible enviar o recepcionar la respuesta del SII.";
                    respuesta.Detalle = ex.Message;
                    respuesta.Resultado = null;

                    ////
                    //// Regrese la respuesta
                    return respuesta;

                }

                #endregion


                ////
                //// Determine la respuesta
                if (!respuesta.EsCorrecto)
                {
                    return respuesta;
                }

                ////
                //// Cree mensaje de salida
                string mensaje = string.Format("{0} - {1}", (string)respuesta.Resultado, pNombreArchivoShort);

                ////
                //// Regrese la respuesta al codigo cliente
                respuesta.EsCorrecto = true;
                respuesta.Mensaje = mensaje;
                respuesta.Detalle = "";
                respuesta.Resultado = (string)respuesta.Resultado;



                ////
                //// Regrese la respuesta
                return respuesta;

            }


        }

}
