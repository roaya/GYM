Public Class FrmInvLog

    Dim Rpt As New ReportInvLog

    'Private Sub RadioDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If RadioDate.Checked = True Then
    '        StockName.Enabled = False
    '        ItemName.Enabled = False
    '        Panel1.Enabled = True
    '        DocType.Enabled = False
    '    End If
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MyDs.Tables("Report_Inventory_Log").Rows.Clear()

            Dim date1 As Date = CDate(DateTimePicker1.Text)
            Dim date2 As Date = CDate(DateTimePicker2.Text)


            If StockName.Text = "" Or ItemName.Text = "" Then
                cls.MsgExclamation("أدخل البيانات الناقصه", "please select warehouse")
            Else
                cmd.CommandText = "select N'" & ItemName.Text & "' as Item_Name , N'" & StockName.Text & "' as stock_name ,  N'رصيد اول المده' as doc_type , dbo.Get_Item_first_Balance('" & date1.ToString("MM/dd/yyyy") & "'," & ItemName.SelectedValue & "," & StockName.SelectedValue & ") as quantity ,(select logo from app_preferences) as Logo "
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Inventory_Log"))

                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Inventory_Log where doc_type <> N'ارصدة اول المده' and Item_ID = " & ItemName.SelectedValue & " and stock_id = " & StockName.SelectedValue & " and doc_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Inventory_Log"))

                cmd.CommandText = "select N'" & ItemName.Text & "' as Item_Name , N'" & StockName.Text & "' as stock_name ,  N'رصيد اخر المده' as doc_type , dbo.Get_Item_Last_Balance('" & date2.ToString("MM/dd/yyyy") & "'," & ItemName.SelectedValue & "," & StockName.SelectedValue & ") as quantity ,(select logo from app_preferences) as Logo "
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Inventory_Log"))

                Rpt.SetDataSource(MyDs.Tables("Report_Inventory_Log"))
                Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = Rpt
                TabControl1.SelectTab(1)
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, "Inv Log")
        End Try
    End Sub

    Private Sub FrmInvLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("stocks")
            StockName.DataSource = MyDs
            StockName.DisplayMember = "stocks.stock_Name"
            StockName.ValueMember = "stocks.stock_ID"

            cls.RefreshData("Items")
            ItemName.DataSource = MyDs
            ItemName.DisplayMember = "Items.Item_Name"
            ItemName.ValueMember = "Items.Item_ID"

        Catch ex As Exception
            cls.WriteError(ex.Message, "Inv Log")
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
    End Sub


    Private Sub Button1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
    End Sub

    Private Sub Button2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
    End Sub

End Class