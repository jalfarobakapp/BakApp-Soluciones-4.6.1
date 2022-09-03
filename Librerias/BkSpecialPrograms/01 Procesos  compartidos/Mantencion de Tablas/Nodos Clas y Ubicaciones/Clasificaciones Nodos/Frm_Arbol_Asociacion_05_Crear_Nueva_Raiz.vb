'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Arbol_Asociacion_05_Crear_Nueva_Raiz

    Dim _Aceptar As Boolean
    Dim _Descripcion As String
    Dim _Clas_Unica_X_Producto As Boolean
    Dim _Es_Posible_Cambiar_Clas_Unicas As Boolean = True

    Public ReadOnly Property Pro_Aceptar()
        Get
            Return _Aceptar
        End Get
    End Property
    Public Property Pro_Clas_Unica_X_Producto() As Boolean
        Get
            Return Rdb_Clas_Unica.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Clas_Unica.Checked = True
            Else
                Rdb_Clas_Multiple.Checked = True
            End If
        End Set
    End Property
    Public Property Pro_Descripcion() As String
        Get
            Return Txt_Descripcion.Text
        End Get
        Set(ByVal value As String)
            Txt_Descripcion.Text = value
        End Set
    End Property
    Public Property Pro_Es_Posible_Cambiar_Clas_Unicas() As Boolean
        Get
            Return _Es_Posible_Cambiar_Clas_Unicas
        End Get
        Set(ByVal value As Boolean)
            _Es_Posible_Cambiar_Clas_Unicas = value
        End Set
    End Property


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnGrabar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Arbol_Asociacion_05_Crear_Nueva_Raiz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BtnGrabar.Visible = True
        Me.ActiveControl = Txt_Descripcion

        Rdb_Clas_Multiple.Enabled = _Es_Posible_Cambiar_Clas_Unicas
        Rdb_Clas_Unica.Enabled = _Es_Posible_Cambiar_Clas_Unicas

    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If String.IsNullOrEmpty(Txt_Descripcion.Text) Then
            MessageBoxEx.Show(Me, "Falta el nombre de la carpeta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
        Else
            _Aceptar = True
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Arbol_Asociacion_05_Crear_Nueva_Raiz_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Rdb_Clas_Unica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb_Clas_Unica.CheckedChanged

    End Sub


    Private Sub Rdb_Clas_Unica_CheckedChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles Rdb_Clas_Unica.CheckedChanging
        'If Rdb_Clas_Unica.Checked Then
        ' If Not _Es_Posible_Cambiar_Clas_Unicas Then
        ' MessageBoxEx.Show(Me, "No es posible cambiar esta característica, ya que la carpeta posee productos asociados", _
        '                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ' e.Cancel = True
        'End If
        'End If
    End Sub
End Class
