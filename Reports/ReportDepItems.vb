Public Class ReportDepItems
    Dim RptPur As New RpDepItem

    Dim b As Boolean = False
    Private Sub ReportDepMeal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData("Employees")
            cls.RefreshData("Items")
            cls.RefreshData("stocks")


            StockID.DataSource = MyDs
            StockID.DisplayMember = "stocks.stock_Name"
            StockID.ValueMember = "stocks.stock_Id"

            EmployeeID.DataSource = MyDs
            EmployeeID.DisplayMember = "Employees.Employee_Name"
            EmployeeID.ValueMember = "Employees.Employee_ID"

            Item_ID.DataSource = MyDs
            Item_ID.DisplayMember = "Items.Item_Name"
            Item_ID.ValueMember = "Items.Item_ID"

            b = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report Dep ITems")
        End Try
    End Sub

    Private Sub RadMeal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadMeal.CheckedChanged
        If RadMeal.Checked = True Then
            StockID.Enabled = False

            EmployeeID.Enabled = False
            Item_ID.Enabled = True
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioEmployeeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmployeeID.CheckedChanged
        If RadioEmployeeID.Checked = True Then
            StockID.Enabled = False

            EmployeeID.Enabled = True
            Item_ID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioStockID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioStockID.CheckedChanged
        If RadioStockID.Checked = True Then
            StockID.Enabled = True

            EmployeeID.Enabled = False
            Item_ID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioTotalBill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTotalBill.CheckedChanged
        If RadioTotalBill.Checked = True Then
            StockID.Enabled = False

            EmployeeID.Enabled = False
            Item_ID.Enabled = False
            TotalBill.Enabled = True
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDates.CheckedChanged
        If RadioDates.Checked = True Then
            StockID.Enabled = False

            EmployeeID.Enabled = False
            Item_ID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        End If
    End Sub
    Private Sub ReportSalesOrder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If BillID.Text = "" Then
                cls.MsgExclamation("اختر رقم الفاتورة", "please enter document ID")

            Else


                Me.Cursor = Cursors.WaitCursor

                MyDs.Tables("report_dep_items").Rows.Clear()
                cmd.CommandText = "select * from report_dep_items where bill_id = " & BillID.Text
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_dep_items"))


                RptPur.SetDataSource(MyDs.Tables("report_dep_items"))
                RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptPur
                m.ShowDialog()
                Me.Cursor = Cursors.Default
            End If


        Catch ex As Exception
            cls.WriteError(ex.Message, "Report Dep ITems")
        End Try
    End Sub

    Private Sub Meal_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item_ID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Dep_Details where item_ID = " & Item_ID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report Dep ITems")
        End Try
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Dep_Header where employee_id = " & EmployeeID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report Dep ITems")
        End Try
    End Sub

    Private Sub StockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Dep_Header where stock_ID = " & StockID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report Dep ITems")
        End Try
    End Sub

    Private Sub TotalBill_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TotalBill.Leave
        Try
            If b = True Then
                If TotalBill.Value > 0 Then
                    cmd.CommandText = "select Bill_ID from Dep_Header where total_bill > " & TotalBill.Value
                    BillID.Items.Clear()
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        BillID.Items.Add(dr("Bill_ID"))
                    Loop
                    dr.Close()
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report Dep ITems")
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Try
            Dim date1 As Date = CDate(DateTimePicker1.Text)
            Dim date2 As Date = CDate(DateTimePicker2.Text)
            cmd.CommandText = "select distinct bill_id from report_dep_items where Bill_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("Bill_ID"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report Dep ITems")
        End Try
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

   
End Class