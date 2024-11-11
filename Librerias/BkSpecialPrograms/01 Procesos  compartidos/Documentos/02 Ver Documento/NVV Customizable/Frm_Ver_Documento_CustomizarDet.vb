Imports System.ComponentModel

Public Class Frm_Ver_Documento_CustomizarDet

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Source As BindingSource
    Private _Row_Producto As DataRow
    Public Property Cl_NVVCustomizable As Cl_NVVCustomizable

    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "SELECT * FROM MAEPR WHERE KOPR = '" & _Codigo & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    Private Sub Frm_Ver_Documento_CustomizarDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cl_NVVCustomizable = New Cl_NVVCustomizable

        Sb_ActualizarGrilla()

    End Sub

    Sub Sb_ActualizarGrilla()

        '' Crear un BindingList a partir de la lista
        Dim bindingList As New BindingList(Of Nvv_Customizable.Detalle)(Cl_NVVCustomizable.Ls_Detalle)

        ' Crear un BindingSource y enlazarlo al DataGridView
        _Source = New BindingSource(bindingList, Nothing)

        With Grilla_Detalle

            .DataSource = _Source

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _DisplayIndex = 0

            '.Columns("Idmaeddo").Visible = False
            '.Columns("Idmaeddo").HeaderText = "Id"
            '.Columns("Idmaeddo").Width = 40
            '.Columns("Idmaeddo").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("CodigoAlternativo").Visible = True
            .Columns("CodigoAlternativo").HeaderText = "Código"
            .Columns("CodigoAlternativo").Width = 110
            .Columns("CodigoAlternativo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 200
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Cantidad").Visible = True
            .Columns("Cantidad").HeaderText = "Cantidad"
            .Columns("Cantidad").Width = 100
            .Columns("Cantidad").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

End Class
