using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HEFSIIREGCOMPRAVENTAS.Negocio;

namespace HEFSIIREGCOMPRAVENTAS.LIB.RegistroCV
{

    public enum TipoResumen
    {
        REGISTRO,
        PENDIENTE,
        NO_INCLUIR,
        RECLAMADO
    }

    /// <summary>
    /// Recupera registros de compra y venta
    /// </summary>
    internal class HefRegCompraVenta
    {

        /// <summary>
        /// Inicia la recuperación de las facturas de compras desde el
        /// Sitio WEB ( Avanzado )
        /// </summary>
        internal static HefRespuesta RecuperarResumenCompras(string cookie, string RutEmpresa, string Periodo, TipoResumen tpoResumen = TipoResumen.REGISTRO)
        {
            ////
            //// Inicie la respuesta
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;

            ////
            //// Variables
            string data = string.Empty;

            ////
            //// Identifique la url donde recuperar la información
            string uriSIITarget = "https://www4.sii.cl/consdcvinternetui/services/data/facadeService/getResumen";
            string uriReference = "https://www4.sii.cl/consdcvinternetui/";

            ////
            //// Inicie el procesamiento
            try
            {

                ////
                //// Crear conección a la página con la informacion
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uriSIITarget);
                webRequest.Method = "POST";
                webRequest.Accept = "application/json, text/plain, */*";
                webRequest.ContentType = "application/json";
                webRequest.Referer = uriReference;
                webRequest.Headers.Add("Accept-Language", "es-ES");
                webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                webRequest.Host = "www4.sii.cl";
                webRequest.Headers.Add("DNT", "1");
                webRequest.Headers.Add("Cache-Control", "no-cache");
                webRequest.Headers.Add("Cookie", cookie);

                ////
                //// Construya los datos del post
                List<string> arr = cookie.Split(';').ToList<string>();
                string conversationId = arr.Where(i => i.Contains("TOKEN")).FirstOrDefault().Split('=')[1];
                Guid originalGuid = Guid.NewGuid();
                string transactionId = originalGuid.ToString("D");
                string rutEmisor = RutEmpresa.Split('-')[0];
                string dvEmisor = RutEmpresa.Split('-')[1].ToUpper();
                string ptributario = Periodo.Replace("-", "");
                string accionRecaptcha = "RCV_DDETC";
                string tokenRecaptcha = "03AFcWeA5o4PmQ_J4qg9E6MgRSgL1CkuQYA6moaBhJrgRcxLIG69jNLA4KWofHfrcFQhzbKPHPMm8Mf2DnJ9gD2WgKvWFSXP-RnTzvJEpH3Kj_uB4vMshwHotpPCTgm_JBCqnn_5Qz6XmMAmalFtvjC-DSANJ-iQ8O5nXiq2xFH0fDFzkqUqedrbce-tRvLmhC_1ia0FO4wz4W2qsz2I9ffiC8HhcyUN-yVWUzGfcSKOC25RRCD5Tlhg7mpWAAjtawUwaid4kbsPUsnwCGwvPH6xfSYfdmVpduojPoolje0xQjSbf2MSK3H7ooj0xs0gDTeesW7kjN_g6WoL0cZp5xgSxdUK6AHykDwQ9u1az_RjVDYT-GLftgOc_NQEvsgHca8mbz5m1rQaAkuTnVrKQPviYmr-Z4TmwP3qTNTNhyhgySpaQsOtsGkLVTq7XV5CYtDivD8VnEUX4ImvnUxZS7Tqj6B5Ekalr36fdjW2qB7zRwhoopaDivQ0xYY2QbvhoKhjfn5A67PlXdt852sgAMGUBcfCgxhZpGjFwRj9I0pQfJ2kM_3CEV9rb2Iha4JOGjttmH-Teq9rL45NbdzDH2E0b026aMoAav0ZTA2eYwYNBSA_ixXUxwpjb6AXRcU-LvctQye2uhwBzZTDKp8DqtFnRzK-_OnwNhYz5e8MSoUhnWZFh5nRRLRfdPRan7krwB29rT1vEKcfhxj5oigfk02sensBtDccZrSd6QuDWZVHjAQ3rCqs3BCc3BY8T9s4txlrCKbjbLrw8GjOBOy8RARiw7iGDSJGkvtQVLIclkg-H2dMisawL0qyXzQ5rLKsWfVsIpKyFZGZUDsj2hqDFm68t5HVL0ISgqtIAkvDaLA6I3khIBywAjll7s-bXI2KCzPwibmBRrtDBIrluANEthoptBmYHJ0ZMTT5hIcfFbQqRQ9-eHSYgQ2X0eyRo6_ASsPm7nCd77JU9RSv3ODXFv1qNvaSi1oq7aoytuM6xFLiz2QNpYTZ6GmPDDSQRy8kjlwhDh3YoMw1ewvNosRCw-DjqOPmPN2dWkAQxw29Kh-rKTPJddRRxEsJyoGGV6nJycU3bGyic_r5svZvkI0gCfSJkeQN5JA24NV_8Vd5SElBVmIuZlwysNGD0ofdR9KgNi4hoSNyVhnsGXPPF9OE0ZRXGEI6tkL8e4LilEZuTaLxJBtqyf4FItSU6wOdmQjfTjjhY7wQefr-FktvYU1DCIPoUxJa-f7TX1eGxafl1Cl3oJBONhEJquo55NEnACkaSRInYfEOfgvj1P-sxM_H2-gn6WRIbz5hAohDWhXNJ5NkbZApfy0sEY9MBfbA1O2Ff3MlVu3BpDcEYMpJ5kdf_M5w7fZEffcHJ9fHIldjEPIELXL2n8TpPFEJpX8l7u_LGl4NMLU7bi5n1mIv5oLiQdiQdMPc8G-jYUemMYznDMrgT_POgpLkfjlviefzptQR-_mA5ipnlGOk-cjq-1XICm1xT2gy4tUr5-GAXUUMwvsP4TanBP13hTb6RW6jXodvo55k5E2CcqM__xuRAn_MFVDPxSRwWEJjYPs5543JqYA_6iq5jYkKwRUQsnV3YoZwcTkz38zEzv0Gi41kmJBUhhsOTpuftLHu2QHxy7mSB9EHsehFkpj31x-SRpDuhMluYHc69ds3875SccidCVzZVGDbJx-uj2e0s18fVWleelU_byVCMoEoByk-qFJ1K3IyG247k1usqGA_TswwnIVrMBRqluVH7S9-3g1iO68dbiDzkdC6q4Nl-sRQvZuCvHNZXHQhjyFRSo1neFQiwYB36dHHHsb26kBN__S0tZ2I_ucYWMCYFe3wOoZC3wLfC08NlaUrqI1hgnkJkiwKYHjAZIMRqH6owMoUX5WXhY1Q8-6XtAwJvDa154io_4DImsXfFfLiDEqLvegN2E";

                ////
                //// Construya el post
                string reqString = "";
                reqString += "{";
                reqString += "\"metaData\":{";
                reqString += "\"namespace\":\"cl.sii.sdi.lob.diii.consdcv.data.api.interfaces.FacadeService/getResumen\",";
                reqString += "\"conversationId\":\"" + conversationId + "\",";
                reqString += "\"transactionId\":\"" + transactionId + "\",";
                reqString += "\"page\":null";
                reqString += "},";
                reqString += "\"data\":{";
                reqString += "\"accionRecaptcha\":\"" + accionRecaptcha + "\",";
                reqString += "\"tokenRecaptcha\":\"" + tokenRecaptcha + "\",";
                reqString += "\"rutEmisor\":\"" + rutEmisor + "\",";
                reqString += "\"dvEmisor\":\"" + dvEmisor + "\",";
                reqString += "\"ptributario\":\"" + ptributario + "\",";
                reqString += "\"estadoContab\":\"" + tpoResumen + "\",";
                reqString += "\"operacion\":\"COMPRA\"";
                reqString += "}";
                reqString += "}";

                ////
                //// Escriba los parametros en el request antes de consultar en el SII
                webRequest.ContentLength = reqString.Length;
                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(requestData, 0, requestData.Length);
                }

