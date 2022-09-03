Imports DevComponents.DotNetBar

Public Class Frm_Remotas_Analisi_Dscto_X_Documento_Rd

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Idmaeedo As Integer
    Dim _Cadena_ConexionSQL_Server_Remotas As String
    Dim _Row_Funcionario As DataRow

    Dim _Ds_Documento As DataSet
    Dim _Row_Encabezado As DataRow
    Dim _Tbl_Detalle As DataTable
    Dim _Row_Maeen As DataRow

    Dim _Row_Tabremot As DataRow
    Dim _Tabla_Enc, _Tabla_Det As String
    Dim _Aceptado As Boolean
    Dim _Rechazado As Boolean

    Dim _Kofu As String
    Dim _Nuremot As String
    Dim _Ipotorga As String

    Dim _Dscto_Global As Double
    Dim _Exite_Documento As Boolean

    Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt

    Dim _Tabla As Enum_Tabla
    Enum Enum_Tabla
        Maeedo
        Kasiedo
    End Enum

    Public ReadOnly Property Pro_Existe_Documento() As String
        Get
            Return _Exite_Documento
        End Get
    End Property
    Public ReadOnly Property Pro_Aceptado() As Boolean
        Get
            Return _Aceptado
        End Get
    End Property
    Public ReadOnly Property Pro_Rechazado() As Boolean
        Get
            Return _Rechazado
        End Get
    End Property
    Public ReadOnly Property Pro_Row_Encabezado() As DataRow
        Get
            Return _Row_Encabezado
        End Get
    End Property

    Public Sub New(Cadena_ConexionSQL_Server_Remotas As String,
                   Row_Tabremot As DataRow,
                   Row_Funcionario As DataRow,
                   Tabla As Enum_Tabla,
                   Id As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Cadena_ConexionSQL_Server_Remotas = Cadena_ConexionSQL_Server_Remotas
        _Sql = New Class_SQL(_Cadena_ConexionSQL_Server_Remotas)

        _Tabla = Tabla
        _Ipotorga = Mid(getIp(), 1, 15)

        If _Tabla = Enum_Tabla.Kasiedo Then

            _Row_Tabremot = Row_Tabremot
            _Row_Funcionario = Row_Funcionario

            _Tabla_Enc = "KASIEDO"
            _Tabla_Det = "KASIDDO"
            _Idmaeedo = _Row_Tabremot.Item("NUDOKASI")

        ElseIf _Tabla = Enum_Tabla.Maeedo Then

            _Tabla_Enc = "MAEEDO"
            _Tabla_Det = "MAEDDO"
            _Idmaeedo = Id

            Btn_Aceptar.Visible = False
            Btn_Rechazar.Visible = False

            Sb_Formato_Generico_Grilla(Grilla_Enc_Tot, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, False, False, False)
            Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.LightYellow, ScrollBars.Vertical, True, False, False)

            Me.Text = "REVISION DE SITUACION COMERCIAL DE DOCUMENTO"

        End If

        Sb_Cargar_Documento()

        caract_combo(Cmb_Lista_Costo)
        Consulta_Sql = "SELECT KOLT AS Padre,KOLT+' - '+MOLT+' '+NOKOLT AS Hijo FROM TABPP WHERE TILT = 'C'  ORDER BY Hijo" ' WHERE SEMILLA = " & Actividad
        Dim _TblListas As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)
        Cmb_Lista_Costo.DataSource = _TblListas
        Cmb_Lista_Costo.SelectedValue = _TblListas.Rows(0).Item("Padre")

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Remotas_Analisi_Dscto_X_Documento_Rd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()
        Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)

        AddHandler Rdb_Costo_Lista.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Costo_PM.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Costo_Uc.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Costo_PM_Documento.CheckedChanged, AddressOf Rdb_CheckedChanged

        AddHandler Grilla_Detalle.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Cargar_Documento()

        Consulta_Sql = "Select *," &
                       "Isnull((Select Top 1 NOKOEN From MAEEN Where KOEN = ENDO And SUEN = SUENDO),'') As RAZON" & vbCrLf &
                       "From " & _Tabla_Enc & " Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "Select *,CASE PRCT WHEN 1 THEN 0 ELSE CASE WHEN UDTRPR = 1 THEN CAPRCO1 ELSE CAPRCO2 END END AS CANTIDAD," &
                       "CASE WHEN UDTRPR = 1 THEN UD01PR ELSE UD02PR END AS UD," &
                       "CAST(PODTGLLI/100.0 AS Float) AS DSCTO," & vbCrLf &
                       "CAST(PODTGLLI/100.0 AS Float) AS DSCTO_REAL" & vbCrLf &
                       "From " & _Tabla_Det & " Where IDMAEEDO = " & _Idmaeedo

        _Ds_Documento = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _Exite_Documento = CBool(_Ds_Documento.Tables(0).Rows.Count)

        If _Exite_Documento Then

            _Row_Encabezado = _Ds_Documento.Tables(0).Rows(0)
            _Tbl_Detalle = _Ds_Documento.Tables(1)

            _Tbl_Detalle.Columns.Add("Total_Costo", System.Type.[GetType]("System.Double"))
            _Tbl_Detalle.Columns.Add("Margen_Valor", System.Type.[GetType]("System.Double"))
            _Tbl_Detalle.Columns.Add("Margen_Porc", System.Type.[GetType]("System.Double"))

            Dim _Koen = _Row_Encabezado.Item("ENDO")
            Dim _Suen = _Row_Encabezado.Item("SUENDO")

            Consulta_Sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
            _Row_Maeen = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If _Tabla = Enum_Tabla.Kasiedo Then
                _Kofu = _Row_Tabremot.Item("KOFU")
                _Nuremot = _Row_Tabremot.Item("NUREMOT")

                Consulta_Sql = "UPDATE TABREMOT SET KOFUAUTO='',OTORGA='',IPOTORGA=''" & vbCrLf &
                           "WHERE KOFU='" & _Kofu & "' AND NUREMOT = '" & _Nuremot & "'"
            End If

        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        With Grilla_Enc_Tot

            .DataSource = _Ds_Documento.Tables(0)

            OcultarEncabezadoGrilla(Grilla_Enc_Tot, True)

            .Columns("TIDO").Visible = True
            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").DisplayIndex = 0
            .Columns("TIDO").ReadOnly = True

            If _Tabla = Enum_Tabla.Maeedo Then
                .Columns("NUDO").Visible = True
                .Columns("NUDO").Width = 90
                .Columns("NUDO").HeaderText = "Número"
                .Columns("NUDO").DisplayIndex = 1
                .Columns("NUDO").ReadOnly = True
            End If

            .Columns("ENDO").Visible = True
            .Columns("ENDO").Width = 90
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").DisplayIndex = 2
            .Columns("ENDO").ReadOnly = True

            .Columns("SUENDO").Visible = True
            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").DisplayIndex = 3
            .Columns("SUENDO").ReadOnly = True

            .Columns("RAZON").Visible = True
            .Columns("RAZON").Width = 400
            .Columns("RAZON").HeaderText = "Razon social"
            .Columns("RAZON").DisplayIndex = 4
            .Columns("RAZON").ReadOnly = True

            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").Width = 90
            .Columns("FEEMDO").HeaderText = "Fecha Em."
            .Columns("FEEMDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDO").DisplayIndex = 5
            .Columns("FEEMDO").ReadOnly = False

            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").Width = 90
            .Columns("FEULVEDO").HeaderText = "Ult. Venci."
            .Columns("FEULVEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEULVEDO").DisplayIndex = 6
            .Columns("FEULVEDO").ReadOnly = True

            .Columns("KOFUDO").Visible = True
            .Columns("KOFUDO").Width = 30
            .Columns("KOFUDO").HeaderText = "Resp"
            .Columns("KOFUDO").DisplayIndex = 7
            .Columns("KOFUDO").ReadOnly = True

            ' .Columns("Sucursal").Visible = True
            '.Columns("Sucursal").Width = 30
            '.Columns("Sucursal").HeaderText = "Suc"
            '.Columns("Sucursal").DisplayIndex = 8
            '.Columns("Sucursal").ReadOnly = True

            '.Columns("TIDO").Visible = False
            '.Columns("Centro_Costo").Visible = True
            '.Columns("Centro_Costo").Width = 50
            '.Columns("Centro_Costo").HeaderText = "C.Costo"
            '.Columns("Centro_Costo").DisplayIndex = 9
            '.Columns("Centro_Costo").ReadOnly = True
            Try
                .Columns("LISACTIVA").Visible = True
                .Columns("LISACTIVA").Width = 60
                .Columns("LISACTIVA").HeaderText = "Lista"
                .Columns("LISACTIVA").DisplayIndex = 20
                .Columns("LISACTIVA").ReadOnly = True
            Catch ex As Exception

            End Try


            .Columns("TAMODO").Visible = True
            .Columns("TAMODO").Width = 50
            .Columns("TAMODO").HeaderText = "T.Mon"
            .Columns("TAMODO").DisplayIndex = 11
            .Columns("TAMODO").ReadOnly = True

            '.Columns("ENDOFisica").Visible = True
            '.Columns("ENDOFisica").Width = 110
            '.Columns("ENDOFisica").HeaderText = "Ent.Despacho"
            '.Columns("ENDOFisica").DisplayIndex = 11
            '.Columns("ENDOFisica").ReadOnly = True

            '.Columns("Contacto_Ent").Visible = True
            '.Columns("Contacto_Ent").Width = 110
            '.Columns("Contacto_Ent").HeaderText = "Contacto"
            '.Columns("Contacto_Ent").DisplayIndex = 12
            '.Columns("Contacto_Ent").ReadOnly = True

            .Columns("MODO").Visible = True
            .Columns("MODO").Width = 40
            .Columns("MODO").HeaderText = "Mon."
            .Columns("MODO").DisplayIndex = 13
            .Columns("MODO").ReadOnly = True

            ' .Columns("Modalidad").Visible = True
            ' .Columns("Modalidad").Width = 40
            ' .Columns("Modalidad").HeaderText = "Mod."
            ' .Columns("Modalidad").DisplayIndex = 11
            ' .Columns("Modalidad").ReadOnly = True


        End With

        Dim _Meardo = _Row_Encabezado.Item("MEARDO")



        With Grilla_Detalle

            .DataSource = _Tbl_Detalle

            Dim _Total_Linea As String
            Dim _Titulo_Total As String
            Dim _FormatoPrecio As String
            Dim _Precio_Linea As String
            Dim _Titulo_Precio As String
            Dim _Precio_Lista As String

            If _Meardo = "B" Then
                _FormatoPrecio = "$ ###,##.##"
                _Precio_Linea = "PPPRBR"
                _Precio_Lista = "PPPRBRLT"
                _Titulo_Precio = "Precio Bruto "
                _Total_Linea = "VABRLI"
                _Titulo_Total = "Total Bruto"
            ElseIf _Meardo = "N" Then
                _FormatoPrecio = "$ ###,##.###"
                _Precio_Linea = "PPPRNE"
                _Precio_Lista = "PPPRNELT"
                _Titulo_Precio = "Precio Neto"
                _Total_Linea = "VANELI"
                _Titulo_Total = "Total Neto"
            End If

            .RowTemplate.Height = 18
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod

            OcultarEncabezadoGrilla(Grilla_Detalle, True)


            '.Columns("BOSULIDO").ReadOnly = True
            '.Columns("BOSULIDO").Width = 30
            '.Columns("BOSULIDO").HeaderText = "Bod"
            '.Columns("BOSULIDO").Visible = True
            '.Columns("BOSULIDO").DisplayIndex = 0

            '.Columns("LINCONDEST").ReadOnly = True
            '.Columns("LINCONDEST").Width = 20
            '.Columns("LINCONDEST").HeaderText = "D"
            '.Columns("LINCONDEST").Visible = True
            '.Columns("LINCONDEST").Frozen = True
            '.Columns("LINCONDEST").DisplayIndex = 1

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True
            '.Columns("KOPRCT").Frozen = True
            .Columns("KOPRCT").DisplayIndex = 2

            .Columns("NOKOPR").Width = 200
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").Frozen = True
            .Columns("NOKOPR").DisplayIndex = 3

            .Columns("UD").Width = 25
            .Columns("UD").HeaderText = "UN"
            .Columns("UD").ReadOnly = True
            .Columns("UD").Visible = True
            .Columns("UD").DisplayIndex = 4

            .Columns("CANTIDAD").Width = 45
            .Columns("CANTIDAD").HeaderText = "Cant."
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").DefaultCellStyle.Format = "###,##.##"
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DisplayIndex = 5

            .Columns(_Precio_Lista).Width = 72
            .Columns(_Precio_Lista).HeaderText = _Titulo_Precio & " (Lista)"
            .Columns(_Precio_Lista).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Precio_Lista).DefaultCellStyle.Format = _FormatoPrecio
            .Columns(_Precio_Lista).Visible = True
            .Columns(_Precio_Lista).DisplayIndex = 6

            .Columns(_Precio_Linea).Width = 72
            .Columns(_Precio_Linea).HeaderText = _Titulo_Precio & " (Digitado)"
            .Columns(_Precio_Linea).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Precio_Linea).DefaultCellStyle.Format = _FormatoPrecio
            .Columns(_Precio_Linea).Visible = True
            .Columns(_Precio_Linea).DisplayIndex = 7

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

            .Columns("DSCTO").Width = 55
            .Columns("DSCTO").HeaderText = "Dscto"
            .Columns("DSCTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DSCTO").DefaultCellStyle.Format = "% ###.##"
            .Columns("DSCTO").Visible = True
            .Columns("DSCTO").DisplayIndex = 8

            .Columns("DSCTO_REAL").Width = 55
            .Columns("DSCTO_REAL").HeaderText = "Dscto Real"
            .Columns("DSCTO_REAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DSCTO_REAL").DefaultCellStyle.Format = "% ###.##"
            .Columns("DSCTO_REAL").Visible = True
            .Columns("DSCTO_REAL").DisplayIndex = 9

            .Columns(_Total_Linea).Width = 75
            .Columns(_Total_Linea).HeaderText = _Titulo_Total
            .Columns(_Total_Linea).DefaultCellStyle.Format = "$ ###,##"
            .Columns(_Total_Linea).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(_Total_Linea).ReadOnly = True
            .Columns(_Total_Linea).Visible = True
            '.Columns(_Total_Linea).Frozen = True
            .Columns(_Total_Linea).DisplayIndex = 10

            '.Columns("VANELI").Width = 80 + _Mas
            '.Columns("VANELI").HeaderText = "Total Neto $"
            '.Columns("VANELI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("VANELI").DefaultCellStyle.Format = "###,##.##"
            '.Columns("VANELI").Visible = True
            '.Columns("VANELI").DisplayIndex = 11

            .Columns("Total_Costo").Width = 75
            .Columns("Total_Costo").HeaderText = "Total Costo"
            .Columns("Total_Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Costo").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Costo").Visible = True
            .Columns("Total_Costo").DisplayIndex = 12

            .Columns("Margen_Valor").Width = 75
            .Columns("Margen_Valor").HeaderText = "Margen $"
            .Columns("Margen_Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Margen_Valor").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Margen_Valor").Visible = True
            .Columns("Margen_Valor").DisplayIndex = 13

            .Columns("Margen_Porc").Width = 50
            .Columns("Margen_Porc").HeaderText = "Mrg %"
            .Columns("Margen_Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Margen_Porc").DefaultCellStyle.Format = "% ###,##.###"
            .Columns("Margen_Porc").Visible = True '_Mostrar_Margen
            .Columns("Margen_Porc").DisplayIndex = 14


        End With

        Dim _TotalNetoDoc = _Row_Encabezado.Item("VANEDO")
        Dim _TotalIvaDoc = _Row_Encabezado.Item("VAIVDO")
        Dim _TotalIlaDoc = _Row_Encabezado.Item("VAIMDO")
        Dim _TotalBrutoDoc = _Row_Encabezado.Item("VABRDO")

        If _Meardo = "B" Then
            LblTotalNeto.Text = FormatCurrency(_TotalNetoDoc, 0)
            LblTotalIva.Text = FormatCurrency(_TotalIvaDoc, 0)
            LblTotalImpuestos.Text = FormatCurrency(_TotalIlaDoc, 0)
            LblTotalBruto.Text = FormatCurrency(_TotalBrutoDoc, 0)

            GroupPanel1.Text = "Total"
            LblTotalNeto.Text = FormatCurrency(_TotalBrutoDoc, 0)
        ElseIf _Meardo = "N" Then
            LblTotalNeto.Text = FormatCurrency(_TotalNetoDoc, 0)
            LblTotalIva.Text = FormatCurrency(_TotalIvaDoc, 0)
            LblTotalImpuestos.Text = FormatCurrency(_TotalIlaDoc, 0)
            LblTotalBruto.Text = FormatCurrency(_TotalBrutoDoc, 0)
        End If

        Grupo_Margen_Porc.Visible = True '_Mostrar_Margen
        Grupo_Margen_Valor.Visible = True '_Mostrar_Margen

        Grupo_Metodo_Costeo.Enabled = True ' _Mostrar_Costos
        Grupo_Total_Costo.Visible = True ' _Mostrar_Costos

        Dim _Descripcion = String.Empty
        Dim _Dscto_Real_Valor, _Dscto_Real_Porc As Double


    End Sub

    Sub Sb_Dscto_Real_X_Linea(_Fila As DataGridViewRow)

        Dim _Dscto_Real_Porc As Double

        Try

            'Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

            Dim _Tido = _Fila.Cells("TIDO").Value
            Dim _Ppprnelt As Double = _Fila.Cells("PPPRNELT").Value
            Dim _Ppprne As Double = _Fila.Cells("PPPRNE").Value

            Dim _Ppprbrlt As Double = _Fila.Cells("PPPRBRLT").Value
            Dim _Ppprbr As Double = _Fila.Cells("PPPRBR").Value

            Dim _Meardo = _Row_Encabezado.Item("MEARDO")
            Dim _Valor_Lista, _Valor_Dig As Double

            If _Meardo = "N" Then
                _Valor_Lista = _Ppprnelt
                _Valor_Dig = _Ppprne
            ElseIf _Meardo = "B" Then
                _Valor_Lista = _Ppprbrlt
                _Valor_Dig = _Ppprbr
            End If

            Dim _Codigo As String = _Fila.Cells("KOPRCT").Value

            Dim _Dscto_Real_Valor = Math.Round(_Valor_Lista - _Valor_Dig, 5)
            _Dscto_Real_Porc = Math.Round(_Dscto_Real_Valor / _Valor_Lista, 5)

            If (Double.IsNaN(_Dscto_Real_Porc) Or Double.IsInfinity(_Dscto_Real_Porc)) Then
                _Dscto_Real_Porc = 0
            End If

            Dim _Podtglli As Double = _Fila.Cells("PODTGLLI").Value / 100

            Dim _Saldo As Double = Math.Round(_Valor_Lista - _Valor_Dig, 5)
            Dim _Dscto_Random As Double = _Valor_Dig * _Podtglli

            Dim _Sumas_Dsctos As Double = _Dscto_Random + _Dscto_Real_Valor
            _Dscto_Real_Porc = _Sumas_Dsctos / _Valor_Lista

            If (Double.IsNaN(_Dscto_Real_Porc) Or Double.IsInfinity(_Dscto_Real_Porc)) Then
                _Dscto_Real_Porc = 0
            End If

        Catch ex As Exception
            _Dscto_Real_Porc = 0
        End Try

        _Fila.Cells("DSCTO_REAL").Value = _Dscto_Real_Porc

    End Sub

    Sub Sb_Revisar_Margenes(_Lista_Costo As String)

        If Not _Exite_Documento Then Return

        Dim _Total_Neto_Sdscto As Double
        Dim _Total_Bruto_Sdcto As Double

        Dim _Total_Dscto_Porc As Double
        Dim _Total_Dscto_Valor As Double

        Dim _Total_Neto As Double
        Dim _Total_Bruto As Double

        Dim _Sub_Total As Double

        Dim _Total_Margen_Porc, _Total_Margen_Valor, _Total_Costo As Double

        Dim _Meardo As String

        If Not (_Row_Encabezado Is Nothing) Then
            _Meardo = _Row_Encabezado.Item("MEARDO")
        End If

        For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows

            Dim _Codigo As String = _Fila.Cells("KOPRCT").Value

            Dim _Cantidad = _Fila.Cells("CANTIDAD").Value
            Dim _Udtrpt As Integer = _Fila.Cells("UDTRPR").Value

            Dim _Precio As Double
            Dim _Total_Linea As String
            Dim _Titulo_Total As String
            Dim _FormatoPrecio As String
            Dim _Precio_Linea As String
            Dim _Titulo_Precio As String
            Dim _Precio_Lista As String


            If _Meardo = "B" Then
                _FormatoPrecio = "$ ###,##.##"
                _Precio_Linea = "PPPRBR"
                _Precio_Lista = "PPPRBRLT"
                _Titulo_Precio = "Precio Bruto "
                _Total_Linea = "VABRLI"
                _Titulo_Total = "Total Bruto"
            ElseIf _Meardo = "N" Then
                _FormatoPrecio = "$ ###,##.###"
                _Precio_Linea = "PPPRNE"
                _Precio_Lista = "PPPRNELT"
                _Titulo_Precio = "Precio Neto"
                _Total_Linea = "VANELI"
                _Titulo_Total = "Total Neto"
            End If

            If _Meardo = "N" Then
                _Precio = _Fila.Cells("PPPRNE").Value
            Else
                _Precio = _Fila.Cells("PPPRBR").Value
            End If


            Dim _DescuentoPorc As Double '= _Fila.Cells("DescuentoPorc").Value
            Dim _DescuentoValor As Double '= _Fila.Cells("DescuentoValor").Value

            Dim _PrecioNetoUd = _Fila.Cells("PPPRNE").Value
            Dim _PrecioNetoUdLista = _Fila.Cells("PPPRNELT").Value

            Dim _PrecioBrutoUd = _Fila.Cells("PPPRBR").Value
            Dim _PrecioBrutoUdLista = _Fila.Cells("PPPRBRLT").Value
            Dim _Rtu = _Fila.Cells("RLUDPR").Value

            Dim _Prct As Boolean = _Fila.Cells("PRCT").Value
            Dim _Tict As String = Trim(NuloPorNro(_Fila.Cells("TICT").Value, ""))
            Dim _Tipr As String = Trim(NuloPorNro(_Fila.Cells("TIPR").Value, ""))

            Dim _PrecioNetoRealUd1 = 0 '_Fila.Cells("PrecioNetoRealUd1").Value
            Dim _PrecioNetoRealUd2 = 0 '_Fila.Cells("PrecioNetoRealUd2").Value

            Dim _Tiene_Dscto As Boolean '= _Fila.Cells("Tiene_Dscto").Value

            Dim _CodLista = _Fila.Cells("KOLTPR").Value
            Dim _DescMaximo '= _Fila.Cells("DescMaximo").Value

            Dim _PorIva = _Fila.Cells("POIVLI").Value
            Dim _PorIla = _Fila.Cells("POIMGLLI").Value

            Dim _Impuestos = _PorIva + _PorIla

            Dim _ValNetoLinea = _Fila.Cells("VANELI").Value
            Dim _ValBrutoLinea = _Fila.Cells("VABRLI").Value

            Dim _PmLinea As Double = 0 '= _Sql.Fx_Trae_Dato("MAEPREM", "PM", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'") '_Fila.Cells("PPPRPM").Value
            Dim _PmSucLinea As Double = 0 '= _Fila.Cells("PmSucLinea").Value
            Dim _PmDocumento As Double = 0

            Dim _UltCompraLinea As Double
            Dim _Costo_Lista As Double

            Dim _i = 1


            If Not _Prct Then ' String.IsNullOrEmpty(_Tict) And Not String.IsNullOrEmpty(_Tipr) And Not _Prct Then

                _PmLinea = _Sql.Fx_Trae_Dato("MAEPREM", "PM", "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'") '_Fila.Cells("PPPRPM").Value
                _UltCompraLinea = _Sql.Fx_Trae_Dato("MAEPREM", "PPUL0" & _Udtrpt, "EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'")
                _Costo_Lista = _Sql.Fx_Trae_Dato("TABPRE",
                                                 "PP0" & _Udtrpt & "UD",
                                                 "KOLT = '" & _Lista_Costo & "' And KOPR = '" & _Codigo & "'", True)
                _PmDocumento = _Fila.Cells("PPPRPM").Value

            Else
                _i = 0
            End If


            Dim _Costo As Double

            If Rdb_Costo_PM_Documento.Checked Then
                _Costo = _PmDocumento
            ElseIf Rdb_Costo_PM.Checked Then
                If _Udtrpt = 1 Then
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

            If _Meardo = "B" Then
                Dim _Imp As Double = _Total_Costo_Linea * (_Impuestos / 100)
                _Total_Costo_Linea = _Total_Costo_Linea + _Imp
            End If


            Dim _Margen_Porc, _Margen_Valor As Double

            If Math.Round(_PrecioNetoUd, 2) < Math.Round(_PrecioNetoUdLista, 2) Then
                _Fila.Cells(_Precio_Linea).Style.ForeColor = Rojo
            End If

            If _Meardo = "N" Then
                _Margen_Valor = (_ValNetoLinea - _Total_Costo_Linea) * _i
                _Margen_Porc = ((_ValNetoLinea - _Total_Costo_Linea) / _ValNetoLinea) * _i
            Else
                _Margen_Valor = (_ValBrutoLinea - _Total_Costo_Linea) * _i
                _Margen_Porc = ((_ValBrutoLinea - _Total_Costo_Linea) / _ValBrutoLinea) * _i
            End If

            'ElseIf _DocEn_Neto_Bruto = "B" Then
            '_Margen = (_ValBrutoLinea - _Total_Costo_Linea) / _ValBrutoLinea
            'End If

            'Total_Costo,CAST( 0 AS Float) AS Margen_Porc
            _Fila.Cells("Total_Costo").Value = Math.Round(_Total_Costo_Linea, 2)
            _Fila.Cells("Margen_Valor").Value = Math.Round(_Margen_Valor, 2)
            _Fila.Cells("Margen_Porc").Value = Math.Round(_Margen_Porc, 4)


            Dim _DsctoRealPorc '= _Fila.Cells("DsctoRealPorc").Value


            _Total_Neto += _ValNetoLinea
            _Total_Bruto += _ValBrutoLinea

            _Total_Neto_Sdscto += _PrecioNetoUdLista * _Cantidad
            _Total_Bruto_Sdcto += _PrecioBrutoUdLista * _Cantidad


            _Total_Costo += _Total_Costo_Linea

            If _Margen_Valor < 0 Then
                _Fila.Cells("Margen_Valor").Style.ForeColor = Rojo
                _Fila.Cells("Margen_Porc").Style.ForeColor = Rojo
            Else
                _Fila.Cells("Margen_Valor").Style.ForeColor = Verde
                _Fila.Cells("Margen_Porc").Style.ForeColor = Verde
            End If

            Sb_Dscto_Real_X_Linea(_Fila)

        Next

        '_TotalNetoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalNetoDoc").Value
        '_TotalIvaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIvaDoc").Value
        '_TotalIlaDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalIlaDoc").Value
        '_TotalBrutoDoc = Grilla_Enc_Tot.Rows(0).Cells("TotalBrutoDoc").Value

        'If _DocEn_Neto_Bruto = "N" Then


        If _Meardo = "N" Then
            _Total_Margen_Porc = (_Total_Neto - _Total_Costo) / _Total_Neto
            _Total_Margen_Valor = _Total_Neto - _Total_Costo
        ElseIf _Meardo = "B" Then
            _Total_Margen_Porc = (_Total_Bruto - _Total_Costo) / _Total_Bruto
            _Total_Margen_Valor = _Total_Bruto - _Total_Costo
        End If



        If _Meardo = "B" Then
            _Total_Dscto_Valor = _Total_Bruto_Sdcto - _Total_Bruto
            _Total_Dscto_Porc = _Total_Dscto_Valor / _Total_Bruto_Sdcto
            _Sub_Total = _Total_Bruto_Sdcto
            Grupo_SubTotal.Text = "Sub Total Bruto"
        ElseIf _Meardo = "N" Then
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


    Private Sub Rdb_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click

        _Aceptado = True

        Dim _Idmaeedo = _Row_Encabezado.Item("IDMAEEDO")
        Dim _Kofuaudo = _Row_Funcionario.Item("KOFU")
        Dim _Row_Maeus As DataRow
        Dim _Row_Maeop As DataRow
        Dim _Koop, _Nokoop As String

        Try

            For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows

                Dim _Kooplido = _Fila.Cells("KOOPLIDO").Value

                If _Kooplido = "TO000005" Or _Kooplido = "TO000816" Then

                    Consulta_Sql = "Select top 1 * From MAEOP Where KOOP = '" & _Kooplido & "'"
                    _Row_Maeop = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    _Koop = _Row_Maeop.Item("KOOP")
                    _Nokoop = _Row_Maeop.Item("NOKOOP")

                    Consulta_Sql = "Select Top 1 * From MAEUS Where KOUS = '" & _Kofuaudo & "' AND KOOP = '" & _Koop & "'"
                    _Row_Maeus = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    If _Row_Maeus Is Nothing Then
                        Throw New Exception("Usted no posee permisos para realizar esta acción" & vbCrLf &
                                            "Permiso: " & _Kooplido & "," & _Nokoop)
                    End If

                End If

            Next

            Consulta_Sql = "Select top 1 * From MAEOP Where KOOP = 'TO000006'"
            _Row_Maeop = _Sql.Fx_Get_DataRow(Consulta_Sql)

            _Koop = _Row_Maeop.Item("KOOP")
            _Nokoop = _Row_Maeop.Item("NOKOOP")

            Consulta_Sql = "Select Top 1 * From MAEUS Where KOUS = '" & _Kofuaudo & "' AND KOOP = 'TO000006'"
            _Row_Maeus = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If _Row_Maeus IsNot Nothing Then

                Dim _Tipo = _Row_Maeus.Item("TIPO")
                Dim _Valor = _Row_Maeus.Item("VALOR")
                _Koop = _Row_Maeus.Item("KOOP")

                If _Tipo = 2 Then
                    Dim _Dscto = _Dscto_Global * 100
                    If _Valor >= _Dscto Then
                        Consulta_Sql = "UPDATE KASIDDO SET KOFUAULIDO = '" & _Kofuaudo & "' Where IDMAEEDO = " & _Idmaeedo & Space(1) &
                                       "And KOOPLIDO In ('TO000005','TO000816')" & vbCrLf &
                                       "UPDATE KASIEDO SET KOFUAUDO = '" & _Kofuaudo & "' WHERE IDMAEEDO = " & _Idmaeedo & vbCrLf &
                                       "UPDATE TABREMOT SET KOFUAUTO='" & _Kofuaudo & "',OTORGA='Visado',IPOTORGA='" & _Ipotorga & "'" & Space(1) &
                                       "WHERE KOFU='" & _Kofu & "' AND NUREMOT = '" & _Nuremot & "'"
                        _Aceptado = _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)
                    Else
                        Throw New Exception("El tope máximo que posee usted para autorizar un descuento global es de " & _Valor & " %")
                        'MessageBoxEx.Show(Me, "El tope máximo que posee usted para autorizar un descuento global es de " & _Valor & " %", _
                        '                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If
            Else
                Throw New Exception("Usted no posee permisos para realizar esta acción" & vbCrLf &
                                    "Permiso: " & _Koop & "," & _Nokoop)
            End If

            If _Aceptado Then
                Me.Close()
            End If

        Catch ex As Exception
            _Aceptado = False
            MessageBoxEx.Show(Me, ex.Message, "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Rechazar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Rechazar.Click

        _Rechazado = True

        Consulta_Sql = "UPDATE TABREMOT SET KOFUAUTO='" & _Row_Funcionario.Item("KOFU") & "',OTORGA='No_autorizo',IPOTORGA='" & _Ipotorga & "'" &
                       "WHERE KOFU='" & _Kofu & "' AND NUREMOT = '" & _Nuremot & "'"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        Me.Close()

    End Sub

    Private Sub Frm_Remotas_Analisi_Dscto_X_Documento_Rd_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If Not _Aceptado And Not _Rechazado Then

            Consulta_Sql = "UPDATE TABREMOT SET KOFUAUTO='',OTORGA='',IPOTORGA=''" &
                           "WHERE KOFU='" & _Kofu & "' AND NUREMOT = '" & _Nuremot & "'"
            _Sql.Ej_consulta_IDU(Consulta_Sql)

        End If

    End Sub

    Private Sub Grilla_Detalle_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Detalle.CellEnter

        Dim _Bodega = String.Empty
        Dim _Descripcion = String.Empty
        Dim _Dscto_Real_Valor, _Dscto_Real_Porc As Double

        Try

            Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

            _Dscto_Real_Porc = _Fila.Cells("DSCTO_REAL").Value
            _Bodega = _Fila.Cells("BOSULIDO").Value
            _Descripcion = "Bod: " & _Bodega & " - " & _Fila.Cells("NOKOPR").Value & ", Descuento Real: " & FormatPercent(_Dscto_Real_Porc, 2)

        Catch ex As Exception
        Finally
            LblDescripcion.Text = _Descripcion
        End Try
    End Sub

    Private Sub Cmb_Lista_Costo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cmb_Lista_Costo.SelectedIndexChanged
        Sb_Revisar_Margenes(Cmb_Lista_Costo.SelectedValue)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Frm_Remotas_Analisi_Dscto_X_Documento_Rd_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click
        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("KOPRCT").Value

        Dim _Endo As String = _Row_Encabezado.Item("ENDO")
        Dim _Tido As String = _Row_Encabezado.Item("TIDO")
        Dim _Tipotransa As String = _Sql.Fx_Trae_Dato("TABTIDO", "TIPOTRANSA", "TIDO = '" & _Tido & "'")

        If _Tipotransa = "C" Then
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Compra)
        ElseIf _Tipotransa = "V" Then
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)
        Else
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
        End If
    End Sub
End Class
