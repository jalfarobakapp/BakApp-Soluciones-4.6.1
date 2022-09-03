using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net;
using System.IO;
using HEFESTO.DTE.AUTENTICACION.ENT;

namespace HEFESTO.DTE.AUTENTICACION
{
    /// <summary>
    /// Construye el envio al sii
    /// </summary>
    public class ENVIO
    {

        /// <summary>
        /// Constantes a utilizar
        /// </summary>
        const string URL_CERTIFICACION = "https://maullin.sii.cl/cgi_dte/UPL/DTEUpload";
        const string URL_PRODUCCION = "https://palena.sii.cl/cgi_dte/UPL/DTEUpload";


        /// <summary>
        /// Envia un determinado archivo al SII
        /// </summary>
        public static Respuesta EnviarArchivoSII(string archivo, 
                                                 string token, 
                                                 string pRutEmisor, 
                                                 string pDigEmisor, 
                                                 string pRutEmpresa, 
                                                 string pDigEmpresa, 
                                                 SIIAmbiente ambiente = SIIAmbiente.Certificacion)
        {

            ////
            //// Inicialice el objeto respuesta
            Respuesta respuesta = new Respuesta();


            ////
            //// Parametros
            string pNombreArchivo = archivo;
            string pNombreArchivoShort = Path.GetFileName( archivo );

            #region  CREAR HEADER DEL ENVIO

            ////
            //// Construya los encabezados del documento 
            string secuencia = string.Empty;
            secuencia += "--7d23e2a11301c4\r\n";
            secuencia += "Content-Disposition: form-data; name=\"rutSender\"\r\n";
            //secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
            //secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
            secuencia += "\r\n";
            secuencia += pRutEmisor + "\r\n";
            secuencia += "--7d23e2a11301c4\r\n";
            secuencia += "Content-Disposition: form-data; name=\"dvSender\"\r\n";
            //secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
            //secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
            secuencia += "\r\n";
            secuencia += pDigEmisor + "\r\n";
            secuencia += "--7d23e2a11301c4\r\n";
            secuencia += "Content-Disposition: form-data; name=\"rutCompany\"\r\n";
            //secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
            //secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
            secuencia += "\r\n";
            secuencia += pRutEmpresa + "\r\n";
            secuencia += "--7d23e2a11301c4\r\n";
            secuencia += "Content-Disposition: form-data; name=\"dvCompany\"\r\n";
            //secuencia += "Content-Type: text/plain; charset=US-ASCII\r\n";
            //secuencia += "Content-Transfer-Encoding: 8Bit\r\n";
            secuencia += "\r\n";
            secuencia += pDigEmpresa + "\r\n";
            secuencia += "--7d23e2a11301c4\r\n";
            secuencia += "Content-Disposition: form-data; name=\"archivo\"; filename=\"" + pNombreArchivoShort  + "\" \r\n";
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
            string pReferer = "www.hefestosDte.cl";
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

                using (StreamWriter sw = new StreamWriter(request.GetRequestStream(), Encoding.GetEncoding("ISO-8859-1") ) )
                {
                    sw.Write(secuencia);
                }

            }
            catch (Exception ex)
            {
                respuesta.correcto = false;
                respuesta.mensaje = "No fue posible escribir en el request la cadena RFC1867\r\nEsto se debe a un error en el formato del documento.\r\n";
                respuesta.detalle = ex.Message;
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
                respuesta = FuncionesComunes.leerRespuestaEnvioLibro(respuestaSii);

            }
            catch (Exception ex)
            {
                ////
                //// Indique al codigo cliente que no fue posible enviar el documento.
                respuesta.correcto = false;
                respuesta.mensaje = "No fue posible enviar o recepcionar la respuesta del SII.";
                respuesta.detalle = ex.Message;
                respuesta.Resultado = null;

                ////
                //// Regrese la respuesta
                return respuesta;

            }

            #endregion

            ////
            //// Cree mensaje de salida
            string mensaje = string.Format("{0} - {1}",(string)respuesta.Resultado, pNombreArchivoShort);

            ////
            //// Regrese la respuesta al codigo cliente
            respuesta.correcto = true;
            respuesta.mensaje = mensaje;
            respuesta.detalle = "";
            respuesta.Resultado = (string)respuesta.Resultado;

            ////
            //// Regrese la respuesta
            return respuesta;

        }

        /// <summary>
        /// Envia un determinado archivo al SII
        /// </summary>
        /// <param name="Uri">Fullpath del archivo xml a enviar al SII</param>
        /// <param name="Token">Token generado en proceso de autenticación</param>
        /// <param name="RutEmisor">Rut del enviador del archivo</param>
        /// <param name="RutEmpresa">Rut de la empresa que envia el archivo</param>
        /// <returns>Objeto Respuesta</returns>
        /// 

        public static Respuesta EnviarArchivoSII(string Uri, 
                                                 string Token, 
                                                 string RutEnviador, 
                                                 string RutEmpresa)
        {

            ////
            //// Inicie el objetorespuesta
            Respuesta r = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Valide los elementos
                if (!File.Exists(Uri))
                    throw new Exception("Archivo Uri no esta disponible o no se puede acceder a el.");

                ////
                //// Recupere el ambiente a utilizar.
                SIIAmbiente ambiente = FuncionesComunes.detectarAmbiente(Uri);


                ////
                //// Valide los rut del proceso
                string parRutEnviadorB = RutEnviador.Split('-')[0];
                string parRutEnviadorD = RutEnviador.Split('-')[1];
                string parRutEmpresaaB = RutEmpresa.Split('-')[0];
                string parRutEmpresaaD = RutEmpresa.Split('-')[1];


                ////
                //// Envie el documento al SII
                Respuesta respuestaEnvio = HEFESTO.DTE.AUTENTICACION.ENVIO.EnviarArchivoSII(
                    Uri,
                    Token,
                    parRutEnviadorB,
                    parRutEnviadorD,
                    parRutEmpresaaB,
                    parRutEmpresaaD,
                    ambiente
                    );

                ////
                //// Recupere la respuesta del proceso.
                r = respuestaEnvio;

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al codigo cliente
                r.correcto = false;
                r.mensaje = "No fue posible enviar el archivo xml al SII.";
                r.detalle = ex.Message;
                r.Resultado = null;
                
            }

            ////
            //// Regrese el valor de retorno
            return r;

        }

    }
}
