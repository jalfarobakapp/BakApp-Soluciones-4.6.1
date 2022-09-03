'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_CRV_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_CRV
    Dim _Filtrar As Boolean

    Public Property Pro_Tbl_CRV() As DataTable
        Get
            Return _Tbl_CRV
        End Get
        Set(ByVal value As DataTable)
            _Tbl_CRV = value
        End Set
    End Property
    Public Property Pro_Filtrar() As Boolean
        Get
            Return _Filtrar
        End Get
        Set(ByVal value As Boolean)
            _Filtrar = value
            If _Filtrar Then
                Btn_Buscar_OT.Visible = False
                Btn_Crear_OT.Visible = False
                Btn_Actualizar.Visible = False
            End If
        End Set
    End Property

    Private Sub Frm_CRV_Lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        If Pro_Filtrar Then
            Me.Top += 30
            Me.Left += 30
        End If

    End Sub

    Public Function Fx_Actualizar_Tbl_Crv(ByVal _Condicion As String) As DataTable

        Consulta_sql = "SELECT Id_CRV,Nro_CRV," & vbCrLf & _
                       "Patente,Case Estado When 'N' Then 'NULA...' Else" & vbCrLf & _
                       "Isnull((Select Top 1 Nombre_Vehiculo " & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_TblVehiculos_Empresa Zv Where Zv.Patente = Zc.Patente),'??') End As Nombre_Vehiculo," & vbCrLf & _
                       "CodChofer," & vbCrLf & _
                       "CodEntidad,SucEntidad," & vbCrLf & _
                       "(Select Top 1 NOKOEN From MAEEN Where KOEN = CodEntidad And SUEN = SucEntidad) As Nokoen," & vbCrLf & _
                       "Pais,Ciudad," & vbCrLf & _
                       "Comuna," & vbCrLf & _
                       "(Select top 1 NOKOCM From TABCM Where KOPA = Pais And KOCI = Ciudad And KOCM = Comuna) As Nom_Comuna," & vbCrLf & _
                       "Direccion," & vbCrLf & _
                       "CONVERT(VARCHAR, Fecha_Hora_Salida, 103) Fecha_Salida,CONVERT(VARCHAR, Fecha_Hora_Salida, 108) Hora_Salida," & _
                       "CONVERT(VARCHAR, Fecha_Hora_Llegada, 103) Fecha_Llegada,CONVERT(VARCHAR, Fecha_Hora_Llegada, 108) Hora_Llegada," & _
                       "Km_Salida, Km_Llegada, Observacion, Estado" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_CRV_Viajes Zc" & vbCrLf & _
                       "Where 1 > 0" & vbCrLf & _Condicion

        Return _Sql.Fx_Get_Tablas(Consulta_sql)

    End Function


    Sub Sb_Actualizar_Grilla()

        If (_Tbl_CRV Is Nothing) Then
            _Tbl_CRV = Fx_Actualizar_Tbl_Crv("And Estado = ''")
        End If

        With Grilla

            .DataSource = _Tbl_CRV

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Nro_CRV").Visible = True
            .Columns("Nro_CRV").HeaderText = "Número"
            .Columns("Nro_CRV").Width = 80
            .Columns("Nro_CRV").DisplayIndex = 0

            If Not _Filtrar Then

                .Columns("Nombre_Vehiculo").Visible = True
                .Columns("Nombre_Vehiculo").HeaderText = "Vehículo"
                .Columns("Nombre_Vehiculo").Width = 180
                .Columns("Nombre_Vehiculo").DisplayIndex = 1

                .Columns("Patente").Visible = True
                .Columns("Patente").HeaderText = "Patente"
                .Columns("Patente").Width = 70
                .Columns("Patente").DisplayIndex = 2

                .Columns("Nokoen").Visible = True
                .Columns("Nokoen").HeaderText = "Cliente/Proveedor"
                .Columns("Nokoen").Width = 200
                .Columns("Nokoen").DisplayIndex = 3

                .Columns("Nom_Comuna").Visible = True
                .Columns("Nom_Comuna").HeaderText = "Comuna"
                .Columns("Nom_Comuna").Width = 100
                .Columns("Nom_Comuna").DisplayIndex = 4

                .Columns("Direccion").Visible = True
                .Columns("Direccion").HeaderText = "Dirección"
                .Columns("Direccion").Width = 180
                .Columns("Direccion").DisplayIndex = 5

                .Columns("Fecha_Salida").Visible = True
                .Columns("Fecha_Salida").HeaderText = "Fecha salida"
                .Columns("Fecha_Salida").Width = 70
                .Columns("Fecha_Salida").DisplayIndex = 6

                .Columns("Hora_Salida").Visible = True
                .Columns("Hora_Salida").HeaderText = "Hora salida"
                .Columns("Hora_Salida").Width = 60
                .Columns("Hora_Salida").DisplayIndex = 7

                .Columns("Km_Salida").Visible = True
                .Columns("Km_Salida").HeaderText = "KM salida"
                .Columns("Km_Salida").Width = 60
                .Columns("Km_Salida").DisplayIndex = 8
                .Columns("Km_Salida").DefaultCellStyle.Format = "###,##"
                .Columns("Km_Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Else
                .Columns("Nombre_Vehiculo").Visible = True
                .Columns("Nombre_Vehiculo").HeaderText = "Vehículo"
                .Columns("Nombre_Vehiculo").Width = 180
                .Columns("Nombre_Vehiculo").DisplayIndex = 1

                .Columns("Patente").Visible = True
                .Columns("Patente").HeaderText = "Patente"
                .Columns("Patente").Width = 70
                .Columns("Patente").DisplayIndex = 2

                .Columns("Nokoen").Visible = True
                .Columns("Nokoen").HeaderText = "Cliente/Proveedor"
                .Columns("Nokoen").Width = 250
                .Columns("Nokoen").DisplayIndex = 3

                '.Columns("Nom_Comuna").Visible = True
                '.Columns("Nom_Comuna").HeaderText = "Comuna"
                '.Columns("Nom_Comuna").Width = 100
                '.Columns("Nom_Comuna").DisplayIndex = 3

                '.Columns("Direccion").Visible = True
                '.Columns("Direccion").HeaderText = "Dirección"
                '.Columns("Direccion").Width = 100
                '.Columns("Direccion").DisplayIndex = 4

                .Columns("Fecha_Salida").Visible = True
                .Columns("Fecha_Salida").HeaderText = "Fecha salida"
                .Columns("Fecha_Salida").Width = 70
                .Columns("Fecha_Salida").DisplayIndex = 4

                .Columns("Hora_Salida").Visible = True
                .Columns("Hora_Salida").HeaderText = "Hora salida"
                .Columns("Hora_Salida").Width = 60
                .Columns("Hora_Salida").DisplayIndex = 5

                .Columns("Fecha_Llegada").Visible = True
                .Columns("Fecha_Llegada").HeaderText = "Fecha llegada"
                .Columns("Fecha_Llegada").Width = 70
                .Columns("Fecha_Llegada").DisplayIndex = 6

                .Columns("Hora_Llegada").Visible = True
                .Columns("Hora_Llegada").HeaderText = "Hora llegada"
                .Columns("Hora_Llegada").Width = 60
                .Columns("Hora_Llegada").DisplayIndex = 7

                .Columns("Km_Salida").Visible = True
                .Columns("Km_Salida").HeaderText = "KM. Salida"
                .Columns("Km_Salida").Width = 70
                .Columns("Km_Salida").DisplayIndex = 8
                .Columns("Km_Salida").DefaultCellStyle.Format = "###,##"
                .Columns("Km_Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns("Km_Llegada").Visible = True
                .Columns("Km_Llegada").HeaderText = "KM. Llegada"
                .Columns("Km_Llegada").Width = 70
                .Columns("Km_Llegada").DisplayIndex = 9
                .Columns("Km_Llegada").DefaultCellStyle.Format = "###,##"
                .Columns("Km_Llegada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End If
            
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With


    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar.Click
        _Tbl_CRV = Nothing
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_CRV_Lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Crear_OT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_OT.Click
        If Fx_Tiene_Permiso(Me, "Crv0014") Then
            Dim Fm As New Frm_CRV(Frm_CRV.Accion.Nuevo)
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                _Tbl_CRV = Nothing
                Sb_Actualizar_Grilla()
            End If
            Fm.Dispose()
        End If
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        If Fx_Tiene_Permiso(Me, "Crv0019") Then
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Patente = _Fila.Cells("Patente").Value
            Dim _Nro_CRV = _Fila.Cells("Nro_CRV").Value

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_CRV_Viajes Where Nro_CRV = '" & _Nro_CRV & "'"

            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then

                Dim Fm As New Frm_CRV(Frm_CRV.Accion.Editar)
                Fm.Pro_Row_CRV = _Tbl.Rows(0)
                Fm.ShowDialog(Me)

                If Not _Filtrar Then
                    If Fm.Pro_Grabar Then
                        _Tbl_CRV = Nothing
                        Sb_Actualizar_Grilla()
                    End If
                End If
                Fm.Dispose()

            Else

            End If
        End If
    End Sub

    Private Sub Btn_Buscar_OT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_OT.Click
        If Fx_Tiene_Permiso(Me, "Crv0017") Then
            Dim Fm As New Frm_CRV_Filtrar
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        If Fx_Tiene_Permiso(Me, "Crv0018") Then
            ExportarTabla_JetExcel_Tabla(_Tbl_CRV, Me, "Lista CRV")
        End If
    End Sub
End Class