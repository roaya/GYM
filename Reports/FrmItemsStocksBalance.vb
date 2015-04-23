Public Class FrmItemsStocksBalance

    Dim rpt As New RptItemsStocksBalance
    Private Sub FrmItemsStocksBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        da.SelectCommand = cmd
        cmd.CommandText = " select item_name from items "
        dr = cmd.ExecuteReader
        Do While dr.Read = True
            Combitem.Items.Add(dr("item_name"))
        Loop
        dr.Close()
    End Sub

    Private Sub Radallitems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radallitems.CheckedChanged
        If Radallitems.Checked = True Then
            Combitem.Enabled = False
            Txtbarcode.Enabled = False
        End If
    End Sub

    Private Sub Raditemname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Raditemname.CheckedChanged
        If Raditemname.Checked = True Then
            Combitem.Enabled = True
            Txtbarcode.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyDs.Tables("report_items_stocks_balance").Rows.Clear()
        If Radallitems.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_items_stocks_balance order by stock_Name , item_name"
            da.Fill(MyDs.Tables("report_items_stocks_balance"))
            rpt.SetDataSource(MyDs.Tables("report_items_stocks_balance"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)
        ElseIf Raditemname.Checked = True Then
            If Combitem.Text = "" Then
                cls.MsgExclamation(" من فضلك اختر اسم الصنف ", "")
            Else
                cmd.CommandText = " select *,(select logo from app_preferences) as Logo from report_items_stocks_balance where item_name  = N'" & Combitem.Text & "'  order by stock_Name , item_name"
                da.Fill(MyDs.Tables("report_items_stocks_balance"))
                rpt.SetDataSource(MyDs.Tables("report_items_stocks_balance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rpt
                TabControl1.SelectTab(1)
            End If
        ElseIf Radbarcode.Checked = True Then
            If Txtbarcode.Text = "" Then
                cls.MsgExclamation("من فضلك اختر الباركود", "")
            Else
                cmd.CommandText = " select *,(select logo from app_preferences) as Logo from report_items_stocks_balance where barcode  = N'" & Txtbarcode.Text & "'  order by stock_Name , item_name"
                da.Fill(MyDs.Tables("report_items_stocks_balance"))
                rpt.SetDataSource(MyDs.Tables("report_items_stocks_balance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rpt
                TabControl1.SelectTab(1)
            End If

        End If


    End Sub

    Private Sub Radbarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radbarcode.CheckedChanged

        If Radbarcode.Checked = True Then
            Txtbarcode.Enabled = True
            Combitem.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.Click
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Txtbarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbarcode.GotFocus
        Txtbarcode.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Txtbarcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbarcode.Leave

        Txtbarcode.BackColor = Color.Gainsboro
    End Sub

    Private Sub Combitem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combitem.GotFocus
        Combitem.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Combitem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combitem.Leave
        Combitem.BackColor = Color.Gainsboro
    End Sub
    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Leave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.GotFocus
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub
End Class