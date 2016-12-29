Imports System.Runtime.InteropServices
Imports System.Management

Public Class Form1
    Dim PnlSze As New Size(239, 673)

    Dim PwdDefault As String

    Dim objMOS As ManagementObjectSearcher
    Dim objMOC As Management.ManagementObjectCollection
    Dim objMO As Management.ManagementObject
    Dim tbl1 As New GeneralDataSet.SubscriptionsDataTable
    Dim tbl3 As New GeneralDataSet.SubscriptionsDataTable
    Dim tbl2 As New GeneralDataSet.EmployeesDataTable
    Dim CoachID As Integer
    Public STable As New GeneralDataSet.SearchTableDataTable
    Public DtlTbl As New DataTable

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Dim ReturnedProperty = "", ProcID As String
        'ProcID = "BFEBFBFF0001067A"


        'objMOS = New ManagementObjectSearcher("Select ProcessorID From Win32_Processor")
        'objMOC = objMOS.Get

        'For Each objMO In objMOC

        '    ReturnedProperty = objMO("ProcessorID")

        'Next

        'If ReturnedProperty <> ProcID Then
        '    MsgBox("هذه النسخة غير مرخصة للعمل علي هذا الجهاز", MsgBoxStyle.Critical, ProjectTitle)
        '    ''''''''cls.MsgCritical("هذه النسخة غير مرخصة للعمل علي هذا الجهاز", "this version isnot licensed to work on this machine please contact your system administrator")
        '    End
        'End If

        Dim m As New LoginForm
        m.ShowDialog()

        SetPermission()

        Me.Opacity = 100



        cmd.CommandText = "execute dbo.Commit_Attendance_LeaveTime " & EmpIDVar
        cmd.ExecuteNonQuery()

        cmd.CommandText = "select isnull(shift_Detail_id,0) from shifts_Details where end_money is null and employee_id=" & EmpIDVar
        CurrentShiftId = cmd.ExecuteScalar


        cmd.CommandText = "select count(*) from attendance where leave_time is null and employee_id=" & EmpIDVar
        If cmd.ExecuteScalar = 0 Then
            If MessageBox.Show("انت لم تسجل حضور اليوم هل تريد تسجيل حضور الأن", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then

                cmd.CommandText = "select count(*) from attendance where attend_date>'" & Today.ToString("MM/dd/yyyy") & "'"
                If cmd.ExecuteScalar() > 0 Then
                    cls.MsgExclamation("عفوا لا يمكنك تسجيل حضور بهذا اليوم برجاء تصحيح التاريخ")
                    Exit Sub
                End If

                cmd.CommandText = "insert into attendance(employee_id,attend_date,attend_time,hours_diff) values(" & EmpIDVar & ",getdate(),getdate(),0)"
                cmd.ExecuteNonQuery()
                cls.MsgInfo("لقد تم تسجيل الحضور بنجاح")
            End If
        End If

        If CurrentShiftId = 0 Then
            cmd.CommandText = "select job_id from employees where employee_id=" & EmpIDVar
            If cmd.ExecuteScalar = 1 Then
                Exit Sub
            End If
            If MessageBox.Show("عفوا لا يوجد وردية مفتوحه الأن هل تريد فتح ورديه جديده", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
                Dim mm As New Shifts_details
                mm.ShowDialog()
            End If
        End If
        cls.RefreshData("select * from subscriptions where no_training=1 ", tbl3)

        cmd.CommandText = "select * from customers"
        dr = cmd.ExecuteReader
        custcode.Items.Add("")
        While dr.Read = True
            custcode.Items.Add(dr("customer_name"))
        End While

        dr.Close()

        Subscription_ID.DataSource = tbl1
        Subscription_ID.DisplayMember = "Subscription_name"
        Subscription_ID.ValueMember = "subscription_id"

        coach.DataSource = tbl2
        coach.DisplayMember = "employee_name"
        coach.ValueMember = "employee_id"

        dailysubsc.DataSource = tbl3
        dailysubsc.DisplayMember = "Subscription_name"
        dailysubsc.ValueMember = "subscription_id"

        PnlSze.Width = 10
        Panel5.Size = PnlSze


        GrdSearch.DataSource = STable
        GrdSearch.Columns(0).Visible = False
        GrdSearch.Columns(1).HeaderText = "نوع البيانات"
        GrdSearch.Columns(2).HeaderText = "البيان التوضيحي"
        GrdSearch.Columns(3).HeaderText = "وصف البيانات"
        GrdSearchDetails.DataSource = DtlTbl


        custcode.SelectedValue = DBNull.Value
    End Sub


    Private Sub BtnDepartments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDepartments.Click
        Dim m As New Departments
        m.MdiParent = Me
        m.Show()
        Panel20.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub BtnJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJobs.Click
        Dim m As New Jobs
        m.MdiParent = Me
        m.Show()
        Panel20.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub BtnEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmployees.Click
        Dim m As New Employees
        m.MdiParent = Me
        m.Show()
        Panel20.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub BtnAttendance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttendance.Click
        Dim m As New Attendance
        m.MdiParent = Me
        m.Show()
        Panel20.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub BtnVacations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVacations.Click
        Dim m As New EmployeesVacations
        m.MdiParent = Me
        m.Show()
        Panel20.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub BtnTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTasks.Click
        Dim m As New EmployeesTasks
        m.MdiParent = Me
        m.Show()
        Panel20.Visible = False
        Panel4.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub MenuEmpAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel1.Visible = False
        Panel20.Visible = False
        Panel4.Visible = False
    End Sub
    Private Sub MenuRewards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuRewards.Click
        Panel20.Visible = False
        Panel4.Visible = True
        Panel1.Visible = False
    End Sub

    Private Sub MenuDiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDiscounts.Click
        Panel1.Visible = False
        Panel20.Visible = True
        Panel4.Visible = False
    End Sub

    Private Sub BtnRewardsCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRewardsCategories.Click
        Dim m As New RewardsCategories
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnEmpRewards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmpRewards.Click
        Dim m As New EmployeesRewards
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnAddHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New EmpAddedHours
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnDiscountCatergories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscountCatergories.Click
        Dim m As New DiscountCategories
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnSecurityGroupHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSecurityGroupHeader.Click
        Dim m As New SecurityGroupHeader
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnSecurityGroupDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSecurityGroupDetails.Click
        Dim m As New SecurityGroupDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnApp_Users_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApp_Users.Click
        Dim m As New AppUsers
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnPrintBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New PrintBarCode
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItems.Click
        Dim m As New Items
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCompanies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCorporations.Click
        Dim m As New Corporations
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnUmMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUmMaster.Click
        Dim m As New UmMaster
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnUmDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUmDetails.Click
        Dim m As New UmDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnItemsStocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItemsStocks.Click
        Dim m As New FirstBalanceStock
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCategories.Click
        Dim m As New Categories
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnStocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStocks.Click
        Dim m As New Stocks
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnItemsOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItemsOut.Click
        Dim m As New ItemsDep
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCheckHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheckHeader.Click
        Dim m As New CheckHeader
        m.MdiParent = Me
        m.Show()
    End Sub



    Private Sub BtnCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustomers.Click
        Dim m As New Customers
        m.MdiParent = Me
        m.Show()
    End Sub


    Private Sub BtnCustomerSubscription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustomerSubscription.Click
        Dim m As New SubscriptionDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCustomersAttendance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubDaily.Click
        Dim m As New DailySubscriptions
        m.MdiParent = Me
        m.Show()

    End Sub


    Private Sub BtnHalls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim m As New Halls
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnSubscripionsCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubscripionsCategories.Click
        Dim m As New SubscriptionsCategories
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnSubscriptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubscriptions.Click
        Dim m As New Subscriptions
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmp.Click
        PanelEmployees.Visible = True
        PanelCustomer.Visible = False
        PanelVendor.Visible = False
        PanelStock.Visible = False
        PanelAccounting.Visible = False
        PanelSecurity.Visible = False
        PanelSettings.Visible = False
        PanelReports.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub


    Private Sub BtnVendors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVendors.Click
        Dim m As New Vendors
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub BtnItemsVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItemsVendor.Click
        Dim m As New ItemsVendors
        m.MdiParent = Me
        m.Show()

    End Sub



    Private Sub BtnActivatePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivatePanel.Click
        PnlSze.Height = 673
        If Panel5.Size.Width = 10 Then
            PnlSze.Width = 239
            Panel5.Size = PnlSze
        Else
            PnlSze.Width = 10
            Panel5.Size = PnlSze
        End If
    End Sub

    Private Sub BtnStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStock.Click
        PanelEmployees.Visible = False
        PanelCustomer.Visible = False
        PanelVendor.Visible = False
        PanelStock.Visible = True
        PanelAccounting.Visible = False
        PanelSecurity.Visible = False
        PanelSettings.Visible = False
        PanelStatistics.Visible = False
        PanelReports.Visible = False

        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub

    Private Sub BtnCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCust.Click
        PanelEmployees.Visible = False
        PanelCustomer.Visible = True
        PanelVendor.Visible = False
        PanelStock.Visible = False
        PanelAccounting.Visible = False
        PanelSecurity.Visible = False
        PanelSettings.Visible = False
        PanelStatistics.Visible = False
        PanelReports.Visible = False

        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub

    Private Sub BtnMedecine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMedecine.Click
        PanelEmployees.Visible = False
        PanelCustomer.Visible = False
        PanelVendor.Visible = True
        PanelStock.Visible = False
        PanelAccounting.Visible = False
        PanelSecurity.Visible = False
        PanelSettings.Visible = False
        PanelStatistics.Visible = False
        PanelReports.Visible = False

        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub

    Private Sub BtnAccounting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAccounting.Click
        PanelEmployees.Visible = False
        PanelCustomer.Visible = False
        PanelVendor.Visible = False
        PanelStock.Visible = False
        PanelAccounting.Visible = True
        PanelSecurity.Visible = False
        PanelSettings.Visible = False
        PanelStatistics.Visible = False
        PanelReports.Visible = False

        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub

    Private Sub BtnMost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMost.Click
        Dim m As New Statistics
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        PanelEmployees.Visible = False
        PanelCustomer.Visible = False
        PanelVendor.Visible = False
        PanelStock.Visible = False
        PanelAccounting.Visible = False
        PanelSecurity.Visible = False
        PanelSettings.Visible = False
        PanelStatistics.Visible = False
        PanelReports.Visible = True

        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub

    Private Sub BtnSecurity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSecurity.Click
        PanelEmployees.Visible = False
        PanelCustomer.Visible = False
        PanelVendor.Visible = False
        PanelStock.Visible = False
        PanelAccounting.Visible = False
        PanelSecurity.Visible = True
        PanelSettings.Visible = False
        PanelStatistics.Visible = False
        PanelReports.Visible = False

        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PanelEmployees.Visible = False
        PanelCustomer.Visible = False
        PanelVendor.Visible = False
        PanelStock.Visible = False
        PanelAccounting.Visible = False
        PanelSecurity.Visible = False
        PanelSettings.Visible = True
        PanelStatistics.Visible = False
        PanelReports.Visible = False

        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel5.Size = PnlSze
    End Sub

    Private Sub BtnShiftCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShifts.Click
        Dim m As New Shifts
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub BtnShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShiftsDetails.Click
        Dim m As New Shifts_details
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub btnEmployeesShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New EmployeesShifts
        m.MdiParent = Me
        m.Show()


    End Sub

    Private Sub BtnSetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetDefault.Click
        Try
            REM AssistantSound.Speak("please enter system password")
            PwdDefault = InputBox("أدخل كلمة السر الخاصة بالنظام", ProjectTitle)
            If PwdDefault = "hosest" Then
                cls.MsgInfo("برجاء الانتظار حتي يتم الانتهاء", "process has been started please donot shutdown your system")
                Me.Cursor = Cursors.WaitCursor
                cmd.CommandText = "DELETE FROM Adjustment_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Sales_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Discount_Level"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Levels"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Attendance"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Sales_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Adjustment_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Cards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Discounts"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Added_Hours"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Rewards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Tasks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Vacations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Pay_Salary"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Ages"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Gender"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Item_Sizes"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Types"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Corporations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Rewards_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Security_Group_Details SET Granted =1"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Seq_Table SET Curr_Val = 1"
                cmd.ExecuteNonQuery()
                Me.Cursor = Cursors.Default
                cls.MsgInfo("تم اعادة النظام للوضع الافتراضي برجاء اعادة التشغيل", "system has been returned to default settings please restart your system")
                End
            Else
                cls.MsgCritical("خطأ في ادخال كلمة السر الخاصة بالنظام", "invalid password please contact your system administrator")
            End If
        Catch ex As Exception
            cls.MsgCritical("خطأ في ادخال كلمة السر الخاصة بالنظام", "invalid password please contact your system administrator")
        End Try
    End Sub

    Private Sub BtnChatServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChatServer.Click
        Try
            Dim p As New Process
            For Each p In Process.GetProcesses
                If p.ProcessName = "server" Then
                    cls.MsgExclamation("نافذة الشات سرفر مفتوحة بالفعل", "chatting server window already opened")
                    Exit Sub
                End If
            Next

            Process.Start(My.Application.Info.DirectoryPath & "\Server.exe")

        Catch ex As Exception
            cls.MsgCritical("لا يمكن تشغيل الشات سرفر في الوقت الحالي", "unable to start chat server please contact your system administrator")
        End Try
    End Sub

    Private Sub BtnChatClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChatClient.Click
        Dim m As New ChatClient
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub BtnSystemCommands_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSystemCommands.Click
        Dim m As New FrmWindows
        m.MdiParent = Me
        m.Show()


    End Sub

    Private Sub MenuExpensesHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExpensesHeader.Click
        Dim m As New ExpensesMaster
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuExpensesOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExpensesOther.Click
        Dim m As New ExpensesDetails
        m.MdiParent = Me
        m.Show()
    End Sub
    Private Sub BtnSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalesOrder.Click
        Dim m As New SalesOrderNormal
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCustomerReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustomerReturns.Click
        Dim m As New ReturnsCustomers
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnPurchaseBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPurchaseBill.Click
        Dim m As New PurchaseOrderNormal
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnVendorReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVendorReturns.Click
        Dim m As New ReturnsVendors
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdjustments.Click
        Dim m As New Adjustments
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuNewProcedureTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuNewProcedureTran.Click
        Dim m As New ProceduresTrans
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuDailyProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDailyProcedures.Click
        Dim m As New ReportDailyPro
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuChequeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuChequeStatus.Click
        Dim m As New ChequesStatus
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuVisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVisa.Click
        Dim m As New Visa
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuDailyProNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDailyProNames.Click
        Dim m As New DailyProcedures
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCheques.Click
        Dim m As New Cheques
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnPayAllSalaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPayAllSalaries.Click
        Dim m As New PayTotalSalary
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnPaySalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPaySalary.Click
        Dim m As New PaySalary
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuDepPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDepPro.Click
        Dim m As New DepProcedures
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuMasterRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMasterRecord.Click
        Dim m As New MasterRecord
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuIncomeDetailsByPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuIncomeDetailsByPeriod.Click
        Dim m As New NetProfitDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuBalanceSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBalanceSheet.Click
        Dim m As New BalanceSheet
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuBalanceBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBalanceBook.Click
        Dim m As New BalanceBook
        m.MdiParent = Me
        m.Show()
    End Sub


    Private Sub BtnCheckDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheckDetails.Click
        Dim m As New CheckDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustomersAttendance.Click
        Dim m As New CustomersAttendance
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Panel20.Visible = False
        Panel4.Visible = False
        Panel1.Visible = True
    End Sub

    Private Sub MenuExpenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExpenses.Click
        Panel10.Visible = True
        Panel16.Visible = False
        Panel17.Visible = False
        Panel18.Visible = False
        Panel19.Visible = False
        BtnPayAllSalaries.Visible = False
        BtnPaySalary.Visible = False
    End Sub

    Private Sub constraint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles constraint.Click
        Panel16.Visible = True
        Panel10.Visible = False
        Panel17.Visible = False
        Panel18.Visible = False
        Panel19.Visible = False
        BtnPayAllSalaries.Visible = False
        BtnPaySalary.Visible = False
    End Sub

    Private Sub Cheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cheques.Click
        Panel17.Visible = True
        Panel10.Visible = False
        Panel16.Visible = False
        Panel18.Visible = False
        Panel19.Visible = False
        BtnPayAllSalaries.Visible = False
        BtnPaySalary.Visible = False
    End Sub

    Private Sub Banks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Banks.Click
        Panel18.Visible = True
        Panel10.Visible = False
        Panel16.Visible = False
        Panel17.Visible = False
        Panel19.Visible = False
        BtnPayAllSalaries.Visible = False
        BtnPaySalary.Visible = False
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Panel19.Visible = True
        Panel10.Visible = False
        Panel16.Visible = False
        Panel17.Visible = False
        Panel18.Visible = False
        BtnPayAllSalaries.Visible = False
        BtnPaySalary.Visible = False
    End Sub

    Private Sub MenuEmpAccounts_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmpAccounts.Click
        Panel17.Visible = False
        Panel10.Visible = False
        Panel16.Visible = False
        Panel18.Visible = False
        Panel19.Visible = False
        BtnPayAllSalaries.Visible = True
        BtnPaySalary.Visible = True
    End Sub

    Private Sub BtnEmployeesDiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmployeesDiscounts.Click
        Dim m As New EmployeesDiscounts
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New Extra
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New Employeesextra
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub btnRptAttendanceTrainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmTrainerAttendance
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGymReports.Click
        Dim m As New GymAllReports
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnEvaluationCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New CustomersEvaluations
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCustEvaluation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New CustomersEvaluationDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptSubDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmSubscriptionsDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmEmployeesExtra
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCustOrderEvaluation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New CustomersOrderEvaluation
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnSpecialSubCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSpecialSubCa.Click
        Dim m As New SpecialCategories
        m.MdiParent = Me
        m.Show()
    End Sub


    Private Sub MenuBanksAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBanksAccounts.Click
        Dim M As New BankAccounts
        M.MdiParent = Me
        M.Show()
    End Sub

    Private Sub MenuBanks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBanks.Click
        Dim M As New Banks
        M.MdiParent = Me
        M.Show()
    End Sub

    Private Sub MenuMoneyPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMoneyPayments.Click
        Dim m As New MoneyPayments
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub MenuMoneyReceivable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMoneyReceivable.Click
        Dim m As New MoneyReceivables
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSettings.Click
        Dim m As New FrmUserPreferences
        m.ShowDialog()
    End Sub

    Private Sub BtnMostCountHalls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmMostCountHalls
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnMostNoCustToTrainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmMostNoCustToTrainer
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCountSpecialSubscriptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmCountSpecialSubscriptions
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ShowAllReports
        Dim RptStat As New RptMostCustomerSubscription
        MyDs.Tables("most_count_subscription").Rows.Clear()
        cmd.CommandText = "select * from most_count_subscription"
        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("most_count_subscription"))
        RptStat.SetDataSource(MyDs.Tables("Report_Sales"))
        m.ShowDialog()
    End Sub

    Private Sub BtnCountries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCountries.Click
        Dim m As New Countries
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCities_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCities.Click
        Dim m As New Cities
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRegions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegions.Click
        Dim m As New Regions
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnLocations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLocations.Click
        Dim m As New Locations
        m.MdiParent = Me
        m.Show()
    End Sub





    Sub SetPermission()
        Try
            For i As Integer = 0 To LogTbl.Rows.Count - 1
                If LogTbl.Rows(i).Item(0) = "نافذة المسمى الوظيفى" Then
                    BtnJobs.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات الاداره" Then
                    BtnDepartments.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات الموظفيين" Then
                    BtnEmployees.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الحضور و الانصراف" Then
                    BtnAttendance.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الاجازات" Then
                    BtnVacations.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الخصومات" Then
                    MenuDiscounts.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة المكافات" Then
                    MenuRewards.Visible = LogTbl.Rows(i).Item(1)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات المهمات" Then
                    BtnTasks.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة البدلات" Then
                    Button3.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الاصناف الاساسيه" Then
                    BtnItems.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات الشركات" Then
                    BtnCorporations.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذه مجموعه القياس" Then
                    BtnUmMaster.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذه تفاصيل مجموعه القياس" Then
                    BtnUmDetails.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة ادخال ارصدة اول مده" Then
                    BtnItemsStocks.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بنود الاصناف الاساسيه" Then
                    BtnCategories.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات المخازن" Then
                    BtnStocks.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اهلاك الاصناف" Then
                    BtnItemsOut.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اذونات التحويل" Then
                    BtnAdjustments.Visible = LogTbl.Rows(i).Item(1)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة جرد الاصناف" Then
                    BtnCheckHeader.Visible = LogTbl.Rows(i).Item(1)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تفاصيل جرد الاصناف" Then
                    BtnCheckDetails.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات العملاء" Then
                    BtnCustomers.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf LogTbl.Rows(i).Item(0) = "نافذة فواتير المبيعات" Then
                    BtnSalesOrder.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة مرتجع العملاء" Then
                    BtnCustomerReturns.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات الصاله" Then
                    '    BtnHalls.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة نوع الاشتراك" Then
                    BtnSubscripionsCategories.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تفاصيل الاشتراك" Then
                    BtnSubscriptions.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة حجز اشتراك" Then
                    BtnCustomerSubscription.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تسجيل الحضور و الانصراف" Then
                    BtnCustomersAttendance.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة جلسه خاصه" Then
                    BtnSpecialSub.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بنود الجلسات خاصه" Then
                    BtnSpecialSubCa.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات المورديين" Then
                    BtnVendors.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة ربط المورديين بالاصناف" Then
                    BtnItemsVendor.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة فواتير المشتريات" Then
                    BtnPurchaseBill.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اذن ارتجاع مورد" Then
                    BtnVendorReturns.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة المصروفات" Then
                    MenuExpenses.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة قائمه الدخل التفصيليه" Then
                    MenuIncomeDetailsByPeriod.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اسماء الحسابات" Then
                    MenuDailyProNames.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة القيود" Then
                    constraint.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة ميزان المراجعه" Then
                    MenuBalanceBook.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الميزانيه العموميه" Then
                    MenuBalanceSheet.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اهلاك الاصول الثابته" Then
                    MenuDepPro.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الشيكات" Then
                    Cheques.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تعاملات البنوك" Then
                    Banks.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اذونات الدفع" Then
                    Button18.Visible = LogTbl.Rows(i).Item(1)
                    btnReceiv.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة حساب الاستاذ" Then
                    MenuMasterRecord.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة حسابات شئون العامليين" Then
                    MenuEmpAccounts.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير فواتير المبيعات" Then
                    BtnRptSalesOrder.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير فواتير المشتريات" Then
                    BtnRptPurchaseOrder.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير اذونات التحويل" Then
                    BtnRptAdjustments.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير اذونات اهلاك الاصناف" Then
                    BtnRptDepItems.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير اذونات ارتجاع الموردين" Then
                    BtnRptVendorReturns.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير اذونات ارتجاع العملاء" Then
                    BtnRptCustomersReturns.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير حركة المخزن" Then
                    BtnRptInvLog.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير حركة المستخدين" Then
                    BtnRptUserLog.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير تقييم المخزن'" Then
                    BtnRptStockValue.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير طباعه باركود الاصناف" Then
                    BtnRptBarcode.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير وحدات القياس" Then
                    BtnRptItemsUm.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "التقرير العام لارصده المخزن" Then
                    BtnGeneralBalance.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "التقرير التفصيلى لارصده المخزن" Then
                    BtnStockDetails.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير حضور وانصراف المدربين" Then
                    '    btnRptAttendanceTrainer.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير حضور وانصراف الموظفين" Then
                    '    BtnRptEmpAttendance.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير طباعه الكروت" Then
                    BtnPrintBarcode.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير كشف حساب عميل" Then
                    '    FrmCustomerTransactions.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير ارصدة الحسابات" Then
                    BtnRptAccountsBalance.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير كشف حساب مورد" Then
                    '    FrmVendorTransactions.Visible = LogTbl.Rows(i).Item(1)

                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير كشف حساب بنك" Then
                    '    BtnBankTran.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير كشف حساب عام" Then
                    BtnAnyAccount.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير تواريخ صلاحيه الاصناف" Then
                    BtnReportItemExpiration.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير كشف الاجور لموظف واحد" Then
                    '    BtnRepPayEmpSalary.Visible = LogTbl.Rows(i).Item(1)

                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير كشف الاجور العام" Then
                    '    BtnRepPaySalary.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الورديات" Then
                    BtnShifts.Visible = LogTbl.Rows(i).Item(1)
                    BtnShiftsDetails.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اعدادات البرنامج" Then
                    BtnSettings.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة مجموعات الامان" Then
                    BtnSecurityGroupHeader.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة صلاحيات مجموعات الامان" Then
                    BtnSecurityGroupDetails.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بيانات المستخدمين" Then
                    BtnApp_Users.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الدخول للشات" Then
                    BtnChatClient.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تشغيل سرفر الشات" Then
                    BtnChatServer.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الوضع الافتراضى" Then
                    BtnSetDefault.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الدول" Then
                    BtnCountries.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة المدن" Then
                    BtnCities.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة المناطق" Then
                    BtnRegions.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة العناوين" Then
                    BtnLocations.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة اوامر النظام" Then
                    BtnSystemCommands.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "احصائية الصالات بنسبة الحضور" Then
                    '    BtnMostCountHalls.Visible = LogTbl.Rows(i).Item(1)

                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "احصائية المتدربين للمدرب الواحد" Then
                    '    BtnMostNoCustToTrainer.Visible = LogTbl.Rows(i).Item(1)

                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "احصائية الجلسات الخاصه" Then
                    '    BtnCountSpecialSubscriptions.Visible = LogTbl.Rows(i).Item(1)

                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "احصائية الاشتراكات بنسبة الحجز-بيانيه" Then
                    '    Button10.Visible = LogTbl.Rows(i).Item(1)

                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "احصائية الاشتراكات بنسبة الحجز-رقميه" Then
                    '    Button9.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf LogTbl.Rows(i).Item(0) = "اضافة فتره و عدد من التمرينات للاشتراك" Then
                    SubscriptionDetails.BtnSearch.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بنود التقييمات" Then
                    BtnEvaluationCategory.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تفاصيل التقييمات" Then
                    BtnCustEvaluation.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تقييمات العملاء" Then
                    BtnCustOrderEvaluation.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "شركات العملاء" Then
                    BtnCompanies.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقارير الجيم" Then
                    BtnGymReports.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير فواتير الاشتراكات" Then
                    '    BtnRptSubDetails.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'ElseIf LogTbl.Rows(i).Item(0) = "تقرير بدلات الموظفين" Then
                    '    BtnRptExtra.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "مرتب الموظف" Then
                    ShowSal = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقارير الجيم" Then
                    BtnGymReports.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير الدخل العام" Then
                    RptIncome.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة ارجاع اشتراك" Then
                    BntSubscReturn.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة تعديل وقت انصراف الموظفين" Then
                    BtnAttendanceLeave.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة بنود المرتبات" Then
                    BtnSalaryGroups.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الاشتراكات اليوميه" Then
                    BtnSubDaily.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة البحث" Then
                    SearchBox.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "تقرير الموظفين" Then
                    btnreportEmployees.Visible = LogTbl.Rows(i).Item(1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "نافذة الاحصائيات" Then
                    BtnMost.Visible = LogTbl.Rows(i).Item(1)
                End If

            Next
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub



    Private Sub BtnBackCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MyDs.Tables("barcodetable1").Rows.Clear()
        For I As Integer = 0 To 3
            r = MyDs.Tables("barcodetable1").NewRow
            r("customer_name1") = " "
            MyDs.Tables("barcodetable1").Rows.Add(r)
        Next

        Dim m As New ShowAllReports
        Dim rptcrd As New RptBarCode2
        rptcrd.SetDataSource(MyDs.Tables("barcodetable1"))
        m.CrystalReportViewer1.ReportSource = rptcrd
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub FrmCustomerTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmCustomerTeansaction
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub BtnPrintEmpCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New PrintEmpBarCode
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnSubDaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSpecialSub.Click
        Dim m As New SpecialSubscriptions
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnEvaluationCategory_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEvaluationCategory.Click
        Dim m As New CustomersEvaluations
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCustEvaluation_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustEvaluation.Click
        Dim m As New CustomersEvaluationDetails
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCustOrderEvaluation_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustOrderEvaluation.Click
        Dim m As New CustomersOrderEvaluation
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnCompanies_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCompanies.Click
        Dim m As New Companies
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New frmreportallsubscriptions
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New frmreportallspecialsubscriptions
        m.MdiParent = Me
        m.Show()
    End Sub
    Private Sub BtnRptAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptAdjustments.Click
        Dim m As New ReportAdjustments
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptPurchaseOrder.Click
        Dim m As New ReportPurchaseOrder
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptVendorReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptVendorReturns.Click
        Dim m As New ReportVenReturns
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptCustomersReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptCustomersReturns.Click
        Dim m As New ReportCusReturns
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptSalesOrder.Click
        Dim m As New ReportSalesOrder
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptEmpAttendance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportEmpAttendance
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptDepItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptDepItems.Click
        Dim m As New ReportDepItems
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptInvLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptInvLog.Click
        Dim m As New FrmInvLog
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptUserLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptUserLog.Click
        Dim m As New ReportUserLog
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptStockValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptStockValue.Click
        Dim m As New FrmReportStockValue
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptItemsUm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptItemsUm.Click
        Try
            MyDs.Tables("query_items_um").Rows.Clear()
            Dim rpt As New RptItemsUm
            Dim m As New ShowAllReports
            da.SelectCommand = cmd
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from query_items_um order by item_name asc"
            da.Fill(MyDs.Tables("query_items_um"))
            rpt.SetDataSource(MyDs.Tables("query_items_um"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.ShowDialog()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Query items um")
        End Try
    End Sub

    Private Sub BtnGeneralBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGeneralBalance.Click
        Dim m As New FrmReportItemsStocks
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStockDetails.Click
        Dim m As New FrmItemsStocksBalance
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnReportItemExpiration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReportItemExpiration.Click
        Dim m As New reportItemExpiration
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub FrmVendorTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmVendorsTrans
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnBankTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportBanksBalance
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnAnyAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnyAccount.Click
        Dim m As New ReportAnyAccount
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnRptAccountsBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRptAccountsBalance.Click
        Dim m As New ReportAnyAccountBalance
        m.MdiParent = Me
        m.Show()
    End Sub



    Private Sub BtnBackCard_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBackCard.Click
        MyDs.Tables("barcodetable1").Rows.Clear()
        For I As Integer = 0 To 4
            r = MyDs.Tables("barcodetable1").NewRow
            r("customer_name1") = " "
            MyDs.Tables("barcodetable1").Rows.Add(r)
        Next

        Dim m As New ShowAllReports
        Dim rptcrd As New RptBarCode2
        rptcrd.SetDataSource(MyDs.Tables("barcodetable1"))
        m.CrystalReportViewer1.ReportSource = rptcrd
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub BtnPrintBarcode_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintBarcode.Click
        Dim m As New PrintBarCode
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub BtnPrintEmpCards_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintEmpCards.Click
        Dim m As New PrintEmpBarCode
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RptIncome.Click
        Dim m As New FrmReportIncom
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TodayIncome.ShowDialog()
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New frmspecialsubscriptions
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BntSubscReturn.Click
        Dim m As New Subscriptions_Reject
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmCustomersAttendace
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Show_Hide.Click
        If Panel2.Tag = "Shown" Then
            Show_Hide.BackgroundImage = My.Resources.Show_Panel
            Panel2.Width = 0
            Panel2.Tag = "Hidden"
        Else
            Show_Hide.BackgroundImage = My.Resources.Hide_Panel
            Panel2.Width = 216
            Panel2.Tag = "Shown"
        End If
    End Sub

    Private Sub EmpBarcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EmpBarcode.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                cmd.CommandText = "select count(*) from attendance where attend_date>'" & Today.ToString("MM/dd/yyyy") & "'"
                If cmd.ExecuteScalar() > 0 Then
                    cls.MsgExclamation("عفوا لا يمكنك تسجيل حضور بهذا اليوم برجاء تصحيح التاريخ")
                    Exit Sub
                End If

                Dim emp_id As Integer
                Dim emp_name As String
                Dim d As Date
                cmd.CommandText = "select employee_id from employees where barcode='" & EmpBarcode.Text & "'"
                Try
                    emp_id = cmd.ExecuteScalar
                Catch
                    emp_id = 0
                End Try

                If EmpBarcode.Text = "" Or emp_id = 0 Then
                    cls.MsgCritical("برجاء ادخال باركود صحيح للموظف")
                    Exit Sub
                End If
                cmd.CommandText = "select employee_name from employees where employee_id=" & emp_id
                emp_name = cmd.ExecuteScalar

                d = Today.ToString

                cmd.CommandText = "execute Commit_Attendance_LeaveTime " & emp_id
                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT dbo.CHECK_ATTENDANCE(" & emp_id & ",'" & d.ToString("MM/dd/yyyy") & "')"
                If cmd.ExecuteScalar = 0 Then
                    d = d.AddDays(-1)
                    cmd.CommandText = "SELECT dbo.CHECK_ATTENDANCE(" & emp_id & ",'" & d.ToString("MM/dd/yyyy") & "')"
                    If cmd.ExecuteScalar <> 0 Then
                        cmd.CommandText = "update attendance set leave_time=getdate() where serial_pk=" & cmd.ExecuteScalar
                        cmd.ExecuteNonQuery()
                        cls.MsgInfo("لقد تم تسجيل انصراف للموظف  " & "'" & emp_name & "'" & " بنجاح")
                        cmd.CommandText = "select isnull(shift_detail_id,0) from shifts_details where end_money is null and employee_id=" & emp_id
                        If cmd.ExecuteScalar <> 0 And emp_id = EmpIDVar Then
                            cmd.CommandText = "update shifts_details set end_date = getdate() , end_money = 0 , real_end_time = ' " & Now.ToLongTimeString & "' where shift_detail_id = " & cmd.ExecuteScalar
                            cmd.ExecuteNonQuery()
                            cls.MsgInfo("لقد تم اغلاق الورديه المرتبطة بالموظف ")
                            INC = 1
                            Dim m As New FrmReportIncome
                            m.ShowDialog()
                            INC = 0
                            CurrentShiftId = 0
                        End If
                        EmpBarcode.Text = ""
                        cls.RefreshData("select * from employees e,jobs j,attendance ca where j.job_id=e.job_id and e.employee_id=ca.Employee_ID and j.job_title=N'مدرب' and ca.leave_time is null", tbl2)
                        Exit Sub
                    End If
                Else
                    cmd.CommandText = "update attendance set leave_time=getdate() where serial_pk=" & cmd.ExecuteScalar
                    cmd.ExecuteNonQuery()
                    cls.MsgInfo("لقد تم تسجيل انصراف للموظف  " & "'" & emp_name & "'" & " بنجاح")
                    cmd.CommandText = "select isnull(shift_detail_id,0) from shifts_details where end_money is null and employee_id=" & emp_id
                    If cmd.ExecuteScalar <> 0 And emp_id = EmpIDVar Then
                        cmd.CommandText = "update shifts_details set end_date = getdate() , end_money = 0 , real_end_time = ' " & Now.ToLongTimeString & "' where shift_detail_id = " & cmd.ExecuteScalar
                        cmd.ExecuteNonQuery()
                        cls.MsgInfo("لقد تم اغلاق الورديه المرتبطة بالموظف ")
                        INC = 1
                        Dim m As New FrmReportIncome
                        m.ShowDialog()
                        INC = 0
                        CurrentShiftId = 0
                    End If
                    EmpBarcode.Text = ""
                    cls.RefreshData("select * from employees e,jobs j,attendance ca where j.job_id=e.job_id and e.employee_id=ca.Employee_ID and j.job_title=N'مدرب' and ca.leave_time is null", tbl2)
                    Exit Sub
                End If


                cmd.CommandText = "select COUNT(*) FROM Employees_Vacations WHERE '" & d.ToString("MM/dd/yyyy") & "' BETWEEN From_Date AND To_Date and employee_id = " & emp_id
                If cmd.ExecuteScalar > 0 Then
                    cls.MsgExclamation("تم تسجيل بيانات هذا الموظف كأجازة في هذه الفترة", "this employee has requested a vacation during this period and cannot register today please remove his record from vacations data")
                    Exit Sub
                Else

                    cmd.CommandText = "insert into attendance(employee_id,attend_date,attend_time,hours_diff) values(" & emp_id & ",getdate(),getdate(),0)"
                    cmd.ExecuteNonQuery()
                    cls.MsgInfo("لقد تم تسجيل حضور للموظف  " & "'" & emp_name & "'" & " بنجاح")
                    EmpBarcode.Text = ""
                End If


            End If
            cls.RefreshData("select * from employees e,jobs j,attendance ca where j.job_id=e.job_id and e.employee_id=ca.Employee_ID and j.job_title=N'مدرب' and ca.leave_time is null", tbl2)
        Catch
        End Try
    End Sub






    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If custname.Text = "" Then
            cls.MsgExclamation("الباركود الذي ادخلته غير صحيح برجاء اعادة ادخال الباركود للعميل")
            Exit Sub
        End If
        Dim req As Decimal
        Dim ss As Integer
        Dim Train_Value As Decimal

        If bysubsc.Checked = True Then
            Dim CustProID As Integer
            Dim Extra_D As Decimal

            If Subscription_ID.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء اختيار اشتراك من الاشتراكات المتاحه")
                Exit Sub
            End If

            cmd.CommandText = "select procedure_master_id from procedure_master where procedure_category=N'عملاء' and reference_id=" & CustID
            cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & cmd.ExecuteScalar & ",getdate())"
            CustProID = cmd.ExecuteScalar()
            cmd.CommandText = "select Extra_disc from app_preferences"
            Extra_D = cmd.ExecuteScalar


            cmd.CommandText = "select value_group/subscriptions.no_training from Subscriptions,Subscriptions_Details where Subscriptions.Subscription_ID = Subscriptions_Details.Subscription_ID and Subscription_Detail_ID=" & Subscription_ID.SelectedValue
            Train_Value = cmd.ExecuteScalar

            cmd.CommandText = "select dbo.Get_Remaining_Subscriptions(" & Subscription_ID.SelectedValue & ")"

            If cmd.ExecuteScalar - Train_Value - Extra_D <= CustProID And CustProID <> 0 Then
                cls.MsgExclamation("عفوا هذا العميل عليه مستحقات يجب دفع جزء منها لكي يسمح له بالحضور")
                Exit Sub
            End If



            If Subscription_ID.SelectedValue = Nothing Or coach.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل جميع البيانات الناقصه")
                Exit Sub
            End If



            cmd.CommandText = "select count(*) from customers_Attendance where convert(date,attend_Date,101)=convert(date,getdate() ,101) and customer_id=" & CustID & " and subscription_id=" & Subscription_ID.SelectedValue
            If cmd.ExecuteScalar > 0 Then
                If MessageBox.Show(" لقد تم تسجيل حضور للعميل '" & custname.Text & "' من قبل هل تريد تسجيل حضوره مره اخرى", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbNo Then
                    Exit Sub
                End If
            End If
            cmd.CommandText = "insert into Customers_Attendance(Customer_ID,Attend_Date,Attend_Time,Subscription_ID,Coach_ID) values(" & CustID & ",getdate(),getdate()," & Subscription_ID.SelectedValue & "," & coach.SelectedValue & ")"
            cmd.ExecuteNonQuery()
            cls.MsgInfo("لقد تم تسجيل الحضور للعميل '" & custname.Text & "' بنجاح")
            custcode.Text = ""
        Else

            If CurrentShiftId = 0 Then
                cls.MsgExclamation("برجاء قم بفتح وردية ")
                Exit Sub
            End If

            If dailysubsc.SelectedValue = Nothing Or coach.SelectedValue = Nothing Then
                cls.MsgComplete()
                Exit Sub
            End If


            cmd.CommandText = "select Value_Group from Subscriptions where Subscription_ID=" & dailysubsc.SelectedValue
            req = cmd.ExecuteScalar

            cmd.CommandText = "insert into subscriptions_Details(customer_id,Subscription_ID,Subscription_Type,Employee_id,Paid,No_Subscriptions,No_Training,Remaining,Start_Date,End_Date,Subscription_Status,Shift_Detail_id) values (" & CustID & "," & dailysubsc.SelectedValue & ",N'مجموعه'," & EmpIDVar & "," & req & ",1,1,0,GETDATE(),GETDATE(),N''," & CurrentShiftId & ")"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "select max(subscription_detail_id) from subscriptions_details"
            ss = cmd.ExecuteScalar

            cmd.CommandText = "insert into Customers_Attendance(Customer_ID,Attend_Date,Attend_Time,Subscription_ID,Coach_ID) values(" & CustID & ",getdate(),getdate()," & ss & "," & coach.SelectedValue & ")"
            cmd.ExecuteNonQuery()
            cls.MsgInfo("لقد تم تسجيل اشتراك يومي للعميل'" & custname.Text & "' بنجاح")
            custcode.Text = ""

        End If
    End Sub

    Private Sub Subscription_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Subscription_ID.SelectedIndexChanged
        Try
            cmd.CommandText = "select coach_id from subscriptions_details where subscription_detail_id=" & Subscription_ID.SelectedValue
            Try
                coach.SelectedValue = cmd.ExecuteScalar
            Catch
                coach.SelectedValue = DBNull.Value
            End Try

            cmd.CommandText = "select count(*) from customers_Attendance where subscription_id=" & Subscription_ID.SelectedValue
            CustAttendance.Text = cmd.ExecuteScalar

        Catch
            CustAttendance.Text = 0
        End Try
    End Sub





    Private Sub dailysubsc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dailysubsc.SelectedIndexChanged
        Try
            cmd.CommandText = "select value_group from subscriptions where subscription_id=" & dailysubsc.SelectedValue
            Cost.Text = cmd.ExecuteScalar
        Catch
        End Try
    End Sub


    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bysubsc.CheckedChanged
        If bysubsc.Checked = True Then
            Panel3.Enabled = True
            Panel6.Enabled = False
        End If
    End Sub

    Private Sub bydaily_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bydaily.CheckedChanged
        If bydaily.Checked = True Then
            Panel3.Enabled = False
            Panel6.Enabled = True
        End If
    End Sub


    Private Sub attendanceManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttendanceLeave.Click
        Dim m As New AttendanceManagement
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalaryGroups.Click
        Dim m As New salarygroups
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button2_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New SubscriptionDetails
        'Show_Hide.BackgroundImage = My.Resources.Show_Panel
        'Panel2.Width = 0
        'Panel2.Tag = "Hidden"
        m.MdiParent = Me
        m.Show()
    End Sub



    Private Sub ToolStripTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchBox.KeyDown
        If e.KeyValue = Keys.Enter Then
            STable.Clear()
            DtlTbl.Clear()
            cmd.CommandText = "select customer_id as ColID,N'عملاء' as ColType,customer_name as ColName,N'البيانات الشخصيه للعميل' as ColDesc from customers where customer_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select customer_id as ColID,N'عملاء' as ColType,customer_name as ColName,N'البيانات الشخصيه للعميل' as ColDesc from customers where customer_Code like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Vendor_id as ColID,N'موردين' as ColType,Vendor_name as ColName,N'البيانات الشخصيه للمورد' as ColDesc from Vendors where Vendor_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات التفصيليه للأصناف' as ColDesc from Items where Item_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select item_id as ColID,N'بيانات الأصناف' as ColType,item_name as ColName,N'بيانات التفصيليه للأصناف' as ColDesc from Items where barcode like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Employee_id as ColID,N'بيانات العاملين' as ColType,Employee_name as ColName,N'بيانات التفصيليه للعاملين' as ColDesc from employees where employee_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Expense_Category_ID as ColID,N'بنود المصروفات' as ColType,Expense_Category_name as ColName,N'بيانات بنود المصروفات' as ColDesc from Expenses_Header where Expense_Category_Name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Stock_ID as ColID,N'المحلات' as ColType,Stock_Name as ColName,N'بيانات المحلات' as ColDesc from Stocks where Stock_Name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Category_id as ColID,N'بنود المخزن' as ColType,Category_name as ColName,N'بيانات بنود المخزن' as ColDesc from categories where Category_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Um_id as ColID,N'مجموعات القياس' as ColType,Um_name as ColName,N'الأصناف و مجموعات القياس' as ColDesc from Um_Master where Um_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select corporation_id as ColID,N'الشركات' as ColType,corporation_name as ColName,N'بيانات الشركات التفصيليه' as ColDesc from corporations where corporation_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Bank_ID as ColID,N'البنوك' as ColType,Bank_name as ColName,N'بيانات البنوك' as ColDesc from Banks where Bank_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '-------------------------------------------------------------
            cmd.CommandText = "select Subscription_id as ColID,N'الاشتراكات' as ColType,subscription_name as ColName,N'بيانات الاشتراكات' as ColDesc from subscriptions where subscription_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------------------------
            cmd.CommandText = "select category_id as ColID,N'بنود الاشتراكات' as ColType,category_name as ColName,N'بيانات بنود الاشتراكات' as ColDesc from subscriptions_categories where category_Name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------------------------
            cmd.CommandText = "select special_categories_id as ColID,N'الجلسات الخاصه' as ColType,category_name as ColName,N'بيانات الجلسات الخاصه' as ColDesc from special_categories where category_name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)

            '------------------------------------------
            cmd.CommandText = "select Cheque_ID as ColID,N'بيانات الشيكات' as ColType,Cheque_Number as ColName,N'تفاصيل الشيكات' as ColDesc from Cheques where Cheque_Number like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Procedure_Master_ID as ColID,N'شجرة الحسابات' as ColType,Daily_Procedure_Name as ColName,N'بيانات شجرة الحسابات' as ColDesc from Procedure_Master where Daily_Procedure_Name like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            '------------------------------------------
            cmd.CommandText = "select Visa_ID as ColID,N'بيانات الفيزا' as ColType,Visa_Number as ColName,N'تفاصيل كروت الفيزا' as ColDesc from Visa where Visa_Number like N'%" & SearchBox.Text & "%'"
            da.SelectCommand = cmd
            da.Fill(STable)
            'GrdSearch.Columns(0).Visible = True
            PanelSearch.Visible = True
        End If

    End Sub


    Private Sub Button7_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        PanelSearch.Visible = False
    End Sub

    Private Sub GrdSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdSearch.CellDoubleClick

        DtlTbl.Rows.Clear()
        DtlTbl.Columns.Clear()

        Select Case GrdSearch.SelectedRows(0).Cells("ColType").Value
            Case "عملاء"
                cmd.CommandText = "select customer_id , customer_name as N'اسم العميل',customer_code as N'كود العميل' ,address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from customers where customer_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "موردين"
                cmd.CommandText = "select vendor_id , vendor_name as N'اسم المورد', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from vendors where vendor_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بيانات العاملين"
                cmd.CommandText = "select employee_id , employee_name as N'اسم الموظف', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from employees where employee_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود المصروفات"
                cmd.CommandText = "select Expense_Detail_id , Expense_name as N'اسم المصروف' from Expenses_Details where Expense_Category_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بيانات الأصناف"
                cmd.CommandText = "select distinct item_id , Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where item_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "المحلات"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where stock_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود المخزن"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where category_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الشركات"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where corporation_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "مجموعات القياس"
                cmd.CommandText = "select distinct item_id ,Corporation_Name as N'اسم المحل' ,item_name as N'اسم الصنف', barcode as N'الباركود', purchase_price as N'سعر الشراء', sale_price as N'سعر القطاعي' , sale_total_price as N'سعر الجمله' from Query_All_Items where Um_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "البنوك"
                cmd.CommandText = "select distinct Account_ID ,Account_Number as N'رقم الحساب' ,Created_Date as N'تاريخ الانشاء' from Banks_Accounts where Bank_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الشيكات"
                cmd.CommandText = "select distinct Cheque_ID ,Cheque_Number as N'رقم الشيك' ,Cheque_Value as N'قيمة الشيك',Cheque_Status as N'الحاله'  from Cheques where Cheque_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "فئات الآجل"
                cmd.CommandText = "select customer_id , customer_name as N'اسم العميل', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from customers where Level_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "فئات الخصم"
                cmd.CommandText = "select customer_id , customer_name as N'اسم العميل', address as N'العنوان', Mobile as N'الموبايل', Tele as N'التليفون' from customers where Discount_Level_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "شجرة الحسابات"
                cmd.CommandText = "select Procedure_Master_ID , Daily_Procedure_Name as N'اسم الحساب', Procedure_Category as N'بند الحساب', Procedure_Type as N'طبيعة الحساب' from Procedure_Master where Procedure_Master_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الاشتراكات"
                cmd.CommandText = "select subscription_id , subscription_Name as N'اسم الاشتراك', value_group as N'سعر المجموعه',value_single as N'سعر الخاص' from subscriptions where subscription_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "بنود الاشتراكات"
                cmd.CommandText = "select category_id , category_name as N'بند الاشتراك', generic_desc as N'وصف مختصر' from subscriptions_categories where category_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            Case "الجلسات الخاصه"
                cmd.CommandText = "select special_categories_id , category_Name as N'الجلسه الخاصه', value as N'قيمة الجلسه' ,Coach_percent as N'نسبة المدرب' from special_categories where special_categories_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value


        End Select

        da.SelectCommand = cmd
        da.Fill(DtlTbl)
        GrdSearchDetails.Columns(0).Visible = False

    End Sub

    Private Sub GrdSearchDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdSearchDetails.CellDoubleClick
        Select Case GrdSearchDetails.SelectedRows(0).Cells(0).OwningColumn.Name
            Case "customer_id"
                Dim m As New Customers
                m.SearchCustomerID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "vendor_id"
                Dim m As New Vendors
                m.SearchVendorID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "employee_id"
                Dim m As New Employees
                m.SearchEmployeeID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Expense_Detail_id"
                Dim m As New ExpensesDetails
                m.SearchExpenseDetailID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "item_id"
                Dim m As New Items
                m.SearchItemID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Account_ID"
                Dim m As New BankAccounts
                m.SearchAccID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Cheque_ID"
                Dim m As New Cheques
                m.SearchChqID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Procedure_Master_ID"
                Dim m As New DailyProcedures
                m.SearchProID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "Visa_ID"
                Dim m As New Visa
                m.SearchVisaID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "subscription_id"
                Dim m As New Subscriptions
                m.SearchSubscriptionId = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "category_id"
                Dim m As New SubscriptionsCategories
                m.SearchSubscCategoryID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
            Case "subscription_categories_id"
                Dim m As New SpecialCategories
                m.SearchSpecialID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                m.ShowDialog()
        End Select
    End Sub


    Private Sub Button8_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreportEmployees.Click
        Dim m As New FrmEmployees
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button2_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiv.Click
        Dim m As New MoneyReceivables
        If custname.Text <> "" Then
            m.ST = CustID
        End If
        m.ShowDialog()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles custcode.TextChanged
        Try
            cmd.CommandText = "select customer_id from customers where customer_Code='" & custcode.Text & "'"
            Try
                CustID = cmd.ExecuteScalar
            Catch
                Exit Sub
            End Try


            cmd.CommandText = "select customer_name from customers where customer_Code='" & custcode.Text & "'"
            Try
                custname.Text = cmd.ExecuteScalar
            Catch
                custname.Text = ""
            End Try

            cls.RefreshData("select d.subscription_detail_id as subscription_id,s.subscription_name,s.Category_ID,s.No_Training,s.Months,s.Value_Group,s.Value_Single from Subscriptions s,Subscriptions_Details d where s.Subscription_ID=d.Subscription_ID  and d.Subscription_Status=N'مفتوحه' and d.Customer_ID = " & CustID, tbl1)
            cls.RefreshData("select * from employees e,jobs j,attendance ca where j.job_id=e.job_id and e.employee_id=ca.Employee_ID and j.job_title=N'مدرب' and ca.leave_time is null", tbl2)
            cls.RefreshData("select * from subscriptions where no_training=1 ", tbl3)

            dailysubsc.SelectedValue = DBNull.Value


            cmd.CommandText = "select procedure_master_id from procedure_master where procedure_Category=N'عملاء' and reference_id=" & CustID
            cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & cmd.ExecuteScalar & ",getdate())"
            CustBalance.Text = cmd.ExecuteScalar

            cmd.CommandText = "select count(*) from customers_Attendance where subscription_id=" & Subscription_ID.SelectedValue
            CustAttendance.Text = cmd.ExecuteScalar
        Catch
            CustBalance.Text = 0
            CustAttendance.Text = 0
        End Try

    End Sub

    Private Sub custcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles custcode.SelectedIndexChanged
        Try
            If custcode.Text <> "" Then
                cmd.CommandText = "select customer_code from customers where customer_name=N'" & custcode.Text & "'"
                System.Windows.Forms.Clipboard.SetText(cmd.ExecuteScalar)
            End If
        Catch
        End Try
    End Sub

    Private Sub Button2_Click_6(sender As Object, e As EventArgs) Handles Button2.Click
        Panel8.Visible = Not Panel8.Visible
    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        Panel9.Visible = Not Panel9.Visible

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim m As New Loans
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub Button8_Click_3(sender As Object, e As EventArgs) Handles Button8.Click
        Dim m As New EmployeesLoansPhases
        m.MdiParent = Me
        m.Show()

    End Sub
End Class
