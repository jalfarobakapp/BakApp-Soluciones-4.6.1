Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Empresas_conectadas

    Dim DatosConex As New ConexionBK
    Public NombreConexionActiva As String
    Dim Directorio As String = Application.StartupPath & "\Data\"

    Dim _Cambio_De_Base As Boolean

    Public _Crear_Conexion As Boolean

    Dim Rut, Razon, Ncorto As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub Empresas_conectadas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'If _Crear_Conexion Then
        '    Btn_conectar.Visible = False
        'Else
        '    Btn_Crear_Coneccion.Visible = False
        'End If

        DatosConex.ReadXml(Directorio & "Conexiones.xml")
        Sb_Actualizar_Grilla()
        Grilla.Focus()
        Grilla.MultiSelect = False

        If Global_Thema = Enum_Themas.Oscuro Or Global_Thema = Enum_Themas.Oscuro_Ligth Then
            Btn_conectar.ForeColor = Color.White
            Btn_Crear_Coneccion.ForeColor = Color.White
            Btn_Cancelar.ForeColor = Color.White
            Btn_Eliminar_Empresa.ForeColor = Color.White
        End If

    End Sub

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm, Cambio_de_base As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 30, New Font("Tahoma", 10), Color.AliceBlue, ScrollBars.Vertical, False, True, False)
        _Cambio_De_Base = Cambio_de_base

    End Sub

    Sub Sb_Actualizar_Grilla()

        'DatosConex.WriteXml(AppPath() & "\Data\filename.xml") 'Documento_vta
        Dim _Tbl = New DataTable
        _Tbl = DatosConex.Tables("CnBakApp")


        With Grilla

            .DataSource = Nothing
            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Rut").Width = 100
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Visible = True

            .Columns("NombreConexion").Width = 230
            .Columns("NombreConexion").HeaderText = "Nombre de conexión"
            .Columns("NombreConexion").Visible = True

            .Columns("BaseDeDatos").Width = 160
            .Columns("BaseDeDatos").HeaderText = "Base de Datos"
            .Columns("BaseDeDatos").Visible = True

        End With

        Sb_Marcar_Grilla()

    End Sub

    Sub Sb_Marcar_Grilla()
        With Grilla
            Dim Contador As Integer
            For Each row As DataGridViewRow In .Rows
                If .Rows(Contador).Cells("TipoConexion").Value <> "SqlServer" Then
                    .Rows(Contador).Visible = False
                End If
                Contador += 1
            Next
        End With
    End Sub
    Sub Sb_Seleccionar_Empresa()

        Try

            Grilla.Enabled = False

            RutEmpresaActiva = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Rut").Value
            NombreConexionActiva = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreConexion").Value)

            Dim _Tbl = New DataTable
            _Tbl = DatosConex.Tables("CnBakApp")

            For Each _Fila As DataRow In _Tbl.Rows
                Dim _NombreConexion = Trim(_Fila.Item("NombreConexion"))
                If _NombreConexion = NombreConexionActiva Then
                    _Fila.Item("Conectado") = True
                Else
                    _Fila.Item("Conectado") = False
                End If
            Next

            DatosConex.WriteXml(Directorio & "Conexiones.xml")

            Dim Rt = Split(RutEmpresaActiva, "-")
            Razon = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Razon").Value
            Ncorto = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NombreCorto").Value

            Dim info As New TaskDialogInfo("Conectar con base de datos",
                                            eTaskDialogIcon.ShieldOk,
                                            Ncorto,
                                            "la conexión con la base de datos resulto exitosa." & vbCrLf & vbCrLf &
                                            "Rut: " & FormatNumber(Rt(0), 0) & "-" & Rt(1) & vbCrLf &
                                            "Empresa: " & Razon,
                                             eTaskDialogButton.Ok _
                                             , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)

            Dim result As eTaskDialogResult = TaskDialog.Show(info)

            Cadena_ConexionSQL_Server = Fx_CadenaConexionSQL(NombreConexionActiva, DatosConex)

            If Fx_Conectar_Empresa(Frm_Menu, True) Then

                Dim _Row_Estacion = Fx_Row_Sesion_Star(Frm_Menu)

                If Not IsNothing(_Row_Estacion) Then

                    Dim _TipoEstacion As String = Trim(_Row_Estacion.Item("TipoEstacion"))

                    If Fx_Buscar_Actualizacion(Frm_Menu) Then
                        Sb_Cerrar_Sistema(False)
                    End If

                    Select Case _TipoEstacion
                        Case "Cd"
                            Sb_CashDro(Frm_Menu)
                            Sb_Cerrar_Sistema(False)
                            End
                        Case "Dfa"
                            Sb_Produccion_Mesones_DFA()
                            End
                        Case "OT1"
                            Sb_IngresoGRIProduccion()
                            End
                        Case Else
                            Dim NewPanel As Login = Nothing
                            NewPanel = New Login(Frm_Menu)
                            NewPanel._Inicio_Sesion = True
                            Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
                            Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)
                    End Select

                Else
                    End
                End If
            Else
                End
            End If

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub
    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        If Not _Crear_Conexion Then
            Sb_Seleccionar_Empresa()
        End If
    End Sub
    Private Sub Btn_Crear_Empresa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Crear_Coneccion.Click

        Dim NewPanel As Crear_Conexion = Nothing
        NewPanel = New Crear_Conexion(Frm_Menu)
        NewPanel.DsConexion = DatosConex
        Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

        Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)

    End Sub
    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        If _Crear_Conexion Then
            Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)
        Else
            If _Cambio_De_Base Then
                Frm_Menu.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)

                Dim NewPanel As Menu = Nothing
                NewPanel = New Menu(Frm_Menu, False)
                Frm_Menu.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

            Else
                End
            End If
        End If
    End Sub
    Private Sub Btn_Eliminar_Empresa_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Eliminar_Empresa.Click
        If CBool(Grilla.SelectedRows.Count) Then
            If MessageBoxEx.Show(Frm_Menu, "¿Esta seguro de eliminar esta conexión?", "Eliminar conexión",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Else
                MessageBoxEx.Show(Frm_Menu, "No hay ninguna empresa seleccionada", "Conectar empresa",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub
    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then

            SendKeys.Send("{LEFT}")
            e.Handled = True
            If Not _Crear_Conexion Then
                Sb_Seleccionar_Empresa()
            End If

        End If
    End Sub
    Private Sub Btn_conectar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_conectar.Click
        If CBool(Grilla.SelectedRows.Count) Then
            Sb_Seleccionar_Empresa()
        Else
            MessageBoxEx.Show(Frm_Menu, "No hay ninguna empresa seleccionada", "Conectar empresa",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    Private Sub Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEnter
        TxtRazon.Text = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Razon").Value
    End Sub
End Class
