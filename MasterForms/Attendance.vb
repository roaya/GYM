Public Class Attendance

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceAttendance As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Attendance"
    Dim d As Date
    '-------------------------------
    Private TblEmp As New GeneralDataSet.EmployeesDataTable
    Private TblShifts As New GeneralDataSet.Shifts_DetailsDataTable
    Private tblHalls As New GeneralDataSet.HallsDataTable
    Dim shift As Integer
    Dim EmpId As Integer
    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub
    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData(TName)
            cls.RefreshData(TblEmp, "Employees")
            cls.RefreshData(TblShifts, "shifts_details")
            cls.RefreshData(tblHalls, "Halls")

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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceAttendance, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, , CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "«·Õ÷Ê— Ê «·«‰’—«›"
            Me.Text = Gcls.SetWTitle

            EmployeeID.DataSource = TblEmp
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"
            EmployeeID.DataBindings.Add("SelectedValue", BSourceAttendance, "Employee_ID")



            AttendanceDate.DataBindings.Add("Text", BSourceAttendance, "Attend_Date")
            AttendanceTime.DataBindings.Add("Text", BSourceAttendance, "Attend_time")

            SSource = BSourceAttendance

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_Name"

            B_EndLoad = True


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            MyDs.Tables("attendance").Columns("attend_date").DefaultValue = Today
            MyDs.Tables("attendance").Columns("attend_time").DefaultValue = Now.TimeOfDay
            'Shift_Detail.DisplayMember = shift
            Gcls.NewRecord()
            AttendanceDate.Text = Today
            AttendanceDate.Enabled = False
            AttendanceTime.Text = Now
            AttendanceTime.Enabled = False
            EmployeeID.Enabled = False
            Barcode.Focus()
            Barcode.Text = ""
            BtnExit.Enabled = True
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
    Private Sub Barcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Barcode.KeyDown

        Try
            If e.KeyValue = Keys.Enter Then
                cmd.CommandText = "select count(*) from attendance where attend_date>'" & Today.ToString("MM/dd/yyyy") & "'"
                If cmd.ExecuteScalar() > 0 Then
                    cls.MsgExclamation("⁄›Ê« ·« Ì„ﬂ‰ﬂ  ”ÃÌ· Õ÷Ê— »Â–« «·ÌÊ„ »—Ã«¡  ’ÕÌÕ «· «—ÌŒ")
                    Exit Sub
                End If

                If Barcode.Text = "" Or EmployeeID.SelectedValue = Nothing Then
                    cls.MsgCritical("»—Ã«¡ «œŒ«· »«—ﬂÊœ ’ÕÌÕ ··„ÊŸ›")
                    Exit Sub
                End If


                If EmployeeID.Text = "" Then
                    cls.MsgComplete()
                    Exit Sub
                End If
                d = AttendanceDate.Text

                cmd.CommandText = "execute Commit_Attendance_LeaveTime " & EmployeeID.SelectedValue
                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT dbo.CHECK_ATTENDANCE(" & EmployeeID.SelectedValue & ",'" & d.ToString("MM/dd/yyyy") & "')"
                If cmd.ExecuteScalar = 0 Then
                    d = d.AddDays(-1)
                    cmd.CommandText = "SELECT dbo.CHECK_ATTENDANCE(" & EmployeeID.SelectedValue & ",'" & d.ToString("MM/dd/yyyy") & "')"
                    If cmd.ExecuteScalar <> 0 Then
                        cmd.CommandText = "update attendance set leave_time=getdate() where serial_pk=" & cmd.ExecuteScalar
                        cmd.ExecuteNonQuery()
                        cls.MsgInfo("·ﬁœ  „  ”ÃÌ· «‰’—«› ··„ÊŸ› »‰Ã«Õ")
                        cmd.CommandText = "select isnull(shift_detail_id,0) from shifts_details where end_money is null and employee_id=" & EmployeeID.SelectedValue
                        If cmd.ExecuteScalar <> 0 And EmployeeID.SelectedValue = EmpIDVar Then
                            cmd.CommandText = "update shifts_details set end_date = getdate() , end_money = 0 , real_end_time = ' " & Now.ToLongTimeString & "' where shift_detail_id = " & cmd.ExecuteScalar
                            cmd.ExecuteNonQuery()
                            cls.MsgInfo("·ﬁœ  „ «€·«ﬁ «·Ê—œÌÂ «·„— »ÿ… »«·„ÊŸ› ")
                            INC = 1
                            Dim m As New FrmReportIncome
                            m.ShowDialog()
                            INC = 0
                            CurrentShiftId = 0
                        End If
                        Barcode.Text = ""
                        Barcode.Enabled = False
                        BtnNew.Enabled = True
                        Exit Sub
                    End If
                Else

                    cmd.CommandText = "update attendance set leave_time=getdate() where serial_pk=" & cmd.ExecuteScalar
                    cmd.ExecuteNonQuery()
                    cls.MsgInfo("·ﬁœ  „  ”ÃÌ· «‰’—«› ··„ÊŸ› »‰Ã«Õ")

                    cmd.CommandText = "select isnull(shift_detail_id,0) from shifts_details where end_money is null and employee_id=" & EmployeeID.SelectedValue
                    If cmd.ExecuteScalar <> 0 And EmployeeID.SelectedValue = EmpIDVar Then
                        cmd.CommandText = "update shifts_details set end_date = getdate() , end_money = 0 , real_end_time = ' " & Now.ToLongTimeString & "' where shift_detail_id = " & cmd.ExecuteScalar
                        cmd.ExecuteNonQuery()
                        cls.MsgInfo("·ﬁœ  „ «€·«ﬁ «·Ê—œÌÂ «·„— »ÿ… »«·„ÊŸ› ")
                        INC = 1
                        Dim m As New FrmReportIncome
                        m.ShowDialog()
                        INC = 0
                        CurrentShiftId = 0
                    End If
                    Barcode.Text = ""
                    Barcode.Enabled = False
                    BtnNew.Enabled = True
                    Exit Sub
                End If


                cmd.CommandText = "select COUNT(*) FROM Employees_Vacations WHERE '" & d.ToString("MM/dd/yyyy") & "' BETWEEN From_Date AND To_Date and employee_id = " & EmployeeID.SelectedValue
                If cmd.ExecuteScalar > 0 Then
                    cls.MsgExclamation(" „  ”ÃÌ· »Ì«‰«  Â–« «·„ÊŸ› ﬂ√Ã«“… ›Ì Â–Â «·› —…", "this employee has requested a vacation during this period and cannot register today please remove his record from vacations data")
                    Exit Sub
                Else

                    cmd.CommandText = "insert into attendance(employee_id,attend_date,attend_time,hours_diff) values(" & EmployeeID.SelectedValue & ",getdate(),getdate(),0)"
                    cmd.ExecuteNonQuery()
                    Barcode.Enabled = False
                    BtnNew.Enabled = True
                    cls.MsgInfo("·ﬁœ  „  ”ÃÌ· Õ÷Ê— «·„ÊŸ› »‰Ã«Õ")
                    Barcode.Text = ""
                End If


                cls.RefreshData(TName)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            AttendanceTime.BackColor = Color.Gainsboro
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
                Gcls.SortData(BSourceAttendance, OrderByCombo.SelectedValue)
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
            BSourceAttendance.RemoveFilter()
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ss As New Employees
        ss.ShowDialog()
        cls.RefreshData("Employees", " Employee_ID ")
    End Sub

    Private Sub AttendanceTime_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        AttendanceTime.BackColor = Color.FromArgb(135, 180, 209)
    End Sub


    Private Sub AttendanceTime_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AttendanceTime.BackColor = Color.Gainsboro
    End Sub

    Private Sub AttendanceDate_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        AttendanceDate.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Barcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Barcode.TextChanged
        Try
            cmd.CommandText = "select employee_id from employees where barcode='" & Barcode.Text & "'"
            EmployeeID.SelectedValue = cmd.ExecuteScalar
        Catch
            EmployeeID.SelectedValue = DBNull.Value
        End Try
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New Employees
        m.ShowDialog()
        cls.RefreshData(TblEmp, "Employees")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New Halls
        m.ShowDialog()
        cls.RefreshData(tblHalls, "Halls")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim m As New ReportEmpAttendance
        m.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New ReportEmpPayingSalary
        m.ShowDialog()
    End Sub




End Class
