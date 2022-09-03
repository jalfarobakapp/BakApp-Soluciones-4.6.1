Imports Lib_Bakapp_VarClassFunc

Public Class Frm_CreaProductos_02_BuscarListado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public CodTablaClass As String
    Public CodClass As String
    Public DesClassOrigen As String
    Public DesClassAltern As String

    Dim FilaSeleccionada As Integer

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        With Grilla
            .RowTemplate.Height = 15
            .DefaultCellStyle.Font = New Font("Tahoma", 7)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod
        End With


    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        CodClass = ""
        Me.Close()
    End Sub




    Sub ActualizarGrilla(ByVal Descripcion As String)


        Dim Condicion = _
               CADENA_A_BUSCAR(Descripcion, _
                               "DescripcionTabla LIKE '%")

        Consulta_sql = "SELECT CodigoTabla,DescripcionTabla,NombreTabla," & vbCrLf & _
                       "Case ApColor When 1 Then 'Si' else 'No' End as ApColor," & vbCrLf & _
                       "Case ApMedida When 1 Then 'Si' else 'No' End as ApMedida," & vbCrLf & _
                       "Case ApModelo When 1 Then 'Si' else 'No' End as ApModelo from Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "Where Tabla = '" & CodTablaClass & "'" & vbCrLf & _
                       "And DescripcionTabla like '%" & Condicion & "%'" & vbCrLf & _
                       "Order by DescripcionTabla"

        With Grilla
            .DataSource = _SQL.Fx_Get_Tablas(Consulta_sql)

            If CodTablaClass = "ARTICULO" Then
                .Columns("CodigoTabla").HeaderText = "Código"
                .Columns("CodigoTabla").Width = 50

                .Columns("DescripcionTabla").HeaderText = "Descripción"
                .Columns("DescripcionTabla").Width = 380

                .Columns("NombreTabla").HeaderText = "Descripción alternativa"
                .Columns("NombreTabla").Width = 250

                .Columns("ApColor").HeaderText = "Color"
                .Columns("ApColor").Width = 60

                .Columns("ApModelo").HeaderText = "Modelo"
                .Columns("ApModelo").Width = 60

                .Columns("ApMedida").HeaderText = "Medida"
                .Columns("ApMedida").Width = 60
            Else
                .Columns("CodigoTabla").HeaderText = "Código"
                .Columns("CodigoTabla").Width = 50

                .Columns("DescripcionTabla").HeaderText = "Descripción"
                .Columns("DescripcionTabla").Width = 470

                .Columns("NombreTabla").HeaderText = "Descripción alternativa"
                .Columns("NombreTabla").Width = 340

                .Columns("ApColor").Visible = False
                .Columns("ApModelo").Visible = False
                .Columns("ApMedida").Visible = False
            End If


        End With

    End Sub

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcion.TextChanged
        ActualizarGrilla(TxtDescripcion.Text)
    End Sub


    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        Try

            CodClass = Grilla.Rows(e.RowIndex).Cells(0).Value
            DesClassOrigen = Grilla.Rows(e.RowIndex).Cells(1).Value
            DesClassAltern = Grilla.Rows(e.RowIndex).Cells(2).Value

            If CodTablaClass = "ARTICULO" Then

                Consulta_sql = "DELETE * FROM Tmp_MatrizCreacionCodigos_Aplica"
                Ej_consulta_IDUaccess(Consulta_sql)


                Dim Color = _Sql.Fx_Trae_Dato(, "ApColor", "Zw_TablaDeCaracterizaciones", _
                                      "Tabla = '" & CodTablaClass & "' And CodigoTabla = '" & CodClass & "'")

                Dim Modelo = _Sql.Fx_Trae_Dato(, "ApModelo", "Zw_TablaDeCaracterizaciones", _
                                      "Tabla = '" & CodTablaClass & "' And CodigoTabla = '" & CodClass & "'")

                Dim Medida = _Sql.Fx_Trae_Dato(, "ApMedida", "Zw_TablaDeCaracterizaciones", _
                                      "Tabla = '" & CodTablaClass & "' And CodigoTabla = '" & CodClass & "'")


                Consulta_sql = "INSERT INTO Tmp_MatrizCreacionCodigos_Aplica (Codigo,COLOR,MEDIDA,MODELO) VALUES " & vbCrLf & _
                               "('CodClass'," & Color & "," & Medida & "," & Modelo & ")"
                Ej_consulta_IDUaccess(Consulta_sql)

                If Color = True Then
                    Consulta_sql = "Update "
                Else

                End If

                If Color = True Then
                    Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                   "Cod_Class = ''," & vbCrLf & _
                                   "Descripcion_Class=''," & vbCrLf & _
                                   "Descripcion_Opcional=''" & vbCrLf & _
                                   "Where Nom_Class = 'COLOR'"
                Else
                    Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                   "Cod_Class = 'XXXX'," & vbCrLf & _
                                   "Descripcion_Class=''," & vbCrLf & _
                                   "Descripcion_Opcional=''" & vbCrLf & _
                                   "Where Nom_Class = 'COLOR'"
                End If
                Ej_consulta_IDUaccess(Consulta_sql)

                If Modelo = True Then
                    Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                   "Cod_Class = ''," & vbCrLf & _
                                   "Descripcion_Class=''," & vbCrLf & _
                                   "Descripcion_Opcional=''" & vbCrLf & _
                                   "Where Nom_Class = 'MODELO'"
                Else
                    Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                   "Cod_Class = 'XXXX'," & vbCrLf & _
                                   "Descripcion_Class=''," & vbCrLf & _
                                   "Descripcion_Opcional=''" & vbCrLf & _
                                   "Where Nom_Class = 'MODELO'"
                End If
                Ej_consulta_IDUaccess(Consulta_sql)

                If Medida = True Then
                    Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                   "Cod_Class = ''," & vbCrLf & _
                                   "Descripcion_Class=''," & vbCrLf & _
                                   "Descripcion_Opcional=''" & vbCrLf & _
                                   "Where Nom_Class = 'MEDIDA'"
                Else
                    Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                   "Cod_Class = 'XXXX'," & vbCrLf & _
                                   "Descripcion_Class=''," & vbCrLf & _
                                   "Descripcion_Opcional=''" & vbCrLf & _
                                   "Where Nom_Class = 'MEDIDA'"
                End If
                Ej_consulta_IDUaccess(Consulta_sql)


                Consulta_sql = "update Tmp_MatrizCreacionCodigos set" & vbCrLf & _
                                   "Cod_Class = 'XXXX'," & vbCrLf & _
                                   "Descripcion_Class=''," & vbCrLf & _
                                   "Descripcion_Opcional=''" & vbCrLf & _
                                   "Where Nom_Class = 'CQ_FABRICA'"

                Ej_consulta_IDUaccess(Consulta_sql)

            End If
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub Frm_CreaProductos_02_BuscarListado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ActiveControl = TxtDescripcion
        Me.Text = CodTablaClass

        ActualizarGrilla(TxtDescripcion.Text)

    End Sub


    Private Sub BtnCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrear.Click

        Dim Fr As New Frm_CreaProductos_03_CrearEditar

        Fr.CodTablaClass = CodTablaClass
        Fr.CodClasif = ""
        Fr.Text = CodTablaClass

        Fr.ShowDialog(Me)
        TxtDescripcion.Text = Fr.TxtDescripcionBusqueda.Text
        ActualizarGrilla(TxtDescripcion.Text)
        TxtDescripcion.SelectAll()
        TxtDescripcion.Focus()

        Fr = Nothing

    End Sub

   

    Private Sub Grilla_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter
        FilaSeleccionada = e.RowIndex
    End Sub

    Function DevulveTF(ByVal Str As String) As Boolean
        If Str = "Si" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub TxtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcion.KeyPress
        If e.KeyChar = "]"c Then
            ' si se pulsa la coma se convertirá en punto
            MsgBox("No se puede usar caracter << ] >> para buscar...", , "Caractee no permitido")

            e.Handled = True
            SendKeys.Send("")
        End If
    End Sub

    Private Sub Btn_Editar_Clasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Clasificacion.Click
        Dim Fr As New Frm_CreaProductos_03_CrearEditar

        Dim Sel = Val(Grilla.SelectedRows.Item(0).ToString())

        Fr.CodTablaClass = CodTablaClass
        Fr.CodClasif = Trim(Grilla.Rows(FilaSeleccionada).Cells(0).Value)


        Fr.TxtDescripcionBusqueda.Text = Trim(Grilla.Rows(FilaSeleccionada).Cells(1).Value)
        Fr.TxtDescripcionAlternativa.Text = Trim(Grilla.Rows(FilaSeleccionada).Cells(2).Value)

        Fr.ChkColor.Checked = DevulveTF(Grilla.Rows(FilaSeleccionada).Cells(3).Value)
        Fr.ChkMedida.Checked = DevulveTF(Grilla.Rows(FilaSeleccionada).Cells(4).Value)
        Fr.ChkModelo.Checked = DevulveTF(Grilla.Rows(FilaSeleccionada).Cells(5).Value)

        Fr.Text = CodTablaClass

        Fr.ShowDialog(Me)

        TxtDescripcion.Text = Fr.TxtDescripcionBusqueda.Text
        ActualizarGrilla(TxtDescripcion.Text)
        TxtDescripcion.SelectAll()
        TxtDescripcion.Focus()

        Fr = Nothing
    End Sub
End Class