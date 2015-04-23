Public Class FrmReportIncom

    Dim date1, date2 As Date
    Dim Tbl As New GeneralDataSet.Query_ShiftsDataTable
    Dim TblEmp As New GeneralDataSet.EmployeesDataTable
    Dim TblIncomeDtls As New DataTable
    Dim Shift, Employee As String
    Dim m As New ShowAllReports
    Dim Rpt As New RptIncome
    Dim Ty As String
    Dim T As New DataTable
    Dim Cat As String
    Dim Employ As Integer = 0

    Private Sub FrmReportIncome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", TblEmp)

        emp.DataSource = TblEmp
        emp.DisplayMember = "Employee_name"
        emp.ValueMember = "employee_id"

    End Sub

    Private Sub Check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check.Click
        date1 = FromDate.Text
        date2 = ToDate.Text



        If byemp.Checked = True Then
            cls.RefreshData("select * from query_shifts where start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' and Employee_Name=N'" & emp.Text & "'", Tbl)
            Employ = emp.SelectedValue
        Else
            cls.RefreshData("select * from query_shifts where start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", Tbl)
            Employ = 0
        End If



        r = Tbl.NewRow
        r("Shift_Name") = "كل الورديات"
        r("Shift_Detail_ID") = 0
        Tbl.Rows.Add(r)

        Shifts.DataSource = Tbl
        Shifts.Columns(0).HeaderText = "اسم الورديه"
        Shifts.Columns(1).Visible = False
        Shifts.Columns(2).HeaderText = "الرصيد النهائي"
        Shifts.Columns(3).HeaderText = "تاريخ البدايه"
        Shifts.Columns(4).HeaderText = "تاريخ النهايه"
        Shifts.Columns(5).HeaderText = "وقت البدايه"
        Shifts.Columns(6).HeaderText = "وقت النهايه"
        Shifts.Columns(7).HeaderText = "اسم الموظف"
        Shifts.Columns(8).Visible = False
        Shifts.Columns(9).Visible = False



    End Sub

    Private Sub byemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byemp.CheckedChanged
        If byemp.Checked = True Then
            emp.Enabled = True
        Else
            emp.Enabled = False
        End If
    End Sub

    Private Sub Shifts_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Shifts.MouseDoubleClick
        Try
            Shift = Shifts.SelectedRows(0).Cells("Shift_Detail_ID").Value
            ShiftName.Text = Shifts.SelectedRows(0).Cells("Employee_Name").Value & " - " & Shifts.SelectedRows(0).Cells("Real_start_Time").Value & " - " & Shifts.SelectedRows(0).Cells("Real_End_Time").Value & " - "

            If Shifts.SelectedRows(0).Cells("Shift_Name").Value.ToString = "كل الورديات" Then
                Shift = "sh.start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                ShiftName.Text = "كل الورديات من'" & date1.ToString("yyyy/MM/dd") & "'   الى   '" & date2.ToString("yyyy/MM/dd") & "'"
                If Employ <> 0 Then
                    cmd.CommandText = "select employee_Name from employees where employee_ID=" & Employ
                    ShiftName.Text = cmd.ExecuteScalar & " - " & ShiftName.Text
                End If
            Else
                Shift = "sh.shift_detail_id=" & Shift
            End If


            If Employ <> 0 Then
                Shift = Shift & " and Sh.employee_ID=" & Employ
                cmd.CommandText = "select employee_Name from employees where employee_ID=" & Employ
            End If


            MyDs.Tables("Income").Rows.Clear()

            cmd.CommandText = "SELECT s.Subscription_NAME as in_name,sc.category_name as 'desc',isnull(SUM(paid),0) as in_value,isnull(SUM(Remaining),0) as Credit,(select logo from app_preferences) as logo from subscriptions s,subscriptions_details sd,subscriptions_categories sc,shifts_details sh where(s.subscription_id = sd.subscription_id) and sh.shift_detail_id=sd.shift_detail_id and sc.Category_ID=s.Category_ID and " & Shift & " group by s.Subscription_NAME,sc.category_name,s.subscription_id "
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "SELECT sc.category_name as in_name,N'جلسات خاصه' as 'desc',isnull(SUM(s.value),0) as in_value,0 as Credit from Special_Categories sc,Special_Subscriptions s,shifts_details sh where(sc.Special_Categories_ID = s.Special_Categories_ID) and sh.shift_Detail_id=s.shift_detail_id and " & Shift & " group by sc.category_name,sc.Special_Categories_ID"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            cmd.CommandText = "select ISNULL(sum(Credit_Value),0) from sales_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r("Credit") = cmd.ExecuteScalar
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_V_Header r,shifts_details sh where footer=N'نقدي' and r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            r("Credit") = 0
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select N'اذونات استلام' as in_Name,N'-' as 'Desc',isnull(SUM(Rec_value),0) as in_value,0 as Credit from Money_Receivables pr,shifts_details sh where  pr.shift_Detail_id=sh.shift_Detail_id and " & Shift
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            cmd.CommandText = "select ISNULL(sum(Credit_Value),0) from purchase_header r,shifts_details sh where r.shift_detail_id=sh.shift_detail_id and " & Shift
            r("Credit") = cmd.ExecuteScalar
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_C_Header r,shifts_details sh where footer=N'نقدي' and r.shift_detail_id=sh.shift_detail_id and " & Shift
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            r("Credit") = 0
            MyDs.Tables("income").Rows.Add(r)



            cmd.CommandText = "select N'اذونات دفع أخرى' as in_Name,N'اذونات دفع' as 'Desc',isnull(-SUM(pay_value),0) as in_value,0 as Credit from Money_Payables pr,shifts_details sh,Procedure_Master PM where Pm.Procedure_Master_ID=PR.To_procedure_Master_ID and  pr.shift_Detail_id=sh.shift_Detail_id and " & Shift & " and pm.Procedure_Category not in (N'مصاريف اداريه',N'مصاريف تسويقيه')"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select N'مصروفات' as in_Name,N'اذونات دفع' as 'Desc',isnull(-SUM(pay_value),0) as in_value,0 as Credit from Money_Payables pr,shifts_details sh,Procedure_Master PM where Pm.Procedure_Master_ID=PR.To_procedure_Master_ID and  pr.shift_Detail_id=sh.shift_Detail_id and " & Shift & " and pm.Procedure_Category in (N'مصاريف اداريه',N'مصاريف تسويقيه')"
            da.Fill(MyDs.Tables("income"))

            Income.DataSource = MyDs.Tables("Income")
            Income.Columns(0).HeaderText = "النوع"
            Income.Columns(1).HeaderText = "الوصف"
            Income.Columns(2).HeaderText = "النقدي"
            Income.Columns(3).HeaderText = "الآجل"
            Income.Columns(4).Visible = False

            r = (MyDs.Tables("Income").NewRow)
            r("In_value") = 0
            r("Credit") = 0
            For i As Integer = 0 To Income.Rows.Count - 1
                r("In_value") = r("In_Value") + Income.Rows(i).Cells("In_Value").Value
                r("Credit") = r("Credit") + Income.Rows(i).Cells("Credit").Value
            Next
            r("In_Name") = "الاجمالي"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


        Catch
            cls.ErrMsg()
        End Try
    End Sub


    Private Sub ShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowReport.Click

        MyDs.Tables("Income").Rows.RemoveAt(MyDs.Tables("Income").Rows.Count - 1)

        Rpt.SetDataSource(MyDs.Tables("Income"))
        Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        Rpt.SetParameterValue("Report_Type", ShiftName.Text)
        m.CrystalReportViewer1.ReportSource = Rpt
        m.ShowDialog()

        r = (MyDs.Tables("Income").NewRow)
        r("In_value") = 0
        r("Credit") = 0
        For i As Integer = 0 To Income.Rows.Count - 1
            r("In_value") = r("In_Value") + Income.Rows(i).Cells("In_Value").Value
            r("Credit") = r("Credit") + Income.Rows(i).Cells("Credit").Value
        Next
        r("In_Name") = "الاجمالي"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

    End Sub


    Private Sub Income_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Income.MouseDoubleClick
        Try
            T.Rows.Clear()
            T.Columns.Clear()

            If Income.SelectedRows(0).Cells("In_Name").Value.ToString = "المبيعات" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Bill_Date,Employee_Name,Customer_Name,Total_Bill,Cash_Value,Credit_Value from report_sales_header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "التاريخ"
                IncomeDetails.Columns(3).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(4).HeaderText = "اسم العميل"
                IncomeDetails.Columns(5).HeaderText = "الاجمالي"
                IncomeDetails.Columns(6).HeaderText = "المدفوع"
                IncomeDetails.Columns(7).HeaderText = "الأجل"


                Type.Text = "فواتير المبيعات"
                Ty = "Sales"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "المشتريات" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Bill_Date,Employee_Name,Vendor_Name,Total_Bill,Cash_Value,Credit_Value from report_purchase_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "التاريخ"
                IncomeDetails.Columns(3).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(4).HeaderText = "اسم المورد"
                IncomeDetails.Columns(5).HeaderText = "الاجمالي"
                IncomeDetails.Columns(6).HeaderText = "المدفوع"
                IncomeDetails.Columns(7).HeaderText = "الأجل"


                Type.Text = "فواتير المشتريات"
                Ty = "Purchase"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مرتجعات الموردين" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Employee_Name,Vendor_Name,Total_Bill from report_return_v_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(3).HeaderText = "اسم المورد"
                IncomeDetails.Columns(4).HeaderText = "الاجمالي"

                Type.Text = "فواتير مرتجعات الموردين"
                Ty = "ReturnV"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مرتجعات العملاء" Then
                cls.RefreshData("select Bill_ID,Bill_Time,Employee_Name,Customer_Name,Total_Bill from report_return_c_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "رقم الفاتوره"
                IncomeDetails.Columns(1).HeaderText = "الوقت"
                IncomeDetails.Columns(2).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(3).HeaderText = "اسم العميل"
                IncomeDetails.Columns(4).HeaderText = "الاجمالي"


                Type.Text = "فواتير مرتجعات العملاء"
                Ty = "ReturnC"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "اذونات استلام" Then
                cls.RefreshData("select Daily_procedure_Name,Rec_Value as Procedure_Balance,Procedure_Category,Procedure_Type,Rec_Desc as Procedure_Desc,Rec_ID from Procedure_Master PM,Money_Receivables MP,Shifts_Details Sh where MP.From_Procedure_Master_ID=PM.Procedure_Master_ID and sh.shift_Detail_ID=Mp.shift_Detail_ID and Rec_Type=N'نقدي' and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "اسم الحساب"
                IncomeDetails.Columns(1).HeaderText = "قيمة المستلم"
                IncomeDetails.Columns(2).HeaderText = "نوع الحساب"
                IncomeDetails.Columns(3).HeaderText = "طبيعة الحساب"
                IncomeDetails.Columns(4).HeaderText = "الوصف"
                IncomeDetails.Columns(5).Visible = False

                Type.Text = "اذونات استلام"
                Ty = "Rec"
            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString = "مصروفات" Then
                cls.RefreshData("select Daily_procedure_Name,Pay_value as Procedure_Balance,Procedure_Category,Procedure_Type,Pay_Desc as Procedure_Desc,Pay_ID from Procedure_Master PM,Money_Payables MP,Shifts_Details Sh where MP.To_Procedure_Master_ID=PM.Procedure_Master_ID and sh.shift_Detail_ID=Mp.shift_Detail_ID and Pay_Type=N'نقدي' and " & Shift & " and pm.Procedure_Category in (N'مصاريف اداريه',N'مصاريف تسويقيه')", T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "اسم الحساب"
                IncomeDetails.Columns(1).HeaderText = "قيمة المدفوع"
                IncomeDetails.Columns(2).HeaderText = "نوع الحساب"
                IncomeDetails.Columns(3).HeaderText = "طبيعة الحساب"
                IncomeDetails.Columns(4).HeaderText = "الوصف"
                IncomeDetails.Columns(5).Visible = False

                Type.Text = "مصروفات"
                Ty = "Exp"
            ElseIf Income.SelectedRows(0).Cells("Desc").Value.ToString = "اذونات دفع" Then
                cls.RefreshData("select Daily_procedure_Name,Pay_value as Procedure_Balance,Procedure_Category,Procedure_Type,Pay_Desc as Procedure_Desc,Pay_ID from Procedure_Master PM,Money_Payables MP,Shifts_Details Sh where MP.To_Procedure_Master_ID=PM.Procedure_Master_ID and sh.shift_Detail_ID=Mp.shift_Detail_ID and Pay_Type=N'نقدي' and " & Shift & " and pm.Procedure_Category not in (N'مصاريف اداريه',N'مصاريف تسويقيه')", T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).HeaderText = "اسم الحساب"
                IncomeDetails.Columns(1).HeaderText = "قيمة المدفوع"
                IncomeDetails.Columns(2).HeaderText = "نوع الحساب"
                IncomeDetails.Columns(3).HeaderText = "طبيعة الحساب"
                IncomeDetails.Columns(4).HeaderText = "الوصف"
                IncomeDetails.Columns(5).Visible = False

                Type.Text = "اذونات دفع"
                Ty = "Pay"
            ElseIf Income.SelectedRows(0).Cells("Desc").Value.ToString = "جلسات خاصه" Then
                cls.RefreshData("select Special_Categories_ID,Category_Name,Employee_Name,Customer_Name,Value,Coach_Percent from report_Special_Subscriptions RS,Shifts_Details Sh where sh.shift_Detail_ID=Rs.shift_Detail_ID and category_Name=N'" & Income.SelectedRows(0).Cells("In_Name").Value.ToString & "' and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).Visible = False
                IncomeDetails.Columns(1).HeaderText = "البند"
                IncomeDetails.Columns(2).HeaderText = "اسم الموظف"
                IncomeDetails.Columns(3).HeaderText = "اسم العميل"
                IncomeDetails.Columns(4).HeaderText = "قيمة الجلسة"
                IncomeDetails.Columns(5).HeaderText = "نسبة المدرب"

                cmd.CommandText = "Select special_Categories_ID from special_Categories where Category_Name=N'" & Income.SelectedRows(0).Cells("In_Name").Value.ToString & "'"
                Cat = cmd.ExecuteScalar

                Type.Text = "جلسة خاصة - " & Income.SelectedRows(0).Cells("In_Name").Value.ToString
                Ty = "Special"

            ElseIf Income.SelectedRows(0).Cells("In_Name").Value.ToString <> "الاجمالي" Then
                cls.RefreshData("select Subscription_Detail_ID,Subscription_Name as N'اسم الاشتراك',Customer_Name as N'العميل',Subscription_Type as N'نوع الاشتراك',coach.Employee_Name as N'المدرب',Paid as N'المدفوع',Remaining as N'الباقي',e.Employee_Name as N'الموظف' from Subscriptions_Details SD join Employees E on E.Employee_Id=SD.Employee_id join Subscriptions S on SD.Subscription_ID=s.Subscription_ID join Customers C on  SD.Customer_ID=C.Customer_Id left outer join Employees Coach on (SD.Coach_ID=Coach.Employee_Id) join Shifts_Details sh on sh.Shift_Detail_ID=SD.Shift_Detail_ID where subscription_Name=N'" & Income.SelectedRows(0).Cells("In_Name").Value.ToString & "' and " & Shift, T)
                IncomeDetails.DataSource = T
                IncomeDetails.Columns(0).Visible = False
                cmd.CommandText = "select subscription_ID from subscriptions where subscription_Name=N'" & Income.SelectedRows(0).Cells("In_Name").Value.ToString & "'"
                Cat = cmd.ExecuteScalar
                Type.Text = "اشتراك - " & Income.SelectedRows(0).Cells("In_Name").Value.ToString
                Ty = "Subsc"
            End If
        Catch
            cls.ErrMsg()
        End Try
    End Sub

    Private Sub IncomeDetails_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IncomeDetails.MouseDoubleClick
        If Ty = "Sales" Then
            Dim RptSales As New RptSalesOrder
            MyDs.Tables("Report_Sales").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo from Report_Sales where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Sales"))
            RptSales.SetDataSource(MyDs.Tables("Report_Sales"))
            RptSales.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptSales
            m.ShowDialog()

        ElseIf Ty = "Purchase" Then
            Dim RptPur As New RptPurchaseOrder
            MyDs.Tables("Report_Purchase").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Purchase where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Purchase"))
            RptPur.SetDataSource(MyDs.Tables("Report_Purchase"))
            RptPur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptPur
            m.ShowDialog()

        ElseIf Ty = "ReturnV" Then
            Dim RptVenRet As New RptVendorReturns
            MyDs.Tables("Report_Vendors_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Vendors_Returns where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Vendors_Returns"))
            RptVenRet.SetDataSource(MyDs.Tables("Report_Vendors_Returns"))
            RptVenRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptVenRet
            m.ShowDialog()

        ElseIf Ty = "ReturnC" Then
            Dim RptCustRet As New RptCustomerReturns
            MyDs.Tables("Report_Customers_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as logo  from Report_Customers_Returns where bill_id = " & IncomeDetails.SelectedRows(0).Cells("Bill_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Customers_Returns"))
            RptCustRet.SetDataSource(MyDs.Tables("Report_Customers_Returns"))
            RptCustRet.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptCustRet
            m.ShowDialog()

        ElseIf Ty = "Rec" Then
            Dim RptPay As New RptReceivePay
            RptPay.ReportDefinition.ReportObjects.Item("TitleRecMoney").ObjectFormat.EnableSuppress = False
            RptPay.ReportDefinition.ReportObjects.Item("TitlePayMoney").ObjectFormat.EnableSuppress = True
            RptPay.ReportDefinition.ReportObjects.Item("TxtReceive").ObjectFormat.EnableSuppress = False
            RptPay.ReportDefinition.ReportObjects.Item("TxtPay").ObjectFormat.EnableSuppress = True

            MyDs.Tables("ReceivePay").Rows.Clear()
            cmd.CommandText = "select Rec_ID,Daily_Procedure_Name Account_Name,Rec_Date Account_Date,Rec_Value Account_Value,Rec_Desc Account_Desc,N'نقدي' Account_Type From Money_Receivables M,Procedure_Master P where p.procedure_master_ID=M.From_procedure_Master_ID and Rec_ID=" & IncomeDetails.SelectedRows(0).Cells("Rec_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("ReceivePay"))
            RptPay.SetDataSource(MyDs.Tables("ReceivePay"))
            m.CrystalReportViewer1.ReportSource = RptPay
            m.ShowDialog()
        ElseIf Ty = "Subsc" Then
            Dim RptSubsc As New RptSubscriptionPrint
            cmd.CommandText = "select max(subscription_detail_id) from subscriptions_details"
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscription_Print where Subscription_Detail_id=" & IncomeDetails.SelectedRows(0).Cells("Subscription_Detail_ID").Value
            da.SelectCommand = cmd
            MyDs.Tables("Report_Subscription_Print").Clear()
            da.Fill(MyDs.Tables("Report_Subscription_Print"))
            RptSubsc.SetDataSource(MyDs.Tables("Report_Subscription_Print"))
            RptSubsc.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = RptSubsc
            m.ShowDialog()
        Else
            Dim RptPay As New RptReceivePay
            RptPay.ReportDefinition.ReportObjects.Item("TitleRecMoney").ObjectFormat.EnableSuppress = True
            RptPay.ReportDefinition.ReportObjects.Item("TitlePayMoney").ObjectFormat.EnableSuppress = False
            RptPay.ReportDefinition.ReportObjects.Item("TxtReceive").ObjectFormat.EnableSuppress = True
            RptPay.ReportDefinition.ReportObjects.Item("TxtPay").ObjectFormat.EnableSuppress = False

            MyDs.Tables("ReceivePay").Rows.Clear()
            cmd.CommandText = "select Pay_ID Rec_ID,Daily_Procedure_Name Account_Name,Pay_Date Account_Date,Pay_Value Account_Value,Pay_Desc Account_Desc,N'نقدي' Account_Type From Money_Payables M,Procedure_Master P where p.procedure_master_ID=M.To_procedure_Master_ID and Pay_ID=" & IncomeDetails.SelectedRows(0).Cells("Pay_ID").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("ReceivePay"))
            RptPay.SetDataSource(MyDs.Tables("ReceivePay"))
            m.CrystalReportViewer1.ReportSource = RptPay
            m.ShowDialog()
        End If

    End Sub



    Private Sub Type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type.Click
        If Ty = "Sales" Then
            Dim Rpt As New RptSales
            MyDs.Tables("Report_Sales_Header").Rows.Clear()
            cls.RefreshData("select *,(Select Logo From App_Preferences) as logo from report_sales_header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("Report_Sales_Header"))
            Rpt.SetDataSource(MyDs.Tables("Report_Sales_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        ElseIf Ty = "Purchase" Then
            Dim Rpt As New ReportPurchase
            MyDs.Tables("Report_Purchase_Header").Rows.Clear()
            cls.RefreshData("select *,(Select Logo From App_Preferences) as logo from report_purchase_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("Report_Purchase_Header"))
            Rpt.SetDataSource(MyDs.Tables("Report_Purchase_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        ElseIf Ty = "ReturnV" Then
            Dim Rpt As New Report_ReturnVHeader
            MyDs.Tables("report_return_v_Header").Rows.Clear()
            cls.RefreshData("select *,(Select Logo From App_Preferences) as logo from report_return_v_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("report_return_v_Header"))
            Rpt.SetDataSource(MyDs.Tables("report_return_v_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()


        ElseIf Ty = "ReturnC" Then
            Dim Rpt As New ReportReturnCHeader
            MyDs.Tables("report_return_c_Header").Rows.Clear()
            cls.RefreshData("select *,(Select Logo From App_Preferences) as logo from report_return_c_Header s,Shifts_Details sh where s.shift_Detail_ID=sh.shift_Detail_ID and " & Shift, MyDs.Tables("report_return_c_Header"))
            Rpt.SetDataSource(MyDs.Tables("report_return_c_Header"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        ElseIf Ty = "Rec" Then
            Dim Rpt As New MoneyTrans
            MyDs.Tables("MoneyTrans").Rows.Clear()
            cls.RefreshData("select Daily_procedure_Name Account,Rec_Value as Value,Rec_Desc as 'Desc',Rec_Date as 'date',(Select Logo From App_Preferences) as logo from Procedure_Master PM,Money_Receivables MP,Shifts_Details Sh where MP.From_Procedure_Master_ID=PM.Procedure_Master_ID and sh.shift_Detail_ID=Mp.shift_Detail_ID and Rec_Type=N'نقدي' and " & Shift, MyDs.Tables("MoneyTrans"))
            Rpt.SetDataSource(MyDs.Tables("MoneyTrans"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            Rpt.SetParameterValue("P_Type", "اذونات استلام")
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()



        ElseIf Ty = "Special" Then
            Dim Rpt As New RptSpecialSubscriptions
            MyDs.Tables("report_Special_subscriptions").Rows.Clear()
            cls.RefreshData("select *,(Select Logo From App_Preferences) as logo from report_Special_subscriptions RS,Shifts_Details Sh where sh.shift_Detail_ID=Rs.shift_Detail_ID and special_Categories_ID=" & Cat & " and " & Shift, MyDs.Tables("report_Special_subscriptions"))
            Rpt.SetDataSource(MyDs.Tables("report_Special_subscriptions"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()


        ElseIf Ty = "Subsc" Then
            Dim Rpt As New RptSubscriptionsDetails
            MyDs.Tables("Report_Subscriptions_Details").Rows.Clear()
            cls.RefreshData("select *,(Select Logo From App_Preferences) as logo from Report_Subscriptions_Details sd,Shifts_Details sh  where sd.shift_detail_ID=sh.shift_Detail_ID and subscription_Id=" & Cat & " and " & Shift, MyDs.Tables("Report_Subscriptions_Details"))
            Rpt.SetDataSource(MyDs.Tables("Report_Subscriptions_Details"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        ElseIf Ty = "Pay" Then
            Dim Rpt As New MoneyTrans
            MyDs.Tables("MoneyTrans").Rows.Clear()
            cls.RefreshData("select Daily_procedure_Name Account,Pay_value as Value,Pay_Desc as 'Desc',Pay_Date as 'date',(Select Logo From App_Preferences) as logo from Procedure_Master PM,Money_Payables MP,Shifts_Details Sh where MP.To_Procedure_Master_ID=PM.Procedure_Master_ID and sh.shift_Detail_ID=Mp.shift_Detail_ID and Pay_Type=N'نقدي' and " & Shift & " and pm.Procedure_Category not in (N'مصاريف اداريه',N'مصاريف تسويقيه')", MyDs.Tables("MoneyTrans"))
            Rpt.SetDataSource(MyDs.Tables("MoneyTrans"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            Rpt.SetParameterValue("P_Type", "اذونات دفع - " & Ty)
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()
        Else
            Dim Rpt As New MoneyTrans
            MyDs.Tables("MoneyTrans").Rows.Clear()
            cls.RefreshData("select Daily_procedure_Name Account,Pay_value as Value,Pay_Desc as 'Desc',Pay_Date as 'date',(Select Logo From App_Preferences) as logo from Procedure_Master PM,Money_Payables MP,Shifts_Details Sh where MP.To_Procedure_Master_ID=PM.Procedure_Master_ID and sh.shift_Detail_ID=Mp.shift_Detail_ID and Pay_Type=N'نقدي' and " & Shift & " and pm.Procedure_Category in (N'مصاريف اداريه',N'مصاريف تسويقيه')", MyDs.Tables("MoneyTrans"))
            Rpt.SetDataSource(MyDs.Tables("MoneyTrans"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            Rpt.SetParameterValue("P_Type", "مصروفات - " & Ty)
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()
        End If
    End Sub


End Class


