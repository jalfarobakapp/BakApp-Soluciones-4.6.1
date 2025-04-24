Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_SelecProdMezclaFab

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_ProductosFab As DataTable

    Public Property Cl_Mezcla As Cl_Mezcla
    Public Property RowNomenclatura As DataRow

    Private _Id_Enc As Integer
    Private _MaxCantFabricar As Integer

    Public Sub New(Id_Enc As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, True, False)
        _Id_Enc = Id_Enc
        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_SelecMezcla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla  = 'TARJA_MAXMEZCLAS' And CodigoTabla = 'MAXMEZCLAS'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Valor) Value " &
                           "('TARJA_MAXMEZCLAS','Cant. Maxima a fabricar por mezcla','MAXMEZCLAS','MAXMEZCLAS',1200)" & vbCrLf &
                           "Select * From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla  = 'TARJA_MAXMEZCLAS' And CodigoTabla = 'MAXMEZCLAS'"
            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        _MaxCantFabricar = _Row.Item("Valor")

        'AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Where Id_Enc = " & _Id_Enc
        _Tbl_ProductosFab = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_ProductosFab

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            'Sb_InsertarBotonenGrilla(Grilla, "Btn_Opciones", "Opciones...", "Opciones", 0, _Tipo_Boton.Boton)

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Width = 220
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Udad").Width = 30
            .Columns("Udad").HeaderText = "Udad"
            .Columns("Udad").Visible = True
            .Columns("Udad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Codnomen").Width = 100
            .Columns("Codnomen").HeaderText = "Cód.Receta"
            .Columns("Codnomen").Visible = True
            .Columns("Codnomen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descriptor").Width = 300
            .Columns("Descriptor").HeaderText = "Receta"
            .Columns("Descriptor").Visible = True
            .Columns("Descriptor").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantnomen").Visible = True
            .Columns("Cantnomen").HeaderText = "Cant.Nom"
            .Columns("Cantnomen").Width = 60
            .Columns("Cantnomen").Visible = True
            .Columns("Cantnomen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cantnomen").DefaultCellStyle.Format = "###,###.##"
            .Columns("Cantnomen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantFabricar").Visible = True
            .Columns("CantFabricar").HeaderText = "Fabricar"
            .Columns("CantFabricar").Width = 60
            .Columns("CantFabricar").Visible = True
            .Columns("CantFabricar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantFabricar").DefaultCellStyle.Format = "###,###.##"
            .Columns("CantFabricar").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantFabricada").Visible = True
            .Columns("CantFabricada").HeaderText = "Fabricado"
            .Columns("CantFabricada").Width = 60
            .Columns("CantFabricada").Visible = True
            .Columns("CantFabricada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantFabricada").DefaultCellStyle.Format = "###,###.##"
            .Columns("CantFabricada").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Btn_Edit").DisplayIndex = True

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id_Det As Integer = _Fila.Cells("Id").Value
        Dim _Codnomen As String = _Fila.Cells("Codnomen").Value
        Dim _Descriptor As String = _Fila.Cells("Descriptor").Value

        Dim _CantFabricada As Double = _Fila.Cells("CantFabricada").Value

        If Not CBool(_CantFabricada) Then

            Dim _Msg1 = "RECETA: " & _Descriptor
            Dim _Msg2 = "¿ESTA SEGURO DE QUERER UTILIZAR ESTA RECETA PARA LA FABRICACION?" & vbCrLf & vbCrLf &
                        "[Yes] Confirmar receta - [No] Seleccionar otra receta - [Cancel] Salir"

            Dim _Mensaje As LsValiciones.Mensajes = Fx_Confirmar_LecturaSINO(_Msg1, _Msg2, eTaskDialogIcon.Exclamation, "CONFIRMACION DE RECETA", True, , False)

            If CType(_Mensaje.Tag, eTaskDialogResult) = eTaskDialogResult.No Then

                If Not Fx_Cambiar_Nomenclatura(_Fila) Then
                    Return
                End If

            End If

            If CType(_Mensaje.Tag, eTaskDialogResult) = eTaskDialogResult.Cancel Then
                Return
            End If

            Sb_Actualizar_Grilla()

        End If

        Dim Fm As New Frm_Fabricaciones(_Id_Det)
        Fm.MaxCantidadFabricar = _MaxCantFabricar
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_IngresarFabircaciones_Click(sender As Object, e As EventArgs) Handles Btn_IngresarFabircaciones.Click
        Call Grilla_CellDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Btn_EditarNomenclatura_Click(sender As Object, e As EventArgs) Handles Btn_EditarNomenclatura.Click

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        If Fx_Cambiar_Nomenclatura(_Fila) Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Function Fx_Cambiar_Nomenclatura(_Fila As DataGridViewRow) As Boolean

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Codigomz As String = _Fila.Cells("Codigo").Value
        Dim _Formularmz_Old As String = _Fila.Cells("Codnomen").Value
        Dim _Idpote_Otm As Integer = _Fila.Cells("Idpote_Otm").Value
        Dim _Idpotl_Otm As Integer = _Fila.Cells("Idpotl_Otm").Value
        Dim _CantFabricada As Double = _Fila.Cells("CantFabricada").Value

        If Not Fx_Tiene_Permiso(Me, "Pdc00011") Then
            Return False
        End If

        If CBool(_CantFabricada) Then
            MessageBoxEx.Show(Me, "No se puede cambiar la nomenclatura de un producto que ya ha sido fabricado.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Dim _RowNomenclatura As DataRow

        Dim Fm As New Frm_Select_Nomenclatura(_Codigomz)
        Fm.OrdenDesc = True
        Fm.ShowDialog(Me)
        _RowNomenclatura = Fm.RowNomenclatura
        Fm.Dispose()

        If IsNothing(_RowNomenclatura) Then
            Return False
        End If

        Dim _Formularmz As String = _RowNomenclatura.Item("CODIGO")

        If _Formularmz_Old = _Formularmz Then
            MessageBoxEx.Show(Me, "La receta seleccionada es la misma que la actual.",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Call Btn_EditarNomenclatura_Click(Nothing, Nothing)
            Return False
        End If

        If MessageBoxEx.Show(Me, "¿Está seguro de cambiar la receta por la nomenclatura seleccionada?" & vbCrLf &
                             "Receta seleccionada: " & _RowNomenclatura.Item("CODIGO") & " - " & _RowNomenclatura.Item("DESCRIPTOR"),
                             "Cambiar receta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            'Call Btn_EditarNomenclatura_Click(Nothing, Nothing)
            Return False
        End If

        Dim Cl_Mezcla As New Cl_Mezcla

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Cl_Mezcla.Fx_CambiarNomenclatura(_Id, _Codigomz, _Formularmz, _Formularmz, _Idpote_Otm, _Idpotl_Otm)

        MessageBoxEx.Show(Me, _Mensaje.Col1_Mensaje, _Mensaje.Col2_Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        Return _Mensaje.EsCorrecto

    End Function

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_VerRecetaCompleta_Click(sender As Object, e As EventArgs) Handles Btn_VerRecetaCompleta.Click
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Codnomen As String = _Fila.Cells("Codnomen").Value

        Dim Fm As New Frm_VerReceta(_Codnomen)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_VerRecetaSinProdExcluidos_Click(sender As Object, e As EventArgs) Handles Btn_VerRecetaSinProdExcluidos.Click
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Codnomen As String = _Fila.Cells("Codnomen").Value

        Dim Fm As New Frm_VerReceta(_Codnomen)
        Fm.NoMostrarMarcaFactorMezcla = True
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_VerRecetaSoloProdExcluidos_Click(sender As Object, e As EventArgs) Handles Btn_VerRecetaSoloProdExcluidos.Click
        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Codnomen As String = _Fila.Cells("Codnomen").Value

        Dim Fm As New Frm_VerReceta(_Codnomen)
        Fm.MostrarSoloMarcaFactorMezcla = True
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub
End Class
