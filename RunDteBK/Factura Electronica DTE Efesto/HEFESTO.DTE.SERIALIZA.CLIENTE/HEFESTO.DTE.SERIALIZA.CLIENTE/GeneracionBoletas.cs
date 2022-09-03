using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HEFESTO.DTE.SERIALIZATION.ENTIDADES;
using HEFESTO.DTE.SERIALIZATION.BOLETAS;
using System.Xml;

namespace HEFESTO.DTE.SERIALIZA.CLIENTE
{
    public class GeneracionBoletas
    {

        /// <summary>
        /// Ejemplo de como crear una factura de exportación utilizando 
        /// clase HEFDTEExpotaciones.
        /// </summary>
        public static void CrearBoleta()
        {

            ////
            //// Cree la instancia del objeto BOLETA
            HEF_BOLETA boleta = new HEF_BOLETA();
            boleta.AgregarNameSpace = true;
            boleta.Version = "1.0";

            ////
            //// Identificacion de la boleta
            boleta.Documento.Encabezado.IdDoc.TipoDTE = 39;
            boleta.Documento.Encabezado.IdDoc.Folio = 1;
            boleta.Documento.Encabezado.IdDoc.FchEmis = "2015-03-22";
            boleta.Documento.Encabezado.IdDoc.IndServicio = 3;

            ////
            //// Datos del emisor
            boleta.Documento.Encabezado.Emisor.RUTEmisor = "76389812-1";
            boleta.Documento.Encabezado.Emisor.RznSocEmisor = "INGENIERIA Y SISTEMAS DAPCOM LIMITADA";
            boleta.Documento.Encabezado.Emisor.GiroEmisor = "EMPRESAS DE SERVICIO INTEGRALES DE INFORMATICA";
            boleta.Documento.Encabezado.Emisor.DirOrigen = "LA PLAYA 1064";
            boleta.Documento.Encabezado.Emisor.CmnaOrigen = "SAN BERNARDO";
            boleta.Documento.Encabezado.Emisor.CiudadOrigen = "SANTIAGO";

            ////
            //// Datos del Receptor
            boleta.Documento.Encabezado.Receptor.RUTRecep = "3-5";
            boleta.Documento.Encabezado.Receptor.RznSocRecep = "YXB S.A.";
            boleta.Documento.Encabezado.Receptor.DirRecep = "BURGOS 80 PISO 2";
            boleta.Documento.Encabezado.Receptor.CmnaRecep = "LAS CONDES";
            boleta.Documento.Encabezado.Receptor.CiudadRecep = "SANTIAGO";

            ////
            //// Cree los totales
            boleta.Documento.Encabezado.Totales.MntNeto = 1000000000;
            boleta.Documento.Encabezado.Totales.MntExe = 2000000000;
            boleta.Documento.Encabezado.Totales.IVA = 9000000000;
            boleta.Documento.Encabezado.Totales.MntTotal = 99000000000;

            ///////////////////////////////////////////////////////////
            //// Cree el detalle 1 del documento
            //// Detalle #1 ( ITEM AFECTO )
            ///////////////////////////////////////////////////////////
            boleta.Documento.Detalle = new List<HEF_Documento_Detalle>();
            HEF_Documento_Detalle detalle1 = new HEF_Documento_Detalle();
            detalle1.NroLinDet = 1;
            detalle1.NmbItem = "ACEITE DE PESCADO B&W";
            detalle1.QtyItem = 100;
            detalle1.PrcItem = 1000;
            detalle1.MontoItem = 100000;
            boleta.Documento.Detalle.Add(detalle1);

            ///////////////////////////////////////////////////////////
            //// CREAR UNA REFERENCIA 
            ///////////////////////////////////////////////////////////
            boleta.Documento.Referencia = new List<HEF_Documento_Referencia>();
            HEF_Documento_Referencia Referencia = new HEF_Documento_Referencia();
            Referencia.NroLinRef = 1;
            Referencia.CodRef = "SET";
            Referencia.RazonRef = "CASO 290030-1";
            boleta.Documento.Referencia.Add(Referencia);


            ////
            //// Inicie la serializacion del documento.
            Respuesta respuesta = boleta.RecuperarDte();
            if (respuesta.Correcto)
            {

                ////
                //// Construya el nombre de salida
                string nameOut = "PRUEBAS\\DTE_BOLETA.XML";

                ////
                //// Regresa el documento xml (DTE)
                XmlDocument xmlDTE = (XmlDocument)respuesta.Resultado;
                xmlDTE.Save(nameOut);

            }
                    
        }

    }
}
