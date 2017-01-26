Imports System.Linq
Public Class EmployeesLoansPhases

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceLoanDetails As New BindingSource
    Dim tbl As New GeneralDataSet.LoansDataTable
    Dim ID As Integer
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Loans_Details"
    '-------------------------------

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        B_EndLoad = False
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cls.RefreshData(TName)
            cls.RefreshData("employees")
            cls.RefreshData("Loans")


            Emp.DataSource = MyDs
            Emp.DisplayMember = "employees.employee_name"
            Emp.ValueMember = "employees.employee_id"




            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub Emp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Emp.SelectedIndexChanged
        If B_EndLoad = True Then
            'Loan.Items.Clear()
            'cmd.CommandText = "select loan_name,Loan_id from loans where loan_type=N'ÃœÊ·Â' and employee_id=" & Emp.SelectedValue
            'dr = cmd.ExecuteReader()
            'Do While dr.Read = True
            '    Loan.Items.Add(dr("Loan_Name"))

            'Loop
            'dr.Close()
            cls.RefreshData("select * from loans where employee_id=" & Emp.SelectedValue, tbl)
            Loan.DataSource = tbl
            Loan.DisplayMember = "loan_name"
            Loan.ValueMember = "loan_id"



        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLoan.Click
        If Loan.Text = "" Then
            cls.MsgExclamation("»—Ã«¡ «Œ — «”„ «·ﬁ—÷")
        Else
            ID = Loan.SelectedValue
            BSourceLoanDetails.DataSource = MyDs
            BSourceLoanDetails.DataMember = "loans_details"
            BSourceLoanDetails.Filter = "loan_id=" & Loan.SelectedValue
            Phase_Value.DataPropertyName = "phase_value"
            Phase_Status.DataPropertyName = "phase_status"
            Phase_Date.DataPropertyName = "pay_date"
            DG.DataSource = BSourceLoanDetails
            DG.Columns(0).Visible = False
            DG.Columns(1).Visible = False

            Pay.Enabled = True
        End If

    End Sub

    Private Sub Pay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pay.Click

        Dim d As Date
        Dim b As String
        Dim c As Integer
        Dim v As Double


        If DG.SelectedRows.Count <= 0 And Value.Value = 0 Then
            cls.MsgInfo("»—Ã«¡ «Œ — «·› —… «·„—«œ œ›⁄Â«")
        Else
            cmd.CommandText = "select procedure_master_id from procedure_master where reference_id=" & Emp.SelectedValue & " and procedure_category=N'√—’œÂ „œÌ‰Â'"
            c = cmd.ExecuteScalar
            cmd.CommandText = "select isnull(max(rec_ID),1) from Money_Receivables"
            Dim recId = Integer.Parse(cmd.ExecuteScalar) + 1

            If DG.SelectedRows.Count > 0 Then
                d = DG.SelectedRows(0).Cells(4).Value
                b = DG.SelectedRows(0).Cells(3).Value
                v = DG.SelectedRows(0).Cells(2).Value

                If b = "„œ›Ê⁄" Then
                    cls.MsgExclamation("Â–Â «·› —Â  „ œ›⁄Â« „‰ ﬁ»·")
                Else
                    cmd.CommandText = "update loans_details set phase_status=N'" & "„œ›Ê⁄" & "' where loan_id=" & ID & " and pay_date='" & d.ToString("MM/dd/yyyy") & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "insert into procedure_details(from_procedure_master_id,to_procedure_master_id,procedure_value,procedure_date,procedure_desc) values(" & 4 & "," & c & "," & v & ",GETDATE()" & ",N'" & "”œ«œ ﬁ”ÿ ”·›Â" & "')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO Money_Receivables(Rec_ID,From_Procedure_Master_ID,Rec_Date,Rec_Value,Rec_Type)VALUES(" & recId & "," & c & ",GETDATE()," & v & ",N'" & "‰ﬁœÌ" & "')"
                    cmd.ExecuteNonQuery()

                End If
            Else
                Dim startDate As Date
                Dim endDate As Date
                Dim rows = DG.Rows.Cast(Of DataGridViewRow)().Where(Function(r) r.Cells(3).Value.ToString() <> "„œ›Ê⁄").ToList
                Dim sum = rows.Select(Of Double)(Function(r) r.Cells(2).Value).Sum
                Dim total As Double = 0
                Dim index = rows.Count - 1
                Dim val = rows(index).Cells(2).Value

                If sum < Value.Value Then
                    cls.MsgExclamation("«·ﬁÌ„… «·„œŒ·… √ﬂ»— „‰ „« ÌÃ» ”œ«œÂ")
                    Return
                End If
                endDate = rows(index).Cells(4).Value
                If Value.Value < val Then
                    cmd.CommandText = "update loans_details set phase_value= phase_value - " & Value.Value & " where loan_id=" & ID & " and pay_date ='" & startDate.ToString("MM/dd/yyyy") & "'"
                    cmd.ExecuteNonQuery()
                Else
                    While total + val <= Value.Value
                        startDate = rows(index).Cells(4).Value
                        total += rows(index).Cells(2).Value
                        index -= 1
                        val = rows(index).Cells(2).Value
                    End While
                    If total < Value.Value Then
                        Dim lastDate As Date = rows(index).Cells(4).Value
                        cmd.CommandText = "update loans_details set phase_value= phase_value - " & Value.Value - total & " where loan_id=" & ID & " and pay_date ='" & lastDate.ToString("MM/dd/yyyy") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    cmd.CommandText = "update loans_details set phase_status=N'" & "„œ›Ê⁄" & "' where loan_id=" & ID & " and pay_date >='" & startDate.ToString("MM/dd/yyyy") & "'" & " and pay_date <='" & endDate.ToString("MM/dd/yyyy") & "'"
                    cmd.ExecuteNonQuery()
                End If
                cmd.CommandText = "insert into procedure_details(from_procedure_master_id,to_procedure_master_id,procedure_value,procedure_date,procedure_desc) values(" & 4 & "," & c & "," & Value.Value & ",GETDATE()" & ",N'" & "”œ«œ ﬁ”ÿ ”·›Â" & "')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO Money_Receivables(Rec_ID,From_Procedure_Master_ID,Rec_Date,Rec_Value,Rec_Type)VALUES(" & recId & "," & c & ",GETDATE()," & Value.Value & ",N'" & "‰ﬁœÌ" & "')"
                cmd.ExecuteNonQuery()


            End If
            cls.RefreshData("Loans_Details")
            cls.MsgInfo("·ﬁœ  „ «·œ›⁄ »‰Ã«Õ")
        End If
    End Sub
End Class
