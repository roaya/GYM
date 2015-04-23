Public Class ReportAnyAccount

    Private rpt As New RptAccountTrans
    Dim TblBanks As New GeneralDataSet.Procedure_MasterDataTable
    Private PType As String
    Dim date1, date2 As Date
    Private FirstBalance, LastBalance As Double



    Private Sub FrmCustomerTeansaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cmd.CommandText = "select * from procedure_master order by Daily_Procedure_Name"
        da.Fill(TblBanks)
        AccountID.DataSource = TblBanks
        AccountID.DisplayMember = "Daily_Procedure_Name"
        AccountID.ValueMember = "Procedure_Master_ID"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If AccountID.Text = "" Then
            cls.MsgInfo("من فضلك اختر رقم الحساب", "")
        Else
            Me.Cursor = Cursors.WaitCursor
            MyDs.Tables("MasterRecord").Rows.Clear()
            MyDs.Tables("Tran_Ven_Cust").Rows.Clear()
            date1 = CDate(DateTimePicker1.Text)
            date2 = CDate(DateTimePicker2.Text)

            MyDs.Tables("MasterRecord").Columns("Daily_Procedure_Name").DefaultValue = AccountID.Text
            'cmd.CommandText = "select procedure_type from procedure_master where procedure_master_id = " & ComboCustomerID.SelectedValue
            'PType = cmd.ExecuteScalar
            'If PType = "مدين" Then
            cmd.CommandText = "select dbo.Get_Any_Previous_Balance(" & AccountID.SelectedValue & " , '" & date1.ToString("MM/dd/yyyy") & "') from procedure_Master where Procedure_Master_ID=" & AccountID.SelectedValue
            'End If
            FirstBalance = cmd.ExecuteScalar

            cmd.CommandText = "SELECT (select logo from app_preferences) as logo,Procedure_Desc as Tran_Desc,Procedure_Date as Tran_Date,Procedure_Value as Tran_Value,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as Logo from Procedure_Details where Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and (from_procedure_master_id = " & AccountID.SelectedValue & " or to_procedure_master_id = " & AccountID.SelectedValue & ")"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Tran_Ven_Cust"))

            cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & AccountID.SelectedValue & " , '" & date2.ToString("MM/dd/yyyy") & "') from procedure_Master where Procedure_Master_ID=" & AccountID.SelectedValue
            LastBalance = cmd.ExecuteScalar

            rpt.SetDataSource(MyDs.Tables("Tran_Ven_Cust"))

            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            rpt.SetParameterValue(0, "كشف حساب : " & AccountID.Text)
            rpt.SetParameterValue("FirstBalance", FirstBalance)
            rpt.SetParameterValue("LastBalance", LastBalance)

            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)
            Me.Cursor = Cursors.Default
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

    Private Sub CombVendor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountID.GotFocus
        AccountID.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub CombVendor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountID.Leave
        AccountID.BackColor = Color.Gainsboro
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

End Class