Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.Threading
Imports System.ComponentModel

'*****************************************************************************************
'                           LICENSE INFORMATION
'*****************************************************************************************
'   PCCom.SerialCommunication Version 1.0.0.0
'   Class file for managing serial port communication
'
'   Copyright (C) 2007  
'   Richard L. McCutchen 
'   Email: richard@psychocoder.net
'   Created: 20OCT07
'
'   This program is free software: you can redistribute it and/or modify
'   it under the terms of the GNU General Public License as published by
'   the Free Software Foundation, either version 3 of the License, or
'   (at your option) any later version.
'
'   This program is distributed in the hope that it will be useful,
'   but WITHOUT ANY WARRANTY; without even the implied warranty of
'   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'   GNU General Public License for more details.
'
'   You should have received a copy of the GNU General Public License
'   along with this program.  If not, see <http://www.gnu.org/licenses/>.
'*****************************************************************************************


Public Class Clas_Comm_Manager
#Region "Manager Enums"
    ''' <summary>
    ''' enumeration to hold our transmission types
    ''' </summary>
    Public Enum TransmissionType
        Text
        Hex
    End Enum

    ''' <summary>
    ''' enumeration to hold our message types
    ''' </summary>
    Public Enum MessageType
        Entrante
        Saliente
        Normal
        Advertencia
        [Error]
    End Enum
#End Region

#Region "Manager Variables"
    'property variables
    Private _baudRate As String = String.Empty
    Private _parity As String = String.Empty
    Private _stopBits As String = String.Empty
    Private _dataBits As String = String.Empty
    Private _portName As String = String.Empty
    Private _transType As TransmissionType
    Private _RichTextBox As RichTextBox '_displayWindow As RichTextBox
    Private _msg As String
    Private _type As MessageType
    'global manager variables
    Private MessageColor As Color() = {Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red}
    Private _Puerto_COM As New SerialPort()
    Private write As Boolean = True

    Dim _Respuesta As String

    Public ReadOnly Property Pro_Puerto_Abierto() As Boolean
        Get
            Return _Puerto_COM.IsOpen
        End Get
    End Property

#End Region

    Public Property Pro_Respuesta() As String
        Get
            Return _Respuesta
        End Get
        Set(ByVal value As String)
            _Respuesta = value
        End Set
    End Property

