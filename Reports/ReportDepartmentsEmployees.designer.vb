<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDepartmentsEmployees
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
        Me.Report = New System.Windows.Forms.TabPage()
        Me.RMeals = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bysalary = New System.Windows.Forms.RadioButton()
        Me.bydept = New System.Windows.Forms.RadioButton()
        Me.BasicSalary = New System.Windows.Forms.NumericUpDown()
        Me.Dept = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.byemp = New System.Windows.Forms.RadioButton()
        Me.Employee = New System.Windows.Forms.ComboBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.byjob = New System.Windows.Forms.RadioButton()
        Me.Job = New System.Windows.Forms.ComboBox()
        Me.Report.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BasicSalary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Report
        '
        Me.Report.Controls.Add(Me.RMeals)
        Me.Report.Location = New System.Drawing.Point(4, 22)
        Me.Report.Name = "Report"
        Me.Report.Padding = New System.Windows.Forms.Padding(3)
        Me.Report.Size = New System.Drawing.Size(883, 706)
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
        Me.RMeals.Size = New System.Drawing.Size(877, 700)
        Me.RMeals.TabIndex = 0
        Me.RMeals.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.byjob)
        Me.GroupBox1.Controls.Add(Me.Job)
        Me.GroupBox1.Controls.Add(Me.bysalary)
        Me.GroupBox1.Controls.Add(Me.bydept)
        Me.GroupBox1.Controls.Add(Me.BasicSalary)
        Me.GroupBox1.Controls.Add(Me.Dept)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.byemp)
        Me.GroupBox1.Controls.Add(Me.Employee)
        Me.GroupBox1.Location = New System.Drawing.Point(160, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 306)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'bysalary
        '
        Me.bysalary.AutoSize = True
        Me.bysalary.Location = New System.Drawing.Point(401, 187)
        Me.bysalary.Name = "bysalary"
        Me.bysalary.Size = New System.Drawing.Size(142, 17)
        Me.bysalary.TabIndex = 9
        Me.bysalary.Text = "المرتب الاساسي اكبر من"
        Me.bysalary.UseVisualStyleBackColor = True
        '
        'bydept
        '
        Me.bydept.AutoSize = True
        Me.bydept.Checked = True
        Me.bydept.Location = New System.Drawing.Point(488, 45)
        Me.bydept.Name = "bydept"
        Me.bydept.Size = New System.Drawing.Size(55, 17)
        Me.bydept.TabIndex = 8
        Me.bydept.TabStop = True
        Me.bydept.Text = "بالاداره"
        Me.bydept.UseVisualStyleBackColor = True
        '
        'BasicSalary
        '
        Me.BasicSalary.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.BasicSalary.Location = New System.Drawing.Point(47, 186)
        Me.BasicSalary.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.BasicSalary.Name = "BasicSalary"
        Me.BasicSalary.Size = New System.Drawing.Size(334, 25)
        Me.BasicSalary.TabIndex = 7
        Me.BasicSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dept
        '
        Me.Dept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Dept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Dept.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Dept.FormattingEnabled = True
        Me.Dept.Location = New System.Drawing.Point(47, 44)
        Me.Dept.Name = "Dept"
        Me.Dept.Size = New System.Drawing.Size(334, 26)
        Me.Dept.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(17, 253)
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
        Me.Button1.Location = New System.Drawing.Point(369, 253)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'byemp
        '
        Me.byemp.AutoSize = True
        Me.byemp.Location = New System.Drawing.Point(480, 99)
        Me.byemp.Name = "byemp"
        Me.byemp.Size = New System.Drawing.Size(63, 17)
        Me.byemp.TabIndex = 1
        Me.byemp.Text = "بالموظف"
        Me.byemp.UseVisualStyleBackColor = True
        '
        'Employee
        '
        Me.Employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Employee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Employee.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Employee.FormattingEnabled = True
        Me.Employee.Location = New System.Drawing.Point(47, 93)
        Me.Employee.Name = "Employee"
        Me.Employee.Size = New System.Drawing.Size(334, 26)
        Me.Employee.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(883, 706)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
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
        Me.TabControl1.Size = New System.Drawing.Size(891, 732)
        Me.TabControl1.TabIndex = 2
        '
        'byjob
        '
        Me.byjob.AutoSize = True
        Me.byjob.Location = New System.Drawing.Point(480, 142)
        Me.byjob.Name = "byjob"
        Me.byjob.Size = New System.Drawing.Size(62, 17)
        Me.byjob.TabIndex = 11
        Me.byjob.Text = "بالوظيفه"
        Me.byjob.UseVisualStyleBackColor = True
        '
        'Job
        '
        Me.Job.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Job.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Job.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Job.FormattingEnabled = True
        Me.Job.Location = New System.Drawing.Point(47, 136)
        Me.Job.Name = "Job"
        Me.Job.Size = New System.Drawing.Size(334, 26)
        Me.Job.TabIndex = 10
        '
        'ReportDepartmentsEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 732)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ReportDepartmentsEmployees"
        Me.Text = "ReportItemExpiration"
        Me.Report.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BasicSalary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents RMeals As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents byemp As System.Windows.Forms.RadioButton
    Friend WithEvents Employee As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Dept As System.Windows.Forms.ComboBox
    Friend WithEvents BasicSalary As System.Windows.Forms.NumericUpDown
    Friend WithEvents bysalary As System.Windows.Forms.RadioButton
    Friend WithEvents bydept As System.Windows.Forms.RadioButton
    Friend WithEvents byjob As System.Windows.Forms.RadioButton
    Friend WithEvents Job As System.Windows.Forms.ComboBox
End Class
