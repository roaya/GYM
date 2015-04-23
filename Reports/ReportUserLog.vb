Public Class ReportUserLog

    Dim Rpt As New Report_User_Log
    Dim date1, date2 As Date
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MyDs.Tables("Report_User_Log").Rows.Clear()
            date1 = CDate(DateTimePicker1.Text)
            date2 = CDate(DateTimePicker2.Text)
            If RadioAllUsers.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_User_Log where action_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' order by Action_Date"
            ElseIf RadioUser.Checked = True Then
                If UserID.Text = "" Then
                    cls.MsgExclamation("اختر اسم المستخدم", "please enter user name")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_User_Log where action_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and user_id = " & UserID.SelectedValue & " order by Action_Date"
                End If
            End If

                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_User_Log"))


            Rpt.SetDataSource(MyDs.Tables("Report_User_Log"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = Rpt
                TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report_User_Log")
        End Try
    End Sub

    Private Sub ReportUserLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("App_Users")
        UserID.DataSource = MyDs
        UserID.ValueMember = "App_Users.User_ID"
        UserID.DisplayMember = "App_Users.User_Name"

    End Sub

    Private Sub RadioUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioUser.CheckedChanged
        If RadioUser.Checked = True Then
            UserID.Enabled = True
        End If
    End Sub

    Private Sub RadioAllUsers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllUsers.CheckedChanged
        If RadioAllUsers.Checked = True Then
            UserID.Enabled = False
        End If
    End Sub
End Class