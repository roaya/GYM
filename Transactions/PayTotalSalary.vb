Public Class PayTotalSalary

    Dim ChValue As Double
    Dim ChqID, FAccID, ToAccID As Integer
    Dim d1, d2 As Date

    Private Sub TxtCheque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCheque.Leave

        If RadioBank.Checked = True Then
            If TxtCheque.Text <> "" Then
                cmd.CommandText = "select dbo.Is_Cheque_Valid('" & TxtCheque.Text & "')"
                ChqID = cmd.ExecuteScalar
                If ChqID = 0 Then
                    cls.MsgExclamation("الشيك غير صالح للاستخدام", "CURRENT CHEQUE NUMBER ISNOT VALID")
                    TxtCheque.Focus()
                    Exit Sub
                Else
                    cmd.CommandText = "select cheque_value from cheques where cheque_number = " & TxtCheque.Text
                    ChValue = cmd.ExecuteScalar
                End If
            End If
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If CDbl(TotalSalaryDep.Text) <= 0 And CDbl(TotalSalaryMarketing.Text) <= 0 Then
            cls.MsgExclamation("لا يوجد مرتبات للسداد خلال الفتره المحدده", "")
            Exit Sub
        End If
        If MsgBox("هل أنت متأكد", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            If RadioCash.Checked = True Then

                If CDbl(TotalSalaryDep.Text) > 0 Then
                    cmd.CommandText = "Exec Commit_Procedure_Tran 12,4," & TotalSalaryDep.Text & ",N'" & PaymentDesc.Text & "'"
                    cmd.ExecuteNonQuery()
                End If
                If CDbl(TotalSalaryMarketing.Text) > 0 Then
                    cmd.CommandText = "Exec Commit_Procedure_Tran 28,4," & TotalSalaryMarketing.Text & ",N'" & PaymentDesc.Text & "'"
                    cmd.ExecuteNonQuery()
                End If
            ElseIf RadioBank.Checked = True Then
                'cmd.CommandText = "select dbo.Get_Bank_Procedure_ID(" & TxtCheque.Text & ")"
                'ToAccID = cmd.ExecuteScalar
                If CDbl(TotalSalaryDep.Text) > 0 Then
                    cmd.CommandText = "Exec Commit_Procedure_Tran 12,24," & TotalSalaryDep.Text & ",N'" & PaymentDesc.Text & "'"
                    cmd.ExecuteNonQuery()
                End If
                If CDbl(TotalSalaryMarketing.Text) > 0 Then
                    cmd.CommandText = "Exec Commit_Procedure_Tran 28,24," & TotalSalaryMarketing.Text & ",N'" & PaymentDesc.Text & "'"
                    cmd.ExecuteNonQuery()
                End If
                cmd.CommandText = "UPDATE Cheques SET Cheque_Status=N'غير منصرف' WHERE Cheque_Number = '" & TxtCheque.Text & "'"
                cmd.ExecuteNonQuery()
            End If

            cls.FillSelectedTable("select * from Query_Loans where pay_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and phase_status = N'غير مدفوع'", "Query_Loans")

            For i As Integer = 0 To MyDs.Tables("Query_Loans").Rows.Count - 1
                cmd.CommandText = "exec Salary_Loan " & MyDs.Tables("Query_Loans").Rows(i).Item("Employee_ID")
                cmd.ExecuteNonQuery()
            Next

            cmd.CommandText = "update Loans_Details set Phase_Status = N'مدفوع' where Pay_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            cmd.ExecuteNonQuery()

            cls.MsgInfo("تم سداد المرتبات بنجاح", "")
        End If
    End Sub

    Private Sub PayTotalSalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        d1 = "01/" & Now.ToString("MM") & "/" & Now.ToString("yyyy")

        d2 = Date.DaysInMonth(CInt(Now.Year), CInt(Now.Month)) & "/" & Now.ToString("MM") & "/" & Now.Year
        cmd.CommandText = "select isnull(sum(P.net_salary),0) from pay_salary P,Departments D,Employees E WHERE E.Department_Id=D.Department_Id AND P.Employee_ID=E.Employee_Id AND D.Generic_Desc =N'اداريه' and p.pay_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        TotalSalaryDep.Text = cmd.ExecuteScalar

        cmd.CommandText = "select isnull(sum(P.net_salary),0) from pay_salary P,Departments D,Employees E WHERE E.Department_Id=D.Department_Id AND P.Employee_ID=E.Employee_Id AND D.Generic_Desc =N'تسويقيه' and p.pay_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        TotalSalaryMarketing.Text = cmd.ExecuteScalar

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New Cheques
        m.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class