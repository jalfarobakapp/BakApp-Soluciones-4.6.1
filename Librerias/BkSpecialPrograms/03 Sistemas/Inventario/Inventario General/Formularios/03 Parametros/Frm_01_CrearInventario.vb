'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar


Public Class Frm_01_CrearInventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _Empresa_Inv, _
           _Sucursal_Inv, _
           _Bodega_Inv As String

    Public _IdInventario As String

    Public _Actualizar_Lista, _Estado As Boolean

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        If ChkInvGenerado.Checked = False Then
            Grabar()
        Else
            Editar()
        End If

    End Sub


    Sub Editar()

        Dim _Fecha_Inv = Format(DtFechaInv.Value, "yyyyMMdd")

        Consulta_sql = "UPDATE Zw_TmpInv_History Set NombreInventario = '" & TxtNombreInventario.Text & "'" & vbCrLf & _
                       ",FuncionarioCargo = '" & CmbFuncionarios.SelectedValue.ToString & "'" & vbCrLf & _
                       ",NombreFuncionario = '" & Trim(CmbFuncionarios.Text) & "'" & vbCrLf & _
                       "Where IdInventario = " & _IdInventario
        'Fecha_Inventario = '" & _Fecha_Inv & _
        '"' And Empresa = '" & _Empresa_Inv & _
        '"' And Sucursal = '" & _Sucursal_Inv & _
        '"' And Bodega = '" & _Bodega_Inv & "'"

        If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
            MessageBoxEx.Show("Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Actualizar_Lista = True
        End If

    End Sub


    Sub Grabar()

        Dim Fecha_Inv, Ano, Mes, Dia As String
        Dim CodFun, NombreFun As String

        Ano = numero_(DtFechaInv.Value.Year.ToString, 4)
        Mes = numero_(DtFechaInv.Value.Month.ToString, 2)
        Dia = numero_(DtFechaInv.Value.Day.ToString, 2)
        Fecha_Inv = Format(DtFechaInv.Value, "yyyyMMdd")

        If String.IsNullOrEmpty(Trim(TxtNombreInventario.Text)) Then
            MessageBoxEx.Show("Falta nombre de inventario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtNombreInventario.Focus()
            Return
        End If

        Dim Reg As Integer =_Sql.Fx_Cuenta_Registros("Zw_TmpInv_History", "Fecha_Inventario = '" & Fecha_Inv & _
                                              "' And Empresa = '" & _Empresa_Inv & _
                                              "' And Sucursal = '" & _Sucursal_Inv & "'" & vbCrLf & _
                                              "And Bodega = '" & _Bodega_Inv & "'")

        If CBool(Reg) Then
            MessageBoxEx.Show("Ya existe un inventario con esta fecha para esta bodega" & vbCrLf & _
                              "No puede crear dos inventario iguales", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        CodFun = CmbFuncionarios.SelectedValue.ToString
        NombreFun = CmbFuncionarios.Text

        Dim dlg As System.Windows.Forms.DialogResult = _
        MessageBoxEx.Show(Me, "¿Desea dejar este inventario como activo?", "Activar Inventario", MessageBoxButtons.YesNo)

        Dim Activo As Integer = 0

        Consulta_sql = String.Empty

        If dlg = System.Windows.Forms.DialogResult.Yes Then
            Activo = 1
            Consulta_sql = "Update Zw_TmpInv_History Set Estado = 0"
        End If


        Consulta_sql = Consulta_sql & vbCrLf & _
                       "INSERT INTO Zw_TmpInv_History (Ano,Mes,Dia,Fecha_Inventario,Empresa,Sucursal,Bodega," & _
                       "Nombre_Empresa, Nombre_Sucursal, Nombre_Bodega,NombreInventario,FuncionarioCargo,NombreFuncionario,Estado) Values" & vbCrLf & _
                       "('" & Ano & "','" & Mes & "','" & Dia & "','" & Fecha_Inv & _
                       "','" & _Empresa_Inv & "','" & _Sucursal_Inv & "','" & _Bodega_Inv & _
                       "','" & LblEmpresa.Text & "','" & LblSucursal.Text & "','" & LblBodega.Text & _
                       "','" & TxtNombreInventario.Text & _
                       "','" & CodFun & "','" & Trim(NombreFun) & "'," & Activo & ")"

        If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
            MessageBoxEx.Show("Inventario creado correctamente", "Crear inventario", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Actualizar_Lista = True
            Me.Close()
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        caract_combo(CmbFuncionarios)
        Consulta_sql = "SELECT KOFU AS Padre,NOKOFU AS Hijo FROM TABFU" 'ZW_TmpInvFuncionariosLideres"
        CmbFuncionarios.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Private Sub BtnEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstado.Click
        Dim _Fecha_Inv = Format(DtFechaInv.Value, "yyyyMMdd")
        Dim Accion As String
        Dim _Es As Integer

        If _Estado Then
            _Es = 0
            Accion = "Inventario Cerrado correctamente"
        Else
            _Es = 1
            Accion = "Inventario Abierto correctamente"
        End If

        Consulta_sql = "Update Zw_TmpInv_History Set Estado = 0" & vbCrLf & _
                       "UPDATE Zw_TmpInv_History Set Estado = " & _Es & vbCrLf & _
                       "Where IdInventario = " & _IdInventario

        If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
            MessageBoxEx.Show(Accion, _
                              "Editar", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Actualizar_Lista = True
            Me.Close()
        End If

    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click

        If Fx_Tiene_Permiso(Me, "In0006") Then

            Dim DatosFotos As Long
            DatosFotos = _Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario",
                                          "IdInventario = " & _IdInventario)

            If DatosFotos > 0 Then
                MessageBoxEx.Show("No es posible tomar una foto del stock de la bodega, ya que existen datos de una foto anterior." & vbCrLf &
                                  "Para poder obtener una nueva foto debe eliminar el congelado anterior", "Foto Stock", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Return
            End If

            CrearFoto()
            'ActualizarGrillaFoto(Grilla, IdBodega)


        End If
    End Sub


    Private Function CrearFoto()
        Try

            Dim Hora As String
            Hora = Now.Hour.ToString & ":" & Now.Minute.ToString & ":" & Now.Second.ToString


            Dim Tbl As New DataTable
            Consulta_sql = "Select * from Zw_TmpInv_History where IdInventario = " & _IdInventario
            Tbl = _SQL.Fx_Get_Tablas(Consulta_sql)
            Dim Fila As DataRow

            Fila = Tbl.Rows(0)

            Dim Empresa, Sucursal, Bodega As String

            Empresa = Fila.Item("Empresa").ToString
            Sucursal = Fila.Item("Sucursal").ToString
            Bodega = Fila.Item("Bodega").ToString


            Dim Fecha_Inv, Ano, Mes, Dia As String
            Dim CodFun, NombreFun As String

            Ano = numero_(DtFechaInv.Value.Year.ToString, 4)
            Mes = numero_(DtFechaInv.Value.Month.ToString, 2)
            Dia = numero_(DtFechaInv.Value.Day.ToString, 2)
            Fecha_Inv = Format(DtFechaInv.Value, "yyyyMMdd")

      

            Consulta_sql = My.Resources._Procedimientos_Inv.Inv_Invetario_Creae_Foto_Stock
            Consulta_sql = Replace(Consulta_sql, "#Ano#", Ano)
            Consulta_sql = Replace(Consulta_sql, "#Mes#", Mes)
            Consulta_sql = Replace(Consulta_sql, "#Dia#", Dia)
            Consulta_sql = Replace(Consulta_sql, "#IdBodega#", 0)
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", Empresa)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", Sucursal)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", Bodega) '#IdInventario#
            Consulta_sql = Replace(Consulta_sql, "#IdInventario#", _IdInventario)

            If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
                MsgBox("Foto del stock de la bodega creado correctamente", MsgBoxStyle.Information, "Tomar Foto")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function



    Sub EliminarFoto()
        Try

            Dim DatosFotos As Long
            DatosFotos =_Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario", _
                                          "IdInventario = " & _IdInventario)

            If DatosFotos = 0 Then
                MessageBoxEx.Show("No existe ninguna foto que eliminar en la base de datos para esta bodega", _
                                  "Eliminar foto stock", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Return
            End If

            Dim _Autorizado As Boolean

            Dim Fm_Pass As New Frm_Clave_Administrador
            Fm_Pass.ShowDialog(Me)
            _Autorizado = Fm_Pass.Pro_Autorizado
            Fm_Pass.Dispose()

            If _Autorizado Then
                Dim dlg As System.Windows.Forms.DialogResult = _
                MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar la foto tomada del stock de la bodega?" & vbCrLf & _
                          "Nota:El proceso no podrá ser interrumpido y no es posible revertirlo", _
                          "Cerrar Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dlg = System.Windows.Forms.DialogResult.Yes Then
                    Consulta_sql = "DELETE ZW_TmpInvFotoInventario WHERE IdInventario = " & _IdInventario
                     _Sql.Ej_consulta_IDU(Consulta_Sql)

                    MessageBoxEx.Show("Datos eliminados correctamente", "Eliminar foto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If






            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnEliminarFotoStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarFotoStock.Click
        Dim Nro As String = "In0010"
        If Fx_Tiene_Permiso(Me, Nro) Then
            EliminarFoto()
        End If
    End Sub
End Class