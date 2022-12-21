using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace HefestoCesionV12.Negocio
{
    /// <summary>
    /// Metodos relacionados con los schemas del SII
    /// </summary>
    internal class HefSchema
    {

        /// <summary>
        /// Inicia la validación de schema del documento DTE
        /// </summary>
        internal static bool EsValidoElSchemaDelSII(string sAec, string sSchema, out string sErrores)
        {

            ////
            //// Difina la constante namespace SII
            const string NS = "http://www.sii.cl/SiiDte";

            ////
            //// Defina la lista de errores a rtegresar
            List<string> errores = new List<string>();


            ////
            //// Inicie la validacion de los schemas
            try
            {
                ////
                //// Cree el administrador del schema
                XmlSchemaSet schemas = new XmlSchemaSet();

                ////
                //// Asigne el schema al administrador
                schemas.Add(NS, sSchema);

                ////
                //// Recupere el documento xml (DTE) a validar
                XDocument DocumentoXml = XDocument.Parse(sAec);

                ////
                //// Inicie la validacion del documento xml contra su schema
                DocumentoXml.Validate(schemas, (o, e) => { errores.Add(e.Message); });

            }
            catch (Exception ex)
            {
                errores.Add(ex.Message);
            }

            ////
            //// Cree la llista de errores
            sErrores = string.Join("\r\n", errores);

            ////
            //// Regrese el valor de retorno 
            return errores.Count == 0;

        }

    }
}