#Region "Manager Properties"

    Public Property Pro_BaudRate() As String
        Get
            Return _baudRate
        End Get
        Set(ByVal value As String)
            _baudRate = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the Parity
    ''' of our manager class
    ''' </summary>
    Public Property Pro_Parity() As String
        Get
            Return _parity
        End Get
        Set(ByVal value As String)
            _parity = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the StopBits
    ''' of our manager class
    ''' </summary>
    Public Property Pro_StopBits() As String
        Get
            Return _stopBits
        End Get
        Set(ByVal value As String)
            _stopBits = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the DataBits
    ''' of our manager class
    ''' </summary>
    Public Property Pro_DataBits() As String
        Get
            Return _dataBits
        End Get
        Set(ByVal value As String)
            _dataBits = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the PortName
    ''' of our manager class
    ''' </summary>
    Public Property Pro_PortName() As String
        Get
            Return _portName
        End Get
        Set(ByVal value As String)
            _portName = value
        End Set
    End Property

    'propiedad para guardar su tipo de transmisión' '' de nuestra clase de administrador
    Public Property Pro_CurrentTransmissionType() As TransmissionType
        Get
            Return _transType
        End Get
        Set(ByVal value As TransmissionType)
            _transType = value
        End Set
    End Property

    'propiedad para mantener nuestra ventana de visualización, valor
    Public Property Pro_RichTextBox() As RichTextBox 'DisplayWindow() As RichTextBox
        Get
            Return _RichTextBox
        End Get
        Set(ByVal value As RichTextBox)
            _RichTextBox = value
        End Set
    End Property

    ''' <summary>
    ''' Property to hold the message being sent
    ''' through the serial port
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Pro_Mensaje() As String 'Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property

    ''' <summary>
    ''' Message to hold the transmission type
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Pro_Type() As MessageType
        Get
            Return _type
        End Get
        Set(ByVal value As MessageType)
            _type = value
        End Set
    End Property
#End Region

#Region "Manager Constructors"
    ''' <summary>
    ''' Constructor to set the properties of our Manager Class
    ''' </summary>
    ''' <param name="baud">Desired BaudRate</param>
    ''' <param name="par">Desired Parity</param>
    ''' <param name="sBits">Desired StopBits</param>
    ''' <param name="dBits">Desired DataBits</param>
    ''' <param name="name">Desired PortName</param>
    Public Sub New(ByVal baud As String, ByVal par As String, ByVal sBits As String, ByVal dBits As String, ByVal name As String, ByVal rtb As RichTextBox)
        _baudRate = baud
        _parity = par
        _stopBits = sBits
        _dataBits = dBits
        _portName = name
        _RichTextBox = rtb
        'now add an event handler
        AddHandler _Puerto_COM.DataReceived, AddressOf Sb_Puerto_COM_Recibe_Datos
    End Sub

    ''' <summary>
    ''' Comstructor to set the properties of our
    ''' serial port communicator to nothing
    ''' </summary>
    Public Sub New()
        _baudRate = String.Empty
        _parity = String.Empty
        _stopBits = String.Empty
        _dataBits = String.Empty
        _portName = "COM1"
        _RichTextBox = Nothing
        'add event handler
        AddHandler _Puerto_COM.DataReceived, AddressOf Sb_Puerto_COM_Recibe_Datos
    End Sub
#End Region

#Region "WriteData"
    Public Sub Sb_Escribir_Datos(ByVal msg As String)
        Select Case Pro_CurrentTransmissionType
            Case TransmissionType.Text
                'first make sure the port is open
                'if its not open then open it
                If Not (_Puerto_COM.IsOpen = True) Then
                    _Puerto_COM.Open()
                End If
                'send the message to the port
                _Puerto_COM.Write(msg)
                'display the message
                _type = MessageType.Saliente ' .Outgoing
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(_type, _msg)
                Exit Select
            Case TransmissionType.Hex
                Try
                    'convert the message to byte array
                    Dim newMsg As Byte() = HexToByte(msg)
                    If Not write Then
                        DisplayData(_type, _msg)
                        Exit Sub
                    End If
                    'send the message to the port
                    If _Puerto_COM.IsOpen Then
                        _Puerto_COM.Write(newMsg, 0, newMsg.Length)
                        'convert back to hex and display
                        _type = MessageType.Saliente ' MessageType.Outgoing
                        _msg = ByteToHex(newMsg) + "" + Environment.NewLine + ""
                        DisplayData(_type, _msg)
                    Else
                        _Respuesta = "Error! El puerto esta cerrado"
                        _type = MessageType.Error
                    End If

                Catch ex As FormatException
                    'display error message
                    _type = MessageType.Error
                    _msg = ex.Message + "" + Environment.NewLine + ""
                    DisplayData(_type, _msg)
                Finally
                    _RichTextBox.SelectAll()
                End Try
                Exit Select
            Case Else
                'first make sure the port is open
                'if its not open then open it
                If Not (_Puerto_COM.IsOpen = True) Then
                    _Puerto_COM.Open()
                End If
                'send the message to the port
                _Puerto_COM.Write(msg)
                'display the message
                _type = MessageType.Saliente
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(MessageType.Saliente, msg + "" + Environment.NewLine + "")
                Exit Select
        End Select
    End Sub
#End Region

#Region "HexToByte"
    ''' <summary>
    ''' method to convert hex string into a byte array
    ''' </summary>
    ''' <param name="msg">string to convert</param>
    ''' <returns>a byte array</returns>
    Private Function HexToByte(ByVal msg As String) As Byte()
        If msg.Length Mod 2 = 0 Then
            'remove any spaces from the string
            _msg = msg
            _msg = msg.Replace(" ", "")
            'create a byte array the length of the
            'divided by 2 (Hex is 2 characters in length)
            Dim comBuffer As Byte() = New Byte(_msg.Length / 2 - 1) {}
            For i As Integer = 0 To _msg.Length - 1 Step 2
                comBuffer(i / 2) = CByte(Convert.ToByte(_msg.Substring(i, 2), 16))
            Next
            write = True
            'loop through the length of the provided string
            'convert each set of 2 characters to a byte
            'and add to the array
            'return the array
            Return comBuffer
        Else
            _msg = "Invalid format"
            _type = MessageType.Error
            DisplayData(_type, _msg)
            write = False
            Return Nothing
        End If
    End Function
#End Region

