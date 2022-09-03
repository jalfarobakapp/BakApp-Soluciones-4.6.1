using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace HEFESTO.FIRMA.DOCUMENTO
{
    public class Negocio
    {

        /// <summary>
        /// Recupera el nombre del sujeto del certificado
        /// </summary>
        /// <param name="certificado">x509Certificate2</param>
        /// <returns>Regresa el nombre del dueño del certificado</returns>
        public static string RecuperarNombre(X509Certificate2 certificado)
        {

            ////
            //// Valor a regresar
            string Nombre = string.Empty;

            ////
            //// Recupere el nombre del dueño del certificado
            try
            {
                string cadena = certificado.SubjectName.Name;
                if (!string.IsNullOrEmpty(cadena))
                {
                    string[] elementos = cadena.Split(',');
                    if (elementos != null && elementos.Length > 0)
                    {

                        foreach (string cn in elementos)
                        {
                            if (cn.Contains("CN"))
                            {
                                Nombre = cn.Replace("CN=", string.Empty).Trim();

                            }

                        }



                    }

                }

            }
            catch (Exception)
            {
                Nombre = null;
            }


            ////
            //// Regrese el valor de retorno
            return Nombre;

        }

        /// <summary>
        /// Recupera todos los nombres de los certificados
        /// </summary>
        /// <returns></returns>
        public static List<string> ListaDeCertificados()
        {

            ////
            //// Inicie el resultado
            List<string> Resultado = new List<string>();
            Resultado.Add("< Seleccione un certificado >");

            try
            {
                ////
                //// Abra el repositorio de certificados para buscar el indicado
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection Certificados1 = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection Certificados2 = Certificados1.Find(X509FindType.FindByTimeValid, DateTime.Now, false);

                ////
                //// Recupere los nombres canonicos de los certificados
                foreach (X509Certificate2 cert in Certificados2)
                {
                    string cn = RecuperarNombre(cert);
                    if (cn != null)
                        Resultado.Add(cn);
                }

            }
            catch (Exception)
            {

                Resultado = null;
            }

            ////
            //// Regrese el valor de resultado
            return Resultado.OrderBy(P => P).ToList();

        }

        /// <summary>
        /// Quita la identacion al documento xml
        /// </summary>
        public static void QuitarIdentacionXml(string uri)
        {

            ////
            //// Abra el documento xml
            XDocument DTE = XDocument.Load(uri, LoadOptions.PreserveWhitespace);

            ////
            //// Quite la identacion del documento
            string[] strLineasDte = DTE.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i <= strLineasDte.Length - 1; i++)
                strLineasDte[i] = strLineasDte[i].TrimStart();

            ////
            //// Recargue el documento xml sin identación
            //// utilizando el objeto xmlDocument
            string p = string.Join("\r\n", strLineasDte);
            DTE = XDocument.Parse(p, LoadOptions.PreserveWhitespace);
            DTE.Declaration = new XDeclaration("1.0", "ISO-8859-1", null);

            ////
            //// Guarde el documento sin identación
            DTE.Save(uri);

        
        }

    }
}
