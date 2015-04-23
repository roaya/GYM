Public Class EmployeesTasks

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceEmployees_Tasks As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Employees_Tasks"
    '-------------------------------
    Dim EditNoValidate As Boolean = True
    Private TblEmp As New GeneralDataSet.EmployeesDataTable

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(TName)
            cls.RefreshData("Select * from employees", TblEmp)
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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceEmployees_Tasks, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------



            Gcls.SetWTitle = "»Ì«‰«  «·„Â„« "
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BSourceEmployees_Tasks, "Task_Code")
            EmployeeID.DataSource = TblEmp
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"
            EmployeeID.DataBindings.Add("SelectedValue", BSourceEmployees_Tasks, "To_Employee")

            TaskTitle.TextBox1.DataBindings.Add("Text", BSourceEmployees_Tasks, "Title")
            TaskText.DataBindings.Add("Text", BSourceEmployees_Tasks, "Task_Desc")
            TaskDate.DataBindings.Add("Text", BSourceEmployees_Tasks, "Task_Date")
            Approved.DataBindings.Add("Checked", BSourceEmployees_Tasks, "Approved", vbYes)
            SSource = BSourceEmployees_Tasks

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Task_Code"

            B_EndLoad = True


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            MyDs.Tables("Employees_Tasks").Columns("From_Employee").DefaultValue = EmpIDVar
            Gcls.NewRecord()
            EditNoValidate = True
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

            ElseIf EmployeeID.Text = "" Then
                cls.MsgComplete()
            ElseIf TaskTitle.TextBox1.Text = "" Then
                cls.MsgComplete()
                TaskTitle.TextBox1.Focus()
                TaskTitle.TextBox1.BackColor = Color.Red

            ElseIf TaskText.Text = "" Then

                cls.MsgComplete()
                TaskText.Focus()
                TaskText.BackColor = Color.Red

            ElseIf TaskDate.Text < Now And EditNoValidate = True Then
                TaskDate.BackColor = Color.Yellow
                TaskDate.Focus()
                cls.MsgExclamation("»—Ã«¡ «Œ Ì«—  «—ÌŒ «ﬂ»— „‰  «—ÌŒ «·ÌÊ„", "")
            Else
                TaskText.BackColor = Color.Gainsboro
                TaskTitle.TextBox1.BackColor = Color.Gainsboro
                TaskDate.BackColor = Color.Gainsboro
                Gcls.SaveRecord()
                EditNoValidate = False
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            TaskText.BackColor = Color.Gainsboro
            TaskTitle.TextBox1.BackColor = Color.Gainsboro
            TaskDate.BackColor = Color.Gainsboro
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
                Gcls.SortData(BSourceEmployees_Tasks, OrderByCombo.SelectedValue)
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
            BSourceEmployees_Tasks.RemoveFilter()
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim aa As New Employees
        aa.ShowDialog()
        cls.RefreshData("Select * from employees", TblEmp)
    End Sub

    Private Sub TaskDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskDate.Leave
        If TaskDate.Text > Now Then
            TaskDate.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub TaskTitle_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskTitle.Leave
        If TaskTitle.TextBox1.Text <> "" Then
            TaskTitle.TextBox1.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub TaskText_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskText.GotFocus
        TaskText.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub TaskText_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskText.Leave
        If TaskText.Text <> "" Then
            TaskText.BackColor = Color.Gainsboro
        End If
    End Sub
End Class
