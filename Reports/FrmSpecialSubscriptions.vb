Public Class frmspecialsubscriptions

    Private rpt As New RptSpecialSubscriptions
    Dim TblBanks As New GeneralDataSet.Procedure_MasterDataTable
    Private PType As String
    Dim date1, date2 As Date
    Dim tblcoach As New GeneralDataSet.EmployeesDataTable
    Dim tblsub As New GeneralDataSet.Special_CategoriesDataTable
    Dim tblcust As New GeneralDataSet.CustomersDataTable


    Private Sub FrmCustomerTeansaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from customers", tblcust)
        cls.RefreshData("select * from special_categories", tblsub)
        cls.RefreshData("select * from employees", tblcoach)


        cust.DataSource = tblcust
        cust.DisplayMember = "customer_name"
        cust.ValueMember = "customer_id"

        coach.DataSource = tblcoach
        coach.DisplayMember = "employee_name"
        coach.ValueMember = "employee_id"


        subsc.DataSource = tblsub
        subsc.DisplayMember = "category_name"
        subsc.ValueMember = "special_categories_name"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If DateTimePicker1.Value = Nothing Or DateTimePicker2.Value = Nothing Then
            cls.MsgInfo("من فضلك ادخل الفتره", "")
        Else
            MyDs.Tables("report_special_subscriptions").Rows.Clear()
            date1 = CDate(DateTimePicker1.Text)
            date2 = CDate(DateTimePicker2.Text)

            If byall.Checked = True Then

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))

            ElseIf bycust.Checked = True Then
                If cust.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء قم بادخال اسم العميل")
                    Exit Sub
                End If

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and customer_id = " & cust.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))

            ElseIf bycoach.Checked = True Then
                If coach.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء قم بادخال اسم المدرب")
                    Exit Sub
                End If

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and trainer_id = " & coach.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))

            ElseIf byspecial.Checked = True Then

                If subsc.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء قم بادخال نوع الجلسه")
                    Exit Sub
                End If

                cmd.CommandText = "SELECT (select logo from app_preferences) as logo,* from report_Special_subscriptions where special_subscription_date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and custspecial_categories_id = " & subsc.SelectedValue
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_Special_subscriptions"))
            End If

            rpt.SetDataSource(MyDs.Tables("report_Special_subscriptions"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Leave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.GotFocus
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub byall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall.CheckedChanged
        If byall.Checked = True Then
            coach.Enabled = False
            cust.Enabled = False
            subsc.Enabled = False
        End If
    End Sub


    Private Sub bycoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycoach.CheckedChanged
        If bycoach.Checked = True Then
            coach.Enabled = True
            cust.Enabled = False
            subsc.Enabled = False
        End If
    End Sub

    Private Sub byspecial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byspecial.CheckedChanged
        If byspecial.Checked = True Then
            coach.Enabled = False
            cust.Enabled = False
            subsc.Enabled = True
        End If
    End Sub

    Private Sub bycust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycust.CheckedChanged
        If bycust.Checked = True Then
            coach.Enabled = False
            cust.Enabled = True
            subsc.Enabled = False
        End If
    End Sub
End Class