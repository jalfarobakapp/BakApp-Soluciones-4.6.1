'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_OcultarPr

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Private Sub BtnBuscarproducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarproducto.Click
        BuscarProducto()
    End Sub

    Private Sub TxtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True

            MostrarPR()
        End If
    End Sub

    Public Sub MostrarPR()
        Dim Cuenta As Integer

        Codigo_abuscar = TxtCodigo.Text
        Cuenta = _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & Codigo_abuscar & "'")

        If Cuenta = 0 Then
            BtnGrabar.Enabled = False
            If Codigo_abuscar <> "" Then
                Codigo_abuscar = ""
                MsgBox("Producto no existe", MsgBoxStyle.Critical, "Producto")
            End If
            BuscarProducto()
        Else
            Txtdescripcion.Text = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & Codigo_abuscar & "'")
            ChkOculto.Checked = EstaOculto(Codigo_abuscar)
            BtnGrabar.Enabled = True
        End If
    End Sub


    Private Function EstaOculto(ByVal Codigo As String) As Boolean

        Dim Ocu As String = _Sql.Fx_Trae_Dato("MAEPR", "ATPR", "KOPR = '" & Codigo & "'")

        If Ocu = "" Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub BuscarProducto()


        Dim Fm As New Frm_BuscarXProducto_Mt
        Fm.CodProveedor_productos = String.Empty
        Fm.Tipo_Busqueda_Productos = Fm.Buscar_En.Maestro_de_Productos
        Fm.ListaDePrecio = ModListaPrecioVenta
        Fm.CodProveedor_productos = String.Empty
        Fm.MostrarOcultos = True
        Fm.ShowDialog(Me)
        Codigo_abuscar = Fm.CodigoPr_Sel

        TxtCodigo.Text = Codigo_abuscar
        If _Sql.Fx_Cuenta_Registros("MAEPR", "KOPR = '" & Codigo_abuscar & "'") > 0 Then
            Txtdescripcion.Text = _Sql.Fx_Trae_Dato("MAEPR", "NOKOPR", "KOPR = '" & Codigo_abuscar & "'")
            ChkOculto.Checked = EstaOculto(Codigo_abuscar)
            BtnGrabar.Enabled = True
        Else
            BtnGrabar.Enabled = False
        End If

    End Sub




    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim Ocu As String

        If ChkOculto.Checked = True Then
            Ocu = "OCU"
        Else
            Ocu = ""
        End If

        Consulta_sql = "UPDATE MAEPR SET ATPR = '" & Ocu & "' WHERE KOPR = '" & TxtCodigo.Text & "'"
        If  _Sql.Ej_consulta_IDU(Consulta_Sql) = True Then
            MsgBox("Datos actualizados correctamente", MsgBoxStyle.Information, "Ocultar producto")
            limpiar()
        End If

    End Sub

    Sub limpiar()
        TxtCodigo.Text = ""
        Txtdescripcion.Text = ""
        BtnGrabar.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        limpiar()
    End Sub

    Private Sub Frm_OcultarPr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtCodigo.Focus()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()


        limpiar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class