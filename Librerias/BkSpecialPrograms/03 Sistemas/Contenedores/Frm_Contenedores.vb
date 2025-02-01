Imports DevComponents.DotNetBar

Public Class Frm_Contenedores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String
    Public Property ModoSeleccion As Boolean
    Public Property Zw_Contenedor As New Zw_Contenedor

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Contenedores, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Contenedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Contenedores.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        If Chk_Abierto.Checked Then
            _Condicion = " And Estado = 'Abierto'"
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Contenedor" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Contenedores

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Contenedores, True)

            '.Columns("Id").Width = 40
            '.Columns("Id").HeaderText = "ID"
            '.Columns("Id").Visible = True
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Empresa").Width = 30
            '.Columns("Empresa").HeaderText = "Emp"
            '.Columns("Empresa").Visible = True
            '.Columns("Empresa").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Contenedor").Width = 100
            .Columns("Contenedor").HeaderText = "Contenedor"
            .Columns("Contenedor").Visible = True
            .Columns("Contenedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreContenedor").Width = 250
            .Columns("NombreContenedor").HeaderText = "Nombre Contenedor"
            .Columns("NombreContenedor").Visible = True
            .Columns("NombreContenedor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Width = 60
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Visible = True
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Contenedor_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Contenedor.Click

        Dim _Grabar As Boolean
        Dim _New_Zw_Contenedor As Zw_Contenedor

        Dim Fm As New Frm_CrearContenedor(0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _New_Zw_Contenedor = Fm.Zw_Contenedor
        Fm.Dispose()

        If _Grabar Then

            If ModoSeleccion Then

                Zw_Contenedor = _New_Zw_Contenedor
                Me.Close()
                Return

            End If

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Grilla_Contenedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Contenedores.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow

        Dim _IdCont As Integer = _Fila.Cells("IdCont").Value

        If ModoSeleccion Then

            'Consulta_sql = "SELECT Id,IdCont,Contenedor,CodFuncionario,Fecha_Hora,NombreEquipo,Id_DocEnc,NroRemota," &
            '               "Rm.CodPermiso,Rm.Descripcion_Adicional,NOKOFU" & vbCrLf &
            '               "From " & _Global_BaseBk & "Zw_Contenedor_DocTom Dt" & vbCrLf &
            '               "Inner Join BAKAPP_SG.dbo.Zw_Remotas Rm On Dt.Id_DocEnc = Rm.Id_Casi_DocEnc" & vbCrLf &
            '               "Left Join TABFU Tf On Tf.KOFU = Rm.CodFuncionario_Solicita" & vbCrLf &
            '               "Where IdCont = " & _IdCont

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            Consulta_sql = "Select t.*,f.NOKOFU From " & _Global_BaseBk & "Zw_Contenedor_DocTom t" & vbCrLf &
                           "Inner Join TABFU f On f.KOFU = t.CodFuncionario" & vbCrLf &
                           "Where NombreEquipo <> '" & _NombreEquipo & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row) Then
                MessageBoxEx.Show(Me, "Este contenedor se encuentra tomado por un documento en construcción." & vbCrLf &
                                  "Pertenece al funcionario: " & _Row.Item("CodFuncionario") & " - " & _Row.Item("NOKOFU"), "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Dim _Cl_Contenedor As New Cl_Contenedor
            Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_IdCont)

            Me.Close()
            Return

        End If

        Dim Fm As New Frm_CrearContenedor(_IdCont)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            _Fila.Cells("Contenedor").Value = Fm.Zw_Contenedor.Contenedor
        End If
        If Fm.Eliminar Then
            Grilla_Contenedores.Rows.Remove(_Fila)
        End If
        Fm.Dispose()

    End Sub

End Class
