Public Class FrmCountSubscription
    Dim rpt As New RptCountSubscriptions
    Dim d1, d2 As Date
    Dim tbl1 As New GeneralDataSet.Subscriptions_CategoriesDataTable
    Dim tbl2 As New GeneralDataSet.Subscriptions_DetailsDataTable

    Private Sub FrmCountSubscription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from dbo.Subscriptions_Categories", tbl1)
        cls.RefreshData("select * from dbo.Subscriptions", tbl2)
        categoryid.DataSource = tbl1
        categoryid.DisplayMember = "category_Name"
        categoryid.ValueMember = "category_ID"

        SubID.DataSource = tbl2
        SubID.DisplayMember = "Subscription_Name"
        SubID.ValueMember = "Subscription_ID"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = CDate(fromdate.Text)
        d2 = CDate(todate.Text)
        MyDs.Tables("Report_count_subscriptions").Rows.Clear()
        If Radall.Checked = True Then
            cmd.CommandText = "Select * from Report_count_subscriptions where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        ElseIf radSub.Checked = True Then
            If SubID.Text = "" Then
                MsgBox("من فضلك اختر اسم الاشتراك")
                Exit Sub
            Else
                cmd.CommandText = "Select * from Report_count_subscriptions where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id =" & SubID.SelectedValue
            End If
        Else
            If categoryid.Text = "" Then
                MsgBox("من فضلك اختر نوع الاشتراك")
                Exit Sub
            Else
                cmd.CommandText = "Select * from Report_count_subscriptions where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and category_id =" & categoryid.SelectedValue
            End If
        End If
        da.Fill(MyDs.Tables("Report_count_subscriptions"))
        rpt.SetDataSource(MyDs.Tables("Report_count_subscriptions"))
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

    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radall.CheckedChanged
        If Radall.Checked = True Then
            SubID.Enabled = False
            categoryid.Enabled = False
        End If
    End Sub

    Private Sub radSub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSub.CheckedChanged
        If radSub.Checked = True Then
            SubID.Enabled = True
            categoryid.Enabled = False
        End If
    End Sub

    Private Sub RadCat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCat.CheckedChanged
        If RadCat.Checked = True Then
            SubID.Enabled = False
            categoryid.Enabled = True
        End If
    End Sub
End Class