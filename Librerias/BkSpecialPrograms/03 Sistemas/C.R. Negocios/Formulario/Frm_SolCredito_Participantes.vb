Imports DevComponents.DotNetBar

Public Class Frm_SolCredito_Participantes

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Nro_Negocio As String
    Dim _Stand_By As Boolean
    Dim _CodFuncionario_SCN As String
    Dim _Cerrado As Boolean

    Dim _TblParticipantes As DataTable

    Public Property Pro_Nro_Negocio As String
        Get
            Return _Nro_Negocio
        End Get
        Set(value As String)
            _Nro_Negocio = value
        End Set
    End Property

    Public Property Pro_Stand_By As Boolean
        Get
            Return _Stand_By
        End Get
        Set(value As Boolean)
            _Stand_By = value
        End Set
    End Property

    Public Property Pro_CodFuncionario_SCN As String
        Get
            Return _CodFuncionario_SCN
        End Get
        Set(value As String)
            _CodFuncionario_SCN = value
        End Set
    End Property

    Public Sub New(ByVal New_Cerrado As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        _Cerrado = New_Cerrado

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Sub Ab_Actualizar_Grilla()

        Consulta_sql = "SELECT Nro_Negocio,Stand_By,CodFuncionario,NomFuncionario,Email,Enviar_copia_al_cierre" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_Negocios_02_Fun" & vbCrLf & _
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & vbCrLf & _
                       "Order by CodFuncionario"

        _TblParticipantes = _Sql.Fx_Get_Tablas(Consulta_sql)


        With Grilla

            .DataSource = _TblParticipantes '_Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("CodFuncionario").Visible = True
            .Columns("CodFuncionario").HeaderText = "Cód."
            .Columns("CodFuncionario").Width = 30

            .Columns("NomFuncionario").Visible = True
            .Columns("NomFuncionario").HeaderText = "Participante"
            .Columns("NomFuncionario").Width = 220

            .Columns("Email").Visible = True
            .Columns("Email").HeaderText = "E-mail"
            .Columns("Email").Width = 260

            .Columns("Enviar_copia_al_cierre").Visible = True
            .Columns("Enviar_copia_al_cierre").HeaderText = "Copiar al cierre"
            .Columns("Enviar_copia_al_cierre").Width = 100
            .Columns("Enviar_copia_al_cierre").ReadOnly = _Cerrado

        End With

    End Sub

    Private Sub Frm_SolCredito_Participantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Consulta_sql = "Select CAST( 1 AS bit) AS Chk,CodFuncionario as Codigo,NomFuncionario as Descripcion," & vbCrLf & _
                       "(SELECT top 1 Enviar_copia_al_cierre " & _
                       "FROM " & _Global_BaseBk & "Zw_Negocios_02_Fun " & _
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = 0) as Enviar_copia_al_cierre" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_Usuarios" & vbCrLf & _
                       "Where CodFuncionario IN (SELECT CodFuncionario FROM " & _Global_BaseBk & "Zw_Negocios_02_Fun " & _
                       "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & ")"

        Ab_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Private Sub Btn_Agregar_Participantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar_Participantes.Click

        If _CodFuncionario_SCN <> FUNCIONARIO Then
            If Not Fx_Tiene_Permiso(Me, "Scn00013") Then Return
        End If

        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_TblParticipantes,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_BakApp, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _TblParticipantes = _Filtrar.Pro_Tbl_Filtro

            Dim _Filtro = Generar_Filtro_IN(_TblParticipantes, "Chk", "Codigo", False, True, "'")

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Negocios_02_Fun " &
                           "Where Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                If CBool(_TblParticipantes.Rows.Count) Then
                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Negocios_02_Fun (Nro_Negocio,Stand_By,CodFuncionario,NomFuncionario,Email) " &
                                   "Select '" & _Nro_Negocio & "'," & CInt(_Stand_By) * -1 & ",KOFU,NOKOFU,EMAIL From TABFU Where KOFU in " & _Filtro
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If
            End If

            Ab_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Frm_SolCredito_Participantes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Usuarios.Click
        If Fx_Tiene_Permiso(Me, "User0001") Then
            Dim Fm As New Frm_Usuarios_Bk
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Frm_SolCredito_Participantes_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If Not _Cerrado Then

            Consulta_sql = String.Empty

            For Each _Fila As DataRow In _TblParticipantes.Rows

                Dim _CodFuncionario As String = _Fila.Item("CodFuncionario")
                Dim _Enviar_copia_al_cierre As Integer = CInt(_Fila.Item("Enviar_copia_al_cierre")) * -1

                Consulta_sql += "Update " & _Global_BaseBk & "Zw_Negocios_02_Fun" & vbCrLf & _
                                "Set Enviar_copia_al_cierre = " & _Enviar_copia_al_cierre & vbCrLf & _
                                "Where CodFuncionario = '" & _CodFuncionario & _
                                "' And Nro_Negocio = '" & _Nro_Negocio & "' And Stand_By = " & CInt(_Stand_By) * -1 & vbCrLf

            Next

            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Sub

    Private Sub Grilla_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

End Class
