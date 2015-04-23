Public Class FrmCustomersEvaluations
    Dim rpt As New RptCustomersEvaluations
    Dim tbl1 As New GeneralDataSet.CustomersDataTable
    Dim tbl2 As New GeneralDataSet.Customers_EvaluationDataTable
    Dim tbl3 As New GeneralDataSet.Customers_Evaluation_DetailsDataTable
    Private Sub RadCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCustomer.CheckedChanged
        If RadCustomer.Checked = True Then
            CustomerID.Enabled = True
            EvaluationID.Enabled = False
            EvaluationDetailId.Enabled = False
        End If
    End Sub

    Private Sub RadEvaluation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEvaluation.CheckedChanged
        If RadEvaluation.Checked = True Then
            CustomerID.Enabled = True
            EvaluationID.Enabled = True
            EvaluationDetailId.Enabled = False
        End If
    End Sub

    Private Sub RadEvaluationDetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadEvaluationDetail.CheckedChanged
        If RadEvaluationDetail.Checked = True Then
            CustomerID.Enabled = True
            EvaluationID.Enabled = False
            EvaluationDetailId.Enabled = True
        End If
    End Sub

    Private Sub FrmCustomersEvaluations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from customers", tbl1)
        cls.RefreshData("select * from customers_Evaluation", tbl2)
        cls.RefreshData("select * from customers_evaluation_details", tbl3)

        CustomerID.DataSource = tbl1
        CustomerID.DisplayMember = "Customer_Name"
        CustomerID.ValueMember = "Customer_id"

        EvaluationID.DataSource = tbl2
        EvaluationID.DisplayMember = "Evaluation_Name"
        EvaluationID.ValueMember = "Evaluation_ID"

        EvaluationDetailId.DataSource = tbl3
        EvaluationDetailId.DisplayMember = "Evaluation_Detail_Name"
        EvaluationDetailId.ValueMember = "Evaluation_detail_ID"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyDs.Tables("Report_Customers_Evaluations").Rows.Clear()
        If RadCustomer.Checked = True Then
            If CustomerID.Text = "" Then
                MsgBox("من فضلك اختر اسم العميل")
                Exit Sub
            Else
                cmd.CommandText = "select * from Report_Customers_Evaluations where Customer_ID= " & CustomerID.SelectedValue

            End If

        ElseIf RadEvaluation.Checked = True Then
            If EvaluationID.Text = "" Then
                MsgBox("من فضلك اختر بند التقييم ")
                Exit Sub
            Else
                cmd.CommandText = "select * from Report_Customers_Evaluations where Evaluation_ID= " & EvaluationID.SelectedValue

            End If
        ElseIf RadEvaluationDetail.Enabled = True Then
            If EvaluationDetailId.Text = "" Then
                MsgBox("من فضلك اختر اسم التقييم")
                Exit Sub
            Else
                cmd.CommandText = "select * from Report_Customers_Evaluations where evaluation_detail_ID= " & EvaluationDetailId.SelectedValue

            End If
      
        End If
        da.Fill(MyDs.Tables("Report_Customers_Evaluations"))
        rpt.SetDataSource(MyDs.Tables("Report_Customers_Evaluations"))
        RMeals.ReportSource = rpt
        TabControl1.SelectTab(1)
    End Sub
End Class