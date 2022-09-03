using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HEFESTO.DTE.SERIALIZATION.EXPORTACION;
using HEFESTO.DTE.SERIALIZATION.ENTIDADES;



namespace HEFESTO.DTE.SERIALIZA.CLIENTE
{
    
    /// <summary>
    /// Ejemplo para generacion de documento de exportacion
    /// </summary>
    class GeneracionExportacion
    {

        /// <summary>
        /// Ejemplo de como crear una factura de exportación utilizando 
        /// clase HEFDTEExpotaciones.
        /// </summary>
        public static void CrearFacturaExportacion()
        {

            ////
            //// Cree una nueva instancia del documento hefdte
            HEFDTEExpotaciones Exp = new HEFDTEExpotaciones();
            Exp.AgregarNameSpace = true;

            ////
            //// Datos del documento
            Exp.version = "1.0";
            Exp.Exportaciones.Encabezado.IdDoc.TipoDTE = 110;
            Exp.Exportaciones.Encabezado.IdDoc.Folio = 1;
            Exp.Exportaciones.Encabezado.IdDoc.FchEmis = DateTime.Now.ToString("yyyy-MM-dd");
            Exp.Exportaciones.Encabezado.IdDoc.FmaPago = 3;
            Exp.Exportaciones.Encabezado.IdDoc.FmaPagExp = 21;


            ////
            //// Datos del emisor del documento
            Exp.Exportaciones.Encabezado.Emisor.RUTEmisor = "76269511-1";
            Exp.Exportaciones.Encabezado.Emisor.RznSoc = "SOCIEDAD DE INVERSIONES RIOFA SPA";
            Exp.Exportaciones.Encabezado.Emisor.GiroEmis = "Servicios de Internet";
            Exp.Exportaciones.Encabezado.Emisor.Acteco.Add(74990);
            Exp.Exportaciones.Encabezado.Emisor.DirOrigen = "Av Presidente Riesco 5111, Las Condes";
            Exp.Exportaciones.Encabezado.Emisor.CmnaOrigen = "Las Condes";
            Exp.Exportaciones.Encabezado.Emisor.CiudadOrigen = "Las Condes";

            ////
            //// Datos del receptor
            Exp.Exportaciones.Encabezado.Receptor.RUTRecep = "55555555-5";
            Exp.Exportaciones.Encabezado.Receptor.CdgIntRecep = "55555555-5";
            Exp.Exportaciones.Encabezado.Receptor.RznSocRecep = "HEFESTO LTDA.";
            Exp.Exportaciones.Encabezado.Receptor.DirRecep = "TEATINOS 120";
            Exp.Exportaciones.Encabezado.Receptor.CmnaRecep = "SANTIAGO";
            Exp.Exportaciones.Encabezado.Receptor.CiudadRecep = "SANTIAGO";
            

            ////
            //// Datos transporte
            Exp.Exportaciones.Encabezado.Transporte = new HEFTransporte();
            Exp.Exportaciones.Encabezado.Transporte.Aduana = new HEFAduana();
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodModVenta = 2;   
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodClauVenta = 1;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.TotClauVenta = 2418.25m; 
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodViaTransp = 7;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodPtoEmbarque = 904;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodPtoDesemb = 411;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodUnidMedTara = 10;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.PesoBruto = 0;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodUnidPesoBruto = 6;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodUnidPesoNeto = 17;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.TotBultos = 50;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.TipoBultos.Add(new HEFTipoBulto() { CodTpoBultos = 80, CantBultos=50,  });
            Exp.Exportaciones.Encabezado.Transporte.Aduana.MntFlete = 1556.16m; 
            Exp.Exportaciones.Encabezado.Transporte.Aduana.MntSeguro = 792.51m;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodPaisRecep = 336;
            Exp.Exportaciones.Encabezado.Transporte.Aduana.CodPaisDestin = 336;



            ////
            //// Totales del documento
            Exp.Exportaciones.Encabezado.Totales.TpoMoneda = "EURO";
            Exp.Exportaciones.Encabezado.Totales.MntExe = 70420;
            Exp.Exportaciones.Encabezado.Totales.MntTotal = 70420;

            ////
            //// Campos de conversión de la moneda a pesos chilenos
            Exp.Exportaciones.Encabezado.OtraMoneda = new HEFOtraMoneda();
            Exp.Exportaciones.Encabezado.OtraMoneda.TpoMoneda = "CPL";
            Exp.Exportaciones.Encabezado.OtraMoneda.TpoCambio = 100;
            Exp.Exportaciones.Encabezado.OtraMoneda.MntExeOtrMnda = 1000;
            Exp.Exportaciones.Encabezado.OtraMoneda.MntTotOtrMnda = 1000;

            ////
            //// detalle del documento
            Exp.Exportaciones.Detalle = new List<HEFDetalle>();
            HEFDetalle Detalle = new HEFDetalle();
            Detalle.NroLinDet = 1;
            Detalle.IndExe = 1;
            Detalle.NmbItem = "CHATARRA DE ALUMINIO";
            Detalle.QtyItem = 503;
            Detalle.UnmdItem = "KN";
            Detalle.PrcItem = 140;
            Detalle.MontoItem = 70420;
            Exp.Exportaciones.Detalle.Add(Detalle);

            
            ////
            //// Agregar recargo globales
            Exp.Exportaciones.DscRcgGlobal = new List<HEFDscRcgGlobal>();
            HEFDscRcgGlobal recargo = new HEFDscRcgGlobal();
            recargo.NroLinDR = 1;
            recargo.TpoMov = "R";
            recargo.GlosaDR = "RECARGO GLOBAL FLETE";
            recargo.TpoValor = "$";
            recargo.ValorDR = 974.65m;
            Exp.Exportaciones.DscRcgGlobal.Add(recargo);

            recargo = new HEFDscRcgGlobal();
            recargo.NroLinDR = 2;
            recargo.TpoMov = "R";
            recargo.GlosaDR = "RECARGO GLOBAL SEGURO";
            recargo.TpoValor = "$";
            recargo.ValorDR = 392.83m;
            Exp.Exportaciones.DscRcgGlobal.Add(recargo);



            ////
            //// Agregar referencias
            Exp.Exportaciones.Referencia = new List<HEFReferencia>();
            HEFReferencia Referencia = new HEFReferencia();
            Referencia.NroLinRef = 1;
            Referencia.TpoDocRef = "SET";
            Referencia.FolioRef = 0;
            Referencia.FchRef = "2015-11-05";
            Referencia.RazonRef = "CASO 438693-1";
            Exp.Exportaciones.Referencia.Add(Referencia);


            ////
            //// Agregar referencias
            Referencia = new HEFReferencia();
            Referencia.NroLinRef = 2;
            Referencia.TpoDocRef = "810";
            Referencia.FolioRef = 4;
            Referencia.FchRef = "2015-11-08";
            Exp.Exportaciones.Referencia.Add(Referencia);


            ////
            //// Inicie la serializacion del documento.
            Respuesta respuesta = Exp.RecuperarDte();
            if (respuesta.Correcto)
            {

                ////
                //// Construya el nombre de salida
                string nameOut = "PRUEBAS\\DTE_FACTURA_EXPORTACION.XML";

                ////
                //// Regresa el documento xml (DTE)
                XmlDocument xmlDTE = (XmlDocument)respuesta.Resultado;
                xmlDTE.Save(nameOut);

            }


        }


        

    }
}
