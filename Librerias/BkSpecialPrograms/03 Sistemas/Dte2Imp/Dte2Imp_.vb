Imports DevComponents.DotNetBar
Imports PdfSharp
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.Layout

Imports System.IO

Public Class Dte2Imp_
    Public FmPrincipal As DevComponents.DotNetBar.Metro.MetroAppForm
    Dim _Nombre_Archivo_XML

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalir.Click
        FmPrincipal.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnBuscarProducto_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscarProducto.Click

        Dim oFD As New OpenFileDialog

        With oFD
            '.Filter = "Ficheros XML |Todos (*.XML)|*.xml"
            '.Filter = "Ficheros DBF (Productos_Aju.xls)|Productos_Aju.xls|Productos_Aju.xlsx"
            .FileName = ""

            If .ShowDialog = DialogResult.OK Then
                _Nombre_Archivo_XML = .SafeFileName
                TxtNombreArchivo.Text = .FileName
            Else
                TxtNombreArchivo.Text = String.Empty
            End If
        End With

    End Sub

    Private Sub BtnImportar_Click(sender As System.Object, e As System.EventArgs) Handles BtnImportar.Click

        Dim _Archivo As String = TxtNombreArchivo.Text

        Dim Extencion As String = LCase(Replace(System.IO.Path.GetExtension(_Archivo), ".", ""))

        If Extencion = "xml" Then

            Dim _Validacion As String

            If String.IsNullOrEmpty(_Validacion) Then

                Dim Ds_Xml As New DataSet
                Ds_Xml.ReadXml(_Archivo)

                If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF") Then
                    System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF")
                End If

                Dim _File As String = AppPath() & "\Data\" & RutEmpresa & "\DTE2PDF\" & _Nombre_Archivo_XML & ".pdf"

                If Not El_Archivo_Esta_Abierto(_File) Then

                    MessageBoxEx.Show("Documento seleccionado correctamente",
                                      "Documento DTE.xml",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim Cl_Dte2XmlIPDF As New Cl_Dte2XmlPDF
                    Cl_Dte2XmlIPDF.Sb_Crear_PDF2XML(FmPrincipal, Ds_Xml, _Nombre_Archivo_XML, "Uso Interno", ChkMarcaAgua.Checked, True) ' (Me, Ds_Xml, _Nombre_Archivo_XML, "Uso Interno", ChkMarcaAgua.Checked)
                    'Generar(Ds_Xml, _Nombre_Archivo_XML, "Uso Interno", False, ChkMarcaAgua.Checked)

                Else

                    MessageBoxEx.Show("El Archivo se encuentra abierto", "DTE2PDF", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            Else

                MessageBoxEx.Show(Me, _Validacion, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Else

            MessageBoxEx.Show("Documento invalido" & vbCrLf &
                              "No tiene extención XML", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Function Fx_New_Validar_DTE(_Archivo_Xml As String) As String


        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(_Archivo_Xml)

            ' Cree el name space manager del documento
            Dim ns As New XmlNamespaceManager(m_xmld.NameTable)
            ns.AddNamespace("sii", m_xmld.DocumentElement.NamespaceURI)


            'ns.AddNamespace("xmlns", m_xmld.DocumentElement.NamespaceURI)

            ' ns.AddNamespace("xmlns", "http://www.sii.cl/SiiDte")
            'ns.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            'ns.AddNamespace("schemaLocation", "http://www.sii.cl/SiiDte EnvioDTE_v10.xsd")


            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("sii:EnvioDTE/sii:SetDTE/sii:DTE", ns)
            ' m_nodelist = m_xmld.SelectNodes("sii:EnvioDTE/sii:SetDTE", ns)
            Dim xDTEs As XmlNodeList = m_xmld.GetElementsByTagName("DTE", m_xmld.DocumentElement.NamespaceURI)

            'Dim XmlRut = m_xmld.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RUTEmisor", ns).InnerText
            Dim _Id = 1
            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist 'm_nodelist

                Dim _Dte = m_node.InnerXml
                'Obtenemos el atributo del codigo
                Dim mCodigo = m_node.Attributes.GetNamedItem("DTE").Value

                Dim XmlRut = m_xmld.SelectSingleNode("sii:DTE[" & _Id &
                                                     "]/sii:Documento/sii:Encabezado/sii:Emisor/sii:RUTEmisor", ns).InnerText
                'Obtenemos el Elemento nombre
                Dim mNombre = m_node.ChildNodes.Item(0).InnerText

                'Obtenemos el Elemento apellido
                Dim mApellido = m_node.ChildNodes.Item(1).InnerText

                'Escribimos el resultado en la consola, 
                'pero tambien podriamos utilizarlos en
                'donde deseemos
                Console.Write("Codigo usuario: " & mCodigo _
                  & " Nombre: " & mNombre _
                  & " Apellido: " & mApellido)
                Console.Write(vbCrLf)

            Next

            Return ""

        Catch ex As Exception
            'Error trapping
            Return ex.Message
        End Try

    End Function


End Class
