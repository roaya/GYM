Public Class FrmEmployeesExtra
    Dim rpt As New RptEmployeesExtra
    Dim d1, d2 As Date
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable

    Private Sub FrmEmployeesExtra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", tbl1)
        EmpID.DataSource = tbl1
        EmpID.DisplayMember = "Employee_Name"
        EmpID.ValueMember = "Employee_ID"
    End Sub

    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radall.CheckedChanged
        If Radall.Checked = True Then
            EmpID.Enabled = False

        End If
    End Sub

    Private Sub rademp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rademp.CheckedChanged
        If rademp.Checked = True Then
            EmpID.Enabled = True

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        d1 = CDate(fromdate.Text)
        d2 = CDate(todate.Text)
        MyDs.Tables("Report_Employees_Extra").Rows.Clear()
        If Radall.Checked = True Then
            cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from Report_Employees_Extra where Extra_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        Else
            If EmpID.Text = "" Then
                MsgBox("من فضلك اختر اسم الموظف")
                Exit Sub
            Else
                cmd.CommandText = "Select *,(select logo from app_preferences) as Logo from Report_Employees_Extra where Extra_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and employee_ID =" & EmpID.SelectedValue
            End If
        End If
        da.Fill(MyDs.Tables("Report_Employees_Extra"))
        rpt.SetDataSource(MyDs.Tables("Report_Employees_Extra"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer2.ReportSource = rpt
        TabControl1.SelectTab(1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class