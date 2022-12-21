using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HefestoCesionV12.Negocio
{
    /// <summary>
    /// Metodos relacionados con certificados 
    /// </summary>
    internal class HefCertificados
    {
        /// <summary>
        /// Recupera un determinado certificado para poder firmar un documento
        /// </summary>
        /// <param name="CN">Nombre del certificado que se busca</param>
        /// <returns>X509Certificate2</returns>
        internal static X509Certificate2 obtenerCertificado(string CN)
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


    }
}
