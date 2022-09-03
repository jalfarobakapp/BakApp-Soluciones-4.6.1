using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace HEFESTO.CONSULTA.ESTADO.DTE.AUTENTICACION
{

    /// <summary>
    /// Enumeracion Publica
    /// Define el tipo de operacion sobre el SII
    /// </summary>
    public enum SIIAmbiente
    {
        Certificacion = 0,
        Produccion = 1
    }


    /// <summary>
    /// Permite conectarse al SII
    /// </summary>
    public class ConectarseSII
    {

        /// <summary>
        /// Nombre Canonico del certificado
        /// </summary>
        public string  CN { get; set; }

        /// <summary>
        /// Define el ambiente de consulta
        /// </summary>
        public SIIAmbiente Ambiente { get; set; }

        

        /// <summary>
        /// Conectarse al SII
        /// </summary>
        /// <param name="CN">Nombre Canonico del certificado</param>
        /// <param name="ambiente">Indica en que ambiente debe conectarse</param>
        public  Respuesta Login()
        {

            ////
            //// Recupere las variables
            string CN = this.CN;
            SIIAmbiente Ambiente = this.Ambiente;

            ////
            //// Inicie la respuesta del servicio
            Respuesta respuesta = new Respuesta();

            ////
            //// inicie el proceso
            try
            {

                ////
                //// Recupere la semilla (Seed) desde el SII
                string seed = ObtenerSemilla(Ambiente);
                if (!string.IsNullOrEmpty(seed))
                {

                    ////
                    //// Firme la semilla utilzando el certificado 
                    string signedSeed = FirmarSemilla(seed, CN);
                    if (!string.IsNullOrEmpty(signedSeed))
                    {

                        if (Ambiente == SIIAmbiente.Produccion)
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
                
                
                }



            }
            catch (Exception ex)
            {
                ////
                //// Respuesta falla de conexion al SII
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = "No fue posible conectarse al SII";
                respuesta.Detalle = ex.Message;
                respuesta.Resultado = null;
            }

            ////
            //// Regrese la respuesta del proceso de login contra el SII
            //// la respuesta es un Token.
            return respuesta;


        }

        /// <summary>
        /// Recupera la semilla desde el SII
        /// </summary>
        /// <param name="modo">Utilizar Ambiente de Certificación o Producción </param>
        private static string ObtenerSemilla(SIIAmbiente modo = SIIAmbiente.Certificacion)
        {

            ////
            //// Inicie el valor de la respuesta
            string respuesta = string.Empty;


            ////
            //// Cree los ontentos de conexion al servidor
            int intentos = 1;
            while (intentos <= 100)
            {

                ////
                //// Inicie el proceso
                try
                {

                    ////
                    //// Recupere la semilla utilizando el ambiente correcto
                    switch (modo)
                    {
                        case SIIAmbiente.Certificacion:
                            break;

                        case SIIAmbiente.Produccion:
                            PRODUCCION.CrSeedService palena = new PRODUCCION.CrSeedService();
                            respuesta = palena.getSeed();
                            respuesta = FuncionesComunes.leerRespuestaSeed(respuesta);
                            intentos = 99999;
                            break;

                        default:
                            break;

                    }


                }
                catch (Exception)
                {
                    intentos++;
                    System.Threading.Thread.Sleep(3000);
                }


                ////
                //// Incremente 
                intentos++;


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
            //// Defina el formato de la firma
            string formatoFirma = "<getToken><item><Semilla>{0}</Semilla></item></getToken>";
            
            ////
            //// Construya el cuerpo del documento en formato string.
            string resultado = string.Empty;
            string body = string.Format(formatoFirma, double.Parse(seed).ToString());

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



    }


   


}
