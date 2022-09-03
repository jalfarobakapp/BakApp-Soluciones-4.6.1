using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace HefRcof.Negocio
{
    /// <summary>
    /// Metodos relacionados con schemas 
    /// </summary>
    internal class Schemas
    {

        /// <summary>
        /// Valida el documento xml contra su schema
        /// </summary>
        public static List<string> ValidarSchema(string uriDte, string uriSchema)
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
                schemas.Add(NS, uriSchema);

                ////
                //// Recupere el documento xml (DTE) a validar
                XDocument DocumentoXml = XDocument.Load(uriDte);

                ////
                //// Inicie la validacion del documento xml contra su schema
                DocumentoXml.Validate(schemas, (o, e) => { errores.Add(e.Message + "  " + e.Exception.LinePosition.ToString()); });

            }
            catch (Exception)
            {
                //errores.Add("Error al intentar validar schema contra documento xml");
            }


            ////
            //// Regrese el valor de retorno 
            return errores;


        }



    }
}
