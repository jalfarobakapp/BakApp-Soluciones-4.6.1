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

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        _Id_Enc = Id_Enc

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

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdp_CPT_MzDet Where Id_Enc = " & _Id_Enc
        _Tbl_ProductosFab = _Sql.Fx_Get_Tablas(Consulta_sql)

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

            .Columns("Descripcion").Width = 340
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Udad").Width = 30
            .Columns("Udad").HeaderText = "Udad"
            .Columns("Udad").Visible = True
            .Columns("Udad").DisplayIndex = _DisplayIndex
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

        Dim Fm As New Frm_Fabricaciones(_Id_Det)
        Fm.Text = _Codnomen & " - " & _Descriptor
        Fm.MaxCantidadFabricar = _MaxCantFabricar
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Sb_Actualizar_Grilla()

    End Sub

End Class