                ////
                //// Recupere la respuesta
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                ////
                //// Si no hay respuesta del servidor
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("El SII no ha contestado nuestra solicitud.");

                ////
                //// Recupere la respuesta del SII
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    ////
                    //// Recupere la respuesta
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    ////
                    //// Escriba el resultado en disco
                    data = readStream.ReadToEnd();

                    ////
                    //// Cierre objetos
                    response.Close();
                    readStream.Close();

                }

                ////
                //// Recupere la información relevante del proceso
                string _resultado = Regex.Match(data, "\"data\":\\[.*?\\]", RegexOptions.Singleline).Value;
                _resultado = Regex.Replace(_resultado, "\"data\"", "\"ResumenCompras\"", RegexOptions.Singleline);
                _resultado = "{" + _resultado + "}";

                _resultado = JsonHelper.FormatJson(_resultado);

                ////
                //// cree respuesta 
                resp.EsCorrecto = true;
                resp.Mensaje = "Recuperar Resumen de compras";
                resp.Detalle = "Archivo generado correctamente";
                resp.Resultado = _resultado;

            }
            catch (Exception ex)
            {

                ////
                //// Notifique al usario del error
                resp.EsCorrecto = false;
                resp.Mensaje = "Recuperar Resumen de compras";
                resp.Detalle = ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Funcnion general pararecuperacion de datos de compras
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="RutEmpresa"></param>
        /// <param name="Periodo"></param>
        /// <param name="TipoDte"></param>
        /// <returns></returns>
        internal static HefRespuesta RecuperarComprasGeneral(string EstadoContable, string cookie, string RutEmpresa, string Periodo, string TipoDte)
        {
            ////
            //// Inicie la respuesta
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;

            ////
            //// Variables
            string data = string.Empty;

            ////
            //// Identifique la url donde recuperar la información
            string uriSIITarget = "https://www4.sii.cl/consdcvinternetui/services/data/facadeService/getDetalleCompraExport";
            string uriReference = "https://www4.sii.cl/consdcvinternetui/";

            ////
            //// Inicie el procesamiento
            try
            {

                ////
                //// Crear conección a la página con la informacion
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uriSIITarget);
                webRequest.Method = "POST";
                webRequest.Accept = "application/json, text/plain, */*";
                webRequest.ContentType = "application/json";
                webRequest.Referer = uriReference;
                webRequest.Headers.Add("Accept-Language", "es-ES");
                webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                webRequest.Host = "www4.sii.cl";
                webRequest.Headers.Add("DNT", "1");
                webRequest.Headers.Add("Cache-Control", "no-cache");
                webRequest.Headers.Add("Cookie", cookie);

                ////
                //// Cree el POST
                List<string> arr = cookie.Split(';').ToList<string>();
                string conversationId = arr.Where(i => i.Contains("TOKEN")).FirstOrDefault().Split('=')[1];
                Guid originalGuid = Guid.NewGuid();
                string transactionId = originalGuid.ToString("D");
                string rutEmisor = RutEmpresa.Split('-')[0];
                string dvEmisor = RutEmpresa.Split('-')[1];
                string ptributario = Periodo.Replace("-", "");
                string accionRecaptcha = "RCV_DDETC";
                string tokenRecaptcha = "03AFcWeA5o4PmQ_J4qg9E6MgRSgL1CkuQYA6moaBhJrgRcxLIG69jNLA4KWofHfrcFQhzbKPHPMm8Mf2DnJ9gD2WgKvWFSXP-RnTzvJEpH3Kj_uB4vMshwHotpPCTgm_JBCqnn_5Qz6XmMAmalFtvjC-DSANJ-iQ8O5nXiq2xFH0fDFzkqUqedrbce-tRvLmhC_1ia0FO4wz4W2qsz2I9ffiC8HhcyUN-yVWUzGfcSKOC25RRCD5Tlhg7mpWAAjtawUwaid4kbsPUsnwCGwvPH6xfSYfdmVpduojPoolje0xQjSbf2MSK3H7ooj0xs0gDTeesW7kjN_g6WoL0cZp5xgSxdUK6AHykDwQ9u1az_RjVDYT-GLftgOc_NQEvsgHca8mbz5m1rQaAkuTnVrKQPviYmr-Z4TmwP3qTNTNhyhgySpaQsOtsGkLVTq7XV5CYtDivD8VnEUX4ImvnUxZS7Tqj6B5Ekalr36fdjW2qB7zRwhoopaDivQ0xYY2QbvhoKhjfn5A67PlXdt852sgAMGUBcfCgxhZpGjFwRj9I0pQfJ2kM_3CEV9rb2Iha4JOGjttmH-Teq9rL45NbdzDH2E0b026aMoAav0ZTA2eYwYNBSA_ixXUxwpjb6AXRcU-LvctQye2uhwBzZTDKp8DqtFnRzK-_OnwNhYz5e8MSoUhnWZFh5nRRLRfdPRan7krwB29rT1vEKcfhxj5oigfk02sensBtDccZrSd6QuDWZVHjAQ3rCqs3BCc3BY8T9s4txlrCKbjbLrw8GjOBOy8RARiw7iGDSJGkvtQVLIclkg-H2dMisawL0qyXzQ5rLKsWfVsIpKyFZGZUDsj2hqDFm68t5HVL0ISgqtIAkvDaLA6I3khIBywAjll7s-bXI2KCzPwibmBRrtDBIrluANEthoptBmYHJ0ZMTT5hIcfFbQqRQ9-eHSYgQ2X0eyRo6_ASsPm7nCd77JU9RSv3ODXFv1qNvaSi1oq7aoytuM6xFLiz2QNpYTZ6GmPDDSQRy8kjlwhDh3YoMw1ewvNosRCw-DjqOPmPN2dWkAQxw29Kh-rKTPJddRRxEsJyoGGV6nJycU3bGyic_r5svZvkI0gCfSJkeQN5JA24NV_8Vd5SElBVmIuZlwysNGD0ofdR9KgNi4hoSNyVhnsGXPPF9OE0ZRXGEI6tkL8e4LilEZuTaLxJBtqyf4FItSU6wOdmQjfTjjhY7wQefr-FktvYU1DCIPoUxJa-f7TX1eGxafl1Cl3oJBONhEJquo55NEnACkaSRInYfEOfgvj1P-sxM_H2-gn6WRIbz5hAohDWhXNJ5NkbZApfy0sEY9MBfbA1O2Ff3MlVu3BpDcEYMpJ5kdf_M5w7fZEffcHJ9fHIldjEPIELXL2n8TpPFEJpX8l7u_LGl4NMLU7bi5n1mIv5oLiQdiQdMPc8G-jYUemMYznDMrgT_POgpLkfjlviefzptQR-_mA5ipnlGOk-cjq-1XICm1xT2gy4tUr5-GAXUUMwvsP4TanBP13hTb6RW6jXodvo55k5E2CcqM__xuRAn_MFVDPxSRwWEJjYPs5543JqYA_6iq5jYkKwRUQsnV3YoZwcTkz38zEzv0Gi41kmJBUhhsOTpuftLHu2QHxy7mSB9EHsehFkpj31x-SRpDuhMluYHc69ds3875SccidCVzZVGDbJx-uj2e0s18fVWleelU_byVCMoEoByk-qFJ1K3IyG247k1usqGA_TswwnIVrMBRqluVH7S9-3g1iO68dbiDzkdC6q4Nl-sRQvZuCvHNZXHQhjyFRSo1neFQiwYB36dHHHsb26kBN__S0tZ2I_ucYWMCYFe3wOoZC3wLfC08NlaUrqI1hgnkJkiwKYHjAZIMRqH6owMoUX5WXhY1Q8-6XtAwJvDa154io_4DImsXfFfLiDEqLvegN2E";
                string reqString = "";
                reqString += "{";
                reqString += "\"metaData\":{  ";
                reqString += "\"namespace\":\"cl.sii.sdi.lob.diii.consdcv.data.api.interfaces.FacadeService/getDetalleCompraExport\",";
                reqString += "\"conversationId\":\"" + conversationId + "\",";
                reqString += "\"transactionId\":\"" + transactionId + "\",";
                reqString += "\"page\":null";
                reqString += "},";
                reqString += "\"data\":{  ";
                reqString += "\"accionRecaptcha\":\"" + accionRecaptcha + "\",";
                reqString += "\"tokenRecaptcha\":\"" + tokenRecaptcha + "\",";
                reqString += "\"rutEmisor\":\"" + rutEmisor + "\",";
                reqString += "\"dvEmisor\":\"" + dvEmisor + "\",";
                reqString += "\"ptributario\":\"" + ptributario + "\",";
                reqString += "\"codTipoDoc\":\"" + TipoDte + "\",";
                reqString += "\"operacion\":\"COMPRA\",";
                reqString += "\"estadoContab\":\"" + EstadoContable + "\"";
                reqString += "}";
                reqString += "}";

                ////
                //// Escriba los parametros en el request antes de consultar en el SII
                webRequest.ContentLength = reqString.Length;
                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(requestData, 0, requestData.Length);
                }

                ////
                //// Recupere la respuesta
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                ////
                //// Si no hay respuesta del servidor
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("El SII no ha contestado nuestra solicitud.");

                ////
                //// Recupere la respuesta del SII
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    ////
                    //// Recupere la respuesta
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    ////
                    //// Escriba el resultado en disco
                    data = readStream.ReadToEnd();

                    ////
                    //// Cierre objetos
                    response.Close();
                    readStream.Close();

                }

                ////
                //// cree respuesta 
                resp.EsCorrecto = true;
                resp.Mensaje = "Recuperar Facturas Compras SII";
                resp.Detalle = "Archivo generador correctamente";
                resp.Resultado = data;

            }
            catch (Exception ex)
            {

                ////
                //// Notifique al usario del error
                resp.EsCorrecto = false;
                resp.Mensaje = "Recuperar Facturas Compras SII";
                resp.Detalle = ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;




        }

        /// <summary>
        /// Inicia la recuperación de las facturas de compras desde el
        /// Sitio WEB
        /// </summary>
        internal static HefRespuesta RecuperarResumenVentas(string cookie, string RutEmpresa, string Periodo)
        {
            ////
            //// Inicie la respuesta
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;

            ////
            //// Variables
            string data = string.Empty;

            ////
            //// Identifique la url donde recuperar la información
            string uriSIITarget = "https://www4.sii.cl/consdcvinternetui/services/data/facadeService/getResumen";
            string uriReference = "https://www4.sii.cl/consdcvinternetui/";

            ////
            //// Inicie el procesamiento
            try
            {

                ////
                //// Crear conección a la página con la informacion
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uriSIITarget);
                webRequest.Method = "POST";
                webRequest.Accept = "application/json, text/plain, */*";
                webRequest.ContentType = "application/json";
                webRequest.Referer = uriReference;
                webRequest.Headers.Add("Accept-Language", "es-ES");
                webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                webRequest.Host = "www4.sii.cl";
                webRequest.Headers.Add("DNT", "1");
                webRequest.Headers.Add("Cache-Control", "no-cache");
                webRequest.Headers.Add("Cookie", cookie);

                ////
                //// Construya los datos del post
                List<string> arr = cookie.Split(';').ToList<string>();
                string conversationId = arr.Where(i => i.Contains("TOKEN")).FirstOrDefault().Split('=')[1];
                Guid originalGuid = Guid.NewGuid();
                string transactionId = originalGuid.ToString("D");
                string rutEmisor = RutEmpresa.Split('-')[0];
                string dvEmisor = RutEmpresa.Split('-')[1].ToUpper();
                string ptributario = Periodo.Replace("-", "");

                ////
                //// Construya el post
                string reqString = "";
                reqString += "{";
                reqString += "\"metaData\":{";
                reqString += "\"namespace\":\"cl.sii.sdi.lob.diii.consdcv.data.api.interfaces.FacadeService/getResumen\",";
                reqString += "\"conversationId\":\"" + conversationId + "\",";
                reqString += "\"transactionId\":\"" + transactionId + "\",";
                reqString += "\"page\":null";
                reqString += "},";
                reqString += "\"data\":{";
                reqString += "\"rutEmisor\":\"" + rutEmisor + "\",";
                reqString += "\"dvEmisor\":\"" + dvEmisor + "\",";
                reqString += "\"ptributario\":\"" + ptributario + "\",";
                reqString += "\"estadoContab\":\"REGISTRO\",";
                reqString += "\"operacion\":\"VENTA\"";
                reqString += "}";
                reqString += "}";

                ////
                //// Escriba los parametros en el request antes de consultar en el SII
                webRequest.ContentLength = reqString.Length;
                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(requestData, 0, requestData.Length);
                }

                ////
                //// Recupere la respuesta
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                ////
                //// Si no hay respuesta del servidor
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("El SII no ha contestado nuestra solicitud.");

                ////
                //// Recupere la respuesta del SII
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    ////
                    //// Recupere la respuesta
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    ////
                    //// Escriba el resultado en disco
                    data = readStream.ReadToEnd();

                    ////
                    //// Cierre objetos
                    response.Close();
                    readStream.Close();

                }

                ////
                //// Recupere la información relevante del proceso
                string _resultado = Regex.Match(data, "\"data\":\\[.*?\\]", RegexOptions.Singleline).Value;
                _resultado = Regex.Replace(_resultado, "\"data\"", "\"ResumenVentas\"", RegexOptions.Singleline);
                _resultado = "{" + _resultado + "}";

                _resultado = JsonHelper.FormatJson(_resultado);

                ////
                //// cree respuesta 
                resp.EsCorrecto = true;
                resp.Mensaje = "Recuperar Resumen de ventas";
                resp.Detalle = "Archivo generado correctamente";
                resp.Resultado = _resultado;

            }
            catch (Exception ex)
            {

                ////
                //// Notifique al usario del error
                resp.EsCorrecto = false;
                resp.Mensaje = "Recuperar Resumen de ventas";
                resp.Detalle = ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;


        }

        /// <summary>
        /// Inicia la recuperación de las facturas de compras desde el
        /// Sitio WEB ( Avanzado )
        /// </summary>
        internal static HefRespuesta RecuperarVentasRegistro(string cookie, string RutEmpresa, string Periodo, string TipoDte)
        {
            ////
            //// Inicie la respuesta
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;

            ////
            //// Variables
            string data = string.Empty;

            ////
            //// Identifique la url donde recuperar la información
            string uriSIITarget = "https://www4.sii.cl/consdcvinternetui/services/data/facadeService/getDetalleVentaExport";
            string uriReference = "https://www4.sii.cl/consdcvinternetui/";

            ////
            //// Inicie el procesamiento
            try
            {

                ////
                //// Crear conección a la página con la informacion
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uriSIITarget);
                webRequest.Method = "POST";
                webRequest.Accept = "application/json, text/plain, */*";
                webRequest.ContentType = "application/json";
                webRequest.Referer = uriReference;
                webRequest.Headers.Add("Accept-Language", "es-ES");
                webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                webRequest.Host = "www4.sii.cl";
                webRequest.Headers.Add("DNT", "1");
                webRequest.Headers.Add("Cache-Control", "no-cache");
                webRequest.Headers.Add("Cookie", cookie);

                ////
                //// Cree el POST
                List<string> arr = cookie.Split(';').ToList<string>();
                string conversationId = arr.Where(i => i.Contains("TOKEN")).FirstOrDefault().Split('=')[1];
                Guid originalGuid = Guid.NewGuid();
                string transactionId = originalGuid.ToString("D");
                string rutEmisor = RutEmpresa.Split('-')[0];
                string dvEmisor = RutEmpresa.Split('-')[1];
                string ptributario = Periodo.Replace("-", "");
                string reqString = "";
                string accionRecaptcha = "RCV_DDETV";
                string tokenRecaptcha = "03AFcWeA5o4PmQ_J4qg9E6MgRSgL1CkuQYA6moaBhJrgRcxLIG69jNLA4KWofHfrcFQhzbKPHPMm8Mf2DnJ9gD2WgKvWFSXP-RnTzvJEpH3Kj_uB4vMshwHotpPCTgm_JBCqnn_5Qz6XmMAmalFtvjC-DSANJ-iQ8O5nXiq2xFH0fDFzkqUqedrbce-tRvLmhC_1ia0FO4wz4W2qsz2I9ffiC8HhcyUN-yVWUzGfcSKOC25RRCD5Tlhg7mpWAAjtawUwaid4kbsPUsnwCGwvPH6xfSYfdmVpduojPoolje0xQjSbf2MSK3H7ooj0xs0gDTeesW7kjN_g6WoL0cZp5xgSxdUK6AHykDwQ9u1az_RjVDYT-GLftgOc_NQEvsgHca8mbz5m1rQaAkuTnVrKQPviYmr-Z4TmwP3qTNTNhyhgySpaQsOtsGkLVTq7XV5CYtDivD8VnEUX4ImvnUxZS7Tqj6B5Ekalr36fdjW2qB7zRwhoopaDivQ0xYY2QbvhoKhjfn5A67PlXdt852sgAMGUBcfCgxhZpGjFwRj9I0pQfJ2kM_3CEV9rb2Iha4JOGjttmH-Teq9rL45NbdzDH2E0b026aMoAav0ZTA2eYwYNBSA_ixXUxwpjb6AXRcU-LvctQye2uhwBzZTDKp8DqtFnRzK-_OnwNhYz5e8MSoUhnWZFh5nRRLRfdPRan7krwB29rT1vEKcfhxj5oigfk02sensBtDccZrSd6QuDWZVHjAQ3rCqs3BCc3BY8T9s4txlrCKbjbLrw8GjOBOy8RARiw7iGDSJGkvtQVLIclkg-H2dMisawL0qyXzQ5rLKsWfVsIpKyFZGZUDsj2hqDFm68t5HVL0ISgqtIAkvDaLA6I3khIBywAjll7s-bXI2KCzPwibmBRrtDBIrluANEthoptBmYHJ0ZMTT5hIcfFbQqRQ9-eHSYgQ2X0eyRo6_ASsPm7nCd77JU9RSv3ODXFv1qNvaSi1oq7aoytuM6xFLiz2QNpYTZ6GmPDDSQRy8kjlwhDh3YoMw1ewvNosRCw-DjqOPmPN2dWkAQxw29Kh-rKTPJddRRxEsJyoGGV6nJycU3bGyic_r5svZvkI0gCfSJkeQN5JA24NV_8Vd5SElBVmIuZlwysNGD0ofdR9KgNi4hoSNyVhnsGXPPF9OE0ZRXGEI6tkL8e4LilEZuTaLxJBtqyf4FItSU6wOdmQjfTjjhY7wQefr-FktvYU1DCIPoUxJa-f7TX1eGxafl1Cl3oJBONhEJquo55NEnACkaSRInYfEOfgvj1P-sxM_H2-gn6WRIbz5hAohDWhXNJ5NkbZApfy0sEY9MBfbA1O2Ff3MlVu3BpDcEYMpJ5kdf_M5w7fZEffcHJ9fHIldjEPIELXL2n8TpPFEJpX8l7u_LGl4NMLU7bi5n1mIv5oLiQdiQdMPc8G-jYUemMYznDMrgT_POgpLkfjlviefzptQR-_mA5ipnlGOk-cjq-1XICm1xT2gy4tUr5-GAXUUMwvsP4TanBP13hTb6RW6jXodvo55k5E2CcqM__xuRAn_MFVDPxSRwWEJjYPs5543JqYA_6iq5jYkKwRUQsnV3YoZwcTkz38zEzv0Gi41kmJBUhhsOTpuftLHu2QHxy7mSB9EHsehFkpj31x-SRpDuhMluYHc69ds3875SccidCVzZVGDbJx-uj2e0s18fVWleelU_byVCMoEoByk-qFJ1K3IyG247k1usqGA_TswwnIVrMBRqluVH7S9-3g1iO68dbiDzkdC6q4Nl-sRQvZuCvHNZXHQhjyFRSo1neFQiwYB36dHHHsb26kBN__S0tZ2I_ucYWMCYFe3wOoZC3wLfC08NlaUrqI1hgnkJkiwKYHjAZIMRqH6owMoUX5WXhY1Q8-6XtAwJvDa154io_4DImsXfFfLiDEqLvegN2E";

                //if (TipoDte == "33" || TipoDte == "56" || TipoDte == "61")
                //{
                //    accionRecaptcha = "RCV_DDETV";
                //}
                //else
                //{
                //    accionRecaptcha = "RCV_DDETC";
                //}


                reqString += "{";
                reqString += "\"metaData\":{  ";
                reqString += "\"namespace\":\"cl.sii.sdi.lob.diii.consdcv.data.api.interfaces.FacadeService/getDetalleVentaExport\",";
                reqString += "\"conversationId\":\"" + conversationId + "\",";
                reqString += "\"transactionId\":\"" + transactionId + "\",";
                reqString += "\"page\":null";
                reqString += "},";
                reqString += "\"data\":{  ";
                reqString += "\"accionRecaptcha\":\"" + accionRecaptcha + "\",";
                reqString += "\"tokenRecaptcha\":\"" + tokenRecaptcha + "\",";
                reqString += "\"rutEmisor\":\"" + rutEmisor + "\",";
                reqString += "\"dvEmisor\":\"" + dvEmisor + "\",";
                reqString += "\"ptributario\":\"" + ptributario + "\",";
                reqString += "\"codTipoDoc\":\"" + TipoDte + "\",";
                reqString += "\"operacion\":\"VENTA\",";
                reqString += "\"estadoContab\":\"REGISTRO\"";
                reqString += "}";
                reqString += "}";

                ////
                //// Escriba los parametros en el request antes de consultar en el SII
                webRequest.ContentLength = reqString.Length;
                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(requestData, 0, requestData.Length);
                }

                ////
                //// Recupere la respuesta
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                ////
                //// Si no hay respuesta del servidor
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("El SII no ha contestado nuestra solicitud.");

                ////
                //// Recupere la respuesta del SII
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    ////
                    //// Recupere la respuesta
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    ////
                    //// Escriba el resultado en disco
                    data = readStream.ReadToEnd();

                    ////
                    //// Cierre objetos
                    response.Close();
                    readStream.Close();

                }

                ////
                //// Ealuar la respuesta
                //resp = Negocio.Funciones.AnalizarRespuesta(data);
                //if (!resp.EsCorrecto)
                //    return resp;

                ////
                //// cree respuesta 
                resp.EsCorrecto = true;
                resp.Mensaje = "Recuperar Facturas Ventas SII";
                resp.Detalle = "Archivo generador correctamente";
                resp.Resultado = data;

            }
            catch (Exception ex)
            {

                ////
                //// Notifique al usario del error
                resp.EsCorrecto = false;
                resp.Mensaje = "Recuperar Facturas Ventas SII";
                resp.Detalle = ex.Message;
                resp.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

    }

}
