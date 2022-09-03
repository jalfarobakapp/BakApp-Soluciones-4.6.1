Imports DevComponents.DotNetBar
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class Frm_SeleccionarListaPrecios

    Public _Listas_Seleccionadas(0) As String
    Public NombreLista As String
    Public TipoValor As String
    Public TipoLista As String

    Public _Lc_Precios, _
           _Lc_Costos, _
           _MultiSeleccion As Boolean

    Dim Datos_Lp As New Ds_Especiales

    Sub LlenarGrilla()

        Consulta_sql = "SELECT Permiso,Tipo,Lista ,Nombre_Lista," & _
                       "Case When TipoValor  = 'N' Then 'Netos' Else 'Brutos'  End as Valores" & vbCrLf & _
                       "FROM " & _Global_BaseBk & "Zw_ListaPreGlobal" & vbCrLf

        If _Lc_Costos And Not _Lc_Precios Then
            Consulta_sql += "Where Tipo = 'C'"
        ElseIf Not _Lc_Costos And _Lc_Precios Then
            Consulta_sql += "Where Tipo = 'P'"
        End If

        Datos_Lp.Clear()

        With GrillaListas

            .DataSource = Nothing

            Dim daAuthors As New SqlDataAdapter(Consulta_sql, cn1)
            daAuthors.Fill(Datos_Lp, "Listas_")

            .DataSource = Datos_Lp
            .DataMember = Datos_Lp.Tables("Listas_").TableName

            OcultarEncabezadoGrilla(GrillaListas)

            If _MultiSeleccion Then
                .Columns("Seleccionada").Width = 50
                .Columns("Seleccionada").HeaderText = "Select."
                .Columns("Seleccionada").Visible = True
            End If

            .Columns("Lista").Width = 50
            .Columns("Lista").HeaderText = "LP"
            .Columns("Lista").ReadOnly = True
            .Columns("Lista").Visible = True

            .Columns("Nombre_Lista").Width = 300
            .Columns("Nombre_Lista").HeaderText = "Nombre lista"
            .Columns("Nombre_Lista").ReadOnly = True
            .Columns("Nombre_Lista").Visible = True

            .Columns("Valores").Width = 100
            .Columns("Valores").HeaderText = "Valores"
            .Columns("Valores").ReadOnly = True
            .Columns("Valores").Visible = True

        End With


    End Sub

    Private Sub GrillaListas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaListas.CellDoubleClick
        If Not _MultiSeleccion Then
            With GrillaListas
                Dim Permiso As String = Trim(.Rows(.CurrentRow.Index).Cells("Permiso").Value)

                If TienePermiso(Permiso) Then
                    _Listas_Seleccionadas(0) = .Rows(.CurrentRow.Index).Cells("Lista").Value
                    NombreLista = .Rows(.CurrentRow.Index).Cells("Nombre_Lista").Value
                    TipoValor = .Rows(.CurrentRow.Index).Cells("Valores").Value
                    TipoLista = .Rows(.CurrentRow.Index).Cells("Tipo").Value
                    Dim Nombre_Lista As String = .Rows(.CurrentRow.Index).Cells("Nombre_Lista").Value
                    Me.Close()
                End If
            End With
        End If
    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Erase _Listas_Seleccionadas
        Me.Close()
    End Sub

    Private Sub Frm_SeleccionarListaPrecios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarGrilla()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Formato_Generico_Grilla(GrillaListas, 20, New Font("Tahoma", 8), Color.AliceBlue)

    End Sub

    Private Sub Frm_SeleccionarListaPrecios_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Erase _Listas_Seleccionadas
            Me.Close()
        End If
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Dim _ListasSeleccionadas As Boolean

        Dim Tbl_lista As DataTable = Datos_Lp.Tables("Listas_")
        Dim i = 0
        For Each _Fila As DataRow In Tbl_lista.Rows

            Dim _Sel As Boolean = _Fila.Item("Seleccionada")
            Dim _Lista As String = _Fila.Item("Lista")
            If _Sel Then
                ReDim Preserve _Listas_Seleccionadas(i)
                _Listas_Seleccionadas(i) = _Lista
                '_Arrglo(i) = _Lista
                _ListasSeleccionadas = True
                i += 1
            End If

        Next

        If Not _ListasSeleccionadas Then Erase _Listas_Seleccionadas
        Me.Close()

    End Sub


End Class