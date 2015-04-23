Public Class Shifts_details
    ''''' Dim BSourceShiftsDetails As BindingSource

    Dim B_EndLoad As Boolean = False
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Shifts_Details"
    Dim t As New DataTable
    Dim T_Delivery, T_Takeaway, T_Sales, T_End_Money, T_Returns, T_Expenses, T_Purchase, T_Receive, T_Payment As Double
    Dim d As Date
    '-------------------------------
    Private Sub Shifts_Details_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Shiftsdetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData("Shifts")
            cls.RefreshData(TName)

            Me.Text = " ›«’Ì· «·Ê—œÌ…"


            ShiftID.DataSource = MyDs
            ShiftID.DisplayMember = "Shifts.Shift_Name"
            ShiftID.ValueMember = "Shifts.Shift_ID"

            cmd.CommandText = "select * from query_shifts where end_money is null order by end_date desc"
            da.SelectCommand = cmd
            da.Fill(t)
            DataGridView1.DataSource = t
            DataGridView1.Columns(0).HeaderText = "«”„ «·Ê—œÌÂ"
            DataGridView1.Columns(1).HeaderText = "—’Ìœ «·»œ«ÌÂ"
            DataGridView1.Columns(2).HeaderText = "—’Ìœ «·‰Â«ÌÂ"
            DataGridView1.Columns(3).HeaderText = " «—ÌŒ «·»œ«ÌÂ"
            DataGridView1.Columns(4).HeaderText = " «—ÌŒ «·‰Â«ÌÂ"
            DataGridView1.Columns(5).HeaderText = "Êﬁ  «·»œ«ÌÂ"
            DataGridView1.Columns(6).HeaderText = "Êﬁ  «·‰Â«ÌÂ"
            DataGridView1.Columns(7).HeaderText = "«”„ «·„ÊŸ›"
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(9).Visible = False



            RVal = "Shift_ID"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try

            If ShiftID.SelectedValue = Nothing Then
                cls.MsgExclamation("»—Ã«¡ «Œ Ì«— ‰Ê⁄ «·Ê—œÌÂ")
                Exit Sub
            End If
            If CurrentShiftId <> 0 Then
                cls.MsgExclamation("ÌÃ» «€·«ﬁ «·Ê—œÌÂ «·„› ÊÕÂ √Ê·«", "")
            Else
                cmd.CommandText = "select count(*) from attendance where leave_time is null and convert(date,attend_date,101)=convert(date,getdate(),101) and employee_id=" & EmpIDVar
                If cmd.ExecuteScalar = 0 Then
                    If MessageBox.Show(" ·« Ì„ﬂ‰ﬂ › Õ Ê—œÌÂ ⁄·Ï „ÊŸ› ·„ Ì”Ã· Õ÷Ê— Â·  —Ìœ  ”ÃÌ· Õ÷Ê— «·√‰", "GYM", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = vbYes Then
                        cmd.CommandText = "update attendance set leave_time=attend_time where leave_time is null and employee_id=" & EmpIDVar
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "insert into attendance(employee_id,attend_date,attend_time,hours_diff) values(" & EmpIDVar & ",getdate(),getdate(),0)"
                        cmd.ExecuteNonQuery()
                    Else
                        Exit Sub
                    End If

                End If


                cmd.CommandText = "select count(*) from shifts_details where end_date is null"
                If cmd.ExecuteNonQuery <= 0 Then
                    'cmd.CommandText = "select count(*) from sales_header where order_status = 0"
                    'If cmd.ExecuteScalar > 0 Then
                    '    cls.MsgCritical("ÌÃ» «€·«ﬁ ﬂ«›… ›Ê« Ì— «·„»Ì⁄«  «·„› ÊÕÂ", "sales orders must be closed first")
                    '    Exit Sub
                    'End If


                    cmd.CommandText = "insert into shifts_details(shift_id,start_money,start_date,real_start_time,employee_id) values(" & ShiftID.SelectedValue & "," & StartMoney.Value & ", getdate() , '" & Now.ToLongTimeString & "' , " & EmpIDVar & ")"
                    cmd.ExecuteNonQuery()
                    t.Rows.Clear()
                    cmd.CommandText = "select * from query_shifts where end_money is null order by end_date desc"
                    da.SelectCommand = cmd
                    da.Fill(t)

                    cmd.CommandText = "select max(shift_detail_id) from shifts_details"
                    CurrentShiftId = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT S.SHIFT_NAME FROM SHIFTS S,SHIFTS_DETAILS D WHERE S.Shift_ID=D.SHIFT_ID AND D.SHIFT_DETAIL_ID=" & CurrentShiftId
                    CurrentShiftName = cmd.ExecuteScalar

                    cls.MsgInfo(" „ › Õ «·Ê—œÌÂ «·ÃœÌœÂ »‰Ã«Õ", "new shift has been started successfully")
                Else
                    cls.MsgCritical("»—Ã«¡ «€·«ﬁ «·Ê—œÌÂ «·„› ÊÕÂ √Ê·«", "please close the opened shift first")
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim m As New FrmReportIncome
            If DataGridView1.SelectedRows.Count <= 0 Then
                cls.MsgExclamation("«Œ — «·Ê—œÌÂ «·„—«œ «€·«ﬁÂ«", "please select the shift which will be closed")
            Else
                '--------------------------------------------------
                'cmd.CommandText = "select count(*) from sales_header where order_status = 0"
                'If cmd.ExecuteScalar > 0 Then
                '    cls.MsgCritical("ÌÃ» «€·«ﬁ ﬂ«›… ›Ê« Ì— «·„»Ì⁄«  «·„› ÊÕÂ", "sales orders must be closed first")
                '    Exit Sub
                'End If

                cmd.CommandText = "select employee_id from shifts_Details where shift_detail_id=" & DataGridView1.SelectedRows(0).Cells("shift_detail_id").Value
                If EmpIDVar <> cmd.ExecuteScalar Then
                    cls.MsgExclamation("⁄›Ê« Â–Â «·Ê—œÌ… ·«  Œ’ﬂ Ê ·« Ì„ﬂ‰ﬂ «€·«ﬁ Ê—œÌ«  «·„ÊŸ›Ì‰ «·√Œ—Ì‰")
                    Exit Sub
                End If

                cmd.CommandText = "select count(*) from shifts_details where shift_id = " & DataGridView1.SelectedRows(0).Cells("Shift_id").Value & " and end_date is null"
                If cmd.ExecuteScalar > 0 Then
                    cmd.CommandText = "select isnull(sum(total_bill),0) from sales_header where shift_detail_id = " & DataGridView1.SelectedRows(0).Cells("Shift_detail_id").Value
                    T_Sales = cmd.ExecuteScalar
                    cmd.CommandText = "select isnull(sum(total_bill),0) from return_c_header where shift_detail_id = " & DataGridView1.SelectedRows(0).Cells("Shift_detail_id").Value
                    T_Returns = cmd.ExecuteScalar
                    cmd.CommandText = "select isnull(sum(rec_value),0) from Money_Receivables where shift_detail_id = " & DataGridView1.SelectedRows(0).Cells("Shift_detail_id").Value
                    T_Receive = cmd.ExecuteScalar

                    '===================================

                    cmd.CommandText = "select isnull(sum(total_bill),0) from purchase_header where shift_detail_id = " & DataGridView1.SelectedRows(0).Cells("Shift_detail_id").Value
                    T_Purchase = cmd.ExecuteScalar
                    cmd.CommandText = "select isnull(sum(pay_value),0) from Money_Payables where shift_detail_id = " & DataGridView1.SelectedRows(0).Cells("Shift_detail_id").Value
                    T_Payment = cmd.ExecuteScalar
                    '===================================

                    cmd.CommandText = "update shifts_details set end_date = getdate() , end_money = 0 , real_end_time = ' " & Now.ToLongTimeString & "' where shift_detail_id = " & CurrentShiftId
                    cmd.ExecuteNonQuery()

                    t.Rows.Clear()
                    cmd.CommandText = "select * from query_shifts where end_money is null order by end_date desc"
                    da.SelectCommand = cmd
                    da.Fill(t)
                    cls.MsgInfo(" „ «€·«ﬁ «·Ê—œÌÂ »‰Ã«Õ", "selected period has been closed successfully")
                    cmd.CommandText = "execute Commit_Attendance_LeaveTime " & EmpIDVar
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select count(*) from attendance where leave_time is null and employee_id=" & EmpIDVar
                    If cmd.ExecuteScalar <> 0 Then
                        If MessageBox.Show("«‰  ·„  ”Ã· «‰’—«›ﬂ »⁄œ Â·  —Ìœ  ”ÃÌ· «‰’—«› «·√‰", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
                            d = Today.ToString
                            cmd.CommandText = "SELECT dbo.CHECK_ATTENDANCE(" & EmpIDVar & ",'" & d.ToString("MM/dd/yyyy") & "')"
                            If cmd.ExecuteScalar = 0 Then
                                d = d.AddDays(-1)
                                cmd.CommandText = "SELECT dbo.CHECK_ATTENDANCE(" & EmpIDVar & ",'" & d.ToString("MM/dd/yyyy") & "')"
                                If cmd.ExecuteScalar <> 0 Then
                                    cmd.CommandText = "update attendance set leave_time=getdate() where serial_pk=" & cmd.ExecuteScalar
                                    cmd.ExecuteNonQuery()
                                    cls.MsgInfo("·ﬁœ  „  ”ÃÌ· «‰’—«› ··„ÊŸ› »‰Ã«Õ")
                                    INC = 1
                                    m.ShowDialog()
                                    INC = 0
                                    CurrentShiftId = 0
                                    Exit Sub
                                End If
                            Else
                                cmd.CommandText = "update attendance set leave_time=getdate() where serial_pk=" & cmd.ExecuteScalar
                                cmd.ExecuteNonQuery()
                                cls.MsgInfo("·ﬁœ  „  ”ÃÌ· «‰’—«› ··„ÊŸ› »‰Ã«Õ")
                                INC = 1
                                m.ShowDialog()
                                INC = 0
                                CurrentShiftId = 0
                                Exit Sub
                            End If
                        End If
                    End If

                    INC = 1
                    m.ShowDialog()
                    INC = 0
                    CurrentShiftId = 0
                    Exit Sub
                Else

                    cls.MsgExclamation("Â–Â «·Ê—œÌÂ  „ «€·«ﬁÂ« „”»ﬁ«", "this shift has been closed before")
                End If

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


End Class
