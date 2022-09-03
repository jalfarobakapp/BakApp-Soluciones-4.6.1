using HEFESTO.DTE.SERIALIZATION.CLASSES;
using HEFESTO.DTE.SERIALIZATION.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Xml;

namespace HEFESTO.DTE.SERIALIZA.CLIENTE
{
    /// <summary>
    /// Generacion de facturas 
    /// </summary>
    public class GeneracionFacturasElec
    {

        /// <summary>
        /// Ejeplo de documento dte con tag extrajero
        /// </summary>
        public static void FacturaActualizada2019()
        {

            ////
            //// Cree una nueva instancia del documento hefdte
            HEFDTE hdte = new HEFDTE();
            hdte.calcularMontosDocumentoDTE = false;
            hdte.Documento.Encabezado.Totales.TasaIVA = 19;

            ////
            //// Cree el encabezado del proyecto
            //// Utilizando los elementos basicos minimos
            hdte.Documento.Encabezado.IdDoc.TipoDTE = 33 ;
            hdte.Documento.Encabezado.IdDoc.Folio = 35;
            hdte.Documento.Encabezado.IdDoc.FchEmis = DateTime.Now.ToString("yyyy-MM-dd");

            ////
            //// MR:23-06-2019
            //// Agregar los campos solicitados por cliente.
            hdte.Documento.Encabezado.IdDoc.IndNoRebaja = 1;
            hdte.Documento.Encabezado.IdDoc.IndTraslado = 1;
            hdte.Documento.Encabezado.IdDoc.TpoImpresion = 1;
            hdte.Documento.Encabezado.IdDoc.MntBruto = 1;
            hdte.Documento.Encabezado.IdDoc.TpoTranCompra = 1;
            hdte.Documento.Encabezado.IdDoc.TpoTranVenta = 1;
            hdte.Documento.Encabezado.IdDoc.TpoCtaPago = "AH";
            hdte.Documento.Encabezado.IdDoc.NumCtaPago = "1234567890";
            hdte.Documento.Encabezado.IdDoc.BcoPago = "MI BANCO";
            hdte.Documento.Encabezado.IdDoc.TipoFactEsp = 123456;

            ////
            //// MR:23-06-2019
            //// Como Agregar Pagos.
            hdte.Documento.Encabezado.IdDoc.MntPagos = new List<HEFMntPagos>();

            HEFMntPagos pago_1 = new HEFMntPagos();
            pago_1.FchPago = "2019-01-01";
            pago_1.MntPago = 100000;
            pago_1.GlosaPagos = "Pago Nro 1 de 3";
            hdte.Documento.Encabezado.IdDoc.MntPagos.Add(pago_1);

            HEFMntPagos pago_2 = new HEFMntPagos();
            pago_2.FchPago = "2019-02-01";
            pago_2.MntPago = 100000;
            pago_2.GlosaPagos = "Pago Nro 2 de 3";
            hdte.Documento.Encabezado.IdDoc.MntPagos.Add(pago_2);

            HEFMntPagos pago_3 = new HEFMntPagos();
            pago_3.FchPago = "2019-03-01";
            pago_3.MntPago = 100000;
            pago_3.GlosaPagos = "Pago Nro 3 de 3";
            hdte.Documento.Encabezado.IdDoc.MntPagos.Add(pago_3);

            ////
            //// Datos del emisor
            hdte.Documento.Encabezado.Emisor.RUTEmisor = "85753400-K";
            hdte.Documento.Encabezado.Emisor.RznSoc = "COMERCIAL MAGALLANES LTDA";
            hdte.Documento.Encabezado.Emisor.GiroEmis = "PREPARACIÓN DEL TERRENO, EXCAVACIONES Y MOVIMIENTOS DE TIERRAS";
            hdte.Documento.Encabezado.Emisor.Acteco.Add(451010);
            hdte.Documento.Encabezado.Emisor.Acteco.Add(523410);
            hdte.Documento.Encabezado.Emisor.Acteco.Add(523942);
            hdte.Documento.Encabezado.Emisor.DirOrigen = "AV. FERMIN VIVACETA 879.";
            hdte.Documento.Encabezado.Emisor.CmnaOrigen = "INDEPENDENCIA";
            hdte.Documento.Encabezado.Emisor.CiudadOrigen = "SANTIAGO";

            ////
            //// Datos del Receptor
            hdte.Documento.Encabezado.Receptor.RUTRecep = "3-5";
            hdte.Documento.Encabezado.Receptor.RznSocRecep = "YXB & CIA S.A.";
            hdte.Documento.Encabezado.Receptor.GiroRecep = "SERVICIOS";
            hdte.Documento.Encabezado.Receptor.DirRecep = "TEATINOS 120";
            hdte.Documento.Encabezado.Receptor.CmnaRecep = "SANTIAGO";
            hdte.Documento.Encabezado.Receptor.CiudadRecep = "SANTIAGO";

            ////
            //// MR:23-06-2019
            //// Agregar los datos del extrajero al documento
            hdte.Documento.Encabezado.Receptor.Extrajero.NumId = "123456";
            hdte.Documento.Encabezado.Receptor.Extrajero.Nacionalidad = "CL";
            hdte.Documento.Encabezado.Receptor.Extrajero.TipoDocID = "123456";

            ////
            //// Detalle #1 
            HEFDetalle detalle1 = new HEFDetalle();
            detalle1.NroLinDet = 1;
            detalle1.CdgItem.TpoCodigo = "EAN13";
            detalle1.CdgItem.VlrCodigo = "123456789";
            detalle1.NmbItem = "Cajón AFECTO";
            detalle1.QtyItem = 5;
            detalle1.PrcItem = 15400;
            detalle1.MontoItem = 77000;
            hdte.Documento.AddDetalle = detalle1;

            ////
            //// Agregar descuentos globales
            hdte.Documento.DscRcgGlobals = new List<HEFDscRcgGlobal>();
            HEFDscRcgGlobal d = new HEFDscRcgGlobal();
            d.NroLinDR = 1;
            d.TpoMov = "D";
            d.GlosaDR = "Descuento global";
            d.TpoValor = "%";
            d.ValorDR = 5;
            hdte.Documento.DscRcgGlobals.Add(d);

            ////
            //// MR:25-10-2018
            //// Nuevo descuento global
            d = new HEFDscRcgGlobal();
            d.NroLinDR = 2;
            d.TpoMov = "D";
            d.GlosaDR = "Descuento global II";
            d.TpoValor = "%";
            d.ValorDR = 5;
            hdte.Documento.DscRcgGlobals.Add(d);

            ////
            //// Agregar una referencia del caso actual
            hdte.Documento.Referencias = new List<HEFReferencia>();
            HEFReferencia referencia = new HEFReferencia();
            referencia.NroLinRef = 1;
            referencia.TpoDocRef = "SET";
            referencia.FolioRef = 0;
            referencia.FchRef = "2015-06-24";
            referencia.RazonRef = "CASO 397743-1";
            hdte.Documento.Referencias.Add(referencia);

            ////
            //// Inicie la serializacion del documento.
            Respuesta respuesta = hdte.RecuperarDte();
            if (respuesta.Correcto)
            {

                ////
                //// Construya el nombre de salida
                string nameOut = string.Format("PRUEBAS 2019\\FacturaConTagExtrajero.xml",
                    hdte.Documento.Referencias[0].RazonRef,
                    hdte.Documento.Encabezado.IdDoc.Folio.ToString().PadLeft(3, '0')
                    );

                ////
                //// Regresa el documento xml (DTE)
                XmlDocument xmlDTE = (XmlDocument)respuesta.Resultado;
                xmlDTE.Save(nameOut);

            }

        }

    }
}
