using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hefesto.Acuse.Recibo.Factura.Negocio
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


        /// <summary>
        /// Recupere el certificado utilizando certificado fisico
        /// </summary>
        /// <param name="fullpath">Fullpath del certificado</param>
        /// <param name="password">password del certificado</param>
        /// <returns></returns>
        internal static Respuesta RecuperarCertificado(string fullpath, string password)
        {
            ////
            //// inicie la respuesta
            Respuesta resp = new Respuesta();
            resp.Mensaje = "Recuperación de certificado";


            ////
            //// inicie
            try
            {

                ////
                //// Validación de los parametros
                if (!File.Exists(fullpath))
                    throw new Exception("No existe el archivo o no se tiene acceso a el.");
                if ( Path.GetExtension(fullpath).ToUpper() != ".PFX" )
                    throw new Exception("El archivo no es un certificado Pfx");
                if ( string.IsNullOrEmpty(password) )
                    throw new Exception("La clave del certificado no puede ser null 0 vacío.");

                ////
                //// recuperar el certificado
                X509Certificate2 certificado = new X509Certificate2(fullpath, password, X509KeyStorageFlags.UserKeySet);
                if (certificado == null)
                    throw new Exception("No fue posible reconstruir el certificado, verifique su password");

                ////
                //// El certificado tiene pk?
                if (!certificado.HasPrivateKey)
                    throw new Exception("El certificado no tiene private key.");

                ////
                //// verifique que el certificado no este expirado.
                DateTime dt;
                if (DateTime.TryParse(certificado.GetExpirationDateString(), out dt))
                {
                    ////
                    //// la fecha de expiración del certificado es valida?
                    if (DateTime.Now > dt)
                        throw new Exception("El certificado actual esta expirado.");
                }

                ////
                //// Regrese el certificado
                resp.EsCorrecto = true;
                resp.Detalle = "recuperación de certificado es OK";
                resp.Resultado = certificado;

            }
            catch (Exception ex)
            {
                ////
                //// notifique el error
                resp.EsCorrecto = false;
                resp.Detalle = ex.Message;
                resp.Resultado = null;
            }

            ////
            //// regrese el certifiado
            return resp;

        }

    }
}
