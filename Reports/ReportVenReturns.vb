﻿Public Class ReportVenReturns

    Dim RptCustRet As New RptVendorReturns
    Dim b As Boolean = False
    Private TblEmp As New GeneralDataSet.EmployeesDataTable
    Private TblVen As New GeneralDataSet.vendorsDataTable
    Private TblStk As New GeneralDataSet.stocksDataTable

    Private Sub ReportVenReturns_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub

    Private Sub ReportCusReturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            cls.RefreshData("select * from Employees", TblEmp)
            cls.RefreshData("select * from Vendors", TblVen)
            cls.RefreshData("select * from Stocks", TblStk)

            cls.RefreshData("Items")
            ItemName.DataSource = MyDs
            ItemName.DisplayMember = "Items.Item_Name"
            ItemName.ValueMember = "Items.Item_ID"

            StockID.DataSource = TblStk
            StockID.DisplayMember = "stock_Name"
            StockID.ValueMember = "stock_ID"

            EmployeeID.DataSource = TblEmp
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"

            VendorID.DataSource = TblVen
            VendorID.DisplayMember = "Vendor_Name"
            VendorID.ValueMember = "Vendor_ID"

            b = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub RadioVendorID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioVendorID.CheckedChanged
        If RadioVendorID.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            VendorID.Enabled = True
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = True
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            VendorID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioBarCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBarCode.CheckedChanged
        If RadioBarCode.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = True
            EmployeeID.Enabled = False
            VendorID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub



    Private Sub RadioStockID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioStockID.CheckedChanged
        If RadioStockID.Checked = True Then
            StockID.Enabled = True
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            VendorID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub RadioTotalBill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTotalBill.CheckedChanged
        If RadioTotalBill.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            VendorID.Enabled = False
            TotalBill.Enabled = True
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If BillID.Text = "" Then
                cls.MsgExclamation("اختر رقم الفاتورة", "please enter document ID")
            Else
                MyDs.Tables("Report_Vendors_Returns").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Vendors_Returns where bill_id = " & BillID.Text
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Vendors_Returns"))
                RptCustRet.SetDataSource(MyDs.Tables("Report_Vendors_Returns"))
                RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustRet
                m.ShowDialog()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub


    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If b = True Then
                cmd.CommandText = "select distinct Bill_ID from Report_Vendors_Returns where item_id =" & ItemName.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub Barcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Barcode.Leave
        Try
            If b = True Then
                cmd.CommandText = "select distinct Bill_ID from Report_Vendors_Returns where barcode = N'" & Barcode.Text & "'"
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub VendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Return_V_Header where Vendor_id = " & VendorID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Return_V_Header where employee_id = " & EmployeeID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub StockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select  Bill_ID from Return_V_Header where stock_id = " & StockID.SelectedValue
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("Bill_ID"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub TotalBill_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TotalBill.Leave
        Try
            If b = True Then
                If TotalBill.Value > 0 Then
                    cmd.CommandText = "select Bill_ID from Return_V_Header where total_bill > " & TotalBill.Value
                    BillID.Items.Clear()
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        BillID.Items.Add(dr("Bill_ID"))
                    Loop
                    dr.Close()
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub RadioDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDates.CheckedChanged
        If RadioDates.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = False
            VendorID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.Leave
        Try
            Dim date1 As Date = CDate(DateTimePicker1.Text)
            Dim date2 As Date = CDate(DateTimePicker2.Text)
            cmd.CommandText = "select bill_id from Report_Vendors_Returns where Bill_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("Bill_ID"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Ven Returns")
        End Try
    End Sub

    Private Sub RadioEmployeeID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmployeeID.CheckedChanged
        If RadioEmployeeID.Checked = True Then
            StockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            EmployeeID.Enabled = True
            VendorID.Enabled = False
            TotalBill.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

 
End Class