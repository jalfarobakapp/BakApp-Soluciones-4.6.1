Imports DevComponents.DotNetBar

Public Class Frm_Mt_InvParc_Importar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _Nombre_Archivo As String
    Dim _Archivo_Importado_correctamente As Boolean

    Dim _Ds_Invent As New Ds_Invent_parcial

    Public ReadOnly Property Pro_Archivo_Importado_correctamente() As Boolean
        Get
            Return _Archivo_Importado_correctamente
        End Get
    End Property

    Public ReadOnly Property Pro_Ds_Invent() As DataSet
        Get
            Return _Ds_Invent
        End Get
    End Property

    Public Sub New(ByVal Ds_Invent As Object,
                   ByVal Empresa As String,
                   ByVal Sucursal As String,
                   ByVal Bodega As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        '_Ds_Invent = Ds_Invent
        _Empresa = Empresa
        _Sucursal = Sucursal
        _Bodega = Bodega

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Mt_InvParc_Importar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub BtnAbrir_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir_Archivo.Click
        Dim oFD As New OpenFileDialog

        With oFD
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            '.Filter = "Ficheros DBF (Productos_Aju.xls)|Productos_Aju.xls|Productos_Aju.xlsx"
            .FileName = ""

            If .ShowDialog = DialogResult.OK Then
                _Nombre_Archivo = .SafeFileName
                TxtNombreArchivo.Text = .FileName
            Else
                TxtNombreArchivo.Text = String.Empty
            End If
        End With
    End Sub

    Private Function Fx_Importar_Inventario(ByVal _Ubic_Archivo As String,
                                             ByVal _Nro_Hoja As Integer) As Boolean
        Try

            _Ds_Invent.Clear()

            Dim _ImpEx As New Class_Importar_Excel
            Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo), ".", "")
            Dim _Arreglo = _ImpEx.Importar_Excel_Array(_Ubic_Archivo, _Extencion, _Nro_Hoja)

            Dim _Filas = _Arreglo.GetUpperBound(0)
            Dim _RegInsert As Long = 0

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = _Filas

            Dim _Contador As Integer = 0

            For i = 1 To _Filas

                System.Windows.Forms.Application.DoEvents()

                Dim _Codigo As String = QuitaEspacios_ParaCodigos(Trim(_Arreglo(i, 0)), 13)
                Dim _Cod_Barras As String = String.Empty
                Dim _CantidadUd1 As Double = _Arreglo(i, 1)
                Dim _CantidadUd2 As Double = 0
                Dim _CostoUd1 As Double = NuloPorNro(_Arreglo(i, 2), 0)
                Dim _Descripcion As String = String.Empty
                Dim _Rtu As Double = 0
                Dim _StockUd1 As Double = 0


                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'" & vbCrLf &
                               "Select Top 1 KOPRAL From TABCODAL Where KOPR = '" & _Codigo & "' And KOEN = ''" & vbCrLf &
                               "Select Top 1 Isnull(STFI1,0) As STFI1 From MAEST" & Space(1) &
                               "Where KOPR = '" & _Codigo & "' AND EMPRESA = '" & _Empresa &
                               "' AND KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "'" & vbCrLf &
                               "Select Top 1 * From MAEPREM" & vbCrLf &
                               "Where KOPR = '" & _Codigo & "' AND EMPRESA = '" & _Empresa & "'"

                Dim _Ds_Producto As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                Dim _Tbl_Maepr As DataTable = _Ds_Producto.Tables(0)
                Dim _Tbl_Tabcodal As DataTable = _Ds_Producto.Tables(1)
                Dim _Tbl_Maest As DataTable = _Ds_Producto.Tables(2)
                Dim _Tbl_Maeprem As DataTable = _Ds_Producto.Tables(3)

                If CBool(_Tbl_Maepr.Rows.Count) Then

                    Dim _RowProducto As DataRow = _Tbl_Maepr.Rows(0)

                    _Descripcion = _RowProducto.Item("NOKOPR")
                    _Rtu = _RowProducto.Item("RLUD")

                    If CBool(_Tbl_Tabcodal.Rows.Count) Then
                        _Cod_Barras = _Tbl_Tabcodal.Rows(0).Item("KOPRAL")
                    End If

                    If CBool(_Tbl_Maest.Rows.Count) Then
                        _StockUd1 = _Tbl_Maest.Rows(0).Item("STFI1")
                    End If

                    _CantidadUd2 = _CantidadUd1 * _Rtu

                    If CBool(_Tbl_Maeprem.Rows.Count) Then
                        _CostoUd1 = _Tbl_Maeprem.Rows(0).Item("PM")
                    End If

                Else
                    _Descripcion = "#NO EXISTE#"
                End If

                Dim rows As DataRow()

                rows = _Ds_Invent.Tables("Inv_InvParcial").Select("CodigoPr = '" & _Codigo & "'", "CodigoPr")

                If CBool(rows.Length) Then
                    _Descripcion = "#REPETIDO#"
                End If

                Dim _Inventariado_Antes = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TmpInv_InvParcial",
                                                                   "Empresa = '" & _Empresa & "' and " &
                                                                   "Sucursal = '" & _Sucursal & "'and " &
                                                                   "Bodega = '" & _Bodega & "' and " &
                                                                   "CodigoPr = '" & _Codigo & "' and " &
                                                                   "Levantado = 1 And DejaStockCero = 0")

                Dim Fecha = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TmpInv_InvParcial",
                                               "FechaInv",
                                               "Empresa = '" & _Empresa & "' and " &
                                               "Sucursal = '" & _Sucursal & "'and " &
                                               "Bodega = '" & _Bodega & "' and " &
                                               "CodigoPr = '" & _Codigo & "' and " &
                                               "Levantado = 1" & vbCrLf &
                                               "ORDER BY FechaInv desc")

                Dim _Fecha_Antes = FechaDelServidor()

                If CBool(_Inventariado_Antes) Then _Fecha_Antes = CDate(Fecha)

                Dim NewFila As DataRow
                NewFila = _Ds_Invent.Tables("Inv_InvParcial").NewRow
                With NewFila

                    .Item("Empresa") = _Empresa
                    .Item("Sucursal") = _Sucursal
                    .Item("Bodega") = _Bodega
                    .Item("CodigoPr") = _Codigo
                    .Item("Descripcion") = _Descripcion
                    .Item("CodBarras") = _Cod_Barras
                    .Item("Rtu") = _Rtu
                    .Item("CantidadUd1") = _CantidadUd1
                    .Item("CantidadUd2") = _CantidadUd1

                    .Item("CostoUnitUd1") = _CostoUd1
                    .Item("TotalCostoUd1") = _CostoUd1 * _CantidadUd1
                    .Item("StockActual") = _StockUd1

                    .Item("Inventariado_Antes") = CBool(_Inventariado_Antes)
                    .Item("Fecha_Antes") = _Fecha_Antes
                    .Item("Oculto") = "OCU"
                    .Item("Nuevo_Producto") = False

                    _Ds_Invent.Tables("Inv_InvParcial").Rows.Add(NewFila)

                End With

                System.Windows.Forms.Application.DoEvents()
                _Contador += 1
                Progreso_Porc.Value = ((_Contador * 100) / _Filas)
                Progreso_Cont.Value += 1

            Next

            Return True

        Catch ex As Exception
            Return False
        Finally
            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0
        End Try

    End Function

    Private Sub BtnImportarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportarDatos.Click

        If Not String.IsNullOrEmpty(TxtNombreArchivo.Text) Then

            _Archivo_Importado_correctamente = Fx_Importar_Inventario(TxtNombreArchivo.Text, 0)

            If _Archivo_Importado_correctamente Then

                Dim _Tb As DataTable = _Ds_Invent.Tables("Inv_InvParcial")
                Dim _Tbl = Fx_Crea_Tabla_Con_Filtro(_Tb, "Descripcion = '#NO EXISTE#' Or Descripcion = '#REPETIDO#'", "CodigoPr")

                If CBool(_Tbl.Rows.Count) Then
                    MessageBoxEx.Show(Me, "Existen productos que no han sido validados por el sistema", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Prod_Problemas")
                    _Archivo_Importado_correctamente = False
                Else
                    Me.Close()
                End If


            Else
                MessageBoxEx.Show(Me, "Problemas de lectura de archivo de origen" & vbCrLf &
                                  "No fue posible crear archivo de paso", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else

            MessageBoxEx.Show(Me, "Debe seleccionar un archivo", "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Frm_Mt_InvParc_Importar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Archivo_Ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Archivo_Ayuda.Click

        Consulta_sql = "Select '' As Codigo,'' As CantidadUd1,'' As CostoUd1"
        ExportarTabla_JetExcel(Consulta_sql, Me, "Archivo_Lev_Inventario")

    End Sub





End Class
