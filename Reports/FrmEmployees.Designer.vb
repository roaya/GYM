<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployees
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
        Me.AllEmployees = New System.Windows.Forms.CheckBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.todate = New System.Windows.Forms.DateTimePicker()
        Me.fromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.byjob = New System.Windows.Forms.RadioButton()
        Me.bydept = New System.Windows.Forms.RadioButton()
        Me.Coaches = New System.Windows.Forms.RadioButton()
        Me.All = New System.Windows.Forms.RadioButton()
        Me.Jobs = New System.Windows.Forms.ComboBox()
        Me.Depts = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(984, 483)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabPage1.Controls.Add(Me.AllEmployees)
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabPage1.Size = New System.Drawing.Size(976, 457)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "الاستعلام"
        '
        'AllEmployees
        '
        Me.AllEmployees.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AllEmployees.AutoSize = True
        Me.AllEmployees.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.AllEmployees.Location = New System.Drawing.Point(848, 426)
        Me.AllEmployees.Name = "AllEmployees"
        Me.AllEmployees.Size = New System.Drawing.Size(108, 22)
        Me.AllEmployees.TabIndex = 54
        Me.AllEmployees.Text = "كل الموظفين"
        Me.AllEmployees.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(310, 57)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(120, 28)
        Me.Button10.TabIndex = 53
        Me.Button10.Text = "استعلام"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(128, 423)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(114, 28)
        Me.Button9.TabIndex = 52
        Me.Button9.Text = "تقرير الحضور"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(8, 423)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(114, 28)
        Me.Button8.TabIndex = 51
        Me.Button8.Text = "تقرير المرتب"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.todate)
        Me.Panel3.Controls.Add(Me.fromdate)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(8, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(236, 77)
        Me.Panel3.TabIndex = 49
        '
        'todate
        '
        Me.todate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.todate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.todate.Location = New System.Drawing.Point(8, 38)
        Me.todate.Name = "todate"
        Me.todate.RightToLeftLayout = True
        Me.todate.Size = New System.Drawing.Size(158, 25)
        Me.todate.TabIndex = 48
        '
        'fromdate
        '
        Me.fromdate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fromdate.Location = New System.Drawing.Point(8, 7)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.RightToLeftLayout = True
        Me.fromdate.Size = New System.Drawing.Size(158, 25)
        Me.fromdate.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(172, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 18)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "الى تاريخ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(172, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "من تاريخ"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(248, 423)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(114, 28)
        Me.Button6.TabIndex = 44
        Me.Button6.Text = "تقرير المهمات"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(368, 423)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(114, 28)
        Me.Button5.TabIndex = 43
        Me.Button5.Text = "تقرير البدلات"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(488, 423)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(114, 28)
        Me.Button3.TabIndex = 42
        Me.Button3.Text = "تقرير الخصومات"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(608, 423)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(114, 28)
        Me.Button2.TabIndex = 41
        Me.Button2.Text = "تقرير المكافآت"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(728, 423)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 28)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "تقرير الأجازات"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackgroundImage = Global.GYM.My.Resources.Resources.button_smallBlue_search
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(310, 17)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(120, 28)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "عرض التقرير"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.byjob)
        Me.Panel1.Controls.Add(Me.bydept)
        Me.Panel1.Controls.Add(Me.Coaches)
        Me.Panel1.Controls.Add(Me.All)
        Me.Panel1.Controls.Add(Me.Jobs)
        Me.Panel1.Controls.Add(Me.Depts)
        Me.Panel1.Location = New System.Drawing.Point(443, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(514, 77)
        Me.Panel1.TabIndex = 38
        '
        'byjob
        '
        Me.byjob.AutoSize = True
        Me.byjob.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.byjob.Location = New System.Drawing.Point(307, 46)
        Me.byjob.Name = "byjob"
        Me.byjob.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.byjob.Size = New System.Drawing.Size(73, 22)
        Me.byjob.TabIndex = 35
        Me.byjob.Text = "الوظيفه"
        Me.byjob.UseVisualStyleBackColor = True
        '
        'bydept
        '
        Me.bydept.AutoSize = True
        Me.bydept.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.bydept.Location = New System.Drawing.Point(318, 6)
        Me.bydept.Name = "bydept"
        Me.bydept.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.bydept.Size = New System.Drawing.Size(62, 22)
        Me.bydept.TabIndex = 34
        Me.bydept.Text = "الاداره"
        Me.bydept.UseVisualStyleBackColor = True
        '
        'Coaches
        '
        Me.Coaches.AutoSize = True
        Me.Coaches.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Coaches.Location = New System.Drawing.Point(428, 44)
        Me.Coaches.Name = "Coaches"
        Me.Coaches.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Coaches.Size = New System.Drawing.Size(76, 22)
        Me.Coaches.TabIndex = 28
        Me.Coaches.Text = "المدربين"
        Me.Coaches.UseVisualStyleBackColor = True
        '
        'All
        '
        Me.All.AutoSize = True
        Me.All.Checked = True
        Me.All.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.All.Location = New System.Drawing.Point(397, 6)
        Me.All.Name = "All"
        Me.All.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.All.Size = New System.Drawing.Size(107, 22)
        Me.All.TabIndex = 27
        Me.All.TabStop = True
        Me.All.Text = "كل الموظفين"
        Me.All.UseVisualStyleBackColor = True
        '
        'Jobs
        '
        Me.Jobs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Jobs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Jobs.Enabled = False
        Me.Jobs.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Jobs.FormattingEnabled = True
        Me.Jobs.Location = New System.Drawing.Point(7, 43)
        Me.Jobs.Name = "Jobs"
        Me.Jobs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Jobs.Size = New System.Drawing.Size(294, 26)
        Me.Jobs.TabIndex = 33
        '
        'Depts
        '
        Me.Depts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Depts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Depts.Enabled = False
        Me.Depts.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Depts.FormattingEnabled = True
        Me.Depts.Location = New System.Drawing.Point(6, 4)
        Me.Depts.Name = "Depts"
        Me.Depts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Depts.Size = New System.Drawing.Size(294, 26)
        Me.Depts.TabIndex = 31
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 95)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(949, 322)
        Me.DataGridView1.TabIndex = 37
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CrystalReportViewer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(976, 457)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "نتيجة التقرير"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = -1
        Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer2.DisplayStatusBar = False
        Me.CrystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(3, 3)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        Me.CrystalReportViewer2.ShowGroupTreeButton = False
        Me.CrystalReportViewer2.ShowParameterPanelButton = False
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(970, 571)
        Me.CrystalReportViewer2.TabIndex = 1
        Me.CrystalReportViewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(984, 483)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmEmployees"
        Me.Text = "الموظفين"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Jobs As System.Windows.Forms.ComboBox
    Friend WithEvents Depts As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Coaches As System.Windows.Forms.RadioButton
    Friend WithEvents All As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents byjob As System.Windows.Forms.RadioButton
    Friend WithEvents bydept As System.Windows.Forms.RadioButton
    Friend WithEvents AllEmployees As System.Windows.Forms.CheckBox
End Class
