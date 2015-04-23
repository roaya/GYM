<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomersEvaluations
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadEvaluationDetail = New System.Windows.Forms.RadioButton()
        Me.EvaluationDetailId = New System.Windows.Forms.ComboBox()
        Me.RadCustomer = New System.Windows.Forms.RadioButton()
        Me.CustomerID = New System.Windows.Forms.ComboBox()
        Me.RadEvaluation = New System.Windows.Forms.RadioButton()
        Me.EvaluationID = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Report = New System.Windows.Forms.TabPage()
        Me.RMeals = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Report.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.Report)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1284, 742)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1276, 716)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadEvaluationDetail)
        Me.GroupBox1.Controls.Add(Me.EvaluationDetailId)
        Me.GroupBox1.Controls.Add(Me.RadCustomer)
        Me.GroupBox1.Controls.Add(Me.CustomerID)
        Me.GroupBox1.Controls.Add(Me.RadEvaluation)
        Me.GroupBox1.Controls.Add(Me.EvaluationID)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(435, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 219)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'RadEvaluationDetail
        '
        Me.RadEvaluationDetail.AutoSize = True
        Me.RadEvaluationDetail.Location = New System.Drawing.Point(335, 146)
        Me.RadEvaluationDetail.Name = "RadEvaluationDetail"
        Me.RadEvaluationDetail.Size = New System.Drawing.Size(101, 22)
        Me.RadEvaluationDetail.TabIndex = 11
        Me.RadEvaluationDetail.Text = "اسم التقييم"
        Me.RadEvaluationDetail.UseVisualStyleBackColor = True
        '
        'EvaluationDetailId
        '
        Me.EvaluationDetailId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.EvaluationDetailId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.EvaluationDetailId.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.EvaluationDetailId.FormattingEnabled = True
        Me.EvaluationDetailId.Location = New System.Drawing.Point(56, 145)
        Me.EvaluationDetailId.Name = "EvaluationDetailId"
        Me.EvaluationDetailId.Size = New System.Drawing.Size(258, 26)
        Me.EvaluationDetailId.TabIndex = 10
        '
        'RadCustomer
        '
        Me.RadCustomer.AutoSize = True
        Me.RadCustomer.Checked = True
        Me.RadCustomer.Location = New System.Drawing.Point(336, 50)
        Me.RadCustomer.Name = "RadCustomer"
        Me.RadCustomer.Size = New System.Drawing.Size(100, 22)
        Me.RadCustomer.TabIndex = 8
        Me.RadCustomer.TabStop = True
        Me.RadCustomer.Text = "اسم العميل"
        Me.RadCustomer.UseVisualStyleBackColor = True
        '
        'CustomerID
        '
        Me.CustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustomerID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.CustomerID.FormattingEnabled = True
        Me.CustomerID.Location = New System.Drawing.Point(56, 50)
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.Size = New System.Drawing.Size(258, 26)
        Me.CustomerID.TabIndex = 6
        '
        'RadEvaluation
        '
        Me.RadEvaluation.AutoSize = True
        Me.RadEvaluation.Location = New System.Drawing.Point(347, 100)
        Me.RadEvaluation.Name = "RadEvaluation"
        Me.RadEvaluation.Size = New System.Drawing.Size(89, 22)
        Me.RadEvaluation.TabIndex = 1
        Me.RadEvaluation.Text = "بند التقييم"
        Me.RadEvaluation.UseVisualStyleBackColor = True
        '
        'EvaluationID
        '
        Me.EvaluationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.EvaluationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.EvaluationID.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.EvaluationID.FormattingEnabled = True
        Me.EvaluationID.Location = New System.Drawing.Point(56, 99)
        Me.EvaluationID.Name = "EvaluationID"
        Me.EvaluationID.Size = New System.Drawing.Size(258, 26)
        Me.EvaluationID.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(461, 422)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 37)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(758, 422)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Report
        '
        Me.Report.Controls.Add(Me.RMeals)
        Me.Report.Location = New System.Drawing.Point(4, 22)
        Me.Report.Name = "Report"
        Me.Report.Padding = New System.Windows.Forms.Padding(3)
        Me.Report.Size = New System.Drawing.Size(1354, 716)
        Me.Report.TabIndex = 1
        Me.Report.Text = "التقرير"
        Me.Report.UseVisualStyleBackColor = True
        '
        'RMeals
        '
        Me.RMeals.ActiveViewIndex = -1
        Me.RMeals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RMeals.Cursor = System.Windows.Forms.Cursors.Default
        Me.RMeals.DisplayStatusBar = False
        Me.RMeals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RMeals.Location = New System.Drawing.Point(3, 3)
        Me.RMeals.Name = "RMeals"
        Me.RMeals.ShowCloseButton = False
        Me.RMeals.ShowCopyButton = False
        Me.RMeals.ShowGroupTreeButton = False
        Me.RMeals.ShowParameterPanelButton = False
        Me.RMeals.Size = New System.Drawing.Size(1356, 718)
        Me.RMeals.TabIndex = 0
        Me.RMeals.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmCustomersEvaluations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 742)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmCustomersEvaluations"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير تقييمات العملاء"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Report.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadEvaluationDetail As System.Windows.Forms.RadioButton
    Friend WithEvents EvaluationDetailId As System.Windows.Forms.ComboBox
    Friend WithEvents RadCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents CustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents RadEvaluation As System.Windows.Forms.RadioButton
    Friend WithEvents EvaluationID As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents RMeals As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
