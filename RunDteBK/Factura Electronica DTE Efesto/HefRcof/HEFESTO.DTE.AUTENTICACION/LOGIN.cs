using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HEFESTO.DTE.AUTENTICACION.ENT;
using System.Security.Cryptography.X509Certificates;

namespace HEFESTO.DTE.AUTENTICACION
{

    /// <summary>
    /// Define el tipo de operacion sobre el SII
    /// </summary>
    public enum SIIAmbiente
    {
        Certificacion = 0,
        Produccion = 1
    }


    /// <summary>
    /// Permite realizar la autenticacion contra el SII
    /// </summary>
    public class LOGIN
    {

        /// <summary>
        /// Permite conectarse al SII utilizando la autenticacion automatica.
        /// </summary>
        /// <param name="CN">Nombre Canonico del certificado digital</param>
        public static Respuesta Conectar(string CN, SIIAmbiente ambiente)
        {

            ////
            //// Inicie la respuesta del servicio
            Respuesta respuesta = new Respuesta();


            try
            {

                ////
                //// Recupere la semilla (Seed) desde el SII
                string seed = ObtenerSemilla(ambiente);

                ////
                //// Si hay respuesta continue con el proceso
                if (!string.IsNullOrEmpty(seed))
                {

                    ////
                    //// Recupere la semilla firmada
                    string signedSeed = FirmarSemilla(seed, CN);
                    if (!string.IsNullOrEmpty(signedSeed))
                    {
                        ////
                        //// Determine donde loguearse
                        if (ambiente == SIIAmbiente.Certificacion)
                        {

                            ////
                            //// Obtenga el token a partir de de la semilla firmada.
                            CERTIFICACION.GetTokenFromSeedService gt = new CERTIFICACION.GetTokenFromSeedService();
                            string valorRespuesta = gt.getToken(signedSeed);
                            if (!string.IsNullOrEmpty(valorRespuesta))
                            {

                                ////
                                //// Lea la respuesta del sii
                                respuesta = FuncionesComunes.leerRespuestaToken(valorRespuesta);

                            }

                        }

                        if (ambiente == SIIAmbiente.Produccion)
                        {

                            ////
                            //// Obtenga el token a partir de de la semilla firmada.
                            PRODUCCION.GetTokenFromSeedService gt = new PRODUCCION.GetTokenFromSeedService();
                            string valorRespuesta = gt.getToken(signedSeed);
                            if (!string.IsNullOrEmpty(valorRespuesta))
                            {

                                ////
                                //// Lea la respuesta del sii
                                respuesta = FuncionesComunes.leerRespuestaToken(valorRespuesta);

                            }

                        }


                    }
                    else
                    {
                        ////
                        //// Indique que no fue posible recuperar la semilla
                        throw new Exception("No fue posible firmar la semilla(seed).");
                    }

                }
                else
                {
                    ////
                    //// Indique que no fue posible recuperar la semilla
                    throw new Exception("No se puedo recuperar semilla(seed) desde el SII");
                }



            }
            catch (Exception ex)
            {
                ////
                //// Notifique el error
                respuesta.correcto = false;
                respuesta.mensaje = "Error al intentar logearse con el SII";
                respuesta.detalle = ex.Message;
                respuesta.Resultado = null;                
            }

        
            ////
            //// Regrese la respuesta al codigo cliente
            return respuesta;
        
        
        }

        /// <summary>
        /// Recupera la semilla desde el SII
        /// </summary>
        /// <param name="modo">Utilizar Ambiente de Certificación o Producción </param>
        private static string ObtenerSemilla(SIIAmbiente modo = SIIAmbiente.Produccion)
        {

            ////
            //// Inicie el valor de la respuesta
            string respuesta = string.Empty;

            ////
            //// Que modo utilizar
            switch (modo)
            {
                case SIIAmbiente.Certificacion:
                    CERTIFICACION.CrSeedService maullin = new CERTIFICACION.CrSeedService();
                    respuesta = maullin.getSeed();
                    respuesta = FuncionesComunes.leerRespuestaSeed(respuesta);
                    break;

                case SIIAmbiente.Produccion:
                    PRODUCCION.CrSeedService palena = new PRODUCCION.CrSeedService();
                    respuesta = palena.getSeed();
                    respuesta = FuncionesComunes.leerRespuestaSeed(respuesta);
                    break;

                default:

                    break;

            }


            ////
            //// Regrese el valor de retorno
            return respuesta;

        }


