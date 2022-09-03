Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Feriados_Anuales

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Pro_Fecha_Desde() As Date
        Get
            Return Dtp_Fecha_Desde.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_Desde.Value = value
        End Set
    End Property
    Public Property Pro_Fecha_Hasta() As Date
        Get
            Return Dtp_Fecha_Hasta.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_Hasta.Value = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dtp_Fecha_Desde.Value = Convert.ToDateTime("01/01/" & FechaDelServidor.Year)
        Dtp_Fecha_Hasta.Value = Convert.ToDateTime("31/12/" & FechaDelServidor.Year)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

    End Sub

    Private Sub Frm_Feriados_Anuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()

        AddHandler Dtp_Fecha_Desde.TextChanged, AddressOf Sb_Actualizar_Grilla
        AddHandler Dtp_Fecha_Hasta.TextChanged, AddressOf Sb_Actualizar_Grilla
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Fecha_Desde As String = Format(Dtp_Fecha_Desde.Value, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd")

        Consulta_sql = "SELECT DATENAME(weekday,Fecha) As Dia,Fecha,NombreTabla,*" & vbCrLf & _
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf & _
                       "Where Tabla = 'FERIADOS'" & vbCrLf & _
                       "And Fecha Between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'" & vbCrLf & _
                       "Order By Fecha"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Dia").HeaderText = "Día"
            .Columns("Dia").Width = 100
            .Columns("Dia").Visible = True

            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Width = 80
            .Columns("Fecha").Visible = True

            .Columns("NombreTabla").HeaderText = "Descripción feriado"
            .Columns("NombreTabla").Width = 300
            .Columns("NombreTabla").Visible = True

        End With


    End Sub

    Private Sub Frm_Feriados_Anuales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Mantencion_Feriados_Anuales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mantencion_Feriados_Anuales.Click
        If Fx_Tiene_Permiso(Me, "Tbl00036") Then

            Dim _Ano As String = FechaDelServidor.Year
            Dim _Aceptado As Boolean

            _Aceptado = InputBox_Bk(Me, "Ingrese el año", "Año del feriado", _Ano, False, _Tipo_Mayus_Minus.Normal, 4,
                               False, _Tipo_Imagen.Texto, False, _Tipo_Caracter.Solo_Numeros_Enteros, False)

            If _Aceptado Then

                If _Ano < 2000 Or _Ano > FechaDelServidor.Year + 1 Then
                    MessageBoxEx.Show(Me, "Los años deben estar entre el 2000 y " & FechaDelServidor.Year + 1,
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Dim Fm As New Frm_Tabla_Caracterizaciones_01_Listado(Frm_Tabla_Caracterizaciones_01_Listado.Enum_Tablas_Random.Feriados_Anuales,
                                                                 Frm_Tabla_Caracterizaciones_01_Listado.Accion.Mantencion_Tabla)
                    Fm.Text = "Feriados Anuales, Año " & _Ano
                    Fm.Pro_Ano_Feriados = _Ano
                    Fm.ShowDialog(Me)
                    Fm.Dispose()
                End If

            End If

            Sb_Actualizar_Grilla()

        End If

    End Sub

End Class