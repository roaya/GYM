Public Class ReportAnyAccountBalance

    Dim date1, date2 As Date
    Dim Rpt As New RptMoneyPayments
    Dim RptDailyPro As New Report_Daily_Pro
    Private TblProMstr As New GeneralDataSet.Procedure_MasterDataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MyDs.Tables("Money_Payments").Rows.Clear()
            MyDs.Tables("Report_Daily_Procedure").Rows.Clear()

            date1 = CDate(DateTimePicker1.Text)
            date2 = CDate(DateTimePicker2.Text)
            If RadioDetails.Checked = True Then
                If RadioAccountID.Checked = True Then
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Daily_Procedure where Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and (FROM_PROCEDURE_ID = " & ComboAccountID.SelectedValue & " or TO_PROCEDURE_ID = " & ComboAccountID.SelectedValue & ") order by Procedure_Date"
                ElseIf RadioCategoryID.Checked = True Then
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from New_Report_Daily_Procedure where Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and (procedure_category = N'" & ComboAccountCategory.Text & "' or procedure_category2 = N'" & ComboAccountCategory.Text & "')"
                End If

                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Daily_Procedure"))
                RptDailyPro.SetDataSource(MyDs.Tables("Report_Daily_Procedure"))
                RptDailyPro.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = RptDailyPro

            ElseIf RadioTotal.Checked = True Then

                If RadioAccountID.Checked = True Then
                    cmd.CommandText = "select daily_procedure_name,(select logo from app_preferences) as logo , dbo.Get_Any_Previous_Balance(Procedure_Master_ID,'" & date2.ToString("MM/dd/yyyy") & "') as Procedure_Balance , Procedure_Category , Procedure_Type  from Procedure_Master where procedure_master_id = " & ComboAccountID.SelectedValue
                ElseIf RadioCategoryID.Checked = True Then
                    cmd.CommandText = "select daily_procedure_name,(select logo from app_preferences) as logo , dbo.Get_Any_Previous_Balance(Procedure_Master_ID,'" & date2.ToString("MM/dd/yyyy") & "') as Procedure_Balance , Procedure_Category , Procedure_Type  from Procedure_Master where procedure_category = N'" & ComboAccountCategory.Text & "'"
                End If

                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Money_Payments"))
                Rpt.SetDataSource(MyDs.Tables("Money_Payments"))
                Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                CrystalReportViewer1.ReportSource = Rpt

            End If
            TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "money_payments")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ReportMoneyPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd.CommandText = "select distinct procedure_category from procedure_master"
        dr = cmd.ExecuteReader
        Do While dr.Read = True
            ComboAccountCategory.Items.Add(dr("procedure_category"))
        Loop
        dr.Close()

        cls.RefreshData("select * from procedure_master order by procedure_category", TblProMstr)
        ComboAccountID.DataSource = TblProMstr
        ComboAccountID.DisplayMember = "Daily_Procedure_Name"
        ComboAccountID.ValueMember = "Procedure_Master_ID"

    End Sub

    Private Sub RadioCategoryID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCategoryID.CheckedChanged
        If RadioCategoryID.Checked = True Then
            ComboAccountCategory.Enabled = True
            ComboAccountID.Enabled = False
        End If
    End Sub

    Private Sub RadioAccountID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAccountID.CheckedChanged
        If RadioAccountID.Checked = True Then
            ComboAccountCategory.Enabled = False
            ComboAccountID.Enabled = True
        End If
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

   

End Class