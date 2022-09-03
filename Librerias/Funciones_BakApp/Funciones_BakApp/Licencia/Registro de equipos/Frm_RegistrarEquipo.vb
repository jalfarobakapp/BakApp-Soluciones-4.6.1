Imports DevComponents.DotNetBar

Public Class Frm_RegistrarEquipo


    Public Registrado As Boolean
    Public Accion
    Public KeyReg_Editar As String

    Public _RutEmpresa, _NombreEmpresa As String

    Public Enum ListaAccion
        Guardar
        Editar
    End Enum

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        LlenaComboTipoEstacion()

        Dim MiIp = getIp()

        Dim _Ds As New DatosBakApp
        'im NombreEquipo = UCase(System.Net.Dns.GetHostName)

        'LblNombreEquipo.Text = NombreEquipo


    End Sub

    Public Property Pro_Nombre_Equipo()
        Get
            Return LblNombreEquipo.Text
        End Get
        Set(ByVal value)
            LblNombreEquipo.Text = value
        End Set
    End Property


    Sub LlenaComboTipoEstacion()

        caract_combo(CmbTipoEstacion)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "N" : dr("Hijo") = "Normal" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "P" : dr("Hijo") = "Post-Venta" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "C" : dr("Hijo") = "Consultor Precios" : dt.Rows.Add(dr)
        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With CmbTipoEstacion
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        'Dim _Registro As New Frm_Licencia_Empresa
        'Dim _Licencia As String = _RutEmpresa & "@" & LblNombreEquipo.Text
        'Dim _Key As String = UCase(_Registro.Fx_Encriptar(_Licencia, "ARDILLA."))

        Dim _Cadena As String = UCase(Trim(_RutEmpresa) & "@" & LblNombreEquipo.Text)
        Dim _Key = Encripta_md5(_Cadena)

        '249360d48e636367b865e0bc8619065d



        If Txt1.Text <> _Key Then
            MessageBoxEx.Show(Me, "Llave de acceso no valida", "Key reg.", _
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Return
        End If

        If Accion = ListaAccion.Guardar Then

            Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_EstacionesBkp (NombreEquipo,TipoEstacion,KeyReg) VALUES" & vbCrLf & _
                           "('" & LblNombreEquipo.Text & "','" & CmbTipoEstacion.SelectedValue & _
                           "','" & _Key & "')"
            Ej_consulta_IDU(Consulta_sql, cn1)

            MessageBoxEx.Show(Me, "Equipo registrado correctamente" & vbCrLf & _
                   "Como estación de trabajo tipo: " & CmbTipoEstacion.Text, "Registrar estación", _
                   Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk)
            Registrado = True
            Me.Close()

        ElseIf Accion = ListaAccion.Editar Then

            Dim Identificacion = Encripta_md5(Trim(LblNombreEquipo.Text))

            Consulta_sql = "UPDATE BakApp.dbo.Zw_EstacionesBkp Set TipoEstacion = '" & CmbTipoEstacion.SelectedValue & "'" & vbCrLf & _
                           ",KeyReg = '" & Txt1.Text & "'" & vbCrLf & _
                           "WHERE KeyReg = '" & Identificacion & "'"

            Ej_consulta_IDU(Consulta_sql, cn1)

            MsgBox("Actualización de estación guardada correctamente", MsgBoxStyle.Information, "Actualizar tipo de estación")


        End If


    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Registrado = False
        Me.Close()
    End Sub

    Private Sub Frm_RegistrarEquipo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TextBoxX1.Text = _RutEmpresa
        TextBoxX2.Text = _NombreEmpresa

        If Accion = ListaAccion.Editar Then
            BtnAceptar.Text = "Guardar cambios"
        ElseIf Accion = ListaAccion.Guardar Then
            BtnAceptar.Text = "Guardar"
        End If

    End Sub

End Class