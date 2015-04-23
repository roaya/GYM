Public Class AttendanceManagement
    Dim D As Date
    Dim T As Date
    Dim tbl As New GeneralDataSet.EmployeesDataTable
    Dim bsource As New BindingSource
    Private Sub AttendanceManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", tbl)
        Emp.DataSource = tbl
        Emp.DisplayMember = "employee_name"
        Emp.ValueMember = "employee_id"

        bsource.DataSource = MyDs
        bsource.DataMember = "attendance"

        DataGridView1.DataSource = bsource
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).HeaderText = "التاريخ"
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).HeaderText = "وقت الحضور"
        DataGridView1.Columns(3).Width = 200
        DataGridView1.Columns(4).HeaderText = "وقت الانصراف"
        DataGridView1.Columns(4).Width = 200
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Emp.SelectedValue = Nothing Or TheDate.Text = "" Then
            cls.MsgComplete()
            Exit Sub
        End If
        D = TheDate.Text
        MyDs.Tables("attendance").Rows.Clear()
        cmd.CommandText = "select * from attendance where employee_id=" & Emp.SelectedValue & " and attend_date='" & D.ToString("MM/dd/yyyy") & "'"
        da.Fill(MyDs.Tables("attendance"))
        bsource.Filter = "leave_time is not NULL"
    End Sub

    
    Private Sub Emp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Emp.SelectedIndexChanged
        Try
            MyDs.Tables("attendance").Rows.Clear()
        Catch
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim nn As Integer
            Try
                nn = DataGridView1.SelectedRows(0).Cells("serial_pk").Value

            Catch
                cls.MsgExclamation("عفو لا توجد بيانات")
                Exit Sub
            End Try
            cmd.CommandText = "update attendance set leave_time=convert(time,DATEADD(HOUR,+" & thetime.Value & ",attend_Time),101) where serial_pk=" & nn
            cmd.ExecuteNonQuery()
            cmd.CommandText = "update attendance set hours_diff=" & thetime.Value * 60 & " where serial_pk=" & nn
            cmd.ExecuteNonQuery()
            MyDs.Tables("attendance").Rows.Clear()
            cmd.CommandText = "select * from attendance where employee_id=" & Emp.SelectedValue & " and attend_date='" & D.ToString("MM/dd/yyyy") & "'"
            da.Fill(MyDs.Tables("attendance"))
            cls.MsgInfo("لقد تم تعديل الوقت بنجاح")
        Catch
            cls.MsgExclamation("برجاء التأكد من وقت الانصارف ")
        End Try
    End Sub
End Class