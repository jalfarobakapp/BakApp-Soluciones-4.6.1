using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HefestoCesionV12.Negocio
{
    /// <summary>
    /// Consultas relacionadas con las cesiones del SII
    /// </summary>
    public class HefConsultas
    {

        /// <summary>
        /// Firma la semilla para ser enviada al SII
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="certificado"></param>
        /// <returns></returns>
        private static string firmarDocumentoSemilla(string documento, X509Certificate2 certificado)
        {

            ////
            //// Cree un nuevo documento xml y defina sus caracteristicas
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(documento);

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document.  'key'
            signedXml.SigningKey = certificado.PrivateKey;

            // Get the signature object from the SignedXml object.
            Signature XMLSignature = signedXml.Signature;

            // Create a reference to be signed.  Pass "" 
            // to specify that all of the current XML
            // document should be signed.
            Reference reference = new Reference("");

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the Reference object to the Signature object.
            XMLSignature.SignedInfo.AddReference(reference);

            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));


            ////
            //// Agregar información del certificado x509
            //// X509Certificate MSCert = X509Certificate.CreateFromCertFile(Certificate);
            keyInfo.AddClause(new System.Security.Cryptography.Xml.KeyInfoX509Data(certificado));


            // Add the KeyInfo object to the Reference object.
            XMLSignature.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));


            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            // Save the signed XML document to a file specified
            // using the passed string.
            //XmlTextWriter xmltw = new XmlTextWriter(@"d:\ResultadoFirma.xml", new UTF8Encoding(false));
            //doc.WriteTo(xmltw);
            //xmltw.Close();
            return doc.InnerXml;

        }


        /// <summary>
        /// Consulta el estado de una cesion utilizando el trackid
        /// </summary>
        public static HefRespuesta ConsultarEstadoEnvioCesion(string _cn, string _rutEmpresa, string _trackid, bool _esProduccion = false)
        {

            ////
            //// Inicie la respuesta del proceso
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;
            resp.Mensaje = "Consulta Estado Cesión";
            resp.Detalle = null;
            resp.Resultado = null;

            ////
            //// Inicie el proceso
            try
            {

                #region VALIDACIONES

                ////
                //// Valide los parametros de la consulta.
                ////

                ////
                //// Normalice el rut
                _rutEmpresa = _rutEmpresa.ToUpper().Trim();

                ////
                //// Recupere el certificado utilizando el cn ingresado
                if (string.IsNullOrEmpty(_cn))
                    throw new Exception("El Cn no puede estar vacío.");

                ////
                //// Intente recuperar el certificado 
                X509Certificate2 _certificado = HefCertificados.obtenerCertificado(_cn);
                if ( _certificado == null )
                    throw new Exception("El Certificado solicitado no existe o no se tiene acceso a el.");

                ////
                //// Evalue el rut de la empresa que hace la consulta
                if ( !HefRuts.ValidaRut(_rutEmpresa) )
                    throw new Exception("El Rut de la empresa ingresado no es valido o no tiene el formato correcto.");

                ////
                //// Valide el trackid ingresado
                if ( !Regex.IsMatch(_trackid,"\\d+",RegexOptions.Singleline) )
                    throw new Exception("El trackid ingresado no es correcto.");

                #endregion

                #region CONSULTA DEL ESTADO

                ////
                //// En caso de consulta en certificación.
                if (!_esProduccion)
                {

                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoCertificacion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoCertificacion.wsRPETCConsultaService())
                    {
                        _estado_envio_cesion = HefConsultaServicio.getEstEnvio(_token, _trackid);
                    }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }

                ////
                //// En el caso de produccion
                if (_esProduccion)
                {
                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoProduccion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoProduccion.wsRPETCConsultaService())
                    {
                        _estado_envio_cesion = HefConsultaServicio.getEstEnvio(_token, _trackid);
                    }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }
                    

                #endregion


            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario del problema
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta Estado Cesión";
                resp.Detalle = "No fue posible ejecutar la consulta. " + ex.Message;
                resp.Resultado = null;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta el estado de una cesion utilizando el trackid
        /// </summary>
        public static HefRespuesta ConsultarEstadoEnvioCesion(string _path_cert, string _pass_cert, string _rutEmpresa, string _trackid, bool _esProduccion = false)
        {

            ////
            //// Inicie la respuesta del proceso
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;
            resp.Mensaje = "Consulta Estado Cesión";
            resp.Detalle = null;
            resp.Resultado = null;

            ////
            //// Inicie el proceso
            try
            {

                #region VALIDACIONES

                ////
                //// Valide los parametros de la consulta.
                ////

                ////
                //// Normalice el rut
                _rutEmpresa = _rutEmpresa.ToUpper().Trim();

                ////
                //// Recuperar el certificado digital
                if (!File.Exists(_path_cert))
                    throw new Exception($"No se encuentra o no se tiene acceso al certificado '{_path_cert}'.");
                if (string.IsNullOrEmpty(_pass_cert))
                    throw new Exception($"La password del certificado no puede estar vacío '{_path_cert}'.");

                ////
                //// Recupere el certificado
                X509Certificate2 _certificado = new X509Certificate2(_path_cert, _pass_cert);
                if ( _certificado == null )
                    throw new Exception($"El Certificado solicitado no existe o no se tiene acceso a el. '{_path_cert}'");

                ////
                //// El certificado tiene clave privada?
                if (!_certificado.HasPrivateKey )
                    throw new Exception($"El Certificado no cuenta con la clave privada. '{_path_cert}'");

                ////
                //// El certificado esta expirado?
                DateTime dt;
                if (DateTime.TryParse(_certificado.GetExpirationDateString(), out dt))
                    if (dt < DateTime.Now)
                        throw new Exception($"El certificado esta expirado (Fecha de expiración {_certificado.GetExpirationDateString()}), '{_path_cert}'");


                ////
                //// Evalue el rut de la empresa que hace la consulta
                if (!HefRuts.ValidaRut(_rutEmpresa))
                    throw new Exception("El Rut de la empresa ingresado no es valido o no tiene el formato correcto.");

                ////
                //// Valide el trackid ingresado
                if (!Regex.IsMatch(_trackid, "\\d+", RegexOptions.Singleline))
                    throw new Exception("El trackid ingresado no es correcto.");

                #endregion

                #region CONSULTA DEL ESTADO

                ////
                //// En caso de consulta en certificación.
                if (!_esProduccion)
                {

                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoCertificacion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoCertificacion.wsRPETCConsultaService())
                    {
                        _estado_envio_cesion = HefConsultaServicio.getEstEnvio(_token, _trackid);
                    }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }

                ////
                //// En el caso de produccion
                if (_esProduccion)
                {
                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoProduccion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoProduccion.wsRPETCConsultaService())
                    {
                        _estado_envio_cesion = HefConsultaServicio.getEstEnvio(_token, _trackid);
                    }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }


                #endregion


            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario del problema
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta Estado Cesión";
                resp.Detalle = "No fue posible ejecutar la consulta. " + ex.Message;
                resp.Resultado = null;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta el estado de una cesion utilizando el trackid
        /// </summary>
        public static HefRespuesta ConsultarEstadoCesion(string _cn, string _rutEmpresa, string _TipoDoc,string FolioDoc, bool _esProduccion = false)
        {

            ////
            //// Inicie la respuesta del proceso
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;
            resp.Mensaje = "Consulta estado Cesión";
            resp.Detalle = null;
            resp.Resultado = null;

            ////
            //// Inicie el proceso
            try
            {

                #region VALIDACIONES

                ////
                //// Valide los parametros de la consulta.
                ////

                ////
                //// Normalice el rut
                _rutEmpresa = _rutEmpresa.ToUpper().Trim();

                ////
                //// Recupere el certificado utilizando el cn ingresado
                if (string.IsNullOrEmpty(_cn))
                    throw new Exception("El Cn no puede estar vacío.");

                ////
                //// Intente recuperar el certificado 
                X509Certificate2 _certificado = HefCertificados.obtenerCertificado(_cn);
                if (_certificado == null)
                    throw new Exception("El Certificado solicitado no existe o no se tiene acceso a el.");

                ////
                //// Evalue el rut de la empresa que hace la consulta
                if (!HefRuts.ValidaRut(_rutEmpresa))
                    throw new Exception("El Rut de la empresa ingresado no es valido o no tiene el formato correcto.");

                ////
                //// Evalue el tpoDoc
                if (!Regex.IsMatch(_TipoDoc,"\\d+",RegexOptions.Singleline))
                    throw new Exception("El tipo de documento no es valido.");

                ////
                //// Evalue el ////
                if (!Regex.IsMatch(FolioDoc, "\\d+", RegexOptions.Singleline))
                    throw new Exception("El folio del documento no es valido.");


                #endregion

                #region CONSULTA DEL ESTADO

                ////
                //// En caso de consulta en certificación.
                if (!_esProduccion)
                {

                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoCertificacion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoCertificacion.wsRPETCConsultaService())
                    {
                        ////
                        //// ejecute la consulta
                        _estado_envio_cesion = HefConsultaServicio.getEstCesion(
                            _token,
                                _rutEmpresa.Split('-')[0], 
                                    _rutEmpresa.Split('-')[1],
                                        _TipoDoc,
                                            FolioDoc,
                                                "");

                    }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Agregar parametros
                    resp.Parametros = $"Parametros ( RUT:{_rutEmpresa} - TIPO:{_TipoDoc} - FOLIO:{FolioDoc} )";

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }

                ////
                //// En el caso de produccion
                if (_esProduccion)
                {
                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoProduccion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoProduccion.wsRPETCConsultaService())
                            {
                                ////
                                //// ejecute la consulta
                                _estado_envio_cesion = HefConsultaServicio.getEstCesion(
                                    _token,
                                        _rutEmpresa.Split('-')[0],
                                            _rutEmpresa.Split('-')[1],
                                                _TipoDoc,
                                                    FolioDoc,
                                                        "");

                            }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }


                #endregion


            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario del problema
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta Estado Cesión";
                resp.Detalle = "No fue posible ejecutar la consulta. " + ex.Message;
                resp.Resultado = null;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Consulta el estado de una cesion utilizando el trackid
        /// </summary>
        public static HefRespuesta ConsultarEstadoCesion(string _path_cert, string _pass_cert, string _rutEmpresa, string _TipoDoc, string FolioDoc, bool _esProduccion = false)
        {

            ////
            //// Inicie la respuesta del proceso
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;
            resp.Mensaje = "Consulta estado Cesión";
            resp.Detalle = null;
            resp.Resultado = null;

            ////
            //// Inicie el proceso
            try
            {

                #region VALIDACIONES

                ////
                //// Valide los parametros de la consulta.
                ////

                ////
                //// Normalice el rut
                _rutEmpresa = _rutEmpresa.ToUpper().Trim();


                ////
                //// Recuperar el certificado digital
                if (!File.Exists(_path_cert))
                    throw new Exception($"No se encuentra o no se tiene acceso al certificado '{_path_cert}'.");
                if (string.IsNullOrEmpty(_pass_cert))
                    throw new Exception($"La password del certificado no puede estar vacío '{_path_cert}'.");

                ////
                //// Recupere el certificado
                X509Certificate2 _certificado = new X509Certificate2(_path_cert, _pass_cert);
                if (_certificado == null)
                    throw new Exception($"El Certificado solicitado no existe o no se tiene acceso a el. '{_path_cert}'");

                ////
                //// El certificado tiene clave privada?
                if (!_certificado.HasPrivateKey)
                    throw new Exception($"El Certificado no cuenta con la clave privada. '{_path_cert}'");

                ////
                //// El certificado esta expirado?
                DateTime dt;
                if (DateTime.TryParse(_certificado.GetExpirationDateString(), out dt))
                    if (dt < DateTime.Now)
                        throw new Exception($"El certificado esta expirado (Fecha de expiración {_certificado.GetExpirationDateString()}), '{_path_cert}'");

                ////
                //// Evalue el rut de la empresa que hace la consulta
                if (!HefRuts.ValidaRut(_rutEmpresa))
                    throw new Exception("El Rut de la empresa ingresado no es valido o no tiene el formato correcto.");

                ////
                //// Evalue el tpoDoc
                if (!Regex.IsMatch(_TipoDoc, "\\d+", RegexOptions.Singleline))
                    throw new Exception("El tipo de documento no es valido.");

                ////
                //// Evalue el ////
                if (!Regex.IsMatch(FolioDoc, "\\d+", RegexOptions.Singleline))
                    throw new Exception("El folio del documento no es valido.");


                #endregion

                #region CONSULTA DEL ESTADO

                ////
                //// En caso de consulta en certificación.
                if (!_esProduccion)
                {

                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Certificacion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Certificacion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoCertificacion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoCertificacion.wsRPETCConsultaService())
                    {
                        ////
                        //// ejecute la consulta
                        _estado_envio_cesion = HefConsultaServicio.getEstCesion(
                            _token,
                                _rutEmpresa.Split('-')[0],
                                    _rutEmpresa.Split('-')[1],
                                        _TipoDoc,
                                            FolioDoc,
                                                "");

                    }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Agregar parametros
                    resp.Parametros = $"Parametros ( RUT:{_rutEmpresa} - TIPO:{_TipoDoc} - FOLIO:{FolioDoc} )";

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }

                ////
                //// En el caso de produccion
                if (_esProduccion)
                {
                    ////
                    //// Recuperar trackid desde certificacion.
                    #region RECUPERAR TOKEN DESDE CERTIFICACION

                    ////
                    //// Recuperar Token
                    string _token = string.Empty;
                    using (HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService crSeedService = new HEFESTO.CESION.LIB.Proxys.Produccion.CrSeedService())
                    {
                        ////
                        //// Recupere la semilla
                        string _semilla = crSeedService.getSeed();

                        ////
                        //// Tenemos semilla?
                        Match m_semilla = Regex.Match(_semilla, "<SEMILLA>(.*?)</SEMILLA>", RegexOptions.Singleline);
                        if (!m_semilla.Success)
                            throw new Exception("La consulta de semilla al SII no regerso respuesta.");

                        ////
                        //// Cree el sobre de la semilla y firmela 
                        _semilla = "<getToken><item><Semilla>" + m_semilla.Groups[1].Value + "</Semilla></item></getToken>";
                        _semilla = firmarDocumentoSemilla(_semilla, _certificado);

                        ////
                        //// Consultar el token
                        using (HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService token = new HEFESTO.CESION.LIB.Proxys.Produccion.GetTokenFromSeedService())
                        {
                            ////
                            //// Recupere el token del SII utilizando la semilla firmada
                            _token = token.getToken(_semilla);

                            ////
                            //// EL SII regreso token?
                            Match m_token = Regex.Match(_token, "<TOKEN>(.*?)</TOKEN>", RegexOptions.Singleline);
                            if (!m_token.Success)
                                throw new Exception("La consulta de token al SII no regerso respuesta.");

                            ////
                            //// Recupere el valor del token
                            _token = m_token.Groups[1].Value;

                        }

                    }

                    #endregion

                    #region INICIE LA CONSULTA DESDE EL SII

                    ////
                    //// Consulte al sii por el estado del envio de cesion electrónica
                    string _estado_envio_cesion = "";
                    using (GetEstadoProduccion.wsRPETCConsultaService HefConsultaServicio =
                        new GetEstadoProduccion.wsRPETCConsultaService())
                    {
                        ////
                        //// ejecute la consulta
                        _estado_envio_cesion = HefConsultaServicio.getEstCesion(
                            _token,
                                _rutEmpresa.Split('-')[0],
                                    _rutEmpresa.Split('-')[1],
                                        _TipoDoc,
                                            FolioDoc,
                                                "");

                    }

                    ////
                    //// Idente el documento
                    _estado_envio_cesion = XDocument.Parse(_estado_envio_cesion).ToString();

                    #endregion

                    ////
                    //// Consutruya la respuesta del proceso
                    resp.EsCorrecto = true;
                    resp.Mensaje = "Consulta Estado Cesión";
                    resp.Detalle = "Consulta ejecutada correctamente";
                    resp.Resultado = _estado_envio_cesion;

                }


                #endregion


            }
            catch (Exception ex)
            {
                ////
                //// Notifique al usuario del problema
                resp.EsCorrecto = false;
                resp.Mensaje = "Consulta Estado Cesión";
                resp.Detalle = "No fue posible ejecutar la consulta. " + ex.Message;
                resp.Resultado = null;
            }

            ////
            //// regrese el valor de retorno
            return resp;

        }




    }

}
