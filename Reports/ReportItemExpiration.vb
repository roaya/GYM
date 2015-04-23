Public Class reportItemExpiration
    Dim rpt As New RptExpiration
    Dim bsource As New BindingSource
    Private Sub RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("Stocks")
        cls.RefreshData("items")
        thename.DataSource = MyDs
        thename.DisplayMember = "items.item_name"
        thename.ValueMember = "items.item_id"

        thestock.DataSource = MyDs
        thestock.DisplayMember = "Stocks.Stock_name"
        thestock.ValueMember = "Stocks.Stock_id"

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If bystock.Checked = True Then
            If byname.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_items_expired where item_id=" & thename.SelectedValue & " and Stock_id=" & thestock.SelectedValue & " and expired_date-GETDATE()<" & Remaining.Value
                da.SelectCommand = cmd
                MyDs.Tables("report_items_Expired").Clear()
                da.Fill(MyDs.Tables("report_items_expired"))
                rpt.SetDataSource(MyDs.Tables("report_items_expired"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
                TabControl1.SelectTab(1)
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_items_expired where Stock_id=" & thestock.SelectedValue & " and expired_date-GETDATE()<" & Remaining.Value
                da.SelectCommand = cmd
                MyDs.Tables("report_items_expired").Clear()
                da.Fill(MyDs.Tables("report_items_expired"))
                rpt.SetDataSource(MyDs.Tables("report_items_expired"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
                TabControl1.SelectTab(1)
            End If
        Else

            If byname.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_items_expired where item_id=" & thename.SelectedValue & " and expired_date-GETDATE()<" & Remaining.Value
                da.SelectCommand = cmd
                MyDs.Tables("report_items_expired").Clear()
                da.Fill(MyDs.Tables("report_items_expired"))
                rpt.SetDataSource(MyDs.Tables("report_items_expired"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
                TabControl1.SelectTab(1)
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_items_expired where expired_date-GETDATE()<" & Remaining.Value
                da.SelectCommand = cmd
                MyDs.Tables("report_items_expired").Clear()
                da.Fill(MyDs.Tables("report_items_expired"))
                rpt.SetDataSource(MyDs.Tables("report_items_expired"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
                TabControl1.SelectTab(1)
            End If
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub byname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byname.CheckedChanged
        thename.Enabled = True
    End Sub

    Private Sub byall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall.CheckedChanged
        thename.Enabled = False
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

    Private Sub bystock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bystock.CheckedChanged
        If bystock.Checked = True Then
            thestock.Enabled = True
        Else
            thestock.Enabled = False
        End If
    End Sub

 
End Class