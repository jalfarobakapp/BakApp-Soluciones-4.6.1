Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_Rc_Reclamo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Info_Estado_A_Realizar As String

    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Abrir_Reclamo As Boolean

    Dim _Sub_Estado_Revisar As Boolean


    Public Property Pro_Cl_Reclamo As Cl_Reclamo
        Get
            Return _Cl_Reclamo
        End Get
        Set(value As Cl_Reclamo)
            _Cl_Reclamo = value
        End Set
    End Property

    Public Property Pro_Abrir_Reclamo As Boolean
        Get
            Return _Abrir_Reclamo
        End Get
        Set(value As Boolean)
            _Abrir_Reclamo = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Reclamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Datos()
        Sb_Actualizar_WockFlow()

        Progreso_Sub_Estados.Visible = Not String.IsNullOrEmpty(Trim(_Cl_Reclamo.Sub_Estado))

        If Progreso_Sub_Estados.Visible Then

            Select Case _Cl_Reclamo.Codigo_Accion

                Case "DC"

                    Sub_Estado_REM.Visible = False
                    Sub_Estado_RVD.Visible = False
                    Sub_Estado_DME_REP_EBV.Visible = False
                    Sub_Estado_RZC.Visible = False

                Case "NO"

                    Sub_Estado_REM.Visible = False
                    Sub_Estado_RVD.Visible = False
                    Sub_Estado_DME_REP_EBV.Visible = False
                    Sub_Estado_RAC.Visible = False

                Case Else

                    Sub_Estado_RAC.Visible = False
                    Sub_Estado_RZC.Visible = False

            End Select

        End If

    End Sub

    Sub Sb_Actualizar_Datos()

        Consulta_Sql = "Select * From MAEPR Where KOPR = '" & _Cl_Reclamo.Pro_Row_Reclamo.Item("Codigo") & "'"
        _Cl_Reclamo.Pro_Row_Producto = _Sql.Fx_Get_DataRow(Consulta_Sql)

        _Cl_Reclamo.Pro_Row_Entidad = Fx_Traer_Datos_Entidad(_Cl_Reclamo.Pro_Row_Reclamo.Item("CodEntidad"),
                                                             _Cl_Reclamo.Pro_Row_Reclamo.Item("SucEntidad"))

        Lbl_Numero.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Numero")
        Lbl_Cliente.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("Rut") & " - " & _Cl_Reclamo.Pro_Row_Entidad.Item("NOKOEN")
        Lbl_Direccion.Text = _Cl_Reclamo.Pro_Row_Entidad.Item("DIEN")
        Lbl_Sucursal_Ingreso.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Sucursal_Ingreso")

        Lbl_Producto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Codigo") & " - " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Descripcion")
        Lbl_Cantidad.Text = "KG " & FormatNumber(_Cl_Reclamo.Pro_Row_Reclamo.Item("Cantidad"), 0)

        Lbl_Fecha_Emision.Text = FormatDateTime(_Cl_Reclamo.Pro_Row_Reclamo.Item("Fecha"), DateFormat.ShortDate)
        Lbl_Fecha_Elaboracion.Text = FormatDateTime(_Cl_Reclamo.Pro_Row_Reclamo.Item("Fecha_Elab"), DateFormat.ShortDate)

        Lbl_Tipo_De_Reclamo.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_De_Reclamo")
        Lbl_Sucursal_Elaboracion.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Sucursal_Elab")

        Lbl_Vendedor.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Vendedor")

        Lbl_Nombre_Contacto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Nombre_Contacto")
        Lbl_Telefono_Contacto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Telefono_Contacto")
        Lbl_Email_Contacto.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Email_Contacto")

        Txt_Descripcion_Reclamo.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Descripcion_Reclamo")

        Me.Text = "FICHA RECLAMO (" & RazonEmpresa & ") Id: " & _Cl_Reclamo.Id_Reclamo

    End Sub
    Sub Sb_Actualizar_Estados()

        For Each _Fila As DataRow In _Cl_Reclamo.Pro_Tbl_Estados.Rows

            Dim _CodEstado = _Fila.Item("Estado")
            Dim _Fecha As Date = _Fila.Item("Fecha_Fijacion")
            Dim _Nombre_Funcionario_Autoriza As String = Trim(_Fila.Item("Nombre_Funcionario_Autoriza"))
            Dim _Observacion As String = _Fila.Item("Observacion")
            Dim _Tido As String = _Fila.Item("Tido")
            Dim _Nudo As String = _Fila.Item("Nudo")
            Dim _Nro_Archivos As Integer

            Select Case _CodEstado

                Case "ING"

                    Fx_Estados(Estado_01_Ingreso, "Ingresado", "Revisión",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "RVE"

                    Fx_Estados(Estado_02_Revision, "Revisión", "Activado",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "RCI"

                    _Nro_Archivos = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Reclamo_Archivos",
                                                             "Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo & " And Estado = 'RCI' And Sub_Estado = ''")

                    Fx_Estados(Estado_03_Recopilar_Informacion, "Rec. información", "Archivos adjuntos: " & _Nro_Archivos,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "RSL"

                    Fx_Estados(Estado_04_Resolucion, "Resolución", _Nombre_Funcionario_Autoriza,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "VAL"

                    Fx_Estados(Estado_05_Validacion, "Validación", _Nombre_Funcionario_Autoriza,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "AVI"

                    Fx_Estados(Estado_06_Aviso_Cliente, "Aviso", "Correo enviado",
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "GES"

                    Fx_Estados(Estado_07_Gestionar_Reclamo, "Gestionar reclamo", _Observacion,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "REM"

                    Fx_Estados(Sub_Estado_REM, "Recepción mercadería", _Tido & "-" & _Nudo,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "RVD"

                    _Nro_Archivos = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Reclamo_Archivos",
                                                             "Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo & " And Estado = 'GES' And Sub_Estado = 'RVD'")


                    Fx_Estados(Sub_Estado_RVD, "Revisión devolución", "Archivos adjuntos: " & _Nro_Archivos,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "DME"

                    Fx_Estados(Sub_Estado_DME_REP_EBV, "Destrucción mercadería", _Tido & "-" & _Nudo,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "REP"

                    Fx_Estados(Sub_Estado_DME_REP_EBV, "Reproceso mercadería", _Tido & "-" & _Nudo,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "EBV"

                    Fx_Estados(Sub_Estado_DME_REP_EBV, "Envío a Bodega", _Tido & "-" & _Nudo,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "RAC"

                    _Nro_Archivos = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Reclamo_Archivos",
                                                             "Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo & " And Estado = 'GES' And Sub_Estado = 'RAC'")

                    Fx_Estados(Sub_Estado_RAC, "Recepción de acta", "Archivos adjuntos: " & _Nro_Archivos,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

                Case "RZC"

                    Fx_Estados(Sub_Estado_RZC, "Rechazado", _Nombre_Funcionario_Autoriza,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.LightCoral, Color.LightCoral, 100)

                Case "ACI"

                    Fx_Estados(Sub_Estado_CIE, "Cierre", _Nombre_Funcionario_Autoriza,
                               "Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate),
                               Color.GreenYellow, Color.GreenYellow, 100)

            End Select

        Next

    End Sub

    Sub Sb_Actualizar_WockFlow()

        Dim _Proximo_Estado As StepItem

        Select Case _Cl_Reclamo.Estado

            Case "ING"

                _Info_Estado_A_Realizar = "Revisión (espera)"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Enviar_a_Revision

                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Gestionar_Reclamo.Click, AddressOf Sb_Info_Estado_a_realizar

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                _Proximo_Estado = Estado_02_Revision

            Case "RVE"

                _Info_Estado_A_Realizar = "Revisión (espera)"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Aceptar_Reclamo_Enviar_A_Recopilacion_De_Informacion

                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Gestionar_Reclamo.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_02_Revision

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "RCI"

                _Info_Estado_A_Realizar = "Recopilación de información"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Estado_03_Recopilar_Informacion

                'AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Gestionar_Reclamo.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_03_Recopilar_Informacion

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Recopilar_Informacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Recopilar_Informacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "RSL"

                _Info_Estado_A_Realizar = "Resolución"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Estado_03_Recopilar_Informacion
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Estado_04_Ver_Resolucion

                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Gestionar_Reclamo.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_04_Resolucion

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Recopilar_Informacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Recopilar_Informacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Resolucion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Resolucion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "VAL"

                _Info_Estado_A_Realizar = "Reparación y Cierre..."

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Estado_03_Recopilar_Informacion
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Estado_04_Ver_Resolucion

                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Estado_05_Validacion
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Info_Estado_a_realizar
                AddHandler Estado_07_Gestionar_Reclamo.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_05_Validacion

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Recopilar_Informacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Recopilar_Informacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Resolucion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Resolucion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Validacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_05_Validacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "AVI"

                _Info_Estado_A_Realizar = "Aviso al cliente..."

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Estado_03_Revisar_Recopilar_Informacion
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Estado_04_Ver_Resolucion
                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Estado_05_Validacion
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Estado_06_Aviso_Cliente

                AddHandler Estado_07_Gestionar_Reclamo.Click, AddressOf Sb_Info_Estado_a_realizar

                _Proximo_Estado = Estado_06_Aviso_Cliente

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Recopilar_Informacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Recopilar_Informacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Resolucion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Resolucion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Validacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_05_Validacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_06_Aviso_Cliente.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_06_Aviso_Cliente.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "GES"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Estado_03_Revisar_Recopilar_Informacion
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Estado_04_Ver_Resolucion
                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Estado_05_Revisar_Validacion
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Estado_06_Aviso_Cliente

                Estado_07_Gestionar_Reclamo.TextColor = Color.Black
                Estado_07_Gestionar_Reclamo.ProgressColors = New System.Drawing.Color() {Color.Orange, Color.Orange} '{Color.GreenYellow, Color.GreenYellow}
                Estado_07_Gestionar_Reclamo.Value = 100
                Estado_07_Gestionar_Reclamo.HotTracking = True

                Dim _Accion As String = _Cl_Reclamo.Pro_Row_Reclamo.Item("Accion")

                'AddHandler Estado_07_Gestionar_Reclamo.MouseEnter, AddressOf Estado_MouseEnter
                'AddHandler Estado_07_Gestionar_Reclamo.MouseLeave, AddressOf Estado_MouseLeave

                Select Case _Cl_Reclamo.Sub_Estado

                    Case "REM"

                        _Proximo_Estado = Sub_Estado_REM

                        AddHandler Sub_Estado_REM.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                        AddHandler Sub_Estado_REM.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                        AddHandler Sub_Estado_REM.Click, AddressOf Sb_Sub_Estado_Nuevo

                    Case "RVD"

                        _Proximo_Estado = Sub_Estado_RVD

                        AddHandler Sub_Estado_REM.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                        AddHandler Sub_Estado_REM.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                        AddHandler Sub_Estado_RVD.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                        AddHandler Sub_Estado_RVD.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                        AddHandler Sub_Estado_REM.Click, AddressOf Sb_Sub_Estado_REM_Editar
                        AddHandler Sub_Estado_RVD.Click, AddressOf Sb_Sub_Estado_Nuevo

                    Case "DME", "REP", "EBV"

                        _Proximo_Estado = Sub_Estado_DME_REP_EBV

                        AddHandler Sub_Estado_REM.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                        AddHandler Sub_Estado_REM.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                        AddHandler Sub_Estado_RVD.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                        AddHandler Sub_Estado_RVD.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                        AddHandler Sub_Estado_DME_REP_EBV.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                        AddHandler Sub_Estado_DME_REP_EBV.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                        AddHandler Sub_Estado_REM.Click, AddressOf Sb_Sub_Estado_REM_Revisar
                        AddHandler Sub_Estado_RVD.Click, AddressOf Sb_Sub_Estado_RVD_Editar
                        AddHandler Sub_Estado_DME_REP_EBV.Click, AddressOf Sb_Sub_Estado_Nuevo

                        Dim _Titulo As String

                        If _Cl_Reclamo.Sub_Estado = "DME" Then
                            _Titulo = "Destrucción de mercadería"
                        ElseIf _Cl_Reclamo.Sub_Estado = "REP" Then
                            _Titulo = "Reproceso de mercadería"
                        ElseIf _Cl_Reclamo.Sub_Estado = "EBV" Then
                            _Titulo = "Envía a bodega de ventas"
                        End If

                        Dim _Leyenda2 As String = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>" & _Titulo &
                                                  "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">...<br/>Etapa...</font>"

                        _Proximo_Estado.Text = _Leyenda2

                    Case "RAC"

                        _Proximo_Estado = Sub_Estado_RAC

                        AddHandler Sub_Estado_RAC.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                        AddHandler Sub_Estado_RAC.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                        AddHandler Sub_Estado_RAC.Click, AddressOf Sb_Sub_Estado_Nuevo

                End Select

                Dim _Leyenda As String = "<font size=" & Chr(34) & "+2" & Chr(34) & "><b>Gestionar Reclamo..." &
                                         "</b></font><br/><font size=" & Chr(34) & "-1" & Chr(34) & ">" & _Accion & "<br/>Estapa...</font>"

                Estado_07_Gestionar_Reclamo.Text = _Leyenda

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Recopilar_Informacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Recopilar_Informacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Resolucion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Resolucion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Validacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_05_Validacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_06_Aviso_Cliente.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_06_Aviso_Cliente.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                'AddHandler Sub_Estado_REM.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                'AddHandler Sub_Estado_REM.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                'AddHandler Sub_Estado_RVD.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                'AddHandler Sub_Estado_RVD.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                'AddHandler Sub_Estado_DME_REP_EBV.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                'AddHandler Sub_Estado_DME_REP_EBV.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "ACI"

                _Proximo_Estado = Sub_Estado_CIE

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Estado_03_Revisar_Recopilar_Informacion
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Estado_04_Ver_Resolucion
                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Estado_05_Revisar_Validacion
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Estado_06_Aviso_Cliente

                AddHandler Sub_Estado_REM.Click, AddressOf Sb_Sub_Estado_REM_Revisar
                AddHandler Sub_Estado_RVD.Click, AddressOf Sb_Sub_Estado_RVD_Revisar
                AddHandler Sub_Estado_DME_REP_EBV.Click, AddressOf Sb_Sub_Estado_DME_REP_EBV_Editar
                AddHandler Sub_Estado_CIE.Click, AddressOf Sb_Cerrar_El_Reclamo

                Btn_Cerrar_Reclamo.Visible = True

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Recopilar_Informacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Recopilar_Informacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Resolucion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Resolucion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Validacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_05_Validacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_06_Aviso_Cliente.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_06_Aviso_Cliente.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Sub_Estado_REM.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Sub_Estado_REM.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Sub_Estado_RVD.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Sub_Estado_RVD.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Sub_Estado_DME_REP_EBV.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Sub_Estado_DME_REP_EBV.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Sub_Estado_CIE.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Sub_Estado_CIE.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case "CIE"

                AddHandler Estado_01_Ingreso.Click, AddressOf Sb_Estado_01_Ver_Ingreso
                AddHandler Estado_02_Revision.Click, AddressOf Sb_Estado_02_Informacion_Aceptar_Estado
                AddHandler Estado_03_Recopilar_Informacion.Click, AddressOf Sb_Estado_03_Revisar_Recopilar_Informacion
                AddHandler Estado_04_Resolucion.Click, AddressOf Sb_Estado_04_Ver_Resolucion
                AddHandler Estado_05_Validacion.Click, AddressOf Sb_Estado_05_Revisar_Validacion
                AddHandler Estado_06_Aviso_Cliente.Click, AddressOf Sb_Estado_06_Aviso_Cliente

                AddHandler Sub_Estado_REM.Click, AddressOf Sb_Sub_Estado_REM_Revisar
                AddHandler Sub_Estado_RVD.Click, AddressOf Sb_Sub_Estado_RVD_Revisar
                AddHandler Sub_Estado_DME_REP_EBV.Click, AddressOf Sb_Sub_Estado_DME_REP_EBV_Revisar

                AddHandler Estado_01_Ingreso.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_01_Ingreso.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_02_Revision.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_02_Revision.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_03_Recopilar_Informacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_03_Recopilar_Informacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_04_Resolucion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_04_Resolucion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_05_Validacion.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_05_Validacion.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Estado_06_Aviso_Cliente.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Estado_06_Aviso_Cliente.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Sub_Estado_REM.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Sub_Estado_REM.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Sub_Estado_RVD.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Sub_Estado_RVD.MouseLeave, AddressOf Estado_Cursor_MouseLeave

                AddHandler Sub_Estado_DME_REP_EBV.MouseEnter, AddressOf Estado_Cursor_MouseEnter
                AddHandler Sub_Estado_DME_REP_EBV.MouseLeave, AddressOf Estado_Cursor_MouseLeave

            Case Else

                _Proximo_Estado = Nothing 'Estado_01_Ingreso

        End Select


        Sb_Actualizar_Estados()

        If Not (_Proximo_Estado Is Nothing) Then

            _Proximo_Estado.TextColor = Color.Black
            _Proximo_Estado.ProgressColors = New System.Drawing.Color() {Color.Yellow, Color.Yellow} '{Color.GreenYellow, Color.GreenYellow}
            _Proximo_Estado.Value = 100
            _Proximo_Estado.HotTracking = True

            'AddHandler _Proximo_Estado.MouseEnter, AddressOf Estado_MouseEnter
            'AddHandler _Proximo_Estado.MouseLeave, AddressOf Estado_MouseLeave

        End If

    End Sub

    Private Sub Estado_Cursor_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
        sender.VALUE = 0
    End Sub

    Private Sub Estado_Cursor_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
        sender.VALUE = 100
    End Sub

    Private Sub Estado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.VALUE = 0
    End Sub

    Private Sub Estado_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.VALUE = 100
    End Sub

#Region "EVENTOS ESTADOS"

#Region "ESTADO 1"

    Sub Sb_Estado_01_Ver_Ingreso()

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Rc_01_Ingreso(Cl_Reclamo.Enum_Accion.Editar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Pro_Cl_Reclamo.Pro_Accion = Cl_Reclamo.Enum_Accion.Editar
        Fm.ShowDialog(Me)
        _Grabar = Fm.Pro_Grabar
        Fm.Dispose()

        If _Grabar Then

            _Cl_Reclamo.Sb_Cargar_Reclamo(_Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo"))
            Sb_Actualizar_Datos()

        End If

    End Sub

#End Region

#Region "ESTADO 2 "
    Sub Sb_Estado_02_Enviar_a_Revision()

        If MessageBoxEx.Show(Me, "¿Desa confirmar el envío de este reclamo al departamento de " & Lbl_Tipo_De_Reclamo.Text & "?",
                             "Enviar reclamo para su aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'RVE' 
                            Where Id_Reclamo = " & _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo") & vbCrLf &
                            "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario) Values " &
                            "(" & _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo") & ",'RVE','" & FUNCIONARIO & "')"

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                _Cl_Reclamo.Sb_Cargar_Reclamo(_Cl_Reclamo.Id_Reclamo)
                Me.Close()
            End If

        End If

    End Sub
    Sub Sb_Estado_02_Aceptar_Reclamo_Enviar_A_Recopilacion_De_Informacion()

        Dim _Grabar As Boolean
        Dim _Aceptado As Boolean
        Dim _Rechazado As Boolean

        Dim Fm As New Frm_Rc_02_Revision
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.ShowDialog(Me)
        _Grabar = Fm.Pro_Grabar
        _Aceptado = Fm.Pro_Aceptado
        _Rechazado = Fm.Pro_Rechazado
        Fm.Dispose()

        If _Aceptado Or _Rechazado Then

            _Abrir_Reclamo = _Aceptado
            Me.Close()

        End If

    End Sub

    Sub Sb_Estado_02_Informacion_Aceptar_Estado()

        Try

            Dim _Fila As DataRow() = _Cl_Reclamo.Pro_Tbl_Estados.Select("Estado = 'RCI'")

            Dim _Estado = _Fila(0).Item("Estado")
            Dim _Nombre_Funcionario_Autoriza = _Fila(0).Item("Nombre_Funcionario_Autoriza")
            Dim _Fecha_Fijacion = _Fila(0).Item("Fecha_Fijacion")

            MessageBoxEx.Show(Me, "Funcionario que autoriza la revisión del reclamo: " & _Nombre_Funcionario_Autoriza & vbCrLf &
                                  "Fecha de apertura: " & FormatDateTime(_Fecha_Fijacion, DateFormat.ShortDate),
                                  "Apertura de reclamo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "No se encontro información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

#End Region

#Region "ESTADO 3"

    Sub Sb_Estado_03_Recopilar_Informacion()

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")

        Dim _Permiso = "RclRes" & _Tipo_Reclamo

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Dim Fm As New Frm_Rc_03_Recopilar_Informacion2
            Fm.Pro_Cl_Reclamo = _Cl_Reclamo

            If _Cl_Reclamo.Estado = "RSL" Then
                Fm.Btn_Resolucion.Visible = False
            End If

            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                _Cl_Reclamo.Sb_Cargar_Reclamo(_Cl_Reclamo.Id_Reclamo)

                If _Cl_Reclamo.Estado = "RCI" Then
                    _Abrir_Reclamo = True
                End If
                Me.Close()
            End If

            Fm.Dispose()

            Sb_Actualizar_Estados()

        End If

    End Sub

    Sub Sb_Estado_03_Revisar_Recopilar_Informacion()

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")
        Dim _Permiso = "RclVal" & _Tipo_Reclamo
        Dim _Tiene_Permiso As Boolean

        If Fx_Tiene_Permiso(Me, "RclRes" & _Tipo_Reclamo,, False) Or Fx_Tiene_Permiso(Me, "RclVal" & _Tipo_Reclamo,, False) Then

            _Tiene_Permiso = True

        Else

            MessageBoxEx.Show(Me, "Usted no posee permisos para revisar esta información" & vbCrLf & vbCrLf &
                              "Para poder ver los datos necesita el permiso : " & "[RclRes" & _Tipo_Reclamo & "] o [" & "RclVal" & _Tipo_Reclamo & "]", "Validación",
                                                                                                                                               MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        If _Tiene_Permiso Then

            Dim Fm As New Frm_Rc_03_Recopilar_Informacion2
            Fm.Pro_Cl_Reclamo = _Cl_Reclamo

            If _Cl_Reclamo.Estado = "RSL" Then
                Fm.Btn_Resolucion.Visible = False
            End If

            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                _Cl_Reclamo.Sb_Cargar_Reclamo(_Cl_Reclamo.Id_Reclamo)

                If _Cl_Reclamo.Estado = "RCI" Then
                    _Abrir_Reclamo = True
                End If
                Me.Close()
            End If

            Fm.Dispose()

            Sb_Actualizar_Estados()

        End If

    End Sub

#End Region

#Region "ESTADO 4"

    Sub Sb_Estado_04_Ver_Resolucion()

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")
        Dim _Permiso = "RclVal" & _Tipo_Reclamo
        Dim _Tiene_Permiso As Boolean

        If Fx_Tiene_Permiso(Me, "RclRes" & _Tipo_Reclamo,, False) Or Fx_Tiene_Permiso(Me, "RclVal" & _Tipo_Reclamo,, False) Then

            _Tiene_Permiso = True

        Else

            MessageBoxEx.Show(Me, "Usted no posee permisos para revisar esta información" & vbCrLf & vbCrLf &
                              "Para poder ver los datos necesita el permiso : " & "[RclRes" & _Tipo_Reclamo & "] o [" & "RclVal" & _Tipo_Reclamo & "]", "Validación",
                                                                                                                                               MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        If _Tiene_Permiso Then

            Dim _Enviar_A_Validacion As Boolean

            Dim Fm As New Frm_Rc_04_Resolucion(Cl_Reclamo.Enum_Accion.Editar)
            Fm.Pro_Cl_Reclamo = _Cl_Reclamo
            Fm.Btn_Aprobar.Visible = False
            Fm.Btn_Rechazar.Visible = False
            Fm.ShowDialog(Me)
            _Enviar_A_Validacion = Fm.Pro_Enviar_A_Validacion
            Fm.Dispose()

            If _Enviar_A_Validacion Then
                Me.Close()
            End If

        End If

    End Sub

#End Region

#Region "ESTADO 5"

    Sub Sb_Estado_05_Validacion()

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")

        Dim _Permiso = "RclVal" & _Tipo_Reclamo

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Dim Fm As New Frm_Rc_05_Validacion
            Fm.Pro_Cl_Reclamo = _Cl_Reclamo
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then

                _Cl_Reclamo.Sb_Cargar_Reclamo(_Cl_Reclamo.Id_Reclamo)

                If _Cl_Reclamo.Codigo_Accion = "NO" Then

                    Dim _Row_Avi = _Cl_Reclamo.Pro_Tbl_Estados.Select("Estado = 'AVI'")

                    If CBool(_Row_Avi.Length) Then

                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'GES',Sub_Estado = 'RCZ'" & vbCrLf &
                                                           "Where Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo & vbCrLf &
                                                           "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values " &
                                                           "(" & _Cl_Reclamo.Id_Reclamo & ",'GES','" & FUNCIONARIO & "','...')" & vbCrLf &
                                                           "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values " &
                                                           "(" & _Cl_Reclamo.Id_Reclamo & ",'RZC','" & FUNCIONARIO & "','Rechazado...123')"
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)
                        Sb_Cerrar_Reclamo(False)

                    End If

                Else
                    Me.Close()
                End If

            End If

            Fm.Dispose()

        End If

    End Sub

    Sub Sb_Estado_05_Revisar_Validacion()

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")

        Dim _Permiso = "RclVal" & _Tipo_Reclamo
        Dim _Tiene_Permiso As Boolean

        If Fx_Tiene_Permiso(Me, "RclRes" & _Tipo_Reclamo,, False) Or Fx_Tiene_Permiso(Me, "RclVal" & _Tipo_Reclamo,, False) Then

            _Tiene_Permiso = True

        Else

            MessageBoxEx.Show(Me, "Usted no posee permisos para revisar esta información" & vbCrLf & vbCrLf &
                              "Para poder ver los datos necesita el permiso : " & "[RclRes" & _Tipo_Reclamo & "] o [" & "RclVal" & _Tipo_Reclamo & "]", "Validación",
                                                                                                                                               MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        If _Tiene_Permiso Then

            Dim Fm As New Frm_Rc_05_Validacion
            Fm.Pro_Cl_Reclamo = _Cl_Reclamo
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

#End Region

#Region "ESTADO 6"

    Sub Sb_Estado_06_Aviso_Cliente()

        Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")

        If _Cl_Reclamo.Estado <> "AVI" Then

            If Not (Fx_Tiene_Permiso(Me, "RclRes" & _Tipo_Reclamo,, False) Or Fx_Tiene_Permiso(Me, "RclVal" & _Tipo_Reclamo,, False)) Then

                MessageBoxEx.Show(Me, "Usted no posee permisos para revisar esta información" & vbCrLf & vbCrLf &
                                  "Para poder ver los datos necesita el permiso : " & "[RclRes" & _Tipo_Reclamo & "] o [" & "RclVal" & _Tipo_Reclamo & "]", "Validación",
                                                                                                                                                   MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

        End If

        Dim Fm As New Frm_Rc_06_Aviso_Cliente
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.ShowDialog(Me)
        Dim _Enviado = Fm.Pro_Enviado
        Fm.Dispose()

        If _Enviado Then

            If _Cl_Reclamo.Codigo_Accion = "NO" Then

                Dim _Row_Avi = _Cl_Reclamo.Pro_Tbl_Estados.Select("Estado = 'AVI'")

                If CBool(_Row_Avi.Length) Then

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'GES',Sub_Estado = 'RCZ'" & vbCrLf &
                                   "Where Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo & vbCrLf &
                                    "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values " &
                                                       "(" & _Cl_Reclamo.Id_Reclamo & ",'GES','" & FUNCIONARIO & "','...')" & vbCrLf &
                                                       "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values " &
                                                       "(" & _Cl_Reclamo.Id_Reclamo & ",'RZC','" & FUNCIONARIO & "','Rechazado...123')"
                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)
                    Sb_Cerrar_Reclamo(False)

                End If

            Else

                Me.Close()

            End If

        End If

    End Sub

#End Region

#Region "ESTADO 7"



#End Region

    Sub Sb_Info_Estado_a_realizar()
        MessageBoxEx.Show(Me, "Debe: " & _Info_Estado_A_Realizar, "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

#End Region

#Region "EVENTOS SUB ESTADOS"


#Region "PROCEDIMIENTO SUB ESTADO"

    Sub Sb_Sub_Estado_Nuevo()

        Dim _Fijar_Estado As Boolean
        Dim _Permiso As String

        Select Case _Cl_Reclamo.Sub_Estado

            Case "REM"
                _Permiso = "Rcl00007"
            Case "RVD"
                _Permiso = "Rcl00008"
            Case "DME"
                _Permiso = "Rcl00009"
            Case "REP"
                _Permiso = "Rcl00010"
            Case "EBV"
                _Permiso = "Rcl00011"
            Case "RAC"
                _Permiso = "Rcl00012"

        End Select

        If Fx_Tiene_Permiso(Me, _Permiso) Then

            Dim Fm As New Frm_RcSe_Ges_Sub_Estados(_Cl_Reclamo.Estado, _Cl_Reclamo.Sub_Estado, Cl_Reclamo.Enum_Accion.Nuevo)
            Fm.Pro_Cl_Reclamo = _Cl_Reclamo
            Fm.ShowDialog(Me)
            _Fijar_Estado = Fm.Pro_Fijar_Estado
            Fm.Dispose()

            If _Fijar_Estado Then

                If _Cl_Reclamo.Estado = "ACI" Then
                    Sb_Cerrar_Reclamo(True)
                Else
                    _Abrir_Reclamo = True
                    Me.Close()
                End If

            End If

        End If

    End Sub

#End Region


#Region "SUB ESTADO 1 REM"

    Sub Sb_Sub_Estado_REM_Editar()

        Dim Fm As New Frm_RcSe_Ges_Sub_Estados(_Cl_Reclamo.Estado, "REM", Cl_Reclamo.Enum_Accion.Editar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Fijar_Estado.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Sub Sb_Sub_Estado_REM_Revisar()

        Dim Fm As New Frm_RcSe_Ges_Sub_Estados(_Cl_Reclamo.Estado, "REM", Cl_Reclamo.Enum_Accion.Revisar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Fijar_Estado.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

#Region "SUB ESTADO 2 RVD"

    Sub Sb_Sub_Estado_RVD_Editar()

        Dim Fm As New Frm_RcSe_Ges_Sub_Estados(_Cl_Reclamo.Estado, "RVD", Cl_Reclamo.Enum_Accion.Editar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Fijar_Estado.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Sub Sb_Sub_Estado_RVD_Revisar()

        Dim Fm As New Frm_RcSe_Ges_Sub_Estados(_Cl_Reclamo.Estado, "RVD", Cl_Reclamo.Enum_Accion.Revisar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Fijar_Estado.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

#End Region

#Region "SUB ESTADO 3 DME, REP, EBV"

    Sub Sb_Sub_Estado_DME_REP_EBV_Editar()

        Dim Fm As New Frm_RcSe_Ges_Sub_Estados(_Cl_Reclamo.Estado, _Cl_Reclamo.Sub_Estado, Cl_Reclamo.Enum_Accion.Editar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Fijar_Estado.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Sub Sb_Sub_Estado_DME_REP_EBV_Revisar()

        Dim Fm As New Frm_RcSe_Ges_Sub_Estados(_Cl_Reclamo.Estado, _Cl_Reclamo.Sub_Estado, Cl_Reclamo.Enum_Accion.Revisar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Fijar_Estado.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

#End Region


#End Region

#End Region

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
    Private Sub Frm_Rc_Reclamo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Borrar_Archivos_Temporales()
    End Sub
    Sub Sb_Borrar_Archivos_Temporales()

        Dim _Path = _Cl_Reclamo.Path_Temporales
        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Reclamo_Archivos Where Id_Reclamo = " & _Cl_Reclamo.Id_Reclamo
        Dim _Tbl_Adjuntos As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        For Each _Archivo As DataRow In _Tbl_Adjuntos.Rows

            Dim _Id_Archivos = _Archivo.Item("Id_Archivos")
            Dim _Nombre_Archivo = _Archivo.Item("Nombre_Archivo")
            Dim _Archivo_adjunto As String = _Path & "\" & _Nombre_Archivo

            Try
                System.IO.File.Delete(_Archivo_adjunto)
            Catch ex As Exception
            End Try

        Next

    End Sub

    Private Sub Btn_Cerrar_Reclamo_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar_Reclamo.Click
        Sb_Cerrar_Reclamo(True)
    End Sub

    Sub Sb_Cerrar_El_Reclamo()
        Sb_Cerrar_Reclamo(True)
    End Sub

    Sub Sb_Cerrar_Reclamo(_Pregunta_Si_Cierra As Boolean)

        Dim _Id_Reclamo = _Cl_Reclamo.Id_Reclamo
        Dim _Observacion As String

        Dim _Cerrar = True

        If _Pregunta_Si_Cierra Then

            Dim _Pregunta = MessageBoxEx.Show(Me, "¿Confirma el cierre del reclamo?", "Cerrar Reclamo",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If _Pregunta <> DialogResult.Yes Then

                _Cerrar = False

            End If

        End If

        If _Cerrar Then

            If Fx_Tiene_Permiso(Me, "Rcl00015") Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'CIE' Where Id_Reclamo = " & _Id_Reclamo & "
                            Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values 
                           (" & _Id_Reclamo & ",'ACI','" & FUNCIONARIO & "','" & _Observacion & "')"
                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then

                    MessageBoxEx.Show(Me, "Reclamo cerrado correctamente", "Cerrar Reclamo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                    Me.Close()

                End If

            End If

        End If

    End Sub

End Class