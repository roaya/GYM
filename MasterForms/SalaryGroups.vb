Public Class salarygroups

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BsourceSalaryGroups As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "salary_groups"
    '-------------------------------

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MasterField1.TextBox1.MaxLength = 50
            cls.RefreshData(TName)

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

            Gcls = New GeneralSp.NewMasterForms(TName, BsourceSalaryGroups, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            Gcls.SetWTitle = "بيانات بنود المرتبات"
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BsourceSalaryGroups, "group_Name")
            Min_Hours.DataBindings.Add("value", BsourceSalaryGroups, "Min_Hours")
            Work_Hours.DataBindings.Add("value", BsourceSalaryGroups, "Work_Hours")
            Extra_Hours.DataBindings.Add("value", BsourceSalaryGroups, "Extra_Hours")
            Hours_Disc.DataBindings.Add("value", BsourceSalaryGroups, "Less_Hours")
            Min_Custs.DataBindings.Add("value", BsourceSalaryGroups, "Min_Customers")
            Extra_Custs.DataBindings.Add("value", BsourceSalaryGroups, "Extra_Customers")
            Custs_Disc.DataBindings.Add("value", BsourceSalaryGroups, "Less_Customers")
            Subsc_Value.DataBindings.Add("value", BsourceSalaryGroups, "Extra_Subsc")
            GenericDesc.TextBox1.DataBindings.Add("Text", BsourceSalaryGroups, "Generic_Desc")

            SSource = BsourceSalaryGroups

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "group_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            Gcls.NewRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If MasterField1.TextBox1.Text = "" Then
                cls.MsgComplete()
                MasterField1.TextBox1.Focus()
                MasterField1.TextBox1.BackColor = Color.Red
            ElseIf Min_Hours.Value <= 0 Or Work_Hours.Value <= 0 Or Extra_Hours.Value <= 0 Or Hours_Disc.Value <= 0 Then
                cls.MsgComplete()
            Else
                Gcls.SaveRecord()
                cls.MsgInfo("لقد تم حفظ البيانات بنجاح")
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

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
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




    Private Sub OrderByCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderByCombo.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                Gcls.SortData(BsourceSalaryGroups, OrderByCombo.SelectedValue)
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
            BsourceSalaryGroups.RemoveFilter()
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


    
    Private Sub Min_Hours_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Min_Hours.Enter
        Min_Hours.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Min_Hours_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Min_Hours.Leave
        Min_Hours.BackColor = Color.Gainsboro
    End Sub

    Private Sub Work_Hours_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Work_Hours.Enter
        Work_Hours.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Work_Hours_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Work_Hours.Leave
        Work_Hours.BackColor = Color.Gainsboro
    End Sub

    Private Sub Extra_Hours_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Extra_Hours.Enter
        Extra_Hours.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Extra_Hours_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Extra_Hours.Leave
        Extra_Hours.BackColor = Color.Gainsboro
    End Sub

    Private Sub Hours_Disc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hours_Disc.Enter
        Hours_Disc.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Hours_Disc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hours_Disc.Leave
        Hours_Disc.BackColor = Color.Gainsboro
    End Sub

    Private Sub Min_Custs_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Min_Custs.Enter
        Min_Custs.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Min_Custs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Min_Custs.Leave
        Min_Custs.BackColor = Color.Gainsboro
    End Sub

    Private Sub Extra_Custs_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Extra_Custs.Enter
        Extra_Custs.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Extra_Custs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Extra_Custs.Leave
        Extra_Custs.BackColor = Color.Gainsboro
    End Sub

    Private Sub Custs_Disc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Custs_Disc.Enter
        Custs_Disc.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Custs_Disc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Custs_Disc.Leave
        Custs_Disc.BackColor = Color.Gainsboro
    End Sub

    Private Sub Subsc_Value_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Subsc_Value.Enter
        Subsc_Value.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Subsc_Value_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Subsc_Value.Leave
        Subsc_Value.BackColor = Color.Gainsboro
    End Sub



End Class
