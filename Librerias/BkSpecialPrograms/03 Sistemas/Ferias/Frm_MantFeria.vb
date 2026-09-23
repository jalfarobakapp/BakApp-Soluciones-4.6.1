Public Class Frm_MantFeria
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    ' Variable global para saber si estamos editando
    Private _Feria_Editar As Zw_Feria = Nothing

    ' 1. CONSTRUCTOR PARA MODO INSERTAR (Por defecto)
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
    End Sub

    ' 2. CONSTRUCTOR PARA MODO EDITAR
    Public Sub New(Feria As Zw_Feria)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Guardamos la feria que recibimos para usar su ID al actualizar
        _Feria_Editar = Feria
    End Sub

    ' 3. CARGA DEL FORMULARIO
    Private Sub Frm_MantFeria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Si _Feria_Editar NO es nulo, significa que entramos en modo Edición
        If _Feria_Editar IsNot Nothing Then
            Me.Text = "Editar Feria"
            Txt_Nombre.Text = _Feria_Editar.NombreFeria
            Dtp_Fecha_01_Desde.Value = _Feria_Editar.FechaInicio
            Dtp_Fecha_01_Hasta.Value = _Feria_Editar.FechaTermino
            Chk_Activa.Checked = _Feria_Editar.Activa
        Else
            Me.Text = "Crear Feria"
            Dtp_Fecha_01_Desde.Value = Date.Now.Date
            Dtp_Fecha_01_Hasta.Value = Date.Now.Date
        End If
    End Sub

    ' Propiedades...
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

    ' 4. BOTÓN GUARDAR
    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        Dim nombre As String = Txt_Nombre.Text.Trim()
        Dim fechaDesde As Date = Dtp_Fecha_01_Desde.Value.Date
        Dim fechaHasta As Date = Dtp_Fecha_01_Hasta.Value.Date

        ' Validaciones
        If String.IsNullOrWhiteSpace(nombre) Then
            MessageBox.Show("El nombre no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txt_Nombre.Focus()
            Return
        End If

        If fechaDesde > fechaHasta Then
            MessageBox.Show("La fecha de inicio (Desde) no puede ser posterior a la fecha de término (Hasta).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dtp_Fecha_01_Desde.Focus()
            Return
        End If

        Dim resultado As LsValiciones.Mensajes

        ' 5. DECIDIR QUÉ FUNCIÓN LLAMAR
        If _Feria_Editar Is Nothing Then
            resultado = Fx_Crear_Feria()
        Else
            resultado = Fx_Editar_Feria()
        End If

        If resultado.EsCorrecto Then
            MessageBox.Show(resultado.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' 6. FUNCIÓN CREAR (Original)
    Function Fx_Crear_Feria() As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes With {.Detalle = "Crear Feria"}
        Dim nombre As String = Txt_Nombre.Text.Trim()
        Dim fechaDesde As Date = Dtp_Fecha_01_Desde.Value.Date
        Dim fechaHasta As Date = Dtp_Fecha_01_Hasta.Value.Date
        Dim activa As Boolean = Chk_Activa.Checked

        Try
            Dim estadoActiva As Integer = If(activa, 1, 0)
            Dim query As String = $"
                INSERT INTO {_Global_BaseBk}[Zw_Ferias]
                           ([NombreFeria],[FechaCreacion],[FechaFeria],[FechaInicio],[FechaTermino],[Activa])
                     VALUES
                           ('{nombre.Replace("'", "''")}', GETDATE(), '{fechaDesde.ToString("yyyyMMdd")}', '{fechaDesde.ToString("yyyyMMdd")}', '{fechaHasta.ToString("yyyyMMdd")}', {estadoActiva})"

            Dim id As Integer
            If Not _Sql.Ej_Insertar_Trae_Identity(query, id) Then
                Throw New System.Exception("Error al crear la feria" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.Mensaje = "Feria creada correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Id = id

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje
    End Function

    ' 7. NUEVA FUNCIÓN EDITAR
    Function Fx_Editar_Feria() As LsValiciones.Mensajes
        Dim _Mensaje As New LsValiciones.Mensajes With {.Detalle = "Editar Feria"}
        Dim nombre As String = Txt_Nombre.Text.Trim()
        Dim fechaDesde As Date = Dtp_Fecha_01_Desde.Value.Date
        Dim fechaHasta As Date = Dtp_Fecha_01_Hasta.Value.Date
        Dim activa As Boolean = Chk_Activa.Checked

        Try
            Dim estadoActiva As Integer = If(activa, 1, 0)

            ' Sentencia UPDATE apuntando al ID de la feria que estamos editando
            Dim query As String = $"
                UPDATE {_Global_BaseBk}[Zw_Ferias]
                   SET [NombreFeria] = '{nombre.Replace("'", "''")}'
                      ,[FechaInicio] = '{fechaDesde.ToString("yyyyMMdd")}'
                      ,[FechaTermino] = '{fechaHasta.ToString("yyyyMMdd")}'
                      ,[Activa] = {estadoActiva}
                 WHERE [Id] = {_Feria_Editar.Id}"

            ' Usamos Ej_consulta_IDU (Insert/Delete/Update) estándar para ejecutar sentencias sin identity
            If Not _Sql.Ej_consulta_IDU(query) Then
                Throw New System.Exception("Error al actualizar la feria" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.Mensaje = "Feria actualizada correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Id = _Feria_Editar.Id

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje
    End Function

    ' Eventos vacíos que tenías...
    Private Sub Dtp_Fecha_01_Hasta_Click(sender As Object, e As EventArgs) Handles Dtp_Fecha_01_Hasta.Click
    End Sub
    Private Sub Lbl_FS_desde_Click(sender As Object, e As EventArgs) Handles Lbl_FS_desde.Click
    End Sub
    Private Sub Grupo_Fechas_Click(sender As Object, e As EventArgs) Handles Grupo_Fechas.Click
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Activa.CheckedChanged
    End Sub
End Class
Public Class Zw_Feria

    Public Property Id As Integer
    Public Property NombreFeria As String
    Public Property FechaInicio As Date
    Public Property FechaTermino As Date
    Public Property Activa As Boolean

    ' Constructor opcional para inicializar con valores limpios por defecto
    Public Sub New()
        Id = 0
        NombreFeria = String.Empty
        FechaInicio = DateTime.Now.Date
        FechaTermino = DateTime.Now.Date
        Activa = True
    End Sub

End Class
