Public Class FrmReportStockValue

    Private Rpt As New ReportStockValue

    Private Sub CheckStockID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckStockID.CheckedChanged
        If CheckStockID.Checked = True Then
            RestaurantID.Enabled = True
        End If
    End Sub

    Private Sub CheckItemID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckItemID.CheckedChanged
        If CheckItemID.Checked = True Then
            ItemID.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyDs.Tables("Vu_Stock_Value").Rows.Clear()
        If CheckItemID.Checked = True And CheckStockID.Checked = False Then
            If ItemID.Text = "" Then
                cls.MsgComplete()
                Exit Sub
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Vu_Stock_Value where Item_id = " & ItemID.SelectedValue
            End If
        ElseIf CheckStockID.Checked = True And CheckItemID.Checked = False Then
            If RestaurantID.Text = "" Then
                cls.MsgComplete()
                Exit Sub
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Vu_Stock_Value where stock_id = " & RestaurantID.SelectedValue
            End If
        ElseIf CheckStockID.Checked = True And CheckItemID.Checked = True Then
            If RestaurantID.Text = "" And ItemID.Text = "" Then
                cls.MsgComplete()
                Exit Sub
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Vu_Stock_Value where Stock_id = " & RestaurantID.SelectedValue & " and Item_id = " & ItemID.SelectedValue
            End If
        ElseIf CheckStockID.Checked = False And CheckItemID.Checked = False Then
            cls.MsgComplete()
            Exit Sub
        End If

        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("Vu_Stock_Value"))
        Rpt.SetDataSource(MyDs.Tables("Vu_Stock_Value"))
        Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer1.ReportSource = Rpt
        TabControl1.SelectTab(1)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub FrmReportStockValue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("Stocks")
        cls.RefreshData("Items")
        ItemID.DataSource = MyDs
        ItemID.ValueMember = "Items.Item_ID"
        ItemID.DisplayMember = "Items.Item_Name"

        RestaurantID.DataSource = MyDs
        RestaurantID.ValueMember = "Stocks.Stock_ID"
        RestaurantID.DisplayMember = "Stocks.Stock_Name"

    End Sub
End Class