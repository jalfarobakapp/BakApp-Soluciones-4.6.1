using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.CONSULTA.ESTADO.DTE.AUTENTICACION
{
    public class ConsultaEstado
    {

        /// <summary>
        /// Consulta el estado de un documento DTE
        /// </summary>
        public static RespuestaQuery ConsultaEstadoDte(entDatos datos)
        {
            ////
            //// inicie la respuesta de la consulta
            RespuestaQuery rq = new RespuestaQuery();


            ////
            //// Inicie el procesamiento 
            try
            {

                ////
                //// Recupere los datos necesarios
                //// RutConsultante,
                //// DvConsultante,
                //// RutCompania,
                //// DvCompania,
                //// RutReceptor,
                //// DvReceptor,
                //// TipoDte,
                //// FolioDte,
                //// FechaEmisionDte,
                //// MontoDte,
                //// Token

                PRODUCCION.QueryEstDteService query = new PRODUCCION.QueryEstDteService();
                string respuesta = query.getEstDte(datos.QueryRutConsultante,
                    datos.QueryDvConsultante,
                    datos.QueryRutCompania,
                    datos.QueryDvCompania,
                    datos.QueryRutReceptor,
                    datos.QueryDvReceptor,
                    datos.TipoDte,
                    datos.Folio,
                    datos.QueryFecha,
                    datos.MontoDte,
                    datos.Token);

                ////
                //// Interprete el estado de la consulta
                rq = FuncionesComunes.leerRespuestaEstadoDte(respuesta);
                
            }
            catch (Exception)
            {

                rq.EsCorrecto = false;
                rq.Mensaje = "No fue posible realizar la consulta del documento";
            }


            ////
            //// Regrese el valor de retorno.
            return rq;

        
        }

    }
}
