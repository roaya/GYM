Public Class FrmEmployees
    Dim TblEmps As New GeneralDataSet.Query_EmployeesDataTable
    Dim TblDepts As New GeneralDataSet.DepartmentsDataTable
    Dim TblJobs As New GeneralDataSet.JobsDataTable
    Dim RptEmps As New RptEmployee
    Dim RptVac As New RptVacations
    Dim RptRewards As New RptRewards
    Dim RptDiscounts As New RptDiscounts
    Dim RptCoaches As New RptCoaches
    Dim RptExtras As New RptEmployeesExtra
    Dim RptTasks As New RptEmployeesTasks
    Dim RptSalary As New RptPaySalary
    Dim RptAttendance As New RptEmployeesAttendance
    Dim RptEmpSalary As New RptEmpPayingSlip

    Dim d1, d2 As Date

    Dim Bsource As New BindingSource


    Private Sub FrmEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("Query_Employees")
        cls.RefreshData("select *,(select logo from app_preferences) as logo from jobs", TblJobs)
        cls.RefreshData("select *,(select logo from app_preferences) as logo from departments", TblDepts)


        Depts.DataSource = TblDepts
        Depts.DisplayMember = "department_Name"
        Depts.ValueMember = "department_id"

        Jobs.DataSource = TblJobs
        Jobs.DisplayMember = "job_title"
        Jobs.ValueMember = "job_id"


        Bsource.DataSource = MyDs
        Bsource.DataMember = "Query_employees"


        DataGridView1.DataSource = Bsource
        DataGridView1.Columns(0).HeaderText = "اسم الموظف"
        DataGridView1.Columns(1).HeaderText = "اسم الاداره"
        DataGridView1.Columns(2).HeaderText = "الوظيفه"
        DataGridView1.Columns(3).HeaderText = "الباركود"
        DataGridView1.Columns(4).HeaderText = "التليفون"
        DataGridView1.Columns(5).HeaderText = "الموبايل"
        DataGridView1.Columns(6).HeaderText = "المؤهل الدراسي"
        DataGridView1.Columns(7).HeaderText = "المرتب الأساسي"
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False
        DataGridView1.Columns(10).Visible = False
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(12).Visible = False
        DataGridView1.Columns(13).Visible = False
        DataGridView1.Columns(14).Visible = False
        DataGridView1.Columns(15).Visible = False
        DataGridView1.Columns(16).Visible = False

    End Sub


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles All.CheckedChanged
        If All.Checked = True Then
            Depts.Enabled = False
            Jobs.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coaches.CheckedChanged
        If Coaches.Checked = True Then
            Depts.Enabled = False
            Jobs.Enabled = False
        End If
    End Sub


    Private Sub bydept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bydept.CheckedChanged
        If bydept.Enabled = True Then
            Depts.Enabled = True
            Jobs.Enabled = False
        End If
    End Sub

    Private Sub byjob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byjob.CheckedChanged
        If byjob.Checked = True Then
            Depts.Enabled = False
            Jobs.Enabled = True
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If All.Checked = True Then
            Bsource.Filter = ""
        ElseIf Coaches.Checked = True Then
            Bsource.Filter = "job_id=1"
        ElseIf bydept.Checked = True Then
            If Depts.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الاداره")
                Exit Sub
            End If
            Bsource.Filter = "department_id=" & Depts.SelectedValue
        ElseIf byjob.Checked = True Then
            If Jobs.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الوظيفه")
                Exit Sub
            End If
            Bsource.Filter = "job_id=" & Jobs.SelectedValue
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees"
        da.SelectCommand = cmd
        MyDs.Tables("query_employees").Clear()
        da.Fill(MyDs.Tables("query_employees"))

        If All.Checked = True Then

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees").Clear()
            da.Fill(MyDs.Tables("query_employees"))

        ElseIf Coaches.Checked = True Then

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees where job_id=1"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees").Clear()
            da.Fill(MyDs.Tables("query_employees"))

        ElseIf bydept.Checked = True Then
            If Depts.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الاداره")
                Exit Sub
            End If

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees where department_id=" & Depts.SelectedValue
            da.SelectCommand = cmd
            MyDs.Tables("query_employees").Clear()
            da.Fill(MyDs.Tables("query_employees"))

        ElseIf byjob.Checked = True Then
            If Jobs.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الوظيفه")
                Exit Sub
            End If

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees where job_id=" & Jobs.SelectedValue
            da.SelectCommand = cmd
            MyDs.Tables("query_employees").Clear()
            da.Fill(MyDs.Tables("query_employees"))


        End If



        RptEmps.SetDataSource(MyDs.Tables("query_employees"))
        RptEmps.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer2.ReportSource = RptEmps
        TabControl1.SelectTab(1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = fromdate.Text
        d2 = todate.Text
        If fromdate.Text = "" Or todate.Text = "" Then
            cls.MsgExclamation("برجاء اختيار الفتره")
            Exit Sub
        End If

        If AllEmployees.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees_Vacation where from_date>='" & d1.ToString("MM/dd/yyyy") & "' and to_date<='" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees_Vacation").Clear()
            da.Fill(MyDs.Tables("query_employees_Vacation"))
            RptVac.SetDataSource(MyDs.Tables("query_employees_Vacation"))
            RptVac.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptVac
            TabControl1.SelectTab(1)
            Exit Sub
        End If

        Try
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees_Vacation where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and from_date>='" & d1.ToString("MM/dd/yyyy") & "' and to_date<='" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees_Vacation").Clear()
            da.Fill(MyDs.Tables("query_employees_Vacation"))
            RptVac.SetDataSource(MyDs.Tables("query_employees_Vacation"))
            RptVac.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptVac
            TabControl1.SelectTab(1)
        Catch
            cls.MsgExclamation("برجاء التأكد من اختيار موظف")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        d1 = fromdate.Text
        d2 = todate.Text
        If fromdate.Text = "" Or todate.Text = "" Then
            cls.MsgExclamation("برجاء اختيار الفتره")
            Exit Sub
        End If

        If AllEmployees.Checked = True Then

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees_rewards where reward_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees_rewards").Clear()
            da.Fill(MyDs.Tables("query_employees_rewards"))
            RptRewards.SetDataSource(MyDs.Tables("query_employees_rewards"))
            RptRewards.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptRewards
            TabControl1.SelectTab(1)
            Exit Sub
        End If

        Try

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees_rewards where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and reward_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees_rewards").Clear()
            da.Fill(MyDs.Tables("query_employees_rewards"))
            RptRewards.SetDataSource(MyDs.Tables("query_employees_rewards"))
            RptRewards.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptRewards
            TabControl1.SelectTab(1)
        Catch
            cls.MsgExclamation("برجاء التأكد من اختيار موظف")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        d1 = fromdate.Text
        d2 = todate.Text
        If fromdate.Text = "" Or todate.Text = "" Then
            cls.MsgExclamation("برجاء اختيار الفتره")
            Exit Sub
        End If

        If AllEmployees.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_Employees_Discounts where discount_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_Employees_Discounts").Clear()
            da.Fill(MyDs.Tables("query_Employees_Discounts"))
            RptDiscounts.SetDataSource(MyDs.Tables("query_Employees_Discounts"))
            RptDiscounts.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptDiscounts
            TabControl1.SelectTab(1)
            Exit Sub
        End If
        Try

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_Employees_Discounts where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and discount_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_Employees_Discounts").Clear()
            da.Fill(MyDs.Tables("query_Employees_Discounts"))
            RptDiscounts.SetDataSource(MyDs.Tables("query_Employees_Discounts"))
            RptDiscounts.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptDiscounts
            TabControl1.SelectTab(1)
        Catch
            cls.MsgExclamation("برجاء التأكد من اختيار موظف")
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        d1 = fromdate.Text
        d2 = todate.Text
        If fromdate.Text = "" Or todate.Text = "" Then
            cls.MsgExclamation("برجاء اختيار الفتره")
            Exit Sub
        End If

        If AllEmployees.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Employees_Extra where extra_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("Report_Employees_Extra").Clear()
            da.Fill(MyDs.Tables("Report_Employees_Extra"))
            RptExtras.SetDataSource(MyDs.Tables("Report_Employees_Extra"))
            RptExtras.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptExtras
            TabControl1.SelectTab(1)
            Exit Sub
        End If
        Try
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Employees_Extra where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and extra_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("Report_Employees_Extra").Clear()
            da.Fill(MyDs.Tables("Report_Employees_Extra"))
            RptExtras.SetDataSource(MyDs.Tables("Report_Employees_Extra"))
            RptExtras.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptExtras
            TabControl1.SelectTab(1)
        Catch
            cls.MsgExclamation("برجاء التأكد من اختيار موظف")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        d1 = fromdate.Text
        d2 = todate.Text
        If fromdate.Text = "" Or todate.Text = "" Then
            cls.MsgExclamation("برجاء اختيار الفتره")
            Exit Sub
        End If

        If AllEmployees.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees_tasks where task_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees_tasks").Clear()
            da.Fill(MyDs.Tables("query_employees_tasks"))
            RptTasks.SetDataSource(MyDs.Tables("query_employees_tasks"))
            RptTasks.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptTasks
            TabControl1.SelectTab(1)
            Exit Sub
        End If

        Try

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_employees_tasks where to_employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and task_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("query_employees_tasks").Clear()
            da.Fill(MyDs.Tables("query_employees_tasks"))
            RptTasks.SetDataSource(MyDs.Tables("query_employees_tasks"))
            RptTasks.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptTasks
            TabControl1.SelectTab(1)
        Catch
            cls.MsgExclamation("برجاء التأكد من اختيار موظف")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        d1 = fromdate.Text
        d2 = todate.Text
        If fromdate.Text = "" Or todate.Text = "" Then
            cls.MsgExclamation("برجاء اختيار الفتره")
            Exit Sub
        End If

        If AllEmployees.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_Employees_attendance where attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("report_Employees_attendance").Clear()
            da.Fill(MyDs.Tables("report_Employees_attendance"))
            RptAttendance.SetDataSource(MyDs.Tables("report_Employees_attendance"))
            RptAttendance.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptAttendance
            TabControl1.SelectTab(1)
            Exit Sub
        End If
        Try

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_Employees_attendance where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("report_Employees_attendance").Clear()
            da.Fill(MyDs.Tables("report_Employees_attendance"))
            RptAttendance.SetDataSource(MyDs.Tables("report_Employees_attendance"))
            RptAttendance.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptAttendance
            TabControl1.SelectTab(1)
        Catch
            cls.MsgExclamation("برجاء التأكد من اختيار موظف")
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        d1 = fromdate.Text
        d2 = todate.Text
        If fromdate.Text = "" Or todate.Text = "" Then
            cls.MsgExclamation("برجاء اختيار الفتره")
            Exit Sub
        End If

        If AllEmployees.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_pay_salary where pay_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("report_pay_salary").Clear()
            da.Fill(MyDs.Tables("report_pay_salary"))
            RptSalary.SetDataSource(MyDs.Tables("report_pay_salary"))
            RptSalary.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptSalary
            TabControl1.SelectTab(1)
            Exit Sub
        End If
        Try

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_pay_salary where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and pay_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("report_pay_salary").Clear()
            da.Fill(MyDs.Tables("report_pay_salary"))
            RptEmpSalary.SetDataSource(MyDs.Tables("report_pay_salary"))
            RptEmpSalary.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RptEmpSalary.SetParameterValue("tod", todate.Text)
            RptEmpSalary.SetParameterValue("fromd", fromdate.Text)
            CrystalReportViewer2.ReportSource = RptEmpSalary
            TabControl1.SelectTab(1)
        Catch
            cls.MsgExclamation("برجاء التأكد من اختيار موظف")
        End Try
    End Sub




    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        d1 = fromdate.Text
        d2 = todate.Text
        Try
            If DataGridView1.SelectedRows(0).Cells("job_id").Value <> 1 Then
                Exit Sub
            End If
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_Employees where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value
            da.SelectCommand = cmd
            MyDs.Tables("query_Coaches").Clear()
            da.Fill(MyDs.Tables("query_Coaches"))
            RptCoaches.SetDataSource(MyDs.Tables("query_Coaches"))
            RptCoaches.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RptCoaches.SetParameterValue("to_d", todate.Text)
            RptCoaches.SetParameterValue("from_d", fromdate.Text)

            cmd.CommandText = "select count(*) from customers_Attendance where coach_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoaches.SetParameterValue("P_Customers", cmd.ExecuteScalar)

            cmd.CommandText = "select count(*) from special_Subscriptions where trainer_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and special_Subscription_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoaches.SetParameterValue("P_Special", cmd.ExecuteScalar)

            cmd.CommandText = "select isnull(sum(hours_Diff)/60,0) from Attendance where employee_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoaches.SetParameterValue("P_Attendance", cmd.ExecuteScalar)

            cmd.CommandText = "select count(*) from subscriptions_details where subscription_type=N'خاص' and coach_id=" & DataGridView1.SelectedRows(0).Cells("employee_id").Value & " and start_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoaches.SetParameterValue("P_Subscriptions", cmd.ExecuteScalar)

            CrystalReportViewer2.ReportSource = RptCoaches
            TabControl1.SelectTab(1)
        Catch
        End Try
    End Sub
End Class