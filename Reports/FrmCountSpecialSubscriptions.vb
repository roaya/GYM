Public Class FrmCountSpecialSubscriptions
    Dim rpt As New RptCountSpecialSubscritions
    Dim d1, d2 As Date
    Dim tbl1 As New GeneralDataSet.SubscriptionsDataTable

    Private Sub FrmCountSpecialSubscriptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from subscriptions", tbl1)
        SubID.DataSource = tbl1
        SubID.DisplayMember = "subscription_name"
        SubID.ValueMember = "subscription_id"
    End Sub

    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radall.CheckedChanged
        If Radall.Checked = True Then
            SubID.Enabled = False
        End If
    End Sub

    Private Sub Radsub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radsub.CheckedChanged
        If Radsub.Checked = True Then
            SubID.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = CDate(fromdate.Text)
        d2 = CDate(todate.Text)
        MyDs.Tables("report_count_special_subscriptions").Rows.Clear()
        If Radall.Checked = True Then
            cmd.CommandText = "Select * from report_count_special_subscriptions where Special_Subscription_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        Else
            If SubID.Text = "" Then
                MsgBox("من فضلك اختر اسم الجلسه")
                Exit Sub
            Else
                cmd.CommandText = "Select * from report_count_special_subscriptions where Special_Subscription_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id =" & SubID.SelectedValue
            End If
        End If
        da.Fill(MyDs.Tables("report_count_special_subscriptions"))
        rpt.SetDataSource(MyDs.Tables("report_count_special_subscriptions"))
        CrystalReportViewer2.ReportSource = rpt
        TabControl1.SelectTab(1)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub


End Class