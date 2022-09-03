'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Inf_Ventas_X_Periodos_Proyeccion_Ventas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _Nombre_Tabla_Paso2 As String

    Dim _Aceptar As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Property Pro_Fecha_01_Desde() As Date
        Get
            Return Dtp_Fecha_01_Desde.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_01_Desde.Value = value
        End Set
    End Property
    Public Property Pro_Fecha_01_Hasta() As Date
        Get
            Return Dtp_Fecha_01_Hasta.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_01_Hasta.Value = value
        End Set
    End Property

    Public Property Pro_Fecha_02_Desde() As Date
        Get
            Return Dtp_Fecha_02_Desde.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_02_Desde.Value = value
        End Set
    End Property
    Public Property Pro_Fecha_02_Hasta() As Date
        Get
            Return Dtp_Fecha_02_Hasta.Value
        End Get
        Set(ByVal value As Date)
            Dtp_Fecha_02_Hasta.Value = value
        End Set
    End Property

    Public Property Pro_Sabado() As Boolean
        Get
            Return Chk_Sabado.Checked
        End Get
        Set(ByVal value As Boolean)
            Chk_Sabado.Checked = value
        End Set
    End Property
    Public Property Pro_Domingo() As Boolean
        Get
            Return Chk_Domingo.Checked
        End Get
        Set(ByVal value As Boolean)
            Chk_Domingo.Checked = value
        End Set
    End Property

    Public Sub New(ByVal Nombre_Tabla_Paso As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _Nombre_Tabla_Paso2 = Nombre_Tabla_Paso & "_02"

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodos_Proyeccion_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtrar.Click
        _Aceptar = True
        Me.Close()
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

End Class