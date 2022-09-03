using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Representa un item del tipo detalle del documento
    /// </summary>
    public class HEFDetalle
    {

        ////
        //// Codigos Impuestos adicionales
        List<int> _CodImpAdics = new List<int>();

        ////
        //// Inicie las clases internas
        HEFCdgItem _CdgItem = new HEFCdgItem();

        ////
        //// Agente retenedor
        HEFRetenedor _Retenedor = new HEFRetenedor();


        /// <summary>
        /// #1 - Número del ítem. Desde 1 a 60
        /// </summary>
        public int NroLinDet { get; set; }

        /// <summary>
        /// #2 - #3 TABLA de Códigos de Ítem 
        /// </summary>
        public HEFCdgItem CdgItem
        {
            get { return _CdgItem; }
            set { _CdgItem = value; }
        }
        
        /// <summary>
        /// #4 - Documento que se liquida
        /// </summary>
        /// <remarks>
        /// Para liquidaciones se debe registrar el 
        /// código del docto. que se liquida. 
        /// (Ej: :30, 33, 35, 39, 56,etc.)
        /// </remarks>
        public int TpoDocLiq { get; set; }
        public bool ShouldSerializeTpoDocLiq(){return (TpoDocLiq == 0) ? false : true;}
        


        /// <summary>
        /// #5 - Indicador de facturación/exención 
        /// </summary>
        /// <remarks>
        /// Indica si el producto o servicio es exento o no afecto a impuesto o si ya 
        /// ha sido facturado. (También se utiliza para indicar garantía de depósito por 
        /// envases. Art.28,Inc3 Reglamento DL 825) (Cervezas, Jugos, Aguas 
        /// Minerales, Bebidas Analcohólicas u otros autorizados por Resolución 
        /// especial) 
        /// Si todos los ítems de una factura tienen valor 1 en este indicador la 
        /// factura no puede ser factura electrónica (código 33), debería ser 
        /// factura exenta (código 34) . Sólo en caso de Liquidación-Factura
        /// que tenga ítems no facturables negativos, se debe señalar el 
        /// indicador 2, e informar el valor con signo negativo.
        /// </remarks>
        /// <example>
        /// 1: No afecto o exento de IVA (10) 
        /// 2: Producto o servicio no es facturable 
        /// 3: Garantía de depósito por envases (Cervezas, Jugos, Aguas Minerales, 
        /// Bebidas Analcohólicas u otros autorizados por Resolución especial) 
        /// 4: Ítem No Venta. (Para facturas y guías de despacho (ésta última 
        /// con Indicador Tipo de Traslado de Bienes. igual a 1) y este ítem no 
        /// será facturado. 
        /// 5: Ítem a rebajar. Para guías de despacho NO VENTA que rebajan 
        /// guía anterior. En el área de referencias se debe indicar la guía anterior. 
        /// 6: Producto o servicio no facturable negativo (excepto en 
        /// liquidaciones-factura) 
        /// </example>
        public int IndExe { get; set; }
        public bool ShouldSerializeIndExe(){return (IndExe == 0) ? false : true; }


        /////////////////////////////////////////////////////
        //// <Retenedor>
        //// Mr. 21-11-2014
        //// Se agrega Nodo Retenedor para facturas de compra
        /////////////////////////////////////////////////////
        public HEFRetenedor Retenedor
        {
            get { return _Retenedor; }
            set { _Retenedor = value; }

        }

        /////////////////////////////////////////////////////
        //// FIN <Retenedor>
        /////////////////////////////////////////////////////



        /// <summary>
        /// #10 - Nombre del producto o servicio 
        /// </summary>
        /// <remarks>
        /// Nombre del producto o servicio
        /// </remarks>
        public string NmbItem { get; set; }

        /// <summary>
        /// #11 - Descripción adicional del producto o servicio
        /// </summary>
        /// <remarks>
        /// Descripción Adicional del producto o 
        /// servicio. Se utiliza para pack, servicios 
        /// con detalle 
        /// </remarks>
        public string DscItem { get; set; }

        /// <summary>
        /// #12 - Cantidad de referencia 
        /// </summary>
        /// <remarks>
        /// Cantidad para la unidad de medida de 
        /// referencia (no se usa para el cálculo 
        /// del valor neto) en 12 enteros y 6  decimales. 
        /// Obligatorio para facturas de venta o 
        /// compra que indican emisor opera 
        /// como Agente Retenedor
        /// </remarks>
        [XmlElement]
        public long QtyRef { get; set; }
        public bool ShouldSerializeQtyRef() { return (QtyRef == 0) ? false : true; }


        /// <summary>
        /// #13 - Unidad de referencia
        /// </summary>
        /// <remarks>
        /// Glosa con unidad de medida de referencia 
        /// Obligatorio para facturas de venta, 
        /// compra o notas que indican emisor 
        /// opera como Agente Retenedor
        /// </remarks>
        /// <example>
        /// Sin validación 
        /// En Guías de Despacho 
        /// con Indicador de tipo de 
        /// Traslado de Bienes 8 o 
        /// 9, es obligatoria si el 
        /// campo Cantidad no está 
        /// en la unidad Kgs brutos. 
        /// Adicionalmente en dicho 
        /// caso se debe utilizar 
        /// tabla de unidades de aduana
        /// </example>
        [XmlElement]
        public long UnmdRef { get; set; }
        public bool ShouldSerializeUnmdRef() { return (UnmdRef == 0) ? false : true; }

        /// <summary>
        /// #14 - Precio de referencia
        /// </summary>
        /// <remarks>
        /// Precio unitario para la unidad de 
        /// medida de referencia (no se usa para 
        /// el cálculo del valor neto) 12 enteros, 6 
        /// decimales. 
        /// Obligatorio para facturas de venta, 
        /// compra o notas que indican emisor 
        /// opera como Agente Retenedor
        /// </remarks>
        /// <example>
        /// Valor numérico 12 
        /// enteros, 6 decimales 
        /// </example>
        [XmlElement]
        public long PrcRef { get; set; }
        public bool ShouldSerializePrcRef() { return (PrcRef == 0) ? false : true; }

        /// <summary>
        /// #15 - Cantidad
        /// </summary>
        /// <remarks>
        /// Cantidad del ítem en 12 enteros y 6 
        /// decimales 
        /// Obligatorio para facturas de venta, 
        /// compra o notas que indican emisor 
        /// opera como Agente Retenedor
        /// </remarks>
        [XmlElement]
        public long QtyItem { get; set; }
        public bool ShouldSerializeQtyItem() { return (QtyItem == 0) ? false : true; }



        ///////////////////////////////////////////////////////
        //// codigos subcantidad 16-17-18
        //// Solo aplica en procesos adicionales
        ///////////////////////////////////////////////////////

        /// <summary>
        /// #19 - Fecha de elaboracion
        /// </summary>
        [XmlElement]
        public string FchElabor { get; set; }

        /// <summary>
        /// #20 - Fecha de vencimiento
        /// </summary>
        [XmlElement]
        public string FchVencim { get; set; }

        /// <summary>
        /// #21 - Unidad de medida
        /// </summary>
        /// <remarks>
        /// Unidad de medida
        /// </remarks>
        /// <example>
        /// Obligatorio para facturas de venta, compra o notas que indican 
        /// emisor opera como Agente Retenedor Obligatorio en Guías de 
        /// Despacho con Indicador de tipo de Traslado de Bienes = 8 y 9 
        /// En Facturas de Exportación Campo obligatorio a excepción 
        /// cuando en el “Indicador de Servicio” se registra el valor 3, 4 o 5. En 
        /// dicho caso se debe utilizar tabla de unidades de Aduanas
        /// </example>
        [XmlElement]
        public string UnmdItem { get; set; }


        /// <summary>
        /// #22 - Precio unitario del item
        /// </summary>
        [XmlElement]
        public long PrcItem { get; set; }
        public bool ShouldSerializePrcItem(){return (PrcItem == 0) ? false : true;}

        /////////////////////////////////////////////
        //// tabla otra moneda detalle
        //// 23 -24-25-26-27-28
        //// Solo aplica en procesos adicionales
        /////////////////////////////////////////////

        /// <summary>
        /// #29 - Descuento en %
        /// </summary>
        /// <remarks>
        /// Descuento (%) en 3 enteros y 2 decimales
        /// </remarks>
        public int DescuentoPct { get; set; }
        public bool ShouldSerializeDescuentoPct() { return (DescuentoPct == 0) ? false : true; }


        /// <summary>
        /// #30 - Descuento Descuento
        /// </summary>
        /// <remarks>
        /// Correspondiente al anterior. Totaliza 
        /// todos los descuentos otorgados al ítem
        /// </remarks>
        public double DescuentoMonto { get; set; }
        public bool ShouldSerializeDescuentoMonto() { return (DescuentoMonto == 0) ? false : true; }

        /////////////////////////////////////////////////
        //// tabla de distribucion del descuento
        //// 31-32
        //// Solo aplica en procesos adicionales
        /////////////////////////////////////////////////


        /// <summary>
        /// #33 - Recargo en %
        /// </summary>
        /// <remarks>
        /// Recargo (%) en 3 enteros y 2 decimales 
        /// </remarks>
        public string RecargoPct { get; set; }


        /// <summary>
        /// #32 - Monto Recargo
        /// </summary>
        /// <remarks>
        /// Correspondiente al anterior. Totaliza 
        /// todos los recargos otorgados al ítem
        /// </remarks>
        public double RecargoMonto { get; set; }
        public bool ShouldSerializeRecargoMonto() { return (RecargoMonto == 0) ? false : true; }


        /////////////////////////////////////////////////
        //// tabla <SubRecargo>
        //// 35-36
        //// Solo aplica en procesos adicionales
        /////////////////////////////////////////////////

        /////////////////////////////////////////////////
        //// tabla CodImpAdic
        //// 37
        //// Solo aplica en procesos adicionales
        //// MR: Actualizar para agregar nuevo comportami
        //// ento
        /////////////////////////////////////////////////
        [XmlIgnore]
        public int AddCodImpAdic
        {
            set { _CodImpAdics.Add(value); }
        }

        [XmlElement("CodImpAdic")]
        public List<int> CodImpAdics { get { return _CodImpAdics; } }


        /// <summary>
        /// #38 - Monto item
        /// </summary>
        /// <remarks>
        /// (Precio Unitario * Cantidad ) – Monto 
        /// Descuento + Monto Recargo 
        /// </remarks>
        /// <example>
        /// M Valor numérico, de acuerdo con descripción 
        /// y: 
        /// 1) Debe ser cero cuando: Indicador de facturación/ exención 
        /// tiene valor 4 o 5 Es una Nota de Crédito tipo fe de erratas.(Ver campo 
        /// Código de Referencia en Referencias) 
        /// 2) Puede ser cero cuando el documento es una Guía de despacho 
        /// NO VENTA (Según campo Indicador Tipo de traslado de bienes del 
        /// encabezado) 
        /// 3) En liquidaciones factura puede ser negativo. 
        /// CUANDO ES CERO PUEDE NO IMPRIMIRSE o Imprimirse un texto 
        /// explicatorio (s/valor, sin costo, etc)
        /// </example>
        public double MontoItem { get; set; }



    }

}
