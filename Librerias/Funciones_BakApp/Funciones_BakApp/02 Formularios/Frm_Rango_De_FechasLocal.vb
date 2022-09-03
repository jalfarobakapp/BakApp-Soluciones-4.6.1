Imports DevComponents.DotNetBar
Imports System.Drawing

Public Class Frm_Rango_De_FechasLocal

    Dim Desde_Fecha, Hasta_Fecha As String

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click

        Desde_Fecha = Format(Fechadesde.Value, "yyyyMMdd")
        hasta_fecha = Format(Fechahasta.Value, "yyyyMMdd")

        Dim Rango As String = numero_((Cuenta_registrosAccess("TmpFechas_Periodos", "Periodo")) + 1, 2)

        Dim Dias, DiasHabiles, Sabados, Domingos As Long

        Dim DiaSabado As FirstDayOfWeek = FirstDayOfWeek.Saturday
        Dim DiaDomingo As FirstDayOfWeek = FirstDayOfWeek.Sunday

        'Fechainicio = DateTimePicker1.Value
        'Fechatermino = DateTimePicker2.Value

        Desde_Fecha = Format(Fechadesde.Value, "yyyyMMdd")
        Hasta_Fecha = Format(Fechahasta.Value, "yyyyMMdd")

        Sabados = Cuentadias(Fechadesde.Value, Fechahasta.Value, DiaSabado)
        Domingos = Cuentadias(Fechadesde.Value, Fechahasta.Value, DiaDomingo)

        Dias = DateDiff(DateInterval.Day, Fechadesde.Value, Fechahasta.Value) + 1
        DiasHabiles = Dias - Sabados - Domingos

        Dim F1 = numero_(Day(Fechadesde.Value), 2) & "/" & numero_(Month(Fechadesde.Value), 2) & "/" & Year(Fechadesde.Value)
        Dim F2 = Day(Fechahasta.Value) & "/" & Month(Fechahasta.Value) & "/" & Year(Fechahasta.Value)

        Consulta_sql = "INSERT INTO TmpFechas_Periodos" & vbCrLf & _
                            "(Periodo,Fecha1,Fecha2,Dias,DiasHabiles,Sabados,Domingos,F1,F2) VALUES " & _
                            "('" & Rango & "','" & Format(Fechadesde.Value, "dd/MM/yyyy") & _
                            "','" & Format(Fechahasta.Value, "dd/MM/yyyy") & "'," & Dias & "," & DiasHabiles & "," & Sabados & "," & Domingos & _
                            ",'" & Desde_Fecha & "','" & Hasta_Fecha & "')"
        Ej_consulta_IDUaccess(Consulta_sql)



        CargarGrilla()

        Dim rtn As New Date
        rtn = Fechahasta.Value 'Date.Now
        rtn = rtn.AddDays(1) '.AddMonths(1).AddDays(-1)

        Fechadesde.Value = rtn '.Value + 1

    End Sub

    Function CargarGrilla()
        Try

            Consulta_sql = "SELECT Periodo,Fecha1,Fecha2 FROM TmpFechas_Periodos"
            Ejecutar_consulta_SQLaccess(Consulta_sql)

            tb = New DataTable
            dbD.Fill(tb) ' ---  aca se carga la tabla de la base access completa

            With Grilla

                .DataSource = tb ' -- Se asigna la tabla al datagridview
                Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.PowderBlue)

                .Columns("Periodo").Width = 58
                .Columns("Periodo").HeaderText = "Rango"
                .Columns("Periodo").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns("Fecha1").Width = 105
                .Columns("Fecha1").HeaderText = "Fecha inicio"
                .Columns("Fecha1").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Columns("Fecha2").Width = 105
                .Columns("Fecha2").HeaderText = "Fecha Fin"
                .Columns("Fecha2").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                .Refresh()
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Frm_RangoDeFechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Fechadesde.Value = Primerdiadelmes(DateTime.Now) '.ToString("MM/dd/yyyy")
        Fechahasta.Value = ultimodiadelmes(DateTime.Now) '.ToString("MM/dd/yyyy")

        CargarGrilla()
    End Sub

    Private Sub Fechadesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fechadesde.ValueChanged
        Fechahasta.Value = ultimodiadelmes(Fechadesde.Value)
        Dim Dias = DateDiff(DateInterval.Day, Fechadesde.Value.Date, Fechahasta.Value.Date) + 1
        LblDias.Text = "Días : " & Dias

        If Dias < 0 Then
            MsgBox("Rango de fecha es inconsistente", MsgBoxStyle.Critical, "Error")
            Fechahasta.Value = ultimodiadelmes(Fechadesde.Value)
            Exit Sub
        End If
    End Sub

    Private Sub BtnLimpiarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiarTodo.Click

        'CargarGrilla(TmpFechas_Periodos)

        Grilla.DataSource = Nothing
        Grilla.Refresh()

        Consulta_sql = "Delete * from TmpFechas_Periodos"
        Ej_consulta_IDUaccess(Consulta_sql)



    End Sub

    Private Sub BtnBorralUltFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorralUltFila.Click

        Dim Rango As String = numero_((Cuenta_registrosAccess("TmpFechas_Periodos", "Periodo")), 2)

        Consulta_sql = "Delete * from TmpFechas_Periodos Where Periodo = '" & Rango & "'"
        Ej_consulta_IDUaccess(Consulta_sql)

        CargarGrilla()


    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Me.Close()
    End Sub

    Private Sub Fechahasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fechahasta.ValueChanged
        Dim Dias = DateDiff(DateInterval.Day, Fechadesde.Value.Date, Fechahasta.Value.Date) + 1
        LblDias.Text = "Días : " & Dias

        If Dias < 0 Then
            MsgBox("Rango de fecha es inconsistente", MsgBoxStyle.Critical, "Error")
            Fechahasta.Value = ultimodiadelmes(Fechadesde.Value)
            Exit Sub
        End If

    End Sub
End Class