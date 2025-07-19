Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Alertas_Pdc

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Ds_Alertas As DataSet

    Dim _Idpote As Integer
    Dim _Idpotl As Integer
    Dim _Idpotpr As Integer
    Dim _Numot As String
    Dim _Operacion As String

    Dim _Codigoob As String
    'Dim _Nombreob As String
    Dim _Cerrar_Al_Grabar As Boolean

    Dim _Row_Operacion As DataRow
    Dim _Row_Meson As DataRow
    Dim _Row_Operario_Crea As DataRow

    Dim _Se_Puede_Editar As Boolean

    Public Property Se_Puede_Editar As Boolean
        Get
            Return _Se_Puede_Editar
        End Get
        Set(value As Boolean)
            _Se_Puede_Editar = value
        End Set
    End Property

    Public Property Codigoob As String
        Get
            Return _Codigoob
        End Get
        Set(value As String)

            _Codigoob = value
            Consulta_sql = "Select * From PMAEOB Where CODIGOOB = '" & _Codigoob & "'"
            _Row_Operario_Crea = _Sql.Fx_Get_DataRow(Consulta_sql)

        End Set
    End Property

    Public Property Cerrar_Al_Grabar As Boolean
        Get
            Return _Cerrar_Al_Grabar
        End Get
        Set(value As Boolean)
            _Cerrar_Al_Grabar = value
        End Set
    End Property

    Enum Enum_Alertas
        Crear
        Editar
        Eliminar
        Ver_Historial
    End Enum

    Public Sub New(_Idpote As Integer, _Idpotl As Integer, _Idpotpr As Integer, _Numot As String, _Operacion As String, _CodMeson As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Alertas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Lectura, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Me._Idpote = _Idpote
        Me._Idpotl = _Idpotl
        Me._Idpotpr = _Idpotpr
        Me._Numot = _Numot
        Me._Operacion = _Operacion

        Consulta_sql = "Select * From POPER Where OPERACION = '" & _Operacion & "'"
        _Row_Operacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pdc_Mesones Where Codmeson = '" & _CodMeson & "'"
        _Row_Meson = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_Meson.Text = "Mesón: " & _CodMeson.ToString.Trim & " - " & _Row_Meson.Item("Nommeson")
        Lbl_Operacion.Text = "Operación: " & _Operacion.ToString.Trim & " - " & _Row_Operacion.Item("NOMBREOP")

        Sb_Actualizar_Alertas()

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Crear_Alerta.ForeColor = Color.White
        End If

        _Se_Puede_Editar = True

    End Sub

    Private Sub Frm_Alertas_Pdc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Btn_Crear_Alerta.Enabled = _Se_Puede_Editar
        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Alertas()

        Consulta_sql = "Select Id_Alertas,Empresa,Idpotpr,Idpotl,Idpote,Numot,Operacion,Codigoob_Envia,NOMBREOB," &
                        "Alerta,Fecha_Alerta As Fecha,Fecha_Alerta As Hora,Editada,Id_Padre_Edit,Eliminada
                        Into #Alertas
                        From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas
                        Left Join PMAEOB On CODIGOOB = Codigoob_Envia
                        Where Idpote = " & _Idpote & " And Operacion = '" & _Operacion & "' And Eliminada = 0 and Editada = 0
                        
                        Select Id_Lectura,Id_Alertas,Leida,Codigoob_Lee,NOMBREOB,Fecha_Leida As Fecha,Fecha_Leida As Hora
                        Into #Lecturas
                        From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas_Lectura 
                        Left Join PMAEOB On CODIGOOB = Codigoob_Lee
                        Where Id_Alertas In (Select Id_Alertas From #Alertas)
                        
                        Select * From  #Alertas
                        Select * From  #Lecturas
                        
                        Drop Table #Alertas
                        Drop Table #Lecturas"

        _Ds_Alertas = _Sql.Fx_Get_DataSet(Consulta_sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  

        _Ds_Alertas.Relations.Add("Rel_Aler_x_Lect",
                         _Ds_Alertas.Tables("Table").Columns("Id_Alertas"),
                         _Ds_Alertas.Tables("Table1").Columns("Id_Alertas"), False)

    End Sub

    Sub Sb_Actualizar_Grilla()

        Grilla_Alertas.DataSource = _Ds_Alertas
        Grilla_Alertas.DataMember = "Table"

        Grilla_Lectura.DataSource = _Ds_Alertas
        Grilla_Lectura.DataMember = "Table.Rel_Aler_x_Lect"

        OcultarEncabezadoGrilla(Grilla_Alertas, True)
        OcultarEncabezadoGrilla(Grilla_Lectura, True)

        Txt_Alerta.DataBindings.Clear()
        Txt_Alerta.DataBindings.Add("text", _Ds_Alertas, "Table.Alerta")

        Dim _DisplayIndex = 0

        With Grilla_Alertas

            .Columns("NOMBREOB").Visible = True
            .Columns("NOMBREOB").HeaderText = "Nombre operario que crea alerta"
            .Columns("NOMBREOB").Width = 320
            .Columns("NOMBREOB").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 65
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm"
            .Columns("Hora").Width = 65
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With


        With Grilla_Lectura

            .Columns("NOMBREOB").Visible = True
            .Columns("NOMBREOB").HeaderText = "Leído por"
            .Columns("NOMBREOB").Width = 320
            .Columns("NOMBREOB").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Fecha").Visible = True
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fecha").Width = 65
            .Columns("Fecha").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Hora").Visible = True
            .Columns("Hora").HeaderText = "Hora"
            .Columns("Hora").DefaultCellStyle.Format = "hh:mm"
            .Columns("Hora").Width = 65
            .Columns("Hora").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Alertas(_Accion As Enum_Alertas)

        Dim _Fila_Alerta As DataGridViewRow = Grilla_Alertas.Rows(Grilla_Alertas.CurrentRow.Index)

        Dim _Idpotpr As Integer = _Fila_Alerta.Cells("Idpotpr").Value
        Dim _Idpotl As Integer = _Fila_Alerta.Cells("Idpotl").Value
        Dim _Idpote As Integer = _Fila_Alerta.Cells("Idpote").Value
        Dim _Numot As Integer = _Fila_Alerta.Cells("Numot").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas 
                        Where Idpote = " & _Idpote & " And Idpotl = " & _Idpotl & " And Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Eliminada = 0 And Editada = 0"
        Dim _Row_Alerta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id_Alertas As Integer
        Dim _Aceptar As Boolean
        Dim _Alerta As String = String.Empty

        If Not IsNothing(_Row_Alerta) Then
            _Id_Alertas = _Row_Alerta.Item("Id_Alertas")
            _Alerta = _Row_Alerta.Item("Alerta")
        End If

        Select Case _Accion

            Case Enum_Alertas.Ver_Historial

                'Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas 
                '                Where Idpote = " & _Idpote & " And Idpotl = " & _Idpotl & " And Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Eliminada = 0 And Editada = 0"
                'Dim _Tbl_Alertas As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Case Enum_Alertas.Crear, Enum_Alertas.Editar

                Consulta_sql = "Select Top 1 PdM.*,Obre.NOMBREOB As Nombre_Obrero From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos PdM
                                    Left Join PMAEOB Obre On Obre.CODIGOOB = PdM.Obrero
                                Where Idpotpr = " & _Idpotpr & " And Estado = 'EMQ'"
                Dim _Row_Maquina_vs_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not IsNothing(_Row_Maquina_vs_Producto) Then

                    Dim _Maquina As String = _Row_Maquina_vs_Producto.Item("CodMaq").ToString.Trim & " - " & _Row_Maquina_vs_Producto.Item("Descripcion").ToString.Trim
                    Dim _Nombre_Obrero As String = _Row_Maquina_vs_Producto.Item("Nombre_Obrero").ToString.Trim
                    Dim _Fecha_Hora_Inicio As DateTime = _Row_Maquina_vs_Producto.Item("Fecha_Hora_Inicio")

                    If MessageBoxEx.Show(Me, "La operación esta siendo actualmente procesada." & vbCrLf & vbCrLf &
                                         "Operario: " & _Nombre_Obrero & vbCrLf &
                                         "Maquina: " & _Maquina & vbCrLf &
                                         "Fecha/hora inicio: " & _Fecha_Hora_Inicio & vbCrLf & vbCrLf &
                                      "¿Desea igualmente ingresar/editar la alerta?",
                                      "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                        Return

                    End If

                End If

                If Not IsNothing(_Row_Operario_Crea) Then


                Else

                    MessageBoxEx.Show(Me, "Debe seleccionar al usuario que envía esta alerta", "Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"

                    Dim _Filtrar As New Clas_Filtros_Random(Me)
                    'Dim _Codigoob As String
                    'Dim _Nombreob As String

                    _Filtrar.Pro_Nombre_Encabezado_Informe = "SELECCIONE AL OPERARIO"

                    If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operarios, _Sql_Filtro_Condicion_Extra,
                               Nothing, False, True) Then

                        Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

                        Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

                        _Codigoob = Trim(_Row.Item("Codigo"))
                        '_Nombreob = Trim(_Row.Item("Descripcion"))

                    Else

                        Return

                    End If

                End If

                If _Accion = Enum_Alertas.Crear Then _Alerta = String.Empty

                Dim _Old_Alerta As String = _Alerta.ToString.Trim

                _Aceptar = InputBox_Bk(Me, "Ingrese la observación para mostrar",
                                       "Crear alerta", _Alerta, True, _Tipo_Mayus_Minus.Mayusculas, 300, True, _Tipo_Imagen.Texto)

                If _Aceptar Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas (Empresa,Idpotpr,Idpotl,Idpote,Numot,Operacion,Codigoob_Envia,Alerta,Id_Padre_Edit) Values 
                                ('" & Mod_Empresa & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & _Numot &
                                "','" & _Operacion & "','" & _Codigoob & "','" & _Alerta & "'," & _Id_Alertas & ")"

                    If _Accion = Enum_Alertas.Editar Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas Set Editada = 1 Where Id_Alertas = " & _Id_Alertas & vbCrLf &
                                       Consulta_sql

                        If _Alerta.Trim = _Old_Alerta.Trim Then
                            Return
                        End If

                    End If

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Sb_Actualizar_Alertas()
                        Sb_Actualizar_Grilla()
                        MessageBoxEx.Show(Me, "Alerta insertada/actualizada correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If


            Case Enum_Alertas.Eliminar

                If MessageBoxEx.Show(Me, "¿Confirma la eliminación de esta alerta?", "Eliminar alerta",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas Set Eliminada = 1 Where Id_Alertas = " & _Id_Alertas

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        Txt_Alerta.Text = String.Empty
                        Sb_Actualizar_Alertas()
                        Sb_Actualizar_Grilla()
                        MessageBoxEx.Show(Me, "Alerta eliminada correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

        End Select

    End Sub

    Sub Sb_Crear_Alerta()

        'Dim _Fila_Alerta As DataGridViewRow = Grilla_Alertas.Rows(Grilla_Alertas.CurrentRow.Index)

        'Dim _Idpotpr As Integer = _Fila_Alerta.Cells("Idpotpr").Value
        'Dim _Idpotl As Integer = _Fila_Alerta.Cells("Idpotl").Value
        'Dim _Idpote As Integer = _Fila_Alerta.Cells("Idpote").Value
        'Dim _Numot As Integer = _Fila_Alerta.Cells("Numot").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas 
                        Where Idpote = " & _Idpote & " And Idpotl = " & _Idpotl & " And Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Eliminada = 0 And Editada = 0"
        Dim _Row_Alerta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id_Alertas As Integer
        Dim _Aceptar As Boolean
        Dim _Alerta As String = String.Empty

        If Not IsNothing(_Row_Alerta) Then
            _Id_Alertas = _Row_Alerta.Item("Id_Alertas")
            _Alerta = _Row_Alerta.Item("Alerta")
        End If

        Consulta_sql = "Select Top 1 PdM.*,Obre.NOMBREOB As Nombre_Obrero From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos PdM
                                    Left Join PMAEOB Obre On Obre.CODIGOOB = PdM.Obrero
                                Where Idpotpr = " & _Idpotpr & " And Estado = 'EMQ'"
        Dim _Row_Maquina_vs_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Maquina_vs_Producto) Then

            Dim _Maquina As String = _Row_Maquina_vs_Producto.Item("CodMaq").ToString.Trim & " - " & _Row_Maquina_vs_Producto.Item("Descripcion").ToString.Trim
            Dim _Nombre_Obrero As String = _Row_Maquina_vs_Producto.Item("Nombre_Obrero").ToString.Trim
            Dim _Fecha_Hora_Inicio As DateTime = _Row_Maquina_vs_Producto.Item("Fecha_Hora_Inicio")

            If MessageBoxEx.Show(Me, "La operación esta siendo actualmente procesada." & vbCrLf & vbCrLf &
                                         "Operario: " & _Nombre_Obrero & vbCrLf &
                                         "Maquina: " & _Maquina & vbCrLf &
                                         "Fecha/hora inicio: " & _Fecha_Hora_Inicio & vbCrLf & vbCrLf &
                                      "¿Desea igualmente ingresar/editar la alerta?",
                                      "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return

            End If

        End If

        If IsNothing(_Row_Operario_Crea) Then

            'MessageBoxEx.Show(Me, "DEBE SELECCIONAR AL OPERARIO QUE CREA ESTA ALERTA", "Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim _Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"

            Dim _Filtrar As New Clas_Filtros_Random(Me)


            _Filtrar.Pro_Nombre_Encabezado_Informe = "SELECCIONE AL OPERARIO QUE CREA LA ALERTA"

            If _Filtrar.Fx_Filtrar(Nothing,
                                   Clas_Filtros_Random.Enum_Tabla_Fl._Pdc_Operarios, _Sql_Filtro_Condicion_Extra,
                                   Nothing, False, True) Then

                Dim _Tbl_Operacion As DataTable = _Filtrar.Pro_Tbl_Filtro

                Dim _Row As DataRow = _Tbl_Operacion.Rows(0)

                _Codigoob = Trim(_Row.Item("Codigo"))
                '_Nombreob = Trim(_Row.Item("Descripcion"))

            Else

                Return

            End If

        End If

        _Alerta = String.Empty

        _Aceptar = InputBox_Bk(Me, "Ingrese la observación para mostrar",
                                       "Crear alerta", _Alerta, True, _Tipo_Mayus_Minus.Mayusculas, 300, True, _Tipo_Imagen.Alerta)

        If _Aceptar Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas (Empresa,Idpotpr,Idpotl,Idpote,Numot,Operacion,Codigoob_Envia,Alerta,Id_Padre_Edit) Values 
                                ('" & Mod_Empresa & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & _Numot &
                                "','" & _Operacion & "','" & _Codigoob & "','" & _Alerta & "'," & _Id_Alertas & ")"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Sb_Actualizar_Alertas()
                Sb_Actualizar_Grilla()
                MessageBoxEx.Show(Me, "Alerta insertada/actualizada correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Sub Sb_Editar_Alerta()

        Dim _Fila_Alerta As DataGridViewRow = Grilla_Alertas.Rows(Grilla_Alertas.CurrentRow.Index)

        Dim _Idpotpr As Integer = _Fila_Alerta.Cells("Idpotpr").Value
        Dim _Idpotl As Integer = _Fila_Alerta.Cells("Idpotl").Value
        Dim _Idpote As Integer = _Fila_Alerta.Cells("Idpote").Value
        Dim _Numot As Integer = _Fila_Alerta.Cells("Numot").Value
        Dim _Codigoob_Envia As String = _Fila_Alerta.Cells("Codigoob_Envia").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas 
                        Where Idpote = " & _Idpote & " And Idpotl = " & _Idpotl & " And Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Eliminada = 0 And Editada = 0"
        Dim _Row_Alerta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id_Alertas As Integer
        Dim _Aceptar As Boolean
        Dim _Alerta As String = String.Empty

        If Not IsNothing(_Row_Alerta) Then

            _Id_Alertas = _Row_Alerta.Item("Id_Alertas")
            _Alerta = _Row_Alerta.Item("Alerta")

        End If

        Consulta_sql = "Select Top 1 PdM.*,Obre.NOMBREOB As Nombre_Obrero From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos PdM
                        Left Join PMAEOB Obre On Obre.CODIGOOB = PdM.Obrero
                        Where Idpotpr = " & _Idpotpr & " And Estado = 'EMQ'"

        Dim _Row_Maquina_vs_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Maquina_vs_Producto) Then

            Dim _Maquina As String = _Row_Maquina_vs_Producto.Item("CodMaq").ToString.Trim & " - " & _Row_Maquina_vs_Producto.Item("Descripcion").ToString.Trim
            Dim _Nombre_Obrero As String = _Row_Maquina_vs_Producto.Item("Nombre_Obrero").ToString.Trim
            Dim _Fecha_Hora_Inicio As DateTime = _Row_Maquina_vs_Producto.Item("Fecha_Hora_Inicio")

            If MessageBoxEx.Show(Me, "La operación esta siendo actualmente procesada." & vbCrLf & vbCrLf &
                                 "Operario: " & _Nombre_Obrero & vbCrLf &
                                 "Maquina: " & _Maquina & vbCrLf &
                                 "Fecha/hora inicio: " & _Fecha_Hora_Inicio & vbCrLf & vbCrLf &
                                 "¿Desea igualmente ingresar/editar la alerta?",
                                 "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return

            End If

        End If

        Dim _Old_Alerta As String = _Alerta.ToString.Trim

        _Aceptar = InputBox_Bk(Me, "Ingrese la observación para mostrar",
                                       "Crear alerta", _Alerta, True, _Tipo_Mayus_Minus.Mayusculas, 300, True, _Tipo_Imagen.Texto)

        If _Aceptar Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas (Empresa,Idpotpr,Idpotl,Idpote,Numot,Operacion,Codigoob_Envia,Alerta,Id_Padre_Edit) Values 
                           ('" & Mod_Empresa & "'," & _Idpotpr & "," & _Idpotl & "," & _Idpote & ",'" & _Numot &
                           "','" & _Operacion & "','" & _Codigoob_Envia & "','" & _Alerta & "'," & _Id_Alertas & ")
                           Update " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas Set Editada = 1 Where Id_Alertas = " & _Id_Alertas

            If _Alerta.Trim = _Old_Alerta.Trim Then
                Return
            End If
        Else
            Return
        End If

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            Sb_Actualizar_Alertas()
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Alerta insertada/actualizada correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Sub Sb_Eliminar_Alerta()

        Dim _Fila_Alerta As DataGridViewRow = Grilla_Alertas.Rows(Grilla_Alertas.CurrentRow.Index)

        Dim _Idpotpr As Integer = _Fila_Alerta.Cells("Idpotpr").Value
        Dim _Idpotl As Integer = _Fila_Alerta.Cells("Idpotl").Value
        Dim _Idpote As Integer = _Fila_Alerta.Cells("Idpote").Value
        Dim _Numot As Integer = _Fila_Alerta.Cells("Numot").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas 
                        Where Idpote = " & _Idpote & " And Idpotl = " & _Idpotl & " And Idpotpr = " & _Idpotpr & " And Operacion = '" & _Operacion & "' And Eliminada = 0 And Editada = 0"
        Dim _Row_Alerta As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Id_Alertas = _Row_Alerta.Item("Id_Alertas")

        If MessageBoxEx.Show(Me, "¿Confirma la eliminación de esta alerta?", "Eliminar alerta",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pdp_MesonVsAlertas Set Eliminada = 1 Where Id_Alertas = " & _Id_Alertas

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Sb_Actualizar_Alertas()
                Sb_Actualizar_Grilla()
                MessageBoxEx.Show(Me, "Alerta eliminada correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub

    Private Sub Frm_Alertas_Pdc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Crear_Alerta_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Alerta.Click
        Sb_Crear_Alerta()
    End Sub

    Private Sub Btn_Alerta_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Alerta_Editar.Click
        Sb_Editar_Alerta()
    End Sub

    Private Sub Btn_Alerta_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Alerta_Eliminar.Click
        'Sb_Alertas(Enum_Alertas.Eliminar)
        Sb_Eliminar_Alerta()
    End Sub

    Private Sub Grilla_Alertas_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla_Alertas.MouseDown

        If _Se_Puede_Editar Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                With sender
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                        ShowContextMenu(Menu_Contextual_Alertas)
                    End If
                End With
            End If
        End If

    End Sub

    Private Sub Grilla_Alertas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Alertas.CellDoubleClick
        If _Se_Puede_Editar Then
            ShowContextMenu(Menu_Contextual_Alertas)
        End If
    End Sub


End Class
