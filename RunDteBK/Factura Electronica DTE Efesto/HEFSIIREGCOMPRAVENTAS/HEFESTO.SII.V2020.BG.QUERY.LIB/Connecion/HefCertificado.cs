using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Authentication;

namespace HEFSIIREGCOMPRAVENTAS.LIB.Connecion
{
    /// <summary>
    /// Recupera autenticacion del sii con certificado
    /// </summary>
    internal class HefCertificado
    {
        /// <summary>
        /// Recupera las cookies del proceso de autenticacion
        /// </summary>
        private static HefRespuesta Conectar(X509Certificate2 Certificado)
        {
            ////
            //// Cree la entidad para recuperar la respuesta
            HefRespuesta resp = new HefRespuesta();

            ////
            //// Target donde apunta la autenticación del SII
            string uriSIITarget = "https://herculesr.sii.cl/cgi_AUT2000/CAutInicio.cgi?";
            uriSIITarget += "https://misiir.sii.cl/cgi_misii/siihome.cgi";

            ////
            //// Agregar protocolos de seguridad
            System.Net.ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls11 |
                    SecurityProtocolType.Tls12 |
                     SecurityProtocolType.Tls |
                        SecurityProtocolType.Ssl3;


            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Consulta al SII para autenticar al cliente actual ( certificado )
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uriSIITarget);
                req.PreAuthenticate = true;
                req.AllowAutoRedirect = true;
                req.ClientCertificates.Add(Certificado);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";

                ////
                //// Escriba la consulta ( POST ) y su largo en bytes
                string postData = "referencia=https%3A%2F%2Fmisiir.sii.cl%2Fcgi_misii%2Fsiihome.cgi";
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                req.ContentLength = postBytes.Length;

                ////
                //// Escriba los bytes en el request stream
                Stream postStream = req.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);
                postStream.Flush();
                postStream.Close();

                ////
                //// Recupere la respuesta de la consulta ( response )
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                ////
                //// Recupere la respuesta del SII
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("No fue posible comunicarse con el servidor remoto.");

                ////
                //// Recupere las cookies generadas por el SII
                bool HasCookies = response.Headers.AllKeys.Contains("Set-Cookie");
                if (!HasCookies)
                    throw new Exception("La consulta actual no regresó cookies.");

                ////
                //// Recupere las cookies del proceso
                string cookies = response.Headers["Set-Cookie"];
                if (string.IsNullOrEmpty(cookies))
                    throw new Exception("La consulta actual no regresó ninguna cookies. ( cookies= null )");

                ////
                //// Cree el arreglo de cookies
                string[] Items = cookies.Split(',');

                ////
                //// Por cada item del arreglo solo recupere el value de la cookie
                string sCookies = string.Empty;
                foreach (string Item in Items)
                {
                    sCookies += Item.Split(';')[0] + "; ";
                }

                ////
                //// Limpie la cadena de los caracteres no validos
                sCookies = sCookies.Substring(0, sCookies.Length - 2);

