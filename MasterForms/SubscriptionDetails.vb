Public Class SubscriptionDetails

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Public bsourcesubscriptionDetails As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Subscriptions_Details"
    Dim tbl1, tbl5 As New GeneralDataSet.CustomersDataTable
    Dim tbl2 As New GeneralDataSet.EmployeesDataTable
    Dim tbl3 As New GeneralDataSet.SubscriptionsDataTable
    Dim tbl4 As New GeneralDataSet.JobsDataTable
    '-------------------------------
    Dim required As Double
    Dim no_Train As Integer
    Dim status As Integer
    Dim bsource As New BindingSource

    Dim d1 As Date
    Dim d2 As Date
    Dim the_date As Date
    Dim trainings As Integer
    Dim num As Integer = 0
    Dim CurrSubs As Integer
    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
          
            cmd.CommandText = "select granted from security_group_details where privilege_name=N'«÷«›… › —Â Ê ⁄œœ „‰ «· „—Ì‰«  ··«‘ —«ﬂ' and group_id=(select group_id from app_users where employee_id=" & EmpIDVar & ")"
            BtnSearch.Visible = cmd.ExecuteScalar



            cls.RefreshData(TName)
            cls.RefreshData("select * from employees e,jobs j where j.job_id=e.job_id and j.job_title=N'„œ—»'", tbl2)
            cls.RefreshData("select * from customers", tbl1)
            cls.RefreshData("select * from customers", tbl5)

            cls.RefreshData("select * from subscriptions where no_training<>1", tbl3)
            cls.RefreshData("select * from jobs", tbl4)
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

            Gcls = New GeneralSp.NewMasterForms(TName, bsourcesubscriptionDetails, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords)


            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "»Ì«‰«  «‘ —«ﬂ«  «·⁄„·«¡"
            Me.Text = Gcls.SetWTitle
            Cust.DataSource = tbl1
            Cust.DisplayMember = "customer_name"
            Cust.ValueMember = "customer_id"
            Cust.DataBindings.Add("SelectedValue", bsourcesubscriptionDetails, "customer_id")


            paid.DataBindings.Add("value", bsourcesubscriptionDetails, "paid")
            No_Subscription.DataBindings.Add("value", bsourcesubscriptionDetails, "no_subscriptions")
            No_Trainings.DataBindings.Add("value", bsourcesubscriptionDetails, "no_training")
            Remaining.DataBindings.Add("value", bsourcesubscriptionDetails, "remaining")
            FromDate.DataBindings.Add("text", bsourcesubscriptionDetails, "start_date")
            ToDAte.DataBindings.Add("text", bsourcesubscriptionDetails, "end_date")
            Type.DataBindings.Add("text", bsourcesubscriptionDetails, "subscription_type")

            SubscriptionType.DataSource = tbl3
            SubscriptionType.DisplayMember = "subscription_name"
            SubscriptionType.ValueMember = "Subscription_ID"
            SubscriptionType.DataBindings.Add("SelectedValue", bsourcesubscriptionDetails, "subscription_id")

            Coach.DataSource = tbl2
            Coach.DisplayMember = "employee_name"
            Coach.ValueMember = "employee_id"
            Coach.DataBindings.Add("SelectedValue", bsourcesubscriptionDetails, "coach_id")
            ''''''''''''''''''''''''''''''''''''''''''''customer information
            bsource.DataSource = tbl5
            bsource.Filter = "customer_id=-1"
            custname.DataBindings.Add("text", bsource, "customer_name")
            Telephone.DataBindings.Add("text", bsource, "tele")
            Mobile.DataBindings.Add("text", bsource, "mobile")
            Bdate.DataBindings.Add("text", bsource, "birth_date")
            RepPerson.DataBindings.Add("text", bsource, "rep_person")
            PersonalID.DataBindings.Add("text", bsource, "personal_id")
            email.DataBindings.Add("text", bsource, "email")
            site.DataBindings.Add("text", bsource, "web_site")
            age.DataBindings.Add("text", bsource, "age")
            address.DataBindings.Add("text", bsource, "address")
            Comments.DataBindings.Add("text", bsource, "comments")
            job.DataSource = tbl4
            job.DisplayMember = "job_title"
            job.ValueMember = "job_id"
            job.DataBindings.Add("selectedvalue", bsource, "job_id")


            bsourcesubscriptionDetails.Filter = "subscription_detail_id is null"
            Coach.Enabled = False

            SSource = bsourcesubscriptionDetails

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "customer_id"

            B_EndLoad = True
            If Cust.SelectedValue <> Nothing Then
                bsource.Filter = "customer_id=" & Cust.SelectedValue
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            MyDs.Tables("Subscriptions_details").Columns("Employee_id").DefaultValue = EmpIDVar
            MyDs.Tables("Subscriptions_details").Columns("Subscription_Status").DefaultValue = "„› ÊÕÂ"
            MyDs.Tables("Subscriptions_details").Columns("subscription_type").DefaultValue = "„Ã„Ê⁄Â"
            MyDs.Tables("Subscriptions_details").Columns("start_date").DefaultValue = Today
            MyDs.Tables("Subscriptions_details").Columns("shift_Detail_id").DefaultValue = CurrentShiftID
            Gcls.NewRecord()
            Type.Text = "„Ã„Ê⁄Â"
            Print.Enabled = False
            Remaining.Value = 0
            MONEY_required.Enabled = False
            No_Trainings.Enabled = False
            Remaining.Enabled = False
            '  ToDAte.Enabled = False
            ' FromDate.Enabled = False
            ToDAte.Value = Today
            FromDate.Checked = True
            ToDAte.Checked = True
            Coach.Enabled = False
            Cust.Enabled = False
            BtnExit.Enabled = True
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If CurrentShiftID = 0 Then
                cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ… ")
                Exit Sub
            End If

            If Cust.SelectedValue <> Nothing Then
                cmd.CommandText = "select count(*) from subscriptions_details where subscription_Status=N'„› ÊÕÂ' and customer_id=" & Cust.SelectedValue
                status = cmd.ExecuteScalar
            End If
            If Cust.SelectedValue = Nothing Or SubscriptionType.SelectedValue = Nothing Or No_Trainings.Value = 0 Then
                cls.MsgComplete()
            ElseIf paid.Value > MONEY_required.Value And num = 0 Then
                cls.MsgExclamation("«·„»·€ «·„œ›Ê⁄ ·« Ì„ﬂ‰ «‰ ÌﬂÊ‰ «ﬂ»— „‰ «·„»·€ «·„ ÿ·»")
            ElseIf status <> 0 Then
                cls.MsgExclamation("Â‰«ﬂ «‘ —«ﬂ „› ÊÕ »‰›” «”„ «·⁄„Ì·")
            ElseIf Coach.Enabled = True And Coach.SelectedValue = Nothing Then
                cls.MsgComplete()
            Else
                Remaining.Value = MONEY_required.Value - paid.Value
                Gcls.SaveRecord()
                cls.MsgInfo("·ﬁœ  „ ÕÃ“ «·«‘ —«ﬂ »‰Ã«Õ")
                num = 0
                Print.Enabled = True
                BtnSearch.Enabled = True
                Add_Train.Visible = False
                Add_month.Visible = False
            End If
        Catch ex As Exception
            cls.MsgExclamation("»—Ã«¡ «œŒ· Ã„Ì⁄ «·»Ì«‰«  «·‰«ﬁ’Â")
            BarCode.Text = ""
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            Gcls.DeleteRecord()
            Print.Enabled = True
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
            num = 1
            BtnSave.Enabled = True
            Add_Train.Visible = True
            Add_month.Visible = True
            Add_Train.Enabled = True
            Add_month.Enabled = True
            BtnSearch.Enabled = False
            BtnNew.Enabled = False
            the_date = ToDAte.Value
            trainings = No_Trainings.Value
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
                Gcls.SortData(bsourcesubscriptionDetails, OrderByCombo.SelectedValue)
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
            bsourcesubscriptionDetails.RemoveFilter()
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

    Private Sub SubscriptionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionType.SelectedIndexChanged
        Try
            ' If B_EndLoad = True Then
            If Type.Text = "„Ã„Ê⁄Â" Then
                cmd.CommandText = "select value_group from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                required = cmd.ExecuteScalar
                cmd.CommandText = "select no_Training+extra_training from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                no_Train = cmd.ExecuteScalar()
                MONEY_required.Value = required
                No_Trainings.Value = no_Train
                No_Subscription.Value = 1

            Else
                cmd.CommandText = "select value_single from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                required = cmd.ExecuteScalar
                cmd.CommandText = "select no_Training+extra_training from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                no_Train = cmd.ExecuteScalar()
                MONEY_required.Value = required
                No_Trainings.Value = no_Train
                No_Subscription.Value = 1

            End If
            cmd.CommandText = "select months from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
            ToDAte.Value = DateAdd(DateInterval.Month, No_Subscription.Value * cmd.ExecuteScalar, Today)
            Remaining.Value = MONEY_required.Value - paid.Value
        Catch

        End Try
    End Sub

    Private Sub paid_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles paid.ValueChanged
        If MONEY_required.Value <> Nothing And paid.Value <> Nothing Then
            Remaining.Value = MONEY_required.Value - paid.Value
        End If
    End Sub

    Private Sub No_Subscription_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles No_Subscription.ValueChanged
        Try
            No_Trainings.Value = No_Subscription.Value * no_Train
            MONEY_required.Value = No_Subscription.Value * required
            Remaining.Value = MONEY_required.Value - paid.Value
            cmd.CommandText = "select months from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
            ToDAte.Value = DateAdd(DateInterval.Month, No_Subscription.Value * cmd.ExecuteScalar, Today)
        Catch
            Exit Sub
        End Try
    End Sub

    Private Sub Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Print.Click

        Dim m As New ShowAllReports
        Dim rpt As New RptSubscriptionPrint
        Try
            cmd.CommandText = "select max(subscription_detail_id) from subscriptions_details"
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscription_Print where Subscription_Detail_id=" & cmd.ExecuteScalar
            da.SelectCommand = cmd
            MyDs.Tables("Report_Subscription_Print").Clear()
            da.Fill(MyDs.Tables("Report_Subscription_Print"))
            rpt.SetDataSource(MyDs.Tables("Report_Subscription_Print"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.ShowDialog()
        Catch
        End Try

    End Sub


 
    Private Sub Type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type.SelectedIndexChanged
        Try

            If Type.Text = "„Ã„Ê⁄Â" Then
                cmd.CommandText = "select value_group from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                required = cmd.ExecuteScalar
                cmd.CommandText = "select no_Training+extra_training from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                no_Train = cmd.ExecuteScalar()
                MONEY_required.Value = required
                No_Trainings.Value = no_Train
                No_Subscription.Value = 1
                Coach.Enabled = False
                Coach.SelectedValue = DBNull.Value
            Else
                cmd.CommandText = "select value_single from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                required = cmd.ExecuteScalar
                cmd.CommandText = "select no_Training+extra_training from subscriptions where subscription_id=" & SubscriptionType.SelectedValue
                no_Train = cmd.ExecuteScalar()
                MONEY_required.Value = required
                No_Trainings.Value = no_Train
                No_Subscription.Value = 1
                Coach.Enabled = True
            End If

            Remaining.Value = MONEY_required.Value - paid.Value
        Catch

        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New Customers
        m.ShowDialog()
        cls.RefreshData("select * from customers", tbl1)
        cls.RefreshData("select * from customers", tbl5)
        Cust.SelectedValue = DBNull.Value
    End Sub

  
    Private Sub BarCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarCode.TextChanged
        Try

            bsource.Filter = "customer_code='" & BarCode.Text & "'"

            cmd.CommandText = "select customer_id from customers where customer_Code='" & BarCode.Text & "'"
            Cust.SelectedValue = cmd.ExecuteScalar
        Catch
            Cust.SelectedValue = DBNull.Value

        End Try
    End Sub

    Private Sub Add_Train_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_Train.ValueChanged
        No_Trainings.Value = trainings + Add_Train.Value
    End Sub

    Private Sub Add_month_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_month.ValueChanged
        ToDAte.Value = DateAdd(DateInterval.Month, Add_month.Value, the_date)
    End Sub

    Private Sub Cust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cust.SelectedIndexChanged
        Try
            If BarCode.Text = "" Then
                bsource.Filter = "customer_id=" & Cust.SelectedValue

         
            End If
        Catch
        End Try
    End Sub

 
    Private Sub BarCode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarCode.Enter
        BarCode.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub BarCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        BarCode.BackColor = Color.White
    End Sub

    Private Sub No_Subscription_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles No_Subscription.Enter
        No_Subscription.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub No_Subscription_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles No_Subscription.Leave
        No_Subscription.BackColor = Color.White
    End Sub

    Private Sub paid_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles paid.Enter
        paid.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub paid_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles paid.Leave
        paid.BackColor = Color.White
    End Sub

End Class
