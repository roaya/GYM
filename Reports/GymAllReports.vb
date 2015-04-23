Public Class GymAllReports
    Dim rpt0 As New RptSubscriptions
    Dim rptsp As New RptSpecialCategories
    Dim rpt1 As New RptAllSubscriptions
    Dim rpt2 As New RptAllSpecial
    Dim rpt3 As New RptSubscriptionsDetails
    Dim rpt4 As New RptCustomersAttendance
    Dim rpt As New RptEmployeesAttendance
    Dim RptSpSub As New RptSpecialSubscriptions
    Dim rptprintsubsc As New RptSubscriptionPrint
    Dim d1, d2 As Date
    Dim type As String
    Dim INDEX As Integer = 0
    Dim bsource As New BindingSource
    Dim TblCust As New GeneralDataSet.CustomersDataTable
    Dim tblEmps As New GeneralDataSet.EmployeesDataTable
    Dim tblsubs As New GeneralDataSet.SubscriptionsDataTable
    Dim tblsubscat As New GeneralDataSet.Subscriptions_CategoriesDataTable
    Dim tblspec As New GeneralDataSet.Special_CategoriesDataTable
    Dim tblcoach As New GeneralDataSet.EmployeesDataTable
    Dim tbldepts As New GeneralDataSet.DepartmentsDataTable
    Dim tbljobs As New GeneralDataSet.JobsDataTable
    Dim tblPrintReport As New GeneralDataSet.Report_Customers_SubscriptionsDataTable

    Private Sub GymAllReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from customers", TblCust)
        cls.RefreshData("select * from employees", tblEmps)
        cls.RefreshData("select * from employees where job_id=1", tblcoach)
        cls.RefreshData("select * from departments", tbldepts)
        cls.RefreshData("select * from jobs", tbljobs)
        cls.RefreshData("select * from subscriptions_categories", tblsubscat)
        cls.RefreshData("select * from subscriptions", tblsubs)
        cls.RefreshData("select * from special_categories", tblspec)
        'cls.RefreshData("select * from customers", TblCust)



        Type0.DataSource = tblsubscat
        Type0.DisplayMember = "category_name"
        Type0.ValueMember = "category_id"

        cat1.DataSource = tblsubscat
        cat1.DisplayMember = "category_name"
        cat1.ValueMember = "category_id"

        subsc1.DataSource = tblsubs
        subsc1.DisplayMember = "subscription_name"
        subsc1.ValueMember = "subscription_id"



        cat2.DataSource = tblspec
        cat2.DisplayMember = "category_name"
        cat2.ValueMember = "special_categories_id"



        Custid3.DataSource = TblCust
        Custid3.DisplayMember = "customer_name"
        Custid3.ValueMember = "customer_id"



        EmpID3.DataSource = tblEmps
        EmpID3.DisplayMember = "EMPLOYEE_NAME"
        EmpID3.ValueMember = "EMPLOYEE_ID"


        coach3.DataSource = tblcoach
        coach3.DisplayMember = "EMPLOYEE_NAME"
        coach3.ValueMember = "EMPLOYEE_ID"



        SubscriptionID3.DataSource = tblsubs
        SubscriptionID3.DisplayMember = "SUBSCRIPTION_NAME"
        SubscriptionID3.ValueMember = "SUBSCRIPTION_id"




        CategoryID3.DataSource = tblsubscat
        CategoryID3.DisplayMember = "category_name"
        CategoryID3.ValueMember = "category_id"



        Employee.DataSource = tblEmps
        Employee.DisplayMember = "EMPLOYEE_NAME"
        Employee.ValueMember = "EMPLOYEE_ID"



        dept.DataSource = tbldepts
        dept.DisplayMember = "DEPARTMENT_nAME"
        dept.ValueMember = "DEPARTMENT_ID"



        job.DataSource = tbljobs
        job.DisplayMember = "JOB_TITLE"
        job.ValueMember = "job_id"



        subsc.DataSource = tblsubs
        subsc.DisplayMember = "SUBSCRIPTION_nAME"
        subsc.ValueMember = "SUBSCRIPTION_ID"

        emp.DataSource = tblcoach
        emp.DisplayMember = "EMPLOYEE_NAME"
        emp.ValueMember = "EMPLOYEE_ID"

        CustID.DataSource = TblCust
        CustID.DisplayMember = "customer_name"
        CustID.ValueMember = "customer_id"


        Customers.DataSource = TblCust
        Customers.DisplayMember = "customer_name"
        Customers.ValueMember = "customer_id"

        bsource.DataSource = MyDs
        bsource.DataMember = "Report_Customers_Subscriptions"

        DataGridView1.DataSource = bsource
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).HeaderText = "بند الاشتراك"
        DataGridView1.Columns(4).Width = 150
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).HeaderText = "اسم الاشتراك"
        DataGridView1.Columns(6).Width = 200
        DataGridView1.Columns(7).HeaderText = "نوع الاشتراك"
        DataGridView1.Columns(8).HeaderText = "ثمن الاشتراك"
        DataGridView1.Columns(9).HeaderText = "المدفوع مقدما"
        DataGridView1.Columns(10).HeaderText = "المتبقي"
        DataGridView1.Columns(11).HeaderText = "سعر الدفع"
        DataGridView1.Columns(12).HeaderText = "تاريخ الدفع"
        DataGridView1.Columns(13).Visible = False


    End Sub
    '=======================================================FrmReportSubscriptions================
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 8
        If byCategory0.Checked = True Then

            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_subscriptions where category_id=" & Type0.SelectedValue
            da.SelectCommand = cmd
            MyDs.Tables("report_subscriptions").Clear()
            da.Fill(MyDs.Tables("report_subscriptions"))
            rpt0.SetDataSource(MyDs.Tables("report_subscriptions"))
            rpt0.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = rpt0
        ElseIf ByAll0.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_subscriptions"
            da.SelectCommand = cmd
            MyDs.Tables("report_subscriptions").Clear()
            da.Fill(MyDs.Tables("report_subscriptions"))
            rpt0.SetDataSource(MyDs.Tables("report_subscriptions"))
            rpt0.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = rpt0
        ElseIf SpecialSubs0.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from special_categories"
            da.SelectCommand = cmd
            MyDs.Tables("special_categories").Clear()
            da.Fill(MyDs.Tables("special_categories"))
            rptsp.SetDataSource(MyDs.Tables("special_categories"))
            rptsp.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = rptsp
        End If

    End Sub
    Private Sub ByAll0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByAll0.CheckedChanged
        If ByAll0.Checked = True Then
            Type0.Enabled = False
        End If
    End Sub

    Private Sub byCategory0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byCategory0.CheckedChanged
        If byCategory0.Checked = True Then
            Type0.Enabled = True
        End If
    End Sub

    Private Sub SpecialSubs0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecialSubs0.CheckedChanged
        If SpecialSubs0.Checked = True Then
            Type0.Enabled = False
        End If
    End Sub
    '=======================================================================FrmReportAllSubscriptions========================
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        d1 = CDate(fromdate1.Text)
        d2 = CDate(todate1.Text)
        MyDs.Tables("report_all_subscriptions").Rows.Clear()
        If byall1.Checked = True Then
            cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_subscriptions where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        ElseIf bycat1.Checked = True Then

            If cat1.SelectedValue = Nothing Then
                MsgBox("من فضلك اختر اسم البند")
                Exit Sub
            Else
                cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_subscriptions where category_id=" & cat1.SelectedValue & " and  start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            End If


        ElseIf bysub1.Checked = True Then
            If subsc1.SelectedValue = Nothing Then
                MsgBox("من فضلك اختر اسم الاشتراك")
                Exit Sub
            Else
                cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_subscriptions where subscription_id=" & subsc1.SelectedValue & " and  start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            End If

        Else
            If type1.SelectedValue = Nothing Then
                MsgBox("من فضلك اختر نوع الاشتراك")
                Exit Sub
            Else
                cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_subscriptions where subscription_type=N'" & type1.Text & "' and  start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            End If

        End If
        da.Fill(MyDs.Tables("report_all_subscriptions"))
        rpt1.SetDataSource(MyDs.Tables("report_all_subscriptions"))
        rpt1.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer2.ReportSource = rpt1
        TabControl1.SelectTab(8)
    End Sub

    Private Sub bysub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bysub1.CheckedChanged
        If bysub1.Checked = True Then
            cat1.Enabled = False
            type1.Enabled = False
            subsc1.Enabled = True
        End If
    End Sub

    Private Sub bytype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bytype1.CheckedChanged
        If bytype1.Checked = True Then
            cat1.Enabled = False
            type1.Enabled = True
            subsc1.Enabled = False
        End If
    End Sub
    Private Sub Rada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall1.CheckedChanged
        If byall1.Checked = True Then
            cat1.Enabled = False
            type1.Enabled = False
            subsc1.Enabled = False
        End If
    End Sub

    Private Sub RadHal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycat1.CheckedChanged
        If bycat1.Checked = True Then
            cat1.Enabled = True
            type1.Enabled = False
            subsc1.Enabled = False
        End If
    End Sub
    '=======================================================================FrmReportAllSpecialSubscriptions=========================

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        d1 = CDate(fromdate2.Text)
        d2 = CDate(todate2.Text)
        MyDs.Tables("report_all_special_Subscriptions").Rows.Clear()
        If byall2.Checked = True Then
            cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_special_Subscriptions where Special_Subscription_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        Else : bycat2.Checked = True

            If cat2.SelectedValue = Nothing Then
                MsgBox("من فضلك اختر اسم البند")
                Exit Sub
            Else
                cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from report_all_special_Subscriptions where special_Categories_id=" & cat2.SelectedValue & " and  Special_Subscription_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            End If
        End If
        da.Fill(MyDs.Tables("report_all_special_Subscriptions"))
        rpt2.SetDataSource(MyDs.Tables("report_all_special_Subscriptions"))
        rpt2.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer2.ReportSource = rpt2
        TabControl1.SelectTab(8)
    End Sub
    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall2.CheckedChanged, byall1.CheckedChanged
        If byall2.Checked = True Then
            cat2.Enabled = False
        End If
    End Sub
    Private Sub RadHall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycat2.CheckedChanged, bycat1.CheckedChanged
        If bycat2.Checked = True Then
            cat2.Enabled = True
        End If
    End Sub
    '=====================================================================FrmSubscriptions_details

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        d1 = CDate(fromdate3.Text)
        d2 = CDate(todate3.Text)
        If Open.Checked = True Then
            type = "مفتوحه"
        ElseIf Closed.Checked = True Then
            type = "مغلقه"
        ElseIf Ret.Checked = True Then
            type = "مرتجع"
        Else
            type = "All"
        End If

        MyDs.Tables("Report_Subscriptions_Details").Rows.Clear()

        If fromdate3.Value = Nothing Or todate3.Value = Nothing Then
            MsgBox("برجاء ادخل الفتره")
            Exit Sub
        End If

        If type <> "All" Then
            If RadAll.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"

            ElseIf RadCust.Checked = True Then
                If Custid3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم العميل")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where Customer_ID= " & Custid3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"

                End If



            ElseIf Rademp.Checked = True Then
                If EmpID3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الموظف")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where employee_id= " & EmpID3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"

                End If



            ElseIf RadCoach.Checked = True Then
                If coach3.SelectedValue = Nothing Then
                    MsgBox("برجاء ادخل اسم الموظف")
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where coach_id= " & coach3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"
                End If


            ElseIf RadSub.Enabled = True Then
                If SubscriptionID3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where subscription_id= " & SubscriptionID3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"

                End If


            ElseIf RadCategory.Checked = True Then
                If CategoryID3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر نوع الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where category_id= " & CategoryID3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"
                End If

            End If
        Else


            If RadAll.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

            ElseIf RadCust.Checked = True Then
                If Custid3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم العميل")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where Customer_ID= " & Custid3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

                End If



            ElseIf Rademp.Checked = True Then
                If EmpID3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الموظف")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where employee_id= " & EmpID3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

                End If



            ElseIf RadCoach.Checked = True Then
                If coach3.SelectedValue = Nothing Then
                    MsgBox("برجاء ادخل اسم الموظف")
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where coach_id= " & coach3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                End If


            ElseIf RadSub.Enabled = True Then
                If SubscriptionID3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where subscription_id= " & SubscriptionID3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

                End If


            ElseIf RadCategory.Checked = True Then
                If CategoryID3.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر نوع الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where category_id= " & CategoryID3.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                End If

            End If


        End If


        da.Fill(MyDs.Tables("Report_Subscriptions_Details"))
        rpt3.SetDataSource(MyDs.Tables("Report_Subscriptions_Details"))
        rpt3.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer2.ReportSource = rpt3
        TabControl1.SelectTab(8)
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadAll.CheckedChanged
        If RadAll.Checked = True Then
            Custid3.Enabled = False
            EmpID3.Enabled = False
            coach3.Enabled = False
            SubscriptionID3.Enabled = False
            CategoryID3.Enabled = False
        End If
    End Sub

    Private Sub RadCoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCoach.CheckedChanged
        If RadCoach.Checked = True Then
            Custid3.Enabled = False
            EmpID3.Enabled = False
            coach3.Enabled = True
            SubscriptionID3.Enabled = False
            CategoryID3.Enabled = False
        End If

    End Sub


    Private Sub RadCustheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCust.CheckedChanged
        If RadCust.Checked = True Then
            Custid3.Enabled = True
            EmpID3.Enabled = False
            coach3.Enabled = False
            SubscriptionID3.Enabled = False
            CategoryID3.Enabled = False
        End If
    End Sub

    Private Sub Rademp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rademp.CheckedChanged
        If Rademp.Checked = True Then
            Custid3.Enabled = False
            EmpID3.Enabled = True
            coach3.Enabled = False
            SubscriptionID3.Enabled = False
            CategoryID3.Enabled = False
        End If
    End Sub

    Private Sub RadSub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadSub.CheckedChanged
        If RadSub.Checked = True Then
            Custid3.Enabled = False
            EmpID3.Enabled = False
            coach3.Enabled = False
            SubscriptionID3.Enabled = True
            CategoryID3.Enabled = False
        End If
    End Sub

    Private Sub RadCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCategory.CheckedChanged
        If RadCategory.Checked = True Then
            Custid3.Enabled = False
            EmpID3.Enabled = False
            coach3.Enabled = False
            SubscriptionID3.Enabled = False
            CategoryID3.Enabled = True
        End If
    End Sub
    '=========================================================FrmSpecialSubscriptions===============================
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click

        If DateTimePicker3.Value = Nothing Or DateTimePicker4.Value = Nothing Then
            cls.MsgInfo("من فضلك ادخل الفتره", "")
        Else
            MyDs.Tables("report_special_subscriptions").Rows.Clear()
            d1 = CDate(DateTimePicker3.Text)
            d2 = CDate(DateTimePicker4.Text)

            If all.Checked = True Then

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & d1.ToString("MM/dd/yyyy") & "'  and   '" & d2.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))

            ElseIf bycust.Checked = True Then
                If cust.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء قم بادخال اسم العميل")
                    Exit Sub
                End If

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & d1.ToString("MM/dd/yyyy") & "'  and   '" & d2.ToString("MM/dd/yyyy") & "' and customer_id = " & cust.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))

            ElseIf bytrainer.Checked = True Then
                If coach.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء قم بادخال اسم المدرب")
                    Exit Sub
                End If

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & d1.ToString("MM/dd/yyyy") & "'  and   '" & d2.ToString("MM/dd/yyyy") & "' and trainer_id = " & coach.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))

            ElseIf byspecial.Checked = True Then

                If specsubsc.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء قم بادخال نوع الجلسه")
                    Exit Sub
                End If

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & d1.ToString("MM/dd/yyyy") & "'  and   '" & d2.ToString("MM/dd/yyyy") & "' and custspecial_categories_id = " & specsubsc.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))
            End If
        End If
        RptSpSub.SetDataSource(MyDs.Tables("report_Special_subscriptions"))
        RptSpSub.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer2.ReportSource = RptSpSub
        TabControl1.SelectTab(8)

    End Sub



    Private Sub all_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles all.CheckedChanged
        If all.Checked = True Then
            cust.Enabled = False
            coach.Enabled = False
            specsubsc.Enabled = False
        End If
    End Sub

    Private Sub bycust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycust.CheckedChanged
        If bycust.Checked = True Then
            cust.Enabled = True
            coach.Enabled = False
            specsubsc.Enabled = False
        End If
    End Sub

    Private Sub bytrainer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bytrainer.CheckedChanged
        If bytrainer.Checked = True Then
            cust.Enabled = False
            coach.Enabled = True
            specsubsc.Enabled = False
        End If
    End Sub

    Private Sub byspecial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byspecial.CheckedChanged
        If byspecial.Checked = True Then
            cust.Enabled = False
            coach.Enabled = False
            specsubsc.Enabled = True
        End If
    End Sub




    '=========================================================ReportEmpAttendance===================================




    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        TabControl1.SelectedIndex = 8
        Dim tod As Date
        Dim fromd As Date
        tod = ToDate.Text
        fromd = FromDate.Text

        If attended_emps.Checked = False Then

            If byall.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt
            ElseIf byemp.Checked = True Then

                If Employee.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الموظف")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where employee_id=" & Employee.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt
            ElseIf byjob.Checked = True Then
                If job.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الوظيفه")
                End If

                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where job_id=" & job.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt

            Else
                If dept.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الاداره")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where department_id=" & dept.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_employees_attendance").Clear()
                da.Fill(MyDs.Tables("report_employees_attendance"))
                rpt.SetDataSource(MyDs.Tables("report_employees_attendance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt
            End If
        Else
            If byall.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt
            ElseIf byemp.Checked = True Then
                If Employee.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الموظف")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where employee_id=" & Employee.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt
            ElseIf byjob.Checked = True Then
                If job.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الوظيفه")
                End If

                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where job_id=" & job.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt

            Else

                If dept.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الاداره")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where department_id=" & dept.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_employees_attendance").Clear()
                da.Fill(MyDs.Tables("report_employees_attendance"))
                rpt.SetDataSource(MyDs.Tables("report_employees_attendance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt
            End If
        End If

    End Sub
    Private Sub byemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byemp.CheckedChanged
        If byemp.Checked = True Then
            Employee.Enabled = True
            dept.Enabled = False
            job.Enabled = False
        End If
    End Sub

    Private Sub bydept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bydept.CheckedChanged
        If bydept.Checked = True Then
            Employee.Enabled = False
            dept.Enabled = True
            job.Enabled = False
        End If
    End Sub

    Private Sub byjob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byjob.CheckedChanged
        If byjob.Checked = True Then
            Employee.Enabled = False
            dept.Enabled = False
            job.Enabled = True
        End If
    End Sub
    Private Sub byall_eckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall.CheckedChanged
        If byall.Checked = True Then
            Employee.Enabled = False
            dept.Enabled = False
            job.Enabled = False
        End If
    End Sub
    '==============================================================================FrmCustomersAttendance


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        d1 = CDate(DateTimePicker1.Text)
        d2 = CDate(DateTimePicker2.Text)
        MyDs.Tables("Report_customers_attendance").Rows.Clear()

        If BySubsc.Checked = False Then
            If allcusts.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by Attend_Date"
                da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                rpt4.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                rpt4.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt4
                TabControl1.SelectTab(8)
            ElseIf bycustname.Checked = True Then
                If CustID.Text = "" Then
                    MsgBox("من فضلك اختر اسم العميل")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where customer_Id= " & CustID.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    CrystalReportViewer2.ReportSource = rpt4
                    TabControl1.SelectTab(8)
                End If
            ElseIf bycoach.Checked = True Then
                If emp.Text = "" Then
                    MsgBox("من فضلك اختر اسم المدرب")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where coach_id= " & emp.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    CrystalReportViewer2.ReportSource = rpt4
                    TabControl1.SelectTab(8)
                End If

            End If
        Else
            If subsc.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الاشتراك")
                Exit Sub
            End If


            If allcusts.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id=" & subsc.SelectedValue & " order by Attend_Date"
                da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                rpt4.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                rpt4.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer2.ReportSource = rpt4
                TabControl1.SelectTab(8)
            ElseIf bycustname.Checked = True Then
                If CustID.Text = "" Then
                    MsgBox("من فضلك اختر اسم العميل")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where customer_Id= " & CustID.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id=" & subsc.SelectedValue & " order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    CrystalReportViewer2.ReportSource = rpt4
                    TabControl1.SelectTab(8)
                End If
            ElseIf bycoach.Checked = True Then
                If emp.Text = "" Then
                    MsgBox("من فضلك اختر اسم المدرب")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where coach_id= " & emp.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id=" & subsc.SelectedValue & "order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt4.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    CrystalReportViewer2.ReportSource = rpt4
                    TabControl1.SelectTab(8)
                End If

            End If
        End If
    End Sub

    Private Sub BySubsc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BySubsc.CheckedChanged
        If BySubsc.Checked = True Then
            subsc.Enabled = True
        Else
            subsc.Enabled = False
        End If
    End Sub

    Private Sub byall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allcusts.CheckedChanged
        If byall.Checked = True Then
            emp.Enabled = False
            CustID.Enabled = False
        End If
    End Sub

    Private Sub RadCust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycustname.CheckedChanged
        If bycustname.Checked = True Then
            emp.Enabled = False
            CustID.Enabled = True
        End If
    End Sub

    Private Sub bycoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycoach.CheckedChanged
        If bycoach.Checked = True Then
            emp.Enabled = True
            CustID.Enabled = False
        End If
    End Sub
    '=======================================================================================PrintSubscReport=========================





    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Try
            MyDs.Tables("Report_Customers_Subscriptions").Rows.Clear()
            cmd.CommandText = "select * from Report_Customers_Subscriptions order by start_date desc"
            da.Fill(MyDs.Tables("Report_Customers_Subscriptions"))
            bsource.Filter = "customer_id=" & Customers.SelectedValue
            DataGridView1.DataSource = bsource
        Catch
            cls.MsgExclamation("هذا العميل غير موجود برجاء اعادة الاختيار")
        End Try
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Try
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscription_Print where Subscription_Detail_id=" & DataGridView1.SelectedRows(0).Cells("subscription_detail_id").Value
            da.SelectCommand = cmd
            MyDs.Tables("Report_Subscription_Print").Clear()
            da.Fill(MyDs.Tables("Report_Subscription_Print"))
            rptprintsubsc.SetDataSource(MyDs.Tables("Report_Subscription_Print"))
            rptprintsubsc.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = rptprintsubsc
            TabControl1.SelectTab(8)
        Catch
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex <> 8 Then
            INDEX = TabControl1.SelectedIndex
        End If

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        TabControl1.SelectedIndex = INDEX
    End Sub







    Private Sub button1_mousemove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button14.MouseMove
        Button14.BackgroundImage = My.Resources._end
        Button14.ForeColor = Color.White
    End Sub

    Private Sub Button3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button15.MouseMove
        Button15.BackgroundImage = My.Resources._end
        Button15.ForeColor = Color.White

    End Sub

    Private Sub Button4_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button16.MouseMove
        Button16.BackgroundImage = My.Resources._end
        Button16.ForeColor = Color.White
    End Sub



    Private Sub Button5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button9.MouseMove
        Button9.BackgroundImage = My.Resources._end
        Button9.ForeColor = Color.White

    End Sub

    Private Sub Button6_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button7.MouseMove
        Button7.BackgroundImage = My.Resources._end
        Button7.ForeColor = Color.White
    End Sub



    Private Sub Button17_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button6.MouseMove
        Button6.BackgroundImage = My.Resources._end
        Button6.ForeColor = Color.White

    End Sub

    Private Sub Button8_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseMove
        Button4.BackgroundImage = My.Resources._end
        Button4.ForeColor = Color.White
    End Sub

    Private Sub Button9_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button11.MouseMove
        Button11.BackgroundImage = My.Resources._end
        Button11.ForeColor = Color.White
    End Sub
    Private Sub Button10_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button17.MouseMove
        Button17.BackgroundImage = My.Resources._end
        Button17.ForeColor = Color.White
    End Sub










    Private Sub button1_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.MouseLeave
        Button14.BackgroundImage = My.Resources.enter
        Button14.ForeColor = Color.Black
    End Sub

    Private Sub Button3_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.MouseLeave
        Button15.BackgroundImage = My.Resources.enter
        Button15.ForeColor = Color.Black

    End Sub

    Private Sub Button4_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.MouseLeave
        Button16.BackgroundImage = My.Resources.enter
        Button16.ForeColor = Color.Black
    End Sub



    Private Sub Button5_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseLeave
        Button9.BackgroundImage = My.Resources.enter
        Button9.ForeColor = Color.Black

    End Sub

    Private Sub Button6_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        Button7.BackgroundImage = My.Resources.enter
        Button7.ForeColor = Color.Black
    End Sub



    Private Sub Button17_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.MouseLeave
        Button6.BackgroundImage = My.Resources.enter
        Button6.ForeColor = Color.Black

    End Sub

    Private Sub Button8_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Button4.BackgroundImage = My.Resources.enter
        Button4.ForeColor = Color.Black
    End Sub

    Private Sub Button9_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.MouseLeave
        Button11.BackgroundImage = My.Resources.enter
        Button11.ForeColor = Color.Black
    End Sub
    Private Sub Button10_mouseleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.MouseLeave
        Button17.BackgroundImage = My.Resources.enter
        Button17.ForeColor = Color.Black
    End Sub

 
End Class