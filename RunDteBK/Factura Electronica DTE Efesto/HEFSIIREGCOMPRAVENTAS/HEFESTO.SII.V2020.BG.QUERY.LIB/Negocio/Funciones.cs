using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using HEFSIIREGCOMPRAVENTAS.Negocio;

namespace HEFSIIREGCOMPRAVENTAS.LIB.Negocio
{
    /// <summary>
    /// Metodos y funciones comunes
    /// </summary>
    internal class Funciones
    {

        /// <summary>
        /// método que calcula el digito verificador a partir
        /// de la mantisa del rut
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        private static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        /// <summary>
        /// Valida el rut 
        /// </summary>
        internal static HefRespuesta ValidarRut(string rut)
        {
            ////
            //// Inicie el valor de retorno
            bool validacion = false;

            ////
            //// Cree la respuesta del proceso
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;

            ////
            //// Inicie el proceso de validación
            try
            {

                rut = rut.Replace(".", "").ToUpper();
                Regex expresion = new Regex("^([0-9]+-[0-9K])$");
                string dv = rut.Substring(rut.Length - 1, 1);
                if (!expresion.IsMatch(rut))
                {

                    resp.EsCorrecto = false;
                    resp.Mensaje = "Error en validación de rut.";
                    resp.Detalle = "El rut ingresado (" + rut + ")no parace ser valido.";
                    return resp;

                }
                char[] charCorte = { '-' };
                string[] rutTemp = rut.Split(charCorte);
                if (dv != Digito(int.Parse(rutTemp[0])))
                {
                    validacion = false;
                }
                validacion = true;
                
            }
            catch (Exception)
            {

            }

            ////
            //// interpretar el resultado
            if (validacion == false)
            {
                resp.EsCorrecto = false;
                resp.Mensaje = "Error en validación de rut.";
                resp.Detalle = "El rut ingresado (" + rut + ")no parace ser valido.";
            }

            ////
            //// interpretar el resultado
            if (validacion == true)
            {
                resp.EsCorrecto = true;
                resp.Mensaje = "Validación rut correcta.";
                resp.Detalle = "El rut ingresado (" + rut + ") es valido.";
            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Valida el periodo ingresado
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        internal static HefRespuesta ValidaPerido(string periodo)
        {
            ////
            //// Iniciar la respuesta
            HefRespuesta r = new HefRespuesta();

            try
            {
                ////
                //// Valide el formato
                if (!Regex.IsMatch(periodo, "[0-9]{4}-[0-9]{2}", RegexOptions.Singleline))
                    throw new Exception("Formato de periodo no es valido");

                ////
                //// Valide fecha
                DateTime dt;
                if ( !DateTime.TryParse(periodo+"-01", out dt ))
                    throw new Exception("Periodo ingresado no es valido.");

                r.EsCorrecto = true;



            }
            catch (Exception ex)
            {
                r.EsCorrecto = false;
                r.Mensaje = "No fue posible interpretar el periodo.";
                r.Detalle = ex.Message;
                
            }

            ////
            //// Regrese el valor de retorno
            return r;
        
        }

        // <summary>
        /// Valida el periodo ingresado
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        internal static HefRespuesta ValidaTipoDTE(string tipoDTE)
        {
            ////
            //// Iniciar la respuesta
            HefRespuesta r = new HefRespuesta();

            try
            {
                ////
                //// Valide el formato
                if (!Regex.IsMatch(tipoDTE, "[0-9]{2,3}", RegexOptions.Singleline))
                    throw new Exception("Formato del tipo dte no es valido");

                r.EsCorrecto = true;
            }
            catch (Exception ex)
            {
                r.EsCorrecto = false;
                r.Mensaje = "No fue posible interpretar el tipo dte.";
                r.Detalle = ex.Message;

            }

            ////
            //// Regrese el valor de retorno
            return r;

        }
        
        /// <summary>
        /// Recupera un determinado certificado para poder firmar un documento
        /// </summary>
        /// <param name="CN">Nombre del certificado que se busca</param>
        /// <returns>X509Certificate2</returns>
        internal static X509Certificate2 RecuperarCertificado(string CN)
        {

            ////
            //// Respuesta
            X509Certificate2 certificado = null;

            ////
            //// Certificado que se esta buscando
            if (string.IsNullOrEmpty(CN) || CN.Length == 0)
                return certificado;

            ////
            //// Inicie la busqueda del certificado
            try
            {

                ////
                //// Abra el repositorio de certificados para buscar el indicado
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection Certificados1 = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection Certificados2 = Certificados1.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection Certificados3 = Certificados2.Find(X509FindType.FindBySubjectName, CN, false);

                ////
                //// Si hay certificado disponible envíe el primero
                if (Certificados3 != null && Certificados3.Count != 0)
                    certificado = Certificados3[0];

                ////
                //// Cierre el almacen de sertificados
                store.Close();


            }
            catch (Exception)
            {
                certificado = null;
            }


            ////
            //// Regrese el valor de retorno 
            return certificado;

        }

        /// <summary>
        /// Interpreta la respuesa del SII
        /// </summary>
        /// <param name="data"></param>
        internal static HefRespuesta AnalizarRespuesta(string data)
        { 
            ////
            //// respuesta
            HefRespuesta r = new HefRespuesta();

            ////
            //// Cree el separadore 
            string[] miSeparador = new string[] { "\r\n" };

            ////
            //// Inicio
            try
            {
                ////
                //// Validar los errores
                if (string.IsNullOrEmpty(data))
                    throw new Exception("El SII no regreso ningun dato.");
                ////
                //// Validar los errores
                Match mRespuesta=   Regex.Match(
                    data,
                        "{\"codRespuesta\":(.*?),\"msgeRespuesta\":(.*?),",
                            RegexOptions.Singleline);

                ////
                //// Si no hay respuesta
                if (!mRespuesta.Success)
                    throw new Exception("El SII no regreso ningun resultado.");

                ////
                //// Cual es la respuesta?
                if ( !mRespuesta.Groups[1].Value.Equals("0")  )
                    throw new Exception("El SII indica un error en la consulta: " + mRespuesta.Groups[2].Value);
                
                ////
                //// Recupere la data de respuesta
                Match mdata = Regex.Match(data, "\"data\":\\[(.*?)\\]", RegexOptions.Singleline);
                if ( !mdata.Success )
                    throw new Exception("El SII no regreso ningun resultado (data).");

                ////
                //// parseo de datos para limpiar error de caracter
                //// separador 
                data = mdata.Groups[1].Value.Replace("\",\"", "\"|\"");
               
                
                ////
                //// Evaluar los datos
                string[] registros = data.Split('|');
                if ( registros.Count() == 0 )
                    throw new Exception("El SII no regreso ningun registro.");
                if (registros.Count() == 1)
                    throw new Exception("El SII no regreso ningun registro.");

                ////
                //// Recupere la cadena de headers y limpiela para generar los archivos xml
                string first_row = Regex.Replace(registros[0], "\"|\\s|\\(|\\)|\\.", "", RegexOptions.Singleline);
                
                ////
                //// recupere los encabezados de los registros
                string[] headers = first_row.Split(';');

                ////
                //// Elimine el header de los registros
                registros = registros.Skip(1).ToArray();

                ////
                //// Crear el registro
                string xdoc = "";
                xdoc += "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n<Hefesto_Resultado>\r\n";

                ////
                //// Recorra todos los registros y exctraiga los campos
                for (int row = 0; row <= registros.Count()-1; row++)
                { 

                    ////
                    //// Limpie la fila
                    xdoc += "<Reg>\r\n";
                    string fila = Regex.Replace(registros[row], "\"", "", RegexOptions.Singleline);
                    string[] campos = fila.Split(';');

                    ////
                    //// Inicie la construccón del documento Xml
                    for (int i = 0; i <= campos.Count() - 2; i++)
                    { 

                        ////
                        //// Cree el registro
                        string item = string.Format("\t<{0}>{1}</{2}>\r\n", headers[i], campos[i], headers[i]);
                        xdoc += item;
                    
                    }

                    ////
                    //// Cierre el registro
                    xdoc += "</Reg>\r\n";
                }
    
                ////
                //// Cierre el documento
                xdoc += "</Hefesto_Resultado>";

                ////
                //// Construir la respuesta
                r.EsCorrecto = true;
                r.Mensaje = "Se construyo correctamente la respuesta.";
                r.Resultado = xdoc;

            }
            catch (Exception ex)
            {
                ////
                //// Construir la respuesta
                r.EsCorrecto = false;
                r.Mensaje = "No fue posible contruir el documento xml de respuesta.";
                r.Detalle = ex.Message;
                
            }

            ////
            //// regrese la respuesta del proceso
            return r;
            
        }

        /// <summary>
        /// Interpreta la respuesa del SII
        /// </summary>
        /// <param name="data"></param>
        internal static HefRespuesta AnalizarRespuestaResumen(string data)
        {
            ////
            //// respuesta
            HefRespuesta r = new HefRespuesta();

            ////
            //// Cree el separadore 
            string[] miSeparador = new string[] { "\r\n" };

            ////
            //// Inicio
            try
            {
                ////
                //// Validar los errores
                if (string.IsNullOrEmpty(data))
                    throw new Exception("El SII no regreso ningun dato.");
                ////
                //// Validar los errores
                Match mRespuesta = Regex.Match(
                    data,
                        "{\"codRespuesta\":(.*?),\"msgeRespuesta\":(.*?),",
                            RegexOptions.Singleline);

                ////
                //// Si no hay respuesta
                if (!mRespuesta.Success)
                    throw new Exception("El SII no regreso ningun resultado.");

                ////
                //// Cual es la respuesta?
                if (!mRespuesta.Groups[1].Value.Equals("0"))
                    throw new Exception("El SII indica un error en la consulta: " + mRespuesta.Groups[2].Value);

                ////
                //// Recupere la data de respuesta
                Match mdata = Regex.Match(data, "\"data\":\\[(.*?)\\]", RegexOptions.Singleline);
                if (!mdata.Success)
                    throw new Exception("El SII no regreso ningun resultado (data).");

                ////
                //// Recuperar los elementos que representan los resumenes
                MatchCollection mResumenes = Regex.Matches(mdata.Value, @"\{(.*?)\}", RegexOptions.Singleline);
                if ( mResumenes.Count == 0 )
                    throw new Exception("El SII no regreso ningun resumen.");
                
                ////
                //// Interpretar los elementos
                string sxml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n<Hefesto_Resultado>\r\n";
                foreach (Match mResumen in mResumenes)
                { 
                    ////
                    //// Construya el registro.
                    string[] Elementos = Regex.Replace(
                        mResumen.Groups[1].Value,
                            "\"",
                             "",
                                RegexOptions.Singleline).Split(',');

                    ////
                    //// Construya los items del documento Xml
                    sxml += "<Res>\r\n";
                    foreach (string Elemento in Elementos)
                    {
                        string tagname = Elemento.Split(':')[0];
                        string tagvalu = Elemento.Split(':')[1];
                        sxml += string.Format("<{0}>{1}</{2}>\r\n", tagname,tagvalu,tagname);
                    
                    }
                    sxml += "</Res>\r\n";
                
                }
                sxml += "</Hefesto_Resultado>";
                
                ////
                //// Construir la respuesta
                r.EsCorrecto = true;
                r.Mensaje = "Se construyo correctamente la respuesta.";
                r.Resultado = sxml;

            }
            catch (Exception ex)
            {
                ////
                //// Construir la respuesta
                r.EsCorrecto = false;
                r.Mensaje = "No fue posible contruir el documento xml de respuesta.";
                r.Detalle = ex.Message;

            }

            ////
            //// regrese la respuesta del proceso
            return r;

        }


        /// <summary>
        /// Genera reporte de registros de ventas en formato json
        /// </summary>
        /// <returns></returns>
        internal static HefRespuesta GenerarResumenVentasJson(Dictionary<string,string> elementos)
        {
            ////
            //// Inicie la respuesta
            HefRespuesta resp = new HefRespuesta();
            resp.Mensaje = "Recuperación de registros de ventas.";

            ////
            //// Variable de salida
            string _salida = string.Empty;


            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Lea todos los registros
                string[] stringSeparators = new string[] { "\r\n" };
                foreach (KeyValuePair<string, string> elemento in elementos)
                {
                    
                    ////
                    //// cual es el key
                    string key = elemento.Key;
                    string val = elemento.Value;

                    ////
                    //// Inicie el proceso de lectura del valor del objeto
                    val = val.Remove(0,1);
                    val = val.Remove(val.Length-1, 1);

                    ////
                    //// Recupere todas las filas del registro
                    string[] filas = val.Split(stringSeparators, StringSplitOptions.None);
                    
                    ////
                    //// Recupere la primera fila 
                    string[] _headers = filas[0].Split(';');
                    _headers = _headers.Select(p => { p = 
                        Regex.Replace(p, "[\\s.,\\(\\)]+", "",RegexOptions.Singleline)  ; return p; })
                            .ToArray();


                    ////
                    //// Recorra todas las filas del archivo
                    for (int f = 1; f <= filas.Count() - 1; f++)
                    {
                        ////
                        //// Arreglo de datos
                        string[] _datos = filas[f].Split(';');

                        ////
                        //// Cree el arreglo
                        string _registro = "{\r\n";
                        for (int i = 0; i <= _headers.Length - 1; i++)
                        {
                            if (i == _headers.Length - 1)
                                _registro += $"  \"{_headers[i]}\":\"{_datos[i]}\"\r\n";
                            else
                                _registro += $"  \"{_headers[i]}\":\"{_datos[i]}\",\r\n";
                        }
                        
                        _registro += "}";

                        ////
                        //// Agregar al registro el tipo de documento consultado
                        //// con el fin de identificar el tipo de documento.
                        _registro = Regex.Replace(_registro, "\"TipoVenta\"", "\"TipoDTE\":\"" + key + "\",\r\n  \"TipoVenta\"", RegexOptions.Singleline); ;

                        ////
                        //// Separe los registros si corresponde
                        if (f != filas.Count() - 1)
                            _registro += ",\r\n";

                        ////
                        //// Concatene la saida
                        _salida += _registro;

                    }

                }

                ////
                //// Cree el resultado
                string _documento = "{\r\n";
                _documento += "\"RegistrosVentas\":\r\n";
                _documento += "[\r\n";
                _documento += _salida;
                _documento += "]\r\n";
                _documento += "}\r\n";

                ////
                //// Normalice el documento
                _documento = Regex.Replace(_documento, "\\}\\{", "},\r\n{", RegexOptions.Singleline);

                ////
                //// ordene el resultado
                _documento = Regex.Replace(_documento,"\r\n","",RegexOptions.Singleline);
                _documento = JsonHelper.FormatJson(_documento);

                ////
                //// regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Detalle = "Recuperación correcta de registros";
                resp.Resultado = _documento;

            }
            catch (Exception ex)
            {
                resp.EsCorrecto = false;
                resp.Detalle = ex.Message;
            }

            ////
            //// Return 
            return resp;

        }

        /// <summary>
        /// Genera reporte de registros de ventas en formato json
        /// </summary>
        /// <returns></returns>
        internal static HefRespuesta GenerarResumenComprasJson(Dictionary<string, string> elementos, string rootName)
        {
            ////
            //// Inicie la respuesta
            HefRespuesta resp = new HefRespuesta();
            resp.Mensaje = "Recuperación de registros de compras.";

            ////
            //// Variable de salida
            string _salida = string.Empty;

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Lea todos los registros
                string[] stringSeparators = new string[] { "\r\n" };
                foreach (KeyValuePair<string, string> elemento in elementos)
                {

                    ////
                    //// cual es el key
                    string key = elemento.Key;
                    string val = elemento.Value;

                    ////
                    //// Inicie el proceso de lectura del valor del objeto
                    val = val.Remove(0, 1);
                    val = val.Remove(val.Length - 1, 1);

                    ////
                    //// Recupere todas las filas del registro
                    string[] filas = val.Split(stringSeparators, StringSplitOptions.None);

                    ////
                    //// Recupere la primera fila 
                    string[] _headers = filas[0].Split(';');
                    _headers = _headers.Select(p => {
                        p =
                        Regex.Replace(p, "[\\s.,\\(\\)]+", "", RegexOptions.Singleline); return p;
                    })
                            .ToArray();


                    ////
                    //// Recorra todas las filas del archivo
                    for (int f = 1; f <= filas.Count() - 1; f++)
                    {
                        ////
                        //// Arreglo de datos
                        string[] _datos = filas[f].Split(';');

                        ////
                        //// Cree el arreglo
                        string _registro = "{\r\n";
                        for (int i = 0; i <= _headers.Length - 1; i++)
                        {
                            if (i == _headers.Length - 1)
                                _registro += $"  \"{_headers[i]}\":\"{_datos[i]}\"\r\n";
                            else
                                _registro += $"  \"{_headers[i]}\":\"{_datos[i]}\",\r\n";
                        }

                        _registro += "}";

                        ////
                        //// Agregar al registro el tipo de documento consultado
                        //// con el fin de identificar el tipo de documento.
                        _registro = Regex.Replace(_registro, "\"TipoCompra\"", "\"TipoDTE\":\"" + key + "\",\r\n  \"TipoCompra\"", RegexOptions.Singleline); ;

                        ////
                        //// Separe los registros si corresponde
                        if (f != filas.Count() - 1)
                            _registro += ",\r\n";

                        ////
                        //// Concatene la saida
                        _salida += _registro;

                    }

                }

                ////
                //// Cree el resultado
                string _documento = "{\r\n";
                _documento += "\""+ rootName + "\":\r\n";
                _documento += "[\r\n";
                _documento += _salida;
                _documento += "]\r\n";
                _documento += "}\r\n";

                ////
                //// Normalice el documento
                _documento = Regex.Replace(_documento, "\\}\\{", "},\r\n{", RegexOptions.Singleline);

                ////
                //// ordene el resultado
                _documento = Regex.Replace(_documento, "\r\n", "", RegexOptions.Singleline);
                _documento = JsonHelper.FormatJson(_documento);

                ////
                //// regrese el valor de retorno
                resp.EsCorrecto = true;
                resp.Detalle = "Recuperación correcta de registros";
                resp.Resultado = _documento;

            }
            catch (Exception ex)
            {
                resp.EsCorrecto = false;
                resp.Detalle = ex.Message;
            }

            ////
            //// Return 
            return resp;

        }

    }

}
