using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HefRcof.Negocio
{
    /// <summary>
    /// Metodos para serializar objeto a xml
    /// </summary>
    internal class Serializar
    {

        /// <summary>
        /// Recupera el documento xml serializado
        /// </summary>
        /// <returns></returns>
        internal static string RecuperarXml(HefConsumoFolios cf)
        {

            var serializer = new XmlSerializer(typeof(HefConsumoFolios));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var sw = new StringWriter();
            var xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings() { OmitXmlDeclaration = true });

            serializer.Serialize(xmlWriter, cf, ns);
            string xml = sw.ToString();

            xml = Negocio.PrettyXml.PrintXML(xml);


            return xml;

        }



    }
}
