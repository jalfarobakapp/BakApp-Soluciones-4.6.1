'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Inf_Ventas_X_Vendedor_01

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Filtro As New DS_Filtro_Venta_Vendedor
    Dim _Tbl_Vendedores, _Tbl_Documentos, _Tbl_Sucursales As DataTable
    Dim _Filtro_Vendedores, _Filtro_Documentos, _Filtro_Sucursales As String
    Dim _Directorio As String = AppPath() & "\Data\" & RutEmpresa & "\Filtro_Informes" '"\DstSolComprasParam"


    Private Sub Frm_Inf_Ventas_X_Vendedor_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dtp_Fecha_Estudio_desde.Value = Primerdiadelmes(FechaDelServidor)
        Dtp_Fecha_Estudio_hasta.Value = FechaDelServidor()

        '_Filtro_Vendedores = Generar_Filtro_IN(_Tbl_Vendedores,"",
        AddHandler Rdb_Vendedores_Algunos.CheckedChanged, AddressOf Sb_Rdb_Vendedores_Algunos_CheckedChanged
        AddHandler Rdb_Documentos_Algunos.CheckedChanged, AddressOf Sb_Rdb_Documentos_Algunos_CheckedChanged
        AddHandler Rdb_Sucursales_Algunos.CheckedChanged, AddressOf Sb_Rdb_Sucursales_Algunos_CheckedChanged

    End Sub


    Private Sub Frm_Inf_Ventas_X_Vendedor_01_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Procesar.Click

        Dim _TblVentas_X_vendedor As DataTable
        _TblVentas_X_vendedor = Fx_Informe_X_Vendedor(Dtp_Fecha_Estudio_desde.Value,
                                                      Dtp_Fecha_Estudio_hasta.Value,
                                                      _Tbl_Vendedores,
                                                      _Tbl_Sucursales,
                                                      _Tbl_Documentos)

        If Not (_TblVentas_X_vendedor Is Nothing) Then

            If CBool(_TblVentas_X_vendedor.Rows.Count) Then

                Dim Fm As New Frm_Inf_Ventas_X_Vendedor_02
                Fm._TblVentas_X_vendedor = _TblVentas_X_vendedor
                Fm._Titulo_Del_Grafico = "Ventas entre " &
                                          FormatDateTime(Dtp_Fecha_Estudio_desde.Value, DateFormat.ShortDate) &
                                          " - " & FormatDateTime(Dtp_Fecha_Estudio_hasta.Value, DateFormat.ShortDate)

                Fm.ShowDialog(Me)

            Else

                MessageBoxEx.Show(Me, "No hay datos que mostrar", "Informe de ventas por vendedor",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)


            End If
        End If
    End Sub


    Function Fx_Informe_X_Vendedor(ByVal _Fecha_Desde As Date,
                                   ByVal _Fecha_Hasta As Date,
                                   ByVal _Tbl_Filtro_Vendedores As DataTable,
                                   ByVal _Tbl_Filtro_Sucursales As DataTable,
                                   ByVal _Tbl_Filtro_Documentos As DataTable) As DataTable

        Dim _FDesde = Format(_Fecha_Desde, "yyyyMMdd")
        Dim _FHasta = Format(_Fecha_Hasta, "yyyyMMdd")

        Dim _Filtro_Sucursales = String.Empty
        Dim _Filtro_Vendedores = String.Empty
        Dim _Filtro_Documentos = "And EDO.TIDO IN ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX'," &
                                 "'FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','GDV'," &
                                 "'NCE','NCV','NCX','NCZ','NEV','RIN')"

        If Rdb_Vendedores_Algunos.Checked Then
            If CBool(_Tbl_Filtro_Vendedores.Rows.Count) Then
                _Filtro_Vendedores = Generar_Filtro_IN(_Tbl_Filtro_Vendedores, "", "Codigo", False, False, "'")
                _Filtro_Vendedores = "And DDO.KOFULIDO In " & _Filtro_Vendedores & vbCrLf
            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY VENDEDORES SELECCIONADOS", My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Return Nothing
            End If
        End If

        If Rdb_Sucursales_Algunos.Checked Then
            If CBool(_Tbl_Filtro_Sucursales.Rows.Count) Then
                _Filtro_Sucursales = Generar_Filtro_IN(_Tbl_Filtro_Sucursales, "", "Codigo", False, False, "'")
                _Filtro_Sucursales = "And EDO.SUDO In " & _Filtro_Sucursales & vbCrLf
            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY SUCURSALES SELECCIONADAS", My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Return Nothing
            End If
        End If

        If Rdb_Documentos_Algunos.Checked Then
            If CBool(_Tbl_Filtro_Documentos.Rows.Count) Then
                _Filtro_Documentos = Generar_Filtro_IN(_Tbl_Filtro_Documentos, "", "Codigo", False, False, "'")
                _Filtro_Documentos = "And EDO.TIDO In " & _Filtro_Documentos & vbCrLf
            Else
                Beep()
                ToastNotification.Show(Me, "NO HAY DOCUMENTOS SELECCIONADOS", My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Return Nothing
            End If
        End If

        Consulta_sql = My.Resources.Recuros_InfVtasXvendedor.SQLQuery_Informe_de_ventas_por_vendedor_detalle & vbCrLf & vbCrLf
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Empresa#", "And EDO.EMPRESA='" & Mod_Empresa & "'")
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Sucursales#", _Filtro_Sucursales)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Fecha#", "And EDO.FEEMDO BETWEEN '" & _FDesde & "' And '" & _FHasta & "'")
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Vendedor#", _Filtro_Vendedores)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Documentos#", _Filtro_Documentos)

        Consulta_sql += My.Resources.Recuros_InfVtasXvendedor.SQLQuery_Informe_de_ventas_por_vendedor_resumen

        Dim _Tbl As DataTable

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _Tbl

    End Function

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        If Not Directory.Exists(_Directorio) Then
            Directory.CreateDirectory(_Directorio)
        End If

        Dim exists = File.Exists(_Directorio & "\DS_Filtro_Venta_Vendedor.xml")

        If exists Then
            _Ds_Filtro.ReadXml(_Directorio & "\DS_Filtro_Venta_Vendedor.xml")
            With _Ds_Filtro.Tables("Tbl_Opciones").Rows(0)
                Rdb_Vendedores_Todos.Checked = .Item("Rdb_Vendedores_Todos")
                Rdb_Vendedores_Algunos.Checked = .Item("Rdb_Vendedores_Algunos")

                Rdb_Sucursales_Todos.Checked = .Item("Rdb_Sucursales_Todos")
                Rdb_Sucursales_Algunos.Checked = .Item("Rdb_Sucursales_Algunos")

                Rdb_Documentos_Todos.Checked = .Item("Rdb_Documentos_Todos")
                Rdb_Documentos_Algunos.Checked = .Item("Rdb_Documentos_Algunos")
            End With
        Else
            _Ds_Filtro.WriteXml(_Directorio & "\DS_Filtro_Venta_Vendedor.xml")
        End If

        Dim _Ds As New DS_Filtro_Venta_Vendedor

        _Ds.ReadXml(_Directorio & "\DS_Filtro_Venta_Vendedor.xml")

        _Tbl_Vendedores = _Ds.Tables("Tbl_Vendedores")
        _Tbl_Sucursales = _Ds.Tables("Tbl_Sucursales")
        _Tbl_Documentos = _Ds.Tables("Tbl_Documentos")

    End Sub

    Sub Sb_Rdb_Vendedores_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Rdb_Vendedores_Algunos.Checked Then
            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
            Fm.Pro_Tbl_Filtro = _Tbl_Vendedores
            Fm.Text = "VENDEDORES"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Tbl_Vendedores = Fm.Pro_Tbl_Filtro
                Sb_Actualizar_Filtros()
            Else
                If Not Fm._Viene_Con_Filtros Then
                    Rdb_Vendedores_Todos.Checked = True
                End If
            End If

        End If
    End Sub

    Sub Sb_Rdb_Documentos_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Rdb_Documentos_Algunos.Checked Then
            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Documentos)
            'Fm._Tabla_a_Filtras = Frm_Filtro_Especial_Informes._Tabla_Fl._Documentos_Venta
            Fm.Pro_Tbl_Filtro = _Tbl_Documentos
            Fm.Text = "DOCUMENTOS DE VENTA"
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And TIDO In ('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX'," &
                                                "'FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','GDV'," &
                                                "'NCE','NCV','NCX','NCZ','NEV','RIN')"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Tbl_Documentos = Fm.Pro_Tbl_Filtro
            Else
                If Not Fm._Viene_Con_Filtros Then
                    Rdb_Documentos_Todos.Checked = True
                End If
            End If

        End If
    End Sub

    Private Sub Frm_Inf_Ventas_X_Vendedor_01_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Actualizar_Filtros()
    End Sub

    Sub Sb_Rdb_Sucursales_Algunos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Rdb_Sucursales_Algunos.Checked Then
            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Sucursales)
            Fm.Pro_Tbl_Filtro = _Tbl_Sucursales
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And EMPRESA = '" & Mod_Empresa & "'"
            Fm.Text = "SUCURSALES"
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                _Tbl_Sucursales = Fm.Pro_Tbl_Filtro
            Else
                If Not Fm._Viene_Con_Filtros Then
                    Rdb_Sucursales_Todos.Checked = True
                End If
            End If

        End If
    End Sub

    Sub Sb_Insertar_Fila_Tabla_Filtro(ByVal _Tbl As DataTable,
                                      ByVal _Codigo As String,
                                      ByVal _Descripcion As String)

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow

        With NewFila

            .Item("Chk") = True
            .Item("Codigo") = _Codigo
            .Item("Descripcion") = _Descripcion

        End With

        _Tbl.Rows.Add(NewFila)

    End Sub

    Private Sub Btn_Modificar_Filtros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modificar_Filtros.Click
        If Fx_Tiene_Permiso(Me, "Inf00011") Then
            Grupo_Vendedores.Enabled = True
            Grupo_Documentos.Enabled = True
            Grupo_Sucursales.Enabled = True
        End If
    End Sub


    Sub Sb_Actualizar_Filtros()


        _Ds_Filtro.Clear()

        Dim NewFila As DataRow
        NewFila = _Ds_Filtro.Tables("Tbl_Opciones").NewRow

        With NewFila

            .Item("Rdb_Vendedores_Todos") = Rdb_Vendedores_Todos.Checked
            .Item("Rdb_Vendedores_Algunos") = Rdb_Vendedores_Algunos.Checked

            .Item("Rdb_Sucursales_Todos") = Rdb_Sucursales_Todos.Checked
            .Item("Rdb_Sucursales_Algunos") = Rdb_Sucursales_Algunos.Checked

            .Item("Rdb_Documentos_Todos") = Rdb_Documentos_Todos.Checked
            .Item("Rdb_Documentos_Algunos") = Rdb_Documentos_Algunos.Checked

        End With

        _Ds_Filtro.Tables("Tbl_Opciones").Rows.Add(NewFila)

        If Rdb_Vendedores_Algunos.Checked Then
            For Each _Fila As DataRow In _Tbl_Vendedores.Rows
                If _Fila.RowState <> DataRowState.Deleted Then
                    If _Fila.Item("Chk") Then
                        Sb_Insertar_Fila_Tabla_Filtro(_Ds_Filtro.Tables("Tbl_Vendedores"), _Fila.Item("Codigo"), _Fila.Item("Descripcion"))
                    End If
                End If
            Next
        End If

        If Rdb_Sucursales_Algunos.Checked Then
            For Each _Fila As DataRow In _Tbl_Sucursales.Rows
                If _Fila.RowState <> DataRowState.Deleted Then
                    If _Fila.Item("Chk") Then
                        Sb_Insertar_Fila_Tabla_Filtro(_Ds_Filtro.Tables("Tbl_Sucursales"), _Fila.Item("Codigo"), _Fila.Item("Descripcion"))
                    End If
                End If
            Next
        End If


        If Rdb_Documentos_Algunos.Checked Then
            For Each _Fila As DataRow In _Tbl_Documentos.Rows
                If _Fila.RowState <> DataRowState.Deleted Then
                    If _Fila.Item("Chk") Then
                        Sb_Insertar_Fila_Tabla_Filtro(_Ds_Filtro.Tables("Tbl_Documentos"), _Fila.Item("Codigo"), _Fila.Item("Descripcion"))
                    End If
                End If
            Next
        End If

        _Ds_Filtro.WriteXml(_Directorio & "\DS_Filtro_Venta_Vendedor.xml")

    End Sub

End Class