Imports System.Net.Sockets
Imports System.Text

Public Class ChatClient

    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String
    Dim infiniteCounter As Integer

    Private Sub getMessage()
        Try
            For infiniteCounter = 1 To 2
                infiniteCounter = 1
                serverStream = clientSocket.GetStream()
                Dim buffSize As Integer
                Dim inStream(10024) As Byte
                buffSize = clientSocket.ReceiveBufferSize
                serverStream.Read(inStream, 0, buffSize)
                Dim returndata As String = _
                System.Text.Encoding.ASCII.GetString(inStream)
                readData = "" + returndata
                msg()
            Next
        Catch ex As Exception
            readData = "توجد مشكلة في الاتصال بالشات سرفر"
            msg()
        End Try
    End Sub

    Private Sub msg()
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New MethodInvoker(AddressOf msg))
            Else
                TextBox1.Text = TextBox1.Text + Environment.NewLine + " >> " + readData
            End If
        Catch ex As Exception
            cls.MsgCritical("توجد مشكلة في الاتصال بالشات سرفر", "unable to connect to chat server please contact your system admin")
            readData = "توجد مشكلة في الاتصال بالشات سرفر"
            msg()
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            readData = "جاري الاتصال بالشات سرفر"
            msg()
            clientSocket.Connect(TxtIP.TextBox.Text, 8888)
            'Label1.Text = "Client Socket Program - Server Connected ..."
            serverStream = clientSocket.GetStream()

            Dim outStream As Byte() = _
            System.Text.Encoding.ASCII.GetBytes(EmpNameVar + "$")
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()

            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMessage)
            ctThread.Start()
            TxtIP.Enabled = False
            ToolStripButton1.Enabled = False
            ToolStripButton2.Enabled = True
            TextBox2.Enabled = True
            Button1.Enabled = True
        Catch ex As Exception
            readData = "توجد مشكلة في الاتصال بالشات سرفر"
            msg()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim outStream As Byte() = _
            System.Text.Encoding.ASCII.GetBytes(TextBox2.Text + "$")
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()
            TextBox2.Text = ""
            TextBox2.Focus()
        Catch ex As Exception
            readData = "توجد مشكلة في الاتصال بالشات سرفر"
            msg()
        End Try
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim outStream As Byte() = _
            System.Text.Encoding.ASCII.GetBytes(TextBox2.Text + "$")
                serverStream.Write(outStream, 0, outStream.Length)
                serverStream.Flush()
                TextBox2.Text = ""
                TextBox2.Focus()
            End If
        Catch ex As Exception
            readData = "توجد مشكلة في الاتصال بالشات سرفر"
            msg()
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cls.MsgInfo("تم قطع الاتصال بنجاح", "connection to the chat server has been closed successfully")
        Me.Close()
    End Sub
End Class