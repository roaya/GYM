Imports System.Linq
Public Class Loans

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BsourceLoans As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Loans"
    '-------------------------------

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(TName)
            cls.RefreshData("Employees")
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

            Gcls = New GeneralSp.NewMasterForms(TName, BsourceLoans, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "»Ì«‰«  «·”·›Â"
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BsourceLoans, "Loan_Name")
            LoanValue.DataBindings.Add("value", BsourceLoans, "Loan_Value")
            Loandate.DataBindings.Add("text", BsourceLoans, "Loan_date")
            LoanFinished.DataBindings.Add("text", BsourceLoans, "Finish_Date")
            Employee_ID.DataSource = MyDs
            Employee_ID.DisplayMember = "employees.employee_Name"
            Employee_ID.ValueMember = "employees.employee_Id"
            Employee_ID.DataBindings.Add("selectedValue", BsourceLoans, "Employee_ID")
           


            SSource = BsourceLoans

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Loan_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            MyDs.Tables("Loans").Columns("Loan_Date").DefaultValue = Now.ToString("dd/MM/yyy")
            MyDs.Tables("Loans").Columns("Finish_Date").DefaultValue = Now.ToString("dd/MM/yyy")
            Gcls.NewRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim reader As SqlClient.SqlDataReader

        Try
            If MasterField1.TextBox1.Text = "" Or LoanValue.Value <= 0 Or Employee_ID.Text = "" Then
                cls.MsgComplete()
                Return
            End If
            Dim count = MyDs.Tables(TName).AsEnumerable().Count(Function(r)  r("Employee_Id") = Employee_ID.SelectedValue.ToString And Date.Parse(r("finish_Date").ToString ()) > Date.Now )
                     If count>0 Then
                cls.MsgExclamation("·« Ì„ﬂ‰ ≈÷«›… ”·›… ·Â–« «·„ÊŸ› ·√‰Â ·„ Ì”œœ ﬁÌ„… «·”·› ﬂ«„·…")
                Return
            End If                                                              

            If LoanFinished.Value <= Loandate.Value Then
                cls.MsgExclamation(" «—ÌŒ «·”œ«œ ÌÃ» √‰ ÌﬂÊ‰ √ﬂ»— „‰  «—ÌŒ «·œ›⁄")
                Return
            End If
            If (LoanFinished.Value - Loandate.Value).TotalDays < 30 Then
                cls.MsgExclamation("«·„œ… ÌÃ» √‰  ﬂÊ‰ ‘Â— ⁄·Ï «·√ﬁ·")
                Return
            End If
            Dim months = Math.Floor((LoanFinished.Value - Loandate.Value).TotalDays / 30)
            Dim valueLimit = 0
            Dim payLimit = 0
            Dim duration = 0
            Dim loanPay = LoanValue.Value / months

            cmd.CommandText = "select Loan_Duration_Limit, Loan_Pay_Limit, Loan_Value_Limit from Salary_Groups g join Employees e on e.Group_ID = g.Group_ID where e.Employee_Id = @employeeId"
            cmd.Parameters.AddWithValue("employeeId", Employee_ID.SelectedValue)
             reader = cmd.ExecuteReader()

            If reader.HasRows Then
                Do While reader.Read()
                    Dim s = reader(0)                 
                    duration = reader.GetInt32(0)
                    payLimit = reader.GetDecimal(1)
                    valueLimit = reader.GetDecimal(2)
                Loop
            End If
            reader.Close
            cmd.CommandText=""                      
            cmd.Parameters.Clear 
            If LoanValue.Value > valueLimit And valueLimit <> 0 Then
                cls.MsgExclamation("·ﬁœ  Ã«Ê“  ﬁÌ„… Â–Â «·”·›… «·Õœ «·√ﬁ’Ï «·„”„ÊÕ »Â ·Â–« «·„ÊŸ›")
                Return
            End If
            If loanPay > payLimit And payLimit <> 0 Then
                cls.MsgExclamation("·ﬁœ  Ã«Ê“  ﬁÌ„… «·œ›⁄… «·Õœ «·√ﬁ’Ï «·„”„ÊÕ »Â ·Â–« «·„ÊŸ›")
                Return
            End If
            If months > duration And duration <> 0 Then
                cls.MsgExclamation("·ﬁœ  Ã«Ê“  „œ… Â–Â «·”·›… «·Õœ «·√ﬁ’Ï «·„”„ÊÕ »Â ·Â–« «·„ÊŸ›")
                Return
            End If

            Gcls.SaveRecord()

        Catch ex As Exception
            reader.Close
            cmd.CommandText=""                      
            cmd.Parameters.Clear 

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
                Gcls.SortData(BsourceLoans, OrderByCombo.SelectedValue)
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
            BsourceLoans.RemoveFilter()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Gcls.BtnFile()
        BtnDelete.Visible = False
    End Sub

    Private Sub BtnData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnData.Click
        Gcls.BtnData()
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click
        Gcls.BtnHelp()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New Employees
        m.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim m As New Attendance
        m.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New PaySalary
        m.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New PayTotalSalary
        m.ShowDialog()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim m As New EmployeesLoansPhases
        m.ShowDialog()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'Dim m As New Restaurant
        'm.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Dim m As New QueryByEmployee
        'm.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Dim m As New QueryEmpByJobDep
        'm.ShowDialog()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Dim m As New QueryAttendance
        'm.ShowDialog()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim m As New PaySalary
        m.ShowDialog()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Dim m As New QueryEmployeesRewards
        'm.ShowDialog()
    End Sub
End Class
