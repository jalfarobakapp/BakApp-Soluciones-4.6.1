using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hefesto.Acuse.Recibo.Factura.Autenticacion.Certificacion
{
    /// <summary>
    /// Login de usuario
    /// </summary>
    internal class HefLogin
    {
                
        /// <summary>
        /// Conectarse al SII
        /// </summary>
        /// <param name="CN">Nombre Canonico del certificado</param>
        /// <param name="ambiente">Indica en que ambiente debe conectarse</param>
        internal static Respuesta Login(X509Certificate2 Certificado)
        {
            ////
            //// Set protocols
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            ////
            //// Inicie la respuesta del servicio
            Respuesta resp = new Respuesta();

            ////
            //// Variables privadas
            string seed = string.Empty;
            string signedSeed = string.Empty;

            ////
            //// inicie el proceso
            try
            {

                ////
                //// Recupere la semilla (Seed) desde el SII
                resp = RecuperarSemillaSII();
                if (!resp.EsCorrecto)
                    return resp;

                ////
                //// Recupere la semilla
                seed = resp.Resultado.ToString();

                ////
                //// Firmar la semilla utilizando el certificado
                resp = FirmarSemilla(seed, Certificado);
                if (!resp.EsCorrecto)
                    return resp;

                ////
                //// Recupere la semilla firmada
                seed = resp.Resultado.ToString();

                ////
                //// Envie la semilla firmada al SII y recupere el token
                TokenCertificacion.GetTokenFromSeedService gt = new TokenCertificacion.GetTokenFromSeedService();
                string token = gt.getToken(seed);
                Match mToken = Regex.Match(token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                if (!mToken.Success)
                    throw new Exception("No fue posible recuperar el token desde la respuesta del SII");

                ////
                //// Complete la respuesta del procesi
                resp.EsCorrecto = true;
                resp.Mensaje = "Autenticación automatica con SII";
                resp.Detalle = "Autenticación Efectuada Correctamente.";
                resp.Resultado = mToken.Groups[1].Value;


            }
            catch (Exception ex)
            {
                ////
                //// Respuesta falla de conexion al SII
                resp.EsCorrecto = false;
                resp.Mensaje = "Autenticación automatica con SII";
                resp.Detalle = "No fue posible autenticarse en el SII.\r\n" + ex.Message;
                resp.Resultado = null;
            }

            ////
            //// Regrese la respuesta del proceso de login contra el SII
            //// la respuesta es un Token.
            return resp;

        }

        /// <summary>
        /// Recupera la semilla desde el SII
        /// </summary>
        internal static Respuesta RecuperarSemillaSII()
        {

            ////
            //// Cree la respuesta del proceso
            Respuesta resp = new Respuesta();
            string respuesta = string.Empty;

            ////
            //// Cree los intentos de conexion al servidor
            //// Se realizaran 10 intentos de conección antes
            //// de anular la operacion. esto debido a que no
            //// siempre es posible conectarse a la primera
            //// con el sii.
            int intentos = 1;
            while (intentos <= 10)
            {

                ////
                //// Inicie el proceso
                try
                {

                    ////
                    //// Recupere la semilla desde el SII
                    SemillaCertificacion.CrSeedService palena = new SemillaCertificacion.CrSeedService();
                    respuesta = palena.getSeed();
                    intentos = 100;

                }
                catch
                {
                    ////
                    //// Vuelva a consultar al SII esperando 2 segundos antes de realizar la consulta
                    intentos++;
                    System.Threading.Thread.Sleep(2000);
                }

                ////
                //// Incremente 
                intentos++;

            }

            ////
            //// Determine la respuesta segun la semilla regresada por el SII
            if (string.IsNullOrEmpty(respuesta))
            {
                resp.EsCorrecto = false;
                resp.Mensaje = "Login Certificación";
                resp.Detalle = "No fue posible recuperar la semilla desde el SII";
                resp.Resultado = null;
                return resp;
            }

            ////
            //// Recupere la semilla
            string sSemilla = Regex.Match(respuesta, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline).Groups[1].Value;

            ////
            //// Asigne los valores de la respuesta
            resp.EsCorrecto = true;
            resp.Mensaje = "Login Certificación";
            resp.Detalle = "Recuperacion de semilla efectuado correctamente.";
            resp.Resultado = sSemilla;

            ////
            //// Regrese el valor de retorno
            return resp;

        }
        
        /// <summary>
        /// Firmar semilla 
        /// </summary>
        /// <param name="seed">Esta es la semilla del sii</param>
        /// <param name="Certificado">Certificado para firmar la semilla</param>
        /// <returns></returns>
        internal static Respuesta FirmarSemilla(string seed, X509Certificate2 Certificado)
        {

            ////
            //// Iniciar la respuesta
            Respuesta resp = new Respuesta();

            ////
            //// Inicie el proceso
            try
            {
                ////
                //// Defina el formato de la firma
                string formatoFirma = "<getToken><item><Semilla>{0}</Semilla></item></getToken>";

                ////
                //// Construya el cuerpo del documento en formato string.
                string resultado = string.Empty;
                string body = string.Format(formatoFirma, double.Parse(seed).ToString());

                ////
                //// Recuperar el certificado para firmar el documento.
                //// y recupere la key del certificado.
                X509Certificate2 certificado = Certificado;

                ////
                //// Firme el resultado de la operación
                resultado =  Negocio.HefFirmas.FirmarDocumentoSemilla(body, certificado);

                ////
                //// Regrese el resultado
                resp.EsCorrecto = true;
                resp.Mensaje = "Firma de semilla";
                resp.Detalle = "Documento Firmado Correctamente";
                resp.Resultado = resultado;

            }
            catch(Exception ex)
            {
                ////
                //// Indique el error al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Firma de semilla";
                resp.Detalle = "No fue posible firmar la semilla." + ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }


    }
}
