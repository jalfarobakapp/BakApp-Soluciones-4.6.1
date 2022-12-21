using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HefestoCesionV12.Negocio
{
    /// <summary>
    /// Metodos de seriaizacion de objetos
    /// </summary>
    internal  class HefSerializacion
    {
        /// <summary>
        /// Permite recuperar el documento xml 
        /// </summary>
        /// <returns></returns>
        internal static string RecuperarDocumentoXml(object objeto)
        {
            ////
            //// Resultado final
            string doc = string.Empty;

            ////
            //// Cree el objeto a serializar
            XmlSerializer xmlSerializer = new XmlSerializer(objeto.GetType());

            ////
            //// Inicie la serializacion del objeto
            using (MemoryStream memStream = new MemoryStream())
            {
                using (StreamWriter stWriter = new StreamWriter(memStream))
                {

                    ////
                    //// Iniciar el xml namespace 
                    System.Xml.Serialization.XmlSerializerNamespaces xs = new XmlSerializerNamespaces();
                    xs.Add("", "");

                    ////
                    //// Serializar
                    xmlSerializer.Serialize(stWriter, objeto, xs);

                    ////
                    //// Normalizar el documento
                    byte[] buffer = memStream.GetBuffer();
                    doc = Encoding.GetEncoding("utf-8").GetString(
                        buffer.TakeWhile((v, index) => buffer.Skip(index).Any(w => w != 0x00)).ToArray()
                            );

                    memStream.Close();

                }

            }

            ////
            //// Ordene el documento
            doc = XDocument.Parse(doc).ToString();

            ////
            //// Agregar instruccion de procesamiento
            doc = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" + doc;

            ////
            //// regrese el valor de retorno
            return doc;

        }

        /// <summary>
        /// Permite crear un comentario
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <returns></returns>
        internal static XmlComment CrearComentario(string mensaje)
        {
            return new XmlDocument().CreateComment(mensaje);
        }

    }
}