#Region "ByteToHex"
    ''' <summary>
    ''' method to convert a byte array into a hex string
    ''' </summary>
    ''' <param name="comByte">byte array to convert</param>
    ''' <returns>a hex string</returns>
    Private Function ByteToHex(ByVal comByte As Byte()) As String
        'create a new StringBuilder object
        Dim builder As New StringBuilder(comByte.Length * 3)
        'loop through each byte in the array
        For Each data As Byte In comByte
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
            'convert the byte to a string and add to the stringbuilder
        Next
        'return the converted value
        Return builder.ToString().ToUpper()
    End Function
#End Region

#Region "DisplayData"
    'Método para mostrar los datos y desde el puerto en la pantalla
    <STAThread()>
    Private Sub DisplayData(ByVal type As MessageType, ByVal msg As String)
        Try
            _RichTextBox.Invoke(New EventHandler(AddressOf Sb_DoDisplay))
        Catch ex As Exception
            _Respuesta = "Error! " & ex.Message
        End Try
    End Sub
#End Region

#Region "OpenPort"
    Public Function Fx_Abrir_Puerto() As Boolean
        Try
            'first check if the port is already open
            'if its open then close it
            If _Puerto_COM.IsOpen = True Then
                _Puerto_COM.Close()
            End If

            'set the properties of our SerialPort Object
            _Puerto_COM.BaudRate = Integer.Parse(_baudRate)
            'BaudRate
            _Puerto_COM.DataBits = Integer.Parse(_dataBits)
            'DataBits
            _Puerto_COM.StopBits = DirectCast([Enum].Parse(GetType(StopBits), _stopBits), StopBits)
            'StopBits
            _Puerto_COM.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
            'Parity
            _Puerto_COM.PortName = _portName
            'PortName
            'now open the port
            _Puerto_COM.Open()
            'display message
            _type = MessageType.Normal
            _msg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""
            _RichTextBox.Text = String.Empty
            DisplayData(_type, _msg)
            'return true
            Return True
        Catch ex As Exception
            DisplayData(MessageType.[Error], ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region " Fx_Cerrar_Puerto "
    Public Function Fx_Cerrar_Puerto()
        If _Puerto_COM.IsOpen Then
            _msg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
            _type = MessageType.Normal
            _RichTextBox.Text = String.Empty
            DisplayData(_type, _msg)

            RemoveHandler _Puerto_COM.DataReceived, AddressOf Sb_Puerto_COM_Recibe_Datos
            '3 Segundos de demora
            Thread.Sleep(5000)
            _Puerto_COM.Close()
        End If
    End Function
#End Region


#Region "SetParityValues"
    Public Sub Sb_SetParityValues(ByVal obj As Object)
        For Each str As String In [Enum].GetNames(GetType(Parity))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "SetStopBitValues"
    Public Sub Sb_SetStopBitValues(ByVal obj As Object)
        For Each str As String In [Enum].GetNames(GetType(StopBits))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "SetPortNameValues"
    Public Sub Sb_SetPortNameValues(ByVal obj As Object)
        For Each str As String In SerialPort.GetPortNames()
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "Sb_Puerto_COM_Recibe_Datos"
    ''' <summary>
    ''' method that will be called when theres data waiting in the buffer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Sb_Puerto_COM_Recibe_Datos(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)

        'determine the mode the user selected (binary/string)
        Select Case Pro_CurrentTransmissionType
            Case TransmissionType.Text
                'user chose string
                'read data waiting in the buffer
                Dim msg As String = _Puerto_COM.ReadExisting()
                'display the data to the user
                _type = MessageType.Entrante
                _msg = msg
                DisplayData(MessageType.Entrante, msg + "" + Environment.NewLine + "")
                Exit Select
            Case TransmissionType.Hex
                'user chose binary
                'retrieve number of bytes in the buffer
                Dim bytes As Integer = _Puerto_COM.BytesToRead
                'create a byte array to hold the awaiting data
                Dim comBuffer As Byte() = New Byte(bytes - 1) {}
                'read the data and store it
                _Puerto_COM.Read(comBuffer, 0, bytes)
                'display the data to the user
                _type = MessageType.Entrante
                _msg = ByteToHex(comBuffer) + "" + Environment.NewLine + ""

                DisplayData(MessageType.Entrante, ByteToHex(comBuffer) + "" + Environment.NewLine + "")

                ' _Respuesta = _RichTextBox.Text

                Exit Select
            Case Else
                'read data waiting in the buffer
                Dim str As String = _Puerto_COM.ReadExisting()
                'display the data to the user
                _type = MessageType.Entrante
                _msg = str + "" + Environment.NewLine + ""
                DisplayData(MessageType.Entrante, str + "" + Environment.NewLine + "")
                Exit Select
        End Select
    End Sub
#End Region

#Region "DoDisplay"
    Private Sub Sb_DoDisplay(ByVal sender As Object, ByVal e As EventArgs)
        Try
            _RichTextBox.SelectedText = String.Empty
            _RichTextBox.SelectionFont = New Font(_RichTextBox.SelectionFont, FontStyle.Bold)
            _RichTextBox.SelectionColor = MessageColor(CType(_type, Integer))
            _RichTextBox.AppendText(_msg)
            _RichTextBox.ScrollToCaret()
            _Respuesta = _RichTextBox.Text
        Catch ex As Exception
            _Respuesta = "Error! " & ex.Message
        End Try
    End Sub
#End Region
End Class

