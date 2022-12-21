using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HEFSIIREGCOMPRAVENTAS.LIB;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {

            ////
            //// Consultar todos los elementos de ventas

            ////
            //// TEST VENTAS
            recuperarResumenVentasRegistro();
            recuperarVentasRegistro();

            ////
            //// TEST COMPRAS
            recuperarResumenCompras();
            RecuperarComprasRegistro();
            RecuperarComprasPendientes();
            RecuperarComprasNoIncluir();
            RecuperarComprasReclamadas();

            ////
            //// Pause
            Console.ReadKey();
            

        }


        #region CONSULTAS AL REGISTRO DE VENTAS

        /// <summary>
        /// Consulta el resumen de ventas del registro de documentos
        /// </summary>
        static void recuperarResumenVentasRegistro()
        {
            ////
            //// Instancie la clase
            HefConsultas query = new HefConsultas("79514800-0", "JUAN PABLO SIERRALTA OREZZOLI");

            ////
            //// Recuperar la información de ventas
            HefRespuesta r = query.RecuperarResumenVentas("2021-01");
            Console.WriteLine(r.EsCorrecto);
            Console.WriteLine(r.Mensaje);
            Console.WriteLine(r.Detalle);
            if (r.EsCorrecto)
                File.WriteAllText("Resultados\\ResumenVentas.json", r.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"));
        }

        /// <summary>
        /// Recupera la información de ventas del registro del SII
        /// por tipo de documento y periodo
        /// </summary>
        static void recuperarVentasRegistro()
        {

            ////
            //// Instancie la clase
            HefConsultas query = new HefConsultas("79514800-0", "JUAN PABLO SIERRALTA OREZZOLI");

            ////
            //// Recuperar la información de ventas
            HefRespuesta r = query.RecuperarVentasRegistro("2021-02");
            Console.WriteLine(r.EsCorrecto);
            Console.WriteLine(r.Mensaje);
            Console.WriteLine(r.Detalle);
            if (r.EsCorrecto)
                File.WriteAllText("Resultados\\RegistrosVentas.json", r.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"));
            
        }

        #endregion

        #region CONSULTAS AL REGISTRO COMPRAS

        /// <summary>
        /// Recupera el resumen de compras 
        /// </summary>
        static void recuperarResumenCompras()
        {
            ////
            //// Instancie la clase
            //// Parametros
            //// - RutEmisor
            //// - Cn Certificado
            HefConsultas query = new HefConsultas("79514800-0", "JUAN PABLO SIERRALTA OREZZOLI");

            ////
            //// Recuperar la información de ventas
            //// Parametro
            //// Periodo: Corresponde al periodo consultado ejemplo 2021-01
            HefRespuesta r = query.RecuperarResumenCompras("2022-11");
            Console.WriteLine(r.EsCorrecto);
            Console.WriteLine(r.Mensaje);
            Console.WriteLine(r.Detalle);
            if (r.EsCorrecto)
                File.WriteAllText("Resultados\\ResumenCompras.json", r.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"));

        }

        /// <summary>
        /// Recupera los datos del registro de compras completo
        /// </summary>
        static void RecuperarComprasRegistro()
        {

            ////
            //// Instancie la clase
            //// - RutEmisor
            //// - Cn Certificado
            HefConsultas query = new HefConsultas("79514800-0", "JUAN PABLO SIERRALTA OREZZOLI");

            ////
            //// Recuperar la información de ventas
            //// Parametro
            //// Periodo : Corresponde al periodo consultado ejemplo 2021-01
            //// TipoDTE : Tipo de documento a buscar
            HefRespuesta r = query.RecuperarComprasRegistro("2022-11");
            Console.WriteLine(r.EsCorrecto);
            Console.WriteLine(r.Mensaje);
            Console.WriteLine(r.Detalle);
            if (r.EsCorrecto)
                File.WriteAllText("Resultados\\RegistrosCompras.json", r.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"));

        }

        /// <summary>
        /// Recuperación de la información de compras pendientes
        /// </summary>
        static void RecuperarComprasPendientes()
        {

            ////
            //// Instancie la clase
            //// Parametros
            //// - RutEmisor
            //// - Cn Certificado
            HefConsultas query = new HefConsultas("79514800-0", "JUAN PABLO SIERRALTA OREZZOLI");

            ////
            //// Recuperar la información de ventas
            //// Parametro
            //// Periodo : Corresponde al periodo consultado ejemplo 2021-01
            //// TipoDTE : Tipo de documento a buscar
            HefRespuesta r = query.RecuperarComprasPendientes("2022-11");
            Console.WriteLine(r.EsCorrecto);
            Console.WriteLine(r.Mensaje);
            Console.WriteLine(r.Detalle);
            if (r.EsCorrecto)
                File.WriteAllText("Resultados\\RegistrosComprasPendientes.json", r.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"));

        }

        /// <summary>
        /// Recuperación del registro de compras que no deben ser incluídas
        /// </summary>
        static void RecuperarComprasNoIncluir()
        {
            ////
            //// Instancie la clase
            //// Parametros
            //// - RutEmisor
            //// - Cn Certificado
            HefConsultas query = new HefConsultas("79514800-0", "JUAN PABLO SIERRALTA OREZZOLI");

            ////
            //// Recuperar la información de ventas
            //// Parametro
            //// Periodo : Corresponde al periodo consultado ejemplo 2021-01
            //// TipoDTE : Tipo de documento a buscar
            HefRespuesta r = query.RecuperarComprasNoIncluir("2022-11");
            Console.WriteLine(r.EsCorrecto);
            Console.WriteLine(r.Mensaje);
            Console.WriteLine(r.Detalle);
            if (r.EsCorrecto)
                File.WriteAllText("Resultados\\RegistrosComprasNoIncluir.json", r.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"));

        }

        /// <summary>
        /// Registro de compras reclamadas
        /// </summary>
        static void RecuperarComprasReclamadas()
        {

            ////
            //// Instancie la clase
            //// Parametros
            //// - RutEmisor
            //// - Cn Certificado
            HefConsultas query = new HefConsultas("79514800-0", "JUAN PABLO SIERRALTA OREZZOLI");

            ////
            //// Recuperar la información de ventas
            //// Parametro
            //// Periodo : Corresponde al periodo consultado ejemplo 2021-01
            //// TipoDTE : Tipo de documento a buscar
            HefRespuesta r = query.RecuperarComprasReclamadas("2022-11");
            Console.WriteLine(r.EsCorrecto);
            Console.WriteLine(r.Mensaje);
            Console.WriteLine(r.Detalle);
            if (r.EsCorrecto)
                File.WriteAllText("Resultados\\RegistrosComprasReclamadas.json", r.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"));

        }

        #endregion

    }

}
