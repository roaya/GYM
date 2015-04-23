Public Class ReportSalesOrder

    Dim RptPur As New RptSalesOrder
    Dim RptPur2 As New RptSalesOrder2
    Dim b As Boolean = False
    Private TblCust As New GeneralDataSet.CustomersDataTable
    Private TblEmp As New GeneralDataSet.EmployeesDataTable
    Private TblStk As New GeneralDataSet.stocksDataTable

    Private Sub ReportSalesOrder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub
    REM rem rem Dim RptChk As New RptSalBill

    Private Sub ReportPurchaseOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData("select * from Employees", TblEmp)
            cls.RefreshData("select * from Customers", TblCust)
            cls.RefreshData("select * from Stocks", TblStk)


            StockID.DataSource = TblStk
            StockID.DisplayMember = "stock_Name"
            StockID.ValueMember = "stock_ID"

            EmployeeID.DataSource = TblEmp
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"

            CustomerID.DataSource = TblCust
            CustomerID.DisplayMember = "Customer_Name"
            CustomerID.ValueMember = "Customer_ID"

            b = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub RadioCustomerID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCustomerID.CheckedChanged
        If RadioCustomerID.Checked = True Then
            StockID.Enabled = False

            EmployeeID.Enabled = False
            CustomerID.Enabled = True
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub






    Private Sub RadioStockID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioStockID.CheckedChanged
        If RadioStockID.Checked = True Then
            StockID.Enabled = True

            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioTotalBill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTotalBill.CheckedChanged
        If RadioTotalBill.Checked = True Then
            StockID.Enabled = False

            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = True
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If BillID.Text = "" Then
                cls.MsgExclamation("اختر رقم الفاتورة", "please enter document ID")
            ElseIf ComboBoxPrintType.Text = "" Then
                cls.MsgExclamation("اختر نوع الطباعه", "please print type")
            Else
                '''''Me.Cursor = Cursors.WaitCursor
                '''''MyDs.Tables("report_sales").Rows.Clear()
                '''''cmd.CommandText = "select * from report_sales where bill_id = " & BillID.Text
                '''''da.SelectCommand = cmd
                '''''da.Fill(MyDs.Tables("report_sales"))
                '''''RptPur.SetDataSource(MyDs.Tables("report_sales"))
                '''''Dim m As New ShowAllReports
                '''''m.CrystalReportViewer1.ReportSource = RptPur
                '''''m.ShowDialog()
                '''''Me.Cursor = Cursors.Default


                Me.Cursor = Cursors.WaitCursor

                MyDs.Tables("Report_Sales").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Sales where bill_id = " & BillID.Text
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Sales"))
                If ComboBoxPrintType.Text = "نسختين" Then
                    RptPur2.SetDataSource(MyDs.Tables("Report_Sales"))
                    RptPur2.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    RptPur2.SetParameterValue("P_HeaderReport2", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    Dim m As New ShowAllReports
                    m.CrystalReportViewer1.ReportSource = RptPur2
                    m.ShowDialog()
                Else
                    RptPur.SetDataSource(MyDs.Tables("Report_Sales"))
                    RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    Dim m As New ShowAllReports
                    m.CrystalReportViewer1.ReportSource = RptPur
                    m.ShowDialog()
                End If
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub


    Private Sub CustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Sales_Header where Customer_id = " & CustomerID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Sales_Header where employee_id = " & EmployeeID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub StockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Sales_Header where stock_id = " & StockID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub TotalBill_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TotalBill.Leave
        Try
            If b = True Then
                If TotalBill.Value > 0 Then
                    cmd.CommandText = "select Bill_ID from Sales_Header where total_bill > " & TotalBill.Value
                    BillID.Items.Clear()
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        BillID.Items.Add(dr("Bill_ID"))
                    Loop
                    dr.Close()
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub RadioDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDates.CheckedChanged
        If RadioDates.Checked = True Then
            StockID.Enabled = False


            EmployeeID.Enabled = False
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.Leave
        Try
            Dim date1 As Date = CDate(DateTimePicker1.Text)
            Dim date2 As Date = CDate(DateTimePicker2.Text)
            cmd.CommandText = "select distinct bill_id from report_sales where Bill_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("Bill_ID"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Sal Orders")
        End Try
    End Sub

    Private Sub RadioEmployeeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmployeeID.CheckedChanged
        If RadioEmployeeID.Checked = True Then
            StockID.Enabled = False

            EmployeeID.Enabled = True
            CustomerID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
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