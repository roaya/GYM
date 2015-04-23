Public Class ReportSubscription


    Dim rpt As New RptSubscriptions
    Dim rptsp As New RptSpecialCategories
    Dim bsource As New BindingSource
    Dim tbl As New GeneralDataSet.Subscriptions_CategoriesDataTable
    Private Sub RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from Subscriptions_Categories", tbl)
     
        Type.DataSource = tbl
        Type.DisplayMember = "category_Name"
        Type.ValueMember = "category_id"

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 1
    
        If ByCategory.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_subscriptions where category_id=" & Type.SelectedValue
            da.SelectCommand = cmd
            MyDs.Tables("report_subscriptions").Clear()
            da.Fill(MyDs.Tables("report_subscriptions"))
            rpt.SetDataSource(MyDs.Tables("report_subscriptions"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rpt
        ElseIf ByAll.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_subscriptions"
            da.SelectCommand = cmd
            MyDs.Tables("report_subscriptions").Clear()
            da.Fill(MyDs.Tables("report_subscriptions"))
            rpt.SetDataSource(MyDs.Tables("report_subscriptions"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rpt
        ElseIf SpecialSubs.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from special_categories"
            da.SelectCommand = cmd
            MyDs.Tables("special_categories").Clear()
            da.Fill(MyDs.Tables("special_categories"))
            rptsp.SetDataSource(MyDs.Tables("special_categories"))
            rptsp.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rptsp
        End If

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
    Private Sub ByCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByCategory.CheckedChanged
        If ByCategory.Checked = True Then
            Type.Enabled = True
        End If
    End Sub

    Private Sub ByAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByAll.CheckedChanged
        If ByAll.Checked = True Then
            Type.Enabled = False
        End If
    End Sub

    Private Sub SpecialSubs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecialSubs.CheckedChanged
        If SpecialSubs.Checked = True Then
            Type.Enabled = False
        End If
    End Sub


End Class