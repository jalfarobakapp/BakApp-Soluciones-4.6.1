'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Vehiculos_Empresa_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Vehiculos As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

       Sb_Formato_Generico_Grilla(Grilla_Vehiculos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Vehiculos_Empresa_Lista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Vehiculos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Chk_Mostrar_Solo_Habilitados.CheckedChanging, AddressOf Chk_Mostrar_Solo_Habilitados_CheckedChanging

    End Sub

#Region "PROCEDIMIENTO"

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        If Chk_Mostrar_Solo_Habilitados.Checked Then
            _Condicion = "And Habilitado = 1"
        End If

        Consulta_sql = "SELECT Id_Vehiculo, Nombre_Vehiculo, Patente," & vbCrLf & _
                       "CodigoTabla_Tipo_Vehiculo, " & vbCrLf & _
                       "ISNULL((Select Top 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones " & vbCrLf & _
                       "Where Tabla = 'VEHIC_TIPO' And CodigoTabla = CodigoTabla_Tipo_Vehiculo),'????') As Tipo_Vehiculo," & vbCrLf & _
                       "Ano," & vbCrLf & _
                       "CodigoTabla_Marca, " & vbCrLf & _
                       "ISNULL((Select Top 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones " & vbCrLf & _
                       "Where Tabla = 'VEHIC_MARCA' And CodigoTabla = CodigoTabla_Marca),'????') As Marca_Vehiculo," & vbCrLf & _
                       "CodigoTabla_Modelo, " & vbCrLf & _
                       "ISNULL((Select Top 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones " & vbCrLf & _
                       "Where Tabla = 'VEHIC_MODELO' And " & vbCrLf & _
                       "Padre_Tabla = 'VEHIC_MARCA' And " & vbCrLf & _
                       "Padre_CodigoTabla = CodigoTabla_Marca And " & vbCrLf & _
                       "CodigoTabla = CodigoTabla_Modelo),'????') As Modelo_Vehiculo," & vbCrLf & _
                       "Nro_Motor, Nro_Chasis, Nro_Serie, Nro_Vin, " & vbCrLf & _
                       "CodigoTabla_Color, " & vbCrLf & _
                       "ISNULL((Select Top 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones " & vbCrLf & _
                       "Where Tabla = 'COLOR' And CodigoTabla = CodigoTabla_Color),'????') As Color_Vehiculo," & vbCrLf & _
                       "Kilometraje, " & vbCrLf & _
                       "CodChofer," & vbCrLf & _
                       "ISNULL((Select Top 1 NomChofer From " & _Global_BaseBk & "Zw_TblChoferes_Empresa ZCh" & vbCrLf & _
                       "Where ZCh.CodChofer = Zv.CodChofer),'????') As Nombre_Conductor_Asignado,Habilitado" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_TblVehiculos_Empresa Zv" & vbCrLf & _
                       "Where 1 > 0" & vbCrLf & _Condicion

       
        _Tbl_Vehiculos = _SQL.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Vehiculos

            .DataSource = _Tbl_Vehiculos

            OcultarEncabezadoGrilla(Grilla_Vehiculos, True)


            .Columns("Nombre_Vehiculo").Visible = True
            .Columns("Nombre_Vehiculo").HeaderText = "Vehículo"
            .Columns("Nombre_Vehiculo").Width = 300
            .Columns("Nombre_Vehiculo").DisplayIndex = 0

            .Columns("Patente").Visible = True
            .Columns("Patente").HeaderText = "Patente"
            .Columns("Patente").Width = 100
            .Columns("Patente").DisplayIndex = 1

            .Columns("Kilometraje").Visible = True
            .Columns("Kilometraje").HeaderText = "Kilometraje"
            .Columns("Kilometraje").Width = 100
            .Columns("Kilometraje").DisplayIndex = 2
            .Columns("Kilometraje").DefaultCellStyle.Format = "###,##"
            .Columns("Kilometraje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

        Sb_Marcar_Grilla()

    End Sub

    Private Sub Sb_Marcar_Grilla()

        For Each _Fila As DataGridViewRow In Grilla_Vehiculos.Rows

            Dim _Habilitado = _Fila.Cells("Habilitado").Value

            If _Habilitado Then
                _Fila.DefaultCellStyle.ForeColor = Color.Black
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Regular)
            Else
                _Fila.DefaultCellStyle.ForeColor = Color.Red
                _Fila.DefaultCellStyle.Font = New Font(Font.Name, Font.Size, FontStyle.Strikeout)
            End If

        Next

    End Sub


#End Region


    Private Sub Chk_Mostrar_Solo_Habilitados_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.CheckBoxChangeEventArgs)
        If Not Fx_Tiene_Permiso(Me, "Crv0003") Then
            e.Cancel = True
        Else
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Frm_Vehiculos_Empresa_Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Crear_Vehiculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Vehiculo.Click

        If Fx_Tiene_Permiso(Me, "Crv0002") Then
            Dim Fm As New Frm_Vehiculos_Empresa(Frm_Vehiculos_Empresa.Accion.Nuevo)
            Fm.ShowDialog(Me)

            If Fm.Pro_Nuevo_Vehiculo Then
                Sb_Actualizar_Grilla()
                Beep()
                ToastNotification.Show(Me, "VEHICULO CREADO CORRECTAMENTE", _
                                       Btn_Crear_Vehiculo.Image, _
                                       1 * 1000, eToastGlowColor.Green, _
                                       eToastPosition.MiddleCenter)
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Grilla_Vehiculos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Vehiculos.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Vehiculos.Rows(Grilla_Vehiculos.CurrentRow.Index)

        Dim _Patente = _Fila.Cells("Patente").Value

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_TblVehiculos_Empresa Where Patente = '" & _Patente & "'"
        Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim Fm As New Frm_Vehiculos_Empresa(Frm_Vehiculos_Empresa.Accion.Editar)
            Fm.Pro_RowVehiculo = _Tbl.Rows(0)
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_Actualizar_Grilla()

        End If

    End Sub


End Class
