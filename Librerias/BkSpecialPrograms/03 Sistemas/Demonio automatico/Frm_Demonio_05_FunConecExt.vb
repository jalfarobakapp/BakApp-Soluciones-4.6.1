Imports DevComponents.DotNetBar
Public Class Frm_Demonio_05_FunConecExt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _NombreEquipo As String
    Dim _Picking As Boolean
    Dim _Funcionario_Autorizado As String
    Dim _Mostrar_Todas_Las_Impresoras_X_Usuario As Boolean

    Public Property Funcionario_Autorizado As String
        Get
            Return _Funcionario_Autorizado
        End Get
        Set(value As String)
            _Funcionario_Autorizado = value
        End Set
    End Property

    Public Property Mostrar_Todas_Las_Impresoras_X_Usuario As Boolean
        Get
            Return _Mostrar_Todas_Las_Impresoras_X_Usuario
        End Get
        Set(value As Boolean)
            _Mostrar_Todas_Las_Impresoras_X_Usuario = value
        End Set
    End Property

    Public Sub New(_NombreEquipo As String, _Picking As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._NombreEquipo = _NombreEquipo
        Me._Picking = _Picking

        _Funcionario_Autorizado = FUNCIONARIO

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Demonio_05_FunConecExt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Servidor de impresiones: " & _NombreEquipo

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen", "Est.", "Estado", 0, _Tipo_Boton.Imagen)
        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub
    Sub Sb_Actualizar_Grilla()

        Dim _Condicion_Tipo = "And Tipo <> 'Picking'"

        If _Picking Then
            _Condicion_Tipo = "And Tipo = 'Picking'"
        End If

        If Mostrar_Todas_Las_Impresoras_X_Usuario Then
            _Condicion_Tipo = String.Empty
        End If

        Consulta_sql = "Declare @NombreEquipo_Imprime as varchar(20)

                        Set @NombreEquipo_Imprime = '" & _NombreEquipo & "'

                        Select @NombreEquipo_Imprime As NombreEquipo, KOFU As Kofu,NOKOFU As Nokofu,Cast(0 As Bit) As Conectado,Cast(0 As int) As Nro_Conec
                        Into #Paso_Diablitos
                        From TABFU

                        Update #Paso_Diablitos Set Conectado = (Select count(*) From " & _Global_BaseBk & "Zw_Usuarios_Impresion Where CodFuncionario = Kofu " & _Condicion_Tipo & "),
						                           Nro_Conec =(Select count(*) From " & _Global_BaseBk & "Zw_Usuarios_Impresion Where CodFuncionario = Kofu And NombreEquipo_Imprime = @NombreEquipo_Imprime " & _Condicion_Tipo & ")	

                        Select * From #Paso_Diablitos
                        --Select * From " & _Global_BaseBk & "Zw_Usuarios_Impresion Where NombreEquipo_Imprime = @NombreEquipo_Imprime

                        Drop Table #Paso_Diablitos"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("BtnImagen").Width = 40
            .Columns("BtnImagen").HeaderText = "Est."
            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Conectado").Width = 40
            '.Columns("Conectado").HeaderText = "Conec."
            '.Columns("Conectado").Visible = True
            '.Columns("Conectado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Kofu").Width = 50
            .Columns("Kofu").HeaderText = "Cod."
            .Columns("Kofu").Visible = True
            .Columns("Kofu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nokofu").Width = 270
            .Columns("Nokofu").HeaderText = "Nombre Funcionario"
            .Columns("Nokofu").Visible = True
            .Columns("Nokofu").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nro_Conec").Width = 50
            .Columns("Nro_Conec").HeaderText = "Nro.C."
            .Columns("Nro_Conec").ToolTipText = "Número de conexiones a este equipo por usuario"
            .Columns("Nro_Conec").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nro_Conec").Visible = True
            .Columns("Nro_Conec").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Row As DataGridViewRow In Grilla.Rows

            Dim _Conectado As Boolean = _Row.Cells("Conectado").Value
            Dim _Imagen As Image

            If _Conectado Then
                _Imagen = Imagenes_16x16.Images.Item("printer-network-green.png")
            Else
                _Imagen = Imagenes_16x16.Images.Item("window-control-minimize.png")
            End If

            _Row.Cells("BtnImagen").Value = _Imagen

        Next

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _CodFuncionario = _Fila.Cells("Kofu").Value
        Dim _Copia_Otros_Usuarios As Boolean

        Dim Fm As New Frm_Imp_Diablito_X_Est(_CodFuncionario, False)
        Fm.Funcionario_Autorizado = Funcionario_Autorizado
        Fm.Editar_Configuraciones = True
        Fm.Cmb_Tido.Enabled = False
        Fm.Txt_SubTido.Enabled = False
        Fm.ShowDialog(Me)
        _Copia_Otros_Usuarios = Fm.Copia_Otros_Usuarios
        Fm.Dispose()

        If _Copia_Otros_Usuarios Then
            Me.Sb_Actualizar_Grilla()
            Return
        End If

        Dim _Condicion_Tipo = "And Tipo <> 'Picking'"

        If _Picking Then
            _Condicion_Tipo = "And Tipo = 'Picking'"
        End If

        If Mostrar_Todas_Las_Impresoras_X_Usuario Then
            _Condicion_Tipo = String.Empty
        End If

        Dim _Conectado As Boolean = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Usuarios_Impresion", "CodFuncionario = '" & _CodFuncionario & "' " & _Condicion_Tipo)
        Dim _Nro_Conec As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Usuarios_Impresion", "CodFuncionario = '" & _CodFuncionario & "' And NombreEquipo_Imprime = '" & _NombreEquipo & "' " & _Condicion_Tipo)
        Dim _Imagen As Image

        If _Conectado Then
            _Imagen = Imagenes_16x16.Images.Item("printer-network-green.png")
        Else
            _Imagen = Imagenes_16x16.Images.Item("window-control-minimize.png")
        End If

        _Fila.Cells("BtnImagen").Value = _Imagen
        _Fila.Cells("Nro_Conec").Value = _Nro_Conec

    End Sub

    Private Sub Grilla_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grilla.CellFormatting

        Dim _Columname As String = Grilla.Columns(e.ColumnIndex).Name

        If _Columname.Contains("Nro_Conec") Then

            Dim _Valor = e.Value

            If _Valor > 0 Then
                'e.CellStyle.ForeColor = Verde
                'e.CellStyle.Font = New Font(Grilla.Font.Name, Grilla.Font.Size, FontStyle.Bold)
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    e.CellStyle.ForeColor = Color.FromArgb(60, 60, 60)
                Else
                    e.CellStyle.ForeColor = Color.LightGray
                End If
            End If

        End If

    End Sub
End Class
