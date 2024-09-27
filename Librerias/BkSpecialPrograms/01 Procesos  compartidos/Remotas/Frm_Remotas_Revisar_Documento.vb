'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_Remotas_Revisar_Documento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_DocEnc As Integer
    Dim _RowRemota As DataRow
    Dim _DsDocumento As New DataSet
    Dim _Funcionario_Revisa As String

    Dim _Tbl_Encabezado As New DataTable
    Dim _Tbl_Detalle As New DataTable

    Dim _RowEntidad As DataRow

    Dim _DocEn_Neto_Bruto As String
    Dim _NroRemota As String

    Dim _TotalNetoDoc, _
        _TotalIvaDoc, _
        _TotalIlaDoc, _
        _TotalBrutoDoc As Double

    Dim _Dscto_X_Linea_Porc_Permiso, _
        _Dscto_Global_Porc_Permiso As Double

    Dim _Dscto_Global As Double

    Dim _Mostrar_Margen As Boolean
    Dim _Mostrar_Costos As Boolean
    Dim _Permiso_Remoto As Boolean
    'Dim _Lista_Costo As String
    Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt

    Dim _Autorizar As Boolean
    Dim _Rechazar As Boolean
    Dim _Salir_Sin_Realizar_Gestion As Boolean
    Dim _Documento_Tomado As Boolean
    Dim _Row_Zw_Casi_DocTom As DataRow

    Enum Enum_Tipo_de_Permiso
        Descuentos
        Morosidad
    End Enum

    Dim _Enum_Tipo_de_Permiso As Enum_Tipo_de_Permiso

    Public ReadOnly Property Pro_Autorizado() As Boolean
        Get
            Return _Autorizar
        End Get
    End Property
    Public ReadOnly Property Pro_Rechazado() As Boolean
        Get
            Return _Rechazar
        End Get
    End Property
    Public ReadOnly Property Pro_Documento_Tomado() As Boolean
        Get
            Return _Documento_Tomado
        End Get
    End Property
    Public ReadOnly Property Pro_Row_Zw_Casi_DocTom() As DataRow
        Get
            Return _Row_Zw_Casi_DocTom
        End Get
    End Property

    Public Sub New(ByVal RowRemota As DataRow, _
                   ByVal Funcionario_Revisa As String, _
                   ByVal Tbl_Encabezado As DataTable, _
                   ByVal Tbl_Detalle As DataTable, _
                   ByVal Permiso_Remoto As Boolean, _
                   ByVal Tipo_Permiso As Enum_Tipo_de_Permiso)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Permiso_Remoto = Permiso_Remoto
        _RowRemota = RowRemota

        _Enum_Tipo_de_Permiso = Tipo_Permiso

        If Not (RowRemota Is Nothing) Then
            _Id_DocEnc = _RowRemota.Item("Id_Casi_DocEnc")
            _NroRemota = _RowRemota.Item("NroRemota")
        End If

        _Funcionario_Revisa = Funcionario_Revisa


        _Tbl_Encabezado = Tbl_Encabezado
        _Tbl_Detalle = Tbl_Detalle

        Dim _CodEntidad = _Tbl_Encabezado.Rows(0).Item("CodEntidad")
        Dim _CodSucEntidad = _Tbl_Encabezado.Rows(0).Item("CodSucEntidad")


        _RowEntidad = Fx_Traer_Datos_Entidad(_CodEntidad, _CodSucEntidad)

        Sb_Formato_Generico_Grilla(Grilla_Enc_Tot, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, False, False, False)
        Grilla_Enc_Tot.ScrollBars = ScrollBars.None
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 15, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, True, False, False)


        caract_combo(Cmb_Lista_Costo)
        Consulta_sql = "SELECT KOLT AS Padre,KOLT+' - '+MOLT+' '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'C'  ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        Cmb_Lista_Costo.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)
        Cmb_Lista_Costo.SelectedValue = "PM"

        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Grilla_Detalle_RowPostPaint

        If _Permiso_Remoto Then

            Dim _Id_Casi_DocEnc = _RowRemota.Item("Id_Casi_DocEnc")

            Consulta_sql = "Select *,(Select Top 1 NOKOFU From TABFU Where KOFU = CodFuncionario) As Funcionario" & vbCrLf & _
                           "From " & _Global_BaseBk & "Zw_Casi_DocTom Where Id_DocEnc = " & _Id_Casi_DocEnc
            _Row_Zw_Casi_DocTom = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_Row_Zw_Casi_DocTom Is Nothing) Then
                _Documento_Tomado = True
            End If

        End If

    End Sub

    Private Sub Frm_Remotas_Revisar_Documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Mostrar_Costos = Fx_Tiene_Permiso(Me, "Bkp00037", _Funcionario_Revisa, False)
        _Mostrar_Margen = Fx_Tiene_Permiso(Me, "Bkp00038", _Funcionario_Revisa, False)

        Sb_Actualizar_Grilla()
        Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)

        AddHandler Rdb_Costo_Lista.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Costo_PM.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Costo_Uc.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Grilla_Detalle.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown

        AddHandler Grilla_Enc_Tot.MouseDown, AddressOf Sb_Grilla_Encabezado_MouseDown

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        If _Permiso_Remoto Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Casi_DocTom (Id_DocEnc,CodFuncionario,Fecha_Hora,NombreEquipo) Values" & Space(1) & _
                           "(" & _Id_DocEnc & ",'" & FUNCIONARIO & "',Getdate(),'" & _NombreEquipo & "')" & vbCrLf & _
                           "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 0,Autorizado = 1,Rechazado = 1 Where NroRemota = '" & _NroRemota & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Private Sub Frm_Remotas_Revisar_Documento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        '_Tbl_Detalle.Columns.Remove("Total_Costo")
        '_Tbl_Detalle.Columns.Remove("Margen_Valor")
        '_Tbl_Detalle.Columns.Remove("Margen_Porc")

        If _Permiso_Remoto Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocTom Where Id_DocEnc = " & _Id_DocEnc & vbCrLf
            If _Salir_Sin_Realizar_Gestion Then
                Consulta_sql += "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 1,Autorizado = 0,Rechazado = 0 Where NroRemota = '" & _NroRemota & "'"
            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla_Enc_Tot

            .DataSource = _Tbl_Encabezado

            OcultarEncabezadoGrilla(Grilla_Enc_Tot, True)


            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").Width = 30
            .Columns("TipoDoc").HeaderText = "TD"
            .Columns("TipoDoc").DisplayIndex = 0
            .Columns("TipoDoc").ReadOnly = True

            .Columns("NroDocumento").Visible = True
            .Columns("NroDocumento").Width = 90
            .Columns("NroDocumento").HeaderText = "Número"
            .Columns("NroDocumento").DisplayIndex = 1
            .Columns("NroDocumento").ReadOnly = True

            .Columns("CodEntidad").Visible = True
            .Columns("CodEntidad").Width = 90
            .Columns("CodEntidad").HeaderText = "Entidad"
            .Columns("CodEntidad").DisplayIndex = 2
            .Columns("CodEntidad").ReadOnly = True

            .Columns("CodSucEntidad").Visible = True
            .Columns("CodSucEntidad").Width = 50
            .Columns("CodSucEntidad").HeaderText = "Suc."
            .Columns("CodSucEntidad").DisplayIndex = 3
            .Columns("CodSucEntidad").ReadOnly = True

            .Columns("Nombre_Entidad").Visible = True
            .Columns("Nombre_Entidad").Width = 220
            .Columns("Nombre_Entidad").HeaderText = "Razon social"
            .Columns("Nombre_Entidad").DisplayIndex = 4
            .Columns("Nombre_Entidad").ReadOnly = True

            .Columns("FechaEmision").Visible = True
            .Columns("FechaEmision").Width = 90
            .Columns("FechaEmision").HeaderText = "Fecha Em."
            .Columns("FechaEmision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaEmision").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaEmision").DisplayIndex = 5
            .Columns("FechaEmision").ReadOnly = False

            .Columns("FechaUltVencimiento").Visible = True
            .Columns("FechaUltVencimiento").Width = 90
            .Columns("FechaUltVencimiento").HeaderText = "Ult. Venci."
            .Columns("FechaUltVencimiento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaUltVencimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaUltVencimiento").DisplayIndex = 6
            .Columns("FechaUltVencimiento").ReadOnly = True

            .Columns("CodFuncionario").Visible = True
            .Columns("CodFuncionario").Width = 30
            .Columns("CodFuncionario").HeaderText = "Resp"
            .Columns("CodFuncionario").DisplayIndex = 7
            .Columns("CodFuncionario").ReadOnly = True

            ' .Columns("Sucursal").Visible = True
            '.Columns("Sucursal").Width = 30
            '.Columns("Sucursal").HeaderText = "Suc"
            '.Columns("Sucursal").DisplayIndex = 8
            '.Columns("Sucursal").ReadOnly = True

            '.Columns("TipoDoc").Visible = False
            '.Columns("Centro_Costo").Visible = True
            '.Columns("Centro_Costo").Width = 50
            '.Columns("Centro_Costo").HeaderText = "C.Costo"
            '.Columns("Centro_Costo").DisplayIndex = 9
            '.Columns("Centro_Costo").ReadOnly = True

            .Columns("ListaPrecios").Visible = True
            .Columns("ListaPrecios").Width = 50
            .Columns("ListaPrecios").HeaderText = "Lista"
            .Columns("ListaPrecios").DisplayIndex = 10
            .Columns("ListaPrecios").ReadOnly = True

            .Columns("Valor_Dolar").Visible = True
            .Columns("Valor_Dolar").Width = 50
            .Columns("Valor_Dolar").HeaderText = "T.Mon"
            .Columns("Valor_Dolar").DisplayIndex = 11
            .Columns("Valor_Dolar").ReadOnly = True

            '.Columns("CodEntidadFisica").Visible = True
            '.Columns("CodEntidadFisica").Width = 110
            '.Columns("CodEntidadFisica").HeaderText = "Ent.Despacho"
            '.Columns("CodEntidadFisica").DisplayIndex = 11
            '.Columns("CodEntidadFisica").ReadOnly = True

            '.Columns("Contacto_Ent").Visible = True
            '.Columns("Contacto_Ent").Width = 110
            '.Columns("Contacto_Ent").HeaderText = "Contacto"
            '.Columns("Contacto_Ent").DisplayIndex = 12
            '.Columns("Contacto_Ent").ReadOnly = True

            .Columns("Moneda_Doc").Visible = True
            .Columns("Moneda_Doc").Width = 40
            .Columns("Moneda_Doc").HeaderText = "Mon."
            .Columns("Moneda_Doc").DisplayIndex = 13
            .Columns("Moneda_Doc").ReadOnly = True

            ' .Columns("Modalidad").Visible = True
            ' .Columns("Modalidad").Width = 40
            ' .Columns("Modalidad").HeaderText = "Mod."
            ' .Columns("Modalidad").DisplayIndex = 11
            ' .Columns("Modalidad").ReadOnly = True

        End With

        _DocEn_Neto_Bruto = _Tbl_Encabezado.Rows(0).Item("DocEn_Neto_Bruto")

        With Grilla_Detalle

            .DataSource = _Tbl_Detalle

            Dim Total, Total_Str As String
            Dim FormatoPrecio As String
            Dim Precio_ As String
            Dim Precio_Campo As String

            If _DocEn_Neto_Bruto = "B" Then
                Total = "ValBrutoLinea"
                FormatoPrecio = "$ ###,##.##"
                Precio_Campo = "PrecioBrutoUdLista"
                Precio_ = "Precio Bruto "
                Total_Str = "Total"
            ElseIf _DocEn_Neto_Bruto = "N" Then
                Total = "ValNetoLinea"
                FormatoPrecio = "$ ###,##.###"
                Precio_ = "Precio Neto "
                Precio_Campo = "PrecioNetoUdLista"
                Total_Str = "Total"
            End If

            .RowTemplate.Height = 18
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _Mas = 0

            .Columns("Bodega").ReadOnly = True
            .Columns("Bodega").Width = 35
            .Columns("Bodega").HeaderText = "Bod"
            .Columns("Bodega").Visible = True
            .Columns("Bodega").Frozen = True
            .Columns("Bodega").DisplayIndex = 0

            .Columns("Lincondest").ReadOnly = True
            .Columns("Lincondest").Width = 20
            .Columns("Lincondest").HeaderText = "D"
            .Columns("Lincondest").Visible = True
            .Columns("Lincondest").Frozen = True
            .Columns("Lincondest").DisplayIndex = 1

            .Columns("Codigo").Width = 100 + _Mas
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").Frozen = True
            .Columns("Codigo").DisplayIndex = 2

            'If Not _Permiso_Remoto Then
            '.Columns("Descripcion").Width = 200 + _Mas
            '.Columns("Descripcion").HeaderText = "Descripción"
            '.Columns("Descripcion").Visible = True
            '.Columns("Descripcion").Frozen = True
            '.Columns("Descripcion").DisplayIndex = 3
            'End If

            .Columns("UdTrans").Width = 25
            .Columns("UdTrans").HeaderText = "UN"
            .Columns("UdTrans").ReadOnly = True
            .Columns("UdTrans").Visible = True
            .Columns("UdTrans").DisplayIndex = 4

            .Columns("Cantidad").Width = 60 + _Mas
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").DisplayIndex = 5

            .Columns(Precio_Campo).Width = 80 + _Mas '110 + _Mas
            .Columns(Precio_Campo).HeaderText = Precio_ & "(Lista)"
            .Columns(Precio_Campo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(Precio_Campo).DefaultCellStyle.Format = FormatoPrecio
            .Columns(Precio_Campo).Visible = True
            .Columns(Precio_Campo).DisplayIndex = 6

            .Columns("Precio").Width = 80 + _Mas '110 + _Mas
            .Columns("Precio").HeaderText = Precio_ & " (Dig.)"
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Format = FormatoPrecio
            .Columns("Precio").Visible = True
            .Columns("Precio").DisplayIndex = 7

            '.Columns("DescuentoPorc").Width = 50 + _Mas
            '.Columns("DescuentoPorc").HeaderText = "Desc %"
            '.Columns("DescuentoPorc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("DescuentoPorc").DefaultCellStyle.Format = "###,##.##"
            '.Columns("DescuentoPorc").Visible = True
            '.Columns("DescuentoPorc").DisplayIndex = 7

            '.Columns("DescuentoValor").Width = 70 + _Mas
            '.Columns("DescuentoValor").HeaderText = "Descuento"
            '.Columns("DescuentoValor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("DescuentoValor").DefaultCellStyle.Format = "$ ###,##"
            '.Columns("DescuentoValor").Visible = True
            '.Columns("DescuentoValor").DisplayIndex = 8

            .Columns("DsctoRealPorc").Width = 80 + _Mas
            .Columns("DsctoRealPorc").HeaderText = "Dscto Real %"
            .Columns("DsctoRealPorc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DsctoRealPorc").DefaultCellStyle.Format = "###,##.##"
            .Columns("DsctoRealPorc").Visible = True
            .Columns("DsctoRealPorc").DisplayIndex = 8

            '.Columns("DsctoRealValor").Width = 90 + _Mas
            '.Columns("DsctoRealValor").HeaderText = "Dscto Real $"
            '.Columns("DsctoRealValor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("DsctoRealValor").DefaultCellStyle.Format = "$ ###,##.##"
            '.Columns("DsctoRealValor").Visible = True
            '.Columns("DsctoRealValor").DisplayIndex = 9

            .Columns(Total).Width = 100 + _Mas
            .Columns(Total).HeaderText = Total_Str
            .Columns(Total).DefaultCellStyle.Format = "$ ###,##"
            .Columns(Total).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(Total).ReadOnly = True
            .Columns(Total).Visible = True
            '.Columns(Total).Frozen = True
            .Columns(Total).DisplayIndex = 10

            .Columns("ValNetoLinea").Width = 80 + _Mas
            .Columns("ValNetoLinea").HeaderText = "Total Neto $"
            .Columns("ValNetoLinea").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ValNetoLinea").DefaultCellStyle.Format = "###,##.##"
            .Columns("ValNetoLinea").Visible = True
            .Columns("ValNetoLinea").DisplayIndex = 11

            .Columns("Total_Costo").Width = 80 + _Mas
            .Columns("Total_Costo").HeaderText = "Total Costo $"
            .Columns("Total_Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Costo").DefaultCellStyle.Format = "###,##.##"
            .Columns("Total_Costo").Visible = _Mostrar_Costos
            .Columns("Total_Costo").DisplayIndex = 12

            .Columns("Margen_Valor").Width = 100 + _Mas
            .Columns("Margen_Valor").HeaderText = "Margen $"
            .Columns("Margen_Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Margen_Valor").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("Margen_Valor").Visible = _Mostrar_Margen
            .Columns("Margen_Valor").DisplayIndex = 13

            .Columns("Margen_Porc").Width = 70 + _Mas
            .Columns("Margen_Porc").HeaderText = "Mrg %"
            .Columns("Margen_Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Margen_Porc").DefaultCellStyle.Format = "% ###,##.###"
            .Columns("Margen_Porc").Visible = _Mostrar_Margen
            .Columns("Margen_Porc").DisplayIndex = 14


        End With

        _TotalNetoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalNetoDoc").Value
        _TotalIvaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIvaDoc").Value
        _TotalIlaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIlaDoc").Value
        _TotalBrutoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalBrutoDoc").Value

        If _DocEn_Neto_Bruto = "B" Then
            LblTotalNeto.Text = FormatCurrency(_TotalNetoDoc, 0)
            LblTotalIva.Text = FormatCurrency(_TotalIvaDoc, 0)
            LblTotalImpuestos.Text = FormatCurrency(_TotalIlaDoc, 0)
            LblTotalBruto.Text = FormatCurrency(_TotalBrutoDoc, 0)
        ElseIf _DocEn_Neto_Bruto = "N" Then
            LblTotalNeto.Text = FormatCurrency(_TotalNetoDoc, 0)
            LblTotalIva.Text = FormatCurrency(_TotalIvaDoc, 0)
            LblTotalImpuestos.Text = FormatCurrency(_TotalIlaDoc, 0)
            LblTotalBruto.Text = FormatCurrency(_TotalBrutoDoc, 0)
        End If

        Grupo_Margen_Porc.Visible = _Mostrar_Margen
        Grupo_Margen_Valor.Visible = _Mostrar_Margen

        Grupo_Metodo_Costeo.Enabled = _Mostrar_Costos
        Grupo_Total_Costo.Visible = _Mostrar_Costos


        If _Mostrar_Margen Then Btn_Mostrar_Margenes.Enabled = False
        If _Mostrar_Costos Then Btn_Ver_Costos.Enabled = False


    End Sub

    Sub Sb_Revisar_Margenes(ByVal _Lista_Costo As String)

        Dim _Total_Neto_Sdscto As Double
        Dim _Total_Bruto_Sdcto As Double

        Dim _Total_Dscto_Porc As Double
        Dim _Total_Dscto_Valor As Double

        Dim _Total_Neto As Double
        Dim _Total_Bruto As Double

        Dim _Sub_Total As Double

        Dim _Total_Margen_Porc, _Total_Margen_Valor, _Total_Costo As Double

        For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows

            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            Dim _Cantidad = _Fila.Cells("Cantidad").Value
            Dim _UnTrans = _Fila.Cells("UnTrans").Value
            Dim _Precio = _Fila.Cells("Precio").Value
            Dim _DescuentoPorc = _Fila.Cells("DescuentoPorc").Value
            Dim _DescuentoValor = _Fila.Cells("DescuentoValor").Value
            Dim _PrecioNetoUd = _Fila.Cells("PrecioNetoUd").Value
            Dim _PrecioNetoUdLista = _Fila.Cells("PrecioNetoUdLista").Value
            Dim _PrecioBrutoUd = _Fila.Cells("PrecioBrutoUd").Value
            Dim _PrecioBrutoUdLista = _Fila.Cells("PrecioBrutoUdLista").Value
            Dim _Rtu = _Fila.Cells("Rtu").Value

            Dim _Tict As String = Trim(NuloPorNro(_Fila.Cells("Tict").Value, ""))
            Dim _Tipr As String = Trim(NuloPorNro(_Fila.Cells("Tipr").Value, ""))
            Dim _Prct As Boolean = _Fila.Cells("Prct").Value

            Dim _PrecioNetoRealUd1 = _Fila.Cells("PrecioNetoRealUd1").Value
            Dim _PrecioNetoRealUd2 = _Fila.Cells("PrecioNetoRealUd2").Value

            Dim _Tiene_Dscto As Boolean = _Fila.Cells("Tiene_Dscto").Value

            Dim _CodLista = _Fila.Cells("CodLista").Value
            Dim _DescMaximo = _Fila.Cells("DescMaximo").Value
            Dim _PorIva = _Fila.Cells("PorIva").Value
            Dim _PorIla = _Fila.Cells("PorIla").Value
            Dim _ValNetoLinea = _Fila.Cells("ValNetoLinea").Value
            Dim _ValBrutoLinea = _Fila.Cells("ValBrutoLinea").Value

            Dim _PmLinea = _Fila.Cells("PmLinea").Value
            Dim _PmSucLinea = _Fila.Cells("PmSucLinea").Value

            Dim _UltCompraLinea As Double
            Dim _Costo_Lista As Double

            Dim _i = 1

            If String.IsNullOrEmpty(_Tict) And Not String.IsNullOrEmpty(_Tipr) And Not _Prct Then
                _UltCompraLinea = _Sql.Fx_Trae_Dato("MAEPREM", "PPUL0" & _UnTrans, _
                                                    "EMPRESA = '" & ModEmpresa & "' AND KOPR = '" & _Codigo & "'")
                _Costo_Lista = _Sql.Fx_Trae_Dato("TABPRE", "PP0" & _UnTrans & "UD", _
                                                 "KOLT = '" & _Lista_Costo & "' And KOPR = '" & _Codigo & "'", True)
            ElseIf _Tict = "D" Then
                _i = 0
            End If


            Dim _Costo As Double

            If Rdb_Costo_PM.Checked Then

                If _UnTrans = 1 Then
                    _Costo = _PmLinea
                Else
                    _Costo = _PmLinea * _Rtu
                End If

            ElseIf Rdb_Costo_Uc.Checked Then
                _Costo = _UltCompraLinea
            ElseIf Rdb_Costo_Lista.Checked Then
                _Costo = _Costo_Lista
            End If

            Dim _Total_Costo_Linea As Double = _Costo * _Cantidad
            Dim _Margen_Porc, _Margen_Valor As Double

            If Math.Round(_PrecioNetoUd, 2) < Math.Round(_PrecioNetoUdLista, 2) Then
                _Fila.Cells("Precio").Style.ForeColor = Color.Red
            End If

            If _Tiene_Dscto Then
                _Fila.Cells("DescuentoPorc").Style.ForeColor = Color.Red
                _Fila.Cells("DescuentoValor").Style.ForeColor = Color.Red
                _Fila.Cells("DsctoRealPorc").Style.ForeColor = Color.Red
                _Fila.Cells("DsctoRealValor").Style.ForeColor = Color.Red
            End If

            'If _DocEn_Neto_Bruto = "N" Then
            _Margen_Valor = (_ValNetoLinea - _Total_Costo_Linea) * _i
            _Margen_Porc = ((_ValNetoLinea - _Total_Costo_Linea) / _ValNetoLinea) * _i

            'ElseIf _DocEn_Neto_Bruto = "B" Then
            '_Margen = (_ValBrutoLinea - _Total_Costo_Linea) / _ValBrutoLinea
            'End If

            'Total_Costo,CAST( 0 AS Float) AS Margen_Porc
            _Fila.Cells("Total_Costo").Value = _Total_Costo_Linea
            _Fila.Cells("Margen_Valor").Value = _Margen_Valor
            _Fila.Cells("Margen_Porc").Value = _Margen_Porc


            Dim _DsctoRealPorc = _Fila.Cells("DsctoRealPorc").Value


            _Total_Neto += _ValNetoLinea
            _Total_Bruto += _ValBrutoLinea

            _Total_Neto_Sdscto += _PrecioNetoUdLista * _Cantidad
            _Total_Bruto_Sdcto += _PrecioBrutoUdLista * _Cantidad


            _Total_Costo += _Total_Costo_Linea

            If _Margen_Valor < 0 Then
                _Fila.Cells("Margen_Valor").Style.ForeColor = Color.Red
                _Fila.Cells("Margen_Porc").Style.ForeColor = Color.Red
            Else
                _Fila.Cells("Margen_Valor").Style.ForeColor = Color.Green
                _Fila.Cells("Margen_Porc").Style.ForeColor = Color.Green
            End If

        Next

        '_TotalNetoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalNetoDoc").Value
        '_TotalIvaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIvaDoc").Value
        '_TotalIlaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIlaDoc").Value
        '_TotalBrutoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalBrutoDoc").Value

        'If _DocEn_Neto_Bruto = "N" Then
        _Total_Margen_Porc = (_Total_Neto - _Total_Costo) / _Total_Neto
        _Total_Margen_Valor = _Total_Neto - _Total_Costo

        If _DocEn_Neto_Bruto = "B" Then
            _Total_Dscto_Valor = _Total_Bruto_Sdcto - _Total_Bruto
            _Total_Dscto_Porc = _Total_Dscto_Valor / _Total_Bruto_Sdcto
            _Sub_Total = _Total_Bruto_Sdcto
            Grupo_SubTotal.Text = "Sub Total Bruto"
        ElseIf _DocEn_Neto_Bruto = "N" Then
            _Total_Dscto_Valor = _Total_Neto_Sdscto - _Total_Neto
            _Total_Dscto_Porc = _Total_Dscto_Valor / _Total_Neto_Sdscto
            _Sub_Total = _Total_Neto_Sdscto
            Grupo_SubTotal.Text = "Sub Total Neto"
        End If

        'ElseIf _DocEn_Neto_Bruto = "B" Then
        '_Total_Margen_Porc = (_Total_Bruto - _Total_Costo) / _Total_Bruto
        '_Total_Margen_Valor = _Total_Bruto - _Total_Costo
        'End If

        _Dscto_Global = Math.Round(_Total_Dscto_Porc, 4)

        Lbl_Total_Dscto_Porcentaje.Text = FormatPercent(_Total_Dscto_Porc, 2)
        Lbl_Total_Dscto_Valor.Text = FormatCurrency(_Total_Dscto_Valor, 0)
        Lbl_Sub_Total.Text = FormatCurrency(_Sub_Total, 0)

        Lbl_Total_Margen_Valor.Text = FormatCurrency(_Total_Margen_Valor, 0)
        Lbl_Total_Margen_Porcentaje.Text = FormatPercent(_Total_Margen_Porc, 2)
        Lbl_Total_Costo.Text = FormatCurrency(_Total_Costo, 0)

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Salir_Sin_Realizar_Gestion = True
        Me.Close()
    End Sub

    Private Sub Grilla_Detalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEnter

        Dim _Descripcion = String.Empty

        Try
            Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)
            _Descripcion = _Fila.Cells("Descripcion").Value
        Catch ex As Exception
        Finally
            TxtObservacion_Linea.Text = _Descripcion
        End Try

    End Sub


    Private Sub Btn_Rechazar_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Rechazar_Documento.Click

        Dim _Aceptado As Boolean
        Dim _Observaciones As String

        _Aceptado = InputBox_Bk(Me, "Ingrese motivo del rechazo", "Solicitud rechazada", _Observaciones, True,
                                            _Tipo_Mayus_Minus.Mayusculas, 200, True, _Tipo_Imagen.Texto,
                                            False, _Tipo_Caracter.Cualquier_caracter)

        If _Aceptado Then

            _Rechazar = True

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf &
                           "CodFuncionario_Autoriza = '" & _Funcionario_Revisa & "',Otorga = 'Rechazado'," & vbCrLf &
                           "Observaciones = '" & _Observaciones & "',Fecha_Otorga = GetDate()" & vbCrLf &
                           "Where NroRemota = '" & _NroRemota & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Me.Close()

        End If

    End Sub

    Private Sub Btn_Aceptar_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar_Documento.Click

        If _Enum_Tipo_de_Permiso = Enum_Tipo_de_Permiso.Descuentos Then
            Sb_Autorizar_X_Descuentos()
        ElseIf _Enum_Tipo_de_Permiso = Enum_Tipo_de_Permiso.Morosidad Then
            Sb_Perimiso_Deuda_Pendiente()
        End If

    End Sub

    Sub Sb_Autorizar_X_Descuentos()

        Dim _Otorga = "Autorizado"

        Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf & _
                       "Where CodUsuario = '" & _Funcionario_Revisa & "' And CodPermiso = 'Bkp00039'"
        Dim _Row_Permisos As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Row_Permisos Is Nothing) Then

            Dim _Valor_Dscto As Double = Math.Round(_Row_Permisos.Item("Valor_Dscto") / 100, 4)

            If _Valor_Dscto >= _Dscto_Global Then

                If _Permiso_Remoto Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf & _
                                   "CodFuncionario_Autoriza = '" & _Funcionario_Revisa & "',Permiso_Otorgado = 1," & vbCrLf & _
                                   "Otorga = '" & _Otorga & "',Fecha_Otorga = GetDate()" & vbCrLf & _
                                   "Where NroRemota = '" & _NroRemota & "'" & vbCrLf & _
                                   "Update " & _Global_BaseBk & "Zw_Casi_DocDet Set CodFunAutoriza = '" & _Funcionario_Revisa & "'" & vbCrLf & _
                                   "Where Id_DocEnc = " & _Id_DocEnc
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                _Autorizar = True

                Me.Close()

            Else

                MessageBoxEx.Show(Me, "Descuento global según documento " & Lbl_Total_Dscto_Porcentaje.Text & vbCrLf & _
                                  "Descuento máximo permitido para el usuario: " & FormatPercent(_Valor_Dscto, 2), _
                                  "PERMISO DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        Else
            MessageBoxEx.Show(Me, "Usted no posee permiso para realizar esta acción" & vbCrLf & _
                              "Permiso Nro: Bkp00039", "Validación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Sub Sb_Perimiso_Deuda_Pendiente()

        _Autorizar = True

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf & _
                       "CodFuncionario_Autoriza = '" & FUNCIONARIO & "',Permiso_Otorgado = 1," & vbCrLf & _
                       "Otorga = 'Autorizado',Fecha_Otorga = GetDate()" & vbCrLf & _
                       "Where NroRemota = '" & _NroRemota & "'" & vbCrLf & _
                       "Update " & _Global_BaseBk & "Zw_Casi_DocEnc Set Funcionario_Autoriza_Deuda_Vencida = '" & FUNCIONARIO & "'" & vbCrLf & _
                       "Where Id_DocEnc = " & _Id_DocEnc
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Me.Close()

    End Sub

    Function Fx_Revisar_Permiso_Descuento(ByVal _Formulario As Form, _
                                          ByVal _Funcionario_Revisa As String, _
                                          ByVal _TblDetalle As DataTable) As Boolean

        _Dscto_X_Linea_Porc_Permiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosVsUsuarios", "Valor_Dscto", _
                                      "CodPermiso = 'Bkp00014' And CodUsuario = '" & _Funcionario_Revisa & "'")

        _Dscto_Global_Porc_Permiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosVsUsuarios", "Valor_Dscto",
                                      "CodPermiso = 'Bkp00039' And CodUsuario = '" & _Funcionario_Revisa & "'")


        Dim _Total_Neto_Sdscto As Double
        Dim _Total_Bruto_Sdcto As Double

        Dim _Total_Dscto_Porc As Double
        Dim _Total_Dscto_Valor As Double

        Dim _Total_Neto As Double
        Dim _Total_Bruto As Double

        Dim _Sub_Total As Double

        Dim _Total_Margen_Porc, _Total_Margen_Valor, _Total_Costo As Double

        For Each _Fila As DataRow In _TblDetalle.Rows 'Grilla_Detalle.Rows

            Dim _Codigo As String = _Fila.Item("Codigo")

            Dim _Cantidad = _Fila.Item("Cantidad")
            Dim _UnTrans = _Fila.Item("UnTrans")
            Dim _Precio = _Fila.Item("Precio")
            Dim _DescuentoPorc = _Fila.Item("DescuentoPorc")
            Dim _DescuentoValor = _Fila.Item("DescuentoValor")
            Dim _PrecioNetoUd = _Fila.Item("PrecioNetoUd")
            Dim _PrecioNetoUdLista = _Fila.Item("PrecioNetoUdLista")
            Dim _PrecioBrutoUd = _Fila.Item("PrecioBrutoUd")
            Dim _PrecioBrutoUdLista = _Fila.Item("PrecioBrutoUdLista")
            Dim _Rtu = _Fila.Item("Rtu")

            Dim _PrecioNetoRealUd1 = _Fila.Item("PrecioNetoRealUd1")
            Dim _PrecioNetoRealUd2 = _Fila.Item("PrecioNetoRealUd2")

            Dim _Tiene_Dscto As Boolean = _Fila.Item("Tiene_Dscto")

            Dim _CodLista = _Fila.Item("CodLista")
            Dim _DescMaximo = _Fila.Item("DescMaximo")
            Dim _PorIva = _Fila.Item("PorIva")
            Dim _PorIla = _Fila.Item("PorIla")
            Dim _ValNetoLinea = _Fila.Item("ValNetoLinea")
            Dim _ValBrutoLinea = _Fila.Item("ValBrutoLinea")

            Dim _PmLinea = _Fila.Item("PmLinea")
            Dim _PmSucLinea = _Fila.Item("PmSucLinea")

            'Dim _UltCompraLinea As Double = _Sql.Fx_Trae_Dato(, "PPUL0" & _UnTrans, "MAEPREM", _
            '                                          "EMPRESA = '" & ModEmpresa & "' AND KOPR = '" & _Codigo & "'")
            'Dim _Costo_Lista As Double = _Sql.Fx_Trae_Dato(, "PP0" & _UnTrans & "UD", _
            '                                       "TABPRE", "KOLT = '" & _Lista_Costo & "' And KOPR = '" & _Codigo & "'", True)

            Dim _Costo As Double

            'If Rdb_Costo_PM.Checked Then

            'If _UnTrans = 1 Then
            '_Costo = _PmLinea
            'Else
            '_Costo = _PmLinea * _Rtu
            'End If

            'ElseIf Rdb_Costo_Uc.Checked Then
            '_Costo = _UltCompraLinea
            'ElseIf Rdb_Costo_Lista.Checked Then
            '_Costo = _Costo_Lista
            'End If

            Dim _Total_Costo_Linea As Double = _Costo * _Cantidad
            Dim _Margen_Porc, _Margen_Valor As Double

            If _PrecioNetoUd < _PrecioNetoUdLista Then
                _Fila.Item("Precio").Style.ForeColor = Color.Red
            End If

            If _Tiene_Dscto Then
                _Fila.Item("DescuentoPorc").Style.ForeColor = Color.Red
                _Fila.Item("DescuentoValor").Style.ForeColor = Color.Red
                _Fila.Item("DsctoRealPorc").Style.ForeColor = Color.Red
                _Fila.Item("DsctoRealValor").Style.ForeColor = Color.Red
            End If

            'If _DocEn_Neto_Bruto = "N" Then
            _Margen_Valor = _ValNetoLinea - _Total_Costo_Linea
            _Margen_Porc = (_ValNetoLinea - _Total_Costo_Linea) / _ValNetoLinea
            'ElseIf _DocEn_Neto_Bruto = "B" Then
            '_Margen = (_ValBrutoLinea - _Total_Costo_Linea) / _ValBrutoLinea
            'End If

            'Total_Costo,CAST( 0 AS Float) AS Margen_Porc
            _Fila.Item("Total_Costo") = _Total_Costo_Linea
            _Fila.Item("Margen_Valor") = _Margen_Valor
            _Fila.Item("Margen_Porc") = _Margen_Porc

            Dim _DsctoRealPorc = _Fila.Item("DsctoRealPorc")

            _Total_Neto += _ValNetoLinea
            _Total_Bruto += _ValBrutoLinea

            _Total_Neto_Sdscto += _PrecioNetoUdLista * _Cantidad
            _Total_Bruto_Sdcto += _PrecioBrutoUdLista * _Cantidad


            _Total_Costo += _Total_Costo_Linea

            If _Margen_Valor < 0 Then
                _Fila.Item("Margen_Valor").Style.ForeColor = Color.Red
                _Fila.Item("Margen_Porc").Style.ForeColor = Color.Red
            Else
                _Fila.Item("Margen_Valor").Style.ForeColor = Color.Green
                _Fila.Item("Margen_Porc").Style.ForeColor = Color.Green
            End If

        Next

        '_TotalNetoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalNetoDoc").Value
        '_TotalIvaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIvaDoc").Value
        '_TotalIlaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIlaDoc").Value
        '_TotalBrutoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalBrutoDoc").Value

        'If _DocEn_Neto_Bruto = "N" Then
        _Total_Margen_Porc = (_Total_Neto - _Total_Costo) / _Total_Neto
        _Total_Margen_Valor = _Total_Neto - _Total_Costo

        If _DocEn_Neto_Bruto = "B" Then
            _Total_Dscto_Valor = _Total_Bruto_Sdcto - _Total_Bruto
            _Total_Dscto_Porc = _Total_Dscto_Valor / _Total_Bruto_Sdcto
            _Sub_Total = _Total_Bruto_Sdcto
            Grupo_SubTotal.Text = "Sub Total Bruto"
        ElseIf _DocEn_Neto_Bruto = "N" Then
            _Total_Dscto_Valor = _Total_Neto_Sdscto - _Total_Neto
            _Total_Dscto_Porc = _Total_Dscto_Valor / _Total_Neto_Sdscto
            _Sub_Total = _Total_Neto_Sdscto
            Grupo_SubTotal.Text = "Sub Total Neto"
        End If

        'ElseIf _DocEn_Neto_Bruto = "B" Then
        '_Total_Margen_Porc = (_Total_Bruto - _Total_Costo) / _Total_Bruto
        '_Total_Margen_Valor = _Total_Bruto - _Total_Costo
        'End If

        _Dscto_Global = _Total_Dscto_Porc

        Lbl_Total_Dscto_Porcentaje.Text = FormatPercent(_Total_Dscto_Porc, 2)
        Lbl_Total_Dscto_Valor.Text = FormatCurrency(_Total_Dscto_Valor, 2)
        Lbl_Sub_Total.Text = FormatCurrency(_Sub_Total, 2)

        Lbl_Total_Margen_Valor.Text = FormatCurrency(_Total_Margen_Valor, 3)
        Lbl_Total_Margen_Porcentaje.Text = FormatPercent(_Total_Margen_Porc, 2)
        Lbl_Total_Costo.Text = FormatCurrency(_Total_Costo, 2)

    End Function

    Private Sub Frm_Remotas_Revisar_Documento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Salir_Sin_Realizar_Gestion = True
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Ver_Costos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Costos.Click

        If Fx_Tiene_Permiso(Me, "Bkp00037", _Funcionario_Revisa) Then

            _Mostrar_Costos = True

            Sb_Actualizar_Grilla()
            Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)

        End If

    End Sub

    Private Sub Sb_Lista_Costo_SelectedIndexChanged()
        Sb_Actualizar_Grilla()
        Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)
    End Sub

    Private Sub Btn_Mostrar_Margenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mostrar_Margenes.Click

        If Fx_Tiene_Permiso(Me, "Bkp00038", _Funcionario_Revisa) Then

            _Mostrar_Margen = True

            Sb_Actualizar_Grilla()
            Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)

        End If

    End Sub

    Private Sub Sb_Rdb_CheckedChanged()
        Sb_Actualizar_Grilla()
        Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)
    End Sub

    Private Sub Sb_Grilla_Encabezado_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Info_Entidad)
                End If
            End With
        End If
    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Productos)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Dim _Endo As String = _Tbl_Encabezado.Rows(0).Item("CodEntidad")
        Dim _Tido As String = _Tbl_Encabezado.Rows(0).Item("TipoDoc")
        Dim _Tipotransa As String = _Sql.Fx_Trae_Dato("TABTIDO", "TIPOTRANSA", "TIDO = '" & _Tido & "'")

        If _Tipotransa = "C" Then
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Compra)
        ElseIf _Tipotransa = "V" Then
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)
        Else
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
        End If

    End Sub

    Private Sub Grilla_Detalle_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net", _
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Mnu_Ficha_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ficha_Entidad.Click
        If Fx_Tiene_Permiso(Me, "CfEnt001", _Funcionario_Revisa) Then 'If Fx_Tiene_Permiso(Me, "CfEnt001") Then

            Dim _Koen = _Tbl_Encabezado.Rows(0).Item("CodEntidad")
            Dim _Suen = _Tbl_Encabezado.Rows(0).Item("CodSucEntidad")

            Dim Fm As New Frm_Crear_Entidad_Mt
            Fm.Fx_Llenar_Entidad(_Koen, _Suen)
            Fm.CrearEntidad = False
            Fm.EditarEntidad = True
            Fm.ShowDialog(Me)

            If Fm.Grabar Then
                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button, _
                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If

            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Ver_Situacion_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Situacion_Cliente.Click
        If Fx_Tiene_Permiso(Me, "Inf00018", _Funcionario_Revisa) Then
            Dim Fm As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad, 0, 0, 0, 0, True)
            Fm.Btn_CambCodPago.Visible = False
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Info_Plana_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Info_Plana_Entidad.Click
        If Not (_RowEntidad Is Nothing) Then
            Dim Fm As New Frm_InfoEnt_Informacion_General(_RowEntidad)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        Else
            MessageBoxEx.Show(Me, "Falta el entidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Btn_Ver_Comportamiento_De_Pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Comportamiento_De_Pago.Click
        If Fx_Tiene_Permiso(Me, "Inf00018", _Funcionario_Revisa) Then 'If Fx_Tiene_Permiso(Me, "Inf00018") Then
            Dim Fm As New Frm_Infor_Ent_Comportamiento_De_Pago
            Fm.Pro_RowEntidad = _RowEntidad '_TblEntidad.Rows(0)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Ver_Documentos_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documentos_Pendientes.Click
        If Fx_Tiene_Permiso(Me, "Inf00018", _Funcionario_Revisa) Then 'If Fx_Tiene_Permiso(Me, "Inf00018") Then
            Dim _Koen = _Tbl_Encabezado.Rows(0).Item("CodEntidad")
            Dim _Suen = _Tbl_Encabezado.Rows(0).Item("CodSucEntidad")

            Sb_Ver_Deuda_Pendiente(_Koen, _Suen, False)
        End If
    End Sub

    Private Sub Btn_Ver_Cheques_En_Cartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Cheques_En_Cartera.Click
        If Fx_Tiene_Permiso(Me, "Inf00018", _Funcionario_Revisa) Then 'If Fx_Tiene_Permiso(Me, "Inf00018") Then
            Dim _Koen = _Tbl_Encabezado.Rows(0).Item("CodEntidad")
            Dim _Suen = _Tbl_Encabezado.Rows(0).Item("CodSucEntidad")
            Dim _Nokoen = _Tbl_Encabezado.Rows(0).Item("Nombre_Entidad")

            Dim Fm As New Frm_Infor_Cheques_En_Cartera_X_Clientes
            Fm.Pro_Filtro_Entidad = _Koen
            Fm.Text = "Cheques en cartera entidad: " & _Nokoen
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Ver_Deuda_Total_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Deuda_Total.Click
        If Fx_Tiene_Permiso(Me, "Inf00018", _Funcionario_Revisa) Then 'If Fx_Tiene_Permiso(Me, "Inf00018") Then
            Dim _Koen = _Tbl_Encabezado.Rows(0).Item("CodEntidad")
            Dim _Suen = _Tbl_Encabezado.Rows(0).Item("CodSucEntidad")

            Sb_Ver_Deuda_Pendiente(_Koen, _Suen, True)
        End If
    End Sub

    Sub Sb_Ver_Deuda_Pendiente(ByVal _Koen As String, _
                                   ByVal _Suen As String, _
                                   ByVal _Deuda_Efectiva As Boolean)


        Dim _Fx_Fecha_Inicio = "19000101"
        Dim _Fx_Fecha_Fin = "22001231"

        Dim _Filtro_Maeedo = "EDO.ENDO = '" & _Koen & "' AND EDO.SUENDO = '" & _Suen & "' AND"
        Dim _Filtro_Maedpce = "And DPCE.ENDP = '" & _Koen & "'"

        Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf

        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos(_Koen, _Suen, Consulta_sql, _
                                                      _Fx_Fecha_Inicio, _Fx_Fecha_Fin, _
                                                      Frm_Inf_Vencimientos_Detalle_Documentos.Accion.Mostrar_todo, _
                                                      0, Frm_Inf_Vencimientos_Detalle_Documentos.Tipo_Informe.Ventas)

        Fm.Pro_Mover_Fechas = False
        Fm.Pro_Chk_Deuda_Efectiva = _Deuda_Efectiva

        Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
        Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce
        Fm.Pro_Solo_Cheques = True
        Fm.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = False
        Fm.Chk_Mostrar_Pagos_Pendientes.Visible = False
        Fm.Sb_Generar_Informe()

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Info_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Info_Entidad.Click
        ShowContextMenu(Menu_Contextual_Info_Entidad)
    End Sub

End Class