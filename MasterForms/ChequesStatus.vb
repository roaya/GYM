Public Class ChequesStatus

    Dim t As New DataTable
    Dim Did, ProMstrID As Integer

    Private Sub ChequesStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        DataGridView1.DataSource = MyDs.Tables("Query_Banks_Accounts")
        DataGridView1.Columns(0).HeaderText = "اسم البنك"
        DataGridView1.Columns(1).HeaderText = "رقم الحساب"
        DataGridView1.Columns(2).HeaderText = "رقم الشيك"
        DataGridView1.Columns(3).HeaderText = "تاريخ الاستحقاق"
        DataGridView1.Columns(4).HeaderText = "تاريخ الاستلام"
        DataGridView1.Columns(5).HeaderText = "قيمة الشيك"
        DataGridView1.Columns(6).HeaderText = "حالة الشيك"
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False

        cls.RefreshData("Procedure_Master")
        ComboProcedureID.DataSource = MyDs
        ComboProcedureID.DisplayMember = "Procedure_Master.Daily_Procedure_Name"
        ComboProcedureID.ValueMember = "Procedure_Master.Procedure_Master_ID"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MyDs.Tables("Query_Banks_Accounts").Rows.Clear()
        If RadioChequeStatus.Checked = True Then
            If ChequeStatus.Text = "" Then
                cls.MsgExclamation("ادخل حالة الشيك", "please enter cheque status")
            Else
                cmd.CommandText = "select * from Query_Banks_Accounts where cheque_status = N'" & ChequeStatus.Text & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Query_Banks_Accounts"))
                'DataGridView1.DataSource = MyDs.Tables("Query_Banks_Accounts")
            End If
        ElseIf RadioChequeNo.Checked = True Then
            If ChequeNo.Text = "" Then
                cls.MsgExclamation("ادخل رقم الشيك", "please enter cheque number")
            Else
                cmd.CommandText = "select * from Query_Banks_Accounts where cheque_number = N'" & ChequeNo.Text & "'"
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Query_Banks_Accounts"))
                'DataGridView1.DataSource = MyDs.Tables("Query_Banks_Accounts")
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count <= 0 Then
            cls.MsgExclamation("اختر رقم الشيك", "please select cheque number")
        Else

            Select Case DataGridView1.SelectedRows(0).Cells("Cheque_Status").Value
                Case "جديد"
                    cls.MsgExclamation("هذا الشيك غير مستخدم من قبل", "")
                Case "منصرف"
                    cls.MsgExclamation("هذا الشيك تم صرفه من قبل", "")
                Case "مرفوض"
                    cls.MsgExclamation("هذا الشيك تم رفضه من قبل", "")
                Case "غير محصل"
                    cls.MsgExclamation("لا يمكن صرف هذا الشيك", "")
                Case "غير منصرف"
                    cmd.CommandText = "update cheques set Cheque_Status = N'منصرف' where cheque_id = " & DataGridView1.SelectedRows(0).Cells("Cheque_ID").Value
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select dbo.Get_Bank_Procedure_ID('" & DataGridView1.SelectedRows(0).Cells("Cheque_Number").Value & "')"
                    ProMstrID = cmd.ExecuteScalar
                    cmd.CommandText = "Exec Commit_Procedure_Tran 24," & ProMstrID & "," & DataGridView1.SelectedRows(0).Cells("Cheque_Value").Value & ",N'صرف شيك'"
                    cmd.ExecuteNonQuery()
                    cls.MsgExclamation("تم صرف الشيك بنجاح", "cheque has been payed successfully")
            End Select
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DataGridView1.SelectedRows.Count <= 0 Then
            cls.MsgExclamation("اختر رقم الشيك", "please select cheque number")
        Else
            Select Case DataGridView1.SelectedRows(0).Cells("Cheque_Status").Value
                Case "جديد"
                    cls.MsgExclamation("هذا الشيك غير مستخدم من قبل", "")
                Case "محصل"
                    cls.MsgExclamation("هذا الشيك تم تحصيله من قبل", "")
                Case "مرفوض"
                    cls.MsgExclamation("هذا الشيك تم رفضه من قبل", "")
                Case "غير منصرف"
                    cls.MsgExclamation("لا يمكن تحصيل هذا الشيك", "")
                Case "غير محصل"
                    cmd.CommandText = "update cheques set Cheque_Status = N'محصل' where cheque_id = " & DataGridView1.SelectedRows(0).Cells("Cheque_ID").Value
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select dbo.Get_Bank_Procedure_ID('" & DataGridView1.SelectedRows(0).Cells("Cheque_Number").Value & "')"
                    ProMstrID = cmd.ExecuteScalar
                    cmd.CommandText = "Exec Commit_Procedure_Tran " & ProMstrID & ",23," & DataGridView1.SelectedRows(0).Cells("Cheque_Value").Value & ",N'تحصيل شيك'"
                    cmd.ExecuteNonQuery()
                    cls.MsgExclamation("تم تحصيل الشيك بنجاح", "cheque has been payed successfully")
            End Select
        End If
    End Sub

    Private Sub RadioChequeStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioChequeStatus.CheckedChanged
        If RadioChequeStatus.Checked = True Then
            ChequeStatus.Enabled = True
            ChequeNo.Enabled = False
        End If
    End Sub

    Private Sub RadioChequeNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioChequeNo.CheckedChanged
        If RadioChequeNo.Checked = True Then
            ChequeStatus.Enabled = False
            ChequeNo.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If DataGridView1.SelectedRows.Count <= 0 Then
            cls.MsgExclamation("اختر رقم الشيك", "please select cheque number")
        Else
            Select Case DataGridView1.SelectedRows(0).Cells("Cheque_Status").Value
                Case "جديد"
                    cls.MsgExclamation("هذا الشيك غير مستخدم من قبل", "")
                Case "مرفوض"
                    cls.MsgExclamation("هذا الشيك تم رفضه من قبل", "")
                Case "محصل"
                    cls.MsgExclamation("هذا الشيك تم تحصيله من قبل", "")
                Case "منصرف"
                    cls.MsgExclamation("هذا الشيك تم صرفه من قبل", "")
                Case Else
                    cmd.CommandText = "select dbo.Get_Pro_Mstr_ID_Chq_Ref(" & DataGridView1.SelectedRows(0).Cells("Cheque_ID").Value & ")"
                    ProMstrID = cmd.ExecuteScalar
                    If ProMstrID = 0 Then
                        If CheckBoxRefuseProID.Checked = True Then
                            If ComboProcedureID.Text = "" Then
                                cls.MsgExclamation("برجاء اختيار اسم الحساب الخاص برفض الشيك", "")
                            Else
                                cmd.CommandText = "update cheques set Cheque_Status = N'مرفوض' where cheque_id = " & DataGridView1.SelectedRows(0).Cells("Cheque_ID").Value
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "select dbo.Get_Bank_Procedure_ID('" & DataGridView1.SelectedRows(0).Cells("Cheque_Number").Value & "')"
                                ProMstrID = cmd.ExecuteScalar
                                Select Case DataGridView1.SelectedRows(0).Cells("Cheque_Status").Value
                                    Case "غير محصل"
                                        cmd.CommandText = "Exec Commit_Procedure_Tran " & ComboProcedureID.SelectedValue & ",23," & DataGridView1.SelectedRows(0).Cells("Cheque_Value").Value & ",N'رفض شيك'"
                                        cmd.ExecuteNonQuery()
                                    Case "غير منصرف"
                                        cmd.CommandText = "Exec Commit_Procedure_Tran 24," & ComboProcedureID.SelectedValue & "," & DataGridView1.SelectedRows(0).Cells("Cheque_Value").Value & ",N'رفض شيك'"
                                        cmd.ExecuteNonQuery()
                                End Select
                            End If
                        End If
                    Else
                        Select Case DataGridView1.SelectedRows(0).Cells("Cheque_Status").Value
                            Case "غير محصل"
                                cmd.CommandText = "Exec Commit_Procedure_Tran " & ProMstrID & ",23," & DataGridView1.SelectedRows(0).Cells("Cheque_Value").Value & ",N'رفض شيك'"
                                cmd.ExecuteNonQuery()
                            Case "غير منصرف"
                                cmd.CommandText = "Exec Commit_Procedure_Tran 24," & ProMstrID & "," & DataGridView1.SelectedRows(0).Cells("Cheque_Value").Value & ",N'رفض شيك'"
                                cmd.ExecuteNonQuery()
                        End Select
                    End If

                    cls.MsgExclamation("تم رفض الشيك بنجاح", "cheque has been payed successfully")
            End Select
        End If
    End Sub

    Private Sub ChequeNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChequeNo.GotFocus
        ChequeNo.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub ChequeNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChequeNo.Leave

        ChequeNo.BackColor = Color.Gainsboro
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
    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black

    End Sub
    Private Sub Button3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseMove
        Button3.BackgroundImage = My.Resources._end
        Button3.ForeColor = Color.White
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        Button5.BackgroundImage = My.Resources.enter
        Button5.ForeColor = Color.Black

    End Sub
    Private Sub Button5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseMove
        Button5.BackgroundImage = My.Resources._end
        Button5.ForeColor = Color.White
    End Sub


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
    Private Sub Button3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.GotFocus
        Button3.BackgroundImage = My.Resources._end
        Button3.ForeColor = Color.White
    End Sub

    Private Sub Button3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Leave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black

    End Sub

    Private Sub Button5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Leave
        Button5.BackgroundImage = My.Resources.enter
        Button5.ForeColor = Color.Black
    End Sub

    Private Sub Button5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.GotFocus
        Button5.BackgroundImage = My.Resources._end
        Button5.ForeColor = Color.White
    End Sub

End Class