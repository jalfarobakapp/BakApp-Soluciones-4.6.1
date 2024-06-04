Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_02_Detalle_Producto_Actual

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Codigo As String
    Private _IdInventario As Integer
    Public _Empresa, _Sucursal, _Bodega As String
    Public _FechaInv As Date
    Public _FStock_Ud1, _Cantidad_Inv, _Dif_Inv_Cantidad As Double

    Public Property Recontado As Boolean

    Public Sub New(_IdInventario As Integer, _Codigo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(GrillaHistoriaProducto, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Me._IdInventario = _IdInventario
        Me._Codigo = _Codigo

        Sb_Color_Botones_Barra(Bar2)

    End Sub
    Private Sub Frm_Detalle_Producto_Actual_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        LblTotalFotoStock.Text = FormatNumber(_FStock_Ud1)
        LblTotalInventariado.Text = FormatNumber(_Cantidad_Inv)
        LblTotalDiferencia.Text = FormatNumber(_Dif_Inv_Cantidad)

        If _Dif_Inv_Cantidad < 0 Then
            LblTotalDiferencia.ForeColor = Rojo
        Else
            LblTotalDiferencia.ForeColor = Verde
        End If

        If String.IsNullOrEmpty(Trim(LblActualizadoPor.Text)) Then
            LabelX3.Visible = False
        End If

        Sb_Ver_Detalle_Del_Producto()

    End Sub
    Private Sub CargaGrillaProductosDesconocidos()

        Try

            Consulta_sql = "SELECT Semilla,SemillaUbicacion, CodigoLeidoArchTxt," & vbCrLf &
                           "UbicacionBodega,Nro_Hoja,Item_Hoja, Fila, Columna, DescripcionProducto, " & vbCrLf &
                           "FechaInventario, CantidadInventariada As Cantidad, Observaciones, Responsable,Contador_1,Contador_2" & vbCrLf &
                           "FROM ZW_TmpInvProductosInventariados" & vbCrLf &
                           "WHERE (Codproducto in ('','@@DESCONOCIDO') " & vbCrLf &
                           "And IdInventario = " & _IdInventario

            GrillaHistoriaProducto.DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

            If GrillaHistoriaProducto.RowCount > 0 Then
                GrillaHistoriaProducto.Columns(0).Visible = False
                GrillaHistoriaProducto.Columns(1).Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GrillaHistoriaProducto_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaHistoriaProducto.CellEnter

        Try

            With GrillaHistoriaProducto

                Dim _Digitador As String = NuloPorNro(.Rows(.CurrentRow.Index).Cells("Digitador").Value, "")
                Dim _Contador_1 As String = .Rows(.CurrentRow.Index).Cells("Contador_1").Value
                Dim _Contador_2 As String = .Rows(.CurrentRow.Index).Cells("Contador_2").Value
                Dim _Actualizado_por As String = .Rows(.CurrentRow.Index).Cells("Actualizado_por").Value
                Dim _Observaciones As String = .Rows(.CurrentRow.Index).Cells("Observaciones").Value
                Dim _Obs_Actualizacion As String = .Rows(.CurrentRow.Index).Cells("Obs_Actualizacion").Value

                LblDigitador.Text = _Digitador
                LblContador1.Text = _Contador_1
                LblContador2.Text = _Contador_2
                LblActualizadoPor.Text = _Actualizado_por
                LblObsActualizacion.Text = _Obs_Actualizacion
                LblObservaciones.Text = _Observaciones

            End With

        Catch ex As Exception

        End Try

    End Sub



    Private Sub BtnEstadisticas_Click(sender As System.Object, e As System.EventArgs) Handles BtnEstadisticas.Click

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnRecontarModificar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabarAnalisis_Reconteo.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then

            Dim myTrans As SqlClient.SqlTransaction
            Dim Comando As SqlClient.SqlCommand

            Dim Cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

            Try


                myTrans = Cn2.BeginTransaction()


                With GrillaHistoriaProducto

                    Dim i = 0
                    Dim _Suma_Cantidad As Double = 0

                    For Each row As DataGridViewRow In .Rows

                        Dim _Cantidad As Double = row.Cells("Cantidad").Value
                        Dim _Cant_Recont As Double = row.Cells("Cant_Recont").Value
                        Dim _Semilla As Double = row.Cells("Semilla").Value
                        Dim _Ubicaion As String = row.Cells("UbicacionBodega").Value
                        Dim _Fila As String = row.Cells("Fila").Value
                        Dim _Columna As String = row.Cells("Columna").Value

                        Dim Observacion_Producto As String
                        Observacion_Producto = UCase(InputBox("OBSERVACION POR RECONTEO" & vbCrLf & vbCrLf &
                                                        "SECTOR: " & _Ubicaion & vbCrLf &
                                                        "FILA: " & _Fila & vbCrLf &
                                                        "COLUMNA: " & _Columna, "Reconteo",
                                                        "Producto recontado ..."))

                        Consulta_sql = "Update ZW_TmpInvProductosInventariados Set Recontado = 1" & vbCrLf &
                                       ",Cantidad_Recontada = " & _Cant_Recont & vbCrLf &
                                       ",Obs_Actualizacion = '" & Trim(Observacion_Producto) & "'" & vbCrLf &
                                       "Where Semilla = " & _Semilla

                        _Suma_Cantidad += _Cant_Recont

                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    Next

                    Dim R_, C_, L_ As Boolean

                    If _Cantidad_Inv = _Suma_Cantidad Then
                        L_ = True
                    Else
                        L_ = False
                    End If

                    Consulta_sql = "Update ZW_TmpInvFotoInventario Set" & vbCrLf &
                                   "Levantado = " & CInt(L_) & "," & vbCrLf &
                                   "Cant_Inventariada = " & _Suma_Cantidad & "," & vbCrLf &
                                   "Dif_Inv_Cantidad = " & _Suma_Cantidad & " - StFisicoUd1," & vbCrLf &
                                   "Total_Costo_Foto = Case When " & _Suma_Cantidad & " < 0 Then 0 Else " & _Suma_Cantidad & " End * PPP," & vbCrLf &
                                   "Total_Costo_Inv = " & _Suma_Cantidad & " * PPP" & vbCrLf &
                                   "Where IdInventario = " & _IdInventario & vbCrLf &
                                   "And CodigoPR = '" & _Codigo & "'"

                    'Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    'Comando.Transaction = myTrans
                    'Comando.ExecuteNonQuery()

                End With

                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

                MessageBoxEx.Show("Producto actualizado correctamente",
                                   "Recontar producto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                MessageBoxEx.Show("El producto esta CERRADO y RECONTADO" & vbCrLf &
                                  "Perdio la condición de estar LEVANTADO", "Marcar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Recontado = True
                ChkCerrado.Checked = True
                ChkRecontado.Checked = True
                ChkLevantado.Checked = False

                Me.Close()

            Catch ex As Exception

                My.Computer.FileSystem.WriteAllText("ArchivoSalida", ex.Message & vbCrLf & ex.StackTrace, False)
                MessageBoxEx.Show(ex.Message, "Error",
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                myTrans.Rollback()

                MessageBoxEx.Show("Transaccion desecha", "Problema",
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            End Try

        End If


    End Sub

    Sub Sb_Ver_Detalle_Del_Producto()

        'Consulta_sql = "SELECT Semilla,Recontado,UbicacionBodega,Isnull(Nro_Hoja,'') as Nro_Hoja," & vbCrLf &
        '               "Isnull(Item_Hoja,'') as Item_Hoja,Columna,Fila," & vbCrLf &
        '               "FechaInventario AS Fecha," & vbCrLf &
        '               "CONVERT(Char(8), FechaInventario, 108) AS Hora," & vbCrLf &
        '               "CantidadInventariada as 'Cantidad'," & vbCrLf &
        '               "Cantidad_Recontada as 'Cant_Recont'," & vbCrLf &
        '               "Responsable,(Select top 1 NOKOFU From TABFU Where KOFU = Responsable) as Digitador," & vbCrLf &
        '               "Contador_1,Contador_2, Observaciones," & vbCrLf &
        '               "Actualizado_por,Obs_Actualizacion" & vbCrLf &
        '               "FROM dbo.ZW_TmpInvProductosInventariados" & vbCrLf &
        '               "Where CodEmpresa = '" & _Empresa & "' And" & vbCrLf &
        '               "CodSucursal = '" & _Sucursal & "' And" & vbCrLf &
        '               "CodBodega = '" & _Bodega & "' And" & vbCrLf &
        '               "Fecha_Inventario_Gral = '" & Format(_FechaInv, "yyyyMMdd") & "' And " & vbCrLf &
        '               "Codproducto = '" & _Codigo & "'"

        Consulta_sql = "Select Semilla,Recontado,UbicacionBodega,Isnull(Nro_Hoja,'') as Nro_Hoja," & vbCrLf &
                       "Isnull(Item_Hoja,'') as Item_Hoja,Columna,Fila," & vbCrLf &
                       "FechaInventario," & vbCrLf &
                       "FechaInventario AS Hora," & vbCrLf &
                       "CantidadInventariada as 'Cantidad'," & vbCrLf &
                       "Cantidad_Recontada as 'Cant_Recont'," & vbCrLf &
                       "Responsable,ISNULL(NOKOFU,'') as Digitador," & vbCrLf &
                       "Contador_1,Contador_2, Observaciones," & vbCrLf &
                       "Actualizado_por,Obs_Actualizacion" & vbCrLf &
                       "From " & _Global_BaseBk & "ZW_TmpInvProductosInventariados" & vbCrLf &
                       "Left Join TABFU On KOFU = Responsable" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Codproducto = '" & _Codigo & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With GrillaHistoriaProducto

            .DataSource = _Tbl
            OcultarEncabezadoGrilla(GrillaHistoriaProducto, True)

            .Columns("Recontado").HeaderText = "Rec."
            .Columns("Recontado").Width = 40
            .Columns("Recontado").Visible = True
            .Columns("Recontado").ReadOnly = True

            .Columns("UbicacionBodega").HeaderText = "Sector"
            .Columns("UbicacionBodega").Width = 180
            .Columns("UbicacionBodega").Visible = True
            .Columns("UbicacionBodega").ReadOnly = True

            .Columns("Columna").HeaderText = "C."
            .Columns("Columna").Width = 30
            .Columns("Columna").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Columna").Visible = True
            .Columns("Columna").ReadOnly = True

            .Columns("Fila").HeaderText = "F."
            .Columns("Fila").Width = 30
            .Columns("Fila").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fila").Visible = True
            .Columns("Fila").ReadOnly = True

            .Columns("Nro_Hoja").HeaderText = "Hoja"
            .Columns("Nro_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_Hoja").Width = 35
            .Columns("Nro_Hoja").Visible = True
            .Columns("Nro_Hoja").ReadOnly = True

            .Columns("Item_Hoja").HeaderText = "Item"
            .Columns("Item_Hoja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Item_Hoja").Width = 40
            .Columns("Item_Hoja").Visible = True
            .Columns("Item_Hoja").ReadOnly = True

            .Columns("FechaInventario").HeaderText = "Fecha"
            .Columns("FechaInventario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaInventario").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaInventario").Width = 70
            .Columns("FechaInventario").Visible = True
            .Columns("FechaInventario").ReadOnly = True

            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 55
            .Columns("Hora").Visible = True
            .Columns("Hora").ReadOnly = True

            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 70
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").ReadOnly = True

            .Columns("Cant_Recont").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cant_Recont").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cant_Recont").HeaderText = "Cant. Recontada"
            .Columns("Cant_Recont").Width = 100
            .Columns("Cant_Recont").Visible = True

            If .RowCount = 0 Then
                MessageBoxEx.Show("No existen datos que mostrar",
                          "Detalle del producto", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End With

        '.ShowDialog(Me)
        'End With
        'Else



        'End If
    End Sub


    Private Sub BtnAgregarConteo_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarConteo.Click

        'If Not Fx_Tiene_Permiso(Me, "In0014") Then Return

        Dim Fm As New Frm_Login
        Fm.Text = "INGRESE CLAVE DE DIGITADOR DEL DOCUMENTO"
        Fm.ShowDialog(Me)

        If Not Fm.CancelarLogin Then

            Dim Fm_Inv As New Frm_01_HojaConteo

            Fm_Inv.Digitador = FUNCIONARIO
            Fm_Inv.Nombre_Digitador = Nombre_funcionario_activo
            Fm_Inv._Empresa_Inv_Activo = _Empresa
            Fm_Inv._Sucursal_Inv_Activo = _Sucursal
            Fm_Inv._Bodega_Inv_Activo = _Bodega
            Fm_Inv.ShowDialog(Me)
            Fm_Inv.Dispose()

        Else
            MessageBox.Show("Sin acceso!!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

End Class
