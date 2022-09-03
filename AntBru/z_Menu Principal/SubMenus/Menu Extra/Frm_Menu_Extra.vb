Public Class Frm_Menu_Extra

    Dim _Panel As UserControl

    Enum Enum_Menu
        Compras
        Ventas
        Listas_Precios_Costo
        Parametros
        Inventarios
        Informes
        Programas_Especiales
        Serv_Tecnico
        Tesoreria
    End Enum

    Public Sub New(ByVal Menu As Enum_Menu)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Select Case Menu
            Case Enum_Menu.Compras
                _Panel = New Modulo_Compras(Me)
                CType(_Panel, Modulo_Compras).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Compras).BtnSalir.Visible = False

            Case Enum_Menu.Ventas
                _Panel = New Modulo_Ventas(Me)
                CType(_Panel, Modulo_Ventas).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Ventas).BtnSalir.Visible = False

            Case Enum_Menu.Listas_Precios_Costo
                _Panel = New Modulo_Lista_Precios_Costos(Me)
                CType(_Panel, Modulo_Lista_Precios_Costos).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Lista_Precios_Costos).BtnSalir.Visible = False

            Case Enum_Menu.Parametros
                _Panel = New Modulo_Parametros(Me)
                CType(_Panel, Modulo_Parametros).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Parametros).BtnSalir.Visible = False

            Case Enum_Menu.Inventarios
                _Panel = New Sistema_Inventarios(Me)
                CType(_Panel, Sistema_Inventarios).Pro_Menu_Extra = True
                CType(_Panel, Sistema_Inventarios).BtnSalir.Visible = False

            Case Enum_Menu.Informes
                _Panel = New Modulo_Informes(Me)
                CType(_Panel, Modulo_Informes).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Informes).BtnSalir.Visible = False

            Case Enum_Menu.Programas_Especiales
                _Panel = New Modulo_Programas_Especiales(Me)
                CType(_Panel, Modulo_Programas_Especiales).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Programas_Especiales).BtnSalir.Visible = False

            Case Enum_Menu.Serv_Tecnico
                _Panel = New Modulo_Servicio_Tecnico(Me)
                CType(_Panel, Modulo_Servicio_Tecnico).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Servicio_Tecnico).BtnSalir.Visible = False

            Case Enum_Menu.Tesoreria
                _Panel = New Modulo_Tesoreria(Me)
                CType(_Panel, Modulo_Tesoreria).Pro_Menu_Extra = True
                CType(_Panel, Modulo_Tesoreria).BtnSalir.Visible = False

        End Select

    End Sub

    Private Sub Frm_Menu_Extra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Frm_Menu.Btn_Mnu_Permisos_Remotos.Enabled = True

        Frm_Menu.Notify_Menu_BakApp.Visible = True
        Frm_Menu.Notify_Menu_BakApp.ShowBalloonTip(3, "Info. BakApp", _
                                          "Acceso a permisos remotos ahora esta activo en la barra de tareas", _
                                   ToolTipIcon.Info)

    End Sub

    Private Sub Frm_Menu_Extra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Menu.Btn_Mnu_Permisos_Remotos.Enabled = False
        Me.ShowModalPanel(_Panel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub


End Class
