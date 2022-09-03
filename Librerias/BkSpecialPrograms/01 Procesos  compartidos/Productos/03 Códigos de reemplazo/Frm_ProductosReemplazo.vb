'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class Frm_ProductosReemplazo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _Ds_Reemplazo As New Ds_CodReemplazo
    Dim _SqlEliminacion As String

    Dim _Grabar As Boolean

    Dim _RowProducto As DataRow

    Public ReadOnly Property Pro_Grabar() As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Public Sub New(ByVal Codigo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_ProdReemplazo, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        _Codigo = Codigo

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me.Text = "Conjunto de reemplazo del producto: " & _RowProducto.Item("NOKOPR")

        Sb_Color_Botones_Barra(Bar1)

    End Sub
    Private Sub Frm_ProductosReemplazo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla_ProdReemplazo.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Buscar_Producto_de_Reemplazo(_Codigo)

    End Sub

    Sub Sb_Buscar_Producto_de_Reemplazo(ByVal _Codigo)

        Dim Reg = _Sql.Fx_Cuenta_Registros("TABREMP", "KOPR = '" & _Codigo & "' And POSICION = 1")

        If Not CBool(Reg) Then
            Consulta_sql = "Insert Into TABREMP (KOPR,KOPRREM,POSICION)" &
                           "Values ('" & _Codigo & "','" & _Codigo & "',1)"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        _Ds_Reemplazo.Clear()
        Grilla_ProdReemplazo.DataSource = Nothing

        Consulta_sql = "SELECT KOPR as 'Codigo',KOPRREM as 'CodigoReemplazo'," &
                       "(SELECT TOP 1 NOKOPR FROM MAEPR WHERE KOPR = RM.KOPRREM ) as 'Descripcion',POSICION as Posicion" & vbCrLf &
                       "FROM TABREMP RM" & vbCrLf &
                       "Where KOPR = '" & _Codigo & "'" & vbCrLf &
                       "Order by POSICION"
        _Ds_Reemplazo = _Sql.Fx_Get_DataSet(Consulta_sql, _Ds_Reemplazo, "CodReemplazo")

        Dim Nombre_Tabla As String = _Ds_Reemplazo.Tables("CodReemplazo").TableName

        With Grilla_ProdReemplazo

            .DataSource = _Ds_Reemplazo
            .DataMember = _Ds_Reemplazo.Tables(Nombre_Tabla).TableName

            OcultarEncabezadoGrilla(Grilla_ProdReemplazo, True)

            .Columns("CodigoReemplazo").Width = 120
            .Columns("CodigoReemplazo").HeaderText = "Código de reemplazo"
            .Columns("CodigoReemplazo").Visible = True

            .Columns("Descripcion").Width = 490
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True

        End With
        Sb_MarcarGrilla()
    End Sub


    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        _Grabar = Fx_Grabar_()

        If _Grabar Then

            Consulta_sql = _SqlEliminacion & vbCrLf & Consulta_sql

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                MessageBoxEx.Show(Me, "Productos conmutativos relacionados correctamente",
                                  "Productos relacionados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        End If

    End Sub

    Function Fx_Grabar_() As Boolean

        If Fx_Tiene_Permiso(Me, "Prod041") Then
            Consulta_sql = String.Empty

            If CBool(Grilla_ProdReemplazo.RowCount) Then

                Consulta_sql += "DELETE TABREMP WHERE KOPRREM = '" & _Codigo & "'" & vbCrLf

                For Each Fila As DataRow In _Ds_Reemplazo.Tables("CodReemplazo").Rows
                    Dim _RowState = Fila.RowState
                    If Not _RowState = DataRowState.Deleted Then
                        Dim _Codigo_Remplazo As String = Fila.Item("CodigoReemplazo")
                        Consulta_sql += "DELETE TABREMP WHERE KOPR = '" & _Codigo_Remplazo & "'" & vbCrLf
                    End If
                Next

                For Each Fp As DataRow In _Ds_Reemplazo.Tables("CodReemplazo").Rows

                    Dim _RowState_Fp = Fp.RowState
                    If Not _RowState_Fp = DataRowState.Deleted Then

                        Dim _Codigo = Fp.Item("CodigoReemplazo")

                        For Each Fila As DataRow In _Ds_Reemplazo.Tables("CodReemplazo").Rows

                            Dim _RowState = Fila.RowState
                            If Not _RowState = DataRowState.Deleted Then

                                Dim _Codigo_Remplazo As String = Fila.Item("CodigoReemplazo")

                                If _Codigo = _Codigo_Remplazo Then
                                    Consulta_sql += "Insert Into TABREMP (KOPR,KOPRREM,POSICION)" &
                                                    "Values ('" & _Codigo & "','" & _Codigo & "',1)" & vbCrLf
                                Else
                                    Consulta_sql += "Insert Into TABREMP (KOPR,KOPRREM,POSICION)" &
                                                    "Values ('" & _Codigo & "','" & _Codigo_Remplazo & "',2)" & vbCrLf
                                End If
                            End If
                        Next

                    End If
                Next

                Return True
            Else
                MessageBoxEx.Show("No")
                Return False
            End If
        End If

    End Function



    Sub Nueva_Linea()
        If Fx_Tiene_Permiso(Me, "Prod041") Then
            Try

                Dim Fm As New Frm_BuscarXProducto_Mt
                Fm.CodProveedor_productos = String.Empty
                Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
                Fm.ListaDePrecio = ModListaPrecioVenta
                Fm.ShowDialog(Me)

                If Not String.IsNullOrEmpty(Fm.CodigoPr_Sel) Then

                    Dim NewFila As DataRow
                    NewFila = _Ds_Reemplazo.Tables("CodReemplazo").NewRow

                    With NewFila

                        .Item("Codigo") = _Codigo
                        .Item("CodigoReemplazo") = Fm._Tbl_Inf_Producto.Rows(0).Item("KOPR")
                        .Item("Descripcion") = Fm._Tbl_Inf_Producto.Rows(0).Item("NOKOPR")
                        .Item("Posicion") = 2

                    End With

                    _Ds_Reemplazo.Tables("CodReemplazo").Rows.Add(NewFila)
                    Grilla_ProdReemplazo.Refresh()
                    Sb_MarcarGrilla()

                End If
            Catch ex As Exception
                MessageBoxEx.Show(Me, ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End If
    End Sub


    Private Sub BtnAgregarcodigoBarras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarcodigoBarras.Click
        Nueva_Linea()
    End Sub

    Sub Sb_MarcarGrilla()

        Try

            Dim ContadorDsctos As Integer = 0

            With Grilla_ProdReemplazo

                Dim i = 0
                For Each row As DataGridViewRow In .Rows

                    Dim _COD As String = row.Cells("CodigoReemplazo").Value

                    If _COD = _Codigo Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                        If Global_Thema = Enum_Themas.Oscuro Then .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    Else
                        .Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If

                    i += 1

                Next

            End With
        Catch ex As Exception

        End Try

    End Sub



    Sub Sb_Eliminar_Linea()

        With Grilla_ProdReemplazo

            Dim _CodigoSel As String = .Rows(.CurrentRow.Index).Cells("CodigoReemplazo").Value

            If _Codigo <> _CodigoSel Then
                If MessageBoxEx.Show("¿Esta seguro de eliminar la línea?",
                                     "Eliminar línea", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim _Codigo_Remplazo As String = .Rows(.CurrentRow.Index).Cells.Item("CodigoReemplazo").Value
                    _SqlEliminacion += "DELETE TABREMP WHERE KOPR = '" & _Codigo_Remplazo & "'" & vbCrLf
                    .Rows.RemoveAt(.CurrentRow.Index)

                End If
            Else
                MessageBoxEx.Show(Me, "Este producto no se puede quitar de la lista, ya que es el producto seleccionado para el conjunto",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End With
    End Sub

    Private Sub Grilla_ProdReemplazo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grilla_ProdReemplazo.KeyDown
        If e.KeyValue = Keys.Delete Then
            Sb_Eliminar_Linea()
        End If
    End Sub

    Private Sub Frm_ProductosReemplazo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


End Class
