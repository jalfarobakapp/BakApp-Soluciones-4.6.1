'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms


Public Class Frm_03_Sectores_Inv

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _IdInventario As String
    Public Sector As String
    Public CodigoUbicacion As String
    Public NombreUbicacion As String
    Public _IngresarHoja As Boolean

    Public _Empresa, _Sucursal, _Bodega As String
    Public _ValidaEstado As Boolean

    Private Sub Frm_Sectores_Inv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualizar_Grilla("")
        Me.ActiveControl = Txtdescripcion

    End Sub

    Sub Actualizar_Grilla(ByVal Ubicacion As String)

        Dim Datos_a_buscar As String
        Dim Descripcion As String = Trim(Txtdescripcion.Text)

        Datos_a_buscar = CADENA_A_BUSCAR(Descripcion, _
                                         "CodSectorInt+CodigoUbicacion+UbicacionBodega" & " LIKE '%")

        Dim Des1 = CADENA_A_BUSCAR(RTrim$(Descripcion), "CodSector+Lugar_+Sector_ LIKE '%")
        Dim Condi = "And  CodSector+Lugar_+Sector_ like '%" & Des1 & "%'"

        Consulta_sql = "SELECT Case When (SELECT COUNT(*) FROM ZW_TmpInvSectores_Cerrados Zc" & vbCrLf & _
                       "WHERE IdInventario = " & _IdInventario & " And Zc.CodSector = Zw_Tbl_SecXBod_.CodSector) > 0 then 'Cerrado'" & vbCrLf & _
                       "Else 'Abierto' end as Estado," & vbCrLf & _
                       "Isnull((Select top 1 CodFuncionario From ZW_TmpInvSectorVsFuncionarios" & vbCrLf & _
                       "Where IdInventario = " & _IdInventario & _
                       " And CodSector = Zw_Tbl_SecXBod_.CodSector),'') as CodFun," & vbCrLf & _
                       "Isnull((Select top 1 NombreFuncionario From ZW_TmpInvSectorVsFuncionarios" & vbCrLf & _
                       "Where IdInventario = " & _IdInventario & _
                       " And CodSector = Zw_Tbl_SecXBod_.CodSector),'No tiene usuario asignado') as NomFun," & vbCrLf & _
                       "Ltrim(Rtrim(Lugar_))+', '+Ltrim(Rtrim(Sector_)) as Descripcion,* FROM Zw_Tbl_SecXBod_" & vbCrLf & _
                       "Where Empresa = '" & _Empresa & _
                       "' And Sucursal = '" & _Sucursal & _
                       "' And Bodega = '" & _Bodega & "'" & vbCrLf & _
                       Condi & vbCrLf & _
                       "Order by Descripcion"

        Grilla_Inv.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)


        With Grilla_Inv

            OcultarEncabezadoGrilla(Grilla_Inv, True)
            '.Columns("Semilla").Visible = False

            .Columns("CodSector").Width = 100
            .Columns("CodSector").HeaderText = "Cód. Sector"
            .Columns("CodSector").Visible = True
            .Columns("CodSector").Frozen = True
            .Columns("CodSector").DisplayIndex = 0
            .Columns("CodSector").Visible = True

            .Columns("Lugar_").Width = 200
            .Columns("Lugar_").HeaderText = "Lugar"
            .Columns("Lugar_").Visible = True
            .Columns("Lugar_").Frozen = True
            .Columns("Lugar_").DisplayIndex = 1
            .Columns("Lugar_").Visible = True

            .Columns("Sector_").Width = 200
            .Columns("Sector_").HeaderText = "Nombre Sector"
            .Columns("Sector_").Visible = True
            .Columns("Sector_").Frozen = True
            .Columns("Sector_").DisplayIndex = 2
            .Columns("Sector_").Visible = True

            .Columns("Estado").Width = 100
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = True
            .Columns("Estado").Frozen = True
            .Columns("Estado").DisplayIndex = 3
            .Columns("Estado").Visible = True


        End With

    End Sub

    Private Sub Txtdescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdescripcion.TextChanged
        Actualizar_Grilla(Trim(Txtdescripcion.Text))
    End Sub


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
       Sb_Formato_Generico_Grilla(Grilla_Inv, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)

    End Sub

    Private Sub Grilla_Inv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Inv.CellDoubleClick
        If _IngresarHoja Then
            SemillaUbicacion_Inv = Nothing

            Sector = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CodSector").Value
            Dim _Estado = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Estado").Value
            NombreUbicacion = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Descripcion").Value

            If _ValidaEstado Then
                If _Estado = "Cerrado" Then
                    MessageBoxEx.Show("¡SECTOR CERRADO!" & vbCrLf & _
                                      "No se pueden ingresar hojas de conteo a un sector cerrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

            Me.Close()
        End If
    End Sub

    Private Sub BtnBuscarProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarProductos.Click
        Dim Fm As New Frm_BuscarXProducto_Mt
        Fm.CodProveedor_productos = String.Empty
        Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
        Fm.ListaDePrecio = ModListaPrecioVenta
        Fm.CodProveedor_productos = String.Empty
        Fm.MostrarOcultos = True
        Fm.BtnBusAlternativas.Visible = True
        Fm.BtnBusAlternativas.Text = "Buscar código alternativo"
        Fm.ShowDialog(Me)
        Codigo_abuscar = String.Empty
    End Sub

    Private Sub VerProductosContadosEnEsteSectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerProductosContadosEnEsteSectorToolStripMenuItem.Click
        Dim _CodFun As String = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CodFun").Value
        Dim _Usuario = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("NomFun").Value, "")
        Dim _Lugar = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Lugar_").Value, "")
        Dim _Sector = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Sector_").Value, "")


        If String.IsNullOrEmpty(_CodFun) Then
            MessageBoxEx.Show("No existe usuario asignado al sector" & vbCrLf & _
                              "Debe asignar un usuario para poder realizar esta acción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_04_Productos_por_sector

        Dim _Cs As String = Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CodSector").Value

        Fm._IdInventario = _IdInventario
        Fm._CodSector = _Cs
        Fm._Nombre_Lugar = _Lugar
        Fm._Codigo_Sector = _Sector
        Fm._FuncionarioCargo = _Usuario

        If CBool(Fm.Act_Grilla()) Then
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show("No existen datos que mostrar", "Productos inventariados por sector", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Grilla_Inv_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla_Inv.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _CodSector = NuloPorNro(.Rows(.CurrentRow.Index).Cells("CodSector").VALUE, "")

                    If String.IsNullOrEmpty(_CodSector) Then
                        ContextMenuStrip1.Enabled = False
                    Else
                        Dim Estado = NuloPorNro(.Rows(.CurrentRow.Index).Cells("Estado").VALUE, "")
                        If Estado = "Abierto" Then
                            AbrirCerrarSectorToolStripMenuItem.Text = "Cerrar Sector"
                        Else
                            AbrirCerrarSectorToolStripMenuItem.Text = "Abrir Sector"
                        End If
                        ContextMenuStrip1.Enabled = True
                    End If
                Else
                    ContextMenuStrip1.Enabled = False
                End If
            End With
        End If
    End Sub

    Private Sub AbrirCerrarSectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirCerrarSectorToolStripMenuItem.Click

        Dim _Estado = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Estado").Value, "")
        Dim _CodSector = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CodSector").Value, "")

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then

            If _Estado = "Abierto" Then
                Consulta_sql = "Insert Into ZW_TmpInvSectores_Cerrados (IdInventario,CodSector) " & _
                               "Values (" & _IdInventario & ",'" & _CodSector & "')"
                _Estado = "Cerrado"

            Else
                Consulta_sql = "Delete ZW_TmpInvSectores_Cerrados Where IdInventario = " & _IdInventario & _
                                               " And CodSector = '" & _CodSector & "'"
                _Estado = "Abierto"

            End If

            If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Estado").Value = _Estado
                MessageBoxEx.Show("Sector " & _Estado & " correctamente", "Cambiar estado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
        
    End Sub

    Private Sub AsignarUsuarioAlSectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarUsuarioAlSectorToolStripMenuItem.Click

        'Dim _CodSector = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CodSector").Value, "")
        'Dim _Lugar = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Lugar_").Value, "")
        'Dim _Sector = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("Sector_").Value, "")

        'Dim Fm As New Frm_BuscarFuncionarios

        'Fm.ShowDialog(Me)
        'Dim _CdFun As String = Trim(Fm._CodFuncionarioSelec)
        'Dim _NmFun As String = Trim(Fm._NomFuncionarioSelec)

        'If Not String.IsNullOrEmpty(_CdFun) Then


        'Dim Reg As Integer =_Sql.Fx_Cuenta_Registros("ZW_TmpInvSectorVsFuncionarios", _
        '                                          "IdInventario = " & _IdInventario & _
        '                                          " And CodSector = '" & _CodSector & _
        '                                          "' And CodFuncionario = '" & _CdFun & "'")

        'If CBool(Reg) Then
        'MessageBoxEx.Show("Este usuario ya esta asignado como responzable a este sector", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        'Return
        'Else

        'Dim dlg As System.Windows.Forms.DialogResult = _
        'MessageBoxEx.Show(Me, "Esta seguro de asigna este usuario como responzable al sector?" & vbCrLf & _
        '                                 "Usuario: " & _NmFun & vbCrLf & _
        '                                 "Sector: " & Trim(_Lugar) & ", " & _Sector, _
        '                                 "Asignar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        'If dlg = System.Windows.Forms.DialogResult.Cancel Then
        'Return
        'End If

        'Consulta_sql = "Delete ZW_TmpInvSectorVsFuncionarios Where IdInventario = " & _IdInventario & " And CodSector = '" & _CodSector & "'" & vbCrLf & _
        '                       "Insert Into ZW_TmpInvSectorVsFuncionarios (IdInventario, CodSector, CodFuncionario, NombreFuncionario) Values " & vbCrLf & _
        '                       "(" & _IdInventario & ",'" & _CodSector & "','" & _CdFun & "','" & _NmFun & "')"
        ' If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then
        'MessageBoxEx.Show("Usuario asignado correctamente", "Asignar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("CodFun").Value = _CdFun
        'Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("NomFun").Value = _NmFun

        'LblUsuarioCargo.Text = "Usuario a cargo: " & _NmFun

        'End If
        'End If

        'End If

    End Sub

    Private Sub Grilla_Inv_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Inv.CellEnter

        Dim _Usuario = NuloPorNro(Grilla_Inv.Rows(Grilla_Inv.CurrentRow.Index).Cells("NomFun").Value, "")

        LblUsuarioCargo.Text = "Usuario a cargo: " & _Usuario
    End Sub
End Class