Public Class frmreportallspecialsubscriptions
    Dim rpt As New RptAllSpecial
    Dim d1, d2 As Date
    Dim tbl1 As New GeneralDataSet.Special_CategoriesDataTable


    Private Sub FrmMostCountHalls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from special_categories", tbl1)

        cat.DataSource = tbl1
        cat.DisplayMember = "category_name"
        cat.ValueMember = "special_categories_id"



    End Sub

    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall.CheckedChanged
        If byall.Checked = True Then
            cat.Enabled = False
        End If
    End Sub

    Private Sub RadHall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycat.CheckedChanged
        If bycat.Checked = True Then
            cat.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = CDate(fromdate.Text)
        d2 = CDate(todate.Text)
        MyDs.Tables("report_all_special_Subscriptions").Rows.Clear()
        If byall.Checked = True Then
            cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_special_Subscriptions where Special_Subscription_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        Else : bycat.Checked = True

            If cat.SelectedValue = Nothing Then
                MsgBox("من فضلك اختر اسم البند")
                Exit Sub
            Else
                cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_special_Subscriptions where special_Categories_id=" & cat.SelectedValue & " and  Special_Subscription_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            End If


        End If
        da.Fill(MyDs.Tables("report_all_special_Subscriptions"))
        rpt.SetDataSource(MyDs.Tables("report_all_special_Subscriptions"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
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