Imports Lib_Bakapp_VarClassFunc
Imports System.Windows.Forms
Imports DevComponents.DotNetBar

Public Class Frm_MatRTU_01



    Sub ActualizarGrilla()

        Consulta_sql = "Select CodigoTabla, NombreTabla from Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "where Tabla = 'RTU'" & vbCrLf & _
                       "order by NombreTabla"
        tb = _SQL.Fx_Get_Tablas(Consulta_sql)


        With Grilla

            .DataSource = tb

           Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

            .Columns("CodigoTabla").Width = 80
            .Columns("CodigoTabla").HeaderText = "Código"

            .Columns("NombreTabla").Width = 200
            .Columns("NombreTabla").HeaderText = "Descripción"

        End With

    End Sub


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ActualizarGrilla()

    End Sub

    
    Private Sub BtnAgregarRTU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarRTU.Click

        If Trim(TxtCodUd1.Text) <> "" And Trim(TxtDescrUd1.Text) <> "" Then

            Consulta_sql = "Insert into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla, NombreTabla,Orden) Values " & vbCrLf & _
                           "('RTU','Razon de transformacion','" & TxtCodUd1.Text & "','" & TxtDescrUd1.Text & "', isnull((select count(*) from Zw_TablaDeCaracterizaciones Where Tabla ='RTU'),0)+1)"
            If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
                MessageBoxEx.Show(Me, "RTU incorporada correctamente", "Grabar nueva R.T.U.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCodUd1.Text = ""
                TxtDescrUd1.Text = ""
                ActualizarGrilla()
                TxtCodUd1.Focus()
            Else
                TxtCodUd1.SelectAll()
                TxtCodUd1.Focus()
            End If
        Else
            MessageBoxEx.Show(Me, "Debe llenar todos los campos", "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub
End Class