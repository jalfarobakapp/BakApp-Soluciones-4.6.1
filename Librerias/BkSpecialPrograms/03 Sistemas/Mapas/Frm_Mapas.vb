Imports System.Text

Public Class Frm_Mapas

    Dim _Pais, _Ciudad, _Comuna, _Direccion As String

    Public Sub New(_Pais As String, _Ciudad As String, _Comuna As String, _Direccion As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Pais = _Pais.Trim
        Me._Ciudad = _Ciudad.Trim
        Me._Comuna = _Comuna.Trim
        Me._Direccion = _Direccion.Trim

        Me.Text = "Dirección: " & _Direccion

    End Sub

    Private Sub Frm_Mapas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _UrlDireccion As New StringBuilder

        'Creamos variable para almacenar la url
        Dim urlMaps As String
        'Concatenamos la dirección con el Textbox añadimos la última sentencia para indicar que sólo se muestre el mapa
        urlMaps = "http://maps.google.com/maps?q=" '& "&output=embed" 'Creamos una variable direccion para que el WebBrowser lo pueda abrir puesto que no puede abrir directamente un string
        _UrlDireccion.Append(urlMaps)

        'Dim direccion As New Uri(urlMaps)
        'ASignamos como URL la direccion

        If Not String.IsNullOrEmpty(_Pais) Then
            _UrlDireccion.Append(_Pais + "," & "+")
        End If

        If Not String.IsNullOrEmpty(_Comuna) Then
            _UrlDireccion.Append(_Comuna + "," & "+")
        End If

        If Not String.IsNullOrEmpty(_Direccion) Then
            _UrlDireccion.Append(_Direccion + "," & "+")
        End If

        WebBrowser1.Navigate(_UrlDireccion.ToString) '.Url = direccion
    End Sub


End Class
