Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_02_Detalle_Producto_Actual

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Codigo As String
    Private _IdInventario As Integer

    Public Property Recontado As Boolean
    Public Property Zw_Inv_FotoInventario As Zw_Inv_FotoInventario

    Public Sub New(_IdInventario As Integer, _Codigo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._IdInventario = _IdInventario
        Me._Codigo = _Codigo

        Sb_Color_Botones_Barra(Bar2)

    End Sub
    Private Sub Frm_Detalle_Producto_Actual_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Ver_Detalle_Del_Producto()

    End Sub

    Private Sub GrillaHistoriaProducto_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Try

            Dim _Fila As DataGridViewRow = Grilla.CurrentRow

            With _Fila

                Dim _Digitador As String = NuloPorNro(.Cells("Digitador").Value, "")
                Dim _Contador_1 As String = .Cells("Contador1").Value
                Dim _Contador_2 As String = .Cells("Contador2").Value
                Dim _Observaciones As String = .Cells("Observaciones").Value

                LblDigitador.Text = _Digitador
                LblContador1.Text = _Contador_1
                LblContador2.Text = _Contador_2
                Txt_Observaciones.Text = _Observaciones

            End With

        Catch ex As Exception

        End Try

    End Sub


    Private Sub BtnEstadisticas_Click(sender As System.Object, e As System.EventArgs) Handles BtnEstadisticas.Click

        Dim Fm As New Frm_EstadisticaProducto(_Codigo)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Sub Sb_Ver_Detalle_Del_Producto()

        Consulta_sql = "Select HDet.Id,IdHoja,Recontado,Sector,Ubicacion,Isnull(HEnc.Nro_Hoja,'') As Nro_Hoja," & vbCrLf &
                       "Item_Hoja,FechaHoraToma,FechaHoraToma AS Hora,Cantidad as 'Cantidad',Responsable,ISNULL(Resp.NOKOFU,'') As Digitador," & vbCrLf &
                       "HEnc.IdContador1,ISNULL(C1.Nombre,'') As Contador1,HEnc.IdContador2,ISNULL(C2.Nombre,'') As Contador2," & vbCrLf &
                       "Observaciones,Actualizado_por,Obs_Actualizacion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle HDet" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Inv_Hoja HEnc On HEnc.Id = HDet.IdHoja" & vbCrLf &
                       "Left Join TABFU Resp On KOFU = HEnc.CodResponsable" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Inv_Contador C1 On C1.Id = HEnc.IdContador1" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Inv_Contador C2 On C2.Id = HEnc.IdContador2" & vbCrLf &
                       "Where HDet.IdInventario = " & _IdInventario & " And Codigo = '" & _Codigo & "'" & vbCrLf &
                       "Order by Recontado,HDet.Id"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl
            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Recontado").HeaderText = "Recontado"
            .Columns("Recontado").Width = 70
            .Columns("Recontado").Visible = True
            .Columns("Recontado").ReadOnly = True

            .Columns("Sector").HeaderText = "Sector"
            .Columns("Sector").Width = 200
            .Columns("Sector").Visible = True
            .Columns("Sector").ReadOnly = True

            .Columns("Ubicacion").HeaderText = "Ubicación"
            .Columns("Ubicacion").Width = 100
            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").ReadOnly = True

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

            .Columns("FechaHoraToma").HeaderText = "Fecha"
            .Columns("FechaHoraToma").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaHoraToma").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaHoraToma").Width = 70
            .Columns("FechaHoraToma").Visible = True
            .Columns("FechaHoraToma").ReadOnly = True

            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Hora").DefaultCellStyle.Format = "HH:mm"
            .Columns("Hora").Width = 45
            .Columns("Hora").Visible = True
            .Columns("Hora").ReadOnly = True

            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantidad").DefaultCellStyle.Format = "###,##.##"
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 70
            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").ReadOnly = True

        End With


        Consulta_sql = "Select Codigo,Recontado, SUM(Cantidad) As Cantidad" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle" & vbCrLf &
                       "Where Codigo = '" & _Codigo & "'" & vbCrLf &
                       "Group By Codigo,Recontado" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Recontado = 1" & vbCrLf &
                       "Where Codigo In (Select Codigo From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle Where Recontado = 1)" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #Paso On #Paso.Codigo = Foto.Codigo And Foto.Recontado = #Paso.Recontado" & vbCrLf &
                       "Where Foto.Recontado = 0" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set Cant_Inventariada = Cantidad" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_FotoInventario Foto" & vbCrLf &
                       "Inner Join #Paso On #Paso.Codigo = Foto.Codigo And Foto.Recontado = #Paso.Recontado" & vbCrLf &
                       "Where Foto.Recontado = 1" & vbCrLf &
                       "Drop table #Paso" & vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Inv_FotoInventario Set " &
                       "Dif_Inv_Cantidad = Cant_Inventariada-StFisicoUd1" &
                       ",Total_Costo_Foto = StFisicoUd1*Costo" &
                       ",Total_Costo_Inv = Cant_Inventariada*Costo" & vbCrLf &
                       "Where IdInventario = " & _IdInventario & " And Codigo = '" & _Codigo & "'"

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Cl_Inventario As New Cl_Inventario

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Inventario.Fx_Llenar_Zw_Inv_FotoInventario(_IdInventario, _Codigo)

        Zw_Inv_FotoInventario = _Mensaje.Tag

        With Zw_Inv_FotoInventario

            Lbl_StFisicoUd1.Text = FormatNumber(.StFisicoUd1, 2)
            Lbl_Cant_Inventariada.Text = FormatNumber(.Cant_Inventariada, 2)
            .Dif_Inv_Cantidad = .Cant_Inventariada - .StFisicoUd1
            Lbl_Dif_Inv_Cantidad.Text = FormatNumber(.Cant_Inventariada - .StFisicoUd1, 0)

            ChkCerrado.Checked = .Cerrado
            ChkLevantado.Checked = .Levantado
            ChkRecontado.Checked = .Recontado

            If .Dif_Inv_Cantidad < 0 Then
                Lbl_Dif_Inv_Cantidad.ForeColor = Rojo
            Else
                Lbl_Dif_Inv_Cantidad.ForeColor = Verde
            End If

        End With

    End Sub


    Private Sub BtnAgregarConteo_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarConteo.Click

        'If Not Fx_Tiene_Permiso(Me, "In0014") Then Return

        Dim Fm_Inv As New Frm_IngresarHoja(_IdInventario, 0)
        Fm_Inv.Reconteo = True
        Fm_Inv.CodigoReconteo = _Codigo
        Fm_Inv.ShowDialog(Me)
        Fm_Inv.Dispose()

        Sb_Ver_Detalle_Del_Producto()

    End Sub

End Class
