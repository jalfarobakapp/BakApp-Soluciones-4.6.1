'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_InfoEnt_Informacion_General

    Dim _InfEntidad As String
    Dim _CodEntidad, _SucEntidad As String
    Dim _RowEntidad As DataRow

    Public Sub New(ByVal RowEntidad As DataRow)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _RowEntidad = RowEntidad
        _CodEntidad = _RowEntidad.Item("KOEN")
        _SucEntidad = _RowEntidad.Item("SUEN")

    End Sub

    Private Sub Frm_InfoEnt_Informacion_General_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _InfEntidad = My.Resources.Sql_Entidad.Informacion_Entidad
        RtxtInfEntidad.Text = _InfEntidad

        With _RowEntidad

            Dim _Rut As String = _RowEntidad.Item("RTEN")
            _Rut = Replace(FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut), ",", ".")

            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#CODIGO#", Trim(.Item("KOEN")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#RUT#", _Rut)
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#TIPOSUCURSAL#", Trim(.Item("TIPOSUCURSAL")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#RAZON#", Trim(.Item("RAZON")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#DIRECCION#", Trim(.Item("DIEN")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#SIGLA#", Trim(.Item("SIEN")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#PAIS#", Trim(.Item("PAIS")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#CIUDAD#", Trim(.Item("CIUDAD")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#COMUNA#", Trim(.Item("COMUNA")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#ZONA#", Trim(.Item("ZONA")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#TELEFONO#", Trim(.Item("FOEN")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#FAX#", Trim(.Item("FAEN")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#EMAIL1#", Trim(.Item("EMAIL")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#EMAIL2#", "") 'Trim(.Item("EMAILCOMER")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#TIPOENTIDAD#", Trim(.Item("TIPOENTIDAD")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#ACTECONOMICA#", Trim(.Item("ACTECONOMICA")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#TAMAEMPRESA#", Trim(.Item("TAMAEMPRESA")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#RUBRO#", Trim(.Item("RUBRO")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#FUNCIONARIO#", Trim(.Item("VENDEDOR")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#COBRADOR#", Trim(.Item("COBRADOR")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#OBSERVACIONES#", Trim(.Item("OBEN")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#LPRECIO#", Trim(.Item("LVEN")))
            RtxtInfEntidad.Text = Replace(RtxtInfEntidad.Text, "#LCOSTO#", Trim(.Item("LCEN")))

        End With

    End Sub


    Private Sub Frm_InfoEnt_Informacion_General_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class