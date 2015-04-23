Public Class CustomersAttendance

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BsourceCustomers_Attendance As New BindingSource
    Dim CHeckDate As Date
    Dim SubStatus As String
    Dim ChecAttend As Integer
    'Set The Data Table Name
    Dim TName As String = "Customers_Attendance"
    Dim d1 As Date
    Dim customer_ID As Integer
    Dim Check_expired As Boolean
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
            'cls.RefreshData("select * from Halls ", tbl1)
            cls.RefreshData("select * from employees e,jobs j,attendance ca where j.job_id=e.job_id and e.employee_id=ca.Employee_ID and j.job_title=N'„œ—»' and ca.leave_time is null", tbl1)
            'cls.RefreshData("Select sd.subscription_detail_id as subscription_id,s.subscription_name,s.Category_ID,s.No_Training,s.Months,s.Value_Group,s.Value_Single from subscriptions s,subscriptions_details sd where s.subscription_id=sd.subscription_id", tbl2)
            cls.RefreshData("Select * from Customers", Tbl4)
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

            Gcls = New GeneralSp.NewMasterForms(TName, BsourceCustomers_Attendance, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "»Ì«‰«  «·Õ÷Ê— Ê«·«‰’—«›"
            Me.Text = Gcls.SetWTitle
            customerid.DataSource = Tbl4
            customerid.DisplayMember = "Customer_Name"
            customerid.ValueMember = "Customer_ID"
            customerid.DataBindings.Add("selectedvalue", BsourceCustomers_Attendance, "customer_Id")
            AttendDate.DataBindings.Add("Text", BsourceCustomers_Attendance, "Attend_Date")
            AttendTime.DataBindings.Add("Text", BsourceCustomers_Attendance, "Attend_Time")
        
            Subscription_ID.DataSource = tbl2
            Subscription_ID.DisplayMember = "Subscription_Name"
            Subscription_ID.ValueMember = "Subscription_ID"
            Subscription_ID.DataBindings.Add("selectedvalue", BsourceCustomers_Attendance, "Subscription_ID")

            coach.DataSource = tbl1
            coach.DisplayMember = "employee_name"
            coach.ValueMember = "employee_ID"
            coach.DataBindings.Add("selectedvalue", BsourceCustomers_Attendance, "coach_id")

            SSource = BsourceCustomers_Attendance

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Corporation_Name"



        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try

            MyDs.Tables("Customers_Attendance").Columns("Attend_Date").DefaultValue = Now.ToString("dd/MM/yyyy")
            MyDs.Tables("Customers_Attendance").Columns("Attend_Time").DefaultValue = Now.ToLongTimeString


            Gcls.NewRecord()
            B_EndLoad = True
            customerid.Enabled = False
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim Train_Value As Decimal

            If Barcode.Text = "" Then
                cls.MsgComplete()
                Barcode.Focus()
                Barcode.BackColor = Color.Red
                Exit Sub
            ElseIf customerid.Text = "" Or Subscription_ID.SelectedValue = Nothing Or coach.SelectedValue = Nothing Then
                cls.MsgComplete()
                Exit Sub
            Else
                Dim CustProID As Integer
                Dim Extra_D As Integer
                cmd.CommandText = "select procedure_master_id from procedure_master where procedure_category=N'⁄„·«¡' and reference_id=" & customerid.SelectedValue
                cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & cmd.ExecuteScalar & ",getdate())"
                CustProID = cmd.ExecuteScalar()

                cmd.CommandText = "select Extra_disc from app_preferences"
                Extra_D = cmd.ExecuteScalar


                cmd.CommandText = "select value_group/subscriptions.no_training from Subscriptions,Subscriptions_Details where Subscriptions.Subscription_ID = Subscriptions_Details.Subscription_ID and Subscription_Detail_ID=" & Subscription_ID.SelectedValue
                Train_Value = cmd.ExecuteScalar

                cmd.CommandText = "select dbo.Get_Remaining_Subscriptions(" & Subscription_ID.SelectedValue & ")"

                If cmd.ExecuteScalar - Extra_D <= CustProID Then
                    cls.MsgExclamation("⁄›Ê« Â–« «·⁄„Ì· ⁄·ÌÂ „” Õﬁ«  ÌÃ» œ›⁄ Ã“¡ „‰Â« ·ﬂÌ Ì”„Õ ·Â »«·Õ÷Ê—")
                    Exit Sub
                End If






                cmd.CommandText = "select count(*) from subscriptionS_details where subscription_detail_id=" & Subscription_ID.SelectedValue & " and '" & Today.ToString("MM/dd/yyyy") & "' between start_date and end_date"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("·ﬁœ ‰›–  ’·«ÕÌ… Â–« «·«‘ —«ﬂ »—Ã«¡  ÃœÌœ «·«‘ —«ﬂ")
                    cmd.CommandText = "update subscriptions_Details set subscription_Status=N'„€·ﬁÂ' where subscription_detail_id=" & Subscription_ID.SelectedValue
                    cmd.ExecuteNonQuery()
                    Exit Sub
                End If
                CustID = customerid.SelectedValue
                CustName = customerid.Text

                Dim result As String
                B_EndLoad = False
                customerid.Enabled = False
                d1 = CDate(AttendDate.Text)


                cmd.CommandText = "select count(*) from attendance where employee_id=" & coach.SelectedValue & " and attend_date between dateadd(day,-1,getdate()) and getdate() and leave_time is null"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("⁄›Ê« Â–« «·„œ—» €Ì— Õ«÷— «·ÌÊ„")
                    Exit Sub
                End If



                cmd.CommandText = "SELECT dbo.CHECK_Customers_ATTENDANCE (" & customerid.SelectedValue & ", '" & d1.ToString("MM/dd/yyyy") & "', " & Subscription_ID.SelectedValue & ")"
                If cmd.ExecuteScalar <= 0 Then
                    Gcls.SaveRecord()
                    Dim m As New custAlerts
                    m.ShowDialog()
                Else
                    result = MsgBox(" „  ”ÃÌ· Õ÷Ê— ·Â–« «·⁄„Ì· „‰ ﬁ»· Â·  —Ìœ «·Õ›Ÿ ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo)
                    If result = vbYes Then
                        Gcls.SaveRecord()
                        Dim m As New custAlerts
                        m.ShowDialog()

                    End If

                End If

            End If
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
                Gcls.SortData(BsourceCustomers_Attendance, OrderByCombo.SelectedValue)
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
            BsourceCustomers_Attendance.RemoveFilter()
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

  

    Private Sub customerid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles customerid.SelectedIndexChanged

        If B_EndLoad = True Then
            MyDs.Tables("Subscriptions").Rows.Clear()
            cls.RefreshData("Select * from subscriptions s,Subscriptions_Details d ,Customers c  where  c.Customer_Id = d.Customer_ID and s.Subscription_ID=d.Subscription_ID and c.Customer_Id = " & customerid.SelectedValue & " and subscription_status=N'„› ÊÕÂ'", tbl2)


            'cmd.CommandText = "Select Subscription_Name from subscriptions s,Subscriptions_Details d ,Customers c  where  c.Customer_Id =d.Customer_ID and s.Subscription_ID=d.Subscription_ID and c.Customer_Name =N'" & customerid.Text & "'"
            'dr = cmd.ExecuteReader
            'Do While dr.Read = True
            '    Subscription_ID.Items.Add(dr("Subscription_Name"))
            'Loop
            'dr.Close()

            
        End If
    End Sub

    Private Sub Barcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Barcode.GotFocus
        Barcode.BackColor = Color.FromArgb(135, 180, 209)

    End Sub


    Private Sub Barcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Barcode.TextChanged
        Try
            cmd.CommandText = "Select Customer_id from Customers where Customer_Code = N'" & Barcode.Text & "'"
            customer_ID = cmd.ExecuteScalar
            customerid.SelectedValue = customer_ID
            cls.RefreshData("select d.subscription_detail_id as subscription_id,s.subscription_name,s.Category_ID,s.No_Training,s.Months,s.Value_Group,s.Value_Single from Subscriptions s,Subscriptions_Details d where s.Subscription_ID=d.Subscription_ID  and d.Subscription_Status=N'„› ÊÕÂ' and d.Customer_ID = " & customerid.SelectedValue, tbl2)

        Catch
            customerid.SelectedValue = DBNull.Value
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
    End Sub

    Private Sub Subscription_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Subscription_ID.SelectedIndexChanged
        Try
            cmd.CommandText = "select coach_id from subscriptions_details where subscription_detail_id=" & Subscription_ID.SelectedValue
            Try
                coach.SelectedValue = cmd.ExecuteScalar
            Catch
                coach.SelectedValue = DBNull.Value
            End Try
        Catch

        End Try
    End Sub

End Class
