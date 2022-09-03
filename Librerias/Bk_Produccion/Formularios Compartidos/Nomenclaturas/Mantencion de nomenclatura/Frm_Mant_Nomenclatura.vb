Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Mant_Nomenclatura

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cl_Nomenclatura As New Cl_Nomenclatura

    Public Property Cl_Nomenclatura As Cl_Nomenclatura
        Get
            Return _Cl_Nomenclatura
        End Get
        Set(value As Cl_Nomenclatura)
            _Cl_Nomenclatura = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Encabezado, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Operaciones, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Mant_Nomenclatura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If _Cl_Nomenclatura.Accion = Cl_Nomenclatura.Enum_Accion.Nuevo Then

        ElseIf _Cl_Nomenclatura.Accion = Cl_Nomenclatura.Enum_Accion.Editar Then
            _Cl_Nomenclatura.Fx_Nuevo_Elemento_de_la_nomenclatura()
        End If

        Sb_Actualizar_Grillas()

    End Sub

    Sub Sb_Actualizar_Grillas()

        Grilla_Encabezado.DataSource = _Cl_Nomenclatura.Tbl_Pnpe
        Grilla_Detalle.DataSource = _Cl_Nomenclatura.Tbl_Pnpd
        Grilla_Operaciones.DataSource = _Cl_Nomenclatura.Tbl_Pnpr

        Sb_Formato_Grilla_Encabezado()
        Sb_Formato_Grilla_Detalle()
        Sb_Formato_Grilla_Operaciones()

    End Sub

    Private Sub Sb_Formato_Grilla_Encabezado()

        With Grilla_Encabezado

            OcultarEncabezadoGrilla(Grilla_Encabezado, True)

            Dim _DisplayIndex = 0

            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").DisplayIndex = _DisplayIndex
            .Columns("CODIGO").ReadOnly = True
            _DisplayIndex += 1

            .Columns("DESCRIPTOR").Visible = True
            .Columns("DESCRIPTOR").Width = 330
            .Columns("DESCRIPTOR").HeaderText = "Descripción"
            .Columns("DESCRIPTOR").DisplayIndex = _DisplayIndex
            .Columns("DESCRIPTOR").ReadOnly = True
            _DisplayIndex += 1

            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").Width = 70
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            .Columns("CANTIDAD").ReadOnly = True
            _DisplayIndex += 1

            .Columns("UDAD").Visible = True
            .Columns("UDAD").Width = 40
            .Columns("UDAD").HeaderText = "Unid"
            .Columns("UDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UDAD").DisplayIndex = _DisplayIndex
            .Columns("UDAD").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Orientado_A").Visible = True
            .Columns("Orientado_A").Width = 100
            .Columns("Orientado_A").HeaderText = "Orientado a:"
            .Columns("Orientado_A").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Orientado_A").DisplayIndex = _DisplayIndex
            .Columns("Orientado_A").ReadOnly = True
            _DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").Width = 50
            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").DisplayIndex = _DisplayIndex
            .Columns("Estado").ReadOnly = True
            _DisplayIndex += 1


        End With

    End Sub

    Private Sub Sb_Formato_Grilla_Detalle()

        With Grilla_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle, True)

            Dim _DisplayIndex = 0

            .Columns("ELEMENTO").Visible = True
            .Columns("ELEMENTO").Width = 100
            .Columns("ELEMENTO").HeaderText = "Código"
            .Columns("ELEMENTO").DisplayIndex = _DisplayIndex
            .Columns("ELEMENTO").ReadOnly = True
            _DisplayIndex += 1

            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").Width = 380
            .Columns("NOKOPR").HeaderText = "Nombre elemento o modelo"
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            .Columns("NOKOPR").ReadOnly = True
            _DisplayIndex += 1

            .Columns("CALIDAD").Visible = True
            .Columns("CALIDAD").Width = 20
            .Columns("CALIDAD").HeaderText = "C"
            .Columns("CALIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CALIDAD").DisplayIndex = _DisplayIndex
            .Columns("CALIDAD").ReadOnly = True
            _DisplayIndex += 1

            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").Width = 60
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            .Columns("CANTIDAD").ReadOnly = True
            _DisplayIndex += 1

            .Columns("UDAD").Visible = True
            .Columns("UDAD").Width = 30
            .Columns("UDAD").HeaderText = "Ud"
            .Columns("UDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UDAD").DisplayIndex = _DisplayIndex
            .Columns("UDAD").ReadOnly = True
            _DisplayIndex += 1

            .Columns("OPERACION").Visible = True
            .Columns("OPERACION").Width = 50
            .Columns("OPERACION").HeaderText = "Oper"
            .Columns("OPERACION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("OPERACION").DisplayIndex = _DisplayIndex
            .Columns("OPERACION").ReadOnly = True
            _DisplayIndex += 1


        End With

    End Sub

    Private Sub Sb_Formato_Grilla_Operaciones()

        With Grilla_Operaciones

            OcultarEncabezadoGrilla(Grilla_Operaciones, True)

            Dim _DisplayIndex = 0

            .Columns("OPERACION").Visible = True
            .Columns("OPERACION").Width = 100
            .Columns("OPERACION").HeaderText = "Código"
            .Columns("OPERACION").DisplayIndex = _DisplayIndex
            .Columns("OPERACION").ReadOnly = True
            _DisplayIndex += 1

            .Columns("NOMBREOP").Visible = True
            .Columns("NOMBREOP").Width = 540
            .Columns("NOMBREOP").HeaderText = "Nombre elemento o modelo"
            .Columns("NOMBREOP").DisplayIndex = _DisplayIndex
            .Columns("NOMBREOP").ReadOnly = True
            _DisplayIndex += 1

            '.Columns("").Visible = True
            '.Columns("CALIDAD").Width = 10
            '.Columns("CALIDAD").HeaderText = "C"
            '.Columns("CALIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("CALIDAD").DisplayIndex = _DisplayIndex
            '.Columns("CALIDAD").ReadOnly = True
            '_DisplayIndex += 1

            '.Columns("CANTIDAD").Visible = True
            '.Columns("CANTIDAD").Width = 40
            '.Columns("CANTIDAD").HeaderText = "Cantidad"
            '.Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            '.Columns("CANTIDAD").ReadOnly = True
            '_DisplayIndex += 1

            '.Columns("UDAD").Visible = True
            '.Columns("UDAD").Width = 100
            '.Columns("UDAD").HeaderText = "Ud"
            '.Columns("UDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("UDAD").DisplayIndex = _DisplayIndex
            '.Columns("UDAD").ReadOnly = True
            '_DisplayIndex += 1

            '.Columns("OPERACION").Visible = True
            '.Columns("OPERACION").Width = 50
            '.Columns("OPERACION").HeaderText = "Oper"
            '.Columns("OPERACION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("OPERACION").DisplayIndex = _DisplayIndex
            '.Columns("OPERACION").ReadOnly = True
            '_DisplayIndex += 1


        End With

    End Sub

End Class