Public Class FrmReportIncome

    Dim date1, date2 As Date
    Dim rpt As New RptIncome
    Dim TblEmp As New GeneralDataSet.EmployeesDataTable
    Dim TblShifts As New GeneralDataSet.Query_ShiftsDataTable
    Dim bsource As New BindingSource
    Dim ListType As String
    Dim The_Type As String
    Dim sh_Emp_ID As Integer
    Private Sub FrmReportIncome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", TblEmp)

        emp.DataSource = TblEmp
        emp.DisplayMember = "Employee_name"
        emp.ValueMember = "employee_id"

        If INC = 1 Then
            cmd.CommandText = "select replace(employee_name + ' (" & FromDate.Value.ToString("dd/MM/yyyy") & ")' + N' من ' +isnull( Real_Start_Time,' ') + N' الى ' + isnull(Real_End_Time,' '),'?','') as employee_name,shift_Detail_id from query_Shifts where shift_Detail_id=" & CurrentShiftId
            Type.Text = cmd.ExecuteScalar
            FromDate.Text = Today.AddDays(-1)
            ToDate.Text = Today
            The_Type = "shift"
            sh_Emp_ID = CurrentShiftId
            MyDs.Tables("Income").Rows.Clear()

            cmd.CommandText = "SELECT s.subscription_id as in_id,s.Subscription_NAME as in_name,sc.category_name as 'desc',SUM(paid)as in_value,(select logo from app_preferences) as logo from subscriptions s,subscriptions_details sd,subscriptions_categories sc,shifts_details sh where(s.subscription_id = sd.subscription_id) and sh.shift_detail_id=sd.shift_detail_id and sc.Category_ID=s.Category_ID and sh.shift_detail_id=" & CurrentShiftId & " group by s.Subscription_NAME,sc.category_name,s.subscription_id "
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "SELECT sc.Special_Categories_ID as in_id,sc.category_name as in_name,N'جلسات خاصه' as 'desc',SUM(s.value)as in_value from Special_Categories sc,Special_Subscriptions s,shifts_details sh where(sc.Special_Categories_ID = s.Special_Categories_ID) and sh.shift_Detail_id=s.shift_detail_id and sh.shift_detail_id=" & CurrentShiftId & " group by sc.category_name,sc.Special_Categories_ID"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftId
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftId
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select procedure_master_id as in_id,daily_procedure_name as in_Name,N'اذونات استلام' as 'Desc',SUM(Rec_Value) as in_value from Procedure_Master pm,Money_Receivables pr ,shifts_details sh  where pm.Procedure_Master_ID=pr.From_Procedure_Master_ID and sh.shift_Detail_id =pr.shift_Detail_id and sh.shift_detail_id=" & CurrentShiftId & " group by daily_procedure_name,procedure_master_id"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftId
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftId
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Dep_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftId
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "الاصناف المهلكه"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select procedure_master_id as in_id,daily_procedure_name as in_Name,N'اذونات دفع' as 'Desc',-SUM(pay_value) as in_value from Procedure_Master pm,Money_Payables pr,shifts_details sh where pm.Procedure_Master_ID=pr.to_Procedure_Master_ID and pr.shift_Detail_id=sh.shift_Detail_id and sh.shift_detail_id=" & CurrentShiftId & " group by daily_procedure_name,procedure_master_id"
            da.Fill(MyDs.Tables("income"))




            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False


            'DataGridView1.Columns("in_name").Width = 400
            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            'DataGridView1.Columns("desc").Width = 250
            DataGridView1.Columns("desc").HeaderText = "الوصف"
            'DataGridView1.Columns("in_value").Width = 400
            DataGridView1.Columns("in_value").HeaderText = "القيمة"


        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        date1 = CDate(FromDate.Text)
        date2 = CDate(ToDate.Text)
        MyDs.Tables("Income").Rows.Clear()

        If FromDate.Value = Nothing Then
            MsgBox("برجاء ادخل التاريخ المراد الاستعلام به")
            Exit Sub
        End If



        If byemp.Checked = True Then

            If emp.SelectedValue = Nothing Then
                MsgBox("برجاء ادخل اسم الموظف")
                Exit Sub
            End If
            The_Type = "emp"
            Type.Text = emp.Text
            sh_Emp_ID = emp.SelectedValue
            cmd.CommandText = "SELECT s.subscription_id as in_id,s.Subscription_NAME as in_name,sc.category_name as 'desc',SUM(paid)as in_value,(select logo from app_preferences) as logo from subscriptions s,subscriptions_details sd,subscriptions_categories sc,shifts_details sh where(s.subscription_id = sd.subscription_id) and sh.shift_detail_id=sd.shift_detail_id and sc.Category_ID=s.Category_ID and sh.employee_id=" & emp.SelectedValue & " and sh.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by s.Subscription_NAME,sc.category_name,s.subscription_id "
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "SELECT sc.Special_Categories_ID as in_id,sc.category_name as in_name,N'جلسات خاصه' as 'desc',SUM(s.value)as in_value from Special_Categories sc,Special_Subscriptions s,shifts_details sh where(sc.Special_Categories_ID = s.Special_Categories_ID) and sh.shift_Detail_id=s.shift_detail_id and sh.employee_id=" & emp.SelectedValue & " and sh.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by sc.category_name,sc.Special_Categories_ID"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select procedure_master_id as in_id,daily_procedure_name as in_Name,N'اذونات استلام' as 'Desc',SUM(Rec_Value) as in_value from Procedure_Master pm,Money_Receivables pr ,shifts_details sh  where pm.Procedure_Master_ID=pr.From_Procedure_Master_ID and sh.shift_Detail_id =pr.shift_Detail_id and sh.employee_id=" & emp.SelectedValue & " and sh.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by daily_procedure_name,procedure_master_id"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Dep_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.employee_id=" & emp.SelectedValue & " and s.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "الاصناف المهلكه"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select procedure_master_id as in_id,daily_procedure_name as in_Name,N'اذونات دفع' as 'Desc',-SUM(pay_value) as in_value from Procedure_Master pm,Money_Payables pr,shifts_details sh where pm.Procedure_Master_ID=pr.to_Procedure_Master_ID and pr.shift_Detail_id=sh.shift_Detail_id and sh.employee_id=" & emp.SelectedValue & " and sh.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by daily_procedure_name,procedure_master_id"
            da.Fill(MyDs.Tables("income"))


            'cmd.CommandText="select dbo.Get_Any_Balance(5,'"&  &"','"& &"')"

            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False


            DataGridView1.Columns("in_name").Width = 400
            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            DataGridView1.Columns("desc").Width = 250
            DataGridView1.Columns("desc").HeaderText = "الوصف"
            DataGridView1.Columns("in_value").Width = 250
            DataGridView1.Columns("in_value").HeaderText = "القيمة"

        ElseIf ByShift.Checked = True Then

            If Shift.SelectedValue = Nothing Then
                MsgBox("برجاء ادخل الورديه")
                Exit Sub
            End If
            The_Type = "shift"
            Type.Text = Shift.Text
            sh_Emp_ID = Shift.SelectedValue


            cmd.CommandText = "SELECT s.subscription_id as in_id,s.Subscription_NAME as in_name,sc.category_name as 'desc',SUM(paid)as in_value,(select logo from app_preferences) as logo from subscriptions s,subscriptions_details sd,subscriptions_categories sc,shifts_details sh where(s.subscription_id = sd.subscription_id) and sh.shift_detail_id=sd.shift_detail_id and sc.Category_ID=s.Category_ID and sh.shift_detail_id=" & Shift.SelectedValue & " group by s.Subscription_NAME,sc.category_name,s.subscription_id "
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "SELECT sc.Special_Categories_ID as in_id,sc.category_name as in_name,N'جلسات خاصه' as 'desc',SUM(s.value)as in_value from Special_Categories sc,Special_Subscriptions s,shifts_details sh where(sc.Special_Categories_ID = s.Special_Categories_ID) and sh.shift_Detail_id=s.shift_detail_id and sh.shift_detail_id=" & Shift.SelectedValue & " group by sc.category_name,sc.Special_Categories_ID"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select N'اذونات استلام' as in_Name,N'اذونات استلام' as 'Desc',SUM(Rec_Value) as in_value from Money_Payables where " & Shift.SelectedValue
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Dep_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_Detail_id=" & Shift.SelectedValue
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "الاصناف المهلكه"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select N'اذونات دفع' as in_Name,N'اذونات دفع' as 'Desc',-SUM(pay_value) as in_value from Money_Receivables where " & Shift.SelectedValue
            da.Fill(MyDs.Tables("income"))




            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False

            DataGridView1.Columns("in_name").Width = 400
            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            DataGridView1.Columns("desc").Width = 250
            DataGridView1.Columns("desc").HeaderText = "الوصف"
            DataGridView1.Columns("in_value").Width = 250
            DataGridView1.Columns("in_value").HeaderText = "القيمة"


        Else

            The_Type = "normal"
            Type.Text = FromDate.Value.ToString("dd/MM/yyyy") & " الى " & ToDate.Value.ToString("dd/MM/yyyy")

            cmd.CommandText = "SELECT s.subscription_id as in_id,s.Subscription_NAME as in_name,sc.category_name as 'desc',SUM(paid)as in_value,(select logo from app_preferences) as logo from subscriptions s,subscriptions_details sd,subscriptions_categories sc,shifts_details sh where(s.subscription_id = sd.subscription_id) and sh.shift_detail_id=sd.shift_detail_id and sc.Category_ID=s.Category_ID and sd.start_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by s.Subscription_NAME,sc.category_name,s.subscription_id "
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "SELECT sc.Special_Categories_ID as in_id,sc.category_name as in_name,N'جلسات خاصه' as 'desc',SUM(s.value)as in_value from Special_Categories sc,Special_Subscriptions s,shifts_details sh where(sc.Special_Categories_ID = s.Special_Categories_ID) and sh.shift_Detail_id=s.shift_detail_id and special_subscription_Date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by sc.category_name,sc.Special_Categories_ID"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "المبيعات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = cmd.ExecuteScalar
            r("In_Name") = "مرتجعات الموردين"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select procedure_master_id as in_id,daily_procedure_name as in_Name,N'اذونات استلام' as 'Desc',SUM(Rec_Value) as in_value from Procedure_Master pm,Money_Receivables pr ,shifts_details sh  where pm.Procedure_Master_ID=pr.From_Procedure_Master_ID and sh.shift_Detail_id =pr.shift_Detail_id and rec_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by daily_procedure_name,procedure_master_id"
            da.Fill(MyDs.Tables("income"))

            cmd.CommandText = "select ISNULL(sum(cash_value),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and bill_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "المشتريات"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and bill_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "مرتجعات العملاء"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)

            cmd.CommandText = "select ISNULL(sum(total_bill),0) from Dep_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and r.bill_Date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
            r = MyDs.Tables("Income").NewRow
            r("In_Value") = -cmd.ExecuteScalar
            r("In_Name") = "الاصناف المهلكه"
            r("Desc") = "-"
            MyDs.Tables("income").Rows.Add(r)


            cmd.CommandText = "select procedure_master_id as in_id,daily_procedure_name as in_Name,N'اذونات دفع' as 'Desc',-SUM(pay_value) as in_value from Procedure_Master pm,Money_Payables pr,shifts_details sh where pm.Procedure_Master_ID=pr.to_Procedure_Master_ID and pr.shift_Detail_id=sh.shift_Detail_id and pay_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "' group by daily_procedure_name,procedure_master_id"
            da.Fill(MyDs.Tables("income"))



            bsource.DataSource = MyDs
            bsource.DataMember = "Income"
            DataGridView1.DataSource = bsource
            DataGridView1.Columns("in_id").Visible = False
            DataGridView1.Columns("date").Visible = False
            DataGridView1.Columns("logo").Visible = False
            DataGridView1.Columns("shift_id").Visible = False
            DataGridView1.Columns("employee_id").Visible = False
            DataGridView1.Columns("employee_name").Visible = False


            DataGridView1.Columns("in_name").Width = 400
            DataGridView1.Columns("in_name").HeaderText = "الاسم"
            DataGridView1.Columns("desc").Width = 250
            DataGridView1.Columns("desc").HeaderText = "الوصف"
            DataGridView1.Columns("in_value").Width = 250
            DataGridView1.Columns("in_value").HeaderText = "القيمة"



        End If


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        rpt.SetDataSource(MyDs.Tables("income"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        If The_Type = "emp" Then
            rpt.SetParameterValue("Report_Type", "موظف - " & emp.SelectedValue & " - " & FromDate.Value.ToString("dd/MM/yyyy") & " - " & ToDate.Value.ToString("dd/MM/yyyy"))
        ElseIf The_Type = "shift" Then
            rpt.SetParameterValue("Report_Type", "ورديه - " & Type.Text)
        Else
            rpt.SetParameterValue("Report_Type", "تاريخ - " & FromDate.Value.ToString("dd/MM/yyyy") & " - " & ToDate.Value.ToString("dd/MM/yyyy"))
        End If
        CrystalReportViewer1.ReportSource = rpt
        TabControl1.SelectTab(1)
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


    Private Sub ByEmp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If byemp.Enabled = True Then
            emp.Enabled = True
            FromDate.Enabled = False
            Shift.Enabled = False
            ByShift.Enabled = False
        End If
    End Sub



    Private Sub InDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromDate.ValueChanged
        Try
            date1 = CDate(FromDate.Text)
            cls.RefreshData("select replace(employee_name + ' (" & FromDate.Value.ToString("dd/MM/yyyy") & ")' + N' من ' +isnull( Real_Start_Time,' ') + N' الى ' + isnull(Real_End_Time,' '),'?','') as employee_name,shift_Detail_id from query_Shifts where start_date='" & date1.ToString("MM/dd/yyyy") & "'", TblShifts)
            Shift.DataSource = TblShifts
            Shift.DisplayMember = "employee_Name"
            Shift.ValueMember = "shift_Detail_id"
        Catch
        End Try

    End Sub



    Private Sub byemp_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byemp.CheckedChanged
        If byemp.Checked = True Then
            emp.Enabled = True
            Shift.Enabled = False
            ByShift.Checked = False
        Else
            emp.Enabled = False
        End If
    End Sub


    Private Sub ByShift_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByShift.CheckStateChanged
        If ByShift.Checked = True Then
            Shift.Enabled = True
            emp.Enabled = False
            byemp.Checked = False
        Else
            Shift.Enabled = False
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim The_ID As Integer
        Dim Type As String
        Dim tblbills As New GeneralDataSet.BillsDataTable
        Try
            The_ID = DataGridView1.SelectedRows(0).Cells("in_id").Value
        Catch
        End Try
        Type = DataGridView1.SelectedRows(0).Cells("desc").Value.ToString
        If Type = "-" Then
            Type = DataGridView1.SelectedRows(0).Cells("in_name").Value.ToString
        End If

        If The_Type = "normal" Then
            If Type = "المبيعات" Then
                cls.RefreshData("select * from report_sales_header where bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_Sales_Header"))
                Bills.DataSource = MyDs.Tables("Report_Sales_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "sales"
                TT.Text = "فواتير المبيعات"
            ElseIf Type = "الاصناف المهلكه" Then
                cls.RefreshData("select * from REPORT_Dep_Header where bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_Dep_Header"))
                Bills.DataSource = MyDs.Tables("report_dep_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم المخزن"
                Bills.Columns(3).HeaderText = "اسم الموظف"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                ListType = "Dep"
                TT.Text = "اذونات الاهلاك"
            ElseIf Type = "المشتريات" Then
                cls.RefreshData("select * from report_purchase_Header where bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_purchase_header"))
                Bills.DataSource = MyDs.Tables("report_purchase_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "purchase"
                TT.Text = "فواتير المشتريات"
            ElseIf Type = "مرتجعات الموردين" Then
                cls.RefreshData("select * from report_return_v_Header where bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_return_v_Header"))
                Bills.DataSource = MyDs.Tables("report_return_v_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "ven_Ret"
                TT.Text = "فواتير مرتجعات الموردين"
            ElseIf Type = "مرتجعات العملاء" Then
                cls.RefreshData("select * from report_return_c_Header where bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_return_c_Header"))
                Bills.DataSource = MyDs.Tables("report_return_c_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "cust_ret"
                TT.Text = "فواتير مرتجعات العملاء"
            ElseIf Type = "جلسات خاصه" Then
                Dim rptpur As New RptSpecialSubscriptions
                MyDs.Tables("report_special_Subscriptions").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_Special_Subscriptions where special_Categories_id=" & The_ID & " and special_subscription_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_special_Subscriptions"))
                rptpur.SetDataSource(MyDs.Tables("report_special_Subscriptions"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            ElseIf Type = "اذونات استلام" Then
                Dim rptpur As New RptMasterRecord
                MyDs.Tables("masterrecord").Rows.Clear()
                cmd.CommandText = "select from_Procedure_Master_ID as procedure_master_id,daily_procedure_name,Rec_Desc as procedure_desc,Rec_Value as from_Balance,Rec_Date as procedure_Date  from Money_Receivables,Procedure_Master where Money_Receivables.from_Procedure_Master_ID=Procedure_Master.Procedure_Master_ID and from_procedure_master_id=" & The_ID & " and rec_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("masterrecord"))
                rptpur.SetDataSource(MyDs.Tables("masterrecord"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)

            ElseIf Type = "اذونات دفع" Then
                Dim rptpur As New RptMasterRecord
                MyDs.Tables("masterrecord").Rows.Clear()
                cmd.CommandText = "select To_Procedure_Master_ID as procedure_master_id,daily_procedure_name,pay_desc as procedure_desc,pay_value as to_Balance,pay_date as procedure_Date from Money_Payables,Procedure_Master where Money_Payables.To_Procedure_Master_ID=Procedure_Master.Procedure_Master_ID and to_procedure_master_id=" & The_ID & " and pay_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("masterrecord"))
                rptpur.SetDataSource(MyDs.Tables("masterrecord"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            Else
                Dim rptpur As New RptSubscriptionsDetails
                MyDs.Tables("report_subscriptions_details").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_subscriptions_details where subscription_id=" & The_ID & " and start_date between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_subscriptions_details"))
                rptpur.SetDataSource(MyDs.Tables("report_subscriptions_details"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            End If

        ElseIf The_Type = "shift" Then
            If Type = "المبيعات" Then
                cls.RefreshData("select * from report_sales_header where shift_Detail_id=" & sh_Emp_ID, MyDs.Tables("report_Sales_Header"))
                Bills.DataSource = MyDs.Tables("report_Sales_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False
                ListType = "sales"
                TT.Text = "فواتير المبيعات"
            ElseIf Type = "الاصناف المهلكه" Then
                cls.RefreshData("select * from report_Dep_Header where shift_detail_id=" & CurrentShiftId & " and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_dep_Header"))
                Bills.DataSource = MyDs.Tables("report_dep_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم المخزن"
                Bills.Columns(3).HeaderText = "اسم الموظف"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "Dep"
                TT.Text = "اذونات الاهلاك"
            ElseIf Type = "المشتريات" Then
                cls.RefreshData("select * from report_purchase_header where shift_detail_id=" & sh_Emp_ID, MyDs.Tables("report_purchase_Header"))
                Bills.DataSource = MyDs.Tables("report_purchase_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "purchase"
                TT.Text = "فواتير المشتريات"
            ElseIf Type = "مرتجعات الموردين" Then
                cls.RefreshData("select * from report_return_v_header where shift_detail_id=" & sh_Emp_ID, MyDs.Tables("report_return_v_Header"))
                Bills.DataSource = MyDs.Tables("report_return_v_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "ven_Ret"
                TT.Text = "فواتير مرتجعات الموردين"
            ElseIf Type = "مرتجعات العملاء" Then
                cls.RefreshData("select * from report_return_c_Header where shift_detail_id=" & sh_Emp_ID, MyDs.Tables("report_Return_C_Header"))
                Bills.DataSource = MyDs.Tables("report_return_c_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "cust_ret"
                TT.Text = "فواتير مرتجعات العملاء"
            ElseIf Type = "جلسات خاصه" Then
                Dim rptpur As New RptSpecialSubscriptions
                MyDs.Tables("report_special_Subscriptions").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_Special_Subscriptions where special_Categories_id=" & The_ID & " and shift_detail_id=" & sh_Emp_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_special_Subscriptions"))
                rptpur.SetDataSource(MyDs.Tables("report_special_Subscriptions"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            ElseIf Type = "اذونات استلام" Then
                Dim rptpur As New RptMasterRecord
                MyDs.Tables("masterrecord").Rows.Clear()
                cmd.CommandText = "select from_Procedure_Master_ID as procedure_master_id,daily_procedure_name,Rec_Desc as procedure_desc,Rec_Value as from_Balance,Rec_Date as procedure_Date  from Money_Receivables,Procedure_Master where Money_Receivables.from_Procedure_Master_ID=Procedure_Master.Procedure_Master_ID and from_procedure_master_id=" & The_ID & " and shift_detail_id=" & sh_Emp_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("masterrecord"))
                rptpur.SetDataSource(MyDs.Tables("masterrecord"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)

            ElseIf Type = "اذونات دفع" Then
                Dim rptpur As New RptMasterRecord
                MyDs.Tables("masterrecord").Rows.Clear()
                cmd.CommandText = "select To_Procedure_Master_ID as procedure_master_id,daily_procedure_name,pay_desc as procedure_desc,pay_value as to_Balance,pay_date as procedure_Date from Money_Payables,Procedure_Master where Money_Payables.To_Procedure_Master_ID=Procedure_Master.Procedure_Master_ID and to_procedure_master_id=" & The_ID & " and shift_detail_id=" & sh_Emp_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("masterrecord"))
                rptpur.SetDataSource(MyDs.Tables("masterrecord"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            Else
                Dim rptpur As New RptSubscriptionsDetails
                MyDs.Tables("report_subscriptions_details").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_subscriptions_details where subscription_id=" & The_ID & " and shift_detail_id=" & sh_Emp_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_subscriptions_details"))
                rptpur.SetDataSource(MyDs.Tables("report_subscriptions_details"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            End If


        ElseIf The_Type = "emp" Then


            If Type = "المبيعات" Then
                cls.RefreshData("select * from report_sales_header where employee_id=" & sh_Emp_ID & " and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_Sales_Header"))
                Bills.DataSource = MyDs.Tables("report_Sales_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False
                ListType = "sales"
                TT.Text = "فواتير المبيعات"
            ElseIf Type = "الاصناف المهلكه" Then
                cls.RefreshData("select * from report_Dep_Header where employee_id=" & sh_Emp_ID & " and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_dep_Header"))
                Bills.DataSource = MyDs.Tables("report_dep_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم المخزن"
                Bills.Columns(3).HeaderText = "اسم الموظف"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "Dep"
                TT.Text = "اذونات الاهلاك"
            ElseIf Type = "المشتريات" Then
                cls.RefreshData("select * from report_purchase_header where employee_id=" & sh_Emp_ID & " and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_purchase_Header"))
                Bills.DataSource = MyDs.Tables("report_purchase_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).HeaderText = "المدفوع"
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False
                Bills.Columns(8).Visible = False

                ListType = "purchase"
                TT.Text = "فواتير المشتريات"
            ElseIf Type = "مرتجعات الموردين" Then
                cls.RefreshData("select * from report_return_v_header where employee_id=" & sh_Emp_ID & " and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_return_v_Header"))
                Bills.DataSource = MyDs.Tables("report_return_v_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم المورد"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "ven_Ret"
                TT.Text = "فواتير مرتجعات الموردين"
            ElseIf Type = "مرتجعات العملاء" Then
                cls.RefreshData("select * from report_return_C_header where employee_id=" & sh_Emp_ID & " and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'", MyDs.Tables("report_return_c_Header"))
                Bills.DataSource = MyDs.Tables("report_return_c_Header")
                Bills.Columns(0).HeaderText = "رقم الفاتوره"
                Bills.Columns(1).HeaderText = "الوقت"
                Bills.Columns(2).HeaderText = "اسم الموظف"
                Bills.Columns(3).HeaderText = "اسم العميل"
                Bills.Columns(4).HeaderText = "الاجمالي"
                Bills.Columns(5).Visible = False
                Bills.Columns(6).Visible = False
                Bills.Columns(7).Visible = False

                ListType = "cust_ret"
                TT.Text = "فواتير مرتجعات العملاء"
            ElseIf Type = "جلسات خاصه" Then
                Dim rptpur As New RptSpecialSubscriptions
                MyDs.Tables("report_special_Subscriptions").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from shifts_details,report_Special_Subscriptions where shifts.details.shift_detail_id=report_special_subscriptions.shift_detail_id and special_Categories_id=" & The_ID & " and shifts_details.employee_id=" & sh_Emp_ID & " and bill_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_special_Subscriptions"))
                rptpur.SetDataSource(MyDs.Tables("report_special_Subscriptions"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            ElseIf Type = "اذونات استلام" Then
                Dim rptpur As New RptMasterRecord
                MyDs.Tables("masterrecord").Rows.Clear()
                cmd.CommandText = "select from_Procedure_Master_ID as procedure_master_id,daily_procedure_name,Rec_Desc as procedure_desc,Rec_Value as from_Balance,Rec_Date as procedure_Date  from Money_Receivables,Procedure_Master,shifts_details where shifts_details.shift_detail_id=money_receivables.shift_detail_id and Money_Receivables.from_Procedure_Master_ID=Procedure_Master.Procedure_Master_ID and from_procedure_master_id=" & The_ID & " and shifts_details.employee_id=" & sh_Emp_ID & " and rec_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("masterrecord"))
                rptpur.SetDataSource(MyDs.Tables("masterrecord"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)

            ElseIf Type = "اذونات دفع" Then
                Dim rptpur As New RptMasterRecord
                MyDs.Tables("masterrecord").Rows.Clear()
                cmd.CommandText = "select To_Procedure_Master_ID as procedure_master_id,daily_procedure_name,pay_desc as procedure_desc,pay_value as to_Balance,pay_date as procedure_Date from Money_Payables,Procedure_Master,shifts_details where shifts_details.shift_Detail_id=money_payables.shift_Detail_id and Money_Payables.To_Procedure_Master_ID=Procedure_Master.Procedure_Master_ID and to_procedure_master_id=" & The_ID & " and shifts_details.employee_id=" & sh_Emp_ID & " and pay_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("masterrecord"))
                rptpur.SetDataSource(MyDs.Tables("masterrecord"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            Else
                Dim rptpur As New RptSubscriptionsDetails
                MyDs.Tables("report_subscriptions_details").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_subscriptions_details where subscription_id=" & The_ID & " and employee_id=" & sh_Emp_ID & " and start_date  between '" & date1.ToString("MM/dd/yyyy") & "' and '" & date2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_subscriptions_details"))
                rptpur.SetDataSource(MyDs.Tables("report_subscriptions_details"))
                rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = rptpur
                TabControl1.SelectTab(1)
            End If

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If Bills.SelectedRows(0).Cells("bill_id").Value = Nothing Then
                Exit Sub
            End If
        Catch
            Exit Sub
        End Try

        If ListType = "sales" Then
            Dim rptpur As New RptSalesOrder
            MyDs.Tables("Report_Sales").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Sales where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Sales"))
            rptpur.SetDataSource(MyDs.Tables("Report_Sales"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)
        ElseIf ListType = "purchase" Then
            Dim rptpur As New RptPurchaseOrder
            MyDs.Tables("report_purchase").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_purchase where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_purchase"))
            rptpur.SetDataSource(MyDs.Tables("report_purchase"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)
        ElseIf ListType = "ven_Ret" Then
            Dim rptpur As New RptVendorReturns
            MyDs.Tables("report_vendors_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_vendors_Returns where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_vendors_Returns"))
            rptpur.SetDataSource(MyDs.Tables("report_vendors_Returns"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)
        ElseIf ListType = "cust_ret" Then
            Dim rptpur As New RptCustomerReturns
            MyDs.Tables("report_Customers_Returns").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_Customers_Returns where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_Customers_Returns"))
            rptpur.SetDataSource(MyDs.Tables("report_Customers_Returns"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)
        Else
            Dim rptpur As New RpDepItem
            MyDs.Tables("report_dep_items").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_dep_items where bill_id = " & Bills.SelectedRows(0).Cells("bill_id").Value
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("report_dep_items"))
            rptpur.SetDataSource(MyDs.Tables("report_dep_items"))
            rptpur.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rptpur
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub Button13_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseMove
        Button3.BackgroundImage = My.Resources._end
        Button3.ForeColor = Color.White

    End Sub

    Private Sub Button4_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseMove
        Button4.BackgroundImage = My.Resources._end
        Button4.ForeColor = Color.White
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black

    End Sub

    Private Sub Button4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Button4.BackgroundImage = My.Resources.enter
        Button4.ForeColor = Color.Black
    End Sub

End Class
