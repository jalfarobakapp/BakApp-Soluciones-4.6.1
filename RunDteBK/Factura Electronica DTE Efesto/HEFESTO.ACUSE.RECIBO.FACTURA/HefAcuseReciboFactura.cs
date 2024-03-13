using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Elementos comunes
/// </summary>
namespace Hefesto.Acuse.Recibo.Factura
{

    /// <summary>
    /// Eventos del documento DTE
    /// </summary>
    public enum enumAcciones
    {
        [Description("Defaul sin valor")]
        Defaul = 0,

        [Description("Acepta Contenido del Documento")]
        ACD_AceptaContenidoDocumento = 1,

        [Description("Reclamo al Contenido del Documento")]
        RCD_ReclamoContenidoDocumento = 2,

        [Description("Otorga Recibo de Mercaderías o Servicios")]
        ERM_OtorgaReciboMercaderiasServicios = 3,

        [Description("Reclamo por Falta Parcial de Mercaderías")]
        RFP_ReclamoFaltaParcialMercaderias = 4,

        [Description("Reclamo por Falta Total de Mercaderías")]
        RFT_ReclamoFaltaTotalMercaderias = 5,

    }

}

/// <summary>
/// Elementos de Certificacion
/// </summary>
namespace Hefesto.Acuse.Recibo.Factura.Certificacion
{

    /// <summary>
    /// Metodos relacionados con los acuse recibo facturas
    /// </summary>
    public class HefAcuseReciboFactura
    {

        #region CONSULTAS CON CN

        /// <summary>
        /// Consulta la version del web services
        /// </summary>
        /// <param name="Cn"></param>
        /// <returns></returns>
        public static Respuesta ConsultarVersion(string Cn)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                ////
                //// Validar el cn del certificado
                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");

