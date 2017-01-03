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
            'cmd.CommandText = "select loan_name,Loan_id from loans where loan_type=N'�����' and employee_id=" & Emp.SelectedValue
            'dr = cmd.ExecuteReader()
            'Do While dr.Read = True
            '    Loan.Items.Add(dr("Loan_Name"))

            'Loop
            'dr.Close()
            cls.RefreshData("select * from loans where employee_id=" & Emp.SelectedValue & " and loan_type=N'" & "�����" & "'", tbl)
            Loan.DataSource = tbl
            Loan.DisplayMember = "loan_name"
            Loan.ValueMember = "loan_id"



        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLoan.Click
        If Loan.Text = "" Then
            cls.MsgExclamation("����� ���� ��� �����")
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
        Dim V As Double
        

        If DG.SelectedRows.Count <= 0 Then
            cls.MsgInfo("����� ���� ������ ������ �����")
        Else
            d = DG.SelectedRows(0).Cells(4).Value
            b = DG.SelectedRows(0).Cells(3).Value
            V = DG.SelectedRows(0).Cells(2).Value

            cmd.CommandText = "select procedure_master_id from procedure_master where reference_id=" & Emp.SelectedValue & " and procedure_category=N'����� �����'"
            c = cmd.ExecuteScalar

            If b = "�����" Then
                cls.MsgExclamation("��� ������ �� ����� �� ���")
            Else
                cmd.CommandText = "update loans_details set phase_status=N'" & "�����" & "' where loan_id=" & ID & " and pay_date='" & d.ToString("MM/dd/yyyy") & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "insert into procedure_details(from_procedure_master_id,to_procedure_master_id,procedure_value,procedure_date,procedure_desc) values(" & 4 & "," & c & "," & V & ",GETDATE()" & ",N'" & "���� ��� ����" & "')"
                cmd.ExecuteNonQuery()
                cls.RefreshData("Loans_Details")

                cls.MsgInfo("��� �� ����� �����")
            End If
        End If
    End Sub
End Class
