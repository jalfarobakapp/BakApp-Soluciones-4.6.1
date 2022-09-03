Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Rc_Lista_Reclamos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Reclamos As DataTable
    Dim _Id_Fila_Activa = 0
    Dim _Estados As Cl_Reclamo.Enum_Estados
    Dim _Listar_datos As Boolean
    Dim _Filtro_Externo As String

    Public Property Pro_Tbl_Reclamos As DataTable
        Get
            Return _Tbl_Reclamos
        End Get
        Set(value As DataTable)
            _Tbl_Reclamos = value
        End Set
    End Property

    Public Property Pro_Filtro_Externo As String
        Get
            Return _Filtro_Externo
        End Get
        Set(value As String)
            _Filtro_Externo = value
        End Set
    End Property

    Public Sub New(Estados As Cl_Reclamo.Enum_Estados, Optional Listar_datos As Boolean = True)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        _Estados = Estados

        Btn_Crear_OT.Visible = False

        Consulta_Sql = "Select '' As Padre,'Todos...' As Hijo, 0 As Orden  Union
                        SELECT CodigoTabla As Padre,NombreTabla As Hijo, Orden" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "WHERE Tabla = 'SIS_RECLAMOS_TIPO' Order by Orden"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        caract_combo(Cmb_Filtro_Codigo)
        Cmb_Filtro_Codigo.DataSource = _Tbl
        Cmb_Filtro_Codigo.SelectedValue = ""

        _Listar_datos = Listar_datos

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Crear_OT.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Lista_Reclamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _Listar_datos Then Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Filtro_Estados As String

        Select Case _Estados

            Case Cl_Reclamo.Enum_Estados.Ingresado

                Btn_Crear_OT.Visible = True
                _Filtro_Estados = "And ((Estado <> 'CIE') Or Id_Reclamo In " &
                                  "(Select Id_Reclamo From " & _Global_BaseBk & "Zw_Reclamo Where Fecha_Cierre > '" & Format(FechaDelServidor, "yyyyMMdd") & "'))"

            Case Cl_Reclamo.Enum_Estados.Revision_Espera, Cl_Reclamo.Enum_Estados.Recopilacion_Informacion, Cl_Reclamo.Enum_Estados.Resolucion

                _Filtro_Estados = "And Estado In ('RVE','RCI','RSL')"

            Case Cl_Reclamo.Enum_Estados.Validacion, Cl_Reclamo.Enum_Estados.Aviso_Cliente

                _Filtro_Estados = "And Estado In ('VAL','AVI')"

            Case Cl_Reclamo.Enum_Estados.Gestionar_Reclamo

                _Filtro_Estados = "And Estado In ('GES','ACI')"

            Case Else

                _Filtro_Estados = String.Empty

        End Select

        Dim _Tipo_Reclamo = Cmb_Filtro_Codigo.SelectedValue

        If Not String.IsNullOrEmpty(_Tipo_Reclamo) Then
            _Filtro_Estados += vbCrLf & " And Tipo_Reclamo = '" & _Tipo_Reclamo & "'"
        End If

        If Not String.IsNullOrEmpty(_Filtro_Externo) Then
            _Filtro_Estados = String.Empty
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'ACI' Where Estado = 'GES' And Sub_Estado = 'RCZ'" & vbCrLf & vbCrLf &
                       "Select Id_Reclamo,Empresa,Numero,
                        Estado,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_ESTADO' And CodigoTabla = Estado) As Estado_Reclamo,
                        Sub_Estado,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_SUBESTADO' And CodigoTabla = Sub_Estado) As Sub_Estado_Reclamo,
                        Sucursal,Codigo_Accion,
                        Fecha_Emision As Fecha,Cast('' As Varchar) As Tiempo_Del_Reclamo,--Fecha_Emision As Hora,
                        Tipo_Reclamo,
                        Sub_Tipo_Reclamo,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_SUBTIPO' And CodigoTabla = Tipo_Reclamo And Padre_Tabla = 'SIS_RECLAMOS_TIPO') As Nombre_Sub_Tipo_De_Reclamo,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_TIPO' And CodigoTabla = Tipo_Reclamo) As Tipo_De_Reclamo,
                        Rut_Contacto,Nombre_Contacto,Email_Contacto,Telefono_Contacto,
                        CodEntidad,SucEntidad,Rut_Entidad As Rut,Isnull(NOKOEN,'??') As Razon,
                        Cod_Vendedor,Isnull(NOKOFU,'??') As Vendedor,
                        Codigo,Descripcion,Fecha_Elab,Cantidad,
                        Suc_Elaboracion,Isnull(RTRIM(LTRIM(REPLACE(NOKOSU,'SUCURSAL',''))),'??') As Sucursal_Ingreso,Observacion
                        From " & _Global_BaseBk & "Zw_Reclamo
                        Left Join MAEEN On KOEN = CodEntidad And SUEN = SucEntidad
                        Left Join TABSU On EMPRESA = Empresa And KOSU = Sucursal
                        Left Join TABFU On KOFU = Cod_Vendedor
                        Where 1 > 0 " & vbCrLf &
                        _Filtro_Estados & vbCrLf & _Filtro_Externo

        _Tbl_Reclamos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla

            .DataSource = _Tbl_Reclamos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 80

            .Columns("Estado_Reclamo").Visible = True
            .Columns("Estado_Reclamo").HeaderText = "Estado"
            .Columns("Estado_Reclamo").Width = 170

            .Columns("Sub_Estado_Reclamo").Visible = True
            .Columns("Sub_Estado_Reclamo").HeaderText = "Sub Estado"
            .Columns("Sub_Estado_Reclamo").Width = 170

            .Columns("Rut").Visible = True
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Width = 80

            .Columns("Razon").Visible = True
            .Columns("Razon").HeaderText = "Cliente"
            .Columns("Razon").Width = 300

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha Emisión"
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 80
            .Columns("Fecha").DisplayIndex = 7

            .Columns("Tiempo_Del_Reclamo").Visible = True
            .Columns("Tiempo_Del_Reclamo").HeaderText = "Tiempo transcurrido"
            .Columns("Tiempo_Del_Reclamo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Tiempo_Del_Reclamo").DefaultCellStyle.Format = "HH:mm"
            .Columns("Tiempo_Del_Reclamo").Width = 120
            .Columns("Tiempo_Del_Reclamo").DisplayIndex = 8

            '.Columns("Hora").Visible = True
            '.Columns("Hora").HeaderText = "Hora"
            '.Columns("Hora").Width = 60
            '.Columns("Hora").DefaultCellStyle.Format = "hh:mm:ss"

            .Columns("Sucursal_Ingreso").Visible = True
            .Columns("Sucursal_Ingreso").HeaderText = "Sucursal"
            .Columns("Sucursal_Ingreso").Width = 130

            .Columns("Tipo_De_Reclamo").Visible = True
            .Columns("Tipo_De_Reclamo").HeaderText = "Tipo"
            .Columns("Tipo_De_Reclamo").Width = 80

        End With

        Sb_Tiempo_En_Mesones_y_Maquinas(Grilla, "Fecha", "Tiempo_Del_Reclamo")

    End Sub

    Sub Sb_Tiempo_En_Mesones_y_Maquinas(Grilla As DataGridView, _Campo_Fecha As String, _Campo_Tiempo As String)

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Fecha_Hora_Inicio = _Row.Cells(_Campo_Fecha).Value

            Dim ts As TimeSpan = Fx_Fecha_y_Hora_del_Servidor.Subtract(_Fecha_Hora_Inicio)

            Dim _Dias_Espera As Int32 = ts.Days
            Dim _Horas_Espera As Int32 = ts.Hours
            Dim _Minutos_Espera As Int32 = ts.Minutes
            Dim _Segundos_Espera As Int32 = ts.Seconds

            Dim _Dias = String.Empty
            Dim _Horas = String.Empty
            Dim _Minutos = String.Empty

            If _Dias_Espera > 0 Then
                If _Dias_Espera = 1 Then
                    _Dias = " día"
                Else
                    _Dias = " días"
                End If
                _Dias = _Dias_Espera & _Dias & ". "
            End If

            If _Horas_Espera > 0 Then
                _Horas = _Horas_Espera & " hr. "
            End If

            If _Minutos_Espera > 0 Then
                _Minutos = _Minutos_Espera & " Min."
            End If

            Dim _Tiempo_En_Maquina As String

            _Tiempo_En_Maquina = _Dias & _Horas & _Minutos

            If String.IsNullOrEmpty(_Tiempo_En_Maquina) Then _Tiempo_En_Maquina = "Menos de 1 Min"

            _Row.Cells(_Campo_Tiempo).Value = _Tiempo_En_Maquina

        Next

    End Sub
    Private Sub Btn_Crear_OT_Click(sender As Object, e As EventArgs) Handles Btn_Crear_OT.Click

        If Fx_Tiene_Permiso(Me, "Rcl00002") Then

            Dim _RowEntidad As DataRow
            Dim _Cl_Reclamo As Cl_Reclamo

            Dim Fm_Ent As New Frm_BuscarEntidad_Mt(False)
            Fm_Ent.Text = "SELECCIONE EL CLIENTE"
            Fm_Ent.ShowDialog(Me)

            If Fm_Ent.Pro_Entidad_Seleccionada Then _RowEntidad = Fm_Ent.Pro_RowEntidad

            Fm_Ent.Dispose()

            If Not IsNothing(_RowEntidad) Then

                Dim Fm As New Frm_Rc_01_Ingreso(Cl_Reclamo.Enum_Accion.Nuevo)
                Fm.Pro_Cl_Reclamo.Pro_Row_Entidad = _RowEntidad
                Fm.ShowDialog(Me)
                _Cl_Reclamo = Fm.Pro_Cl_Reclamo
                Dim _Grabado As Boolean = Not IsNothing(Fm.Pro_Cl_Reclamo.Pro_Row_Reclamo)
                Fm.Dispose()

                If _Grabado Then
                    Sb_Actualizar_Grilla()
                Else
                    Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Reclamo_Archivos Where Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo
                    _Sql.Ej_consulta_IDU(Consulta_Sql)
                End If

            End If

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Abrir_Reclamo(_Fila)

    End Sub

    Sub Sb_Abrir_Reclamo(_Fila As DataGridViewRow)

        Dim _Id_Reclamo As Integer = _Fila.Cells("Id_Reclamo").Value
        Dim _Tipo_Reclamo As String = _Fila.Cells("Tipo_Reclamo").Value

        Dim _Permiso As String
        Dim _Pedir_Permiso As Boolean

        Select Case _Estados

            Case Cl_Reclamo.Enum_Estados.Ingresado

            Case Cl_Reclamo.Enum_Estados.Revision_Espera, Cl_Reclamo.Enum_Estados.Recopilacion_Informacion, Cl_Reclamo.Enum_Estados.Resolucion
                _Permiso = "RclRes" & _Tipo_Reclamo
                _Pedir_Permiso = True
            Case Cl_Reclamo.Enum_Estados.Validacion ', Cl_Reclamo.Enum_Estados.Aviso_Cliente
                _Permiso = "RclVal" & _Tipo_Reclamo
                _Pedir_Permiso = True
            Case Cl_Reclamo.Enum_Estados.Gestionar_Reclamo

            Case Else

        End Select

        If _Pedir_Permiso Then

            If Not Fx_Tiene_Permiso(Me, _Permiso) Then
                Return
            End If

        End If

        Dim _Abrir_Reclamo As Boolean
        Dim _Grabado As Boolean

        Dim _Cl_Reclamo As New Cl_Reclamo

        _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)

        Dim Fm As New Frm_Rc_Reclamo()
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.ShowDialog(Me)
        _Grabado = Not IsNothing(Fm.Pro_Cl_Reclamo.Pro_Row_Reclamo)
        _Abrir_Reclamo = Fm.Pro_Abrir_Reclamo
        Fm.Dispose()

        If _Grabado Then

            If _Abrir_Reclamo Then
                Sb_Abrir_Reclamo(_Fila)
            End If

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Function Fx_Estados(ByVal _St_Etapa As StepItem,
                        ByVal _Encabezado As String,
                        ByVal _Espera As String,
                        ByVal _Etapa As String,
                        ByVal _Color_Arriba As Color,
                        ByVal _Color_Abajo As Color,
                        ByVal _Valor As Integer)

        Dim _Leyenda As String = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _Encabezado &
                              "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _Espera & "<br/>" & _Etapa & "</font>"

        With _St_Etapa
            .Text = _Leyenda
            .Value = _Valor
            .TextColor = Color.Black
            .ProgressColors = New System.Drawing.Color() {_Color_Arriba, _Color_Abajo} '{Color.GreenYellow, Color.GreenYellow}
            .HotTracking = True
        End With

    End Function

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _Id_Fila_Activa <> _Fila.Index Or (_Id_Fila_Activa Is Nothing) Then
            '_Fila.Cells("Chk_Flujo_Trabajo").Value = False
            'Sb_Actualizar_Estados_De_La_Fila(_Fila)
        End If
    End Sub

    Private Sub Btn_Configuración_Click(sender As Object, e As EventArgs)

        Dim Fm As New Frm_Rc_Configuracion
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Btn_Buscar_Reclamo_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Reclamo.Click

        Dim Fm As New Frm_Rc_Buscador
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Cmb_Filtro_Codigo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Filtro_Codigo.SelectedIndexChanged
        Call BtnActualizar_Click(Nothing, Nothing)
    End Sub

End Class