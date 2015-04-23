Public Class Employees

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceEmployees As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Employees"
    '-------------------------------
    Public SearchEmployeeID As Integer
    Dim tbl As New GeneralDataSet.salary_Groupsdatatable
    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from salary_Groups", tbl)
            cls.RefreshData(TName)
            cls.RefreshData("Jobs")
            cls.RefreshData("Departments")

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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceEmployees, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "»Ì«‰«  «·„ÊŸ›Ì‰"
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BSourceEmployees, "Employee_Name")
            Education.TextBox1.DataBindings.Add("Text", BSourceEmployees, "Education")
            Tele.TextBox1.DataBindings.Add("Text", BSourceEmployees, "Tele")
            Email.TextBox1.DataBindings.Add("Text", BSourceEmployees, "email")
            Mobile.TextBox1.DataBindings.Add("Text", BSourceEmployees, "Mobile")
            Address.TextBox1.DataBindings.Add("Text", BSourceEmployees, "Address")
            Basic_Salary.DataBindings.Add("Value", BSourceEmployees, "basic_salary")
            Barcode.TextBox1.DataBindings.Add("text", BSourceEmployees, "barcode")
            HireDate.DataBindings.Add("Text", BSourceEmployees, "Hire_Date")
            Variable_salary.DataBindings.Add("value", BSourceEmployees, "variable_salary")

            Group_ID.DataSource = tbl
            Group_ID.DisplayMember = "group_name"
            Group_ID.ValueMember = "group_id"
            Group_ID.DataBindings.Add("SelectedValue", BSourceEmployees, "Group_ID")


            JobID.DataSource = MyDs
            JobID.DisplayMember = "Jobs.Job_Title"
            JobID.ValueMember = "Jobs.Job_ID"
            JobID.DataBindings.Add("SelectedValue", BSourceEmployees, "Job_ID")

            DepartmentID.DataSource = MyDs
            DepartmentID.DisplayMember = "Departments.Department_Name"
            DepartmentID.ValueMember = "Departments.Department_ID"
            DepartmentID.DataBindings.Add("SelectedValue", BSourceEmployees, "Department_ID")

            Photo.DataBindings.Add("backgroundImage", BSourceEmployees, "Photo", True)

            SSource = BSourceEmployees

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Employee_Name"

            Basic_Salary.Visible = ShowSal
            Variable_salary.Visible = ShowSal
            Group_ID.Visible = ShowSal
            GeneralLabel13.Visible = ShowSal
            GeneralLabel10.Visible = ShowSal
            GeneralLabel11.Visible = ShowSal
            Button19.Visible = ShowSal

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

            ElseIf Barcode.TextBox1.Text = "" Then
                cls.MsgComplete()

                Barcode.TextBox1.Focus()
                Barcode.TextBox1.BackColor = Color.Red

            ElseIf JobID.Text = "" Then
                cls.MsgComplete()
                JobID.Focus()
            ElseIf DepartmentID.Text = "" Then
                cls.MsgComplete()
                DepartmentID.Focus()
            ElseIf Group_ID.SelectedValue = Nothing Then
                cls.MsgComplete()
                Group_ID.Focus()
            ElseIf Basic_Salary.Value <= 0 Then
                cls.MsgComplete()
                Basic_Salary.Focus()
                Basic_Salary.BackColor = Color.Gainsboro
            Else
                Gcls.SaveRecord()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            Basic_Salary.BackColor = Color.Gainsboro
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
                Gcls.SortData(BSourceEmployees, OrderByCombo.SelectedValue)
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
            BSourceEmployees.RemoveFilter()
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
        Dim ad As New Jobs
        ad.ShowDialog()
        cls.RefreshData("Jobs")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ss As New Departments
        ss.ShowDialog()
        cls.RefreshData("Departments")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            Dim Fpath As String = ""

l:
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog1.Title = "«Œ — ’Ê—… ·⁄—÷Â« ⁄·Ì «·‰«›–…"
            OpenFileDialog1.Filter = "Image Files|*.JPG;*.JPEG;*.png;*.Gif;"
            If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
                If MsgBox("·„ Ì „ «Œ Ì«— «·’Ê—… Â·  —Ìœ «⁄«œ… «·«Œ Ì«— ø", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = DialogResult.Yes Then
                    GoTo l
                End If
            Else
                Fpath = OpenFileDialog1.FileName
            End If

            Photo.BackgroundImage = Image.FromFile(Fpath)
        Catch ex As Exception
            Dim s As String = ""
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Photo.BackgroundImage = Nothing
    End Sub

    Private Sub Salary_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Basic_Salary.GotFocus
        Basic_Salary.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Salary_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Basic_Salary.Leave
        If Basic_Salary.Value > 0 Then
            Basic_Salary.BackColor = Color.Gainsboro
        End If
    End Sub

   
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New RewardsCategories
        m.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New EmployeesRewards
        m.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim m As New Extra
        m.ShowDialog()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim m As New Employeesextra
        m.ShowDialog()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim m As New DiscountCategories
        m.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim m As New EmployeesDiscounts
        m.ShowDialog()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim m As New EmployeesVacations
        m.ShowDialog()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim m As New EmployeesTasks
        m.ShowDialog()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim m As New Attendance
        m.ShowDialog()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim m As New PaySalary
        m.ShowDialog()
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim m As New Departments
        m.ShowDialog()
        cls.RefreshData("Departments")
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Dim m As New Jobs
        m.ShowDialog()
        cls.RefreshData("Jobs")
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim m As New FrmEmployees
        m.ShowDialog()
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim m As New salarygroups
        m.ShowDialog()
        cls.RefreshData("select * from salary_Groups", tbl)
    End Sub
End Class
