'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Stand_By

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowDocumento As DataRow
    Dim _TblDocumentos As DataTable
    Dim _Id_DocEnc As Integer
    Dim _CodFuncionario As String

    Enum Tipo_Visualizacion
        Motrar_todos
        Mostrar_solo_usuario_activo
        Mostrar_Numeros_Reservado_OCC
    End Enum

    Dim _Visualizar As Tipo_Visualizacion

    Public Sub New(ByVal Visualizar As Tipo_Visualizacion,
                   ByVal CodFuncionario As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent()
        _Visualizar = Visualizar
        _CodFuncionario = CodFuncionario

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub
    Public ReadOnly Property _Row_Documento_Seleccionado() As DataRow
        Get
            Return _RowDocumento
        End Get
    End Property
    Private Sub Frm_Formulario_Stand_By_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Btn_Refresh_Click(Nothing, Nothing)

        AddHandler Btn_Refresh.Click, AddressOf Btn_Refresh_Click
        AddHandler Grilla.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        _RowDocumento = Nothing

        Chk_Ver_Reservas_Otros_Usuarios.Visible = (_Visualizar = Tipo_Visualizacion.Mostrar_Numeros_Reservado_OCC)

    End Sub
    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Id_DocEnc As Integer = _Fila.Cells("Id_DocEnc").Value

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc" & vbCrLf &
                       "Where Id_DocEnc = " & _Id_DocEnc
        _RowDocumento = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowDocumento) Then
            Me.Close()
        Else
            MessageBoxEx.Show(Me, "Este documento ya no está disponible", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _RowDocumento = Nothing
        End If

    End Sub
    Sub Sb_Actualizar_Grilla(ByVal _Solo_Usuario_Actual As Boolean)

        Dim _Condicion = String.Empty

        If _Solo_Usuario_Actual Then
            _Condicion = "And CodFuncionario = '" & _CodFuncionario & "'"
        End If

        Select Case _Visualizar

            Case Tipo_Visualizacion.Mostrar_solo_usuario_activo, Tipo_Visualizacion.Motrar_todos

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc" & vbCrLf &
                               "Where Id_DocEnc Not In (Select Id_Casi_DocEnc From " & _Global_BaseBk & "Zw_Remotas)" & Environment.NewLine &
                               "And Empresa = '" & ModEmpresa & "' And Stand_by = 1" & Environment.NewLine &
                                _Condicion

            Case Tipo_Visualizacion.Mostrar_Numeros_Reservado_OCC

                If Chk_Ver_Reservas_Otros_Usuarios.Checked Then
                    _Condicion = String.Empty
                End If

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc" & vbCrLf &
                               "Where Id_DocEnc Not In (Select Id_Casi_DocEnc From " & _Global_BaseBk & "Zw_Remotas)" & Environment.NewLine &
                               "And Empresa = '" & ModEmpresa & "' And Reserva_NroOCC = 1" & Environment.NewLine &
                                _Condicion

        End Select

        _TblDocumentos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _TblDocumentos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("TipoDoc").Visible = True
            .Columns("TipoDoc").HeaderText = "Tipo"
            .Columns("TipoDoc").Width = 35
            .Columns("TipoDoc").DisplayIndex = 0

            .Columns("NroDocumento").Visible = True
            .Columns("NroDocumento").HeaderText = "Número"
            .Columns("NroDocumento").Width = 80
            .Columns("NroDocumento").DisplayIndex = 1

            .Columns("CodEntidad").Visible = True
            .Columns("CodEntidad").HeaderText = "Entidad"
            .Columns("CodEntidad").Width = 70
            .Columns("CodEntidad").DisplayIndex = 2

            .Columns("CodSucEntidad").Visible = True
            .Columns("CodSucEntidad").HeaderText = "Suc."
            .Columns("CodSucEntidad").Width = 50
            .Columns("CodSucEntidad").DisplayIndex = 3

            .Columns("Nombre_Entidad").Visible = True
            .Columns("Nombre_Entidad").HeaderText = "Razón Social"
            .Columns("Nombre_Entidad").Width = 230
            .Columns("Nombre_Entidad").DisplayIndex = 4

            .Columns("CodFuncionario").Visible = True
            .Columns("CodFuncionario").HeaderText = "Func."
            .Columns("CodFuncionario").Width = 40
            .Columns("CodFuncionario").DisplayIndex = 5

            .Columns("FechaEmision").Visible = True
            .Columns("FechaEmision").HeaderText = "Fecha"
            .Columns("FechaEmision").Width = 80
            .Columns("FechaEmision").DisplayIndex = 6

            .Columns("TotalBrutoDoc").Visible = True
            .Columns("TotalBrutoDoc").HeaderText = "Total"
            .Columns("TotalBrutoDoc").Width = 75
            .Columns("TotalBrutoDoc").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalBrutoDoc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalBrutoDoc").DisplayIndex = 7

        End With

    End Sub
    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Select Case _Visualizar

            Case Tipo_Visualizacion.Mostrar_solo_usuario_activo, Tipo_Visualizacion.Motrar_todos

                If _Visualizar = Tipo_Visualizacion.Mostrar_solo_usuario_activo Then
                    Me.Text = "Documentos en Stand-By, usuario activo"
                    Sb_Actualizar_Grilla(True)
                ElseIf _Visualizar = Tipo_Visualizacion.Motrar_todos Then
                    Me.Text = "Documentos en Stand-By, todos los usuarios"
                    Sb_Actualizar_Grilla(False)
                End If

            Case Tipo_Visualizacion.Mostrar_Numeros_Reservado_OCC

                Me.Text = "Documentos con número de Orden de compra reservados, usuario activo"
                Sb_Actualizar_Grilla(True)

        End Select

    End Sub
    Private Sub Frm_Formulario_Stand_By_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _RowDocumento = Nothing
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Imprimir_Reserva_OCC_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir_Reserva_OCC.Click

        If Fx_Tiene_Permiso(Me, "Doc00046") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Id_DocEnc As Integer = _Fila.Cells("Id_DocEnc").Value
            Dim _CodFuncionario As String = _Fila.Cells("CodFuncionario").Value

            Dim _Cl_Imprimir As New Clas_Imprimir_Reserva_OCC
            _Cl_Imprimir.Fx_Imprimir_Archivo(Me, _Id_DocEnc, _CodFuncionario, "")

        End If

    End Sub
    Private Sub Grilla_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Try

                With sender

                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                    'If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    'Else
                    'Return
                    'End If

                    Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name

                    If _Visualizar = Tipo_Visualizacion.Mostrar_Numeros_Reservado_OCC Then
                        ShowContextMenu(Menu_Contextual_01)
                    End If

                End With

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub Btn_Cerrar_Reserva_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar_Reserva.Click

        If Fx_Tiene_Permiso(Me, "Doc00045") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            Dim _Id_DocEnc As Integer = _Fila.Cells("Id_DocEnc").Value
            Dim _Reserva_Idmaeedo As Integer = _Fila.Cells("Reserva_Idmaeedo").Value

            If MessageBoxEx.Show(Me, "¿Esta seguro de cerrar definitivamente este número de documento?", "Cerrar Reserva de OCC",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Id_DocEnc & "
                            Delete " & _Global_BaseBk & "Zw_Casi_DocObs Where Id_DocEnc = " & _Id_DocEnc & "
                            Delete MAEDDO Where IDMAEEDO = " & _Reserva_Idmaeedo & "
                            Delete MAEEDOOB Where IDMAEEDO = " & _Reserva_Idmaeedo

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    Call Btn_Refresh_Click(Nothing, Nothing)
                Else
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema!", vbOK, MessageBoxIcon.Question)
                End If

            End If

        End If

    End Sub

End Class
