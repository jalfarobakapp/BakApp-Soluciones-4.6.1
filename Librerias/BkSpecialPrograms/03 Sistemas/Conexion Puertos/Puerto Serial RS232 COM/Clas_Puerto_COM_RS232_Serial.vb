Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms


Public Class Clas_Puerto_COM_RS232_Serial

    Public Enum TransmissionType
        Text
        Hex
    End Enum

    Public Enum MessageType
        Incoming
        Outgoing
        Normal
        Warning
        [Error]
    End Enum

    'Variables de propiedad
    Private _baudRate As String = String.Empty
    Private _parity As String = String.Empty
    Private _stopBits As String = String.Empty
    Private _dataBits As String = String.Empty
    Private _portName As String = String.Empty
    Private _transType As TransmissionType
    Private _displayWindow As RichTextBox
    Private _msg As String
    Private _type As MessageType

    'Variables globales del administrador
    Private MessageColor As Color() = {Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red}
    Private comPort As New SerialPort()
    Private write As Boolean = True
    
    Public Property StopBits() As String
        Get
            Return _stopBits
        End Get
        Set(ByVal value As String)
            _stopBits = value
        End Set
    End Property

    Public Property DataBits() As String
        Get
            Return _dataBits
        End Get
        Set(ByVal value As String)
            _dataBits = value
        End Set
    End Property

    Public Property PortName() As String
        Get
            Return _portName
        End Get
        Set(ByVal value As String)
            _portName = value
        End Set
    End Property

    Public Property CurrentTransmissionType() As TransmissionType
        Get
            Return _transType
        End Get
        Set(ByVal value As TransmissionType)
            _transType = value
        End Set
    End Property

    Public Property DisplayWindow() As RichTextBox
        Get
            Return _displayWindow
        End Get
        Set(ByVal value As RichTextBox)
            _displayWindow = value
        End Set
    End Property

    Public Property Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property

    Public Property Type() As MessageType
        Get
            Return _type
        End Get
        Set(ByVal value As MessageType)
            _type = value
        End Set
    End Property



    Public Property BaudRate() As String
        Get
            Return _baudRate
        End Get
        Set(ByVal value As String)
            _baudRate = value
        End Set
    End Property

    Public Property Parity() As String
        Get
            Return _parity
        End Get
        Set(ByVal value As String)
            _parity = value
        End Set
    End Property

#Region "Manager Constructors"
    '' <summary>
    '' Constructor to set the properties of our Manager Class
    '' </summary>
    '' <param name="baud">Desired BaudRate</param>
    '' <param name="par">Desired Parity</param>
    '' <param name="sBits">Desired StopBits</param>
    '' <param name="dBits">Desired DataBits</param>
    '' <param name="name">Desired PortName</param>
    Public Sub New(ByVal baud As String, _
                   ByVal par As String, _
                   ByVal sBits As String, _
                   ByVal dBits As String, _
                   ByVal name As String, _
                   ByVal rtb As RichTextBox)
        _baudRate = baud
        _parity = par
        _stopBits = sBits
        _dataBits = dBits
        _portName = name
        _displayWindow = rtb
        'now add an event handler
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub

    '' <summary>
    '' Comstructor to set the properties of our
    '' serial port communicator to nothing
    '' </summary>
    Public Sub New()
        _baudRate = String.Empty
        _parity = String.Empty
        _stopBits = String.Empty
        _dataBits = String.Empty
        _portName = "COM1"
        _displayWindow = Nothing
        'add event handler
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub
#End Region

#Region "WriteData"

    Public Sub WriteData(ByVal msg As String)
        Select Case CurrentTransmissionType
            Case TransmissionType.Text
                'first make sure the port is open
                'if its not open then open it
                If Not (comPort.IsOpen = True) Then
                    comPort.Open()
                End If
                'send the message to the port
                comPort.Write(msg)
                'display the message
                _type = MessageType.Outgoing
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(_type, _msg)
                Exit Select
            Case TransmissionType.Hex
                Try
                    'convert the message to byte array
                    Dim newMsg As Byte() = HexToByte(msg)
                    'Determine if we are goint
                    'to write the byte data to the screen
                    If Not write Then
                        DisplayData(_type, _msg)
                        Exit Sub
                    End If
                    'send the message to the port
                    comPort.Write(newMsg, 0, newMsg.Length)
                    'convert back to hex and display
                    _type = MessageType.Outgoing
                    _msg = ByteToHex(newMsg) + "" + Environment.NewLine + ""
                    DisplayData(_type, _msg)
                Catch ex As FormatException
                    'display error message
                    _type = MessageType.Error
                    _msg = ex.Message + "" + Environment.NewLine + ""
                    DisplayData(_type, _msg)
                Finally
                    _displayWindow.SelectAll()
                End Try
                Exit Select
            Case Else
                'first make sure the port is open
                'if its not open then open it
                If Not (comPort.IsOpen = True) Then
                    comPort.Open()
                End If
                'send the message to the port
                comPort.Write(msg)
                'display the message
                _type = MessageType.Outgoing
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(MessageType.Outgoing, msg + "" + Environment.NewLine + "")
                Exit Select
        End Select
    End Sub
