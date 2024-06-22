Imports System.Security.Cryptography
Imports DevComponents.DotNetBar
Imports Google.Protobuf.WellKnownTypes
Imports K4os.Compression.LZ4.Internal

Public Class Frm_01_CrearInventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _IdInventario As Integer

    Public Property Grabar As Boolean
    Public Property Cl_Inventario As New Cl_Inventario

    Public Sub New(_IdInventario As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'caract_combo(CmbFuncionarios)
        'Consulta_sql = "SELECT KOFU AS Padre,NOKOFU AS Hijo FROM TABFU"
        'CmbFuncionarios.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

        Me._IdInventario = _IdInventario

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_01_CrearInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If CBool(_IdInventario) Then
            Cl_Inventario.Fx_Llenar_Zw_Inv_Inventario(_IdInventario)
        End If

        With Cl_Inventario.Zw_Inv_Inventario

            Lbl_Empresa.Text = .Nombre_Empresa
            Lbl_Sucursal.Text = .Nombre_Sucursal
            Lbl_Bodega.Text = .Nombre_Bodega
            Txt_NombreInventario.Text = .NombreInventario
            Txt_FuncCargo.Tag = .FuncionarioCargo
            Txt_FuncCargo.Text = .NombreFuncionario
            Dtp_Fecha_Inventario.Value = .Fecha_Inventario
            Chk_Estado.Checked = .Activo

        End With

        Btn_FotoStock.Enabled = CBool(_IdInventario)

        Me.ActiveControl = Txt_NombreInventario

    End Sub
    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click

        With Cl_Inventario.Zw_Inv_Inventario

            .Ano = numero_(Dtp_Fecha_Inventario.Value.Year.ToString, 4)
            .Mes = numero_(Dtp_Fecha_Inventario.Value.Month.ToString, 2)
            .Dia = numero_(Dtp_Fecha_Inventario.Value.Day.ToString, 2)
            .NombreInventario = Txt_NombreInventario.Text
            .FuncionarioCargo = Txt_FuncCargo.Tag
            .NombreFuncionario = Txt_FuncCargo.Text
            .Fecha_Inventario = Dtp_Fecha_Inventario.Value
            .Activo = Chk_Estado.Checked

        End With

        If CBool(_IdInventario) Then
            Sb_Editar_Inventario()
        Else
            Sb_Grabar_Nuevo_Inventario()
        End If

    End Sub

    Sub Editar()

        Dim _Fecha_Inv = Format(Dtp_Fecha_Inventario.Value, "yyyyMMdd")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_History Set NombreInventario = '" & Txt_NombreInventario.Text & "'" & vbCrLf &
                       ",FuncionarioCargo = '" & Txt_FuncCargo.Tag & "'" & vbCrLf &
                       ",NombreFuncionario = '" & Txt_FuncCargo.Text.Trim & "'" & vbCrLf &
                       "Where IdInventario = " & _IdInventario

        If _Sql.Ej_consulta_IDU(Consulta_sql) = True Then
            MessageBoxEx.Show("Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Grabar = True
        End If

    End Sub

    Sub Sb_Editar_Inventario()

        Dim _Mensaje As LsValiciones.Mensajes
        _Mensaje = Cl_Inventario.Fx_Editar_Inventario()

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Grabar = True
            Me.Close()
        End If

    End Sub

    Sub Sb_Grabar_Nuevo_Inventario()

        If String.IsNullOrEmpty(Trim(Txt_NombreInventario.Text)) Then
            MessageBoxEx.Show(Me, "Falta nombre de inventario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NombreInventario.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Trim(Txt_FuncCargo.Text)) Then
            MessageBoxEx.Show(Me, "Falta el funcionario a cargo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_FuncCargo.Focus()
            Return
        End If

        With Cl_Inventario.Zw_Inv_Inventario

            Dim Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_TmpInv_History",
                                                          "Fecha_Inventario = '" & Format(Dtp_Fecha_Inventario.Value, "yyyyMMdd") &
                                                          "' And Empresa = '" & .Empresa &
                                                          "' And Sucursal = '" & .Sucursal & "'" & vbCrLf &
                                                          "And Bodega = '" & .Bodega & "'")

            If CBool(Reg) Then
                MessageBoxEx.Show(Me, "Ya se ha registrado un inventario con esta fecha para esta bodega. No es" & vbCrLf &
                                  "posible crear dos inventarios idénticos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

        End With

        Dim _Mensaje As LsValiciones.Mensajes
        _Mensaje = Cl_Inventario.Fx_Crear_Inventario

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Grabar = True
            Me.Close()
        End If

    End Sub

    Sub Sb_Grabar()

        Dim Fecha_Inv, Ano, Mes, Dia As String
        Dim CodFun, NombreFun As String

        Ano = numero_(Dtp_Fecha_Inventario.Value.Year.ToString, 4)
        Mes = numero_(Dtp_Fecha_Inventario.Value.Month.ToString, 2)
        Dia = numero_(Dtp_Fecha_Inventario.Value.Day.ToString, 2)
        Fecha_Inv = Format(Dtp_Fecha_Inventario.Value, "yyyyMMdd")

        If String.IsNullOrEmpty(Trim(Txt_NombreInventario.Text)) Then
            MessageBoxEx.Show("Falta nombre de inventario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NombreInventario.Focus()
            Return
        End If

        Dim _Empresa_Inv, _Sucursal_Inv, _Bodega_Inv As String

        Dim Reg As Integer = _Sql.Fx_Cuenta_Registros("Zw_TmpInv_History", "Fecha_Inventario = '" & Fecha_Inv &
                                              "' And Empresa = '" & _Empresa_Inv &
                                              "' And Sucursal = '" & _Sucursal_Inv & "'" & vbCrLf &
                                              "And Bodega = '" & _Bodega_Inv & "'")

        If CBool(Reg) Then
            MessageBoxEx.Show("Ya existe un inventario con esta fecha para esta bodega" & vbCrLf &
                              "No puede crear dos inventario iguales", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        CodFun = Txt_FuncCargo.Tag
        NombreFun = Txt_FuncCargo.Text

        Dim dlg As System.Windows.Forms.DialogResult =
        MessageBoxEx.Show(Me, "¿Desea dejar este inventario como activo?", "Activar Inventario", MessageBoxButtons.YesNo)

        Dim Activo As Integer = 0

        Consulta_sql = String.Empty

        If dlg = System.Windows.Forms.DialogResult.Yes Then
            Activo = 1
            Consulta_sql = "Update Zw_TmpInv_History Set Estado = 0"
        End If


        Consulta_sql = Consulta_sql & vbCrLf &
                       "INSERT INTO Zw_TmpInv_History (Ano,Mes,Dia,Fecha_Inventario,Empresa,Sucursal,Bodega," &
                       "Nombre_Empresa, Nombre_Sucursal, Nombre_Bodega,NombreInventario,FuncionarioCargo,NombreFuncionario,Estado) Values" & vbCrLf &
                       "('" & Ano & "','" & Mes & "','" & Dia & "','" & Fecha_Inv &
                       "','" & _Empresa_Inv & "','" & _Sucursal_Inv & "','" & _Bodega_Inv &
                       "','" & Lbl_Empresa.Text & "','" & Lbl_Sucursal.Text & "','" & Lbl_Bodega.Text &
                       "','" & Txt_NombreInventario.Text &
                       "','" & CodFun & "','" & Trim(NombreFun) & "'," & Activo & ")"

        If _Sql.Ej_consulta_IDU(Consulta_sql) = True Then
            MessageBoxEx.Show("Inventario creado correctamente", "Crear inventario", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Grabar = True
            Me.Close()
        End If
    End Sub

    Private Sub Btn_EliminarFotoStock_Click(sender As Object, e As EventArgs) Handles Btn_EliminarFotoStock.Click

        If Not Fx_Tiene_Permiso(Me, "In0010") Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes
        _Mensaje = Cl_Inventario.Fx_EliminarFoto(Me, _IdInventario)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        'EliminarFoto()

    End Sub

    Private Sub Btn_TomarFotoStock_Click(sender As Object, e As EventArgs) Handles Btn_TomarFotoStock.Click

        If Not Fx_Tiene_Permiso(Me, "In0006") Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes
        _Mensaje = Cl_Inventario.Fx_CrearFoto(_IdInventario)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Me.Close()
        End If



    End Sub

    Private Function CrearFoto()
        Try

            Dim Hora As String
            Hora = Now.Hour.ToString & ":" & Now.Minute.ToString & ":" & Now.Second.ToString


            Dim Tbl As New DataTable
            Consulta_sql = "Select * from Zw_TmpInv_History where IdInventario = " & _IdInventario
            Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim Fila As DataRow

            Fila = Tbl.Rows(0)

            Dim Empresa, Sucursal, Bodega As String

            Empresa = Fila.Item("Empresa").ToString
            Sucursal = Fila.Item("Sucursal").ToString
            Bodega = Fila.Item("Bodega").ToString


            Dim Fecha_Inv, Ano, Mes, Dia As String
            Dim CodFun, NombreFun As String

            Ano = numero_(Dtp_Fecha_Inventario.Value.Year.ToString, 4)
            Mes = numero_(Dtp_Fecha_Inventario.Value.Month.ToString, 2)
            Dia = numero_(Dtp_Fecha_Inventario.Value.Day.ToString, 2)
            Fecha_Inv = Format(Dtp_Fecha_Inventario.Value, "yyyyMMdd")


            Consulta_sql = My.Resources._Procedimientos_Inv.Inv_Invetario_Creae_Foto_Stock
            Consulta_sql = Replace(Consulta_sql, "#Ano#", Ano)
            Consulta_sql = Replace(Consulta_sql, "#Mes#", Mes)
            Consulta_sql = Replace(Consulta_sql, "#Dia#", Dia)
            Consulta_sql = Replace(Consulta_sql, "#IdBodega#", 0)
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", Empresa)
            Consulta_sql = Replace(Consulta_sql, "#Sucursal#", Sucursal)
            Consulta_sql = Replace(Consulta_sql, "#Bodega#", Bodega) '#IdInventario#
            Consulta_sql = Replace(Consulta_sql, "#IdInventario#", _IdInventario)

            If _Sql.Ej_consulta_IDU(Consulta_sql) = True Then
                MsgBox("Foto del stock de la bodega creado correctamente", MsgBoxStyle.Information, "Tomar Foto")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Sub EliminarFoto()
        Try

            Dim DatosFotos As Long
            DatosFotos = _Sql.Fx_Cuenta_Registros("ZW_TmpInvFotoInventario",
                                          "IdInventario = " & _IdInventario)

            If DatosFotos = 0 Then
                MessageBoxEx.Show("No existe ninguna foto que eliminar en la base de datos para esta bodega",
                                  "Eliminar foto stock", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Return
            End If

            Dim _Autorizado As Boolean

            Dim Fm_Pass As New Frm_Clave_Administrador
            Fm_Pass.ShowDialog(Me)
            _Autorizado = Fm_Pass.Pro_Autorizado
            Fm_Pass.Dispose()

            If _Autorizado Then
                Dim dlg As System.Windows.Forms.DialogResult =
                MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar la foto tomada del stock de la bodega?" & vbCrLf &
                          "Nota:El proceso no podrá ser interrumpido y no es posible revertirlo",
                          "Cerrar Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dlg = System.Windows.Forms.DialogResult.Yes Then
                    Consulta_sql = "DELETE ZW_TmpInvFotoInventario WHERE IdInventario = " & _IdInventario
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    MessageBoxEx.Show("Datos eliminados correctamente", "Eliminar foto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Txt_FuncCargo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FuncCargo.ButtonCustomClick

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "", False, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Txt_FuncCargo.Tag = _Row.Item("Codigo")
            Txt_FuncCargo.Text = _Row.Item("Descripcion").ToString.Trim

            If String.IsNullOrWhiteSpace(Txt_NombreInventario.Text) Then
                Txt_NombreInventario.Focus()
            End If

        End If

    End Sub

End Class
