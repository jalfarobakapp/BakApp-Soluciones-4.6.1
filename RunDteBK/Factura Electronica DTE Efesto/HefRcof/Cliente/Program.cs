using HefRcof;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {

            ////
            //// Generar archivo Rcof
            HefConsumoFolios cf = new HefConsumoFolios();

            ////
            //// Indicar el certificado a utilizar
            cf.Certificado = "Javier Antonio Solis Ganga";
            cf.Schema = "Schemas\\Rcof.xsd";

            ////
            //// Completar la caratula del rcof
            cf.DocumentoConsumoFolios.Caratula.RutEmisor = "76196416-K";
            cf.DocumentoConsumoFolios.Caratula.RutEnvia = "9517320-9";
            cf.DocumentoConsumoFolios.Caratula.FchResol = "2014-08-22";
            cf.DocumentoConsumoFolios.Caratula.NroResol = "80";
            cf.DocumentoConsumoFolios.Caratula.FchInicio = "2019-12-19";
            cf.DocumentoConsumoFolios.Caratula.FchFinal = "2019-12-19";
            cf.DocumentoConsumoFolios.Caratula.Correlativo = "1";
            cf.DocumentoConsumoFolios.Caratula.SecEnvio = "1";

           

            ////
            //// Agregar un nuevo resumen al proceso
            HefResumen resumen = new HefResumen();
            resumen.TipoDocumento = 39;
            resumen.MntNeto = 4840711;
            resumen.MntExento = 0;
            resumen.MntIva = 919735;
            resumen.MntTotal = 5760446;
            resumen.FoliosEmitidos = 792;
            resumen.FoliosAnulados = 0;
            resumen.FoliosUtilizados = 792;

            HefRangoUtilizados RUtil1 = new HefRangoUtilizados();
            RUtil1.Inicial = 1;
            RUtil1.Final = 198;
            resumen.RangoUtilizados.Add(RUtil1);

            HefRangoUtilizados RUtil2 = new HefRangoUtilizados();
            RUtil2.Inicial = 8001;
            RUtil2.Final = 8372;
            resumen.RangoUtilizados.Add(RUtil2);

            HefRangoUtilizados RUtil3 = new HefRangoUtilizados();
            RUtil3.Inicial = 25009;
            RUtil3.Final = 25230;
            resumen.RangoUtilizados.Add(RUtil3);


            //HefRangoAnulados RAnul1 = new HefRangoAnulados();
            //RAnul1.Inicial = 11;
            //RAnul1.Final = 15;
            //resumen.RangoAnulados.Add(RAnul1);

            //HefRangoAnulados RAnul2 = new HefRangoAnulados();
            //RAnul2.Inicial = 23;
            //RAnul2.Final = 24;
            //resumen.RangoAnulados.Add(RAnul2);


            //// Agregar el resumen
            cf.DocumentoConsumoFolios.Resumenes.Add(resumen);

            //// Iniciar la publicación del documento actual
            if (cf.Publicar())
            {

                Console.WriteLine(cf.Trackid);

            }
            
                       
            ////
            //PAuse
            Console.Read();


        }
    }
}
