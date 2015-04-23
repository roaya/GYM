Public Class MasterRecord

    Dim date1, date2 As Date
    Dim rpt As New RptMasterRecord
    Private PType As String

    Private Sub MasterRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("Procedure_Master")
        ComboProcedureID.DataSource = MyDs
        ComboProcedureID.ValueMember = "Procedure_Master.Procedure_Master_ID"
        ComboProcedureID.DisplayMember = "Procedure_Master.Daily_Procedure_Name"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MyDs.Tables("MasterRecord").Rows.Clear()
            date1 = CDate(DateTimePicker1.Text)
            date2 = CDate(DateTimePicker2.Text)
            If RadioAllProcedures.Checked = True Then
                For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
                    MyDs.Tables("MasterRecord").Columns("Daily_Procedure_Name").DefaultValue = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
                    If MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Type") = "مدين" Then
                        cmd.CommandText = "select N'رصيد أول المده' as Procedure_Desc , dbo.Get_Any_Previous_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & " , '" & date1.ToString("MM/dd/yyyy") & "') as from_balance from procedure_Master where Procedure_Master_ID=" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID")
                    Else
                        cmd.CommandText = "select N'رصيد أول المده' as Procedure_Desc , dbo.Get_Any_Previous_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & " , '" & date1.ToString("MM/dd/yyyy") & "') as to_balance from procedure_Master where Procedure_Master_ID=" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID")
                    End If
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))

                    cmd.CommandText = "SELECT D.Procedure_Desc,D.Procedure_Date,D.Procedure_Value as To_Balance FROM Procedure_Master H,Procedure_Details D,Procedure_Master H2 WHERE H.Procedure_Master_ID = D.From_Procedure_Master_ID AND H2.Procedure_Master_ID = D.TO_Procedure_Master_ID AND D.To_Procedure_Master_ID=" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & " and Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))
                    cmd.CommandText = "SELECT D.Procedure_Desc,D.Procedure_Date,D.Procedure_Value as From_Balance FROM Procedure_Master H,Procedure_Details D,Procedure_Master H2 WHERE H.Procedure_Master_ID = D.From_Procedure_Master_ID AND H2.Procedure_Master_ID = D.TO_Procedure_Master_ID AND D.From_Procedure_Master_ID=" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & " and Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))

                    cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date2.ToString("MM/dd/yyyy") & "') as procedure_balance "
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))
                Next
            ElseIf RadioProcedure.Checked = True Then

                If ComboProcedureID.SelectedValue = Nothing Then
                    cls.MsgExclamation("اختر اسم الحساب", "please enter account name")
                    Exit Sub
                Else
                    MyDs.Tables("MasterRecord").Columns("Daily_Procedure_Name").DefaultValue = ComboProcedureID.Text
                    cmd.CommandText = "select procedure_type from procedure_master where procedure_master_id = " & ComboProcedureID.SelectedValue
                    PType = cmd.ExecuteScalar
                    If PType = "مدين" Then
                        cmd.CommandText = "select N'رصيد أول المده' as Procedure_Desc ,dbo.Get_Any_Previous_Balance(" & ComboProcedureID.SelectedValue & " , '" & date1.ToString("MM/dd/yyyy") & "') as from_balance from procedure_Master where Procedure_Master_ID=" & ComboProcedureID.SelectedValue
                    Else
                        cmd.CommandText = "select N'رصيد أول المده' as Procedure_Desc ,dbo.Get_Any_Previous_Balance(" & ComboProcedureID.SelectedValue & " , '" & date1.ToString("MM/dd/yyyy") & "') as to_balance from procedure_Master where Procedure_Master_ID=" & ComboProcedureID.SelectedValue
                    End If

                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))

                    cmd.CommandText = "SELECT D.Procedure_Desc,D.Procedure_Date,D.Procedure_Value as To_Balance FROM Procedure_Master H,Procedure_Details D,Procedure_Master H2 WHERE H.Procedure_Master_ID = D.From_Procedure_Master_ID AND H2.Procedure_Master_ID = D.TO_Procedure_Master_ID AND D.To_Procedure_Master_ID=" & ComboProcedureID.SelectedValue & " and Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))
                    cmd.CommandText = "SELECT D.Procedure_Desc,D.Procedure_Date,D.Procedure_Value as From_Balance FROM Procedure_Master H,Procedure_Details D,Procedure_Master H2 WHERE H.Procedure_Master_ID = D.From_Procedure_Master_ID AND H2.Procedure_Master_ID = D.TO_Procedure_Master_ID AND D.From_Procedure_Master_ID=" & ComboProcedureID.SelectedValue & " and Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & date2.ToString("MM/dd/yyyy") & "'"
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))

                    cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & ComboProcedureID.SelectedValue & ",'" & date2.ToString("MM/dd/yyyy") & "') as procedure_balance"
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("MasterRecord"))
                End If
            End If




            rpt.SetDataSource(MyDs.Tables("MasterRecord"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            CrystalReportViewer1.ReportSource = rpt
            TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "MasterRecord")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class