        /// <summary>
        /// Firma la semilla para poder validarla en el SII
        /// </summary>
        private static string FirmarSemilla(string seed, string cn)
        {

            ////
            //// Construya el cuerpo del documento en formato string.
            string resultado = string.Empty;
            string body = string.Format("<getToken><item><Semilla>{0}</Semilla></item></getToken>", double.Parse(seed).ToString());

            ////
            //// Recuperar el certificado para firmar el documento.
            //// y recupere la key del certificado.
            X509Certificate2 certificado = FuncionesComunes.obtenerCertificado(cn);

            ////
            //// Firme la semilla.
            try
            {
                resultado = FuncionesComunes.firmarDocumentoSemilla(body, certificado);
            }
            catch (Exception)
            {
                resultado = string.Empty;
            }



            return resultado;



        }

        /// <summary>
        /// Firma la semilla para poder validarla en el SII
        /// </summary>
        private static string FirmarSemilla(string seed, X509Certificate2 certificado)
        {

            ////
            //// Construya el cuerpo del documento en formato string.
            string resultado = string.Empty;
            string body = string.Format("<getToken><item><Semilla>{0}</Semilla></item></getToken>", double.Parse(seed).ToString());

            ////
            //// Firme la semilla.
            try
            {
                resultado = FuncionesComunes.firmarDocumentoSemilla(body, certificado);
            }
            catch (Exception)
            {
                resultado = string.Empty;
            }
                       
            return resultado;



        }



        /// <summary>
        /// Permite conectarse al SII utilizando la autenticacion automatica.
        /// </summary>
        /// <param name="CN">Nombre Canonico del certificado digital</param>
        public static Respuesta Conectar(X509Certificate2 certificado, SIIAmbiente ambiente)
        {

            ////
            //// Inicie la respuesta del servicio
            Respuesta respuesta = new Respuesta();


            try
            {

                ////
                //// Recupere la semilla (Seed) desde el SII
                string seed = ObtenerSemilla(ambiente);

                ////
                //// Si hay respuesta continue con el proceso
                if (!string.IsNullOrEmpty(seed))
                {

                    ////
                    //// Recupere la semilla firmada
                    string signedSeed = FirmarSemilla(seed,certificado);
                    if (!string.IsNullOrEmpty(signedSeed))
                    {
                        ////
                        //// Determine donde loguearse
                        if (ambiente == SIIAmbiente.Certificacion)
                        {

                            ////
                            //// Obtenga el token a partir de de la semilla firmada.
                            CERTIFICACION.GetTokenFromSeedService gt = new CERTIFICACION.GetTokenFromSeedService();
                            string valorRespuesta = gt.getToken(signedSeed);
                            if (!string.IsNullOrEmpty(valorRespuesta))
                            {

                                ////
                                //// Lea la respuesta del sii
                                respuesta = FuncionesComunes.leerRespuestaToken(valorRespuesta);

                            }

                        }

                        if (ambiente == SIIAmbiente.Produccion)
                        {

                            ////
                            //// Obtenga el token a partir de de la semilla firmada.
                            PRODUCCION.GetTokenFromSeedService gt = new PRODUCCION.GetTokenFromSeedService();
                            string valorRespuesta = gt.getToken(signedSeed);
                            if (!string.IsNullOrEmpty(valorRespuesta))
                            {

                                ////
                                //// Lea la respuesta del sii
                                respuesta = FuncionesComunes.leerRespuestaToken(valorRespuesta);

                            }

                        }


                    }
                    else
                    {
                        ////
                        //// Indique que no fue posible recuperar la semilla
                        throw new Exception("No fue posible firmar la semilla(seed).");
                    }

                }
                else
                {
                    ////
                    //// Indique que no fue posible recuperar la semilla
                    throw new Exception("No se puedo recuperar semilla(seed) desde el SII");
                }



            }
            catch (Exception ex)
            {
                ////
                //// Notifique el error
                respuesta.correcto = false;
                respuesta.mensaje = "Error al intentar logearse con el SII";
                respuesta.detalle = ex.Message;
                respuesta.Resultado = null;
            }


            ////
            //// Regrese la respuesta al codigo cliente
            return respuesta;


        }



    }
}
