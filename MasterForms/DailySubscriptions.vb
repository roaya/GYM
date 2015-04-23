Public Class DailySubscriptions

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BsourceDaily_Subsc As New BindingSource
    Dim CHeckDate As Date
    Dim SubStatus As String
    Dim ChecAttend As Integer
    Dim tbl As New GeneralDataSet.Customers_AttendanceDataTable
    'Set The Data Table Name
    Dim TName As String = "Customers_Attendance"
    Dim d1 As Date
    Dim customer_ID As Integer
    Dim Check_expired As Boolean

    Dim Req As Decimal
    '-------------------------------
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.SubscriptionsDataTable

    Dim Tbl4 As New GeneralDataSet.CustomersDataTable

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            customerid.Enabled = False
            cls.RefreshData(TName)
            cls.RefreshData("select * from employees e,jobs j where j.job_id=e.job_id and j.job_title=N'مدرب'", tbl1)
            cls.RefreshData("Select * from subscriptions where no_training=1", tbl2)
            cls.RefreshData("Select * from Customers", Tbl4)

            BsourceDaily_Subsc.Filter = ""


            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.DataSource = B
            OrderByCombo.DisplayMember = "Logical_Name"
            OrderByCombo.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            Gcls = New GeneralSp.NewMasterForms(TName, BsourceDaily_Subsc, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "بيانات الاشتراكات اليومية"
            Me.Text = Gcls.SetWTitle
            customerid.DataSource = Tbl4
            customerid.DisplayMember = "Customer_Name"
            customerid.ValueMember = "Customer_ID"
            customerid.DataBindings.Add("selectedvalue", BsourceDaily_Subsc, "customer_Id")
            AttendDate.DataBindings.Add("Text", BsourceDaily_Subsc, "Attend_Date")
            AttendTime.DataBindings.Add("Text", BsourceDaily_Subsc, "Attend_Time")
            Coach.DataSource = tbl1
            Coach.DisplayMember = "employee_name"
            Coach.ValueMember = "employee_Id"
            Coach.DataBindings.Add("selectedvalue", BsourceDaily_Subsc, "coach_id")


            Subscription_ID.DataSource = tbl2
            Subscription_ID.DisplayMember = "Subscription_Name"
            Subscription_ID.ValueMember = "Subscription_ID"

            ss.DataBindings.Add("text", BsourceDaily_Subsc, "Subscription_ID")



            SSource = BsourceDaily_Subsc

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Corporation_Name"


            BsourceDaily_Subsc.MoveLast()



        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try

            MyDs.Tables("Customers_Attendance").Columns("Attend_Date").DefaultValue = Now.ToString("dd/MM/yyyy")
            MyDs.Tables("Customers_Attendance").Columns("Attend_Time").DefaultValue = Now.ToLongTimeString

            Gcls.NewRecord()
            customerid.Enabled = False
            B_EndLoad = True
            customerid.Enabled = False
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If CurrentShiftID = 0 Then
                cls.MsgExclamation("برجاء قم بفتح وردية ")
                Exit Sub
            End If


            If customerid.SelectedValue = Nothing Or Coach.SelectedValue = Nothing Or Subscription_ID.SelectedValue = Nothing Then
                cls.MsgComplete()
                Exit Sub
            End If



            cmd.CommandText = "select count(*) from attendance where employee_id=" & Coach.SelectedValue & " and attend_date between dateadd(day,-1,getdate()) and getdate() and leave_time is null"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgExclamation("عفوا هذا المدرب غير حاضر اليوم")
                Exit Sub
            End If





            'cmd.CommandText = "select count(*)%2 from attendance where hall_id=" & Coach.SelectedValue & " and convert(date,Attend_Date,101)=convert(date,getdate(),101)"
            'If cmd.ExecuteScalar = 0 Then
            '    cls.MsgExclamation("عفوا لا يوجد مدرب في هذه الصالة")
            '    Exit Sub
            'End If


            cmd.CommandText = "select Value_Group from Subscriptions where Subscription_ID=" & Subscription_ID.SelectedValue
            Req = cmd.ExecuteScalar

            cmd.CommandText = "insert into subscriptions_Details(customer_id,Subscription_ID,Subscription_Type,Employee_id,Paid,No_Subscriptions,No_Training,Remaining,Start_Date,End_Date,Subscription_Status,Shift_Detail_id) values (" & customerid.SelectedValue & "," & Subscription_ID.SelectedValue & ",N'مجموعه'," & EmpIDVar & "," & Req & ",1,1,0,GETDATE(),GETDATE(),N'مغلقه'," & CurrentShiftID & ")"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "select max(subscription_detail_id) from subscriptions_details"
            ss.Text = cmd.ExecuteScalar


            Gcls.SaveRecord()
            BsourceDaily_Subsc.MoveLast()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            Gcls.DeleteRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            Gcls.LastRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Try
            Gcls.NextRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        Try
            Gcls.PreviousRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirst.Click
        Try
            Gcls.FirstRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Gcls.EditRecord()
            customerid.Enabled = False
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    'Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CutData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CopyData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.PasteData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    Private Sub OrderByCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderByCombo.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                Gcls.SortData(BsourceDaily_Subsc, OrderByCombo.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Gcls.ExitForm()
            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Gcls.ReloadData()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelSerach.Click
        Try
            BsourceDaily_Subsc.RemoveFilter()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Gcls.BtnFile()
    End Sub

    Private Sub BtnData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnData.Click
        Gcls.BtnData()
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click
        Gcls.BtnHelp()
    End Sub



    Private Sub Barcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Barcode.GotFocus
        Barcode.BackColor = Color.FromArgb(135, 180, 209)

    End Sub


    Private Sub Barcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Barcode.TextChanged
        Try
            cmd.CommandText = "Select Customer_id from Customers where Customer_Code = N'" & Barcode.Text & "'"
            customer_ID = cmd.ExecuteScalar
            customerid.SelectedValue = customer_ID
        Catch
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New Customers
        m.ShowDialog()
        cls.RefreshData("Select * from Customers", Tbl4)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New SubscriptionsCategories
        m.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim m As New Subscriptions
        m.ShowDialog()
        cls.RefreshData("Select * from subscriptions", tbl2)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim m As New SubscriptionDetails
        m.ShowDialog()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim m As New SpecialCategories
        m.ShowDialog()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim m As New SpecialSubscriptions
        m.ShowDialog()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim m As New Companies
        m.ShowDialog()
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Dim m As New FrmCustomersAttendace
        m.ShowDialog()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim m As New ReportSubscription
        m.ShowDialog()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim m As New FrmSubscriptionsDetails
        m.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New Halls
        m.ShowDialog()
        cls.RefreshData("select * from Halls ", tbl1)
    End Sub

    Private Sub Subscription_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Subscription_ID.SelectedIndexChanged
        Try
            cmd.CommandText = "select value_Group from subscriptions where subscription_id=" & Subscription_ID.SelectedValue
            Cost.Text = cmd.ExecuteScalar
            ss.Text = Subscription_ID.SelectedValue
        Catch

        End Try
    End Sub
End Class