                ////
                //// Complete la respuesta del proceso
                resp.EsCorrecto = true;
                resp.Mensaje = "Conectar()";
                resp.Detalle = "Operación ejecutada correctamente.";
                resp.Resultado = sCookies;

            }
            catch (Exception Ex)
            {
                resp.EsCorrecto = false;
                resp.Mensaje = "No fue posible conectarse al SII.";
                resp.Detalle = Ex.Message;
                resp.Resultado = null;
            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Recupere las credenciales necesarias
        /// </summary>
        /// <param name="Certificado"></param>
        internal static HefRespuesta RecuperarConeccion(string RutEmpresa, X509Certificate2 Certificado)
        { 

            ////
            //// Respuesta
            HefRespuesta r = new HefRespuesta();

            ////
            //// Este es el token
            string token = "";

            ////
            //// Nombre de la coneccion
            string misTokens = Path.Combine(Path.GetTempPath(), "HefestoTokenCV");
            Directory.CreateDirectory(misTokens);

            ////
            //// Cree el nombre del archivo
            string myArchivo = misTokens + string.Format("/{0}.tkn", RutEmpresa);

            ////
            //// Sí existe el archivo evaluelo
            if (File.Exists(myArchivo))
            {

                ////
                //// Cree el archivo file info
                FileInfo fiArchivo = new FileInfo(myArchivo);

                ////
                //// Este archivo tiene mas de una hora creado?
                //// sí es así eliminelo pues el token debe haber 
                //// vencido o esta a punto de hacerlo.
                TimeSpan diff = DateTime.Now - fiArchivo.LastWriteTime;
                double t = diff.TotalHours;
                if (t > 1)
                {
                    ////
                    //// Si la diferencia es mayor que 1 cree nuevamente el archivo.
                    HefRespuesta resp = Conectar(Certificado);
                    if (!resp.EsCorrecto)
                        return resp;
                    
                    ////
                    //// Recupere la información
                    token = resp.Resultado.ToString();
                    File.Delete(myArchivo);
                    File.WriteAllText(myArchivo, token);
                    
                }
                else
                {
                    ////
                    //// Lea el archivo y recupere el token
                    token = File.ReadAllText(myArchivo);

                }

            }
            else
            {
                ////
                //// Si la diferencia es mayor que 1 cree nuevamente el archivo.
                HefRespuesta resp = Conectar(Certificado);
                if (!resp.EsCorrecto)
                    return resp;

                ////
                //// Recupere la información
                token = resp.Resultado.ToString();
                File.WriteAllText(myArchivo, token);
            
            }

            ////
            //// Regrese la respuesta
            r.EsCorrecto = true;
            r.Resultado = token;
            return r;           
        
        }

        /// <summary>
        /// Recupere las credenciales necesarias
        /// </summary>
        /// <param name="Certificado"></param>
        internal static HefRespuesta RecuperarConeccion2(string RutEmpresa, X509Certificate2 Certificado)
        {

            ////
            //// Respuesta
            HefRespuesta r = new HefRespuesta();

            ////
            //// Este es el token
            string token = "";

            ////
            //// Nombre de la coneccion
            string misTokens = Path.Combine(Path.GetTempPath(), "HefestoTokenCV");
            Directory.CreateDirectory(misTokens);

            ////
            //// Cree el nombre del archivo
            string myArchivo = misTokens + string.Format("/{0}.tkn", RutEmpresa);

            ////
            //// Sí existe el archivo evaluelo
            if (File.Exists(myArchivo))
            {

                ////
                //// Recupere el contenido del archivo
                string content = File.ReadAllText(myArchivo, Encoding.GetEncoding("ISO-8859-1"));

                ////
                //// Recupere el timestamp de las credenciales
                //// NETSCAPE_LIVEWIRE.exp=20211007120138;
                Match exp = Regex.Match(content, "NETSCAPE_LIVEWIRE.exp=(\\d+);", RegexOptions.Singleline);
                if (exp.Success)
                {

                    ////
                    //// reconstruya la fecha de expiracion
                    string fch = Convert.ToInt64(exp.Groups[1].Value).ToString("####-##-## ##:##:##");

                    ////
                    //// Cree la fecha de expiración de la scredenciales
                    DateTime _fecha_expiracion;
                    if (!DateTime.TryParse(fch, out _fecha_expiracion))
                        return null;

                    ////
                    //// Recupere la fecha y hora actual de Chile para realizar el calculo 
                    //// diferencial de horas.
                    DateTime utcDateTime = DateTime.Now.ToUniversalTime();

                    ////
                    //// Cual es la zona horaria de Chile
                    TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");
                    DateTime _fecha_chile = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, cstZone);

                    ////
                    //// A la fecha de expiración restele 1 hora 
                    _fecha_expiracion = _fecha_expiracion.AddHours(-1);

                    ////
                    //// Evalue las fechas
                    bool esOtroDia = _fecha_chile.ToString("dd") != _fecha_expiracion.ToString("dd");

                    ////
                    //// Calcular las fechas
                    TimeSpan ts = _fecha_expiracion - _fecha_chile;
                    
                    ////
                    //// Cuantos días han pasado ?
                    if ( ts.TotalMinutes <= 0 || esOtroDia )
                    {

                        ////
                        //// Si la diferencia es mayor que 1 cree nuevamente el archivo.
                        HefRespuesta resp = Conectar(Certificado);
                        if (!resp.EsCorrecto)
                            return resp;

                        ////
                        //// Recupere la información
                        token = resp.Resultado.ToString();
                        File.Delete(myArchivo);
                        File.WriteAllText(myArchivo, token);

                    }
                    else
                    {
                        ////
                        //// Lea el archivo y recupere el token
                        token = content;

                    }

                }

            }
            else
            {
                ////
                //// Si la diferencia es mayor que 1 cree nuevamente el archivo.
                HefRespuesta resp = Conectar(Certificado);
                if (!resp.EsCorrecto)
                    return resp;

                ////
                //// Recupere la información
                token = resp.Resultado.ToString();
                File.WriteAllText(myArchivo, token);

            }

            ////
            //// Regrese la respuesta
            r.EsCorrecto = true;
            r.Resultado = token;
            return r;

        }

    }

}
