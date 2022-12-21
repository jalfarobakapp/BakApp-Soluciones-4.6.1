using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace HEFESTO.CONSULTA.TRACKID.Negocio
{

    public class Certificados
    {
        public static List<string> RecuperarCNs()
        {

            ////
            //// Abra el repositorio de certificados para buscar el indicado
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection Certificados1 = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection Certificados2 = Certificados1.Find(X509FindType.FindByTimeValid, DateTime.Now, false);

            List<string> CNS = new List<string>();
            CNS.Add("< SELECCIONE UN CERTIFICADO >");

            foreach (X509Certificate2 certificado in Certificados2)
            {
                string CN = certificado.SubjectName.Name;

                string substring = CN.Substring(CN.IndexOf("CN"));
                string[] array = substring.Split(',');
                array[0] = array[0].Replace("CN=", string.Empty).Trim();
                CNS.Add(array[0]);

            }

            return CNS;

        }

        public static X509Certificate2 RecuperarCertificado(string CN)
        {


            ////
            //// Respuesta
            X509Certificate2 certificado = null;

            ////
            //// Certificado que se esta buscando
            if (string.IsNullOrEmpty(CN) || CN.Length == 0)
                return null;

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

            return certificado;

        }

    }

}
