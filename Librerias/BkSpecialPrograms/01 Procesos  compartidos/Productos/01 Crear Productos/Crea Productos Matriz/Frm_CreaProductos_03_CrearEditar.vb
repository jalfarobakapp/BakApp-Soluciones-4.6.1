Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_CreaProductos_03_CrearEditar

    Public CodClasif As String
    Public CodTablaClass As String


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Sub Grabar()

        Try

            Dim Nro =_Sql.Fx_Cuenta_Registros("Zw_TablaDeCaracterizaciones", "Tabla = '" & CodTablaClass & "'") + 1

            Dim CantCarac = trae_datoAccess(tb, "CaracteresCod", "Tmp_MatrizCreacionCodigos", _
                                            "Nom_Class = '" & CodTablaClass & "'")



            Dim Grabo = False

            While Grabo = False

                CodClasif = numero_(Nro, CantCarac)

                Consulta_sql = "Insert into Zw_TablaDeCaracterizaciones " & vbCrLf & _
                               "(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden,ApColor,ApMedida,ApModelo) Values " & vbCrLf & _
                               "('" & CodTablaClass & "'," & _
                               "'" & TxtDescripcionBusqueda.Text & "'," & _
                               "'" & CodClasif & "'," & _
                               "'" & TxtDescripcionAlternativa.Text & "'," & Nro & _
                               "," & Val(ChkColor.Checked) & _
                               "," & Val(ChkMedida.Checked) & _
                               "," & Val(ChkModelo.Checked) & ")"

                If _Sql.Ej_consulta_IDU(Consulta_sql, False) = True Then


                    Dim info As New TaskDialogInfo("Graba Clasificación", _
                                   eTaskDialogIcon.Information2, _
                                   "¿Desea agregar un nuevo elemento?", _
                                   "La clasificación: " & TxtDescripcionBusqueda.Text & vbCrLf & _
                                   "Se ha incorporado correctamente" & vbCrLf & _
                                   "[Yes] Crear nuevo, [No] Volver a la pantalla anterior", _
                                   eTaskDialogButton.Yes + eTaskDialogButton.No _
                                   , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
                    Dim result As eTaskDialogResult = TaskDialog.Show(info)

                    If result = eTaskDialogResult.Yes Then
                        TxtDescripcionAlternativa.Text = ""
                        TxtDescripcionBusqueda.Text = ""
                        CodClasif = ""
                        TxtDescripcionBusqueda.Focus()
                    Else
                        Me.Close()
                    End If
                    Grabo = True
                Else
                    Nro += 1
                    Grabo = False
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Editar()
        Try

            'Dim Nro =_Sql.Fx_Cuenta_Registros("Zw_TablaDeCaracterizaciones", "Tabla = '" & CodTablaClass & "'") + 1
            'CodClasif = numero_(Nro, 5)

            Consulta_sql = "Update Zw_TablaDeCaracterizaciones Set" & vbCrLf & _
                           "DescripcionTabla = '" & TxtDescripcionBusqueda.Text & _
                           "',NombreTabla = '" & TxtDescripcionAlternativa.Text & _
                           "',ApColor = " & Val(ChkColor.Checked) & "," & vbCrLf & _
                           "ApMedida = " & Val(ChkMedida.Checked) & "," & vbCrLf & _
                           "ApModelo = " & Val(ChkModelo.Checked) & vbCrLf & _
                           "Where CodigoTabla = '" & CodClasif & "' and" & vbCrLf & _
                           "Tabla = '" & CodTablaClass & "'"

            If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then

                Dim info As New TaskDialogInfo("Graba Clasificación", _
                               eTaskDialogIcon.BlueFlag, _
                               "Datos actualizados correctamente", _
                               "La clasificación: " & TxtCodigo.Text & vbCrLf & _
                               "Se ha actualizado correctamente", _
                               eTaskDialogButton.Yes + eTaskDialogButton.No _
                               , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)

                
                Me.Close()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If CodClasif = "" Then
            Grabar()
        Else
            Editar()
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        EstiloFormulario(StyleManager1)

    End Sub

    Private Sub Frm_CreaProductos_03_CrearEditar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtCodigo.Text = CodClasif
        TxtDescripcionBusqueda.Focus()

        Dim Validar As Boolean

        If CodTablaClass = "ARTICULO" Then
            Validar = True
        Else
            Validar = False
        End If

        ChkColor.Enabled = Validar : ChkMedida.Enabled = Validar : ChkModelo.Enabled = Validar


        If CodClasif <> "" Then
            Dim Registros =_Sql.Fx_Cuenta_Registros("Zw_CodClassCreadas", "Clasificacion = '" & CodTablaClass & _
                                 "' and Codigo_Clasificacion = '" & CodClasif & "'")
            If Registros > 0 Then
                TxtDescripcionBusqueda.ReadOnly = True
                TxtDescripcionAlternativa.Focus()
            End If
        End If


    End Sub

   

    Private Sub TxtDescripcionBusqueda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescripcionBusqueda.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            e.Handled = True
            TxtDescripcionAlternativa.Text = TxtDescripcionBusqueda.Text
            TxtDescripcionAlternativa.Focus()
        End If
    End Sub

    Private Sub TxtDescripcionBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionBusqueda.TextChanged
        sender.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TxtDescripcionAlternativa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionAlternativa.TextChanged
        sender.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TxtDescripcionBusqueda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDescripcionBusqueda.KeyDown
        If TxtDescripcionBusqueda.ReadOnly = True Then
            MsgBox("No se puede cambiar esta descripción, ya que existiten productos creados con esta definición" & vbCrLf & _
                   "Solo se puede cambiar la descripción alternativa")
            TxtDescripcionAlternativa.Focus()
        End If
    End Sub
End Class