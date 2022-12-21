using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.RegularExpressions;
using HEFSIIREGCOMPRAVENTAS.LIB.Negocio;
using HEFSIIREGCOMPRAVENTAS.LIB.RegistroCV;

namespace HEFSIIREGCOMPRAVENTAS.LIB
{
    /// <summary>
    /// Punto entrada a sistema
    /// </summary>
    public class HefConsultas
    {

        /// <summary>
        /// Representa el rut de la empresa que realiza la consulta
        /// </summary>
        public string RutEmpresa { get; set; }

        /// <summary>
        /// Representa el certificado del usuario para realizar la consulta
        /// </summary>
        public X509Certificate2 Certificado { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="RutEmisor">Rut del emisor de documentos</param>
        /// <param name="Cn">Nombre del certificado</param>
        public HefConsultas(string RutEmisor, string Cn)
        { 
        
            ////
            //// Iniciar la validacion del rut de la empresa.
            HefRespuesta resp = Negocio.Funciones.ValidarRut(RutEmisor.ToUpper());
            if (!resp.EsCorrecto)
                throw new Exception( resp.Detalle );

            ////
            //// Actualie el valor en la clase
            this.RutEmpresa = RutEmisor.ToUpper();
            
            ////
            //// Recuperar el certificado digital suministrado.
            X509Certificate2 certificado = Negocio.Funciones.RecuperarCertificado(Cn);
            if (certificado == null)
                throw new Exception("No se encuentra el certificado o no se tiene acceso a el.");

            ////
            //// Agregrar el certificado
            this.Certificado = certificado;
            
        }

        /// <summary>
        /// Constructor de clase recuperacion registros 
        /// </summary>
        /// <param name="RutEmisor">Rut del emisor de los documentos</param>
        /// <param name="Cert_path">Fullpath del archivo pfx</param>
        /// <param name="Cert_pass">Password del certificado</param>
        public HefConsultas(string RutEmisor, string Cert_path, string Cert_pass)
        {

            ////
            //// Iniciar la validacion del rut de la empresa.
            HefRespuesta resp = Negocio.Funciones.ValidarRut(RutEmisor.ToUpper());
            if (!resp.EsCorrecto)
                throw new Exception(resp.Detalle);

            ////
            //// Actualie el valor en la clase
            this.RutEmpresa = RutEmisor.ToUpper();

            ////
            //// Inicie la recuperación del certificado
            if (!File.Exists(Cert_path))
                throw new Exception("No se encuentra o no se tiene acceso al certificado pfx.");

            ////
            //// Valide que la password tiene valor o no
            if (string.IsNullOrEmpty(Cert_pass))
                throw new Exception("Password del certificado no puede estar vacía.");

            ////
            //// Inicie la generación del certificado
            X509Certificate2 certificado = new X509Certificate2(Cert_path, Cert_pass);
            if (certificado == null)
                throw new Exception("No fue posible recuperar el certificado.");

            ////
            //// El certificado tiene clave privada
            if ( !certificado.HasPrivateKey )
                throw new Exception("El certificado no tiene private key.");

            ////
            //// Evalue la fecha de expiración
            DateTime dt;
            if ( !DateTime.TryParse( certificado.GetExpirationDateString(), out dt) )
                throw new Exception("No fue posible recueperar la fecha de expiración del certificado.");

            ////
            //// El certificado expiró?
            if ( DateTime.Now > dt  )
                throw new Exception("El certificado esta expirado.");

            ////
            //// Agregrar el certificado
            this.Certificado = certificado;

        }

        /// <summary>
        /// Constructor de clase recuperacion registros 
        /// </summary>
        /// <param name="RutEmisor">Rut del emisor de los documentos</param>
        /// <param name="Cert_path">Fullpath del archivo pfx</param>
        /// <param name="Cert_pass">Password del certificado</param>
        public HefConsultas(string RutEmisor, X509Certificate2 certificado)
        {

            ////
            //// Iniciar la validacion del rut de la empresa.
            HefRespuesta resp = Negocio.Funciones.ValidarRut(RutEmisor.ToUpper());
            if (!resp.EsCorrecto)
                throw new Exception(resp.Detalle);

            ////
            //// Actualie el valor en la clase
            this.RutEmpresa = RutEmisor.ToUpper();

            ////
            //// El certificado tiene clave privada
            if (!certificado.HasPrivateKey)
                throw new Exception("El certificado no tiene private key.");

            ////
            //// Evalue la fecha de expiración
            DateTime dt;
            if (!DateTime.TryParse(certificado.GetExpirationDateString(), out dt))
                throw new Exception("No fue posible recueperar la fecha de expiración del certificado.");

            ////
            //// El certificado expiró?
            if (DateTime.Now > dt)
                throw new Exception("El certificado esta expirado.");

            ////
            //// Agregrar el certificado
            this.Certificado = certificado;

        }


        /// <summary>
        /// Recupera el resumen de compras 
        /// </summary>
        public HefRespuesta RecuperarResumenCompras(string periodo, TipoResumen tpoResumen = TipoResumen.REGISTRO)
        { 
        
            ////
            //// Recupere el token desde el SII
            HefRespuesta resp = Connecion.HefCertificado.RecuperarConeccion2(this.RutEmpresa, this.Certificado);
            if (!resp.EsCorrecto)
                throw new Exception("No fue posible establecer conección con sii.");

            ////
            //// Recupere el token
            string token = resp.Resultado.ToString();

            ////
            //// Validar periodo
            resp = Negocio.Funciones.ValidaPerido(periodo);
            if ( !resp.EsCorrecto )
                throw new Exception("Periodo no es valido.");

            ////
            //// 
            return RegistroCV.HefRegCompraVenta.RecuperarResumenCompras(token, this.RutEmpresa, periodo, tpoResumen);

        }

        /// <summary>
        /// Recupera el resumen de compras 
        /// </summary>
        public HefRespuesta RecuperarResumenCompras(string periodo, string token)
        {
            ////
            //// Recuperar resumen de compras
            return RegistroCV.HefRegCompraVenta.RecuperarResumenCompras(token, this.RutEmpresa, periodo);

        }

        /// <summary>
        /// Recupera los registros de compras desde el registro usando el periodo yyyy-MM
        /// </summary>
        public HefRespuesta RecuperarComprasRegistro(string periodo)
        {
            ////
            //// Recupere el token desde el SII
            HefRespuesta resp = Connecion.HefCertificado.RecuperarConeccion2(this.RutEmpresa, this.Certificado);
            if (!resp.EsCorrecto)
                throw new Exception("No fue posible establecer conección con sii.");

            ////
            //// Recupere el token
            string token = resp.Resultado.ToString();

            ////
            //// Validar periodo
            resp = Negocio.Funciones.ValidaPerido(periodo);
            if (!resp.EsCorrecto)
                throw new Exception("Periodo no es valido.");

            ////
            //// Recuperar el resumen de compras del registro
            HefRespuesta respResumen = RecuperarResumenCompras(periodo);
            if ( !respResumen.EsCorrecto )
                throw new Exception("No fue posible recuperar el resumen de compras.");

            ////
            //// Recupere todos los documentos que estan disponibles para la consulta actual
            //// <rsmnTipoDocInteger>33</rsmnTipoDocInteger>
            string data = respResumen.Resultado.ToString();
            List<string> docs = Regex.Matches(
                data,
                    "\"rsmnTipoDocInteger\":\\s(.*?),",
                        RegexOptions.Singleline).Cast<Match>()
                            .Select(m => m.Groups[1].Value)
                                .ToList();

            ////
            //// Remueva los documentos boletas que no son necesarios
            docs.RemoveAll(delegate (string i)
            {
                if (i == "39" || i == "41")
                    return true;
                return false;

            });

            ////
            //// Inicie la recuperación de los registros
            Dictionary<string, string> _resultados = new Dictionary<string, string>();
            foreach (string TipoDTE in docs)
            {

                ////
                //// Inicie la recuperación de los registros de compras
                HefRespuesta respRegistros = RegistroCV.HefRegCompraVenta.RecuperarComprasGeneral(
                    "REGISTRO",
                        token,
                            this.RutEmpresa,
                                periodo,
                                    TipoDTE);

                ////
                //// Si hay resultado recuperelo y recupere solo la data
                if (respRegistros.EsCorrecto)
                    _resultados.Add(TipoDTE,
                                        Regex.Match(
                                            respRegistros.Resultado.ToString(),
                                                "\\[(.*?)\\]",
                                                    RegexOptions.Singleline
                                                        ).Groups[1].Value.Replace("\",\"", "\r\n"));


            }

            ////
            //// Inicie la generación del reporte en formato json
            return Funciones.GenerarResumenComprasJson(_resultados, "RegistroCompras");

        }

        /// <summary>
        /// Recupera los registros de compras desde el registro usando el periodo yyyy-MM
        /// </summary>
        public HefRespuesta RecuperarComprasPendientes(string periodo)
        {
            ////
            //// Recupere el token desde el SII
            HefRespuesta resp = Connecion.HefCertificado.RecuperarConeccion2(this.RutEmpresa, this.Certificado);
            if (!resp.EsCorrecto)
                throw new Exception("No fue posible establecer conección con sii.");

            ////
            //// Recupere el token
            string token = resp.Resultado.ToString();

            ////
            //// Validar periodo
            resp = Negocio.Funciones.ValidaPerido(periodo);
            if (!resp.EsCorrecto)
                throw new Exception("Periodo no es valido.");

            ////
            //// Recuperar el resumen de compras del registro
            HefRespuesta respResumen = RecuperarResumenCompras(periodo);
            if (!respResumen.EsCorrecto)
                throw new Exception("No fue posible recuperar el resumen de compras.");

            ////
            //// Recupere todos los documentos que estan disponibles para la consulta actual
            //// <rsmnTipoDocInteger>33</rsmnTipoDocInteger>
            string data = respResumen.Resultado.ToString();
            List<string> docs = Regex.Matches(
                data,
                    "\"rsmnTipoDocInteger\":\\s(.*?),",
                        RegexOptions.Singleline).Cast<Match>()
                            .Select(m => m.Groups[1].Value)
                                .ToList();

            ////
            //// Remueva los documentos boletas que no son necesarios
            docs.RemoveAll(delegate (string i)
            {
                if (i == "39" || i == "41")
                    return true;
                return false;

            });

            ////
            //// Inicie la recuperación de los registros
            Dictionary<string, string> _resultados = new Dictionary<string, string>();
            foreach (string TipoDTE in docs)
            {

                ////
                //// Inicie la recuperación de los registros de compras
                HefRespuesta respRegistros = RegistroCV.HefRegCompraVenta.RecuperarComprasGeneral(
                    "PENDIENTE",
                        token,
                            this.RutEmpresa,
                                periodo,
                                    TipoDTE);

                ////
                //// Si hay resultado recuperelo y recupere solo la data
                if (respRegistros.EsCorrecto)
                    _resultados.Add(TipoDTE,
                                        Regex.Match(
                                            respRegistros.Resultado.ToString(),
                                                "\\[(.*?)\\]",
                                                    RegexOptions.Singleline
                                                        ).Groups[1].Value.Replace("\",\"", "\r\n"));


            }

            ////
            //// Inicie la generación del reporte en formato json
            return Funciones.GenerarResumenComprasJson(_resultados, "RegistroComprasPendientes");

        }

        /// <summary>
        /// Recupera los registros de compras desde el registro usando el periodo yyyy-MM
        /// </summary>
        public HefRespuesta RecuperarComprasNoIncluir(string periodo)
        {
            ////
            //// Recupere el token desde el SII
            HefRespuesta resp = Connecion.HefCertificado.RecuperarConeccion2(this.RutEmpresa, this.Certificado);
            if (!resp.EsCorrecto)
                throw new Exception("No fue posible establecer conección con sii.");

            ////
            //// Recupere el token
            string token = resp.Resultado.ToString();

            ////
            //// Validar periodo
            resp = Negocio.Funciones.ValidaPerido(periodo);
            if (!resp.EsCorrecto)
                throw new Exception("Periodo no es valido.");

            ////
            //// Recuperar el resumen de compras del registro
            HefRespuesta respResumen = RecuperarResumenCompras(periodo, token);
            if (!respResumen.EsCorrecto)
                throw new Exception("No fue posible recuperar el resumen de compras.");

            ////
            //// Recupere todos los documentos que estan disponibles para la consulta actual
            //// <rsmnTipoDocInteger>33</rsmnTipoDocInteger>
            string data = respResumen.Resultado.ToString();
            List<string> docs = Regex.Matches(
                data,
                    "\"rsmnTipoDocInteger\":\\s(.*?),",
                        RegexOptions.Singleline).Cast<Match>()
                            .Select(m => m.Groups[1].Value)
                                .ToList();

            ////
            //// Remueva los documentos boletas que no son necesarios
            docs.RemoveAll(delegate (string i)
            {
                if (i == "39" || i == "41")
                    return true;
                return false;

            });

            ////
            //// Inicie la recuperación de los registros
            Dictionary<string, string> _resultados = new Dictionary<string, string>();
            foreach (string TipoDTE in docs)
            {

                ////
                //// Inicie la recuperación de los registros de compras
                HefRespuesta respRegistros = RegistroCV.HefRegCompraVenta.RecuperarComprasGeneral(
                    "NO_INCLUIR",
                        token,
                            this.RutEmpresa,
                                periodo,
                                    TipoDTE);

                ////
                //// Si hay resultado recuperelo y recupere solo la data
                if (respRegistros.EsCorrecto)
                    _resultados.Add(TipoDTE,
                                        Regex.Match(
                                            respRegistros.Resultado.ToString(),
                                                "\\[(.*?)\\]",
                                                    RegexOptions.Singleline
                                                        ).Groups[1].Value.Replace("\",\"", "\r\n"));


            }

            ////
            //// Inicie la generación del reporte en formato json
            return Funciones.GenerarResumenComprasJson(_resultados, "RegistroComprasNoIncluir");


        }

        /// <summary>
        /// Recupera los registros de compras desde el registro usando el periodo yyyy-MM
        /// </summary>
        public HefRespuesta RecuperarComprasReclamadas(string periodo)
        {
            ////
            //// Recupere el token desde el SII
            HefRespuesta resp = Connecion.HefCertificado.RecuperarConeccion2(this.RutEmpresa, this.Certificado);
            if (!resp.EsCorrecto)
                throw new Exception("No fue posible establecer conección con sii.");
            ////
            //// Recupere el token
            string token = resp.Resultado.ToString();

            ////
            //// Validar periodo
            resp = Negocio.Funciones.ValidaPerido(periodo);
            if (!resp.EsCorrecto)
                throw new Exception("Periodo no es valido.");


            ////
            //// Recuperar el resumen de compras del registro
            HefRespuesta respResumen = RecuperarResumenCompras(periodo, token);
            if (!respResumen.EsCorrecto)
                throw new Exception("No fue posible recuperar el resumen de compras.");

            ////
            //// Recupere todos los documentos que estan disponibles para la consulta actual
            //// <rsmnTipoDocInteger>33</rsmnTipoDocInteger>
            string data = respResumen.Resultado.ToString();
            List<string> docs = Regex.Matches(
                data,
                    "\"rsmnTipoDocInteger\":\\s(.*?),",
                        RegexOptions.Singleline).Cast<Match>()
                            .Select(m => m.Groups[1].Value)
                                .ToList();

            ////
            //// Remueva los documentos boletas que no son necesarios
            docs.RemoveAll(delegate (string i)
            {
                if (i == "39" || i == "41")
                    return true;
                return false;

            });

            ////
            //// Inicie la recuperación de los registros
            Dictionary<string, string> _resultados = new Dictionary<string, string>();
            foreach (string TipoDTE in docs)
            {

                ////
                //// Inicie la recuperación de los registros de compras
                HefRespuesta respRegistros = RegistroCV.HefRegCompraVenta.RecuperarComprasGeneral(
                    "RECLAMADO",
                        token,
                            this.RutEmpresa,
                                periodo,
                                    TipoDTE);

                ////
                //// Si hay resultado recuperelo y recupere solo la data
                if (respRegistros.EsCorrecto)
                    _resultados.Add(TipoDTE,
                                        Regex.Match(
                                            respRegistros.Resultado.ToString(),
                                                "\\[(.*?)\\]",
                                                    RegexOptions.Singleline
                                                        ).Groups[1].Value.Replace("\",\"", "\r\n"));


            }

            ////
            //// Inicie la generación del reporte en formato json
            return Funciones.GenerarResumenComprasJson(_resultados, "RegistroComprasReclamadas");


        }



        #region SECCION VENTAS


        /// <summary>
        /// Recupera el resumen de ventas desde el SII
        /// </summary>
        /// <param name="periodo"></param>
        public HefRespuesta RecuperarResumenVentas(string periodo)
        {
            ////
            //// Recupere el token desde el SII
            HefRespuesta resp = Connecion.HefCertificado.RecuperarConeccion2(this.RutEmpresa, this.Certificado);
            if (!resp.EsCorrecto)
                throw new Exception("No fue posible establecer conección con sii.");

            ////
            //// Recupere el token
            string token = resp.Resultado.ToString();

            ////
            //// Validar periodo
            resp = Negocio.Funciones.ValidaPerido(periodo);
            if (!resp.EsCorrecto)
                throw new Exception("Periodo no es valido.");

            ////
            //// Recupere los registros
            return RegistroCV.HefRegCompraVenta.RecuperarResumenVentas(token, this.RutEmpresa, periodo);
        
        
        }

        /// <summary>
        /// Recupera la información completa de ventas
        /// </summary>
        public HefRespuesta RecuperarVentasRegistro(string periodo)
        {
            ////
            //// Cree la respuesta del proceso
            HefRespuesta resp = new HefRespuesta();
            resp.Mensaje = "Recuperación de registros completos de ventas.";

            ////
            //// inicie el proceso
            try
            {
                ////
                //// Recupere el token desde el SII
                HefRespuesta respToken = Connecion.HefCertificado.RecuperarConeccion2(this.RutEmpresa, this.Certificado);
                if (!respToken.EsCorrecto)
                    throw new Exception("No fue posible establecer conección con sii.");

                ////
                //// Recupere el token
                string token = respToken.Resultado.ToString();

                ////
                //// Validar periodo
                HefRespuesta respPeriodo = Negocio.Funciones.ValidaPerido(periodo);
                if (!respPeriodo.EsCorrecto)
                    throw new Exception("Periodo no es valido.");

                ////
                //// Recupere el resumen de ventas para extraer los tipos de documentos que estan disponibles
                HefRespuesta respResumen = RecuperarResumenVentas(periodo);
                if (!respResumen.EsCorrecto)
                    throw new Exception("No fue posible recuperar el resumen de ventas.");

                ////
                //// Recupere todos los documentos que estan disponibles para la consulta actual
                //// <rsmnTipoDocInteger>33</rsmnTipoDocInteger>
                string data = respResumen.Resultado.ToString();
                List<string> docs = Regex.Matches(
                    data,
                        "\"rsmnTipoDocInteger\":\\s(.*?),",
                            RegexOptions.Singleline).Cast<Match>()
                                .Select(m => m.Groups[1].Value)
                                    .ToList();

                ////
                //// Remueva los documentos boletas que no son necesarios
                docs.RemoveAll(delegate (string i)
                {
                    if (i == "39" || i == "41")
                        return true;
                    return false;
                });

                ////
                //// Inicie la recuperación de los registros
                Dictionary<string, string> _resultados = new Dictionary<string, string>();
                foreach (string TipoDTE in docs)
                {

                    ////
                    //// Recupere los registros 
                    HefRespuesta respRegistros = RegistroCV.HefRegCompraVenta.RecuperarVentasRegistro(
                        token, 
                            RutEmpresa,
                                periodo,
                                    TipoDTE);

                    ////
                    //// Si hay resultado recuperelo y recupere solo la data
                    if (respRegistros.EsCorrecto)
                        _resultados.Add(TipoDTE,
                                            Regex.Match(
                                                respRegistros.Resultado.ToString(),
                                                    "\\[(.*?)\\]",
                                                        RegexOptions.Singleline
                                                            ).Groups[1].Value.Replace("\",\"", "\r\n"));


                }

                ////
                //// Inicie la generación del reporte en formato json
                resp = Funciones.GenerarResumenVentasJson(_resultados);

            }
            catch (Exception ex)
            {
                ////
                //// Notifique el error
                resp.EsCorrecto = false;
                resp.Detalle = "No fue posible ejecutar la consulta: " + ex.Message;
                
            }

            ////
            //// Regrese el valor de retorno
            return resp;
            
        }

        #endregion

    }

}
