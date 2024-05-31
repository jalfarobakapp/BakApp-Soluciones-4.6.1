'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_01_HojaConteo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Ds_Inventario As New DsInventario_Gral

    Public _CodSectorInt As String
    Public Codigo_Sector As String
    Public Digitador As String
    Public Nombre_Digitador As String

    Public _IdInventario_Activo As Integer
    Public _Fecha_Inventario_Gral As Date
    Public _Fecha_Inv_Activo As Date
    Public _Empresa_Inv_Activo,
           _Sucursal_Inv_Activo,
           _Bodega_Inv_Activo,
           _Ano, _Mes, _Dia As String

    Dim _Cancelar_LevMasivo As Boolean


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Inv, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
    End Sub

#Region "PROCESOS"

    Sub Nueva_Hoja(ByVal _IncorporarHoja As Boolean)

        Ds_Inventario.Clear()

        If _IncorporarHoja Then

            Dim Frm_ As New Frm_03_Sectores_Inv
            Frm_._Empresa = _Empresa_Inv_Activo
            Frm_._Sucursal = _Sucursal_Inv_Activo
            Frm_._Bodega = _Bodega_Inv_Activo
            Frm_._IngresarHoja = True
            Frm_._ValidaEstado = True

            Frm_._IdInventario = _IdInventario_Activo 'SemillaUbicacion_Inv

            Frm_.ShowDialog(Me)

            _CodSectorInt = Frm_.Sector
            Codigo_Sector = Frm_.NombreUbicacion

        End If

        If String.IsNullOrEmpty(Trim(NuloPorNro(_CodSectorInt, ""))) Then
            Me.Close()
            MessageBoxEx.Show("No se selecciono ningún Sector", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        With Grilla_Enc
            .DataSource = Nothing
            .DataSource = Ds_Inventario '.Tables("DetalleDocumento")
            .DataMember = Ds_Inventario.Tables("Hoja_Conteo_Encabezado").TableName
            .ScrollBars = ScrollBars.None
        End With

        With Grilla_Inv
            .DataSource = Nothing
            .DataSource = Ds_Inventario '.Tables("DetalleDocumento")
            .DataMember = Ds_Inventario.Tables("Hoja_Conteo_Detalle").TableName
            .ScrollBars = ScrollBars.None
        End With

        Formato_Grilla()

        Dim NewFila As DataRow
        NewFila = Ds_Inventario.Tables("Hoja_Conteo_Encabezado").NewRow

        With NewFila
            .Item("Digitador") = Digitador
            .Item("Nombre_Digitador") = Nombre_funcionario_activo
            .Item("Cod_Sector") = _CodSectorInt
            .Item("Codigo_Sector") = Codigo_Sector
        End With

        Ds_Inventario.Tables("Hoja_Conteo_Encabezado").Rows.Add(NewFila)

        If _IncorporarHoja Then

            Nueva_Linea()

            'NewFila = Ds_Inventario.Tables("Hoja_Conteo_Detalle").NewRow
            'With NewFila
            '.Item("Nuevo_Producto") = True
            'End With
            'Ds_Inventario.Tables("Hoja_Conteo_Detalle").Rows.Add(NewFila)

            Me.ActiveControl = Grilla_Inv
            With Grilla_Inv
                .Focus()
                .CurrentCell = .Rows(0).Cells("Codproducto")
                '.BeginEdit(True)
            End With
        End If
    End Sub

    Sub Formato_Grilla()

        With Grilla_Enc

            OcultarEncabezadoGrilla(Grilla_Enc, True)

            .Columns("Cod_Sector").Width = 100
            .Columns("Cod_Sector").HeaderText = "Sector"
            .Columns("Cod_Sector").Visible = True
            .Columns("Cod_Sector").Frozen = True
            .Columns("Cod_Sector").DisplayIndex = 0
            .Columns("Cod_Sector").ReadOnly = True

            .Columns("Codigo_Sector").Width = 200
            .Columns("Codigo_Sector").HeaderText = "Nombre Sector"
            .Columns("Codigo_Sector").Visible = True
            .Columns("Codigo_Sector").Frozen = True
            .Columns("Codigo_Sector").DisplayIndex = 1
            .Columns("Codigo_Sector").ReadOnly = True

            .Columns("Nombre_Digitador").Width = 150
            .Columns("Nombre_Digitador").HeaderText = "Digitador"
            .Columns("Nombre_Digitador").Visible = True
            .Columns("Nombre_Digitador").Frozen = True
            .Columns("Nombre_Digitador").DisplayIndex = 2
            .Columns("Nombre_Digitador").ReadOnly = True

            .Columns("Contador_1").Width = 150
            .Columns("Contador_1").HeaderText = "Contador 1"
            .Columns("Contador_1").Visible = True
            .Columns("Contador_1").Frozen = True
            .Columns("Contador_1").DisplayIndex = 3

            .Columns("Contador_2").Width = 150
            .Columns("Contador_2").HeaderText = "Contador 2"
            .Columns("Contador_2").Visible = True
            .Columns("Contador_2").Frozen = True
            .Columns("Contador_2").DisplayIndex = 4

        End With

        With Grilla_Inv

            OcultarEncabezadoGrilla(Grilla_Inv, True)

            .Columns("Item_Hoja").Width = 30
            .Columns("Item_Hoja").HeaderText = "Item"
            .Columns("Item_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Item_Hoja").Visible = True
            .Columns("Item_Hoja").Frozen = True
            .Columns("Item_Hoja").DisplayIndex = 0
            .Columns("Item_Hoja").ReadOnly = True

            .Columns("Codproducto").Width = 110
            .Columns("Codproducto").HeaderText = "Código"
            .Columns("Codproducto").Visible = True
            .Columns("Codproducto").Frozen = True
            .Columns("Codproducto").DisplayIndex = 1
            .Columns("Codproducto").ReadOnly = True

            .Columns("DescripcionProducto").Width = 330
            .Columns("DescripcionProducto").HeaderText = "Descripción"
            .Columns("DescripcionProducto").Visible = True
            .Columns("DescripcionProducto").Frozen = True
            .Columns("DescripcionProducto").DisplayIndex = 2
            .Columns("DescripcionProducto").ReadOnly = True

            .Columns("CodUbicacion").Width = 50
            .Columns("CodUbicacion").HeaderText = "Cod Ub."
            .Columns("CodUbicacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CodUbicacion").Visible = True
            .Columns("CodUbicacion").Frozen = True
            .Columns("CodUbicacion").DisplayIndex = 3

            .Columns("Columna").Width = 75
            .Columns("Columna").HeaderText = "Columna"
            .Columns("Columna").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Columna").Visible = True
            .Columns("Columna").Frozen = True
            .Columns("Columna").DisplayIndex = 4

            .Columns("Fila").Width = 50
            .Columns("Fila").HeaderText = "Fila"
            .Columns("Fila").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fila").Visible = True
            .Columns("Fila").Frozen = True
            .Columns("Fila").DisplayIndex = 5

            .Columns("CantidadInventariada").Width = 90
            .Columns("CantidadInventariada").HeaderText = "Cantidad"
            .Columns("CantidadInventariada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadInventariada").DefaultCellStyle.Format = "###,##.##"
            .Columns("CantidadInventariada").Visible = True
            .Columns("CantidadInventariada").Frozen = True
            .Columns("CantidadInventariada").DisplayIndex = 6

            .Columns("Unidad_Medida").Width = 40
            .Columns("Unidad_Medida").HeaderText = "UN"
            .Columns("Unidad_Medida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Unidad_Medida").Visible = True
            .Columns("Unidad_Medida").Frozen = True
            .Columns("Unidad_Medida").DisplayIndex = 7
            .Columns("Unidad_Medida").ReadOnly = True

        End With

    End Sub

    Private Sub Nueva_Linea()
        Grilla_Inv.Refresh()

        Dim NewFila As DataRow
        NewFila = Ds_Inventario.Tables("Hoja_Conteo_Detalle").NewRow
        With NewFila
            .Item("Nuevo_Producto") = True
            .Item("CodProducto") = String.Empty
            .Item("DescripcionProducto") = String.Empty
            .Item("CantidadInventariada") = 0
            Ds_Inventario.Tables("Hoja_Conteo_Detalle").Rows.Add(NewFila)
        End With

    End Sub

#End Region

    Private Sub Frm_HojaConteo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Dim tecla = e.KeyCode

            If e.KeyValue = Keys.Down Then 'Or e.KeyValue = Keys.Up Then
                With Grilla_Inv

                    Dim Columna As Integer = .CurrentCellAddress.X
                    Dim Fila As Integer = .CurrentCellAddress.Y

                    Dim Nuevo_Producto As Boolean = .Rows(Fila).Cells("Nuevo_Producto").Value

                    If Not Nuevo_Producto Then

                        Dim Filas As Integer = .Rows.Count - 1
                        Nuevo_Producto = .Rows(Filas).Cells("Nuevo_Producto").Value

                        If Filas = Fila Then '.CurrentRow.Index Then
                            Nueva_Linea()
                            .CurrentCell = .Rows(Fila + 1).Cells("Codproducto") '.Rows(.CurrentRow.Index).Cells("Codigo")
                        ElseIf Fila + 1 = .Rows.Count - 1 And Nuevo_Producto Then
                            .CurrentCell = .Rows(Filas).Cells("Codproducto")
                        End If
                    End If

                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Frm_HojaConteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Nueva_Hoja(True)
    End Sub

    Private Sub Grilla_Inv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Inv.CellDoubleClick
        With Grilla_Inv
            Dim Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            If String.IsNullOrEmpty(Trim(Cabeza)) Then
                Buscar_Producto()
            End If
        End With
    End Sub

    Private Sub Grilla_Inv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Inv.KeyDown
        With Grilla_Inv
            Dim Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim Codigo As String = NuloPorNro(.Rows(.CurrentRow.Index).Cells("Codproducto").Value, "")
            Dim tecla = e.KeyCode

            If e.KeyValue = Keys.Return Then
                If Cabeza = "Codproducto" Then

                    If Not String.IsNullOrEmpty(Trim(Codigo)) Then
                        Dim dlg As System.Windows.Forms.DialogResult =
                        MessageBoxEx.Show(Me, "ESTA ACCION MODIFICARA EL PRODUCTO DE LA LINEA?" & vbCrLf &
                                          "¿ESTA SEGURO DE QUERER SEGUIR CON LA ACCION?",
                                          "MODIFICAR PRODUCTO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                        If dlg = System.Windows.Forms.DialogResult.Cancel Then
                            Return
                        End If
                    End If
                    If Buscar_Producto() Then
                        e.Handled = True

                    End If

                ElseIf (Cabeza = "Fila") And Not String.IsNullOrEmpty(Trim(Codigo)) Then
                    Grilla_Inv.CurrentCell = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Columna")
                    SendKeys.Send("{F2}")
                    e.Handled = True
                ElseIf (Cabeza = "Columna") And Not String.IsNullOrEmpty(Trim(Codigo)) Then
                    Grilla_Inv.CurrentCell = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CantidadInventariada")
                    SendKeys.Send("{F2}")
                    e.Handled = True
                ElseIf (Cabeza = "CantidadInventariada") And Not String.IsNullOrEmpty(Trim(Codigo)) Then
                    Grilla_Inv.CurrentCell = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Codproducto")
                    SendKeys.Send("{F2}")
                    e.Handled = True
                End If

            End If
        End With

    End Sub

    Function Buscar_Producto(Optional ByVal _Codigo As String = "") As Boolean


        If String.IsNullOrEmpty(_Codigo) Then

            Dim Fm As New Frm_BuscarXProducto_Mt
            Fm.CodProveedor_productos = String.Empty
            Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
            Fm.ListaDePrecio = ModListaPrecioVenta
            Fm.CodProveedor_productos = String.Empty
            Fm.MostrarOcultos = True
            Fm.BtnBusAlternativas.Visible = True
            Fm.BtnBusAlternativas.Text = "Buscar código alternativo"
            Fm.ShowDialog(Me)
            _Codigo = Fm.CodigoPr_Sel

        End If


        'If String.IsNullOrEmpty(Trim(Fm.TxtCantidadContada.Text)) Then Return False

        If Not String.IsNullOrEmpty(Trim(_Codigo)) Then


            Dim _Indice_Grilla As Integer = Grilla_Inv.CurrentRow.Index

            Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & Codigo_abuscar & "'"
            Dim Tbl_Maepr As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)
            Dim _Descripcion As String

            Dim _Item_Hoja As String = numero_(Grilla_Inv.RowCount, 2)

            With Grilla_Inv

                .Rows(_Indice_Grilla).Cells("IdInventario").Value = _IdInventario_Activo
                .Rows(_Indice_Grilla).Cells("Ano").Value = _Ano
                .Rows(_Indice_Grilla).Cells("Mes").Value = _Mes
                .Rows(_Indice_Grilla).Cells("Dia").Value = _Dia

                .Rows(_Indice_Grilla).Cells("Item_Hoja").Value = _Item_Hoja
                .Rows(_Indice_Grilla).Cells("Nuevo_Producto").Value = False

                .Rows(_Indice_Grilla).Cells("CodEmpresa").Value = _Empresa_Inv_Activo
                .Rows(_Indice_Grilla).Cells("CodSucursal").Value = _Sucursal_Inv_Activo
                .Rows(_Indice_Grilla).Cells("CodBodega").Value = _Bodega_Inv_Activo

                '.Rows(Index).Cells("SemillaUbicacion").Value = SemillaUbicacion_Inv
                .Rows(_Indice_Grilla).Cells("Codproducto").Value = Tbl_Maepr.Rows(0).Item("KOPR")
                .Rows(_Indice_Grilla).Cells("Codrapido").Value = Tbl_Maepr.Rows(0).Item("KOPRRA")
                .Rows(_Indice_Grilla).Cells("Codtecnico").Value = Tbl_Maepr.Rows(0).Item("KOPRTE")

                If _Codigo = "ZDESCONOCIDO" Then
                    _Descripcion = Tbl_Maepr.Rows(0).Item("NOKOPR")
                    _Descripcion = InputBox("Ingrese la descripción de este producto" & vbCrLf &
                                            "Producto desconocido", "Cambiar descripción")
                Else
                    _Descripcion = Tbl_Maepr.Rows(0).Item("NOKOPR")
                End If

                .Rows(_Indice_Grilla).Cells("DescripcionProducto").Value = UCase(_Descripcion)
                .Rows(_Indice_Grilla).Cells("Unidad_Medida").Value = Tbl_Maepr.Rows(0).Item("UD01PR")

                .Rows(_Indice_Grilla).Cells("FechaInventario").Value = Now.Date
                .Rows(_Indice_Grilla).Cells("Observaciones").Value = String.Empty
                .Rows(_Indice_Grilla).Cells("TipoConteo").Value = "M"



            End With
            'Inventario_AnoActivo, _
            '             Inventario_MesActivo, _
            '             inventario_DiaActivo)


            Grilla_Inv.CurrentCell = Grilla_Inv.Rows(_Indice_Grilla).Cells("CodUbicacion")
            Return True
            'Else
            '    Return False
        End If

    End Function

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

        Dim dlg As System.Windows.Forms.DialogResult =
                      MessageBoxEx.Show(Me, "ESTA SEGURO DE QUERER LIMPIAR TODO EL DOCUMENTO, ESTO BORRARA TODAS LAS LINEAS?",
                                        "MODIFICAR PRODUCTO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

        If dlg = System.Windows.Forms.DialogResult.OK Then
            Nueva_Hoja(True)
        End If

    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click


        Dim Ruta_Documento_Bkp As String = AppPath() & "\Data\" & RutEmpresa & "\Hoja_Inv.xml"
        Ds_Inventario.WriteXml(Ruta_Documento_Bkp)
        'MsgBox("listo")

        Dim _Contador_1, _Contador_2 As String

        _Contador_1 = NuloPorNro(Grilla_Enc.Rows(0).Cells("Contador_1").Value, "")
        _Contador_2 = NuloPorNro(Grilla_Enc.Rows(0).Cells("Contador_2").Value, "")

        If String.IsNullOrEmpty(_Contador_1) Then
            MessageBoxEx.Show("Falta Contador 1", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Grilla_Enc.CurrentCell = Grilla_Enc.Rows(0).Cells("Contador_1")
            Grilla_Enc.Focus()
            Grilla_Enc.BeginEdit(True)
            Return
        End If

        If String.IsNullOrEmpty(_Contador_2) Then
            MessageBoxEx.Show("Falta Contador 2", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Grilla_Enc.CurrentCell = Grilla_Enc.Rows(0).Cells("Contador_2")
            Grilla_Enc.Focus()
            Grilla_Enc.BeginEdit(True)
            Return
        End If

        Dim Nro_Hoja As String

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        Try

            myTrans = cn2.BeginTransaction()

            Nro_Hoja =
           _Sql.Fx_Cuenta_Registros("ZW_TmpInvHojas_Inventario", "IdInventario = '" & _IdInventario_Activo & "'") + 1

            Consulta_sql = "INSERT INTO ZW_TmpInvHojas_Inventario (IdInventario,Nro_Hoja, TipoConteo) VALUES" & vbCrLf &
                           "(" & _IdInventario_Activo & ",'" & Nro_Hoja & "','M')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            'Comando.Transaction = myTrans
            'Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            'While dfd1.Read()
            'Nro_Hoja = dfd1("Identity")
            'End While
            'dfd1.Close()

            Dim _Nro_Hoja As String = Nro_Hoja
            Dim Contador As Integer = 0

            For Each Fila_ As DataGridViewRow In Grilla_Inv.Rows
                With Fila_
                    Dim _Ano, _Mes, _Dia, _IdBodega, _CodEmpresa, _CodSucursal, _CodBodega,
                        _CodUbicacion, _UbicacionBodega, _Codproducto, _Codrapido, _Codtecnico,
                        _DescripcionProducto, _CodBarras, _FechaInventario, _Unidad_Medida, _CantidadInventariada,
                        _VecesInventariado, _Observaciones, _Responsable,
                        _Fila, _Columna, _Item_Hoja, _TipoConteo As String


                    _Codproducto = NuloPorNro(.Cells("Codproducto").Value, "")

                    If Not String.IsNullOrEmpty(Trim(_Codproducto)) Then

                        _Item_Hoja = .Cells("Item_Hoja").Value
                        _Ano = .Cells("Ano").Value
                        _Mes = .Cells("Mes").Value
                        _Dia = .Cells("Dia").Value
                        _IdBodega = 0 '.Cells("IdBodega").Value
                        _CodEmpresa = .Cells("CodEmpresa").Value
                        _CodSucursal = .Cells("CodSucursal").Value
                        _CodBodega = .Cells("CodBodega").Value
                        _CodUbicacion = NuloPorNro(.Cells("CodUbicacion").Value, "")
                        _UbicacionBodega = Codigo_Sector 'NuloPorNro(Grilla_Enc.Rows(0).Cells("Codigo_Sector").Value, "") '.Cells("UbicacionBodega").Value

                        _Codrapido = .Cells("Codrapido").Value
                        _Codtecnico = .Cells("Codtecnico").Value
                        _DescripcionProducto = .Cells("DescripcionProducto").Value
                        _CodBarras = NuloPorNro(.Cells("CodBarras").Value, "")
                        _Unidad_Medida = .Cells("Unidad_Medida").Value
                        _CantidadInventariada = .Cells("CantidadInventariada").Value
                        _TipoConteo = .Cells("TipoConteo").Value

                        _Observaciones = .Cells("Observaciones").Value
                        _Responsable = Digitador
                        _Fila = NuloPorNro(.Cells("Fila").Value, "")
                        _Columna = NuloPorNro(.Cells("Columna").Value, "")


                        Consulta_sql = "INSERT INTO ZW_TmpInvProductosInventariados (IdInventario,Fecha_Inventario_Gral,Ano,Mes,Dia,IdBodega,CodEmpresa,CodSucursal,CodBodega," &
                                       "SemillaUbicacion,CodSectorInt,UbicacionBodega,TipoConteo,Nro_Hoja,Item_Hoja,Codproducto,Codrapido,Codtecnico,DescripcionProducto," &
                                       "CodBarras,FechaInventario,Unidad_Medida,CantidadInventariada,VecesInventariado," &
                                       "Observaciones,Responsable,Contador_1,Contador_2,CodigoLeidoArchTxt," &
                                       "CodUbicacion,Fila,Columna) VALUES " & vbCrLf &
                                       "(" & _IdInventario_Activo & ",'" & Format(_Fecha_Inventario_Gral, "yyyyMMdd") &
                                       "','" & _Ano & "','" & _Mes & "','" & _Dia & "'," & _IdBodega &
                                       ",'" & _CodEmpresa & "','" & _CodSucursal & "','" & _CodBodega &
                                       "','" & _CodUbicacion & "','" & _CodSectorInt & "','" & _UbicacionBodega &
                                       "','" & _TipoConteo & "','" & _Nro_Hoja &
                                       "','" & _Item_Hoja & "','" & _Codproducto &
                                       "','" & _Codrapido & "','" & _Codtecnico & "','" & _DescripcionProducto &
                                       "','" & _CodBarras & "',getdate(),'" & _Unidad_Medida & "'," & _CantidadInventariada &
                                       ",1,'" & _Observaciones &
                                       "','" & _Responsable & "','" & _Contador_1 & "','" & _Contador_2 &
                                       "','','" & _CodUbicacion & "','" & _Fila & "','" & _Columna & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()
                        Contador += 1

                    End If

                End With

            Next

            If CBool(Contador) Then
                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            Else
                MessageBoxEx.Show("No existen datos que guardar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                myTrans.Rollback()
                Return
            End If

            MessageBoxEx.Show("NUMERO DE HOJA: " & _Nro_Hoja, "INVENTARIO INGRESADO AL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Dim dlg As System.Windows.Forms.DialogResult =
                     MessageBoxEx.Show(Me, "¿DESEA SEGUIR INGRESANDO MAS HOJAS CON EL MISMO DIGITADOR :" & vbCrLf &
                                       Trim(Nombre_funcionario_activo) & "?" & vbCrLf & vbCrLf &
                                       "RECUERDE EL ULTIMO NUMERO DE HOJA ES : " & _Nro_Hoja,
                                       "INVENTARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            Nueva_Hoja(True)

            If dlg = System.Windows.Forms.DialogResult.Yes Then
                dlg =
                     MessageBoxEx.Show(Me, "¿Desea mantener los contadores?" & vbCrLf &
                                       "Contador 1: " & _Contador_1 & vbCrLf &
                                       "Contador 2: " & _Contador_2,
                                       "INVENTARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If dlg = System.Windows.Forms.DialogResult.Yes Then
                    Grilla_Enc.Rows(0).Cells("Contador_1").Value = _Contador_1
                    Grilla_Enc.Rows(0).Cells("Contador_2").Value = _Contador_2
                End If
            Else
                Me.Close()
            End If

        Catch ex As Exception

            MessageBoxEx.Show(ex.Message, "Error",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            myTrans.Rollback()

            MessageBoxEx.Show("Transaccion desecha", "Problema",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

        End Try
    End Sub

    Private Sub Grilla_Inv_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Inv.CellEndEdit
        Try
            With Grilla_Inv
                Dim Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
                Dim Codigo As String = NuloPorNro(.Rows(.CurrentRow.Index).Cells("Codproducto").Value, "")

                Dim _Valor As String = NuloPorNro(.Rows(.CurrentRow.Index).Cells(Cabeza).Value, "")

                If (Cabeza = "CodUbicacion") And Not String.IsNullOrEmpty(Trim(Codigo)) Then

                    Dim _CodUbic As Integer

                    Try
                        _CodUbic = _Valor
                    Catch ex As Exception
                        _CodUbic = 0
                    End Try

                    Consulta_sql = "SELECT CodSector, IdUbicacion, Columna, Fila, Alto, Largo, Ancho, Peso_Max, Desc_Ubicacion" & vbCrLf &
                           "FROM Zw_Tbl_SecXBod_Ubicaciones" & vbCrLf &
                           "Where CodSector = '" & _CodSectorInt & "' And IdUbicacion = " & _CodUbic
                    Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

                    If CBool(_Tbl.Rows.Count) Then
                        Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Columna").Value =
                        _Tbl.Rows(0).Item("Columna")
                        Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Fila").Value =
                        _Tbl.Rows(0).Item("Fila")
                        Grilla_Inv.CurrentCell =
                        Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CantidadInventariada")
                    Else
                        MessageBoxEx.Show("¡No existe ubicación o no pertenece a este sector!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Columna").Value = String.Empty
                        Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Fila").Value = String.Empty
                        Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CodUbicacion").Value = String.Empty
                        Grilla_Inv.CurrentCell = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Columna")

                        'SendKeys.Send("{F2}")
                    End If

                ElseIf (Cabeza = "Columna") And Not String.IsNullOrEmpty(Trim(Codigo)) Then

                    Grilla_Inv.CurrentCell = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Fila")
                    'SendKeys.Send("{F2}")

                ElseIf (Cabeza = "Fila") And Not String.IsNullOrEmpty(Trim(Codigo)) Then

                    Grilla_Inv.CurrentCell = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CantidadInventariada")
                    'SendKeys.Send("{F2}")

                ElseIf (Cabeza = "CantidadInventariada") And Not String.IsNullOrEmpty(Trim(Codigo)) Then

                    'Grilla_Inv.CurrentCell = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Codproducto")
                    'SendKeys.Send("{F2}")

                End If
            End With
        Catch ex As Exception

        End Try

    End Sub



    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click

        'Ds_Inventario.Clear()

        Consulta_sql = "SELECT * FROM ZW_TmpInvProductosInventariados Where Nro_Hoja = 11"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Grilla_Inv.DataSource = _Tbl


        With Grilla_Enc
            .DataSource = Nothing
            .DataSource = Ds_Inventario '.Tables("DetalleDocumento")
            .DataMember = Ds_Inventario.Tables("Hoja_Conteo_Encabezado").TableName
            .ScrollBars = ScrollBars.None
        End With

        Formato_Grilla()

    End Sub

    Private Sub Frm_HojaConteo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Grilla_Inv.RowCount > 0 Then
            Dim dlg As System.Windows.Forms.DialogResult = MessageBoxEx.Show(Me, "¿Desea salir sin grabar, se perderan los cambios?", "Cerrar formulario", MessageBoxButtons.YesNo)

            If dlg = System.Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BtnImportarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportarDatos.Click
        Try

            'Dim Fm As New Frm_SeleccionarTipoBusquedaCodProducto
            'Fm.ShowDialog(Me)

            'f Not Fm._Aceptado Then
            'MessageBoxEx.Show("No se selecciono ningún tipo de código para el levantamiento", _
            '                      "Tipo de código", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ' Return
            'End If

            Dim _CantProd As Integer


            _CantProd = Ds_Inventario.Tables("Hoja_Conteo_Detalle").Compute("Count(Codproducto)",
                                                                            "Nuevo_Producto = 0")

            If CBool(_CantProd) Then
                Dim dlg As System.Windows.Forms.DialogResult =
                MessageBoxEx.Show(Me, "Existen productos en la lista, se quitaran si continua" & vbCrLf &
                                  "¿Desea continuar con esta acción?", "Cerrar formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If dlg = System.Windows.Forms.DialogResult.No Then
                    Return
                End If
            End If

            _Cancelar_LevMasivo = False

            Dim _Levantado As Boolean = True
            Dim oFD As New OpenFileDialog
            Dim Nombre_Archivo As String
            Dim Ubicacion_File
            '.Filter = "Ficheros DBF (PFMDSP10.dbf)|PFMDSP10.dbf|Todos (*.*)|*.*"
            '.Filter = "Ficheros DBF (Productos_Aju.xls)|Productos_Aju.xls|Productos_Aju.xlsx"

            oFD.FileName = String.Empty

            If oFD.ShowDialog = DialogResult.OK Then
                Nombre_Archivo = oFD.SafeFileName
                Ubicacion_File = oFD.FileName
                BtnCancelarImp.Visible = True
            Else
                Return
            End If


            Dim ImpEx As New Class_Importar_Excel
            Dim Extencion As String = Replace(System.IO.Path.GetExtension(Nombre_Archivo), ".", "")
            Dim Arreglo = ImpEx.Importar_Excel_Array(Ubicacion_File, Extencion)

            Dim Filas = Arreglo.GetUpperBound(0)
            Dim RegInsert As Long = 0

            'CirculoProgreso.Maximum = 100
            'Progreso_Cont.Maximum = Filas 'Dst_Impotar.Tables("Inv_InvParcial").Rows.Count

            If Filas <= 1 Then
                MessageBoxEx.Show("No existen datos que levantar!!", "Unificar productos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim Contador As Integer = 0
            CirculoProgreso.Maximum = 100

            DeshabilitarObjetos(False)
            CirculoProgreso.Value = 0

            Dim _Encontrados As Long = 0
            Dim _NoEncontrados As Long = 0

            Nueva_Hoja(False)


            For i = 1 To Filas
                'Zzz_TblPasoFO()
                System.Windows.Forms.Application.DoEvents()

                Dim _CodUbic As String = Trim(Arreglo(i, 0))  ' Código Ubicación
                Dim _CodigoPr As String = Trim(Arreglo(i, 1)) ' Código producto
                Dim _Cantidad As Double = De_Txt_a_Num_01(Trim(Arreglo(i, 2)), 5) ' Cantidad inventariada

                'If Fm.RdbCodPrincipal.Checked Then
                'Consulta_sql = "SELECT * FROM MAEPR WHERE KOPR = '" & _CodigoPr & "'"
                'ElseIf Fm.RdbCodRapido.Checked Then
                'Consulta_sql = "SELECT * FROM MAEPR WHERE KOPRRA = '" & _CodigoPr & "'"
                'ElseIf Fm.RdbCodTecnico.Checked Then
                'Consulta_sql = "SELECT * FROM MAEPR WHERE KOPRTE = '" & _CodigoPr & "'"
                'ElseIf Fm.RdbCodAlternativo.Checked Then
                '_CodigoPr = _Sql.Fx_Trae_Dato(, "KOPR", "TABCODAL", "KOPRAL = '" & _CodigoPr & "' AND KOEN = ''")
                'Consulta_sql = "SELECT * FROM MAEPR WHERE KOPR = '" & _CodigoPr & "'"
                'End If

                Dim _CodPrincipal,
                    _CodRapido,
                    _CodTecnico,
                    _CodAlternativo,
                    _Descripcion,
                    _Und,
                    _CodUbicacion,
                    _Columna,
                    _Fila As String

                Dim _TblInfProd As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblInfProd.Rows.Count) Then


                    _CodPrincipal = Trim(_TblInfProd.Rows(0).Item("KOPR"))
                    _CodRapido = Trim(_TblInfProd.Rows(0).Item("KOPRRA"))
                    _CodTecnico = Trim(_TblInfProd.Rows(0).Item("KOPRTE"))

                    _CodAlternativo = _Sql.Fx_Trae_Dato("TABCODAL", "KOPRAL",
                                                "KOPR = '" & _CodigoPr & "' AND KOEN = ''")

                    _Descripcion = _TblInfProd.Rows(0).Item("NOKOPR")
                    _Und = _TblInfProd.Rows(0).Item("UD01PR")

                    If _Cancelar_LevMasivo Then

                        Dim dlg As System.Windows.Forms.DialogResult =
                                        MessageBoxEx.Show(Me,
                                        "¿Esta seguro de cancelar esta acción?",
                                        "Cancelar", MessageBoxButtons.YesNo)

                        If dlg = System.Windows.Forms.DialogResult.Yes Then
                            DeshabilitarObjetos(True)
                            Exit For
                        Else
                            _Cancelar_LevMasivo = False
                        End If

                    End If
                    _Encontrados += 1
                Else

                    _CodPrincipal = "@@DESCONOCIDO"
                    _CodRapido = String.Empty
                    _CodTecnico = String.Empty
                    _CodAlternativo = String.Empty
                    _Descripcion = "PRODUCTO DESCONOCIDO XXXXXXXXXXXXXXXXXXXXXXXXXXXXZ"
                    _Und = "UN"

                    _NoEncontrados += 1
                End If

                Consulta_sql = "SELECT Columna, Fila FROM Zw_Tbl_SecXBod_Ubicaciones" & vbCrLf &
                               "Where CodSector = '" & _CodSectorInt & "' And IdUbicacion = " & _CodUbic

                Dim _TblUbic As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblUbic.Rows.Count) Then
                    _Columna = _TblUbic.Rows(0).Item("Columna")
                    _Fila = _TblUbic.Rows(0).Item("Fila")
                    _CodUbicacion = _CodUbic
                Else
                    _Columna = String.Empty
                    _Fila = String.Empty
                    _CodUbicacion = String.Empty
                End If

                Dim _Item_Hoja As String = numero_(i, 2)

                Dim NewFila As DataRow
                NewFila = Ds_Inventario.Tables("Hoja_Conteo_Detalle").NewRow
                With NewFila

                    .Item("IdInventario") = _IdInventario_Activo
                    .Item("Ano") = _Ano
                    .Item("Mes") = _Mes
                    .Item("Dia") = _Dia
                    .Item("Item_Hoja") = _Item_Hoja
                    .Item("CodEmpresa") = _Empresa_Inv_Activo
                    .Item("CodSucursal") = _Sucursal_Inv_Activo
                    .Item("CodBodega") = _Bodega_Inv_Activo
                    .Item("Codproducto") = _CodPrincipal
                    .Item("Codrapido") = _CodRapido
                    .Item("Codtecnico") = _CodTecnico
                    .Item("CodBarras") = _CodAlternativo
                    .Item("DescripcionProducto") = _Descripcion
                    .Item("Unidad_Medida") = _Und

                    .Item("FechaInventario") = Now.Date
                    .Item("CodUbicacion") = _CodUbicacion
                    .Item("Columna") = _Columna
                    .Item("Fila") = _Fila
                    .Item("CodigoLeidoArchTxt") = _CodigoPr
                    .Item("CantidadInventariada") = _Cantidad
                    .Item("Observaciones") = String.Empty
                    .Item("TipoConteo") = "E"

                    Ds_Inventario.Tables("Hoja_Conteo_Detalle").Rows.Add(NewFila)

                End With

                Lblestado.Text = "Encontrados " & FormatNumber(_Encontrados, 0) &
                                 ", No encontrados " & FormatNumber(_NoEncontrados, 0) &
                                 ", Total: " & FormatNumber(Filas, 0)
                Contador += 1
                CirculoProgreso.Value = ((Contador * 100) / Filas)

            Next

            CirculoProgreso.Value = 0

            If _Levantado Then
                MessageBoxEx.Show(Filas & " Productos Incorporados correctamente",
                                  "Levantar productos", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            DeshabilitarObjetos(True)

        Catch ex As Exception
            DeshabilitarObjetos(True)
            MsgBox(ex.Message)
        End Try

    End Sub


    Sub DeshabilitarObjetos(ByVal Estado As Boolean)

        BtnGrabar.Enabled = Estado
        GrupoEnc.Enabled = Estado
        GrupoDet.Enabled = Estado
        BtnLimpiar.Enabled = Estado
        BtnSalir.Enabled = Estado

        If Estado Then
            BtnCancelarImp.Visible = False
            CirculoProgreso.Visible = False
            Lblestado.Visible = False
        Else
            BtnCancelarImp.Visible = True
            Lblestado.Visible = True
            CirculoProgreso.Visible = True
        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Grilla_Inv_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla_Inv.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Codigo = NuloPorNro(.Rows(.CurrentRow.Index).Cells("Codproducto").VALUE, "")
                    ContextMenuStrip1.Enabled = True

                    If String.IsNullOrEmpty(_Codigo) Then
                        BtnMnuBuscarProducto.Text = "Buscar producto"
                    Else
                        'ContextMenuStrip1.Enabled = True
                        BtnMnuBuscarProducto.Text = "Cambiar producto..."
                    End If
                Else
                    ContextMenuStrip1.Enabled = False
                End If
            End With
        End If
    End Sub

    Private Sub BtnMnuBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMnuBuscarProducto.Click
        Dim _Codigo = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Codproducto").Value, "")

        If Not String.IsNullOrEmpty(Trim(_Codigo)) Then
            Dim dlg As System.Windows.Forms.DialogResult =
            MessageBoxEx.Show(Me, "ESTA ACCION MODIFICARA EL PRODUCTO DE LA LINEA?" & vbCrLf &
                              "¿ESTA SEGURO DE QUERER SEGUIR CON LA ACCION?",
                              "MODIFICAR PRODUCTO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            If dlg = System.Windows.Forms.DialogResult.Cancel Then
                Return
            End If
        End If

        Buscar_Producto()

    End Sub

    Private Sub BtnMnuIncorpProductoDesconocido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMnuIncorpProductoDesconocido.Click

        Dim _Indice_Grilla = Grilla_Inv.CurrentRow.Index
        Dim _Descripcion As String
        Dim _Nuevo_Producto As Boolean = Grilla_Inv.Rows(_Indice_Grilla).Cells("Nuevo_Producto").Value


        Dim _Item_Hoja As String
        'numero_(Grilla_Inv.RowCount, 2)
        Dim _Codigo = "@@DESCONOCIDO"

        If _Nuevo_Producto Then
            _Item_Hoja = numero_(Grilla_Inv.RowCount, 2)
        Else
            _Item_Hoja = Grilla_Inv.Rows(_Indice_Grilla).Cells("Item_Hoja").Value
        End If

        With Grilla_Inv

            .Rows(_Indice_Grilla).Cells("IdInventario").Value = _IdInventario_Activo
            .Rows(_Indice_Grilla).Cells("Ano").Value = _Ano
            .Rows(_Indice_Grilla).Cells("Mes").Value = _Mes
            .Rows(_Indice_Grilla).Cells("Dia").Value = _Dia

            .Rows(_Indice_Grilla).Cells("Item_Hoja").Value = _Item_Hoja
            .Rows(_Indice_Grilla).Cells("Nuevo_Producto").Value = False

            .Rows(_Indice_Grilla).Cells("CodEmpresa").Value = _Empresa_Inv_Activo
            .Rows(_Indice_Grilla).Cells("CodSucursal").Value = _Sucursal_Inv_Activo
            .Rows(_Indice_Grilla).Cells("CodBodega").Value = _Bodega_Inv_Activo

            .Rows(_Indice_Grilla).Cells("Codproducto").Value = _Codigo
            .Rows(_Indice_Grilla).Cells("Codrapido").Value = String.Empty
            .Rows(_Indice_Grilla).Cells("Codtecnico").Value = String.Empty

            If _Codigo = "@@DESCONOCIDO" Then
                _Descripcion = "PRODUCTO DESCONOCIDO"
                _Descripcion = InputBox("Ingrese la descripción de este producto",
                                        "Cambiar descripción", "PRODUCTO DESCONOCIDO")
            End If

            .Rows(_Indice_Grilla).Cells("DescripcionProducto").Value = UCase(_Descripcion)
            .Rows(_Indice_Grilla).Cells("Unidad_Medida").Value = "UN"

            .Rows(_Indice_Grilla).Cells("FechaInventario").Value = Now.Date
            .Rows(_Indice_Grilla).Cells("Observaciones").Value = String.Empty
            .Rows(_Indice_Grilla).Cells("TipoConteo").Value = "M"

        End With

        Grilla_Inv.CurrentCell = Grilla_Inv.Rows(_Indice_Grilla).Cells("CodUbicacion")
    End Sub

    Private Sub BtnMnuCambiarDescProductoDesconocido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMnuCambiarDescProductoDesconocido.Click

        Dim _Indice_Grilla = Grilla_Inv.CurrentRow.Index
        Dim _Codigo As String = Grilla_Inv.Rows(_Indice_Grilla).Cells("CodProducto").Value
        Dim _Descripcion = Grilla_Inv.Rows(_Indice_Grilla).Cells("DescripcionProducto").Value

        If _Codigo = "@@DESCONOCIDO" Then
            _Descripcion = InputBox("Ingrese la descripción de este producto",
                                    "Cambiar descripción", _Descripcion)
            Grilla_Inv.Rows(_Indice_Grilla).Cells("DescripcionProducto").Value = UCase(_Descripcion)
        Else
            MessageBoxEx.Show("¡Esta opción es solo para productos desconocidos!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub
End Class
