<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPaySalary
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
        Me.EmpName = New System.Windows.Forms.ComboBox()
        Me.ByAllEmps = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.toDate = New System.Windows.Forms.DateTimePicker()
        Me.fromdate = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ByEmp = New System.Windows.Forms.RadioButton()
        Me.ByDept = New System.Windows.Forms.RadioButton()
        Me.thename = New System.Windows.Forms.ComboBox()
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
        Me.TabControl1.Size = New System.Drawing.Size(1368, 748)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1360, 722)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "معاملات التقرير"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EmpName)
        Me.GroupBox1.Controls.Add(Me.ByAllEmps)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.toDate)
        Me.GroupBox1.Controls.Add(Me.fromdate)
        Me.GroupBox1.Controls.Add(Me.ByEmp)
        Me.GroupBox1.Controls.Add(Me.ByDept)
        Me.GroupBox1.Controls.Add(Me.thename)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(399, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 374)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'EmpName
        '
        Me.EmpName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.EmpName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.EmpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmpName.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.EmpName.FormattingEnabled = True
        Me.EmpName.Location = New System.Drawing.Point(72, 118)
        Me.EmpName.Name = "EmpName"
        Me.EmpName.Size = New System.Drawing.Size(296, 26)
        Me.EmpName.TabIndex = 11
        '
        'ByAllEmps
        '
        Me.ByAllEmps.AutoSize = True
        Me.ByAllEmps.Location = New System.Drawing.Point(378, 181)
        Me.ByAllEmps.Name = "ByAllEmps"
        Me.ByAllEmps.Size = New System.Drawing.Size(112, 22)
        Me.ByAllEmps.TabIndex = 10
        Me.ByAllEmps.Text = "بكل الموظفين"
        Me.ByAllEmps.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(416, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 18)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "الى تاريخ :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(415, 260)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = " من تاريخ :"
        '
        'toDate
        '
        Me.toDate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.toDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.toDate.Location = New System.Drawing.Point(72, 304)
        Me.toDate.Name = "toDate"
        Me.toDate.RightToLeftLayout = True
        Me.toDate.Size = New System.Drawing.Size(296, 25)
        Me.toDate.TabIndex = 7
        '
        'fromdate
        '
        Me.fromdate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fromdate.Location = New System.Drawing.Point(72, 255)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.RightToLeftLayout = True
        Me.fromdate.Size = New System.Drawing.Size(296, 25)
        Me.fromdate.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.enter
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(497, 538)
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
        Me.Button1.Location = New System.Drawing.Point(721, 538)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "عرض"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ByEmp
        '
        Me.ByEmp.AutoSize = True
        Me.ByEmp.Location = New System.Drawing.Point(378, 119)
        Me.ByEmp.Name = "ByEmp"
        Me.ByEmp.Size = New System.Drawing.Size(112, 22)
        Me.ByEmp.TabIndex = 2
        Me.ByEmp.Text = "باسم الموظف"
        Me.ByEmp.UseVisualStyleBackColor = True
        '
        'ByDept
        '
        Me.ByDept.AutoSize = True
        Me.ByDept.Checked = True
        Me.ByDept.Location = New System.Drawing.Point(390, 57)
        Me.ByDept.Name = "ByDept"
        Me.ByDept.Size = New System.Drawing.Size(100, 22)
        Me.ByDept.TabIndex = 1
        Me.ByDept.TabStop = True
        Me.ByDept.Text = "باسم الادارة"
        Me.ByDept.UseVisualStyleBackColor = True
        '
        'thename
        '
        Me.thename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.thename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.thename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.thename.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.thename.FormattingEnabled = True
        Me.thename.Location = New System.Drawing.Point(72, 55)
        Me.thename.Name = "thename"
        Me.thename.Size = New System.Drawing.Size(296, 26)
        Me.thename.TabIndex = 0
        '
        'Report
        '
        Me.Report.Controls.Add(Me.RMeals)
        Me.Report.Location = New System.Drawing.Point(4, 22)
        Me.Report.Name = "Report"
        Me.Report.Padding = New System.Windows.Forms.Padding(3)
        Me.Report.Size = New System.Drawing.Size(1360, 722)
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
        Me.RMeals.Size = New System.Drawing.Size(1354, 716)
        Me.RMeals.TabIndex = 0
        Me.RMeals.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportPaySalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1368, 748)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "ReportPaySalary"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مرتبات الموظفين"
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
    Friend WithEvents ByAllEmps As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents toDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ByEmp As System.Windows.Forms.RadioButton
    Friend WithEvents ByDept As System.Windows.Forms.RadioButton
    Friend WithEvents thename As System.Windows.Forms.ComboBox
    Friend WithEvents Report As System.Windows.Forms.TabPage
    Friend WithEvents RMeals As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents EmpName As System.Windows.Forms.ComboBox
End Class
