Public Class FrmCustomerTeansaction


    Private rpt As New RptAccountTrans
    Dim TblCust As New GeneralDataSet.Procedure_MasterDataTable
    Private PType As String
    Dim date1, date2 As Date
    Private FirstBalance, LastBalance As Double

    ''Dim TotalFirstCredit, TotalBill, TotalCash, TotalCredit, TotalVisa, TotalCheque, TotalPayment, TotalReturn, TotalReserve, TotalReserveCash, TotalReserveCredit, TotalCustPayCheque As Double
    ''Dim TotalPayToCustCash, TotalPayToCustCheque As Double


    ''Private Sub RadCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    If RadCustomer.Checked = True Then
    ''        Combcustomer.Enabled = True
    ''        fromdate.Enabled = False
    ''        todate.Enabled = False

    ''    End If
    ''End Sub

    ''Private Sub Raddate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    If Raddate.Checked = True Then
    ''        Combcustomer.Enabled = False
    ''        fromdate.Enabled = True
    ''        todate.Enabled = True
    ''    End If
    ''End Sub


    Private Sub FrmCustomerTeansaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.RefreshData("Customers", " Customer_Name ")
        cmd.CommandText = "select * from procedure_master where Procedure_Category = N'عملاء'"
        da.Fill(TblCust)
        ComboCustomerID.DataSource = TblCust
        ComboCustomerID.DisplayMember = "Daily_Procedure_Name"
        ComboCustomerID.ValueMember = "Procedure_Master_ID"

        'cmd.CommandText = "select customer_name from customers"
        'dr = cmd.ExecuteReader
        'Do While dr.Read = True
        '    Combcustomer.Items.Add(dr("customer_name"))
        'Loop
        'dr.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If ComboCustomerID.Text = "" Then
            cls.MsgInfo("من فضلك اختر اسم العميل", "")
        Else
            Me.Cursor = Cursors.WaitCursor
            MyDs.Tables("MasterRecord").Rows.Clear()
            MyDs.Tables("Tran_Ven_Cust").Rows.Clear()
            date1 = CDate(fromdate.Text)
            date2 = CDate(todate.Text)

            MyDs.Tables("MasterRecord").Columns("Daily_Procedure_Name").DefaultValue = ComboCustomerID.Text
            'cmd.CommandText = "select procedure_type from procedure_master where procedure_master_id = " & ComboCustomerID.SelectedValue
            'PType = cmd.ExecuteScalar
            'If PType = "مدين" Then
            cmd.CommandText = "select dbo.Get_Any_Previous_Balance(" & ComboCustomerID.SelectedValue & " , '" & date1.ToString("MM/dd/yyyy") & "') from procedure_Master where Procedure_Master_ID=" & ComboCustomerID.SelectedValue
            'End If
            FirstBalance = cmd.ExecuteScalar

            cmd.CommandText = "SELECT (select logo from app_preferences) as logo,Procedure_Desc as Tran_Desc,Procedure_Date as Tran_Date,Procedure_Value as Tran_Value from Procedure_Details where Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and (from_procedure_master_id = " & ComboCustomerID.SelectedValue & " or to_procedure_master_id = " & ComboCustomerID.SelectedValue & ")"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Tran_Ven_Cust"))
            
            cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & ComboCustomerID.SelectedValue & " , '" & date2.ToString("MM/dd/yyyy") & "') from procedure_Master where Procedure_Master_ID=" & ComboCustomerID.SelectedValue
            LastBalance = cmd.ExecuteScalar

            rpt.SetDataSource(MyDs.Tables("Tran_Ven_Cust"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            rpt.SetParameterValue(0, "كشف حساب : " & ComboCustomerID.Text)
            rpt.SetParameterValue("FirstBalance", FirstBalance)
            rpt.SetParameterValue("LastBalance", LastBalance)

            CrystalReportViewer2.ReportSource = rpt
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub




    ''Sub CalcBalance()

    ''    d1 = fromdate.Text
    ''    d2 = todate.Text

    ''    cmd.CommandText = "select balance from customers where customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalFirstCredit = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'فاتورة مبيعات' and doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalBill = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'فاتورة مبيعات - اجل'  and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalCredit = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'فاتورة مبيعات - نقدي'  and doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalCash = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'فاتورة مبيعات - بشيك' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalCheque = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'فاتورة مبيعات - فيزا'  and doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalVisa = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'اذن ارتجاع' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalReturn = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'اذن دفع' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalPayment = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'اذن حجز بضاعه' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalReserve = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'اذن حجز بضاعه - نقدي' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalReserveCash = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'اذن حجز بضاعه - اجل' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalReserveCredit = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'اذن دفع شيك' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalCustPayCheque = cmd.ExecuteScalar

    ''    '--------------------------------------------
    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'دفع نقديه للعميل' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalPayToCustCash = cmd.ExecuteScalar

    ''    cmd.CommandText = " select isnull(sum(doc_value),0) from Report_Customer_Transaction where doc_type = N'دفع شيك للعميل' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'  and customer_name = N'" & Combcustomer.Text & "'"
    ''    TotalPayToCustCheque = cmd.ExecuteScalar
    ''    '--------------------------------------------


    ''    TxtCustomerBalance.Text = (TotalFirstCredit + TotalBill + TotalReserve + TotalPayToCustCash + TotalPayToCustCheque) - (TotalCash + TotalCheque + TotalVisa + TotalReturn + TotalPayment + TotalReserveCash + TotalCustPayCheque)


    ''End Sub
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

    Private Sub Combcustomer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerID.GotFocus
        ComboCustomerID.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Combcustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerID.Leave
        ComboCustomerID.BackColor = Color.Gainsboro
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