                ////
                //// Recupere el certificado
                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_consultarVersion(Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "No fue posible consultar la versión: " + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta al SII si el documento es cedible
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaEstadoDocumentoCedible(string Cn, string RutEmisor, string TipoDte, string FolioDte)
        {

            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_consultarDocDteCedible(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta la fecha de publicación en el SII de un DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaFechaRecepcionDte(string Cn, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_ConsultaFechaRecepcionDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();


                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// COnsulta al SII por el historial del Docuemnto DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaHistorialDocumentoDTE(string Cn, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_ConsultarHistorialDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();


                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Agregar evento al documento DTE
        /// Aceptar
        /// Rechazar
        /// Recibo mercaderias
        /// Recibo mercaderias parciales
        /// </summary>
        public static Respuesta AgregarEventoDTE(string Cn, string RutEmisor, string TipoDte, string FolioDte, enumAcciones Acciones)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_AgregarEventoDte(RutEmisor, TipoDte, FolioDte, Token, Acciones);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        #endregion

        #region CONSULTAS CON CERTIFICADO

        /// <summary>
        /// Consulta la version del web services
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultarVersion(string path_cert, string pass_cert)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_consultarVersion(Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "No fue posible consultar la versión: " + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta al SII si el documento es cedible
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaEstadoDocumentoCedible(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte)
        {

            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS
                                
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;


                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_consultarDocDteCedible(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta la fecha de publicación en el SII de un DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaFechaRecepcionDte(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_ConsultaFechaRecepcionDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();


                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// COnsulta al SII por el historial del Docuemnto DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaHistorialDocumentoDTE(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_ConsultarHistorialDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();


                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Agregar evento al documento DTE
        /// Aceptar
        /// Rechazar
        /// Recibo mercaderias
        /// Recibo mercaderias parciales
        /// </summary>
        public static Respuesta AgregarEventoDTE(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte, enumAcciones Acciones)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Certificacion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Certificacion.HefConsultas.Hef_AgregarEventoDte(RutEmisor, TipoDte, FolioDte, Token, Acciones);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        #endregion


    }

}

/// <summary>
/// Elementos de Produccion
/// </summary>
namespace Hefesto.Acuse.Recibo.Factura.Produccion
{

    /// <summary>
    /// Metodos relacionados con los acuse recibo facturas
    /// </summary>
    public class HefAcuseReciboFactura
    {

        #region CONSULTAS CON CN

        /// <summary>
        /// Consulta la version del web services
        /// </summary>
        /// <param name="Cn"></param>
        /// <returns></returns>
        public static Respuesta ConsultarVersion(string Cn)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {
                
                #region VALIDAR PARAMETROS

                ////
                //// Validar el cn del certificado
                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");

                ////
                //// Recupere el certificado
                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_consultarVersion(Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "No fue posible consultar la versión: " + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }
        
        /// <summary>
        /// Consulta al SII si el documento es cedible
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaEstadoDocumentoCedible(string Cn,string RutEmisor,string TipoDte,string FolioDte)
        {

            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {
                
                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_consultarDocDteCedible(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);
                               
                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }
            
            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta la fecha de publicación en el SII de un DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaFechaRecepcionDte(string Cn, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {
               
                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_ConsultaFechaRecepcionDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);
                               
                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();
                

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// COnsulta al SII por el historial del Docuemnto DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaHistorialDocumentoDTE(string Cn, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_ConsultarHistorialDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();


                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Agregar evento al documento DTE
        /// Aceptar
        /// Rechazar
        /// Recibo mercaderias
        /// Recibo mercaderias parciales
        /// </summary>
        public static Respuesta AgregarEventoDTE(string Cn, string RutEmisor, string TipoDte, string FolioDte, enumAcciones Acciones)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {
                
                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(Cn))
                    throw new Exception("El parametro Cn no puede estar vacio.");
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                X509Certificate2 Certificado = Negocio.HefCertificados.obtenerCertificado(Cn);
                if (Certificado == null)
                    throw new Exception("El certificado '" + Cn + "' no existe o no se tiene acceso a el.");

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_AgregarEventoDte(RutEmisor, TipoDte, FolioDte, Token, Acciones);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();
                
                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }
            
            ////
            //// regrese el valor de retorno
            return resp;

        }

        #endregion

        #region CONSULTAS CON CERTIFICADO

        /// <summary>
        /// Consulta la version del web services
        /// </summary>
        /// <param name="Cn"></param>
        /// <returns></returns>
        public static Respuesta ConsultarVersion(string path_cert, string pass_cert)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;
                                
                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_consultarVersion(Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro version web services";
                resp.Detalle = "No fue posible consultar la versión: " + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta al SII si el documento es cedible
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaEstadoDocumentoCedible(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte)
        {

            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                ////
                //// Validaciones
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;


                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_consultarDocDteCedible(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo documento DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta la fecha de publicación en el SII de un DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaFechaRecepcionDte(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_ConsultaFechaRecepcionDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();


                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo fecha emision DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// COnsulta al SII por el historial del Docuemnto DTE
        /// </summary>
        /// <returns></returns>
        public static Respuesta ConsultaHistorialDocumentoDTE(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_ConsultarHistorialDte(RutEmisor, TipoDte, FolioDte, Token);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();


                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta registro de reclamo historial documento dte producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Agregar evento al documento DTE
        /// Aceptar
        /// Rechazar
        /// Recibo mercaderias
        /// Recibo mercaderias parciales
        /// </summary>
        public static Respuesta AgregarEventoDTE(string path_cert, string pass_cert, string RutEmisor, string TipoDte, string FolioDte, enumAcciones Acciones)
        {
            ////
            //// Iniciar la respuesta 
            Respuesta resp = new Respuesta();

            ////
            //// Iniciar el proceso
            try
            {

                #region VALIDAR PARAMETROS

                
                if (string.IsNullOrEmpty(RutEmisor))
                    throw new Exception("El parametro RutEmisor no puede estar vacio.");
                if (string.IsNullOrEmpty(TipoDte))
                    throw new Exception("El parametro TipoDte no puede estar vacio.");
                if (string.IsNullOrEmpty(FolioDte))
                    throw new Exception("El parametro FolioDte no puede estar vacio.");

                ////
                //// existe el certificado?
                Respuesta respCert = Negocio.HefCertificados.RecuperarCertificado(path_cert, pass_cert);
                if (!respCert.EsCorrecto)
                    throw new Exception("No fue posible recuperar el certificado. " + respCert.Detalle);

                ////
                //// Extraiga el certificado desde la respuesta
                X509Certificate2 Certificado = (X509Certificate2)respCert.Resultado;

                #endregion

                #region AUTENTICARSE

                ////
                //// Auntenticarse en el SII
                Respuesta respToken = Autenticacion.Produccion.HefLogin.Login(Certificado);
                if (!respToken.EsCorrecto)
                    return respToken;

                ////
                //// Recupere el Token del SII
                string Token = respToken.Resultado.ToString();

                ////
                //// Inicie la consulta del trackid 
                Respuesta respConsulta = Dal.Produccion.HefConsultas.Hef_AgregarEventoDte(RutEmisor, TipoDte, FolioDte, Token, Acciones);
                if (!respConsulta.EsCorrecto)
                    throw new Exception(respConsulta.Mensaje);

                ////
                //// notificar al usuario
                resp.EsCorrecto = true;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "Se ejecuto correctamente la consulta.";
                resp.Resultado = respConsulta.Resultado.ToString();

                #endregion

            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario
                resp.EsCorrecto = false;
                resp.Mensaje = "Ingresar aceptación o reclamo al registro de reclamo  DTE cedible producción";
                resp.Detalle = "No fue posible consultar documento DTE\r\n" + ex.Message;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }


        #endregion

    }

}
