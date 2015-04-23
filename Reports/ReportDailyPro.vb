Public Class ReportDailyPro

    Dim Rpt As New Report_Daily_Pro
    Dim date1, date2 As Date
    Dim b As Boolean = False
    Private TblProMstr As New GeneralDataSet.Procedure_MasterDataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MyDs.Tables("Report_Daily_Procedure").Rows.Clear()
            date1 = CDate(DateTimePicker1.Text)
            date2 = CDate(DateTimePicker2.Text)
            If RadioAllProcedures.Checked = True Then
                cmd.CommandText = "select *,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as Logo from Report_Daily_Procedure where Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' order by Procedure_Date"
            ElseIf RadioProcedure.Checked = True Then
                If ComboProcedureID.Text = "" Then
                    cls.MsgExclamation("اختر اسم الحساب", "please enter account name")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Daily_Procedure where Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "' and (FROM_PROCEDURE_ID = " & ComboProcedureID.SelectedValue & " or TO_PROCEDURE_ID = " & ComboProcedureID.SelectedValue & ") order by Procedure_Date"
                End If
            End If

            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Report_Daily_Procedure"))


            Rpt.SetDataSource(MyDs.Tables("Report_Daily_Procedure"))
            Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer1.ReportSource = Rpt
            TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Report_Daily_Procedure")
        End Try
    End Sub

    Private Sub RadioProcedure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProcedure.CheckedChanged
        If RadioProcedure.Checked = True Then
            ComboProcedureID.Enabled = True
        End If
    End Sub

    Private Sub RadioAllProcedures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllProcedures.CheckedChanged
        If RadioAllProcedures.Checked = True Then
            ComboProcedureID.Enabled = False
        End If
    End Sub

    Private Sub ReportDailyPro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub

    Private Sub ReportDailyPro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from Procedure_Master", TblProMstr)
        ComboProcedureID.DataSource = TblProMstr
        ComboProcedureID.ValueMember = "Procedure_Master_ID"
        ComboProcedureID.DisplayMember = "Daily_Procedure_Name"
        b = True
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class