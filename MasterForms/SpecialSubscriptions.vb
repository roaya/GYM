Public Class SpecialSubscriptions

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim bsourcespecialsubscriptions As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Special_Subscriptions"
    '-------------------------------
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.CustomersDataTable
    Dim tbl3 As New GeneralDataSet.Special_CategoriesDataTable
    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(TName)
            cls.RefreshData("select * from employees e,jobs j where j.job_id=e.job_id and j.job_title=N'„œ—»'", tbl1)
            cls.RefreshData("select * from customers", tbl2)
            cls.RefreshData("select * from special_categories", tbl3)

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

            Gcls = New GeneralSp.NewMasterForms(TName, bsourcespecialsubscriptions, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "»Ì«‰«  «·Ã·”«  «·Œ«’Â"
            Me.Text = Gcls.SetWTitle
            Trainer.DataSource = tbl1
            Trainer.DisplayMember = "employee_name"
            Trainer.ValueMember = "employee_id"
            Trainer.DataBindings.Add("selectedvalue", bsourcespecialsubscriptions, "trainer_id")
            Customer.DataSource = tbl2
            Customer.DisplayMember = "customer_name"
            Customer.ValueMember = "customer_id"
            Customer.DataBindings.Add("selectedvalue", bsourcespecialsubscriptions, "customer_id")
            Value.DataBindings.Add("value", bsourcespecialsubscriptions, "value")
            Percent.DataBindings.Add("value", bsourcespecialsubscriptions, "Percentage")
            SubDate.DataBindings.Add("text", bsourcespecialsubscriptions, "special_subscription_Date")
            Subscription.DataSource = tbl3
            Subscription.DisplayMember = "category_name"
            Subscription.ValueMember = "special_categories_id"
            Subscription.DataBindings.Add("selectedvalue", bsourcespecialsubscriptions, "special_categories_id")


            SSource = bsourcespecialsubscriptions

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "trainer_id"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            MyDs.Tables("special_subscriptions").Columns("special_subscription_Date").DefaultValue = Today
            MyDs.Tables("special_subscriptions").Columns("shift_detail_id").DefaultValue = CurrentShiftID

            Gcls.NewRecord()
            Value.Enabled = False
            Percent.Enabled = False
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


            If Customer.Text = "" Or Trainer.Text = "" Or Subscription.Text = "" Then
                cls.MsgComplete()
            ElseIf Value.Value <= 0 Then
                cls.MsgComplete()
                Value.Focus()
                Value.BackColor = Color.Red
                End

            ElseIf Percent.Value <= 0 Then
                cls.MsgComplete()
                Percent.Focus()
                Percent.BackColor = Color.Red
            Else

                Gcls.SaveRecord()
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
                Gcls.SortData(bsourcespecialsubscriptions, OrderByCombo.SelectedValue)
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
            bsourcespecialsubscriptions.RemoveFilter()
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

    Private Sub Subscription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Subscription.SelectedIndexChanged
        Try
            cmd.CommandText = "select value from special_categories where special_categories_id=" & Subscription.SelectedValue
            Value.Value = cmd.ExecuteScalar
            cmd.CommandText = "select coach_percent from special_categories where special_categories_id=" & Subscription.SelectedValue
            Percent.Value = cmd.ExecuteScalar

        Catch

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New SpecialCategories
        m.ShowDialog()
        cls.RefreshData("Special_Categories")
    End Sub

   
End Class
