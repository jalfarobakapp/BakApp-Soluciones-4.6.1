using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.IO;
using HEFESTO.DTE.SERIALIZATION.ENTIDADES;


namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{


    /// <summary>
    /// Representa el documento DTE actual
    /// </summary>
    [XmlRoot(ElementName = "DTE")]
    public class HEFDTE
    {

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HEFDTE()
        {
            //DateTime dt = new DateTime(2015, 12, 12);
            //if (DateTime.Now >= dt)
            //    throw new Exception("Clase Demo expirada.");
        
        }

        /// <summary>
        /// Representa la zona Documento
        /// </summary>
        HEFDocumento _Documento = new HEFDocumento();
        public HEFDocumento Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }

        /// <summary>
        /// Representa el atributo version del documento DTE
        /// </summary>
        [XmlAttribute("version")]
        public string version { get; set; }


        #region METODOS INTERNOS DE LA CLASE

        /// <summary>
        /// Indica si se debe calcular o no los montos de la totalera
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool calcularMontosDocumentoDTE { get; set; }

        /// <summary>
        /// Serializa la clase para obtener el documento xml de resultado
        /// </summary>
        /// <returns>Documento XML que representa el DTE del SII(basico)</returns>
        public Respuesta RecuperarDte()
        {

            ////
            //// Inicie la respuesta del proceso
            Respuesta respuesta = new Respuesta();
            XmlWriter xmlwriter;

            ////
            //// Inicie la serializacion del documento
            try
            {

                ////
                //// Normalice los datos del documento. Agrega las fechas del documento
                //// comprueba rutas, etc.
                Respuesta resp = this.NormalizarDocumentoDTE();
                if (!resp.Correcto)
                    throw new Exception(resp.Mensaje);


                ////
                //// Calcular los montos del documento actual 
                resp = null;
                if (this.calcularMontosDocumentoDTE)
                {
                    resp = this.calcularMontosDocumentoDTETotalera();
                    if (!resp.Correcto)
                        throw new Exception(resp.Mensaje);
                }


                #region SERIALIZA EL OBJETO ACTUAL EN UN DOCUMENTO XML DTE

                ////
                //// Prepare el espacio de nombres a utilizar para la serializacion
                var xns = new XmlSerializerNamespaces();
                xns.Add(string.Empty, string.Empty);


                ////
                //// Setee el resultado de la declaracion del documento xml
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.Encoding = Encoding.GetEncoding("ISO-8859-1");
                xws.Indent = true;

                ////
                //// Serialice la clase DTE
                XmlSerializer x = new XmlSerializer(this.GetType());

                ////
                //// Cree temporalmente un archivo xml para guardar el resultado
                string rutaResultadoDte = ObtenerRutaResultado();
                using (XmlWriter xw = XmlWriter.Create(rutaResultadoDte, xws))
                {
                    xw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\" ");
                    x.Serialize(xw, this, xns);
                    xmlwriter = xw;
                }


                ////
                //// Factorice el documento
                FactorizarDocumento(rutaResultadoDte);

                #endregion


                ////
                //// Indique al usuario que el proceso es correcto
                respuesta.Correcto = true;
                respuesta.Mensaje = "Fin del proceso de serializaciond el objeto actual OK";
                respuesta.Detalle = string.Empty;

                XmlDocument xDte = new XmlDocument();
                xDte.PreserveWhitespace = true;
                xDte.Load(rutaResultadoDte);
                respuesta.Resultado = xDte;


                File.Delete(rutaResultadoDte);


            }
            catch (Exception excep)
            {
                ////
                //// Indique el error al codigo cliente
                respuesta.Correcto = false;
                respuesta.Mensaje = "No fue posible serializar el objeto DTE actual.";
                respuesta.Detalle = excep.Message;
                respuesta.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno del metodo
            return respuesta;


        }

        /// <summary>
        /// Permite normalizar los datos del documento
        /// </summary>
        private Respuesta NormalizarDocumentoDTE()
        {

            ////
            //// Inicie la respuesta de este metodo
            Respuesta respuesta = new Respuesta();

            try
            {
                ////
                //// En el caso que no se asigne la version del nodo DTE, asigne automaticamente 
                //// el valor por defecto del mismo.
                if (string.IsNullOrEmpty(this.version))
                    this.version = "1.0";

                ////
                //// En el caso que el usuario no setee la fecha de emison del
                //// documento. la clase agregara la fecha actual para completar el nodo.
                if (string.IsNullOrEmpty(this.Documento.Encabezado.IdDoc.FchEmis))
                    this.Documento.Encabezado.IdDoc.FchEmis = DateTime.Now.ToString("yyyy-MM-dd");

                ////
                //// En el caso que el usuario no agregue el valor del TMSTFirma del documento
                //// la clase agregara el correspondiente al de hoy.
                if (string.IsNullOrEmpty(this.Documento.TmstFirma))
                    this.Documento.TmstFirma = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                ////
                //// En el caso que el usuario no agregue un Id para el documento actual
                //// la clase agregara uno de forma automatica al nodo que corresponde.
                string IDTemp = "HEFESTO_DTE_T{0}_F{1}_R{2}";
                if (string.IsNullOrEmpty(this.Documento.ID))
                {

                    ////
                    //// Pregunte si existen datos suficientes para crear el ID del documento
                    string sRUTEmisor = string.Empty;
                    if (string.IsNullOrEmpty(this.Documento.Encabezado.Emisor.RUTEmisor))
                        sRUTEmisor = "99999999-9";
                    else
                        sRUTEmisor = this.Documento.Encabezado.Emisor.RUTEmisor;

                    ////
                    //// Construya el ID
                    this.Documento.ID = string.Format(IDTemp,
                        this.Documento.Encabezado.IdDoc.TipoDTE,
                        this.Documento.Encabezado.IdDoc.Folio,
                        sRUTEmisor.Replace("-", "_")
                        );

                }



                ////
                //// Definicion de numero de linea del detalle de forma automatica
                List<HEFDetalle> detalles = this.Documento.Detalles;
                int i = 1;
                detalles.ForEach(delegate(HEFDetalle det)
                {
                    det.NroLinDet = i;
                    i++;
                });




                ////
                //// Indique el final del proceso
                respuesta.Correcto = true;


            }
            catch (Exception excep)
            {
                ////
                //// Colocar aqui cualquier excepcion que se genere
                respuesta.Correcto = false;
                respuesta.Mensaje = "No fue posible normalizar el documento.";
                respuesta.Detalle = excep.Message;
                respuesta.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return respuesta;


        }

        /// <summary>
        /// Calcula los valores del nodo Totales utilizando los
        /// elementos ingresados por el usuario.
        /// </summary>
        private Respuesta calcularMontosDocumentoDTETotalera()
        {

            ////
            //// Inicie la respuesta de este metodo
            Respuesta Respuesta = new Respuesta();

            ///
            //// Intente calcular los montos del documento
            //// utilizando los elementos introducidos por el 
            //// usuario.
            try
            {

                ////
                //// Pregunte si existen detalle a procesar
                if (this.Documento.Detalles == null)
                    throw new Exception("No hay detalles para calcular la totalera. La coleccion de detalles es null.");

                ////
                //// Pregunte si existen detalle a procesar
                if (this.Documento.Detalles.Count == 0)
                    throw new Exception("No hay suficientes detalles para calcular la totalera.");

                ////
                //// Calcule los impuestos y retenciones
                CalcularImpuestosRetenciones();

                ////
                //// Recupere todos los elementos netos del detalle y sumelos
                var MntNetoSum = this.Documento.Detalles.Where(a => !(a.IndExe >= 1)).Sum(a => a.MontoItem);
                var MntExeSum = this.Documento.Detalles.Where(a => a.IndExe == 1).Sum(a => a.MontoItem);

                ////
                //// Calcule los descuentos y recargos 
                var DescuentoGlobalAfecto =  CalcularDescuentosGlobalesAfec();

                ////
                //// Recalcule valores
                MntNetoSum -= DescuentoGlobalAfecto;


                ////
                //// Calcule los impuestos y retenciones
                double MntImptoReten = 0;
                if (this.Documento.Encabezado.Totales.ImptoReten != null)
                    MntImptoReten = this.Documento.Encabezado.Totales.ImptoReten.Sum(a => a.MontoImp);

                ////
                //// Calcule el IVA del documento.
                var MntIVA = Math.Round((MntNetoSum * 0.19), MidpointRounding.AwayFromZero);

                ////
                //// Calcule el monto total del documento
                var MntTotalSum = (MntNetoSum + MntExeSum + MntIVA + MntImptoReten);

                ////
                //// Traslade los valores a sus respectivos nodos
                this.Documento.Encabezado.Totales.MntNeto = MntNetoSum;
                this.Documento.Encabezado.Totales.MntExe = MntExeSum;
                this.Documento.Encabezado.Totales.IVA = MntIVA;
                this.Documento.Encabezado.Totales.MntTotal = MntTotalSum;


                ////
                //// Regrese el resultado de la operacion
                Respuesta.Correcto = true;


            }
            catch (Exception Excep)
            {
                ////
                //// Colocar aqui cualquier excepcion que se genere
                Respuesta.Correcto = false;
                Respuesta.Mensaje = "No fue posible calcular los montos de la totalera.";
                Respuesta.Detalle = Excep.Message;
                Respuesta.Resultado = null;

            }


            ////
            //// Regrese el valor del metodo
            return Respuesta;

        }

        /// <summary>
        /// Calcula el resumen de los impuestos y retenciones
        /// </summary>
        private void CalcularImpuestosRetenciones()
        {

            ////
            //// Cree la respuesta 
            List<HEFImptoReten> RespImptoRetens = new List<HEFImptoReten>();

            ////
            //// Recupere los impuestos y retenciones 
            List<HEFImptoReten> ImptoRetens = this.Documento.Encabezado.Totales.ImptoReten;

            ////
            //// Si nohay valores 
            if (ImptoRetens == null)
                return;


            ////
            //// Recupere la lista de los impuestos subyacentes en la lista original
            List<string> Codigos = ImptoRetens.Select(p => p.TipoImp).Distinct().ToList();
            foreach (string Codigo in Codigos)
            {

                ////
                //// Recupere la informacion del impuesto.
                string TasaImp = ImptoRetens.Where(p => p.TipoImp == Codigo).FirstOrDefault().TasaImp;

                ////
                //// Calcule el monto total
                double MontoImp = ImptoRetens.Where(p => p.TipoImp == Codigo).Sum(i => i.MontoImp);

                ////
                //// Cree el nuevo elemento
                HEFImptoReten ImptoReten = new HEFImptoReten();
                ImptoReten.TipoImp = Codigo;
                ImptoReten.TasaImp = TasaImp;
                ImptoReten.MontoImp = MontoImp;
                RespImptoRetens.Add(ImptoReten);

            }


            ////
            //// Reasigne  los valores
            this.Documento.Encabezado.Totales.ImptoReten = RespImptoRetens;

        }

        /// <summary>
        /// Calcular los Descuentos y Recargos
        /// </summary>
        private double CalcularDescuentosGlobalesAfec()
        {

            ////
            //// Recupere los impuestos y retenciones 
            double Descuentos = 0;
            List<HEFDscRcgGlobal> DscRcgs = this.Documento.DscRcgGlobals;
            List<HEFDscRcgGlobal> DescuentosAfec;
                        
            ////
            //// Si nohay valores 
            if (DscRcgs == null || DscRcgs.Count == 0 )
                return 0;
           
            ////
            //// Calcule el total de monto neto del documento 
            Double MntNetoSum = this.Documento.Detalles.Where(a => !(a.IndExe >= 1)).Sum(a => a.MontoItem);

            ////
            //// Recupere todos los descuentos y recargos desde 
            //// la coleccion de elementos que afecten a items 
            //// efectos del documento.
            DescuentosAfec = DscRcgs.Where(d => d.TpoMov == "D" && !(d.IndExeDR >= 1) ).ToList();

            ////
            //// Salga si no hay valores
            if ( DescuentosAfec == null || DescuentosAfec.Count == 0 )
                return 0;

            ////
            //// Recupere el valor nominal de descuentos
            Descuentos = Convert.ToDouble( DescuentosAfec.Where(d => d.TpoValor == "$").Sum(d => d.ValorDR) );

            ////
            //// Recupere el valor porcentual de descuentos
            Descuentos += DescuentosAfec.Where(d => d.TpoValor == "%").Sum(d => Math.Round( ( ( Convert.ToDouble( d.ValorDR ) * MntNetoSum )/100 ), MidpointRounding.AwayFromZero ) );
                    
        
            ////
            //// Regrese el valor de retorno
            return Descuentos;

        }

        /// <summary>
        /// Genera la ruta de resultado donde se depositara el documento DTE
        /// generado por esta clase.
        /// </summary>
        /// <remarks>
        /// - En el caso de estar en modo DEBUG, la clase regresara la ruta actual del proyecto.
        /// - En el caso de no haber ruta 
        /// </remarks>
        private string ObtenerRutaResultado()
        {

            ////
            //// Ruta Temporal
            const string TEMP = "TEMPORALES";

            ////
            //// Cree el nombre del documento actual(Plantilla)
            string DteTpo = "00";
            string DteFolio = "0000000000";
            string DteRut = "00000000_0";
            string DteName = "DTE_T{0}_F{1}_R{2}.XML";
            string DtePath = "";

            ////
            //// Normalice los datos del documento para construir
            //// correctamente el nombre del documento.

            ////
            //// Normalice si es necesario el valor de 'TipoDTE'.
            if (!string.IsNullOrEmpty(this.Documento.Encabezado.IdDoc.TipoDTE.ToString()))
                DteTpo = this.Documento.Encabezado.IdDoc.TipoDTE.ToString();

            ////
            //// Normalice si es necesario el valor de 'Folio'.
            if (!string.IsNullOrEmpty(this.Documento.Encabezado.IdDoc.Folio.ToString()))
                DteFolio = this.Documento.Encabezado.IdDoc.Folio.ToString();

            ////
            //// Normalice si es necesario el valor de 'Folio'.
            if (!string.IsNullOrEmpty(this.Documento.Encabezado.Emisor.RUTEmisor))
                DteRut = this.Documento.Encabezado.Emisor.RUTEmisor;

            ////
            //// Construya el nombre del documento DTE a generar
            DteName = string.Format(DteName, DteTpo, DteFolio, DteRut);

            ////
            //// Pregunte si la path actual es valida, si no es asi
            //// deje la temporal.
            if (!Directory.Exists(TEMP))
                Directory.CreateDirectory(TEMP);
            DtePath = TEMP;

            ////
            //// Construya la fullpath del documento
            DtePath = Path.Combine(DtePath, DteName);

            ////
            //// Compruebe que no exista el mismo documento
            //// en el fullpath creado.
            if (File.Exists(DtePath))
                File.Delete(DtePath);

            ////
            //// Regrese el valor de retorno del metodo
            return DtePath;

        }

        /// <summary>
        /// Factoriza elementos del documento que la serializacion 
        /// pasa por alto
        /// </summary>
        /// <param name="uri"></param>
        private void FactorizarDocumento(string uri)
        { 
        
            ////
            //// Cargue el documento xml generado 
            XmlDocument xmlDte = new XmlDocument();
            xmlDte.PreserveWhitespace = true;
            xmlDte.Load(uri);


            ////
            //// Cree el administrador de name space
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlDte.NameTable);
            ns.AddNamespace("sii", xmlDte.DocumentElement.NamespaceURI);


            ////
            //// Si el documento es un a factura exenta no muestre la tasa del IVA
            XmlElement node = (XmlElement)xmlDte.SelectSingleNode("sii:DTE/sii:Documento/sii:Encabezado/sii:IdDoc/sii:TipoDTE", ns);
            if (node != null && node.InnerText.Equals("34"))
            {
                ////
                //// Elimine la tasa del impuesto
                XmlElement nodeTasa = (XmlElement)xmlDte.SelectSingleNode("sii:DTE/sii:Documento/sii:Encabezado/sii:Totales/sii:TasaIVA", ns);
                if (nodeTasa != null)
                    nodeTasa.ParentNode.RemoveChild(nodeTasa);

            }


            ////
            //// Si los detalles del documento quedan con codigo pero sin valores eliminelos
            XmlNodeList Detalles = xmlDte.SelectNodes("sii:DTE/sii:Documento/sii:Detalle", ns);
            foreach (XmlElement Detalle in Detalles)
            { 
                XmlElement nodeCdgItem = (XmlElement)Detalle.SelectSingleNode("sii:CdgItem",ns);
                if (nodeCdgItem != null && !nodeCdgItem.HasChildNodes)
                    nodeCdgItem.ParentNode.RemoveChild(nodeCdgItem);

                XmlElement nodeDscItem = (XmlElement)Detalle.SelectSingleNode("sii:DscItem", ns);
                if (nodeDscItem != null && nodeDscItem.InnerText == string.Empty)
                    nodeDscItem.ParentNode.RemoveChild(nodeDscItem);

                XmlElement nodeRetenedor = (XmlElement)Detalle.SelectSingleNode("sii:Retenedor", ns);
                if ( nodeRetenedor!= null &&  !nodeRetenedor.HasChildNodes)
                    nodeRetenedor.ParentNode.RemoveChild(nodeRetenedor);


            }


            ////
            //// Guarde el documento
            xmlDte.Save(uri);

            ////
            //// Abra nuevamente el documento para ordenarlo
            xmlDte = new XmlDocument();
            xmlDte.Load(uri);
            xmlDte.Save(uri);


        }
        
        #endregion



    }

}
