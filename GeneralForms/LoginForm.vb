Imports System.IO
Imports System.Security.Cryptography
Imports System.Net.Mail

Public Class LoginForm

    Dim b As Boolean = False

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Login()
   

    End Sub

    Sub Login()

        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Or ServerNameTextBox.Text = "" Then
            MsgBox("√œŒ· »Ì«‰«  «· ”ÃÌ·", MsgBoxStyle.Exclamation, ProjectTitle)
        Else

            Try
                If cn.State = ConnectionState.Closed Then
                    cls.OpenConn("GYM", ServerNameTextBox.Text, "sa", "pass@word1", False)
                End If
            Catch ex As Exception
                'cls.MsgCritical("Â‰«ﬂ Œÿ√ ›Ì «·« ’«· »«·”—›— »—Ã«¡ «· √ﬂœ „‰ „⁄·Ê„«  «·« ’«·", "system cannot connect to the specified server please contact system admin")
                MsgBox("Â‰«ﬂ Œÿ√ ›Ì «·« ’«· »«·”—›— »—Ã«¡ «· √ﬂœ „‰ „⁄·Ê„«  «·« ’«·", MsgBoxStyle.Exclamation, ProjectTitle)

                cls.WriteError(ex.Message, "Main")
                Exit Sub
            End Try



            cmd.CommandText = "select count(*) from app_users where user_name ='" & UsernameTextBox.Text & "' and user_password ='" & PasswordTextBox.Text & "'"
            If cmd.ExecuteScalar > 0 Then
                cmd.CommandText = "select distinct employee_id , employee_name , Account_Status , User_ID from Emp_Security where user_name ='" & UsernameTextBox.Text & "'"
                dr = cmd.ExecuteReader
                If Not dr.Read = False Then
                    UserIDVar = dr("User_id")
                    EmpIDVar = dr("employee_id")
                    EmpNameVar = dr("employee_name")
                    UserNameVar = UsernameTextBox.Text
                    If dr("Account_Status") = 0 Then
                        cls.MsgCritical("Â–« «·Õ”«» „€·ﬁ »—Ã«¡ «·« ’«· »„œÌ— «·‰Ÿ«„", "This account is closed please contact system admin")
                        End
                    End If
                End If
                If dr.IsClosed = False Then
                    dr.Close()
                End If


                FillDataSet()
                WriteAuth()
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo("  „ «· ”ÃÌ· »‰Ã«Õ „—Õ»« " & EmpNameVar, "Login Succeeded welcome " & EmpNameVar)
                End If

                b = True
                Me.Close()
            Else
                cls.MsgExclamation("Œÿ√ ›Ì «· ”ÃÌ· √⁄œ «· ”ÃÌ· „—… «Œ—Ì", "Invalid Authentication information please verify your data")
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
            End If
        End If

    End Sub

    Public Sub FillDataSet()
        StatusStrip1.Visible = True
        ProgressBar1.Visible = True
        ProgressTxt.Visible = True
        Dim FillTbl() As String = {"Table_Columns"}
        For i As Integer = 0 To FillTbl.Length - 1
            
            cmd.CommandText = "select * from " & FillTbl(i)
            da.Fill(MyDs.Tables(FillTbl(i)))
        Next

        ProgressBar1.Value = ProgressBar1.Value + 10
        ProgressTxt.Text = "%" & ProgressBar1.Value

        '-----------------Email Msg-------------------------------
        Try
            Me.Cursor = Cursors.WaitCursor
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Is_Send") = True Then
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Send_Action") = "»œ¡ «·»—‰«„Ã" Then
                   
                    'cls.SendEmail()

                    ProgressBar1.Value = ProgressBar1.Value + 10
                    ProgressTxt.Text = "%" & ProgressBar1.Value

                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            cls.MsgInfo("·„ Ì „ «—”«· «Ì„Ì·«  «·‰Ÿ«„ »—Ã«¡ «· √ﬂœ „‰ « ’«·ﬂ »«·«‰ —‰  «Ê „—«Ã⁄… «⁄œ«œ«  «·‰Ÿ«„", "System cannot send alerts emails please verify your internet connection")
        End Try
        '---------------------------------------------------------

        cmd.CommandText = "select Privilege_name as '«”„ «·’·«ÕÌ…', Granted as '„ «Õ… / €Ì— „ «Õ…' from Emp_Security where employee_id = " & EmpIDVar
        da.SelectCommand = cmd
        da.Fill(LogTbl)
        If CheckViewRpt.Checked = True Then
            ShowLogReport = True
        End If

        ProgressBar1.Value = ProgressBar1.Value + 10
        ProgressTxt.Text = "%" & ProgressBar1.Value

        cmd.CommandText = "select Stock_name from Stocks where Stock_id = " & ProjectSettings.CurrentStockID
        ProjectSettings.CurrentStockName = cmd.ExecuteScalar

        ProgressBar1.Value = 100
        ProgressTxt.Text = "%100"

    End Sub

   

    Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If b = True Then
            e.Cancel = False
        Else
            End
            e.Cancel = True
        End If

    End Sub


    Private Sub UsernameTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown, PasswordTextBox.KeyDown, ServerNameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub


    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        End
    End Sub


    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReadAuth()
    End Sub

#Region "Auth"

    Structure MyStruct
        Dim RID As Integer
        <VBFixedString(35)> Dim UName As String
        <VBFixedString(35)> Dim UPwd As String
        <VBFixedString(35)> Dim Srvr As String
    End Structure


    Public Sub AddRecord()

        Dim k As New MyStruct
        k.RID = 1
        k.UName = UsernameTextBox.Text
        k.UPwd = PasswordTextBox.Text
        k.Srvr = ServerNameTextBox.Text
        FileOpen(1, My.Application.Info.DirectoryPath & "\LgU.Rye", OpenMode.Random, OpenAccess.Write, OpenShare.Default)

        FilePut(1, k, 1)
        FileClose(1)

    End Sub

    Sub WriteAuth()
        If CheckSaveLogin.Checked = True Then
            Dim fs As New IO.FileStream(My.Application.Info.DirectoryPath & "\LgU.Rye", IO.FileMode.Create)
            fs.Close()
            AddRecord()
        Else
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\LgU.Rye") Then
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\LgU.Rye")
            End If


        End If
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Server.Srvr") Then
            My.Computer.FileSystem.WriteAllText("Server.Srvr", ServerNameTextBox.Text, False)
        End If
    End Sub

    Sub ReadAuth()

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\LgU.Rye") = True Then

            Dim j As New MyStruct
            Dim i As Integer
            FileOpen(1, My.Application.Info.DirectoryPath & "\LgU.Rye", OpenMode.Random, OpenAccess.Read, OpenShare.Default)
            Do While EOF(1) = False
                FileGet(1, j)
                i = j.RID
                UsernameTextBox.Text = Trim(j.UName)
                PasswordTextBox.Text = Trim(j.UPwd)
                ServerNameTextBox.Text = Trim(j.Srvr)
            Loop
            CheckSaveLogin.Checked = True
            FileClose(1)
        End If
    End Sub


#End Region

    Private Sub Button3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.enter
    End Sub

    
    Private Sub Button3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseMove
        Button3.BackgroundImage = My.Resources._end
    End Sub

    Private Sub Button4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Button4.BackgroundImage = My.Resources.enter
    End Sub

    Private Sub Button4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseMove
        Button4.BackgroundImage = My.Resources._end
    End Sub
End Class
