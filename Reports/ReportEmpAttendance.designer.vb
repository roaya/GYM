<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportEmpAttendance
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
        Me.byall = New System.Windows.Forms.RadioButton()
        Me.attended_emps = New System.Windows.Forms.CheckBox()
        Me.job = New System.Windows.Forms.ComboBox()
        Me.dept = New System.Windows.Forms.ComboBox()
        Me.byjob = New System.Windows.Forms.RadioButton()
        Me.bydept = New System.Windows.Forms.RadioButton()
        Me.byemp = New System.Windows.Forms.RadioButton()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Employee = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1290, 742)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1282, 711)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.byall)
        Me.GroupBox1.Controls.Add(Me.attended_emps)
        Me.GroupBox1.Controls.Add(Me.job)
        Me.GroupBox1.Controls.Add(Me.dept)
        Me.GroupBox1.Controls.Add(Me.byjob)
        Me.GroupBox1.Controls.Add(Me.bydept)
        Me.GroupBox1.Controls.Add(Me.byemp)
        Me.GroupBox1.Controls.Add(Me.ToDate)
        Me.GroupBox1.Controls.Add(Me.FromDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Employee)
        Me.GroupBox1.Location = New System.Drawing.Point(396, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 338)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'byall
        '
        Me.byall.AutoSize = True
        Me.byall.Checked = True
        Me.byall.Location = New System.Drawing.Point(439, 36)
        Me.byall.Name = "byall"
        Me.byall.Size = New System.Drawing.Size(112, 22)
        Me.byall.TabIndex = 18
        Me.byall.TabStop = True
        Me.byall.Text = "بكل الموظفين"
        Me.byall.UseVisualStyleBackColor = True
        '
        'attended_emps
        '
        Me.attended_emps.AutoSize = True
        Me.attended_emps.Location = New System.Drawing.Point(219, 228)
        Me.attended_emps.Name = "attended_emps"
        Me.attended_emps.Size = New System.Drawing.Size(210, 22)
        Me.attended_emps.TabIndex = 17
        Me.attended_emps.Text = "الموظفين الذين لم ينصرفو بعد"
        Me.attended_emps.UseVisualStyleBackColor = True
        '
        'job
        '
        Me.job.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.job.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.job.Enabled = False
        Me.job.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.job.FormattingEnabled = True
        Me.job.Location = New System.Drawing.Point(30, 175)
        Me.job.Name = "job"
        Me.job.Size = New System.Drawing.Size(399, 26)
        Me.job.TabIndex = 16
        '
        'dept
        '
        Me.dept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.dept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dept.Enabled = False
        Me.dept.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.dept.FormattingEnabled = True
        Me.dept.Location = New System.Drawing.Point(30, 128)
        Me.dept.Name = "dept"
        Me.dept.Size = New System.Drawing.Size(399, 26)
        Me.dept.TabIndex = 15
        '
        'byjob
        '
        Me.byjob.AutoSize = True
        Me.byjob.Location = New System.Drawing.Point(478, 176)
        Me.byjob.Name = "byjob"
        Me.byjob.Size = New System.Drawing.Size(73, 22)
        Me.byjob.TabIndex = 14
        Me.byjob.Text = "الوظيفه"
        Me.byjob.UseVisualStyleBackColor = True
        '
        'bydept
        '
        Me.bydept.AutoSize = True
        Me.bydept.Location = New System.Drawing.Point(489, 129)
        Me.bydept.Name = "bydept"
        Me.bydept.Size = New System.Drawing.Size(62, 22)
        Me.bydept.TabIndex = 13
        Me.bydept.Text = "الاداره"
        Me.bydept.UseVisualStyleBackColor = True
        '
        'byemp
        '
        Me.byemp.AutoSize = True
        Me.byemp.Location = New System.Drawing.Point(443, 81)
        Me.byemp.Name = "byemp"
        Me.byemp.Size = New System.Drawing.Size(108, 22)
        Me.byemp.TabIndex = 12
        Me.byemp.Text = "اسم الموظف"
        Me.byemp.UseVisualStyleBackColor = True
        '
        'ToDate
        '
        Me.ToDate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(30, 277)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToDate.RightToLeftLayout = True
        Me.ToDate.Size = New System.Drawing.Size(200, 25)
        Me.ToDate.TabIndex = 11
        '
        'FromDate
        '
        Me.FromDate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(283, 277)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FromDate.RightToLeftLayout = True
        Me.FromDate.Size = New System.Drawing.Size(200, 25)
        Me.FromDate.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label4.Location = New System.Drawing.Point(244, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "الى"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label3.Location = New System.Drawing.Point(496, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 18)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "من :"
        '
        'Employee
        '
        Me.Employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Employee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Employee.Enabled = False
        Me.Employee.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Employee.FormattingEnabled = True
        Me.Employee.Location = New System.Drawing.Point(30, 78)
        Me.Employee.Name = "Employee"
        Me.Employee.Size = New System.Drawing.Size(399, 26)
        Me.Employee.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(725, 446)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(486, 446)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 37)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Report
        '
        Me.Report.Controls.Add(Me.RMeals)
        Me.Report.Location = New System.Drawing.Point(4, 27)
        Me.Report.Name = "Report"
        Me.Report.Padding = New System.Windows.Forms.Padding(3)
        Me.Report.Size = New System.Drawing.Size(1282, 711)
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
        Me.RMeals.Size = New System.Drawing.Size(1276, 705)
        Me.RMeals.TabIndex = 0
        Me.RMeals.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportEmpAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 742)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "ReportEmpAttendance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير حضور و انصراف العاملين"
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Employee As System.Windows.Forms.ComboBox
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents RMeals As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents job As System.Windows.Forms.ComboBox
    Friend WithEvents dept As System.Windows.Forms.ComboBox
    Friend WithEvents byjob As System.Windows.Forms.RadioButton
    Friend WithEvents bydept As System.Windows.Forms.RadioButton
    Friend WithEvents byemp As System.Windows.Forms.RadioButton
    Friend WithEvents attended_emps As System.Windows.Forms.CheckBox
    Friend WithEvents byall As System.Windows.Forms.RadioButton
End Class
