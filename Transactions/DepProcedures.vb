Public Class DepProcedures

    Private d As Date
    Private ProMstr As New GeneralDataSet.Procedure_MasterDataTable

    Private Sub DepProcedures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from Procedure_Master where procedure_category = N'أصول ثابته'", ProMstr)
        ComboProcedureID.DataSource = ProMstr
        ComboProcedureID.DisplayMember = "Daily_Procedure_Name"
        ComboProcedureID.ValueMember = "Procedure_Master_ID"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        cmd.CommandText = "SELECT DBO.TEST_DEP_PRO_ID(N'" & ComboProcedureID.Text & "')"
        If cmd.ExecuteScalar <= 0 Then
            cls.MsgExclamation("لا يوجد حساب اهلاك لهذا الأصل برجاء انشاء حساب اهلاك خاص بالأصل المحدد", "")
        Else
            d = DepDate.Text
            cmd.CommandText = "Exec Commit_Procedure_Dep N'" & ComboProcedureID.Text & "', " & DepValue.Value & ", '" & d.ToString("MM/dd/yyyy") & "' , N'" & DepDesc.Text & " - " & EmpNameVar & "'"
            cmd.ExecuteNonQuery()
            cls.MsgInfo("تم حفظ قيد الاهلاك بنجاح", "")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboProcedureID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboProcedureID.GotFocus
        ComboProcedureID.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub ComboProcedureID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboProcedureID.Leave

        ComboProcedureID.BackColor = Color.Gainsboro
    End Sub

    Private Sub DepDesc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepDesc.GotFocus
        DepDesc.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub DepDesc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepDesc.Leave
        DepDesc.BackColor = Color.Gainsboro
    End Sub

    Private Sub DepValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepValue.GotFocus
        DepValue.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub DepValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepValue.Leave
        DepValue.BackColor = Color.Gainsboro
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseMove
        Button3.BackgroundImage = My.Resources._end
        Button3.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black
    End Sub
    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Leave
        Button3.BackgroundImage = My.Resources.enter
        Button3.ForeColor = Color.Black
    End Sub

    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.GotFocus
        Button3.BackgroundImage = My.Resources._end
        Button3.ForeColor = Color.White
    End Sub

End Class