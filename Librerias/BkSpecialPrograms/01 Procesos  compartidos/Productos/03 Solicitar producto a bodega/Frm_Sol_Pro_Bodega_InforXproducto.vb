Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Sol_Pro_Bodega_InforXproducto


    Public _Fila As DataGridViewRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            TxtBodega.FocusHighlightEnabled = False
            TxtUbicacion.FocusHighlightEnabled = False
            TxtProducto.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Sol_Pro_Bodega_InforXproducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Frm_Sol_Pro_Bodega_InforXproducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With _Fila

            TxtProducto.Text = Trim(.Cells("Codigo").Value) & ", " & Trim(.Cells("Descripcion").Value)
            TxtBodega.Text = Trim(.Cells("NomBodega").Value)
            TxtUbicacion.Text = Trim(.Cells("Ubicacion").Value)

            TxtFunSolicita.Text = Trim(.Cells("Nom_Funcionario_Sol").Value)
            TxtFechaSolicita.Text = Trim(.Cells("Fecha_Sol").Value) & ", " & Trim(.Cells("Hora_Sol").Value)

            TxtFunEntrega.Text = Trim(.Cells("Nom_Funcionario_Ent").Value)

            If Not String.IsNullOrEmpty(Trim(.Cells("Fecha_Sol").Value)) Then
                TxtFechaSolicita.Text = Trim(.Cells("Fecha_Sol").Value) & ", " & Trim(.Cells("Hora_Sol").Value)
            End If

            TxtFunEntrega.Text = Trim(.Cells("Nom_Funcionario_Ent").Value)

            If Not String.IsNullOrEmpty(Trim(.Cells("Fecha_Ent").Value)) Then
                TxtFechaEntrega.Text = Trim(.Cells("Fecha_Ent").Value) & ", " & Trim(.Cells("Hora_Ent").Value)
            End If

            TxtFunRecibe.Text = Trim(.Cells("Nom_Funcionario_Rec").Value)
            If Not String.IsNullOrEmpty(Trim(.Cells("Fecha_Rec").Value)) Then
                TxtFechaRecibe.Text = Trim(.Cells("Fecha_Rec").Value) & ", " & Trim(.Cells("Hora_Rec").Value)
            End If


            TxtFunCancela.Text = Trim(.Cells("Nom_Funcionario_Cie").Value)

            If Not String.IsNullOrEmpty(Trim(.Cells("Fecha_Cie").Value)) Then
                TxtFechaCancela.Text = Trim(.Cells("Fecha_Cie").Value) & ", " & Trim(.Cells("Hora_Cie").Value)
            End If


            TxtFunAutorizaPasar.Text = Trim(.Cells("Nom_Funcionario_Aut").Value)

            If Not String.IsNullOrEmpty(Trim(.Cells("Fecha_Aut").Value)) Then
                TxtFechaAutorizaPasar.Text = Trim(.Cells("Fecha_Aut").Value) & ", " & Trim(.Cells("Hora_Aut").Value)
            End If

            TxtMotivoCancela.Text = Trim(.Cells("Motivo_cierre").Value)


        End With
    End Sub

End Class
