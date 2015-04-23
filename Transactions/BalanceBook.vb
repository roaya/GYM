Public Class BalanceBook

    Dim date1, date2 As Date
    Private FirstBalance, LastBalance, FromPeriodBalance, ToPeriodBalance As Double
    Private rpt As New RptBalanceBook
    Private TblProMaster As New GeneralDataSet.Procedure_MasterDataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        date1 = CDate(DateTimePicker1.Text)
        date2 = CDate(DateTimePicker2.Text)
        MyDs.Tables("BalanceBook").Rows.Clear()
        ''cls.RefreshData(TblProMaster, "procedure_master", " Procedure_Category ")
        cls.FillSelectedTable("select * from procedure_master where procedure_master_id <> 21 order by Procedure_Category", TblProMaster)
        For i As Integer = 0 To TblProMaster.Rows.Count - 1
            r = MyDs.Tables("BalanceBook").NewRow
            r("Procedure_Master_ID") = TblProMaster.Rows(i).Item("Procedure_Master_ID")
            r("Daily_Procedure_Name") = TblProMaster.Rows(i).Item("Daily_Procedure_Name")
            If TblProMaster.Rows(i).Item("Procedure_Type") = "مدين" Then
                r("First_From_Balance") = TblProMaster.Rows(i).Item("Balance")
            Else
                r("First_To_Balance") = TblProMaster.Rows(i).Item("Balance")
            End If
            cmd.CommandText = "select dbo.Get_Any_Balance(" & TblProMaster.Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            LastBalance = cmd.ExecuteScalar
            If TblProMaster.Rows(i).Item("Procedure_Type") = "مدين" Then
                If LastBalance < 0 Then
                    r("Last_To_Balance") = LastBalance
                Else
                    r("Last_From_Balance") = LastBalance
                End If
            Else
                If LastBalance < 0 Then
                    r("Last_From_Balance") = LastBalance
                Else
                    r("Last_To_Balance") = LastBalance
                End If
            End If

            cmd.CommandText = "select isnull(sum(procedure_value),0) from procedure_details where from_procedure_master_id = " & TblProMaster.Rows(i).Item("Procedure_Master_ID")
            r("From_Balance") = cmd.ExecuteScalar
            cmd.CommandText = "select isnull(sum(procedure_value),0) from procedure_details where to_procedure_master_id = " & TblProMaster.Rows(i).Item("Procedure_Master_ID")
            r("To_Balance") = cmd.ExecuteScalar
            cmd.CommandText = "select logo from app_preferences"
            r("logo") = cmd.ExecuteScalar
            'If TblProMaster.Rows(i).Item("Procedure_Master_ID")
            MyDs.Tables("BalanceBook").Rows.Add(r)
        Next

        rpt.SetDataSource(MyDs.Tables("BalanceBook"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer1.ReportSource = rpt
        TabControl1.SelectTab(1)

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

    
End Class