#End Region

#Region "HexToByte"

    Private Function HexToByte(ByVal msg As String) As Byte()
        'Here we added an extra check to ensure the data
        'was the proper length for converting to byte
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
            'Message wasnt the proper length
            'So we set the display message
            _msg = "Invalid format"
            _type = MessageType.Error
            ' DisplayData(_Type, _msg)
            'Set our boolean value to false
            write = False
            Return Nothing
        End If
    End Function
#End Region

#Region "ByteToHex"

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

    Private Sub DisplayData(ByVal type As MessageType, ByVal msg As String)
        _displayWindow.Invoke(New EventHandler(AddressOf DoDisplay))
    End Sub
#End Region

#Region "DoDisplay"
    Private Sub DoDisplay(ByVal sender As Object, ByVal e As EventArgs)
        _displayWindow.SelectedText = String.Empty
        _displayWindow.SelectionFont = New Font(_displayWindow.SelectionFont, FontStyle.Bold)
        _displayWindow.SelectionColor = MessageColor(CType(_type, Integer))
        _displayWindow.AppendText(_msg)
        _displayWindow.ScrollToCaret()
    End Sub
#End Region

#Region "OpenPort"
    Public Function OpenPort() As Boolean
        Try
            'first check if the port is already open
            'if its open then close it
            If comPort.IsOpen = True Then
                comPort.Close()
            End If

            'set the properties of our SerialPort Object
            comPort.BaudRate = Integer.Parse(_baudRate)
            'BaudRate
            comPort.DataBits = Integer.Parse(_dataBits)
            'DataBits
            comPort.StopBits = DirectCast([Enum].Parse(GetType(StopBits), _stopBits), StopBits)
            'StopBits
            comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
            'Parity
            comPort.PortName = _portName
            'PortName
            'now open the port
            comPort.Open()
            'display message
            _type = MessageType.Normal
            _msg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""
            DisplayData(_type, _msg)
            'return true
            Return True
        Catch ex As Exception
            DisplayData(MessageType.[Error], ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region " ClosePort "
    Public Sub ClosePort()
        If comPort.IsOpen Then
            _msg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
            _type = MessageType.Normal
            DisplayData(_type, _msg)
            comPort.Close()
        End If
    End Sub
#End Region

#Region "comPort_DataReceived"

    ''' method that will be called when theres data waiting in the buffer

    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        'determine the mode the user selected (binary/string)
        Select Case CurrentTransmissionType
            Case TransmissionType.Text
                'user chose string
                'read data waiting in the buffer
                Dim msg As String = comPort.ReadExisting()
                'display the data to the user
                _type = MessageType.Incoming
                _msg = msg
                DisplayData(MessageType.Incoming, msg + "" + Environment.NewLine + "")
                Exit Select
            Case TransmissionType.Hex
                'user chose binary
                'retrieve number of bytes in the buffer
                Dim bytes As Integer = comPort.BytesToRead
                'create a byte array to hold the awaiting data
                Dim comBuffer As Byte() = New Byte(bytes - 1) {}
                'read the data and store it
                comPort.Read(comBuffer, 0, bytes)
                'display the data to the user
                _type = MessageType.Incoming
                _msg = ByteToHex(comBuffer) + "" + Environment.NewLine + ""
                DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "" + Environment.NewLine + "")
                Exit Select
            Case Else
                'read data waiting in the buffer
                Dim str As String = comPort.ReadExisting()
                'display the data to the user
                _type = MessageType.Incoming
                _msg = str + "" + Environment.NewLine + ""
                DisplayData(MessageType.Incoming, str + "" + Environment.NewLine + "")
                Exit Select
        End Select
    End Sub
#End Region


End Class
